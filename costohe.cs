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
   public class costohe : GXDataArea
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
            Form.Meta.addItem("description", "COSTOHE", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCOSTOHEFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("IndicadroresPalmas", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public costohe( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("IndicadroresPalmas", true);
      }

      public costohe( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "COSTOHE", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_COSTOHE.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSTOHE.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSTOHE.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSTOHE.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSTOHE.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 4, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx0090.aspx"+"',["+"{Ctrl:gx.dom.el('"+"COSTOHEFECHA"+"'), id:'"+"COSTOHEFECHA"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"COSTOHEMES"+"'), id:'"+"COSTOHEMES"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"COSTOHEANO"+"'), id:'"+"COSTOHEANO"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"INDICADORESCODIGO"+"'), id:'"+"INDICADORESCODIGO"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"COD_AREA"+"'), id:'"+"COD_AREA"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_COSTOHE.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCOSTOHEFecha_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCOSTOHEFecha_Internalname, "COSTOHEFecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCOSTOHEFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCOSTOHEFecha_Internalname, context.localUtil.Format(A21COSTOHEFecha, "99/99/99"), context.localUtil.Format( A21COSTOHEFecha, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCOSTOHEFecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCOSTOHEFecha_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_COSTOHE.htm");
         GxWebStd.gx_bitmap( context, edtCOSTOHEFecha_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCOSTOHEFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_COSTOHE.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCOSTOHEMes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCOSTOHEMes_Internalname, "COSTOHEMes", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCOSTOHEMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A22COSTOHEMes), 4, 0, ",", "")), StringUtil.LTrim( ((edtCOSTOHEMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A22COSTOHEMes), "ZZZ9") : context.localUtil.Format( (decimal)(A22COSTOHEMes), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCOSTOHEMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCOSTOHEMes_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_COSTOHE.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCOSTOHEAno_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCOSTOHEAno_Internalname, "COSTOHEAno", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCOSTOHEAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A23COSTOHEAno), 4, 0, ",", "")), StringUtil.LTrim( ((edtCOSTOHEAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A23COSTOHEAno), "ZZZ9") : context.localUtil.Format( (decimal)(A23COSTOHEAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCOSTOHEAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCOSTOHEAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_COSTOHE.htm");
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
         GxWebStd.gx_single_line_edit( context, edtIndicadoresCodigo_Internalname, A4IndicadoresCodigo, StringUtil.RTrim( context.localUtil.Format( A4IndicadoresCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIndicadoresCodigo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIndicadoresCodigo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_COSTOHE.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_4_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_4_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_4_Internalname, sImgUrl, imgprompt_4_Link, "", "", context.GetTheme( ), imgprompt_4_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_COSTOHE.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCod_Area_Internalname, A5Cod_Area, StringUtil.RTrim( context.localUtil.Format( A5Cod_Area, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCod_Area_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCod_Area_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_COSTOHE.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_5_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_5_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_5_Internalname, sImgUrl, imgprompt_5_Link, "", "", context.GetTheme( ), imgprompt_5_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_COSTOHE.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCOSTOHEValor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCOSTOHEValor_Internalname, "COSTOHEValor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCOSTOHEValor_Internalname, StringUtil.LTrim( StringUtil.NToC( A131COSTOHEValor, 12, 2, ",", "")), StringUtil.LTrim( ((edtCOSTOHEValor_Enabled!=0) ? context.localUtil.Format( A131COSTOHEValor, "ZZZZZZZZ9.99") : context.localUtil.Format( A131COSTOHEValor, "ZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCOSTOHEValor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCOSTOHEValor_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_COSTOHE.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCOSTOHETotHoras_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCOSTOHETotHoras_Internalname, "Horas", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCOSTOHETotHoras_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A237COSTOHETotHoras), 6, 0, ",", "")), StringUtil.LTrim( ((edtCOSTOHETotHoras_Enabled!=0) ? context.localUtil.Format( (decimal)(A237COSTOHETotHoras), "ZZZZZ9") : context.localUtil.Format( (decimal)(A237COSTOHETotHoras), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCOSTOHETotHoras_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCOSTOHETotHoras_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_COSTOHE.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSTOHE.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSTOHE.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSTOHE.htm");
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
            Z21COSTOHEFecha = context.localUtil.CToD( cgiGet( "Z21COSTOHEFecha"), 0);
            Z22COSTOHEMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z22COSTOHEMes"), ",", "."), 18, MidpointRounding.ToEven));
            Z23COSTOHEAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z23COSTOHEAno"), ",", "."), 18, MidpointRounding.ToEven));
            Z4IndicadoresCodigo = cgiGet( "Z4IndicadoresCodigo");
            Z5Cod_Area = cgiGet( "Z5Cod_Area");
            Z131COSTOHEValor = context.localUtil.CToN( cgiGet( "Z131COSTOHEValor"), ",", ".");
            Z237COSTOHETotHoras = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z237COSTOHETotHoras"), ",", "."), 18, MidpointRounding.ToEven));
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( context.localUtil.VCDate( cgiGet( edtCOSTOHEFecha_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"COSTOHEFecha"}), 1, "COSTOHEFECHA");
               AnyError = 1;
               GX_FocusControl = edtCOSTOHEFecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A21COSTOHEFecha = DateTime.MinValue;
               AssignAttri("", false, "A21COSTOHEFecha", context.localUtil.Format(A21COSTOHEFecha, "99/99/99"));
            }
            else
            {
               A21COSTOHEFecha = context.localUtil.CToD( cgiGet( edtCOSTOHEFecha_Internalname), 2);
               AssignAttri("", false, "A21COSTOHEFecha", context.localUtil.Format(A21COSTOHEFecha, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCOSTOHEMes_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCOSTOHEMes_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COSTOHEMES");
               AnyError = 1;
               GX_FocusControl = edtCOSTOHEMes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A22COSTOHEMes = 0;
               AssignAttri("", false, "A22COSTOHEMes", StringUtil.LTrimStr( (decimal)(A22COSTOHEMes), 4, 0));
            }
            else
            {
               A22COSTOHEMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCOSTOHEMes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A22COSTOHEMes", StringUtil.LTrimStr( (decimal)(A22COSTOHEMes), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCOSTOHEAno_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCOSTOHEAno_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COSTOHEANO");
               AnyError = 1;
               GX_FocusControl = edtCOSTOHEAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A23COSTOHEAno = 0;
               AssignAttri("", false, "A23COSTOHEAno", StringUtil.LTrimStr( (decimal)(A23COSTOHEAno), 4, 0));
            }
            else
            {
               A23COSTOHEAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCOSTOHEAno_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A23COSTOHEAno", StringUtil.LTrimStr( (decimal)(A23COSTOHEAno), 4, 0));
            }
            A4IndicadoresCodigo = cgiGet( edtIndicadoresCodigo_Internalname);
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A5Cod_Area = cgiGet( edtCod_Area_Internalname);
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCOSTOHEValor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCOSTOHEValor_Internalname), ",", ".") > 999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COSTOHEVALOR");
               AnyError = 1;
               GX_FocusControl = edtCOSTOHEValor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A131COSTOHEValor = 0;
               AssignAttri("", false, "A131COSTOHEValor", StringUtil.LTrimStr( A131COSTOHEValor, 12, 2));
            }
            else
            {
               A131COSTOHEValor = context.localUtil.CToN( cgiGet( edtCOSTOHEValor_Internalname), ",", ".");
               AssignAttri("", false, "A131COSTOHEValor", StringUtil.LTrimStr( A131COSTOHEValor, 12, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCOSTOHETotHoras_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCOSTOHETotHoras_Internalname), ",", ".") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COSTOHETOTHORAS");
               AnyError = 1;
               GX_FocusControl = edtCOSTOHETotHoras_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A237COSTOHETotHoras = 0;
               AssignAttri("", false, "A237COSTOHETotHoras", StringUtil.LTrimStr( (decimal)(A237COSTOHETotHoras), 6, 0));
            }
            else
            {
               A237COSTOHETotHoras = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtCOSTOHETotHoras_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A237COSTOHETotHoras", StringUtil.LTrimStr( (decimal)(A237COSTOHETotHoras), 6, 0));
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
               A21COSTOHEFecha = context.localUtil.ParseDateParm( GetPar( "COSTOHEFecha"));
               AssignAttri("", false, "A21COSTOHEFecha", context.localUtil.Format(A21COSTOHEFecha, "99/99/99"));
               A22COSTOHEMes = (short)(Math.Round(NumberUtil.Val( GetPar( "COSTOHEMes"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A22COSTOHEMes", StringUtil.LTrimStr( (decimal)(A22COSTOHEMes), 4, 0));
               A23COSTOHEAno = (short)(Math.Round(NumberUtil.Val( GetPar( "COSTOHEAno"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A23COSTOHEAno", StringUtil.LTrimStr( (decimal)(A23COSTOHEAno), 4, 0));
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
               InitAll089( ) ;
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
         DisableAttributes089( ) ;
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

      protected void ResetCaption080( )
      {
      }

      protected void ZM089( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z131COSTOHEValor = T00083_A131COSTOHEValor[0];
               Z237COSTOHETotHoras = T00083_A237COSTOHETotHoras[0];
            }
            else
            {
               Z131COSTOHEValor = A131COSTOHEValor;
               Z237COSTOHETotHoras = A237COSTOHETotHoras;
            }
         }
         if ( GX_JID == -2 )
         {
            Z21COSTOHEFecha = A21COSTOHEFecha;
            Z22COSTOHEMes = A22COSTOHEMes;
            Z23COSTOHEAno = A23COSTOHEAno;
            Z131COSTOHEValor = A131COSTOHEValor;
            Z237COSTOHETotHoras = A237COSTOHETotHoras;
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

      protected void Load089( )
      {
         /* Using cursor T00086 */
         pr_default.execute(4, new Object[] {A21COSTOHEFecha, A22COSTOHEMes, A23COSTOHEAno, A4IndicadoresCodigo, A5Cod_Area});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound9 = 1;
            A131COSTOHEValor = T00086_A131COSTOHEValor[0];
            AssignAttri("", false, "A131COSTOHEValor", StringUtil.LTrimStr( A131COSTOHEValor, 12, 2));
            A237COSTOHETotHoras = T00086_A237COSTOHETotHoras[0];
            AssignAttri("", false, "A237COSTOHETotHoras", StringUtil.LTrimStr( (decimal)(A237COSTOHETotHoras), 6, 0));
            ZM089( -2) ;
         }
         pr_default.close(4);
         OnLoadActions089( ) ;
      }

      protected void OnLoadActions089( )
      {
      }

      protected void CheckExtendedTable089( )
      {
         nIsDirty_9 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A21COSTOHEFecha) || ( DateTimeUtil.ResetTime ( A21COSTOHEFecha ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo COSTOHEFecha fuera de rango", "OutOfRange", 1, "COSTOHEFECHA");
            AnyError = 1;
            GX_FocusControl = edtCOSTOHEFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00084 */
         pr_default.execute(2, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T00085 */
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

      protected void CloseExtendedTableCursors089( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( string A4IndicadoresCodigo )
      {
         /* Using cursor T00087 */
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
         /* Using cursor T00088 */
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

      protected void GetKey089( )
      {
         /* Using cursor T00089 */
         pr_default.execute(7, new Object[] {A21COSTOHEFecha, A22COSTOHEMes, A23COSTOHEAno, A4IndicadoresCodigo, A5Cod_Area});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound9 = 1;
         }
         else
         {
            RcdFound9 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00083 */
         pr_default.execute(1, new Object[] {A21COSTOHEFecha, A22COSTOHEMes, A23COSTOHEAno, A4IndicadoresCodigo, A5Cod_Area});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM089( 2) ;
            RcdFound9 = 1;
            A21COSTOHEFecha = T00083_A21COSTOHEFecha[0];
            AssignAttri("", false, "A21COSTOHEFecha", context.localUtil.Format(A21COSTOHEFecha, "99/99/99"));
            A22COSTOHEMes = T00083_A22COSTOHEMes[0];
            AssignAttri("", false, "A22COSTOHEMes", StringUtil.LTrimStr( (decimal)(A22COSTOHEMes), 4, 0));
            A23COSTOHEAno = T00083_A23COSTOHEAno[0];
            AssignAttri("", false, "A23COSTOHEAno", StringUtil.LTrimStr( (decimal)(A23COSTOHEAno), 4, 0));
            A131COSTOHEValor = T00083_A131COSTOHEValor[0];
            AssignAttri("", false, "A131COSTOHEValor", StringUtil.LTrimStr( A131COSTOHEValor, 12, 2));
            A237COSTOHETotHoras = T00083_A237COSTOHETotHoras[0];
            AssignAttri("", false, "A237COSTOHETotHoras", StringUtil.LTrimStr( (decimal)(A237COSTOHETotHoras), 6, 0));
            A4IndicadoresCodigo = T00083_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A5Cod_Area = T00083_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            Z21COSTOHEFecha = A21COSTOHEFecha;
            Z22COSTOHEMes = A22COSTOHEMes;
            Z23COSTOHEAno = A23COSTOHEAno;
            Z4IndicadoresCodigo = A4IndicadoresCodigo;
            Z5Cod_Area = A5Cod_Area;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load089( ) ;
            if ( AnyError == 1 )
            {
               RcdFound9 = 0;
               InitializeNonKey089( ) ;
            }
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound9 = 0;
            InitializeNonKey089( ) ;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey089( ) ;
         if ( RcdFound9 == 0 )
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
         RcdFound9 = 0;
         /* Using cursor T000810 */
         pr_default.execute(8, new Object[] {A21COSTOHEFecha, A22COSTOHEMes, A23COSTOHEAno, A4IndicadoresCodigo, A5Cod_Area});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( DateTimeUtil.ResetTime ( T000810_A21COSTOHEFecha[0] ) < DateTimeUtil.ResetTime ( A21COSTOHEFecha ) ) || ( DateTimeUtil.ResetTime ( T000810_A21COSTOHEFecha[0] ) == DateTimeUtil.ResetTime ( A21COSTOHEFecha ) ) && ( T000810_A22COSTOHEMes[0] < A22COSTOHEMes ) || ( T000810_A22COSTOHEMes[0] == A22COSTOHEMes ) && ( DateTimeUtil.ResetTime ( T000810_A21COSTOHEFecha[0] ) == DateTimeUtil.ResetTime ( A21COSTOHEFecha ) ) && ( T000810_A23COSTOHEAno[0] < A23COSTOHEAno ) || ( T000810_A23COSTOHEAno[0] == A23COSTOHEAno ) && ( T000810_A22COSTOHEMes[0] == A22COSTOHEMes ) && ( DateTimeUtil.ResetTime ( T000810_A21COSTOHEFecha[0] ) == DateTimeUtil.ResetTime ( A21COSTOHEFecha ) ) && ( StringUtil.StrCmp(T000810_A4IndicadoresCodigo[0], A4IndicadoresCodigo) < 0 ) || ( StringUtil.StrCmp(T000810_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000810_A23COSTOHEAno[0] == A23COSTOHEAno ) && ( T000810_A22COSTOHEMes[0] == A22COSTOHEMes ) && ( DateTimeUtil.ResetTime ( T000810_A21COSTOHEFecha[0] ) == DateTimeUtil.ResetTime ( A21COSTOHEFecha ) ) && ( StringUtil.StrCmp(T000810_A5Cod_Area[0], A5Cod_Area) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( DateTimeUtil.ResetTime ( T000810_A21COSTOHEFecha[0] ) > DateTimeUtil.ResetTime ( A21COSTOHEFecha ) ) || ( DateTimeUtil.ResetTime ( T000810_A21COSTOHEFecha[0] ) == DateTimeUtil.ResetTime ( A21COSTOHEFecha ) ) && ( T000810_A22COSTOHEMes[0] > A22COSTOHEMes ) || ( T000810_A22COSTOHEMes[0] == A22COSTOHEMes ) && ( DateTimeUtil.ResetTime ( T000810_A21COSTOHEFecha[0] ) == DateTimeUtil.ResetTime ( A21COSTOHEFecha ) ) && ( T000810_A23COSTOHEAno[0] > A23COSTOHEAno ) || ( T000810_A23COSTOHEAno[0] == A23COSTOHEAno ) && ( T000810_A22COSTOHEMes[0] == A22COSTOHEMes ) && ( DateTimeUtil.ResetTime ( T000810_A21COSTOHEFecha[0] ) == DateTimeUtil.ResetTime ( A21COSTOHEFecha ) ) && ( StringUtil.StrCmp(T000810_A4IndicadoresCodigo[0], A4IndicadoresCodigo) > 0 ) || ( StringUtil.StrCmp(T000810_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000810_A23COSTOHEAno[0] == A23COSTOHEAno ) && ( T000810_A22COSTOHEMes[0] == A22COSTOHEMes ) && ( DateTimeUtil.ResetTime ( T000810_A21COSTOHEFecha[0] ) == DateTimeUtil.ResetTime ( A21COSTOHEFecha ) ) && ( StringUtil.StrCmp(T000810_A5Cod_Area[0], A5Cod_Area) > 0 ) ) )
            {
               A21COSTOHEFecha = T000810_A21COSTOHEFecha[0];
               AssignAttri("", false, "A21COSTOHEFecha", context.localUtil.Format(A21COSTOHEFecha, "99/99/99"));
               A22COSTOHEMes = T000810_A22COSTOHEMes[0];
               AssignAttri("", false, "A22COSTOHEMes", StringUtil.LTrimStr( (decimal)(A22COSTOHEMes), 4, 0));
               A23COSTOHEAno = T000810_A23COSTOHEAno[0];
               AssignAttri("", false, "A23COSTOHEAno", StringUtil.LTrimStr( (decimal)(A23COSTOHEAno), 4, 0));
               A4IndicadoresCodigo = T000810_A4IndicadoresCodigo[0];
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               A5Cod_Area = T000810_A5Cod_Area[0];
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               RcdFound9 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound9 = 0;
         /* Using cursor T000811 */
         pr_default.execute(9, new Object[] {A21COSTOHEFecha, A22COSTOHEMes, A23COSTOHEAno, A4IndicadoresCodigo, A5Cod_Area});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( DateTimeUtil.ResetTime ( T000811_A21COSTOHEFecha[0] ) > DateTimeUtil.ResetTime ( A21COSTOHEFecha ) ) || ( DateTimeUtil.ResetTime ( T000811_A21COSTOHEFecha[0] ) == DateTimeUtil.ResetTime ( A21COSTOHEFecha ) ) && ( T000811_A22COSTOHEMes[0] > A22COSTOHEMes ) || ( T000811_A22COSTOHEMes[0] == A22COSTOHEMes ) && ( DateTimeUtil.ResetTime ( T000811_A21COSTOHEFecha[0] ) == DateTimeUtil.ResetTime ( A21COSTOHEFecha ) ) && ( T000811_A23COSTOHEAno[0] > A23COSTOHEAno ) || ( T000811_A23COSTOHEAno[0] == A23COSTOHEAno ) && ( T000811_A22COSTOHEMes[0] == A22COSTOHEMes ) && ( DateTimeUtil.ResetTime ( T000811_A21COSTOHEFecha[0] ) == DateTimeUtil.ResetTime ( A21COSTOHEFecha ) ) && ( StringUtil.StrCmp(T000811_A4IndicadoresCodigo[0], A4IndicadoresCodigo) > 0 ) || ( StringUtil.StrCmp(T000811_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000811_A23COSTOHEAno[0] == A23COSTOHEAno ) && ( T000811_A22COSTOHEMes[0] == A22COSTOHEMes ) && ( DateTimeUtil.ResetTime ( T000811_A21COSTOHEFecha[0] ) == DateTimeUtil.ResetTime ( A21COSTOHEFecha ) ) && ( StringUtil.StrCmp(T000811_A5Cod_Area[0], A5Cod_Area) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( DateTimeUtil.ResetTime ( T000811_A21COSTOHEFecha[0] ) < DateTimeUtil.ResetTime ( A21COSTOHEFecha ) ) || ( DateTimeUtil.ResetTime ( T000811_A21COSTOHEFecha[0] ) == DateTimeUtil.ResetTime ( A21COSTOHEFecha ) ) && ( T000811_A22COSTOHEMes[0] < A22COSTOHEMes ) || ( T000811_A22COSTOHEMes[0] == A22COSTOHEMes ) && ( DateTimeUtil.ResetTime ( T000811_A21COSTOHEFecha[0] ) == DateTimeUtil.ResetTime ( A21COSTOHEFecha ) ) && ( T000811_A23COSTOHEAno[0] < A23COSTOHEAno ) || ( T000811_A23COSTOHEAno[0] == A23COSTOHEAno ) && ( T000811_A22COSTOHEMes[0] == A22COSTOHEMes ) && ( DateTimeUtil.ResetTime ( T000811_A21COSTOHEFecha[0] ) == DateTimeUtil.ResetTime ( A21COSTOHEFecha ) ) && ( StringUtil.StrCmp(T000811_A4IndicadoresCodigo[0], A4IndicadoresCodigo) < 0 ) || ( StringUtil.StrCmp(T000811_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000811_A23COSTOHEAno[0] == A23COSTOHEAno ) && ( T000811_A22COSTOHEMes[0] == A22COSTOHEMes ) && ( DateTimeUtil.ResetTime ( T000811_A21COSTOHEFecha[0] ) == DateTimeUtil.ResetTime ( A21COSTOHEFecha ) ) && ( StringUtil.StrCmp(T000811_A5Cod_Area[0], A5Cod_Area) < 0 ) ) )
            {
               A21COSTOHEFecha = T000811_A21COSTOHEFecha[0];
               AssignAttri("", false, "A21COSTOHEFecha", context.localUtil.Format(A21COSTOHEFecha, "99/99/99"));
               A22COSTOHEMes = T000811_A22COSTOHEMes[0];
               AssignAttri("", false, "A22COSTOHEMes", StringUtil.LTrimStr( (decimal)(A22COSTOHEMes), 4, 0));
               A23COSTOHEAno = T000811_A23COSTOHEAno[0];
               AssignAttri("", false, "A23COSTOHEAno", StringUtil.LTrimStr( (decimal)(A23COSTOHEAno), 4, 0));
               A4IndicadoresCodigo = T000811_A4IndicadoresCodigo[0];
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               A5Cod_Area = T000811_A5Cod_Area[0];
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               RcdFound9 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey089( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCOSTOHEFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert089( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound9 == 1 )
            {
               if ( ( DateTimeUtil.ResetTime ( A21COSTOHEFecha ) != DateTimeUtil.ResetTime ( Z21COSTOHEFecha ) ) || ( A22COSTOHEMes != Z22COSTOHEMes ) || ( A23COSTOHEAno != Z23COSTOHEAno ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) )
               {
                  A21COSTOHEFecha = Z21COSTOHEFecha;
                  AssignAttri("", false, "A21COSTOHEFecha", context.localUtil.Format(A21COSTOHEFecha, "99/99/99"));
                  A22COSTOHEMes = Z22COSTOHEMes;
                  AssignAttri("", false, "A22COSTOHEMes", StringUtil.LTrimStr( (decimal)(A22COSTOHEMes), 4, 0));
                  A23COSTOHEAno = Z23COSTOHEAno;
                  AssignAttri("", false, "A23COSTOHEAno", StringUtil.LTrimStr( (decimal)(A23COSTOHEAno), 4, 0));
                  A4IndicadoresCodigo = Z4IndicadoresCodigo;
                  AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
                  A5Cod_Area = Z5Cod_Area;
                  AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "COSTOHEFECHA");
                  AnyError = 1;
                  GX_FocusControl = edtCOSTOHEFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCOSTOHEFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update089( ) ;
                  GX_FocusControl = edtCOSTOHEFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( DateTimeUtil.ResetTime ( A21COSTOHEFecha ) != DateTimeUtil.ResetTime ( Z21COSTOHEFecha ) ) || ( A22COSTOHEMes != Z22COSTOHEMes ) || ( A23COSTOHEAno != Z23COSTOHEAno ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtCOSTOHEFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert089( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "COSTOHEFECHA");
                     AnyError = 1;
                     GX_FocusControl = edtCOSTOHEFecha_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtCOSTOHEFecha_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert089( ) ;
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
         if ( ( DateTimeUtil.ResetTime ( A21COSTOHEFecha ) != DateTimeUtil.ResetTime ( Z21COSTOHEFecha ) ) || ( A22COSTOHEMes != Z22COSTOHEMes ) || ( A23COSTOHEAno != Z23COSTOHEAno ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) )
         {
            A21COSTOHEFecha = Z21COSTOHEFecha;
            AssignAttri("", false, "A21COSTOHEFecha", context.localUtil.Format(A21COSTOHEFecha, "99/99/99"));
            A22COSTOHEMes = Z22COSTOHEMes;
            AssignAttri("", false, "A22COSTOHEMes", StringUtil.LTrimStr( (decimal)(A22COSTOHEMes), 4, 0));
            A23COSTOHEAno = Z23COSTOHEAno;
            AssignAttri("", false, "A23COSTOHEAno", StringUtil.LTrimStr( (decimal)(A23COSTOHEAno), 4, 0));
            A4IndicadoresCodigo = Z4IndicadoresCodigo;
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A5Cod_Area = Z5Cod_Area;
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "COSTOHEFECHA");
            AnyError = 1;
            GX_FocusControl = edtCOSTOHEFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCOSTOHEFecha_Internalname;
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
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "COSTOHEFECHA");
            AnyError = 1;
            GX_FocusControl = edtCOSTOHEFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtCOSTOHEValor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart089( ) ;
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCOSTOHEValor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd089( ) ;
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
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCOSTOHEValor_Internalname;
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
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCOSTOHEValor_Internalname;
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
         ScanStart089( ) ;
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound9 != 0 )
            {
               ScanNext089( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCOSTOHEValor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd089( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency089( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00082 */
            pr_default.execute(0, new Object[] {A21COSTOHEFecha, A22COSTOHEMes, A23COSTOHEAno, A4IndicadoresCodigo, A5Cod_Area});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"COSTOHE"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z131COSTOHEValor != T00082_A131COSTOHEValor[0] ) || ( Z237COSTOHETotHoras != T00082_A237COSTOHETotHoras[0] ) )
            {
               if ( Z131COSTOHEValor != T00082_A131COSTOHEValor[0] )
               {
                  GXUtil.WriteLog("costohe:[seudo value changed for attri]"+"COSTOHEValor");
                  GXUtil.WriteLogRaw("Old: ",Z131COSTOHEValor);
                  GXUtil.WriteLogRaw("Current: ",T00082_A131COSTOHEValor[0]);
               }
               if ( Z237COSTOHETotHoras != T00082_A237COSTOHETotHoras[0] )
               {
                  GXUtil.WriteLog("costohe:[seudo value changed for attri]"+"COSTOHETotHoras");
                  GXUtil.WriteLogRaw("Old: ",Z237COSTOHETotHoras);
                  GXUtil.WriteLogRaw("Current: ",T00082_A237COSTOHETotHoras[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"COSTOHE"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert089( )
      {
         BeforeValidate089( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable089( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM089( 0) ;
            CheckOptimisticConcurrency089( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm089( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert089( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000812 */
                     pr_default.execute(10, new Object[] {A21COSTOHEFecha, A22COSTOHEMes, A23COSTOHEAno, A131COSTOHEValor, A237COSTOHETotHoras, A4IndicadoresCodigo, A5Cod_Area});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("COSTOHE");
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
                           ResetCaption080( ) ;
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
               Load089( ) ;
            }
            EndLevel089( ) ;
         }
         CloseExtendedTableCursors089( ) ;
      }

      protected void Update089( )
      {
         BeforeValidate089( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable089( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency089( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm089( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate089( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000813 */
                     pr_default.execute(11, new Object[] {A131COSTOHEValor, A237COSTOHETotHoras, A21COSTOHEFecha, A22COSTOHEMes, A23COSTOHEAno, A4IndicadoresCodigo, A5Cod_Area});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("COSTOHE");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"COSTOHE"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate089( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption080( ) ;
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
            EndLevel089( ) ;
         }
         CloseExtendedTableCursors089( ) ;
      }

      protected void DeferredUpdate089( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate089( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency089( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls089( ) ;
            AfterConfirm089( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete089( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000814 */
                  pr_default.execute(12, new Object[] {A21COSTOHEFecha, A22COSTOHEMes, A23COSTOHEAno, A4IndicadoresCodigo, A5Cod_Area});
                  pr_default.close(12);
                  pr_default.SmartCacheProvider.SetUpdated("COSTOHE");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound9 == 0 )
                        {
                           InitAll089( ) ;
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
                        ResetCaption080( ) ;
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
         sMode9 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel089( ) ;
         Gx_mode = sMode9;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls089( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel089( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete089( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("costohe",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues080( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("costohe",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart089( )
      {
         /* Using cursor T000815 */
         pr_default.execute(13);
         RcdFound9 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound9 = 1;
            A21COSTOHEFecha = T000815_A21COSTOHEFecha[0];
            AssignAttri("", false, "A21COSTOHEFecha", context.localUtil.Format(A21COSTOHEFecha, "99/99/99"));
            A22COSTOHEMes = T000815_A22COSTOHEMes[0];
            AssignAttri("", false, "A22COSTOHEMes", StringUtil.LTrimStr( (decimal)(A22COSTOHEMes), 4, 0));
            A23COSTOHEAno = T000815_A23COSTOHEAno[0];
            AssignAttri("", false, "A23COSTOHEAno", StringUtil.LTrimStr( (decimal)(A23COSTOHEAno), 4, 0));
            A4IndicadoresCodigo = T000815_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A5Cod_Area = T000815_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext089( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound9 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound9 = 1;
            A21COSTOHEFecha = T000815_A21COSTOHEFecha[0];
            AssignAttri("", false, "A21COSTOHEFecha", context.localUtil.Format(A21COSTOHEFecha, "99/99/99"));
            A22COSTOHEMes = T000815_A22COSTOHEMes[0];
            AssignAttri("", false, "A22COSTOHEMes", StringUtil.LTrimStr( (decimal)(A22COSTOHEMes), 4, 0));
            A23COSTOHEAno = T000815_A23COSTOHEAno[0];
            AssignAttri("", false, "A23COSTOHEAno", StringUtil.LTrimStr( (decimal)(A23COSTOHEAno), 4, 0));
            A4IndicadoresCodigo = T000815_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A5Cod_Area = T000815_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
         }
      }

      protected void ScanEnd089( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm089( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert089( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate089( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete089( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete089( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate089( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes089( )
      {
         edtCOSTOHEFecha_Enabled = 0;
         AssignProp("", false, edtCOSTOHEFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSTOHEFecha_Enabled), 5, 0), true);
         edtCOSTOHEMes_Enabled = 0;
         AssignProp("", false, edtCOSTOHEMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSTOHEMes_Enabled), 5, 0), true);
         edtCOSTOHEAno_Enabled = 0;
         AssignProp("", false, edtCOSTOHEAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSTOHEAno_Enabled), 5, 0), true);
         edtIndicadoresCodigo_Enabled = 0;
         AssignProp("", false, edtIndicadoresCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIndicadoresCodigo_Enabled), 5, 0), true);
         edtCod_Area_Enabled = 0;
         AssignProp("", false, edtCod_Area_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCod_Area_Enabled), 5, 0), true);
         edtCOSTOHEValor_Enabled = 0;
         AssignProp("", false, edtCOSTOHEValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSTOHEValor_Enabled), 5, 0), true);
         edtCOSTOHETotHoras_Enabled = 0;
         AssignProp("", false, edtCOSTOHETotHoras_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSTOHETotHoras_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes089( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues080( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("costohe.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z21COSTOHEFecha", context.localUtil.DToC( Z21COSTOHEFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z22COSTOHEMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z22COSTOHEMes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z23COSTOHEAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z23COSTOHEAno), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z4IndicadoresCodigo", Z4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "Z5Cod_Area", Z5Cod_Area);
         GxWebStd.gx_hidden_field( context, "Z131COSTOHEValor", StringUtil.LTrim( StringUtil.NToC( Z131COSTOHEValor, 12, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z237COSTOHETotHoras", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z237COSTOHETotHoras), 6, 0, ",", "")));
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
         return formatLink("costohe.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "COSTOHE" ;
      }

      public override string GetPgmdesc( )
      {
         return "COSTOHE" ;
      }

      protected void InitializeNonKey089( )
      {
         A131COSTOHEValor = 0;
         AssignAttri("", false, "A131COSTOHEValor", StringUtil.LTrimStr( A131COSTOHEValor, 12, 2));
         A237COSTOHETotHoras = 0;
         AssignAttri("", false, "A237COSTOHETotHoras", StringUtil.LTrimStr( (decimal)(A237COSTOHETotHoras), 6, 0));
         Z131COSTOHEValor = 0;
         Z237COSTOHETotHoras = 0;
      }

      protected void InitAll089( )
      {
         A21COSTOHEFecha = DateTime.MinValue;
         AssignAttri("", false, "A21COSTOHEFecha", context.localUtil.Format(A21COSTOHEFecha, "99/99/99"));
         A22COSTOHEMes = 0;
         AssignAttri("", false, "A22COSTOHEMes", StringUtil.LTrimStr( (decimal)(A22COSTOHEMes), 4, 0));
         A23COSTOHEAno = 0;
         AssignAttri("", false, "A23COSTOHEAno", StringUtil.LTrimStr( (decimal)(A23COSTOHEAno), 4, 0));
         A4IndicadoresCodigo = "";
         AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
         A5Cod_Area = "";
         AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
         InitializeNonKey089( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202472310206", true, true);
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
         context.AddJavascriptSource("costohe.js", "?202472310206", false, true);
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
         edtCOSTOHEFecha_Internalname = "COSTOHEFECHA";
         edtCOSTOHEMes_Internalname = "COSTOHEMES";
         edtCOSTOHEAno_Internalname = "COSTOHEANO";
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO";
         edtCod_Area_Internalname = "COD_AREA";
         edtCOSTOHEValor_Internalname = "COSTOHEVALOR";
         edtCOSTOHETotHoras_Internalname = "COSTOHETOTHORAS";
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
         Form.Caption = "COSTOHE";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCOSTOHETotHoras_Jsonclick = "";
         edtCOSTOHETotHoras_Enabled = 1;
         edtCOSTOHEValor_Jsonclick = "";
         edtCOSTOHEValor_Enabled = 1;
         imgprompt_5_Visible = 1;
         imgprompt_5_Link = "";
         edtCod_Area_Jsonclick = "";
         edtCod_Area_Enabled = 1;
         imgprompt_4_Visible = 1;
         imgprompt_4_Link = "";
         edtIndicadoresCodigo_Jsonclick = "";
         edtIndicadoresCodigo_Enabled = 1;
         edtCOSTOHEAno_Jsonclick = "";
         edtCOSTOHEAno_Enabled = 1;
         edtCOSTOHEMes_Jsonclick = "";
         edtCOSTOHEMes_Enabled = 1;
         edtCOSTOHEFecha_Jsonclick = "";
         edtCOSTOHEFecha_Enabled = 1;
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
         /* Using cursor T000816 */
         pr_default.execute(14, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(14);
         /* Using cursor T000817 */
         pr_default.execute(15, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(15);
         GX_FocusControl = edtCOSTOHEValor_Internalname;
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
         /* Using cursor T000816 */
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
         /* Using cursor T000817 */
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
         AssignAttri("", false, "A131COSTOHEValor", StringUtil.LTrim( StringUtil.NToC( A131COSTOHEValor, 12, 2, ".", "")));
         AssignAttri("", false, "A237COSTOHETotHoras", StringUtil.LTrim( StringUtil.NToC( (decimal)(A237COSTOHETotHoras), 6, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z21COSTOHEFecha", context.localUtil.Format(Z21COSTOHEFecha, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z22COSTOHEMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z22COSTOHEMes), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z23COSTOHEAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z23COSTOHEAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z4IndicadoresCodigo", Z4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "Z5Cod_Area", Z5Cod_Area);
         GxWebStd.gx_hidden_field( context, "Z131COSTOHEValor", StringUtil.LTrim( StringUtil.NToC( Z131COSTOHEValor, 12, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z237COSTOHETotHoras", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z237COSTOHETotHoras), 6, 0, ".", "")));
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
         setEventMetadata("VALID_COSTOHEFECHA","{handler:'Valid_Costohefecha',iparms:[]");
         setEventMetadata("VALID_COSTOHEFECHA",",oparms:[]}");
         setEventMetadata("VALID_COSTOHEMES","{handler:'Valid_Costohemes',iparms:[]");
         setEventMetadata("VALID_COSTOHEMES",",oparms:[]}");
         setEventMetadata("VALID_COSTOHEANO","{handler:'Valid_Costoheano',iparms:[]");
         setEventMetadata("VALID_COSTOHEANO",",oparms:[]}");
         setEventMetadata("VALID_INDICADORESCODIGO","{handler:'Valid_Indicadorescodigo',iparms:[{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:''}]");
         setEventMetadata("VALID_INDICADORESCODIGO",",oparms:[]}");
         setEventMetadata("VALID_COD_AREA","{handler:'Valid_Cod_area',iparms:[{av:'A21COSTOHEFecha',fld:'COSTOHEFECHA',pic:''},{av:'A22COSTOHEMes',fld:'COSTOHEMES',pic:'ZZZ9'},{av:'A23COSTOHEAno',fld:'COSTOHEANO',pic:'ZZZ9'},{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:''},{av:'A5Cod_Area',fld:'COD_AREA',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_COD_AREA",",oparms:[{av:'A131COSTOHEValor',fld:'COSTOHEVALOR',pic:'ZZZZZZZZ9.99'},{av:'A237COSTOHETotHoras',fld:'COSTOHETOTHORAS',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z21COSTOHEFecha'},{av:'Z22COSTOHEMes'},{av:'Z23COSTOHEAno'},{av:'Z4IndicadoresCodigo'},{av:'Z5Cod_Area'},{av:'Z131COSTOHEValor'},{av:'Z237COSTOHETotHoras'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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
         Z21COSTOHEFecha = DateTime.MinValue;
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
         A21COSTOHEFecha = DateTime.MinValue;
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
         T00086_A21COSTOHEFecha = new DateTime[] {DateTime.MinValue} ;
         T00086_A22COSTOHEMes = new short[1] ;
         T00086_A23COSTOHEAno = new short[1] ;
         T00086_A131COSTOHEValor = new decimal[1] ;
         T00086_A237COSTOHETotHoras = new int[1] ;
         T00086_A4IndicadoresCodigo = new string[] {""} ;
         T00086_A5Cod_Area = new string[] {""} ;
         T00084_A4IndicadoresCodigo = new string[] {""} ;
         T00085_A5Cod_Area = new string[] {""} ;
         T00087_A4IndicadoresCodigo = new string[] {""} ;
         T00088_A5Cod_Area = new string[] {""} ;
         T00089_A21COSTOHEFecha = new DateTime[] {DateTime.MinValue} ;
         T00089_A22COSTOHEMes = new short[1] ;
         T00089_A23COSTOHEAno = new short[1] ;
         T00089_A4IndicadoresCodigo = new string[] {""} ;
         T00089_A5Cod_Area = new string[] {""} ;
         T00083_A21COSTOHEFecha = new DateTime[] {DateTime.MinValue} ;
         T00083_A22COSTOHEMes = new short[1] ;
         T00083_A23COSTOHEAno = new short[1] ;
         T00083_A131COSTOHEValor = new decimal[1] ;
         T00083_A237COSTOHETotHoras = new int[1] ;
         T00083_A4IndicadoresCodigo = new string[] {""} ;
         T00083_A5Cod_Area = new string[] {""} ;
         sMode9 = "";
         T000810_A21COSTOHEFecha = new DateTime[] {DateTime.MinValue} ;
         T000810_A22COSTOHEMes = new short[1] ;
         T000810_A23COSTOHEAno = new short[1] ;
         T000810_A4IndicadoresCodigo = new string[] {""} ;
         T000810_A5Cod_Area = new string[] {""} ;
         T000811_A21COSTOHEFecha = new DateTime[] {DateTime.MinValue} ;
         T000811_A22COSTOHEMes = new short[1] ;
         T000811_A23COSTOHEAno = new short[1] ;
         T000811_A4IndicadoresCodigo = new string[] {""} ;
         T000811_A5Cod_Area = new string[] {""} ;
         T00082_A21COSTOHEFecha = new DateTime[] {DateTime.MinValue} ;
         T00082_A22COSTOHEMes = new short[1] ;
         T00082_A23COSTOHEAno = new short[1] ;
         T00082_A131COSTOHEValor = new decimal[1] ;
         T00082_A237COSTOHETotHoras = new int[1] ;
         T00082_A4IndicadoresCodigo = new string[] {""} ;
         T00082_A5Cod_Area = new string[] {""} ;
         T000815_A21COSTOHEFecha = new DateTime[] {DateTime.MinValue} ;
         T000815_A22COSTOHEMes = new short[1] ;
         T000815_A23COSTOHEAno = new short[1] ;
         T000815_A4IndicadoresCodigo = new string[] {""} ;
         T000815_A5Cod_Area = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T000816_A4IndicadoresCodigo = new string[] {""} ;
         T000817_A5Cod_Area = new string[] {""} ;
         ZZ21COSTOHEFecha = DateTime.MinValue;
         ZZ4IndicadoresCodigo = "";
         ZZ5Cod_Area = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.costohe__default(),
            new Object[][] {
                new Object[] {
               T00082_A21COSTOHEFecha, T00082_A22COSTOHEMes, T00082_A23COSTOHEAno, T00082_A131COSTOHEValor, T00082_A237COSTOHETotHoras, T00082_A4IndicadoresCodigo, T00082_A5Cod_Area
               }
               , new Object[] {
               T00083_A21COSTOHEFecha, T00083_A22COSTOHEMes, T00083_A23COSTOHEAno, T00083_A131COSTOHEValor, T00083_A237COSTOHETotHoras, T00083_A4IndicadoresCodigo, T00083_A5Cod_Area
               }
               , new Object[] {
               T00084_A4IndicadoresCodigo
               }
               , new Object[] {
               T00085_A5Cod_Area
               }
               , new Object[] {
               T00086_A21COSTOHEFecha, T00086_A22COSTOHEMes, T00086_A23COSTOHEAno, T00086_A131COSTOHEValor, T00086_A237COSTOHETotHoras, T00086_A4IndicadoresCodigo, T00086_A5Cod_Area
               }
               , new Object[] {
               T00087_A4IndicadoresCodigo
               }
               , new Object[] {
               T00088_A5Cod_Area
               }
               , new Object[] {
               T00089_A21COSTOHEFecha, T00089_A22COSTOHEMes, T00089_A23COSTOHEAno, T00089_A4IndicadoresCodigo, T00089_A5Cod_Area
               }
               , new Object[] {
               T000810_A21COSTOHEFecha, T000810_A22COSTOHEMes, T000810_A23COSTOHEAno, T000810_A4IndicadoresCodigo, T000810_A5Cod_Area
               }
               , new Object[] {
               T000811_A21COSTOHEFecha, T000811_A22COSTOHEMes, T000811_A23COSTOHEAno, T000811_A4IndicadoresCodigo, T000811_A5Cod_Area
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000815_A21COSTOHEFecha, T000815_A22COSTOHEMes, T000815_A23COSTOHEAno, T000815_A4IndicadoresCodigo, T000815_A5Cod_Area
               }
               , new Object[] {
               T000816_A4IndicadoresCodigo
               }
               , new Object[] {
               T000817_A5Cod_Area
               }
            }
         );
      }

      private short Z22COSTOHEMes ;
      private short Z23COSTOHEAno ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A22COSTOHEMes ;
      private short A23COSTOHEAno ;
      private short GX_JID ;
      private short RcdFound9 ;
      private short nIsDirty_9 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ22COSTOHEMes ;
      private short ZZ23COSTOHEAno ;
      private int Z237COSTOHETotHoras ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtCOSTOHEFecha_Enabled ;
      private int edtCOSTOHEMes_Enabled ;
      private int edtCOSTOHEAno_Enabled ;
      private int edtIndicadoresCodigo_Enabled ;
      private int imgprompt_4_Visible ;
      private int edtCod_Area_Enabled ;
      private int imgprompt_5_Visible ;
      private int edtCOSTOHEValor_Enabled ;
      private int A237COSTOHETotHoras ;
      private int edtCOSTOHETotHoras_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ237COSTOHETotHoras ;
      private decimal Z131COSTOHEValor ;
      private decimal A131COSTOHEValor ;
      private decimal ZZ131COSTOHEValor ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCOSTOHEFecha_Internalname ;
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
      private string edtCOSTOHEFecha_Jsonclick ;
      private string edtCOSTOHEMes_Internalname ;
      private string edtCOSTOHEMes_Jsonclick ;
      private string edtCOSTOHEAno_Internalname ;
      private string edtCOSTOHEAno_Jsonclick ;
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
      private string edtCOSTOHEValor_Internalname ;
      private string edtCOSTOHEValor_Jsonclick ;
      private string edtCOSTOHETotHoras_Internalname ;
      private string edtCOSTOHETotHoras_Jsonclick ;
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
      private string sMode9 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z21COSTOHEFecha ;
      private DateTime A21COSTOHEFecha ;
      private DateTime ZZ21COSTOHEFecha ;
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
      private DateTime[] T00086_A21COSTOHEFecha ;
      private short[] T00086_A22COSTOHEMes ;
      private short[] T00086_A23COSTOHEAno ;
      private decimal[] T00086_A131COSTOHEValor ;
      private int[] T00086_A237COSTOHETotHoras ;
      private string[] T00086_A4IndicadoresCodigo ;
      private string[] T00086_A5Cod_Area ;
      private string[] T00084_A4IndicadoresCodigo ;
      private string[] T00085_A5Cod_Area ;
      private string[] T00087_A4IndicadoresCodigo ;
      private string[] T00088_A5Cod_Area ;
      private DateTime[] T00089_A21COSTOHEFecha ;
      private short[] T00089_A22COSTOHEMes ;
      private short[] T00089_A23COSTOHEAno ;
      private string[] T00089_A4IndicadoresCodigo ;
      private string[] T00089_A5Cod_Area ;
      private DateTime[] T00083_A21COSTOHEFecha ;
      private short[] T00083_A22COSTOHEMes ;
      private short[] T00083_A23COSTOHEAno ;
      private decimal[] T00083_A131COSTOHEValor ;
      private int[] T00083_A237COSTOHETotHoras ;
      private string[] T00083_A4IndicadoresCodigo ;
      private string[] T00083_A5Cod_Area ;
      private DateTime[] T000810_A21COSTOHEFecha ;
      private short[] T000810_A22COSTOHEMes ;
      private short[] T000810_A23COSTOHEAno ;
      private string[] T000810_A4IndicadoresCodigo ;
      private string[] T000810_A5Cod_Area ;
      private DateTime[] T000811_A21COSTOHEFecha ;
      private short[] T000811_A22COSTOHEMes ;
      private short[] T000811_A23COSTOHEAno ;
      private string[] T000811_A4IndicadoresCodigo ;
      private string[] T000811_A5Cod_Area ;
      private DateTime[] T00082_A21COSTOHEFecha ;
      private short[] T00082_A22COSTOHEMes ;
      private short[] T00082_A23COSTOHEAno ;
      private decimal[] T00082_A131COSTOHEValor ;
      private int[] T00082_A237COSTOHETotHoras ;
      private string[] T00082_A4IndicadoresCodigo ;
      private string[] T00082_A5Cod_Area ;
      private DateTime[] T000815_A21COSTOHEFecha ;
      private short[] T000815_A22COSTOHEMes ;
      private short[] T000815_A23COSTOHEAno ;
      private string[] T000815_A4IndicadoresCodigo ;
      private string[] T000815_A5Cod_Area ;
      private string[] T000816_A4IndicadoresCodigo ;
      private string[] T000817_A5Cod_Area ;
      private GXWebForm Form ;
   }

   public class costohe__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT00086;
          prmT00086 = new Object[] {
          new ParDef("@COSTOHEFecha",GXType.Date,8,0) ,
          new ParDef("@COSTOHEMes",GXType.Int16,4,0) ,
          new ParDef("@COSTOHEAno",GXType.Int16,4,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT00084;
          prmT00084 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT00085;
          prmT00085 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT00087;
          prmT00087 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT00088;
          prmT00088 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT00089;
          prmT00089 = new Object[] {
          new ParDef("@COSTOHEFecha",GXType.Date,8,0) ,
          new ParDef("@COSTOHEMes",GXType.Int16,4,0) ,
          new ParDef("@COSTOHEAno",GXType.Int16,4,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT00083;
          prmT00083 = new Object[] {
          new ParDef("@COSTOHEFecha",GXType.Date,8,0) ,
          new ParDef("@COSTOHEMes",GXType.Int16,4,0) ,
          new ParDef("@COSTOHEAno",GXType.Int16,4,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000810;
          prmT000810 = new Object[] {
          new ParDef("@COSTOHEFecha",GXType.Date,8,0) ,
          new ParDef("@COSTOHEMes",GXType.Int16,4,0) ,
          new ParDef("@COSTOHEAno",GXType.Int16,4,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000811;
          prmT000811 = new Object[] {
          new ParDef("@COSTOHEFecha",GXType.Date,8,0) ,
          new ParDef("@COSTOHEMes",GXType.Int16,4,0) ,
          new ParDef("@COSTOHEAno",GXType.Int16,4,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT00082;
          prmT00082 = new Object[] {
          new ParDef("@COSTOHEFecha",GXType.Date,8,0) ,
          new ParDef("@COSTOHEMes",GXType.Int16,4,0) ,
          new ParDef("@COSTOHEAno",GXType.Int16,4,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000812;
          prmT000812 = new Object[] {
          new ParDef("@COSTOHEFecha",GXType.Date,8,0) ,
          new ParDef("@COSTOHEMes",GXType.Int16,4,0) ,
          new ParDef("@COSTOHEAno",GXType.Int16,4,0) ,
          new ParDef("@COSTOHEValor",GXType.Decimal,12,2) ,
          new ParDef("@COSTOHETotHoras",GXType.Int32,6,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000813;
          prmT000813 = new Object[] {
          new ParDef("@COSTOHEValor",GXType.Decimal,12,2) ,
          new ParDef("@COSTOHETotHoras",GXType.Int32,6,0) ,
          new ParDef("@COSTOHEFecha",GXType.Date,8,0) ,
          new ParDef("@COSTOHEMes",GXType.Int16,4,0) ,
          new ParDef("@COSTOHEAno",GXType.Int16,4,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000814;
          prmT000814 = new Object[] {
          new ParDef("@COSTOHEFecha",GXType.Date,8,0) ,
          new ParDef("@COSTOHEMes",GXType.Int16,4,0) ,
          new ParDef("@COSTOHEAno",GXType.Int16,4,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000815;
          prmT000815 = new Object[] {
          };
          Object[] prmT000816;
          prmT000816 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000817;
          prmT000817 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00082", "SELECT [COSTOHEFecha], [COSTOHEMes], [COSTOHEAno], [COSTOHEValor], [COSTOHETotHoras], [IndicadoresCodigo], [Cod_Area] FROM [COSTOHE] WITH (UPDLOCK) WHERE [COSTOHEFecha] = @COSTOHEFecha AND [COSTOHEMes] = @COSTOHEMes AND [COSTOHEAno] = @COSTOHEAno AND [IndicadoresCodigo] = @IndicadoresCodigo AND [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT00082,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00083", "SELECT [COSTOHEFecha], [COSTOHEMes], [COSTOHEAno], [COSTOHEValor], [COSTOHETotHoras], [IndicadoresCodigo], [Cod_Area] FROM [COSTOHE] WHERE [COSTOHEFecha] = @COSTOHEFecha AND [COSTOHEMes] = @COSTOHEMes AND [COSTOHEAno] = @COSTOHEAno AND [IndicadoresCodigo] = @IndicadoresCodigo AND [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT00083,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00084", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT00084,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00085", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT00085,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00086", "SELECT TM1.[COSTOHEFecha], TM1.[COSTOHEMes], TM1.[COSTOHEAno], TM1.[COSTOHEValor], TM1.[COSTOHETotHoras], TM1.[IndicadoresCodigo], TM1.[Cod_Area] FROM [COSTOHE] TM1 WHERE TM1.[COSTOHEFecha] = @COSTOHEFecha and TM1.[COSTOHEMes] = @COSTOHEMes and TM1.[COSTOHEAno] = @COSTOHEAno and TM1.[IndicadoresCodigo] = @IndicadoresCodigo and TM1.[Cod_Area] = @Cod_Area ORDER BY TM1.[COSTOHEFecha], TM1.[COSTOHEMes], TM1.[COSTOHEAno], TM1.[IndicadoresCodigo], TM1.[Cod_Area]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00086,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00087", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT00087,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00088", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT00088,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00089", "SELECT [COSTOHEFecha], [COSTOHEMes], [COSTOHEAno], [IndicadoresCodigo], [Cod_Area] FROM [COSTOHE] WHERE [COSTOHEFecha] = @COSTOHEFecha AND [COSTOHEMes] = @COSTOHEMes AND [COSTOHEAno] = @COSTOHEAno AND [IndicadoresCodigo] = @IndicadoresCodigo AND [Cod_Area] = @Cod_Area  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00089,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000810", "SELECT TOP 1 [COSTOHEFecha], [COSTOHEMes], [COSTOHEAno], [IndicadoresCodigo], [Cod_Area] FROM [COSTOHE] WHERE ( [COSTOHEFecha] > @COSTOHEFecha or [COSTOHEFecha] = @COSTOHEFecha and [COSTOHEMes] > @COSTOHEMes or [COSTOHEMes] = @COSTOHEMes and [COSTOHEFecha] = @COSTOHEFecha and [COSTOHEAno] > @COSTOHEAno or [COSTOHEAno] = @COSTOHEAno and [COSTOHEMes] = @COSTOHEMes and [COSTOHEFecha] = @COSTOHEFecha and [IndicadoresCodigo] > @IndicadoresCodigo or [IndicadoresCodigo] = @IndicadoresCodigo and [COSTOHEAno] = @COSTOHEAno and [COSTOHEMes] = @COSTOHEMes and [COSTOHEFecha] = @COSTOHEFecha and [Cod_Area] > @Cod_Area) ORDER BY [COSTOHEFecha], [COSTOHEMes], [COSTOHEAno], [IndicadoresCodigo], [Cod_Area]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000810,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000811", "SELECT TOP 1 [COSTOHEFecha], [COSTOHEMes], [COSTOHEAno], [IndicadoresCodigo], [Cod_Area] FROM [COSTOHE] WHERE ( [COSTOHEFecha] < @COSTOHEFecha or [COSTOHEFecha] = @COSTOHEFecha and [COSTOHEMes] < @COSTOHEMes or [COSTOHEMes] = @COSTOHEMes and [COSTOHEFecha] = @COSTOHEFecha and [COSTOHEAno] < @COSTOHEAno or [COSTOHEAno] = @COSTOHEAno and [COSTOHEMes] = @COSTOHEMes and [COSTOHEFecha] = @COSTOHEFecha and [IndicadoresCodigo] < @IndicadoresCodigo or [IndicadoresCodigo] = @IndicadoresCodigo and [COSTOHEAno] = @COSTOHEAno and [COSTOHEMes] = @COSTOHEMes and [COSTOHEFecha] = @COSTOHEFecha and [Cod_Area] < @Cod_Area) ORDER BY [COSTOHEFecha] DESC, [COSTOHEMes] DESC, [COSTOHEAno] DESC, [IndicadoresCodigo] DESC, [Cod_Area] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000811,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000812", "INSERT INTO [COSTOHE]([COSTOHEFecha], [COSTOHEMes], [COSTOHEAno], [COSTOHEValor], [COSTOHETotHoras], [IndicadoresCodigo], [Cod_Area]) VALUES(@COSTOHEFecha, @COSTOHEMes, @COSTOHEAno, @COSTOHEValor, @COSTOHETotHoras, @IndicadoresCodigo, @Cod_Area)", GxErrorMask.GX_NOMASK,prmT000812)
             ,new CursorDef("T000813", "UPDATE [COSTOHE] SET [COSTOHEValor]=@COSTOHEValor, [COSTOHETotHoras]=@COSTOHETotHoras  WHERE [COSTOHEFecha] = @COSTOHEFecha AND [COSTOHEMes] = @COSTOHEMes AND [COSTOHEAno] = @COSTOHEAno AND [IndicadoresCodigo] = @IndicadoresCodigo AND [Cod_Area] = @Cod_Area", GxErrorMask.GX_NOMASK,prmT000813)
             ,new CursorDef("T000814", "DELETE FROM [COSTOHE]  WHERE [COSTOHEFecha] = @COSTOHEFecha AND [COSTOHEMes] = @COSTOHEMes AND [COSTOHEAno] = @COSTOHEAno AND [IndicadoresCodigo] = @IndicadoresCodigo AND [Cod_Area] = @Cod_Area", GxErrorMask.GX_NOMASK,prmT000814)
             ,new CursorDef("T000815", "SELECT [COSTOHEFecha], [COSTOHEMes], [COSTOHEAno], [IndicadoresCodigo], [Cod_Area] FROM [COSTOHE] ORDER BY [COSTOHEFecha], [COSTOHEMes], [COSTOHEAno], [IndicadoresCodigo], [Cod_Area]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000815,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000816", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000816,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000817", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000817,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                return;
             case 1 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
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
