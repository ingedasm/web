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
   public class gx0160 : GXDataArea
   {
      public gx0160( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("IndicadroresPalmas", true);
      }

      public gx0160( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out DateTime aP0_pRFF_COMPRADAFecha ,
                           out string aP1_pCod_Area ,
                           out string aP2_pIndicadoresCodigo ,
                           out short aP3_pRFF_COMPRADAMes ,
                           out short aP4_pRFF_COMPRADAAno ,
                           out string aP5_pRFF_COMPRAPRODUCUP )
      {
         this.AV13pRFF_COMPRADAFecha = DateTime.MinValue ;
         this.AV14pCod_Area = "" ;
         this.AV15pIndicadoresCodigo = "" ;
         this.AV16pRFF_COMPRADAMes = 0 ;
         this.AV17pRFF_COMPRADAAno = 0 ;
         this.AV18pRFF_COMPRAPRODUCUP = "" ;
         executePrivate();
         aP0_pRFF_COMPRADAFecha=this.AV13pRFF_COMPRADAFecha;
         aP1_pCod_Area=this.AV14pCod_Area;
         aP2_pIndicadoresCodigo=this.AV15pIndicadoresCodigo;
         aP3_pRFF_COMPRADAMes=this.AV16pRFF_COMPRADAMes;
         aP4_pRFF_COMPRADAAno=this.AV17pRFF_COMPRADAAno;
         aP5_pRFF_COMPRAPRODUCUP=this.AV18pRFF_COMPRAPRODUCUP;
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
            gxfirstwebparm = GetFirstPar( "pRFF_COMPRADAFecha");
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
               gxfirstwebparm = GetFirstPar( "pRFF_COMPRADAFecha");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pRFF_COMPRADAFecha");
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
               AV13pRFF_COMPRADAFecha = context.localUtil.ParseDateParm( gxfirstwebparm);
               AssignAttri("", false, "AV13pRFF_COMPRADAFecha", context.localUtil.Format(AV13pRFF_COMPRADAFecha, "99/99/99"));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV14pCod_Area = GetPar( "pCod_Area");
                  AssignAttri("", false, "AV14pCod_Area", AV14pCod_Area);
                  AV15pIndicadoresCodigo = GetPar( "pIndicadoresCodigo");
                  AssignAttri("", false, "AV15pIndicadoresCodigo", AV15pIndicadoresCodigo);
                  AV16pRFF_COMPRADAMes = (short)(Math.Round(NumberUtil.Val( GetPar( "pRFF_COMPRADAMes"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV16pRFF_COMPRADAMes", StringUtil.LTrimStr( (decimal)(AV16pRFF_COMPRADAMes), 4, 0));
                  AV17pRFF_COMPRADAAno = (short)(Math.Round(NumberUtil.Val( GetPar( "pRFF_COMPRADAAno"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV17pRFF_COMPRADAAno", StringUtil.LTrimStr( (decimal)(AV17pRFF_COMPRADAAno), 4, 0));
                  AV18pRFF_COMPRAPRODUCUP = GetPar( "pRFF_COMPRAPRODUCUP");
                  AssignAttri("", false, "AV18pRFF_COMPRAPRODUCUP", AV18pRFF_COMPRAPRODUCUP);
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
         AV6cRFF_COMPRADAFecha = context.localUtil.ParseDateParm( GetPar( "cRFF_COMPRADAFecha"));
         AV7cCod_Area = GetPar( "cCod_Area");
         AV8cIndicadoresCodigo = GetPar( "cIndicadoresCodigo");
         AV9cRFF_COMPRADAMes = (short)(Math.Round(NumberUtil.Val( GetPar( "cRFF_COMPRADAMes"), "."), 18, MidpointRounding.ToEven));
         AV10cRFF_COMPRADAAno = (short)(Math.Round(NumberUtil.Val( GetPar( "cRFF_COMPRADAAno"), "."), 18, MidpointRounding.ToEven));
         AV11cRFF_COMPRAPRODUCUP = GetPar( "cRFF_COMPRAPRODUCUP");
         AV12cRFF_COMPRATON = NumberUtil.Val( GetPar( "cRFF_COMPRATON"), ".");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cRFF_COMPRADAFecha, AV7cCod_Area, AV8cIndicadoresCodigo, AV9cRFF_COMPRADAMes, AV10cRFF_COMPRADAAno, AV11cRFF_COMPRAPRODUCUP, AV12cRFF_COMPRATON) ;
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
         PA1C2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START1C2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0160.aspx", new object[] {UrlEncode(DateTimeUtil.FormatDateParm(AV13pRFF_COMPRADAFecha)),UrlEncode(StringUtil.RTrim(AV14pCod_Area)),UrlEncode(StringUtil.RTrim(AV15pIndicadoresCodigo)),UrlEncode(StringUtil.LTrimStr(AV16pRFF_COMPRADAMes,4,0)),UrlEncode(StringUtil.LTrimStr(AV17pRFF_COMPRADAAno,4,0)),UrlEncode(StringUtil.RTrim(AV18pRFF_COMPRAPRODUCUP))}, new string[] {"pRFF_COMPRADAFecha","pCod_Area","pIndicadoresCodigo","pRFF_COMPRADAMes","pRFF_COMPRADAAno","pRFF_COMPRAPRODUCUP"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCRFF_COMPRADAFECHA", context.localUtil.Format(AV6cRFF_COMPRADAFecha, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vCCOD_AREA", AV7cCod_Area);
         GxWebStd.gx_hidden_field( context, "GXH_vCINDICADORESCODIGO", AV8cIndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "GXH_vCRFF_COMPRADAMES", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9cRFF_COMPRADAMes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCRFF_COMPRADAANO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cRFF_COMPRADAAno), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCRFF_COMPRAPRODUCUP", StringUtil.RTrim( AV11cRFF_COMPRAPRODUCUP));
         GxWebStd.gx_hidden_field( context, "GXH_vCRFF_COMPRATON", StringUtil.LTrim( StringUtil.NToC( AV12cRFF_COMPRATON, 12, 2, ",", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPRFF_COMPRADAFECHA", context.localUtil.DToC( AV13pRFF_COMPRADAFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vPCOD_AREA", AV14pCod_Area);
         GxWebStd.gx_hidden_field( context, "vPINDICADORESCODIGO", AV15pIndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "vPRFF_COMPRADAMES", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16pRFF_COMPRADAMes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPRFF_COMPRADAANO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17pRFF_COMPRADAAno), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPRFF_COMPRAPRODUCUP", StringUtil.RTrim( AV18pRFF_COMPRAPRODUCUP));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "RFF_COMPRADAFECHAFILTERCONTAINER_Class", StringUtil.RTrim( divRff_compradafechafiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "COD_AREAFILTERCONTAINER_Class", StringUtil.RTrim( divCod_areafiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "INDICADORESCODIGOFILTERCONTAINER_Class", StringUtil.RTrim( divIndicadorescodigofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "RFF_COMPRADAMESFILTERCONTAINER_Class", StringUtil.RTrim( divRff_compradamesfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "RFF_COMPRADAANOFILTERCONTAINER_Class", StringUtil.RTrim( divRff_compradaanofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "RFF_COMPRAPRODUCUPFILTERCONTAINER_Class", StringUtil.RTrim( divRff_compraproducupfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "RFF_COMPRATONFILTERCONTAINER_Class", StringUtil.RTrim( divRff_compratonfiltercontainer_Class));
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
            WE1C2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT1C2( ) ;
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
         return formatLink("gx0160.aspx", new object[] {UrlEncode(DateTimeUtil.FormatDateParm(AV13pRFF_COMPRADAFecha)),UrlEncode(StringUtil.RTrim(AV14pCod_Area)),UrlEncode(StringUtil.RTrim(AV15pIndicadoresCodigo)),UrlEncode(StringUtil.LTrimStr(AV16pRFF_COMPRADAMes,4,0)),UrlEncode(StringUtil.LTrimStr(AV17pRFF_COMPRADAAno,4,0)),UrlEncode(StringUtil.RTrim(AV18pRFF_COMPRAPRODUCUP))}, new string[] {"pRFF_COMPRADAFecha","pCod_Area","pIndicadoresCodigo","pRFF_COMPRADAMes","pRFF_COMPRADAAno","pRFF_COMPRAPRODUCUP"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx0160" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List RFF_COMPRADA" ;
      }

      protected void WB1C0( )
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
            GxWebStd.gx_div_start( context, divRff_compradafechafiltercontainer_Internalname, 1, 0, "px", 0, "px", divRff_compradafechafiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblrff_compradafechafilter_Internalname, "RFF_COMPRADAFecha", "", "", lblLblrff_compradafechafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e111c1_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0160.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCrff_compradafecha_Internalname, "RFF_COMPRADAFecha", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCrff_compradafecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCrff_compradafecha_Internalname, context.localUtil.Format(AV6cRFF_COMPRADAFecha, "99/99/99"), context.localUtil.Format( AV6cRFF_COMPRADAFecha, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCrff_compradafecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCrff_compradafecha_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx0160.htm");
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
            GxWebStd.gx_div_start( context, divCod_areafiltercontainer_Internalname, 1, 0, "px", 0, "px", divCod_areafiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcod_areafilter_Internalname, "Cod_Area", "", "", lblLblcod_areafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e121c1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0160.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcod_area_Internalname, AV7cCod_Area, StringUtil.RTrim( context.localUtil.Format( AV7cCod_Area, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcod_area_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcod_area_Visible, edtavCcod_area_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Gx0160.htm");
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
            GxWebStd.gx_label_ctrl( context, lblLblindicadorescodigofilter_Internalname, "Indicadores Codigo", "", "", lblLblindicadorescodigofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e131c1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0160.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCindicadorescodigo_Internalname, AV8cIndicadoresCodigo, StringUtil.RTrim( context.localUtil.Format( AV8cIndicadoresCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCindicadorescodigo_Jsonclick, 0, "Attribute", "", "", "", "", edtavCindicadorescodigo_Visible, edtavCindicadorescodigo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Gx0160.htm");
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
            GxWebStd.gx_div_start( context, divRff_compradamesfiltercontainer_Internalname, 1, 0, "px", 0, "px", divRff_compradamesfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblrff_compradamesfilter_Internalname, "RFF_COMPRADAMes", "", "", lblLblrff_compradamesfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e141c1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0160.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCrff_compradames_Internalname, "RFF_COMPRADAMes", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCrff_compradames_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9cRFF_COMPRADAMes), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCrff_compradames_Enabled!=0) ? context.localUtil.Format( (decimal)(AV9cRFF_COMPRADAMes), "ZZZ9") : context.localUtil.Format( (decimal)(AV9cRFF_COMPRADAMes), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCrff_compradames_Jsonclick, 0, "Attribute", "", "", "", "", edtavCrff_compradames_Visible, edtavCrff_compradames_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx0160.htm");
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
            GxWebStd.gx_div_start( context, divRff_compradaanofiltercontainer_Internalname, 1, 0, "px", 0, "px", divRff_compradaanofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblrff_compradaanofilter_Internalname, "RFF_COMPRADAAno", "", "", lblLblrff_compradaanofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e151c1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0160.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCrff_compradaano_Internalname, "RFF_COMPRADAAno", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCrff_compradaano_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cRFF_COMPRADAAno), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCrff_compradaano_Enabled!=0) ? context.localUtil.Format( (decimal)(AV10cRFF_COMPRADAAno), "ZZZ9") : context.localUtil.Format( (decimal)(AV10cRFF_COMPRADAAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCrff_compradaano_Jsonclick, 0, "Attribute", "", "", "", "", edtavCrff_compradaano_Visible, edtavCrff_compradaano_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx0160.htm");
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
            GxWebStd.gx_div_start( context, divRff_compraproducupfiltercontainer_Internalname, 1, 0, "px", 0, "px", divRff_compraproducupfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblrff_compraproducupfilter_Internalname, "RFF_COMPRAPRODUCUP", "", "", lblLblrff_compraproducupfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e161c1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0160.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCrff_compraproducup_Internalname, "RFF_COMPRAPRODUCUP", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCrff_compraproducup_Internalname, StringUtil.RTrim( AV11cRFF_COMPRAPRODUCUP), StringUtil.RTrim( context.localUtil.Format( AV11cRFF_COMPRAPRODUCUP, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCrff_compraproducup_Jsonclick, 0, "Attribute", "", "", "", "", edtavCrff_compraproducup_Visible, edtavCrff_compraproducup_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Gx0160.htm");
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
            GxWebStd.gx_div_start( context, divRff_compratonfiltercontainer_Internalname, 1, 0, "px", 0, "px", divRff_compratonfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblrff_compratonfilter_Internalname, "RFF_COMPRATON", "", "", lblLblrff_compratonfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e171c1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0160.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCrff_compraton_Internalname, "RFF_COMPRATON", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCrff_compraton_Internalname, StringUtil.LTrim( StringUtil.NToC( AV12cRFF_COMPRATON, 12, 2, ",", "")), StringUtil.LTrim( ((edtavCrff_compraton_Enabled!=0) ? context.localUtil.Format( AV12cRFF_COMPRATON, "ZZZZZZZZ9.99") : context.localUtil.Format( AV12cRFF_COMPRATON, "ZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCrff_compraton_Jsonclick, 0, "Attribute", "", "", "", "", edtavCrff_compraton_Visible, edtavCrff_compraton_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx0160.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e181c1_client"+"'", TempTags, "", 2, "HLP_Gx0160.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0160.htm");
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

      protected void START1C2( )
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
            Form.Meta.addItem("description", "Selection List RFF_COMPRADA", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1C0( ) ;
      }

      protected void WS1C2( )
      {
         START1C2( ) ;
         EVT1C2( ) ;
      }

      protected void EVT1C2( )
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
                              A86RFF_COMPRADAFecha = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtRFF_COMPRADAFecha_Internalname), 0));
                              A5Cod_Area = cgiGet( edtCod_Area_Internalname);
                              A4IndicadoresCodigo = cgiGet( edtIndicadoresCodigo_Internalname);
                              A87RFF_COMPRADAMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtRFF_COMPRADAMes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A238RFF_COMPRATON = context.localUtil.CToN( cgiGet( edtRFF_COMPRATON_Internalname), ",", ".");
                              n238RFF_COMPRATON = false;
                              A88RFF_COMPRADAAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtRFF_COMPRADAAno_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A89RFF_COMPRAPRODUCUP = cgiGet( edtRFF_COMPRAPRODUCUP_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E191C2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E201C2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Crff_compradafecha Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCRFF_COMPRADAFECHA"), 0) != AV6cRFF_COMPRADAFecha )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccod_area Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCCOD_AREA"), AV7cCod_Area) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cindicadorescodigo Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCINDICADORESCODIGO"), AV8cIndicadoresCodigo) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Crff_compradames Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCRFF_COMPRADAMES"), ",", ".") != Convert.ToDecimal( AV9cRFF_COMPRADAMes )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Crff_compradaano Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCRFF_COMPRADAANO"), ",", ".") != Convert.ToDecimal( AV10cRFF_COMPRADAAno )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Crff_compraproducup Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCRFF_COMPRAPRODUCUP"), AV11cRFF_COMPRAPRODUCUP) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Crff_compraton Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCRFF_COMPRATON"), ",", ".") != AV12cRFF_COMPRATON )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E211C2 ();
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

      protected void WE1C2( )
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

      protected void PA1C2( )
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
                                        DateTime AV6cRFF_COMPRADAFecha ,
                                        string AV7cCod_Area ,
                                        string AV8cIndicadoresCodigo ,
                                        short AV9cRFF_COMPRADAMes ,
                                        short AV10cRFF_COMPRADAAno ,
                                        string AV11cRFF_COMPRAPRODUCUP ,
                                        decimal AV12cRFF_COMPRATON )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF1C2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_RFF_COMPRADAFECHA", GetSecureSignedToken( "", A86RFF_COMPRADAFecha, context));
         GxWebStd.gx_hidden_field( context, "RFF_COMPRADAFECHA", context.localUtil.Format(A86RFF_COMPRADAFecha, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "gxhash_COD_AREA", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A5Cod_Area, "")), context));
         GxWebStd.gx_hidden_field( context, "COD_AREA", A5Cod_Area);
         GxWebStd.gx_hidden_field( context, "gxhash_INDICADORESCODIGO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A4IndicadoresCodigo, "")), context));
         GxWebStd.gx_hidden_field( context, "INDICADORESCODIGO", A4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "gxhash_RFF_COMPRADAMES", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A87RFF_COMPRADAMes), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "RFF_COMPRADAMES", StringUtil.LTrim( StringUtil.NToC( (decimal)(A87RFF_COMPRADAMes), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_RFF_COMPRADAANO", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A88RFF_COMPRADAAno), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "RFF_COMPRADAANO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A88RFF_COMPRADAAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_RFF_COMPRAPRODUCUP", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A89RFF_COMPRAPRODUCUP, "")), context));
         GxWebStd.gx_hidden_field( context, "RFF_COMPRAPRODUCUP", StringUtil.RTrim( A89RFF_COMPRAPRODUCUP));
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
         RF1C2( ) ;
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

      protected void RF1C2( )
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
                                                 AV12cRFF_COMPRATON ,
                                                 A238RFF_COMPRATON ,
                                                 A5Cod_Area ,
                                                 AV7cCod_Area ,
                                                 A4IndicadoresCodigo ,
                                                 AV8cIndicadoresCodigo ,
                                                 A87RFF_COMPRADAMes ,
                                                 AV9cRFF_COMPRADAMes ,
                                                 A88RFF_COMPRADAAno ,
                                                 AV10cRFF_COMPRADAAno ,
                                                 A89RFF_COMPRAPRODUCUP ,
                                                 AV11cRFF_COMPRAPRODUCUP ,
                                                 AV6cRFF_COMPRADAFecha } ,
                                                 new int[]{
                                                 TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE
                                                 }
            });
            lV7cCod_Area = StringUtil.Concat( StringUtil.RTrim( AV7cCod_Area), "%", "");
            lV8cIndicadoresCodigo = StringUtil.Concat( StringUtil.RTrim( AV8cIndicadoresCodigo), "%", "");
            lV11cRFF_COMPRAPRODUCUP = StringUtil.PadR( StringUtil.RTrim( AV11cRFF_COMPRAPRODUCUP), 20, "%");
            /* Using cursor H001C2 */
            pr_default.execute(0, new Object[] {AV6cRFF_COMPRADAFecha, lV7cCod_Area, lV8cIndicadoresCodigo, AV9cRFF_COMPRADAMes, AV10cRFF_COMPRADAAno, lV11cRFF_COMPRAPRODUCUP, AV12cRFF_COMPRATON, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A89RFF_COMPRAPRODUCUP = H001C2_A89RFF_COMPRAPRODUCUP[0];
               A88RFF_COMPRADAAno = H001C2_A88RFF_COMPRADAAno[0];
               A238RFF_COMPRATON = H001C2_A238RFF_COMPRATON[0];
               n238RFF_COMPRATON = H001C2_n238RFF_COMPRATON[0];
               A87RFF_COMPRADAMes = H001C2_A87RFF_COMPRADAMes[0];
               A4IndicadoresCodigo = H001C2_A4IndicadoresCodigo[0];
               A5Cod_Area = H001C2_A5Cod_Area[0];
               A86RFF_COMPRADAFecha = H001C2_A86RFF_COMPRADAFecha[0];
               /* Execute user event: Load */
               E201C2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WB1C0( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes1C2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_RFF_COMPRADAFECHA"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, A86RFF_COMPRADAFecha, context));
         GxWebStd.gx_hidden_field( context, "gxhash_COD_AREA"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, StringUtil.RTrim( context.localUtil.Format( A5Cod_Area, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_INDICADORESCODIGO"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, StringUtil.RTrim( context.localUtil.Format( A4IndicadoresCodigo, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_RFF_COMPRADAMES"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A87RFF_COMPRADAMes), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_RFF_COMPRADAANO"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A88RFF_COMPRADAAno), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_RFF_COMPRAPRODUCUP"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, StringUtil.RTrim( context.localUtil.Format( A89RFF_COMPRAPRODUCUP, "")), context));
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
                                              AV12cRFF_COMPRATON ,
                                              A238RFF_COMPRATON ,
                                              A5Cod_Area ,
                                              AV7cCod_Area ,
                                              A4IndicadoresCodigo ,
                                              AV8cIndicadoresCodigo ,
                                              A87RFF_COMPRADAMes ,
                                              AV9cRFF_COMPRADAMes ,
                                              A88RFF_COMPRADAAno ,
                                              AV10cRFF_COMPRADAAno ,
                                              A89RFF_COMPRAPRODUCUP ,
                                              AV11cRFF_COMPRAPRODUCUP ,
                                              AV6cRFF_COMPRADAFecha } ,
                                              new int[]{
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE
                                              }
         });
         lV7cCod_Area = StringUtil.Concat( StringUtil.RTrim( AV7cCod_Area), "%", "");
         lV8cIndicadoresCodigo = StringUtil.Concat( StringUtil.RTrim( AV8cIndicadoresCodigo), "%", "");
         lV11cRFF_COMPRAPRODUCUP = StringUtil.PadR( StringUtil.RTrim( AV11cRFF_COMPRAPRODUCUP), 20, "%");
         /* Using cursor H001C3 */
         pr_default.execute(1, new Object[] {AV6cRFF_COMPRADAFecha, lV7cCod_Area, lV8cIndicadoresCodigo, AV9cRFF_COMPRADAMes, AV10cRFF_COMPRADAAno, lV11cRFF_COMPRAPRODUCUP, AV12cRFF_COMPRATON});
         GRID1_nRecordCount = H001C3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cRFF_COMPRADAFecha, AV7cCod_Area, AV8cIndicadoresCodigo, AV9cRFF_COMPRADAMes, AV10cRFF_COMPRADAAno, AV11cRFF_COMPRAPRODUCUP, AV12cRFF_COMPRATON) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cRFF_COMPRADAFecha, AV7cCod_Area, AV8cIndicadoresCodigo, AV9cRFF_COMPRADAMes, AV10cRFF_COMPRADAAno, AV11cRFF_COMPRAPRODUCUP, AV12cRFF_COMPRATON) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cRFF_COMPRADAFecha, AV7cCod_Area, AV8cIndicadoresCodigo, AV9cRFF_COMPRADAMes, AV10cRFF_COMPRADAAno, AV11cRFF_COMPRAPRODUCUP, AV12cRFF_COMPRATON) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cRFF_COMPRADAFecha, AV7cCod_Area, AV8cIndicadoresCodigo, AV9cRFF_COMPRADAMes, AV10cRFF_COMPRADAAno, AV11cRFF_COMPRAPRODUCUP, AV12cRFF_COMPRATON) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cRFF_COMPRADAFecha, AV7cCod_Area, AV8cIndicadoresCodigo, AV9cRFF_COMPRADAMes, AV10cRFF_COMPRADAAno, AV11cRFF_COMPRAPRODUCUP, AV12cRFF_COMPRATON) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP1C0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E191C2 ();
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
            if ( context.localUtil.VCDate( cgiGet( edtavCrff_compradafecha_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"RFF_COMPRADAFecha"}), 1, "vCRFF_COMPRADAFECHA");
               GX_FocusControl = edtavCrff_compradafecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cRFF_COMPRADAFecha = DateTime.MinValue;
               AssignAttri("", false, "AV6cRFF_COMPRADAFecha", context.localUtil.Format(AV6cRFF_COMPRADAFecha, "99/99/99"));
            }
            else
            {
               AV6cRFF_COMPRADAFecha = context.localUtil.CToD( cgiGet( edtavCrff_compradafecha_Internalname), 2);
               AssignAttri("", false, "AV6cRFF_COMPRADAFecha", context.localUtil.Format(AV6cRFF_COMPRADAFecha, "99/99/99"));
            }
            AV7cCod_Area = cgiGet( edtavCcod_area_Internalname);
            AssignAttri("", false, "AV7cCod_Area", AV7cCod_Area);
            AV8cIndicadoresCodigo = cgiGet( edtavCindicadorescodigo_Internalname);
            AssignAttri("", false, "AV8cIndicadoresCodigo", AV8cIndicadoresCodigo);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCrff_compradames_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCrff_compradames_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCRFF_COMPRADAMES");
               GX_FocusControl = edtavCrff_compradames_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9cRFF_COMPRADAMes = 0;
               AssignAttri("", false, "AV9cRFF_COMPRADAMes", StringUtil.LTrimStr( (decimal)(AV9cRFF_COMPRADAMes), 4, 0));
            }
            else
            {
               AV9cRFF_COMPRADAMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCrff_compradames_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV9cRFF_COMPRADAMes", StringUtil.LTrimStr( (decimal)(AV9cRFF_COMPRADAMes), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCrff_compradaano_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCrff_compradaano_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCRFF_COMPRADAANO");
               GX_FocusControl = edtavCrff_compradaano_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cRFF_COMPRADAAno = 0;
               AssignAttri("", false, "AV10cRFF_COMPRADAAno", StringUtil.LTrimStr( (decimal)(AV10cRFF_COMPRADAAno), 4, 0));
            }
            else
            {
               AV10cRFF_COMPRADAAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCrff_compradaano_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV10cRFF_COMPRADAAno", StringUtil.LTrimStr( (decimal)(AV10cRFF_COMPRADAAno), 4, 0));
            }
            AV11cRFF_COMPRAPRODUCUP = cgiGet( edtavCrff_compraproducup_Internalname);
            AssignAttri("", false, "AV11cRFF_COMPRAPRODUCUP", AV11cRFF_COMPRAPRODUCUP);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCrff_compraton_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCrff_compraton_Internalname), ",", ".") > 999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCRFF_COMPRATON");
               GX_FocusControl = edtavCrff_compraton_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12cRFF_COMPRATON = 0;
               AssignAttri("", false, "AV12cRFF_COMPRATON", StringUtil.LTrimStr( AV12cRFF_COMPRATON, 12, 2));
            }
            else
            {
               AV12cRFF_COMPRATON = context.localUtil.CToN( cgiGet( edtavCrff_compraton_Internalname), ",", ".");
               AssignAttri("", false, "AV12cRFF_COMPRATON", StringUtil.LTrimStr( AV12cRFF_COMPRATON, 12, 2));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vCRFF_COMPRADAFECHA"), 2) ) != DateTimeUtil.ResetTime ( AV6cRFF_COMPRADAFecha ) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCCOD_AREA"), AV7cCod_Area) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCINDICADORESCODIGO"), AV8cIndicadoresCodigo) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCRFF_COMPRADAMES"), ",", ".") != Convert.ToDecimal( AV9cRFF_COMPRADAMes )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCRFF_COMPRADAANO"), ",", ".") != Convert.ToDecimal( AV10cRFF_COMPRADAAno )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCRFF_COMPRAPRODUCUP"), AV11cRFF_COMPRAPRODUCUP) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vCRFF_COMPRATON"), ",", ".") != AV12cRFF_COMPRATON )
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
         E191C2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E191C2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Lista de Selección %1", "RFF_COMPRADA", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV19ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E201C2( )
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
         E211C2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E211C2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pRFF_COMPRADAFecha = A86RFF_COMPRADAFecha;
         AssignAttri("", false, "AV13pRFF_COMPRADAFecha", context.localUtil.Format(AV13pRFF_COMPRADAFecha, "99/99/99"));
         AV14pCod_Area = A5Cod_Area;
         AssignAttri("", false, "AV14pCod_Area", AV14pCod_Area);
         AV15pIndicadoresCodigo = A4IndicadoresCodigo;
         AssignAttri("", false, "AV15pIndicadoresCodigo", AV15pIndicadoresCodigo);
         AV16pRFF_COMPRADAMes = A87RFF_COMPRADAMes;
         AssignAttri("", false, "AV16pRFF_COMPRADAMes", StringUtil.LTrimStr( (decimal)(AV16pRFF_COMPRADAMes), 4, 0));
         AV17pRFF_COMPRADAAno = A88RFF_COMPRADAAno;
         AssignAttri("", false, "AV17pRFF_COMPRADAAno", StringUtil.LTrimStr( (decimal)(AV17pRFF_COMPRADAAno), 4, 0));
         AV18pRFF_COMPRAPRODUCUP = A89RFF_COMPRAPRODUCUP;
         AssignAttri("", false, "AV18pRFF_COMPRAPRODUCUP", AV18pRFF_COMPRAPRODUCUP);
         context.setWebReturnParms(new Object[] {context.localUtil.Format( AV13pRFF_COMPRADAFecha, "99/99/99"),(string)AV14pCod_Area,(string)AV15pIndicadoresCodigo,(short)AV16pRFF_COMPRADAMes,(short)AV17pRFF_COMPRADAAno,(string)AV18pRFF_COMPRAPRODUCUP});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pRFF_COMPRADAFecha","AV14pCod_Area","AV15pIndicadoresCodigo","AV16pRFF_COMPRADAMes","AV17pRFF_COMPRADAAno","AV18pRFF_COMPRAPRODUCUP"});
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
         AV13pRFF_COMPRADAFecha = (DateTime)getParm(obj,0);
         AssignAttri("", false, "AV13pRFF_COMPRADAFecha", context.localUtil.Format(AV13pRFF_COMPRADAFecha, "99/99/99"));
         AV14pCod_Area = (string)getParm(obj,1);
         AssignAttri("", false, "AV14pCod_Area", AV14pCod_Area);
         AV15pIndicadoresCodigo = (string)getParm(obj,2);
         AssignAttri("", false, "AV15pIndicadoresCodigo", AV15pIndicadoresCodigo);
         AV16pRFF_COMPRADAMes = Convert.ToInt16(getParm(obj,3));
         AssignAttri("", false, "AV16pRFF_COMPRADAMes", StringUtil.LTrimStr( (decimal)(AV16pRFF_COMPRADAMes), 4, 0));
         AV17pRFF_COMPRADAAno = Convert.ToInt16(getParm(obj,4));
         AssignAttri("", false, "AV17pRFF_COMPRADAAno", StringUtil.LTrimStr( (decimal)(AV17pRFF_COMPRADAAno), 4, 0));
         AV18pRFF_COMPRAPRODUCUP = (string)getParm(obj,5);
         AssignAttri("", false, "AV18pRFF_COMPRAPRODUCUP", AV18pRFF_COMPRAPRODUCUP);
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
         PA1C2( ) ;
         WS1C2( ) ;
         WE1C2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20247231025793", true, true);
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
         context.AddJavascriptSource("gx0160.js", "?20247231025793", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtRFF_COMPRADAFecha_Internalname = "RFF_COMPRADAFECHA_"+sGXsfl_84_idx;
         edtCod_Area_Internalname = "COD_AREA_"+sGXsfl_84_idx;
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO_"+sGXsfl_84_idx;
         edtRFF_COMPRADAMes_Internalname = "RFF_COMPRADAMES_"+sGXsfl_84_idx;
         edtRFF_COMPRATON_Internalname = "RFF_COMPRATON_"+sGXsfl_84_idx;
         edtRFF_COMPRADAAno_Internalname = "RFF_COMPRADAANO_"+sGXsfl_84_idx;
         edtRFF_COMPRAPRODUCUP_Internalname = "RFF_COMPRAPRODUCUP_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtRFF_COMPRADAFecha_Internalname = "RFF_COMPRADAFECHA_"+sGXsfl_84_fel_idx;
         edtCod_Area_Internalname = "COD_AREA_"+sGXsfl_84_fel_idx;
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO_"+sGXsfl_84_fel_idx;
         edtRFF_COMPRADAMes_Internalname = "RFF_COMPRADAMES_"+sGXsfl_84_fel_idx;
         edtRFF_COMPRATON_Internalname = "RFF_COMPRATON_"+sGXsfl_84_fel_idx;
         edtRFF_COMPRADAAno_Internalname = "RFF_COMPRADAANO_"+sGXsfl_84_fel_idx;
         edtRFF_COMPRAPRODUCUP_Internalname = "RFF_COMPRAPRODUCUP_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         SubsflControlProps_842( ) ;
         WB1C0( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( context.localUtil.Format(A86RFF_COMPRADAFecha, "99/99/99"))+"'"+", "+"'"+GXUtil.EncodeJSConstant( A5Cod_Area)+"'"+", "+"'"+GXUtil.EncodeJSConstant( A4IndicadoresCodigo)+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A87RFF_COMPRADAMes), 4, 0, ",", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A88RFF_COMPRADAAno), 4, 0, ",", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.RTrim( A89RFF_COMPRAPRODUCUP))+"'"+"]);";
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
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRFF_COMPRADAFecha_Internalname,context.localUtil.Format(A86RFF_COMPRADAFecha, "99/99/99"),context.localUtil.Format( A86RFF_COMPRADAFecha, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRFF_COMPRADAFecha_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
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
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRFF_COMPRADAMes_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A87RFF_COMPRADAMes), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A87RFF_COMPRADAMes), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRFF_COMPRADAMes_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtRFF_COMPRATON_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( context.localUtil.Format(A86RFF_COMPRADAFecha, "99/99/99"))+"'"+", "+"'"+GXUtil.EncodeJSConstant( A5Cod_Area)+"'"+", "+"'"+GXUtil.EncodeJSConstant( A4IndicadoresCodigo)+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A87RFF_COMPRADAMes), 4, 0, ",", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A88RFF_COMPRADAAno), 4, 0, ",", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.RTrim( A89RFF_COMPRAPRODUCUP))+"'"+"]);";
            AssignProp("", false, edtRFF_COMPRATON_Internalname, "Link", edtRFF_COMPRATON_Link, !bGXsfl_84_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRFF_COMPRATON_Internalname,StringUtil.LTrim( StringUtil.NToC( A238RFF_COMPRATON, 12, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A238RFF_COMPRATON, "ZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtRFF_COMPRATON_Link,(string)"",(string)"",(string)"",(string)edtRFF_COMPRATON_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRFF_COMPRADAAno_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A88RFF_COMPRADAAno), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A88RFF_COMPRADAAno), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRFF_COMPRADAAno_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRFF_COMPRAPRODUCUP_Internalname,StringUtil.RTrim( A89RFF_COMPRAPRODUCUP),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRFF_COMPRAPRODUCUP_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            send_integrity_lvl_hashes1C2( ) ;
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
            context.SendWebValue( "RFF_COMPRADAFecha") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Cod_Area") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Indicadores Codigo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "RFF_COMPRADAMes") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "RFF_COMPRATON") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "RFF_COMPRADAAno") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "RFF_COMPRAPRODUCUP") ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A86RFF_COMPRADAFecha, "99/99/99")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A5Cod_Area));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A4IndicadoresCodigo));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A87RFF_COMPRADAMes), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A238RFF_COMPRATON, 12, 2, ".", ""))));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtRFF_COMPRATON_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A88RFF_COMPRADAAno), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A89RFF_COMPRAPRODUCUP)));
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
         lblLblrff_compradafechafilter_Internalname = "LBLRFF_COMPRADAFECHAFILTER";
         edtavCrff_compradafecha_Internalname = "vCRFF_COMPRADAFECHA";
         divRff_compradafechafiltercontainer_Internalname = "RFF_COMPRADAFECHAFILTERCONTAINER";
         lblLblcod_areafilter_Internalname = "LBLCOD_AREAFILTER";
         edtavCcod_area_Internalname = "vCCOD_AREA";
         divCod_areafiltercontainer_Internalname = "COD_AREAFILTERCONTAINER";
         lblLblindicadorescodigofilter_Internalname = "LBLINDICADORESCODIGOFILTER";
         edtavCindicadorescodigo_Internalname = "vCINDICADORESCODIGO";
         divIndicadorescodigofiltercontainer_Internalname = "INDICADORESCODIGOFILTERCONTAINER";
         lblLblrff_compradamesfilter_Internalname = "LBLRFF_COMPRADAMESFILTER";
         edtavCrff_compradames_Internalname = "vCRFF_COMPRADAMES";
         divRff_compradamesfiltercontainer_Internalname = "RFF_COMPRADAMESFILTERCONTAINER";
         lblLblrff_compradaanofilter_Internalname = "LBLRFF_COMPRADAANOFILTER";
         edtavCrff_compradaano_Internalname = "vCRFF_COMPRADAANO";
         divRff_compradaanofiltercontainer_Internalname = "RFF_COMPRADAANOFILTERCONTAINER";
         lblLblrff_compraproducupfilter_Internalname = "LBLRFF_COMPRAPRODUCUPFILTER";
         edtavCrff_compraproducup_Internalname = "vCRFF_COMPRAPRODUCUP";
         divRff_compraproducupfiltercontainer_Internalname = "RFF_COMPRAPRODUCUPFILTERCONTAINER";
         lblLblrff_compratonfilter_Internalname = "LBLRFF_COMPRATONFILTER";
         edtavCrff_compraton_Internalname = "vCRFF_COMPRATON";
         divRff_compratonfiltercontainer_Internalname = "RFF_COMPRATONFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtRFF_COMPRADAFecha_Internalname = "RFF_COMPRADAFECHA";
         edtCod_Area_Internalname = "COD_AREA";
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO";
         edtRFF_COMPRADAMes_Internalname = "RFF_COMPRADAMES";
         edtRFF_COMPRATON_Internalname = "RFF_COMPRATON";
         edtRFF_COMPRADAAno_Internalname = "RFF_COMPRADAANO";
         edtRFF_COMPRAPRODUCUP_Internalname = "RFF_COMPRAPRODUCUP";
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
         edtRFF_COMPRAPRODUCUP_Jsonclick = "";
         edtRFF_COMPRADAAno_Jsonclick = "";
         edtRFF_COMPRATON_Jsonclick = "";
         edtRFF_COMPRATON_Link = "";
         edtRFF_COMPRADAMes_Jsonclick = "";
         edtIndicadoresCodigo_Jsonclick = "";
         edtCod_Area_Jsonclick = "";
         edtRFF_COMPRADAFecha_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtavCrff_compraton_Jsonclick = "";
         edtavCrff_compraton_Enabled = 1;
         edtavCrff_compraton_Visible = 1;
         edtavCrff_compraproducup_Jsonclick = "";
         edtavCrff_compraproducup_Enabled = 1;
         edtavCrff_compraproducup_Visible = 1;
         edtavCrff_compradaano_Jsonclick = "";
         edtavCrff_compradaano_Enabled = 1;
         edtavCrff_compradaano_Visible = 1;
         edtavCrff_compradames_Jsonclick = "";
         edtavCrff_compradames_Enabled = 1;
         edtavCrff_compradames_Visible = 1;
         edtavCindicadorescodigo_Jsonclick = "";
         edtavCindicadorescodigo_Enabled = 1;
         edtavCindicadorescodigo_Visible = 1;
         edtavCcod_area_Jsonclick = "";
         edtavCcod_area_Enabled = 1;
         edtavCcod_area_Visible = 1;
         edtavCrff_compradafecha_Jsonclick = "";
         edtavCrff_compradafecha_Enabled = 1;
         divRff_compratonfiltercontainer_Class = "AdvancedContainerItem";
         divRff_compraproducupfiltercontainer_Class = "AdvancedContainerItem";
         divRff_compradaanofiltercontainer_Class = "AdvancedContainerItem";
         divRff_compradamesfiltercontainer_Class = "AdvancedContainerItem";
         divIndicadorescodigofiltercontainer_Class = "AdvancedContainerItem";
         divCod_areafiltercontainer_Class = "AdvancedContainerItem";
         divRff_compradafechafiltercontainer_Class = "AdvancedContainerItem";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List RFF_COMPRADA";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cRFF_COMPRADAFecha',fld:'vCRFF_COMPRADAFECHA',pic:''},{av:'AV7cCod_Area',fld:'vCCOD_AREA',pic:''},{av:'AV8cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV9cRFF_COMPRADAMes',fld:'vCRFF_COMPRADAMES',pic:'ZZZ9'},{av:'AV10cRFF_COMPRADAAno',fld:'vCRFF_COMPRADAANO',pic:'ZZZ9'},{av:'AV11cRFF_COMPRAPRODUCUP',fld:'vCRFF_COMPRAPRODUCUP',pic:''},{av:'AV12cRFF_COMPRATON',fld:'vCRFF_COMPRATON',pic:'ZZZZZZZZ9.99'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E181C1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLRFF_COMPRADAFECHAFILTER.CLICK","{handler:'E111C1',iparms:[{av:'divRff_compradafechafiltercontainer_Class',ctrl:'RFF_COMPRADAFECHAFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLRFF_COMPRADAFECHAFILTER.CLICK",",oparms:[{av:'divRff_compradafechafiltercontainer_Class',ctrl:'RFF_COMPRADAFECHAFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLCOD_AREAFILTER.CLICK","{handler:'E121C1',iparms:[{av:'divCod_areafiltercontainer_Class',ctrl:'COD_AREAFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCOD_AREAFILTER.CLICK",",oparms:[{av:'divCod_areafiltercontainer_Class',ctrl:'COD_AREAFILTERCONTAINER',prop:'Class'},{av:'edtavCcod_area_Visible',ctrl:'vCCOD_AREA',prop:'Visible'}]}");
         setEventMetadata("LBLINDICADORESCODIGOFILTER.CLICK","{handler:'E131C1',iparms:[{av:'divIndicadorescodigofiltercontainer_Class',ctrl:'INDICADORESCODIGOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLINDICADORESCODIGOFILTER.CLICK",",oparms:[{av:'divIndicadorescodigofiltercontainer_Class',ctrl:'INDICADORESCODIGOFILTERCONTAINER',prop:'Class'},{av:'edtavCindicadorescodigo_Visible',ctrl:'vCINDICADORESCODIGO',prop:'Visible'}]}");
         setEventMetadata("LBLRFF_COMPRADAMESFILTER.CLICK","{handler:'E141C1',iparms:[{av:'divRff_compradamesfiltercontainer_Class',ctrl:'RFF_COMPRADAMESFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLRFF_COMPRADAMESFILTER.CLICK",",oparms:[{av:'divRff_compradamesfiltercontainer_Class',ctrl:'RFF_COMPRADAMESFILTERCONTAINER',prop:'Class'},{av:'edtavCrff_compradames_Visible',ctrl:'vCRFF_COMPRADAMES',prop:'Visible'}]}");
         setEventMetadata("LBLRFF_COMPRADAANOFILTER.CLICK","{handler:'E151C1',iparms:[{av:'divRff_compradaanofiltercontainer_Class',ctrl:'RFF_COMPRADAANOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLRFF_COMPRADAANOFILTER.CLICK",",oparms:[{av:'divRff_compradaanofiltercontainer_Class',ctrl:'RFF_COMPRADAANOFILTERCONTAINER',prop:'Class'},{av:'edtavCrff_compradaano_Visible',ctrl:'vCRFF_COMPRADAANO',prop:'Visible'}]}");
         setEventMetadata("LBLRFF_COMPRAPRODUCUPFILTER.CLICK","{handler:'E161C1',iparms:[{av:'divRff_compraproducupfiltercontainer_Class',ctrl:'RFF_COMPRAPRODUCUPFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLRFF_COMPRAPRODUCUPFILTER.CLICK",",oparms:[{av:'divRff_compraproducupfiltercontainer_Class',ctrl:'RFF_COMPRAPRODUCUPFILTERCONTAINER',prop:'Class'},{av:'edtavCrff_compraproducup_Visible',ctrl:'vCRFF_COMPRAPRODUCUP',prop:'Visible'}]}");
         setEventMetadata("LBLRFF_COMPRATONFILTER.CLICK","{handler:'E171C1',iparms:[{av:'divRff_compratonfiltercontainer_Class',ctrl:'RFF_COMPRATONFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLRFF_COMPRATONFILTER.CLICK",",oparms:[{av:'divRff_compratonfiltercontainer_Class',ctrl:'RFF_COMPRATONFILTERCONTAINER',prop:'Class'},{av:'edtavCrff_compraton_Visible',ctrl:'vCRFF_COMPRATON',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E211C2',iparms:[{av:'A86RFF_COMPRADAFecha',fld:'RFF_COMPRADAFECHA',pic:'',hsh:true},{av:'A5Cod_Area',fld:'COD_AREA',pic:'',hsh:true},{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:'',hsh:true},{av:'A87RFF_COMPRADAMes',fld:'RFF_COMPRADAMES',pic:'ZZZ9',hsh:true},{av:'A88RFF_COMPRADAAno',fld:'RFF_COMPRADAANO',pic:'ZZZ9',hsh:true},{av:'A89RFF_COMPRAPRODUCUP',fld:'RFF_COMPRAPRODUCUP',pic:'',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pRFF_COMPRADAFecha',fld:'vPRFF_COMPRADAFECHA',pic:''},{av:'AV14pCod_Area',fld:'vPCOD_AREA',pic:''},{av:'AV15pIndicadoresCodigo',fld:'vPINDICADORESCODIGO',pic:''},{av:'AV16pRFF_COMPRADAMes',fld:'vPRFF_COMPRADAMES',pic:'ZZZ9'},{av:'AV17pRFF_COMPRADAAno',fld:'vPRFF_COMPRADAANO',pic:'ZZZ9'},{av:'AV18pRFF_COMPRAPRODUCUP',fld:'vPRFF_COMPRAPRODUCUP',pic:''}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cRFF_COMPRADAFecha',fld:'vCRFF_COMPRADAFECHA',pic:''},{av:'AV7cCod_Area',fld:'vCCOD_AREA',pic:''},{av:'AV8cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV9cRFF_COMPRADAMes',fld:'vCRFF_COMPRADAMES',pic:'ZZZ9'},{av:'AV10cRFF_COMPRADAAno',fld:'vCRFF_COMPRADAANO',pic:'ZZZ9'},{av:'AV11cRFF_COMPRAPRODUCUP',fld:'vCRFF_COMPRAPRODUCUP',pic:''},{av:'AV12cRFF_COMPRATON',fld:'vCRFF_COMPRATON',pic:'ZZZZZZZZ9.99'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cRFF_COMPRADAFecha',fld:'vCRFF_COMPRADAFECHA',pic:''},{av:'AV7cCod_Area',fld:'vCCOD_AREA',pic:''},{av:'AV8cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV9cRFF_COMPRADAMes',fld:'vCRFF_COMPRADAMES',pic:'ZZZ9'},{av:'AV10cRFF_COMPRADAAno',fld:'vCRFF_COMPRADAANO',pic:'ZZZ9'},{av:'AV11cRFF_COMPRAPRODUCUP',fld:'vCRFF_COMPRAPRODUCUP',pic:''},{av:'AV12cRFF_COMPRATON',fld:'vCRFF_COMPRATON',pic:'ZZZZZZZZ9.99'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cRFF_COMPRADAFecha',fld:'vCRFF_COMPRADAFECHA',pic:''},{av:'AV7cCod_Area',fld:'vCCOD_AREA',pic:''},{av:'AV8cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV9cRFF_COMPRADAMes',fld:'vCRFF_COMPRADAMES',pic:'ZZZ9'},{av:'AV10cRFF_COMPRADAAno',fld:'vCRFF_COMPRADAANO',pic:'ZZZ9'},{av:'AV11cRFF_COMPRAPRODUCUP',fld:'vCRFF_COMPRAPRODUCUP',pic:''},{av:'AV12cRFF_COMPRATON',fld:'vCRFF_COMPRATON',pic:'ZZZZZZZZ9.99'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cRFF_COMPRADAFecha',fld:'vCRFF_COMPRADAFECHA',pic:''},{av:'AV7cCod_Area',fld:'vCCOD_AREA',pic:''},{av:'AV8cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV9cRFF_COMPRADAMes',fld:'vCRFF_COMPRADAMES',pic:'ZZZ9'},{av:'AV10cRFF_COMPRADAAno',fld:'vCRFF_COMPRADAANO',pic:'ZZZ9'},{av:'AV11cRFF_COMPRAPRODUCUP',fld:'vCRFF_COMPRAPRODUCUP',pic:''},{av:'AV12cRFF_COMPRATON',fld:'vCRFF_COMPRATON',pic:'ZZZZZZZZ9.99'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CRFF_COMPRADAFECHA","{handler:'Validv_Crff_compradafecha',iparms:[]");
         setEventMetadata("VALIDV_CRFF_COMPRADAFECHA",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Rff_compraproducup',iparms:[]");
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
         AV13pRFF_COMPRADAFecha = DateTime.MinValue;
         AV14pCod_Area = "";
         AV15pIndicadoresCodigo = "";
         AV18pRFF_COMPRAPRODUCUP = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV6cRFF_COMPRADAFecha = DateTime.MinValue;
         AV7cCod_Area = "";
         AV8cIndicadoresCodigo = "";
         AV11cRFF_COMPRAPRODUCUP = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblrff_compradafechafilter_Jsonclick = "";
         TempTags = "";
         lblLblcod_areafilter_Jsonclick = "";
         lblLblindicadorescodigofilter_Jsonclick = "";
         lblLblrff_compradamesfilter_Jsonclick = "";
         lblLblrff_compradaanofilter_Jsonclick = "";
         lblLblrff_compraproducupfilter_Jsonclick = "";
         lblLblrff_compratonfilter_Jsonclick = "";
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
         A86RFF_COMPRADAFecha = DateTime.MinValue;
         A5Cod_Area = "";
         A4IndicadoresCodigo = "";
         A89RFF_COMPRAPRODUCUP = "";
         scmdbuf = "";
         lV7cCod_Area = "";
         lV8cIndicadoresCodigo = "";
         lV11cRFF_COMPRAPRODUCUP = "";
         H001C2_A89RFF_COMPRAPRODUCUP = new string[] {""} ;
         H001C2_A88RFF_COMPRADAAno = new short[1] ;
         H001C2_A238RFF_COMPRATON = new decimal[1] ;
         H001C2_n238RFF_COMPRATON = new bool[] {false} ;
         H001C2_A87RFF_COMPRADAMes = new short[1] ;
         H001C2_A4IndicadoresCodigo = new string[] {""} ;
         H001C2_A5Cod_Area = new string[] {""} ;
         H001C2_A86RFF_COMPRADAFecha = new DateTime[] {DateTime.MinValue} ;
         H001C3_AGRID1_nRecordCount = new long[1] ;
         AV19ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0160__default(),
            new Object[][] {
                new Object[] {
               H001C2_A89RFF_COMPRAPRODUCUP, H001C2_A88RFF_COMPRADAAno, H001C2_A238RFF_COMPRATON, H001C2_n238RFF_COMPRATON, H001C2_A87RFF_COMPRADAMes, H001C2_A4IndicadoresCodigo, H001C2_A5Cod_Area, H001C2_A86RFF_COMPRADAFecha
               }
               , new Object[] {
               H001C3_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV16pRFF_COMPRADAMes ;
      private short AV17pRFF_COMPRADAAno ;
      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV9cRFF_COMPRADAMes ;
      private short AV10cRFF_COMPRADAAno ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A87RFF_COMPRADAMes ;
      private short A88RFF_COMPRADAAno ;
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
      private int edtavCrff_compradafecha_Enabled ;
      private int edtavCcod_area_Visible ;
      private int edtavCcod_area_Enabled ;
      private int edtavCindicadorescodigo_Visible ;
      private int edtavCindicadorescodigo_Enabled ;
      private int edtavCrff_compradames_Enabled ;
      private int edtavCrff_compradames_Visible ;
      private int edtavCrff_compradaano_Enabled ;
      private int edtavCrff_compradaano_Visible ;
      private int edtavCrff_compraproducup_Visible ;
      private int edtavCrff_compraproducup_Enabled ;
      private int edtavCrff_compraton_Enabled ;
      private int edtavCrff_compraton_Visible ;
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
      private decimal AV12cRFF_COMPRATON ;
      private decimal A238RFF_COMPRATON ;
      private string AV18pRFF_COMPRAPRODUCUP ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divRff_compradafechafiltercontainer_Class ;
      private string divCod_areafiltercontainer_Class ;
      private string divIndicadorescodigofiltercontainer_Class ;
      private string divRff_compradamesfiltercontainer_Class ;
      private string divRff_compradaanofiltercontainer_Class ;
      private string divRff_compraproducupfiltercontainer_Class ;
      private string divRff_compratonfiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_84_idx="0001" ;
      private string AV11cRFF_COMPRAPRODUCUP ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divRff_compradafechafiltercontainer_Internalname ;
      private string lblLblrff_compradafechafilter_Internalname ;
      private string lblLblrff_compradafechafilter_Jsonclick ;
      private string edtavCrff_compradafecha_Internalname ;
      private string TempTags ;
      private string edtavCrff_compradafecha_Jsonclick ;
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
      private string divRff_compradamesfiltercontainer_Internalname ;
      private string lblLblrff_compradamesfilter_Internalname ;
      private string lblLblrff_compradamesfilter_Jsonclick ;
      private string edtavCrff_compradames_Internalname ;
      private string edtavCrff_compradames_Jsonclick ;
      private string divRff_compradaanofiltercontainer_Internalname ;
      private string lblLblrff_compradaanofilter_Internalname ;
      private string lblLblrff_compradaanofilter_Jsonclick ;
      private string edtavCrff_compradaano_Internalname ;
      private string edtavCrff_compradaano_Jsonclick ;
      private string divRff_compraproducupfiltercontainer_Internalname ;
      private string lblLblrff_compraproducupfilter_Internalname ;
      private string lblLblrff_compraproducupfilter_Jsonclick ;
      private string edtavCrff_compraproducup_Internalname ;
      private string edtavCrff_compraproducup_Jsonclick ;
      private string divRff_compratonfiltercontainer_Internalname ;
      private string lblLblrff_compratonfilter_Internalname ;
      private string lblLblrff_compratonfilter_Jsonclick ;
      private string edtavCrff_compraton_Internalname ;
      private string edtavCrff_compraton_Jsonclick ;
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
      private string edtRFF_COMPRADAFecha_Internalname ;
      private string edtCod_Area_Internalname ;
      private string edtIndicadoresCodigo_Internalname ;
      private string edtRFF_COMPRADAMes_Internalname ;
      private string edtRFF_COMPRATON_Internalname ;
      private string edtRFF_COMPRADAAno_Internalname ;
      private string A89RFF_COMPRAPRODUCUP ;
      private string edtRFF_COMPRAPRODUCUP_Internalname ;
      private string scmdbuf ;
      private string lV11cRFF_COMPRAPRODUCUP ;
      private string AV19ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtRFF_COMPRADAFecha_Jsonclick ;
      private string edtCod_Area_Jsonclick ;
      private string edtIndicadoresCodigo_Jsonclick ;
      private string edtRFF_COMPRADAMes_Jsonclick ;
      private string edtRFF_COMPRATON_Link ;
      private string edtRFF_COMPRATON_Jsonclick ;
      private string edtRFF_COMPRADAAno_Jsonclick ;
      private string edtRFF_COMPRAPRODUCUP_Jsonclick ;
      private string subGrid1_Header ;
      private DateTime AV13pRFF_COMPRADAFecha ;
      private DateTime AV6cRFF_COMPRADAFecha ;
      private DateTime A86RFF_COMPRADAFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool n238RFF_COMPRATON ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV14pCod_Area ;
      private string AV15pIndicadoresCodigo ;
      private string AV7cCod_Area ;
      private string AV8cIndicadoresCodigo ;
      private string AV22Linkselection_GXI ;
      private string A5Cod_Area ;
      private string A4IndicadoresCodigo ;
      private string lV7cCod_Area ;
      private string lV8cIndicadoresCodigo ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] H001C2_A89RFF_COMPRAPRODUCUP ;
      private short[] H001C2_A88RFF_COMPRADAAno ;
      private decimal[] H001C2_A238RFF_COMPRATON ;
      private bool[] H001C2_n238RFF_COMPRATON ;
      private short[] H001C2_A87RFF_COMPRADAMes ;
      private string[] H001C2_A4IndicadoresCodigo ;
      private string[] H001C2_A5Cod_Area ;
      private DateTime[] H001C2_A86RFF_COMPRADAFecha ;
      private long[] H001C3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private DateTime aP0_pRFF_COMPRADAFecha ;
      private string aP1_pCod_Area ;
      private string aP2_pIndicadoresCodigo ;
      private short aP3_pRFF_COMPRADAMes ;
      private short aP4_pRFF_COMPRADAAno ;
      private string aP5_pRFF_COMPRAPRODUCUP ;
      private GXWebForm Form ;
   }

   public class gx0160__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H001C2( IGxContext context ,
                                             decimal AV12cRFF_COMPRATON ,
                                             decimal A238RFF_COMPRATON ,
                                             string A5Cod_Area ,
                                             string AV7cCod_Area ,
                                             string A4IndicadoresCodigo ,
                                             string AV8cIndicadoresCodigo ,
                                             short A87RFF_COMPRADAMes ,
                                             short AV9cRFF_COMPRADAMes ,
                                             short A88RFF_COMPRADAAno ,
                                             short AV10cRFF_COMPRADAAno ,
                                             string A89RFF_COMPRAPRODUCUP ,
                                             string AV11cRFF_COMPRAPRODUCUP ,
                                             DateTime AV6cRFF_COMPRADAFecha )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [RFF_COMPRAPRODUCUP], [RFF_COMPRADAAno], [RFF_COMPRATON], [RFF_COMPRADAMes], [IndicadoresCodigo], [Cod_Area], [RFF_COMPRADAFecha]";
         sFromString = " FROM [RFF_COMPRADA]";
         sOrderString = "";
         AddWhere(sWhereString, "([RFF_COMPRADAFecha] >= @AV6cRFF_COMPRADAFecha)");
         AddWhere(sWhereString, "([Cod_Area] like @lV7cCod_Area)");
         AddWhere(sWhereString, "([IndicadoresCodigo] like @lV8cIndicadoresCodigo)");
         AddWhere(sWhereString, "([RFF_COMPRADAMes] >= @AV9cRFF_COMPRADAMes)");
         AddWhere(sWhereString, "([RFF_COMPRADAAno] >= @AV10cRFF_COMPRADAAno)");
         AddWhere(sWhereString, "([RFF_COMPRAPRODUCUP] like @lV11cRFF_COMPRAPRODUCUP)");
         if ( ! (Convert.ToDecimal(0)==AV12cRFF_COMPRATON) )
         {
            AddWhere(sWhereString, "([RFF_COMPRATON] >= @AV12cRFF_COMPRATON)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [RFF_COMPRADAFecha], [Cod_Area], [IndicadoresCodigo], [RFF_COMPRADAMes], [RFF_COMPRADAAno], [RFF_COMPRAPRODUCUP]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H001C3( IGxContext context ,
                                             decimal AV12cRFF_COMPRATON ,
                                             decimal A238RFF_COMPRATON ,
                                             string A5Cod_Area ,
                                             string AV7cCod_Area ,
                                             string A4IndicadoresCodigo ,
                                             string AV8cIndicadoresCodigo ,
                                             short A87RFF_COMPRADAMes ,
                                             short AV9cRFF_COMPRADAMes ,
                                             short A88RFF_COMPRADAAno ,
                                             short AV10cRFF_COMPRADAAno ,
                                             string A89RFF_COMPRAPRODUCUP ,
                                             string AV11cRFF_COMPRAPRODUCUP ,
                                             DateTime AV6cRFF_COMPRADAFecha )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [RFF_COMPRADA]";
         AddWhere(sWhereString, "([RFF_COMPRADAFecha] >= @AV6cRFF_COMPRADAFecha)");
         AddWhere(sWhereString, "([Cod_Area] like @lV7cCod_Area)");
         AddWhere(sWhereString, "([IndicadoresCodigo] like @lV8cIndicadoresCodigo)");
         AddWhere(sWhereString, "([RFF_COMPRADAMes] >= @AV9cRFF_COMPRADAMes)");
         AddWhere(sWhereString, "([RFF_COMPRADAAno] >= @AV10cRFF_COMPRADAAno)");
         AddWhere(sWhereString, "([RFF_COMPRAPRODUCUP] like @lV11cRFF_COMPRAPRODUCUP)");
         if ( ! (Convert.ToDecimal(0)==AV12cRFF_COMPRATON) )
         {
            AddWhere(sWhereString, "([RFF_COMPRATON] >= @AV12cRFF_COMPRATON)");
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
                     return conditional_H001C2(context, (decimal)dynConstraints[0] , (decimal)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (DateTime)dynConstraints[12] );
               case 1 :
                     return conditional_H001C3(context, (decimal)dynConstraints[0] , (decimal)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (DateTime)dynConstraints[12] );
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
          Object[] prmH001C2;
          prmH001C2 = new Object[] {
          new ParDef("@AV6cRFF_COMPRADAFecha",GXType.Date,8,0) ,
          new ParDef("@lV7cCod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@lV8cIndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@AV9cRFF_COMPRADAMes",GXType.Int16,4,0) ,
          new ParDef("@AV10cRFF_COMPRADAAno",GXType.Int16,4,0) ,
          new ParDef("@lV11cRFF_COMPRAPRODUCUP",GXType.NChar,20,0) ,
          new ParDef("@AV12cRFF_COMPRATON",GXType.Decimal,12,2) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH001C3;
          prmH001C3 = new Object[] {
          new ParDef("@AV6cRFF_COMPRADAFecha",GXType.Date,8,0) ,
          new ParDef("@lV7cCod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@lV8cIndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@AV9cRFF_COMPRADAMes",GXType.Int16,4,0) ,
          new ParDef("@AV10cRFF_COMPRADAAno",GXType.Int16,4,0) ,
          new ParDef("@lV11cRFF_COMPRAPRODUCUP",GXType.NChar,20,0) ,
          new ParDef("@AV12cRFF_COMPRATON",GXType.Decimal,12,2)
          };
          def= new CursorDef[] {
              new CursorDef("H001C2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001C2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H001C3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001C3,1, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
