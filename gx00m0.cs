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
   public class gx00m0 : GXDataArea
   {
      public gx00m0( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("IndicadroresPalmas", true);
      }

      public gx00m0( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out DateTime aP0_pVentasFecha ,
                           out short aP1_pVentasMes ,
                           out short aP2_pVentasAno ,
                           out string aP3_pTipoProductoCod )
      {
         this.AV12pVentasFecha = DateTime.MinValue ;
         this.AV13pVentasMes = 0 ;
         this.AV14pVentasAno = 0 ;
         this.AV15pTipoProductoCod = "" ;
         executePrivate();
         aP0_pVentasFecha=this.AV12pVentasFecha;
         aP1_pVentasMes=this.AV13pVentasMes;
         aP2_pVentasAno=this.AV14pVentasAno;
         aP3_pTipoProductoCod=this.AV15pTipoProductoCod;
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
            gxfirstwebparm = GetFirstPar( "pVentasFecha");
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
               gxfirstwebparm = GetFirstPar( "pVentasFecha");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pVentasFecha");
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
               AV12pVentasFecha = context.localUtil.ParseDateParm( gxfirstwebparm);
               AssignAttri("", false, "AV12pVentasFecha", context.localUtil.Format(AV12pVentasFecha, "99/99/99"));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV13pVentasMes = (short)(Math.Round(NumberUtil.Val( GetPar( "pVentasMes"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13pVentasMes", StringUtil.LTrimStr( (decimal)(AV13pVentasMes), 4, 0));
                  AV14pVentasAno = (short)(Math.Round(NumberUtil.Val( GetPar( "pVentasAno"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV14pVentasAno", StringUtil.LTrimStr( (decimal)(AV14pVentasAno), 4, 0));
                  AV15pTipoProductoCod = GetPar( "pTipoProductoCod");
                  AssignAttri("", false, "AV15pTipoProductoCod", AV15pTipoProductoCod);
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
         AV6cVentasFecha = context.localUtil.ParseDateParm( GetPar( "cVentasFecha"));
         AV7cVentasMes = (short)(Math.Round(NumberUtil.Val( GetPar( "cVentasMes"), "."), 18, MidpointRounding.ToEven));
         AV8cVentasAno = (short)(Math.Round(NumberUtil.Val( GetPar( "cVentasAno"), "."), 18, MidpointRounding.ToEven));
         AV9cTipoProductoCod = GetPar( "cTipoProductoCod");
         AV10cVentasValor = NumberUtil.Val( GetPar( "cVentasValor"), ".");
         AV11cClientesCodigo = GetPar( "cClientesCodigo");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cVentasFecha, AV7cVentasMes, AV8cVentasAno, AV9cTipoProductoCod, AV10cVentasValor, AV11cClientesCodigo) ;
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
         PA0O2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0O2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx00m0.aspx", new object[] {UrlEncode(DateTimeUtil.FormatDateParm(AV12pVentasFecha)),UrlEncode(StringUtil.LTrimStr(AV13pVentasMes,4,0)),UrlEncode(StringUtil.LTrimStr(AV14pVentasAno,4,0)),UrlEncode(StringUtil.RTrim(AV15pTipoProductoCod))}, new string[] {"pVentasFecha","pVentasMes","pVentasAno","pTipoProductoCod"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCVENTASFECHA", context.localUtil.Format(AV6cVentasFecha, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vCVENTASMES", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cVentasMes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCVENTASANO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cVentasAno), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCTIPOPRODUCTOCOD", AV9cTipoProductoCod);
         GxWebStd.gx_hidden_field( context, "GXH_vCVENTASVALOR", StringUtil.LTrim( StringUtil.NToC( AV10cVentasValor, 14, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCLIENTESCODIGO", AV11cClientesCodigo);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_74", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_74), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPVENTASFECHA", context.localUtil.DToC( AV12pVentasFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vPVENTASMES", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pVentasMes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPVENTASANO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14pVentasAno), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPTIPOPRODUCTOCOD", AV15pTipoProductoCod);
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "VENTASFECHAFILTERCONTAINER_Class", StringUtil.RTrim( divVentasfechafiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "VENTASMESFILTERCONTAINER_Class", StringUtil.RTrim( divVentasmesfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "VENTASANOFILTERCONTAINER_Class", StringUtil.RTrim( divVentasanofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TIPOPRODUCTOCODFILTERCONTAINER_Class", StringUtil.RTrim( divTipoproductocodfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "VENTASVALORFILTERCONTAINER_Class", StringUtil.RTrim( divVentasvalorfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CLIENTESCODIGOFILTERCONTAINER_Class", StringUtil.RTrim( divClientescodigofiltercontainer_Class));
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
            WE0O2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0O2( ) ;
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
         return formatLink("gx00m0.aspx", new object[] {UrlEncode(DateTimeUtil.FormatDateParm(AV12pVentasFecha)),UrlEncode(StringUtil.LTrimStr(AV13pVentasMes,4,0)),UrlEncode(StringUtil.LTrimStr(AV14pVentasAno,4,0)),UrlEncode(StringUtil.RTrim(AV15pTipoProductoCod))}, new string[] {"pVentasFecha","pVentasMes","pVentasAno","pTipoProductoCod"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx00M0" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List Ventas" ;
      }

      protected void WB0O0( )
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
            GxWebStd.gx_div_start( context, divVentasfechafiltercontainer_Internalname, 1, 0, "px", 0, "px", divVentasfechafiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblventasfechafilter_Internalname, "Ventas Fecha", "", "", lblLblventasfechafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e110o1_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00M0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCventasfecha_Internalname, "Ventas Fecha", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_74_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCventasfecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCventasfecha_Internalname, context.localUtil.Format(AV6cVentasFecha, "99/99/99"), context.localUtil.Format( AV6cVentasFecha, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCventasfecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCventasfecha_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00M0.htm");
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
            GxWebStd.gx_div_start( context, divVentasmesfiltercontainer_Internalname, 1, 0, "px", 0, "px", divVentasmesfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblventasmesfilter_Internalname, "Ventas Mes", "", "", lblLblventasmesfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e120o1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00M0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCventasmes_Internalname, "Ventas Mes", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCventasmes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cVentasMes), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCventasmes_Enabled!=0) ? context.localUtil.Format( (decimal)(AV7cVentasMes), "ZZZ9") : context.localUtil.Format( (decimal)(AV7cVentasMes), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCventasmes_Jsonclick, 0, "Attribute", "", "", "", "", edtavCventasmes_Visible, edtavCventasmes_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00M0.htm");
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
            GxWebStd.gx_div_start( context, divVentasanofiltercontainer_Internalname, 1, 0, "px", 0, "px", divVentasanofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblventasanofilter_Internalname, "Ventas Ano", "", "", lblLblventasanofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e130o1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00M0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCventasano_Internalname, "Ventas Ano", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCventasano_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cVentasAno), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCventasano_Enabled!=0) ? context.localUtil.Format( (decimal)(AV8cVentasAno), "ZZZ9") : context.localUtil.Format( (decimal)(AV8cVentasAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCventasano_Jsonclick, 0, "Attribute", "", "", "", "", edtavCventasano_Visible, edtavCventasano_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00M0.htm");
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
            GxWebStd.gx_label_ctrl( context, lblLbltipoproductocodfilter_Internalname, "Tipo Producto Cod", "", "", lblLbltipoproductocodfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e140o1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00M0.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtipoproductocod_Internalname, AV9cTipoProductoCod, StringUtil.RTrim( context.localUtil.Format( AV9cTipoProductoCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtipoproductocod_Jsonclick, 0, "Attribute", "", "", "", "", edtavCtipoproductocod_Visible, edtavCtipoproductocod_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Gx00M0.htm");
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
            GxWebStd.gx_div_start( context, divVentasvalorfiltercontainer_Internalname, 1, 0, "px", 0, "px", divVentasvalorfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblventasvalorfilter_Internalname, "Ventas Valor", "", "", lblLblventasvalorfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e150o1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00M0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCventasvalor_Internalname, "Ventas Valor", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCventasvalor_Internalname, StringUtil.LTrim( StringUtil.NToC( AV10cVentasValor, 14, 2, ",", "")), StringUtil.LTrim( ((edtavCventasvalor_Enabled!=0) ? context.localUtil.Format( AV10cVentasValor, "ZZZZZZZZZZ9.99") : context.localUtil.Format( AV10cVentasValor, "ZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCventasvalor_Jsonclick, 0, "Attribute", "", "", "", "", edtavCventasvalor_Visible, edtavCventasvalor_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00M0.htm");
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
            GxWebStd.gx_div_start( context, divClientescodigofiltercontainer_Internalname, 1, 0, "px", 0, "px", divClientescodigofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblclientescodigofilter_Internalname, "Clientes Codigo", "", "", lblLblclientescodigofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e160o1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00M0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCclientescodigo_Internalname, "Clientes Codigo", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCclientescodigo_Internalname, AV11cClientesCodigo, StringUtil.RTrim( context.localUtil.Format( AV11cClientesCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCclientescodigo_Jsonclick, 0, "Attribute", "", "", "", "", edtavCclientescodigo_Visible, edtavCclientescodigo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Gx00M0.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e170o1_client"+"'", TempTags, "", 2, "HLP_Gx00M0.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx00M0.htm");
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

      protected void START0O2( )
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
            Form.Meta.addItem("description", "Selection List Ventas", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0O0( ) ;
      }

      protected void WS0O2( )
      {
         START0O2( ) ;
         EVT0O2( ) ;
      }

      protected void EVT0O2( )
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
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV19Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_74_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A46VentasFecha = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtVentasFecha_Internalname), 0));
                              A47VentasMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtVentasMes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A48VentasAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtVentasAno_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A45TipoProductoCod = cgiGet( edtTipoProductoCod_Internalname);
                              A160VentasValor = context.localUtil.CToN( cgiGet( edtVentasValor_Internalname), ",", ".");
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E180O2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E190O2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cventasfecha Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCVENTASFECHA"), 0) != AV6cVentasFecha )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cventasmes Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCVENTASMES"), ",", ".") != Convert.ToDecimal( AV7cVentasMes )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cventasano Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCVENTASANO"), ",", ".") != Convert.ToDecimal( AV8cVentasAno )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ctipoproductocod Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCTIPOPRODUCTOCOD"), AV9cTipoProductoCod) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cventasvalor Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCVENTASVALOR"), ",", ".") != AV10cVentasValor )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cclientescodigo Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCCLIENTESCODIGO"), AV11cClientesCodigo) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E200O2 ();
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

      protected void WE0O2( )
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

      protected void PA0O2( )
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
                                        DateTime AV6cVentasFecha ,
                                        short AV7cVentasMes ,
                                        short AV8cVentasAno ,
                                        string AV9cTipoProductoCod ,
                                        decimal AV10cVentasValor ,
                                        string AV11cClientesCodigo )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF0O2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_VENTASFECHA", GetSecureSignedToken( "", A46VentasFecha, context));
         GxWebStd.gx_hidden_field( context, "VENTASFECHA", context.localUtil.Format(A46VentasFecha, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "gxhash_VENTASMES", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A47VentasMes), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "VENTASMES", StringUtil.LTrim( StringUtil.NToC( (decimal)(A47VentasMes), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_VENTASANO", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A48VentasAno), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "VENTASANO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A48VentasAno), 4, 0, ".", "")));
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
         RF0O2( ) ;
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

      protected void RF0O2( )
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
                                                 AV10cVentasValor ,
                                                 AV11cClientesCodigo ,
                                                 A160VentasValor ,
                                                 A49ClientesCodigo ,
                                                 A45TipoProductoCod ,
                                                 AV9cTipoProductoCod ,
                                                 AV6cVentasFecha ,
                                                 AV7cVentasMes ,
                                                 AV8cVentasAno } ,
                                                 new int[]{
                                                 TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            lV9cTipoProductoCod = StringUtil.Concat( StringUtil.RTrim( AV9cTipoProductoCod), "%", "");
            lV11cClientesCodigo = StringUtil.Concat( StringUtil.RTrim( AV11cClientesCodigo), "%", "");
            /* Using cursor H000O2 */
            pr_default.execute(0, new Object[] {AV6cVentasFecha, AV7cVentasMes, AV8cVentasAno, lV9cTipoProductoCod, AV10cVentasValor, lV11cClientesCodigo, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_74_idx = 1;
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A49ClientesCodigo = H000O2_A49ClientesCodigo[0];
               A160VentasValor = H000O2_A160VentasValor[0];
               A45TipoProductoCod = H000O2_A45TipoProductoCod[0];
               A48VentasAno = H000O2_A48VentasAno[0];
               A47VentasMes = H000O2_A47VentasMes[0];
               A46VentasFecha = H000O2_A46VentasFecha[0];
               /* Execute user event: Load */
               E190O2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 74;
            WB0O0( ) ;
         }
         bGXsfl_74_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0O2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_VENTASFECHA"+"_"+sGXsfl_74_idx, GetSecureSignedToken( sGXsfl_74_idx, A46VentasFecha, context));
         GxWebStd.gx_hidden_field( context, "gxhash_VENTASMES"+"_"+sGXsfl_74_idx, GetSecureSignedToken( sGXsfl_74_idx, context.localUtil.Format( (decimal)(A47VentasMes), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_VENTASANO"+"_"+sGXsfl_74_idx, GetSecureSignedToken( sGXsfl_74_idx, context.localUtil.Format( (decimal)(A48VentasAno), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TIPOPRODUCTOCOD"+"_"+sGXsfl_74_idx, GetSecureSignedToken( sGXsfl_74_idx, StringUtil.RTrim( context.localUtil.Format( A45TipoProductoCod, "")), context));
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
                                              AV10cVentasValor ,
                                              AV11cClientesCodigo ,
                                              A160VentasValor ,
                                              A49ClientesCodigo ,
                                              A45TipoProductoCod ,
                                              AV9cTipoProductoCod ,
                                              AV6cVentasFecha ,
                                              AV7cVentasMes ,
                                              AV8cVentasAno } ,
                                              new int[]{
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV9cTipoProductoCod = StringUtil.Concat( StringUtil.RTrim( AV9cTipoProductoCod), "%", "");
         lV11cClientesCodigo = StringUtil.Concat( StringUtil.RTrim( AV11cClientesCodigo), "%", "");
         /* Using cursor H000O3 */
         pr_default.execute(1, new Object[] {AV6cVentasFecha, AV7cVentasMes, AV8cVentasAno, lV9cTipoProductoCod, AV10cVentasValor, lV11cClientesCodigo});
         GRID1_nRecordCount = H000O3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cVentasFecha, AV7cVentasMes, AV8cVentasAno, AV9cTipoProductoCod, AV10cVentasValor, AV11cClientesCodigo) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cVentasFecha, AV7cVentasMes, AV8cVentasAno, AV9cTipoProductoCod, AV10cVentasValor, AV11cClientesCodigo) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cVentasFecha, AV7cVentasMes, AV8cVentasAno, AV9cTipoProductoCod, AV10cVentasValor, AV11cClientesCodigo) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cVentasFecha, AV7cVentasMes, AV8cVentasAno, AV9cTipoProductoCod, AV10cVentasValor, AV11cClientesCodigo) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cVentasFecha, AV7cVentasMes, AV8cVentasAno, AV9cTipoProductoCod, AV10cVentasValor, AV11cClientesCodigo) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0O0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E180O2 ();
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
            if ( context.localUtil.VCDate( cgiGet( edtavCventasfecha_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Ventas Fecha"}), 1, "vCVENTASFECHA");
               GX_FocusControl = edtavCventasfecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cVentasFecha = DateTime.MinValue;
               AssignAttri("", false, "AV6cVentasFecha", context.localUtil.Format(AV6cVentasFecha, "99/99/99"));
            }
            else
            {
               AV6cVentasFecha = context.localUtil.CToD( cgiGet( edtavCventasfecha_Internalname), 2);
               AssignAttri("", false, "AV6cVentasFecha", context.localUtil.Format(AV6cVentasFecha, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCventasmes_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCventasmes_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCVENTASMES");
               GX_FocusControl = edtavCventasmes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7cVentasMes = 0;
               AssignAttri("", false, "AV7cVentasMes", StringUtil.LTrimStr( (decimal)(AV7cVentasMes), 4, 0));
            }
            else
            {
               AV7cVentasMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCventasmes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7cVentasMes", StringUtil.LTrimStr( (decimal)(AV7cVentasMes), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCventasano_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCventasano_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCVENTASANO");
               GX_FocusControl = edtavCventasano_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cVentasAno = 0;
               AssignAttri("", false, "AV8cVentasAno", StringUtil.LTrimStr( (decimal)(AV8cVentasAno), 4, 0));
            }
            else
            {
               AV8cVentasAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCventasano_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV8cVentasAno", StringUtil.LTrimStr( (decimal)(AV8cVentasAno), 4, 0));
            }
            AV9cTipoProductoCod = cgiGet( edtavCtipoproductocod_Internalname);
            AssignAttri("", false, "AV9cTipoProductoCod", AV9cTipoProductoCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCventasvalor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCventasvalor_Internalname), ",", ".") > 99999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCVENTASVALOR");
               GX_FocusControl = edtavCventasvalor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cVentasValor = 0;
               AssignAttri("", false, "AV10cVentasValor", StringUtil.LTrimStr( AV10cVentasValor, 14, 2));
            }
            else
            {
               AV10cVentasValor = context.localUtil.CToN( cgiGet( edtavCventasvalor_Internalname), ",", ".");
               AssignAttri("", false, "AV10cVentasValor", StringUtil.LTrimStr( AV10cVentasValor, 14, 2));
            }
            AV11cClientesCodigo = cgiGet( edtavCclientescodigo_Internalname);
            AssignAttri("", false, "AV11cClientesCodigo", AV11cClientesCodigo);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vCVENTASFECHA"), 2) ) != DateTimeUtil.ResetTime ( AV6cVentasFecha ) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCVENTASMES"), ",", ".") != Convert.ToDecimal( AV7cVentasMes )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCVENTASANO"), ",", ".") != Convert.ToDecimal( AV8cVentasAno )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCTIPOPRODUCTOCOD"), AV9cTipoProductoCod) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vCVENTASVALOR"), ",", ".") != AV10cVentasValor )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCCLIENTESCODIGO"), AV11cClientesCodigo) != 0 )
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
         E180O2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E180O2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Lista de Selección %1", "Ventas", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV16ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E190O2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "selectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV19Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )));
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
         E200O2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E200O2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV12pVentasFecha = A46VentasFecha;
         AssignAttri("", false, "AV12pVentasFecha", context.localUtil.Format(AV12pVentasFecha, "99/99/99"));
         AV13pVentasMes = A47VentasMes;
         AssignAttri("", false, "AV13pVentasMes", StringUtil.LTrimStr( (decimal)(AV13pVentasMes), 4, 0));
         AV14pVentasAno = A48VentasAno;
         AssignAttri("", false, "AV14pVentasAno", StringUtil.LTrimStr( (decimal)(AV14pVentasAno), 4, 0));
         AV15pTipoProductoCod = A45TipoProductoCod;
         AssignAttri("", false, "AV15pTipoProductoCod", AV15pTipoProductoCod);
         context.setWebReturnParms(new Object[] {context.localUtil.Format( AV12pVentasFecha, "99/99/99"),(short)AV13pVentasMes,(short)AV14pVentasAno,(string)AV15pTipoProductoCod});
         context.setWebReturnParmsMetadata(new Object[] {"AV12pVentasFecha","AV13pVentasMes","AV14pVentasAno","AV15pTipoProductoCod"});
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
         AV12pVentasFecha = (DateTime)getParm(obj,0);
         AssignAttri("", false, "AV12pVentasFecha", context.localUtil.Format(AV12pVentasFecha, "99/99/99"));
         AV13pVentasMes = Convert.ToInt16(getParm(obj,1));
         AssignAttri("", false, "AV13pVentasMes", StringUtil.LTrimStr( (decimal)(AV13pVentasMes), 4, 0));
         AV14pVentasAno = Convert.ToInt16(getParm(obj,2));
         AssignAttri("", false, "AV14pVentasAno", StringUtil.LTrimStr( (decimal)(AV14pVentasAno), 4, 0));
         AV15pTipoProductoCod = (string)getParm(obj,3);
         AssignAttri("", false, "AV15pTipoProductoCod", AV15pTipoProductoCod);
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
         PA0O2( ) ;
         WS0O2( ) ;
         WE0O2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024723102317", true, true);
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
         context.AddJavascriptSource("gx00m0.js", "?2024723102318", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_idx;
         edtVentasFecha_Internalname = "VENTASFECHA_"+sGXsfl_74_idx;
         edtVentasMes_Internalname = "VENTASMES_"+sGXsfl_74_idx;
         edtVentasAno_Internalname = "VENTASANO_"+sGXsfl_74_idx;
         edtTipoProductoCod_Internalname = "TIPOPRODUCTOCOD_"+sGXsfl_74_idx;
         edtVentasValor_Internalname = "VENTASVALOR_"+sGXsfl_74_idx;
      }

      protected void SubsflControlProps_fel_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_fel_idx;
         edtVentasFecha_Internalname = "VENTASFECHA_"+sGXsfl_74_fel_idx;
         edtVentasMes_Internalname = "VENTASMES_"+sGXsfl_74_fel_idx;
         edtVentasAno_Internalname = "VENTASANO_"+sGXsfl_74_fel_idx;
         edtTipoProductoCod_Internalname = "TIPOPRODUCTOCOD_"+sGXsfl_74_fel_idx;
         edtVentasValor_Internalname = "VENTASVALOR_"+sGXsfl_74_fel_idx;
      }

      protected void sendrow_742( )
      {
         SubsflControlProps_742( ) ;
         WB0O0( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( context.localUtil.Format(A46VentasFecha, "99/99/99"))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A47VentasMes), 4, 0, ",", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A48VentasAno), 4, 0, ",", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( A45TipoProductoCod)+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_74_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV19Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV19Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtVentasFecha_Internalname,context.localUtil.Format(A46VentasFecha, "99/99/99"),context.localUtil.Format( A46VentasFecha, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtVentasFecha_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtVentasMes_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A47VentasMes), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A47VentasMes), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtVentasMes_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtVentasAno_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A48VentasAno), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A48VentasAno), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtVentasAno_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipoProductoCod_Internalname,(string)A45TipoProductoCod,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTipoProductoCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtVentasValor_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( context.localUtil.Format(A46VentasFecha, "99/99/99"))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A47VentasMes), 4, 0, ",", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A48VentasAno), 4, 0, ",", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( A45TipoProductoCod)+"'"+"]);";
            AssignProp("", false, edtVentasValor_Internalname, "Link", edtVentasValor_Link, !bGXsfl_74_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtVentasValor_Internalname,StringUtil.LTrim( StringUtil.NToC( A160VentasValor, 14, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A160VentasValor, "ZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtVentasValor_Link,(string)"",(string)"",(string)"",(string)edtVentasValor_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes0O2( ) ;
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
            context.SendWebValue( "Fecha") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Mes") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Ano") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Tipo Producto Cod") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Valor") ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A46VentasFecha, "99/99/99")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A47VentasMes), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A48VentasAno), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A45TipoProductoCod));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A160VentasValor, 14, 2, ".", ""))));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtVentasValor_Link));
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
         lblLblventasfechafilter_Internalname = "LBLVENTASFECHAFILTER";
         edtavCventasfecha_Internalname = "vCVENTASFECHA";
         divVentasfechafiltercontainer_Internalname = "VENTASFECHAFILTERCONTAINER";
         lblLblventasmesfilter_Internalname = "LBLVENTASMESFILTER";
         edtavCventasmes_Internalname = "vCVENTASMES";
         divVentasmesfiltercontainer_Internalname = "VENTASMESFILTERCONTAINER";
         lblLblventasanofilter_Internalname = "LBLVENTASANOFILTER";
         edtavCventasano_Internalname = "vCVENTASANO";
         divVentasanofiltercontainer_Internalname = "VENTASANOFILTERCONTAINER";
         lblLbltipoproductocodfilter_Internalname = "LBLTIPOPRODUCTOCODFILTER";
         edtavCtipoproductocod_Internalname = "vCTIPOPRODUCTOCOD";
         divTipoproductocodfiltercontainer_Internalname = "TIPOPRODUCTOCODFILTERCONTAINER";
         lblLblventasvalorfilter_Internalname = "LBLVENTASVALORFILTER";
         edtavCventasvalor_Internalname = "vCVENTASVALOR";
         divVentasvalorfiltercontainer_Internalname = "VENTASVALORFILTERCONTAINER";
         lblLblclientescodigofilter_Internalname = "LBLCLIENTESCODIGOFILTER";
         edtavCclientescodigo_Internalname = "vCCLIENTESCODIGO";
         divClientescodigofiltercontainer_Internalname = "CLIENTESCODIGOFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtVentasFecha_Internalname = "VENTASFECHA";
         edtVentasMes_Internalname = "VENTASMES";
         edtVentasAno_Internalname = "VENTASANO";
         edtTipoProductoCod_Internalname = "TIPOPRODUCTOCOD";
         edtVentasValor_Internalname = "VENTASVALOR";
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
         edtVentasValor_Jsonclick = "";
         edtVentasValor_Link = "";
         edtTipoProductoCod_Jsonclick = "";
         edtVentasAno_Jsonclick = "";
         edtVentasMes_Jsonclick = "";
         edtVentasFecha_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtavCclientescodigo_Jsonclick = "";
         edtavCclientescodigo_Enabled = 1;
         edtavCclientescodigo_Visible = 1;
         edtavCventasvalor_Jsonclick = "";
         edtavCventasvalor_Enabled = 1;
         edtavCventasvalor_Visible = 1;
         edtavCtipoproductocod_Jsonclick = "";
         edtavCtipoproductocod_Enabled = 1;
         edtavCtipoproductocod_Visible = 1;
         edtavCventasano_Jsonclick = "";
         edtavCventasano_Enabled = 1;
         edtavCventasano_Visible = 1;
         edtavCventasmes_Jsonclick = "";
         edtavCventasmes_Enabled = 1;
         edtavCventasmes_Visible = 1;
         edtavCventasfecha_Jsonclick = "";
         edtavCventasfecha_Enabled = 1;
         divClientescodigofiltercontainer_Class = "AdvancedContainerItem";
         divVentasvalorfiltercontainer_Class = "AdvancedContainerItem";
         divTipoproductocodfiltercontainer_Class = "AdvancedContainerItem";
         divVentasanofiltercontainer_Class = "AdvancedContainerItem";
         divVentasmesfiltercontainer_Class = "AdvancedContainerItem";
         divVentasfechafiltercontainer_Class = "AdvancedContainerItem";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List Ventas";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cVentasFecha',fld:'vCVENTASFECHA',pic:''},{av:'AV7cVentasMes',fld:'vCVENTASMES',pic:'ZZZ9'},{av:'AV8cVentasAno',fld:'vCVENTASANO',pic:'ZZZ9'},{av:'AV9cTipoProductoCod',fld:'vCTIPOPRODUCTOCOD',pic:''},{av:'AV10cVentasValor',fld:'vCVENTASVALOR',pic:'ZZZZZZZZZZ9.99'},{av:'AV11cClientesCodigo',fld:'vCCLIENTESCODIGO',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E170O1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLVENTASFECHAFILTER.CLICK","{handler:'E110O1',iparms:[{av:'divVentasfechafiltercontainer_Class',ctrl:'VENTASFECHAFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLVENTASFECHAFILTER.CLICK",",oparms:[{av:'divVentasfechafiltercontainer_Class',ctrl:'VENTASFECHAFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLVENTASMESFILTER.CLICK","{handler:'E120O1',iparms:[{av:'divVentasmesfiltercontainer_Class',ctrl:'VENTASMESFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLVENTASMESFILTER.CLICK",",oparms:[{av:'divVentasmesfiltercontainer_Class',ctrl:'VENTASMESFILTERCONTAINER',prop:'Class'},{av:'edtavCventasmes_Visible',ctrl:'vCVENTASMES',prop:'Visible'}]}");
         setEventMetadata("LBLVENTASANOFILTER.CLICK","{handler:'E130O1',iparms:[{av:'divVentasanofiltercontainer_Class',ctrl:'VENTASANOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLVENTASANOFILTER.CLICK",",oparms:[{av:'divVentasanofiltercontainer_Class',ctrl:'VENTASANOFILTERCONTAINER',prop:'Class'},{av:'edtavCventasano_Visible',ctrl:'vCVENTASANO',prop:'Visible'}]}");
         setEventMetadata("LBLTIPOPRODUCTOCODFILTER.CLICK","{handler:'E140O1',iparms:[{av:'divTipoproductocodfiltercontainer_Class',ctrl:'TIPOPRODUCTOCODFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTIPOPRODUCTOCODFILTER.CLICK",",oparms:[{av:'divTipoproductocodfiltercontainer_Class',ctrl:'TIPOPRODUCTOCODFILTERCONTAINER',prop:'Class'},{av:'edtavCtipoproductocod_Visible',ctrl:'vCTIPOPRODUCTOCOD',prop:'Visible'}]}");
         setEventMetadata("LBLVENTASVALORFILTER.CLICK","{handler:'E150O1',iparms:[{av:'divVentasvalorfiltercontainer_Class',ctrl:'VENTASVALORFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLVENTASVALORFILTER.CLICK",",oparms:[{av:'divVentasvalorfiltercontainer_Class',ctrl:'VENTASVALORFILTERCONTAINER',prop:'Class'},{av:'edtavCventasvalor_Visible',ctrl:'vCVENTASVALOR',prop:'Visible'}]}");
         setEventMetadata("LBLCLIENTESCODIGOFILTER.CLICK","{handler:'E160O1',iparms:[{av:'divClientescodigofiltercontainer_Class',ctrl:'CLIENTESCODIGOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCLIENTESCODIGOFILTER.CLICK",",oparms:[{av:'divClientescodigofiltercontainer_Class',ctrl:'CLIENTESCODIGOFILTERCONTAINER',prop:'Class'},{av:'edtavCclientescodigo_Visible',ctrl:'vCCLIENTESCODIGO',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E200O2',iparms:[{av:'A46VentasFecha',fld:'VENTASFECHA',pic:'',hsh:true},{av:'A47VentasMes',fld:'VENTASMES',pic:'ZZZ9',hsh:true},{av:'A48VentasAno',fld:'VENTASANO',pic:'ZZZ9',hsh:true},{av:'A45TipoProductoCod',fld:'TIPOPRODUCTOCOD',pic:'',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV12pVentasFecha',fld:'vPVENTASFECHA',pic:''},{av:'AV13pVentasMes',fld:'vPVENTASMES',pic:'ZZZ9'},{av:'AV14pVentasAno',fld:'vPVENTASANO',pic:'ZZZ9'},{av:'AV15pTipoProductoCod',fld:'vPTIPOPRODUCTOCOD',pic:''}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cVentasFecha',fld:'vCVENTASFECHA',pic:''},{av:'AV7cVentasMes',fld:'vCVENTASMES',pic:'ZZZ9'},{av:'AV8cVentasAno',fld:'vCVENTASANO',pic:'ZZZ9'},{av:'AV9cTipoProductoCod',fld:'vCTIPOPRODUCTOCOD',pic:''},{av:'AV10cVentasValor',fld:'vCVENTASVALOR',pic:'ZZZZZZZZZZ9.99'},{av:'AV11cClientesCodigo',fld:'vCCLIENTESCODIGO',pic:''}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cVentasFecha',fld:'vCVENTASFECHA',pic:''},{av:'AV7cVentasMes',fld:'vCVENTASMES',pic:'ZZZ9'},{av:'AV8cVentasAno',fld:'vCVENTASANO',pic:'ZZZ9'},{av:'AV9cTipoProductoCod',fld:'vCTIPOPRODUCTOCOD',pic:''},{av:'AV10cVentasValor',fld:'vCVENTASVALOR',pic:'ZZZZZZZZZZ9.99'},{av:'AV11cClientesCodigo',fld:'vCCLIENTESCODIGO',pic:''}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cVentasFecha',fld:'vCVENTASFECHA',pic:''},{av:'AV7cVentasMes',fld:'vCVENTASMES',pic:'ZZZ9'},{av:'AV8cVentasAno',fld:'vCVENTASANO',pic:'ZZZ9'},{av:'AV9cTipoProductoCod',fld:'vCTIPOPRODUCTOCOD',pic:''},{av:'AV10cVentasValor',fld:'vCVENTASVALOR',pic:'ZZZZZZZZZZ9.99'},{av:'AV11cClientesCodigo',fld:'vCCLIENTESCODIGO',pic:''}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cVentasFecha',fld:'vCVENTASFECHA',pic:''},{av:'AV7cVentasMes',fld:'vCVENTASMES',pic:'ZZZ9'},{av:'AV8cVentasAno',fld:'vCVENTASANO',pic:'ZZZ9'},{av:'AV9cTipoProductoCod',fld:'vCTIPOPRODUCTOCOD',pic:''},{av:'AV10cVentasValor',fld:'vCVENTASVALOR',pic:'ZZZZZZZZZZ9.99'},{av:'AV11cClientesCodigo',fld:'vCCLIENTESCODIGO',pic:''}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CVENTASFECHA","{handler:'Validv_Cventasfecha',iparms:[]");
         setEventMetadata("VALIDV_CVENTASFECHA",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Ventasvalor',iparms:[]");
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
         AV12pVentasFecha = DateTime.MinValue;
         AV15pTipoProductoCod = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV6cVentasFecha = DateTime.MinValue;
         AV9cTipoProductoCod = "";
         AV11cClientesCodigo = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblventasfechafilter_Jsonclick = "";
         TempTags = "";
         lblLblventasmesfilter_Jsonclick = "";
         lblLblventasanofilter_Jsonclick = "";
         lblLbltipoproductocodfilter_Jsonclick = "";
         lblLblventasvalorfilter_Jsonclick = "";
         lblLblclientescodigofilter_Jsonclick = "";
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
         AV19Linkselection_GXI = "";
         A46VentasFecha = DateTime.MinValue;
         A45TipoProductoCod = "";
         scmdbuf = "";
         lV9cTipoProductoCod = "";
         lV11cClientesCodigo = "";
         A49ClientesCodigo = "";
         H000O2_A49ClientesCodigo = new string[] {""} ;
         H000O2_A160VentasValor = new decimal[1] ;
         H000O2_A45TipoProductoCod = new string[] {""} ;
         H000O2_A48VentasAno = new short[1] ;
         H000O2_A47VentasMes = new short[1] ;
         H000O2_A46VentasFecha = new DateTime[] {DateTime.MinValue} ;
         H000O3_AGRID1_nRecordCount = new long[1] ;
         AV16ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx00m0__default(),
            new Object[][] {
                new Object[] {
               H000O2_A49ClientesCodigo, H000O2_A160VentasValor, H000O2_A45TipoProductoCod, H000O2_A48VentasAno, H000O2_A47VentasMes, H000O2_A46VentasFecha
               }
               , new Object[] {
               H000O3_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV13pVentasMes ;
      private short AV14pVentasAno ;
      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV7cVentasMes ;
      private short AV8cVentasAno ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A47VentasMes ;
      private short A48VentasAno ;
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
      private int edtavCventasfecha_Enabled ;
      private int edtavCventasmes_Enabled ;
      private int edtavCventasmes_Visible ;
      private int edtavCventasano_Enabled ;
      private int edtavCventasano_Visible ;
      private int edtavCtipoproductocod_Visible ;
      private int edtavCtipoproductocod_Enabled ;
      private int edtavCventasvalor_Enabled ;
      private int edtavCventasvalor_Visible ;
      private int edtavCclientescodigo_Visible ;
      private int edtavCclientescodigo_Enabled ;
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
      private decimal AV10cVentasValor ;
      private decimal A160VentasValor ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divVentasfechafiltercontainer_Class ;
      private string divVentasmesfiltercontainer_Class ;
      private string divVentasanofiltercontainer_Class ;
      private string divTipoproductocodfiltercontainer_Class ;
      private string divVentasvalorfiltercontainer_Class ;
      private string divClientescodigofiltercontainer_Class ;
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
      private string divVentasfechafiltercontainer_Internalname ;
      private string lblLblventasfechafilter_Internalname ;
      private string lblLblventasfechafilter_Jsonclick ;
      private string edtavCventasfecha_Internalname ;
      private string TempTags ;
      private string edtavCventasfecha_Jsonclick ;
      private string divVentasmesfiltercontainer_Internalname ;
      private string lblLblventasmesfilter_Internalname ;
      private string lblLblventasmesfilter_Jsonclick ;
      private string edtavCventasmes_Internalname ;
      private string edtavCventasmes_Jsonclick ;
      private string divVentasanofiltercontainer_Internalname ;
      private string lblLblventasanofilter_Internalname ;
      private string lblLblventasanofilter_Jsonclick ;
      private string edtavCventasano_Internalname ;
      private string edtavCventasano_Jsonclick ;
      private string divTipoproductocodfiltercontainer_Internalname ;
      private string lblLbltipoproductocodfilter_Internalname ;
      private string lblLbltipoproductocodfilter_Jsonclick ;
      private string edtavCtipoproductocod_Internalname ;
      private string edtavCtipoproductocod_Jsonclick ;
      private string divVentasvalorfiltercontainer_Internalname ;
      private string lblLblventasvalorfilter_Internalname ;
      private string lblLblventasvalorfilter_Jsonclick ;
      private string edtavCventasvalor_Internalname ;
      private string edtavCventasvalor_Jsonclick ;
      private string divClientescodigofiltercontainer_Internalname ;
      private string lblLblclientescodigofilter_Internalname ;
      private string lblLblclientescodigofilter_Jsonclick ;
      private string edtavCclientescodigo_Internalname ;
      private string edtavCclientescodigo_Jsonclick ;
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
      private string edtVentasFecha_Internalname ;
      private string edtVentasMes_Internalname ;
      private string edtVentasAno_Internalname ;
      private string edtTipoProductoCod_Internalname ;
      private string edtVentasValor_Internalname ;
      private string scmdbuf ;
      private string AV16ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_74_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtVentasFecha_Jsonclick ;
      private string edtVentasMes_Jsonclick ;
      private string edtVentasAno_Jsonclick ;
      private string edtTipoProductoCod_Jsonclick ;
      private string edtVentasValor_Link ;
      private string edtVentasValor_Jsonclick ;
      private string subGrid1_Header ;
      private DateTime AV12pVentasFecha ;
      private DateTime AV6cVentasFecha ;
      private DateTime A46VentasFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_74_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV15pTipoProductoCod ;
      private string AV9cTipoProductoCod ;
      private string AV11cClientesCodigo ;
      private string AV19Linkselection_GXI ;
      private string A45TipoProductoCod ;
      private string lV9cTipoProductoCod ;
      private string lV11cClientesCodigo ;
      private string A49ClientesCodigo ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] H000O2_A49ClientesCodigo ;
      private decimal[] H000O2_A160VentasValor ;
      private string[] H000O2_A45TipoProductoCod ;
      private short[] H000O2_A48VentasAno ;
      private short[] H000O2_A47VentasMes ;
      private DateTime[] H000O2_A46VentasFecha ;
      private long[] H000O3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private DateTime aP0_pVentasFecha ;
      private short aP1_pVentasMes ;
      private short aP2_pVentasAno ;
      private string aP3_pTipoProductoCod ;
      private GXWebForm Form ;
   }

   public class gx00m0__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H000O2( IGxContext context ,
                                             decimal AV10cVentasValor ,
                                             string AV11cClientesCodigo ,
                                             decimal A160VentasValor ,
                                             string A49ClientesCodigo ,
                                             string A45TipoProductoCod ,
                                             string AV9cTipoProductoCod ,
                                             DateTime AV6cVentasFecha ,
                                             short AV7cVentasMes ,
                                             short AV8cVentasAno )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[9];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [ClientesCodigo], [VentasValor], [TipoProductoCod], [VentasAno], [VentasMes], [VentasFecha]";
         sFromString = " FROM [Ventas]";
         sOrderString = "";
         AddWhere(sWhereString, "([VentasFecha] >= @AV6cVentasFecha and [VentasMes] >= @AV7cVentasMes and [VentasAno] >= @AV8cVentasAno)");
         AddWhere(sWhereString, "([TipoProductoCod] like @lV9cTipoProductoCod)");
         if ( ! (Convert.ToDecimal(0)==AV10cVentasValor) )
         {
            AddWhere(sWhereString, "([VentasValor] >= @AV10cVentasValor)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11cClientesCodigo)) )
         {
            AddWhere(sWhereString, "([ClientesCodigo] like @lV11cClientesCodigo)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         sOrderString += " ORDER BY [VentasFecha], [VentasMes], [VentasAno], [TipoProductoCod]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H000O3( IGxContext context ,
                                             decimal AV10cVentasValor ,
                                             string AV11cClientesCodigo ,
                                             decimal A160VentasValor ,
                                             string A49ClientesCodigo ,
                                             string A45TipoProductoCod ,
                                             string AV9cTipoProductoCod ,
                                             DateTime AV6cVentasFecha ,
                                             short AV7cVentasMes ,
                                             short AV8cVentasAno )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [Ventas]";
         AddWhere(sWhereString, "([VentasFecha] >= @AV6cVentasFecha and [VentasMes] >= @AV7cVentasMes and [VentasAno] >= @AV8cVentasAno)");
         AddWhere(sWhereString, "([TipoProductoCod] like @lV9cTipoProductoCod)");
         if ( ! (Convert.ToDecimal(0)==AV10cVentasValor) )
         {
            AddWhere(sWhereString, "([VentasValor] >= @AV10cVentasValor)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11cClientesCodigo)) )
         {
            AddWhere(sWhereString, "([ClientesCodigo] like @lV11cClientesCodigo)");
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
                     return conditional_H000O2(context, (decimal)dynConstraints[0] , (string)dynConstraints[1] , (decimal)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (DateTime)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] );
               case 1 :
                     return conditional_H000O3(context, (decimal)dynConstraints[0] , (string)dynConstraints[1] , (decimal)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (DateTime)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] );
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
          Object[] prmH000O2;
          prmH000O2 = new Object[] {
          new ParDef("@AV6cVentasFecha",GXType.Date,8,0) ,
          new ParDef("@AV7cVentasMes",GXType.Int16,4,0) ,
          new ParDef("@AV8cVentasAno",GXType.Int16,4,0) ,
          new ParDef("@lV9cTipoProductoCod",GXType.NVarChar,40,0) ,
          new ParDef("@AV10cVentasValor",GXType.Decimal,14,2) ,
          new ParDef("@lV11cClientesCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH000O3;
          prmH000O3 = new Object[] {
          new ParDef("@AV6cVentasFecha",GXType.Date,8,0) ,
          new ParDef("@AV7cVentasMes",GXType.Int16,4,0) ,
          new ParDef("@AV8cVentasAno",GXType.Int16,4,0) ,
          new ParDef("@lV9cTipoProductoCod",GXType.NVarChar,40,0) ,
          new ParDef("@AV10cVentasValor",GXType.Decimal,14,2) ,
          new ParDef("@lV11cClientesCodigo",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000O2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000O2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H000O3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000O3,1, GxCacheFrequency.OFF ,false,false )
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
