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
   public class metasindicadores : GXDataArea
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
            A4IndicadoresCodigo = GetPar( "IndicadoresCodigo");
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A4IndicadoresCodigo) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A31TipoMetasCodigo = GetPar( "TipoMetasCodigo");
            AssignAttri("", false, "A31TipoMetasCodigo", A31TipoMetasCodigo);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A31TipoMetasCodigo) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A16UsuariosCodigo = GetPar( "UsuariosCodigo");
            AssignAttri("", false, "A16UsuariosCodigo", A16UsuariosCodigo);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A16UsuariosCodigo) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A34MotivosMetasCodigo = GetPar( "MotivosMetasCodigo");
            AssignAttri("", false, "A34MotivosMetasCodigo", A34MotivosMetasCodigo);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A34MotivosMetasCodigo) ;
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
            Form.Meta.addItem("description", "Metas Indicadores", 0) ;
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

      public metasindicadores( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("IndicadroresPalmas", true);
      }

      public metasindicadores( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Metas Indicadores", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_MetasIndicadores.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_MetasIndicadores.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_MetasIndicadores.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_MetasIndicadores.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_MetasIndicadores.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 4, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx00f0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"INDICADORESCODIGO"+"'), id:'"+"INDICADORESCODIGO"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"METASINDICADORESMES"+"'), id:'"+"METASINDICADORESMES"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"METASINDICADORESANO"+"'), id:'"+"METASINDICADORESANO"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"TIPOMETASCODIGO"+"'), id:'"+"TIPOMETASCODIGO"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_MetasIndicadores.htm");
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
         GxWebStd.gx_label_element( context, edtIndicadoresCodigo_Internalname, "Indicadores Codigo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIndicadoresCodigo_Internalname, A4IndicadoresCodigo, StringUtil.RTrim( context.localUtil.Format( A4IndicadoresCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIndicadoresCodigo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIndicadoresCodigo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_MetasIndicadores.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_4_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_4_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_4_Internalname, sImgUrl, imgprompt_4_Link, "", "", context.GetTheme( ), imgprompt_4_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_MetasIndicadores.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMetasIndicadoresMes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMetasIndicadoresMes_Internalname, "Indicadores Mes", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMetasIndicadoresMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A32MetasIndicadoresMes), 4, 0, ",", "")), StringUtil.LTrim( ((edtMetasIndicadoresMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A32MetasIndicadoresMes), "ZZZ9") : context.localUtil.Format( (decimal)(A32MetasIndicadoresMes), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMetasIndicadoresMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMetasIndicadoresMes_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_MetasIndicadores.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMetasIndicadoresAno_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMetasIndicadoresAno_Internalname, "Indicadores Ano", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMetasIndicadoresAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A33MetasIndicadoresAno), 4, 0, ",", "")), StringUtil.LTrim( ((edtMetasIndicadoresAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A33MetasIndicadoresAno), "ZZZ9") : context.localUtil.Format( (decimal)(A33MetasIndicadoresAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMetasIndicadoresAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMetasIndicadoresAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_MetasIndicadores.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTipoMetasCodigo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTipoMetasCodigo_Internalname, "Tipo Metas Codigo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipoMetasCodigo_Internalname, A31TipoMetasCodigo, StringUtil.RTrim( context.localUtil.Format( A31TipoMetasCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipoMetasCodigo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipoMetasCodigo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_MetasIndicadores.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_31_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_31_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_31_Internalname, sImgUrl, imgprompt_31_Link, "", "", context.GetTheme( ), imgprompt_31_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_MetasIndicadores.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMetasIndicadoresValorMes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMetasIndicadoresValorMes_Internalname, "Valor Mes", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMetasIndicadoresValorMes_Internalname, StringUtil.LTrim( StringUtil.NToC( A143MetasIndicadoresValorMes, 12, 2, ",", "")), StringUtil.LTrim( ((edtMetasIndicadoresValorMes_Enabled!=0) ? context.localUtil.Format( A143MetasIndicadoresValorMes, "ZZZZZZZZ9.99") : context.localUtil.Format( A143MetasIndicadoresValorMes, "ZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMetasIndicadoresValorMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMetasIndicadoresValorMes_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_MetasIndicadores.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMetasIndicadoresTicketNro_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMetasIndicadoresTicketNro_Internalname, "Ticket Nro", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMetasIndicadoresTicketNro_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A139MetasIndicadoresTicketNro), 10, 0, ",", "")), StringUtil.LTrim( ((edtMetasIndicadoresTicketNro_Enabled!=0) ? context.localUtil.Format( (decimal)(A139MetasIndicadoresTicketNro), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A139MetasIndicadoresTicketNro), "ZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMetasIndicadoresTicketNro_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMetasIndicadoresTicketNro_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_MetasIndicadores.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuariosCodigo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuariosCodigo_Internalname, "Usuarios Codigo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuariosCodigo_Internalname, A16UsuariosCodigo, StringUtil.RTrim( context.localUtil.Format( A16UsuariosCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuariosCodigo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuariosCodigo_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_MetasIndicadores.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_16_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_16_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_16_Internalname, sImgUrl, imgprompt_16_Link, "", "", context.GetTheme( ), imgprompt_16_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_MetasIndicadores.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMotivosMetasCodigo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMotivosMetasCodigo_Internalname, "Motivos Metas Codigo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMotivosMetasCodigo_Internalname, A34MotivosMetasCodigo, StringUtil.RTrim( context.localUtil.Format( A34MotivosMetasCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMotivosMetasCodigo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMotivosMetasCodigo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_MetasIndicadores.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_34_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_34_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_34_Internalname, sImgUrl, imgprompt_34_Link, "", "", context.GetTheme( ), imgprompt_34_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_MetasIndicadores.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMetasIndicadoresReg_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMetasIndicadoresReg_Internalname, "Indicadores Reg", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtMetasIndicadoresReg_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtMetasIndicadoresReg_Internalname, context.localUtil.Format(A141MetasIndicadoresReg, "99/99/99"), context.localUtil.Format( A141MetasIndicadoresReg, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMetasIndicadoresReg_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMetasIndicadoresReg_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_MetasIndicadores.htm");
         GxWebStd.gx_bitmap( context, edtMetasIndicadoresReg_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtMetasIndicadoresReg_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_MetasIndicadores.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMetasIndicadoresHor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMetasIndicadoresHor_Internalname, "Indicadores Hor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMetasIndicadoresHor_Internalname, A142MetasIndicadoresHor, StringUtil.RTrim( context.localUtil.Format( A142MetasIndicadoresHor, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMetasIndicadoresHor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMetasIndicadoresHor_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_MetasIndicadores.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMetasIndicadoresValorAno_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMetasIndicadoresValorAno_Internalname, "Valor Ano", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMetasIndicadoresValorAno_Internalname, StringUtil.LTrim( StringUtil.NToC( A144MetasIndicadoresValorAno, 12, 2, ",", "")), StringUtil.LTrim( ((edtMetasIndicadoresValorAno_Enabled!=0) ? context.localUtil.Format( A144MetasIndicadoresValorAno, "ZZZZZZZZ9.99") : context.localUtil.Format( A144MetasIndicadoresValorAno, "ZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMetasIndicadoresValorAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMetasIndicadoresValorAno_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_MetasIndicadores.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_MetasIndicadores.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_MetasIndicadores.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_MetasIndicadores.htm");
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
            Z32MetasIndicadoresMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z32MetasIndicadoresMes"), ",", "."), 18, MidpointRounding.ToEven));
            Z33MetasIndicadoresAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z33MetasIndicadoresAno"), ",", "."), 18, MidpointRounding.ToEven));
            Z31TipoMetasCodigo = cgiGet( "Z31TipoMetasCodigo");
            Z143MetasIndicadoresValorMes = context.localUtil.CToN( cgiGet( "Z143MetasIndicadoresValorMes"), ",", ".");
            Z139MetasIndicadoresTicketNro = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z139MetasIndicadoresTicketNro"), ",", "."), 18, MidpointRounding.ToEven));
            Z141MetasIndicadoresReg = context.localUtil.CToD( cgiGet( "Z141MetasIndicadoresReg"), 0);
            Z142MetasIndicadoresHor = cgiGet( "Z142MetasIndicadoresHor");
            Z144MetasIndicadoresValorAno = context.localUtil.CToN( cgiGet( "Z144MetasIndicadoresValorAno"), ",", ".");
            Z16UsuariosCodigo = cgiGet( "Z16UsuariosCodigo");
            Z34MotivosMetasCodigo = cgiGet( "Z34MotivosMetasCodigo");
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A4IndicadoresCodigo = cgiGet( edtIndicadoresCodigo_Internalname);
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            if ( ( ( context.localUtil.CToN( cgiGet( edtMetasIndicadoresMes_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMetasIndicadoresMes_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "METASINDICADORESMES");
               AnyError = 1;
               GX_FocusControl = edtMetasIndicadoresMes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A32MetasIndicadoresMes = 0;
               AssignAttri("", false, "A32MetasIndicadoresMes", StringUtil.LTrimStr( (decimal)(A32MetasIndicadoresMes), 4, 0));
            }
            else
            {
               A32MetasIndicadoresMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtMetasIndicadoresMes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A32MetasIndicadoresMes", StringUtil.LTrimStr( (decimal)(A32MetasIndicadoresMes), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtMetasIndicadoresAno_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMetasIndicadoresAno_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "METASINDICADORESANO");
               AnyError = 1;
               GX_FocusControl = edtMetasIndicadoresAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A33MetasIndicadoresAno = 0;
               AssignAttri("", false, "A33MetasIndicadoresAno", StringUtil.LTrimStr( (decimal)(A33MetasIndicadoresAno), 4, 0));
            }
            else
            {
               A33MetasIndicadoresAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtMetasIndicadoresAno_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A33MetasIndicadoresAno", StringUtil.LTrimStr( (decimal)(A33MetasIndicadoresAno), 4, 0));
            }
            A31TipoMetasCodigo = cgiGet( edtTipoMetasCodigo_Internalname);
            AssignAttri("", false, "A31TipoMetasCodigo", A31TipoMetasCodigo);
            if ( ( ( context.localUtil.CToN( cgiGet( edtMetasIndicadoresValorMes_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMetasIndicadoresValorMes_Internalname), ",", ".") > 999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "METASINDICADORESVALORMES");
               AnyError = 1;
               GX_FocusControl = edtMetasIndicadoresValorMes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A143MetasIndicadoresValorMes = 0;
               AssignAttri("", false, "A143MetasIndicadoresValorMes", StringUtil.LTrimStr( A143MetasIndicadoresValorMes, 12, 2));
            }
            else
            {
               A143MetasIndicadoresValorMes = context.localUtil.CToN( cgiGet( edtMetasIndicadoresValorMes_Internalname), ",", ".");
               AssignAttri("", false, "A143MetasIndicadoresValorMes", StringUtil.LTrimStr( A143MetasIndicadoresValorMes, 12, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtMetasIndicadoresTicketNro_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMetasIndicadoresTicketNro_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "METASINDICADORESTICKETNRO");
               AnyError = 1;
               GX_FocusControl = edtMetasIndicadoresTicketNro_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A139MetasIndicadoresTicketNro = 0;
               AssignAttri("", false, "A139MetasIndicadoresTicketNro", StringUtil.LTrimStr( (decimal)(A139MetasIndicadoresTicketNro), 10, 0));
            }
            else
            {
               A139MetasIndicadoresTicketNro = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtMetasIndicadoresTicketNro_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A139MetasIndicadoresTicketNro", StringUtil.LTrimStr( (decimal)(A139MetasIndicadoresTicketNro), 10, 0));
            }
            A16UsuariosCodigo = cgiGet( edtUsuariosCodigo_Internalname);
            AssignAttri("", false, "A16UsuariosCodigo", A16UsuariosCodigo);
            A34MotivosMetasCodigo = cgiGet( edtMotivosMetasCodigo_Internalname);
            AssignAttri("", false, "A34MotivosMetasCodigo", A34MotivosMetasCodigo);
            if ( context.localUtil.VCDate( cgiGet( edtMetasIndicadoresReg_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Metas Indicadores Reg"}), 1, "METASINDICADORESREG");
               AnyError = 1;
               GX_FocusControl = edtMetasIndicadoresReg_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A141MetasIndicadoresReg = DateTime.MinValue;
               AssignAttri("", false, "A141MetasIndicadoresReg", context.localUtil.Format(A141MetasIndicadoresReg, "99/99/99"));
            }
            else
            {
               A141MetasIndicadoresReg = context.localUtil.CToD( cgiGet( edtMetasIndicadoresReg_Internalname), 2);
               AssignAttri("", false, "A141MetasIndicadoresReg", context.localUtil.Format(A141MetasIndicadoresReg, "99/99/99"));
            }
            A142MetasIndicadoresHor = cgiGet( edtMetasIndicadoresHor_Internalname);
            AssignAttri("", false, "A142MetasIndicadoresHor", A142MetasIndicadoresHor);
            if ( ( ( context.localUtil.CToN( cgiGet( edtMetasIndicadoresValorAno_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMetasIndicadoresValorAno_Internalname), ",", ".") > 999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "METASINDICADORESVALORANO");
               AnyError = 1;
               GX_FocusControl = edtMetasIndicadoresValorAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A144MetasIndicadoresValorAno = 0;
               AssignAttri("", false, "A144MetasIndicadoresValorAno", StringUtil.LTrimStr( A144MetasIndicadoresValorAno, 12, 2));
            }
            else
            {
               A144MetasIndicadoresValorAno = context.localUtil.CToN( cgiGet( edtMetasIndicadoresValorAno_Internalname), ",", ".");
               AssignAttri("", false, "A144MetasIndicadoresValorAno", StringUtil.LTrimStr( A144MetasIndicadoresValorAno, 12, 2));
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
               A4IndicadoresCodigo = GetPar( "IndicadoresCodigo");
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               A32MetasIndicadoresMes = (short)(Math.Round(NumberUtil.Val( GetPar( "MetasIndicadoresMes"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A32MetasIndicadoresMes", StringUtil.LTrimStr( (decimal)(A32MetasIndicadoresMes), 4, 0));
               A33MetasIndicadoresAno = (short)(Math.Round(NumberUtil.Val( GetPar( "MetasIndicadoresAno"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A33MetasIndicadoresAno", StringUtil.LTrimStr( (decimal)(A33MetasIndicadoresAno), 4, 0));
               A31TipoMetasCodigo = GetPar( "TipoMetasCodigo");
               AssignAttri("", false, "A31TipoMetasCodigo", A31TipoMetasCodigo);
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
               InitAll0E15( ) ;
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
         DisableAttributes0E15( ) ;
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

      protected void ResetCaption0E0( )
      {
      }

      protected void ZM0E15( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z143MetasIndicadoresValorMes = T000E3_A143MetasIndicadoresValorMes[0];
               Z139MetasIndicadoresTicketNro = T000E3_A139MetasIndicadoresTicketNro[0];
               Z141MetasIndicadoresReg = T000E3_A141MetasIndicadoresReg[0];
               Z142MetasIndicadoresHor = T000E3_A142MetasIndicadoresHor[0];
               Z144MetasIndicadoresValorAno = T000E3_A144MetasIndicadoresValorAno[0];
               Z16UsuariosCodigo = T000E3_A16UsuariosCodigo[0];
               Z34MotivosMetasCodigo = T000E3_A34MotivosMetasCodigo[0];
            }
            else
            {
               Z143MetasIndicadoresValorMes = A143MetasIndicadoresValorMes;
               Z139MetasIndicadoresTicketNro = A139MetasIndicadoresTicketNro;
               Z141MetasIndicadoresReg = A141MetasIndicadoresReg;
               Z142MetasIndicadoresHor = A142MetasIndicadoresHor;
               Z144MetasIndicadoresValorAno = A144MetasIndicadoresValorAno;
               Z16UsuariosCodigo = A16UsuariosCodigo;
               Z34MotivosMetasCodigo = A34MotivosMetasCodigo;
            }
         }
         if ( GX_JID == -2 )
         {
            Z32MetasIndicadoresMes = A32MetasIndicadoresMes;
            Z33MetasIndicadoresAno = A33MetasIndicadoresAno;
            Z143MetasIndicadoresValorMes = A143MetasIndicadoresValorMes;
            Z139MetasIndicadoresTicketNro = A139MetasIndicadoresTicketNro;
            Z141MetasIndicadoresReg = A141MetasIndicadoresReg;
            Z142MetasIndicadoresHor = A142MetasIndicadoresHor;
            Z144MetasIndicadoresValorAno = A144MetasIndicadoresValorAno;
            Z4IndicadoresCodigo = A4IndicadoresCodigo;
            Z31TipoMetasCodigo = A31TipoMetasCodigo;
            Z16UsuariosCodigo = A16UsuariosCodigo;
            Z34MotivosMetasCodigo = A34MotivosMetasCodigo;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_4_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0030.aspx"+"',["+"{Ctrl:gx.dom.el('"+"INDICADORESCODIGO"+"'), id:'"+"INDICADORESCODIGO"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"true"+");");
         imgprompt_31_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx00e0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"TIPOMETASCODIGO"+"'), id:'"+"TIPOMETASCODIGO"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");");
         imgprompt_16_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0020.aspx"+"',["+"{Ctrl:gx.dom.el('"+"USUARIOSCODIGO"+"'), id:'"+"USUARIOSCODIGO"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_34_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx00g0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"MOTIVOSMETASCODIGO"+"'), id:'"+"MOTIVOSMETASCODIGO"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
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

      protected void Load0E15( )
      {
         /* Using cursor T000E8 */
         pr_default.execute(6, new Object[] {A4IndicadoresCodigo, A32MetasIndicadoresMes, A33MetasIndicadoresAno, A31TipoMetasCodigo});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound15 = 1;
            A143MetasIndicadoresValorMes = T000E8_A143MetasIndicadoresValorMes[0];
            AssignAttri("", false, "A143MetasIndicadoresValorMes", StringUtil.LTrimStr( A143MetasIndicadoresValorMes, 12, 2));
            A139MetasIndicadoresTicketNro = T000E8_A139MetasIndicadoresTicketNro[0];
            AssignAttri("", false, "A139MetasIndicadoresTicketNro", StringUtil.LTrimStr( (decimal)(A139MetasIndicadoresTicketNro), 10, 0));
            A141MetasIndicadoresReg = T000E8_A141MetasIndicadoresReg[0];
            AssignAttri("", false, "A141MetasIndicadoresReg", context.localUtil.Format(A141MetasIndicadoresReg, "99/99/99"));
            A142MetasIndicadoresHor = T000E8_A142MetasIndicadoresHor[0];
            AssignAttri("", false, "A142MetasIndicadoresHor", A142MetasIndicadoresHor);
            A144MetasIndicadoresValorAno = T000E8_A144MetasIndicadoresValorAno[0];
            AssignAttri("", false, "A144MetasIndicadoresValorAno", StringUtil.LTrimStr( A144MetasIndicadoresValorAno, 12, 2));
            A16UsuariosCodigo = T000E8_A16UsuariosCodigo[0];
            AssignAttri("", false, "A16UsuariosCodigo", A16UsuariosCodigo);
            A34MotivosMetasCodigo = T000E8_A34MotivosMetasCodigo[0];
            AssignAttri("", false, "A34MotivosMetasCodigo", A34MotivosMetasCodigo);
            ZM0E15( -2) ;
         }
         pr_default.close(6);
         OnLoadActions0E15( ) ;
      }

      protected void OnLoadActions0E15( )
      {
      }

      protected void CheckExtendedTable0E15( )
      {
         nIsDirty_15 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T000E4 */
         pr_default.execute(2, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T000E5 */
         pr_default.execute(3, new Object[] {A31TipoMetasCodigo});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo Metas'.", "ForeignKeyNotFound", 1, "TIPOMETASCODIGO");
            AnyError = 1;
            GX_FocusControl = edtTipoMetasCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         /* Using cursor T000E6 */
         pr_default.execute(4, new Object[] {A16UsuariosCodigo});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Usuarios'.", "ForeignKeyNotFound", 1, "USUARIOSCODIGO");
            AnyError = 1;
            GX_FocusControl = edtUsuariosCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(4);
         /* Using cursor T000E7 */
         pr_default.execute(5, new Object[] {A34MotivosMetasCodigo});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Motivos Metas'.", "ForeignKeyNotFound", 1, "MOTIVOSMETASCODIGO");
            AnyError = 1;
            GX_FocusControl = edtMotivosMetasCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(5);
         if ( ! ( (DateTime.MinValue==A141MetasIndicadoresReg) || ( DateTimeUtil.ResetTime ( A141MetasIndicadoresReg ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Metas Indicadores Reg fuera de rango", "OutOfRange", 1, "METASINDICADORESREG");
            AnyError = 1;
            GX_FocusControl = edtMetasIndicadoresReg_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0E15( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( string A4IndicadoresCodigo )
      {
         /* Using cursor T000E9 */
         pr_default.execute(7, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_4( string A31TipoMetasCodigo )
      {
         /* Using cursor T000E10 */
         pr_default.execute(8, new Object[] {A31TipoMetasCodigo});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo Metas'.", "ForeignKeyNotFound", 1, "TIPOMETASCODIGO");
            AnyError = 1;
            GX_FocusControl = edtTipoMetasCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void gxLoad_5( string A16UsuariosCodigo )
      {
         /* Using cursor T000E11 */
         pr_default.execute(9, new Object[] {A16UsuariosCodigo});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No existe 'Usuarios'.", "ForeignKeyNotFound", 1, "USUARIOSCODIGO");
            AnyError = 1;
            GX_FocusControl = edtUsuariosCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_6( string A34MotivosMetasCodigo )
      {
         /* Using cursor T000E12 */
         pr_default.execute(10, new Object[] {A34MotivosMetasCodigo});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem("No existe 'Motivos Metas'.", "ForeignKeyNotFound", 1, "MOTIVOSMETASCODIGO");
            AnyError = 1;
            GX_FocusControl = edtMotivosMetasCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void GetKey0E15( )
      {
         /* Using cursor T000E13 */
         pr_default.execute(11, new Object[] {A4IndicadoresCodigo, A32MetasIndicadoresMes, A33MetasIndicadoresAno, A31TipoMetasCodigo});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound15 = 1;
         }
         else
         {
            RcdFound15 = 0;
         }
         pr_default.close(11);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000E3 */
         pr_default.execute(1, new Object[] {A4IndicadoresCodigo, A32MetasIndicadoresMes, A33MetasIndicadoresAno, A31TipoMetasCodigo});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0E15( 2) ;
            RcdFound15 = 1;
            A32MetasIndicadoresMes = T000E3_A32MetasIndicadoresMes[0];
            AssignAttri("", false, "A32MetasIndicadoresMes", StringUtil.LTrimStr( (decimal)(A32MetasIndicadoresMes), 4, 0));
            A33MetasIndicadoresAno = T000E3_A33MetasIndicadoresAno[0];
            AssignAttri("", false, "A33MetasIndicadoresAno", StringUtil.LTrimStr( (decimal)(A33MetasIndicadoresAno), 4, 0));
            A143MetasIndicadoresValorMes = T000E3_A143MetasIndicadoresValorMes[0];
            AssignAttri("", false, "A143MetasIndicadoresValorMes", StringUtil.LTrimStr( A143MetasIndicadoresValorMes, 12, 2));
            A139MetasIndicadoresTicketNro = T000E3_A139MetasIndicadoresTicketNro[0];
            AssignAttri("", false, "A139MetasIndicadoresTicketNro", StringUtil.LTrimStr( (decimal)(A139MetasIndicadoresTicketNro), 10, 0));
            A141MetasIndicadoresReg = T000E3_A141MetasIndicadoresReg[0];
            AssignAttri("", false, "A141MetasIndicadoresReg", context.localUtil.Format(A141MetasIndicadoresReg, "99/99/99"));
            A142MetasIndicadoresHor = T000E3_A142MetasIndicadoresHor[0];
            AssignAttri("", false, "A142MetasIndicadoresHor", A142MetasIndicadoresHor);
            A144MetasIndicadoresValorAno = T000E3_A144MetasIndicadoresValorAno[0];
            AssignAttri("", false, "A144MetasIndicadoresValorAno", StringUtil.LTrimStr( A144MetasIndicadoresValorAno, 12, 2));
            A4IndicadoresCodigo = T000E3_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A31TipoMetasCodigo = T000E3_A31TipoMetasCodigo[0];
            AssignAttri("", false, "A31TipoMetasCodigo", A31TipoMetasCodigo);
            A16UsuariosCodigo = T000E3_A16UsuariosCodigo[0];
            AssignAttri("", false, "A16UsuariosCodigo", A16UsuariosCodigo);
            A34MotivosMetasCodigo = T000E3_A34MotivosMetasCodigo[0];
            AssignAttri("", false, "A34MotivosMetasCodigo", A34MotivosMetasCodigo);
            Z4IndicadoresCodigo = A4IndicadoresCodigo;
            Z32MetasIndicadoresMes = A32MetasIndicadoresMes;
            Z33MetasIndicadoresAno = A33MetasIndicadoresAno;
            Z31TipoMetasCodigo = A31TipoMetasCodigo;
            sMode15 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0E15( ) ;
            if ( AnyError == 1 )
            {
               RcdFound15 = 0;
               InitializeNonKey0E15( ) ;
            }
            Gx_mode = sMode15;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound15 = 0;
            InitializeNonKey0E15( ) ;
            sMode15 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode15;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0E15( ) ;
         if ( RcdFound15 == 0 )
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
         RcdFound15 = 0;
         /* Using cursor T000E14 */
         pr_default.execute(12, new Object[] {A4IndicadoresCodigo, A32MetasIndicadoresMes, A33MetasIndicadoresAno, A31TipoMetasCodigo});
         if ( (pr_default.getStatus(12) != 101) )
         {
            while ( (pr_default.getStatus(12) != 101) && ( ( StringUtil.StrCmp(T000E14_A4IndicadoresCodigo[0], A4IndicadoresCodigo) < 0 ) || ( StringUtil.StrCmp(T000E14_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000E14_A32MetasIndicadoresMes[0] < A32MetasIndicadoresMes ) || ( T000E14_A32MetasIndicadoresMes[0] == A32MetasIndicadoresMes ) && ( StringUtil.StrCmp(T000E14_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000E14_A33MetasIndicadoresAno[0] < A33MetasIndicadoresAno ) || ( T000E14_A33MetasIndicadoresAno[0] == A33MetasIndicadoresAno ) && ( T000E14_A32MetasIndicadoresMes[0] == A32MetasIndicadoresMes ) && ( StringUtil.StrCmp(T000E14_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T000E14_A31TipoMetasCodigo[0], A31TipoMetasCodigo) < 0 ) ) )
            {
               pr_default.readNext(12);
            }
            if ( (pr_default.getStatus(12) != 101) && ( ( StringUtil.StrCmp(T000E14_A4IndicadoresCodigo[0], A4IndicadoresCodigo) > 0 ) || ( StringUtil.StrCmp(T000E14_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000E14_A32MetasIndicadoresMes[0] > A32MetasIndicadoresMes ) || ( T000E14_A32MetasIndicadoresMes[0] == A32MetasIndicadoresMes ) && ( StringUtil.StrCmp(T000E14_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000E14_A33MetasIndicadoresAno[0] > A33MetasIndicadoresAno ) || ( T000E14_A33MetasIndicadoresAno[0] == A33MetasIndicadoresAno ) && ( T000E14_A32MetasIndicadoresMes[0] == A32MetasIndicadoresMes ) && ( StringUtil.StrCmp(T000E14_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T000E14_A31TipoMetasCodigo[0], A31TipoMetasCodigo) > 0 ) ) )
            {
               A4IndicadoresCodigo = T000E14_A4IndicadoresCodigo[0];
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               A32MetasIndicadoresMes = T000E14_A32MetasIndicadoresMes[0];
               AssignAttri("", false, "A32MetasIndicadoresMes", StringUtil.LTrimStr( (decimal)(A32MetasIndicadoresMes), 4, 0));
               A33MetasIndicadoresAno = T000E14_A33MetasIndicadoresAno[0];
               AssignAttri("", false, "A33MetasIndicadoresAno", StringUtil.LTrimStr( (decimal)(A33MetasIndicadoresAno), 4, 0));
               A31TipoMetasCodigo = T000E14_A31TipoMetasCodigo[0];
               AssignAttri("", false, "A31TipoMetasCodigo", A31TipoMetasCodigo);
               RcdFound15 = 1;
            }
         }
         pr_default.close(12);
      }

      protected void move_previous( )
      {
         RcdFound15 = 0;
         /* Using cursor T000E15 */
         pr_default.execute(13, new Object[] {A4IndicadoresCodigo, A32MetasIndicadoresMes, A33MetasIndicadoresAno, A31TipoMetasCodigo});
         if ( (pr_default.getStatus(13) != 101) )
         {
            while ( (pr_default.getStatus(13) != 101) && ( ( StringUtil.StrCmp(T000E15_A4IndicadoresCodigo[0], A4IndicadoresCodigo) > 0 ) || ( StringUtil.StrCmp(T000E15_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000E15_A32MetasIndicadoresMes[0] > A32MetasIndicadoresMes ) || ( T000E15_A32MetasIndicadoresMes[0] == A32MetasIndicadoresMes ) && ( StringUtil.StrCmp(T000E15_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000E15_A33MetasIndicadoresAno[0] > A33MetasIndicadoresAno ) || ( T000E15_A33MetasIndicadoresAno[0] == A33MetasIndicadoresAno ) && ( T000E15_A32MetasIndicadoresMes[0] == A32MetasIndicadoresMes ) && ( StringUtil.StrCmp(T000E15_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T000E15_A31TipoMetasCodigo[0], A31TipoMetasCodigo) > 0 ) ) )
            {
               pr_default.readNext(13);
            }
            if ( (pr_default.getStatus(13) != 101) && ( ( StringUtil.StrCmp(T000E15_A4IndicadoresCodigo[0], A4IndicadoresCodigo) < 0 ) || ( StringUtil.StrCmp(T000E15_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000E15_A32MetasIndicadoresMes[0] < A32MetasIndicadoresMes ) || ( T000E15_A32MetasIndicadoresMes[0] == A32MetasIndicadoresMes ) && ( StringUtil.StrCmp(T000E15_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000E15_A33MetasIndicadoresAno[0] < A33MetasIndicadoresAno ) || ( T000E15_A33MetasIndicadoresAno[0] == A33MetasIndicadoresAno ) && ( T000E15_A32MetasIndicadoresMes[0] == A32MetasIndicadoresMes ) && ( StringUtil.StrCmp(T000E15_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T000E15_A31TipoMetasCodigo[0], A31TipoMetasCodigo) < 0 ) ) )
            {
               A4IndicadoresCodigo = T000E15_A4IndicadoresCodigo[0];
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               A32MetasIndicadoresMes = T000E15_A32MetasIndicadoresMes[0];
               AssignAttri("", false, "A32MetasIndicadoresMes", StringUtil.LTrimStr( (decimal)(A32MetasIndicadoresMes), 4, 0));
               A33MetasIndicadoresAno = T000E15_A33MetasIndicadoresAno[0];
               AssignAttri("", false, "A33MetasIndicadoresAno", StringUtil.LTrimStr( (decimal)(A33MetasIndicadoresAno), 4, 0));
               A31TipoMetasCodigo = T000E15_A31TipoMetasCodigo[0];
               AssignAttri("", false, "A31TipoMetasCodigo", A31TipoMetasCodigo);
               RcdFound15 = 1;
            }
         }
         pr_default.close(13);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0E15( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0E15( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound15 == 1 )
            {
               if ( ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) || ( A32MetasIndicadoresMes != Z32MetasIndicadoresMes ) || ( A33MetasIndicadoresAno != Z33MetasIndicadoresAno ) || ( StringUtil.StrCmp(A31TipoMetasCodigo, Z31TipoMetasCodigo) != 0 ) )
               {
                  A4IndicadoresCodigo = Z4IndicadoresCodigo;
                  AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
                  A32MetasIndicadoresMes = Z32MetasIndicadoresMes;
                  AssignAttri("", false, "A32MetasIndicadoresMes", StringUtil.LTrimStr( (decimal)(A32MetasIndicadoresMes), 4, 0));
                  A33MetasIndicadoresAno = Z33MetasIndicadoresAno;
                  AssignAttri("", false, "A33MetasIndicadoresAno", StringUtil.LTrimStr( (decimal)(A33MetasIndicadoresAno), 4, 0));
                  A31TipoMetasCodigo = Z31TipoMetasCodigo;
                  AssignAttri("", false, "A31TipoMetasCodigo", A31TipoMetasCodigo);
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
                  Update0E15( ) ;
                  GX_FocusControl = edtIndicadoresCodigo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) || ( A32MetasIndicadoresMes != Z32MetasIndicadoresMes ) || ( A33MetasIndicadoresAno != Z33MetasIndicadoresAno ) || ( StringUtil.StrCmp(A31TipoMetasCodigo, Z31TipoMetasCodigo) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtIndicadoresCodigo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0E15( ) ;
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
                     Insert0E15( ) ;
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
         if ( ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) || ( A32MetasIndicadoresMes != Z32MetasIndicadoresMes ) || ( A33MetasIndicadoresAno != Z33MetasIndicadoresAno ) || ( StringUtil.StrCmp(A31TipoMetasCodigo, Z31TipoMetasCodigo) != 0 ) )
         {
            A4IndicadoresCodigo = Z4IndicadoresCodigo;
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A32MetasIndicadoresMes = Z32MetasIndicadoresMes;
            AssignAttri("", false, "A32MetasIndicadoresMes", StringUtil.LTrimStr( (decimal)(A32MetasIndicadoresMes), 4, 0));
            A33MetasIndicadoresAno = Z33MetasIndicadoresAno;
            AssignAttri("", false, "A33MetasIndicadoresAno", StringUtil.LTrimStr( (decimal)(A33MetasIndicadoresAno), 4, 0));
            A31TipoMetasCodigo = Z31TipoMetasCodigo;
            AssignAttri("", false, "A31TipoMetasCodigo", A31TipoMetasCodigo);
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
         if ( RcdFound15 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtMetasIndicadoresValorMes_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0E15( ) ;
         if ( RcdFound15 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMetasIndicadoresValorMes_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0E15( ) ;
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
         if ( RcdFound15 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMetasIndicadoresValorMes_Internalname;
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
         if ( RcdFound15 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMetasIndicadoresValorMes_Internalname;
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
         ScanStart0E15( ) ;
         if ( RcdFound15 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound15 != 0 )
            {
               ScanNext0E15( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMetasIndicadoresValorMes_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0E15( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0E15( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000E2 */
            pr_default.execute(0, new Object[] {A4IndicadoresCodigo, A32MetasIndicadoresMes, A33MetasIndicadoresAno, A31TipoMetasCodigo});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"MetasIndicadores"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z143MetasIndicadoresValorMes != T000E2_A143MetasIndicadoresValorMes[0] ) || ( Z139MetasIndicadoresTicketNro != T000E2_A139MetasIndicadoresTicketNro[0] ) || ( DateTimeUtil.ResetTime ( Z141MetasIndicadoresReg ) != DateTimeUtil.ResetTime ( T000E2_A141MetasIndicadoresReg[0] ) ) || ( StringUtil.StrCmp(Z142MetasIndicadoresHor, T000E2_A142MetasIndicadoresHor[0]) != 0 ) || ( Z144MetasIndicadoresValorAno != T000E2_A144MetasIndicadoresValorAno[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z16UsuariosCodigo, T000E2_A16UsuariosCodigo[0]) != 0 ) || ( StringUtil.StrCmp(Z34MotivosMetasCodigo, T000E2_A34MotivosMetasCodigo[0]) != 0 ) )
            {
               if ( Z143MetasIndicadoresValorMes != T000E2_A143MetasIndicadoresValorMes[0] )
               {
                  GXUtil.WriteLog("metasindicadores:[seudo value changed for attri]"+"MetasIndicadoresValorMes");
                  GXUtil.WriteLogRaw("Old: ",Z143MetasIndicadoresValorMes);
                  GXUtil.WriteLogRaw("Current: ",T000E2_A143MetasIndicadoresValorMes[0]);
               }
               if ( Z139MetasIndicadoresTicketNro != T000E2_A139MetasIndicadoresTicketNro[0] )
               {
                  GXUtil.WriteLog("metasindicadores:[seudo value changed for attri]"+"MetasIndicadoresTicketNro");
                  GXUtil.WriteLogRaw("Old: ",Z139MetasIndicadoresTicketNro);
                  GXUtil.WriteLogRaw("Current: ",T000E2_A139MetasIndicadoresTicketNro[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z141MetasIndicadoresReg ) != DateTimeUtil.ResetTime ( T000E2_A141MetasIndicadoresReg[0] ) )
               {
                  GXUtil.WriteLog("metasindicadores:[seudo value changed for attri]"+"MetasIndicadoresReg");
                  GXUtil.WriteLogRaw("Old: ",Z141MetasIndicadoresReg);
                  GXUtil.WriteLogRaw("Current: ",T000E2_A141MetasIndicadoresReg[0]);
               }
               if ( StringUtil.StrCmp(Z142MetasIndicadoresHor, T000E2_A142MetasIndicadoresHor[0]) != 0 )
               {
                  GXUtil.WriteLog("metasindicadores:[seudo value changed for attri]"+"MetasIndicadoresHor");
                  GXUtil.WriteLogRaw("Old: ",Z142MetasIndicadoresHor);
                  GXUtil.WriteLogRaw("Current: ",T000E2_A142MetasIndicadoresHor[0]);
               }
               if ( Z144MetasIndicadoresValorAno != T000E2_A144MetasIndicadoresValorAno[0] )
               {
                  GXUtil.WriteLog("metasindicadores:[seudo value changed for attri]"+"MetasIndicadoresValorAno");
                  GXUtil.WriteLogRaw("Old: ",Z144MetasIndicadoresValorAno);
                  GXUtil.WriteLogRaw("Current: ",T000E2_A144MetasIndicadoresValorAno[0]);
               }
               if ( StringUtil.StrCmp(Z16UsuariosCodigo, T000E2_A16UsuariosCodigo[0]) != 0 )
               {
                  GXUtil.WriteLog("metasindicadores:[seudo value changed for attri]"+"UsuariosCodigo");
                  GXUtil.WriteLogRaw("Old: ",Z16UsuariosCodigo);
                  GXUtil.WriteLogRaw("Current: ",T000E2_A16UsuariosCodigo[0]);
               }
               if ( StringUtil.StrCmp(Z34MotivosMetasCodigo, T000E2_A34MotivosMetasCodigo[0]) != 0 )
               {
                  GXUtil.WriteLog("metasindicadores:[seudo value changed for attri]"+"MotivosMetasCodigo");
                  GXUtil.WriteLogRaw("Old: ",Z34MotivosMetasCodigo);
                  GXUtil.WriteLogRaw("Current: ",T000E2_A34MotivosMetasCodigo[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"MetasIndicadores"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0E15( )
      {
         BeforeValidate0E15( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0E15( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0E15( 0) ;
            CheckOptimisticConcurrency0E15( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0E15( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0E15( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000E16 */
                     pr_default.execute(14, new Object[] {A32MetasIndicadoresMes, A33MetasIndicadoresAno, A143MetasIndicadoresValorMes, A139MetasIndicadoresTicketNro, A141MetasIndicadoresReg, A142MetasIndicadoresHor, A144MetasIndicadoresValorAno, A4IndicadoresCodigo, A31TipoMetasCodigo, A16UsuariosCodigo, A34MotivosMetasCodigo});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("MetasIndicadores");
                     if ( (pr_default.getStatus(14) == 1) )
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
                           ResetCaption0E0( ) ;
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
               Load0E15( ) ;
            }
            EndLevel0E15( ) ;
         }
         CloseExtendedTableCursors0E15( ) ;
      }

      protected void Update0E15( )
      {
         BeforeValidate0E15( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0E15( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0E15( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0E15( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0E15( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000E17 */
                     pr_default.execute(15, new Object[] {A143MetasIndicadoresValorMes, A139MetasIndicadoresTicketNro, A141MetasIndicadoresReg, A142MetasIndicadoresHor, A144MetasIndicadoresValorAno, A16UsuariosCodigo, A34MotivosMetasCodigo, A4IndicadoresCodigo, A32MetasIndicadoresMes, A33MetasIndicadoresAno, A31TipoMetasCodigo});
                     pr_default.close(15);
                     pr_default.SmartCacheProvider.SetUpdated("MetasIndicadores");
                     if ( (pr_default.getStatus(15) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"MetasIndicadores"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0E15( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0E0( ) ;
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
            EndLevel0E15( ) ;
         }
         CloseExtendedTableCursors0E15( ) ;
      }

      protected void DeferredUpdate0E15( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0E15( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0E15( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0E15( ) ;
            AfterConfirm0E15( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0E15( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000E18 */
                  pr_default.execute(16, new Object[] {A4IndicadoresCodigo, A32MetasIndicadoresMes, A33MetasIndicadoresAno, A31TipoMetasCodigo});
                  pr_default.close(16);
                  pr_default.SmartCacheProvider.SetUpdated("MetasIndicadores");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound15 == 0 )
                        {
                           InitAll0E15( ) ;
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
                        ResetCaption0E0( ) ;
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
         sMode15 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0E15( ) ;
         Gx_mode = sMode15;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0E15( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0E15( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0E15( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("metasindicadores",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0E0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("metasindicadores",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0E15( )
      {
         /* Using cursor T000E19 */
         pr_default.execute(17);
         RcdFound15 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound15 = 1;
            A4IndicadoresCodigo = T000E19_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A32MetasIndicadoresMes = T000E19_A32MetasIndicadoresMes[0];
            AssignAttri("", false, "A32MetasIndicadoresMes", StringUtil.LTrimStr( (decimal)(A32MetasIndicadoresMes), 4, 0));
            A33MetasIndicadoresAno = T000E19_A33MetasIndicadoresAno[0];
            AssignAttri("", false, "A33MetasIndicadoresAno", StringUtil.LTrimStr( (decimal)(A33MetasIndicadoresAno), 4, 0));
            A31TipoMetasCodigo = T000E19_A31TipoMetasCodigo[0];
            AssignAttri("", false, "A31TipoMetasCodigo", A31TipoMetasCodigo);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0E15( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound15 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound15 = 1;
            A4IndicadoresCodigo = T000E19_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A32MetasIndicadoresMes = T000E19_A32MetasIndicadoresMes[0];
            AssignAttri("", false, "A32MetasIndicadoresMes", StringUtil.LTrimStr( (decimal)(A32MetasIndicadoresMes), 4, 0));
            A33MetasIndicadoresAno = T000E19_A33MetasIndicadoresAno[0];
            AssignAttri("", false, "A33MetasIndicadoresAno", StringUtil.LTrimStr( (decimal)(A33MetasIndicadoresAno), 4, 0));
            A31TipoMetasCodigo = T000E19_A31TipoMetasCodigo[0];
            AssignAttri("", false, "A31TipoMetasCodigo", A31TipoMetasCodigo);
         }
      }

      protected void ScanEnd0E15( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm0E15( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0E15( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0E15( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0E15( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0E15( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0E15( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0E15( )
      {
         edtIndicadoresCodigo_Enabled = 0;
         AssignProp("", false, edtIndicadoresCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIndicadoresCodigo_Enabled), 5, 0), true);
         edtMetasIndicadoresMes_Enabled = 0;
         AssignProp("", false, edtMetasIndicadoresMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMetasIndicadoresMes_Enabled), 5, 0), true);
         edtMetasIndicadoresAno_Enabled = 0;
         AssignProp("", false, edtMetasIndicadoresAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMetasIndicadoresAno_Enabled), 5, 0), true);
         edtTipoMetasCodigo_Enabled = 0;
         AssignProp("", false, edtTipoMetasCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipoMetasCodigo_Enabled), 5, 0), true);
         edtMetasIndicadoresValorMes_Enabled = 0;
         AssignProp("", false, edtMetasIndicadoresValorMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMetasIndicadoresValorMes_Enabled), 5, 0), true);
         edtMetasIndicadoresTicketNro_Enabled = 0;
         AssignProp("", false, edtMetasIndicadoresTicketNro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMetasIndicadoresTicketNro_Enabled), 5, 0), true);
         edtUsuariosCodigo_Enabled = 0;
         AssignProp("", false, edtUsuariosCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuariosCodigo_Enabled), 5, 0), true);
         edtMotivosMetasCodigo_Enabled = 0;
         AssignProp("", false, edtMotivosMetasCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMotivosMetasCodigo_Enabled), 5, 0), true);
         edtMetasIndicadoresReg_Enabled = 0;
         AssignProp("", false, edtMetasIndicadoresReg_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMetasIndicadoresReg_Enabled), 5, 0), true);
         edtMetasIndicadoresHor_Enabled = 0;
         AssignProp("", false, edtMetasIndicadoresHor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMetasIndicadoresHor_Enabled), 5, 0), true);
         edtMetasIndicadoresValorAno_Enabled = 0;
         AssignProp("", false, edtMetasIndicadoresValorAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMetasIndicadoresValorAno_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0E15( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0E0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("metasindicadores.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z32MetasIndicadoresMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z32MetasIndicadoresMes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z33MetasIndicadoresAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z33MetasIndicadoresAno), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z31TipoMetasCodigo", Z31TipoMetasCodigo);
         GxWebStd.gx_hidden_field( context, "Z143MetasIndicadoresValorMes", StringUtil.LTrim( StringUtil.NToC( Z143MetasIndicadoresValorMes, 12, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z139MetasIndicadoresTicketNro", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z139MetasIndicadoresTicketNro), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z141MetasIndicadoresReg", context.localUtil.DToC( Z141MetasIndicadoresReg, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z142MetasIndicadoresHor", Z142MetasIndicadoresHor);
         GxWebStd.gx_hidden_field( context, "Z144MetasIndicadoresValorAno", StringUtil.LTrim( StringUtil.NToC( Z144MetasIndicadoresValorAno, 12, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z16UsuariosCodigo", Z16UsuariosCodigo);
         GxWebStd.gx_hidden_field( context, "Z34MotivosMetasCodigo", Z34MotivosMetasCodigo);
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
         return formatLink("metasindicadores.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "MetasIndicadores" ;
      }

      public override string GetPgmdesc( )
      {
         return "Metas Indicadores" ;
      }

      protected void InitializeNonKey0E15( )
      {
         A143MetasIndicadoresValorMes = 0;
         AssignAttri("", false, "A143MetasIndicadoresValorMes", StringUtil.LTrimStr( A143MetasIndicadoresValorMes, 12, 2));
         A139MetasIndicadoresTicketNro = 0;
         AssignAttri("", false, "A139MetasIndicadoresTicketNro", StringUtil.LTrimStr( (decimal)(A139MetasIndicadoresTicketNro), 10, 0));
         A16UsuariosCodigo = "";
         AssignAttri("", false, "A16UsuariosCodigo", A16UsuariosCodigo);
         A34MotivosMetasCodigo = "";
         AssignAttri("", false, "A34MotivosMetasCodigo", A34MotivosMetasCodigo);
         A141MetasIndicadoresReg = DateTime.MinValue;
         AssignAttri("", false, "A141MetasIndicadoresReg", context.localUtil.Format(A141MetasIndicadoresReg, "99/99/99"));
         A142MetasIndicadoresHor = "";
         AssignAttri("", false, "A142MetasIndicadoresHor", A142MetasIndicadoresHor);
         A144MetasIndicadoresValorAno = 0;
         AssignAttri("", false, "A144MetasIndicadoresValorAno", StringUtil.LTrimStr( A144MetasIndicadoresValorAno, 12, 2));
         Z143MetasIndicadoresValorMes = 0;
         Z139MetasIndicadoresTicketNro = 0;
         Z141MetasIndicadoresReg = DateTime.MinValue;
         Z142MetasIndicadoresHor = "";
         Z144MetasIndicadoresValorAno = 0;
         Z16UsuariosCodigo = "";
         Z34MotivosMetasCodigo = "";
      }

      protected void InitAll0E15( )
      {
         A4IndicadoresCodigo = "";
         AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
         A32MetasIndicadoresMes = 0;
         AssignAttri("", false, "A32MetasIndicadoresMes", StringUtil.LTrimStr( (decimal)(A32MetasIndicadoresMes), 4, 0));
         A33MetasIndicadoresAno = 0;
         AssignAttri("", false, "A33MetasIndicadoresAno", StringUtil.LTrimStr( (decimal)(A33MetasIndicadoresAno), 4, 0));
         A31TipoMetasCodigo = "";
         AssignAttri("", false, "A31TipoMetasCodigo", A31TipoMetasCodigo);
         InitializeNonKey0E15( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024723102160", true, true);
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
         context.AddJavascriptSource("metasindicadores.js", "?2024723102160", false, true);
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
         edtMetasIndicadoresMes_Internalname = "METASINDICADORESMES";
         edtMetasIndicadoresAno_Internalname = "METASINDICADORESANO";
         edtTipoMetasCodigo_Internalname = "TIPOMETASCODIGO";
         edtMetasIndicadoresValorMes_Internalname = "METASINDICADORESVALORMES";
         edtMetasIndicadoresTicketNro_Internalname = "METASINDICADORESTICKETNRO";
         edtUsuariosCodigo_Internalname = "USUARIOSCODIGO";
         edtMotivosMetasCodigo_Internalname = "MOTIVOSMETASCODIGO";
         edtMetasIndicadoresReg_Internalname = "METASINDICADORESREG";
         edtMetasIndicadoresHor_Internalname = "METASINDICADORESHOR";
         edtMetasIndicadoresValorAno_Internalname = "METASINDICADORESVALORANO";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_4_Internalname = "PROMPT_4";
         imgprompt_31_Internalname = "PROMPT_31";
         imgprompt_16_Internalname = "PROMPT_16";
         imgprompt_34_Internalname = "PROMPT_34";
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
         Form.Caption = "Metas Indicadores";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtMetasIndicadoresValorAno_Jsonclick = "";
         edtMetasIndicadoresValorAno_Enabled = 1;
         edtMetasIndicadoresHor_Jsonclick = "";
         edtMetasIndicadoresHor_Enabled = 1;
         edtMetasIndicadoresReg_Jsonclick = "";
         edtMetasIndicadoresReg_Enabled = 1;
         imgprompt_34_Visible = 1;
         imgprompt_34_Link = "";
         edtMotivosMetasCodigo_Jsonclick = "";
         edtMotivosMetasCodigo_Enabled = 1;
         imgprompt_16_Visible = 1;
         imgprompt_16_Link = "";
         edtUsuariosCodigo_Jsonclick = "";
         edtUsuariosCodigo_Enabled = 1;
         edtMetasIndicadoresTicketNro_Jsonclick = "";
         edtMetasIndicadoresTicketNro_Enabled = 1;
         edtMetasIndicadoresValorMes_Jsonclick = "";
         edtMetasIndicadoresValorMes_Enabled = 1;
         imgprompt_31_Visible = 1;
         imgprompt_31_Link = "";
         edtTipoMetasCodigo_Jsonclick = "";
         edtTipoMetasCodigo_Enabled = 1;
         edtMetasIndicadoresAno_Jsonclick = "";
         edtMetasIndicadoresAno_Enabled = 1;
         edtMetasIndicadoresMes_Jsonclick = "";
         edtMetasIndicadoresMes_Enabled = 1;
         imgprompt_4_Visible = 1;
         imgprompt_4_Link = "";
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
         /* Using cursor T000E20 */
         pr_default.execute(18, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(18);
         /* Using cursor T000E21 */
         pr_default.execute(19, new Object[] {A31TipoMetasCodigo});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo Metas'.", "ForeignKeyNotFound", 1, "TIPOMETASCODIGO");
            AnyError = 1;
            GX_FocusControl = edtTipoMetasCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(19);
         GX_FocusControl = edtMetasIndicadoresValorMes_Internalname;
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
         /* Using cursor T000E20 */
         pr_default.execute(18, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
         }
         pr_default.close(18);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Tipometascodigo( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T000E21 */
         pr_default.execute(19, new Object[] {A31TipoMetasCodigo});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo Metas'.", "ForeignKeyNotFound", 1, "TIPOMETASCODIGO");
            AnyError = 1;
            GX_FocusControl = edtTipoMetasCodigo_Internalname;
         }
         pr_default.close(19);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A143MetasIndicadoresValorMes", StringUtil.LTrim( StringUtil.NToC( A143MetasIndicadoresValorMes, 12, 2, ".", "")));
         AssignAttri("", false, "A139MetasIndicadoresTicketNro", StringUtil.LTrim( StringUtil.NToC( (decimal)(A139MetasIndicadoresTicketNro), 10, 0, ".", "")));
         AssignAttri("", false, "A16UsuariosCodigo", A16UsuariosCodigo);
         AssignAttri("", false, "A34MotivosMetasCodigo", A34MotivosMetasCodigo);
         AssignAttri("", false, "A141MetasIndicadoresReg", context.localUtil.Format(A141MetasIndicadoresReg, "99/99/99"));
         AssignAttri("", false, "A142MetasIndicadoresHor", A142MetasIndicadoresHor);
         AssignAttri("", false, "A144MetasIndicadoresValorAno", StringUtil.LTrim( StringUtil.NToC( A144MetasIndicadoresValorAno, 12, 2, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z4IndicadoresCodigo", Z4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "Z32MetasIndicadoresMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z32MetasIndicadoresMes), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z33MetasIndicadoresAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z33MetasIndicadoresAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z31TipoMetasCodigo", Z31TipoMetasCodigo);
         GxWebStd.gx_hidden_field( context, "Z143MetasIndicadoresValorMes", StringUtil.LTrim( StringUtil.NToC( Z143MetasIndicadoresValorMes, 12, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z139MetasIndicadoresTicketNro", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z139MetasIndicadoresTicketNro), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z16UsuariosCodigo", Z16UsuariosCodigo);
         GxWebStd.gx_hidden_field( context, "Z34MotivosMetasCodigo", Z34MotivosMetasCodigo);
         GxWebStd.gx_hidden_field( context, "Z141MetasIndicadoresReg", context.localUtil.Format(Z141MetasIndicadoresReg, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z142MetasIndicadoresHor", Z142MetasIndicadoresHor);
         GxWebStd.gx_hidden_field( context, "Z144MetasIndicadoresValorAno", StringUtil.LTrim( StringUtil.NToC( Z144MetasIndicadoresValorAno, 12, 2, ".", "")));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Usuarioscodigo( )
      {
         /* Using cursor T000E22 */
         pr_default.execute(20, new Object[] {A16UsuariosCodigo});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GX_msglist.addItem("No existe 'Usuarios'.", "ForeignKeyNotFound", 1, "USUARIOSCODIGO");
            AnyError = 1;
            GX_FocusControl = edtUsuariosCodigo_Internalname;
         }
         pr_default.close(20);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Motivosmetascodigo( )
      {
         /* Using cursor T000E23 */
         pr_default.execute(21, new Object[] {A34MotivosMetasCodigo});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GX_msglist.addItem("No existe 'Motivos Metas'.", "ForeignKeyNotFound", 1, "MOTIVOSMETASCODIGO");
            AnyError = 1;
            GX_FocusControl = edtMotivosMetasCodigo_Internalname;
         }
         pr_default.close(21);
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
         setEventMetadata("VALID_INDICADORESCODIGO","{handler:'Valid_Indicadorescodigo',iparms:[{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:''}]");
         setEventMetadata("VALID_INDICADORESCODIGO",",oparms:[]}");
         setEventMetadata("VALID_METASINDICADORESMES","{handler:'Valid_Metasindicadoresmes',iparms:[]");
         setEventMetadata("VALID_METASINDICADORESMES",",oparms:[]}");
         setEventMetadata("VALID_METASINDICADORESANO","{handler:'Valid_Metasindicadoresano',iparms:[]");
         setEventMetadata("VALID_METASINDICADORESANO",",oparms:[]}");
         setEventMetadata("VALID_TIPOMETASCODIGO","{handler:'Valid_Tipometascodigo',iparms:[{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:''},{av:'A32MetasIndicadoresMes',fld:'METASINDICADORESMES',pic:'ZZZ9'},{av:'A33MetasIndicadoresAno',fld:'METASINDICADORESANO',pic:'ZZZ9'},{av:'A31TipoMetasCodigo',fld:'TIPOMETASCODIGO',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_TIPOMETASCODIGO",",oparms:[{av:'A143MetasIndicadoresValorMes',fld:'METASINDICADORESVALORMES',pic:'ZZZZZZZZ9.99'},{av:'A139MetasIndicadoresTicketNro',fld:'METASINDICADORESTICKETNRO',pic:'ZZZZZZZZZ9'},{av:'A16UsuariosCodigo',fld:'USUARIOSCODIGO',pic:''},{av:'A34MotivosMetasCodigo',fld:'MOTIVOSMETASCODIGO',pic:''},{av:'A141MetasIndicadoresReg',fld:'METASINDICADORESREG',pic:''},{av:'A142MetasIndicadoresHor',fld:'METASINDICADORESHOR',pic:''},{av:'A144MetasIndicadoresValorAno',fld:'METASINDICADORESVALORANO',pic:'ZZZZZZZZ9.99'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z4IndicadoresCodigo'},{av:'Z32MetasIndicadoresMes'},{av:'Z33MetasIndicadoresAno'},{av:'Z31TipoMetasCodigo'},{av:'Z143MetasIndicadoresValorMes'},{av:'Z139MetasIndicadoresTicketNro'},{av:'Z16UsuariosCodigo'},{av:'Z34MotivosMetasCodigo'},{av:'Z141MetasIndicadoresReg'},{av:'Z142MetasIndicadoresHor'},{av:'Z144MetasIndicadoresValorAno'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_USUARIOSCODIGO","{handler:'Valid_Usuarioscodigo',iparms:[{av:'A16UsuariosCodigo',fld:'USUARIOSCODIGO',pic:''}]");
         setEventMetadata("VALID_USUARIOSCODIGO",",oparms:[]}");
         setEventMetadata("VALID_MOTIVOSMETASCODIGO","{handler:'Valid_Motivosmetascodigo',iparms:[{av:'A34MotivosMetasCodigo',fld:'MOTIVOSMETASCODIGO',pic:''}]");
         setEventMetadata("VALID_MOTIVOSMETASCODIGO",",oparms:[]}");
         setEventMetadata("VALID_METASINDICADORESREG","{handler:'Valid_Metasindicadoresreg',iparms:[]");
         setEventMetadata("VALID_METASINDICADORESREG",",oparms:[]}");
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
         pr_default.close(18);
         pr_default.close(19);
         pr_default.close(20);
         pr_default.close(21);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z4IndicadoresCodigo = "";
         Z31TipoMetasCodigo = "";
         Z141MetasIndicadoresReg = DateTime.MinValue;
         Z142MetasIndicadoresHor = "";
         Z16UsuariosCodigo = "";
         Z34MotivosMetasCodigo = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A4IndicadoresCodigo = "";
         A31TipoMetasCodigo = "";
         A16UsuariosCodigo = "";
         A34MotivosMetasCodigo = "";
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
         imgprompt_4_gximage = "";
         sImgUrl = "";
         imgprompt_31_gximage = "";
         imgprompt_16_gximage = "";
         imgprompt_34_gximage = "";
         A141MetasIndicadoresReg = DateTime.MinValue;
         A142MetasIndicadoresHor = "";
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
         T000E8_A32MetasIndicadoresMes = new short[1] ;
         T000E8_A33MetasIndicadoresAno = new short[1] ;
         T000E8_A143MetasIndicadoresValorMes = new decimal[1] ;
         T000E8_A139MetasIndicadoresTicketNro = new long[1] ;
         T000E8_A141MetasIndicadoresReg = new DateTime[] {DateTime.MinValue} ;
         T000E8_A142MetasIndicadoresHor = new string[] {""} ;
         T000E8_A144MetasIndicadoresValorAno = new decimal[1] ;
         T000E8_A4IndicadoresCodigo = new string[] {""} ;
         T000E8_A31TipoMetasCodigo = new string[] {""} ;
         T000E8_A16UsuariosCodigo = new string[] {""} ;
         T000E8_A34MotivosMetasCodigo = new string[] {""} ;
         T000E4_A4IndicadoresCodigo = new string[] {""} ;
         T000E5_A31TipoMetasCodigo = new string[] {""} ;
         T000E6_A16UsuariosCodigo = new string[] {""} ;
         T000E7_A34MotivosMetasCodigo = new string[] {""} ;
         T000E9_A4IndicadoresCodigo = new string[] {""} ;
         T000E10_A31TipoMetasCodigo = new string[] {""} ;
         T000E11_A16UsuariosCodigo = new string[] {""} ;
         T000E12_A34MotivosMetasCodigo = new string[] {""} ;
         T000E13_A4IndicadoresCodigo = new string[] {""} ;
         T000E13_A32MetasIndicadoresMes = new short[1] ;
         T000E13_A33MetasIndicadoresAno = new short[1] ;
         T000E13_A31TipoMetasCodigo = new string[] {""} ;
         T000E3_A32MetasIndicadoresMes = new short[1] ;
         T000E3_A33MetasIndicadoresAno = new short[1] ;
         T000E3_A143MetasIndicadoresValorMes = new decimal[1] ;
         T000E3_A139MetasIndicadoresTicketNro = new long[1] ;
         T000E3_A141MetasIndicadoresReg = new DateTime[] {DateTime.MinValue} ;
         T000E3_A142MetasIndicadoresHor = new string[] {""} ;
         T000E3_A144MetasIndicadoresValorAno = new decimal[1] ;
         T000E3_A4IndicadoresCodigo = new string[] {""} ;
         T000E3_A31TipoMetasCodigo = new string[] {""} ;
         T000E3_A16UsuariosCodigo = new string[] {""} ;
         T000E3_A34MotivosMetasCodigo = new string[] {""} ;
         sMode15 = "";
         T000E14_A4IndicadoresCodigo = new string[] {""} ;
         T000E14_A32MetasIndicadoresMes = new short[1] ;
         T000E14_A33MetasIndicadoresAno = new short[1] ;
         T000E14_A31TipoMetasCodigo = new string[] {""} ;
         T000E15_A4IndicadoresCodigo = new string[] {""} ;
         T000E15_A32MetasIndicadoresMes = new short[1] ;
         T000E15_A33MetasIndicadoresAno = new short[1] ;
         T000E15_A31TipoMetasCodigo = new string[] {""} ;
         T000E2_A32MetasIndicadoresMes = new short[1] ;
         T000E2_A33MetasIndicadoresAno = new short[1] ;
         T000E2_A143MetasIndicadoresValorMes = new decimal[1] ;
         T000E2_A139MetasIndicadoresTicketNro = new long[1] ;
         T000E2_A141MetasIndicadoresReg = new DateTime[] {DateTime.MinValue} ;
         T000E2_A142MetasIndicadoresHor = new string[] {""} ;
         T000E2_A144MetasIndicadoresValorAno = new decimal[1] ;
         T000E2_A4IndicadoresCodigo = new string[] {""} ;
         T000E2_A31TipoMetasCodigo = new string[] {""} ;
         T000E2_A16UsuariosCodigo = new string[] {""} ;
         T000E2_A34MotivosMetasCodigo = new string[] {""} ;
         T000E19_A4IndicadoresCodigo = new string[] {""} ;
         T000E19_A32MetasIndicadoresMes = new short[1] ;
         T000E19_A33MetasIndicadoresAno = new short[1] ;
         T000E19_A31TipoMetasCodigo = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T000E20_A4IndicadoresCodigo = new string[] {""} ;
         T000E21_A31TipoMetasCodigo = new string[] {""} ;
         ZZ4IndicadoresCodigo = "";
         ZZ31TipoMetasCodigo = "";
         ZZ16UsuariosCodigo = "";
         ZZ34MotivosMetasCodigo = "";
         ZZ141MetasIndicadoresReg = DateTime.MinValue;
         ZZ142MetasIndicadoresHor = "";
         T000E22_A16UsuariosCodigo = new string[] {""} ;
         T000E23_A34MotivosMetasCodigo = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.metasindicadores__default(),
            new Object[][] {
                new Object[] {
               T000E2_A32MetasIndicadoresMes, T000E2_A33MetasIndicadoresAno, T000E2_A143MetasIndicadoresValorMes, T000E2_A139MetasIndicadoresTicketNro, T000E2_A141MetasIndicadoresReg, T000E2_A142MetasIndicadoresHor, T000E2_A144MetasIndicadoresValorAno, T000E2_A4IndicadoresCodigo, T000E2_A31TipoMetasCodigo, T000E2_A16UsuariosCodigo,
               T000E2_A34MotivosMetasCodigo
               }
               , new Object[] {
               T000E3_A32MetasIndicadoresMes, T000E3_A33MetasIndicadoresAno, T000E3_A143MetasIndicadoresValorMes, T000E3_A139MetasIndicadoresTicketNro, T000E3_A141MetasIndicadoresReg, T000E3_A142MetasIndicadoresHor, T000E3_A144MetasIndicadoresValorAno, T000E3_A4IndicadoresCodigo, T000E3_A31TipoMetasCodigo, T000E3_A16UsuariosCodigo,
               T000E3_A34MotivosMetasCodigo
               }
               , new Object[] {
               T000E4_A4IndicadoresCodigo
               }
               , new Object[] {
               T000E5_A31TipoMetasCodigo
               }
               , new Object[] {
               T000E6_A16UsuariosCodigo
               }
               , new Object[] {
               T000E7_A34MotivosMetasCodigo
               }
               , new Object[] {
               T000E8_A32MetasIndicadoresMes, T000E8_A33MetasIndicadoresAno, T000E8_A143MetasIndicadoresValorMes, T000E8_A139MetasIndicadoresTicketNro, T000E8_A141MetasIndicadoresReg, T000E8_A142MetasIndicadoresHor, T000E8_A144MetasIndicadoresValorAno, T000E8_A4IndicadoresCodigo, T000E8_A31TipoMetasCodigo, T000E8_A16UsuariosCodigo,
               T000E8_A34MotivosMetasCodigo
               }
               , new Object[] {
               T000E9_A4IndicadoresCodigo
               }
               , new Object[] {
               T000E10_A31TipoMetasCodigo
               }
               , new Object[] {
               T000E11_A16UsuariosCodigo
               }
               , new Object[] {
               T000E12_A34MotivosMetasCodigo
               }
               , new Object[] {
               T000E13_A4IndicadoresCodigo, T000E13_A32MetasIndicadoresMes, T000E13_A33MetasIndicadoresAno, T000E13_A31TipoMetasCodigo
               }
               , new Object[] {
               T000E14_A4IndicadoresCodigo, T000E14_A32MetasIndicadoresMes, T000E14_A33MetasIndicadoresAno, T000E14_A31TipoMetasCodigo
               }
               , new Object[] {
               T000E15_A4IndicadoresCodigo, T000E15_A32MetasIndicadoresMes, T000E15_A33MetasIndicadoresAno, T000E15_A31TipoMetasCodigo
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000E19_A4IndicadoresCodigo, T000E19_A32MetasIndicadoresMes, T000E19_A33MetasIndicadoresAno, T000E19_A31TipoMetasCodigo
               }
               , new Object[] {
               T000E20_A4IndicadoresCodigo
               }
               , new Object[] {
               T000E21_A31TipoMetasCodigo
               }
               , new Object[] {
               T000E22_A16UsuariosCodigo
               }
               , new Object[] {
               T000E23_A34MotivosMetasCodigo
               }
            }
         );
      }

      private short Z32MetasIndicadoresMes ;
      private short Z33MetasIndicadoresAno ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A32MetasIndicadoresMes ;
      private short A33MetasIndicadoresAno ;
      private short GX_JID ;
      private short RcdFound15 ;
      private short nIsDirty_15 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ32MetasIndicadoresMes ;
      private short ZZ33MetasIndicadoresAno ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtIndicadoresCodigo_Enabled ;
      private int imgprompt_4_Visible ;
      private int edtMetasIndicadoresMes_Enabled ;
      private int edtMetasIndicadoresAno_Enabled ;
      private int edtTipoMetasCodigo_Enabled ;
      private int imgprompt_31_Visible ;
      private int edtMetasIndicadoresValorMes_Enabled ;
      private int edtMetasIndicadoresTicketNro_Enabled ;
      private int edtUsuariosCodigo_Enabled ;
      private int imgprompt_16_Visible ;
      private int edtMotivosMetasCodigo_Enabled ;
      private int imgprompt_34_Visible ;
      private int edtMetasIndicadoresReg_Enabled ;
      private int edtMetasIndicadoresHor_Enabled ;
      private int edtMetasIndicadoresValorAno_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z139MetasIndicadoresTicketNro ;
      private long A139MetasIndicadoresTicketNro ;
      private long ZZ139MetasIndicadoresTicketNro ;
      private decimal Z143MetasIndicadoresValorMes ;
      private decimal Z144MetasIndicadoresValorAno ;
      private decimal A143MetasIndicadoresValorMes ;
      private decimal A144MetasIndicadoresValorAno ;
      private decimal ZZ143MetasIndicadoresValorMes ;
      private decimal ZZ144MetasIndicadoresValorAno ;
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
      private string imgprompt_4_gximage ;
      private string sImgUrl ;
      private string imgprompt_4_Internalname ;
      private string imgprompt_4_Link ;
      private string edtMetasIndicadoresMes_Internalname ;
      private string edtMetasIndicadoresMes_Jsonclick ;
      private string edtMetasIndicadoresAno_Internalname ;
      private string edtMetasIndicadoresAno_Jsonclick ;
      private string edtTipoMetasCodigo_Internalname ;
      private string edtTipoMetasCodigo_Jsonclick ;
      private string imgprompt_31_gximage ;
      private string imgprompt_31_Internalname ;
      private string imgprompt_31_Link ;
      private string edtMetasIndicadoresValorMes_Internalname ;
      private string edtMetasIndicadoresValorMes_Jsonclick ;
      private string edtMetasIndicadoresTicketNro_Internalname ;
      private string edtMetasIndicadoresTicketNro_Jsonclick ;
      private string edtUsuariosCodigo_Internalname ;
      private string edtUsuariosCodigo_Jsonclick ;
      private string imgprompt_16_gximage ;
      private string imgprompt_16_Internalname ;
      private string imgprompt_16_Link ;
      private string edtMotivosMetasCodigo_Internalname ;
      private string edtMotivosMetasCodigo_Jsonclick ;
      private string imgprompt_34_gximage ;
      private string imgprompt_34_Internalname ;
      private string imgprompt_34_Link ;
      private string edtMetasIndicadoresReg_Internalname ;
      private string edtMetasIndicadoresReg_Jsonclick ;
      private string edtMetasIndicadoresHor_Internalname ;
      private string edtMetasIndicadoresHor_Jsonclick ;
      private string edtMetasIndicadoresValorAno_Internalname ;
      private string edtMetasIndicadoresValorAno_Jsonclick ;
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
      private string sMode15 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z141MetasIndicadoresReg ;
      private DateTime A141MetasIndicadoresReg ;
      private DateTime ZZ141MetasIndicadoresReg ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private string Z4IndicadoresCodigo ;
      private string Z31TipoMetasCodigo ;
      private string Z142MetasIndicadoresHor ;
      private string Z16UsuariosCodigo ;
      private string Z34MotivosMetasCodigo ;
      private string A4IndicadoresCodigo ;
      private string A31TipoMetasCodigo ;
      private string A16UsuariosCodigo ;
      private string A34MotivosMetasCodigo ;
      private string A142MetasIndicadoresHor ;
      private string ZZ4IndicadoresCodigo ;
      private string ZZ31TipoMetasCodigo ;
      private string ZZ16UsuariosCodigo ;
      private string ZZ34MotivosMetasCodigo ;
      private string ZZ142MetasIndicadoresHor ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T000E8_A32MetasIndicadoresMes ;
      private short[] T000E8_A33MetasIndicadoresAno ;
      private decimal[] T000E8_A143MetasIndicadoresValorMes ;
      private long[] T000E8_A139MetasIndicadoresTicketNro ;
      private DateTime[] T000E8_A141MetasIndicadoresReg ;
      private string[] T000E8_A142MetasIndicadoresHor ;
      private decimal[] T000E8_A144MetasIndicadoresValorAno ;
      private string[] T000E8_A4IndicadoresCodigo ;
      private string[] T000E8_A31TipoMetasCodigo ;
      private string[] T000E8_A16UsuariosCodigo ;
      private string[] T000E8_A34MotivosMetasCodigo ;
      private string[] T000E4_A4IndicadoresCodigo ;
      private string[] T000E5_A31TipoMetasCodigo ;
      private string[] T000E6_A16UsuariosCodigo ;
      private string[] T000E7_A34MotivosMetasCodigo ;
      private string[] T000E9_A4IndicadoresCodigo ;
      private string[] T000E10_A31TipoMetasCodigo ;
      private string[] T000E11_A16UsuariosCodigo ;
      private string[] T000E12_A34MotivosMetasCodigo ;
      private string[] T000E13_A4IndicadoresCodigo ;
      private short[] T000E13_A32MetasIndicadoresMes ;
      private short[] T000E13_A33MetasIndicadoresAno ;
      private string[] T000E13_A31TipoMetasCodigo ;
      private short[] T000E3_A32MetasIndicadoresMes ;
      private short[] T000E3_A33MetasIndicadoresAno ;
      private decimal[] T000E3_A143MetasIndicadoresValorMes ;
      private long[] T000E3_A139MetasIndicadoresTicketNro ;
      private DateTime[] T000E3_A141MetasIndicadoresReg ;
      private string[] T000E3_A142MetasIndicadoresHor ;
      private decimal[] T000E3_A144MetasIndicadoresValorAno ;
      private string[] T000E3_A4IndicadoresCodigo ;
      private string[] T000E3_A31TipoMetasCodigo ;
      private string[] T000E3_A16UsuariosCodigo ;
      private string[] T000E3_A34MotivosMetasCodigo ;
      private string[] T000E14_A4IndicadoresCodigo ;
      private short[] T000E14_A32MetasIndicadoresMes ;
      private short[] T000E14_A33MetasIndicadoresAno ;
      private string[] T000E14_A31TipoMetasCodigo ;
      private string[] T000E15_A4IndicadoresCodigo ;
      private short[] T000E15_A32MetasIndicadoresMes ;
      private short[] T000E15_A33MetasIndicadoresAno ;
      private string[] T000E15_A31TipoMetasCodigo ;
      private short[] T000E2_A32MetasIndicadoresMes ;
      private short[] T000E2_A33MetasIndicadoresAno ;
      private decimal[] T000E2_A143MetasIndicadoresValorMes ;
      private long[] T000E2_A139MetasIndicadoresTicketNro ;
      private DateTime[] T000E2_A141MetasIndicadoresReg ;
      private string[] T000E2_A142MetasIndicadoresHor ;
      private decimal[] T000E2_A144MetasIndicadoresValorAno ;
      private string[] T000E2_A4IndicadoresCodigo ;
      private string[] T000E2_A31TipoMetasCodigo ;
      private string[] T000E2_A16UsuariosCodigo ;
      private string[] T000E2_A34MotivosMetasCodigo ;
      private string[] T000E19_A4IndicadoresCodigo ;
      private short[] T000E19_A32MetasIndicadoresMes ;
      private short[] T000E19_A33MetasIndicadoresAno ;
      private string[] T000E19_A31TipoMetasCodigo ;
      private string[] T000E20_A4IndicadoresCodigo ;
      private string[] T000E21_A31TipoMetasCodigo ;
      private string[] T000E22_A16UsuariosCodigo ;
      private string[] T000E23_A34MotivosMetasCodigo ;
      private GXWebForm Form ;
   }

   public class metasindicadores__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new UpdateCursor(def[14])
         ,new UpdateCursor(def[15])
         ,new UpdateCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000E8;
          prmT000E8 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MetasIndicadoresMes",GXType.Int16,4,0) ,
          new ParDef("@MetasIndicadoresAno",GXType.Int16,4,0) ,
          new ParDef("@TipoMetasCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000E4;
          prmT000E4 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000E5;
          prmT000E5 = new Object[] {
          new ParDef("@TipoMetasCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000E6;
          prmT000E6 = new Object[] {
          new ParDef("@UsuariosCodigo",GXType.NVarChar,150,0)
          };
          Object[] prmT000E7;
          prmT000E7 = new Object[] {
          new ParDef("@MotivosMetasCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000E9;
          prmT000E9 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000E10;
          prmT000E10 = new Object[] {
          new ParDef("@TipoMetasCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000E11;
          prmT000E11 = new Object[] {
          new ParDef("@UsuariosCodigo",GXType.NVarChar,150,0)
          };
          Object[] prmT000E12;
          prmT000E12 = new Object[] {
          new ParDef("@MotivosMetasCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000E13;
          prmT000E13 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MetasIndicadoresMes",GXType.Int16,4,0) ,
          new ParDef("@MetasIndicadoresAno",GXType.Int16,4,0) ,
          new ParDef("@TipoMetasCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000E3;
          prmT000E3 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MetasIndicadoresMes",GXType.Int16,4,0) ,
          new ParDef("@MetasIndicadoresAno",GXType.Int16,4,0) ,
          new ParDef("@TipoMetasCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000E14;
          prmT000E14 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MetasIndicadoresMes",GXType.Int16,4,0) ,
          new ParDef("@MetasIndicadoresAno",GXType.Int16,4,0) ,
          new ParDef("@TipoMetasCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000E15;
          prmT000E15 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MetasIndicadoresMes",GXType.Int16,4,0) ,
          new ParDef("@MetasIndicadoresAno",GXType.Int16,4,0) ,
          new ParDef("@TipoMetasCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000E2;
          prmT000E2 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MetasIndicadoresMes",GXType.Int16,4,0) ,
          new ParDef("@MetasIndicadoresAno",GXType.Int16,4,0) ,
          new ParDef("@TipoMetasCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000E16;
          prmT000E16 = new Object[] {
          new ParDef("@MetasIndicadoresMes",GXType.Int16,4,0) ,
          new ParDef("@MetasIndicadoresAno",GXType.Int16,4,0) ,
          new ParDef("@MetasIndicadoresValorMes",GXType.Decimal,12,2) ,
          new ParDef("@MetasIndicadoresTicketNro",GXType.Decimal,10,0) ,
          new ParDef("@MetasIndicadoresReg",GXType.Date,8,0) ,
          new ParDef("@MetasIndicadoresHor",GXType.NVarChar,40,0) ,
          new ParDef("@MetasIndicadoresValorAno",GXType.Decimal,12,2) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@TipoMetasCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@UsuariosCodigo",GXType.NVarChar,150,0) ,
          new ParDef("@MotivosMetasCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000E17;
          prmT000E17 = new Object[] {
          new ParDef("@MetasIndicadoresValorMes",GXType.Decimal,12,2) ,
          new ParDef("@MetasIndicadoresTicketNro",GXType.Decimal,10,0) ,
          new ParDef("@MetasIndicadoresReg",GXType.Date,8,0) ,
          new ParDef("@MetasIndicadoresHor",GXType.NVarChar,40,0) ,
          new ParDef("@MetasIndicadoresValorAno",GXType.Decimal,12,2) ,
          new ParDef("@UsuariosCodigo",GXType.NVarChar,150,0) ,
          new ParDef("@MotivosMetasCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MetasIndicadoresMes",GXType.Int16,4,0) ,
          new ParDef("@MetasIndicadoresAno",GXType.Int16,4,0) ,
          new ParDef("@TipoMetasCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000E18;
          prmT000E18 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MetasIndicadoresMes",GXType.Int16,4,0) ,
          new ParDef("@MetasIndicadoresAno",GXType.Int16,4,0) ,
          new ParDef("@TipoMetasCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000E19;
          prmT000E19 = new Object[] {
          };
          Object[] prmT000E20;
          prmT000E20 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000E21;
          prmT000E21 = new Object[] {
          new ParDef("@TipoMetasCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000E22;
          prmT000E22 = new Object[] {
          new ParDef("@UsuariosCodigo",GXType.NVarChar,150,0)
          };
          Object[] prmT000E23;
          prmT000E23 = new Object[] {
          new ParDef("@MotivosMetasCodigo",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("T000E2", "SELECT [MetasIndicadoresMes], [MetasIndicadoresAno], [MetasIndicadoresValorMes], [MetasIndicadoresTicketNro], [MetasIndicadoresReg], [MetasIndicadoresHor], [MetasIndicadoresValorAno], [IndicadoresCodigo], [TipoMetasCodigo], [UsuariosCodigo], [MotivosMetasCodigo] FROM [MetasIndicadores] WITH (UPDLOCK) WHERE [IndicadoresCodigo] = @IndicadoresCodigo AND [MetasIndicadoresMes] = @MetasIndicadoresMes AND [MetasIndicadoresAno] = @MetasIndicadoresAno AND [TipoMetasCodigo] = @TipoMetasCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000E3", "SELECT [MetasIndicadoresMes], [MetasIndicadoresAno], [MetasIndicadoresValorMes], [MetasIndicadoresTicketNro], [MetasIndicadoresReg], [MetasIndicadoresHor], [MetasIndicadoresValorAno], [IndicadoresCodigo], [TipoMetasCodigo], [UsuariosCodigo], [MotivosMetasCodigo] FROM [MetasIndicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo AND [MetasIndicadoresMes] = @MetasIndicadoresMes AND [MetasIndicadoresAno] = @MetasIndicadoresAno AND [TipoMetasCodigo] = @TipoMetasCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000E4", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000E5", "SELECT [TipoMetasCodigo] FROM [TipoMetas] WHERE [TipoMetasCodigo] = @TipoMetasCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000E6", "SELECT [UsuariosCodigo] FROM [Usuarios] WHERE [UsuariosCodigo] = @UsuariosCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000E7", "SELECT [MotivosMetasCodigo] FROM [MotivosMetas] WHERE [MotivosMetasCodigo] = @MotivosMetasCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000E8", "SELECT TM1.[MetasIndicadoresMes], TM1.[MetasIndicadoresAno], TM1.[MetasIndicadoresValorMes], TM1.[MetasIndicadoresTicketNro], TM1.[MetasIndicadoresReg], TM1.[MetasIndicadoresHor], TM1.[MetasIndicadoresValorAno], TM1.[IndicadoresCodigo], TM1.[TipoMetasCodigo], TM1.[UsuariosCodigo], TM1.[MotivosMetasCodigo] FROM [MetasIndicadores] TM1 WHERE TM1.[IndicadoresCodigo] = @IndicadoresCodigo and TM1.[MetasIndicadoresMes] = @MetasIndicadoresMes and TM1.[MetasIndicadoresAno] = @MetasIndicadoresAno and TM1.[TipoMetasCodigo] = @TipoMetasCodigo ORDER BY TM1.[IndicadoresCodigo], TM1.[MetasIndicadoresMes], TM1.[MetasIndicadoresAno], TM1.[TipoMetasCodigo]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000E8,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000E9", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000E10", "SELECT [TipoMetasCodigo] FROM [TipoMetas] WHERE [TipoMetasCodigo] = @TipoMetasCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E10,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000E11", "SELECT [UsuariosCodigo] FROM [Usuarios] WHERE [UsuariosCodigo] = @UsuariosCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000E12", "SELECT [MotivosMetasCodigo] FROM [MotivosMetas] WHERE [MotivosMetasCodigo] = @MotivosMetasCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E12,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000E13", "SELECT [IndicadoresCodigo], [MetasIndicadoresMes], [MetasIndicadoresAno], [TipoMetasCodigo] FROM [MetasIndicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo AND [MetasIndicadoresMes] = @MetasIndicadoresMes AND [MetasIndicadoresAno] = @MetasIndicadoresAno AND [TipoMetasCodigo] = @TipoMetasCodigo  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000E13,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000E14", "SELECT TOP 1 [IndicadoresCodigo], [MetasIndicadoresMes], [MetasIndicadoresAno], [TipoMetasCodigo] FROM [MetasIndicadores] WHERE ( [IndicadoresCodigo] > @IndicadoresCodigo or [IndicadoresCodigo] = @IndicadoresCodigo and [MetasIndicadoresMes] > @MetasIndicadoresMes or [MetasIndicadoresMes] = @MetasIndicadoresMes and [IndicadoresCodigo] = @IndicadoresCodigo and [MetasIndicadoresAno] > @MetasIndicadoresAno or [MetasIndicadoresAno] = @MetasIndicadoresAno and [MetasIndicadoresMes] = @MetasIndicadoresMes and [IndicadoresCodigo] = @IndicadoresCodigo and [TipoMetasCodigo] > @TipoMetasCodigo) ORDER BY [IndicadoresCodigo], [MetasIndicadoresMes], [MetasIndicadoresAno], [TipoMetasCodigo]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000E14,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000E15", "SELECT TOP 1 [IndicadoresCodigo], [MetasIndicadoresMes], [MetasIndicadoresAno], [TipoMetasCodigo] FROM [MetasIndicadores] WHERE ( [IndicadoresCodigo] < @IndicadoresCodigo or [IndicadoresCodigo] = @IndicadoresCodigo and [MetasIndicadoresMes] < @MetasIndicadoresMes or [MetasIndicadoresMes] = @MetasIndicadoresMes and [IndicadoresCodigo] = @IndicadoresCodigo and [MetasIndicadoresAno] < @MetasIndicadoresAno or [MetasIndicadoresAno] = @MetasIndicadoresAno and [MetasIndicadoresMes] = @MetasIndicadoresMes and [IndicadoresCodigo] = @IndicadoresCodigo and [TipoMetasCodigo] < @TipoMetasCodigo) ORDER BY [IndicadoresCodigo] DESC, [MetasIndicadoresMes] DESC, [MetasIndicadoresAno] DESC, [TipoMetasCodigo] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000E15,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000E16", "INSERT INTO [MetasIndicadores]([MetasIndicadoresMes], [MetasIndicadoresAno], [MetasIndicadoresValorMes], [MetasIndicadoresTicketNro], [MetasIndicadoresReg], [MetasIndicadoresHor], [MetasIndicadoresValorAno], [IndicadoresCodigo], [TipoMetasCodigo], [UsuariosCodigo], [MotivosMetasCodigo]) VALUES(@MetasIndicadoresMes, @MetasIndicadoresAno, @MetasIndicadoresValorMes, @MetasIndicadoresTicketNro, @MetasIndicadoresReg, @MetasIndicadoresHor, @MetasIndicadoresValorAno, @IndicadoresCodigo, @TipoMetasCodigo, @UsuariosCodigo, @MotivosMetasCodigo)", GxErrorMask.GX_NOMASK,prmT000E16)
             ,new CursorDef("T000E17", "UPDATE [MetasIndicadores] SET [MetasIndicadoresValorMes]=@MetasIndicadoresValorMes, [MetasIndicadoresTicketNro]=@MetasIndicadoresTicketNro, [MetasIndicadoresReg]=@MetasIndicadoresReg, [MetasIndicadoresHor]=@MetasIndicadoresHor, [MetasIndicadoresValorAno]=@MetasIndicadoresValorAno, [UsuariosCodigo]=@UsuariosCodigo, [MotivosMetasCodigo]=@MotivosMetasCodigo  WHERE [IndicadoresCodigo] = @IndicadoresCodigo AND [MetasIndicadoresMes] = @MetasIndicadoresMes AND [MetasIndicadoresAno] = @MetasIndicadoresAno AND [TipoMetasCodigo] = @TipoMetasCodigo", GxErrorMask.GX_NOMASK,prmT000E17)
             ,new CursorDef("T000E18", "DELETE FROM [MetasIndicadores]  WHERE [IndicadoresCodigo] = @IndicadoresCodigo AND [MetasIndicadoresMes] = @MetasIndicadoresMes AND [MetasIndicadoresAno] = @MetasIndicadoresAno AND [TipoMetasCodigo] = @TipoMetasCodigo", GxErrorMask.GX_NOMASK,prmT000E18)
             ,new CursorDef("T000E19", "SELECT [IndicadoresCodigo], [MetasIndicadoresMes], [MetasIndicadoresAno], [TipoMetasCodigo] FROM [MetasIndicadores] ORDER BY [IndicadoresCodigo], [MetasIndicadoresMes], [MetasIndicadoresAno], [TipoMetasCodigo]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000E19,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000E20", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E20,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000E21", "SELECT [TipoMetasCodigo] FROM [TipoMetas] WHERE [TipoMetasCodigo] = @TipoMetasCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E21,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000E22", "SELECT [UsuariosCodigo] FROM [Usuarios] WHERE [UsuariosCodigo] = @UsuariosCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E22,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000E23", "SELECT [MotivosMetasCodigo] FROM [MotivosMetas] WHERE [MotivosMetasCodigo] = @MotivosMetasCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E23,1, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
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
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 11 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
             case 12 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
             case 13 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
             case 17 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
             case 18 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 19 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 20 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 21 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
       }
    }

 }

}
