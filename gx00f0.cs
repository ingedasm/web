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
   public class gx00f0 : GXDataArea
   {
      public gx00f0( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("IndicadroresPalmas", true);
      }

      public gx00f0( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out string aP0_pIndicadoresCodigo ,
                           out short aP1_pMetasIndicadoresMes ,
                           out short aP2_pMetasIndicadoresAno ,
                           out string aP3_pTipoMetasCodigo )
      {
         this.AV13pIndicadoresCodigo = "" ;
         this.AV14pMetasIndicadoresMes = 0 ;
         this.AV15pMetasIndicadoresAno = 0 ;
         this.AV16pTipoMetasCodigo = "" ;
         executePrivate();
         aP0_pIndicadoresCodigo=this.AV13pIndicadoresCodigo;
         aP1_pMetasIndicadoresMes=this.AV14pMetasIndicadoresMes;
         aP2_pMetasIndicadoresAno=this.AV15pMetasIndicadoresAno;
         aP3_pTipoMetasCodigo=this.AV16pTipoMetasCodigo;
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
            gxfirstwebparm = GetFirstPar( "pIndicadoresCodigo");
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
               gxfirstwebparm = GetFirstPar( "pIndicadoresCodigo");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pIndicadoresCodigo");
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
               AV13pIndicadoresCodigo = gxfirstwebparm;
               AssignAttri("", false, "AV13pIndicadoresCodigo", AV13pIndicadoresCodigo);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV14pMetasIndicadoresMes = (short)(Math.Round(NumberUtil.Val( GetPar( "pMetasIndicadoresMes"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV14pMetasIndicadoresMes", StringUtil.LTrimStr( (decimal)(AV14pMetasIndicadoresMes), 4, 0));
                  AV15pMetasIndicadoresAno = (short)(Math.Round(NumberUtil.Val( GetPar( "pMetasIndicadoresAno"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV15pMetasIndicadoresAno", StringUtil.LTrimStr( (decimal)(AV15pMetasIndicadoresAno), 4, 0));
                  AV16pTipoMetasCodigo = GetPar( "pTipoMetasCodigo");
                  AssignAttri("", false, "AV16pTipoMetasCodigo", AV16pTipoMetasCodigo);
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
         AV6cIndicadoresCodigo = GetPar( "cIndicadoresCodigo");
         AV7cMetasIndicadoresMes = (short)(Math.Round(NumberUtil.Val( GetPar( "cMetasIndicadoresMes"), "."), 18, MidpointRounding.ToEven));
         AV8cMetasIndicadoresAno = (short)(Math.Round(NumberUtil.Val( GetPar( "cMetasIndicadoresAno"), "."), 18, MidpointRounding.ToEven));
         AV9cTipoMetasCodigo = GetPar( "cTipoMetasCodigo");
         AV10cMetasIndicadoresValorMes = NumberUtil.Val( GetPar( "cMetasIndicadoresValorMes"), ".");
         AV11cMetasIndicadoresTicketNro = (long)(Math.Round(NumberUtil.Val( GetPar( "cMetasIndicadoresTicketNro"), "."), 18, MidpointRounding.ToEven));
         AV12cMotivosMetasCodigo = GetPar( "cMotivosMetasCodigo");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cIndicadoresCodigo, AV7cMetasIndicadoresMes, AV8cMetasIndicadoresAno, AV9cTipoMetasCodigo, AV10cMetasIndicadoresValorMes, AV11cMetasIndicadoresTicketNro, AV12cMotivosMetasCodigo) ;
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
         PA0H2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0H2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx00f0.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV13pIndicadoresCodigo)),UrlEncode(StringUtil.LTrimStr(AV14pMetasIndicadoresMes,4,0)),UrlEncode(StringUtil.LTrimStr(AV15pMetasIndicadoresAno,4,0)),UrlEncode(StringUtil.RTrim(AV16pTipoMetasCodigo))}, new string[] {"pIndicadoresCodigo","pMetasIndicadoresMes","pMetasIndicadoresAno","pTipoMetasCodigo"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCINDICADORESCODIGO", AV6cIndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "GXH_vCMETASINDICADORESMES", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cMetasIndicadoresMes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCMETASINDICADORESANO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cMetasIndicadoresAno), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCTIPOMETASCODIGO", AV9cTipoMetasCodigo);
         GxWebStd.gx_hidden_field( context, "GXH_vCMETASINDICADORESVALORMES", StringUtil.LTrim( StringUtil.NToC( AV10cMetasIndicadoresValorMes, 12, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCMETASINDICADORESTICKETNRO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cMetasIndicadoresTicketNro), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCMOTIVOSMETASCODIGO", AV12cMotivosMetasCodigo);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPINDICADORESCODIGO", AV13pIndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "vPMETASINDICADORESMES", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14pMetasIndicadoresMes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPMETASINDICADORESANO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15pMetasIndicadoresAno), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPTIPOMETASCODIGO", AV16pTipoMetasCodigo);
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "INDICADORESCODIGOFILTERCONTAINER_Class", StringUtil.RTrim( divIndicadorescodigofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "METASINDICADORESMESFILTERCONTAINER_Class", StringUtil.RTrim( divMetasindicadoresmesfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "METASINDICADORESANOFILTERCONTAINER_Class", StringUtil.RTrim( divMetasindicadoresanofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TIPOMETASCODIGOFILTERCONTAINER_Class", StringUtil.RTrim( divTipometascodigofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "METASINDICADORESVALORMESFILTERCONTAINER_Class", StringUtil.RTrim( divMetasindicadoresvalormesfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "METASINDICADORESTICKETNROFILTERCONTAINER_Class", StringUtil.RTrim( divMetasindicadoresticketnrofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "MOTIVOSMETASCODIGOFILTERCONTAINER_Class", StringUtil.RTrim( divMotivosmetascodigofiltercontainer_Class));
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
            WE0H2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0H2( ) ;
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
         return formatLink("gx00f0.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV13pIndicadoresCodigo)),UrlEncode(StringUtil.LTrimStr(AV14pMetasIndicadoresMes,4,0)),UrlEncode(StringUtil.LTrimStr(AV15pMetasIndicadoresAno,4,0)),UrlEncode(StringUtil.RTrim(AV16pTipoMetasCodigo))}, new string[] {"pIndicadoresCodigo","pMetasIndicadoresMes","pMetasIndicadoresAno","pTipoMetasCodigo"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx00F0" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List Metas Indicadores" ;
      }

      protected void WB0H0( )
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
            GxWebStd.gx_div_start( context, divIndicadorescodigofiltercontainer_Internalname, 1, 0, "px", 0, "px", divIndicadorescodigofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblindicadorescodigofilter_Internalname, "Indicadores Codigo", "", "", lblLblindicadorescodigofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e110h1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00F0.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCindicadorescodigo_Internalname, AV6cIndicadoresCodigo, StringUtil.RTrim( context.localUtil.Format( AV6cIndicadoresCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCindicadorescodigo_Jsonclick, 0, "Attribute", "", "", "", "", edtavCindicadorescodigo_Visible, edtavCindicadorescodigo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Gx00F0.htm");
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
            GxWebStd.gx_div_start( context, divMetasindicadoresmesfiltercontainer_Internalname, 1, 0, "px", 0, "px", divMetasindicadoresmesfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblmetasindicadoresmesfilter_Internalname, "Metas Indicadores Mes", "", "", lblLblmetasindicadoresmesfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e120h1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00F0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCmetasindicadoresmes_Internalname, "Metas Indicadores Mes", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCmetasindicadoresmes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cMetasIndicadoresMes), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCmetasindicadoresmes_Enabled!=0) ? context.localUtil.Format( (decimal)(AV7cMetasIndicadoresMes), "ZZZ9") : context.localUtil.Format( (decimal)(AV7cMetasIndicadoresMes), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCmetasindicadoresmes_Jsonclick, 0, "Attribute", "", "", "", "", edtavCmetasindicadoresmes_Visible, edtavCmetasindicadoresmes_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00F0.htm");
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
            GxWebStd.gx_div_start( context, divMetasindicadoresanofiltercontainer_Internalname, 1, 0, "px", 0, "px", divMetasindicadoresanofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblmetasindicadoresanofilter_Internalname, "Metas Indicadores Ano", "", "", lblLblmetasindicadoresanofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e130h1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00F0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCmetasindicadoresano_Internalname, "Metas Indicadores Ano", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCmetasindicadoresano_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cMetasIndicadoresAno), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCmetasindicadoresano_Enabled!=0) ? context.localUtil.Format( (decimal)(AV8cMetasIndicadoresAno), "ZZZ9") : context.localUtil.Format( (decimal)(AV8cMetasIndicadoresAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCmetasindicadoresano_Jsonclick, 0, "Attribute", "", "", "", "", edtavCmetasindicadoresano_Visible, edtavCmetasindicadoresano_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00F0.htm");
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
            GxWebStd.gx_div_start( context, divTipometascodigofiltercontainer_Internalname, 1, 0, "px", 0, "px", divTipometascodigofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltipometascodigofilter_Internalname, "Tipo Metas Codigo", "", "", lblLbltipometascodigofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e140h1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00F0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtipometascodigo_Internalname, "Tipo Metas Codigo", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtipometascodigo_Internalname, AV9cTipoMetasCodigo, StringUtil.RTrim( context.localUtil.Format( AV9cTipoMetasCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtipometascodigo_Jsonclick, 0, "Attribute", "", "", "", "", edtavCtipometascodigo_Visible, edtavCtipometascodigo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Gx00F0.htm");
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
            GxWebStd.gx_div_start( context, divMetasindicadoresvalormesfiltercontainer_Internalname, 1, 0, "px", 0, "px", divMetasindicadoresvalormesfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblmetasindicadoresvalormesfilter_Internalname, "Metas Indicadores Valor Mes", "", "", lblLblmetasindicadoresvalormesfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e150h1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00F0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCmetasindicadoresvalormes_Internalname, "Metas Indicadores Valor Mes", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCmetasindicadoresvalormes_Internalname, StringUtil.LTrim( StringUtil.NToC( AV10cMetasIndicadoresValorMes, 12, 2, ",", "")), StringUtil.LTrim( ((edtavCmetasindicadoresvalormes_Enabled!=0) ? context.localUtil.Format( AV10cMetasIndicadoresValorMes, "ZZZZZZZZ9.99") : context.localUtil.Format( AV10cMetasIndicadoresValorMes, "ZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCmetasindicadoresvalormes_Jsonclick, 0, "Attribute", "", "", "", "", edtavCmetasindicadoresvalormes_Visible, edtavCmetasindicadoresvalormes_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00F0.htm");
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
            GxWebStd.gx_div_start( context, divMetasindicadoresticketnrofiltercontainer_Internalname, 1, 0, "px", 0, "px", divMetasindicadoresticketnrofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblmetasindicadoresticketnrofilter_Internalname, "Metas Indicadores Ticket Nro", "", "", lblLblmetasindicadoresticketnrofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e160h1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00F0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCmetasindicadoresticketnro_Internalname, "Metas Indicadores Ticket Nro", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCmetasindicadoresticketnro_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cMetasIndicadoresTicketNro), 10, 0, ",", "")), StringUtil.LTrim( ((edtavCmetasindicadoresticketnro_Enabled!=0) ? context.localUtil.Format( (decimal)(AV11cMetasIndicadoresTicketNro), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV11cMetasIndicadoresTicketNro), "ZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCmetasindicadoresticketnro_Jsonclick, 0, "Attribute", "", "", "", "", edtavCmetasindicadoresticketnro_Visible, edtavCmetasindicadoresticketnro_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00F0.htm");
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
            GxWebStd.gx_div_start( context, divMotivosmetascodigofiltercontainer_Internalname, 1, 0, "px", 0, "px", divMotivosmetascodigofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblmotivosmetascodigofilter_Internalname, "Motivos Metas Codigo", "", "", lblLblmotivosmetascodigofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e170h1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00F0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCmotivosmetascodigo_Internalname, "Motivos Metas Codigo", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCmotivosmetascodigo_Internalname, AV12cMotivosMetasCodigo, StringUtil.RTrim( context.localUtil.Format( AV12cMotivosMetasCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCmotivosmetascodigo_Jsonclick, 0, "Attribute", "", "", "", "", edtavCmotivosmetascodigo_Visible, edtavCmotivosmetascodigo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Gx00F0.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e180h1_client"+"'", TempTags, "", 2, "HLP_Gx00F0.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx00F0.htm");
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

      protected void START0H2( )
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
            Form.Meta.addItem("description", "Selection List Metas Indicadores", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0H0( ) ;
      }

      protected void WS0H2( )
      {
         START0H2( ) ;
         EVT0H2( ) ;
      }

      protected void EVT0H2( )
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
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV20Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_84_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A4IndicadoresCodigo = cgiGet( edtIndicadoresCodigo_Internalname);
                              A32MetasIndicadoresMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtMetasIndicadoresMes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A33MetasIndicadoresAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtMetasIndicadoresAno_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A31TipoMetasCodigo = cgiGet( edtTipoMetasCodigo_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E190H2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E200H2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cindicadorescodigo Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCINDICADORESCODIGO"), AV6cIndicadoresCodigo) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cmetasindicadoresmes Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCMETASINDICADORESMES"), ",", ".") != Convert.ToDecimal( AV7cMetasIndicadoresMes )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cmetasindicadoresano Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCMETASINDICADORESANO"), ",", ".") != Convert.ToDecimal( AV8cMetasIndicadoresAno )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ctipometascodigo Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCTIPOMETASCODIGO"), AV9cTipoMetasCodigo) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cmetasindicadoresvalormes Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCMETASINDICADORESVALORMES"), ",", ".") != AV10cMetasIndicadoresValorMes )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cmetasindicadoresticketnro Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCMETASINDICADORESTICKETNRO"), ",", ".") != Convert.ToDecimal( AV11cMetasIndicadoresTicketNro )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cmotivosmetascodigo Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCMOTIVOSMETASCODIGO"), AV12cMotivosMetasCodigo) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E210H2 ();
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

      protected void WE0H2( )
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

      protected void PA0H2( )
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
                                        string AV6cIndicadoresCodigo ,
                                        short AV7cMetasIndicadoresMes ,
                                        short AV8cMetasIndicadoresAno ,
                                        string AV9cTipoMetasCodigo ,
                                        decimal AV10cMetasIndicadoresValorMes ,
                                        long AV11cMetasIndicadoresTicketNro ,
                                        string AV12cMotivosMetasCodigo )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF0H2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_INDICADORESCODIGO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A4IndicadoresCodigo, "")), context));
         GxWebStd.gx_hidden_field( context, "INDICADORESCODIGO", A4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "gxhash_METASINDICADORESMES", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A32MetasIndicadoresMes), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "METASINDICADORESMES", StringUtil.LTrim( StringUtil.NToC( (decimal)(A32MetasIndicadoresMes), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_METASINDICADORESANO", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A33MetasIndicadoresAno), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "METASINDICADORESANO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A33MetasIndicadoresAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_TIPOMETASCODIGO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A31TipoMetasCodigo, "")), context));
         GxWebStd.gx_hidden_field( context, "TIPOMETASCODIGO", A31TipoMetasCodigo);
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
         RF0H2( ) ;
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

      protected void RF0H2( )
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
                                                 AV10cMetasIndicadoresValorMes ,
                                                 AV11cMetasIndicadoresTicketNro ,
                                                 AV12cMotivosMetasCodigo ,
                                                 A143MetasIndicadoresValorMes ,
                                                 A139MetasIndicadoresTicketNro ,
                                                 A34MotivosMetasCodigo ,
                                                 A4IndicadoresCodigo ,
                                                 AV6cIndicadoresCodigo ,
                                                 A32MetasIndicadoresMes ,
                                                 AV7cMetasIndicadoresMes ,
                                                 A33MetasIndicadoresAno ,
                                                 AV8cMetasIndicadoresAno ,
                                                 A31TipoMetasCodigo ,
                                                 AV9cTipoMetasCodigo } ,
                                                 new int[]{
                                                 TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            lV6cIndicadoresCodigo = StringUtil.Concat( StringUtil.RTrim( AV6cIndicadoresCodigo), "%", "");
            lV9cTipoMetasCodigo = StringUtil.Concat( StringUtil.RTrim( AV9cTipoMetasCodigo), "%", "");
            lV12cMotivosMetasCodigo = StringUtil.Concat( StringUtil.RTrim( AV12cMotivosMetasCodigo), "%", "");
            /* Using cursor H000H2 */
            pr_default.execute(0, new Object[] {lV6cIndicadoresCodigo, AV7cMetasIndicadoresMes, AV8cMetasIndicadoresAno, lV9cTipoMetasCodigo, AV10cMetasIndicadoresValorMes, AV11cMetasIndicadoresTicketNro, lV12cMotivosMetasCodigo, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A34MotivosMetasCodigo = H000H2_A34MotivosMetasCodigo[0];
               A139MetasIndicadoresTicketNro = H000H2_A139MetasIndicadoresTicketNro[0];
               A143MetasIndicadoresValorMes = H000H2_A143MetasIndicadoresValorMes[0];
               A31TipoMetasCodigo = H000H2_A31TipoMetasCodigo[0];
               A33MetasIndicadoresAno = H000H2_A33MetasIndicadoresAno[0];
               A32MetasIndicadoresMes = H000H2_A32MetasIndicadoresMes[0];
               A4IndicadoresCodigo = H000H2_A4IndicadoresCodigo[0];
               /* Execute user event: Load */
               E200H2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WB0H0( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0H2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_INDICADORESCODIGO"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, StringUtil.RTrim( context.localUtil.Format( A4IndicadoresCodigo, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_METASINDICADORESMES"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A32MetasIndicadoresMes), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_METASINDICADORESANO"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A33MetasIndicadoresAno), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TIPOMETASCODIGO"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, StringUtil.RTrim( context.localUtil.Format( A31TipoMetasCodigo, "")), context));
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
                                              AV10cMetasIndicadoresValorMes ,
                                              AV11cMetasIndicadoresTicketNro ,
                                              AV12cMotivosMetasCodigo ,
                                              A143MetasIndicadoresValorMes ,
                                              A139MetasIndicadoresTicketNro ,
                                              A34MotivosMetasCodigo ,
                                              A4IndicadoresCodigo ,
                                              AV6cIndicadoresCodigo ,
                                              A32MetasIndicadoresMes ,
                                              AV7cMetasIndicadoresMes ,
                                              A33MetasIndicadoresAno ,
                                              AV8cMetasIndicadoresAno ,
                                              A31TipoMetasCodigo ,
                                              AV9cTipoMetasCodigo } ,
                                              new int[]{
                                              TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV6cIndicadoresCodigo = StringUtil.Concat( StringUtil.RTrim( AV6cIndicadoresCodigo), "%", "");
         lV9cTipoMetasCodigo = StringUtil.Concat( StringUtil.RTrim( AV9cTipoMetasCodigo), "%", "");
         lV12cMotivosMetasCodigo = StringUtil.Concat( StringUtil.RTrim( AV12cMotivosMetasCodigo), "%", "");
         /* Using cursor H000H3 */
         pr_default.execute(1, new Object[] {lV6cIndicadoresCodigo, AV7cMetasIndicadoresMes, AV8cMetasIndicadoresAno, lV9cTipoMetasCodigo, AV10cMetasIndicadoresValorMes, AV11cMetasIndicadoresTicketNro, lV12cMotivosMetasCodigo});
         GRID1_nRecordCount = H000H3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cIndicadoresCodigo, AV7cMetasIndicadoresMes, AV8cMetasIndicadoresAno, AV9cTipoMetasCodigo, AV10cMetasIndicadoresValorMes, AV11cMetasIndicadoresTicketNro, AV12cMotivosMetasCodigo) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cIndicadoresCodigo, AV7cMetasIndicadoresMes, AV8cMetasIndicadoresAno, AV9cTipoMetasCodigo, AV10cMetasIndicadoresValorMes, AV11cMetasIndicadoresTicketNro, AV12cMotivosMetasCodigo) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cIndicadoresCodigo, AV7cMetasIndicadoresMes, AV8cMetasIndicadoresAno, AV9cTipoMetasCodigo, AV10cMetasIndicadoresValorMes, AV11cMetasIndicadoresTicketNro, AV12cMotivosMetasCodigo) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cIndicadoresCodigo, AV7cMetasIndicadoresMes, AV8cMetasIndicadoresAno, AV9cTipoMetasCodigo, AV10cMetasIndicadoresValorMes, AV11cMetasIndicadoresTicketNro, AV12cMotivosMetasCodigo) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cIndicadoresCodigo, AV7cMetasIndicadoresMes, AV8cMetasIndicadoresAno, AV9cTipoMetasCodigo, AV10cMetasIndicadoresValorMes, AV11cMetasIndicadoresTicketNro, AV12cMotivosMetasCodigo) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0H0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E190H2 ();
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
            AV6cIndicadoresCodigo = cgiGet( edtavCindicadorescodigo_Internalname);
            AssignAttri("", false, "AV6cIndicadoresCodigo", AV6cIndicadoresCodigo);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCmetasindicadoresmes_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCmetasindicadoresmes_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCMETASINDICADORESMES");
               GX_FocusControl = edtavCmetasindicadoresmes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7cMetasIndicadoresMes = 0;
               AssignAttri("", false, "AV7cMetasIndicadoresMes", StringUtil.LTrimStr( (decimal)(AV7cMetasIndicadoresMes), 4, 0));
            }
            else
            {
               AV7cMetasIndicadoresMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCmetasindicadoresmes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7cMetasIndicadoresMes", StringUtil.LTrimStr( (decimal)(AV7cMetasIndicadoresMes), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCmetasindicadoresano_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCmetasindicadoresano_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCMETASINDICADORESANO");
               GX_FocusControl = edtavCmetasindicadoresano_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cMetasIndicadoresAno = 0;
               AssignAttri("", false, "AV8cMetasIndicadoresAno", StringUtil.LTrimStr( (decimal)(AV8cMetasIndicadoresAno), 4, 0));
            }
            else
            {
               AV8cMetasIndicadoresAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCmetasindicadoresano_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV8cMetasIndicadoresAno", StringUtil.LTrimStr( (decimal)(AV8cMetasIndicadoresAno), 4, 0));
            }
            AV9cTipoMetasCodigo = cgiGet( edtavCtipometascodigo_Internalname);
            AssignAttri("", false, "AV9cTipoMetasCodigo", AV9cTipoMetasCodigo);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCmetasindicadoresvalormes_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCmetasindicadoresvalormes_Internalname), ",", ".") > 999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCMETASINDICADORESVALORMES");
               GX_FocusControl = edtavCmetasindicadoresvalormes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cMetasIndicadoresValorMes = 0;
               AssignAttri("", false, "AV10cMetasIndicadoresValorMes", StringUtil.LTrimStr( AV10cMetasIndicadoresValorMes, 12, 2));
            }
            else
            {
               AV10cMetasIndicadoresValorMes = context.localUtil.CToN( cgiGet( edtavCmetasindicadoresvalormes_Internalname), ",", ".");
               AssignAttri("", false, "AV10cMetasIndicadoresValorMes", StringUtil.LTrimStr( AV10cMetasIndicadoresValorMes, 12, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCmetasindicadoresticketnro_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCmetasindicadoresticketnro_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCMETASINDICADORESTICKETNRO");
               GX_FocusControl = edtavCmetasindicadoresticketnro_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11cMetasIndicadoresTicketNro = 0;
               AssignAttri("", false, "AV11cMetasIndicadoresTicketNro", StringUtil.LTrimStr( (decimal)(AV11cMetasIndicadoresTicketNro), 10, 0));
            }
            else
            {
               AV11cMetasIndicadoresTicketNro = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCmetasindicadoresticketnro_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11cMetasIndicadoresTicketNro", StringUtil.LTrimStr( (decimal)(AV11cMetasIndicadoresTicketNro), 10, 0));
            }
            AV12cMotivosMetasCodigo = cgiGet( edtavCmotivosmetascodigo_Internalname);
            AssignAttri("", false, "AV12cMotivosMetasCodigo", AV12cMotivosMetasCodigo);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCINDICADORESCODIGO"), AV6cIndicadoresCodigo) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCMETASINDICADORESMES"), ",", ".") != Convert.ToDecimal( AV7cMetasIndicadoresMes )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCMETASINDICADORESANO"), ",", ".") != Convert.ToDecimal( AV8cMetasIndicadoresAno )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCTIPOMETASCODIGO"), AV9cTipoMetasCodigo) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vCMETASINDICADORESVALORMES"), ",", ".") != AV10cMetasIndicadoresValorMes )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCMETASINDICADORESTICKETNRO"), ",", ".") != Convert.ToDecimal( AV11cMetasIndicadoresTicketNro )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCMOTIVOSMETASCODIGO"), AV12cMotivosMetasCodigo) != 0 )
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
         E190H2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E190H2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Lista de Selección %1", "Metas Indicadores", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV17ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E200H2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "selectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV20Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )));
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
         E210H2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E210H2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pIndicadoresCodigo = A4IndicadoresCodigo;
         AssignAttri("", false, "AV13pIndicadoresCodigo", AV13pIndicadoresCodigo);
         AV14pMetasIndicadoresMes = A32MetasIndicadoresMes;
         AssignAttri("", false, "AV14pMetasIndicadoresMes", StringUtil.LTrimStr( (decimal)(AV14pMetasIndicadoresMes), 4, 0));
         AV15pMetasIndicadoresAno = A33MetasIndicadoresAno;
         AssignAttri("", false, "AV15pMetasIndicadoresAno", StringUtil.LTrimStr( (decimal)(AV15pMetasIndicadoresAno), 4, 0));
         AV16pTipoMetasCodigo = A31TipoMetasCodigo;
         AssignAttri("", false, "AV16pTipoMetasCodigo", AV16pTipoMetasCodigo);
         context.setWebReturnParms(new Object[] {(string)AV13pIndicadoresCodigo,(short)AV14pMetasIndicadoresMes,(short)AV15pMetasIndicadoresAno,(string)AV16pTipoMetasCodigo});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pIndicadoresCodigo","AV14pMetasIndicadoresMes","AV15pMetasIndicadoresAno","AV16pTipoMetasCodigo"});
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
         AV13pIndicadoresCodigo = (string)getParm(obj,0);
         AssignAttri("", false, "AV13pIndicadoresCodigo", AV13pIndicadoresCodigo);
         AV14pMetasIndicadoresMes = Convert.ToInt16(getParm(obj,1));
         AssignAttri("", false, "AV14pMetasIndicadoresMes", StringUtil.LTrimStr( (decimal)(AV14pMetasIndicadoresMes), 4, 0));
         AV15pMetasIndicadoresAno = Convert.ToInt16(getParm(obj,2));
         AssignAttri("", false, "AV15pMetasIndicadoresAno", StringUtil.LTrimStr( (decimal)(AV15pMetasIndicadoresAno), 4, 0));
         AV16pTipoMetasCodigo = (string)getParm(obj,3);
         AssignAttri("", false, "AV16pTipoMetasCodigo", AV16pTipoMetasCodigo);
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
         PA0H2( ) ;
         WS0H2( ) ;
         WE0H2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20247231021994", true, true);
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
         context.AddJavascriptSource("gx00f0.js", "?20247231021994", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO_"+sGXsfl_84_idx;
         edtMetasIndicadoresMes_Internalname = "METASINDICADORESMES_"+sGXsfl_84_idx;
         edtMetasIndicadoresAno_Internalname = "METASINDICADORESANO_"+sGXsfl_84_idx;
         edtTipoMetasCodigo_Internalname = "TIPOMETASCODIGO_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO_"+sGXsfl_84_fel_idx;
         edtMetasIndicadoresMes_Internalname = "METASINDICADORESMES_"+sGXsfl_84_fel_idx;
         edtMetasIndicadoresAno_Internalname = "METASINDICADORESANO_"+sGXsfl_84_fel_idx;
         edtTipoMetasCodigo_Internalname = "TIPOMETASCODIGO_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         SubsflControlProps_842( ) ;
         WB0H0( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( A4IndicadoresCodigo)+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A32MetasIndicadoresMes), 4, 0, ",", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A33MetasIndicadoresAno), 4, 0, ",", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( A31TipoMetasCodigo)+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_84_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV20Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV20Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
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
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMetasIndicadoresMes_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A32MetasIndicadoresMes), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A32MetasIndicadoresMes), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMetasIndicadoresMes_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMetasIndicadoresAno_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A33MetasIndicadoresAno), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A33MetasIndicadoresAno), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMetasIndicadoresAno_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipoMetasCodigo_Internalname,(string)A31TipoMetasCodigo,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTipoMetasCodigo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            send_integrity_lvl_hashes0H2( ) ;
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
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Indicadores Codigo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Indicadores Mes") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Indicadores Ano") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Tipo Metas Codigo") ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A4IndicadoresCodigo));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A32MetasIndicadoresMes), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A33MetasIndicadoresAno), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A31TipoMetasCodigo));
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
         lblLblindicadorescodigofilter_Internalname = "LBLINDICADORESCODIGOFILTER";
         edtavCindicadorescodigo_Internalname = "vCINDICADORESCODIGO";
         divIndicadorescodigofiltercontainer_Internalname = "INDICADORESCODIGOFILTERCONTAINER";
         lblLblmetasindicadoresmesfilter_Internalname = "LBLMETASINDICADORESMESFILTER";
         edtavCmetasindicadoresmes_Internalname = "vCMETASINDICADORESMES";
         divMetasindicadoresmesfiltercontainer_Internalname = "METASINDICADORESMESFILTERCONTAINER";
         lblLblmetasindicadoresanofilter_Internalname = "LBLMETASINDICADORESANOFILTER";
         edtavCmetasindicadoresano_Internalname = "vCMETASINDICADORESANO";
         divMetasindicadoresanofiltercontainer_Internalname = "METASINDICADORESANOFILTERCONTAINER";
         lblLbltipometascodigofilter_Internalname = "LBLTIPOMETASCODIGOFILTER";
         edtavCtipometascodigo_Internalname = "vCTIPOMETASCODIGO";
         divTipometascodigofiltercontainer_Internalname = "TIPOMETASCODIGOFILTERCONTAINER";
         lblLblmetasindicadoresvalormesfilter_Internalname = "LBLMETASINDICADORESVALORMESFILTER";
         edtavCmetasindicadoresvalormes_Internalname = "vCMETASINDICADORESVALORMES";
         divMetasindicadoresvalormesfiltercontainer_Internalname = "METASINDICADORESVALORMESFILTERCONTAINER";
         lblLblmetasindicadoresticketnrofilter_Internalname = "LBLMETASINDICADORESTICKETNROFILTER";
         edtavCmetasindicadoresticketnro_Internalname = "vCMETASINDICADORESTICKETNRO";
         divMetasindicadoresticketnrofiltercontainer_Internalname = "METASINDICADORESTICKETNROFILTERCONTAINER";
         lblLblmotivosmetascodigofilter_Internalname = "LBLMOTIVOSMETASCODIGOFILTER";
         edtavCmotivosmetascodigo_Internalname = "vCMOTIVOSMETASCODIGO";
         divMotivosmetascodigofiltercontainer_Internalname = "MOTIVOSMETASCODIGOFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO";
         edtMetasIndicadoresMes_Internalname = "METASINDICADORESMES";
         edtMetasIndicadoresAno_Internalname = "METASINDICADORESANO";
         edtTipoMetasCodigo_Internalname = "TIPOMETASCODIGO";
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
         edtTipoMetasCodigo_Jsonclick = "";
         edtMetasIndicadoresAno_Jsonclick = "";
         edtMetasIndicadoresMes_Jsonclick = "";
         edtIndicadoresCodigo_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtavCmotivosmetascodigo_Jsonclick = "";
         edtavCmotivosmetascodigo_Enabled = 1;
         edtavCmotivosmetascodigo_Visible = 1;
         edtavCmetasindicadoresticketnro_Jsonclick = "";
         edtavCmetasindicadoresticketnro_Enabled = 1;
         edtavCmetasindicadoresticketnro_Visible = 1;
         edtavCmetasindicadoresvalormes_Jsonclick = "";
         edtavCmetasindicadoresvalormes_Enabled = 1;
         edtavCmetasindicadoresvalormes_Visible = 1;
         edtavCtipometascodigo_Jsonclick = "";
         edtavCtipometascodigo_Enabled = 1;
         edtavCtipometascodigo_Visible = 1;
         edtavCmetasindicadoresano_Jsonclick = "";
         edtavCmetasindicadoresano_Enabled = 1;
         edtavCmetasindicadoresano_Visible = 1;
         edtavCmetasindicadoresmes_Jsonclick = "";
         edtavCmetasindicadoresmes_Enabled = 1;
         edtavCmetasindicadoresmes_Visible = 1;
         edtavCindicadorescodigo_Jsonclick = "";
         edtavCindicadorescodigo_Enabled = 1;
         edtavCindicadorescodigo_Visible = 1;
         divMotivosmetascodigofiltercontainer_Class = "AdvancedContainerItem";
         divMetasindicadoresticketnrofiltercontainer_Class = "AdvancedContainerItem";
         divMetasindicadoresvalormesfiltercontainer_Class = "AdvancedContainerItem";
         divTipometascodigofiltercontainer_Class = "AdvancedContainerItem";
         divMetasindicadoresanofiltercontainer_Class = "AdvancedContainerItem";
         divMetasindicadoresmesfiltercontainer_Class = "AdvancedContainerItem";
         divIndicadorescodigofiltercontainer_Class = "AdvancedContainerItem";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List Metas Indicadores";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV7cMetasIndicadoresMes',fld:'vCMETASINDICADORESMES',pic:'ZZZ9'},{av:'AV8cMetasIndicadoresAno',fld:'vCMETASINDICADORESANO',pic:'ZZZ9'},{av:'AV9cTipoMetasCodigo',fld:'vCTIPOMETASCODIGO',pic:''},{av:'AV10cMetasIndicadoresValorMes',fld:'vCMETASINDICADORESVALORMES',pic:'ZZZZZZZZ9.99'},{av:'AV11cMetasIndicadoresTicketNro',fld:'vCMETASINDICADORESTICKETNRO',pic:'ZZZZZZZZZ9'},{av:'AV12cMotivosMetasCodigo',fld:'vCMOTIVOSMETASCODIGO',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E180H1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLINDICADORESCODIGOFILTER.CLICK","{handler:'E110H1',iparms:[{av:'divIndicadorescodigofiltercontainer_Class',ctrl:'INDICADORESCODIGOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLINDICADORESCODIGOFILTER.CLICK",",oparms:[{av:'divIndicadorescodigofiltercontainer_Class',ctrl:'INDICADORESCODIGOFILTERCONTAINER',prop:'Class'},{av:'edtavCindicadorescodigo_Visible',ctrl:'vCINDICADORESCODIGO',prop:'Visible'}]}");
         setEventMetadata("LBLMETASINDICADORESMESFILTER.CLICK","{handler:'E120H1',iparms:[{av:'divMetasindicadoresmesfiltercontainer_Class',ctrl:'METASINDICADORESMESFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLMETASINDICADORESMESFILTER.CLICK",",oparms:[{av:'divMetasindicadoresmesfiltercontainer_Class',ctrl:'METASINDICADORESMESFILTERCONTAINER',prop:'Class'},{av:'edtavCmetasindicadoresmes_Visible',ctrl:'vCMETASINDICADORESMES',prop:'Visible'}]}");
         setEventMetadata("LBLMETASINDICADORESANOFILTER.CLICK","{handler:'E130H1',iparms:[{av:'divMetasindicadoresanofiltercontainer_Class',ctrl:'METASINDICADORESANOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLMETASINDICADORESANOFILTER.CLICK",",oparms:[{av:'divMetasindicadoresanofiltercontainer_Class',ctrl:'METASINDICADORESANOFILTERCONTAINER',prop:'Class'},{av:'edtavCmetasindicadoresano_Visible',ctrl:'vCMETASINDICADORESANO',prop:'Visible'}]}");
         setEventMetadata("LBLTIPOMETASCODIGOFILTER.CLICK","{handler:'E140H1',iparms:[{av:'divTipometascodigofiltercontainer_Class',ctrl:'TIPOMETASCODIGOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTIPOMETASCODIGOFILTER.CLICK",",oparms:[{av:'divTipometascodigofiltercontainer_Class',ctrl:'TIPOMETASCODIGOFILTERCONTAINER',prop:'Class'},{av:'edtavCtipometascodigo_Visible',ctrl:'vCTIPOMETASCODIGO',prop:'Visible'}]}");
         setEventMetadata("LBLMETASINDICADORESVALORMESFILTER.CLICK","{handler:'E150H1',iparms:[{av:'divMetasindicadoresvalormesfiltercontainer_Class',ctrl:'METASINDICADORESVALORMESFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLMETASINDICADORESVALORMESFILTER.CLICK",",oparms:[{av:'divMetasindicadoresvalormesfiltercontainer_Class',ctrl:'METASINDICADORESVALORMESFILTERCONTAINER',prop:'Class'},{av:'edtavCmetasindicadoresvalormes_Visible',ctrl:'vCMETASINDICADORESVALORMES',prop:'Visible'}]}");
         setEventMetadata("LBLMETASINDICADORESTICKETNROFILTER.CLICK","{handler:'E160H1',iparms:[{av:'divMetasindicadoresticketnrofiltercontainer_Class',ctrl:'METASINDICADORESTICKETNROFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLMETASINDICADORESTICKETNROFILTER.CLICK",",oparms:[{av:'divMetasindicadoresticketnrofiltercontainer_Class',ctrl:'METASINDICADORESTICKETNROFILTERCONTAINER',prop:'Class'},{av:'edtavCmetasindicadoresticketnro_Visible',ctrl:'vCMETASINDICADORESTICKETNRO',prop:'Visible'}]}");
         setEventMetadata("LBLMOTIVOSMETASCODIGOFILTER.CLICK","{handler:'E170H1',iparms:[{av:'divMotivosmetascodigofiltercontainer_Class',ctrl:'MOTIVOSMETASCODIGOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLMOTIVOSMETASCODIGOFILTER.CLICK",",oparms:[{av:'divMotivosmetascodigofiltercontainer_Class',ctrl:'MOTIVOSMETASCODIGOFILTERCONTAINER',prop:'Class'},{av:'edtavCmotivosmetascodigo_Visible',ctrl:'vCMOTIVOSMETASCODIGO',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E210H2',iparms:[{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:'',hsh:true},{av:'A32MetasIndicadoresMes',fld:'METASINDICADORESMES',pic:'ZZZ9',hsh:true},{av:'A33MetasIndicadoresAno',fld:'METASINDICADORESANO',pic:'ZZZ9',hsh:true},{av:'A31TipoMetasCodigo',fld:'TIPOMETASCODIGO',pic:'',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pIndicadoresCodigo',fld:'vPINDICADORESCODIGO',pic:''},{av:'AV14pMetasIndicadoresMes',fld:'vPMETASINDICADORESMES',pic:'ZZZ9'},{av:'AV15pMetasIndicadoresAno',fld:'vPMETASINDICADORESANO',pic:'ZZZ9'},{av:'AV16pTipoMetasCodigo',fld:'vPTIPOMETASCODIGO',pic:''}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV7cMetasIndicadoresMes',fld:'vCMETASINDICADORESMES',pic:'ZZZ9'},{av:'AV8cMetasIndicadoresAno',fld:'vCMETASINDICADORESANO',pic:'ZZZ9'},{av:'AV9cTipoMetasCodigo',fld:'vCTIPOMETASCODIGO',pic:''},{av:'AV10cMetasIndicadoresValorMes',fld:'vCMETASINDICADORESVALORMES',pic:'ZZZZZZZZ9.99'},{av:'AV11cMetasIndicadoresTicketNro',fld:'vCMETASINDICADORESTICKETNRO',pic:'ZZZZZZZZZ9'},{av:'AV12cMotivosMetasCodigo',fld:'vCMOTIVOSMETASCODIGO',pic:''}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV7cMetasIndicadoresMes',fld:'vCMETASINDICADORESMES',pic:'ZZZ9'},{av:'AV8cMetasIndicadoresAno',fld:'vCMETASINDICADORESANO',pic:'ZZZ9'},{av:'AV9cTipoMetasCodigo',fld:'vCTIPOMETASCODIGO',pic:''},{av:'AV10cMetasIndicadoresValorMes',fld:'vCMETASINDICADORESVALORMES',pic:'ZZZZZZZZ9.99'},{av:'AV11cMetasIndicadoresTicketNro',fld:'vCMETASINDICADORESTICKETNRO',pic:'ZZZZZZZZZ9'},{av:'AV12cMotivosMetasCodigo',fld:'vCMOTIVOSMETASCODIGO',pic:''}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV7cMetasIndicadoresMes',fld:'vCMETASINDICADORESMES',pic:'ZZZ9'},{av:'AV8cMetasIndicadoresAno',fld:'vCMETASINDICADORESANO',pic:'ZZZ9'},{av:'AV9cTipoMetasCodigo',fld:'vCTIPOMETASCODIGO',pic:''},{av:'AV10cMetasIndicadoresValorMes',fld:'vCMETASINDICADORESVALORMES',pic:'ZZZZZZZZ9.99'},{av:'AV11cMetasIndicadoresTicketNro',fld:'vCMETASINDICADORESTICKETNRO',pic:'ZZZZZZZZZ9'},{av:'AV12cMotivosMetasCodigo',fld:'vCMOTIVOSMETASCODIGO',pic:''}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV7cMetasIndicadoresMes',fld:'vCMETASINDICADORESMES',pic:'ZZZ9'},{av:'AV8cMetasIndicadoresAno',fld:'vCMETASINDICADORESANO',pic:'ZZZ9'},{av:'AV9cTipoMetasCodigo',fld:'vCTIPOMETASCODIGO',pic:''},{av:'AV10cMetasIndicadoresValorMes',fld:'vCMETASINDICADORESVALORMES',pic:'ZZZZZZZZ9.99'},{av:'AV11cMetasIndicadoresTicketNro',fld:'vCMETASINDICADORESTICKETNRO',pic:'ZZZZZZZZZ9'},{av:'AV12cMotivosMetasCodigo',fld:'vCMOTIVOSMETASCODIGO',pic:''}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Tipometascodigo',iparms:[]");
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
         AV13pIndicadoresCodigo = "";
         AV16pTipoMetasCodigo = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV6cIndicadoresCodigo = "";
         AV9cTipoMetasCodigo = "";
         AV12cMotivosMetasCodigo = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblindicadorescodigofilter_Jsonclick = "";
         TempTags = "";
         lblLblmetasindicadoresmesfilter_Jsonclick = "";
         lblLblmetasindicadoresanofilter_Jsonclick = "";
         lblLbltipometascodigofilter_Jsonclick = "";
         lblLblmetasindicadoresvalormesfilter_Jsonclick = "";
         lblLblmetasindicadoresticketnrofilter_Jsonclick = "";
         lblLblmotivosmetascodigofilter_Jsonclick = "";
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
         A4IndicadoresCodigo = "";
         A31TipoMetasCodigo = "";
         scmdbuf = "";
         lV6cIndicadoresCodigo = "";
         lV9cTipoMetasCodigo = "";
         lV12cMotivosMetasCodigo = "";
         A34MotivosMetasCodigo = "";
         H000H2_A34MotivosMetasCodigo = new string[] {""} ;
         H000H2_A139MetasIndicadoresTicketNro = new long[1] ;
         H000H2_A143MetasIndicadoresValorMes = new decimal[1] ;
         H000H2_A31TipoMetasCodigo = new string[] {""} ;
         H000H2_A33MetasIndicadoresAno = new short[1] ;
         H000H2_A32MetasIndicadoresMes = new short[1] ;
         H000H2_A4IndicadoresCodigo = new string[] {""} ;
         H000H3_AGRID1_nRecordCount = new long[1] ;
         AV17ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx00f0__default(),
            new Object[][] {
                new Object[] {
               H000H2_A34MotivosMetasCodigo, H000H2_A139MetasIndicadoresTicketNro, H000H2_A143MetasIndicadoresValorMes, H000H2_A31TipoMetasCodigo, H000H2_A33MetasIndicadoresAno, H000H2_A32MetasIndicadoresMes, H000H2_A4IndicadoresCodigo
               }
               , new Object[] {
               H000H3_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV14pMetasIndicadoresMes ;
      private short AV15pMetasIndicadoresAno ;
      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV7cMetasIndicadoresMes ;
      private short AV8cMetasIndicadoresAno ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A32MetasIndicadoresMes ;
      private short A33MetasIndicadoresAno ;
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
      private int edtavCindicadorescodigo_Visible ;
      private int edtavCindicadorescodigo_Enabled ;
      private int edtavCmetasindicadoresmes_Enabled ;
      private int edtavCmetasindicadoresmes_Visible ;
      private int edtavCmetasindicadoresano_Enabled ;
      private int edtavCmetasindicadoresano_Visible ;
      private int edtavCtipometascodigo_Visible ;
      private int edtavCtipometascodigo_Enabled ;
      private int edtavCmetasindicadoresvalormes_Enabled ;
      private int edtavCmetasindicadoresvalormes_Visible ;
      private int edtavCmetasindicadoresticketnro_Enabled ;
      private int edtavCmetasindicadoresticketnro_Visible ;
      private int edtavCmotivosmetascodigo_Visible ;
      private int edtavCmotivosmetascodigo_Enabled ;
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
      private long AV11cMetasIndicadoresTicketNro ;
      private long GRID1_nCurrentRecord ;
      private long A139MetasIndicadoresTicketNro ;
      private long GRID1_nRecordCount ;
      private decimal AV10cMetasIndicadoresValorMes ;
      private decimal A143MetasIndicadoresValorMes ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divIndicadorescodigofiltercontainer_Class ;
      private string divMetasindicadoresmesfiltercontainer_Class ;
      private string divMetasindicadoresanofiltercontainer_Class ;
      private string divTipometascodigofiltercontainer_Class ;
      private string divMetasindicadoresvalormesfiltercontainer_Class ;
      private string divMetasindicadoresticketnrofiltercontainer_Class ;
      private string divMotivosmetascodigofiltercontainer_Class ;
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
      private string divIndicadorescodigofiltercontainer_Internalname ;
      private string lblLblindicadorescodigofilter_Internalname ;
      private string lblLblindicadorescodigofilter_Jsonclick ;
      private string edtavCindicadorescodigo_Internalname ;
      private string TempTags ;
      private string edtavCindicadorescodigo_Jsonclick ;
      private string divMetasindicadoresmesfiltercontainer_Internalname ;
      private string lblLblmetasindicadoresmesfilter_Internalname ;
      private string lblLblmetasindicadoresmesfilter_Jsonclick ;
      private string edtavCmetasindicadoresmes_Internalname ;
      private string edtavCmetasindicadoresmes_Jsonclick ;
      private string divMetasindicadoresanofiltercontainer_Internalname ;
      private string lblLblmetasindicadoresanofilter_Internalname ;
      private string lblLblmetasindicadoresanofilter_Jsonclick ;
      private string edtavCmetasindicadoresano_Internalname ;
      private string edtavCmetasindicadoresano_Jsonclick ;
      private string divTipometascodigofiltercontainer_Internalname ;
      private string lblLbltipometascodigofilter_Internalname ;
      private string lblLbltipometascodigofilter_Jsonclick ;
      private string edtavCtipometascodigo_Internalname ;
      private string edtavCtipometascodigo_Jsonclick ;
      private string divMetasindicadoresvalormesfiltercontainer_Internalname ;
      private string lblLblmetasindicadoresvalormesfilter_Internalname ;
      private string lblLblmetasindicadoresvalormesfilter_Jsonclick ;
      private string edtavCmetasindicadoresvalormes_Internalname ;
      private string edtavCmetasindicadoresvalormes_Jsonclick ;
      private string divMetasindicadoresticketnrofiltercontainer_Internalname ;
      private string lblLblmetasindicadoresticketnrofilter_Internalname ;
      private string lblLblmetasindicadoresticketnrofilter_Jsonclick ;
      private string edtavCmetasindicadoresticketnro_Internalname ;
      private string edtavCmetasindicadoresticketnro_Jsonclick ;
      private string divMotivosmetascodigofiltercontainer_Internalname ;
      private string lblLblmotivosmetascodigofilter_Internalname ;
      private string lblLblmotivosmetascodigofilter_Jsonclick ;
      private string edtavCmotivosmetascodigo_Internalname ;
      private string edtavCmotivosmetascodigo_Jsonclick ;
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
      private string edtIndicadoresCodigo_Internalname ;
      private string edtMetasIndicadoresMes_Internalname ;
      private string edtMetasIndicadoresAno_Internalname ;
      private string edtTipoMetasCodigo_Internalname ;
      private string scmdbuf ;
      private string AV17ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtIndicadoresCodigo_Jsonclick ;
      private string edtMetasIndicadoresMes_Jsonclick ;
      private string edtMetasIndicadoresAno_Jsonclick ;
      private string edtTipoMetasCodigo_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV13pIndicadoresCodigo ;
      private string AV16pTipoMetasCodigo ;
      private string AV6cIndicadoresCodigo ;
      private string AV9cTipoMetasCodigo ;
      private string AV12cMotivosMetasCodigo ;
      private string AV20Linkselection_GXI ;
      private string A4IndicadoresCodigo ;
      private string A31TipoMetasCodigo ;
      private string lV6cIndicadoresCodigo ;
      private string lV9cTipoMetasCodigo ;
      private string lV12cMotivosMetasCodigo ;
      private string A34MotivosMetasCodigo ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] H000H2_A34MotivosMetasCodigo ;
      private long[] H000H2_A139MetasIndicadoresTicketNro ;
      private decimal[] H000H2_A143MetasIndicadoresValorMes ;
      private string[] H000H2_A31TipoMetasCodigo ;
      private short[] H000H2_A33MetasIndicadoresAno ;
      private short[] H000H2_A32MetasIndicadoresMes ;
      private string[] H000H2_A4IndicadoresCodigo ;
      private long[] H000H3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private string aP0_pIndicadoresCodigo ;
      private short aP1_pMetasIndicadoresMes ;
      private short aP2_pMetasIndicadoresAno ;
      private string aP3_pTipoMetasCodigo ;
      private GXWebForm Form ;
   }

   public class gx00f0__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H000H2( IGxContext context ,
                                             decimal AV10cMetasIndicadoresValorMes ,
                                             long AV11cMetasIndicadoresTicketNro ,
                                             string AV12cMotivosMetasCodigo ,
                                             decimal A143MetasIndicadoresValorMes ,
                                             long A139MetasIndicadoresTicketNro ,
                                             string A34MotivosMetasCodigo ,
                                             string A4IndicadoresCodigo ,
                                             string AV6cIndicadoresCodigo ,
                                             short A32MetasIndicadoresMes ,
                                             short AV7cMetasIndicadoresMes ,
                                             short A33MetasIndicadoresAno ,
                                             short AV8cMetasIndicadoresAno ,
                                             string A31TipoMetasCodigo ,
                                             string AV9cTipoMetasCodigo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [MotivosMetasCodigo], [MetasIndicadoresTicketNro], [MetasIndicadoresValorMes], [TipoMetasCodigo], [MetasIndicadoresAno], [MetasIndicadoresMes], [IndicadoresCodigo]";
         sFromString = " FROM [MetasIndicadores]";
         sOrderString = "";
         AddWhere(sWhereString, "([IndicadoresCodigo] like @lV6cIndicadoresCodigo)");
         AddWhere(sWhereString, "([MetasIndicadoresMes] >= @AV7cMetasIndicadoresMes)");
         AddWhere(sWhereString, "([MetasIndicadoresAno] >= @AV8cMetasIndicadoresAno)");
         AddWhere(sWhereString, "([TipoMetasCodigo] like @lV9cTipoMetasCodigo)");
         if ( ! (Convert.ToDecimal(0)==AV10cMetasIndicadoresValorMes) )
         {
            AddWhere(sWhereString, "([MetasIndicadoresValorMes] >= @AV10cMetasIndicadoresValorMes)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV11cMetasIndicadoresTicketNro) )
         {
            AddWhere(sWhereString, "([MetasIndicadoresTicketNro] >= @AV11cMetasIndicadoresTicketNro)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12cMotivosMetasCodigo)) )
         {
            AddWhere(sWhereString, "([MotivosMetasCodigo] like @lV12cMotivosMetasCodigo)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [IndicadoresCodigo], [MetasIndicadoresMes], [MetasIndicadoresAno], [TipoMetasCodigo]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H000H3( IGxContext context ,
                                             decimal AV10cMetasIndicadoresValorMes ,
                                             long AV11cMetasIndicadoresTicketNro ,
                                             string AV12cMotivosMetasCodigo ,
                                             decimal A143MetasIndicadoresValorMes ,
                                             long A139MetasIndicadoresTicketNro ,
                                             string A34MotivosMetasCodigo ,
                                             string A4IndicadoresCodigo ,
                                             string AV6cIndicadoresCodigo ,
                                             short A32MetasIndicadoresMes ,
                                             short AV7cMetasIndicadoresMes ,
                                             short A33MetasIndicadoresAno ,
                                             short AV8cMetasIndicadoresAno ,
                                             string A31TipoMetasCodigo ,
                                             string AV9cTipoMetasCodigo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [MetasIndicadores]";
         AddWhere(sWhereString, "([IndicadoresCodigo] like @lV6cIndicadoresCodigo)");
         AddWhere(sWhereString, "([MetasIndicadoresMes] >= @AV7cMetasIndicadoresMes)");
         AddWhere(sWhereString, "([MetasIndicadoresAno] >= @AV8cMetasIndicadoresAno)");
         AddWhere(sWhereString, "([TipoMetasCodigo] like @lV9cTipoMetasCodigo)");
         if ( ! (Convert.ToDecimal(0)==AV10cMetasIndicadoresValorMes) )
         {
            AddWhere(sWhereString, "([MetasIndicadoresValorMes] >= @AV10cMetasIndicadoresValorMes)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV11cMetasIndicadoresTicketNro) )
         {
            AddWhere(sWhereString, "([MetasIndicadoresTicketNro] >= @AV11cMetasIndicadoresTicketNro)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12cMotivosMetasCodigo)) )
         {
            AddWhere(sWhereString, "([MotivosMetasCodigo] like @lV12cMotivosMetasCodigo)");
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
                     return conditional_H000H2(context, (decimal)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (decimal)dynConstraints[3] , (long)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] );
               case 1 :
                     return conditional_H000H3(context, (decimal)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (decimal)dynConstraints[3] , (long)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] );
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
          Object[] prmH000H2;
          prmH000H2 = new Object[] {
          new ParDef("@lV6cIndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@AV7cMetasIndicadoresMes",GXType.Int16,4,0) ,
          new ParDef("@AV8cMetasIndicadoresAno",GXType.Int16,4,0) ,
          new ParDef("@lV9cTipoMetasCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@AV10cMetasIndicadoresValorMes",GXType.Decimal,12,2) ,
          new ParDef("@AV11cMetasIndicadoresTicketNro",GXType.Decimal,10,0) ,
          new ParDef("@lV12cMotivosMetasCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH000H3;
          prmH000H3 = new Object[] {
          new ParDef("@lV6cIndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@AV7cMetasIndicadoresMes",GXType.Int16,4,0) ,
          new ParDef("@AV8cMetasIndicadoresAno",GXType.Int16,4,0) ,
          new ParDef("@lV9cTipoMetasCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@AV10cMetasIndicadoresValorMes",GXType.Decimal,12,2) ,
          new ParDef("@AV11cMetasIndicadoresTicketNro",GXType.Decimal,10,0) ,
          new ParDef("@lV12cMotivosMetasCodigo",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000H2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000H2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H000H3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000H3,1, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
