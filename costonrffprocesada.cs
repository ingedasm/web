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
   public class costonrffprocesada : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A5Cod_Area = GetPar( "Cod_Area");
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A5Cod_Area) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A4IndicadoresCodigo = GetPar( "IndicadoresCodigo");
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A4IndicadoresCodigo) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A53MOTIVOSCOSRFFPROCod = GetPar( "MOTIVOSCOSRFFPROCod");
            AssignAttri("", false, "A53MOTIVOSCOSRFFPROCod", A53MOTIVOSCOSRFFPROCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A53MOTIVOSCOSRFFPROCod) ;
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
            Form.Meta.addItem("description", "COSTONRFFPROCESADA", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCOSTONRFFPROCFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("IndicadroresPalmas", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public costonrffprocesada( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("IndicadroresPalmas", true);
      }

      public costonrffprocesada( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "COSTONRFFPROCESADA", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_COSTONRFFPROCESADA.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSTONRFFPROCESADA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSTONRFFPROCESADA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSTONRFFPROCESADA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSTONRFFPROCESADA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 4, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx00q0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"COSTONRFFPROCFEC"+"'), id:'"+"COSTONRFFPROCFEC"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"COSTONRFFPROCMES"+"'), id:'"+"COSTONRFFPROCMES"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"COSTONRFFPROCANO"+"'), id:'"+"COSTONRFFPROCANO"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"COD_AREA"+"'), id:'"+"COD_AREA"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"INDICADORESCODIGO"+"'), id:'"+"INDICADORESCODIGO"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"MOTIVOSCOSRFFPROCOD"+"'), id:'"+"MOTIVOSCOSRFFPROCOD"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_COSTONRFFPROCESADA.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCOSTONRFFPROCFec_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCOSTONRFFPROCFec_Internalname, "COSTONRFFPROCFec", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCOSTONRFFPROCFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCOSTONRFFPROCFec_Internalname, context.localUtil.Format(A71COSTONRFFPROCFec, "99/99/99"), context.localUtil.Format( A71COSTONRFFPROCFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCOSTONRFFPROCFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCOSTONRFFPROCFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_COSTONRFFPROCESADA.htm");
         GxWebStd.gx_bitmap( context, edtCOSTONRFFPROCFec_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCOSTONRFFPROCFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_COSTONRFFPROCESADA.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCOSTONRFFPROCMes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCOSTONRFFPROCMes_Internalname, "COSTONRFFPROCMes", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCOSTONRFFPROCMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A72COSTONRFFPROCMes), 4, 0, ",", "")), StringUtil.LTrim( ((edtCOSTONRFFPROCMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A72COSTONRFFPROCMes), "ZZZ9") : context.localUtil.Format( (decimal)(A72COSTONRFFPROCMes), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCOSTONRFFPROCMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCOSTONRFFPROCMes_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_COSTONRFFPROCESADA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCOSTONRFFPROCAno_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCOSTONRFFPROCAno_Internalname, "COSTONRFFPROCAno", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCOSTONRFFPROCAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A73COSTONRFFPROCAno), 4, 0, ",", "")), StringUtil.LTrim( ((edtCOSTONRFFPROCAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A73COSTONRFFPROCAno), "ZZZ9") : context.localUtil.Format( (decimal)(A73COSTONRFFPROCAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCOSTONRFFPROCAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCOSTONRFFPROCAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_COSTONRFFPROCESADA.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCod_Area_Internalname, A5Cod_Area, StringUtil.RTrim( context.localUtil.Format( A5Cod_Area, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCod_Area_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCod_Area_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_COSTONRFFPROCESADA.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_5_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_5_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_5_Internalname, sImgUrl, imgprompt_5_Link, "", "", context.GetTheme( ), imgprompt_5_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_COSTONRFFPROCESADA.htm");
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
         GxWebStd.gx_single_line_edit( context, edtIndicadoresCodigo_Internalname, A4IndicadoresCodigo, StringUtil.RTrim( context.localUtil.Format( A4IndicadoresCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIndicadoresCodigo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIndicadoresCodigo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_COSTONRFFPROCESADA.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_4_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_4_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_4_Internalname, sImgUrl, imgprompt_4_Link, "", "", context.GetTheme( ), imgprompt_4_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_COSTONRFFPROCESADA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMOTIVOSCOSRFFPROCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMOTIVOSCOSRFFPROCod_Internalname, "MOTIVOSCOSRFFPROCod", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMOTIVOSCOSRFFPROCod_Internalname, A53MOTIVOSCOSRFFPROCod, StringUtil.RTrim( context.localUtil.Format( A53MOTIVOSCOSRFFPROCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMOTIVOSCOSRFFPROCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMOTIVOSCOSRFFPROCod_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_COSTONRFFPROCESADA.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_53_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_53_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_53_Internalname, sImgUrl, imgprompt_53_Link, "", "", context.GetTheme( ), imgprompt_53_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_COSTONRFFPROCESADA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCOSTONRFFPROCValor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCOSTONRFFPROCValor_Internalname, "COSTONRFFPROCValor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCOSTONRFFPROCValor_Internalname, StringUtil.LTrim( StringUtil.NToC( A168COSTONRFFPROCValor, 15, 4, ",", "")), StringUtil.LTrim( ((edtCOSTONRFFPROCValor_Enabled!=0) ? context.localUtil.Format( A168COSTONRFFPROCValor, "ZZZZZZZZZ9.9999") : context.localUtil.Format( A168COSTONRFFPROCValor, "ZZZZZZZZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCOSTONRFFPROCValor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCOSTONRFFPROCValor_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_COSTONRFFPROCESADA.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSTONRFFPROCESADA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSTONRFFPROCESADA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSTONRFFPROCESADA.htm");
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
            Z71COSTONRFFPROCFec = context.localUtil.CToD( cgiGet( "Z71COSTONRFFPROCFec"), 0);
            Z72COSTONRFFPROCMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z72COSTONRFFPROCMes"), ",", "."), 18, MidpointRounding.ToEven));
            Z73COSTONRFFPROCAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z73COSTONRFFPROCAno"), ",", "."), 18, MidpointRounding.ToEven));
            Z5Cod_Area = cgiGet( "Z5Cod_Area");
            Z4IndicadoresCodigo = cgiGet( "Z4IndicadoresCodigo");
            Z53MOTIVOSCOSRFFPROCod = cgiGet( "Z53MOTIVOSCOSRFFPROCod");
            Z168COSTONRFFPROCValor = context.localUtil.CToN( cgiGet( "Z168COSTONRFFPROCValor"), ",", ".");
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( context.localUtil.VCDate( cgiGet( edtCOSTONRFFPROCFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"COSTONRFFPROCFec"}), 1, "COSTONRFFPROCFEC");
               AnyError = 1;
               GX_FocusControl = edtCOSTONRFFPROCFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A71COSTONRFFPROCFec = DateTime.MinValue;
               AssignAttri("", false, "A71COSTONRFFPROCFec", context.localUtil.Format(A71COSTONRFFPROCFec, "99/99/99"));
            }
            else
            {
               A71COSTONRFFPROCFec = context.localUtil.CToD( cgiGet( edtCOSTONRFFPROCFec_Internalname), 2);
               AssignAttri("", false, "A71COSTONRFFPROCFec", context.localUtil.Format(A71COSTONRFFPROCFec, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCOSTONRFFPROCMes_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCOSTONRFFPROCMes_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COSTONRFFPROCMES");
               AnyError = 1;
               GX_FocusControl = edtCOSTONRFFPROCMes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A72COSTONRFFPROCMes = 0;
               AssignAttri("", false, "A72COSTONRFFPROCMes", StringUtil.LTrimStr( (decimal)(A72COSTONRFFPROCMes), 4, 0));
            }
            else
            {
               A72COSTONRFFPROCMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCOSTONRFFPROCMes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A72COSTONRFFPROCMes", StringUtil.LTrimStr( (decimal)(A72COSTONRFFPROCMes), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCOSTONRFFPROCAno_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCOSTONRFFPROCAno_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COSTONRFFPROCANO");
               AnyError = 1;
               GX_FocusControl = edtCOSTONRFFPROCAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A73COSTONRFFPROCAno = 0;
               AssignAttri("", false, "A73COSTONRFFPROCAno", StringUtil.LTrimStr( (decimal)(A73COSTONRFFPROCAno), 4, 0));
            }
            else
            {
               A73COSTONRFFPROCAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCOSTONRFFPROCAno_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A73COSTONRFFPROCAno", StringUtil.LTrimStr( (decimal)(A73COSTONRFFPROCAno), 4, 0));
            }
            A5Cod_Area = cgiGet( edtCod_Area_Internalname);
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = cgiGet( edtIndicadoresCodigo_Internalname);
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A53MOTIVOSCOSRFFPROCod = cgiGet( edtMOTIVOSCOSRFFPROCod_Internalname);
            AssignAttri("", false, "A53MOTIVOSCOSRFFPROCod", A53MOTIVOSCOSRFFPROCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCOSTONRFFPROCValor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCOSTONRFFPROCValor_Internalname), ",", ".") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COSTONRFFPROCVALOR");
               AnyError = 1;
               GX_FocusControl = edtCOSTONRFFPROCValor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A168COSTONRFFPROCValor = 0;
               AssignAttri("", false, "A168COSTONRFFPROCValor", StringUtil.LTrimStr( A168COSTONRFFPROCValor, 15, 4));
            }
            else
            {
               A168COSTONRFFPROCValor = context.localUtil.CToN( cgiGet( edtCOSTONRFFPROCValor_Internalname), ",", ".");
               AssignAttri("", false, "A168COSTONRFFPROCValor", StringUtil.LTrimStr( A168COSTONRFFPROCValor, 15, 4));
            }
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
               A71COSTONRFFPROCFec = context.localUtil.ParseDateParm( GetPar( "COSTONRFFPROCFec"));
               AssignAttri("", false, "A71COSTONRFFPROCFec", context.localUtil.Format(A71COSTONRFFPROCFec, "99/99/99"));
               A72COSTONRFFPROCMes = (short)(Math.Round(NumberUtil.Val( GetPar( "COSTONRFFPROCMes"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A72COSTONRFFPROCMes", StringUtil.LTrimStr( (decimal)(A72COSTONRFFPROCMes), 4, 0));
               A73COSTONRFFPROCAno = (short)(Math.Round(NumberUtil.Val( GetPar( "COSTONRFFPROCAno"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A73COSTONRFFPROCAno", StringUtil.LTrimStr( (decimal)(A73COSTONRFFPROCAno), 4, 0));
               A5Cod_Area = GetPar( "Cod_Area");
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               A4IndicadoresCodigo = GetPar( "IndicadoresCodigo");
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               A53MOTIVOSCOSRFFPROCod = GetPar( "MOTIVOSCOSRFFPROCod");
               AssignAttri("", false, "A53MOTIVOSCOSRFFPROCod", A53MOTIVOSCOSRFFPROCod);
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
               InitAll0P26( ) ;
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
         DisableAttributes0P26( ) ;
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

      protected void ResetCaption0P0( )
      {
      }

      protected void ZM0P26( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z168COSTONRFFPROCValor = T000P3_A168COSTONRFFPROCValor[0];
            }
            else
            {
               Z168COSTONRFFPROCValor = A168COSTONRFFPROCValor;
            }
         }
         if ( GX_JID == -2 )
         {
            Z71COSTONRFFPROCFec = A71COSTONRFFPROCFec;
            Z72COSTONRFFPROCMes = A72COSTONRFFPROCMes;
            Z73COSTONRFFPROCAno = A73COSTONRFFPROCAno;
            Z168COSTONRFFPROCValor = A168COSTONRFFPROCValor;
            Z5Cod_Area = A5Cod_Area;
            Z4IndicadoresCodigo = A4IndicadoresCodigo;
            Z53MOTIVOSCOSRFFPROCod = A53MOTIVOSCOSRFFPROCod;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_5_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"COD_AREA"+"'), id:'"+"COD_AREA"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"true"+");");
         imgprompt_4_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0030.aspx"+"',["+"{Ctrl:gx.dom.el('"+"INDICADORESCODIGO"+"'), id:'"+"INDICADORESCODIGO"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"true"+");");
         imgprompt_53_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx00p0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"MOTIVOSCOSRFFPROCOD"+"'), id:'"+"MOTIVOSCOSRFFPROCOD"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");");
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

      protected void Load0P26( )
      {
         /* Using cursor T000P7 */
         pr_default.execute(5, new Object[] {A71COSTONRFFPROCFec, A72COSTONRFFPROCMes, A73COSTONRFFPROCAno, A5Cod_Area, A4IndicadoresCodigo, A53MOTIVOSCOSRFFPROCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound26 = 1;
            A168COSTONRFFPROCValor = T000P7_A168COSTONRFFPROCValor[0];
            AssignAttri("", false, "A168COSTONRFFPROCValor", StringUtil.LTrimStr( A168COSTONRFFPROCValor, 15, 4));
            ZM0P26( -2) ;
         }
         pr_default.close(5);
         OnLoadActions0P26( ) ;
      }

      protected void OnLoadActions0P26( )
      {
      }

      protected void CheckExtendedTable0P26( )
      {
         nIsDirty_26 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A71COSTONRFFPROCFec) || ( DateTimeUtil.ResetTime ( A71COSTONRFFPROCFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo COSTONRFFPROCFec fuera de rango", "OutOfRange", 1, "COSTONRFFPROCFEC");
            AnyError = 1;
            GX_FocusControl = edtCOSTONRFFPROCFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000P4 */
         pr_default.execute(2, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T000P5 */
         pr_default.execute(3, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         /* Using cursor T000P6 */
         pr_default.execute(4, new Object[] {A53MOTIVOSCOSRFFPROCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'MOTIVOSCOSRFFPRO'.", "ForeignKeyNotFound", 1, "MOTIVOSCOSRFFPROCOD");
            AnyError = 1;
            GX_FocusControl = edtMOTIVOSCOSRFFPROCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors0P26( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( string A5Cod_Area )
      {
         /* Using cursor T000P8 */
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

      protected void gxLoad_4( string A4IndicadoresCodigo )
      {
         /* Using cursor T000P9 */
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

      protected void gxLoad_5( string A53MOTIVOSCOSRFFPROCod )
      {
         /* Using cursor T000P10 */
         pr_default.execute(8, new Object[] {A53MOTIVOSCOSRFFPROCod});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'MOTIVOSCOSRFFPRO'.", "ForeignKeyNotFound", 1, "MOTIVOSCOSRFFPROCOD");
            AnyError = 1;
            GX_FocusControl = edtMOTIVOSCOSRFFPROCod_Internalname;
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

      protected void GetKey0P26( )
      {
         /* Using cursor T000P11 */
         pr_default.execute(9, new Object[] {A71COSTONRFFPROCFec, A72COSTONRFFPROCMes, A73COSTONRFFPROCAno, A5Cod_Area, A4IndicadoresCodigo, A53MOTIVOSCOSRFFPROCod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound26 = 1;
         }
         else
         {
            RcdFound26 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000P3 */
         pr_default.execute(1, new Object[] {A71COSTONRFFPROCFec, A72COSTONRFFPROCMes, A73COSTONRFFPROCAno, A5Cod_Area, A4IndicadoresCodigo, A53MOTIVOSCOSRFFPROCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0P26( 2) ;
            RcdFound26 = 1;
            A71COSTONRFFPROCFec = T000P3_A71COSTONRFFPROCFec[0];
            AssignAttri("", false, "A71COSTONRFFPROCFec", context.localUtil.Format(A71COSTONRFFPROCFec, "99/99/99"));
            A72COSTONRFFPROCMes = T000P3_A72COSTONRFFPROCMes[0];
            AssignAttri("", false, "A72COSTONRFFPROCMes", StringUtil.LTrimStr( (decimal)(A72COSTONRFFPROCMes), 4, 0));
            A73COSTONRFFPROCAno = T000P3_A73COSTONRFFPROCAno[0];
            AssignAttri("", false, "A73COSTONRFFPROCAno", StringUtil.LTrimStr( (decimal)(A73COSTONRFFPROCAno), 4, 0));
            A168COSTONRFFPROCValor = T000P3_A168COSTONRFFPROCValor[0];
            AssignAttri("", false, "A168COSTONRFFPROCValor", StringUtil.LTrimStr( A168COSTONRFFPROCValor, 15, 4));
            A5Cod_Area = T000P3_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = T000P3_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A53MOTIVOSCOSRFFPROCod = T000P3_A53MOTIVOSCOSRFFPROCod[0];
            AssignAttri("", false, "A53MOTIVOSCOSRFFPROCod", A53MOTIVOSCOSRFFPROCod);
            Z71COSTONRFFPROCFec = A71COSTONRFFPROCFec;
            Z72COSTONRFFPROCMes = A72COSTONRFFPROCMes;
            Z73COSTONRFFPROCAno = A73COSTONRFFPROCAno;
            Z5Cod_Area = A5Cod_Area;
            Z4IndicadoresCodigo = A4IndicadoresCodigo;
            Z53MOTIVOSCOSRFFPROCod = A53MOTIVOSCOSRFFPROCod;
            sMode26 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0P26( ) ;
            if ( AnyError == 1 )
            {
               RcdFound26 = 0;
               InitializeNonKey0P26( ) ;
            }
            Gx_mode = sMode26;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound26 = 0;
            InitializeNonKey0P26( ) ;
            sMode26 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode26;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0P26( ) ;
         if ( RcdFound26 == 0 )
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
         RcdFound26 = 0;
         /* Using cursor T000P12 */
         pr_default.execute(10, new Object[] {A71COSTONRFFPROCFec, A72COSTONRFFPROCMes, A73COSTONRFFPROCAno, A5Cod_Area, A4IndicadoresCodigo, A53MOTIVOSCOSRFFPROCod});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( DateTimeUtil.ResetTime ( T000P12_A71COSTONRFFPROCFec[0] ) < DateTimeUtil.ResetTime ( A71COSTONRFFPROCFec ) ) || ( DateTimeUtil.ResetTime ( T000P12_A71COSTONRFFPROCFec[0] ) == DateTimeUtil.ResetTime ( A71COSTONRFFPROCFec ) ) && ( T000P12_A72COSTONRFFPROCMes[0] < A72COSTONRFFPROCMes ) || ( T000P12_A72COSTONRFFPROCMes[0] == A72COSTONRFFPROCMes ) && ( DateTimeUtil.ResetTime ( T000P12_A71COSTONRFFPROCFec[0] ) == DateTimeUtil.ResetTime ( A71COSTONRFFPROCFec ) ) && ( T000P12_A73COSTONRFFPROCAno[0] < A73COSTONRFFPROCAno ) || ( T000P12_A73COSTONRFFPROCAno[0] == A73COSTONRFFPROCAno ) && ( T000P12_A72COSTONRFFPROCMes[0] == A72COSTONRFFPROCMes ) && ( DateTimeUtil.ResetTime ( T000P12_A71COSTONRFFPROCFec[0] ) == DateTimeUtil.ResetTime ( A71COSTONRFFPROCFec ) ) && ( StringUtil.StrCmp(T000P12_A5Cod_Area[0], A5Cod_Area) < 0 ) || ( StringUtil.StrCmp(T000P12_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000P12_A73COSTONRFFPROCAno[0] == A73COSTONRFFPROCAno ) && ( T000P12_A72COSTONRFFPROCMes[0] == A72COSTONRFFPROCMes ) && ( DateTimeUtil.ResetTime ( T000P12_A71COSTONRFFPROCFec[0] ) == DateTimeUtil.ResetTime ( A71COSTONRFFPROCFec ) ) && ( StringUtil.StrCmp(T000P12_A4IndicadoresCodigo[0], A4IndicadoresCodigo) < 0 ) || ( StringUtil.StrCmp(T000P12_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T000P12_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000P12_A73COSTONRFFPROCAno[0] == A73COSTONRFFPROCAno ) && ( T000P12_A72COSTONRFFPROCMes[0] == A72COSTONRFFPROCMes ) && ( DateTimeUtil.ResetTime ( T000P12_A71COSTONRFFPROCFec[0] ) == DateTimeUtil.ResetTime ( A71COSTONRFFPROCFec ) ) && ( StringUtil.StrCmp(T000P12_A53MOTIVOSCOSRFFPROCod[0], A53MOTIVOSCOSRFFPROCod) < 0 ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( DateTimeUtil.ResetTime ( T000P12_A71COSTONRFFPROCFec[0] ) > DateTimeUtil.ResetTime ( A71COSTONRFFPROCFec ) ) || ( DateTimeUtil.ResetTime ( T000P12_A71COSTONRFFPROCFec[0] ) == DateTimeUtil.ResetTime ( A71COSTONRFFPROCFec ) ) && ( T000P12_A72COSTONRFFPROCMes[0] > A72COSTONRFFPROCMes ) || ( T000P12_A72COSTONRFFPROCMes[0] == A72COSTONRFFPROCMes ) && ( DateTimeUtil.ResetTime ( T000P12_A71COSTONRFFPROCFec[0] ) == DateTimeUtil.ResetTime ( A71COSTONRFFPROCFec ) ) && ( T000P12_A73COSTONRFFPROCAno[0] > A73COSTONRFFPROCAno ) || ( T000P12_A73COSTONRFFPROCAno[0] == A73COSTONRFFPROCAno ) && ( T000P12_A72COSTONRFFPROCMes[0] == A72COSTONRFFPROCMes ) && ( DateTimeUtil.ResetTime ( T000P12_A71COSTONRFFPROCFec[0] ) == DateTimeUtil.ResetTime ( A71COSTONRFFPROCFec ) ) && ( StringUtil.StrCmp(T000P12_A5Cod_Area[0], A5Cod_Area) > 0 ) || ( StringUtil.StrCmp(T000P12_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000P12_A73COSTONRFFPROCAno[0] == A73COSTONRFFPROCAno ) && ( T000P12_A72COSTONRFFPROCMes[0] == A72COSTONRFFPROCMes ) && ( DateTimeUtil.ResetTime ( T000P12_A71COSTONRFFPROCFec[0] ) == DateTimeUtil.ResetTime ( A71COSTONRFFPROCFec ) ) && ( StringUtil.StrCmp(T000P12_A4IndicadoresCodigo[0], A4IndicadoresCodigo) > 0 ) || ( StringUtil.StrCmp(T000P12_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T000P12_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000P12_A73COSTONRFFPROCAno[0] == A73COSTONRFFPROCAno ) && ( T000P12_A72COSTONRFFPROCMes[0] == A72COSTONRFFPROCMes ) && ( DateTimeUtil.ResetTime ( T000P12_A71COSTONRFFPROCFec[0] ) == DateTimeUtil.ResetTime ( A71COSTONRFFPROCFec ) ) && ( StringUtil.StrCmp(T000P12_A53MOTIVOSCOSRFFPROCod[0], A53MOTIVOSCOSRFFPROCod) > 0 ) ) )
            {
               A71COSTONRFFPROCFec = T000P12_A71COSTONRFFPROCFec[0];
               AssignAttri("", false, "A71COSTONRFFPROCFec", context.localUtil.Format(A71COSTONRFFPROCFec, "99/99/99"));
               A72COSTONRFFPROCMes = T000P12_A72COSTONRFFPROCMes[0];
               AssignAttri("", false, "A72COSTONRFFPROCMes", StringUtil.LTrimStr( (decimal)(A72COSTONRFFPROCMes), 4, 0));
               A73COSTONRFFPROCAno = T000P12_A73COSTONRFFPROCAno[0];
               AssignAttri("", false, "A73COSTONRFFPROCAno", StringUtil.LTrimStr( (decimal)(A73COSTONRFFPROCAno), 4, 0));
               A5Cod_Area = T000P12_A5Cod_Area[0];
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               A4IndicadoresCodigo = T000P12_A4IndicadoresCodigo[0];
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               A53MOTIVOSCOSRFFPROCod = T000P12_A53MOTIVOSCOSRFFPROCod[0];
               AssignAttri("", false, "A53MOTIVOSCOSRFFPROCod", A53MOTIVOSCOSRFFPROCod);
               RcdFound26 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound26 = 0;
         /* Using cursor T000P13 */
         pr_default.execute(11, new Object[] {A71COSTONRFFPROCFec, A72COSTONRFFPROCMes, A73COSTONRFFPROCAno, A5Cod_Area, A4IndicadoresCodigo, A53MOTIVOSCOSRFFPROCod});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( DateTimeUtil.ResetTime ( T000P13_A71COSTONRFFPROCFec[0] ) > DateTimeUtil.ResetTime ( A71COSTONRFFPROCFec ) ) || ( DateTimeUtil.ResetTime ( T000P13_A71COSTONRFFPROCFec[0] ) == DateTimeUtil.ResetTime ( A71COSTONRFFPROCFec ) ) && ( T000P13_A72COSTONRFFPROCMes[0] > A72COSTONRFFPROCMes ) || ( T000P13_A72COSTONRFFPROCMes[0] == A72COSTONRFFPROCMes ) && ( DateTimeUtil.ResetTime ( T000P13_A71COSTONRFFPROCFec[0] ) == DateTimeUtil.ResetTime ( A71COSTONRFFPROCFec ) ) && ( T000P13_A73COSTONRFFPROCAno[0] > A73COSTONRFFPROCAno ) || ( T000P13_A73COSTONRFFPROCAno[0] == A73COSTONRFFPROCAno ) && ( T000P13_A72COSTONRFFPROCMes[0] == A72COSTONRFFPROCMes ) && ( DateTimeUtil.ResetTime ( T000P13_A71COSTONRFFPROCFec[0] ) == DateTimeUtil.ResetTime ( A71COSTONRFFPROCFec ) ) && ( StringUtil.StrCmp(T000P13_A5Cod_Area[0], A5Cod_Area) > 0 ) || ( StringUtil.StrCmp(T000P13_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000P13_A73COSTONRFFPROCAno[0] == A73COSTONRFFPROCAno ) && ( T000P13_A72COSTONRFFPROCMes[0] == A72COSTONRFFPROCMes ) && ( DateTimeUtil.ResetTime ( T000P13_A71COSTONRFFPROCFec[0] ) == DateTimeUtil.ResetTime ( A71COSTONRFFPROCFec ) ) && ( StringUtil.StrCmp(T000P13_A4IndicadoresCodigo[0], A4IndicadoresCodigo) > 0 ) || ( StringUtil.StrCmp(T000P13_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T000P13_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000P13_A73COSTONRFFPROCAno[0] == A73COSTONRFFPROCAno ) && ( T000P13_A72COSTONRFFPROCMes[0] == A72COSTONRFFPROCMes ) && ( DateTimeUtil.ResetTime ( T000P13_A71COSTONRFFPROCFec[0] ) == DateTimeUtil.ResetTime ( A71COSTONRFFPROCFec ) ) && ( StringUtil.StrCmp(T000P13_A53MOTIVOSCOSRFFPROCod[0], A53MOTIVOSCOSRFFPROCod) > 0 ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( DateTimeUtil.ResetTime ( T000P13_A71COSTONRFFPROCFec[0] ) < DateTimeUtil.ResetTime ( A71COSTONRFFPROCFec ) ) || ( DateTimeUtil.ResetTime ( T000P13_A71COSTONRFFPROCFec[0] ) == DateTimeUtil.ResetTime ( A71COSTONRFFPROCFec ) ) && ( T000P13_A72COSTONRFFPROCMes[0] < A72COSTONRFFPROCMes ) || ( T000P13_A72COSTONRFFPROCMes[0] == A72COSTONRFFPROCMes ) && ( DateTimeUtil.ResetTime ( T000P13_A71COSTONRFFPROCFec[0] ) == DateTimeUtil.ResetTime ( A71COSTONRFFPROCFec ) ) && ( T000P13_A73COSTONRFFPROCAno[0] < A73COSTONRFFPROCAno ) || ( T000P13_A73COSTONRFFPROCAno[0] == A73COSTONRFFPROCAno ) && ( T000P13_A72COSTONRFFPROCMes[0] == A72COSTONRFFPROCMes ) && ( DateTimeUtil.ResetTime ( T000P13_A71COSTONRFFPROCFec[0] ) == DateTimeUtil.ResetTime ( A71COSTONRFFPROCFec ) ) && ( StringUtil.StrCmp(T000P13_A5Cod_Area[0], A5Cod_Area) < 0 ) || ( StringUtil.StrCmp(T000P13_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000P13_A73COSTONRFFPROCAno[0] == A73COSTONRFFPROCAno ) && ( T000P13_A72COSTONRFFPROCMes[0] == A72COSTONRFFPROCMes ) && ( DateTimeUtil.ResetTime ( T000P13_A71COSTONRFFPROCFec[0] ) == DateTimeUtil.ResetTime ( A71COSTONRFFPROCFec ) ) && ( StringUtil.StrCmp(T000P13_A4IndicadoresCodigo[0], A4IndicadoresCodigo) < 0 ) || ( StringUtil.StrCmp(T000P13_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T000P13_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000P13_A73COSTONRFFPROCAno[0] == A73COSTONRFFPROCAno ) && ( T000P13_A72COSTONRFFPROCMes[0] == A72COSTONRFFPROCMes ) && ( DateTimeUtil.ResetTime ( T000P13_A71COSTONRFFPROCFec[0] ) == DateTimeUtil.ResetTime ( A71COSTONRFFPROCFec ) ) && ( StringUtil.StrCmp(T000P13_A53MOTIVOSCOSRFFPROCod[0], A53MOTIVOSCOSRFFPROCod) < 0 ) ) )
            {
               A71COSTONRFFPROCFec = T000P13_A71COSTONRFFPROCFec[0];
               AssignAttri("", false, "A71COSTONRFFPROCFec", context.localUtil.Format(A71COSTONRFFPROCFec, "99/99/99"));
               A72COSTONRFFPROCMes = T000P13_A72COSTONRFFPROCMes[0];
               AssignAttri("", false, "A72COSTONRFFPROCMes", StringUtil.LTrimStr( (decimal)(A72COSTONRFFPROCMes), 4, 0));
               A73COSTONRFFPROCAno = T000P13_A73COSTONRFFPROCAno[0];
               AssignAttri("", false, "A73COSTONRFFPROCAno", StringUtil.LTrimStr( (decimal)(A73COSTONRFFPROCAno), 4, 0));
               A5Cod_Area = T000P13_A5Cod_Area[0];
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               A4IndicadoresCodigo = T000P13_A4IndicadoresCodigo[0];
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               A53MOTIVOSCOSRFFPROCod = T000P13_A53MOTIVOSCOSRFFPROCod[0];
               AssignAttri("", false, "A53MOTIVOSCOSRFFPROCod", A53MOTIVOSCOSRFFPROCod);
               RcdFound26 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0P26( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCOSTONRFFPROCFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0P26( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound26 == 1 )
            {
               if ( ( DateTimeUtil.ResetTime ( A71COSTONRFFPROCFec ) != DateTimeUtil.ResetTime ( Z71COSTONRFFPROCFec ) ) || ( A72COSTONRFFPROCMes != Z72COSTONRFFPROCMes ) || ( A73COSTONRFFPROCAno != Z73COSTONRFFPROCAno ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) || ( StringUtil.StrCmp(A53MOTIVOSCOSRFFPROCod, Z53MOTIVOSCOSRFFPROCod) != 0 ) )
               {
                  A71COSTONRFFPROCFec = Z71COSTONRFFPROCFec;
                  AssignAttri("", false, "A71COSTONRFFPROCFec", context.localUtil.Format(A71COSTONRFFPROCFec, "99/99/99"));
                  A72COSTONRFFPROCMes = Z72COSTONRFFPROCMes;
                  AssignAttri("", false, "A72COSTONRFFPROCMes", StringUtil.LTrimStr( (decimal)(A72COSTONRFFPROCMes), 4, 0));
                  A73COSTONRFFPROCAno = Z73COSTONRFFPROCAno;
                  AssignAttri("", false, "A73COSTONRFFPROCAno", StringUtil.LTrimStr( (decimal)(A73COSTONRFFPROCAno), 4, 0));
                  A5Cod_Area = Z5Cod_Area;
                  AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
                  A4IndicadoresCodigo = Z4IndicadoresCodigo;
                  AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
                  A53MOTIVOSCOSRFFPROCod = Z53MOTIVOSCOSRFFPROCod;
                  AssignAttri("", false, "A53MOTIVOSCOSRFFPROCod", A53MOTIVOSCOSRFFPROCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "COSTONRFFPROCFEC");
                  AnyError = 1;
                  GX_FocusControl = edtCOSTONRFFPROCFec_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCOSTONRFFPROCFec_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0P26( ) ;
                  GX_FocusControl = edtCOSTONRFFPROCFec_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( DateTimeUtil.ResetTime ( A71COSTONRFFPROCFec ) != DateTimeUtil.ResetTime ( Z71COSTONRFFPROCFec ) ) || ( A72COSTONRFFPROCMes != Z72COSTONRFFPROCMes ) || ( A73COSTONRFFPROCAno != Z73COSTONRFFPROCAno ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) || ( StringUtil.StrCmp(A53MOTIVOSCOSRFFPROCod, Z53MOTIVOSCOSRFFPROCod) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtCOSTONRFFPROCFec_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0P26( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "COSTONRFFPROCFEC");
                     AnyError = 1;
                     GX_FocusControl = edtCOSTONRFFPROCFec_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtCOSTONRFFPROCFec_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0P26( ) ;
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
         if ( ( DateTimeUtil.ResetTime ( A71COSTONRFFPROCFec ) != DateTimeUtil.ResetTime ( Z71COSTONRFFPROCFec ) ) || ( A72COSTONRFFPROCMes != Z72COSTONRFFPROCMes ) || ( A73COSTONRFFPROCAno != Z73COSTONRFFPROCAno ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) || ( StringUtil.StrCmp(A53MOTIVOSCOSRFFPROCod, Z53MOTIVOSCOSRFFPROCod) != 0 ) )
         {
            A71COSTONRFFPROCFec = Z71COSTONRFFPROCFec;
            AssignAttri("", false, "A71COSTONRFFPROCFec", context.localUtil.Format(A71COSTONRFFPROCFec, "99/99/99"));
            A72COSTONRFFPROCMes = Z72COSTONRFFPROCMes;
            AssignAttri("", false, "A72COSTONRFFPROCMes", StringUtil.LTrimStr( (decimal)(A72COSTONRFFPROCMes), 4, 0));
            A73COSTONRFFPROCAno = Z73COSTONRFFPROCAno;
            AssignAttri("", false, "A73COSTONRFFPROCAno", StringUtil.LTrimStr( (decimal)(A73COSTONRFFPROCAno), 4, 0));
            A5Cod_Area = Z5Cod_Area;
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = Z4IndicadoresCodigo;
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A53MOTIVOSCOSRFFPROCod = Z53MOTIVOSCOSRFFPROCod;
            AssignAttri("", false, "A53MOTIVOSCOSRFFPROCod", A53MOTIVOSCOSRFFPROCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "COSTONRFFPROCFEC");
            AnyError = 1;
            GX_FocusControl = edtCOSTONRFFPROCFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCOSTONRFFPROCFec_Internalname;
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
         if ( RcdFound26 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "COSTONRFFPROCFEC");
            AnyError = 1;
            GX_FocusControl = edtCOSTONRFFPROCFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtCOSTONRFFPROCValor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0P26( ) ;
         if ( RcdFound26 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCOSTONRFFPROCValor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0P26( ) ;
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
         if ( RcdFound26 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCOSTONRFFPROCValor_Internalname;
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
         if ( RcdFound26 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCOSTONRFFPROCValor_Internalname;
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
         ScanStart0P26( ) ;
         if ( RcdFound26 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound26 != 0 )
            {
               ScanNext0P26( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCOSTONRFFPROCValor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0P26( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0P26( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000P2 */
            pr_default.execute(0, new Object[] {A71COSTONRFFPROCFec, A72COSTONRFFPROCMes, A73COSTONRFFPROCAno, A5Cod_Area, A4IndicadoresCodigo, A53MOTIVOSCOSRFFPROCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"COSTONRFFPROCESADA"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z168COSTONRFFPROCValor != T000P2_A168COSTONRFFPROCValor[0] ) )
            {
               if ( Z168COSTONRFFPROCValor != T000P2_A168COSTONRFFPROCValor[0] )
               {
                  GXUtil.WriteLog("costonrffprocesada:[seudo value changed for attri]"+"COSTONRFFPROCValor");
                  GXUtil.WriteLogRaw("Old: ",Z168COSTONRFFPROCValor);
                  GXUtil.WriteLogRaw("Current: ",T000P2_A168COSTONRFFPROCValor[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"COSTONRFFPROCESADA"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0P26( )
      {
         BeforeValidate0P26( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0P26( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0P26( 0) ;
            CheckOptimisticConcurrency0P26( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0P26( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0P26( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000P14 */
                     pr_default.execute(12, new Object[] {A71COSTONRFFPROCFec, A72COSTONRFFPROCMes, A73COSTONRFFPROCAno, A168COSTONRFFPROCValor, A5Cod_Area, A4IndicadoresCodigo, A53MOTIVOSCOSRFFPROCod});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("COSTONRFFPROCESADA");
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
                           ResetCaption0P0( ) ;
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
               Load0P26( ) ;
            }
            EndLevel0P26( ) ;
         }
         CloseExtendedTableCursors0P26( ) ;
      }

      protected void Update0P26( )
      {
         BeforeValidate0P26( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0P26( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0P26( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0P26( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0P26( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000P15 */
                     pr_default.execute(13, new Object[] {A168COSTONRFFPROCValor, A71COSTONRFFPROCFec, A72COSTONRFFPROCMes, A73COSTONRFFPROCAno, A5Cod_Area, A4IndicadoresCodigo, A53MOTIVOSCOSRFFPROCod});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("COSTONRFFPROCESADA");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"COSTONRFFPROCESADA"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0P26( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0P0( ) ;
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
            EndLevel0P26( ) ;
         }
         CloseExtendedTableCursors0P26( ) ;
      }

      protected void DeferredUpdate0P26( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0P26( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0P26( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0P26( ) ;
            AfterConfirm0P26( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0P26( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000P16 */
                  pr_default.execute(14, new Object[] {A71COSTONRFFPROCFec, A72COSTONRFFPROCMes, A73COSTONRFFPROCAno, A5Cod_Area, A4IndicadoresCodigo, A53MOTIVOSCOSRFFPROCod});
                  pr_default.close(14);
                  pr_default.SmartCacheProvider.SetUpdated("COSTONRFFPROCESADA");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound26 == 0 )
                        {
                           InitAll0P26( ) ;
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
                        ResetCaption0P0( ) ;
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
         sMode26 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0P26( ) ;
         Gx_mode = sMode26;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0P26( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0P26( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0P26( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("costonrffprocesada",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0P0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("costonrffprocesada",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0P26( )
      {
         /* Using cursor T000P17 */
         pr_default.execute(15);
         RcdFound26 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound26 = 1;
            A71COSTONRFFPROCFec = T000P17_A71COSTONRFFPROCFec[0];
            AssignAttri("", false, "A71COSTONRFFPROCFec", context.localUtil.Format(A71COSTONRFFPROCFec, "99/99/99"));
            A72COSTONRFFPROCMes = T000P17_A72COSTONRFFPROCMes[0];
            AssignAttri("", false, "A72COSTONRFFPROCMes", StringUtil.LTrimStr( (decimal)(A72COSTONRFFPROCMes), 4, 0));
            A73COSTONRFFPROCAno = T000P17_A73COSTONRFFPROCAno[0];
            AssignAttri("", false, "A73COSTONRFFPROCAno", StringUtil.LTrimStr( (decimal)(A73COSTONRFFPROCAno), 4, 0));
            A5Cod_Area = T000P17_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = T000P17_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A53MOTIVOSCOSRFFPROCod = T000P17_A53MOTIVOSCOSRFFPROCod[0];
            AssignAttri("", false, "A53MOTIVOSCOSRFFPROCod", A53MOTIVOSCOSRFFPROCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0P26( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound26 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound26 = 1;
            A71COSTONRFFPROCFec = T000P17_A71COSTONRFFPROCFec[0];
            AssignAttri("", false, "A71COSTONRFFPROCFec", context.localUtil.Format(A71COSTONRFFPROCFec, "99/99/99"));
            A72COSTONRFFPROCMes = T000P17_A72COSTONRFFPROCMes[0];
            AssignAttri("", false, "A72COSTONRFFPROCMes", StringUtil.LTrimStr( (decimal)(A72COSTONRFFPROCMes), 4, 0));
            A73COSTONRFFPROCAno = T000P17_A73COSTONRFFPROCAno[0];
            AssignAttri("", false, "A73COSTONRFFPROCAno", StringUtil.LTrimStr( (decimal)(A73COSTONRFFPROCAno), 4, 0));
            A5Cod_Area = T000P17_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = T000P17_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A53MOTIVOSCOSRFFPROCod = T000P17_A53MOTIVOSCOSRFFPROCod[0];
            AssignAttri("", false, "A53MOTIVOSCOSRFFPROCod", A53MOTIVOSCOSRFFPROCod);
         }
      }

      protected void ScanEnd0P26( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm0P26( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0P26( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0P26( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0P26( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0P26( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0P26( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0P26( )
      {
         edtCOSTONRFFPROCFec_Enabled = 0;
         AssignProp("", false, edtCOSTONRFFPROCFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSTONRFFPROCFec_Enabled), 5, 0), true);
         edtCOSTONRFFPROCMes_Enabled = 0;
         AssignProp("", false, edtCOSTONRFFPROCMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSTONRFFPROCMes_Enabled), 5, 0), true);
         edtCOSTONRFFPROCAno_Enabled = 0;
         AssignProp("", false, edtCOSTONRFFPROCAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSTONRFFPROCAno_Enabled), 5, 0), true);
         edtCod_Area_Enabled = 0;
         AssignProp("", false, edtCod_Area_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCod_Area_Enabled), 5, 0), true);
         edtIndicadoresCodigo_Enabled = 0;
         AssignProp("", false, edtIndicadoresCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIndicadoresCodigo_Enabled), 5, 0), true);
         edtMOTIVOSCOSRFFPROCod_Enabled = 0;
         AssignProp("", false, edtMOTIVOSCOSRFFPROCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMOTIVOSCOSRFFPROCod_Enabled), 5, 0), true);
         edtCOSTONRFFPROCValor_Enabled = 0;
         AssignProp("", false, edtCOSTONRFFPROCValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSTONRFFPROCValor_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0P26( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0P0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("costonrffprocesada.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z71COSTONRFFPROCFec", context.localUtil.DToC( Z71COSTONRFFPROCFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z72COSTONRFFPROCMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z72COSTONRFFPROCMes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z73COSTONRFFPROCAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z73COSTONRFFPROCAno), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z5Cod_Area", Z5Cod_Area);
         GxWebStd.gx_hidden_field( context, "Z4IndicadoresCodigo", Z4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "Z53MOTIVOSCOSRFFPROCod", Z53MOTIVOSCOSRFFPROCod);
         GxWebStd.gx_hidden_field( context, "Z168COSTONRFFPROCValor", StringUtil.LTrim( StringUtil.NToC( Z168COSTONRFFPROCValor, 15, 4, ",", "")));
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
         return formatLink("costonrffprocesada.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "COSTONRFFPROCESADA" ;
      }

      public override string GetPgmdesc( )
      {
         return "COSTONRFFPROCESADA" ;
      }

      protected void InitializeNonKey0P26( )
      {
         A168COSTONRFFPROCValor = 0;
         AssignAttri("", false, "A168COSTONRFFPROCValor", StringUtil.LTrimStr( A168COSTONRFFPROCValor, 15, 4));
         Z168COSTONRFFPROCValor = 0;
      }

      protected void InitAll0P26( )
      {
         A71COSTONRFFPROCFec = DateTime.MinValue;
         AssignAttri("", false, "A71COSTONRFFPROCFec", context.localUtil.Format(A71COSTONRFFPROCFec, "99/99/99"));
         A72COSTONRFFPROCMes = 0;
         AssignAttri("", false, "A72COSTONRFFPROCMes", StringUtil.LTrimStr( (decimal)(A72COSTONRFFPROCMes), 4, 0));
         A73COSTONRFFPROCAno = 0;
         AssignAttri("", false, "A73COSTONRFFPROCAno", StringUtil.LTrimStr( (decimal)(A73COSTONRFFPROCAno), 4, 0));
         A5Cod_Area = "";
         AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
         A4IndicadoresCodigo = "";
         AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
         A53MOTIVOSCOSRFFPROCod = "";
         AssignAttri("", false, "A53MOTIVOSCOSRFFPROCod", A53MOTIVOSCOSRFFPROCod);
         InitializeNonKey0P26( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20247231023497", true, true);
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
         context.AddJavascriptSource("costonrffprocesada.js", "?20247231023498", false, true);
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
         edtCOSTONRFFPROCFec_Internalname = "COSTONRFFPROCFEC";
         edtCOSTONRFFPROCMes_Internalname = "COSTONRFFPROCMES";
         edtCOSTONRFFPROCAno_Internalname = "COSTONRFFPROCANO";
         edtCod_Area_Internalname = "COD_AREA";
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO";
         edtMOTIVOSCOSRFFPROCod_Internalname = "MOTIVOSCOSRFFPROCOD";
         edtCOSTONRFFPROCValor_Internalname = "COSTONRFFPROCVALOR";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_5_Internalname = "PROMPT_5";
         imgprompt_4_Internalname = "PROMPT_4";
         imgprompt_53_Internalname = "PROMPT_53";
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
         Form.Caption = "COSTONRFFPROCESADA";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCOSTONRFFPROCValor_Jsonclick = "";
         edtCOSTONRFFPROCValor_Enabled = 1;
         imgprompt_53_Visible = 1;
         imgprompt_53_Link = "";
         edtMOTIVOSCOSRFFPROCod_Jsonclick = "";
         edtMOTIVOSCOSRFFPROCod_Enabled = 1;
         imgprompt_4_Visible = 1;
         imgprompt_4_Link = "";
         edtIndicadoresCodigo_Jsonclick = "";
         edtIndicadoresCodigo_Enabled = 1;
         imgprompt_5_Visible = 1;
         imgprompt_5_Link = "";
         edtCod_Area_Jsonclick = "";
         edtCod_Area_Enabled = 1;
         edtCOSTONRFFPROCAno_Jsonclick = "";
         edtCOSTONRFFPROCAno_Enabled = 1;
         edtCOSTONRFFPROCMes_Jsonclick = "";
         edtCOSTONRFFPROCMes_Enabled = 1;
         edtCOSTONRFFPROCFec_Jsonclick = "";
         edtCOSTONRFFPROCFec_Enabled = 1;
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
         /* Using cursor T000P18 */
         pr_default.execute(16, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(16);
         /* Using cursor T000P19 */
         pr_default.execute(17, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(17);
         /* Using cursor T000P20 */
         pr_default.execute(18, new Object[] {A53MOTIVOSCOSRFFPROCod});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'MOTIVOSCOSRFFPRO'.", "ForeignKeyNotFound", 1, "MOTIVOSCOSRFFPROCOD");
            AnyError = 1;
            GX_FocusControl = edtMOTIVOSCOSRFFPROCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(18);
         GX_FocusControl = edtCOSTONRFFPROCValor_Internalname;
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
         /* Using cursor T000P18 */
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
         /* Using cursor T000P19 */
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

      public void Valid_Motivoscosrffprocod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T000P20 */
         pr_default.execute(18, new Object[] {A53MOTIVOSCOSRFFPROCod});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'MOTIVOSCOSRFFPRO'.", "ForeignKeyNotFound", 1, "MOTIVOSCOSRFFPROCOD");
            AnyError = 1;
            GX_FocusControl = edtMOTIVOSCOSRFFPROCod_Internalname;
         }
         pr_default.close(18);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A168COSTONRFFPROCValor", StringUtil.LTrim( StringUtil.NToC( A168COSTONRFFPROCValor, 15, 4, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z71COSTONRFFPROCFec", context.localUtil.Format(Z71COSTONRFFPROCFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z72COSTONRFFPROCMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z72COSTONRFFPROCMes), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z73COSTONRFFPROCAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z73COSTONRFFPROCAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z5Cod_Area", Z5Cod_Area);
         GxWebStd.gx_hidden_field( context, "Z4IndicadoresCodigo", Z4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "Z53MOTIVOSCOSRFFPROCod", Z53MOTIVOSCOSRFFPROCod);
         GxWebStd.gx_hidden_field( context, "Z168COSTONRFFPROCValor", StringUtil.LTrim( StringUtil.NToC( Z168COSTONRFFPROCValor, 15, 4, ".", "")));
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
         setEventMetadata("VALID_COSTONRFFPROCFEC","{handler:'Valid_Costonrffprocfec',iparms:[]");
         setEventMetadata("VALID_COSTONRFFPROCFEC",",oparms:[]}");
         setEventMetadata("VALID_COSTONRFFPROCMES","{handler:'Valid_Costonrffprocmes',iparms:[]");
         setEventMetadata("VALID_COSTONRFFPROCMES",",oparms:[]}");
         setEventMetadata("VALID_COSTONRFFPROCANO","{handler:'Valid_Costonrffprocano',iparms:[]");
         setEventMetadata("VALID_COSTONRFFPROCANO",",oparms:[]}");
         setEventMetadata("VALID_COD_AREA","{handler:'Valid_Cod_area',iparms:[{av:'A5Cod_Area',fld:'COD_AREA',pic:''}]");
         setEventMetadata("VALID_COD_AREA",",oparms:[]}");
         setEventMetadata("VALID_INDICADORESCODIGO","{handler:'Valid_Indicadorescodigo',iparms:[{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:''}]");
         setEventMetadata("VALID_INDICADORESCODIGO",",oparms:[]}");
         setEventMetadata("VALID_MOTIVOSCOSRFFPROCOD","{handler:'Valid_Motivoscosrffprocod',iparms:[{av:'A71COSTONRFFPROCFec',fld:'COSTONRFFPROCFEC',pic:''},{av:'A72COSTONRFFPROCMes',fld:'COSTONRFFPROCMES',pic:'ZZZ9'},{av:'A73COSTONRFFPROCAno',fld:'COSTONRFFPROCANO',pic:'ZZZ9'},{av:'A5Cod_Area',fld:'COD_AREA',pic:''},{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:''},{av:'A53MOTIVOSCOSRFFPROCod',fld:'MOTIVOSCOSRFFPROCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_MOTIVOSCOSRFFPROCOD",",oparms:[{av:'A168COSTONRFFPROCValor',fld:'COSTONRFFPROCVALOR',pic:'ZZZZZZZZZ9.9999'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z71COSTONRFFPROCFec'},{av:'Z72COSTONRFFPROCMes'},{av:'Z73COSTONRFFPROCAno'},{av:'Z5Cod_Area'},{av:'Z4IndicadoresCodigo'},{av:'Z53MOTIVOSCOSRFFPROCod'},{av:'Z168COSTONRFFPROCValor'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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
         Z71COSTONRFFPROCFec = DateTime.MinValue;
         Z5Cod_Area = "";
         Z4IndicadoresCodigo = "";
         Z53MOTIVOSCOSRFFPROCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A5Cod_Area = "";
         A4IndicadoresCodigo = "";
         A53MOTIVOSCOSRFFPROCod = "";
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
         A71COSTONRFFPROCFec = DateTime.MinValue;
         imgprompt_5_gximage = "";
         sImgUrl = "";
         imgprompt_4_gximage = "";
         imgprompt_53_gximage = "";
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
         T000P7_A71COSTONRFFPROCFec = new DateTime[] {DateTime.MinValue} ;
         T000P7_A72COSTONRFFPROCMes = new short[1] ;
         T000P7_A73COSTONRFFPROCAno = new short[1] ;
         T000P7_A168COSTONRFFPROCValor = new decimal[1] ;
         T000P7_A5Cod_Area = new string[] {""} ;
         T000P7_A4IndicadoresCodigo = new string[] {""} ;
         T000P7_A53MOTIVOSCOSRFFPROCod = new string[] {""} ;
         T000P4_A5Cod_Area = new string[] {""} ;
         T000P5_A4IndicadoresCodigo = new string[] {""} ;
         T000P6_A53MOTIVOSCOSRFFPROCod = new string[] {""} ;
         T000P8_A5Cod_Area = new string[] {""} ;
         T000P9_A4IndicadoresCodigo = new string[] {""} ;
         T000P10_A53MOTIVOSCOSRFFPROCod = new string[] {""} ;
         T000P11_A71COSTONRFFPROCFec = new DateTime[] {DateTime.MinValue} ;
         T000P11_A72COSTONRFFPROCMes = new short[1] ;
         T000P11_A73COSTONRFFPROCAno = new short[1] ;
         T000P11_A5Cod_Area = new string[] {""} ;
         T000P11_A4IndicadoresCodigo = new string[] {""} ;
         T000P11_A53MOTIVOSCOSRFFPROCod = new string[] {""} ;
         T000P3_A71COSTONRFFPROCFec = new DateTime[] {DateTime.MinValue} ;
         T000P3_A72COSTONRFFPROCMes = new short[1] ;
         T000P3_A73COSTONRFFPROCAno = new short[1] ;
         T000P3_A168COSTONRFFPROCValor = new decimal[1] ;
         T000P3_A5Cod_Area = new string[] {""} ;
         T000P3_A4IndicadoresCodigo = new string[] {""} ;
         T000P3_A53MOTIVOSCOSRFFPROCod = new string[] {""} ;
         sMode26 = "";
         T000P12_A71COSTONRFFPROCFec = new DateTime[] {DateTime.MinValue} ;
         T000P12_A72COSTONRFFPROCMes = new short[1] ;
         T000P12_A73COSTONRFFPROCAno = new short[1] ;
         T000P12_A5Cod_Area = new string[] {""} ;
         T000P12_A4IndicadoresCodigo = new string[] {""} ;
         T000P12_A53MOTIVOSCOSRFFPROCod = new string[] {""} ;
         T000P13_A71COSTONRFFPROCFec = new DateTime[] {DateTime.MinValue} ;
         T000P13_A72COSTONRFFPROCMes = new short[1] ;
         T000P13_A73COSTONRFFPROCAno = new short[1] ;
         T000P13_A5Cod_Area = new string[] {""} ;
         T000P13_A4IndicadoresCodigo = new string[] {""} ;
         T000P13_A53MOTIVOSCOSRFFPROCod = new string[] {""} ;
         T000P2_A71COSTONRFFPROCFec = new DateTime[] {DateTime.MinValue} ;
         T000P2_A72COSTONRFFPROCMes = new short[1] ;
         T000P2_A73COSTONRFFPROCAno = new short[1] ;
         T000P2_A168COSTONRFFPROCValor = new decimal[1] ;
         T000P2_A5Cod_Area = new string[] {""} ;
         T000P2_A4IndicadoresCodigo = new string[] {""} ;
         T000P2_A53MOTIVOSCOSRFFPROCod = new string[] {""} ;
         T000P17_A71COSTONRFFPROCFec = new DateTime[] {DateTime.MinValue} ;
         T000P17_A72COSTONRFFPROCMes = new short[1] ;
         T000P17_A73COSTONRFFPROCAno = new short[1] ;
         T000P17_A5Cod_Area = new string[] {""} ;
         T000P17_A4IndicadoresCodigo = new string[] {""} ;
         T000P17_A53MOTIVOSCOSRFFPROCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T000P18_A5Cod_Area = new string[] {""} ;
         T000P19_A4IndicadoresCodigo = new string[] {""} ;
         T000P20_A53MOTIVOSCOSRFFPROCod = new string[] {""} ;
         ZZ71COSTONRFFPROCFec = DateTime.MinValue;
         ZZ5Cod_Area = "";
         ZZ4IndicadoresCodigo = "";
         ZZ53MOTIVOSCOSRFFPROCod = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.costonrffprocesada__default(),
            new Object[][] {
                new Object[] {
               T000P2_A71COSTONRFFPROCFec, T000P2_A72COSTONRFFPROCMes, T000P2_A73COSTONRFFPROCAno, T000P2_A168COSTONRFFPROCValor, T000P2_A5Cod_Area, T000P2_A4IndicadoresCodigo, T000P2_A53MOTIVOSCOSRFFPROCod
               }
               , new Object[] {
               T000P3_A71COSTONRFFPROCFec, T000P3_A72COSTONRFFPROCMes, T000P3_A73COSTONRFFPROCAno, T000P3_A168COSTONRFFPROCValor, T000P3_A5Cod_Area, T000P3_A4IndicadoresCodigo, T000P3_A53MOTIVOSCOSRFFPROCod
               }
               , new Object[] {
               T000P4_A5Cod_Area
               }
               , new Object[] {
               T000P5_A4IndicadoresCodigo
               }
               , new Object[] {
               T000P6_A53MOTIVOSCOSRFFPROCod
               }
               , new Object[] {
               T000P7_A71COSTONRFFPROCFec, T000P7_A72COSTONRFFPROCMes, T000P7_A73COSTONRFFPROCAno, T000P7_A168COSTONRFFPROCValor, T000P7_A5Cod_Area, T000P7_A4IndicadoresCodigo, T000P7_A53MOTIVOSCOSRFFPROCod
               }
               , new Object[] {
               T000P8_A5Cod_Area
               }
               , new Object[] {
               T000P9_A4IndicadoresCodigo
               }
               , new Object[] {
               T000P10_A53MOTIVOSCOSRFFPROCod
               }
               , new Object[] {
               T000P11_A71COSTONRFFPROCFec, T000P11_A72COSTONRFFPROCMes, T000P11_A73COSTONRFFPROCAno, T000P11_A5Cod_Area, T000P11_A4IndicadoresCodigo, T000P11_A53MOTIVOSCOSRFFPROCod
               }
               , new Object[] {
               T000P12_A71COSTONRFFPROCFec, T000P12_A72COSTONRFFPROCMes, T000P12_A73COSTONRFFPROCAno, T000P12_A5Cod_Area, T000P12_A4IndicadoresCodigo, T000P12_A53MOTIVOSCOSRFFPROCod
               }
               , new Object[] {
               T000P13_A71COSTONRFFPROCFec, T000P13_A72COSTONRFFPROCMes, T000P13_A73COSTONRFFPROCAno, T000P13_A5Cod_Area, T000P13_A4IndicadoresCodigo, T000P13_A53MOTIVOSCOSRFFPROCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000P17_A71COSTONRFFPROCFec, T000P17_A72COSTONRFFPROCMes, T000P17_A73COSTONRFFPROCAno, T000P17_A5Cod_Area, T000P17_A4IndicadoresCodigo, T000P17_A53MOTIVOSCOSRFFPROCod
               }
               , new Object[] {
               T000P18_A5Cod_Area
               }
               , new Object[] {
               T000P19_A4IndicadoresCodigo
               }
               , new Object[] {
               T000P20_A53MOTIVOSCOSRFFPROCod
               }
            }
         );
      }

      private short Z72COSTONRFFPROCMes ;
      private short Z73COSTONRFFPROCAno ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A72COSTONRFFPROCMes ;
      private short A73COSTONRFFPROCAno ;
      private short GX_JID ;
      private short RcdFound26 ;
      private short nIsDirty_26 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ72COSTONRFFPROCMes ;
      private short ZZ73COSTONRFFPROCAno ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtCOSTONRFFPROCFec_Enabled ;
      private int edtCOSTONRFFPROCMes_Enabled ;
      private int edtCOSTONRFFPROCAno_Enabled ;
      private int edtCod_Area_Enabled ;
      private int imgprompt_5_Visible ;
      private int edtIndicadoresCodigo_Enabled ;
      private int imgprompt_4_Visible ;
      private int edtMOTIVOSCOSRFFPROCod_Enabled ;
      private int imgprompt_53_Visible ;
      private int edtCOSTONRFFPROCValor_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private decimal Z168COSTONRFFPROCValor ;
      private decimal A168COSTONRFFPROCValor ;
      private decimal ZZ168COSTONRFFPROCValor ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCOSTONRFFPROCFec_Internalname ;
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
      private string edtCOSTONRFFPROCFec_Jsonclick ;
      private string edtCOSTONRFFPROCMes_Internalname ;
      private string edtCOSTONRFFPROCMes_Jsonclick ;
      private string edtCOSTONRFFPROCAno_Internalname ;
      private string edtCOSTONRFFPROCAno_Jsonclick ;
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
      private string edtMOTIVOSCOSRFFPROCod_Internalname ;
      private string edtMOTIVOSCOSRFFPROCod_Jsonclick ;
      private string imgprompt_53_gximage ;
      private string imgprompt_53_Internalname ;
      private string imgprompt_53_Link ;
      private string edtCOSTONRFFPROCValor_Internalname ;
      private string edtCOSTONRFFPROCValor_Jsonclick ;
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
      private string sMode26 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z71COSTONRFFPROCFec ;
      private DateTime A71COSTONRFFPROCFec ;
      private DateTime ZZ71COSTONRFFPROCFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string Z5Cod_Area ;
      private string Z4IndicadoresCodigo ;
      private string Z53MOTIVOSCOSRFFPROCod ;
      private string A5Cod_Area ;
      private string A4IndicadoresCodigo ;
      private string A53MOTIVOSCOSRFFPROCod ;
      private string ZZ5Cod_Area ;
      private string ZZ4IndicadoresCodigo ;
      private string ZZ53MOTIVOSCOSRFFPROCod ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] T000P7_A71COSTONRFFPROCFec ;
      private short[] T000P7_A72COSTONRFFPROCMes ;
      private short[] T000P7_A73COSTONRFFPROCAno ;
      private decimal[] T000P7_A168COSTONRFFPROCValor ;
      private string[] T000P7_A5Cod_Area ;
      private string[] T000P7_A4IndicadoresCodigo ;
      private string[] T000P7_A53MOTIVOSCOSRFFPROCod ;
      private string[] T000P4_A5Cod_Area ;
      private string[] T000P5_A4IndicadoresCodigo ;
      private string[] T000P6_A53MOTIVOSCOSRFFPROCod ;
      private string[] T000P8_A5Cod_Area ;
      private string[] T000P9_A4IndicadoresCodigo ;
      private string[] T000P10_A53MOTIVOSCOSRFFPROCod ;
      private DateTime[] T000P11_A71COSTONRFFPROCFec ;
      private short[] T000P11_A72COSTONRFFPROCMes ;
      private short[] T000P11_A73COSTONRFFPROCAno ;
      private string[] T000P11_A5Cod_Area ;
      private string[] T000P11_A4IndicadoresCodigo ;
      private string[] T000P11_A53MOTIVOSCOSRFFPROCod ;
      private DateTime[] T000P3_A71COSTONRFFPROCFec ;
      private short[] T000P3_A72COSTONRFFPROCMes ;
      private short[] T000P3_A73COSTONRFFPROCAno ;
      private decimal[] T000P3_A168COSTONRFFPROCValor ;
      private string[] T000P3_A5Cod_Area ;
      private string[] T000P3_A4IndicadoresCodigo ;
      private string[] T000P3_A53MOTIVOSCOSRFFPROCod ;
      private DateTime[] T000P12_A71COSTONRFFPROCFec ;
      private short[] T000P12_A72COSTONRFFPROCMes ;
      private short[] T000P12_A73COSTONRFFPROCAno ;
      private string[] T000P12_A5Cod_Area ;
      private string[] T000P12_A4IndicadoresCodigo ;
      private string[] T000P12_A53MOTIVOSCOSRFFPROCod ;
      private DateTime[] T000P13_A71COSTONRFFPROCFec ;
      private short[] T000P13_A72COSTONRFFPROCMes ;
      private short[] T000P13_A73COSTONRFFPROCAno ;
      private string[] T000P13_A5Cod_Area ;
      private string[] T000P13_A4IndicadoresCodigo ;
      private string[] T000P13_A53MOTIVOSCOSRFFPROCod ;
      private DateTime[] T000P2_A71COSTONRFFPROCFec ;
      private short[] T000P2_A72COSTONRFFPROCMes ;
      private short[] T000P2_A73COSTONRFFPROCAno ;
      private decimal[] T000P2_A168COSTONRFFPROCValor ;
      private string[] T000P2_A5Cod_Area ;
      private string[] T000P2_A4IndicadoresCodigo ;
      private string[] T000P2_A53MOTIVOSCOSRFFPROCod ;
      private DateTime[] T000P17_A71COSTONRFFPROCFec ;
      private short[] T000P17_A72COSTONRFFPROCMes ;
      private short[] T000P17_A73COSTONRFFPROCAno ;
      private string[] T000P17_A5Cod_Area ;
      private string[] T000P17_A4IndicadoresCodigo ;
      private string[] T000P17_A53MOTIVOSCOSRFFPROCod ;
      private string[] T000P18_A5Cod_Area ;
      private string[] T000P19_A4IndicadoresCodigo ;
      private string[] T000P20_A53MOTIVOSCOSRFFPROCod ;
      private GXWebForm Form ;
   }

   public class costonrffprocesada__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT000P7;
          prmT000P7 = new Object[] {
          new ParDef("@COSTONRFFPROCFec",GXType.Date,8,0) ,
          new ParDef("@COSTONRFFPROCMes",GXType.Int16,4,0) ,
          new ParDef("@COSTONRFFPROCAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MOTIVOSCOSRFFPROCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000P4;
          prmT000P4 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000P5;
          prmT000P5 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000P6;
          prmT000P6 = new Object[] {
          new ParDef("@MOTIVOSCOSRFFPROCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000P8;
          prmT000P8 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000P9;
          prmT000P9 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000P10;
          prmT000P10 = new Object[] {
          new ParDef("@MOTIVOSCOSRFFPROCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000P11;
          prmT000P11 = new Object[] {
          new ParDef("@COSTONRFFPROCFec",GXType.Date,8,0) ,
          new ParDef("@COSTONRFFPROCMes",GXType.Int16,4,0) ,
          new ParDef("@COSTONRFFPROCAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MOTIVOSCOSRFFPROCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000P3;
          prmT000P3 = new Object[] {
          new ParDef("@COSTONRFFPROCFec",GXType.Date,8,0) ,
          new ParDef("@COSTONRFFPROCMes",GXType.Int16,4,0) ,
          new ParDef("@COSTONRFFPROCAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MOTIVOSCOSRFFPROCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000P12;
          prmT000P12 = new Object[] {
          new ParDef("@COSTONRFFPROCFec",GXType.Date,8,0) ,
          new ParDef("@COSTONRFFPROCMes",GXType.Int16,4,0) ,
          new ParDef("@COSTONRFFPROCAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MOTIVOSCOSRFFPROCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000P13;
          prmT000P13 = new Object[] {
          new ParDef("@COSTONRFFPROCFec",GXType.Date,8,0) ,
          new ParDef("@COSTONRFFPROCMes",GXType.Int16,4,0) ,
          new ParDef("@COSTONRFFPROCAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MOTIVOSCOSRFFPROCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000P2;
          prmT000P2 = new Object[] {
          new ParDef("@COSTONRFFPROCFec",GXType.Date,8,0) ,
          new ParDef("@COSTONRFFPROCMes",GXType.Int16,4,0) ,
          new ParDef("@COSTONRFFPROCAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MOTIVOSCOSRFFPROCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000P14;
          prmT000P14 = new Object[] {
          new ParDef("@COSTONRFFPROCFec",GXType.Date,8,0) ,
          new ParDef("@COSTONRFFPROCMes",GXType.Int16,4,0) ,
          new ParDef("@COSTONRFFPROCAno",GXType.Int16,4,0) ,
          new ParDef("@COSTONRFFPROCValor",GXType.Decimal,15,4) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MOTIVOSCOSRFFPROCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000P15;
          prmT000P15 = new Object[] {
          new ParDef("@COSTONRFFPROCValor",GXType.Decimal,15,4) ,
          new ParDef("@COSTONRFFPROCFec",GXType.Date,8,0) ,
          new ParDef("@COSTONRFFPROCMes",GXType.Int16,4,0) ,
          new ParDef("@COSTONRFFPROCAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MOTIVOSCOSRFFPROCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000P16;
          prmT000P16 = new Object[] {
          new ParDef("@COSTONRFFPROCFec",GXType.Date,8,0) ,
          new ParDef("@COSTONRFFPROCMes",GXType.Int16,4,0) ,
          new ParDef("@COSTONRFFPROCAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MOTIVOSCOSRFFPROCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000P17;
          prmT000P17 = new Object[] {
          };
          Object[] prmT000P18;
          prmT000P18 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000P19;
          prmT000P19 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000P20;
          prmT000P20 = new Object[] {
          new ParDef("@MOTIVOSCOSRFFPROCod",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("T000P2", "SELECT [COSTONRFFPROCFec], [COSTONRFFPROCMes], [COSTONRFFPROCAno], [COSTONRFFPROCValor], [Cod_Area], [IndicadoresCodigo], [MOTIVOSCOSRFFPROCod] FROM [COSTONRFFPROCESADA] WITH (UPDLOCK) WHERE [COSTONRFFPROCFec] = @COSTONRFFPROCFec AND [COSTONRFFPROCMes] = @COSTONRFFPROCMes AND [COSTONRFFPROCAno] = @COSTONRFFPROCAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo AND [MOTIVOSCOSRFFPROCod] = @MOTIVOSCOSRFFPROCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000P3", "SELECT [COSTONRFFPROCFec], [COSTONRFFPROCMes], [COSTONRFFPROCAno], [COSTONRFFPROCValor], [Cod_Area], [IndicadoresCodigo], [MOTIVOSCOSRFFPROCod] FROM [COSTONRFFPROCESADA] WHERE [COSTONRFFPROCFec] = @COSTONRFFPROCFec AND [COSTONRFFPROCMes] = @COSTONRFFPROCMes AND [COSTONRFFPROCAno] = @COSTONRFFPROCAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo AND [MOTIVOSCOSRFFPROCod] = @MOTIVOSCOSRFFPROCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000P4", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000P5", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000P6", "SELECT [MOTIVOSCOSRFFPROCod] FROM [MOTIVOSCOSRFFPRO] WHERE [MOTIVOSCOSRFFPROCod] = @MOTIVOSCOSRFFPROCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000P7", "SELECT TM1.[COSTONRFFPROCFec], TM1.[COSTONRFFPROCMes], TM1.[COSTONRFFPROCAno], TM1.[COSTONRFFPROCValor], TM1.[Cod_Area], TM1.[IndicadoresCodigo], TM1.[MOTIVOSCOSRFFPROCod] FROM [COSTONRFFPROCESADA] TM1 WHERE TM1.[COSTONRFFPROCFec] = @COSTONRFFPROCFec and TM1.[COSTONRFFPROCMes] = @COSTONRFFPROCMes and TM1.[COSTONRFFPROCAno] = @COSTONRFFPROCAno and TM1.[Cod_Area] = @Cod_Area and TM1.[IndicadoresCodigo] = @IndicadoresCodigo and TM1.[MOTIVOSCOSRFFPROCod] = @MOTIVOSCOSRFFPROCod ORDER BY TM1.[COSTONRFFPROCFec], TM1.[COSTONRFFPROCMes], TM1.[COSTONRFFPROCAno], TM1.[Cod_Area], TM1.[IndicadoresCodigo], TM1.[MOTIVOSCOSRFFPROCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000P7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000P8", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000P9", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000P10", "SELECT [MOTIVOSCOSRFFPROCod] FROM [MOTIVOSCOSRFFPRO] WHERE [MOTIVOSCOSRFFPROCod] = @MOTIVOSCOSRFFPROCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P10,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000P11", "SELECT [COSTONRFFPROCFec], [COSTONRFFPROCMes], [COSTONRFFPROCAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOSCOSRFFPROCod] FROM [COSTONRFFPROCESADA] WHERE [COSTONRFFPROCFec] = @COSTONRFFPROCFec AND [COSTONRFFPROCMes] = @COSTONRFFPROCMes AND [COSTONRFFPROCAno] = @COSTONRFFPROCAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo AND [MOTIVOSCOSRFFPROCod] = @MOTIVOSCOSRFFPROCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000P11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000P12", "SELECT TOP 1 [COSTONRFFPROCFec], [COSTONRFFPROCMes], [COSTONRFFPROCAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOSCOSRFFPROCod] FROM [COSTONRFFPROCESADA] WHERE ( [COSTONRFFPROCFec] > @COSTONRFFPROCFec or [COSTONRFFPROCFec] = @COSTONRFFPROCFec and [COSTONRFFPROCMes] > @COSTONRFFPROCMes or [COSTONRFFPROCMes] = @COSTONRFFPROCMes and [COSTONRFFPROCFec] = @COSTONRFFPROCFec and [COSTONRFFPROCAno] > @COSTONRFFPROCAno or [COSTONRFFPROCAno] = @COSTONRFFPROCAno and [COSTONRFFPROCMes] = @COSTONRFFPROCMes and [COSTONRFFPROCFec] = @COSTONRFFPROCFec and [Cod_Area] > @Cod_Area or [Cod_Area] = @Cod_Area and [COSTONRFFPROCAno] = @COSTONRFFPROCAno and [COSTONRFFPROCMes] = @COSTONRFFPROCMes and [COSTONRFFPROCFec] = @COSTONRFFPROCFec and [IndicadoresCodigo] > @IndicadoresCodigo or [IndicadoresCodigo] = @IndicadoresCodigo and [Cod_Area] = @Cod_Area and [COSTONRFFPROCAno] = @COSTONRFFPROCAno and [COSTONRFFPROCMes] = @COSTONRFFPROCMes and [COSTONRFFPROCFec] = @COSTONRFFPROCFec and [MOTIVOSCOSRFFPROCod] > @MOTIVOSCOSRFFPROCod) ORDER BY [COSTONRFFPROCFec], [COSTONRFFPROCMes], [COSTONRFFPROCAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOSCOSRFFPROCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000P12,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000P13", "SELECT TOP 1 [COSTONRFFPROCFec], [COSTONRFFPROCMes], [COSTONRFFPROCAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOSCOSRFFPROCod] FROM [COSTONRFFPROCESADA] WHERE ( [COSTONRFFPROCFec] < @COSTONRFFPROCFec or [COSTONRFFPROCFec] = @COSTONRFFPROCFec and [COSTONRFFPROCMes] < @COSTONRFFPROCMes or [COSTONRFFPROCMes] = @COSTONRFFPROCMes and [COSTONRFFPROCFec] = @COSTONRFFPROCFec and [COSTONRFFPROCAno] < @COSTONRFFPROCAno or [COSTONRFFPROCAno] = @COSTONRFFPROCAno and [COSTONRFFPROCMes] = @COSTONRFFPROCMes and [COSTONRFFPROCFec] = @COSTONRFFPROCFec and [Cod_Area] < @Cod_Area or [Cod_Area] = @Cod_Area and [COSTONRFFPROCAno] = @COSTONRFFPROCAno and [COSTONRFFPROCMes] = @COSTONRFFPROCMes and [COSTONRFFPROCFec] = @COSTONRFFPROCFec and [IndicadoresCodigo] < @IndicadoresCodigo or [IndicadoresCodigo] = @IndicadoresCodigo and [Cod_Area] = @Cod_Area and [COSTONRFFPROCAno] = @COSTONRFFPROCAno and [COSTONRFFPROCMes] = @COSTONRFFPROCMes and [COSTONRFFPROCFec] = @COSTONRFFPROCFec and [MOTIVOSCOSRFFPROCod] < @MOTIVOSCOSRFFPROCod) ORDER BY [COSTONRFFPROCFec] DESC, [COSTONRFFPROCMes] DESC, [COSTONRFFPROCAno] DESC, [Cod_Area] DESC, [IndicadoresCodigo] DESC, [MOTIVOSCOSRFFPROCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000P13,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000P14", "INSERT INTO [COSTONRFFPROCESADA]([COSTONRFFPROCFec], [COSTONRFFPROCMes], [COSTONRFFPROCAno], [COSTONRFFPROCValor], [Cod_Area], [IndicadoresCodigo], [MOTIVOSCOSRFFPROCod]) VALUES(@COSTONRFFPROCFec, @COSTONRFFPROCMes, @COSTONRFFPROCAno, @COSTONRFFPROCValor, @Cod_Area, @IndicadoresCodigo, @MOTIVOSCOSRFFPROCod)", GxErrorMask.GX_NOMASK,prmT000P14)
             ,new CursorDef("T000P15", "UPDATE [COSTONRFFPROCESADA] SET [COSTONRFFPROCValor]=@COSTONRFFPROCValor  WHERE [COSTONRFFPROCFec] = @COSTONRFFPROCFec AND [COSTONRFFPROCMes] = @COSTONRFFPROCMes AND [COSTONRFFPROCAno] = @COSTONRFFPROCAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo AND [MOTIVOSCOSRFFPROCod] = @MOTIVOSCOSRFFPROCod", GxErrorMask.GX_NOMASK,prmT000P15)
             ,new CursorDef("T000P16", "DELETE FROM [COSTONRFFPROCESADA]  WHERE [COSTONRFFPROCFec] = @COSTONRFFPROCFec AND [COSTONRFFPROCMes] = @COSTONRFFPROCMes AND [COSTONRFFPROCAno] = @COSTONRFFPROCAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo AND [MOTIVOSCOSRFFPROCod] = @MOTIVOSCOSRFFPROCod", GxErrorMask.GX_NOMASK,prmT000P16)
             ,new CursorDef("T000P17", "SELECT [COSTONRFFPROCFec], [COSTONRFFPROCMes], [COSTONRFFPROCAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOSCOSRFFPROCod] FROM [COSTONRFFPROCESADA] ORDER BY [COSTONRFFPROCFec], [COSTONRFFPROCMes], [COSTONRFFPROCAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOSCOSRFFPROCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000P17,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000P18", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P18,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000P19", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P19,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000P20", "SELECT [MOTIVOSCOSRFFPROCod] FROM [MOTIVOSCOSRFFPRO] WHERE [MOTIVOSCOSRFFPROCod] = @MOTIVOSCOSRFFPROCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P20,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                return;
             case 1 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
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
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
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
