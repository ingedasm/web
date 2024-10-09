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
   public class usuarios : GXDataArea
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
            Form.Meta.addItem("description", "Usuarios", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtUsuariosCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("IndicadroresPalmas", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public usuarios( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("IndicadroresPalmas", true);
      }

      public usuarios( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Usuarios", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Usuarios.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 4, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx0020.aspx"+"',["+"{Ctrl:gx.dom.el('"+"USUARIOSCODIGO"+"'), id:'"+"USUARIOSCODIGO"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_Usuarios.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuariosCodigo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuariosCodigo_Internalname, "Codigo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuariosCodigo_Internalname, A16UsuariosCodigo, StringUtil.RTrim( context.localUtil.Format( A16UsuariosCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuariosCodigo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuariosCodigo_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuariosNombres_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuariosNombres_Internalname, "Nombres", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuariosNombres_Internalname, A116UsuariosNombres, StringUtil.RTrim( context.localUtil.Format( A116UsuariosNombres, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuariosNombres_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuariosNombres_Enabled, 0, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuariosPsw_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuariosPsw_Internalname, "Psw", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuariosPsw_Internalname, A117UsuariosPsw, StringUtil.RTrim( context.localUtil.Format( A117UsuariosPsw, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuariosPsw_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuariosPsw_Enabled, 0, "text", "", 32, "chr", 1, "row", 32, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Usuarios.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCod_Area_Internalname, A5Cod_Area, StringUtil.RTrim( context.localUtil.Format( A5Cod_Area, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCod_Area_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCod_Area_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Usuarios.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_5_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_5_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_5_Internalname, sImgUrl, imgprompt_5_Link, "", "", context.GetTheme( ), imgprompt_5_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuariosAdmin_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuariosAdmin_Internalname, "Admin", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuariosAdmin_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A118UsuariosAdmin), 4, 0, ",", "")), StringUtil.LTrim( ((edtUsuariosAdmin_Enabled!=0) ? context.localUtil.Format( (decimal)(A118UsuariosAdmin), "ZZZ9") : context.localUtil.Format( (decimal)(A118UsuariosAdmin), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuariosAdmin_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuariosAdmin_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuariosActualiza_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuariosActualiza_Internalname, "Actualiza", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuariosActualiza_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A119UsuariosActualiza), 4, 0, ",", "")), StringUtil.LTrim( ((edtUsuariosActualiza_Enabled!=0) ? context.localUtil.Format( (decimal)(A119UsuariosActualiza), "ZZZ9") : context.localUtil.Format( (decimal)(A119UsuariosActualiza), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuariosActualiza_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuariosActualiza_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuariosOrden_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuariosOrden_Internalname, "Orden", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuariosOrden_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A120UsuariosOrden), 4, 0, ",", "")), StringUtil.LTrim( ((edtUsuariosOrden_Enabled!=0) ? context.localUtil.Format( (decimal)(A120UsuariosOrden), "ZZZ9") : context.localUtil.Format( (decimal)(A120UsuariosOrden), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuariosOrden_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuariosOrden_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuariosImagen_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuariosImagen_Internalname, "Imagen", "col-sm-3 ImageLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         ClassString = "Image";
         StyleString = "";
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         edtUsuariosImagen_Filetype = "tmp";
         AssignProp("", false, edtUsuariosImagen_Internalname, "Filetype", edtUsuariosImagen_Filetype, true);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A204UsuariosImagen)) )
         {
            gxblobfileaux.Source = A204UsuariosImagen;
            if ( ! gxblobfileaux.HasExtension() || ( StringUtil.StrCmp(edtUsuariosImagen_Filetype, "tmp") != 0 ) )
            {
               gxblobfileaux.SetExtension(StringUtil.Trim( edtUsuariosImagen_Filetype));
            }
            if ( gxblobfileaux.ErrCode == 0 )
            {
               A204UsuariosImagen = gxblobfileaux.GetURI();
               n204UsuariosImagen = false;
               AssignAttri("", false, "A204UsuariosImagen", A204UsuariosImagen);
               AssignProp("", false, edtUsuariosImagen_Internalname, "URL", context.PathToRelativeUrl( A204UsuariosImagen), true);
               edtUsuariosImagen_Filetype = gxblobfileaux.GetExtension();
               AssignProp("", false, edtUsuariosImagen_Internalname, "Filetype", edtUsuariosImagen_Filetype, true);
            }
            AssignProp("", false, edtUsuariosImagen_Internalname, "URL", context.PathToRelativeUrl( A204UsuariosImagen), true);
         }
         GxWebStd.gx_blob_field( context, edtUsuariosImagen_Internalname, StringUtil.RTrim( A204UsuariosImagen), context.PathToRelativeUrl( A204UsuariosImagen), (String.IsNullOrEmpty(StringUtil.RTrim( edtUsuariosImagen_Contenttype)) ? context.GetContentType( (String.IsNullOrEmpty(StringUtil.RTrim( edtUsuariosImagen_Filetype)) ? A204UsuariosImagen : edtUsuariosImagen_Filetype)) : edtUsuariosImagen_Contenttype), false, "", edtUsuariosImagen_Parameters, 0, edtUsuariosImagen_Enabled, 1, "", "", 0, -1, 250, "px", 60, "px", 0, 0, 0, edtUsuariosImagen_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", StyleString, ClassString, "", "", ""+TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "", "", "HLP_Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuariosLinkImagen_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuariosLinkImagen_Internalname, "Link Imagen", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtUsuariosLinkImagen_Internalname, A205UsuariosLinkImagen, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", 0, 1, edtUsuariosLinkImagen_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuariosVigenciaHasta_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuariosVigenciaHasta_Internalname, "Vigencia Hasta", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtUsuariosVigenciaHasta_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtUsuariosVigenciaHasta_Internalname, context.localUtil.Format(A290UsuariosVigenciaHasta, "99/99/99"), context.localUtil.Format( A290UsuariosVigenciaHasta, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuariosVigenciaHasta_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuariosVigenciaHasta_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Usuarios.htm");
         GxWebStd.gx_bitmap( context, edtUsuariosVigenciaHasta_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtUsuariosVigenciaHasta_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Usuarios.htm");
         context.WriteHtmlTextNl( "</div>") ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Usuarios.htm");
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
            Z16UsuariosCodigo = cgiGet( "Z16UsuariosCodigo");
            Z116UsuariosNombres = cgiGet( "Z116UsuariosNombres");
            Z117UsuariosPsw = cgiGet( "Z117UsuariosPsw");
            Z118UsuariosAdmin = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z118UsuariosAdmin"), ",", "."), 18, MidpointRounding.ToEven));
            Z119UsuariosActualiza = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z119UsuariosActualiza"), ",", "."), 18, MidpointRounding.ToEven));
            Z120UsuariosOrden = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z120UsuariosOrden"), ",", "."), 18, MidpointRounding.ToEven));
            Z205UsuariosLinkImagen = cgiGet( "Z205UsuariosLinkImagen");
            n205UsuariosLinkImagen = (String.IsNullOrEmpty(StringUtil.RTrim( A205UsuariosLinkImagen)) ? true : false);
            Z290UsuariosVigenciaHasta = context.localUtil.CToD( cgiGet( "Z290UsuariosVigenciaHasta"), 0);
            n290UsuariosVigenciaHasta = ((DateTime.MinValue==A290UsuariosVigenciaHasta) ? true : false);
            Z5Cod_Area = cgiGet( "Z5Cod_Area");
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            edtUsuariosImagen_Filename = cgiGet( "USUARIOSIMAGEN_Filename");
            edtUsuariosImagen_Filetype = cgiGet( "USUARIOSIMAGEN_Filetype");
            /* Read variables values. */
            A16UsuariosCodigo = cgiGet( edtUsuariosCodigo_Internalname);
            AssignAttri("", false, "A16UsuariosCodigo", A16UsuariosCodigo);
            A116UsuariosNombres = cgiGet( edtUsuariosNombres_Internalname);
            AssignAttri("", false, "A116UsuariosNombres", A116UsuariosNombres);
            A117UsuariosPsw = cgiGet( edtUsuariosPsw_Internalname);
            AssignAttri("", false, "A117UsuariosPsw", A117UsuariosPsw);
            A5Cod_Area = cgiGet( edtCod_Area_Internalname);
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            if ( ( ( context.localUtil.CToN( cgiGet( edtUsuariosAdmin_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtUsuariosAdmin_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUARIOSADMIN");
               AnyError = 1;
               GX_FocusControl = edtUsuariosAdmin_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A118UsuariosAdmin = 0;
               AssignAttri("", false, "A118UsuariosAdmin", StringUtil.LTrimStr( (decimal)(A118UsuariosAdmin), 4, 0));
            }
            else
            {
               A118UsuariosAdmin = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtUsuariosAdmin_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A118UsuariosAdmin", StringUtil.LTrimStr( (decimal)(A118UsuariosAdmin), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtUsuariosActualiza_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtUsuariosActualiza_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUARIOSACTUALIZA");
               AnyError = 1;
               GX_FocusControl = edtUsuariosActualiza_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A119UsuariosActualiza = 0;
               AssignAttri("", false, "A119UsuariosActualiza", StringUtil.LTrimStr( (decimal)(A119UsuariosActualiza), 4, 0));
            }
            else
            {
               A119UsuariosActualiza = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtUsuariosActualiza_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A119UsuariosActualiza", StringUtil.LTrimStr( (decimal)(A119UsuariosActualiza), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtUsuariosOrden_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtUsuariosOrden_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUARIOSORDEN");
               AnyError = 1;
               GX_FocusControl = edtUsuariosOrden_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A120UsuariosOrden = 0;
               AssignAttri("", false, "A120UsuariosOrden", StringUtil.LTrimStr( (decimal)(A120UsuariosOrden), 4, 0));
            }
            else
            {
               A120UsuariosOrden = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtUsuariosOrden_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A120UsuariosOrden", StringUtil.LTrimStr( (decimal)(A120UsuariosOrden), 4, 0));
            }
            A204UsuariosImagen = cgiGet( edtUsuariosImagen_Internalname);
            n204UsuariosImagen = false;
            AssignAttri("", false, "A204UsuariosImagen", A204UsuariosImagen);
            n204UsuariosImagen = (String.IsNullOrEmpty(StringUtil.RTrim( A204UsuariosImagen)) ? true : false);
            A205UsuariosLinkImagen = cgiGet( edtUsuariosLinkImagen_Internalname);
            n205UsuariosLinkImagen = false;
            AssignAttri("", false, "A205UsuariosLinkImagen", A205UsuariosLinkImagen);
            n205UsuariosLinkImagen = (String.IsNullOrEmpty(StringUtil.RTrim( A205UsuariosLinkImagen)) ? true : false);
            if ( context.localUtil.VCDate( cgiGet( edtUsuariosVigenciaHasta_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Usuarios Vigencia Hasta"}), 1, "USUARIOSVIGENCIAHASTA");
               AnyError = 1;
               GX_FocusControl = edtUsuariosVigenciaHasta_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A290UsuariosVigenciaHasta = DateTime.MinValue;
               n290UsuariosVigenciaHasta = false;
               AssignAttri("", false, "A290UsuariosVigenciaHasta", context.localUtil.Format(A290UsuariosVigenciaHasta, "99/99/99"));
            }
            else
            {
               A290UsuariosVigenciaHasta = context.localUtil.CToD( cgiGet( edtUsuariosVigenciaHasta_Internalname), 2);
               n290UsuariosVigenciaHasta = false;
               AssignAttri("", false, "A290UsuariosVigenciaHasta", context.localUtil.Format(A290UsuariosVigenciaHasta, "99/99/99"));
            }
            n290UsuariosVigenciaHasta = ((DateTime.MinValue==A290UsuariosVigenciaHasta) ? true : false);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A204UsuariosImagen)) )
            {
               edtUsuariosImagen_Filename = (string)(CGIGetFileName(edtUsuariosImagen_Internalname));
               edtUsuariosImagen_Filetype = (string)(CGIGetFileType(edtUsuariosImagen_Internalname));
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( A204UsuariosImagen)) )
            {
               GXCCtlgxBlob = "USUARIOSIMAGEN" + "_gxBlob";
               A204UsuariosImagen = cgiGet( GXCCtlgxBlob);
               n204UsuariosImagen = false;
               n204UsuariosImagen = (String.IsNullOrEmpty(StringUtil.RTrim( A204UsuariosImagen)) ? true : false);
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
               A16UsuariosCodigo = GetPar( "UsuariosCodigo");
               AssignAttri("", false, "A16UsuariosCodigo", A16UsuariosCodigo);
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
               InitAll032( ) ;
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
         DisableAttributes032( ) ;
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

      protected void ResetCaption030( )
      {
      }

      protected void ZM032( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z116UsuariosNombres = T00033_A116UsuariosNombres[0];
               Z117UsuariosPsw = T00033_A117UsuariosPsw[0];
               Z118UsuariosAdmin = T00033_A118UsuariosAdmin[0];
               Z119UsuariosActualiza = T00033_A119UsuariosActualiza[0];
               Z120UsuariosOrden = T00033_A120UsuariosOrden[0];
               Z205UsuariosLinkImagen = T00033_A205UsuariosLinkImagen[0];
               Z290UsuariosVigenciaHasta = T00033_A290UsuariosVigenciaHasta[0];
               Z5Cod_Area = T00033_A5Cod_Area[0];
            }
            else
            {
               Z116UsuariosNombres = A116UsuariosNombres;
               Z117UsuariosPsw = A117UsuariosPsw;
               Z118UsuariosAdmin = A118UsuariosAdmin;
               Z119UsuariosActualiza = A119UsuariosActualiza;
               Z120UsuariosOrden = A120UsuariosOrden;
               Z205UsuariosLinkImagen = A205UsuariosLinkImagen;
               Z290UsuariosVigenciaHasta = A290UsuariosVigenciaHasta;
               Z5Cod_Area = A5Cod_Area;
            }
         }
         if ( GX_JID == -2 )
         {
            Z16UsuariosCodigo = A16UsuariosCodigo;
            Z116UsuariosNombres = A116UsuariosNombres;
            Z117UsuariosPsw = A117UsuariosPsw;
            Z118UsuariosAdmin = A118UsuariosAdmin;
            Z119UsuariosActualiza = A119UsuariosActualiza;
            Z120UsuariosOrden = A120UsuariosOrden;
            Z204UsuariosImagen = A204UsuariosImagen;
            Z205UsuariosLinkImagen = A205UsuariosLinkImagen;
            Z290UsuariosVigenciaHasta = A290UsuariosVigenciaHasta;
            Z5Cod_Area = A5Cod_Area;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_5_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"COD_AREA"+"'), id:'"+"COD_AREA"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
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

      protected void Load032( )
      {
         /* Using cursor T00035 */
         pr_default.execute(3, new Object[] {A16UsuariosCodigo});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound2 = 1;
            A116UsuariosNombres = T00035_A116UsuariosNombres[0];
            AssignAttri("", false, "A116UsuariosNombres", A116UsuariosNombres);
            A117UsuariosPsw = T00035_A117UsuariosPsw[0];
            AssignAttri("", false, "A117UsuariosPsw", A117UsuariosPsw);
            A118UsuariosAdmin = T00035_A118UsuariosAdmin[0];
            AssignAttri("", false, "A118UsuariosAdmin", StringUtil.LTrimStr( (decimal)(A118UsuariosAdmin), 4, 0));
            A119UsuariosActualiza = T00035_A119UsuariosActualiza[0];
            AssignAttri("", false, "A119UsuariosActualiza", StringUtil.LTrimStr( (decimal)(A119UsuariosActualiza), 4, 0));
            A120UsuariosOrden = T00035_A120UsuariosOrden[0];
            AssignAttri("", false, "A120UsuariosOrden", StringUtil.LTrimStr( (decimal)(A120UsuariosOrden), 4, 0));
            A205UsuariosLinkImagen = T00035_A205UsuariosLinkImagen[0];
            n205UsuariosLinkImagen = T00035_n205UsuariosLinkImagen[0];
            AssignAttri("", false, "A205UsuariosLinkImagen", A205UsuariosLinkImagen);
            A290UsuariosVigenciaHasta = T00035_A290UsuariosVigenciaHasta[0];
            n290UsuariosVigenciaHasta = T00035_n290UsuariosVigenciaHasta[0];
            AssignAttri("", false, "A290UsuariosVigenciaHasta", context.localUtil.Format(A290UsuariosVigenciaHasta, "99/99/99"));
            A5Cod_Area = T00035_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A204UsuariosImagen = T00035_A204UsuariosImagen[0];
            n204UsuariosImagen = T00035_n204UsuariosImagen[0];
            AssignAttri("", false, "A204UsuariosImagen", A204UsuariosImagen);
            AssignProp("", false, edtUsuariosImagen_Internalname, "URL", context.PathToRelativeUrl( A204UsuariosImagen), true);
            ZM032( -2) ;
         }
         pr_default.close(3);
         OnLoadActions032( ) ;
      }

      protected void OnLoadActions032( )
      {
      }

      protected void CheckExtendedTable032( )
      {
         nIsDirty_2 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00034 */
         pr_default.execute(2, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         if ( ! ( (DateTime.MinValue==A290UsuariosVigenciaHasta) || ( DateTimeUtil.ResetTime ( A290UsuariosVigenciaHasta ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Usuarios Vigencia Hasta fuera de rango", "OutOfRange", 1, "USUARIOSVIGENCIAHASTA");
            AnyError = 1;
            GX_FocusControl = edtUsuariosVigenciaHasta_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors032( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( string A5Cod_Area )
      {
         /* Using cursor T00036 */
         pr_default.execute(4, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
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

      protected void GetKey032( )
      {
         /* Using cursor T00037 */
         pr_default.execute(5, new Object[] {A16UsuariosCodigo});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound2 = 1;
         }
         else
         {
            RcdFound2 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00033 */
         pr_default.execute(1, new Object[] {A16UsuariosCodigo});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM032( 2) ;
            RcdFound2 = 1;
            A16UsuariosCodigo = T00033_A16UsuariosCodigo[0];
            AssignAttri("", false, "A16UsuariosCodigo", A16UsuariosCodigo);
            A116UsuariosNombres = T00033_A116UsuariosNombres[0];
            AssignAttri("", false, "A116UsuariosNombres", A116UsuariosNombres);
            A117UsuariosPsw = T00033_A117UsuariosPsw[0];
            AssignAttri("", false, "A117UsuariosPsw", A117UsuariosPsw);
            A118UsuariosAdmin = T00033_A118UsuariosAdmin[0];
            AssignAttri("", false, "A118UsuariosAdmin", StringUtil.LTrimStr( (decimal)(A118UsuariosAdmin), 4, 0));
            A119UsuariosActualiza = T00033_A119UsuariosActualiza[0];
            AssignAttri("", false, "A119UsuariosActualiza", StringUtil.LTrimStr( (decimal)(A119UsuariosActualiza), 4, 0));
            A120UsuariosOrden = T00033_A120UsuariosOrden[0];
            AssignAttri("", false, "A120UsuariosOrden", StringUtil.LTrimStr( (decimal)(A120UsuariosOrden), 4, 0));
            A205UsuariosLinkImagen = T00033_A205UsuariosLinkImagen[0];
            n205UsuariosLinkImagen = T00033_n205UsuariosLinkImagen[0];
            AssignAttri("", false, "A205UsuariosLinkImagen", A205UsuariosLinkImagen);
            A290UsuariosVigenciaHasta = T00033_A290UsuariosVigenciaHasta[0];
            n290UsuariosVigenciaHasta = T00033_n290UsuariosVigenciaHasta[0];
            AssignAttri("", false, "A290UsuariosVigenciaHasta", context.localUtil.Format(A290UsuariosVigenciaHasta, "99/99/99"));
            A5Cod_Area = T00033_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A204UsuariosImagen = T00033_A204UsuariosImagen[0];
            n204UsuariosImagen = T00033_n204UsuariosImagen[0];
            AssignAttri("", false, "A204UsuariosImagen", A204UsuariosImagen);
            AssignProp("", false, edtUsuariosImagen_Internalname, "URL", context.PathToRelativeUrl( A204UsuariosImagen), true);
            Z16UsuariosCodigo = A16UsuariosCodigo;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load032( ) ;
            if ( AnyError == 1 )
            {
               RcdFound2 = 0;
               InitializeNonKey032( ) ;
            }
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound2 = 0;
            InitializeNonKey032( ) ;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey032( ) ;
         if ( RcdFound2 == 0 )
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
         RcdFound2 = 0;
         /* Using cursor T00038 */
         pr_default.execute(6, new Object[] {A16UsuariosCodigo});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T00038_A16UsuariosCodigo[0], A16UsuariosCodigo) < 0 ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T00038_A16UsuariosCodigo[0], A16UsuariosCodigo) > 0 ) ) )
            {
               A16UsuariosCodigo = T00038_A16UsuariosCodigo[0];
               AssignAttri("", false, "A16UsuariosCodigo", A16UsuariosCodigo);
               RcdFound2 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound2 = 0;
         /* Using cursor T00039 */
         pr_default.execute(7, new Object[] {A16UsuariosCodigo});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T00039_A16UsuariosCodigo[0], A16UsuariosCodigo) > 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T00039_A16UsuariosCodigo[0], A16UsuariosCodigo) < 0 ) ) )
            {
               A16UsuariosCodigo = T00039_A16UsuariosCodigo[0];
               AssignAttri("", false, "A16UsuariosCodigo", A16UsuariosCodigo);
               RcdFound2 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey032( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtUsuariosCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert032( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound2 == 1 )
            {
               if ( StringUtil.StrCmp(A16UsuariosCodigo, Z16UsuariosCodigo) != 0 )
               {
                  A16UsuariosCodigo = Z16UsuariosCodigo;
                  AssignAttri("", false, "A16UsuariosCodigo", A16UsuariosCodigo);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "USUARIOSCODIGO");
                  AnyError = 1;
                  GX_FocusControl = edtUsuariosCodigo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtUsuariosCodigo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update032( ) ;
                  GX_FocusControl = edtUsuariosCodigo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A16UsuariosCodigo, Z16UsuariosCodigo) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtUsuariosCodigo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert032( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "USUARIOSCODIGO");
                     AnyError = 1;
                     GX_FocusControl = edtUsuariosCodigo_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtUsuariosCodigo_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert032( ) ;
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
         if ( StringUtil.StrCmp(A16UsuariosCodigo, Z16UsuariosCodigo) != 0 )
         {
            A16UsuariosCodigo = Z16UsuariosCodigo;
            AssignAttri("", false, "A16UsuariosCodigo", A16UsuariosCodigo);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "USUARIOSCODIGO");
            AnyError = 1;
            GX_FocusControl = edtUsuariosCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtUsuariosCodigo_Internalname;
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
         if ( RcdFound2 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "USUARIOSCODIGO");
            AnyError = 1;
            GX_FocusControl = edtUsuariosCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtUsuariosNombres_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart032( ) ;
         if ( RcdFound2 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtUsuariosNombres_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd032( ) ;
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
         if ( RcdFound2 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtUsuariosNombres_Internalname;
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
         if ( RcdFound2 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtUsuariosNombres_Internalname;
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
         ScanStart032( ) ;
         if ( RcdFound2 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound2 != 0 )
            {
               ScanNext032( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtUsuariosNombres_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd032( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency032( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00032 */
            pr_default.execute(0, new Object[] {A16UsuariosCodigo});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Usuarios"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z116UsuariosNombres, T00032_A116UsuariosNombres[0]) != 0 ) || ( StringUtil.StrCmp(Z117UsuariosPsw, T00032_A117UsuariosPsw[0]) != 0 ) || ( Z118UsuariosAdmin != T00032_A118UsuariosAdmin[0] ) || ( Z119UsuariosActualiza != T00032_A119UsuariosActualiza[0] ) || ( Z120UsuariosOrden != T00032_A120UsuariosOrden[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z205UsuariosLinkImagen, T00032_A205UsuariosLinkImagen[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z290UsuariosVigenciaHasta ) != DateTimeUtil.ResetTime ( T00032_A290UsuariosVigenciaHasta[0] ) ) || ( StringUtil.StrCmp(Z5Cod_Area, T00032_A5Cod_Area[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z116UsuariosNombres, T00032_A116UsuariosNombres[0]) != 0 )
               {
                  GXUtil.WriteLog("usuarios:[seudo value changed for attri]"+"UsuariosNombres");
                  GXUtil.WriteLogRaw("Old: ",Z116UsuariosNombres);
                  GXUtil.WriteLogRaw("Current: ",T00032_A116UsuariosNombres[0]);
               }
               if ( StringUtil.StrCmp(Z117UsuariosPsw, T00032_A117UsuariosPsw[0]) != 0 )
               {
                  GXUtil.WriteLog("usuarios:[seudo value changed for attri]"+"UsuariosPsw");
                  GXUtil.WriteLogRaw("Old: ",Z117UsuariosPsw);
                  GXUtil.WriteLogRaw("Current: ",T00032_A117UsuariosPsw[0]);
               }
               if ( Z118UsuariosAdmin != T00032_A118UsuariosAdmin[0] )
               {
                  GXUtil.WriteLog("usuarios:[seudo value changed for attri]"+"UsuariosAdmin");
                  GXUtil.WriteLogRaw("Old: ",Z118UsuariosAdmin);
                  GXUtil.WriteLogRaw("Current: ",T00032_A118UsuariosAdmin[0]);
               }
               if ( Z119UsuariosActualiza != T00032_A119UsuariosActualiza[0] )
               {
                  GXUtil.WriteLog("usuarios:[seudo value changed for attri]"+"UsuariosActualiza");
                  GXUtil.WriteLogRaw("Old: ",Z119UsuariosActualiza);
                  GXUtil.WriteLogRaw("Current: ",T00032_A119UsuariosActualiza[0]);
               }
               if ( Z120UsuariosOrden != T00032_A120UsuariosOrden[0] )
               {
                  GXUtil.WriteLog("usuarios:[seudo value changed for attri]"+"UsuariosOrden");
                  GXUtil.WriteLogRaw("Old: ",Z120UsuariosOrden);
                  GXUtil.WriteLogRaw("Current: ",T00032_A120UsuariosOrden[0]);
               }
               if ( StringUtil.StrCmp(Z205UsuariosLinkImagen, T00032_A205UsuariosLinkImagen[0]) != 0 )
               {
                  GXUtil.WriteLog("usuarios:[seudo value changed for attri]"+"UsuariosLinkImagen");
                  GXUtil.WriteLogRaw("Old: ",Z205UsuariosLinkImagen);
                  GXUtil.WriteLogRaw("Current: ",T00032_A205UsuariosLinkImagen[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z290UsuariosVigenciaHasta ) != DateTimeUtil.ResetTime ( T00032_A290UsuariosVigenciaHasta[0] ) )
               {
                  GXUtil.WriteLog("usuarios:[seudo value changed for attri]"+"UsuariosVigenciaHasta");
                  GXUtil.WriteLogRaw("Old: ",Z290UsuariosVigenciaHasta);
                  GXUtil.WriteLogRaw("Current: ",T00032_A290UsuariosVigenciaHasta[0]);
               }
               if ( StringUtil.StrCmp(Z5Cod_Area, T00032_A5Cod_Area[0]) != 0 )
               {
                  GXUtil.WriteLog("usuarios:[seudo value changed for attri]"+"Cod_Area");
                  GXUtil.WriteLogRaw("Old: ",Z5Cod_Area);
                  GXUtil.WriteLogRaw("Current: ",T00032_A5Cod_Area[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Usuarios"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert032( )
      {
         BeforeValidate032( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable032( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM032( 0) ;
            CheckOptimisticConcurrency032( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm032( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert032( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000310 */
                     pr_default.execute(8, new Object[] {A16UsuariosCodigo, A116UsuariosNombres, A117UsuariosPsw, A118UsuariosAdmin, A119UsuariosActualiza, A120UsuariosOrden, n204UsuariosImagen, A204UsuariosImagen, n205UsuariosLinkImagen, A205UsuariosLinkImagen, n290UsuariosVigenciaHasta, A290UsuariosVigenciaHasta, A5Cod_Area});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Usuarios");
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
                           ResetCaption030( ) ;
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
               Load032( ) ;
            }
            EndLevel032( ) ;
         }
         CloseExtendedTableCursors032( ) ;
      }

      protected void Update032( )
      {
         BeforeValidate032( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable032( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency032( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm032( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate032( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000311 */
                     pr_default.execute(9, new Object[] {A116UsuariosNombres, A117UsuariosPsw, A118UsuariosAdmin, A119UsuariosActualiza, A120UsuariosOrden, n205UsuariosLinkImagen, A205UsuariosLinkImagen, n290UsuariosVigenciaHasta, A290UsuariosVigenciaHasta, A5Cod_Area, A16UsuariosCodigo});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Usuarios");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Usuarios"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate032( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption030( ) ;
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
            EndLevel032( ) ;
         }
         CloseExtendedTableCursors032( ) ;
      }

      protected void DeferredUpdate032( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000312 */
            pr_default.execute(10, new Object[] {n204UsuariosImagen, A204UsuariosImagen, A16UsuariosCodigo});
            pr_default.close(10);
            pr_default.SmartCacheProvider.SetUpdated("Usuarios");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate032( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency032( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls032( ) ;
            AfterConfirm032( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete032( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000313 */
                  pr_default.execute(11, new Object[] {A16UsuariosCodigo});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("Usuarios");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound2 == 0 )
                        {
                           InitAll032( ) ;
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
                        ResetCaption030( ) ;
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
         sMode2 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel032( ) ;
         Gx_mode = sMode2;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls032( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000314 */
            pr_default.execute(12, new Object[] {A16UsuariosCodigo});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Metas Indicadores"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void EndLevel032( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete032( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("usuarios",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues030( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("usuarios",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart032( )
      {
         /* Using cursor T000315 */
         pr_default.execute(13);
         RcdFound2 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound2 = 1;
            A16UsuariosCodigo = T000315_A16UsuariosCodigo[0];
            AssignAttri("", false, "A16UsuariosCodigo", A16UsuariosCodigo);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext032( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound2 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound2 = 1;
            A16UsuariosCodigo = T000315_A16UsuariosCodigo[0];
            AssignAttri("", false, "A16UsuariosCodigo", A16UsuariosCodigo);
         }
      }

      protected void ScanEnd032( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm032( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert032( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate032( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete032( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete032( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate032( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes032( )
      {
         edtUsuariosCodigo_Enabled = 0;
         AssignProp("", false, edtUsuariosCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosCodigo_Enabled), 5, 0), true);
         edtUsuariosNombres_Enabled = 0;
         AssignProp("", false, edtUsuariosNombres_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosNombres_Enabled), 5, 0), true);
         edtUsuariosPsw_Enabled = 0;
         AssignProp("", false, edtUsuariosPsw_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosPsw_Enabled), 5, 0), true);
         edtCod_Area_Enabled = 0;
         AssignProp("", false, edtCod_Area_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCod_Area_Enabled), 5, 0), true);
         edtUsuariosAdmin_Enabled = 0;
         AssignProp("", false, edtUsuariosAdmin_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosAdmin_Enabled), 5, 0), true);
         edtUsuariosActualiza_Enabled = 0;
         AssignProp("", false, edtUsuariosActualiza_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosActualiza_Enabled), 5, 0), true);
         edtUsuariosOrden_Enabled = 0;
         AssignProp("", false, edtUsuariosOrden_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosOrden_Enabled), 5, 0), true);
         edtUsuariosImagen_Enabled = 0;
         AssignProp("", false, edtUsuariosImagen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosImagen_Enabled), 5, 0), true);
         edtUsuariosLinkImagen_Enabled = 0;
         AssignProp("", false, edtUsuariosLinkImagen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosLinkImagen_Enabled), 5, 0), true);
         edtUsuariosVigenciaHasta_Enabled = 0;
         AssignProp("", false, edtUsuariosVigenciaHasta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosVigenciaHasta_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes032( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues030( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("usuarios.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z16UsuariosCodigo", Z16UsuariosCodigo);
         GxWebStd.gx_hidden_field( context, "Z116UsuariosNombres", Z116UsuariosNombres);
         GxWebStd.gx_hidden_field( context, "Z117UsuariosPsw", Z117UsuariosPsw);
         GxWebStd.gx_hidden_field( context, "Z118UsuariosAdmin", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z118UsuariosAdmin), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z119UsuariosActualiza", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z119UsuariosActualiza), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z120UsuariosOrden", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z120UsuariosOrden), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z205UsuariosLinkImagen", Z205UsuariosLinkImagen);
         GxWebStd.gx_hidden_field( context, "Z290UsuariosVigenciaHasta", context.localUtil.DToC( Z290UsuariosVigenciaHasta, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z5Cod_Area", Z5Cod_Area);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GXCCtlgxBlob = "USUARIOSIMAGEN" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A204UsuariosImagen);
         GxWebStd.gx_hidden_field( context, "USUARIOSIMAGEN_Filename", StringUtil.RTrim( edtUsuariosImagen_Filename));
         GxWebStd.gx_hidden_field( context, "USUARIOSIMAGEN_Filetype", StringUtil.RTrim( edtUsuariosImagen_Filetype));
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
         return formatLink("usuarios.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Usuarios" ;
      }

      public override string GetPgmdesc( )
      {
         return "Usuarios" ;
      }

      protected void InitializeNonKey032( )
      {
         A116UsuariosNombres = "";
         AssignAttri("", false, "A116UsuariosNombres", A116UsuariosNombres);
         A117UsuariosPsw = "";
         AssignAttri("", false, "A117UsuariosPsw", A117UsuariosPsw);
         A5Cod_Area = "";
         AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
         A118UsuariosAdmin = 0;
         AssignAttri("", false, "A118UsuariosAdmin", StringUtil.LTrimStr( (decimal)(A118UsuariosAdmin), 4, 0));
         A119UsuariosActualiza = 0;
         AssignAttri("", false, "A119UsuariosActualiza", StringUtil.LTrimStr( (decimal)(A119UsuariosActualiza), 4, 0));
         A120UsuariosOrden = 0;
         AssignAttri("", false, "A120UsuariosOrden", StringUtil.LTrimStr( (decimal)(A120UsuariosOrden), 4, 0));
         A204UsuariosImagen = "";
         n204UsuariosImagen = false;
         AssignAttri("", false, "A204UsuariosImagen", A204UsuariosImagen);
         AssignProp("", false, edtUsuariosImagen_Internalname, "URL", context.PathToRelativeUrl( A204UsuariosImagen), true);
         n204UsuariosImagen = (String.IsNullOrEmpty(StringUtil.RTrim( A204UsuariosImagen)) ? true : false);
         A205UsuariosLinkImagen = "";
         n205UsuariosLinkImagen = false;
         AssignAttri("", false, "A205UsuariosLinkImagen", A205UsuariosLinkImagen);
         n205UsuariosLinkImagen = (String.IsNullOrEmpty(StringUtil.RTrim( A205UsuariosLinkImagen)) ? true : false);
         A290UsuariosVigenciaHasta = DateTime.MinValue;
         n290UsuariosVigenciaHasta = false;
         AssignAttri("", false, "A290UsuariosVigenciaHasta", context.localUtil.Format(A290UsuariosVigenciaHasta, "99/99/99"));
         n290UsuariosVigenciaHasta = ((DateTime.MinValue==A290UsuariosVigenciaHasta) ? true : false);
         Z116UsuariosNombres = "";
         Z117UsuariosPsw = "";
         Z118UsuariosAdmin = 0;
         Z119UsuariosActualiza = 0;
         Z120UsuariosOrden = 0;
         Z205UsuariosLinkImagen = "";
         Z290UsuariosVigenciaHasta = DateTime.MinValue;
         Z5Cod_Area = "";
      }

      protected void InitAll032( )
      {
         A16UsuariosCodigo = "";
         AssignAttri("", false, "A16UsuariosCodigo", A16UsuariosCodigo);
         InitializeNonKey032( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20247231015271", true, true);
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
         context.AddJavascriptSource("usuarios.js", "?20247231015272", false, true);
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
         edtUsuariosCodigo_Internalname = "USUARIOSCODIGO";
         edtUsuariosNombres_Internalname = "USUARIOSNOMBRES";
         edtUsuariosPsw_Internalname = "USUARIOSPSW";
         edtCod_Area_Internalname = "COD_AREA";
         edtUsuariosAdmin_Internalname = "USUARIOSADMIN";
         edtUsuariosActualiza_Internalname = "USUARIOSACTUALIZA";
         edtUsuariosOrden_Internalname = "USUARIOSORDEN";
         edtUsuariosImagen_Internalname = "USUARIOSIMAGEN";
         edtUsuariosLinkImagen_Internalname = "USUARIOSLINKIMAGEN";
         edtUsuariosVigenciaHasta_Internalname = "USUARIOSVIGENCIAHASTA";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_5_Internalname = "PROMPT_5";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("IndicadroresPalmas", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtUsuariosImagen_Filename = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Usuarios";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtUsuariosVigenciaHasta_Jsonclick = "";
         edtUsuariosVigenciaHasta_Enabled = 1;
         edtUsuariosLinkImagen_Enabled = 1;
         edtUsuariosImagen_Jsonclick = "";
         edtUsuariosImagen_Parameters = "";
         edtUsuariosImagen_Contenttype = "";
         edtUsuariosImagen_Filetype = "";
         edtUsuariosImagen_Enabled = 1;
         edtUsuariosOrden_Jsonclick = "";
         edtUsuariosOrden_Enabled = 1;
         edtUsuariosActualiza_Jsonclick = "";
         edtUsuariosActualiza_Enabled = 1;
         edtUsuariosAdmin_Jsonclick = "";
         edtUsuariosAdmin_Enabled = 1;
         imgprompt_5_Visible = 1;
         imgprompt_5_Link = "";
         edtCod_Area_Jsonclick = "";
         edtCod_Area_Enabled = 1;
         edtUsuariosPsw_Jsonclick = "";
         edtUsuariosPsw_Enabled = 1;
         edtUsuariosNombres_Jsonclick = "";
         edtUsuariosNombres_Enabled = 1;
         edtUsuariosCodigo_Jsonclick = "";
         edtUsuariosCodigo_Enabled = 1;
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
         GX_FocusControl = edtUsuariosNombres_Internalname;
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

      public void Valid_Usuarioscodigo( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A116UsuariosNombres", A116UsuariosNombres);
         AssignAttri("", false, "A117UsuariosPsw", A117UsuariosPsw);
         AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
         AssignAttri("", false, "A118UsuariosAdmin", StringUtil.LTrim( StringUtil.NToC( (decimal)(A118UsuariosAdmin), 4, 0, ".", "")));
         AssignAttri("", false, "A119UsuariosActualiza", StringUtil.LTrim( StringUtil.NToC( (decimal)(A119UsuariosActualiza), 4, 0, ".", "")));
         AssignAttri("", false, "A120UsuariosOrden", StringUtil.LTrim( StringUtil.NToC( (decimal)(A120UsuariosOrden), 4, 0, ".", "")));
         AssignAttri("", false, "A204UsuariosImagen", context.PathToRelativeUrl( A204UsuariosImagen));
         AssignAttri("", false, "A205UsuariosLinkImagen", A205UsuariosLinkImagen);
         AssignAttri("", false, "A290UsuariosVigenciaHasta", context.localUtil.Format(A290UsuariosVigenciaHasta, "99/99/99"));
         AssignProp("", false, edtUsuariosImagen_Internalname, "Filetype", edtUsuariosImagen_Filetype, true);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z16UsuariosCodigo", Z16UsuariosCodigo);
         GxWebStd.gx_hidden_field( context, "Z116UsuariosNombres", Z116UsuariosNombres);
         GxWebStd.gx_hidden_field( context, "Z117UsuariosPsw", Z117UsuariosPsw);
         GxWebStd.gx_hidden_field( context, "Z5Cod_Area", Z5Cod_Area);
         GxWebStd.gx_hidden_field( context, "Z118UsuariosAdmin", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z118UsuariosAdmin), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z119UsuariosActualiza", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z119UsuariosActualiza), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z120UsuariosOrden", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z120UsuariosOrden), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z204UsuariosImagen", context.PathToRelativeUrl( Z204UsuariosImagen));
         GxWebStd.gx_hidden_field( context, "Z205UsuariosLinkImagen", Z205UsuariosLinkImagen);
         GxWebStd.gx_hidden_field( context, "Z290UsuariosVigenciaHasta", context.localUtil.Format(Z290UsuariosVigenciaHasta, "99/99/99"));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Cod_area( )
      {
         /* Using cursor T000316 */
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
         setEventMetadata("VALID_USUARIOSCODIGO","{handler:'Valid_Usuarioscodigo',iparms:[{av:'A16UsuariosCodigo',fld:'USUARIOSCODIGO',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_USUARIOSCODIGO",",oparms:[{av:'A116UsuariosNombres',fld:'USUARIOSNOMBRES',pic:''},{av:'A117UsuariosPsw',fld:'USUARIOSPSW',pic:''},{av:'A5Cod_Area',fld:'COD_AREA',pic:''},{av:'A118UsuariosAdmin',fld:'USUARIOSADMIN',pic:'ZZZ9'},{av:'A119UsuariosActualiza',fld:'USUARIOSACTUALIZA',pic:'ZZZ9'},{av:'A120UsuariosOrden',fld:'USUARIOSORDEN',pic:'ZZZ9'},{av:'A204UsuariosImagen',fld:'USUARIOSIMAGEN',pic:''},{av:'A205UsuariosLinkImagen',fld:'USUARIOSLINKIMAGEN',pic:''},{av:'A290UsuariosVigenciaHasta',fld:'USUARIOSVIGENCIAHASTA',pic:''},{av:'edtUsuariosImagen_Filetype',ctrl:'USUARIOSIMAGEN',prop:'Filetype'},{av:'edtUsuariosImagen_Filename',ctrl:'USUARIOSIMAGEN',prop:'Filename'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z16UsuariosCodigo'},{av:'Z116UsuariosNombres'},{av:'Z117UsuariosPsw'},{av:'Z5Cod_Area'},{av:'Z118UsuariosAdmin'},{av:'Z119UsuariosActualiza'},{av:'Z120UsuariosOrden'},{av:'Z204UsuariosImagen'},{av:'Z205UsuariosLinkImagen'},{av:'Z290UsuariosVigenciaHasta'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_COD_AREA","{handler:'Valid_Cod_area',iparms:[{av:'A5Cod_Area',fld:'COD_AREA',pic:''}]");
         setEventMetadata("VALID_COD_AREA",",oparms:[]}");
         setEventMetadata("VALID_USUARIOSVIGENCIAHASTA","{handler:'Valid_Usuariosvigenciahasta',iparms:[]");
         setEventMetadata("VALID_USUARIOSVIGENCIAHASTA",",oparms:[]}");
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
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z16UsuariosCodigo = "";
         Z116UsuariosNombres = "";
         Z117UsuariosPsw = "";
         Z205UsuariosLinkImagen = "";
         Z290UsuariosVigenciaHasta = DateTime.MinValue;
         Z5Cod_Area = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A5Cod_Area = "";
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
         A16UsuariosCodigo = "";
         A116UsuariosNombres = "";
         A117UsuariosPsw = "";
         imgprompt_5_gximage = "";
         sImgUrl = "";
         gxblobfileaux = new GxFile(context.GetPhysicalPath());
         A204UsuariosImagen = "";
         A205UsuariosLinkImagen = "";
         A290UsuariosVigenciaHasta = DateTime.MinValue;
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
         Z204UsuariosImagen = "";
         T00035_A16UsuariosCodigo = new string[] {""} ;
         T00035_A116UsuariosNombres = new string[] {""} ;
         T00035_A117UsuariosPsw = new string[] {""} ;
         T00035_A118UsuariosAdmin = new short[1] ;
         T00035_A119UsuariosActualiza = new short[1] ;
         T00035_A120UsuariosOrden = new short[1] ;
         T00035_A205UsuariosLinkImagen = new string[] {""} ;
         T00035_n205UsuariosLinkImagen = new bool[] {false} ;
         T00035_A290UsuariosVigenciaHasta = new DateTime[] {DateTime.MinValue} ;
         T00035_n290UsuariosVigenciaHasta = new bool[] {false} ;
         T00035_A5Cod_Area = new string[] {""} ;
         T00035_A204UsuariosImagen = new string[] {""} ;
         T00035_n204UsuariosImagen = new bool[] {false} ;
         T00034_A5Cod_Area = new string[] {""} ;
         T00036_A5Cod_Area = new string[] {""} ;
         T00037_A16UsuariosCodigo = new string[] {""} ;
         T00033_A16UsuariosCodigo = new string[] {""} ;
         T00033_A116UsuariosNombres = new string[] {""} ;
         T00033_A117UsuariosPsw = new string[] {""} ;
         T00033_A118UsuariosAdmin = new short[1] ;
         T00033_A119UsuariosActualiza = new short[1] ;
         T00033_A120UsuariosOrden = new short[1] ;
         T00033_A205UsuariosLinkImagen = new string[] {""} ;
         T00033_n205UsuariosLinkImagen = new bool[] {false} ;
         T00033_A290UsuariosVigenciaHasta = new DateTime[] {DateTime.MinValue} ;
         T00033_n290UsuariosVigenciaHasta = new bool[] {false} ;
         T00033_A5Cod_Area = new string[] {""} ;
         T00033_A204UsuariosImagen = new string[] {""} ;
         T00033_n204UsuariosImagen = new bool[] {false} ;
         sMode2 = "";
         T00038_A16UsuariosCodigo = new string[] {""} ;
         T00039_A16UsuariosCodigo = new string[] {""} ;
         T00032_A16UsuariosCodigo = new string[] {""} ;
         T00032_A116UsuariosNombres = new string[] {""} ;
         T00032_A117UsuariosPsw = new string[] {""} ;
         T00032_A118UsuariosAdmin = new short[1] ;
         T00032_A119UsuariosActualiza = new short[1] ;
         T00032_A120UsuariosOrden = new short[1] ;
         T00032_A205UsuariosLinkImagen = new string[] {""} ;
         T00032_n205UsuariosLinkImagen = new bool[] {false} ;
         T00032_A290UsuariosVigenciaHasta = new DateTime[] {DateTime.MinValue} ;
         T00032_n290UsuariosVigenciaHasta = new bool[] {false} ;
         T00032_A5Cod_Area = new string[] {""} ;
         T00032_A204UsuariosImagen = new string[] {""} ;
         T00032_n204UsuariosImagen = new bool[] {false} ;
         T000314_A4IndicadoresCodigo = new string[] {""} ;
         T000314_A32MetasIndicadoresMes = new short[1] ;
         T000314_A33MetasIndicadoresAno = new short[1] ;
         T000314_A31TipoMetasCodigo = new string[] {""} ;
         T000315_A16UsuariosCodigo = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ16UsuariosCodigo = "";
         ZZ116UsuariosNombres = "";
         ZZ117UsuariosPsw = "";
         ZZ5Cod_Area = "";
         ZZ204UsuariosImagen = "";
         ZZ205UsuariosLinkImagen = "";
         ZZ290UsuariosVigenciaHasta = DateTime.MinValue;
         T000316_A5Cod_Area = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.usuarios__default(),
            new Object[][] {
                new Object[] {
               T00032_A16UsuariosCodigo, T00032_A116UsuariosNombres, T00032_A117UsuariosPsw, T00032_A118UsuariosAdmin, T00032_A119UsuariosActualiza, T00032_A120UsuariosOrden, T00032_A205UsuariosLinkImagen, T00032_n205UsuariosLinkImagen, T00032_A290UsuariosVigenciaHasta, T00032_n290UsuariosVigenciaHasta,
               T00032_A5Cod_Area, T00032_A204UsuariosImagen, T00032_n204UsuariosImagen
               }
               , new Object[] {
               T00033_A16UsuariosCodigo, T00033_A116UsuariosNombres, T00033_A117UsuariosPsw, T00033_A118UsuariosAdmin, T00033_A119UsuariosActualiza, T00033_A120UsuariosOrden, T00033_A205UsuariosLinkImagen, T00033_n205UsuariosLinkImagen, T00033_A290UsuariosVigenciaHasta, T00033_n290UsuariosVigenciaHasta,
               T00033_A5Cod_Area, T00033_A204UsuariosImagen, T00033_n204UsuariosImagen
               }
               , new Object[] {
               T00034_A5Cod_Area
               }
               , new Object[] {
               T00035_A16UsuariosCodigo, T00035_A116UsuariosNombres, T00035_A117UsuariosPsw, T00035_A118UsuariosAdmin, T00035_A119UsuariosActualiza, T00035_A120UsuariosOrden, T00035_A205UsuariosLinkImagen, T00035_n205UsuariosLinkImagen, T00035_A290UsuariosVigenciaHasta, T00035_n290UsuariosVigenciaHasta,
               T00035_A5Cod_Area, T00035_A204UsuariosImagen, T00035_n204UsuariosImagen
               }
               , new Object[] {
               T00036_A5Cod_Area
               }
               , new Object[] {
               T00037_A16UsuariosCodigo
               }
               , new Object[] {
               T00038_A16UsuariosCodigo
               }
               , new Object[] {
               T00039_A16UsuariosCodigo
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
               T000314_A4IndicadoresCodigo, T000314_A32MetasIndicadoresMes, T000314_A33MetasIndicadoresAno, T000314_A31TipoMetasCodigo
               }
               , new Object[] {
               T000315_A16UsuariosCodigo
               }
               , new Object[] {
               T000316_A5Cod_Area
               }
            }
         );
      }

      private short Z118UsuariosAdmin ;
      private short Z119UsuariosActualiza ;
      private short Z120UsuariosOrden ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A118UsuariosAdmin ;
      private short A119UsuariosActualiza ;
      private short A120UsuariosOrden ;
      private short GX_JID ;
      private short RcdFound2 ;
      private short nIsDirty_2 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ118UsuariosAdmin ;
      private short ZZ119UsuariosActualiza ;
      private short ZZ120UsuariosOrden ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtUsuariosCodigo_Enabled ;
      private int edtUsuariosNombres_Enabled ;
      private int edtUsuariosPsw_Enabled ;
      private int edtCod_Area_Enabled ;
      private int imgprompt_5_Visible ;
      private int edtUsuariosAdmin_Enabled ;
      private int edtUsuariosActualiza_Enabled ;
      private int edtUsuariosOrden_Enabled ;
      private int edtUsuariosImagen_Enabled ;
      private int edtUsuariosLinkImagen_Enabled ;
      private int edtUsuariosVigenciaHasta_Enabled ;
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
      private string edtUsuariosCodigo_Internalname ;
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
      private string edtUsuariosCodigo_Jsonclick ;
      private string edtUsuariosNombres_Internalname ;
      private string edtUsuariosNombres_Jsonclick ;
      private string edtUsuariosPsw_Internalname ;
      private string edtUsuariosPsw_Jsonclick ;
      private string edtCod_Area_Internalname ;
      private string edtCod_Area_Jsonclick ;
      private string imgprompt_5_gximage ;
      private string sImgUrl ;
      private string imgprompt_5_Internalname ;
      private string imgprompt_5_Link ;
      private string edtUsuariosAdmin_Internalname ;
      private string edtUsuariosAdmin_Jsonclick ;
      private string edtUsuariosActualiza_Internalname ;
      private string edtUsuariosActualiza_Jsonclick ;
      private string edtUsuariosOrden_Internalname ;
      private string edtUsuariosOrden_Jsonclick ;
      private string edtUsuariosImagen_Internalname ;
      private string edtUsuariosImagen_Filetype ;
      private string edtUsuariosImagen_Contenttype ;
      private string edtUsuariosImagen_Parameters ;
      private string edtUsuariosImagen_Jsonclick ;
      private string edtUsuariosLinkImagen_Internalname ;
      private string edtUsuariosVigenciaHasta_Internalname ;
      private string edtUsuariosVigenciaHasta_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string Gx_mode ;
      private string edtUsuariosImagen_Filename ;
      private string GXCCtlgxBlob ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode2 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z290UsuariosVigenciaHasta ;
      private DateTime A290UsuariosVigenciaHasta ;
      private DateTime ZZ290UsuariosVigenciaHasta ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n204UsuariosImagen ;
      private bool n205UsuariosLinkImagen ;
      private bool n290UsuariosVigenciaHasta ;
      private bool Gx_longc ;
      private string Z16UsuariosCodigo ;
      private string Z116UsuariosNombres ;
      private string Z117UsuariosPsw ;
      private string Z205UsuariosLinkImagen ;
      private string Z5Cod_Area ;
      private string A5Cod_Area ;
      private string A16UsuariosCodigo ;
      private string A116UsuariosNombres ;
      private string A117UsuariosPsw ;
      private string A205UsuariosLinkImagen ;
      private string ZZ16UsuariosCodigo ;
      private string ZZ116UsuariosNombres ;
      private string ZZ117UsuariosPsw ;
      private string ZZ5Cod_Area ;
      private string ZZ205UsuariosLinkImagen ;
      private string A204UsuariosImagen ;
      private string Z204UsuariosImagen ;
      private string ZZ204UsuariosImagen ;
      private GxFile gxblobfileaux ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00035_A16UsuariosCodigo ;
      private string[] T00035_A116UsuariosNombres ;
      private string[] T00035_A117UsuariosPsw ;
      private short[] T00035_A118UsuariosAdmin ;
      private short[] T00035_A119UsuariosActualiza ;
      private short[] T00035_A120UsuariosOrden ;
      private string[] T00035_A205UsuariosLinkImagen ;
      private bool[] T00035_n205UsuariosLinkImagen ;
      private DateTime[] T00035_A290UsuariosVigenciaHasta ;
      private bool[] T00035_n290UsuariosVigenciaHasta ;
      private string[] T00035_A5Cod_Area ;
      private string[] T00035_A204UsuariosImagen ;
      private bool[] T00035_n204UsuariosImagen ;
      private string[] T00034_A5Cod_Area ;
      private string[] T00036_A5Cod_Area ;
      private string[] T00037_A16UsuariosCodigo ;
      private string[] T00033_A16UsuariosCodigo ;
      private string[] T00033_A116UsuariosNombres ;
      private string[] T00033_A117UsuariosPsw ;
      private short[] T00033_A118UsuariosAdmin ;
      private short[] T00033_A119UsuariosActualiza ;
      private short[] T00033_A120UsuariosOrden ;
      private string[] T00033_A205UsuariosLinkImagen ;
      private bool[] T00033_n205UsuariosLinkImagen ;
      private DateTime[] T00033_A290UsuariosVigenciaHasta ;
      private bool[] T00033_n290UsuariosVigenciaHasta ;
      private string[] T00033_A5Cod_Area ;
      private string[] T00033_A204UsuariosImagen ;
      private bool[] T00033_n204UsuariosImagen ;
      private string[] T00038_A16UsuariosCodigo ;
      private string[] T00039_A16UsuariosCodigo ;
      private string[] T00032_A16UsuariosCodigo ;
      private string[] T00032_A116UsuariosNombres ;
      private string[] T00032_A117UsuariosPsw ;
      private short[] T00032_A118UsuariosAdmin ;
      private short[] T00032_A119UsuariosActualiza ;
      private short[] T00032_A120UsuariosOrden ;
      private string[] T00032_A205UsuariosLinkImagen ;
      private bool[] T00032_n205UsuariosLinkImagen ;
      private DateTime[] T00032_A290UsuariosVigenciaHasta ;
      private bool[] T00032_n290UsuariosVigenciaHasta ;
      private string[] T00032_A5Cod_Area ;
      private string[] T00032_A204UsuariosImagen ;
      private bool[] T00032_n204UsuariosImagen ;
      private string[] T000314_A4IndicadoresCodigo ;
      private short[] T000314_A32MetasIndicadoresMes ;
      private short[] T000314_A33MetasIndicadoresAno ;
      private string[] T000314_A31TipoMetasCodigo ;
      private string[] T000315_A16UsuariosCodigo ;
      private string[] T000316_A5Cod_Area ;
      private GXWebForm Form ;
   }

   public class usuarios__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00035;
          prmT00035 = new Object[] {
          new ParDef("@UsuariosCodigo",GXType.NVarChar,150,0)
          };
          Object[] prmT00034;
          prmT00034 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT00036;
          prmT00036 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT00037;
          prmT00037 = new Object[] {
          new ParDef("@UsuariosCodigo",GXType.NVarChar,150,0)
          };
          Object[] prmT00033;
          prmT00033 = new Object[] {
          new ParDef("@UsuariosCodigo",GXType.NVarChar,150,0)
          };
          Object[] prmT00038;
          prmT00038 = new Object[] {
          new ParDef("@UsuariosCodigo",GXType.NVarChar,150,0)
          };
          Object[] prmT00039;
          prmT00039 = new Object[] {
          new ParDef("@UsuariosCodigo",GXType.NVarChar,150,0)
          };
          Object[] prmT00032;
          prmT00032 = new Object[] {
          new ParDef("@UsuariosCodigo",GXType.NVarChar,150,0)
          };
          Object[] prmT000310;
          prmT000310 = new Object[] {
          new ParDef("@UsuariosCodigo",GXType.NVarChar,150,0) ,
          new ParDef("@UsuariosNombres",GXType.NVarChar,120,0) ,
          new ParDef("@UsuariosPsw",GXType.NVarChar,32,0) ,
          new ParDef("@UsuariosAdmin",GXType.Int16,4,0) ,
          new ParDef("@UsuariosActualiza",GXType.Int16,4,0) ,
          new ParDef("@UsuariosOrden",GXType.Int16,4,0) ,
          new ParDef("@UsuariosImagen",GXType.Blob,1024,0){Nullable=true,InDB=true} ,
          new ParDef("@UsuariosLinkImagen",GXType.NVarChar,300,0){Nullable=true} ,
          new ParDef("@UsuariosVigenciaHasta",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000311;
          prmT000311 = new Object[] {
          new ParDef("@UsuariosNombres",GXType.NVarChar,120,0) ,
          new ParDef("@UsuariosPsw",GXType.NVarChar,32,0) ,
          new ParDef("@UsuariosAdmin",GXType.Int16,4,0) ,
          new ParDef("@UsuariosActualiza",GXType.Int16,4,0) ,
          new ParDef("@UsuariosOrden",GXType.Int16,4,0) ,
          new ParDef("@UsuariosLinkImagen",GXType.NVarChar,300,0){Nullable=true} ,
          new ParDef("@UsuariosVigenciaHasta",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@UsuariosCodigo",GXType.NVarChar,150,0)
          };
          Object[] prmT000312;
          prmT000312 = new Object[] {
          new ParDef("@UsuariosImagen",GXType.Blob,1024,0){Nullable=true,InDB=true} ,
          new ParDef("@UsuariosCodigo",GXType.NVarChar,150,0)
          };
          Object[] prmT000313;
          prmT000313 = new Object[] {
          new ParDef("@UsuariosCodigo",GXType.NVarChar,150,0)
          };
          Object[] prmT000314;
          prmT000314 = new Object[] {
          new ParDef("@UsuariosCodigo",GXType.NVarChar,150,0)
          };
          Object[] prmT000315;
          prmT000315 = new Object[] {
          };
          Object[] prmT000316;
          prmT000316 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00032", "SELECT [UsuariosCodigo], [UsuariosNombres], [UsuariosPsw], [UsuariosAdmin], [UsuariosActualiza], [UsuariosOrden], [UsuariosLinkImagen], [UsuariosVigenciaHasta], [Cod_Area], [UsuariosImagen] FROM [Usuarios] WITH (UPDLOCK) WHERE [UsuariosCodigo] = @UsuariosCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT00032,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00033", "SELECT [UsuariosCodigo], [UsuariosNombres], [UsuariosPsw], [UsuariosAdmin], [UsuariosActualiza], [UsuariosOrden], [UsuariosLinkImagen], [UsuariosVigenciaHasta], [Cod_Area], [UsuariosImagen] FROM [Usuarios] WHERE [UsuariosCodigo] = @UsuariosCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT00033,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00034", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT00034,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00035", "SELECT TM1.[UsuariosCodigo], TM1.[UsuariosNombres], TM1.[UsuariosPsw], TM1.[UsuariosAdmin], TM1.[UsuariosActualiza], TM1.[UsuariosOrden], TM1.[UsuariosLinkImagen], TM1.[UsuariosVigenciaHasta], TM1.[Cod_Area], TM1.[UsuariosImagen] FROM [Usuarios] TM1 WHERE TM1.[UsuariosCodigo] = @UsuariosCodigo ORDER BY TM1.[UsuariosCodigo]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00035,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00036", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT00036,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00037", "SELECT [UsuariosCodigo] FROM [Usuarios] WHERE [UsuariosCodigo] = @UsuariosCodigo  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00037,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00038", "SELECT TOP 1 [UsuariosCodigo] FROM [Usuarios] WHERE ( [UsuariosCodigo] > @UsuariosCodigo) ORDER BY [UsuariosCodigo]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00038,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00039", "SELECT TOP 1 [UsuariosCodigo] FROM [Usuarios] WHERE ( [UsuariosCodigo] < @UsuariosCodigo) ORDER BY [UsuariosCodigo] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00039,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000310", "INSERT INTO [Usuarios]([UsuariosCodigo], [UsuariosNombres], [UsuariosPsw], [UsuariosAdmin], [UsuariosActualiza], [UsuariosOrden], [UsuariosImagen], [UsuariosLinkImagen], [UsuariosVigenciaHasta], [Cod_Area]) VALUES(@UsuariosCodigo, @UsuariosNombres, @UsuariosPsw, @UsuariosAdmin, @UsuariosActualiza, @UsuariosOrden, @UsuariosImagen, @UsuariosLinkImagen, @UsuariosVigenciaHasta, @Cod_Area)", GxErrorMask.GX_NOMASK,prmT000310)
             ,new CursorDef("T000311", "UPDATE [Usuarios] SET [UsuariosNombres]=@UsuariosNombres, [UsuariosPsw]=@UsuariosPsw, [UsuariosAdmin]=@UsuariosAdmin, [UsuariosActualiza]=@UsuariosActualiza, [UsuariosOrden]=@UsuariosOrden, [UsuariosLinkImagen]=@UsuariosLinkImagen, [UsuariosVigenciaHasta]=@UsuariosVigenciaHasta, [Cod_Area]=@Cod_Area  WHERE [UsuariosCodigo] = @UsuariosCodigo", GxErrorMask.GX_NOMASK,prmT000311)
             ,new CursorDef("T000312", "UPDATE [Usuarios] SET [UsuariosImagen]=@UsuariosImagen  WHERE [UsuariosCodigo] = @UsuariosCodigo", GxErrorMask.GX_NOMASK,prmT000312)
             ,new CursorDef("T000313", "DELETE FROM [Usuarios]  WHERE [UsuariosCodigo] = @UsuariosCodigo", GxErrorMask.GX_NOMASK,prmT000313)
             ,new CursorDef("T000314", "SELECT TOP 1 [IndicadoresCodigo], [MetasIndicadoresMes], [MetasIndicadoresAno], [TipoMetasCodigo] FROM [MetasIndicadores] WHERE [UsuariosCodigo] = @UsuariosCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000314,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000315", "SELECT [UsuariosCodigo] FROM [Usuarios] ORDER BY [UsuariosCodigo]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000315,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000316", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000316,1, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((string[]) buf[10])[0] = rslt.getVarchar(9);
                ((string[]) buf[11])[0] = rslt.getBLOBFile(10, "tmp", "");
                ((bool[]) buf[12])[0] = rslt.wasNull(10);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((string[]) buf[10])[0] = rslt.getVarchar(9);
                ((string[]) buf[11])[0] = rslt.getBLOBFile(10, "tmp", "");
                ((bool[]) buf[12])[0] = rslt.wasNull(10);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((string[]) buf[10])[0] = rslt.getVarchar(9);
                ((string[]) buf[11])[0] = rslt.getBLOBFile(10, "tmp", "");
                ((bool[]) buf[12])[0] = rslt.wasNull(10);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 12 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
             case 13 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 14 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
       }
    }

 }

}
