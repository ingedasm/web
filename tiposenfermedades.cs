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
   public class tiposenfermedades : GXDataArea
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
            Form.Meta.addItem("description", "Tipos Enfermedades", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTiposEnfermedadesCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("IndicadroresPalmas", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public tiposenfermedades( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("IndicadroresPalmas", true);
      }

      public tiposenfermedades( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Tipos Enfermedades", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_TiposEnfermedades.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TiposEnfermedades.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_TiposEnfermedades.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_TiposEnfermedades.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TiposEnfermedades.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 4, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx0170.aspx"+"',["+"{Ctrl:gx.dom.el('"+"TIPOSENFERMEDADESCOD"+"'), id:'"+"TIPOSENFERMEDADESCOD"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_TiposEnfermedades.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTiposEnfermedadesCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTiposEnfermedadesCod_Internalname, "Enfermedades Cod", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTiposEnfermedadesCod_Internalname, A90TiposEnfermedadesCod, StringUtil.RTrim( context.localUtil.Format( A90TiposEnfermedadesCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTiposEnfermedadesCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTiposEnfermedadesCod_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_TiposEnfermedades.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTiposEnfermedadesNom_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTiposEnfermedadesNom_Internalname, "Enfermedades Nom", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTiposEnfermedadesNom_Internalname, A262TiposEnfermedadesNom, StringUtil.RTrim( context.localUtil.Format( A262TiposEnfermedadesNom, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTiposEnfermedadesNom_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTiposEnfermedadesNom_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_TiposEnfermedades.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_TiposEnfermedades.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_TiposEnfermedades.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_TiposEnfermedades.htm");
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
            Z90TiposEnfermedadesCod = cgiGet( "Z90TiposEnfermedadesCod");
            Z262TiposEnfermedadesNom = cgiGet( "Z262TiposEnfermedadesNom");
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A90TiposEnfermedadesCod = cgiGet( edtTiposEnfermedadesCod_Internalname);
            AssignAttri("", false, "A90TiposEnfermedadesCod", A90TiposEnfermedadesCod);
            A262TiposEnfermedadesNom = cgiGet( edtTiposEnfermedadesNom_Internalname);
            AssignAttri("", false, "A262TiposEnfermedadesNom", A262TiposEnfermedadesNom);
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
               A90TiposEnfermedadesCod = GetPar( "TiposEnfermedadesCod");
               AssignAttri("", false, "A90TiposEnfermedadesCod", A90TiposEnfermedadesCod);
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
               InitAll1643( ) ;
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
         DisableAttributes1643( ) ;
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

      protected void ResetCaption160( )
      {
      }

      protected void ZM1643( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z262TiposEnfermedadesNom = T00163_A262TiposEnfermedadesNom[0];
            }
            else
            {
               Z262TiposEnfermedadesNom = A262TiposEnfermedadesNom;
            }
         }
         if ( GX_JID == -1 )
         {
            Z90TiposEnfermedadesCod = A90TiposEnfermedadesCod;
            Z262TiposEnfermedadesNom = A262TiposEnfermedadesNom;
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

      protected void Load1643( )
      {
         /* Using cursor T00164 */
         pr_default.execute(2, new Object[] {A90TiposEnfermedadesCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound43 = 1;
            A262TiposEnfermedadesNom = T00164_A262TiposEnfermedadesNom[0];
            AssignAttri("", false, "A262TiposEnfermedadesNom", A262TiposEnfermedadesNom);
            ZM1643( -1) ;
         }
         pr_default.close(2);
         OnLoadActions1643( ) ;
      }

      protected void OnLoadActions1643( )
      {
      }

      protected void CheckExtendedTable1643( )
      {
         nIsDirty_43 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors1643( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1643( )
      {
         /* Using cursor T00165 */
         pr_default.execute(3, new Object[] {A90TiposEnfermedadesCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound43 = 1;
         }
         else
         {
            RcdFound43 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00163 */
         pr_default.execute(1, new Object[] {A90TiposEnfermedadesCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1643( 1) ;
            RcdFound43 = 1;
            A90TiposEnfermedadesCod = T00163_A90TiposEnfermedadesCod[0];
            AssignAttri("", false, "A90TiposEnfermedadesCod", A90TiposEnfermedadesCod);
            A262TiposEnfermedadesNom = T00163_A262TiposEnfermedadesNom[0];
            AssignAttri("", false, "A262TiposEnfermedadesNom", A262TiposEnfermedadesNom);
            Z90TiposEnfermedadesCod = A90TiposEnfermedadesCod;
            sMode43 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1643( ) ;
            if ( AnyError == 1 )
            {
               RcdFound43 = 0;
               InitializeNonKey1643( ) ;
            }
            Gx_mode = sMode43;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound43 = 0;
            InitializeNonKey1643( ) ;
            sMode43 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode43;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1643( ) ;
         if ( RcdFound43 == 0 )
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
         RcdFound43 = 0;
         /* Using cursor T00166 */
         pr_default.execute(4, new Object[] {A90TiposEnfermedadesCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T00166_A90TiposEnfermedadesCod[0], A90TiposEnfermedadesCod) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T00166_A90TiposEnfermedadesCod[0], A90TiposEnfermedadesCod) > 0 ) ) )
            {
               A90TiposEnfermedadesCod = T00166_A90TiposEnfermedadesCod[0];
               AssignAttri("", false, "A90TiposEnfermedadesCod", A90TiposEnfermedadesCod);
               RcdFound43 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound43 = 0;
         /* Using cursor T00167 */
         pr_default.execute(5, new Object[] {A90TiposEnfermedadesCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T00167_A90TiposEnfermedadesCod[0], A90TiposEnfermedadesCod) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T00167_A90TiposEnfermedadesCod[0], A90TiposEnfermedadesCod) < 0 ) ) )
            {
               A90TiposEnfermedadesCod = T00167_A90TiposEnfermedadesCod[0];
               AssignAttri("", false, "A90TiposEnfermedadesCod", A90TiposEnfermedadesCod);
               RcdFound43 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1643( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTiposEnfermedadesCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1643( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound43 == 1 )
            {
               if ( StringUtil.StrCmp(A90TiposEnfermedadesCod, Z90TiposEnfermedadesCod) != 0 )
               {
                  A90TiposEnfermedadesCod = Z90TiposEnfermedadesCod;
                  AssignAttri("", false, "A90TiposEnfermedadesCod", A90TiposEnfermedadesCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TIPOSENFERMEDADESCOD");
                  AnyError = 1;
                  GX_FocusControl = edtTiposEnfermedadesCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTiposEnfermedadesCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1643( ) ;
                  GX_FocusControl = edtTiposEnfermedadesCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A90TiposEnfermedadesCod, Z90TiposEnfermedadesCod) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtTiposEnfermedadesCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1643( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TIPOSENFERMEDADESCOD");
                     AnyError = 1;
                     GX_FocusControl = edtTiposEnfermedadesCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtTiposEnfermedadesCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1643( ) ;
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
         if ( StringUtil.StrCmp(A90TiposEnfermedadesCod, Z90TiposEnfermedadesCod) != 0 )
         {
            A90TiposEnfermedadesCod = Z90TiposEnfermedadesCod;
            AssignAttri("", false, "A90TiposEnfermedadesCod", A90TiposEnfermedadesCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TIPOSENFERMEDADESCOD");
            AnyError = 1;
            GX_FocusControl = edtTiposEnfermedadesCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTiposEnfermedadesCod_Internalname;
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
         if ( RcdFound43 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "TIPOSENFERMEDADESCOD");
            AnyError = 1;
            GX_FocusControl = edtTiposEnfermedadesCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtTiposEnfermedadesNom_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1643( ) ;
         if ( RcdFound43 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTiposEnfermedadesNom_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1643( ) ;
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
         if ( RcdFound43 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTiposEnfermedadesNom_Internalname;
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
         if ( RcdFound43 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTiposEnfermedadesNom_Internalname;
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
         ScanStart1643( ) ;
         if ( RcdFound43 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound43 != 0 )
            {
               ScanNext1643( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTiposEnfermedadesNom_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1643( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1643( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00162 */
            pr_default.execute(0, new Object[] {A90TiposEnfermedadesCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TiposEnfermedades"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z262TiposEnfermedadesNom, T00162_A262TiposEnfermedadesNom[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z262TiposEnfermedadesNom, T00162_A262TiposEnfermedadesNom[0]) != 0 )
               {
                  GXUtil.WriteLog("tiposenfermedades:[seudo value changed for attri]"+"TiposEnfermedadesNom");
                  GXUtil.WriteLogRaw("Old: ",Z262TiposEnfermedadesNom);
                  GXUtil.WriteLogRaw("Current: ",T00162_A262TiposEnfermedadesNom[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TiposEnfermedades"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1643( )
      {
         BeforeValidate1643( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1643( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1643( 0) ;
            CheckOptimisticConcurrency1643( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1643( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1643( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00168 */
                     pr_default.execute(6, new Object[] {A90TiposEnfermedadesCod, A262TiposEnfermedadesNom});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("TiposEnfermedades");
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
                           ResetCaption160( ) ;
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
               Load1643( ) ;
            }
            EndLevel1643( ) ;
         }
         CloseExtendedTableCursors1643( ) ;
      }

      protected void Update1643( )
      {
         BeforeValidate1643( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1643( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1643( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1643( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1643( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00169 */
                     pr_default.execute(7, new Object[] {A262TiposEnfermedadesNom, A90TiposEnfermedadesCod});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("TiposEnfermedades");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TiposEnfermedades"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1643( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption160( ) ;
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
            EndLevel1643( ) ;
         }
         CloseExtendedTableCursors1643( ) ;
      }

      protected void DeferredUpdate1643( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1643( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1643( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1643( ) ;
            AfterConfirm1643( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1643( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001610 */
                  pr_default.execute(8, new Object[] {A90TiposEnfermedadesCod});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("TiposEnfermedades");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound43 == 0 )
                        {
                           InitAll1643( ) ;
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
                        ResetCaption160( ) ;
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
         sMode43 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1643( ) ;
         Gx_mode = sMode43;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1643( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T001611 */
            pr_default.execute(9, new Object[] {A90TiposEnfermedadesCod});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"INCIDENCIAPC"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel1643( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1643( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("tiposenfermedades",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues160( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("tiposenfermedades",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1643( )
      {
         /* Using cursor T001612 */
         pr_default.execute(10);
         RcdFound43 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound43 = 1;
            A90TiposEnfermedadesCod = T001612_A90TiposEnfermedadesCod[0];
            AssignAttri("", false, "A90TiposEnfermedadesCod", A90TiposEnfermedadesCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1643( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound43 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound43 = 1;
            A90TiposEnfermedadesCod = T001612_A90TiposEnfermedadesCod[0];
            AssignAttri("", false, "A90TiposEnfermedadesCod", A90TiposEnfermedadesCod);
         }
      }

      protected void ScanEnd1643( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm1643( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1643( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1643( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1643( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1643( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1643( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1643( )
      {
         edtTiposEnfermedadesCod_Enabled = 0;
         AssignProp("", false, edtTiposEnfermedadesCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTiposEnfermedadesCod_Enabled), 5, 0), true);
         edtTiposEnfermedadesNom_Enabled = 0;
         AssignProp("", false, edtTiposEnfermedadesNom_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTiposEnfermedadesNom_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1643( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues160( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("tiposenfermedades.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z90TiposEnfermedadesCod", Z90TiposEnfermedadesCod);
         GxWebStd.gx_hidden_field( context, "Z262TiposEnfermedadesNom", Z262TiposEnfermedadesNom);
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
         return formatLink("tiposenfermedades.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "TiposEnfermedades" ;
      }

      public override string GetPgmdesc( )
      {
         return "Tipos Enfermedades" ;
      }

      protected void InitializeNonKey1643( )
      {
         A262TiposEnfermedadesNom = "";
         AssignAttri("", false, "A262TiposEnfermedadesNom", A262TiposEnfermedadesNom);
         Z262TiposEnfermedadesNom = "";
      }

      protected void InitAll1643( )
      {
         A90TiposEnfermedadesCod = "";
         AssignAttri("", false, "A90TiposEnfermedadesCod", A90TiposEnfermedadesCod);
         InitializeNonKey1643( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20247231025690", true, true);
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
         context.AddJavascriptSource("tiposenfermedades.js", "?20247231025690", false, true);
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
         edtTiposEnfermedadesCod_Internalname = "TIPOSENFERMEDADESCOD";
         edtTiposEnfermedadesNom_Internalname = "TIPOSENFERMEDADESNOM";
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
         Form.Caption = "Tipos Enfermedades";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtTiposEnfermedadesNom_Jsonclick = "";
         edtTiposEnfermedadesNom_Enabled = 1;
         edtTiposEnfermedadesCod_Jsonclick = "";
         edtTiposEnfermedadesCod_Enabled = 1;
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
         GX_FocusControl = edtTiposEnfermedadesNom_Internalname;
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

      public void Valid_Tiposenfermedadescod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A262TiposEnfermedadesNom", A262TiposEnfermedadesNom);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z90TiposEnfermedadesCod", Z90TiposEnfermedadesCod);
         GxWebStd.gx_hidden_field( context, "Z262TiposEnfermedadesNom", Z262TiposEnfermedadesNom);
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
         setEventMetadata("VALID_TIPOSENFERMEDADESCOD","{handler:'Valid_Tiposenfermedadescod',iparms:[{av:'A90TiposEnfermedadesCod',fld:'TIPOSENFERMEDADESCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_TIPOSENFERMEDADESCOD",",oparms:[{av:'A262TiposEnfermedadesNom',fld:'TIPOSENFERMEDADESNOM',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z90TiposEnfermedadesCod'},{av:'Z262TiposEnfermedadesNom'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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
         Z90TiposEnfermedadesCod = "";
         Z262TiposEnfermedadesNom = "";
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
         A90TiposEnfermedadesCod = "";
         A262TiposEnfermedadesNom = "";
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
         T00164_A90TiposEnfermedadesCod = new string[] {""} ;
         T00164_A262TiposEnfermedadesNom = new string[] {""} ;
         T00165_A90TiposEnfermedadesCod = new string[] {""} ;
         T00163_A90TiposEnfermedadesCod = new string[] {""} ;
         T00163_A262TiposEnfermedadesNom = new string[] {""} ;
         sMode43 = "";
         T00166_A90TiposEnfermedadesCod = new string[] {""} ;
         T00167_A90TiposEnfermedadesCod = new string[] {""} ;
         T00162_A90TiposEnfermedadesCod = new string[] {""} ;
         T00162_A262TiposEnfermedadesNom = new string[] {""} ;
         T001611_A104INCIDENCIAPCFec = new DateTime[] {DateTime.MinValue} ;
         T001611_A105INCIDENCIAPCMes = new short[1] ;
         T001611_A106INCIDENCIAPCano = new short[1] ;
         T001611_A5Cod_Area = new string[] {""} ;
         T001611_A4IndicadoresCodigo = new string[] {""} ;
         T001611_A90TiposEnfermedadesCod = new string[] {""} ;
         T001611_A91MATERIALPALMASCOD = new string[] {""} ;
         T001611_A107INCIDENCIAPCZONA = new string[] {""} ;
         T001611_A108INCIDENCIAPCLOTE = new string[] {""} ;
         T001612_A90TiposEnfermedadesCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ90TiposEnfermedadesCod = "";
         ZZ262TiposEnfermedadesNom = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tiposenfermedades__default(),
            new Object[][] {
                new Object[] {
               T00162_A90TiposEnfermedadesCod, T00162_A262TiposEnfermedadesNom
               }
               , new Object[] {
               T00163_A90TiposEnfermedadesCod, T00163_A262TiposEnfermedadesNom
               }
               , new Object[] {
               T00164_A90TiposEnfermedadesCod, T00164_A262TiposEnfermedadesNom
               }
               , new Object[] {
               T00165_A90TiposEnfermedadesCod
               }
               , new Object[] {
               T00166_A90TiposEnfermedadesCod
               }
               , new Object[] {
               T00167_A90TiposEnfermedadesCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001611_A104INCIDENCIAPCFec, T001611_A105INCIDENCIAPCMes, T001611_A106INCIDENCIAPCano, T001611_A5Cod_Area, T001611_A4IndicadoresCodigo, T001611_A90TiposEnfermedadesCod, T001611_A91MATERIALPALMASCOD, T001611_A107INCIDENCIAPCZONA, T001611_A108INCIDENCIAPCLOTE
               }
               , new Object[] {
               T001612_A90TiposEnfermedadesCod
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
      private short RcdFound43 ;
      private short nIsDirty_43 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtTiposEnfermedadesCod_Enabled ;
      private int edtTiposEnfermedadesNom_Enabled ;
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
      private string edtTiposEnfermedadesCod_Internalname ;
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
      private string edtTiposEnfermedadesCod_Jsonclick ;
      private string edtTiposEnfermedadesNom_Internalname ;
      private string edtTiposEnfermedadesNom_Jsonclick ;
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
      private string sMode43 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string Z90TiposEnfermedadesCod ;
      private string Z262TiposEnfermedadesNom ;
      private string A90TiposEnfermedadesCod ;
      private string A262TiposEnfermedadesNom ;
      private string ZZ90TiposEnfermedadesCod ;
      private string ZZ262TiposEnfermedadesNom ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00164_A90TiposEnfermedadesCod ;
      private string[] T00164_A262TiposEnfermedadesNom ;
      private string[] T00165_A90TiposEnfermedadesCod ;
      private string[] T00163_A90TiposEnfermedadesCod ;
      private string[] T00163_A262TiposEnfermedadesNom ;
      private string[] T00166_A90TiposEnfermedadesCod ;
      private string[] T00167_A90TiposEnfermedadesCod ;
      private string[] T00162_A90TiposEnfermedadesCod ;
      private string[] T00162_A262TiposEnfermedadesNom ;
      private DateTime[] T001611_A104INCIDENCIAPCFec ;
      private short[] T001611_A105INCIDENCIAPCMes ;
      private short[] T001611_A106INCIDENCIAPCano ;
      private string[] T001611_A5Cod_Area ;
      private string[] T001611_A4IndicadoresCodigo ;
      private string[] T001611_A90TiposEnfermedadesCod ;
      private string[] T001611_A91MATERIALPALMASCOD ;
      private string[] T001611_A107INCIDENCIAPCZONA ;
      private string[] T001611_A108INCIDENCIAPCLOTE ;
      private string[] T001612_A90TiposEnfermedadesCod ;
      private GXWebForm Form ;
   }

   public class tiposenfermedades__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00164;
          prmT00164 = new Object[] {
          new ParDef("@TiposEnfermedadesCod",GXType.NVarChar,40,0)
          };
          Object[] prmT00165;
          prmT00165 = new Object[] {
          new ParDef("@TiposEnfermedadesCod",GXType.NVarChar,40,0)
          };
          Object[] prmT00163;
          prmT00163 = new Object[] {
          new ParDef("@TiposEnfermedadesCod",GXType.NVarChar,40,0)
          };
          Object[] prmT00166;
          prmT00166 = new Object[] {
          new ParDef("@TiposEnfermedadesCod",GXType.NVarChar,40,0)
          };
          Object[] prmT00167;
          prmT00167 = new Object[] {
          new ParDef("@TiposEnfermedadesCod",GXType.NVarChar,40,0)
          };
          Object[] prmT00162;
          prmT00162 = new Object[] {
          new ParDef("@TiposEnfermedadesCod",GXType.NVarChar,40,0)
          };
          Object[] prmT00168;
          prmT00168 = new Object[] {
          new ParDef("@TiposEnfermedadesCod",GXType.NVarChar,40,0) ,
          new ParDef("@TiposEnfermedadesNom",GXType.NVarChar,150,0)
          };
          Object[] prmT00169;
          prmT00169 = new Object[] {
          new ParDef("@TiposEnfermedadesNom",GXType.NVarChar,150,0) ,
          new ParDef("@TiposEnfermedadesCod",GXType.NVarChar,40,0)
          };
          Object[] prmT001610;
          prmT001610 = new Object[] {
          new ParDef("@TiposEnfermedadesCod",GXType.NVarChar,40,0)
          };
          Object[] prmT001611;
          prmT001611 = new Object[] {
          new ParDef("@TiposEnfermedadesCod",GXType.NVarChar,40,0)
          };
          Object[] prmT001612;
          prmT001612 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T00162", "SELECT [TiposEnfermedadesCod], [TiposEnfermedadesNom] FROM [TiposEnfermedades] WITH (UPDLOCK) WHERE [TiposEnfermedadesCod] = @TiposEnfermedadesCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00162,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00163", "SELECT [TiposEnfermedadesCod], [TiposEnfermedadesNom] FROM [TiposEnfermedades] WHERE [TiposEnfermedadesCod] = @TiposEnfermedadesCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00163,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00164", "SELECT TM1.[TiposEnfermedadesCod], TM1.[TiposEnfermedadesNom] FROM [TiposEnfermedades] TM1 WHERE TM1.[TiposEnfermedadesCod] = @TiposEnfermedadesCod ORDER BY TM1.[TiposEnfermedadesCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00164,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00165", "SELECT [TiposEnfermedadesCod] FROM [TiposEnfermedades] WHERE [TiposEnfermedadesCod] = @TiposEnfermedadesCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00165,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00166", "SELECT TOP 1 [TiposEnfermedadesCod] FROM [TiposEnfermedades] WHERE ( [TiposEnfermedadesCod] > @TiposEnfermedadesCod) ORDER BY [TiposEnfermedadesCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00166,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00167", "SELECT TOP 1 [TiposEnfermedadesCod] FROM [TiposEnfermedades] WHERE ( [TiposEnfermedadesCod] < @TiposEnfermedadesCod) ORDER BY [TiposEnfermedadesCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00167,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00168", "INSERT INTO [TiposEnfermedades]([TiposEnfermedadesCod], [TiposEnfermedadesNom]) VALUES(@TiposEnfermedadesCod, @TiposEnfermedadesNom)", GxErrorMask.GX_NOMASK,prmT00168)
             ,new CursorDef("T00169", "UPDATE [TiposEnfermedades] SET [TiposEnfermedadesNom]=@TiposEnfermedadesNom  WHERE [TiposEnfermedadesCod] = @TiposEnfermedadesCod", GxErrorMask.GX_NOMASK,prmT00169)
             ,new CursorDef("T001610", "DELETE FROM [TiposEnfermedades]  WHERE [TiposEnfermedadesCod] = @TiposEnfermedadesCod", GxErrorMask.GX_NOMASK,prmT001610)
             ,new CursorDef("T001611", "SELECT TOP 1 [INCIDENCIAPCFec], [INCIDENCIAPCMes], [INCIDENCIAPCano], [Cod_Area], [IndicadoresCodigo], [TiposEnfermedadesCod], [MATERIALPALMASCOD], [INCIDENCIAPCZONA], [INCIDENCIAPCLOTE] FROM [INCIDENCIAPC] WHERE [TiposEnfermedadesCod] = @TiposEnfermedadesCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001611,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001612", "SELECT [TiposEnfermedadesCod] FROM [TiposEnfermedades] ORDER BY [TiposEnfermedadesCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001612,100, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 9 :
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
             case 10 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
       }
    }

 }

}
