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
   public class zonalotes : GXDataArea
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
            Form.Meta.addItem("description", "ZONALOTES", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtZONALOTESCODZON_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("IndicadroresPalmas", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public zonalotes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("IndicadroresPalmas", true);
      }

      public zonalotes( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "ZONALOTES", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_ZONALOTES.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ZONALOTES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_ZONALOTES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_ZONALOTES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ZONALOTES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 4, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx0190.aspx"+"',["+"{Ctrl:gx.dom.el('"+"ZONALOTESCODZON"+"'), id:'"+"ZONALOTESCODZON"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"ZONALOTESCODLOT"+"'), id:'"+"ZONALOTESCODLOT"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_ZONALOTES.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtZONALOTESCODZON_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtZONALOTESCODZON_Internalname, "ZONALOTESCODZON", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtZONALOTESCODZON_Internalname, A92ZONALOTESCODZON, StringUtil.RTrim( context.localUtil.Format( A92ZONALOTESCODZON, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtZONALOTESCODZON_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtZONALOTESCODZON_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_ZONALOTES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtZONALOTESCODLOT_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtZONALOTESCODLOT_Internalname, "ZONALOTESCODLOT", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtZONALOTESCODLOT_Internalname, A93ZONALOTESCODLOT, StringUtil.RTrim( context.localUtil.Format( A93ZONALOTESCODLOT, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtZONALOTESCODLOT_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtZONALOTESCODLOT_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_ZONALOTES.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ZONALOTES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ZONALOTES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ZONALOTES.htm");
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
            Z92ZONALOTESCODZON = cgiGet( "Z92ZONALOTESCODZON");
            Z93ZONALOTESCODLOT = cgiGet( "Z93ZONALOTESCODLOT");
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A92ZONALOTESCODZON = cgiGet( edtZONALOTESCODZON_Internalname);
            AssignAttri("", false, "A92ZONALOTESCODZON", A92ZONALOTESCODZON);
            A93ZONALOTESCODLOT = cgiGet( edtZONALOTESCODLOT_Internalname);
            AssignAttri("", false, "A93ZONALOTESCODLOT", A93ZONALOTESCODLOT);
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
               A92ZONALOTESCODZON = GetPar( "ZONALOTESCODZON");
               AssignAttri("", false, "A92ZONALOTESCODZON", A92ZONALOTESCODZON);
               A93ZONALOTESCODLOT = GetPar( "ZONALOTESCODLOT");
               AssignAttri("", false, "A93ZONALOTESCODLOT", A93ZONALOTESCODLOT);
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
               InitAll1845( ) ;
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
         DisableAttributes1845( ) ;
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

      protected void ResetCaption180( )
      {
      }

      protected void ZM1845( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
            }
            else
            {
            }
         }
         if ( GX_JID == -1 )
         {
            Z92ZONALOTESCODZON = A92ZONALOTESCODZON;
            Z93ZONALOTESCODLOT = A93ZONALOTESCODLOT;
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

      protected void Load1845( )
      {
         /* Using cursor T00184 */
         pr_default.execute(2, new Object[] {A92ZONALOTESCODZON, A93ZONALOTESCODLOT});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound45 = 1;
            ZM1845( -1) ;
         }
         pr_default.close(2);
         OnLoadActions1845( ) ;
      }

      protected void OnLoadActions1845( )
      {
      }

      protected void CheckExtendedTable1845( )
      {
         nIsDirty_45 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors1845( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1845( )
      {
         /* Using cursor T00185 */
         pr_default.execute(3, new Object[] {A92ZONALOTESCODZON, A93ZONALOTESCODLOT});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound45 = 1;
         }
         else
         {
            RcdFound45 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00183 */
         pr_default.execute(1, new Object[] {A92ZONALOTESCODZON, A93ZONALOTESCODLOT});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1845( 1) ;
            RcdFound45 = 1;
            A92ZONALOTESCODZON = T00183_A92ZONALOTESCODZON[0];
            AssignAttri("", false, "A92ZONALOTESCODZON", A92ZONALOTESCODZON);
            A93ZONALOTESCODLOT = T00183_A93ZONALOTESCODLOT[0];
            AssignAttri("", false, "A93ZONALOTESCODLOT", A93ZONALOTESCODLOT);
            Z92ZONALOTESCODZON = A92ZONALOTESCODZON;
            Z93ZONALOTESCODLOT = A93ZONALOTESCODLOT;
            sMode45 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1845( ) ;
            if ( AnyError == 1 )
            {
               RcdFound45 = 0;
               InitializeNonKey1845( ) ;
            }
            Gx_mode = sMode45;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound45 = 0;
            InitializeNonKey1845( ) ;
            sMode45 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode45;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1845( ) ;
         if ( RcdFound45 == 0 )
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
         RcdFound45 = 0;
         /* Using cursor T00186 */
         pr_default.execute(4, new Object[] {A92ZONALOTESCODZON, A93ZONALOTESCODLOT});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T00186_A92ZONALOTESCODZON[0], A92ZONALOTESCODZON) < 0 ) || ( StringUtil.StrCmp(T00186_A92ZONALOTESCODZON[0], A92ZONALOTESCODZON) == 0 ) && ( StringUtil.StrCmp(T00186_A93ZONALOTESCODLOT[0], A93ZONALOTESCODLOT) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T00186_A92ZONALOTESCODZON[0], A92ZONALOTESCODZON) > 0 ) || ( StringUtil.StrCmp(T00186_A92ZONALOTESCODZON[0], A92ZONALOTESCODZON) == 0 ) && ( StringUtil.StrCmp(T00186_A93ZONALOTESCODLOT[0], A93ZONALOTESCODLOT) > 0 ) ) )
            {
               A92ZONALOTESCODZON = T00186_A92ZONALOTESCODZON[0];
               AssignAttri("", false, "A92ZONALOTESCODZON", A92ZONALOTESCODZON);
               A93ZONALOTESCODLOT = T00186_A93ZONALOTESCODLOT[0];
               AssignAttri("", false, "A93ZONALOTESCODLOT", A93ZONALOTESCODLOT);
               RcdFound45 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound45 = 0;
         /* Using cursor T00187 */
         pr_default.execute(5, new Object[] {A92ZONALOTESCODZON, A93ZONALOTESCODLOT});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T00187_A92ZONALOTESCODZON[0], A92ZONALOTESCODZON) > 0 ) || ( StringUtil.StrCmp(T00187_A92ZONALOTESCODZON[0], A92ZONALOTESCODZON) == 0 ) && ( StringUtil.StrCmp(T00187_A93ZONALOTESCODLOT[0], A93ZONALOTESCODLOT) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T00187_A92ZONALOTESCODZON[0], A92ZONALOTESCODZON) < 0 ) || ( StringUtil.StrCmp(T00187_A92ZONALOTESCODZON[0], A92ZONALOTESCODZON) == 0 ) && ( StringUtil.StrCmp(T00187_A93ZONALOTESCODLOT[0], A93ZONALOTESCODLOT) < 0 ) ) )
            {
               A92ZONALOTESCODZON = T00187_A92ZONALOTESCODZON[0];
               AssignAttri("", false, "A92ZONALOTESCODZON", A92ZONALOTESCODZON);
               A93ZONALOTESCODLOT = T00187_A93ZONALOTESCODLOT[0];
               AssignAttri("", false, "A93ZONALOTESCODLOT", A93ZONALOTESCODLOT);
               RcdFound45 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1845( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtZONALOTESCODZON_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1845( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound45 == 1 )
            {
               if ( ( StringUtil.StrCmp(A92ZONALOTESCODZON, Z92ZONALOTESCODZON) != 0 ) || ( StringUtil.StrCmp(A93ZONALOTESCODLOT, Z93ZONALOTESCODLOT) != 0 ) )
               {
                  A92ZONALOTESCODZON = Z92ZONALOTESCODZON;
                  AssignAttri("", false, "A92ZONALOTESCODZON", A92ZONALOTESCODZON);
                  A93ZONALOTESCODLOT = Z93ZONALOTESCODLOT;
                  AssignAttri("", false, "A93ZONALOTESCODLOT", A93ZONALOTESCODLOT);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ZONALOTESCODZON");
                  AnyError = 1;
                  GX_FocusControl = edtZONALOTESCODZON_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtZONALOTESCODZON_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1845( ) ;
                  GX_FocusControl = edtZONALOTESCODZON_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A92ZONALOTESCODZON, Z92ZONALOTESCODZON) != 0 ) || ( StringUtil.StrCmp(A93ZONALOTESCODLOT, Z93ZONALOTESCODLOT) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtZONALOTESCODZON_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1845( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ZONALOTESCODZON");
                     AnyError = 1;
                     GX_FocusControl = edtZONALOTESCODZON_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtZONALOTESCODZON_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1845( ) ;
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
         if ( ( StringUtil.StrCmp(A92ZONALOTESCODZON, Z92ZONALOTESCODZON) != 0 ) || ( StringUtil.StrCmp(A93ZONALOTESCODLOT, Z93ZONALOTESCODLOT) != 0 ) )
         {
            A92ZONALOTESCODZON = Z92ZONALOTESCODZON;
            AssignAttri("", false, "A92ZONALOTESCODZON", A92ZONALOTESCODZON);
            A93ZONALOTESCODLOT = Z93ZONALOTESCODLOT;
            AssignAttri("", false, "A93ZONALOTESCODLOT", A93ZONALOTESCODLOT);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ZONALOTESCODZON");
            AnyError = 1;
            GX_FocusControl = edtZONALOTESCODZON_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtZONALOTESCODZON_Internalname;
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
         if ( RcdFound45 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "ZONALOTESCODZON");
            AnyError = 1;
            GX_FocusControl = edtZONALOTESCODZON_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1845( ) ;
         if ( RcdFound45 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         ScanEnd1845( ) ;
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
         if ( RcdFound45 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
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
         if ( RcdFound45 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1845( ) ;
         if ( RcdFound45 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound45 != 0 )
            {
               ScanNext1845( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         ScanEnd1845( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1845( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00182 */
            pr_default.execute(0, new Object[] {A92ZONALOTESCODZON, A93ZONALOTESCODLOT});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ZONALOTES"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ZONALOTES"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1845( )
      {
         BeforeValidate1845( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1845( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1845( 0) ;
            CheckOptimisticConcurrency1845( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1845( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1845( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00188 */
                     pr_default.execute(6, new Object[] {A92ZONALOTESCODZON, A93ZONALOTESCODLOT});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("ZONALOTES");
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
                           ResetCaption180( ) ;
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
               Load1845( ) ;
            }
            EndLevel1845( ) ;
         }
         CloseExtendedTableCursors1845( ) ;
      }

      protected void Update1845( )
      {
         BeforeValidate1845( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1845( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1845( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1845( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1845( ) ;
                  if ( AnyError == 0 )
                  {
                     /* No attributes to update on table [ZONALOTES] */
                     DeferredUpdate1845( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption180( ) ;
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
            EndLevel1845( ) ;
         }
         CloseExtendedTableCursors1845( ) ;
      }

      protected void DeferredUpdate1845( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1845( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1845( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1845( ) ;
            AfterConfirm1845( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1845( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T00189 */
                  pr_default.execute(7, new Object[] {A92ZONALOTESCODZON, A93ZONALOTESCODLOT});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("ZONALOTES");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound45 == 0 )
                        {
                           InitAll1845( ) ;
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
                        ResetCaption180( ) ;
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
         sMode45 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1845( ) ;
         Gx_mode = sMode45;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1845( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1845( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1845( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("zonalotes",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues180( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("zonalotes",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1845( )
      {
         /* Using cursor T001810 */
         pr_default.execute(8);
         RcdFound45 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound45 = 1;
            A92ZONALOTESCODZON = T001810_A92ZONALOTESCODZON[0];
            AssignAttri("", false, "A92ZONALOTESCODZON", A92ZONALOTESCODZON);
            A93ZONALOTESCODLOT = T001810_A93ZONALOTESCODLOT[0];
            AssignAttri("", false, "A93ZONALOTESCODLOT", A93ZONALOTESCODLOT);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1845( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound45 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound45 = 1;
            A92ZONALOTESCODZON = T001810_A92ZONALOTESCODZON[0];
            AssignAttri("", false, "A92ZONALOTESCODZON", A92ZONALOTESCODZON);
            A93ZONALOTESCODLOT = T001810_A93ZONALOTESCODLOT[0];
            AssignAttri("", false, "A93ZONALOTESCODLOT", A93ZONALOTESCODLOT);
         }
      }

      protected void ScanEnd1845( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm1845( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1845( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1845( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1845( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1845( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1845( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1845( )
      {
         edtZONALOTESCODZON_Enabled = 0;
         AssignProp("", false, edtZONALOTESCODZON_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtZONALOTESCODZON_Enabled), 5, 0), true);
         edtZONALOTESCODLOT_Enabled = 0;
         AssignProp("", false, edtZONALOTESCODLOT_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtZONALOTESCODLOT_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1845( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues180( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("zonalotes.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z92ZONALOTESCODZON", Z92ZONALOTESCODZON);
         GxWebStd.gx_hidden_field( context, "Z93ZONALOTESCODLOT", Z93ZONALOTESCODLOT);
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
         return formatLink("zonalotes.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "ZONALOTES" ;
      }

      public override string GetPgmdesc( )
      {
         return "ZONALOTES" ;
      }

      protected void InitializeNonKey1845( )
      {
      }

      protected void InitAll1845( )
      {
         A92ZONALOTESCODZON = "";
         AssignAttri("", false, "A92ZONALOTESCODZON", A92ZONALOTESCODZON);
         A93ZONALOTESCODLOT = "";
         AssignAttri("", false, "A93ZONALOTESCODLOT", A93ZONALOTESCODLOT);
         InitializeNonKey1845( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024723102563", true, true);
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
         context.AddJavascriptSource("zonalotes.js", "?2024723102563", false, true);
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
         edtZONALOTESCODZON_Internalname = "ZONALOTESCODZON";
         edtZONALOTESCODLOT_Internalname = "ZONALOTESCODLOT";
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
         Form.Caption = "ZONALOTES";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtZONALOTESCODLOT_Jsonclick = "";
         edtZONALOTESCODLOT_Enabled = 1;
         edtZONALOTESCODZON_Jsonclick = "";
         edtZONALOTESCODZON_Enabled = 1;
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
         if ( AnyError == 0 )
         {
            GX_FocusControl = "";
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
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

      public void Valid_Zonalotescodlot( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z92ZONALOTESCODZON", Z92ZONALOTESCODZON);
         GxWebStd.gx_hidden_field( context, "Z93ZONALOTESCODLOT", Z93ZONALOTESCODLOT);
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
         setEventMetadata("VALID_ZONALOTESCODZON","{handler:'Valid_Zonalotescodzon',iparms:[]");
         setEventMetadata("VALID_ZONALOTESCODZON",",oparms:[]}");
         setEventMetadata("VALID_ZONALOTESCODLOT","{handler:'Valid_Zonalotescodlot',iparms:[{av:'A92ZONALOTESCODZON',fld:'ZONALOTESCODZON',pic:''},{av:'A93ZONALOTESCODLOT',fld:'ZONALOTESCODLOT',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_ZONALOTESCODLOT",",oparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z92ZONALOTESCODZON'},{av:'Z93ZONALOTESCODLOT'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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
         Z92ZONALOTESCODZON = "";
         Z93ZONALOTESCODLOT = "";
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
         A92ZONALOTESCODZON = "";
         A93ZONALOTESCODLOT = "";
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
         T00184_A92ZONALOTESCODZON = new string[] {""} ;
         T00184_A93ZONALOTESCODLOT = new string[] {""} ;
         T00185_A92ZONALOTESCODZON = new string[] {""} ;
         T00185_A93ZONALOTESCODLOT = new string[] {""} ;
         T00183_A92ZONALOTESCODZON = new string[] {""} ;
         T00183_A93ZONALOTESCODLOT = new string[] {""} ;
         sMode45 = "";
         T00186_A92ZONALOTESCODZON = new string[] {""} ;
         T00186_A93ZONALOTESCODLOT = new string[] {""} ;
         T00187_A92ZONALOTESCODZON = new string[] {""} ;
         T00187_A93ZONALOTESCODLOT = new string[] {""} ;
         T00182_A92ZONALOTESCODZON = new string[] {""} ;
         T00182_A93ZONALOTESCODLOT = new string[] {""} ;
         T001810_A92ZONALOTESCODZON = new string[] {""} ;
         T001810_A93ZONALOTESCODLOT = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ92ZONALOTESCODZON = "";
         ZZ93ZONALOTESCODLOT = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.zonalotes__default(),
            new Object[][] {
                new Object[] {
               T00182_A92ZONALOTESCODZON, T00182_A93ZONALOTESCODLOT
               }
               , new Object[] {
               T00183_A92ZONALOTESCODZON, T00183_A93ZONALOTESCODLOT
               }
               , new Object[] {
               T00184_A92ZONALOTESCODZON, T00184_A93ZONALOTESCODLOT
               }
               , new Object[] {
               T00185_A92ZONALOTESCODZON, T00185_A93ZONALOTESCODLOT
               }
               , new Object[] {
               T00186_A92ZONALOTESCODZON, T00186_A93ZONALOTESCODLOT
               }
               , new Object[] {
               T00187_A92ZONALOTESCODZON, T00187_A93ZONALOTESCODLOT
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001810_A92ZONALOTESCODZON, T001810_A93ZONALOTESCODLOT
               }
            }
         );
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short GX_JID ;
      private short RcdFound45 ;
      private short nIsDirty_45 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtZONALOTESCODZON_Enabled ;
      private int edtZONALOTESCODLOT_Enabled ;
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
      private string edtZONALOTESCODZON_Internalname ;
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
      private string edtZONALOTESCODZON_Jsonclick ;
      private string edtZONALOTESCODLOT_Internalname ;
      private string edtZONALOTESCODLOT_Jsonclick ;
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
      private string sMode45 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string Z92ZONALOTESCODZON ;
      private string Z93ZONALOTESCODLOT ;
      private string A92ZONALOTESCODZON ;
      private string A93ZONALOTESCODLOT ;
      private string ZZ92ZONALOTESCODZON ;
      private string ZZ93ZONALOTESCODLOT ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00184_A92ZONALOTESCODZON ;
      private string[] T00184_A93ZONALOTESCODLOT ;
      private string[] T00185_A92ZONALOTESCODZON ;
      private string[] T00185_A93ZONALOTESCODLOT ;
      private string[] T00183_A92ZONALOTESCODZON ;
      private string[] T00183_A93ZONALOTESCODLOT ;
      private string[] T00186_A92ZONALOTESCODZON ;
      private string[] T00186_A93ZONALOTESCODLOT ;
      private string[] T00187_A92ZONALOTESCODZON ;
      private string[] T00187_A93ZONALOTESCODLOT ;
      private string[] T00182_A92ZONALOTESCODZON ;
      private string[] T00182_A93ZONALOTESCODLOT ;
      private string[] T001810_A92ZONALOTESCODZON ;
      private string[] T001810_A93ZONALOTESCODLOT ;
      private GXWebForm Form ;
   }

   public class zonalotes__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[8])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00184;
          prmT00184 = new Object[] {
          new ParDef("@ZONALOTESCODZON",GXType.NVarChar,40,0) ,
          new ParDef("@ZONALOTESCODLOT",GXType.NVarChar,40,0)
          };
          Object[] prmT00185;
          prmT00185 = new Object[] {
          new ParDef("@ZONALOTESCODZON",GXType.NVarChar,40,0) ,
          new ParDef("@ZONALOTESCODLOT",GXType.NVarChar,40,0)
          };
          Object[] prmT00183;
          prmT00183 = new Object[] {
          new ParDef("@ZONALOTESCODZON",GXType.NVarChar,40,0) ,
          new ParDef("@ZONALOTESCODLOT",GXType.NVarChar,40,0)
          };
          Object[] prmT00186;
          prmT00186 = new Object[] {
          new ParDef("@ZONALOTESCODZON",GXType.NVarChar,40,0) ,
          new ParDef("@ZONALOTESCODLOT",GXType.NVarChar,40,0)
          };
          Object[] prmT00187;
          prmT00187 = new Object[] {
          new ParDef("@ZONALOTESCODZON",GXType.NVarChar,40,0) ,
          new ParDef("@ZONALOTESCODLOT",GXType.NVarChar,40,0)
          };
          Object[] prmT00182;
          prmT00182 = new Object[] {
          new ParDef("@ZONALOTESCODZON",GXType.NVarChar,40,0) ,
          new ParDef("@ZONALOTESCODLOT",GXType.NVarChar,40,0)
          };
          Object[] prmT00188;
          prmT00188 = new Object[] {
          new ParDef("@ZONALOTESCODZON",GXType.NVarChar,40,0) ,
          new ParDef("@ZONALOTESCODLOT",GXType.NVarChar,40,0)
          };
          Object[] prmT00189;
          prmT00189 = new Object[] {
          new ParDef("@ZONALOTESCODZON",GXType.NVarChar,40,0) ,
          new ParDef("@ZONALOTESCODLOT",GXType.NVarChar,40,0)
          };
          Object[] prmT001810;
          prmT001810 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T00182", "SELECT [ZONALOTESCODZON], [ZONALOTESCODLOT] FROM [ZONALOTES] WITH (UPDLOCK) WHERE [ZONALOTESCODZON] = @ZONALOTESCODZON AND [ZONALOTESCODLOT] = @ZONALOTESCODLOT ",true, GxErrorMask.GX_NOMASK, false, this,prmT00182,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00183", "SELECT [ZONALOTESCODZON], [ZONALOTESCODLOT] FROM [ZONALOTES] WHERE [ZONALOTESCODZON] = @ZONALOTESCODZON AND [ZONALOTESCODLOT] = @ZONALOTESCODLOT ",true, GxErrorMask.GX_NOMASK, false, this,prmT00183,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00184", "SELECT TM1.[ZONALOTESCODZON], TM1.[ZONALOTESCODLOT] FROM [ZONALOTES] TM1 WHERE TM1.[ZONALOTESCODZON] = @ZONALOTESCODZON and TM1.[ZONALOTESCODLOT] = @ZONALOTESCODLOT ORDER BY TM1.[ZONALOTESCODZON], TM1.[ZONALOTESCODLOT]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00184,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00185", "SELECT [ZONALOTESCODZON], [ZONALOTESCODLOT] FROM [ZONALOTES] WHERE [ZONALOTESCODZON] = @ZONALOTESCODZON AND [ZONALOTESCODLOT] = @ZONALOTESCODLOT  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00185,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00186", "SELECT TOP 1 [ZONALOTESCODZON], [ZONALOTESCODLOT] FROM [ZONALOTES] WHERE ( [ZONALOTESCODZON] > @ZONALOTESCODZON or [ZONALOTESCODZON] = @ZONALOTESCODZON and [ZONALOTESCODLOT] > @ZONALOTESCODLOT) ORDER BY [ZONALOTESCODZON], [ZONALOTESCODLOT]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00186,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00187", "SELECT TOP 1 [ZONALOTESCODZON], [ZONALOTESCODLOT] FROM [ZONALOTES] WHERE ( [ZONALOTESCODZON] < @ZONALOTESCODZON or [ZONALOTESCODZON] = @ZONALOTESCODZON and [ZONALOTESCODLOT] < @ZONALOTESCODLOT) ORDER BY [ZONALOTESCODZON] DESC, [ZONALOTESCODLOT] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00187,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00188", "INSERT INTO [ZONALOTES]([ZONALOTESCODZON], [ZONALOTESCODLOT]) VALUES(@ZONALOTESCODZON, @ZONALOTESCODLOT)", GxErrorMask.GX_NOMASK,prmT00188)
             ,new CursorDef("T00189", "DELETE FROM [ZONALOTES]  WHERE [ZONALOTESCODZON] = @ZONALOTESCODZON AND [ZONALOTESCODLOT] = @ZONALOTESCODLOT", GxErrorMask.GX_NOMASK,prmT00189)
             ,new CursorDef("T001810", "SELECT [ZONALOTESCODZON], [ZONALOTESCODLOT] FROM [ZONALOTES] ORDER BY [ZONALOTESCODZON], [ZONALOTESCODLOT]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001810,100, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
