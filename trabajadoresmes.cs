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
   public class trabajadoresmes : GXDataArea
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
            Form.Meta.addItem("description", "TRABAJADORESMES", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTRABAJADORESMESANO_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("IndicadroresPalmas", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public trabajadoresmes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("IndicadroresPalmas", true);
      }

      public trabajadoresmes( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "TRABAJADORESMES", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_TRABAJADORESMES.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TRABAJADORESMES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_TRABAJADORESMES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_TRABAJADORESMES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TRABAJADORESMES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 4, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx01a0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"TRABAJADORESMESANO"+"'), id:'"+"TRABAJADORESMESANO"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"TRABAJADORESMESMES"+"'), id:'"+"TRABAJADORESMESMES"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_TRABAJADORESMES.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTRABAJADORESMESANO_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTRABAJADORESMESANO_Internalname, "TRABAJADORESMESANO", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTRABAJADORESMESANO_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A112TRABAJADORESMESANO), 4, 0, ",", "")), StringUtil.LTrim( ((edtTRABAJADORESMESANO_Enabled!=0) ? context.localUtil.Format( (decimal)(A112TRABAJADORESMESANO), "ZZZ9") : context.localUtil.Format( (decimal)(A112TRABAJADORESMESANO), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTRABAJADORESMESANO_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTRABAJADORESMESANO_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_TRABAJADORESMES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTRABAJADORESMESMES_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTRABAJADORESMESMES_Internalname, "TRABAJADORESMESMES", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTRABAJADORESMESMES_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A113TRABAJADORESMESMES), 4, 0, ",", "")), StringUtil.LTrim( ((edtTRABAJADORESMESMES_Enabled!=0) ? context.localUtil.Format( (decimal)(A113TRABAJADORESMESMES), "ZZZ9") : context.localUtil.Format( (decimal)(A113TRABAJADORESMESMES), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTRABAJADORESMESMES_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTRABAJADORESMESMES_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_TRABAJADORESMES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTRABAJADORESMESNRO_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTRABAJADORESMESNRO_Internalname, "TRABAJADORESMESNRO", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTRABAJADORESMESNRO_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A288TRABAJADORESMESNRO), 10, 0, ",", "")), StringUtil.LTrim( ((edtTRABAJADORESMESNRO_Enabled!=0) ? context.localUtil.Format( (decimal)(A288TRABAJADORESMESNRO), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A288TRABAJADORESMESNRO), "ZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTRABAJADORESMESNRO_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTRABAJADORESMESNRO_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_TRABAJADORESMES.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_TRABAJADORESMES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_TRABAJADORESMES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_TRABAJADORESMES.htm");
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
            Z112TRABAJADORESMESANO = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z112TRABAJADORESMESANO"), ",", "."), 18, MidpointRounding.ToEven));
            Z113TRABAJADORESMESMES = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z113TRABAJADORESMESMES"), ",", "."), 18, MidpointRounding.ToEven));
            Z288TRABAJADORESMESNRO = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z288TRABAJADORESMESNRO"), ",", "."), 18, MidpointRounding.ToEven));
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtTRABAJADORESMESANO_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTRABAJADORESMESANO_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TRABAJADORESMESANO");
               AnyError = 1;
               GX_FocusControl = edtTRABAJADORESMESANO_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A112TRABAJADORESMESANO = 0;
               AssignAttri("", false, "A112TRABAJADORESMESANO", StringUtil.LTrimStr( (decimal)(A112TRABAJADORESMESANO), 4, 0));
            }
            else
            {
               A112TRABAJADORESMESANO = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtTRABAJADORESMESANO_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A112TRABAJADORESMESANO", StringUtil.LTrimStr( (decimal)(A112TRABAJADORESMESANO), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtTRABAJADORESMESMES_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTRABAJADORESMESMES_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TRABAJADORESMESMES");
               AnyError = 1;
               GX_FocusControl = edtTRABAJADORESMESMES_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A113TRABAJADORESMESMES = 0;
               AssignAttri("", false, "A113TRABAJADORESMESMES", StringUtil.LTrimStr( (decimal)(A113TRABAJADORESMESMES), 4, 0));
            }
            else
            {
               A113TRABAJADORESMESMES = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtTRABAJADORESMESMES_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A113TRABAJADORESMESMES", StringUtil.LTrimStr( (decimal)(A113TRABAJADORESMESMES), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtTRABAJADORESMESNRO_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTRABAJADORESMESNRO_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TRABAJADORESMESNRO");
               AnyError = 1;
               GX_FocusControl = edtTRABAJADORESMESNRO_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A288TRABAJADORESMESNRO = 0;
               AssignAttri("", false, "A288TRABAJADORESMESNRO", StringUtil.LTrimStr( (decimal)(A288TRABAJADORESMESNRO), 10, 0));
            }
            else
            {
               A288TRABAJADORESMESNRO = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtTRABAJADORESMESNRO_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A288TRABAJADORESMESNRO", StringUtil.LTrimStr( (decimal)(A288TRABAJADORESMESNRO), 10, 0));
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
               A112TRABAJADORESMESANO = (short)(Math.Round(NumberUtil.Val( GetPar( "TRABAJADORESMESANO"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A112TRABAJADORESMESANO", StringUtil.LTrimStr( (decimal)(A112TRABAJADORESMESANO), 4, 0));
               A113TRABAJADORESMESMES = (short)(Math.Round(NumberUtil.Val( GetPar( "TRABAJADORESMESMES"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A113TRABAJADORESMESMES", StringUtil.LTrimStr( (decimal)(A113TRABAJADORESMESMES), 4, 0));
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
               InitAll1946( ) ;
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
         DisableAttributes1946( ) ;
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

      protected void ResetCaption190( )
      {
      }

      protected void ZM1946( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z288TRABAJADORESMESNRO = T00193_A288TRABAJADORESMESNRO[0];
            }
            else
            {
               Z288TRABAJADORESMESNRO = A288TRABAJADORESMESNRO;
            }
         }
         if ( GX_JID == -1 )
         {
            Z112TRABAJADORESMESANO = A112TRABAJADORESMESANO;
            Z113TRABAJADORESMESMES = A113TRABAJADORESMESMES;
            Z288TRABAJADORESMESNRO = A288TRABAJADORESMESNRO;
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

      protected void Load1946( )
      {
         /* Using cursor T00194 */
         pr_default.execute(2, new Object[] {A112TRABAJADORESMESANO, A113TRABAJADORESMESMES});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound46 = 1;
            A288TRABAJADORESMESNRO = T00194_A288TRABAJADORESMESNRO[0];
            AssignAttri("", false, "A288TRABAJADORESMESNRO", StringUtil.LTrimStr( (decimal)(A288TRABAJADORESMESNRO), 10, 0));
            ZM1946( -1) ;
         }
         pr_default.close(2);
         OnLoadActions1946( ) ;
      }

      protected void OnLoadActions1946( )
      {
      }

      protected void CheckExtendedTable1946( )
      {
         nIsDirty_46 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors1946( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1946( )
      {
         /* Using cursor T00195 */
         pr_default.execute(3, new Object[] {A112TRABAJADORESMESANO, A113TRABAJADORESMESMES});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound46 = 1;
         }
         else
         {
            RcdFound46 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00193 */
         pr_default.execute(1, new Object[] {A112TRABAJADORESMESANO, A113TRABAJADORESMESMES});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1946( 1) ;
            RcdFound46 = 1;
            A112TRABAJADORESMESANO = T00193_A112TRABAJADORESMESANO[0];
            AssignAttri("", false, "A112TRABAJADORESMESANO", StringUtil.LTrimStr( (decimal)(A112TRABAJADORESMESANO), 4, 0));
            A113TRABAJADORESMESMES = T00193_A113TRABAJADORESMESMES[0];
            AssignAttri("", false, "A113TRABAJADORESMESMES", StringUtil.LTrimStr( (decimal)(A113TRABAJADORESMESMES), 4, 0));
            A288TRABAJADORESMESNRO = T00193_A288TRABAJADORESMESNRO[0];
            AssignAttri("", false, "A288TRABAJADORESMESNRO", StringUtil.LTrimStr( (decimal)(A288TRABAJADORESMESNRO), 10, 0));
            Z112TRABAJADORESMESANO = A112TRABAJADORESMESANO;
            Z113TRABAJADORESMESMES = A113TRABAJADORESMESMES;
            sMode46 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1946( ) ;
            if ( AnyError == 1 )
            {
               RcdFound46 = 0;
               InitializeNonKey1946( ) ;
            }
            Gx_mode = sMode46;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound46 = 0;
            InitializeNonKey1946( ) ;
            sMode46 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode46;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1946( ) ;
         if ( RcdFound46 == 0 )
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
         RcdFound46 = 0;
         /* Using cursor T00196 */
         pr_default.execute(4, new Object[] {A112TRABAJADORESMESANO, A113TRABAJADORESMESMES});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T00196_A112TRABAJADORESMESANO[0] < A112TRABAJADORESMESANO ) || ( T00196_A112TRABAJADORESMESANO[0] == A112TRABAJADORESMESANO ) && ( T00196_A113TRABAJADORESMESMES[0] < A113TRABAJADORESMESMES ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T00196_A112TRABAJADORESMESANO[0] > A112TRABAJADORESMESANO ) || ( T00196_A112TRABAJADORESMESANO[0] == A112TRABAJADORESMESANO ) && ( T00196_A113TRABAJADORESMESMES[0] > A113TRABAJADORESMESMES ) ) )
            {
               A112TRABAJADORESMESANO = T00196_A112TRABAJADORESMESANO[0];
               AssignAttri("", false, "A112TRABAJADORESMESANO", StringUtil.LTrimStr( (decimal)(A112TRABAJADORESMESANO), 4, 0));
               A113TRABAJADORESMESMES = T00196_A113TRABAJADORESMESMES[0];
               AssignAttri("", false, "A113TRABAJADORESMESMES", StringUtil.LTrimStr( (decimal)(A113TRABAJADORESMESMES), 4, 0));
               RcdFound46 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound46 = 0;
         /* Using cursor T00197 */
         pr_default.execute(5, new Object[] {A112TRABAJADORESMESANO, A113TRABAJADORESMESMES});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T00197_A112TRABAJADORESMESANO[0] > A112TRABAJADORESMESANO ) || ( T00197_A112TRABAJADORESMESANO[0] == A112TRABAJADORESMESANO ) && ( T00197_A113TRABAJADORESMESMES[0] > A113TRABAJADORESMESMES ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T00197_A112TRABAJADORESMESANO[0] < A112TRABAJADORESMESANO ) || ( T00197_A112TRABAJADORESMESANO[0] == A112TRABAJADORESMESANO ) && ( T00197_A113TRABAJADORESMESMES[0] < A113TRABAJADORESMESMES ) ) )
            {
               A112TRABAJADORESMESANO = T00197_A112TRABAJADORESMESANO[0];
               AssignAttri("", false, "A112TRABAJADORESMESANO", StringUtil.LTrimStr( (decimal)(A112TRABAJADORESMESANO), 4, 0));
               A113TRABAJADORESMESMES = T00197_A113TRABAJADORESMESMES[0];
               AssignAttri("", false, "A113TRABAJADORESMESMES", StringUtil.LTrimStr( (decimal)(A113TRABAJADORESMESMES), 4, 0));
               RcdFound46 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1946( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTRABAJADORESMESANO_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1946( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound46 == 1 )
            {
               if ( ( A112TRABAJADORESMESANO != Z112TRABAJADORESMESANO ) || ( A113TRABAJADORESMESMES != Z113TRABAJADORESMESMES ) )
               {
                  A112TRABAJADORESMESANO = Z112TRABAJADORESMESANO;
                  AssignAttri("", false, "A112TRABAJADORESMESANO", StringUtil.LTrimStr( (decimal)(A112TRABAJADORESMESANO), 4, 0));
                  A113TRABAJADORESMESMES = Z113TRABAJADORESMESMES;
                  AssignAttri("", false, "A113TRABAJADORESMESMES", StringUtil.LTrimStr( (decimal)(A113TRABAJADORESMESMES), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TRABAJADORESMESANO");
                  AnyError = 1;
                  GX_FocusControl = edtTRABAJADORESMESANO_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTRABAJADORESMESANO_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1946( ) ;
                  GX_FocusControl = edtTRABAJADORESMESANO_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A112TRABAJADORESMESANO != Z112TRABAJADORESMESANO ) || ( A113TRABAJADORESMESMES != Z113TRABAJADORESMESMES ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtTRABAJADORESMESANO_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1946( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TRABAJADORESMESANO");
                     AnyError = 1;
                     GX_FocusControl = edtTRABAJADORESMESANO_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtTRABAJADORESMESANO_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1946( ) ;
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
         if ( ( A112TRABAJADORESMESANO != Z112TRABAJADORESMESANO ) || ( A113TRABAJADORESMESMES != Z113TRABAJADORESMESMES ) )
         {
            A112TRABAJADORESMESANO = Z112TRABAJADORESMESANO;
            AssignAttri("", false, "A112TRABAJADORESMESANO", StringUtil.LTrimStr( (decimal)(A112TRABAJADORESMESANO), 4, 0));
            A113TRABAJADORESMESMES = Z113TRABAJADORESMESMES;
            AssignAttri("", false, "A113TRABAJADORESMESMES", StringUtil.LTrimStr( (decimal)(A113TRABAJADORESMESMES), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TRABAJADORESMESANO");
            AnyError = 1;
            GX_FocusControl = edtTRABAJADORESMESANO_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTRABAJADORESMESANO_Internalname;
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
         if ( RcdFound46 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "TRABAJADORESMESANO");
            AnyError = 1;
            GX_FocusControl = edtTRABAJADORESMESANO_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtTRABAJADORESMESNRO_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1946( ) ;
         if ( RcdFound46 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTRABAJADORESMESNRO_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1946( ) ;
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
         if ( RcdFound46 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTRABAJADORESMESNRO_Internalname;
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
         if ( RcdFound46 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTRABAJADORESMESNRO_Internalname;
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
         ScanStart1946( ) ;
         if ( RcdFound46 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound46 != 0 )
            {
               ScanNext1946( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTRABAJADORESMESNRO_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1946( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1946( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00192 */
            pr_default.execute(0, new Object[] {A112TRABAJADORESMESANO, A113TRABAJADORESMESMES});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TRABAJADORESMES"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z288TRABAJADORESMESNRO != T00192_A288TRABAJADORESMESNRO[0] ) )
            {
               if ( Z288TRABAJADORESMESNRO != T00192_A288TRABAJADORESMESNRO[0] )
               {
                  GXUtil.WriteLog("trabajadoresmes:[seudo value changed for attri]"+"TRABAJADORESMESNRO");
                  GXUtil.WriteLogRaw("Old: ",Z288TRABAJADORESMESNRO);
                  GXUtil.WriteLogRaw("Current: ",T00192_A288TRABAJADORESMESNRO[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TRABAJADORESMES"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1946( )
      {
         BeforeValidate1946( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1946( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1946( 0) ;
            CheckOptimisticConcurrency1946( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1946( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1946( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00198 */
                     pr_default.execute(6, new Object[] {A112TRABAJADORESMESANO, A113TRABAJADORESMESMES, A288TRABAJADORESMESNRO});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("TRABAJADORESMES");
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
                           ResetCaption190( ) ;
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
               Load1946( ) ;
            }
            EndLevel1946( ) ;
         }
         CloseExtendedTableCursors1946( ) ;
      }

      protected void Update1946( )
      {
         BeforeValidate1946( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1946( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1946( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1946( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1946( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00199 */
                     pr_default.execute(7, new Object[] {A288TRABAJADORESMESNRO, A112TRABAJADORESMESANO, A113TRABAJADORESMESMES});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("TRABAJADORESMES");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TRABAJADORESMES"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1946( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption190( ) ;
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
            EndLevel1946( ) ;
         }
         CloseExtendedTableCursors1946( ) ;
      }

      protected void DeferredUpdate1946( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1946( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1946( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1946( ) ;
            AfterConfirm1946( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1946( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001910 */
                  pr_default.execute(8, new Object[] {A112TRABAJADORESMESANO, A113TRABAJADORESMESMES});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("TRABAJADORESMES");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound46 == 0 )
                        {
                           InitAll1946( ) ;
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
                        ResetCaption190( ) ;
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
         sMode46 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1946( ) ;
         Gx_mode = sMode46;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1946( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1946( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1946( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("trabajadoresmes",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues190( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("trabajadoresmes",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1946( )
      {
         /* Using cursor T001911 */
         pr_default.execute(9);
         RcdFound46 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound46 = 1;
            A112TRABAJADORESMESANO = T001911_A112TRABAJADORESMESANO[0];
            AssignAttri("", false, "A112TRABAJADORESMESANO", StringUtil.LTrimStr( (decimal)(A112TRABAJADORESMESANO), 4, 0));
            A113TRABAJADORESMESMES = T001911_A113TRABAJADORESMESMES[0];
            AssignAttri("", false, "A113TRABAJADORESMESMES", StringUtil.LTrimStr( (decimal)(A113TRABAJADORESMESMES), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1946( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound46 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound46 = 1;
            A112TRABAJADORESMESANO = T001911_A112TRABAJADORESMESANO[0];
            AssignAttri("", false, "A112TRABAJADORESMESANO", StringUtil.LTrimStr( (decimal)(A112TRABAJADORESMESANO), 4, 0));
            A113TRABAJADORESMESMES = T001911_A113TRABAJADORESMESMES[0];
            AssignAttri("", false, "A113TRABAJADORESMESMES", StringUtil.LTrimStr( (decimal)(A113TRABAJADORESMESMES), 4, 0));
         }
      }

      protected void ScanEnd1946( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm1946( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1946( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1946( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1946( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1946( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1946( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1946( )
      {
         edtTRABAJADORESMESANO_Enabled = 0;
         AssignProp("", false, edtTRABAJADORESMESANO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTRABAJADORESMESANO_Enabled), 5, 0), true);
         edtTRABAJADORESMESMES_Enabled = 0;
         AssignProp("", false, edtTRABAJADORESMESMES_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTRABAJADORESMESMES_Enabled), 5, 0), true);
         edtTRABAJADORESMESNRO_Enabled = 0;
         AssignProp("", false, edtTRABAJADORESMESNRO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTRABAJADORESMESNRO_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1946( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues190( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trabajadoresmes.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z112TRABAJADORESMESANO", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z112TRABAJADORESMESANO), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z113TRABAJADORESMESMES", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z113TRABAJADORESMESMES), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z288TRABAJADORESMESNRO", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z288TRABAJADORESMESNRO), 10, 0, ",", "")));
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
         return formatLink("trabajadoresmes.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "TRABAJADORESMES" ;
      }

      public override string GetPgmdesc( )
      {
         return "TRABAJADORESMES" ;
      }

      protected void InitializeNonKey1946( )
      {
         A288TRABAJADORESMESNRO = 0;
         AssignAttri("", false, "A288TRABAJADORESMESNRO", StringUtil.LTrimStr( (decimal)(A288TRABAJADORESMESNRO), 10, 0));
         Z288TRABAJADORESMESNRO = 0;
      }

      protected void InitAll1946( )
      {
         A112TRABAJADORESMESANO = 0;
         AssignAttri("", false, "A112TRABAJADORESMESANO", StringUtil.LTrimStr( (decimal)(A112TRABAJADORESMESANO), 4, 0));
         A113TRABAJADORESMESMES = 0;
         AssignAttri("", false, "A113TRABAJADORESMESMES", StringUtil.LTrimStr( (decimal)(A113TRABAJADORESMESMES), 4, 0));
         InitializeNonKey1946( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024723103024", true, true);
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
         context.AddJavascriptSource("trabajadoresmes.js", "?2024723103024", false, true);
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
         edtTRABAJADORESMESANO_Internalname = "TRABAJADORESMESANO";
         edtTRABAJADORESMESMES_Internalname = "TRABAJADORESMESMES";
         edtTRABAJADORESMESNRO_Internalname = "TRABAJADORESMESNRO";
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
         Form.Caption = "TRABAJADORESMES";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtTRABAJADORESMESNRO_Jsonclick = "";
         edtTRABAJADORESMESNRO_Enabled = 1;
         edtTRABAJADORESMESMES_Jsonclick = "";
         edtTRABAJADORESMESMES_Enabled = 1;
         edtTRABAJADORESMESANO_Jsonclick = "";
         edtTRABAJADORESMESANO_Enabled = 1;
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
         GX_FocusControl = edtTRABAJADORESMESNRO_Internalname;
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

      public void Valid_Trabajadoresmesmes( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A288TRABAJADORESMESNRO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A288TRABAJADORESMESNRO), 10, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z112TRABAJADORESMESANO", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z112TRABAJADORESMESANO), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z113TRABAJADORESMESMES", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z113TRABAJADORESMESMES), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z288TRABAJADORESMESNRO", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z288TRABAJADORESMESNRO), 10, 0, ".", "")));
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
         setEventMetadata("VALID_TRABAJADORESMESANO","{handler:'Valid_Trabajadoresmesano',iparms:[]");
         setEventMetadata("VALID_TRABAJADORESMESANO",",oparms:[]}");
         setEventMetadata("VALID_TRABAJADORESMESMES","{handler:'Valid_Trabajadoresmesmes',iparms:[{av:'A112TRABAJADORESMESANO',fld:'TRABAJADORESMESANO',pic:'ZZZ9'},{av:'A113TRABAJADORESMESMES',fld:'TRABAJADORESMESMES',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_TRABAJADORESMESMES",",oparms:[{av:'A288TRABAJADORESMESNRO',fld:'TRABAJADORESMESNRO',pic:'ZZZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z112TRABAJADORESMESANO'},{av:'Z113TRABAJADORESMESMES'},{av:'Z288TRABAJADORESMESNRO'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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
         T00194_A112TRABAJADORESMESANO = new short[1] ;
         T00194_A113TRABAJADORESMESMES = new short[1] ;
         T00194_A288TRABAJADORESMESNRO = new long[1] ;
         T00195_A112TRABAJADORESMESANO = new short[1] ;
         T00195_A113TRABAJADORESMESMES = new short[1] ;
         T00193_A112TRABAJADORESMESANO = new short[1] ;
         T00193_A113TRABAJADORESMESMES = new short[1] ;
         T00193_A288TRABAJADORESMESNRO = new long[1] ;
         sMode46 = "";
         T00196_A112TRABAJADORESMESANO = new short[1] ;
         T00196_A113TRABAJADORESMESMES = new short[1] ;
         T00197_A112TRABAJADORESMESANO = new short[1] ;
         T00197_A113TRABAJADORESMESMES = new short[1] ;
         T00192_A112TRABAJADORESMESANO = new short[1] ;
         T00192_A113TRABAJADORESMESMES = new short[1] ;
         T00192_A288TRABAJADORESMESNRO = new long[1] ;
         T001911_A112TRABAJADORESMESANO = new short[1] ;
         T001911_A113TRABAJADORESMESMES = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trabajadoresmes__default(),
            new Object[][] {
                new Object[] {
               T00192_A112TRABAJADORESMESANO, T00192_A113TRABAJADORESMESMES, T00192_A288TRABAJADORESMESNRO
               }
               , new Object[] {
               T00193_A112TRABAJADORESMESANO, T00193_A113TRABAJADORESMESMES, T00193_A288TRABAJADORESMESNRO
               }
               , new Object[] {
               T00194_A112TRABAJADORESMESANO, T00194_A113TRABAJADORESMESMES, T00194_A288TRABAJADORESMESNRO
               }
               , new Object[] {
               T00195_A112TRABAJADORESMESANO, T00195_A113TRABAJADORESMESMES
               }
               , new Object[] {
               T00196_A112TRABAJADORESMESANO, T00196_A113TRABAJADORESMESMES
               }
               , new Object[] {
               T00197_A112TRABAJADORESMESANO, T00197_A113TRABAJADORESMESMES
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001911_A112TRABAJADORESMESANO, T001911_A113TRABAJADORESMESMES
               }
            }
         );
      }

      private short Z112TRABAJADORESMESANO ;
      private short Z113TRABAJADORESMESMES ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A112TRABAJADORESMESANO ;
      private short A113TRABAJADORESMESMES ;
      private short GX_JID ;
      private short RcdFound46 ;
      private short nIsDirty_46 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ112TRABAJADORESMESANO ;
      private short ZZ113TRABAJADORESMESMES ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtTRABAJADORESMESANO_Enabled ;
      private int edtTRABAJADORESMESMES_Enabled ;
      private int edtTRABAJADORESMESNRO_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z288TRABAJADORESMESNRO ;
      private long A288TRABAJADORESMESNRO ;
      private long ZZ288TRABAJADORESMESNRO ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTRABAJADORESMESANO_Internalname ;
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
      private string edtTRABAJADORESMESANO_Jsonclick ;
      private string edtTRABAJADORESMESMES_Internalname ;
      private string edtTRABAJADORESMESMES_Jsonclick ;
      private string edtTRABAJADORESMESNRO_Internalname ;
      private string edtTRABAJADORESMESNRO_Jsonclick ;
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
      private string sMode46 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T00194_A112TRABAJADORESMESANO ;
      private short[] T00194_A113TRABAJADORESMESMES ;
      private long[] T00194_A288TRABAJADORESMESNRO ;
      private short[] T00195_A112TRABAJADORESMESANO ;
      private short[] T00195_A113TRABAJADORESMESMES ;
      private short[] T00193_A112TRABAJADORESMESANO ;
      private short[] T00193_A113TRABAJADORESMESMES ;
      private long[] T00193_A288TRABAJADORESMESNRO ;
      private short[] T00196_A112TRABAJADORESMESANO ;
      private short[] T00196_A113TRABAJADORESMESMES ;
      private short[] T00197_A112TRABAJADORESMESANO ;
      private short[] T00197_A113TRABAJADORESMESMES ;
      private short[] T00192_A112TRABAJADORESMESANO ;
      private short[] T00192_A113TRABAJADORESMESMES ;
      private long[] T00192_A288TRABAJADORESMESNRO ;
      private short[] T001911_A112TRABAJADORESMESANO ;
      private short[] T001911_A113TRABAJADORESMESMES ;
      private GXWebForm Form ;
   }

   public class trabajadoresmes__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00194;
          prmT00194 = new Object[] {
          new ParDef("@TRABAJADORESMESANO",GXType.Int16,4,0) ,
          new ParDef("@TRABAJADORESMESMES",GXType.Int16,4,0)
          };
          Object[] prmT00195;
          prmT00195 = new Object[] {
          new ParDef("@TRABAJADORESMESANO",GXType.Int16,4,0) ,
          new ParDef("@TRABAJADORESMESMES",GXType.Int16,4,0)
          };
          Object[] prmT00193;
          prmT00193 = new Object[] {
          new ParDef("@TRABAJADORESMESANO",GXType.Int16,4,0) ,
          new ParDef("@TRABAJADORESMESMES",GXType.Int16,4,0)
          };
          Object[] prmT00196;
          prmT00196 = new Object[] {
          new ParDef("@TRABAJADORESMESANO",GXType.Int16,4,0) ,
          new ParDef("@TRABAJADORESMESMES",GXType.Int16,4,0)
          };
          Object[] prmT00197;
          prmT00197 = new Object[] {
          new ParDef("@TRABAJADORESMESANO",GXType.Int16,4,0) ,
          new ParDef("@TRABAJADORESMESMES",GXType.Int16,4,0)
          };
          Object[] prmT00192;
          prmT00192 = new Object[] {
          new ParDef("@TRABAJADORESMESANO",GXType.Int16,4,0) ,
          new ParDef("@TRABAJADORESMESMES",GXType.Int16,4,0)
          };
          Object[] prmT00198;
          prmT00198 = new Object[] {
          new ParDef("@TRABAJADORESMESANO",GXType.Int16,4,0) ,
          new ParDef("@TRABAJADORESMESMES",GXType.Int16,4,0) ,
          new ParDef("@TRABAJADORESMESNRO",GXType.Decimal,10,0)
          };
          Object[] prmT00199;
          prmT00199 = new Object[] {
          new ParDef("@TRABAJADORESMESNRO",GXType.Decimal,10,0) ,
          new ParDef("@TRABAJADORESMESANO",GXType.Int16,4,0) ,
          new ParDef("@TRABAJADORESMESMES",GXType.Int16,4,0)
          };
          Object[] prmT001910;
          prmT001910 = new Object[] {
          new ParDef("@TRABAJADORESMESANO",GXType.Int16,4,0) ,
          new ParDef("@TRABAJADORESMESMES",GXType.Int16,4,0)
          };
          Object[] prmT001911;
          prmT001911 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T00192", "SELECT [TRABAJADORESMESANO], [TRABAJADORESMESMES], [TRABAJADORESMESNRO] FROM [TRABAJADORESMES] WITH (UPDLOCK) WHERE [TRABAJADORESMESANO] = @TRABAJADORESMESANO AND [TRABAJADORESMESMES] = @TRABAJADORESMESMES ",true, GxErrorMask.GX_NOMASK, false, this,prmT00192,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00193", "SELECT [TRABAJADORESMESANO], [TRABAJADORESMESMES], [TRABAJADORESMESNRO] FROM [TRABAJADORESMES] WHERE [TRABAJADORESMESANO] = @TRABAJADORESMESANO AND [TRABAJADORESMESMES] = @TRABAJADORESMESMES ",true, GxErrorMask.GX_NOMASK, false, this,prmT00193,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00194", "SELECT TM1.[TRABAJADORESMESANO], TM1.[TRABAJADORESMESMES], TM1.[TRABAJADORESMESNRO] FROM [TRABAJADORESMES] TM1 WHERE TM1.[TRABAJADORESMESANO] = @TRABAJADORESMESANO and TM1.[TRABAJADORESMESMES] = @TRABAJADORESMESMES ORDER BY TM1.[TRABAJADORESMESANO], TM1.[TRABAJADORESMESMES]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00194,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00195", "SELECT [TRABAJADORESMESANO], [TRABAJADORESMESMES] FROM [TRABAJADORESMES] WHERE [TRABAJADORESMESANO] = @TRABAJADORESMESANO AND [TRABAJADORESMESMES] = @TRABAJADORESMESMES  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00195,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00196", "SELECT TOP 1 [TRABAJADORESMESANO], [TRABAJADORESMESMES] FROM [TRABAJADORESMES] WHERE ( [TRABAJADORESMESANO] > @TRABAJADORESMESANO or [TRABAJADORESMESANO] = @TRABAJADORESMESANO and [TRABAJADORESMESMES] > @TRABAJADORESMESMES) ORDER BY [TRABAJADORESMESANO], [TRABAJADORESMESMES]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00196,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00197", "SELECT TOP 1 [TRABAJADORESMESANO], [TRABAJADORESMESMES] FROM [TRABAJADORESMES] WHERE ( [TRABAJADORESMESANO] < @TRABAJADORESMESANO or [TRABAJADORESMESANO] = @TRABAJADORESMESANO and [TRABAJADORESMESMES] < @TRABAJADORESMESMES) ORDER BY [TRABAJADORESMESANO] DESC, [TRABAJADORESMESMES] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00197,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00198", "INSERT INTO [TRABAJADORESMES]([TRABAJADORESMESANO], [TRABAJADORESMESMES], [TRABAJADORESMESNRO]) VALUES(@TRABAJADORESMESANO, @TRABAJADORESMESMES, @TRABAJADORESMESNRO)", GxErrorMask.GX_NOMASK,prmT00198)
             ,new CursorDef("T00199", "UPDATE [TRABAJADORESMES] SET [TRABAJADORESMESNRO]=@TRABAJADORESMESNRO  WHERE [TRABAJADORESMESANO] = @TRABAJADORESMESANO AND [TRABAJADORESMESMES] = @TRABAJADORESMESMES", GxErrorMask.GX_NOMASK,prmT00199)
             ,new CursorDef("T001910", "DELETE FROM [TRABAJADORESMES]  WHERE [TRABAJADORESMESANO] = @TRABAJADORESMESANO AND [TRABAJADORESMESMES] = @TRABAJADORESMESMES", GxErrorMask.GX_NOMASK,prmT001910)
             ,new CursorDef("T001911", "SELECT [TRABAJADORESMESANO], [TRABAJADORESMESMES] FROM [TRABAJADORESMES] ORDER BY [TRABAJADORESMESANO], [TRABAJADORESMESMES]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001911,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
       }
    }

 }

}
