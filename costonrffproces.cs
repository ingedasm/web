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
   public class costonrffproces : GXDataArea
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false;
         gxfirstwebparm = GetNextPar( );
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A5Cod_Area = GetPar( "Cod_Area");
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A5Cod_Area) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A4IndicadoresCodigo = GetPar( "IndicadoresCodigo");
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A4IndicadoresCodigo) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A66MOTIVOSCOSRFFCodigo = GetPar( "MOTIVOSCOSRFFCodigo");
            AssignAttri("", false, "A66MOTIVOSCOSRFFCodigo", A66MOTIVOSCOSRFFCodigo);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A66MOTIVOSCOSRFFCodigo) ;
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
            gxfirstwebparm = GetNextPar( );
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetNextPar( );
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
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
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
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_1-167910", 0) ;
            }
            Form.Meta.addItem("description", "COSTONRFFPROCES", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCOSTONRFFPROCESFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("IndicadroresPalmas", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public costonrffproces( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("IndicadroresPalmas", true);
      }

      public costonrffproces( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("general.ui.masterunanimosidebar", "GeneXus.Programs.general.ui.masterunanimosidebar", new Object[] {context});
            MasterPageObj.setDataArea(this,false);
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

      protected void fix_multi_value_controls( )
      {
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "title-container", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "COSTONRFFPROCES", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_COSTONRFFPROCES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
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
         GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "form-container", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divToolbarcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 form__toolbar-cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-first";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSTONRFFPROCES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSTONRFFPROCES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSTONRFFPROCES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSTONRFFPROCES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 4, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx0130.aspx"+"',["+"{Ctrl:gx.dom.el('"+"COSTONRFFPROCESFECHA"+"'), id:'"+"COSTONRFFPROCESFECHA"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"COSTONRFFPROCESMES"+"'), id:'"+"COSTONRFFPROCESMES"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"COSTONRFFPROCESANO"+"'), id:'"+"COSTONRFFPROCESANO"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"COD_AREA"+"'), id:'"+"COD_AREA"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"INDICADORESCODIGO"+"'), id:'"+"INDICADORESCODIGO"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"MOTIVOSCOSRFFCODIGO"+"'), id:'"+"MOTIVOSCOSRFFCODIGO"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_COSTONRFFPROCES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell-advanced", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCOSTONRFFPROCESFecha_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCOSTONRFFPROCESFecha_Internalname, "COSTONRFFPROCESFecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCOSTONRFFPROCESFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCOSTONRFFPROCESFecha_Internalname, context.localUtil.Format(A80COSTONRFFPROCESFecha, "99/99/99"), context.localUtil.Format( A80COSTONRFFPROCESFecha, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCOSTONRFFPROCESFecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCOSTONRFFPROCESFecha_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_COSTONRFFPROCES.htm");
         GxWebStd.gx_bitmap( context, edtCOSTONRFFPROCESFecha_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCOSTONRFFPROCESFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_COSTONRFFPROCES.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCOSTONRFFPROCESMes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCOSTONRFFPROCESMes_Internalname, "COSTONRFFPROCESMes", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCOSTONRFFPROCESMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A81COSTONRFFPROCESMes), 4, 0, ",", "")), StringUtil.LTrim( ((edtCOSTONRFFPROCESMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A81COSTONRFFPROCESMes), "ZZZ9") : context.localUtil.Format( (decimal)(A81COSTONRFFPROCESMes), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCOSTONRFFPROCESMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCOSTONRFFPROCESMes_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_COSTONRFFPROCES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCOSTONRFFPROCESAno_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCOSTONRFFPROCESAno_Internalname, "COSTONRFFPROCESAno", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCOSTONRFFPROCESAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A82COSTONRFFPROCESAno), 4, 0, ",", "")), StringUtil.LTrim( ((edtCOSTONRFFPROCESAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A82COSTONRFFPROCESAno), "ZZZ9") : context.localUtil.Format( (decimal)(A82COSTONRFFPROCESAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCOSTONRFFPROCESAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCOSTONRFFPROCESAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_COSTONRFFPROCES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCod_Area_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCod_Area_Internalname, "Cod_Area", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCod_Area_Internalname, A5Cod_Area, StringUtil.RTrim( context.localUtil.Format( A5Cod_Area, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCod_Area_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCod_Area_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_COSTONRFFPROCES.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_5_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_5_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_5_Internalname, sImgUrl, imgprompt_5_Link, "", "", context.GetTheme( ), imgprompt_5_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_COSTONRFFPROCES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtIndicadoresCodigo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtIndicadoresCodigo_Internalname, "Indicadores Codigo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIndicadoresCodigo_Internalname, A4IndicadoresCodigo, StringUtil.RTrim( context.localUtil.Format( A4IndicadoresCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIndicadoresCodigo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIndicadoresCodigo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_COSTONRFFPROCES.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_4_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_4_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_4_Internalname, sImgUrl, imgprompt_4_Link, "", "", context.GetTheme( ), imgprompt_4_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_COSTONRFFPROCES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMOTIVOSCOSRFFCodigo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMOTIVOSCOSRFFCodigo_Internalname, "MOTIVOSCOSRFFCodigo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMOTIVOSCOSRFFCodigo_Internalname, A66MOTIVOSCOSRFFCodigo, StringUtil.RTrim( context.localUtil.Format( A66MOTIVOSCOSRFFCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMOTIVOSCOSRFFCodigo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMOTIVOSCOSRFFCodigo_Enabled, 0, "text", "", 80, "chr", 1, "row", 140, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_COSTONRFFPROCES.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_66_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_66_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_66_Internalname, sImgUrl, imgprompt_66_Link, "", "", context.GetTheme( ), imgprompt_66_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_COSTONRFFPROCES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCOSTONRFFPROCESValor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCOSTONRFFPROCESValor_Internalname, "COSTONRFFPROCESValor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCOSTONRFFPROCESValor_Internalname, StringUtil.LTrim( StringUtil.NToC( A198COSTONRFFPROCESValor, 16, 2, ",", "")), StringUtil.LTrim( ((edtCOSTONRFFPROCESValor_Enabled!=0) ? context.localUtil.Format( A198COSTONRFFPROCESValor, "ZZZZZZZZZZZZ9.99") : context.localUtil.Format( A198COSTONRFFPROCESValor, "ZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCOSTONRFFPROCESValor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCOSTONRFFPROCESValor_Enabled, 0, "text", "", 16, "chr", 1, "row", 16, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_COSTONRFFPROCES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCOSTONRFFPROCESUser_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCOSTONRFFPROCESUser_Internalname, "COSTONRFFPROCESUser", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCOSTONRFFPROCESUser_Internalname, A199COSTONRFFPROCESUser, StringUtil.RTrim( context.localUtil.Format( A199COSTONRFFPROCESUser, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCOSTONRFFPROCESUser_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCOSTONRFFPROCESUser_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_COSTONRFFPROCES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCOSTONRFFPROCESReg_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCOSTONRFFPROCESReg_Internalname, "COSTONRFFPROCESReg", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCOSTONRFFPROCESReg_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCOSTONRFFPROCESReg_Internalname, context.localUtil.Format(A200COSTONRFFPROCESReg, "99/99/99"), context.localUtil.Format( A200COSTONRFFPROCESReg, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCOSTONRFFPROCESReg_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCOSTONRFFPROCESReg_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_COSTONRFFPROCES.htm");
         GxWebStd.gx_bitmap( context, edtCOSTONRFFPROCESReg_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCOSTONRFFPROCESReg_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_COSTONRFFPROCES.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCOSTONRFFPROCESHor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCOSTONRFFPROCESHor_Internalname, "COSTONRFFPROCESHor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCOSTONRFFPROCESHor_Internalname, A201COSTONRFFPROCESHor, StringUtil.RTrim( context.localUtil.Format( A201COSTONRFFPROCESHor, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCOSTONRFFPROCESHor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCOSTONRFFPROCESHor_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_COSTONRFFPROCES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__actions--fixed", "Right", "Middle", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSTONRFFPROCES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSTONRFFPROCES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSTONRFFPROCES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "Right", "Middle", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Z80COSTONRFFPROCESFecha = context.localUtil.CToD( cgiGet( "Z80COSTONRFFPROCESFecha"), 0);
            Z81COSTONRFFPROCESMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z81COSTONRFFPROCESMes"), ",", "."), 18, MidpointRounding.ToEven));
            Z82COSTONRFFPROCESAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z82COSTONRFFPROCESAno"), ",", "."), 18, MidpointRounding.ToEven));
            Z5Cod_Area = cgiGet( "Z5Cod_Area");
            Z4IndicadoresCodigo = cgiGet( "Z4IndicadoresCodigo");
            Z66MOTIVOSCOSRFFCodigo = cgiGet( "Z66MOTIVOSCOSRFFCodigo");
            Z198COSTONRFFPROCESValor = context.localUtil.CToN( cgiGet( "Z198COSTONRFFPROCESValor"), ",", ".");
            Z199COSTONRFFPROCESUser = cgiGet( "Z199COSTONRFFPROCESUser");
            Z200COSTONRFFPROCESReg = context.localUtil.CToD( cgiGet( "Z200COSTONRFFPROCESReg"), 0);
            Z201COSTONRFFPROCESHor = cgiGet( "Z201COSTONRFFPROCESHor");
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( context.localUtil.VCDate( cgiGet( edtCOSTONRFFPROCESFecha_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"COSTONRFFPROCESFecha"}), 1, "COSTONRFFPROCESFECHA");
               AnyError = 1;
               GX_FocusControl = edtCOSTONRFFPROCESFecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A80COSTONRFFPROCESFecha = DateTime.MinValue;
               AssignAttri("", false, "A80COSTONRFFPROCESFecha", context.localUtil.Format(A80COSTONRFFPROCESFecha, "99/99/99"));
            }
            else
            {
               A80COSTONRFFPROCESFecha = context.localUtil.CToD( cgiGet( edtCOSTONRFFPROCESFecha_Internalname), 2);
               AssignAttri("", false, "A80COSTONRFFPROCESFecha", context.localUtil.Format(A80COSTONRFFPROCESFecha, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCOSTONRFFPROCESMes_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCOSTONRFFPROCESMes_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COSTONRFFPROCESMES");
               AnyError = 1;
               GX_FocusControl = edtCOSTONRFFPROCESMes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A81COSTONRFFPROCESMes = 0;
               AssignAttri("", false, "A81COSTONRFFPROCESMes", StringUtil.LTrimStr( (decimal)(A81COSTONRFFPROCESMes), 4, 0));
            }
            else
            {
               A81COSTONRFFPROCESMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCOSTONRFFPROCESMes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A81COSTONRFFPROCESMes", StringUtil.LTrimStr( (decimal)(A81COSTONRFFPROCESMes), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCOSTONRFFPROCESAno_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCOSTONRFFPROCESAno_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COSTONRFFPROCESANO");
               AnyError = 1;
               GX_FocusControl = edtCOSTONRFFPROCESAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A82COSTONRFFPROCESAno = 0;
               AssignAttri("", false, "A82COSTONRFFPROCESAno", StringUtil.LTrimStr( (decimal)(A82COSTONRFFPROCESAno), 4, 0));
            }
            else
            {
               A82COSTONRFFPROCESAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCOSTONRFFPROCESAno_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A82COSTONRFFPROCESAno", StringUtil.LTrimStr( (decimal)(A82COSTONRFFPROCESAno), 4, 0));
            }
            A5Cod_Area = cgiGet( edtCod_Area_Internalname);
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = cgiGet( edtIndicadoresCodigo_Internalname);
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A66MOTIVOSCOSRFFCodigo = cgiGet( edtMOTIVOSCOSRFFCodigo_Internalname);
            AssignAttri("", false, "A66MOTIVOSCOSRFFCodigo", A66MOTIVOSCOSRFFCodigo);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCOSTONRFFPROCESValor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCOSTONRFFPROCESValor_Internalname), ",", ".") > 9999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COSTONRFFPROCESVALOR");
               AnyError = 1;
               GX_FocusControl = edtCOSTONRFFPROCESValor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A198COSTONRFFPROCESValor = 0;
               AssignAttri("", false, "A198COSTONRFFPROCESValor", StringUtil.LTrimStr( A198COSTONRFFPROCESValor, 16, 2));
            }
            else
            {
               A198COSTONRFFPROCESValor = context.localUtil.CToN( cgiGet( edtCOSTONRFFPROCESValor_Internalname), ",", ".");
               AssignAttri("", false, "A198COSTONRFFPROCESValor", StringUtil.LTrimStr( A198COSTONRFFPROCESValor, 16, 2));
            }
            A199COSTONRFFPROCESUser = cgiGet( edtCOSTONRFFPROCESUser_Internalname);
            AssignAttri("", false, "A199COSTONRFFPROCESUser", A199COSTONRFFPROCESUser);
            if ( context.localUtil.VCDate( cgiGet( edtCOSTONRFFPROCESReg_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"COSTONRFFPROCESReg"}), 1, "COSTONRFFPROCESREG");
               AnyError = 1;
               GX_FocusControl = edtCOSTONRFFPROCESReg_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A200COSTONRFFPROCESReg = DateTime.MinValue;
               AssignAttri("", false, "A200COSTONRFFPROCESReg", context.localUtil.Format(A200COSTONRFFPROCESReg, "99/99/99"));
            }
            else
            {
               A200COSTONRFFPROCESReg = context.localUtil.CToD( cgiGet( edtCOSTONRFFPROCESReg_Internalname), 2);
               AssignAttri("", false, "A200COSTONRFFPROCESReg", context.localUtil.Format(A200COSTONRFFPROCESReg, "99/99/99"));
            }
            A201COSTONRFFPROCESHor = cgiGet( edtCOSTONRFFPROCESHor_Internalname);
            AssignAttri("", false, "A201COSTONRFFPROCESHor", A201COSTONRFFPROCESHor);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            standaloneNotModal( ) ;
         }
         else
         {
            standaloneNotModal( ) ;
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
            {
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               A80COSTONRFFPROCESFecha = context.localUtil.ParseDateParm( GetPar( "COSTONRFFPROCESFecha"));
               AssignAttri("", false, "A80COSTONRFFPROCESFecha", context.localUtil.Format(A80COSTONRFFPROCESFecha, "99/99/99"));
               A81COSTONRFFPROCESMes = (short)(Math.Round(NumberUtil.Val( GetPar( "COSTONRFFPROCESMes"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A81COSTONRFFPROCESMes", StringUtil.LTrimStr( (decimal)(A81COSTONRFFPROCESMes), 4, 0));
               A82COSTONRFFPROCESAno = (short)(Math.Round(NumberUtil.Val( GetPar( "COSTONRFFPROCESAno"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A82COSTONRFFPROCESAno", StringUtil.LTrimStr( (decimal)(A82COSTONRFFPROCESAno), 4, 0));
               A5Cod_Area = GetPar( "Cod_Area");
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               A4IndicadoresCodigo = GetPar( "IndicadoresCodigo");
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               A66MOTIVOSCOSRFFCodigo = GetPar( "MOTIVOSCOSRFFCodigo");
               AssignAttri("", false, "A66MOTIVOSCOSRFFCodigo", A66MOTIVOSCOSRFFCodigo);
               getEqualNoModal( ) ;
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               disable_std_buttons_dsp( ) ;
               standaloneModal( ) ;
            }
            else
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               standaloneModal( ) ;
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
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
                        if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_enter( ) ;
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_first( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "PREVIOUS") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_previous( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_next( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_last( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "SELECT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_select( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DELETE") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_delete( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           AfterKeyLoadScreen( ) ;
                        }
                     }
                     else
                     {
                     }
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1239( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         if ( IsIns( ) )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
      }

      protected void disable_std_buttons_dsp( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) )
         {
            bttBtn_enter_Visible = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
         }
         DisableAttributes1239( ) ;
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void ResetCaption120( )
      {
      }

      protected void ZM1239( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z198COSTONRFFPROCESValor = T00123_A198COSTONRFFPROCESValor[0];
               Z199COSTONRFFPROCESUser = T00123_A199COSTONRFFPROCESUser[0];
               Z200COSTONRFFPROCESReg = T00123_A200COSTONRFFPROCESReg[0];
               Z201COSTONRFFPROCESHor = T00123_A201COSTONRFFPROCESHor[0];
            }
            else
            {
               Z198COSTONRFFPROCESValor = A198COSTONRFFPROCESValor;
               Z199COSTONRFFPROCESUser = A199COSTONRFFPROCESUser;
               Z200COSTONRFFPROCESReg = A200COSTONRFFPROCESReg;
               Z201COSTONRFFPROCESHor = A201COSTONRFFPROCESHor;
            }
         }
         if ( GX_JID == -3 )
         {
            Z80COSTONRFFPROCESFecha = A80COSTONRFFPROCESFecha;
            Z81COSTONRFFPROCESMes = A81COSTONRFFPROCESMes;
            Z82COSTONRFFPROCESAno = A82COSTONRFFPROCESAno;
            Z198COSTONRFFPROCESValor = A198COSTONRFFPROCESValor;
            Z199COSTONRFFPROCESUser = A199COSTONRFFPROCESUser;
            Z200COSTONRFFPROCESReg = A200COSTONRFFPROCESReg;
            Z201COSTONRFFPROCESHor = A201COSTONRFFPROCESHor;
            Z5Cod_Area = A5Cod_Area;
            Z4IndicadoresCodigo = A4IndicadoresCodigo;
            Z66MOTIVOSCOSRFFCodigo = A66MOTIVOSCOSRFFCodigo;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_5_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"COD_AREA"+"'), id:'"+"COD_AREA"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"true"+");");
         imgprompt_4_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0030.aspx"+"',["+"{Ctrl:gx.dom.el('"+"INDICADORESCODIGO"+"'), id:'"+"INDICADORESCODIGO"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"true"+");");
         imgprompt_66_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0120.aspx"+"',["+"{Ctrl:gx.dom.el('"+"MOTIVOSCOSRFFCODIGO"+"'), id:'"+"MOTIVOSCOSRFFCODIGO"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");");
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_delete_Enabled = 1;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
      }

      protected void Load1239( )
      {
         /* Using cursor T00127 */
         pr_default.execute(5, new Object[] {A80COSTONRFFPROCESFecha, A81COSTONRFFPROCESMes, A82COSTONRFFPROCESAno, A5Cod_Area, A4IndicadoresCodigo, A66MOTIVOSCOSRFFCodigo});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound39 = 1;
            A198COSTONRFFPROCESValor = T00127_A198COSTONRFFPROCESValor[0];
            AssignAttri("", false, "A198COSTONRFFPROCESValor", StringUtil.LTrimStr( A198COSTONRFFPROCESValor, 16, 2));
            A199COSTONRFFPROCESUser = T00127_A199COSTONRFFPROCESUser[0];
            AssignAttri("", false, "A199COSTONRFFPROCESUser", A199COSTONRFFPROCESUser);
            A200COSTONRFFPROCESReg = T00127_A200COSTONRFFPROCESReg[0];
            AssignAttri("", false, "A200COSTONRFFPROCESReg", context.localUtil.Format(A200COSTONRFFPROCESReg, "99/99/99"));
            A201COSTONRFFPROCESHor = T00127_A201COSTONRFFPROCESHor[0];
            AssignAttri("", false, "A201COSTONRFFPROCESHor", A201COSTONRFFPROCESHor);
            ZM1239( -3) ;
         }
         pr_default.close(5);
         OnLoadActions1239( ) ;
      }

      protected void OnLoadActions1239( )
      {
      }

      protected void CheckExtendedTable1239( )
      {
         nIsDirty_39 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A80COSTONRFFPROCESFecha) || ( DateTimeUtil.ResetTime ( A80COSTONRFFPROCESFecha ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo COSTONRFFPROCESFecha fuera de rango", "OutOfRange", 1, "COSTONRFFPROCESFECHA");
            AnyError = 1;
            GX_FocusControl = edtCOSTONRFFPROCESFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00124 */
         pr_default.execute(2, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T00125 */
         pr_default.execute(3, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         /* Using cursor T00126 */
         pr_default.execute(4, new Object[] {A66MOTIVOSCOSRFFCodigo});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'MOTIVOSCOSRFF'.", "ForeignKeyNotFound", 1, "MOTIVOSCOSRFFCODIGO");
            AnyError = 1;
            GX_FocusControl = edtMOTIVOSCOSRFFCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(4);
         if ( ! ( (DateTime.MinValue==A200COSTONRFFPROCESReg) || ( DateTimeUtil.ResetTime ( A200COSTONRFFPROCESReg ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo COSTONRFFPROCESReg fuera de rango", "OutOfRange", 1, "COSTONRFFPROCESREG");
            AnyError = 1;
            GX_FocusControl = edtCOSTONRFFPROCESReg_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1239( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_4( string A5Cod_Area )
      {
         /* Using cursor T00128 */
         pr_default.execute(6, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void gxLoad_5( string A4IndicadoresCodigo )
      {
         /* Using cursor T00129 */
         pr_default.execute(7, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_6( string A66MOTIVOSCOSRFFCodigo )
      {
         /* Using cursor T001210 */
         pr_default.execute(8, new Object[] {A66MOTIVOSCOSRFFCodigo});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'MOTIVOSCOSRFF'.", "ForeignKeyNotFound", 1, "MOTIVOSCOSRFFCODIGO");
            AnyError = 1;
            GX_FocusControl = edtMOTIVOSCOSRFFCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey1239( )
      {
         /* Using cursor T001211 */
         pr_default.execute(9, new Object[] {A80COSTONRFFPROCESFecha, A81COSTONRFFPROCESMes, A82COSTONRFFPROCESAno, A5Cod_Area, A4IndicadoresCodigo, A66MOTIVOSCOSRFFCodigo});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound39 = 1;
         }
         else
         {
            RcdFound39 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00123 */
         pr_default.execute(1, new Object[] {A80COSTONRFFPROCESFecha, A81COSTONRFFPROCESMes, A82COSTONRFFPROCESAno, A5Cod_Area, A4IndicadoresCodigo, A66MOTIVOSCOSRFFCodigo});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1239( 3) ;
            RcdFound39 = 1;
            A80COSTONRFFPROCESFecha = T00123_A80COSTONRFFPROCESFecha[0];
            AssignAttri("", false, "A80COSTONRFFPROCESFecha", context.localUtil.Format(A80COSTONRFFPROCESFecha, "99/99/99"));
            A81COSTONRFFPROCESMes = T00123_A81COSTONRFFPROCESMes[0];
            AssignAttri("", false, "A81COSTONRFFPROCESMes", StringUtil.LTrimStr( (decimal)(A81COSTONRFFPROCESMes), 4, 0));
            A82COSTONRFFPROCESAno = T00123_A82COSTONRFFPROCESAno[0];
            AssignAttri("", false, "A82COSTONRFFPROCESAno", StringUtil.LTrimStr( (decimal)(A82COSTONRFFPROCESAno), 4, 0));
            A198COSTONRFFPROCESValor = T00123_A198COSTONRFFPROCESValor[0];
            AssignAttri("", false, "A198COSTONRFFPROCESValor", StringUtil.LTrimStr( A198COSTONRFFPROCESValor, 16, 2));
            A199COSTONRFFPROCESUser = T00123_A199COSTONRFFPROCESUser[0];
            AssignAttri("", false, "A199COSTONRFFPROCESUser", A199COSTONRFFPROCESUser);
            A200COSTONRFFPROCESReg = T00123_A200COSTONRFFPROCESReg[0];
            AssignAttri("", false, "A200COSTONRFFPROCESReg", context.localUtil.Format(A200COSTONRFFPROCESReg, "99/99/99"));
            A201COSTONRFFPROCESHor = T00123_A201COSTONRFFPROCESHor[0];
            AssignAttri("", false, "A201COSTONRFFPROCESHor", A201COSTONRFFPROCESHor);
            A5Cod_Area = T00123_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = T00123_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A66MOTIVOSCOSRFFCodigo = T00123_A66MOTIVOSCOSRFFCodigo[0];
            AssignAttri("", false, "A66MOTIVOSCOSRFFCodigo", A66MOTIVOSCOSRFFCodigo);
            Z80COSTONRFFPROCESFecha = A80COSTONRFFPROCESFecha;
            Z81COSTONRFFPROCESMes = A81COSTONRFFPROCESMes;
            Z82COSTONRFFPROCESAno = A82COSTONRFFPROCESAno;
            Z5Cod_Area = A5Cod_Area;
            Z4IndicadoresCodigo = A4IndicadoresCodigo;
            Z66MOTIVOSCOSRFFCodigo = A66MOTIVOSCOSRFFCodigo;
            sMode39 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1239( ) ;
            if ( AnyError == 1 )
            {
               RcdFound39 = 0;
               InitializeNonKey1239( ) ;
            }
            Gx_mode = sMode39;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound39 = 0;
            InitializeNonKey1239( ) ;
            sMode39 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode39;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1239( ) ;
         if ( RcdFound39 == 0 )
         {
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound39 = 0;
         /* Using cursor T001212 */
         pr_default.execute(10, new Object[] {A80COSTONRFFPROCESFecha, A81COSTONRFFPROCESMes, A82COSTONRFFPROCESAno, A5Cod_Area, A4IndicadoresCodigo, A66MOTIVOSCOSRFFCodigo});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( DateTimeUtil.ResetTime ( T001212_A80COSTONRFFPROCESFecha[0] ) < DateTimeUtil.ResetTime ( A80COSTONRFFPROCESFecha ) ) || ( DateTimeUtil.ResetTime ( T001212_A80COSTONRFFPROCESFecha[0] ) == DateTimeUtil.ResetTime ( A80COSTONRFFPROCESFecha ) ) && ( T001212_A81COSTONRFFPROCESMes[0] < A81COSTONRFFPROCESMes ) || ( T001212_A81COSTONRFFPROCESMes[0] == A81COSTONRFFPROCESMes ) && ( DateTimeUtil.ResetTime ( T001212_A80COSTONRFFPROCESFecha[0] ) == DateTimeUtil.ResetTime ( A80COSTONRFFPROCESFecha ) ) && ( T001212_A82COSTONRFFPROCESAno[0] < A82COSTONRFFPROCESAno ) || ( T001212_A82COSTONRFFPROCESAno[0] == A82COSTONRFFPROCESAno ) && ( T001212_A81COSTONRFFPROCESMes[0] == A81COSTONRFFPROCESMes ) && ( DateTimeUtil.ResetTime ( T001212_A80COSTONRFFPROCESFecha[0] ) == DateTimeUtil.ResetTime ( A80COSTONRFFPROCESFecha ) ) && ( StringUtil.StrCmp(T001212_A5Cod_Area[0], A5Cod_Area) < 0 ) || ( StringUtil.StrCmp(T001212_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T001212_A82COSTONRFFPROCESAno[0] == A82COSTONRFFPROCESAno ) && ( T001212_A81COSTONRFFPROCESMes[0] == A81COSTONRFFPROCESMes ) && ( DateTimeUtil.ResetTime ( T001212_A80COSTONRFFPROCESFecha[0] ) == DateTimeUtil.ResetTime ( A80COSTONRFFPROCESFecha ) ) && ( StringUtil.StrCmp(T001212_A4IndicadoresCodigo[0], A4IndicadoresCodigo) < 0 ) || ( StringUtil.StrCmp(T001212_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T001212_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T001212_A82COSTONRFFPROCESAno[0] == A82COSTONRFFPROCESAno ) && ( T001212_A81COSTONRFFPROCESMes[0] == A81COSTONRFFPROCESMes ) && ( DateTimeUtil.ResetTime ( T001212_A80COSTONRFFPROCESFecha[0] ) == DateTimeUtil.ResetTime ( A80COSTONRFFPROCESFecha ) ) && ( StringUtil.StrCmp(T001212_A66MOTIVOSCOSRFFCodigo[0], A66MOTIVOSCOSRFFCodigo) < 0 ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( DateTimeUtil.ResetTime ( T001212_A80COSTONRFFPROCESFecha[0] ) > DateTimeUtil.ResetTime ( A80COSTONRFFPROCESFecha ) ) || ( DateTimeUtil.ResetTime ( T001212_A80COSTONRFFPROCESFecha[0] ) == DateTimeUtil.ResetTime ( A80COSTONRFFPROCESFecha ) ) && ( T001212_A81COSTONRFFPROCESMes[0] > A81COSTONRFFPROCESMes ) || ( T001212_A81COSTONRFFPROCESMes[0] == A81COSTONRFFPROCESMes ) && ( DateTimeUtil.ResetTime ( T001212_A80COSTONRFFPROCESFecha[0] ) == DateTimeUtil.ResetTime ( A80COSTONRFFPROCESFecha ) ) && ( T001212_A82COSTONRFFPROCESAno[0] > A82COSTONRFFPROCESAno ) || ( T001212_A82COSTONRFFPROCESAno[0] == A82COSTONRFFPROCESAno ) && ( T001212_A81COSTONRFFPROCESMes[0] == A81COSTONRFFPROCESMes ) && ( DateTimeUtil.ResetTime ( T001212_A80COSTONRFFPROCESFecha[0] ) == DateTimeUtil.ResetTime ( A80COSTONRFFPROCESFecha ) ) && ( StringUtil.StrCmp(T001212_A5Cod_Area[0], A5Cod_Area) > 0 ) || ( StringUtil.StrCmp(T001212_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T001212_A82COSTONRFFPROCESAno[0] == A82COSTONRFFPROCESAno ) && ( T001212_A81COSTONRFFPROCESMes[0] == A81COSTONRFFPROCESMes ) && ( DateTimeUtil.ResetTime ( T001212_A80COSTONRFFPROCESFecha[0] ) == DateTimeUtil.ResetTime ( A80COSTONRFFPROCESFecha ) ) && ( StringUtil.StrCmp(T001212_A4IndicadoresCodigo[0], A4IndicadoresCodigo) > 0 ) || ( StringUtil.StrCmp(T001212_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T001212_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T001212_A82COSTONRFFPROCESAno[0] == A82COSTONRFFPROCESAno ) && ( T001212_A81COSTONRFFPROCESMes[0] == A81COSTONRFFPROCESMes ) && ( DateTimeUtil.ResetTime ( T001212_A80COSTONRFFPROCESFecha[0] ) == DateTimeUtil.ResetTime ( A80COSTONRFFPROCESFecha ) ) && ( StringUtil.StrCmp(T001212_A66MOTIVOSCOSRFFCodigo[0], A66MOTIVOSCOSRFFCodigo) > 0 ) ) )
            {
               A80COSTONRFFPROCESFecha = T001212_A80COSTONRFFPROCESFecha[0];
               AssignAttri("", false, "A80COSTONRFFPROCESFecha", context.localUtil.Format(A80COSTONRFFPROCESFecha, "99/99/99"));
               A81COSTONRFFPROCESMes = T001212_A81COSTONRFFPROCESMes[0];
               AssignAttri("", false, "A81COSTONRFFPROCESMes", StringUtil.LTrimStr( (decimal)(A81COSTONRFFPROCESMes), 4, 0));
               A82COSTONRFFPROCESAno = T001212_A82COSTONRFFPROCESAno[0];
               AssignAttri("", false, "A82COSTONRFFPROCESAno", StringUtil.LTrimStr( (decimal)(A82COSTONRFFPROCESAno), 4, 0));
               A5Cod_Area = T001212_A5Cod_Area[0];
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               A4IndicadoresCodigo = T001212_A4IndicadoresCodigo[0];
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               A66MOTIVOSCOSRFFCodigo = T001212_A66MOTIVOSCOSRFFCodigo[0];
               AssignAttri("", false, "A66MOTIVOSCOSRFFCodigo", A66MOTIVOSCOSRFFCodigo);
               RcdFound39 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound39 = 0;
         /* Using cursor T001213 */
         pr_default.execute(11, new Object[] {A80COSTONRFFPROCESFecha, A81COSTONRFFPROCESMes, A82COSTONRFFPROCESAno, A5Cod_Area, A4IndicadoresCodigo, A66MOTIVOSCOSRFFCodigo});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( DateTimeUtil.ResetTime ( T001213_A80COSTONRFFPROCESFecha[0] ) > DateTimeUtil.ResetTime ( A80COSTONRFFPROCESFecha ) ) || ( DateTimeUtil.ResetTime ( T001213_A80COSTONRFFPROCESFecha[0] ) == DateTimeUtil.ResetTime ( A80COSTONRFFPROCESFecha ) ) && ( T001213_A81COSTONRFFPROCESMes[0] > A81COSTONRFFPROCESMes ) || ( T001213_A81COSTONRFFPROCESMes[0] == A81COSTONRFFPROCESMes ) && ( DateTimeUtil.ResetTime ( T001213_A80COSTONRFFPROCESFecha[0] ) == DateTimeUtil.ResetTime ( A80COSTONRFFPROCESFecha ) ) && ( T001213_A82COSTONRFFPROCESAno[0] > A82COSTONRFFPROCESAno ) || ( T001213_A82COSTONRFFPROCESAno[0] == A82COSTONRFFPROCESAno ) && ( T001213_A81COSTONRFFPROCESMes[0] == A81COSTONRFFPROCESMes ) && ( DateTimeUtil.ResetTime ( T001213_A80COSTONRFFPROCESFecha[0] ) == DateTimeUtil.ResetTime ( A80COSTONRFFPROCESFecha ) ) && ( StringUtil.StrCmp(T001213_A5Cod_Area[0], A5Cod_Area) > 0 ) || ( StringUtil.StrCmp(T001213_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T001213_A82COSTONRFFPROCESAno[0] == A82COSTONRFFPROCESAno ) && ( T001213_A81COSTONRFFPROCESMes[0] == A81COSTONRFFPROCESMes ) && ( DateTimeUtil.ResetTime ( T001213_A80COSTONRFFPROCESFecha[0] ) == DateTimeUtil.ResetTime ( A80COSTONRFFPROCESFecha ) ) && ( StringUtil.StrCmp(T001213_A4IndicadoresCodigo[0], A4IndicadoresCodigo) > 0 ) || ( StringUtil.StrCmp(T001213_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T001213_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T001213_A82COSTONRFFPROCESAno[0] == A82COSTONRFFPROCESAno ) && ( T001213_A81COSTONRFFPROCESMes[0] == A81COSTONRFFPROCESMes ) && ( DateTimeUtil.ResetTime ( T001213_A80COSTONRFFPROCESFecha[0] ) == DateTimeUtil.ResetTime ( A80COSTONRFFPROCESFecha ) ) && ( StringUtil.StrCmp(T001213_A66MOTIVOSCOSRFFCodigo[0], A66MOTIVOSCOSRFFCodigo) > 0 ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( DateTimeUtil.ResetTime ( T001213_A80COSTONRFFPROCESFecha[0] ) < DateTimeUtil.ResetTime ( A80COSTONRFFPROCESFecha ) ) || ( DateTimeUtil.ResetTime ( T001213_A80COSTONRFFPROCESFecha[0] ) == DateTimeUtil.ResetTime ( A80COSTONRFFPROCESFecha ) ) && ( T001213_A81COSTONRFFPROCESMes[0] < A81COSTONRFFPROCESMes ) || ( T001213_A81COSTONRFFPROCESMes[0] == A81COSTONRFFPROCESMes ) && ( DateTimeUtil.ResetTime ( T001213_A80COSTONRFFPROCESFecha[0] ) == DateTimeUtil.ResetTime ( A80COSTONRFFPROCESFecha ) ) && ( T001213_A82COSTONRFFPROCESAno[0] < A82COSTONRFFPROCESAno ) || ( T001213_A82COSTONRFFPROCESAno[0] == A82COSTONRFFPROCESAno ) && ( T001213_A81COSTONRFFPROCESMes[0] == A81COSTONRFFPROCESMes ) && ( DateTimeUtil.ResetTime ( T001213_A80COSTONRFFPROCESFecha[0] ) == DateTimeUtil.ResetTime ( A80COSTONRFFPROCESFecha ) ) && ( StringUtil.StrCmp(T001213_A5Cod_Area[0], A5Cod_Area) < 0 ) || ( StringUtil.StrCmp(T001213_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T001213_A82COSTONRFFPROCESAno[0] == A82COSTONRFFPROCESAno ) && ( T001213_A81COSTONRFFPROCESMes[0] == A81COSTONRFFPROCESMes ) && ( DateTimeUtil.ResetTime ( T001213_A80COSTONRFFPROCESFecha[0] ) == DateTimeUtil.ResetTime ( A80COSTONRFFPROCESFecha ) ) && ( StringUtil.StrCmp(T001213_A4IndicadoresCodigo[0], A4IndicadoresCodigo) < 0 ) || ( StringUtil.StrCmp(T001213_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T001213_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T001213_A82COSTONRFFPROCESAno[0] == A82COSTONRFFPROCESAno ) && ( T001213_A81COSTONRFFPROCESMes[0] == A81COSTONRFFPROCESMes ) && ( DateTimeUtil.ResetTime ( T001213_A80COSTONRFFPROCESFecha[0] ) == DateTimeUtil.ResetTime ( A80COSTONRFFPROCESFecha ) ) && ( StringUtil.StrCmp(T001213_A66MOTIVOSCOSRFFCodigo[0], A66MOTIVOSCOSRFFCodigo) < 0 ) ) )
            {
               A80COSTONRFFPROCESFecha = T001213_A80COSTONRFFPROCESFecha[0];
               AssignAttri("", false, "A80COSTONRFFPROCESFecha", context.localUtil.Format(A80COSTONRFFPROCESFecha, "99/99/99"));
               A81COSTONRFFPROCESMes = T001213_A81COSTONRFFPROCESMes[0];
               AssignAttri("", false, "A81COSTONRFFPROCESMes", StringUtil.LTrimStr( (decimal)(A81COSTONRFFPROCESMes), 4, 0));
               A82COSTONRFFPROCESAno = T001213_A82COSTONRFFPROCESAno[0];
               AssignAttri("", false, "A82COSTONRFFPROCESAno", StringUtil.LTrimStr( (decimal)(A82COSTONRFFPROCESAno), 4, 0));
               A5Cod_Area = T001213_A5Cod_Area[0];
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               A4IndicadoresCodigo = T001213_A4IndicadoresCodigo[0];
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               A66MOTIVOSCOSRFFCodigo = T001213_A66MOTIVOSCOSRFFCodigo[0];
               AssignAttri("", false, "A66MOTIVOSCOSRFFCodigo", A66MOTIVOSCOSRFFCodigo);
               RcdFound39 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1239( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCOSTONRFFPROCESFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1239( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound39 == 1 )
            {
               if ( ( DateTimeUtil.ResetTime ( A80COSTONRFFPROCESFecha ) != DateTimeUtil.ResetTime ( Z80COSTONRFFPROCESFecha ) ) || ( A81COSTONRFFPROCESMes != Z81COSTONRFFPROCESMes ) || ( A82COSTONRFFPROCESAno != Z82COSTONRFFPROCESAno ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) || ( StringUtil.StrCmp(A66MOTIVOSCOSRFFCodigo, Z66MOTIVOSCOSRFFCodigo) != 0 ) )
               {
                  A80COSTONRFFPROCESFecha = Z80COSTONRFFPROCESFecha;
                  AssignAttri("", false, "A80COSTONRFFPROCESFecha", context.localUtil.Format(A80COSTONRFFPROCESFecha, "99/99/99"));
                  A81COSTONRFFPROCESMes = Z81COSTONRFFPROCESMes;
                  AssignAttri("", false, "A81COSTONRFFPROCESMes", StringUtil.LTrimStr( (decimal)(A81COSTONRFFPROCESMes), 4, 0));
                  A82COSTONRFFPROCESAno = Z82COSTONRFFPROCESAno;
                  AssignAttri("", false, "A82COSTONRFFPROCESAno", StringUtil.LTrimStr( (decimal)(A82COSTONRFFPROCESAno), 4, 0));
                  A5Cod_Area = Z5Cod_Area;
                  AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
                  A4IndicadoresCodigo = Z4IndicadoresCodigo;
                  AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
                  A66MOTIVOSCOSRFFCodigo = Z66MOTIVOSCOSRFFCodigo;
                  AssignAttri("", false, "A66MOTIVOSCOSRFFCodigo", A66MOTIVOSCOSRFFCodigo);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "COSTONRFFPROCESFECHA");
                  AnyError = 1;
                  GX_FocusControl = edtCOSTONRFFPROCESFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCOSTONRFFPROCESFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1239( ) ;
                  GX_FocusControl = edtCOSTONRFFPROCESFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( DateTimeUtil.ResetTime ( A80COSTONRFFPROCESFecha ) != DateTimeUtil.ResetTime ( Z80COSTONRFFPROCESFecha ) ) || ( A81COSTONRFFPROCESMes != Z81COSTONRFFPROCESMes ) || ( A82COSTONRFFPROCESAno != Z82COSTONRFFPROCESAno ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) || ( StringUtil.StrCmp(A66MOTIVOSCOSRFFCodigo, Z66MOTIVOSCOSRFFCodigo) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtCOSTONRFFPROCESFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1239( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "COSTONRFFPROCESFECHA");
                     AnyError = 1;
                     GX_FocusControl = edtCOSTONRFFPROCESFecha_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtCOSTONRFFPROCESFecha_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1239( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      protected void btn_delete( )
      {
         if ( ( DateTimeUtil.ResetTime ( A80COSTONRFFPROCESFecha ) != DateTimeUtil.ResetTime ( Z80COSTONRFFPROCESFecha ) ) || ( A81COSTONRFFPROCESMes != Z81COSTONRFFPROCESMes ) || ( A82COSTONRFFPROCESAno != Z82COSTONRFFPROCESAno ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) || ( StringUtil.StrCmp(A66MOTIVOSCOSRFFCodigo, Z66MOTIVOSCOSRFFCodigo) != 0 ) )
         {
            A80COSTONRFFPROCESFecha = Z80COSTONRFFPROCESFecha;
            AssignAttri("", false, "A80COSTONRFFPROCESFecha", context.localUtil.Format(A80COSTONRFFPROCESFecha, "99/99/99"));
            A81COSTONRFFPROCESMes = Z81COSTONRFFPROCESMes;
            AssignAttri("", false, "A81COSTONRFFPROCESMes", StringUtil.LTrimStr( (decimal)(A81COSTONRFFPROCESMes), 4, 0));
            A82COSTONRFFPROCESAno = Z82COSTONRFFPROCESAno;
            AssignAttri("", false, "A82COSTONRFFPROCESAno", StringUtil.LTrimStr( (decimal)(A82COSTONRFFPROCESAno), 4, 0));
            A5Cod_Area = Z5Cod_Area;
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = Z4IndicadoresCodigo;
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A66MOTIVOSCOSRFFCodigo = Z66MOTIVOSCOSRFFCodigo;
            AssignAttri("", false, "A66MOTIVOSCOSRFFCodigo", A66MOTIVOSCOSRFFCodigo);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "COSTONRFFPROCESFECHA");
            AnyError = 1;
            GX_FocusControl = edtCOSTONRFFPROCESFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCOSTONRFFPROCESFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            getByPrimaryKey( ) ;
         }
         CloseOpenCursors();
      }

      protected void btn_get( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         if ( RcdFound39 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "COSTONRFFPROCESFECHA");
            AnyError = 1;
            GX_FocusControl = edtCOSTONRFFPROCESFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtCOSTONRFFPROCESValor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1239( ) ;
         if ( RcdFound39 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCOSTONRFFPROCESValor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1239( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_previous( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_previous( ) ;
         if ( RcdFound39 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCOSTONRFFPROCESValor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_next( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_next( ) ;
         if ( RcdFound39 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCOSTONRFFPROCESValor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1239( ) ;
         if ( RcdFound39 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound39 != 0 )
            {
               ScanNext1239( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCOSTONRFFPROCESValor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1239( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1239( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00122 */
            pr_default.execute(0, new Object[] {A80COSTONRFFPROCESFecha, A81COSTONRFFPROCESMes, A82COSTONRFFPROCESAno, A5Cod_Area, A4IndicadoresCodigo, A66MOTIVOSCOSRFFCodigo});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"COSTONRFFPROCES"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z198COSTONRFFPROCESValor != T00122_A198COSTONRFFPROCESValor[0] ) || ( StringUtil.StrCmp(Z199COSTONRFFPROCESUser, T00122_A199COSTONRFFPROCESUser[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z200COSTONRFFPROCESReg ) != DateTimeUtil.ResetTime ( T00122_A200COSTONRFFPROCESReg[0] ) ) || ( StringUtil.StrCmp(Z201COSTONRFFPROCESHor, T00122_A201COSTONRFFPROCESHor[0]) != 0 ) )
            {
               if ( Z198COSTONRFFPROCESValor != T00122_A198COSTONRFFPROCESValor[0] )
               {
                  GXUtil.WriteLog("costonrffproces:[seudo value changed for attri]"+"COSTONRFFPROCESValor");
                  GXUtil.WriteLogRaw("Old: ",Z198COSTONRFFPROCESValor);
                  GXUtil.WriteLogRaw("Current: ",T00122_A198COSTONRFFPROCESValor[0]);
               }
               if ( StringUtil.StrCmp(Z199COSTONRFFPROCESUser, T00122_A199COSTONRFFPROCESUser[0]) != 0 )
               {
                  GXUtil.WriteLog("costonrffproces:[seudo value changed for attri]"+"COSTONRFFPROCESUser");
                  GXUtil.WriteLogRaw("Old: ",Z199COSTONRFFPROCESUser);
                  GXUtil.WriteLogRaw("Current: ",T00122_A199COSTONRFFPROCESUser[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z200COSTONRFFPROCESReg ) != DateTimeUtil.ResetTime ( T00122_A200COSTONRFFPROCESReg[0] ) )
               {
                  GXUtil.WriteLog("costonrffproces:[seudo value changed for attri]"+"COSTONRFFPROCESReg");
                  GXUtil.WriteLogRaw("Old: ",Z200COSTONRFFPROCESReg);
                  GXUtil.WriteLogRaw("Current: ",T00122_A200COSTONRFFPROCESReg[0]);
               }
               if ( StringUtil.StrCmp(Z201COSTONRFFPROCESHor, T00122_A201COSTONRFFPROCESHor[0]) != 0 )
               {
                  GXUtil.WriteLog("costonrffproces:[seudo value changed for attri]"+"COSTONRFFPROCESHor");
                  GXUtil.WriteLogRaw("Old: ",Z201COSTONRFFPROCESHor);
                  GXUtil.WriteLogRaw("Current: ",T00122_A201COSTONRFFPROCESHor[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"COSTONRFFPROCES"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1239( )
      {
         BeforeValidate1239( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1239( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1239( 0) ;
            CheckOptimisticConcurrency1239( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1239( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1239( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001214 */
                     pr_default.execute(12, new Object[] {A80COSTONRFFPROCESFecha, A81COSTONRFFPROCESMes, A82COSTONRFFPROCESAno, A198COSTONRFFPROCESValor, A199COSTONRFFPROCESUser, A200COSTONRFFPROCESReg, A201COSTONRFFPROCESHor, A5Cod_Area, A4IndicadoresCodigo, A66MOTIVOSCOSRFFCodigo});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("COSTONRFFPROCES");
                     if ( (pr_default.getStatus(12) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption120( ) ;
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load1239( ) ;
            }
            EndLevel1239( ) ;
         }
         CloseExtendedTableCursors1239( ) ;
      }

      protected void Update1239( )
      {
         BeforeValidate1239( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1239( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1239( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1239( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1239( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001215 */
                     pr_default.execute(13, new Object[] {A198COSTONRFFPROCESValor, A199COSTONRFFPROCESUser, A200COSTONRFFPROCESReg, A201COSTONRFFPROCESHor, A80COSTONRFFPROCESFecha, A81COSTONRFFPROCESMes, A82COSTONRFFPROCESAno, A5Cod_Area, A4IndicadoresCodigo, A66MOTIVOSCOSRFFCodigo});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("COSTONRFFPROCES");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"COSTONRFFPROCES"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1239( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption120( ) ;
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel1239( ) ;
         }
         CloseExtendedTableCursors1239( ) ;
      }

      protected void DeferredUpdate1239( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1239( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1239( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1239( ) ;
            AfterConfirm1239( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1239( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001216 */
                  pr_default.execute(14, new Object[] {A80COSTONRFFPROCESFecha, A81COSTONRFFPROCESMes, A82COSTONRFFPROCESAno, A5Cod_Area, A4IndicadoresCodigo, A66MOTIVOSCOSRFFCodigo});
                  pr_default.close(14);
                  pr_default.SmartCacheProvider.SetUpdated("COSTONRFFPROCES");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound39 == 0 )
                        {
                           InitAll1239( ) ;
                           Gx_mode = "INS";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        else
                        {
                           getByPrimaryKey( ) ;
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                        ResetCaption120( ) ;
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode39 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1239( ) ;
         Gx_mode = sMode39;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1239( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1239( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1239( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("costonrffproces",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues120( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("costonrffproces",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1239( )
      {
         /* Using cursor T001217 */
         pr_default.execute(15);
         RcdFound39 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound39 = 1;
            A80COSTONRFFPROCESFecha = T001217_A80COSTONRFFPROCESFecha[0];
            AssignAttri("", false, "A80COSTONRFFPROCESFecha", context.localUtil.Format(A80COSTONRFFPROCESFecha, "99/99/99"));
            A81COSTONRFFPROCESMes = T001217_A81COSTONRFFPROCESMes[0];
            AssignAttri("", false, "A81COSTONRFFPROCESMes", StringUtil.LTrimStr( (decimal)(A81COSTONRFFPROCESMes), 4, 0));
            A82COSTONRFFPROCESAno = T001217_A82COSTONRFFPROCESAno[0];
            AssignAttri("", false, "A82COSTONRFFPROCESAno", StringUtil.LTrimStr( (decimal)(A82COSTONRFFPROCESAno), 4, 0));
            A5Cod_Area = T001217_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = T001217_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A66MOTIVOSCOSRFFCodigo = T001217_A66MOTIVOSCOSRFFCodigo[0];
            AssignAttri("", false, "A66MOTIVOSCOSRFFCodigo", A66MOTIVOSCOSRFFCodigo);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1239( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound39 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound39 = 1;
            A80COSTONRFFPROCESFecha = T001217_A80COSTONRFFPROCESFecha[0];
            AssignAttri("", false, "A80COSTONRFFPROCESFecha", context.localUtil.Format(A80COSTONRFFPROCESFecha, "99/99/99"));
            A81COSTONRFFPROCESMes = T001217_A81COSTONRFFPROCESMes[0];
            AssignAttri("", false, "A81COSTONRFFPROCESMes", StringUtil.LTrimStr( (decimal)(A81COSTONRFFPROCESMes), 4, 0));
            A82COSTONRFFPROCESAno = T001217_A82COSTONRFFPROCESAno[0];
            AssignAttri("", false, "A82COSTONRFFPROCESAno", StringUtil.LTrimStr( (decimal)(A82COSTONRFFPROCESAno), 4, 0));
            A5Cod_Area = T001217_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = T001217_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A66MOTIVOSCOSRFFCodigo = T001217_A66MOTIVOSCOSRFFCodigo[0];
            AssignAttri("", false, "A66MOTIVOSCOSRFFCodigo", A66MOTIVOSCOSRFFCodigo);
         }
      }

      protected void ScanEnd1239( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm1239( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1239( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1239( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1239( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1239( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1239( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1239( )
      {
         edtCOSTONRFFPROCESFecha_Enabled = 0;
         AssignProp("", false, edtCOSTONRFFPROCESFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSTONRFFPROCESFecha_Enabled), 5, 0), true);
         edtCOSTONRFFPROCESMes_Enabled = 0;
         AssignProp("", false, edtCOSTONRFFPROCESMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSTONRFFPROCESMes_Enabled), 5, 0), true);
         edtCOSTONRFFPROCESAno_Enabled = 0;
         AssignProp("", false, edtCOSTONRFFPROCESAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSTONRFFPROCESAno_Enabled), 5, 0), true);
         edtCod_Area_Enabled = 0;
         AssignProp("", false, edtCod_Area_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCod_Area_Enabled), 5, 0), true);
         edtIndicadoresCodigo_Enabled = 0;
         AssignProp("", false, edtIndicadoresCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIndicadoresCodigo_Enabled), 5, 0), true);
         edtMOTIVOSCOSRFFCodigo_Enabled = 0;
         AssignProp("", false, edtMOTIVOSCOSRFFCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMOTIVOSCOSRFFCodigo_Enabled), 5, 0), true);
         edtCOSTONRFFPROCESValor_Enabled = 0;
         AssignProp("", false, edtCOSTONRFFPROCESValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSTONRFFPROCESValor_Enabled), 5, 0), true);
         edtCOSTONRFFPROCESUser_Enabled = 0;
         AssignProp("", false, edtCOSTONRFFPROCESUser_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSTONRFFPROCESUser_Enabled), 5, 0), true);
         edtCOSTONRFFPROCESReg_Enabled = 0;
         AssignProp("", false, edtCOSTONRFFPROCESReg_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSTONRFFPROCESReg_Enabled), 5, 0), true);
         edtCOSTONRFFPROCESHor_Enabled = 0;
         AssignProp("", false, edtCOSTONRFFPROCESHor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSTONRFFPROCESHor_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1239( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues120( )
      {
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
         MasterPageObj.master_styles();
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
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("costonrffproces.aspx") +"\">") ;
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
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z80COSTONRFFPROCESFecha", context.localUtil.DToC( Z80COSTONRFFPROCESFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z81COSTONRFFPROCESMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z81COSTONRFFPROCESMes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z82COSTONRFFPROCESAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z82COSTONRFFPROCESAno), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z5Cod_Area", Z5Cod_Area);
         GxWebStd.gx_hidden_field( context, "Z4IndicadoresCodigo", Z4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "Z66MOTIVOSCOSRFFCodigo", Z66MOTIVOSCOSRFFCodigo);
         GxWebStd.gx_hidden_field( context, "Z198COSTONRFFPROCESValor", StringUtil.LTrim( StringUtil.NToC( Z198COSTONRFFPROCESValor, 16, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z199COSTONRFFPROCESUser", Z199COSTONRFFPROCESUser);
         GxWebStd.gx_hidden_field( context, "Z200COSTONRFFPROCESReg", context.localUtil.DToC( Z200COSTONRFFPROCESReg, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z201COSTONRFFPROCESHor", Z201COSTONRFFPROCESHor);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
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

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
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
         return formatLink("costonrffproces.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "COSTONRFFPROCES" ;
      }

      public override string GetPgmdesc( )
      {
         return "COSTONRFFPROCES" ;
      }

      protected void InitializeNonKey1239( )
      {
         A198COSTONRFFPROCESValor = 0;
         AssignAttri("", false, "A198COSTONRFFPROCESValor", StringUtil.LTrimStr( A198COSTONRFFPROCESValor, 16, 2));
         A199COSTONRFFPROCESUser = "";
         AssignAttri("", false, "A199COSTONRFFPROCESUser", A199COSTONRFFPROCESUser);
         A200COSTONRFFPROCESReg = DateTime.MinValue;
         AssignAttri("", false, "A200COSTONRFFPROCESReg", context.localUtil.Format(A200COSTONRFFPROCESReg, "99/99/99"));
         A201COSTONRFFPROCESHor = "";
         AssignAttri("", false, "A201COSTONRFFPROCESHor", A201COSTONRFFPROCESHor);
         Z198COSTONRFFPROCESValor = 0;
         Z199COSTONRFFPROCESUser = "";
         Z200COSTONRFFPROCESReg = DateTime.MinValue;
         Z201COSTONRFFPROCESHor = "";
      }

      protected void InitAll1239( )
      {
         A80COSTONRFFPROCESFecha = DateTime.MinValue;
         AssignAttri("", false, "A80COSTONRFFPROCESFecha", context.localUtil.Format(A80COSTONRFFPROCESFecha, "99/99/99"));
         A81COSTONRFFPROCESMes = 0;
         AssignAttri("", false, "A81COSTONRFFPROCESMes", StringUtil.LTrimStr( (decimal)(A81COSTONRFFPROCESMes), 4, 0));
         A82COSTONRFFPROCESAno = 0;
         AssignAttri("", false, "A82COSTONRFFPROCESAno", StringUtil.LTrimStr( (decimal)(A82COSTONRFFPROCESAno), 4, 0));
         A5Cod_Area = "";
         AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
         A4IndicadoresCodigo = "";
         AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
         A66MOTIVOSCOSRFFCodigo = "";
         AssignAttri("", false, "A66MOTIVOSCOSRFFCodigo", A66MOTIVOSCOSRFFCodigo);
         InitializeNonKey1239( ) ;
      }

      protected void StandaloneModalInsert( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20247231025248", true, true);
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
         context.AddJavascriptSource("costonrffproces.js", "?20247231025248", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
         edtCOSTONRFFPROCESFecha_Internalname = "COSTONRFFPROCESFECHA";
         edtCOSTONRFFPROCESMes_Internalname = "COSTONRFFPROCESMES";
         edtCOSTONRFFPROCESAno_Internalname = "COSTONRFFPROCESANO";
         edtCod_Area_Internalname = "COD_AREA";
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO";
         edtMOTIVOSCOSRFFCodigo_Internalname = "MOTIVOSCOSRFFCODIGO";
         edtCOSTONRFFPROCESValor_Internalname = "COSTONRFFPROCESVALOR";
         edtCOSTONRFFPROCESUser_Internalname = "COSTONRFFPROCESUSER";
         edtCOSTONRFFPROCESReg_Internalname = "COSTONRFFPROCESREG";
         edtCOSTONRFFPROCESHor_Internalname = "COSTONRFFPROCESHOR";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_5_Internalname = "PROMPT_5";
         imgprompt_4_Internalname = "PROMPT_4";
         imgprompt_66_Internalname = "PROMPT_66";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("IndicadroresPalmas", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "COSTONRFFPROCES";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCOSTONRFFPROCESHor_Jsonclick = "";
         edtCOSTONRFFPROCESHor_Enabled = 1;
         edtCOSTONRFFPROCESReg_Jsonclick = "";
         edtCOSTONRFFPROCESReg_Enabled = 1;
         edtCOSTONRFFPROCESUser_Jsonclick = "";
         edtCOSTONRFFPROCESUser_Enabled = 1;
         edtCOSTONRFFPROCESValor_Jsonclick = "";
         edtCOSTONRFFPROCESValor_Enabled = 1;
         imgprompt_66_Visible = 1;
         imgprompt_66_Link = "";
         edtMOTIVOSCOSRFFCodigo_Jsonclick = "";
         edtMOTIVOSCOSRFFCodigo_Enabled = 1;
         imgprompt_4_Visible = 1;
         imgprompt_4_Link = "";
         edtIndicadoresCodigo_Jsonclick = "";
         edtIndicadoresCodigo_Enabled = 1;
         imgprompt_5_Visible = 1;
         imgprompt_5_Link = "";
         edtCod_Area_Jsonclick = "";
         edtCod_Area_Enabled = 1;
         edtCOSTONRFFPROCESAno_Jsonclick = "";
         edtCOSTONRFFPROCESAno_Enabled = 1;
         edtCOSTONRFFPROCESMes_Jsonclick = "";
         edtCOSTONRFFPROCESMes_Enabled = 1;
         edtCOSTONRFFPROCESFecha_Jsonclick = "";
         edtCOSTONRFFPROCESFecha_Enabled = 1;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         /* Using cursor T001218 */
         pr_default.execute(16, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(16);
         /* Using cursor T001219 */
         pr_default.execute(17, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(17);
         /* Using cursor T001220 */
         pr_default.execute(18, new Object[] {A66MOTIVOSCOSRFFCodigo});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'MOTIVOSCOSRFF'.", "ForeignKeyNotFound", 1, "MOTIVOSCOSRFFCODIGO");
            AnyError = 1;
            GX_FocusControl = edtMOTIVOSCOSRFFCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(18);
         GX_FocusControl = edtCOSTONRFFPROCESValor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
         /* End function AfterKeyLoadScreen */
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void Valid_Cod_area( )
      {
         /* Using cursor T001218 */
         pr_default.execute(16, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
         }
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Indicadorescodigo( )
      {
         /* Using cursor T001219 */
         pr_default.execute(17, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
         }
         pr_default.close(17);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Motivoscosrffcodigo( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T001220 */
         pr_default.execute(18, new Object[] {A66MOTIVOSCOSRFFCodigo});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'MOTIVOSCOSRFF'.", "ForeignKeyNotFound", 1, "MOTIVOSCOSRFFCODIGO");
            AnyError = 1;
            GX_FocusControl = edtMOTIVOSCOSRFFCodigo_Internalname;
         }
         pr_default.close(18);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A198COSTONRFFPROCESValor", StringUtil.LTrim( StringUtil.NToC( A198COSTONRFFPROCESValor, 16, 2, ".", "")));
         AssignAttri("", false, "A199COSTONRFFPROCESUser", A199COSTONRFFPROCESUser);
         AssignAttri("", false, "A200COSTONRFFPROCESReg", context.localUtil.Format(A200COSTONRFFPROCESReg, "99/99/99"));
         AssignAttri("", false, "A201COSTONRFFPROCESHor", A201COSTONRFFPROCESHor);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z80COSTONRFFPROCESFecha", context.localUtil.Format(Z80COSTONRFFPROCESFecha, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z81COSTONRFFPROCESMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z81COSTONRFFPROCESMes), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z82COSTONRFFPROCESAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z82COSTONRFFPROCESAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z5Cod_Area", Z5Cod_Area);
         GxWebStd.gx_hidden_field( context, "Z4IndicadoresCodigo", Z4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "Z66MOTIVOSCOSRFFCodigo", Z66MOTIVOSCOSRFFCodigo);
         GxWebStd.gx_hidden_field( context, "Z198COSTONRFFPROCESValor", StringUtil.LTrim( StringUtil.NToC( Z198COSTONRFFPROCESValor, 16, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z199COSTONRFFPROCESUser", Z199COSTONRFFPROCESUser);
         GxWebStd.gx_hidden_field( context, "Z200COSTONRFFPROCESReg", context.localUtil.Format(Z200COSTONRFFPROCESReg, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z201COSTONRFFPROCESHor", Z201COSTONRFFPROCESHor);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_COSTONRFFPROCESFECHA","{handler:'Valid_Costonrffprocesfecha',iparms:[]");
         setEventMetadata("VALID_COSTONRFFPROCESFECHA",",oparms:[]}");
         setEventMetadata("VALID_COSTONRFFPROCESMES","{handler:'Valid_Costonrffprocesmes',iparms:[]");
         setEventMetadata("VALID_COSTONRFFPROCESMES",",oparms:[]}");
         setEventMetadata("VALID_COSTONRFFPROCESANO","{handler:'Valid_Costonrffprocesano',iparms:[]");
         setEventMetadata("VALID_COSTONRFFPROCESANO",",oparms:[]}");
         setEventMetadata("VALID_COD_AREA","{handler:'Valid_Cod_area',iparms:[{av:'A5Cod_Area',fld:'COD_AREA',pic:''}]");
         setEventMetadata("VALID_COD_AREA",",oparms:[]}");
         setEventMetadata("VALID_INDICADORESCODIGO","{handler:'Valid_Indicadorescodigo',iparms:[{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:''}]");
         setEventMetadata("VALID_INDICADORESCODIGO",",oparms:[]}");
         setEventMetadata("VALID_MOTIVOSCOSRFFCODIGO","{handler:'Valid_Motivoscosrffcodigo',iparms:[{av:'A80COSTONRFFPROCESFecha',fld:'COSTONRFFPROCESFECHA',pic:''},{av:'A81COSTONRFFPROCESMes',fld:'COSTONRFFPROCESMES',pic:'ZZZ9'},{av:'A82COSTONRFFPROCESAno',fld:'COSTONRFFPROCESANO',pic:'ZZZ9'},{av:'A5Cod_Area',fld:'COD_AREA',pic:''},{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:''},{av:'A66MOTIVOSCOSRFFCodigo',fld:'MOTIVOSCOSRFFCODIGO',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_MOTIVOSCOSRFFCODIGO",",oparms:[{av:'A198COSTONRFFPROCESValor',fld:'COSTONRFFPROCESVALOR',pic:'ZZZZZZZZZZZZ9.99'},{av:'A199COSTONRFFPROCESUser',fld:'COSTONRFFPROCESUSER',pic:''},{av:'A200COSTONRFFPROCESReg',fld:'COSTONRFFPROCESREG',pic:''},{av:'A201COSTONRFFPROCESHor',fld:'COSTONRFFPROCESHOR',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z80COSTONRFFPROCESFecha'},{av:'Z81COSTONRFFPROCESMes'},{av:'Z82COSTONRFFPROCESAno'},{av:'Z5Cod_Area'},{av:'Z4IndicadoresCodigo'},{av:'Z66MOTIVOSCOSRFFCodigo'},{av:'Z198COSTONRFFPROCESValor'},{av:'Z199COSTONRFFPROCESUser'},{av:'Z200COSTONRFFPROCESReg'},{av:'Z201COSTONRFFPROCESHor'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_COSTONRFFPROCESREG","{handler:'Valid_Costonrffprocesreg',iparms:[]");
         setEventMetadata("VALID_COSTONRFFPROCESREG",",oparms:[]}");
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
         pr_default.close(1);
         pr_default.close(16);
         pr_default.close(17);
         pr_default.close(18);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z80COSTONRFFPROCESFecha = DateTime.MinValue;
         Z5Cod_Area = "";
         Z4IndicadoresCodigo = "";
         Z66MOTIVOSCOSRFFCodigo = "";
         Z199COSTONRFFPROCESUser = "";
         Z200COSTONRFFPROCESReg = DateTime.MinValue;
         Z201COSTONRFFPROCESHor = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A5Cod_Area = "";
         A4IndicadoresCodigo = "";
         A66MOTIVOSCOSRFFCodigo = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A80COSTONRFFPROCESFecha = DateTime.MinValue;
         imgprompt_5_gximage = "";
         sImgUrl = "";
         imgprompt_4_gximage = "";
         imgprompt_66_gximage = "";
         A199COSTONRFFPROCESUser = "";
         A200COSTONRFFPROCESReg = DateTime.MinValue;
         A201COSTONRFFPROCESHor = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_mode = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         T00127_A80COSTONRFFPROCESFecha = new DateTime[] {DateTime.MinValue} ;
         T00127_A81COSTONRFFPROCESMes = new short[1] ;
         T00127_A82COSTONRFFPROCESAno = new short[1] ;
         T00127_A198COSTONRFFPROCESValor = new decimal[1] ;
         T00127_A199COSTONRFFPROCESUser = new string[] {""} ;
         T00127_A200COSTONRFFPROCESReg = new DateTime[] {DateTime.MinValue} ;
         T00127_A201COSTONRFFPROCESHor = new string[] {""} ;
         T00127_A5Cod_Area = new string[] {""} ;
         T00127_A4IndicadoresCodigo = new string[] {""} ;
         T00127_A66MOTIVOSCOSRFFCodigo = new string[] {""} ;
         T00124_A5Cod_Area = new string[] {""} ;
         T00125_A4IndicadoresCodigo = new string[] {""} ;
         T00126_A66MOTIVOSCOSRFFCodigo = new string[] {""} ;
         T00128_A5Cod_Area = new string[] {""} ;
         T00129_A4IndicadoresCodigo = new string[] {""} ;
         T001210_A66MOTIVOSCOSRFFCodigo = new string[] {""} ;
         T001211_A80COSTONRFFPROCESFecha = new DateTime[] {DateTime.MinValue} ;
         T001211_A81COSTONRFFPROCESMes = new short[1] ;
         T001211_A82COSTONRFFPROCESAno = new short[1] ;
         T001211_A5Cod_Area = new string[] {""} ;
         T001211_A4IndicadoresCodigo = new string[] {""} ;
         T001211_A66MOTIVOSCOSRFFCodigo = new string[] {""} ;
         T00123_A80COSTONRFFPROCESFecha = new DateTime[] {DateTime.MinValue} ;
         T00123_A81COSTONRFFPROCESMes = new short[1] ;
         T00123_A82COSTONRFFPROCESAno = new short[1] ;
         T00123_A198COSTONRFFPROCESValor = new decimal[1] ;
         T00123_A199COSTONRFFPROCESUser = new string[] {""} ;
         T00123_A200COSTONRFFPROCESReg = new DateTime[] {DateTime.MinValue} ;
         T00123_A201COSTONRFFPROCESHor = new string[] {""} ;
         T00123_A5Cod_Area = new string[] {""} ;
         T00123_A4IndicadoresCodigo = new string[] {""} ;
         T00123_A66MOTIVOSCOSRFFCodigo = new string[] {""} ;
         sMode39 = "";
         T001212_A80COSTONRFFPROCESFecha = new DateTime[] {DateTime.MinValue} ;
         T001212_A81COSTONRFFPROCESMes = new short[1] ;
         T001212_A82COSTONRFFPROCESAno = new short[1] ;
         T001212_A5Cod_Area = new string[] {""} ;
         T001212_A4IndicadoresCodigo = new string[] {""} ;
         T001212_A66MOTIVOSCOSRFFCodigo = new string[] {""} ;
         T001213_A80COSTONRFFPROCESFecha = new DateTime[] {DateTime.MinValue} ;
         T001213_A81COSTONRFFPROCESMes = new short[1] ;
         T001213_A82COSTONRFFPROCESAno = new short[1] ;
         T001213_A5Cod_Area = new string[] {""} ;
         T001213_A4IndicadoresCodigo = new string[] {""} ;
         T001213_A66MOTIVOSCOSRFFCodigo = new string[] {""} ;
         T00122_A80COSTONRFFPROCESFecha = new DateTime[] {DateTime.MinValue} ;
         T00122_A81COSTONRFFPROCESMes = new short[1] ;
         T00122_A82COSTONRFFPROCESAno = new short[1] ;
         T00122_A198COSTONRFFPROCESValor = new decimal[1] ;
         T00122_A199COSTONRFFPROCESUser = new string[] {""} ;
         T00122_A200COSTONRFFPROCESReg = new DateTime[] {DateTime.MinValue} ;
         T00122_A201COSTONRFFPROCESHor = new string[] {""} ;
         T00122_A5Cod_Area = new string[] {""} ;
         T00122_A4IndicadoresCodigo = new string[] {""} ;
         T00122_A66MOTIVOSCOSRFFCodigo = new string[] {""} ;
         T001217_A80COSTONRFFPROCESFecha = new DateTime[] {DateTime.MinValue} ;
         T001217_A81COSTONRFFPROCESMes = new short[1] ;
         T001217_A82COSTONRFFPROCESAno = new short[1] ;
         T001217_A5Cod_Area = new string[] {""} ;
         T001217_A4IndicadoresCodigo = new string[] {""} ;
         T001217_A66MOTIVOSCOSRFFCodigo = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T001218_A5Cod_Area = new string[] {""} ;
         T001219_A4IndicadoresCodigo = new string[] {""} ;
         T001220_A66MOTIVOSCOSRFFCodigo = new string[] {""} ;
         ZZ80COSTONRFFPROCESFecha = DateTime.MinValue;
         ZZ5Cod_Area = "";
         ZZ4IndicadoresCodigo = "";
         ZZ66MOTIVOSCOSRFFCodigo = "";
         ZZ199COSTONRFFPROCESUser = "";
         ZZ200COSTONRFFPROCESReg = DateTime.MinValue;
         ZZ201COSTONRFFPROCESHor = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.costonrffproces__default(),
            new Object[][] {
                new Object[] {
               T00122_A80COSTONRFFPROCESFecha, T00122_A81COSTONRFFPROCESMes, T00122_A82COSTONRFFPROCESAno, T00122_A198COSTONRFFPROCESValor, T00122_A199COSTONRFFPROCESUser, T00122_A200COSTONRFFPROCESReg, T00122_A201COSTONRFFPROCESHor, T00122_A5Cod_Area, T00122_A4IndicadoresCodigo, T00122_A66MOTIVOSCOSRFFCodigo
               }
               , new Object[] {
               T00123_A80COSTONRFFPROCESFecha, T00123_A81COSTONRFFPROCESMes, T00123_A82COSTONRFFPROCESAno, T00123_A198COSTONRFFPROCESValor, T00123_A199COSTONRFFPROCESUser, T00123_A200COSTONRFFPROCESReg, T00123_A201COSTONRFFPROCESHor, T00123_A5Cod_Area, T00123_A4IndicadoresCodigo, T00123_A66MOTIVOSCOSRFFCodigo
               }
               , new Object[] {
               T00124_A5Cod_Area
               }
               , new Object[] {
               T00125_A4IndicadoresCodigo
               }
               , new Object[] {
               T00126_A66MOTIVOSCOSRFFCodigo
               }
               , new Object[] {
               T00127_A80COSTONRFFPROCESFecha, T00127_A81COSTONRFFPROCESMes, T00127_A82COSTONRFFPROCESAno, T00127_A198COSTONRFFPROCESValor, T00127_A199COSTONRFFPROCESUser, T00127_A200COSTONRFFPROCESReg, T00127_A201COSTONRFFPROCESHor, T00127_A5Cod_Area, T00127_A4IndicadoresCodigo, T00127_A66MOTIVOSCOSRFFCodigo
               }
               , new Object[] {
               T00128_A5Cod_Area
               }
               , new Object[] {
               T00129_A4IndicadoresCodigo
               }
               , new Object[] {
               T001210_A66MOTIVOSCOSRFFCodigo
               }
               , new Object[] {
               T001211_A80COSTONRFFPROCESFecha, T001211_A81COSTONRFFPROCESMes, T001211_A82COSTONRFFPROCESAno, T001211_A5Cod_Area, T001211_A4IndicadoresCodigo, T001211_A66MOTIVOSCOSRFFCodigo
               }
               , new Object[] {
               T001212_A80COSTONRFFPROCESFecha, T001212_A81COSTONRFFPROCESMes, T001212_A82COSTONRFFPROCESAno, T001212_A5Cod_Area, T001212_A4IndicadoresCodigo, T001212_A66MOTIVOSCOSRFFCodigo
               }
               , new Object[] {
               T001213_A80COSTONRFFPROCESFecha, T001213_A81COSTONRFFPROCESMes, T001213_A82COSTONRFFPROCESAno, T001213_A5Cod_Area, T001213_A4IndicadoresCodigo, T001213_A66MOTIVOSCOSRFFCodigo
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001217_A80COSTONRFFPROCESFecha, T001217_A81COSTONRFFPROCESMes, T001217_A82COSTONRFFPROCESAno, T001217_A5Cod_Area, T001217_A4IndicadoresCodigo, T001217_A66MOTIVOSCOSRFFCodigo
               }
               , new Object[] {
               T001218_A5Cod_Area
               }
               , new Object[] {
               T001219_A4IndicadoresCodigo
               }
               , new Object[] {
               T001220_A66MOTIVOSCOSRFFCodigo
               }
            }
         );
      }

      private short Z81COSTONRFFPROCESMes ;
      private short Z82COSTONRFFPROCESAno ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A81COSTONRFFPROCESMes ;
      private short A82COSTONRFFPROCESAno ;
      private short GX_JID ;
      private short RcdFound39 ;
      private short nIsDirty_39 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ81COSTONRFFPROCESMes ;
      private short ZZ82COSTONRFFPROCESAno ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtCOSTONRFFPROCESFecha_Enabled ;
      private int edtCOSTONRFFPROCESMes_Enabled ;
      private int edtCOSTONRFFPROCESAno_Enabled ;
      private int edtCod_Area_Enabled ;
      private int imgprompt_5_Visible ;
      private int edtIndicadoresCodigo_Enabled ;
      private int imgprompt_4_Visible ;
      private int edtMOTIVOSCOSRFFCodigo_Enabled ;
      private int imgprompt_66_Visible ;
      private int edtCOSTONRFFPROCESValor_Enabled ;
      private int edtCOSTONRFFPROCESUser_Enabled ;
      private int edtCOSTONRFFPROCESReg_Enabled ;
      private int edtCOSTONRFFPROCESHor_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private decimal Z198COSTONRFFPROCESValor ;
      private decimal A198COSTONRFFPROCESValor ;
      private decimal ZZ198COSTONRFFPROCESValor ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCOSTONRFFPROCESFecha_Internalname ;
      private string divMaintable_Internalname ;
      private string divTitlecontainer_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divFormcontainer_Internalname ;
      private string divToolbarcell_Internalname ;
      private string TempTags ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
      private string edtCOSTONRFFPROCESFecha_Jsonclick ;
      private string edtCOSTONRFFPROCESMes_Internalname ;
      private string edtCOSTONRFFPROCESMes_Jsonclick ;
      private string edtCOSTONRFFPROCESAno_Internalname ;
      private string edtCOSTONRFFPROCESAno_Jsonclick ;
      private string edtCod_Area_Internalname ;
      private string edtCod_Area_Jsonclick ;
      private string imgprompt_5_gximage ;
      private string sImgUrl ;
      private string imgprompt_5_Internalname ;
      private string imgprompt_5_Link ;
      private string edtIndicadoresCodigo_Internalname ;
      private string edtIndicadoresCodigo_Jsonclick ;
      private string imgprompt_4_gximage ;
      private string imgprompt_4_Internalname ;
      private string imgprompt_4_Link ;
      private string edtMOTIVOSCOSRFFCodigo_Internalname ;
      private string edtMOTIVOSCOSRFFCodigo_Jsonclick ;
      private string imgprompt_66_gximage ;
      private string imgprompt_66_Internalname ;
      private string imgprompt_66_Link ;
      private string edtCOSTONRFFPROCESValor_Internalname ;
      private string edtCOSTONRFFPROCESValor_Jsonclick ;
      private string edtCOSTONRFFPROCESUser_Internalname ;
      private string edtCOSTONRFFPROCESUser_Jsonclick ;
      private string edtCOSTONRFFPROCESReg_Internalname ;
      private string edtCOSTONRFFPROCESReg_Jsonclick ;
      private string edtCOSTONRFFPROCESHor_Internalname ;
      private string edtCOSTONRFFPROCESHor_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string Gx_mode ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode39 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z80COSTONRFFPROCESFecha ;
      private DateTime Z200COSTONRFFPROCESReg ;
      private DateTime A80COSTONRFFPROCESFecha ;
      private DateTime A200COSTONRFFPROCESReg ;
      private DateTime ZZ80COSTONRFFPROCESFecha ;
      private DateTime ZZ200COSTONRFFPROCESReg ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string Z5Cod_Area ;
      private string Z4IndicadoresCodigo ;
      private string Z66MOTIVOSCOSRFFCodigo ;
      private string Z199COSTONRFFPROCESUser ;
      private string Z201COSTONRFFPROCESHor ;
      private string A5Cod_Area ;
      private string A4IndicadoresCodigo ;
      private string A66MOTIVOSCOSRFFCodigo ;
      private string A199COSTONRFFPROCESUser ;
      private string A201COSTONRFFPROCESHor ;
      private string ZZ5Cod_Area ;
      private string ZZ4IndicadoresCodigo ;
      private string ZZ66MOTIVOSCOSRFFCodigo ;
      private string ZZ199COSTONRFFPROCESUser ;
      private string ZZ201COSTONRFFPROCESHor ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] T00127_A80COSTONRFFPROCESFecha ;
      private short[] T00127_A81COSTONRFFPROCESMes ;
      private short[] T00127_A82COSTONRFFPROCESAno ;
      private decimal[] T00127_A198COSTONRFFPROCESValor ;
      private string[] T00127_A199COSTONRFFPROCESUser ;
      private DateTime[] T00127_A200COSTONRFFPROCESReg ;
      private string[] T00127_A201COSTONRFFPROCESHor ;
      private string[] T00127_A5Cod_Area ;
      private string[] T00127_A4IndicadoresCodigo ;
      private string[] T00127_A66MOTIVOSCOSRFFCodigo ;
      private string[] T00124_A5Cod_Area ;
      private string[] T00125_A4IndicadoresCodigo ;
      private string[] T00126_A66MOTIVOSCOSRFFCodigo ;
      private string[] T00128_A5Cod_Area ;
      private string[] T00129_A4IndicadoresCodigo ;
      private string[] T001210_A66MOTIVOSCOSRFFCodigo ;
      private DateTime[] T001211_A80COSTONRFFPROCESFecha ;
      private short[] T001211_A81COSTONRFFPROCESMes ;
      private short[] T001211_A82COSTONRFFPROCESAno ;
      private string[] T001211_A5Cod_Area ;
      private string[] T001211_A4IndicadoresCodigo ;
      private string[] T001211_A66MOTIVOSCOSRFFCodigo ;
      private DateTime[] T00123_A80COSTONRFFPROCESFecha ;
      private short[] T00123_A81COSTONRFFPROCESMes ;
      private short[] T00123_A82COSTONRFFPROCESAno ;
      private decimal[] T00123_A198COSTONRFFPROCESValor ;
      private string[] T00123_A199COSTONRFFPROCESUser ;
      private DateTime[] T00123_A200COSTONRFFPROCESReg ;
      private string[] T00123_A201COSTONRFFPROCESHor ;
      private string[] T00123_A5Cod_Area ;
      private string[] T00123_A4IndicadoresCodigo ;
      private string[] T00123_A66MOTIVOSCOSRFFCodigo ;
      private DateTime[] T001212_A80COSTONRFFPROCESFecha ;
      private short[] T001212_A81COSTONRFFPROCESMes ;
      private short[] T001212_A82COSTONRFFPROCESAno ;
      private string[] T001212_A5Cod_Area ;
      private string[] T001212_A4IndicadoresCodigo ;
      private string[] T001212_A66MOTIVOSCOSRFFCodigo ;
      private DateTime[] T001213_A80COSTONRFFPROCESFecha ;
      private short[] T001213_A81COSTONRFFPROCESMes ;
      private short[] T001213_A82COSTONRFFPROCESAno ;
      private string[] T001213_A5Cod_Area ;
      private string[] T001213_A4IndicadoresCodigo ;
      private string[] T001213_A66MOTIVOSCOSRFFCodigo ;
      private DateTime[] T00122_A80COSTONRFFPROCESFecha ;
      private short[] T00122_A81COSTONRFFPROCESMes ;
      private short[] T00122_A82COSTONRFFPROCESAno ;
      private decimal[] T00122_A198COSTONRFFPROCESValor ;
      private string[] T00122_A199COSTONRFFPROCESUser ;
      private DateTime[] T00122_A200COSTONRFFPROCESReg ;
      private string[] T00122_A201COSTONRFFPROCESHor ;
      private string[] T00122_A5Cod_Area ;
      private string[] T00122_A4IndicadoresCodigo ;
      private string[] T00122_A66MOTIVOSCOSRFFCodigo ;
      private DateTime[] T001217_A80COSTONRFFPROCESFecha ;
      private short[] T001217_A81COSTONRFFPROCESMes ;
      private short[] T001217_A82COSTONRFFPROCESAno ;
      private string[] T001217_A5Cod_Area ;
      private string[] T001217_A4IndicadoresCodigo ;
      private string[] T001217_A66MOTIVOSCOSRFFCodigo ;
      private string[] T001218_A5Cod_Area ;
      private string[] T001219_A4IndicadoresCodigo ;
      private string[] T001220_A66MOTIVOSCOSRFFCodigo ;
      private GXWebForm Form ;
   }

   public class costonrffproces__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new UpdateCursor(def[13])
         ,new UpdateCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00127;
          prmT00127 = new Object[] {
          new ParDef("@COSTONRFFPROCESFecha",GXType.Date,8,0) ,
          new ParDef("@COSTONRFFPROCESMes",GXType.Int16,4,0) ,
          new ParDef("@COSTONRFFPROCESAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MOTIVOSCOSRFFCodigo",GXType.NVarChar,140,0)
          };
          Object[] prmT00124;
          prmT00124 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT00125;
          prmT00125 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT00126;
          prmT00126 = new Object[] {
          new ParDef("@MOTIVOSCOSRFFCodigo",GXType.NVarChar,140,0)
          };
          Object[] prmT00128;
          prmT00128 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT00129;
          prmT00129 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT001210;
          prmT001210 = new Object[] {
          new ParDef("@MOTIVOSCOSRFFCodigo",GXType.NVarChar,140,0)
          };
          Object[] prmT001211;
          prmT001211 = new Object[] {
          new ParDef("@COSTONRFFPROCESFecha",GXType.Date,8,0) ,
          new ParDef("@COSTONRFFPROCESMes",GXType.Int16,4,0) ,
          new ParDef("@COSTONRFFPROCESAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MOTIVOSCOSRFFCodigo",GXType.NVarChar,140,0)
          };
          Object[] prmT00123;
          prmT00123 = new Object[] {
          new ParDef("@COSTONRFFPROCESFecha",GXType.Date,8,0) ,
          new ParDef("@COSTONRFFPROCESMes",GXType.Int16,4,0) ,
          new ParDef("@COSTONRFFPROCESAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MOTIVOSCOSRFFCodigo",GXType.NVarChar,140,0)
          };
          Object[] prmT001212;
          prmT001212 = new Object[] {
          new ParDef("@COSTONRFFPROCESFecha",GXType.Date,8,0) ,
          new ParDef("@COSTONRFFPROCESMes",GXType.Int16,4,0) ,
          new ParDef("@COSTONRFFPROCESAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MOTIVOSCOSRFFCodigo",GXType.NVarChar,140,0)
          };
          Object[] prmT001213;
          prmT001213 = new Object[] {
          new ParDef("@COSTONRFFPROCESFecha",GXType.Date,8,0) ,
          new ParDef("@COSTONRFFPROCESMes",GXType.Int16,4,0) ,
          new ParDef("@COSTONRFFPROCESAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MOTIVOSCOSRFFCodigo",GXType.NVarChar,140,0)
          };
          Object[] prmT00122;
          prmT00122 = new Object[] {
          new ParDef("@COSTONRFFPROCESFecha",GXType.Date,8,0) ,
          new ParDef("@COSTONRFFPROCESMes",GXType.Int16,4,0) ,
          new ParDef("@COSTONRFFPROCESAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MOTIVOSCOSRFFCodigo",GXType.NVarChar,140,0)
          };
          Object[] prmT001214;
          prmT001214 = new Object[] {
          new ParDef("@COSTONRFFPROCESFecha",GXType.Date,8,0) ,
          new ParDef("@COSTONRFFPROCESMes",GXType.Int16,4,0) ,
          new ParDef("@COSTONRFFPROCESAno",GXType.Int16,4,0) ,
          new ParDef("@COSTONRFFPROCESValor",GXType.Decimal,16,2) ,
          new ParDef("@COSTONRFFPROCESUser",GXType.NVarChar,150,0) ,
          new ParDef("@COSTONRFFPROCESReg",GXType.Date,8,0) ,
          new ParDef("@COSTONRFFPROCESHor",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MOTIVOSCOSRFFCodigo",GXType.NVarChar,140,0)
          };
          Object[] prmT001215;
          prmT001215 = new Object[] {
          new ParDef("@COSTONRFFPROCESValor",GXType.Decimal,16,2) ,
          new ParDef("@COSTONRFFPROCESUser",GXType.NVarChar,150,0) ,
          new ParDef("@COSTONRFFPROCESReg",GXType.Date,8,0) ,
          new ParDef("@COSTONRFFPROCESHor",GXType.NVarChar,40,0) ,
          new ParDef("@COSTONRFFPROCESFecha",GXType.Date,8,0) ,
          new ParDef("@COSTONRFFPROCESMes",GXType.Int16,4,0) ,
          new ParDef("@COSTONRFFPROCESAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MOTIVOSCOSRFFCodigo",GXType.NVarChar,140,0)
          };
          Object[] prmT001216;
          prmT001216 = new Object[] {
          new ParDef("@COSTONRFFPROCESFecha",GXType.Date,8,0) ,
          new ParDef("@COSTONRFFPROCESMes",GXType.Int16,4,0) ,
          new ParDef("@COSTONRFFPROCESAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MOTIVOSCOSRFFCodigo",GXType.NVarChar,140,0)
          };
          Object[] prmT001217;
          prmT001217 = new Object[] {
          };
          Object[] prmT001218;
          prmT001218 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT001219;
          prmT001219 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT001220;
          prmT001220 = new Object[] {
          new ParDef("@MOTIVOSCOSRFFCodigo",GXType.NVarChar,140,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00122", "SELECT [COSTONRFFPROCESFecha], [COSTONRFFPROCESMes], [COSTONRFFPROCESAno], [COSTONRFFPROCESValor], [COSTONRFFPROCESUser], [COSTONRFFPROCESReg], [COSTONRFFPROCESHor], [Cod_Area], [IndicadoresCodigo], [MOTIVOSCOSRFFCodigo] FROM [COSTONRFFPROCES] WITH (UPDLOCK) WHERE [COSTONRFFPROCESFecha] = @COSTONRFFPROCESFecha AND [COSTONRFFPROCESMes] = @COSTONRFFPROCESMes AND [COSTONRFFPROCESAno] = @COSTONRFFPROCESAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo AND [MOTIVOSCOSRFFCodigo] = @MOTIVOSCOSRFFCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT00122,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00123", "SELECT [COSTONRFFPROCESFecha], [COSTONRFFPROCESMes], [COSTONRFFPROCESAno], [COSTONRFFPROCESValor], [COSTONRFFPROCESUser], [COSTONRFFPROCESReg], [COSTONRFFPROCESHor], [Cod_Area], [IndicadoresCodigo], [MOTIVOSCOSRFFCodigo] FROM [COSTONRFFPROCES] WHERE [COSTONRFFPROCESFecha] = @COSTONRFFPROCESFecha AND [COSTONRFFPROCESMes] = @COSTONRFFPROCESMes AND [COSTONRFFPROCESAno] = @COSTONRFFPROCESAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo AND [MOTIVOSCOSRFFCodigo] = @MOTIVOSCOSRFFCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT00123,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00124", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT00124,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00125", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT00125,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00126", "SELECT [MOTIVOSCOSRFFCodigo] FROM [MOTIVOSCOSRFF] WHERE [MOTIVOSCOSRFFCodigo] = @MOTIVOSCOSRFFCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT00126,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00127", "SELECT TM1.[COSTONRFFPROCESFecha], TM1.[COSTONRFFPROCESMes], TM1.[COSTONRFFPROCESAno], TM1.[COSTONRFFPROCESValor], TM1.[COSTONRFFPROCESUser], TM1.[COSTONRFFPROCESReg], TM1.[COSTONRFFPROCESHor], TM1.[Cod_Area], TM1.[IndicadoresCodigo], TM1.[MOTIVOSCOSRFFCodigo] FROM [COSTONRFFPROCES] TM1 WHERE TM1.[COSTONRFFPROCESFecha] = @COSTONRFFPROCESFecha and TM1.[COSTONRFFPROCESMes] = @COSTONRFFPROCESMes and TM1.[COSTONRFFPROCESAno] = @COSTONRFFPROCESAno and TM1.[Cod_Area] = @Cod_Area and TM1.[IndicadoresCodigo] = @IndicadoresCodigo and TM1.[MOTIVOSCOSRFFCodigo] = @MOTIVOSCOSRFFCodigo ORDER BY TM1.[COSTONRFFPROCESFecha], TM1.[COSTONRFFPROCESMes], TM1.[COSTONRFFPROCESAno], TM1.[Cod_Area], TM1.[IndicadoresCodigo], TM1.[MOTIVOSCOSRFFCodigo]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00127,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00128", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT00128,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00129", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT00129,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001210", "SELECT [MOTIVOSCOSRFFCodigo] FROM [MOTIVOSCOSRFF] WHERE [MOTIVOSCOSRFFCodigo] = @MOTIVOSCOSRFFCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT001210,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001211", "SELECT [COSTONRFFPROCESFecha], [COSTONRFFPROCESMes], [COSTONRFFPROCESAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOSCOSRFFCodigo] FROM [COSTONRFFPROCES] WHERE [COSTONRFFPROCESFecha] = @COSTONRFFPROCESFecha AND [COSTONRFFPROCESMes] = @COSTONRFFPROCESMes AND [COSTONRFFPROCESAno] = @COSTONRFFPROCESAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo AND [MOTIVOSCOSRFFCodigo] = @MOTIVOSCOSRFFCodigo  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001211,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001212", "SELECT TOP 1 [COSTONRFFPROCESFecha], [COSTONRFFPROCESMes], [COSTONRFFPROCESAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOSCOSRFFCodigo] FROM [COSTONRFFPROCES] WHERE ( [COSTONRFFPROCESFecha] > @COSTONRFFPROCESFecha or [COSTONRFFPROCESFecha] = @COSTONRFFPROCESFecha and [COSTONRFFPROCESMes] > @COSTONRFFPROCESMes or [COSTONRFFPROCESMes] = @COSTONRFFPROCESMes and [COSTONRFFPROCESFecha] = @COSTONRFFPROCESFecha and [COSTONRFFPROCESAno] > @COSTONRFFPROCESAno or [COSTONRFFPROCESAno] = @COSTONRFFPROCESAno and [COSTONRFFPROCESMes] = @COSTONRFFPROCESMes and [COSTONRFFPROCESFecha] = @COSTONRFFPROCESFecha and [Cod_Area] > @Cod_Area or [Cod_Area] = @Cod_Area and [COSTONRFFPROCESAno] = @COSTONRFFPROCESAno and [COSTONRFFPROCESMes] = @COSTONRFFPROCESMes and [COSTONRFFPROCESFecha] = @COSTONRFFPROCESFecha and [IndicadoresCodigo] > @IndicadoresCodigo or [IndicadoresCodigo] = @IndicadoresCodigo and [Cod_Area] = @Cod_Area and [COSTONRFFPROCESAno] = @COSTONRFFPROCESAno and [COSTONRFFPROCESMes] = @COSTONRFFPROCESMes and [COSTONRFFPROCESFecha] = @COSTONRFFPROCESFecha and [MOTIVOSCOSRFFCodigo] > @MOTIVOSCOSRFFCodigo) ORDER BY [COSTONRFFPROCESFecha], [COSTONRFFPROCESMes], [COSTONRFFPROCESAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOSCOSRFFCodigo]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001212,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001213", "SELECT TOP 1 [COSTONRFFPROCESFecha], [COSTONRFFPROCESMes], [COSTONRFFPROCESAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOSCOSRFFCodigo] FROM [COSTONRFFPROCES] WHERE ( [COSTONRFFPROCESFecha] < @COSTONRFFPROCESFecha or [COSTONRFFPROCESFecha] = @COSTONRFFPROCESFecha and [COSTONRFFPROCESMes] < @COSTONRFFPROCESMes or [COSTONRFFPROCESMes] = @COSTONRFFPROCESMes and [COSTONRFFPROCESFecha] = @COSTONRFFPROCESFecha and [COSTONRFFPROCESAno] < @COSTONRFFPROCESAno or [COSTONRFFPROCESAno] = @COSTONRFFPROCESAno and [COSTONRFFPROCESMes] = @COSTONRFFPROCESMes and [COSTONRFFPROCESFecha] = @COSTONRFFPROCESFecha and [Cod_Area] < @Cod_Area or [Cod_Area] = @Cod_Area and [COSTONRFFPROCESAno] = @COSTONRFFPROCESAno and [COSTONRFFPROCESMes] = @COSTONRFFPROCESMes and [COSTONRFFPROCESFecha] = @COSTONRFFPROCESFecha and [IndicadoresCodigo] < @IndicadoresCodigo or [IndicadoresCodigo] = @IndicadoresCodigo and [Cod_Area] = @Cod_Area and [COSTONRFFPROCESAno] = @COSTONRFFPROCESAno and [COSTONRFFPROCESMes] = @COSTONRFFPROCESMes and [COSTONRFFPROCESFecha] = @COSTONRFFPROCESFecha and [MOTIVOSCOSRFFCodigo] < @MOTIVOSCOSRFFCodigo) ORDER BY [COSTONRFFPROCESFecha] DESC, [COSTONRFFPROCESMes] DESC, [COSTONRFFPROCESAno] DESC, [Cod_Area] DESC, [IndicadoresCodigo] DESC, [MOTIVOSCOSRFFCodigo] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001213,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001214", "INSERT INTO [COSTONRFFPROCES]([COSTONRFFPROCESFecha], [COSTONRFFPROCESMes], [COSTONRFFPROCESAno], [COSTONRFFPROCESValor], [COSTONRFFPROCESUser], [COSTONRFFPROCESReg], [COSTONRFFPROCESHor], [Cod_Area], [IndicadoresCodigo], [MOTIVOSCOSRFFCodigo]) VALUES(@COSTONRFFPROCESFecha, @COSTONRFFPROCESMes, @COSTONRFFPROCESAno, @COSTONRFFPROCESValor, @COSTONRFFPROCESUser, @COSTONRFFPROCESReg, @COSTONRFFPROCESHor, @Cod_Area, @IndicadoresCodigo, @MOTIVOSCOSRFFCodigo)", GxErrorMask.GX_NOMASK,prmT001214)
             ,new CursorDef("T001215", "UPDATE [COSTONRFFPROCES] SET [COSTONRFFPROCESValor]=@COSTONRFFPROCESValor, [COSTONRFFPROCESUser]=@COSTONRFFPROCESUser, [COSTONRFFPROCESReg]=@COSTONRFFPROCESReg, [COSTONRFFPROCESHor]=@COSTONRFFPROCESHor  WHERE [COSTONRFFPROCESFecha] = @COSTONRFFPROCESFecha AND [COSTONRFFPROCESMes] = @COSTONRFFPROCESMes AND [COSTONRFFPROCESAno] = @COSTONRFFPROCESAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo AND [MOTIVOSCOSRFFCodigo] = @MOTIVOSCOSRFFCodigo", GxErrorMask.GX_NOMASK,prmT001215)
             ,new CursorDef("T001216", "DELETE FROM [COSTONRFFPROCES]  WHERE [COSTONRFFPROCESFecha] = @COSTONRFFPROCESFecha AND [COSTONRFFPROCESMes] = @COSTONRFFPROCESMes AND [COSTONRFFPROCESAno] = @COSTONRFFPROCESAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo AND [MOTIVOSCOSRFFCodigo] = @MOTIVOSCOSRFFCodigo", GxErrorMask.GX_NOMASK,prmT001216)
             ,new CursorDef("T001217", "SELECT [COSTONRFFPROCESFecha], [COSTONRFFPROCESMes], [COSTONRFFPROCESAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOSCOSRFFCodigo] FROM [COSTONRFFPROCES] ORDER BY [COSTONRFFPROCESFecha], [COSTONRFFPROCESMes], [COSTONRFFPROCESAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOSCOSRFFCodigo]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001217,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001218", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT001218,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001219", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT001219,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001220", "SELECT [MOTIVOSCOSRFFCodigo] FROM [MOTIVOSCOSRFF] WHERE [MOTIVOSCOSRFFCodigo] = @MOTIVOSCOSRFFCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT001220,1, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                return;
             case 1 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 5 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 9 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                return;
             case 10 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                return;
             case 11 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                return;
             case 15 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                return;
             case 16 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 17 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 18 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
       }
    }

 }

}
