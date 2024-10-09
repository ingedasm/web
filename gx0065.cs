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
   public class gx0065 : GXDataArea
   {
      public gx0065( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("IndicadroresPalmas", true);
      }

      public gx0065( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( DateTime aP0_pAusen_Fecha ,
                           short aP1_pAusen_Mes ,
                           short aP2_pAusen_Ano ,
                           string aP3_pIndicadoresCodigo ,
                           string aP4_pCod_Area ,
                           out DateTime aP5_pAusenArea_Fecha ,
                           out string aP6_pTipoAusen_Codigo )
      {
         this.AV8pAusen_Fecha = aP0_pAusen_Fecha;
         this.AV9pAusen_Mes = aP1_pAusen_Mes;
         this.AV10pAusen_Ano = aP2_pAusen_Ano;
         this.AV11pIndicadoresCodigo = aP3_pIndicadoresCodigo;
         this.AV12pCod_Area = aP4_pCod_Area;
         this.AV13pAusenArea_Fecha = DateTime.MinValue ;
         this.AV14pTipoAusen_Codigo = "" ;
         executePrivate();
         aP5_pAusenArea_Fecha=this.AV13pAusenArea_Fecha;
         aP6_pTipoAusen_Codigo=this.AV14pTipoAusen_Codigo;
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
            gxfirstwebparm = GetFirstPar( "pAusen_Fecha");
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
               gxfirstwebparm = GetFirstPar( "pAusen_Fecha");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pAusen_Fecha");
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
               AV8pAusen_Fecha = context.localUtil.ParseDateParm( gxfirstwebparm);
               AssignAttri("", false, "AV8pAusen_Fecha", context.localUtil.Format(AV8pAusen_Fecha, "99/99/99"));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV9pAusen_Mes = (short)(Math.Round(NumberUtil.Val( GetPar( "pAusen_Mes"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV9pAusen_Mes", StringUtil.LTrimStr( (decimal)(AV9pAusen_Mes), 4, 0));
                  AV10pAusen_Ano = (short)(Math.Round(NumberUtil.Val( GetPar( "pAusen_Ano"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV10pAusen_Ano", StringUtil.LTrimStr( (decimal)(AV10pAusen_Ano), 4, 0));
                  AV11pIndicadoresCodigo = GetPar( "pIndicadoresCodigo");
                  AssignAttri("", false, "AV11pIndicadoresCodigo", AV11pIndicadoresCodigo);
                  AV12pCod_Area = GetPar( "pCod_Area");
                  AssignAttri("", false, "AV12pCod_Area", AV12pCod_Area);
                  AV13pAusenArea_Fecha = context.localUtil.ParseDateParm( GetPar( "pAusenArea_Fecha"));
                  AssignAttri("", false, "AV13pAusenArea_Fecha", context.localUtil.Format(AV13pAusenArea_Fecha, "99/99/99"));
                  AV14pTipoAusen_Codigo = GetPar( "pTipoAusen_Codigo");
                  AssignAttri("", false, "AV14pTipoAusen_Codigo", AV14pTipoAusen_Codigo);
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
         nRC_GXsfl_34 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_34"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_34_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_34_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_34_idx = GetPar( "sGXsfl_34_idx");
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
         AV6cAusenArea_Fecha = context.localUtil.ParseDateParm( GetPar( "cAusenArea_Fecha"));
         AV7cTipoAusen_Codigo = GetPar( "cTipoAusen_Codigo");
         AV8pAusen_Fecha = context.localUtil.ParseDateParm( GetPar( "pAusen_Fecha"));
         AV9pAusen_Mes = (short)(Math.Round(NumberUtil.Val( GetPar( "pAusen_Mes"), "."), 18, MidpointRounding.ToEven));
         AV10pAusen_Ano = (short)(Math.Round(NumberUtil.Val( GetPar( "pAusen_Ano"), "."), 18, MidpointRounding.ToEven));
         AV11pIndicadoresCodigo = GetPar( "pIndicadoresCodigo");
         AV12pCod_Area = GetPar( "pCod_Area");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cAusenArea_Fecha, AV7cTipoAusen_Codigo, AV8pAusen_Fecha, AV9pAusen_Mes, AV10pAusen_Ano, AV11pIndicadoresCodigo, AV12pCod_Area) ;
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
         PA072( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START072( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0065.aspx", new object[] {UrlEncode(DateTimeUtil.FormatDateParm(AV8pAusen_Fecha)),UrlEncode(StringUtil.LTrimStr(AV9pAusen_Mes,4,0)),UrlEncode(StringUtil.LTrimStr(AV10pAusen_Ano,4,0)),UrlEncode(StringUtil.RTrim(AV11pIndicadoresCodigo)),UrlEncode(StringUtil.RTrim(AV12pCod_Area)),UrlEncode(DateTimeUtil.FormatDateParm(AV13pAusenArea_Fecha)),UrlEncode(StringUtil.RTrim(AV14pTipoAusen_Codigo))}, new string[] {"pAusen_Fecha","pAusen_Mes","pAusen_Ano","pIndicadoresCodigo","pCod_Area","pAusenArea_Fecha","pTipoAusen_Codigo"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCAUSENAREA_FECHA", context.localUtil.Format(AV6cAusenArea_Fecha, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vCTIPOAUSEN_CODIGO", AV7cTipoAusen_Codigo);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_34", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_34), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPAUSEN_FECHA", context.localUtil.DToC( AV8pAusen_Fecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vPAUSEN_MES", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9pAusen_Mes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPAUSEN_ANO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10pAusen_Ano), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPINDICADORESCODIGO", AV11pIndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "vPCOD_AREA", AV12pCod_Area);
         GxWebStd.gx_hidden_field( context, "vPAUSENAREA_FECHA", context.localUtil.DToC( AV13pAusenArea_Fecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vPTIPOAUSEN_CODIGO", AV14pTipoAusen_Codigo);
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "AUSENAREA_FECHAFILTERCONTAINER_Class", StringUtil.RTrim( divAusenarea_fechafiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TIPOAUSEN_CODIGOFILTERCONTAINER_Class", StringUtil.RTrim( divTipoausen_codigofiltercontainer_Class));
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
            WE072( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT072( ) ;
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
         return formatLink("gx0065.aspx", new object[] {UrlEncode(DateTimeUtil.FormatDateParm(AV8pAusen_Fecha)),UrlEncode(StringUtil.LTrimStr(AV9pAusen_Mes,4,0)),UrlEncode(StringUtil.LTrimStr(AV10pAusen_Ano,4,0)),UrlEncode(StringUtil.RTrim(AV11pIndicadoresCodigo)),UrlEncode(StringUtil.RTrim(AV12pCod_Area)),UrlEncode(DateTimeUtil.FormatDateParm(AV13pAusenArea_Fecha)),UrlEncode(StringUtil.RTrim(AV14pTipoAusen_Codigo))}, new string[] {"pAusen_Fecha","pAusen_Mes","pAusen_Ano","pIndicadoresCodigo","pCod_Area","pAusenArea_Fecha","pTipoAusen_Codigo"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx0065" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List Area" ;
      }

      protected void WB070( )
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
            GxWebStd.gx_div_start( context, divAusenarea_fechafiltercontainer_Internalname, 1, 0, "px", 0, "px", divAusenarea_fechafiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblausenarea_fechafilter_Internalname, "Ausen Area_Fecha", "", "", lblLblausenarea_fechafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11071_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0065.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCausenarea_fecha_Internalname, "Ausen Area_Fecha", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_34_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCausenarea_fecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCausenarea_fecha_Internalname, context.localUtil.Format(AV6cAusenArea_Fecha, "99/99/99"), context.localUtil.Format( AV6cAusenArea_Fecha, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCausenarea_fecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCausenarea_fecha_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx0065.htm");
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
            GxWebStd.gx_div_start( context, divTipoausen_codigofiltercontainer_Internalname, 1, 0, "px", 0, "px", divTipoausen_codigofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltipoausen_codigofilter_Internalname, "Tipo Ausen_Codigo", "", "", lblLbltipoausen_codigofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12071_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0065.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtipoausen_codigo_Internalname, "Tipo Ausen_Codigo", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_34_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtipoausen_codigo_Internalname, AV7cTipoAusen_Codigo, StringUtil.RTrim( context.localUtil.Format( AV7cTipoAusen_Codigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtipoausen_codigo_Jsonclick, 0, "Attribute", "", "", "", "", edtavCtipoausen_codigo_Visible, edtavCtipoausen_codigo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Gx0065.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(34), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e13071_client"+"'", TempTags, "", 2, "HLP_Gx0065.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl34( ) ;
         }
         if ( wbEnd == 34 )
         {
            wbEnd = 0;
            nRC_GXsfl_34 = (int)(nGXsfl_34_idx-1);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(34), 2, 0)+","+"null"+");", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0065.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 34 )
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

      protected void START072( )
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
            Form.Meta.addItem("description", "Selection List Area", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP070( ) ;
      }

      protected void WS072( )
      {
         START072( ) ;
         EVT072( ) ;
      }

      protected void EVT072( )
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
                              nGXsfl_34_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx), 4, 0), 4, "0");
                              SubsflControlProps_342( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV18Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_34_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A10AusenArea_Fecha = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtAusenArea_Fecha_Internalname), 0));
                              A11TipoAusen_Codigo = cgiGet( edtTipoAusen_Codigo_Internalname);
                              A12AusenAreaValor = context.localUtil.CToN( cgiGet( edtAusenAreaValor_Internalname), ",", ".");
                              A14AusentismosAreaReg = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtAusentismosAreaReg_Internalname), 0));
                              A1Ausen_Fecha = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtAusen_Fecha_Internalname), 0));
                              A2Ausen_Mes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtAusen_Mes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A3Ausen_Ano = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtAusen_Ano_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A4IndicadoresCodigo = cgiGet( edtIndicadoresCodigo_Internalname);
                              A5Cod_Area = cgiGet( edtCod_Area_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E14072 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E15072 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Causenarea_fecha Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCAUSENAREA_FECHA"), 0) != AV6cAusenArea_Fecha )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ctipoausen_codigo Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCTIPOAUSEN_CODIGO"), AV7cTipoAusen_Codigo) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E16072 ();
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

      protected void WE072( )
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

      protected void PA072( )
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
         SubsflControlProps_342( ) ;
         while ( nGXsfl_34_idx <= nRC_GXsfl_34 )
         {
            sendrow_342( ) ;
            nGXsfl_34_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_34_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_34_idx+1);
            sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx), 4, 0), 4, "0");
            SubsflControlProps_342( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        DateTime AV6cAusenArea_Fecha ,
                                        string AV7cTipoAusen_Codigo ,
                                        DateTime AV8pAusen_Fecha ,
                                        short AV9pAusen_Mes ,
                                        short AV10pAusen_Ano ,
                                        string AV11pIndicadoresCodigo ,
                                        string AV12pCod_Area )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF072( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_AUSENAREA_FECHA", GetSecureSignedToken( "", A10AusenArea_Fecha, context));
         GxWebStd.gx_hidden_field( context, "AUSENAREA_FECHA", context.localUtil.Format(A10AusenArea_Fecha, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "gxhash_TIPOAUSEN_CODIGO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A11TipoAusen_Codigo, "")), context));
         GxWebStd.gx_hidden_field( context, "TIPOAUSEN_CODIGO", A11TipoAusen_Codigo);
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
         RF072( ) ;
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

      protected void RF072( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 34;
         nGXsfl_34_idx = 1;
         sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx), 4, 0), 4, "0");
         SubsflControlProps_342( ) ;
         bGXsfl_34_Refreshing = true;
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
            SubsflControlProps_342( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            lV7cTipoAusen_Codigo = StringUtil.Concat( StringUtil.RTrim( AV7cTipoAusen_Codigo), "%", "");
            /* Using cursor H00072 */
            pr_default.execute(0, new Object[] {AV8pAusen_Fecha, AV9pAusen_Mes, AV10pAusen_Ano, AV11pIndicadoresCodigo, AV12pCod_Area, AV6cAusenArea_Fecha, lV7cTipoAusen_Codigo, GXPagingFrom2, GXPagingTo2});
            nGXsfl_34_idx = 1;
            sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx), 4, 0), 4, "0");
            SubsflControlProps_342( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A5Cod_Area = H00072_A5Cod_Area[0];
               A4IndicadoresCodigo = H00072_A4IndicadoresCodigo[0];
               A3Ausen_Ano = H00072_A3Ausen_Ano[0];
               A2Ausen_Mes = H00072_A2Ausen_Mes[0];
               A1Ausen_Fecha = H00072_A1Ausen_Fecha[0];
               A14AusentismosAreaReg = H00072_A14AusentismosAreaReg[0];
               A12AusenAreaValor = H00072_A12AusenAreaValor[0];
               A11TipoAusen_Codigo = H00072_A11TipoAusen_Codigo[0];
               A10AusenArea_Fecha = H00072_A10AusenArea_Fecha[0];
               /* Execute user event: Load */
               E15072 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 34;
            WB070( ) ;
         }
         bGXsfl_34_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes072( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_AUSENAREA_FECHA"+"_"+sGXsfl_34_idx, GetSecureSignedToken( sGXsfl_34_idx, A10AusenArea_Fecha, context));
         GxWebStd.gx_hidden_field( context, "gxhash_TIPOAUSEN_CODIGO"+"_"+sGXsfl_34_idx, GetSecureSignedToken( sGXsfl_34_idx, StringUtil.RTrim( context.localUtil.Format( A11TipoAusen_Codigo, "")), context));
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
         lV7cTipoAusen_Codigo = StringUtil.Concat( StringUtil.RTrim( AV7cTipoAusen_Codigo), "%", "");
         /* Using cursor H00073 */
         pr_default.execute(1, new Object[] {AV8pAusen_Fecha, AV9pAusen_Mes, AV10pAusen_Ano, AV11pIndicadoresCodigo, AV12pCod_Area, AV6cAusenArea_Fecha, lV7cTipoAusen_Codigo});
         GRID1_nRecordCount = H00073_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cAusenArea_Fecha, AV7cTipoAusen_Codigo, AV8pAusen_Fecha, AV9pAusen_Mes, AV10pAusen_Ano, AV11pIndicadoresCodigo, AV12pCod_Area) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cAusenArea_Fecha, AV7cTipoAusen_Codigo, AV8pAusen_Fecha, AV9pAusen_Mes, AV10pAusen_Ano, AV11pIndicadoresCodigo, AV12pCod_Area) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cAusenArea_Fecha, AV7cTipoAusen_Codigo, AV8pAusen_Fecha, AV9pAusen_Mes, AV10pAusen_Ano, AV11pIndicadoresCodigo, AV12pCod_Area) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cAusenArea_Fecha, AV7cTipoAusen_Codigo, AV8pAusen_Fecha, AV9pAusen_Mes, AV10pAusen_Ano, AV11pIndicadoresCodigo, AV12pCod_Area) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cAusenArea_Fecha, AV7cTipoAusen_Codigo, AV8pAusen_Fecha, AV9pAusen_Mes, AV10pAusen_Ano, AV11pIndicadoresCodigo, AV12pCod_Area) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP070( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E14072 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_34 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_34"), ",", "."), 18, MidpointRounding.ToEven));
            GRID1_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ",", "."), 18, MidpointRounding.ToEven));
            GRID1_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ",", "."), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( context.localUtil.VCDate( cgiGet( edtavCausenarea_fecha_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Ausen Area_Fecha"}), 1, "vCAUSENAREA_FECHA");
               GX_FocusControl = edtavCausenarea_fecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cAusenArea_Fecha = DateTime.MinValue;
               AssignAttri("", false, "AV6cAusenArea_Fecha", context.localUtil.Format(AV6cAusenArea_Fecha, "99/99/99"));
            }
            else
            {
               AV6cAusenArea_Fecha = context.localUtil.CToD( cgiGet( edtavCausenarea_fecha_Internalname), 2);
               AssignAttri("", false, "AV6cAusenArea_Fecha", context.localUtil.Format(AV6cAusenArea_Fecha, "99/99/99"));
            }
            AV7cTipoAusen_Codigo = cgiGet( edtavCtipoausen_codigo_Internalname);
            AssignAttri("", false, "AV7cTipoAusen_Codigo", AV7cTipoAusen_Codigo);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vCAUSENAREA_FECHA"), 2) ) != DateTimeUtil.ResetTime ( AV6cAusenArea_Fecha ) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCTIPOAUSEN_CODIGO"), AV7cTipoAusen_Codigo) != 0 )
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
         E14072 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E14072( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Lista de Selección %1", "Area", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV15ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E15072( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "selectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV18Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )));
         sendrow_342( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_34_Refreshing )
         {
            DoAjaxLoad(34, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E16072 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E16072( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pAusenArea_Fecha = A10AusenArea_Fecha;
         AssignAttri("", false, "AV13pAusenArea_Fecha", context.localUtil.Format(AV13pAusenArea_Fecha, "99/99/99"));
         AV14pTipoAusen_Codigo = A11TipoAusen_Codigo;
         AssignAttri("", false, "AV14pTipoAusen_Codigo", AV14pTipoAusen_Codigo);
         context.setWebReturnParms(new Object[] {context.localUtil.Format( AV13pAusenArea_Fecha, "99/99/99"),(string)AV14pTipoAusen_Codigo});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pAusenArea_Fecha","AV14pTipoAusen_Codigo"});
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
         AV8pAusen_Fecha = (DateTime)getParm(obj,0);
         AssignAttri("", false, "AV8pAusen_Fecha", context.localUtil.Format(AV8pAusen_Fecha, "99/99/99"));
         AV9pAusen_Mes = Convert.ToInt16(getParm(obj,1));
         AssignAttri("", false, "AV9pAusen_Mes", StringUtil.LTrimStr( (decimal)(AV9pAusen_Mes), 4, 0));
         AV10pAusen_Ano = Convert.ToInt16(getParm(obj,2));
         AssignAttri("", false, "AV10pAusen_Ano", StringUtil.LTrimStr( (decimal)(AV10pAusen_Ano), 4, 0));
         AV11pIndicadoresCodigo = (string)getParm(obj,3);
         AssignAttri("", false, "AV11pIndicadoresCodigo", AV11pIndicadoresCodigo);
         AV12pCod_Area = (string)getParm(obj,4);
         AssignAttri("", false, "AV12pCod_Area", AV12pCod_Area);
         AV13pAusenArea_Fecha = (DateTime)getParm(obj,5);
         AssignAttri("", false, "AV13pAusenArea_Fecha", context.localUtil.Format(AV13pAusenArea_Fecha, "99/99/99"));
         AV14pTipoAusen_Codigo = (string)getParm(obj,6);
         AssignAttri("", false, "AV14pTipoAusen_Codigo", AV14pTipoAusen_Codigo);
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
         PA072( ) ;
         WS072( ) ;
         WE072( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024723101498", true, true);
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
         context.AddJavascriptSource("gx0065.js", "?20247231014910", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_342( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_34_idx;
         edtAusenArea_Fecha_Internalname = "AUSENAREA_FECHA_"+sGXsfl_34_idx;
         edtTipoAusen_Codigo_Internalname = "TIPOAUSEN_CODIGO_"+sGXsfl_34_idx;
         edtAusenAreaValor_Internalname = "AUSENAREAVALOR_"+sGXsfl_34_idx;
         edtAusentismosAreaReg_Internalname = "AUSENTISMOSAREAREG_"+sGXsfl_34_idx;
         edtAusen_Fecha_Internalname = "AUSEN_FECHA_"+sGXsfl_34_idx;
         edtAusen_Mes_Internalname = "AUSEN_MES_"+sGXsfl_34_idx;
         edtAusen_Ano_Internalname = "AUSEN_ANO_"+sGXsfl_34_idx;
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO_"+sGXsfl_34_idx;
         edtCod_Area_Internalname = "COD_AREA_"+sGXsfl_34_idx;
      }

      protected void SubsflControlProps_fel_342( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_34_fel_idx;
         edtAusenArea_Fecha_Internalname = "AUSENAREA_FECHA_"+sGXsfl_34_fel_idx;
         edtTipoAusen_Codigo_Internalname = "TIPOAUSEN_CODIGO_"+sGXsfl_34_fel_idx;
         edtAusenAreaValor_Internalname = "AUSENAREAVALOR_"+sGXsfl_34_fel_idx;
         edtAusentismosAreaReg_Internalname = "AUSENTISMOSAREAREG_"+sGXsfl_34_fel_idx;
         edtAusen_Fecha_Internalname = "AUSEN_FECHA_"+sGXsfl_34_fel_idx;
         edtAusen_Mes_Internalname = "AUSEN_MES_"+sGXsfl_34_fel_idx;
         edtAusen_Ano_Internalname = "AUSEN_ANO_"+sGXsfl_34_fel_idx;
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO_"+sGXsfl_34_fel_idx;
         edtCod_Area_Internalname = "COD_AREA_"+sGXsfl_34_fel_idx;
      }

      protected void sendrow_342( )
      {
         SubsflControlProps_342( ) ;
         WB070( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_34_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_34_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_34_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( context.localUtil.Format(A10AusenArea_Fecha, "99/99/99"))+"'"+", "+"'"+GXUtil.EncodeJSConstant( A11TipoAusen_Codigo)+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_34_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV18Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV18Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAusenArea_Fecha_Internalname,context.localUtil.Format(A10AusenArea_Fecha, "99/99/99"),context.localUtil.Format( A10AusenArea_Fecha, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAusenArea_Fecha_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)34,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipoAusen_Codigo_Internalname,(string)A11TipoAusen_Codigo,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTipoAusen_Codigo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)34,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtAusenAreaValor_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( context.localUtil.Format(A10AusenArea_Fecha, "99/99/99"))+"'"+", "+"'"+GXUtil.EncodeJSConstant( A11TipoAusen_Codigo)+"'"+"]);";
            AssignProp("", false, edtAusenAreaValor_Internalname, "Link", edtAusenAreaValor_Link, !bGXsfl_34_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAusenAreaValor_Internalname,StringUtil.LTrim( StringUtil.NToC( A12AusenAreaValor, 15, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A12AusenAreaValor, "ZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtAusenAreaValor_Link,(string)"",(string)"",(string)"",(string)edtAusenAreaValor_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)15,(short)0,(short)0,(short)34,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAusentismosAreaReg_Internalname,context.localUtil.Format(A14AusentismosAreaReg, "99/99/99"),context.localUtil.Format( A14AusentismosAreaReg, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAusentismosAreaReg_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)34,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAusen_Fecha_Internalname,context.localUtil.Format(A1Ausen_Fecha, "99/99/99"),context.localUtil.Format( A1Ausen_Fecha, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAusen_Fecha_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)34,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAusen_Mes_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A2Ausen_Mes), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A2Ausen_Mes), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAusen_Mes_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)34,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAusen_Ano_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A3Ausen_Ano), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A3Ausen_Ano), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAusen_Ano_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)34,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIndicadoresCodigo_Internalname,(string)A4IndicadoresCodigo,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIndicadoresCodigo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)34,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCod_Area_Internalname,(string)A5Cod_Area,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCod_Area_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)34,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            send_integrity_lvl_hashes072( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_34_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_34_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_34_idx+1);
            sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx), 4, 0), 4, "0");
            SubsflControlProps_342( ) ;
         }
         /* End function sendrow_342 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl34( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"34\">") ;
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
            context.SendWebValue( "Area_Fecha") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Tipo Ausen_Codigo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Area Valor") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Area Reg") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Ausen_Fecha") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Ausen_Mes") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Ausen_Ano") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Indicadores Codigo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Cod_Area") ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A10AusenArea_Fecha, "99/99/99")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A11TipoAusen_Codigo));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A12AusenAreaValor, 15, 2, ".", ""))));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtAusenAreaValor_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A14AusentismosAreaReg, "99/99/99")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A1Ausen_Fecha, "99/99/99")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A2Ausen_Mes), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A3Ausen_Ano), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A4IndicadoresCodigo));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A5Cod_Area));
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
         lblLblausenarea_fechafilter_Internalname = "LBLAUSENAREA_FECHAFILTER";
         edtavCausenarea_fecha_Internalname = "vCAUSENAREA_FECHA";
         divAusenarea_fechafiltercontainer_Internalname = "AUSENAREA_FECHAFILTERCONTAINER";
         lblLbltipoausen_codigofilter_Internalname = "LBLTIPOAUSEN_CODIGOFILTER";
         edtavCtipoausen_codigo_Internalname = "vCTIPOAUSEN_CODIGO";
         divTipoausen_codigofiltercontainer_Internalname = "TIPOAUSEN_CODIGOFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtAusenArea_Fecha_Internalname = "AUSENAREA_FECHA";
         edtTipoAusen_Codigo_Internalname = "TIPOAUSEN_CODIGO";
         edtAusenAreaValor_Internalname = "AUSENAREAVALOR";
         edtAusentismosAreaReg_Internalname = "AUSENTISMOSAREAREG";
         edtAusen_Fecha_Internalname = "AUSEN_FECHA";
         edtAusen_Mes_Internalname = "AUSEN_MES";
         edtAusen_Ano_Internalname = "AUSEN_ANO";
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO";
         edtCod_Area_Internalname = "COD_AREA";
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
         edtCod_Area_Jsonclick = "";
         edtIndicadoresCodigo_Jsonclick = "";
         edtAusen_Ano_Jsonclick = "";
         edtAusen_Mes_Jsonclick = "";
         edtAusen_Fecha_Jsonclick = "";
         edtAusentismosAreaReg_Jsonclick = "";
         edtAusenAreaValor_Jsonclick = "";
         edtAusenAreaValor_Link = "";
         edtTipoAusen_Codigo_Jsonclick = "";
         edtAusenArea_Fecha_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtavCtipoausen_codigo_Jsonclick = "";
         edtavCtipoausen_codigo_Enabled = 1;
         edtavCtipoausen_codigo_Visible = 1;
         edtavCausenarea_fecha_Jsonclick = "";
         edtavCausenarea_fecha_Enabled = 1;
         divTipoausen_codigofiltercontainer_Class = "AdvancedContainerItem";
         divAusenarea_fechafiltercontainer_Class = "AdvancedContainerItem";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List Area";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cAusenArea_Fecha',fld:'vCAUSENAREA_FECHA',pic:''},{av:'AV7cTipoAusen_Codigo',fld:'vCTIPOAUSEN_CODIGO',pic:''},{av:'AV8pAusen_Fecha',fld:'vPAUSEN_FECHA',pic:''},{av:'AV9pAusen_Mes',fld:'vPAUSEN_MES',pic:'ZZZ9'},{av:'AV10pAusen_Ano',fld:'vPAUSEN_ANO',pic:'ZZZ9'},{av:'AV11pIndicadoresCodigo',fld:'vPINDICADORESCODIGO',pic:''},{av:'AV12pCod_Area',fld:'vPCOD_AREA',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E13071',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLAUSENAREA_FECHAFILTER.CLICK","{handler:'E11071',iparms:[{av:'divAusenarea_fechafiltercontainer_Class',ctrl:'AUSENAREA_FECHAFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLAUSENAREA_FECHAFILTER.CLICK",",oparms:[{av:'divAusenarea_fechafiltercontainer_Class',ctrl:'AUSENAREA_FECHAFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLTIPOAUSEN_CODIGOFILTER.CLICK","{handler:'E12071',iparms:[{av:'divTipoausen_codigofiltercontainer_Class',ctrl:'TIPOAUSEN_CODIGOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTIPOAUSEN_CODIGOFILTER.CLICK",",oparms:[{av:'divTipoausen_codigofiltercontainer_Class',ctrl:'TIPOAUSEN_CODIGOFILTERCONTAINER',prop:'Class'},{av:'edtavCtipoausen_codigo_Visible',ctrl:'vCTIPOAUSEN_CODIGO',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E16072',iparms:[{av:'A10AusenArea_Fecha',fld:'AUSENAREA_FECHA',pic:'',hsh:true},{av:'A11TipoAusen_Codigo',fld:'TIPOAUSEN_CODIGO',pic:'',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pAusenArea_Fecha',fld:'vPAUSENAREA_FECHA',pic:''},{av:'AV14pTipoAusen_Codigo',fld:'vPTIPOAUSEN_CODIGO',pic:''}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cAusenArea_Fecha',fld:'vCAUSENAREA_FECHA',pic:''},{av:'AV7cTipoAusen_Codigo',fld:'vCTIPOAUSEN_CODIGO',pic:''},{av:'AV8pAusen_Fecha',fld:'vPAUSEN_FECHA',pic:''},{av:'AV9pAusen_Mes',fld:'vPAUSEN_MES',pic:'ZZZ9'},{av:'AV10pAusen_Ano',fld:'vPAUSEN_ANO',pic:'ZZZ9'},{av:'AV11pIndicadoresCodigo',fld:'vPINDICADORESCODIGO',pic:''},{av:'AV12pCod_Area',fld:'vPCOD_AREA',pic:''}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cAusenArea_Fecha',fld:'vCAUSENAREA_FECHA',pic:''},{av:'AV7cTipoAusen_Codigo',fld:'vCTIPOAUSEN_CODIGO',pic:''},{av:'AV8pAusen_Fecha',fld:'vPAUSEN_FECHA',pic:''},{av:'AV9pAusen_Mes',fld:'vPAUSEN_MES',pic:'ZZZ9'},{av:'AV10pAusen_Ano',fld:'vPAUSEN_ANO',pic:'ZZZ9'},{av:'AV11pIndicadoresCodigo',fld:'vPINDICADORESCODIGO',pic:''},{av:'AV12pCod_Area',fld:'vPCOD_AREA',pic:''}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cAusenArea_Fecha',fld:'vCAUSENAREA_FECHA',pic:''},{av:'AV7cTipoAusen_Codigo',fld:'vCTIPOAUSEN_CODIGO',pic:''},{av:'AV8pAusen_Fecha',fld:'vPAUSEN_FECHA',pic:''},{av:'AV9pAusen_Mes',fld:'vPAUSEN_MES',pic:'ZZZ9'},{av:'AV10pAusen_Ano',fld:'vPAUSEN_ANO',pic:'ZZZ9'},{av:'AV11pIndicadoresCodigo',fld:'vPINDICADORESCODIGO',pic:''},{av:'AV12pCod_Area',fld:'vPCOD_AREA',pic:''}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cAusenArea_Fecha',fld:'vCAUSENAREA_FECHA',pic:''},{av:'AV7cTipoAusen_Codigo',fld:'vCTIPOAUSEN_CODIGO',pic:''},{av:'AV8pAusen_Fecha',fld:'vPAUSEN_FECHA',pic:''},{av:'AV9pAusen_Mes',fld:'vPAUSEN_MES',pic:'ZZZ9'},{av:'AV10pAusen_Ano',fld:'vPAUSEN_ANO',pic:'ZZZ9'},{av:'AV11pIndicadoresCodigo',fld:'vPINDICADORESCODIGO',pic:''},{av:'AV12pCod_Area',fld:'vPCOD_AREA',pic:''}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CAUSENAREA_FECHA","{handler:'Validv_Causenarea_fecha',iparms:[]");
         setEventMetadata("VALIDV_CAUSENAREA_FECHA",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Cod_area',iparms:[]");
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
         AV13pAusenArea_Fecha = DateTime.MinValue;
         AV14pTipoAusen_Codigo = "";
         wcpOAV8pAusen_Fecha = DateTime.MinValue;
         wcpOAV11pIndicadoresCodigo = "";
         wcpOAV12pCod_Area = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV6cAusenArea_Fecha = DateTime.MinValue;
         AV7cTipoAusen_Codigo = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblausenarea_fechafilter_Jsonclick = "";
         TempTags = "";
         lblLbltipoausen_codigofilter_Jsonclick = "";
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
         AV18Linkselection_GXI = "";
         A10AusenArea_Fecha = DateTime.MinValue;
         A11TipoAusen_Codigo = "";
         A14AusentismosAreaReg = DateTime.MinValue;
         A1Ausen_Fecha = DateTime.MinValue;
         A4IndicadoresCodigo = "";
         A5Cod_Area = "";
         scmdbuf = "";
         lV7cTipoAusen_Codigo = "";
         H00072_A5Cod_Area = new string[] {""} ;
         H00072_A4IndicadoresCodigo = new string[] {""} ;
         H00072_A3Ausen_Ano = new short[1] ;
         H00072_A2Ausen_Mes = new short[1] ;
         H00072_A1Ausen_Fecha = new DateTime[] {DateTime.MinValue} ;
         H00072_A14AusentismosAreaReg = new DateTime[] {DateTime.MinValue} ;
         H00072_A12AusenAreaValor = new decimal[1] ;
         H00072_A11TipoAusen_Codigo = new string[] {""} ;
         H00072_A10AusenArea_Fecha = new DateTime[] {DateTime.MinValue} ;
         H00073_AGRID1_nRecordCount = new long[1] ;
         AV15ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0065__default(),
            new Object[][] {
                new Object[] {
               H00072_A5Cod_Area, H00072_A4IndicadoresCodigo, H00072_A3Ausen_Ano, H00072_A2Ausen_Mes, H00072_A1Ausen_Fecha, H00072_A14AusentismosAreaReg, H00072_A12AusenAreaValor, H00072_A11TipoAusen_Codigo, H00072_A10AusenArea_Fecha
               }
               , new Object[] {
               H00073_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV9pAusen_Mes ;
      private short AV10pAusen_Ano ;
      private short wcpOAV9pAusen_Mes ;
      private short wcpOAV10pAusen_Ano ;
      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A2Ausen_Mes ;
      private short A3Ausen_Ano ;
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
      private int nRC_GXsfl_34 ;
      private int subGrid1_Rows ;
      private int nGXsfl_34_idx=1 ;
      private int edtavCausenarea_fecha_Enabled ;
      private int edtavCtipoausen_codigo_Visible ;
      private int edtavCtipoausen_codigo_Enabled ;
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
      private decimal A12AusenAreaValor ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divAusenarea_fechafiltercontainer_Class ;
      private string divTipoausen_codigofiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_34_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divAusenarea_fechafiltercontainer_Internalname ;
      private string lblLblausenarea_fechafilter_Internalname ;
      private string lblLblausenarea_fechafilter_Jsonclick ;
      private string edtavCausenarea_fecha_Internalname ;
      private string TempTags ;
      private string edtavCausenarea_fecha_Jsonclick ;
      private string divTipoausen_codigofiltercontainer_Internalname ;
      private string lblLbltipoausen_codigofilter_Internalname ;
      private string lblLbltipoausen_codigofilter_Jsonclick ;
      private string edtavCtipoausen_codigo_Internalname ;
      private string edtavCtipoausen_codigo_Jsonclick ;
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
      private string edtAusenArea_Fecha_Internalname ;
      private string edtTipoAusen_Codigo_Internalname ;
      private string edtAusenAreaValor_Internalname ;
      private string edtAusentismosAreaReg_Internalname ;
      private string edtAusen_Fecha_Internalname ;
      private string edtAusen_Mes_Internalname ;
      private string edtAusen_Ano_Internalname ;
      private string edtIndicadoresCodigo_Internalname ;
      private string edtCod_Area_Internalname ;
      private string scmdbuf ;
      private string AV15ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_34_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtAusenArea_Fecha_Jsonclick ;
      private string edtTipoAusen_Codigo_Jsonclick ;
      private string edtAusenAreaValor_Link ;
      private string edtAusenAreaValor_Jsonclick ;
      private string edtAusentismosAreaReg_Jsonclick ;
      private string edtAusen_Fecha_Jsonclick ;
      private string edtAusen_Mes_Jsonclick ;
      private string edtAusen_Ano_Jsonclick ;
      private string edtIndicadoresCodigo_Jsonclick ;
      private string edtCod_Area_Jsonclick ;
      private string subGrid1_Header ;
      private DateTime AV8pAusen_Fecha ;
      private DateTime AV13pAusenArea_Fecha ;
      private DateTime wcpOAV8pAusen_Fecha ;
      private DateTime AV6cAusenArea_Fecha ;
      private DateTime A10AusenArea_Fecha ;
      private DateTime A14AusentismosAreaReg ;
      private DateTime A1Ausen_Fecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_34_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV11pIndicadoresCodigo ;
      private string AV12pCod_Area ;
      private string AV14pTipoAusen_Codigo ;
      private string wcpOAV11pIndicadoresCodigo ;
      private string wcpOAV12pCod_Area ;
      private string AV7cTipoAusen_Codigo ;
      private string AV18Linkselection_GXI ;
      private string A11TipoAusen_Codigo ;
      private string A4IndicadoresCodigo ;
      private string A5Cod_Area ;
      private string lV7cTipoAusen_Codigo ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] H00072_A5Cod_Area ;
      private string[] H00072_A4IndicadoresCodigo ;
      private short[] H00072_A3Ausen_Ano ;
      private short[] H00072_A2Ausen_Mes ;
      private DateTime[] H00072_A1Ausen_Fecha ;
      private DateTime[] H00072_A14AusentismosAreaReg ;
      private decimal[] H00072_A12AusenAreaValor ;
      private string[] H00072_A11TipoAusen_Codigo ;
      private DateTime[] H00072_A10AusenArea_Fecha ;
      private long[] H00073_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private DateTime aP5_pAusenArea_Fecha ;
      private string aP6_pTipoAusen_Codigo ;
      private GXWebForm Form ;
   }

   public class gx0065__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH00072;
          prmH00072 = new Object[] {
          new ParDef("@AV8pAusen_Fecha",GXType.Date,8,0) ,
          new ParDef("@AV9pAusen_Mes",GXType.Int16,4,0) ,
          new ParDef("@AV10pAusen_Ano",GXType.Int16,4,0) ,
          new ParDef("@AV11pIndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@AV12pCod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@AV6cAusenArea_Fecha",GXType.Date,8,0) ,
          new ParDef("@lV7cTipoAusen_Codigo",GXType.NVarChar,40,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00073;
          prmH00073 = new Object[] {
          new ParDef("@AV8pAusen_Fecha",GXType.Date,8,0) ,
          new ParDef("@AV9pAusen_Mes",GXType.Int16,4,0) ,
          new ParDef("@AV10pAusen_Ano",GXType.Int16,4,0) ,
          new ParDef("@AV11pIndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@AV12pCod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@AV6cAusenArea_Fecha",GXType.Date,8,0) ,
          new ParDef("@lV7cTipoAusen_Codigo",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00072", "SELECT [Cod_Area], [IndicadoresCodigo], [Ausen_Ano], [Ausen_Mes], [Ausen_Fecha], [AusentismosAreaReg], [AusenAreaValor], [TipoAusen_Codigo], [AusenArea_Fecha] FROM [AusentismosTipos] WHERE ([Ausen_Fecha] = @AV8pAusen_Fecha and [Ausen_Mes] = @AV9pAusen_Mes and [Ausen_Ano] = @AV10pAusen_Ano and [IndicadoresCodigo] = @AV11pIndicadoresCodigo and [Cod_Area] = @AV12pCod_Area and [AusenArea_Fecha] >= @AV6cAusenArea_Fecha) AND ([TipoAusen_Codigo] like @lV7cTipoAusen_Codigo) ORDER BY [Ausen_Fecha], [Ausen_Mes], [Ausen_Ano], [IndicadoresCodigo], [Cod_Area], [AusenArea_Fecha], [TipoAusen_Codigo]  OFFSET @GXPagingFrom2 ROWS FETCH NEXT CAST((SELECT CASE WHEN @GXPagingTo2 > 0 THEN @GXPagingTo2 ELSE 1e9 END) AS INTEGER) ROWS ONLY",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00072,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00073", "SELECT COUNT(*) FROM [AusentismosTipos] WHERE ([Ausen_Fecha] = @AV8pAusen_Fecha and [Ausen_Mes] = @AV9pAusen_Mes and [Ausen_Ano] = @AV10pAusen_Ano and [IndicadoresCodigo] = @AV11pIndicadoresCodigo and [Cod_Area] = @AV12pCod_Area and [AusenArea_Fecha] >= @AV6cAusenArea_Fecha) AND ([TipoAusen_Codigo] like @lV7cTipoAusen_Codigo) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00073,1, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
