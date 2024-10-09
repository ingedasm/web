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
   public class tea : GXDataArea
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
            Form.Meta.addItem("description", "TEA", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTEAFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("IndicadroresPalmas", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public tea( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("IndicadroresPalmas", true);
      }

      public tea( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "TEA", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_TEA.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TEA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_TEA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_TEA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TEA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 4, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx00k0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"TEAFECHA"+"'), id:'"+"TEAFECHA"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"TEAMES"+"'), id:'"+"TEAMES"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"TEAANO"+"'), id:'"+"TEAANO"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"INDICADORESCODIGO"+"'), id:'"+"INDICADORESCODIGO"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"COD_AREA"+"'), id:'"+"COD_AREA"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_TEA.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTEAFecha_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTEAFecha_Internalname, "TEAFecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTEAFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTEAFecha_Internalname, context.localUtil.Format(A42TEAFecha, "99/99/99"), context.localUtil.Format( A42TEAFecha, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTEAFecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTEAFecha_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_TEA.htm");
         GxWebStd.gx_bitmap( context, edtTEAFecha_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTEAFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TEA.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTEAMes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTEAMes_Internalname, "TEAMes", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTEAMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A43TEAMes), 4, 0, ",", "")), StringUtil.LTrim( ((edtTEAMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A43TEAMes), "ZZZ9") : context.localUtil.Format( (decimal)(A43TEAMes), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTEAMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTEAMes_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_TEA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTEAAno_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTEAAno_Internalname, "TEAAno", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTEAAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A44TEAAno), 4, 0, ",", "")), StringUtil.LTrim( ((edtTEAAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A44TEAAno), "ZZZ9") : context.localUtil.Format( (decimal)(A44TEAAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTEAAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTEAAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_TEA.htm");
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
         GxWebStd.gx_single_line_edit( context, edtIndicadoresCodigo_Internalname, A4IndicadoresCodigo, StringUtil.RTrim( context.localUtil.Format( A4IndicadoresCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIndicadoresCodigo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIndicadoresCodigo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_TEA.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_4_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_4_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_4_Internalname, sImgUrl, imgprompt_4_Link, "", "", context.GetTheme( ), imgprompt_4_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_TEA.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCod_Area_Internalname, A5Cod_Area, StringUtil.RTrim( context.localUtil.Format( A5Cod_Area, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCod_Area_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCod_Area_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_TEA.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_5_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_5_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_5_Internalname, sImgUrl, imgprompt_5_Link, "", "", context.GetTheme( ), imgprompt_5_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_TEA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTEAValor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTEAValor_Internalname, "TEAValor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTEAValor_Internalname, StringUtil.LTrim( StringUtil.NToC( A158TEAValor, 15, 3, ",", "")), StringUtil.LTrim( ((edtTEAValor_Enabled!=0) ? context.localUtil.Format( A158TEAValor, "ZZZZZZZZZZ9.999") : context.localUtil.Format( A158TEAValor, "ZZZZZZZZZZ9.999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','3');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','3');"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTEAValor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTEAValor_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_TEA.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_TEA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_TEA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_TEA.htm");
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
            Z42TEAFecha = context.localUtil.CToD( cgiGet( "Z42TEAFecha"), 0);
            Z43TEAMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z43TEAMes"), ",", "."), 18, MidpointRounding.ToEven));
            Z44TEAAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z44TEAAno"), ",", "."), 18, MidpointRounding.ToEven));
            Z4IndicadoresCodigo = cgiGet( "Z4IndicadoresCodigo");
            Z5Cod_Area = cgiGet( "Z5Cod_Area");
            Z158TEAValor = context.localUtil.CToN( cgiGet( "Z158TEAValor"), ",", ".");
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( context.localUtil.VCDate( cgiGet( edtTEAFecha_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"TEAFecha"}), 1, "TEAFECHA");
               AnyError = 1;
               GX_FocusControl = edtTEAFecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A42TEAFecha = DateTime.MinValue;
               AssignAttri("", false, "A42TEAFecha", context.localUtil.Format(A42TEAFecha, "99/99/99"));
            }
            else
            {
               A42TEAFecha = context.localUtil.CToD( cgiGet( edtTEAFecha_Internalname), 2);
               AssignAttri("", false, "A42TEAFecha", context.localUtil.Format(A42TEAFecha, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtTEAMes_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTEAMes_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TEAMES");
               AnyError = 1;
               GX_FocusControl = edtTEAMes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A43TEAMes = 0;
               AssignAttri("", false, "A43TEAMes", StringUtil.LTrimStr( (decimal)(A43TEAMes), 4, 0));
            }
            else
            {
               A43TEAMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtTEAMes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A43TEAMes", StringUtil.LTrimStr( (decimal)(A43TEAMes), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtTEAAno_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTEAAno_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TEAANO");
               AnyError = 1;
               GX_FocusControl = edtTEAAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A44TEAAno = 0;
               AssignAttri("", false, "A44TEAAno", StringUtil.LTrimStr( (decimal)(A44TEAAno), 4, 0));
            }
            else
            {
               A44TEAAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtTEAAno_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A44TEAAno", StringUtil.LTrimStr( (decimal)(A44TEAAno), 4, 0));
            }
            A4IndicadoresCodigo = cgiGet( edtIndicadoresCodigo_Internalname);
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A5Cod_Area = cgiGet( edtCod_Area_Internalname);
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            if ( ( ( context.localUtil.CToN( cgiGet( edtTEAValor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTEAValor_Internalname), ",", ".") > 99999999999.999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TEAVALOR");
               AnyError = 1;
               GX_FocusControl = edtTEAValor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A158TEAValor = 0;
               AssignAttri("", false, "A158TEAValor", StringUtil.LTrimStr( A158TEAValor, 15, 3));
            }
            else
            {
               A158TEAValor = context.localUtil.CToN( cgiGet( edtTEAValor_Internalname), ",", ".");
               AssignAttri("", false, "A158TEAValor", StringUtil.LTrimStr( A158TEAValor, 15, 3));
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
               A42TEAFecha = context.localUtil.ParseDateParm( GetPar( "TEAFecha"));
               AssignAttri("", false, "A42TEAFecha", context.localUtil.Format(A42TEAFecha, "99/99/99"));
               A43TEAMes = (short)(Math.Round(NumberUtil.Val( GetPar( "TEAMes"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A43TEAMes", StringUtil.LTrimStr( (decimal)(A43TEAMes), 4, 0));
               A44TEAAno = (short)(Math.Round(NumberUtil.Val( GetPar( "TEAAno"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A44TEAAno", StringUtil.LTrimStr( (decimal)(A44TEAAno), 4, 0));
               A4IndicadoresCodigo = GetPar( "IndicadoresCodigo");
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
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
               InitAll0J20( ) ;
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
         DisableAttributes0J20( ) ;
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

      protected void ResetCaption0J0( )
      {
      }

      protected void ZM0J20( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z158TEAValor = T000J3_A158TEAValor[0];
            }
            else
            {
               Z158TEAValor = A158TEAValor;
            }
         }
         if ( GX_JID == -2 )
         {
            Z42TEAFecha = A42TEAFecha;
            Z43TEAMes = A43TEAMes;
            Z44TEAAno = A44TEAAno;
            Z158TEAValor = A158TEAValor;
            Z4IndicadoresCodigo = A4IndicadoresCodigo;
            Z5Cod_Area = A5Cod_Area;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_4_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0030.aspx"+"',["+"{Ctrl:gx.dom.el('"+"INDICADORESCODIGO"+"'), id:'"+"INDICADORESCODIGO"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"true"+");");
         imgprompt_5_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"COD_AREA"+"'), id:'"+"COD_AREA"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");");
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

      protected void Load0J20( )
      {
         /* Using cursor T000J6 */
         pr_default.execute(4, new Object[] {A42TEAFecha, A43TEAMes, A44TEAAno, A4IndicadoresCodigo, A5Cod_Area});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound20 = 1;
            A158TEAValor = T000J6_A158TEAValor[0];
            AssignAttri("", false, "A158TEAValor", StringUtil.LTrimStr( A158TEAValor, 15, 3));
            ZM0J20( -2) ;
         }
         pr_default.close(4);
         OnLoadActions0J20( ) ;
      }

      protected void OnLoadActions0J20( )
      {
      }

      protected void CheckExtendedTable0J20( )
      {
         nIsDirty_20 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A42TEAFecha) || ( DateTimeUtil.ResetTime ( A42TEAFecha ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo TEAFecha fuera de rango", "OutOfRange", 1, "TEAFECHA");
            AnyError = 1;
            GX_FocusControl = edtTEAFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000J4 */
         pr_default.execute(2, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T000J5 */
         pr_default.execute(3, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0J20( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( string A4IndicadoresCodigo )
      {
         /* Using cursor T000J7 */
         pr_default.execute(5, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
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

      protected void gxLoad_4( string A5Cod_Area )
      {
         /* Using cursor T000J8 */
         pr_default.execute(6, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
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

      protected void GetKey0J20( )
      {
         /* Using cursor T000J9 */
         pr_default.execute(7, new Object[] {A42TEAFecha, A43TEAMes, A44TEAAno, A4IndicadoresCodigo, A5Cod_Area});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound20 = 1;
         }
         else
         {
            RcdFound20 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000J3 */
         pr_default.execute(1, new Object[] {A42TEAFecha, A43TEAMes, A44TEAAno, A4IndicadoresCodigo, A5Cod_Area});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0J20( 2) ;
            RcdFound20 = 1;
            A42TEAFecha = T000J3_A42TEAFecha[0];
            AssignAttri("", false, "A42TEAFecha", context.localUtil.Format(A42TEAFecha, "99/99/99"));
            A43TEAMes = T000J3_A43TEAMes[0];
            AssignAttri("", false, "A43TEAMes", StringUtil.LTrimStr( (decimal)(A43TEAMes), 4, 0));
            A44TEAAno = T000J3_A44TEAAno[0];
            AssignAttri("", false, "A44TEAAno", StringUtil.LTrimStr( (decimal)(A44TEAAno), 4, 0));
            A158TEAValor = T000J3_A158TEAValor[0];
            AssignAttri("", false, "A158TEAValor", StringUtil.LTrimStr( A158TEAValor, 15, 3));
            A4IndicadoresCodigo = T000J3_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A5Cod_Area = T000J3_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            Z42TEAFecha = A42TEAFecha;
            Z43TEAMes = A43TEAMes;
            Z44TEAAno = A44TEAAno;
            Z4IndicadoresCodigo = A4IndicadoresCodigo;
            Z5Cod_Area = A5Cod_Area;
            sMode20 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0J20( ) ;
            if ( AnyError == 1 )
            {
               RcdFound20 = 0;
               InitializeNonKey0J20( ) ;
            }
            Gx_mode = sMode20;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound20 = 0;
            InitializeNonKey0J20( ) ;
            sMode20 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode20;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0J20( ) ;
         if ( RcdFound20 == 0 )
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
         RcdFound20 = 0;
         /* Using cursor T000J10 */
         pr_default.execute(8, new Object[] {A42TEAFecha, A43TEAMes, A44TEAAno, A4IndicadoresCodigo, A5Cod_Area});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( DateTimeUtil.ResetTime ( T000J10_A42TEAFecha[0] ) < DateTimeUtil.ResetTime ( A42TEAFecha ) ) || ( DateTimeUtil.ResetTime ( T000J10_A42TEAFecha[0] ) == DateTimeUtil.ResetTime ( A42TEAFecha ) ) && ( T000J10_A43TEAMes[0] < A43TEAMes ) || ( T000J10_A43TEAMes[0] == A43TEAMes ) && ( DateTimeUtil.ResetTime ( T000J10_A42TEAFecha[0] ) == DateTimeUtil.ResetTime ( A42TEAFecha ) ) && ( T000J10_A44TEAAno[0] < A44TEAAno ) || ( T000J10_A44TEAAno[0] == A44TEAAno ) && ( T000J10_A43TEAMes[0] == A43TEAMes ) && ( DateTimeUtil.ResetTime ( T000J10_A42TEAFecha[0] ) == DateTimeUtil.ResetTime ( A42TEAFecha ) ) && ( StringUtil.StrCmp(T000J10_A4IndicadoresCodigo[0], A4IndicadoresCodigo) < 0 ) || ( StringUtil.StrCmp(T000J10_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000J10_A44TEAAno[0] == A44TEAAno ) && ( T000J10_A43TEAMes[0] == A43TEAMes ) && ( DateTimeUtil.ResetTime ( T000J10_A42TEAFecha[0] ) == DateTimeUtil.ResetTime ( A42TEAFecha ) ) && ( StringUtil.StrCmp(T000J10_A5Cod_Area[0], A5Cod_Area) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( DateTimeUtil.ResetTime ( T000J10_A42TEAFecha[0] ) > DateTimeUtil.ResetTime ( A42TEAFecha ) ) || ( DateTimeUtil.ResetTime ( T000J10_A42TEAFecha[0] ) == DateTimeUtil.ResetTime ( A42TEAFecha ) ) && ( T000J10_A43TEAMes[0] > A43TEAMes ) || ( T000J10_A43TEAMes[0] == A43TEAMes ) && ( DateTimeUtil.ResetTime ( T000J10_A42TEAFecha[0] ) == DateTimeUtil.ResetTime ( A42TEAFecha ) ) && ( T000J10_A44TEAAno[0] > A44TEAAno ) || ( T000J10_A44TEAAno[0] == A44TEAAno ) && ( T000J10_A43TEAMes[0] == A43TEAMes ) && ( DateTimeUtil.ResetTime ( T000J10_A42TEAFecha[0] ) == DateTimeUtil.ResetTime ( A42TEAFecha ) ) && ( StringUtil.StrCmp(T000J10_A4IndicadoresCodigo[0], A4IndicadoresCodigo) > 0 ) || ( StringUtil.StrCmp(T000J10_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000J10_A44TEAAno[0] == A44TEAAno ) && ( T000J10_A43TEAMes[0] == A43TEAMes ) && ( DateTimeUtil.ResetTime ( T000J10_A42TEAFecha[0] ) == DateTimeUtil.ResetTime ( A42TEAFecha ) ) && ( StringUtil.StrCmp(T000J10_A5Cod_Area[0], A5Cod_Area) > 0 ) ) )
            {
               A42TEAFecha = T000J10_A42TEAFecha[0];
               AssignAttri("", false, "A42TEAFecha", context.localUtil.Format(A42TEAFecha, "99/99/99"));
               A43TEAMes = T000J10_A43TEAMes[0];
               AssignAttri("", false, "A43TEAMes", StringUtil.LTrimStr( (decimal)(A43TEAMes), 4, 0));
               A44TEAAno = T000J10_A44TEAAno[0];
               AssignAttri("", false, "A44TEAAno", StringUtil.LTrimStr( (decimal)(A44TEAAno), 4, 0));
               A4IndicadoresCodigo = T000J10_A4IndicadoresCodigo[0];
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               A5Cod_Area = T000J10_A5Cod_Area[0];
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               RcdFound20 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound20 = 0;
         /* Using cursor T000J11 */
         pr_default.execute(9, new Object[] {A42TEAFecha, A43TEAMes, A44TEAAno, A4IndicadoresCodigo, A5Cod_Area});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( DateTimeUtil.ResetTime ( T000J11_A42TEAFecha[0] ) > DateTimeUtil.ResetTime ( A42TEAFecha ) ) || ( DateTimeUtil.ResetTime ( T000J11_A42TEAFecha[0] ) == DateTimeUtil.ResetTime ( A42TEAFecha ) ) && ( T000J11_A43TEAMes[0] > A43TEAMes ) || ( T000J11_A43TEAMes[0] == A43TEAMes ) && ( DateTimeUtil.ResetTime ( T000J11_A42TEAFecha[0] ) == DateTimeUtil.ResetTime ( A42TEAFecha ) ) && ( T000J11_A44TEAAno[0] > A44TEAAno ) || ( T000J11_A44TEAAno[0] == A44TEAAno ) && ( T000J11_A43TEAMes[0] == A43TEAMes ) && ( DateTimeUtil.ResetTime ( T000J11_A42TEAFecha[0] ) == DateTimeUtil.ResetTime ( A42TEAFecha ) ) && ( StringUtil.StrCmp(T000J11_A4IndicadoresCodigo[0], A4IndicadoresCodigo) > 0 ) || ( StringUtil.StrCmp(T000J11_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000J11_A44TEAAno[0] == A44TEAAno ) && ( T000J11_A43TEAMes[0] == A43TEAMes ) && ( DateTimeUtil.ResetTime ( T000J11_A42TEAFecha[0] ) == DateTimeUtil.ResetTime ( A42TEAFecha ) ) && ( StringUtil.StrCmp(T000J11_A5Cod_Area[0], A5Cod_Area) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( DateTimeUtil.ResetTime ( T000J11_A42TEAFecha[0] ) < DateTimeUtil.ResetTime ( A42TEAFecha ) ) || ( DateTimeUtil.ResetTime ( T000J11_A42TEAFecha[0] ) == DateTimeUtil.ResetTime ( A42TEAFecha ) ) && ( T000J11_A43TEAMes[0] < A43TEAMes ) || ( T000J11_A43TEAMes[0] == A43TEAMes ) && ( DateTimeUtil.ResetTime ( T000J11_A42TEAFecha[0] ) == DateTimeUtil.ResetTime ( A42TEAFecha ) ) && ( T000J11_A44TEAAno[0] < A44TEAAno ) || ( T000J11_A44TEAAno[0] == A44TEAAno ) && ( T000J11_A43TEAMes[0] == A43TEAMes ) && ( DateTimeUtil.ResetTime ( T000J11_A42TEAFecha[0] ) == DateTimeUtil.ResetTime ( A42TEAFecha ) ) && ( StringUtil.StrCmp(T000J11_A4IndicadoresCodigo[0], A4IndicadoresCodigo) < 0 ) || ( StringUtil.StrCmp(T000J11_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000J11_A44TEAAno[0] == A44TEAAno ) && ( T000J11_A43TEAMes[0] == A43TEAMes ) && ( DateTimeUtil.ResetTime ( T000J11_A42TEAFecha[0] ) == DateTimeUtil.ResetTime ( A42TEAFecha ) ) && ( StringUtil.StrCmp(T000J11_A5Cod_Area[0], A5Cod_Area) < 0 ) ) )
            {
               A42TEAFecha = T000J11_A42TEAFecha[0];
               AssignAttri("", false, "A42TEAFecha", context.localUtil.Format(A42TEAFecha, "99/99/99"));
               A43TEAMes = T000J11_A43TEAMes[0];
               AssignAttri("", false, "A43TEAMes", StringUtil.LTrimStr( (decimal)(A43TEAMes), 4, 0));
               A44TEAAno = T000J11_A44TEAAno[0];
               AssignAttri("", false, "A44TEAAno", StringUtil.LTrimStr( (decimal)(A44TEAAno), 4, 0));
               A4IndicadoresCodigo = T000J11_A4IndicadoresCodigo[0];
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               A5Cod_Area = T000J11_A5Cod_Area[0];
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               RcdFound20 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0J20( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTEAFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0J20( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound20 == 1 )
            {
               if ( ( DateTimeUtil.ResetTime ( A42TEAFecha ) != DateTimeUtil.ResetTime ( Z42TEAFecha ) ) || ( A43TEAMes != Z43TEAMes ) || ( A44TEAAno != Z44TEAAno ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) )
               {
                  A42TEAFecha = Z42TEAFecha;
                  AssignAttri("", false, "A42TEAFecha", context.localUtil.Format(A42TEAFecha, "99/99/99"));
                  A43TEAMes = Z43TEAMes;
                  AssignAttri("", false, "A43TEAMes", StringUtil.LTrimStr( (decimal)(A43TEAMes), 4, 0));
                  A44TEAAno = Z44TEAAno;
                  AssignAttri("", false, "A44TEAAno", StringUtil.LTrimStr( (decimal)(A44TEAAno), 4, 0));
                  A4IndicadoresCodigo = Z4IndicadoresCodigo;
                  AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
                  A5Cod_Area = Z5Cod_Area;
                  AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TEAFECHA");
                  AnyError = 1;
                  GX_FocusControl = edtTEAFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTEAFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0J20( ) ;
                  GX_FocusControl = edtTEAFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( DateTimeUtil.ResetTime ( A42TEAFecha ) != DateTimeUtil.ResetTime ( Z42TEAFecha ) ) || ( A43TEAMes != Z43TEAMes ) || ( A44TEAAno != Z44TEAAno ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtTEAFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0J20( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TEAFECHA");
                     AnyError = 1;
                     GX_FocusControl = edtTEAFecha_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtTEAFecha_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0J20( ) ;
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
         if ( ( DateTimeUtil.ResetTime ( A42TEAFecha ) != DateTimeUtil.ResetTime ( Z42TEAFecha ) ) || ( A43TEAMes != Z43TEAMes ) || ( A44TEAAno != Z44TEAAno ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) )
         {
            A42TEAFecha = Z42TEAFecha;
            AssignAttri("", false, "A42TEAFecha", context.localUtil.Format(A42TEAFecha, "99/99/99"));
            A43TEAMes = Z43TEAMes;
            AssignAttri("", false, "A43TEAMes", StringUtil.LTrimStr( (decimal)(A43TEAMes), 4, 0));
            A44TEAAno = Z44TEAAno;
            AssignAttri("", false, "A44TEAAno", StringUtil.LTrimStr( (decimal)(A44TEAAno), 4, 0));
            A4IndicadoresCodigo = Z4IndicadoresCodigo;
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A5Cod_Area = Z5Cod_Area;
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TEAFECHA");
            AnyError = 1;
            GX_FocusControl = edtTEAFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTEAFecha_Internalname;
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
         if ( RcdFound20 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "TEAFECHA");
            AnyError = 1;
            GX_FocusControl = edtTEAFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtTEAValor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0J20( ) ;
         if ( RcdFound20 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTEAValor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0J20( ) ;
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
         if ( RcdFound20 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTEAValor_Internalname;
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
         if ( RcdFound20 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTEAValor_Internalname;
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
         ScanStart0J20( ) ;
         if ( RcdFound20 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound20 != 0 )
            {
               ScanNext0J20( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTEAValor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0J20( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0J20( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000J2 */
            pr_default.execute(0, new Object[] {A42TEAFecha, A43TEAMes, A44TEAAno, A4IndicadoresCodigo, A5Cod_Area});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TEA"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z158TEAValor != T000J2_A158TEAValor[0] ) )
            {
               if ( Z158TEAValor != T000J2_A158TEAValor[0] )
               {
                  GXUtil.WriteLog("tea:[seudo value changed for attri]"+"TEAValor");
                  GXUtil.WriteLogRaw("Old: ",Z158TEAValor);
                  GXUtil.WriteLogRaw("Current: ",T000J2_A158TEAValor[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TEA"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0J20( )
      {
         BeforeValidate0J20( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0J20( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0J20( 0) ;
            CheckOptimisticConcurrency0J20( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0J20( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0J20( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000J12 */
                     pr_default.execute(10, new Object[] {A42TEAFecha, A43TEAMes, A44TEAAno, A158TEAValor, A4IndicadoresCodigo, A5Cod_Area});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("TEA");
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
                           ResetCaption0J0( ) ;
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
               Load0J20( ) ;
            }
            EndLevel0J20( ) ;
         }
         CloseExtendedTableCursors0J20( ) ;
      }

      protected void Update0J20( )
      {
         BeforeValidate0J20( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0J20( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0J20( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0J20( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0J20( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000J13 */
                     pr_default.execute(11, new Object[] {A158TEAValor, A42TEAFecha, A43TEAMes, A44TEAAno, A4IndicadoresCodigo, A5Cod_Area});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("TEA");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TEA"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0J20( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0J0( ) ;
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
            EndLevel0J20( ) ;
         }
         CloseExtendedTableCursors0J20( ) ;
      }

      protected void DeferredUpdate0J20( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0J20( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0J20( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0J20( ) ;
            AfterConfirm0J20( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0J20( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000J14 */
                  pr_default.execute(12, new Object[] {A42TEAFecha, A43TEAMes, A44TEAAno, A4IndicadoresCodigo, A5Cod_Area});
                  pr_default.close(12);
                  pr_default.SmartCacheProvider.SetUpdated("TEA");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound20 == 0 )
                        {
                           InitAll0J20( ) ;
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
                        ResetCaption0J0( ) ;
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
         sMode20 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0J20( ) ;
         Gx_mode = sMode20;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0J20( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0J20( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0J20( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("tea",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0J0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("tea",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0J20( )
      {
         /* Using cursor T000J15 */
         pr_default.execute(13);
         RcdFound20 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound20 = 1;
            A42TEAFecha = T000J15_A42TEAFecha[0];
            AssignAttri("", false, "A42TEAFecha", context.localUtil.Format(A42TEAFecha, "99/99/99"));
            A43TEAMes = T000J15_A43TEAMes[0];
            AssignAttri("", false, "A43TEAMes", StringUtil.LTrimStr( (decimal)(A43TEAMes), 4, 0));
            A44TEAAno = T000J15_A44TEAAno[0];
            AssignAttri("", false, "A44TEAAno", StringUtil.LTrimStr( (decimal)(A44TEAAno), 4, 0));
            A4IndicadoresCodigo = T000J15_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A5Cod_Area = T000J15_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0J20( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound20 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound20 = 1;
            A42TEAFecha = T000J15_A42TEAFecha[0];
            AssignAttri("", false, "A42TEAFecha", context.localUtil.Format(A42TEAFecha, "99/99/99"));
            A43TEAMes = T000J15_A43TEAMes[0];
            AssignAttri("", false, "A43TEAMes", StringUtil.LTrimStr( (decimal)(A43TEAMes), 4, 0));
            A44TEAAno = T000J15_A44TEAAno[0];
            AssignAttri("", false, "A44TEAAno", StringUtil.LTrimStr( (decimal)(A44TEAAno), 4, 0));
            A4IndicadoresCodigo = T000J15_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A5Cod_Area = T000J15_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
         }
      }

      protected void ScanEnd0J20( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm0J20( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0J20( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0J20( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0J20( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0J20( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0J20( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0J20( )
      {
         edtTEAFecha_Enabled = 0;
         AssignProp("", false, edtTEAFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTEAFecha_Enabled), 5, 0), true);
         edtTEAMes_Enabled = 0;
         AssignProp("", false, edtTEAMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTEAMes_Enabled), 5, 0), true);
         edtTEAAno_Enabled = 0;
         AssignProp("", false, edtTEAAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTEAAno_Enabled), 5, 0), true);
         edtIndicadoresCodigo_Enabled = 0;
         AssignProp("", false, edtIndicadoresCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIndicadoresCodigo_Enabled), 5, 0), true);
         edtCod_Area_Enabled = 0;
         AssignProp("", false, edtCod_Area_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCod_Area_Enabled), 5, 0), true);
         edtTEAValor_Enabled = 0;
         AssignProp("", false, edtTEAValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTEAValor_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0J20( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0J0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("tea.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z42TEAFecha", context.localUtil.DToC( Z42TEAFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z43TEAMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z43TEAMes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z44TEAAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z44TEAAno), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z4IndicadoresCodigo", Z4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "Z5Cod_Area", Z5Cod_Area);
         GxWebStd.gx_hidden_field( context, "Z158TEAValor", StringUtil.LTrim( StringUtil.NToC( Z158TEAValor, 15, 3, ",", "")));
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
         return formatLink("tea.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "TEA" ;
      }

      public override string GetPgmdesc( )
      {
         return "TEA" ;
      }

      protected void InitializeNonKey0J20( )
      {
         A158TEAValor = 0;
         AssignAttri("", false, "A158TEAValor", StringUtil.LTrimStr( A158TEAValor, 15, 3));
         Z158TEAValor = 0;
      }

      protected void InitAll0J20( )
      {
         A42TEAFecha = DateTime.MinValue;
         AssignAttri("", false, "A42TEAFecha", context.localUtil.Format(A42TEAFecha, "99/99/99"));
         A43TEAMes = 0;
         AssignAttri("", false, "A43TEAMes", StringUtil.LTrimStr( (decimal)(A43TEAMes), 4, 0));
         A44TEAAno = 0;
         AssignAttri("", false, "A44TEAAno", StringUtil.LTrimStr( (decimal)(A44TEAAno), 4, 0));
         A4IndicadoresCodigo = "";
         AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
         A5Cod_Area = "";
         AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
         InitializeNonKey0J20( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20247231022333", true, true);
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
         context.AddJavascriptSource("tea.js", "?20247231022334", false, true);
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
         edtTEAFecha_Internalname = "TEAFECHA";
         edtTEAMes_Internalname = "TEAMES";
         edtTEAAno_Internalname = "TEAANO";
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO";
         edtCod_Area_Internalname = "COD_AREA";
         edtTEAValor_Internalname = "TEAVALOR";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_4_Internalname = "PROMPT_4";
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
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "TEA";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtTEAValor_Jsonclick = "";
         edtTEAValor_Enabled = 1;
         imgprompt_5_Visible = 1;
         imgprompt_5_Link = "";
         edtCod_Area_Jsonclick = "";
         edtCod_Area_Enabled = 1;
         imgprompt_4_Visible = 1;
         imgprompt_4_Link = "";
         edtIndicadoresCodigo_Jsonclick = "";
         edtIndicadoresCodigo_Enabled = 1;
         edtTEAAno_Jsonclick = "";
         edtTEAAno_Enabled = 1;
         edtTEAMes_Jsonclick = "";
         edtTEAMes_Enabled = 1;
         edtTEAFecha_Jsonclick = "";
         edtTEAFecha_Enabled = 1;
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
         /* Using cursor T000J16 */
         pr_default.execute(14, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(14);
         /* Using cursor T000J17 */
         pr_default.execute(15, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(15);
         GX_FocusControl = edtTEAValor_Internalname;
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
         /* Using cursor T000J16 */
         pr_default.execute(14, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
         }
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Cod_area( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T000J17 */
         pr_default.execute(15, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
         }
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A158TEAValor", StringUtil.LTrim( StringUtil.NToC( A158TEAValor, 15, 3, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z42TEAFecha", context.localUtil.Format(Z42TEAFecha, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z43TEAMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z43TEAMes), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z44TEAAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z44TEAAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z4IndicadoresCodigo", Z4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "Z5Cod_Area", Z5Cod_Area);
         GxWebStd.gx_hidden_field( context, "Z158TEAValor", StringUtil.LTrim( StringUtil.NToC( Z158TEAValor, 15, 3, ".", "")));
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
         setEventMetadata("VALID_TEAFECHA","{handler:'Valid_Teafecha',iparms:[]");
         setEventMetadata("VALID_TEAFECHA",",oparms:[]}");
         setEventMetadata("VALID_TEAMES","{handler:'Valid_Teames',iparms:[]");
         setEventMetadata("VALID_TEAMES",",oparms:[]}");
         setEventMetadata("VALID_TEAANO","{handler:'Valid_Teaano',iparms:[]");
         setEventMetadata("VALID_TEAANO",",oparms:[]}");
         setEventMetadata("VALID_INDICADORESCODIGO","{handler:'Valid_Indicadorescodigo',iparms:[{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:''}]");
         setEventMetadata("VALID_INDICADORESCODIGO",",oparms:[]}");
         setEventMetadata("VALID_COD_AREA","{handler:'Valid_Cod_area',iparms:[{av:'A42TEAFecha',fld:'TEAFECHA',pic:''},{av:'A43TEAMes',fld:'TEAMES',pic:'ZZZ9'},{av:'A44TEAAno',fld:'TEAANO',pic:'ZZZ9'},{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:''},{av:'A5Cod_Area',fld:'COD_AREA',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_COD_AREA",",oparms:[{av:'A158TEAValor',fld:'TEAVALOR',pic:'ZZZZZZZZZZ9.999'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z42TEAFecha'},{av:'Z43TEAMes'},{av:'Z44TEAAno'},{av:'Z4IndicadoresCodigo'},{av:'Z5Cod_Area'},{av:'Z158TEAValor'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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
         Z42TEAFecha = DateTime.MinValue;
         Z4IndicadoresCodigo = "";
         Z5Cod_Area = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A4IndicadoresCodigo = "";
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
         A42TEAFecha = DateTime.MinValue;
         imgprompt_4_gximage = "";
         sImgUrl = "";
         imgprompt_5_gximage = "";
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
         T000J6_A42TEAFecha = new DateTime[] {DateTime.MinValue} ;
         T000J6_A43TEAMes = new short[1] ;
         T000J6_A44TEAAno = new short[1] ;
         T000J6_A158TEAValor = new decimal[1] ;
         T000J6_A4IndicadoresCodigo = new string[] {""} ;
         T000J6_A5Cod_Area = new string[] {""} ;
         T000J4_A4IndicadoresCodigo = new string[] {""} ;
         T000J5_A5Cod_Area = new string[] {""} ;
         T000J7_A4IndicadoresCodigo = new string[] {""} ;
         T000J8_A5Cod_Area = new string[] {""} ;
         T000J9_A42TEAFecha = new DateTime[] {DateTime.MinValue} ;
         T000J9_A43TEAMes = new short[1] ;
         T000J9_A44TEAAno = new short[1] ;
         T000J9_A4IndicadoresCodigo = new string[] {""} ;
         T000J9_A5Cod_Area = new string[] {""} ;
         T000J3_A42TEAFecha = new DateTime[] {DateTime.MinValue} ;
         T000J3_A43TEAMes = new short[1] ;
         T000J3_A44TEAAno = new short[1] ;
         T000J3_A158TEAValor = new decimal[1] ;
         T000J3_A4IndicadoresCodigo = new string[] {""} ;
         T000J3_A5Cod_Area = new string[] {""} ;
         sMode20 = "";
         T000J10_A42TEAFecha = new DateTime[] {DateTime.MinValue} ;
         T000J10_A43TEAMes = new short[1] ;
         T000J10_A44TEAAno = new short[1] ;
         T000J10_A4IndicadoresCodigo = new string[] {""} ;
         T000J10_A5Cod_Area = new string[] {""} ;
         T000J11_A42TEAFecha = new DateTime[] {DateTime.MinValue} ;
         T000J11_A43TEAMes = new short[1] ;
         T000J11_A44TEAAno = new short[1] ;
         T000J11_A4IndicadoresCodigo = new string[] {""} ;
         T000J11_A5Cod_Area = new string[] {""} ;
         T000J2_A42TEAFecha = new DateTime[] {DateTime.MinValue} ;
         T000J2_A43TEAMes = new short[1] ;
         T000J2_A44TEAAno = new short[1] ;
         T000J2_A158TEAValor = new decimal[1] ;
         T000J2_A4IndicadoresCodigo = new string[] {""} ;
         T000J2_A5Cod_Area = new string[] {""} ;
         T000J15_A42TEAFecha = new DateTime[] {DateTime.MinValue} ;
         T000J15_A43TEAMes = new short[1] ;
         T000J15_A44TEAAno = new short[1] ;
         T000J15_A4IndicadoresCodigo = new string[] {""} ;
         T000J15_A5Cod_Area = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T000J16_A4IndicadoresCodigo = new string[] {""} ;
         T000J17_A5Cod_Area = new string[] {""} ;
         ZZ42TEAFecha = DateTime.MinValue;
         ZZ4IndicadoresCodigo = "";
         ZZ5Cod_Area = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tea__default(),
            new Object[][] {
                new Object[] {
               T000J2_A42TEAFecha, T000J2_A43TEAMes, T000J2_A44TEAAno, T000J2_A158TEAValor, T000J2_A4IndicadoresCodigo, T000J2_A5Cod_Area
               }
               , new Object[] {
               T000J3_A42TEAFecha, T000J3_A43TEAMes, T000J3_A44TEAAno, T000J3_A158TEAValor, T000J3_A4IndicadoresCodigo, T000J3_A5Cod_Area
               }
               , new Object[] {
               T000J4_A4IndicadoresCodigo
               }
               , new Object[] {
               T000J5_A5Cod_Area
               }
               , new Object[] {
               T000J6_A42TEAFecha, T000J6_A43TEAMes, T000J6_A44TEAAno, T000J6_A158TEAValor, T000J6_A4IndicadoresCodigo, T000J6_A5Cod_Area
               }
               , new Object[] {
               T000J7_A4IndicadoresCodigo
               }
               , new Object[] {
               T000J8_A5Cod_Area
               }
               , new Object[] {
               T000J9_A42TEAFecha, T000J9_A43TEAMes, T000J9_A44TEAAno, T000J9_A4IndicadoresCodigo, T000J9_A5Cod_Area
               }
               , new Object[] {
               T000J10_A42TEAFecha, T000J10_A43TEAMes, T000J10_A44TEAAno, T000J10_A4IndicadoresCodigo, T000J10_A5Cod_Area
               }
               , new Object[] {
               T000J11_A42TEAFecha, T000J11_A43TEAMes, T000J11_A44TEAAno, T000J11_A4IndicadoresCodigo, T000J11_A5Cod_Area
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000J15_A42TEAFecha, T000J15_A43TEAMes, T000J15_A44TEAAno, T000J15_A4IndicadoresCodigo, T000J15_A5Cod_Area
               }
               , new Object[] {
               T000J16_A4IndicadoresCodigo
               }
               , new Object[] {
               T000J17_A5Cod_Area
               }
            }
         );
      }

      private short Z43TEAMes ;
      private short Z44TEAAno ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A43TEAMes ;
      private short A44TEAAno ;
      private short GX_JID ;
      private short RcdFound20 ;
      private short nIsDirty_20 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ43TEAMes ;
      private short ZZ44TEAAno ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtTEAFecha_Enabled ;
      private int edtTEAMes_Enabled ;
      private int edtTEAAno_Enabled ;
      private int edtIndicadoresCodigo_Enabled ;
      private int imgprompt_4_Visible ;
      private int edtCod_Area_Enabled ;
      private int imgprompt_5_Visible ;
      private int edtTEAValor_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private decimal Z158TEAValor ;
      private decimal A158TEAValor ;
      private decimal ZZ158TEAValor ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTEAFecha_Internalname ;
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
      private string edtTEAFecha_Jsonclick ;
      private string edtTEAMes_Internalname ;
      private string edtTEAMes_Jsonclick ;
      private string edtTEAAno_Internalname ;
      private string edtTEAAno_Jsonclick ;
      private string edtIndicadoresCodigo_Internalname ;
      private string edtIndicadoresCodigo_Jsonclick ;
      private string imgprompt_4_gximage ;
      private string sImgUrl ;
      private string imgprompt_4_Internalname ;
      private string imgprompt_4_Link ;
      private string edtCod_Area_Internalname ;
      private string edtCod_Area_Jsonclick ;
      private string imgprompt_5_gximage ;
      private string imgprompt_5_Internalname ;
      private string imgprompt_5_Link ;
      private string edtTEAValor_Internalname ;
      private string edtTEAValor_Jsonclick ;
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
      private string sMode20 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z42TEAFecha ;
      private DateTime A42TEAFecha ;
      private DateTime ZZ42TEAFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string Z4IndicadoresCodigo ;
      private string Z5Cod_Area ;
      private string A4IndicadoresCodigo ;
      private string A5Cod_Area ;
      private string ZZ4IndicadoresCodigo ;
      private string ZZ5Cod_Area ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] T000J6_A42TEAFecha ;
      private short[] T000J6_A43TEAMes ;
      private short[] T000J6_A44TEAAno ;
      private decimal[] T000J6_A158TEAValor ;
      private string[] T000J6_A4IndicadoresCodigo ;
      private string[] T000J6_A5Cod_Area ;
      private string[] T000J4_A4IndicadoresCodigo ;
      private string[] T000J5_A5Cod_Area ;
      private string[] T000J7_A4IndicadoresCodigo ;
      private string[] T000J8_A5Cod_Area ;
      private DateTime[] T000J9_A42TEAFecha ;
      private short[] T000J9_A43TEAMes ;
      private short[] T000J9_A44TEAAno ;
      private string[] T000J9_A4IndicadoresCodigo ;
      private string[] T000J9_A5Cod_Area ;
      private DateTime[] T000J3_A42TEAFecha ;
      private short[] T000J3_A43TEAMes ;
      private short[] T000J3_A44TEAAno ;
      private decimal[] T000J3_A158TEAValor ;
      private string[] T000J3_A4IndicadoresCodigo ;
      private string[] T000J3_A5Cod_Area ;
      private DateTime[] T000J10_A42TEAFecha ;
      private short[] T000J10_A43TEAMes ;
      private short[] T000J10_A44TEAAno ;
      private string[] T000J10_A4IndicadoresCodigo ;
      private string[] T000J10_A5Cod_Area ;
      private DateTime[] T000J11_A42TEAFecha ;
      private short[] T000J11_A43TEAMes ;
      private short[] T000J11_A44TEAAno ;
      private string[] T000J11_A4IndicadoresCodigo ;
      private string[] T000J11_A5Cod_Area ;
      private DateTime[] T000J2_A42TEAFecha ;
      private short[] T000J2_A43TEAMes ;
      private short[] T000J2_A44TEAAno ;
      private decimal[] T000J2_A158TEAValor ;
      private string[] T000J2_A4IndicadoresCodigo ;
      private string[] T000J2_A5Cod_Area ;
      private DateTime[] T000J15_A42TEAFecha ;
      private short[] T000J15_A43TEAMes ;
      private short[] T000J15_A44TEAAno ;
      private string[] T000J15_A4IndicadoresCodigo ;
      private string[] T000J15_A5Cod_Area ;
      private string[] T000J16_A4IndicadoresCodigo ;
      private string[] T000J17_A5Cod_Area ;
      private GXWebForm Form ;
   }

   public class tea__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT000J6;
          prmT000J6 = new Object[] {
          new ParDef("@TEAFecha",GXType.Date,8,0) ,
          new ParDef("@TEAMes",GXType.Int16,4,0) ,
          new ParDef("@TEAAno",GXType.Int16,4,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000J4;
          prmT000J4 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000J5;
          prmT000J5 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000J7;
          prmT000J7 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000J8;
          prmT000J8 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000J9;
          prmT000J9 = new Object[] {
          new ParDef("@TEAFecha",GXType.Date,8,0) ,
          new ParDef("@TEAMes",GXType.Int16,4,0) ,
          new ParDef("@TEAAno",GXType.Int16,4,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000J3;
          prmT000J3 = new Object[] {
          new ParDef("@TEAFecha",GXType.Date,8,0) ,
          new ParDef("@TEAMes",GXType.Int16,4,0) ,
          new ParDef("@TEAAno",GXType.Int16,4,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000J10;
          prmT000J10 = new Object[] {
          new ParDef("@TEAFecha",GXType.Date,8,0) ,
          new ParDef("@TEAMes",GXType.Int16,4,0) ,
          new ParDef("@TEAAno",GXType.Int16,4,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000J11;
          prmT000J11 = new Object[] {
          new ParDef("@TEAFecha",GXType.Date,8,0) ,
          new ParDef("@TEAMes",GXType.Int16,4,0) ,
          new ParDef("@TEAAno",GXType.Int16,4,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000J2;
          prmT000J2 = new Object[] {
          new ParDef("@TEAFecha",GXType.Date,8,0) ,
          new ParDef("@TEAMes",GXType.Int16,4,0) ,
          new ParDef("@TEAAno",GXType.Int16,4,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000J12;
          prmT000J12 = new Object[] {
          new ParDef("@TEAFecha",GXType.Date,8,0) ,
          new ParDef("@TEAMes",GXType.Int16,4,0) ,
          new ParDef("@TEAAno",GXType.Int16,4,0) ,
          new ParDef("@TEAValor",GXType.Decimal,15,3) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000J13;
          prmT000J13 = new Object[] {
          new ParDef("@TEAValor",GXType.Decimal,15,3) ,
          new ParDef("@TEAFecha",GXType.Date,8,0) ,
          new ParDef("@TEAMes",GXType.Int16,4,0) ,
          new ParDef("@TEAAno",GXType.Int16,4,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000J14;
          prmT000J14 = new Object[] {
          new ParDef("@TEAFecha",GXType.Date,8,0) ,
          new ParDef("@TEAMes",GXType.Int16,4,0) ,
          new ParDef("@TEAAno",GXType.Int16,4,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000J15;
          prmT000J15 = new Object[] {
          };
          Object[] prmT000J16;
          prmT000J16 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000J17;
          prmT000J17 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("T000J2", "SELECT [TEAFecha], [TEAMes], [TEAAno], [TEAValor], [IndicadoresCodigo], [Cod_Area] FROM [TEA] WITH (UPDLOCK) WHERE [TEAFecha] = @TEAFecha AND [TEAMes] = @TEAMes AND [TEAAno] = @TEAAno AND [IndicadoresCodigo] = @IndicadoresCodigo AND [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000J3", "SELECT [TEAFecha], [TEAMes], [TEAAno], [TEAValor], [IndicadoresCodigo], [Cod_Area] FROM [TEA] WHERE [TEAFecha] = @TEAFecha AND [TEAMes] = @TEAMes AND [TEAAno] = @TEAAno AND [IndicadoresCodigo] = @IndicadoresCodigo AND [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000J4", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000J5", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000J6", "SELECT TM1.[TEAFecha], TM1.[TEAMes], TM1.[TEAAno], TM1.[TEAValor], TM1.[IndicadoresCodigo], TM1.[Cod_Area] FROM [TEA] TM1 WHERE TM1.[TEAFecha] = @TEAFecha and TM1.[TEAMes] = @TEAMes and TM1.[TEAAno] = @TEAAno and TM1.[IndicadoresCodigo] = @IndicadoresCodigo and TM1.[Cod_Area] = @Cod_Area ORDER BY TM1.[TEAFecha], TM1.[TEAMes], TM1.[TEAAno], TM1.[IndicadoresCodigo], TM1.[Cod_Area]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000J6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000J7", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000J8", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000J9", "SELECT [TEAFecha], [TEAMes], [TEAAno], [IndicadoresCodigo], [Cod_Area] FROM [TEA] WHERE [TEAFecha] = @TEAFecha AND [TEAMes] = @TEAMes AND [TEAAno] = @TEAAno AND [IndicadoresCodigo] = @IndicadoresCodigo AND [Cod_Area] = @Cod_Area  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000J9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000J10", "SELECT TOP 1 [TEAFecha], [TEAMes], [TEAAno], [IndicadoresCodigo], [Cod_Area] FROM [TEA] WHERE ( [TEAFecha] > @TEAFecha or [TEAFecha] = @TEAFecha and [TEAMes] > @TEAMes or [TEAMes] = @TEAMes and [TEAFecha] = @TEAFecha and [TEAAno] > @TEAAno or [TEAAno] = @TEAAno and [TEAMes] = @TEAMes and [TEAFecha] = @TEAFecha and [IndicadoresCodigo] > @IndicadoresCodigo or [IndicadoresCodigo] = @IndicadoresCodigo and [TEAAno] = @TEAAno and [TEAMes] = @TEAMes and [TEAFecha] = @TEAFecha and [Cod_Area] > @Cod_Area) ORDER BY [TEAFecha], [TEAMes], [TEAAno], [IndicadoresCodigo], [Cod_Area]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000J10,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000J11", "SELECT TOP 1 [TEAFecha], [TEAMes], [TEAAno], [IndicadoresCodigo], [Cod_Area] FROM [TEA] WHERE ( [TEAFecha] < @TEAFecha or [TEAFecha] = @TEAFecha and [TEAMes] < @TEAMes or [TEAMes] = @TEAMes and [TEAFecha] = @TEAFecha and [TEAAno] < @TEAAno or [TEAAno] = @TEAAno and [TEAMes] = @TEAMes and [TEAFecha] = @TEAFecha and [IndicadoresCodigo] < @IndicadoresCodigo or [IndicadoresCodigo] = @IndicadoresCodigo and [TEAAno] = @TEAAno and [TEAMes] = @TEAMes and [TEAFecha] = @TEAFecha and [Cod_Area] < @Cod_Area) ORDER BY [TEAFecha] DESC, [TEAMes] DESC, [TEAAno] DESC, [IndicadoresCodigo] DESC, [Cod_Area] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000J11,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000J12", "INSERT INTO [TEA]([TEAFecha], [TEAMes], [TEAAno], [TEAValor], [IndicadoresCodigo], [Cod_Area]) VALUES(@TEAFecha, @TEAMes, @TEAAno, @TEAValor, @IndicadoresCodigo, @Cod_Area)", GxErrorMask.GX_NOMASK,prmT000J12)
             ,new CursorDef("T000J13", "UPDATE [TEA] SET [TEAValor]=@TEAValor  WHERE [TEAFecha] = @TEAFecha AND [TEAMes] = @TEAMes AND [TEAAno] = @TEAAno AND [IndicadoresCodigo] = @IndicadoresCodigo AND [Cod_Area] = @Cod_Area", GxErrorMask.GX_NOMASK,prmT000J13)
             ,new CursorDef("T000J14", "DELETE FROM [TEA]  WHERE [TEAFecha] = @TEAFecha AND [TEAMes] = @TEAMes AND [TEAAno] = @TEAAno AND [IndicadoresCodigo] = @IndicadoresCodigo AND [Cod_Area] = @Cod_Area", GxErrorMask.GX_NOMASK,prmT000J14)
             ,new CursorDef("T000J15", "SELECT [TEAFecha], [TEAMes], [TEAAno], [IndicadoresCodigo], [Cod_Area] FROM [TEA] ORDER BY [TEAFecha], [TEAMes], [TEAAno], [IndicadoresCodigo], [Cod_Area]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000J15,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000J16", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J16,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000J17", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J17,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                return;
             case 1 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
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
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
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
