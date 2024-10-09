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
   public class toncpoha : GXDataArea
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
            Form.Meta.addItem("description", "TONCPOHA", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTONCPOHAFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("IndicadroresPalmas", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public toncpoha( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("IndicadroresPalmas", true);
      }

      public toncpoha( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "TONCPOHA", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_TONCPOHA.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TONCPOHA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_TONCPOHA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_TONCPOHA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TONCPOHA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 4, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx00s0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"TONCPOHAFECHA"+"'), id:'"+"TONCPOHAFECHA"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"TONCPOHAMES"+"'), id:'"+"TONCPOHAMES"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"TONCPOHAANO"+"'), id:'"+"TONCPOHAANO"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"COD_AREA"+"'), id:'"+"COD_AREA"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"INDICADORESCODIGO"+"'), id:'"+"INDICADORESCODIGO"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_TONCPOHA.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTONCPOHAFecha_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTONCPOHAFecha_Internalname, "TONCPOHAFecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTONCPOHAFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTONCPOHAFecha_Internalname, context.localUtil.Format(A54TONCPOHAFecha, "99/99/99"), context.localUtil.Format( A54TONCPOHAFecha, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTONCPOHAFecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTONCPOHAFecha_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_TONCPOHA.htm");
         GxWebStd.gx_bitmap( context, edtTONCPOHAFecha_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTONCPOHAFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TONCPOHA.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTONCPOHAMes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTONCPOHAMes_Internalname, "TONCPOHAMes", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTONCPOHAMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A55TONCPOHAMes), 4, 0, ",", "")), StringUtil.LTrim( ((edtTONCPOHAMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A55TONCPOHAMes), "ZZZ9") : context.localUtil.Format( (decimal)(A55TONCPOHAMes), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTONCPOHAMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTONCPOHAMes_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_TONCPOHA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTONCPOHAAno_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTONCPOHAAno_Internalname, "TONCPOHAAno", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTONCPOHAAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A56TONCPOHAAno), 4, 0, ",", "")), StringUtil.LTrim( ((edtTONCPOHAAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A56TONCPOHAAno), "ZZZ9") : context.localUtil.Format( (decimal)(A56TONCPOHAAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTONCPOHAAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTONCPOHAAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_TONCPOHA.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCod_Area_Internalname, A5Cod_Area, StringUtil.RTrim( context.localUtil.Format( A5Cod_Area, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCod_Area_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCod_Area_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_TONCPOHA.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_5_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_5_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_5_Internalname, sImgUrl, imgprompt_5_Link, "", "", context.GetTheme( ), imgprompt_5_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_TONCPOHA.htm");
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
         GxWebStd.gx_single_line_edit( context, edtIndicadoresCodigo_Internalname, A4IndicadoresCodigo, StringUtil.RTrim( context.localUtil.Format( A4IndicadoresCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIndicadoresCodigo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIndicadoresCodigo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_TONCPOHA.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_4_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_4_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_4_Internalname, sImgUrl, imgprompt_4_Link, "", "", context.GetTheme( ), imgprompt_4_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_TONCPOHA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTONCPOHAhaproduc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTONCPOHAhaproduc_Internalname, "TONCPOHAhaproduc", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTONCPOHAhaproduc_Internalname, StringUtil.LTrim( StringUtil.NToC( A170TONCPOHAhaproduc, 15, 2, ",", "")), StringUtil.LTrim( ((edtTONCPOHAhaproduc_Enabled!=0) ? context.localUtil.Format( A170TONCPOHAhaproduc, "ZZZZZZZZZZZ9.99") : context.localUtil.Format( A170TONCPOHAhaproduc, "ZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTONCPOHAhaproduc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTONCPOHAhaproduc_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_TONCPOHA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTONCPOHAuse_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTONCPOHAuse_Internalname, "TONCPOHAuse", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtTONCPOHAuse_Internalname, A171TONCPOHAuse, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", 0, 1, edtTONCPOHAuse_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_TONCPOHA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTONCPOHAreg_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTONCPOHAreg_Internalname, "TONCPOHAreg", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTONCPOHAreg_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTONCPOHAreg_Internalname, context.localUtil.Format(A172TONCPOHAreg, "99/99/99"), context.localUtil.Format( A172TONCPOHAreg, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTONCPOHAreg_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTONCPOHAreg_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_TONCPOHA.htm");
         GxWebStd.gx_bitmap( context, edtTONCPOHAreg_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTONCPOHAreg_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TONCPOHA.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTONCPOHAhor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTONCPOHAhor_Internalname, "TONCPOHAhor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTONCPOHAhor_Internalname, A173TONCPOHAhor, StringUtil.RTrim( context.localUtil.Format( A173TONCPOHAhor, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTONCPOHAhor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTONCPOHAhor_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_TONCPOHA.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_TONCPOHA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_TONCPOHA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_TONCPOHA.htm");
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
            Z54TONCPOHAFecha = context.localUtil.CToD( cgiGet( "Z54TONCPOHAFecha"), 0);
            Z55TONCPOHAMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z55TONCPOHAMes"), ",", "."), 18, MidpointRounding.ToEven));
            Z56TONCPOHAAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z56TONCPOHAAno"), ",", "."), 18, MidpointRounding.ToEven));
            Z5Cod_Area = cgiGet( "Z5Cod_Area");
            Z4IndicadoresCodigo = cgiGet( "Z4IndicadoresCodigo");
            Z170TONCPOHAhaproduc = context.localUtil.CToN( cgiGet( "Z170TONCPOHAhaproduc"), ",", ".");
            Z171TONCPOHAuse = cgiGet( "Z171TONCPOHAuse");
            Z172TONCPOHAreg = context.localUtil.CToD( cgiGet( "Z172TONCPOHAreg"), 0);
            Z173TONCPOHAhor = cgiGet( "Z173TONCPOHAhor");
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( context.localUtil.VCDate( cgiGet( edtTONCPOHAFecha_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"TONCPOHAFecha"}), 1, "TONCPOHAFECHA");
               AnyError = 1;
               GX_FocusControl = edtTONCPOHAFecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A54TONCPOHAFecha = DateTime.MinValue;
               AssignAttri("", false, "A54TONCPOHAFecha", context.localUtil.Format(A54TONCPOHAFecha, "99/99/99"));
            }
            else
            {
               A54TONCPOHAFecha = context.localUtil.CToD( cgiGet( edtTONCPOHAFecha_Internalname), 2);
               AssignAttri("", false, "A54TONCPOHAFecha", context.localUtil.Format(A54TONCPOHAFecha, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtTONCPOHAMes_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTONCPOHAMes_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TONCPOHAMES");
               AnyError = 1;
               GX_FocusControl = edtTONCPOHAMes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A55TONCPOHAMes = 0;
               AssignAttri("", false, "A55TONCPOHAMes", StringUtil.LTrimStr( (decimal)(A55TONCPOHAMes), 4, 0));
            }
            else
            {
               A55TONCPOHAMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtTONCPOHAMes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A55TONCPOHAMes", StringUtil.LTrimStr( (decimal)(A55TONCPOHAMes), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtTONCPOHAAno_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTONCPOHAAno_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TONCPOHAANO");
               AnyError = 1;
               GX_FocusControl = edtTONCPOHAAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A56TONCPOHAAno = 0;
               AssignAttri("", false, "A56TONCPOHAAno", StringUtil.LTrimStr( (decimal)(A56TONCPOHAAno), 4, 0));
            }
            else
            {
               A56TONCPOHAAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtTONCPOHAAno_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A56TONCPOHAAno", StringUtil.LTrimStr( (decimal)(A56TONCPOHAAno), 4, 0));
            }
            A5Cod_Area = cgiGet( edtCod_Area_Internalname);
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = cgiGet( edtIndicadoresCodigo_Internalname);
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            if ( ( ( context.localUtil.CToN( cgiGet( edtTONCPOHAhaproduc_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTONCPOHAhaproduc_Internalname), ",", ".") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TONCPOHAHAPRODUC");
               AnyError = 1;
               GX_FocusControl = edtTONCPOHAhaproduc_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A170TONCPOHAhaproduc = 0;
               AssignAttri("", false, "A170TONCPOHAhaproduc", StringUtil.LTrimStr( A170TONCPOHAhaproduc, 15, 2));
            }
            else
            {
               A170TONCPOHAhaproduc = context.localUtil.CToN( cgiGet( edtTONCPOHAhaproduc_Internalname), ",", ".");
               AssignAttri("", false, "A170TONCPOHAhaproduc", StringUtil.LTrimStr( A170TONCPOHAhaproduc, 15, 2));
            }
            A171TONCPOHAuse = cgiGet( edtTONCPOHAuse_Internalname);
            AssignAttri("", false, "A171TONCPOHAuse", A171TONCPOHAuse);
            if ( context.localUtil.VCDate( cgiGet( edtTONCPOHAreg_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"TONCPOHAreg"}), 1, "TONCPOHAREG");
               AnyError = 1;
               GX_FocusControl = edtTONCPOHAreg_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A172TONCPOHAreg = DateTime.MinValue;
               AssignAttri("", false, "A172TONCPOHAreg", context.localUtil.Format(A172TONCPOHAreg, "99/99/99"));
            }
            else
            {
               A172TONCPOHAreg = context.localUtil.CToD( cgiGet( edtTONCPOHAreg_Internalname), 2);
               AssignAttri("", false, "A172TONCPOHAreg", context.localUtil.Format(A172TONCPOHAreg, "99/99/99"));
            }
            A173TONCPOHAhor = cgiGet( edtTONCPOHAhor_Internalname);
            AssignAttri("", false, "A173TONCPOHAhor", A173TONCPOHAhor);
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
               A54TONCPOHAFecha = context.localUtil.ParseDateParm( GetPar( "TONCPOHAFecha"));
               AssignAttri("", false, "A54TONCPOHAFecha", context.localUtil.Format(A54TONCPOHAFecha, "99/99/99"));
               A55TONCPOHAMes = (short)(Math.Round(NumberUtil.Val( GetPar( "TONCPOHAMes"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A55TONCPOHAMes", StringUtil.LTrimStr( (decimal)(A55TONCPOHAMes), 4, 0));
               A56TONCPOHAAno = (short)(Math.Round(NumberUtil.Val( GetPar( "TONCPOHAAno"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A56TONCPOHAAno", StringUtil.LTrimStr( (decimal)(A56TONCPOHAAno), 4, 0));
               A5Cod_Area = GetPar( "Cod_Area");
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               A4IndicadoresCodigo = GetPar( "IndicadoresCodigo");
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
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
               InitAll0R28( ) ;
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
         DisableAttributes0R28( ) ;
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

      protected void ResetCaption0R0( )
      {
      }

      protected void ZM0R28( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z170TONCPOHAhaproduc = T000R3_A170TONCPOHAhaproduc[0];
               Z171TONCPOHAuse = T000R3_A171TONCPOHAuse[0];
               Z172TONCPOHAreg = T000R3_A172TONCPOHAreg[0];
               Z173TONCPOHAhor = T000R3_A173TONCPOHAhor[0];
            }
            else
            {
               Z170TONCPOHAhaproduc = A170TONCPOHAhaproduc;
               Z171TONCPOHAuse = A171TONCPOHAuse;
               Z172TONCPOHAreg = A172TONCPOHAreg;
               Z173TONCPOHAhor = A173TONCPOHAhor;
            }
         }
         if ( GX_JID == -3 )
         {
            Z54TONCPOHAFecha = A54TONCPOHAFecha;
            Z55TONCPOHAMes = A55TONCPOHAMes;
            Z56TONCPOHAAno = A56TONCPOHAAno;
            Z170TONCPOHAhaproduc = A170TONCPOHAhaproduc;
            Z171TONCPOHAuse = A171TONCPOHAuse;
            Z172TONCPOHAreg = A172TONCPOHAreg;
            Z173TONCPOHAhor = A173TONCPOHAhor;
            Z5Cod_Area = A5Cod_Area;
            Z4IndicadoresCodigo = A4IndicadoresCodigo;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_5_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"COD_AREA"+"'), id:'"+"COD_AREA"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"true"+");");
         imgprompt_4_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0030.aspx"+"',["+"{Ctrl:gx.dom.el('"+"INDICADORESCODIGO"+"'), id:'"+"INDICADORESCODIGO"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");");
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

      protected void Load0R28( )
      {
         /* Using cursor T000R6 */
         pr_default.execute(4, new Object[] {A54TONCPOHAFecha, A55TONCPOHAMes, A56TONCPOHAAno, A5Cod_Area, A4IndicadoresCodigo});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound28 = 1;
            A170TONCPOHAhaproduc = T000R6_A170TONCPOHAhaproduc[0];
            AssignAttri("", false, "A170TONCPOHAhaproduc", StringUtil.LTrimStr( A170TONCPOHAhaproduc, 15, 2));
            A171TONCPOHAuse = T000R6_A171TONCPOHAuse[0];
            AssignAttri("", false, "A171TONCPOHAuse", A171TONCPOHAuse);
            A172TONCPOHAreg = T000R6_A172TONCPOHAreg[0];
            AssignAttri("", false, "A172TONCPOHAreg", context.localUtil.Format(A172TONCPOHAreg, "99/99/99"));
            A173TONCPOHAhor = T000R6_A173TONCPOHAhor[0];
            AssignAttri("", false, "A173TONCPOHAhor", A173TONCPOHAhor);
            ZM0R28( -3) ;
         }
         pr_default.close(4);
         OnLoadActions0R28( ) ;
      }

      protected void OnLoadActions0R28( )
      {
      }

      protected void CheckExtendedTable0R28( )
      {
         nIsDirty_28 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A54TONCPOHAFecha) || ( DateTimeUtil.ResetTime ( A54TONCPOHAFecha ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo TONCPOHAFecha fuera de rango", "OutOfRange", 1, "TONCPOHAFECHA");
            AnyError = 1;
            GX_FocusControl = edtTONCPOHAFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000R4 */
         pr_default.execute(2, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T000R5 */
         pr_default.execute(3, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         if ( ! ( (DateTime.MinValue==A172TONCPOHAreg) || ( DateTimeUtil.ResetTime ( A172TONCPOHAreg ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo TONCPOHAreg fuera de rango", "OutOfRange", 1, "TONCPOHAREG");
            AnyError = 1;
            GX_FocusControl = edtTONCPOHAreg_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0R28( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_4( string A5Cod_Area )
      {
         /* Using cursor T000R7 */
         pr_default.execute(5, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_5( string A4IndicadoresCodigo )
      {
         /* Using cursor T000R8 */
         pr_default.execute(6, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
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

      protected void GetKey0R28( )
      {
         /* Using cursor T000R9 */
         pr_default.execute(7, new Object[] {A54TONCPOHAFecha, A55TONCPOHAMes, A56TONCPOHAAno, A5Cod_Area, A4IndicadoresCodigo});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound28 = 1;
         }
         else
         {
            RcdFound28 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000R3 */
         pr_default.execute(1, new Object[] {A54TONCPOHAFecha, A55TONCPOHAMes, A56TONCPOHAAno, A5Cod_Area, A4IndicadoresCodigo});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0R28( 3) ;
            RcdFound28 = 1;
            A54TONCPOHAFecha = T000R3_A54TONCPOHAFecha[0];
            AssignAttri("", false, "A54TONCPOHAFecha", context.localUtil.Format(A54TONCPOHAFecha, "99/99/99"));
            A55TONCPOHAMes = T000R3_A55TONCPOHAMes[0];
            AssignAttri("", false, "A55TONCPOHAMes", StringUtil.LTrimStr( (decimal)(A55TONCPOHAMes), 4, 0));
            A56TONCPOHAAno = T000R3_A56TONCPOHAAno[0];
            AssignAttri("", false, "A56TONCPOHAAno", StringUtil.LTrimStr( (decimal)(A56TONCPOHAAno), 4, 0));
            A170TONCPOHAhaproduc = T000R3_A170TONCPOHAhaproduc[0];
            AssignAttri("", false, "A170TONCPOHAhaproduc", StringUtil.LTrimStr( A170TONCPOHAhaproduc, 15, 2));
            A171TONCPOHAuse = T000R3_A171TONCPOHAuse[0];
            AssignAttri("", false, "A171TONCPOHAuse", A171TONCPOHAuse);
            A172TONCPOHAreg = T000R3_A172TONCPOHAreg[0];
            AssignAttri("", false, "A172TONCPOHAreg", context.localUtil.Format(A172TONCPOHAreg, "99/99/99"));
            A173TONCPOHAhor = T000R3_A173TONCPOHAhor[0];
            AssignAttri("", false, "A173TONCPOHAhor", A173TONCPOHAhor);
            A5Cod_Area = T000R3_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = T000R3_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            Z54TONCPOHAFecha = A54TONCPOHAFecha;
            Z55TONCPOHAMes = A55TONCPOHAMes;
            Z56TONCPOHAAno = A56TONCPOHAAno;
            Z5Cod_Area = A5Cod_Area;
            Z4IndicadoresCodigo = A4IndicadoresCodigo;
            sMode28 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0R28( ) ;
            if ( AnyError == 1 )
            {
               RcdFound28 = 0;
               InitializeNonKey0R28( ) ;
            }
            Gx_mode = sMode28;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound28 = 0;
            InitializeNonKey0R28( ) ;
            sMode28 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode28;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0R28( ) ;
         if ( RcdFound28 == 0 )
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
         RcdFound28 = 0;
         /* Using cursor T000R10 */
         pr_default.execute(8, new Object[] {A54TONCPOHAFecha, A55TONCPOHAMes, A56TONCPOHAAno, A5Cod_Area, A4IndicadoresCodigo});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( DateTimeUtil.ResetTime ( T000R10_A54TONCPOHAFecha[0] ) < DateTimeUtil.ResetTime ( A54TONCPOHAFecha ) ) || ( DateTimeUtil.ResetTime ( T000R10_A54TONCPOHAFecha[0] ) == DateTimeUtil.ResetTime ( A54TONCPOHAFecha ) ) && ( T000R10_A55TONCPOHAMes[0] < A55TONCPOHAMes ) || ( T000R10_A55TONCPOHAMes[0] == A55TONCPOHAMes ) && ( DateTimeUtil.ResetTime ( T000R10_A54TONCPOHAFecha[0] ) == DateTimeUtil.ResetTime ( A54TONCPOHAFecha ) ) && ( T000R10_A56TONCPOHAAno[0] < A56TONCPOHAAno ) || ( T000R10_A56TONCPOHAAno[0] == A56TONCPOHAAno ) && ( T000R10_A55TONCPOHAMes[0] == A55TONCPOHAMes ) && ( DateTimeUtil.ResetTime ( T000R10_A54TONCPOHAFecha[0] ) == DateTimeUtil.ResetTime ( A54TONCPOHAFecha ) ) && ( StringUtil.StrCmp(T000R10_A5Cod_Area[0], A5Cod_Area) < 0 ) || ( StringUtil.StrCmp(T000R10_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000R10_A56TONCPOHAAno[0] == A56TONCPOHAAno ) && ( T000R10_A55TONCPOHAMes[0] == A55TONCPOHAMes ) && ( DateTimeUtil.ResetTime ( T000R10_A54TONCPOHAFecha[0] ) == DateTimeUtil.ResetTime ( A54TONCPOHAFecha ) ) && ( StringUtil.StrCmp(T000R10_A4IndicadoresCodigo[0], A4IndicadoresCodigo) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( DateTimeUtil.ResetTime ( T000R10_A54TONCPOHAFecha[0] ) > DateTimeUtil.ResetTime ( A54TONCPOHAFecha ) ) || ( DateTimeUtil.ResetTime ( T000R10_A54TONCPOHAFecha[0] ) == DateTimeUtil.ResetTime ( A54TONCPOHAFecha ) ) && ( T000R10_A55TONCPOHAMes[0] > A55TONCPOHAMes ) || ( T000R10_A55TONCPOHAMes[0] == A55TONCPOHAMes ) && ( DateTimeUtil.ResetTime ( T000R10_A54TONCPOHAFecha[0] ) == DateTimeUtil.ResetTime ( A54TONCPOHAFecha ) ) && ( T000R10_A56TONCPOHAAno[0] > A56TONCPOHAAno ) || ( T000R10_A56TONCPOHAAno[0] == A56TONCPOHAAno ) && ( T000R10_A55TONCPOHAMes[0] == A55TONCPOHAMes ) && ( DateTimeUtil.ResetTime ( T000R10_A54TONCPOHAFecha[0] ) == DateTimeUtil.ResetTime ( A54TONCPOHAFecha ) ) && ( StringUtil.StrCmp(T000R10_A5Cod_Area[0], A5Cod_Area) > 0 ) || ( StringUtil.StrCmp(T000R10_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000R10_A56TONCPOHAAno[0] == A56TONCPOHAAno ) && ( T000R10_A55TONCPOHAMes[0] == A55TONCPOHAMes ) && ( DateTimeUtil.ResetTime ( T000R10_A54TONCPOHAFecha[0] ) == DateTimeUtil.ResetTime ( A54TONCPOHAFecha ) ) && ( StringUtil.StrCmp(T000R10_A4IndicadoresCodigo[0], A4IndicadoresCodigo) > 0 ) ) )
            {
               A54TONCPOHAFecha = T000R10_A54TONCPOHAFecha[0];
               AssignAttri("", false, "A54TONCPOHAFecha", context.localUtil.Format(A54TONCPOHAFecha, "99/99/99"));
               A55TONCPOHAMes = T000R10_A55TONCPOHAMes[0];
               AssignAttri("", false, "A55TONCPOHAMes", StringUtil.LTrimStr( (decimal)(A55TONCPOHAMes), 4, 0));
               A56TONCPOHAAno = T000R10_A56TONCPOHAAno[0];
               AssignAttri("", false, "A56TONCPOHAAno", StringUtil.LTrimStr( (decimal)(A56TONCPOHAAno), 4, 0));
               A5Cod_Area = T000R10_A5Cod_Area[0];
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               A4IndicadoresCodigo = T000R10_A4IndicadoresCodigo[0];
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               RcdFound28 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound28 = 0;
         /* Using cursor T000R11 */
         pr_default.execute(9, new Object[] {A54TONCPOHAFecha, A55TONCPOHAMes, A56TONCPOHAAno, A5Cod_Area, A4IndicadoresCodigo});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( DateTimeUtil.ResetTime ( T000R11_A54TONCPOHAFecha[0] ) > DateTimeUtil.ResetTime ( A54TONCPOHAFecha ) ) || ( DateTimeUtil.ResetTime ( T000R11_A54TONCPOHAFecha[0] ) == DateTimeUtil.ResetTime ( A54TONCPOHAFecha ) ) && ( T000R11_A55TONCPOHAMes[0] > A55TONCPOHAMes ) || ( T000R11_A55TONCPOHAMes[0] == A55TONCPOHAMes ) && ( DateTimeUtil.ResetTime ( T000R11_A54TONCPOHAFecha[0] ) == DateTimeUtil.ResetTime ( A54TONCPOHAFecha ) ) && ( T000R11_A56TONCPOHAAno[0] > A56TONCPOHAAno ) || ( T000R11_A56TONCPOHAAno[0] == A56TONCPOHAAno ) && ( T000R11_A55TONCPOHAMes[0] == A55TONCPOHAMes ) && ( DateTimeUtil.ResetTime ( T000R11_A54TONCPOHAFecha[0] ) == DateTimeUtil.ResetTime ( A54TONCPOHAFecha ) ) && ( StringUtil.StrCmp(T000R11_A5Cod_Area[0], A5Cod_Area) > 0 ) || ( StringUtil.StrCmp(T000R11_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000R11_A56TONCPOHAAno[0] == A56TONCPOHAAno ) && ( T000R11_A55TONCPOHAMes[0] == A55TONCPOHAMes ) && ( DateTimeUtil.ResetTime ( T000R11_A54TONCPOHAFecha[0] ) == DateTimeUtil.ResetTime ( A54TONCPOHAFecha ) ) && ( StringUtil.StrCmp(T000R11_A4IndicadoresCodigo[0], A4IndicadoresCodigo) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( DateTimeUtil.ResetTime ( T000R11_A54TONCPOHAFecha[0] ) < DateTimeUtil.ResetTime ( A54TONCPOHAFecha ) ) || ( DateTimeUtil.ResetTime ( T000R11_A54TONCPOHAFecha[0] ) == DateTimeUtil.ResetTime ( A54TONCPOHAFecha ) ) && ( T000R11_A55TONCPOHAMes[0] < A55TONCPOHAMes ) || ( T000R11_A55TONCPOHAMes[0] == A55TONCPOHAMes ) && ( DateTimeUtil.ResetTime ( T000R11_A54TONCPOHAFecha[0] ) == DateTimeUtil.ResetTime ( A54TONCPOHAFecha ) ) && ( T000R11_A56TONCPOHAAno[0] < A56TONCPOHAAno ) || ( T000R11_A56TONCPOHAAno[0] == A56TONCPOHAAno ) && ( T000R11_A55TONCPOHAMes[0] == A55TONCPOHAMes ) && ( DateTimeUtil.ResetTime ( T000R11_A54TONCPOHAFecha[0] ) == DateTimeUtil.ResetTime ( A54TONCPOHAFecha ) ) && ( StringUtil.StrCmp(T000R11_A5Cod_Area[0], A5Cod_Area) < 0 ) || ( StringUtil.StrCmp(T000R11_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000R11_A56TONCPOHAAno[0] == A56TONCPOHAAno ) && ( T000R11_A55TONCPOHAMes[0] == A55TONCPOHAMes ) && ( DateTimeUtil.ResetTime ( T000R11_A54TONCPOHAFecha[0] ) == DateTimeUtil.ResetTime ( A54TONCPOHAFecha ) ) && ( StringUtil.StrCmp(T000R11_A4IndicadoresCodigo[0], A4IndicadoresCodigo) < 0 ) ) )
            {
               A54TONCPOHAFecha = T000R11_A54TONCPOHAFecha[0];
               AssignAttri("", false, "A54TONCPOHAFecha", context.localUtil.Format(A54TONCPOHAFecha, "99/99/99"));
               A55TONCPOHAMes = T000R11_A55TONCPOHAMes[0];
               AssignAttri("", false, "A55TONCPOHAMes", StringUtil.LTrimStr( (decimal)(A55TONCPOHAMes), 4, 0));
               A56TONCPOHAAno = T000R11_A56TONCPOHAAno[0];
               AssignAttri("", false, "A56TONCPOHAAno", StringUtil.LTrimStr( (decimal)(A56TONCPOHAAno), 4, 0));
               A5Cod_Area = T000R11_A5Cod_Area[0];
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               A4IndicadoresCodigo = T000R11_A4IndicadoresCodigo[0];
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               RcdFound28 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0R28( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTONCPOHAFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0R28( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound28 == 1 )
            {
               if ( ( DateTimeUtil.ResetTime ( A54TONCPOHAFecha ) != DateTimeUtil.ResetTime ( Z54TONCPOHAFecha ) ) || ( A55TONCPOHAMes != Z55TONCPOHAMes ) || ( A56TONCPOHAAno != Z56TONCPOHAAno ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) )
               {
                  A54TONCPOHAFecha = Z54TONCPOHAFecha;
                  AssignAttri("", false, "A54TONCPOHAFecha", context.localUtil.Format(A54TONCPOHAFecha, "99/99/99"));
                  A55TONCPOHAMes = Z55TONCPOHAMes;
                  AssignAttri("", false, "A55TONCPOHAMes", StringUtil.LTrimStr( (decimal)(A55TONCPOHAMes), 4, 0));
                  A56TONCPOHAAno = Z56TONCPOHAAno;
                  AssignAttri("", false, "A56TONCPOHAAno", StringUtil.LTrimStr( (decimal)(A56TONCPOHAAno), 4, 0));
                  A5Cod_Area = Z5Cod_Area;
                  AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
                  A4IndicadoresCodigo = Z4IndicadoresCodigo;
                  AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TONCPOHAFECHA");
                  AnyError = 1;
                  GX_FocusControl = edtTONCPOHAFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTONCPOHAFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0R28( ) ;
                  GX_FocusControl = edtTONCPOHAFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( DateTimeUtil.ResetTime ( A54TONCPOHAFecha ) != DateTimeUtil.ResetTime ( Z54TONCPOHAFecha ) ) || ( A55TONCPOHAMes != Z55TONCPOHAMes ) || ( A56TONCPOHAAno != Z56TONCPOHAAno ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtTONCPOHAFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0R28( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TONCPOHAFECHA");
                     AnyError = 1;
                     GX_FocusControl = edtTONCPOHAFecha_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtTONCPOHAFecha_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0R28( ) ;
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
         if ( ( DateTimeUtil.ResetTime ( A54TONCPOHAFecha ) != DateTimeUtil.ResetTime ( Z54TONCPOHAFecha ) ) || ( A55TONCPOHAMes != Z55TONCPOHAMes ) || ( A56TONCPOHAAno != Z56TONCPOHAAno ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) )
         {
            A54TONCPOHAFecha = Z54TONCPOHAFecha;
            AssignAttri("", false, "A54TONCPOHAFecha", context.localUtil.Format(A54TONCPOHAFecha, "99/99/99"));
            A55TONCPOHAMes = Z55TONCPOHAMes;
            AssignAttri("", false, "A55TONCPOHAMes", StringUtil.LTrimStr( (decimal)(A55TONCPOHAMes), 4, 0));
            A56TONCPOHAAno = Z56TONCPOHAAno;
            AssignAttri("", false, "A56TONCPOHAAno", StringUtil.LTrimStr( (decimal)(A56TONCPOHAAno), 4, 0));
            A5Cod_Area = Z5Cod_Area;
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = Z4IndicadoresCodigo;
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TONCPOHAFECHA");
            AnyError = 1;
            GX_FocusControl = edtTONCPOHAFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTONCPOHAFecha_Internalname;
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
         if ( RcdFound28 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "TONCPOHAFECHA");
            AnyError = 1;
            GX_FocusControl = edtTONCPOHAFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtTONCPOHAhaproduc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0R28( ) ;
         if ( RcdFound28 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTONCPOHAhaproduc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0R28( ) ;
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
         if ( RcdFound28 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTONCPOHAhaproduc_Internalname;
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
         if ( RcdFound28 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTONCPOHAhaproduc_Internalname;
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
         ScanStart0R28( ) ;
         if ( RcdFound28 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound28 != 0 )
            {
               ScanNext0R28( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTONCPOHAhaproduc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0R28( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0R28( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000R2 */
            pr_default.execute(0, new Object[] {A54TONCPOHAFecha, A55TONCPOHAMes, A56TONCPOHAAno, A5Cod_Area, A4IndicadoresCodigo});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TONCPOHA"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z170TONCPOHAhaproduc != T000R2_A170TONCPOHAhaproduc[0] ) || ( StringUtil.StrCmp(Z171TONCPOHAuse, T000R2_A171TONCPOHAuse[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z172TONCPOHAreg ) != DateTimeUtil.ResetTime ( T000R2_A172TONCPOHAreg[0] ) ) || ( StringUtil.StrCmp(Z173TONCPOHAhor, T000R2_A173TONCPOHAhor[0]) != 0 ) )
            {
               if ( Z170TONCPOHAhaproduc != T000R2_A170TONCPOHAhaproduc[0] )
               {
                  GXUtil.WriteLog("toncpoha:[seudo value changed for attri]"+"TONCPOHAhaproduc");
                  GXUtil.WriteLogRaw("Old: ",Z170TONCPOHAhaproduc);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A170TONCPOHAhaproduc[0]);
               }
               if ( StringUtil.StrCmp(Z171TONCPOHAuse, T000R2_A171TONCPOHAuse[0]) != 0 )
               {
                  GXUtil.WriteLog("toncpoha:[seudo value changed for attri]"+"TONCPOHAuse");
                  GXUtil.WriteLogRaw("Old: ",Z171TONCPOHAuse);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A171TONCPOHAuse[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z172TONCPOHAreg ) != DateTimeUtil.ResetTime ( T000R2_A172TONCPOHAreg[0] ) )
               {
                  GXUtil.WriteLog("toncpoha:[seudo value changed for attri]"+"TONCPOHAreg");
                  GXUtil.WriteLogRaw("Old: ",Z172TONCPOHAreg);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A172TONCPOHAreg[0]);
               }
               if ( StringUtil.StrCmp(Z173TONCPOHAhor, T000R2_A173TONCPOHAhor[0]) != 0 )
               {
                  GXUtil.WriteLog("toncpoha:[seudo value changed for attri]"+"TONCPOHAhor");
                  GXUtil.WriteLogRaw("Old: ",Z173TONCPOHAhor);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A173TONCPOHAhor[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TONCPOHA"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0R28( )
      {
         BeforeValidate0R28( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0R28( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0R28( 0) ;
            CheckOptimisticConcurrency0R28( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0R28( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0R28( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000R12 */
                     pr_default.execute(10, new Object[] {A54TONCPOHAFecha, A55TONCPOHAMes, A56TONCPOHAAno, A170TONCPOHAhaproduc, A171TONCPOHAuse, A172TONCPOHAreg, A173TONCPOHAhor, A5Cod_Area, A4IndicadoresCodigo});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("TONCPOHA");
                     if ( (pr_default.getStatus(10) == 1) )
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
                           ResetCaption0R0( ) ;
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
               Load0R28( ) ;
            }
            EndLevel0R28( ) ;
         }
         CloseExtendedTableCursors0R28( ) ;
      }

      protected void Update0R28( )
      {
         BeforeValidate0R28( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0R28( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0R28( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0R28( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0R28( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000R13 */
                     pr_default.execute(11, new Object[] {A170TONCPOHAhaproduc, A171TONCPOHAuse, A172TONCPOHAreg, A173TONCPOHAhor, A54TONCPOHAFecha, A55TONCPOHAMes, A56TONCPOHAAno, A5Cod_Area, A4IndicadoresCodigo});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("TONCPOHA");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TONCPOHA"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0R28( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0R0( ) ;
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
            EndLevel0R28( ) ;
         }
         CloseExtendedTableCursors0R28( ) ;
      }

      protected void DeferredUpdate0R28( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0R28( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0R28( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0R28( ) ;
            AfterConfirm0R28( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0R28( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000R14 */
                  pr_default.execute(12, new Object[] {A54TONCPOHAFecha, A55TONCPOHAMes, A56TONCPOHAAno, A5Cod_Area, A4IndicadoresCodigo});
                  pr_default.close(12);
                  pr_default.SmartCacheProvider.SetUpdated("TONCPOHA");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound28 == 0 )
                        {
                           InitAll0R28( ) ;
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
                        ResetCaption0R0( ) ;
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
         sMode28 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0R28( ) ;
         Gx_mode = sMode28;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0R28( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0R28( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0R28( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("toncpoha",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0R0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("toncpoha",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0R28( )
      {
         /* Using cursor T000R15 */
         pr_default.execute(13);
         RcdFound28 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound28 = 1;
            A54TONCPOHAFecha = T000R15_A54TONCPOHAFecha[0];
            AssignAttri("", false, "A54TONCPOHAFecha", context.localUtil.Format(A54TONCPOHAFecha, "99/99/99"));
            A55TONCPOHAMes = T000R15_A55TONCPOHAMes[0];
            AssignAttri("", false, "A55TONCPOHAMes", StringUtil.LTrimStr( (decimal)(A55TONCPOHAMes), 4, 0));
            A56TONCPOHAAno = T000R15_A56TONCPOHAAno[0];
            AssignAttri("", false, "A56TONCPOHAAno", StringUtil.LTrimStr( (decimal)(A56TONCPOHAAno), 4, 0));
            A5Cod_Area = T000R15_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = T000R15_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0R28( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound28 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound28 = 1;
            A54TONCPOHAFecha = T000R15_A54TONCPOHAFecha[0];
            AssignAttri("", false, "A54TONCPOHAFecha", context.localUtil.Format(A54TONCPOHAFecha, "99/99/99"));
            A55TONCPOHAMes = T000R15_A55TONCPOHAMes[0];
            AssignAttri("", false, "A55TONCPOHAMes", StringUtil.LTrimStr( (decimal)(A55TONCPOHAMes), 4, 0));
            A56TONCPOHAAno = T000R15_A56TONCPOHAAno[0];
            AssignAttri("", false, "A56TONCPOHAAno", StringUtil.LTrimStr( (decimal)(A56TONCPOHAAno), 4, 0));
            A5Cod_Area = T000R15_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = T000R15_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
         }
      }

      protected void ScanEnd0R28( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm0R28( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0R28( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0R28( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0R28( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0R28( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0R28( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0R28( )
      {
         edtTONCPOHAFecha_Enabled = 0;
         AssignProp("", false, edtTONCPOHAFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTONCPOHAFecha_Enabled), 5, 0), true);
         edtTONCPOHAMes_Enabled = 0;
         AssignProp("", false, edtTONCPOHAMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTONCPOHAMes_Enabled), 5, 0), true);
         edtTONCPOHAAno_Enabled = 0;
         AssignProp("", false, edtTONCPOHAAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTONCPOHAAno_Enabled), 5, 0), true);
         edtCod_Area_Enabled = 0;
         AssignProp("", false, edtCod_Area_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCod_Area_Enabled), 5, 0), true);
         edtIndicadoresCodigo_Enabled = 0;
         AssignProp("", false, edtIndicadoresCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIndicadoresCodigo_Enabled), 5, 0), true);
         edtTONCPOHAhaproduc_Enabled = 0;
         AssignProp("", false, edtTONCPOHAhaproduc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTONCPOHAhaproduc_Enabled), 5, 0), true);
         edtTONCPOHAuse_Enabled = 0;
         AssignProp("", false, edtTONCPOHAuse_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTONCPOHAuse_Enabled), 5, 0), true);
         edtTONCPOHAreg_Enabled = 0;
         AssignProp("", false, edtTONCPOHAreg_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTONCPOHAreg_Enabled), 5, 0), true);
         edtTONCPOHAhor_Enabled = 0;
         AssignProp("", false, edtTONCPOHAhor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTONCPOHAhor_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0R28( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0R0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("toncpoha.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z54TONCPOHAFecha", context.localUtil.DToC( Z54TONCPOHAFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z55TONCPOHAMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z55TONCPOHAMes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z56TONCPOHAAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z56TONCPOHAAno), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z5Cod_Area", Z5Cod_Area);
         GxWebStd.gx_hidden_field( context, "Z4IndicadoresCodigo", Z4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "Z170TONCPOHAhaproduc", StringUtil.LTrim( StringUtil.NToC( Z170TONCPOHAhaproduc, 15, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z171TONCPOHAuse", Z171TONCPOHAuse);
         GxWebStd.gx_hidden_field( context, "Z172TONCPOHAreg", context.localUtil.DToC( Z172TONCPOHAreg, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z173TONCPOHAhor", Z173TONCPOHAhor);
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
         return formatLink("toncpoha.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "TONCPOHA" ;
      }

      public override string GetPgmdesc( )
      {
         return "TONCPOHA" ;
      }

      protected void InitializeNonKey0R28( )
      {
         A170TONCPOHAhaproduc = 0;
         AssignAttri("", false, "A170TONCPOHAhaproduc", StringUtil.LTrimStr( A170TONCPOHAhaproduc, 15, 2));
         A171TONCPOHAuse = "";
         AssignAttri("", false, "A171TONCPOHAuse", A171TONCPOHAuse);
         A172TONCPOHAreg = DateTime.MinValue;
         AssignAttri("", false, "A172TONCPOHAreg", context.localUtil.Format(A172TONCPOHAreg, "99/99/99"));
         A173TONCPOHAhor = "";
         AssignAttri("", false, "A173TONCPOHAhor", A173TONCPOHAhor);
         Z170TONCPOHAhaproduc = 0;
         Z171TONCPOHAuse = "";
         Z172TONCPOHAreg = DateTime.MinValue;
         Z173TONCPOHAhor = "";
      }

      protected void InitAll0R28( )
      {
         A54TONCPOHAFecha = DateTime.MinValue;
         AssignAttri("", false, "A54TONCPOHAFecha", context.localUtil.Format(A54TONCPOHAFecha, "99/99/99"));
         A55TONCPOHAMes = 0;
         AssignAttri("", false, "A55TONCPOHAMes", StringUtil.LTrimStr( (decimal)(A55TONCPOHAMes), 4, 0));
         A56TONCPOHAAno = 0;
         AssignAttri("", false, "A56TONCPOHAAno", StringUtil.LTrimStr( (decimal)(A56TONCPOHAAno), 4, 0));
         A5Cod_Area = "";
         AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
         A4IndicadoresCodigo = "";
         AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
         InitializeNonKey0R28( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20247231024783", true, true);
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
         context.AddJavascriptSource("toncpoha.js", "?20247231024783", false, true);
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
         edtTONCPOHAFecha_Internalname = "TONCPOHAFECHA";
         edtTONCPOHAMes_Internalname = "TONCPOHAMES";
         edtTONCPOHAAno_Internalname = "TONCPOHAANO";
         edtCod_Area_Internalname = "COD_AREA";
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO";
         edtTONCPOHAhaproduc_Internalname = "TONCPOHAHAPRODUC";
         edtTONCPOHAuse_Internalname = "TONCPOHAUSE";
         edtTONCPOHAreg_Internalname = "TONCPOHAREG";
         edtTONCPOHAhor_Internalname = "TONCPOHAHOR";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_5_Internalname = "PROMPT_5";
         imgprompt_4_Internalname = "PROMPT_4";
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
         Form.Caption = "TONCPOHA";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtTONCPOHAhor_Jsonclick = "";
         edtTONCPOHAhor_Enabled = 1;
         edtTONCPOHAreg_Jsonclick = "";
         edtTONCPOHAreg_Enabled = 1;
         edtTONCPOHAuse_Enabled = 1;
         edtTONCPOHAhaproduc_Jsonclick = "";
         edtTONCPOHAhaproduc_Enabled = 1;
         imgprompt_4_Visible = 1;
         imgprompt_4_Link = "";
         edtIndicadoresCodigo_Jsonclick = "";
         edtIndicadoresCodigo_Enabled = 1;
         imgprompt_5_Visible = 1;
         imgprompt_5_Link = "";
         edtCod_Area_Jsonclick = "";
         edtCod_Area_Enabled = 1;
         edtTONCPOHAAno_Jsonclick = "";
         edtTONCPOHAAno_Enabled = 1;
         edtTONCPOHAMes_Jsonclick = "";
         edtTONCPOHAMes_Enabled = 1;
         edtTONCPOHAFecha_Jsonclick = "";
         edtTONCPOHAFecha_Enabled = 1;
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
         /* Using cursor T000R16 */
         pr_default.execute(14, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(14);
         /* Using cursor T000R17 */
         pr_default.execute(15, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(15);
         GX_FocusControl = edtTONCPOHAhaproduc_Internalname;
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
         /* Using cursor T000R16 */
         pr_default.execute(14, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
         }
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Indicadorescodigo( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T000R17 */
         pr_default.execute(15, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
         }
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A170TONCPOHAhaproduc", StringUtil.LTrim( StringUtil.NToC( A170TONCPOHAhaproduc, 15, 2, ".", "")));
         AssignAttri("", false, "A171TONCPOHAuse", A171TONCPOHAuse);
         AssignAttri("", false, "A172TONCPOHAreg", context.localUtil.Format(A172TONCPOHAreg, "99/99/99"));
         AssignAttri("", false, "A173TONCPOHAhor", A173TONCPOHAhor);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z54TONCPOHAFecha", context.localUtil.Format(Z54TONCPOHAFecha, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z55TONCPOHAMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z55TONCPOHAMes), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z56TONCPOHAAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z56TONCPOHAAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z5Cod_Area", Z5Cod_Area);
         GxWebStd.gx_hidden_field( context, "Z4IndicadoresCodigo", Z4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "Z170TONCPOHAhaproduc", StringUtil.LTrim( StringUtil.NToC( Z170TONCPOHAhaproduc, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z171TONCPOHAuse", Z171TONCPOHAuse);
         GxWebStd.gx_hidden_field( context, "Z172TONCPOHAreg", context.localUtil.Format(Z172TONCPOHAreg, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z173TONCPOHAhor", Z173TONCPOHAhor);
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
         setEventMetadata("VALID_TONCPOHAFECHA","{handler:'Valid_Toncpohafecha',iparms:[]");
         setEventMetadata("VALID_TONCPOHAFECHA",",oparms:[]}");
         setEventMetadata("VALID_TONCPOHAMES","{handler:'Valid_Toncpohames',iparms:[]");
         setEventMetadata("VALID_TONCPOHAMES",",oparms:[]}");
         setEventMetadata("VALID_TONCPOHAANO","{handler:'Valid_Toncpohaano',iparms:[]");
         setEventMetadata("VALID_TONCPOHAANO",",oparms:[]}");
         setEventMetadata("VALID_COD_AREA","{handler:'Valid_Cod_area',iparms:[{av:'A5Cod_Area',fld:'COD_AREA',pic:''}]");
         setEventMetadata("VALID_COD_AREA",",oparms:[]}");
         setEventMetadata("VALID_INDICADORESCODIGO","{handler:'Valid_Indicadorescodigo',iparms:[{av:'A54TONCPOHAFecha',fld:'TONCPOHAFECHA',pic:''},{av:'A55TONCPOHAMes',fld:'TONCPOHAMES',pic:'ZZZ9'},{av:'A56TONCPOHAAno',fld:'TONCPOHAANO',pic:'ZZZ9'},{av:'A5Cod_Area',fld:'COD_AREA',pic:''},{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_INDICADORESCODIGO",",oparms:[{av:'A170TONCPOHAhaproduc',fld:'TONCPOHAHAPRODUC',pic:'ZZZZZZZZZZZ9.99'},{av:'A171TONCPOHAuse',fld:'TONCPOHAUSE',pic:''},{av:'A172TONCPOHAreg',fld:'TONCPOHAREG',pic:''},{av:'A173TONCPOHAhor',fld:'TONCPOHAHOR',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z54TONCPOHAFecha'},{av:'Z55TONCPOHAMes'},{av:'Z56TONCPOHAAno'},{av:'Z5Cod_Area'},{av:'Z4IndicadoresCodigo'},{av:'Z170TONCPOHAhaproduc'},{av:'Z171TONCPOHAuse'},{av:'Z172TONCPOHAreg'},{av:'Z173TONCPOHAhor'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_TONCPOHAREG","{handler:'Valid_Toncpohareg',iparms:[]");
         setEventMetadata("VALID_TONCPOHAREG",",oparms:[]}");
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
         pr_default.close(14);
         pr_default.close(15);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z54TONCPOHAFecha = DateTime.MinValue;
         Z5Cod_Area = "";
         Z4IndicadoresCodigo = "";
         Z171TONCPOHAuse = "";
         Z172TONCPOHAreg = DateTime.MinValue;
         Z173TONCPOHAhor = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A5Cod_Area = "";
         A4IndicadoresCodigo = "";
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
         A54TONCPOHAFecha = DateTime.MinValue;
         imgprompt_5_gximage = "";
         sImgUrl = "";
         imgprompt_4_gximage = "";
         A171TONCPOHAuse = "";
         A172TONCPOHAreg = DateTime.MinValue;
         A173TONCPOHAhor = "";
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
         T000R6_A54TONCPOHAFecha = new DateTime[] {DateTime.MinValue} ;
         T000R6_A55TONCPOHAMes = new short[1] ;
         T000R6_A56TONCPOHAAno = new short[1] ;
         T000R6_A170TONCPOHAhaproduc = new decimal[1] ;
         T000R6_A171TONCPOHAuse = new string[] {""} ;
         T000R6_A172TONCPOHAreg = new DateTime[] {DateTime.MinValue} ;
         T000R6_A173TONCPOHAhor = new string[] {""} ;
         T000R6_A5Cod_Area = new string[] {""} ;
         T000R6_A4IndicadoresCodigo = new string[] {""} ;
         T000R4_A5Cod_Area = new string[] {""} ;
         T000R5_A4IndicadoresCodigo = new string[] {""} ;
         T000R7_A5Cod_Area = new string[] {""} ;
         T000R8_A4IndicadoresCodigo = new string[] {""} ;
         T000R9_A54TONCPOHAFecha = new DateTime[] {DateTime.MinValue} ;
         T000R9_A55TONCPOHAMes = new short[1] ;
         T000R9_A56TONCPOHAAno = new short[1] ;
         T000R9_A5Cod_Area = new string[] {""} ;
         T000R9_A4IndicadoresCodigo = new string[] {""} ;
         T000R3_A54TONCPOHAFecha = new DateTime[] {DateTime.MinValue} ;
         T000R3_A55TONCPOHAMes = new short[1] ;
         T000R3_A56TONCPOHAAno = new short[1] ;
         T000R3_A170TONCPOHAhaproduc = new decimal[1] ;
         T000R3_A171TONCPOHAuse = new string[] {""} ;
         T000R3_A172TONCPOHAreg = new DateTime[] {DateTime.MinValue} ;
         T000R3_A173TONCPOHAhor = new string[] {""} ;
         T000R3_A5Cod_Area = new string[] {""} ;
         T000R3_A4IndicadoresCodigo = new string[] {""} ;
         sMode28 = "";
         T000R10_A54TONCPOHAFecha = new DateTime[] {DateTime.MinValue} ;
         T000R10_A55TONCPOHAMes = new short[1] ;
         T000R10_A56TONCPOHAAno = new short[1] ;
         T000R10_A5Cod_Area = new string[] {""} ;
         T000R10_A4IndicadoresCodigo = new string[] {""} ;
         T000R11_A54TONCPOHAFecha = new DateTime[] {DateTime.MinValue} ;
         T000R11_A55TONCPOHAMes = new short[1] ;
         T000R11_A56TONCPOHAAno = new short[1] ;
         T000R11_A5Cod_Area = new string[] {""} ;
         T000R11_A4IndicadoresCodigo = new string[] {""} ;
         T000R2_A54TONCPOHAFecha = new DateTime[] {DateTime.MinValue} ;
         T000R2_A55TONCPOHAMes = new short[1] ;
         T000R2_A56TONCPOHAAno = new short[1] ;
         T000R2_A170TONCPOHAhaproduc = new decimal[1] ;
         T000R2_A171TONCPOHAuse = new string[] {""} ;
         T000R2_A172TONCPOHAreg = new DateTime[] {DateTime.MinValue} ;
         T000R2_A173TONCPOHAhor = new string[] {""} ;
         T000R2_A5Cod_Area = new string[] {""} ;
         T000R2_A4IndicadoresCodigo = new string[] {""} ;
         T000R15_A54TONCPOHAFecha = new DateTime[] {DateTime.MinValue} ;
         T000R15_A55TONCPOHAMes = new short[1] ;
         T000R15_A56TONCPOHAAno = new short[1] ;
         T000R15_A5Cod_Area = new string[] {""} ;
         T000R15_A4IndicadoresCodigo = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T000R16_A5Cod_Area = new string[] {""} ;
         T000R17_A4IndicadoresCodigo = new string[] {""} ;
         ZZ54TONCPOHAFecha = DateTime.MinValue;
         ZZ5Cod_Area = "";
         ZZ4IndicadoresCodigo = "";
         ZZ171TONCPOHAuse = "";
         ZZ172TONCPOHAreg = DateTime.MinValue;
         ZZ173TONCPOHAhor = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.toncpoha__default(),
            new Object[][] {
                new Object[] {
               T000R2_A54TONCPOHAFecha, T000R2_A55TONCPOHAMes, T000R2_A56TONCPOHAAno, T000R2_A170TONCPOHAhaproduc, T000R2_A171TONCPOHAuse, T000R2_A172TONCPOHAreg, T000R2_A173TONCPOHAhor, T000R2_A5Cod_Area, T000R2_A4IndicadoresCodigo
               }
               , new Object[] {
               T000R3_A54TONCPOHAFecha, T000R3_A55TONCPOHAMes, T000R3_A56TONCPOHAAno, T000R3_A170TONCPOHAhaproduc, T000R3_A171TONCPOHAuse, T000R3_A172TONCPOHAreg, T000R3_A173TONCPOHAhor, T000R3_A5Cod_Area, T000R3_A4IndicadoresCodigo
               }
               , new Object[] {
               T000R4_A5Cod_Area
               }
               , new Object[] {
               T000R5_A4IndicadoresCodigo
               }
               , new Object[] {
               T000R6_A54TONCPOHAFecha, T000R6_A55TONCPOHAMes, T000R6_A56TONCPOHAAno, T000R6_A170TONCPOHAhaproduc, T000R6_A171TONCPOHAuse, T000R6_A172TONCPOHAreg, T000R6_A173TONCPOHAhor, T000R6_A5Cod_Area, T000R6_A4IndicadoresCodigo
               }
               , new Object[] {
               T000R7_A5Cod_Area
               }
               , new Object[] {
               T000R8_A4IndicadoresCodigo
               }
               , new Object[] {
               T000R9_A54TONCPOHAFecha, T000R9_A55TONCPOHAMes, T000R9_A56TONCPOHAAno, T000R9_A5Cod_Area, T000R9_A4IndicadoresCodigo
               }
               , new Object[] {
               T000R10_A54TONCPOHAFecha, T000R10_A55TONCPOHAMes, T000R10_A56TONCPOHAAno, T000R10_A5Cod_Area, T000R10_A4IndicadoresCodigo
               }
               , new Object[] {
               T000R11_A54TONCPOHAFecha, T000R11_A55TONCPOHAMes, T000R11_A56TONCPOHAAno, T000R11_A5Cod_Area, T000R11_A4IndicadoresCodigo
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000R15_A54TONCPOHAFecha, T000R15_A55TONCPOHAMes, T000R15_A56TONCPOHAAno, T000R15_A5Cod_Area, T000R15_A4IndicadoresCodigo
               }
               , new Object[] {
               T000R16_A5Cod_Area
               }
               , new Object[] {
               T000R17_A4IndicadoresCodigo
               }
            }
         );
      }

      private short Z55TONCPOHAMes ;
      private short Z56TONCPOHAAno ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A55TONCPOHAMes ;
      private short A56TONCPOHAAno ;
      private short GX_JID ;
      private short RcdFound28 ;
      private short nIsDirty_28 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ55TONCPOHAMes ;
      private short ZZ56TONCPOHAAno ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtTONCPOHAFecha_Enabled ;
      private int edtTONCPOHAMes_Enabled ;
      private int edtTONCPOHAAno_Enabled ;
      private int edtCod_Area_Enabled ;
      private int imgprompt_5_Visible ;
      private int edtIndicadoresCodigo_Enabled ;
      private int imgprompt_4_Visible ;
      private int edtTONCPOHAhaproduc_Enabled ;
      private int edtTONCPOHAuse_Enabled ;
      private int edtTONCPOHAreg_Enabled ;
      private int edtTONCPOHAhor_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private decimal Z170TONCPOHAhaproduc ;
      private decimal A170TONCPOHAhaproduc ;
      private decimal ZZ170TONCPOHAhaproduc ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTONCPOHAFecha_Internalname ;
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
      private string edtTONCPOHAFecha_Jsonclick ;
      private string edtTONCPOHAMes_Internalname ;
      private string edtTONCPOHAMes_Jsonclick ;
      private string edtTONCPOHAAno_Internalname ;
      private string edtTONCPOHAAno_Jsonclick ;
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
      private string edtTONCPOHAhaproduc_Internalname ;
      private string edtTONCPOHAhaproduc_Jsonclick ;
      private string edtTONCPOHAuse_Internalname ;
      private string edtTONCPOHAreg_Internalname ;
      private string edtTONCPOHAreg_Jsonclick ;
      private string edtTONCPOHAhor_Internalname ;
      private string edtTONCPOHAhor_Jsonclick ;
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
      private string sMode28 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z54TONCPOHAFecha ;
      private DateTime Z172TONCPOHAreg ;
      private DateTime A54TONCPOHAFecha ;
      private DateTime A172TONCPOHAreg ;
      private DateTime ZZ54TONCPOHAFecha ;
      private DateTime ZZ172TONCPOHAreg ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string Z5Cod_Area ;
      private string Z4IndicadoresCodigo ;
      private string Z171TONCPOHAuse ;
      private string Z173TONCPOHAhor ;
      private string A5Cod_Area ;
      private string A4IndicadoresCodigo ;
      private string A171TONCPOHAuse ;
      private string A173TONCPOHAhor ;
      private string ZZ5Cod_Area ;
      private string ZZ4IndicadoresCodigo ;
      private string ZZ171TONCPOHAuse ;
      private string ZZ173TONCPOHAhor ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] T000R6_A54TONCPOHAFecha ;
      private short[] T000R6_A55TONCPOHAMes ;
      private short[] T000R6_A56TONCPOHAAno ;
      private decimal[] T000R6_A170TONCPOHAhaproduc ;
      private string[] T000R6_A171TONCPOHAuse ;
      private DateTime[] T000R6_A172TONCPOHAreg ;
      private string[] T000R6_A173TONCPOHAhor ;
      private string[] T000R6_A5Cod_Area ;
      private string[] T000R6_A4IndicadoresCodigo ;
      private string[] T000R4_A5Cod_Area ;
      private string[] T000R5_A4IndicadoresCodigo ;
      private string[] T000R7_A5Cod_Area ;
      private string[] T000R8_A4IndicadoresCodigo ;
      private DateTime[] T000R9_A54TONCPOHAFecha ;
      private short[] T000R9_A55TONCPOHAMes ;
      private short[] T000R9_A56TONCPOHAAno ;
      private string[] T000R9_A5Cod_Area ;
      private string[] T000R9_A4IndicadoresCodigo ;
      private DateTime[] T000R3_A54TONCPOHAFecha ;
      private short[] T000R3_A55TONCPOHAMes ;
      private short[] T000R3_A56TONCPOHAAno ;
      private decimal[] T000R3_A170TONCPOHAhaproduc ;
      private string[] T000R3_A171TONCPOHAuse ;
      private DateTime[] T000R3_A172TONCPOHAreg ;
      private string[] T000R3_A173TONCPOHAhor ;
      private string[] T000R3_A5Cod_Area ;
      private string[] T000R3_A4IndicadoresCodigo ;
      private DateTime[] T000R10_A54TONCPOHAFecha ;
      private short[] T000R10_A55TONCPOHAMes ;
      private short[] T000R10_A56TONCPOHAAno ;
      private string[] T000R10_A5Cod_Area ;
      private string[] T000R10_A4IndicadoresCodigo ;
      private DateTime[] T000R11_A54TONCPOHAFecha ;
      private short[] T000R11_A55TONCPOHAMes ;
      private short[] T000R11_A56TONCPOHAAno ;
      private string[] T000R11_A5Cod_Area ;
      private string[] T000R11_A4IndicadoresCodigo ;
      private DateTime[] T000R2_A54TONCPOHAFecha ;
      private short[] T000R2_A55TONCPOHAMes ;
      private short[] T000R2_A56TONCPOHAAno ;
      private decimal[] T000R2_A170TONCPOHAhaproduc ;
      private string[] T000R2_A171TONCPOHAuse ;
      private DateTime[] T000R2_A172TONCPOHAreg ;
      private string[] T000R2_A173TONCPOHAhor ;
      private string[] T000R2_A5Cod_Area ;
      private string[] T000R2_A4IndicadoresCodigo ;
      private DateTime[] T000R15_A54TONCPOHAFecha ;
      private short[] T000R15_A55TONCPOHAMes ;
      private short[] T000R15_A56TONCPOHAAno ;
      private string[] T000R15_A5Cod_Area ;
      private string[] T000R15_A4IndicadoresCodigo ;
      private string[] T000R16_A5Cod_Area ;
      private string[] T000R17_A4IndicadoresCodigo ;
      private GXWebForm Form ;
   }

   public class toncpoha__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[10])
         ,new UpdateCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000R6;
          prmT000R6 = new Object[] {
          new ParDef("@TONCPOHAFecha",GXType.Date,8,0) ,
          new ParDef("@TONCPOHAMes",GXType.Int16,4,0) ,
          new ParDef("@TONCPOHAAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000R4;
          prmT000R4 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000R5;
          prmT000R5 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000R7;
          prmT000R7 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000R8;
          prmT000R8 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000R9;
          prmT000R9 = new Object[] {
          new ParDef("@TONCPOHAFecha",GXType.Date,8,0) ,
          new ParDef("@TONCPOHAMes",GXType.Int16,4,0) ,
          new ParDef("@TONCPOHAAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000R3;
          prmT000R3 = new Object[] {
          new ParDef("@TONCPOHAFecha",GXType.Date,8,0) ,
          new ParDef("@TONCPOHAMes",GXType.Int16,4,0) ,
          new ParDef("@TONCPOHAAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000R10;
          prmT000R10 = new Object[] {
          new ParDef("@TONCPOHAFecha",GXType.Date,8,0) ,
          new ParDef("@TONCPOHAMes",GXType.Int16,4,0) ,
          new ParDef("@TONCPOHAAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000R11;
          prmT000R11 = new Object[] {
          new ParDef("@TONCPOHAFecha",GXType.Date,8,0) ,
          new ParDef("@TONCPOHAMes",GXType.Int16,4,0) ,
          new ParDef("@TONCPOHAAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000R2;
          prmT000R2 = new Object[] {
          new ParDef("@TONCPOHAFecha",GXType.Date,8,0) ,
          new ParDef("@TONCPOHAMes",GXType.Int16,4,0) ,
          new ParDef("@TONCPOHAAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000R12;
          prmT000R12 = new Object[] {
          new ParDef("@TONCPOHAFecha",GXType.Date,8,0) ,
          new ParDef("@TONCPOHAMes",GXType.Int16,4,0) ,
          new ParDef("@TONCPOHAAno",GXType.Int16,4,0) ,
          new ParDef("@TONCPOHAhaproduc",GXType.Decimal,15,2) ,
          new ParDef("@TONCPOHAuse",GXType.NVarChar,200,0) ,
          new ParDef("@TONCPOHAreg",GXType.Date,8,0) ,
          new ParDef("@TONCPOHAhor",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000R13;
          prmT000R13 = new Object[] {
          new ParDef("@TONCPOHAhaproduc",GXType.Decimal,15,2) ,
          new ParDef("@TONCPOHAuse",GXType.NVarChar,200,0) ,
          new ParDef("@TONCPOHAreg",GXType.Date,8,0) ,
          new ParDef("@TONCPOHAhor",GXType.NVarChar,40,0) ,
          new ParDef("@TONCPOHAFecha",GXType.Date,8,0) ,
          new ParDef("@TONCPOHAMes",GXType.Int16,4,0) ,
          new ParDef("@TONCPOHAAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000R14;
          prmT000R14 = new Object[] {
          new ParDef("@TONCPOHAFecha",GXType.Date,8,0) ,
          new ParDef("@TONCPOHAMes",GXType.Int16,4,0) ,
          new ParDef("@TONCPOHAAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000R15;
          prmT000R15 = new Object[] {
          };
          Object[] prmT000R16;
          prmT000R16 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000R17;
          prmT000R17 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("T000R2", "SELECT [TONCPOHAFecha], [TONCPOHAMes], [TONCPOHAAno], [TONCPOHAhaproduc], [TONCPOHAuse], [TONCPOHAreg], [TONCPOHAhor], [Cod_Area], [IndicadoresCodigo] FROM [TONCPOHA] WITH (UPDLOCK) WHERE [TONCPOHAFecha] = @TONCPOHAFecha AND [TONCPOHAMes] = @TONCPOHAMes AND [TONCPOHAAno] = @TONCPOHAAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000R3", "SELECT [TONCPOHAFecha], [TONCPOHAMes], [TONCPOHAAno], [TONCPOHAhaproduc], [TONCPOHAuse], [TONCPOHAreg], [TONCPOHAhor], [Cod_Area], [IndicadoresCodigo] FROM [TONCPOHA] WHERE [TONCPOHAFecha] = @TONCPOHAFecha AND [TONCPOHAMes] = @TONCPOHAMes AND [TONCPOHAAno] = @TONCPOHAAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000R4", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000R5", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000R6", "SELECT TM1.[TONCPOHAFecha], TM1.[TONCPOHAMes], TM1.[TONCPOHAAno], TM1.[TONCPOHAhaproduc], TM1.[TONCPOHAuse], TM1.[TONCPOHAreg], TM1.[TONCPOHAhor], TM1.[Cod_Area], TM1.[IndicadoresCodigo] FROM [TONCPOHA] TM1 WHERE TM1.[TONCPOHAFecha] = @TONCPOHAFecha and TM1.[TONCPOHAMes] = @TONCPOHAMes and TM1.[TONCPOHAAno] = @TONCPOHAAno and TM1.[Cod_Area] = @Cod_Area and TM1.[IndicadoresCodigo] = @IndicadoresCodigo ORDER BY TM1.[TONCPOHAFecha], TM1.[TONCPOHAMes], TM1.[TONCPOHAAno], TM1.[Cod_Area], TM1.[IndicadoresCodigo]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000R6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000R7", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000R8", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000R9", "SELECT [TONCPOHAFecha], [TONCPOHAMes], [TONCPOHAAno], [Cod_Area], [IndicadoresCodigo] FROM [TONCPOHA] WHERE [TONCPOHAFecha] = @TONCPOHAFecha AND [TONCPOHAMes] = @TONCPOHAMes AND [TONCPOHAAno] = @TONCPOHAAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000R9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000R10", "SELECT TOP 1 [TONCPOHAFecha], [TONCPOHAMes], [TONCPOHAAno], [Cod_Area], [IndicadoresCodigo] FROM [TONCPOHA] WHERE ( [TONCPOHAFecha] > @TONCPOHAFecha or [TONCPOHAFecha] = @TONCPOHAFecha and [TONCPOHAMes] > @TONCPOHAMes or [TONCPOHAMes] = @TONCPOHAMes and [TONCPOHAFecha] = @TONCPOHAFecha and [TONCPOHAAno] > @TONCPOHAAno or [TONCPOHAAno] = @TONCPOHAAno and [TONCPOHAMes] = @TONCPOHAMes and [TONCPOHAFecha] = @TONCPOHAFecha and [Cod_Area] > @Cod_Area or [Cod_Area] = @Cod_Area and [TONCPOHAAno] = @TONCPOHAAno and [TONCPOHAMes] = @TONCPOHAMes and [TONCPOHAFecha] = @TONCPOHAFecha and [IndicadoresCodigo] > @IndicadoresCodigo) ORDER BY [TONCPOHAFecha], [TONCPOHAMes], [TONCPOHAAno], [Cod_Area], [IndicadoresCodigo]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000R10,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000R11", "SELECT TOP 1 [TONCPOHAFecha], [TONCPOHAMes], [TONCPOHAAno], [Cod_Area], [IndicadoresCodigo] FROM [TONCPOHA] WHERE ( [TONCPOHAFecha] < @TONCPOHAFecha or [TONCPOHAFecha] = @TONCPOHAFecha and [TONCPOHAMes] < @TONCPOHAMes or [TONCPOHAMes] = @TONCPOHAMes and [TONCPOHAFecha] = @TONCPOHAFecha and [TONCPOHAAno] < @TONCPOHAAno or [TONCPOHAAno] = @TONCPOHAAno and [TONCPOHAMes] = @TONCPOHAMes and [TONCPOHAFecha] = @TONCPOHAFecha and [Cod_Area] < @Cod_Area or [Cod_Area] = @Cod_Area and [TONCPOHAAno] = @TONCPOHAAno and [TONCPOHAMes] = @TONCPOHAMes and [TONCPOHAFecha] = @TONCPOHAFecha and [IndicadoresCodigo] < @IndicadoresCodigo) ORDER BY [TONCPOHAFecha] DESC, [TONCPOHAMes] DESC, [TONCPOHAAno] DESC, [Cod_Area] DESC, [IndicadoresCodigo] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000R11,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000R12", "INSERT INTO [TONCPOHA]([TONCPOHAFecha], [TONCPOHAMes], [TONCPOHAAno], [TONCPOHAhaproduc], [TONCPOHAuse], [TONCPOHAreg], [TONCPOHAhor], [Cod_Area], [IndicadoresCodigo]) VALUES(@TONCPOHAFecha, @TONCPOHAMes, @TONCPOHAAno, @TONCPOHAhaproduc, @TONCPOHAuse, @TONCPOHAreg, @TONCPOHAhor, @Cod_Area, @IndicadoresCodigo)", GxErrorMask.GX_NOMASK,prmT000R12)
             ,new CursorDef("T000R13", "UPDATE [TONCPOHA] SET [TONCPOHAhaproduc]=@TONCPOHAhaproduc, [TONCPOHAuse]=@TONCPOHAuse, [TONCPOHAreg]=@TONCPOHAreg, [TONCPOHAhor]=@TONCPOHAhor  WHERE [TONCPOHAFecha] = @TONCPOHAFecha AND [TONCPOHAMes] = @TONCPOHAMes AND [TONCPOHAAno] = @TONCPOHAAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo", GxErrorMask.GX_NOMASK,prmT000R13)
             ,new CursorDef("T000R14", "DELETE FROM [TONCPOHA]  WHERE [TONCPOHAFecha] = @TONCPOHAFecha AND [TONCPOHAMes] = @TONCPOHAMes AND [TONCPOHAAno] = @TONCPOHAAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo", GxErrorMask.GX_NOMASK,prmT000R14)
             ,new CursorDef("T000R15", "SELECT [TONCPOHAFecha], [TONCPOHAMes], [TONCPOHAAno], [Cod_Area], [IndicadoresCodigo] FROM [TONCPOHA] ORDER BY [TONCPOHAFecha], [TONCPOHAMes], [TONCPOHAAno], [Cod_Area], [IndicadoresCodigo]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000R15,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000R16", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R16,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000R17", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R17,1, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 4 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 7 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 8 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 9 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 13 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 14 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 15 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
       }
    }

 }

}
