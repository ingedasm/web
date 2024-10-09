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
   public class frutoprocesado : GXDataArea
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
            Form.Meta.addItem("description", "FRUTOPROCESADO", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtFRUTOPROCESADOFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("IndicadroresPalmas", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public frutoprocesado( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("IndicadroresPalmas", true);
      }

      public frutoprocesado( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "FRUTOPROCESADO", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_FRUTOPROCESADO.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_FRUTOPROCESADO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_FRUTOPROCESADO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_FRUTOPROCESADO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_FRUTOPROCESADO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 4, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx00j0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"FRUTOPROCESADOFEC"+"'), id:'"+"FRUTOPROCESADOFEC"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"FRUTOPROCESADOMES"+"'), id:'"+"FRUTOPROCESADOMES"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"FRUTOPROCESADOANO"+"'), id:'"+"FRUTOPROCESADOANO"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"COD_AREA"+"'), id:'"+"COD_AREA"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"INDICADORESCODIGO"+"'), id:'"+"INDICADORESCODIGO"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_FRUTOPROCESADO.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFRUTOPROCESADOFec_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFRUTOPROCESADOFec_Internalname, "FRUTOPROCESADOFec", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtFRUTOPROCESADOFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtFRUTOPROCESADOFec_Internalname, context.localUtil.Format(A39FRUTOPROCESADOFec, "99/99/99"), context.localUtil.Format( A39FRUTOPROCESADOFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFRUTOPROCESADOFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFRUTOPROCESADOFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_FRUTOPROCESADO.htm");
         GxWebStd.gx_bitmap( context, edtFRUTOPROCESADOFec_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtFRUTOPROCESADOFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_FRUTOPROCESADO.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFRUTOPROCESADOMes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFRUTOPROCESADOMes_Internalname, "FRUTOPROCESADOMes", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFRUTOPROCESADOMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A40FRUTOPROCESADOMes), 4, 0, ",", "")), StringUtil.LTrim( ((edtFRUTOPROCESADOMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A40FRUTOPROCESADOMes), "ZZZ9") : context.localUtil.Format( (decimal)(A40FRUTOPROCESADOMes), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFRUTOPROCESADOMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFRUTOPROCESADOMes_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_FRUTOPROCESADO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFRUTOPROCESADOAno_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFRUTOPROCESADOAno_Internalname, "FRUTOPROCESADOAno", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFRUTOPROCESADOAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A41FRUTOPROCESADOAno), 4, 0, ",", "")), StringUtil.LTrim( ((edtFRUTOPROCESADOAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A41FRUTOPROCESADOAno), "ZZZ9") : context.localUtil.Format( (decimal)(A41FRUTOPROCESADOAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFRUTOPROCESADOAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFRUTOPROCESADOAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_FRUTOPROCESADO.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCod_Area_Internalname, A5Cod_Area, StringUtil.RTrim( context.localUtil.Format( A5Cod_Area, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCod_Area_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCod_Area_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_FRUTOPROCESADO.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_5_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_5_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_5_Internalname, sImgUrl, imgprompt_5_Link, "", "", context.GetTheme( ), imgprompt_5_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_FRUTOPROCESADO.htm");
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
         GxWebStd.gx_single_line_edit( context, edtIndicadoresCodigo_Internalname, A4IndicadoresCodigo, StringUtil.RTrim( context.localUtil.Format( A4IndicadoresCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIndicadoresCodigo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIndicadoresCodigo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_FRUTOPROCESADO.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_4_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_4_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_4_Internalname, sImgUrl, imgprompt_4_Link, "", "", context.GetTheme( ), imgprompt_4_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_FRUTOPROCESADO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFRUTOPROCESADOValor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFRUTOPROCESADOValor_Internalname, "FRUTOPROCESADOValor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFRUTOPROCESADOValor_Internalname, StringUtil.LTrim( StringUtil.NToC( A151FRUTOPROCESADOValor, 16, 2, ",", "")), StringUtil.LTrim( ((edtFRUTOPROCESADOValor_Enabled!=0) ? context.localUtil.Format( A151FRUTOPROCESADOValor, "ZZZZZZZZZZZZ9.99") : context.localUtil.Format( A151FRUTOPROCESADOValor, "ZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFRUTOPROCESADOValor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFRUTOPROCESADOValor_Enabled, 0, "text", "", 16, "chr", 1, "row", 16, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_FRUTOPROCESADO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFRUTOPROCESADOUser_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFRUTOPROCESADOUser_Internalname, "FRUTOPROCESADOUser", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtFRUTOPROCESADOUser_Internalname, A152FRUTOPROCESADOUser, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", 0, 1, edtFRUTOPROCESADOUser_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_FRUTOPROCESADO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFRUTOPROCESADOReg_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFRUTOPROCESADOReg_Internalname, "FRUTOPROCESADOReg", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtFRUTOPROCESADOReg_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtFRUTOPROCESADOReg_Internalname, context.localUtil.Format(A153FRUTOPROCESADOReg, "99/99/99"), context.localUtil.Format( A153FRUTOPROCESADOReg, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFRUTOPROCESADOReg_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFRUTOPROCESADOReg_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_FRUTOPROCESADO.htm");
         GxWebStd.gx_bitmap( context, edtFRUTOPROCESADOReg_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtFRUTOPROCESADOReg_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_FRUTOPROCESADO.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFRUTOPROCESADOHor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFRUTOPROCESADOHor_Internalname, "FRUTOPROCESADOHor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFRUTOPROCESADOHor_Internalname, A154FRUTOPROCESADOHor, StringUtil.RTrim( context.localUtil.Format( A154FRUTOPROCESADOHor, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFRUTOPROCESADOHor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFRUTOPROCESADOHor_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_FRUTOPROCESADO.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_FRUTOPROCESADO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_FRUTOPROCESADO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_FRUTOPROCESADO.htm");
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
            Z39FRUTOPROCESADOFec = context.localUtil.CToD( cgiGet( "Z39FRUTOPROCESADOFec"), 0);
            Z40FRUTOPROCESADOMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z40FRUTOPROCESADOMes"), ",", "."), 18, MidpointRounding.ToEven));
            Z41FRUTOPROCESADOAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z41FRUTOPROCESADOAno"), ",", "."), 18, MidpointRounding.ToEven));
            Z5Cod_Area = cgiGet( "Z5Cod_Area");
            Z4IndicadoresCodigo = cgiGet( "Z4IndicadoresCodigo");
            Z151FRUTOPROCESADOValor = context.localUtil.CToN( cgiGet( "Z151FRUTOPROCESADOValor"), ",", ".");
            Z152FRUTOPROCESADOUser = cgiGet( "Z152FRUTOPROCESADOUser");
            Z153FRUTOPROCESADOReg = context.localUtil.CToD( cgiGet( "Z153FRUTOPROCESADOReg"), 0);
            Z154FRUTOPROCESADOHor = cgiGet( "Z154FRUTOPROCESADOHor");
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( context.localUtil.VCDate( cgiGet( edtFRUTOPROCESADOFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"FRUTOPROCESADOFec"}), 1, "FRUTOPROCESADOFEC");
               AnyError = 1;
               GX_FocusControl = edtFRUTOPROCESADOFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A39FRUTOPROCESADOFec = DateTime.MinValue;
               AssignAttri("", false, "A39FRUTOPROCESADOFec", context.localUtil.Format(A39FRUTOPROCESADOFec, "99/99/99"));
            }
            else
            {
               A39FRUTOPROCESADOFec = context.localUtil.CToD( cgiGet( edtFRUTOPROCESADOFec_Internalname), 2);
               AssignAttri("", false, "A39FRUTOPROCESADOFec", context.localUtil.Format(A39FRUTOPROCESADOFec, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtFRUTOPROCESADOMes_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtFRUTOPROCESADOMes_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FRUTOPROCESADOMES");
               AnyError = 1;
               GX_FocusControl = edtFRUTOPROCESADOMes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A40FRUTOPROCESADOMes = 0;
               AssignAttri("", false, "A40FRUTOPROCESADOMes", StringUtil.LTrimStr( (decimal)(A40FRUTOPROCESADOMes), 4, 0));
            }
            else
            {
               A40FRUTOPROCESADOMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtFRUTOPROCESADOMes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A40FRUTOPROCESADOMes", StringUtil.LTrimStr( (decimal)(A40FRUTOPROCESADOMes), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtFRUTOPROCESADOAno_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtFRUTOPROCESADOAno_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FRUTOPROCESADOANO");
               AnyError = 1;
               GX_FocusControl = edtFRUTOPROCESADOAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A41FRUTOPROCESADOAno = 0;
               AssignAttri("", false, "A41FRUTOPROCESADOAno", StringUtil.LTrimStr( (decimal)(A41FRUTOPROCESADOAno), 4, 0));
            }
            else
            {
               A41FRUTOPROCESADOAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtFRUTOPROCESADOAno_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A41FRUTOPROCESADOAno", StringUtil.LTrimStr( (decimal)(A41FRUTOPROCESADOAno), 4, 0));
            }
            A5Cod_Area = cgiGet( edtCod_Area_Internalname);
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = cgiGet( edtIndicadoresCodigo_Internalname);
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            if ( ( ( context.localUtil.CToN( cgiGet( edtFRUTOPROCESADOValor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtFRUTOPROCESADOValor_Internalname), ",", ".") > 9999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FRUTOPROCESADOVALOR");
               AnyError = 1;
               GX_FocusControl = edtFRUTOPROCESADOValor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A151FRUTOPROCESADOValor = 0;
               AssignAttri("", false, "A151FRUTOPROCESADOValor", StringUtil.LTrimStr( A151FRUTOPROCESADOValor, 16, 2));
            }
            else
            {
               A151FRUTOPROCESADOValor = context.localUtil.CToN( cgiGet( edtFRUTOPROCESADOValor_Internalname), ",", ".");
               AssignAttri("", false, "A151FRUTOPROCESADOValor", StringUtil.LTrimStr( A151FRUTOPROCESADOValor, 16, 2));
            }
            A152FRUTOPROCESADOUser = cgiGet( edtFRUTOPROCESADOUser_Internalname);
            AssignAttri("", false, "A152FRUTOPROCESADOUser", A152FRUTOPROCESADOUser);
            if ( context.localUtil.VCDate( cgiGet( edtFRUTOPROCESADOReg_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"FRUTOPROCESADOReg"}), 1, "FRUTOPROCESADOREG");
               AnyError = 1;
               GX_FocusControl = edtFRUTOPROCESADOReg_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A153FRUTOPROCESADOReg = DateTime.MinValue;
               AssignAttri("", false, "A153FRUTOPROCESADOReg", context.localUtil.Format(A153FRUTOPROCESADOReg, "99/99/99"));
            }
            else
            {
               A153FRUTOPROCESADOReg = context.localUtil.CToD( cgiGet( edtFRUTOPROCESADOReg_Internalname), 2);
               AssignAttri("", false, "A153FRUTOPROCESADOReg", context.localUtil.Format(A153FRUTOPROCESADOReg, "99/99/99"));
            }
            A154FRUTOPROCESADOHor = cgiGet( edtFRUTOPROCESADOHor_Internalname);
            AssignAttri("", false, "A154FRUTOPROCESADOHor", A154FRUTOPROCESADOHor);
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
               A39FRUTOPROCESADOFec = context.localUtil.ParseDateParm( GetPar( "FRUTOPROCESADOFec"));
               AssignAttri("", false, "A39FRUTOPROCESADOFec", context.localUtil.Format(A39FRUTOPROCESADOFec, "99/99/99"));
               A40FRUTOPROCESADOMes = (short)(Math.Round(NumberUtil.Val( GetPar( "FRUTOPROCESADOMes"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A40FRUTOPROCESADOMes", StringUtil.LTrimStr( (decimal)(A40FRUTOPROCESADOMes), 4, 0));
               A41FRUTOPROCESADOAno = (short)(Math.Round(NumberUtil.Val( GetPar( "FRUTOPROCESADOAno"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A41FRUTOPROCESADOAno", StringUtil.LTrimStr( (decimal)(A41FRUTOPROCESADOAno), 4, 0));
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
               InitAll0I19( ) ;
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
         DisableAttributes0I19( ) ;
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

      protected void ResetCaption0I0( )
      {
      }

      protected void ZM0I19( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z151FRUTOPROCESADOValor = T000I3_A151FRUTOPROCESADOValor[0];
               Z152FRUTOPROCESADOUser = T000I3_A152FRUTOPROCESADOUser[0];
               Z153FRUTOPROCESADOReg = T000I3_A153FRUTOPROCESADOReg[0];
               Z154FRUTOPROCESADOHor = T000I3_A154FRUTOPROCESADOHor[0];
            }
            else
            {
               Z151FRUTOPROCESADOValor = A151FRUTOPROCESADOValor;
               Z152FRUTOPROCESADOUser = A152FRUTOPROCESADOUser;
               Z153FRUTOPROCESADOReg = A153FRUTOPROCESADOReg;
               Z154FRUTOPROCESADOHor = A154FRUTOPROCESADOHor;
            }
         }
         if ( GX_JID == -3 )
         {
            Z39FRUTOPROCESADOFec = A39FRUTOPROCESADOFec;
            Z40FRUTOPROCESADOMes = A40FRUTOPROCESADOMes;
            Z41FRUTOPROCESADOAno = A41FRUTOPROCESADOAno;
            Z151FRUTOPROCESADOValor = A151FRUTOPROCESADOValor;
            Z152FRUTOPROCESADOUser = A152FRUTOPROCESADOUser;
            Z153FRUTOPROCESADOReg = A153FRUTOPROCESADOReg;
            Z154FRUTOPROCESADOHor = A154FRUTOPROCESADOHor;
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

      protected void Load0I19( )
      {
         /* Using cursor T000I6 */
         pr_default.execute(4, new Object[] {A39FRUTOPROCESADOFec, A40FRUTOPROCESADOMes, A41FRUTOPROCESADOAno, A5Cod_Area, A4IndicadoresCodigo});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound19 = 1;
            A151FRUTOPROCESADOValor = T000I6_A151FRUTOPROCESADOValor[0];
            AssignAttri("", false, "A151FRUTOPROCESADOValor", StringUtil.LTrimStr( A151FRUTOPROCESADOValor, 16, 2));
            A152FRUTOPROCESADOUser = T000I6_A152FRUTOPROCESADOUser[0];
            AssignAttri("", false, "A152FRUTOPROCESADOUser", A152FRUTOPROCESADOUser);
            A153FRUTOPROCESADOReg = T000I6_A153FRUTOPROCESADOReg[0];
            AssignAttri("", false, "A153FRUTOPROCESADOReg", context.localUtil.Format(A153FRUTOPROCESADOReg, "99/99/99"));
            A154FRUTOPROCESADOHor = T000I6_A154FRUTOPROCESADOHor[0];
            AssignAttri("", false, "A154FRUTOPROCESADOHor", A154FRUTOPROCESADOHor);
            ZM0I19( -3) ;
         }
         pr_default.close(4);
         OnLoadActions0I19( ) ;
      }

      protected void OnLoadActions0I19( )
      {
      }

      protected void CheckExtendedTable0I19( )
      {
         nIsDirty_19 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A39FRUTOPROCESADOFec) || ( DateTimeUtil.ResetTime ( A39FRUTOPROCESADOFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo FRUTOPROCESADOFec fuera de rango", "OutOfRange", 1, "FRUTOPROCESADOFEC");
            AnyError = 1;
            GX_FocusControl = edtFRUTOPROCESADOFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000I4 */
         pr_default.execute(2, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T000I5 */
         pr_default.execute(3, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         if ( ! ( (DateTime.MinValue==A153FRUTOPROCESADOReg) || ( DateTimeUtil.ResetTime ( A153FRUTOPROCESADOReg ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo FRUTOPROCESADOReg fuera de rango", "OutOfRange", 1, "FRUTOPROCESADOREG");
            AnyError = 1;
            GX_FocusControl = edtFRUTOPROCESADOReg_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0I19( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_4( string A5Cod_Area )
      {
         /* Using cursor T000I7 */
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
         /* Using cursor T000I8 */
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

      protected void GetKey0I19( )
      {
         /* Using cursor T000I9 */
         pr_default.execute(7, new Object[] {A39FRUTOPROCESADOFec, A40FRUTOPROCESADOMes, A41FRUTOPROCESADOAno, A5Cod_Area, A4IndicadoresCodigo});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound19 = 1;
         }
         else
         {
            RcdFound19 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000I3 */
         pr_default.execute(1, new Object[] {A39FRUTOPROCESADOFec, A40FRUTOPROCESADOMes, A41FRUTOPROCESADOAno, A5Cod_Area, A4IndicadoresCodigo});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0I19( 3) ;
            RcdFound19 = 1;
            A39FRUTOPROCESADOFec = T000I3_A39FRUTOPROCESADOFec[0];
            AssignAttri("", false, "A39FRUTOPROCESADOFec", context.localUtil.Format(A39FRUTOPROCESADOFec, "99/99/99"));
            A40FRUTOPROCESADOMes = T000I3_A40FRUTOPROCESADOMes[0];
            AssignAttri("", false, "A40FRUTOPROCESADOMes", StringUtil.LTrimStr( (decimal)(A40FRUTOPROCESADOMes), 4, 0));
            A41FRUTOPROCESADOAno = T000I3_A41FRUTOPROCESADOAno[0];
            AssignAttri("", false, "A41FRUTOPROCESADOAno", StringUtil.LTrimStr( (decimal)(A41FRUTOPROCESADOAno), 4, 0));
            A151FRUTOPROCESADOValor = T000I3_A151FRUTOPROCESADOValor[0];
            AssignAttri("", false, "A151FRUTOPROCESADOValor", StringUtil.LTrimStr( A151FRUTOPROCESADOValor, 16, 2));
            A152FRUTOPROCESADOUser = T000I3_A152FRUTOPROCESADOUser[0];
            AssignAttri("", false, "A152FRUTOPROCESADOUser", A152FRUTOPROCESADOUser);
            A153FRUTOPROCESADOReg = T000I3_A153FRUTOPROCESADOReg[0];
            AssignAttri("", false, "A153FRUTOPROCESADOReg", context.localUtil.Format(A153FRUTOPROCESADOReg, "99/99/99"));
            A154FRUTOPROCESADOHor = T000I3_A154FRUTOPROCESADOHor[0];
            AssignAttri("", false, "A154FRUTOPROCESADOHor", A154FRUTOPROCESADOHor);
            A5Cod_Area = T000I3_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = T000I3_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            Z39FRUTOPROCESADOFec = A39FRUTOPROCESADOFec;
            Z40FRUTOPROCESADOMes = A40FRUTOPROCESADOMes;
            Z41FRUTOPROCESADOAno = A41FRUTOPROCESADOAno;
            Z5Cod_Area = A5Cod_Area;
            Z4IndicadoresCodigo = A4IndicadoresCodigo;
            sMode19 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0I19( ) ;
            if ( AnyError == 1 )
            {
               RcdFound19 = 0;
               InitializeNonKey0I19( ) ;
            }
            Gx_mode = sMode19;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound19 = 0;
            InitializeNonKey0I19( ) ;
            sMode19 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode19;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0I19( ) ;
         if ( RcdFound19 == 0 )
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
         RcdFound19 = 0;
         /* Using cursor T000I10 */
         pr_default.execute(8, new Object[] {A39FRUTOPROCESADOFec, A40FRUTOPROCESADOMes, A41FRUTOPROCESADOAno, A5Cod_Area, A4IndicadoresCodigo});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( DateTimeUtil.ResetTime ( T000I10_A39FRUTOPROCESADOFec[0] ) < DateTimeUtil.ResetTime ( A39FRUTOPROCESADOFec ) ) || ( DateTimeUtil.ResetTime ( T000I10_A39FRUTOPROCESADOFec[0] ) == DateTimeUtil.ResetTime ( A39FRUTOPROCESADOFec ) ) && ( T000I10_A40FRUTOPROCESADOMes[0] < A40FRUTOPROCESADOMes ) || ( T000I10_A40FRUTOPROCESADOMes[0] == A40FRUTOPROCESADOMes ) && ( DateTimeUtil.ResetTime ( T000I10_A39FRUTOPROCESADOFec[0] ) == DateTimeUtil.ResetTime ( A39FRUTOPROCESADOFec ) ) && ( T000I10_A41FRUTOPROCESADOAno[0] < A41FRUTOPROCESADOAno ) || ( T000I10_A41FRUTOPROCESADOAno[0] == A41FRUTOPROCESADOAno ) && ( T000I10_A40FRUTOPROCESADOMes[0] == A40FRUTOPROCESADOMes ) && ( DateTimeUtil.ResetTime ( T000I10_A39FRUTOPROCESADOFec[0] ) == DateTimeUtil.ResetTime ( A39FRUTOPROCESADOFec ) ) && ( StringUtil.StrCmp(T000I10_A5Cod_Area[0], A5Cod_Area) < 0 ) || ( StringUtil.StrCmp(T000I10_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000I10_A41FRUTOPROCESADOAno[0] == A41FRUTOPROCESADOAno ) && ( T000I10_A40FRUTOPROCESADOMes[0] == A40FRUTOPROCESADOMes ) && ( DateTimeUtil.ResetTime ( T000I10_A39FRUTOPROCESADOFec[0] ) == DateTimeUtil.ResetTime ( A39FRUTOPROCESADOFec ) ) && ( StringUtil.StrCmp(T000I10_A4IndicadoresCodigo[0], A4IndicadoresCodigo) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( DateTimeUtil.ResetTime ( T000I10_A39FRUTOPROCESADOFec[0] ) > DateTimeUtil.ResetTime ( A39FRUTOPROCESADOFec ) ) || ( DateTimeUtil.ResetTime ( T000I10_A39FRUTOPROCESADOFec[0] ) == DateTimeUtil.ResetTime ( A39FRUTOPROCESADOFec ) ) && ( T000I10_A40FRUTOPROCESADOMes[0] > A40FRUTOPROCESADOMes ) || ( T000I10_A40FRUTOPROCESADOMes[0] == A40FRUTOPROCESADOMes ) && ( DateTimeUtil.ResetTime ( T000I10_A39FRUTOPROCESADOFec[0] ) == DateTimeUtil.ResetTime ( A39FRUTOPROCESADOFec ) ) && ( T000I10_A41FRUTOPROCESADOAno[0] > A41FRUTOPROCESADOAno ) || ( T000I10_A41FRUTOPROCESADOAno[0] == A41FRUTOPROCESADOAno ) && ( T000I10_A40FRUTOPROCESADOMes[0] == A40FRUTOPROCESADOMes ) && ( DateTimeUtil.ResetTime ( T000I10_A39FRUTOPROCESADOFec[0] ) == DateTimeUtil.ResetTime ( A39FRUTOPROCESADOFec ) ) && ( StringUtil.StrCmp(T000I10_A5Cod_Area[0], A5Cod_Area) > 0 ) || ( StringUtil.StrCmp(T000I10_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000I10_A41FRUTOPROCESADOAno[0] == A41FRUTOPROCESADOAno ) && ( T000I10_A40FRUTOPROCESADOMes[0] == A40FRUTOPROCESADOMes ) && ( DateTimeUtil.ResetTime ( T000I10_A39FRUTOPROCESADOFec[0] ) == DateTimeUtil.ResetTime ( A39FRUTOPROCESADOFec ) ) && ( StringUtil.StrCmp(T000I10_A4IndicadoresCodigo[0], A4IndicadoresCodigo) > 0 ) ) )
            {
               A39FRUTOPROCESADOFec = T000I10_A39FRUTOPROCESADOFec[0];
               AssignAttri("", false, "A39FRUTOPROCESADOFec", context.localUtil.Format(A39FRUTOPROCESADOFec, "99/99/99"));
               A40FRUTOPROCESADOMes = T000I10_A40FRUTOPROCESADOMes[0];
               AssignAttri("", false, "A40FRUTOPROCESADOMes", StringUtil.LTrimStr( (decimal)(A40FRUTOPROCESADOMes), 4, 0));
               A41FRUTOPROCESADOAno = T000I10_A41FRUTOPROCESADOAno[0];
               AssignAttri("", false, "A41FRUTOPROCESADOAno", StringUtil.LTrimStr( (decimal)(A41FRUTOPROCESADOAno), 4, 0));
               A5Cod_Area = T000I10_A5Cod_Area[0];
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               A4IndicadoresCodigo = T000I10_A4IndicadoresCodigo[0];
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               RcdFound19 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound19 = 0;
         /* Using cursor T000I11 */
         pr_default.execute(9, new Object[] {A39FRUTOPROCESADOFec, A40FRUTOPROCESADOMes, A41FRUTOPROCESADOAno, A5Cod_Area, A4IndicadoresCodigo});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( DateTimeUtil.ResetTime ( T000I11_A39FRUTOPROCESADOFec[0] ) > DateTimeUtil.ResetTime ( A39FRUTOPROCESADOFec ) ) || ( DateTimeUtil.ResetTime ( T000I11_A39FRUTOPROCESADOFec[0] ) == DateTimeUtil.ResetTime ( A39FRUTOPROCESADOFec ) ) && ( T000I11_A40FRUTOPROCESADOMes[0] > A40FRUTOPROCESADOMes ) || ( T000I11_A40FRUTOPROCESADOMes[0] == A40FRUTOPROCESADOMes ) && ( DateTimeUtil.ResetTime ( T000I11_A39FRUTOPROCESADOFec[0] ) == DateTimeUtil.ResetTime ( A39FRUTOPROCESADOFec ) ) && ( T000I11_A41FRUTOPROCESADOAno[0] > A41FRUTOPROCESADOAno ) || ( T000I11_A41FRUTOPROCESADOAno[0] == A41FRUTOPROCESADOAno ) && ( T000I11_A40FRUTOPROCESADOMes[0] == A40FRUTOPROCESADOMes ) && ( DateTimeUtil.ResetTime ( T000I11_A39FRUTOPROCESADOFec[0] ) == DateTimeUtil.ResetTime ( A39FRUTOPROCESADOFec ) ) && ( StringUtil.StrCmp(T000I11_A5Cod_Area[0], A5Cod_Area) > 0 ) || ( StringUtil.StrCmp(T000I11_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000I11_A41FRUTOPROCESADOAno[0] == A41FRUTOPROCESADOAno ) && ( T000I11_A40FRUTOPROCESADOMes[0] == A40FRUTOPROCESADOMes ) && ( DateTimeUtil.ResetTime ( T000I11_A39FRUTOPROCESADOFec[0] ) == DateTimeUtil.ResetTime ( A39FRUTOPROCESADOFec ) ) && ( StringUtil.StrCmp(T000I11_A4IndicadoresCodigo[0], A4IndicadoresCodigo) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( DateTimeUtil.ResetTime ( T000I11_A39FRUTOPROCESADOFec[0] ) < DateTimeUtil.ResetTime ( A39FRUTOPROCESADOFec ) ) || ( DateTimeUtil.ResetTime ( T000I11_A39FRUTOPROCESADOFec[0] ) == DateTimeUtil.ResetTime ( A39FRUTOPROCESADOFec ) ) && ( T000I11_A40FRUTOPROCESADOMes[0] < A40FRUTOPROCESADOMes ) || ( T000I11_A40FRUTOPROCESADOMes[0] == A40FRUTOPROCESADOMes ) && ( DateTimeUtil.ResetTime ( T000I11_A39FRUTOPROCESADOFec[0] ) == DateTimeUtil.ResetTime ( A39FRUTOPROCESADOFec ) ) && ( T000I11_A41FRUTOPROCESADOAno[0] < A41FRUTOPROCESADOAno ) || ( T000I11_A41FRUTOPROCESADOAno[0] == A41FRUTOPROCESADOAno ) && ( T000I11_A40FRUTOPROCESADOMes[0] == A40FRUTOPROCESADOMes ) && ( DateTimeUtil.ResetTime ( T000I11_A39FRUTOPROCESADOFec[0] ) == DateTimeUtil.ResetTime ( A39FRUTOPROCESADOFec ) ) && ( StringUtil.StrCmp(T000I11_A5Cod_Area[0], A5Cod_Area) < 0 ) || ( StringUtil.StrCmp(T000I11_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000I11_A41FRUTOPROCESADOAno[0] == A41FRUTOPROCESADOAno ) && ( T000I11_A40FRUTOPROCESADOMes[0] == A40FRUTOPROCESADOMes ) && ( DateTimeUtil.ResetTime ( T000I11_A39FRUTOPROCESADOFec[0] ) == DateTimeUtil.ResetTime ( A39FRUTOPROCESADOFec ) ) && ( StringUtil.StrCmp(T000I11_A4IndicadoresCodigo[0], A4IndicadoresCodigo) < 0 ) ) )
            {
               A39FRUTOPROCESADOFec = T000I11_A39FRUTOPROCESADOFec[0];
               AssignAttri("", false, "A39FRUTOPROCESADOFec", context.localUtil.Format(A39FRUTOPROCESADOFec, "99/99/99"));
               A40FRUTOPROCESADOMes = T000I11_A40FRUTOPROCESADOMes[0];
               AssignAttri("", false, "A40FRUTOPROCESADOMes", StringUtil.LTrimStr( (decimal)(A40FRUTOPROCESADOMes), 4, 0));
               A41FRUTOPROCESADOAno = T000I11_A41FRUTOPROCESADOAno[0];
               AssignAttri("", false, "A41FRUTOPROCESADOAno", StringUtil.LTrimStr( (decimal)(A41FRUTOPROCESADOAno), 4, 0));
               A5Cod_Area = T000I11_A5Cod_Area[0];
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               A4IndicadoresCodigo = T000I11_A4IndicadoresCodigo[0];
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               RcdFound19 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0I19( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtFRUTOPROCESADOFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0I19( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound19 == 1 )
            {
               if ( ( DateTimeUtil.ResetTime ( A39FRUTOPROCESADOFec ) != DateTimeUtil.ResetTime ( Z39FRUTOPROCESADOFec ) ) || ( A40FRUTOPROCESADOMes != Z40FRUTOPROCESADOMes ) || ( A41FRUTOPROCESADOAno != Z41FRUTOPROCESADOAno ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) )
               {
                  A39FRUTOPROCESADOFec = Z39FRUTOPROCESADOFec;
                  AssignAttri("", false, "A39FRUTOPROCESADOFec", context.localUtil.Format(A39FRUTOPROCESADOFec, "99/99/99"));
                  A40FRUTOPROCESADOMes = Z40FRUTOPROCESADOMes;
                  AssignAttri("", false, "A40FRUTOPROCESADOMes", StringUtil.LTrimStr( (decimal)(A40FRUTOPROCESADOMes), 4, 0));
                  A41FRUTOPROCESADOAno = Z41FRUTOPROCESADOAno;
                  AssignAttri("", false, "A41FRUTOPROCESADOAno", StringUtil.LTrimStr( (decimal)(A41FRUTOPROCESADOAno), 4, 0));
                  A5Cod_Area = Z5Cod_Area;
                  AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
                  A4IndicadoresCodigo = Z4IndicadoresCodigo;
                  AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "FRUTOPROCESADOFEC");
                  AnyError = 1;
                  GX_FocusControl = edtFRUTOPROCESADOFec_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtFRUTOPROCESADOFec_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0I19( ) ;
                  GX_FocusControl = edtFRUTOPROCESADOFec_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( DateTimeUtil.ResetTime ( A39FRUTOPROCESADOFec ) != DateTimeUtil.ResetTime ( Z39FRUTOPROCESADOFec ) ) || ( A40FRUTOPROCESADOMes != Z40FRUTOPROCESADOMes ) || ( A41FRUTOPROCESADOAno != Z41FRUTOPROCESADOAno ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtFRUTOPROCESADOFec_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0I19( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "FRUTOPROCESADOFEC");
                     AnyError = 1;
                     GX_FocusControl = edtFRUTOPROCESADOFec_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtFRUTOPROCESADOFec_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0I19( ) ;
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
         if ( ( DateTimeUtil.ResetTime ( A39FRUTOPROCESADOFec ) != DateTimeUtil.ResetTime ( Z39FRUTOPROCESADOFec ) ) || ( A40FRUTOPROCESADOMes != Z40FRUTOPROCESADOMes ) || ( A41FRUTOPROCESADOAno != Z41FRUTOPROCESADOAno ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) )
         {
            A39FRUTOPROCESADOFec = Z39FRUTOPROCESADOFec;
            AssignAttri("", false, "A39FRUTOPROCESADOFec", context.localUtil.Format(A39FRUTOPROCESADOFec, "99/99/99"));
            A40FRUTOPROCESADOMes = Z40FRUTOPROCESADOMes;
            AssignAttri("", false, "A40FRUTOPROCESADOMes", StringUtil.LTrimStr( (decimal)(A40FRUTOPROCESADOMes), 4, 0));
            A41FRUTOPROCESADOAno = Z41FRUTOPROCESADOAno;
            AssignAttri("", false, "A41FRUTOPROCESADOAno", StringUtil.LTrimStr( (decimal)(A41FRUTOPROCESADOAno), 4, 0));
            A5Cod_Area = Z5Cod_Area;
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = Z4IndicadoresCodigo;
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "FRUTOPROCESADOFEC");
            AnyError = 1;
            GX_FocusControl = edtFRUTOPROCESADOFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtFRUTOPROCESADOFec_Internalname;
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
         if ( RcdFound19 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "FRUTOPROCESADOFEC");
            AnyError = 1;
            GX_FocusControl = edtFRUTOPROCESADOFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtFRUTOPROCESADOValor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0I19( ) ;
         if ( RcdFound19 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtFRUTOPROCESADOValor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0I19( ) ;
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
         if ( RcdFound19 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtFRUTOPROCESADOValor_Internalname;
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
         if ( RcdFound19 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtFRUTOPROCESADOValor_Internalname;
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
         ScanStart0I19( ) ;
         if ( RcdFound19 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound19 != 0 )
            {
               ScanNext0I19( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtFRUTOPROCESADOValor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0I19( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0I19( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000I2 */
            pr_default.execute(0, new Object[] {A39FRUTOPROCESADOFec, A40FRUTOPROCESADOMes, A41FRUTOPROCESADOAno, A5Cod_Area, A4IndicadoresCodigo});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"FRUTOPROCESADO"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z151FRUTOPROCESADOValor != T000I2_A151FRUTOPROCESADOValor[0] ) || ( StringUtil.StrCmp(Z152FRUTOPROCESADOUser, T000I2_A152FRUTOPROCESADOUser[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z153FRUTOPROCESADOReg ) != DateTimeUtil.ResetTime ( T000I2_A153FRUTOPROCESADOReg[0] ) ) || ( StringUtil.StrCmp(Z154FRUTOPROCESADOHor, T000I2_A154FRUTOPROCESADOHor[0]) != 0 ) )
            {
               if ( Z151FRUTOPROCESADOValor != T000I2_A151FRUTOPROCESADOValor[0] )
               {
                  GXUtil.WriteLog("frutoprocesado:[seudo value changed for attri]"+"FRUTOPROCESADOValor");
                  GXUtil.WriteLogRaw("Old: ",Z151FRUTOPROCESADOValor);
                  GXUtil.WriteLogRaw("Current: ",T000I2_A151FRUTOPROCESADOValor[0]);
               }
               if ( StringUtil.StrCmp(Z152FRUTOPROCESADOUser, T000I2_A152FRUTOPROCESADOUser[0]) != 0 )
               {
                  GXUtil.WriteLog("frutoprocesado:[seudo value changed for attri]"+"FRUTOPROCESADOUser");
                  GXUtil.WriteLogRaw("Old: ",Z152FRUTOPROCESADOUser);
                  GXUtil.WriteLogRaw("Current: ",T000I2_A152FRUTOPROCESADOUser[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z153FRUTOPROCESADOReg ) != DateTimeUtil.ResetTime ( T000I2_A153FRUTOPROCESADOReg[0] ) )
               {
                  GXUtil.WriteLog("frutoprocesado:[seudo value changed for attri]"+"FRUTOPROCESADOReg");
                  GXUtil.WriteLogRaw("Old: ",Z153FRUTOPROCESADOReg);
                  GXUtil.WriteLogRaw("Current: ",T000I2_A153FRUTOPROCESADOReg[0]);
               }
               if ( StringUtil.StrCmp(Z154FRUTOPROCESADOHor, T000I2_A154FRUTOPROCESADOHor[0]) != 0 )
               {
                  GXUtil.WriteLog("frutoprocesado:[seudo value changed for attri]"+"FRUTOPROCESADOHor");
                  GXUtil.WriteLogRaw("Old: ",Z154FRUTOPROCESADOHor);
                  GXUtil.WriteLogRaw("Current: ",T000I2_A154FRUTOPROCESADOHor[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"FRUTOPROCESADO"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0I19( )
      {
         BeforeValidate0I19( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0I19( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0I19( 0) ;
            CheckOptimisticConcurrency0I19( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0I19( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0I19( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000I12 */
                     pr_default.execute(10, new Object[] {A39FRUTOPROCESADOFec, A40FRUTOPROCESADOMes, A41FRUTOPROCESADOAno, A151FRUTOPROCESADOValor, A152FRUTOPROCESADOUser, A153FRUTOPROCESADOReg, A154FRUTOPROCESADOHor, A5Cod_Area, A4IndicadoresCodigo});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("FRUTOPROCESADO");
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
                           ResetCaption0I0( ) ;
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
               Load0I19( ) ;
            }
            EndLevel0I19( ) ;
         }
         CloseExtendedTableCursors0I19( ) ;
      }

      protected void Update0I19( )
      {
         BeforeValidate0I19( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0I19( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0I19( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0I19( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0I19( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000I13 */
                     pr_default.execute(11, new Object[] {A151FRUTOPROCESADOValor, A152FRUTOPROCESADOUser, A153FRUTOPROCESADOReg, A154FRUTOPROCESADOHor, A39FRUTOPROCESADOFec, A40FRUTOPROCESADOMes, A41FRUTOPROCESADOAno, A5Cod_Area, A4IndicadoresCodigo});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("FRUTOPROCESADO");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"FRUTOPROCESADO"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0I19( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0I0( ) ;
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
            EndLevel0I19( ) ;
         }
         CloseExtendedTableCursors0I19( ) ;
      }

      protected void DeferredUpdate0I19( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0I19( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0I19( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0I19( ) ;
            AfterConfirm0I19( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0I19( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000I14 */
                  pr_default.execute(12, new Object[] {A39FRUTOPROCESADOFec, A40FRUTOPROCESADOMes, A41FRUTOPROCESADOAno, A5Cod_Area, A4IndicadoresCodigo});
                  pr_default.close(12);
                  pr_default.SmartCacheProvider.SetUpdated("FRUTOPROCESADO");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound19 == 0 )
                        {
                           InitAll0I19( ) ;
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
                        ResetCaption0I0( ) ;
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
         sMode19 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0I19( ) ;
         Gx_mode = sMode19;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0I19( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0I19( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0I19( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("frutoprocesado",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0I0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("frutoprocesado",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0I19( )
      {
         /* Using cursor T000I15 */
         pr_default.execute(13);
         RcdFound19 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound19 = 1;
            A39FRUTOPROCESADOFec = T000I15_A39FRUTOPROCESADOFec[0];
            AssignAttri("", false, "A39FRUTOPROCESADOFec", context.localUtil.Format(A39FRUTOPROCESADOFec, "99/99/99"));
            A40FRUTOPROCESADOMes = T000I15_A40FRUTOPROCESADOMes[0];
            AssignAttri("", false, "A40FRUTOPROCESADOMes", StringUtil.LTrimStr( (decimal)(A40FRUTOPROCESADOMes), 4, 0));
            A41FRUTOPROCESADOAno = T000I15_A41FRUTOPROCESADOAno[0];
            AssignAttri("", false, "A41FRUTOPROCESADOAno", StringUtil.LTrimStr( (decimal)(A41FRUTOPROCESADOAno), 4, 0));
            A5Cod_Area = T000I15_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = T000I15_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0I19( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound19 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound19 = 1;
            A39FRUTOPROCESADOFec = T000I15_A39FRUTOPROCESADOFec[0];
            AssignAttri("", false, "A39FRUTOPROCESADOFec", context.localUtil.Format(A39FRUTOPROCESADOFec, "99/99/99"));
            A40FRUTOPROCESADOMes = T000I15_A40FRUTOPROCESADOMes[0];
            AssignAttri("", false, "A40FRUTOPROCESADOMes", StringUtil.LTrimStr( (decimal)(A40FRUTOPROCESADOMes), 4, 0));
            A41FRUTOPROCESADOAno = T000I15_A41FRUTOPROCESADOAno[0];
            AssignAttri("", false, "A41FRUTOPROCESADOAno", StringUtil.LTrimStr( (decimal)(A41FRUTOPROCESADOAno), 4, 0));
            A5Cod_Area = T000I15_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = T000I15_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
         }
      }

      protected void ScanEnd0I19( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm0I19( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0I19( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0I19( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0I19( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0I19( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0I19( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0I19( )
      {
         edtFRUTOPROCESADOFec_Enabled = 0;
         AssignProp("", false, edtFRUTOPROCESADOFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFRUTOPROCESADOFec_Enabled), 5, 0), true);
         edtFRUTOPROCESADOMes_Enabled = 0;
         AssignProp("", false, edtFRUTOPROCESADOMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFRUTOPROCESADOMes_Enabled), 5, 0), true);
         edtFRUTOPROCESADOAno_Enabled = 0;
         AssignProp("", false, edtFRUTOPROCESADOAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFRUTOPROCESADOAno_Enabled), 5, 0), true);
         edtCod_Area_Enabled = 0;
         AssignProp("", false, edtCod_Area_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCod_Area_Enabled), 5, 0), true);
         edtIndicadoresCodigo_Enabled = 0;
         AssignProp("", false, edtIndicadoresCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIndicadoresCodigo_Enabled), 5, 0), true);
         edtFRUTOPROCESADOValor_Enabled = 0;
         AssignProp("", false, edtFRUTOPROCESADOValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFRUTOPROCESADOValor_Enabled), 5, 0), true);
         edtFRUTOPROCESADOUser_Enabled = 0;
         AssignProp("", false, edtFRUTOPROCESADOUser_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFRUTOPROCESADOUser_Enabled), 5, 0), true);
         edtFRUTOPROCESADOReg_Enabled = 0;
         AssignProp("", false, edtFRUTOPROCESADOReg_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFRUTOPROCESADOReg_Enabled), 5, 0), true);
         edtFRUTOPROCESADOHor_Enabled = 0;
         AssignProp("", false, edtFRUTOPROCESADOHor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFRUTOPROCESADOHor_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0I19( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0I0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("frutoprocesado.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z39FRUTOPROCESADOFec", context.localUtil.DToC( Z39FRUTOPROCESADOFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z40FRUTOPROCESADOMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z40FRUTOPROCESADOMes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z41FRUTOPROCESADOAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z41FRUTOPROCESADOAno), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z5Cod_Area", Z5Cod_Area);
         GxWebStd.gx_hidden_field( context, "Z4IndicadoresCodigo", Z4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "Z151FRUTOPROCESADOValor", StringUtil.LTrim( StringUtil.NToC( Z151FRUTOPROCESADOValor, 16, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z152FRUTOPROCESADOUser", Z152FRUTOPROCESADOUser);
         GxWebStd.gx_hidden_field( context, "Z153FRUTOPROCESADOReg", context.localUtil.DToC( Z153FRUTOPROCESADOReg, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z154FRUTOPROCESADOHor", Z154FRUTOPROCESADOHor);
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
         return formatLink("frutoprocesado.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "FRUTOPROCESADO" ;
      }

      public override string GetPgmdesc( )
      {
         return "FRUTOPROCESADO" ;
      }

      protected void InitializeNonKey0I19( )
      {
         A151FRUTOPROCESADOValor = 0;
         AssignAttri("", false, "A151FRUTOPROCESADOValor", StringUtil.LTrimStr( A151FRUTOPROCESADOValor, 16, 2));
         A152FRUTOPROCESADOUser = "";
         AssignAttri("", false, "A152FRUTOPROCESADOUser", A152FRUTOPROCESADOUser);
         A153FRUTOPROCESADOReg = DateTime.MinValue;
         AssignAttri("", false, "A153FRUTOPROCESADOReg", context.localUtil.Format(A153FRUTOPROCESADOReg, "99/99/99"));
         A154FRUTOPROCESADOHor = "";
         AssignAttri("", false, "A154FRUTOPROCESADOHor", A154FRUTOPROCESADOHor);
         Z151FRUTOPROCESADOValor = 0;
         Z152FRUTOPROCESADOUser = "";
         Z153FRUTOPROCESADOReg = DateTime.MinValue;
         Z154FRUTOPROCESADOHor = "";
      }

      protected void InitAll0I19( )
      {
         A39FRUTOPROCESADOFec = DateTime.MinValue;
         AssignAttri("", false, "A39FRUTOPROCESADOFec", context.localUtil.Format(A39FRUTOPROCESADOFec, "99/99/99"));
         A40FRUTOPROCESADOMes = 0;
         AssignAttri("", false, "A40FRUTOPROCESADOMes", StringUtil.LTrimStr( (decimal)(A40FRUTOPROCESADOMes), 4, 0));
         A41FRUTOPROCESADOAno = 0;
         AssignAttri("", false, "A41FRUTOPROCESADOAno", StringUtil.LTrimStr( (decimal)(A41FRUTOPROCESADOAno), 4, 0));
         A5Cod_Area = "";
         AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
         A4IndicadoresCodigo = "";
         AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
         InitializeNonKey0I19( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20247231022762", true, true);
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
         context.AddJavascriptSource("frutoprocesado.js", "?20247231022762", false, true);
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
         edtFRUTOPROCESADOFec_Internalname = "FRUTOPROCESADOFEC";
         edtFRUTOPROCESADOMes_Internalname = "FRUTOPROCESADOMES";
         edtFRUTOPROCESADOAno_Internalname = "FRUTOPROCESADOANO";
         edtCod_Area_Internalname = "COD_AREA";
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO";
         edtFRUTOPROCESADOValor_Internalname = "FRUTOPROCESADOVALOR";
         edtFRUTOPROCESADOUser_Internalname = "FRUTOPROCESADOUSER";
         edtFRUTOPROCESADOReg_Internalname = "FRUTOPROCESADOREG";
         edtFRUTOPROCESADOHor_Internalname = "FRUTOPROCESADOHOR";
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
         Form.Caption = "FRUTOPROCESADO";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtFRUTOPROCESADOHor_Jsonclick = "";
         edtFRUTOPROCESADOHor_Enabled = 1;
         edtFRUTOPROCESADOReg_Jsonclick = "";
         edtFRUTOPROCESADOReg_Enabled = 1;
         edtFRUTOPROCESADOUser_Enabled = 1;
         edtFRUTOPROCESADOValor_Jsonclick = "";
         edtFRUTOPROCESADOValor_Enabled = 1;
         imgprompt_4_Visible = 1;
         imgprompt_4_Link = "";
         edtIndicadoresCodigo_Jsonclick = "";
         edtIndicadoresCodigo_Enabled = 1;
         imgprompt_5_Visible = 1;
         imgprompt_5_Link = "";
         edtCod_Area_Jsonclick = "";
         edtCod_Area_Enabled = 1;
         edtFRUTOPROCESADOAno_Jsonclick = "";
         edtFRUTOPROCESADOAno_Enabled = 1;
         edtFRUTOPROCESADOMes_Jsonclick = "";
         edtFRUTOPROCESADOMes_Enabled = 1;
         edtFRUTOPROCESADOFec_Jsonclick = "";
         edtFRUTOPROCESADOFec_Enabled = 1;
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
         /* Using cursor T000I16 */
         pr_default.execute(14, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(14);
         /* Using cursor T000I17 */
         pr_default.execute(15, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(15);
         GX_FocusControl = edtFRUTOPROCESADOValor_Internalname;
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
         /* Using cursor T000I16 */
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
         /* Using cursor T000I17 */
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
         AssignAttri("", false, "A151FRUTOPROCESADOValor", StringUtil.LTrim( StringUtil.NToC( A151FRUTOPROCESADOValor, 16, 2, ".", "")));
         AssignAttri("", false, "A152FRUTOPROCESADOUser", A152FRUTOPROCESADOUser);
         AssignAttri("", false, "A153FRUTOPROCESADOReg", context.localUtil.Format(A153FRUTOPROCESADOReg, "99/99/99"));
         AssignAttri("", false, "A154FRUTOPROCESADOHor", A154FRUTOPROCESADOHor);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z39FRUTOPROCESADOFec", context.localUtil.Format(Z39FRUTOPROCESADOFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z40FRUTOPROCESADOMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z40FRUTOPROCESADOMes), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z41FRUTOPROCESADOAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z41FRUTOPROCESADOAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z5Cod_Area", Z5Cod_Area);
         GxWebStd.gx_hidden_field( context, "Z4IndicadoresCodigo", Z4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "Z151FRUTOPROCESADOValor", StringUtil.LTrim( StringUtil.NToC( Z151FRUTOPROCESADOValor, 16, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z152FRUTOPROCESADOUser", Z152FRUTOPROCESADOUser);
         GxWebStd.gx_hidden_field( context, "Z153FRUTOPROCESADOReg", context.localUtil.Format(Z153FRUTOPROCESADOReg, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z154FRUTOPROCESADOHor", Z154FRUTOPROCESADOHor);
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
         setEventMetadata("VALID_FRUTOPROCESADOFEC","{handler:'Valid_Frutoprocesadofec',iparms:[]");
         setEventMetadata("VALID_FRUTOPROCESADOFEC",",oparms:[]}");
         setEventMetadata("VALID_FRUTOPROCESADOMES","{handler:'Valid_Frutoprocesadomes',iparms:[]");
         setEventMetadata("VALID_FRUTOPROCESADOMES",",oparms:[]}");
         setEventMetadata("VALID_FRUTOPROCESADOANO","{handler:'Valid_Frutoprocesadoano',iparms:[]");
         setEventMetadata("VALID_FRUTOPROCESADOANO",",oparms:[]}");
         setEventMetadata("VALID_COD_AREA","{handler:'Valid_Cod_area',iparms:[{av:'A5Cod_Area',fld:'COD_AREA',pic:''}]");
         setEventMetadata("VALID_COD_AREA",",oparms:[]}");
         setEventMetadata("VALID_INDICADORESCODIGO","{handler:'Valid_Indicadorescodigo',iparms:[{av:'A39FRUTOPROCESADOFec',fld:'FRUTOPROCESADOFEC',pic:''},{av:'A40FRUTOPROCESADOMes',fld:'FRUTOPROCESADOMES',pic:'ZZZ9'},{av:'A41FRUTOPROCESADOAno',fld:'FRUTOPROCESADOANO',pic:'ZZZ9'},{av:'A5Cod_Area',fld:'COD_AREA',pic:''},{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_INDICADORESCODIGO",",oparms:[{av:'A151FRUTOPROCESADOValor',fld:'FRUTOPROCESADOVALOR',pic:'ZZZZZZZZZZZZ9.99'},{av:'A152FRUTOPROCESADOUser',fld:'FRUTOPROCESADOUSER',pic:''},{av:'A153FRUTOPROCESADOReg',fld:'FRUTOPROCESADOREG',pic:''},{av:'A154FRUTOPROCESADOHor',fld:'FRUTOPROCESADOHOR',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z39FRUTOPROCESADOFec'},{av:'Z40FRUTOPROCESADOMes'},{av:'Z41FRUTOPROCESADOAno'},{av:'Z5Cod_Area'},{av:'Z4IndicadoresCodigo'},{av:'Z151FRUTOPROCESADOValor'},{av:'Z152FRUTOPROCESADOUser'},{av:'Z153FRUTOPROCESADOReg'},{av:'Z154FRUTOPROCESADOHor'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_FRUTOPROCESADOREG","{handler:'Valid_Frutoprocesadoreg',iparms:[]");
         setEventMetadata("VALID_FRUTOPROCESADOREG",",oparms:[]}");
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
         Z39FRUTOPROCESADOFec = DateTime.MinValue;
         Z5Cod_Area = "";
         Z4IndicadoresCodigo = "";
         Z152FRUTOPROCESADOUser = "";
         Z153FRUTOPROCESADOReg = DateTime.MinValue;
         Z154FRUTOPROCESADOHor = "";
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
         A39FRUTOPROCESADOFec = DateTime.MinValue;
         imgprompt_5_gximage = "";
         sImgUrl = "";
         imgprompt_4_gximage = "";
         A152FRUTOPROCESADOUser = "";
         A153FRUTOPROCESADOReg = DateTime.MinValue;
         A154FRUTOPROCESADOHor = "";
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
         T000I6_A39FRUTOPROCESADOFec = new DateTime[] {DateTime.MinValue} ;
         T000I6_A40FRUTOPROCESADOMes = new short[1] ;
         T000I6_A41FRUTOPROCESADOAno = new short[1] ;
         T000I6_A151FRUTOPROCESADOValor = new decimal[1] ;
         T000I6_A152FRUTOPROCESADOUser = new string[] {""} ;
         T000I6_A153FRUTOPROCESADOReg = new DateTime[] {DateTime.MinValue} ;
         T000I6_A154FRUTOPROCESADOHor = new string[] {""} ;
         T000I6_A5Cod_Area = new string[] {""} ;
         T000I6_A4IndicadoresCodigo = new string[] {""} ;
         T000I4_A5Cod_Area = new string[] {""} ;
         T000I5_A4IndicadoresCodigo = new string[] {""} ;
         T000I7_A5Cod_Area = new string[] {""} ;
         T000I8_A4IndicadoresCodigo = new string[] {""} ;
         T000I9_A39FRUTOPROCESADOFec = new DateTime[] {DateTime.MinValue} ;
         T000I9_A40FRUTOPROCESADOMes = new short[1] ;
         T000I9_A41FRUTOPROCESADOAno = new short[1] ;
         T000I9_A5Cod_Area = new string[] {""} ;
         T000I9_A4IndicadoresCodigo = new string[] {""} ;
         T000I3_A39FRUTOPROCESADOFec = new DateTime[] {DateTime.MinValue} ;
         T000I3_A40FRUTOPROCESADOMes = new short[1] ;
         T000I3_A41FRUTOPROCESADOAno = new short[1] ;
         T000I3_A151FRUTOPROCESADOValor = new decimal[1] ;
         T000I3_A152FRUTOPROCESADOUser = new string[] {""} ;
         T000I3_A153FRUTOPROCESADOReg = new DateTime[] {DateTime.MinValue} ;
         T000I3_A154FRUTOPROCESADOHor = new string[] {""} ;
         T000I3_A5Cod_Area = new string[] {""} ;
         T000I3_A4IndicadoresCodigo = new string[] {""} ;
         sMode19 = "";
         T000I10_A39FRUTOPROCESADOFec = new DateTime[] {DateTime.MinValue} ;
         T000I10_A40FRUTOPROCESADOMes = new short[1] ;
         T000I10_A41FRUTOPROCESADOAno = new short[1] ;
         T000I10_A5Cod_Area = new string[] {""} ;
         T000I10_A4IndicadoresCodigo = new string[] {""} ;
         T000I11_A39FRUTOPROCESADOFec = new DateTime[] {DateTime.MinValue} ;
         T000I11_A40FRUTOPROCESADOMes = new short[1] ;
         T000I11_A41FRUTOPROCESADOAno = new short[1] ;
         T000I11_A5Cod_Area = new string[] {""} ;
         T000I11_A4IndicadoresCodigo = new string[] {""} ;
         T000I2_A39FRUTOPROCESADOFec = new DateTime[] {DateTime.MinValue} ;
         T000I2_A40FRUTOPROCESADOMes = new short[1] ;
         T000I2_A41FRUTOPROCESADOAno = new short[1] ;
         T000I2_A151FRUTOPROCESADOValor = new decimal[1] ;
         T000I2_A152FRUTOPROCESADOUser = new string[] {""} ;
         T000I2_A153FRUTOPROCESADOReg = new DateTime[] {DateTime.MinValue} ;
         T000I2_A154FRUTOPROCESADOHor = new string[] {""} ;
         T000I2_A5Cod_Area = new string[] {""} ;
         T000I2_A4IndicadoresCodigo = new string[] {""} ;
         T000I15_A39FRUTOPROCESADOFec = new DateTime[] {DateTime.MinValue} ;
         T000I15_A40FRUTOPROCESADOMes = new short[1] ;
         T000I15_A41FRUTOPROCESADOAno = new short[1] ;
         T000I15_A5Cod_Area = new string[] {""} ;
         T000I15_A4IndicadoresCodigo = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T000I16_A5Cod_Area = new string[] {""} ;
         T000I17_A4IndicadoresCodigo = new string[] {""} ;
         ZZ39FRUTOPROCESADOFec = DateTime.MinValue;
         ZZ5Cod_Area = "";
         ZZ4IndicadoresCodigo = "";
         ZZ152FRUTOPROCESADOUser = "";
         ZZ153FRUTOPROCESADOReg = DateTime.MinValue;
         ZZ154FRUTOPROCESADOHor = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.frutoprocesado__default(),
            new Object[][] {
                new Object[] {
               T000I2_A39FRUTOPROCESADOFec, T000I2_A40FRUTOPROCESADOMes, T000I2_A41FRUTOPROCESADOAno, T000I2_A151FRUTOPROCESADOValor, T000I2_A152FRUTOPROCESADOUser, T000I2_A153FRUTOPROCESADOReg, T000I2_A154FRUTOPROCESADOHor, T000I2_A5Cod_Area, T000I2_A4IndicadoresCodigo
               }
               , new Object[] {
               T000I3_A39FRUTOPROCESADOFec, T000I3_A40FRUTOPROCESADOMes, T000I3_A41FRUTOPROCESADOAno, T000I3_A151FRUTOPROCESADOValor, T000I3_A152FRUTOPROCESADOUser, T000I3_A153FRUTOPROCESADOReg, T000I3_A154FRUTOPROCESADOHor, T000I3_A5Cod_Area, T000I3_A4IndicadoresCodigo
               }
               , new Object[] {
               T000I4_A5Cod_Area
               }
               , new Object[] {
               T000I5_A4IndicadoresCodigo
               }
               , new Object[] {
               T000I6_A39FRUTOPROCESADOFec, T000I6_A40FRUTOPROCESADOMes, T000I6_A41FRUTOPROCESADOAno, T000I6_A151FRUTOPROCESADOValor, T000I6_A152FRUTOPROCESADOUser, T000I6_A153FRUTOPROCESADOReg, T000I6_A154FRUTOPROCESADOHor, T000I6_A5Cod_Area, T000I6_A4IndicadoresCodigo
               }
               , new Object[] {
               T000I7_A5Cod_Area
               }
               , new Object[] {
               T000I8_A4IndicadoresCodigo
               }
               , new Object[] {
               T000I9_A39FRUTOPROCESADOFec, T000I9_A40FRUTOPROCESADOMes, T000I9_A41FRUTOPROCESADOAno, T000I9_A5Cod_Area, T000I9_A4IndicadoresCodigo
               }
               , new Object[] {
               T000I10_A39FRUTOPROCESADOFec, T000I10_A40FRUTOPROCESADOMes, T000I10_A41FRUTOPROCESADOAno, T000I10_A5Cod_Area, T000I10_A4IndicadoresCodigo
               }
               , new Object[] {
               T000I11_A39FRUTOPROCESADOFec, T000I11_A40FRUTOPROCESADOMes, T000I11_A41FRUTOPROCESADOAno, T000I11_A5Cod_Area, T000I11_A4IndicadoresCodigo
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000I15_A39FRUTOPROCESADOFec, T000I15_A40FRUTOPROCESADOMes, T000I15_A41FRUTOPROCESADOAno, T000I15_A5Cod_Area, T000I15_A4IndicadoresCodigo
               }
               , new Object[] {
               T000I16_A5Cod_Area
               }
               , new Object[] {
               T000I17_A4IndicadoresCodigo
               }
            }
         );
      }

      private short Z40FRUTOPROCESADOMes ;
      private short Z41FRUTOPROCESADOAno ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A40FRUTOPROCESADOMes ;
      private short A41FRUTOPROCESADOAno ;
      private short GX_JID ;
      private short RcdFound19 ;
      private short nIsDirty_19 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ40FRUTOPROCESADOMes ;
      private short ZZ41FRUTOPROCESADOAno ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtFRUTOPROCESADOFec_Enabled ;
      private int edtFRUTOPROCESADOMes_Enabled ;
      private int edtFRUTOPROCESADOAno_Enabled ;
      private int edtCod_Area_Enabled ;
      private int imgprompt_5_Visible ;
      private int edtIndicadoresCodigo_Enabled ;
      private int imgprompt_4_Visible ;
      private int edtFRUTOPROCESADOValor_Enabled ;
      private int edtFRUTOPROCESADOUser_Enabled ;
      private int edtFRUTOPROCESADOReg_Enabled ;
      private int edtFRUTOPROCESADOHor_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private decimal Z151FRUTOPROCESADOValor ;
      private decimal A151FRUTOPROCESADOValor ;
      private decimal ZZ151FRUTOPROCESADOValor ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtFRUTOPROCESADOFec_Internalname ;
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
      private string edtFRUTOPROCESADOFec_Jsonclick ;
      private string edtFRUTOPROCESADOMes_Internalname ;
      private string edtFRUTOPROCESADOMes_Jsonclick ;
      private string edtFRUTOPROCESADOAno_Internalname ;
      private string edtFRUTOPROCESADOAno_Jsonclick ;
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
      private string edtFRUTOPROCESADOValor_Internalname ;
      private string edtFRUTOPROCESADOValor_Jsonclick ;
      private string edtFRUTOPROCESADOUser_Internalname ;
      private string edtFRUTOPROCESADOReg_Internalname ;
      private string edtFRUTOPROCESADOReg_Jsonclick ;
      private string edtFRUTOPROCESADOHor_Internalname ;
      private string edtFRUTOPROCESADOHor_Jsonclick ;
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
      private string sMode19 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z39FRUTOPROCESADOFec ;
      private DateTime Z153FRUTOPROCESADOReg ;
      private DateTime A39FRUTOPROCESADOFec ;
      private DateTime A153FRUTOPROCESADOReg ;
      private DateTime ZZ39FRUTOPROCESADOFec ;
      private DateTime ZZ153FRUTOPROCESADOReg ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string Z5Cod_Area ;
      private string Z4IndicadoresCodigo ;
      private string Z152FRUTOPROCESADOUser ;
      private string Z154FRUTOPROCESADOHor ;
      private string A5Cod_Area ;
      private string A4IndicadoresCodigo ;
      private string A152FRUTOPROCESADOUser ;
      private string A154FRUTOPROCESADOHor ;
      private string ZZ5Cod_Area ;
      private string ZZ4IndicadoresCodigo ;
      private string ZZ152FRUTOPROCESADOUser ;
      private string ZZ154FRUTOPROCESADOHor ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] T000I6_A39FRUTOPROCESADOFec ;
      private short[] T000I6_A40FRUTOPROCESADOMes ;
      private short[] T000I6_A41FRUTOPROCESADOAno ;
      private decimal[] T000I6_A151FRUTOPROCESADOValor ;
      private string[] T000I6_A152FRUTOPROCESADOUser ;
      private DateTime[] T000I6_A153FRUTOPROCESADOReg ;
      private string[] T000I6_A154FRUTOPROCESADOHor ;
      private string[] T000I6_A5Cod_Area ;
      private string[] T000I6_A4IndicadoresCodigo ;
      private string[] T000I4_A5Cod_Area ;
      private string[] T000I5_A4IndicadoresCodigo ;
      private string[] T000I7_A5Cod_Area ;
      private string[] T000I8_A4IndicadoresCodigo ;
      private DateTime[] T000I9_A39FRUTOPROCESADOFec ;
      private short[] T000I9_A40FRUTOPROCESADOMes ;
      private short[] T000I9_A41FRUTOPROCESADOAno ;
      private string[] T000I9_A5Cod_Area ;
      private string[] T000I9_A4IndicadoresCodigo ;
      private DateTime[] T000I3_A39FRUTOPROCESADOFec ;
      private short[] T000I3_A40FRUTOPROCESADOMes ;
      private short[] T000I3_A41FRUTOPROCESADOAno ;
      private decimal[] T000I3_A151FRUTOPROCESADOValor ;
      private string[] T000I3_A152FRUTOPROCESADOUser ;
      private DateTime[] T000I3_A153FRUTOPROCESADOReg ;
      private string[] T000I3_A154FRUTOPROCESADOHor ;
      private string[] T000I3_A5Cod_Area ;
      private string[] T000I3_A4IndicadoresCodigo ;
      private DateTime[] T000I10_A39FRUTOPROCESADOFec ;
      private short[] T000I10_A40FRUTOPROCESADOMes ;
      private short[] T000I10_A41FRUTOPROCESADOAno ;
      private string[] T000I10_A5Cod_Area ;
      private string[] T000I10_A4IndicadoresCodigo ;
      private DateTime[] T000I11_A39FRUTOPROCESADOFec ;
      private short[] T000I11_A40FRUTOPROCESADOMes ;
      private short[] T000I11_A41FRUTOPROCESADOAno ;
      private string[] T000I11_A5Cod_Area ;
      private string[] T000I11_A4IndicadoresCodigo ;
      private DateTime[] T000I2_A39FRUTOPROCESADOFec ;
      private short[] T000I2_A40FRUTOPROCESADOMes ;
      private short[] T000I2_A41FRUTOPROCESADOAno ;
      private decimal[] T000I2_A151FRUTOPROCESADOValor ;
      private string[] T000I2_A152FRUTOPROCESADOUser ;
      private DateTime[] T000I2_A153FRUTOPROCESADOReg ;
      private string[] T000I2_A154FRUTOPROCESADOHor ;
      private string[] T000I2_A5Cod_Area ;
      private string[] T000I2_A4IndicadoresCodigo ;
      private DateTime[] T000I15_A39FRUTOPROCESADOFec ;
      private short[] T000I15_A40FRUTOPROCESADOMes ;
      private short[] T000I15_A41FRUTOPROCESADOAno ;
      private string[] T000I15_A5Cod_Area ;
      private string[] T000I15_A4IndicadoresCodigo ;
      private string[] T000I16_A5Cod_Area ;
      private string[] T000I17_A4IndicadoresCodigo ;
      private GXWebForm Form ;
   }

   public class frutoprocesado__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT000I6;
          prmT000I6 = new Object[] {
          new ParDef("@FRUTOPROCESADOFec",GXType.Date,8,0) ,
          new ParDef("@FRUTOPROCESADOMes",GXType.Int16,4,0) ,
          new ParDef("@FRUTOPROCESADOAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000I4;
          prmT000I4 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000I5;
          prmT000I5 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000I7;
          prmT000I7 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000I8;
          prmT000I8 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000I9;
          prmT000I9 = new Object[] {
          new ParDef("@FRUTOPROCESADOFec",GXType.Date,8,0) ,
          new ParDef("@FRUTOPROCESADOMes",GXType.Int16,4,0) ,
          new ParDef("@FRUTOPROCESADOAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000I3;
          prmT000I3 = new Object[] {
          new ParDef("@FRUTOPROCESADOFec",GXType.Date,8,0) ,
          new ParDef("@FRUTOPROCESADOMes",GXType.Int16,4,0) ,
          new ParDef("@FRUTOPROCESADOAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000I10;
          prmT000I10 = new Object[] {
          new ParDef("@FRUTOPROCESADOFec",GXType.Date,8,0) ,
          new ParDef("@FRUTOPROCESADOMes",GXType.Int16,4,0) ,
          new ParDef("@FRUTOPROCESADOAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000I11;
          prmT000I11 = new Object[] {
          new ParDef("@FRUTOPROCESADOFec",GXType.Date,8,0) ,
          new ParDef("@FRUTOPROCESADOMes",GXType.Int16,4,0) ,
          new ParDef("@FRUTOPROCESADOAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000I2;
          prmT000I2 = new Object[] {
          new ParDef("@FRUTOPROCESADOFec",GXType.Date,8,0) ,
          new ParDef("@FRUTOPROCESADOMes",GXType.Int16,4,0) ,
          new ParDef("@FRUTOPROCESADOAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000I12;
          prmT000I12 = new Object[] {
          new ParDef("@FRUTOPROCESADOFec",GXType.Date,8,0) ,
          new ParDef("@FRUTOPROCESADOMes",GXType.Int16,4,0) ,
          new ParDef("@FRUTOPROCESADOAno",GXType.Int16,4,0) ,
          new ParDef("@FRUTOPROCESADOValor",GXType.Decimal,16,2) ,
          new ParDef("@FRUTOPROCESADOUser",GXType.NVarChar,200,0) ,
          new ParDef("@FRUTOPROCESADOReg",GXType.Date,8,0) ,
          new ParDef("@FRUTOPROCESADOHor",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000I13;
          prmT000I13 = new Object[] {
          new ParDef("@FRUTOPROCESADOValor",GXType.Decimal,16,2) ,
          new ParDef("@FRUTOPROCESADOUser",GXType.NVarChar,200,0) ,
          new ParDef("@FRUTOPROCESADOReg",GXType.Date,8,0) ,
          new ParDef("@FRUTOPROCESADOHor",GXType.NVarChar,40,0) ,
          new ParDef("@FRUTOPROCESADOFec",GXType.Date,8,0) ,
          new ParDef("@FRUTOPROCESADOMes",GXType.Int16,4,0) ,
          new ParDef("@FRUTOPROCESADOAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000I14;
          prmT000I14 = new Object[] {
          new ParDef("@FRUTOPROCESADOFec",GXType.Date,8,0) ,
          new ParDef("@FRUTOPROCESADOMes",GXType.Int16,4,0) ,
          new ParDef("@FRUTOPROCESADOAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000I15;
          prmT000I15 = new Object[] {
          };
          Object[] prmT000I16;
          prmT000I16 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000I17;
          prmT000I17 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("T000I2", "SELECT [FRUTOPROCESADOFec], [FRUTOPROCESADOMes], [FRUTOPROCESADOAno], [FRUTOPROCESADOValor], [FRUTOPROCESADOUser], [FRUTOPROCESADOReg], [FRUTOPROCESADOHor], [Cod_Area], [IndicadoresCodigo] FROM [FRUTOPROCESADO] WITH (UPDLOCK) WHERE [FRUTOPROCESADOFec] = @FRUTOPROCESADOFec AND [FRUTOPROCESADOMes] = @FRUTOPROCESADOMes AND [FRUTOPROCESADOAno] = @FRUTOPROCESADOAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000I3", "SELECT [FRUTOPROCESADOFec], [FRUTOPROCESADOMes], [FRUTOPROCESADOAno], [FRUTOPROCESADOValor], [FRUTOPROCESADOUser], [FRUTOPROCESADOReg], [FRUTOPROCESADOHor], [Cod_Area], [IndicadoresCodigo] FROM [FRUTOPROCESADO] WHERE [FRUTOPROCESADOFec] = @FRUTOPROCESADOFec AND [FRUTOPROCESADOMes] = @FRUTOPROCESADOMes AND [FRUTOPROCESADOAno] = @FRUTOPROCESADOAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000I4", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000I5", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000I6", "SELECT TM1.[FRUTOPROCESADOFec], TM1.[FRUTOPROCESADOMes], TM1.[FRUTOPROCESADOAno], TM1.[FRUTOPROCESADOValor], TM1.[FRUTOPROCESADOUser], TM1.[FRUTOPROCESADOReg], TM1.[FRUTOPROCESADOHor], TM1.[Cod_Area], TM1.[IndicadoresCodigo] FROM [FRUTOPROCESADO] TM1 WHERE TM1.[FRUTOPROCESADOFec] = @FRUTOPROCESADOFec and TM1.[FRUTOPROCESADOMes] = @FRUTOPROCESADOMes and TM1.[FRUTOPROCESADOAno] = @FRUTOPROCESADOAno and TM1.[Cod_Area] = @Cod_Area and TM1.[IndicadoresCodigo] = @IndicadoresCodigo ORDER BY TM1.[FRUTOPROCESADOFec], TM1.[FRUTOPROCESADOMes], TM1.[FRUTOPROCESADOAno], TM1.[Cod_Area], TM1.[IndicadoresCodigo]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000I6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000I7", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000I8", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000I9", "SELECT [FRUTOPROCESADOFec], [FRUTOPROCESADOMes], [FRUTOPROCESADOAno], [Cod_Area], [IndicadoresCodigo] FROM [FRUTOPROCESADO] WHERE [FRUTOPROCESADOFec] = @FRUTOPROCESADOFec AND [FRUTOPROCESADOMes] = @FRUTOPROCESADOMes AND [FRUTOPROCESADOAno] = @FRUTOPROCESADOAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000I9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000I10", "SELECT TOP 1 [FRUTOPROCESADOFec], [FRUTOPROCESADOMes], [FRUTOPROCESADOAno], [Cod_Area], [IndicadoresCodigo] FROM [FRUTOPROCESADO] WHERE ( [FRUTOPROCESADOFec] > @FRUTOPROCESADOFec or [FRUTOPROCESADOFec] = @FRUTOPROCESADOFec and [FRUTOPROCESADOMes] > @FRUTOPROCESADOMes or [FRUTOPROCESADOMes] = @FRUTOPROCESADOMes and [FRUTOPROCESADOFec] = @FRUTOPROCESADOFec and [FRUTOPROCESADOAno] > @FRUTOPROCESADOAno or [FRUTOPROCESADOAno] = @FRUTOPROCESADOAno and [FRUTOPROCESADOMes] = @FRUTOPROCESADOMes and [FRUTOPROCESADOFec] = @FRUTOPROCESADOFec and [Cod_Area] > @Cod_Area or [Cod_Area] = @Cod_Area and [FRUTOPROCESADOAno] = @FRUTOPROCESADOAno and [FRUTOPROCESADOMes] = @FRUTOPROCESADOMes and [FRUTOPROCESADOFec] = @FRUTOPROCESADOFec and [IndicadoresCodigo] > @IndicadoresCodigo) ORDER BY [FRUTOPROCESADOFec], [FRUTOPROCESADOMes], [FRUTOPROCESADOAno], [Cod_Area], [IndicadoresCodigo]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000I10,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000I11", "SELECT TOP 1 [FRUTOPROCESADOFec], [FRUTOPROCESADOMes], [FRUTOPROCESADOAno], [Cod_Area], [IndicadoresCodigo] FROM [FRUTOPROCESADO] WHERE ( [FRUTOPROCESADOFec] < @FRUTOPROCESADOFec or [FRUTOPROCESADOFec] = @FRUTOPROCESADOFec and [FRUTOPROCESADOMes] < @FRUTOPROCESADOMes or [FRUTOPROCESADOMes] = @FRUTOPROCESADOMes and [FRUTOPROCESADOFec] = @FRUTOPROCESADOFec and [FRUTOPROCESADOAno] < @FRUTOPROCESADOAno or [FRUTOPROCESADOAno] = @FRUTOPROCESADOAno and [FRUTOPROCESADOMes] = @FRUTOPROCESADOMes and [FRUTOPROCESADOFec] = @FRUTOPROCESADOFec and [Cod_Area] < @Cod_Area or [Cod_Area] = @Cod_Area and [FRUTOPROCESADOAno] = @FRUTOPROCESADOAno and [FRUTOPROCESADOMes] = @FRUTOPROCESADOMes and [FRUTOPROCESADOFec] = @FRUTOPROCESADOFec and [IndicadoresCodigo] < @IndicadoresCodigo) ORDER BY [FRUTOPROCESADOFec] DESC, [FRUTOPROCESADOMes] DESC, [FRUTOPROCESADOAno] DESC, [Cod_Area] DESC, [IndicadoresCodigo] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000I11,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000I12", "INSERT INTO [FRUTOPROCESADO]([FRUTOPROCESADOFec], [FRUTOPROCESADOMes], [FRUTOPROCESADOAno], [FRUTOPROCESADOValor], [FRUTOPROCESADOUser], [FRUTOPROCESADOReg], [FRUTOPROCESADOHor], [Cod_Area], [IndicadoresCodigo]) VALUES(@FRUTOPROCESADOFec, @FRUTOPROCESADOMes, @FRUTOPROCESADOAno, @FRUTOPROCESADOValor, @FRUTOPROCESADOUser, @FRUTOPROCESADOReg, @FRUTOPROCESADOHor, @Cod_Area, @IndicadoresCodigo)", GxErrorMask.GX_NOMASK,prmT000I12)
             ,new CursorDef("T000I13", "UPDATE [FRUTOPROCESADO] SET [FRUTOPROCESADOValor]=@FRUTOPROCESADOValor, [FRUTOPROCESADOUser]=@FRUTOPROCESADOUser, [FRUTOPROCESADOReg]=@FRUTOPROCESADOReg, [FRUTOPROCESADOHor]=@FRUTOPROCESADOHor  WHERE [FRUTOPROCESADOFec] = @FRUTOPROCESADOFec AND [FRUTOPROCESADOMes] = @FRUTOPROCESADOMes AND [FRUTOPROCESADOAno] = @FRUTOPROCESADOAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo", GxErrorMask.GX_NOMASK,prmT000I13)
             ,new CursorDef("T000I14", "DELETE FROM [FRUTOPROCESADO]  WHERE [FRUTOPROCESADOFec] = @FRUTOPROCESADOFec AND [FRUTOPROCESADOMes] = @FRUTOPROCESADOMes AND [FRUTOPROCESADOAno] = @FRUTOPROCESADOAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo", GxErrorMask.GX_NOMASK,prmT000I14)
             ,new CursorDef("T000I15", "SELECT [FRUTOPROCESADOFec], [FRUTOPROCESADOMes], [FRUTOPROCESADOAno], [Cod_Area], [IndicadoresCodigo] FROM [FRUTOPROCESADO] ORDER BY [FRUTOPROCESADOFec], [FRUTOPROCESADOMes], [FRUTOPROCESADOAno], [Cod_Area], [IndicadoresCodigo]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000I15,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000I16", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I16,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000I17", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I17,1, GxCacheFrequency.OFF ,true,false )
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
