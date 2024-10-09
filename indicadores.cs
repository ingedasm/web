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
   public class indicadores : GXDataArea
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
            Form.Meta.addItem("description", "Indicadores", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("IndicadroresPalmas", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public indicadores( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("IndicadroresPalmas", true);
      }

      public indicadores( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Indicadores", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Indicadores.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Indicadores.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Indicadores.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Indicadores.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Indicadores.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 4, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx0030.aspx"+"',["+"{Ctrl:gx.dom.el('"+"INDICADORESCODIGO"+"'), id:'"+"INDICADORESCODIGO"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_Indicadores.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtIndicadoresCodigo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtIndicadoresCodigo_Internalname, "Codigo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIndicadoresCodigo_Internalname, A4IndicadoresCodigo, StringUtil.RTrim( context.localUtil.Format( A4IndicadoresCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIndicadoresCodigo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIndicadoresCodigo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Indicadores.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtIndicadoresSigla_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtIndicadoresSigla_Internalname, "Sigla", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIndicadoresSigla_Internalname, A128IndicadoresSigla, StringUtil.RTrim( context.localUtil.Format( A128IndicadoresSigla, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIndicadoresSigla_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIndicadoresSigla_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Indicadores.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtIndicadoresNombres_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtIndicadoresNombres_Internalname, "Nombres", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtIndicadoresNombres_Internalname, A121IndicadoresNombres, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", 0, 1, edtIndicadoresNombres_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Indicadores.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtIndicadoresFormula_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtIndicadoresFormula_Internalname, "Formula", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtIndicadoresFormula_Internalname, A122IndicadoresFormula, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", 0, 1, edtIndicadoresFormula_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Indicadores.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtIndicadoresConsecutivo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtIndicadoresConsecutivo_Internalname, "Consecutivo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIndicadoresConsecutivo_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A123IndicadoresConsecutivo), 4, 0, ",", "")), StringUtil.LTrim( ((edtIndicadoresConsecutivo_Enabled!=0) ? context.localUtil.Format( (decimal)(A123IndicadoresConsecutivo), "ZZZ9") : context.localUtil.Format( (decimal)(A123IndicadoresConsecutivo), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIndicadoresConsecutivo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIndicadoresConsecutivo_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Indicadores.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Indicadores.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Indicadores.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Indicadores.htm");
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
            Z4IndicadoresCodigo = cgiGet( "Z4IndicadoresCodigo");
            Z128IndicadoresSigla = cgiGet( "Z128IndicadoresSigla");
            n128IndicadoresSigla = (String.IsNullOrEmpty(StringUtil.RTrim( A128IndicadoresSigla)) ? true : false);
            Z121IndicadoresNombres = cgiGet( "Z121IndicadoresNombres");
            Z122IndicadoresFormula = cgiGet( "Z122IndicadoresFormula");
            n122IndicadoresFormula = (String.IsNullOrEmpty(StringUtil.RTrim( A122IndicadoresFormula)) ? true : false);
            Z123IndicadoresConsecutivo = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z123IndicadoresConsecutivo"), ",", "."), 18, MidpointRounding.ToEven));
            n123IndicadoresConsecutivo = ((0==A123IndicadoresConsecutivo) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A4IndicadoresCodigo = cgiGet( edtIndicadoresCodigo_Internalname);
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A128IndicadoresSigla = cgiGet( edtIndicadoresSigla_Internalname);
            n128IndicadoresSigla = false;
            AssignAttri("", false, "A128IndicadoresSigla", A128IndicadoresSigla);
            n128IndicadoresSigla = (String.IsNullOrEmpty(StringUtil.RTrim( A128IndicadoresSigla)) ? true : false);
            A121IndicadoresNombres = cgiGet( edtIndicadoresNombres_Internalname);
            AssignAttri("", false, "A121IndicadoresNombres", A121IndicadoresNombres);
            A122IndicadoresFormula = cgiGet( edtIndicadoresFormula_Internalname);
            n122IndicadoresFormula = false;
            AssignAttri("", false, "A122IndicadoresFormula", A122IndicadoresFormula);
            n122IndicadoresFormula = (String.IsNullOrEmpty(StringUtil.RTrim( A122IndicadoresFormula)) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtIndicadoresConsecutivo_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtIndicadoresConsecutivo_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "INDICADORESCONSECUTIVO");
               AnyError = 1;
               GX_FocusControl = edtIndicadoresConsecutivo_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A123IndicadoresConsecutivo = 0;
               n123IndicadoresConsecutivo = false;
               AssignAttri("", false, "A123IndicadoresConsecutivo", StringUtil.LTrimStr( (decimal)(A123IndicadoresConsecutivo), 4, 0));
            }
            else
            {
               A123IndicadoresConsecutivo = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtIndicadoresConsecutivo_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n123IndicadoresConsecutivo = false;
               AssignAttri("", false, "A123IndicadoresConsecutivo", StringUtil.LTrimStr( (decimal)(A123IndicadoresConsecutivo), 4, 0));
            }
            n123IndicadoresConsecutivo = ((0==A123IndicadoresConsecutivo) ? true : false);
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
               InitAll043( ) ;
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
         DisableAttributes043( ) ;
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

      protected void ResetCaption040( )
      {
      }

      protected void ZM043( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z128IndicadoresSigla = T00043_A128IndicadoresSigla[0];
               Z121IndicadoresNombres = T00043_A121IndicadoresNombres[0];
               Z122IndicadoresFormula = T00043_A122IndicadoresFormula[0];
               Z123IndicadoresConsecutivo = T00043_A123IndicadoresConsecutivo[0];
            }
            else
            {
               Z128IndicadoresSigla = A128IndicadoresSigla;
               Z121IndicadoresNombres = A121IndicadoresNombres;
               Z122IndicadoresFormula = A122IndicadoresFormula;
               Z123IndicadoresConsecutivo = A123IndicadoresConsecutivo;
            }
         }
         if ( GX_JID == -1 )
         {
            Z4IndicadoresCodigo = A4IndicadoresCodigo;
            Z128IndicadoresSigla = A128IndicadoresSigla;
            Z121IndicadoresNombres = A121IndicadoresNombres;
            Z122IndicadoresFormula = A122IndicadoresFormula;
            Z123IndicadoresConsecutivo = A123IndicadoresConsecutivo;
         }
      }

      protected void standaloneNotModal( )
      {
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

      protected void Load043( )
      {
         /* Using cursor T00044 */
         pr_default.execute(2, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound3 = 1;
            A128IndicadoresSigla = T00044_A128IndicadoresSigla[0];
            n128IndicadoresSigla = T00044_n128IndicadoresSigla[0];
            AssignAttri("", false, "A128IndicadoresSigla", A128IndicadoresSigla);
            A121IndicadoresNombres = T00044_A121IndicadoresNombres[0];
            AssignAttri("", false, "A121IndicadoresNombres", A121IndicadoresNombres);
            A122IndicadoresFormula = T00044_A122IndicadoresFormula[0];
            n122IndicadoresFormula = T00044_n122IndicadoresFormula[0];
            AssignAttri("", false, "A122IndicadoresFormula", A122IndicadoresFormula);
            A123IndicadoresConsecutivo = T00044_A123IndicadoresConsecutivo[0];
            n123IndicadoresConsecutivo = T00044_n123IndicadoresConsecutivo[0];
            AssignAttri("", false, "A123IndicadoresConsecutivo", StringUtil.LTrimStr( (decimal)(A123IndicadoresConsecutivo), 4, 0));
            ZM043( -1) ;
         }
         pr_default.close(2);
         OnLoadActions043( ) ;
      }

      protected void OnLoadActions043( )
      {
      }

      protected void CheckExtendedTable043( )
      {
         nIsDirty_3 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors043( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey043( )
      {
         /* Using cursor T00045 */
         pr_default.execute(3, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound3 = 1;
         }
         else
         {
            RcdFound3 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00043 */
         pr_default.execute(1, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM043( 1) ;
            RcdFound3 = 1;
            A4IndicadoresCodigo = T00043_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A128IndicadoresSigla = T00043_A128IndicadoresSigla[0];
            n128IndicadoresSigla = T00043_n128IndicadoresSigla[0];
            AssignAttri("", false, "A128IndicadoresSigla", A128IndicadoresSigla);
            A121IndicadoresNombres = T00043_A121IndicadoresNombres[0];
            AssignAttri("", false, "A121IndicadoresNombres", A121IndicadoresNombres);
            A122IndicadoresFormula = T00043_A122IndicadoresFormula[0];
            n122IndicadoresFormula = T00043_n122IndicadoresFormula[0];
            AssignAttri("", false, "A122IndicadoresFormula", A122IndicadoresFormula);
            A123IndicadoresConsecutivo = T00043_A123IndicadoresConsecutivo[0];
            n123IndicadoresConsecutivo = T00043_n123IndicadoresConsecutivo[0];
            AssignAttri("", false, "A123IndicadoresConsecutivo", StringUtil.LTrimStr( (decimal)(A123IndicadoresConsecutivo), 4, 0));
            Z4IndicadoresCodigo = A4IndicadoresCodigo;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load043( ) ;
            if ( AnyError == 1 )
            {
               RcdFound3 = 0;
               InitializeNonKey043( ) ;
            }
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound3 = 0;
            InitializeNonKey043( ) ;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey043( ) ;
         if ( RcdFound3 == 0 )
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
         RcdFound3 = 0;
         /* Using cursor T00046 */
         pr_default.execute(4, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T00046_A4IndicadoresCodigo[0], A4IndicadoresCodigo) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T00046_A4IndicadoresCodigo[0], A4IndicadoresCodigo) > 0 ) ) )
            {
               A4IndicadoresCodigo = T00046_A4IndicadoresCodigo[0];
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               RcdFound3 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound3 = 0;
         /* Using cursor T00047 */
         pr_default.execute(5, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T00047_A4IndicadoresCodigo[0], A4IndicadoresCodigo) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T00047_A4IndicadoresCodigo[0], A4IndicadoresCodigo) < 0 ) ) )
            {
               A4IndicadoresCodigo = T00047_A4IndicadoresCodigo[0];
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               RcdFound3 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey043( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert043( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound3 == 1 )
            {
               if ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 )
               {
                  A4IndicadoresCodigo = Z4IndicadoresCodigo;
                  AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "INDICADORESCODIGO");
                  AnyError = 1;
                  GX_FocusControl = edtIndicadoresCodigo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtIndicadoresCodigo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update043( ) ;
                  GX_FocusControl = edtIndicadoresCodigo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtIndicadoresCodigo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert043( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "INDICADORESCODIGO");
                     AnyError = 1;
                     GX_FocusControl = edtIndicadoresCodigo_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtIndicadoresCodigo_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert043( ) ;
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
         if ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 )
         {
            A4IndicadoresCodigo = Z4IndicadoresCodigo;
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
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
         if ( RcdFound3 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtIndicadoresSigla_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart043( ) ;
         if ( RcdFound3 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtIndicadoresSigla_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd043( ) ;
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
         if ( RcdFound3 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtIndicadoresSigla_Internalname;
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
         if ( RcdFound3 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtIndicadoresSigla_Internalname;
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
         ScanStart043( ) ;
         if ( RcdFound3 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound3 != 0 )
            {
               ScanNext043( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtIndicadoresSigla_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd043( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency043( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00042 */
            pr_default.execute(0, new Object[] {A4IndicadoresCodigo});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Indicadores"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z128IndicadoresSigla, T00042_A128IndicadoresSigla[0]) != 0 ) || ( StringUtil.StrCmp(Z121IndicadoresNombres, T00042_A121IndicadoresNombres[0]) != 0 ) || ( StringUtil.StrCmp(Z122IndicadoresFormula, T00042_A122IndicadoresFormula[0]) != 0 ) || ( Z123IndicadoresConsecutivo != T00042_A123IndicadoresConsecutivo[0] ) )
            {
               if ( StringUtil.StrCmp(Z128IndicadoresSigla, T00042_A128IndicadoresSigla[0]) != 0 )
               {
                  GXUtil.WriteLog("indicadores:[seudo value changed for attri]"+"IndicadoresSigla");
                  GXUtil.WriteLogRaw("Old: ",Z128IndicadoresSigla);
                  GXUtil.WriteLogRaw("Current: ",T00042_A128IndicadoresSigla[0]);
               }
               if ( StringUtil.StrCmp(Z121IndicadoresNombres, T00042_A121IndicadoresNombres[0]) != 0 )
               {
                  GXUtil.WriteLog("indicadores:[seudo value changed for attri]"+"IndicadoresNombres");
                  GXUtil.WriteLogRaw("Old: ",Z121IndicadoresNombres);
                  GXUtil.WriteLogRaw("Current: ",T00042_A121IndicadoresNombres[0]);
               }
               if ( StringUtil.StrCmp(Z122IndicadoresFormula, T00042_A122IndicadoresFormula[0]) != 0 )
               {
                  GXUtil.WriteLog("indicadores:[seudo value changed for attri]"+"IndicadoresFormula");
                  GXUtil.WriteLogRaw("Old: ",Z122IndicadoresFormula);
                  GXUtil.WriteLogRaw("Current: ",T00042_A122IndicadoresFormula[0]);
               }
               if ( Z123IndicadoresConsecutivo != T00042_A123IndicadoresConsecutivo[0] )
               {
                  GXUtil.WriteLog("indicadores:[seudo value changed for attri]"+"IndicadoresConsecutivo");
                  GXUtil.WriteLogRaw("Old: ",Z123IndicadoresConsecutivo);
                  GXUtil.WriteLogRaw("Current: ",T00042_A123IndicadoresConsecutivo[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Indicadores"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert043( )
      {
         BeforeValidate043( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable043( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM043( 0) ;
            CheckOptimisticConcurrency043( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm043( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert043( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00048 */
                     pr_default.execute(6, new Object[] {A4IndicadoresCodigo, n128IndicadoresSigla, A128IndicadoresSigla, A121IndicadoresNombres, n122IndicadoresFormula, A122IndicadoresFormula, n123IndicadoresConsecutivo, A123IndicadoresConsecutivo});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Indicadores");
                     if ( (pr_default.getStatus(6) == 1) )
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
                           ResetCaption040( ) ;
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
               Load043( ) ;
            }
            EndLevel043( ) ;
         }
         CloseExtendedTableCursors043( ) ;
      }

      protected void Update043( )
      {
         BeforeValidate043( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable043( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency043( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm043( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate043( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00049 */
                     pr_default.execute(7, new Object[] {n128IndicadoresSigla, A128IndicadoresSigla, A121IndicadoresNombres, n122IndicadoresFormula, A122IndicadoresFormula, n123IndicadoresConsecutivo, A123IndicadoresConsecutivo, A4IndicadoresCodigo});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Indicadores");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Indicadores"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate043( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption040( ) ;
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
            EndLevel043( ) ;
         }
         CloseExtendedTableCursors043( ) ;
      }

      protected void DeferredUpdate043( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate043( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency043( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls043( ) ;
            AfterConfirm043( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete043( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000410 */
                  pr_default.execute(8, new Object[] {A4IndicadoresCodigo});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("Indicadores");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound3 == 0 )
                        {
                           InitAll043( ) ;
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
                        ResetCaption040( ) ;
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
         sMode3 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel043( ) ;
         Gx_mode = sMode3;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls043( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000411 */
            pr_default.execute(9, new Object[] {A4IndicadoresCodigo});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Parametros"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor T000412 */
            pr_default.execute(10, new Object[] {A4IndicadoresCodigo});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"RFF_COMPRADA"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor T000413 */
            pr_default.execute(11, new Object[] {A4IndicadoresCodigo});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"PRECNETOTONCPO"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor T000414 */
            pr_default.execute(12, new Object[] {A4IndicadoresCodigo});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"COSTONRFFPROCES"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T000415 */
            pr_default.execute(13, new Object[] {A4IndicadoresCodigo});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"COSTOTONRFFPRODU"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor T000416 */
            pr_default.execute(14, new Object[] {A4IndicadoresCodigo});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"COSTOCPOPRODUCIDO"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T000417 */
            pr_default.execute(15, new Object[] {A4IndicadoresCodigo});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"MARGENEBITDA"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T000418 */
            pr_default.execute(16, new Object[] {A4IndicadoresCodigo});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"INCIDENCIAPC"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor T000419 */
            pr_default.execute(17, new Object[] {A4IndicadoresCodigo});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"COSTONRFFPROD"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor T000420 */
            pr_default.execute(18, new Object[] {A4IndicadoresCodigo});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"HATRABAJADORES"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
            /* Using cursor T000421 */
            pr_default.execute(19, new Object[] {A4IndicadoresCodigo});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"TONCPOHA"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
            /* Using cursor T000422 */
            pr_default.execute(20, new Object[] {A4IndicadoresCodigo});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"FRUTAPROPIA"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
            /* Using cursor T000423 */
            pr_default.execute(21, new Object[] {A4IndicadoresCodigo});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"COSTONRFFPROCESADA"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
            /* Using cursor T000424 */
            pr_default.execute(22, new Object[] {A4IndicadoresCodigo});
            if ( (pr_default.getStatus(22) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Acidez"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(22);
            /* Using cursor T000425 */
            pr_default.execute(23, new Object[] {A4IndicadoresCodigo});
            if ( (pr_default.getStatus(23) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"TEA"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(23);
            /* Using cursor T000426 */
            pr_default.execute(24, new Object[] {A4IndicadoresCodigo});
            if ( (pr_default.getStatus(24) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"FRUTOPROCESADO"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(24);
            /* Using cursor T000427 */
            pr_default.execute(25, new Object[] {A4IndicadoresCodigo});
            if ( (pr_default.getStatus(25) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"COSTOCPOHA"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(25);
            /* Using cursor T000428 */
            pr_default.execute(26, new Object[] {A4IndicadoresCodigo});
            if ( (pr_default.getStatus(26) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Metas Indicadores"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(26);
            /* Using cursor T000429 */
            pr_default.execute(27, new Object[] {A4IndicadoresCodigo});
            if ( (pr_default.getStatus(27) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"PAGOFRUTA"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(27);
            /* Using cursor T000430 */
            pr_default.execute(28, new Object[] {A4IndicadoresCodigo});
            if ( (pr_default.getStatus(28) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"COSUSPTONFRUTA"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(28);
            /* Using cursor T000431 */
            pr_default.execute(29, new Object[] {A4IndicadoresCodigo});
            if ( (pr_default.getStatus(29) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"TRIF"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(29);
            /* Using cursor T000432 */
            pr_default.execute(30, new Object[] {A4IndicadoresCodigo});
            if ( (pr_default.getStatus(30) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"COSTOHE"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(30);
            /* Using cursor T000433 */
            pr_default.execute(31, new Object[] {A4IndicadoresCodigo});
            if ( (pr_default.getStatus(31) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ACCDAG"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(31);
            /* Using cursor T000434 */
            pr_default.execute(32, new Object[] {A4IndicadoresCodigo});
            if ( (pr_default.getStatus(32) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Area"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(32);
         }
      }

      protected void EndLevel043( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete043( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("indicadores",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues040( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("indicadores",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart043( )
      {
         /* Using cursor T000435 */
         pr_default.execute(33);
         RcdFound3 = 0;
         if ( (pr_default.getStatus(33) != 101) )
         {
            RcdFound3 = 1;
            A4IndicadoresCodigo = T000435_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext043( )
      {
         /* Scan next routine */
         pr_default.readNext(33);
         RcdFound3 = 0;
         if ( (pr_default.getStatus(33) != 101) )
         {
            RcdFound3 = 1;
            A4IndicadoresCodigo = T000435_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
         }
      }

      protected void ScanEnd043( )
      {
         pr_default.close(33);
      }

      protected void AfterConfirm043( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert043( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate043( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete043( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete043( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate043( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes043( )
      {
         edtIndicadoresCodigo_Enabled = 0;
         AssignProp("", false, edtIndicadoresCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIndicadoresCodigo_Enabled), 5, 0), true);
         edtIndicadoresSigla_Enabled = 0;
         AssignProp("", false, edtIndicadoresSigla_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIndicadoresSigla_Enabled), 5, 0), true);
         edtIndicadoresNombres_Enabled = 0;
         AssignProp("", false, edtIndicadoresNombres_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIndicadoresNombres_Enabled), 5, 0), true);
         edtIndicadoresFormula_Enabled = 0;
         AssignProp("", false, edtIndicadoresFormula_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIndicadoresFormula_Enabled), 5, 0), true);
         edtIndicadoresConsecutivo_Enabled = 0;
         AssignProp("", false, edtIndicadoresConsecutivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIndicadoresConsecutivo_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes043( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues040( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("indicadores.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z4IndicadoresCodigo", Z4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "Z128IndicadoresSigla", Z128IndicadoresSigla);
         GxWebStd.gx_hidden_field( context, "Z121IndicadoresNombres", Z121IndicadoresNombres);
         GxWebStd.gx_hidden_field( context, "Z122IndicadoresFormula", Z122IndicadoresFormula);
         GxWebStd.gx_hidden_field( context, "Z123IndicadoresConsecutivo", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z123IndicadoresConsecutivo), 4, 0, ",", "")));
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
         return formatLink("indicadores.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Indicadores" ;
      }

      public override string GetPgmdesc( )
      {
         return "Indicadores" ;
      }

      protected void InitializeNonKey043( )
      {
         A128IndicadoresSigla = "";
         n128IndicadoresSigla = false;
         AssignAttri("", false, "A128IndicadoresSigla", A128IndicadoresSigla);
         n128IndicadoresSigla = (String.IsNullOrEmpty(StringUtil.RTrim( A128IndicadoresSigla)) ? true : false);
         A121IndicadoresNombres = "";
         AssignAttri("", false, "A121IndicadoresNombres", A121IndicadoresNombres);
         A122IndicadoresFormula = "";
         n122IndicadoresFormula = false;
         AssignAttri("", false, "A122IndicadoresFormula", A122IndicadoresFormula);
         n122IndicadoresFormula = (String.IsNullOrEmpty(StringUtil.RTrim( A122IndicadoresFormula)) ? true : false);
         A123IndicadoresConsecutivo = 0;
         n123IndicadoresConsecutivo = false;
         AssignAttri("", false, "A123IndicadoresConsecutivo", StringUtil.LTrimStr( (decimal)(A123IndicadoresConsecutivo), 4, 0));
         n123IndicadoresConsecutivo = ((0==A123IndicadoresConsecutivo) ? true : false);
         Z128IndicadoresSigla = "";
         Z121IndicadoresNombres = "";
         Z122IndicadoresFormula = "";
         Z123IndicadoresConsecutivo = 0;
      }

      protected void InitAll043( )
      {
         A4IndicadoresCodigo = "";
         AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
         InitializeNonKey043( ) ;
      }

      protected void StandaloneModalInsert( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20247231014375", true, true);
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
         context.AddJavascriptSource("indicadores.js", "?20247231014375", false, true);
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
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO";
         edtIndicadoresSigla_Internalname = "INDICADORESSIGLA";
         edtIndicadoresNombres_Internalname = "INDICADORESNOMBRES";
         edtIndicadoresFormula_Internalname = "INDICADORESFORMULA";
         edtIndicadoresConsecutivo_Internalname = "INDICADORESCONSECUTIVO";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
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
         Form.Caption = "Indicadores";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtIndicadoresConsecutivo_Jsonclick = "";
         edtIndicadoresConsecutivo_Enabled = 1;
         edtIndicadoresFormula_Enabled = 1;
         edtIndicadoresNombres_Enabled = 1;
         edtIndicadoresSigla_Jsonclick = "";
         edtIndicadoresSigla_Enabled = 1;
         edtIndicadoresCodigo_Jsonclick = "";
         edtIndicadoresCodigo_Enabled = 1;
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
         GX_FocusControl = edtIndicadoresSigla_Internalname;
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

      public void Valid_Indicadorescodigo( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A128IndicadoresSigla", A128IndicadoresSigla);
         AssignAttri("", false, "A121IndicadoresNombres", A121IndicadoresNombres);
         AssignAttri("", false, "A122IndicadoresFormula", A122IndicadoresFormula);
         AssignAttri("", false, "A123IndicadoresConsecutivo", StringUtil.LTrim( StringUtil.NToC( (decimal)(A123IndicadoresConsecutivo), 4, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z4IndicadoresCodigo", Z4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "Z128IndicadoresSigla", Z128IndicadoresSigla);
         GxWebStd.gx_hidden_field( context, "Z121IndicadoresNombres", Z121IndicadoresNombres);
         GxWebStd.gx_hidden_field( context, "Z122IndicadoresFormula", Z122IndicadoresFormula);
         GxWebStd.gx_hidden_field( context, "Z123IndicadoresConsecutivo", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z123IndicadoresConsecutivo), 4, 0, ".", "")));
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
         setEventMetadata("VALID_INDICADORESCODIGO","{handler:'Valid_Indicadorescodigo',iparms:[{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_INDICADORESCODIGO",",oparms:[{av:'A128IndicadoresSigla',fld:'INDICADORESSIGLA',pic:''},{av:'A121IndicadoresNombres',fld:'INDICADORESNOMBRES',pic:''},{av:'A122IndicadoresFormula',fld:'INDICADORESFORMULA',pic:''},{av:'A123IndicadoresConsecutivo',fld:'INDICADORESCONSECUTIVO',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z4IndicadoresCodigo'},{av:'Z128IndicadoresSigla'},{av:'Z121IndicadoresNombres'},{av:'Z122IndicadoresFormula'},{av:'Z123IndicadoresConsecutivo'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z4IndicadoresCodigo = "";
         Z128IndicadoresSigla = "";
         Z121IndicadoresNombres = "";
         Z122IndicadoresFormula = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
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
         A4IndicadoresCodigo = "";
         A128IndicadoresSigla = "";
         A121IndicadoresNombres = "";
         A122IndicadoresFormula = "";
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
         T00044_A4IndicadoresCodigo = new string[] {""} ;
         T00044_A128IndicadoresSigla = new string[] {""} ;
         T00044_n128IndicadoresSigla = new bool[] {false} ;
         T00044_A121IndicadoresNombres = new string[] {""} ;
         T00044_A122IndicadoresFormula = new string[] {""} ;
         T00044_n122IndicadoresFormula = new bool[] {false} ;
         T00044_A123IndicadoresConsecutivo = new short[1] ;
         T00044_n123IndicadoresConsecutivo = new bool[] {false} ;
         T00045_A4IndicadoresCodigo = new string[] {""} ;
         T00043_A4IndicadoresCodigo = new string[] {""} ;
         T00043_A128IndicadoresSigla = new string[] {""} ;
         T00043_n128IndicadoresSigla = new bool[] {false} ;
         T00043_A121IndicadoresNombres = new string[] {""} ;
         T00043_A122IndicadoresFormula = new string[] {""} ;
         T00043_n122IndicadoresFormula = new bool[] {false} ;
         T00043_A123IndicadoresConsecutivo = new short[1] ;
         T00043_n123IndicadoresConsecutivo = new bool[] {false} ;
         sMode3 = "";
         T00046_A4IndicadoresCodigo = new string[] {""} ;
         T00047_A4IndicadoresCodigo = new string[] {""} ;
         T00042_A4IndicadoresCodigo = new string[] {""} ;
         T00042_A128IndicadoresSigla = new string[] {""} ;
         T00042_n128IndicadoresSigla = new bool[] {false} ;
         T00042_A121IndicadoresNombres = new string[] {""} ;
         T00042_A122IndicadoresFormula = new string[] {""} ;
         T00042_n122IndicadoresFormula = new bool[] {false} ;
         T00042_A123IndicadoresConsecutivo = new short[1] ;
         T00042_n123IndicadoresConsecutivo = new bool[] {false} ;
         T000411_A35ParametrosCodigo = new short[1] ;
         T000412_A86RFF_COMPRADAFecha = new DateTime[] {DateTime.MinValue} ;
         T000412_A5Cod_Area = new string[] {""} ;
         T000412_A4IndicadoresCodigo = new string[] {""} ;
         T000412_A87RFF_COMPRADAMes = new short[1] ;
         T000412_A88RFF_COMPRADAAno = new short[1] ;
         T000412_A89RFF_COMPRAPRODUCUP = new string[] {""} ;
         T000413_A83PRECNETOTONCPOFecha = new DateTime[] {DateTime.MinValue} ;
         T000413_A84PRECNETOTONCPOMes = new short[1] ;
         T000413_A85PRECNETOTONCPOAno = new short[1] ;
         T000413_A5Cod_Area = new string[] {""} ;
         T000413_A4IndicadoresCodigo = new string[] {""} ;
         T000413_A67MOTIVOSPRENETCodigo = new string[] {""} ;
         T000414_A80COSTONRFFPROCESFecha = new DateTime[] {DateTime.MinValue} ;
         T000414_A81COSTONRFFPROCESMes = new short[1] ;
         T000414_A82COSTONRFFPROCESAno = new short[1] ;
         T000414_A5Cod_Area = new string[] {""} ;
         T000414_A4IndicadoresCodigo = new string[] {""} ;
         T000414_A66MOTIVOSCOSRFFCodigo = new string[] {""} ;
         T000415_A77COSTOTONRFFPRODUFecha = new DateTime[] {DateTime.MinValue} ;
         T000415_A78COSTOTONRFFPRODUMes = new short[1] ;
         T000415_A79COSTOTONRFFPRODUAno = new short[1] ;
         T000415_A5Cod_Area = new string[] {""} ;
         T000415_A4IndicadoresCodigo = new string[] {""} ;
         T000415_A65MOTIVOTONRFFcod = new string[] {""} ;
         T000416_A109COSTOCPOPRODUCIDOFecha = new DateTime[] {DateTime.MinValue} ;
         T000416_A110COSTOCPOPRODUCIDOMes = new short[1] ;
         T000416_A111COSTOCPOPRODUCIDOAno = new short[1] ;
         T000416_A5Cod_Area = new string[] {""} ;
         T000416_A4IndicadoresCodigo = new string[] {""} ;
         T000416_A64TIPOSCPOCod = new string[] {""} ;
         T000416_A45TipoProductoCod = new string[] {""} ;
         T000417_A74MARGENEBITDAFecha = new DateTime[] {DateTime.MinValue} ;
         T000417_A75MARGENEBITDAMes = new short[1] ;
         T000417_A76MARGENEBITDAAno = new short[1] ;
         T000417_A5Cod_Area = new string[] {""} ;
         T000417_A4IndicadoresCodigo = new string[] {""} ;
         T000417_A63MOTIVOMARGENCod = new string[] {""} ;
         T000418_A104INCIDENCIAPCFec = new DateTime[] {DateTime.MinValue} ;
         T000418_A105INCIDENCIAPCMes = new short[1] ;
         T000418_A106INCIDENCIAPCano = new short[1] ;
         T000418_A5Cod_Area = new string[] {""} ;
         T000418_A4IndicadoresCodigo = new string[] {""} ;
         T000418_A90TiposEnfermedadesCod = new string[] {""} ;
         T000418_A91MATERIALPALMASCOD = new string[] {""} ;
         T000418_A107INCIDENCIAPCZONA = new string[] {""} ;
         T000418_A108INCIDENCIAPCLOTE = new string[] {""} ;
         T000419_A60COSTONRFFPRODfec = new DateTime[] {DateTime.MinValue} ;
         T000419_A61COSTONRFFPRODmes = new short[1] ;
         T000419_A62COSTONRFFPRODano = new short[1] ;
         T000419_A5Cod_Area = new string[] {""} ;
         T000419_A4IndicadoresCodigo = new string[] {""} ;
         T000420_A57HATRABAJADORESFecha = new DateTime[] {DateTime.MinValue} ;
         T000420_A58HATRABAJADORESMes = new short[1] ;
         T000420_A59HATRABAJADORESAno = new short[1] ;
         T000420_A5Cod_Area = new string[] {""} ;
         T000420_A4IndicadoresCodigo = new string[] {""} ;
         T000421_A54TONCPOHAFecha = new DateTime[] {DateTime.MinValue} ;
         T000421_A55TONCPOHAMes = new short[1] ;
         T000421_A56TONCPOHAAno = new short[1] ;
         T000421_A5Cod_Area = new string[] {""} ;
         T000421_A4IndicadoresCodigo = new string[] {""} ;
         T000422_A94FRUTAPROPIAFecha = new DateTime[] {DateTime.MinValue} ;
         T000422_A95FRUTAPROPIAMes = new short[1] ;
         T000422_A96FRUTAPROPIAAno = new short[1] ;
         T000422_A4IndicadoresCodigo = new string[] {""} ;
         T000422_A5Cod_Area = new string[] {""} ;
         T000422_A97VIAJE = new long[1] ;
         T000422_A98SETOR = new string[] {""} ;
         T000422_A99FINCA = new string[] {""} ;
         T000422_A100PROVE_COD = new string[] {""} ;
         T000422_A101DIA = new DateTime[] {DateTime.MinValue} ;
         T000422_A102LOTE = new string[] {""} ;
         T000422_A103TAL = new string[] {""} ;
         T000423_A71COSTONRFFPROCFec = new DateTime[] {DateTime.MinValue} ;
         T000423_A72COSTONRFFPROCMes = new short[1] ;
         T000423_A73COSTONRFFPROCAno = new short[1] ;
         T000423_A5Cod_Area = new string[] {""} ;
         T000423_A4IndicadoresCodigo = new string[] {""} ;
         T000423_A53MOTIVOSCOSRFFPROCod = new string[] {""} ;
         T000424_A50AcidezFecha = new DateTime[] {DateTime.MinValue} ;
         T000424_A51AcidezMes = new short[1] ;
         T000424_A52AcidezAno = new short[1] ;
         T000424_A5Cod_Area = new string[] {""} ;
         T000424_A4IndicadoresCodigo = new string[] {""} ;
         T000425_A42TEAFecha = new DateTime[] {DateTime.MinValue} ;
         T000425_A43TEAMes = new short[1] ;
         T000425_A44TEAAno = new short[1] ;
         T000425_A4IndicadoresCodigo = new string[] {""} ;
         T000425_A5Cod_Area = new string[] {""} ;
         T000426_A39FRUTOPROCESADOFec = new DateTime[] {DateTime.MinValue} ;
         T000426_A40FRUTOPROCESADOMes = new short[1] ;
         T000426_A41FRUTOPROCESADOAno = new short[1] ;
         T000426_A5Cod_Area = new string[] {""} ;
         T000426_A4IndicadoresCodigo = new string[] {""} ;
         T000427_A36COSTOCPOHAFecha = new DateTime[] {DateTime.MinValue} ;
         T000427_A37COSTOCPOHAAno = new short[1] ;
         T000427_A38COSTOCPOHAMes = new short[1] ;
         T000427_A5Cod_Area = new string[] {""} ;
         T000427_A4IndicadoresCodigo = new string[] {""} ;
         T000428_A4IndicadoresCodigo = new string[] {""} ;
         T000428_A32MetasIndicadoresMes = new short[1] ;
         T000428_A33MetasIndicadoresAno = new short[1] ;
         T000428_A31TipoMetasCodigo = new string[] {""} ;
         T000429_A68PAGOFRUTAFecha = new DateTime[] {DateTime.MinValue} ;
         T000429_A69PAGOFRUTAMes = new short[1] ;
         T000429_A70PAGOFRUTAAno = new short[1] ;
         T000429_A5Cod_Area = new string[] {""} ;
         T000429_A4IndicadoresCodigo = new string[] {""} ;
         T000429_A30MotivosUspCodigo = new string[] {""} ;
         T000430_A27COSUSPTONFRUTAFecha = new DateTime[] {DateTime.MinValue} ;
         T000430_A28COSUSPTONFRUTAMes = new short[1] ;
         T000430_A29COSUSPTONFRUTAAno = new short[1] ;
         T000430_A5Cod_Area = new string[] {""} ;
         T000430_A4IndicadoresCodigo = new string[] {""} ;
         T000431_A24TRIFFecha = new DateTime[] {DateTime.MinValue} ;
         T000431_A25TRIFMes = new short[1] ;
         T000431_A26TRIFAno = new short[1] ;
         T000431_A4IndicadoresCodigo = new string[] {""} ;
         T000431_A5Cod_Area = new string[] {""} ;
         T000432_A21COSTOHEFecha = new DateTime[] {DateTime.MinValue} ;
         T000432_A22COSTOHEMes = new short[1] ;
         T000432_A23COSTOHEAno = new short[1] ;
         T000432_A4IndicadoresCodigo = new string[] {""} ;
         T000432_A5Cod_Area = new string[] {""} ;
         T000433_A18ACCDAG_Fecha = new DateTime[] {DateTime.MinValue} ;
         T000433_A19ACCDAG_Mes = new short[1] ;
         T000433_A20ACCDAG_Ano = new short[1] ;
         T000433_A5Cod_Area = new string[] {""} ;
         T000433_A4IndicadoresCodigo = new string[] {""} ;
         T000433_A17ProcesosACCDAGCod = new string[] {""} ;
         T000434_A1Ausen_Fecha = new DateTime[] {DateTime.MinValue} ;
         T000434_A2Ausen_Mes = new short[1] ;
         T000434_A3Ausen_Ano = new short[1] ;
         T000434_A4IndicadoresCodigo = new string[] {""} ;
         T000434_A5Cod_Area = new string[] {""} ;
         T000435_A4IndicadoresCodigo = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ4IndicadoresCodigo = "";
         ZZ128IndicadoresSigla = "";
         ZZ121IndicadoresNombres = "";
         ZZ122IndicadoresFormula = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.indicadores__default(),
            new Object[][] {
                new Object[] {
               T00042_A4IndicadoresCodigo, T00042_A128IndicadoresSigla, T00042_n128IndicadoresSigla, T00042_A121IndicadoresNombres, T00042_A122IndicadoresFormula, T00042_n122IndicadoresFormula, T00042_A123IndicadoresConsecutivo, T00042_n123IndicadoresConsecutivo
               }
               , new Object[] {
               T00043_A4IndicadoresCodigo, T00043_A128IndicadoresSigla, T00043_n128IndicadoresSigla, T00043_A121IndicadoresNombres, T00043_A122IndicadoresFormula, T00043_n122IndicadoresFormula, T00043_A123IndicadoresConsecutivo, T00043_n123IndicadoresConsecutivo
               }
               , new Object[] {
               T00044_A4IndicadoresCodigo, T00044_A128IndicadoresSigla, T00044_n128IndicadoresSigla, T00044_A121IndicadoresNombres, T00044_A122IndicadoresFormula, T00044_n122IndicadoresFormula, T00044_A123IndicadoresConsecutivo, T00044_n123IndicadoresConsecutivo
               }
               , new Object[] {
               T00045_A4IndicadoresCodigo
               }
               , new Object[] {
               T00046_A4IndicadoresCodigo
               }
               , new Object[] {
               T00047_A4IndicadoresCodigo
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000411_A35ParametrosCodigo
               }
               , new Object[] {
               T000412_A86RFF_COMPRADAFecha, T000412_A5Cod_Area, T000412_A4IndicadoresCodigo, T000412_A87RFF_COMPRADAMes, T000412_A88RFF_COMPRADAAno, T000412_A89RFF_COMPRAPRODUCUP
               }
               , new Object[] {
               T000413_A83PRECNETOTONCPOFecha, T000413_A84PRECNETOTONCPOMes, T000413_A85PRECNETOTONCPOAno, T000413_A5Cod_Area, T000413_A4IndicadoresCodigo, T000413_A67MOTIVOSPRENETCodigo
               }
               , new Object[] {
               T000414_A80COSTONRFFPROCESFecha, T000414_A81COSTONRFFPROCESMes, T000414_A82COSTONRFFPROCESAno, T000414_A5Cod_Area, T000414_A4IndicadoresCodigo, T000414_A66MOTIVOSCOSRFFCodigo
               }
               , new Object[] {
               T000415_A77COSTOTONRFFPRODUFecha, T000415_A78COSTOTONRFFPRODUMes, T000415_A79COSTOTONRFFPRODUAno, T000415_A5Cod_Area, T000415_A4IndicadoresCodigo, T000415_A65MOTIVOTONRFFcod
               }
               , new Object[] {
               T000416_A109COSTOCPOPRODUCIDOFecha, T000416_A110COSTOCPOPRODUCIDOMes, T000416_A111COSTOCPOPRODUCIDOAno, T000416_A5Cod_Area, T000416_A4IndicadoresCodigo, T000416_A64TIPOSCPOCod, T000416_A45TipoProductoCod
               }
               , new Object[] {
               T000417_A74MARGENEBITDAFecha, T000417_A75MARGENEBITDAMes, T000417_A76MARGENEBITDAAno, T000417_A5Cod_Area, T000417_A4IndicadoresCodigo, T000417_A63MOTIVOMARGENCod
               }
               , new Object[] {
               T000418_A104INCIDENCIAPCFec, T000418_A105INCIDENCIAPCMes, T000418_A106INCIDENCIAPCano, T000418_A5Cod_Area, T000418_A4IndicadoresCodigo, T000418_A90TiposEnfermedadesCod, T000418_A91MATERIALPALMASCOD, T000418_A107INCIDENCIAPCZONA, T000418_A108INCIDENCIAPCLOTE
               }
               , new Object[] {
               T000419_A60COSTONRFFPRODfec, T000419_A61COSTONRFFPRODmes, T000419_A62COSTONRFFPRODano, T000419_A5Cod_Area, T000419_A4IndicadoresCodigo
               }
               , new Object[] {
               T000420_A57HATRABAJADORESFecha, T000420_A58HATRABAJADORESMes, T000420_A59HATRABAJADORESAno, T000420_A5Cod_Area, T000420_A4IndicadoresCodigo
               }
               , new Object[] {
               T000421_A54TONCPOHAFecha, T000421_A55TONCPOHAMes, T000421_A56TONCPOHAAno, T000421_A5Cod_Area, T000421_A4IndicadoresCodigo
               }
               , new Object[] {
               T000422_A94FRUTAPROPIAFecha, T000422_A95FRUTAPROPIAMes, T000422_A96FRUTAPROPIAAno, T000422_A4IndicadoresCodigo, T000422_A5Cod_Area, T000422_A97VIAJE, T000422_A98SETOR, T000422_A99FINCA, T000422_A100PROVE_COD, T000422_A101DIA,
               T000422_A102LOTE, T000422_A103TAL
               }
               , new Object[] {
               T000423_A71COSTONRFFPROCFec, T000423_A72COSTONRFFPROCMes, T000423_A73COSTONRFFPROCAno, T000423_A5Cod_Area, T000423_A4IndicadoresCodigo, T000423_A53MOTIVOSCOSRFFPROCod
               }
               , new Object[] {
               T000424_A50AcidezFecha, T000424_A51AcidezMes, T000424_A52AcidezAno, T000424_A5Cod_Area, T000424_A4IndicadoresCodigo
               }
               , new Object[] {
               T000425_A42TEAFecha, T000425_A43TEAMes, T000425_A44TEAAno, T000425_A4IndicadoresCodigo, T000425_A5Cod_Area
               }
               , new Object[] {
               T000426_A39FRUTOPROCESADOFec, T000426_A40FRUTOPROCESADOMes, T000426_A41FRUTOPROCESADOAno, T000426_A5Cod_Area, T000426_A4IndicadoresCodigo
               }
               , new Object[] {
               T000427_A36COSTOCPOHAFecha, T000427_A37COSTOCPOHAAno, T000427_A38COSTOCPOHAMes, T000427_A5Cod_Area, T000427_A4IndicadoresCodigo
               }
               , new Object[] {
               T000428_A4IndicadoresCodigo, T000428_A32MetasIndicadoresMes, T000428_A33MetasIndicadoresAno, T000428_A31TipoMetasCodigo
               }
               , new Object[] {
               T000429_A68PAGOFRUTAFecha, T000429_A69PAGOFRUTAMes, T000429_A70PAGOFRUTAAno, T000429_A5Cod_Area, T000429_A4IndicadoresCodigo, T000429_A30MotivosUspCodigo
               }
               , new Object[] {
               T000430_A27COSUSPTONFRUTAFecha, T000430_A28COSUSPTONFRUTAMes, T000430_A29COSUSPTONFRUTAAno, T000430_A5Cod_Area, T000430_A4IndicadoresCodigo
               }
               , new Object[] {
               T000431_A24TRIFFecha, T000431_A25TRIFMes, T000431_A26TRIFAno, T000431_A4IndicadoresCodigo, T000431_A5Cod_Area
               }
               , new Object[] {
               T000432_A21COSTOHEFecha, T000432_A22COSTOHEMes, T000432_A23COSTOHEAno, T000432_A4IndicadoresCodigo, T000432_A5Cod_Area
               }
               , new Object[] {
               T000433_A18ACCDAG_Fecha, T000433_A19ACCDAG_Mes, T000433_A20ACCDAG_Ano, T000433_A5Cod_Area, T000433_A4IndicadoresCodigo, T000433_A17ProcesosACCDAGCod
               }
               , new Object[] {
               T000434_A1Ausen_Fecha, T000434_A2Ausen_Mes, T000434_A3Ausen_Ano, T000434_A4IndicadoresCodigo, T000434_A5Cod_Area
               }
               , new Object[] {
               T000435_A4IndicadoresCodigo
               }
            }
         );
      }

      private short Z123IndicadoresConsecutivo ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A123IndicadoresConsecutivo ;
      private short GX_JID ;
      private short RcdFound3 ;
      private short nIsDirty_3 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ123IndicadoresConsecutivo ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtIndicadoresCodigo_Enabled ;
      private int edtIndicadoresSigla_Enabled ;
      private int edtIndicadoresNombres_Enabled ;
      private int edtIndicadoresFormula_Enabled ;
      private int edtIndicadoresConsecutivo_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtIndicadoresCodigo_Internalname ;
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
      private string edtIndicadoresCodigo_Jsonclick ;
      private string edtIndicadoresSigla_Internalname ;
      private string edtIndicadoresSigla_Jsonclick ;
      private string edtIndicadoresNombres_Internalname ;
      private string edtIndicadoresFormula_Internalname ;
      private string edtIndicadoresConsecutivo_Internalname ;
      private string edtIndicadoresConsecutivo_Jsonclick ;
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
      private string sMode3 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n128IndicadoresSigla ;
      private bool n122IndicadoresFormula ;
      private bool n123IndicadoresConsecutivo ;
      private string Z4IndicadoresCodigo ;
      private string Z128IndicadoresSigla ;
      private string Z121IndicadoresNombres ;
      private string Z122IndicadoresFormula ;
      private string A4IndicadoresCodigo ;
      private string A128IndicadoresSigla ;
      private string A121IndicadoresNombres ;
      private string A122IndicadoresFormula ;
      private string ZZ4IndicadoresCodigo ;
      private string ZZ128IndicadoresSigla ;
      private string ZZ121IndicadoresNombres ;
      private string ZZ122IndicadoresFormula ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00044_A4IndicadoresCodigo ;
      private string[] T00044_A128IndicadoresSigla ;
      private bool[] T00044_n128IndicadoresSigla ;
      private string[] T00044_A121IndicadoresNombres ;
      private string[] T00044_A122IndicadoresFormula ;
      private bool[] T00044_n122IndicadoresFormula ;
      private short[] T00044_A123IndicadoresConsecutivo ;
      private bool[] T00044_n123IndicadoresConsecutivo ;
      private string[] T00045_A4IndicadoresCodigo ;
      private string[] T00043_A4IndicadoresCodigo ;
      private string[] T00043_A128IndicadoresSigla ;
      private bool[] T00043_n128IndicadoresSigla ;
      private string[] T00043_A121IndicadoresNombres ;
      private string[] T00043_A122IndicadoresFormula ;
      private bool[] T00043_n122IndicadoresFormula ;
      private short[] T00043_A123IndicadoresConsecutivo ;
      private bool[] T00043_n123IndicadoresConsecutivo ;
      private string[] T00046_A4IndicadoresCodigo ;
      private string[] T00047_A4IndicadoresCodigo ;
      private string[] T00042_A4IndicadoresCodigo ;
      private string[] T00042_A128IndicadoresSigla ;
      private bool[] T00042_n128IndicadoresSigla ;
      private string[] T00042_A121IndicadoresNombres ;
      private string[] T00042_A122IndicadoresFormula ;
      private bool[] T00042_n122IndicadoresFormula ;
      private short[] T00042_A123IndicadoresConsecutivo ;
      private bool[] T00042_n123IndicadoresConsecutivo ;
      private short[] T000411_A35ParametrosCodigo ;
      private DateTime[] T000412_A86RFF_COMPRADAFecha ;
      private string[] T000412_A5Cod_Area ;
      private string[] T000412_A4IndicadoresCodigo ;
      private short[] T000412_A87RFF_COMPRADAMes ;
      private short[] T000412_A88RFF_COMPRADAAno ;
      private string[] T000412_A89RFF_COMPRAPRODUCUP ;
      private DateTime[] T000413_A83PRECNETOTONCPOFecha ;
      private short[] T000413_A84PRECNETOTONCPOMes ;
      private short[] T000413_A85PRECNETOTONCPOAno ;
      private string[] T000413_A5Cod_Area ;
      private string[] T000413_A4IndicadoresCodigo ;
      private string[] T000413_A67MOTIVOSPRENETCodigo ;
      private DateTime[] T000414_A80COSTONRFFPROCESFecha ;
      private short[] T000414_A81COSTONRFFPROCESMes ;
      private short[] T000414_A82COSTONRFFPROCESAno ;
      private string[] T000414_A5Cod_Area ;
      private string[] T000414_A4IndicadoresCodigo ;
      private string[] T000414_A66MOTIVOSCOSRFFCodigo ;
      private DateTime[] T000415_A77COSTOTONRFFPRODUFecha ;
      private short[] T000415_A78COSTOTONRFFPRODUMes ;
      private short[] T000415_A79COSTOTONRFFPRODUAno ;
      private string[] T000415_A5Cod_Area ;
      private string[] T000415_A4IndicadoresCodigo ;
      private string[] T000415_A65MOTIVOTONRFFcod ;
      private DateTime[] T000416_A109COSTOCPOPRODUCIDOFecha ;
      private short[] T000416_A110COSTOCPOPRODUCIDOMes ;
      private short[] T000416_A111COSTOCPOPRODUCIDOAno ;
      private string[] T000416_A5Cod_Area ;
      private string[] T000416_A4IndicadoresCodigo ;
      private string[] T000416_A64TIPOSCPOCod ;
      private string[] T000416_A45TipoProductoCod ;
      private DateTime[] T000417_A74MARGENEBITDAFecha ;
      private short[] T000417_A75MARGENEBITDAMes ;
      private short[] T000417_A76MARGENEBITDAAno ;
      private string[] T000417_A5Cod_Area ;
      private string[] T000417_A4IndicadoresCodigo ;
      private string[] T000417_A63MOTIVOMARGENCod ;
      private DateTime[] T000418_A104INCIDENCIAPCFec ;
      private short[] T000418_A105INCIDENCIAPCMes ;
      private short[] T000418_A106INCIDENCIAPCano ;
      private string[] T000418_A5Cod_Area ;
      private string[] T000418_A4IndicadoresCodigo ;
      private string[] T000418_A90TiposEnfermedadesCod ;
      private string[] T000418_A91MATERIALPALMASCOD ;
      private string[] T000418_A107INCIDENCIAPCZONA ;
      private string[] T000418_A108INCIDENCIAPCLOTE ;
      private DateTime[] T000419_A60COSTONRFFPRODfec ;
      private short[] T000419_A61COSTONRFFPRODmes ;
      private short[] T000419_A62COSTONRFFPRODano ;
      private string[] T000419_A5Cod_Area ;
      private string[] T000419_A4IndicadoresCodigo ;
      private DateTime[] T000420_A57HATRABAJADORESFecha ;
      private short[] T000420_A58HATRABAJADORESMes ;
      private short[] T000420_A59HATRABAJADORESAno ;
      private string[] T000420_A5Cod_Area ;
      private string[] T000420_A4IndicadoresCodigo ;
      private DateTime[] T000421_A54TONCPOHAFecha ;
      private short[] T000421_A55TONCPOHAMes ;
      private short[] T000421_A56TONCPOHAAno ;
      private string[] T000421_A5Cod_Area ;
      private string[] T000421_A4IndicadoresCodigo ;
      private DateTime[] T000422_A94FRUTAPROPIAFecha ;
      private short[] T000422_A95FRUTAPROPIAMes ;
      private short[] T000422_A96FRUTAPROPIAAno ;
      private string[] T000422_A4IndicadoresCodigo ;
      private string[] T000422_A5Cod_Area ;
      private long[] T000422_A97VIAJE ;
      private string[] T000422_A98SETOR ;
      private string[] T000422_A99FINCA ;
      private string[] T000422_A100PROVE_COD ;
      private DateTime[] T000422_A101DIA ;
      private string[] T000422_A102LOTE ;
      private string[] T000422_A103TAL ;
      private DateTime[] T000423_A71COSTONRFFPROCFec ;
      private short[] T000423_A72COSTONRFFPROCMes ;
      private short[] T000423_A73COSTONRFFPROCAno ;
      private string[] T000423_A5Cod_Area ;
      private string[] T000423_A4IndicadoresCodigo ;
      private string[] T000423_A53MOTIVOSCOSRFFPROCod ;
      private DateTime[] T000424_A50AcidezFecha ;
      private short[] T000424_A51AcidezMes ;
      private short[] T000424_A52AcidezAno ;
      private string[] T000424_A5Cod_Area ;
      private string[] T000424_A4IndicadoresCodigo ;
      private DateTime[] T000425_A42TEAFecha ;
      private short[] T000425_A43TEAMes ;
      private short[] T000425_A44TEAAno ;
      private string[] T000425_A4IndicadoresCodigo ;
      private string[] T000425_A5Cod_Area ;
      private DateTime[] T000426_A39FRUTOPROCESADOFec ;
      private short[] T000426_A40FRUTOPROCESADOMes ;
      private short[] T000426_A41FRUTOPROCESADOAno ;
      private string[] T000426_A5Cod_Area ;
      private string[] T000426_A4IndicadoresCodigo ;
      private DateTime[] T000427_A36COSTOCPOHAFecha ;
      private short[] T000427_A37COSTOCPOHAAno ;
      private short[] T000427_A38COSTOCPOHAMes ;
      private string[] T000427_A5Cod_Area ;
      private string[] T000427_A4IndicadoresCodigo ;
      private string[] T000428_A4IndicadoresCodigo ;
      private short[] T000428_A32MetasIndicadoresMes ;
      private short[] T000428_A33MetasIndicadoresAno ;
      private string[] T000428_A31TipoMetasCodigo ;
      private DateTime[] T000429_A68PAGOFRUTAFecha ;
      private short[] T000429_A69PAGOFRUTAMes ;
      private short[] T000429_A70PAGOFRUTAAno ;
      private string[] T000429_A5Cod_Area ;
      private string[] T000429_A4IndicadoresCodigo ;
      private string[] T000429_A30MotivosUspCodigo ;
      private DateTime[] T000430_A27COSUSPTONFRUTAFecha ;
      private short[] T000430_A28COSUSPTONFRUTAMes ;
      private short[] T000430_A29COSUSPTONFRUTAAno ;
      private string[] T000430_A5Cod_Area ;
      private string[] T000430_A4IndicadoresCodigo ;
      private DateTime[] T000431_A24TRIFFecha ;
      private short[] T000431_A25TRIFMes ;
      private short[] T000431_A26TRIFAno ;
      private string[] T000431_A4IndicadoresCodigo ;
      private string[] T000431_A5Cod_Area ;
      private DateTime[] T000432_A21COSTOHEFecha ;
      private short[] T000432_A22COSTOHEMes ;
      private short[] T000432_A23COSTOHEAno ;
      private string[] T000432_A4IndicadoresCodigo ;
      private string[] T000432_A5Cod_Area ;
      private DateTime[] T000433_A18ACCDAG_Fecha ;
      private short[] T000433_A19ACCDAG_Mes ;
      private short[] T000433_A20ACCDAG_Ano ;
      private string[] T000433_A5Cod_Area ;
      private string[] T000433_A4IndicadoresCodigo ;
      private string[] T000433_A17ProcesosACCDAGCod ;
      private DateTime[] T000434_A1Ausen_Fecha ;
      private short[] T000434_A2Ausen_Mes ;
      private short[] T000434_A3Ausen_Ano ;
      private string[] T000434_A4IndicadoresCodigo ;
      private string[] T000434_A5Cod_Area ;
      private string[] T000435_A4IndicadoresCodigo ;
      private GXWebForm Form ;
   }

   public class indicadores__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[6])
         ,new UpdateCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
         ,new ForEachCursor(def[23])
         ,new ForEachCursor(def[24])
         ,new ForEachCursor(def[25])
         ,new ForEachCursor(def[26])
         ,new ForEachCursor(def[27])
         ,new ForEachCursor(def[28])
         ,new ForEachCursor(def[29])
         ,new ForEachCursor(def[30])
         ,new ForEachCursor(def[31])
         ,new ForEachCursor(def[32])
         ,new ForEachCursor(def[33])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00044;
          prmT00044 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT00045;
          prmT00045 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT00043;
          prmT00043 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT00046;
          prmT00046 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT00047;
          prmT00047 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT00042;
          prmT00042 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT00048;
          prmT00048 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresSigla",GXType.NVarChar,40,0){Nullable=true} ,
          new ParDef("@IndicadoresNombres",GXType.NVarChar,300,0) ,
          new ParDef("@IndicadoresFormula",GXType.NVarChar,300,0){Nullable=true} ,
          new ParDef("@IndicadoresConsecutivo",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT00049;
          prmT00049 = new Object[] {
          new ParDef("@IndicadoresSigla",GXType.NVarChar,40,0){Nullable=true} ,
          new ParDef("@IndicadoresNombres",GXType.NVarChar,300,0) ,
          new ParDef("@IndicadoresFormula",GXType.NVarChar,300,0){Nullable=true} ,
          new ParDef("@IndicadoresConsecutivo",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000410;
          prmT000410 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000411;
          prmT000411 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000412;
          prmT000412 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000413;
          prmT000413 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000414;
          prmT000414 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000415;
          prmT000415 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000416;
          prmT000416 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000417;
          prmT000417 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000418;
          prmT000418 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000419;
          prmT000419 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000420;
          prmT000420 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000421;
          prmT000421 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000422;
          prmT000422 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000423;
          prmT000423 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000424;
          prmT000424 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000425;
          prmT000425 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000426;
          prmT000426 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000427;
          prmT000427 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000428;
          prmT000428 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000429;
          prmT000429 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000430;
          prmT000430 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000431;
          prmT000431 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000432;
          prmT000432 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000433;
          prmT000433 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000434;
          prmT000434 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000435;
          prmT000435 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T00042", "SELECT [IndicadoresCodigo], [IndicadoresSigla], [IndicadoresNombres], [IndicadoresFormula], [IndicadoresConsecutivo] FROM [Indicadores] WITH (UPDLOCK) WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT00042,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00043", "SELECT [IndicadoresCodigo], [IndicadoresSigla], [IndicadoresNombres], [IndicadoresFormula], [IndicadoresConsecutivo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT00043,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00044", "SELECT TM1.[IndicadoresCodigo], TM1.[IndicadoresSigla], TM1.[IndicadoresNombres], TM1.[IndicadoresFormula], TM1.[IndicadoresConsecutivo] FROM [Indicadores] TM1 WHERE TM1.[IndicadoresCodigo] = @IndicadoresCodigo ORDER BY TM1.[IndicadoresCodigo]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00044,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00045", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00045,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00046", "SELECT TOP 1 [IndicadoresCodigo] FROM [Indicadores] WHERE ( [IndicadoresCodigo] > @IndicadoresCodigo) ORDER BY [IndicadoresCodigo]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00046,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00047", "SELECT TOP 1 [IndicadoresCodigo] FROM [Indicadores] WHERE ( [IndicadoresCodigo] < @IndicadoresCodigo) ORDER BY [IndicadoresCodigo] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00047,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00048", "INSERT INTO [Indicadores]([IndicadoresCodigo], [IndicadoresSigla], [IndicadoresNombres], [IndicadoresFormula], [IndicadoresConsecutivo]) VALUES(@IndicadoresCodigo, @IndicadoresSigla, @IndicadoresNombres, @IndicadoresFormula, @IndicadoresConsecutivo)", GxErrorMask.GX_NOMASK,prmT00048)
             ,new CursorDef("T00049", "UPDATE [Indicadores] SET [IndicadoresSigla]=@IndicadoresSigla, [IndicadoresNombres]=@IndicadoresNombres, [IndicadoresFormula]=@IndicadoresFormula, [IndicadoresConsecutivo]=@IndicadoresConsecutivo  WHERE [IndicadoresCodigo] = @IndicadoresCodigo", GxErrorMask.GX_NOMASK,prmT00049)
             ,new CursorDef("T000410", "DELETE FROM [Indicadores]  WHERE [IndicadoresCodigo] = @IndicadoresCodigo", GxErrorMask.GX_NOMASK,prmT000410)
             ,new CursorDef("T000411", "SELECT TOP 1 [ParametrosCodigo] FROM [Parametros] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000411,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000412", "SELECT TOP 1 [RFF_COMPRADAFecha], [Cod_Area], [IndicadoresCodigo], [RFF_COMPRADAMes], [RFF_COMPRADAAno], [RFF_COMPRAPRODUCUP] FROM [RFF_COMPRADA] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000412,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000413", "SELECT TOP 1 [PRECNETOTONCPOFecha], [PRECNETOTONCPOMes], [PRECNETOTONCPOAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOSPRENETCodigo] FROM [PRECNETOTONCPO] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000413,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000414", "SELECT TOP 1 [COSTONRFFPROCESFecha], [COSTONRFFPROCESMes], [COSTONRFFPROCESAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOSCOSRFFCodigo] FROM [COSTONRFFPROCES] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000414,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000415", "SELECT TOP 1 [COSTOTONRFFPRODUFecha], [COSTOTONRFFPRODUMes], [COSTOTONRFFPRODUAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOTONRFFcod] FROM [COSTOTONRFFPRODU] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000415,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000416", "SELECT TOP 1 [COSTOCPOPRODUCIDOFecha], [COSTOCPOPRODUCIDOMes], [COSTOCPOPRODUCIDOAno], [Cod_Area], [IndicadoresCodigo], [TIPOSCPOCod], [TipoProductoCod] FROM [COSTOCPOPRODUCIDO] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000416,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000417", "SELECT TOP 1 [MARGENEBITDAFecha], [MARGENEBITDAMes], [MARGENEBITDAAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOMARGENCod] FROM [MARGENEBITDA] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000417,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000418", "SELECT TOP 1 [INCIDENCIAPCFec], [INCIDENCIAPCMes], [INCIDENCIAPCano], [Cod_Area], [IndicadoresCodigo], [TiposEnfermedadesCod], [MATERIALPALMASCOD], [INCIDENCIAPCZONA], [INCIDENCIAPCLOTE] FROM [INCIDENCIAPC] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000418,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000419", "SELECT TOP 1 [COSTONRFFPRODfec], [COSTONRFFPRODmes], [COSTONRFFPRODano], [Cod_Area], [IndicadoresCodigo] FROM [COSTONRFFPROD] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000419,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000420", "SELECT TOP 1 [HATRABAJADORESFecha], [HATRABAJADORESMes], [HATRABAJADORESAno], [Cod_Area], [IndicadoresCodigo] FROM [HATRABAJADORES] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000420,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000421", "SELECT TOP 1 [TONCPOHAFecha], [TONCPOHAMes], [TONCPOHAAno], [Cod_Area], [IndicadoresCodigo] FROM [TONCPOHA] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000421,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000422", "SELECT TOP 1 [FRUTAPROPIAFecha], [FRUTAPROPIAMes], [FRUTAPROPIAAno], [IndicadoresCodigo], [Cod_Area], [VIAJE], [SETOR], [FINCA], [PROVE_COD], [DIA], [LOTE], [TAL] FROM [FRUTAPROPIA] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000422,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000423", "SELECT TOP 1 [COSTONRFFPROCFec], [COSTONRFFPROCMes], [COSTONRFFPROCAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOSCOSRFFPROCod] FROM [COSTONRFFPROCESADA] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000423,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000424", "SELECT TOP 1 [AcidezFecha], [AcidezMes], [AcidezAno], [Cod_Area], [IndicadoresCodigo] FROM [Acidez] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000424,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000425", "SELECT TOP 1 [TEAFecha], [TEAMes], [TEAAno], [IndicadoresCodigo], [Cod_Area] FROM [TEA] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000425,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000426", "SELECT TOP 1 [FRUTOPROCESADOFec], [FRUTOPROCESADOMes], [FRUTOPROCESADOAno], [Cod_Area], [IndicadoresCodigo] FROM [FRUTOPROCESADO] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000426,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000427", "SELECT TOP 1 [COSTOCPOHAFecha], [COSTOCPOHAAno], [COSTOCPOHAMes], [Cod_Area], [IndicadoresCodigo] FROM [COSTOCPOHA] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000427,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000428", "SELECT TOP 1 [IndicadoresCodigo], [MetasIndicadoresMes], [MetasIndicadoresAno], [TipoMetasCodigo] FROM [MetasIndicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000428,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000429", "SELECT TOP 1 [PAGOFRUTAFecha], [PAGOFRUTAMes], [PAGOFRUTAAno], [Cod_Area], [IndicadoresCodigo], [MotivosUspCodigo] FROM [PAGOFRUTA] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000429,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000430", "SELECT TOP 1 [COSUSPTONFRUTAFecha], [COSUSPTONFRUTAMes], [COSUSPTONFRUTAAno], [Cod_Area], [IndicadoresCodigo] FROM [COSUSPTONFRUTA] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000430,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000431", "SELECT TOP 1 [TRIFFecha], [TRIFMes], [TRIFAno], [IndicadoresCodigo], [Cod_Area] FROM [TRIF] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000431,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000432", "SELECT TOP 1 [COSTOHEFecha], [COSTOHEMes], [COSTOHEAno], [IndicadoresCodigo], [Cod_Area] FROM [COSTOHE] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000432,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000433", "SELECT TOP 1 [ACCDAG_Fecha], [ACCDAG_Mes], [ACCDAG_Ano], [Cod_Area], [IndicadoresCodigo], [ProcesosACCDAGCod] FROM [ACCDAG] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000433,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000434", "SELECT TOP 1 [Ausen_Fecha], [Ausen_Mes], [Ausen_Ano], [IndicadoresCodigo], [Cod_Area] FROM [Ausentismos] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000434,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000435", "SELECT [IndicadoresCodigo] FROM [Indicadores] ORDER BY [IndicadoresCodigo]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000435,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((short[]) buf[6])[0] = rslt.getShort(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((short[]) buf[6])[0] = rslt.getShort(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((short[]) buf[6])[0] = rslt.getShort(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 10 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                return;
             case 11 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                return;
             case 12 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                return;
             case 13 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                return;
             case 14 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                return;
             case 17 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 18 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 19 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 20 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getVarchar(12);
                return;
             case 21 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                return;
             case 22 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 23 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 24 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 25 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 26 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
             case 27 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                return;
             case 28 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 29 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
       }
       getresults30( cursor, rslt, buf) ;
    }

    public void getresults30( int cursor ,
                              IFieldGetter rslt ,
                              Object[] buf )
    {
       switch ( cursor )
       {
             case 30 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 31 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                return;
             case 32 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 33 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
       }
    }

 }

}
