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
   public class acidez : GXDataArea
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
            Form.Meta.addItem("description", "Acidez", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtAcidezFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("IndicadroresPalmas", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public acidez( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("IndicadroresPalmas", true);
      }

      public acidez( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Acidez", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Acidez.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Acidez.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Acidez.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Acidez.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Acidez.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 4, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx00o0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"ACIDEZFECHA"+"'), id:'"+"ACIDEZFECHA"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"ACIDEZMES"+"'), id:'"+"ACIDEZMES"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"ACIDEZANO"+"'), id:'"+"ACIDEZANO"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"COD_AREA"+"'), id:'"+"COD_AREA"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"INDICADORESCODIGO"+"'), id:'"+"INDICADORESCODIGO"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_Acidez.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAcidezFecha_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAcidezFecha_Internalname, "Fecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtAcidezFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtAcidezFecha_Internalname, context.localUtil.Format(A50AcidezFecha, "99/99/99"), context.localUtil.Format( A50AcidezFecha, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAcidezFecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAcidezFecha_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Acidez.htm");
         GxWebStd.gx_bitmap( context, edtAcidezFecha_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtAcidezFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Acidez.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAcidezMes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAcidezMes_Internalname, "Mes", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAcidezMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A51AcidezMes), 4, 0, ",", "")), StringUtil.LTrim( ((edtAcidezMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A51AcidezMes), "ZZZ9") : context.localUtil.Format( (decimal)(A51AcidezMes), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAcidezMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAcidezMes_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Acidez.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAcidezAno_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAcidezAno_Internalname, "Ano", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAcidezAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A52AcidezAno), 4, 0, ",", "")), StringUtil.LTrim( ((edtAcidezAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A52AcidezAno), "ZZZ9") : context.localUtil.Format( (decimal)(A52AcidezAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAcidezAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAcidezAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Acidez.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCod_Area_Internalname, A5Cod_Area, StringUtil.RTrim( context.localUtil.Format( A5Cod_Area, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCod_Area_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCod_Area_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Acidez.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_5_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_5_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_5_Internalname, sImgUrl, imgprompt_5_Link, "", "", context.GetTheme( ), imgprompt_5_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Acidez.htm");
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
         GxWebStd.gx_single_line_edit( context, edtIndicadoresCodigo_Internalname, A4IndicadoresCodigo, StringUtil.RTrim( context.localUtil.Format( A4IndicadoresCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIndicadoresCodigo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIndicadoresCodigo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Acidez.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_4_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_4_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_4_Internalname, sImgUrl, imgprompt_4_Link, "", "", context.GetTheme( ), imgprompt_4_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Acidez.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAcidezValor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAcidezValor_Internalname, "Valor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAcidezValor_Internalname, StringUtil.LTrim( StringUtil.NToC( A163AcidezValor, 10, 5, ",", "")), StringUtil.LTrim( ((edtAcidezValor_Enabled!=0) ? context.localUtil.Format( A163AcidezValor, "ZZZ9.99999") : context.localUtil.Format( A163AcidezValor, "ZZZ9.99999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','5');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','5');"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAcidezValor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAcidezValor_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Acidez.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAcidezUser_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAcidezUser_Internalname, "User", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtAcidezUser_Internalname, A164AcidezUser, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", 0, 1, edtAcidezUser_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Acidez.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAcidezReg_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAcidezReg_Internalname, "Reg", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtAcidezReg_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtAcidezReg_Internalname, context.localUtil.Format(A165AcidezReg, "99/99/99"), context.localUtil.Format( A165AcidezReg, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAcidezReg_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAcidezReg_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Acidez.htm");
         GxWebStd.gx_bitmap( context, edtAcidezReg_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtAcidezReg_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Acidez.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAcidezHora_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAcidezHora_Internalname, "Hora", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAcidezHora_Internalname, A166AcidezHora, StringUtil.RTrim( context.localUtil.Format( A166AcidezHora, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAcidezHora_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAcidezHora_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Acidez.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Acidez.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Acidez.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Acidez.htm");
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
            Z50AcidezFecha = context.localUtil.CToD( cgiGet( "Z50AcidezFecha"), 0);
            Z51AcidezMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z51AcidezMes"), ",", "."), 18, MidpointRounding.ToEven));
            Z52AcidezAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z52AcidezAno"), ",", "."), 18, MidpointRounding.ToEven));
            Z5Cod_Area = cgiGet( "Z5Cod_Area");
            Z4IndicadoresCodigo = cgiGet( "Z4IndicadoresCodigo");
            Z163AcidezValor = context.localUtil.CToN( cgiGet( "Z163AcidezValor"), ",", ".");
            Z164AcidezUser = cgiGet( "Z164AcidezUser");
            Z165AcidezReg = context.localUtil.CToD( cgiGet( "Z165AcidezReg"), 0);
            Z166AcidezHora = cgiGet( "Z166AcidezHora");
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( context.localUtil.VCDate( cgiGet( edtAcidezFecha_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Acidez Fecha"}), 1, "ACIDEZFECHA");
               AnyError = 1;
               GX_FocusControl = edtAcidezFecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A50AcidezFecha = DateTime.MinValue;
               AssignAttri("", false, "A50AcidezFecha", context.localUtil.Format(A50AcidezFecha, "99/99/99"));
            }
            else
            {
               A50AcidezFecha = context.localUtil.CToD( cgiGet( edtAcidezFecha_Internalname), 2);
               AssignAttri("", false, "A50AcidezFecha", context.localUtil.Format(A50AcidezFecha, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtAcidezMes_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAcidezMes_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACIDEZMES");
               AnyError = 1;
               GX_FocusControl = edtAcidezMes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A51AcidezMes = 0;
               AssignAttri("", false, "A51AcidezMes", StringUtil.LTrimStr( (decimal)(A51AcidezMes), 4, 0));
            }
            else
            {
               A51AcidezMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtAcidezMes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A51AcidezMes", StringUtil.LTrimStr( (decimal)(A51AcidezMes), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtAcidezAno_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAcidezAno_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACIDEZANO");
               AnyError = 1;
               GX_FocusControl = edtAcidezAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A52AcidezAno = 0;
               AssignAttri("", false, "A52AcidezAno", StringUtil.LTrimStr( (decimal)(A52AcidezAno), 4, 0));
            }
            else
            {
               A52AcidezAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtAcidezAno_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A52AcidezAno", StringUtil.LTrimStr( (decimal)(A52AcidezAno), 4, 0));
            }
            A5Cod_Area = cgiGet( edtCod_Area_Internalname);
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = cgiGet( edtIndicadoresCodigo_Internalname);
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            if ( ( ( context.localUtil.CToN( cgiGet( edtAcidezValor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAcidezValor_Internalname), ",", ".") > 9999.99999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACIDEZVALOR");
               AnyError = 1;
               GX_FocusControl = edtAcidezValor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A163AcidezValor = 0;
               AssignAttri("", false, "A163AcidezValor", StringUtil.LTrimStr( A163AcidezValor, 10, 5));
            }
            else
            {
               A163AcidezValor = context.localUtil.CToN( cgiGet( edtAcidezValor_Internalname), ",", ".");
               AssignAttri("", false, "A163AcidezValor", StringUtil.LTrimStr( A163AcidezValor, 10, 5));
            }
            A164AcidezUser = cgiGet( edtAcidezUser_Internalname);
            AssignAttri("", false, "A164AcidezUser", A164AcidezUser);
            if ( context.localUtil.VCDate( cgiGet( edtAcidezReg_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Acidez Reg"}), 1, "ACIDEZREG");
               AnyError = 1;
               GX_FocusControl = edtAcidezReg_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A165AcidezReg = DateTime.MinValue;
               AssignAttri("", false, "A165AcidezReg", context.localUtil.Format(A165AcidezReg, "99/99/99"));
            }
            else
            {
               A165AcidezReg = context.localUtil.CToD( cgiGet( edtAcidezReg_Internalname), 2);
               AssignAttri("", false, "A165AcidezReg", context.localUtil.Format(A165AcidezReg, "99/99/99"));
            }
            A166AcidezHora = cgiGet( edtAcidezHora_Internalname);
            AssignAttri("", false, "A166AcidezHora", A166AcidezHora);
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
               A50AcidezFecha = context.localUtil.ParseDateParm( GetPar( "AcidezFecha"));
               AssignAttri("", false, "A50AcidezFecha", context.localUtil.Format(A50AcidezFecha, "99/99/99"));
               A51AcidezMes = (short)(Math.Round(NumberUtil.Val( GetPar( "AcidezMes"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A51AcidezMes", StringUtil.LTrimStr( (decimal)(A51AcidezMes), 4, 0));
               A52AcidezAno = (short)(Math.Round(NumberUtil.Val( GetPar( "AcidezAno"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A52AcidezAno", StringUtil.LTrimStr( (decimal)(A52AcidezAno), 4, 0));
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
               InitAll0N24( ) ;
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
         DisableAttributes0N24( ) ;
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

      protected void ResetCaption0N0( )
      {
      }

      protected void ZM0N24( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z163AcidezValor = T000N3_A163AcidezValor[0];
               Z164AcidezUser = T000N3_A164AcidezUser[0];
               Z165AcidezReg = T000N3_A165AcidezReg[0];
               Z166AcidezHora = T000N3_A166AcidezHora[0];
            }
            else
            {
               Z163AcidezValor = A163AcidezValor;
               Z164AcidezUser = A164AcidezUser;
               Z165AcidezReg = A165AcidezReg;
               Z166AcidezHora = A166AcidezHora;
            }
         }
         if ( GX_JID == -3 )
         {
            Z50AcidezFecha = A50AcidezFecha;
            Z51AcidezMes = A51AcidezMes;
            Z52AcidezAno = A52AcidezAno;
            Z163AcidezValor = A163AcidezValor;
            Z164AcidezUser = A164AcidezUser;
            Z165AcidezReg = A165AcidezReg;
            Z166AcidezHora = A166AcidezHora;
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

      protected void Load0N24( )
      {
         /* Using cursor T000N6 */
         pr_default.execute(4, new Object[] {A50AcidezFecha, A51AcidezMes, A52AcidezAno, A5Cod_Area, A4IndicadoresCodigo});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound24 = 1;
            A163AcidezValor = T000N6_A163AcidezValor[0];
            AssignAttri("", false, "A163AcidezValor", StringUtil.LTrimStr( A163AcidezValor, 10, 5));
            A164AcidezUser = T000N6_A164AcidezUser[0];
            AssignAttri("", false, "A164AcidezUser", A164AcidezUser);
            A165AcidezReg = T000N6_A165AcidezReg[0];
            AssignAttri("", false, "A165AcidezReg", context.localUtil.Format(A165AcidezReg, "99/99/99"));
            A166AcidezHora = T000N6_A166AcidezHora[0];
            AssignAttri("", false, "A166AcidezHora", A166AcidezHora);
            ZM0N24( -3) ;
         }
         pr_default.close(4);
         OnLoadActions0N24( ) ;
      }

      protected void OnLoadActions0N24( )
      {
      }

      protected void CheckExtendedTable0N24( )
      {
         nIsDirty_24 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A50AcidezFecha) || ( DateTimeUtil.ResetTime ( A50AcidezFecha ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Acidez Fecha fuera de rango", "OutOfRange", 1, "ACIDEZFECHA");
            AnyError = 1;
            GX_FocusControl = edtAcidezFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000N4 */
         pr_default.execute(2, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T000N5 */
         pr_default.execute(3, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         if ( ! ( (DateTime.MinValue==A165AcidezReg) || ( DateTimeUtil.ResetTime ( A165AcidezReg ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Acidez Reg fuera de rango", "OutOfRange", 1, "ACIDEZREG");
            AnyError = 1;
            GX_FocusControl = edtAcidezReg_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0N24( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_4( string A5Cod_Area )
      {
         /* Using cursor T000N7 */
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
         /* Using cursor T000N8 */
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

      protected void GetKey0N24( )
      {
         /* Using cursor T000N9 */
         pr_default.execute(7, new Object[] {A50AcidezFecha, A51AcidezMes, A52AcidezAno, A5Cod_Area, A4IndicadoresCodigo});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound24 = 1;
         }
         else
         {
            RcdFound24 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000N3 */
         pr_default.execute(1, new Object[] {A50AcidezFecha, A51AcidezMes, A52AcidezAno, A5Cod_Area, A4IndicadoresCodigo});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0N24( 3) ;
            RcdFound24 = 1;
            A50AcidezFecha = T000N3_A50AcidezFecha[0];
            AssignAttri("", false, "A50AcidezFecha", context.localUtil.Format(A50AcidezFecha, "99/99/99"));
            A51AcidezMes = T000N3_A51AcidezMes[0];
            AssignAttri("", false, "A51AcidezMes", StringUtil.LTrimStr( (decimal)(A51AcidezMes), 4, 0));
            A52AcidezAno = T000N3_A52AcidezAno[0];
            AssignAttri("", false, "A52AcidezAno", StringUtil.LTrimStr( (decimal)(A52AcidezAno), 4, 0));
            A163AcidezValor = T000N3_A163AcidezValor[0];
            AssignAttri("", false, "A163AcidezValor", StringUtil.LTrimStr( A163AcidezValor, 10, 5));
            A164AcidezUser = T000N3_A164AcidezUser[0];
            AssignAttri("", false, "A164AcidezUser", A164AcidezUser);
            A165AcidezReg = T000N3_A165AcidezReg[0];
            AssignAttri("", false, "A165AcidezReg", context.localUtil.Format(A165AcidezReg, "99/99/99"));
            A166AcidezHora = T000N3_A166AcidezHora[0];
            AssignAttri("", false, "A166AcidezHora", A166AcidezHora);
            A5Cod_Area = T000N3_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = T000N3_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            Z50AcidezFecha = A50AcidezFecha;
            Z51AcidezMes = A51AcidezMes;
            Z52AcidezAno = A52AcidezAno;
            Z5Cod_Area = A5Cod_Area;
            Z4IndicadoresCodigo = A4IndicadoresCodigo;
            sMode24 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0N24( ) ;
            if ( AnyError == 1 )
            {
               RcdFound24 = 0;
               InitializeNonKey0N24( ) ;
            }
            Gx_mode = sMode24;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound24 = 0;
            InitializeNonKey0N24( ) ;
            sMode24 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode24;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0N24( ) ;
         if ( RcdFound24 == 0 )
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
         RcdFound24 = 0;
         /* Using cursor T000N10 */
         pr_default.execute(8, new Object[] {A50AcidezFecha, A51AcidezMes, A52AcidezAno, A5Cod_Area, A4IndicadoresCodigo});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( DateTimeUtil.ResetTime ( T000N10_A50AcidezFecha[0] ) < DateTimeUtil.ResetTime ( A50AcidezFecha ) ) || ( DateTimeUtil.ResetTime ( T000N10_A50AcidezFecha[0] ) == DateTimeUtil.ResetTime ( A50AcidezFecha ) ) && ( T000N10_A51AcidezMes[0] < A51AcidezMes ) || ( T000N10_A51AcidezMes[0] == A51AcidezMes ) && ( DateTimeUtil.ResetTime ( T000N10_A50AcidezFecha[0] ) == DateTimeUtil.ResetTime ( A50AcidezFecha ) ) && ( T000N10_A52AcidezAno[0] < A52AcidezAno ) || ( T000N10_A52AcidezAno[0] == A52AcidezAno ) && ( T000N10_A51AcidezMes[0] == A51AcidezMes ) && ( DateTimeUtil.ResetTime ( T000N10_A50AcidezFecha[0] ) == DateTimeUtil.ResetTime ( A50AcidezFecha ) ) && ( StringUtil.StrCmp(T000N10_A5Cod_Area[0], A5Cod_Area) < 0 ) || ( StringUtil.StrCmp(T000N10_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000N10_A52AcidezAno[0] == A52AcidezAno ) && ( T000N10_A51AcidezMes[0] == A51AcidezMes ) && ( DateTimeUtil.ResetTime ( T000N10_A50AcidezFecha[0] ) == DateTimeUtil.ResetTime ( A50AcidezFecha ) ) && ( StringUtil.StrCmp(T000N10_A4IndicadoresCodigo[0], A4IndicadoresCodigo) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( DateTimeUtil.ResetTime ( T000N10_A50AcidezFecha[0] ) > DateTimeUtil.ResetTime ( A50AcidezFecha ) ) || ( DateTimeUtil.ResetTime ( T000N10_A50AcidezFecha[0] ) == DateTimeUtil.ResetTime ( A50AcidezFecha ) ) && ( T000N10_A51AcidezMes[0] > A51AcidezMes ) || ( T000N10_A51AcidezMes[0] == A51AcidezMes ) && ( DateTimeUtil.ResetTime ( T000N10_A50AcidezFecha[0] ) == DateTimeUtil.ResetTime ( A50AcidezFecha ) ) && ( T000N10_A52AcidezAno[0] > A52AcidezAno ) || ( T000N10_A52AcidezAno[0] == A52AcidezAno ) && ( T000N10_A51AcidezMes[0] == A51AcidezMes ) && ( DateTimeUtil.ResetTime ( T000N10_A50AcidezFecha[0] ) == DateTimeUtil.ResetTime ( A50AcidezFecha ) ) && ( StringUtil.StrCmp(T000N10_A5Cod_Area[0], A5Cod_Area) > 0 ) || ( StringUtil.StrCmp(T000N10_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000N10_A52AcidezAno[0] == A52AcidezAno ) && ( T000N10_A51AcidezMes[0] == A51AcidezMes ) && ( DateTimeUtil.ResetTime ( T000N10_A50AcidezFecha[0] ) == DateTimeUtil.ResetTime ( A50AcidezFecha ) ) && ( StringUtil.StrCmp(T000N10_A4IndicadoresCodigo[0], A4IndicadoresCodigo) > 0 ) ) )
            {
               A50AcidezFecha = T000N10_A50AcidezFecha[0];
               AssignAttri("", false, "A50AcidezFecha", context.localUtil.Format(A50AcidezFecha, "99/99/99"));
               A51AcidezMes = T000N10_A51AcidezMes[0];
               AssignAttri("", false, "A51AcidezMes", StringUtil.LTrimStr( (decimal)(A51AcidezMes), 4, 0));
               A52AcidezAno = T000N10_A52AcidezAno[0];
               AssignAttri("", false, "A52AcidezAno", StringUtil.LTrimStr( (decimal)(A52AcidezAno), 4, 0));
               A5Cod_Area = T000N10_A5Cod_Area[0];
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               A4IndicadoresCodigo = T000N10_A4IndicadoresCodigo[0];
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               RcdFound24 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound24 = 0;
         /* Using cursor T000N11 */
         pr_default.execute(9, new Object[] {A50AcidezFecha, A51AcidezMes, A52AcidezAno, A5Cod_Area, A4IndicadoresCodigo});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( DateTimeUtil.ResetTime ( T000N11_A50AcidezFecha[0] ) > DateTimeUtil.ResetTime ( A50AcidezFecha ) ) || ( DateTimeUtil.ResetTime ( T000N11_A50AcidezFecha[0] ) == DateTimeUtil.ResetTime ( A50AcidezFecha ) ) && ( T000N11_A51AcidezMes[0] > A51AcidezMes ) || ( T000N11_A51AcidezMes[0] == A51AcidezMes ) && ( DateTimeUtil.ResetTime ( T000N11_A50AcidezFecha[0] ) == DateTimeUtil.ResetTime ( A50AcidezFecha ) ) && ( T000N11_A52AcidezAno[0] > A52AcidezAno ) || ( T000N11_A52AcidezAno[0] == A52AcidezAno ) && ( T000N11_A51AcidezMes[0] == A51AcidezMes ) && ( DateTimeUtil.ResetTime ( T000N11_A50AcidezFecha[0] ) == DateTimeUtil.ResetTime ( A50AcidezFecha ) ) && ( StringUtil.StrCmp(T000N11_A5Cod_Area[0], A5Cod_Area) > 0 ) || ( StringUtil.StrCmp(T000N11_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000N11_A52AcidezAno[0] == A52AcidezAno ) && ( T000N11_A51AcidezMes[0] == A51AcidezMes ) && ( DateTimeUtil.ResetTime ( T000N11_A50AcidezFecha[0] ) == DateTimeUtil.ResetTime ( A50AcidezFecha ) ) && ( StringUtil.StrCmp(T000N11_A4IndicadoresCodigo[0], A4IndicadoresCodigo) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( DateTimeUtil.ResetTime ( T000N11_A50AcidezFecha[0] ) < DateTimeUtil.ResetTime ( A50AcidezFecha ) ) || ( DateTimeUtil.ResetTime ( T000N11_A50AcidezFecha[0] ) == DateTimeUtil.ResetTime ( A50AcidezFecha ) ) && ( T000N11_A51AcidezMes[0] < A51AcidezMes ) || ( T000N11_A51AcidezMes[0] == A51AcidezMes ) && ( DateTimeUtil.ResetTime ( T000N11_A50AcidezFecha[0] ) == DateTimeUtil.ResetTime ( A50AcidezFecha ) ) && ( T000N11_A52AcidezAno[0] < A52AcidezAno ) || ( T000N11_A52AcidezAno[0] == A52AcidezAno ) && ( T000N11_A51AcidezMes[0] == A51AcidezMes ) && ( DateTimeUtil.ResetTime ( T000N11_A50AcidezFecha[0] ) == DateTimeUtil.ResetTime ( A50AcidezFecha ) ) && ( StringUtil.StrCmp(T000N11_A5Cod_Area[0], A5Cod_Area) < 0 ) || ( StringUtil.StrCmp(T000N11_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000N11_A52AcidezAno[0] == A52AcidezAno ) && ( T000N11_A51AcidezMes[0] == A51AcidezMes ) && ( DateTimeUtil.ResetTime ( T000N11_A50AcidezFecha[0] ) == DateTimeUtil.ResetTime ( A50AcidezFecha ) ) && ( StringUtil.StrCmp(T000N11_A4IndicadoresCodigo[0], A4IndicadoresCodigo) < 0 ) ) )
            {
               A50AcidezFecha = T000N11_A50AcidezFecha[0];
               AssignAttri("", false, "A50AcidezFecha", context.localUtil.Format(A50AcidezFecha, "99/99/99"));
               A51AcidezMes = T000N11_A51AcidezMes[0];
               AssignAttri("", false, "A51AcidezMes", StringUtil.LTrimStr( (decimal)(A51AcidezMes), 4, 0));
               A52AcidezAno = T000N11_A52AcidezAno[0];
               AssignAttri("", false, "A52AcidezAno", StringUtil.LTrimStr( (decimal)(A52AcidezAno), 4, 0));
               A5Cod_Area = T000N11_A5Cod_Area[0];
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               A4IndicadoresCodigo = T000N11_A4IndicadoresCodigo[0];
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               RcdFound24 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0N24( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtAcidezFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0N24( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound24 == 1 )
            {
               if ( ( DateTimeUtil.ResetTime ( A50AcidezFecha ) != DateTimeUtil.ResetTime ( Z50AcidezFecha ) ) || ( A51AcidezMes != Z51AcidezMes ) || ( A52AcidezAno != Z52AcidezAno ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) )
               {
                  A50AcidezFecha = Z50AcidezFecha;
                  AssignAttri("", false, "A50AcidezFecha", context.localUtil.Format(A50AcidezFecha, "99/99/99"));
                  A51AcidezMes = Z51AcidezMes;
                  AssignAttri("", false, "A51AcidezMes", StringUtil.LTrimStr( (decimal)(A51AcidezMes), 4, 0));
                  A52AcidezAno = Z52AcidezAno;
                  AssignAttri("", false, "A52AcidezAno", StringUtil.LTrimStr( (decimal)(A52AcidezAno), 4, 0));
                  A5Cod_Area = Z5Cod_Area;
                  AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
                  A4IndicadoresCodigo = Z4IndicadoresCodigo;
                  AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ACIDEZFECHA");
                  AnyError = 1;
                  GX_FocusControl = edtAcidezFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtAcidezFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0N24( ) ;
                  GX_FocusControl = edtAcidezFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( DateTimeUtil.ResetTime ( A50AcidezFecha ) != DateTimeUtil.ResetTime ( Z50AcidezFecha ) ) || ( A51AcidezMes != Z51AcidezMes ) || ( A52AcidezAno != Z52AcidezAno ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtAcidezFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0N24( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ACIDEZFECHA");
                     AnyError = 1;
                     GX_FocusControl = edtAcidezFecha_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtAcidezFecha_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0N24( ) ;
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
         if ( ( DateTimeUtil.ResetTime ( A50AcidezFecha ) != DateTimeUtil.ResetTime ( Z50AcidezFecha ) ) || ( A51AcidezMes != Z51AcidezMes ) || ( A52AcidezAno != Z52AcidezAno ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) )
         {
            A50AcidezFecha = Z50AcidezFecha;
            AssignAttri("", false, "A50AcidezFecha", context.localUtil.Format(A50AcidezFecha, "99/99/99"));
            A51AcidezMes = Z51AcidezMes;
            AssignAttri("", false, "A51AcidezMes", StringUtil.LTrimStr( (decimal)(A51AcidezMes), 4, 0));
            A52AcidezAno = Z52AcidezAno;
            AssignAttri("", false, "A52AcidezAno", StringUtil.LTrimStr( (decimal)(A52AcidezAno), 4, 0));
            A5Cod_Area = Z5Cod_Area;
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = Z4IndicadoresCodigo;
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ACIDEZFECHA");
            AnyError = 1;
            GX_FocusControl = edtAcidezFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtAcidezFecha_Internalname;
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
         if ( RcdFound24 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "ACIDEZFECHA");
            AnyError = 1;
            GX_FocusControl = edtAcidezFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtAcidezValor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0N24( ) ;
         if ( RcdFound24 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAcidezValor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0N24( ) ;
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
         if ( RcdFound24 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAcidezValor_Internalname;
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
         if ( RcdFound24 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAcidezValor_Internalname;
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
         ScanStart0N24( ) ;
         if ( RcdFound24 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound24 != 0 )
            {
               ScanNext0N24( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAcidezValor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0N24( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0N24( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000N2 */
            pr_default.execute(0, new Object[] {A50AcidezFecha, A51AcidezMes, A52AcidezAno, A5Cod_Area, A4IndicadoresCodigo});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Acidez"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z163AcidezValor != T000N2_A163AcidezValor[0] ) || ( StringUtil.StrCmp(Z164AcidezUser, T000N2_A164AcidezUser[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z165AcidezReg ) != DateTimeUtil.ResetTime ( T000N2_A165AcidezReg[0] ) ) || ( StringUtil.StrCmp(Z166AcidezHora, T000N2_A166AcidezHora[0]) != 0 ) )
            {
               if ( Z163AcidezValor != T000N2_A163AcidezValor[0] )
               {
                  GXUtil.WriteLog("acidez:[seudo value changed for attri]"+"AcidezValor");
                  GXUtil.WriteLogRaw("Old: ",Z163AcidezValor);
                  GXUtil.WriteLogRaw("Current: ",T000N2_A163AcidezValor[0]);
               }
               if ( StringUtil.StrCmp(Z164AcidezUser, T000N2_A164AcidezUser[0]) != 0 )
               {
                  GXUtil.WriteLog("acidez:[seudo value changed for attri]"+"AcidezUser");
                  GXUtil.WriteLogRaw("Old: ",Z164AcidezUser);
                  GXUtil.WriteLogRaw("Current: ",T000N2_A164AcidezUser[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z165AcidezReg ) != DateTimeUtil.ResetTime ( T000N2_A165AcidezReg[0] ) )
               {
                  GXUtil.WriteLog("acidez:[seudo value changed for attri]"+"AcidezReg");
                  GXUtil.WriteLogRaw("Old: ",Z165AcidezReg);
                  GXUtil.WriteLogRaw("Current: ",T000N2_A165AcidezReg[0]);
               }
               if ( StringUtil.StrCmp(Z166AcidezHora, T000N2_A166AcidezHora[0]) != 0 )
               {
                  GXUtil.WriteLog("acidez:[seudo value changed for attri]"+"AcidezHora");
                  GXUtil.WriteLogRaw("Old: ",Z166AcidezHora);
                  GXUtil.WriteLogRaw("Current: ",T000N2_A166AcidezHora[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Acidez"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0N24( )
      {
         BeforeValidate0N24( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0N24( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0N24( 0) ;
            CheckOptimisticConcurrency0N24( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0N24( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0N24( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000N12 */
                     pr_default.execute(10, new Object[] {A50AcidezFecha, A51AcidezMes, A52AcidezAno, A163AcidezValor, A164AcidezUser, A165AcidezReg, A166AcidezHora, A5Cod_Area, A4IndicadoresCodigo});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Acidez");
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
                           ResetCaption0N0( ) ;
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
               Load0N24( ) ;
            }
            EndLevel0N24( ) ;
         }
         CloseExtendedTableCursors0N24( ) ;
      }

      protected void Update0N24( )
      {
         BeforeValidate0N24( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0N24( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0N24( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0N24( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0N24( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000N13 */
                     pr_default.execute(11, new Object[] {A163AcidezValor, A164AcidezUser, A165AcidezReg, A166AcidezHora, A50AcidezFecha, A51AcidezMes, A52AcidezAno, A5Cod_Area, A4IndicadoresCodigo});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("Acidez");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Acidez"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0N24( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0N0( ) ;
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
            EndLevel0N24( ) ;
         }
         CloseExtendedTableCursors0N24( ) ;
      }

      protected void DeferredUpdate0N24( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0N24( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0N24( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0N24( ) ;
            AfterConfirm0N24( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0N24( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000N14 */
                  pr_default.execute(12, new Object[] {A50AcidezFecha, A51AcidezMes, A52AcidezAno, A5Cod_Area, A4IndicadoresCodigo});
                  pr_default.close(12);
                  pr_default.SmartCacheProvider.SetUpdated("Acidez");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound24 == 0 )
                        {
                           InitAll0N24( ) ;
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
                        ResetCaption0N0( ) ;
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
         sMode24 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0N24( ) ;
         Gx_mode = sMode24;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0N24( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0N24( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0N24( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("acidez",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0N0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("acidez",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0N24( )
      {
         /* Using cursor T000N15 */
         pr_default.execute(13);
         RcdFound24 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound24 = 1;
            A50AcidezFecha = T000N15_A50AcidezFecha[0];
            AssignAttri("", false, "A50AcidezFecha", context.localUtil.Format(A50AcidezFecha, "99/99/99"));
            A51AcidezMes = T000N15_A51AcidezMes[0];
            AssignAttri("", false, "A51AcidezMes", StringUtil.LTrimStr( (decimal)(A51AcidezMes), 4, 0));
            A52AcidezAno = T000N15_A52AcidezAno[0];
            AssignAttri("", false, "A52AcidezAno", StringUtil.LTrimStr( (decimal)(A52AcidezAno), 4, 0));
            A5Cod_Area = T000N15_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = T000N15_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0N24( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound24 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound24 = 1;
            A50AcidezFecha = T000N15_A50AcidezFecha[0];
            AssignAttri("", false, "A50AcidezFecha", context.localUtil.Format(A50AcidezFecha, "99/99/99"));
            A51AcidezMes = T000N15_A51AcidezMes[0];
            AssignAttri("", false, "A51AcidezMes", StringUtil.LTrimStr( (decimal)(A51AcidezMes), 4, 0));
            A52AcidezAno = T000N15_A52AcidezAno[0];
            AssignAttri("", false, "A52AcidezAno", StringUtil.LTrimStr( (decimal)(A52AcidezAno), 4, 0));
            A5Cod_Area = T000N15_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = T000N15_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
         }
      }

      protected void ScanEnd0N24( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm0N24( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0N24( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0N24( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0N24( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0N24( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0N24( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0N24( )
      {
         edtAcidezFecha_Enabled = 0;
         AssignProp("", false, edtAcidezFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAcidezFecha_Enabled), 5, 0), true);
         edtAcidezMes_Enabled = 0;
         AssignProp("", false, edtAcidezMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAcidezMes_Enabled), 5, 0), true);
         edtAcidezAno_Enabled = 0;
         AssignProp("", false, edtAcidezAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAcidezAno_Enabled), 5, 0), true);
         edtCod_Area_Enabled = 0;
         AssignProp("", false, edtCod_Area_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCod_Area_Enabled), 5, 0), true);
         edtIndicadoresCodigo_Enabled = 0;
         AssignProp("", false, edtIndicadoresCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIndicadoresCodigo_Enabled), 5, 0), true);
         edtAcidezValor_Enabled = 0;
         AssignProp("", false, edtAcidezValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAcidezValor_Enabled), 5, 0), true);
         edtAcidezUser_Enabled = 0;
         AssignProp("", false, edtAcidezUser_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAcidezUser_Enabled), 5, 0), true);
         edtAcidezReg_Enabled = 0;
         AssignProp("", false, edtAcidezReg_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAcidezReg_Enabled), 5, 0), true);
         edtAcidezHora_Enabled = 0;
         AssignProp("", false, edtAcidezHora_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAcidezHora_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0N24( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0N0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("acidez.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z50AcidezFecha", context.localUtil.DToC( Z50AcidezFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z51AcidezMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z51AcidezMes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z52AcidezAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z52AcidezAno), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z5Cod_Area", Z5Cod_Area);
         GxWebStd.gx_hidden_field( context, "Z4IndicadoresCodigo", Z4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "Z163AcidezValor", StringUtil.LTrim( StringUtil.NToC( Z163AcidezValor, 10, 5, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z164AcidezUser", Z164AcidezUser);
         GxWebStd.gx_hidden_field( context, "Z165AcidezReg", context.localUtil.DToC( Z165AcidezReg, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z166AcidezHora", Z166AcidezHora);
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
         return formatLink("acidez.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Acidez" ;
      }

      public override string GetPgmdesc( )
      {
         return "Acidez" ;
      }

      protected void InitializeNonKey0N24( )
      {
         A163AcidezValor = 0;
         AssignAttri("", false, "A163AcidezValor", StringUtil.LTrimStr( A163AcidezValor, 10, 5));
         A164AcidezUser = "";
         AssignAttri("", false, "A164AcidezUser", A164AcidezUser);
         A165AcidezReg = DateTime.MinValue;
         AssignAttri("", false, "A165AcidezReg", context.localUtil.Format(A165AcidezReg, "99/99/99"));
         A166AcidezHora = "";
         AssignAttri("", false, "A166AcidezHora", A166AcidezHora);
         Z163AcidezValor = 0;
         Z164AcidezUser = "";
         Z165AcidezReg = DateTime.MinValue;
         Z166AcidezHora = "";
      }

      protected void InitAll0N24( )
      {
         A50AcidezFecha = DateTime.MinValue;
         AssignAttri("", false, "A50AcidezFecha", context.localUtil.Format(A50AcidezFecha, "99/99/99"));
         A51AcidezMes = 0;
         AssignAttri("", false, "A51AcidezMes", StringUtil.LTrimStr( (decimal)(A51AcidezMes), 4, 0));
         A52AcidezAno = 0;
         AssignAttri("", false, "A52AcidezAno", StringUtil.LTrimStr( (decimal)(A52AcidezAno), 4, 0));
         A5Cod_Area = "";
         AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
         A4IndicadoresCodigo = "";
         AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
         InitializeNonKey0N24( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20247231023276", true, true);
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
         context.AddJavascriptSource("acidez.js", "?20247231023277", false, true);
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
         edtAcidezFecha_Internalname = "ACIDEZFECHA";
         edtAcidezMes_Internalname = "ACIDEZMES";
         edtAcidezAno_Internalname = "ACIDEZANO";
         edtCod_Area_Internalname = "COD_AREA";
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO";
         edtAcidezValor_Internalname = "ACIDEZVALOR";
         edtAcidezUser_Internalname = "ACIDEZUSER";
         edtAcidezReg_Internalname = "ACIDEZREG";
         edtAcidezHora_Internalname = "ACIDEZHORA";
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
         Form.Caption = "Acidez";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtAcidezHora_Jsonclick = "";
         edtAcidezHora_Enabled = 1;
         edtAcidezReg_Jsonclick = "";
         edtAcidezReg_Enabled = 1;
         edtAcidezUser_Enabled = 1;
         edtAcidezValor_Jsonclick = "";
         edtAcidezValor_Enabled = 1;
         imgprompt_4_Visible = 1;
         imgprompt_4_Link = "";
         edtIndicadoresCodigo_Jsonclick = "";
         edtIndicadoresCodigo_Enabled = 1;
         imgprompt_5_Visible = 1;
         imgprompt_5_Link = "";
         edtCod_Area_Jsonclick = "";
         edtCod_Area_Enabled = 1;
         edtAcidezAno_Jsonclick = "";
         edtAcidezAno_Enabled = 1;
         edtAcidezMes_Jsonclick = "";
         edtAcidezMes_Enabled = 1;
         edtAcidezFecha_Jsonclick = "";
         edtAcidezFecha_Enabled = 1;
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
         /* Using cursor T000N16 */
         pr_default.execute(14, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(14);
         /* Using cursor T000N17 */
         pr_default.execute(15, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(15);
         GX_FocusControl = edtAcidezValor_Internalname;
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
         /* Using cursor T000N16 */
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
         /* Using cursor T000N17 */
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
         AssignAttri("", false, "A163AcidezValor", StringUtil.LTrim( StringUtil.NToC( A163AcidezValor, 10, 5, ".", "")));
         AssignAttri("", false, "A164AcidezUser", A164AcidezUser);
         AssignAttri("", false, "A165AcidezReg", context.localUtil.Format(A165AcidezReg, "99/99/99"));
         AssignAttri("", false, "A166AcidezHora", A166AcidezHora);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z50AcidezFecha", context.localUtil.Format(Z50AcidezFecha, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z51AcidezMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z51AcidezMes), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z52AcidezAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z52AcidezAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z5Cod_Area", Z5Cod_Area);
         GxWebStd.gx_hidden_field( context, "Z4IndicadoresCodigo", Z4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "Z163AcidezValor", StringUtil.LTrim( StringUtil.NToC( Z163AcidezValor, 10, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z164AcidezUser", Z164AcidezUser);
         GxWebStd.gx_hidden_field( context, "Z165AcidezReg", context.localUtil.Format(Z165AcidezReg, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z166AcidezHora", Z166AcidezHora);
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
         setEventMetadata("VALID_ACIDEZFECHA","{handler:'Valid_Acidezfecha',iparms:[]");
         setEventMetadata("VALID_ACIDEZFECHA",",oparms:[]}");
         setEventMetadata("VALID_ACIDEZMES","{handler:'Valid_Acidezmes',iparms:[]");
         setEventMetadata("VALID_ACIDEZMES",",oparms:[]}");
         setEventMetadata("VALID_ACIDEZANO","{handler:'Valid_Acidezano',iparms:[]");
         setEventMetadata("VALID_ACIDEZANO",",oparms:[]}");
         setEventMetadata("VALID_COD_AREA","{handler:'Valid_Cod_area',iparms:[{av:'A5Cod_Area',fld:'COD_AREA',pic:''}]");
         setEventMetadata("VALID_COD_AREA",",oparms:[]}");
         setEventMetadata("VALID_INDICADORESCODIGO","{handler:'Valid_Indicadorescodigo',iparms:[{av:'A50AcidezFecha',fld:'ACIDEZFECHA',pic:''},{av:'A51AcidezMes',fld:'ACIDEZMES',pic:'ZZZ9'},{av:'A52AcidezAno',fld:'ACIDEZANO',pic:'ZZZ9'},{av:'A5Cod_Area',fld:'COD_AREA',pic:''},{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_INDICADORESCODIGO",",oparms:[{av:'A163AcidezValor',fld:'ACIDEZVALOR',pic:'ZZZ9.99999'},{av:'A164AcidezUser',fld:'ACIDEZUSER',pic:''},{av:'A165AcidezReg',fld:'ACIDEZREG',pic:''},{av:'A166AcidezHora',fld:'ACIDEZHORA',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z50AcidezFecha'},{av:'Z51AcidezMes'},{av:'Z52AcidezAno'},{av:'Z5Cod_Area'},{av:'Z4IndicadoresCodigo'},{av:'Z163AcidezValor'},{av:'Z164AcidezUser'},{av:'Z165AcidezReg'},{av:'Z166AcidezHora'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_ACIDEZREG","{handler:'Valid_Acidezreg',iparms:[]");
         setEventMetadata("VALID_ACIDEZREG",",oparms:[]}");
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
         Z50AcidezFecha = DateTime.MinValue;
         Z5Cod_Area = "";
         Z4IndicadoresCodigo = "";
         Z164AcidezUser = "";
         Z165AcidezReg = DateTime.MinValue;
         Z166AcidezHora = "";
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
         A50AcidezFecha = DateTime.MinValue;
         imgprompt_5_gximage = "";
         sImgUrl = "";
         imgprompt_4_gximage = "";
         A164AcidezUser = "";
         A165AcidezReg = DateTime.MinValue;
         A166AcidezHora = "";
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
         T000N6_A50AcidezFecha = new DateTime[] {DateTime.MinValue} ;
         T000N6_A51AcidezMes = new short[1] ;
         T000N6_A52AcidezAno = new short[1] ;
         T000N6_A163AcidezValor = new decimal[1] ;
         T000N6_A164AcidezUser = new string[] {""} ;
         T000N6_A165AcidezReg = new DateTime[] {DateTime.MinValue} ;
         T000N6_A166AcidezHora = new string[] {""} ;
         T000N6_A5Cod_Area = new string[] {""} ;
         T000N6_A4IndicadoresCodigo = new string[] {""} ;
         T000N4_A5Cod_Area = new string[] {""} ;
         T000N5_A4IndicadoresCodigo = new string[] {""} ;
         T000N7_A5Cod_Area = new string[] {""} ;
         T000N8_A4IndicadoresCodigo = new string[] {""} ;
         T000N9_A50AcidezFecha = new DateTime[] {DateTime.MinValue} ;
         T000N9_A51AcidezMes = new short[1] ;
         T000N9_A52AcidezAno = new short[1] ;
         T000N9_A5Cod_Area = new string[] {""} ;
         T000N9_A4IndicadoresCodigo = new string[] {""} ;
         T000N3_A50AcidezFecha = new DateTime[] {DateTime.MinValue} ;
         T000N3_A51AcidezMes = new short[1] ;
         T000N3_A52AcidezAno = new short[1] ;
         T000N3_A163AcidezValor = new decimal[1] ;
         T000N3_A164AcidezUser = new string[] {""} ;
         T000N3_A165AcidezReg = new DateTime[] {DateTime.MinValue} ;
         T000N3_A166AcidezHora = new string[] {""} ;
         T000N3_A5Cod_Area = new string[] {""} ;
         T000N3_A4IndicadoresCodigo = new string[] {""} ;
         sMode24 = "";
         T000N10_A50AcidezFecha = new DateTime[] {DateTime.MinValue} ;
         T000N10_A51AcidezMes = new short[1] ;
         T000N10_A52AcidezAno = new short[1] ;
         T000N10_A5Cod_Area = new string[] {""} ;
         T000N10_A4IndicadoresCodigo = new string[] {""} ;
         T000N11_A50AcidezFecha = new DateTime[] {DateTime.MinValue} ;
         T000N11_A51AcidezMes = new short[1] ;
         T000N11_A52AcidezAno = new short[1] ;
         T000N11_A5Cod_Area = new string[] {""} ;
         T000N11_A4IndicadoresCodigo = new string[] {""} ;
         T000N2_A50AcidezFecha = new DateTime[] {DateTime.MinValue} ;
         T000N2_A51AcidezMes = new short[1] ;
         T000N2_A52AcidezAno = new short[1] ;
         T000N2_A163AcidezValor = new decimal[1] ;
         T000N2_A164AcidezUser = new string[] {""} ;
         T000N2_A165AcidezReg = new DateTime[] {DateTime.MinValue} ;
         T000N2_A166AcidezHora = new string[] {""} ;
         T000N2_A5Cod_Area = new string[] {""} ;
         T000N2_A4IndicadoresCodigo = new string[] {""} ;
         T000N15_A50AcidezFecha = new DateTime[] {DateTime.MinValue} ;
         T000N15_A51AcidezMes = new short[1] ;
         T000N15_A52AcidezAno = new short[1] ;
         T000N15_A5Cod_Area = new string[] {""} ;
         T000N15_A4IndicadoresCodigo = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T000N16_A5Cod_Area = new string[] {""} ;
         T000N17_A4IndicadoresCodigo = new string[] {""} ;
         ZZ50AcidezFecha = DateTime.MinValue;
         ZZ5Cod_Area = "";
         ZZ4IndicadoresCodigo = "";
         ZZ164AcidezUser = "";
         ZZ165AcidezReg = DateTime.MinValue;
         ZZ166AcidezHora = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.acidez__default(),
            new Object[][] {
                new Object[] {
               T000N2_A50AcidezFecha, T000N2_A51AcidezMes, T000N2_A52AcidezAno, T000N2_A163AcidezValor, T000N2_A164AcidezUser, T000N2_A165AcidezReg, T000N2_A166AcidezHora, T000N2_A5Cod_Area, T000N2_A4IndicadoresCodigo
               }
               , new Object[] {
               T000N3_A50AcidezFecha, T000N3_A51AcidezMes, T000N3_A52AcidezAno, T000N3_A163AcidezValor, T000N3_A164AcidezUser, T000N3_A165AcidezReg, T000N3_A166AcidezHora, T000N3_A5Cod_Area, T000N3_A4IndicadoresCodigo
               }
               , new Object[] {
               T000N4_A5Cod_Area
               }
               , new Object[] {
               T000N5_A4IndicadoresCodigo
               }
               , new Object[] {
               T000N6_A50AcidezFecha, T000N6_A51AcidezMes, T000N6_A52AcidezAno, T000N6_A163AcidezValor, T000N6_A164AcidezUser, T000N6_A165AcidezReg, T000N6_A166AcidezHora, T000N6_A5Cod_Area, T000N6_A4IndicadoresCodigo
               }
               , new Object[] {
               T000N7_A5Cod_Area
               }
               , new Object[] {
               T000N8_A4IndicadoresCodigo
               }
               , new Object[] {
               T000N9_A50AcidezFecha, T000N9_A51AcidezMes, T000N9_A52AcidezAno, T000N9_A5Cod_Area, T000N9_A4IndicadoresCodigo
               }
               , new Object[] {
               T000N10_A50AcidezFecha, T000N10_A51AcidezMes, T000N10_A52AcidezAno, T000N10_A5Cod_Area, T000N10_A4IndicadoresCodigo
               }
               , new Object[] {
               T000N11_A50AcidezFecha, T000N11_A51AcidezMes, T000N11_A52AcidezAno, T000N11_A5Cod_Area, T000N11_A4IndicadoresCodigo
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000N15_A50AcidezFecha, T000N15_A51AcidezMes, T000N15_A52AcidezAno, T000N15_A5Cod_Area, T000N15_A4IndicadoresCodigo
               }
               , new Object[] {
               T000N16_A5Cod_Area
               }
               , new Object[] {
               T000N17_A4IndicadoresCodigo
               }
            }
         );
      }

      private short Z51AcidezMes ;
      private short Z52AcidezAno ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A51AcidezMes ;
      private short A52AcidezAno ;
      private short GX_JID ;
      private short RcdFound24 ;
      private short nIsDirty_24 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ51AcidezMes ;
      private short ZZ52AcidezAno ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtAcidezFecha_Enabled ;
      private int edtAcidezMes_Enabled ;
      private int edtAcidezAno_Enabled ;
      private int edtCod_Area_Enabled ;
      private int imgprompt_5_Visible ;
      private int edtIndicadoresCodigo_Enabled ;
      private int imgprompt_4_Visible ;
      private int edtAcidezValor_Enabled ;
      private int edtAcidezUser_Enabled ;
      private int edtAcidezReg_Enabled ;
      private int edtAcidezHora_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private decimal Z163AcidezValor ;
      private decimal A163AcidezValor ;
      private decimal ZZ163AcidezValor ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtAcidezFecha_Internalname ;
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
      private string edtAcidezFecha_Jsonclick ;
      private string edtAcidezMes_Internalname ;
      private string edtAcidezMes_Jsonclick ;
      private string edtAcidezAno_Internalname ;
      private string edtAcidezAno_Jsonclick ;
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
      private string edtAcidezValor_Internalname ;
      private string edtAcidezValor_Jsonclick ;
      private string edtAcidezUser_Internalname ;
      private string edtAcidezReg_Internalname ;
      private string edtAcidezReg_Jsonclick ;
      private string edtAcidezHora_Internalname ;
      private string edtAcidezHora_Jsonclick ;
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
      private string sMode24 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z50AcidezFecha ;
      private DateTime Z165AcidezReg ;
      private DateTime A50AcidezFecha ;
      private DateTime A165AcidezReg ;
      private DateTime ZZ50AcidezFecha ;
      private DateTime ZZ165AcidezReg ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string Z5Cod_Area ;
      private string Z4IndicadoresCodigo ;
      private string Z164AcidezUser ;
      private string Z166AcidezHora ;
      private string A5Cod_Area ;
      private string A4IndicadoresCodigo ;
      private string A164AcidezUser ;
      private string A166AcidezHora ;
      private string ZZ5Cod_Area ;
      private string ZZ4IndicadoresCodigo ;
      private string ZZ164AcidezUser ;
      private string ZZ166AcidezHora ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] T000N6_A50AcidezFecha ;
      private short[] T000N6_A51AcidezMes ;
      private short[] T000N6_A52AcidezAno ;
      private decimal[] T000N6_A163AcidezValor ;
      private string[] T000N6_A164AcidezUser ;
      private DateTime[] T000N6_A165AcidezReg ;
      private string[] T000N6_A166AcidezHora ;
      private string[] T000N6_A5Cod_Area ;
      private string[] T000N6_A4IndicadoresCodigo ;
      private string[] T000N4_A5Cod_Area ;
      private string[] T000N5_A4IndicadoresCodigo ;
      private string[] T000N7_A5Cod_Area ;
      private string[] T000N8_A4IndicadoresCodigo ;
      private DateTime[] T000N9_A50AcidezFecha ;
      private short[] T000N9_A51AcidezMes ;
      private short[] T000N9_A52AcidezAno ;
      private string[] T000N9_A5Cod_Area ;
      private string[] T000N9_A4IndicadoresCodigo ;
      private DateTime[] T000N3_A50AcidezFecha ;
      private short[] T000N3_A51AcidezMes ;
      private short[] T000N3_A52AcidezAno ;
      private decimal[] T000N3_A163AcidezValor ;
      private string[] T000N3_A164AcidezUser ;
      private DateTime[] T000N3_A165AcidezReg ;
      private string[] T000N3_A166AcidezHora ;
      private string[] T000N3_A5Cod_Area ;
      private string[] T000N3_A4IndicadoresCodigo ;
      private DateTime[] T000N10_A50AcidezFecha ;
      private short[] T000N10_A51AcidezMes ;
      private short[] T000N10_A52AcidezAno ;
      private string[] T000N10_A5Cod_Area ;
      private string[] T000N10_A4IndicadoresCodigo ;
      private DateTime[] T000N11_A50AcidezFecha ;
      private short[] T000N11_A51AcidezMes ;
      private short[] T000N11_A52AcidezAno ;
      private string[] T000N11_A5Cod_Area ;
      private string[] T000N11_A4IndicadoresCodigo ;
      private DateTime[] T000N2_A50AcidezFecha ;
      private short[] T000N2_A51AcidezMes ;
      private short[] T000N2_A52AcidezAno ;
      private decimal[] T000N2_A163AcidezValor ;
      private string[] T000N2_A164AcidezUser ;
      private DateTime[] T000N2_A165AcidezReg ;
      private string[] T000N2_A166AcidezHora ;
      private string[] T000N2_A5Cod_Area ;
      private string[] T000N2_A4IndicadoresCodigo ;
      private DateTime[] T000N15_A50AcidezFecha ;
      private short[] T000N15_A51AcidezMes ;
      private short[] T000N15_A52AcidezAno ;
      private string[] T000N15_A5Cod_Area ;
      private string[] T000N15_A4IndicadoresCodigo ;
      private string[] T000N16_A5Cod_Area ;
      private string[] T000N17_A4IndicadoresCodigo ;
      private GXWebForm Form ;
   }

   public class acidez__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT000N6;
          prmT000N6 = new Object[] {
          new ParDef("@AcidezFecha",GXType.Date,8,0) ,
          new ParDef("@AcidezMes",GXType.Int16,4,0) ,
          new ParDef("@AcidezAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000N4;
          prmT000N4 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000N5;
          prmT000N5 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000N7;
          prmT000N7 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000N8;
          prmT000N8 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000N9;
          prmT000N9 = new Object[] {
          new ParDef("@AcidezFecha",GXType.Date,8,0) ,
          new ParDef("@AcidezMes",GXType.Int16,4,0) ,
          new ParDef("@AcidezAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000N3;
          prmT000N3 = new Object[] {
          new ParDef("@AcidezFecha",GXType.Date,8,0) ,
          new ParDef("@AcidezMes",GXType.Int16,4,0) ,
          new ParDef("@AcidezAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000N10;
          prmT000N10 = new Object[] {
          new ParDef("@AcidezFecha",GXType.Date,8,0) ,
          new ParDef("@AcidezMes",GXType.Int16,4,0) ,
          new ParDef("@AcidezAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000N11;
          prmT000N11 = new Object[] {
          new ParDef("@AcidezFecha",GXType.Date,8,0) ,
          new ParDef("@AcidezMes",GXType.Int16,4,0) ,
          new ParDef("@AcidezAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000N2;
          prmT000N2 = new Object[] {
          new ParDef("@AcidezFecha",GXType.Date,8,0) ,
          new ParDef("@AcidezMes",GXType.Int16,4,0) ,
          new ParDef("@AcidezAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000N12;
          prmT000N12 = new Object[] {
          new ParDef("@AcidezFecha",GXType.Date,8,0) ,
          new ParDef("@AcidezMes",GXType.Int16,4,0) ,
          new ParDef("@AcidezAno",GXType.Int16,4,0) ,
          new ParDef("@AcidezValor",GXType.Decimal,10,5) ,
          new ParDef("@AcidezUser",GXType.NVarChar,200,0) ,
          new ParDef("@AcidezReg",GXType.Date,8,0) ,
          new ParDef("@AcidezHora",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000N13;
          prmT000N13 = new Object[] {
          new ParDef("@AcidezValor",GXType.Decimal,10,5) ,
          new ParDef("@AcidezUser",GXType.NVarChar,200,0) ,
          new ParDef("@AcidezReg",GXType.Date,8,0) ,
          new ParDef("@AcidezHora",GXType.NVarChar,40,0) ,
          new ParDef("@AcidezFecha",GXType.Date,8,0) ,
          new ParDef("@AcidezMes",GXType.Int16,4,0) ,
          new ParDef("@AcidezAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000N14;
          prmT000N14 = new Object[] {
          new ParDef("@AcidezFecha",GXType.Date,8,0) ,
          new ParDef("@AcidezMes",GXType.Int16,4,0) ,
          new ParDef("@AcidezAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000N15;
          prmT000N15 = new Object[] {
          };
          Object[] prmT000N16;
          prmT000N16 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000N17;
          prmT000N17 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("T000N2", "SELECT [AcidezFecha], [AcidezMes], [AcidezAno], [AcidezValor], [AcidezUser], [AcidezReg], [AcidezHora], [Cod_Area], [IndicadoresCodigo] FROM [Acidez] WITH (UPDLOCK) WHERE [AcidezFecha] = @AcidezFecha AND [AcidezMes] = @AcidezMes AND [AcidezAno] = @AcidezAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000N3", "SELECT [AcidezFecha], [AcidezMes], [AcidezAno], [AcidezValor], [AcidezUser], [AcidezReg], [AcidezHora], [Cod_Area], [IndicadoresCodigo] FROM [Acidez] WHERE [AcidezFecha] = @AcidezFecha AND [AcidezMes] = @AcidezMes AND [AcidezAno] = @AcidezAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000N4", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000N5", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000N6", "SELECT TM1.[AcidezFecha], TM1.[AcidezMes], TM1.[AcidezAno], TM1.[AcidezValor], TM1.[AcidezUser], TM1.[AcidezReg], TM1.[AcidezHora], TM1.[Cod_Area], TM1.[IndicadoresCodigo] FROM [Acidez] TM1 WHERE TM1.[AcidezFecha] = @AcidezFecha and TM1.[AcidezMes] = @AcidezMes and TM1.[AcidezAno] = @AcidezAno and TM1.[Cod_Area] = @Cod_Area and TM1.[IndicadoresCodigo] = @IndicadoresCodigo ORDER BY TM1.[AcidezFecha], TM1.[AcidezMes], TM1.[AcidezAno], TM1.[Cod_Area], TM1.[IndicadoresCodigo]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000N6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000N7", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000N8", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000N9", "SELECT [AcidezFecha], [AcidezMes], [AcidezAno], [Cod_Area], [IndicadoresCodigo] FROM [Acidez] WHERE [AcidezFecha] = @AcidezFecha AND [AcidezMes] = @AcidezMes AND [AcidezAno] = @AcidezAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000N9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000N10", "SELECT TOP 1 [AcidezFecha], [AcidezMes], [AcidezAno], [Cod_Area], [IndicadoresCodigo] FROM [Acidez] WHERE ( [AcidezFecha] > @AcidezFecha or [AcidezFecha] = @AcidezFecha and [AcidezMes] > @AcidezMes or [AcidezMes] = @AcidezMes and [AcidezFecha] = @AcidezFecha and [AcidezAno] > @AcidezAno or [AcidezAno] = @AcidezAno and [AcidezMes] = @AcidezMes and [AcidezFecha] = @AcidezFecha and [Cod_Area] > @Cod_Area or [Cod_Area] = @Cod_Area and [AcidezAno] = @AcidezAno and [AcidezMes] = @AcidezMes and [AcidezFecha] = @AcidezFecha and [IndicadoresCodigo] > @IndicadoresCodigo) ORDER BY [AcidezFecha], [AcidezMes], [AcidezAno], [Cod_Area], [IndicadoresCodigo]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000N10,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000N11", "SELECT TOP 1 [AcidezFecha], [AcidezMes], [AcidezAno], [Cod_Area], [IndicadoresCodigo] FROM [Acidez] WHERE ( [AcidezFecha] < @AcidezFecha or [AcidezFecha] = @AcidezFecha and [AcidezMes] < @AcidezMes or [AcidezMes] = @AcidezMes and [AcidezFecha] = @AcidezFecha and [AcidezAno] < @AcidezAno or [AcidezAno] = @AcidezAno and [AcidezMes] = @AcidezMes and [AcidezFecha] = @AcidezFecha and [Cod_Area] < @Cod_Area or [Cod_Area] = @Cod_Area and [AcidezAno] = @AcidezAno and [AcidezMes] = @AcidezMes and [AcidezFecha] = @AcidezFecha and [IndicadoresCodigo] < @IndicadoresCodigo) ORDER BY [AcidezFecha] DESC, [AcidezMes] DESC, [AcidezAno] DESC, [Cod_Area] DESC, [IndicadoresCodigo] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000N11,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000N12", "INSERT INTO [Acidez]([AcidezFecha], [AcidezMes], [AcidezAno], [AcidezValor], [AcidezUser], [AcidezReg], [AcidezHora], [Cod_Area], [IndicadoresCodigo]) VALUES(@AcidezFecha, @AcidezMes, @AcidezAno, @AcidezValor, @AcidezUser, @AcidezReg, @AcidezHora, @Cod_Area, @IndicadoresCodigo)", GxErrorMask.GX_NOMASK,prmT000N12)
             ,new CursorDef("T000N13", "UPDATE [Acidez] SET [AcidezValor]=@AcidezValor, [AcidezUser]=@AcidezUser, [AcidezReg]=@AcidezReg, [AcidezHora]=@AcidezHora  WHERE [AcidezFecha] = @AcidezFecha AND [AcidezMes] = @AcidezMes AND [AcidezAno] = @AcidezAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo", GxErrorMask.GX_NOMASK,prmT000N13)
             ,new CursorDef("T000N14", "DELETE FROM [Acidez]  WHERE [AcidezFecha] = @AcidezFecha AND [AcidezMes] = @AcidezMes AND [AcidezAno] = @AcidezAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo", GxErrorMask.GX_NOMASK,prmT000N14)
             ,new CursorDef("T000N15", "SELECT [AcidezFecha], [AcidezMes], [AcidezAno], [Cod_Area], [IndicadoresCodigo] FROM [Acidez] ORDER BY [AcidezFecha], [AcidezMes], [AcidezAno], [Cod_Area], [IndicadoresCodigo]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000N15,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000N16", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N16,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000N17", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N17,1, GxCacheFrequency.OFF ,true,false )
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
