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
   public class costocpoproducido : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A64TIPOSCPOCod = GetPar( "TIPOSCPOCod");
            AssignAttri("", false, "A64TIPOSCPOCod", A64TIPOSCPOCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A64TIPOSCPOCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A45TipoProductoCod = GetPar( "TipoProductoCod");
            AssignAttri("", false, "A45TipoProductoCod", A45TipoProductoCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A45TipoProductoCod) ;
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
            Form.Meta.addItem("description", "COSTOCPOPRODUCIDO", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCOSTOCPOPRODUCIDOFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("IndicadroresPalmas", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public costocpoproducido( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("IndicadroresPalmas", true);
      }

      public costocpoproducido( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "COSTOCPOPRODUCIDO", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_COSTOCPOPRODUCIDO.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSTOCPOPRODUCIDO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSTOCPOPRODUCIDO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSTOCPOPRODUCIDO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSTOCPOPRODUCIDO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 4, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx00z0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"COSTOCPOPRODUCIDOFECHA"+"'), id:'"+"COSTOCPOPRODUCIDOFECHA"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"COSTOCPOPRODUCIDOMES"+"'), id:'"+"COSTOCPOPRODUCIDOMES"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"COSTOCPOPRODUCIDOANO"+"'), id:'"+"COSTOCPOPRODUCIDOANO"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"COD_AREA"+"'), id:'"+"COD_AREA"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"INDICADORESCODIGO"+"'), id:'"+"INDICADORESCODIGO"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"TIPOSCPOCOD"+"'), id:'"+"TIPOSCPOCOD"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"TIPOPRODUCTOCOD"+"'), id:'"+"TIPOPRODUCTOCOD"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_COSTOCPOPRODUCIDO.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCOSTOCPOPRODUCIDOFecha_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCOSTOCPOPRODUCIDOFecha_Internalname, "COSTOCPOPRODUCIDOFecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCOSTOCPOPRODUCIDOFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCOSTOCPOPRODUCIDOFecha_Internalname, context.localUtil.Format(A109COSTOCPOPRODUCIDOFecha, "99/99/99"), context.localUtil.Format( A109COSTOCPOPRODUCIDOFecha, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCOSTOCPOPRODUCIDOFecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCOSTOCPOPRODUCIDOFecha_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_COSTOCPOPRODUCIDO.htm");
         GxWebStd.gx_bitmap( context, edtCOSTOCPOPRODUCIDOFecha_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCOSTOCPOPRODUCIDOFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_COSTOCPOPRODUCIDO.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCOSTOCPOPRODUCIDOMes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCOSTOCPOPRODUCIDOMes_Internalname, "COSTOCPOPRODUCIDOMes", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCOSTOCPOPRODUCIDOMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A110COSTOCPOPRODUCIDOMes), 4, 0, ",", "")), StringUtil.LTrim( ((edtCOSTOCPOPRODUCIDOMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A110COSTOCPOPRODUCIDOMes), "ZZZ9") : context.localUtil.Format( (decimal)(A110COSTOCPOPRODUCIDOMes), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCOSTOCPOPRODUCIDOMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCOSTOCPOPRODUCIDOMes_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_COSTOCPOPRODUCIDO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCOSTOCPOPRODUCIDOAno_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCOSTOCPOPRODUCIDOAno_Internalname, "COSTOCPOPRODUCIDOAno", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCOSTOCPOPRODUCIDOAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A111COSTOCPOPRODUCIDOAno), 4, 0, ",", "")), StringUtil.LTrim( ((edtCOSTOCPOPRODUCIDOAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A111COSTOCPOPRODUCIDOAno), "ZZZ9") : context.localUtil.Format( (decimal)(A111COSTOCPOPRODUCIDOAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCOSTOCPOPRODUCIDOAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCOSTOCPOPRODUCIDOAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_COSTOCPOPRODUCIDO.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCod_Area_Internalname, A5Cod_Area, StringUtil.RTrim( context.localUtil.Format( A5Cod_Area, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCod_Area_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCod_Area_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_COSTOCPOPRODUCIDO.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_5_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_5_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_5_Internalname, sImgUrl, imgprompt_5_Link, "", "", context.GetTheme( ), imgprompt_5_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_COSTOCPOPRODUCIDO.htm");
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
         GxWebStd.gx_single_line_edit( context, edtIndicadoresCodigo_Internalname, A4IndicadoresCodigo, StringUtil.RTrim( context.localUtil.Format( A4IndicadoresCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIndicadoresCodigo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIndicadoresCodigo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_COSTOCPOPRODUCIDO.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_4_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_4_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_4_Internalname, sImgUrl, imgprompt_4_Link, "", "", context.GetTheme( ), imgprompt_4_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_COSTOCPOPRODUCIDO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTIPOSCPOCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTIPOSCPOCod_Internalname, "TIPOSCPOCod", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTIPOSCPOCod_Internalname, A64TIPOSCPOCod, StringUtil.RTrim( context.localUtil.Format( A64TIPOSCPOCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTIPOSCPOCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTIPOSCPOCod_Enabled, 0, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_COSTOCPOPRODUCIDO.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_64_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_64_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_64_Internalname, sImgUrl, imgprompt_64_Link, "", "", context.GetTheme( ), imgprompt_64_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_COSTOCPOPRODUCIDO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTipoProductoCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTipoProductoCod_Internalname, "Tipo Producto Cod", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipoProductoCod_Internalname, A45TipoProductoCod, StringUtil.RTrim( context.localUtil.Format( A45TipoProductoCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipoProductoCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipoProductoCod_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_COSTOCPOPRODUCIDO.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_45_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_45_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_45_Internalname, sImgUrl, imgprompt_45_Link, "", "", context.GetTheme( ), imgprompt_45_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_COSTOCPOPRODUCIDO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCOSTOCPOPRODUCIDOValor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCOSTOCPOPRODUCIDOValor_Internalname, "COSTOCPOPRODUCIDOValor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCOSTOCPOPRODUCIDOValor_Internalname, StringUtil.LTrim( StringUtil.NToC( A191COSTOCPOPRODUCIDOValor, 10, 2, ",", "")), StringUtil.LTrim( ((edtCOSTOCPOPRODUCIDOValor_Enabled!=0) ? context.localUtil.Format( A191COSTOCPOPRODUCIDOValor, "ZZZZZZ9.99") : context.localUtil.Format( A191COSTOCPOPRODUCIDOValor, "ZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCOSTOCPOPRODUCIDOValor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCOSTOCPOPRODUCIDOValor_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_COSTOCPOPRODUCIDO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCOSTOCPOPRODUCIDOUser_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCOSTOCPOPRODUCIDOUser_Internalname, "COSTOCPOPRODUCIDOUser", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCOSTOCPOPRODUCIDOUser_Internalname, A192COSTOCPOPRODUCIDOUser, StringUtil.RTrim( context.localUtil.Format( A192COSTOCPOPRODUCIDOUser, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCOSTOCPOPRODUCIDOUser_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCOSTOCPOPRODUCIDOUser_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_COSTOCPOPRODUCIDO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCOSTOCPOPRODUCIDOReg_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCOSTOCPOPRODUCIDOReg_Internalname, "COSTOCPOPRODUCIDOReg", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCOSTOCPOPRODUCIDOReg_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCOSTOCPOPRODUCIDOReg_Internalname, context.localUtil.Format(A193COSTOCPOPRODUCIDOReg, "99/99/99"), context.localUtil.Format( A193COSTOCPOPRODUCIDOReg, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCOSTOCPOPRODUCIDOReg_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCOSTOCPOPRODUCIDOReg_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_COSTOCPOPRODUCIDO.htm");
         GxWebStd.gx_bitmap( context, edtCOSTOCPOPRODUCIDOReg_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCOSTOCPOPRODUCIDOReg_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_COSTOCPOPRODUCIDO.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCOSTOCPOPRODUCIDOHor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCOSTOCPOPRODUCIDOHor_Internalname, "COSTOCPOPRODUCIDOHor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCOSTOCPOPRODUCIDOHor_Internalname, A194COSTOCPOPRODUCIDOHor, StringUtil.RTrim( context.localUtil.Format( A194COSTOCPOPRODUCIDOHor, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCOSTOCPOPRODUCIDOHor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCOSTOCPOPRODUCIDOHor_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_COSTOCPOPRODUCIDO.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSTOCPOPRODUCIDO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSTOCPOPRODUCIDO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSTOCPOPRODUCIDO.htm");
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
            Z109COSTOCPOPRODUCIDOFecha = context.localUtil.CToD( cgiGet( "Z109COSTOCPOPRODUCIDOFecha"), 0);
            Z110COSTOCPOPRODUCIDOMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z110COSTOCPOPRODUCIDOMes"), ",", "."), 18, MidpointRounding.ToEven));
            Z111COSTOCPOPRODUCIDOAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z111COSTOCPOPRODUCIDOAno"), ",", "."), 18, MidpointRounding.ToEven));
            Z5Cod_Area = cgiGet( "Z5Cod_Area");
            Z4IndicadoresCodigo = cgiGet( "Z4IndicadoresCodigo");
            Z64TIPOSCPOCod = cgiGet( "Z64TIPOSCPOCod");
            Z45TipoProductoCod = cgiGet( "Z45TipoProductoCod");
            Z191COSTOCPOPRODUCIDOValor = context.localUtil.CToN( cgiGet( "Z191COSTOCPOPRODUCIDOValor"), ",", ".");
            Z192COSTOCPOPRODUCIDOUser = cgiGet( "Z192COSTOCPOPRODUCIDOUser");
            Z193COSTOCPOPRODUCIDOReg = context.localUtil.CToD( cgiGet( "Z193COSTOCPOPRODUCIDOReg"), 0);
            Z194COSTOCPOPRODUCIDOHor = cgiGet( "Z194COSTOCPOPRODUCIDOHor");
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( context.localUtil.VCDate( cgiGet( edtCOSTOCPOPRODUCIDOFecha_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"COSTOCPOPRODUCIDOFecha"}), 1, "COSTOCPOPRODUCIDOFECHA");
               AnyError = 1;
               GX_FocusControl = edtCOSTOCPOPRODUCIDOFecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A109COSTOCPOPRODUCIDOFecha = DateTime.MinValue;
               AssignAttri("", false, "A109COSTOCPOPRODUCIDOFecha", context.localUtil.Format(A109COSTOCPOPRODUCIDOFecha, "99/99/99"));
            }
            else
            {
               A109COSTOCPOPRODUCIDOFecha = context.localUtil.CToD( cgiGet( edtCOSTOCPOPRODUCIDOFecha_Internalname), 2);
               AssignAttri("", false, "A109COSTOCPOPRODUCIDOFecha", context.localUtil.Format(A109COSTOCPOPRODUCIDOFecha, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCOSTOCPOPRODUCIDOMes_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCOSTOCPOPRODUCIDOMes_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COSTOCPOPRODUCIDOMES");
               AnyError = 1;
               GX_FocusControl = edtCOSTOCPOPRODUCIDOMes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A110COSTOCPOPRODUCIDOMes = 0;
               AssignAttri("", false, "A110COSTOCPOPRODUCIDOMes", StringUtil.LTrimStr( (decimal)(A110COSTOCPOPRODUCIDOMes), 4, 0));
            }
            else
            {
               A110COSTOCPOPRODUCIDOMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCOSTOCPOPRODUCIDOMes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A110COSTOCPOPRODUCIDOMes", StringUtil.LTrimStr( (decimal)(A110COSTOCPOPRODUCIDOMes), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCOSTOCPOPRODUCIDOAno_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCOSTOCPOPRODUCIDOAno_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COSTOCPOPRODUCIDOANO");
               AnyError = 1;
               GX_FocusControl = edtCOSTOCPOPRODUCIDOAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A111COSTOCPOPRODUCIDOAno = 0;
               AssignAttri("", false, "A111COSTOCPOPRODUCIDOAno", StringUtil.LTrimStr( (decimal)(A111COSTOCPOPRODUCIDOAno), 4, 0));
            }
            else
            {
               A111COSTOCPOPRODUCIDOAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCOSTOCPOPRODUCIDOAno_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A111COSTOCPOPRODUCIDOAno", StringUtil.LTrimStr( (decimal)(A111COSTOCPOPRODUCIDOAno), 4, 0));
            }
            A5Cod_Area = cgiGet( edtCod_Area_Internalname);
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = cgiGet( edtIndicadoresCodigo_Internalname);
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A64TIPOSCPOCod = cgiGet( edtTIPOSCPOCod_Internalname);
            AssignAttri("", false, "A64TIPOSCPOCod", A64TIPOSCPOCod);
            A45TipoProductoCod = cgiGet( edtTipoProductoCod_Internalname);
            AssignAttri("", false, "A45TipoProductoCod", A45TipoProductoCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCOSTOCPOPRODUCIDOValor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCOSTOCPOPRODUCIDOValor_Internalname), ",", ".") > 9999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COSTOCPOPRODUCIDOVALOR");
               AnyError = 1;
               GX_FocusControl = edtCOSTOCPOPRODUCIDOValor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A191COSTOCPOPRODUCIDOValor = 0;
               AssignAttri("", false, "A191COSTOCPOPRODUCIDOValor", StringUtil.LTrimStr( A191COSTOCPOPRODUCIDOValor, 10, 2));
            }
            else
            {
               A191COSTOCPOPRODUCIDOValor = context.localUtil.CToN( cgiGet( edtCOSTOCPOPRODUCIDOValor_Internalname), ",", ".");
               AssignAttri("", false, "A191COSTOCPOPRODUCIDOValor", StringUtil.LTrimStr( A191COSTOCPOPRODUCIDOValor, 10, 2));
            }
            A192COSTOCPOPRODUCIDOUser = cgiGet( edtCOSTOCPOPRODUCIDOUser_Internalname);
            AssignAttri("", false, "A192COSTOCPOPRODUCIDOUser", A192COSTOCPOPRODUCIDOUser);
            if ( context.localUtil.VCDate( cgiGet( edtCOSTOCPOPRODUCIDOReg_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"COSTOCPOPRODUCIDOReg"}), 1, "COSTOCPOPRODUCIDOREG");
               AnyError = 1;
               GX_FocusControl = edtCOSTOCPOPRODUCIDOReg_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A193COSTOCPOPRODUCIDOReg = DateTime.MinValue;
               AssignAttri("", false, "A193COSTOCPOPRODUCIDOReg", context.localUtil.Format(A193COSTOCPOPRODUCIDOReg, "99/99/99"));
            }
            else
            {
               A193COSTOCPOPRODUCIDOReg = context.localUtil.CToD( cgiGet( edtCOSTOCPOPRODUCIDOReg_Internalname), 2);
               AssignAttri("", false, "A193COSTOCPOPRODUCIDOReg", context.localUtil.Format(A193COSTOCPOPRODUCIDOReg, "99/99/99"));
            }
            A194COSTOCPOPRODUCIDOHor = cgiGet( edtCOSTOCPOPRODUCIDOHor_Internalname);
            AssignAttri("", false, "A194COSTOCPOPRODUCIDOHor", A194COSTOCPOPRODUCIDOHor);
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
               A109COSTOCPOPRODUCIDOFecha = context.localUtil.ParseDateParm( GetPar( "COSTOCPOPRODUCIDOFecha"));
               AssignAttri("", false, "A109COSTOCPOPRODUCIDOFecha", context.localUtil.Format(A109COSTOCPOPRODUCIDOFecha, "99/99/99"));
               A110COSTOCPOPRODUCIDOMes = (short)(Math.Round(NumberUtil.Val( GetPar( "COSTOCPOPRODUCIDOMes"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A110COSTOCPOPRODUCIDOMes", StringUtil.LTrimStr( (decimal)(A110COSTOCPOPRODUCIDOMes), 4, 0));
               A111COSTOCPOPRODUCIDOAno = (short)(Math.Round(NumberUtil.Val( GetPar( "COSTOCPOPRODUCIDOAno"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A111COSTOCPOPRODUCIDOAno", StringUtil.LTrimStr( (decimal)(A111COSTOCPOPRODUCIDOAno), 4, 0));
               A5Cod_Area = GetPar( "Cod_Area");
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               A4IndicadoresCodigo = GetPar( "IndicadoresCodigo");
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               A64TIPOSCPOCod = GetPar( "TIPOSCPOCod");
               AssignAttri("", false, "A64TIPOSCPOCod", A64TIPOSCPOCod);
               A45TipoProductoCod = GetPar( "TipoProductoCod");
               AssignAttri("", false, "A45TipoProductoCod", A45TipoProductoCod);
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
               InitAll0Y35( ) ;
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
         DisableAttributes0Y35( ) ;
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

      protected void ResetCaption0Y0( )
      {
      }

      protected void ZM0Y35( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z191COSTOCPOPRODUCIDOValor = T000Y3_A191COSTOCPOPRODUCIDOValor[0];
               Z192COSTOCPOPRODUCIDOUser = T000Y3_A192COSTOCPOPRODUCIDOUser[0];
               Z193COSTOCPOPRODUCIDOReg = T000Y3_A193COSTOCPOPRODUCIDOReg[0];
               Z194COSTOCPOPRODUCIDOHor = T000Y3_A194COSTOCPOPRODUCIDOHor[0];
            }
            else
            {
               Z191COSTOCPOPRODUCIDOValor = A191COSTOCPOPRODUCIDOValor;
               Z192COSTOCPOPRODUCIDOUser = A192COSTOCPOPRODUCIDOUser;
               Z193COSTOCPOPRODUCIDOReg = A193COSTOCPOPRODUCIDOReg;
               Z194COSTOCPOPRODUCIDOHor = A194COSTOCPOPRODUCIDOHor;
            }
         }
         if ( GX_JID == -3 )
         {
            Z109COSTOCPOPRODUCIDOFecha = A109COSTOCPOPRODUCIDOFecha;
            Z110COSTOCPOPRODUCIDOMes = A110COSTOCPOPRODUCIDOMes;
            Z111COSTOCPOPRODUCIDOAno = A111COSTOCPOPRODUCIDOAno;
            Z191COSTOCPOPRODUCIDOValor = A191COSTOCPOPRODUCIDOValor;
            Z192COSTOCPOPRODUCIDOUser = A192COSTOCPOPRODUCIDOUser;
            Z193COSTOCPOPRODUCIDOReg = A193COSTOCPOPRODUCIDOReg;
            Z194COSTOCPOPRODUCIDOHor = A194COSTOCPOPRODUCIDOHor;
            Z5Cod_Area = A5Cod_Area;
            Z4IndicadoresCodigo = A4IndicadoresCodigo;
            Z64TIPOSCPOCod = A64TIPOSCPOCod;
            Z45TipoProductoCod = A45TipoProductoCod;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_5_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"COD_AREA"+"'), id:'"+"COD_AREA"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"true"+");");
         imgprompt_4_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0030.aspx"+"',["+"{Ctrl:gx.dom.el('"+"INDICADORESCODIGO"+"'), id:'"+"INDICADORESCODIGO"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"true"+");");
         imgprompt_64_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx00y0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"TIPOSCPOCOD"+"'), id:'"+"TIPOSCPOCOD"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"true"+");");
         imgprompt_45_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx00l0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"TIPOPRODUCTOCOD"+"'), id:'"+"TIPOPRODUCTOCOD"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");");
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

      protected void Load0Y35( )
      {
         /* Using cursor T000Y8 */
         pr_default.execute(6, new Object[] {A109COSTOCPOPRODUCIDOFecha, A110COSTOCPOPRODUCIDOMes, A111COSTOCPOPRODUCIDOAno, A5Cod_Area, A4IndicadoresCodigo, A64TIPOSCPOCod, A45TipoProductoCod});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound35 = 1;
            A191COSTOCPOPRODUCIDOValor = T000Y8_A191COSTOCPOPRODUCIDOValor[0];
            AssignAttri("", false, "A191COSTOCPOPRODUCIDOValor", StringUtil.LTrimStr( A191COSTOCPOPRODUCIDOValor, 10, 2));
            A192COSTOCPOPRODUCIDOUser = T000Y8_A192COSTOCPOPRODUCIDOUser[0];
            AssignAttri("", false, "A192COSTOCPOPRODUCIDOUser", A192COSTOCPOPRODUCIDOUser);
            A193COSTOCPOPRODUCIDOReg = T000Y8_A193COSTOCPOPRODUCIDOReg[0];
            AssignAttri("", false, "A193COSTOCPOPRODUCIDOReg", context.localUtil.Format(A193COSTOCPOPRODUCIDOReg, "99/99/99"));
            A194COSTOCPOPRODUCIDOHor = T000Y8_A194COSTOCPOPRODUCIDOHor[0];
            AssignAttri("", false, "A194COSTOCPOPRODUCIDOHor", A194COSTOCPOPRODUCIDOHor);
            ZM0Y35( -3) ;
         }
         pr_default.close(6);
         OnLoadActions0Y35( ) ;
      }

      protected void OnLoadActions0Y35( )
      {
      }

      protected void CheckExtendedTable0Y35( )
      {
         nIsDirty_35 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A109COSTOCPOPRODUCIDOFecha) || ( DateTimeUtil.ResetTime ( A109COSTOCPOPRODUCIDOFecha ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo COSTOCPOPRODUCIDOFecha fuera de rango", "OutOfRange", 1, "COSTOCPOPRODUCIDOFECHA");
            AnyError = 1;
            GX_FocusControl = edtCOSTOCPOPRODUCIDOFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000Y4 */
         pr_default.execute(2, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T000Y5 */
         pr_default.execute(3, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         /* Using cursor T000Y6 */
         pr_default.execute(4, new Object[] {A64TIPOSCPOCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'TIPOSCPO'.", "ForeignKeyNotFound", 1, "TIPOSCPOCOD");
            AnyError = 1;
            GX_FocusControl = edtTIPOSCPOCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(4);
         /* Using cursor T000Y7 */
         pr_default.execute(5, new Object[] {A45TipoProductoCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo Producto'.", "ForeignKeyNotFound", 1, "TIPOPRODUCTOCOD");
            AnyError = 1;
            GX_FocusControl = edtTipoProductoCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(5);
         if ( ! ( (DateTime.MinValue==A193COSTOCPOPRODUCIDOReg) || ( DateTimeUtil.ResetTime ( A193COSTOCPOPRODUCIDOReg ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo COSTOCPOPRODUCIDOReg fuera de rango", "OutOfRange", 1, "COSTOCPOPRODUCIDOREG");
            AnyError = 1;
            GX_FocusControl = edtCOSTOCPOPRODUCIDOReg_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0Y35( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_4( string A5Cod_Area )
      {
         /* Using cursor T000Y9 */
         pr_default.execute(7, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
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

      protected void gxLoad_5( string A4IndicadoresCodigo )
      {
         /* Using cursor T000Y10 */
         pr_default.execute(8, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
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

      protected void gxLoad_6( string A64TIPOSCPOCod )
      {
         /* Using cursor T000Y11 */
         pr_default.execute(9, new Object[] {A64TIPOSCPOCod});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No existe 'TIPOSCPO'.", "ForeignKeyNotFound", 1, "TIPOSCPOCOD");
            AnyError = 1;
            GX_FocusControl = edtTIPOSCPOCod_Internalname;
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

      protected void gxLoad_7( string A45TipoProductoCod )
      {
         /* Using cursor T000Y12 */
         pr_default.execute(10, new Object[] {A45TipoProductoCod});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo Producto'.", "ForeignKeyNotFound", 1, "TIPOPRODUCTOCOD");
            AnyError = 1;
            GX_FocusControl = edtTipoProductoCod_Internalname;
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

      protected void GetKey0Y35( )
      {
         /* Using cursor T000Y13 */
         pr_default.execute(11, new Object[] {A109COSTOCPOPRODUCIDOFecha, A110COSTOCPOPRODUCIDOMes, A111COSTOCPOPRODUCIDOAno, A5Cod_Area, A4IndicadoresCodigo, A64TIPOSCPOCod, A45TipoProductoCod});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound35 = 1;
         }
         else
         {
            RcdFound35 = 0;
         }
         pr_default.close(11);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000Y3 */
         pr_default.execute(1, new Object[] {A109COSTOCPOPRODUCIDOFecha, A110COSTOCPOPRODUCIDOMes, A111COSTOCPOPRODUCIDOAno, A5Cod_Area, A4IndicadoresCodigo, A64TIPOSCPOCod, A45TipoProductoCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0Y35( 3) ;
            RcdFound35 = 1;
            A109COSTOCPOPRODUCIDOFecha = T000Y3_A109COSTOCPOPRODUCIDOFecha[0];
            AssignAttri("", false, "A109COSTOCPOPRODUCIDOFecha", context.localUtil.Format(A109COSTOCPOPRODUCIDOFecha, "99/99/99"));
            A110COSTOCPOPRODUCIDOMes = T000Y3_A110COSTOCPOPRODUCIDOMes[0];
            AssignAttri("", false, "A110COSTOCPOPRODUCIDOMes", StringUtil.LTrimStr( (decimal)(A110COSTOCPOPRODUCIDOMes), 4, 0));
            A111COSTOCPOPRODUCIDOAno = T000Y3_A111COSTOCPOPRODUCIDOAno[0];
            AssignAttri("", false, "A111COSTOCPOPRODUCIDOAno", StringUtil.LTrimStr( (decimal)(A111COSTOCPOPRODUCIDOAno), 4, 0));
            A191COSTOCPOPRODUCIDOValor = T000Y3_A191COSTOCPOPRODUCIDOValor[0];
            AssignAttri("", false, "A191COSTOCPOPRODUCIDOValor", StringUtil.LTrimStr( A191COSTOCPOPRODUCIDOValor, 10, 2));
            A192COSTOCPOPRODUCIDOUser = T000Y3_A192COSTOCPOPRODUCIDOUser[0];
            AssignAttri("", false, "A192COSTOCPOPRODUCIDOUser", A192COSTOCPOPRODUCIDOUser);
            A193COSTOCPOPRODUCIDOReg = T000Y3_A193COSTOCPOPRODUCIDOReg[0];
            AssignAttri("", false, "A193COSTOCPOPRODUCIDOReg", context.localUtil.Format(A193COSTOCPOPRODUCIDOReg, "99/99/99"));
            A194COSTOCPOPRODUCIDOHor = T000Y3_A194COSTOCPOPRODUCIDOHor[0];
            AssignAttri("", false, "A194COSTOCPOPRODUCIDOHor", A194COSTOCPOPRODUCIDOHor);
            A5Cod_Area = T000Y3_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = T000Y3_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A64TIPOSCPOCod = T000Y3_A64TIPOSCPOCod[0];
            AssignAttri("", false, "A64TIPOSCPOCod", A64TIPOSCPOCod);
            A45TipoProductoCod = T000Y3_A45TipoProductoCod[0];
            AssignAttri("", false, "A45TipoProductoCod", A45TipoProductoCod);
            Z109COSTOCPOPRODUCIDOFecha = A109COSTOCPOPRODUCIDOFecha;
            Z110COSTOCPOPRODUCIDOMes = A110COSTOCPOPRODUCIDOMes;
            Z111COSTOCPOPRODUCIDOAno = A111COSTOCPOPRODUCIDOAno;
            Z5Cod_Area = A5Cod_Area;
            Z4IndicadoresCodigo = A4IndicadoresCodigo;
            Z64TIPOSCPOCod = A64TIPOSCPOCod;
            Z45TipoProductoCod = A45TipoProductoCod;
            sMode35 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0Y35( ) ;
            if ( AnyError == 1 )
            {
               RcdFound35 = 0;
               InitializeNonKey0Y35( ) ;
            }
            Gx_mode = sMode35;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound35 = 0;
            InitializeNonKey0Y35( ) ;
            sMode35 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode35;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0Y35( ) ;
         if ( RcdFound35 == 0 )
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
         RcdFound35 = 0;
         /* Using cursor T000Y14 */
         pr_default.execute(12, new Object[] {A109COSTOCPOPRODUCIDOFecha, A110COSTOCPOPRODUCIDOMes, A111COSTOCPOPRODUCIDOAno, A5Cod_Area, A4IndicadoresCodigo, A64TIPOSCPOCod, A45TipoProductoCod});
         if ( (pr_default.getStatus(12) != 101) )
         {
            while ( (pr_default.getStatus(12) != 101) && ( ( DateTimeUtil.ResetTime ( T000Y14_A109COSTOCPOPRODUCIDOFecha[0] ) < DateTimeUtil.ResetTime ( A109COSTOCPOPRODUCIDOFecha ) ) || ( DateTimeUtil.ResetTime ( T000Y14_A109COSTOCPOPRODUCIDOFecha[0] ) == DateTimeUtil.ResetTime ( A109COSTOCPOPRODUCIDOFecha ) ) && ( T000Y14_A110COSTOCPOPRODUCIDOMes[0] < A110COSTOCPOPRODUCIDOMes ) ||
            ( T000Y14_A110COSTOCPOPRODUCIDOMes[0] == A110COSTOCPOPRODUCIDOMes ) && ( DateTimeUtil.ResetTime ( T000Y14_A109COSTOCPOPRODUCIDOFecha[0] ) == DateTimeUtil.ResetTime ( A109COSTOCPOPRODUCIDOFecha ) ) && ( T000Y14_A111COSTOCPOPRODUCIDOAno[0] < A111COSTOCPOPRODUCIDOAno ) || ( T000Y14_A111COSTOCPOPRODUCIDOAno[0] == A111COSTOCPOPRODUCIDOAno ) && ( T000Y14_A110COSTOCPOPRODUCIDOMes[0] ==
            A110COSTOCPOPRODUCIDOMes ) && ( DateTimeUtil.ResetTime ( T000Y14_A109COSTOCPOPRODUCIDOFecha[0] ) == DateTimeUtil.ResetTime ( A109COSTOCPOPRODUCIDOFecha ) ) && ( StringUtil.StrCmp(T000Y14_A5Cod_Area[0], A5Cod_Area) < 0 ) || ( StringUtil.StrCmp(T000Y14_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000Y14_A111COSTOCPOPRODUCIDOAno[0] == A111COSTOCPOPRODUCIDOAno ) && ( T000Y14_A110COSTOCPOPRODUCIDOMes[0] ==
            A110COSTOCPOPRODUCIDOMes ) && ( DateTimeUtil.ResetTime ( T000Y14_A109COSTOCPOPRODUCIDOFecha[0] ) == DateTimeUtil.ResetTime ( A109COSTOCPOPRODUCIDOFecha ) ) && ( StringUtil.StrCmp(T000Y14_A4IndicadoresCodigo[0], A4IndicadoresCodigo) < 0 ) || ( StringUtil.StrCmp(T000Y14_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T000Y14_A5Cod_Area[0], A5Cod_Area) == 0 ) &&
            ( T000Y14_A111COSTOCPOPRODUCIDOAno[0] == A111COSTOCPOPRODUCIDOAno ) && ( T000Y14_A110COSTOCPOPRODUCIDOMes[0] == A110COSTOCPOPRODUCIDOMes ) && ( DateTimeUtil.ResetTime ( T000Y14_A109COSTOCPOPRODUCIDOFecha[0] ) == DateTimeUtil.ResetTime ( A109COSTOCPOPRODUCIDOFecha ) ) && ( StringUtil.StrCmp(T000Y14_A64TIPOSCPOCod[0], A64TIPOSCPOCod) < 0 ) ||
            ( StringUtil.StrCmp(T000Y14_A64TIPOSCPOCod[0], A64TIPOSCPOCod) == 0 ) && ( StringUtil.StrCmp(T000Y14_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T000Y14_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000Y14_A111COSTOCPOPRODUCIDOAno[0] == A111COSTOCPOPRODUCIDOAno ) && ( T000Y14_A110COSTOCPOPRODUCIDOMes[0] == A110COSTOCPOPRODUCIDOMes ) &&
            ( DateTimeUtil.ResetTime ( T000Y14_A109COSTOCPOPRODUCIDOFecha[0] ) == DateTimeUtil.ResetTime ( A109COSTOCPOPRODUCIDOFecha ) ) && ( StringUtil.StrCmp(T000Y14_A45TipoProductoCod[0], A45TipoProductoCod) < 0 ) )
            )
            {
               pr_default.readNext(12);
            }
            if ( (pr_default.getStatus(12) != 101) && ( ( DateTimeUtil.ResetTime ( T000Y14_A109COSTOCPOPRODUCIDOFecha[0] ) > DateTimeUtil.ResetTime ( A109COSTOCPOPRODUCIDOFecha ) ) || ( DateTimeUtil.ResetTime ( T000Y14_A109COSTOCPOPRODUCIDOFecha[0] ) == DateTimeUtil.ResetTime ( A109COSTOCPOPRODUCIDOFecha ) ) && ( T000Y14_A110COSTOCPOPRODUCIDOMes[0] > A110COSTOCPOPRODUCIDOMes ) ||
            ( T000Y14_A110COSTOCPOPRODUCIDOMes[0] == A110COSTOCPOPRODUCIDOMes ) && ( DateTimeUtil.ResetTime ( T000Y14_A109COSTOCPOPRODUCIDOFecha[0] ) == DateTimeUtil.ResetTime ( A109COSTOCPOPRODUCIDOFecha ) ) && ( T000Y14_A111COSTOCPOPRODUCIDOAno[0] > A111COSTOCPOPRODUCIDOAno ) || ( T000Y14_A111COSTOCPOPRODUCIDOAno[0] == A111COSTOCPOPRODUCIDOAno ) && ( T000Y14_A110COSTOCPOPRODUCIDOMes[0] ==
            A110COSTOCPOPRODUCIDOMes ) && ( DateTimeUtil.ResetTime ( T000Y14_A109COSTOCPOPRODUCIDOFecha[0] ) == DateTimeUtil.ResetTime ( A109COSTOCPOPRODUCIDOFecha ) ) && ( StringUtil.StrCmp(T000Y14_A5Cod_Area[0], A5Cod_Area) > 0 ) || ( StringUtil.StrCmp(T000Y14_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000Y14_A111COSTOCPOPRODUCIDOAno[0] == A111COSTOCPOPRODUCIDOAno ) && ( T000Y14_A110COSTOCPOPRODUCIDOMes[0] ==
            A110COSTOCPOPRODUCIDOMes ) && ( DateTimeUtil.ResetTime ( T000Y14_A109COSTOCPOPRODUCIDOFecha[0] ) == DateTimeUtil.ResetTime ( A109COSTOCPOPRODUCIDOFecha ) ) && ( StringUtil.StrCmp(T000Y14_A4IndicadoresCodigo[0], A4IndicadoresCodigo) > 0 ) || ( StringUtil.StrCmp(T000Y14_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T000Y14_A5Cod_Area[0], A5Cod_Area) == 0 ) &&
            ( T000Y14_A111COSTOCPOPRODUCIDOAno[0] == A111COSTOCPOPRODUCIDOAno ) && ( T000Y14_A110COSTOCPOPRODUCIDOMes[0] == A110COSTOCPOPRODUCIDOMes ) && ( DateTimeUtil.ResetTime ( T000Y14_A109COSTOCPOPRODUCIDOFecha[0] ) == DateTimeUtil.ResetTime ( A109COSTOCPOPRODUCIDOFecha ) ) && ( StringUtil.StrCmp(T000Y14_A64TIPOSCPOCod[0], A64TIPOSCPOCod) > 0 ) ||
            ( StringUtil.StrCmp(T000Y14_A64TIPOSCPOCod[0], A64TIPOSCPOCod) == 0 ) && ( StringUtil.StrCmp(T000Y14_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T000Y14_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000Y14_A111COSTOCPOPRODUCIDOAno[0] == A111COSTOCPOPRODUCIDOAno ) && ( T000Y14_A110COSTOCPOPRODUCIDOMes[0] == A110COSTOCPOPRODUCIDOMes ) &&
            ( DateTimeUtil.ResetTime ( T000Y14_A109COSTOCPOPRODUCIDOFecha[0] ) == DateTimeUtil.ResetTime ( A109COSTOCPOPRODUCIDOFecha ) ) && ( StringUtil.StrCmp(T000Y14_A45TipoProductoCod[0], A45TipoProductoCod) > 0 ) )
            )
            {
               A109COSTOCPOPRODUCIDOFecha = T000Y14_A109COSTOCPOPRODUCIDOFecha[0];
               AssignAttri("", false, "A109COSTOCPOPRODUCIDOFecha", context.localUtil.Format(A109COSTOCPOPRODUCIDOFecha, "99/99/99"));
               A110COSTOCPOPRODUCIDOMes = T000Y14_A110COSTOCPOPRODUCIDOMes[0];
               AssignAttri("", false, "A110COSTOCPOPRODUCIDOMes", StringUtil.LTrimStr( (decimal)(A110COSTOCPOPRODUCIDOMes), 4, 0));
               A111COSTOCPOPRODUCIDOAno = T000Y14_A111COSTOCPOPRODUCIDOAno[0];
               AssignAttri("", false, "A111COSTOCPOPRODUCIDOAno", StringUtil.LTrimStr( (decimal)(A111COSTOCPOPRODUCIDOAno), 4, 0));
               A5Cod_Area = T000Y14_A5Cod_Area[0];
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               A4IndicadoresCodigo = T000Y14_A4IndicadoresCodigo[0];
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               A64TIPOSCPOCod = T000Y14_A64TIPOSCPOCod[0];
               AssignAttri("", false, "A64TIPOSCPOCod", A64TIPOSCPOCod);
               A45TipoProductoCod = T000Y14_A45TipoProductoCod[0];
               AssignAttri("", false, "A45TipoProductoCod", A45TipoProductoCod);
               RcdFound35 = 1;
            }
         }
         pr_default.close(12);
      }

      protected void move_previous( )
      {
         RcdFound35 = 0;
         /* Using cursor T000Y15 */
         pr_default.execute(13, new Object[] {A109COSTOCPOPRODUCIDOFecha, A110COSTOCPOPRODUCIDOMes, A111COSTOCPOPRODUCIDOAno, A5Cod_Area, A4IndicadoresCodigo, A64TIPOSCPOCod, A45TipoProductoCod});
         if ( (pr_default.getStatus(13) != 101) )
         {
            while ( (pr_default.getStatus(13) != 101) && ( ( DateTimeUtil.ResetTime ( T000Y15_A109COSTOCPOPRODUCIDOFecha[0] ) > DateTimeUtil.ResetTime ( A109COSTOCPOPRODUCIDOFecha ) ) || ( DateTimeUtil.ResetTime ( T000Y15_A109COSTOCPOPRODUCIDOFecha[0] ) == DateTimeUtil.ResetTime ( A109COSTOCPOPRODUCIDOFecha ) ) && ( T000Y15_A110COSTOCPOPRODUCIDOMes[0] > A110COSTOCPOPRODUCIDOMes ) ||
            ( T000Y15_A110COSTOCPOPRODUCIDOMes[0] == A110COSTOCPOPRODUCIDOMes ) && ( DateTimeUtil.ResetTime ( T000Y15_A109COSTOCPOPRODUCIDOFecha[0] ) == DateTimeUtil.ResetTime ( A109COSTOCPOPRODUCIDOFecha ) ) && ( T000Y15_A111COSTOCPOPRODUCIDOAno[0] > A111COSTOCPOPRODUCIDOAno ) || ( T000Y15_A111COSTOCPOPRODUCIDOAno[0] == A111COSTOCPOPRODUCIDOAno ) && ( T000Y15_A110COSTOCPOPRODUCIDOMes[0] ==
            A110COSTOCPOPRODUCIDOMes ) && ( DateTimeUtil.ResetTime ( T000Y15_A109COSTOCPOPRODUCIDOFecha[0] ) == DateTimeUtil.ResetTime ( A109COSTOCPOPRODUCIDOFecha ) ) && ( StringUtil.StrCmp(T000Y15_A5Cod_Area[0], A5Cod_Area) > 0 ) || ( StringUtil.StrCmp(T000Y15_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000Y15_A111COSTOCPOPRODUCIDOAno[0] == A111COSTOCPOPRODUCIDOAno ) && ( T000Y15_A110COSTOCPOPRODUCIDOMes[0] ==
            A110COSTOCPOPRODUCIDOMes ) && ( DateTimeUtil.ResetTime ( T000Y15_A109COSTOCPOPRODUCIDOFecha[0] ) == DateTimeUtil.ResetTime ( A109COSTOCPOPRODUCIDOFecha ) ) && ( StringUtil.StrCmp(T000Y15_A4IndicadoresCodigo[0], A4IndicadoresCodigo) > 0 ) || ( StringUtil.StrCmp(T000Y15_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T000Y15_A5Cod_Area[0], A5Cod_Area) == 0 ) &&
            ( T000Y15_A111COSTOCPOPRODUCIDOAno[0] == A111COSTOCPOPRODUCIDOAno ) && ( T000Y15_A110COSTOCPOPRODUCIDOMes[0] == A110COSTOCPOPRODUCIDOMes ) && ( DateTimeUtil.ResetTime ( T000Y15_A109COSTOCPOPRODUCIDOFecha[0] ) == DateTimeUtil.ResetTime ( A109COSTOCPOPRODUCIDOFecha ) ) && ( StringUtil.StrCmp(T000Y15_A64TIPOSCPOCod[0], A64TIPOSCPOCod) > 0 ) ||
            ( StringUtil.StrCmp(T000Y15_A64TIPOSCPOCod[0], A64TIPOSCPOCod) == 0 ) && ( StringUtil.StrCmp(T000Y15_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T000Y15_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000Y15_A111COSTOCPOPRODUCIDOAno[0] == A111COSTOCPOPRODUCIDOAno ) && ( T000Y15_A110COSTOCPOPRODUCIDOMes[0] == A110COSTOCPOPRODUCIDOMes ) &&
            ( DateTimeUtil.ResetTime ( T000Y15_A109COSTOCPOPRODUCIDOFecha[0] ) == DateTimeUtil.ResetTime ( A109COSTOCPOPRODUCIDOFecha ) ) && ( StringUtil.StrCmp(T000Y15_A45TipoProductoCod[0], A45TipoProductoCod) > 0 ) )
            )
            {
               pr_default.readNext(13);
            }
            if ( (pr_default.getStatus(13) != 101) && ( ( DateTimeUtil.ResetTime ( T000Y15_A109COSTOCPOPRODUCIDOFecha[0] ) < DateTimeUtil.ResetTime ( A109COSTOCPOPRODUCIDOFecha ) ) || ( DateTimeUtil.ResetTime ( T000Y15_A109COSTOCPOPRODUCIDOFecha[0] ) == DateTimeUtil.ResetTime ( A109COSTOCPOPRODUCIDOFecha ) ) && ( T000Y15_A110COSTOCPOPRODUCIDOMes[0] < A110COSTOCPOPRODUCIDOMes ) ||
            ( T000Y15_A110COSTOCPOPRODUCIDOMes[0] == A110COSTOCPOPRODUCIDOMes ) && ( DateTimeUtil.ResetTime ( T000Y15_A109COSTOCPOPRODUCIDOFecha[0] ) == DateTimeUtil.ResetTime ( A109COSTOCPOPRODUCIDOFecha ) ) && ( T000Y15_A111COSTOCPOPRODUCIDOAno[0] < A111COSTOCPOPRODUCIDOAno ) || ( T000Y15_A111COSTOCPOPRODUCIDOAno[0] == A111COSTOCPOPRODUCIDOAno ) && ( T000Y15_A110COSTOCPOPRODUCIDOMes[0] ==
            A110COSTOCPOPRODUCIDOMes ) && ( DateTimeUtil.ResetTime ( T000Y15_A109COSTOCPOPRODUCIDOFecha[0] ) == DateTimeUtil.ResetTime ( A109COSTOCPOPRODUCIDOFecha ) ) && ( StringUtil.StrCmp(T000Y15_A5Cod_Area[0], A5Cod_Area) < 0 ) || ( StringUtil.StrCmp(T000Y15_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000Y15_A111COSTOCPOPRODUCIDOAno[0] == A111COSTOCPOPRODUCIDOAno ) && ( T000Y15_A110COSTOCPOPRODUCIDOMes[0] ==
            A110COSTOCPOPRODUCIDOMes ) && ( DateTimeUtil.ResetTime ( T000Y15_A109COSTOCPOPRODUCIDOFecha[0] ) == DateTimeUtil.ResetTime ( A109COSTOCPOPRODUCIDOFecha ) ) && ( StringUtil.StrCmp(T000Y15_A4IndicadoresCodigo[0], A4IndicadoresCodigo) < 0 ) || ( StringUtil.StrCmp(T000Y15_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T000Y15_A5Cod_Area[0], A5Cod_Area) == 0 ) &&
            ( T000Y15_A111COSTOCPOPRODUCIDOAno[0] == A111COSTOCPOPRODUCIDOAno ) && ( T000Y15_A110COSTOCPOPRODUCIDOMes[0] == A110COSTOCPOPRODUCIDOMes ) && ( DateTimeUtil.ResetTime ( T000Y15_A109COSTOCPOPRODUCIDOFecha[0] ) == DateTimeUtil.ResetTime ( A109COSTOCPOPRODUCIDOFecha ) ) && ( StringUtil.StrCmp(T000Y15_A64TIPOSCPOCod[0], A64TIPOSCPOCod) < 0 ) ||
            ( StringUtil.StrCmp(T000Y15_A64TIPOSCPOCod[0], A64TIPOSCPOCod) == 0 ) && ( StringUtil.StrCmp(T000Y15_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T000Y15_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000Y15_A111COSTOCPOPRODUCIDOAno[0] == A111COSTOCPOPRODUCIDOAno ) && ( T000Y15_A110COSTOCPOPRODUCIDOMes[0] == A110COSTOCPOPRODUCIDOMes ) &&
            ( DateTimeUtil.ResetTime ( T000Y15_A109COSTOCPOPRODUCIDOFecha[0] ) == DateTimeUtil.ResetTime ( A109COSTOCPOPRODUCIDOFecha ) ) && ( StringUtil.StrCmp(T000Y15_A45TipoProductoCod[0], A45TipoProductoCod) < 0 ) )
            )
            {
               A109COSTOCPOPRODUCIDOFecha = T000Y15_A109COSTOCPOPRODUCIDOFecha[0];
               AssignAttri("", false, "A109COSTOCPOPRODUCIDOFecha", context.localUtil.Format(A109COSTOCPOPRODUCIDOFecha, "99/99/99"));
               A110COSTOCPOPRODUCIDOMes = T000Y15_A110COSTOCPOPRODUCIDOMes[0];
               AssignAttri("", false, "A110COSTOCPOPRODUCIDOMes", StringUtil.LTrimStr( (decimal)(A110COSTOCPOPRODUCIDOMes), 4, 0));
               A111COSTOCPOPRODUCIDOAno = T000Y15_A111COSTOCPOPRODUCIDOAno[0];
               AssignAttri("", false, "A111COSTOCPOPRODUCIDOAno", StringUtil.LTrimStr( (decimal)(A111COSTOCPOPRODUCIDOAno), 4, 0));
               A5Cod_Area = T000Y15_A5Cod_Area[0];
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               A4IndicadoresCodigo = T000Y15_A4IndicadoresCodigo[0];
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               A64TIPOSCPOCod = T000Y15_A64TIPOSCPOCod[0];
               AssignAttri("", false, "A64TIPOSCPOCod", A64TIPOSCPOCod);
               A45TipoProductoCod = T000Y15_A45TipoProductoCod[0];
               AssignAttri("", false, "A45TipoProductoCod", A45TipoProductoCod);
               RcdFound35 = 1;
            }
         }
         pr_default.close(13);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0Y35( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCOSTOCPOPRODUCIDOFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0Y35( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound35 == 1 )
            {
               if ( ( DateTimeUtil.ResetTime ( A109COSTOCPOPRODUCIDOFecha ) != DateTimeUtil.ResetTime ( Z109COSTOCPOPRODUCIDOFecha ) ) || ( A110COSTOCPOPRODUCIDOMes != Z110COSTOCPOPRODUCIDOMes ) || ( A111COSTOCPOPRODUCIDOAno != Z111COSTOCPOPRODUCIDOAno ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) || ( StringUtil.StrCmp(A64TIPOSCPOCod, Z64TIPOSCPOCod) != 0 ) || ( StringUtil.StrCmp(A45TipoProductoCod, Z45TipoProductoCod) != 0 ) )
               {
                  A109COSTOCPOPRODUCIDOFecha = Z109COSTOCPOPRODUCIDOFecha;
                  AssignAttri("", false, "A109COSTOCPOPRODUCIDOFecha", context.localUtil.Format(A109COSTOCPOPRODUCIDOFecha, "99/99/99"));
                  A110COSTOCPOPRODUCIDOMes = Z110COSTOCPOPRODUCIDOMes;
                  AssignAttri("", false, "A110COSTOCPOPRODUCIDOMes", StringUtil.LTrimStr( (decimal)(A110COSTOCPOPRODUCIDOMes), 4, 0));
                  A111COSTOCPOPRODUCIDOAno = Z111COSTOCPOPRODUCIDOAno;
                  AssignAttri("", false, "A111COSTOCPOPRODUCIDOAno", StringUtil.LTrimStr( (decimal)(A111COSTOCPOPRODUCIDOAno), 4, 0));
                  A5Cod_Area = Z5Cod_Area;
                  AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
                  A4IndicadoresCodigo = Z4IndicadoresCodigo;
                  AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
                  A64TIPOSCPOCod = Z64TIPOSCPOCod;
                  AssignAttri("", false, "A64TIPOSCPOCod", A64TIPOSCPOCod);
                  A45TipoProductoCod = Z45TipoProductoCod;
                  AssignAttri("", false, "A45TipoProductoCod", A45TipoProductoCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "COSTOCPOPRODUCIDOFECHA");
                  AnyError = 1;
                  GX_FocusControl = edtCOSTOCPOPRODUCIDOFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCOSTOCPOPRODUCIDOFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0Y35( ) ;
                  GX_FocusControl = edtCOSTOCPOPRODUCIDOFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( DateTimeUtil.ResetTime ( A109COSTOCPOPRODUCIDOFecha ) != DateTimeUtil.ResetTime ( Z109COSTOCPOPRODUCIDOFecha ) ) || ( A110COSTOCPOPRODUCIDOMes != Z110COSTOCPOPRODUCIDOMes ) || ( A111COSTOCPOPRODUCIDOAno != Z111COSTOCPOPRODUCIDOAno ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) || ( StringUtil.StrCmp(A64TIPOSCPOCod, Z64TIPOSCPOCod) != 0 ) || ( StringUtil.StrCmp(A45TipoProductoCod, Z45TipoProductoCod) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtCOSTOCPOPRODUCIDOFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0Y35( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "COSTOCPOPRODUCIDOFECHA");
                     AnyError = 1;
                     GX_FocusControl = edtCOSTOCPOPRODUCIDOFecha_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtCOSTOCPOPRODUCIDOFecha_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0Y35( ) ;
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
         if ( ( DateTimeUtil.ResetTime ( A109COSTOCPOPRODUCIDOFecha ) != DateTimeUtil.ResetTime ( Z109COSTOCPOPRODUCIDOFecha ) ) || ( A110COSTOCPOPRODUCIDOMes != Z110COSTOCPOPRODUCIDOMes ) || ( A111COSTOCPOPRODUCIDOAno != Z111COSTOCPOPRODUCIDOAno ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) || ( StringUtil.StrCmp(A64TIPOSCPOCod, Z64TIPOSCPOCod) != 0 ) || ( StringUtil.StrCmp(A45TipoProductoCod, Z45TipoProductoCod) != 0 ) )
         {
            A109COSTOCPOPRODUCIDOFecha = Z109COSTOCPOPRODUCIDOFecha;
            AssignAttri("", false, "A109COSTOCPOPRODUCIDOFecha", context.localUtil.Format(A109COSTOCPOPRODUCIDOFecha, "99/99/99"));
            A110COSTOCPOPRODUCIDOMes = Z110COSTOCPOPRODUCIDOMes;
            AssignAttri("", false, "A110COSTOCPOPRODUCIDOMes", StringUtil.LTrimStr( (decimal)(A110COSTOCPOPRODUCIDOMes), 4, 0));
            A111COSTOCPOPRODUCIDOAno = Z111COSTOCPOPRODUCIDOAno;
            AssignAttri("", false, "A111COSTOCPOPRODUCIDOAno", StringUtil.LTrimStr( (decimal)(A111COSTOCPOPRODUCIDOAno), 4, 0));
            A5Cod_Area = Z5Cod_Area;
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = Z4IndicadoresCodigo;
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A64TIPOSCPOCod = Z64TIPOSCPOCod;
            AssignAttri("", false, "A64TIPOSCPOCod", A64TIPOSCPOCod);
            A45TipoProductoCod = Z45TipoProductoCod;
            AssignAttri("", false, "A45TipoProductoCod", A45TipoProductoCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "COSTOCPOPRODUCIDOFECHA");
            AnyError = 1;
            GX_FocusControl = edtCOSTOCPOPRODUCIDOFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCOSTOCPOPRODUCIDOFecha_Internalname;
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
         if ( RcdFound35 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "COSTOCPOPRODUCIDOFECHA");
            AnyError = 1;
            GX_FocusControl = edtCOSTOCPOPRODUCIDOFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtCOSTOCPOPRODUCIDOValor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0Y35( ) ;
         if ( RcdFound35 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCOSTOCPOPRODUCIDOValor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0Y35( ) ;
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
         if ( RcdFound35 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCOSTOCPOPRODUCIDOValor_Internalname;
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
         if ( RcdFound35 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCOSTOCPOPRODUCIDOValor_Internalname;
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
         ScanStart0Y35( ) ;
         if ( RcdFound35 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound35 != 0 )
            {
               ScanNext0Y35( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCOSTOCPOPRODUCIDOValor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0Y35( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0Y35( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000Y2 */
            pr_default.execute(0, new Object[] {A109COSTOCPOPRODUCIDOFecha, A110COSTOCPOPRODUCIDOMes, A111COSTOCPOPRODUCIDOAno, A5Cod_Area, A4IndicadoresCodigo, A64TIPOSCPOCod, A45TipoProductoCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"COSTOCPOPRODUCIDO"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z191COSTOCPOPRODUCIDOValor != T000Y2_A191COSTOCPOPRODUCIDOValor[0] ) || ( StringUtil.StrCmp(Z192COSTOCPOPRODUCIDOUser, T000Y2_A192COSTOCPOPRODUCIDOUser[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z193COSTOCPOPRODUCIDOReg ) != DateTimeUtil.ResetTime ( T000Y2_A193COSTOCPOPRODUCIDOReg[0] ) ) || ( StringUtil.StrCmp(Z194COSTOCPOPRODUCIDOHor, T000Y2_A194COSTOCPOPRODUCIDOHor[0]) != 0 ) )
            {
               if ( Z191COSTOCPOPRODUCIDOValor != T000Y2_A191COSTOCPOPRODUCIDOValor[0] )
               {
                  GXUtil.WriteLog("costocpoproducido:[seudo value changed for attri]"+"COSTOCPOPRODUCIDOValor");
                  GXUtil.WriteLogRaw("Old: ",Z191COSTOCPOPRODUCIDOValor);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A191COSTOCPOPRODUCIDOValor[0]);
               }
               if ( StringUtil.StrCmp(Z192COSTOCPOPRODUCIDOUser, T000Y2_A192COSTOCPOPRODUCIDOUser[0]) != 0 )
               {
                  GXUtil.WriteLog("costocpoproducido:[seudo value changed for attri]"+"COSTOCPOPRODUCIDOUser");
                  GXUtil.WriteLogRaw("Old: ",Z192COSTOCPOPRODUCIDOUser);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A192COSTOCPOPRODUCIDOUser[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z193COSTOCPOPRODUCIDOReg ) != DateTimeUtil.ResetTime ( T000Y2_A193COSTOCPOPRODUCIDOReg[0] ) )
               {
                  GXUtil.WriteLog("costocpoproducido:[seudo value changed for attri]"+"COSTOCPOPRODUCIDOReg");
                  GXUtil.WriteLogRaw("Old: ",Z193COSTOCPOPRODUCIDOReg);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A193COSTOCPOPRODUCIDOReg[0]);
               }
               if ( StringUtil.StrCmp(Z194COSTOCPOPRODUCIDOHor, T000Y2_A194COSTOCPOPRODUCIDOHor[0]) != 0 )
               {
                  GXUtil.WriteLog("costocpoproducido:[seudo value changed for attri]"+"COSTOCPOPRODUCIDOHor");
                  GXUtil.WriteLogRaw("Old: ",Z194COSTOCPOPRODUCIDOHor);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A194COSTOCPOPRODUCIDOHor[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"COSTOCPOPRODUCIDO"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0Y35( )
      {
         BeforeValidate0Y35( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Y35( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0Y35( 0) ;
            CheckOptimisticConcurrency0Y35( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Y35( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0Y35( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000Y16 */
                     pr_default.execute(14, new Object[] {A109COSTOCPOPRODUCIDOFecha, A110COSTOCPOPRODUCIDOMes, A111COSTOCPOPRODUCIDOAno, A191COSTOCPOPRODUCIDOValor, A192COSTOCPOPRODUCIDOUser, A193COSTOCPOPRODUCIDOReg, A194COSTOCPOPRODUCIDOHor, A5Cod_Area, A4IndicadoresCodigo, A64TIPOSCPOCod, A45TipoProductoCod});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("COSTOCPOPRODUCIDO");
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
                           ResetCaption0Y0( ) ;
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
               Load0Y35( ) ;
            }
            EndLevel0Y35( ) ;
         }
         CloseExtendedTableCursors0Y35( ) ;
      }

      protected void Update0Y35( )
      {
         BeforeValidate0Y35( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Y35( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Y35( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Y35( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0Y35( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000Y17 */
                     pr_default.execute(15, new Object[] {A191COSTOCPOPRODUCIDOValor, A192COSTOCPOPRODUCIDOUser, A193COSTOCPOPRODUCIDOReg, A194COSTOCPOPRODUCIDOHor, A109COSTOCPOPRODUCIDOFecha, A110COSTOCPOPRODUCIDOMes, A111COSTOCPOPRODUCIDOAno, A5Cod_Area, A4IndicadoresCodigo, A64TIPOSCPOCod, A45TipoProductoCod});
                     pr_default.close(15);
                     pr_default.SmartCacheProvider.SetUpdated("COSTOCPOPRODUCIDO");
                     if ( (pr_default.getStatus(15) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"COSTOCPOPRODUCIDO"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0Y35( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0Y0( ) ;
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
            EndLevel0Y35( ) ;
         }
         CloseExtendedTableCursors0Y35( ) ;
      }

      protected void DeferredUpdate0Y35( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0Y35( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Y35( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0Y35( ) ;
            AfterConfirm0Y35( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0Y35( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000Y18 */
                  pr_default.execute(16, new Object[] {A109COSTOCPOPRODUCIDOFecha, A110COSTOCPOPRODUCIDOMes, A111COSTOCPOPRODUCIDOAno, A5Cod_Area, A4IndicadoresCodigo, A64TIPOSCPOCod, A45TipoProductoCod});
                  pr_default.close(16);
                  pr_default.SmartCacheProvider.SetUpdated("COSTOCPOPRODUCIDO");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound35 == 0 )
                        {
                           InitAll0Y35( ) ;
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
                        ResetCaption0Y0( ) ;
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
         sMode35 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0Y35( ) ;
         Gx_mode = sMode35;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0Y35( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0Y35( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0Y35( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("costocpoproducido",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0Y0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("costocpoproducido",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0Y35( )
      {
         /* Using cursor T000Y19 */
         pr_default.execute(17);
         RcdFound35 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound35 = 1;
            A109COSTOCPOPRODUCIDOFecha = T000Y19_A109COSTOCPOPRODUCIDOFecha[0];
            AssignAttri("", false, "A109COSTOCPOPRODUCIDOFecha", context.localUtil.Format(A109COSTOCPOPRODUCIDOFecha, "99/99/99"));
            A110COSTOCPOPRODUCIDOMes = T000Y19_A110COSTOCPOPRODUCIDOMes[0];
            AssignAttri("", false, "A110COSTOCPOPRODUCIDOMes", StringUtil.LTrimStr( (decimal)(A110COSTOCPOPRODUCIDOMes), 4, 0));
            A111COSTOCPOPRODUCIDOAno = T000Y19_A111COSTOCPOPRODUCIDOAno[0];
            AssignAttri("", false, "A111COSTOCPOPRODUCIDOAno", StringUtil.LTrimStr( (decimal)(A111COSTOCPOPRODUCIDOAno), 4, 0));
            A5Cod_Area = T000Y19_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = T000Y19_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A64TIPOSCPOCod = T000Y19_A64TIPOSCPOCod[0];
            AssignAttri("", false, "A64TIPOSCPOCod", A64TIPOSCPOCod);
            A45TipoProductoCod = T000Y19_A45TipoProductoCod[0];
            AssignAttri("", false, "A45TipoProductoCod", A45TipoProductoCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0Y35( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound35 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound35 = 1;
            A109COSTOCPOPRODUCIDOFecha = T000Y19_A109COSTOCPOPRODUCIDOFecha[0];
            AssignAttri("", false, "A109COSTOCPOPRODUCIDOFecha", context.localUtil.Format(A109COSTOCPOPRODUCIDOFecha, "99/99/99"));
            A110COSTOCPOPRODUCIDOMes = T000Y19_A110COSTOCPOPRODUCIDOMes[0];
            AssignAttri("", false, "A110COSTOCPOPRODUCIDOMes", StringUtil.LTrimStr( (decimal)(A110COSTOCPOPRODUCIDOMes), 4, 0));
            A111COSTOCPOPRODUCIDOAno = T000Y19_A111COSTOCPOPRODUCIDOAno[0];
            AssignAttri("", false, "A111COSTOCPOPRODUCIDOAno", StringUtil.LTrimStr( (decimal)(A111COSTOCPOPRODUCIDOAno), 4, 0));
            A5Cod_Area = T000Y19_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = T000Y19_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A64TIPOSCPOCod = T000Y19_A64TIPOSCPOCod[0];
            AssignAttri("", false, "A64TIPOSCPOCod", A64TIPOSCPOCod);
            A45TipoProductoCod = T000Y19_A45TipoProductoCod[0];
            AssignAttri("", false, "A45TipoProductoCod", A45TipoProductoCod);
         }
      }

      protected void ScanEnd0Y35( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm0Y35( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0Y35( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0Y35( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0Y35( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0Y35( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0Y35( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0Y35( )
      {
         edtCOSTOCPOPRODUCIDOFecha_Enabled = 0;
         AssignProp("", false, edtCOSTOCPOPRODUCIDOFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSTOCPOPRODUCIDOFecha_Enabled), 5, 0), true);
         edtCOSTOCPOPRODUCIDOMes_Enabled = 0;
         AssignProp("", false, edtCOSTOCPOPRODUCIDOMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSTOCPOPRODUCIDOMes_Enabled), 5, 0), true);
         edtCOSTOCPOPRODUCIDOAno_Enabled = 0;
         AssignProp("", false, edtCOSTOCPOPRODUCIDOAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSTOCPOPRODUCIDOAno_Enabled), 5, 0), true);
         edtCod_Area_Enabled = 0;
         AssignProp("", false, edtCod_Area_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCod_Area_Enabled), 5, 0), true);
         edtIndicadoresCodigo_Enabled = 0;
         AssignProp("", false, edtIndicadoresCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIndicadoresCodigo_Enabled), 5, 0), true);
         edtTIPOSCPOCod_Enabled = 0;
         AssignProp("", false, edtTIPOSCPOCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTIPOSCPOCod_Enabled), 5, 0), true);
         edtTipoProductoCod_Enabled = 0;
         AssignProp("", false, edtTipoProductoCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipoProductoCod_Enabled), 5, 0), true);
         edtCOSTOCPOPRODUCIDOValor_Enabled = 0;
         AssignProp("", false, edtCOSTOCPOPRODUCIDOValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSTOCPOPRODUCIDOValor_Enabled), 5, 0), true);
         edtCOSTOCPOPRODUCIDOUser_Enabled = 0;
         AssignProp("", false, edtCOSTOCPOPRODUCIDOUser_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSTOCPOPRODUCIDOUser_Enabled), 5, 0), true);
         edtCOSTOCPOPRODUCIDOReg_Enabled = 0;
         AssignProp("", false, edtCOSTOCPOPRODUCIDOReg_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSTOCPOPRODUCIDOReg_Enabled), 5, 0), true);
         edtCOSTOCPOPRODUCIDOHor_Enabled = 0;
         AssignProp("", false, edtCOSTOCPOPRODUCIDOHor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSTOCPOPRODUCIDOHor_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0Y35( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0Y0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("costocpoproducido.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z109COSTOCPOPRODUCIDOFecha", context.localUtil.DToC( Z109COSTOCPOPRODUCIDOFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z110COSTOCPOPRODUCIDOMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z110COSTOCPOPRODUCIDOMes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z111COSTOCPOPRODUCIDOAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z111COSTOCPOPRODUCIDOAno), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z5Cod_Area", Z5Cod_Area);
         GxWebStd.gx_hidden_field( context, "Z4IndicadoresCodigo", Z4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "Z64TIPOSCPOCod", Z64TIPOSCPOCod);
         GxWebStd.gx_hidden_field( context, "Z45TipoProductoCod", Z45TipoProductoCod);
         GxWebStd.gx_hidden_field( context, "Z191COSTOCPOPRODUCIDOValor", StringUtil.LTrim( StringUtil.NToC( Z191COSTOCPOPRODUCIDOValor, 10, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z192COSTOCPOPRODUCIDOUser", Z192COSTOCPOPRODUCIDOUser);
         GxWebStd.gx_hidden_field( context, "Z193COSTOCPOPRODUCIDOReg", context.localUtil.DToC( Z193COSTOCPOPRODUCIDOReg, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z194COSTOCPOPRODUCIDOHor", Z194COSTOCPOPRODUCIDOHor);
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
         return formatLink("costocpoproducido.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "COSTOCPOPRODUCIDO" ;
      }

      public override string GetPgmdesc( )
      {
         return "COSTOCPOPRODUCIDO" ;
      }

      protected void InitializeNonKey0Y35( )
      {
         A191COSTOCPOPRODUCIDOValor = 0;
         AssignAttri("", false, "A191COSTOCPOPRODUCIDOValor", StringUtil.LTrimStr( A191COSTOCPOPRODUCIDOValor, 10, 2));
         A192COSTOCPOPRODUCIDOUser = "";
         AssignAttri("", false, "A192COSTOCPOPRODUCIDOUser", A192COSTOCPOPRODUCIDOUser);
         A193COSTOCPOPRODUCIDOReg = DateTime.MinValue;
         AssignAttri("", false, "A193COSTOCPOPRODUCIDOReg", context.localUtil.Format(A193COSTOCPOPRODUCIDOReg, "99/99/99"));
         A194COSTOCPOPRODUCIDOHor = "";
         AssignAttri("", false, "A194COSTOCPOPRODUCIDOHor", A194COSTOCPOPRODUCIDOHor);
         Z191COSTOCPOPRODUCIDOValor = 0;
         Z192COSTOCPOPRODUCIDOUser = "";
         Z193COSTOCPOPRODUCIDOReg = DateTime.MinValue;
         Z194COSTOCPOPRODUCIDOHor = "";
      }

      protected void InitAll0Y35( )
      {
         A109COSTOCPOPRODUCIDOFecha = DateTime.MinValue;
         AssignAttri("", false, "A109COSTOCPOPRODUCIDOFecha", context.localUtil.Format(A109COSTOCPOPRODUCIDOFecha, "99/99/99"));
         A110COSTOCPOPRODUCIDOMes = 0;
         AssignAttri("", false, "A110COSTOCPOPRODUCIDOMes", StringUtil.LTrimStr( (decimal)(A110COSTOCPOPRODUCIDOMes), 4, 0));
         A111COSTOCPOPRODUCIDOAno = 0;
         AssignAttri("", false, "A111COSTOCPOPRODUCIDOAno", StringUtil.LTrimStr( (decimal)(A111COSTOCPOPRODUCIDOAno), 4, 0));
         A5Cod_Area = "";
         AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
         A4IndicadoresCodigo = "";
         AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
         A64TIPOSCPOCod = "";
         AssignAttri("", false, "A64TIPOSCPOCod", A64TIPOSCPOCod);
         A45TipoProductoCod = "";
         AssignAttri("", false, "A45TipoProductoCod", A45TipoProductoCod);
         InitializeNonKey0Y35( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20247231025168", true, true);
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
         context.AddJavascriptSource("costocpoproducido.js", "?20247231025168", false, true);
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
         edtCOSTOCPOPRODUCIDOFecha_Internalname = "COSTOCPOPRODUCIDOFECHA";
         edtCOSTOCPOPRODUCIDOMes_Internalname = "COSTOCPOPRODUCIDOMES";
         edtCOSTOCPOPRODUCIDOAno_Internalname = "COSTOCPOPRODUCIDOANO";
         edtCod_Area_Internalname = "COD_AREA";
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO";
         edtTIPOSCPOCod_Internalname = "TIPOSCPOCOD";
         edtTipoProductoCod_Internalname = "TIPOPRODUCTOCOD";
         edtCOSTOCPOPRODUCIDOValor_Internalname = "COSTOCPOPRODUCIDOVALOR";
         edtCOSTOCPOPRODUCIDOUser_Internalname = "COSTOCPOPRODUCIDOUSER";
         edtCOSTOCPOPRODUCIDOReg_Internalname = "COSTOCPOPRODUCIDOREG";
         edtCOSTOCPOPRODUCIDOHor_Internalname = "COSTOCPOPRODUCIDOHOR";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_5_Internalname = "PROMPT_5";
         imgprompt_4_Internalname = "PROMPT_4";
         imgprompt_64_Internalname = "PROMPT_64";
         imgprompt_45_Internalname = "PROMPT_45";
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
         Form.Caption = "COSTOCPOPRODUCIDO";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCOSTOCPOPRODUCIDOHor_Jsonclick = "";
         edtCOSTOCPOPRODUCIDOHor_Enabled = 1;
         edtCOSTOCPOPRODUCIDOReg_Jsonclick = "";
         edtCOSTOCPOPRODUCIDOReg_Enabled = 1;
         edtCOSTOCPOPRODUCIDOUser_Jsonclick = "";
         edtCOSTOCPOPRODUCIDOUser_Enabled = 1;
         edtCOSTOCPOPRODUCIDOValor_Jsonclick = "";
         edtCOSTOCPOPRODUCIDOValor_Enabled = 1;
         imgprompt_45_Visible = 1;
         imgprompt_45_Link = "";
         edtTipoProductoCod_Jsonclick = "";
         edtTipoProductoCod_Enabled = 1;
         imgprompt_64_Visible = 1;
         imgprompt_64_Link = "";
         edtTIPOSCPOCod_Jsonclick = "";
         edtTIPOSCPOCod_Enabled = 1;
         imgprompt_4_Visible = 1;
         imgprompt_4_Link = "";
         edtIndicadoresCodigo_Jsonclick = "";
         edtIndicadoresCodigo_Enabled = 1;
         imgprompt_5_Visible = 1;
         imgprompt_5_Link = "";
         edtCod_Area_Jsonclick = "";
         edtCod_Area_Enabled = 1;
         edtCOSTOCPOPRODUCIDOAno_Jsonclick = "";
         edtCOSTOCPOPRODUCIDOAno_Enabled = 1;
         edtCOSTOCPOPRODUCIDOMes_Jsonclick = "";
         edtCOSTOCPOPRODUCIDOMes_Enabled = 1;
         edtCOSTOCPOPRODUCIDOFecha_Jsonclick = "";
         edtCOSTOCPOPRODUCIDOFecha_Enabled = 1;
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
         /* Using cursor T000Y20 */
         pr_default.execute(18, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(18);
         /* Using cursor T000Y21 */
         pr_default.execute(19, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(19);
         /* Using cursor T000Y22 */
         pr_default.execute(20, new Object[] {A64TIPOSCPOCod});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GX_msglist.addItem("No existe 'TIPOSCPO'.", "ForeignKeyNotFound", 1, "TIPOSCPOCOD");
            AnyError = 1;
            GX_FocusControl = edtTIPOSCPOCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(20);
         /* Using cursor T000Y23 */
         pr_default.execute(21, new Object[] {A45TipoProductoCod});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo Producto'.", "ForeignKeyNotFound", 1, "TIPOPRODUCTOCOD");
            AnyError = 1;
            GX_FocusControl = edtTipoProductoCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(21);
         GX_FocusControl = edtCOSTOCPOPRODUCIDOValor_Internalname;
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
         /* Using cursor T000Y20 */
         pr_default.execute(18, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
         }
         pr_default.close(18);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Indicadorescodigo( )
      {
         /* Using cursor T000Y21 */
         pr_default.execute(19, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
         }
         pr_default.close(19);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Tiposcpocod( )
      {
         /* Using cursor T000Y22 */
         pr_default.execute(20, new Object[] {A64TIPOSCPOCod});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GX_msglist.addItem("No existe 'TIPOSCPO'.", "ForeignKeyNotFound", 1, "TIPOSCPOCOD");
            AnyError = 1;
            GX_FocusControl = edtTIPOSCPOCod_Internalname;
         }
         pr_default.close(20);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Tipoproductocod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T000Y23 */
         pr_default.execute(21, new Object[] {A45TipoProductoCod});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo Producto'.", "ForeignKeyNotFound", 1, "TIPOPRODUCTOCOD");
            AnyError = 1;
            GX_FocusControl = edtTipoProductoCod_Internalname;
         }
         pr_default.close(21);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A191COSTOCPOPRODUCIDOValor", StringUtil.LTrim( StringUtil.NToC( A191COSTOCPOPRODUCIDOValor, 10, 2, ".", "")));
         AssignAttri("", false, "A192COSTOCPOPRODUCIDOUser", A192COSTOCPOPRODUCIDOUser);
         AssignAttri("", false, "A193COSTOCPOPRODUCIDOReg", context.localUtil.Format(A193COSTOCPOPRODUCIDOReg, "99/99/99"));
         AssignAttri("", false, "A194COSTOCPOPRODUCIDOHor", A194COSTOCPOPRODUCIDOHor);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z109COSTOCPOPRODUCIDOFecha", context.localUtil.Format(Z109COSTOCPOPRODUCIDOFecha, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z110COSTOCPOPRODUCIDOMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z110COSTOCPOPRODUCIDOMes), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z111COSTOCPOPRODUCIDOAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z111COSTOCPOPRODUCIDOAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z5Cod_Area", Z5Cod_Area);
         GxWebStd.gx_hidden_field( context, "Z4IndicadoresCodigo", Z4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "Z64TIPOSCPOCod", Z64TIPOSCPOCod);
         GxWebStd.gx_hidden_field( context, "Z45TipoProductoCod", Z45TipoProductoCod);
         GxWebStd.gx_hidden_field( context, "Z191COSTOCPOPRODUCIDOValor", StringUtil.LTrim( StringUtil.NToC( Z191COSTOCPOPRODUCIDOValor, 10, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z192COSTOCPOPRODUCIDOUser", Z192COSTOCPOPRODUCIDOUser);
         GxWebStd.gx_hidden_field( context, "Z193COSTOCPOPRODUCIDOReg", context.localUtil.Format(Z193COSTOCPOPRODUCIDOReg, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z194COSTOCPOPRODUCIDOHor", Z194COSTOCPOPRODUCIDOHor);
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
         setEventMetadata("VALID_COSTOCPOPRODUCIDOFECHA","{handler:'Valid_Costocpoproducidofecha',iparms:[]");
         setEventMetadata("VALID_COSTOCPOPRODUCIDOFECHA",",oparms:[]}");
         setEventMetadata("VALID_COSTOCPOPRODUCIDOMES","{handler:'Valid_Costocpoproducidomes',iparms:[]");
         setEventMetadata("VALID_COSTOCPOPRODUCIDOMES",",oparms:[]}");
         setEventMetadata("VALID_COSTOCPOPRODUCIDOANO","{handler:'Valid_Costocpoproducidoano',iparms:[]");
         setEventMetadata("VALID_COSTOCPOPRODUCIDOANO",",oparms:[]}");
         setEventMetadata("VALID_COD_AREA","{handler:'Valid_Cod_area',iparms:[{av:'A5Cod_Area',fld:'COD_AREA',pic:''}]");
         setEventMetadata("VALID_COD_AREA",",oparms:[]}");
         setEventMetadata("VALID_INDICADORESCODIGO","{handler:'Valid_Indicadorescodigo',iparms:[{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:''}]");
         setEventMetadata("VALID_INDICADORESCODIGO",",oparms:[]}");
         setEventMetadata("VALID_TIPOSCPOCOD","{handler:'Valid_Tiposcpocod',iparms:[{av:'A64TIPOSCPOCod',fld:'TIPOSCPOCOD',pic:''}]");
         setEventMetadata("VALID_TIPOSCPOCOD",",oparms:[]}");
         setEventMetadata("VALID_TIPOPRODUCTOCOD","{handler:'Valid_Tipoproductocod',iparms:[{av:'A109COSTOCPOPRODUCIDOFecha',fld:'COSTOCPOPRODUCIDOFECHA',pic:''},{av:'A110COSTOCPOPRODUCIDOMes',fld:'COSTOCPOPRODUCIDOMES',pic:'ZZZ9'},{av:'A111COSTOCPOPRODUCIDOAno',fld:'COSTOCPOPRODUCIDOANO',pic:'ZZZ9'},{av:'A5Cod_Area',fld:'COD_AREA',pic:''},{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:''},{av:'A64TIPOSCPOCod',fld:'TIPOSCPOCOD',pic:''},{av:'A45TipoProductoCod',fld:'TIPOPRODUCTOCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_TIPOPRODUCTOCOD",",oparms:[{av:'A191COSTOCPOPRODUCIDOValor',fld:'COSTOCPOPRODUCIDOVALOR',pic:'ZZZZZZ9.99'},{av:'A192COSTOCPOPRODUCIDOUser',fld:'COSTOCPOPRODUCIDOUSER',pic:''},{av:'A193COSTOCPOPRODUCIDOReg',fld:'COSTOCPOPRODUCIDOREG',pic:''},{av:'A194COSTOCPOPRODUCIDOHor',fld:'COSTOCPOPRODUCIDOHOR',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z109COSTOCPOPRODUCIDOFecha'},{av:'Z110COSTOCPOPRODUCIDOMes'},{av:'Z111COSTOCPOPRODUCIDOAno'},{av:'Z5Cod_Area'},{av:'Z4IndicadoresCodigo'},{av:'Z64TIPOSCPOCod'},{av:'Z45TipoProductoCod'},{av:'Z191COSTOCPOPRODUCIDOValor'},{av:'Z192COSTOCPOPRODUCIDOUser'},{av:'Z193COSTOCPOPRODUCIDOReg'},{av:'Z194COSTOCPOPRODUCIDOHor'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_COSTOCPOPRODUCIDOREG","{handler:'Valid_Costocpoproducidoreg',iparms:[]");
         setEventMetadata("VALID_COSTOCPOPRODUCIDOREG",",oparms:[]}");
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
         Z109COSTOCPOPRODUCIDOFecha = DateTime.MinValue;
         Z5Cod_Area = "";
         Z4IndicadoresCodigo = "";
         Z64TIPOSCPOCod = "";
         Z45TipoProductoCod = "";
         Z192COSTOCPOPRODUCIDOUser = "";
         Z193COSTOCPOPRODUCIDOReg = DateTime.MinValue;
         Z194COSTOCPOPRODUCIDOHor = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A5Cod_Area = "";
         A4IndicadoresCodigo = "";
         A64TIPOSCPOCod = "";
         A45TipoProductoCod = "";
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
         A109COSTOCPOPRODUCIDOFecha = DateTime.MinValue;
         imgprompt_5_gximage = "";
         sImgUrl = "";
         imgprompt_4_gximage = "";
         imgprompt_64_gximage = "";
         imgprompt_45_gximage = "";
         A192COSTOCPOPRODUCIDOUser = "";
         A193COSTOCPOPRODUCIDOReg = DateTime.MinValue;
         A194COSTOCPOPRODUCIDOHor = "";
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
         T000Y8_A109COSTOCPOPRODUCIDOFecha = new DateTime[] {DateTime.MinValue} ;
         T000Y8_A110COSTOCPOPRODUCIDOMes = new short[1] ;
         T000Y8_A111COSTOCPOPRODUCIDOAno = new short[1] ;
         T000Y8_A191COSTOCPOPRODUCIDOValor = new decimal[1] ;
         T000Y8_A192COSTOCPOPRODUCIDOUser = new string[] {""} ;
         T000Y8_A193COSTOCPOPRODUCIDOReg = new DateTime[] {DateTime.MinValue} ;
         T000Y8_A194COSTOCPOPRODUCIDOHor = new string[] {""} ;
         T000Y8_A5Cod_Area = new string[] {""} ;
         T000Y8_A4IndicadoresCodigo = new string[] {""} ;
         T000Y8_A64TIPOSCPOCod = new string[] {""} ;
         T000Y8_A45TipoProductoCod = new string[] {""} ;
         T000Y4_A5Cod_Area = new string[] {""} ;
         T000Y5_A4IndicadoresCodigo = new string[] {""} ;
         T000Y6_A64TIPOSCPOCod = new string[] {""} ;
         T000Y7_A45TipoProductoCod = new string[] {""} ;
         T000Y9_A5Cod_Area = new string[] {""} ;
         T000Y10_A4IndicadoresCodigo = new string[] {""} ;
         T000Y11_A64TIPOSCPOCod = new string[] {""} ;
         T000Y12_A45TipoProductoCod = new string[] {""} ;
         T000Y13_A109COSTOCPOPRODUCIDOFecha = new DateTime[] {DateTime.MinValue} ;
         T000Y13_A110COSTOCPOPRODUCIDOMes = new short[1] ;
         T000Y13_A111COSTOCPOPRODUCIDOAno = new short[1] ;
         T000Y13_A5Cod_Area = new string[] {""} ;
         T000Y13_A4IndicadoresCodigo = new string[] {""} ;
         T000Y13_A64TIPOSCPOCod = new string[] {""} ;
         T000Y13_A45TipoProductoCod = new string[] {""} ;
         T000Y3_A109COSTOCPOPRODUCIDOFecha = new DateTime[] {DateTime.MinValue} ;
         T000Y3_A110COSTOCPOPRODUCIDOMes = new short[1] ;
         T000Y3_A111COSTOCPOPRODUCIDOAno = new short[1] ;
         T000Y3_A191COSTOCPOPRODUCIDOValor = new decimal[1] ;
         T000Y3_A192COSTOCPOPRODUCIDOUser = new string[] {""} ;
         T000Y3_A193COSTOCPOPRODUCIDOReg = new DateTime[] {DateTime.MinValue} ;
         T000Y3_A194COSTOCPOPRODUCIDOHor = new string[] {""} ;
         T000Y3_A5Cod_Area = new string[] {""} ;
         T000Y3_A4IndicadoresCodigo = new string[] {""} ;
         T000Y3_A64TIPOSCPOCod = new string[] {""} ;
         T000Y3_A45TipoProductoCod = new string[] {""} ;
         sMode35 = "";
         T000Y14_A109COSTOCPOPRODUCIDOFecha = new DateTime[] {DateTime.MinValue} ;
         T000Y14_A110COSTOCPOPRODUCIDOMes = new short[1] ;
         T000Y14_A111COSTOCPOPRODUCIDOAno = new short[1] ;
         T000Y14_A5Cod_Area = new string[] {""} ;
         T000Y14_A4IndicadoresCodigo = new string[] {""} ;
         T000Y14_A64TIPOSCPOCod = new string[] {""} ;
         T000Y14_A45TipoProductoCod = new string[] {""} ;
         T000Y15_A109COSTOCPOPRODUCIDOFecha = new DateTime[] {DateTime.MinValue} ;
         T000Y15_A110COSTOCPOPRODUCIDOMes = new short[1] ;
         T000Y15_A111COSTOCPOPRODUCIDOAno = new short[1] ;
         T000Y15_A5Cod_Area = new string[] {""} ;
         T000Y15_A4IndicadoresCodigo = new string[] {""} ;
         T000Y15_A64TIPOSCPOCod = new string[] {""} ;
         T000Y15_A45TipoProductoCod = new string[] {""} ;
         T000Y2_A109COSTOCPOPRODUCIDOFecha = new DateTime[] {DateTime.MinValue} ;
         T000Y2_A110COSTOCPOPRODUCIDOMes = new short[1] ;
         T000Y2_A111COSTOCPOPRODUCIDOAno = new short[1] ;
         T000Y2_A191COSTOCPOPRODUCIDOValor = new decimal[1] ;
         T000Y2_A192COSTOCPOPRODUCIDOUser = new string[] {""} ;
         T000Y2_A193COSTOCPOPRODUCIDOReg = new DateTime[] {DateTime.MinValue} ;
         T000Y2_A194COSTOCPOPRODUCIDOHor = new string[] {""} ;
         T000Y2_A5Cod_Area = new string[] {""} ;
         T000Y2_A4IndicadoresCodigo = new string[] {""} ;
         T000Y2_A64TIPOSCPOCod = new string[] {""} ;
         T000Y2_A45TipoProductoCod = new string[] {""} ;
         T000Y19_A109COSTOCPOPRODUCIDOFecha = new DateTime[] {DateTime.MinValue} ;
         T000Y19_A110COSTOCPOPRODUCIDOMes = new short[1] ;
         T000Y19_A111COSTOCPOPRODUCIDOAno = new short[1] ;
         T000Y19_A5Cod_Area = new string[] {""} ;
         T000Y19_A4IndicadoresCodigo = new string[] {""} ;
         T000Y19_A64TIPOSCPOCod = new string[] {""} ;
         T000Y19_A45TipoProductoCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T000Y20_A5Cod_Area = new string[] {""} ;
         T000Y21_A4IndicadoresCodigo = new string[] {""} ;
         T000Y22_A64TIPOSCPOCod = new string[] {""} ;
         T000Y23_A45TipoProductoCod = new string[] {""} ;
         ZZ109COSTOCPOPRODUCIDOFecha = DateTime.MinValue;
         ZZ5Cod_Area = "";
         ZZ4IndicadoresCodigo = "";
         ZZ64TIPOSCPOCod = "";
         ZZ45TipoProductoCod = "";
         ZZ192COSTOCPOPRODUCIDOUser = "";
         ZZ193COSTOCPOPRODUCIDOReg = DateTime.MinValue;
         ZZ194COSTOCPOPRODUCIDOHor = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.costocpoproducido__default(),
            new Object[][] {
                new Object[] {
               T000Y2_A109COSTOCPOPRODUCIDOFecha, T000Y2_A110COSTOCPOPRODUCIDOMes, T000Y2_A111COSTOCPOPRODUCIDOAno, T000Y2_A191COSTOCPOPRODUCIDOValor, T000Y2_A192COSTOCPOPRODUCIDOUser, T000Y2_A193COSTOCPOPRODUCIDOReg, T000Y2_A194COSTOCPOPRODUCIDOHor, T000Y2_A5Cod_Area, T000Y2_A4IndicadoresCodigo, T000Y2_A64TIPOSCPOCod,
               T000Y2_A45TipoProductoCod
               }
               , new Object[] {
               T000Y3_A109COSTOCPOPRODUCIDOFecha, T000Y3_A110COSTOCPOPRODUCIDOMes, T000Y3_A111COSTOCPOPRODUCIDOAno, T000Y3_A191COSTOCPOPRODUCIDOValor, T000Y3_A192COSTOCPOPRODUCIDOUser, T000Y3_A193COSTOCPOPRODUCIDOReg, T000Y3_A194COSTOCPOPRODUCIDOHor, T000Y3_A5Cod_Area, T000Y3_A4IndicadoresCodigo, T000Y3_A64TIPOSCPOCod,
               T000Y3_A45TipoProductoCod
               }
               , new Object[] {
               T000Y4_A5Cod_Area
               }
               , new Object[] {
               T000Y5_A4IndicadoresCodigo
               }
               , new Object[] {
               T000Y6_A64TIPOSCPOCod
               }
               , new Object[] {
               T000Y7_A45TipoProductoCod
               }
               , new Object[] {
               T000Y8_A109COSTOCPOPRODUCIDOFecha, T000Y8_A110COSTOCPOPRODUCIDOMes, T000Y8_A111COSTOCPOPRODUCIDOAno, T000Y8_A191COSTOCPOPRODUCIDOValor, T000Y8_A192COSTOCPOPRODUCIDOUser, T000Y8_A193COSTOCPOPRODUCIDOReg, T000Y8_A194COSTOCPOPRODUCIDOHor, T000Y8_A5Cod_Area, T000Y8_A4IndicadoresCodigo, T000Y8_A64TIPOSCPOCod,
               T000Y8_A45TipoProductoCod
               }
               , new Object[] {
               T000Y9_A5Cod_Area
               }
               , new Object[] {
               T000Y10_A4IndicadoresCodigo
               }
               , new Object[] {
               T000Y11_A64TIPOSCPOCod
               }
               , new Object[] {
               T000Y12_A45TipoProductoCod
               }
               , new Object[] {
               T000Y13_A109COSTOCPOPRODUCIDOFecha, T000Y13_A110COSTOCPOPRODUCIDOMes, T000Y13_A111COSTOCPOPRODUCIDOAno, T000Y13_A5Cod_Area, T000Y13_A4IndicadoresCodigo, T000Y13_A64TIPOSCPOCod, T000Y13_A45TipoProductoCod
               }
               , new Object[] {
               T000Y14_A109COSTOCPOPRODUCIDOFecha, T000Y14_A110COSTOCPOPRODUCIDOMes, T000Y14_A111COSTOCPOPRODUCIDOAno, T000Y14_A5Cod_Area, T000Y14_A4IndicadoresCodigo, T000Y14_A64TIPOSCPOCod, T000Y14_A45TipoProductoCod
               }
               , new Object[] {
               T000Y15_A109COSTOCPOPRODUCIDOFecha, T000Y15_A110COSTOCPOPRODUCIDOMes, T000Y15_A111COSTOCPOPRODUCIDOAno, T000Y15_A5Cod_Area, T000Y15_A4IndicadoresCodigo, T000Y15_A64TIPOSCPOCod, T000Y15_A45TipoProductoCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000Y19_A109COSTOCPOPRODUCIDOFecha, T000Y19_A110COSTOCPOPRODUCIDOMes, T000Y19_A111COSTOCPOPRODUCIDOAno, T000Y19_A5Cod_Area, T000Y19_A4IndicadoresCodigo, T000Y19_A64TIPOSCPOCod, T000Y19_A45TipoProductoCod
               }
               , new Object[] {
               T000Y20_A5Cod_Area
               }
               , new Object[] {
               T000Y21_A4IndicadoresCodigo
               }
               , new Object[] {
               T000Y22_A64TIPOSCPOCod
               }
               , new Object[] {
               T000Y23_A45TipoProductoCod
               }
            }
         );
      }

      private short Z110COSTOCPOPRODUCIDOMes ;
      private short Z111COSTOCPOPRODUCIDOAno ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A110COSTOCPOPRODUCIDOMes ;
      private short A111COSTOCPOPRODUCIDOAno ;
      private short GX_JID ;
      private short RcdFound35 ;
      private short nIsDirty_35 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ110COSTOCPOPRODUCIDOMes ;
      private short ZZ111COSTOCPOPRODUCIDOAno ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtCOSTOCPOPRODUCIDOFecha_Enabled ;
      private int edtCOSTOCPOPRODUCIDOMes_Enabled ;
      private int edtCOSTOCPOPRODUCIDOAno_Enabled ;
      private int edtCod_Area_Enabled ;
      private int imgprompt_5_Visible ;
      private int edtIndicadoresCodigo_Enabled ;
      private int imgprompt_4_Visible ;
      private int edtTIPOSCPOCod_Enabled ;
      private int imgprompt_64_Visible ;
      private int edtTipoProductoCod_Enabled ;
      private int imgprompt_45_Visible ;
      private int edtCOSTOCPOPRODUCIDOValor_Enabled ;
      private int edtCOSTOCPOPRODUCIDOUser_Enabled ;
      private int edtCOSTOCPOPRODUCIDOReg_Enabled ;
      private int edtCOSTOCPOPRODUCIDOHor_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private decimal Z191COSTOCPOPRODUCIDOValor ;
      private decimal A191COSTOCPOPRODUCIDOValor ;
      private decimal ZZ191COSTOCPOPRODUCIDOValor ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCOSTOCPOPRODUCIDOFecha_Internalname ;
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
      private string edtCOSTOCPOPRODUCIDOFecha_Jsonclick ;
      private string edtCOSTOCPOPRODUCIDOMes_Internalname ;
      private string edtCOSTOCPOPRODUCIDOMes_Jsonclick ;
      private string edtCOSTOCPOPRODUCIDOAno_Internalname ;
      private string edtCOSTOCPOPRODUCIDOAno_Jsonclick ;
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
      private string edtTIPOSCPOCod_Internalname ;
      private string edtTIPOSCPOCod_Jsonclick ;
      private string imgprompt_64_gximage ;
      private string imgprompt_64_Internalname ;
      private string imgprompt_64_Link ;
      private string edtTipoProductoCod_Internalname ;
      private string edtTipoProductoCod_Jsonclick ;
      private string imgprompt_45_gximage ;
      private string imgprompt_45_Internalname ;
      private string imgprompt_45_Link ;
      private string edtCOSTOCPOPRODUCIDOValor_Internalname ;
      private string edtCOSTOCPOPRODUCIDOValor_Jsonclick ;
      private string edtCOSTOCPOPRODUCIDOUser_Internalname ;
      private string edtCOSTOCPOPRODUCIDOUser_Jsonclick ;
      private string edtCOSTOCPOPRODUCIDOReg_Internalname ;
      private string edtCOSTOCPOPRODUCIDOReg_Jsonclick ;
      private string edtCOSTOCPOPRODUCIDOHor_Internalname ;
      private string edtCOSTOCPOPRODUCIDOHor_Jsonclick ;
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
      private string sMode35 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z109COSTOCPOPRODUCIDOFecha ;
      private DateTime Z193COSTOCPOPRODUCIDOReg ;
      private DateTime A109COSTOCPOPRODUCIDOFecha ;
      private DateTime A193COSTOCPOPRODUCIDOReg ;
      private DateTime ZZ109COSTOCPOPRODUCIDOFecha ;
      private DateTime ZZ193COSTOCPOPRODUCIDOReg ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string Z5Cod_Area ;
      private string Z4IndicadoresCodigo ;
      private string Z64TIPOSCPOCod ;
      private string Z45TipoProductoCod ;
      private string Z192COSTOCPOPRODUCIDOUser ;
      private string Z194COSTOCPOPRODUCIDOHor ;
      private string A5Cod_Area ;
      private string A4IndicadoresCodigo ;
      private string A64TIPOSCPOCod ;
      private string A45TipoProductoCod ;
      private string A192COSTOCPOPRODUCIDOUser ;
      private string A194COSTOCPOPRODUCIDOHor ;
      private string ZZ5Cod_Area ;
      private string ZZ4IndicadoresCodigo ;
      private string ZZ64TIPOSCPOCod ;
      private string ZZ45TipoProductoCod ;
      private string ZZ192COSTOCPOPRODUCIDOUser ;
      private string ZZ194COSTOCPOPRODUCIDOHor ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] T000Y8_A109COSTOCPOPRODUCIDOFecha ;
      private short[] T000Y8_A110COSTOCPOPRODUCIDOMes ;
      private short[] T000Y8_A111COSTOCPOPRODUCIDOAno ;
      private decimal[] T000Y8_A191COSTOCPOPRODUCIDOValor ;
      private string[] T000Y8_A192COSTOCPOPRODUCIDOUser ;
      private DateTime[] T000Y8_A193COSTOCPOPRODUCIDOReg ;
      private string[] T000Y8_A194COSTOCPOPRODUCIDOHor ;
      private string[] T000Y8_A5Cod_Area ;
      private string[] T000Y8_A4IndicadoresCodigo ;
      private string[] T000Y8_A64TIPOSCPOCod ;
      private string[] T000Y8_A45TipoProductoCod ;
      private string[] T000Y4_A5Cod_Area ;
      private string[] T000Y5_A4IndicadoresCodigo ;
      private string[] T000Y6_A64TIPOSCPOCod ;
      private string[] T000Y7_A45TipoProductoCod ;
      private string[] T000Y9_A5Cod_Area ;
      private string[] T000Y10_A4IndicadoresCodigo ;
      private string[] T000Y11_A64TIPOSCPOCod ;
      private string[] T000Y12_A45TipoProductoCod ;
      private DateTime[] T000Y13_A109COSTOCPOPRODUCIDOFecha ;
      private short[] T000Y13_A110COSTOCPOPRODUCIDOMes ;
      private short[] T000Y13_A111COSTOCPOPRODUCIDOAno ;
      private string[] T000Y13_A5Cod_Area ;
      private string[] T000Y13_A4IndicadoresCodigo ;
      private string[] T000Y13_A64TIPOSCPOCod ;
      private string[] T000Y13_A45TipoProductoCod ;
      private DateTime[] T000Y3_A109COSTOCPOPRODUCIDOFecha ;
      private short[] T000Y3_A110COSTOCPOPRODUCIDOMes ;
      private short[] T000Y3_A111COSTOCPOPRODUCIDOAno ;
      private decimal[] T000Y3_A191COSTOCPOPRODUCIDOValor ;
      private string[] T000Y3_A192COSTOCPOPRODUCIDOUser ;
      private DateTime[] T000Y3_A193COSTOCPOPRODUCIDOReg ;
      private string[] T000Y3_A194COSTOCPOPRODUCIDOHor ;
      private string[] T000Y3_A5Cod_Area ;
      private string[] T000Y3_A4IndicadoresCodigo ;
      private string[] T000Y3_A64TIPOSCPOCod ;
      private string[] T000Y3_A45TipoProductoCod ;
      private DateTime[] T000Y14_A109COSTOCPOPRODUCIDOFecha ;
      private short[] T000Y14_A110COSTOCPOPRODUCIDOMes ;
      private short[] T000Y14_A111COSTOCPOPRODUCIDOAno ;
      private string[] T000Y14_A5Cod_Area ;
      private string[] T000Y14_A4IndicadoresCodigo ;
      private string[] T000Y14_A64TIPOSCPOCod ;
      private string[] T000Y14_A45TipoProductoCod ;
      private DateTime[] T000Y15_A109COSTOCPOPRODUCIDOFecha ;
      private short[] T000Y15_A110COSTOCPOPRODUCIDOMes ;
      private short[] T000Y15_A111COSTOCPOPRODUCIDOAno ;
      private string[] T000Y15_A5Cod_Area ;
      private string[] T000Y15_A4IndicadoresCodigo ;
      private string[] T000Y15_A64TIPOSCPOCod ;
      private string[] T000Y15_A45TipoProductoCod ;
      private DateTime[] T000Y2_A109COSTOCPOPRODUCIDOFecha ;
      private short[] T000Y2_A110COSTOCPOPRODUCIDOMes ;
      private short[] T000Y2_A111COSTOCPOPRODUCIDOAno ;
      private decimal[] T000Y2_A191COSTOCPOPRODUCIDOValor ;
      private string[] T000Y2_A192COSTOCPOPRODUCIDOUser ;
      private DateTime[] T000Y2_A193COSTOCPOPRODUCIDOReg ;
      private string[] T000Y2_A194COSTOCPOPRODUCIDOHor ;
      private string[] T000Y2_A5Cod_Area ;
      private string[] T000Y2_A4IndicadoresCodigo ;
      private string[] T000Y2_A64TIPOSCPOCod ;
      private string[] T000Y2_A45TipoProductoCod ;
      private DateTime[] T000Y19_A109COSTOCPOPRODUCIDOFecha ;
      private short[] T000Y19_A110COSTOCPOPRODUCIDOMes ;
      private short[] T000Y19_A111COSTOCPOPRODUCIDOAno ;
      private string[] T000Y19_A5Cod_Area ;
      private string[] T000Y19_A4IndicadoresCodigo ;
      private string[] T000Y19_A64TIPOSCPOCod ;
      private string[] T000Y19_A45TipoProductoCod ;
      private string[] T000Y20_A5Cod_Area ;
      private string[] T000Y21_A4IndicadoresCodigo ;
      private string[] T000Y22_A64TIPOSCPOCod ;
      private string[] T000Y23_A45TipoProductoCod ;
      private GXWebForm Form ;
   }

   public class costocpoproducido__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT000Y8;
          prmT000Y8 = new Object[] {
          new ParDef("@COSTOCPOPRODUCIDOFecha",GXType.Date,8,0) ,
          new ParDef("@COSTOCPOPRODUCIDOMes",GXType.Int16,4,0) ,
          new ParDef("@COSTOCPOPRODUCIDOAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@TIPOSCPOCod",GXType.NVarChar,120,0) ,
          new ParDef("@TipoProductoCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000Y4;
          prmT000Y4 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000Y5;
          prmT000Y5 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000Y6;
          prmT000Y6 = new Object[] {
          new ParDef("@TIPOSCPOCod",GXType.NVarChar,120,0)
          };
          Object[] prmT000Y7;
          prmT000Y7 = new Object[] {
          new ParDef("@TipoProductoCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000Y9;
          prmT000Y9 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000Y10;
          prmT000Y10 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000Y11;
          prmT000Y11 = new Object[] {
          new ParDef("@TIPOSCPOCod",GXType.NVarChar,120,0)
          };
          Object[] prmT000Y12;
          prmT000Y12 = new Object[] {
          new ParDef("@TipoProductoCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000Y13;
          prmT000Y13 = new Object[] {
          new ParDef("@COSTOCPOPRODUCIDOFecha",GXType.Date,8,0) ,
          new ParDef("@COSTOCPOPRODUCIDOMes",GXType.Int16,4,0) ,
          new ParDef("@COSTOCPOPRODUCIDOAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@TIPOSCPOCod",GXType.NVarChar,120,0) ,
          new ParDef("@TipoProductoCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000Y3;
          prmT000Y3 = new Object[] {
          new ParDef("@COSTOCPOPRODUCIDOFecha",GXType.Date,8,0) ,
          new ParDef("@COSTOCPOPRODUCIDOMes",GXType.Int16,4,0) ,
          new ParDef("@COSTOCPOPRODUCIDOAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@TIPOSCPOCod",GXType.NVarChar,120,0) ,
          new ParDef("@TipoProductoCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000Y14;
          prmT000Y14 = new Object[] {
          new ParDef("@COSTOCPOPRODUCIDOFecha",GXType.Date,8,0) ,
          new ParDef("@COSTOCPOPRODUCIDOMes",GXType.Int16,4,0) ,
          new ParDef("@COSTOCPOPRODUCIDOAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@TIPOSCPOCod",GXType.NVarChar,120,0) ,
          new ParDef("@TipoProductoCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000Y15;
          prmT000Y15 = new Object[] {
          new ParDef("@COSTOCPOPRODUCIDOFecha",GXType.Date,8,0) ,
          new ParDef("@COSTOCPOPRODUCIDOMes",GXType.Int16,4,0) ,
          new ParDef("@COSTOCPOPRODUCIDOAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@TIPOSCPOCod",GXType.NVarChar,120,0) ,
          new ParDef("@TipoProductoCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000Y2;
          prmT000Y2 = new Object[] {
          new ParDef("@COSTOCPOPRODUCIDOFecha",GXType.Date,8,0) ,
          new ParDef("@COSTOCPOPRODUCIDOMes",GXType.Int16,4,0) ,
          new ParDef("@COSTOCPOPRODUCIDOAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@TIPOSCPOCod",GXType.NVarChar,120,0) ,
          new ParDef("@TipoProductoCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000Y16;
          prmT000Y16 = new Object[] {
          new ParDef("@COSTOCPOPRODUCIDOFecha",GXType.Date,8,0) ,
          new ParDef("@COSTOCPOPRODUCIDOMes",GXType.Int16,4,0) ,
          new ParDef("@COSTOCPOPRODUCIDOAno",GXType.Int16,4,0) ,
          new ParDef("@COSTOCPOPRODUCIDOValor",GXType.Decimal,10,2) ,
          new ParDef("@COSTOCPOPRODUCIDOUser",GXType.NVarChar,150,0) ,
          new ParDef("@COSTOCPOPRODUCIDOReg",GXType.Date,8,0) ,
          new ParDef("@COSTOCPOPRODUCIDOHor",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@TIPOSCPOCod",GXType.NVarChar,120,0) ,
          new ParDef("@TipoProductoCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000Y17;
          prmT000Y17 = new Object[] {
          new ParDef("@COSTOCPOPRODUCIDOValor",GXType.Decimal,10,2) ,
          new ParDef("@COSTOCPOPRODUCIDOUser",GXType.NVarChar,150,0) ,
          new ParDef("@COSTOCPOPRODUCIDOReg",GXType.Date,8,0) ,
          new ParDef("@COSTOCPOPRODUCIDOHor",GXType.NVarChar,40,0) ,
          new ParDef("@COSTOCPOPRODUCIDOFecha",GXType.Date,8,0) ,
          new ParDef("@COSTOCPOPRODUCIDOMes",GXType.Int16,4,0) ,
          new ParDef("@COSTOCPOPRODUCIDOAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@TIPOSCPOCod",GXType.NVarChar,120,0) ,
          new ParDef("@TipoProductoCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000Y18;
          prmT000Y18 = new Object[] {
          new ParDef("@COSTOCPOPRODUCIDOFecha",GXType.Date,8,0) ,
          new ParDef("@COSTOCPOPRODUCIDOMes",GXType.Int16,4,0) ,
          new ParDef("@COSTOCPOPRODUCIDOAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@TIPOSCPOCod",GXType.NVarChar,120,0) ,
          new ParDef("@TipoProductoCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000Y19;
          prmT000Y19 = new Object[] {
          };
          Object[] prmT000Y20;
          prmT000Y20 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000Y21;
          prmT000Y21 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000Y22;
          prmT000Y22 = new Object[] {
          new ParDef("@TIPOSCPOCod",GXType.NVarChar,120,0)
          };
          Object[] prmT000Y23;
          prmT000Y23 = new Object[] {
          new ParDef("@TipoProductoCod",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("T000Y2", "SELECT [COSTOCPOPRODUCIDOFecha], [COSTOCPOPRODUCIDOMes], [COSTOCPOPRODUCIDOAno], [COSTOCPOPRODUCIDOValor], [COSTOCPOPRODUCIDOUser], [COSTOCPOPRODUCIDOReg], [COSTOCPOPRODUCIDOHor], [Cod_Area], [IndicadoresCodigo], [TIPOSCPOCod], [TipoProductoCod] FROM [COSTOCPOPRODUCIDO] WITH (UPDLOCK) WHERE [COSTOCPOPRODUCIDOFecha] = @COSTOCPOPRODUCIDOFecha AND [COSTOCPOPRODUCIDOMes] = @COSTOCPOPRODUCIDOMes AND [COSTOCPOPRODUCIDOAno] = @COSTOCPOPRODUCIDOAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo AND [TIPOSCPOCod] = @TIPOSCPOCod AND [TipoProductoCod] = @TipoProductoCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000Y3", "SELECT [COSTOCPOPRODUCIDOFecha], [COSTOCPOPRODUCIDOMes], [COSTOCPOPRODUCIDOAno], [COSTOCPOPRODUCIDOValor], [COSTOCPOPRODUCIDOUser], [COSTOCPOPRODUCIDOReg], [COSTOCPOPRODUCIDOHor], [Cod_Area], [IndicadoresCodigo], [TIPOSCPOCod], [TipoProductoCod] FROM [COSTOCPOPRODUCIDO] WHERE [COSTOCPOPRODUCIDOFecha] = @COSTOCPOPRODUCIDOFecha AND [COSTOCPOPRODUCIDOMes] = @COSTOCPOPRODUCIDOMes AND [COSTOCPOPRODUCIDOAno] = @COSTOCPOPRODUCIDOAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo AND [TIPOSCPOCod] = @TIPOSCPOCod AND [TipoProductoCod] = @TipoProductoCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000Y4", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000Y5", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000Y6", "SELECT [TIPOSCPOCod] FROM [TIPOSCPO] WHERE [TIPOSCPOCod] = @TIPOSCPOCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000Y7", "SELECT [TipoProductoCod] FROM [TipoProducto] WHERE [TipoProductoCod] = @TipoProductoCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000Y8", "SELECT TM1.[COSTOCPOPRODUCIDOFecha], TM1.[COSTOCPOPRODUCIDOMes], TM1.[COSTOCPOPRODUCIDOAno], TM1.[COSTOCPOPRODUCIDOValor], TM1.[COSTOCPOPRODUCIDOUser], TM1.[COSTOCPOPRODUCIDOReg], TM1.[COSTOCPOPRODUCIDOHor], TM1.[Cod_Area], TM1.[IndicadoresCodigo], TM1.[TIPOSCPOCod], TM1.[TipoProductoCod] FROM [COSTOCPOPRODUCIDO] TM1 WHERE TM1.[COSTOCPOPRODUCIDOFecha] = @COSTOCPOPRODUCIDOFecha and TM1.[COSTOCPOPRODUCIDOMes] = @COSTOCPOPRODUCIDOMes and TM1.[COSTOCPOPRODUCIDOAno] = @COSTOCPOPRODUCIDOAno and TM1.[Cod_Area] = @Cod_Area and TM1.[IndicadoresCodigo] = @IndicadoresCodigo and TM1.[TIPOSCPOCod] = @TIPOSCPOCod and TM1.[TipoProductoCod] = @TipoProductoCod ORDER BY TM1.[COSTOCPOPRODUCIDOFecha], TM1.[COSTOCPOPRODUCIDOMes], TM1.[COSTOCPOPRODUCIDOAno], TM1.[Cod_Area], TM1.[IndicadoresCodigo], TM1.[TIPOSCPOCod], TM1.[TipoProductoCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y8,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000Y9", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000Y10", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y10,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000Y11", "SELECT [TIPOSCPOCod] FROM [TIPOSCPO] WHERE [TIPOSCPOCod] = @TIPOSCPOCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000Y12", "SELECT [TipoProductoCod] FROM [TipoProducto] WHERE [TipoProductoCod] = @TipoProductoCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y12,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000Y13", "SELECT [COSTOCPOPRODUCIDOFecha], [COSTOCPOPRODUCIDOMes], [COSTOCPOPRODUCIDOAno], [Cod_Area], [IndicadoresCodigo], [TIPOSCPOCod], [TipoProductoCod] FROM [COSTOCPOPRODUCIDO] WHERE [COSTOCPOPRODUCIDOFecha] = @COSTOCPOPRODUCIDOFecha AND [COSTOCPOPRODUCIDOMes] = @COSTOCPOPRODUCIDOMes AND [COSTOCPOPRODUCIDOAno] = @COSTOCPOPRODUCIDOAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo AND [TIPOSCPOCod] = @TIPOSCPOCod AND [TipoProductoCod] = @TipoProductoCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y13,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000Y14", "SELECT TOP 1 [COSTOCPOPRODUCIDOFecha], [COSTOCPOPRODUCIDOMes], [COSTOCPOPRODUCIDOAno], [Cod_Area], [IndicadoresCodigo], [TIPOSCPOCod], [TipoProductoCod] FROM [COSTOCPOPRODUCIDO] WHERE ( [COSTOCPOPRODUCIDOFecha] > @COSTOCPOPRODUCIDOFecha or [COSTOCPOPRODUCIDOFecha] = @COSTOCPOPRODUCIDOFecha and [COSTOCPOPRODUCIDOMes] > @COSTOCPOPRODUCIDOMes or [COSTOCPOPRODUCIDOMes] = @COSTOCPOPRODUCIDOMes and [COSTOCPOPRODUCIDOFecha] = @COSTOCPOPRODUCIDOFecha and [COSTOCPOPRODUCIDOAno] > @COSTOCPOPRODUCIDOAno or [COSTOCPOPRODUCIDOAno] = @COSTOCPOPRODUCIDOAno and [COSTOCPOPRODUCIDOMes] = @COSTOCPOPRODUCIDOMes and [COSTOCPOPRODUCIDOFecha] = @COSTOCPOPRODUCIDOFecha and [Cod_Area] > @Cod_Area or [Cod_Area] = @Cod_Area and [COSTOCPOPRODUCIDOAno] = @COSTOCPOPRODUCIDOAno and [COSTOCPOPRODUCIDOMes] = @COSTOCPOPRODUCIDOMes and [COSTOCPOPRODUCIDOFecha] = @COSTOCPOPRODUCIDOFecha and [IndicadoresCodigo] > @IndicadoresCodigo or [IndicadoresCodigo] = @IndicadoresCodigo and [Cod_Area] = @Cod_Area and [COSTOCPOPRODUCIDOAno] = @COSTOCPOPRODUCIDOAno and [COSTOCPOPRODUCIDOMes] = @COSTOCPOPRODUCIDOMes and [COSTOCPOPRODUCIDOFecha] = @COSTOCPOPRODUCIDOFecha and [TIPOSCPOCod] > @TIPOSCPOCod or [TIPOSCPOCod] = @TIPOSCPOCod and [IndicadoresCodigo] = @IndicadoresCodigo and [Cod_Area] = @Cod_Area and [COSTOCPOPRODUCIDOAno] = @COSTOCPOPRODUCIDOAno and [COSTOCPOPRODUCIDOMes] = @COSTOCPOPRODUCIDOMes and [COSTOCPOPRODUCIDOFecha] = @COSTOCPOPRODUCIDOFecha and [TipoProductoCod] > @TipoProductoCod) ORDER BY [COSTOCPOPRODUCIDOFecha], [COSTOCPOPRODUCIDOMes], [COSTOCPOPRODUCIDOAno], [Cod_Area], [IndicadoresCodigo], [TIPOSCPOCod], [TipoProductoCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y14,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000Y15", "SELECT TOP 1 [COSTOCPOPRODUCIDOFecha], [COSTOCPOPRODUCIDOMes], [COSTOCPOPRODUCIDOAno], [Cod_Area], [IndicadoresCodigo], [TIPOSCPOCod], [TipoProductoCod] FROM [COSTOCPOPRODUCIDO] WHERE ( [COSTOCPOPRODUCIDOFecha] < @COSTOCPOPRODUCIDOFecha or [COSTOCPOPRODUCIDOFecha] = @COSTOCPOPRODUCIDOFecha and [COSTOCPOPRODUCIDOMes] < @COSTOCPOPRODUCIDOMes or [COSTOCPOPRODUCIDOMes] = @COSTOCPOPRODUCIDOMes and [COSTOCPOPRODUCIDOFecha] = @COSTOCPOPRODUCIDOFecha and [COSTOCPOPRODUCIDOAno] < @COSTOCPOPRODUCIDOAno or [COSTOCPOPRODUCIDOAno] = @COSTOCPOPRODUCIDOAno and [COSTOCPOPRODUCIDOMes] = @COSTOCPOPRODUCIDOMes and [COSTOCPOPRODUCIDOFecha] = @COSTOCPOPRODUCIDOFecha and [Cod_Area] < @Cod_Area or [Cod_Area] = @Cod_Area and [COSTOCPOPRODUCIDOAno] = @COSTOCPOPRODUCIDOAno and [COSTOCPOPRODUCIDOMes] = @COSTOCPOPRODUCIDOMes and [COSTOCPOPRODUCIDOFecha] = @COSTOCPOPRODUCIDOFecha and [IndicadoresCodigo] < @IndicadoresCodigo or [IndicadoresCodigo] = @IndicadoresCodigo and [Cod_Area] = @Cod_Area and [COSTOCPOPRODUCIDOAno] = @COSTOCPOPRODUCIDOAno and [COSTOCPOPRODUCIDOMes] = @COSTOCPOPRODUCIDOMes and [COSTOCPOPRODUCIDOFecha] = @COSTOCPOPRODUCIDOFecha and [TIPOSCPOCod] < @TIPOSCPOCod or [TIPOSCPOCod] = @TIPOSCPOCod and [IndicadoresCodigo] = @IndicadoresCodigo and [Cod_Area] = @Cod_Area and [COSTOCPOPRODUCIDOAno] = @COSTOCPOPRODUCIDOAno and [COSTOCPOPRODUCIDOMes] = @COSTOCPOPRODUCIDOMes and [COSTOCPOPRODUCIDOFecha] = @COSTOCPOPRODUCIDOFecha and [TipoProductoCod] < @TipoProductoCod) ORDER BY [COSTOCPOPRODUCIDOFecha] DESC, [COSTOCPOPRODUCIDOMes] DESC, [COSTOCPOPRODUCIDOAno] DESC, [Cod_Area] DESC, [IndicadoresCodigo] DESC, [TIPOSCPOCod] DESC, [TipoProductoCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y15,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000Y16", "INSERT INTO [COSTOCPOPRODUCIDO]([COSTOCPOPRODUCIDOFecha], [COSTOCPOPRODUCIDOMes], [COSTOCPOPRODUCIDOAno], [COSTOCPOPRODUCIDOValor], [COSTOCPOPRODUCIDOUser], [COSTOCPOPRODUCIDOReg], [COSTOCPOPRODUCIDOHor], [Cod_Area], [IndicadoresCodigo], [TIPOSCPOCod], [TipoProductoCod]) VALUES(@COSTOCPOPRODUCIDOFecha, @COSTOCPOPRODUCIDOMes, @COSTOCPOPRODUCIDOAno, @COSTOCPOPRODUCIDOValor, @COSTOCPOPRODUCIDOUser, @COSTOCPOPRODUCIDOReg, @COSTOCPOPRODUCIDOHor, @Cod_Area, @IndicadoresCodigo, @TIPOSCPOCod, @TipoProductoCod)", GxErrorMask.GX_NOMASK,prmT000Y16)
             ,new CursorDef("T000Y17", "UPDATE [COSTOCPOPRODUCIDO] SET [COSTOCPOPRODUCIDOValor]=@COSTOCPOPRODUCIDOValor, [COSTOCPOPRODUCIDOUser]=@COSTOCPOPRODUCIDOUser, [COSTOCPOPRODUCIDOReg]=@COSTOCPOPRODUCIDOReg, [COSTOCPOPRODUCIDOHor]=@COSTOCPOPRODUCIDOHor  WHERE [COSTOCPOPRODUCIDOFecha] = @COSTOCPOPRODUCIDOFecha AND [COSTOCPOPRODUCIDOMes] = @COSTOCPOPRODUCIDOMes AND [COSTOCPOPRODUCIDOAno] = @COSTOCPOPRODUCIDOAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo AND [TIPOSCPOCod] = @TIPOSCPOCod AND [TipoProductoCod] = @TipoProductoCod", GxErrorMask.GX_NOMASK,prmT000Y17)
             ,new CursorDef("T000Y18", "DELETE FROM [COSTOCPOPRODUCIDO]  WHERE [COSTOCPOPRODUCIDOFecha] = @COSTOCPOPRODUCIDOFecha AND [COSTOCPOPRODUCIDOMes] = @COSTOCPOPRODUCIDOMes AND [COSTOCPOPRODUCIDOAno] = @COSTOCPOPRODUCIDOAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo AND [TIPOSCPOCod] = @TIPOSCPOCod AND [TipoProductoCod] = @TipoProductoCod", GxErrorMask.GX_NOMASK,prmT000Y18)
             ,new CursorDef("T000Y19", "SELECT [COSTOCPOPRODUCIDOFecha], [COSTOCPOPRODUCIDOMes], [COSTOCPOPRODUCIDOAno], [Cod_Area], [IndicadoresCodigo], [TIPOSCPOCod], [TipoProductoCod] FROM [COSTOCPOPRODUCIDO] ORDER BY [COSTOCPOPRODUCIDOFecha], [COSTOCPOPRODUCIDOMes], [COSTOCPOPRODUCIDOAno], [Cod_Area], [IndicadoresCodigo], [TIPOSCPOCod], [TipoProductoCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y19,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000Y20", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y20,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000Y21", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y21,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000Y22", "SELECT [TIPOSCPOCod] FROM [TIPOSCPO] WHERE [TIPOSCPOCod] = @TIPOSCPOCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y22,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000Y23", "SELECT [TipoProductoCod] FROM [TipoProducto] WHERE [TipoProductoCod] = @TipoProductoCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y23,1, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                return;
             case 1 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                return;
             case 12 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                return;
             case 13 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                return;
             case 17 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
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
