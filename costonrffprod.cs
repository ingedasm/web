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
   public class costonrffprod : GXDataArea
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
            Form.Meta.addItem("description", "COSTONRFFPROD", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCOSTONRFFPRODfec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("IndicadroresPalmas", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public costonrffprod( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("IndicadroresPalmas", true);
      }

      public costonrffprod( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "COSTONRFFPROD", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_COSTONRFFPROD.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSTONRFFPROD.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSTONRFFPROD.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSTONRFFPROD.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSTONRFFPROD.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 4, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx00u0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"COSTONRFFPRODFEC"+"'), id:'"+"COSTONRFFPRODFEC"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"COSTONRFFPRODMES"+"'), id:'"+"COSTONRFFPRODMES"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"COSTONRFFPRODANO"+"'), id:'"+"COSTONRFFPRODANO"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"COD_AREA"+"'), id:'"+"COD_AREA"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"INDICADORESCODIGO"+"'), id:'"+"INDICADORESCODIGO"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_COSTONRFFPROD.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCOSTONRFFPRODfec_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCOSTONRFFPRODfec_Internalname, "COSTONRFFPRODfec", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCOSTONRFFPRODfec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCOSTONRFFPRODfec_Internalname, context.localUtil.Format(A60COSTONRFFPRODfec, "99/99/99"), context.localUtil.Format( A60COSTONRFFPRODfec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCOSTONRFFPRODfec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCOSTONRFFPRODfec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_COSTONRFFPROD.htm");
         GxWebStd.gx_bitmap( context, edtCOSTONRFFPRODfec_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCOSTONRFFPRODfec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_COSTONRFFPROD.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCOSTONRFFPRODmes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCOSTONRFFPRODmes_Internalname, "COSTONRFFPRODmes", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCOSTONRFFPRODmes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A61COSTONRFFPRODmes), 4, 0, ",", "")), StringUtil.LTrim( ((edtCOSTONRFFPRODmes_Enabled!=0) ? context.localUtil.Format( (decimal)(A61COSTONRFFPRODmes), "ZZZ9") : context.localUtil.Format( (decimal)(A61COSTONRFFPRODmes), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCOSTONRFFPRODmes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCOSTONRFFPRODmes_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_COSTONRFFPROD.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCOSTONRFFPRODano_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCOSTONRFFPRODano_Internalname, "COSTONRFFPRODano", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCOSTONRFFPRODano_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A62COSTONRFFPRODano), 4, 0, ",", "")), StringUtil.LTrim( ((edtCOSTONRFFPRODano_Enabled!=0) ? context.localUtil.Format( (decimal)(A62COSTONRFFPRODano), "ZZZ9") : context.localUtil.Format( (decimal)(A62COSTONRFFPRODano), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCOSTONRFFPRODano_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCOSTONRFFPRODano_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_COSTONRFFPROD.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCod_Area_Internalname, A5Cod_Area, StringUtil.RTrim( context.localUtil.Format( A5Cod_Area, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCod_Area_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCod_Area_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_COSTONRFFPROD.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_5_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_5_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_5_Internalname, sImgUrl, imgprompt_5_Link, "", "", context.GetTheme( ), imgprompt_5_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_COSTONRFFPROD.htm");
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
         GxWebStd.gx_single_line_edit( context, edtIndicadoresCodigo_Internalname, A4IndicadoresCodigo, StringUtil.RTrim( context.localUtil.Format( A4IndicadoresCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIndicadoresCodigo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIndicadoresCodigo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_COSTONRFFPROD.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_4_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_4_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_4_Internalname, sImgUrl, imgprompt_4_Link, "", "", context.GetTheme( ), imgprompt_4_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_COSTONRFFPROD.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCOSTONRFFPRODValoEjec_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCOSTONRFFPRODValoEjec_Internalname, "Ejec", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCOSTONRFFPRODValoEjec_Internalname, StringUtil.LTrim( StringUtil.NToC( A179COSTONRFFPRODValoEjec, 14, 2, ",", "")), StringUtil.LTrim( ((edtCOSTONRFFPRODValoEjec_Enabled!=0) ? context.localUtil.Format( A179COSTONRFFPRODValoEjec, "ZZZZZZZZZZ9.99") : context.localUtil.Format( A179COSTONRFFPRODValoEjec, "ZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCOSTONRFFPRODValoEjec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCOSTONRFFPRODValoEjec_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_COSTONRFFPROD.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSTONRFFPROD.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSTONRFFPROD.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSTONRFFPROD.htm");
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
            Z60COSTONRFFPRODfec = context.localUtil.CToD( cgiGet( "Z60COSTONRFFPRODfec"), 0);
            Z61COSTONRFFPRODmes = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z61COSTONRFFPRODmes"), ",", "."), 18, MidpointRounding.ToEven));
            Z62COSTONRFFPRODano = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z62COSTONRFFPRODano"), ",", "."), 18, MidpointRounding.ToEven));
            Z5Cod_Area = cgiGet( "Z5Cod_Area");
            Z4IndicadoresCodigo = cgiGet( "Z4IndicadoresCodigo");
            Z179COSTONRFFPRODValoEjec = context.localUtil.CToN( cgiGet( "Z179COSTONRFFPRODValoEjec"), ",", ".");
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( context.localUtil.VCDate( cgiGet( edtCOSTONRFFPRODfec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"COSTONRFFPRODfec"}), 1, "COSTONRFFPRODFEC");
               AnyError = 1;
               GX_FocusControl = edtCOSTONRFFPRODfec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A60COSTONRFFPRODfec = DateTime.MinValue;
               AssignAttri("", false, "A60COSTONRFFPRODfec", context.localUtil.Format(A60COSTONRFFPRODfec, "99/99/99"));
            }
            else
            {
               A60COSTONRFFPRODfec = context.localUtil.CToD( cgiGet( edtCOSTONRFFPRODfec_Internalname), 2);
               AssignAttri("", false, "A60COSTONRFFPRODfec", context.localUtil.Format(A60COSTONRFFPRODfec, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCOSTONRFFPRODmes_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCOSTONRFFPRODmes_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COSTONRFFPRODMES");
               AnyError = 1;
               GX_FocusControl = edtCOSTONRFFPRODmes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A61COSTONRFFPRODmes = 0;
               AssignAttri("", false, "A61COSTONRFFPRODmes", StringUtil.LTrimStr( (decimal)(A61COSTONRFFPRODmes), 4, 0));
            }
            else
            {
               A61COSTONRFFPRODmes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCOSTONRFFPRODmes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A61COSTONRFFPRODmes", StringUtil.LTrimStr( (decimal)(A61COSTONRFFPRODmes), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCOSTONRFFPRODano_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCOSTONRFFPRODano_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COSTONRFFPRODANO");
               AnyError = 1;
               GX_FocusControl = edtCOSTONRFFPRODano_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A62COSTONRFFPRODano = 0;
               AssignAttri("", false, "A62COSTONRFFPRODano", StringUtil.LTrimStr( (decimal)(A62COSTONRFFPRODano), 4, 0));
            }
            else
            {
               A62COSTONRFFPRODano = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCOSTONRFFPRODano_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A62COSTONRFFPRODano", StringUtil.LTrimStr( (decimal)(A62COSTONRFFPRODano), 4, 0));
            }
            A5Cod_Area = cgiGet( edtCod_Area_Internalname);
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = cgiGet( edtIndicadoresCodigo_Internalname);
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCOSTONRFFPRODValoEjec_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCOSTONRFFPRODValoEjec_Internalname), ",", ".") > 99999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COSTONRFFPRODVALOEJEC");
               AnyError = 1;
               GX_FocusControl = edtCOSTONRFFPRODValoEjec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A179COSTONRFFPRODValoEjec = 0;
               AssignAttri("", false, "A179COSTONRFFPRODValoEjec", StringUtil.LTrimStr( A179COSTONRFFPRODValoEjec, 14, 2));
            }
            else
            {
               A179COSTONRFFPRODValoEjec = context.localUtil.CToN( cgiGet( edtCOSTONRFFPRODValoEjec_Internalname), ",", ".");
               AssignAttri("", false, "A179COSTONRFFPRODValoEjec", StringUtil.LTrimStr( A179COSTONRFFPRODValoEjec, 14, 2));
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
               A60COSTONRFFPRODfec = context.localUtil.ParseDateParm( GetPar( "COSTONRFFPRODfec"));
               AssignAttri("", false, "A60COSTONRFFPRODfec", context.localUtil.Format(A60COSTONRFFPRODfec, "99/99/99"));
               A61COSTONRFFPRODmes = (short)(Math.Round(NumberUtil.Val( GetPar( "COSTONRFFPRODmes"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A61COSTONRFFPRODmes", StringUtil.LTrimStr( (decimal)(A61COSTONRFFPRODmes), 4, 0));
               A62COSTONRFFPRODano = (short)(Math.Round(NumberUtil.Val( GetPar( "COSTONRFFPRODano"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A62COSTONRFFPRODano", StringUtil.LTrimStr( (decimal)(A62COSTONRFFPRODano), 4, 0));
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
               InitAll0T30( ) ;
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
         DisableAttributes0T30( ) ;
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

      protected void ResetCaption0T0( )
      {
      }

      protected void ZM0T30( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z179COSTONRFFPRODValoEjec = T000T3_A179COSTONRFFPRODValoEjec[0];
            }
            else
            {
               Z179COSTONRFFPRODValoEjec = A179COSTONRFFPRODValoEjec;
            }
         }
         if ( GX_JID == -2 )
         {
            Z60COSTONRFFPRODfec = A60COSTONRFFPRODfec;
            Z61COSTONRFFPRODmes = A61COSTONRFFPRODmes;
            Z62COSTONRFFPRODano = A62COSTONRFFPRODano;
            Z179COSTONRFFPRODValoEjec = A179COSTONRFFPRODValoEjec;
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

      protected void Load0T30( )
      {
         /* Using cursor T000T6 */
         pr_default.execute(4, new Object[] {A60COSTONRFFPRODfec, A61COSTONRFFPRODmes, A62COSTONRFFPRODano, A5Cod_Area, A4IndicadoresCodigo});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound30 = 1;
            A179COSTONRFFPRODValoEjec = T000T6_A179COSTONRFFPRODValoEjec[0];
            AssignAttri("", false, "A179COSTONRFFPRODValoEjec", StringUtil.LTrimStr( A179COSTONRFFPRODValoEjec, 14, 2));
            ZM0T30( -2) ;
         }
         pr_default.close(4);
         OnLoadActions0T30( ) ;
      }

      protected void OnLoadActions0T30( )
      {
      }

      protected void CheckExtendedTable0T30( )
      {
         nIsDirty_30 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A60COSTONRFFPRODfec) || ( DateTimeUtil.ResetTime ( A60COSTONRFFPRODfec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo COSTONRFFPRODfec fuera de rango", "OutOfRange", 1, "COSTONRFFPRODFEC");
            AnyError = 1;
            GX_FocusControl = edtCOSTONRFFPRODfec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000T4 */
         pr_default.execute(2, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T000T5 */
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

      protected void CloseExtendedTableCursors0T30( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( string A5Cod_Area )
      {
         /* Using cursor T000T7 */
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
         /* Using cursor T000T8 */
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

      protected void GetKey0T30( )
      {
         /* Using cursor T000T9 */
         pr_default.execute(7, new Object[] {A60COSTONRFFPRODfec, A61COSTONRFFPRODmes, A62COSTONRFFPRODano, A5Cod_Area, A4IndicadoresCodigo});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound30 = 1;
         }
         else
         {
            RcdFound30 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000T3 */
         pr_default.execute(1, new Object[] {A60COSTONRFFPRODfec, A61COSTONRFFPRODmes, A62COSTONRFFPRODano, A5Cod_Area, A4IndicadoresCodigo});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0T30( 2) ;
            RcdFound30 = 1;
            A60COSTONRFFPRODfec = T000T3_A60COSTONRFFPRODfec[0];
            AssignAttri("", false, "A60COSTONRFFPRODfec", context.localUtil.Format(A60COSTONRFFPRODfec, "99/99/99"));
            A61COSTONRFFPRODmes = T000T3_A61COSTONRFFPRODmes[0];
            AssignAttri("", false, "A61COSTONRFFPRODmes", StringUtil.LTrimStr( (decimal)(A61COSTONRFFPRODmes), 4, 0));
            A62COSTONRFFPRODano = T000T3_A62COSTONRFFPRODano[0];
            AssignAttri("", false, "A62COSTONRFFPRODano", StringUtil.LTrimStr( (decimal)(A62COSTONRFFPRODano), 4, 0));
            A179COSTONRFFPRODValoEjec = T000T3_A179COSTONRFFPRODValoEjec[0];
            AssignAttri("", false, "A179COSTONRFFPRODValoEjec", StringUtil.LTrimStr( A179COSTONRFFPRODValoEjec, 14, 2));
            A5Cod_Area = T000T3_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = T000T3_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            Z60COSTONRFFPRODfec = A60COSTONRFFPRODfec;
            Z61COSTONRFFPRODmes = A61COSTONRFFPRODmes;
            Z62COSTONRFFPRODano = A62COSTONRFFPRODano;
            Z5Cod_Area = A5Cod_Area;
            Z4IndicadoresCodigo = A4IndicadoresCodigo;
            sMode30 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0T30( ) ;
            if ( AnyError == 1 )
            {
               RcdFound30 = 0;
               InitializeNonKey0T30( ) ;
            }
            Gx_mode = sMode30;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound30 = 0;
            InitializeNonKey0T30( ) ;
            sMode30 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode30;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0T30( ) ;
         if ( RcdFound30 == 0 )
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
         RcdFound30 = 0;
         /* Using cursor T000T10 */
         pr_default.execute(8, new Object[] {A60COSTONRFFPRODfec, A61COSTONRFFPRODmes, A62COSTONRFFPRODano, A5Cod_Area, A4IndicadoresCodigo});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( DateTimeUtil.ResetTime ( T000T10_A60COSTONRFFPRODfec[0] ) < DateTimeUtil.ResetTime ( A60COSTONRFFPRODfec ) ) || ( DateTimeUtil.ResetTime ( T000T10_A60COSTONRFFPRODfec[0] ) == DateTimeUtil.ResetTime ( A60COSTONRFFPRODfec ) ) && ( T000T10_A61COSTONRFFPRODmes[0] < A61COSTONRFFPRODmes ) || ( T000T10_A61COSTONRFFPRODmes[0] == A61COSTONRFFPRODmes ) && ( DateTimeUtil.ResetTime ( T000T10_A60COSTONRFFPRODfec[0] ) == DateTimeUtil.ResetTime ( A60COSTONRFFPRODfec ) ) && ( T000T10_A62COSTONRFFPRODano[0] < A62COSTONRFFPRODano ) || ( T000T10_A62COSTONRFFPRODano[0] == A62COSTONRFFPRODano ) && ( T000T10_A61COSTONRFFPRODmes[0] == A61COSTONRFFPRODmes ) && ( DateTimeUtil.ResetTime ( T000T10_A60COSTONRFFPRODfec[0] ) == DateTimeUtil.ResetTime ( A60COSTONRFFPRODfec ) ) && ( StringUtil.StrCmp(T000T10_A5Cod_Area[0], A5Cod_Area) < 0 ) || ( StringUtil.StrCmp(T000T10_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000T10_A62COSTONRFFPRODano[0] == A62COSTONRFFPRODano ) && ( T000T10_A61COSTONRFFPRODmes[0] == A61COSTONRFFPRODmes ) && ( DateTimeUtil.ResetTime ( T000T10_A60COSTONRFFPRODfec[0] ) == DateTimeUtil.ResetTime ( A60COSTONRFFPRODfec ) ) && ( StringUtil.StrCmp(T000T10_A4IndicadoresCodigo[0], A4IndicadoresCodigo) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( DateTimeUtil.ResetTime ( T000T10_A60COSTONRFFPRODfec[0] ) > DateTimeUtil.ResetTime ( A60COSTONRFFPRODfec ) ) || ( DateTimeUtil.ResetTime ( T000T10_A60COSTONRFFPRODfec[0] ) == DateTimeUtil.ResetTime ( A60COSTONRFFPRODfec ) ) && ( T000T10_A61COSTONRFFPRODmes[0] > A61COSTONRFFPRODmes ) || ( T000T10_A61COSTONRFFPRODmes[0] == A61COSTONRFFPRODmes ) && ( DateTimeUtil.ResetTime ( T000T10_A60COSTONRFFPRODfec[0] ) == DateTimeUtil.ResetTime ( A60COSTONRFFPRODfec ) ) && ( T000T10_A62COSTONRFFPRODano[0] > A62COSTONRFFPRODano ) || ( T000T10_A62COSTONRFFPRODano[0] == A62COSTONRFFPRODano ) && ( T000T10_A61COSTONRFFPRODmes[0] == A61COSTONRFFPRODmes ) && ( DateTimeUtil.ResetTime ( T000T10_A60COSTONRFFPRODfec[0] ) == DateTimeUtil.ResetTime ( A60COSTONRFFPRODfec ) ) && ( StringUtil.StrCmp(T000T10_A5Cod_Area[0], A5Cod_Area) > 0 ) || ( StringUtil.StrCmp(T000T10_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000T10_A62COSTONRFFPRODano[0] == A62COSTONRFFPRODano ) && ( T000T10_A61COSTONRFFPRODmes[0] == A61COSTONRFFPRODmes ) && ( DateTimeUtil.ResetTime ( T000T10_A60COSTONRFFPRODfec[0] ) == DateTimeUtil.ResetTime ( A60COSTONRFFPRODfec ) ) && ( StringUtil.StrCmp(T000T10_A4IndicadoresCodigo[0], A4IndicadoresCodigo) > 0 ) ) )
            {
               A60COSTONRFFPRODfec = T000T10_A60COSTONRFFPRODfec[0];
               AssignAttri("", false, "A60COSTONRFFPRODfec", context.localUtil.Format(A60COSTONRFFPRODfec, "99/99/99"));
               A61COSTONRFFPRODmes = T000T10_A61COSTONRFFPRODmes[0];
               AssignAttri("", false, "A61COSTONRFFPRODmes", StringUtil.LTrimStr( (decimal)(A61COSTONRFFPRODmes), 4, 0));
               A62COSTONRFFPRODano = T000T10_A62COSTONRFFPRODano[0];
               AssignAttri("", false, "A62COSTONRFFPRODano", StringUtil.LTrimStr( (decimal)(A62COSTONRFFPRODano), 4, 0));
               A5Cod_Area = T000T10_A5Cod_Area[0];
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               A4IndicadoresCodigo = T000T10_A4IndicadoresCodigo[0];
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               RcdFound30 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound30 = 0;
         /* Using cursor T000T11 */
         pr_default.execute(9, new Object[] {A60COSTONRFFPRODfec, A61COSTONRFFPRODmes, A62COSTONRFFPRODano, A5Cod_Area, A4IndicadoresCodigo});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( DateTimeUtil.ResetTime ( T000T11_A60COSTONRFFPRODfec[0] ) > DateTimeUtil.ResetTime ( A60COSTONRFFPRODfec ) ) || ( DateTimeUtil.ResetTime ( T000T11_A60COSTONRFFPRODfec[0] ) == DateTimeUtil.ResetTime ( A60COSTONRFFPRODfec ) ) && ( T000T11_A61COSTONRFFPRODmes[0] > A61COSTONRFFPRODmes ) || ( T000T11_A61COSTONRFFPRODmes[0] == A61COSTONRFFPRODmes ) && ( DateTimeUtil.ResetTime ( T000T11_A60COSTONRFFPRODfec[0] ) == DateTimeUtil.ResetTime ( A60COSTONRFFPRODfec ) ) && ( T000T11_A62COSTONRFFPRODano[0] > A62COSTONRFFPRODano ) || ( T000T11_A62COSTONRFFPRODano[0] == A62COSTONRFFPRODano ) && ( T000T11_A61COSTONRFFPRODmes[0] == A61COSTONRFFPRODmes ) && ( DateTimeUtil.ResetTime ( T000T11_A60COSTONRFFPRODfec[0] ) == DateTimeUtil.ResetTime ( A60COSTONRFFPRODfec ) ) && ( StringUtil.StrCmp(T000T11_A5Cod_Area[0], A5Cod_Area) > 0 ) || ( StringUtil.StrCmp(T000T11_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000T11_A62COSTONRFFPRODano[0] == A62COSTONRFFPRODano ) && ( T000T11_A61COSTONRFFPRODmes[0] == A61COSTONRFFPRODmes ) && ( DateTimeUtil.ResetTime ( T000T11_A60COSTONRFFPRODfec[0] ) == DateTimeUtil.ResetTime ( A60COSTONRFFPRODfec ) ) && ( StringUtil.StrCmp(T000T11_A4IndicadoresCodigo[0], A4IndicadoresCodigo) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( DateTimeUtil.ResetTime ( T000T11_A60COSTONRFFPRODfec[0] ) < DateTimeUtil.ResetTime ( A60COSTONRFFPRODfec ) ) || ( DateTimeUtil.ResetTime ( T000T11_A60COSTONRFFPRODfec[0] ) == DateTimeUtil.ResetTime ( A60COSTONRFFPRODfec ) ) && ( T000T11_A61COSTONRFFPRODmes[0] < A61COSTONRFFPRODmes ) || ( T000T11_A61COSTONRFFPRODmes[0] == A61COSTONRFFPRODmes ) && ( DateTimeUtil.ResetTime ( T000T11_A60COSTONRFFPRODfec[0] ) == DateTimeUtil.ResetTime ( A60COSTONRFFPRODfec ) ) && ( T000T11_A62COSTONRFFPRODano[0] < A62COSTONRFFPRODano ) || ( T000T11_A62COSTONRFFPRODano[0] == A62COSTONRFFPRODano ) && ( T000T11_A61COSTONRFFPRODmes[0] == A61COSTONRFFPRODmes ) && ( DateTimeUtil.ResetTime ( T000T11_A60COSTONRFFPRODfec[0] ) == DateTimeUtil.ResetTime ( A60COSTONRFFPRODfec ) ) && ( StringUtil.StrCmp(T000T11_A5Cod_Area[0], A5Cod_Area) < 0 ) || ( StringUtil.StrCmp(T000T11_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000T11_A62COSTONRFFPRODano[0] == A62COSTONRFFPRODano ) && ( T000T11_A61COSTONRFFPRODmes[0] == A61COSTONRFFPRODmes ) && ( DateTimeUtil.ResetTime ( T000T11_A60COSTONRFFPRODfec[0] ) == DateTimeUtil.ResetTime ( A60COSTONRFFPRODfec ) ) && ( StringUtil.StrCmp(T000T11_A4IndicadoresCodigo[0], A4IndicadoresCodigo) < 0 ) ) )
            {
               A60COSTONRFFPRODfec = T000T11_A60COSTONRFFPRODfec[0];
               AssignAttri("", false, "A60COSTONRFFPRODfec", context.localUtil.Format(A60COSTONRFFPRODfec, "99/99/99"));
               A61COSTONRFFPRODmes = T000T11_A61COSTONRFFPRODmes[0];
               AssignAttri("", false, "A61COSTONRFFPRODmes", StringUtil.LTrimStr( (decimal)(A61COSTONRFFPRODmes), 4, 0));
               A62COSTONRFFPRODano = T000T11_A62COSTONRFFPRODano[0];
               AssignAttri("", false, "A62COSTONRFFPRODano", StringUtil.LTrimStr( (decimal)(A62COSTONRFFPRODano), 4, 0));
               A5Cod_Area = T000T11_A5Cod_Area[0];
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               A4IndicadoresCodigo = T000T11_A4IndicadoresCodigo[0];
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               RcdFound30 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0T30( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCOSTONRFFPRODfec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0T30( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound30 == 1 )
            {
               if ( ( DateTimeUtil.ResetTime ( A60COSTONRFFPRODfec ) != DateTimeUtil.ResetTime ( Z60COSTONRFFPRODfec ) ) || ( A61COSTONRFFPRODmes != Z61COSTONRFFPRODmes ) || ( A62COSTONRFFPRODano != Z62COSTONRFFPRODano ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) )
               {
                  A60COSTONRFFPRODfec = Z60COSTONRFFPRODfec;
                  AssignAttri("", false, "A60COSTONRFFPRODfec", context.localUtil.Format(A60COSTONRFFPRODfec, "99/99/99"));
                  A61COSTONRFFPRODmes = Z61COSTONRFFPRODmes;
                  AssignAttri("", false, "A61COSTONRFFPRODmes", StringUtil.LTrimStr( (decimal)(A61COSTONRFFPRODmes), 4, 0));
                  A62COSTONRFFPRODano = Z62COSTONRFFPRODano;
                  AssignAttri("", false, "A62COSTONRFFPRODano", StringUtil.LTrimStr( (decimal)(A62COSTONRFFPRODano), 4, 0));
                  A5Cod_Area = Z5Cod_Area;
                  AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
                  A4IndicadoresCodigo = Z4IndicadoresCodigo;
                  AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "COSTONRFFPRODFEC");
                  AnyError = 1;
                  GX_FocusControl = edtCOSTONRFFPRODfec_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCOSTONRFFPRODfec_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0T30( ) ;
                  GX_FocusControl = edtCOSTONRFFPRODfec_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( DateTimeUtil.ResetTime ( A60COSTONRFFPRODfec ) != DateTimeUtil.ResetTime ( Z60COSTONRFFPRODfec ) ) || ( A61COSTONRFFPRODmes != Z61COSTONRFFPRODmes ) || ( A62COSTONRFFPRODano != Z62COSTONRFFPRODano ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtCOSTONRFFPRODfec_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0T30( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "COSTONRFFPRODFEC");
                     AnyError = 1;
                     GX_FocusControl = edtCOSTONRFFPRODfec_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtCOSTONRFFPRODfec_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0T30( ) ;
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
         if ( ( DateTimeUtil.ResetTime ( A60COSTONRFFPRODfec ) != DateTimeUtil.ResetTime ( Z60COSTONRFFPRODfec ) ) || ( A61COSTONRFFPRODmes != Z61COSTONRFFPRODmes ) || ( A62COSTONRFFPRODano != Z62COSTONRFFPRODano ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) )
         {
            A60COSTONRFFPRODfec = Z60COSTONRFFPRODfec;
            AssignAttri("", false, "A60COSTONRFFPRODfec", context.localUtil.Format(A60COSTONRFFPRODfec, "99/99/99"));
            A61COSTONRFFPRODmes = Z61COSTONRFFPRODmes;
            AssignAttri("", false, "A61COSTONRFFPRODmes", StringUtil.LTrimStr( (decimal)(A61COSTONRFFPRODmes), 4, 0));
            A62COSTONRFFPRODano = Z62COSTONRFFPRODano;
            AssignAttri("", false, "A62COSTONRFFPRODano", StringUtil.LTrimStr( (decimal)(A62COSTONRFFPRODano), 4, 0));
            A5Cod_Area = Z5Cod_Area;
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = Z4IndicadoresCodigo;
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "COSTONRFFPRODFEC");
            AnyError = 1;
            GX_FocusControl = edtCOSTONRFFPRODfec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCOSTONRFFPRODfec_Internalname;
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
         if ( RcdFound30 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "COSTONRFFPRODFEC");
            AnyError = 1;
            GX_FocusControl = edtCOSTONRFFPRODfec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtCOSTONRFFPRODValoEjec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0T30( ) ;
         if ( RcdFound30 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCOSTONRFFPRODValoEjec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0T30( ) ;
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
         if ( RcdFound30 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCOSTONRFFPRODValoEjec_Internalname;
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
         if ( RcdFound30 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCOSTONRFFPRODValoEjec_Internalname;
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
         ScanStart0T30( ) ;
         if ( RcdFound30 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound30 != 0 )
            {
               ScanNext0T30( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCOSTONRFFPRODValoEjec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0T30( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0T30( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000T2 */
            pr_default.execute(0, new Object[] {A60COSTONRFFPRODfec, A61COSTONRFFPRODmes, A62COSTONRFFPRODano, A5Cod_Area, A4IndicadoresCodigo});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"COSTONRFFPROD"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z179COSTONRFFPRODValoEjec != T000T2_A179COSTONRFFPRODValoEjec[0] ) )
            {
               if ( Z179COSTONRFFPRODValoEjec != T000T2_A179COSTONRFFPRODValoEjec[0] )
               {
                  GXUtil.WriteLog("costonrffprod:[seudo value changed for attri]"+"COSTONRFFPRODValoEjec");
                  GXUtil.WriteLogRaw("Old: ",Z179COSTONRFFPRODValoEjec);
                  GXUtil.WriteLogRaw("Current: ",T000T2_A179COSTONRFFPRODValoEjec[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"COSTONRFFPROD"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0T30( )
      {
         BeforeValidate0T30( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0T30( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0T30( 0) ;
            CheckOptimisticConcurrency0T30( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0T30( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0T30( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000T12 */
                     pr_default.execute(10, new Object[] {A60COSTONRFFPRODfec, A61COSTONRFFPRODmes, A62COSTONRFFPRODano, A179COSTONRFFPRODValoEjec, A5Cod_Area, A4IndicadoresCodigo});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("COSTONRFFPROD");
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
                           ResetCaption0T0( ) ;
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
               Load0T30( ) ;
            }
            EndLevel0T30( ) ;
         }
         CloseExtendedTableCursors0T30( ) ;
      }

      protected void Update0T30( )
      {
         BeforeValidate0T30( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0T30( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0T30( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0T30( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0T30( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000T13 */
                     pr_default.execute(11, new Object[] {A179COSTONRFFPRODValoEjec, A60COSTONRFFPRODfec, A61COSTONRFFPRODmes, A62COSTONRFFPRODano, A5Cod_Area, A4IndicadoresCodigo});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("COSTONRFFPROD");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"COSTONRFFPROD"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0T30( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0T0( ) ;
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
            EndLevel0T30( ) ;
         }
         CloseExtendedTableCursors0T30( ) ;
      }

      protected void DeferredUpdate0T30( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0T30( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0T30( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0T30( ) ;
            AfterConfirm0T30( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0T30( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000T14 */
                  pr_default.execute(12, new Object[] {A60COSTONRFFPRODfec, A61COSTONRFFPRODmes, A62COSTONRFFPRODano, A5Cod_Area, A4IndicadoresCodigo});
                  pr_default.close(12);
                  pr_default.SmartCacheProvider.SetUpdated("COSTONRFFPROD");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound30 == 0 )
                        {
                           InitAll0T30( ) ;
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
                        ResetCaption0T0( ) ;
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
         sMode30 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0T30( ) ;
         Gx_mode = sMode30;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0T30( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0T30( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0T30( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("costonrffprod",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0T0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("costonrffprod",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0T30( )
      {
         /* Using cursor T000T15 */
         pr_default.execute(13);
         RcdFound30 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound30 = 1;
            A60COSTONRFFPRODfec = T000T15_A60COSTONRFFPRODfec[0];
            AssignAttri("", false, "A60COSTONRFFPRODfec", context.localUtil.Format(A60COSTONRFFPRODfec, "99/99/99"));
            A61COSTONRFFPRODmes = T000T15_A61COSTONRFFPRODmes[0];
            AssignAttri("", false, "A61COSTONRFFPRODmes", StringUtil.LTrimStr( (decimal)(A61COSTONRFFPRODmes), 4, 0));
            A62COSTONRFFPRODano = T000T15_A62COSTONRFFPRODano[0];
            AssignAttri("", false, "A62COSTONRFFPRODano", StringUtil.LTrimStr( (decimal)(A62COSTONRFFPRODano), 4, 0));
            A5Cod_Area = T000T15_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = T000T15_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0T30( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound30 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound30 = 1;
            A60COSTONRFFPRODfec = T000T15_A60COSTONRFFPRODfec[0];
            AssignAttri("", false, "A60COSTONRFFPRODfec", context.localUtil.Format(A60COSTONRFFPRODfec, "99/99/99"));
            A61COSTONRFFPRODmes = T000T15_A61COSTONRFFPRODmes[0];
            AssignAttri("", false, "A61COSTONRFFPRODmes", StringUtil.LTrimStr( (decimal)(A61COSTONRFFPRODmes), 4, 0));
            A62COSTONRFFPRODano = T000T15_A62COSTONRFFPRODano[0];
            AssignAttri("", false, "A62COSTONRFFPRODano", StringUtil.LTrimStr( (decimal)(A62COSTONRFFPRODano), 4, 0));
            A5Cod_Area = T000T15_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = T000T15_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
         }
      }

      protected void ScanEnd0T30( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm0T30( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0T30( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0T30( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0T30( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0T30( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0T30( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0T30( )
      {
         edtCOSTONRFFPRODfec_Enabled = 0;
         AssignProp("", false, edtCOSTONRFFPRODfec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSTONRFFPRODfec_Enabled), 5, 0), true);
         edtCOSTONRFFPRODmes_Enabled = 0;
         AssignProp("", false, edtCOSTONRFFPRODmes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSTONRFFPRODmes_Enabled), 5, 0), true);
         edtCOSTONRFFPRODano_Enabled = 0;
         AssignProp("", false, edtCOSTONRFFPRODano_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSTONRFFPRODano_Enabled), 5, 0), true);
         edtCod_Area_Enabled = 0;
         AssignProp("", false, edtCod_Area_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCod_Area_Enabled), 5, 0), true);
         edtIndicadoresCodigo_Enabled = 0;
         AssignProp("", false, edtIndicadoresCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIndicadoresCodigo_Enabled), 5, 0), true);
         edtCOSTONRFFPRODValoEjec_Enabled = 0;
         AssignProp("", false, edtCOSTONRFFPRODValoEjec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSTONRFFPRODValoEjec_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0T30( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0T0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("costonrffprod.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z60COSTONRFFPRODfec", context.localUtil.DToC( Z60COSTONRFFPRODfec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z61COSTONRFFPRODmes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z61COSTONRFFPRODmes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z62COSTONRFFPRODano", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z62COSTONRFFPRODano), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z5Cod_Area", Z5Cod_Area);
         GxWebStd.gx_hidden_field( context, "Z4IndicadoresCodigo", Z4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "Z179COSTONRFFPRODValoEjec", StringUtil.LTrim( StringUtil.NToC( Z179COSTONRFFPRODValoEjec, 14, 2, ",", "")));
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
         return formatLink("costonrffprod.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "COSTONRFFPROD" ;
      }

      public override string GetPgmdesc( )
      {
         return "COSTONRFFPROD" ;
      }

      protected void InitializeNonKey0T30( )
      {
         A179COSTONRFFPRODValoEjec = 0;
         AssignAttri("", false, "A179COSTONRFFPRODValoEjec", StringUtil.LTrimStr( A179COSTONRFFPRODValoEjec, 14, 2));
         Z179COSTONRFFPRODValoEjec = 0;
      }

      protected void InitAll0T30( )
      {
         A60COSTONRFFPRODfec = DateTime.MinValue;
         AssignAttri("", false, "A60COSTONRFFPRODfec", context.localUtil.Format(A60COSTONRFFPRODfec, "99/99/99"));
         A61COSTONRFFPRODmes = 0;
         AssignAttri("", false, "A61COSTONRFFPRODmes", StringUtil.LTrimStr( (decimal)(A61COSTONRFFPRODmes), 4, 0));
         A62COSTONRFFPRODano = 0;
         AssignAttri("", false, "A62COSTONRFFPRODano", StringUtil.LTrimStr( (decimal)(A62COSTONRFFPRODano), 4, 0));
         A5Cod_Area = "";
         AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
         A4IndicadoresCodigo = "";
         AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
         InitializeNonKey0T30( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20247231024012", true, true);
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
         context.AddJavascriptSource("costonrffprod.js", "?20247231024012", false, true);
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
         edtCOSTONRFFPRODfec_Internalname = "COSTONRFFPRODFEC";
         edtCOSTONRFFPRODmes_Internalname = "COSTONRFFPRODMES";
         edtCOSTONRFFPRODano_Internalname = "COSTONRFFPRODANO";
         edtCod_Area_Internalname = "COD_AREA";
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO";
         edtCOSTONRFFPRODValoEjec_Internalname = "COSTONRFFPRODVALOEJEC";
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
         Form.Caption = "COSTONRFFPROD";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCOSTONRFFPRODValoEjec_Jsonclick = "";
         edtCOSTONRFFPRODValoEjec_Enabled = 1;
         imgprompt_4_Visible = 1;
         imgprompt_4_Link = "";
         edtIndicadoresCodigo_Jsonclick = "";
         edtIndicadoresCodigo_Enabled = 1;
         imgprompt_5_Visible = 1;
         imgprompt_5_Link = "";
         edtCod_Area_Jsonclick = "";
         edtCod_Area_Enabled = 1;
         edtCOSTONRFFPRODano_Jsonclick = "";
         edtCOSTONRFFPRODano_Enabled = 1;
         edtCOSTONRFFPRODmes_Jsonclick = "";
         edtCOSTONRFFPRODmes_Enabled = 1;
         edtCOSTONRFFPRODfec_Jsonclick = "";
         edtCOSTONRFFPRODfec_Enabled = 1;
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
         /* Using cursor T000T16 */
         pr_default.execute(14, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(14);
         /* Using cursor T000T17 */
         pr_default.execute(15, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(15);
         GX_FocusControl = edtCOSTONRFFPRODValoEjec_Internalname;
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
         /* Using cursor T000T16 */
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
         /* Using cursor T000T17 */
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
         AssignAttri("", false, "A179COSTONRFFPRODValoEjec", StringUtil.LTrim( StringUtil.NToC( A179COSTONRFFPRODValoEjec, 14, 2, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z60COSTONRFFPRODfec", context.localUtil.Format(Z60COSTONRFFPRODfec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z61COSTONRFFPRODmes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z61COSTONRFFPRODmes), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z62COSTONRFFPRODano", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z62COSTONRFFPRODano), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z5Cod_Area", Z5Cod_Area);
         GxWebStd.gx_hidden_field( context, "Z4IndicadoresCodigo", Z4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "Z179COSTONRFFPRODValoEjec", StringUtil.LTrim( StringUtil.NToC( Z179COSTONRFFPRODValoEjec, 14, 2, ".", "")));
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
         setEventMetadata("VALID_COSTONRFFPRODFEC","{handler:'Valid_Costonrffprodfec',iparms:[]");
         setEventMetadata("VALID_COSTONRFFPRODFEC",",oparms:[]}");
         setEventMetadata("VALID_COSTONRFFPRODMES","{handler:'Valid_Costonrffprodmes',iparms:[]");
         setEventMetadata("VALID_COSTONRFFPRODMES",",oparms:[]}");
         setEventMetadata("VALID_COSTONRFFPRODANO","{handler:'Valid_Costonrffprodano',iparms:[]");
         setEventMetadata("VALID_COSTONRFFPRODANO",",oparms:[]}");
         setEventMetadata("VALID_COD_AREA","{handler:'Valid_Cod_area',iparms:[{av:'A5Cod_Area',fld:'COD_AREA',pic:''}]");
         setEventMetadata("VALID_COD_AREA",",oparms:[]}");
         setEventMetadata("VALID_INDICADORESCODIGO","{handler:'Valid_Indicadorescodigo',iparms:[{av:'A60COSTONRFFPRODfec',fld:'COSTONRFFPRODFEC',pic:''},{av:'A61COSTONRFFPRODmes',fld:'COSTONRFFPRODMES',pic:'ZZZ9'},{av:'A62COSTONRFFPRODano',fld:'COSTONRFFPRODANO',pic:'ZZZ9'},{av:'A5Cod_Area',fld:'COD_AREA',pic:''},{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_INDICADORESCODIGO",",oparms:[{av:'A179COSTONRFFPRODValoEjec',fld:'COSTONRFFPRODVALOEJEC',pic:'ZZZZZZZZZZ9.99'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z60COSTONRFFPRODfec'},{av:'Z61COSTONRFFPRODmes'},{av:'Z62COSTONRFFPRODano'},{av:'Z5Cod_Area'},{av:'Z4IndicadoresCodigo'},{av:'Z179COSTONRFFPRODValoEjec'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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
         Z60COSTONRFFPRODfec = DateTime.MinValue;
         Z5Cod_Area = "";
         Z4IndicadoresCodigo = "";
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
         A60COSTONRFFPRODfec = DateTime.MinValue;
         imgprompt_5_gximage = "";
         sImgUrl = "";
         imgprompt_4_gximage = "";
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
         T000T6_A60COSTONRFFPRODfec = new DateTime[] {DateTime.MinValue} ;
         T000T6_A61COSTONRFFPRODmes = new short[1] ;
         T000T6_A62COSTONRFFPRODano = new short[1] ;
         T000T6_A179COSTONRFFPRODValoEjec = new decimal[1] ;
         T000T6_A5Cod_Area = new string[] {""} ;
         T000T6_A4IndicadoresCodigo = new string[] {""} ;
         T000T4_A5Cod_Area = new string[] {""} ;
         T000T5_A4IndicadoresCodigo = new string[] {""} ;
         T000T7_A5Cod_Area = new string[] {""} ;
         T000T8_A4IndicadoresCodigo = new string[] {""} ;
         T000T9_A60COSTONRFFPRODfec = new DateTime[] {DateTime.MinValue} ;
         T000T9_A61COSTONRFFPRODmes = new short[1] ;
         T000T9_A62COSTONRFFPRODano = new short[1] ;
         T000T9_A5Cod_Area = new string[] {""} ;
         T000T9_A4IndicadoresCodigo = new string[] {""} ;
         T000T3_A60COSTONRFFPRODfec = new DateTime[] {DateTime.MinValue} ;
         T000T3_A61COSTONRFFPRODmes = new short[1] ;
         T000T3_A62COSTONRFFPRODano = new short[1] ;
         T000T3_A179COSTONRFFPRODValoEjec = new decimal[1] ;
         T000T3_A5Cod_Area = new string[] {""} ;
         T000T3_A4IndicadoresCodigo = new string[] {""} ;
         sMode30 = "";
         T000T10_A60COSTONRFFPRODfec = new DateTime[] {DateTime.MinValue} ;
         T000T10_A61COSTONRFFPRODmes = new short[1] ;
         T000T10_A62COSTONRFFPRODano = new short[1] ;
         T000T10_A5Cod_Area = new string[] {""} ;
         T000T10_A4IndicadoresCodigo = new string[] {""} ;
         T000T11_A60COSTONRFFPRODfec = new DateTime[] {DateTime.MinValue} ;
         T000T11_A61COSTONRFFPRODmes = new short[1] ;
         T000T11_A62COSTONRFFPRODano = new short[1] ;
         T000T11_A5Cod_Area = new string[] {""} ;
         T000T11_A4IndicadoresCodigo = new string[] {""} ;
         T000T2_A60COSTONRFFPRODfec = new DateTime[] {DateTime.MinValue} ;
         T000T2_A61COSTONRFFPRODmes = new short[1] ;
         T000T2_A62COSTONRFFPRODano = new short[1] ;
         T000T2_A179COSTONRFFPRODValoEjec = new decimal[1] ;
         T000T2_A5Cod_Area = new string[] {""} ;
         T000T2_A4IndicadoresCodigo = new string[] {""} ;
         T000T15_A60COSTONRFFPRODfec = new DateTime[] {DateTime.MinValue} ;
         T000T15_A61COSTONRFFPRODmes = new short[1] ;
         T000T15_A62COSTONRFFPRODano = new short[1] ;
         T000T15_A5Cod_Area = new string[] {""} ;
         T000T15_A4IndicadoresCodigo = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T000T16_A5Cod_Area = new string[] {""} ;
         T000T17_A4IndicadoresCodigo = new string[] {""} ;
         ZZ60COSTONRFFPRODfec = DateTime.MinValue;
         ZZ5Cod_Area = "";
         ZZ4IndicadoresCodigo = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.costonrffprod__default(),
            new Object[][] {
                new Object[] {
               T000T2_A60COSTONRFFPRODfec, T000T2_A61COSTONRFFPRODmes, T000T2_A62COSTONRFFPRODano, T000T2_A179COSTONRFFPRODValoEjec, T000T2_A5Cod_Area, T000T2_A4IndicadoresCodigo
               }
               , new Object[] {
               T000T3_A60COSTONRFFPRODfec, T000T3_A61COSTONRFFPRODmes, T000T3_A62COSTONRFFPRODano, T000T3_A179COSTONRFFPRODValoEjec, T000T3_A5Cod_Area, T000T3_A4IndicadoresCodigo
               }
               , new Object[] {
               T000T4_A5Cod_Area
               }
               , new Object[] {
               T000T5_A4IndicadoresCodigo
               }
               , new Object[] {
               T000T6_A60COSTONRFFPRODfec, T000T6_A61COSTONRFFPRODmes, T000T6_A62COSTONRFFPRODano, T000T6_A179COSTONRFFPRODValoEjec, T000T6_A5Cod_Area, T000T6_A4IndicadoresCodigo
               }
               , new Object[] {
               T000T7_A5Cod_Area
               }
               , new Object[] {
               T000T8_A4IndicadoresCodigo
               }
               , new Object[] {
               T000T9_A60COSTONRFFPRODfec, T000T9_A61COSTONRFFPRODmes, T000T9_A62COSTONRFFPRODano, T000T9_A5Cod_Area, T000T9_A4IndicadoresCodigo
               }
               , new Object[] {
               T000T10_A60COSTONRFFPRODfec, T000T10_A61COSTONRFFPRODmes, T000T10_A62COSTONRFFPRODano, T000T10_A5Cod_Area, T000T10_A4IndicadoresCodigo
               }
               , new Object[] {
               T000T11_A60COSTONRFFPRODfec, T000T11_A61COSTONRFFPRODmes, T000T11_A62COSTONRFFPRODano, T000T11_A5Cod_Area, T000T11_A4IndicadoresCodigo
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000T15_A60COSTONRFFPRODfec, T000T15_A61COSTONRFFPRODmes, T000T15_A62COSTONRFFPRODano, T000T15_A5Cod_Area, T000T15_A4IndicadoresCodigo
               }
               , new Object[] {
               T000T16_A5Cod_Area
               }
               , new Object[] {
               T000T17_A4IndicadoresCodigo
               }
            }
         );
      }

      private short Z61COSTONRFFPRODmes ;
      private short Z62COSTONRFFPRODano ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A61COSTONRFFPRODmes ;
      private short A62COSTONRFFPRODano ;
      private short GX_JID ;
      private short RcdFound30 ;
      private short nIsDirty_30 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ61COSTONRFFPRODmes ;
      private short ZZ62COSTONRFFPRODano ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtCOSTONRFFPRODfec_Enabled ;
      private int edtCOSTONRFFPRODmes_Enabled ;
      private int edtCOSTONRFFPRODano_Enabled ;
      private int edtCod_Area_Enabled ;
      private int imgprompt_5_Visible ;
      private int edtIndicadoresCodigo_Enabled ;
      private int imgprompt_4_Visible ;
      private int edtCOSTONRFFPRODValoEjec_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private decimal Z179COSTONRFFPRODValoEjec ;
      private decimal A179COSTONRFFPRODValoEjec ;
      private decimal ZZ179COSTONRFFPRODValoEjec ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCOSTONRFFPRODfec_Internalname ;
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
      private string edtCOSTONRFFPRODfec_Jsonclick ;
      private string edtCOSTONRFFPRODmes_Internalname ;
      private string edtCOSTONRFFPRODmes_Jsonclick ;
      private string edtCOSTONRFFPRODano_Internalname ;
      private string edtCOSTONRFFPRODano_Jsonclick ;
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
      private string edtCOSTONRFFPRODValoEjec_Internalname ;
      private string edtCOSTONRFFPRODValoEjec_Jsonclick ;
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
      private string sMode30 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z60COSTONRFFPRODfec ;
      private DateTime A60COSTONRFFPRODfec ;
      private DateTime ZZ60COSTONRFFPRODfec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string Z5Cod_Area ;
      private string Z4IndicadoresCodigo ;
      private string A5Cod_Area ;
      private string A4IndicadoresCodigo ;
      private string ZZ5Cod_Area ;
      private string ZZ4IndicadoresCodigo ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] T000T6_A60COSTONRFFPRODfec ;
      private short[] T000T6_A61COSTONRFFPRODmes ;
      private short[] T000T6_A62COSTONRFFPRODano ;
      private decimal[] T000T6_A179COSTONRFFPRODValoEjec ;
      private string[] T000T6_A5Cod_Area ;
      private string[] T000T6_A4IndicadoresCodigo ;
      private string[] T000T4_A5Cod_Area ;
      private string[] T000T5_A4IndicadoresCodigo ;
      private string[] T000T7_A5Cod_Area ;
      private string[] T000T8_A4IndicadoresCodigo ;
      private DateTime[] T000T9_A60COSTONRFFPRODfec ;
      private short[] T000T9_A61COSTONRFFPRODmes ;
      private short[] T000T9_A62COSTONRFFPRODano ;
      private string[] T000T9_A5Cod_Area ;
      private string[] T000T9_A4IndicadoresCodigo ;
      private DateTime[] T000T3_A60COSTONRFFPRODfec ;
      private short[] T000T3_A61COSTONRFFPRODmes ;
      private short[] T000T3_A62COSTONRFFPRODano ;
      private decimal[] T000T3_A179COSTONRFFPRODValoEjec ;
      private string[] T000T3_A5Cod_Area ;
      private string[] T000T3_A4IndicadoresCodigo ;
      private DateTime[] T000T10_A60COSTONRFFPRODfec ;
      private short[] T000T10_A61COSTONRFFPRODmes ;
      private short[] T000T10_A62COSTONRFFPRODano ;
      private string[] T000T10_A5Cod_Area ;
      private string[] T000T10_A4IndicadoresCodigo ;
      private DateTime[] T000T11_A60COSTONRFFPRODfec ;
      private short[] T000T11_A61COSTONRFFPRODmes ;
      private short[] T000T11_A62COSTONRFFPRODano ;
      private string[] T000T11_A5Cod_Area ;
      private string[] T000T11_A4IndicadoresCodigo ;
      private DateTime[] T000T2_A60COSTONRFFPRODfec ;
      private short[] T000T2_A61COSTONRFFPRODmes ;
      private short[] T000T2_A62COSTONRFFPRODano ;
      private decimal[] T000T2_A179COSTONRFFPRODValoEjec ;
      private string[] T000T2_A5Cod_Area ;
      private string[] T000T2_A4IndicadoresCodigo ;
      private DateTime[] T000T15_A60COSTONRFFPRODfec ;
      private short[] T000T15_A61COSTONRFFPRODmes ;
      private short[] T000T15_A62COSTONRFFPRODano ;
      private string[] T000T15_A5Cod_Area ;
      private string[] T000T15_A4IndicadoresCodigo ;
      private string[] T000T16_A5Cod_Area ;
      private string[] T000T17_A4IndicadoresCodigo ;
      private GXWebForm Form ;
   }

   public class costonrffprod__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT000T6;
          prmT000T6 = new Object[] {
          new ParDef("@COSTONRFFPRODfec",GXType.Date,8,0) ,
          new ParDef("@COSTONRFFPRODmes",GXType.Int16,4,0) ,
          new ParDef("@COSTONRFFPRODano",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000T4;
          prmT000T4 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000T5;
          prmT000T5 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000T7;
          prmT000T7 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000T8;
          prmT000T8 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000T9;
          prmT000T9 = new Object[] {
          new ParDef("@COSTONRFFPRODfec",GXType.Date,8,0) ,
          new ParDef("@COSTONRFFPRODmes",GXType.Int16,4,0) ,
          new ParDef("@COSTONRFFPRODano",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000T3;
          prmT000T3 = new Object[] {
          new ParDef("@COSTONRFFPRODfec",GXType.Date,8,0) ,
          new ParDef("@COSTONRFFPRODmes",GXType.Int16,4,0) ,
          new ParDef("@COSTONRFFPRODano",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000T10;
          prmT000T10 = new Object[] {
          new ParDef("@COSTONRFFPRODfec",GXType.Date,8,0) ,
          new ParDef("@COSTONRFFPRODmes",GXType.Int16,4,0) ,
          new ParDef("@COSTONRFFPRODano",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000T11;
          prmT000T11 = new Object[] {
          new ParDef("@COSTONRFFPRODfec",GXType.Date,8,0) ,
          new ParDef("@COSTONRFFPRODmes",GXType.Int16,4,0) ,
          new ParDef("@COSTONRFFPRODano",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000T2;
          prmT000T2 = new Object[] {
          new ParDef("@COSTONRFFPRODfec",GXType.Date,8,0) ,
          new ParDef("@COSTONRFFPRODmes",GXType.Int16,4,0) ,
          new ParDef("@COSTONRFFPRODano",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000T12;
          prmT000T12 = new Object[] {
          new ParDef("@COSTONRFFPRODfec",GXType.Date,8,0) ,
          new ParDef("@COSTONRFFPRODmes",GXType.Int16,4,0) ,
          new ParDef("@COSTONRFFPRODano",GXType.Int16,4,0) ,
          new ParDef("@COSTONRFFPRODValoEjec",GXType.Decimal,14,2) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000T13;
          prmT000T13 = new Object[] {
          new ParDef("@COSTONRFFPRODValoEjec",GXType.Decimal,14,2) ,
          new ParDef("@COSTONRFFPRODfec",GXType.Date,8,0) ,
          new ParDef("@COSTONRFFPRODmes",GXType.Int16,4,0) ,
          new ParDef("@COSTONRFFPRODano",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000T14;
          prmT000T14 = new Object[] {
          new ParDef("@COSTONRFFPRODfec",GXType.Date,8,0) ,
          new ParDef("@COSTONRFFPRODmes",GXType.Int16,4,0) ,
          new ParDef("@COSTONRFFPRODano",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000T15;
          prmT000T15 = new Object[] {
          };
          Object[] prmT000T16;
          prmT000T16 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000T17;
          prmT000T17 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("T000T2", "SELECT [COSTONRFFPRODfec], [COSTONRFFPRODmes], [COSTONRFFPRODano], [COSTONRFFPRODValoEjec], [Cod_Area], [IndicadoresCodigo] FROM [COSTONRFFPROD] WITH (UPDLOCK) WHERE [COSTONRFFPRODfec] = @COSTONRFFPRODfec AND [COSTONRFFPRODmes] = @COSTONRFFPRODmes AND [COSTONRFFPRODano] = @COSTONRFFPRODano AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000T3", "SELECT [COSTONRFFPRODfec], [COSTONRFFPRODmes], [COSTONRFFPRODano], [COSTONRFFPRODValoEjec], [Cod_Area], [IndicadoresCodigo] FROM [COSTONRFFPROD] WHERE [COSTONRFFPRODfec] = @COSTONRFFPRODfec AND [COSTONRFFPRODmes] = @COSTONRFFPRODmes AND [COSTONRFFPRODano] = @COSTONRFFPRODano AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000T4", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000T5", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000T6", "SELECT TM1.[COSTONRFFPRODfec], TM1.[COSTONRFFPRODmes], TM1.[COSTONRFFPRODano], TM1.[COSTONRFFPRODValoEjec], TM1.[Cod_Area], TM1.[IndicadoresCodigo] FROM [COSTONRFFPROD] TM1 WHERE TM1.[COSTONRFFPRODfec] = @COSTONRFFPRODfec and TM1.[COSTONRFFPRODmes] = @COSTONRFFPRODmes and TM1.[COSTONRFFPRODano] = @COSTONRFFPRODano and TM1.[Cod_Area] = @Cod_Area and TM1.[IndicadoresCodigo] = @IndicadoresCodigo ORDER BY TM1.[COSTONRFFPRODfec], TM1.[COSTONRFFPRODmes], TM1.[COSTONRFFPRODano], TM1.[Cod_Area], TM1.[IndicadoresCodigo]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000T6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000T7", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000T8", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000T9", "SELECT [COSTONRFFPRODfec], [COSTONRFFPRODmes], [COSTONRFFPRODano], [Cod_Area], [IndicadoresCodigo] FROM [COSTONRFFPROD] WHERE [COSTONRFFPRODfec] = @COSTONRFFPRODfec AND [COSTONRFFPRODmes] = @COSTONRFFPRODmes AND [COSTONRFFPRODano] = @COSTONRFFPRODano AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000T9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000T10", "SELECT TOP 1 [COSTONRFFPRODfec], [COSTONRFFPRODmes], [COSTONRFFPRODano], [Cod_Area], [IndicadoresCodigo] FROM [COSTONRFFPROD] WHERE ( [COSTONRFFPRODfec] > @COSTONRFFPRODfec or [COSTONRFFPRODfec] = @COSTONRFFPRODfec and [COSTONRFFPRODmes] > @COSTONRFFPRODmes or [COSTONRFFPRODmes] = @COSTONRFFPRODmes and [COSTONRFFPRODfec] = @COSTONRFFPRODfec and [COSTONRFFPRODano] > @COSTONRFFPRODano or [COSTONRFFPRODano] = @COSTONRFFPRODano and [COSTONRFFPRODmes] = @COSTONRFFPRODmes and [COSTONRFFPRODfec] = @COSTONRFFPRODfec and [Cod_Area] > @Cod_Area or [Cod_Area] = @Cod_Area and [COSTONRFFPRODano] = @COSTONRFFPRODano and [COSTONRFFPRODmes] = @COSTONRFFPRODmes and [COSTONRFFPRODfec] = @COSTONRFFPRODfec and [IndicadoresCodigo] > @IndicadoresCodigo) ORDER BY [COSTONRFFPRODfec], [COSTONRFFPRODmes], [COSTONRFFPRODano], [Cod_Area], [IndicadoresCodigo]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000T10,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000T11", "SELECT TOP 1 [COSTONRFFPRODfec], [COSTONRFFPRODmes], [COSTONRFFPRODano], [Cod_Area], [IndicadoresCodigo] FROM [COSTONRFFPROD] WHERE ( [COSTONRFFPRODfec] < @COSTONRFFPRODfec or [COSTONRFFPRODfec] = @COSTONRFFPRODfec and [COSTONRFFPRODmes] < @COSTONRFFPRODmes or [COSTONRFFPRODmes] = @COSTONRFFPRODmes and [COSTONRFFPRODfec] = @COSTONRFFPRODfec and [COSTONRFFPRODano] < @COSTONRFFPRODano or [COSTONRFFPRODano] = @COSTONRFFPRODano and [COSTONRFFPRODmes] = @COSTONRFFPRODmes and [COSTONRFFPRODfec] = @COSTONRFFPRODfec and [Cod_Area] < @Cod_Area or [Cod_Area] = @Cod_Area and [COSTONRFFPRODano] = @COSTONRFFPRODano and [COSTONRFFPRODmes] = @COSTONRFFPRODmes and [COSTONRFFPRODfec] = @COSTONRFFPRODfec and [IndicadoresCodigo] < @IndicadoresCodigo) ORDER BY [COSTONRFFPRODfec] DESC, [COSTONRFFPRODmes] DESC, [COSTONRFFPRODano] DESC, [Cod_Area] DESC, [IndicadoresCodigo] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000T11,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000T12", "INSERT INTO [COSTONRFFPROD]([COSTONRFFPRODfec], [COSTONRFFPRODmes], [COSTONRFFPRODano], [COSTONRFFPRODValoEjec], [Cod_Area], [IndicadoresCodigo]) VALUES(@COSTONRFFPRODfec, @COSTONRFFPRODmes, @COSTONRFFPRODano, @COSTONRFFPRODValoEjec, @Cod_Area, @IndicadoresCodigo)", GxErrorMask.GX_NOMASK,prmT000T12)
             ,new CursorDef("T000T13", "UPDATE [COSTONRFFPROD] SET [COSTONRFFPRODValoEjec]=@COSTONRFFPRODValoEjec  WHERE [COSTONRFFPRODfec] = @COSTONRFFPRODfec AND [COSTONRFFPRODmes] = @COSTONRFFPRODmes AND [COSTONRFFPRODano] = @COSTONRFFPRODano AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo", GxErrorMask.GX_NOMASK,prmT000T13)
             ,new CursorDef("T000T14", "DELETE FROM [COSTONRFFPROD]  WHERE [COSTONRFFPRODfec] = @COSTONRFFPRODfec AND [COSTONRFFPRODmes] = @COSTONRFFPRODmes AND [COSTONRFFPRODano] = @COSTONRFFPRODano AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo", GxErrorMask.GX_NOMASK,prmT000T14)
             ,new CursorDef("T000T15", "SELECT [COSTONRFFPRODfec], [COSTONRFFPRODmes], [COSTONRFFPRODano], [Cod_Area], [IndicadoresCodigo] FROM [COSTONRFFPROD] ORDER BY [COSTONRFFPRODfec], [COSTONRFFPRODmes], [COSTONRFFPRODano], [Cod_Area], [IndicadoresCodigo]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000T15,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000T16", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T16,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000T17", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T17,1, GxCacheFrequency.OFF ,true,false )
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
