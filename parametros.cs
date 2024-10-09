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
   public class parametros : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_2") == 0 )
         {
            A4IndicadoresCodigo = GetPar( "IndicadoresCodigo");
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A4IndicadoresCodigo) ;
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
            Form.Meta.addItem("description", "Parametros", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtParametrosCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("IndicadroresPalmas", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public parametros( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("IndicadroresPalmas", true);
      }

      public parametros( IGxContext context )
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
         cmbParametrosTipo = new GXCombobox();
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
         if ( cmbParametrosTipo.ItemCount > 0 )
         {
            A146ParametrosTipo = cmbParametrosTipo.getValidValue(A146ParametrosTipo);
            AssignAttri("", false, "A146ParametrosTipo", A146ParametrosTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbParametrosTipo.CurrentValue = StringUtil.RTrim( A146ParametrosTipo);
            AssignProp("", false, cmbParametrosTipo_Internalname, "Values", cmbParametrosTipo.ToJavascriptSource(), true);
         }
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Parametros", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Parametros.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Parametros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Parametros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Parametros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Parametros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 4, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx00h0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PARAMETROSCODIGO"+"'), id:'"+"PARAMETROSCODIGO"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_Parametros.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtParametrosCodigo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParametrosCodigo_Internalname, "Codigo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParametrosCodigo_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A35ParametrosCodigo), 4, 0, ",", "")), StringUtil.LTrim( ((edtParametrosCodigo_Enabled!=0) ? context.localUtil.Format( (decimal)(A35ParametrosCodigo), "ZZZ9") : context.localUtil.Format( (decimal)(A35ParametrosCodigo), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParametrosCodigo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParametrosCodigo_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Parametros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtParametrosNombres_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParametrosNombres_Internalname, "Nombres", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtParametrosNombres_Internalname, A145ParametrosNombres, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", 0, 1, edtParametrosNombres_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Parametros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbParametrosTipo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbParametrosTipo_Internalname, "Tipo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbParametrosTipo, cmbParametrosTipo_Internalname, StringUtil.RTrim( A146ParametrosTipo), 1, cmbParametrosTipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbParametrosTipo.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "", true, 0, "HLP_Parametros.htm");
         cmbParametrosTipo.CurrentValue = StringUtil.RTrim( A146ParametrosTipo);
         AssignProp("", false, cmbParametrosTipo_Internalname, "Values", (string)(cmbParametrosTipo.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIndicadoresCodigo_Internalname, A4IndicadoresCodigo, StringUtil.RTrim( context.localUtil.Format( A4IndicadoresCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIndicadoresCodigo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIndicadoresCodigo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Parametros.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_4_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_4_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_4_Internalname, sImgUrl, imgprompt_4_Link, "", "", context.GetTheme( ), imgprompt_4_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Parametros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtParametrosMes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParametrosMes_Internalname, "Mes", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParametrosMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A147ParametrosMes), 4, 0, ",", "")), StringUtil.LTrim( ((edtParametrosMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A147ParametrosMes), "ZZZ9") : context.localUtil.Format( (decimal)(A147ParametrosMes), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParametrosMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParametrosMes_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Parametros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtParametrosAno_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParametrosAno_Internalname, "Ano", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParametrosAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A148ParametrosAno), 4, 0, ",", "")), StringUtil.LTrim( ((edtParametrosAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A148ParametrosAno), "ZZZ9") : context.localUtil.Format( (decimal)(A148ParametrosAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParametrosAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParametrosAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Parametros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtParametrosValor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParametrosValor_Internalname, "Valor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParametrosValor_Internalname, StringUtil.LTrim( StringUtil.NToC( A149ParametrosValor, 15, 4, ",", "")), StringUtil.LTrim( ((edtParametrosValor_Enabled!=0) ? context.localUtil.Format( A149ParametrosValor, "ZZZZZZZZZ9.9999") : context.localUtil.Format( A149ParametrosValor, "ZZZZZZZZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParametrosValor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParametrosValor_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Parametros.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Parametros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Parametros.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Parametros.htm");
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
            Z35ParametrosCodigo = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z35ParametrosCodigo"), ",", "."), 18, MidpointRounding.ToEven));
            Z145ParametrosNombres = cgiGet( "Z145ParametrosNombres");
            Z146ParametrosTipo = cgiGet( "Z146ParametrosTipo");
            Z147ParametrosMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z147ParametrosMes"), ",", "."), 18, MidpointRounding.ToEven));
            Z148ParametrosAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z148ParametrosAno"), ",", "."), 18, MidpointRounding.ToEven));
            Z149ParametrosValor = context.localUtil.CToN( cgiGet( "Z149ParametrosValor"), ",", ".");
            Z4IndicadoresCodigo = cgiGet( "Z4IndicadoresCodigo");
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtParametrosCodigo_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtParametrosCodigo_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PARAMETROSCODIGO");
               AnyError = 1;
               GX_FocusControl = edtParametrosCodigo_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A35ParametrosCodigo = 0;
               AssignAttri("", false, "A35ParametrosCodigo", StringUtil.LTrimStr( (decimal)(A35ParametrosCodigo), 4, 0));
            }
            else
            {
               A35ParametrosCodigo = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtParametrosCodigo_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A35ParametrosCodigo", StringUtil.LTrimStr( (decimal)(A35ParametrosCodigo), 4, 0));
            }
            A145ParametrosNombres = cgiGet( edtParametrosNombres_Internalname);
            AssignAttri("", false, "A145ParametrosNombres", A145ParametrosNombres);
            cmbParametrosTipo.CurrentValue = cgiGet( cmbParametrosTipo_Internalname);
            A146ParametrosTipo = cgiGet( cmbParametrosTipo_Internalname);
            AssignAttri("", false, "A146ParametrosTipo", A146ParametrosTipo);
            A4IndicadoresCodigo = cgiGet( edtIndicadoresCodigo_Internalname);
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            if ( ( ( context.localUtil.CToN( cgiGet( edtParametrosMes_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtParametrosMes_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PARAMETROSMES");
               AnyError = 1;
               GX_FocusControl = edtParametrosMes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A147ParametrosMes = 0;
               AssignAttri("", false, "A147ParametrosMes", StringUtil.LTrimStr( (decimal)(A147ParametrosMes), 4, 0));
            }
            else
            {
               A147ParametrosMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtParametrosMes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A147ParametrosMes", StringUtil.LTrimStr( (decimal)(A147ParametrosMes), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtParametrosAno_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtParametrosAno_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PARAMETROSANO");
               AnyError = 1;
               GX_FocusControl = edtParametrosAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A148ParametrosAno = 0;
               AssignAttri("", false, "A148ParametrosAno", StringUtil.LTrimStr( (decimal)(A148ParametrosAno), 4, 0));
            }
            else
            {
               A148ParametrosAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtParametrosAno_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A148ParametrosAno", StringUtil.LTrimStr( (decimal)(A148ParametrosAno), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtParametrosValor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtParametrosValor_Internalname), ",", ".") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PARAMETROSVALOR");
               AnyError = 1;
               GX_FocusControl = edtParametrosValor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A149ParametrosValor = 0;
               AssignAttri("", false, "A149ParametrosValor", StringUtil.LTrimStr( A149ParametrosValor, 15, 4));
            }
            else
            {
               A149ParametrosValor = context.localUtil.CToN( cgiGet( edtParametrosValor_Internalname), ",", ".");
               AssignAttri("", false, "A149ParametrosValor", StringUtil.LTrimStr( A149ParametrosValor, 15, 4));
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
               A35ParametrosCodigo = (short)(Math.Round(NumberUtil.Val( GetPar( "ParametrosCodigo"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A35ParametrosCodigo", StringUtil.LTrimStr( (decimal)(A35ParametrosCodigo), 4, 0));
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
               InitAll0G17( ) ;
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
         DisableAttributes0G17( ) ;
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

      protected void ResetCaption0G0( )
      {
      }

      protected void ZM0G17( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z145ParametrosNombres = T000G3_A145ParametrosNombres[0];
               Z146ParametrosTipo = T000G3_A146ParametrosTipo[0];
               Z147ParametrosMes = T000G3_A147ParametrosMes[0];
               Z148ParametrosAno = T000G3_A148ParametrosAno[0];
               Z149ParametrosValor = T000G3_A149ParametrosValor[0];
               Z4IndicadoresCodigo = T000G3_A4IndicadoresCodigo[0];
            }
            else
            {
               Z145ParametrosNombres = A145ParametrosNombres;
               Z146ParametrosTipo = A146ParametrosTipo;
               Z147ParametrosMes = A147ParametrosMes;
               Z148ParametrosAno = A148ParametrosAno;
               Z149ParametrosValor = A149ParametrosValor;
               Z4IndicadoresCodigo = A4IndicadoresCodigo;
            }
         }
         if ( GX_JID == -1 )
         {
            Z35ParametrosCodigo = A35ParametrosCodigo;
            Z145ParametrosNombres = A145ParametrosNombres;
            Z146ParametrosTipo = A146ParametrosTipo;
            Z147ParametrosMes = A147ParametrosMes;
            Z148ParametrosAno = A148ParametrosAno;
            Z149ParametrosValor = A149ParametrosValor;
            Z4IndicadoresCodigo = A4IndicadoresCodigo;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_4_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0030.aspx"+"',["+"{Ctrl:gx.dom.el('"+"INDICADORESCODIGO"+"'), id:'"+"INDICADORESCODIGO"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
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

      protected void Load0G17( )
      {
         /* Using cursor T000G5 */
         pr_default.execute(3, new Object[] {A35ParametrosCodigo});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound17 = 1;
            A145ParametrosNombres = T000G5_A145ParametrosNombres[0];
            AssignAttri("", false, "A145ParametrosNombres", A145ParametrosNombres);
            A146ParametrosTipo = T000G5_A146ParametrosTipo[0];
            AssignAttri("", false, "A146ParametrosTipo", A146ParametrosTipo);
            A147ParametrosMes = T000G5_A147ParametrosMes[0];
            AssignAttri("", false, "A147ParametrosMes", StringUtil.LTrimStr( (decimal)(A147ParametrosMes), 4, 0));
            A148ParametrosAno = T000G5_A148ParametrosAno[0];
            AssignAttri("", false, "A148ParametrosAno", StringUtil.LTrimStr( (decimal)(A148ParametrosAno), 4, 0));
            A149ParametrosValor = T000G5_A149ParametrosValor[0];
            AssignAttri("", false, "A149ParametrosValor", StringUtil.LTrimStr( A149ParametrosValor, 15, 4));
            A4IndicadoresCodigo = T000G5_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            ZM0G17( -1) ;
         }
         pr_default.close(3);
         OnLoadActions0G17( ) ;
      }

      protected void OnLoadActions0G17( )
      {
      }

      protected void CheckExtendedTable0G17( )
      {
         nIsDirty_17 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T000G4 */
         pr_default.execute(2, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0G17( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( string A4IndicadoresCodigo )
      {
         /* Using cursor T000G6 */
         pr_default.execute(4, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey0G17( )
      {
         /* Using cursor T000G7 */
         pr_default.execute(5, new Object[] {A35ParametrosCodigo});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound17 = 1;
         }
         else
         {
            RcdFound17 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000G3 */
         pr_default.execute(1, new Object[] {A35ParametrosCodigo});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0G17( 1) ;
            RcdFound17 = 1;
            A35ParametrosCodigo = T000G3_A35ParametrosCodigo[0];
            AssignAttri("", false, "A35ParametrosCodigo", StringUtil.LTrimStr( (decimal)(A35ParametrosCodigo), 4, 0));
            A145ParametrosNombres = T000G3_A145ParametrosNombres[0];
            AssignAttri("", false, "A145ParametrosNombres", A145ParametrosNombres);
            A146ParametrosTipo = T000G3_A146ParametrosTipo[0];
            AssignAttri("", false, "A146ParametrosTipo", A146ParametrosTipo);
            A147ParametrosMes = T000G3_A147ParametrosMes[0];
            AssignAttri("", false, "A147ParametrosMes", StringUtil.LTrimStr( (decimal)(A147ParametrosMes), 4, 0));
            A148ParametrosAno = T000G3_A148ParametrosAno[0];
            AssignAttri("", false, "A148ParametrosAno", StringUtil.LTrimStr( (decimal)(A148ParametrosAno), 4, 0));
            A149ParametrosValor = T000G3_A149ParametrosValor[0];
            AssignAttri("", false, "A149ParametrosValor", StringUtil.LTrimStr( A149ParametrosValor, 15, 4));
            A4IndicadoresCodigo = T000G3_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            Z35ParametrosCodigo = A35ParametrosCodigo;
            sMode17 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0G17( ) ;
            if ( AnyError == 1 )
            {
               RcdFound17 = 0;
               InitializeNonKey0G17( ) ;
            }
            Gx_mode = sMode17;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound17 = 0;
            InitializeNonKey0G17( ) ;
            sMode17 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode17;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0G17( ) ;
         if ( RcdFound17 == 0 )
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
         RcdFound17 = 0;
         /* Using cursor T000G8 */
         pr_default.execute(6, new Object[] {A35ParametrosCodigo});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T000G8_A35ParametrosCodigo[0] < A35ParametrosCodigo ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T000G8_A35ParametrosCodigo[0] > A35ParametrosCodigo ) ) )
            {
               A35ParametrosCodigo = T000G8_A35ParametrosCodigo[0];
               AssignAttri("", false, "A35ParametrosCodigo", StringUtil.LTrimStr( (decimal)(A35ParametrosCodigo), 4, 0));
               RcdFound17 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound17 = 0;
         /* Using cursor T000G9 */
         pr_default.execute(7, new Object[] {A35ParametrosCodigo});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T000G9_A35ParametrosCodigo[0] > A35ParametrosCodigo ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T000G9_A35ParametrosCodigo[0] < A35ParametrosCodigo ) ) )
            {
               A35ParametrosCodigo = T000G9_A35ParametrosCodigo[0];
               AssignAttri("", false, "A35ParametrosCodigo", StringUtil.LTrimStr( (decimal)(A35ParametrosCodigo), 4, 0));
               RcdFound17 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0G17( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtParametrosCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0G17( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound17 == 1 )
            {
               if ( A35ParametrosCodigo != Z35ParametrosCodigo )
               {
                  A35ParametrosCodigo = Z35ParametrosCodigo;
                  AssignAttri("", false, "A35ParametrosCodigo", StringUtil.LTrimStr( (decimal)(A35ParametrosCodigo), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PARAMETROSCODIGO");
                  AnyError = 1;
                  GX_FocusControl = edtParametrosCodigo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtParametrosCodigo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0G17( ) ;
                  GX_FocusControl = edtParametrosCodigo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A35ParametrosCodigo != Z35ParametrosCodigo )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtParametrosCodigo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0G17( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PARAMETROSCODIGO");
                     AnyError = 1;
                     GX_FocusControl = edtParametrosCodigo_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtParametrosCodigo_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0G17( ) ;
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
         if ( A35ParametrosCodigo != Z35ParametrosCodigo )
         {
            A35ParametrosCodigo = Z35ParametrosCodigo;
            AssignAttri("", false, "A35ParametrosCodigo", StringUtil.LTrimStr( (decimal)(A35ParametrosCodigo), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PARAMETROSCODIGO");
            AnyError = 1;
            GX_FocusControl = edtParametrosCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtParametrosCodigo_Internalname;
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
         if ( RcdFound17 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "PARAMETROSCODIGO");
            AnyError = 1;
            GX_FocusControl = edtParametrosCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtParametrosNombres_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0G17( ) ;
         if ( RcdFound17 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtParametrosNombres_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0G17( ) ;
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
         if ( RcdFound17 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtParametrosNombres_Internalname;
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
         if ( RcdFound17 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtParametrosNombres_Internalname;
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
         ScanStart0G17( ) ;
         if ( RcdFound17 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound17 != 0 )
            {
               ScanNext0G17( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtParametrosNombres_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0G17( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0G17( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000G2 */
            pr_default.execute(0, new Object[] {A35ParametrosCodigo});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Parametros"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z145ParametrosNombres, T000G2_A145ParametrosNombres[0]) != 0 ) || ( StringUtil.StrCmp(Z146ParametrosTipo, T000G2_A146ParametrosTipo[0]) != 0 ) || ( Z147ParametrosMes != T000G2_A147ParametrosMes[0] ) || ( Z148ParametrosAno != T000G2_A148ParametrosAno[0] ) || ( Z149ParametrosValor != T000G2_A149ParametrosValor[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z4IndicadoresCodigo, T000G2_A4IndicadoresCodigo[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z145ParametrosNombres, T000G2_A145ParametrosNombres[0]) != 0 )
               {
                  GXUtil.WriteLog("parametros:[seudo value changed for attri]"+"ParametrosNombres");
                  GXUtil.WriteLogRaw("Old: ",Z145ParametrosNombres);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A145ParametrosNombres[0]);
               }
               if ( StringUtil.StrCmp(Z146ParametrosTipo, T000G2_A146ParametrosTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("parametros:[seudo value changed for attri]"+"ParametrosTipo");
                  GXUtil.WriteLogRaw("Old: ",Z146ParametrosTipo);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A146ParametrosTipo[0]);
               }
               if ( Z147ParametrosMes != T000G2_A147ParametrosMes[0] )
               {
                  GXUtil.WriteLog("parametros:[seudo value changed for attri]"+"ParametrosMes");
                  GXUtil.WriteLogRaw("Old: ",Z147ParametrosMes);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A147ParametrosMes[0]);
               }
               if ( Z148ParametrosAno != T000G2_A148ParametrosAno[0] )
               {
                  GXUtil.WriteLog("parametros:[seudo value changed for attri]"+"ParametrosAno");
                  GXUtil.WriteLogRaw("Old: ",Z148ParametrosAno);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A148ParametrosAno[0]);
               }
               if ( Z149ParametrosValor != T000G2_A149ParametrosValor[0] )
               {
                  GXUtil.WriteLog("parametros:[seudo value changed for attri]"+"ParametrosValor");
                  GXUtil.WriteLogRaw("Old: ",Z149ParametrosValor);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A149ParametrosValor[0]);
               }
               if ( StringUtil.StrCmp(Z4IndicadoresCodigo, T000G2_A4IndicadoresCodigo[0]) != 0 )
               {
                  GXUtil.WriteLog("parametros:[seudo value changed for attri]"+"IndicadoresCodigo");
                  GXUtil.WriteLogRaw("Old: ",Z4IndicadoresCodigo);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A4IndicadoresCodigo[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Parametros"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0G17( )
      {
         BeforeValidate0G17( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0G17( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0G17( 0) ;
            CheckOptimisticConcurrency0G17( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0G17( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0G17( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000G10 */
                     pr_default.execute(8, new Object[] {A35ParametrosCodigo, A145ParametrosNombres, A146ParametrosTipo, A147ParametrosMes, A148ParametrosAno, A149ParametrosValor, A4IndicadoresCodigo});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Parametros");
                     if ( (pr_default.getStatus(8) == 1) )
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
                           ResetCaption0G0( ) ;
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
               Load0G17( ) ;
            }
            EndLevel0G17( ) ;
         }
         CloseExtendedTableCursors0G17( ) ;
      }

      protected void Update0G17( )
      {
         BeforeValidate0G17( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0G17( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0G17( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0G17( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0G17( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000G11 */
                     pr_default.execute(9, new Object[] {A145ParametrosNombres, A146ParametrosTipo, A147ParametrosMes, A148ParametrosAno, A149ParametrosValor, A4IndicadoresCodigo, A35ParametrosCodigo});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Parametros");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Parametros"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0G17( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0G0( ) ;
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
            EndLevel0G17( ) ;
         }
         CloseExtendedTableCursors0G17( ) ;
      }

      protected void DeferredUpdate0G17( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0G17( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0G17( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0G17( ) ;
            AfterConfirm0G17( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0G17( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000G12 */
                  pr_default.execute(10, new Object[] {A35ParametrosCodigo});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("Parametros");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound17 == 0 )
                        {
                           InitAll0G17( ) ;
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
                        ResetCaption0G0( ) ;
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
         sMode17 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0G17( ) ;
         Gx_mode = sMode17;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0G17( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0G17( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0G17( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("parametros",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0G0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("parametros",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0G17( )
      {
         /* Using cursor T000G13 */
         pr_default.execute(11);
         RcdFound17 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound17 = 1;
            A35ParametrosCodigo = T000G13_A35ParametrosCodigo[0];
            AssignAttri("", false, "A35ParametrosCodigo", StringUtil.LTrimStr( (decimal)(A35ParametrosCodigo), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0G17( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound17 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound17 = 1;
            A35ParametrosCodigo = T000G13_A35ParametrosCodigo[0];
            AssignAttri("", false, "A35ParametrosCodigo", StringUtil.LTrimStr( (decimal)(A35ParametrosCodigo), 4, 0));
         }
      }

      protected void ScanEnd0G17( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm0G17( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0G17( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0G17( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0G17( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0G17( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0G17( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0G17( )
      {
         edtParametrosCodigo_Enabled = 0;
         AssignProp("", false, edtParametrosCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametrosCodigo_Enabled), 5, 0), true);
         edtParametrosNombres_Enabled = 0;
         AssignProp("", false, edtParametrosNombres_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametrosNombres_Enabled), 5, 0), true);
         cmbParametrosTipo.Enabled = 0;
         AssignProp("", false, cmbParametrosTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbParametrosTipo.Enabled), 5, 0), true);
         edtIndicadoresCodigo_Enabled = 0;
         AssignProp("", false, edtIndicadoresCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIndicadoresCodigo_Enabled), 5, 0), true);
         edtParametrosMes_Enabled = 0;
         AssignProp("", false, edtParametrosMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametrosMes_Enabled), 5, 0), true);
         edtParametrosAno_Enabled = 0;
         AssignProp("", false, edtParametrosAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametrosAno_Enabled), 5, 0), true);
         edtParametrosValor_Enabled = 0;
         AssignProp("", false, edtParametrosValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametrosValor_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0G17( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0G0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("parametros.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z35ParametrosCodigo", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z35ParametrosCodigo), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z145ParametrosNombres", Z145ParametrosNombres);
         GxWebStd.gx_hidden_field( context, "Z146ParametrosTipo", Z146ParametrosTipo);
         GxWebStd.gx_hidden_field( context, "Z147ParametrosMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z147ParametrosMes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z148ParametrosAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z148ParametrosAno), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z149ParametrosValor", StringUtil.LTrim( StringUtil.NToC( Z149ParametrosValor, 15, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z4IndicadoresCodigo", Z4IndicadoresCodigo);
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
         return formatLink("parametros.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Parametros" ;
      }

      public override string GetPgmdesc( )
      {
         return "Parametros" ;
      }

      protected void InitializeNonKey0G17( )
      {
         A145ParametrosNombres = "";
         AssignAttri("", false, "A145ParametrosNombres", A145ParametrosNombres);
         A146ParametrosTipo = "";
         AssignAttri("", false, "A146ParametrosTipo", A146ParametrosTipo);
         A4IndicadoresCodigo = "";
         AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
         A147ParametrosMes = 0;
         AssignAttri("", false, "A147ParametrosMes", StringUtil.LTrimStr( (decimal)(A147ParametrosMes), 4, 0));
         A148ParametrosAno = 0;
         AssignAttri("", false, "A148ParametrosAno", StringUtil.LTrimStr( (decimal)(A148ParametrosAno), 4, 0));
         A149ParametrosValor = 0;
         AssignAttri("", false, "A149ParametrosValor", StringUtil.LTrimStr( A149ParametrosValor, 15, 4));
         Z145ParametrosNombres = "";
         Z146ParametrosTipo = "";
         Z147ParametrosMes = 0;
         Z148ParametrosAno = 0;
         Z149ParametrosValor = 0;
         Z4IndicadoresCodigo = "";
      }

      protected void InitAll0G17( )
      {
         A35ParametrosCodigo = 0;
         AssignAttri("", false, "A35ParametrosCodigo", StringUtil.LTrimStr( (decimal)(A35ParametrosCodigo), 4, 0));
         InitializeNonKey0G17( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20247231021654", true, true);
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
         context.AddJavascriptSource("parametros.js", "?20247231021655", false, true);
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
         edtParametrosCodigo_Internalname = "PARAMETROSCODIGO";
         edtParametrosNombres_Internalname = "PARAMETROSNOMBRES";
         cmbParametrosTipo_Internalname = "PARAMETROSTIPO";
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO";
         edtParametrosMes_Internalname = "PARAMETROSMES";
         edtParametrosAno_Internalname = "PARAMETROSANO";
         edtParametrosValor_Internalname = "PARAMETROSVALOR";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
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
         Form.Caption = "Parametros";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtParametrosValor_Jsonclick = "";
         edtParametrosValor_Enabled = 1;
         edtParametrosAno_Jsonclick = "";
         edtParametrosAno_Enabled = 1;
         edtParametrosMes_Jsonclick = "";
         edtParametrosMes_Enabled = 1;
         imgprompt_4_Visible = 1;
         imgprompt_4_Link = "";
         edtIndicadoresCodigo_Jsonclick = "";
         edtIndicadoresCodigo_Enabled = 1;
         cmbParametrosTipo_Jsonclick = "";
         cmbParametrosTipo.Enabled = 1;
         edtParametrosNombres_Enabled = 1;
         edtParametrosCodigo_Jsonclick = "";
         edtParametrosCodigo_Enabled = 1;
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
         cmbParametrosTipo.Name = "PARAMETROSTIPO";
         cmbParametrosTipo.WebTags = "";
         cmbParametrosTipo.addItem("VU", "VALOR UNICO", 0);
         cmbParametrosTipo.addItem("VM", "VALOR MES", 0);
         if ( cmbParametrosTipo.ItemCount > 0 )
         {
            A146ParametrosTipo = cmbParametrosTipo.getValidValue(A146ParametrosTipo);
            AssignAttri("", false, "A146ParametrosTipo", A146ParametrosTipo);
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtParametrosNombres_Internalname;
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

      public void Valid_Parametroscodigo( )
      {
         A146ParametrosTipo = cmbParametrosTipo.CurrentValue;
         cmbParametrosTipo.CurrentValue = A146ParametrosTipo;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbParametrosTipo.ItemCount > 0 )
         {
            A146ParametrosTipo = cmbParametrosTipo.getValidValue(A146ParametrosTipo);
            cmbParametrosTipo.CurrentValue = A146ParametrosTipo;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbParametrosTipo.CurrentValue = StringUtil.RTrim( A146ParametrosTipo);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A145ParametrosNombres", A145ParametrosNombres);
         AssignAttri("", false, "A146ParametrosTipo", A146ParametrosTipo);
         cmbParametrosTipo.CurrentValue = StringUtil.RTrim( A146ParametrosTipo);
         AssignProp("", false, cmbParametrosTipo_Internalname, "Values", cmbParametrosTipo.ToJavascriptSource(), true);
         AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
         AssignAttri("", false, "A147ParametrosMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(A147ParametrosMes), 4, 0, ".", "")));
         AssignAttri("", false, "A148ParametrosAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(A148ParametrosAno), 4, 0, ".", "")));
         AssignAttri("", false, "A149ParametrosValor", StringUtil.LTrim( StringUtil.NToC( A149ParametrosValor, 15, 4, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z35ParametrosCodigo", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z35ParametrosCodigo), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z145ParametrosNombres", Z145ParametrosNombres);
         GxWebStd.gx_hidden_field( context, "Z146ParametrosTipo", Z146ParametrosTipo);
         GxWebStd.gx_hidden_field( context, "Z4IndicadoresCodigo", Z4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "Z147ParametrosMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z147ParametrosMes), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z148ParametrosAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z148ParametrosAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z149ParametrosValor", StringUtil.LTrim( StringUtil.NToC( Z149ParametrosValor, 15, 4, ".", "")));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Indicadorescodigo( )
      {
         /* Using cursor T000G14 */
         pr_default.execute(12, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
         }
         pr_default.close(12);
         dynload_actions( ) ;
         /*  Sending validation outputs */
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
         setEventMetadata("VALID_PARAMETROSCODIGO","{handler:'Valid_Parametroscodigo',iparms:[{av:'cmbParametrosTipo'},{av:'A146ParametrosTipo',fld:'PARAMETROSTIPO',pic:''},{av:'A35ParametrosCodigo',fld:'PARAMETROSCODIGO',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_PARAMETROSCODIGO",",oparms:[{av:'A145ParametrosNombres',fld:'PARAMETROSNOMBRES',pic:''},{av:'cmbParametrosTipo'},{av:'A146ParametrosTipo',fld:'PARAMETROSTIPO',pic:''},{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:''},{av:'A147ParametrosMes',fld:'PARAMETROSMES',pic:'ZZZ9'},{av:'A148ParametrosAno',fld:'PARAMETROSANO',pic:'ZZZ9'},{av:'A149ParametrosValor',fld:'PARAMETROSVALOR',pic:'ZZZZZZZZZ9.9999'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z35ParametrosCodigo'},{av:'Z145ParametrosNombres'},{av:'Z146ParametrosTipo'},{av:'Z4IndicadoresCodigo'},{av:'Z147ParametrosMes'},{av:'Z148ParametrosAno'},{av:'Z149ParametrosValor'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_INDICADORESCODIGO","{handler:'Valid_Indicadorescodigo',iparms:[{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:''}]");
         setEventMetadata("VALID_INDICADORESCODIGO",",oparms:[]}");
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
         pr_default.close(12);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z145ParametrosNombres = "";
         Z146ParametrosTipo = "";
         Z4IndicadoresCodigo = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A4IndicadoresCodigo = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A146ParametrosTipo = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A145ParametrosNombres = "";
         imgprompt_4_gximage = "";
         sImgUrl = "";
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
         T000G5_A35ParametrosCodigo = new short[1] ;
         T000G5_A145ParametrosNombres = new string[] {""} ;
         T000G5_A146ParametrosTipo = new string[] {""} ;
         T000G5_A147ParametrosMes = new short[1] ;
         T000G5_A148ParametrosAno = new short[1] ;
         T000G5_A149ParametrosValor = new decimal[1] ;
         T000G5_A4IndicadoresCodigo = new string[] {""} ;
         T000G4_A4IndicadoresCodigo = new string[] {""} ;
         T000G6_A4IndicadoresCodigo = new string[] {""} ;
         T000G7_A35ParametrosCodigo = new short[1] ;
         T000G3_A35ParametrosCodigo = new short[1] ;
         T000G3_A145ParametrosNombres = new string[] {""} ;
         T000G3_A146ParametrosTipo = new string[] {""} ;
         T000G3_A147ParametrosMes = new short[1] ;
         T000G3_A148ParametrosAno = new short[1] ;
         T000G3_A149ParametrosValor = new decimal[1] ;
         T000G3_A4IndicadoresCodigo = new string[] {""} ;
         sMode17 = "";
         T000G8_A35ParametrosCodigo = new short[1] ;
         T000G9_A35ParametrosCodigo = new short[1] ;
         T000G2_A35ParametrosCodigo = new short[1] ;
         T000G2_A145ParametrosNombres = new string[] {""} ;
         T000G2_A146ParametrosTipo = new string[] {""} ;
         T000G2_A147ParametrosMes = new short[1] ;
         T000G2_A148ParametrosAno = new short[1] ;
         T000G2_A149ParametrosValor = new decimal[1] ;
         T000G2_A4IndicadoresCodigo = new string[] {""} ;
         T000G13_A35ParametrosCodigo = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ145ParametrosNombres = "";
         ZZ146ParametrosTipo = "";
         ZZ4IndicadoresCodigo = "";
         T000G14_A4IndicadoresCodigo = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.parametros__default(),
            new Object[][] {
                new Object[] {
               T000G2_A35ParametrosCodigo, T000G2_A145ParametrosNombres, T000G2_A146ParametrosTipo, T000G2_A147ParametrosMes, T000G2_A148ParametrosAno, T000G2_A149ParametrosValor, T000G2_A4IndicadoresCodigo
               }
               , new Object[] {
               T000G3_A35ParametrosCodigo, T000G3_A145ParametrosNombres, T000G3_A146ParametrosTipo, T000G3_A147ParametrosMes, T000G3_A148ParametrosAno, T000G3_A149ParametrosValor, T000G3_A4IndicadoresCodigo
               }
               , new Object[] {
               T000G4_A4IndicadoresCodigo
               }
               , new Object[] {
               T000G5_A35ParametrosCodigo, T000G5_A145ParametrosNombres, T000G5_A146ParametrosTipo, T000G5_A147ParametrosMes, T000G5_A148ParametrosAno, T000G5_A149ParametrosValor, T000G5_A4IndicadoresCodigo
               }
               , new Object[] {
               T000G6_A4IndicadoresCodigo
               }
               , new Object[] {
               T000G7_A35ParametrosCodigo
               }
               , new Object[] {
               T000G8_A35ParametrosCodigo
               }
               , new Object[] {
               T000G9_A35ParametrosCodigo
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000G13_A35ParametrosCodigo
               }
               , new Object[] {
               T000G14_A4IndicadoresCodigo
               }
            }
         );
      }

      private short Z35ParametrosCodigo ;
      private short Z147ParametrosMes ;
      private short Z148ParametrosAno ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A35ParametrosCodigo ;
      private short A147ParametrosMes ;
      private short A148ParametrosAno ;
      private short GX_JID ;
      private short RcdFound17 ;
      private short nIsDirty_17 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ35ParametrosCodigo ;
      private short ZZ147ParametrosMes ;
      private short ZZ148ParametrosAno ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtParametrosCodigo_Enabled ;
      private int edtParametrosNombres_Enabled ;
      private int edtIndicadoresCodigo_Enabled ;
      private int imgprompt_4_Visible ;
      private int edtParametrosMes_Enabled ;
      private int edtParametrosAno_Enabled ;
      private int edtParametrosValor_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private decimal Z149ParametrosValor ;
      private decimal A149ParametrosValor ;
      private decimal ZZ149ParametrosValor ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtParametrosCodigo_Internalname ;
      private string cmbParametrosTipo_Internalname ;
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
      private string edtParametrosCodigo_Jsonclick ;
      private string edtParametrosNombres_Internalname ;
      private string cmbParametrosTipo_Jsonclick ;
      private string edtIndicadoresCodigo_Internalname ;
      private string edtIndicadoresCodigo_Jsonclick ;
      private string imgprompt_4_gximage ;
      private string sImgUrl ;
      private string imgprompt_4_Internalname ;
      private string imgprompt_4_Link ;
      private string edtParametrosMes_Internalname ;
      private string edtParametrosMes_Jsonclick ;
      private string edtParametrosAno_Internalname ;
      private string edtParametrosAno_Jsonclick ;
      private string edtParametrosValor_Internalname ;
      private string edtParametrosValor_Jsonclick ;
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
      private string sMode17 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private string Z145ParametrosNombres ;
      private string Z146ParametrosTipo ;
      private string Z4IndicadoresCodigo ;
      private string A4IndicadoresCodigo ;
      private string A146ParametrosTipo ;
      private string A145ParametrosNombres ;
      private string ZZ145ParametrosNombres ;
      private string ZZ146ParametrosTipo ;
      private string ZZ4IndicadoresCodigo ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbParametrosTipo ;
      private IDataStoreProvider pr_default ;
      private short[] T000G5_A35ParametrosCodigo ;
      private string[] T000G5_A145ParametrosNombres ;
      private string[] T000G5_A146ParametrosTipo ;
      private short[] T000G5_A147ParametrosMes ;
      private short[] T000G5_A148ParametrosAno ;
      private decimal[] T000G5_A149ParametrosValor ;
      private string[] T000G5_A4IndicadoresCodigo ;
      private string[] T000G4_A4IndicadoresCodigo ;
      private string[] T000G6_A4IndicadoresCodigo ;
      private short[] T000G7_A35ParametrosCodigo ;
      private short[] T000G3_A35ParametrosCodigo ;
      private string[] T000G3_A145ParametrosNombres ;
      private string[] T000G3_A146ParametrosTipo ;
      private short[] T000G3_A147ParametrosMes ;
      private short[] T000G3_A148ParametrosAno ;
      private decimal[] T000G3_A149ParametrosValor ;
      private string[] T000G3_A4IndicadoresCodigo ;
      private short[] T000G8_A35ParametrosCodigo ;
      private short[] T000G9_A35ParametrosCodigo ;
      private short[] T000G2_A35ParametrosCodigo ;
      private string[] T000G2_A145ParametrosNombres ;
      private string[] T000G2_A146ParametrosTipo ;
      private short[] T000G2_A147ParametrosMes ;
      private short[] T000G2_A148ParametrosAno ;
      private decimal[] T000G2_A149ParametrosValor ;
      private string[] T000G2_A4IndicadoresCodigo ;
      private short[] T000G13_A35ParametrosCodigo ;
      private string[] T000G14_A4IndicadoresCodigo ;
      private GXWebForm Form ;
   }

   public class parametros__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[8])
         ,new UpdateCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000G5;
          prmT000G5 = new Object[] {
          new ParDef("@ParametrosCodigo",GXType.Int16,4,0)
          };
          Object[] prmT000G4;
          prmT000G4 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000G6;
          prmT000G6 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000G7;
          prmT000G7 = new Object[] {
          new ParDef("@ParametrosCodigo",GXType.Int16,4,0)
          };
          Object[] prmT000G3;
          prmT000G3 = new Object[] {
          new ParDef("@ParametrosCodigo",GXType.Int16,4,0)
          };
          Object[] prmT000G8;
          prmT000G8 = new Object[] {
          new ParDef("@ParametrosCodigo",GXType.Int16,4,0)
          };
          Object[] prmT000G9;
          prmT000G9 = new Object[] {
          new ParDef("@ParametrosCodigo",GXType.Int16,4,0)
          };
          Object[] prmT000G2;
          prmT000G2 = new Object[] {
          new ParDef("@ParametrosCodigo",GXType.Int16,4,0)
          };
          Object[] prmT000G10;
          prmT000G10 = new Object[] {
          new ParDef("@ParametrosCodigo",GXType.Int16,4,0) ,
          new ParDef("@ParametrosNombres",GXType.NVarChar,200,0) ,
          new ParDef("@ParametrosTipo",GXType.NVarChar,20,0) ,
          new ParDef("@ParametrosMes",GXType.Int16,4,0) ,
          new ParDef("@ParametrosAno",GXType.Int16,4,0) ,
          new ParDef("@ParametrosValor",GXType.Decimal,15,4) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000G11;
          prmT000G11 = new Object[] {
          new ParDef("@ParametrosNombres",GXType.NVarChar,200,0) ,
          new ParDef("@ParametrosTipo",GXType.NVarChar,20,0) ,
          new ParDef("@ParametrosMes",GXType.Int16,4,0) ,
          new ParDef("@ParametrosAno",GXType.Int16,4,0) ,
          new ParDef("@ParametrosValor",GXType.Decimal,15,4) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@ParametrosCodigo",GXType.Int16,4,0)
          };
          Object[] prmT000G12;
          prmT000G12 = new Object[] {
          new ParDef("@ParametrosCodigo",GXType.Int16,4,0)
          };
          Object[] prmT000G13;
          prmT000G13 = new Object[] {
          };
          Object[] prmT000G14;
          prmT000G14 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("T000G2", "SELECT [ParametrosCodigo], [ParametrosNombres], [ParametrosTipo], [ParametrosMes], [ParametrosAno], [ParametrosValor], [IndicadoresCodigo] FROM [Parametros] WITH (UPDLOCK) WHERE [ParametrosCodigo] = @ParametrosCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G3", "SELECT [ParametrosCodigo], [ParametrosNombres], [ParametrosTipo], [ParametrosMes], [ParametrosAno], [ParametrosValor], [IndicadoresCodigo] FROM [Parametros] WHERE [ParametrosCodigo] = @ParametrosCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G4", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G5", "SELECT TM1.[ParametrosCodigo], TM1.[ParametrosNombres], TM1.[ParametrosTipo], TM1.[ParametrosMes], TM1.[ParametrosAno], TM1.[ParametrosValor], TM1.[IndicadoresCodigo] FROM [Parametros] TM1 WHERE TM1.[ParametrosCodigo] = @ParametrosCodigo ORDER BY TM1.[ParametrosCodigo]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000G5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G6", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G7", "SELECT [ParametrosCodigo] FROM [Parametros] WHERE [ParametrosCodigo] = @ParametrosCodigo  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000G7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G8", "SELECT TOP 1 [ParametrosCodigo] FROM [Parametros] WHERE ( [ParametrosCodigo] > @ParametrosCodigo) ORDER BY [ParametrosCodigo]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000G8,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000G9", "SELECT TOP 1 [ParametrosCodigo] FROM [Parametros] WHERE ( [ParametrosCodigo] < @ParametrosCodigo) ORDER BY [ParametrosCodigo] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000G9,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000G10", "INSERT INTO [Parametros]([ParametrosCodigo], [ParametrosNombres], [ParametrosTipo], [ParametrosMes], [ParametrosAno], [ParametrosValor], [IndicadoresCodigo]) VALUES(@ParametrosCodigo, @ParametrosNombres, @ParametrosTipo, @ParametrosMes, @ParametrosAno, @ParametrosValor, @IndicadoresCodigo)", GxErrorMask.GX_NOMASK,prmT000G10)
             ,new CursorDef("T000G11", "UPDATE [Parametros] SET [ParametrosNombres]=@ParametrosNombres, [ParametrosTipo]=@ParametrosTipo, [ParametrosMes]=@ParametrosMes, [ParametrosAno]=@ParametrosAno, [ParametrosValor]=@ParametrosValor, [IndicadoresCodigo]=@IndicadoresCodigo  WHERE [ParametrosCodigo] = @ParametrosCodigo", GxErrorMask.GX_NOMASK,prmT000G11)
             ,new CursorDef("T000G12", "DELETE FROM [Parametros]  WHERE [ParametrosCodigo] = @ParametrosCodigo", GxErrorMask.GX_NOMASK,prmT000G12)
             ,new CursorDef("T000G13", "SELECT [ParametrosCodigo] FROM [Parametros] ORDER BY [ParametrosCodigo]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000G13,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000G14", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G14,1, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 12 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
       }
    }

 }

}
