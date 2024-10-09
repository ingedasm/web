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
   public class costotonrffprodu : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A65MOTIVOTONRFFcod = GetPar( "MOTIVOTONRFFcod");
            AssignAttri("", false, "A65MOTIVOTONRFFcod", A65MOTIVOTONRFFcod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A65MOTIVOTONRFFcod) ;
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
            Form.Meta.addItem("description", "COSTOTONRFFPRODU", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCOSTOTONRFFPRODUFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("IndicadroresPalmas", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public costotonrffprodu( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("IndicadroresPalmas", true);
      }

      public costotonrffprodu( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "COSTOTONRFFPRODU", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_COSTOTONRFFPRODU.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSTOTONRFFPRODU.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSTOTONRFFPRODU.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSTOTONRFFPRODU.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSTOTONRFFPRODU.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 4, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx0110.aspx"+"',["+"{Ctrl:gx.dom.el('"+"COSTOTONRFFPRODUFECHA"+"'), id:'"+"COSTOTONRFFPRODUFECHA"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"COSTOTONRFFPRODUMES"+"'), id:'"+"COSTOTONRFFPRODUMES"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"COSTOTONRFFPRODUANO"+"'), id:'"+"COSTOTONRFFPRODUANO"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"COD_AREA"+"'), id:'"+"COD_AREA"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"INDICADORESCODIGO"+"'), id:'"+"INDICADORESCODIGO"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"MOTIVOTONRFFCOD"+"'), id:'"+"MOTIVOTONRFFCOD"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_COSTOTONRFFPRODU.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCOSTOTONRFFPRODUFecha_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCOSTOTONRFFPRODUFecha_Internalname, "COSTOTONRFFPRODUFecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCOSTOTONRFFPRODUFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCOSTOTONRFFPRODUFecha_Internalname, context.localUtil.Format(A77COSTOTONRFFPRODUFecha, "99/99/99"), context.localUtil.Format( A77COSTOTONRFFPRODUFecha, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCOSTOTONRFFPRODUFecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCOSTOTONRFFPRODUFecha_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_COSTOTONRFFPRODU.htm");
         GxWebStd.gx_bitmap( context, edtCOSTOTONRFFPRODUFecha_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCOSTOTONRFFPRODUFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_COSTOTONRFFPRODU.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCOSTOTONRFFPRODUMes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCOSTOTONRFFPRODUMes_Internalname, "COSTOTONRFFPRODUMes", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCOSTOTONRFFPRODUMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A78COSTOTONRFFPRODUMes), 4, 0, ",", "")), StringUtil.LTrim( ((edtCOSTOTONRFFPRODUMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A78COSTOTONRFFPRODUMes), "ZZZ9") : context.localUtil.Format( (decimal)(A78COSTOTONRFFPRODUMes), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCOSTOTONRFFPRODUMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCOSTOTONRFFPRODUMes_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_COSTOTONRFFPRODU.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCOSTOTONRFFPRODUAno_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCOSTOTONRFFPRODUAno_Internalname, "COSTOTONRFFPRODUAno", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCOSTOTONRFFPRODUAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A79COSTOTONRFFPRODUAno), 4, 0, ",", "")), StringUtil.LTrim( ((edtCOSTOTONRFFPRODUAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A79COSTOTONRFFPRODUAno), "ZZZ9") : context.localUtil.Format( (decimal)(A79COSTOTONRFFPRODUAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCOSTOTONRFFPRODUAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCOSTOTONRFFPRODUAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_COSTOTONRFFPRODU.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCod_Area_Internalname, A5Cod_Area, StringUtil.RTrim( context.localUtil.Format( A5Cod_Area, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCod_Area_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCod_Area_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_COSTOTONRFFPRODU.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_5_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_5_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_5_Internalname, sImgUrl, imgprompt_5_Link, "", "", context.GetTheme( ), imgprompt_5_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_COSTOTONRFFPRODU.htm");
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
         GxWebStd.gx_single_line_edit( context, edtIndicadoresCodigo_Internalname, A4IndicadoresCodigo, StringUtil.RTrim( context.localUtil.Format( A4IndicadoresCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIndicadoresCodigo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIndicadoresCodigo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_COSTOTONRFFPRODU.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_4_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_4_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_4_Internalname, sImgUrl, imgprompt_4_Link, "", "", context.GetTheme( ), imgprompt_4_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_COSTOTONRFFPRODU.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMOTIVOTONRFFcod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMOTIVOTONRFFcod_Internalname, "MOTIVOTONRFFcod", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMOTIVOTONRFFcod_Internalname, A65MOTIVOTONRFFcod, StringUtil.RTrim( context.localUtil.Format( A65MOTIVOTONRFFcod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMOTIVOTONRFFcod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMOTIVOTONRFFcod_Enabled, 0, "text", "", 80, "chr", 1, "row", 140, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_COSTOTONRFFPRODU.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_65_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_65_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_65_Internalname, sImgUrl, imgprompt_65_Link, "", "", context.GetTheme( ), imgprompt_65_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_COSTOTONRFFPRODU.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCOSTOTONRFFPRODUValor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCOSTOTONRFFPRODUValor_Internalname, "COSTOTONRFFPRODUValor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCOSTOTONRFFPRODUValor_Internalname, StringUtil.LTrim( StringUtil.NToC( A196COSTOTONRFFPRODUValor, 16, 2, ",", "")), StringUtil.LTrim( ((edtCOSTOTONRFFPRODUValor_Enabled!=0) ? context.localUtil.Format( A196COSTOTONRFFPRODUValor, "ZZZZZZZZZZZZ9.99") : context.localUtil.Format( A196COSTOTONRFFPRODUValor, "ZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCOSTOTONRFFPRODUValor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCOSTOTONRFFPRODUValor_Enabled, 0, "text", "", 16, "chr", 1, "row", 16, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_COSTOTONRFFPRODU.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSTOTONRFFPRODU.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSTOTONRFFPRODU.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSTOTONRFFPRODU.htm");
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
            Z77COSTOTONRFFPRODUFecha = context.localUtil.CToD( cgiGet( "Z77COSTOTONRFFPRODUFecha"), 0);
            Z78COSTOTONRFFPRODUMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z78COSTOTONRFFPRODUMes"), ",", "."), 18, MidpointRounding.ToEven));
            Z79COSTOTONRFFPRODUAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z79COSTOTONRFFPRODUAno"), ",", "."), 18, MidpointRounding.ToEven));
            Z5Cod_Area = cgiGet( "Z5Cod_Area");
            Z4IndicadoresCodigo = cgiGet( "Z4IndicadoresCodigo");
            Z65MOTIVOTONRFFcod = cgiGet( "Z65MOTIVOTONRFFcod");
            Z196COSTOTONRFFPRODUValor = context.localUtil.CToN( cgiGet( "Z196COSTOTONRFFPRODUValor"), ",", ".");
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( context.localUtil.VCDate( cgiGet( edtCOSTOTONRFFPRODUFecha_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"COSTOTONRFFPRODUFecha"}), 1, "COSTOTONRFFPRODUFECHA");
               AnyError = 1;
               GX_FocusControl = edtCOSTOTONRFFPRODUFecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A77COSTOTONRFFPRODUFecha = DateTime.MinValue;
               AssignAttri("", false, "A77COSTOTONRFFPRODUFecha", context.localUtil.Format(A77COSTOTONRFFPRODUFecha, "99/99/99"));
            }
            else
            {
               A77COSTOTONRFFPRODUFecha = context.localUtil.CToD( cgiGet( edtCOSTOTONRFFPRODUFecha_Internalname), 2);
               AssignAttri("", false, "A77COSTOTONRFFPRODUFecha", context.localUtil.Format(A77COSTOTONRFFPRODUFecha, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCOSTOTONRFFPRODUMes_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCOSTOTONRFFPRODUMes_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COSTOTONRFFPRODUMES");
               AnyError = 1;
               GX_FocusControl = edtCOSTOTONRFFPRODUMes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A78COSTOTONRFFPRODUMes = 0;
               AssignAttri("", false, "A78COSTOTONRFFPRODUMes", StringUtil.LTrimStr( (decimal)(A78COSTOTONRFFPRODUMes), 4, 0));
            }
            else
            {
               A78COSTOTONRFFPRODUMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCOSTOTONRFFPRODUMes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A78COSTOTONRFFPRODUMes", StringUtil.LTrimStr( (decimal)(A78COSTOTONRFFPRODUMes), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCOSTOTONRFFPRODUAno_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCOSTOTONRFFPRODUAno_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COSTOTONRFFPRODUANO");
               AnyError = 1;
               GX_FocusControl = edtCOSTOTONRFFPRODUAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A79COSTOTONRFFPRODUAno = 0;
               AssignAttri("", false, "A79COSTOTONRFFPRODUAno", StringUtil.LTrimStr( (decimal)(A79COSTOTONRFFPRODUAno), 4, 0));
            }
            else
            {
               A79COSTOTONRFFPRODUAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCOSTOTONRFFPRODUAno_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A79COSTOTONRFFPRODUAno", StringUtil.LTrimStr( (decimal)(A79COSTOTONRFFPRODUAno), 4, 0));
            }
            A5Cod_Area = cgiGet( edtCod_Area_Internalname);
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = cgiGet( edtIndicadoresCodigo_Internalname);
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A65MOTIVOTONRFFcod = cgiGet( edtMOTIVOTONRFFcod_Internalname);
            AssignAttri("", false, "A65MOTIVOTONRFFcod", A65MOTIVOTONRFFcod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCOSTOTONRFFPRODUValor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCOSTOTONRFFPRODUValor_Internalname), ",", ".") > 9999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COSTOTONRFFPRODUVALOR");
               AnyError = 1;
               GX_FocusControl = edtCOSTOTONRFFPRODUValor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A196COSTOTONRFFPRODUValor = 0;
               AssignAttri("", false, "A196COSTOTONRFFPRODUValor", StringUtil.LTrimStr( A196COSTOTONRFFPRODUValor, 16, 2));
            }
            else
            {
               A196COSTOTONRFFPRODUValor = context.localUtil.CToN( cgiGet( edtCOSTOTONRFFPRODUValor_Internalname), ",", ".");
               AssignAttri("", false, "A196COSTOTONRFFPRODUValor", StringUtil.LTrimStr( A196COSTOTONRFFPRODUValor, 16, 2));
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
               A77COSTOTONRFFPRODUFecha = context.localUtil.ParseDateParm( GetPar( "COSTOTONRFFPRODUFecha"));
               AssignAttri("", false, "A77COSTOTONRFFPRODUFecha", context.localUtil.Format(A77COSTOTONRFFPRODUFecha, "99/99/99"));
               A78COSTOTONRFFPRODUMes = (short)(Math.Round(NumberUtil.Val( GetPar( "COSTOTONRFFPRODUMes"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A78COSTOTONRFFPRODUMes", StringUtil.LTrimStr( (decimal)(A78COSTOTONRFFPRODUMes), 4, 0));
               A79COSTOTONRFFPRODUAno = (short)(Math.Round(NumberUtil.Val( GetPar( "COSTOTONRFFPRODUAno"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A79COSTOTONRFFPRODUAno", StringUtil.LTrimStr( (decimal)(A79COSTOTONRFFPRODUAno), 4, 0));
               A5Cod_Area = GetPar( "Cod_Area");
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               A4IndicadoresCodigo = GetPar( "IndicadoresCodigo");
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               A65MOTIVOTONRFFcod = GetPar( "MOTIVOTONRFFcod");
               AssignAttri("", false, "A65MOTIVOTONRFFcod", A65MOTIVOTONRFFcod);
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
               InitAll1037( ) ;
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
         DisableAttributes1037( ) ;
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

      protected void ResetCaption100( )
      {
      }

      protected void ZM1037( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z196COSTOTONRFFPRODUValor = T00103_A196COSTOTONRFFPRODUValor[0];
            }
            else
            {
               Z196COSTOTONRFFPRODUValor = A196COSTOTONRFFPRODUValor;
            }
         }
         if ( GX_JID == -2 )
         {
            Z77COSTOTONRFFPRODUFecha = A77COSTOTONRFFPRODUFecha;
            Z78COSTOTONRFFPRODUMes = A78COSTOTONRFFPRODUMes;
            Z79COSTOTONRFFPRODUAno = A79COSTOTONRFFPRODUAno;
            Z196COSTOTONRFFPRODUValor = A196COSTOTONRFFPRODUValor;
            Z5Cod_Area = A5Cod_Area;
            Z4IndicadoresCodigo = A4IndicadoresCodigo;
            Z65MOTIVOTONRFFcod = A65MOTIVOTONRFFcod;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_5_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"COD_AREA"+"'), id:'"+"COD_AREA"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"true"+");");
         imgprompt_4_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0030.aspx"+"',["+"{Ctrl:gx.dom.el('"+"INDICADORESCODIGO"+"'), id:'"+"INDICADORESCODIGO"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"true"+");");
         imgprompt_65_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0100.aspx"+"',["+"{Ctrl:gx.dom.el('"+"MOTIVOTONRFFCOD"+"'), id:'"+"MOTIVOTONRFFCOD"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");");
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

      protected void Load1037( )
      {
         /* Using cursor T00107 */
         pr_default.execute(5, new Object[] {A77COSTOTONRFFPRODUFecha, A78COSTOTONRFFPRODUMes, A79COSTOTONRFFPRODUAno, A5Cod_Area, A4IndicadoresCodigo, A65MOTIVOTONRFFcod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound37 = 1;
            A196COSTOTONRFFPRODUValor = T00107_A196COSTOTONRFFPRODUValor[0];
            AssignAttri("", false, "A196COSTOTONRFFPRODUValor", StringUtil.LTrimStr( A196COSTOTONRFFPRODUValor, 16, 2));
            ZM1037( -2) ;
         }
         pr_default.close(5);
         OnLoadActions1037( ) ;
      }

      protected void OnLoadActions1037( )
      {
      }

      protected void CheckExtendedTable1037( )
      {
         nIsDirty_37 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A77COSTOTONRFFPRODUFecha) || ( DateTimeUtil.ResetTime ( A77COSTOTONRFFPRODUFecha ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo COSTOTONRFFPRODUFecha fuera de rango", "OutOfRange", 1, "COSTOTONRFFPRODUFECHA");
            AnyError = 1;
            GX_FocusControl = edtCOSTOTONRFFPRODUFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00104 */
         pr_default.execute(2, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T00105 */
         pr_default.execute(3, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         /* Using cursor T00106 */
         pr_default.execute(4, new Object[] {A65MOTIVOTONRFFcod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'MOTIVOTONRFF'.", "ForeignKeyNotFound", 1, "MOTIVOTONRFFCOD");
            AnyError = 1;
            GX_FocusControl = edtMOTIVOTONRFFcod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors1037( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( string A5Cod_Area )
      {
         /* Using cursor T00108 */
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

      protected void gxLoad_4( string A4IndicadoresCodigo )
      {
         /* Using cursor T00109 */
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

      protected void gxLoad_5( string A65MOTIVOTONRFFcod )
      {
         /* Using cursor T001010 */
         pr_default.execute(8, new Object[] {A65MOTIVOTONRFFcod});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'MOTIVOTONRFF'.", "ForeignKeyNotFound", 1, "MOTIVOTONRFFCOD");
            AnyError = 1;
            GX_FocusControl = edtMOTIVOTONRFFcod_Internalname;
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

      protected void GetKey1037( )
      {
         /* Using cursor T001011 */
         pr_default.execute(9, new Object[] {A77COSTOTONRFFPRODUFecha, A78COSTOTONRFFPRODUMes, A79COSTOTONRFFPRODUAno, A5Cod_Area, A4IndicadoresCodigo, A65MOTIVOTONRFFcod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound37 = 1;
         }
         else
         {
            RcdFound37 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00103 */
         pr_default.execute(1, new Object[] {A77COSTOTONRFFPRODUFecha, A78COSTOTONRFFPRODUMes, A79COSTOTONRFFPRODUAno, A5Cod_Area, A4IndicadoresCodigo, A65MOTIVOTONRFFcod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1037( 2) ;
            RcdFound37 = 1;
            A77COSTOTONRFFPRODUFecha = T00103_A77COSTOTONRFFPRODUFecha[0];
            AssignAttri("", false, "A77COSTOTONRFFPRODUFecha", context.localUtil.Format(A77COSTOTONRFFPRODUFecha, "99/99/99"));
            A78COSTOTONRFFPRODUMes = T00103_A78COSTOTONRFFPRODUMes[0];
            AssignAttri("", false, "A78COSTOTONRFFPRODUMes", StringUtil.LTrimStr( (decimal)(A78COSTOTONRFFPRODUMes), 4, 0));
            A79COSTOTONRFFPRODUAno = T00103_A79COSTOTONRFFPRODUAno[0];
            AssignAttri("", false, "A79COSTOTONRFFPRODUAno", StringUtil.LTrimStr( (decimal)(A79COSTOTONRFFPRODUAno), 4, 0));
            A196COSTOTONRFFPRODUValor = T00103_A196COSTOTONRFFPRODUValor[0];
            AssignAttri("", false, "A196COSTOTONRFFPRODUValor", StringUtil.LTrimStr( A196COSTOTONRFFPRODUValor, 16, 2));
            A5Cod_Area = T00103_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = T00103_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A65MOTIVOTONRFFcod = T00103_A65MOTIVOTONRFFcod[0];
            AssignAttri("", false, "A65MOTIVOTONRFFcod", A65MOTIVOTONRFFcod);
            Z77COSTOTONRFFPRODUFecha = A77COSTOTONRFFPRODUFecha;
            Z78COSTOTONRFFPRODUMes = A78COSTOTONRFFPRODUMes;
            Z79COSTOTONRFFPRODUAno = A79COSTOTONRFFPRODUAno;
            Z5Cod_Area = A5Cod_Area;
            Z4IndicadoresCodigo = A4IndicadoresCodigo;
            Z65MOTIVOTONRFFcod = A65MOTIVOTONRFFcod;
            sMode37 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1037( ) ;
            if ( AnyError == 1 )
            {
               RcdFound37 = 0;
               InitializeNonKey1037( ) ;
            }
            Gx_mode = sMode37;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound37 = 0;
            InitializeNonKey1037( ) ;
            sMode37 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode37;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1037( ) ;
         if ( RcdFound37 == 0 )
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
         RcdFound37 = 0;
         /* Using cursor T001012 */
         pr_default.execute(10, new Object[] {A77COSTOTONRFFPRODUFecha, A78COSTOTONRFFPRODUMes, A79COSTOTONRFFPRODUAno, A5Cod_Area, A4IndicadoresCodigo, A65MOTIVOTONRFFcod});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( DateTimeUtil.ResetTime ( T001012_A77COSTOTONRFFPRODUFecha[0] ) < DateTimeUtil.ResetTime ( A77COSTOTONRFFPRODUFecha ) ) || ( DateTimeUtil.ResetTime ( T001012_A77COSTOTONRFFPRODUFecha[0] ) == DateTimeUtil.ResetTime ( A77COSTOTONRFFPRODUFecha ) ) && ( T001012_A78COSTOTONRFFPRODUMes[0] < A78COSTOTONRFFPRODUMes ) || ( T001012_A78COSTOTONRFFPRODUMes[0] == A78COSTOTONRFFPRODUMes ) && ( DateTimeUtil.ResetTime ( T001012_A77COSTOTONRFFPRODUFecha[0] ) == DateTimeUtil.ResetTime ( A77COSTOTONRFFPRODUFecha ) ) && ( T001012_A79COSTOTONRFFPRODUAno[0] < A79COSTOTONRFFPRODUAno ) || ( T001012_A79COSTOTONRFFPRODUAno[0] == A79COSTOTONRFFPRODUAno ) && ( T001012_A78COSTOTONRFFPRODUMes[0] == A78COSTOTONRFFPRODUMes ) && ( DateTimeUtil.ResetTime ( T001012_A77COSTOTONRFFPRODUFecha[0] ) == DateTimeUtil.ResetTime ( A77COSTOTONRFFPRODUFecha ) ) && ( StringUtil.StrCmp(T001012_A5Cod_Area[0], A5Cod_Area) < 0 ) || ( StringUtil.StrCmp(T001012_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T001012_A79COSTOTONRFFPRODUAno[0] == A79COSTOTONRFFPRODUAno ) && ( T001012_A78COSTOTONRFFPRODUMes[0] == A78COSTOTONRFFPRODUMes ) && ( DateTimeUtil.ResetTime ( T001012_A77COSTOTONRFFPRODUFecha[0] ) == DateTimeUtil.ResetTime ( A77COSTOTONRFFPRODUFecha ) ) && ( StringUtil.StrCmp(T001012_A4IndicadoresCodigo[0], A4IndicadoresCodigo) < 0 ) || ( StringUtil.StrCmp(T001012_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T001012_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T001012_A79COSTOTONRFFPRODUAno[0] == A79COSTOTONRFFPRODUAno ) && ( T001012_A78COSTOTONRFFPRODUMes[0] == A78COSTOTONRFFPRODUMes ) && ( DateTimeUtil.ResetTime ( T001012_A77COSTOTONRFFPRODUFecha[0] ) == DateTimeUtil.ResetTime ( A77COSTOTONRFFPRODUFecha ) ) && ( StringUtil.StrCmp(T001012_A65MOTIVOTONRFFcod[0], A65MOTIVOTONRFFcod) < 0 ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( DateTimeUtil.ResetTime ( T001012_A77COSTOTONRFFPRODUFecha[0] ) > DateTimeUtil.ResetTime ( A77COSTOTONRFFPRODUFecha ) ) || ( DateTimeUtil.ResetTime ( T001012_A77COSTOTONRFFPRODUFecha[0] ) == DateTimeUtil.ResetTime ( A77COSTOTONRFFPRODUFecha ) ) && ( T001012_A78COSTOTONRFFPRODUMes[0] > A78COSTOTONRFFPRODUMes ) || ( T001012_A78COSTOTONRFFPRODUMes[0] == A78COSTOTONRFFPRODUMes ) && ( DateTimeUtil.ResetTime ( T001012_A77COSTOTONRFFPRODUFecha[0] ) == DateTimeUtil.ResetTime ( A77COSTOTONRFFPRODUFecha ) ) && ( T001012_A79COSTOTONRFFPRODUAno[0] > A79COSTOTONRFFPRODUAno ) || ( T001012_A79COSTOTONRFFPRODUAno[0] == A79COSTOTONRFFPRODUAno ) && ( T001012_A78COSTOTONRFFPRODUMes[0] == A78COSTOTONRFFPRODUMes ) && ( DateTimeUtil.ResetTime ( T001012_A77COSTOTONRFFPRODUFecha[0] ) == DateTimeUtil.ResetTime ( A77COSTOTONRFFPRODUFecha ) ) && ( StringUtil.StrCmp(T001012_A5Cod_Area[0], A5Cod_Area) > 0 ) || ( StringUtil.StrCmp(T001012_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T001012_A79COSTOTONRFFPRODUAno[0] == A79COSTOTONRFFPRODUAno ) && ( T001012_A78COSTOTONRFFPRODUMes[0] == A78COSTOTONRFFPRODUMes ) && ( DateTimeUtil.ResetTime ( T001012_A77COSTOTONRFFPRODUFecha[0] ) == DateTimeUtil.ResetTime ( A77COSTOTONRFFPRODUFecha ) ) && ( StringUtil.StrCmp(T001012_A4IndicadoresCodigo[0], A4IndicadoresCodigo) > 0 ) || ( StringUtil.StrCmp(T001012_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T001012_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T001012_A79COSTOTONRFFPRODUAno[0] == A79COSTOTONRFFPRODUAno ) && ( T001012_A78COSTOTONRFFPRODUMes[0] == A78COSTOTONRFFPRODUMes ) && ( DateTimeUtil.ResetTime ( T001012_A77COSTOTONRFFPRODUFecha[0] ) == DateTimeUtil.ResetTime ( A77COSTOTONRFFPRODUFecha ) ) && ( StringUtil.StrCmp(T001012_A65MOTIVOTONRFFcod[0], A65MOTIVOTONRFFcod) > 0 ) ) )
            {
               A77COSTOTONRFFPRODUFecha = T001012_A77COSTOTONRFFPRODUFecha[0];
               AssignAttri("", false, "A77COSTOTONRFFPRODUFecha", context.localUtil.Format(A77COSTOTONRFFPRODUFecha, "99/99/99"));
               A78COSTOTONRFFPRODUMes = T001012_A78COSTOTONRFFPRODUMes[0];
               AssignAttri("", false, "A78COSTOTONRFFPRODUMes", StringUtil.LTrimStr( (decimal)(A78COSTOTONRFFPRODUMes), 4, 0));
               A79COSTOTONRFFPRODUAno = T001012_A79COSTOTONRFFPRODUAno[0];
               AssignAttri("", false, "A79COSTOTONRFFPRODUAno", StringUtil.LTrimStr( (decimal)(A79COSTOTONRFFPRODUAno), 4, 0));
               A5Cod_Area = T001012_A5Cod_Area[0];
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               A4IndicadoresCodigo = T001012_A4IndicadoresCodigo[0];
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               A65MOTIVOTONRFFcod = T001012_A65MOTIVOTONRFFcod[0];
               AssignAttri("", false, "A65MOTIVOTONRFFcod", A65MOTIVOTONRFFcod);
               RcdFound37 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound37 = 0;
         /* Using cursor T001013 */
         pr_default.execute(11, new Object[] {A77COSTOTONRFFPRODUFecha, A78COSTOTONRFFPRODUMes, A79COSTOTONRFFPRODUAno, A5Cod_Area, A4IndicadoresCodigo, A65MOTIVOTONRFFcod});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( DateTimeUtil.ResetTime ( T001013_A77COSTOTONRFFPRODUFecha[0] ) > DateTimeUtil.ResetTime ( A77COSTOTONRFFPRODUFecha ) ) || ( DateTimeUtil.ResetTime ( T001013_A77COSTOTONRFFPRODUFecha[0] ) == DateTimeUtil.ResetTime ( A77COSTOTONRFFPRODUFecha ) ) && ( T001013_A78COSTOTONRFFPRODUMes[0] > A78COSTOTONRFFPRODUMes ) || ( T001013_A78COSTOTONRFFPRODUMes[0] == A78COSTOTONRFFPRODUMes ) && ( DateTimeUtil.ResetTime ( T001013_A77COSTOTONRFFPRODUFecha[0] ) == DateTimeUtil.ResetTime ( A77COSTOTONRFFPRODUFecha ) ) && ( T001013_A79COSTOTONRFFPRODUAno[0] > A79COSTOTONRFFPRODUAno ) || ( T001013_A79COSTOTONRFFPRODUAno[0] == A79COSTOTONRFFPRODUAno ) && ( T001013_A78COSTOTONRFFPRODUMes[0] == A78COSTOTONRFFPRODUMes ) && ( DateTimeUtil.ResetTime ( T001013_A77COSTOTONRFFPRODUFecha[0] ) == DateTimeUtil.ResetTime ( A77COSTOTONRFFPRODUFecha ) ) && ( StringUtil.StrCmp(T001013_A5Cod_Area[0], A5Cod_Area) > 0 ) || ( StringUtil.StrCmp(T001013_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T001013_A79COSTOTONRFFPRODUAno[0] == A79COSTOTONRFFPRODUAno ) && ( T001013_A78COSTOTONRFFPRODUMes[0] == A78COSTOTONRFFPRODUMes ) && ( DateTimeUtil.ResetTime ( T001013_A77COSTOTONRFFPRODUFecha[0] ) == DateTimeUtil.ResetTime ( A77COSTOTONRFFPRODUFecha ) ) && ( StringUtil.StrCmp(T001013_A4IndicadoresCodigo[0], A4IndicadoresCodigo) > 0 ) || ( StringUtil.StrCmp(T001013_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T001013_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T001013_A79COSTOTONRFFPRODUAno[0] == A79COSTOTONRFFPRODUAno ) && ( T001013_A78COSTOTONRFFPRODUMes[0] == A78COSTOTONRFFPRODUMes ) && ( DateTimeUtil.ResetTime ( T001013_A77COSTOTONRFFPRODUFecha[0] ) == DateTimeUtil.ResetTime ( A77COSTOTONRFFPRODUFecha ) ) && ( StringUtil.StrCmp(T001013_A65MOTIVOTONRFFcod[0], A65MOTIVOTONRFFcod) > 0 ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( DateTimeUtil.ResetTime ( T001013_A77COSTOTONRFFPRODUFecha[0] ) < DateTimeUtil.ResetTime ( A77COSTOTONRFFPRODUFecha ) ) || ( DateTimeUtil.ResetTime ( T001013_A77COSTOTONRFFPRODUFecha[0] ) == DateTimeUtil.ResetTime ( A77COSTOTONRFFPRODUFecha ) ) && ( T001013_A78COSTOTONRFFPRODUMes[0] < A78COSTOTONRFFPRODUMes ) || ( T001013_A78COSTOTONRFFPRODUMes[0] == A78COSTOTONRFFPRODUMes ) && ( DateTimeUtil.ResetTime ( T001013_A77COSTOTONRFFPRODUFecha[0] ) == DateTimeUtil.ResetTime ( A77COSTOTONRFFPRODUFecha ) ) && ( T001013_A79COSTOTONRFFPRODUAno[0] < A79COSTOTONRFFPRODUAno ) || ( T001013_A79COSTOTONRFFPRODUAno[0] == A79COSTOTONRFFPRODUAno ) && ( T001013_A78COSTOTONRFFPRODUMes[0] == A78COSTOTONRFFPRODUMes ) && ( DateTimeUtil.ResetTime ( T001013_A77COSTOTONRFFPRODUFecha[0] ) == DateTimeUtil.ResetTime ( A77COSTOTONRFFPRODUFecha ) ) && ( StringUtil.StrCmp(T001013_A5Cod_Area[0], A5Cod_Area) < 0 ) || ( StringUtil.StrCmp(T001013_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T001013_A79COSTOTONRFFPRODUAno[0] == A79COSTOTONRFFPRODUAno ) && ( T001013_A78COSTOTONRFFPRODUMes[0] == A78COSTOTONRFFPRODUMes ) && ( DateTimeUtil.ResetTime ( T001013_A77COSTOTONRFFPRODUFecha[0] ) == DateTimeUtil.ResetTime ( A77COSTOTONRFFPRODUFecha ) ) && ( StringUtil.StrCmp(T001013_A4IndicadoresCodigo[0], A4IndicadoresCodigo) < 0 ) || ( StringUtil.StrCmp(T001013_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T001013_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T001013_A79COSTOTONRFFPRODUAno[0] == A79COSTOTONRFFPRODUAno ) && ( T001013_A78COSTOTONRFFPRODUMes[0] == A78COSTOTONRFFPRODUMes ) && ( DateTimeUtil.ResetTime ( T001013_A77COSTOTONRFFPRODUFecha[0] ) == DateTimeUtil.ResetTime ( A77COSTOTONRFFPRODUFecha ) ) && ( StringUtil.StrCmp(T001013_A65MOTIVOTONRFFcod[0], A65MOTIVOTONRFFcod) < 0 ) ) )
            {
               A77COSTOTONRFFPRODUFecha = T001013_A77COSTOTONRFFPRODUFecha[0];
               AssignAttri("", false, "A77COSTOTONRFFPRODUFecha", context.localUtil.Format(A77COSTOTONRFFPRODUFecha, "99/99/99"));
               A78COSTOTONRFFPRODUMes = T001013_A78COSTOTONRFFPRODUMes[0];
               AssignAttri("", false, "A78COSTOTONRFFPRODUMes", StringUtil.LTrimStr( (decimal)(A78COSTOTONRFFPRODUMes), 4, 0));
               A79COSTOTONRFFPRODUAno = T001013_A79COSTOTONRFFPRODUAno[0];
               AssignAttri("", false, "A79COSTOTONRFFPRODUAno", StringUtil.LTrimStr( (decimal)(A79COSTOTONRFFPRODUAno), 4, 0));
               A5Cod_Area = T001013_A5Cod_Area[0];
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               A4IndicadoresCodigo = T001013_A4IndicadoresCodigo[0];
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               A65MOTIVOTONRFFcod = T001013_A65MOTIVOTONRFFcod[0];
               AssignAttri("", false, "A65MOTIVOTONRFFcod", A65MOTIVOTONRFFcod);
               RcdFound37 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1037( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCOSTOTONRFFPRODUFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1037( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound37 == 1 )
            {
               if ( ( DateTimeUtil.ResetTime ( A77COSTOTONRFFPRODUFecha ) != DateTimeUtil.ResetTime ( Z77COSTOTONRFFPRODUFecha ) ) || ( A78COSTOTONRFFPRODUMes != Z78COSTOTONRFFPRODUMes ) || ( A79COSTOTONRFFPRODUAno != Z79COSTOTONRFFPRODUAno ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) || ( StringUtil.StrCmp(A65MOTIVOTONRFFcod, Z65MOTIVOTONRFFcod) != 0 ) )
               {
                  A77COSTOTONRFFPRODUFecha = Z77COSTOTONRFFPRODUFecha;
                  AssignAttri("", false, "A77COSTOTONRFFPRODUFecha", context.localUtil.Format(A77COSTOTONRFFPRODUFecha, "99/99/99"));
                  A78COSTOTONRFFPRODUMes = Z78COSTOTONRFFPRODUMes;
                  AssignAttri("", false, "A78COSTOTONRFFPRODUMes", StringUtil.LTrimStr( (decimal)(A78COSTOTONRFFPRODUMes), 4, 0));
                  A79COSTOTONRFFPRODUAno = Z79COSTOTONRFFPRODUAno;
                  AssignAttri("", false, "A79COSTOTONRFFPRODUAno", StringUtil.LTrimStr( (decimal)(A79COSTOTONRFFPRODUAno), 4, 0));
                  A5Cod_Area = Z5Cod_Area;
                  AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
                  A4IndicadoresCodigo = Z4IndicadoresCodigo;
                  AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
                  A65MOTIVOTONRFFcod = Z65MOTIVOTONRFFcod;
                  AssignAttri("", false, "A65MOTIVOTONRFFcod", A65MOTIVOTONRFFcod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "COSTOTONRFFPRODUFECHA");
                  AnyError = 1;
                  GX_FocusControl = edtCOSTOTONRFFPRODUFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCOSTOTONRFFPRODUFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1037( ) ;
                  GX_FocusControl = edtCOSTOTONRFFPRODUFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( DateTimeUtil.ResetTime ( A77COSTOTONRFFPRODUFecha ) != DateTimeUtil.ResetTime ( Z77COSTOTONRFFPRODUFecha ) ) || ( A78COSTOTONRFFPRODUMes != Z78COSTOTONRFFPRODUMes ) || ( A79COSTOTONRFFPRODUAno != Z79COSTOTONRFFPRODUAno ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) || ( StringUtil.StrCmp(A65MOTIVOTONRFFcod, Z65MOTIVOTONRFFcod) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtCOSTOTONRFFPRODUFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1037( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "COSTOTONRFFPRODUFECHA");
                     AnyError = 1;
                     GX_FocusControl = edtCOSTOTONRFFPRODUFecha_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtCOSTOTONRFFPRODUFecha_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1037( ) ;
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
         if ( ( DateTimeUtil.ResetTime ( A77COSTOTONRFFPRODUFecha ) != DateTimeUtil.ResetTime ( Z77COSTOTONRFFPRODUFecha ) ) || ( A78COSTOTONRFFPRODUMes != Z78COSTOTONRFFPRODUMes ) || ( A79COSTOTONRFFPRODUAno != Z79COSTOTONRFFPRODUAno ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) || ( StringUtil.StrCmp(A65MOTIVOTONRFFcod, Z65MOTIVOTONRFFcod) != 0 ) )
         {
            A77COSTOTONRFFPRODUFecha = Z77COSTOTONRFFPRODUFecha;
            AssignAttri("", false, "A77COSTOTONRFFPRODUFecha", context.localUtil.Format(A77COSTOTONRFFPRODUFecha, "99/99/99"));
            A78COSTOTONRFFPRODUMes = Z78COSTOTONRFFPRODUMes;
            AssignAttri("", false, "A78COSTOTONRFFPRODUMes", StringUtil.LTrimStr( (decimal)(A78COSTOTONRFFPRODUMes), 4, 0));
            A79COSTOTONRFFPRODUAno = Z79COSTOTONRFFPRODUAno;
            AssignAttri("", false, "A79COSTOTONRFFPRODUAno", StringUtil.LTrimStr( (decimal)(A79COSTOTONRFFPRODUAno), 4, 0));
            A5Cod_Area = Z5Cod_Area;
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = Z4IndicadoresCodigo;
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A65MOTIVOTONRFFcod = Z65MOTIVOTONRFFcod;
            AssignAttri("", false, "A65MOTIVOTONRFFcod", A65MOTIVOTONRFFcod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "COSTOTONRFFPRODUFECHA");
            AnyError = 1;
            GX_FocusControl = edtCOSTOTONRFFPRODUFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCOSTOTONRFFPRODUFecha_Internalname;
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
         if ( RcdFound37 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "COSTOTONRFFPRODUFECHA");
            AnyError = 1;
            GX_FocusControl = edtCOSTOTONRFFPRODUFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtCOSTOTONRFFPRODUValor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1037( ) ;
         if ( RcdFound37 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCOSTOTONRFFPRODUValor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1037( ) ;
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
         if ( RcdFound37 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCOSTOTONRFFPRODUValor_Internalname;
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
         if ( RcdFound37 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCOSTOTONRFFPRODUValor_Internalname;
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
         ScanStart1037( ) ;
         if ( RcdFound37 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound37 != 0 )
            {
               ScanNext1037( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCOSTOTONRFFPRODUValor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1037( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1037( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00102 */
            pr_default.execute(0, new Object[] {A77COSTOTONRFFPRODUFecha, A78COSTOTONRFFPRODUMes, A79COSTOTONRFFPRODUAno, A5Cod_Area, A4IndicadoresCodigo, A65MOTIVOTONRFFcod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"COSTOTONRFFPRODU"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z196COSTOTONRFFPRODUValor != T00102_A196COSTOTONRFFPRODUValor[0] ) )
            {
               if ( Z196COSTOTONRFFPRODUValor != T00102_A196COSTOTONRFFPRODUValor[0] )
               {
                  GXUtil.WriteLog("costotonrffprodu:[seudo value changed for attri]"+"COSTOTONRFFPRODUValor");
                  GXUtil.WriteLogRaw("Old: ",Z196COSTOTONRFFPRODUValor);
                  GXUtil.WriteLogRaw("Current: ",T00102_A196COSTOTONRFFPRODUValor[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"COSTOTONRFFPRODU"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1037( )
      {
         BeforeValidate1037( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1037( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1037( 0) ;
            CheckOptimisticConcurrency1037( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1037( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1037( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001014 */
                     pr_default.execute(12, new Object[] {A77COSTOTONRFFPRODUFecha, A78COSTOTONRFFPRODUMes, A79COSTOTONRFFPRODUAno, A196COSTOTONRFFPRODUValor, A5Cod_Area, A4IndicadoresCodigo, A65MOTIVOTONRFFcod});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("COSTOTONRFFPRODU");
                     if ( (pr_default.getStatus(12) == 1) )
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
                           ResetCaption100( ) ;
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
               Load1037( ) ;
            }
            EndLevel1037( ) ;
         }
         CloseExtendedTableCursors1037( ) ;
      }

      protected void Update1037( )
      {
         BeforeValidate1037( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1037( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1037( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1037( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1037( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001015 */
                     pr_default.execute(13, new Object[] {A196COSTOTONRFFPRODUValor, A77COSTOTONRFFPRODUFecha, A78COSTOTONRFFPRODUMes, A79COSTOTONRFFPRODUAno, A5Cod_Area, A4IndicadoresCodigo, A65MOTIVOTONRFFcod});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("COSTOTONRFFPRODU");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"COSTOTONRFFPRODU"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1037( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption100( ) ;
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
            EndLevel1037( ) ;
         }
         CloseExtendedTableCursors1037( ) ;
      }

      protected void DeferredUpdate1037( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1037( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1037( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1037( ) ;
            AfterConfirm1037( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1037( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001016 */
                  pr_default.execute(14, new Object[] {A77COSTOTONRFFPRODUFecha, A78COSTOTONRFFPRODUMes, A79COSTOTONRFFPRODUAno, A5Cod_Area, A4IndicadoresCodigo, A65MOTIVOTONRFFcod});
                  pr_default.close(14);
                  pr_default.SmartCacheProvider.SetUpdated("COSTOTONRFFPRODU");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound37 == 0 )
                        {
                           InitAll1037( ) ;
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
                        ResetCaption100( ) ;
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
         sMode37 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1037( ) ;
         Gx_mode = sMode37;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1037( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1037( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1037( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("costotonrffprodu",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues100( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("costotonrffprodu",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1037( )
      {
         /* Using cursor T001017 */
         pr_default.execute(15);
         RcdFound37 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound37 = 1;
            A77COSTOTONRFFPRODUFecha = T001017_A77COSTOTONRFFPRODUFecha[0];
            AssignAttri("", false, "A77COSTOTONRFFPRODUFecha", context.localUtil.Format(A77COSTOTONRFFPRODUFecha, "99/99/99"));
            A78COSTOTONRFFPRODUMes = T001017_A78COSTOTONRFFPRODUMes[0];
            AssignAttri("", false, "A78COSTOTONRFFPRODUMes", StringUtil.LTrimStr( (decimal)(A78COSTOTONRFFPRODUMes), 4, 0));
            A79COSTOTONRFFPRODUAno = T001017_A79COSTOTONRFFPRODUAno[0];
            AssignAttri("", false, "A79COSTOTONRFFPRODUAno", StringUtil.LTrimStr( (decimal)(A79COSTOTONRFFPRODUAno), 4, 0));
            A5Cod_Area = T001017_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = T001017_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A65MOTIVOTONRFFcod = T001017_A65MOTIVOTONRFFcod[0];
            AssignAttri("", false, "A65MOTIVOTONRFFcod", A65MOTIVOTONRFFcod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1037( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound37 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound37 = 1;
            A77COSTOTONRFFPRODUFecha = T001017_A77COSTOTONRFFPRODUFecha[0];
            AssignAttri("", false, "A77COSTOTONRFFPRODUFecha", context.localUtil.Format(A77COSTOTONRFFPRODUFecha, "99/99/99"));
            A78COSTOTONRFFPRODUMes = T001017_A78COSTOTONRFFPRODUMes[0];
            AssignAttri("", false, "A78COSTOTONRFFPRODUMes", StringUtil.LTrimStr( (decimal)(A78COSTOTONRFFPRODUMes), 4, 0));
            A79COSTOTONRFFPRODUAno = T001017_A79COSTOTONRFFPRODUAno[0];
            AssignAttri("", false, "A79COSTOTONRFFPRODUAno", StringUtil.LTrimStr( (decimal)(A79COSTOTONRFFPRODUAno), 4, 0));
            A5Cod_Area = T001017_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = T001017_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A65MOTIVOTONRFFcod = T001017_A65MOTIVOTONRFFcod[0];
            AssignAttri("", false, "A65MOTIVOTONRFFcod", A65MOTIVOTONRFFcod);
         }
      }

      protected void ScanEnd1037( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm1037( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1037( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1037( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1037( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1037( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1037( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1037( )
      {
         edtCOSTOTONRFFPRODUFecha_Enabled = 0;
         AssignProp("", false, edtCOSTOTONRFFPRODUFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSTOTONRFFPRODUFecha_Enabled), 5, 0), true);
         edtCOSTOTONRFFPRODUMes_Enabled = 0;
         AssignProp("", false, edtCOSTOTONRFFPRODUMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSTOTONRFFPRODUMes_Enabled), 5, 0), true);
         edtCOSTOTONRFFPRODUAno_Enabled = 0;
         AssignProp("", false, edtCOSTOTONRFFPRODUAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSTOTONRFFPRODUAno_Enabled), 5, 0), true);
         edtCod_Area_Enabled = 0;
         AssignProp("", false, edtCod_Area_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCod_Area_Enabled), 5, 0), true);
         edtIndicadoresCodigo_Enabled = 0;
         AssignProp("", false, edtIndicadoresCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIndicadoresCodigo_Enabled), 5, 0), true);
         edtMOTIVOTONRFFcod_Enabled = 0;
         AssignProp("", false, edtMOTIVOTONRFFcod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMOTIVOTONRFFcod_Enabled), 5, 0), true);
         edtCOSTOTONRFFPRODUValor_Enabled = 0;
         AssignProp("", false, edtCOSTOTONRFFPRODUValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSTOTONRFFPRODUValor_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1037( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues100( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("costotonrffprodu.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z77COSTOTONRFFPRODUFecha", context.localUtil.DToC( Z77COSTOTONRFFPRODUFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z78COSTOTONRFFPRODUMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z78COSTOTONRFFPRODUMes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z79COSTOTONRFFPRODUAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z79COSTOTONRFFPRODUAno), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z5Cod_Area", Z5Cod_Area);
         GxWebStd.gx_hidden_field( context, "Z4IndicadoresCodigo", Z4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "Z65MOTIVOTONRFFcod", Z65MOTIVOTONRFFcod);
         GxWebStd.gx_hidden_field( context, "Z196COSTOTONRFFPRODUValor", StringUtil.LTrim( StringUtil.NToC( Z196COSTOTONRFFPRODUValor, 16, 2, ",", "")));
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
         return formatLink("costotonrffprodu.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "COSTOTONRFFPRODU" ;
      }

      public override string GetPgmdesc( )
      {
         return "COSTOTONRFFPRODU" ;
      }

      protected void InitializeNonKey1037( )
      {
         A196COSTOTONRFFPRODUValor = 0;
         AssignAttri("", false, "A196COSTOTONRFFPRODUValor", StringUtil.LTrimStr( A196COSTOTONRFFPRODUValor, 16, 2));
         Z196COSTOTONRFFPRODUValor = 0;
      }

      protected void InitAll1037( )
      {
         A77COSTOTONRFFPRODUFecha = DateTime.MinValue;
         AssignAttri("", false, "A77COSTOTONRFFPRODUFecha", context.localUtil.Format(A77COSTOTONRFFPRODUFecha, "99/99/99"));
         A78COSTOTONRFFPRODUMes = 0;
         AssignAttri("", false, "A78COSTOTONRFFPRODUMes", StringUtil.LTrimStr( (decimal)(A78COSTOTONRFFPRODUMes), 4, 0));
         A79COSTOTONRFFPRODUAno = 0;
         AssignAttri("", false, "A79COSTOTONRFFPRODUAno", StringUtil.LTrimStr( (decimal)(A79COSTOTONRFFPRODUAno), 4, 0));
         A5Cod_Area = "";
         AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
         A4IndicadoresCodigo = "";
         AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
         A65MOTIVOTONRFFcod = "";
         AssignAttri("", false, "A65MOTIVOTONRFFcod", A65MOTIVOTONRFFcod);
         InitializeNonKey1037( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20247231025110", true, true);
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
         context.AddJavascriptSource("costotonrffprodu.js", "?20247231025110", false, true);
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
         edtCOSTOTONRFFPRODUFecha_Internalname = "COSTOTONRFFPRODUFECHA";
         edtCOSTOTONRFFPRODUMes_Internalname = "COSTOTONRFFPRODUMES";
         edtCOSTOTONRFFPRODUAno_Internalname = "COSTOTONRFFPRODUANO";
         edtCod_Area_Internalname = "COD_AREA";
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO";
         edtMOTIVOTONRFFcod_Internalname = "MOTIVOTONRFFCOD";
         edtCOSTOTONRFFPRODUValor_Internalname = "COSTOTONRFFPRODUVALOR";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_5_Internalname = "PROMPT_5";
         imgprompt_4_Internalname = "PROMPT_4";
         imgprompt_65_Internalname = "PROMPT_65";
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
         Form.Caption = "COSTOTONRFFPRODU";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCOSTOTONRFFPRODUValor_Jsonclick = "";
         edtCOSTOTONRFFPRODUValor_Enabled = 1;
         imgprompt_65_Visible = 1;
         imgprompt_65_Link = "";
         edtMOTIVOTONRFFcod_Jsonclick = "";
         edtMOTIVOTONRFFcod_Enabled = 1;
         imgprompt_4_Visible = 1;
         imgprompt_4_Link = "";
         edtIndicadoresCodigo_Jsonclick = "";
         edtIndicadoresCodigo_Enabled = 1;
         imgprompt_5_Visible = 1;
         imgprompt_5_Link = "";
         edtCod_Area_Jsonclick = "";
         edtCod_Area_Enabled = 1;
         edtCOSTOTONRFFPRODUAno_Jsonclick = "";
         edtCOSTOTONRFFPRODUAno_Enabled = 1;
         edtCOSTOTONRFFPRODUMes_Jsonclick = "";
         edtCOSTOTONRFFPRODUMes_Enabled = 1;
         edtCOSTOTONRFFPRODUFecha_Jsonclick = "";
         edtCOSTOTONRFFPRODUFecha_Enabled = 1;
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
         /* Using cursor T001018 */
         pr_default.execute(16, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(16);
         /* Using cursor T001019 */
         pr_default.execute(17, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(17);
         /* Using cursor T001020 */
         pr_default.execute(18, new Object[] {A65MOTIVOTONRFFcod});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'MOTIVOTONRFF'.", "ForeignKeyNotFound", 1, "MOTIVOTONRFFCOD");
            AnyError = 1;
            GX_FocusControl = edtMOTIVOTONRFFcod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(18);
         GX_FocusControl = edtCOSTOTONRFFPRODUValor_Internalname;
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
         /* Using cursor T001018 */
         pr_default.execute(16, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
         }
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Indicadorescodigo( )
      {
         /* Using cursor T001019 */
         pr_default.execute(17, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
         }
         pr_default.close(17);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Motivotonrffcod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T001020 */
         pr_default.execute(18, new Object[] {A65MOTIVOTONRFFcod});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'MOTIVOTONRFF'.", "ForeignKeyNotFound", 1, "MOTIVOTONRFFCOD");
            AnyError = 1;
            GX_FocusControl = edtMOTIVOTONRFFcod_Internalname;
         }
         pr_default.close(18);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A196COSTOTONRFFPRODUValor", StringUtil.LTrim( StringUtil.NToC( A196COSTOTONRFFPRODUValor, 16, 2, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z77COSTOTONRFFPRODUFecha", context.localUtil.Format(Z77COSTOTONRFFPRODUFecha, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z78COSTOTONRFFPRODUMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z78COSTOTONRFFPRODUMes), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z79COSTOTONRFFPRODUAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z79COSTOTONRFFPRODUAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z5Cod_Area", Z5Cod_Area);
         GxWebStd.gx_hidden_field( context, "Z4IndicadoresCodigo", Z4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "Z65MOTIVOTONRFFcod", Z65MOTIVOTONRFFcod);
         GxWebStd.gx_hidden_field( context, "Z196COSTOTONRFFPRODUValor", StringUtil.LTrim( StringUtil.NToC( Z196COSTOTONRFFPRODUValor, 16, 2, ".", "")));
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
         setEventMetadata("VALID_COSTOTONRFFPRODUFECHA","{handler:'Valid_Costotonrffprodufecha',iparms:[]");
         setEventMetadata("VALID_COSTOTONRFFPRODUFECHA",",oparms:[]}");
         setEventMetadata("VALID_COSTOTONRFFPRODUMES","{handler:'Valid_Costotonrffprodumes',iparms:[]");
         setEventMetadata("VALID_COSTOTONRFFPRODUMES",",oparms:[]}");
         setEventMetadata("VALID_COSTOTONRFFPRODUANO","{handler:'Valid_Costotonrffproduano',iparms:[]");
         setEventMetadata("VALID_COSTOTONRFFPRODUANO",",oparms:[]}");
         setEventMetadata("VALID_COD_AREA","{handler:'Valid_Cod_area',iparms:[{av:'A5Cod_Area',fld:'COD_AREA',pic:''}]");
         setEventMetadata("VALID_COD_AREA",",oparms:[]}");
         setEventMetadata("VALID_INDICADORESCODIGO","{handler:'Valid_Indicadorescodigo',iparms:[{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:''}]");
         setEventMetadata("VALID_INDICADORESCODIGO",",oparms:[]}");
         setEventMetadata("VALID_MOTIVOTONRFFCOD","{handler:'Valid_Motivotonrffcod',iparms:[{av:'A77COSTOTONRFFPRODUFecha',fld:'COSTOTONRFFPRODUFECHA',pic:''},{av:'A78COSTOTONRFFPRODUMes',fld:'COSTOTONRFFPRODUMES',pic:'ZZZ9'},{av:'A79COSTOTONRFFPRODUAno',fld:'COSTOTONRFFPRODUANO',pic:'ZZZ9'},{av:'A5Cod_Area',fld:'COD_AREA',pic:''},{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:''},{av:'A65MOTIVOTONRFFcod',fld:'MOTIVOTONRFFCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_MOTIVOTONRFFCOD",",oparms:[{av:'A196COSTOTONRFFPRODUValor',fld:'COSTOTONRFFPRODUVALOR',pic:'ZZZZZZZZZZZZ9.99'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z77COSTOTONRFFPRODUFecha'},{av:'Z78COSTOTONRFFPRODUMes'},{av:'Z79COSTOTONRFFPRODUAno'},{av:'Z5Cod_Area'},{av:'Z4IndicadoresCodigo'},{av:'Z65MOTIVOTONRFFcod'},{av:'Z196COSTOTONRFFPRODUValor'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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
         pr_default.close(16);
         pr_default.close(17);
         pr_default.close(18);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z77COSTOTONRFFPRODUFecha = DateTime.MinValue;
         Z5Cod_Area = "";
         Z4IndicadoresCodigo = "";
         Z65MOTIVOTONRFFcod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A5Cod_Area = "";
         A4IndicadoresCodigo = "";
         A65MOTIVOTONRFFcod = "";
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
         A77COSTOTONRFFPRODUFecha = DateTime.MinValue;
         imgprompt_5_gximage = "";
         sImgUrl = "";
         imgprompt_4_gximage = "";
         imgprompt_65_gximage = "";
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
         T00107_A77COSTOTONRFFPRODUFecha = new DateTime[] {DateTime.MinValue} ;
         T00107_A78COSTOTONRFFPRODUMes = new short[1] ;
         T00107_A79COSTOTONRFFPRODUAno = new short[1] ;
         T00107_A196COSTOTONRFFPRODUValor = new decimal[1] ;
         T00107_A5Cod_Area = new string[] {""} ;
         T00107_A4IndicadoresCodigo = new string[] {""} ;
         T00107_A65MOTIVOTONRFFcod = new string[] {""} ;
         T00104_A5Cod_Area = new string[] {""} ;
         T00105_A4IndicadoresCodigo = new string[] {""} ;
         T00106_A65MOTIVOTONRFFcod = new string[] {""} ;
         T00108_A5Cod_Area = new string[] {""} ;
         T00109_A4IndicadoresCodigo = new string[] {""} ;
         T001010_A65MOTIVOTONRFFcod = new string[] {""} ;
         T001011_A77COSTOTONRFFPRODUFecha = new DateTime[] {DateTime.MinValue} ;
         T001011_A78COSTOTONRFFPRODUMes = new short[1] ;
         T001011_A79COSTOTONRFFPRODUAno = new short[1] ;
         T001011_A5Cod_Area = new string[] {""} ;
         T001011_A4IndicadoresCodigo = new string[] {""} ;
         T001011_A65MOTIVOTONRFFcod = new string[] {""} ;
         T00103_A77COSTOTONRFFPRODUFecha = new DateTime[] {DateTime.MinValue} ;
         T00103_A78COSTOTONRFFPRODUMes = new short[1] ;
         T00103_A79COSTOTONRFFPRODUAno = new short[1] ;
         T00103_A196COSTOTONRFFPRODUValor = new decimal[1] ;
         T00103_A5Cod_Area = new string[] {""} ;
         T00103_A4IndicadoresCodigo = new string[] {""} ;
         T00103_A65MOTIVOTONRFFcod = new string[] {""} ;
         sMode37 = "";
         T001012_A77COSTOTONRFFPRODUFecha = new DateTime[] {DateTime.MinValue} ;
         T001012_A78COSTOTONRFFPRODUMes = new short[1] ;
         T001012_A79COSTOTONRFFPRODUAno = new short[1] ;
         T001012_A5Cod_Area = new string[] {""} ;
         T001012_A4IndicadoresCodigo = new string[] {""} ;
         T001012_A65MOTIVOTONRFFcod = new string[] {""} ;
         T001013_A77COSTOTONRFFPRODUFecha = new DateTime[] {DateTime.MinValue} ;
         T001013_A78COSTOTONRFFPRODUMes = new short[1] ;
         T001013_A79COSTOTONRFFPRODUAno = new short[1] ;
         T001013_A5Cod_Area = new string[] {""} ;
         T001013_A4IndicadoresCodigo = new string[] {""} ;
         T001013_A65MOTIVOTONRFFcod = new string[] {""} ;
         T00102_A77COSTOTONRFFPRODUFecha = new DateTime[] {DateTime.MinValue} ;
         T00102_A78COSTOTONRFFPRODUMes = new short[1] ;
         T00102_A79COSTOTONRFFPRODUAno = new short[1] ;
         T00102_A196COSTOTONRFFPRODUValor = new decimal[1] ;
         T00102_A5Cod_Area = new string[] {""} ;
         T00102_A4IndicadoresCodigo = new string[] {""} ;
         T00102_A65MOTIVOTONRFFcod = new string[] {""} ;
         T001017_A77COSTOTONRFFPRODUFecha = new DateTime[] {DateTime.MinValue} ;
         T001017_A78COSTOTONRFFPRODUMes = new short[1] ;
         T001017_A79COSTOTONRFFPRODUAno = new short[1] ;
         T001017_A5Cod_Area = new string[] {""} ;
         T001017_A4IndicadoresCodigo = new string[] {""} ;
         T001017_A65MOTIVOTONRFFcod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T001018_A5Cod_Area = new string[] {""} ;
         T001019_A4IndicadoresCodigo = new string[] {""} ;
         T001020_A65MOTIVOTONRFFcod = new string[] {""} ;
         ZZ77COSTOTONRFFPRODUFecha = DateTime.MinValue;
         ZZ5Cod_Area = "";
         ZZ4IndicadoresCodigo = "";
         ZZ65MOTIVOTONRFFcod = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.costotonrffprodu__default(),
            new Object[][] {
                new Object[] {
               T00102_A77COSTOTONRFFPRODUFecha, T00102_A78COSTOTONRFFPRODUMes, T00102_A79COSTOTONRFFPRODUAno, T00102_A196COSTOTONRFFPRODUValor, T00102_A5Cod_Area, T00102_A4IndicadoresCodigo, T00102_A65MOTIVOTONRFFcod
               }
               , new Object[] {
               T00103_A77COSTOTONRFFPRODUFecha, T00103_A78COSTOTONRFFPRODUMes, T00103_A79COSTOTONRFFPRODUAno, T00103_A196COSTOTONRFFPRODUValor, T00103_A5Cod_Area, T00103_A4IndicadoresCodigo, T00103_A65MOTIVOTONRFFcod
               }
               , new Object[] {
               T00104_A5Cod_Area
               }
               , new Object[] {
               T00105_A4IndicadoresCodigo
               }
               , new Object[] {
               T00106_A65MOTIVOTONRFFcod
               }
               , new Object[] {
               T00107_A77COSTOTONRFFPRODUFecha, T00107_A78COSTOTONRFFPRODUMes, T00107_A79COSTOTONRFFPRODUAno, T00107_A196COSTOTONRFFPRODUValor, T00107_A5Cod_Area, T00107_A4IndicadoresCodigo, T00107_A65MOTIVOTONRFFcod
               }
               , new Object[] {
               T00108_A5Cod_Area
               }
               , new Object[] {
               T00109_A4IndicadoresCodigo
               }
               , new Object[] {
               T001010_A65MOTIVOTONRFFcod
               }
               , new Object[] {
               T001011_A77COSTOTONRFFPRODUFecha, T001011_A78COSTOTONRFFPRODUMes, T001011_A79COSTOTONRFFPRODUAno, T001011_A5Cod_Area, T001011_A4IndicadoresCodigo, T001011_A65MOTIVOTONRFFcod
               }
               , new Object[] {
               T001012_A77COSTOTONRFFPRODUFecha, T001012_A78COSTOTONRFFPRODUMes, T001012_A79COSTOTONRFFPRODUAno, T001012_A5Cod_Area, T001012_A4IndicadoresCodigo, T001012_A65MOTIVOTONRFFcod
               }
               , new Object[] {
               T001013_A77COSTOTONRFFPRODUFecha, T001013_A78COSTOTONRFFPRODUMes, T001013_A79COSTOTONRFFPRODUAno, T001013_A5Cod_Area, T001013_A4IndicadoresCodigo, T001013_A65MOTIVOTONRFFcod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001017_A77COSTOTONRFFPRODUFecha, T001017_A78COSTOTONRFFPRODUMes, T001017_A79COSTOTONRFFPRODUAno, T001017_A5Cod_Area, T001017_A4IndicadoresCodigo, T001017_A65MOTIVOTONRFFcod
               }
               , new Object[] {
               T001018_A5Cod_Area
               }
               , new Object[] {
               T001019_A4IndicadoresCodigo
               }
               , new Object[] {
               T001020_A65MOTIVOTONRFFcod
               }
            }
         );
      }

      private short Z78COSTOTONRFFPRODUMes ;
      private short Z79COSTOTONRFFPRODUAno ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A78COSTOTONRFFPRODUMes ;
      private short A79COSTOTONRFFPRODUAno ;
      private short GX_JID ;
      private short RcdFound37 ;
      private short nIsDirty_37 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ78COSTOTONRFFPRODUMes ;
      private short ZZ79COSTOTONRFFPRODUAno ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtCOSTOTONRFFPRODUFecha_Enabled ;
      private int edtCOSTOTONRFFPRODUMes_Enabled ;
      private int edtCOSTOTONRFFPRODUAno_Enabled ;
      private int edtCod_Area_Enabled ;
      private int imgprompt_5_Visible ;
      private int edtIndicadoresCodigo_Enabled ;
      private int imgprompt_4_Visible ;
      private int edtMOTIVOTONRFFcod_Enabled ;
      private int imgprompt_65_Visible ;
      private int edtCOSTOTONRFFPRODUValor_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private decimal Z196COSTOTONRFFPRODUValor ;
      private decimal A196COSTOTONRFFPRODUValor ;
      private decimal ZZ196COSTOTONRFFPRODUValor ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCOSTOTONRFFPRODUFecha_Internalname ;
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
      private string edtCOSTOTONRFFPRODUFecha_Jsonclick ;
      private string edtCOSTOTONRFFPRODUMes_Internalname ;
      private string edtCOSTOTONRFFPRODUMes_Jsonclick ;
      private string edtCOSTOTONRFFPRODUAno_Internalname ;
      private string edtCOSTOTONRFFPRODUAno_Jsonclick ;
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
      private string edtMOTIVOTONRFFcod_Internalname ;
      private string edtMOTIVOTONRFFcod_Jsonclick ;
      private string imgprompt_65_gximage ;
      private string imgprompt_65_Internalname ;
      private string imgprompt_65_Link ;
      private string edtCOSTOTONRFFPRODUValor_Internalname ;
      private string edtCOSTOTONRFFPRODUValor_Jsonclick ;
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
      private string sMode37 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z77COSTOTONRFFPRODUFecha ;
      private DateTime A77COSTOTONRFFPRODUFecha ;
      private DateTime ZZ77COSTOTONRFFPRODUFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string Z5Cod_Area ;
      private string Z4IndicadoresCodigo ;
      private string Z65MOTIVOTONRFFcod ;
      private string A5Cod_Area ;
      private string A4IndicadoresCodigo ;
      private string A65MOTIVOTONRFFcod ;
      private string ZZ5Cod_Area ;
      private string ZZ4IndicadoresCodigo ;
      private string ZZ65MOTIVOTONRFFcod ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] T00107_A77COSTOTONRFFPRODUFecha ;
      private short[] T00107_A78COSTOTONRFFPRODUMes ;
      private short[] T00107_A79COSTOTONRFFPRODUAno ;
      private decimal[] T00107_A196COSTOTONRFFPRODUValor ;
      private string[] T00107_A5Cod_Area ;
      private string[] T00107_A4IndicadoresCodigo ;
      private string[] T00107_A65MOTIVOTONRFFcod ;
      private string[] T00104_A5Cod_Area ;
      private string[] T00105_A4IndicadoresCodigo ;
      private string[] T00106_A65MOTIVOTONRFFcod ;
      private string[] T00108_A5Cod_Area ;
      private string[] T00109_A4IndicadoresCodigo ;
      private string[] T001010_A65MOTIVOTONRFFcod ;
      private DateTime[] T001011_A77COSTOTONRFFPRODUFecha ;
      private short[] T001011_A78COSTOTONRFFPRODUMes ;
      private short[] T001011_A79COSTOTONRFFPRODUAno ;
      private string[] T001011_A5Cod_Area ;
      private string[] T001011_A4IndicadoresCodigo ;
      private string[] T001011_A65MOTIVOTONRFFcod ;
      private DateTime[] T00103_A77COSTOTONRFFPRODUFecha ;
      private short[] T00103_A78COSTOTONRFFPRODUMes ;
      private short[] T00103_A79COSTOTONRFFPRODUAno ;
      private decimal[] T00103_A196COSTOTONRFFPRODUValor ;
      private string[] T00103_A5Cod_Area ;
      private string[] T00103_A4IndicadoresCodigo ;
      private string[] T00103_A65MOTIVOTONRFFcod ;
      private DateTime[] T001012_A77COSTOTONRFFPRODUFecha ;
      private short[] T001012_A78COSTOTONRFFPRODUMes ;
      private short[] T001012_A79COSTOTONRFFPRODUAno ;
      private string[] T001012_A5Cod_Area ;
      private string[] T001012_A4IndicadoresCodigo ;
      private string[] T001012_A65MOTIVOTONRFFcod ;
      private DateTime[] T001013_A77COSTOTONRFFPRODUFecha ;
      private short[] T001013_A78COSTOTONRFFPRODUMes ;
      private short[] T001013_A79COSTOTONRFFPRODUAno ;
      private string[] T001013_A5Cod_Area ;
      private string[] T001013_A4IndicadoresCodigo ;
      private string[] T001013_A65MOTIVOTONRFFcod ;
      private DateTime[] T00102_A77COSTOTONRFFPRODUFecha ;
      private short[] T00102_A78COSTOTONRFFPRODUMes ;
      private short[] T00102_A79COSTOTONRFFPRODUAno ;
      private decimal[] T00102_A196COSTOTONRFFPRODUValor ;
      private string[] T00102_A5Cod_Area ;
      private string[] T00102_A4IndicadoresCodigo ;
      private string[] T00102_A65MOTIVOTONRFFcod ;
      private DateTime[] T001017_A77COSTOTONRFFPRODUFecha ;
      private short[] T001017_A78COSTOTONRFFPRODUMes ;
      private short[] T001017_A79COSTOTONRFFPRODUAno ;
      private string[] T001017_A5Cod_Area ;
      private string[] T001017_A4IndicadoresCodigo ;
      private string[] T001017_A65MOTIVOTONRFFcod ;
      private string[] T001018_A5Cod_Area ;
      private string[] T001019_A4IndicadoresCodigo ;
      private string[] T001020_A65MOTIVOTONRFFcod ;
      private GXWebForm Form ;
   }

   public class costotonrffprodu__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[12])
         ,new UpdateCursor(def[13])
         ,new UpdateCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00107;
          prmT00107 = new Object[] {
          new ParDef("@COSTOTONRFFPRODUFecha",GXType.Date,8,0) ,
          new ParDef("@COSTOTONRFFPRODUMes",GXType.Int16,4,0) ,
          new ParDef("@COSTOTONRFFPRODUAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MOTIVOTONRFFcod",GXType.NVarChar,140,0)
          };
          Object[] prmT00104;
          prmT00104 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT00105;
          prmT00105 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT00106;
          prmT00106 = new Object[] {
          new ParDef("@MOTIVOTONRFFcod",GXType.NVarChar,140,0)
          };
          Object[] prmT00108;
          prmT00108 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT00109;
          prmT00109 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT001010;
          prmT001010 = new Object[] {
          new ParDef("@MOTIVOTONRFFcod",GXType.NVarChar,140,0)
          };
          Object[] prmT001011;
          prmT001011 = new Object[] {
          new ParDef("@COSTOTONRFFPRODUFecha",GXType.Date,8,0) ,
          new ParDef("@COSTOTONRFFPRODUMes",GXType.Int16,4,0) ,
          new ParDef("@COSTOTONRFFPRODUAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MOTIVOTONRFFcod",GXType.NVarChar,140,0)
          };
          Object[] prmT00103;
          prmT00103 = new Object[] {
          new ParDef("@COSTOTONRFFPRODUFecha",GXType.Date,8,0) ,
          new ParDef("@COSTOTONRFFPRODUMes",GXType.Int16,4,0) ,
          new ParDef("@COSTOTONRFFPRODUAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MOTIVOTONRFFcod",GXType.NVarChar,140,0)
          };
          Object[] prmT001012;
          prmT001012 = new Object[] {
          new ParDef("@COSTOTONRFFPRODUFecha",GXType.Date,8,0) ,
          new ParDef("@COSTOTONRFFPRODUMes",GXType.Int16,4,0) ,
          new ParDef("@COSTOTONRFFPRODUAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MOTIVOTONRFFcod",GXType.NVarChar,140,0)
          };
          Object[] prmT001013;
          prmT001013 = new Object[] {
          new ParDef("@COSTOTONRFFPRODUFecha",GXType.Date,8,0) ,
          new ParDef("@COSTOTONRFFPRODUMes",GXType.Int16,4,0) ,
          new ParDef("@COSTOTONRFFPRODUAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MOTIVOTONRFFcod",GXType.NVarChar,140,0)
          };
          Object[] prmT00102;
          prmT00102 = new Object[] {
          new ParDef("@COSTOTONRFFPRODUFecha",GXType.Date,8,0) ,
          new ParDef("@COSTOTONRFFPRODUMes",GXType.Int16,4,0) ,
          new ParDef("@COSTOTONRFFPRODUAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MOTIVOTONRFFcod",GXType.NVarChar,140,0)
          };
          Object[] prmT001014;
          prmT001014 = new Object[] {
          new ParDef("@COSTOTONRFFPRODUFecha",GXType.Date,8,0) ,
          new ParDef("@COSTOTONRFFPRODUMes",GXType.Int16,4,0) ,
          new ParDef("@COSTOTONRFFPRODUAno",GXType.Int16,4,0) ,
          new ParDef("@COSTOTONRFFPRODUValor",GXType.Decimal,16,2) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MOTIVOTONRFFcod",GXType.NVarChar,140,0)
          };
          Object[] prmT001015;
          prmT001015 = new Object[] {
          new ParDef("@COSTOTONRFFPRODUValor",GXType.Decimal,16,2) ,
          new ParDef("@COSTOTONRFFPRODUFecha",GXType.Date,8,0) ,
          new ParDef("@COSTOTONRFFPRODUMes",GXType.Int16,4,0) ,
          new ParDef("@COSTOTONRFFPRODUAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MOTIVOTONRFFcod",GXType.NVarChar,140,0)
          };
          Object[] prmT001016;
          prmT001016 = new Object[] {
          new ParDef("@COSTOTONRFFPRODUFecha",GXType.Date,8,0) ,
          new ParDef("@COSTOTONRFFPRODUMes",GXType.Int16,4,0) ,
          new ParDef("@COSTOTONRFFPRODUAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MOTIVOTONRFFcod",GXType.NVarChar,140,0)
          };
          Object[] prmT001017;
          prmT001017 = new Object[] {
          };
          Object[] prmT001018;
          prmT001018 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT001019;
          prmT001019 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT001020;
          prmT001020 = new Object[] {
          new ParDef("@MOTIVOTONRFFcod",GXType.NVarChar,140,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00102", "SELECT [COSTOTONRFFPRODUFecha], [COSTOTONRFFPRODUMes], [COSTOTONRFFPRODUAno], [COSTOTONRFFPRODUValor], [Cod_Area], [IndicadoresCodigo], [MOTIVOTONRFFcod] FROM [COSTOTONRFFPRODU] WITH (UPDLOCK) WHERE [COSTOTONRFFPRODUFecha] = @COSTOTONRFFPRODUFecha AND [COSTOTONRFFPRODUMes] = @COSTOTONRFFPRODUMes AND [COSTOTONRFFPRODUAno] = @COSTOTONRFFPRODUAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo AND [MOTIVOTONRFFcod] = @MOTIVOTONRFFcod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00102,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00103", "SELECT [COSTOTONRFFPRODUFecha], [COSTOTONRFFPRODUMes], [COSTOTONRFFPRODUAno], [COSTOTONRFFPRODUValor], [Cod_Area], [IndicadoresCodigo], [MOTIVOTONRFFcod] FROM [COSTOTONRFFPRODU] WHERE [COSTOTONRFFPRODUFecha] = @COSTOTONRFFPRODUFecha AND [COSTOTONRFFPRODUMes] = @COSTOTONRFFPRODUMes AND [COSTOTONRFFPRODUAno] = @COSTOTONRFFPRODUAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo AND [MOTIVOTONRFFcod] = @MOTIVOTONRFFcod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00103,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00104", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT00104,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00105", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT00105,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00106", "SELECT [MOTIVOTONRFFcod] FROM [MOTIVOTONRFF] WHERE [MOTIVOTONRFFcod] = @MOTIVOTONRFFcod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00106,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00107", "SELECT TM1.[COSTOTONRFFPRODUFecha], TM1.[COSTOTONRFFPRODUMes], TM1.[COSTOTONRFFPRODUAno], TM1.[COSTOTONRFFPRODUValor], TM1.[Cod_Area], TM1.[IndicadoresCodigo], TM1.[MOTIVOTONRFFcod] FROM [COSTOTONRFFPRODU] TM1 WHERE TM1.[COSTOTONRFFPRODUFecha] = @COSTOTONRFFPRODUFecha and TM1.[COSTOTONRFFPRODUMes] = @COSTOTONRFFPRODUMes and TM1.[COSTOTONRFFPRODUAno] = @COSTOTONRFFPRODUAno and TM1.[Cod_Area] = @Cod_Area and TM1.[IndicadoresCodigo] = @IndicadoresCodigo and TM1.[MOTIVOTONRFFcod] = @MOTIVOTONRFFcod ORDER BY TM1.[COSTOTONRFFPRODUFecha], TM1.[COSTOTONRFFPRODUMes], TM1.[COSTOTONRFFPRODUAno], TM1.[Cod_Area], TM1.[IndicadoresCodigo], TM1.[MOTIVOTONRFFcod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00107,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00108", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT00108,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00109", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT00109,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001010", "SELECT [MOTIVOTONRFFcod] FROM [MOTIVOTONRFF] WHERE [MOTIVOTONRFFcod] = @MOTIVOTONRFFcod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001010,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001011", "SELECT [COSTOTONRFFPRODUFecha], [COSTOTONRFFPRODUMes], [COSTOTONRFFPRODUAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOTONRFFcod] FROM [COSTOTONRFFPRODU] WHERE [COSTOTONRFFPRODUFecha] = @COSTOTONRFFPRODUFecha AND [COSTOTONRFFPRODUMes] = @COSTOTONRFFPRODUMes AND [COSTOTONRFFPRODUAno] = @COSTOTONRFFPRODUAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo AND [MOTIVOTONRFFcod] = @MOTIVOTONRFFcod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001011,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001012", "SELECT TOP 1 [COSTOTONRFFPRODUFecha], [COSTOTONRFFPRODUMes], [COSTOTONRFFPRODUAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOTONRFFcod] FROM [COSTOTONRFFPRODU] WHERE ( [COSTOTONRFFPRODUFecha] > @COSTOTONRFFPRODUFecha or [COSTOTONRFFPRODUFecha] = @COSTOTONRFFPRODUFecha and [COSTOTONRFFPRODUMes] > @COSTOTONRFFPRODUMes or [COSTOTONRFFPRODUMes] = @COSTOTONRFFPRODUMes and [COSTOTONRFFPRODUFecha] = @COSTOTONRFFPRODUFecha and [COSTOTONRFFPRODUAno] > @COSTOTONRFFPRODUAno or [COSTOTONRFFPRODUAno] = @COSTOTONRFFPRODUAno and [COSTOTONRFFPRODUMes] = @COSTOTONRFFPRODUMes and [COSTOTONRFFPRODUFecha] = @COSTOTONRFFPRODUFecha and [Cod_Area] > @Cod_Area or [Cod_Area] = @Cod_Area and [COSTOTONRFFPRODUAno] = @COSTOTONRFFPRODUAno and [COSTOTONRFFPRODUMes] = @COSTOTONRFFPRODUMes and [COSTOTONRFFPRODUFecha] = @COSTOTONRFFPRODUFecha and [IndicadoresCodigo] > @IndicadoresCodigo or [IndicadoresCodigo] = @IndicadoresCodigo and [Cod_Area] = @Cod_Area and [COSTOTONRFFPRODUAno] = @COSTOTONRFFPRODUAno and [COSTOTONRFFPRODUMes] = @COSTOTONRFFPRODUMes and [COSTOTONRFFPRODUFecha] = @COSTOTONRFFPRODUFecha and [MOTIVOTONRFFcod] > @MOTIVOTONRFFcod) ORDER BY [COSTOTONRFFPRODUFecha], [COSTOTONRFFPRODUMes], [COSTOTONRFFPRODUAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOTONRFFcod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001012,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001013", "SELECT TOP 1 [COSTOTONRFFPRODUFecha], [COSTOTONRFFPRODUMes], [COSTOTONRFFPRODUAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOTONRFFcod] FROM [COSTOTONRFFPRODU] WHERE ( [COSTOTONRFFPRODUFecha] < @COSTOTONRFFPRODUFecha or [COSTOTONRFFPRODUFecha] = @COSTOTONRFFPRODUFecha and [COSTOTONRFFPRODUMes] < @COSTOTONRFFPRODUMes or [COSTOTONRFFPRODUMes] = @COSTOTONRFFPRODUMes and [COSTOTONRFFPRODUFecha] = @COSTOTONRFFPRODUFecha and [COSTOTONRFFPRODUAno] < @COSTOTONRFFPRODUAno or [COSTOTONRFFPRODUAno] = @COSTOTONRFFPRODUAno and [COSTOTONRFFPRODUMes] = @COSTOTONRFFPRODUMes and [COSTOTONRFFPRODUFecha] = @COSTOTONRFFPRODUFecha and [Cod_Area] < @Cod_Area or [Cod_Area] = @Cod_Area and [COSTOTONRFFPRODUAno] = @COSTOTONRFFPRODUAno and [COSTOTONRFFPRODUMes] = @COSTOTONRFFPRODUMes and [COSTOTONRFFPRODUFecha] = @COSTOTONRFFPRODUFecha and [IndicadoresCodigo] < @IndicadoresCodigo or [IndicadoresCodigo] = @IndicadoresCodigo and [Cod_Area] = @Cod_Area and [COSTOTONRFFPRODUAno] = @COSTOTONRFFPRODUAno and [COSTOTONRFFPRODUMes] = @COSTOTONRFFPRODUMes and [COSTOTONRFFPRODUFecha] = @COSTOTONRFFPRODUFecha and [MOTIVOTONRFFcod] < @MOTIVOTONRFFcod) ORDER BY [COSTOTONRFFPRODUFecha] DESC, [COSTOTONRFFPRODUMes] DESC, [COSTOTONRFFPRODUAno] DESC, [Cod_Area] DESC, [IndicadoresCodigo] DESC, [MOTIVOTONRFFcod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001013,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001014", "INSERT INTO [COSTOTONRFFPRODU]([COSTOTONRFFPRODUFecha], [COSTOTONRFFPRODUMes], [COSTOTONRFFPRODUAno], [COSTOTONRFFPRODUValor], [Cod_Area], [IndicadoresCodigo], [MOTIVOTONRFFcod]) VALUES(@COSTOTONRFFPRODUFecha, @COSTOTONRFFPRODUMes, @COSTOTONRFFPRODUAno, @COSTOTONRFFPRODUValor, @Cod_Area, @IndicadoresCodigo, @MOTIVOTONRFFcod)", GxErrorMask.GX_NOMASK,prmT001014)
             ,new CursorDef("T001015", "UPDATE [COSTOTONRFFPRODU] SET [COSTOTONRFFPRODUValor]=@COSTOTONRFFPRODUValor  WHERE [COSTOTONRFFPRODUFecha] = @COSTOTONRFFPRODUFecha AND [COSTOTONRFFPRODUMes] = @COSTOTONRFFPRODUMes AND [COSTOTONRFFPRODUAno] = @COSTOTONRFFPRODUAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo AND [MOTIVOTONRFFcod] = @MOTIVOTONRFFcod", GxErrorMask.GX_NOMASK,prmT001015)
             ,new CursorDef("T001016", "DELETE FROM [COSTOTONRFFPRODU]  WHERE [COSTOTONRFFPRODUFecha] = @COSTOTONRFFPRODUFecha AND [COSTOTONRFFPRODUMes] = @COSTOTONRFFPRODUMes AND [COSTOTONRFFPRODUAno] = @COSTOTONRFFPRODUAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo AND [MOTIVOTONRFFcod] = @MOTIVOTONRFFcod", GxErrorMask.GX_NOMASK,prmT001016)
             ,new CursorDef("T001017", "SELECT [COSTOTONRFFPRODUFecha], [COSTOTONRFFPRODUMes], [COSTOTONRFFPRODUAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOTONRFFcod] FROM [COSTOTONRFFPRODU] ORDER BY [COSTOTONRFFPRODUFecha], [COSTOTONRFFPRODUMes], [COSTOTONRFFPRODUAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOTONRFFcod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001017,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001018", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT001018,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001019", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT001019,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001020", "SELECT [MOTIVOTONRFFcod] FROM [MOTIVOTONRFF] WHERE [MOTIVOTONRFFcod] = @MOTIVOTONRFFcod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001020,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                return;
             case 1 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 9 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                return;
             case 10 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                return;
             case 11 :
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
                return;
             case 16 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 17 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 18 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
       }
    }

 }

}
