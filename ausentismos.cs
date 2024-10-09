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
   public class ausentismos : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A4IndicadoresCodigo = GetPar( "IndicadoresCodigo");
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A4IndicadoresCodigo) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A5Cod_Area = GetPar( "Cod_Area");
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A5Cod_Area) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_9") == 0 )
         {
            A11TipoAusen_Codigo = GetPar( "TipoAusen_Codigo");
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_9( A11TipoAusen_Codigo) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridausentismos_area") == 0 )
         {
            gxnrGridausentismos_area_newrow_invoke( ) ;
            return  ;
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
            Form.Meta.addItem("description", "Ausentismos", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtAusen_Fecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("IndicadroresPalmas", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridausentismos_area_newrow_invoke( )
      {
         nRC_GXsfl_83 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_83"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_83_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_83_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_83_idx = GetPar( "sGXsfl_83_idx");
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridausentismos_area_newrow( ) ;
         /* End function gxnrGridausentismos_area_newrow_invoke */
      }

      public ausentismos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("IndicadroresPalmas", true);
      }

      public ausentismos( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Ausentismos", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Ausentismos.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Ausentismos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Ausentismos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Ausentismos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Ausentismos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 4, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx0050.aspx"+"',["+"{Ctrl:gx.dom.el('"+"AUSEN_FECHA"+"'), id:'"+"AUSEN_FECHA"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"AUSEN_MES"+"'), id:'"+"AUSEN_MES"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"AUSEN_ANO"+"'), id:'"+"AUSEN_ANO"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"INDICADORESCODIGO"+"'), id:'"+"INDICADORESCODIGO"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"COD_AREA"+"'), id:'"+"COD_AREA"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_Ausentismos.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAusen_Fecha_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAusen_Fecha_Internalname, "Ausen_Fecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtAusen_Fecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtAusen_Fecha_Internalname, context.localUtil.Format(A1Ausen_Fecha, "99/99/99"), context.localUtil.Format( A1Ausen_Fecha, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAusen_Fecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAusen_Fecha_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Ausentismos.htm");
         GxWebStd.gx_bitmap( context, edtAusen_Fecha_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtAusen_Fecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Ausentismos.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAusen_Mes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAusen_Mes_Internalname, "Ausen_Mes", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAusen_Mes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2Ausen_Mes), 4, 0, ",", "")), StringUtil.LTrim( ((edtAusen_Mes_Enabled!=0) ? context.localUtil.Format( (decimal)(A2Ausen_Mes), "ZZZ9") : context.localUtil.Format( (decimal)(A2Ausen_Mes), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAusen_Mes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAusen_Mes_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Ausentismos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAusen_Ano_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAusen_Ano_Internalname, "Ausen_Ano", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAusen_Ano_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A3Ausen_Ano), 4, 0, ",", "")), StringUtil.LTrim( ((edtAusen_Ano_Enabled!=0) ? context.localUtil.Format( (decimal)(A3Ausen_Ano), "ZZZ9") : context.localUtil.Format( (decimal)(A3Ausen_Ano), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAusen_Ano_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAusen_Ano_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Ausentismos.htm");
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
         GxWebStd.gx_single_line_edit( context, edtIndicadoresCodigo_Internalname, A4IndicadoresCodigo, StringUtil.RTrim( context.localUtil.Format( A4IndicadoresCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIndicadoresCodigo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIndicadoresCodigo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Ausentismos.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_4_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_4_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_4_Internalname, sImgUrl, imgprompt_4_Link, "", "", context.GetTheme( ), imgprompt_4_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Ausentismos.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCod_Area_Internalname, A5Cod_Area, StringUtil.RTrim( context.localUtil.Format( A5Cod_Area, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCod_Area_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCod_Area_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Ausentismos.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_5_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_5_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_5_Internalname, sImgUrl, imgprompt_5_Link, "", "", context.GetTheme( ), imgprompt_5_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Ausentismos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAusen_Valor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAusen_Valor_Internalname, "Ausen_Valor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAusen_Valor_Internalname, StringUtil.LTrim( StringUtil.NToC( A6Ausen_Valor, 15, 2, ",", "")), StringUtil.LTrim( ((edtAusen_Valor_Enabled!=0) ? context.localUtil.Format( A6Ausen_Valor, "ZZZZZZZZZZZ9.99") : context.localUtil.Format( A6Ausen_Valor, "ZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAusen_Valor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAusen_Valor_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Ausentismos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAusentismosUser_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAusentismosUser_Internalname, "User", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAusentismosUser_Internalname, A7AusentismosUser, StringUtil.RTrim( context.localUtil.Format( A7AusentismosUser, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAusentismosUser_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAusentismosUser_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Ausentismos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAusentismosReg_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAusentismosReg_Internalname, "Reg", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtAusentismosReg_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtAusentismosReg_Internalname, context.localUtil.Format(A8AusentismosReg, "99/99/99"), context.localUtil.Format( A8AusentismosReg, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAusentismosReg_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAusentismosReg_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Ausentismos.htm");
         GxWebStd.gx_bitmap( context, edtAusentismosReg_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtAusentismosReg_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Ausentismos.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAusentismosHor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAusentismosHor_Internalname, "Hor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAusentismosHor_Internalname, A9AusentismosHor, StringUtil.RTrim( context.localUtil.Format( A9AusentismosHor, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAusentismosHor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAusentismosHor_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Ausentismos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divAreatable_Internalname, 1, 0, "px", 0, "px", "form__table-level", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitlearea_Internalname, "Area", "", "", lblTitlearea_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-04", 0, "", 1, 1, 0, 0, "HLP_Ausentismos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         gxdraw_Gridausentismos_area( ) ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Ausentismos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Ausentismos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Ausentismos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "Right", "Middle", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void gxdraw_Gridausentismos_area( )
      {
         /*  Grid Control  */
         StartGridControl83( ) ;
         nGXsfl_83_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount6 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_6 = 1;
               ScanStart016( ) ;
               while ( RcdFound6 != 0 )
               {
                  init_level_properties6( ) ;
                  getByPrimaryKey016( ) ;
                  AddRow016( ) ;
                  ScanNext016( ) ;
               }
               ScanEnd016( ) ;
               nBlankRcdCount6 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal016( ) ;
            standaloneModal016( ) ;
            sMode6 = Gx_mode;
            while ( nGXsfl_83_idx < nRC_GXsfl_83 )
            {
               bGXsfl_83_Refreshing = true;
               ReadRow016( ) ;
               edtAusenArea_Fecha_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "AUSENAREA_FECHA_"+sGXsfl_83_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtAusenArea_Fecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAusenArea_Fecha_Enabled), 5, 0), !bGXsfl_83_Refreshing);
               edtTipoAusen_Codigo_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "TIPOAUSEN_CODIGO_"+sGXsfl_83_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtTipoAusen_Codigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipoAusen_Codigo_Enabled), 5, 0), !bGXsfl_83_Refreshing);
               edtAusenAreaValor_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "AUSENAREAVALOR_"+sGXsfl_83_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtAusenAreaValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAusenAreaValor_Enabled), 5, 0), !bGXsfl_83_Refreshing);
               edtAusentismosAreaUser_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "AUSENTISMOSAREAUSER_"+sGXsfl_83_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtAusentismosAreaUser_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAusentismosAreaUser_Enabled), 5, 0), !bGXsfl_83_Refreshing);
               edtAusentismosAreaReg_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "AUSENTISMOSAREAREG_"+sGXsfl_83_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtAusentismosAreaReg_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAusentismosAreaReg_Enabled), 5, 0), !bGXsfl_83_Refreshing);
               edtAusentismosAreaHor_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "AUSENTISMOSAREAHOR_"+sGXsfl_83_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtAusentismosAreaHor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAusentismosAreaHor_Enabled), 5, 0), !bGXsfl_83_Refreshing);
               imgprompt_4_Link = cgiGet( "PROMPT_11_"+sGXsfl_83_idx+"Link");
               if ( ( nRcdExists_6 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal016( ) ;
               }
               SendRow016( ) ;
               bGXsfl_83_Refreshing = false;
            }
            Gx_mode = sMode6;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount6 = 5;
            nRcdExists_6 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart016( ) ;
               while ( RcdFound6 != 0 )
               {
                  sGXsfl_83_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_836( ) ;
                  init_level_properties6( ) ;
                  standaloneNotModal016( ) ;
                  getByPrimaryKey016( ) ;
                  standaloneModal016( ) ;
                  AddRow016( ) ;
                  ScanNext016( ) ;
               }
               ScanEnd016( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         sMode6 = Gx_mode;
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sGXsfl_83_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_idx+1), 4, 0), 4, "0");
         SubsflControlProps_836( ) ;
         InitAll016( ) ;
         init_level_properties6( ) ;
         nRcdExists_6 = 0;
         nIsMod_6 = 0;
         nRcdDeleted_6 = 0;
         nBlankRcdCount6 = (short)(nBlankRcdUsr6+nBlankRcdCount6);
         fRowAdded = 0;
         while ( nBlankRcdCount6 > 0 )
         {
            standaloneNotModal016( ) ;
            standaloneModal016( ) ;
            AddRow016( ) ;
            if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
            {
               fRowAdded = 1;
               GX_FocusControl = edtAusenArea_Fecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nBlankRcdCount6 = (short)(nBlankRcdCount6-1);
         }
         Gx_mode = sMode6;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridausentismos_areaContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridausentismos_area", Gridausentismos_areaContainer, subGridausentismos_area_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridausentismos_areaContainerData", Gridausentismos_areaContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridausentismos_areaContainerData"+"V", Gridausentismos_areaContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridausentismos_areaContainerData"+"V"+"\" value='"+Gridausentismos_areaContainer.GridValuesHidden()+"'/>") ;
         }
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
            Z1Ausen_Fecha = context.localUtil.CToD( cgiGet( "Z1Ausen_Fecha"), 0);
            Z2Ausen_Mes = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z2Ausen_Mes"), ",", "."), 18, MidpointRounding.ToEven));
            Z3Ausen_Ano = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z3Ausen_Ano"), ",", "."), 18, MidpointRounding.ToEven));
            Z4IndicadoresCodigo = cgiGet( "Z4IndicadoresCodigo");
            Z5Cod_Area = cgiGet( "Z5Cod_Area");
            Z6Ausen_Valor = context.localUtil.CToN( cgiGet( "Z6Ausen_Valor"), ",", ".");
            Z7AusentismosUser = cgiGet( "Z7AusentismosUser");
            Z8AusentismosReg = context.localUtil.CToD( cgiGet( "Z8AusentismosReg"), 0);
            Z9AusentismosHor = cgiGet( "Z9AusentismosHor");
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            nRC_GXsfl_83 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_83"), ",", "."), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( context.localUtil.VCDate( cgiGet( edtAusen_Fecha_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Ausen_Fecha"}), 1, "AUSEN_FECHA");
               AnyError = 1;
               GX_FocusControl = edtAusen_Fecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1Ausen_Fecha = DateTime.MinValue;
               AssignAttri("", false, "A1Ausen_Fecha", context.localUtil.Format(A1Ausen_Fecha, "99/99/99"));
            }
            else
            {
               A1Ausen_Fecha = context.localUtil.CToD( cgiGet( edtAusen_Fecha_Internalname), 2);
               AssignAttri("", false, "A1Ausen_Fecha", context.localUtil.Format(A1Ausen_Fecha, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtAusen_Mes_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAusen_Mes_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "AUSEN_MES");
               AnyError = 1;
               GX_FocusControl = edtAusen_Mes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2Ausen_Mes = 0;
               AssignAttri("", false, "A2Ausen_Mes", StringUtil.LTrimStr( (decimal)(A2Ausen_Mes), 4, 0));
            }
            else
            {
               A2Ausen_Mes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtAusen_Mes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A2Ausen_Mes", StringUtil.LTrimStr( (decimal)(A2Ausen_Mes), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtAusen_Ano_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAusen_Ano_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "AUSEN_ANO");
               AnyError = 1;
               GX_FocusControl = edtAusen_Ano_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A3Ausen_Ano = 0;
               AssignAttri("", false, "A3Ausen_Ano", StringUtil.LTrimStr( (decimal)(A3Ausen_Ano), 4, 0));
            }
            else
            {
               A3Ausen_Ano = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtAusen_Ano_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A3Ausen_Ano", StringUtil.LTrimStr( (decimal)(A3Ausen_Ano), 4, 0));
            }
            A4IndicadoresCodigo = cgiGet( edtIndicadoresCodigo_Internalname);
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A5Cod_Area = cgiGet( edtCod_Area_Internalname);
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            if ( ( ( context.localUtil.CToN( cgiGet( edtAusen_Valor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAusen_Valor_Internalname), ",", ".") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "AUSEN_VALOR");
               AnyError = 1;
               GX_FocusControl = edtAusen_Valor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A6Ausen_Valor = 0;
               AssignAttri("", false, "A6Ausen_Valor", StringUtil.LTrimStr( A6Ausen_Valor, 15, 2));
            }
            else
            {
               A6Ausen_Valor = context.localUtil.CToN( cgiGet( edtAusen_Valor_Internalname), ",", ".");
               AssignAttri("", false, "A6Ausen_Valor", StringUtil.LTrimStr( A6Ausen_Valor, 15, 2));
            }
            A7AusentismosUser = cgiGet( edtAusentismosUser_Internalname);
            AssignAttri("", false, "A7AusentismosUser", A7AusentismosUser);
            if ( context.localUtil.VCDate( cgiGet( edtAusentismosReg_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Ausentismos Reg"}), 1, "AUSENTISMOSREG");
               AnyError = 1;
               GX_FocusControl = edtAusentismosReg_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A8AusentismosReg = DateTime.MinValue;
               AssignAttri("", false, "A8AusentismosReg", context.localUtil.Format(A8AusentismosReg, "99/99/99"));
            }
            else
            {
               A8AusentismosReg = context.localUtil.CToD( cgiGet( edtAusentismosReg_Internalname), 2);
               AssignAttri("", false, "A8AusentismosReg", context.localUtil.Format(A8AusentismosReg, "99/99/99"));
            }
            A9AusentismosHor = cgiGet( edtAusentismosHor_Internalname);
            AssignAttri("", false, "A9AusentismosHor", A9AusentismosHor);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            standaloneNotModal( ) ;
         }
         else
         {
            standaloneNotModal( ) ;
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
            {
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               A1Ausen_Fecha = context.localUtil.ParseDateParm( GetPar( "Ausen_Fecha"));
               AssignAttri("", false, "A1Ausen_Fecha", context.localUtil.Format(A1Ausen_Fecha, "99/99/99"));
               A2Ausen_Mes = (short)(Math.Round(NumberUtil.Val( GetPar( "Ausen_Mes"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A2Ausen_Mes", StringUtil.LTrimStr( (decimal)(A2Ausen_Mes), 4, 0));
               A3Ausen_Ano = (short)(Math.Round(NumberUtil.Val( GetPar( "Ausen_Ano"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A3Ausen_Ano", StringUtil.LTrimStr( (decimal)(A3Ausen_Ano), 4, 0));
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
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
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
               InitAll015( ) ;
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
         DisableAttributes015( ) ;
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

      protected void CONFIRM_016( )
      {
         nGXsfl_83_idx = 0;
         while ( nGXsfl_83_idx < nRC_GXsfl_83 )
         {
            ReadRow016( ) ;
            if ( ( nRcdExists_6 != 0 ) || ( nIsMod_6 != 0 ) )
            {
               GetKey016( ) ;
               if ( ( nRcdExists_6 == 0 ) && ( nRcdDeleted_6 == 0 ) )
               {
                  if ( RcdFound6 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate016( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable016( ) ;
                        CloseExtendedTableCursors016( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "AUSENAREA_FECHA_" + sGXsfl_83_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtAusenArea_Fecha_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound6 != 0 )
                  {
                     if ( nRcdDeleted_6 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey016( ) ;
                        Load016( ) ;
                        BeforeValidate016( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls016( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_6 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate016( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable016( ) ;
                              CloseExtendedTableCursors016( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_6 == 0 )
                     {
                        GXCCtl = "AUSENAREA_FECHA_" + sGXsfl_83_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtAusenArea_Fecha_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtAusenArea_Fecha_Internalname, context.localUtil.Format(A10AusenArea_Fecha, "99/99/99")) ;
            ChangePostValue( edtTipoAusen_Codigo_Internalname, A11TipoAusen_Codigo) ;
            ChangePostValue( edtAusenAreaValor_Internalname, StringUtil.LTrim( StringUtil.NToC( A12AusenAreaValor, 15, 2, ",", ""))) ;
            ChangePostValue( edtAusentismosAreaUser_Internalname, A13AusentismosAreaUser) ;
            ChangePostValue( edtAusentismosAreaReg_Internalname, context.localUtil.Format(A14AusentismosAreaReg, "99/99/99")) ;
            ChangePostValue( edtAusentismosAreaHor_Internalname, A15AusentismosAreaHor) ;
            ChangePostValue( "ZT_"+"Z10AusenArea_Fecha_"+sGXsfl_83_idx, context.localUtil.DToC( Z10AusenArea_Fecha, 0, "/")) ;
            ChangePostValue( "ZT_"+"Z11TipoAusen_Codigo_"+sGXsfl_83_idx, Z11TipoAusen_Codigo) ;
            ChangePostValue( "ZT_"+"Z12AusenAreaValor_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( Z12AusenAreaValor, 15, 2, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z13AusentismosAreaUser_"+sGXsfl_83_idx, Z13AusentismosAreaUser) ;
            ChangePostValue( "ZT_"+"Z14AusentismosAreaReg_"+sGXsfl_83_idx, context.localUtil.DToC( Z14AusentismosAreaReg, 0, "/")) ;
            ChangePostValue( "ZT_"+"Z15AusentismosAreaHor_"+sGXsfl_83_idx, Z15AusentismosAreaHor) ;
            ChangePostValue( "nRcdDeleted_6_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_6), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdExists_6_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_6), 4, 0, ",", ""))) ;
            ChangePostValue( "nIsMod_6_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_6), 4, 0, ",", ""))) ;
            if ( nIsMod_6 != 0 )
            {
               ChangePostValue( "AUSENAREA_FECHA_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAusenArea_Fecha_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "TIPOAUSEN_CODIGO_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTipoAusen_Codigo_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "AUSENAREAVALOR_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAusenAreaValor_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "AUSENTISMOSAREAUSER_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAusentismosAreaUser_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "AUSENTISMOSAREAREG_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAusentismosAreaReg_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "AUSENTISMOSAREAHOR_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAusentismosAreaHor_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption010( )
      {
      }

      protected void ZM015( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z6Ausen_Valor = T00016_A6Ausen_Valor[0];
               Z7AusentismosUser = T00016_A7AusentismosUser[0];
               Z8AusentismosReg = T00016_A8AusentismosReg[0];
               Z9AusentismosHor = T00016_A9AusentismosHor[0];
            }
            else
            {
               Z6Ausen_Valor = A6Ausen_Valor;
               Z7AusentismosUser = A7AusentismosUser;
               Z8AusentismosReg = A8AusentismosReg;
               Z9AusentismosHor = A9AusentismosHor;
            }
         }
         if ( GX_JID == -5 )
         {
            Z1Ausen_Fecha = A1Ausen_Fecha;
            Z2Ausen_Mes = A2Ausen_Mes;
            Z3Ausen_Ano = A3Ausen_Ano;
            Z6Ausen_Valor = A6Ausen_Valor;
            Z7AusentismosUser = A7AusentismosUser;
            Z8AusentismosReg = A8AusentismosReg;
            Z9AusentismosHor = A9AusentismosHor;
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

      protected void Load015( )
      {
         /* Using cursor T00019 */
         pr_default.execute(7, new Object[] {A1Ausen_Fecha, A2Ausen_Mes, A3Ausen_Ano, A4IndicadoresCodigo, A5Cod_Area});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound5 = 1;
            A6Ausen_Valor = T00019_A6Ausen_Valor[0];
            AssignAttri("", false, "A6Ausen_Valor", StringUtil.LTrimStr( A6Ausen_Valor, 15, 2));
            A7AusentismosUser = T00019_A7AusentismosUser[0];
            AssignAttri("", false, "A7AusentismosUser", A7AusentismosUser);
            A8AusentismosReg = T00019_A8AusentismosReg[0];
            AssignAttri("", false, "A8AusentismosReg", context.localUtil.Format(A8AusentismosReg, "99/99/99"));
            A9AusentismosHor = T00019_A9AusentismosHor[0];
            AssignAttri("", false, "A9AusentismosHor", A9AusentismosHor);
            ZM015( -5) ;
         }
         pr_default.close(7);
         OnLoadActions015( ) ;
      }

      protected void OnLoadActions015( )
      {
      }

      protected void CheckExtendedTable015( )
      {
         nIsDirty_5 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A1Ausen_Fecha) || ( DateTimeUtil.ResetTime ( A1Ausen_Fecha ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Ausen_Fecha fuera de rango", "OutOfRange", 1, "AUSEN_FECHA");
            AnyError = 1;
            GX_FocusControl = edtAusen_Fecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00017 */
         pr_default.execute(5, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(5);
         /* Using cursor T00018 */
         pr_default.execute(6, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(6);
         if ( ! ( (DateTime.MinValue==A8AusentismosReg) || ( DateTimeUtil.ResetTime ( A8AusentismosReg ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Ausentismos Reg fuera de rango", "OutOfRange", 1, "AUSENTISMOSREG");
            AnyError = 1;
            GX_FocusControl = edtAusentismosReg_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors015( )
      {
         pr_default.close(5);
         pr_default.close(6);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_6( string A4IndicadoresCodigo )
      {
         /* Using cursor T000110 */
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

      protected void gxLoad_7( string A5Cod_Area )
      {
         /* Using cursor T000111 */
         pr_default.execute(9, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
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

      protected void GetKey015( )
      {
         /* Using cursor T000112 */
         pr_default.execute(10, new Object[] {A1Ausen_Fecha, A2Ausen_Mes, A3Ausen_Ano, A4IndicadoresCodigo, A5Cod_Area});
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound5 = 1;
         }
         else
         {
            RcdFound5 = 0;
         }
         pr_default.close(10);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00016 */
         pr_default.execute(4, new Object[] {A1Ausen_Fecha, A2Ausen_Mes, A3Ausen_Ano, A4IndicadoresCodigo, A5Cod_Area});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM015( 5) ;
            RcdFound5 = 1;
            A1Ausen_Fecha = T00016_A1Ausen_Fecha[0];
            AssignAttri("", false, "A1Ausen_Fecha", context.localUtil.Format(A1Ausen_Fecha, "99/99/99"));
            A2Ausen_Mes = T00016_A2Ausen_Mes[0];
            AssignAttri("", false, "A2Ausen_Mes", StringUtil.LTrimStr( (decimal)(A2Ausen_Mes), 4, 0));
            A3Ausen_Ano = T00016_A3Ausen_Ano[0];
            AssignAttri("", false, "A3Ausen_Ano", StringUtil.LTrimStr( (decimal)(A3Ausen_Ano), 4, 0));
            A6Ausen_Valor = T00016_A6Ausen_Valor[0];
            AssignAttri("", false, "A6Ausen_Valor", StringUtil.LTrimStr( A6Ausen_Valor, 15, 2));
            A7AusentismosUser = T00016_A7AusentismosUser[0];
            AssignAttri("", false, "A7AusentismosUser", A7AusentismosUser);
            A8AusentismosReg = T00016_A8AusentismosReg[0];
            AssignAttri("", false, "A8AusentismosReg", context.localUtil.Format(A8AusentismosReg, "99/99/99"));
            A9AusentismosHor = T00016_A9AusentismosHor[0];
            AssignAttri("", false, "A9AusentismosHor", A9AusentismosHor);
            A4IndicadoresCodigo = T00016_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A5Cod_Area = T00016_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            Z1Ausen_Fecha = A1Ausen_Fecha;
            Z2Ausen_Mes = A2Ausen_Mes;
            Z3Ausen_Ano = A3Ausen_Ano;
            Z4IndicadoresCodigo = A4IndicadoresCodigo;
            Z5Cod_Area = A5Cod_Area;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load015( ) ;
            if ( AnyError == 1 )
            {
               RcdFound5 = 0;
               InitializeNonKey015( ) ;
            }
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound5 = 0;
            InitializeNonKey015( ) ;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(4);
      }

      protected void getEqualNoModal( )
      {
         GetKey015( ) ;
         if ( RcdFound5 == 0 )
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
         RcdFound5 = 0;
         /* Using cursor T000113 */
         pr_default.execute(11, new Object[] {A1Ausen_Fecha, A2Ausen_Mes, A3Ausen_Ano, A4IndicadoresCodigo, A5Cod_Area});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( DateTimeUtil.ResetTime ( T000113_A1Ausen_Fecha[0] ) < DateTimeUtil.ResetTime ( A1Ausen_Fecha ) ) || ( DateTimeUtil.ResetTime ( T000113_A1Ausen_Fecha[0] ) == DateTimeUtil.ResetTime ( A1Ausen_Fecha ) ) && ( T000113_A2Ausen_Mes[0] < A2Ausen_Mes ) || ( T000113_A2Ausen_Mes[0] == A2Ausen_Mes ) && ( DateTimeUtil.ResetTime ( T000113_A1Ausen_Fecha[0] ) == DateTimeUtil.ResetTime ( A1Ausen_Fecha ) ) && ( T000113_A3Ausen_Ano[0] < A3Ausen_Ano ) || ( T000113_A3Ausen_Ano[0] == A3Ausen_Ano ) && ( T000113_A2Ausen_Mes[0] == A2Ausen_Mes ) && ( DateTimeUtil.ResetTime ( T000113_A1Ausen_Fecha[0] ) == DateTimeUtil.ResetTime ( A1Ausen_Fecha ) ) && ( StringUtil.StrCmp(T000113_A4IndicadoresCodigo[0], A4IndicadoresCodigo) < 0 ) || ( StringUtil.StrCmp(T000113_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000113_A3Ausen_Ano[0] == A3Ausen_Ano ) && ( T000113_A2Ausen_Mes[0] == A2Ausen_Mes ) && ( DateTimeUtil.ResetTime ( T000113_A1Ausen_Fecha[0] ) == DateTimeUtil.ResetTime ( A1Ausen_Fecha ) ) && ( StringUtil.StrCmp(T000113_A5Cod_Area[0], A5Cod_Area) < 0 ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( DateTimeUtil.ResetTime ( T000113_A1Ausen_Fecha[0] ) > DateTimeUtil.ResetTime ( A1Ausen_Fecha ) ) || ( DateTimeUtil.ResetTime ( T000113_A1Ausen_Fecha[0] ) == DateTimeUtil.ResetTime ( A1Ausen_Fecha ) ) && ( T000113_A2Ausen_Mes[0] > A2Ausen_Mes ) || ( T000113_A2Ausen_Mes[0] == A2Ausen_Mes ) && ( DateTimeUtil.ResetTime ( T000113_A1Ausen_Fecha[0] ) == DateTimeUtil.ResetTime ( A1Ausen_Fecha ) ) && ( T000113_A3Ausen_Ano[0] > A3Ausen_Ano ) || ( T000113_A3Ausen_Ano[0] == A3Ausen_Ano ) && ( T000113_A2Ausen_Mes[0] == A2Ausen_Mes ) && ( DateTimeUtil.ResetTime ( T000113_A1Ausen_Fecha[0] ) == DateTimeUtil.ResetTime ( A1Ausen_Fecha ) ) && ( StringUtil.StrCmp(T000113_A4IndicadoresCodigo[0], A4IndicadoresCodigo) > 0 ) || ( StringUtil.StrCmp(T000113_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000113_A3Ausen_Ano[0] == A3Ausen_Ano ) && ( T000113_A2Ausen_Mes[0] == A2Ausen_Mes ) && ( DateTimeUtil.ResetTime ( T000113_A1Ausen_Fecha[0] ) == DateTimeUtil.ResetTime ( A1Ausen_Fecha ) ) && ( StringUtil.StrCmp(T000113_A5Cod_Area[0], A5Cod_Area) > 0 ) ) )
            {
               A1Ausen_Fecha = T000113_A1Ausen_Fecha[0];
               AssignAttri("", false, "A1Ausen_Fecha", context.localUtil.Format(A1Ausen_Fecha, "99/99/99"));
               A2Ausen_Mes = T000113_A2Ausen_Mes[0];
               AssignAttri("", false, "A2Ausen_Mes", StringUtil.LTrimStr( (decimal)(A2Ausen_Mes), 4, 0));
               A3Ausen_Ano = T000113_A3Ausen_Ano[0];
               AssignAttri("", false, "A3Ausen_Ano", StringUtil.LTrimStr( (decimal)(A3Ausen_Ano), 4, 0));
               A4IndicadoresCodigo = T000113_A4IndicadoresCodigo[0];
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               A5Cod_Area = T000113_A5Cod_Area[0];
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               RcdFound5 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void move_previous( )
      {
         RcdFound5 = 0;
         /* Using cursor T000114 */
         pr_default.execute(12, new Object[] {A1Ausen_Fecha, A2Ausen_Mes, A3Ausen_Ano, A4IndicadoresCodigo, A5Cod_Area});
         if ( (pr_default.getStatus(12) != 101) )
         {
            while ( (pr_default.getStatus(12) != 101) && ( ( DateTimeUtil.ResetTime ( T000114_A1Ausen_Fecha[0] ) > DateTimeUtil.ResetTime ( A1Ausen_Fecha ) ) || ( DateTimeUtil.ResetTime ( T000114_A1Ausen_Fecha[0] ) == DateTimeUtil.ResetTime ( A1Ausen_Fecha ) ) && ( T000114_A2Ausen_Mes[0] > A2Ausen_Mes ) || ( T000114_A2Ausen_Mes[0] == A2Ausen_Mes ) && ( DateTimeUtil.ResetTime ( T000114_A1Ausen_Fecha[0] ) == DateTimeUtil.ResetTime ( A1Ausen_Fecha ) ) && ( T000114_A3Ausen_Ano[0] > A3Ausen_Ano ) || ( T000114_A3Ausen_Ano[0] == A3Ausen_Ano ) && ( T000114_A2Ausen_Mes[0] == A2Ausen_Mes ) && ( DateTimeUtil.ResetTime ( T000114_A1Ausen_Fecha[0] ) == DateTimeUtil.ResetTime ( A1Ausen_Fecha ) ) && ( StringUtil.StrCmp(T000114_A4IndicadoresCodigo[0], A4IndicadoresCodigo) > 0 ) || ( StringUtil.StrCmp(T000114_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000114_A3Ausen_Ano[0] == A3Ausen_Ano ) && ( T000114_A2Ausen_Mes[0] == A2Ausen_Mes ) && ( DateTimeUtil.ResetTime ( T000114_A1Ausen_Fecha[0] ) == DateTimeUtil.ResetTime ( A1Ausen_Fecha ) ) && ( StringUtil.StrCmp(T000114_A5Cod_Area[0], A5Cod_Area) > 0 ) ) )
            {
               pr_default.readNext(12);
            }
            if ( (pr_default.getStatus(12) != 101) && ( ( DateTimeUtil.ResetTime ( T000114_A1Ausen_Fecha[0] ) < DateTimeUtil.ResetTime ( A1Ausen_Fecha ) ) || ( DateTimeUtil.ResetTime ( T000114_A1Ausen_Fecha[0] ) == DateTimeUtil.ResetTime ( A1Ausen_Fecha ) ) && ( T000114_A2Ausen_Mes[0] < A2Ausen_Mes ) || ( T000114_A2Ausen_Mes[0] == A2Ausen_Mes ) && ( DateTimeUtil.ResetTime ( T000114_A1Ausen_Fecha[0] ) == DateTimeUtil.ResetTime ( A1Ausen_Fecha ) ) && ( T000114_A3Ausen_Ano[0] < A3Ausen_Ano ) || ( T000114_A3Ausen_Ano[0] == A3Ausen_Ano ) && ( T000114_A2Ausen_Mes[0] == A2Ausen_Mes ) && ( DateTimeUtil.ResetTime ( T000114_A1Ausen_Fecha[0] ) == DateTimeUtil.ResetTime ( A1Ausen_Fecha ) ) && ( StringUtil.StrCmp(T000114_A4IndicadoresCodigo[0], A4IndicadoresCodigo) < 0 ) || ( StringUtil.StrCmp(T000114_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000114_A3Ausen_Ano[0] == A3Ausen_Ano ) && ( T000114_A2Ausen_Mes[0] == A2Ausen_Mes ) && ( DateTimeUtil.ResetTime ( T000114_A1Ausen_Fecha[0] ) == DateTimeUtil.ResetTime ( A1Ausen_Fecha ) ) && ( StringUtil.StrCmp(T000114_A5Cod_Area[0], A5Cod_Area) < 0 ) ) )
            {
               A1Ausen_Fecha = T000114_A1Ausen_Fecha[0];
               AssignAttri("", false, "A1Ausen_Fecha", context.localUtil.Format(A1Ausen_Fecha, "99/99/99"));
               A2Ausen_Mes = T000114_A2Ausen_Mes[0];
               AssignAttri("", false, "A2Ausen_Mes", StringUtil.LTrimStr( (decimal)(A2Ausen_Mes), 4, 0));
               A3Ausen_Ano = T000114_A3Ausen_Ano[0];
               AssignAttri("", false, "A3Ausen_Ano", StringUtil.LTrimStr( (decimal)(A3Ausen_Ano), 4, 0));
               A4IndicadoresCodigo = T000114_A4IndicadoresCodigo[0];
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               A5Cod_Area = T000114_A5Cod_Area[0];
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               RcdFound5 = 1;
            }
         }
         pr_default.close(12);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey015( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtAusen_Fecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert015( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound5 == 1 )
            {
               if ( ( DateTimeUtil.ResetTime ( A1Ausen_Fecha ) != DateTimeUtil.ResetTime ( Z1Ausen_Fecha ) ) || ( A2Ausen_Mes != Z2Ausen_Mes ) || ( A3Ausen_Ano != Z3Ausen_Ano ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) )
               {
                  A1Ausen_Fecha = Z1Ausen_Fecha;
                  AssignAttri("", false, "A1Ausen_Fecha", context.localUtil.Format(A1Ausen_Fecha, "99/99/99"));
                  A2Ausen_Mes = Z2Ausen_Mes;
                  AssignAttri("", false, "A2Ausen_Mes", StringUtil.LTrimStr( (decimal)(A2Ausen_Mes), 4, 0));
                  A3Ausen_Ano = Z3Ausen_Ano;
                  AssignAttri("", false, "A3Ausen_Ano", StringUtil.LTrimStr( (decimal)(A3Ausen_Ano), 4, 0));
                  A4IndicadoresCodigo = Z4IndicadoresCodigo;
                  AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
                  A5Cod_Area = Z5Cod_Area;
                  AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "AUSEN_FECHA");
                  AnyError = 1;
                  GX_FocusControl = edtAusen_Fecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtAusen_Fecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update015( ) ;
                  GX_FocusControl = edtAusen_Fecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( DateTimeUtil.ResetTime ( A1Ausen_Fecha ) != DateTimeUtil.ResetTime ( Z1Ausen_Fecha ) ) || ( A2Ausen_Mes != Z2Ausen_Mes ) || ( A3Ausen_Ano != Z3Ausen_Ano ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtAusen_Fecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert015( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "AUSEN_FECHA");
                     AnyError = 1;
                     GX_FocusControl = edtAusen_Fecha_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtAusen_Fecha_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert015( ) ;
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
         if ( ( DateTimeUtil.ResetTime ( A1Ausen_Fecha ) != DateTimeUtil.ResetTime ( Z1Ausen_Fecha ) ) || ( A2Ausen_Mes != Z2Ausen_Mes ) || ( A3Ausen_Ano != Z3Ausen_Ano ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) )
         {
            A1Ausen_Fecha = Z1Ausen_Fecha;
            AssignAttri("", false, "A1Ausen_Fecha", context.localUtil.Format(A1Ausen_Fecha, "99/99/99"));
            A2Ausen_Mes = Z2Ausen_Mes;
            AssignAttri("", false, "A2Ausen_Mes", StringUtil.LTrimStr( (decimal)(A2Ausen_Mes), 4, 0));
            A3Ausen_Ano = Z3Ausen_Ano;
            AssignAttri("", false, "A3Ausen_Ano", StringUtil.LTrimStr( (decimal)(A3Ausen_Ano), 4, 0));
            A4IndicadoresCodigo = Z4IndicadoresCodigo;
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A5Cod_Area = Z5Cod_Area;
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "AUSEN_FECHA");
            AnyError = 1;
            GX_FocusControl = edtAusen_Fecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtAusen_Fecha_Internalname;
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
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "AUSEN_FECHA");
            AnyError = 1;
            GX_FocusControl = edtAusen_Fecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtAusen_Valor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart015( ) ;
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAusen_Valor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd015( ) ;
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
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAusen_Valor_Internalname;
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
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAusen_Valor_Internalname;
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
         ScanStart015( ) ;
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound5 != 0 )
            {
               ScanNext015( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAusen_Valor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd015( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency015( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00015 */
            pr_default.execute(3, new Object[] {A1Ausen_Fecha, A2Ausen_Mes, A3Ausen_Ano, A4IndicadoresCodigo, A5Cod_Area});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Ausentismos"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(3) == 101) || ( Z6Ausen_Valor != T00015_A6Ausen_Valor[0] ) || ( StringUtil.StrCmp(Z7AusentismosUser, T00015_A7AusentismosUser[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z8AusentismosReg ) != DateTimeUtil.ResetTime ( T00015_A8AusentismosReg[0] ) ) || ( StringUtil.StrCmp(Z9AusentismosHor, T00015_A9AusentismosHor[0]) != 0 ) )
            {
               if ( Z6Ausen_Valor != T00015_A6Ausen_Valor[0] )
               {
                  GXUtil.WriteLog("ausentismos:[seudo value changed for attri]"+"Ausen_Valor");
                  GXUtil.WriteLogRaw("Old: ",Z6Ausen_Valor);
                  GXUtil.WriteLogRaw("Current: ",T00015_A6Ausen_Valor[0]);
               }
               if ( StringUtil.StrCmp(Z7AusentismosUser, T00015_A7AusentismosUser[0]) != 0 )
               {
                  GXUtil.WriteLog("ausentismos:[seudo value changed for attri]"+"AusentismosUser");
                  GXUtil.WriteLogRaw("Old: ",Z7AusentismosUser);
                  GXUtil.WriteLogRaw("Current: ",T00015_A7AusentismosUser[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z8AusentismosReg ) != DateTimeUtil.ResetTime ( T00015_A8AusentismosReg[0] ) )
               {
                  GXUtil.WriteLog("ausentismos:[seudo value changed for attri]"+"AusentismosReg");
                  GXUtil.WriteLogRaw("Old: ",Z8AusentismosReg);
                  GXUtil.WriteLogRaw("Current: ",T00015_A8AusentismosReg[0]);
               }
               if ( StringUtil.StrCmp(Z9AusentismosHor, T00015_A9AusentismosHor[0]) != 0 )
               {
                  GXUtil.WriteLog("ausentismos:[seudo value changed for attri]"+"AusentismosHor");
                  GXUtil.WriteLogRaw("Old: ",Z9AusentismosHor);
                  GXUtil.WriteLogRaw("Current: ",T00015_A9AusentismosHor[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Ausentismos"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert015( )
      {
         BeforeValidate015( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable015( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM015( 0) ;
            CheckOptimisticConcurrency015( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm015( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert015( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000115 */
                     pr_default.execute(13, new Object[] {A1Ausen_Fecha, A2Ausen_Mes, A3Ausen_Ano, A6Ausen_Valor, A7AusentismosUser, A8AusentismosReg, A9AusentismosHor, A4IndicadoresCodigo, A5Cod_Area});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("Ausentismos");
                     if ( (pr_default.getStatus(13) == 1) )
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
                           ProcessLevel015( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption010( ) ;
                           }
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
               Load015( ) ;
            }
            EndLevel015( ) ;
         }
         CloseExtendedTableCursors015( ) ;
      }

      protected void Update015( )
      {
         BeforeValidate015( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable015( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency015( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm015( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate015( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000116 */
                     pr_default.execute(14, new Object[] {A6Ausen_Valor, A7AusentismosUser, A8AusentismosReg, A9AusentismosHor, A1Ausen_Fecha, A2Ausen_Mes, A3Ausen_Ano, A4IndicadoresCodigo, A5Cod_Area});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("Ausentismos");
                     if ( (pr_default.getStatus(14) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Ausentismos"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate015( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel015( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
                              ResetCaption010( ) ;
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
            }
            EndLevel015( ) ;
         }
         CloseExtendedTableCursors015( ) ;
      }

      protected void DeferredUpdate015( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate015( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency015( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls015( ) ;
            AfterConfirm015( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete015( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart016( ) ;
                  while ( RcdFound6 != 0 )
                  {
                     getByPrimaryKey016( ) ;
                     Delete016( ) ;
                     ScanNext016( ) ;
                  }
                  ScanEnd016( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000117 */
                     pr_default.execute(15, new Object[] {A1Ausen_Fecha, A2Ausen_Mes, A3Ausen_Ano, A4IndicadoresCodigo, A5Cod_Area});
                     pr_default.close(15);
                     pr_default.SmartCacheProvider.SetUpdated("Ausentismos");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           move_next( ) ;
                           if ( RcdFound5 == 0 )
                           {
                              InitAll015( ) ;
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
                           ResetCaption010( ) ;
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
         }
         sMode5 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel015( ) ;
         Gx_mode = sMode5;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls015( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void ProcessNestedLevel016( )
      {
         nGXsfl_83_idx = 0;
         while ( nGXsfl_83_idx < nRC_GXsfl_83 )
         {
            ReadRow016( ) ;
            if ( ( nRcdExists_6 != 0 ) || ( nIsMod_6 != 0 ) )
            {
               standaloneNotModal016( ) ;
               GetKey016( ) ;
               if ( ( nRcdExists_6 == 0 ) && ( nRcdDeleted_6 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert016( ) ;
               }
               else
               {
                  if ( RcdFound6 != 0 )
                  {
                     if ( ( nRcdDeleted_6 != 0 ) && ( nRcdExists_6 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete016( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_6 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update016( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_6 == 0 )
                     {
                        GXCCtl = "AUSENAREA_FECHA_" + sGXsfl_83_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtAusenArea_Fecha_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtAusenArea_Fecha_Internalname, context.localUtil.Format(A10AusenArea_Fecha, "99/99/99")) ;
            ChangePostValue( edtTipoAusen_Codigo_Internalname, A11TipoAusen_Codigo) ;
            ChangePostValue( edtAusenAreaValor_Internalname, StringUtil.LTrim( StringUtil.NToC( A12AusenAreaValor, 15, 2, ",", ""))) ;
            ChangePostValue( edtAusentismosAreaUser_Internalname, A13AusentismosAreaUser) ;
            ChangePostValue( edtAusentismosAreaReg_Internalname, context.localUtil.Format(A14AusentismosAreaReg, "99/99/99")) ;
            ChangePostValue( edtAusentismosAreaHor_Internalname, A15AusentismosAreaHor) ;
            ChangePostValue( "ZT_"+"Z10AusenArea_Fecha_"+sGXsfl_83_idx, context.localUtil.DToC( Z10AusenArea_Fecha, 0, "/")) ;
            ChangePostValue( "ZT_"+"Z11TipoAusen_Codigo_"+sGXsfl_83_idx, Z11TipoAusen_Codigo) ;
            ChangePostValue( "ZT_"+"Z12AusenAreaValor_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( Z12AusenAreaValor, 15, 2, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z13AusentismosAreaUser_"+sGXsfl_83_idx, Z13AusentismosAreaUser) ;
            ChangePostValue( "ZT_"+"Z14AusentismosAreaReg_"+sGXsfl_83_idx, context.localUtil.DToC( Z14AusentismosAreaReg, 0, "/")) ;
            ChangePostValue( "ZT_"+"Z15AusentismosAreaHor_"+sGXsfl_83_idx, Z15AusentismosAreaHor) ;
            ChangePostValue( "nRcdDeleted_6_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_6), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdExists_6_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_6), 4, 0, ",", ""))) ;
            ChangePostValue( "nIsMod_6_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_6), 4, 0, ",", ""))) ;
            if ( nIsMod_6 != 0 )
            {
               ChangePostValue( "AUSENAREA_FECHA_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAusenArea_Fecha_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "TIPOAUSEN_CODIGO_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTipoAusen_Codigo_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "AUSENAREAVALOR_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAusenAreaValor_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "AUSENTISMOSAREAUSER_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAusentismosAreaUser_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "AUSENTISMOSAREAREG_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAusentismosAreaReg_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "AUSENTISMOSAREAHOR_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAusentismosAreaHor_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll016( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_6 = 0;
         nIsMod_6 = 0;
         nRcdDeleted_6 = 0;
      }

      protected void ProcessLevel015( )
      {
         /* Save parent mode. */
         sMode5 = Gx_mode;
         ProcessNestedLevel016( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode5;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel015( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(3);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete015( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(2);
            context.CommitDataStores("ausentismos",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues010( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(2);
            context.RollbackDataStores("ausentismos",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart015( )
      {
         /* Using cursor T000118 */
         pr_default.execute(16);
         RcdFound5 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound5 = 1;
            A1Ausen_Fecha = T000118_A1Ausen_Fecha[0];
            AssignAttri("", false, "A1Ausen_Fecha", context.localUtil.Format(A1Ausen_Fecha, "99/99/99"));
            A2Ausen_Mes = T000118_A2Ausen_Mes[0];
            AssignAttri("", false, "A2Ausen_Mes", StringUtil.LTrimStr( (decimal)(A2Ausen_Mes), 4, 0));
            A3Ausen_Ano = T000118_A3Ausen_Ano[0];
            AssignAttri("", false, "A3Ausen_Ano", StringUtil.LTrimStr( (decimal)(A3Ausen_Ano), 4, 0));
            A4IndicadoresCodigo = T000118_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A5Cod_Area = T000118_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext015( )
      {
         /* Scan next routine */
         pr_default.readNext(16);
         RcdFound5 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound5 = 1;
            A1Ausen_Fecha = T000118_A1Ausen_Fecha[0];
            AssignAttri("", false, "A1Ausen_Fecha", context.localUtil.Format(A1Ausen_Fecha, "99/99/99"));
            A2Ausen_Mes = T000118_A2Ausen_Mes[0];
            AssignAttri("", false, "A2Ausen_Mes", StringUtil.LTrimStr( (decimal)(A2Ausen_Mes), 4, 0));
            A3Ausen_Ano = T000118_A3Ausen_Ano[0];
            AssignAttri("", false, "A3Ausen_Ano", StringUtil.LTrimStr( (decimal)(A3Ausen_Ano), 4, 0));
            A4IndicadoresCodigo = T000118_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A5Cod_Area = T000118_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
         }
      }

      protected void ScanEnd015( )
      {
         pr_default.close(16);
      }

      protected void AfterConfirm015( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert015( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate015( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete015( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete015( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate015( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes015( )
      {
         edtAusen_Fecha_Enabled = 0;
         AssignProp("", false, edtAusen_Fecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAusen_Fecha_Enabled), 5, 0), true);
         edtAusen_Mes_Enabled = 0;
         AssignProp("", false, edtAusen_Mes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAusen_Mes_Enabled), 5, 0), true);
         edtAusen_Ano_Enabled = 0;
         AssignProp("", false, edtAusen_Ano_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAusen_Ano_Enabled), 5, 0), true);
         edtIndicadoresCodigo_Enabled = 0;
         AssignProp("", false, edtIndicadoresCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIndicadoresCodigo_Enabled), 5, 0), true);
         edtCod_Area_Enabled = 0;
         AssignProp("", false, edtCod_Area_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCod_Area_Enabled), 5, 0), true);
         edtAusen_Valor_Enabled = 0;
         AssignProp("", false, edtAusen_Valor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAusen_Valor_Enabled), 5, 0), true);
         edtAusentismosUser_Enabled = 0;
         AssignProp("", false, edtAusentismosUser_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAusentismosUser_Enabled), 5, 0), true);
         edtAusentismosReg_Enabled = 0;
         AssignProp("", false, edtAusentismosReg_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAusentismosReg_Enabled), 5, 0), true);
         edtAusentismosHor_Enabled = 0;
         AssignProp("", false, edtAusentismosHor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAusentismosHor_Enabled), 5, 0), true);
      }

      protected void ZM016( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z12AusenAreaValor = T00013_A12AusenAreaValor[0];
               Z13AusentismosAreaUser = T00013_A13AusentismosAreaUser[0];
               Z14AusentismosAreaReg = T00013_A14AusentismosAreaReg[0];
               Z15AusentismosAreaHor = T00013_A15AusentismosAreaHor[0];
            }
            else
            {
               Z12AusenAreaValor = A12AusenAreaValor;
               Z13AusentismosAreaUser = A13AusentismosAreaUser;
               Z14AusentismosAreaReg = A14AusentismosAreaReg;
               Z15AusentismosAreaHor = A15AusentismosAreaHor;
            }
         }
         if ( GX_JID == -8 )
         {
            Z1Ausen_Fecha = A1Ausen_Fecha;
            Z2Ausen_Mes = A2Ausen_Mes;
            Z3Ausen_Ano = A3Ausen_Ano;
            Z4IndicadoresCodigo = A4IndicadoresCodigo;
            Z5Cod_Area = A5Cod_Area;
            Z10AusenArea_Fecha = A10AusenArea_Fecha;
            Z12AusenAreaValor = A12AusenAreaValor;
            Z13AusentismosAreaUser = A13AusentismosAreaUser;
            Z14AusentismosAreaReg = A14AusentismosAreaReg;
            Z15AusentismosAreaHor = A15AusentismosAreaHor;
            Z11TipoAusen_Codigo = A11TipoAusen_Codigo;
         }
      }

      protected void standaloneNotModal016( )
      {
      }

      protected void standaloneModal016( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtAusenArea_Fecha_Enabled = 0;
            AssignProp("", false, edtAusenArea_Fecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAusenArea_Fecha_Enabled), 5, 0), !bGXsfl_83_Refreshing);
         }
         else
         {
            edtAusenArea_Fecha_Enabled = 1;
            AssignProp("", false, edtAusenArea_Fecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAusenArea_Fecha_Enabled), 5, 0), !bGXsfl_83_Refreshing);
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtTipoAusen_Codigo_Enabled = 0;
            AssignProp("", false, edtTipoAusen_Codigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipoAusen_Codigo_Enabled), 5, 0), !bGXsfl_83_Refreshing);
         }
         else
         {
            edtTipoAusen_Codigo_Enabled = 1;
            AssignProp("", false, edtTipoAusen_Codigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipoAusen_Codigo_Enabled), 5, 0), !bGXsfl_83_Refreshing);
         }
      }

      protected void Load016( )
      {
         /* Using cursor T000119 */
         pr_default.execute(17, new Object[] {A1Ausen_Fecha, A2Ausen_Mes, A3Ausen_Ano, A4IndicadoresCodigo, A5Cod_Area, A10AusenArea_Fecha, A11TipoAusen_Codigo});
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound6 = 1;
            A12AusenAreaValor = T000119_A12AusenAreaValor[0];
            A13AusentismosAreaUser = T000119_A13AusentismosAreaUser[0];
            A14AusentismosAreaReg = T000119_A14AusentismosAreaReg[0];
            A15AusentismosAreaHor = T000119_A15AusentismosAreaHor[0];
            ZM016( -8) ;
         }
         pr_default.close(17);
         OnLoadActions016( ) ;
      }

      protected void OnLoadActions016( )
      {
      }

      protected void CheckExtendedTable016( )
      {
         nIsDirty_6 = 0;
         Gx_BScreen = 1;
         standaloneModal016( ) ;
         if ( ! ( (DateTime.MinValue==A10AusenArea_Fecha) || ( DateTimeUtil.ResetTime ( A10AusenArea_Fecha ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GXCCtl = "AUSENAREA_FECHA_" + sGXsfl_83_idx;
            GX_msglist.addItem("Campo Ausen Area_Fecha fuera de rango", "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtAusenArea_Fecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00014 */
         pr_default.execute(2, new Object[] {A11TipoAusen_Codigo});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "TIPOAUSEN_CODIGO_" + sGXsfl_83_idx;
            GX_msglist.addItem("No existe 'Tipo Ausentismo'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtTipoAusen_Codigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         if ( ! ( (DateTime.MinValue==A14AusentismosAreaReg) || ( DateTimeUtil.ResetTime ( A14AusentismosAreaReg ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GXCCtl = "AUSENTISMOSAREAREG_" + sGXsfl_83_idx;
            GX_msglist.addItem("Campo Ausentismos Area Reg fuera de rango", "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtAusentismosAreaReg_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors016( )
      {
         pr_default.close(2);
      }

      protected void enableDisable016( )
      {
      }

      protected void gxLoad_9( string A11TipoAusen_Codigo )
      {
         /* Using cursor T000120 */
         pr_default.execute(18, new Object[] {A11TipoAusen_Codigo});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GXCCtl = "TIPOAUSEN_CODIGO_" + sGXsfl_83_idx;
            GX_msglist.addItem("No existe 'Tipo Ausentismo'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtTipoAusen_Codigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(18) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(18);
      }

      protected void GetKey016( )
      {
         /* Using cursor T000121 */
         pr_default.execute(19, new Object[] {A1Ausen_Fecha, A2Ausen_Mes, A3Ausen_Ano, A4IndicadoresCodigo, A5Cod_Area, A10AusenArea_Fecha, A11TipoAusen_Codigo});
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound6 = 1;
         }
         else
         {
            RcdFound6 = 0;
         }
         pr_default.close(19);
      }

      protected void getByPrimaryKey016( )
      {
         /* Using cursor T00013 */
         pr_default.execute(1, new Object[] {A1Ausen_Fecha, A2Ausen_Mes, A3Ausen_Ano, A4IndicadoresCodigo, A5Cod_Area, A10AusenArea_Fecha, A11TipoAusen_Codigo});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM016( 8) ;
            RcdFound6 = 1;
            InitializeNonKey016( ) ;
            A10AusenArea_Fecha = T00013_A10AusenArea_Fecha[0];
            A12AusenAreaValor = T00013_A12AusenAreaValor[0];
            A13AusentismosAreaUser = T00013_A13AusentismosAreaUser[0];
            A14AusentismosAreaReg = T00013_A14AusentismosAreaReg[0];
            A15AusentismosAreaHor = T00013_A15AusentismosAreaHor[0];
            A11TipoAusen_Codigo = T00013_A11TipoAusen_Codigo[0];
            Z1Ausen_Fecha = A1Ausen_Fecha;
            Z2Ausen_Mes = A2Ausen_Mes;
            Z3Ausen_Ano = A3Ausen_Ano;
            Z4IndicadoresCodigo = A4IndicadoresCodigo;
            Z5Cod_Area = A5Cod_Area;
            Z10AusenArea_Fecha = A10AusenArea_Fecha;
            Z11TipoAusen_Codigo = A11TipoAusen_Codigo;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal016( ) ;
            Load016( ) ;
            Gx_mode = sMode6;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound6 = 0;
            InitializeNonKey016( ) ;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal016( ) ;
            Gx_mode = sMode6;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes016( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency016( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00012 */
            pr_default.execute(0, new Object[] {A1Ausen_Fecha, A2Ausen_Mes, A3Ausen_Ano, A4IndicadoresCodigo, A5Cod_Area, A10AusenArea_Fecha, A11TipoAusen_Codigo});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"AusentismosTipos"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z12AusenAreaValor != T00012_A12AusenAreaValor[0] ) || ( StringUtil.StrCmp(Z13AusentismosAreaUser, T00012_A13AusentismosAreaUser[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z14AusentismosAreaReg ) != DateTimeUtil.ResetTime ( T00012_A14AusentismosAreaReg[0] ) ) || ( StringUtil.StrCmp(Z15AusentismosAreaHor, T00012_A15AusentismosAreaHor[0]) != 0 ) )
            {
               if ( Z12AusenAreaValor != T00012_A12AusenAreaValor[0] )
               {
                  GXUtil.WriteLog("ausentismos:[seudo value changed for attri]"+"AusenAreaValor");
                  GXUtil.WriteLogRaw("Old: ",Z12AusenAreaValor);
                  GXUtil.WriteLogRaw("Current: ",T00012_A12AusenAreaValor[0]);
               }
               if ( StringUtil.StrCmp(Z13AusentismosAreaUser, T00012_A13AusentismosAreaUser[0]) != 0 )
               {
                  GXUtil.WriteLog("ausentismos:[seudo value changed for attri]"+"AusentismosAreaUser");
                  GXUtil.WriteLogRaw("Old: ",Z13AusentismosAreaUser);
                  GXUtil.WriteLogRaw("Current: ",T00012_A13AusentismosAreaUser[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z14AusentismosAreaReg ) != DateTimeUtil.ResetTime ( T00012_A14AusentismosAreaReg[0] ) )
               {
                  GXUtil.WriteLog("ausentismos:[seudo value changed for attri]"+"AusentismosAreaReg");
                  GXUtil.WriteLogRaw("Old: ",Z14AusentismosAreaReg);
                  GXUtil.WriteLogRaw("Current: ",T00012_A14AusentismosAreaReg[0]);
               }
               if ( StringUtil.StrCmp(Z15AusentismosAreaHor, T00012_A15AusentismosAreaHor[0]) != 0 )
               {
                  GXUtil.WriteLog("ausentismos:[seudo value changed for attri]"+"AusentismosAreaHor");
                  GXUtil.WriteLogRaw("Old: ",Z15AusentismosAreaHor);
                  GXUtil.WriteLogRaw("Current: ",T00012_A15AusentismosAreaHor[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"AusentismosTipos"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert016( )
      {
         BeforeValidate016( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable016( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM016( 0) ;
            CheckOptimisticConcurrency016( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm016( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert016( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000122 */
                     pr_default.execute(20, new Object[] {A1Ausen_Fecha, A2Ausen_Mes, A3Ausen_Ano, A4IndicadoresCodigo, A5Cod_Area, A10AusenArea_Fecha, A12AusenAreaValor, A13AusentismosAreaUser, A14AusentismosAreaReg, A15AusentismosAreaHor, A11TipoAusen_Codigo});
                     pr_default.close(20);
                     pr_default.SmartCacheProvider.SetUpdated("AusentismosTipos");
                     if ( (pr_default.getStatus(20) == 1) )
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
               Load016( ) ;
            }
            EndLevel016( ) ;
         }
         CloseExtendedTableCursors016( ) ;
      }

      protected void Update016( )
      {
         BeforeValidate016( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable016( ) ;
         }
         if ( ( nIsMod_6 != 0 ) || ( nIsDirty_6 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency016( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm016( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate016( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000123 */
                        pr_default.execute(21, new Object[] {A12AusenAreaValor, A13AusentismosAreaUser, A14AusentismosAreaReg, A15AusentismosAreaHor, A1Ausen_Fecha, A2Ausen_Mes, A3Ausen_Ano, A4IndicadoresCodigo, A5Cod_Area, A10AusenArea_Fecha, A11TipoAusen_Codigo});
                        pr_default.close(21);
                        pr_default.SmartCacheProvider.SetUpdated("AusentismosTipos");
                        if ( (pr_default.getStatus(21) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"AusentismosTipos"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate016( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey016( ) ;
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
               EndLevel016( ) ;
            }
         }
         CloseExtendedTableCursors016( ) ;
      }

      protected void DeferredUpdate016( )
      {
      }

      protected void Delete016( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate016( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency016( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls016( ) ;
            AfterConfirm016( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete016( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000124 */
                  pr_default.execute(22, new Object[] {A1Ausen_Fecha, A2Ausen_Mes, A3Ausen_Ano, A4IndicadoresCodigo, A5Cod_Area, A10AusenArea_Fecha, A11TipoAusen_Codigo});
                  pr_default.close(22);
                  pr_default.SmartCacheProvider.SetUpdated("AusentismosTipos");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode6 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel016( ) ;
         Gx_mode = sMode6;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls016( )
      {
         standaloneModal016( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel016( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart016( )
      {
         /* Scan By routine */
         /* Using cursor T000125 */
         pr_default.execute(23, new Object[] {A1Ausen_Fecha, A2Ausen_Mes, A3Ausen_Ano, A4IndicadoresCodigo, A5Cod_Area});
         RcdFound6 = 0;
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound6 = 1;
            A10AusenArea_Fecha = T000125_A10AusenArea_Fecha[0];
            A11TipoAusen_Codigo = T000125_A11TipoAusen_Codigo[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext016( )
      {
         /* Scan next routine */
         pr_default.readNext(23);
         RcdFound6 = 0;
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound6 = 1;
            A10AusenArea_Fecha = T000125_A10AusenArea_Fecha[0];
            A11TipoAusen_Codigo = T000125_A11TipoAusen_Codigo[0];
         }
      }

      protected void ScanEnd016( )
      {
         pr_default.close(23);
      }

      protected void AfterConfirm016( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert016( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate016( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete016( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete016( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate016( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes016( )
      {
         edtAusenArea_Fecha_Enabled = 0;
         AssignProp("", false, edtAusenArea_Fecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAusenArea_Fecha_Enabled), 5, 0), !bGXsfl_83_Refreshing);
         edtTipoAusen_Codigo_Enabled = 0;
         AssignProp("", false, edtTipoAusen_Codigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipoAusen_Codigo_Enabled), 5, 0), !bGXsfl_83_Refreshing);
         edtAusenAreaValor_Enabled = 0;
         AssignProp("", false, edtAusenAreaValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAusenAreaValor_Enabled), 5, 0), !bGXsfl_83_Refreshing);
         edtAusentismosAreaUser_Enabled = 0;
         AssignProp("", false, edtAusentismosAreaUser_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAusentismosAreaUser_Enabled), 5, 0), !bGXsfl_83_Refreshing);
         edtAusentismosAreaReg_Enabled = 0;
         AssignProp("", false, edtAusentismosAreaReg_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAusentismosAreaReg_Enabled), 5, 0), !bGXsfl_83_Refreshing);
         edtAusentismosAreaHor_Enabled = 0;
         AssignProp("", false, edtAusentismosAreaHor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAusentismosAreaHor_Enabled), 5, 0), !bGXsfl_83_Refreshing);
      }

      protected void send_integrity_lvl_hashes016( )
      {
      }

      protected void send_integrity_lvl_hashes015( )
      {
      }

      protected void SubsflControlProps_836( )
      {
         edtAusenArea_Fecha_Internalname = "AUSENAREA_FECHA_"+sGXsfl_83_idx;
         edtTipoAusen_Codigo_Internalname = "TIPOAUSEN_CODIGO_"+sGXsfl_83_idx;
         imgprompt_11_Internalname = "PROMPT_11_"+sGXsfl_83_idx;
         edtAusenAreaValor_Internalname = "AUSENAREAVALOR_"+sGXsfl_83_idx;
         edtAusentismosAreaUser_Internalname = "AUSENTISMOSAREAUSER_"+sGXsfl_83_idx;
         edtAusentismosAreaReg_Internalname = "AUSENTISMOSAREAREG_"+sGXsfl_83_idx;
         edtAusentismosAreaHor_Internalname = "AUSENTISMOSAREAHOR_"+sGXsfl_83_idx;
      }

      protected void SubsflControlProps_fel_836( )
      {
         edtAusenArea_Fecha_Internalname = "AUSENAREA_FECHA_"+sGXsfl_83_fel_idx;
         edtTipoAusen_Codigo_Internalname = "TIPOAUSEN_CODIGO_"+sGXsfl_83_fel_idx;
         imgprompt_11_Internalname = "PROMPT_11_"+sGXsfl_83_fel_idx;
         edtAusenAreaValor_Internalname = "AUSENAREAVALOR_"+sGXsfl_83_fel_idx;
         edtAusentismosAreaUser_Internalname = "AUSENTISMOSAREAUSER_"+sGXsfl_83_fel_idx;
         edtAusentismosAreaReg_Internalname = "AUSENTISMOSAREAREG_"+sGXsfl_83_fel_idx;
         edtAusentismosAreaHor_Internalname = "AUSENTISMOSAREAHOR_"+sGXsfl_83_fel_idx;
      }

      protected void AddRow016( )
      {
         nGXsfl_83_idx = (int)(nGXsfl_83_idx+1);
         sGXsfl_83_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_idx), 4, 0), 4, "0");
         SubsflControlProps_836( ) ;
         SendRow016( ) ;
      }

      protected void SendRow016( )
      {
         Gridausentismos_areaRow = GXWebRow.GetNew(context);
         if ( subGridausentismos_area_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridausentismos_area_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridausentismos_area_Class, "") != 0 )
            {
               subGridausentismos_area_Linesclass = subGridausentismos_area_Class+"Odd";
            }
         }
         else if ( subGridausentismos_area_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridausentismos_area_Backstyle = 0;
            subGridausentismos_area_Backcolor = subGridausentismos_area_Allbackcolor;
            if ( StringUtil.StrCmp(subGridausentismos_area_Class, "") != 0 )
            {
               subGridausentismos_area_Linesclass = subGridausentismos_area_Class+"Uniform";
            }
         }
         else if ( subGridausentismos_area_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridausentismos_area_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridausentismos_area_Class, "") != 0 )
            {
               subGridausentismos_area_Linesclass = subGridausentismos_area_Class+"Odd";
            }
            subGridausentismos_area_Backcolor = (int)(0x0);
         }
         else if ( subGridausentismos_area_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridausentismos_area_Backstyle = 1;
            if ( ((int)((nGXsfl_83_idx) % (2))) == 0 )
            {
               subGridausentismos_area_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridausentismos_area_Class, "") != 0 )
               {
                  subGridausentismos_area_Linesclass = subGridausentismos_area_Class+"Even";
               }
            }
            else
            {
               subGridausentismos_area_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridausentismos_area_Class, "") != 0 )
               {
                  subGridausentismos_area_Linesclass = subGridausentismos_area_Class+"Odd";
               }
            }
         }
         imgprompt_11_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0040.aspx"+"',["+"{Ctrl:gx.dom.el('"+"TIPOAUSEN_CODIGO_"+sGXsfl_83_idx+"'), id:'"+"TIPOAUSEN_CODIGO_"+sGXsfl_83_idx+"'"+",IOType:'out'}"+"],"+"gx.dom.form()."+"nIsMod_6_"+sGXsfl_83_idx+","+"'', false"+","+"false"+");");
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_6_" + sGXsfl_83_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 84,'',false,'" + sGXsfl_83_idx + "',83)\"";
         ROClassString = "Attribute";
         Gridausentismos_areaRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAusenArea_Fecha_Internalname,context.localUtil.Format(A10AusenArea_Fecha, "99/99/99"),context.localUtil.Format( A10AusenArea_Fecha, "99/99/99"),TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,84);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAusenArea_Fecha_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtAusenArea_Fecha_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)83,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_6_" + sGXsfl_83_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 85,'',false,'" + sGXsfl_83_idx + "',83)\"";
         ROClassString = "Attribute";
         Gridausentismos_areaRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipoAusen_Codigo_Internalname,(string)A11TipoAusen_Codigo,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,85);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTipoAusen_Codigo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtTipoAusen_Codigo_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)83,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_11_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_11_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         Gridausentismos_areaRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_11_Internalname,(string)sImgUrl,(string)imgprompt_11_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_11_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_6_" + sGXsfl_83_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 86,'',false,'" + sGXsfl_83_idx + "',83)\"";
         ROClassString = "Attribute";
         Gridausentismos_areaRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAusenAreaValor_Internalname,StringUtil.LTrim( StringUtil.NToC( A12AusenAreaValor, 15, 2, ",", "")),StringUtil.LTrim( ((edtAusenAreaValor_Enabled!=0) ? context.localUtil.Format( A12AusenAreaValor, "ZZZZZZZZZZZ9.99") : context.localUtil.Format( A12AusenAreaValor, "ZZZZZZZZZZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,86);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAusenAreaValor_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtAusenAreaValor_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)15,(short)0,(short)0,(short)83,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_6_" + sGXsfl_83_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 87,'',false,'" + sGXsfl_83_idx + "',83)\"";
         ROClassString = "Attribute";
         Gridausentismos_areaRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAusentismosAreaUser_Internalname,(string)A13AusentismosAreaUser,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,87);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAusentismosAreaUser_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtAusentismosAreaUser_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)120,(short)0,(short)0,(short)83,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_6_" + sGXsfl_83_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 88,'',false,'" + sGXsfl_83_idx + "',83)\"";
         ROClassString = "Attribute";
         Gridausentismos_areaRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAusentismosAreaReg_Internalname,context.localUtil.Format(A14AusentismosAreaReg, "99/99/99"),context.localUtil.Format( A14AusentismosAreaReg, "99/99/99"),TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,88);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAusentismosAreaReg_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtAusentismosAreaReg_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)83,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_6_" + sGXsfl_83_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 89,'',false,'" + sGXsfl_83_idx + "',83)\"";
         ROClassString = "Attribute";
         Gridausentismos_areaRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAusentismosAreaHor_Internalname,(string)A15AusentismosAreaHor,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAusentismosAreaHor_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtAusentismosAreaHor_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)83,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         ajax_sending_grid_row(Gridausentismos_areaRow);
         send_integrity_lvl_hashes016( ) ;
         GXCCtl = "Z10AusenArea_Fecha_" + sGXsfl_83_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, context.localUtil.DToC( Z10AusenArea_Fecha, 0, "/"));
         GXCCtl = "Z11TipoAusen_Codigo_" + sGXsfl_83_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z11TipoAusen_Codigo);
         GXCCtl = "Z12AusenAreaValor_" + sGXsfl_83_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z12AusenAreaValor, 15, 2, ",", "")));
         GXCCtl = "Z13AusentismosAreaUser_" + sGXsfl_83_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z13AusentismosAreaUser);
         GXCCtl = "Z14AusentismosAreaReg_" + sGXsfl_83_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, context.localUtil.DToC( Z14AusentismosAreaReg, 0, "/"));
         GXCCtl = "Z15AusentismosAreaHor_" + sGXsfl_83_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z15AusentismosAreaHor);
         GXCCtl = "nRcdDeleted_6_" + sGXsfl_83_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_6), 4, 0, ",", "")));
         GXCCtl = "nRcdExists_6_" + sGXsfl_83_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_6), 4, 0, ",", "")));
         GXCCtl = "nIsMod_6_" + sGXsfl_83_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_6), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "AUSENAREA_FECHA_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAusenArea_Fecha_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TIPOAUSEN_CODIGO_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTipoAusen_Codigo_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "AUSENAREAVALOR_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAusenAreaValor_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "AUSENTISMOSAREAUSER_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAusentismosAreaUser_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "AUSENTISMOSAREAREG_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAusentismosAreaReg_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "AUSENTISMOSAREAHOR_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAusentismosAreaHor_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROMPT_11_"+sGXsfl_83_idx+"Link", StringUtil.RTrim( imgprompt_11_Link));
         ajax_sending_grid_row(null);
         Gridausentismos_areaContainer.AddRow(Gridausentismos_areaRow);
      }

      protected void ReadRow016( )
      {
         nGXsfl_83_idx = (int)(nGXsfl_83_idx+1);
         sGXsfl_83_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_idx), 4, 0), 4, "0");
         SubsflControlProps_836( ) ;
         edtAusenArea_Fecha_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "AUSENAREA_FECHA_"+sGXsfl_83_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtTipoAusen_Codigo_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "TIPOAUSEN_CODIGO_"+sGXsfl_83_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtAusenAreaValor_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "AUSENAREAVALOR_"+sGXsfl_83_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtAusentismosAreaUser_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "AUSENTISMOSAREAUSER_"+sGXsfl_83_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtAusentismosAreaReg_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "AUSENTISMOSAREAREG_"+sGXsfl_83_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtAusentismosAreaHor_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "AUSENTISMOSAREAHOR_"+sGXsfl_83_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         imgprompt_4_Link = cgiGet( "PROMPT_11_"+sGXsfl_83_idx+"Link");
         if ( context.localUtil.VCDate( cgiGet( edtAusenArea_Fecha_Internalname), 2) == 0 )
         {
            GXCCtl = "AUSENAREA_FECHA_" + sGXsfl_83_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Ausen Area_Fecha"}), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtAusenArea_Fecha_Internalname;
            wbErr = true;
            A10AusenArea_Fecha = DateTime.MinValue;
         }
         else
         {
            A10AusenArea_Fecha = context.localUtil.CToD( cgiGet( edtAusenArea_Fecha_Internalname), 2);
         }
         A11TipoAusen_Codigo = cgiGet( edtTipoAusen_Codigo_Internalname);
         if ( ( ( context.localUtil.CToN( cgiGet( edtAusenAreaValor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAusenAreaValor_Internalname), ",", ".") > 999999999999.99m ) ) )
         {
            GXCCtl = "AUSENAREAVALOR_" + sGXsfl_83_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtAusenAreaValor_Internalname;
            wbErr = true;
            A12AusenAreaValor = 0;
         }
         else
         {
            A12AusenAreaValor = context.localUtil.CToN( cgiGet( edtAusenAreaValor_Internalname), ",", ".");
         }
         A13AusentismosAreaUser = cgiGet( edtAusentismosAreaUser_Internalname);
         if ( context.localUtil.VCDate( cgiGet( edtAusentismosAreaReg_Internalname), 2) == 0 )
         {
            GXCCtl = "AUSENTISMOSAREAREG_" + sGXsfl_83_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Ausentismos Area Reg"}), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtAusentismosAreaReg_Internalname;
            wbErr = true;
            A14AusentismosAreaReg = DateTime.MinValue;
         }
         else
         {
            A14AusentismosAreaReg = context.localUtil.CToD( cgiGet( edtAusentismosAreaReg_Internalname), 2);
         }
         A15AusentismosAreaHor = cgiGet( edtAusentismosAreaHor_Internalname);
         GXCCtl = "Z10AusenArea_Fecha_" + sGXsfl_83_idx;
         Z10AusenArea_Fecha = context.localUtil.CToD( cgiGet( GXCCtl), 0);
         GXCCtl = "Z11TipoAusen_Codigo_" + sGXsfl_83_idx;
         Z11TipoAusen_Codigo = cgiGet( GXCCtl);
         GXCCtl = "Z12AusenAreaValor_" + sGXsfl_83_idx;
         Z12AusenAreaValor = context.localUtil.CToN( cgiGet( GXCCtl), ",", ".");
         GXCCtl = "Z13AusentismosAreaUser_" + sGXsfl_83_idx;
         Z13AusentismosAreaUser = cgiGet( GXCCtl);
         GXCCtl = "Z14AusentismosAreaReg_" + sGXsfl_83_idx;
         Z14AusentismosAreaReg = context.localUtil.CToD( cgiGet( GXCCtl), 0);
         GXCCtl = "Z15AusentismosAreaHor_" + sGXsfl_83_idx;
         Z15AusentismosAreaHor = cgiGet( GXCCtl);
         GXCCtl = "nRcdDeleted_6_" + sGXsfl_83_idx;
         nRcdDeleted_6 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_6_" + sGXsfl_83_idx;
         nRcdExists_6 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_6_" + sGXsfl_83_idx;
         nIsMod_6 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtTipoAusen_Codigo_Enabled = edtTipoAusen_Codigo_Enabled;
         defedtAusenArea_Fecha_Enabled = edtAusenArea_Fecha_Enabled;
      }

      protected void ConfirmValues010( )
      {
         nGXsfl_83_idx = 0;
         sGXsfl_83_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_idx), 4, 0), 4, "0");
         SubsflControlProps_836( ) ;
         while ( nGXsfl_83_idx < nRC_GXsfl_83 )
         {
            nGXsfl_83_idx = (int)(nGXsfl_83_idx+1);
            sGXsfl_83_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_idx), 4, 0), 4, "0");
            SubsflControlProps_836( ) ;
            ChangePostValue( "Z10AusenArea_Fecha_"+sGXsfl_83_idx, cgiGet( "ZT_"+"Z10AusenArea_Fecha_"+sGXsfl_83_idx)) ;
            DeletePostValue( "ZT_"+"Z10AusenArea_Fecha_"+sGXsfl_83_idx) ;
            ChangePostValue( "Z11TipoAusen_Codigo_"+sGXsfl_83_idx, cgiGet( "ZT_"+"Z11TipoAusen_Codigo_"+sGXsfl_83_idx)) ;
            DeletePostValue( "ZT_"+"Z11TipoAusen_Codigo_"+sGXsfl_83_idx) ;
            ChangePostValue( "Z12AusenAreaValor_"+sGXsfl_83_idx, cgiGet( "ZT_"+"Z12AusenAreaValor_"+sGXsfl_83_idx)) ;
            DeletePostValue( "ZT_"+"Z12AusenAreaValor_"+sGXsfl_83_idx) ;
            ChangePostValue( "Z13AusentismosAreaUser_"+sGXsfl_83_idx, cgiGet( "ZT_"+"Z13AusentismosAreaUser_"+sGXsfl_83_idx)) ;
            DeletePostValue( "ZT_"+"Z13AusentismosAreaUser_"+sGXsfl_83_idx) ;
            ChangePostValue( "Z14AusentismosAreaReg_"+sGXsfl_83_idx, cgiGet( "ZT_"+"Z14AusentismosAreaReg_"+sGXsfl_83_idx)) ;
            DeletePostValue( "ZT_"+"Z14AusentismosAreaReg_"+sGXsfl_83_idx) ;
            ChangePostValue( "Z15AusentismosAreaHor_"+sGXsfl_83_idx, cgiGet( "ZT_"+"Z15AusentismosAreaHor_"+sGXsfl_83_idx)) ;
            DeletePostValue( "ZT_"+"Z15AusentismosAreaHor_"+sGXsfl_83_idx) ;
         }
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("ausentismos.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z1Ausen_Fecha", context.localUtil.DToC( Z1Ausen_Fecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z2Ausen_Mes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2Ausen_Mes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z3Ausen_Ano", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z3Ausen_Ano), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z4IndicadoresCodigo", Z4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "Z5Cod_Area", Z5Cod_Area);
         GxWebStd.gx_hidden_field( context, "Z6Ausen_Valor", StringUtil.LTrim( StringUtil.NToC( Z6Ausen_Valor, 15, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z7AusentismosUser", Z7AusentismosUser);
         GxWebStd.gx_hidden_field( context, "Z8AusentismosReg", context.localUtil.DToC( Z8AusentismosReg, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z9AusentismosHor", Z9AusentismosHor);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_83", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_83_idx), 8, 0, ",", "")));
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
         return formatLink("ausentismos.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Ausentismos" ;
      }

      public override string GetPgmdesc( )
      {
         return "Ausentismos" ;
      }

      protected void InitializeNonKey015( )
      {
         A6Ausen_Valor = 0;
         AssignAttri("", false, "A6Ausen_Valor", StringUtil.LTrimStr( A6Ausen_Valor, 15, 2));
         A7AusentismosUser = "";
         AssignAttri("", false, "A7AusentismosUser", A7AusentismosUser);
         A8AusentismosReg = DateTime.MinValue;
         AssignAttri("", false, "A8AusentismosReg", context.localUtil.Format(A8AusentismosReg, "99/99/99"));
         A9AusentismosHor = "";
         AssignAttri("", false, "A9AusentismosHor", A9AusentismosHor);
         Z6Ausen_Valor = 0;
         Z7AusentismosUser = "";
         Z8AusentismosReg = DateTime.MinValue;
         Z9AusentismosHor = "";
      }

      protected void InitAll015( )
      {
         A1Ausen_Fecha = DateTime.MinValue;
         AssignAttri("", false, "A1Ausen_Fecha", context.localUtil.Format(A1Ausen_Fecha, "99/99/99"));
         A2Ausen_Mes = 0;
         AssignAttri("", false, "A2Ausen_Mes", StringUtil.LTrimStr( (decimal)(A2Ausen_Mes), 4, 0));
         A3Ausen_Ano = 0;
         AssignAttri("", false, "A3Ausen_Ano", StringUtil.LTrimStr( (decimal)(A3Ausen_Ano), 4, 0));
         A4IndicadoresCodigo = "";
         AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
         A5Cod_Area = "";
         AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
         InitializeNonKey015( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey016( )
      {
         A12AusenAreaValor = 0;
         A13AusentismosAreaUser = "";
         A14AusentismosAreaReg = DateTime.MinValue;
         A15AusentismosAreaHor = "";
         Z12AusenAreaValor = 0;
         Z13AusentismosAreaUser = "";
         Z14AusentismosAreaReg = DateTime.MinValue;
         Z15AusentismosAreaHor = "";
      }

      protected void InitAll016( )
      {
         A10AusenArea_Fecha = DateTime.MinValue;
         A11TipoAusen_Codigo = "";
         InitializeNonKey016( ) ;
      }

      protected void StandaloneModalInsert016( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20247231014795", true, true);
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
         context.AddJavascriptSource("ausentismos.js", "?20247231014795", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties6( )
      {
         edtTipoAusen_Codigo_Enabled = defedtTipoAusen_Codigo_Enabled;
         AssignProp("", false, edtTipoAusen_Codigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipoAusen_Codigo_Enabled), 5, 0), !bGXsfl_83_Refreshing);
         edtAusenArea_Fecha_Enabled = defedtAusenArea_Fecha_Enabled;
         AssignProp("", false, edtAusenArea_Fecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAusenArea_Fecha_Enabled), 5, 0), !bGXsfl_83_Refreshing);
      }

      protected void StartGridControl83( )
      {
         Gridausentismos_areaContainer.AddObjectProperty("GridName", "Gridausentismos_area");
         Gridausentismos_areaContainer.AddObjectProperty("Header", subGridausentismos_area_Header);
         Gridausentismos_areaContainer.AddObjectProperty("Class", "Grid");
         Gridausentismos_areaContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridausentismos_areaContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridausentismos_areaContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridausentismos_area_Backcolorstyle), 1, 0, ".", "")));
         Gridausentismos_areaContainer.AddObjectProperty("CmpContext", "");
         Gridausentismos_areaContainer.AddObjectProperty("InMasterPage", "false");
         Gridausentismos_areaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridausentismos_areaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A10AusenArea_Fecha, "99/99/99")));
         Gridausentismos_areaColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAusenArea_Fecha_Enabled), 5, 0, ".", "")));
         Gridausentismos_areaContainer.AddColumnProperties(Gridausentismos_areaColumn);
         Gridausentismos_areaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridausentismos_areaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A11TipoAusen_Codigo));
         Gridausentismos_areaColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTipoAusen_Codigo_Enabled), 5, 0, ".", "")));
         Gridausentismos_areaContainer.AddColumnProperties(Gridausentismos_areaColumn);
         Gridausentismos_areaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridausentismos_areaContainer.AddColumnProperties(Gridausentismos_areaColumn);
         Gridausentismos_areaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridausentismos_areaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A12AusenAreaValor, 15, 2, ".", ""))));
         Gridausentismos_areaColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAusenAreaValor_Enabled), 5, 0, ".", "")));
         Gridausentismos_areaContainer.AddColumnProperties(Gridausentismos_areaColumn);
         Gridausentismos_areaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridausentismos_areaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A13AusentismosAreaUser));
         Gridausentismos_areaColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAusentismosAreaUser_Enabled), 5, 0, ".", "")));
         Gridausentismos_areaContainer.AddColumnProperties(Gridausentismos_areaColumn);
         Gridausentismos_areaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridausentismos_areaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A14AusentismosAreaReg, "99/99/99")));
         Gridausentismos_areaColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAusentismosAreaReg_Enabled), 5, 0, ".", "")));
         Gridausentismos_areaContainer.AddColumnProperties(Gridausentismos_areaColumn);
         Gridausentismos_areaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridausentismos_areaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A15AusentismosAreaHor));
         Gridausentismos_areaColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAusentismosAreaHor_Enabled), 5, 0, ".", "")));
         Gridausentismos_areaContainer.AddColumnProperties(Gridausentismos_areaColumn);
         Gridausentismos_areaContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridausentismos_area_Selectedindex), 4, 0, ".", "")));
         Gridausentismos_areaContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridausentismos_area_Allowselection), 1, 0, ".", "")));
         Gridausentismos_areaContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridausentismos_area_Selectioncolor), 9, 0, ".", "")));
         Gridausentismos_areaContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridausentismos_area_Allowhovering), 1, 0, ".", "")));
         Gridausentismos_areaContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridausentismos_area_Hoveringcolor), 9, 0, ".", "")));
         Gridausentismos_areaContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridausentismos_area_Allowcollapsing), 1, 0, ".", "")));
         Gridausentismos_areaContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridausentismos_area_Collapsed), 1, 0, ".", "")));
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
         edtAusen_Fecha_Internalname = "AUSEN_FECHA";
         edtAusen_Mes_Internalname = "AUSEN_MES";
         edtAusen_Ano_Internalname = "AUSEN_ANO";
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO";
         edtCod_Area_Internalname = "COD_AREA";
         edtAusen_Valor_Internalname = "AUSEN_VALOR";
         edtAusentismosUser_Internalname = "AUSENTISMOSUSER";
         edtAusentismosReg_Internalname = "AUSENTISMOSREG";
         edtAusentismosHor_Internalname = "AUSENTISMOSHOR";
         lblTitlearea_Internalname = "TITLEAREA";
         edtAusenArea_Fecha_Internalname = "AUSENAREA_FECHA";
         edtTipoAusen_Codigo_Internalname = "TIPOAUSEN_CODIGO";
         edtAusenAreaValor_Internalname = "AUSENAREAVALOR";
         edtAusentismosAreaUser_Internalname = "AUSENTISMOSAREAUSER";
         edtAusentismosAreaReg_Internalname = "AUSENTISMOSAREAREG";
         edtAusentismosAreaHor_Internalname = "AUSENTISMOSAREAHOR";
         divAreatable_Internalname = "AREATABLE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_4_Internalname = "PROMPT_4";
         imgprompt_5_Internalname = "PROMPT_5";
         imgprompt_11_Internalname = "PROMPT_11";
         subGridausentismos_area_Internalname = "GRIDAUSENTISMOS_AREA";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("IndicadroresPalmas", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridausentismos_area_Allowcollapsing = 0;
         subGridausentismos_area_Allowselection = 0;
         subGridausentismos_area_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Ausentismos";
         edtAusentismosAreaHor_Jsonclick = "";
         edtAusentismosAreaReg_Jsonclick = "";
         edtAusentismosAreaUser_Jsonclick = "";
         edtAusenAreaValor_Jsonclick = "";
         imgprompt_11_Visible = 1;
         imgprompt_11_Link = "";
         imgprompt_4_Visible = 1;
         edtTipoAusen_Codigo_Jsonclick = "";
         edtAusenArea_Fecha_Jsonclick = "";
         subGridausentismos_area_Class = "Grid";
         subGridausentismos_area_Backcolorstyle = 0;
         edtAusentismosAreaHor_Enabled = 1;
         edtAusentismosAreaReg_Enabled = 1;
         edtAusentismosAreaUser_Enabled = 1;
         edtAusenAreaValor_Enabled = 1;
         edtTipoAusen_Codigo_Enabled = 1;
         edtAusenArea_Fecha_Enabled = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtAusentismosHor_Jsonclick = "";
         edtAusentismosHor_Enabled = 1;
         edtAusentismosReg_Jsonclick = "";
         edtAusentismosReg_Enabled = 1;
         edtAusentismosUser_Jsonclick = "";
         edtAusentismosUser_Enabled = 1;
         edtAusen_Valor_Jsonclick = "";
         edtAusen_Valor_Enabled = 1;
         imgprompt_5_Visible = 1;
         imgprompt_5_Link = "";
         edtCod_Area_Jsonclick = "";
         edtCod_Area_Enabled = 1;
         imgprompt_4_Visible = 1;
         imgprompt_4_Link = "";
         edtIndicadoresCodigo_Jsonclick = "";
         edtIndicadoresCodigo_Enabled = 1;
         edtAusen_Ano_Jsonclick = "";
         edtAusen_Ano_Enabled = 1;
         edtAusen_Mes_Jsonclick = "";
         edtAusen_Mes_Enabled = 1;
         edtAusen_Fecha_Jsonclick = "";
         edtAusen_Fecha_Enabled = 1;
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

      protected void gxnrGridausentismos_area_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_836( ) ;
         while ( nGXsfl_83_idx <= nRC_GXsfl_83 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal016( ) ;
            standaloneModal016( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow016( ) ;
            nGXsfl_83_idx = (int)(nGXsfl_83_idx+1);
            sGXsfl_83_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_idx), 4, 0), 4, "0");
            SubsflControlProps_836( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridausentismos_areaContainer)) ;
         /* End function gxnrGridausentismos_area_newrow */
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
         /* Using cursor T000126 */
         pr_default.execute(24, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(24) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(24);
         /* Using cursor T000127 */
         pr_default.execute(25, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(25) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(25);
         GX_FocusControl = edtAusen_Valor_Internalname;
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
         /* Using cursor T000126 */
         pr_default.execute(24, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(24) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
         }
         pr_default.close(24);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Cod_area( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T000127 */
         pr_default.execute(25, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(25) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
         }
         pr_default.close(25);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A6Ausen_Valor", StringUtil.LTrim( StringUtil.NToC( A6Ausen_Valor, 15, 2, ".", "")));
         AssignAttri("", false, "A7AusentismosUser", A7AusentismosUser);
         AssignAttri("", false, "A8AusentismosReg", context.localUtil.Format(A8AusentismosReg, "99/99/99"));
         AssignAttri("", false, "A9AusentismosHor", A9AusentismosHor);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z1Ausen_Fecha", context.localUtil.Format(Z1Ausen_Fecha, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z2Ausen_Mes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2Ausen_Mes), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z3Ausen_Ano", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z3Ausen_Ano), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z4IndicadoresCodigo", Z4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "Z5Cod_Area", Z5Cod_Area);
         GxWebStd.gx_hidden_field( context, "Z6Ausen_Valor", StringUtil.LTrim( StringUtil.NToC( Z6Ausen_Valor, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z7AusentismosUser", Z7AusentismosUser);
         GxWebStd.gx_hidden_field( context, "Z8AusentismosReg", context.localUtil.Format(Z8AusentismosReg, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z9AusentismosHor", Z9AusentismosHor);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Tipoausen_codigo( )
      {
         /* Using cursor T000128 */
         pr_default.execute(26, new Object[] {A11TipoAusen_Codigo});
         if ( (pr_default.getStatus(26) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo Ausentismo'.", "ForeignKeyNotFound", 1, "TIPOAUSEN_CODIGO");
            AnyError = 1;
            GX_FocusControl = edtTipoAusen_Codigo_Internalname;
         }
         pr_default.close(26);
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
         setEventMetadata("VALID_AUSEN_FECHA","{handler:'Valid_Ausen_fecha',iparms:[]");
         setEventMetadata("VALID_AUSEN_FECHA",",oparms:[]}");
         setEventMetadata("VALID_AUSEN_MES","{handler:'Valid_Ausen_mes',iparms:[]");
         setEventMetadata("VALID_AUSEN_MES",",oparms:[]}");
         setEventMetadata("VALID_AUSEN_ANO","{handler:'Valid_Ausen_ano',iparms:[]");
         setEventMetadata("VALID_AUSEN_ANO",",oparms:[]}");
         setEventMetadata("VALID_INDICADORESCODIGO","{handler:'Valid_Indicadorescodigo',iparms:[{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:''}]");
         setEventMetadata("VALID_INDICADORESCODIGO",",oparms:[]}");
         setEventMetadata("VALID_COD_AREA","{handler:'Valid_Cod_area',iparms:[{av:'A1Ausen_Fecha',fld:'AUSEN_FECHA',pic:''},{av:'A2Ausen_Mes',fld:'AUSEN_MES',pic:'ZZZ9'},{av:'A3Ausen_Ano',fld:'AUSEN_ANO',pic:'ZZZ9'},{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:''},{av:'A5Cod_Area',fld:'COD_AREA',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_COD_AREA",",oparms:[{av:'A6Ausen_Valor',fld:'AUSEN_VALOR',pic:'ZZZZZZZZZZZ9.99'},{av:'A7AusentismosUser',fld:'AUSENTISMOSUSER',pic:''},{av:'A8AusentismosReg',fld:'AUSENTISMOSREG',pic:''},{av:'A9AusentismosHor',fld:'AUSENTISMOSHOR',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z1Ausen_Fecha'},{av:'Z2Ausen_Mes'},{av:'Z3Ausen_Ano'},{av:'Z4IndicadoresCodigo'},{av:'Z5Cod_Area'},{av:'Z6Ausen_Valor'},{av:'Z7AusentismosUser'},{av:'Z8AusentismosReg'},{av:'Z9AusentismosHor'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_AUSENTISMOSREG","{handler:'Valid_Ausentismosreg',iparms:[]");
         setEventMetadata("VALID_AUSENTISMOSREG",",oparms:[]}");
         setEventMetadata("VALID_AUSENAREA_FECHA","{handler:'Valid_Ausenarea_fecha',iparms:[]");
         setEventMetadata("VALID_AUSENAREA_FECHA",",oparms:[]}");
         setEventMetadata("VALID_TIPOAUSEN_CODIGO","{handler:'Valid_Tipoausen_codigo',iparms:[{av:'A11TipoAusen_Codigo',fld:'TIPOAUSEN_CODIGO',pic:''}]");
         setEventMetadata("VALID_TIPOAUSEN_CODIGO",",oparms:[]}");
         setEventMetadata("VALID_AUSENTISMOSAREAREG","{handler:'Valid_Ausentismosareareg',iparms:[]");
         setEventMetadata("VALID_AUSENTISMOSAREAREG",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Ausentismosareahor',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
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
         pr_default.close(26);
         pr_default.close(4);
         pr_default.close(24);
         pr_default.close(25);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z1Ausen_Fecha = DateTime.MinValue;
         Z4IndicadoresCodigo = "";
         Z5Cod_Area = "";
         Z7AusentismosUser = "";
         Z8AusentismosReg = DateTime.MinValue;
         Z9AusentismosHor = "";
         Z10AusenArea_Fecha = DateTime.MinValue;
         Z11TipoAusen_Codigo = "";
         Z13AusentismosAreaUser = "";
         Z14AusentismosAreaReg = DateTime.MinValue;
         Z15AusentismosAreaHor = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A4IndicadoresCodigo = "";
         A5Cod_Area = "";
         A11TipoAusen_Codigo = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         Gx_mode = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A1Ausen_Fecha = DateTime.MinValue;
         imgprompt_4_gximage = "";
         sImgUrl = "";
         imgprompt_5_gximage = "";
         A7AusentismosUser = "";
         A8AusentismosReg = DateTime.MinValue;
         A9AusentismosHor = "";
         lblTitlearea_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridausentismos_areaContainer = new GXWebGrid( context);
         sMode6 = "";
         sStyleString = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A10AusenArea_Fecha = DateTime.MinValue;
         A13AusentismosAreaUser = "";
         A14AusentismosAreaReg = DateTime.MinValue;
         A15AusentismosAreaHor = "";
         T00019_A1Ausen_Fecha = new DateTime[] {DateTime.MinValue} ;
         T00019_A2Ausen_Mes = new short[1] ;
         T00019_A3Ausen_Ano = new short[1] ;
         T00019_A6Ausen_Valor = new decimal[1] ;
         T00019_A7AusentismosUser = new string[] {""} ;
         T00019_A8AusentismosReg = new DateTime[] {DateTime.MinValue} ;
         T00019_A9AusentismosHor = new string[] {""} ;
         T00019_A4IndicadoresCodigo = new string[] {""} ;
         T00019_A5Cod_Area = new string[] {""} ;
         T00017_A4IndicadoresCodigo = new string[] {""} ;
         T00018_A5Cod_Area = new string[] {""} ;
         T000110_A4IndicadoresCodigo = new string[] {""} ;
         T000111_A5Cod_Area = new string[] {""} ;
         T000112_A1Ausen_Fecha = new DateTime[] {DateTime.MinValue} ;
         T000112_A2Ausen_Mes = new short[1] ;
         T000112_A3Ausen_Ano = new short[1] ;
         T000112_A4IndicadoresCodigo = new string[] {""} ;
         T000112_A5Cod_Area = new string[] {""} ;
         T00016_A1Ausen_Fecha = new DateTime[] {DateTime.MinValue} ;
         T00016_A2Ausen_Mes = new short[1] ;
         T00016_A3Ausen_Ano = new short[1] ;
         T00016_A6Ausen_Valor = new decimal[1] ;
         T00016_A7AusentismosUser = new string[] {""} ;
         T00016_A8AusentismosReg = new DateTime[] {DateTime.MinValue} ;
         T00016_A9AusentismosHor = new string[] {""} ;
         T00016_A4IndicadoresCodigo = new string[] {""} ;
         T00016_A5Cod_Area = new string[] {""} ;
         sMode5 = "";
         T000113_A1Ausen_Fecha = new DateTime[] {DateTime.MinValue} ;
         T000113_A2Ausen_Mes = new short[1] ;
         T000113_A3Ausen_Ano = new short[1] ;
         T000113_A4IndicadoresCodigo = new string[] {""} ;
         T000113_A5Cod_Area = new string[] {""} ;
         T000114_A1Ausen_Fecha = new DateTime[] {DateTime.MinValue} ;
         T000114_A2Ausen_Mes = new short[1] ;
         T000114_A3Ausen_Ano = new short[1] ;
         T000114_A4IndicadoresCodigo = new string[] {""} ;
         T000114_A5Cod_Area = new string[] {""} ;
         T00015_A1Ausen_Fecha = new DateTime[] {DateTime.MinValue} ;
         T00015_A2Ausen_Mes = new short[1] ;
         T00015_A3Ausen_Ano = new short[1] ;
         T00015_A6Ausen_Valor = new decimal[1] ;
         T00015_A7AusentismosUser = new string[] {""} ;
         T00015_A8AusentismosReg = new DateTime[] {DateTime.MinValue} ;
         T00015_A9AusentismosHor = new string[] {""} ;
         T00015_A4IndicadoresCodigo = new string[] {""} ;
         T00015_A5Cod_Area = new string[] {""} ;
         T000118_A1Ausen_Fecha = new DateTime[] {DateTime.MinValue} ;
         T000118_A2Ausen_Mes = new short[1] ;
         T000118_A3Ausen_Ano = new short[1] ;
         T000118_A4IndicadoresCodigo = new string[] {""} ;
         T000118_A5Cod_Area = new string[] {""} ;
         T000119_A1Ausen_Fecha = new DateTime[] {DateTime.MinValue} ;
         T000119_A2Ausen_Mes = new short[1] ;
         T000119_A3Ausen_Ano = new short[1] ;
         T000119_A4IndicadoresCodigo = new string[] {""} ;
         T000119_A5Cod_Area = new string[] {""} ;
         T000119_A10AusenArea_Fecha = new DateTime[] {DateTime.MinValue} ;
         T000119_A12AusenAreaValor = new decimal[1] ;
         T000119_A13AusentismosAreaUser = new string[] {""} ;
         T000119_A14AusentismosAreaReg = new DateTime[] {DateTime.MinValue} ;
         T000119_A15AusentismosAreaHor = new string[] {""} ;
         T000119_A11TipoAusen_Codigo = new string[] {""} ;
         T00014_A11TipoAusen_Codigo = new string[] {""} ;
         T000120_A11TipoAusen_Codigo = new string[] {""} ;
         T000121_A1Ausen_Fecha = new DateTime[] {DateTime.MinValue} ;
         T000121_A2Ausen_Mes = new short[1] ;
         T000121_A3Ausen_Ano = new short[1] ;
         T000121_A4IndicadoresCodigo = new string[] {""} ;
         T000121_A5Cod_Area = new string[] {""} ;
         T000121_A10AusenArea_Fecha = new DateTime[] {DateTime.MinValue} ;
         T000121_A11TipoAusen_Codigo = new string[] {""} ;
         T00013_A1Ausen_Fecha = new DateTime[] {DateTime.MinValue} ;
         T00013_A2Ausen_Mes = new short[1] ;
         T00013_A3Ausen_Ano = new short[1] ;
         T00013_A4IndicadoresCodigo = new string[] {""} ;
         T00013_A5Cod_Area = new string[] {""} ;
         T00013_A10AusenArea_Fecha = new DateTime[] {DateTime.MinValue} ;
         T00013_A12AusenAreaValor = new decimal[1] ;
         T00013_A13AusentismosAreaUser = new string[] {""} ;
         T00013_A14AusentismosAreaReg = new DateTime[] {DateTime.MinValue} ;
         T00013_A15AusentismosAreaHor = new string[] {""} ;
         T00013_A11TipoAusen_Codigo = new string[] {""} ;
         T00012_A1Ausen_Fecha = new DateTime[] {DateTime.MinValue} ;
         T00012_A2Ausen_Mes = new short[1] ;
         T00012_A3Ausen_Ano = new short[1] ;
         T00012_A4IndicadoresCodigo = new string[] {""} ;
         T00012_A5Cod_Area = new string[] {""} ;
         T00012_A10AusenArea_Fecha = new DateTime[] {DateTime.MinValue} ;
         T00012_A12AusenAreaValor = new decimal[1] ;
         T00012_A13AusentismosAreaUser = new string[] {""} ;
         T00012_A14AusentismosAreaReg = new DateTime[] {DateTime.MinValue} ;
         T00012_A15AusentismosAreaHor = new string[] {""} ;
         T00012_A11TipoAusen_Codigo = new string[] {""} ;
         T000125_A1Ausen_Fecha = new DateTime[] {DateTime.MinValue} ;
         T000125_A2Ausen_Mes = new short[1] ;
         T000125_A3Ausen_Ano = new short[1] ;
         T000125_A4IndicadoresCodigo = new string[] {""} ;
         T000125_A5Cod_Area = new string[] {""} ;
         T000125_A10AusenArea_Fecha = new DateTime[] {DateTime.MinValue} ;
         T000125_A11TipoAusen_Codigo = new string[] {""} ;
         Gridausentismos_areaRow = new GXWebRow();
         subGridausentismos_area_Linesclass = "";
         ROClassString = "";
         imgprompt_11_gximage = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Gridausentismos_areaColumn = new GXWebColumn();
         T000126_A4IndicadoresCodigo = new string[] {""} ;
         T000127_A5Cod_Area = new string[] {""} ;
         ZZ1Ausen_Fecha = DateTime.MinValue;
         ZZ4IndicadoresCodigo = "";
         ZZ5Cod_Area = "";
         ZZ7AusentismosUser = "";
         ZZ8AusentismosReg = DateTime.MinValue;
         ZZ9AusentismosHor = "";
         T000128_A11TipoAusen_Codigo = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ausentismos__default(),
            new Object[][] {
                new Object[] {
               T00012_A1Ausen_Fecha, T00012_A2Ausen_Mes, T00012_A3Ausen_Ano, T00012_A4IndicadoresCodigo, T00012_A5Cod_Area, T00012_A10AusenArea_Fecha, T00012_A12AusenAreaValor, T00012_A13AusentismosAreaUser, T00012_A14AusentismosAreaReg, T00012_A15AusentismosAreaHor,
               T00012_A11TipoAusen_Codigo
               }
               , new Object[] {
               T00013_A1Ausen_Fecha, T00013_A2Ausen_Mes, T00013_A3Ausen_Ano, T00013_A4IndicadoresCodigo, T00013_A5Cod_Area, T00013_A10AusenArea_Fecha, T00013_A12AusenAreaValor, T00013_A13AusentismosAreaUser, T00013_A14AusentismosAreaReg, T00013_A15AusentismosAreaHor,
               T00013_A11TipoAusen_Codigo
               }
               , new Object[] {
               T00014_A11TipoAusen_Codigo
               }
               , new Object[] {
               T00015_A1Ausen_Fecha, T00015_A2Ausen_Mes, T00015_A3Ausen_Ano, T00015_A6Ausen_Valor, T00015_A7AusentismosUser, T00015_A8AusentismosReg, T00015_A9AusentismosHor, T00015_A4IndicadoresCodigo, T00015_A5Cod_Area
               }
               , new Object[] {
               T00016_A1Ausen_Fecha, T00016_A2Ausen_Mes, T00016_A3Ausen_Ano, T00016_A6Ausen_Valor, T00016_A7AusentismosUser, T00016_A8AusentismosReg, T00016_A9AusentismosHor, T00016_A4IndicadoresCodigo, T00016_A5Cod_Area
               }
               , new Object[] {
               T00017_A4IndicadoresCodigo
               }
               , new Object[] {
               T00018_A5Cod_Area
               }
               , new Object[] {
               T00019_A1Ausen_Fecha, T00019_A2Ausen_Mes, T00019_A3Ausen_Ano, T00019_A6Ausen_Valor, T00019_A7AusentismosUser, T00019_A8AusentismosReg, T00019_A9AusentismosHor, T00019_A4IndicadoresCodigo, T00019_A5Cod_Area
               }
               , new Object[] {
               T000110_A4IndicadoresCodigo
               }
               , new Object[] {
               T000111_A5Cod_Area
               }
               , new Object[] {
               T000112_A1Ausen_Fecha, T000112_A2Ausen_Mes, T000112_A3Ausen_Ano, T000112_A4IndicadoresCodigo, T000112_A5Cod_Area
               }
               , new Object[] {
               T000113_A1Ausen_Fecha, T000113_A2Ausen_Mes, T000113_A3Ausen_Ano, T000113_A4IndicadoresCodigo, T000113_A5Cod_Area
               }
               , new Object[] {
               T000114_A1Ausen_Fecha, T000114_A2Ausen_Mes, T000114_A3Ausen_Ano, T000114_A4IndicadoresCodigo, T000114_A5Cod_Area
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000118_A1Ausen_Fecha, T000118_A2Ausen_Mes, T000118_A3Ausen_Ano, T000118_A4IndicadoresCodigo, T000118_A5Cod_Area
               }
               , new Object[] {
               T000119_A1Ausen_Fecha, T000119_A2Ausen_Mes, T000119_A3Ausen_Ano, T000119_A4IndicadoresCodigo, T000119_A5Cod_Area, T000119_A10AusenArea_Fecha, T000119_A12AusenAreaValor, T000119_A13AusentismosAreaUser, T000119_A14AusentismosAreaReg, T000119_A15AusentismosAreaHor,
               T000119_A11TipoAusen_Codigo
               }
               , new Object[] {
               T000120_A11TipoAusen_Codigo
               }
               , new Object[] {
               T000121_A1Ausen_Fecha, T000121_A2Ausen_Mes, T000121_A3Ausen_Ano, T000121_A4IndicadoresCodigo, T000121_A5Cod_Area, T000121_A10AusenArea_Fecha, T000121_A11TipoAusen_Codigo
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000125_A1Ausen_Fecha, T000125_A2Ausen_Mes, T000125_A3Ausen_Ano, T000125_A4IndicadoresCodigo, T000125_A5Cod_Area, T000125_A10AusenArea_Fecha, T000125_A11TipoAusen_Codigo
               }
               , new Object[] {
               T000126_A4IndicadoresCodigo
               }
               , new Object[] {
               T000127_A5Cod_Area
               }
               , new Object[] {
               T000128_A11TipoAusen_Codigo
               }
            }
         );
      }

      private short nIsMod_6 ;
      private short Z2Ausen_Mes ;
      private short Z3Ausen_Ano ;
      private short nRcdDeleted_6 ;
      private short nRcdExists_6 ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A2Ausen_Mes ;
      private short A3Ausen_Ano ;
      private short nBlankRcdCount6 ;
      private short RcdFound6 ;
      private short nBlankRcdUsr6 ;
      private short GX_JID ;
      private short RcdFound5 ;
      private short nIsDirty_5 ;
      private short Gx_BScreen ;
      private short nIsDirty_6 ;
      private short subGridausentismos_area_Backcolorstyle ;
      private short subGridausentismos_area_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridausentismos_area_Allowselection ;
      private short subGridausentismos_area_Allowhovering ;
      private short subGridausentismos_area_Allowcollapsing ;
      private short subGridausentismos_area_Collapsed ;
      private short ZZ2Ausen_Mes ;
      private short ZZ3Ausen_Ano ;
      private int nRC_GXsfl_83 ;
      private int nGXsfl_83_idx=1 ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtAusen_Fecha_Enabled ;
      private int edtAusen_Mes_Enabled ;
      private int edtAusen_Ano_Enabled ;
      private int edtIndicadoresCodigo_Enabled ;
      private int imgprompt_4_Visible ;
      private int edtCod_Area_Enabled ;
      private int imgprompt_5_Visible ;
      private int edtAusen_Valor_Enabled ;
      private int edtAusentismosUser_Enabled ;
      private int edtAusentismosReg_Enabled ;
      private int edtAusentismosHor_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtAusenArea_Fecha_Enabled ;
      private int edtTipoAusen_Codigo_Enabled ;
      private int edtAusenAreaValor_Enabled ;
      private int edtAusentismosAreaUser_Enabled ;
      private int edtAusentismosAreaReg_Enabled ;
      private int edtAusentismosAreaHor_Enabled ;
      private int fRowAdded ;
      private int subGridausentismos_area_Backcolor ;
      private int subGridausentismos_area_Allbackcolor ;
      private int imgprompt_11_Visible ;
      private int defedtTipoAusen_Codigo_Enabled ;
      private int defedtAusenArea_Fecha_Enabled ;
      private int idxLst ;
      private int subGridausentismos_area_Selectedindex ;
      private int subGridausentismos_area_Selectioncolor ;
      private int subGridausentismos_area_Hoveringcolor ;
      private long GRIDAUSENTISMOS_AREA_nFirstRecordOnPage ;
      private decimal Z6Ausen_Valor ;
      private decimal Z12AusenAreaValor ;
      private decimal A6Ausen_Valor ;
      private decimal A12AusenAreaValor ;
      private decimal ZZ6Ausen_Valor ;
      private string sPrefix ;
      private string sGXsfl_83_idx="0001" ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtAusen_Fecha_Internalname ;
      private string Gx_mode ;
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
      private string edtAusen_Fecha_Jsonclick ;
      private string edtAusen_Mes_Internalname ;
      private string edtAusen_Mes_Jsonclick ;
      private string edtAusen_Ano_Internalname ;
      private string edtAusen_Ano_Jsonclick ;
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
      private string edtAusen_Valor_Internalname ;
      private string edtAusen_Valor_Jsonclick ;
      private string edtAusentismosUser_Internalname ;
      private string edtAusentismosUser_Jsonclick ;
      private string edtAusentismosReg_Internalname ;
      private string edtAusentismosReg_Jsonclick ;
      private string edtAusentismosHor_Internalname ;
      private string edtAusentismosHor_Jsonclick ;
      private string divAreatable_Internalname ;
      private string lblTitlearea_Internalname ;
      private string lblTitlearea_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string sMode6 ;
      private string edtAusenArea_Fecha_Internalname ;
      private string edtTipoAusen_Codigo_Internalname ;
      private string edtAusenAreaValor_Internalname ;
      private string edtAusentismosAreaUser_Internalname ;
      private string edtAusentismosAreaReg_Internalname ;
      private string edtAusentismosAreaHor_Internalname ;
      private string sStyleString ;
      private string subGridausentismos_area_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string sMode5 ;
      private string imgprompt_11_Internalname ;
      private string sGXsfl_83_fel_idx="0001" ;
      private string subGridausentismos_area_Class ;
      private string subGridausentismos_area_Linesclass ;
      private string imgprompt_11_Link ;
      private string ROClassString ;
      private string edtAusenArea_Fecha_Jsonclick ;
      private string edtTipoAusen_Codigo_Jsonclick ;
      private string imgprompt_11_gximage ;
      private string edtAusenAreaValor_Jsonclick ;
      private string edtAusentismosAreaUser_Jsonclick ;
      private string edtAusentismosAreaReg_Jsonclick ;
      private string edtAusentismosAreaHor_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridausentismos_area_Header ;
      private DateTime Z1Ausen_Fecha ;
      private DateTime Z8AusentismosReg ;
      private DateTime Z10AusenArea_Fecha ;
      private DateTime Z14AusentismosAreaReg ;
      private DateTime A1Ausen_Fecha ;
      private DateTime A8AusentismosReg ;
      private DateTime A10AusenArea_Fecha ;
      private DateTime A14AusentismosAreaReg ;
      private DateTime ZZ1Ausen_Fecha ;
      private DateTime ZZ8AusentismosReg ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool bGXsfl_83_Refreshing=false ;
      private string Z4IndicadoresCodigo ;
      private string Z5Cod_Area ;
      private string Z7AusentismosUser ;
      private string Z9AusentismosHor ;
      private string Z11TipoAusen_Codigo ;
      private string Z13AusentismosAreaUser ;
      private string Z15AusentismosAreaHor ;
      private string A4IndicadoresCodigo ;
      private string A5Cod_Area ;
      private string A11TipoAusen_Codigo ;
      private string A7AusentismosUser ;
      private string A9AusentismosHor ;
      private string A13AusentismosAreaUser ;
      private string A15AusentismosAreaHor ;
      private string ZZ4IndicadoresCodigo ;
      private string ZZ5Cod_Area ;
      private string ZZ7AusentismosUser ;
      private string ZZ9AusentismosHor ;
      private GXWebGrid Gridausentismos_areaContainer ;
      private GXWebRow Gridausentismos_areaRow ;
      private GXWebColumn Gridausentismos_areaColumn ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] T00019_A1Ausen_Fecha ;
      private short[] T00019_A2Ausen_Mes ;
      private short[] T00019_A3Ausen_Ano ;
      private decimal[] T00019_A6Ausen_Valor ;
      private string[] T00019_A7AusentismosUser ;
      private DateTime[] T00019_A8AusentismosReg ;
      private string[] T00019_A9AusentismosHor ;
      private string[] T00019_A4IndicadoresCodigo ;
      private string[] T00019_A5Cod_Area ;
      private string[] T00017_A4IndicadoresCodigo ;
      private string[] T00018_A5Cod_Area ;
      private string[] T000110_A4IndicadoresCodigo ;
      private string[] T000111_A5Cod_Area ;
      private DateTime[] T000112_A1Ausen_Fecha ;
      private short[] T000112_A2Ausen_Mes ;
      private short[] T000112_A3Ausen_Ano ;
      private string[] T000112_A4IndicadoresCodigo ;
      private string[] T000112_A5Cod_Area ;
      private DateTime[] T00016_A1Ausen_Fecha ;
      private short[] T00016_A2Ausen_Mes ;
      private short[] T00016_A3Ausen_Ano ;
      private decimal[] T00016_A6Ausen_Valor ;
      private string[] T00016_A7AusentismosUser ;
      private DateTime[] T00016_A8AusentismosReg ;
      private string[] T00016_A9AusentismosHor ;
      private string[] T00016_A4IndicadoresCodigo ;
      private string[] T00016_A5Cod_Area ;
      private DateTime[] T000113_A1Ausen_Fecha ;
      private short[] T000113_A2Ausen_Mes ;
      private short[] T000113_A3Ausen_Ano ;
      private string[] T000113_A4IndicadoresCodigo ;
      private string[] T000113_A5Cod_Area ;
      private DateTime[] T000114_A1Ausen_Fecha ;
      private short[] T000114_A2Ausen_Mes ;
      private short[] T000114_A3Ausen_Ano ;
      private string[] T000114_A4IndicadoresCodigo ;
      private string[] T000114_A5Cod_Area ;
      private DateTime[] T00015_A1Ausen_Fecha ;
      private short[] T00015_A2Ausen_Mes ;
      private short[] T00015_A3Ausen_Ano ;
      private decimal[] T00015_A6Ausen_Valor ;
      private string[] T00015_A7AusentismosUser ;
      private DateTime[] T00015_A8AusentismosReg ;
      private string[] T00015_A9AusentismosHor ;
      private string[] T00015_A4IndicadoresCodigo ;
      private string[] T00015_A5Cod_Area ;
      private DateTime[] T000118_A1Ausen_Fecha ;
      private short[] T000118_A2Ausen_Mes ;
      private short[] T000118_A3Ausen_Ano ;
      private string[] T000118_A4IndicadoresCodigo ;
      private string[] T000118_A5Cod_Area ;
      private DateTime[] T000119_A1Ausen_Fecha ;
      private short[] T000119_A2Ausen_Mes ;
      private short[] T000119_A3Ausen_Ano ;
      private string[] T000119_A4IndicadoresCodigo ;
      private string[] T000119_A5Cod_Area ;
      private DateTime[] T000119_A10AusenArea_Fecha ;
      private decimal[] T000119_A12AusenAreaValor ;
      private string[] T000119_A13AusentismosAreaUser ;
      private DateTime[] T000119_A14AusentismosAreaReg ;
      private string[] T000119_A15AusentismosAreaHor ;
      private string[] T000119_A11TipoAusen_Codigo ;
      private string[] T00014_A11TipoAusen_Codigo ;
      private string[] T000120_A11TipoAusen_Codigo ;
      private DateTime[] T000121_A1Ausen_Fecha ;
      private short[] T000121_A2Ausen_Mes ;
      private short[] T000121_A3Ausen_Ano ;
      private string[] T000121_A4IndicadoresCodigo ;
      private string[] T000121_A5Cod_Area ;
      private DateTime[] T000121_A10AusenArea_Fecha ;
      private string[] T000121_A11TipoAusen_Codigo ;
      private DateTime[] T00013_A1Ausen_Fecha ;
      private short[] T00013_A2Ausen_Mes ;
      private short[] T00013_A3Ausen_Ano ;
      private string[] T00013_A4IndicadoresCodigo ;
      private string[] T00013_A5Cod_Area ;
      private DateTime[] T00013_A10AusenArea_Fecha ;
      private decimal[] T00013_A12AusenAreaValor ;
      private string[] T00013_A13AusentismosAreaUser ;
      private DateTime[] T00013_A14AusentismosAreaReg ;
      private string[] T00013_A15AusentismosAreaHor ;
      private string[] T00013_A11TipoAusen_Codigo ;
      private DateTime[] T00012_A1Ausen_Fecha ;
      private short[] T00012_A2Ausen_Mes ;
      private short[] T00012_A3Ausen_Ano ;
      private string[] T00012_A4IndicadoresCodigo ;
      private string[] T00012_A5Cod_Area ;
      private DateTime[] T00012_A10AusenArea_Fecha ;
      private decimal[] T00012_A12AusenAreaValor ;
      private string[] T00012_A13AusentismosAreaUser ;
      private DateTime[] T00012_A14AusentismosAreaReg ;
      private string[] T00012_A15AusentismosAreaHor ;
      private string[] T00012_A11TipoAusen_Codigo ;
      private DateTime[] T000125_A1Ausen_Fecha ;
      private short[] T000125_A2Ausen_Mes ;
      private short[] T000125_A3Ausen_Ano ;
      private string[] T000125_A4IndicadoresCodigo ;
      private string[] T000125_A5Cod_Area ;
      private DateTime[] T000125_A10AusenArea_Fecha ;
      private string[] T000125_A11TipoAusen_Codigo ;
      private string[] T000126_A4IndicadoresCodigo ;
      private string[] T000127_A5Cod_Area ;
      private string[] T000128_A11TipoAusen_Codigo ;
      private GXWebForm Form ;
   }

   public class ausentismos__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[13])
         ,new UpdateCursor(def[14])
         ,new UpdateCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new UpdateCursor(def[20])
         ,new UpdateCursor(def[21])
         ,new UpdateCursor(def[22])
         ,new ForEachCursor(def[23])
         ,new ForEachCursor(def[24])
         ,new ForEachCursor(def[25])
         ,new ForEachCursor(def[26])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00019;
          prmT00019 = new Object[] {
          new ParDef("@Ausen_Fecha",GXType.Date,8,0) ,
          new ParDef("@Ausen_Mes",GXType.Int16,4,0) ,
          new ParDef("@Ausen_Ano",GXType.Int16,4,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT00017;
          prmT00017 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT00018;
          prmT00018 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000110;
          prmT000110 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000111;
          prmT000111 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000112;
          prmT000112 = new Object[] {
          new ParDef("@Ausen_Fecha",GXType.Date,8,0) ,
          new ParDef("@Ausen_Mes",GXType.Int16,4,0) ,
          new ParDef("@Ausen_Ano",GXType.Int16,4,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT00016;
          prmT00016 = new Object[] {
          new ParDef("@Ausen_Fecha",GXType.Date,8,0) ,
          new ParDef("@Ausen_Mes",GXType.Int16,4,0) ,
          new ParDef("@Ausen_Ano",GXType.Int16,4,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000113;
          prmT000113 = new Object[] {
          new ParDef("@Ausen_Fecha",GXType.Date,8,0) ,
          new ParDef("@Ausen_Mes",GXType.Int16,4,0) ,
          new ParDef("@Ausen_Ano",GXType.Int16,4,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000114;
          prmT000114 = new Object[] {
          new ParDef("@Ausen_Fecha",GXType.Date,8,0) ,
          new ParDef("@Ausen_Mes",GXType.Int16,4,0) ,
          new ParDef("@Ausen_Ano",GXType.Int16,4,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT00015;
          prmT00015 = new Object[] {
          new ParDef("@Ausen_Fecha",GXType.Date,8,0) ,
          new ParDef("@Ausen_Mes",GXType.Int16,4,0) ,
          new ParDef("@Ausen_Ano",GXType.Int16,4,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000115;
          prmT000115 = new Object[] {
          new ParDef("@Ausen_Fecha",GXType.Date,8,0) ,
          new ParDef("@Ausen_Mes",GXType.Int16,4,0) ,
          new ParDef("@Ausen_Ano",GXType.Int16,4,0) ,
          new ParDef("@Ausen_Valor",GXType.Decimal,15,2) ,
          new ParDef("@AusentismosUser",GXType.NVarChar,150,0) ,
          new ParDef("@AusentismosReg",GXType.Date,8,0) ,
          new ParDef("@AusentismosHor",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000116;
          prmT000116 = new Object[] {
          new ParDef("@Ausen_Valor",GXType.Decimal,15,2) ,
          new ParDef("@AusentismosUser",GXType.NVarChar,150,0) ,
          new ParDef("@AusentismosReg",GXType.Date,8,0) ,
          new ParDef("@AusentismosHor",GXType.NVarChar,40,0) ,
          new ParDef("@Ausen_Fecha",GXType.Date,8,0) ,
          new ParDef("@Ausen_Mes",GXType.Int16,4,0) ,
          new ParDef("@Ausen_Ano",GXType.Int16,4,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000117;
          prmT000117 = new Object[] {
          new ParDef("@Ausen_Fecha",GXType.Date,8,0) ,
          new ParDef("@Ausen_Mes",GXType.Int16,4,0) ,
          new ParDef("@Ausen_Ano",GXType.Int16,4,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000118;
          prmT000118 = new Object[] {
          };
          Object[] prmT000119;
          prmT000119 = new Object[] {
          new ParDef("@Ausen_Fecha",GXType.Date,8,0) ,
          new ParDef("@Ausen_Mes",GXType.Int16,4,0) ,
          new ParDef("@Ausen_Ano",GXType.Int16,4,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@AusenArea_Fecha",GXType.Date,8,0) ,
          new ParDef("@TipoAusen_Codigo",GXType.NVarChar,40,0)
          };
          Object[] prmT00014;
          prmT00014 = new Object[] {
          new ParDef("@TipoAusen_Codigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000120;
          prmT000120 = new Object[] {
          new ParDef("@TipoAusen_Codigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000121;
          prmT000121 = new Object[] {
          new ParDef("@Ausen_Fecha",GXType.Date,8,0) ,
          new ParDef("@Ausen_Mes",GXType.Int16,4,0) ,
          new ParDef("@Ausen_Ano",GXType.Int16,4,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@AusenArea_Fecha",GXType.Date,8,0) ,
          new ParDef("@TipoAusen_Codigo",GXType.NVarChar,40,0)
          };
          Object[] prmT00013;
          prmT00013 = new Object[] {
          new ParDef("@Ausen_Fecha",GXType.Date,8,0) ,
          new ParDef("@Ausen_Mes",GXType.Int16,4,0) ,
          new ParDef("@Ausen_Ano",GXType.Int16,4,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@AusenArea_Fecha",GXType.Date,8,0) ,
          new ParDef("@TipoAusen_Codigo",GXType.NVarChar,40,0)
          };
          Object[] prmT00012;
          prmT00012 = new Object[] {
          new ParDef("@Ausen_Fecha",GXType.Date,8,0) ,
          new ParDef("@Ausen_Mes",GXType.Int16,4,0) ,
          new ParDef("@Ausen_Ano",GXType.Int16,4,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@AusenArea_Fecha",GXType.Date,8,0) ,
          new ParDef("@TipoAusen_Codigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000122;
          prmT000122 = new Object[] {
          new ParDef("@Ausen_Fecha",GXType.Date,8,0) ,
          new ParDef("@Ausen_Mes",GXType.Int16,4,0) ,
          new ParDef("@Ausen_Ano",GXType.Int16,4,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@AusenArea_Fecha",GXType.Date,8,0) ,
          new ParDef("@AusenAreaValor",GXType.Decimal,15,2) ,
          new ParDef("@AusentismosAreaUser",GXType.NVarChar,120,0) ,
          new ParDef("@AusentismosAreaReg",GXType.Date,8,0) ,
          new ParDef("@AusentismosAreaHor",GXType.NVarChar,40,0) ,
          new ParDef("@TipoAusen_Codigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000123;
          prmT000123 = new Object[] {
          new ParDef("@AusenAreaValor",GXType.Decimal,15,2) ,
          new ParDef("@AusentismosAreaUser",GXType.NVarChar,120,0) ,
          new ParDef("@AusentismosAreaReg",GXType.Date,8,0) ,
          new ParDef("@AusentismosAreaHor",GXType.NVarChar,40,0) ,
          new ParDef("@Ausen_Fecha",GXType.Date,8,0) ,
          new ParDef("@Ausen_Mes",GXType.Int16,4,0) ,
          new ParDef("@Ausen_Ano",GXType.Int16,4,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@AusenArea_Fecha",GXType.Date,8,0) ,
          new ParDef("@TipoAusen_Codigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000124;
          prmT000124 = new Object[] {
          new ParDef("@Ausen_Fecha",GXType.Date,8,0) ,
          new ParDef("@Ausen_Mes",GXType.Int16,4,0) ,
          new ParDef("@Ausen_Ano",GXType.Int16,4,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@AusenArea_Fecha",GXType.Date,8,0) ,
          new ParDef("@TipoAusen_Codigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000125;
          prmT000125 = new Object[] {
          new ParDef("@Ausen_Fecha",GXType.Date,8,0) ,
          new ParDef("@Ausen_Mes",GXType.Int16,4,0) ,
          new ParDef("@Ausen_Ano",GXType.Int16,4,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000126;
          prmT000126 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000127;
          prmT000127 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000128;
          prmT000128 = new Object[] {
          new ParDef("@TipoAusen_Codigo",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00012", "SELECT [Ausen_Fecha], [Ausen_Mes], [Ausen_Ano], [IndicadoresCodigo], [Cod_Area], [AusenArea_Fecha], [AusenAreaValor], [AusentismosAreaUser], [AusentismosAreaReg], [AusentismosAreaHor], [TipoAusen_Codigo] FROM [AusentismosTipos] WITH (UPDLOCK) WHERE [Ausen_Fecha] = @Ausen_Fecha AND [Ausen_Mes] = @Ausen_Mes AND [Ausen_Ano] = @Ausen_Ano AND [IndicadoresCodigo] = @IndicadoresCodigo AND [Cod_Area] = @Cod_Area AND [AusenArea_Fecha] = @AusenArea_Fecha AND [TipoAusen_Codigo] = @TipoAusen_Codigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT00012,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00013", "SELECT [Ausen_Fecha], [Ausen_Mes], [Ausen_Ano], [IndicadoresCodigo], [Cod_Area], [AusenArea_Fecha], [AusenAreaValor], [AusentismosAreaUser], [AusentismosAreaReg], [AusentismosAreaHor], [TipoAusen_Codigo] FROM [AusentismosTipos] WHERE [Ausen_Fecha] = @Ausen_Fecha AND [Ausen_Mes] = @Ausen_Mes AND [Ausen_Ano] = @Ausen_Ano AND [IndicadoresCodigo] = @IndicadoresCodigo AND [Cod_Area] = @Cod_Area AND [AusenArea_Fecha] = @AusenArea_Fecha AND [TipoAusen_Codigo] = @TipoAusen_Codigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT00013,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00014", "SELECT [TipoAusen_Codigo] FROM [TipoAusentismo] WHERE [TipoAusen_Codigo] = @TipoAusen_Codigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT00014,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00015", "SELECT [Ausen_Fecha], [Ausen_Mes], [Ausen_Ano], [Ausen_Valor], [AusentismosUser], [AusentismosReg], [AusentismosHor], [IndicadoresCodigo], [Cod_Area] FROM [Ausentismos] WITH (UPDLOCK) WHERE [Ausen_Fecha] = @Ausen_Fecha AND [Ausen_Mes] = @Ausen_Mes AND [Ausen_Ano] = @Ausen_Ano AND [IndicadoresCodigo] = @IndicadoresCodigo AND [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT00015,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00016", "SELECT [Ausen_Fecha], [Ausen_Mes], [Ausen_Ano], [Ausen_Valor], [AusentismosUser], [AusentismosReg], [AusentismosHor], [IndicadoresCodigo], [Cod_Area] FROM [Ausentismos] WHERE [Ausen_Fecha] = @Ausen_Fecha AND [Ausen_Mes] = @Ausen_Mes AND [Ausen_Ano] = @Ausen_Ano AND [IndicadoresCodigo] = @IndicadoresCodigo AND [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT00016,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00017", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT00017,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00018", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT00018,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00019", "SELECT TM1.[Ausen_Fecha], TM1.[Ausen_Mes], TM1.[Ausen_Ano], TM1.[Ausen_Valor], TM1.[AusentismosUser], TM1.[AusentismosReg], TM1.[AusentismosHor], TM1.[IndicadoresCodigo], TM1.[Cod_Area] FROM [Ausentismos] TM1 WHERE TM1.[Ausen_Fecha] = @Ausen_Fecha and TM1.[Ausen_Mes] = @Ausen_Mes and TM1.[Ausen_Ano] = @Ausen_Ano and TM1.[IndicadoresCodigo] = @IndicadoresCodigo and TM1.[Cod_Area] = @Cod_Area ORDER BY TM1.[Ausen_Fecha], TM1.[Ausen_Mes], TM1.[Ausen_Ano], TM1.[IndicadoresCodigo], TM1.[Cod_Area]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00019,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000110", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000110,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000111", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000111,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000112", "SELECT [Ausen_Fecha], [Ausen_Mes], [Ausen_Ano], [IndicadoresCodigo], [Cod_Area] FROM [Ausentismos] WHERE [Ausen_Fecha] = @Ausen_Fecha AND [Ausen_Mes] = @Ausen_Mes AND [Ausen_Ano] = @Ausen_Ano AND [IndicadoresCodigo] = @IndicadoresCodigo AND [Cod_Area] = @Cod_Area  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000112,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000113", "SELECT TOP 1 [Ausen_Fecha], [Ausen_Mes], [Ausen_Ano], [IndicadoresCodigo], [Cod_Area] FROM [Ausentismos] WHERE ( [Ausen_Fecha] > @Ausen_Fecha or [Ausen_Fecha] = @Ausen_Fecha and [Ausen_Mes] > @Ausen_Mes or [Ausen_Mes] = @Ausen_Mes and [Ausen_Fecha] = @Ausen_Fecha and [Ausen_Ano] > @Ausen_Ano or [Ausen_Ano] = @Ausen_Ano and [Ausen_Mes] = @Ausen_Mes and [Ausen_Fecha] = @Ausen_Fecha and [IndicadoresCodigo] > @IndicadoresCodigo or [IndicadoresCodigo] = @IndicadoresCodigo and [Ausen_Ano] = @Ausen_Ano and [Ausen_Mes] = @Ausen_Mes and [Ausen_Fecha] = @Ausen_Fecha and [Cod_Area] > @Cod_Area) ORDER BY [Ausen_Fecha], [Ausen_Mes], [Ausen_Ano], [IndicadoresCodigo], [Cod_Area]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000113,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000114", "SELECT TOP 1 [Ausen_Fecha], [Ausen_Mes], [Ausen_Ano], [IndicadoresCodigo], [Cod_Area] FROM [Ausentismos] WHERE ( [Ausen_Fecha] < @Ausen_Fecha or [Ausen_Fecha] = @Ausen_Fecha and [Ausen_Mes] < @Ausen_Mes or [Ausen_Mes] = @Ausen_Mes and [Ausen_Fecha] = @Ausen_Fecha and [Ausen_Ano] < @Ausen_Ano or [Ausen_Ano] = @Ausen_Ano and [Ausen_Mes] = @Ausen_Mes and [Ausen_Fecha] = @Ausen_Fecha and [IndicadoresCodigo] < @IndicadoresCodigo or [IndicadoresCodigo] = @IndicadoresCodigo and [Ausen_Ano] = @Ausen_Ano and [Ausen_Mes] = @Ausen_Mes and [Ausen_Fecha] = @Ausen_Fecha and [Cod_Area] < @Cod_Area) ORDER BY [Ausen_Fecha] DESC, [Ausen_Mes] DESC, [Ausen_Ano] DESC, [IndicadoresCodigo] DESC, [Cod_Area] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000114,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000115", "INSERT INTO [Ausentismos]([Ausen_Fecha], [Ausen_Mes], [Ausen_Ano], [Ausen_Valor], [AusentismosUser], [AusentismosReg], [AusentismosHor], [IndicadoresCodigo], [Cod_Area]) VALUES(@Ausen_Fecha, @Ausen_Mes, @Ausen_Ano, @Ausen_Valor, @AusentismosUser, @AusentismosReg, @AusentismosHor, @IndicadoresCodigo, @Cod_Area)", GxErrorMask.GX_NOMASK,prmT000115)
             ,new CursorDef("T000116", "UPDATE [Ausentismos] SET [Ausen_Valor]=@Ausen_Valor, [AusentismosUser]=@AusentismosUser, [AusentismosReg]=@AusentismosReg, [AusentismosHor]=@AusentismosHor  WHERE [Ausen_Fecha] = @Ausen_Fecha AND [Ausen_Mes] = @Ausen_Mes AND [Ausen_Ano] = @Ausen_Ano AND [IndicadoresCodigo] = @IndicadoresCodigo AND [Cod_Area] = @Cod_Area", GxErrorMask.GX_NOMASK,prmT000116)
             ,new CursorDef("T000117", "DELETE FROM [Ausentismos]  WHERE [Ausen_Fecha] = @Ausen_Fecha AND [Ausen_Mes] = @Ausen_Mes AND [Ausen_Ano] = @Ausen_Ano AND [IndicadoresCodigo] = @IndicadoresCodigo AND [Cod_Area] = @Cod_Area", GxErrorMask.GX_NOMASK,prmT000117)
             ,new CursorDef("T000118", "SELECT [Ausen_Fecha], [Ausen_Mes], [Ausen_Ano], [IndicadoresCodigo], [Cod_Area] FROM [Ausentismos] ORDER BY [Ausen_Fecha], [Ausen_Mes], [Ausen_Ano], [IndicadoresCodigo], [Cod_Area]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000118,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000119", "SELECT [Ausen_Fecha], [Ausen_Mes], [Ausen_Ano], [IndicadoresCodigo], [Cod_Area], [AusenArea_Fecha], [AusenAreaValor], [AusentismosAreaUser], [AusentismosAreaReg], [AusentismosAreaHor], [TipoAusen_Codigo] FROM [AusentismosTipos] WHERE [Ausen_Fecha] = @Ausen_Fecha and [Ausen_Mes] = @Ausen_Mes and [Ausen_Ano] = @Ausen_Ano and [IndicadoresCodigo] = @IndicadoresCodigo and [Cod_Area] = @Cod_Area and [AusenArea_Fecha] = @AusenArea_Fecha and [TipoAusen_Codigo] = @TipoAusen_Codigo ORDER BY [Ausen_Fecha], [Ausen_Mes], [Ausen_Ano], [IndicadoresCodigo], [Cod_Area], [AusenArea_Fecha], [TipoAusen_Codigo] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000119,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000120", "SELECT [TipoAusen_Codigo] FROM [TipoAusentismo] WHERE [TipoAusen_Codigo] = @TipoAusen_Codigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000120,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000121", "SELECT [Ausen_Fecha], [Ausen_Mes], [Ausen_Ano], [IndicadoresCodigo], [Cod_Area], [AusenArea_Fecha], [TipoAusen_Codigo] FROM [AusentismosTipos] WHERE [Ausen_Fecha] = @Ausen_Fecha AND [Ausen_Mes] = @Ausen_Mes AND [Ausen_Ano] = @Ausen_Ano AND [IndicadoresCodigo] = @IndicadoresCodigo AND [Cod_Area] = @Cod_Area AND [AusenArea_Fecha] = @AusenArea_Fecha AND [TipoAusen_Codigo] = @TipoAusen_Codigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000121,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000122", "INSERT INTO [AusentismosTipos]([Ausen_Fecha], [Ausen_Mes], [Ausen_Ano], [IndicadoresCodigo], [Cod_Area], [AusenArea_Fecha], [AusenAreaValor], [AusentismosAreaUser], [AusentismosAreaReg], [AusentismosAreaHor], [TipoAusen_Codigo]) VALUES(@Ausen_Fecha, @Ausen_Mes, @Ausen_Ano, @IndicadoresCodigo, @Cod_Area, @AusenArea_Fecha, @AusenAreaValor, @AusentismosAreaUser, @AusentismosAreaReg, @AusentismosAreaHor, @TipoAusen_Codigo)", GxErrorMask.GX_NOMASK,prmT000122)
             ,new CursorDef("T000123", "UPDATE [AusentismosTipos] SET [AusenAreaValor]=@AusenAreaValor, [AusentismosAreaUser]=@AusentismosAreaUser, [AusentismosAreaReg]=@AusentismosAreaReg, [AusentismosAreaHor]=@AusentismosAreaHor  WHERE [Ausen_Fecha] = @Ausen_Fecha AND [Ausen_Mes] = @Ausen_Mes AND [Ausen_Ano] = @Ausen_Ano AND [IndicadoresCodigo] = @IndicadoresCodigo AND [Cod_Area] = @Cod_Area AND [AusenArea_Fecha] = @AusenArea_Fecha AND [TipoAusen_Codigo] = @TipoAusen_Codigo", GxErrorMask.GX_NOMASK,prmT000123)
             ,new CursorDef("T000124", "DELETE FROM [AusentismosTipos]  WHERE [Ausen_Fecha] = @Ausen_Fecha AND [Ausen_Mes] = @Ausen_Mes AND [Ausen_Ano] = @Ausen_Ano AND [IndicadoresCodigo] = @IndicadoresCodigo AND [Cod_Area] = @Cod_Area AND [AusenArea_Fecha] = @AusenArea_Fecha AND [TipoAusen_Codigo] = @TipoAusen_Codigo", GxErrorMask.GX_NOMASK,prmT000124)
             ,new CursorDef("T000125", "SELECT [Ausen_Fecha], [Ausen_Mes], [Ausen_Ano], [IndicadoresCodigo], [Cod_Area], [AusenArea_Fecha], [TipoAusen_Codigo] FROM [AusentismosTipos] WHERE [Ausen_Fecha] = @Ausen_Fecha and [Ausen_Mes] = @Ausen_Mes and [Ausen_Ano] = @Ausen_Ano and [IndicadoresCodigo] = @IndicadoresCodigo and [Cod_Area] = @Cod_Area ORDER BY [Ausen_Fecha], [Ausen_Mes], [Ausen_Ano], [IndicadoresCodigo], [Cod_Area], [AusenArea_Fecha], [TipoAusen_Codigo] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000125,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000126", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000126,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000127", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000127,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000128", "SELECT [TipoAusen_Codigo] FROM [TipoAusentismo] WHERE [TipoAusen_Codigo] = @TipoAusen_Codigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000128,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                return;
             case 1 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 3 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                return;
             case 4 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
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
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 10 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 11 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 12 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 16 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 17 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                return;
             case 18 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 19 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                return;
             case 23 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                return;
             case 24 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 25 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 26 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
       }
    }

 }

}
