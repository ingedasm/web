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
   public class ventas : GXDataArea
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
            A45TipoProductoCod = GetPar( "TipoProductoCod");
            AssignAttri("", false, "A45TipoProductoCod", A45TipoProductoCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A45TipoProductoCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A49ClientesCodigo = GetPar( "ClientesCodigo");
            AssignAttri("", false, "A49ClientesCodigo", A49ClientesCodigo);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A49ClientesCodigo) ;
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
            Form.Meta.addItem("description", "Ventas", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtVentasFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("IndicadroresPalmas", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public ventas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("IndicadroresPalmas", true);
      }

      public ventas( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Ventas", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Ventas.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Ventas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Ventas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Ventas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Ventas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 4, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx00m0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"VENTASFECHA"+"'), id:'"+"VENTASFECHA"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"VENTASMES"+"'), id:'"+"VENTASMES"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"VENTASANO"+"'), id:'"+"VENTASANO"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"TIPOPRODUCTOCOD"+"'), id:'"+"TIPOPRODUCTOCOD"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_Ventas.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtVentasFecha_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVentasFecha_Internalname, "Fecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtVentasFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtVentasFecha_Internalname, context.localUtil.Format(A46VentasFecha, "99/99/99"), context.localUtil.Format( A46VentasFecha, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVentasFecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVentasFecha_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Ventas.htm");
         GxWebStd.gx_bitmap( context, edtVentasFecha_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtVentasFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Ventas.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtVentasMes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVentasMes_Internalname, "Mes", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVentasMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A47VentasMes), 4, 0, ",", "")), StringUtil.LTrim( ((edtVentasMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A47VentasMes), "ZZZ9") : context.localUtil.Format( (decimal)(A47VentasMes), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVentasMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVentasMes_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Ventas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtVentasAno_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVentasAno_Internalname, "Ano", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVentasAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A48VentasAno), 4, 0, ",", "")), StringUtil.LTrim( ((edtVentasAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A48VentasAno), "ZZZ9") : context.localUtil.Format( (decimal)(A48VentasAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVentasAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVentasAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Ventas.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipoProductoCod_Internalname, A45TipoProductoCod, StringUtil.RTrim( context.localUtil.Format( A45TipoProductoCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipoProductoCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipoProductoCod_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Ventas.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_45_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_45_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_45_Internalname, sImgUrl, imgprompt_45_Link, "", "", context.GetTheme( ), imgprompt_45_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Ventas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtVentasValor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVentasValor_Internalname, "Valor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVentasValor_Internalname, StringUtil.LTrim( StringUtil.NToC( A160VentasValor, 14, 2, ",", "")), StringUtil.LTrim( ((edtVentasValor_Enabled!=0) ? context.localUtil.Format( A160VentasValor, "ZZZZZZZZZZ9.99") : context.localUtil.Format( A160VentasValor, "ZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVentasValor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVentasValor_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Ventas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtClientesCodigo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClientesCodigo_Internalname, "Clientes Codigo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClientesCodigo_Internalname, A49ClientesCodigo, StringUtil.RTrim( context.localUtil.Format( A49ClientesCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClientesCodigo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtClientesCodigo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Ventas.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_49_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_49_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_49_Internalname, sImgUrl, imgprompt_49_Link, "", "", context.GetTheme( ), imgprompt_49_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Ventas.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Ventas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Ventas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Ventas.htm");
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
            Z46VentasFecha = context.localUtil.CToD( cgiGet( "Z46VentasFecha"), 0);
            Z47VentasMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z47VentasMes"), ",", "."), 18, MidpointRounding.ToEven));
            Z48VentasAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z48VentasAno"), ",", "."), 18, MidpointRounding.ToEven));
            Z45TipoProductoCod = cgiGet( "Z45TipoProductoCod");
            Z160VentasValor = context.localUtil.CToN( cgiGet( "Z160VentasValor"), ",", ".");
            Z49ClientesCodigo = cgiGet( "Z49ClientesCodigo");
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( context.localUtil.VCDate( cgiGet( edtVentasFecha_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Ventas Fecha"}), 1, "VENTASFECHA");
               AnyError = 1;
               GX_FocusControl = edtVentasFecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A46VentasFecha = DateTime.MinValue;
               AssignAttri("", false, "A46VentasFecha", context.localUtil.Format(A46VentasFecha, "99/99/99"));
            }
            else
            {
               A46VentasFecha = context.localUtil.CToD( cgiGet( edtVentasFecha_Internalname), 2);
               AssignAttri("", false, "A46VentasFecha", context.localUtil.Format(A46VentasFecha, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtVentasMes_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtVentasMes_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "VENTASMES");
               AnyError = 1;
               GX_FocusControl = edtVentasMes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A47VentasMes = 0;
               AssignAttri("", false, "A47VentasMes", StringUtil.LTrimStr( (decimal)(A47VentasMes), 4, 0));
            }
            else
            {
               A47VentasMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtVentasMes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A47VentasMes", StringUtil.LTrimStr( (decimal)(A47VentasMes), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtVentasAno_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtVentasAno_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "VENTASANO");
               AnyError = 1;
               GX_FocusControl = edtVentasAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A48VentasAno = 0;
               AssignAttri("", false, "A48VentasAno", StringUtil.LTrimStr( (decimal)(A48VentasAno), 4, 0));
            }
            else
            {
               A48VentasAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtVentasAno_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A48VentasAno", StringUtil.LTrimStr( (decimal)(A48VentasAno), 4, 0));
            }
            A45TipoProductoCod = cgiGet( edtTipoProductoCod_Internalname);
            AssignAttri("", false, "A45TipoProductoCod", A45TipoProductoCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtVentasValor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtVentasValor_Internalname), ",", ".") > 99999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "VENTASVALOR");
               AnyError = 1;
               GX_FocusControl = edtVentasValor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A160VentasValor = 0;
               AssignAttri("", false, "A160VentasValor", StringUtil.LTrimStr( A160VentasValor, 14, 2));
            }
            else
            {
               A160VentasValor = context.localUtil.CToN( cgiGet( edtVentasValor_Internalname), ",", ".");
               AssignAttri("", false, "A160VentasValor", StringUtil.LTrimStr( A160VentasValor, 14, 2));
            }
            A49ClientesCodigo = cgiGet( edtClientesCodigo_Internalname);
            AssignAttri("", false, "A49ClientesCodigo", A49ClientesCodigo);
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
               A46VentasFecha = context.localUtil.ParseDateParm( GetPar( "VentasFecha"));
               AssignAttri("", false, "A46VentasFecha", context.localUtil.Format(A46VentasFecha, "99/99/99"));
               A47VentasMes = (short)(Math.Round(NumberUtil.Val( GetPar( "VentasMes"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A47VentasMes", StringUtil.LTrimStr( (decimal)(A47VentasMes), 4, 0));
               A48VentasAno = (short)(Math.Round(NumberUtil.Val( GetPar( "VentasAno"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A48VentasAno", StringUtil.LTrimStr( (decimal)(A48VentasAno), 4, 0));
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
               InitAll0L22( ) ;
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
         DisableAttributes0L22( ) ;
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

      protected void ResetCaption0L0( )
      {
      }

      protected void ZM0L22( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z160VentasValor = T000L3_A160VentasValor[0];
               Z49ClientesCodigo = T000L3_A49ClientesCodigo[0];
            }
            else
            {
               Z160VentasValor = A160VentasValor;
               Z49ClientesCodigo = A49ClientesCodigo;
            }
         }
         if ( GX_JID == -2 )
         {
            Z46VentasFecha = A46VentasFecha;
            Z47VentasMes = A47VentasMes;
            Z48VentasAno = A48VentasAno;
            Z160VentasValor = A160VentasValor;
            Z45TipoProductoCod = A45TipoProductoCod;
            Z49ClientesCodigo = A49ClientesCodigo;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_45_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx00l0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"TIPOPRODUCTOCOD"+"'), id:'"+"TIPOPRODUCTOCOD"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");");
         imgprompt_49_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx00n0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"CLIENTESCODIGO"+"'), id:'"+"CLIENTESCODIGO"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
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

      protected void Load0L22( )
      {
         /* Using cursor T000L6 */
         pr_default.execute(4, new Object[] {A46VentasFecha, A47VentasMes, A48VentasAno, A45TipoProductoCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound22 = 1;
            A160VentasValor = T000L6_A160VentasValor[0];
            AssignAttri("", false, "A160VentasValor", StringUtil.LTrimStr( A160VentasValor, 14, 2));
            A49ClientesCodigo = T000L6_A49ClientesCodigo[0];
            AssignAttri("", false, "A49ClientesCodigo", A49ClientesCodigo);
            ZM0L22( -2) ;
         }
         pr_default.close(4);
         OnLoadActions0L22( ) ;
      }

      protected void OnLoadActions0L22( )
      {
      }

      protected void CheckExtendedTable0L22( )
      {
         nIsDirty_22 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A46VentasFecha) || ( DateTimeUtil.ResetTime ( A46VentasFecha ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Ventas Fecha fuera de rango", "OutOfRange", 1, "VENTASFECHA");
            AnyError = 1;
            GX_FocusControl = edtVentasFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000L4 */
         pr_default.execute(2, new Object[] {A45TipoProductoCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo Producto'.", "ForeignKeyNotFound", 1, "TIPOPRODUCTOCOD");
            AnyError = 1;
            GX_FocusControl = edtTipoProductoCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T000L5 */
         pr_default.execute(3, new Object[] {A49ClientesCodigo});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Clientes'.", "ForeignKeyNotFound", 1, "CLIENTESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtClientesCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0L22( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( string A45TipoProductoCod )
      {
         /* Using cursor T000L7 */
         pr_default.execute(5, new Object[] {A45TipoProductoCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo Producto'.", "ForeignKeyNotFound", 1, "TIPOPRODUCTOCOD");
            AnyError = 1;
            GX_FocusControl = edtTipoProductoCod_Internalname;
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

      protected void gxLoad_4( string A49ClientesCodigo )
      {
         /* Using cursor T000L8 */
         pr_default.execute(6, new Object[] {A49ClientesCodigo});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Clientes'.", "ForeignKeyNotFound", 1, "CLIENTESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtClientesCodigo_Internalname;
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

      protected void GetKey0L22( )
      {
         /* Using cursor T000L9 */
         pr_default.execute(7, new Object[] {A46VentasFecha, A47VentasMes, A48VentasAno, A45TipoProductoCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound22 = 1;
         }
         else
         {
            RcdFound22 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000L3 */
         pr_default.execute(1, new Object[] {A46VentasFecha, A47VentasMes, A48VentasAno, A45TipoProductoCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0L22( 2) ;
            RcdFound22 = 1;
            A46VentasFecha = T000L3_A46VentasFecha[0];
            AssignAttri("", false, "A46VentasFecha", context.localUtil.Format(A46VentasFecha, "99/99/99"));
            A47VentasMes = T000L3_A47VentasMes[0];
            AssignAttri("", false, "A47VentasMes", StringUtil.LTrimStr( (decimal)(A47VentasMes), 4, 0));
            A48VentasAno = T000L3_A48VentasAno[0];
            AssignAttri("", false, "A48VentasAno", StringUtil.LTrimStr( (decimal)(A48VentasAno), 4, 0));
            A160VentasValor = T000L3_A160VentasValor[0];
            AssignAttri("", false, "A160VentasValor", StringUtil.LTrimStr( A160VentasValor, 14, 2));
            A45TipoProductoCod = T000L3_A45TipoProductoCod[0];
            AssignAttri("", false, "A45TipoProductoCod", A45TipoProductoCod);
            A49ClientesCodigo = T000L3_A49ClientesCodigo[0];
            AssignAttri("", false, "A49ClientesCodigo", A49ClientesCodigo);
            Z46VentasFecha = A46VentasFecha;
            Z47VentasMes = A47VentasMes;
            Z48VentasAno = A48VentasAno;
            Z45TipoProductoCod = A45TipoProductoCod;
            sMode22 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0L22( ) ;
            if ( AnyError == 1 )
            {
               RcdFound22 = 0;
               InitializeNonKey0L22( ) ;
            }
            Gx_mode = sMode22;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound22 = 0;
            InitializeNonKey0L22( ) ;
            sMode22 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode22;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0L22( ) ;
         if ( RcdFound22 == 0 )
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
         RcdFound22 = 0;
         /* Using cursor T000L10 */
         pr_default.execute(8, new Object[] {A46VentasFecha, A47VentasMes, A48VentasAno, A45TipoProductoCod});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( DateTimeUtil.ResetTime ( T000L10_A46VentasFecha[0] ) < DateTimeUtil.ResetTime ( A46VentasFecha ) ) || ( DateTimeUtil.ResetTime ( T000L10_A46VentasFecha[0] ) == DateTimeUtil.ResetTime ( A46VentasFecha ) ) && ( T000L10_A47VentasMes[0] < A47VentasMes ) || ( T000L10_A47VentasMes[0] == A47VentasMes ) && ( DateTimeUtil.ResetTime ( T000L10_A46VentasFecha[0] ) == DateTimeUtil.ResetTime ( A46VentasFecha ) ) && ( T000L10_A48VentasAno[0] < A48VentasAno ) || ( T000L10_A48VentasAno[0] == A48VentasAno ) && ( T000L10_A47VentasMes[0] == A47VentasMes ) && ( DateTimeUtil.ResetTime ( T000L10_A46VentasFecha[0] ) == DateTimeUtil.ResetTime ( A46VentasFecha ) ) && ( StringUtil.StrCmp(T000L10_A45TipoProductoCod[0], A45TipoProductoCod) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( DateTimeUtil.ResetTime ( T000L10_A46VentasFecha[0] ) > DateTimeUtil.ResetTime ( A46VentasFecha ) ) || ( DateTimeUtil.ResetTime ( T000L10_A46VentasFecha[0] ) == DateTimeUtil.ResetTime ( A46VentasFecha ) ) && ( T000L10_A47VentasMes[0] > A47VentasMes ) || ( T000L10_A47VentasMes[0] == A47VentasMes ) && ( DateTimeUtil.ResetTime ( T000L10_A46VentasFecha[0] ) == DateTimeUtil.ResetTime ( A46VentasFecha ) ) && ( T000L10_A48VentasAno[0] > A48VentasAno ) || ( T000L10_A48VentasAno[0] == A48VentasAno ) && ( T000L10_A47VentasMes[0] == A47VentasMes ) && ( DateTimeUtil.ResetTime ( T000L10_A46VentasFecha[0] ) == DateTimeUtil.ResetTime ( A46VentasFecha ) ) && ( StringUtil.StrCmp(T000L10_A45TipoProductoCod[0], A45TipoProductoCod) > 0 ) ) )
            {
               A46VentasFecha = T000L10_A46VentasFecha[0];
               AssignAttri("", false, "A46VentasFecha", context.localUtil.Format(A46VentasFecha, "99/99/99"));
               A47VentasMes = T000L10_A47VentasMes[0];
               AssignAttri("", false, "A47VentasMes", StringUtil.LTrimStr( (decimal)(A47VentasMes), 4, 0));
               A48VentasAno = T000L10_A48VentasAno[0];
               AssignAttri("", false, "A48VentasAno", StringUtil.LTrimStr( (decimal)(A48VentasAno), 4, 0));
               A45TipoProductoCod = T000L10_A45TipoProductoCod[0];
               AssignAttri("", false, "A45TipoProductoCod", A45TipoProductoCod);
               RcdFound22 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound22 = 0;
         /* Using cursor T000L11 */
         pr_default.execute(9, new Object[] {A46VentasFecha, A47VentasMes, A48VentasAno, A45TipoProductoCod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( DateTimeUtil.ResetTime ( T000L11_A46VentasFecha[0] ) > DateTimeUtil.ResetTime ( A46VentasFecha ) ) || ( DateTimeUtil.ResetTime ( T000L11_A46VentasFecha[0] ) == DateTimeUtil.ResetTime ( A46VentasFecha ) ) && ( T000L11_A47VentasMes[0] > A47VentasMes ) || ( T000L11_A47VentasMes[0] == A47VentasMes ) && ( DateTimeUtil.ResetTime ( T000L11_A46VentasFecha[0] ) == DateTimeUtil.ResetTime ( A46VentasFecha ) ) && ( T000L11_A48VentasAno[0] > A48VentasAno ) || ( T000L11_A48VentasAno[0] == A48VentasAno ) && ( T000L11_A47VentasMes[0] == A47VentasMes ) && ( DateTimeUtil.ResetTime ( T000L11_A46VentasFecha[0] ) == DateTimeUtil.ResetTime ( A46VentasFecha ) ) && ( StringUtil.StrCmp(T000L11_A45TipoProductoCod[0], A45TipoProductoCod) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( DateTimeUtil.ResetTime ( T000L11_A46VentasFecha[0] ) < DateTimeUtil.ResetTime ( A46VentasFecha ) ) || ( DateTimeUtil.ResetTime ( T000L11_A46VentasFecha[0] ) == DateTimeUtil.ResetTime ( A46VentasFecha ) ) && ( T000L11_A47VentasMes[0] < A47VentasMes ) || ( T000L11_A47VentasMes[0] == A47VentasMes ) && ( DateTimeUtil.ResetTime ( T000L11_A46VentasFecha[0] ) == DateTimeUtil.ResetTime ( A46VentasFecha ) ) && ( T000L11_A48VentasAno[0] < A48VentasAno ) || ( T000L11_A48VentasAno[0] == A48VentasAno ) && ( T000L11_A47VentasMes[0] == A47VentasMes ) && ( DateTimeUtil.ResetTime ( T000L11_A46VentasFecha[0] ) == DateTimeUtil.ResetTime ( A46VentasFecha ) ) && ( StringUtil.StrCmp(T000L11_A45TipoProductoCod[0], A45TipoProductoCod) < 0 ) ) )
            {
               A46VentasFecha = T000L11_A46VentasFecha[0];
               AssignAttri("", false, "A46VentasFecha", context.localUtil.Format(A46VentasFecha, "99/99/99"));
               A47VentasMes = T000L11_A47VentasMes[0];
               AssignAttri("", false, "A47VentasMes", StringUtil.LTrimStr( (decimal)(A47VentasMes), 4, 0));
               A48VentasAno = T000L11_A48VentasAno[0];
               AssignAttri("", false, "A48VentasAno", StringUtil.LTrimStr( (decimal)(A48VentasAno), 4, 0));
               A45TipoProductoCod = T000L11_A45TipoProductoCod[0];
               AssignAttri("", false, "A45TipoProductoCod", A45TipoProductoCod);
               RcdFound22 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0L22( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtVentasFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0L22( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound22 == 1 )
            {
               if ( ( DateTimeUtil.ResetTime ( A46VentasFecha ) != DateTimeUtil.ResetTime ( Z46VentasFecha ) ) || ( A47VentasMes != Z47VentasMes ) || ( A48VentasAno != Z48VentasAno ) || ( StringUtil.StrCmp(A45TipoProductoCod, Z45TipoProductoCod) != 0 ) )
               {
                  A46VentasFecha = Z46VentasFecha;
                  AssignAttri("", false, "A46VentasFecha", context.localUtil.Format(A46VentasFecha, "99/99/99"));
                  A47VentasMes = Z47VentasMes;
                  AssignAttri("", false, "A47VentasMes", StringUtil.LTrimStr( (decimal)(A47VentasMes), 4, 0));
                  A48VentasAno = Z48VentasAno;
                  AssignAttri("", false, "A48VentasAno", StringUtil.LTrimStr( (decimal)(A48VentasAno), 4, 0));
                  A45TipoProductoCod = Z45TipoProductoCod;
                  AssignAttri("", false, "A45TipoProductoCod", A45TipoProductoCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "VENTASFECHA");
                  AnyError = 1;
                  GX_FocusControl = edtVentasFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtVentasFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0L22( ) ;
                  GX_FocusControl = edtVentasFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( DateTimeUtil.ResetTime ( A46VentasFecha ) != DateTimeUtil.ResetTime ( Z46VentasFecha ) ) || ( A47VentasMes != Z47VentasMes ) || ( A48VentasAno != Z48VentasAno ) || ( StringUtil.StrCmp(A45TipoProductoCod, Z45TipoProductoCod) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtVentasFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0L22( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "VENTASFECHA");
                     AnyError = 1;
                     GX_FocusControl = edtVentasFecha_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtVentasFecha_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0L22( ) ;
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
         if ( ( DateTimeUtil.ResetTime ( A46VentasFecha ) != DateTimeUtil.ResetTime ( Z46VentasFecha ) ) || ( A47VentasMes != Z47VentasMes ) || ( A48VentasAno != Z48VentasAno ) || ( StringUtil.StrCmp(A45TipoProductoCod, Z45TipoProductoCod) != 0 ) )
         {
            A46VentasFecha = Z46VentasFecha;
            AssignAttri("", false, "A46VentasFecha", context.localUtil.Format(A46VentasFecha, "99/99/99"));
            A47VentasMes = Z47VentasMes;
            AssignAttri("", false, "A47VentasMes", StringUtil.LTrimStr( (decimal)(A47VentasMes), 4, 0));
            A48VentasAno = Z48VentasAno;
            AssignAttri("", false, "A48VentasAno", StringUtil.LTrimStr( (decimal)(A48VentasAno), 4, 0));
            A45TipoProductoCod = Z45TipoProductoCod;
            AssignAttri("", false, "A45TipoProductoCod", A45TipoProductoCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "VENTASFECHA");
            AnyError = 1;
            GX_FocusControl = edtVentasFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtVentasFecha_Internalname;
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
         if ( RcdFound22 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "VENTASFECHA");
            AnyError = 1;
            GX_FocusControl = edtVentasFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtVentasValor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0L22( ) ;
         if ( RcdFound22 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtVentasValor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0L22( ) ;
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
         if ( RcdFound22 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtVentasValor_Internalname;
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
         if ( RcdFound22 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtVentasValor_Internalname;
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
         ScanStart0L22( ) ;
         if ( RcdFound22 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound22 != 0 )
            {
               ScanNext0L22( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtVentasValor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0L22( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0L22( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000L2 */
            pr_default.execute(0, new Object[] {A46VentasFecha, A47VentasMes, A48VentasAno, A45TipoProductoCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Ventas"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z160VentasValor != T000L2_A160VentasValor[0] ) || ( StringUtil.StrCmp(Z49ClientesCodigo, T000L2_A49ClientesCodigo[0]) != 0 ) )
            {
               if ( Z160VentasValor != T000L2_A160VentasValor[0] )
               {
                  GXUtil.WriteLog("ventas:[seudo value changed for attri]"+"VentasValor");
                  GXUtil.WriteLogRaw("Old: ",Z160VentasValor);
                  GXUtil.WriteLogRaw("Current: ",T000L2_A160VentasValor[0]);
               }
               if ( StringUtil.StrCmp(Z49ClientesCodigo, T000L2_A49ClientesCodigo[0]) != 0 )
               {
                  GXUtil.WriteLog("ventas:[seudo value changed for attri]"+"ClientesCodigo");
                  GXUtil.WriteLogRaw("Old: ",Z49ClientesCodigo);
                  GXUtil.WriteLogRaw("Current: ",T000L2_A49ClientesCodigo[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Ventas"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0L22( )
      {
         BeforeValidate0L22( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0L22( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0L22( 0) ;
            CheckOptimisticConcurrency0L22( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0L22( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0L22( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000L12 */
                     pr_default.execute(10, new Object[] {A46VentasFecha, A47VentasMes, A48VentasAno, A160VentasValor, A45TipoProductoCod, A49ClientesCodigo});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Ventas");
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
                           ResetCaption0L0( ) ;
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
               Load0L22( ) ;
            }
            EndLevel0L22( ) ;
         }
         CloseExtendedTableCursors0L22( ) ;
      }

      protected void Update0L22( )
      {
         BeforeValidate0L22( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0L22( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0L22( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0L22( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0L22( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000L13 */
                     pr_default.execute(11, new Object[] {A160VentasValor, A49ClientesCodigo, A46VentasFecha, A47VentasMes, A48VentasAno, A45TipoProductoCod});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("Ventas");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Ventas"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0L22( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0L0( ) ;
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
            EndLevel0L22( ) ;
         }
         CloseExtendedTableCursors0L22( ) ;
      }

      protected void DeferredUpdate0L22( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0L22( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0L22( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0L22( ) ;
            AfterConfirm0L22( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0L22( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000L14 */
                  pr_default.execute(12, new Object[] {A46VentasFecha, A47VentasMes, A48VentasAno, A45TipoProductoCod});
                  pr_default.close(12);
                  pr_default.SmartCacheProvider.SetUpdated("Ventas");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound22 == 0 )
                        {
                           InitAll0L22( ) ;
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
                        ResetCaption0L0( ) ;
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
         sMode22 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0L22( ) ;
         Gx_mode = sMode22;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0L22( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0L22( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0L22( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("ventas",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0L0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("ventas",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0L22( )
      {
         /* Using cursor T000L15 */
         pr_default.execute(13);
         RcdFound22 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound22 = 1;
            A46VentasFecha = T000L15_A46VentasFecha[0];
            AssignAttri("", false, "A46VentasFecha", context.localUtil.Format(A46VentasFecha, "99/99/99"));
            A47VentasMes = T000L15_A47VentasMes[0];
            AssignAttri("", false, "A47VentasMes", StringUtil.LTrimStr( (decimal)(A47VentasMes), 4, 0));
            A48VentasAno = T000L15_A48VentasAno[0];
            AssignAttri("", false, "A48VentasAno", StringUtil.LTrimStr( (decimal)(A48VentasAno), 4, 0));
            A45TipoProductoCod = T000L15_A45TipoProductoCod[0];
            AssignAttri("", false, "A45TipoProductoCod", A45TipoProductoCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0L22( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound22 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound22 = 1;
            A46VentasFecha = T000L15_A46VentasFecha[0];
            AssignAttri("", false, "A46VentasFecha", context.localUtil.Format(A46VentasFecha, "99/99/99"));
            A47VentasMes = T000L15_A47VentasMes[0];
            AssignAttri("", false, "A47VentasMes", StringUtil.LTrimStr( (decimal)(A47VentasMes), 4, 0));
            A48VentasAno = T000L15_A48VentasAno[0];
            AssignAttri("", false, "A48VentasAno", StringUtil.LTrimStr( (decimal)(A48VentasAno), 4, 0));
            A45TipoProductoCod = T000L15_A45TipoProductoCod[0];
            AssignAttri("", false, "A45TipoProductoCod", A45TipoProductoCod);
         }
      }

      protected void ScanEnd0L22( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm0L22( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0L22( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0L22( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0L22( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0L22( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0L22( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0L22( )
      {
         edtVentasFecha_Enabled = 0;
         AssignProp("", false, edtVentasFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVentasFecha_Enabled), 5, 0), true);
         edtVentasMes_Enabled = 0;
         AssignProp("", false, edtVentasMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVentasMes_Enabled), 5, 0), true);
         edtVentasAno_Enabled = 0;
         AssignProp("", false, edtVentasAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVentasAno_Enabled), 5, 0), true);
         edtTipoProductoCod_Enabled = 0;
         AssignProp("", false, edtTipoProductoCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipoProductoCod_Enabled), 5, 0), true);
         edtVentasValor_Enabled = 0;
         AssignProp("", false, edtVentasValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVentasValor_Enabled), 5, 0), true);
         edtClientesCodigo_Enabled = 0;
         AssignProp("", false, edtClientesCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClientesCodigo_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0L22( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0L0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("ventas.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z46VentasFecha", context.localUtil.DToC( Z46VentasFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z47VentasMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z47VentasMes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z48VentasAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z48VentasAno), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z45TipoProductoCod", Z45TipoProductoCod);
         GxWebStd.gx_hidden_field( context, "Z160VentasValor", StringUtil.LTrim( StringUtil.NToC( Z160VentasValor, 14, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z49ClientesCodigo", Z49ClientesCodigo);
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
         return formatLink("ventas.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Ventas" ;
      }

      public override string GetPgmdesc( )
      {
         return "Ventas" ;
      }

      protected void InitializeNonKey0L22( )
      {
         A160VentasValor = 0;
         AssignAttri("", false, "A160VentasValor", StringUtil.LTrimStr( A160VentasValor, 14, 2));
         A49ClientesCodigo = "";
         AssignAttri("", false, "A49ClientesCodigo", A49ClientesCodigo);
         Z160VentasValor = 0;
         Z49ClientesCodigo = "";
      }

      protected void InitAll0L22( )
      {
         A46VentasFecha = DateTime.MinValue;
         AssignAttri("", false, "A46VentasFecha", context.localUtil.Format(A46VentasFecha, "99/99/99"));
         A47VentasMes = 0;
         AssignAttri("", false, "A47VentasMes", StringUtil.LTrimStr( (decimal)(A47VentasMes), 4, 0));
         A48VentasAno = 0;
         AssignAttri("", false, "A48VentasAno", StringUtil.LTrimStr( (decimal)(A48VentasAno), 4, 0));
         A45TipoProductoCod = "";
         AssignAttri("", false, "A45TipoProductoCod", A45TipoProductoCod);
         InitializeNonKey0L22( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20247231022588", true, true);
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
         context.AddJavascriptSource("ventas.js", "?20247231022588", false, true);
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
         edtVentasFecha_Internalname = "VENTASFECHA";
         edtVentasMes_Internalname = "VENTASMES";
         edtVentasAno_Internalname = "VENTASANO";
         edtTipoProductoCod_Internalname = "TIPOPRODUCTOCOD";
         edtVentasValor_Internalname = "VENTASVALOR";
         edtClientesCodigo_Internalname = "CLIENTESCODIGO";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_45_Internalname = "PROMPT_45";
         imgprompt_49_Internalname = "PROMPT_49";
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
         Form.Caption = "Ventas";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         imgprompt_49_Visible = 1;
         imgprompt_49_Link = "";
         edtClientesCodigo_Jsonclick = "";
         edtClientesCodigo_Enabled = 1;
         edtVentasValor_Jsonclick = "";
         edtVentasValor_Enabled = 1;
         imgprompt_45_Visible = 1;
         imgprompt_45_Link = "";
         edtTipoProductoCod_Jsonclick = "";
         edtTipoProductoCod_Enabled = 1;
         edtVentasAno_Jsonclick = "";
         edtVentasAno_Enabled = 1;
         edtVentasMes_Jsonclick = "";
         edtVentasMes_Enabled = 1;
         edtVentasFecha_Jsonclick = "";
         edtVentasFecha_Enabled = 1;
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
         /* Using cursor T000L16 */
         pr_default.execute(14, new Object[] {A45TipoProductoCod});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo Producto'.", "ForeignKeyNotFound", 1, "TIPOPRODUCTOCOD");
            AnyError = 1;
            GX_FocusControl = edtTipoProductoCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(14);
         GX_FocusControl = edtVentasValor_Internalname;
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

      public void Valid_Tipoproductocod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T000L16 */
         pr_default.execute(14, new Object[] {A45TipoProductoCod});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo Producto'.", "ForeignKeyNotFound", 1, "TIPOPRODUCTOCOD");
            AnyError = 1;
            GX_FocusControl = edtTipoProductoCod_Internalname;
         }
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A160VentasValor", StringUtil.LTrim( StringUtil.NToC( A160VentasValor, 14, 2, ".", "")));
         AssignAttri("", false, "A49ClientesCodigo", A49ClientesCodigo);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z46VentasFecha", context.localUtil.Format(Z46VentasFecha, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z47VentasMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z47VentasMes), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z48VentasAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z48VentasAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z45TipoProductoCod", Z45TipoProductoCod);
         GxWebStd.gx_hidden_field( context, "Z160VentasValor", StringUtil.LTrim( StringUtil.NToC( Z160VentasValor, 14, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z49ClientesCodigo", Z49ClientesCodigo);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Clientescodigo( )
      {
         /* Using cursor T000L17 */
         pr_default.execute(15, new Object[] {A49ClientesCodigo});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Clientes'.", "ForeignKeyNotFound", 1, "CLIENTESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtClientesCodigo_Internalname;
         }
         pr_default.close(15);
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
         setEventMetadata("VALID_VENTASFECHA","{handler:'Valid_Ventasfecha',iparms:[]");
         setEventMetadata("VALID_VENTASFECHA",",oparms:[]}");
         setEventMetadata("VALID_VENTASMES","{handler:'Valid_Ventasmes',iparms:[]");
         setEventMetadata("VALID_VENTASMES",",oparms:[]}");
         setEventMetadata("VALID_VENTASANO","{handler:'Valid_Ventasano',iparms:[]");
         setEventMetadata("VALID_VENTASANO",",oparms:[]}");
         setEventMetadata("VALID_TIPOPRODUCTOCOD","{handler:'Valid_Tipoproductocod',iparms:[{av:'A46VentasFecha',fld:'VENTASFECHA',pic:''},{av:'A47VentasMes',fld:'VENTASMES',pic:'ZZZ9'},{av:'A48VentasAno',fld:'VENTASANO',pic:'ZZZ9'},{av:'A45TipoProductoCod',fld:'TIPOPRODUCTOCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_TIPOPRODUCTOCOD",",oparms:[{av:'A160VentasValor',fld:'VENTASVALOR',pic:'ZZZZZZZZZZ9.99'},{av:'A49ClientesCodigo',fld:'CLIENTESCODIGO',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z46VentasFecha'},{av:'Z47VentasMes'},{av:'Z48VentasAno'},{av:'Z45TipoProductoCod'},{av:'Z160VentasValor'},{av:'Z49ClientesCodigo'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_CLIENTESCODIGO","{handler:'Valid_Clientescodigo',iparms:[{av:'A49ClientesCodigo',fld:'CLIENTESCODIGO',pic:''}]");
         setEventMetadata("VALID_CLIENTESCODIGO",",oparms:[]}");
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
         Z46VentasFecha = DateTime.MinValue;
         Z45TipoProductoCod = "";
         Z49ClientesCodigo = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A45TipoProductoCod = "";
         A49ClientesCodigo = "";
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
         A46VentasFecha = DateTime.MinValue;
         imgprompt_45_gximage = "";
         sImgUrl = "";
         imgprompt_49_gximage = "";
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
         T000L6_A46VentasFecha = new DateTime[] {DateTime.MinValue} ;
         T000L6_A47VentasMes = new short[1] ;
         T000L6_A48VentasAno = new short[1] ;
         T000L6_A160VentasValor = new decimal[1] ;
         T000L6_A45TipoProductoCod = new string[] {""} ;
         T000L6_A49ClientesCodigo = new string[] {""} ;
         T000L4_A45TipoProductoCod = new string[] {""} ;
         T000L5_A49ClientesCodigo = new string[] {""} ;
         T000L7_A45TipoProductoCod = new string[] {""} ;
         T000L8_A49ClientesCodigo = new string[] {""} ;
         T000L9_A46VentasFecha = new DateTime[] {DateTime.MinValue} ;
         T000L9_A47VentasMes = new short[1] ;
         T000L9_A48VentasAno = new short[1] ;
         T000L9_A45TipoProductoCod = new string[] {""} ;
         T000L3_A46VentasFecha = new DateTime[] {DateTime.MinValue} ;
         T000L3_A47VentasMes = new short[1] ;
         T000L3_A48VentasAno = new short[1] ;
         T000L3_A160VentasValor = new decimal[1] ;
         T000L3_A45TipoProductoCod = new string[] {""} ;
         T000L3_A49ClientesCodigo = new string[] {""} ;
         sMode22 = "";
         T000L10_A46VentasFecha = new DateTime[] {DateTime.MinValue} ;
         T000L10_A47VentasMes = new short[1] ;
         T000L10_A48VentasAno = new short[1] ;
         T000L10_A45TipoProductoCod = new string[] {""} ;
         T000L11_A46VentasFecha = new DateTime[] {DateTime.MinValue} ;
         T000L11_A47VentasMes = new short[1] ;
         T000L11_A48VentasAno = new short[1] ;
         T000L11_A45TipoProductoCod = new string[] {""} ;
         T000L2_A46VentasFecha = new DateTime[] {DateTime.MinValue} ;
         T000L2_A47VentasMes = new short[1] ;
         T000L2_A48VentasAno = new short[1] ;
         T000L2_A160VentasValor = new decimal[1] ;
         T000L2_A45TipoProductoCod = new string[] {""} ;
         T000L2_A49ClientesCodigo = new string[] {""} ;
         T000L15_A46VentasFecha = new DateTime[] {DateTime.MinValue} ;
         T000L15_A47VentasMes = new short[1] ;
         T000L15_A48VentasAno = new short[1] ;
         T000L15_A45TipoProductoCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T000L16_A45TipoProductoCod = new string[] {""} ;
         ZZ46VentasFecha = DateTime.MinValue;
         ZZ45TipoProductoCod = "";
         ZZ49ClientesCodigo = "";
         T000L17_A49ClientesCodigo = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ventas__default(),
            new Object[][] {
                new Object[] {
               T000L2_A46VentasFecha, T000L2_A47VentasMes, T000L2_A48VentasAno, T000L2_A160VentasValor, T000L2_A45TipoProductoCod, T000L2_A49ClientesCodigo
               }
               , new Object[] {
               T000L3_A46VentasFecha, T000L3_A47VentasMes, T000L3_A48VentasAno, T000L3_A160VentasValor, T000L3_A45TipoProductoCod, T000L3_A49ClientesCodigo
               }
               , new Object[] {
               T000L4_A45TipoProductoCod
               }
               , new Object[] {
               T000L5_A49ClientesCodigo
               }
               , new Object[] {
               T000L6_A46VentasFecha, T000L6_A47VentasMes, T000L6_A48VentasAno, T000L6_A160VentasValor, T000L6_A45TipoProductoCod, T000L6_A49ClientesCodigo
               }
               , new Object[] {
               T000L7_A45TipoProductoCod
               }
               , new Object[] {
               T000L8_A49ClientesCodigo
               }
               , new Object[] {
               T000L9_A46VentasFecha, T000L9_A47VentasMes, T000L9_A48VentasAno, T000L9_A45TipoProductoCod
               }
               , new Object[] {
               T000L10_A46VentasFecha, T000L10_A47VentasMes, T000L10_A48VentasAno, T000L10_A45TipoProductoCod
               }
               , new Object[] {
               T000L11_A46VentasFecha, T000L11_A47VentasMes, T000L11_A48VentasAno, T000L11_A45TipoProductoCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000L15_A46VentasFecha, T000L15_A47VentasMes, T000L15_A48VentasAno, T000L15_A45TipoProductoCod
               }
               , new Object[] {
               T000L16_A45TipoProductoCod
               }
               , new Object[] {
               T000L17_A49ClientesCodigo
               }
            }
         );
      }

      private short Z47VentasMes ;
      private short Z48VentasAno ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A47VentasMes ;
      private short A48VentasAno ;
      private short GX_JID ;
      private short RcdFound22 ;
      private short nIsDirty_22 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ47VentasMes ;
      private short ZZ48VentasAno ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtVentasFecha_Enabled ;
      private int edtVentasMes_Enabled ;
      private int edtVentasAno_Enabled ;
      private int edtTipoProductoCod_Enabled ;
      private int imgprompt_45_Visible ;
      private int edtVentasValor_Enabled ;
      private int edtClientesCodigo_Enabled ;
      private int imgprompt_49_Visible ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private decimal Z160VentasValor ;
      private decimal A160VentasValor ;
      private decimal ZZ160VentasValor ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtVentasFecha_Internalname ;
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
      private string edtVentasFecha_Jsonclick ;
      private string edtVentasMes_Internalname ;
      private string edtVentasMes_Jsonclick ;
      private string edtVentasAno_Internalname ;
      private string edtVentasAno_Jsonclick ;
      private string edtTipoProductoCod_Internalname ;
      private string edtTipoProductoCod_Jsonclick ;
      private string imgprompt_45_gximage ;
      private string sImgUrl ;
      private string imgprompt_45_Internalname ;
      private string imgprompt_45_Link ;
      private string edtVentasValor_Internalname ;
      private string edtVentasValor_Jsonclick ;
      private string edtClientesCodigo_Internalname ;
      private string edtClientesCodigo_Jsonclick ;
      private string imgprompt_49_gximage ;
      private string imgprompt_49_Internalname ;
      private string imgprompt_49_Link ;
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
      private string sMode22 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z46VentasFecha ;
      private DateTime A46VentasFecha ;
      private DateTime ZZ46VentasFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string Z45TipoProductoCod ;
      private string Z49ClientesCodigo ;
      private string A45TipoProductoCod ;
      private string A49ClientesCodigo ;
      private string ZZ45TipoProductoCod ;
      private string ZZ49ClientesCodigo ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] T000L6_A46VentasFecha ;
      private short[] T000L6_A47VentasMes ;
      private short[] T000L6_A48VentasAno ;
      private decimal[] T000L6_A160VentasValor ;
      private string[] T000L6_A45TipoProductoCod ;
      private string[] T000L6_A49ClientesCodigo ;
      private string[] T000L4_A45TipoProductoCod ;
      private string[] T000L5_A49ClientesCodigo ;
      private string[] T000L7_A45TipoProductoCod ;
      private string[] T000L8_A49ClientesCodigo ;
      private DateTime[] T000L9_A46VentasFecha ;
      private short[] T000L9_A47VentasMes ;
      private short[] T000L9_A48VentasAno ;
      private string[] T000L9_A45TipoProductoCod ;
      private DateTime[] T000L3_A46VentasFecha ;
      private short[] T000L3_A47VentasMes ;
      private short[] T000L3_A48VentasAno ;
      private decimal[] T000L3_A160VentasValor ;
      private string[] T000L3_A45TipoProductoCod ;
      private string[] T000L3_A49ClientesCodigo ;
      private DateTime[] T000L10_A46VentasFecha ;
      private short[] T000L10_A47VentasMes ;
      private short[] T000L10_A48VentasAno ;
      private string[] T000L10_A45TipoProductoCod ;
      private DateTime[] T000L11_A46VentasFecha ;
      private short[] T000L11_A47VentasMes ;
      private short[] T000L11_A48VentasAno ;
      private string[] T000L11_A45TipoProductoCod ;
      private DateTime[] T000L2_A46VentasFecha ;
      private short[] T000L2_A47VentasMes ;
      private short[] T000L2_A48VentasAno ;
      private decimal[] T000L2_A160VentasValor ;
      private string[] T000L2_A45TipoProductoCod ;
      private string[] T000L2_A49ClientesCodigo ;
      private DateTime[] T000L15_A46VentasFecha ;
      private short[] T000L15_A47VentasMes ;
      private short[] T000L15_A48VentasAno ;
      private string[] T000L15_A45TipoProductoCod ;
      private string[] T000L16_A45TipoProductoCod ;
      private string[] T000L17_A49ClientesCodigo ;
      private GXWebForm Form ;
   }

   public class ventas__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT000L6;
          prmT000L6 = new Object[] {
          new ParDef("@VentasFecha",GXType.Date,8,0) ,
          new ParDef("@VentasMes",GXType.Int16,4,0) ,
          new ParDef("@VentasAno",GXType.Int16,4,0) ,
          new ParDef("@TipoProductoCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000L4;
          prmT000L4 = new Object[] {
          new ParDef("@TipoProductoCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000L5;
          prmT000L5 = new Object[] {
          new ParDef("@ClientesCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000L7;
          prmT000L7 = new Object[] {
          new ParDef("@TipoProductoCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000L8;
          prmT000L8 = new Object[] {
          new ParDef("@ClientesCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000L9;
          prmT000L9 = new Object[] {
          new ParDef("@VentasFecha",GXType.Date,8,0) ,
          new ParDef("@VentasMes",GXType.Int16,4,0) ,
          new ParDef("@VentasAno",GXType.Int16,4,0) ,
          new ParDef("@TipoProductoCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000L3;
          prmT000L3 = new Object[] {
          new ParDef("@VentasFecha",GXType.Date,8,0) ,
          new ParDef("@VentasMes",GXType.Int16,4,0) ,
          new ParDef("@VentasAno",GXType.Int16,4,0) ,
          new ParDef("@TipoProductoCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000L10;
          prmT000L10 = new Object[] {
          new ParDef("@VentasFecha",GXType.Date,8,0) ,
          new ParDef("@VentasMes",GXType.Int16,4,0) ,
          new ParDef("@VentasAno",GXType.Int16,4,0) ,
          new ParDef("@TipoProductoCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000L11;
          prmT000L11 = new Object[] {
          new ParDef("@VentasFecha",GXType.Date,8,0) ,
          new ParDef("@VentasMes",GXType.Int16,4,0) ,
          new ParDef("@VentasAno",GXType.Int16,4,0) ,
          new ParDef("@TipoProductoCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000L2;
          prmT000L2 = new Object[] {
          new ParDef("@VentasFecha",GXType.Date,8,0) ,
          new ParDef("@VentasMes",GXType.Int16,4,0) ,
          new ParDef("@VentasAno",GXType.Int16,4,0) ,
          new ParDef("@TipoProductoCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000L12;
          prmT000L12 = new Object[] {
          new ParDef("@VentasFecha",GXType.Date,8,0) ,
          new ParDef("@VentasMes",GXType.Int16,4,0) ,
          new ParDef("@VentasAno",GXType.Int16,4,0) ,
          new ParDef("@VentasValor",GXType.Decimal,14,2) ,
          new ParDef("@TipoProductoCod",GXType.NVarChar,40,0) ,
          new ParDef("@ClientesCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000L13;
          prmT000L13 = new Object[] {
          new ParDef("@VentasValor",GXType.Decimal,14,2) ,
          new ParDef("@ClientesCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@VentasFecha",GXType.Date,8,0) ,
          new ParDef("@VentasMes",GXType.Int16,4,0) ,
          new ParDef("@VentasAno",GXType.Int16,4,0) ,
          new ParDef("@TipoProductoCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000L14;
          prmT000L14 = new Object[] {
          new ParDef("@VentasFecha",GXType.Date,8,0) ,
          new ParDef("@VentasMes",GXType.Int16,4,0) ,
          new ParDef("@VentasAno",GXType.Int16,4,0) ,
          new ParDef("@TipoProductoCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000L15;
          prmT000L15 = new Object[] {
          };
          Object[] prmT000L16;
          prmT000L16 = new Object[] {
          new ParDef("@TipoProductoCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000L17;
          prmT000L17 = new Object[] {
          new ParDef("@ClientesCodigo",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("T000L2", "SELECT [VentasFecha], [VentasMes], [VentasAno], [VentasValor], [TipoProductoCod], [ClientesCodigo] FROM [Ventas] WITH (UPDLOCK) WHERE [VentasFecha] = @VentasFecha AND [VentasMes] = @VentasMes AND [VentasAno] = @VentasAno AND [TipoProductoCod] = @TipoProductoCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000L3", "SELECT [VentasFecha], [VentasMes], [VentasAno], [VentasValor], [TipoProductoCod], [ClientesCodigo] FROM [Ventas] WHERE [VentasFecha] = @VentasFecha AND [VentasMes] = @VentasMes AND [VentasAno] = @VentasAno AND [TipoProductoCod] = @TipoProductoCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000L4", "SELECT [TipoProductoCod] FROM [TipoProducto] WHERE [TipoProductoCod] = @TipoProductoCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000L5", "SELECT [ClientesCodigo] FROM [Clientes] WHERE [ClientesCodigo] = @ClientesCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000L6", "SELECT TM1.[VentasFecha], TM1.[VentasMes], TM1.[VentasAno], TM1.[VentasValor], TM1.[TipoProductoCod], TM1.[ClientesCodigo] FROM [Ventas] TM1 WHERE TM1.[VentasFecha] = @VentasFecha and TM1.[VentasMes] = @VentasMes and TM1.[VentasAno] = @VentasAno and TM1.[TipoProductoCod] = @TipoProductoCod ORDER BY TM1.[VentasFecha], TM1.[VentasMes], TM1.[VentasAno], TM1.[TipoProductoCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000L6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000L7", "SELECT [TipoProductoCod] FROM [TipoProducto] WHERE [TipoProductoCod] = @TipoProductoCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000L8", "SELECT [ClientesCodigo] FROM [Clientes] WHERE [ClientesCodigo] = @ClientesCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000L9", "SELECT [VentasFecha], [VentasMes], [VentasAno], [TipoProductoCod] FROM [Ventas] WHERE [VentasFecha] = @VentasFecha AND [VentasMes] = @VentasMes AND [VentasAno] = @VentasAno AND [TipoProductoCod] = @TipoProductoCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000L9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000L10", "SELECT TOP 1 [VentasFecha], [VentasMes], [VentasAno], [TipoProductoCod] FROM [Ventas] WHERE ( [VentasFecha] > @VentasFecha or [VentasFecha] = @VentasFecha and [VentasMes] > @VentasMes or [VentasMes] = @VentasMes and [VentasFecha] = @VentasFecha and [VentasAno] > @VentasAno or [VentasAno] = @VentasAno and [VentasMes] = @VentasMes and [VentasFecha] = @VentasFecha and [TipoProductoCod] > @TipoProductoCod) ORDER BY [VentasFecha], [VentasMes], [VentasAno], [TipoProductoCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000L10,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000L11", "SELECT TOP 1 [VentasFecha], [VentasMes], [VentasAno], [TipoProductoCod] FROM [Ventas] WHERE ( [VentasFecha] < @VentasFecha or [VentasFecha] = @VentasFecha and [VentasMes] < @VentasMes or [VentasMes] = @VentasMes and [VentasFecha] = @VentasFecha and [VentasAno] < @VentasAno or [VentasAno] = @VentasAno and [VentasMes] = @VentasMes and [VentasFecha] = @VentasFecha and [TipoProductoCod] < @TipoProductoCod) ORDER BY [VentasFecha] DESC, [VentasMes] DESC, [VentasAno] DESC, [TipoProductoCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000L11,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000L12", "INSERT INTO [Ventas]([VentasFecha], [VentasMes], [VentasAno], [VentasValor], [TipoProductoCod], [ClientesCodigo]) VALUES(@VentasFecha, @VentasMes, @VentasAno, @VentasValor, @TipoProductoCod, @ClientesCodigo)", GxErrorMask.GX_NOMASK,prmT000L12)
             ,new CursorDef("T000L13", "UPDATE [Ventas] SET [VentasValor]=@VentasValor, [ClientesCodigo]=@ClientesCodigo  WHERE [VentasFecha] = @VentasFecha AND [VentasMes] = @VentasMes AND [VentasAno] = @VentasAno AND [TipoProductoCod] = @TipoProductoCod", GxErrorMask.GX_NOMASK,prmT000L13)
             ,new CursorDef("T000L14", "DELETE FROM [Ventas]  WHERE [VentasFecha] = @VentasFecha AND [VentasMes] = @VentasMes AND [VentasAno] = @VentasAno AND [TipoProductoCod] = @TipoProductoCod", GxErrorMask.GX_NOMASK,prmT000L14)
             ,new CursorDef("T000L15", "SELECT [VentasFecha], [VentasMes], [VentasAno], [TipoProductoCod] FROM [Ventas] ORDER BY [VentasFecha], [VentasMes], [VentasAno], [TipoProductoCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000L15,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000L16", "SELECT [TipoProductoCod] FROM [TipoProducto] WHERE [TipoProductoCod] = @TipoProductoCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L16,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000L17", "SELECT [ClientesCodigo] FROM [Clientes] WHERE [ClientesCodigo] = @ClientesCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L17,1, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 8 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
             case 9 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
             case 13 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
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
