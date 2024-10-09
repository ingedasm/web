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
   public class areas : GXDataArea
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
            Form.Meta.addItem("description", "Areas", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCod_Area_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("IndicadroresPalmas", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public areas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("IndicadroresPalmas", true);
      }

      public areas( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Areas", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Areas.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Areas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Areas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Areas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Areas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 4, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"COD_AREA"+"'), id:'"+"COD_AREA"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_Areas.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCod_Area_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCod_Area_Internalname, "Cod_Area", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCod_Area_Internalname, A5Cod_Area, StringUtil.RTrim( context.localUtil.Format( A5Cod_Area, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCod_Area_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCod_Area_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Areas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtNom_Area_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNom_Area_Internalname, "Nom_Area", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNom_Area_Internalname, A114Nom_Area, StringUtil.RTrim( context.localUtil.Format( A114Nom_Area, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNom_Area_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNom_Area_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Areas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtlogo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtlogo_Internalname, "logo", "col-sm-3 ImageLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         ClassString = "Image";
         StyleString = "";
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         edtlogo_Filetype = "tmp";
         AssignProp("", false, edtlogo_Internalname, "Filetype", edtlogo_Filetype, true);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A115logo)) )
         {
            gxblobfileaux.Source = A115logo;
            if ( ! gxblobfileaux.HasExtension() || ( StringUtil.StrCmp(edtlogo_Filetype, "tmp") != 0 ) )
            {
               gxblobfileaux.SetExtension(StringUtil.Trim( edtlogo_Filetype));
            }
            if ( gxblobfileaux.ErrCode == 0 )
            {
               A115logo = gxblobfileaux.GetURI();
               n115logo = false;
               AssignAttri("", false, "A115logo", A115logo);
               AssignProp("", false, edtlogo_Internalname, "URL", context.PathToRelativeUrl( A115logo), true);
               edtlogo_Filetype = gxblobfileaux.GetExtension();
               AssignProp("", false, edtlogo_Internalname, "Filetype", edtlogo_Filetype, true);
            }
            AssignProp("", false, edtlogo_Internalname, "URL", context.PathToRelativeUrl( A115logo), true);
         }
         GxWebStd.gx_blob_field( context, edtlogo_Internalname, StringUtil.RTrim( A115logo), context.PathToRelativeUrl( A115logo), (String.IsNullOrEmpty(StringUtil.RTrim( edtlogo_Contenttype)) ? context.GetContentType( (String.IsNullOrEmpty(StringUtil.RTrim( edtlogo_Filetype)) ? A115logo : edtlogo_Filetype)) : edtlogo_Contenttype), false, "", edtlogo_Parameters, 0, edtlogo_Enabled, 1, "", "", 0, -1, 250, "px", 60, "px", 0, 0, 0, edtlogo_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", StyleString, ClassString, "", "", ""+TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "", "", "HLP_Areas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAreasLinkUrlImagen_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAreasLinkUrlImagen_Internalname, "Url Imagen", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtAreasLinkUrlImagen_Internalname, A206AreasLinkUrlImagen, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", 0, 1, edtAreasLinkUrlImagen_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Areas.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Areas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Areas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Areas.htm");
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
            Z5Cod_Area = cgiGet( "Z5Cod_Area");
            Z114Nom_Area = cgiGet( "Z114Nom_Area");
            Z206AreasLinkUrlImagen = cgiGet( "Z206AreasLinkUrlImagen");
            n206AreasLinkUrlImagen = (String.IsNullOrEmpty(StringUtil.RTrim( A206AreasLinkUrlImagen)) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            edtlogo_Filename = cgiGet( "LOGO_Filename");
            edtlogo_Filetype = cgiGet( "LOGO_Filetype");
            /* Read variables values. */
            A5Cod_Area = cgiGet( edtCod_Area_Internalname);
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A114Nom_Area = cgiGet( edtNom_Area_Internalname);
            AssignAttri("", false, "A114Nom_Area", A114Nom_Area);
            A115logo = cgiGet( edtlogo_Internalname);
            n115logo = false;
            AssignAttri("", false, "A115logo", A115logo);
            n115logo = (String.IsNullOrEmpty(StringUtil.RTrim( A115logo)) ? true : false);
            A206AreasLinkUrlImagen = cgiGet( edtAreasLinkUrlImagen_Internalname);
            n206AreasLinkUrlImagen = false;
            AssignAttri("", false, "A206AreasLinkUrlImagen", A206AreasLinkUrlImagen);
            n206AreasLinkUrlImagen = (String.IsNullOrEmpty(StringUtil.RTrim( A206AreasLinkUrlImagen)) ? true : false);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A115logo)) )
            {
               edtlogo_Filename = (string)(CGIGetFileName(edtlogo_Internalname));
               edtlogo_Filetype = (string)(CGIGetFileType(edtlogo_Internalname));
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( A115logo)) )
            {
               GXCCtlgxBlob = "LOGO" + "_gxBlob";
               A115logo = cgiGet( GXCCtlgxBlob);
               n115logo = false;
               n115logo = (String.IsNullOrEmpty(StringUtil.RTrim( A115logo)) ? true : false);
            }
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
               A5Cod_Area = GetPar( "Cod_Area");
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
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
               InitAll021( ) ;
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
         DisableAttributes021( ) ;
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

      protected void ResetCaption020( )
      {
      }

      protected void ZM021( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z114Nom_Area = T00023_A114Nom_Area[0];
               Z206AreasLinkUrlImagen = T00023_A206AreasLinkUrlImagen[0];
            }
            else
            {
               Z114Nom_Area = A114Nom_Area;
               Z206AreasLinkUrlImagen = A206AreasLinkUrlImagen;
            }
         }
         if ( GX_JID == -1 )
         {
            Z5Cod_Area = A5Cod_Area;
            Z114Nom_Area = A114Nom_Area;
            Z115logo = A115logo;
            Z206AreasLinkUrlImagen = A206AreasLinkUrlImagen;
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

      protected void Load021( )
      {
         /* Using cursor T00024 */
         pr_default.execute(2, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound1 = 1;
            A114Nom_Area = T00024_A114Nom_Area[0];
            AssignAttri("", false, "A114Nom_Area", A114Nom_Area);
            A206AreasLinkUrlImagen = T00024_A206AreasLinkUrlImagen[0];
            n206AreasLinkUrlImagen = T00024_n206AreasLinkUrlImagen[0];
            AssignAttri("", false, "A206AreasLinkUrlImagen", A206AreasLinkUrlImagen);
            A115logo = T00024_A115logo[0];
            n115logo = T00024_n115logo[0];
            AssignAttri("", false, "A115logo", A115logo);
            AssignProp("", false, edtlogo_Internalname, "URL", context.PathToRelativeUrl( A115logo), true);
            ZM021( -1) ;
         }
         pr_default.close(2);
         OnLoadActions021( ) ;
      }

      protected void OnLoadActions021( )
      {
      }

      protected void CheckExtendedTable021( )
      {
         nIsDirty_1 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors021( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey021( )
      {
         /* Using cursor T00025 */
         pr_default.execute(3, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound1 = 1;
         }
         else
         {
            RcdFound1 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00023 */
         pr_default.execute(1, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM021( 1) ;
            RcdFound1 = 1;
            A5Cod_Area = T00023_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A114Nom_Area = T00023_A114Nom_Area[0];
            AssignAttri("", false, "A114Nom_Area", A114Nom_Area);
            A206AreasLinkUrlImagen = T00023_A206AreasLinkUrlImagen[0];
            n206AreasLinkUrlImagen = T00023_n206AreasLinkUrlImagen[0];
            AssignAttri("", false, "A206AreasLinkUrlImagen", A206AreasLinkUrlImagen);
            A115logo = T00023_A115logo[0];
            n115logo = T00023_n115logo[0];
            AssignAttri("", false, "A115logo", A115logo);
            AssignProp("", false, edtlogo_Internalname, "URL", context.PathToRelativeUrl( A115logo), true);
            Z5Cod_Area = A5Cod_Area;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load021( ) ;
            if ( AnyError == 1 )
            {
               RcdFound1 = 0;
               InitializeNonKey021( ) ;
            }
            Gx_mode = sMode1;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound1 = 0;
            InitializeNonKey021( ) ;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode1;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey021( ) ;
         if ( RcdFound1 == 0 )
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
         RcdFound1 = 0;
         /* Using cursor T00026 */
         pr_default.execute(4, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T00026_A5Cod_Area[0], A5Cod_Area) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T00026_A5Cod_Area[0], A5Cod_Area) > 0 ) ) )
            {
               A5Cod_Area = T00026_A5Cod_Area[0];
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               RcdFound1 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound1 = 0;
         /* Using cursor T00027 */
         pr_default.execute(5, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T00027_A5Cod_Area[0], A5Cod_Area) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T00027_A5Cod_Area[0], A5Cod_Area) < 0 ) ) )
            {
               A5Cod_Area = T00027_A5Cod_Area[0];
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               RcdFound1 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey021( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCod_Area_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert021( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound1 == 1 )
            {
               if ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 )
               {
                  A5Cod_Area = Z5Cod_Area;
                  AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "COD_AREA");
                  AnyError = 1;
                  GX_FocusControl = edtCod_Area_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCod_Area_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update021( ) ;
                  GX_FocusControl = edtCod_Area_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtCod_Area_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert021( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "COD_AREA");
                     AnyError = 1;
                     GX_FocusControl = edtCod_Area_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtCod_Area_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert021( ) ;
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
         if ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 )
         {
            A5Cod_Area = Z5Cod_Area;
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCod_Area_Internalname;
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
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtNom_Area_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart021( ) ;
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtNom_Area_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd021( ) ;
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
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtNom_Area_Internalname;
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
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtNom_Area_Internalname;
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
         ScanStart021( ) ;
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound1 != 0 )
            {
               ScanNext021( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtNom_Area_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd021( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency021( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00022 */
            pr_default.execute(0, new Object[] {A5Cod_Area});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Areas"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z114Nom_Area, T00022_A114Nom_Area[0]) != 0 ) || ( StringUtil.StrCmp(Z206AreasLinkUrlImagen, T00022_A206AreasLinkUrlImagen[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z114Nom_Area, T00022_A114Nom_Area[0]) != 0 )
               {
                  GXUtil.WriteLog("areas:[seudo value changed for attri]"+"Nom_Area");
                  GXUtil.WriteLogRaw("Old: ",Z114Nom_Area);
                  GXUtil.WriteLogRaw("Current: ",T00022_A114Nom_Area[0]);
               }
               if ( StringUtil.StrCmp(Z206AreasLinkUrlImagen, T00022_A206AreasLinkUrlImagen[0]) != 0 )
               {
                  GXUtil.WriteLog("areas:[seudo value changed for attri]"+"AreasLinkUrlImagen");
                  GXUtil.WriteLogRaw("Old: ",Z206AreasLinkUrlImagen);
                  GXUtil.WriteLogRaw("Current: ",T00022_A206AreasLinkUrlImagen[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Areas"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert021( )
      {
         BeforeValidate021( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable021( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM021( 0) ;
            CheckOptimisticConcurrency021( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm021( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert021( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00028 */
                     pr_default.execute(6, new Object[] {A5Cod_Area, A114Nom_Area, n115logo, A115logo, n206AreasLinkUrlImagen, A206AreasLinkUrlImagen});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Areas");
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
                           ResetCaption020( ) ;
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
               Load021( ) ;
            }
            EndLevel021( ) ;
         }
         CloseExtendedTableCursors021( ) ;
      }

      protected void Update021( )
      {
         BeforeValidate021( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable021( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency021( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm021( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate021( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00029 */
                     pr_default.execute(7, new Object[] {A114Nom_Area, n206AreasLinkUrlImagen, A206AreasLinkUrlImagen, A5Cod_Area});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Areas");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Areas"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate021( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption020( ) ;
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
            EndLevel021( ) ;
         }
         CloseExtendedTableCursors021( ) ;
      }

      protected void DeferredUpdate021( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000210 */
            pr_default.execute(8, new Object[] {n115logo, A115logo, A5Cod_Area});
            pr_default.close(8);
            pr_default.SmartCacheProvider.SetUpdated("Areas");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate021( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency021( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls021( ) ;
            AfterConfirm021( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete021( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000211 */
                  pr_default.execute(9, new Object[] {A5Cod_Area});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("Areas");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound1 == 0 )
                        {
                           InitAll021( ) ;
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
                        ResetCaption020( ) ;
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
         sMode1 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel021( ) ;
         Gx_mode = sMode1;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls021( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000212 */
            pr_default.execute(10, new Object[] {A5Cod_Area});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Usuarios"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor T000213 */
            pr_default.execute(11, new Object[] {A5Cod_Area});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"RFF_COMPRADA"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor T000214 */
            pr_default.execute(12, new Object[] {A5Cod_Area});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"PRECNETOTONCPO"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T000215 */
            pr_default.execute(13, new Object[] {A5Cod_Area});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"COSTONRFFPROCES"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor T000216 */
            pr_default.execute(14, new Object[] {A5Cod_Area});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"COSTOTONRFFPRODU"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T000217 */
            pr_default.execute(15, new Object[] {A5Cod_Area});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"COSTOCPOPRODUCIDO"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T000218 */
            pr_default.execute(16, new Object[] {A5Cod_Area});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"MARGENEBITDA"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor T000219 */
            pr_default.execute(17, new Object[] {A5Cod_Area});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"INCIDENCIAPC"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor T000220 */
            pr_default.execute(18, new Object[] {A5Cod_Area});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"COSTONRFFPROD"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
            /* Using cursor T000221 */
            pr_default.execute(19, new Object[] {A5Cod_Area});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"HATRABAJADORES"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
            /* Using cursor T000222 */
            pr_default.execute(20, new Object[] {A5Cod_Area});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"TONCPOHA"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
            /* Using cursor T000223 */
            pr_default.execute(21, new Object[] {A5Cod_Area});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"FRUTAPROPIA"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
            /* Using cursor T000224 */
            pr_default.execute(22, new Object[] {A5Cod_Area});
            if ( (pr_default.getStatus(22) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"COSTONRFFPROCESADA"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(22);
            /* Using cursor T000225 */
            pr_default.execute(23, new Object[] {A5Cod_Area});
            if ( (pr_default.getStatus(23) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Acidez"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(23);
            /* Using cursor T000226 */
            pr_default.execute(24, new Object[] {A5Cod_Area});
            if ( (pr_default.getStatus(24) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"TEA"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(24);
            /* Using cursor T000227 */
            pr_default.execute(25, new Object[] {A5Cod_Area});
            if ( (pr_default.getStatus(25) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"FRUTOPROCESADO"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(25);
            /* Using cursor T000228 */
            pr_default.execute(26, new Object[] {A5Cod_Area});
            if ( (pr_default.getStatus(26) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"COSTOCPOHA"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(26);
            /* Using cursor T000229 */
            pr_default.execute(27, new Object[] {A5Cod_Area});
            if ( (pr_default.getStatus(27) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"PAGOFRUTA"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(27);
            /* Using cursor T000230 */
            pr_default.execute(28, new Object[] {A5Cod_Area});
            if ( (pr_default.getStatus(28) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"COSUSPTONFRUTA"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(28);
            /* Using cursor T000231 */
            pr_default.execute(29, new Object[] {A5Cod_Area});
            if ( (pr_default.getStatus(29) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"TRIF"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(29);
            /* Using cursor T000232 */
            pr_default.execute(30, new Object[] {A5Cod_Area});
            if ( (pr_default.getStatus(30) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"COSTOHE"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(30);
            /* Using cursor T000233 */
            pr_default.execute(31, new Object[] {A5Cod_Area});
            if ( (pr_default.getStatus(31) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ACCDAG"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(31);
            /* Using cursor T000234 */
            pr_default.execute(32, new Object[] {A5Cod_Area});
            if ( (pr_default.getStatus(32) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Area"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(32);
         }
      }

      protected void EndLevel021( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete021( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("areas",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues020( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("areas",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart021( )
      {
         /* Using cursor T000235 */
         pr_default.execute(33);
         RcdFound1 = 0;
         if ( (pr_default.getStatus(33) != 101) )
         {
            RcdFound1 = 1;
            A5Cod_Area = T000235_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext021( )
      {
         /* Scan next routine */
         pr_default.readNext(33);
         RcdFound1 = 0;
         if ( (pr_default.getStatus(33) != 101) )
         {
            RcdFound1 = 1;
            A5Cod_Area = T000235_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
         }
      }

      protected void ScanEnd021( )
      {
         pr_default.close(33);
      }

      protected void AfterConfirm021( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert021( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate021( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete021( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete021( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate021( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes021( )
      {
         edtCod_Area_Enabled = 0;
         AssignProp("", false, edtCod_Area_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCod_Area_Enabled), 5, 0), true);
         edtNom_Area_Enabled = 0;
         AssignProp("", false, edtNom_Area_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNom_Area_Enabled), 5, 0), true);
         edtlogo_Enabled = 0;
         AssignProp("", false, edtlogo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtlogo_Enabled), 5, 0), true);
         edtAreasLinkUrlImagen_Enabled = 0;
         AssignProp("", false, edtAreasLinkUrlImagen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAreasLinkUrlImagen_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes021( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues020( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("areas.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z5Cod_Area", Z5Cod_Area);
         GxWebStd.gx_hidden_field( context, "Z114Nom_Area", Z114Nom_Area);
         GxWebStd.gx_hidden_field( context, "Z206AreasLinkUrlImagen", Z206AreasLinkUrlImagen);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GXCCtlgxBlob = "LOGO" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A115logo);
         GxWebStd.gx_hidden_field( context, "LOGO_Filename", StringUtil.RTrim( edtlogo_Filename));
         GxWebStd.gx_hidden_field( context, "LOGO_Filetype", StringUtil.RTrim( edtlogo_Filetype));
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
         return formatLink("areas.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Areas" ;
      }

      public override string GetPgmdesc( )
      {
         return "Areas" ;
      }

      protected void InitializeNonKey021( )
      {
         A114Nom_Area = "";
         AssignAttri("", false, "A114Nom_Area", A114Nom_Area);
         A115logo = "";
         n115logo = false;
         AssignAttri("", false, "A115logo", A115logo);
         AssignProp("", false, edtlogo_Internalname, "URL", context.PathToRelativeUrl( A115logo), true);
         n115logo = (String.IsNullOrEmpty(StringUtil.RTrim( A115logo)) ? true : false);
         A206AreasLinkUrlImagen = "";
         n206AreasLinkUrlImagen = false;
         AssignAttri("", false, "A206AreasLinkUrlImagen", A206AreasLinkUrlImagen);
         n206AreasLinkUrlImagen = (String.IsNullOrEmpty(StringUtil.RTrim( A206AreasLinkUrlImagen)) ? true : false);
         Z114Nom_Area = "";
         Z206AreasLinkUrlImagen = "";
      }

      protected void InitAll021( )
      {
         A5Cod_Area = "";
         AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
         InitializeNonKey021( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20247231014526", true, true);
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
         context.AddJavascriptSource("areas.js", "?20247231014528", false, true);
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
         edtCod_Area_Internalname = "COD_AREA";
         edtNom_Area_Internalname = "NOM_AREA";
         edtlogo_Internalname = "LOGO";
         edtAreasLinkUrlImagen_Internalname = "AREASLINKURLIMAGEN";
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
         edtlogo_Filename = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Areas";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtAreasLinkUrlImagen_Enabled = 1;
         edtlogo_Jsonclick = "";
         edtlogo_Parameters = "";
         edtlogo_Contenttype = "";
         edtlogo_Filetype = "";
         edtlogo_Enabled = 1;
         edtNom_Area_Jsonclick = "";
         edtNom_Area_Enabled = 1;
         edtCod_Area_Jsonclick = "";
         edtCod_Area_Enabled = 1;
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
         GX_FocusControl = edtNom_Area_Internalname;
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
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A114Nom_Area", A114Nom_Area);
         AssignAttri("", false, "A115logo", context.PathToRelativeUrl( A115logo));
         AssignAttri("", false, "A206AreasLinkUrlImagen", A206AreasLinkUrlImagen);
         AssignProp("", false, edtlogo_Internalname, "Filetype", edtlogo_Filetype, true);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z5Cod_Area", Z5Cod_Area);
         GxWebStd.gx_hidden_field( context, "Z114Nom_Area", Z114Nom_Area);
         GxWebStd.gx_hidden_field( context, "Z115logo", context.PathToRelativeUrl( Z115logo));
         GxWebStd.gx_hidden_field( context, "Z206AreasLinkUrlImagen", Z206AreasLinkUrlImagen);
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
         setEventMetadata("VALID_COD_AREA","{handler:'Valid_Cod_area',iparms:[{av:'A5Cod_Area',fld:'COD_AREA',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_COD_AREA",",oparms:[{av:'A114Nom_Area',fld:'NOM_AREA',pic:''},{av:'A115logo',fld:'LOGO',pic:''},{av:'A206AreasLinkUrlImagen',fld:'AREASLINKURLIMAGEN',pic:''},{av:'edtlogo_Filetype',ctrl:'LOGO',prop:'Filetype'},{av:'edtlogo_Filename',ctrl:'LOGO',prop:'Filename'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z5Cod_Area'},{av:'Z114Nom_Area'},{av:'Z115logo'},{av:'Z206AreasLinkUrlImagen'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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
         Z5Cod_Area = "";
         Z114Nom_Area = "";
         Z206AreasLinkUrlImagen = "";
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
         A5Cod_Area = "";
         A114Nom_Area = "";
         gxblobfileaux = new GxFile(context.GetPhysicalPath());
         A115logo = "";
         A206AreasLinkUrlImagen = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_mode = "";
         GXCCtlgxBlob = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z115logo = "";
         T00024_A5Cod_Area = new string[] {""} ;
         T00024_A114Nom_Area = new string[] {""} ;
         T00024_A206AreasLinkUrlImagen = new string[] {""} ;
         T00024_n206AreasLinkUrlImagen = new bool[] {false} ;
         T00024_A115logo = new string[] {""} ;
         T00024_n115logo = new bool[] {false} ;
         T00025_A5Cod_Area = new string[] {""} ;
         T00023_A5Cod_Area = new string[] {""} ;
         T00023_A114Nom_Area = new string[] {""} ;
         T00023_A206AreasLinkUrlImagen = new string[] {""} ;
         T00023_n206AreasLinkUrlImagen = new bool[] {false} ;
         T00023_A115logo = new string[] {""} ;
         T00023_n115logo = new bool[] {false} ;
         sMode1 = "";
         T00026_A5Cod_Area = new string[] {""} ;
         T00027_A5Cod_Area = new string[] {""} ;
         T00022_A5Cod_Area = new string[] {""} ;
         T00022_A114Nom_Area = new string[] {""} ;
         T00022_A206AreasLinkUrlImagen = new string[] {""} ;
         T00022_n206AreasLinkUrlImagen = new bool[] {false} ;
         T00022_A115logo = new string[] {""} ;
         T00022_n115logo = new bool[] {false} ;
         T000212_A16UsuariosCodigo = new string[] {""} ;
         T000213_A86RFF_COMPRADAFecha = new DateTime[] {DateTime.MinValue} ;
         T000213_A5Cod_Area = new string[] {""} ;
         T000213_A4IndicadoresCodigo = new string[] {""} ;
         T000213_A87RFF_COMPRADAMes = new short[1] ;
         T000213_A88RFF_COMPRADAAno = new short[1] ;
         T000213_A89RFF_COMPRAPRODUCUP = new string[] {""} ;
         T000214_A83PRECNETOTONCPOFecha = new DateTime[] {DateTime.MinValue} ;
         T000214_A84PRECNETOTONCPOMes = new short[1] ;
         T000214_A85PRECNETOTONCPOAno = new short[1] ;
         T000214_A5Cod_Area = new string[] {""} ;
         T000214_A4IndicadoresCodigo = new string[] {""} ;
         T000214_A67MOTIVOSPRENETCodigo = new string[] {""} ;
         T000215_A80COSTONRFFPROCESFecha = new DateTime[] {DateTime.MinValue} ;
         T000215_A81COSTONRFFPROCESMes = new short[1] ;
         T000215_A82COSTONRFFPROCESAno = new short[1] ;
         T000215_A5Cod_Area = new string[] {""} ;
         T000215_A4IndicadoresCodigo = new string[] {""} ;
         T000215_A66MOTIVOSCOSRFFCodigo = new string[] {""} ;
         T000216_A77COSTOTONRFFPRODUFecha = new DateTime[] {DateTime.MinValue} ;
         T000216_A78COSTOTONRFFPRODUMes = new short[1] ;
         T000216_A79COSTOTONRFFPRODUAno = new short[1] ;
         T000216_A5Cod_Area = new string[] {""} ;
         T000216_A4IndicadoresCodigo = new string[] {""} ;
         T000216_A65MOTIVOTONRFFcod = new string[] {""} ;
         T000217_A109COSTOCPOPRODUCIDOFecha = new DateTime[] {DateTime.MinValue} ;
         T000217_A110COSTOCPOPRODUCIDOMes = new short[1] ;
         T000217_A111COSTOCPOPRODUCIDOAno = new short[1] ;
         T000217_A5Cod_Area = new string[] {""} ;
         T000217_A4IndicadoresCodigo = new string[] {""} ;
         T000217_A64TIPOSCPOCod = new string[] {""} ;
         T000217_A45TipoProductoCod = new string[] {""} ;
         T000218_A74MARGENEBITDAFecha = new DateTime[] {DateTime.MinValue} ;
         T000218_A75MARGENEBITDAMes = new short[1] ;
         T000218_A76MARGENEBITDAAno = new short[1] ;
         T000218_A5Cod_Area = new string[] {""} ;
         T000218_A4IndicadoresCodigo = new string[] {""} ;
         T000218_A63MOTIVOMARGENCod = new string[] {""} ;
         T000219_A104INCIDENCIAPCFec = new DateTime[] {DateTime.MinValue} ;
         T000219_A105INCIDENCIAPCMes = new short[1] ;
         T000219_A106INCIDENCIAPCano = new short[1] ;
         T000219_A5Cod_Area = new string[] {""} ;
         T000219_A4IndicadoresCodigo = new string[] {""} ;
         T000219_A90TiposEnfermedadesCod = new string[] {""} ;
         T000219_A91MATERIALPALMASCOD = new string[] {""} ;
         T000219_A107INCIDENCIAPCZONA = new string[] {""} ;
         T000219_A108INCIDENCIAPCLOTE = new string[] {""} ;
         T000220_A60COSTONRFFPRODfec = new DateTime[] {DateTime.MinValue} ;
         T000220_A61COSTONRFFPRODmes = new short[1] ;
         T000220_A62COSTONRFFPRODano = new short[1] ;
         T000220_A5Cod_Area = new string[] {""} ;
         T000220_A4IndicadoresCodigo = new string[] {""} ;
         T000221_A57HATRABAJADORESFecha = new DateTime[] {DateTime.MinValue} ;
         T000221_A58HATRABAJADORESMes = new short[1] ;
         T000221_A59HATRABAJADORESAno = new short[1] ;
         T000221_A5Cod_Area = new string[] {""} ;
         T000221_A4IndicadoresCodigo = new string[] {""} ;
         T000222_A54TONCPOHAFecha = new DateTime[] {DateTime.MinValue} ;
         T000222_A55TONCPOHAMes = new short[1] ;
         T000222_A56TONCPOHAAno = new short[1] ;
         T000222_A5Cod_Area = new string[] {""} ;
         T000222_A4IndicadoresCodigo = new string[] {""} ;
         T000223_A94FRUTAPROPIAFecha = new DateTime[] {DateTime.MinValue} ;
         T000223_A95FRUTAPROPIAMes = new short[1] ;
         T000223_A96FRUTAPROPIAAno = new short[1] ;
         T000223_A4IndicadoresCodigo = new string[] {""} ;
         T000223_A5Cod_Area = new string[] {""} ;
         T000223_A97VIAJE = new long[1] ;
         T000223_A98SETOR = new string[] {""} ;
         T000223_A99FINCA = new string[] {""} ;
         T000223_A100PROVE_COD = new string[] {""} ;
         T000223_A101DIA = new DateTime[] {DateTime.MinValue} ;
         T000223_A102LOTE = new string[] {""} ;
         T000223_A103TAL = new string[] {""} ;
         T000224_A71COSTONRFFPROCFec = new DateTime[] {DateTime.MinValue} ;
         T000224_A72COSTONRFFPROCMes = new short[1] ;
         T000224_A73COSTONRFFPROCAno = new short[1] ;
         T000224_A5Cod_Area = new string[] {""} ;
         T000224_A4IndicadoresCodigo = new string[] {""} ;
         T000224_A53MOTIVOSCOSRFFPROCod = new string[] {""} ;
         T000225_A50AcidezFecha = new DateTime[] {DateTime.MinValue} ;
         T000225_A51AcidezMes = new short[1] ;
         T000225_A52AcidezAno = new short[1] ;
         T000225_A5Cod_Area = new string[] {""} ;
         T000225_A4IndicadoresCodigo = new string[] {""} ;
         T000226_A42TEAFecha = new DateTime[] {DateTime.MinValue} ;
         T000226_A43TEAMes = new short[1] ;
         T000226_A44TEAAno = new short[1] ;
         T000226_A4IndicadoresCodigo = new string[] {""} ;
         T000226_A5Cod_Area = new string[] {""} ;
         T000227_A39FRUTOPROCESADOFec = new DateTime[] {DateTime.MinValue} ;
         T000227_A40FRUTOPROCESADOMes = new short[1] ;
         T000227_A41FRUTOPROCESADOAno = new short[1] ;
         T000227_A5Cod_Area = new string[] {""} ;
         T000227_A4IndicadoresCodigo = new string[] {""} ;
         T000228_A36COSTOCPOHAFecha = new DateTime[] {DateTime.MinValue} ;
         T000228_A37COSTOCPOHAAno = new short[1] ;
         T000228_A38COSTOCPOHAMes = new short[1] ;
         T000228_A5Cod_Area = new string[] {""} ;
         T000228_A4IndicadoresCodigo = new string[] {""} ;
         T000229_A68PAGOFRUTAFecha = new DateTime[] {DateTime.MinValue} ;
         T000229_A69PAGOFRUTAMes = new short[1] ;
         T000229_A70PAGOFRUTAAno = new short[1] ;
         T000229_A5Cod_Area = new string[] {""} ;
         T000229_A4IndicadoresCodigo = new string[] {""} ;
         T000229_A30MotivosUspCodigo = new string[] {""} ;
         T000230_A27COSUSPTONFRUTAFecha = new DateTime[] {DateTime.MinValue} ;
         T000230_A28COSUSPTONFRUTAMes = new short[1] ;
         T000230_A29COSUSPTONFRUTAAno = new short[1] ;
         T000230_A5Cod_Area = new string[] {""} ;
         T000230_A4IndicadoresCodigo = new string[] {""} ;
         T000231_A24TRIFFecha = new DateTime[] {DateTime.MinValue} ;
         T000231_A25TRIFMes = new short[1] ;
         T000231_A26TRIFAno = new short[1] ;
         T000231_A4IndicadoresCodigo = new string[] {""} ;
         T000231_A5Cod_Area = new string[] {""} ;
         T000232_A21COSTOHEFecha = new DateTime[] {DateTime.MinValue} ;
         T000232_A22COSTOHEMes = new short[1] ;
         T000232_A23COSTOHEAno = new short[1] ;
         T000232_A4IndicadoresCodigo = new string[] {""} ;
         T000232_A5Cod_Area = new string[] {""} ;
         T000233_A18ACCDAG_Fecha = new DateTime[] {DateTime.MinValue} ;
         T000233_A19ACCDAG_Mes = new short[1] ;
         T000233_A20ACCDAG_Ano = new short[1] ;
         T000233_A5Cod_Area = new string[] {""} ;
         T000233_A4IndicadoresCodigo = new string[] {""} ;
         T000233_A17ProcesosACCDAGCod = new string[] {""} ;
         T000234_A1Ausen_Fecha = new DateTime[] {DateTime.MinValue} ;
         T000234_A2Ausen_Mes = new short[1] ;
         T000234_A3Ausen_Ano = new short[1] ;
         T000234_A4IndicadoresCodigo = new string[] {""} ;
         T000234_A5Cod_Area = new string[] {""} ;
         T000235_A5Cod_Area = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ5Cod_Area = "";
         ZZ114Nom_Area = "";
         ZZ115logo = "";
         ZZ206AreasLinkUrlImagen = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.areas__default(),
            new Object[][] {
                new Object[] {
               T00022_A5Cod_Area, T00022_A114Nom_Area, T00022_A206AreasLinkUrlImagen, T00022_n206AreasLinkUrlImagen, T00022_A115logo, T00022_n115logo
               }
               , new Object[] {
               T00023_A5Cod_Area, T00023_A114Nom_Area, T00023_A206AreasLinkUrlImagen, T00023_n206AreasLinkUrlImagen, T00023_A115logo, T00023_n115logo
               }
               , new Object[] {
               T00024_A5Cod_Area, T00024_A114Nom_Area, T00024_A206AreasLinkUrlImagen, T00024_n206AreasLinkUrlImagen, T00024_A115logo, T00024_n115logo
               }
               , new Object[] {
               T00025_A5Cod_Area
               }
               , new Object[] {
               T00026_A5Cod_Area
               }
               , new Object[] {
               T00027_A5Cod_Area
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000212_A16UsuariosCodigo
               }
               , new Object[] {
               T000213_A86RFF_COMPRADAFecha, T000213_A5Cod_Area, T000213_A4IndicadoresCodigo, T000213_A87RFF_COMPRADAMes, T000213_A88RFF_COMPRADAAno, T000213_A89RFF_COMPRAPRODUCUP
               }
               , new Object[] {
               T000214_A83PRECNETOTONCPOFecha, T000214_A84PRECNETOTONCPOMes, T000214_A85PRECNETOTONCPOAno, T000214_A5Cod_Area, T000214_A4IndicadoresCodigo, T000214_A67MOTIVOSPRENETCodigo
               }
               , new Object[] {
               T000215_A80COSTONRFFPROCESFecha, T000215_A81COSTONRFFPROCESMes, T000215_A82COSTONRFFPROCESAno, T000215_A5Cod_Area, T000215_A4IndicadoresCodigo, T000215_A66MOTIVOSCOSRFFCodigo
               }
               , new Object[] {
               T000216_A77COSTOTONRFFPRODUFecha, T000216_A78COSTOTONRFFPRODUMes, T000216_A79COSTOTONRFFPRODUAno, T000216_A5Cod_Area, T000216_A4IndicadoresCodigo, T000216_A65MOTIVOTONRFFcod
               }
               , new Object[] {
               T000217_A109COSTOCPOPRODUCIDOFecha, T000217_A110COSTOCPOPRODUCIDOMes, T000217_A111COSTOCPOPRODUCIDOAno, T000217_A5Cod_Area, T000217_A4IndicadoresCodigo, T000217_A64TIPOSCPOCod, T000217_A45TipoProductoCod
               }
               , new Object[] {
               T000218_A74MARGENEBITDAFecha, T000218_A75MARGENEBITDAMes, T000218_A76MARGENEBITDAAno, T000218_A5Cod_Area, T000218_A4IndicadoresCodigo, T000218_A63MOTIVOMARGENCod
               }
               , new Object[] {
               T000219_A104INCIDENCIAPCFec, T000219_A105INCIDENCIAPCMes, T000219_A106INCIDENCIAPCano, T000219_A5Cod_Area, T000219_A4IndicadoresCodigo, T000219_A90TiposEnfermedadesCod, T000219_A91MATERIALPALMASCOD, T000219_A107INCIDENCIAPCZONA, T000219_A108INCIDENCIAPCLOTE
               }
               , new Object[] {
               T000220_A60COSTONRFFPRODfec, T000220_A61COSTONRFFPRODmes, T000220_A62COSTONRFFPRODano, T000220_A5Cod_Area, T000220_A4IndicadoresCodigo
               }
               , new Object[] {
               T000221_A57HATRABAJADORESFecha, T000221_A58HATRABAJADORESMes, T000221_A59HATRABAJADORESAno, T000221_A5Cod_Area, T000221_A4IndicadoresCodigo
               }
               , new Object[] {
               T000222_A54TONCPOHAFecha, T000222_A55TONCPOHAMes, T000222_A56TONCPOHAAno, T000222_A5Cod_Area, T000222_A4IndicadoresCodigo
               }
               , new Object[] {
               T000223_A94FRUTAPROPIAFecha, T000223_A95FRUTAPROPIAMes, T000223_A96FRUTAPROPIAAno, T000223_A4IndicadoresCodigo, T000223_A5Cod_Area, T000223_A97VIAJE, T000223_A98SETOR, T000223_A99FINCA, T000223_A100PROVE_COD, T000223_A101DIA,
               T000223_A102LOTE, T000223_A103TAL
               }
               , new Object[] {
               T000224_A71COSTONRFFPROCFec, T000224_A72COSTONRFFPROCMes, T000224_A73COSTONRFFPROCAno, T000224_A5Cod_Area, T000224_A4IndicadoresCodigo, T000224_A53MOTIVOSCOSRFFPROCod
               }
               , new Object[] {
               T000225_A50AcidezFecha, T000225_A51AcidezMes, T000225_A52AcidezAno, T000225_A5Cod_Area, T000225_A4IndicadoresCodigo
               }
               , new Object[] {
               T000226_A42TEAFecha, T000226_A43TEAMes, T000226_A44TEAAno, T000226_A4IndicadoresCodigo, T000226_A5Cod_Area
               }
               , new Object[] {
               T000227_A39FRUTOPROCESADOFec, T000227_A40FRUTOPROCESADOMes, T000227_A41FRUTOPROCESADOAno, T000227_A5Cod_Area, T000227_A4IndicadoresCodigo
               }
               , new Object[] {
               T000228_A36COSTOCPOHAFecha, T000228_A37COSTOCPOHAAno, T000228_A38COSTOCPOHAMes, T000228_A5Cod_Area, T000228_A4IndicadoresCodigo
               }
               , new Object[] {
               T000229_A68PAGOFRUTAFecha, T000229_A69PAGOFRUTAMes, T000229_A70PAGOFRUTAAno, T000229_A5Cod_Area, T000229_A4IndicadoresCodigo, T000229_A30MotivosUspCodigo
               }
               , new Object[] {
               T000230_A27COSUSPTONFRUTAFecha, T000230_A28COSUSPTONFRUTAMes, T000230_A29COSUSPTONFRUTAAno, T000230_A5Cod_Area, T000230_A4IndicadoresCodigo
               }
               , new Object[] {
               T000231_A24TRIFFecha, T000231_A25TRIFMes, T000231_A26TRIFAno, T000231_A4IndicadoresCodigo, T000231_A5Cod_Area
               }
               , new Object[] {
               T000232_A21COSTOHEFecha, T000232_A22COSTOHEMes, T000232_A23COSTOHEAno, T000232_A4IndicadoresCodigo, T000232_A5Cod_Area
               }
               , new Object[] {
               T000233_A18ACCDAG_Fecha, T000233_A19ACCDAG_Mes, T000233_A20ACCDAG_Ano, T000233_A5Cod_Area, T000233_A4IndicadoresCodigo, T000233_A17ProcesosACCDAGCod
               }
               , new Object[] {
               T000234_A1Ausen_Fecha, T000234_A2Ausen_Mes, T000234_A3Ausen_Ano, T000234_A4IndicadoresCodigo, T000234_A5Cod_Area
               }
               , new Object[] {
               T000235_A5Cod_Area
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
      private short RcdFound1 ;
      private short nIsDirty_1 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtCod_Area_Enabled ;
      private int edtNom_Area_Enabled ;
      private int edtlogo_Enabled ;
      private int edtAreasLinkUrlImagen_Enabled ;
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
      private string edtCod_Area_Internalname ;
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
      private string edtCod_Area_Jsonclick ;
      private string edtNom_Area_Internalname ;
      private string edtNom_Area_Jsonclick ;
      private string edtlogo_Internalname ;
      private string edtlogo_Filetype ;
      private string edtlogo_Contenttype ;
      private string edtlogo_Parameters ;
      private string edtlogo_Jsonclick ;
      private string edtAreasLinkUrlImagen_Internalname ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string Gx_mode ;
      private string edtlogo_Filename ;
      private string GXCCtlgxBlob ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode1 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n115logo ;
      private bool n206AreasLinkUrlImagen ;
      private string Z5Cod_Area ;
      private string Z114Nom_Area ;
      private string Z206AreasLinkUrlImagen ;
      private string A5Cod_Area ;
      private string A114Nom_Area ;
      private string A206AreasLinkUrlImagen ;
      private string ZZ5Cod_Area ;
      private string ZZ114Nom_Area ;
      private string ZZ206AreasLinkUrlImagen ;
      private string A115logo ;
      private string Z115logo ;
      private string ZZ115logo ;
      private GxFile gxblobfileaux ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00024_A5Cod_Area ;
      private string[] T00024_A114Nom_Area ;
      private string[] T00024_A206AreasLinkUrlImagen ;
      private bool[] T00024_n206AreasLinkUrlImagen ;
      private string[] T00024_A115logo ;
      private bool[] T00024_n115logo ;
      private string[] T00025_A5Cod_Area ;
      private string[] T00023_A5Cod_Area ;
      private string[] T00023_A114Nom_Area ;
      private string[] T00023_A206AreasLinkUrlImagen ;
      private bool[] T00023_n206AreasLinkUrlImagen ;
      private string[] T00023_A115logo ;
      private bool[] T00023_n115logo ;
      private string[] T00026_A5Cod_Area ;
      private string[] T00027_A5Cod_Area ;
      private string[] T00022_A5Cod_Area ;
      private string[] T00022_A114Nom_Area ;
      private string[] T00022_A206AreasLinkUrlImagen ;
      private bool[] T00022_n206AreasLinkUrlImagen ;
      private string[] T00022_A115logo ;
      private bool[] T00022_n115logo ;
      private string[] T000212_A16UsuariosCodigo ;
      private DateTime[] T000213_A86RFF_COMPRADAFecha ;
      private string[] T000213_A5Cod_Area ;
      private string[] T000213_A4IndicadoresCodigo ;
      private short[] T000213_A87RFF_COMPRADAMes ;
      private short[] T000213_A88RFF_COMPRADAAno ;
      private string[] T000213_A89RFF_COMPRAPRODUCUP ;
      private DateTime[] T000214_A83PRECNETOTONCPOFecha ;
      private short[] T000214_A84PRECNETOTONCPOMes ;
      private short[] T000214_A85PRECNETOTONCPOAno ;
      private string[] T000214_A5Cod_Area ;
      private string[] T000214_A4IndicadoresCodigo ;
      private string[] T000214_A67MOTIVOSPRENETCodigo ;
      private DateTime[] T000215_A80COSTONRFFPROCESFecha ;
      private short[] T000215_A81COSTONRFFPROCESMes ;
      private short[] T000215_A82COSTONRFFPROCESAno ;
      private string[] T000215_A5Cod_Area ;
      private string[] T000215_A4IndicadoresCodigo ;
      private string[] T000215_A66MOTIVOSCOSRFFCodigo ;
      private DateTime[] T000216_A77COSTOTONRFFPRODUFecha ;
      private short[] T000216_A78COSTOTONRFFPRODUMes ;
      private short[] T000216_A79COSTOTONRFFPRODUAno ;
      private string[] T000216_A5Cod_Area ;
      private string[] T000216_A4IndicadoresCodigo ;
      private string[] T000216_A65MOTIVOTONRFFcod ;
      private DateTime[] T000217_A109COSTOCPOPRODUCIDOFecha ;
      private short[] T000217_A110COSTOCPOPRODUCIDOMes ;
      private short[] T000217_A111COSTOCPOPRODUCIDOAno ;
      private string[] T000217_A5Cod_Area ;
      private string[] T000217_A4IndicadoresCodigo ;
      private string[] T000217_A64TIPOSCPOCod ;
      private string[] T000217_A45TipoProductoCod ;
      private DateTime[] T000218_A74MARGENEBITDAFecha ;
      private short[] T000218_A75MARGENEBITDAMes ;
      private short[] T000218_A76MARGENEBITDAAno ;
      private string[] T000218_A5Cod_Area ;
      private string[] T000218_A4IndicadoresCodigo ;
      private string[] T000218_A63MOTIVOMARGENCod ;
      private DateTime[] T000219_A104INCIDENCIAPCFec ;
      private short[] T000219_A105INCIDENCIAPCMes ;
      private short[] T000219_A106INCIDENCIAPCano ;
      private string[] T000219_A5Cod_Area ;
      private string[] T000219_A4IndicadoresCodigo ;
      private string[] T000219_A90TiposEnfermedadesCod ;
      private string[] T000219_A91MATERIALPALMASCOD ;
      private string[] T000219_A107INCIDENCIAPCZONA ;
      private string[] T000219_A108INCIDENCIAPCLOTE ;
      private DateTime[] T000220_A60COSTONRFFPRODfec ;
      private short[] T000220_A61COSTONRFFPRODmes ;
      private short[] T000220_A62COSTONRFFPRODano ;
      private string[] T000220_A5Cod_Area ;
      private string[] T000220_A4IndicadoresCodigo ;
      private DateTime[] T000221_A57HATRABAJADORESFecha ;
      private short[] T000221_A58HATRABAJADORESMes ;
      private short[] T000221_A59HATRABAJADORESAno ;
      private string[] T000221_A5Cod_Area ;
      private string[] T000221_A4IndicadoresCodigo ;
      private DateTime[] T000222_A54TONCPOHAFecha ;
      private short[] T000222_A55TONCPOHAMes ;
      private short[] T000222_A56TONCPOHAAno ;
      private string[] T000222_A5Cod_Area ;
      private string[] T000222_A4IndicadoresCodigo ;
      private DateTime[] T000223_A94FRUTAPROPIAFecha ;
      private short[] T000223_A95FRUTAPROPIAMes ;
      private short[] T000223_A96FRUTAPROPIAAno ;
      private string[] T000223_A4IndicadoresCodigo ;
      private string[] T000223_A5Cod_Area ;
      private long[] T000223_A97VIAJE ;
      private string[] T000223_A98SETOR ;
      private string[] T000223_A99FINCA ;
      private string[] T000223_A100PROVE_COD ;
      private DateTime[] T000223_A101DIA ;
      private string[] T000223_A102LOTE ;
      private string[] T000223_A103TAL ;
      private DateTime[] T000224_A71COSTONRFFPROCFec ;
      private short[] T000224_A72COSTONRFFPROCMes ;
      private short[] T000224_A73COSTONRFFPROCAno ;
      private string[] T000224_A5Cod_Area ;
      private string[] T000224_A4IndicadoresCodigo ;
      private string[] T000224_A53MOTIVOSCOSRFFPROCod ;
      private DateTime[] T000225_A50AcidezFecha ;
      private short[] T000225_A51AcidezMes ;
      private short[] T000225_A52AcidezAno ;
      private string[] T000225_A5Cod_Area ;
      private string[] T000225_A4IndicadoresCodigo ;
      private DateTime[] T000226_A42TEAFecha ;
      private short[] T000226_A43TEAMes ;
      private short[] T000226_A44TEAAno ;
      private string[] T000226_A4IndicadoresCodigo ;
      private string[] T000226_A5Cod_Area ;
      private DateTime[] T000227_A39FRUTOPROCESADOFec ;
      private short[] T000227_A40FRUTOPROCESADOMes ;
      private short[] T000227_A41FRUTOPROCESADOAno ;
      private string[] T000227_A5Cod_Area ;
      private string[] T000227_A4IndicadoresCodigo ;
      private DateTime[] T000228_A36COSTOCPOHAFecha ;
      private short[] T000228_A37COSTOCPOHAAno ;
      private short[] T000228_A38COSTOCPOHAMes ;
      private string[] T000228_A5Cod_Area ;
      private string[] T000228_A4IndicadoresCodigo ;
      private DateTime[] T000229_A68PAGOFRUTAFecha ;
      private short[] T000229_A69PAGOFRUTAMes ;
      private short[] T000229_A70PAGOFRUTAAno ;
      private string[] T000229_A5Cod_Area ;
      private string[] T000229_A4IndicadoresCodigo ;
      private string[] T000229_A30MotivosUspCodigo ;
      private DateTime[] T000230_A27COSUSPTONFRUTAFecha ;
      private short[] T000230_A28COSUSPTONFRUTAMes ;
      private short[] T000230_A29COSUSPTONFRUTAAno ;
      private string[] T000230_A5Cod_Area ;
      private string[] T000230_A4IndicadoresCodigo ;
      private DateTime[] T000231_A24TRIFFecha ;
      private short[] T000231_A25TRIFMes ;
      private short[] T000231_A26TRIFAno ;
      private string[] T000231_A4IndicadoresCodigo ;
      private string[] T000231_A5Cod_Area ;
      private DateTime[] T000232_A21COSTOHEFecha ;
      private short[] T000232_A22COSTOHEMes ;
      private short[] T000232_A23COSTOHEAno ;
      private string[] T000232_A4IndicadoresCodigo ;
      private string[] T000232_A5Cod_Area ;
      private DateTime[] T000233_A18ACCDAG_Fecha ;
      private short[] T000233_A19ACCDAG_Mes ;
      private short[] T000233_A20ACCDAG_Ano ;
      private string[] T000233_A5Cod_Area ;
      private string[] T000233_A4IndicadoresCodigo ;
      private string[] T000233_A17ProcesosACCDAGCod ;
      private DateTime[] T000234_A1Ausen_Fecha ;
      private short[] T000234_A2Ausen_Mes ;
      private short[] T000234_A3Ausen_Ano ;
      private string[] T000234_A4IndicadoresCodigo ;
      private string[] T000234_A5Cod_Area ;
      private string[] T000235_A5Cod_Area ;
      private GXWebForm Form ;
   }

   public class areas__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[9])
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
          Object[] prmT00024;
          prmT00024 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT00025;
          prmT00025 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT00023;
          prmT00023 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT00026;
          prmT00026 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT00027;
          prmT00027 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT00022;
          prmT00022 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT00028;
          prmT00028 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@Nom_Area",GXType.NVarChar,40,0) ,
          new ParDef("@logo",GXType.Blob,1024,0){Nullable=true,InDB=true} ,
          new ParDef("@AreasLinkUrlImagen",GXType.NVarChar,300,0){Nullable=true}
          };
          Object[] prmT00029;
          prmT00029 = new Object[] {
          new ParDef("@Nom_Area",GXType.NVarChar,40,0) ,
          new ParDef("@AreasLinkUrlImagen",GXType.NVarChar,300,0){Nullable=true} ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000210;
          prmT000210 = new Object[] {
          new ParDef("@logo",GXType.Blob,1024,0){Nullable=true,InDB=true} ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000211;
          prmT000211 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000212;
          prmT000212 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000213;
          prmT000213 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000214;
          prmT000214 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000215;
          prmT000215 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000216;
          prmT000216 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000217;
          prmT000217 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000218;
          prmT000218 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000219;
          prmT000219 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000220;
          prmT000220 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000221;
          prmT000221 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000222;
          prmT000222 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000223;
          prmT000223 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000224;
          prmT000224 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000225;
          prmT000225 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000226;
          prmT000226 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000227;
          prmT000227 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000228;
          prmT000228 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000229;
          prmT000229 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000230;
          prmT000230 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000231;
          prmT000231 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000232;
          prmT000232 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000233;
          prmT000233 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000234;
          prmT000234 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000235;
          prmT000235 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T00022", "SELECT [Cod_Area], [Nom_Area], [AreasLinkUrlImagen], [logo] FROM [Areas] WITH (UPDLOCK) WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT00022,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00023", "SELECT [Cod_Area], [Nom_Area], [AreasLinkUrlImagen], [logo] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT00023,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00024", "SELECT TM1.[Cod_Area], TM1.[Nom_Area], TM1.[AreasLinkUrlImagen], TM1.[logo] FROM [Areas] TM1 WHERE TM1.[Cod_Area] = @Cod_Area ORDER BY TM1.[Cod_Area]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00024,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00025", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00025,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00026", "SELECT TOP 1 [Cod_Area] FROM [Areas] WHERE ( [Cod_Area] > @Cod_Area) ORDER BY [Cod_Area]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00026,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00027", "SELECT TOP 1 [Cod_Area] FROM [Areas] WHERE ( [Cod_Area] < @Cod_Area) ORDER BY [Cod_Area] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00027,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00028", "INSERT INTO [Areas]([Cod_Area], [Nom_Area], [logo], [AreasLinkUrlImagen]) VALUES(@Cod_Area, @Nom_Area, @logo, @AreasLinkUrlImagen)", GxErrorMask.GX_NOMASK,prmT00028)
             ,new CursorDef("T00029", "UPDATE [Areas] SET [Nom_Area]=@Nom_Area, [AreasLinkUrlImagen]=@AreasLinkUrlImagen  WHERE [Cod_Area] = @Cod_Area", GxErrorMask.GX_NOMASK,prmT00029)
             ,new CursorDef("T000210", "UPDATE [Areas] SET [logo]=@logo  WHERE [Cod_Area] = @Cod_Area", GxErrorMask.GX_NOMASK,prmT000210)
             ,new CursorDef("T000211", "DELETE FROM [Areas]  WHERE [Cod_Area] = @Cod_Area", GxErrorMask.GX_NOMASK,prmT000211)
             ,new CursorDef("T000212", "SELECT TOP 1 [UsuariosCodigo] FROM [Usuarios] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000212,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000213", "SELECT TOP 1 [RFF_COMPRADAFecha], [Cod_Area], [IndicadoresCodigo], [RFF_COMPRADAMes], [RFF_COMPRADAAno], [RFF_COMPRAPRODUCUP] FROM [RFF_COMPRADA] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000213,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000214", "SELECT TOP 1 [PRECNETOTONCPOFecha], [PRECNETOTONCPOMes], [PRECNETOTONCPOAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOSPRENETCodigo] FROM [PRECNETOTONCPO] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000214,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000215", "SELECT TOP 1 [COSTONRFFPROCESFecha], [COSTONRFFPROCESMes], [COSTONRFFPROCESAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOSCOSRFFCodigo] FROM [COSTONRFFPROCES] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000215,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000216", "SELECT TOP 1 [COSTOTONRFFPRODUFecha], [COSTOTONRFFPRODUMes], [COSTOTONRFFPRODUAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOTONRFFcod] FROM [COSTOTONRFFPRODU] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000216,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000217", "SELECT TOP 1 [COSTOCPOPRODUCIDOFecha], [COSTOCPOPRODUCIDOMes], [COSTOCPOPRODUCIDOAno], [Cod_Area], [IndicadoresCodigo], [TIPOSCPOCod], [TipoProductoCod] FROM [COSTOCPOPRODUCIDO] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000217,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000218", "SELECT TOP 1 [MARGENEBITDAFecha], [MARGENEBITDAMes], [MARGENEBITDAAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOMARGENCod] FROM [MARGENEBITDA] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000218,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000219", "SELECT TOP 1 [INCIDENCIAPCFec], [INCIDENCIAPCMes], [INCIDENCIAPCano], [Cod_Area], [IndicadoresCodigo], [TiposEnfermedadesCod], [MATERIALPALMASCOD], [INCIDENCIAPCZONA], [INCIDENCIAPCLOTE] FROM [INCIDENCIAPC] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000219,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000220", "SELECT TOP 1 [COSTONRFFPRODfec], [COSTONRFFPRODmes], [COSTONRFFPRODano], [Cod_Area], [IndicadoresCodigo] FROM [COSTONRFFPROD] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000220,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000221", "SELECT TOP 1 [HATRABAJADORESFecha], [HATRABAJADORESMes], [HATRABAJADORESAno], [Cod_Area], [IndicadoresCodigo] FROM [HATRABAJADORES] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000221,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000222", "SELECT TOP 1 [TONCPOHAFecha], [TONCPOHAMes], [TONCPOHAAno], [Cod_Area], [IndicadoresCodigo] FROM [TONCPOHA] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000222,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000223", "SELECT TOP 1 [FRUTAPROPIAFecha], [FRUTAPROPIAMes], [FRUTAPROPIAAno], [IndicadoresCodigo], [Cod_Area], [VIAJE], [SETOR], [FINCA], [PROVE_COD], [DIA], [LOTE], [TAL] FROM [FRUTAPROPIA] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000223,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000224", "SELECT TOP 1 [COSTONRFFPROCFec], [COSTONRFFPROCMes], [COSTONRFFPROCAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOSCOSRFFPROCod] FROM [COSTONRFFPROCESADA] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000224,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000225", "SELECT TOP 1 [AcidezFecha], [AcidezMes], [AcidezAno], [Cod_Area], [IndicadoresCodigo] FROM [Acidez] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000225,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000226", "SELECT TOP 1 [TEAFecha], [TEAMes], [TEAAno], [IndicadoresCodigo], [Cod_Area] FROM [TEA] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000226,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000227", "SELECT TOP 1 [FRUTOPROCESADOFec], [FRUTOPROCESADOMes], [FRUTOPROCESADOAno], [Cod_Area], [IndicadoresCodigo] FROM [FRUTOPROCESADO] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000227,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000228", "SELECT TOP 1 [COSTOCPOHAFecha], [COSTOCPOHAAno], [COSTOCPOHAMes], [Cod_Area], [IndicadoresCodigo] FROM [COSTOCPOHA] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000228,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000229", "SELECT TOP 1 [PAGOFRUTAFecha], [PAGOFRUTAMes], [PAGOFRUTAAno], [Cod_Area], [IndicadoresCodigo], [MotivosUspCodigo] FROM [PAGOFRUTA] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000229,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000230", "SELECT TOP 1 [COSUSPTONFRUTAFecha], [COSUSPTONFRUTAMes], [COSUSPTONFRUTAAno], [Cod_Area], [IndicadoresCodigo] FROM [COSUSPTONFRUTA] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000230,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000231", "SELECT TOP 1 [TRIFFecha], [TRIFMes], [TRIFAno], [IndicadoresCodigo], [Cod_Area] FROM [TRIF] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000231,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000232", "SELECT TOP 1 [COSTOHEFecha], [COSTOHEMes], [COSTOHEAno], [IndicadoresCodigo], [Cod_Area] FROM [COSTOHE] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000232,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000233", "SELECT TOP 1 [ACCDAG_Fecha], [ACCDAG_Mes], [ACCDAG_Ano], [Cod_Area], [IndicadoresCodigo], [ProcesosACCDAGCod] FROM [ACCDAG] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000233,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000234", "SELECT TOP 1 [Ausen_Fecha], [Ausen_Mes], [Ausen_Ano], [IndicadoresCodigo], [Cod_Area] FROM [Ausentismos] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000234,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000235", "SELECT [Cod_Area] FROM [Areas] ORDER BY [Cod_Area]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000235,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getBLOBFile(4, "tmp", "");
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getBLOBFile(4, "tmp", "");
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getBLOBFile(4, "tmp", "");
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
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
             case 10 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 11 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
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
                return;
             case 15 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                return;
             case 16 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                return;
             case 17 :
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
                return;
             case 21 :
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
             case 22 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
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
