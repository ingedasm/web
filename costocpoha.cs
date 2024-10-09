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
   public class costocpoha : GXDataArea
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
            Form.Meta.addItem("description", "COSTOCPOHA", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCOSTOCPOHAFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("IndicadroresPalmas", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public costocpoha( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("IndicadroresPalmas", true);
      }

      public costocpoha( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "COSTOCPOHA", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_COSTOCPOHA.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSTOCPOHA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSTOCPOHA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSTOCPOHA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSTOCPOHA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 4, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx00i0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"COSTOCPOHAFECHA"+"'), id:'"+"COSTOCPOHAFECHA"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"COSTOCPOHAANO"+"'), id:'"+"COSTOCPOHAANO"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"COSTOCPOHAMES"+"'), id:'"+"COSTOCPOHAMES"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"COD_AREA"+"'), id:'"+"COD_AREA"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"INDICADORESCODIGO"+"'), id:'"+"INDICADORESCODIGO"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_COSTOCPOHA.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCOSTOCPOHAFecha_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCOSTOCPOHAFecha_Internalname, "COSTOCPOHAFecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCOSTOCPOHAFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCOSTOCPOHAFecha_Internalname, context.localUtil.Format(A36COSTOCPOHAFecha, "99/99/99"), context.localUtil.Format( A36COSTOCPOHAFecha, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCOSTOCPOHAFecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCOSTOCPOHAFecha_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_COSTOCPOHA.htm");
         GxWebStd.gx_bitmap( context, edtCOSTOCPOHAFecha_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCOSTOCPOHAFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_COSTOCPOHA.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCOSTOCPOHAAno_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCOSTOCPOHAAno_Internalname, "COSTOCPOHAAno", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCOSTOCPOHAAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A37COSTOCPOHAAno), 4, 0, ",", "")), StringUtil.LTrim( ((edtCOSTOCPOHAAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A37COSTOCPOHAAno), "ZZZ9") : context.localUtil.Format( (decimal)(A37COSTOCPOHAAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCOSTOCPOHAAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCOSTOCPOHAAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_COSTOCPOHA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCOSTOCPOHAMes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCOSTOCPOHAMes_Internalname, "COSTOCPOHAMes", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCOSTOCPOHAMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A38COSTOCPOHAMes), 4, 0, ",", "")), StringUtil.LTrim( ((edtCOSTOCPOHAMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A38COSTOCPOHAMes), "ZZZ9") : context.localUtil.Format( (decimal)(A38COSTOCPOHAMes), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCOSTOCPOHAMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCOSTOCPOHAMes_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_COSTOCPOHA.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCod_Area_Internalname, A5Cod_Area, StringUtil.RTrim( context.localUtil.Format( A5Cod_Area, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCod_Area_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCod_Area_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_COSTOCPOHA.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_5_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_5_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_5_Internalname, sImgUrl, imgprompt_5_Link, "", "", context.GetTheme( ), imgprompt_5_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_COSTOCPOHA.htm");
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
         GxWebStd.gx_single_line_edit( context, edtIndicadoresCodigo_Internalname, A4IndicadoresCodigo, StringUtil.RTrim( context.localUtil.Format( A4IndicadoresCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIndicadoresCodigo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIndicadoresCodigo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_COSTOCPOHA.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_4_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_4_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_4_Internalname, sImgUrl, imgprompt_4_Link, "", "", context.GetTheme( ), imgprompt_4_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_COSTOCPOHA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCOSTOCPOHAValor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCOSTOCPOHAValor_Internalname, "COSTOCPOHAValor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCOSTOCPOHAValor_Internalname, StringUtil.LTrim( StringUtil.NToC( A150COSTOCPOHAValor, 14, 2, ",", "")), StringUtil.LTrim( ((edtCOSTOCPOHAValor_Enabled!=0) ? context.localUtil.Format( A150COSTOCPOHAValor, "ZZZZZZZZZZ9.99") : context.localUtil.Format( A150COSTOCPOHAValor, "ZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCOSTOCPOHAValor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCOSTOCPOHAValor_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_COSTOCPOHA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCOSTOCPOHAUser_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCOSTOCPOHAUser_Internalname, "COSTOCPOHAUser", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtCOSTOCPOHAUser_Internalname, A155COSTOCPOHAUser, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", 0, 1, edtCOSTOCPOHAUser_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "240", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_COSTOCPOHA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCOSTOCPOHAReg_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCOSTOCPOHAReg_Internalname, "COSTOCPOHAReg", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCOSTOCPOHAReg_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCOSTOCPOHAReg_Internalname, context.localUtil.Format(A156COSTOCPOHAReg, "99/99/99"), context.localUtil.Format( A156COSTOCPOHAReg, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCOSTOCPOHAReg_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCOSTOCPOHAReg_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_COSTOCPOHA.htm");
         GxWebStd.gx_bitmap( context, edtCOSTOCPOHAReg_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCOSTOCPOHAReg_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_COSTOCPOHA.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCOSTOCPOHAHor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCOSTOCPOHAHor_Internalname, "COSTOCPOHAHor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCOSTOCPOHAHor_Internalname, A157COSTOCPOHAHor, StringUtil.RTrim( context.localUtil.Format( A157COSTOCPOHAHor, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCOSTOCPOHAHor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCOSTOCPOHAHor_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_COSTOCPOHA.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSTOCPOHA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSTOCPOHA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSTOCPOHA.htm");
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
            Z36COSTOCPOHAFecha = context.localUtil.CToD( cgiGet( "Z36COSTOCPOHAFecha"), 0);
            Z37COSTOCPOHAAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z37COSTOCPOHAAno"), ",", "."), 18, MidpointRounding.ToEven));
            Z38COSTOCPOHAMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z38COSTOCPOHAMes"), ",", "."), 18, MidpointRounding.ToEven));
            Z5Cod_Area = cgiGet( "Z5Cod_Area");
            Z4IndicadoresCodigo = cgiGet( "Z4IndicadoresCodigo");
            Z150COSTOCPOHAValor = context.localUtil.CToN( cgiGet( "Z150COSTOCPOHAValor"), ",", ".");
            Z155COSTOCPOHAUser = cgiGet( "Z155COSTOCPOHAUser");
            Z156COSTOCPOHAReg = context.localUtil.CToD( cgiGet( "Z156COSTOCPOHAReg"), 0);
            Z157COSTOCPOHAHor = cgiGet( "Z157COSTOCPOHAHor");
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( context.localUtil.VCDate( cgiGet( edtCOSTOCPOHAFecha_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"COSTOCPOHAFecha"}), 1, "COSTOCPOHAFECHA");
               AnyError = 1;
               GX_FocusControl = edtCOSTOCPOHAFecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A36COSTOCPOHAFecha = DateTime.MinValue;
               AssignAttri("", false, "A36COSTOCPOHAFecha", context.localUtil.Format(A36COSTOCPOHAFecha, "99/99/99"));
            }
            else
            {
               A36COSTOCPOHAFecha = context.localUtil.CToD( cgiGet( edtCOSTOCPOHAFecha_Internalname), 2);
               AssignAttri("", false, "A36COSTOCPOHAFecha", context.localUtil.Format(A36COSTOCPOHAFecha, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCOSTOCPOHAAno_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCOSTOCPOHAAno_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COSTOCPOHAANO");
               AnyError = 1;
               GX_FocusControl = edtCOSTOCPOHAAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A37COSTOCPOHAAno = 0;
               AssignAttri("", false, "A37COSTOCPOHAAno", StringUtil.LTrimStr( (decimal)(A37COSTOCPOHAAno), 4, 0));
            }
            else
            {
               A37COSTOCPOHAAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCOSTOCPOHAAno_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A37COSTOCPOHAAno", StringUtil.LTrimStr( (decimal)(A37COSTOCPOHAAno), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCOSTOCPOHAMes_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCOSTOCPOHAMes_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COSTOCPOHAMES");
               AnyError = 1;
               GX_FocusControl = edtCOSTOCPOHAMes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A38COSTOCPOHAMes = 0;
               AssignAttri("", false, "A38COSTOCPOHAMes", StringUtil.LTrimStr( (decimal)(A38COSTOCPOHAMes), 4, 0));
            }
            else
            {
               A38COSTOCPOHAMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCOSTOCPOHAMes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A38COSTOCPOHAMes", StringUtil.LTrimStr( (decimal)(A38COSTOCPOHAMes), 4, 0));
            }
            A5Cod_Area = cgiGet( edtCod_Area_Internalname);
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = cgiGet( edtIndicadoresCodigo_Internalname);
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCOSTOCPOHAValor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCOSTOCPOHAValor_Internalname), ",", ".") > 99999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COSTOCPOHAVALOR");
               AnyError = 1;
               GX_FocusControl = edtCOSTOCPOHAValor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A150COSTOCPOHAValor = 0;
               AssignAttri("", false, "A150COSTOCPOHAValor", StringUtil.LTrimStr( A150COSTOCPOHAValor, 14, 2));
            }
            else
            {
               A150COSTOCPOHAValor = context.localUtil.CToN( cgiGet( edtCOSTOCPOHAValor_Internalname), ",", ".");
               AssignAttri("", false, "A150COSTOCPOHAValor", StringUtil.LTrimStr( A150COSTOCPOHAValor, 14, 2));
            }
            A155COSTOCPOHAUser = cgiGet( edtCOSTOCPOHAUser_Internalname);
            AssignAttri("", false, "A155COSTOCPOHAUser", A155COSTOCPOHAUser);
            if ( context.localUtil.VCDate( cgiGet( edtCOSTOCPOHAReg_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"COSTOCPOHAReg"}), 1, "COSTOCPOHAREG");
               AnyError = 1;
               GX_FocusControl = edtCOSTOCPOHAReg_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A156COSTOCPOHAReg = DateTime.MinValue;
               AssignAttri("", false, "A156COSTOCPOHAReg", context.localUtil.Format(A156COSTOCPOHAReg, "99/99/99"));
            }
            else
            {
               A156COSTOCPOHAReg = context.localUtil.CToD( cgiGet( edtCOSTOCPOHAReg_Internalname), 2);
               AssignAttri("", false, "A156COSTOCPOHAReg", context.localUtil.Format(A156COSTOCPOHAReg, "99/99/99"));
            }
            A157COSTOCPOHAHor = cgiGet( edtCOSTOCPOHAHor_Internalname);
            AssignAttri("", false, "A157COSTOCPOHAHor", A157COSTOCPOHAHor);
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
               A36COSTOCPOHAFecha = context.localUtil.ParseDateParm( GetPar( "COSTOCPOHAFecha"));
               AssignAttri("", false, "A36COSTOCPOHAFecha", context.localUtil.Format(A36COSTOCPOHAFecha, "99/99/99"));
               A37COSTOCPOHAAno = (short)(Math.Round(NumberUtil.Val( GetPar( "COSTOCPOHAAno"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A37COSTOCPOHAAno", StringUtil.LTrimStr( (decimal)(A37COSTOCPOHAAno), 4, 0));
               A38COSTOCPOHAMes = (short)(Math.Round(NumberUtil.Val( GetPar( "COSTOCPOHAMes"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A38COSTOCPOHAMes", StringUtil.LTrimStr( (decimal)(A38COSTOCPOHAMes), 4, 0));
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
               InitAll0H18( ) ;
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
         DisableAttributes0H18( ) ;
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

      protected void ResetCaption0H0( )
      {
      }

      protected void ZM0H18( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z150COSTOCPOHAValor = T000H3_A150COSTOCPOHAValor[0];
               Z155COSTOCPOHAUser = T000H3_A155COSTOCPOHAUser[0];
               Z156COSTOCPOHAReg = T000H3_A156COSTOCPOHAReg[0];
               Z157COSTOCPOHAHor = T000H3_A157COSTOCPOHAHor[0];
            }
            else
            {
               Z150COSTOCPOHAValor = A150COSTOCPOHAValor;
               Z155COSTOCPOHAUser = A155COSTOCPOHAUser;
               Z156COSTOCPOHAReg = A156COSTOCPOHAReg;
               Z157COSTOCPOHAHor = A157COSTOCPOHAHor;
            }
         }
         if ( GX_JID == -3 )
         {
            Z36COSTOCPOHAFecha = A36COSTOCPOHAFecha;
            Z37COSTOCPOHAAno = A37COSTOCPOHAAno;
            Z38COSTOCPOHAMes = A38COSTOCPOHAMes;
            Z150COSTOCPOHAValor = A150COSTOCPOHAValor;
            Z155COSTOCPOHAUser = A155COSTOCPOHAUser;
            Z156COSTOCPOHAReg = A156COSTOCPOHAReg;
            Z157COSTOCPOHAHor = A157COSTOCPOHAHor;
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

      protected void Load0H18( )
      {
         /* Using cursor T000H6 */
         pr_default.execute(4, new Object[] {A36COSTOCPOHAFecha, A37COSTOCPOHAAno, A38COSTOCPOHAMes, A5Cod_Area, A4IndicadoresCodigo});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound18 = 1;
            A150COSTOCPOHAValor = T000H6_A150COSTOCPOHAValor[0];
            AssignAttri("", false, "A150COSTOCPOHAValor", StringUtil.LTrimStr( A150COSTOCPOHAValor, 14, 2));
            A155COSTOCPOHAUser = T000H6_A155COSTOCPOHAUser[0];
            AssignAttri("", false, "A155COSTOCPOHAUser", A155COSTOCPOHAUser);
            A156COSTOCPOHAReg = T000H6_A156COSTOCPOHAReg[0];
            AssignAttri("", false, "A156COSTOCPOHAReg", context.localUtil.Format(A156COSTOCPOHAReg, "99/99/99"));
            A157COSTOCPOHAHor = T000H6_A157COSTOCPOHAHor[0];
            AssignAttri("", false, "A157COSTOCPOHAHor", A157COSTOCPOHAHor);
            ZM0H18( -3) ;
         }
         pr_default.close(4);
         OnLoadActions0H18( ) ;
      }

      protected void OnLoadActions0H18( )
      {
      }

      protected void CheckExtendedTable0H18( )
      {
         nIsDirty_18 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A36COSTOCPOHAFecha) || ( DateTimeUtil.ResetTime ( A36COSTOCPOHAFecha ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo COSTOCPOHAFecha fuera de rango", "OutOfRange", 1, "COSTOCPOHAFECHA");
            AnyError = 1;
            GX_FocusControl = edtCOSTOCPOHAFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000H4 */
         pr_default.execute(2, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T000H5 */
         pr_default.execute(3, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         if ( ! ( (DateTime.MinValue==A156COSTOCPOHAReg) || ( DateTimeUtil.ResetTime ( A156COSTOCPOHAReg ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo COSTOCPOHAReg fuera de rango", "OutOfRange", 1, "COSTOCPOHAREG");
            AnyError = 1;
            GX_FocusControl = edtCOSTOCPOHAReg_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0H18( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_4( string A5Cod_Area )
      {
         /* Using cursor T000H7 */
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
         /* Using cursor T000H8 */
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

      protected void GetKey0H18( )
      {
         /* Using cursor T000H9 */
         pr_default.execute(7, new Object[] {A36COSTOCPOHAFecha, A37COSTOCPOHAAno, A38COSTOCPOHAMes, A5Cod_Area, A4IndicadoresCodigo});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound18 = 1;
         }
         else
         {
            RcdFound18 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000H3 */
         pr_default.execute(1, new Object[] {A36COSTOCPOHAFecha, A37COSTOCPOHAAno, A38COSTOCPOHAMes, A5Cod_Area, A4IndicadoresCodigo});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0H18( 3) ;
            RcdFound18 = 1;
            A36COSTOCPOHAFecha = T000H3_A36COSTOCPOHAFecha[0];
            AssignAttri("", false, "A36COSTOCPOHAFecha", context.localUtil.Format(A36COSTOCPOHAFecha, "99/99/99"));
            A37COSTOCPOHAAno = T000H3_A37COSTOCPOHAAno[0];
            AssignAttri("", false, "A37COSTOCPOHAAno", StringUtil.LTrimStr( (decimal)(A37COSTOCPOHAAno), 4, 0));
            A38COSTOCPOHAMes = T000H3_A38COSTOCPOHAMes[0];
            AssignAttri("", false, "A38COSTOCPOHAMes", StringUtil.LTrimStr( (decimal)(A38COSTOCPOHAMes), 4, 0));
            A150COSTOCPOHAValor = T000H3_A150COSTOCPOHAValor[0];
            AssignAttri("", false, "A150COSTOCPOHAValor", StringUtil.LTrimStr( A150COSTOCPOHAValor, 14, 2));
            A155COSTOCPOHAUser = T000H3_A155COSTOCPOHAUser[0];
            AssignAttri("", false, "A155COSTOCPOHAUser", A155COSTOCPOHAUser);
            A156COSTOCPOHAReg = T000H3_A156COSTOCPOHAReg[0];
            AssignAttri("", false, "A156COSTOCPOHAReg", context.localUtil.Format(A156COSTOCPOHAReg, "99/99/99"));
            A157COSTOCPOHAHor = T000H3_A157COSTOCPOHAHor[0];
            AssignAttri("", false, "A157COSTOCPOHAHor", A157COSTOCPOHAHor);
            A5Cod_Area = T000H3_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = T000H3_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            Z36COSTOCPOHAFecha = A36COSTOCPOHAFecha;
            Z37COSTOCPOHAAno = A37COSTOCPOHAAno;
            Z38COSTOCPOHAMes = A38COSTOCPOHAMes;
            Z5Cod_Area = A5Cod_Area;
            Z4IndicadoresCodigo = A4IndicadoresCodigo;
            sMode18 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0H18( ) ;
            if ( AnyError == 1 )
            {
               RcdFound18 = 0;
               InitializeNonKey0H18( ) ;
            }
            Gx_mode = sMode18;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound18 = 0;
            InitializeNonKey0H18( ) ;
            sMode18 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode18;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0H18( ) ;
         if ( RcdFound18 == 0 )
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
         RcdFound18 = 0;
         /* Using cursor T000H10 */
         pr_default.execute(8, new Object[] {A36COSTOCPOHAFecha, A37COSTOCPOHAAno, A38COSTOCPOHAMes, A5Cod_Area, A4IndicadoresCodigo});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( DateTimeUtil.ResetTime ( T000H10_A36COSTOCPOHAFecha[0] ) < DateTimeUtil.ResetTime ( A36COSTOCPOHAFecha ) ) || ( DateTimeUtil.ResetTime ( T000H10_A36COSTOCPOHAFecha[0] ) == DateTimeUtil.ResetTime ( A36COSTOCPOHAFecha ) ) && ( T000H10_A37COSTOCPOHAAno[0] < A37COSTOCPOHAAno ) || ( T000H10_A37COSTOCPOHAAno[0] == A37COSTOCPOHAAno ) && ( DateTimeUtil.ResetTime ( T000H10_A36COSTOCPOHAFecha[0] ) == DateTimeUtil.ResetTime ( A36COSTOCPOHAFecha ) ) && ( T000H10_A38COSTOCPOHAMes[0] < A38COSTOCPOHAMes ) || ( T000H10_A38COSTOCPOHAMes[0] == A38COSTOCPOHAMes ) && ( T000H10_A37COSTOCPOHAAno[0] == A37COSTOCPOHAAno ) && ( DateTimeUtil.ResetTime ( T000H10_A36COSTOCPOHAFecha[0] ) == DateTimeUtil.ResetTime ( A36COSTOCPOHAFecha ) ) && ( StringUtil.StrCmp(T000H10_A5Cod_Area[0], A5Cod_Area) < 0 ) || ( StringUtil.StrCmp(T000H10_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000H10_A38COSTOCPOHAMes[0] == A38COSTOCPOHAMes ) && ( T000H10_A37COSTOCPOHAAno[0] == A37COSTOCPOHAAno ) && ( DateTimeUtil.ResetTime ( T000H10_A36COSTOCPOHAFecha[0] ) == DateTimeUtil.ResetTime ( A36COSTOCPOHAFecha ) ) && ( StringUtil.StrCmp(T000H10_A4IndicadoresCodigo[0], A4IndicadoresCodigo) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( DateTimeUtil.ResetTime ( T000H10_A36COSTOCPOHAFecha[0] ) > DateTimeUtil.ResetTime ( A36COSTOCPOHAFecha ) ) || ( DateTimeUtil.ResetTime ( T000H10_A36COSTOCPOHAFecha[0] ) == DateTimeUtil.ResetTime ( A36COSTOCPOHAFecha ) ) && ( T000H10_A37COSTOCPOHAAno[0] > A37COSTOCPOHAAno ) || ( T000H10_A37COSTOCPOHAAno[0] == A37COSTOCPOHAAno ) && ( DateTimeUtil.ResetTime ( T000H10_A36COSTOCPOHAFecha[0] ) == DateTimeUtil.ResetTime ( A36COSTOCPOHAFecha ) ) && ( T000H10_A38COSTOCPOHAMes[0] > A38COSTOCPOHAMes ) || ( T000H10_A38COSTOCPOHAMes[0] == A38COSTOCPOHAMes ) && ( T000H10_A37COSTOCPOHAAno[0] == A37COSTOCPOHAAno ) && ( DateTimeUtil.ResetTime ( T000H10_A36COSTOCPOHAFecha[0] ) == DateTimeUtil.ResetTime ( A36COSTOCPOHAFecha ) ) && ( StringUtil.StrCmp(T000H10_A5Cod_Area[0], A5Cod_Area) > 0 ) || ( StringUtil.StrCmp(T000H10_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000H10_A38COSTOCPOHAMes[0] == A38COSTOCPOHAMes ) && ( T000H10_A37COSTOCPOHAAno[0] == A37COSTOCPOHAAno ) && ( DateTimeUtil.ResetTime ( T000H10_A36COSTOCPOHAFecha[0] ) == DateTimeUtil.ResetTime ( A36COSTOCPOHAFecha ) ) && ( StringUtil.StrCmp(T000H10_A4IndicadoresCodigo[0], A4IndicadoresCodigo) > 0 ) ) )
            {
               A36COSTOCPOHAFecha = T000H10_A36COSTOCPOHAFecha[0];
               AssignAttri("", false, "A36COSTOCPOHAFecha", context.localUtil.Format(A36COSTOCPOHAFecha, "99/99/99"));
               A37COSTOCPOHAAno = T000H10_A37COSTOCPOHAAno[0];
               AssignAttri("", false, "A37COSTOCPOHAAno", StringUtil.LTrimStr( (decimal)(A37COSTOCPOHAAno), 4, 0));
               A38COSTOCPOHAMes = T000H10_A38COSTOCPOHAMes[0];
               AssignAttri("", false, "A38COSTOCPOHAMes", StringUtil.LTrimStr( (decimal)(A38COSTOCPOHAMes), 4, 0));
               A5Cod_Area = T000H10_A5Cod_Area[0];
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               A4IndicadoresCodigo = T000H10_A4IndicadoresCodigo[0];
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               RcdFound18 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound18 = 0;
         /* Using cursor T000H11 */
         pr_default.execute(9, new Object[] {A36COSTOCPOHAFecha, A37COSTOCPOHAAno, A38COSTOCPOHAMes, A5Cod_Area, A4IndicadoresCodigo});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( DateTimeUtil.ResetTime ( T000H11_A36COSTOCPOHAFecha[0] ) > DateTimeUtil.ResetTime ( A36COSTOCPOHAFecha ) ) || ( DateTimeUtil.ResetTime ( T000H11_A36COSTOCPOHAFecha[0] ) == DateTimeUtil.ResetTime ( A36COSTOCPOHAFecha ) ) && ( T000H11_A37COSTOCPOHAAno[0] > A37COSTOCPOHAAno ) || ( T000H11_A37COSTOCPOHAAno[0] == A37COSTOCPOHAAno ) && ( DateTimeUtil.ResetTime ( T000H11_A36COSTOCPOHAFecha[0] ) == DateTimeUtil.ResetTime ( A36COSTOCPOHAFecha ) ) && ( T000H11_A38COSTOCPOHAMes[0] > A38COSTOCPOHAMes ) || ( T000H11_A38COSTOCPOHAMes[0] == A38COSTOCPOHAMes ) && ( T000H11_A37COSTOCPOHAAno[0] == A37COSTOCPOHAAno ) && ( DateTimeUtil.ResetTime ( T000H11_A36COSTOCPOHAFecha[0] ) == DateTimeUtil.ResetTime ( A36COSTOCPOHAFecha ) ) && ( StringUtil.StrCmp(T000H11_A5Cod_Area[0], A5Cod_Area) > 0 ) || ( StringUtil.StrCmp(T000H11_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000H11_A38COSTOCPOHAMes[0] == A38COSTOCPOHAMes ) && ( T000H11_A37COSTOCPOHAAno[0] == A37COSTOCPOHAAno ) && ( DateTimeUtil.ResetTime ( T000H11_A36COSTOCPOHAFecha[0] ) == DateTimeUtil.ResetTime ( A36COSTOCPOHAFecha ) ) && ( StringUtil.StrCmp(T000H11_A4IndicadoresCodigo[0], A4IndicadoresCodigo) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( DateTimeUtil.ResetTime ( T000H11_A36COSTOCPOHAFecha[0] ) < DateTimeUtil.ResetTime ( A36COSTOCPOHAFecha ) ) || ( DateTimeUtil.ResetTime ( T000H11_A36COSTOCPOHAFecha[0] ) == DateTimeUtil.ResetTime ( A36COSTOCPOHAFecha ) ) && ( T000H11_A37COSTOCPOHAAno[0] < A37COSTOCPOHAAno ) || ( T000H11_A37COSTOCPOHAAno[0] == A37COSTOCPOHAAno ) && ( DateTimeUtil.ResetTime ( T000H11_A36COSTOCPOHAFecha[0] ) == DateTimeUtil.ResetTime ( A36COSTOCPOHAFecha ) ) && ( T000H11_A38COSTOCPOHAMes[0] < A38COSTOCPOHAMes ) || ( T000H11_A38COSTOCPOHAMes[0] == A38COSTOCPOHAMes ) && ( T000H11_A37COSTOCPOHAAno[0] == A37COSTOCPOHAAno ) && ( DateTimeUtil.ResetTime ( T000H11_A36COSTOCPOHAFecha[0] ) == DateTimeUtil.ResetTime ( A36COSTOCPOHAFecha ) ) && ( StringUtil.StrCmp(T000H11_A5Cod_Area[0], A5Cod_Area) < 0 ) || ( StringUtil.StrCmp(T000H11_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000H11_A38COSTOCPOHAMes[0] == A38COSTOCPOHAMes ) && ( T000H11_A37COSTOCPOHAAno[0] == A37COSTOCPOHAAno ) && ( DateTimeUtil.ResetTime ( T000H11_A36COSTOCPOHAFecha[0] ) == DateTimeUtil.ResetTime ( A36COSTOCPOHAFecha ) ) && ( StringUtil.StrCmp(T000H11_A4IndicadoresCodigo[0], A4IndicadoresCodigo) < 0 ) ) )
            {
               A36COSTOCPOHAFecha = T000H11_A36COSTOCPOHAFecha[0];
               AssignAttri("", false, "A36COSTOCPOHAFecha", context.localUtil.Format(A36COSTOCPOHAFecha, "99/99/99"));
               A37COSTOCPOHAAno = T000H11_A37COSTOCPOHAAno[0];
               AssignAttri("", false, "A37COSTOCPOHAAno", StringUtil.LTrimStr( (decimal)(A37COSTOCPOHAAno), 4, 0));
               A38COSTOCPOHAMes = T000H11_A38COSTOCPOHAMes[0];
               AssignAttri("", false, "A38COSTOCPOHAMes", StringUtil.LTrimStr( (decimal)(A38COSTOCPOHAMes), 4, 0));
               A5Cod_Area = T000H11_A5Cod_Area[0];
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               A4IndicadoresCodigo = T000H11_A4IndicadoresCodigo[0];
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               RcdFound18 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0H18( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCOSTOCPOHAFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0H18( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound18 == 1 )
            {
               if ( ( DateTimeUtil.ResetTime ( A36COSTOCPOHAFecha ) != DateTimeUtil.ResetTime ( Z36COSTOCPOHAFecha ) ) || ( A37COSTOCPOHAAno != Z37COSTOCPOHAAno ) || ( A38COSTOCPOHAMes != Z38COSTOCPOHAMes ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) )
               {
                  A36COSTOCPOHAFecha = Z36COSTOCPOHAFecha;
                  AssignAttri("", false, "A36COSTOCPOHAFecha", context.localUtil.Format(A36COSTOCPOHAFecha, "99/99/99"));
                  A37COSTOCPOHAAno = Z37COSTOCPOHAAno;
                  AssignAttri("", false, "A37COSTOCPOHAAno", StringUtil.LTrimStr( (decimal)(A37COSTOCPOHAAno), 4, 0));
                  A38COSTOCPOHAMes = Z38COSTOCPOHAMes;
                  AssignAttri("", false, "A38COSTOCPOHAMes", StringUtil.LTrimStr( (decimal)(A38COSTOCPOHAMes), 4, 0));
                  A5Cod_Area = Z5Cod_Area;
                  AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
                  A4IndicadoresCodigo = Z4IndicadoresCodigo;
                  AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "COSTOCPOHAFECHA");
                  AnyError = 1;
                  GX_FocusControl = edtCOSTOCPOHAFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCOSTOCPOHAFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0H18( ) ;
                  GX_FocusControl = edtCOSTOCPOHAFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( DateTimeUtil.ResetTime ( A36COSTOCPOHAFecha ) != DateTimeUtil.ResetTime ( Z36COSTOCPOHAFecha ) ) || ( A37COSTOCPOHAAno != Z37COSTOCPOHAAno ) || ( A38COSTOCPOHAMes != Z38COSTOCPOHAMes ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtCOSTOCPOHAFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0H18( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "COSTOCPOHAFECHA");
                     AnyError = 1;
                     GX_FocusControl = edtCOSTOCPOHAFecha_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtCOSTOCPOHAFecha_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0H18( ) ;
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
         if ( ( DateTimeUtil.ResetTime ( A36COSTOCPOHAFecha ) != DateTimeUtil.ResetTime ( Z36COSTOCPOHAFecha ) ) || ( A37COSTOCPOHAAno != Z37COSTOCPOHAAno ) || ( A38COSTOCPOHAMes != Z38COSTOCPOHAMes ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) )
         {
            A36COSTOCPOHAFecha = Z36COSTOCPOHAFecha;
            AssignAttri("", false, "A36COSTOCPOHAFecha", context.localUtil.Format(A36COSTOCPOHAFecha, "99/99/99"));
            A37COSTOCPOHAAno = Z37COSTOCPOHAAno;
            AssignAttri("", false, "A37COSTOCPOHAAno", StringUtil.LTrimStr( (decimal)(A37COSTOCPOHAAno), 4, 0));
            A38COSTOCPOHAMes = Z38COSTOCPOHAMes;
            AssignAttri("", false, "A38COSTOCPOHAMes", StringUtil.LTrimStr( (decimal)(A38COSTOCPOHAMes), 4, 0));
            A5Cod_Area = Z5Cod_Area;
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = Z4IndicadoresCodigo;
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "COSTOCPOHAFECHA");
            AnyError = 1;
            GX_FocusControl = edtCOSTOCPOHAFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCOSTOCPOHAFecha_Internalname;
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
         if ( RcdFound18 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "COSTOCPOHAFECHA");
            AnyError = 1;
            GX_FocusControl = edtCOSTOCPOHAFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtCOSTOCPOHAValor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0H18( ) ;
         if ( RcdFound18 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCOSTOCPOHAValor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0H18( ) ;
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
         if ( RcdFound18 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCOSTOCPOHAValor_Internalname;
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
         if ( RcdFound18 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCOSTOCPOHAValor_Internalname;
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
         ScanStart0H18( ) ;
         if ( RcdFound18 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound18 != 0 )
            {
               ScanNext0H18( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCOSTOCPOHAValor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0H18( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0H18( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000H2 */
            pr_default.execute(0, new Object[] {A36COSTOCPOHAFecha, A37COSTOCPOHAAno, A38COSTOCPOHAMes, A5Cod_Area, A4IndicadoresCodigo});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"COSTOCPOHA"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z150COSTOCPOHAValor != T000H2_A150COSTOCPOHAValor[0] ) || ( StringUtil.StrCmp(Z155COSTOCPOHAUser, T000H2_A155COSTOCPOHAUser[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z156COSTOCPOHAReg ) != DateTimeUtil.ResetTime ( T000H2_A156COSTOCPOHAReg[0] ) ) || ( StringUtil.StrCmp(Z157COSTOCPOHAHor, T000H2_A157COSTOCPOHAHor[0]) != 0 ) )
            {
               if ( Z150COSTOCPOHAValor != T000H2_A150COSTOCPOHAValor[0] )
               {
                  GXUtil.WriteLog("costocpoha:[seudo value changed for attri]"+"COSTOCPOHAValor");
                  GXUtil.WriteLogRaw("Old: ",Z150COSTOCPOHAValor);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A150COSTOCPOHAValor[0]);
               }
               if ( StringUtil.StrCmp(Z155COSTOCPOHAUser, T000H2_A155COSTOCPOHAUser[0]) != 0 )
               {
                  GXUtil.WriteLog("costocpoha:[seudo value changed for attri]"+"COSTOCPOHAUser");
                  GXUtil.WriteLogRaw("Old: ",Z155COSTOCPOHAUser);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A155COSTOCPOHAUser[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z156COSTOCPOHAReg ) != DateTimeUtil.ResetTime ( T000H2_A156COSTOCPOHAReg[0] ) )
               {
                  GXUtil.WriteLog("costocpoha:[seudo value changed for attri]"+"COSTOCPOHAReg");
                  GXUtil.WriteLogRaw("Old: ",Z156COSTOCPOHAReg);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A156COSTOCPOHAReg[0]);
               }
               if ( StringUtil.StrCmp(Z157COSTOCPOHAHor, T000H2_A157COSTOCPOHAHor[0]) != 0 )
               {
                  GXUtil.WriteLog("costocpoha:[seudo value changed for attri]"+"COSTOCPOHAHor");
                  GXUtil.WriteLogRaw("Old: ",Z157COSTOCPOHAHor);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A157COSTOCPOHAHor[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"COSTOCPOHA"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0H18( )
      {
         BeforeValidate0H18( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0H18( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0H18( 0) ;
            CheckOptimisticConcurrency0H18( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0H18( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0H18( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000H12 */
                     pr_default.execute(10, new Object[] {A36COSTOCPOHAFecha, A37COSTOCPOHAAno, A38COSTOCPOHAMes, A150COSTOCPOHAValor, A155COSTOCPOHAUser, A156COSTOCPOHAReg, A157COSTOCPOHAHor, A5Cod_Area, A4IndicadoresCodigo});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("COSTOCPOHA");
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
                           ResetCaption0H0( ) ;
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
               Load0H18( ) ;
            }
            EndLevel0H18( ) ;
         }
         CloseExtendedTableCursors0H18( ) ;
      }

      protected void Update0H18( )
      {
         BeforeValidate0H18( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0H18( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0H18( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0H18( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0H18( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000H13 */
                     pr_default.execute(11, new Object[] {A150COSTOCPOHAValor, A155COSTOCPOHAUser, A156COSTOCPOHAReg, A157COSTOCPOHAHor, A36COSTOCPOHAFecha, A37COSTOCPOHAAno, A38COSTOCPOHAMes, A5Cod_Area, A4IndicadoresCodigo});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("COSTOCPOHA");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"COSTOCPOHA"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0H18( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0H0( ) ;
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
            EndLevel0H18( ) ;
         }
         CloseExtendedTableCursors0H18( ) ;
      }

      protected void DeferredUpdate0H18( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0H18( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0H18( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0H18( ) ;
            AfterConfirm0H18( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0H18( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000H14 */
                  pr_default.execute(12, new Object[] {A36COSTOCPOHAFecha, A37COSTOCPOHAAno, A38COSTOCPOHAMes, A5Cod_Area, A4IndicadoresCodigo});
                  pr_default.close(12);
                  pr_default.SmartCacheProvider.SetUpdated("COSTOCPOHA");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound18 == 0 )
                        {
                           InitAll0H18( ) ;
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
                        ResetCaption0H0( ) ;
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
         sMode18 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0H18( ) ;
         Gx_mode = sMode18;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0H18( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0H18( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0H18( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("costocpoha",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0H0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("costocpoha",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0H18( )
      {
         /* Using cursor T000H15 */
         pr_default.execute(13);
         RcdFound18 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound18 = 1;
            A36COSTOCPOHAFecha = T000H15_A36COSTOCPOHAFecha[0];
            AssignAttri("", false, "A36COSTOCPOHAFecha", context.localUtil.Format(A36COSTOCPOHAFecha, "99/99/99"));
            A37COSTOCPOHAAno = T000H15_A37COSTOCPOHAAno[0];
            AssignAttri("", false, "A37COSTOCPOHAAno", StringUtil.LTrimStr( (decimal)(A37COSTOCPOHAAno), 4, 0));
            A38COSTOCPOHAMes = T000H15_A38COSTOCPOHAMes[0];
            AssignAttri("", false, "A38COSTOCPOHAMes", StringUtil.LTrimStr( (decimal)(A38COSTOCPOHAMes), 4, 0));
            A5Cod_Area = T000H15_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = T000H15_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0H18( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound18 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound18 = 1;
            A36COSTOCPOHAFecha = T000H15_A36COSTOCPOHAFecha[0];
            AssignAttri("", false, "A36COSTOCPOHAFecha", context.localUtil.Format(A36COSTOCPOHAFecha, "99/99/99"));
            A37COSTOCPOHAAno = T000H15_A37COSTOCPOHAAno[0];
            AssignAttri("", false, "A37COSTOCPOHAAno", StringUtil.LTrimStr( (decimal)(A37COSTOCPOHAAno), 4, 0));
            A38COSTOCPOHAMes = T000H15_A38COSTOCPOHAMes[0];
            AssignAttri("", false, "A38COSTOCPOHAMes", StringUtil.LTrimStr( (decimal)(A38COSTOCPOHAMes), 4, 0));
            A5Cod_Area = T000H15_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = T000H15_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
         }
      }

      protected void ScanEnd0H18( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm0H18( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0H18( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0H18( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0H18( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0H18( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0H18( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0H18( )
      {
         edtCOSTOCPOHAFecha_Enabled = 0;
         AssignProp("", false, edtCOSTOCPOHAFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSTOCPOHAFecha_Enabled), 5, 0), true);
         edtCOSTOCPOHAAno_Enabled = 0;
         AssignProp("", false, edtCOSTOCPOHAAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSTOCPOHAAno_Enabled), 5, 0), true);
         edtCOSTOCPOHAMes_Enabled = 0;
         AssignProp("", false, edtCOSTOCPOHAMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSTOCPOHAMes_Enabled), 5, 0), true);
         edtCod_Area_Enabled = 0;
         AssignProp("", false, edtCod_Area_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCod_Area_Enabled), 5, 0), true);
         edtIndicadoresCodigo_Enabled = 0;
         AssignProp("", false, edtIndicadoresCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIndicadoresCodigo_Enabled), 5, 0), true);
         edtCOSTOCPOHAValor_Enabled = 0;
         AssignProp("", false, edtCOSTOCPOHAValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSTOCPOHAValor_Enabled), 5, 0), true);
         edtCOSTOCPOHAUser_Enabled = 0;
         AssignProp("", false, edtCOSTOCPOHAUser_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSTOCPOHAUser_Enabled), 5, 0), true);
         edtCOSTOCPOHAReg_Enabled = 0;
         AssignProp("", false, edtCOSTOCPOHAReg_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSTOCPOHAReg_Enabled), 5, 0), true);
         edtCOSTOCPOHAHor_Enabled = 0;
         AssignProp("", false, edtCOSTOCPOHAHor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSTOCPOHAHor_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0H18( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0H0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("costocpoha.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z36COSTOCPOHAFecha", context.localUtil.DToC( Z36COSTOCPOHAFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z37COSTOCPOHAAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z37COSTOCPOHAAno), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z38COSTOCPOHAMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z38COSTOCPOHAMes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z5Cod_Area", Z5Cod_Area);
         GxWebStd.gx_hidden_field( context, "Z4IndicadoresCodigo", Z4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "Z150COSTOCPOHAValor", StringUtil.LTrim( StringUtil.NToC( Z150COSTOCPOHAValor, 14, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z155COSTOCPOHAUser", Z155COSTOCPOHAUser);
         GxWebStd.gx_hidden_field( context, "Z156COSTOCPOHAReg", context.localUtil.DToC( Z156COSTOCPOHAReg, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z157COSTOCPOHAHor", Z157COSTOCPOHAHor);
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
         return formatLink("costocpoha.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "COSTOCPOHA" ;
      }

      public override string GetPgmdesc( )
      {
         return "COSTOCPOHA" ;
      }

      protected void InitializeNonKey0H18( )
      {
         A150COSTOCPOHAValor = 0;
         AssignAttri("", false, "A150COSTOCPOHAValor", StringUtil.LTrimStr( A150COSTOCPOHAValor, 14, 2));
         A155COSTOCPOHAUser = "";
         AssignAttri("", false, "A155COSTOCPOHAUser", A155COSTOCPOHAUser);
         A156COSTOCPOHAReg = DateTime.MinValue;
         AssignAttri("", false, "A156COSTOCPOHAReg", context.localUtil.Format(A156COSTOCPOHAReg, "99/99/99"));
         A157COSTOCPOHAHor = "";
         AssignAttri("", false, "A157COSTOCPOHAHor", A157COSTOCPOHAHor);
         Z150COSTOCPOHAValor = 0;
         Z155COSTOCPOHAUser = "";
         Z156COSTOCPOHAReg = DateTime.MinValue;
         Z157COSTOCPOHAHor = "";
      }

      protected void InitAll0H18( )
      {
         A36COSTOCPOHAFecha = DateTime.MinValue;
         AssignAttri("", false, "A36COSTOCPOHAFecha", context.localUtil.Format(A36COSTOCPOHAFecha, "99/99/99"));
         A37COSTOCPOHAAno = 0;
         AssignAttri("", false, "A37COSTOCPOHAAno", StringUtil.LTrimStr( (decimal)(A37COSTOCPOHAAno), 4, 0));
         A38COSTOCPOHAMes = 0;
         AssignAttri("", false, "A38COSTOCPOHAMes", StringUtil.LTrimStr( (decimal)(A38COSTOCPOHAMes), 4, 0));
         A5Cod_Area = "";
         AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
         A4IndicadoresCodigo = "";
         AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
         InitializeNonKey0H18( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20247231021842", true, true);
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
         context.AddJavascriptSource("costocpoha.js", "?20247231021843", false, true);
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
         edtCOSTOCPOHAFecha_Internalname = "COSTOCPOHAFECHA";
         edtCOSTOCPOHAAno_Internalname = "COSTOCPOHAANO";
         edtCOSTOCPOHAMes_Internalname = "COSTOCPOHAMES";
         edtCod_Area_Internalname = "COD_AREA";
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO";
         edtCOSTOCPOHAValor_Internalname = "COSTOCPOHAVALOR";
         edtCOSTOCPOHAUser_Internalname = "COSTOCPOHAUSER";
         edtCOSTOCPOHAReg_Internalname = "COSTOCPOHAREG";
         edtCOSTOCPOHAHor_Internalname = "COSTOCPOHAHOR";
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
         Form.Caption = "COSTOCPOHA";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCOSTOCPOHAHor_Jsonclick = "";
         edtCOSTOCPOHAHor_Enabled = 1;
         edtCOSTOCPOHAReg_Jsonclick = "";
         edtCOSTOCPOHAReg_Enabled = 1;
         edtCOSTOCPOHAUser_Enabled = 1;
         edtCOSTOCPOHAValor_Jsonclick = "";
         edtCOSTOCPOHAValor_Enabled = 1;
         imgprompt_4_Visible = 1;
         imgprompt_4_Link = "";
         edtIndicadoresCodigo_Jsonclick = "";
         edtIndicadoresCodigo_Enabled = 1;
         imgprompt_5_Visible = 1;
         imgprompt_5_Link = "";
         edtCod_Area_Jsonclick = "";
         edtCod_Area_Enabled = 1;
         edtCOSTOCPOHAMes_Jsonclick = "";
         edtCOSTOCPOHAMes_Enabled = 1;
         edtCOSTOCPOHAAno_Jsonclick = "";
         edtCOSTOCPOHAAno_Enabled = 1;
         edtCOSTOCPOHAFecha_Jsonclick = "";
         edtCOSTOCPOHAFecha_Enabled = 1;
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
         /* Using cursor T000H16 */
         pr_default.execute(14, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(14);
         /* Using cursor T000H17 */
         pr_default.execute(15, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(15);
         GX_FocusControl = edtCOSTOCPOHAValor_Internalname;
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
         /* Using cursor T000H16 */
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
         /* Using cursor T000H17 */
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
         AssignAttri("", false, "A150COSTOCPOHAValor", StringUtil.LTrim( StringUtil.NToC( A150COSTOCPOHAValor, 14, 2, ".", "")));
         AssignAttri("", false, "A155COSTOCPOHAUser", A155COSTOCPOHAUser);
         AssignAttri("", false, "A156COSTOCPOHAReg", context.localUtil.Format(A156COSTOCPOHAReg, "99/99/99"));
         AssignAttri("", false, "A157COSTOCPOHAHor", A157COSTOCPOHAHor);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z36COSTOCPOHAFecha", context.localUtil.Format(Z36COSTOCPOHAFecha, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z37COSTOCPOHAAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z37COSTOCPOHAAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z38COSTOCPOHAMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z38COSTOCPOHAMes), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z5Cod_Area", Z5Cod_Area);
         GxWebStd.gx_hidden_field( context, "Z4IndicadoresCodigo", Z4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "Z150COSTOCPOHAValor", StringUtil.LTrim( StringUtil.NToC( Z150COSTOCPOHAValor, 14, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z155COSTOCPOHAUser", Z155COSTOCPOHAUser);
         GxWebStd.gx_hidden_field( context, "Z156COSTOCPOHAReg", context.localUtil.Format(Z156COSTOCPOHAReg, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z157COSTOCPOHAHor", Z157COSTOCPOHAHor);
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
         setEventMetadata("VALID_COSTOCPOHAFECHA","{handler:'Valid_Costocpohafecha',iparms:[]");
         setEventMetadata("VALID_COSTOCPOHAFECHA",",oparms:[]}");
         setEventMetadata("VALID_COSTOCPOHAANO","{handler:'Valid_Costocpohaano',iparms:[]");
         setEventMetadata("VALID_COSTOCPOHAANO",",oparms:[]}");
         setEventMetadata("VALID_COSTOCPOHAMES","{handler:'Valid_Costocpohames',iparms:[]");
         setEventMetadata("VALID_COSTOCPOHAMES",",oparms:[]}");
         setEventMetadata("VALID_COD_AREA","{handler:'Valid_Cod_area',iparms:[{av:'A5Cod_Area',fld:'COD_AREA',pic:''}]");
         setEventMetadata("VALID_COD_AREA",",oparms:[]}");
         setEventMetadata("VALID_INDICADORESCODIGO","{handler:'Valid_Indicadorescodigo',iparms:[{av:'A36COSTOCPOHAFecha',fld:'COSTOCPOHAFECHA',pic:''},{av:'A37COSTOCPOHAAno',fld:'COSTOCPOHAANO',pic:'ZZZ9'},{av:'A38COSTOCPOHAMes',fld:'COSTOCPOHAMES',pic:'ZZZ9'},{av:'A5Cod_Area',fld:'COD_AREA',pic:''},{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_INDICADORESCODIGO",",oparms:[{av:'A150COSTOCPOHAValor',fld:'COSTOCPOHAVALOR',pic:'ZZZZZZZZZZ9.99'},{av:'A155COSTOCPOHAUser',fld:'COSTOCPOHAUSER',pic:''},{av:'A156COSTOCPOHAReg',fld:'COSTOCPOHAREG',pic:''},{av:'A157COSTOCPOHAHor',fld:'COSTOCPOHAHOR',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z36COSTOCPOHAFecha'},{av:'Z37COSTOCPOHAAno'},{av:'Z38COSTOCPOHAMes'},{av:'Z5Cod_Area'},{av:'Z4IndicadoresCodigo'},{av:'Z150COSTOCPOHAValor'},{av:'Z155COSTOCPOHAUser'},{av:'Z156COSTOCPOHAReg'},{av:'Z157COSTOCPOHAHor'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_COSTOCPOHAREG","{handler:'Valid_Costocpohareg',iparms:[]");
         setEventMetadata("VALID_COSTOCPOHAREG",",oparms:[]}");
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
         Z36COSTOCPOHAFecha = DateTime.MinValue;
         Z5Cod_Area = "";
         Z4IndicadoresCodigo = "";
         Z155COSTOCPOHAUser = "";
         Z156COSTOCPOHAReg = DateTime.MinValue;
         Z157COSTOCPOHAHor = "";
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
         A36COSTOCPOHAFecha = DateTime.MinValue;
         imgprompt_5_gximage = "";
         sImgUrl = "";
         imgprompt_4_gximage = "";
         A155COSTOCPOHAUser = "";
         A156COSTOCPOHAReg = DateTime.MinValue;
         A157COSTOCPOHAHor = "";
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
         T000H6_A36COSTOCPOHAFecha = new DateTime[] {DateTime.MinValue} ;
         T000H6_A37COSTOCPOHAAno = new short[1] ;
         T000H6_A38COSTOCPOHAMes = new short[1] ;
         T000H6_A150COSTOCPOHAValor = new decimal[1] ;
         T000H6_A155COSTOCPOHAUser = new string[] {""} ;
         T000H6_A156COSTOCPOHAReg = new DateTime[] {DateTime.MinValue} ;
         T000H6_A157COSTOCPOHAHor = new string[] {""} ;
         T000H6_A5Cod_Area = new string[] {""} ;
         T000H6_A4IndicadoresCodigo = new string[] {""} ;
         T000H4_A5Cod_Area = new string[] {""} ;
         T000H5_A4IndicadoresCodigo = new string[] {""} ;
         T000H7_A5Cod_Area = new string[] {""} ;
         T000H8_A4IndicadoresCodigo = new string[] {""} ;
         T000H9_A36COSTOCPOHAFecha = new DateTime[] {DateTime.MinValue} ;
         T000H9_A37COSTOCPOHAAno = new short[1] ;
         T000H9_A38COSTOCPOHAMes = new short[1] ;
         T000H9_A5Cod_Area = new string[] {""} ;
         T000H9_A4IndicadoresCodigo = new string[] {""} ;
         T000H3_A36COSTOCPOHAFecha = new DateTime[] {DateTime.MinValue} ;
         T000H3_A37COSTOCPOHAAno = new short[1] ;
         T000H3_A38COSTOCPOHAMes = new short[1] ;
         T000H3_A150COSTOCPOHAValor = new decimal[1] ;
         T000H3_A155COSTOCPOHAUser = new string[] {""} ;
         T000H3_A156COSTOCPOHAReg = new DateTime[] {DateTime.MinValue} ;
         T000H3_A157COSTOCPOHAHor = new string[] {""} ;
         T000H3_A5Cod_Area = new string[] {""} ;
         T000H3_A4IndicadoresCodigo = new string[] {""} ;
         sMode18 = "";
         T000H10_A36COSTOCPOHAFecha = new DateTime[] {DateTime.MinValue} ;
         T000H10_A37COSTOCPOHAAno = new short[1] ;
         T000H10_A38COSTOCPOHAMes = new short[1] ;
         T000H10_A5Cod_Area = new string[] {""} ;
         T000H10_A4IndicadoresCodigo = new string[] {""} ;
         T000H11_A36COSTOCPOHAFecha = new DateTime[] {DateTime.MinValue} ;
         T000H11_A37COSTOCPOHAAno = new short[1] ;
         T000H11_A38COSTOCPOHAMes = new short[1] ;
         T000H11_A5Cod_Area = new string[] {""} ;
         T000H11_A4IndicadoresCodigo = new string[] {""} ;
         T000H2_A36COSTOCPOHAFecha = new DateTime[] {DateTime.MinValue} ;
         T000H2_A37COSTOCPOHAAno = new short[1] ;
         T000H2_A38COSTOCPOHAMes = new short[1] ;
         T000H2_A150COSTOCPOHAValor = new decimal[1] ;
         T000H2_A155COSTOCPOHAUser = new string[] {""} ;
         T000H2_A156COSTOCPOHAReg = new DateTime[] {DateTime.MinValue} ;
         T000H2_A157COSTOCPOHAHor = new string[] {""} ;
         T000H2_A5Cod_Area = new string[] {""} ;
         T000H2_A4IndicadoresCodigo = new string[] {""} ;
         T000H15_A36COSTOCPOHAFecha = new DateTime[] {DateTime.MinValue} ;
         T000H15_A37COSTOCPOHAAno = new short[1] ;
         T000H15_A38COSTOCPOHAMes = new short[1] ;
         T000H15_A5Cod_Area = new string[] {""} ;
         T000H15_A4IndicadoresCodigo = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T000H16_A5Cod_Area = new string[] {""} ;
         T000H17_A4IndicadoresCodigo = new string[] {""} ;
         ZZ36COSTOCPOHAFecha = DateTime.MinValue;
         ZZ5Cod_Area = "";
         ZZ4IndicadoresCodigo = "";
         ZZ155COSTOCPOHAUser = "";
         ZZ156COSTOCPOHAReg = DateTime.MinValue;
         ZZ157COSTOCPOHAHor = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.costocpoha__default(),
            new Object[][] {
                new Object[] {
               T000H2_A36COSTOCPOHAFecha, T000H2_A37COSTOCPOHAAno, T000H2_A38COSTOCPOHAMes, T000H2_A150COSTOCPOHAValor, T000H2_A155COSTOCPOHAUser, T000H2_A156COSTOCPOHAReg, T000H2_A157COSTOCPOHAHor, T000H2_A5Cod_Area, T000H2_A4IndicadoresCodigo
               }
               , new Object[] {
               T000H3_A36COSTOCPOHAFecha, T000H3_A37COSTOCPOHAAno, T000H3_A38COSTOCPOHAMes, T000H3_A150COSTOCPOHAValor, T000H3_A155COSTOCPOHAUser, T000H3_A156COSTOCPOHAReg, T000H3_A157COSTOCPOHAHor, T000H3_A5Cod_Area, T000H3_A4IndicadoresCodigo
               }
               , new Object[] {
               T000H4_A5Cod_Area
               }
               , new Object[] {
               T000H5_A4IndicadoresCodigo
               }
               , new Object[] {
               T000H6_A36COSTOCPOHAFecha, T000H6_A37COSTOCPOHAAno, T000H6_A38COSTOCPOHAMes, T000H6_A150COSTOCPOHAValor, T000H6_A155COSTOCPOHAUser, T000H6_A156COSTOCPOHAReg, T000H6_A157COSTOCPOHAHor, T000H6_A5Cod_Area, T000H6_A4IndicadoresCodigo
               }
               , new Object[] {
               T000H7_A5Cod_Area
               }
               , new Object[] {
               T000H8_A4IndicadoresCodigo
               }
               , new Object[] {
               T000H9_A36COSTOCPOHAFecha, T000H9_A37COSTOCPOHAAno, T000H9_A38COSTOCPOHAMes, T000H9_A5Cod_Area, T000H9_A4IndicadoresCodigo
               }
               , new Object[] {
               T000H10_A36COSTOCPOHAFecha, T000H10_A37COSTOCPOHAAno, T000H10_A38COSTOCPOHAMes, T000H10_A5Cod_Area, T000H10_A4IndicadoresCodigo
               }
               , new Object[] {
               T000H11_A36COSTOCPOHAFecha, T000H11_A37COSTOCPOHAAno, T000H11_A38COSTOCPOHAMes, T000H11_A5Cod_Area, T000H11_A4IndicadoresCodigo
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000H15_A36COSTOCPOHAFecha, T000H15_A37COSTOCPOHAAno, T000H15_A38COSTOCPOHAMes, T000H15_A5Cod_Area, T000H15_A4IndicadoresCodigo
               }
               , new Object[] {
               T000H16_A5Cod_Area
               }
               , new Object[] {
               T000H17_A4IndicadoresCodigo
               }
            }
         );
      }

      private short Z37COSTOCPOHAAno ;
      private short Z38COSTOCPOHAMes ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A37COSTOCPOHAAno ;
      private short A38COSTOCPOHAMes ;
      private short GX_JID ;
      private short RcdFound18 ;
      private short nIsDirty_18 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ37COSTOCPOHAAno ;
      private short ZZ38COSTOCPOHAMes ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtCOSTOCPOHAFecha_Enabled ;
      private int edtCOSTOCPOHAAno_Enabled ;
      private int edtCOSTOCPOHAMes_Enabled ;
      private int edtCod_Area_Enabled ;
      private int imgprompt_5_Visible ;
      private int edtIndicadoresCodigo_Enabled ;
      private int imgprompt_4_Visible ;
      private int edtCOSTOCPOHAValor_Enabled ;
      private int edtCOSTOCPOHAUser_Enabled ;
      private int edtCOSTOCPOHAReg_Enabled ;
      private int edtCOSTOCPOHAHor_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private decimal Z150COSTOCPOHAValor ;
      private decimal A150COSTOCPOHAValor ;
      private decimal ZZ150COSTOCPOHAValor ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCOSTOCPOHAFecha_Internalname ;
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
      private string edtCOSTOCPOHAFecha_Jsonclick ;
      private string edtCOSTOCPOHAAno_Internalname ;
      private string edtCOSTOCPOHAAno_Jsonclick ;
      private string edtCOSTOCPOHAMes_Internalname ;
      private string edtCOSTOCPOHAMes_Jsonclick ;
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
      private string edtCOSTOCPOHAValor_Internalname ;
      private string edtCOSTOCPOHAValor_Jsonclick ;
      private string edtCOSTOCPOHAUser_Internalname ;
      private string edtCOSTOCPOHAReg_Internalname ;
      private string edtCOSTOCPOHAReg_Jsonclick ;
      private string edtCOSTOCPOHAHor_Internalname ;
      private string edtCOSTOCPOHAHor_Jsonclick ;
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
      private string sMode18 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z36COSTOCPOHAFecha ;
      private DateTime Z156COSTOCPOHAReg ;
      private DateTime A36COSTOCPOHAFecha ;
      private DateTime A156COSTOCPOHAReg ;
      private DateTime ZZ36COSTOCPOHAFecha ;
      private DateTime ZZ156COSTOCPOHAReg ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string Z5Cod_Area ;
      private string Z4IndicadoresCodigo ;
      private string Z155COSTOCPOHAUser ;
      private string Z157COSTOCPOHAHor ;
      private string A5Cod_Area ;
      private string A4IndicadoresCodigo ;
      private string A155COSTOCPOHAUser ;
      private string A157COSTOCPOHAHor ;
      private string ZZ5Cod_Area ;
      private string ZZ4IndicadoresCodigo ;
      private string ZZ155COSTOCPOHAUser ;
      private string ZZ157COSTOCPOHAHor ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] T000H6_A36COSTOCPOHAFecha ;
      private short[] T000H6_A37COSTOCPOHAAno ;
      private short[] T000H6_A38COSTOCPOHAMes ;
      private decimal[] T000H6_A150COSTOCPOHAValor ;
      private string[] T000H6_A155COSTOCPOHAUser ;
      private DateTime[] T000H6_A156COSTOCPOHAReg ;
      private string[] T000H6_A157COSTOCPOHAHor ;
      private string[] T000H6_A5Cod_Area ;
      private string[] T000H6_A4IndicadoresCodigo ;
      private string[] T000H4_A5Cod_Area ;
      private string[] T000H5_A4IndicadoresCodigo ;
      private string[] T000H7_A5Cod_Area ;
      private string[] T000H8_A4IndicadoresCodigo ;
      private DateTime[] T000H9_A36COSTOCPOHAFecha ;
      private short[] T000H9_A37COSTOCPOHAAno ;
      private short[] T000H9_A38COSTOCPOHAMes ;
      private string[] T000H9_A5Cod_Area ;
      private string[] T000H9_A4IndicadoresCodigo ;
      private DateTime[] T000H3_A36COSTOCPOHAFecha ;
      private short[] T000H3_A37COSTOCPOHAAno ;
      private short[] T000H3_A38COSTOCPOHAMes ;
      private decimal[] T000H3_A150COSTOCPOHAValor ;
      private string[] T000H3_A155COSTOCPOHAUser ;
      private DateTime[] T000H3_A156COSTOCPOHAReg ;
      private string[] T000H3_A157COSTOCPOHAHor ;
      private string[] T000H3_A5Cod_Area ;
      private string[] T000H3_A4IndicadoresCodigo ;
      private DateTime[] T000H10_A36COSTOCPOHAFecha ;
      private short[] T000H10_A37COSTOCPOHAAno ;
      private short[] T000H10_A38COSTOCPOHAMes ;
      private string[] T000H10_A5Cod_Area ;
      private string[] T000H10_A4IndicadoresCodigo ;
      private DateTime[] T000H11_A36COSTOCPOHAFecha ;
      private short[] T000H11_A37COSTOCPOHAAno ;
      private short[] T000H11_A38COSTOCPOHAMes ;
      private string[] T000H11_A5Cod_Area ;
      private string[] T000H11_A4IndicadoresCodigo ;
      private DateTime[] T000H2_A36COSTOCPOHAFecha ;
      private short[] T000H2_A37COSTOCPOHAAno ;
      private short[] T000H2_A38COSTOCPOHAMes ;
      private decimal[] T000H2_A150COSTOCPOHAValor ;
      private string[] T000H2_A155COSTOCPOHAUser ;
      private DateTime[] T000H2_A156COSTOCPOHAReg ;
      private string[] T000H2_A157COSTOCPOHAHor ;
      private string[] T000H2_A5Cod_Area ;
      private string[] T000H2_A4IndicadoresCodigo ;
      private DateTime[] T000H15_A36COSTOCPOHAFecha ;
      private short[] T000H15_A37COSTOCPOHAAno ;
      private short[] T000H15_A38COSTOCPOHAMes ;
      private string[] T000H15_A5Cod_Area ;
      private string[] T000H15_A4IndicadoresCodigo ;
      private string[] T000H16_A5Cod_Area ;
      private string[] T000H17_A4IndicadoresCodigo ;
      private GXWebForm Form ;
   }

   public class costocpoha__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT000H6;
          prmT000H6 = new Object[] {
          new ParDef("@COSTOCPOHAFecha",GXType.Date,8,0) ,
          new ParDef("@COSTOCPOHAAno",GXType.Int16,4,0) ,
          new ParDef("@COSTOCPOHAMes",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000H4;
          prmT000H4 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000H5;
          prmT000H5 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000H7;
          prmT000H7 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000H8;
          prmT000H8 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000H9;
          prmT000H9 = new Object[] {
          new ParDef("@COSTOCPOHAFecha",GXType.Date,8,0) ,
          new ParDef("@COSTOCPOHAAno",GXType.Int16,4,0) ,
          new ParDef("@COSTOCPOHAMes",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000H3;
          prmT000H3 = new Object[] {
          new ParDef("@COSTOCPOHAFecha",GXType.Date,8,0) ,
          new ParDef("@COSTOCPOHAAno",GXType.Int16,4,0) ,
          new ParDef("@COSTOCPOHAMes",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000H10;
          prmT000H10 = new Object[] {
          new ParDef("@COSTOCPOHAFecha",GXType.Date,8,0) ,
          new ParDef("@COSTOCPOHAAno",GXType.Int16,4,0) ,
          new ParDef("@COSTOCPOHAMes",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000H11;
          prmT000H11 = new Object[] {
          new ParDef("@COSTOCPOHAFecha",GXType.Date,8,0) ,
          new ParDef("@COSTOCPOHAAno",GXType.Int16,4,0) ,
          new ParDef("@COSTOCPOHAMes",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000H2;
          prmT000H2 = new Object[] {
          new ParDef("@COSTOCPOHAFecha",GXType.Date,8,0) ,
          new ParDef("@COSTOCPOHAAno",GXType.Int16,4,0) ,
          new ParDef("@COSTOCPOHAMes",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000H12;
          prmT000H12 = new Object[] {
          new ParDef("@COSTOCPOHAFecha",GXType.Date,8,0) ,
          new ParDef("@COSTOCPOHAAno",GXType.Int16,4,0) ,
          new ParDef("@COSTOCPOHAMes",GXType.Int16,4,0) ,
          new ParDef("@COSTOCPOHAValor",GXType.Decimal,14,2) ,
          new ParDef("@COSTOCPOHAUser",GXType.NVarChar,240,0) ,
          new ParDef("@COSTOCPOHAReg",GXType.Date,8,0) ,
          new ParDef("@COSTOCPOHAHor",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000H13;
          prmT000H13 = new Object[] {
          new ParDef("@COSTOCPOHAValor",GXType.Decimal,14,2) ,
          new ParDef("@COSTOCPOHAUser",GXType.NVarChar,240,0) ,
          new ParDef("@COSTOCPOHAReg",GXType.Date,8,0) ,
          new ParDef("@COSTOCPOHAHor",GXType.NVarChar,40,0) ,
          new ParDef("@COSTOCPOHAFecha",GXType.Date,8,0) ,
          new ParDef("@COSTOCPOHAAno",GXType.Int16,4,0) ,
          new ParDef("@COSTOCPOHAMes",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000H14;
          prmT000H14 = new Object[] {
          new ParDef("@COSTOCPOHAFecha",GXType.Date,8,0) ,
          new ParDef("@COSTOCPOHAAno",GXType.Int16,4,0) ,
          new ParDef("@COSTOCPOHAMes",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000H15;
          prmT000H15 = new Object[] {
          };
          Object[] prmT000H16;
          prmT000H16 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000H17;
          prmT000H17 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("T000H2", "SELECT [COSTOCPOHAFecha], [COSTOCPOHAAno], [COSTOCPOHAMes], [COSTOCPOHAValor], [COSTOCPOHAUser], [COSTOCPOHAReg], [COSTOCPOHAHor], [Cod_Area], [IndicadoresCodigo] FROM [COSTOCPOHA] WITH (UPDLOCK) WHERE [COSTOCPOHAFecha] = @COSTOCPOHAFecha AND [COSTOCPOHAAno] = @COSTOCPOHAAno AND [COSTOCPOHAMes] = @COSTOCPOHAMes AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000H3", "SELECT [COSTOCPOHAFecha], [COSTOCPOHAAno], [COSTOCPOHAMes], [COSTOCPOHAValor], [COSTOCPOHAUser], [COSTOCPOHAReg], [COSTOCPOHAHor], [Cod_Area], [IndicadoresCodigo] FROM [COSTOCPOHA] WHERE [COSTOCPOHAFecha] = @COSTOCPOHAFecha AND [COSTOCPOHAAno] = @COSTOCPOHAAno AND [COSTOCPOHAMes] = @COSTOCPOHAMes AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000H4", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000H5", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000H6", "SELECT TM1.[COSTOCPOHAFecha], TM1.[COSTOCPOHAAno], TM1.[COSTOCPOHAMes], TM1.[COSTOCPOHAValor], TM1.[COSTOCPOHAUser], TM1.[COSTOCPOHAReg], TM1.[COSTOCPOHAHor], TM1.[Cod_Area], TM1.[IndicadoresCodigo] FROM [COSTOCPOHA] TM1 WHERE TM1.[COSTOCPOHAFecha] = @COSTOCPOHAFecha and TM1.[COSTOCPOHAAno] = @COSTOCPOHAAno and TM1.[COSTOCPOHAMes] = @COSTOCPOHAMes and TM1.[Cod_Area] = @Cod_Area and TM1.[IndicadoresCodigo] = @IndicadoresCodigo ORDER BY TM1.[COSTOCPOHAFecha], TM1.[COSTOCPOHAAno], TM1.[COSTOCPOHAMes], TM1.[Cod_Area], TM1.[IndicadoresCodigo]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000H6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000H7", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000H8", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000H9", "SELECT [COSTOCPOHAFecha], [COSTOCPOHAAno], [COSTOCPOHAMes], [Cod_Area], [IndicadoresCodigo] FROM [COSTOCPOHA] WHERE [COSTOCPOHAFecha] = @COSTOCPOHAFecha AND [COSTOCPOHAAno] = @COSTOCPOHAAno AND [COSTOCPOHAMes] = @COSTOCPOHAMes AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000H9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000H10", "SELECT TOP 1 [COSTOCPOHAFecha], [COSTOCPOHAAno], [COSTOCPOHAMes], [Cod_Area], [IndicadoresCodigo] FROM [COSTOCPOHA] WHERE ( [COSTOCPOHAFecha] > @COSTOCPOHAFecha or [COSTOCPOHAFecha] = @COSTOCPOHAFecha and [COSTOCPOHAAno] > @COSTOCPOHAAno or [COSTOCPOHAAno] = @COSTOCPOHAAno and [COSTOCPOHAFecha] = @COSTOCPOHAFecha and [COSTOCPOHAMes] > @COSTOCPOHAMes or [COSTOCPOHAMes] = @COSTOCPOHAMes and [COSTOCPOHAAno] = @COSTOCPOHAAno and [COSTOCPOHAFecha] = @COSTOCPOHAFecha and [Cod_Area] > @Cod_Area or [Cod_Area] = @Cod_Area and [COSTOCPOHAMes] = @COSTOCPOHAMes and [COSTOCPOHAAno] = @COSTOCPOHAAno and [COSTOCPOHAFecha] = @COSTOCPOHAFecha and [IndicadoresCodigo] > @IndicadoresCodigo) ORDER BY [COSTOCPOHAFecha], [COSTOCPOHAAno], [COSTOCPOHAMes], [Cod_Area], [IndicadoresCodigo]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000H10,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000H11", "SELECT TOP 1 [COSTOCPOHAFecha], [COSTOCPOHAAno], [COSTOCPOHAMes], [Cod_Area], [IndicadoresCodigo] FROM [COSTOCPOHA] WHERE ( [COSTOCPOHAFecha] < @COSTOCPOHAFecha or [COSTOCPOHAFecha] = @COSTOCPOHAFecha and [COSTOCPOHAAno] < @COSTOCPOHAAno or [COSTOCPOHAAno] = @COSTOCPOHAAno and [COSTOCPOHAFecha] = @COSTOCPOHAFecha and [COSTOCPOHAMes] < @COSTOCPOHAMes or [COSTOCPOHAMes] = @COSTOCPOHAMes and [COSTOCPOHAAno] = @COSTOCPOHAAno and [COSTOCPOHAFecha] = @COSTOCPOHAFecha and [Cod_Area] < @Cod_Area or [Cod_Area] = @Cod_Area and [COSTOCPOHAMes] = @COSTOCPOHAMes and [COSTOCPOHAAno] = @COSTOCPOHAAno and [COSTOCPOHAFecha] = @COSTOCPOHAFecha and [IndicadoresCodigo] < @IndicadoresCodigo) ORDER BY [COSTOCPOHAFecha] DESC, [COSTOCPOHAAno] DESC, [COSTOCPOHAMes] DESC, [Cod_Area] DESC, [IndicadoresCodigo] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000H11,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000H12", "INSERT INTO [COSTOCPOHA]([COSTOCPOHAFecha], [COSTOCPOHAAno], [COSTOCPOHAMes], [COSTOCPOHAValor], [COSTOCPOHAUser], [COSTOCPOHAReg], [COSTOCPOHAHor], [Cod_Area], [IndicadoresCodigo]) VALUES(@COSTOCPOHAFecha, @COSTOCPOHAAno, @COSTOCPOHAMes, @COSTOCPOHAValor, @COSTOCPOHAUser, @COSTOCPOHAReg, @COSTOCPOHAHor, @Cod_Area, @IndicadoresCodigo)", GxErrorMask.GX_NOMASK,prmT000H12)
             ,new CursorDef("T000H13", "UPDATE [COSTOCPOHA] SET [COSTOCPOHAValor]=@COSTOCPOHAValor, [COSTOCPOHAUser]=@COSTOCPOHAUser, [COSTOCPOHAReg]=@COSTOCPOHAReg, [COSTOCPOHAHor]=@COSTOCPOHAHor  WHERE [COSTOCPOHAFecha] = @COSTOCPOHAFecha AND [COSTOCPOHAAno] = @COSTOCPOHAAno AND [COSTOCPOHAMes] = @COSTOCPOHAMes AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo", GxErrorMask.GX_NOMASK,prmT000H13)
             ,new CursorDef("T000H14", "DELETE FROM [COSTOCPOHA]  WHERE [COSTOCPOHAFecha] = @COSTOCPOHAFecha AND [COSTOCPOHAAno] = @COSTOCPOHAAno AND [COSTOCPOHAMes] = @COSTOCPOHAMes AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo", GxErrorMask.GX_NOMASK,prmT000H14)
             ,new CursorDef("T000H15", "SELECT [COSTOCPOHAFecha], [COSTOCPOHAAno], [COSTOCPOHAMes], [Cod_Area], [IndicadoresCodigo] FROM [COSTOCPOHA] ORDER BY [COSTOCPOHAFecha], [COSTOCPOHAAno], [COSTOCPOHAMes], [Cod_Area], [IndicadoresCodigo]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000H15,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000H16", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H16,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000H17", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H17,1, GxCacheFrequency.OFF ,true,false )
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
