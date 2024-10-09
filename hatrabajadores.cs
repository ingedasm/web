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
   public class hatrabajadores : GXDataArea
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
            Form.Meta.addItem("description", "HATRABAJADORES", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtHATRABAJADORESFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("IndicadroresPalmas", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public hatrabajadores( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("IndicadroresPalmas", true);
      }

      public hatrabajadores( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "HATRABAJADORES", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_HATRABAJADORES.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_HATRABAJADORES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_HATRABAJADORES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_HATRABAJADORES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_HATRABAJADORES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 4, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx00t0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"HATRABAJADORESFECHA"+"'), id:'"+"HATRABAJADORESFECHA"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"HATRABAJADORESMES"+"'), id:'"+"HATRABAJADORESMES"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"HATRABAJADORESANO"+"'), id:'"+"HATRABAJADORESANO"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"COD_AREA"+"'), id:'"+"COD_AREA"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"INDICADORESCODIGO"+"'), id:'"+"INDICADORESCODIGO"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_HATRABAJADORES.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtHATRABAJADORESFecha_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHATRABAJADORESFecha_Internalname, "HATRABAJADORESFecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtHATRABAJADORESFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtHATRABAJADORESFecha_Internalname, context.localUtil.Format(A57HATRABAJADORESFecha, "99/99/99"), context.localUtil.Format( A57HATRABAJADORESFecha, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHATRABAJADORESFecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtHATRABAJADORESFecha_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_HATRABAJADORES.htm");
         GxWebStd.gx_bitmap( context, edtHATRABAJADORESFecha_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtHATRABAJADORESFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_HATRABAJADORES.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtHATRABAJADORESMes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHATRABAJADORESMes_Internalname, "HATRABAJADORESMes", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHATRABAJADORESMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A58HATRABAJADORESMes), 4, 0, ",", "")), StringUtil.LTrim( ((edtHATRABAJADORESMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A58HATRABAJADORESMes), "ZZZ9") : context.localUtil.Format( (decimal)(A58HATRABAJADORESMes), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHATRABAJADORESMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtHATRABAJADORESMes_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_HATRABAJADORES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtHATRABAJADORESAno_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHATRABAJADORESAno_Internalname, "HATRABAJADORESAno", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHATRABAJADORESAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A59HATRABAJADORESAno), 4, 0, ",", "")), StringUtil.LTrim( ((edtHATRABAJADORESAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A59HATRABAJADORESAno), "ZZZ9") : context.localUtil.Format( (decimal)(A59HATRABAJADORESAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHATRABAJADORESAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtHATRABAJADORESAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_HATRABAJADORES.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCod_Area_Internalname, A5Cod_Area, StringUtil.RTrim( context.localUtil.Format( A5Cod_Area, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCod_Area_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCod_Area_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_HATRABAJADORES.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_5_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_5_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_5_Internalname, sImgUrl, imgprompt_5_Link, "", "", context.GetTheme( ), imgprompt_5_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_HATRABAJADORES.htm");
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
         GxWebStd.gx_single_line_edit( context, edtIndicadoresCodigo_Internalname, A4IndicadoresCodigo, StringUtil.RTrim( context.localUtil.Format( A4IndicadoresCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIndicadoresCodigo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIndicadoresCodigo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_HATRABAJADORES.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_4_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_4_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_4_Internalname, sImgUrl, imgprompt_4_Link, "", "", context.GetTheme( ), imgprompt_4_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_HATRABAJADORES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtHATRABAJADORESTotHas_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHATRABAJADORESTotHas_Internalname, "Has", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHATRABAJADORESTotHas_Internalname, StringUtil.LTrim( StringUtil.NToC( A174HATRABAJADORESTotHas, 12, 2, ",", "")), StringUtil.LTrim( ((edtHATRABAJADORESTotHas_Enabled!=0) ? context.localUtil.Format( A174HATRABAJADORESTotHas, "ZZZZZZZZ9.99") : context.localUtil.Format( A174HATRABAJADORESTotHas, "ZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHATRABAJADORESTotHas_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtHATRABAJADORESTotHas_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_HATRABAJADORES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtHATRABAJADORESTotTrab_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHATRABAJADORESTotTrab_Internalname, "Trab", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHATRABAJADORESTotTrab_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A175HATRABAJADORESTotTrab), 6, 0, ",", "")), StringUtil.LTrim( ((edtHATRABAJADORESTotTrab_Enabled!=0) ? context.localUtil.Format( (decimal)(A175HATRABAJADORESTotTrab), "ZZZZZ9") : context.localUtil.Format( (decimal)(A175HATRABAJADORESTotTrab), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHATRABAJADORESTotTrab_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtHATRABAJADORESTotTrab_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_HATRABAJADORES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtHATRABAJADORESuser_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHATRABAJADORESuser_Internalname, "HATRABAJADORESuser", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHATRABAJADORESuser_Internalname, A176HATRABAJADORESuser, StringUtil.RTrim( context.localUtil.Format( A176HATRABAJADORESuser, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHATRABAJADORESuser_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtHATRABAJADORESuser_Enabled, 0, "text", "", 80, "chr", 1, "row", 140, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_HATRABAJADORES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtHATRABAJADORESreg_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHATRABAJADORESreg_Internalname, "HATRABAJADORESreg", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtHATRABAJADORESreg_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtHATRABAJADORESreg_Internalname, context.localUtil.Format(A177HATRABAJADORESreg, "99/99/99"), context.localUtil.Format( A177HATRABAJADORESreg, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHATRABAJADORESreg_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtHATRABAJADORESreg_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_HATRABAJADORES.htm");
         GxWebStd.gx_bitmap( context, edtHATRABAJADORESreg_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtHATRABAJADORESreg_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_HATRABAJADORES.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtHATRABAJADOREShor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHATRABAJADOREShor_Internalname, "HATRABAJADOREShor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHATRABAJADOREShor_Internalname, A178HATRABAJADOREShor, StringUtil.RTrim( context.localUtil.Format( A178HATRABAJADOREShor, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHATRABAJADOREShor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtHATRABAJADOREShor_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_HATRABAJADORES.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_HATRABAJADORES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_HATRABAJADORES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_HATRABAJADORES.htm");
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
            Z57HATRABAJADORESFecha = context.localUtil.CToD( cgiGet( "Z57HATRABAJADORESFecha"), 0);
            Z58HATRABAJADORESMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z58HATRABAJADORESMes"), ",", "."), 18, MidpointRounding.ToEven));
            Z59HATRABAJADORESAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z59HATRABAJADORESAno"), ",", "."), 18, MidpointRounding.ToEven));
            Z5Cod_Area = cgiGet( "Z5Cod_Area");
            Z4IndicadoresCodigo = cgiGet( "Z4IndicadoresCodigo");
            Z174HATRABAJADORESTotHas = context.localUtil.CToN( cgiGet( "Z174HATRABAJADORESTotHas"), ",", ".");
            Z175HATRABAJADORESTotTrab = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z175HATRABAJADORESTotTrab"), ",", "."), 18, MidpointRounding.ToEven));
            Z176HATRABAJADORESuser = cgiGet( "Z176HATRABAJADORESuser");
            Z177HATRABAJADORESreg = context.localUtil.CToD( cgiGet( "Z177HATRABAJADORESreg"), 0);
            Z178HATRABAJADOREShor = cgiGet( "Z178HATRABAJADOREShor");
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( context.localUtil.VCDate( cgiGet( edtHATRABAJADORESFecha_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"HATRABAJADORESFecha"}), 1, "HATRABAJADORESFECHA");
               AnyError = 1;
               GX_FocusControl = edtHATRABAJADORESFecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A57HATRABAJADORESFecha = DateTime.MinValue;
               AssignAttri("", false, "A57HATRABAJADORESFecha", context.localUtil.Format(A57HATRABAJADORESFecha, "99/99/99"));
            }
            else
            {
               A57HATRABAJADORESFecha = context.localUtil.CToD( cgiGet( edtHATRABAJADORESFecha_Internalname), 2);
               AssignAttri("", false, "A57HATRABAJADORESFecha", context.localUtil.Format(A57HATRABAJADORESFecha, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtHATRABAJADORESMes_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtHATRABAJADORESMes_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "HATRABAJADORESMES");
               AnyError = 1;
               GX_FocusControl = edtHATRABAJADORESMes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A58HATRABAJADORESMes = 0;
               AssignAttri("", false, "A58HATRABAJADORESMes", StringUtil.LTrimStr( (decimal)(A58HATRABAJADORESMes), 4, 0));
            }
            else
            {
               A58HATRABAJADORESMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtHATRABAJADORESMes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A58HATRABAJADORESMes", StringUtil.LTrimStr( (decimal)(A58HATRABAJADORESMes), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtHATRABAJADORESAno_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtHATRABAJADORESAno_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "HATRABAJADORESANO");
               AnyError = 1;
               GX_FocusControl = edtHATRABAJADORESAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A59HATRABAJADORESAno = 0;
               AssignAttri("", false, "A59HATRABAJADORESAno", StringUtil.LTrimStr( (decimal)(A59HATRABAJADORESAno), 4, 0));
            }
            else
            {
               A59HATRABAJADORESAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtHATRABAJADORESAno_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A59HATRABAJADORESAno", StringUtil.LTrimStr( (decimal)(A59HATRABAJADORESAno), 4, 0));
            }
            A5Cod_Area = cgiGet( edtCod_Area_Internalname);
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = cgiGet( edtIndicadoresCodigo_Internalname);
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            if ( ( ( context.localUtil.CToN( cgiGet( edtHATRABAJADORESTotHas_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtHATRABAJADORESTotHas_Internalname), ",", ".") > 999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "HATRABAJADORESTOTHAS");
               AnyError = 1;
               GX_FocusControl = edtHATRABAJADORESTotHas_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A174HATRABAJADORESTotHas = 0;
               AssignAttri("", false, "A174HATRABAJADORESTotHas", StringUtil.LTrimStr( A174HATRABAJADORESTotHas, 12, 2));
            }
            else
            {
               A174HATRABAJADORESTotHas = context.localUtil.CToN( cgiGet( edtHATRABAJADORESTotHas_Internalname), ",", ".");
               AssignAttri("", false, "A174HATRABAJADORESTotHas", StringUtil.LTrimStr( A174HATRABAJADORESTotHas, 12, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtHATRABAJADORESTotTrab_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtHATRABAJADORESTotTrab_Internalname), ",", ".") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "HATRABAJADORESTOTTRAB");
               AnyError = 1;
               GX_FocusControl = edtHATRABAJADORESTotTrab_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A175HATRABAJADORESTotTrab = 0;
               AssignAttri("", false, "A175HATRABAJADORESTotTrab", StringUtil.LTrimStr( (decimal)(A175HATRABAJADORESTotTrab), 6, 0));
            }
            else
            {
               A175HATRABAJADORESTotTrab = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtHATRABAJADORESTotTrab_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A175HATRABAJADORESTotTrab", StringUtil.LTrimStr( (decimal)(A175HATRABAJADORESTotTrab), 6, 0));
            }
            A176HATRABAJADORESuser = cgiGet( edtHATRABAJADORESuser_Internalname);
            AssignAttri("", false, "A176HATRABAJADORESuser", A176HATRABAJADORESuser);
            if ( context.localUtil.VCDate( cgiGet( edtHATRABAJADORESreg_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"HATRABAJADORESreg"}), 1, "HATRABAJADORESREG");
               AnyError = 1;
               GX_FocusControl = edtHATRABAJADORESreg_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A177HATRABAJADORESreg = DateTime.MinValue;
               AssignAttri("", false, "A177HATRABAJADORESreg", context.localUtil.Format(A177HATRABAJADORESreg, "99/99/99"));
            }
            else
            {
               A177HATRABAJADORESreg = context.localUtil.CToD( cgiGet( edtHATRABAJADORESreg_Internalname), 2);
               AssignAttri("", false, "A177HATRABAJADORESreg", context.localUtil.Format(A177HATRABAJADORESreg, "99/99/99"));
            }
            A178HATRABAJADOREShor = cgiGet( edtHATRABAJADOREShor_Internalname);
            AssignAttri("", false, "A178HATRABAJADOREShor", A178HATRABAJADOREShor);
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
               A57HATRABAJADORESFecha = context.localUtil.ParseDateParm( GetPar( "HATRABAJADORESFecha"));
               AssignAttri("", false, "A57HATRABAJADORESFecha", context.localUtil.Format(A57HATRABAJADORESFecha, "99/99/99"));
               A58HATRABAJADORESMes = (short)(Math.Round(NumberUtil.Val( GetPar( "HATRABAJADORESMes"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A58HATRABAJADORESMes", StringUtil.LTrimStr( (decimal)(A58HATRABAJADORESMes), 4, 0));
               A59HATRABAJADORESAno = (short)(Math.Round(NumberUtil.Val( GetPar( "HATRABAJADORESAno"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A59HATRABAJADORESAno", StringUtil.LTrimStr( (decimal)(A59HATRABAJADORESAno), 4, 0));
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
               InitAll0S29( ) ;
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
         DisableAttributes0S29( ) ;
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

      protected void ResetCaption0S0( )
      {
      }

      protected void ZM0S29( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z174HATRABAJADORESTotHas = T000S3_A174HATRABAJADORESTotHas[0];
               Z175HATRABAJADORESTotTrab = T000S3_A175HATRABAJADORESTotTrab[0];
               Z176HATRABAJADORESuser = T000S3_A176HATRABAJADORESuser[0];
               Z177HATRABAJADORESreg = T000S3_A177HATRABAJADORESreg[0];
               Z178HATRABAJADOREShor = T000S3_A178HATRABAJADOREShor[0];
            }
            else
            {
               Z174HATRABAJADORESTotHas = A174HATRABAJADORESTotHas;
               Z175HATRABAJADORESTotTrab = A175HATRABAJADORESTotTrab;
               Z176HATRABAJADORESuser = A176HATRABAJADORESuser;
               Z177HATRABAJADORESreg = A177HATRABAJADORESreg;
               Z178HATRABAJADOREShor = A178HATRABAJADOREShor;
            }
         }
         if ( GX_JID == -3 )
         {
            Z57HATRABAJADORESFecha = A57HATRABAJADORESFecha;
            Z58HATRABAJADORESMes = A58HATRABAJADORESMes;
            Z59HATRABAJADORESAno = A59HATRABAJADORESAno;
            Z174HATRABAJADORESTotHas = A174HATRABAJADORESTotHas;
            Z175HATRABAJADORESTotTrab = A175HATRABAJADORESTotTrab;
            Z176HATRABAJADORESuser = A176HATRABAJADORESuser;
            Z177HATRABAJADORESreg = A177HATRABAJADORESreg;
            Z178HATRABAJADOREShor = A178HATRABAJADOREShor;
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

      protected void Load0S29( )
      {
         /* Using cursor T000S6 */
         pr_default.execute(4, new Object[] {A57HATRABAJADORESFecha, A58HATRABAJADORESMes, A59HATRABAJADORESAno, A5Cod_Area, A4IndicadoresCodigo});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound29 = 1;
            A174HATRABAJADORESTotHas = T000S6_A174HATRABAJADORESTotHas[0];
            AssignAttri("", false, "A174HATRABAJADORESTotHas", StringUtil.LTrimStr( A174HATRABAJADORESTotHas, 12, 2));
            A175HATRABAJADORESTotTrab = T000S6_A175HATRABAJADORESTotTrab[0];
            AssignAttri("", false, "A175HATRABAJADORESTotTrab", StringUtil.LTrimStr( (decimal)(A175HATRABAJADORESTotTrab), 6, 0));
            A176HATRABAJADORESuser = T000S6_A176HATRABAJADORESuser[0];
            AssignAttri("", false, "A176HATRABAJADORESuser", A176HATRABAJADORESuser);
            A177HATRABAJADORESreg = T000S6_A177HATRABAJADORESreg[0];
            AssignAttri("", false, "A177HATRABAJADORESreg", context.localUtil.Format(A177HATRABAJADORESreg, "99/99/99"));
            A178HATRABAJADOREShor = T000S6_A178HATRABAJADOREShor[0];
            AssignAttri("", false, "A178HATRABAJADOREShor", A178HATRABAJADOREShor);
            ZM0S29( -3) ;
         }
         pr_default.close(4);
         OnLoadActions0S29( ) ;
      }

      protected void OnLoadActions0S29( )
      {
      }

      protected void CheckExtendedTable0S29( )
      {
         nIsDirty_29 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A57HATRABAJADORESFecha) || ( DateTimeUtil.ResetTime ( A57HATRABAJADORESFecha ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo HATRABAJADORESFecha fuera de rango", "OutOfRange", 1, "HATRABAJADORESFECHA");
            AnyError = 1;
            GX_FocusControl = edtHATRABAJADORESFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000S4 */
         pr_default.execute(2, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T000S5 */
         pr_default.execute(3, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         if ( ! ( (DateTime.MinValue==A177HATRABAJADORESreg) || ( DateTimeUtil.ResetTime ( A177HATRABAJADORESreg ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo HATRABAJADORESreg fuera de rango", "OutOfRange", 1, "HATRABAJADORESREG");
            AnyError = 1;
            GX_FocusControl = edtHATRABAJADORESreg_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0S29( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_4( string A5Cod_Area )
      {
         /* Using cursor T000S7 */
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
         /* Using cursor T000S8 */
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

      protected void GetKey0S29( )
      {
         /* Using cursor T000S9 */
         pr_default.execute(7, new Object[] {A57HATRABAJADORESFecha, A58HATRABAJADORESMes, A59HATRABAJADORESAno, A5Cod_Area, A4IndicadoresCodigo});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound29 = 1;
         }
         else
         {
            RcdFound29 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000S3 */
         pr_default.execute(1, new Object[] {A57HATRABAJADORESFecha, A58HATRABAJADORESMes, A59HATRABAJADORESAno, A5Cod_Area, A4IndicadoresCodigo});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0S29( 3) ;
            RcdFound29 = 1;
            A57HATRABAJADORESFecha = T000S3_A57HATRABAJADORESFecha[0];
            AssignAttri("", false, "A57HATRABAJADORESFecha", context.localUtil.Format(A57HATRABAJADORESFecha, "99/99/99"));
            A58HATRABAJADORESMes = T000S3_A58HATRABAJADORESMes[0];
            AssignAttri("", false, "A58HATRABAJADORESMes", StringUtil.LTrimStr( (decimal)(A58HATRABAJADORESMes), 4, 0));
            A59HATRABAJADORESAno = T000S3_A59HATRABAJADORESAno[0];
            AssignAttri("", false, "A59HATRABAJADORESAno", StringUtil.LTrimStr( (decimal)(A59HATRABAJADORESAno), 4, 0));
            A174HATRABAJADORESTotHas = T000S3_A174HATRABAJADORESTotHas[0];
            AssignAttri("", false, "A174HATRABAJADORESTotHas", StringUtil.LTrimStr( A174HATRABAJADORESTotHas, 12, 2));
            A175HATRABAJADORESTotTrab = T000S3_A175HATRABAJADORESTotTrab[0];
            AssignAttri("", false, "A175HATRABAJADORESTotTrab", StringUtil.LTrimStr( (decimal)(A175HATRABAJADORESTotTrab), 6, 0));
            A176HATRABAJADORESuser = T000S3_A176HATRABAJADORESuser[0];
            AssignAttri("", false, "A176HATRABAJADORESuser", A176HATRABAJADORESuser);
            A177HATRABAJADORESreg = T000S3_A177HATRABAJADORESreg[0];
            AssignAttri("", false, "A177HATRABAJADORESreg", context.localUtil.Format(A177HATRABAJADORESreg, "99/99/99"));
            A178HATRABAJADOREShor = T000S3_A178HATRABAJADOREShor[0];
            AssignAttri("", false, "A178HATRABAJADOREShor", A178HATRABAJADOREShor);
            A5Cod_Area = T000S3_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = T000S3_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            Z57HATRABAJADORESFecha = A57HATRABAJADORESFecha;
            Z58HATRABAJADORESMes = A58HATRABAJADORESMes;
            Z59HATRABAJADORESAno = A59HATRABAJADORESAno;
            Z5Cod_Area = A5Cod_Area;
            Z4IndicadoresCodigo = A4IndicadoresCodigo;
            sMode29 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0S29( ) ;
            if ( AnyError == 1 )
            {
               RcdFound29 = 0;
               InitializeNonKey0S29( ) ;
            }
            Gx_mode = sMode29;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound29 = 0;
            InitializeNonKey0S29( ) ;
            sMode29 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode29;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0S29( ) ;
         if ( RcdFound29 == 0 )
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
         RcdFound29 = 0;
         /* Using cursor T000S10 */
         pr_default.execute(8, new Object[] {A57HATRABAJADORESFecha, A58HATRABAJADORESMes, A59HATRABAJADORESAno, A5Cod_Area, A4IndicadoresCodigo});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( DateTimeUtil.ResetTime ( T000S10_A57HATRABAJADORESFecha[0] ) < DateTimeUtil.ResetTime ( A57HATRABAJADORESFecha ) ) || ( DateTimeUtil.ResetTime ( T000S10_A57HATRABAJADORESFecha[0] ) == DateTimeUtil.ResetTime ( A57HATRABAJADORESFecha ) ) && ( T000S10_A58HATRABAJADORESMes[0] < A58HATRABAJADORESMes ) || ( T000S10_A58HATRABAJADORESMes[0] == A58HATRABAJADORESMes ) && ( DateTimeUtil.ResetTime ( T000S10_A57HATRABAJADORESFecha[0] ) == DateTimeUtil.ResetTime ( A57HATRABAJADORESFecha ) ) && ( T000S10_A59HATRABAJADORESAno[0] < A59HATRABAJADORESAno ) || ( T000S10_A59HATRABAJADORESAno[0] == A59HATRABAJADORESAno ) && ( T000S10_A58HATRABAJADORESMes[0] == A58HATRABAJADORESMes ) && ( DateTimeUtil.ResetTime ( T000S10_A57HATRABAJADORESFecha[0] ) == DateTimeUtil.ResetTime ( A57HATRABAJADORESFecha ) ) && ( StringUtil.StrCmp(T000S10_A5Cod_Area[0], A5Cod_Area) < 0 ) || ( StringUtil.StrCmp(T000S10_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000S10_A59HATRABAJADORESAno[0] == A59HATRABAJADORESAno ) && ( T000S10_A58HATRABAJADORESMes[0] == A58HATRABAJADORESMes ) && ( DateTimeUtil.ResetTime ( T000S10_A57HATRABAJADORESFecha[0] ) == DateTimeUtil.ResetTime ( A57HATRABAJADORESFecha ) ) && ( StringUtil.StrCmp(T000S10_A4IndicadoresCodigo[0], A4IndicadoresCodigo) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( DateTimeUtil.ResetTime ( T000S10_A57HATRABAJADORESFecha[0] ) > DateTimeUtil.ResetTime ( A57HATRABAJADORESFecha ) ) || ( DateTimeUtil.ResetTime ( T000S10_A57HATRABAJADORESFecha[0] ) == DateTimeUtil.ResetTime ( A57HATRABAJADORESFecha ) ) && ( T000S10_A58HATRABAJADORESMes[0] > A58HATRABAJADORESMes ) || ( T000S10_A58HATRABAJADORESMes[0] == A58HATRABAJADORESMes ) && ( DateTimeUtil.ResetTime ( T000S10_A57HATRABAJADORESFecha[0] ) == DateTimeUtil.ResetTime ( A57HATRABAJADORESFecha ) ) && ( T000S10_A59HATRABAJADORESAno[0] > A59HATRABAJADORESAno ) || ( T000S10_A59HATRABAJADORESAno[0] == A59HATRABAJADORESAno ) && ( T000S10_A58HATRABAJADORESMes[0] == A58HATRABAJADORESMes ) && ( DateTimeUtil.ResetTime ( T000S10_A57HATRABAJADORESFecha[0] ) == DateTimeUtil.ResetTime ( A57HATRABAJADORESFecha ) ) && ( StringUtil.StrCmp(T000S10_A5Cod_Area[0], A5Cod_Area) > 0 ) || ( StringUtil.StrCmp(T000S10_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000S10_A59HATRABAJADORESAno[0] == A59HATRABAJADORESAno ) && ( T000S10_A58HATRABAJADORESMes[0] == A58HATRABAJADORESMes ) && ( DateTimeUtil.ResetTime ( T000S10_A57HATRABAJADORESFecha[0] ) == DateTimeUtil.ResetTime ( A57HATRABAJADORESFecha ) ) && ( StringUtil.StrCmp(T000S10_A4IndicadoresCodigo[0], A4IndicadoresCodigo) > 0 ) ) )
            {
               A57HATRABAJADORESFecha = T000S10_A57HATRABAJADORESFecha[0];
               AssignAttri("", false, "A57HATRABAJADORESFecha", context.localUtil.Format(A57HATRABAJADORESFecha, "99/99/99"));
               A58HATRABAJADORESMes = T000S10_A58HATRABAJADORESMes[0];
               AssignAttri("", false, "A58HATRABAJADORESMes", StringUtil.LTrimStr( (decimal)(A58HATRABAJADORESMes), 4, 0));
               A59HATRABAJADORESAno = T000S10_A59HATRABAJADORESAno[0];
               AssignAttri("", false, "A59HATRABAJADORESAno", StringUtil.LTrimStr( (decimal)(A59HATRABAJADORESAno), 4, 0));
               A5Cod_Area = T000S10_A5Cod_Area[0];
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               A4IndicadoresCodigo = T000S10_A4IndicadoresCodigo[0];
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               RcdFound29 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound29 = 0;
         /* Using cursor T000S11 */
         pr_default.execute(9, new Object[] {A57HATRABAJADORESFecha, A58HATRABAJADORESMes, A59HATRABAJADORESAno, A5Cod_Area, A4IndicadoresCodigo});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( DateTimeUtil.ResetTime ( T000S11_A57HATRABAJADORESFecha[0] ) > DateTimeUtil.ResetTime ( A57HATRABAJADORESFecha ) ) || ( DateTimeUtil.ResetTime ( T000S11_A57HATRABAJADORESFecha[0] ) == DateTimeUtil.ResetTime ( A57HATRABAJADORESFecha ) ) && ( T000S11_A58HATRABAJADORESMes[0] > A58HATRABAJADORESMes ) || ( T000S11_A58HATRABAJADORESMes[0] == A58HATRABAJADORESMes ) && ( DateTimeUtil.ResetTime ( T000S11_A57HATRABAJADORESFecha[0] ) == DateTimeUtil.ResetTime ( A57HATRABAJADORESFecha ) ) && ( T000S11_A59HATRABAJADORESAno[0] > A59HATRABAJADORESAno ) || ( T000S11_A59HATRABAJADORESAno[0] == A59HATRABAJADORESAno ) && ( T000S11_A58HATRABAJADORESMes[0] == A58HATRABAJADORESMes ) && ( DateTimeUtil.ResetTime ( T000S11_A57HATRABAJADORESFecha[0] ) == DateTimeUtil.ResetTime ( A57HATRABAJADORESFecha ) ) && ( StringUtil.StrCmp(T000S11_A5Cod_Area[0], A5Cod_Area) > 0 ) || ( StringUtil.StrCmp(T000S11_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000S11_A59HATRABAJADORESAno[0] == A59HATRABAJADORESAno ) && ( T000S11_A58HATRABAJADORESMes[0] == A58HATRABAJADORESMes ) && ( DateTimeUtil.ResetTime ( T000S11_A57HATRABAJADORESFecha[0] ) == DateTimeUtil.ResetTime ( A57HATRABAJADORESFecha ) ) && ( StringUtil.StrCmp(T000S11_A4IndicadoresCodigo[0], A4IndicadoresCodigo) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( DateTimeUtil.ResetTime ( T000S11_A57HATRABAJADORESFecha[0] ) < DateTimeUtil.ResetTime ( A57HATRABAJADORESFecha ) ) || ( DateTimeUtil.ResetTime ( T000S11_A57HATRABAJADORESFecha[0] ) == DateTimeUtil.ResetTime ( A57HATRABAJADORESFecha ) ) && ( T000S11_A58HATRABAJADORESMes[0] < A58HATRABAJADORESMes ) || ( T000S11_A58HATRABAJADORESMes[0] == A58HATRABAJADORESMes ) && ( DateTimeUtil.ResetTime ( T000S11_A57HATRABAJADORESFecha[0] ) == DateTimeUtil.ResetTime ( A57HATRABAJADORESFecha ) ) && ( T000S11_A59HATRABAJADORESAno[0] < A59HATRABAJADORESAno ) || ( T000S11_A59HATRABAJADORESAno[0] == A59HATRABAJADORESAno ) && ( T000S11_A58HATRABAJADORESMes[0] == A58HATRABAJADORESMes ) && ( DateTimeUtil.ResetTime ( T000S11_A57HATRABAJADORESFecha[0] ) == DateTimeUtil.ResetTime ( A57HATRABAJADORESFecha ) ) && ( StringUtil.StrCmp(T000S11_A5Cod_Area[0], A5Cod_Area) < 0 ) || ( StringUtil.StrCmp(T000S11_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000S11_A59HATRABAJADORESAno[0] == A59HATRABAJADORESAno ) && ( T000S11_A58HATRABAJADORESMes[0] == A58HATRABAJADORESMes ) && ( DateTimeUtil.ResetTime ( T000S11_A57HATRABAJADORESFecha[0] ) == DateTimeUtil.ResetTime ( A57HATRABAJADORESFecha ) ) && ( StringUtil.StrCmp(T000S11_A4IndicadoresCodigo[0], A4IndicadoresCodigo) < 0 ) ) )
            {
               A57HATRABAJADORESFecha = T000S11_A57HATRABAJADORESFecha[0];
               AssignAttri("", false, "A57HATRABAJADORESFecha", context.localUtil.Format(A57HATRABAJADORESFecha, "99/99/99"));
               A58HATRABAJADORESMes = T000S11_A58HATRABAJADORESMes[0];
               AssignAttri("", false, "A58HATRABAJADORESMes", StringUtil.LTrimStr( (decimal)(A58HATRABAJADORESMes), 4, 0));
               A59HATRABAJADORESAno = T000S11_A59HATRABAJADORESAno[0];
               AssignAttri("", false, "A59HATRABAJADORESAno", StringUtil.LTrimStr( (decimal)(A59HATRABAJADORESAno), 4, 0));
               A5Cod_Area = T000S11_A5Cod_Area[0];
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               A4IndicadoresCodigo = T000S11_A4IndicadoresCodigo[0];
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               RcdFound29 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0S29( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtHATRABAJADORESFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0S29( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound29 == 1 )
            {
               if ( ( DateTimeUtil.ResetTime ( A57HATRABAJADORESFecha ) != DateTimeUtil.ResetTime ( Z57HATRABAJADORESFecha ) ) || ( A58HATRABAJADORESMes != Z58HATRABAJADORESMes ) || ( A59HATRABAJADORESAno != Z59HATRABAJADORESAno ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) )
               {
                  A57HATRABAJADORESFecha = Z57HATRABAJADORESFecha;
                  AssignAttri("", false, "A57HATRABAJADORESFecha", context.localUtil.Format(A57HATRABAJADORESFecha, "99/99/99"));
                  A58HATRABAJADORESMes = Z58HATRABAJADORESMes;
                  AssignAttri("", false, "A58HATRABAJADORESMes", StringUtil.LTrimStr( (decimal)(A58HATRABAJADORESMes), 4, 0));
                  A59HATRABAJADORESAno = Z59HATRABAJADORESAno;
                  AssignAttri("", false, "A59HATRABAJADORESAno", StringUtil.LTrimStr( (decimal)(A59HATRABAJADORESAno), 4, 0));
                  A5Cod_Area = Z5Cod_Area;
                  AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
                  A4IndicadoresCodigo = Z4IndicadoresCodigo;
                  AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "HATRABAJADORESFECHA");
                  AnyError = 1;
                  GX_FocusControl = edtHATRABAJADORESFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtHATRABAJADORESFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0S29( ) ;
                  GX_FocusControl = edtHATRABAJADORESFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( DateTimeUtil.ResetTime ( A57HATRABAJADORESFecha ) != DateTimeUtil.ResetTime ( Z57HATRABAJADORESFecha ) ) || ( A58HATRABAJADORESMes != Z58HATRABAJADORESMes ) || ( A59HATRABAJADORESAno != Z59HATRABAJADORESAno ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtHATRABAJADORESFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0S29( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "HATRABAJADORESFECHA");
                     AnyError = 1;
                     GX_FocusControl = edtHATRABAJADORESFecha_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtHATRABAJADORESFecha_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0S29( ) ;
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
         if ( ( DateTimeUtil.ResetTime ( A57HATRABAJADORESFecha ) != DateTimeUtil.ResetTime ( Z57HATRABAJADORESFecha ) ) || ( A58HATRABAJADORESMes != Z58HATRABAJADORESMes ) || ( A59HATRABAJADORESAno != Z59HATRABAJADORESAno ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) )
         {
            A57HATRABAJADORESFecha = Z57HATRABAJADORESFecha;
            AssignAttri("", false, "A57HATRABAJADORESFecha", context.localUtil.Format(A57HATRABAJADORESFecha, "99/99/99"));
            A58HATRABAJADORESMes = Z58HATRABAJADORESMes;
            AssignAttri("", false, "A58HATRABAJADORESMes", StringUtil.LTrimStr( (decimal)(A58HATRABAJADORESMes), 4, 0));
            A59HATRABAJADORESAno = Z59HATRABAJADORESAno;
            AssignAttri("", false, "A59HATRABAJADORESAno", StringUtil.LTrimStr( (decimal)(A59HATRABAJADORESAno), 4, 0));
            A5Cod_Area = Z5Cod_Area;
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = Z4IndicadoresCodigo;
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "HATRABAJADORESFECHA");
            AnyError = 1;
            GX_FocusControl = edtHATRABAJADORESFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtHATRABAJADORESFecha_Internalname;
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
         if ( RcdFound29 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "HATRABAJADORESFECHA");
            AnyError = 1;
            GX_FocusControl = edtHATRABAJADORESFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtHATRABAJADORESTotHas_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0S29( ) ;
         if ( RcdFound29 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtHATRABAJADORESTotHas_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0S29( ) ;
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
         if ( RcdFound29 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtHATRABAJADORESTotHas_Internalname;
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
         if ( RcdFound29 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtHATRABAJADORESTotHas_Internalname;
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
         ScanStart0S29( ) ;
         if ( RcdFound29 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound29 != 0 )
            {
               ScanNext0S29( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtHATRABAJADORESTotHas_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0S29( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0S29( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000S2 */
            pr_default.execute(0, new Object[] {A57HATRABAJADORESFecha, A58HATRABAJADORESMes, A59HATRABAJADORESAno, A5Cod_Area, A4IndicadoresCodigo});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"HATRABAJADORES"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z174HATRABAJADORESTotHas != T000S2_A174HATRABAJADORESTotHas[0] ) || ( Z175HATRABAJADORESTotTrab != T000S2_A175HATRABAJADORESTotTrab[0] ) || ( StringUtil.StrCmp(Z176HATRABAJADORESuser, T000S2_A176HATRABAJADORESuser[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z177HATRABAJADORESreg ) != DateTimeUtil.ResetTime ( T000S2_A177HATRABAJADORESreg[0] ) ) || ( StringUtil.StrCmp(Z178HATRABAJADOREShor, T000S2_A178HATRABAJADOREShor[0]) != 0 ) )
            {
               if ( Z174HATRABAJADORESTotHas != T000S2_A174HATRABAJADORESTotHas[0] )
               {
                  GXUtil.WriteLog("hatrabajadores:[seudo value changed for attri]"+"HATRABAJADORESTotHas");
                  GXUtil.WriteLogRaw("Old: ",Z174HATRABAJADORESTotHas);
                  GXUtil.WriteLogRaw("Current: ",T000S2_A174HATRABAJADORESTotHas[0]);
               }
               if ( Z175HATRABAJADORESTotTrab != T000S2_A175HATRABAJADORESTotTrab[0] )
               {
                  GXUtil.WriteLog("hatrabajadores:[seudo value changed for attri]"+"HATRABAJADORESTotTrab");
                  GXUtil.WriteLogRaw("Old: ",Z175HATRABAJADORESTotTrab);
                  GXUtil.WriteLogRaw("Current: ",T000S2_A175HATRABAJADORESTotTrab[0]);
               }
               if ( StringUtil.StrCmp(Z176HATRABAJADORESuser, T000S2_A176HATRABAJADORESuser[0]) != 0 )
               {
                  GXUtil.WriteLog("hatrabajadores:[seudo value changed for attri]"+"HATRABAJADORESuser");
                  GXUtil.WriteLogRaw("Old: ",Z176HATRABAJADORESuser);
                  GXUtil.WriteLogRaw("Current: ",T000S2_A176HATRABAJADORESuser[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z177HATRABAJADORESreg ) != DateTimeUtil.ResetTime ( T000S2_A177HATRABAJADORESreg[0] ) )
               {
                  GXUtil.WriteLog("hatrabajadores:[seudo value changed for attri]"+"HATRABAJADORESreg");
                  GXUtil.WriteLogRaw("Old: ",Z177HATRABAJADORESreg);
                  GXUtil.WriteLogRaw("Current: ",T000S2_A177HATRABAJADORESreg[0]);
               }
               if ( StringUtil.StrCmp(Z178HATRABAJADOREShor, T000S2_A178HATRABAJADOREShor[0]) != 0 )
               {
                  GXUtil.WriteLog("hatrabajadores:[seudo value changed for attri]"+"HATRABAJADOREShor");
                  GXUtil.WriteLogRaw("Old: ",Z178HATRABAJADOREShor);
                  GXUtil.WriteLogRaw("Current: ",T000S2_A178HATRABAJADOREShor[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"HATRABAJADORES"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0S29( )
      {
         BeforeValidate0S29( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0S29( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0S29( 0) ;
            CheckOptimisticConcurrency0S29( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0S29( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0S29( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000S12 */
                     pr_default.execute(10, new Object[] {A57HATRABAJADORESFecha, A58HATRABAJADORESMes, A59HATRABAJADORESAno, A174HATRABAJADORESTotHas, A175HATRABAJADORESTotTrab, A176HATRABAJADORESuser, A177HATRABAJADORESreg, A178HATRABAJADOREShor, A5Cod_Area, A4IndicadoresCodigo});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("HATRABAJADORES");
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
                           ResetCaption0S0( ) ;
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
               Load0S29( ) ;
            }
            EndLevel0S29( ) ;
         }
         CloseExtendedTableCursors0S29( ) ;
      }

      protected void Update0S29( )
      {
         BeforeValidate0S29( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0S29( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0S29( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0S29( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0S29( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000S13 */
                     pr_default.execute(11, new Object[] {A174HATRABAJADORESTotHas, A175HATRABAJADORESTotTrab, A176HATRABAJADORESuser, A177HATRABAJADORESreg, A178HATRABAJADOREShor, A57HATRABAJADORESFecha, A58HATRABAJADORESMes, A59HATRABAJADORESAno, A5Cod_Area, A4IndicadoresCodigo});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("HATRABAJADORES");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"HATRABAJADORES"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0S29( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0S0( ) ;
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
            EndLevel0S29( ) ;
         }
         CloseExtendedTableCursors0S29( ) ;
      }

      protected void DeferredUpdate0S29( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0S29( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0S29( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0S29( ) ;
            AfterConfirm0S29( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0S29( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000S14 */
                  pr_default.execute(12, new Object[] {A57HATRABAJADORESFecha, A58HATRABAJADORESMes, A59HATRABAJADORESAno, A5Cod_Area, A4IndicadoresCodigo});
                  pr_default.close(12);
                  pr_default.SmartCacheProvider.SetUpdated("HATRABAJADORES");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound29 == 0 )
                        {
                           InitAll0S29( ) ;
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
                        ResetCaption0S0( ) ;
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
         sMode29 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0S29( ) ;
         Gx_mode = sMode29;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0S29( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0S29( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0S29( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("hatrabajadores",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0S0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("hatrabajadores",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0S29( )
      {
         /* Using cursor T000S15 */
         pr_default.execute(13);
         RcdFound29 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound29 = 1;
            A57HATRABAJADORESFecha = T000S15_A57HATRABAJADORESFecha[0];
            AssignAttri("", false, "A57HATRABAJADORESFecha", context.localUtil.Format(A57HATRABAJADORESFecha, "99/99/99"));
            A58HATRABAJADORESMes = T000S15_A58HATRABAJADORESMes[0];
            AssignAttri("", false, "A58HATRABAJADORESMes", StringUtil.LTrimStr( (decimal)(A58HATRABAJADORESMes), 4, 0));
            A59HATRABAJADORESAno = T000S15_A59HATRABAJADORESAno[0];
            AssignAttri("", false, "A59HATRABAJADORESAno", StringUtil.LTrimStr( (decimal)(A59HATRABAJADORESAno), 4, 0));
            A5Cod_Area = T000S15_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = T000S15_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0S29( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound29 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound29 = 1;
            A57HATRABAJADORESFecha = T000S15_A57HATRABAJADORESFecha[0];
            AssignAttri("", false, "A57HATRABAJADORESFecha", context.localUtil.Format(A57HATRABAJADORESFecha, "99/99/99"));
            A58HATRABAJADORESMes = T000S15_A58HATRABAJADORESMes[0];
            AssignAttri("", false, "A58HATRABAJADORESMes", StringUtil.LTrimStr( (decimal)(A58HATRABAJADORESMes), 4, 0));
            A59HATRABAJADORESAno = T000S15_A59HATRABAJADORESAno[0];
            AssignAttri("", false, "A59HATRABAJADORESAno", StringUtil.LTrimStr( (decimal)(A59HATRABAJADORESAno), 4, 0));
            A5Cod_Area = T000S15_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = T000S15_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
         }
      }

      protected void ScanEnd0S29( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm0S29( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0S29( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0S29( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0S29( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0S29( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0S29( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0S29( )
      {
         edtHATRABAJADORESFecha_Enabled = 0;
         AssignProp("", false, edtHATRABAJADORESFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHATRABAJADORESFecha_Enabled), 5, 0), true);
         edtHATRABAJADORESMes_Enabled = 0;
         AssignProp("", false, edtHATRABAJADORESMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHATRABAJADORESMes_Enabled), 5, 0), true);
         edtHATRABAJADORESAno_Enabled = 0;
         AssignProp("", false, edtHATRABAJADORESAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHATRABAJADORESAno_Enabled), 5, 0), true);
         edtCod_Area_Enabled = 0;
         AssignProp("", false, edtCod_Area_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCod_Area_Enabled), 5, 0), true);
         edtIndicadoresCodigo_Enabled = 0;
         AssignProp("", false, edtIndicadoresCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIndicadoresCodigo_Enabled), 5, 0), true);
         edtHATRABAJADORESTotHas_Enabled = 0;
         AssignProp("", false, edtHATRABAJADORESTotHas_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHATRABAJADORESTotHas_Enabled), 5, 0), true);
         edtHATRABAJADORESTotTrab_Enabled = 0;
         AssignProp("", false, edtHATRABAJADORESTotTrab_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHATRABAJADORESTotTrab_Enabled), 5, 0), true);
         edtHATRABAJADORESuser_Enabled = 0;
         AssignProp("", false, edtHATRABAJADORESuser_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHATRABAJADORESuser_Enabled), 5, 0), true);
         edtHATRABAJADORESreg_Enabled = 0;
         AssignProp("", false, edtHATRABAJADORESreg_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHATRABAJADORESreg_Enabled), 5, 0), true);
         edtHATRABAJADOREShor_Enabled = 0;
         AssignProp("", false, edtHATRABAJADOREShor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHATRABAJADOREShor_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0S29( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0S0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("hatrabajadores.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z57HATRABAJADORESFecha", context.localUtil.DToC( Z57HATRABAJADORESFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z58HATRABAJADORESMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z58HATRABAJADORESMes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z59HATRABAJADORESAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z59HATRABAJADORESAno), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z5Cod_Area", Z5Cod_Area);
         GxWebStd.gx_hidden_field( context, "Z4IndicadoresCodigo", Z4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "Z174HATRABAJADORESTotHas", StringUtil.LTrim( StringUtil.NToC( Z174HATRABAJADORESTotHas, 12, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z175HATRABAJADORESTotTrab", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z175HATRABAJADORESTotTrab), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z176HATRABAJADORESuser", Z176HATRABAJADORESuser);
         GxWebStd.gx_hidden_field( context, "Z177HATRABAJADORESreg", context.localUtil.DToC( Z177HATRABAJADORESreg, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z178HATRABAJADOREShor", Z178HATRABAJADOREShor);
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
         return formatLink("hatrabajadores.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "HATRABAJADORES" ;
      }

      public override string GetPgmdesc( )
      {
         return "HATRABAJADORES" ;
      }

      protected void InitializeNonKey0S29( )
      {
         A174HATRABAJADORESTotHas = 0;
         AssignAttri("", false, "A174HATRABAJADORESTotHas", StringUtil.LTrimStr( A174HATRABAJADORESTotHas, 12, 2));
         A175HATRABAJADORESTotTrab = 0;
         AssignAttri("", false, "A175HATRABAJADORESTotTrab", StringUtil.LTrimStr( (decimal)(A175HATRABAJADORESTotTrab), 6, 0));
         A176HATRABAJADORESuser = "";
         AssignAttri("", false, "A176HATRABAJADORESuser", A176HATRABAJADORESuser);
         A177HATRABAJADORESreg = DateTime.MinValue;
         AssignAttri("", false, "A177HATRABAJADORESreg", context.localUtil.Format(A177HATRABAJADORESreg, "99/99/99"));
         A178HATRABAJADOREShor = "";
         AssignAttri("", false, "A178HATRABAJADOREShor", A178HATRABAJADOREShor);
         Z174HATRABAJADORESTotHas = 0;
         Z175HATRABAJADORESTotTrab = 0;
         Z176HATRABAJADORESuser = "";
         Z177HATRABAJADORESreg = DateTime.MinValue;
         Z178HATRABAJADOREShor = "";
      }

      protected void InitAll0S29( )
      {
         A57HATRABAJADORESFecha = DateTime.MinValue;
         AssignAttri("", false, "A57HATRABAJADORESFecha", context.localUtil.Format(A57HATRABAJADORESFecha, "99/99/99"));
         A58HATRABAJADORESMes = 0;
         AssignAttri("", false, "A58HATRABAJADORESMes", StringUtil.LTrimStr( (decimal)(A58HATRABAJADORESMes), 4, 0));
         A59HATRABAJADORESAno = 0;
         AssignAttri("", false, "A59HATRABAJADORESAno", StringUtil.LTrimStr( (decimal)(A59HATRABAJADORESAno), 4, 0));
         A5Cod_Area = "";
         AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
         A4IndicadoresCodigo = "";
         AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
         InitializeNonKey0S29( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20247231024238", true, true);
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
         context.AddJavascriptSource("hatrabajadores.js", "?20247231024238", false, true);
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
         edtHATRABAJADORESFecha_Internalname = "HATRABAJADORESFECHA";
         edtHATRABAJADORESMes_Internalname = "HATRABAJADORESMES";
         edtHATRABAJADORESAno_Internalname = "HATRABAJADORESANO";
         edtCod_Area_Internalname = "COD_AREA";
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO";
         edtHATRABAJADORESTotHas_Internalname = "HATRABAJADORESTOTHAS";
         edtHATRABAJADORESTotTrab_Internalname = "HATRABAJADORESTOTTRAB";
         edtHATRABAJADORESuser_Internalname = "HATRABAJADORESUSER";
         edtHATRABAJADORESreg_Internalname = "HATRABAJADORESREG";
         edtHATRABAJADOREShor_Internalname = "HATRABAJADORESHOR";
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
         Form.Caption = "HATRABAJADORES";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtHATRABAJADOREShor_Jsonclick = "";
         edtHATRABAJADOREShor_Enabled = 1;
         edtHATRABAJADORESreg_Jsonclick = "";
         edtHATRABAJADORESreg_Enabled = 1;
         edtHATRABAJADORESuser_Jsonclick = "";
         edtHATRABAJADORESuser_Enabled = 1;
         edtHATRABAJADORESTotTrab_Jsonclick = "";
         edtHATRABAJADORESTotTrab_Enabled = 1;
         edtHATRABAJADORESTotHas_Jsonclick = "";
         edtHATRABAJADORESTotHas_Enabled = 1;
         imgprompt_4_Visible = 1;
         imgprompt_4_Link = "";
         edtIndicadoresCodigo_Jsonclick = "";
         edtIndicadoresCodigo_Enabled = 1;
         imgprompt_5_Visible = 1;
         imgprompt_5_Link = "";
         edtCod_Area_Jsonclick = "";
         edtCod_Area_Enabled = 1;
         edtHATRABAJADORESAno_Jsonclick = "";
         edtHATRABAJADORESAno_Enabled = 1;
         edtHATRABAJADORESMes_Jsonclick = "";
         edtHATRABAJADORESMes_Enabled = 1;
         edtHATRABAJADORESFecha_Jsonclick = "";
         edtHATRABAJADORESFecha_Enabled = 1;
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
         /* Using cursor T000S16 */
         pr_default.execute(14, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(14);
         /* Using cursor T000S17 */
         pr_default.execute(15, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(15);
         GX_FocusControl = edtHATRABAJADORESTotHas_Internalname;
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
         /* Using cursor T000S16 */
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
         /* Using cursor T000S17 */
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
         AssignAttri("", false, "A174HATRABAJADORESTotHas", StringUtil.LTrim( StringUtil.NToC( A174HATRABAJADORESTotHas, 12, 2, ".", "")));
         AssignAttri("", false, "A175HATRABAJADORESTotTrab", StringUtil.LTrim( StringUtil.NToC( (decimal)(A175HATRABAJADORESTotTrab), 6, 0, ".", "")));
         AssignAttri("", false, "A176HATRABAJADORESuser", A176HATRABAJADORESuser);
         AssignAttri("", false, "A177HATRABAJADORESreg", context.localUtil.Format(A177HATRABAJADORESreg, "99/99/99"));
         AssignAttri("", false, "A178HATRABAJADOREShor", A178HATRABAJADOREShor);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z57HATRABAJADORESFecha", context.localUtil.Format(Z57HATRABAJADORESFecha, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z58HATRABAJADORESMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z58HATRABAJADORESMes), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z59HATRABAJADORESAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z59HATRABAJADORESAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z5Cod_Area", Z5Cod_Area);
         GxWebStd.gx_hidden_field( context, "Z4IndicadoresCodigo", Z4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "Z174HATRABAJADORESTotHas", StringUtil.LTrim( StringUtil.NToC( Z174HATRABAJADORESTotHas, 12, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z175HATRABAJADORESTotTrab", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z175HATRABAJADORESTotTrab), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z176HATRABAJADORESuser", Z176HATRABAJADORESuser);
         GxWebStd.gx_hidden_field( context, "Z177HATRABAJADORESreg", context.localUtil.Format(Z177HATRABAJADORESreg, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z178HATRABAJADOREShor", Z178HATRABAJADOREShor);
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
         setEventMetadata("VALID_HATRABAJADORESFECHA","{handler:'Valid_Hatrabajadoresfecha',iparms:[]");
         setEventMetadata("VALID_HATRABAJADORESFECHA",",oparms:[]}");
         setEventMetadata("VALID_HATRABAJADORESMES","{handler:'Valid_Hatrabajadoresmes',iparms:[]");
         setEventMetadata("VALID_HATRABAJADORESMES",",oparms:[]}");
         setEventMetadata("VALID_HATRABAJADORESANO","{handler:'Valid_Hatrabajadoresano',iparms:[]");
         setEventMetadata("VALID_HATRABAJADORESANO",",oparms:[]}");
         setEventMetadata("VALID_COD_AREA","{handler:'Valid_Cod_area',iparms:[{av:'A5Cod_Area',fld:'COD_AREA',pic:''}]");
         setEventMetadata("VALID_COD_AREA",",oparms:[]}");
         setEventMetadata("VALID_INDICADORESCODIGO","{handler:'Valid_Indicadorescodigo',iparms:[{av:'A57HATRABAJADORESFecha',fld:'HATRABAJADORESFECHA',pic:''},{av:'A58HATRABAJADORESMes',fld:'HATRABAJADORESMES',pic:'ZZZ9'},{av:'A59HATRABAJADORESAno',fld:'HATRABAJADORESANO',pic:'ZZZ9'},{av:'A5Cod_Area',fld:'COD_AREA',pic:''},{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_INDICADORESCODIGO",",oparms:[{av:'A174HATRABAJADORESTotHas',fld:'HATRABAJADORESTOTHAS',pic:'ZZZZZZZZ9.99'},{av:'A175HATRABAJADORESTotTrab',fld:'HATRABAJADORESTOTTRAB',pic:'ZZZZZ9'},{av:'A176HATRABAJADORESuser',fld:'HATRABAJADORESUSER',pic:''},{av:'A177HATRABAJADORESreg',fld:'HATRABAJADORESREG',pic:''},{av:'A178HATRABAJADOREShor',fld:'HATRABAJADORESHOR',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z57HATRABAJADORESFecha'},{av:'Z58HATRABAJADORESMes'},{av:'Z59HATRABAJADORESAno'},{av:'Z5Cod_Area'},{av:'Z4IndicadoresCodigo'},{av:'Z174HATRABAJADORESTotHas'},{av:'Z175HATRABAJADORESTotTrab'},{av:'Z176HATRABAJADORESuser'},{av:'Z177HATRABAJADORESreg'},{av:'Z178HATRABAJADOREShor'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_HATRABAJADORESREG","{handler:'Valid_Hatrabajadoresreg',iparms:[]");
         setEventMetadata("VALID_HATRABAJADORESREG",",oparms:[]}");
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
         Z57HATRABAJADORESFecha = DateTime.MinValue;
         Z5Cod_Area = "";
         Z4IndicadoresCodigo = "";
         Z176HATRABAJADORESuser = "";
         Z177HATRABAJADORESreg = DateTime.MinValue;
         Z178HATRABAJADOREShor = "";
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
         A57HATRABAJADORESFecha = DateTime.MinValue;
         imgprompt_5_gximage = "";
         sImgUrl = "";
         imgprompt_4_gximage = "";
         A176HATRABAJADORESuser = "";
         A177HATRABAJADORESreg = DateTime.MinValue;
         A178HATRABAJADOREShor = "";
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
         T000S6_A57HATRABAJADORESFecha = new DateTime[] {DateTime.MinValue} ;
         T000S6_A58HATRABAJADORESMes = new short[1] ;
         T000S6_A59HATRABAJADORESAno = new short[1] ;
         T000S6_A174HATRABAJADORESTotHas = new decimal[1] ;
         T000S6_A175HATRABAJADORESTotTrab = new int[1] ;
         T000S6_A176HATRABAJADORESuser = new string[] {""} ;
         T000S6_A177HATRABAJADORESreg = new DateTime[] {DateTime.MinValue} ;
         T000S6_A178HATRABAJADOREShor = new string[] {""} ;
         T000S6_A5Cod_Area = new string[] {""} ;
         T000S6_A4IndicadoresCodigo = new string[] {""} ;
         T000S4_A5Cod_Area = new string[] {""} ;
         T000S5_A4IndicadoresCodigo = new string[] {""} ;
         T000S7_A5Cod_Area = new string[] {""} ;
         T000S8_A4IndicadoresCodigo = new string[] {""} ;
         T000S9_A57HATRABAJADORESFecha = new DateTime[] {DateTime.MinValue} ;
         T000S9_A58HATRABAJADORESMes = new short[1] ;
         T000S9_A59HATRABAJADORESAno = new short[1] ;
         T000S9_A5Cod_Area = new string[] {""} ;
         T000S9_A4IndicadoresCodigo = new string[] {""} ;
         T000S3_A57HATRABAJADORESFecha = new DateTime[] {DateTime.MinValue} ;
         T000S3_A58HATRABAJADORESMes = new short[1] ;
         T000S3_A59HATRABAJADORESAno = new short[1] ;
         T000S3_A174HATRABAJADORESTotHas = new decimal[1] ;
         T000S3_A175HATRABAJADORESTotTrab = new int[1] ;
         T000S3_A176HATRABAJADORESuser = new string[] {""} ;
         T000S3_A177HATRABAJADORESreg = new DateTime[] {DateTime.MinValue} ;
         T000S3_A178HATRABAJADOREShor = new string[] {""} ;
         T000S3_A5Cod_Area = new string[] {""} ;
         T000S3_A4IndicadoresCodigo = new string[] {""} ;
         sMode29 = "";
         T000S10_A57HATRABAJADORESFecha = new DateTime[] {DateTime.MinValue} ;
         T000S10_A58HATRABAJADORESMes = new short[1] ;
         T000S10_A59HATRABAJADORESAno = new short[1] ;
         T000S10_A5Cod_Area = new string[] {""} ;
         T000S10_A4IndicadoresCodigo = new string[] {""} ;
         T000S11_A57HATRABAJADORESFecha = new DateTime[] {DateTime.MinValue} ;
         T000S11_A58HATRABAJADORESMes = new short[1] ;
         T000S11_A59HATRABAJADORESAno = new short[1] ;
         T000S11_A5Cod_Area = new string[] {""} ;
         T000S11_A4IndicadoresCodigo = new string[] {""} ;
         T000S2_A57HATRABAJADORESFecha = new DateTime[] {DateTime.MinValue} ;
         T000S2_A58HATRABAJADORESMes = new short[1] ;
         T000S2_A59HATRABAJADORESAno = new short[1] ;
         T000S2_A174HATRABAJADORESTotHas = new decimal[1] ;
         T000S2_A175HATRABAJADORESTotTrab = new int[1] ;
         T000S2_A176HATRABAJADORESuser = new string[] {""} ;
         T000S2_A177HATRABAJADORESreg = new DateTime[] {DateTime.MinValue} ;
         T000S2_A178HATRABAJADOREShor = new string[] {""} ;
         T000S2_A5Cod_Area = new string[] {""} ;
         T000S2_A4IndicadoresCodigo = new string[] {""} ;
         T000S15_A57HATRABAJADORESFecha = new DateTime[] {DateTime.MinValue} ;
         T000S15_A58HATRABAJADORESMes = new short[1] ;
         T000S15_A59HATRABAJADORESAno = new short[1] ;
         T000S15_A5Cod_Area = new string[] {""} ;
         T000S15_A4IndicadoresCodigo = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T000S16_A5Cod_Area = new string[] {""} ;
         T000S17_A4IndicadoresCodigo = new string[] {""} ;
         ZZ57HATRABAJADORESFecha = DateTime.MinValue;
         ZZ5Cod_Area = "";
         ZZ4IndicadoresCodigo = "";
         ZZ176HATRABAJADORESuser = "";
         ZZ177HATRABAJADORESreg = DateTime.MinValue;
         ZZ178HATRABAJADOREShor = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.hatrabajadores__default(),
            new Object[][] {
                new Object[] {
               T000S2_A57HATRABAJADORESFecha, T000S2_A58HATRABAJADORESMes, T000S2_A59HATRABAJADORESAno, T000S2_A174HATRABAJADORESTotHas, T000S2_A175HATRABAJADORESTotTrab, T000S2_A176HATRABAJADORESuser, T000S2_A177HATRABAJADORESreg, T000S2_A178HATRABAJADOREShor, T000S2_A5Cod_Area, T000S2_A4IndicadoresCodigo
               }
               , new Object[] {
               T000S3_A57HATRABAJADORESFecha, T000S3_A58HATRABAJADORESMes, T000S3_A59HATRABAJADORESAno, T000S3_A174HATRABAJADORESTotHas, T000S3_A175HATRABAJADORESTotTrab, T000S3_A176HATRABAJADORESuser, T000S3_A177HATRABAJADORESreg, T000S3_A178HATRABAJADOREShor, T000S3_A5Cod_Area, T000S3_A4IndicadoresCodigo
               }
               , new Object[] {
               T000S4_A5Cod_Area
               }
               , new Object[] {
               T000S5_A4IndicadoresCodigo
               }
               , new Object[] {
               T000S6_A57HATRABAJADORESFecha, T000S6_A58HATRABAJADORESMes, T000S6_A59HATRABAJADORESAno, T000S6_A174HATRABAJADORESTotHas, T000S6_A175HATRABAJADORESTotTrab, T000S6_A176HATRABAJADORESuser, T000S6_A177HATRABAJADORESreg, T000S6_A178HATRABAJADOREShor, T000S6_A5Cod_Area, T000S6_A4IndicadoresCodigo
               }
               , new Object[] {
               T000S7_A5Cod_Area
               }
               , new Object[] {
               T000S8_A4IndicadoresCodigo
               }
               , new Object[] {
               T000S9_A57HATRABAJADORESFecha, T000S9_A58HATRABAJADORESMes, T000S9_A59HATRABAJADORESAno, T000S9_A5Cod_Area, T000S9_A4IndicadoresCodigo
               }
               , new Object[] {
               T000S10_A57HATRABAJADORESFecha, T000S10_A58HATRABAJADORESMes, T000S10_A59HATRABAJADORESAno, T000S10_A5Cod_Area, T000S10_A4IndicadoresCodigo
               }
               , new Object[] {
               T000S11_A57HATRABAJADORESFecha, T000S11_A58HATRABAJADORESMes, T000S11_A59HATRABAJADORESAno, T000S11_A5Cod_Area, T000S11_A4IndicadoresCodigo
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000S15_A57HATRABAJADORESFecha, T000S15_A58HATRABAJADORESMes, T000S15_A59HATRABAJADORESAno, T000S15_A5Cod_Area, T000S15_A4IndicadoresCodigo
               }
               , new Object[] {
               T000S16_A5Cod_Area
               }
               , new Object[] {
               T000S17_A4IndicadoresCodigo
               }
            }
         );
      }

      private short Z58HATRABAJADORESMes ;
      private short Z59HATRABAJADORESAno ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A58HATRABAJADORESMes ;
      private short A59HATRABAJADORESAno ;
      private short GX_JID ;
      private short RcdFound29 ;
      private short nIsDirty_29 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ58HATRABAJADORESMes ;
      private short ZZ59HATRABAJADORESAno ;
      private int Z175HATRABAJADORESTotTrab ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtHATRABAJADORESFecha_Enabled ;
      private int edtHATRABAJADORESMes_Enabled ;
      private int edtHATRABAJADORESAno_Enabled ;
      private int edtCod_Area_Enabled ;
      private int imgprompt_5_Visible ;
      private int edtIndicadoresCodigo_Enabled ;
      private int imgprompt_4_Visible ;
      private int edtHATRABAJADORESTotHas_Enabled ;
      private int A175HATRABAJADORESTotTrab ;
      private int edtHATRABAJADORESTotTrab_Enabled ;
      private int edtHATRABAJADORESuser_Enabled ;
      private int edtHATRABAJADORESreg_Enabled ;
      private int edtHATRABAJADOREShor_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ175HATRABAJADORESTotTrab ;
      private decimal Z174HATRABAJADORESTotHas ;
      private decimal A174HATRABAJADORESTotHas ;
      private decimal ZZ174HATRABAJADORESTotHas ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtHATRABAJADORESFecha_Internalname ;
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
      private string edtHATRABAJADORESFecha_Jsonclick ;
      private string edtHATRABAJADORESMes_Internalname ;
      private string edtHATRABAJADORESMes_Jsonclick ;
      private string edtHATRABAJADORESAno_Internalname ;
      private string edtHATRABAJADORESAno_Jsonclick ;
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
      private string edtHATRABAJADORESTotHas_Internalname ;
      private string edtHATRABAJADORESTotHas_Jsonclick ;
      private string edtHATRABAJADORESTotTrab_Internalname ;
      private string edtHATRABAJADORESTotTrab_Jsonclick ;
      private string edtHATRABAJADORESuser_Internalname ;
      private string edtHATRABAJADORESuser_Jsonclick ;
      private string edtHATRABAJADORESreg_Internalname ;
      private string edtHATRABAJADORESreg_Jsonclick ;
      private string edtHATRABAJADOREShor_Internalname ;
      private string edtHATRABAJADOREShor_Jsonclick ;
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
      private string sMode29 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z57HATRABAJADORESFecha ;
      private DateTime Z177HATRABAJADORESreg ;
      private DateTime A57HATRABAJADORESFecha ;
      private DateTime A177HATRABAJADORESreg ;
      private DateTime ZZ57HATRABAJADORESFecha ;
      private DateTime ZZ177HATRABAJADORESreg ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string Z5Cod_Area ;
      private string Z4IndicadoresCodigo ;
      private string Z176HATRABAJADORESuser ;
      private string Z178HATRABAJADOREShor ;
      private string A5Cod_Area ;
      private string A4IndicadoresCodigo ;
      private string A176HATRABAJADORESuser ;
      private string A178HATRABAJADOREShor ;
      private string ZZ5Cod_Area ;
      private string ZZ4IndicadoresCodigo ;
      private string ZZ176HATRABAJADORESuser ;
      private string ZZ178HATRABAJADOREShor ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] T000S6_A57HATRABAJADORESFecha ;
      private short[] T000S6_A58HATRABAJADORESMes ;
      private short[] T000S6_A59HATRABAJADORESAno ;
      private decimal[] T000S6_A174HATRABAJADORESTotHas ;
      private int[] T000S6_A175HATRABAJADORESTotTrab ;
      private string[] T000S6_A176HATRABAJADORESuser ;
      private DateTime[] T000S6_A177HATRABAJADORESreg ;
      private string[] T000S6_A178HATRABAJADOREShor ;
      private string[] T000S6_A5Cod_Area ;
      private string[] T000S6_A4IndicadoresCodigo ;
      private string[] T000S4_A5Cod_Area ;
      private string[] T000S5_A4IndicadoresCodigo ;
      private string[] T000S7_A5Cod_Area ;
      private string[] T000S8_A4IndicadoresCodigo ;
      private DateTime[] T000S9_A57HATRABAJADORESFecha ;
      private short[] T000S9_A58HATRABAJADORESMes ;
      private short[] T000S9_A59HATRABAJADORESAno ;
      private string[] T000S9_A5Cod_Area ;
      private string[] T000S9_A4IndicadoresCodigo ;
      private DateTime[] T000S3_A57HATRABAJADORESFecha ;
      private short[] T000S3_A58HATRABAJADORESMes ;
      private short[] T000S3_A59HATRABAJADORESAno ;
      private decimal[] T000S3_A174HATRABAJADORESTotHas ;
      private int[] T000S3_A175HATRABAJADORESTotTrab ;
      private string[] T000S3_A176HATRABAJADORESuser ;
      private DateTime[] T000S3_A177HATRABAJADORESreg ;
      private string[] T000S3_A178HATRABAJADOREShor ;
      private string[] T000S3_A5Cod_Area ;
      private string[] T000S3_A4IndicadoresCodigo ;
      private DateTime[] T000S10_A57HATRABAJADORESFecha ;
      private short[] T000S10_A58HATRABAJADORESMes ;
      private short[] T000S10_A59HATRABAJADORESAno ;
      private string[] T000S10_A5Cod_Area ;
      private string[] T000S10_A4IndicadoresCodigo ;
      private DateTime[] T000S11_A57HATRABAJADORESFecha ;
      private short[] T000S11_A58HATRABAJADORESMes ;
      private short[] T000S11_A59HATRABAJADORESAno ;
      private string[] T000S11_A5Cod_Area ;
      private string[] T000S11_A4IndicadoresCodigo ;
      private DateTime[] T000S2_A57HATRABAJADORESFecha ;
      private short[] T000S2_A58HATRABAJADORESMes ;
      private short[] T000S2_A59HATRABAJADORESAno ;
      private decimal[] T000S2_A174HATRABAJADORESTotHas ;
      private int[] T000S2_A175HATRABAJADORESTotTrab ;
      private string[] T000S2_A176HATRABAJADORESuser ;
      private DateTime[] T000S2_A177HATRABAJADORESreg ;
      private string[] T000S2_A178HATRABAJADOREShor ;
      private string[] T000S2_A5Cod_Area ;
      private string[] T000S2_A4IndicadoresCodigo ;
      private DateTime[] T000S15_A57HATRABAJADORESFecha ;
      private short[] T000S15_A58HATRABAJADORESMes ;
      private short[] T000S15_A59HATRABAJADORESAno ;
      private string[] T000S15_A5Cod_Area ;
      private string[] T000S15_A4IndicadoresCodigo ;
      private string[] T000S16_A5Cod_Area ;
      private string[] T000S17_A4IndicadoresCodigo ;
      private GXWebForm Form ;
   }

   public class hatrabajadores__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT000S6;
          prmT000S6 = new Object[] {
          new ParDef("@HATRABAJADORESFecha",GXType.Date,8,0) ,
          new ParDef("@HATRABAJADORESMes",GXType.Int16,4,0) ,
          new ParDef("@HATRABAJADORESAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000S4;
          prmT000S4 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000S5;
          prmT000S5 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000S7;
          prmT000S7 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000S8;
          prmT000S8 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000S9;
          prmT000S9 = new Object[] {
          new ParDef("@HATRABAJADORESFecha",GXType.Date,8,0) ,
          new ParDef("@HATRABAJADORESMes",GXType.Int16,4,0) ,
          new ParDef("@HATRABAJADORESAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000S3;
          prmT000S3 = new Object[] {
          new ParDef("@HATRABAJADORESFecha",GXType.Date,8,0) ,
          new ParDef("@HATRABAJADORESMes",GXType.Int16,4,0) ,
          new ParDef("@HATRABAJADORESAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000S10;
          prmT000S10 = new Object[] {
          new ParDef("@HATRABAJADORESFecha",GXType.Date,8,0) ,
          new ParDef("@HATRABAJADORESMes",GXType.Int16,4,0) ,
          new ParDef("@HATRABAJADORESAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000S11;
          prmT000S11 = new Object[] {
          new ParDef("@HATRABAJADORESFecha",GXType.Date,8,0) ,
          new ParDef("@HATRABAJADORESMes",GXType.Int16,4,0) ,
          new ParDef("@HATRABAJADORESAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000S2;
          prmT000S2 = new Object[] {
          new ParDef("@HATRABAJADORESFecha",GXType.Date,8,0) ,
          new ParDef("@HATRABAJADORESMes",GXType.Int16,4,0) ,
          new ParDef("@HATRABAJADORESAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000S12;
          prmT000S12 = new Object[] {
          new ParDef("@HATRABAJADORESFecha",GXType.Date,8,0) ,
          new ParDef("@HATRABAJADORESMes",GXType.Int16,4,0) ,
          new ParDef("@HATRABAJADORESAno",GXType.Int16,4,0) ,
          new ParDef("@HATRABAJADORESTotHas",GXType.Decimal,12,2) ,
          new ParDef("@HATRABAJADORESTotTrab",GXType.Int32,6,0) ,
          new ParDef("@HATRABAJADORESuser",GXType.NVarChar,140,0) ,
          new ParDef("@HATRABAJADORESreg",GXType.Date,8,0) ,
          new ParDef("@HATRABAJADOREShor",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000S13;
          prmT000S13 = new Object[] {
          new ParDef("@HATRABAJADORESTotHas",GXType.Decimal,12,2) ,
          new ParDef("@HATRABAJADORESTotTrab",GXType.Int32,6,0) ,
          new ParDef("@HATRABAJADORESuser",GXType.NVarChar,140,0) ,
          new ParDef("@HATRABAJADORESreg",GXType.Date,8,0) ,
          new ParDef("@HATRABAJADOREShor",GXType.NVarChar,40,0) ,
          new ParDef("@HATRABAJADORESFecha",GXType.Date,8,0) ,
          new ParDef("@HATRABAJADORESMes",GXType.Int16,4,0) ,
          new ParDef("@HATRABAJADORESAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000S14;
          prmT000S14 = new Object[] {
          new ParDef("@HATRABAJADORESFecha",GXType.Date,8,0) ,
          new ParDef("@HATRABAJADORESMes",GXType.Int16,4,0) ,
          new ParDef("@HATRABAJADORESAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000S15;
          prmT000S15 = new Object[] {
          };
          Object[] prmT000S16;
          prmT000S16 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000S17;
          prmT000S17 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("T000S2", "SELECT [HATRABAJADORESFecha], [HATRABAJADORESMes], [HATRABAJADORESAno], [HATRABAJADORESTotHas], [HATRABAJADORESTotTrab], [HATRABAJADORESuser], [HATRABAJADORESreg], [HATRABAJADOREShor], [Cod_Area], [IndicadoresCodigo] FROM [HATRABAJADORES] WITH (UPDLOCK) WHERE [HATRABAJADORESFecha] = @HATRABAJADORESFecha AND [HATRABAJADORESMes] = @HATRABAJADORESMes AND [HATRABAJADORESAno] = @HATRABAJADORESAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000S3", "SELECT [HATRABAJADORESFecha], [HATRABAJADORESMes], [HATRABAJADORESAno], [HATRABAJADORESTotHas], [HATRABAJADORESTotTrab], [HATRABAJADORESuser], [HATRABAJADORESreg], [HATRABAJADOREShor], [Cod_Area], [IndicadoresCodigo] FROM [HATRABAJADORES] WHERE [HATRABAJADORESFecha] = @HATRABAJADORESFecha AND [HATRABAJADORESMes] = @HATRABAJADORESMes AND [HATRABAJADORESAno] = @HATRABAJADORESAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000S4", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000S5", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000S6", "SELECT TM1.[HATRABAJADORESFecha], TM1.[HATRABAJADORESMes], TM1.[HATRABAJADORESAno], TM1.[HATRABAJADORESTotHas], TM1.[HATRABAJADORESTotTrab], TM1.[HATRABAJADORESuser], TM1.[HATRABAJADORESreg], TM1.[HATRABAJADOREShor], TM1.[Cod_Area], TM1.[IndicadoresCodigo] FROM [HATRABAJADORES] TM1 WHERE TM1.[HATRABAJADORESFecha] = @HATRABAJADORESFecha and TM1.[HATRABAJADORESMes] = @HATRABAJADORESMes and TM1.[HATRABAJADORESAno] = @HATRABAJADORESAno and TM1.[Cod_Area] = @Cod_Area and TM1.[IndicadoresCodigo] = @IndicadoresCodigo ORDER BY TM1.[HATRABAJADORESFecha], TM1.[HATRABAJADORESMes], TM1.[HATRABAJADORESAno], TM1.[Cod_Area], TM1.[IndicadoresCodigo]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000S6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000S7", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000S8", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000S9", "SELECT [HATRABAJADORESFecha], [HATRABAJADORESMes], [HATRABAJADORESAno], [Cod_Area], [IndicadoresCodigo] FROM [HATRABAJADORES] WHERE [HATRABAJADORESFecha] = @HATRABAJADORESFecha AND [HATRABAJADORESMes] = @HATRABAJADORESMes AND [HATRABAJADORESAno] = @HATRABAJADORESAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000S9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000S10", "SELECT TOP 1 [HATRABAJADORESFecha], [HATRABAJADORESMes], [HATRABAJADORESAno], [Cod_Area], [IndicadoresCodigo] FROM [HATRABAJADORES] WHERE ( [HATRABAJADORESFecha] > @HATRABAJADORESFecha or [HATRABAJADORESFecha] = @HATRABAJADORESFecha and [HATRABAJADORESMes] > @HATRABAJADORESMes or [HATRABAJADORESMes] = @HATRABAJADORESMes and [HATRABAJADORESFecha] = @HATRABAJADORESFecha and [HATRABAJADORESAno] > @HATRABAJADORESAno or [HATRABAJADORESAno] = @HATRABAJADORESAno and [HATRABAJADORESMes] = @HATRABAJADORESMes and [HATRABAJADORESFecha] = @HATRABAJADORESFecha and [Cod_Area] > @Cod_Area or [Cod_Area] = @Cod_Area and [HATRABAJADORESAno] = @HATRABAJADORESAno and [HATRABAJADORESMes] = @HATRABAJADORESMes and [HATRABAJADORESFecha] = @HATRABAJADORESFecha and [IndicadoresCodigo] > @IndicadoresCodigo) ORDER BY [HATRABAJADORESFecha], [HATRABAJADORESMes], [HATRABAJADORESAno], [Cod_Area], [IndicadoresCodigo]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000S10,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000S11", "SELECT TOP 1 [HATRABAJADORESFecha], [HATRABAJADORESMes], [HATRABAJADORESAno], [Cod_Area], [IndicadoresCodigo] FROM [HATRABAJADORES] WHERE ( [HATRABAJADORESFecha] < @HATRABAJADORESFecha or [HATRABAJADORESFecha] = @HATRABAJADORESFecha and [HATRABAJADORESMes] < @HATRABAJADORESMes or [HATRABAJADORESMes] = @HATRABAJADORESMes and [HATRABAJADORESFecha] = @HATRABAJADORESFecha and [HATRABAJADORESAno] < @HATRABAJADORESAno or [HATRABAJADORESAno] = @HATRABAJADORESAno and [HATRABAJADORESMes] = @HATRABAJADORESMes and [HATRABAJADORESFecha] = @HATRABAJADORESFecha and [Cod_Area] < @Cod_Area or [Cod_Area] = @Cod_Area and [HATRABAJADORESAno] = @HATRABAJADORESAno and [HATRABAJADORESMes] = @HATRABAJADORESMes and [HATRABAJADORESFecha] = @HATRABAJADORESFecha and [IndicadoresCodigo] < @IndicadoresCodigo) ORDER BY [HATRABAJADORESFecha] DESC, [HATRABAJADORESMes] DESC, [HATRABAJADORESAno] DESC, [Cod_Area] DESC, [IndicadoresCodigo] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000S11,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000S12", "INSERT INTO [HATRABAJADORES]([HATRABAJADORESFecha], [HATRABAJADORESMes], [HATRABAJADORESAno], [HATRABAJADORESTotHas], [HATRABAJADORESTotTrab], [HATRABAJADORESuser], [HATRABAJADORESreg], [HATRABAJADOREShor], [Cod_Area], [IndicadoresCodigo]) VALUES(@HATRABAJADORESFecha, @HATRABAJADORESMes, @HATRABAJADORESAno, @HATRABAJADORESTotHas, @HATRABAJADORESTotTrab, @HATRABAJADORESuser, @HATRABAJADORESreg, @HATRABAJADOREShor, @Cod_Area, @IndicadoresCodigo)", GxErrorMask.GX_NOMASK,prmT000S12)
             ,new CursorDef("T000S13", "UPDATE [HATRABAJADORES] SET [HATRABAJADORESTotHas]=@HATRABAJADORESTotHas, [HATRABAJADORESTotTrab]=@HATRABAJADORESTotTrab, [HATRABAJADORESuser]=@HATRABAJADORESuser, [HATRABAJADORESreg]=@HATRABAJADORESreg, [HATRABAJADOREShor]=@HATRABAJADOREShor  WHERE [HATRABAJADORESFecha] = @HATRABAJADORESFecha AND [HATRABAJADORESMes] = @HATRABAJADORESMes AND [HATRABAJADORESAno] = @HATRABAJADORESAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo", GxErrorMask.GX_NOMASK,prmT000S13)
             ,new CursorDef("T000S14", "DELETE FROM [HATRABAJADORES]  WHERE [HATRABAJADORESFecha] = @HATRABAJADORESFecha AND [HATRABAJADORESMes] = @HATRABAJADORESMes AND [HATRABAJADORESAno] = @HATRABAJADORESAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo", GxErrorMask.GX_NOMASK,prmT000S14)
             ,new CursorDef("T000S15", "SELECT [HATRABAJADORESFecha], [HATRABAJADORESMes], [HATRABAJADORESAno], [Cod_Area], [IndicadoresCodigo] FROM [HATRABAJADORES] ORDER BY [HATRABAJADORESFecha], [HATRABAJADORESMes], [HATRABAJADORESAno], [Cod_Area], [IndicadoresCodigo]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000S15,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000S16", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S16,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000S17", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S17,1, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                return;
             case 1 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
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
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
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
