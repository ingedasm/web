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
   public class rff_comprada : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A4IndicadoresCodigo = GetPar( "IndicadoresCodigo");
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A4IndicadoresCodigo) ;
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
            Form.Meta.addItem("description", "RFF_COMPRADA", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtRFF_COMPRADAFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("IndicadroresPalmas", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public rff_comprada( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("IndicadroresPalmas", true);
      }

      public rff_comprada( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "RFF_COMPRADA", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_RFF_COMPRADA.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_RFF_COMPRADA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_RFF_COMPRADA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_RFF_COMPRADA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_RFF_COMPRADA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 4, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx0160.aspx"+"',["+"{Ctrl:gx.dom.el('"+"RFF_COMPRADAFECHA"+"'), id:'"+"RFF_COMPRADAFECHA"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"COD_AREA"+"'), id:'"+"COD_AREA"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"INDICADORESCODIGO"+"'), id:'"+"INDICADORESCODIGO"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"RFF_COMPRADAMES"+"'), id:'"+"RFF_COMPRADAMES"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"RFF_COMPRADAANO"+"'), id:'"+"RFF_COMPRADAANO"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"RFF_COMPRAPRODUCUP"+"'), id:'"+"RFF_COMPRAPRODUCUP"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_RFF_COMPRADA.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRFF_COMPRADAFecha_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRFF_COMPRADAFecha_Internalname, "RFF_COMPRADAFecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtRFF_COMPRADAFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtRFF_COMPRADAFecha_Internalname, context.localUtil.Format(A86RFF_COMPRADAFecha, "99/99/99"), context.localUtil.Format( A86RFF_COMPRADAFecha, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRFF_COMPRADAFecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRFF_COMPRADAFecha_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_RFF_COMPRADA.htm");
         GxWebStd.gx_bitmap( context, edtRFF_COMPRADAFecha_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtRFF_COMPRADAFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_RFF_COMPRADA.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCod_Area_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCod_Area_Internalname, "Cod_Area", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCod_Area_Internalname, A5Cod_Area, StringUtil.RTrim( context.localUtil.Format( A5Cod_Area, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCod_Area_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCod_Area_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_RFF_COMPRADA.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_5_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_5_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_5_Internalname, sImgUrl, imgprompt_5_Link, "", "", context.GetTheme( ), imgprompt_5_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_RFF_COMPRADA.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIndicadoresCodigo_Internalname, A4IndicadoresCodigo, StringUtil.RTrim( context.localUtil.Format( A4IndicadoresCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIndicadoresCodigo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIndicadoresCodigo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_RFF_COMPRADA.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_4_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_4_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_4_Internalname, sImgUrl, imgprompt_4_Link, "", "", context.GetTheme( ), imgprompt_4_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_RFF_COMPRADA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRFF_COMPRADAMes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRFF_COMPRADAMes_Internalname, "RFF_COMPRADAMes", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRFF_COMPRADAMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A87RFF_COMPRADAMes), 4, 0, ",", "")), StringUtil.LTrim( ((edtRFF_COMPRADAMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A87RFF_COMPRADAMes), "ZZZ9") : context.localUtil.Format( (decimal)(A87RFF_COMPRADAMes), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRFF_COMPRADAMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRFF_COMPRADAMes_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_RFF_COMPRADA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRFF_COMPRADAAno_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRFF_COMPRADAAno_Internalname, "RFF_COMPRADAAno", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRFF_COMPRADAAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A88RFF_COMPRADAAno), 4, 0, ",", "")), StringUtil.LTrim( ((edtRFF_COMPRADAAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A88RFF_COMPRADAAno), "ZZZ9") : context.localUtil.Format( (decimal)(A88RFF_COMPRADAAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRFF_COMPRADAAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRFF_COMPRADAAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_RFF_COMPRADA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRFF_COMPRAPRODUCUP_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRFF_COMPRAPRODUCUP_Internalname, "RFF_COMPRAPRODUCUP", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRFF_COMPRAPRODUCUP_Internalname, StringUtil.RTrim( A89RFF_COMPRAPRODUCUP), StringUtil.RTrim( context.localUtil.Format( A89RFF_COMPRAPRODUCUP, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRFF_COMPRAPRODUCUP_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRFF_COMPRAPRODUCUP_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_RFF_COMPRADA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRFF_COMPRATON_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRFF_COMPRATON_Internalname, "RFF_COMPRATON", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRFF_COMPRATON_Internalname, StringUtil.LTrim( StringUtil.NToC( A238RFF_COMPRATON, 12, 2, ",", "")), StringUtil.LTrim( ((edtRFF_COMPRATON_Enabled!=0) ? context.localUtil.Format( A238RFF_COMPRATON, "ZZZZZZZZ9.99") : context.localUtil.Format( A238RFF_COMPRATON, "ZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRFF_COMPRATON_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRFF_COMPRATON_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_RFF_COMPRADA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRFF_COMPRAPROVEE_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRFF_COMPRAPROVEE_Internalname, "RFF_COMPRAPROVEE", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtRFF_COMPRAPROVEE_Internalname, A239RFF_COMPRAPROVEE, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", 0, 1, edtRFF_COMPRAPROVEE_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_RFF_COMPRADA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRFF_COMPRAFINCA_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRFF_COMPRAFINCA_Internalname, "RFF_COMPRAFINCA", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtRFF_COMPRAFINCA_Internalname, A240RFF_COMPRAFINCA, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", 0, 1, edtRFF_COMPRAFINCA_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_RFF_COMPRADA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRFF_COMPRAZONA_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRFF_COMPRAZONA_Internalname, "RFF_COMPRAZONA", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRFF_COMPRAZONA_Internalname, A241RFF_COMPRAZONA, StringUtil.RTrim( context.localUtil.Format( A241RFF_COMPRAZONA, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRFF_COMPRAZONA_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRFF_COMPRAZONA_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_RFF_COMPRADA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRFF_COMPRAVEREDAID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRFF_COMPRAVEREDAID_Internalname, "RFF_COMPRAVEREDAID", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRFF_COMPRAVEREDAID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A242RFF_COMPRAVEREDAID), 15, 0, ",", "")), StringUtil.LTrim( ((edtRFF_COMPRAVEREDAID_Enabled!=0) ? context.localUtil.Format( (decimal)(A242RFF_COMPRAVEREDAID), "ZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A242RFF_COMPRAVEREDAID), "ZZZZZZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRFF_COMPRAVEREDAID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRFF_COMPRAVEREDAID_Enabled, 0, "text", "1", 15, "chr", 1, "row", 15, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_RFF_COMPRADA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRFF_COMPRAVEREDANOM_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRFF_COMPRAVEREDANOM_Internalname, "RFF_COMPRAVEREDANOM", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtRFF_COMPRAVEREDANOM_Internalname, A243RFF_COMPRAVEREDANOM, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", 0, 1, edtRFF_COMPRAVEREDANOM_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_RFF_COMPRADA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRFF_COMPRAMUNIID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRFF_COMPRAMUNIID_Internalname, "RFF_COMPRAMUNIID", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRFF_COMPRAMUNIID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A244RFF_COMPRAMUNIID), 10, 0, ",", "")), StringUtil.LTrim( ((edtRFF_COMPRAMUNIID_Enabled!=0) ? context.localUtil.Format( (decimal)(A244RFF_COMPRAMUNIID), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A244RFF_COMPRAMUNIID), "ZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,94);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRFF_COMPRAMUNIID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRFF_COMPRAMUNIID_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_RFF_COMPRADA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRFF_COMPRAMUNINOM_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRFF_COMPRAMUNINOM_Internalname, "RFF_COMPRAMUNINOM", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtRFF_COMPRAMUNINOM_Internalname, A245RFF_COMPRAMUNINOM, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", 0, 1, edtRFF_COMPRAMUNINOM_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_RFF_COMPRADA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRFF_COMPRADEPTOID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRFF_COMPRADEPTOID_Internalname, "RFF_COMPRADEPTOID", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRFF_COMPRADEPTOID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A246RFF_COMPRADEPTOID), 10, 0, ",", "")), StringUtil.LTrim( ((edtRFF_COMPRADEPTOID_Enabled!=0) ? context.localUtil.Format( (decimal)(A246RFF_COMPRADEPTOID), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A246RFF_COMPRADEPTOID), "ZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,104);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRFF_COMPRADEPTOID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRFF_COMPRADEPTOID_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_RFF_COMPRADA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRFF_COMPRADEPTONOM_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRFF_COMPRADEPTONOM_Internalname, "RFF_COMPRADEPTONOM", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtRFF_COMPRADEPTONOM_Internalname, A247RFF_COMPRADEPTONOM, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,109);\"", 0, 1, edtRFF_COMPRADEPTONOM_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_RFF_COMPRADA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRFF_COMPRACLASIFIC_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRFF_COMPRACLASIFIC_Internalname, "RFF_COMPRACLASIFIC", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRFF_COMPRACLASIFIC_Internalname, A248RFF_COMPRACLASIFIC, StringUtil.RTrim( context.localUtil.Format( A248RFF_COMPRACLASIFIC, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,114);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRFF_COMPRACLASIFIC_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRFF_COMPRACLASIFIC_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_RFF_COMPRADA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRFF_COMPRATAMANO_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRFF_COMPRATAMANO_Internalname, "RFF_COMPRATAMANO", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 119,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRFF_COMPRATAMANO_Internalname, A249RFF_COMPRATAMANO, StringUtil.RTrim( context.localUtil.Format( A249RFF_COMPRATAMANO, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,119);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRFF_COMPRATAMANO_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRFF_COMPRATAMANO_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_RFF_COMPRADA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRFF_COMPRAHAS_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRFF_COMPRAHAS_Internalname, "RFF_COMPRAHAS", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 124,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRFF_COMPRAHAS_Internalname, StringUtil.LTrim( StringUtil.NToC( A250RFF_COMPRAHAS, 16, 2, ",", "")), StringUtil.LTrim( ((edtRFF_COMPRAHAS_Enabled!=0) ? context.localUtil.Format( A250RFF_COMPRAHAS, "ZZZZZZZZZZZZ9.99") : context.localUtil.Format( A250RFF_COMPRAHAS, "ZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,124);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRFF_COMPRAHAS_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRFF_COMPRAHAS_Enabled, 0, "text", "", 16, "chr", 1, "row", 16, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_RFF_COMPRADA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRFF_COMPRADISTAKM_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRFF_COMPRADISTAKM_Internalname, "RFF_COMPRADISTAKM", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 129,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRFF_COMPRADISTAKM_Internalname, StringUtil.LTrim( StringUtil.NToC( A251RFF_COMPRADISTAKM, 10, 2, ",", "")), StringUtil.LTrim( ((edtRFF_COMPRADISTAKM_Enabled!=0) ? context.localUtil.Format( A251RFF_COMPRADISTAKM, "ZZZZZZ9.99") : context.localUtil.Format( A251RFF_COMPRADISTAKM, "ZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,129);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRFF_COMPRADISTAKM_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRFF_COMPRADISTAKM_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_RFF_COMPRADA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRFF_COMPRARANDISTAN_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRFF_COMPRARANDISTAN_Internalname, "RFF_COMPRARANDISTAN", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 134,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRFF_COMPRARANDISTAN_Internalname, A252RFF_COMPRARANDISTAN, StringUtil.RTrim( context.localUtil.Format( A252RFF_COMPRARANDISTAN, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,134);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRFF_COMPRARANDISTAN_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRFF_COMPRARANDISTAN_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_RFF_COMPRADA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRFF_COMPRAIDACOMPANAM_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRFF_COMPRAIDACOMPANAM_Internalname, "RFF_COMPRAIDACOMPANAM", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 139,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRFF_COMPRAIDACOMPANAM_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A253RFF_COMPRAIDACOMPANAM), 15, 0, ",", "")), StringUtil.LTrim( ((edtRFF_COMPRAIDACOMPANAM_Enabled!=0) ? context.localUtil.Format( (decimal)(A253RFF_COMPRAIDACOMPANAM), "ZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A253RFF_COMPRAIDACOMPANAM), "ZZZZZZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,139);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRFF_COMPRAIDACOMPANAM_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRFF_COMPRAIDACOMPANAM_Enabled, 0, "text", "1", 15, "chr", 1, "row", 15, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_RFF_COMPRADA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRFF_COMPRAACOMPANANOM_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRFF_COMPRAACOMPANANOM_Internalname, "RFF_COMPRAACOMPANANOM", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 144,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtRFF_COMPRAACOMPANANOM_Internalname, A254RFF_COMPRAACOMPANANOM, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,144);\"", 0, 1, edtRFF_COMPRAACOMPANANOM_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_RFF_COMPRADA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRFF_COMPRARSPO_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRFF_COMPRARSPO_Internalname, "RFF_COMPRARSPO", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 149,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRFF_COMPRARSPO_Internalname, A255RFF_COMPRARSPO, StringUtil.RTrim( context.localUtil.Format( A255RFF_COMPRARSPO, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,149);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRFF_COMPRARSPO_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRFF_COMPRARSPO_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_RFF_COMPRADA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRFF_COMPRANATURALEZA_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRFF_COMPRANATURALEZA_Internalname, "RFF_COMPRANATURALEZA", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 154,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRFF_COMPRANATURALEZA_Internalname, A256RFF_COMPRANATURALEZA, StringUtil.RTrim( context.localUtil.Format( A256RFF_COMPRANATURALEZA, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,154);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRFF_COMPRANATURALEZA_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRFF_COMPRANATURALEZA_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_RFF_COMPRADA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRFF_COMPRACOORDX_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRFF_COMPRACOORDX_Internalname, "RFF_COMPRACOORDX", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 159,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRFF_COMPRACOORDX_Internalname, A257RFF_COMPRACOORDX, StringUtil.RTrim( context.localUtil.Format( A257RFF_COMPRACOORDX, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,159);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRFF_COMPRACOORDX_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRFF_COMPRACOORDX_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_RFF_COMPRADA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRFF_COMPRACOORDY_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRFF_COMPRACOORDY_Internalname, "RFF_COMPRACOORDY", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 164,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRFF_COMPRACOORDY_Internalname, A258RFF_COMPRACOORDY, StringUtil.RTrim( context.localUtil.Format( A258RFF_COMPRACOORDY, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,164);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRFF_COMPRACOORDY_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRFF_COMPRACOORDY_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_RFF_COMPRADA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRFF_COMPRAEDADRANGO_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRFF_COMPRAEDADRANGO_Internalname, "RFF_COMPRAEDADRANGO", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 169,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRFF_COMPRAEDADRANGO_Internalname, A259RFF_COMPRAEDADRANGO, StringUtil.RTrim( context.localUtil.Format( A259RFF_COMPRAEDADRANGO, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,169);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRFF_COMPRAEDADRANGO_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRFF_COMPRAEDADRANGO_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_RFF_COMPRADA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRFF_COMPRAMATERIAL_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRFF_COMPRAMATERIAL_Internalname, "RFF_COMPRAMATERIAL", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 174,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRFF_COMPRAMATERIAL_Internalname, A260RFF_COMPRAMATERIAL, StringUtil.RTrim( context.localUtil.Format( A260RFF_COMPRAMATERIAL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,174);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRFF_COMPRAMATERIAL_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRFF_COMPRAMATERIAL_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_RFF_COMPRADA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRFF_COMPRACOMITE_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRFF_COMPRACOMITE_Internalname, "RFF_COMPRACOMITE", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 179,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtRFF_COMPRACOMITE_Internalname, A261RFF_COMPRACOMITE, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,179);\"", 0, 1, edtRFF_COMPRACOMITE_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_RFF_COMPRADA.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 184,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_RFF_COMPRADA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 186,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_RFF_COMPRADA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 188,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_RFF_COMPRADA.htm");
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
            Z86RFF_COMPRADAFecha = context.localUtil.CToD( cgiGet( "Z86RFF_COMPRADAFecha"), 0);
            Z5Cod_Area = cgiGet( "Z5Cod_Area");
            Z4IndicadoresCodigo = cgiGet( "Z4IndicadoresCodigo");
            Z87RFF_COMPRADAMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z87RFF_COMPRADAMes"), ",", "."), 18, MidpointRounding.ToEven));
            Z88RFF_COMPRADAAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z88RFF_COMPRADAAno"), ",", "."), 18, MidpointRounding.ToEven));
            Z89RFF_COMPRAPRODUCUP = cgiGet( "Z89RFF_COMPRAPRODUCUP");
            Z238RFF_COMPRATON = context.localUtil.CToN( cgiGet( "Z238RFF_COMPRATON"), ",", ".");
            n238RFF_COMPRATON = ((Convert.ToDecimal(0)==A238RFF_COMPRATON) ? true : false);
            Z239RFF_COMPRAPROVEE = cgiGet( "Z239RFF_COMPRAPROVEE");
            n239RFF_COMPRAPROVEE = (String.IsNullOrEmpty(StringUtil.RTrim( A239RFF_COMPRAPROVEE)) ? true : false);
            Z240RFF_COMPRAFINCA = cgiGet( "Z240RFF_COMPRAFINCA");
            n240RFF_COMPRAFINCA = (String.IsNullOrEmpty(StringUtil.RTrim( A240RFF_COMPRAFINCA)) ? true : false);
            Z241RFF_COMPRAZONA = cgiGet( "Z241RFF_COMPRAZONA");
            n241RFF_COMPRAZONA = (String.IsNullOrEmpty(StringUtil.RTrim( A241RFF_COMPRAZONA)) ? true : false);
            Z242RFF_COMPRAVEREDAID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z242RFF_COMPRAVEREDAID"), ",", "."), 18, MidpointRounding.ToEven));
            n242RFF_COMPRAVEREDAID = ((0==A242RFF_COMPRAVEREDAID) ? true : false);
            Z243RFF_COMPRAVEREDANOM = cgiGet( "Z243RFF_COMPRAVEREDANOM");
            n243RFF_COMPRAVEREDANOM = (String.IsNullOrEmpty(StringUtil.RTrim( A243RFF_COMPRAVEREDANOM)) ? true : false);
            Z244RFF_COMPRAMUNIID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z244RFF_COMPRAMUNIID"), ",", "."), 18, MidpointRounding.ToEven));
            n244RFF_COMPRAMUNIID = ((0==A244RFF_COMPRAMUNIID) ? true : false);
            Z245RFF_COMPRAMUNINOM = cgiGet( "Z245RFF_COMPRAMUNINOM");
            n245RFF_COMPRAMUNINOM = (String.IsNullOrEmpty(StringUtil.RTrim( A245RFF_COMPRAMUNINOM)) ? true : false);
            Z246RFF_COMPRADEPTOID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z246RFF_COMPRADEPTOID"), ",", "."), 18, MidpointRounding.ToEven));
            n246RFF_COMPRADEPTOID = ((0==A246RFF_COMPRADEPTOID) ? true : false);
            Z247RFF_COMPRADEPTONOM = cgiGet( "Z247RFF_COMPRADEPTONOM");
            n247RFF_COMPRADEPTONOM = (String.IsNullOrEmpty(StringUtil.RTrim( A247RFF_COMPRADEPTONOM)) ? true : false);
            Z248RFF_COMPRACLASIFIC = cgiGet( "Z248RFF_COMPRACLASIFIC");
            n248RFF_COMPRACLASIFIC = (String.IsNullOrEmpty(StringUtil.RTrim( A248RFF_COMPRACLASIFIC)) ? true : false);
            Z249RFF_COMPRATAMANO = cgiGet( "Z249RFF_COMPRATAMANO");
            n249RFF_COMPRATAMANO = (String.IsNullOrEmpty(StringUtil.RTrim( A249RFF_COMPRATAMANO)) ? true : false);
            Z250RFF_COMPRAHAS = context.localUtil.CToN( cgiGet( "Z250RFF_COMPRAHAS"), ",", ".");
            n250RFF_COMPRAHAS = ((Convert.ToDecimal(0)==A250RFF_COMPRAHAS) ? true : false);
            Z251RFF_COMPRADISTAKM = context.localUtil.CToN( cgiGet( "Z251RFF_COMPRADISTAKM"), ",", ".");
            n251RFF_COMPRADISTAKM = ((Convert.ToDecimal(0)==A251RFF_COMPRADISTAKM) ? true : false);
            Z252RFF_COMPRARANDISTAN = cgiGet( "Z252RFF_COMPRARANDISTAN");
            n252RFF_COMPRARANDISTAN = (String.IsNullOrEmpty(StringUtil.RTrim( A252RFF_COMPRARANDISTAN)) ? true : false);
            Z253RFF_COMPRAIDACOMPANAM = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z253RFF_COMPRAIDACOMPANAM"), ",", "."), 18, MidpointRounding.ToEven));
            n253RFF_COMPRAIDACOMPANAM = ((0==A253RFF_COMPRAIDACOMPANAM) ? true : false);
            Z254RFF_COMPRAACOMPANANOM = cgiGet( "Z254RFF_COMPRAACOMPANANOM");
            n254RFF_COMPRAACOMPANANOM = (String.IsNullOrEmpty(StringUtil.RTrim( A254RFF_COMPRAACOMPANANOM)) ? true : false);
            Z255RFF_COMPRARSPO = cgiGet( "Z255RFF_COMPRARSPO");
            n255RFF_COMPRARSPO = (String.IsNullOrEmpty(StringUtil.RTrim( A255RFF_COMPRARSPO)) ? true : false);
            Z256RFF_COMPRANATURALEZA = cgiGet( "Z256RFF_COMPRANATURALEZA");
            n256RFF_COMPRANATURALEZA = (String.IsNullOrEmpty(StringUtil.RTrim( A256RFF_COMPRANATURALEZA)) ? true : false);
            Z257RFF_COMPRACOORDX = cgiGet( "Z257RFF_COMPRACOORDX");
            n257RFF_COMPRACOORDX = (String.IsNullOrEmpty(StringUtil.RTrim( A257RFF_COMPRACOORDX)) ? true : false);
            Z258RFF_COMPRACOORDY = cgiGet( "Z258RFF_COMPRACOORDY");
            n258RFF_COMPRACOORDY = (String.IsNullOrEmpty(StringUtil.RTrim( A258RFF_COMPRACOORDY)) ? true : false);
            Z259RFF_COMPRAEDADRANGO = cgiGet( "Z259RFF_COMPRAEDADRANGO");
            n259RFF_COMPRAEDADRANGO = (String.IsNullOrEmpty(StringUtil.RTrim( A259RFF_COMPRAEDADRANGO)) ? true : false);
            Z260RFF_COMPRAMATERIAL = cgiGet( "Z260RFF_COMPRAMATERIAL");
            n260RFF_COMPRAMATERIAL = (String.IsNullOrEmpty(StringUtil.RTrim( A260RFF_COMPRAMATERIAL)) ? true : false);
            Z261RFF_COMPRACOMITE = cgiGet( "Z261RFF_COMPRACOMITE");
            n261RFF_COMPRACOMITE = (String.IsNullOrEmpty(StringUtil.RTrim( A261RFF_COMPRACOMITE)) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( context.localUtil.VCDate( cgiGet( edtRFF_COMPRADAFecha_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"RFF_COMPRADAFecha"}), 1, "RFF_COMPRADAFECHA");
               AnyError = 1;
               GX_FocusControl = edtRFF_COMPRADAFecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A86RFF_COMPRADAFecha = DateTime.MinValue;
               AssignAttri("", false, "A86RFF_COMPRADAFecha", context.localUtil.Format(A86RFF_COMPRADAFecha, "99/99/99"));
            }
            else
            {
               A86RFF_COMPRADAFecha = context.localUtil.CToD( cgiGet( edtRFF_COMPRADAFecha_Internalname), 2);
               AssignAttri("", false, "A86RFF_COMPRADAFecha", context.localUtil.Format(A86RFF_COMPRADAFecha, "99/99/99"));
            }
            A5Cod_Area = cgiGet( edtCod_Area_Internalname);
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = cgiGet( edtIndicadoresCodigo_Internalname);
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            if ( ( ( context.localUtil.CToN( cgiGet( edtRFF_COMPRADAMes_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRFF_COMPRADAMes_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "RFF_COMPRADAMES");
               AnyError = 1;
               GX_FocusControl = edtRFF_COMPRADAMes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A87RFF_COMPRADAMes = 0;
               AssignAttri("", false, "A87RFF_COMPRADAMes", StringUtil.LTrimStr( (decimal)(A87RFF_COMPRADAMes), 4, 0));
            }
            else
            {
               A87RFF_COMPRADAMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtRFF_COMPRADAMes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A87RFF_COMPRADAMes", StringUtil.LTrimStr( (decimal)(A87RFF_COMPRADAMes), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtRFF_COMPRADAAno_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRFF_COMPRADAAno_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "RFF_COMPRADAANO");
               AnyError = 1;
               GX_FocusControl = edtRFF_COMPRADAAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A88RFF_COMPRADAAno = 0;
               AssignAttri("", false, "A88RFF_COMPRADAAno", StringUtil.LTrimStr( (decimal)(A88RFF_COMPRADAAno), 4, 0));
            }
            else
            {
               A88RFF_COMPRADAAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtRFF_COMPRADAAno_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A88RFF_COMPRADAAno", StringUtil.LTrimStr( (decimal)(A88RFF_COMPRADAAno), 4, 0));
            }
            A89RFF_COMPRAPRODUCUP = cgiGet( edtRFF_COMPRAPRODUCUP_Internalname);
            AssignAttri("", false, "A89RFF_COMPRAPRODUCUP", A89RFF_COMPRAPRODUCUP);
            if ( ( ( context.localUtil.CToN( cgiGet( edtRFF_COMPRATON_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRFF_COMPRATON_Internalname), ",", ".") > 999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "RFF_COMPRATON");
               AnyError = 1;
               GX_FocusControl = edtRFF_COMPRATON_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A238RFF_COMPRATON = 0;
               n238RFF_COMPRATON = false;
               AssignAttri("", false, "A238RFF_COMPRATON", StringUtil.LTrimStr( A238RFF_COMPRATON, 12, 2));
            }
            else
            {
               A238RFF_COMPRATON = context.localUtil.CToN( cgiGet( edtRFF_COMPRATON_Internalname), ",", ".");
               n238RFF_COMPRATON = false;
               AssignAttri("", false, "A238RFF_COMPRATON", StringUtil.LTrimStr( A238RFF_COMPRATON, 12, 2));
            }
            n238RFF_COMPRATON = ((Convert.ToDecimal(0)==A238RFF_COMPRATON) ? true : false);
            A239RFF_COMPRAPROVEE = cgiGet( edtRFF_COMPRAPROVEE_Internalname);
            n239RFF_COMPRAPROVEE = false;
            AssignAttri("", false, "A239RFF_COMPRAPROVEE", A239RFF_COMPRAPROVEE);
            n239RFF_COMPRAPROVEE = (String.IsNullOrEmpty(StringUtil.RTrim( A239RFF_COMPRAPROVEE)) ? true : false);
            A240RFF_COMPRAFINCA = cgiGet( edtRFF_COMPRAFINCA_Internalname);
            n240RFF_COMPRAFINCA = false;
            AssignAttri("", false, "A240RFF_COMPRAFINCA", A240RFF_COMPRAFINCA);
            n240RFF_COMPRAFINCA = (String.IsNullOrEmpty(StringUtil.RTrim( A240RFF_COMPRAFINCA)) ? true : false);
            A241RFF_COMPRAZONA = cgiGet( edtRFF_COMPRAZONA_Internalname);
            n241RFF_COMPRAZONA = false;
            AssignAttri("", false, "A241RFF_COMPRAZONA", A241RFF_COMPRAZONA);
            n241RFF_COMPRAZONA = (String.IsNullOrEmpty(StringUtil.RTrim( A241RFF_COMPRAZONA)) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtRFF_COMPRAVEREDAID_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRFF_COMPRAVEREDAID_Internalname), ",", ".") > Convert.ToDecimal( 999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "RFF_COMPRAVEREDAID");
               AnyError = 1;
               GX_FocusControl = edtRFF_COMPRAVEREDAID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A242RFF_COMPRAVEREDAID = 0;
               n242RFF_COMPRAVEREDAID = false;
               AssignAttri("", false, "A242RFF_COMPRAVEREDAID", StringUtil.LTrimStr( (decimal)(A242RFF_COMPRAVEREDAID), 15, 0));
            }
            else
            {
               A242RFF_COMPRAVEREDAID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtRFF_COMPRAVEREDAID_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n242RFF_COMPRAVEREDAID = false;
               AssignAttri("", false, "A242RFF_COMPRAVEREDAID", StringUtil.LTrimStr( (decimal)(A242RFF_COMPRAVEREDAID), 15, 0));
            }
            n242RFF_COMPRAVEREDAID = ((0==A242RFF_COMPRAVEREDAID) ? true : false);
            A243RFF_COMPRAVEREDANOM = cgiGet( edtRFF_COMPRAVEREDANOM_Internalname);
            n243RFF_COMPRAVEREDANOM = false;
            AssignAttri("", false, "A243RFF_COMPRAVEREDANOM", A243RFF_COMPRAVEREDANOM);
            n243RFF_COMPRAVEREDANOM = (String.IsNullOrEmpty(StringUtil.RTrim( A243RFF_COMPRAVEREDANOM)) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtRFF_COMPRAMUNIID_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRFF_COMPRAMUNIID_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "RFF_COMPRAMUNIID");
               AnyError = 1;
               GX_FocusControl = edtRFF_COMPRAMUNIID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A244RFF_COMPRAMUNIID = 0;
               n244RFF_COMPRAMUNIID = false;
               AssignAttri("", false, "A244RFF_COMPRAMUNIID", StringUtil.LTrimStr( (decimal)(A244RFF_COMPRAMUNIID), 10, 0));
            }
            else
            {
               A244RFF_COMPRAMUNIID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtRFF_COMPRAMUNIID_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n244RFF_COMPRAMUNIID = false;
               AssignAttri("", false, "A244RFF_COMPRAMUNIID", StringUtil.LTrimStr( (decimal)(A244RFF_COMPRAMUNIID), 10, 0));
            }
            n244RFF_COMPRAMUNIID = ((0==A244RFF_COMPRAMUNIID) ? true : false);
            A245RFF_COMPRAMUNINOM = cgiGet( edtRFF_COMPRAMUNINOM_Internalname);
            n245RFF_COMPRAMUNINOM = false;
            AssignAttri("", false, "A245RFF_COMPRAMUNINOM", A245RFF_COMPRAMUNINOM);
            n245RFF_COMPRAMUNINOM = (String.IsNullOrEmpty(StringUtil.RTrim( A245RFF_COMPRAMUNINOM)) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtRFF_COMPRADEPTOID_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRFF_COMPRADEPTOID_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "RFF_COMPRADEPTOID");
               AnyError = 1;
               GX_FocusControl = edtRFF_COMPRADEPTOID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A246RFF_COMPRADEPTOID = 0;
               n246RFF_COMPRADEPTOID = false;
               AssignAttri("", false, "A246RFF_COMPRADEPTOID", StringUtil.LTrimStr( (decimal)(A246RFF_COMPRADEPTOID), 10, 0));
            }
            else
            {
               A246RFF_COMPRADEPTOID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtRFF_COMPRADEPTOID_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n246RFF_COMPRADEPTOID = false;
               AssignAttri("", false, "A246RFF_COMPRADEPTOID", StringUtil.LTrimStr( (decimal)(A246RFF_COMPRADEPTOID), 10, 0));
            }
            n246RFF_COMPRADEPTOID = ((0==A246RFF_COMPRADEPTOID) ? true : false);
            A247RFF_COMPRADEPTONOM = cgiGet( edtRFF_COMPRADEPTONOM_Internalname);
            n247RFF_COMPRADEPTONOM = false;
            AssignAttri("", false, "A247RFF_COMPRADEPTONOM", A247RFF_COMPRADEPTONOM);
            n247RFF_COMPRADEPTONOM = (String.IsNullOrEmpty(StringUtil.RTrim( A247RFF_COMPRADEPTONOM)) ? true : false);
            A248RFF_COMPRACLASIFIC = cgiGet( edtRFF_COMPRACLASIFIC_Internalname);
            n248RFF_COMPRACLASIFIC = false;
            AssignAttri("", false, "A248RFF_COMPRACLASIFIC", A248RFF_COMPRACLASIFIC);
            n248RFF_COMPRACLASIFIC = (String.IsNullOrEmpty(StringUtil.RTrim( A248RFF_COMPRACLASIFIC)) ? true : false);
            A249RFF_COMPRATAMANO = cgiGet( edtRFF_COMPRATAMANO_Internalname);
            n249RFF_COMPRATAMANO = false;
            AssignAttri("", false, "A249RFF_COMPRATAMANO", A249RFF_COMPRATAMANO);
            n249RFF_COMPRATAMANO = (String.IsNullOrEmpty(StringUtil.RTrim( A249RFF_COMPRATAMANO)) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtRFF_COMPRAHAS_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRFF_COMPRAHAS_Internalname), ",", ".") > 9999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "RFF_COMPRAHAS");
               AnyError = 1;
               GX_FocusControl = edtRFF_COMPRAHAS_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A250RFF_COMPRAHAS = 0;
               n250RFF_COMPRAHAS = false;
               AssignAttri("", false, "A250RFF_COMPRAHAS", StringUtil.LTrimStr( A250RFF_COMPRAHAS, 16, 2));
            }
            else
            {
               A250RFF_COMPRAHAS = context.localUtil.CToN( cgiGet( edtRFF_COMPRAHAS_Internalname), ",", ".");
               n250RFF_COMPRAHAS = false;
               AssignAttri("", false, "A250RFF_COMPRAHAS", StringUtil.LTrimStr( A250RFF_COMPRAHAS, 16, 2));
            }
            n250RFF_COMPRAHAS = ((Convert.ToDecimal(0)==A250RFF_COMPRAHAS) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtRFF_COMPRADISTAKM_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRFF_COMPRADISTAKM_Internalname), ",", ".") > 9999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "RFF_COMPRADISTAKM");
               AnyError = 1;
               GX_FocusControl = edtRFF_COMPRADISTAKM_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A251RFF_COMPRADISTAKM = 0;
               n251RFF_COMPRADISTAKM = false;
               AssignAttri("", false, "A251RFF_COMPRADISTAKM", StringUtil.LTrimStr( A251RFF_COMPRADISTAKM, 10, 2));
            }
            else
            {
               A251RFF_COMPRADISTAKM = context.localUtil.CToN( cgiGet( edtRFF_COMPRADISTAKM_Internalname), ",", ".");
               n251RFF_COMPRADISTAKM = false;
               AssignAttri("", false, "A251RFF_COMPRADISTAKM", StringUtil.LTrimStr( A251RFF_COMPRADISTAKM, 10, 2));
            }
            n251RFF_COMPRADISTAKM = ((Convert.ToDecimal(0)==A251RFF_COMPRADISTAKM) ? true : false);
            A252RFF_COMPRARANDISTAN = cgiGet( edtRFF_COMPRARANDISTAN_Internalname);
            n252RFF_COMPRARANDISTAN = false;
            AssignAttri("", false, "A252RFF_COMPRARANDISTAN", A252RFF_COMPRARANDISTAN);
            n252RFF_COMPRARANDISTAN = (String.IsNullOrEmpty(StringUtil.RTrim( A252RFF_COMPRARANDISTAN)) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtRFF_COMPRAIDACOMPANAM_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRFF_COMPRAIDACOMPANAM_Internalname), ",", ".") > Convert.ToDecimal( 999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "RFF_COMPRAIDACOMPANAM");
               AnyError = 1;
               GX_FocusControl = edtRFF_COMPRAIDACOMPANAM_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A253RFF_COMPRAIDACOMPANAM = 0;
               n253RFF_COMPRAIDACOMPANAM = false;
               AssignAttri("", false, "A253RFF_COMPRAIDACOMPANAM", StringUtil.LTrimStr( (decimal)(A253RFF_COMPRAIDACOMPANAM), 15, 0));
            }
            else
            {
               A253RFF_COMPRAIDACOMPANAM = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtRFF_COMPRAIDACOMPANAM_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n253RFF_COMPRAIDACOMPANAM = false;
               AssignAttri("", false, "A253RFF_COMPRAIDACOMPANAM", StringUtil.LTrimStr( (decimal)(A253RFF_COMPRAIDACOMPANAM), 15, 0));
            }
            n253RFF_COMPRAIDACOMPANAM = ((0==A253RFF_COMPRAIDACOMPANAM) ? true : false);
            A254RFF_COMPRAACOMPANANOM = cgiGet( edtRFF_COMPRAACOMPANANOM_Internalname);
            n254RFF_COMPRAACOMPANANOM = false;
            AssignAttri("", false, "A254RFF_COMPRAACOMPANANOM", A254RFF_COMPRAACOMPANANOM);
            n254RFF_COMPRAACOMPANANOM = (String.IsNullOrEmpty(StringUtil.RTrim( A254RFF_COMPRAACOMPANANOM)) ? true : false);
            A255RFF_COMPRARSPO = cgiGet( edtRFF_COMPRARSPO_Internalname);
            n255RFF_COMPRARSPO = false;
            AssignAttri("", false, "A255RFF_COMPRARSPO", A255RFF_COMPRARSPO);
            n255RFF_COMPRARSPO = (String.IsNullOrEmpty(StringUtil.RTrim( A255RFF_COMPRARSPO)) ? true : false);
            A256RFF_COMPRANATURALEZA = cgiGet( edtRFF_COMPRANATURALEZA_Internalname);
            n256RFF_COMPRANATURALEZA = false;
            AssignAttri("", false, "A256RFF_COMPRANATURALEZA", A256RFF_COMPRANATURALEZA);
            n256RFF_COMPRANATURALEZA = (String.IsNullOrEmpty(StringUtil.RTrim( A256RFF_COMPRANATURALEZA)) ? true : false);
            A257RFF_COMPRACOORDX = cgiGet( edtRFF_COMPRACOORDX_Internalname);
            n257RFF_COMPRACOORDX = false;
            AssignAttri("", false, "A257RFF_COMPRACOORDX", A257RFF_COMPRACOORDX);
            n257RFF_COMPRACOORDX = (String.IsNullOrEmpty(StringUtil.RTrim( A257RFF_COMPRACOORDX)) ? true : false);
            A258RFF_COMPRACOORDY = cgiGet( edtRFF_COMPRACOORDY_Internalname);
            n258RFF_COMPRACOORDY = false;
            AssignAttri("", false, "A258RFF_COMPRACOORDY", A258RFF_COMPRACOORDY);
            n258RFF_COMPRACOORDY = (String.IsNullOrEmpty(StringUtil.RTrim( A258RFF_COMPRACOORDY)) ? true : false);
            A259RFF_COMPRAEDADRANGO = cgiGet( edtRFF_COMPRAEDADRANGO_Internalname);
            n259RFF_COMPRAEDADRANGO = false;
            AssignAttri("", false, "A259RFF_COMPRAEDADRANGO", A259RFF_COMPRAEDADRANGO);
            n259RFF_COMPRAEDADRANGO = (String.IsNullOrEmpty(StringUtil.RTrim( A259RFF_COMPRAEDADRANGO)) ? true : false);
            A260RFF_COMPRAMATERIAL = cgiGet( edtRFF_COMPRAMATERIAL_Internalname);
            n260RFF_COMPRAMATERIAL = false;
            AssignAttri("", false, "A260RFF_COMPRAMATERIAL", A260RFF_COMPRAMATERIAL);
            n260RFF_COMPRAMATERIAL = (String.IsNullOrEmpty(StringUtil.RTrim( A260RFF_COMPRAMATERIAL)) ? true : false);
            A261RFF_COMPRACOMITE = cgiGet( edtRFF_COMPRACOMITE_Internalname);
            n261RFF_COMPRACOMITE = false;
            AssignAttri("", false, "A261RFF_COMPRACOMITE", A261RFF_COMPRACOMITE);
            n261RFF_COMPRACOMITE = (String.IsNullOrEmpty(StringUtil.RTrim( A261RFF_COMPRACOMITE)) ? true : false);
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
               A86RFF_COMPRADAFecha = context.localUtil.ParseDateParm( GetPar( "RFF_COMPRADAFecha"));
               AssignAttri("", false, "A86RFF_COMPRADAFecha", context.localUtil.Format(A86RFF_COMPRADAFecha, "99/99/99"));
               A5Cod_Area = GetPar( "Cod_Area");
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               A4IndicadoresCodigo = GetPar( "IndicadoresCodigo");
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               A87RFF_COMPRADAMes = (short)(Math.Round(NumberUtil.Val( GetPar( "RFF_COMPRADAMes"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A87RFF_COMPRADAMes", StringUtil.LTrimStr( (decimal)(A87RFF_COMPRADAMes), 4, 0));
               A88RFF_COMPRADAAno = (short)(Math.Round(NumberUtil.Val( GetPar( "RFF_COMPRADAAno"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A88RFF_COMPRADAAno", StringUtil.LTrimStr( (decimal)(A88RFF_COMPRADAAno), 4, 0));
               A89RFF_COMPRAPRODUCUP = GetPar( "RFF_COMPRAPRODUCUP");
               AssignAttri("", false, "A89RFF_COMPRAPRODUCUP", A89RFF_COMPRAPRODUCUP);
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
               InitAll1542( ) ;
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
         DisableAttributes1542( ) ;
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

      protected void ResetCaption150( )
      {
      }

      protected void ZM1542( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z238RFF_COMPRATON = T00153_A238RFF_COMPRATON[0];
               Z239RFF_COMPRAPROVEE = T00153_A239RFF_COMPRAPROVEE[0];
               Z240RFF_COMPRAFINCA = T00153_A240RFF_COMPRAFINCA[0];
               Z241RFF_COMPRAZONA = T00153_A241RFF_COMPRAZONA[0];
               Z242RFF_COMPRAVEREDAID = T00153_A242RFF_COMPRAVEREDAID[0];
               Z243RFF_COMPRAVEREDANOM = T00153_A243RFF_COMPRAVEREDANOM[0];
               Z244RFF_COMPRAMUNIID = T00153_A244RFF_COMPRAMUNIID[0];
               Z245RFF_COMPRAMUNINOM = T00153_A245RFF_COMPRAMUNINOM[0];
               Z246RFF_COMPRADEPTOID = T00153_A246RFF_COMPRADEPTOID[0];
               Z247RFF_COMPRADEPTONOM = T00153_A247RFF_COMPRADEPTONOM[0];
               Z248RFF_COMPRACLASIFIC = T00153_A248RFF_COMPRACLASIFIC[0];
               Z249RFF_COMPRATAMANO = T00153_A249RFF_COMPRATAMANO[0];
               Z250RFF_COMPRAHAS = T00153_A250RFF_COMPRAHAS[0];
               Z251RFF_COMPRADISTAKM = T00153_A251RFF_COMPRADISTAKM[0];
               Z252RFF_COMPRARANDISTAN = T00153_A252RFF_COMPRARANDISTAN[0];
               Z253RFF_COMPRAIDACOMPANAM = T00153_A253RFF_COMPRAIDACOMPANAM[0];
               Z254RFF_COMPRAACOMPANANOM = T00153_A254RFF_COMPRAACOMPANANOM[0];
               Z255RFF_COMPRARSPO = T00153_A255RFF_COMPRARSPO[0];
               Z256RFF_COMPRANATURALEZA = T00153_A256RFF_COMPRANATURALEZA[0];
               Z257RFF_COMPRACOORDX = T00153_A257RFF_COMPRACOORDX[0];
               Z258RFF_COMPRACOORDY = T00153_A258RFF_COMPRACOORDY[0];
               Z259RFF_COMPRAEDADRANGO = T00153_A259RFF_COMPRAEDADRANGO[0];
               Z260RFF_COMPRAMATERIAL = T00153_A260RFF_COMPRAMATERIAL[0];
               Z261RFF_COMPRACOMITE = T00153_A261RFF_COMPRACOMITE[0];
            }
            else
            {
               Z238RFF_COMPRATON = A238RFF_COMPRATON;
               Z239RFF_COMPRAPROVEE = A239RFF_COMPRAPROVEE;
               Z240RFF_COMPRAFINCA = A240RFF_COMPRAFINCA;
               Z241RFF_COMPRAZONA = A241RFF_COMPRAZONA;
               Z242RFF_COMPRAVEREDAID = A242RFF_COMPRAVEREDAID;
               Z243RFF_COMPRAVEREDANOM = A243RFF_COMPRAVEREDANOM;
               Z244RFF_COMPRAMUNIID = A244RFF_COMPRAMUNIID;
               Z245RFF_COMPRAMUNINOM = A245RFF_COMPRAMUNINOM;
               Z246RFF_COMPRADEPTOID = A246RFF_COMPRADEPTOID;
               Z247RFF_COMPRADEPTONOM = A247RFF_COMPRADEPTONOM;
               Z248RFF_COMPRACLASIFIC = A248RFF_COMPRACLASIFIC;
               Z249RFF_COMPRATAMANO = A249RFF_COMPRATAMANO;
               Z250RFF_COMPRAHAS = A250RFF_COMPRAHAS;
               Z251RFF_COMPRADISTAKM = A251RFF_COMPRADISTAKM;
               Z252RFF_COMPRARANDISTAN = A252RFF_COMPRARANDISTAN;
               Z253RFF_COMPRAIDACOMPANAM = A253RFF_COMPRAIDACOMPANAM;
               Z254RFF_COMPRAACOMPANANOM = A254RFF_COMPRAACOMPANANOM;
               Z255RFF_COMPRARSPO = A255RFF_COMPRARSPO;
               Z256RFF_COMPRANATURALEZA = A256RFF_COMPRANATURALEZA;
               Z257RFF_COMPRACOORDX = A257RFF_COMPRACOORDX;
               Z258RFF_COMPRACOORDY = A258RFF_COMPRACOORDY;
               Z259RFF_COMPRAEDADRANGO = A259RFF_COMPRAEDADRANGO;
               Z260RFF_COMPRAMATERIAL = A260RFF_COMPRAMATERIAL;
               Z261RFF_COMPRACOMITE = A261RFF_COMPRACOMITE;
            }
         }
         if ( GX_JID == -2 )
         {
            Z86RFF_COMPRADAFecha = A86RFF_COMPRADAFecha;
            Z87RFF_COMPRADAMes = A87RFF_COMPRADAMes;
            Z88RFF_COMPRADAAno = A88RFF_COMPRADAAno;
            Z89RFF_COMPRAPRODUCUP = A89RFF_COMPRAPRODUCUP;
            Z238RFF_COMPRATON = A238RFF_COMPRATON;
            Z239RFF_COMPRAPROVEE = A239RFF_COMPRAPROVEE;
            Z240RFF_COMPRAFINCA = A240RFF_COMPRAFINCA;
            Z241RFF_COMPRAZONA = A241RFF_COMPRAZONA;
            Z242RFF_COMPRAVEREDAID = A242RFF_COMPRAVEREDAID;
            Z243RFF_COMPRAVEREDANOM = A243RFF_COMPRAVEREDANOM;
            Z244RFF_COMPRAMUNIID = A244RFF_COMPRAMUNIID;
            Z245RFF_COMPRAMUNINOM = A245RFF_COMPRAMUNINOM;
            Z246RFF_COMPRADEPTOID = A246RFF_COMPRADEPTOID;
            Z247RFF_COMPRADEPTONOM = A247RFF_COMPRADEPTONOM;
            Z248RFF_COMPRACLASIFIC = A248RFF_COMPRACLASIFIC;
            Z249RFF_COMPRATAMANO = A249RFF_COMPRATAMANO;
            Z250RFF_COMPRAHAS = A250RFF_COMPRAHAS;
            Z251RFF_COMPRADISTAKM = A251RFF_COMPRADISTAKM;
            Z252RFF_COMPRARANDISTAN = A252RFF_COMPRARANDISTAN;
            Z253RFF_COMPRAIDACOMPANAM = A253RFF_COMPRAIDACOMPANAM;
            Z254RFF_COMPRAACOMPANANOM = A254RFF_COMPRAACOMPANANOM;
            Z255RFF_COMPRARSPO = A255RFF_COMPRARSPO;
            Z256RFF_COMPRANATURALEZA = A256RFF_COMPRANATURALEZA;
            Z257RFF_COMPRACOORDX = A257RFF_COMPRACOORDX;
            Z258RFF_COMPRACOORDY = A258RFF_COMPRACOORDY;
            Z259RFF_COMPRAEDADRANGO = A259RFF_COMPRAEDADRANGO;
            Z260RFF_COMPRAMATERIAL = A260RFF_COMPRAMATERIAL;
            Z261RFF_COMPRACOMITE = A261RFF_COMPRACOMITE;
            Z5Cod_Area = A5Cod_Area;
            Z4IndicadoresCodigo = A4IndicadoresCodigo;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_5_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"COD_AREA"+"'), id:'"+"COD_AREA"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"true"+");");
         imgprompt_4_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0030.aspx"+"',["+"{Ctrl:gx.dom.el('"+"INDICADORESCODIGO"+"'), id:'"+"INDICADORESCODIGO"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"true"+");");
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

      protected void Load1542( )
      {
         /* Using cursor T00156 */
         pr_default.execute(4, new Object[] {A86RFF_COMPRADAFecha, A5Cod_Area, A4IndicadoresCodigo, A87RFF_COMPRADAMes, A88RFF_COMPRADAAno, A89RFF_COMPRAPRODUCUP});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound42 = 1;
            A238RFF_COMPRATON = T00156_A238RFF_COMPRATON[0];
            n238RFF_COMPRATON = T00156_n238RFF_COMPRATON[0];
            AssignAttri("", false, "A238RFF_COMPRATON", StringUtil.LTrimStr( A238RFF_COMPRATON, 12, 2));
            A239RFF_COMPRAPROVEE = T00156_A239RFF_COMPRAPROVEE[0];
            n239RFF_COMPRAPROVEE = T00156_n239RFF_COMPRAPROVEE[0];
            AssignAttri("", false, "A239RFF_COMPRAPROVEE", A239RFF_COMPRAPROVEE);
            A240RFF_COMPRAFINCA = T00156_A240RFF_COMPRAFINCA[0];
            n240RFF_COMPRAFINCA = T00156_n240RFF_COMPRAFINCA[0];
            AssignAttri("", false, "A240RFF_COMPRAFINCA", A240RFF_COMPRAFINCA);
            A241RFF_COMPRAZONA = T00156_A241RFF_COMPRAZONA[0];
            n241RFF_COMPRAZONA = T00156_n241RFF_COMPRAZONA[0];
            AssignAttri("", false, "A241RFF_COMPRAZONA", A241RFF_COMPRAZONA);
            A242RFF_COMPRAVEREDAID = T00156_A242RFF_COMPRAVEREDAID[0];
            n242RFF_COMPRAVEREDAID = T00156_n242RFF_COMPRAVEREDAID[0];
            AssignAttri("", false, "A242RFF_COMPRAVEREDAID", StringUtil.LTrimStr( (decimal)(A242RFF_COMPRAVEREDAID), 15, 0));
            A243RFF_COMPRAVEREDANOM = T00156_A243RFF_COMPRAVEREDANOM[0];
            n243RFF_COMPRAVEREDANOM = T00156_n243RFF_COMPRAVEREDANOM[0];
            AssignAttri("", false, "A243RFF_COMPRAVEREDANOM", A243RFF_COMPRAVEREDANOM);
            A244RFF_COMPRAMUNIID = T00156_A244RFF_COMPRAMUNIID[0];
            n244RFF_COMPRAMUNIID = T00156_n244RFF_COMPRAMUNIID[0];
            AssignAttri("", false, "A244RFF_COMPRAMUNIID", StringUtil.LTrimStr( (decimal)(A244RFF_COMPRAMUNIID), 10, 0));
            A245RFF_COMPRAMUNINOM = T00156_A245RFF_COMPRAMUNINOM[0];
            n245RFF_COMPRAMUNINOM = T00156_n245RFF_COMPRAMUNINOM[0];
            AssignAttri("", false, "A245RFF_COMPRAMUNINOM", A245RFF_COMPRAMUNINOM);
            A246RFF_COMPRADEPTOID = T00156_A246RFF_COMPRADEPTOID[0];
            n246RFF_COMPRADEPTOID = T00156_n246RFF_COMPRADEPTOID[0];
            AssignAttri("", false, "A246RFF_COMPRADEPTOID", StringUtil.LTrimStr( (decimal)(A246RFF_COMPRADEPTOID), 10, 0));
            A247RFF_COMPRADEPTONOM = T00156_A247RFF_COMPRADEPTONOM[0];
            n247RFF_COMPRADEPTONOM = T00156_n247RFF_COMPRADEPTONOM[0];
            AssignAttri("", false, "A247RFF_COMPRADEPTONOM", A247RFF_COMPRADEPTONOM);
            A248RFF_COMPRACLASIFIC = T00156_A248RFF_COMPRACLASIFIC[0];
            n248RFF_COMPRACLASIFIC = T00156_n248RFF_COMPRACLASIFIC[0];
            AssignAttri("", false, "A248RFF_COMPRACLASIFIC", A248RFF_COMPRACLASIFIC);
            A249RFF_COMPRATAMANO = T00156_A249RFF_COMPRATAMANO[0];
            n249RFF_COMPRATAMANO = T00156_n249RFF_COMPRATAMANO[0];
            AssignAttri("", false, "A249RFF_COMPRATAMANO", A249RFF_COMPRATAMANO);
            A250RFF_COMPRAHAS = T00156_A250RFF_COMPRAHAS[0];
            n250RFF_COMPRAHAS = T00156_n250RFF_COMPRAHAS[0];
            AssignAttri("", false, "A250RFF_COMPRAHAS", StringUtil.LTrimStr( A250RFF_COMPRAHAS, 16, 2));
            A251RFF_COMPRADISTAKM = T00156_A251RFF_COMPRADISTAKM[0];
            n251RFF_COMPRADISTAKM = T00156_n251RFF_COMPRADISTAKM[0];
            AssignAttri("", false, "A251RFF_COMPRADISTAKM", StringUtil.LTrimStr( A251RFF_COMPRADISTAKM, 10, 2));
            A252RFF_COMPRARANDISTAN = T00156_A252RFF_COMPRARANDISTAN[0];
            n252RFF_COMPRARANDISTAN = T00156_n252RFF_COMPRARANDISTAN[0];
            AssignAttri("", false, "A252RFF_COMPRARANDISTAN", A252RFF_COMPRARANDISTAN);
            A253RFF_COMPRAIDACOMPANAM = T00156_A253RFF_COMPRAIDACOMPANAM[0];
            n253RFF_COMPRAIDACOMPANAM = T00156_n253RFF_COMPRAIDACOMPANAM[0];
            AssignAttri("", false, "A253RFF_COMPRAIDACOMPANAM", StringUtil.LTrimStr( (decimal)(A253RFF_COMPRAIDACOMPANAM), 15, 0));
            A254RFF_COMPRAACOMPANANOM = T00156_A254RFF_COMPRAACOMPANANOM[0];
            n254RFF_COMPRAACOMPANANOM = T00156_n254RFF_COMPRAACOMPANANOM[0];
            AssignAttri("", false, "A254RFF_COMPRAACOMPANANOM", A254RFF_COMPRAACOMPANANOM);
            A255RFF_COMPRARSPO = T00156_A255RFF_COMPRARSPO[0];
            n255RFF_COMPRARSPO = T00156_n255RFF_COMPRARSPO[0];
            AssignAttri("", false, "A255RFF_COMPRARSPO", A255RFF_COMPRARSPO);
            A256RFF_COMPRANATURALEZA = T00156_A256RFF_COMPRANATURALEZA[0];
            n256RFF_COMPRANATURALEZA = T00156_n256RFF_COMPRANATURALEZA[0];
            AssignAttri("", false, "A256RFF_COMPRANATURALEZA", A256RFF_COMPRANATURALEZA);
            A257RFF_COMPRACOORDX = T00156_A257RFF_COMPRACOORDX[0];
            n257RFF_COMPRACOORDX = T00156_n257RFF_COMPRACOORDX[0];
            AssignAttri("", false, "A257RFF_COMPRACOORDX", A257RFF_COMPRACOORDX);
            A258RFF_COMPRACOORDY = T00156_A258RFF_COMPRACOORDY[0];
            n258RFF_COMPRACOORDY = T00156_n258RFF_COMPRACOORDY[0];
            AssignAttri("", false, "A258RFF_COMPRACOORDY", A258RFF_COMPRACOORDY);
            A259RFF_COMPRAEDADRANGO = T00156_A259RFF_COMPRAEDADRANGO[0];
            n259RFF_COMPRAEDADRANGO = T00156_n259RFF_COMPRAEDADRANGO[0];
            AssignAttri("", false, "A259RFF_COMPRAEDADRANGO", A259RFF_COMPRAEDADRANGO);
            A260RFF_COMPRAMATERIAL = T00156_A260RFF_COMPRAMATERIAL[0];
            n260RFF_COMPRAMATERIAL = T00156_n260RFF_COMPRAMATERIAL[0];
            AssignAttri("", false, "A260RFF_COMPRAMATERIAL", A260RFF_COMPRAMATERIAL);
            A261RFF_COMPRACOMITE = T00156_A261RFF_COMPRACOMITE[0];
            n261RFF_COMPRACOMITE = T00156_n261RFF_COMPRACOMITE[0];
            AssignAttri("", false, "A261RFF_COMPRACOMITE", A261RFF_COMPRACOMITE);
            ZM1542( -2) ;
         }
         pr_default.close(4);
         OnLoadActions1542( ) ;
      }

      protected void OnLoadActions1542( )
      {
      }

      protected void CheckExtendedTable1542( )
      {
         nIsDirty_42 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A86RFF_COMPRADAFecha) || ( DateTimeUtil.ResetTime ( A86RFF_COMPRADAFecha ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo RFF_COMPRADAFecha fuera de rango", "OutOfRange", 1, "RFF_COMPRADAFECHA");
            AnyError = 1;
            GX_FocusControl = edtRFF_COMPRADAFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00154 */
         pr_default.execute(2, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T00155 */
         pr_default.execute(3, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors1542( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( string A5Cod_Area )
      {
         /* Using cursor T00157 */
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

      protected void gxLoad_4( string A4IndicadoresCodigo )
      {
         /* Using cursor T00158 */
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

      protected void GetKey1542( )
      {
         /* Using cursor T00159 */
         pr_default.execute(7, new Object[] {A86RFF_COMPRADAFecha, A5Cod_Area, A4IndicadoresCodigo, A87RFF_COMPRADAMes, A88RFF_COMPRADAAno, A89RFF_COMPRAPRODUCUP});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound42 = 1;
         }
         else
         {
            RcdFound42 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00153 */
         pr_default.execute(1, new Object[] {A86RFF_COMPRADAFecha, A5Cod_Area, A4IndicadoresCodigo, A87RFF_COMPRADAMes, A88RFF_COMPRADAAno, A89RFF_COMPRAPRODUCUP});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1542( 2) ;
            RcdFound42 = 1;
            A86RFF_COMPRADAFecha = T00153_A86RFF_COMPRADAFecha[0];
            AssignAttri("", false, "A86RFF_COMPRADAFecha", context.localUtil.Format(A86RFF_COMPRADAFecha, "99/99/99"));
            A87RFF_COMPRADAMes = T00153_A87RFF_COMPRADAMes[0];
            AssignAttri("", false, "A87RFF_COMPRADAMes", StringUtil.LTrimStr( (decimal)(A87RFF_COMPRADAMes), 4, 0));
            A88RFF_COMPRADAAno = T00153_A88RFF_COMPRADAAno[0];
            AssignAttri("", false, "A88RFF_COMPRADAAno", StringUtil.LTrimStr( (decimal)(A88RFF_COMPRADAAno), 4, 0));
            A89RFF_COMPRAPRODUCUP = T00153_A89RFF_COMPRAPRODUCUP[0];
            AssignAttri("", false, "A89RFF_COMPRAPRODUCUP", A89RFF_COMPRAPRODUCUP);
            A238RFF_COMPRATON = T00153_A238RFF_COMPRATON[0];
            n238RFF_COMPRATON = T00153_n238RFF_COMPRATON[0];
            AssignAttri("", false, "A238RFF_COMPRATON", StringUtil.LTrimStr( A238RFF_COMPRATON, 12, 2));
            A239RFF_COMPRAPROVEE = T00153_A239RFF_COMPRAPROVEE[0];
            n239RFF_COMPRAPROVEE = T00153_n239RFF_COMPRAPROVEE[0];
            AssignAttri("", false, "A239RFF_COMPRAPROVEE", A239RFF_COMPRAPROVEE);
            A240RFF_COMPRAFINCA = T00153_A240RFF_COMPRAFINCA[0];
            n240RFF_COMPRAFINCA = T00153_n240RFF_COMPRAFINCA[0];
            AssignAttri("", false, "A240RFF_COMPRAFINCA", A240RFF_COMPRAFINCA);
            A241RFF_COMPRAZONA = T00153_A241RFF_COMPRAZONA[0];
            n241RFF_COMPRAZONA = T00153_n241RFF_COMPRAZONA[0];
            AssignAttri("", false, "A241RFF_COMPRAZONA", A241RFF_COMPRAZONA);
            A242RFF_COMPRAVEREDAID = T00153_A242RFF_COMPRAVEREDAID[0];
            n242RFF_COMPRAVEREDAID = T00153_n242RFF_COMPRAVEREDAID[0];
            AssignAttri("", false, "A242RFF_COMPRAVEREDAID", StringUtil.LTrimStr( (decimal)(A242RFF_COMPRAVEREDAID), 15, 0));
            A243RFF_COMPRAVEREDANOM = T00153_A243RFF_COMPRAVEREDANOM[0];
            n243RFF_COMPRAVEREDANOM = T00153_n243RFF_COMPRAVEREDANOM[0];
            AssignAttri("", false, "A243RFF_COMPRAVEREDANOM", A243RFF_COMPRAVEREDANOM);
            A244RFF_COMPRAMUNIID = T00153_A244RFF_COMPRAMUNIID[0];
            n244RFF_COMPRAMUNIID = T00153_n244RFF_COMPRAMUNIID[0];
            AssignAttri("", false, "A244RFF_COMPRAMUNIID", StringUtil.LTrimStr( (decimal)(A244RFF_COMPRAMUNIID), 10, 0));
            A245RFF_COMPRAMUNINOM = T00153_A245RFF_COMPRAMUNINOM[0];
            n245RFF_COMPRAMUNINOM = T00153_n245RFF_COMPRAMUNINOM[0];
            AssignAttri("", false, "A245RFF_COMPRAMUNINOM", A245RFF_COMPRAMUNINOM);
            A246RFF_COMPRADEPTOID = T00153_A246RFF_COMPRADEPTOID[0];
            n246RFF_COMPRADEPTOID = T00153_n246RFF_COMPRADEPTOID[0];
            AssignAttri("", false, "A246RFF_COMPRADEPTOID", StringUtil.LTrimStr( (decimal)(A246RFF_COMPRADEPTOID), 10, 0));
            A247RFF_COMPRADEPTONOM = T00153_A247RFF_COMPRADEPTONOM[0];
            n247RFF_COMPRADEPTONOM = T00153_n247RFF_COMPRADEPTONOM[0];
            AssignAttri("", false, "A247RFF_COMPRADEPTONOM", A247RFF_COMPRADEPTONOM);
            A248RFF_COMPRACLASIFIC = T00153_A248RFF_COMPRACLASIFIC[0];
            n248RFF_COMPRACLASIFIC = T00153_n248RFF_COMPRACLASIFIC[0];
            AssignAttri("", false, "A248RFF_COMPRACLASIFIC", A248RFF_COMPRACLASIFIC);
            A249RFF_COMPRATAMANO = T00153_A249RFF_COMPRATAMANO[0];
            n249RFF_COMPRATAMANO = T00153_n249RFF_COMPRATAMANO[0];
            AssignAttri("", false, "A249RFF_COMPRATAMANO", A249RFF_COMPRATAMANO);
            A250RFF_COMPRAHAS = T00153_A250RFF_COMPRAHAS[0];
            n250RFF_COMPRAHAS = T00153_n250RFF_COMPRAHAS[0];
            AssignAttri("", false, "A250RFF_COMPRAHAS", StringUtil.LTrimStr( A250RFF_COMPRAHAS, 16, 2));
            A251RFF_COMPRADISTAKM = T00153_A251RFF_COMPRADISTAKM[0];
            n251RFF_COMPRADISTAKM = T00153_n251RFF_COMPRADISTAKM[0];
            AssignAttri("", false, "A251RFF_COMPRADISTAKM", StringUtil.LTrimStr( A251RFF_COMPRADISTAKM, 10, 2));
            A252RFF_COMPRARANDISTAN = T00153_A252RFF_COMPRARANDISTAN[0];
            n252RFF_COMPRARANDISTAN = T00153_n252RFF_COMPRARANDISTAN[0];
            AssignAttri("", false, "A252RFF_COMPRARANDISTAN", A252RFF_COMPRARANDISTAN);
            A253RFF_COMPRAIDACOMPANAM = T00153_A253RFF_COMPRAIDACOMPANAM[0];
            n253RFF_COMPRAIDACOMPANAM = T00153_n253RFF_COMPRAIDACOMPANAM[0];
            AssignAttri("", false, "A253RFF_COMPRAIDACOMPANAM", StringUtil.LTrimStr( (decimal)(A253RFF_COMPRAIDACOMPANAM), 15, 0));
            A254RFF_COMPRAACOMPANANOM = T00153_A254RFF_COMPRAACOMPANANOM[0];
            n254RFF_COMPRAACOMPANANOM = T00153_n254RFF_COMPRAACOMPANANOM[0];
            AssignAttri("", false, "A254RFF_COMPRAACOMPANANOM", A254RFF_COMPRAACOMPANANOM);
            A255RFF_COMPRARSPO = T00153_A255RFF_COMPRARSPO[0];
            n255RFF_COMPRARSPO = T00153_n255RFF_COMPRARSPO[0];
            AssignAttri("", false, "A255RFF_COMPRARSPO", A255RFF_COMPRARSPO);
            A256RFF_COMPRANATURALEZA = T00153_A256RFF_COMPRANATURALEZA[0];
            n256RFF_COMPRANATURALEZA = T00153_n256RFF_COMPRANATURALEZA[0];
            AssignAttri("", false, "A256RFF_COMPRANATURALEZA", A256RFF_COMPRANATURALEZA);
            A257RFF_COMPRACOORDX = T00153_A257RFF_COMPRACOORDX[0];
            n257RFF_COMPRACOORDX = T00153_n257RFF_COMPRACOORDX[0];
            AssignAttri("", false, "A257RFF_COMPRACOORDX", A257RFF_COMPRACOORDX);
            A258RFF_COMPRACOORDY = T00153_A258RFF_COMPRACOORDY[0];
            n258RFF_COMPRACOORDY = T00153_n258RFF_COMPRACOORDY[0];
            AssignAttri("", false, "A258RFF_COMPRACOORDY", A258RFF_COMPRACOORDY);
            A259RFF_COMPRAEDADRANGO = T00153_A259RFF_COMPRAEDADRANGO[0];
            n259RFF_COMPRAEDADRANGO = T00153_n259RFF_COMPRAEDADRANGO[0];
            AssignAttri("", false, "A259RFF_COMPRAEDADRANGO", A259RFF_COMPRAEDADRANGO);
            A260RFF_COMPRAMATERIAL = T00153_A260RFF_COMPRAMATERIAL[0];
            n260RFF_COMPRAMATERIAL = T00153_n260RFF_COMPRAMATERIAL[0];
            AssignAttri("", false, "A260RFF_COMPRAMATERIAL", A260RFF_COMPRAMATERIAL);
            A261RFF_COMPRACOMITE = T00153_A261RFF_COMPRACOMITE[0];
            n261RFF_COMPRACOMITE = T00153_n261RFF_COMPRACOMITE[0];
            AssignAttri("", false, "A261RFF_COMPRACOMITE", A261RFF_COMPRACOMITE);
            A5Cod_Area = T00153_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = T00153_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            Z86RFF_COMPRADAFecha = A86RFF_COMPRADAFecha;
            Z5Cod_Area = A5Cod_Area;
            Z4IndicadoresCodigo = A4IndicadoresCodigo;
            Z87RFF_COMPRADAMes = A87RFF_COMPRADAMes;
            Z88RFF_COMPRADAAno = A88RFF_COMPRADAAno;
            Z89RFF_COMPRAPRODUCUP = A89RFF_COMPRAPRODUCUP;
            sMode42 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1542( ) ;
            if ( AnyError == 1 )
            {
               RcdFound42 = 0;
               InitializeNonKey1542( ) ;
            }
            Gx_mode = sMode42;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound42 = 0;
            InitializeNonKey1542( ) ;
            sMode42 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode42;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1542( ) ;
         if ( RcdFound42 == 0 )
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
         RcdFound42 = 0;
         /* Using cursor T001510 */
         pr_default.execute(8, new Object[] {A86RFF_COMPRADAFecha, A5Cod_Area, A4IndicadoresCodigo, A87RFF_COMPRADAMes, A88RFF_COMPRADAAno, A89RFF_COMPRAPRODUCUP});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( DateTimeUtil.ResetTime ( T001510_A86RFF_COMPRADAFecha[0] ) < DateTimeUtil.ResetTime ( A86RFF_COMPRADAFecha ) ) || ( DateTimeUtil.ResetTime ( T001510_A86RFF_COMPRADAFecha[0] ) == DateTimeUtil.ResetTime ( A86RFF_COMPRADAFecha ) ) && ( StringUtil.StrCmp(T001510_A5Cod_Area[0], A5Cod_Area) < 0 ) || ( StringUtil.StrCmp(T001510_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( DateTimeUtil.ResetTime ( T001510_A86RFF_COMPRADAFecha[0] ) == DateTimeUtil.ResetTime ( A86RFF_COMPRADAFecha ) ) && ( StringUtil.StrCmp(T001510_A4IndicadoresCodigo[0], A4IndicadoresCodigo) < 0 ) || ( StringUtil.StrCmp(T001510_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T001510_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( DateTimeUtil.ResetTime ( T001510_A86RFF_COMPRADAFecha[0] ) == DateTimeUtil.ResetTime ( A86RFF_COMPRADAFecha ) ) && ( T001510_A87RFF_COMPRADAMes[0] < A87RFF_COMPRADAMes ) || ( T001510_A87RFF_COMPRADAMes[0] == A87RFF_COMPRADAMes ) && ( StringUtil.StrCmp(T001510_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T001510_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( DateTimeUtil.ResetTime ( T001510_A86RFF_COMPRADAFecha[0] ) == DateTimeUtil.ResetTime ( A86RFF_COMPRADAFecha ) ) && ( T001510_A88RFF_COMPRADAAno[0] < A88RFF_COMPRADAAno ) || ( T001510_A88RFF_COMPRADAAno[0] == A88RFF_COMPRADAAno ) && ( T001510_A87RFF_COMPRADAMes[0] == A87RFF_COMPRADAMes ) && ( StringUtil.StrCmp(T001510_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T001510_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( DateTimeUtil.ResetTime ( T001510_A86RFF_COMPRADAFecha[0] ) == DateTimeUtil.ResetTime ( A86RFF_COMPRADAFecha ) ) && ( StringUtil.StrCmp(T001510_A89RFF_COMPRAPRODUCUP[0], A89RFF_COMPRAPRODUCUP) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( DateTimeUtil.ResetTime ( T001510_A86RFF_COMPRADAFecha[0] ) > DateTimeUtil.ResetTime ( A86RFF_COMPRADAFecha ) ) || ( DateTimeUtil.ResetTime ( T001510_A86RFF_COMPRADAFecha[0] ) == DateTimeUtil.ResetTime ( A86RFF_COMPRADAFecha ) ) && ( StringUtil.StrCmp(T001510_A5Cod_Area[0], A5Cod_Area) > 0 ) || ( StringUtil.StrCmp(T001510_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( DateTimeUtil.ResetTime ( T001510_A86RFF_COMPRADAFecha[0] ) == DateTimeUtil.ResetTime ( A86RFF_COMPRADAFecha ) ) && ( StringUtil.StrCmp(T001510_A4IndicadoresCodigo[0], A4IndicadoresCodigo) > 0 ) || ( StringUtil.StrCmp(T001510_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T001510_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( DateTimeUtil.ResetTime ( T001510_A86RFF_COMPRADAFecha[0] ) == DateTimeUtil.ResetTime ( A86RFF_COMPRADAFecha ) ) && ( T001510_A87RFF_COMPRADAMes[0] > A87RFF_COMPRADAMes ) || ( T001510_A87RFF_COMPRADAMes[0] == A87RFF_COMPRADAMes ) && ( StringUtil.StrCmp(T001510_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T001510_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( DateTimeUtil.ResetTime ( T001510_A86RFF_COMPRADAFecha[0] ) == DateTimeUtil.ResetTime ( A86RFF_COMPRADAFecha ) ) && ( T001510_A88RFF_COMPRADAAno[0] > A88RFF_COMPRADAAno ) || ( T001510_A88RFF_COMPRADAAno[0] == A88RFF_COMPRADAAno ) && ( T001510_A87RFF_COMPRADAMes[0] == A87RFF_COMPRADAMes ) && ( StringUtil.StrCmp(T001510_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T001510_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( DateTimeUtil.ResetTime ( T001510_A86RFF_COMPRADAFecha[0] ) == DateTimeUtil.ResetTime ( A86RFF_COMPRADAFecha ) ) && ( StringUtil.StrCmp(T001510_A89RFF_COMPRAPRODUCUP[0], A89RFF_COMPRAPRODUCUP) > 0 ) ) )
            {
               A86RFF_COMPRADAFecha = T001510_A86RFF_COMPRADAFecha[0];
               AssignAttri("", false, "A86RFF_COMPRADAFecha", context.localUtil.Format(A86RFF_COMPRADAFecha, "99/99/99"));
               A5Cod_Area = T001510_A5Cod_Area[0];
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               A4IndicadoresCodigo = T001510_A4IndicadoresCodigo[0];
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               A87RFF_COMPRADAMes = T001510_A87RFF_COMPRADAMes[0];
               AssignAttri("", false, "A87RFF_COMPRADAMes", StringUtil.LTrimStr( (decimal)(A87RFF_COMPRADAMes), 4, 0));
               A88RFF_COMPRADAAno = T001510_A88RFF_COMPRADAAno[0];
               AssignAttri("", false, "A88RFF_COMPRADAAno", StringUtil.LTrimStr( (decimal)(A88RFF_COMPRADAAno), 4, 0));
               A89RFF_COMPRAPRODUCUP = T001510_A89RFF_COMPRAPRODUCUP[0];
               AssignAttri("", false, "A89RFF_COMPRAPRODUCUP", A89RFF_COMPRAPRODUCUP);
               RcdFound42 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound42 = 0;
         /* Using cursor T001511 */
         pr_default.execute(9, new Object[] {A86RFF_COMPRADAFecha, A5Cod_Area, A4IndicadoresCodigo, A87RFF_COMPRADAMes, A88RFF_COMPRADAAno, A89RFF_COMPRAPRODUCUP});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( DateTimeUtil.ResetTime ( T001511_A86RFF_COMPRADAFecha[0] ) > DateTimeUtil.ResetTime ( A86RFF_COMPRADAFecha ) ) || ( DateTimeUtil.ResetTime ( T001511_A86RFF_COMPRADAFecha[0] ) == DateTimeUtil.ResetTime ( A86RFF_COMPRADAFecha ) ) && ( StringUtil.StrCmp(T001511_A5Cod_Area[0], A5Cod_Area) > 0 ) || ( StringUtil.StrCmp(T001511_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( DateTimeUtil.ResetTime ( T001511_A86RFF_COMPRADAFecha[0] ) == DateTimeUtil.ResetTime ( A86RFF_COMPRADAFecha ) ) && ( StringUtil.StrCmp(T001511_A4IndicadoresCodigo[0], A4IndicadoresCodigo) > 0 ) || ( StringUtil.StrCmp(T001511_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T001511_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( DateTimeUtil.ResetTime ( T001511_A86RFF_COMPRADAFecha[0] ) == DateTimeUtil.ResetTime ( A86RFF_COMPRADAFecha ) ) && ( T001511_A87RFF_COMPRADAMes[0] > A87RFF_COMPRADAMes ) || ( T001511_A87RFF_COMPRADAMes[0] == A87RFF_COMPRADAMes ) && ( StringUtil.StrCmp(T001511_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T001511_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( DateTimeUtil.ResetTime ( T001511_A86RFF_COMPRADAFecha[0] ) == DateTimeUtil.ResetTime ( A86RFF_COMPRADAFecha ) ) && ( T001511_A88RFF_COMPRADAAno[0] > A88RFF_COMPRADAAno ) || ( T001511_A88RFF_COMPRADAAno[0] == A88RFF_COMPRADAAno ) && ( T001511_A87RFF_COMPRADAMes[0] == A87RFF_COMPRADAMes ) && ( StringUtil.StrCmp(T001511_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T001511_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( DateTimeUtil.ResetTime ( T001511_A86RFF_COMPRADAFecha[0] ) == DateTimeUtil.ResetTime ( A86RFF_COMPRADAFecha ) ) && ( StringUtil.StrCmp(T001511_A89RFF_COMPRAPRODUCUP[0], A89RFF_COMPRAPRODUCUP) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( DateTimeUtil.ResetTime ( T001511_A86RFF_COMPRADAFecha[0] ) < DateTimeUtil.ResetTime ( A86RFF_COMPRADAFecha ) ) || ( DateTimeUtil.ResetTime ( T001511_A86RFF_COMPRADAFecha[0] ) == DateTimeUtil.ResetTime ( A86RFF_COMPRADAFecha ) ) && ( StringUtil.StrCmp(T001511_A5Cod_Area[0], A5Cod_Area) < 0 ) || ( StringUtil.StrCmp(T001511_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( DateTimeUtil.ResetTime ( T001511_A86RFF_COMPRADAFecha[0] ) == DateTimeUtil.ResetTime ( A86RFF_COMPRADAFecha ) ) && ( StringUtil.StrCmp(T001511_A4IndicadoresCodigo[0], A4IndicadoresCodigo) < 0 ) || ( StringUtil.StrCmp(T001511_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T001511_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( DateTimeUtil.ResetTime ( T001511_A86RFF_COMPRADAFecha[0] ) == DateTimeUtil.ResetTime ( A86RFF_COMPRADAFecha ) ) && ( T001511_A87RFF_COMPRADAMes[0] < A87RFF_COMPRADAMes ) || ( T001511_A87RFF_COMPRADAMes[0] == A87RFF_COMPRADAMes ) && ( StringUtil.StrCmp(T001511_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T001511_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( DateTimeUtil.ResetTime ( T001511_A86RFF_COMPRADAFecha[0] ) == DateTimeUtil.ResetTime ( A86RFF_COMPRADAFecha ) ) && ( T001511_A88RFF_COMPRADAAno[0] < A88RFF_COMPRADAAno ) || ( T001511_A88RFF_COMPRADAAno[0] == A88RFF_COMPRADAAno ) && ( T001511_A87RFF_COMPRADAMes[0] == A87RFF_COMPRADAMes ) && ( StringUtil.StrCmp(T001511_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T001511_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( DateTimeUtil.ResetTime ( T001511_A86RFF_COMPRADAFecha[0] ) == DateTimeUtil.ResetTime ( A86RFF_COMPRADAFecha ) ) && ( StringUtil.StrCmp(T001511_A89RFF_COMPRAPRODUCUP[0], A89RFF_COMPRAPRODUCUP) < 0 ) ) )
            {
               A86RFF_COMPRADAFecha = T001511_A86RFF_COMPRADAFecha[0];
               AssignAttri("", false, "A86RFF_COMPRADAFecha", context.localUtil.Format(A86RFF_COMPRADAFecha, "99/99/99"));
               A5Cod_Area = T001511_A5Cod_Area[0];
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               A4IndicadoresCodigo = T001511_A4IndicadoresCodigo[0];
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               A87RFF_COMPRADAMes = T001511_A87RFF_COMPRADAMes[0];
               AssignAttri("", false, "A87RFF_COMPRADAMes", StringUtil.LTrimStr( (decimal)(A87RFF_COMPRADAMes), 4, 0));
               A88RFF_COMPRADAAno = T001511_A88RFF_COMPRADAAno[0];
               AssignAttri("", false, "A88RFF_COMPRADAAno", StringUtil.LTrimStr( (decimal)(A88RFF_COMPRADAAno), 4, 0));
               A89RFF_COMPRAPRODUCUP = T001511_A89RFF_COMPRAPRODUCUP[0];
               AssignAttri("", false, "A89RFF_COMPRAPRODUCUP", A89RFF_COMPRAPRODUCUP);
               RcdFound42 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1542( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtRFF_COMPRADAFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1542( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound42 == 1 )
            {
               if ( ( DateTimeUtil.ResetTime ( A86RFF_COMPRADAFecha ) != DateTimeUtil.ResetTime ( Z86RFF_COMPRADAFecha ) ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) || ( A87RFF_COMPRADAMes != Z87RFF_COMPRADAMes ) || ( A88RFF_COMPRADAAno != Z88RFF_COMPRADAAno ) || ( StringUtil.StrCmp(A89RFF_COMPRAPRODUCUP, Z89RFF_COMPRAPRODUCUP) != 0 ) )
               {
                  A86RFF_COMPRADAFecha = Z86RFF_COMPRADAFecha;
                  AssignAttri("", false, "A86RFF_COMPRADAFecha", context.localUtil.Format(A86RFF_COMPRADAFecha, "99/99/99"));
                  A5Cod_Area = Z5Cod_Area;
                  AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
                  A4IndicadoresCodigo = Z4IndicadoresCodigo;
                  AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
                  A87RFF_COMPRADAMes = Z87RFF_COMPRADAMes;
                  AssignAttri("", false, "A87RFF_COMPRADAMes", StringUtil.LTrimStr( (decimal)(A87RFF_COMPRADAMes), 4, 0));
                  A88RFF_COMPRADAAno = Z88RFF_COMPRADAAno;
                  AssignAttri("", false, "A88RFF_COMPRADAAno", StringUtil.LTrimStr( (decimal)(A88RFF_COMPRADAAno), 4, 0));
                  A89RFF_COMPRAPRODUCUP = Z89RFF_COMPRAPRODUCUP;
                  AssignAttri("", false, "A89RFF_COMPRAPRODUCUP", A89RFF_COMPRAPRODUCUP);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "RFF_COMPRADAFECHA");
                  AnyError = 1;
                  GX_FocusControl = edtRFF_COMPRADAFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtRFF_COMPRADAFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1542( ) ;
                  GX_FocusControl = edtRFF_COMPRADAFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( DateTimeUtil.ResetTime ( A86RFF_COMPRADAFecha ) != DateTimeUtil.ResetTime ( Z86RFF_COMPRADAFecha ) ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) || ( A87RFF_COMPRADAMes != Z87RFF_COMPRADAMes ) || ( A88RFF_COMPRADAAno != Z88RFF_COMPRADAAno ) || ( StringUtil.StrCmp(A89RFF_COMPRAPRODUCUP, Z89RFF_COMPRAPRODUCUP) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtRFF_COMPRADAFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1542( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "RFF_COMPRADAFECHA");
                     AnyError = 1;
                     GX_FocusControl = edtRFF_COMPRADAFecha_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtRFF_COMPRADAFecha_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1542( ) ;
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
         if ( ( DateTimeUtil.ResetTime ( A86RFF_COMPRADAFecha ) != DateTimeUtil.ResetTime ( Z86RFF_COMPRADAFecha ) ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) || ( A87RFF_COMPRADAMes != Z87RFF_COMPRADAMes ) || ( A88RFF_COMPRADAAno != Z88RFF_COMPRADAAno ) || ( StringUtil.StrCmp(A89RFF_COMPRAPRODUCUP, Z89RFF_COMPRAPRODUCUP) != 0 ) )
         {
            A86RFF_COMPRADAFecha = Z86RFF_COMPRADAFecha;
            AssignAttri("", false, "A86RFF_COMPRADAFecha", context.localUtil.Format(A86RFF_COMPRADAFecha, "99/99/99"));
            A5Cod_Area = Z5Cod_Area;
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = Z4IndicadoresCodigo;
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A87RFF_COMPRADAMes = Z87RFF_COMPRADAMes;
            AssignAttri("", false, "A87RFF_COMPRADAMes", StringUtil.LTrimStr( (decimal)(A87RFF_COMPRADAMes), 4, 0));
            A88RFF_COMPRADAAno = Z88RFF_COMPRADAAno;
            AssignAttri("", false, "A88RFF_COMPRADAAno", StringUtil.LTrimStr( (decimal)(A88RFF_COMPRADAAno), 4, 0));
            A89RFF_COMPRAPRODUCUP = Z89RFF_COMPRAPRODUCUP;
            AssignAttri("", false, "A89RFF_COMPRAPRODUCUP", A89RFF_COMPRAPRODUCUP);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "RFF_COMPRADAFECHA");
            AnyError = 1;
            GX_FocusControl = edtRFF_COMPRADAFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtRFF_COMPRADAFecha_Internalname;
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
         if ( RcdFound42 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "RFF_COMPRADAFECHA");
            AnyError = 1;
            GX_FocusControl = edtRFF_COMPRADAFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtRFF_COMPRATON_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1542( ) ;
         if ( RcdFound42 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtRFF_COMPRATON_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1542( ) ;
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
         if ( RcdFound42 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtRFF_COMPRATON_Internalname;
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
         if ( RcdFound42 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtRFF_COMPRATON_Internalname;
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
         ScanStart1542( ) ;
         if ( RcdFound42 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound42 != 0 )
            {
               ScanNext1542( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtRFF_COMPRATON_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1542( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1542( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00152 */
            pr_default.execute(0, new Object[] {A86RFF_COMPRADAFecha, A5Cod_Area, A4IndicadoresCodigo, A87RFF_COMPRADAMes, A88RFF_COMPRADAAno, A89RFF_COMPRAPRODUCUP});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"RFF_COMPRADA"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z238RFF_COMPRATON != T00152_A238RFF_COMPRATON[0] ) || ( StringUtil.StrCmp(Z239RFF_COMPRAPROVEE, T00152_A239RFF_COMPRAPROVEE[0]) != 0 ) || ( StringUtil.StrCmp(Z240RFF_COMPRAFINCA, T00152_A240RFF_COMPRAFINCA[0]) != 0 ) || ( StringUtil.StrCmp(Z241RFF_COMPRAZONA, T00152_A241RFF_COMPRAZONA[0]) != 0 ) || ( Z242RFF_COMPRAVEREDAID != T00152_A242RFF_COMPRAVEREDAID[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z243RFF_COMPRAVEREDANOM, T00152_A243RFF_COMPRAVEREDANOM[0]) != 0 ) || ( Z244RFF_COMPRAMUNIID != T00152_A244RFF_COMPRAMUNIID[0] ) || ( StringUtil.StrCmp(Z245RFF_COMPRAMUNINOM, T00152_A245RFF_COMPRAMUNINOM[0]) != 0 ) || ( Z246RFF_COMPRADEPTOID != T00152_A246RFF_COMPRADEPTOID[0] ) || ( StringUtil.StrCmp(Z247RFF_COMPRADEPTONOM, T00152_A247RFF_COMPRADEPTONOM[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z248RFF_COMPRACLASIFIC, T00152_A248RFF_COMPRACLASIFIC[0]) != 0 ) || ( StringUtil.StrCmp(Z249RFF_COMPRATAMANO, T00152_A249RFF_COMPRATAMANO[0]) != 0 ) || ( Z250RFF_COMPRAHAS != T00152_A250RFF_COMPRAHAS[0] ) || ( Z251RFF_COMPRADISTAKM != T00152_A251RFF_COMPRADISTAKM[0] ) || ( StringUtil.StrCmp(Z252RFF_COMPRARANDISTAN, T00152_A252RFF_COMPRARANDISTAN[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z253RFF_COMPRAIDACOMPANAM != T00152_A253RFF_COMPRAIDACOMPANAM[0] ) || ( StringUtil.StrCmp(Z254RFF_COMPRAACOMPANANOM, T00152_A254RFF_COMPRAACOMPANANOM[0]) != 0 ) || ( StringUtil.StrCmp(Z255RFF_COMPRARSPO, T00152_A255RFF_COMPRARSPO[0]) != 0 ) || ( StringUtil.StrCmp(Z256RFF_COMPRANATURALEZA, T00152_A256RFF_COMPRANATURALEZA[0]) != 0 ) || ( StringUtil.StrCmp(Z257RFF_COMPRACOORDX, T00152_A257RFF_COMPRACOORDX[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z258RFF_COMPRACOORDY, T00152_A258RFF_COMPRACOORDY[0]) != 0 ) || ( StringUtil.StrCmp(Z259RFF_COMPRAEDADRANGO, T00152_A259RFF_COMPRAEDADRANGO[0]) != 0 ) || ( StringUtil.StrCmp(Z260RFF_COMPRAMATERIAL, T00152_A260RFF_COMPRAMATERIAL[0]) != 0 ) || ( StringUtil.StrCmp(Z261RFF_COMPRACOMITE, T00152_A261RFF_COMPRACOMITE[0]) != 0 ) )
            {
               if ( Z238RFF_COMPRATON != T00152_A238RFF_COMPRATON[0] )
               {
                  GXUtil.WriteLog("rff_comprada:[seudo value changed for attri]"+"RFF_COMPRATON");
                  GXUtil.WriteLogRaw("Old: ",Z238RFF_COMPRATON);
                  GXUtil.WriteLogRaw("Current: ",T00152_A238RFF_COMPRATON[0]);
               }
               if ( StringUtil.StrCmp(Z239RFF_COMPRAPROVEE, T00152_A239RFF_COMPRAPROVEE[0]) != 0 )
               {
                  GXUtil.WriteLog("rff_comprada:[seudo value changed for attri]"+"RFF_COMPRAPROVEE");
                  GXUtil.WriteLogRaw("Old: ",Z239RFF_COMPRAPROVEE);
                  GXUtil.WriteLogRaw("Current: ",T00152_A239RFF_COMPRAPROVEE[0]);
               }
               if ( StringUtil.StrCmp(Z240RFF_COMPRAFINCA, T00152_A240RFF_COMPRAFINCA[0]) != 0 )
               {
                  GXUtil.WriteLog("rff_comprada:[seudo value changed for attri]"+"RFF_COMPRAFINCA");
                  GXUtil.WriteLogRaw("Old: ",Z240RFF_COMPRAFINCA);
                  GXUtil.WriteLogRaw("Current: ",T00152_A240RFF_COMPRAFINCA[0]);
               }
               if ( StringUtil.StrCmp(Z241RFF_COMPRAZONA, T00152_A241RFF_COMPRAZONA[0]) != 0 )
               {
                  GXUtil.WriteLog("rff_comprada:[seudo value changed for attri]"+"RFF_COMPRAZONA");
                  GXUtil.WriteLogRaw("Old: ",Z241RFF_COMPRAZONA);
                  GXUtil.WriteLogRaw("Current: ",T00152_A241RFF_COMPRAZONA[0]);
               }
               if ( Z242RFF_COMPRAVEREDAID != T00152_A242RFF_COMPRAVEREDAID[0] )
               {
                  GXUtil.WriteLog("rff_comprada:[seudo value changed for attri]"+"RFF_COMPRAVEREDAID");
                  GXUtil.WriteLogRaw("Old: ",Z242RFF_COMPRAVEREDAID);
                  GXUtil.WriteLogRaw("Current: ",T00152_A242RFF_COMPRAVEREDAID[0]);
               }
               if ( StringUtil.StrCmp(Z243RFF_COMPRAVEREDANOM, T00152_A243RFF_COMPRAVEREDANOM[0]) != 0 )
               {
                  GXUtil.WriteLog("rff_comprada:[seudo value changed for attri]"+"RFF_COMPRAVEREDANOM");
                  GXUtil.WriteLogRaw("Old: ",Z243RFF_COMPRAVEREDANOM);
                  GXUtil.WriteLogRaw("Current: ",T00152_A243RFF_COMPRAVEREDANOM[0]);
               }
               if ( Z244RFF_COMPRAMUNIID != T00152_A244RFF_COMPRAMUNIID[0] )
               {
                  GXUtil.WriteLog("rff_comprada:[seudo value changed for attri]"+"RFF_COMPRAMUNIID");
                  GXUtil.WriteLogRaw("Old: ",Z244RFF_COMPRAMUNIID);
                  GXUtil.WriteLogRaw("Current: ",T00152_A244RFF_COMPRAMUNIID[0]);
               }
               if ( StringUtil.StrCmp(Z245RFF_COMPRAMUNINOM, T00152_A245RFF_COMPRAMUNINOM[0]) != 0 )
               {
                  GXUtil.WriteLog("rff_comprada:[seudo value changed for attri]"+"RFF_COMPRAMUNINOM");
                  GXUtil.WriteLogRaw("Old: ",Z245RFF_COMPRAMUNINOM);
                  GXUtil.WriteLogRaw("Current: ",T00152_A245RFF_COMPRAMUNINOM[0]);
               }
               if ( Z246RFF_COMPRADEPTOID != T00152_A246RFF_COMPRADEPTOID[0] )
               {
                  GXUtil.WriteLog("rff_comprada:[seudo value changed for attri]"+"RFF_COMPRADEPTOID");
                  GXUtil.WriteLogRaw("Old: ",Z246RFF_COMPRADEPTOID);
                  GXUtil.WriteLogRaw("Current: ",T00152_A246RFF_COMPRADEPTOID[0]);
               }
               if ( StringUtil.StrCmp(Z247RFF_COMPRADEPTONOM, T00152_A247RFF_COMPRADEPTONOM[0]) != 0 )
               {
                  GXUtil.WriteLog("rff_comprada:[seudo value changed for attri]"+"RFF_COMPRADEPTONOM");
                  GXUtil.WriteLogRaw("Old: ",Z247RFF_COMPRADEPTONOM);
                  GXUtil.WriteLogRaw("Current: ",T00152_A247RFF_COMPRADEPTONOM[0]);
               }
               if ( StringUtil.StrCmp(Z248RFF_COMPRACLASIFIC, T00152_A248RFF_COMPRACLASIFIC[0]) != 0 )
               {
                  GXUtil.WriteLog("rff_comprada:[seudo value changed for attri]"+"RFF_COMPRACLASIFIC");
                  GXUtil.WriteLogRaw("Old: ",Z248RFF_COMPRACLASIFIC);
                  GXUtil.WriteLogRaw("Current: ",T00152_A248RFF_COMPRACLASIFIC[0]);
               }
               if ( StringUtil.StrCmp(Z249RFF_COMPRATAMANO, T00152_A249RFF_COMPRATAMANO[0]) != 0 )
               {
                  GXUtil.WriteLog("rff_comprada:[seudo value changed for attri]"+"RFF_COMPRATAMANO");
                  GXUtil.WriteLogRaw("Old: ",Z249RFF_COMPRATAMANO);
                  GXUtil.WriteLogRaw("Current: ",T00152_A249RFF_COMPRATAMANO[0]);
               }
               if ( Z250RFF_COMPRAHAS != T00152_A250RFF_COMPRAHAS[0] )
               {
                  GXUtil.WriteLog("rff_comprada:[seudo value changed for attri]"+"RFF_COMPRAHAS");
                  GXUtil.WriteLogRaw("Old: ",Z250RFF_COMPRAHAS);
                  GXUtil.WriteLogRaw("Current: ",T00152_A250RFF_COMPRAHAS[0]);
               }
               if ( Z251RFF_COMPRADISTAKM != T00152_A251RFF_COMPRADISTAKM[0] )
               {
                  GXUtil.WriteLog("rff_comprada:[seudo value changed for attri]"+"RFF_COMPRADISTAKM");
                  GXUtil.WriteLogRaw("Old: ",Z251RFF_COMPRADISTAKM);
                  GXUtil.WriteLogRaw("Current: ",T00152_A251RFF_COMPRADISTAKM[0]);
               }
               if ( StringUtil.StrCmp(Z252RFF_COMPRARANDISTAN, T00152_A252RFF_COMPRARANDISTAN[0]) != 0 )
               {
                  GXUtil.WriteLog("rff_comprada:[seudo value changed for attri]"+"RFF_COMPRARANDISTAN");
                  GXUtil.WriteLogRaw("Old: ",Z252RFF_COMPRARANDISTAN);
                  GXUtil.WriteLogRaw("Current: ",T00152_A252RFF_COMPRARANDISTAN[0]);
               }
               if ( Z253RFF_COMPRAIDACOMPANAM != T00152_A253RFF_COMPRAIDACOMPANAM[0] )
               {
                  GXUtil.WriteLog("rff_comprada:[seudo value changed for attri]"+"RFF_COMPRAIDACOMPANAM");
                  GXUtil.WriteLogRaw("Old: ",Z253RFF_COMPRAIDACOMPANAM);
                  GXUtil.WriteLogRaw("Current: ",T00152_A253RFF_COMPRAIDACOMPANAM[0]);
               }
               if ( StringUtil.StrCmp(Z254RFF_COMPRAACOMPANANOM, T00152_A254RFF_COMPRAACOMPANANOM[0]) != 0 )
               {
                  GXUtil.WriteLog("rff_comprada:[seudo value changed for attri]"+"RFF_COMPRAACOMPANANOM");
                  GXUtil.WriteLogRaw("Old: ",Z254RFF_COMPRAACOMPANANOM);
                  GXUtil.WriteLogRaw("Current: ",T00152_A254RFF_COMPRAACOMPANANOM[0]);
               }
               if ( StringUtil.StrCmp(Z255RFF_COMPRARSPO, T00152_A255RFF_COMPRARSPO[0]) != 0 )
               {
                  GXUtil.WriteLog("rff_comprada:[seudo value changed for attri]"+"RFF_COMPRARSPO");
                  GXUtil.WriteLogRaw("Old: ",Z255RFF_COMPRARSPO);
                  GXUtil.WriteLogRaw("Current: ",T00152_A255RFF_COMPRARSPO[0]);
               }
               if ( StringUtil.StrCmp(Z256RFF_COMPRANATURALEZA, T00152_A256RFF_COMPRANATURALEZA[0]) != 0 )
               {
                  GXUtil.WriteLog("rff_comprada:[seudo value changed for attri]"+"RFF_COMPRANATURALEZA");
                  GXUtil.WriteLogRaw("Old: ",Z256RFF_COMPRANATURALEZA);
                  GXUtil.WriteLogRaw("Current: ",T00152_A256RFF_COMPRANATURALEZA[0]);
               }
               if ( StringUtil.StrCmp(Z257RFF_COMPRACOORDX, T00152_A257RFF_COMPRACOORDX[0]) != 0 )
               {
                  GXUtil.WriteLog("rff_comprada:[seudo value changed for attri]"+"RFF_COMPRACOORDX");
                  GXUtil.WriteLogRaw("Old: ",Z257RFF_COMPRACOORDX);
                  GXUtil.WriteLogRaw("Current: ",T00152_A257RFF_COMPRACOORDX[0]);
               }
               if ( StringUtil.StrCmp(Z258RFF_COMPRACOORDY, T00152_A258RFF_COMPRACOORDY[0]) != 0 )
               {
                  GXUtil.WriteLog("rff_comprada:[seudo value changed for attri]"+"RFF_COMPRACOORDY");
                  GXUtil.WriteLogRaw("Old: ",Z258RFF_COMPRACOORDY);
                  GXUtil.WriteLogRaw("Current: ",T00152_A258RFF_COMPRACOORDY[0]);
               }
               if ( StringUtil.StrCmp(Z259RFF_COMPRAEDADRANGO, T00152_A259RFF_COMPRAEDADRANGO[0]) != 0 )
               {
                  GXUtil.WriteLog("rff_comprada:[seudo value changed for attri]"+"RFF_COMPRAEDADRANGO");
                  GXUtil.WriteLogRaw("Old: ",Z259RFF_COMPRAEDADRANGO);
                  GXUtil.WriteLogRaw("Current: ",T00152_A259RFF_COMPRAEDADRANGO[0]);
               }
               if ( StringUtil.StrCmp(Z260RFF_COMPRAMATERIAL, T00152_A260RFF_COMPRAMATERIAL[0]) != 0 )
               {
                  GXUtil.WriteLog("rff_comprada:[seudo value changed for attri]"+"RFF_COMPRAMATERIAL");
                  GXUtil.WriteLogRaw("Old: ",Z260RFF_COMPRAMATERIAL);
                  GXUtil.WriteLogRaw("Current: ",T00152_A260RFF_COMPRAMATERIAL[0]);
               }
               if ( StringUtil.StrCmp(Z261RFF_COMPRACOMITE, T00152_A261RFF_COMPRACOMITE[0]) != 0 )
               {
                  GXUtil.WriteLog("rff_comprada:[seudo value changed for attri]"+"RFF_COMPRACOMITE");
                  GXUtil.WriteLogRaw("Old: ",Z261RFF_COMPRACOMITE);
                  GXUtil.WriteLogRaw("Current: ",T00152_A261RFF_COMPRACOMITE[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"RFF_COMPRADA"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1542( )
      {
         BeforeValidate1542( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1542( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1542( 0) ;
            CheckOptimisticConcurrency1542( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1542( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1542( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001512 */
                     pr_default.execute(10, new Object[] {A86RFF_COMPRADAFecha, A87RFF_COMPRADAMes, A88RFF_COMPRADAAno, A89RFF_COMPRAPRODUCUP, n238RFF_COMPRATON, A238RFF_COMPRATON, n239RFF_COMPRAPROVEE, A239RFF_COMPRAPROVEE, n240RFF_COMPRAFINCA, A240RFF_COMPRAFINCA, n241RFF_COMPRAZONA, A241RFF_COMPRAZONA, n242RFF_COMPRAVEREDAID, A242RFF_COMPRAVEREDAID, n243RFF_COMPRAVEREDANOM, A243RFF_COMPRAVEREDANOM, n244RFF_COMPRAMUNIID, A244RFF_COMPRAMUNIID, n245RFF_COMPRAMUNINOM, A245RFF_COMPRAMUNINOM, n246RFF_COMPRADEPTOID, A246RFF_COMPRADEPTOID, n247RFF_COMPRADEPTONOM, A247RFF_COMPRADEPTONOM, n248RFF_COMPRACLASIFIC, A248RFF_COMPRACLASIFIC, n249RFF_COMPRATAMANO, A249RFF_COMPRATAMANO, n250RFF_COMPRAHAS, A250RFF_COMPRAHAS, n251RFF_COMPRADISTAKM, A251RFF_COMPRADISTAKM, n252RFF_COMPRARANDISTAN, A252RFF_COMPRARANDISTAN, n253RFF_COMPRAIDACOMPANAM, A253RFF_COMPRAIDACOMPANAM, n254RFF_COMPRAACOMPANANOM, A254RFF_COMPRAACOMPANANOM, n255RFF_COMPRARSPO, A255RFF_COMPRARSPO, n256RFF_COMPRANATURALEZA, A256RFF_COMPRANATURALEZA, n257RFF_COMPRACOORDX, A257RFF_COMPRACOORDX, n258RFF_COMPRACOORDY, A258RFF_COMPRACOORDY, n259RFF_COMPRAEDADRANGO, A259RFF_COMPRAEDADRANGO, n260RFF_COMPRAMATERIAL, A260RFF_COMPRAMATERIAL, n261RFF_COMPRACOMITE, A261RFF_COMPRACOMITE, A5Cod_Area, A4IndicadoresCodigo});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("RFF_COMPRADA");
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
                           ResetCaption150( ) ;
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
               Load1542( ) ;
            }
            EndLevel1542( ) ;
         }
         CloseExtendedTableCursors1542( ) ;
      }

      protected void Update1542( )
      {
         BeforeValidate1542( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1542( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1542( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1542( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1542( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001513 */
                     pr_default.execute(11, new Object[] {n238RFF_COMPRATON, A238RFF_COMPRATON, n239RFF_COMPRAPROVEE, A239RFF_COMPRAPROVEE, n240RFF_COMPRAFINCA, A240RFF_COMPRAFINCA, n241RFF_COMPRAZONA, A241RFF_COMPRAZONA, n242RFF_COMPRAVEREDAID, A242RFF_COMPRAVEREDAID, n243RFF_COMPRAVEREDANOM, A243RFF_COMPRAVEREDANOM, n244RFF_COMPRAMUNIID, A244RFF_COMPRAMUNIID, n245RFF_COMPRAMUNINOM, A245RFF_COMPRAMUNINOM, n246RFF_COMPRADEPTOID, A246RFF_COMPRADEPTOID, n247RFF_COMPRADEPTONOM, A247RFF_COMPRADEPTONOM, n248RFF_COMPRACLASIFIC, A248RFF_COMPRACLASIFIC, n249RFF_COMPRATAMANO, A249RFF_COMPRATAMANO, n250RFF_COMPRAHAS, A250RFF_COMPRAHAS, n251RFF_COMPRADISTAKM, A251RFF_COMPRADISTAKM, n252RFF_COMPRARANDISTAN, A252RFF_COMPRARANDISTAN, n253RFF_COMPRAIDACOMPANAM, A253RFF_COMPRAIDACOMPANAM, n254RFF_COMPRAACOMPANANOM, A254RFF_COMPRAACOMPANANOM, n255RFF_COMPRARSPO, A255RFF_COMPRARSPO, n256RFF_COMPRANATURALEZA, A256RFF_COMPRANATURALEZA, n257RFF_COMPRACOORDX, A257RFF_COMPRACOORDX, n258RFF_COMPRACOORDY, A258RFF_COMPRACOORDY, n259RFF_COMPRAEDADRANGO, A259RFF_COMPRAEDADRANGO, n260RFF_COMPRAMATERIAL, A260RFF_COMPRAMATERIAL, n261RFF_COMPRACOMITE, A261RFF_COMPRACOMITE, A86RFF_COMPRADAFecha, A5Cod_Area, A4IndicadoresCodigo, A87RFF_COMPRADAMes, A88RFF_COMPRADAAno, A89RFF_COMPRAPRODUCUP});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("RFF_COMPRADA");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"RFF_COMPRADA"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1542( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption150( ) ;
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
            EndLevel1542( ) ;
         }
         CloseExtendedTableCursors1542( ) ;
      }

      protected void DeferredUpdate1542( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1542( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1542( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1542( ) ;
            AfterConfirm1542( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1542( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001514 */
                  pr_default.execute(12, new Object[] {A86RFF_COMPRADAFecha, A5Cod_Area, A4IndicadoresCodigo, A87RFF_COMPRADAMes, A88RFF_COMPRADAAno, A89RFF_COMPRAPRODUCUP});
                  pr_default.close(12);
                  pr_default.SmartCacheProvider.SetUpdated("RFF_COMPRADA");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound42 == 0 )
                        {
                           InitAll1542( ) ;
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
                        ResetCaption150( ) ;
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
         sMode42 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1542( ) ;
         Gx_mode = sMode42;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1542( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1542( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1542( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("rff_comprada",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues150( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("rff_comprada",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1542( )
      {
         /* Using cursor T001515 */
         pr_default.execute(13);
         RcdFound42 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound42 = 1;
            A86RFF_COMPRADAFecha = T001515_A86RFF_COMPRADAFecha[0];
            AssignAttri("", false, "A86RFF_COMPRADAFecha", context.localUtil.Format(A86RFF_COMPRADAFecha, "99/99/99"));
            A5Cod_Area = T001515_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = T001515_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A87RFF_COMPRADAMes = T001515_A87RFF_COMPRADAMes[0];
            AssignAttri("", false, "A87RFF_COMPRADAMes", StringUtil.LTrimStr( (decimal)(A87RFF_COMPRADAMes), 4, 0));
            A88RFF_COMPRADAAno = T001515_A88RFF_COMPRADAAno[0];
            AssignAttri("", false, "A88RFF_COMPRADAAno", StringUtil.LTrimStr( (decimal)(A88RFF_COMPRADAAno), 4, 0));
            A89RFF_COMPRAPRODUCUP = T001515_A89RFF_COMPRAPRODUCUP[0];
            AssignAttri("", false, "A89RFF_COMPRAPRODUCUP", A89RFF_COMPRAPRODUCUP);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1542( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound42 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound42 = 1;
            A86RFF_COMPRADAFecha = T001515_A86RFF_COMPRADAFecha[0];
            AssignAttri("", false, "A86RFF_COMPRADAFecha", context.localUtil.Format(A86RFF_COMPRADAFecha, "99/99/99"));
            A5Cod_Area = T001515_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = T001515_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A87RFF_COMPRADAMes = T001515_A87RFF_COMPRADAMes[0];
            AssignAttri("", false, "A87RFF_COMPRADAMes", StringUtil.LTrimStr( (decimal)(A87RFF_COMPRADAMes), 4, 0));
            A88RFF_COMPRADAAno = T001515_A88RFF_COMPRADAAno[0];
            AssignAttri("", false, "A88RFF_COMPRADAAno", StringUtil.LTrimStr( (decimal)(A88RFF_COMPRADAAno), 4, 0));
            A89RFF_COMPRAPRODUCUP = T001515_A89RFF_COMPRAPRODUCUP[0];
            AssignAttri("", false, "A89RFF_COMPRAPRODUCUP", A89RFF_COMPRAPRODUCUP);
         }
      }

      protected void ScanEnd1542( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm1542( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1542( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1542( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1542( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1542( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1542( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1542( )
      {
         edtRFF_COMPRADAFecha_Enabled = 0;
         AssignProp("", false, edtRFF_COMPRADAFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRFF_COMPRADAFecha_Enabled), 5, 0), true);
         edtCod_Area_Enabled = 0;
         AssignProp("", false, edtCod_Area_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCod_Area_Enabled), 5, 0), true);
         edtIndicadoresCodigo_Enabled = 0;
         AssignProp("", false, edtIndicadoresCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIndicadoresCodigo_Enabled), 5, 0), true);
         edtRFF_COMPRADAMes_Enabled = 0;
         AssignProp("", false, edtRFF_COMPRADAMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRFF_COMPRADAMes_Enabled), 5, 0), true);
         edtRFF_COMPRADAAno_Enabled = 0;
         AssignProp("", false, edtRFF_COMPRADAAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRFF_COMPRADAAno_Enabled), 5, 0), true);
         edtRFF_COMPRAPRODUCUP_Enabled = 0;
         AssignProp("", false, edtRFF_COMPRAPRODUCUP_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRFF_COMPRAPRODUCUP_Enabled), 5, 0), true);
         edtRFF_COMPRATON_Enabled = 0;
         AssignProp("", false, edtRFF_COMPRATON_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRFF_COMPRATON_Enabled), 5, 0), true);
         edtRFF_COMPRAPROVEE_Enabled = 0;
         AssignProp("", false, edtRFF_COMPRAPROVEE_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRFF_COMPRAPROVEE_Enabled), 5, 0), true);
         edtRFF_COMPRAFINCA_Enabled = 0;
         AssignProp("", false, edtRFF_COMPRAFINCA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRFF_COMPRAFINCA_Enabled), 5, 0), true);
         edtRFF_COMPRAZONA_Enabled = 0;
         AssignProp("", false, edtRFF_COMPRAZONA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRFF_COMPRAZONA_Enabled), 5, 0), true);
         edtRFF_COMPRAVEREDAID_Enabled = 0;
         AssignProp("", false, edtRFF_COMPRAVEREDAID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRFF_COMPRAVEREDAID_Enabled), 5, 0), true);
         edtRFF_COMPRAVEREDANOM_Enabled = 0;
         AssignProp("", false, edtRFF_COMPRAVEREDANOM_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRFF_COMPRAVEREDANOM_Enabled), 5, 0), true);
         edtRFF_COMPRAMUNIID_Enabled = 0;
         AssignProp("", false, edtRFF_COMPRAMUNIID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRFF_COMPRAMUNIID_Enabled), 5, 0), true);
         edtRFF_COMPRAMUNINOM_Enabled = 0;
         AssignProp("", false, edtRFF_COMPRAMUNINOM_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRFF_COMPRAMUNINOM_Enabled), 5, 0), true);
         edtRFF_COMPRADEPTOID_Enabled = 0;
         AssignProp("", false, edtRFF_COMPRADEPTOID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRFF_COMPRADEPTOID_Enabled), 5, 0), true);
         edtRFF_COMPRADEPTONOM_Enabled = 0;
         AssignProp("", false, edtRFF_COMPRADEPTONOM_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRFF_COMPRADEPTONOM_Enabled), 5, 0), true);
         edtRFF_COMPRACLASIFIC_Enabled = 0;
         AssignProp("", false, edtRFF_COMPRACLASIFIC_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRFF_COMPRACLASIFIC_Enabled), 5, 0), true);
         edtRFF_COMPRATAMANO_Enabled = 0;
         AssignProp("", false, edtRFF_COMPRATAMANO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRFF_COMPRATAMANO_Enabled), 5, 0), true);
         edtRFF_COMPRAHAS_Enabled = 0;
         AssignProp("", false, edtRFF_COMPRAHAS_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRFF_COMPRAHAS_Enabled), 5, 0), true);
         edtRFF_COMPRADISTAKM_Enabled = 0;
         AssignProp("", false, edtRFF_COMPRADISTAKM_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRFF_COMPRADISTAKM_Enabled), 5, 0), true);
         edtRFF_COMPRARANDISTAN_Enabled = 0;
         AssignProp("", false, edtRFF_COMPRARANDISTAN_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRFF_COMPRARANDISTAN_Enabled), 5, 0), true);
         edtRFF_COMPRAIDACOMPANAM_Enabled = 0;
         AssignProp("", false, edtRFF_COMPRAIDACOMPANAM_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRFF_COMPRAIDACOMPANAM_Enabled), 5, 0), true);
         edtRFF_COMPRAACOMPANANOM_Enabled = 0;
         AssignProp("", false, edtRFF_COMPRAACOMPANANOM_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRFF_COMPRAACOMPANANOM_Enabled), 5, 0), true);
         edtRFF_COMPRARSPO_Enabled = 0;
         AssignProp("", false, edtRFF_COMPRARSPO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRFF_COMPRARSPO_Enabled), 5, 0), true);
         edtRFF_COMPRANATURALEZA_Enabled = 0;
         AssignProp("", false, edtRFF_COMPRANATURALEZA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRFF_COMPRANATURALEZA_Enabled), 5, 0), true);
         edtRFF_COMPRACOORDX_Enabled = 0;
         AssignProp("", false, edtRFF_COMPRACOORDX_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRFF_COMPRACOORDX_Enabled), 5, 0), true);
         edtRFF_COMPRACOORDY_Enabled = 0;
         AssignProp("", false, edtRFF_COMPRACOORDY_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRFF_COMPRACOORDY_Enabled), 5, 0), true);
         edtRFF_COMPRAEDADRANGO_Enabled = 0;
         AssignProp("", false, edtRFF_COMPRAEDADRANGO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRFF_COMPRAEDADRANGO_Enabled), 5, 0), true);
         edtRFF_COMPRAMATERIAL_Enabled = 0;
         AssignProp("", false, edtRFF_COMPRAMATERIAL_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRFF_COMPRAMATERIAL_Enabled), 5, 0), true);
         edtRFF_COMPRACOMITE_Enabled = 0;
         AssignProp("", false, edtRFF_COMPRACOMITE_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRFF_COMPRACOMITE_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1542( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues150( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("rff_comprada.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z86RFF_COMPRADAFecha", context.localUtil.DToC( Z86RFF_COMPRADAFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z5Cod_Area", Z5Cod_Area);
         GxWebStd.gx_hidden_field( context, "Z4IndicadoresCodigo", Z4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "Z87RFF_COMPRADAMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z87RFF_COMPRADAMes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z88RFF_COMPRADAAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z88RFF_COMPRADAAno), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z89RFF_COMPRAPRODUCUP", StringUtil.RTrim( Z89RFF_COMPRAPRODUCUP));
         GxWebStd.gx_hidden_field( context, "Z238RFF_COMPRATON", StringUtil.LTrim( StringUtil.NToC( Z238RFF_COMPRATON, 12, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z239RFF_COMPRAPROVEE", Z239RFF_COMPRAPROVEE);
         GxWebStd.gx_hidden_field( context, "Z240RFF_COMPRAFINCA", Z240RFF_COMPRAFINCA);
         GxWebStd.gx_hidden_field( context, "Z241RFF_COMPRAZONA", Z241RFF_COMPRAZONA);
         GxWebStd.gx_hidden_field( context, "Z242RFF_COMPRAVEREDAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z242RFF_COMPRAVEREDAID), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z243RFF_COMPRAVEREDANOM", Z243RFF_COMPRAVEREDANOM);
         GxWebStd.gx_hidden_field( context, "Z244RFF_COMPRAMUNIID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z244RFF_COMPRAMUNIID), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z245RFF_COMPRAMUNINOM", Z245RFF_COMPRAMUNINOM);
         GxWebStd.gx_hidden_field( context, "Z246RFF_COMPRADEPTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z246RFF_COMPRADEPTOID), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z247RFF_COMPRADEPTONOM", Z247RFF_COMPRADEPTONOM);
         GxWebStd.gx_hidden_field( context, "Z248RFF_COMPRACLASIFIC", Z248RFF_COMPRACLASIFIC);
         GxWebStd.gx_hidden_field( context, "Z249RFF_COMPRATAMANO", Z249RFF_COMPRATAMANO);
         GxWebStd.gx_hidden_field( context, "Z250RFF_COMPRAHAS", StringUtil.LTrim( StringUtil.NToC( Z250RFF_COMPRAHAS, 16, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z251RFF_COMPRADISTAKM", StringUtil.LTrim( StringUtil.NToC( Z251RFF_COMPRADISTAKM, 10, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z252RFF_COMPRARANDISTAN", Z252RFF_COMPRARANDISTAN);
         GxWebStd.gx_hidden_field( context, "Z253RFF_COMPRAIDACOMPANAM", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z253RFF_COMPRAIDACOMPANAM), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z254RFF_COMPRAACOMPANANOM", Z254RFF_COMPRAACOMPANANOM);
         GxWebStd.gx_hidden_field( context, "Z255RFF_COMPRARSPO", Z255RFF_COMPRARSPO);
         GxWebStd.gx_hidden_field( context, "Z256RFF_COMPRANATURALEZA", Z256RFF_COMPRANATURALEZA);
         GxWebStd.gx_hidden_field( context, "Z257RFF_COMPRACOORDX", Z257RFF_COMPRACOORDX);
         GxWebStd.gx_hidden_field( context, "Z258RFF_COMPRACOORDY", Z258RFF_COMPRACOORDY);
         GxWebStd.gx_hidden_field( context, "Z259RFF_COMPRAEDADRANGO", Z259RFF_COMPRAEDADRANGO);
         GxWebStd.gx_hidden_field( context, "Z260RFF_COMPRAMATERIAL", Z260RFF_COMPRAMATERIAL);
         GxWebStd.gx_hidden_field( context, "Z261RFF_COMPRACOMITE", Z261RFF_COMPRACOMITE);
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
         return formatLink("rff_comprada.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "RFF_COMPRADA" ;
      }

      public override string GetPgmdesc( )
      {
         return "RFF_COMPRADA" ;
      }

      protected void InitializeNonKey1542( )
      {
         A238RFF_COMPRATON = 0;
         n238RFF_COMPRATON = false;
         AssignAttri("", false, "A238RFF_COMPRATON", StringUtil.LTrimStr( A238RFF_COMPRATON, 12, 2));
         n238RFF_COMPRATON = ((Convert.ToDecimal(0)==A238RFF_COMPRATON) ? true : false);
         A239RFF_COMPRAPROVEE = "";
         n239RFF_COMPRAPROVEE = false;
         AssignAttri("", false, "A239RFF_COMPRAPROVEE", A239RFF_COMPRAPROVEE);
         n239RFF_COMPRAPROVEE = (String.IsNullOrEmpty(StringUtil.RTrim( A239RFF_COMPRAPROVEE)) ? true : false);
         A240RFF_COMPRAFINCA = "";
         n240RFF_COMPRAFINCA = false;
         AssignAttri("", false, "A240RFF_COMPRAFINCA", A240RFF_COMPRAFINCA);
         n240RFF_COMPRAFINCA = (String.IsNullOrEmpty(StringUtil.RTrim( A240RFF_COMPRAFINCA)) ? true : false);
         A241RFF_COMPRAZONA = "";
         n241RFF_COMPRAZONA = false;
         AssignAttri("", false, "A241RFF_COMPRAZONA", A241RFF_COMPRAZONA);
         n241RFF_COMPRAZONA = (String.IsNullOrEmpty(StringUtil.RTrim( A241RFF_COMPRAZONA)) ? true : false);
         A242RFF_COMPRAVEREDAID = 0;
         n242RFF_COMPRAVEREDAID = false;
         AssignAttri("", false, "A242RFF_COMPRAVEREDAID", StringUtil.LTrimStr( (decimal)(A242RFF_COMPRAVEREDAID), 15, 0));
         n242RFF_COMPRAVEREDAID = ((0==A242RFF_COMPRAVEREDAID) ? true : false);
         A243RFF_COMPRAVEREDANOM = "";
         n243RFF_COMPRAVEREDANOM = false;
         AssignAttri("", false, "A243RFF_COMPRAVEREDANOM", A243RFF_COMPRAVEREDANOM);
         n243RFF_COMPRAVEREDANOM = (String.IsNullOrEmpty(StringUtil.RTrim( A243RFF_COMPRAVEREDANOM)) ? true : false);
         A244RFF_COMPRAMUNIID = 0;
         n244RFF_COMPRAMUNIID = false;
         AssignAttri("", false, "A244RFF_COMPRAMUNIID", StringUtil.LTrimStr( (decimal)(A244RFF_COMPRAMUNIID), 10, 0));
         n244RFF_COMPRAMUNIID = ((0==A244RFF_COMPRAMUNIID) ? true : false);
         A245RFF_COMPRAMUNINOM = "";
         n245RFF_COMPRAMUNINOM = false;
         AssignAttri("", false, "A245RFF_COMPRAMUNINOM", A245RFF_COMPRAMUNINOM);
         n245RFF_COMPRAMUNINOM = (String.IsNullOrEmpty(StringUtil.RTrim( A245RFF_COMPRAMUNINOM)) ? true : false);
         A246RFF_COMPRADEPTOID = 0;
         n246RFF_COMPRADEPTOID = false;
         AssignAttri("", false, "A246RFF_COMPRADEPTOID", StringUtil.LTrimStr( (decimal)(A246RFF_COMPRADEPTOID), 10, 0));
         n246RFF_COMPRADEPTOID = ((0==A246RFF_COMPRADEPTOID) ? true : false);
         A247RFF_COMPRADEPTONOM = "";
         n247RFF_COMPRADEPTONOM = false;
         AssignAttri("", false, "A247RFF_COMPRADEPTONOM", A247RFF_COMPRADEPTONOM);
         n247RFF_COMPRADEPTONOM = (String.IsNullOrEmpty(StringUtil.RTrim( A247RFF_COMPRADEPTONOM)) ? true : false);
         A248RFF_COMPRACLASIFIC = "";
         n248RFF_COMPRACLASIFIC = false;
         AssignAttri("", false, "A248RFF_COMPRACLASIFIC", A248RFF_COMPRACLASIFIC);
         n248RFF_COMPRACLASIFIC = (String.IsNullOrEmpty(StringUtil.RTrim( A248RFF_COMPRACLASIFIC)) ? true : false);
         A249RFF_COMPRATAMANO = "";
         n249RFF_COMPRATAMANO = false;
         AssignAttri("", false, "A249RFF_COMPRATAMANO", A249RFF_COMPRATAMANO);
         n249RFF_COMPRATAMANO = (String.IsNullOrEmpty(StringUtil.RTrim( A249RFF_COMPRATAMANO)) ? true : false);
         A250RFF_COMPRAHAS = 0;
         n250RFF_COMPRAHAS = false;
         AssignAttri("", false, "A250RFF_COMPRAHAS", StringUtil.LTrimStr( A250RFF_COMPRAHAS, 16, 2));
         n250RFF_COMPRAHAS = ((Convert.ToDecimal(0)==A250RFF_COMPRAHAS) ? true : false);
         A251RFF_COMPRADISTAKM = 0;
         n251RFF_COMPRADISTAKM = false;
         AssignAttri("", false, "A251RFF_COMPRADISTAKM", StringUtil.LTrimStr( A251RFF_COMPRADISTAKM, 10, 2));
         n251RFF_COMPRADISTAKM = ((Convert.ToDecimal(0)==A251RFF_COMPRADISTAKM) ? true : false);
         A252RFF_COMPRARANDISTAN = "";
         n252RFF_COMPRARANDISTAN = false;
         AssignAttri("", false, "A252RFF_COMPRARANDISTAN", A252RFF_COMPRARANDISTAN);
         n252RFF_COMPRARANDISTAN = (String.IsNullOrEmpty(StringUtil.RTrim( A252RFF_COMPRARANDISTAN)) ? true : false);
         A253RFF_COMPRAIDACOMPANAM = 0;
         n253RFF_COMPRAIDACOMPANAM = false;
         AssignAttri("", false, "A253RFF_COMPRAIDACOMPANAM", StringUtil.LTrimStr( (decimal)(A253RFF_COMPRAIDACOMPANAM), 15, 0));
         n253RFF_COMPRAIDACOMPANAM = ((0==A253RFF_COMPRAIDACOMPANAM) ? true : false);
         A254RFF_COMPRAACOMPANANOM = "";
         n254RFF_COMPRAACOMPANANOM = false;
         AssignAttri("", false, "A254RFF_COMPRAACOMPANANOM", A254RFF_COMPRAACOMPANANOM);
         n254RFF_COMPRAACOMPANANOM = (String.IsNullOrEmpty(StringUtil.RTrim( A254RFF_COMPRAACOMPANANOM)) ? true : false);
         A255RFF_COMPRARSPO = "";
         n255RFF_COMPRARSPO = false;
         AssignAttri("", false, "A255RFF_COMPRARSPO", A255RFF_COMPRARSPO);
         n255RFF_COMPRARSPO = (String.IsNullOrEmpty(StringUtil.RTrim( A255RFF_COMPRARSPO)) ? true : false);
         A256RFF_COMPRANATURALEZA = "";
         n256RFF_COMPRANATURALEZA = false;
         AssignAttri("", false, "A256RFF_COMPRANATURALEZA", A256RFF_COMPRANATURALEZA);
         n256RFF_COMPRANATURALEZA = (String.IsNullOrEmpty(StringUtil.RTrim( A256RFF_COMPRANATURALEZA)) ? true : false);
         A257RFF_COMPRACOORDX = "";
         n257RFF_COMPRACOORDX = false;
         AssignAttri("", false, "A257RFF_COMPRACOORDX", A257RFF_COMPRACOORDX);
         n257RFF_COMPRACOORDX = (String.IsNullOrEmpty(StringUtil.RTrim( A257RFF_COMPRACOORDX)) ? true : false);
         A258RFF_COMPRACOORDY = "";
         n258RFF_COMPRACOORDY = false;
         AssignAttri("", false, "A258RFF_COMPRACOORDY", A258RFF_COMPRACOORDY);
         n258RFF_COMPRACOORDY = (String.IsNullOrEmpty(StringUtil.RTrim( A258RFF_COMPRACOORDY)) ? true : false);
         A259RFF_COMPRAEDADRANGO = "";
         n259RFF_COMPRAEDADRANGO = false;
         AssignAttri("", false, "A259RFF_COMPRAEDADRANGO", A259RFF_COMPRAEDADRANGO);
         n259RFF_COMPRAEDADRANGO = (String.IsNullOrEmpty(StringUtil.RTrim( A259RFF_COMPRAEDADRANGO)) ? true : false);
         A260RFF_COMPRAMATERIAL = "";
         n260RFF_COMPRAMATERIAL = false;
         AssignAttri("", false, "A260RFF_COMPRAMATERIAL", A260RFF_COMPRAMATERIAL);
         n260RFF_COMPRAMATERIAL = (String.IsNullOrEmpty(StringUtil.RTrim( A260RFF_COMPRAMATERIAL)) ? true : false);
         A261RFF_COMPRACOMITE = "";
         n261RFF_COMPRACOMITE = false;
         AssignAttri("", false, "A261RFF_COMPRACOMITE", A261RFF_COMPRACOMITE);
         n261RFF_COMPRACOMITE = (String.IsNullOrEmpty(StringUtil.RTrim( A261RFF_COMPRACOMITE)) ? true : false);
         Z238RFF_COMPRATON = 0;
         Z239RFF_COMPRAPROVEE = "";
         Z240RFF_COMPRAFINCA = "";
         Z241RFF_COMPRAZONA = "";
         Z242RFF_COMPRAVEREDAID = 0;
         Z243RFF_COMPRAVEREDANOM = "";
         Z244RFF_COMPRAMUNIID = 0;
         Z245RFF_COMPRAMUNINOM = "";
         Z246RFF_COMPRADEPTOID = 0;
         Z247RFF_COMPRADEPTONOM = "";
         Z248RFF_COMPRACLASIFIC = "";
         Z249RFF_COMPRATAMANO = "";
         Z250RFF_COMPRAHAS = 0;
         Z251RFF_COMPRADISTAKM = 0;
         Z252RFF_COMPRARANDISTAN = "";
         Z253RFF_COMPRAIDACOMPANAM = 0;
         Z254RFF_COMPRAACOMPANANOM = "";
         Z255RFF_COMPRARSPO = "";
         Z256RFF_COMPRANATURALEZA = "";
         Z257RFF_COMPRACOORDX = "";
         Z258RFF_COMPRACOORDY = "";
         Z259RFF_COMPRAEDADRANGO = "";
         Z260RFF_COMPRAMATERIAL = "";
         Z261RFF_COMPRACOMITE = "";
      }

      protected void InitAll1542( )
      {
         A86RFF_COMPRADAFecha = DateTime.MinValue;
         AssignAttri("", false, "A86RFF_COMPRADAFecha", context.localUtil.Format(A86RFF_COMPRADAFecha, "99/99/99"));
         A5Cod_Area = "";
         AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
         A4IndicadoresCodigo = "";
         AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
         A87RFF_COMPRADAMes = 0;
         AssignAttri("", false, "A87RFF_COMPRADAMes", StringUtil.LTrimStr( (decimal)(A87RFF_COMPRADAMes), 4, 0));
         A88RFF_COMPRADAAno = 0;
         AssignAttri("", false, "A88RFF_COMPRADAAno", StringUtil.LTrimStr( (decimal)(A88RFF_COMPRADAAno), 4, 0));
         A89RFF_COMPRAPRODUCUP = "";
         AssignAttri("", false, "A89RFF_COMPRAPRODUCUP", A89RFF_COMPRAPRODUCUP);
         InitializeNonKey1542( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20247231025912", true, true);
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
         context.AddJavascriptSource("rff_comprada.js", "?20247231025912", false, true);
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
         edtRFF_COMPRADAFecha_Internalname = "RFF_COMPRADAFECHA";
         edtCod_Area_Internalname = "COD_AREA";
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO";
         edtRFF_COMPRADAMes_Internalname = "RFF_COMPRADAMES";
         edtRFF_COMPRADAAno_Internalname = "RFF_COMPRADAANO";
         edtRFF_COMPRAPRODUCUP_Internalname = "RFF_COMPRAPRODUCUP";
         edtRFF_COMPRATON_Internalname = "RFF_COMPRATON";
         edtRFF_COMPRAPROVEE_Internalname = "RFF_COMPRAPROVEE";
         edtRFF_COMPRAFINCA_Internalname = "RFF_COMPRAFINCA";
         edtRFF_COMPRAZONA_Internalname = "RFF_COMPRAZONA";
         edtRFF_COMPRAVEREDAID_Internalname = "RFF_COMPRAVEREDAID";
         edtRFF_COMPRAVEREDANOM_Internalname = "RFF_COMPRAVEREDANOM";
         edtRFF_COMPRAMUNIID_Internalname = "RFF_COMPRAMUNIID";
         edtRFF_COMPRAMUNINOM_Internalname = "RFF_COMPRAMUNINOM";
         edtRFF_COMPRADEPTOID_Internalname = "RFF_COMPRADEPTOID";
         edtRFF_COMPRADEPTONOM_Internalname = "RFF_COMPRADEPTONOM";
         edtRFF_COMPRACLASIFIC_Internalname = "RFF_COMPRACLASIFIC";
         edtRFF_COMPRATAMANO_Internalname = "RFF_COMPRATAMANO";
         edtRFF_COMPRAHAS_Internalname = "RFF_COMPRAHAS";
         edtRFF_COMPRADISTAKM_Internalname = "RFF_COMPRADISTAKM";
         edtRFF_COMPRARANDISTAN_Internalname = "RFF_COMPRARANDISTAN";
         edtRFF_COMPRAIDACOMPANAM_Internalname = "RFF_COMPRAIDACOMPANAM";
         edtRFF_COMPRAACOMPANANOM_Internalname = "RFF_COMPRAACOMPANANOM";
         edtRFF_COMPRARSPO_Internalname = "RFF_COMPRARSPO";
         edtRFF_COMPRANATURALEZA_Internalname = "RFF_COMPRANATURALEZA";
         edtRFF_COMPRACOORDX_Internalname = "RFF_COMPRACOORDX";
         edtRFF_COMPRACOORDY_Internalname = "RFF_COMPRACOORDY";
         edtRFF_COMPRAEDADRANGO_Internalname = "RFF_COMPRAEDADRANGO";
         edtRFF_COMPRAMATERIAL_Internalname = "RFF_COMPRAMATERIAL";
         edtRFF_COMPRACOMITE_Internalname = "RFF_COMPRACOMITE";
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
         Form.Caption = "RFF_COMPRADA";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtRFF_COMPRACOMITE_Enabled = 1;
         edtRFF_COMPRAMATERIAL_Jsonclick = "";
         edtRFF_COMPRAMATERIAL_Enabled = 1;
         edtRFF_COMPRAEDADRANGO_Jsonclick = "";
         edtRFF_COMPRAEDADRANGO_Enabled = 1;
         edtRFF_COMPRACOORDY_Jsonclick = "";
         edtRFF_COMPRACOORDY_Enabled = 1;
         edtRFF_COMPRACOORDX_Jsonclick = "";
         edtRFF_COMPRACOORDX_Enabled = 1;
         edtRFF_COMPRANATURALEZA_Jsonclick = "";
         edtRFF_COMPRANATURALEZA_Enabled = 1;
         edtRFF_COMPRARSPO_Jsonclick = "";
         edtRFF_COMPRARSPO_Enabled = 1;
         edtRFF_COMPRAACOMPANANOM_Enabled = 1;
         edtRFF_COMPRAIDACOMPANAM_Jsonclick = "";
         edtRFF_COMPRAIDACOMPANAM_Enabled = 1;
         edtRFF_COMPRARANDISTAN_Jsonclick = "";
         edtRFF_COMPRARANDISTAN_Enabled = 1;
         edtRFF_COMPRADISTAKM_Jsonclick = "";
         edtRFF_COMPRADISTAKM_Enabled = 1;
         edtRFF_COMPRAHAS_Jsonclick = "";
         edtRFF_COMPRAHAS_Enabled = 1;
         edtRFF_COMPRATAMANO_Jsonclick = "";
         edtRFF_COMPRATAMANO_Enabled = 1;
         edtRFF_COMPRACLASIFIC_Jsonclick = "";
         edtRFF_COMPRACLASIFIC_Enabled = 1;
         edtRFF_COMPRADEPTONOM_Enabled = 1;
         edtRFF_COMPRADEPTOID_Jsonclick = "";
         edtRFF_COMPRADEPTOID_Enabled = 1;
         edtRFF_COMPRAMUNINOM_Enabled = 1;
         edtRFF_COMPRAMUNIID_Jsonclick = "";
         edtRFF_COMPRAMUNIID_Enabled = 1;
         edtRFF_COMPRAVEREDANOM_Enabled = 1;
         edtRFF_COMPRAVEREDAID_Jsonclick = "";
         edtRFF_COMPRAVEREDAID_Enabled = 1;
         edtRFF_COMPRAZONA_Jsonclick = "";
         edtRFF_COMPRAZONA_Enabled = 1;
         edtRFF_COMPRAFINCA_Enabled = 1;
         edtRFF_COMPRAPROVEE_Enabled = 1;
         edtRFF_COMPRATON_Jsonclick = "";
         edtRFF_COMPRATON_Enabled = 1;
         edtRFF_COMPRAPRODUCUP_Jsonclick = "";
         edtRFF_COMPRAPRODUCUP_Enabled = 1;
         edtRFF_COMPRADAAno_Jsonclick = "";
         edtRFF_COMPRADAAno_Enabled = 1;
         edtRFF_COMPRADAMes_Jsonclick = "";
         edtRFF_COMPRADAMes_Enabled = 1;
         imgprompt_4_Visible = 1;
         imgprompt_4_Link = "";
         edtIndicadoresCodigo_Jsonclick = "";
         edtIndicadoresCodigo_Enabled = 1;
         imgprompt_5_Visible = 1;
         imgprompt_5_Link = "";
         edtCod_Area_Jsonclick = "";
         edtCod_Area_Enabled = 1;
         edtRFF_COMPRADAFecha_Jsonclick = "";
         edtRFF_COMPRADAFecha_Enabled = 1;
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
         /* Using cursor T001516 */
         pr_default.execute(14, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(14);
         /* Using cursor T001517 */
         pr_default.execute(15, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(15);
         GX_FocusControl = edtRFF_COMPRATON_Internalname;
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
         /* Using cursor T001516 */
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
         /* Using cursor T001517 */
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
      }

      public void Valid_Rff_compraproducup( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A238RFF_COMPRATON", StringUtil.LTrim( StringUtil.NToC( A238RFF_COMPRATON, 12, 2, ".", "")));
         AssignAttri("", false, "A239RFF_COMPRAPROVEE", A239RFF_COMPRAPROVEE);
         AssignAttri("", false, "A240RFF_COMPRAFINCA", A240RFF_COMPRAFINCA);
         AssignAttri("", false, "A241RFF_COMPRAZONA", A241RFF_COMPRAZONA);
         AssignAttri("", false, "A242RFF_COMPRAVEREDAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A242RFF_COMPRAVEREDAID), 15, 0, ".", "")));
         AssignAttri("", false, "A243RFF_COMPRAVEREDANOM", A243RFF_COMPRAVEREDANOM);
         AssignAttri("", false, "A244RFF_COMPRAMUNIID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A244RFF_COMPRAMUNIID), 10, 0, ".", "")));
         AssignAttri("", false, "A245RFF_COMPRAMUNINOM", A245RFF_COMPRAMUNINOM);
         AssignAttri("", false, "A246RFF_COMPRADEPTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A246RFF_COMPRADEPTOID), 10, 0, ".", "")));
         AssignAttri("", false, "A247RFF_COMPRADEPTONOM", A247RFF_COMPRADEPTONOM);
         AssignAttri("", false, "A248RFF_COMPRACLASIFIC", A248RFF_COMPRACLASIFIC);
         AssignAttri("", false, "A249RFF_COMPRATAMANO", A249RFF_COMPRATAMANO);
         AssignAttri("", false, "A250RFF_COMPRAHAS", StringUtil.LTrim( StringUtil.NToC( A250RFF_COMPRAHAS, 16, 2, ".", "")));
         AssignAttri("", false, "A251RFF_COMPRADISTAKM", StringUtil.LTrim( StringUtil.NToC( A251RFF_COMPRADISTAKM, 10, 2, ".", "")));
         AssignAttri("", false, "A252RFF_COMPRARANDISTAN", A252RFF_COMPRARANDISTAN);
         AssignAttri("", false, "A253RFF_COMPRAIDACOMPANAM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A253RFF_COMPRAIDACOMPANAM), 15, 0, ".", "")));
         AssignAttri("", false, "A254RFF_COMPRAACOMPANANOM", A254RFF_COMPRAACOMPANANOM);
         AssignAttri("", false, "A255RFF_COMPRARSPO", A255RFF_COMPRARSPO);
         AssignAttri("", false, "A256RFF_COMPRANATURALEZA", A256RFF_COMPRANATURALEZA);
         AssignAttri("", false, "A257RFF_COMPRACOORDX", A257RFF_COMPRACOORDX);
         AssignAttri("", false, "A258RFF_COMPRACOORDY", A258RFF_COMPRACOORDY);
         AssignAttri("", false, "A259RFF_COMPRAEDADRANGO", A259RFF_COMPRAEDADRANGO);
         AssignAttri("", false, "A260RFF_COMPRAMATERIAL", A260RFF_COMPRAMATERIAL);
         AssignAttri("", false, "A261RFF_COMPRACOMITE", A261RFF_COMPRACOMITE);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z86RFF_COMPRADAFecha", context.localUtil.Format(Z86RFF_COMPRADAFecha, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z5Cod_Area", Z5Cod_Area);
         GxWebStd.gx_hidden_field( context, "Z4IndicadoresCodigo", Z4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "Z87RFF_COMPRADAMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z87RFF_COMPRADAMes), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z88RFF_COMPRADAAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z88RFF_COMPRADAAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z89RFF_COMPRAPRODUCUP", StringUtil.RTrim( Z89RFF_COMPRAPRODUCUP));
         GxWebStd.gx_hidden_field( context, "Z238RFF_COMPRATON", StringUtil.LTrim( StringUtil.NToC( Z238RFF_COMPRATON, 12, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z239RFF_COMPRAPROVEE", Z239RFF_COMPRAPROVEE);
         GxWebStd.gx_hidden_field( context, "Z240RFF_COMPRAFINCA", Z240RFF_COMPRAFINCA);
         GxWebStd.gx_hidden_field( context, "Z241RFF_COMPRAZONA", Z241RFF_COMPRAZONA);
         GxWebStd.gx_hidden_field( context, "Z242RFF_COMPRAVEREDAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z242RFF_COMPRAVEREDAID), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z243RFF_COMPRAVEREDANOM", Z243RFF_COMPRAVEREDANOM);
         GxWebStd.gx_hidden_field( context, "Z244RFF_COMPRAMUNIID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z244RFF_COMPRAMUNIID), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z245RFF_COMPRAMUNINOM", Z245RFF_COMPRAMUNINOM);
         GxWebStd.gx_hidden_field( context, "Z246RFF_COMPRADEPTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z246RFF_COMPRADEPTOID), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z247RFF_COMPRADEPTONOM", Z247RFF_COMPRADEPTONOM);
         GxWebStd.gx_hidden_field( context, "Z248RFF_COMPRACLASIFIC", Z248RFF_COMPRACLASIFIC);
         GxWebStd.gx_hidden_field( context, "Z249RFF_COMPRATAMANO", Z249RFF_COMPRATAMANO);
         GxWebStd.gx_hidden_field( context, "Z250RFF_COMPRAHAS", StringUtil.LTrim( StringUtil.NToC( Z250RFF_COMPRAHAS, 16, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z251RFF_COMPRADISTAKM", StringUtil.LTrim( StringUtil.NToC( Z251RFF_COMPRADISTAKM, 10, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z252RFF_COMPRARANDISTAN", Z252RFF_COMPRARANDISTAN);
         GxWebStd.gx_hidden_field( context, "Z253RFF_COMPRAIDACOMPANAM", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z253RFF_COMPRAIDACOMPANAM), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z254RFF_COMPRAACOMPANANOM", Z254RFF_COMPRAACOMPANANOM);
         GxWebStd.gx_hidden_field( context, "Z255RFF_COMPRARSPO", Z255RFF_COMPRARSPO);
         GxWebStd.gx_hidden_field( context, "Z256RFF_COMPRANATURALEZA", Z256RFF_COMPRANATURALEZA);
         GxWebStd.gx_hidden_field( context, "Z257RFF_COMPRACOORDX", Z257RFF_COMPRACOORDX);
         GxWebStd.gx_hidden_field( context, "Z258RFF_COMPRACOORDY", Z258RFF_COMPRACOORDY);
         GxWebStd.gx_hidden_field( context, "Z259RFF_COMPRAEDADRANGO", Z259RFF_COMPRAEDADRANGO);
         GxWebStd.gx_hidden_field( context, "Z260RFF_COMPRAMATERIAL", Z260RFF_COMPRAMATERIAL);
         GxWebStd.gx_hidden_field( context, "Z261RFF_COMPRACOMITE", Z261RFF_COMPRACOMITE);
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
         setEventMetadata("VALID_RFF_COMPRADAFECHA","{handler:'Valid_Rff_compradafecha',iparms:[]");
         setEventMetadata("VALID_RFF_COMPRADAFECHA",",oparms:[]}");
         setEventMetadata("VALID_COD_AREA","{handler:'Valid_Cod_area',iparms:[{av:'A5Cod_Area',fld:'COD_AREA',pic:''}]");
         setEventMetadata("VALID_COD_AREA",",oparms:[]}");
         setEventMetadata("VALID_INDICADORESCODIGO","{handler:'Valid_Indicadorescodigo',iparms:[{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:''}]");
         setEventMetadata("VALID_INDICADORESCODIGO",",oparms:[]}");
         setEventMetadata("VALID_RFF_COMPRADAMES","{handler:'Valid_Rff_compradames',iparms:[]");
         setEventMetadata("VALID_RFF_COMPRADAMES",",oparms:[]}");
         setEventMetadata("VALID_RFF_COMPRADAANO","{handler:'Valid_Rff_compradaano',iparms:[]");
         setEventMetadata("VALID_RFF_COMPRADAANO",",oparms:[]}");
         setEventMetadata("VALID_RFF_COMPRAPRODUCUP","{handler:'Valid_Rff_compraproducup',iparms:[{av:'A86RFF_COMPRADAFecha',fld:'RFF_COMPRADAFECHA',pic:''},{av:'A5Cod_Area',fld:'COD_AREA',pic:''},{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:''},{av:'A87RFF_COMPRADAMes',fld:'RFF_COMPRADAMES',pic:'ZZZ9'},{av:'A88RFF_COMPRADAAno',fld:'RFF_COMPRADAANO',pic:'ZZZ9'},{av:'A89RFF_COMPRAPRODUCUP',fld:'RFF_COMPRAPRODUCUP',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_RFF_COMPRAPRODUCUP",",oparms:[{av:'A238RFF_COMPRATON',fld:'RFF_COMPRATON',pic:'ZZZZZZZZ9.99'},{av:'A239RFF_COMPRAPROVEE',fld:'RFF_COMPRAPROVEE',pic:''},{av:'A240RFF_COMPRAFINCA',fld:'RFF_COMPRAFINCA',pic:''},{av:'A241RFF_COMPRAZONA',fld:'RFF_COMPRAZONA',pic:''},{av:'A242RFF_COMPRAVEREDAID',fld:'RFF_COMPRAVEREDAID',pic:'ZZZZZZZZZZZZZZ9'},{av:'A243RFF_COMPRAVEREDANOM',fld:'RFF_COMPRAVEREDANOM',pic:''},{av:'A244RFF_COMPRAMUNIID',fld:'RFF_COMPRAMUNIID',pic:'ZZZZZZZZZ9'},{av:'A245RFF_COMPRAMUNINOM',fld:'RFF_COMPRAMUNINOM',pic:''},{av:'A246RFF_COMPRADEPTOID',fld:'RFF_COMPRADEPTOID',pic:'ZZZZZZZZZ9'},{av:'A247RFF_COMPRADEPTONOM',fld:'RFF_COMPRADEPTONOM',pic:''},{av:'A248RFF_COMPRACLASIFIC',fld:'RFF_COMPRACLASIFIC',pic:''},{av:'A249RFF_COMPRATAMANO',fld:'RFF_COMPRATAMANO',pic:''},{av:'A250RFF_COMPRAHAS',fld:'RFF_COMPRAHAS',pic:'ZZZZZZZZZZZZ9.99'},{av:'A251RFF_COMPRADISTAKM',fld:'RFF_COMPRADISTAKM',pic:'ZZZZZZ9.99'},{av:'A252RFF_COMPRARANDISTAN',fld:'RFF_COMPRARANDISTAN',pic:''},{av:'A253RFF_COMPRAIDACOMPANAM',fld:'RFF_COMPRAIDACOMPANAM',pic:'ZZZZZZZZZZZZZZ9'},{av:'A254RFF_COMPRAACOMPANANOM',fld:'RFF_COMPRAACOMPANANOM',pic:''},{av:'A255RFF_COMPRARSPO',fld:'RFF_COMPRARSPO',pic:''},{av:'A256RFF_COMPRANATURALEZA',fld:'RFF_COMPRANATURALEZA',pic:''},{av:'A257RFF_COMPRACOORDX',fld:'RFF_COMPRACOORDX',pic:''},{av:'A258RFF_COMPRACOORDY',fld:'RFF_COMPRACOORDY',pic:''},{av:'A259RFF_COMPRAEDADRANGO',fld:'RFF_COMPRAEDADRANGO',pic:''},{av:'A260RFF_COMPRAMATERIAL',fld:'RFF_COMPRAMATERIAL',pic:''},{av:'A261RFF_COMPRACOMITE',fld:'RFF_COMPRACOMITE',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z86RFF_COMPRADAFecha'},{av:'Z5Cod_Area'},{av:'Z4IndicadoresCodigo'},{av:'Z87RFF_COMPRADAMes'},{av:'Z88RFF_COMPRADAAno'},{av:'Z89RFF_COMPRAPRODUCUP'},{av:'Z238RFF_COMPRATON'},{av:'Z239RFF_COMPRAPROVEE'},{av:'Z240RFF_COMPRAFINCA'},{av:'Z241RFF_COMPRAZONA'},{av:'Z242RFF_COMPRAVEREDAID'},{av:'Z243RFF_COMPRAVEREDANOM'},{av:'Z244RFF_COMPRAMUNIID'},{av:'Z245RFF_COMPRAMUNINOM'},{av:'Z246RFF_COMPRADEPTOID'},{av:'Z247RFF_COMPRADEPTONOM'},{av:'Z248RFF_COMPRACLASIFIC'},{av:'Z249RFF_COMPRATAMANO'},{av:'Z250RFF_COMPRAHAS'},{av:'Z251RFF_COMPRADISTAKM'},{av:'Z252RFF_COMPRARANDISTAN'},{av:'Z253RFF_COMPRAIDACOMPANAM'},{av:'Z254RFF_COMPRAACOMPANANOM'},{av:'Z255RFF_COMPRARSPO'},{av:'Z256RFF_COMPRANATURALEZA'},{av:'Z257RFF_COMPRACOORDX'},{av:'Z258RFF_COMPRACOORDY'},{av:'Z259RFF_COMPRAEDADRANGO'},{av:'Z260RFF_COMPRAMATERIAL'},{av:'Z261RFF_COMPRACOMITE'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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
         Z86RFF_COMPRADAFecha = DateTime.MinValue;
         Z5Cod_Area = "";
         Z4IndicadoresCodigo = "";
         Z89RFF_COMPRAPRODUCUP = "";
         Z239RFF_COMPRAPROVEE = "";
         Z240RFF_COMPRAFINCA = "";
         Z241RFF_COMPRAZONA = "";
         Z243RFF_COMPRAVEREDANOM = "";
         Z245RFF_COMPRAMUNINOM = "";
         Z247RFF_COMPRADEPTONOM = "";
         Z248RFF_COMPRACLASIFIC = "";
         Z249RFF_COMPRATAMANO = "";
         Z252RFF_COMPRARANDISTAN = "";
         Z254RFF_COMPRAACOMPANANOM = "";
         Z255RFF_COMPRARSPO = "";
         Z256RFF_COMPRANATURALEZA = "";
         Z257RFF_COMPRACOORDX = "";
         Z258RFF_COMPRACOORDY = "";
         Z259RFF_COMPRAEDADRANGO = "";
         Z260RFF_COMPRAMATERIAL = "";
         Z261RFF_COMPRACOMITE = "";
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
         A86RFF_COMPRADAFecha = DateTime.MinValue;
         imgprompt_5_gximage = "";
         sImgUrl = "";
         imgprompt_4_gximage = "";
         A89RFF_COMPRAPRODUCUP = "";
         A239RFF_COMPRAPROVEE = "";
         A240RFF_COMPRAFINCA = "";
         A241RFF_COMPRAZONA = "";
         A243RFF_COMPRAVEREDANOM = "";
         A245RFF_COMPRAMUNINOM = "";
         A247RFF_COMPRADEPTONOM = "";
         A248RFF_COMPRACLASIFIC = "";
         A249RFF_COMPRATAMANO = "";
         A252RFF_COMPRARANDISTAN = "";
         A254RFF_COMPRAACOMPANANOM = "";
         A255RFF_COMPRARSPO = "";
         A256RFF_COMPRANATURALEZA = "";
         A257RFF_COMPRACOORDX = "";
         A258RFF_COMPRACOORDY = "";
         A259RFF_COMPRAEDADRANGO = "";
         A260RFF_COMPRAMATERIAL = "";
         A261RFF_COMPRACOMITE = "";
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
         T00156_A86RFF_COMPRADAFecha = new DateTime[] {DateTime.MinValue} ;
         T00156_A87RFF_COMPRADAMes = new short[1] ;
         T00156_A88RFF_COMPRADAAno = new short[1] ;
         T00156_A89RFF_COMPRAPRODUCUP = new string[] {""} ;
         T00156_A238RFF_COMPRATON = new decimal[1] ;
         T00156_n238RFF_COMPRATON = new bool[] {false} ;
         T00156_A239RFF_COMPRAPROVEE = new string[] {""} ;
         T00156_n239RFF_COMPRAPROVEE = new bool[] {false} ;
         T00156_A240RFF_COMPRAFINCA = new string[] {""} ;
         T00156_n240RFF_COMPRAFINCA = new bool[] {false} ;
         T00156_A241RFF_COMPRAZONA = new string[] {""} ;
         T00156_n241RFF_COMPRAZONA = new bool[] {false} ;
         T00156_A242RFF_COMPRAVEREDAID = new long[1] ;
         T00156_n242RFF_COMPRAVEREDAID = new bool[] {false} ;
         T00156_A243RFF_COMPRAVEREDANOM = new string[] {""} ;
         T00156_n243RFF_COMPRAVEREDANOM = new bool[] {false} ;
         T00156_A244RFF_COMPRAMUNIID = new long[1] ;
         T00156_n244RFF_COMPRAMUNIID = new bool[] {false} ;
         T00156_A245RFF_COMPRAMUNINOM = new string[] {""} ;
         T00156_n245RFF_COMPRAMUNINOM = new bool[] {false} ;
         T00156_A246RFF_COMPRADEPTOID = new long[1] ;
         T00156_n246RFF_COMPRADEPTOID = new bool[] {false} ;
         T00156_A247RFF_COMPRADEPTONOM = new string[] {""} ;
         T00156_n247RFF_COMPRADEPTONOM = new bool[] {false} ;
         T00156_A248RFF_COMPRACLASIFIC = new string[] {""} ;
         T00156_n248RFF_COMPRACLASIFIC = new bool[] {false} ;
         T00156_A249RFF_COMPRATAMANO = new string[] {""} ;
         T00156_n249RFF_COMPRATAMANO = new bool[] {false} ;
         T00156_A250RFF_COMPRAHAS = new decimal[1] ;
         T00156_n250RFF_COMPRAHAS = new bool[] {false} ;
         T00156_A251RFF_COMPRADISTAKM = new decimal[1] ;
         T00156_n251RFF_COMPRADISTAKM = new bool[] {false} ;
         T00156_A252RFF_COMPRARANDISTAN = new string[] {""} ;
         T00156_n252RFF_COMPRARANDISTAN = new bool[] {false} ;
         T00156_A253RFF_COMPRAIDACOMPANAM = new long[1] ;
         T00156_n253RFF_COMPRAIDACOMPANAM = new bool[] {false} ;
         T00156_A254RFF_COMPRAACOMPANANOM = new string[] {""} ;
         T00156_n254RFF_COMPRAACOMPANANOM = new bool[] {false} ;
         T00156_A255RFF_COMPRARSPO = new string[] {""} ;
         T00156_n255RFF_COMPRARSPO = new bool[] {false} ;
         T00156_A256RFF_COMPRANATURALEZA = new string[] {""} ;
         T00156_n256RFF_COMPRANATURALEZA = new bool[] {false} ;
         T00156_A257RFF_COMPRACOORDX = new string[] {""} ;
         T00156_n257RFF_COMPRACOORDX = new bool[] {false} ;
         T00156_A258RFF_COMPRACOORDY = new string[] {""} ;
         T00156_n258RFF_COMPRACOORDY = new bool[] {false} ;
         T00156_A259RFF_COMPRAEDADRANGO = new string[] {""} ;
         T00156_n259RFF_COMPRAEDADRANGO = new bool[] {false} ;
         T00156_A260RFF_COMPRAMATERIAL = new string[] {""} ;
         T00156_n260RFF_COMPRAMATERIAL = new bool[] {false} ;
         T00156_A261RFF_COMPRACOMITE = new string[] {""} ;
         T00156_n261RFF_COMPRACOMITE = new bool[] {false} ;
         T00156_A5Cod_Area = new string[] {""} ;
         T00156_A4IndicadoresCodigo = new string[] {""} ;
         T00154_A5Cod_Area = new string[] {""} ;
         T00155_A4IndicadoresCodigo = new string[] {""} ;
         T00157_A5Cod_Area = new string[] {""} ;
         T00158_A4IndicadoresCodigo = new string[] {""} ;
         T00159_A86RFF_COMPRADAFecha = new DateTime[] {DateTime.MinValue} ;
         T00159_A5Cod_Area = new string[] {""} ;
         T00159_A4IndicadoresCodigo = new string[] {""} ;
         T00159_A87RFF_COMPRADAMes = new short[1] ;
         T00159_A88RFF_COMPRADAAno = new short[1] ;
         T00159_A89RFF_COMPRAPRODUCUP = new string[] {""} ;
         T00153_A86RFF_COMPRADAFecha = new DateTime[] {DateTime.MinValue} ;
         T00153_A87RFF_COMPRADAMes = new short[1] ;
         T00153_A88RFF_COMPRADAAno = new short[1] ;
         T00153_A89RFF_COMPRAPRODUCUP = new string[] {""} ;
         T00153_A238RFF_COMPRATON = new decimal[1] ;
         T00153_n238RFF_COMPRATON = new bool[] {false} ;
         T00153_A239RFF_COMPRAPROVEE = new string[] {""} ;
         T00153_n239RFF_COMPRAPROVEE = new bool[] {false} ;
         T00153_A240RFF_COMPRAFINCA = new string[] {""} ;
         T00153_n240RFF_COMPRAFINCA = new bool[] {false} ;
         T00153_A241RFF_COMPRAZONA = new string[] {""} ;
         T00153_n241RFF_COMPRAZONA = new bool[] {false} ;
         T00153_A242RFF_COMPRAVEREDAID = new long[1] ;
         T00153_n242RFF_COMPRAVEREDAID = new bool[] {false} ;
         T00153_A243RFF_COMPRAVEREDANOM = new string[] {""} ;
         T00153_n243RFF_COMPRAVEREDANOM = new bool[] {false} ;
         T00153_A244RFF_COMPRAMUNIID = new long[1] ;
         T00153_n244RFF_COMPRAMUNIID = new bool[] {false} ;
         T00153_A245RFF_COMPRAMUNINOM = new string[] {""} ;
         T00153_n245RFF_COMPRAMUNINOM = new bool[] {false} ;
         T00153_A246RFF_COMPRADEPTOID = new long[1] ;
         T00153_n246RFF_COMPRADEPTOID = new bool[] {false} ;
         T00153_A247RFF_COMPRADEPTONOM = new string[] {""} ;
         T00153_n247RFF_COMPRADEPTONOM = new bool[] {false} ;
         T00153_A248RFF_COMPRACLASIFIC = new string[] {""} ;
         T00153_n248RFF_COMPRACLASIFIC = new bool[] {false} ;
         T00153_A249RFF_COMPRATAMANO = new string[] {""} ;
         T00153_n249RFF_COMPRATAMANO = new bool[] {false} ;
         T00153_A250RFF_COMPRAHAS = new decimal[1] ;
         T00153_n250RFF_COMPRAHAS = new bool[] {false} ;
         T00153_A251RFF_COMPRADISTAKM = new decimal[1] ;
         T00153_n251RFF_COMPRADISTAKM = new bool[] {false} ;
         T00153_A252RFF_COMPRARANDISTAN = new string[] {""} ;
         T00153_n252RFF_COMPRARANDISTAN = new bool[] {false} ;
         T00153_A253RFF_COMPRAIDACOMPANAM = new long[1] ;
         T00153_n253RFF_COMPRAIDACOMPANAM = new bool[] {false} ;
         T00153_A254RFF_COMPRAACOMPANANOM = new string[] {""} ;
         T00153_n254RFF_COMPRAACOMPANANOM = new bool[] {false} ;
         T00153_A255RFF_COMPRARSPO = new string[] {""} ;
         T00153_n255RFF_COMPRARSPO = new bool[] {false} ;
         T00153_A256RFF_COMPRANATURALEZA = new string[] {""} ;
         T00153_n256RFF_COMPRANATURALEZA = new bool[] {false} ;
         T00153_A257RFF_COMPRACOORDX = new string[] {""} ;
         T00153_n257RFF_COMPRACOORDX = new bool[] {false} ;
         T00153_A258RFF_COMPRACOORDY = new string[] {""} ;
         T00153_n258RFF_COMPRACOORDY = new bool[] {false} ;
         T00153_A259RFF_COMPRAEDADRANGO = new string[] {""} ;
         T00153_n259RFF_COMPRAEDADRANGO = new bool[] {false} ;
         T00153_A260RFF_COMPRAMATERIAL = new string[] {""} ;
         T00153_n260RFF_COMPRAMATERIAL = new bool[] {false} ;
         T00153_A261RFF_COMPRACOMITE = new string[] {""} ;
         T00153_n261RFF_COMPRACOMITE = new bool[] {false} ;
         T00153_A5Cod_Area = new string[] {""} ;
         T00153_A4IndicadoresCodigo = new string[] {""} ;
         sMode42 = "";
         T001510_A86RFF_COMPRADAFecha = new DateTime[] {DateTime.MinValue} ;
         T001510_A5Cod_Area = new string[] {""} ;
         T001510_A4IndicadoresCodigo = new string[] {""} ;
         T001510_A87RFF_COMPRADAMes = new short[1] ;
         T001510_A88RFF_COMPRADAAno = new short[1] ;
         T001510_A89RFF_COMPRAPRODUCUP = new string[] {""} ;
         T001511_A86RFF_COMPRADAFecha = new DateTime[] {DateTime.MinValue} ;
         T001511_A5Cod_Area = new string[] {""} ;
         T001511_A4IndicadoresCodigo = new string[] {""} ;
         T001511_A87RFF_COMPRADAMes = new short[1] ;
         T001511_A88RFF_COMPRADAAno = new short[1] ;
         T001511_A89RFF_COMPRAPRODUCUP = new string[] {""} ;
         T00152_A86RFF_COMPRADAFecha = new DateTime[] {DateTime.MinValue} ;
         T00152_A87RFF_COMPRADAMes = new short[1] ;
         T00152_A88RFF_COMPRADAAno = new short[1] ;
         T00152_A89RFF_COMPRAPRODUCUP = new string[] {""} ;
         T00152_A238RFF_COMPRATON = new decimal[1] ;
         T00152_n238RFF_COMPRATON = new bool[] {false} ;
         T00152_A239RFF_COMPRAPROVEE = new string[] {""} ;
         T00152_n239RFF_COMPRAPROVEE = new bool[] {false} ;
         T00152_A240RFF_COMPRAFINCA = new string[] {""} ;
         T00152_n240RFF_COMPRAFINCA = new bool[] {false} ;
         T00152_A241RFF_COMPRAZONA = new string[] {""} ;
         T00152_n241RFF_COMPRAZONA = new bool[] {false} ;
         T00152_A242RFF_COMPRAVEREDAID = new long[1] ;
         T00152_n242RFF_COMPRAVEREDAID = new bool[] {false} ;
         T00152_A243RFF_COMPRAVEREDANOM = new string[] {""} ;
         T00152_n243RFF_COMPRAVEREDANOM = new bool[] {false} ;
         T00152_A244RFF_COMPRAMUNIID = new long[1] ;
         T00152_n244RFF_COMPRAMUNIID = new bool[] {false} ;
         T00152_A245RFF_COMPRAMUNINOM = new string[] {""} ;
         T00152_n245RFF_COMPRAMUNINOM = new bool[] {false} ;
         T00152_A246RFF_COMPRADEPTOID = new long[1] ;
         T00152_n246RFF_COMPRADEPTOID = new bool[] {false} ;
         T00152_A247RFF_COMPRADEPTONOM = new string[] {""} ;
         T00152_n247RFF_COMPRADEPTONOM = new bool[] {false} ;
         T00152_A248RFF_COMPRACLASIFIC = new string[] {""} ;
         T00152_n248RFF_COMPRACLASIFIC = new bool[] {false} ;
         T00152_A249RFF_COMPRATAMANO = new string[] {""} ;
         T00152_n249RFF_COMPRATAMANO = new bool[] {false} ;
         T00152_A250RFF_COMPRAHAS = new decimal[1] ;
         T00152_n250RFF_COMPRAHAS = new bool[] {false} ;
         T00152_A251RFF_COMPRADISTAKM = new decimal[1] ;
         T00152_n251RFF_COMPRADISTAKM = new bool[] {false} ;
         T00152_A252RFF_COMPRARANDISTAN = new string[] {""} ;
         T00152_n252RFF_COMPRARANDISTAN = new bool[] {false} ;
         T00152_A253RFF_COMPRAIDACOMPANAM = new long[1] ;
         T00152_n253RFF_COMPRAIDACOMPANAM = new bool[] {false} ;
         T00152_A254RFF_COMPRAACOMPANANOM = new string[] {""} ;
         T00152_n254RFF_COMPRAACOMPANANOM = new bool[] {false} ;
         T00152_A255RFF_COMPRARSPO = new string[] {""} ;
         T00152_n255RFF_COMPRARSPO = new bool[] {false} ;
         T00152_A256RFF_COMPRANATURALEZA = new string[] {""} ;
         T00152_n256RFF_COMPRANATURALEZA = new bool[] {false} ;
         T00152_A257RFF_COMPRACOORDX = new string[] {""} ;
         T00152_n257RFF_COMPRACOORDX = new bool[] {false} ;
         T00152_A258RFF_COMPRACOORDY = new string[] {""} ;
         T00152_n258RFF_COMPRACOORDY = new bool[] {false} ;
         T00152_A259RFF_COMPRAEDADRANGO = new string[] {""} ;
         T00152_n259RFF_COMPRAEDADRANGO = new bool[] {false} ;
         T00152_A260RFF_COMPRAMATERIAL = new string[] {""} ;
         T00152_n260RFF_COMPRAMATERIAL = new bool[] {false} ;
         T00152_A261RFF_COMPRACOMITE = new string[] {""} ;
         T00152_n261RFF_COMPRACOMITE = new bool[] {false} ;
         T00152_A5Cod_Area = new string[] {""} ;
         T00152_A4IndicadoresCodigo = new string[] {""} ;
         T001515_A86RFF_COMPRADAFecha = new DateTime[] {DateTime.MinValue} ;
         T001515_A5Cod_Area = new string[] {""} ;
         T001515_A4IndicadoresCodigo = new string[] {""} ;
         T001515_A87RFF_COMPRADAMes = new short[1] ;
         T001515_A88RFF_COMPRADAAno = new short[1] ;
         T001515_A89RFF_COMPRAPRODUCUP = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T001516_A5Cod_Area = new string[] {""} ;
         T001517_A4IndicadoresCodigo = new string[] {""} ;
         ZZ86RFF_COMPRADAFecha = DateTime.MinValue;
         ZZ5Cod_Area = "";
         ZZ4IndicadoresCodigo = "";
         ZZ89RFF_COMPRAPRODUCUP = "";
         ZZ239RFF_COMPRAPROVEE = "";
         ZZ240RFF_COMPRAFINCA = "";
         ZZ241RFF_COMPRAZONA = "";
         ZZ243RFF_COMPRAVEREDANOM = "";
         ZZ245RFF_COMPRAMUNINOM = "";
         ZZ247RFF_COMPRADEPTONOM = "";
         ZZ248RFF_COMPRACLASIFIC = "";
         ZZ249RFF_COMPRATAMANO = "";
         ZZ252RFF_COMPRARANDISTAN = "";
         ZZ254RFF_COMPRAACOMPANANOM = "";
         ZZ255RFF_COMPRARSPO = "";
         ZZ256RFF_COMPRANATURALEZA = "";
         ZZ257RFF_COMPRACOORDX = "";
         ZZ258RFF_COMPRACOORDY = "";
         ZZ259RFF_COMPRAEDADRANGO = "";
         ZZ260RFF_COMPRAMATERIAL = "";
         ZZ261RFF_COMPRACOMITE = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rff_comprada__default(),
            new Object[][] {
                new Object[] {
               T00152_A86RFF_COMPRADAFecha, T00152_A87RFF_COMPRADAMes, T00152_A88RFF_COMPRADAAno, T00152_A89RFF_COMPRAPRODUCUP, T00152_A238RFF_COMPRATON, T00152_n238RFF_COMPRATON, T00152_A239RFF_COMPRAPROVEE, T00152_n239RFF_COMPRAPROVEE, T00152_A240RFF_COMPRAFINCA, T00152_n240RFF_COMPRAFINCA,
               T00152_A241RFF_COMPRAZONA, T00152_n241RFF_COMPRAZONA, T00152_A242RFF_COMPRAVEREDAID, T00152_n242RFF_COMPRAVEREDAID, T00152_A243RFF_COMPRAVEREDANOM, T00152_n243RFF_COMPRAVEREDANOM, T00152_A244RFF_COMPRAMUNIID, T00152_n244RFF_COMPRAMUNIID, T00152_A245RFF_COMPRAMUNINOM, T00152_n245RFF_COMPRAMUNINOM,
               T00152_A246RFF_COMPRADEPTOID, T00152_n246RFF_COMPRADEPTOID, T00152_A247RFF_COMPRADEPTONOM, T00152_n247RFF_COMPRADEPTONOM, T00152_A248RFF_COMPRACLASIFIC, T00152_n248RFF_COMPRACLASIFIC, T00152_A249RFF_COMPRATAMANO, T00152_n249RFF_COMPRATAMANO, T00152_A250RFF_COMPRAHAS, T00152_n250RFF_COMPRAHAS,
               T00152_A251RFF_COMPRADISTAKM, T00152_n251RFF_COMPRADISTAKM, T00152_A252RFF_COMPRARANDISTAN, T00152_n252RFF_COMPRARANDISTAN, T00152_A253RFF_COMPRAIDACOMPANAM, T00152_n253RFF_COMPRAIDACOMPANAM, T00152_A254RFF_COMPRAACOMPANANOM, T00152_n254RFF_COMPRAACOMPANANOM, T00152_A255RFF_COMPRARSPO, T00152_n255RFF_COMPRARSPO,
               T00152_A256RFF_COMPRANATURALEZA, T00152_n256RFF_COMPRANATURALEZA, T00152_A257RFF_COMPRACOORDX, T00152_n257RFF_COMPRACOORDX, T00152_A258RFF_COMPRACOORDY, T00152_n258RFF_COMPRACOORDY, T00152_A259RFF_COMPRAEDADRANGO, T00152_n259RFF_COMPRAEDADRANGO, T00152_A260RFF_COMPRAMATERIAL, T00152_n260RFF_COMPRAMATERIAL,
               T00152_A261RFF_COMPRACOMITE, T00152_n261RFF_COMPRACOMITE, T00152_A5Cod_Area, T00152_A4IndicadoresCodigo
               }
               , new Object[] {
               T00153_A86RFF_COMPRADAFecha, T00153_A87RFF_COMPRADAMes, T00153_A88RFF_COMPRADAAno, T00153_A89RFF_COMPRAPRODUCUP, T00153_A238RFF_COMPRATON, T00153_n238RFF_COMPRATON, T00153_A239RFF_COMPRAPROVEE, T00153_n239RFF_COMPRAPROVEE, T00153_A240RFF_COMPRAFINCA, T00153_n240RFF_COMPRAFINCA,
               T00153_A241RFF_COMPRAZONA, T00153_n241RFF_COMPRAZONA, T00153_A242RFF_COMPRAVEREDAID, T00153_n242RFF_COMPRAVEREDAID, T00153_A243RFF_COMPRAVEREDANOM, T00153_n243RFF_COMPRAVEREDANOM, T00153_A244RFF_COMPRAMUNIID, T00153_n244RFF_COMPRAMUNIID, T00153_A245RFF_COMPRAMUNINOM, T00153_n245RFF_COMPRAMUNINOM,
               T00153_A246RFF_COMPRADEPTOID, T00153_n246RFF_COMPRADEPTOID, T00153_A247RFF_COMPRADEPTONOM, T00153_n247RFF_COMPRADEPTONOM, T00153_A248RFF_COMPRACLASIFIC, T00153_n248RFF_COMPRACLASIFIC, T00153_A249RFF_COMPRATAMANO, T00153_n249RFF_COMPRATAMANO, T00153_A250RFF_COMPRAHAS, T00153_n250RFF_COMPRAHAS,
               T00153_A251RFF_COMPRADISTAKM, T00153_n251RFF_COMPRADISTAKM, T00153_A252RFF_COMPRARANDISTAN, T00153_n252RFF_COMPRARANDISTAN, T00153_A253RFF_COMPRAIDACOMPANAM, T00153_n253RFF_COMPRAIDACOMPANAM, T00153_A254RFF_COMPRAACOMPANANOM, T00153_n254RFF_COMPRAACOMPANANOM, T00153_A255RFF_COMPRARSPO, T00153_n255RFF_COMPRARSPO,
               T00153_A256RFF_COMPRANATURALEZA, T00153_n256RFF_COMPRANATURALEZA, T00153_A257RFF_COMPRACOORDX, T00153_n257RFF_COMPRACOORDX, T00153_A258RFF_COMPRACOORDY, T00153_n258RFF_COMPRACOORDY, T00153_A259RFF_COMPRAEDADRANGO, T00153_n259RFF_COMPRAEDADRANGO, T00153_A260RFF_COMPRAMATERIAL, T00153_n260RFF_COMPRAMATERIAL,
               T00153_A261RFF_COMPRACOMITE, T00153_n261RFF_COMPRACOMITE, T00153_A5Cod_Area, T00153_A4IndicadoresCodigo
               }
               , new Object[] {
               T00154_A5Cod_Area
               }
               , new Object[] {
               T00155_A4IndicadoresCodigo
               }
               , new Object[] {
               T00156_A86RFF_COMPRADAFecha, T00156_A87RFF_COMPRADAMes, T00156_A88RFF_COMPRADAAno, T00156_A89RFF_COMPRAPRODUCUP, T00156_A238RFF_COMPRATON, T00156_n238RFF_COMPRATON, T00156_A239RFF_COMPRAPROVEE, T00156_n239RFF_COMPRAPROVEE, T00156_A240RFF_COMPRAFINCA, T00156_n240RFF_COMPRAFINCA,
               T00156_A241RFF_COMPRAZONA, T00156_n241RFF_COMPRAZONA, T00156_A242RFF_COMPRAVEREDAID, T00156_n242RFF_COMPRAVEREDAID, T00156_A243RFF_COMPRAVEREDANOM, T00156_n243RFF_COMPRAVEREDANOM, T00156_A244RFF_COMPRAMUNIID, T00156_n244RFF_COMPRAMUNIID, T00156_A245RFF_COMPRAMUNINOM, T00156_n245RFF_COMPRAMUNINOM,
               T00156_A246RFF_COMPRADEPTOID, T00156_n246RFF_COMPRADEPTOID, T00156_A247RFF_COMPRADEPTONOM, T00156_n247RFF_COMPRADEPTONOM, T00156_A248RFF_COMPRACLASIFIC, T00156_n248RFF_COMPRACLASIFIC, T00156_A249RFF_COMPRATAMANO, T00156_n249RFF_COMPRATAMANO, T00156_A250RFF_COMPRAHAS, T00156_n250RFF_COMPRAHAS,
               T00156_A251RFF_COMPRADISTAKM, T00156_n251RFF_COMPRADISTAKM, T00156_A252RFF_COMPRARANDISTAN, T00156_n252RFF_COMPRARANDISTAN, T00156_A253RFF_COMPRAIDACOMPANAM, T00156_n253RFF_COMPRAIDACOMPANAM, T00156_A254RFF_COMPRAACOMPANANOM, T00156_n254RFF_COMPRAACOMPANANOM, T00156_A255RFF_COMPRARSPO, T00156_n255RFF_COMPRARSPO,
               T00156_A256RFF_COMPRANATURALEZA, T00156_n256RFF_COMPRANATURALEZA, T00156_A257RFF_COMPRACOORDX, T00156_n257RFF_COMPRACOORDX, T00156_A258RFF_COMPRACOORDY, T00156_n258RFF_COMPRACOORDY, T00156_A259RFF_COMPRAEDADRANGO, T00156_n259RFF_COMPRAEDADRANGO, T00156_A260RFF_COMPRAMATERIAL, T00156_n260RFF_COMPRAMATERIAL,
               T00156_A261RFF_COMPRACOMITE, T00156_n261RFF_COMPRACOMITE, T00156_A5Cod_Area, T00156_A4IndicadoresCodigo
               }
               , new Object[] {
               T00157_A5Cod_Area
               }
               , new Object[] {
               T00158_A4IndicadoresCodigo
               }
               , new Object[] {
               T00159_A86RFF_COMPRADAFecha, T00159_A5Cod_Area, T00159_A4IndicadoresCodigo, T00159_A87RFF_COMPRADAMes, T00159_A88RFF_COMPRADAAno, T00159_A89RFF_COMPRAPRODUCUP
               }
               , new Object[] {
               T001510_A86RFF_COMPRADAFecha, T001510_A5Cod_Area, T001510_A4IndicadoresCodigo, T001510_A87RFF_COMPRADAMes, T001510_A88RFF_COMPRADAAno, T001510_A89RFF_COMPRAPRODUCUP
               }
               , new Object[] {
               T001511_A86RFF_COMPRADAFecha, T001511_A5Cod_Area, T001511_A4IndicadoresCodigo, T001511_A87RFF_COMPRADAMes, T001511_A88RFF_COMPRADAAno, T001511_A89RFF_COMPRAPRODUCUP
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001515_A86RFF_COMPRADAFecha, T001515_A5Cod_Area, T001515_A4IndicadoresCodigo, T001515_A87RFF_COMPRADAMes, T001515_A88RFF_COMPRADAAno, T001515_A89RFF_COMPRAPRODUCUP
               }
               , new Object[] {
               T001516_A5Cod_Area
               }
               , new Object[] {
               T001517_A4IndicadoresCodigo
               }
            }
         );
      }

      private short Z87RFF_COMPRADAMes ;
      private short Z88RFF_COMPRADAAno ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A87RFF_COMPRADAMes ;
      private short A88RFF_COMPRADAAno ;
      private short GX_JID ;
      private short RcdFound42 ;
      private short nIsDirty_42 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ87RFF_COMPRADAMes ;
      private short ZZ88RFF_COMPRADAAno ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtRFF_COMPRADAFecha_Enabled ;
      private int edtCod_Area_Enabled ;
      private int imgprompt_5_Visible ;
      private int edtIndicadoresCodigo_Enabled ;
      private int imgprompt_4_Visible ;
      private int edtRFF_COMPRADAMes_Enabled ;
      private int edtRFF_COMPRADAAno_Enabled ;
      private int edtRFF_COMPRAPRODUCUP_Enabled ;
      private int edtRFF_COMPRATON_Enabled ;
      private int edtRFF_COMPRAPROVEE_Enabled ;
      private int edtRFF_COMPRAFINCA_Enabled ;
      private int edtRFF_COMPRAZONA_Enabled ;
      private int edtRFF_COMPRAVEREDAID_Enabled ;
      private int edtRFF_COMPRAVEREDANOM_Enabled ;
      private int edtRFF_COMPRAMUNIID_Enabled ;
      private int edtRFF_COMPRAMUNINOM_Enabled ;
      private int edtRFF_COMPRADEPTOID_Enabled ;
      private int edtRFF_COMPRADEPTONOM_Enabled ;
      private int edtRFF_COMPRACLASIFIC_Enabled ;
      private int edtRFF_COMPRATAMANO_Enabled ;
      private int edtRFF_COMPRAHAS_Enabled ;
      private int edtRFF_COMPRADISTAKM_Enabled ;
      private int edtRFF_COMPRARANDISTAN_Enabled ;
      private int edtRFF_COMPRAIDACOMPANAM_Enabled ;
      private int edtRFF_COMPRAACOMPANANOM_Enabled ;
      private int edtRFF_COMPRARSPO_Enabled ;
      private int edtRFF_COMPRANATURALEZA_Enabled ;
      private int edtRFF_COMPRACOORDX_Enabled ;
      private int edtRFF_COMPRACOORDY_Enabled ;
      private int edtRFF_COMPRAEDADRANGO_Enabled ;
      private int edtRFF_COMPRAMATERIAL_Enabled ;
      private int edtRFF_COMPRACOMITE_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z242RFF_COMPRAVEREDAID ;
      private long Z244RFF_COMPRAMUNIID ;
      private long Z246RFF_COMPRADEPTOID ;
      private long Z253RFF_COMPRAIDACOMPANAM ;
      private long A242RFF_COMPRAVEREDAID ;
      private long A244RFF_COMPRAMUNIID ;
      private long A246RFF_COMPRADEPTOID ;
      private long A253RFF_COMPRAIDACOMPANAM ;
      private long ZZ242RFF_COMPRAVEREDAID ;
      private long ZZ244RFF_COMPRAMUNIID ;
      private long ZZ246RFF_COMPRADEPTOID ;
      private long ZZ253RFF_COMPRAIDACOMPANAM ;
      private decimal Z238RFF_COMPRATON ;
      private decimal Z250RFF_COMPRAHAS ;
      private decimal Z251RFF_COMPRADISTAKM ;
      private decimal A238RFF_COMPRATON ;
      private decimal A250RFF_COMPRAHAS ;
      private decimal A251RFF_COMPRADISTAKM ;
      private decimal ZZ238RFF_COMPRATON ;
      private decimal ZZ250RFF_COMPRAHAS ;
      private decimal ZZ251RFF_COMPRADISTAKM ;
      private string sPrefix ;
      private string Z89RFF_COMPRAPRODUCUP ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtRFF_COMPRADAFecha_Internalname ;
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
      private string edtRFF_COMPRADAFecha_Jsonclick ;
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
      private string edtRFF_COMPRADAMes_Internalname ;
      private string edtRFF_COMPRADAMes_Jsonclick ;
      private string edtRFF_COMPRADAAno_Internalname ;
      private string edtRFF_COMPRADAAno_Jsonclick ;
      private string edtRFF_COMPRAPRODUCUP_Internalname ;
      private string A89RFF_COMPRAPRODUCUP ;
      private string edtRFF_COMPRAPRODUCUP_Jsonclick ;
      private string edtRFF_COMPRATON_Internalname ;
      private string edtRFF_COMPRATON_Jsonclick ;
      private string edtRFF_COMPRAPROVEE_Internalname ;
      private string edtRFF_COMPRAFINCA_Internalname ;
      private string edtRFF_COMPRAZONA_Internalname ;
      private string edtRFF_COMPRAZONA_Jsonclick ;
      private string edtRFF_COMPRAVEREDAID_Internalname ;
      private string edtRFF_COMPRAVEREDAID_Jsonclick ;
      private string edtRFF_COMPRAVEREDANOM_Internalname ;
      private string edtRFF_COMPRAMUNIID_Internalname ;
      private string edtRFF_COMPRAMUNIID_Jsonclick ;
      private string edtRFF_COMPRAMUNINOM_Internalname ;
      private string edtRFF_COMPRADEPTOID_Internalname ;
      private string edtRFF_COMPRADEPTOID_Jsonclick ;
      private string edtRFF_COMPRADEPTONOM_Internalname ;
      private string edtRFF_COMPRACLASIFIC_Internalname ;
      private string edtRFF_COMPRACLASIFIC_Jsonclick ;
      private string edtRFF_COMPRATAMANO_Internalname ;
      private string edtRFF_COMPRATAMANO_Jsonclick ;
      private string edtRFF_COMPRAHAS_Internalname ;
      private string edtRFF_COMPRAHAS_Jsonclick ;
      private string edtRFF_COMPRADISTAKM_Internalname ;
      private string edtRFF_COMPRADISTAKM_Jsonclick ;
      private string edtRFF_COMPRARANDISTAN_Internalname ;
      private string edtRFF_COMPRARANDISTAN_Jsonclick ;
      private string edtRFF_COMPRAIDACOMPANAM_Internalname ;
      private string edtRFF_COMPRAIDACOMPANAM_Jsonclick ;
      private string edtRFF_COMPRAACOMPANANOM_Internalname ;
      private string edtRFF_COMPRARSPO_Internalname ;
      private string edtRFF_COMPRARSPO_Jsonclick ;
      private string edtRFF_COMPRANATURALEZA_Internalname ;
      private string edtRFF_COMPRANATURALEZA_Jsonclick ;
      private string edtRFF_COMPRACOORDX_Internalname ;
      private string edtRFF_COMPRACOORDX_Jsonclick ;
      private string edtRFF_COMPRACOORDY_Internalname ;
      private string edtRFF_COMPRACOORDY_Jsonclick ;
      private string edtRFF_COMPRAEDADRANGO_Internalname ;
      private string edtRFF_COMPRAEDADRANGO_Jsonclick ;
      private string edtRFF_COMPRAMATERIAL_Internalname ;
      private string edtRFF_COMPRAMATERIAL_Jsonclick ;
      private string edtRFF_COMPRACOMITE_Internalname ;
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
      private string sMode42 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ89RFF_COMPRAPRODUCUP ;
      private DateTime Z86RFF_COMPRADAFecha ;
      private DateTime A86RFF_COMPRADAFecha ;
      private DateTime ZZ86RFF_COMPRADAFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n238RFF_COMPRATON ;
      private bool n239RFF_COMPRAPROVEE ;
      private bool n240RFF_COMPRAFINCA ;
      private bool n241RFF_COMPRAZONA ;
      private bool n242RFF_COMPRAVEREDAID ;
      private bool n243RFF_COMPRAVEREDANOM ;
      private bool n244RFF_COMPRAMUNIID ;
      private bool n245RFF_COMPRAMUNINOM ;
      private bool n246RFF_COMPRADEPTOID ;
      private bool n247RFF_COMPRADEPTONOM ;
      private bool n248RFF_COMPRACLASIFIC ;
      private bool n249RFF_COMPRATAMANO ;
      private bool n250RFF_COMPRAHAS ;
      private bool n251RFF_COMPRADISTAKM ;
      private bool n252RFF_COMPRARANDISTAN ;
      private bool n253RFF_COMPRAIDACOMPANAM ;
      private bool n254RFF_COMPRAACOMPANANOM ;
      private bool n255RFF_COMPRARSPO ;
      private bool n256RFF_COMPRANATURALEZA ;
      private bool n257RFF_COMPRACOORDX ;
      private bool n258RFF_COMPRACOORDY ;
      private bool n259RFF_COMPRAEDADRANGO ;
      private bool n260RFF_COMPRAMATERIAL ;
      private bool n261RFF_COMPRACOMITE ;
      private bool Gx_longc ;
      private string Z5Cod_Area ;
      private string Z4IndicadoresCodigo ;
      private string Z239RFF_COMPRAPROVEE ;
      private string Z240RFF_COMPRAFINCA ;
      private string Z241RFF_COMPRAZONA ;
      private string Z243RFF_COMPRAVEREDANOM ;
      private string Z245RFF_COMPRAMUNINOM ;
      private string Z247RFF_COMPRADEPTONOM ;
      private string Z248RFF_COMPRACLASIFIC ;
      private string Z249RFF_COMPRATAMANO ;
      private string Z252RFF_COMPRARANDISTAN ;
      private string Z254RFF_COMPRAACOMPANANOM ;
      private string Z255RFF_COMPRARSPO ;
      private string Z256RFF_COMPRANATURALEZA ;
      private string Z257RFF_COMPRACOORDX ;
      private string Z258RFF_COMPRACOORDY ;
      private string Z259RFF_COMPRAEDADRANGO ;
      private string Z260RFF_COMPRAMATERIAL ;
      private string Z261RFF_COMPRACOMITE ;
      private string A5Cod_Area ;
      private string A4IndicadoresCodigo ;
      private string A239RFF_COMPRAPROVEE ;
      private string A240RFF_COMPRAFINCA ;
      private string A241RFF_COMPRAZONA ;
      private string A243RFF_COMPRAVEREDANOM ;
      private string A245RFF_COMPRAMUNINOM ;
      private string A247RFF_COMPRADEPTONOM ;
      private string A248RFF_COMPRACLASIFIC ;
      private string A249RFF_COMPRATAMANO ;
      private string A252RFF_COMPRARANDISTAN ;
      private string A254RFF_COMPRAACOMPANANOM ;
      private string A255RFF_COMPRARSPO ;
      private string A256RFF_COMPRANATURALEZA ;
      private string A257RFF_COMPRACOORDX ;
      private string A258RFF_COMPRACOORDY ;
      private string A259RFF_COMPRAEDADRANGO ;
      private string A260RFF_COMPRAMATERIAL ;
      private string A261RFF_COMPRACOMITE ;
      private string ZZ5Cod_Area ;
      private string ZZ4IndicadoresCodigo ;
      private string ZZ239RFF_COMPRAPROVEE ;
      private string ZZ240RFF_COMPRAFINCA ;
      private string ZZ241RFF_COMPRAZONA ;
      private string ZZ243RFF_COMPRAVEREDANOM ;
      private string ZZ245RFF_COMPRAMUNINOM ;
      private string ZZ247RFF_COMPRADEPTONOM ;
      private string ZZ248RFF_COMPRACLASIFIC ;
      private string ZZ249RFF_COMPRATAMANO ;
      private string ZZ252RFF_COMPRARANDISTAN ;
      private string ZZ254RFF_COMPRAACOMPANANOM ;
      private string ZZ255RFF_COMPRARSPO ;
      private string ZZ256RFF_COMPRANATURALEZA ;
      private string ZZ257RFF_COMPRACOORDX ;
      private string ZZ258RFF_COMPRACOORDY ;
      private string ZZ259RFF_COMPRAEDADRANGO ;
      private string ZZ260RFF_COMPRAMATERIAL ;
      private string ZZ261RFF_COMPRACOMITE ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] T00156_A86RFF_COMPRADAFecha ;
      private short[] T00156_A87RFF_COMPRADAMes ;
      private short[] T00156_A88RFF_COMPRADAAno ;
      private string[] T00156_A89RFF_COMPRAPRODUCUP ;
      private decimal[] T00156_A238RFF_COMPRATON ;
      private bool[] T00156_n238RFF_COMPRATON ;
      private string[] T00156_A239RFF_COMPRAPROVEE ;
      private bool[] T00156_n239RFF_COMPRAPROVEE ;
      private string[] T00156_A240RFF_COMPRAFINCA ;
      private bool[] T00156_n240RFF_COMPRAFINCA ;
      private string[] T00156_A241RFF_COMPRAZONA ;
      private bool[] T00156_n241RFF_COMPRAZONA ;
      private long[] T00156_A242RFF_COMPRAVEREDAID ;
      private bool[] T00156_n242RFF_COMPRAVEREDAID ;
      private string[] T00156_A243RFF_COMPRAVEREDANOM ;
      private bool[] T00156_n243RFF_COMPRAVEREDANOM ;
      private long[] T00156_A244RFF_COMPRAMUNIID ;
      private bool[] T00156_n244RFF_COMPRAMUNIID ;
      private string[] T00156_A245RFF_COMPRAMUNINOM ;
      private bool[] T00156_n245RFF_COMPRAMUNINOM ;
      private long[] T00156_A246RFF_COMPRADEPTOID ;
      private bool[] T00156_n246RFF_COMPRADEPTOID ;
      private string[] T00156_A247RFF_COMPRADEPTONOM ;
      private bool[] T00156_n247RFF_COMPRADEPTONOM ;
      private string[] T00156_A248RFF_COMPRACLASIFIC ;
      private bool[] T00156_n248RFF_COMPRACLASIFIC ;
      private string[] T00156_A249RFF_COMPRATAMANO ;
      private bool[] T00156_n249RFF_COMPRATAMANO ;
      private decimal[] T00156_A250RFF_COMPRAHAS ;
      private bool[] T00156_n250RFF_COMPRAHAS ;
      private decimal[] T00156_A251RFF_COMPRADISTAKM ;
      private bool[] T00156_n251RFF_COMPRADISTAKM ;
      private string[] T00156_A252RFF_COMPRARANDISTAN ;
      private bool[] T00156_n252RFF_COMPRARANDISTAN ;
      private long[] T00156_A253RFF_COMPRAIDACOMPANAM ;
      private bool[] T00156_n253RFF_COMPRAIDACOMPANAM ;
      private string[] T00156_A254RFF_COMPRAACOMPANANOM ;
      private bool[] T00156_n254RFF_COMPRAACOMPANANOM ;
      private string[] T00156_A255RFF_COMPRARSPO ;
      private bool[] T00156_n255RFF_COMPRARSPO ;
      private string[] T00156_A256RFF_COMPRANATURALEZA ;
      private bool[] T00156_n256RFF_COMPRANATURALEZA ;
      private string[] T00156_A257RFF_COMPRACOORDX ;
      private bool[] T00156_n257RFF_COMPRACOORDX ;
      private string[] T00156_A258RFF_COMPRACOORDY ;
      private bool[] T00156_n258RFF_COMPRACOORDY ;
      private string[] T00156_A259RFF_COMPRAEDADRANGO ;
      private bool[] T00156_n259RFF_COMPRAEDADRANGO ;
      private string[] T00156_A260RFF_COMPRAMATERIAL ;
      private bool[] T00156_n260RFF_COMPRAMATERIAL ;
      private string[] T00156_A261RFF_COMPRACOMITE ;
      private bool[] T00156_n261RFF_COMPRACOMITE ;
      private string[] T00156_A5Cod_Area ;
      private string[] T00156_A4IndicadoresCodigo ;
      private string[] T00154_A5Cod_Area ;
      private string[] T00155_A4IndicadoresCodigo ;
      private string[] T00157_A5Cod_Area ;
      private string[] T00158_A4IndicadoresCodigo ;
      private DateTime[] T00159_A86RFF_COMPRADAFecha ;
      private string[] T00159_A5Cod_Area ;
      private string[] T00159_A4IndicadoresCodigo ;
      private short[] T00159_A87RFF_COMPRADAMes ;
      private short[] T00159_A88RFF_COMPRADAAno ;
      private string[] T00159_A89RFF_COMPRAPRODUCUP ;
      private DateTime[] T00153_A86RFF_COMPRADAFecha ;
      private short[] T00153_A87RFF_COMPRADAMes ;
      private short[] T00153_A88RFF_COMPRADAAno ;
      private string[] T00153_A89RFF_COMPRAPRODUCUP ;
      private decimal[] T00153_A238RFF_COMPRATON ;
      private bool[] T00153_n238RFF_COMPRATON ;
      private string[] T00153_A239RFF_COMPRAPROVEE ;
      private bool[] T00153_n239RFF_COMPRAPROVEE ;
      private string[] T00153_A240RFF_COMPRAFINCA ;
      private bool[] T00153_n240RFF_COMPRAFINCA ;
      private string[] T00153_A241RFF_COMPRAZONA ;
      private bool[] T00153_n241RFF_COMPRAZONA ;
      private long[] T00153_A242RFF_COMPRAVEREDAID ;
      private bool[] T00153_n242RFF_COMPRAVEREDAID ;
      private string[] T00153_A243RFF_COMPRAVEREDANOM ;
      private bool[] T00153_n243RFF_COMPRAVEREDANOM ;
      private long[] T00153_A244RFF_COMPRAMUNIID ;
      private bool[] T00153_n244RFF_COMPRAMUNIID ;
      private string[] T00153_A245RFF_COMPRAMUNINOM ;
      private bool[] T00153_n245RFF_COMPRAMUNINOM ;
      private long[] T00153_A246RFF_COMPRADEPTOID ;
      private bool[] T00153_n246RFF_COMPRADEPTOID ;
      private string[] T00153_A247RFF_COMPRADEPTONOM ;
      private bool[] T00153_n247RFF_COMPRADEPTONOM ;
      private string[] T00153_A248RFF_COMPRACLASIFIC ;
      private bool[] T00153_n248RFF_COMPRACLASIFIC ;
      private string[] T00153_A249RFF_COMPRATAMANO ;
      private bool[] T00153_n249RFF_COMPRATAMANO ;
      private decimal[] T00153_A250RFF_COMPRAHAS ;
      private bool[] T00153_n250RFF_COMPRAHAS ;
      private decimal[] T00153_A251RFF_COMPRADISTAKM ;
      private bool[] T00153_n251RFF_COMPRADISTAKM ;
      private string[] T00153_A252RFF_COMPRARANDISTAN ;
      private bool[] T00153_n252RFF_COMPRARANDISTAN ;
      private long[] T00153_A253RFF_COMPRAIDACOMPANAM ;
      private bool[] T00153_n253RFF_COMPRAIDACOMPANAM ;
      private string[] T00153_A254RFF_COMPRAACOMPANANOM ;
      private bool[] T00153_n254RFF_COMPRAACOMPANANOM ;
      private string[] T00153_A255RFF_COMPRARSPO ;
      private bool[] T00153_n255RFF_COMPRARSPO ;
      private string[] T00153_A256RFF_COMPRANATURALEZA ;
      private bool[] T00153_n256RFF_COMPRANATURALEZA ;
      private string[] T00153_A257RFF_COMPRACOORDX ;
      private bool[] T00153_n257RFF_COMPRACOORDX ;
      private string[] T00153_A258RFF_COMPRACOORDY ;
      private bool[] T00153_n258RFF_COMPRACOORDY ;
      private string[] T00153_A259RFF_COMPRAEDADRANGO ;
      private bool[] T00153_n259RFF_COMPRAEDADRANGO ;
      private string[] T00153_A260RFF_COMPRAMATERIAL ;
      private bool[] T00153_n260RFF_COMPRAMATERIAL ;
      private string[] T00153_A261RFF_COMPRACOMITE ;
      private bool[] T00153_n261RFF_COMPRACOMITE ;
      private string[] T00153_A5Cod_Area ;
      private string[] T00153_A4IndicadoresCodigo ;
      private DateTime[] T001510_A86RFF_COMPRADAFecha ;
      private string[] T001510_A5Cod_Area ;
      private string[] T001510_A4IndicadoresCodigo ;
      private short[] T001510_A87RFF_COMPRADAMes ;
      private short[] T001510_A88RFF_COMPRADAAno ;
      private string[] T001510_A89RFF_COMPRAPRODUCUP ;
      private DateTime[] T001511_A86RFF_COMPRADAFecha ;
      private string[] T001511_A5Cod_Area ;
      private string[] T001511_A4IndicadoresCodigo ;
      private short[] T001511_A87RFF_COMPRADAMes ;
      private short[] T001511_A88RFF_COMPRADAAno ;
      private string[] T001511_A89RFF_COMPRAPRODUCUP ;
      private DateTime[] T00152_A86RFF_COMPRADAFecha ;
      private short[] T00152_A87RFF_COMPRADAMes ;
      private short[] T00152_A88RFF_COMPRADAAno ;
      private string[] T00152_A89RFF_COMPRAPRODUCUP ;
      private decimal[] T00152_A238RFF_COMPRATON ;
      private bool[] T00152_n238RFF_COMPRATON ;
      private string[] T00152_A239RFF_COMPRAPROVEE ;
      private bool[] T00152_n239RFF_COMPRAPROVEE ;
      private string[] T00152_A240RFF_COMPRAFINCA ;
      private bool[] T00152_n240RFF_COMPRAFINCA ;
      private string[] T00152_A241RFF_COMPRAZONA ;
      private bool[] T00152_n241RFF_COMPRAZONA ;
      private long[] T00152_A242RFF_COMPRAVEREDAID ;
      private bool[] T00152_n242RFF_COMPRAVEREDAID ;
      private string[] T00152_A243RFF_COMPRAVEREDANOM ;
      private bool[] T00152_n243RFF_COMPRAVEREDANOM ;
      private long[] T00152_A244RFF_COMPRAMUNIID ;
      private bool[] T00152_n244RFF_COMPRAMUNIID ;
      private string[] T00152_A245RFF_COMPRAMUNINOM ;
      private bool[] T00152_n245RFF_COMPRAMUNINOM ;
      private long[] T00152_A246RFF_COMPRADEPTOID ;
      private bool[] T00152_n246RFF_COMPRADEPTOID ;
      private string[] T00152_A247RFF_COMPRADEPTONOM ;
      private bool[] T00152_n247RFF_COMPRADEPTONOM ;
      private string[] T00152_A248RFF_COMPRACLASIFIC ;
      private bool[] T00152_n248RFF_COMPRACLASIFIC ;
      private string[] T00152_A249RFF_COMPRATAMANO ;
      private bool[] T00152_n249RFF_COMPRATAMANO ;
      private decimal[] T00152_A250RFF_COMPRAHAS ;
      private bool[] T00152_n250RFF_COMPRAHAS ;
      private decimal[] T00152_A251RFF_COMPRADISTAKM ;
      private bool[] T00152_n251RFF_COMPRADISTAKM ;
      private string[] T00152_A252RFF_COMPRARANDISTAN ;
      private bool[] T00152_n252RFF_COMPRARANDISTAN ;
      private long[] T00152_A253RFF_COMPRAIDACOMPANAM ;
      private bool[] T00152_n253RFF_COMPRAIDACOMPANAM ;
      private string[] T00152_A254RFF_COMPRAACOMPANANOM ;
      private bool[] T00152_n254RFF_COMPRAACOMPANANOM ;
      private string[] T00152_A255RFF_COMPRARSPO ;
      private bool[] T00152_n255RFF_COMPRARSPO ;
      private string[] T00152_A256RFF_COMPRANATURALEZA ;
      private bool[] T00152_n256RFF_COMPRANATURALEZA ;
      private string[] T00152_A257RFF_COMPRACOORDX ;
      private bool[] T00152_n257RFF_COMPRACOORDX ;
      private string[] T00152_A258RFF_COMPRACOORDY ;
      private bool[] T00152_n258RFF_COMPRACOORDY ;
      private string[] T00152_A259RFF_COMPRAEDADRANGO ;
      private bool[] T00152_n259RFF_COMPRAEDADRANGO ;
      private string[] T00152_A260RFF_COMPRAMATERIAL ;
      private bool[] T00152_n260RFF_COMPRAMATERIAL ;
      private string[] T00152_A261RFF_COMPRACOMITE ;
      private bool[] T00152_n261RFF_COMPRACOMITE ;
      private string[] T00152_A5Cod_Area ;
      private string[] T00152_A4IndicadoresCodigo ;
      private DateTime[] T001515_A86RFF_COMPRADAFecha ;
      private string[] T001515_A5Cod_Area ;
      private string[] T001515_A4IndicadoresCodigo ;
      private short[] T001515_A87RFF_COMPRADAMes ;
      private short[] T001515_A88RFF_COMPRADAAno ;
      private string[] T001515_A89RFF_COMPRAPRODUCUP ;
      private string[] T001516_A5Cod_Area ;
      private string[] T001517_A4IndicadoresCodigo ;
      private GXWebForm Form ;
   }

   public class rff_comprada__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT00156;
          prmT00156 = new Object[] {
          new ParDef("@RFF_COMPRADAFecha",GXType.Date,8,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@RFF_COMPRADAMes",GXType.Int16,4,0) ,
          new ParDef("@RFF_COMPRADAAno",GXType.Int16,4,0) ,
          new ParDef("@RFF_COMPRAPRODUCUP",GXType.NChar,20,0)
          };
          Object[] prmT00154;
          prmT00154 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT00155;
          prmT00155 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT00157;
          prmT00157 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT00158;
          prmT00158 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT00159;
          prmT00159 = new Object[] {
          new ParDef("@RFF_COMPRADAFecha",GXType.Date,8,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@RFF_COMPRADAMes",GXType.Int16,4,0) ,
          new ParDef("@RFF_COMPRADAAno",GXType.Int16,4,0) ,
          new ParDef("@RFF_COMPRAPRODUCUP",GXType.NChar,20,0)
          };
          Object[] prmT00153;
          prmT00153 = new Object[] {
          new ParDef("@RFF_COMPRADAFecha",GXType.Date,8,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@RFF_COMPRADAMes",GXType.Int16,4,0) ,
          new ParDef("@RFF_COMPRADAAno",GXType.Int16,4,0) ,
          new ParDef("@RFF_COMPRAPRODUCUP",GXType.NChar,20,0)
          };
          Object[] prmT001510;
          prmT001510 = new Object[] {
          new ParDef("@RFF_COMPRADAFecha",GXType.Date,8,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@RFF_COMPRADAMes",GXType.Int16,4,0) ,
          new ParDef("@RFF_COMPRADAAno",GXType.Int16,4,0) ,
          new ParDef("@RFF_COMPRAPRODUCUP",GXType.NChar,20,0)
          };
          Object[] prmT001511;
          prmT001511 = new Object[] {
          new ParDef("@RFF_COMPRADAFecha",GXType.Date,8,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@RFF_COMPRADAMes",GXType.Int16,4,0) ,
          new ParDef("@RFF_COMPRADAAno",GXType.Int16,4,0) ,
          new ParDef("@RFF_COMPRAPRODUCUP",GXType.NChar,20,0)
          };
          Object[] prmT00152;
          prmT00152 = new Object[] {
          new ParDef("@RFF_COMPRADAFecha",GXType.Date,8,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@RFF_COMPRADAMes",GXType.Int16,4,0) ,
          new ParDef("@RFF_COMPRADAAno",GXType.Int16,4,0) ,
          new ParDef("@RFF_COMPRAPRODUCUP",GXType.NChar,20,0)
          };
          Object[] prmT001512;
          prmT001512 = new Object[] {
          new ParDef("@RFF_COMPRADAFecha",GXType.Date,8,0) ,
          new ParDef("@RFF_COMPRADAMes",GXType.Int16,4,0) ,
          new ParDef("@RFF_COMPRADAAno",GXType.Int16,4,0) ,
          new ParDef("@RFF_COMPRAPRODUCUP",GXType.NChar,20,0) ,
          new ParDef("@RFF_COMPRATON",GXType.Decimal,12,2){Nullable=true} ,
          new ParDef("@RFF_COMPRAPROVEE",GXType.NVarChar,300,0){Nullable=true} ,
          new ParDef("@RFF_COMPRAFINCA",GXType.NVarChar,300,0){Nullable=true} ,
          new ParDef("@RFF_COMPRAZONA",GXType.NVarChar,40,0){Nullable=true} ,
          new ParDef("@RFF_COMPRAVEREDAID",GXType.Decimal,15,0){Nullable=true} ,
          new ParDef("@RFF_COMPRAVEREDANOM",GXType.NVarChar,300,0){Nullable=true} ,
          new ParDef("@RFF_COMPRAMUNIID",GXType.Decimal,10,0){Nullable=true} ,
          new ParDef("@RFF_COMPRAMUNINOM",GXType.NVarChar,300,0){Nullable=true} ,
          new ParDef("@RFF_COMPRADEPTOID",GXType.Decimal,10,0){Nullable=true} ,
          new ParDef("@RFF_COMPRADEPTONOM",GXType.NVarChar,300,0){Nullable=true} ,
          new ParDef("@RFF_COMPRACLASIFIC",GXType.NVarChar,40,0){Nullable=true} ,
          new ParDef("@RFF_COMPRATAMANO",GXType.NVarChar,40,0){Nullable=true} ,
          new ParDef("@RFF_COMPRAHAS",GXType.Decimal,16,2){Nullable=true} ,
          new ParDef("@RFF_COMPRADISTAKM",GXType.Decimal,10,2){Nullable=true} ,
          new ParDef("@RFF_COMPRARANDISTAN",GXType.NVarChar,40,0){Nullable=true} ,
          new ParDef("@RFF_COMPRAIDACOMPANAM",GXType.Decimal,15,0){Nullable=true} ,
          new ParDef("@RFF_COMPRAACOMPANANOM",GXType.NVarChar,300,0){Nullable=true} ,
          new ParDef("@RFF_COMPRARSPO",GXType.NVarChar,40,0){Nullable=true} ,
          new ParDef("@RFF_COMPRANATURALEZA",GXType.NVarChar,40,0){Nullable=true} ,
          new ParDef("@RFF_COMPRACOORDX",GXType.NVarChar,40,0){Nullable=true} ,
          new ParDef("@RFF_COMPRACOORDY",GXType.NVarChar,40,0){Nullable=true} ,
          new ParDef("@RFF_COMPRAEDADRANGO",GXType.NVarChar,50,0){Nullable=true} ,
          new ParDef("@RFF_COMPRAMATERIAL",GXType.NVarChar,40,0){Nullable=true} ,
          new ParDef("@RFF_COMPRACOMITE",GXType.NVarChar,300,0){Nullable=true} ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT001513;
          prmT001513 = new Object[] {
          new ParDef("@RFF_COMPRATON",GXType.Decimal,12,2){Nullable=true} ,
          new ParDef("@RFF_COMPRAPROVEE",GXType.NVarChar,300,0){Nullable=true} ,
          new ParDef("@RFF_COMPRAFINCA",GXType.NVarChar,300,0){Nullable=true} ,
          new ParDef("@RFF_COMPRAZONA",GXType.NVarChar,40,0){Nullable=true} ,
          new ParDef("@RFF_COMPRAVEREDAID",GXType.Decimal,15,0){Nullable=true} ,
          new ParDef("@RFF_COMPRAVEREDANOM",GXType.NVarChar,300,0){Nullable=true} ,
          new ParDef("@RFF_COMPRAMUNIID",GXType.Decimal,10,0){Nullable=true} ,
          new ParDef("@RFF_COMPRAMUNINOM",GXType.NVarChar,300,0){Nullable=true} ,
          new ParDef("@RFF_COMPRADEPTOID",GXType.Decimal,10,0){Nullable=true} ,
          new ParDef("@RFF_COMPRADEPTONOM",GXType.NVarChar,300,0){Nullable=true} ,
          new ParDef("@RFF_COMPRACLASIFIC",GXType.NVarChar,40,0){Nullable=true} ,
          new ParDef("@RFF_COMPRATAMANO",GXType.NVarChar,40,0){Nullable=true} ,
          new ParDef("@RFF_COMPRAHAS",GXType.Decimal,16,2){Nullable=true} ,
          new ParDef("@RFF_COMPRADISTAKM",GXType.Decimal,10,2){Nullable=true} ,
          new ParDef("@RFF_COMPRARANDISTAN",GXType.NVarChar,40,0){Nullable=true} ,
          new ParDef("@RFF_COMPRAIDACOMPANAM",GXType.Decimal,15,0){Nullable=true} ,
          new ParDef("@RFF_COMPRAACOMPANANOM",GXType.NVarChar,300,0){Nullable=true} ,
          new ParDef("@RFF_COMPRARSPO",GXType.NVarChar,40,0){Nullable=true} ,
          new ParDef("@RFF_COMPRANATURALEZA",GXType.NVarChar,40,0){Nullable=true} ,
          new ParDef("@RFF_COMPRACOORDX",GXType.NVarChar,40,0){Nullable=true} ,
          new ParDef("@RFF_COMPRACOORDY",GXType.NVarChar,40,0){Nullable=true} ,
          new ParDef("@RFF_COMPRAEDADRANGO",GXType.NVarChar,50,0){Nullable=true} ,
          new ParDef("@RFF_COMPRAMATERIAL",GXType.NVarChar,40,0){Nullable=true} ,
          new ParDef("@RFF_COMPRACOMITE",GXType.NVarChar,300,0){Nullable=true} ,
          new ParDef("@RFF_COMPRADAFecha",GXType.Date,8,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@RFF_COMPRADAMes",GXType.Int16,4,0) ,
          new ParDef("@RFF_COMPRADAAno",GXType.Int16,4,0) ,
          new ParDef("@RFF_COMPRAPRODUCUP",GXType.NChar,20,0)
          };
          Object[] prmT001514;
          prmT001514 = new Object[] {
          new ParDef("@RFF_COMPRADAFecha",GXType.Date,8,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@RFF_COMPRADAMes",GXType.Int16,4,0) ,
          new ParDef("@RFF_COMPRADAAno",GXType.Int16,4,0) ,
          new ParDef("@RFF_COMPRAPRODUCUP",GXType.NChar,20,0)
          };
          Object[] prmT001515;
          prmT001515 = new Object[] {
          };
          Object[] prmT001516;
          prmT001516 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT001517;
          prmT001517 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00152", "SELECT [RFF_COMPRADAFecha], [RFF_COMPRADAMes], [RFF_COMPRADAAno], [RFF_COMPRAPRODUCUP], [RFF_COMPRATON], [RFF_COMPRAPROVEE], [RFF_COMPRAFINCA], [RFF_COMPRAZONA], [RFF_COMPRAVEREDAID], [RFF_COMPRAVEREDANOM], [RFF_COMPRAMUNIID], [RFF_COMPRAMUNINOM], [RFF_COMPRADEPTOID], [RFF_COMPRADEPTONOM], [RFF_COMPRACLASIFIC], [RFF_COMPRATAMANO], [RFF_COMPRAHAS], [RFF_COMPRADISTAKM], [RFF_COMPRARANDISTAN], [RFF_COMPRAIDACOMPANAM], [RFF_COMPRAACOMPANANOM], [RFF_COMPRARSPO], [RFF_COMPRANATURALEZA], [RFF_COMPRACOORDX], [RFF_COMPRACOORDY], [RFF_COMPRAEDADRANGO], [RFF_COMPRAMATERIAL], [RFF_COMPRACOMITE], [Cod_Area], [IndicadoresCodigo] FROM [RFF_COMPRADA] WITH (UPDLOCK) WHERE [RFF_COMPRADAFecha] = @RFF_COMPRADAFecha AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo AND [RFF_COMPRADAMes] = @RFF_COMPRADAMes AND [RFF_COMPRADAAno] = @RFF_COMPRADAAno AND [RFF_COMPRAPRODUCUP] = @RFF_COMPRAPRODUCUP ",true, GxErrorMask.GX_NOMASK, false, this,prmT00152,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00153", "SELECT [RFF_COMPRADAFecha], [RFF_COMPRADAMes], [RFF_COMPRADAAno], [RFF_COMPRAPRODUCUP], [RFF_COMPRATON], [RFF_COMPRAPROVEE], [RFF_COMPRAFINCA], [RFF_COMPRAZONA], [RFF_COMPRAVEREDAID], [RFF_COMPRAVEREDANOM], [RFF_COMPRAMUNIID], [RFF_COMPRAMUNINOM], [RFF_COMPRADEPTOID], [RFF_COMPRADEPTONOM], [RFF_COMPRACLASIFIC], [RFF_COMPRATAMANO], [RFF_COMPRAHAS], [RFF_COMPRADISTAKM], [RFF_COMPRARANDISTAN], [RFF_COMPRAIDACOMPANAM], [RFF_COMPRAACOMPANANOM], [RFF_COMPRARSPO], [RFF_COMPRANATURALEZA], [RFF_COMPRACOORDX], [RFF_COMPRACOORDY], [RFF_COMPRAEDADRANGO], [RFF_COMPRAMATERIAL], [RFF_COMPRACOMITE], [Cod_Area], [IndicadoresCodigo] FROM [RFF_COMPRADA] WHERE [RFF_COMPRADAFecha] = @RFF_COMPRADAFecha AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo AND [RFF_COMPRADAMes] = @RFF_COMPRADAMes AND [RFF_COMPRADAAno] = @RFF_COMPRADAAno AND [RFF_COMPRAPRODUCUP] = @RFF_COMPRAPRODUCUP ",true, GxErrorMask.GX_NOMASK, false, this,prmT00153,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00154", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT00154,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00155", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT00155,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00156", "SELECT TM1.[RFF_COMPRADAFecha], TM1.[RFF_COMPRADAMes], TM1.[RFF_COMPRADAAno], TM1.[RFF_COMPRAPRODUCUP], TM1.[RFF_COMPRATON], TM1.[RFF_COMPRAPROVEE], TM1.[RFF_COMPRAFINCA], TM1.[RFF_COMPRAZONA], TM1.[RFF_COMPRAVEREDAID], TM1.[RFF_COMPRAVEREDANOM], TM1.[RFF_COMPRAMUNIID], TM1.[RFF_COMPRAMUNINOM], TM1.[RFF_COMPRADEPTOID], TM1.[RFF_COMPRADEPTONOM], TM1.[RFF_COMPRACLASIFIC], TM1.[RFF_COMPRATAMANO], TM1.[RFF_COMPRAHAS], TM1.[RFF_COMPRADISTAKM], TM1.[RFF_COMPRARANDISTAN], TM1.[RFF_COMPRAIDACOMPANAM], TM1.[RFF_COMPRAACOMPANANOM], TM1.[RFF_COMPRARSPO], TM1.[RFF_COMPRANATURALEZA], TM1.[RFF_COMPRACOORDX], TM1.[RFF_COMPRACOORDY], TM1.[RFF_COMPRAEDADRANGO], TM1.[RFF_COMPRAMATERIAL], TM1.[RFF_COMPRACOMITE], TM1.[Cod_Area], TM1.[IndicadoresCodigo] FROM [RFF_COMPRADA] TM1 WHERE TM1.[RFF_COMPRADAFecha] = @RFF_COMPRADAFecha and TM1.[Cod_Area] = @Cod_Area and TM1.[IndicadoresCodigo] = @IndicadoresCodigo and TM1.[RFF_COMPRADAMes] = @RFF_COMPRADAMes and TM1.[RFF_COMPRADAAno] = @RFF_COMPRADAAno and TM1.[RFF_COMPRAPRODUCUP] = @RFF_COMPRAPRODUCUP ORDER BY TM1.[RFF_COMPRADAFecha], TM1.[Cod_Area], TM1.[IndicadoresCodigo], TM1.[RFF_COMPRADAMes], TM1.[RFF_COMPRADAAno], TM1.[RFF_COMPRAPRODUCUP]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00156,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00157", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT00157,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00158", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT00158,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00159", "SELECT [RFF_COMPRADAFecha], [Cod_Area], [IndicadoresCodigo], [RFF_COMPRADAMes], [RFF_COMPRADAAno], [RFF_COMPRAPRODUCUP] FROM [RFF_COMPRADA] WHERE [RFF_COMPRADAFecha] = @RFF_COMPRADAFecha AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo AND [RFF_COMPRADAMes] = @RFF_COMPRADAMes AND [RFF_COMPRADAAno] = @RFF_COMPRADAAno AND [RFF_COMPRAPRODUCUP] = @RFF_COMPRAPRODUCUP  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00159,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001510", "SELECT TOP 1 [RFF_COMPRADAFecha], [Cod_Area], [IndicadoresCodigo], [RFF_COMPRADAMes], [RFF_COMPRADAAno], [RFF_COMPRAPRODUCUP] FROM [RFF_COMPRADA] WHERE ( [RFF_COMPRADAFecha] > @RFF_COMPRADAFecha or [RFF_COMPRADAFecha] = @RFF_COMPRADAFecha and [Cod_Area] > @Cod_Area or [Cod_Area] = @Cod_Area and [RFF_COMPRADAFecha] = @RFF_COMPRADAFecha and [IndicadoresCodigo] > @IndicadoresCodigo or [IndicadoresCodigo] = @IndicadoresCodigo and [Cod_Area] = @Cod_Area and [RFF_COMPRADAFecha] = @RFF_COMPRADAFecha and [RFF_COMPRADAMes] > @RFF_COMPRADAMes or [RFF_COMPRADAMes] = @RFF_COMPRADAMes and [IndicadoresCodigo] = @IndicadoresCodigo and [Cod_Area] = @Cod_Area and [RFF_COMPRADAFecha] = @RFF_COMPRADAFecha and [RFF_COMPRADAAno] > @RFF_COMPRADAAno or [RFF_COMPRADAAno] = @RFF_COMPRADAAno and [RFF_COMPRADAMes] = @RFF_COMPRADAMes and [IndicadoresCodigo] = @IndicadoresCodigo and [Cod_Area] = @Cod_Area and [RFF_COMPRADAFecha] = @RFF_COMPRADAFecha and [RFF_COMPRAPRODUCUP] > @RFF_COMPRAPRODUCUP) ORDER BY [RFF_COMPRADAFecha], [Cod_Area], [IndicadoresCodigo], [RFF_COMPRADAMes], [RFF_COMPRADAAno], [RFF_COMPRAPRODUCUP]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001510,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001511", "SELECT TOP 1 [RFF_COMPRADAFecha], [Cod_Area], [IndicadoresCodigo], [RFF_COMPRADAMes], [RFF_COMPRADAAno], [RFF_COMPRAPRODUCUP] FROM [RFF_COMPRADA] WHERE ( [RFF_COMPRADAFecha] < @RFF_COMPRADAFecha or [RFF_COMPRADAFecha] = @RFF_COMPRADAFecha and [Cod_Area] < @Cod_Area or [Cod_Area] = @Cod_Area and [RFF_COMPRADAFecha] = @RFF_COMPRADAFecha and [IndicadoresCodigo] < @IndicadoresCodigo or [IndicadoresCodigo] = @IndicadoresCodigo and [Cod_Area] = @Cod_Area and [RFF_COMPRADAFecha] = @RFF_COMPRADAFecha and [RFF_COMPRADAMes] < @RFF_COMPRADAMes or [RFF_COMPRADAMes] = @RFF_COMPRADAMes and [IndicadoresCodigo] = @IndicadoresCodigo and [Cod_Area] = @Cod_Area and [RFF_COMPRADAFecha] = @RFF_COMPRADAFecha and [RFF_COMPRADAAno] < @RFF_COMPRADAAno or [RFF_COMPRADAAno] = @RFF_COMPRADAAno and [RFF_COMPRADAMes] = @RFF_COMPRADAMes and [IndicadoresCodigo] = @IndicadoresCodigo and [Cod_Area] = @Cod_Area and [RFF_COMPRADAFecha] = @RFF_COMPRADAFecha and [RFF_COMPRAPRODUCUP] < @RFF_COMPRAPRODUCUP) ORDER BY [RFF_COMPRADAFecha] DESC, [Cod_Area] DESC, [IndicadoresCodigo] DESC, [RFF_COMPRADAMes] DESC, [RFF_COMPRADAAno] DESC, [RFF_COMPRAPRODUCUP] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001511,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001512", "INSERT INTO [RFF_COMPRADA]([RFF_COMPRADAFecha], [RFF_COMPRADAMes], [RFF_COMPRADAAno], [RFF_COMPRAPRODUCUP], [RFF_COMPRATON], [RFF_COMPRAPROVEE], [RFF_COMPRAFINCA], [RFF_COMPRAZONA], [RFF_COMPRAVEREDAID], [RFF_COMPRAVEREDANOM], [RFF_COMPRAMUNIID], [RFF_COMPRAMUNINOM], [RFF_COMPRADEPTOID], [RFF_COMPRADEPTONOM], [RFF_COMPRACLASIFIC], [RFF_COMPRATAMANO], [RFF_COMPRAHAS], [RFF_COMPRADISTAKM], [RFF_COMPRARANDISTAN], [RFF_COMPRAIDACOMPANAM], [RFF_COMPRAACOMPANANOM], [RFF_COMPRARSPO], [RFF_COMPRANATURALEZA], [RFF_COMPRACOORDX], [RFF_COMPRACOORDY], [RFF_COMPRAEDADRANGO], [RFF_COMPRAMATERIAL], [RFF_COMPRACOMITE], [Cod_Area], [IndicadoresCodigo]) VALUES(@RFF_COMPRADAFecha, @RFF_COMPRADAMes, @RFF_COMPRADAAno, @RFF_COMPRAPRODUCUP, @RFF_COMPRATON, @RFF_COMPRAPROVEE, @RFF_COMPRAFINCA, @RFF_COMPRAZONA, @RFF_COMPRAVEREDAID, @RFF_COMPRAVEREDANOM, @RFF_COMPRAMUNIID, @RFF_COMPRAMUNINOM, @RFF_COMPRADEPTOID, @RFF_COMPRADEPTONOM, @RFF_COMPRACLASIFIC, @RFF_COMPRATAMANO, @RFF_COMPRAHAS, @RFF_COMPRADISTAKM, @RFF_COMPRARANDISTAN, @RFF_COMPRAIDACOMPANAM, @RFF_COMPRAACOMPANANOM, @RFF_COMPRARSPO, @RFF_COMPRANATURALEZA, @RFF_COMPRACOORDX, @RFF_COMPRACOORDY, @RFF_COMPRAEDADRANGO, @RFF_COMPRAMATERIAL, @RFF_COMPRACOMITE, @Cod_Area, @IndicadoresCodigo)", GxErrorMask.GX_NOMASK,prmT001512)
             ,new CursorDef("T001513", "UPDATE [RFF_COMPRADA] SET [RFF_COMPRATON]=@RFF_COMPRATON, [RFF_COMPRAPROVEE]=@RFF_COMPRAPROVEE, [RFF_COMPRAFINCA]=@RFF_COMPRAFINCA, [RFF_COMPRAZONA]=@RFF_COMPRAZONA, [RFF_COMPRAVEREDAID]=@RFF_COMPRAVEREDAID, [RFF_COMPRAVEREDANOM]=@RFF_COMPRAVEREDANOM, [RFF_COMPRAMUNIID]=@RFF_COMPRAMUNIID, [RFF_COMPRAMUNINOM]=@RFF_COMPRAMUNINOM, [RFF_COMPRADEPTOID]=@RFF_COMPRADEPTOID, [RFF_COMPRADEPTONOM]=@RFF_COMPRADEPTONOM, [RFF_COMPRACLASIFIC]=@RFF_COMPRACLASIFIC, [RFF_COMPRATAMANO]=@RFF_COMPRATAMANO, [RFF_COMPRAHAS]=@RFF_COMPRAHAS, [RFF_COMPRADISTAKM]=@RFF_COMPRADISTAKM, [RFF_COMPRARANDISTAN]=@RFF_COMPRARANDISTAN, [RFF_COMPRAIDACOMPANAM]=@RFF_COMPRAIDACOMPANAM, [RFF_COMPRAACOMPANANOM]=@RFF_COMPRAACOMPANANOM, [RFF_COMPRARSPO]=@RFF_COMPRARSPO, [RFF_COMPRANATURALEZA]=@RFF_COMPRANATURALEZA, [RFF_COMPRACOORDX]=@RFF_COMPRACOORDX, [RFF_COMPRACOORDY]=@RFF_COMPRACOORDY, [RFF_COMPRAEDADRANGO]=@RFF_COMPRAEDADRANGO, [RFF_COMPRAMATERIAL]=@RFF_COMPRAMATERIAL, [RFF_COMPRACOMITE]=@RFF_COMPRACOMITE  WHERE [RFF_COMPRADAFecha] = @RFF_COMPRADAFecha AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo AND [RFF_COMPRADAMes] = @RFF_COMPRADAMes AND [RFF_COMPRADAAno] = @RFF_COMPRADAAno AND [RFF_COMPRAPRODUCUP] = @RFF_COMPRAPRODUCUP", GxErrorMask.GX_NOMASK,prmT001513)
             ,new CursorDef("T001514", "DELETE FROM [RFF_COMPRADA]  WHERE [RFF_COMPRADAFecha] = @RFF_COMPRADAFecha AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo AND [RFF_COMPRADAMes] = @RFF_COMPRADAMes AND [RFF_COMPRADAAno] = @RFF_COMPRADAAno AND [RFF_COMPRAPRODUCUP] = @RFF_COMPRAPRODUCUP", GxErrorMask.GX_NOMASK,prmT001514)
             ,new CursorDef("T001515", "SELECT [RFF_COMPRADAFecha], [Cod_Area], [IndicadoresCodigo], [RFF_COMPRADAMes], [RFF_COMPRADAAno], [RFF_COMPRAPRODUCUP] FROM [RFF_COMPRADA] ORDER BY [RFF_COMPRADAFecha], [Cod_Area], [IndicadoresCodigo], [RFF_COMPRADAMes], [RFF_COMPRADAAno], [RFF_COMPRAPRODUCUP]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001515,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001516", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT001516,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001517", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT001517,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((string[]) buf[8])[0] = rslt.getVarchar(7);
                ((bool[]) buf[9])[0] = rslt.wasNull(7);
                ((string[]) buf[10])[0] = rslt.getVarchar(8);
                ((bool[]) buf[11])[0] = rslt.wasNull(8);
                ((long[]) buf[12])[0] = rslt.getLong(9);
                ((bool[]) buf[13])[0] = rslt.wasNull(9);
                ((string[]) buf[14])[0] = rslt.getVarchar(10);
                ((bool[]) buf[15])[0] = rslt.wasNull(10);
                ((long[]) buf[16])[0] = rslt.getLong(11);
                ((bool[]) buf[17])[0] = rslt.wasNull(11);
                ((string[]) buf[18])[0] = rslt.getVarchar(12);
                ((bool[]) buf[19])[0] = rslt.wasNull(12);
                ((long[]) buf[20])[0] = rslt.getLong(13);
                ((bool[]) buf[21])[0] = rslt.wasNull(13);
                ((string[]) buf[22])[0] = rslt.getVarchar(14);
                ((bool[]) buf[23])[0] = rslt.wasNull(14);
                ((string[]) buf[24])[0] = rslt.getVarchar(15);
                ((bool[]) buf[25])[0] = rslt.wasNull(15);
                ((string[]) buf[26])[0] = rslt.getVarchar(16);
                ((bool[]) buf[27])[0] = rslt.wasNull(16);
                ((decimal[]) buf[28])[0] = rslt.getDecimal(17);
                ((bool[]) buf[29])[0] = rslt.wasNull(17);
                ((decimal[]) buf[30])[0] = rslt.getDecimal(18);
                ((bool[]) buf[31])[0] = rslt.wasNull(18);
                ((string[]) buf[32])[0] = rslt.getVarchar(19);
                ((bool[]) buf[33])[0] = rslt.wasNull(19);
                ((long[]) buf[34])[0] = rslt.getLong(20);
                ((bool[]) buf[35])[0] = rslt.wasNull(20);
                ((string[]) buf[36])[0] = rslt.getVarchar(21);
                ((bool[]) buf[37])[0] = rslt.wasNull(21);
                ((string[]) buf[38])[0] = rslt.getVarchar(22);
                ((bool[]) buf[39])[0] = rslt.wasNull(22);
                ((string[]) buf[40])[0] = rslt.getVarchar(23);
                ((bool[]) buf[41])[0] = rslt.wasNull(23);
                ((string[]) buf[42])[0] = rslt.getVarchar(24);
                ((bool[]) buf[43])[0] = rslt.wasNull(24);
                ((string[]) buf[44])[0] = rslt.getVarchar(25);
                ((bool[]) buf[45])[0] = rslt.wasNull(25);
                ((string[]) buf[46])[0] = rslt.getVarchar(26);
                ((bool[]) buf[47])[0] = rslt.wasNull(26);
                ((string[]) buf[48])[0] = rslt.getVarchar(27);
                ((bool[]) buf[49])[0] = rslt.wasNull(27);
                ((string[]) buf[50])[0] = rslt.getVarchar(28);
                ((bool[]) buf[51])[0] = rslt.wasNull(28);
                ((string[]) buf[52])[0] = rslt.getVarchar(29);
                ((string[]) buf[53])[0] = rslt.getVarchar(30);
                return;
             case 1 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((string[]) buf[8])[0] = rslt.getVarchar(7);
                ((bool[]) buf[9])[0] = rslt.wasNull(7);
                ((string[]) buf[10])[0] = rslt.getVarchar(8);
                ((bool[]) buf[11])[0] = rslt.wasNull(8);
                ((long[]) buf[12])[0] = rslt.getLong(9);
                ((bool[]) buf[13])[0] = rslt.wasNull(9);
                ((string[]) buf[14])[0] = rslt.getVarchar(10);
                ((bool[]) buf[15])[0] = rslt.wasNull(10);
                ((long[]) buf[16])[0] = rslt.getLong(11);
                ((bool[]) buf[17])[0] = rslt.wasNull(11);
                ((string[]) buf[18])[0] = rslt.getVarchar(12);
                ((bool[]) buf[19])[0] = rslt.wasNull(12);
                ((long[]) buf[20])[0] = rslt.getLong(13);
                ((bool[]) buf[21])[0] = rslt.wasNull(13);
                ((string[]) buf[22])[0] = rslt.getVarchar(14);
                ((bool[]) buf[23])[0] = rslt.wasNull(14);
                ((string[]) buf[24])[0] = rslt.getVarchar(15);
                ((bool[]) buf[25])[0] = rslt.wasNull(15);
                ((string[]) buf[26])[0] = rslt.getVarchar(16);
                ((bool[]) buf[27])[0] = rslt.wasNull(16);
                ((decimal[]) buf[28])[0] = rslt.getDecimal(17);
                ((bool[]) buf[29])[0] = rslt.wasNull(17);
                ((decimal[]) buf[30])[0] = rslt.getDecimal(18);
                ((bool[]) buf[31])[0] = rslt.wasNull(18);
                ((string[]) buf[32])[0] = rslt.getVarchar(19);
                ((bool[]) buf[33])[0] = rslt.wasNull(19);
                ((long[]) buf[34])[0] = rslt.getLong(20);
                ((bool[]) buf[35])[0] = rslt.wasNull(20);
                ((string[]) buf[36])[0] = rslt.getVarchar(21);
                ((bool[]) buf[37])[0] = rslt.wasNull(21);
                ((string[]) buf[38])[0] = rslt.getVarchar(22);
                ((bool[]) buf[39])[0] = rslt.wasNull(22);
                ((string[]) buf[40])[0] = rslt.getVarchar(23);
                ((bool[]) buf[41])[0] = rslt.wasNull(23);
                ((string[]) buf[42])[0] = rslt.getVarchar(24);
                ((bool[]) buf[43])[0] = rslt.wasNull(24);
                ((string[]) buf[44])[0] = rslt.getVarchar(25);
                ((bool[]) buf[45])[0] = rslt.wasNull(25);
                ((string[]) buf[46])[0] = rslt.getVarchar(26);
                ((bool[]) buf[47])[0] = rslt.wasNull(26);
                ((string[]) buf[48])[0] = rslt.getVarchar(27);
                ((bool[]) buf[49])[0] = rslt.wasNull(27);
                ((string[]) buf[50])[0] = rslt.getVarchar(28);
                ((bool[]) buf[51])[0] = rslt.wasNull(28);
                ((string[]) buf[52])[0] = rslt.getVarchar(29);
                ((string[]) buf[53])[0] = rslt.getVarchar(30);
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
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((string[]) buf[8])[0] = rslt.getVarchar(7);
                ((bool[]) buf[9])[0] = rslt.wasNull(7);
                ((string[]) buf[10])[0] = rslt.getVarchar(8);
                ((bool[]) buf[11])[0] = rslt.wasNull(8);
                ((long[]) buf[12])[0] = rslt.getLong(9);
                ((bool[]) buf[13])[0] = rslt.wasNull(9);
                ((string[]) buf[14])[0] = rslt.getVarchar(10);
                ((bool[]) buf[15])[0] = rslt.wasNull(10);
                ((long[]) buf[16])[0] = rslt.getLong(11);
                ((bool[]) buf[17])[0] = rslt.wasNull(11);
                ((string[]) buf[18])[0] = rslt.getVarchar(12);
                ((bool[]) buf[19])[0] = rslt.wasNull(12);
                ((long[]) buf[20])[0] = rslt.getLong(13);
                ((bool[]) buf[21])[0] = rslt.wasNull(13);
                ((string[]) buf[22])[0] = rslt.getVarchar(14);
                ((bool[]) buf[23])[0] = rslt.wasNull(14);
                ((string[]) buf[24])[0] = rslt.getVarchar(15);
                ((bool[]) buf[25])[0] = rslt.wasNull(15);
                ((string[]) buf[26])[0] = rslt.getVarchar(16);
                ((bool[]) buf[27])[0] = rslt.wasNull(16);
                ((decimal[]) buf[28])[0] = rslt.getDecimal(17);
                ((bool[]) buf[29])[0] = rslt.wasNull(17);
                ((decimal[]) buf[30])[0] = rslt.getDecimal(18);
                ((bool[]) buf[31])[0] = rslt.wasNull(18);
                ((string[]) buf[32])[0] = rslt.getVarchar(19);
                ((bool[]) buf[33])[0] = rslt.wasNull(19);
                ((long[]) buf[34])[0] = rslt.getLong(20);
                ((bool[]) buf[35])[0] = rslt.wasNull(20);
                ((string[]) buf[36])[0] = rslt.getVarchar(21);
                ((bool[]) buf[37])[0] = rslt.wasNull(21);
                ((string[]) buf[38])[0] = rslt.getVarchar(22);
                ((bool[]) buf[39])[0] = rslt.wasNull(22);
                ((string[]) buf[40])[0] = rslt.getVarchar(23);
                ((bool[]) buf[41])[0] = rslt.wasNull(23);
                ((string[]) buf[42])[0] = rslt.getVarchar(24);
                ((bool[]) buf[43])[0] = rslt.wasNull(24);
                ((string[]) buf[44])[0] = rslt.getVarchar(25);
                ((bool[]) buf[45])[0] = rslt.wasNull(25);
                ((string[]) buf[46])[0] = rslt.getVarchar(26);
                ((bool[]) buf[47])[0] = rslt.wasNull(26);
                ((string[]) buf[48])[0] = rslt.getVarchar(27);
                ((bool[]) buf[49])[0] = rslt.wasNull(27);
                ((string[]) buf[50])[0] = rslt.getVarchar(28);
                ((bool[]) buf[51])[0] = rslt.wasNull(28);
                ((string[]) buf[52])[0] = rslt.getVarchar(29);
                ((string[]) buf[53])[0] = rslt.getVarchar(30);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 7 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                return;
             case 8 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                return;
             case 9 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                return;
             case 13 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
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
