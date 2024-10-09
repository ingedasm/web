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
   public class gx0090 : GXDataArea
   {
      public gx0090( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("IndicadroresPalmas", true);
      }

      public gx0090( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out DateTime aP0_pCOSTOHEFecha ,
                           out short aP1_pCOSTOHEMes ,
                           out short aP2_pCOSTOHEAno ,
                           out string aP3_pIndicadoresCodigo ,
                           out string aP4_pCod_Area )
      {
         this.AV13pCOSTOHEFecha = DateTime.MinValue ;
         this.AV14pCOSTOHEMes = 0 ;
         this.AV15pCOSTOHEAno = 0 ;
         this.AV16pIndicadoresCodigo = "" ;
         this.AV17pCod_Area = "" ;
         executePrivate();
         aP0_pCOSTOHEFecha=this.AV13pCOSTOHEFecha;
         aP1_pCOSTOHEMes=this.AV14pCOSTOHEMes;
         aP2_pCOSTOHEAno=this.AV15pCOSTOHEAno;
         aP3_pIndicadoresCodigo=this.AV16pIndicadoresCodigo;
         aP4_pCod_Area=this.AV17pCod_Area;
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
            gxfirstwebparm = GetFirstPar( "pCOSTOHEFecha");
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
               gxfirstwebparm = GetFirstPar( "pCOSTOHEFecha");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pCOSTOHEFecha");
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
               AV13pCOSTOHEFecha = context.localUtil.ParseDateParm( gxfirstwebparm);
               AssignAttri("", false, "AV13pCOSTOHEFecha", context.localUtil.Format(AV13pCOSTOHEFecha, "99/99/99"));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV14pCOSTOHEMes = (short)(Math.Round(NumberUtil.Val( GetPar( "pCOSTOHEMes"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV14pCOSTOHEMes", StringUtil.LTrimStr( (decimal)(AV14pCOSTOHEMes), 4, 0));
                  AV15pCOSTOHEAno = (short)(Math.Round(NumberUtil.Val( GetPar( "pCOSTOHEAno"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV15pCOSTOHEAno", StringUtil.LTrimStr( (decimal)(AV15pCOSTOHEAno), 4, 0));
                  AV16pIndicadoresCodigo = GetPar( "pIndicadoresCodigo");
                  AssignAttri("", false, "AV16pIndicadoresCodigo", AV16pIndicadoresCodigo);
                  AV17pCod_Area = GetPar( "pCod_Area");
                  AssignAttri("", false, "AV17pCod_Area", AV17pCod_Area);
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
         AV6cCOSTOHEFecha = context.localUtil.ParseDateParm( GetPar( "cCOSTOHEFecha"));
         AV7cCOSTOHEMes = (short)(Math.Round(NumberUtil.Val( GetPar( "cCOSTOHEMes"), "."), 18, MidpointRounding.ToEven));
         AV8cCOSTOHEAno = (short)(Math.Round(NumberUtil.Val( GetPar( "cCOSTOHEAno"), "."), 18, MidpointRounding.ToEven));
         AV9cIndicadoresCodigo = GetPar( "cIndicadoresCodigo");
         AV10cCod_Area = GetPar( "cCod_Area");
         AV11cCOSTOHEValor = NumberUtil.Val( GetPar( "cCOSTOHEValor"), ".");
         AV12cCOSTOHETotHoras = (int)(Math.Round(NumberUtil.Val( GetPar( "cCOSTOHETotHoras"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cCOSTOHEFecha, AV7cCOSTOHEMes, AV8cCOSTOHEAno, AV9cIndicadoresCodigo, AV10cCod_Area, AV11cCOSTOHEValor, AV12cCOSTOHETotHoras) ;
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
         PA0B2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0B2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0090.aspx", new object[] {UrlEncode(DateTimeUtil.FormatDateParm(AV13pCOSTOHEFecha)),UrlEncode(StringUtil.LTrimStr(AV14pCOSTOHEMes,4,0)),UrlEncode(StringUtil.LTrimStr(AV15pCOSTOHEAno,4,0)),UrlEncode(StringUtil.RTrim(AV16pIndicadoresCodigo)),UrlEncode(StringUtil.RTrim(AV17pCod_Area))}, new string[] {"pCOSTOHEFecha","pCOSTOHEMes","pCOSTOHEAno","pIndicadoresCodigo","pCod_Area"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCCOSTOHEFECHA", context.localUtil.Format(AV6cCOSTOHEFecha, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vCCOSTOHEMES", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cCOSTOHEMes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCOSTOHEANO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cCOSTOHEAno), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCINDICADORESCODIGO", AV9cIndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "GXH_vCCOD_AREA", AV10cCod_Area);
         GxWebStd.gx_hidden_field( context, "GXH_vCCOSTOHEVALOR", StringUtil.LTrim( StringUtil.NToC( AV11cCOSTOHEValor, 12, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCOSTOHETOTHORAS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12cCOSTOHETotHoras), 6, 0, ",", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPCOSTOHEFECHA", context.localUtil.DToC( AV13pCOSTOHEFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vPCOSTOHEMES", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14pCOSTOHEMes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPCOSTOHEANO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15pCOSTOHEAno), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPINDICADORESCODIGO", AV16pIndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "vPCOD_AREA", AV17pCod_Area);
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "COSTOHEFECHAFILTERCONTAINER_Class", StringUtil.RTrim( divCostohefechafiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "COSTOHEMESFILTERCONTAINER_Class", StringUtil.RTrim( divCostohemesfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "COSTOHEANOFILTERCONTAINER_Class", StringUtil.RTrim( divCostoheanofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "INDICADORESCODIGOFILTERCONTAINER_Class", StringUtil.RTrim( divIndicadorescodigofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "COD_AREAFILTERCONTAINER_Class", StringUtil.RTrim( divCod_areafiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "COSTOHEVALORFILTERCONTAINER_Class", StringUtil.RTrim( divCostohevalorfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "COSTOHETOTHORASFILTERCONTAINER_Class", StringUtil.RTrim( divCostohetothorasfiltercontainer_Class));
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
            WE0B2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0B2( ) ;
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
         return formatLink("gx0090.aspx", new object[] {UrlEncode(DateTimeUtil.FormatDateParm(AV13pCOSTOHEFecha)),UrlEncode(StringUtil.LTrimStr(AV14pCOSTOHEMes,4,0)),UrlEncode(StringUtil.LTrimStr(AV15pCOSTOHEAno,4,0)),UrlEncode(StringUtil.RTrim(AV16pIndicadoresCodigo)),UrlEncode(StringUtil.RTrim(AV17pCod_Area))}, new string[] {"pCOSTOHEFecha","pCOSTOHEMes","pCOSTOHEAno","pIndicadoresCodigo","pCod_Area"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx0090" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List COSTOHE" ;
      }

      protected void WB0B0( )
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
            GxWebStd.gx_div_start( context, divCostohefechafiltercontainer_Internalname, 1, 0, "px", 0, "px", divCostohefechafiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcostohefechafilter_Internalname, "COSTOHEFecha", "", "", lblLblcostohefechafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e110b1_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcostohefecha_Internalname, "COSTOHEFecha", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCcostohefecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCcostohefecha_Internalname, context.localUtil.Format(AV6cCOSTOHEFecha, "99/99/99"), context.localUtil.Format( AV6cCOSTOHEFecha, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcostohefecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCcostohefecha_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx0090.htm");
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
            GxWebStd.gx_div_start( context, divCostohemesfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCostohemesfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcostohemesfilter_Internalname, "COSTOHEMes", "", "", lblLblcostohemesfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e120b1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcostohemes_Internalname, "COSTOHEMes", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcostohemes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cCOSTOHEMes), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCcostohemes_Enabled!=0) ? context.localUtil.Format( (decimal)(AV7cCOSTOHEMes), "ZZZ9") : context.localUtil.Format( (decimal)(AV7cCOSTOHEMes), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcostohemes_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcostohemes_Visible, edtavCcostohemes_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx0090.htm");
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
            GxWebStd.gx_div_start( context, divCostoheanofiltercontainer_Internalname, 1, 0, "px", 0, "px", divCostoheanofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcostoheanofilter_Internalname, "COSTOHEAno", "", "", lblLblcostoheanofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e130b1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcostoheano_Internalname, "COSTOHEAno", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcostoheano_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cCOSTOHEAno), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCcostoheano_Enabled!=0) ? context.localUtil.Format( (decimal)(AV8cCOSTOHEAno), "ZZZ9") : context.localUtil.Format( (decimal)(AV8cCOSTOHEAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcostoheano_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcostoheano_Visible, edtavCcostoheano_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx0090.htm");
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
            GxWebStd.gx_label_ctrl( context, lblLblindicadorescodigofilter_Internalname, "Indicadores Codigo", "", "", lblLblindicadorescodigofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e140b1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0090.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavCindicadorescodigo_Internalname, AV9cIndicadoresCodigo, StringUtil.RTrim( context.localUtil.Format( AV9cIndicadoresCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCindicadorescodigo_Jsonclick, 0, "Attribute", "", "", "", "", edtavCindicadorescodigo_Visible, edtavCindicadorescodigo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Gx0090.htm");
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
            GxWebStd.gx_label_ctrl( context, lblLblcod_areafilter_Internalname, "Cod_Area", "", "", lblLblcod_areafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e150b1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0090.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavCcod_area_Internalname, AV10cCod_Area, StringUtil.RTrim( context.localUtil.Format( AV10cCod_Area, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcod_area_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcod_area_Visible, edtavCcod_area_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Gx0090.htm");
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
            GxWebStd.gx_div_start( context, divCostohevalorfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCostohevalorfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcostohevalorfilter_Internalname, "COSTOHEValor", "", "", lblLblcostohevalorfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e160b1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcostohevalor_Internalname, "COSTOHEValor", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcostohevalor_Internalname, StringUtil.LTrim( StringUtil.NToC( AV11cCOSTOHEValor, 12, 2, ",", "")), StringUtil.LTrim( ((edtavCcostohevalor_Enabled!=0) ? context.localUtil.Format( AV11cCOSTOHEValor, "ZZZZZZZZ9.99") : context.localUtil.Format( AV11cCOSTOHEValor, "ZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcostohevalor_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcostohevalor_Visible, edtavCcostohevalor_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx0090.htm");
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
            GxWebStd.gx_div_start( context, divCostohetothorasfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCostohetothorasfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcostohetothorasfilter_Internalname, "COSTOHETot Horas", "", "", lblLblcostohetothorasfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e170b1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcostohetothoras_Internalname, "COSTOHETot Horas", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcostohetothoras_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12cCOSTOHETotHoras), 6, 0, ",", "")), StringUtil.LTrim( ((edtavCcostohetothoras_Enabled!=0) ? context.localUtil.Format( (decimal)(AV12cCOSTOHETotHoras), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV12cCOSTOHETotHoras), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcostohetothoras_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcostohetothoras_Visible, edtavCcostohetothoras_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx0090.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e180b1_client"+"'", TempTags, "", 2, "HLP_Gx0090.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0090.htm");
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

      protected void START0B2( )
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
            Form.Meta.addItem("description", "Selection List COSTOHE", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0B0( ) ;
      }

      protected void WS0B2( )
      {
         START0B2( ) ;
         EVT0B2( ) ;
      }

      protected void EVT0B2( )
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
                              A21COSTOHEFecha = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtCOSTOHEFecha_Internalname), 0));
                              A22COSTOHEMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCOSTOHEMes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A23COSTOHEAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCOSTOHEAno_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A4IndicadoresCodigo = cgiGet( edtIndicadoresCodigo_Internalname);
                              A5Cod_Area = cgiGet( edtCod_Area_Internalname);
                              A131COSTOHEValor = context.localUtil.CToN( cgiGet( edtCOSTOHEValor_Internalname), ",", ".");
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E190B2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E200B2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Ccostohefecha Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCCOSTOHEFECHA"), 0) != AV6cCOSTOHEFecha )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccostohemes Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCOSTOHEMES"), ",", ".") != Convert.ToDecimal( AV7cCOSTOHEMes )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccostoheano Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCOSTOHEANO"), ",", ".") != Convert.ToDecimal( AV8cCOSTOHEAno )) )
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
                                       /* Set Refresh If Ccostohevalor Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCCOSTOHEVALOR"), ",", ".") != AV11cCOSTOHEValor )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccostohetothoras Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCOSTOHETOTHORAS"), ",", ".") != Convert.ToDecimal( AV12cCOSTOHETotHoras )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E210B2 ();
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

      protected void WE0B2( )
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

      protected void PA0B2( )
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
                                        DateTime AV6cCOSTOHEFecha ,
                                        short AV7cCOSTOHEMes ,
                                        short AV8cCOSTOHEAno ,
                                        string AV9cIndicadoresCodigo ,
                                        string AV10cCod_Area ,
                                        decimal AV11cCOSTOHEValor ,
                                        int AV12cCOSTOHETotHoras )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF0B2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_COSTOHEFECHA", GetSecureSignedToken( "", A21COSTOHEFecha, context));
         GxWebStd.gx_hidden_field( context, "COSTOHEFECHA", context.localUtil.Format(A21COSTOHEFecha, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "gxhash_COSTOHEMES", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A22COSTOHEMes), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "COSTOHEMES", StringUtil.LTrim( StringUtil.NToC( (decimal)(A22COSTOHEMes), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_COSTOHEANO", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A23COSTOHEAno), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "COSTOHEANO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A23COSTOHEAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_INDICADORESCODIGO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A4IndicadoresCodigo, "")), context));
         GxWebStd.gx_hidden_field( context, "INDICADORESCODIGO", A4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "gxhash_COD_AREA", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A5Cod_Area, "")), context));
         GxWebStd.gx_hidden_field( context, "COD_AREA", A5Cod_Area);
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
         RF0B2( ) ;
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

      protected void RF0B2( )
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
                                                 AV11cCOSTOHEValor ,
                                                 AV12cCOSTOHETotHoras ,
                                                 A131COSTOHEValor ,
                                                 A237COSTOHETotHoras ,
                                                 A4IndicadoresCodigo ,
                                                 AV9cIndicadoresCodigo ,
                                                 A5Cod_Area ,
                                                 AV10cCod_Area ,
                                                 AV6cCOSTOHEFecha ,
                                                 AV7cCOSTOHEMes ,
                                                 AV8cCOSTOHEAno } ,
                                                 new int[]{
                                                 TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            lV9cIndicadoresCodigo = StringUtil.Concat( StringUtil.RTrim( AV9cIndicadoresCodigo), "%", "");
            lV10cCod_Area = StringUtil.Concat( StringUtil.RTrim( AV10cCod_Area), "%", "");
            /* Using cursor H000B2 */
            pr_default.execute(0, new Object[] {AV6cCOSTOHEFecha, AV7cCOSTOHEMes, AV8cCOSTOHEAno, lV9cIndicadoresCodigo, lV10cCod_Area, AV11cCOSTOHEValor, AV12cCOSTOHETotHoras, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A237COSTOHETotHoras = H000B2_A237COSTOHETotHoras[0];
               A131COSTOHEValor = H000B2_A131COSTOHEValor[0];
               A5Cod_Area = H000B2_A5Cod_Area[0];
               A4IndicadoresCodigo = H000B2_A4IndicadoresCodigo[0];
               A23COSTOHEAno = H000B2_A23COSTOHEAno[0];
               A22COSTOHEMes = H000B2_A22COSTOHEMes[0];
               A21COSTOHEFecha = H000B2_A21COSTOHEFecha[0];
               /* Execute user event: Load */
               E200B2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WB0B0( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0B2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_COSTOHEFECHA"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, A21COSTOHEFecha, context));
         GxWebStd.gx_hidden_field( context, "gxhash_COSTOHEMES"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A22COSTOHEMes), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_COSTOHEANO"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A23COSTOHEAno), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_INDICADORESCODIGO"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, StringUtil.RTrim( context.localUtil.Format( A4IndicadoresCodigo, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_COD_AREA"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, StringUtil.RTrim( context.localUtil.Format( A5Cod_Area, "")), context));
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
                                              AV11cCOSTOHEValor ,
                                              AV12cCOSTOHETotHoras ,
                                              A131COSTOHEValor ,
                                              A237COSTOHETotHoras ,
                                              A4IndicadoresCodigo ,
                                              AV9cIndicadoresCodigo ,
                                              A5Cod_Area ,
                                              AV10cCod_Area ,
                                              AV6cCOSTOHEFecha ,
                                              AV7cCOSTOHEMes ,
                                              AV8cCOSTOHEAno } ,
                                              new int[]{
                                              TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV9cIndicadoresCodigo = StringUtil.Concat( StringUtil.RTrim( AV9cIndicadoresCodigo), "%", "");
         lV10cCod_Area = StringUtil.Concat( StringUtil.RTrim( AV10cCod_Area), "%", "");
         /* Using cursor H000B3 */
         pr_default.execute(1, new Object[] {AV6cCOSTOHEFecha, AV7cCOSTOHEMes, AV8cCOSTOHEAno, lV9cIndicadoresCodigo, lV10cCod_Area, AV11cCOSTOHEValor, AV12cCOSTOHETotHoras});
         GRID1_nRecordCount = H000B3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCOSTOHEFecha, AV7cCOSTOHEMes, AV8cCOSTOHEAno, AV9cIndicadoresCodigo, AV10cCod_Area, AV11cCOSTOHEValor, AV12cCOSTOHETotHoras) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCOSTOHEFecha, AV7cCOSTOHEMes, AV8cCOSTOHEAno, AV9cIndicadoresCodigo, AV10cCod_Area, AV11cCOSTOHEValor, AV12cCOSTOHETotHoras) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCOSTOHEFecha, AV7cCOSTOHEMes, AV8cCOSTOHEAno, AV9cIndicadoresCodigo, AV10cCod_Area, AV11cCOSTOHEValor, AV12cCOSTOHETotHoras) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCOSTOHEFecha, AV7cCOSTOHEMes, AV8cCOSTOHEAno, AV9cIndicadoresCodigo, AV10cCod_Area, AV11cCOSTOHEValor, AV12cCOSTOHETotHoras) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCOSTOHEFecha, AV7cCOSTOHEMes, AV8cCOSTOHEAno, AV9cIndicadoresCodigo, AV10cCod_Area, AV11cCOSTOHEValor, AV12cCOSTOHETotHoras) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0B0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E190B2 ();
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
            if ( context.localUtil.VCDate( cgiGet( edtavCcostohefecha_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"COSTOHEFecha"}), 1, "vCCOSTOHEFECHA");
               GX_FocusControl = edtavCcostohefecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cCOSTOHEFecha = DateTime.MinValue;
               AssignAttri("", false, "AV6cCOSTOHEFecha", context.localUtil.Format(AV6cCOSTOHEFecha, "99/99/99"));
            }
            else
            {
               AV6cCOSTOHEFecha = context.localUtil.CToD( cgiGet( edtavCcostohefecha_Internalname), 2);
               AssignAttri("", false, "AV6cCOSTOHEFecha", context.localUtil.Format(AV6cCOSTOHEFecha, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcostohemes_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcostohemes_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCOSTOHEMES");
               GX_FocusControl = edtavCcostohemes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7cCOSTOHEMes = 0;
               AssignAttri("", false, "AV7cCOSTOHEMes", StringUtil.LTrimStr( (decimal)(AV7cCOSTOHEMes), 4, 0));
            }
            else
            {
               AV7cCOSTOHEMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCcostohemes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7cCOSTOHEMes", StringUtil.LTrimStr( (decimal)(AV7cCOSTOHEMes), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcostoheano_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcostoheano_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCOSTOHEANO");
               GX_FocusControl = edtavCcostoheano_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cCOSTOHEAno = 0;
               AssignAttri("", false, "AV8cCOSTOHEAno", StringUtil.LTrimStr( (decimal)(AV8cCOSTOHEAno), 4, 0));
            }
            else
            {
               AV8cCOSTOHEAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCcostoheano_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV8cCOSTOHEAno", StringUtil.LTrimStr( (decimal)(AV8cCOSTOHEAno), 4, 0));
            }
            AV9cIndicadoresCodigo = cgiGet( edtavCindicadorescodigo_Internalname);
            AssignAttri("", false, "AV9cIndicadoresCodigo", AV9cIndicadoresCodigo);
            AV10cCod_Area = cgiGet( edtavCcod_area_Internalname);
            AssignAttri("", false, "AV10cCod_Area", AV10cCod_Area);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcostohevalor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcostohevalor_Internalname), ",", ".") > 999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCOSTOHEVALOR");
               GX_FocusControl = edtavCcostohevalor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11cCOSTOHEValor = 0;
               AssignAttri("", false, "AV11cCOSTOHEValor", StringUtil.LTrimStr( AV11cCOSTOHEValor, 12, 2));
            }
            else
            {
               AV11cCOSTOHEValor = context.localUtil.CToN( cgiGet( edtavCcostohevalor_Internalname), ",", ".");
               AssignAttri("", false, "AV11cCOSTOHEValor", StringUtil.LTrimStr( AV11cCOSTOHEValor, 12, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcostohetothoras_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcostohetothoras_Internalname), ",", ".") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCOSTOHETOTHORAS");
               GX_FocusControl = edtavCcostohetothoras_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12cCOSTOHETotHoras = 0;
               AssignAttri("", false, "AV12cCOSTOHETotHoras", StringUtil.LTrimStr( (decimal)(AV12cCOSTOHETotHoras), 6, 0));
            }
            else
            {
               AV12cCOSTOHETotHoras = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCcostohetothoras_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12cCOSTOHETotHoras", StringUtil.LTrimStr( (decimal)(AV12cCOSTOHETotHoras), 6, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vCCOSTOHEFECHA"), 2) ) != DateTimeUtil.ResetTime ( AV6cCOSTOHEFecha ) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCOSTOHEMES"), ",", ".") != Convert.ToDecimal( AV7cCOSTOHEMes )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCOSTOHEANO"), ",", ".") != Convert.ToDecimal( AV8cCOSTOHEAno )) )
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
            if ( context.localUtil.CToN( cgiGet( "GXH_vCCOSTOHEVALOR"), ",", ".") != AV11cCOSTOHEValor )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCOSTOHETOTHORAS"), ",", ".") != Convert.ToDecimal( AV12cCOSTOHETotHoras )) )
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
         E190B2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E190B2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Lista de Selección %1", "COSTOHE", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV18ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E200B2( )
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
         E210B2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E210B2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pCOSTOHEFecha = A21COSTOHEFecha;
         AssignAttri("", false, "AV13pCOSTOHEFecha", context.localUtil.Format(AV13pCOSTOHEFecha, "99/99/99"));
         AV14pCOSTOHEMes = A22COSTOHEMes;
         AssignAttri("", false, "AV14pCOSTOHEMes", StringUtil.LTrimStr( (decimal)(AV14pCOSTOHEMes), 4, 0));
         AV15pCOSTOHEAno = A23COSTOHEAno;
         AssignAttri("", false, "AV15pCOSTOHEAno", StringUtil.LTrimStr( (decimal)(AV15pCOSTOHEAno), 4, 0));
         AV16pIndicadoresCodigo = A4IndicadoresCodigo;
         AssignAttri("", false, "AV16pIndicadoresCodigo", AV16pIndicadoresCodigo);
         AV17pCod_Area = A5Cod_Area;
         AssignAttri("", false, "AV17pCod_Area", AV17pCod_Area);
         context.setWebReturnParms(new Object[] {context.localUtil.Format( AV13pCOSTOHEFecha, "99/99/99"),(short)AV14pCOSTOHEMes,(short)AV15pCOSTOHEAno,(string)AV16pIndicadoresCodigo,(string)AV17pCod_Area});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pCOSTOHEFecha","AV14pCOSTOHEMes","AV15pCOSTOHEAno","AV16pIndicadoresCodigo","AV17pCod_Area"});
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
         AV13pCOSTOHEFecha = (DateTime)getParm(obj,0);
         AssignAttri("", false, "AV13pCOSTOHEFecha", context.localUtil.Format(AV13pCOSTOHEFecha, "99/99/99"));
         AV14pCOSTOHEMes = Convert.ToInt16(getParm(obj,1));
         AssignAttri("", false, "AV14pCOSTOHEMes", StringUtil.LTrimStr( (decimal)(AV14pCOSTOHEMes), 4, 0));
         AV15pCOSTOHEAno = Convert.ToInt16(getParm(obj,2));
         AssignAttri("", false, "AV15pCOSTOHEAno", StringUtil.LTrimStr( (decimal)(AV15pCOSTOHEAno), 4, 0));
         AV16pIndicadoresCodigo = (string)getParm(obj,3);
         AssignAttri("", false, "AV16pIndicadoresCodigo", AV16pIndicadoresCodigo);
         AV17pCod_Area = (string)getParm(obj,4);
         AssignAttri("", false, "AV17pCod_Area", AV17pCod_Area);
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
         PA0B2( ) ;
         WS0B2( ) ;
         WE0B2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024723101564", true, true);
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
         context.AddJavascriptSource("gx0090.js", "?2024723101564", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtCOSTOHEFecha_Internalname = "COSTOHEFECHA_"+sGXsfl_84_idx;
         edtCOSTOHEMes_Internalname = "COSTOHEMES_"+sGXsfl_84_idx;
         edtCOSTOHEAno_Internalname = "COSTOHEANO_"+sGXsfl_84_idx;
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO_"+sGXsfl_84_idx;
         edtCod_Area_Internalname = "COD_AREA_"+sGXsfl_84_idx;
         edtCOSTOHEValor_Internalname = "COSTOHEVALOR_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtCOSTOHEFecha_Internalname = "COSTOHEFECHA_"+sGXsfl_84_fel_idx;
         edtCOSTOHEMes_Internalname = "COSTOHEMES_"+sGXsfl_84_fel_idx;
         edtCOSTOHEAno_Internalname = "COSTOHEANO_"+sGXsfl_84_fel_idx;
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO_"+sGXsfl_84_fel_idx;
         edtCod_Area_Internalname = "COD_AREA_"+sGXsfl_84_fel_idx;
         edtCOSTOHEValor_Internalname = "COSTOHEVALOR_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         SubsflControlProps_842( ) ;
         WB0B0( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( context.localUtil.Format(A21COSTOHEFecha, "99/99/99"))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A22COSTOHEMes), 4, 0, ",", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A23COSTOHEAno), 4, 0, ",", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( A4IndicadoresCodigo)+"'"+", "+"'"+GXUtil.EncodeJSConstant( A5Cod_Area)+"'"+"]);";
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
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCOSTOHEFecha_Internalname,context.localUtil.Format(A21COSTOHEFecha, "99/99/99"),context.localUtil.Format( A21COSTOHEFecha, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCOSTOHEFecha_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCOSTOHEMes_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A22COSTOHEMes), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A22COSTOHEMes), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCOSTOHEMes_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCOSTOHEAno_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A23COSTOHEAno), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A23COSTOHEAno), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCOSTOHEAno_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
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
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtCOSTOHEValor_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( context.localUtil.Format(A21COSTOHEFecha, "99/99/99"))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A22COSTOHEMes), 4, 0, ",", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A23COSTOHEAno), 4, 0, ",", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( A4IndicadoresCodigo)+"'"+", "+"'"+GXUtil.EncodeJSConstant( A5Cod_Area)+"'"+"]);";
            AssignProp("", false, edtCOSTOHEValor_Internalname, "Link", edtCOSTOHEValor_Link, !bGXsfl_84_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCOSTOHEValor_Internalname,StringUtil.LTrim( StringUtil.NToC( A131COSTOHEValor, 12, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A131COSTOHEValor, "ZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtCOSTOHEValor_Link,(string)"",(string)"",(string)"",(string)edtCOSTOHEValor_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes0B2( ) ;
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
            context.SendWebValue( "COSTOHEFecha") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "COSTOHEMes") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "COSTOHEAno") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Indicadores Codigo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Cod_Area") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "COSTOHEValor") ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A21COSTOHEFecha, "99/99/99")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A22COSTOHEMes), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A23COSTOHEAno), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A4IndicadoresCodigo));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A5Cod_Area));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A131COSTOHEValor, 12, 2, ".", ""))));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtCOSTOHEValor_Link));
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
         lblLblcostohefechafilter_Internalname = "LBLCOSTOHEFECHAFILTER";
         edtavCcostohefecha_Internalname = "vCCOSTOHEFECHA";
         divCostohefechafiltercontainer_Internalname = "COSTOHEFECHAFILTERCONTAINER";
         lblLblcostohemesfilter_Internalname = "LBLCOSTOHEMESFILTER";
         edtavCcostohemes_Internalname = "vCCOSTOHEMES";
         divCostohemesfiltercontainer_Internalname = "COSTOHEMESFILTERCONTAINER";
         lblLblcostoheanofilter_Internalname = "LBLCOSTOHEANOFILTER";
         edtavCcostoheano_Internalname = "vCCOSTOHEANO";
         divCostoheanofiltercontainer_Internalname = "COSTOHEANOFILTERCONTAINER";
         lblLblindicadorescodigofilter_Internalname = "LBLINDICADORESCODIGOFILTER";
         edtavCindicadorescodigo_Internalname = "vCINDICADORESCODIGO";
         divIndicadorescodigofiltercontainer_Internalname = "INDICADORESCODIGOFILTERCONTAINER";
         lblLblcod_areafilter_Internalname = "LBLCOD_AREAFILTER";
         edtavCcod_area_Internalname = "vCCOD_AREA";
         divCod_areafiltercontainer_Internalname = "COD_AREAFILTERCONTAINER";
         lblLblcostohevalorfilter_Internalname = "LBLCOSTOHEVALORFILTER";
         edtavCcostohevalor_Internalname = "vCCOSTOHEVALOR";
         divCostohevalorfiltercontainer_Internalname = "COSTOHEVALORFILTERCONTAINER";
         lblLblcostohetothorasfilter_Internalname = "LBLCOSTOHETOTHORASFILTER";
         edtavCcostohetothoras_Internalname = "vCCOSTOHETOTHORAS";
         divCostohetothorasfiltercontainer_Internalname = "COSTOHETOTHORASFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtCOSTOHEFecha_Internalname = "COSTOHEFECHA";
         edtCOSTOHEMes_Internalname = "COSTOHEMES";
         edtCOSTOHEAno_Internalname = "COSTOHEANO";
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO";
         edtCod_Area_Internalname = "COD_AREA";
         edtCOSTOHEValor_Internalname = "COSTOHEVALOR";
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
         edtCOSTOHEValor_Jsonclick = "";
         edtCOSTOHEValor_Link = "";
         edtCod_Area_Jsonclick = "";
         edtIndicadoresCodigo_Jsonclick = "";
         edtCOSTOHEAno_Jsonclick = "";
         edtCOSTOHEMes_Jsonclick = "";
         edtCOSTOHEFecha_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtavCcostohetothoras_Jsonclick = "";
         edtavCcostohetothoras_Enabled = 1;
         edtavCcostohetothoras_Visible = 1;
         edtavCcostohevalor_Jsonclick = "";
         edtavCcostohevalor_Enabled = 1;
         edtavCcostohevalor_Visible = 1;
         edtavCcod_area_Jsonclick = "";
         edtavCcod_area_Enabled = 1;
         edtavCcod_area_Visible = 1;
         edtavCindicadorescodigo_Jsonclick = "";
         edtavCindicadorescodigo_Enabled = 1;
         edtavCindicadorescodigo_Visible = 1;
         edtavCcostoheano_Jsonclick = "";
         edtavCcostoheano_Enabled = 1;
         edtavCcostoheano_Visible = 1;
         edtavCcostohemes_Jsonclick = "";
         edtavCcostohemes_Enabled = 1;
         edtavCcostohemes_Visible = 1;
         edtavCcostohefecha_Jsonclick = "";
         edtavCcostohefecha_Enabled = 1;
         divCostohetothorasfiltercontainer_Class = "AdvancedContainerItem";
         divCostohevalorfiltercontainer_Class = "AdvancedContainerItem";
         divCod_areafiltercontainer_Class = "AdvancedContainerItem";
         divIndicadorescodigofiltercontainer_Class = "AdvancedContainerItem";
         divCostoheanofiltercontainer_Class = "AdvancedContainerItem";
         divCostohemesfiltercontainer_Class = "AdvancedContainerItem";
         divCostohefechafiltercontainer_Class = "AdvancedContainerItem";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List COSTOHE";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCOSTOHEFecha',fld:'vCCOSTOHEFECHA',pic:''},{av:'AV7cCOSTOHEMes',fld:'vCCOSTOHEMES',pic:'ZZZ9'},{av:'AV8cCOSTOHEAno',fld:'vCCOSTOHEANO',pic:'ZZZ9'},{av:'AV9cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV10cCod_Area',fld:'vCCOD_AREA',pic:''},{av:'AV11cCOSTOHEValor',fld:'vCCOSTOHEVALOR',pic:'ZZZZZZZZ9.99'},{av:'AV12cCOSTOHETotHoras',fld:'vCCOSTOHETOTHORAS',pic:'ZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E180B1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLCOSTOHEFECHAFILTER.CLICK","{handler:'E110B1',iparms:[{av:'divCostohefechafiltercontainer_Class',ctrl:'COSTOHEFECHAFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCOSTOHEFECHAFILTER.CLICK",",oparms:[{av:'divCostohefechafiltercontainer_Class',ctrl:'COSTOHEFECHAFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLCOSTOHEMESFILTER.CLICK","{handler:'E120B1',iparms:[{av:'divCostohemesfiltercontainer_Class',ctrl:'COSTOHEMESFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCOSTOHEMESFILTER.CLICK",",oparms:[{av:'divCostohemesfiltercontainer_Class',ctrl:'COSTOHEMESFILTERCONTAINER',prop:'Class'},{av:'edtavCcostohemes_Visible',ctrl:'vCCOSTOHEMES',prop:'Visible'}]}");
         setEventMetadata("LBLCOSTOHEANOFILTER.CLICK","{handler:'E130B1',iparms:[{av:'divCostoheanofiltercontainer_Class',ctrl:'COSTOHEANOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCOSTOHEANOFILTER.CLICK",",oparms:[{av:'divCostoheanofiltercontainer_Class',ctrl:'COSTOHEANOFILTERCONTAINER',prop:'Class'},{av:'edtavCcostoheano_Visible',ctrl:'vCCOSTOHEANO',prop:'Visible'}]}");
         setEventMetadata("LBLINDICADORESCODIGOFILTER.CLICK","{handler:'E140B1',iparms:[{av:'divIndicadorescodigofiltercontainer_Class',ctrl:'INDICADORESCODIGOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLINDICADORESCODIGOFILTER.CLICK",",oparms:[{av:'divIndicadorescodigofiltercontainer_Class',ctrl:'INDICADORESCODIGOFILTERCONTAINER',prop:'Class'},{av:'edtavCindicadorescodigo_Visible',ctrl:'vCINDICADORESCODIGO',prop:'Visible'}]}");
         setEventMetadata("LBLCOD_AREAFILTER.CLICK","{handler:'E150B1',iparms:[{av:'divCod_areafiltercontainer_Class',ctrl:'COD_AREAFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCOD_AREAFILTER.CLICK",",oparms:[{av:'divCod_areafiltercontainer_Class',ctrl:'COD_AREAFILTERCONTAINER',prop:'Class'},{av:'edtavCcod_area_Visible',ctrl:'vCCOD_AREA',prop:'Visible'}]}");
         setEventMetadata("LBLCOSTOHEVALORFILTER.CLICK","{handler:'E160B1',iparms:[{av:'divCostohevalorfiltercontainer_Class',ctrl:'COSTOHEVALORFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCOSTOHEVALORFILTER.CLICK",",oparms:[{av:'divCostohevalorfiltercontainer_Class',ctrl:'COSTOHEVALORFILTERCONTAINER',prop:'Class'},{av:'edtavCcostohevalor_Visible',ctrl:'vCCOSTOHEVALOR',prop:'Visible'}]}");
         setEventMetadata("LBLCOSTOHETOTHORASFILTER.CLICK","{handler:'E170B1',iparms:[{av:'divCostohetothorasfiltercontainer_Class',ctrl:'COSTOHETOTHORASFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCOSTOHETOTHORASFILTER.CLICK",",oparms:[{av:'divCostohetothorasfiltercontainer_Class',ctrl:'COSTOHETOTHORASFILTERCONTAINER',prop:'Class'},{av:'edtavCcostohetothoras_Visible',ctrl:'vCCOSTOHETOTHORAS',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E210B2',iparms:[{av:'A21COSTOHEFecha',fld:'COSTOHEFECHA',pic:'',hsh:true},{av:'A22COSTOHEMes',fld:'COSTOHEMES',pic:'ZZZ9',hsh:true},{av:'A23COSTOHEAno',fld:'COSTOHEANO',pic:'ZZZ9',hsh:true},{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:'',hsh:true},{av:'A5Cod_Area',fld:'COD_AREA',pic:'',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pCOSTOHEFecha',fld:'vPCOSTOHEFECHA',pic:''},{av:'AV14pCOSTOHEMes',fld:'vPCOSTOHEMES',pic:'ZZZ9'},{av:'AV15pCOSTOHEAno',fld:'vPCOSTOHEANO',pic:'ZZZ9'},{av:'AV16pIndicadoresCodigo',fld:'vPINDICADORESCODIGO',pic:''},{av:'AV17pCod_Area',fld:'vPCOD_AREA',pic:''}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCOSTOHEFecha',fld:'vCCOSTOHEFECHA',pic:''},{av:'AV7cCOSTOHEMes',fld:'vCCOSTOHEMES',pic:'ZZZ9'},{av:'AV8cCOSTOHEAno',fld:'vCCOSTOHEANO',pic:'ZZZ9'},{av:'AV9cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV10cCod_Area',fld:'vCCOD_AREA',pic:''},{av:'AV11cCOSTOHEValor',fld:'vCCOSTOHEVALOR',pic:'ZZZZZZZZ9.99'},{av:'AV12cCOSTOHETotHoras',fld:'vCCOSTOHETOTHORAS',pic:'ZZZZZ9'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCOSTOHEFecha',fld:'vCCOSTOHEFECHA',pic:''},{av:'AV7cCOSTOHEMes',fld:'vCCOSTOHEMES',pic:'ZZZ9'},{av:'AV8cCOSTOHEAno',fld:'vCCOSTOHEANO',pic:'ZZZ9'},{av:'AV9cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV10cCod_Area',fld:'vCCOD_AREA',pic:''},{av:'AV11cCOSTOHEValor',fld:'vCCOSTOHEVALOR',pic:'ZZZZZZZZ9.99'},{av:'AV12cCOSTOHETotHoras',fld:'vCCOSTOHETOTHORAS',pic:'ZZZZZ9'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCOSTOHEFecha',fld:'vCCOSTOHEFECHA',pic:''},{av:'AV7cCOSTOHEMes',fld:'vCCOSTOHEMES',pic:'ZZZ9'},{av:'AV8cCOSTOHEAno',fld:'vCCOSTOHEANO',pic:'ZZZ9'},{av:'AV9cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV10cCod_Area',fld:'vCCOD_AREA',pic:''},{av:'AV11cCOSTOHEValor',fld:'vCCOSTOHEVALOR',pic:'ZZZZZZZZ9.99'},{av:'AV12cCOSTOHETotHoras',fld:'vCCOSTOHETOTHORAS',pic:'ZZZZZ9'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCOSTOHEFecha',fld:'vCCOSTOHEFECHA',pic:''},{av:'AV7cCOSTOHEMes',fld:'vCCOSTOHEMES',pic:'ZZZ9'},{av:'AV8cCOSTOHEAno',fld:'vCCOSTOHEANO',pic:'ZZZ9'},{av:'AV9cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV10cCod_Area',fld:'vCCOD_AREA',pic:''},{av:'AV11cCOSTOHEValor',fld:'vCCOSTOHEVALOR',pic:'ZZZZZZZZ9.99'},{av:'AV12cCOSTOHETotHoras',fld:'vCCOSTOHETOTHORAS',pic:'ZZZZZ9'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CCOSTOHEFECHA","{handler:'Validv_Ccostohefecha',iparms:[]");
         setEventMetadata("VALIDV_CCOSTOHEFECHA",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Costohevalor',iparms:[]");
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
         AV13pCOSTOHEFecha = DateTime.MinValue;
         AV16pIndicadoresCodigo = "";
         AV17pCod_Area = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV6cCOSTOHEFecha = DateTime.MinValue;
         AV9cIndicadoresCodigo = "";
         AV10cCod_Area = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblcostohefechafilter_Jsonclick = "";
         TempTags = "";
         lblLblcostohemesfilter_Jsonclick = "";
         lblLblcostoheanofilter_Jsonclick = "";
         lblLblindicadorescodigofilter_Jsonclick = "";
         lblLblcod_areafilter_Jsonclick = "";
         lblLblcostohevalorfilter_Jsonclick = "";
         lblLblcostohetothorasfilter_Jsonclick = "";
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
         A21COSTOHEFecha = DateTime.MinValue;
         A4IndicadoresCodigo = "";
         A5Cod_Area = "";
         scmdbuf = "";
         lV9cIndicadoresCodigo = "";
         lV10cCod_Area = "";
         H000B2_A237COSTOHETotHoras = new int[1] ;
         H000B2_A131COSTOHEValor = new decimal[1] ;
         H000B2_A5Cod_Area = new string[] {""} ;
         H000B2_A4IndicadoresCodigo = new string[] {""} ;
         H000B2_A23COSTOHEAno = new short[1] ;
         H000B2_A22COSTOHEMes = new short[1] ;
         H000B2_A21COSTOHEFecha = new DateTime[] {DateTime.MinValue} ;
         H000B3_AGRID1_nRecordCount = new long[1] ;
         AV18ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0090__default(),
            new Object[][] {
                new Object[] {
               H000B2_A237COSTOHETotHoras, H000B2_A131COSTOHEValor, H000B2_A5Cod_Area, H000B2_A4IndicadoresCodigo, H000B2_A23COSTOHEAno, H000B2_A22COSTOHEMes, H000B2_A21COSTOHEFecha
               }
               , new Object[] {
               H000B3_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV14pCOSTOHEMes ;
      private short AV15pCOSTOHEAno ;
      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV7cCOSTOHEMes ;
      private short AV8cCOSTOHEAno ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A22COSTOHEMes ;
      private short A23COSTOHEAno ;
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
      private int AV12cCOSTOHETotHoras ;
      private int edtavCcostohefecha_Enabled ;
      private int edtavCcostohemes_Enabled ;
      private int edtavCcostohemes_Visible ;
      private int edtavCcostoheano_Enabled ;
      private int edtavCcostoheano_Visible ;
      private int edtavCindicadorescodigo_Visible ;
      private int edtavCindicadorescodigo_Enabled ;
      private int edtavCcod_area_Visible ;
      private int edtavCcod_area_Enabled ;
      private int edtavCcostohevalor_Enabled ;
      private int edtavCcostohevalor_Visible ;
      private int edtavCcostohetothoras_Enabled ;
      private int edtavCcostohetothoras_Visible ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A237COSTOHETotHoras ;
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
      private decimal AV11cCOSTOHEValor ;
      private decimal A131COSTOHEValor ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divCostohefechafiltercontainer_Class ;
      private string divCostohemesfiltercontainer_Class ;
      private string divCostoheanofiltercontainer_Class ;
      private string divIndicadorescodigofiltercontainer_Class ;
      private string divCod_areafiltercontainer_Class ;
      private string divCostohevalorfiltercontainer_Class ;
      private string divCostohetothorasfiltercontainer_Class ;
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
      private string divCostohefechafiltercontainer_Internalname ;
      private string lblLblcostohefechafilter_Internalname ;
      private string lblLblcostohefechafilter_Jsonclick ;
      private string edtavCcostohefecha_Internalname ;
      private string TempTags ;
      private string edtavCcostohefecha_Jsonclick ;
      private string divCostohemesfiltercontainer_Internalname ;
      private string lblLblcostohemesfilter_Internalname ;
      private string lblLblcostohemesfilter_Jsonclick ;
      private string edtavCcostohemes_Internalname ;
      private string edtavCcostohemes_Jsonclick ;
      private string divCostoheanofiltercontainer_Internalname ;
      private string lblLblcostoheanofilter_Internalname ;
      private string lblLblcostoheanofilter_Jsonclick ;
      private string edtavCcostoheano_Internalname ;
      private string edtavCcostoheano_Jsonclick ;
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
      private string divCostohevalorfiltercontainer_Internalname ;
      private string lblLblcostohevalorfilter_Internalname ;
      private string lblLblcostohevalorfilter_Jsonclick ;
      private string edtavCcostohevalor_Internalname ;
      private string edtavCcostohevalor_Jsonclick ;
      private string divCostohetothorasfiltercontainer_Internalname ;
      private string lblLblcostohetothorasfilter_Internalname ;
      private string lblLblcostohetothorasfilter_Jsonclick ;
      private string edtavCcostohetothoras_Internalname ;
      private string edtavCcostohetothoras_Jsonclick ;
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
      private string edtCOSTOHEFecha_Internalname ;
      private string edtCOSTOHEMes_Internalname ;
      private string edtCOSTOHEAno_Internalname ;
      private string edtIndicadoresCodigo_Internalname ;
      private string edtCod_Area_Internalname ;
      private string edtCOSTOHEValor_Internalname ;
      private string scmdbuf ;
      private string AV18ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtCOSTOHEFecha_Jsonclick ;
      private string edtCOSTOHEMes_Jsonclick ;
      private string edtCOSTOHEAno_Jsonclick ;
      private string edtIndicadoresCodigo_Jsonclick ;
      private string edtCod_Area_Jsonclick ;
      private string edtCOSTOHEValor_Link ;
      private string edtCOSTOHEValor_Jsonclick ;
      private string subGrid1_Header ;
      private DateTime AV13pCOSTOHEFecha ;
      private DateTime AV6cCOSTOHEFecha ;
      private DateTime A21COSTOHEFecha ;
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
      private string AV9cIndicadoresCodigo ;
      private string AV10cCod_Area ;
      private string AV21Linkselection_GXI ;
      private string A4IndicadoresCodigo ;
      private string A5Cod_Area ;
      private string lV9cIndicadoresCodigo ;
      private string lV10cCod_Area ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] H000B2_A237COSTOHETotHoras ;
      private decimal[] H000B2_A131COSTOHEValor ;
      private string[] H000B2_A5Cod_Area ;
      private string[] H000B2_A4IndicadoresCodigo ;
      private short[] H000B2_A23COSTOHEAno ;
      private short[] H000B2_A22COSTOHEMes ;
      private DateTime[] H000B2_A21COSTOHEFecha ;
      private long[] H000B3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private DateTime aP0_pCOSTOHEFecha ;
      private short aP1_pCOSTOHEMes ;
      private short aP2_pCOSTOHEAno ;
      private string aP3_pIndicadoresCodigo ;
      private string aP4_pCod_Area ;
      private GXWebForm Form ;
   }

   public class gx0090__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H000B2( IGxContext context ,
                                             decimal AV11cCOSTOHEValor ,
                                             int AV12cCOSTOHETotHoras ,
                                             decimal A131COSTOHEValor ,
                                             int A237COSTOHETotHoras ,
                                             string A4IndicadoresCodigo ,
                                             string AV9cIndicadoresCodigo ,
                                             string A5Cod_Area ,
                                             string AV10cCod_Area ,
                                             DateTime AV6cCOSTOHEFecha ,
                                             short AV7cCOSTOHEMes ,
                                             short AV8cCOSTOHEAno )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [COSTOHETotHoras], [COSTOHEValor], [Cod_Area], [IndicadoresCodigo], [COSTOHEAno], [COSTOHEMes], [COSTOHEFecha]";
         sFromString = " FROM [COSTOHE]";
         sOrderString = "";
         AddWhere(sWhereString, "([COSTOHEFecha] >= @AV6cCOSTOHEFecha and [COSTOHEMes] >= @AV7cCOSTOHEMes and [COSTOHEAno] >= @AV8cCOSTOHEAno)");
         AddWhere(sWhereString, "([IndicadoresCodigo] like @lV9cIndicadoresCodigo)");
         AddWhere(sWhereString, "([Cod_Area] like @lV10cCod_Area)");
         if ( ! (Convert.ToDecimal(0)==AV11cCOSTOHEValor) )
         {
            AddWhere(sWhereString, "([COSTOHEValor] >= @AV11cCOSTOHEValor)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV12cCOSTOHETotHoras) )
         {
            AddWhere(sWhereString, "([COSTOHETotHoras] >= @AV12cCOSTOHETotHoras)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [COSTOHEFecha], [COSTOHEMes], [COSTOHEAno], [IndicadoresCodigo], [Cod_Area]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H000B3( IGxContext context ,
                                             decimal AV11cCOSTOHEValor ,
                                             int AV12cCOSTOHETotHoras ,
                                             decimal A131COSTOHEValor ,
                                             int A237COSTOHETotHoras ,
                                             string A4IndicadoresCodigo ,
                                             string AV9cIndicadoresCodigo ,
                                             string A5Cod_Area ,
                                             string AV10cCod_Area ,
                                             DateTime AV6cCOSTOHEFecha ,
                                             short AV7cCOSTOHEMes ,
                                             short AV8cCOSTOHEAno )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [COSTOHE]";
         AddWhere(sWhereString, "([COSTOHEFecha] >= @AV6cCOSTOHEFecha and [COSTOHEMes] >= @AV7cCOSTOHEMes and [COSTOHEAno] >= @AV8cCOSTOHEAno)");
         AddWhere(sWhereString, "([IndicadoresCodigo] like @lV9cIndicadoresCodigo)");
         AddWhere(sWhereString, "([Cod_Area] like @lV10cCod_Area)");
         if ( ! (Convert.ToDecimal(0)==AV11cCOSTOHEValor) )
         {
            AddWhere(sWhereString, "([COSTOHEValor] >= @AV11cCOSTOHEValor)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV12cCOSTOHETotHoras) )
         {
            AddWhere(sWhereString, "([COSTOHETotHoras] >= @AV12cCOSTOHETotHoras)");
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
                     return conditional_H000B2(context, (decimal)dynConstraints[0] , (int)dynConstraints[1] , (decimal)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (DateTime)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] );
               case 1 :
                     return conditional_H000B3(context, (decimal)dynConstraints[0] , (int)dynConstraints[1] , (decimal)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (DateTime)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] );
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
          Object[] prmH000B2;
          prmH000B2 = new Object[] {
          new ParDef("@AV6cCOSTOHEFecha",GXType.Date,8,0) ,
          new ParDef("@AV7cCOSTOHEMes",GXType.Int16,4,0) ,
          new ParDef("@AV8cCOSTOHEAno",GXType.Int16,4,0) ,
          new ParDef("@lV9cIndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@lV10cCod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@AV11cCOSTOHEValor",GXType.Decimal,12,2) ,
          new ParDef("@AV12cCOSTOHETotHoras",GXType.Int32,6,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH000B3;
          prmH000B3 = new Object[] {
          new ParDef("@AV6cCOSTOHEFecha",GXType.Date,8,0) ,
          new ParDef("@AV7cCOSTOHEMes",GXType.Int16,4,0) ,
          new ParDef("@AV8cCOSTOHEAno",GXType.Int16,4,0) ,
          new ParDef("@lV9cIndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@lV10cCod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@AV11cCOSTOHEValor",GXType.Decimal,12,2) ,
          new ParDef("@AV12cCOSTOHETotHoras",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000B2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000B2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H000B3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000B3,1, GxCacheFrequency.OFF ,false,false )
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
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
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
