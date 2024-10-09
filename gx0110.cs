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
   public class gx0110 : GXDataArea
   {
      public gx0110( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("IndicadroresPalmas", true);
      }

      public gx0110( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out DateTime aP0_pCOSTOTONRFFPRODUFecha ,
                           out short aP1_pCOSTOTONRFFPRODUMes ,
                           out short aP2_pCOSTOTONRFFPRODUAno ,
                           out string aP3_pCod_Area ,
                           out string aP4_pIndicadoresCodigo ,
                           out string aP5_pMOTIVOTONRFFcod )
      {
         this.AV12pCOSTOTONRFFPRODUFecha = DateTime.MinValue ;
         this.AV13pCOSTOTONRFFPRODUMes = 0 ;
         this.AV14pCOSTOTONRFFPRODUAno = 0 ;
         this.AV15pCod_Area = "" ;
         this.AV16pIndicadoresCodigo = "" ;
         this.AV17pMOTIVOTONRFFcod = "" ;
         executePrivate();
         aP0_pCOSTOTONRFFPRODUFecha=this.AV12pCOSTOTONRFFPRODUFecha;
         aP1_pCOSTOTONRFFPRODUMes=this.AV13pCOSTOTONRFFPRODUMes;
         aP2_pCOSTOTONRFFPRODUAno=this.AV14pCOSTOTONRFFPRODUAno;
         aP3_pCod_Area=this.AV15pCod_Area;
         aP4_pIndicadoresCodigo=this.AV16pIndicadoresCodigo;
         aP5_pMOTIVOTONRFFcod=this.AV17pMOTIVOTONRFFcod;
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
            gxfirstwebparm = GetFirstPar( "pCOSTOTONRFFPRODUFecha");
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
               gxfirstwebparm = GetFirstPar( "pCOSTOTONRFFPRODUFecha");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pCOSTOTONRFFPRODUFecha");
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
               AV12pCOSTOTONRFFPRODUFecha = context.localUtil.ParseDateParm( gxfirstwebparm);
               AssignAttri("", false, "AV12pCOSTOTONRFFPRODUFecha", context.localUtil.Format(AV12pCOSTOTONRFFPRODUFecha, "99/99/99"));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV13pCOSTOTONRFFPRODUMes = (short)(Math.Round(NumberUtil.Val( GetPar( "pCOSTOTONRFFPRODUMes"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13pCOSTOTONRFFPRODUMes", StringUtil.LTrimStr( (decimal)(AV13pCOSTOTONRFFPRODUMes), 4, 0));
                  AV14pCOSTOTONRFFPRODUAno = (short)(Math.Round(NumberUtil.Val( GetPar( "pCOSTOTONRFFPRODUAno"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV14pCOSTOTONRFFPRODUAno", StringUtil.LTrimStr( (decimal)(AV14pCOSTOTONRFFPRODUAno), 4, 0));
                  AV15pCod_Area = GetPar( "pCod_Area");
                  AssignAttri("", false, "AV15pCod_Area", AV15pCod_Area);
                  AV16pIndicadoresCodigo = GetPar( "pIndicadoresCodigo");
                  AssignAttri("", false, "AV16pIndicadoresCodigo", AV16pIndicadoresCodigo);
                  AV17pMOTIVOTONRFFcod = GetPar( "pMOTIVOTONRFFcod");
                  AssignAttri("", false, "AV17pMOTIVOTONRFFcod", AV17pMOTIVOTONRFFcod);
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
         AV6cCOSTOTONRFFPRODUFecha = context.localUtil.ParseDateParm( GetPar( "cCOSTOTONRFFPRODUFecha"));
         AV7cCOSTOTONRFFPRODUMes = (short)(Math.Round(NumberUtil.Val( GetPar( "cCOSTOTONRFFPRODUMes"), "."), 18, MidpointRounding.ToEven));
         AV8cCOSTOTONRFFPRODUAno = (short)(Math.Round(NumberUtil.Val( GetPar( "cCOSTOTONRFFPRODUAno"), "."), 18, MidpointRounding.ToEven));
         AV9cCod_Area = GetPar( "cCod_Area");
         AV10cIndicadoresCodigo = GetPar( "cIndicadoresCodigo");
         AV11cCOSTOTONRFFPRODUValor = NumberUtil.Val( GetPar( "cCOSTOTONRFFPRODUValor"), ".");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cCOSTOTONRFFPRODUFecha, AV7cCOSTOTONRFFPRODUMes, AV8cCOSTOTONRFFPRODUAno, AV9cCod_Area, AV10cIndicadoresCodigo, AV11cCOSTOTONRFFPRODUValor) ;
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
         PA152( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START152( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0110.aspx", new object[] {UrlEncode(DateTimeUtil.FormatDateParm(AV12pCOSTOTONRFFPRODUFecha)),UrlEncode(StringUtil.LTrimStr(AV13pCOSTOTONRFFPRODUMes,4,0)),UrlEncode(StringUtil.LTrimStr(AV14pCOSTOTONRFFPRODUAno,4,0)),UrlEncode(StringUtil.RTrim(AV15pCod_Area)),UrlEncode(StringUtil.RTrim(AV16pIndicadoresCodigo)),UrlEncode(StringUtil.RTrim(AV17pMOTIVOTONRFFcod))}, new string[] {"pCOSTOTONRFFPRODUFecha","pCOSTOTONRFFPRODUMes","pCOSTOTONRFFPRODUAno","pCod_Area","pIndicadoresCodigo","pMOTIVOTONRFFcod"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCCOSTOTONRFFPRODUFECHA", context.localUtil.Format(AV6cCOSTOTONRFFPRODUFecha, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vCCOSTOTONRFFPRODUMES", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cCOSTOTONRFFPRODUMes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCOSTOTONRFFPRODUANO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cCOSTOTONRFFPRODUAno), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCOD_AREA", AV9cCod_Area);
         GxWebStd.gx_hidden_field( context, "GXH_vCINDICADORESCODIGO", AV10cIndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "GXH_vCCOSTOTONRFFPRODUVALOR", StringUtil.LTrim( StringUtil.NToC( AV11cCOSTOTONRFFPRODUValor, 16, 2, ",", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_74", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_74), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPCOSTOTONRFFPRODUFECHA", context.localUtil.DToC( AV12pCOSTOTONRFFPRODUFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vPCOSTOTONRFFPRODUMES", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pCOSTOTONRFFPRODUMes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPCOSTOTONRFFPRODUANO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14pCOSTOTONRFFPRODUAno), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPCOD_AREA", AV15pCod_Area);
         GxWebStd.gx_hidden_field( context, "vPINDICADORESCODIGO", AV16pIndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "vPMOTIVOTONRFFCOD", AV17pMOTIVOTONRFFcod);
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "COSTOTONRFFPRODUFECHAFILTERCONTAINER_Class", StringUtil.RTrim( divCostotonrffprodufechafiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "COSTOTONRFFPRODUMESFILTERCONTAINER_Class", StringUtil.RTrim( divCostotonrffprodumesfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "COSTOTONRFFPRODUANOFILTERCONTAINER_Class", StringUtil.RTrim( divCostotonrffproduanofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "COD_AREAFILTERCONTAINER_Class", StringUtil.RTrim( divCod_areafiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "INDICADORESCODIGOFILTERCONTAINER_Class", StringUtil.RTrim( divIndicadorescodigofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "COSTOTONRFFPRODUVALORFILTERCONTAINER_Class", StringUtil.RTrim( divCostotonrffproduvalorfiltercontainer_Class));
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
            WE152( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT152( ) ;
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
         return formatLink("gx0110.aspx", new object[] {UrlEncode(DateTimeUtil.FormatDateParm(AV12pCOSTOTONRFFPRODUFecha)),UrlEncode(StringUtil.LTrimStr(AV13pCOSTOTONRFFPRODUMes,4,0)),UrlEncode(StringUtil.LTrimStr(AV14pCOSTOTONRFFPRODUAno,4,0)),UrlEncode(StringUtil.RTrim(AV15pCod_Area)),UrlEncode(StringUtil.RTrim(AV16pIndicadoresCodigo)),UrlEncode(StringUtil.RTrim(AV17pMOTIVOTONRFFcod))}, new string[] {"pCOSTOTONRFFPRODUFecha","pCOSTOTONRFFPRODUMes","pCOSTOTONRFFPRODUAno","pCod_Area","pIndicadoresCodigo","pMOTIVOTONRFFcod"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx0110" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List COSTOTONRFFPRODU" ;
      }

      protected void WB150( )
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
            GxWebStd.gx_div_start( context, divCostotonrffprodufechafiltercontainer_Internalname, 1, 0, "px", 0, "px", divCostotonrffprodufechafiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcostotonrffprodufechafilter_Internalname, "COSTOTONRFFPRODUFecha", "", "", lblLblcostotonrffprodufechafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11151_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0110.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcostotonrffprodufecha_Internalname, "COSTOTONRFFPRODUFecha", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_74_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCcostotonrffprodufecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCcostotonrffprodufecha_Internalname, context.localUtil.Format(AV6cCOSTOTONRFFPRODUFecha, "99/99/99"), context.localUtil.Format( AV6cCOSTOTONRFFPRODUFecha, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcostotonrffprodufecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCcostotonrffprodufecha_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx0110.htm");
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
            GxWebStd.gx_div_start( context, divCostotonrffprodumesfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCostotonrffprodumesfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcostotonrffprodumesfilter_Internalname, "COSTOTONRFFPRODUMes", "", "", lblLblcostotonrffprodumesfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12151_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0110.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcostotonrffprodumes_Internalname, "COSTOTONRFFPRODUMes", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcostotonrffprodumes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cCOSTOTONRFFPRODUMes), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCcostotonrffprodumes_Enabled!=0) ? context.localUtil.Format( (decimal)(AV7cCOSTOTONRFFPRODUMes), "ZZZ9") : context.localUtil.Format( (decimal)(AV7cCOSTOTONRFFPRODUMes), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcostotonrffprodumes_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcostotonrffprodumes_Visible, edtavCcostotonrffprodumes_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx0110.htm");
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
            GxWebStd.gx_div_start( context, divCostotonrffproduanofiltercontainer_Internalname, 1, 0, "px", 0, "px", divCostotonrffproduanofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcostotonrffproduanofilter_Internalname, "COSTOTONRFFPRODUAno", "", "", lblLblcostotonrffproduanofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13151_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0110.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcostotonrffproduano_Internalname, "COSTOTONRFFPRODUAno", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcostotonrffproduano_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cCOSTOTONRFFPRODUAno), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCcostotonrffproduano_Enabled!=0) ? context.localUtil.Format( (decimal)(AV8cCOSTOTONRFFPRODUAno), "ZZZ9") : context.localUtil.Format( (decimal)(AV8cCOSTOTONRFFPRODUAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcostotonrffproduano_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcostotonrffproduano_Visible, edtavCcostotonrffproduano_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx0110.htm");
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
            GxWebStd.gx_label_ctrl( context, lblLblcod_areafilter_Internalname, "Cod_Area", "", "", lblLblcod_areafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14151_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0110.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavCcod_area_Internalname, AV9cCod_Area, StringUtil.RTrim( context.localUtil.Format( AV9cCod_Area, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcod_area_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcod_area_Visible, edtavCcod_area_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Gx0110.htm");
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
            GxWebStd.gx_label_ctrl( context, lblLblindicadorescodigofilter_Internalname, "Indicadores Codigo", "", "", lblLblindicadorescodigofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15151_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0110.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavCindicadorescodigo_Internalname, AV10cIndicadoresCodigo, StringUtil.RTrim( context.localUtil.Format( AV10cIndicadoresCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCindicadorescodigo_Jsonclick, 0, "Attribute", "", "", "", "", edtavCindicadorescodigo_Visible, edtavCindicadorescodigo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Gx0110.htm");
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
            GxWebStd.gx_div_start( context, divCostotonrffproduvalorfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCostotonrffproduvalorfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcostotonrffproduvalorfilter_Internalname, "COSTOTONRFFPRODUValor", "", "", lblLblcostotonrffproduvalorfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e16151_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0110.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcostotonrffproduvalor_Internalname, "COSTOTONRFFPRODUValor", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcostotonrffproduvalor_Internalname, StringUtil.LTrim( StringUtil.NToC( AV11cCOSTOTONRFFPRODUValor, 16, 2, ",", "")), StringUtil.LTrim( ((edtavCcostotonrffproduvalor_Enabled!=0) ? context.localUtil.Format( AV11cCOSTOTONRFFPRODUValor, "ZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV11cCOSTOTONRFFPRODUValor, "ZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcostotonrffproduvalor_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcostotonrffproduvalor_Visible, edtavCcostotonrffproduvalor_Enabled, 0, "text", "", 16, "chr", 1, "row", 16, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx0110.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e17151_client"+"'", TempTags, "", 2, "HLP_Gx0110.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0110.htm");
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

      protected void START152( )
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
            Form.Meta.addItem("description", "Selection List COSTOTONRFFPRODU", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP150( ) ;
      }

      protected void WS152( )
      {
         START152( ) ;
         EVT152( ) ;
      }

      protected void EVT152( )
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
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV21Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_74_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A77COSTOTONRFFPRODUFecha = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtCOSTOTONRFFPRODUFecha_Internalname), 0));
                              A78COSTOTONRFFPRODUMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCOSTOTONRFFPRODUMes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A79COSTOTONRFFPRODUAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCOSTOTONRFFPRODUAno_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A5Cod_Area = cgiGet( edtCod_Area_Internalname);
                              A196COSTOTONRFFPRODUValor = context.localUtil.CToN( cgiGet( edtCOSTOTONRFFPRODUValor_Internalname), ",", ".");
                              A4IndicadoresCodigo = cgiGet( edtIndicadoresCodigo_Internalname);
                              A65MOTIVOTONRFFcod = cgiGet( edtMOTIVOTONRFFcod_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E18152 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E19152 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Ccostotonrffprodufecha Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCCOSTOTONRFFPRODUFECHA"), 0) != AV6cCOSTOTONRFFPRODUFecha )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccostotonrffprodumes Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCOSTOTONRFFPRODUMES"), ",", ".") != Convert.ToDecimal( AV7cCOSTOTONRFFPRODUMes )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccostotonrffproduano Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCOSTOTONRFFPRODUANO"), ",", ".") != Convert.ToDecimal( AV8cCOSTOTONRFFPRODUAno )) )
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
                                       /* Set Refresh If Ccostotonrffproduvalor Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCCOSTOTONRFFPRODUVALOR"), ",", ".") != AV11cCOSTOTONRFFPRODUValor )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E20152 ();
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

      protected void WE152( )
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

      protected void PA152( )
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
                                        DateTime AV6cCOSTOTONRFFPRODUFecha ,
                                        short AV7cCOSTOTONRFFPRODUMes ,
                                        short AV8cCOSTOTONRFFPRODUAno ,
                                        string AV9cCod_Area ,
                                        string AV10cIndicadoresCodigo ,
                                        decimal AV11cCOSTOTONRFFPRODUValor )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF152( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_COSTOTONRFFPRODUFECHA", GetSecureSignedToken( "", A77COSTOTONRFFPRODUFecha, context));
         GxWebStd.gx_hidden_field( context, "COSTOTONRFFPRODUFECHA", context.localUtil.Format(A77COSTOTONRFFPRODUFecha, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "gxhash_COSTOTONRFFPRODUMES", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A78COSTOTONRFFPRODUMes), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "COSTOTONRFFPRODUMES", StringUtil.LTrim( StringUtil.NToC( (decimal)(A78COSTOTONRFFPRODUMes), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_COSTOTONRFFPRODUANO", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A79COSTOTONRFFPRODUAno), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "COSTOTONRFFPRODUANO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A79COSTOTONRFFPRODUAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_COD_AREA", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A5Cod_Area, "")), context));
         GxWebStd.gx_hidden_field( context, "COD_AREA", A5Cod_Area);
         GxWebStd.gx_hidden_field( context, "gxhash_INDICADORESCODIGO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A4IndicadoresCodigo, "")), context));
         GxWebStd.gx_hidden_field( context, "INDICADORESCODIGO", A4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "gxhash_MOTIVOTONRFFCOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A65MOTIVOTONRFFcod, "")), context));
         GxWebStd.gx_hidden_field( context, "MOTIVOTONRFFCOD", A65MOTIVOTONRFFcod);
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
         RF152( ) ;
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

      protected void RF152( )
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
                                                 AV11cCOSTOTONRFFPRODUValor ,
                                                 A196COSTOTONRFFPRODUValor ,
                                                 A5Cod_Area ,
                                                 AV9cCod_Area ,
                                                 A4IndicadoresCodigo ,
                                                 AV10cIndicadoresCodigo ,
                                                 AV6cCOSTOTONRFFPRODUFecha ,
                                                 AV7cCOSTOTONRFFPRODUMes ,
                                                 AV8cCOSTOTONRFFPRODUAno } ,
                                                 new int[]{
                                                 TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            lV9cCod_Area = StringUtil.Concat( StringUtil.RTrim( AV9cCod_Area), "%", "");
            lV10cIndicadoresCodigo = StringUtil.Concat( StringUtil.RTrim( AV10cIndicadoresCodigo), "%", "");
            /* Using cursor H00152 */
            pr_default.execute(0, new Object[] {AV6cCOSTOTONRFFPRODUFecha, AV7cCOSTOTONRFFPRODUMes, AV8cCOSTOTONRFFPRODUAno, lV9cCod_Area, lV10cIndicadoresCodigo, AV11cCOSTOTONRFFPRODUValor, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_74_idx = 1;
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A65MOTIVOTONRFFcod = H00152_A65MOTIVOTONRFFcod[0];
               A4IndicadoresCodigo = H00152_A4IndicadoresCodigo[0];
               A196COSTOTONRFFPRODUValor = H00152_A196COSTOTONRFFPRODUValor[0];
               A5Cod_Area = H00152_A5Cod_Area[0];
               A79COSTOTONRFFPRODUAno = H00152_A79COSTOTONRFFPRODUAno[0];
               A78COSTOTONRFFPRODUMes = H00152_A78COSTOTONRFFPRODUMes[0];
               A77COSTOTONRFFPRODUFecha = H00152_A77COSTOTONRFFPRODUFecha[0];
               /* Execute user event: Load */
               E19152 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 74;
            WB150( ) ;
         }
         bGXsfl_74_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes152( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_COSTOTONRFFPRODUFECHA"+"_"+sGXsfl_74_idx, GetSecureSignedToken( sGXsfl_74_idx, A77COSTOTONRFFPRODUFecha, context));
         GxWebStd.gx_hidden_field( context, "gxhash_COSTOTONRFFPRODUMES"+"_"+sGXsfl_74_idx, GetSecureSignedToken( sGXsfl_74_idx, context.localUtil.Format( (decimal)(A78COSTOTONRFFPRODUMes), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_COSTOTONRFFPRODUANO"+"_"+sGXsfl_74_idx, GetSecureSignedToken( sGXsfl_74_idx, context.localUtil.Format( (decimal)(A79COSTOTONRFFPRODUAno), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_COD_AREA"+"_"+sGXsfl_74_idx, GetSecureSignedToken( sGXsfl_74_idx, StringUtil.RTrim( context.localUtil.Format( A5Cod_Area, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_INDICADORESCODIGO"+"_"+sGXsfl_74_idx, GetSecureSignedToken( sGXsfl_74_idx, StringUtil.RTrim( context.localUtil.Format( A4IndicadoresCodigo, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_MOTIVOTONRFFCOD"+"_"+sGXsfl_74_idx, GetSecureSignedToken( sGXsfl_74_idx, StringUtil.RTrim( context.localUtil.Format( A65MOTIVOTONRFFcod, "")), context));
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
                                              AV11cCOSTOTONRFFPRODUValor ,
                                              A196COSTOTONRFFPRODUValor ,
                                              A5Cod_Area ,
                                              AV9cCod_Area ,
                                              A4IndicadoresCodigo ,
                                              AV10cIndicadoresCodigo ,
                                              AV6cCOSTOTONRFFPRODUFecha ,
                                              AV7cCOSTOTONRFFPRODUMes ,
                                              AV8cCOSTOTONRFFPRODUAno } ,
                                              new int[]{
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV9cCod_Area = StringUtil.Concat( StringUtil.RTrim( AV9cCod_Area), "%", "");
         lV10cIndicadoresCodigo = StringUtil.Concat( StringUtil.RTrim( AV10cIndicadoresCodigo), "%", "");
         /* Using cursor H00153 */
         pr_default.execute(1, new Object[] {AV6cCOSTOTONRFFPRODUFecha, AV7cCOSTOTONRFFPRODUMes, AV8cCOSTOTONRFFPRODUAno, lV9cCod_Area, lV10cIndicadoresCodigo, AV11cCOSTOTONRFFPRODUValor});
         GRID1_nRecordCount = H00153_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCOSTOTONRFFPRODUFecha, AV7cCOSTOTONRFFPRODUMes, AV8cCOSTOTONRFFPRODUAno, AV9cCod_Area, AV10cIndicadoresCodigo, AV11cCOSTOTONRFFPRODUValor) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCOSTOTONRFFPRODUFecha, AV7cCOSTOTONRFFPRODUMes, AV8cCOSTOTONRFFPRODUAno, AV9cCod_Area, AV10cIndicadoresCodigo, AV11cCOSTOTONRFFPRODUValor) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCOSTOTONRFFPRODUFecha, AV7cCOSTOTONRFFPRODUMes, AV8cCOSTOTONRFFPRODUAno, AV9cCod_Area, AV10cIndicadoresCodigo, AV11cCOSTOTONRFFPRODUValor) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCOSTOTONRFFPRODUFecha, AV7cCOSTOTONRFFPRODUMes, AV8cCOSTOTONRFFPRODUAno, AV9cCod_Area, AV10cIndicadoresCodigo, AV11cCOSTOTONRFFPRODUValor) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cCOSTOTONRFFPRODUFecha, AV7cCOSTOTONRFFPRODUMes, AV8cCOSTOTONRFFPRODUAno, AV9cCod_Area, AV10cIndicadoresCodigo, AV11cCOSTOTONRFFPRODUValor) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP150( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E18152 ();
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
            if ( context.localUtil.VCDate( cgiGet( edtavCcostotonrffprodufecha_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"COSTOTONRFFPRODUFecha"}), 1, "vCCOSTOTONRFFPRODUFECHA");
               GX_FocusControl = edtavCcostotonrffprodufecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cCOSTOTONRFFPRODUFecha = DateTime.MinValue;
               AssignAttri("", false, "AV6cCOSTOTONRFFPRODUFecha", context.localUtil.Format(AV6cCOSTOTONRFFPRODUFecha, "99/99/99"));
            }
            else
            {
               AV6cCOSTOTONRFFPRODUFecha = context.localUtil.CToD( cgiGet( edtavCcostotonrffprodufecha_Internalname), 2);
               AssignAttri("", false, "AV6cCOSTOTONRFFPRODUFecha", context.localUtil.Format(AV6cCOSTOTONRFFPRODUFecha, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcostotonrffprodumes_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcostotonrffprodumes_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCOSTOTONRFFPRODUMES");
               GX_FocusControl = edtavCcostotonrffprodumes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7cCOSTOTONRFFPRODUMes = 0;
               AssignAttri("", false, "AV7cCOSTOTONRFFPRODUMes", StringUtil.LTrimStr( (decimal)(AV7cCOSTOTONRFFPRODUMes), 4, 0));
            }
            else
            {
               AV7cCOSTOTONRFFPRODUMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCcostotonrffprodumes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7cCOSTOTONRFFPRODUMes", StringUtil.LTrimStr( (decimal)(AV7cCOSTOTONRFFPRODUMes), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcostotonrffproduano_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcostotonrffproduano_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCOSTOTONRFFPRODUANO");
               GX_FocusControl = edtavCcostotonrffproduano_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cCOSTOTONRFFPRODUAno = 0;
               AssignAttri("", false, "AV8cCOSTOTONRFFPRODUAno", StringUtil.LTrimStr( (decimal)(AV8cCOSTOTONRFFPRODUAno), 4, 0));
            }
            else
            {
               AV8cCOSTOTONRFFPRODUAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCcostotonrffproduano_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV8cCOSTOTONRFFPRODUAno", StringUtil.LTrimStr( (decimal)(AV8cCOSTOTONRFFPRODUAno), 4, 0));
            }
            AV9cCod_Area = cgiGet( edtavCcod_area_Internalname);
            AssignAttri("", false, "AV9cCod_Area", AV9cCod_Area);
            AV10cIndicadoresCodigo = cgiGet( edtavCindicadorescodigo_Internalname);
            AssignAttri("", false, "AV10cIndicadoresCodigo", AV10cIndicadoresCodigo);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcostotonrffproduvalor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcostotonrffproduvalor_Internalname), ",", ".") > 9999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCOSTOTONRFFPRODUVALOR");
               GX_FocusControl = edtavCcostotonrffproduvalor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11cCOSTOTONRFFPRODUValor = 0;
               AssignAttri("", false, "AV11cCOSTOTONRFFPRODUValor", StringUtil.LTrimStr( AV11cCOSTOTONRFFPRODUValor, 16, 2));
            }
            else
            {
               AV11cCOSTOTONRFFPRODUValor = context.localUtil.CToN( cgiGet( edtavCcostotonrffproduvalor_Internalname), ",", ".");
               AssignAttri("", false, "AV11cCOSTOTONRFFPRODUValor", StringUtil.LTrimStr( AV11cCOSTOTONRFFPRODUValor, 16, 2));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vCCOSTOTONRFFPRODUFECHA"), 2) ) != DateTimeUtil.ResetTime ( AV6cCOSTOTONRFFPRODUFecha ) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCOSTOTONRFFPRODUMES"), ",", ".") != Convert.ToDecimal( AV7cCOSTOTONRFFPRODUMes )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCOSTOTONRFFPRODUANO"), ",", ".") != Convert.ToDecimal( AV8cCOSTOTONRFFPRODUAno )) )
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
            if ( context.localUtil.CToN( cgiGet( "GXH_vCCOSTOTONRFFPRODUVALOR"), ",", ".") != AV11cCOSTOTONRFFPRODUValor )
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
         E18152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E18152( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Lista de Selección %1", "COSTOTONRFFPRODU", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV18ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E19152( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "selectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV21Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )));
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
         E20152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E20152( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV12pCOSTOTONRFFPRODUFecha = A77COSTOTONRFFPRODUFecha;
         AssignAttri("", false, "AV12pCOSTOTONRFFPRODUFecha", context.localUtil.Format(AV12pCOSTOTONRFFPRODUFecha, "99/99/99"));
         AV13pCOSTOTONRFFPRODUMes = A78COSTOTONRFFPRODUMes;
         AssignAttri("", false, "AV13pCOSTOTONRFFPRODUMes", StringUtil.LTrimStr( (decimal)(AV13pCOSTOTONRFFPRODUMes), 4, 0));
         AV14pCOSTOTONRFFPRODUAno = A79COSTOTONRFFPRODUAno;
         AssignAttri("", false, "AV14pCOSTOTONRFFPRODUAno", StringUtil.LTrimStr( (decimal)(AV14pCOSTOTONRFFPRODUAno), 4, 0));
         AV15pCod_Area = A5Cod_Area;
         AssignAttri("", false, "AV15pCod_Area", AV15pCod_Area);
         AV16pIndicadoresCodigo = A4IndicadoresCodigo;
         AssignAttri("", false, "AV16pIndicadoresCodigo", AV16pIndicadoresCodigo);
         AV17pMOTIVOTONRFFcod = A65MOTIVOTONRFFcod;
         AssignAttri("", false, "AV17pMOTIVOTONRFFcod", AV17pMOTIVOTONRFFcod);
         context.setWebReturnParms(new Object[] {context.localUtil.Format( AV12pCOSTOTONRFFPRODUFecha, "99/99/99"),(short)AV13pCOSTOTONRFFPRODUMes,(short)AV14pCOSTOTONRFFPRODUAno,(string)AV15pCod_Area,(string)AV16pIndicadoresCodigo,(string)AV17pMOTIVOTONRFFcod});
         context.setWebReturnParmsMetadata(new Object[] {"AV12pCOSTOTONRFFPRODUFecha","AV13pCOSTOTONRFFPRODUMes","AV14pCOSTOTONRFFPRODUAno","AV15pCod_Area","AV16pIndicadoresCodigo","AV17pMOTIVOTONRFFcod"});
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
         AV12pCOSTOTONRFFPRODUFecha = (DateTime)getParm(obj,0);
         AssignAttri("", false, "AV12pCOSTOTONRFFPRODUFecha", context.localUtil.Format(AV12pCOSTOTONRFFPRODUFecha, "99/99/99"));
         AV13pCOSTOTONRFFPRODUMes = Convert.ToInt16(getParm(obj,1));
         AssignAttri("", false, "AV13pCOSTOTONRFFPRODUMes", StringUtil.LTrimStr( (decimal)(AV13pCOSTOTONRFFPRODUMes), 4, 0));
         AV14pCOSTOTONRFFPRODUAno = Convert.ToInt16(getParm(obj,2));
         AssignAttri("", false, "AV14pCOSTOTONRFFPRODUAno", StringUtil.LTrimStr( (decimal)(AV14pCOSTOTONRFFPRODUAno), 4, 0));
         AV15pCod_Area = (string)getParm(obj,3);
         AssignAttri("", false, "AV15pCod_Area", AV15pCod_Area);
         AV16pIndicadoresCodigo = (string)getParm(obj,4);
         AssignAttri("", false, "AV16pIndicadoresCodigo", AV16pIndicadoresCodigo);
         AV17pMOTIVOTONRFFcod = (string)getParm(obj,5);
         AssignAttri("", false, "AV17pMOTIVOTONRFFcod", AV17pMOTIVOTONRFFcod);
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
         PA152( ) ;
         WS152( ) ;
         WE152( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20247231025245", true, true);
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
         context.AddJavascriptSource("gx0110.js", "?20247231025245", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_idx;
         edtCOSTOTONRFFPRODUFecha_Internalname = "COSTOTONRFFPRODUFECHA_"+sGXsfl_74_idx;
         edtCOSTOTONRFFPRODUMes_Internalname = "COSTOTONRFFPRODUMES_"+sGXsfl_74_idx;
         edtCOSTOTONRFFPRODUAno_Internalname = "COSTOTONRFFPRODUANO_"+sGXsfl_74_idx;
         edtCod_Area_Internalname = "COD_AREA_"+sGXsfl_74_idx;
         edtCOSTOTONRFFPRODUValor_Internalname = "COSTOTONRFFPRODUVALOR_"+sGXsfl_74_idx;
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO_"+sGXsfl_74_idx;
         edtMOTIVOTONRFFcod_Internalname = "MOTIVOTONRFFCOD_"+sGXsfl_74_idx;
      }

      protected void SubsflControlProps_fel_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_fel_idx;
         edtCOSTOTONRFFPRODUFecha_Internalname = "COSTOTONRFFPRODUFECHA_"+sGXsfl_74_fel_idx;
         edtCOSTOTONRFFPRODUMes_Internalname = "COSTOTONRFFPRODUMES_"+sGXsfl_74_fel_idx;
         edtCOSTOTONRFFPRODUAno_Internalname = "COSTOTONRFFPRODUANO_"+sGXsfl_74_fel_idx;
         edtCod_Area_Internalname = "COD_AREA_"+sGXsfl_74_fel_idx;
         edtCOSTOTONRFFPRODUValor_Internalname = "COSTOTONRFFPRODUVALOR_"+sGXsfl_74_fel_idx;
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO_"+sGXsfl_74_fel_idx;
         edtMOTIVOTONRFFcod_Internalname = "MOTIVOTONRFFCOD_"+sGXsfl_74_fel_idx;
      }

      protected void sendrow_742( )
      {
         SubsflControlProps_742( ) ;
         WB150( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( context.localUtil.Format(A77COSTOTONRFFPRODUFecha, "99/99/99"))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A78COSTOTONRFFPRODUMes), 4, 0, ",", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A79COSTOTONRFFPRODUAno), 4, 0, ",", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( A5Cod_Area)+"'"+", "+"'"+GXUtil.EncodeJSConstant( A4IndicadoresCodigo)+"'"+", "+"'"+GXUtil.EncodeJSConstant( A65MOTIVOTONRFFcod)+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_74_Refreshing);
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
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCOSTOTONRFFPRODUFecha_Internalname,context.localUtil.Format(A77COSTOTONRFFPRODUFecha, "99/99/99"),context.localUtil.Format( A77COSTOTONRFFPRODUFecha, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCOSTOTONRFFPRODUFecha_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCOSTOTONRFFPRODUMes_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A78COSTOTONRFFPRODUMes), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A78COSTOTONRFFPRODUMes), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCOSTOTONRFFPRODUMes_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCOSTOTONRFFPRODUAno_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A79COSTOTONRFFPRODUAno), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A79COSTOTONRFFPRODUAno), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCOSTOTONRFFPRODUAno_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
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
            edtCOSTOTONRFFPRODUValor_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( context.localUtil.Format(A77COSTOTONRFFPRODUFecha, "99/99/99"))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A78COSTOTONRFFPRODUMes), 4, 0, ",", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A79COSTOTONRFFPRODUAno), 4, 0, ",", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( A5Cod_Area)+"'"+", "+"'"+GXUtil.EncodeJSConstant( A4IndicadoresCodigo)+"'"+", "+"'"+GXUtil.EncodeJSConstant( A65MOTIVOTONRFFcod)+"'"+"]);";
            AssignProp("", false, edtCOSTOTONRFFPRODUValor_Internalname, "Link", edtCOSTOTONRFFPRODUValor_Link, !bGXsfl_74_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCOSTOTONRFFPRODUValor_Internalname,StringUtil.LTrim( StringUtil.NToC( A196COSTOTONRFFPRODUValor, 16, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A196COSTOTONRFFPRODUValor, "ZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtCOSTOTONRFFPRODUValor_Link,(string)"",(string)"",(string)"",(string)edtCOSTOTONRFFPRODUValor_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)16,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIndicadoresCodigo_Internalname,(string)A4IndicadoresCodigo,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIndicadoresCodigo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMOTIVOTONRFFcod_Internalname,(string)A65MOTIVOTONRFFcod,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMOTIVOTONRFFcod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)140,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            send_integrity_lvl_hashes152( ) ;
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
            context.SendWebValue( "COSTOTONRFFPRODUFecha") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "COSTOTONRFFPRODUMes") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "COSTOTONRFFPRODUAno") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Cod_Area") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "COSTOTONRFFPRODUValor") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Indicadores Codigo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "MOTIVOTONRFFcod") ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A77COSTOTONRFFPRODUFecha, "99/99/99")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A78COSTOTONRFFPRODUMes), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A79COSTOTONRFFPRODUAno), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A5Cod_Area));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A196COSTOTONRFFPRODUValor, 16, 2, ".", ""))));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtCOSTOTONRFFPRODUValor_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A4IndicadoresCodigo));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A65MOTIVOTONRFFcod));
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
         lblLblcostotonrffprodufechafilter_Internalname = "LBLCOSTOTONRFFPRODUFECHAFILTER";
         edtavCcostotonrffprodufecha_Internalname = "vCCOSTOTONRFFPRODUFECHA";
         divCostotonrffprodufechafiltercontainer_Internalname = "COSTOTONRFFPRODUFECHAFILTERCONTAINER";
         lblLblcostotonrffprodumesfilter_Internalname = "LBLCOSTOTONRFFPRODUMESFILTER";
         edtavCcostotonrffprodumes_Internalname = "vCCOSTOTONRFFPRODUMES";
         divCostotonrffprodumesfiltercontainer_Internalname = "COSTOTONRFFPRODUMESFILTERCONTAINER";
         lblLblcostotonrffproduanofilter_Internalname = "LBLCOSTOTONRFFPRODUANOFILTER";
         edtavCcostotonrffproduano_Internalname = "vCCOSTOTONRFFPRODUANO";
         divCostotonrffproduanofiltercontainer_Internalname = "COSTOTONRFFPRODUANOFILTERCONTAINER";
         lblLblcod_areafilter_Internalname = "LBLCOD_AREAFILTER";
         edtavCcod_area_Internalname = "vCCOD_AREA";
         divCod_areafiltercontainer_Internalname = "COD_AREAFILTERCONTAINER";
         lblLblindicadorescodigofilter_Internalname = "LBLINDICADORESCODIGOFILTER";
         edtavCindicadorescodigo_Internalname = "vCINDICADORESCODIGO";
         divIndicadorescodigofiltercontainer_Internalname = "INDICADORESCODIGOFILTERCONTAINER";
         lblLblcostotonrffproduvalorfilter_Internalname = "LBLCOSTOTONRFFPRODUVALORFILTER";
         edtavCcostotonrffproduvalor_Internalname = "vCCOSTOTONRFFPRODUVALOR";
         divCostotonrffproduvalorfiltercontainer_Internalname = "COSTOTONRFFPRODUVALORFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtCOSTOTONRFFPRODUFecha_Internalname = "COSTOTONRFFPRODUFECHA";
         edtCOSTOTONRFFPRODUMes_Internalname = "COSTOTONRFFPRODUMES";
         edtCOSTOTONRFFPRODUAno_Internalname = "COSTOTONRFFPRODUANO";
         edtCod_Area_Internalname = "COD_AREA";
         edtCOSTOTONRFFPRODUValor_Internalname = "COSTOTONRFFPRODUVALOR";
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO";
         edtMOTIVOTONRFFcod_Internalname = "MOTIVOTONRFFCOD";
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
         edtMOTIVOTONRFFcod_Jsonclick = "";
         edtIndicadoresCodigo_Jsonclick = "";
         edtCOSTOTONRFFPRODUValor_Jsonclick = "";
         edtCOSTOTONRFFPRODUValor_Link = "";
         edtCod_Area_Jsonclick = "";
         edtCOSTOTONRFFPRODUAno_Jsonclick = "";
         edtCOSTOTONRFFPRODUMes_Jsonclick = "";
         edtCOSTOTONRFFPRODUFecha_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtavCcostotonrffproduvalor_Jsonclick = "";
         edtavCcostotonrffproduvalor_Enabled = 1;
         edtavCcostotonrffproduvalor_Visible = 1;
         edtavCindicadorescodigo_Jsonclick = "";
         edtavCindicadorescodigo_Enabled = 1;
         edtavCindicadorescodigo_Visible = 1;
         edtavCcod_area_Jsonclick = "";
         edtavCcod_area_Enabled = 1;
         edtavCcod_area_Visible = 1;
         edtavCcostotonrffproduano_Jsonclick = "";
         edtavCcostotonrffproduano_Enabled = 1;
         edtavCcostotonrffproduano_Visible = 1;
         edtavCcostotonrffprodumes_Jsonclick = "";
         edtavCcostotonrffprodumes_Enabled = 1;
         edtavCcostotonrffprodumes_Visible = 1;
         edtavCcostotonrffprodufecha_Jsonclick = "";
         edtavCcostotonrffprodufecha_Enabled = 1;
         divCostotonrffproduvalorfiltercontainer_Class = "AdvancedContainerItem";
         divIndicadorescodigofiltercontainer_Class = "AdvancedContainerItem";
         divCod_areafiltercontainer_Class = "AdvancedContainerItem";
         divCostotonrffproduanofiltercontainer_Class = "AdvancedContainerItem";
         divCostotonrffprodumesfiltercontainer_Class = "AdvancedContainerItem";
         divCostotonrffprodufechafiltercontainer_Class = "AdvancedContainerItem";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List COSTOTONRFFPRODU";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCOSTOTONRFFPRODUFecha',fld:'vCCOSTOTONRFFPRODUFECHA',pic:''},{av:'AV7cCOSTOTONRFFPRODUMes',fld:'vCCOSTOTONRFFPRODUMES',pic:'ZZZ9'},{av:'AV8cCOSTOTONRFFPRODUAno',fld:'vCCOSTOTONRFFPRODUANO',pic:'ZZZ9'},{av:'AV9cCod_Area',fld:'vCCOD_AREA',pic:''},{av:'AV10cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV11cCOSTOTONRFFPRODUValor',fld:'vCCOSTOTONRFFPRODUVALOR',pic:'ZZZZZZZZZZZZ9.99'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E17151',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLCOSTOTONRFFPRODUFECHAFILTER.CLICK","{handler:'E11151',iparms:[{av:'divCostotonrffprodufechafiltercontainer_Class',ctrl:'COSTOTONRFFPRODUFECHAFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCOSTOTONRFFPRODUFECHAFILTER.CLICK",",oparms:[{av:'divCostotonrffprodufechafiltercontainer_Class',ctrl:'COSTOTONRFFPRODUFECHAFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLCOSTOTONRFFPRODUMESFILTER.CLICK","{handler:'E12151',iparms:[{av:'divCostotonrffprodumesfiltercontainer_Class',ctrl:'COSTOTONRFFPRODUMESFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCOSTOTONRFFPRODUMESFILTER.CLICK",",oparms:[{av:'divCostotonrffprodumesfiltercontainer_Class',ctrl:'COSTOTONRFFPRODUMESFILTERCONTAINER',prop:'Class'},{av:'edtavCcostotonrffprodumes_Visible',ctrl:'vCCOSTOTONRFFPRODUMES',prop:'Visible'}]}");
         setEventMetadata("LBLCOSTOTONRFFPRODUANOFILTER.CLICK","{handler:'E13151',iparms:[{av:'divCostotonrffproduanofiltercontainer_Class',ctrl:'COSTOTONRFFPRODUANOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCOSTOTONRFFPRODUANOFILTER.CLICK",",oparms:[{av:'divCostotonrffproduanofiltercontainer_Class',ctrl:'COSTOTONRFFPRODUANOFILTERCONTAINER',prop:'Class'},{av:'edtavCcostotonrffproduano_Visible',ctrl:'vCCOSTOTONRFFPRODUANO',prop:'Visible'}]}");
         setEventMetadata("LBLCOD_AREAFILTER.CLICK","{handler:'E14151',iparms:[{av:'divCod_areafiltercontainer_Class',ctrl:'COD_AREAFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCOD_AREAFILTER.CLICK",",oparms:[{av:'divCod_areafiltercontainer_Class',ctrl:'COD_AREAFILTERCONTAINER',prop:'Class'},{av:'edtavCcod_area_Visible',ctrl:'vCCOD_AREA',prop:'Visible'}]}");
         setEventMetadata("LBLINDICADORESCODIGOFILTER.CLICK","{handler:'E15151',iparms:[{av:'divIndicadorescodigofiltercontainer_Class',ctrl:'INDICADORESCODIGOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLINDICADORESCODIGOFILTER.CLICK",",oparms:[{av:'divIndicadorescodigofiltercontainer_Class',ctrl:'INDICADORESCODIGOFILTERCONTAINER',prop:'Class'},{av:'edtavCindicadorescodigo_Visible',ctrl:'vCINDICADORESCODIGO',prop:'Visible'}]}");
         setEventMetadata("LBLCOSTOTONRFFPRODUVALORFILTER.CLICK","{handler:'E16151',iparms:[{av:'divCostotonrffproduvalorfiltercontainer_Class',ctrl:'COSTOTONRFFPRODUVALORFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCOSTOTONRFFPRODUVALORFILTER.CLICK",",oparms:[{av:'divCostotonrffproduvalorfiltercontainer_Class',ctrl:'COSTOTONRFFPRODUVALORFILTERCONTAINER',prop:'Class'},{av:'edtavCcostotonrffproduvalor_Visible',ctrl:'vCCOSTOTONRFFPRODUVALOR',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E20152',iparms:[{av:'A77COSTOTONRFFPRODUFecha',fld:'COSTOTONRFFPRODUFECHA',pic:'',hsh:true},{av:'A78COSTOTONRFFPRODUMes',fld:'COSTOTONRFFPRODUMES',pic:'ZZZ9',hsh:true},{av:'A79COSTOTONRFFPRODUAno',fld:'COSTOTONRFFPRODUANO',pic:'ZZZ9',hsh:true},{av:'A5Cod_Area',fld:'COD_AREA',pic:'',hsh:true},{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:'',hsh:true},{av:'A65MOTIVOTONRFFcod',fld:'MOTIVOTONRFFCOD',pic:'',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV12pCOSTOTONRFFPRODUFecha',fld:'vPCOSTOTONRFFPRODUFECHA',pic:''},{av:'AV13pCOSTOTONRFFPRODUMes',fld:'vPCOSTOTONRFFPRODUMES',pic:'ZZZ9'},{av:'AV14pCOSTOTONRFFPRODUAno',fld:'vPCOSTOTONRFFPRODUANO',pic:'ZZZ9'},{av:'AV15pCod_Area',fld:'vPCOD_AREA',pic:''},{av:'AV16pIndicadoresCodigo',fld:'vPINDICADORESCODIGO',pic:''},{av:'AV17pMOTIVOTONRFFcod',fld:'vPMOTIVOTONRFFCOD',pic:''}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCOSTOTONRFFPRODUFecha',fld:'vCCOSTOTONRFFPRODUFECHA',pic:''},{av:'AV7cCOSTOTONRFFPRODUMes',fld:'vCCOSTOTONRFFPRODUMES',pic:'ZZZ9'},{av:'AV8cCOSTOTONRFFPRODUAno',fld:'vCCOSTOTONRFFPRODUANO',pic:'ZZZ9'},{av:'AV9cCod_Area',fld:'vCCOD_AREA',pic:''},{av:'AV10cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV11cCOSTOTONRFFPRODUValor',fld:'vCCOSTOTONRFFPRODUVALOR',pic:'ZZZZZZZZZZZZ9.99'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCOSTOTONRFFPRODUFecha',fld:'vCCOSTOTONRFFPRODUFECHA',pic:''},{av:'AV7cCOSTOTONRFFPRODUMes',fld:'vCCOSTOTONRFFPRODUMES',pic:'ZZZ9'},{av:'AV8cCOSTOTONRFFPRODUAno',fld:'vCCOSTOTONRFFPRODUANO',pic:'ZZZ9'},{av:'AV9cCod_Area',fld:'vCCOD_AREA',pic:''},{av:'AV10cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV11cCOSTOTONRFFPRODUValor',fld:'vCCOSTOTONRFFPRODUVALOR',pic:'ZZZZZZZZZZZZ9.99'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCOSTOTONRFFPRODUFecha',fld:'vCCOSTOTONRFFPRODUFECHA',pic:''},{av:'AV7cCOSTOTONRFFPRODUMes',fld:'vCCOSTOTONRFFPRODUMES',pic:'ZZZ9'},{av:'AV8cCOSTOTONRFFPRODUAno',fld:'vCCOSTOTONRFFPRODUANO',pic:'ZZZ9'},{av:'AV9cCod_Area',fld:'vCCOD_AREA',pic:''},{av:'AV10cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV11cCOSTOTONRFFPRODUValor',fld:'vCCOSTOTONRFFPRODUVALOR',pic:'ZZZZZZZZZZZZ9.99'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cCOSTOTONRFFPRODUFecha',fld:'vCCOSTOTONRFFPRODUFECHA',pic:''},{av:'AV7cCOSTOTONRFFPRODUMes',fld:'vCCOSTOTONRFFPRODUMES',pic:'ZZZ9'},{av:'AV8cCOSTOTONRFFPRODUAno',fld:'vCCOSTOTONRFFPRODUANO',pic:'ZZZ9'},{av:'AV9cCod_Area',fld:'vCCOD_AREA',pic:''},{av:'AV10cIndicadoresCodigo',fld:'vCINDICADORESCODIGO',pic:''},{av:'AV11cCOSTOTONRFFPRODUValor',fld:'vCCOSTOTONRFFPRODUVALOR',pic:'ZZZZZZZZZZZZ9.99'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CCOSTOTONRFFPRODUFECHA","{handler:'Validv_Ccostotonrffprodufecha',iparms:[]");
         setEventMetadata("VALIDV_CCOSTOTONRFFPRODUFECHA",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Motivotonrffcod',iparms:[]");
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
         AV12pCOSTOTONRFFPRODUFecha = DateTime.MinValue;
         AV15pCod_Area = "";
         AV16pIndicadoresCodigo = "";
         AV17pMOTIVOTONRFFcod = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV6cCOSTOTONRFFPRODUFecha = DateTime.MinValue;
         AV9cCod_Area = "";
         AV10cIndicadoresCodigo = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblcostotonrffprodufechafilter_Jsonclick = "";
         TempTags = "";
         lblLblcostotonrffprodumesfilter_Jsonclick = "";
         lblLblcostotonrffproduanofilter_Jsonclick = "";
         lblLblcod_areafilter_Jsonclick = "";
         lblLblindicadorescodigofilter_Jsonclick = "";
         lblLblcostotonrffproduvalorfilter_Jsonclick = "";
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
         A77COSTOTONRFFPRODUFecha = DateTime.MinValue;
         A5Cod_Area = "";
         A4IndicadoresCodigo = "";
         A65MOTIVOTONRFFcod = "";
         scmdbuf = "";
         lV9cCod_Area = "";
         lV10cIndicadoresCodigo = "";
         H00152_A65MOTIVOTONRFFcod = new string[] {""} ;
         H00152_A4IndicadoresCodigo = new string[] {""} ;
         H00152_A196COSTOTONRFFPRODUValor = new decimal[1] ;
         H00152_A5Cod_Area = new string[] {""} ;
         H00152_A79COSTOTONRFFPRODUAno = new short[1] ;
         H00152_A78COSTOTONRFFPRODUMes = new short[1] ;
         H00152_A77COSTOTONRFFPRODUFecha = new DateTime[] {DateTime.MinValue} ;
         H00153_AGRID1_nRecordCount = new long[1] ;
         AV18ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0110__default(),
            new Object[][] {
                new Object[] {
               H00152_A65MOTIVOTONRFFcod, H00152_A4IndicadoresCodigo, H00152_A196COSTOTONRFFPRODUValor, H00152_A5Cod_Area, H00152_A79COSTOTONRFFPRODUAno, H00152_A78COSTOTONRFFPRODUMes, H00152_A77COSTOTONRFFPRODUFecha
               }
               , new Object[] {
               H00153_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV13pCOSTOTONRFFPRODUMes ;
      private short AV14pCOSTOTONRFFPRODUAno ;
      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV7cCOSTOTONRFFPRODUMes ;
      private short AV8cCOSTOTONRFFPRODUAno ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A78COSTOTONRFFPRODUMes ;
      private short A79COSTOTONRFFPRODUAno ;
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
      private int edtavCcostotonrffprodufecha_Enabled ;
      private int edtavCcostotonrffprodumes_Enabled ;
      private int edtavCcostotonrffprodumes_Visible ;
      private int edtavCcostotonrffproduano_Enabled ;
      private int edtavCcostotonrffproduano_Visible ;
      private int edtavCcod_area_Visible ;
      private int edtavCcod_area_Enabled ;
      private int edtavCindicadorescodigo_Visible ;
      private int edtavCindicadorescodigo_Enabled ;
      private int edtavCcostotonrffproduvalor_Enabled ;
      private int edtavCcostotonrffproduvalor_Visible ;
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
      private decimal AV11cCOSTOTONRFFPRODUValor ;
      private decimal A196COSTOTONRFFPRODUValor ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divCostotonrffprodufechafiltercontainer_Class ;
      private string divCostotonrffprodumesfiltercontainer_Class ;
      private string divCostotonrffproduanofiltercontainer_Class ;
      private string divCod_areafiltercontainer_Class ;
      private string divIndicadorescodigofiltercontainer_Class ;
      private string divCostotonrffproduvalorfiltercontainer_Class ;
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
      private string divCostotonrffprodufechafiltercontainer_Internalname ;
      private string lblLblcostotonrffprodufechafilter_Internalname ;
      private string lblLblcostotonrffprodufechafilter_Jsonclick ;
      private string edtavCcostotonrffprodufecha_Internalname ;
      private string TempTags ;
      private string edtavCcostotonrffprodufecha_Jsonclick ;
      private string divCostotonrffprodumesfiltercontainer_Internalname ;
      private string lblLblcostotonrffprodumesfilter_Internalname ;
      private string lblLblcostotonrffprodumesfilter_Jsonclick ;
      private string edtavCcostotonrffprodumes_Internalname ;
      private string edtavCcostotonrffprodumes_Jsonclick ;
      private string divCostotonrffproduanofiltercontainer_Internalname ;
      private string lblLblcostotonrffproduanofilter_Internalname ;
      private string lblLblcostotonrffproduanofilter_Jsonclick ;
      private string edtavCcostotonrffproduano_Internalname ;
      private string edtavCcostotonrffproduano_Jsonclick ;
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
      private string divCostotonrffproduvalorfiltercontainer_Internalname ;
      private string lblLblcostotonrffproduvalorfilter_Internalname ;
      private string lblLblcostotonrffproduvalorfilter_Jsonclick ;
      private string edtavCcostotonrffproduvalor_Internalname ;
      private string edtavCcostotonrffproduvalor_Jsonclick ;
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
      private string edtCOSTOTONRFFPRODUFecha_Internalname ;
      private string edtCOSTOTONRFFPRODUMes_Internalname ;
      private string edtCOSTOTONRFFPRODUAno_Internalname ;
      private string edtCod_Area_Internalname ;
      private string edtCOSTOTONRFFPRODUValor_Internalname ;
      private string edtIndicadoresCodigo_Internalname ;
      private string edtMOTIVOTONRFFcod_Internalname ;
      private string scmdbuf ;
      private string AV18ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_74_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtCOSTOTONRFFPRODUFecha_Jsonclick ;
      private string edtCOSTOTONRFFPRODUMes_Jsonclick ;
      private string edtCOSTOTONRFFPRODUAno_Jsonclick ;
      private string edtCod_Area_Jsonclick ;
      private string edtCOSTOTONRFFPRODUValor_Link ;
      private string edtCOSTOTONRFFPRODUValor_Jsonclick ;
      private string edtIndicadoresCodigo_Jsonclick ;
      private string edtMOTIVOTONRFFcod_Jsonclick ;
      private string subGrid1_Header ;
      private DateTime AV12pCOSTOTONRFFPRODUFecha ;
      private DateTime AV6cCOSTOTONRFFPRODUFecha ;
      private DateTime A77COSTOTONRFFPRODUFecha ;
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
      private string AV17pMOTIVOTONRFFcod ;
      private string AV9cCod_Area ;
      private string AV10cIndicadoresCodigo ;
      private string AV21Linkselection_GXI ;
      private string A5Cod_Area ;
      private string A4IndicadoresCodigo ;
      private string A65MOTIVOTONRFFcod ;
      private string lV9cCod_Area ;
      private string lV10cIndicadoresCodigo ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] H00152_A65MOTIVOTONRFFcod ;
      private string[] H00152_A4IndicadoresCodigo ;
      private decimal[] H00152_A196COSTOTONRFFPRODUValor ;
      private string[] H00152_A5Cod_Area ;
      private short[] H00152_A79COSTOTONRFFPRODUAno ;
      private short[] H00152_A78COSTOTONRFFPRODUMes ;
      private DateTime[] H00152_A77COSTOTONRFFPRODUFecha ;
      private long[] H00153_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private DateTime aP0_pCOSTOTONRFFPRODUFecha ;
      private short aP1_pCOSTOTONRFFPRODUMes ;
      private short aP2_pCOSTOTONRFFPRODUAno ;
      private string aP3_pCod_Area ;
      private string aP4_pIndicadoresCodigo ;
      private string aP5_pMOTIVOTONRFFcod ;
      private GXWebForm Form ;
   }

   public class gx0110__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00152( IGxContext context ,
                                             decimal AV11cCOSTOTONRFFPRODUValor ,
                                             decimal A196COSTOTONRFFPRODUValor ,
                                             string A5Cod_Area ,
                                             string AV9cCod_Area ,
                                             string A4IndicadoresCodigo ,
                                             string AV10cIndicadoresCodigo ,
                                             DateTime AV6cCOSTOTONRFFPRODUFecha ,
                                             short AV7cCOSTOTONRFFPRODUMes ,
                                             short AV8cCOSTOTONRFFPRODUAno )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[9];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [MOTIVOTONRFFcod], [IndicadoresCodigo], [COSTOTONRFFPRODUValor], [Cod_Area], [COSTOTONRFFPRODUAno], [COSTOTONRFFPRODUMes], [COSTOTONRFFPRODUFecha]";
         sFromString = " FROM [COSTOTONRFFPRODU]";
         sOrderString = "";
         AddWhere(sWhereString, "([COSTOTONRFFPRODUFecha] >= @AV6cCOSTOTONRFFPRODUFecha and [COSTOTONRFFPRODUMes] >= @AV7cCOSTOTONRFFPRODUMes and [COSTOTONRFFPRODUAno] >= @AV8cCOSTOTONRFFPRODUAno)");
         AddWhere(sWhereString, "([Cod_Area] like @lV9cCod_Area)");
         AddWhere(sWhereString, "([IndicadoresCodigo] like @lV10cIndicadoresCodigo)");
         if ( ! (Convert.ToDecimal(0)==AV11cCOSTOTONRFFPRODUValor) )
         {
            AddWhere(sWhereString, "([COSTOTONRFFPRODUValor] >= @AV11cCOSTOTONRFFPRODUValor)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         sOrderString += " ORDER BY [COSTOTONRFFPRODUFecha], [COSTOTONRFFPRODUMes], [COSTOTONRFFPRODUAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOTONRFFcod]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00153( IGxContext context ,
                                             decimal AV11cCOSTOTONRFFPRODUValor ,
                                             decimal A196COSTOTONRFFPRODUValor ,
                                             string A5Cod_Area ,
                                             string AV9cCod_Area ,
                                             string A4IndicadoresCodigo ,
                                             string AV10cIndicadoresCodigo ,
                                             DateTime AV6cCOSTOTONRFFPRODUFecha ,
                                             short AV7cCOSTOTONRFFPRODUMes ,
                                             short AV8cCOSTOTONRFFPRODUAno )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [COSTOTONRFFPRODU]";
         AddWhere(sWhereString, "([COSTOTONRFFPRODUFecha] >= @AV6cCOSTOTONRFFPRODUFecha and [COSTOTONRFFPRODUMes] >= @AV7cCOSTOTONRFFPRODUMes and [COSTOTONRFFPRODUAno] >= @AV8cCOSTOTONRFFPRODUAno)");
         AddWhere(sWhereString, "([Cod_Area] like @lV9cCod_Area)");
         AddWhere(sWhereString, "([IndicadoresCodigo] like @lV10cIndicadoresCodigo)");
         if ( ! (Convert.ToDecimal(0)==AV11cCOSTOTONRFFPRODUValor) )
         {
            AddWhere(sWhereString, "([COSTOTONRFFPRODUValor] >= @AV11cCOSTOTONRFFPRODUValor)");
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
                     return conditional_H00152(context, (decimal)dynConstraints[0] , (decimal)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (DateTime)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] );
               case 1 :
                     return conditional_H00153(context, (decimal)dynConstraints[0] , (decimal)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (DateTime)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] );
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
          Object[] prmH00152;
          prmH00152 = new Object[] {
          new ParDef("@AV6cCOSTOTONRFFPRODUFecha",GXType.Date,8,0) ,
          new ParDef("@AV7cCOSTOTONRFFPRODUMes",GXType.Int16,4,0) ,
          new ParDef("@AV8cCOSTOTONRFFPRODUAno",GXType.Int16,4,0) ,
          new ParDef("@lV9cCod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@lV10cIndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@AV11cCOSTOTONRFFPRODUValor",GXType.Decimal,16,2) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00153;
          prmH00153 = new Object[] {
          new ParDef("@AV6cCOSTOTONRFFPRODUFecha",GXType.Date,8,0) ,
          new ParDef("@AV7cCOSTOTONRFFPRODUMes",GXType.Int16,4,0) ,
          new ParDef("@AV8cCOSTOTONRFFPRODUAno",GXType.Int16,4,0) ,
          new ParDef("@lV9cCod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@lV10cIndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@AV11cCOSTOTONRFFPRODUValor",GXType.Decimal,16,2)
          };
          def= new CursorDef[] {
              new CursorDef("H00152", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00152,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00153", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00153,1, GxCacheFrequency.OFF ,false,false )
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
