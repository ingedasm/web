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
   public class precnetotoncpo : GXDataArea
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
            A67MOTIVOSPRENETCodigo = GetPar( "MOTIVOSPRENETCodigo");
            AssignAttri("", false, "A67MOTIVOSPRENETCodigo", A67MOTIVOSPRENETCodigo);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A67MOTIVOSPRENETCodigo) ;
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
            Form.Meta.addItem("description", "PRECNETOTONCPO", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtPRECNETOTONCPOFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("IndicadroresPalmas", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public precnetotoncpo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("IndicadroresPalmas", true);
      }

      public precnetotoncpo( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "PRECNETOTONCPO", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_PRECNETOTONCPO.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_PRECNETOTONCPO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_PRECNETOTONCPO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_PRECNETOTONCPO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_PRECNETOTONCPO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 4, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx0150.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PRECNETOTONCPOFECHA"+"'), id:'"+"PRECNETOTONCPOFECHA"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"PRECNETOTONCPOMES"+"'), id:'"+"PRECNETOTONCPOMES"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"PRECNETOTONCPOANO"+"'), id:'"+"PRECNETOTONCPOANO"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"COD_AREA"+"'), id:'"+"COD_AREA"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"INDICADORESCODIGO"+"'), id:'"+"INDICADORESCODIGO"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"MOTIVOSPRENETCODIGO"+"'), id:'"+"MOTIVOSPRENETCODIGO"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_PRECNETOTONCPO.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPRECNETOTONCPOFecha_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPRECNETOTONCPOFecha_Internalname, "PRECNETOTONCPOFecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtPRECNETOTONCPOFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPRECNETOTONCPOFecha_Internalname, context.localUtil.Format(A83PRECNETOTONCPOFecha, "99/99/99"), context.localUtil.Format( A83PRECNETOTONCPOFecha, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPRECNETOTONCPOFecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPRECNETOTONCPOFecha_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_PRECNETOTONCPO.htm");
         GxWebStd.gx_bitmap( context, edtPRECNETOTONCPOFecha_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPRECNETOTONCPOFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_PRECNETOTONCPO.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPRECNETOTONCPOMes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPRECNETOTONCPOMes_Internalname, "PRECNETOTONCPOMes", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPRECNETOTONCPOMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A84PRECNETOTONCPOMes), 4, 0, ",", "")), StringUtil.LTrim( ((edtPRECNETOTONCPOMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A84PRECNETOTONCPOMes), "ZZZ9") : context.localUtil.Format( (decimal)(A84PRECNETOTONCPOMes), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPRECNETOTONCPOMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPRECNETOTONCPOMes_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_PRECNETOTONCPO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPRECNETOTONCPOAno_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPRECNETOTONCPOAno_Internalname, "PRECNETOTONCPOAno", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPRECNETOTONCPOAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A85PRECNETOTONCPOAno), 4, 0, ",", "")), StringUtil.LTrim( ((edtPRECNETOTONCPOAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A85PRECNETOTONCPOAno), "ZZZ9") : context.localUtil.Format( (decimal)(A85PRECNETOTONCPOAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPRECNETOTONCPOAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPRECNETOTONCPOAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_PRECNETOTONCPO.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCod_Area_Internalname, A5Cod_Area, StringUtil.RTrim( context.localUtil.Format( A5Cod_Area, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCod_Area_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCod_Area_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_PRECNETOTONCPO.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_5_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_5_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_5_Internalname, sImgUrl, imgprompt_5_Link, "", "", context.GetTheme( ), imgprompt_5_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_PRECNETOTONCPO.htm");
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
         GxWebStd.gx_single_line_edit( context, edtIndicadoresCodigo_Internalname, A4IndicadoresCodigo, StringUtil.RTrim( context.localUtil.Format( A4IndicadoresCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIndicadoresCodigo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIndicadoresCodigo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_PRECNETOTONCPO.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_4_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_4_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_4_Internalname, sImgUrl, imgprompt_4_Link, "", "", context.GetTheme( ), imgprompt_4_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_PRECNETOTONCPO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMOTIVOSPRENETCodigo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMOTIVOSPRENETCodigo_Internalname, "MOTIVOSPRENETCodigo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtMOTIVOSPRENETCodigo_Internalname, A67MOTIVOSPRENETCodigo, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", 0, 1, edtMOTIVOSPRENETCodigo_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_PRECNETOTONCPO.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_67_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_67_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_67_Internalname, sImgUrl, imgprompt_67_Link, "", "", context.GetTheme( ), imgprompt_67_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_PRECNETOTONCPO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPRECNETOTONCPOValor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPRECNETOTONCPOValor_Internalname, "PRECNETOTONCPOValor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPRECNETOTONCPOValor_Internalname, StringUtil.LTrim( StringUtil.NToC( A203PRECNETOTONCPOValor, 16, 2, ",", "")), StringUtil.LTrim( ((edtPRECNETOTONCPOValor_Enabled!=0) ? context.localUtil.Format( A203PRECNETOTONCPOValor, "ZZZZZZZZZZZZ9.99") : context.localUtil.Format( A203PRECNETOTONCPOValor, "ZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPRECNETOTONCPOValor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPRECNETOTONCPOValor_Enabled, 0, "text", "", 16, "chr", 1, "row", 16, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_PRECNETOTONCPO.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_PRECNETOTONCPO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_PRECNETOTONCPO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_PRECNETOTONCPO.htm");
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
            Z83PRECNETOTONCPOFecha = context.localUtil.CToD( cgiGet( "Z83PRECNETOTONCPOFecha"), 0);
            Z84PRECNETOTONCPOMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z84PRECNETOTONCPOMes"), ",", "."), 18, MidpointRounding.ToEven));
            Z85PRECNETOTONCPOAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z85PRECNETOTONCPOAno"), ",", "."), 18, MidpointRounding.ToEven));
            Z5Cod_Area = cgiGet( "Z5Cod_Area");
            Z4IndicadoresCodigo = cgiGet( "Z4IndicadoresCodigo");
            Z67MOTIVOSPRENETCodigo = cgiGet( "Z67MOTIVOSPRENETCodigo");
            Z203PRECNETOTONCPOValor = context.localUtil.CToN( cgiGet( "Z203PRECNETOTONCPOValor"), ",", ".");
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( context.localUtil.VCDate( cgiGet( edtPRECNETOTONCPOFecha_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"PRECNETOTONCPOFecha"}), 1, "PRECNETOTONCPOFECHA");
               AnyError = 1;
               GX_FocusControl = edtPRECNETOTONCPOFecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A83PRECNETOTONCPOFecha = DateTime.MinValue;
               AssignAttri("", false, "A83PRECNETOTONCPOFecha", context.localUtil.Format(A83PRECNETOTONCPOFecha, "99/99/99"));
            }
            else
            {
               A83PRECNETOTONCPOFecha = context.localUtil.CToD( cgiGet( edtPRECNETOTONCPOFecha_Internalname), 2);
               AssignAttri("", false, "A83PRECNETOTONCPOFecha", context.localUtil.Format(A83PRECNETOTONCPOFecha, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtPRECNETOTONCPOMes_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPRECNETOTONCPOMes_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRECNETOTONCPOMES");
               AnyError = 1;
               GX_FocusControl = edtPRECNETOTONCPOMes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A84PRECNETOTONCPOMes = 0;
               AssignAttri("", false, "A84PRECNETOTONCPOMes", StringUtil.LTrimStr( (decimal)(A84PRECNETOTONCPOMes), 4, 0));
            }
            else
            {
               A84PRECNETOTONCPOMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPRECNETOTONCPOMes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A84PRECNETOTONCPOMes", StringUtil.LTrimStr( (decimal)(A84PRECNETOTONCPOMes), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtPRECNETOTONCPOAno_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPRECNETOTONCPOAno_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRECNETOTONCPOANO");
               AnyError = 1;
               GX_FocusControl = edtPRECNETOTONCPOAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A85PRECNETOTONCPOAno = 0;
               AssignAttri("", false, "A85PRECNETOTONCPOAno", StringUtil.LTrimStr( (decimal)(A85PRECNETOTONCPOAno), 4, 0));
            }
            else
            {
               A85PRECNETOTONCPOAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPRECNETOTONCPOAno_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A85PRECNETOTONCPOAno", StringUtil.LTrimStr( (decimal)(A85PRECNETOTONCPOAno), 4, 0));
            }
            A5Cod_Area = cgiGet( edtCod_Area_Internalname);
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = cgiGet( edtIndicadoresCodigo_Internalname);
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A67MOTIVOSPRENETCodigo = cgiGet( edtMOTIVOSPRENETCodigo_Internalname);
            AssignAttri("", false, "A67MOTIVOSPRENETCodigo", A67MOTIVOSPRENETCodigo);
            if ( ( ( context.localUtil.CToN( cgiGet( edtPRECNETOTONCPOValor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPRECNETOTONCPOValor_Internalname), ",", ".") > 9999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRECNETOTONCPOVALOR");
               AnyError = 1;
               GX_FocusControl = edtPRECNETOTONCPOValor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A203PRECNETOTONCPOValor = 0;
               AssignAttri("", false, "A203PRECNETOTONCPOValor", StringUtil.LTrimStr( A203PRECNETOTONCPOValor, 16, 2));
            }
            else
            {
               A203PRECNETOTONCPOValor = context.localUtil.CToN( cgiGet( edtPRECNETOTONCPOValor_Internalname), ",", ".");
               AssignAttri("", false, "A203PRECNETOTONCPOValor", StringUtil.LTrimStr( A203PRECNETOTONCPOValor, 16, 2));
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
               A83PRECNETOTONCPOFecha = context.localUtil.ParseDateParm( GetPar( "PRECNETOTONCPOFecha"));
               AssignAttri("", false, "A83PRECNETOTONCPOFecha", context.localUtil.Format(A83PRECNETOTONCPOFecha, "99/99/99"));
               A84PRECNETOTONCPOMes = (short)(Math.Round(NumberUtil.Val( GetPar( "PRECNETOTONCPOMes"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A84PRECNETOTONCPOMes", StringUtil.LTrimStr( (decimal)(A84PRECNETOTONCPOMes), 4, 0));
               A85PRECNETOTONCPOAno = (short)(Math.Round(NumberUtil.Val( GetPar( "PRECNETOTONCPOAno"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A85PRECNETOTONCPOAno", StringUtil.LTrimStr( (decimal)(A85PRECNETOTONCPOAno), 4, 0));
               A5Cod_Area = GetPar( "Cod_Area");
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               A4IndicadoresCodigo = GetPar( "IndicadoresCodigo");
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               A67MOTIVOSPRENETCodigo = GetPar( "MOTIVOSPRENETCodigo");
               AssignAttri("", false, "A67MOTIVOSPRENETCodigo", A67MOTIVOSPRENETCodigo);
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
               InitAll1441( ) ;
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
         DisableAttributes1441( ) ;
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

      protected void ResetCaption140( )
      {
      }

      protected void ZM1441( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z203PRECNETOTONCPOValor = T00143_A203PRECNETOTONCPOValor[0];
            }
            else
            {
               Z203PRECNETOTONCPOValor = A203PRECNETOTONCPOValor;
            }
         }
         if ( GX_JID == -2 )
         {
            Z83PRECNETOTONCPOFecha = A83PRECNETOTONCPOFecha;
            Z84PRECNETOTONCPOMes = A84PRECNETOTONCPOMes;
            Z85PRECNETOTONCPOAno = A85PRECNETOTONCPOAno;
            Z203PRECNETOTONCPOValor = A203PRECNETOTONCPOValor;
            Z5Cod_Area = A5Cod_Area;
            Z4IndicadoresCodigo = A4IndicadoresCodigo;
            Z67MOTIVOSPRENETCodigo = A67MOTIVOSPRENETCodigo;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_5_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"COD_AREA"+"'), id:'"+"COD_AREA"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"true"+");");
         imgprompt_4_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0030.aspx"+"',["+"{Ctrl:gx.dom.el('"+"INDICADORESCODIGO"+"'), id:'"+"INDICADORESCODIGO"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"true"+");");
         imgprompt_67_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0140.aspx"+"',["+"{Ctrl:gx.dom.el('"+"MOTIVOSPRENETCODIGO"+"'), id:'"+"MOTIVOSPRENETCODIGO"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");");
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

      protected void Load1441( )
      {
         /* Using cursor T00147 */
         pr_default.execute(5, new Object[] {A83PRECNETOTONCPOFecha, A84PRECNETOTONCPOMes, A85PRECNETOTONCPOAno, A5Cod_Area, A4IndicadoresCodigo, A67MOTIVOSPRENETCodigo});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound41 = 1;
            A203PRECNETOTONCPOValor = T00147_A203PRECNETOTONCPOValor[0];
            AssignAttri("", false, "A203PRECNETOTONCPOValor", StringUtil.LTrimStr( A203PRECNETOTONCPOValor, 16, 2));
            ZM1441( -2) ;
         }
         pr_default.close(5);
         OnLoadActions1441( ) ;
      }

      protected void OnLoadActions1441( )
      {
      }

      protected void CheckExtendedTable1441( )
      {
         nIsDirty_41 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A83PRECNETOTONCPOFecha) || ( DateTimeUtil.ResetTime ( A83PRECNETOTONCPOFecha ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo PRECNETOTONCPOFecha fuera de rango", "OutOfRange", 1, "PRECNETOTONCPOFECHA");
            AnyError = 1;
            GX_FocusControl = edtPRECNETOTONCPOFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00144 */
         pr_default.execute(2, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T00145 */
         pr_default.execute(3, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         /* Using cursor T00146 */
         pr_default.execute(4, new Object[] {A67MOTIVOSPRENETCodigo});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'MOTIVOSPRENET'.", "ForeignKeyNotFound", 1, "MOTIVOSPRENETCODIGO");
            AnyError = 1;
            GX_FocusControl = edtMOTIVOSPRENETCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors1441( )
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
         /* Using cursor T00148 */
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
         /* Using cursor T00149 */
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

      protected void gxLoad_5( string A67MOTIVOSPRENETCodigo )
      {
         /* Using cursor T001410 */
         pr_default.execute(8, new Object[] {A67MOTIVOSPRENETCodigo});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'MOTIVOSPRENET'.", "ForeignKeyNotFound", 1, "MOTIVOSPRENETCODIGO");
            AnyError = 1;
            GX_FocusControl = edtMOTIVOSPRENETCodigo_Internalname;
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

      protected void GetKey1441( )
      {
         /* Using cursor T001411 */
         pr_default.execute(9, new Object[] {A83PRECNETOTONCPOFecha, A84PRECNETOTONCPOMes, A85PRECNETOTONCPOAno, A5Cod_Area, A4IndicadoresCodigo, A67MOTIVOSPRENETCodigo});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound41 = 1;
         }
         else
         {
            RcdFound41 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00143 */
         pr_default.execute(1, new Object[] {A83PRECNETOTONCPOFecha, A84PRECNETOTONCPOMes, A85PRECNETOTONCPOAno, A5Cod_Area, A4IndicadoresCodigo, A67MOTIVOSPRENETCodigo});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1441( 2) ;
            RcdFound41 = 1;
            A83PRECNETOTONCPOFecha = T00143_A83PRECNETOTONCPOFecha[0];
            AssignAttri("", false, "A83PRECNETOTONCPOFecha", context.localUtil.Format(A83PRECNETOTONCPOFecha, "99/99/99"));
            A84PRECNETOTONCPOMes = T00143_A84PRECNETOTONCPOMes[0];
            AssignAttri("", false, "A84PRECNETOTONCPOMes", StringUtil.LTrimStr( (decimal)(A84PRECNETOTONCPOMes), 4, 0));
            A85PRECNETOTONCPOAno = T00143_A85PRECNETOTONCPOAno[0];
            AssignAttri("", false, "A85PRECNETOTONCPOAno", StringUtil.LTrimStr( (decimal)(A85PRECNETOTONCPOAno), 4, 0));
            A203PRECNETOTONCPOValor = T00143_A203PRECNETOTONCPOValor[0];
            AssignAttri("", false, "A203PRECNETOTONCPOValor", StringUtil.LTrimStr( A203PRECNETOTONCPOValor, 16, 2));
            A5Cod_Area = T00143_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = T00143_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A67MOTIVOSPRENETCodigo = T00143_A67MOTIVOSPRENETCodigo[0];
            AssignAttri("", false, "A67MOTIVOSPRENETCodigo", A67MOTIVOSPRENETCodigo);
            Z83PRECNETOTONCPOFecha = A83PRECNETOTONCPOFecha;
            Z84PRECNETOTONCPOMes = A84PRECNETOTONCPOMes;
            Z85PRECNETOTONCPOAno = A85PRECNETOTONCPOAno;
            Z5Cod_Area = A5Cod_Area;
            Z4IndicadoresCodigo = A4IndicadoresCodigo;
            Z67MOTIVOSPRENETCodigo = A67MOTIVOSPRENETCodigo;
            sMode41 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1441( ) ;
            if ( AnyError == 1 )
            {
               RcdFound41 = 0;
               InitializeNonKey1441( ) ;
            }
            Gx_mode = sMode41;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound41 = 0;
            InitializeNonKey1441( ) ;
            sMode41 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode41;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1441( ) ;
         if ( RcdFound41 == 0 )
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
         RcdFound41 = 0;
         /* Using cursor T001412 */
         pr_default.execute(10, new Object[] {A83PRECNETOTONCPOFecha, A84PRECNETOTONCPOMes, A85PRECNETOTONCPOAno, A5Cod_Area, A4IndicadoresCodigo, A67MOTIVOSPRENETCodigo});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( DateTimeUtil.ResetTime ( T001412_A83PRECNETOTONCPOFecha[0] ) < DateTimeUtil.ResetTime ( A83PRECNETOTONCPOFecha ) ) || ( DateTimeUtil.ResetTime ( T001412_A83PRECNETOTONCPOFecha[0] ) == DateTimeUtil.ResetTime ( A83PRECNETOTONCPOFecha ) ) && ( T001412_A84PRECNETOTONCPOMes[0] < A84PRECNETOTONCPOMes ) || ( T001412_A84PRECNETOTONCPOMes[0] == A84PRECNETOTONCPOMes ) && ( DateTimeUtil.ResetTime ( T001412_A83PRECNETOTONCPOFecha[0] ) == DateTimeUtil.ResetTime ( A83PRECNETOTONCPOFecha ) ) && ( T001412_A85PRECNETOTONCPOAno[0] < A85PRECNETOTONCPOAno ) || ( T001412_A85PRECNETOTONCPOAno[0] == A85PRECNETOTONCPOAno ) && ( T001412_A84PRECNETOTONCPOMes[0] == A84PRECNETOTONCPOMes ) && ( DateTimeUtil.ResetTime ( T001412_A83PRECNETOTONCPOFecha[0] ) == DateTimeUtil.ResetTime ( A83PRECNETOTONCPOFecha ) ) && ( StringUtil.StrCmp(T001412_A5Cod_Area[0], A5Cod_Area) < 0 ) || ( StringUtil.StrCmp(T001412_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T001412_A85PRECNETOTONCPOAno[0] == A85PRECNETOTONCPOAno ) && ( T001412_A84PRECNETOTONCPOMes[0] == A84PRECNETOTONCPOMes ) && ( DateTimeUtil.ResetTime ( T001412_A83PRECNETOTONCPOFecha[0] ) == DateTimeUtil.ResetTime ( A83PRECNETOTONCPOFecha ) ) && ( StringUtil.StrCmp(T001412_A4IndicadoresCodigo[0], A4IndicadoresCodigo) < 0 ) || ( StringUtil.StrCmp(T001412_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T001412_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T001412_A85PRECNETOTONCPOAno[0] == A85PRECNETOTONCPOAno ) && ( T001412_A84PRECNETOTONCPOMes[0] == A84PRECNETOTONCPOMes ) && ( DateTimeUtil.ResetTime ( T001412_A83PRECNETOTONCPOFecha[0] ) == DateTimeUtil.ResetTime ( A83PRECNETOTONCPOFecha ) ) && ( StringUtil.StrCmp(T001412_A67MOTIVOSPRENETCodigo[0], A67MOTIVOSPRENETCodigo) < 0 ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( DateTimeUtil.ResetTime ( T001412_A83PRECNETOTONCPOFecha[0] ) > DateTimeUtil.ResetTime ( A83PRECNETOTONCPOFecha ) ) || ( DateTimeUtil.ResetTime ( T001412_A83PRECNETOTONCPOFecha[0] ) == DateTimeUtil.ResetTime ( A83PRECNETOTONCPOFecha ) ) && ( T001412_A84PRECNETOTONCPOMes[0] > A84PRECNETOTONCPOMes ) || ( T001412_A84PRECNETOTONCPOMes[0] == A84PRECNETOTONCPOMes ) && ( DateTimeUtil.ResetTime ( T001412_A83PRECNETOTONCPOFecha[0] ) == DateTimeUtil.ResetTime ( A83PRECNETOTONCPOFecha ) ) && ( T001412_A85PRECNETOTONCPOAno[0] > A85PRECNETOTONCPOAno ) || ( T001412_A85PRECNETOTONCPOAno[0] == A85PRECNETOTONCPOAno ) && ( T001412_A84PRECNETOTONCPOMes[0] == A84PRECNETOTONCPOMes ) && ( DateTimeUtil.ResetTime ( T001412_A83PRECNETOTONCPOFecha[0] ) == DateTimeUtil.ResetTime ( A83PRECNETOTONCPOFecha ) ) && ( StringUtil.StrCmp(T001412_A5Cod_Area[0], A5Cod_Area) > 0 ) || ( StringUtil.StrCmp(T001412_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T001412_A85PRECNETOTONCPOAno[0] == A85PRECNETOTONCPOAno ) && ( T001412_A84PRECNETOTONCPOMes[0] == A84PRECNETOTONCPOMes ) && ( DateTimeUtil.ResetTime ( T001412_A83PRECNETOTONCPOFecha[0] ) == DateTimeUtil.ResetTime ( A83PRECNETOTONCPOFecha ) ) && ( StringUtil.StrCmp(T001412_A4IndicadoresCodigo[0], A4IndicadoresCodigo) > 0 ) || ( StringUtil.StrCmp(T001412_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T001412_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T001412_A85PRECNETOTONCPOAno[0] == A85PRECNETOTONCPOAno ) && ( T001412_A84PRECNETOTONCPOMes[0] == A84PRECNETOTONCPOMes ) && ( DateTimeUtil.ResetTime ( T001412_A83PRECNETOTONCPOFecha[0] ) == DateTimeUtil.ResetTime ( A83PRECNETOTONCPOFecha ) ) && ( StringUtil.StrCmp(T001412_A67MOTIVOSPRENETCodigo[0], A67MOTIVOSPRENETCodigo) > 0 ) ) )
            {
               A83PRECNETOTONCPOFecha = T001412_A83PRECNETOTONCPOFecha[0];
               AssignAttri("", false, "A83PRECNETOTONCPOFecha", context.localUtil.Format(A83PRECNETOTONCPOFecha, "99/99/99"));
               A84PRECNETOTONCPOMes = T001412_A84PRECNETOTONCPOMes[0];
               AssignAttri("", false, "A84PRECNETOTONCPOMes", StringUtil.LTrimStr( (decimal)(A84PRECNETOTONCPOMes), 4, 0));
               A85PRECNETOTONCPOAno = T001412_A85PRECNETOTONCPOAno[0];
               AssignAttri("", false, "A85PRECNETOTONCPOAno", StringUtil.LTrimStr( (decimal)(A85PRECNETOTONCPOAno), 4, 0));
               A5Cod_Area = T001412_A5Cod_Area[0];
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               A4IndicadoresCodigo = T001412_A4IndicadoresCodigo[0];
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               A67MOTIVOSPRENETCodigo = T001412_A67MOTIVOSPRENETCodigo[0];
               AssignAttri("", false, "A67MOTIVOSPRENETCodigo", A67MOTIVOSPRENETCodigo);
               RcdFound41 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound41 = 0;
         /* Using cursor T001413 */
         pr_default.execute(11, new Object[] {A83PRECNETOTONCPOFecha, A84PRECNETOTONCPOMes, A85PRECNETOTONCPOAno, A5Cod_Area, A4IndicadoresCodigo, A67MOTIVOSPRENETCodigo});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( DateTimeUtil.ResetTime ( T001413_A83PRECNETOTONCPOFecha[0] ) > DateTimeUtil.ResetTime ( A83PRECNETOTONCPOFecha ) ) || ( DateTimeUtil.ResetTime ( T001413_A83PRECNETOTONCPOFecha[0] ) == DateTimeUtil.ResetTime ( A83PRECNETOTONCPOFecha ) ) && ( T001413_A84PRECNETOTONCPOMes[0] > A84PRECNETOTONCPOMes ) || ( T001413_A84PRECNETOTONCPOMes[0] == A84PRECNETOTONCPOMes ) && ( DateTimeUtil.ResetTime ( T001413_A83PRECNETOTONCPOFecha[0] ) == DateTimeUtil.ResetTime ( A83PRECNETOTONCPOFecha ) ) && ( T001413_A85PRECNETOTONCPOAno[0] > A85PRECNETOTONCPOAno ) || ( T001413_A85PRECNETOTONCPOAno[0] == A85PRECNETOTONCPOAno ) && ( T001413_A84PRECNETOTONCPOMes[0] == A84PRECNETOTONCPOMes ) && ( DateTimeUtil.ResetTime ( T001413_A83PRECNETOTONCPOFecha[0] ) == DateTimeUtil.ResetTime ( A83PRECNETOTONCPOFecha ) ) && ( StringUtil.StrCmp(T001413_A5Cod_Area[0], A5Cod_Area) > 0 ) || ( StringUtil.StrCmp(T001413_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T001413_A85PRECNETOTONCPOAno[0] == A85PRECNETOTONCPOAno ) && ( T001413_A84PRECNETOTONCPOMes[0] == A84PRECNETOTONCPOMes ) && ( DateTimeUtil.ResetTime ( T001413_A83PRECNETOTONCPOFecha[0] ) == DateTimeUtil.ResetTime ( A83PRECNETOTONCPOFecha ) ) && ( StringUtil.StrCmp(T001413_A4IndicadoresCodigo[0], A4IndicadoresCodigo) > 0 ) || ( StringUtil.StrCmp(T001413_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T001413_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T001413_A85PRECNETOTONCPOAno[0] == A85PRECNETOTONCPOAno ) && ( T001413_A84PRECNETOTONCPOMes[0] == A84PRECNETOTONCPOMes ) && ( DateTimeUtil.ResetTime ( T001413_A83PRECNETOTONCPOFecha[0] ) == DateTimeUtil.ResetTime ( A83PRECNETOTONCPOFecha ) ) && ( StringUtil.StrCmp(T001413_A67MOTIVOSPRENETCodigo[0], A67MOTIVOSPRENETCodigo) > 0 ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( DateTimeUtil.ResetTime ( T001413_A83PRECNETOTONCPOFecha[0] ) < DateTimeUtil.ResetTime ( A83PRECNETOTONCPOFecha ) ) || ( DateTimeUtil.ResetTime ( T001413_A83PRECNETOTONCPOFecha[0] ) == DateTimeUtil.ResetTime ( A83PRECNETOTONCPOFecha ) ) && ( T001413_A84PRECNETOTONCPOMes[0] < A84PRECNETOTONCPOMes ) || ( T001413_A84PRECNETOTONCPOMes[0] == A84PRECNETOTONCPOMes ) && ( DateTimeUtil.ResetTime ( T001413_A83PRECNETOTONCPOFecha[0] ) == DateTimeUtil.ResetTime ( A83PRECNETOTONCPOFecha ) ) && ( T001413_A85PRECNETOTONCPOAno[0] < A85PRECNETOTONCPOAno ) || ( T001413_A85PRECNETOTONCPOAno[0] == A85PRECNETOTONCPOAno ) && ( T001413_A84PRECNETOTONCPOMes[0] == A84PRECNETOTONCPOMes ) && ( DateTimeUtil.ResetTime ( T001413_A83PRECNETOTONCPOFecha[0] ) == DateTimeUtil.ResetTime ( A83PRECNETOTONCPOFecha ) ) && ( StringUtil.StrCmp(T001413_A5Cod_Area[0], A5Cod_Area) < 0 ) || ( StringUtil.StrCmp(T001413_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T001413_A85PRECNETOTONCPOAno[0] == A85PRECNETOTONCPOAno ) && ( T001413_A84PRECNETOTONCPOMes[0] == A84PRECNETOTONCPOMes ) && ( DateTimeUtil.ResetTime ( T001413_A83PRECNETOTONCPOFecha[0] ) == DateTimeUtil.ResetTime ( A83PRECNETOTONCPOFecha ) ) && ( StringUtil.StrCmp(T001413_A4IndicadoresCodigo[0], A4IndicadoresCodigo) < 0 ) || ( StringUtil.StrCmp(T001413_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T001413_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T001413_A85PRECNETOTONCPOAno[0] == A85PRECNETOTONCPOAno ) && ( T001413_A84PRECNETOTONCPOMes[0] == A84PRECNETOTONCPOMes ) && ( DateTimeUtil.ResetTime ( T001413_A83PRECNETOTONCPOFecha[0] ) == DateTimeUtil.ResetTime ( A83PRECNETOTONCPOFecha ) ) && ( StringUtil.StrCmp(T001413_A67MOTIVOSPRENETCodigo[0], A67MOTIVOSPRENETCodigo) < 0 ) ) )
            {
               A83PRECNETOTONCPOFecha = T001413_A83PRECNETOTONCPOFecha[0];
               AssignAttri("", false, "A83PRECNETOTONCPOFecha", context.localUtil.Format(A83PRECNETOTONCPOFecha, "99/99/99"));
               A84PRECNETOTONCPOMes = T001413_A84PRECNETOTONCPOMes[0];
               AssignAttri("", false, "A84PRECNETOTONCPOMes", StringUtil.LTrimStr( (decimal)(A84PRECNETOTONCPOMes), 4, 0));
               A85PRECNETOTONCPOAno = T001413_A85PRECNETOTONCPOAno[0];
               AssignAttri("", false, "A85PRECNETOTONCPOAno", StringUtil.LTrimStr( (decimal)(A85PRECNETOTONCPOAno), 4, 0));
               A5Cod_Area = T001413_A5Cod_Area[0];
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               A4IndicadoresCodigo = T001413_A4IndicadoresCodigo[0];
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               A67MOTIVOSPRENETCodigo = T001413_A67MOTIVOSPRENETCodigo[0];
               AssignAttri("", false, "A67MOTIVOSPRENETCodigo", A67MOTIVOSPRENETCodigo);
               RcdFound41 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1441( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPRECNETOTONCPOFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1441( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound41 == 1 )
            {
               if ( ( DateTimeUtil.ResetTime ( A83PRECNETOTONCPOFecha ) != DateTimeUtil.ResetTime ( Z83PRECNETOTONCPOFecha ) ) || ( A84PRECNETOTONCPOMes != Z84PRECNETOTONCPOMes ) || ( A85PRECNETOTONCPOAno != Z85PRECNETOTONCPOAno ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) || ( StringUtil.StrCmp(A67MOTIVOSPRENETCodigo, Z67MOTIVOSPRENETCodigo) != 0 ) )
               {
                  A83PRECNETOTONCPOFecha = Z83PRECNETOTONCPOFecha;
                  AssignAttri("", false, "A83PRECNETOTONCPOFecha", context.localUtil.Format(A83PRECNETOTONCPOFecha, "99/99/99"));
                  A84PRECNETOTONCPOMes = Z84PRECNETOTONCPOMes;
                  AssignAttri("", false, "A84PRECNETOTONCPOMes", StringUtil.LTrimStr( (decimal)(A84PRECNETOTONCPOMes), 4, 0));
                  A85PRECNETOTONCPOAno = Z85PRECNETOTONCPOAno;
                  AssignAttri("", false, "A85PRECNETOTONCPOAno", StringUtil.LTrimStr( (decimal)(A85PRECNETOTONCPOAno), 4, 0));
                  A5Cod_Area = Z5Cod_Area;
                  AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
                  A4IndicadoresCodigo = Z4IndicadoresCodigo;
                  AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
                  A67MOTIVOSPRENETCodigo = Z67MOTIVOSPRENETCodigo;
                  AssignAttri("", false, "A67MOTIVOSPRENETCodigo", A67MOTIVOSPRENETCodigo);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PRECNETOTONCPOFECHA");
                  AnyError = 1;
                  GX_FocusControl = edtPRECNETOTONCPOFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPRECNETOTONCPOFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1441( ) ;
                  GX_FocusControl = edtPRECNETOTONCPOFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( DateTimeUtil.ResetTime ( A83PRECNETOTONCPOFecha ) != DateTimeUtil.ResetTime ( Z83PRECNETOTONCPOFecha ) ) || ( A84PRECNETOTONCPOMes != Z84PRECNETOTONCPOMes ) || ( A85PRECNETOTONCPOAno != Z85PRECNETOTONCPOAno ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) || ( StringUtil.StrCmp(A67MOTIVOSPRENETCodigo, Z67MOTIVOSPRENETCodigo) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtPRECNETOTONCPOFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1441( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PRECNETOTONCPOFECHA");
                     AnyError = 1;
                     GX_FocusControl = edtPRECNETOTONCPOFecha_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtPRECNETOTONCPOFecha_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1441( ) ;
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
         if ( ( DateTimeUtil.ResetTime ( A83PRECNETOTONCPOFecha ) != DateTimeUtil.ResetTime ( Z83PRECNETOTONCPOFecha ) ) || ( A84PRECNETOTONCPOMes != Z84PRECNETOTONCPOMes ) || ( A85PRECNETOTONCPOAno != Z85PRECNETOTONCPOAno ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) || ( StringUtil.StrCmp(A67MOTIVOSPRENETCodigo, Z67MOTIVOSPRENETCodigo) != 0 ) )
         {
            A83PRECNETOTONCPOFecha = Z83PRECNETOTONCPOFecha;
            AssignAttri("", false, "A83PRECNETOTONCPOFecha", context.localUtil.Format(A83PRECNETOTONCPOFecha, "99/99/99"));
            A84PRECNETOTONCPOMes = Z84PRECNETOTONCPOMes;
            AssignAttri("", false, "A84PRECNETOTONCPOMes", StringUtil.LTrimStr( (decimal)(A84PRECNETOTONCPOMes), 4, 0));
            A85PRECNETOTONCPOAno = Z85PRECNETOTONCPOAno;
            AssignAttri("", false, "A85PRECNETOTONCPOAno", StringUtil.LTrimStr( (decimal)(A85PRECNETOTONCPOAno), 4, 0));
            A5Cod_Area = Z5Cod_Area;
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = Z4IndicadoresCodigo;
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A67MOTIVOSPRENETCodigo = Z67MOTIVOSPRENETCodigo;
            AssignAttri("", false, "A67MOTIVOSPRENETCodigo", A67MOTIVOSPRENETCodigo);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PRECNETOTONCPOFECHA");
            AnyError = 1;
            GX_FocusControl = edtPRECNETOTONCPOFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPRECNETOTONCPOFecha_Internalname;
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
         if ( RcdFound41 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "PRECNETOTONCPOFECHA");
            AnyError = 1;
            GX_FocusControl = edtPRECNETOTONCPOFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtPRECNETOTONCPOValor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1441( ) ;
         if ( RcdFound41 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPRECNETOTONCPOValor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1441( ) ;
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
         if ( RcdFound41 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPRECNETOTONCPOValor_Internalname;
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
         if ( RcdFound41 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPRECNETOTONCPOValor_Internalname;
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
         ScanStart1441( ) ;
         if ( RcdFound41 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound41 != 0 )
            {
               ScanNext1441( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPRECNETOTONCPOValor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1441( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1441( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00142 */
            pr_default.execute(0, new Object[] {A83PRECNETOTONCPOFecha, A84PRECNETOTONCPOMes, A85PRECNETOTONCPOAno, A5Cod_Area, A4IndicadoresCodigo, A67MOTIVOSPRENETCodigo});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PRECNETOTONCPO"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z203PRECNETOTONCPOValor != T00142_A203PRECNETOTONCPOValor[0] ) )
            {
               if ( Z203PRECNETOTONCPOValor != T00142_A203PRECNETOTONCPOValor[0] )
               {
                  GXUtil.WriteLog("precnetotoncpo:[seudo value changed for attri]"+"PRECNETOTONCPOValor");
                  GXUtil.WriteLogRaw("Old: ",Z203PRECNETOTONCPOValor);
                  GXUtil.WriteLogRaw("Current: ",T00142_A203PRECNETOTONCPOValor[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"PRECNETOTONCPO"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1441( )
      {
         BeforeValidate1441( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1441( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1441( 0) ;
            CheckOptimisticConcurrency1441( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1441( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1441( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001414 */
                     pr_default.execute(12, new Object[] {A83PRECNETOTONCPOFecha, A84PRECNETOTONCPOMes, A85PRECNETOTONCPOAno, A203PRECNETOTONCPOValor, A5Cod_Area, A4IndicadoresCodigo, A67MOTIVOSPRENETCodigo});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("PRECNETOTONCPO");
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
                           ResetCaption140( ) ;
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
               Load1441( ) ;
            }
            EndLevel1441( ) ;
         }
         CloseExtendedTableCursors1441( ) ;
      }

      protected void Update1441( )
      {
         BeforeValidate1441( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1441( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1441( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1441( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1441( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001415 */
                     pr_default.execute(13, new Object[] {A203PRECNETOTONCPOValor, A83PRECNETOTONCPOFecha, A84PRECNETOTONCPOMes, A85PRECNETOTONCPOAno, A5Cod_Area, A4IndicadoresCodigo, A67MOTIVOSPRENETCodigo});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("PRECNETOTONCPO");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PRECNETOTONCPO"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1441( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption140( ) ;
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
            EndLevel1441( ) ;
         }
         CloseExtendedTableCursors1441( ) ;
      }

      protected void DeferredUpdate1441( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1441( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1441( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1441( ) ;
            AfterConfirm1441( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1441( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001416 */
                  pr_default.execute(14, new Object[] {A83PRECNETOTONCPOFecha, A84PRECNETOTONCPOMes, A85PRECNETOTONCPOAno, A5Cod_Area, A4IndicadoresCodigo, A67MOTIVOSPRENETCodigo});
                  pr_default.close(14);
                  pr_default.SmartCacheProvider.SetUpdated("PRECNETOTONCPO");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound41 == 0 )
                        {
                           InitAll1441( ) ;
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
                        ResetCaption140( ) ;
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
         sMode41 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1441( ) ;
         Gx_mode = sMode41;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1441( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1441( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1441( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("precnetotoncpo",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues140( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("precnetotoncpo",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1441( )
      {
         /* Using cursor T001417 */
         pr_default.execute(15);
         RcdFound41 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound41 = 1;
            A83PRECNETOTONCPOFecha = T001417_A83PRECNETOTONCPOFecha[0];
            AssignAttri("", false, "A83PRECNETOTONCPOFecha", context.localUtil.Format(A83PRECNETOTONCPOFecha, "99/99/99"));
            A84PRECNETOTONCPOMes = T001417_A84PRECNETOTONCPOMes[0];
            AssignAttri("", false, "A84PRECNETOTONCPOMes", StringUtil.LTrimStr( (decimal)(A84PRECNETOTONCPOMes), 4, 0));
            A85PRECNETOTONCPOAno = T001417_A85PRECNETOTONCPOAno[0];
            AssignAttri("", false, "A85PRECNETOTONCPOAno", StringUtil.LTrimStr( (decimal)(A85PRECNETOTONCPOAno), 4, 0));
            A5Cod_Area = T001417_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = T001417_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A67MOTIVOSPRENETCodigo = T001417_A67MOTIVOSPRENETCodigo[0];
            AssignAttri("", false, "A67MOTIVOSPRENETCodigo", A67MOTIVOSPRENETCodigo);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1441( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound41 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound41 = 1;
            A83PRECNETOTONCPOFecha = T001417_A83PRECNETOTONCPOFecha[0];
            AssignAttri("", false, "A83PRECNETOTONCPOFecha", context.localUtil.Format(A83PRECNETOTONCPOFecha, "99/99/99"));
            A84PRECNETOTONCPOMes = T001417_A84PRECNETOTONCPOMes[0];
            AssignAttri("", false, "A84PRECNETOTONCPOMes", StringUtil.LTrimStr( (decimal)(A84PRECNETOTONCPOMes), 4, 0));
            A85PRECNETOTONCPOAno = T001417_A85PRECNETOTONCPOAno[0];
            AssignAttri("", false, "A85PRECNETOTONCPOAno", StringUtil.LTrimStr( (decimal)(A85PRECNETOTONCPOAno), 4, 0));
            A5Cod_Area = T001417_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = T001417_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A67MOTIVOSPRENETCodigo = T001417_A67MOTIVOSPRENETCodigo[0];
            AssignAttri("", false, "A67MOTIVOSPRENETCodigo", A67MOTIVOSPRENETCodigo);
         }
      }

      protected void ScanEnd1441( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm1441( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1441( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1441( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1441( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1441( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1441( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1441( )
      {
         edtPRECNETOTONCPOFecha_Enabled = 0;
         AssignProp("", false, edtPRECNETOTONCPOFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPRECNETOTONCPOFecha_Enabled), 5, 0), true);
         edtPRECNETOTONCPOMes_Enabled = 0;
         AssignProp("", false, edtPRECNETOTONCPOMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPRECNETOTONCPOMes_Enabled), 5, 0), true);
         edtPRECNETOTONCPOAno_Enabled = 0;
         AssignProp("", false, edtPRECNETOTONCPOAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPRECNETOTONCPOAno_Enabled), 5, 0), true);
         edtCod_Area_Enabled = 0;
         AssignProp("", false, edtCod_Area_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCod_Area_Enabled), 5, 0), true);
         edtIndicadoresCodigo_Enabled = 0;
         AssignProp("", false, edtIndicadoresCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIndicadoresCodigo_Enabled), 5, 0), true);
         edtMOTIVOSPRENETCodigo_Enabled = 0;
         AssignProp("", false, edtMOTIVOSPRENETCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMOTIVOSPRENETCodigo_Enabled), 5, 0), true);
         edtPRECNETOTONCPOValor_Enabled = 0;
         AssignProp("", false, edtPRECNETOTONCPOValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPRECNETOTONCPOValor_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1441( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues140( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("precnetotoncpo.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z83PRECNETOTONCPOFecha", context.localUtil.DToC( Z83PRECNETOTONCPOFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z84PRECNETOTONCPOMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z84PRECNETOTONCPOMes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z85PRECNETOTONCPOAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z85PRECNETOTONCPOAno), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z5Cod_Area", Z5Cod_Area);
         GxWebStd.gx_hidden_field( context, "Z4IndicadoresCodigo", Z4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "Z67MOTIVOSPRENETCodigo", Z67MOTIVOSPRENETCodigo);
         GxWebStd.gx_hidden_field( context, "Z203PRECNETOTONCPOValor", StringUtil.LTrim( StringUtil.NToC( Z203PRECNETOTONCPOValor, 16, 2, ",", "")));
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
         return formatLink("precnetotoncpo.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "PRECNETOTONCPO" ;
      }

      public override string GetPgmdesc( )
      {
         return "PRECNETOTONCPO" ;
      }

      protected void InitializeNonKey1441( )
      {
         A203PRECNETOTONCPOValor = 0;
         AssignAttri("", false, "A203PRECNETOTONCPOValor", StringUtil.LTrimStr( A203PRECNETOTONCPOValor, 16, 2));
         Z203PRECNETOTONCPOValor = 0;
      }

      protected void InitAll1441( )
      {
         A83PRECNETOTONCPOFecha = DateTime.MinValue;
         AssignAttri("", false, "A83PRECNETOTONCPOFecha", context.localUtil.Format(A83PRECNETOTONCPOFecha, "99/99/99"));
         A84PRECNETOTONCPOMes = 0;
         AssignAttri("", false, "A84PRECNETOTONCPOMes", StringUtil.LTrimStr( (decimal)(A84PRECNETOTONCPOMes), 4, 0));
         A85PRECNETOTONCPOAno = 0;
         AssignAttri("", false, "A85PRECNETOTONCPOAno", StringUtil.LTrimStr( (decimal)(A85PRECNETOTONCPOAno), 4, 0));
         A5Cod_Area = "";
         AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
         A4IndicadoresCodigo = "";
         AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
         A67MOTIVOSPRENETCodigo = "";
         AssignAttri("", false, "A67MOTIVOSPRENETCodigo", A67MOTIVOSPRENETCodigo);
         InitializeNonKey1441( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024723102551", true, true);
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
         context.AddJavascriptSource("precnetotoncpo.js", "?2024723102551", false, true);
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
         edtPRECNETOTONCPOFecha_Internalname = "PRECNETOTONCPOFECHA";
         edtPRECNETOTONCPOMes_Internalname = "PRECNETOTONCPOMES";
         edtPRECNETOTONCPOAno_Internalname = "PRECNETOTONCPOANO";
         edtCod_Area_Internalname = "COD_AREA";
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO";
         edtMOTIVOSPRENETCodigo_Internalname = "MOTIVOSPRENETCODIGO";
         edtPRECNETOTONCPOValor_Internalname = "PRECNETOTONCPOVALOR";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_5_Internalname = "PROMPT_5";
         imgprompt_4_Internalname = "PROMPT_4";
         imgprompt_67_Internalname = "PROMPT_67";
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
         Form.Caption = "PRECNETOTONCPO";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtPRECNETOTONCPOValor_Jsonclick = "";
         edtPRECNETOTONCPOValor_Enabled = 1;
         imgprompt_67_Visible = 1;
         imgprompt_67_Link = "";
         edtMOTIVOSPRENETCodigo_Enabled = 1;
         imgprompt_4_Visible = 1;
         imgprompt_4_Link = "";
         edtIndicadoresCodigo_Jsonclick = "";
         edtIndicadoresCodigo_Enabled = 1;
         imgprompt_5_Visible = 1;
         imgprompt_5_Link = "";
         edtCod_Area_Jsonclick = "";
         edtCod_Area_Enabled = 1;
         edtPRECNETOTONCPOAno_Jsonclick = "";
         edtPRECNETOTONCPOAno_Enabled = 1;
         edtPRECNETOTONCPOMes_Jsonclick = "";
         edtPRECNETOTONCPOMes_Enabled = 1;
         edtPRECNETOTONCPOFecha_Jsonclick = "";
         edtPRECNETOTONCPOFecha_Enabled = 1;
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
         /* Using cursor T001418 */
         pr_default.execute(16, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(16);
         /* Using cursor T001419 */
         pr_default.execute(17, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(17);
         /* Using cursor T001420 */
         pr_default.execute(18, new Object[] {A67MOTIVOSPRENETCodigo});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'MOTIVOSPRENET'.", "ForeignKeyNotFound", 1, "MOTIVOSPRENETCODIGO");
            AnyError = 1;
            GX_FocusControl = edtMOTIVOSPRENETCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(18);
         GX_FocusControl = edtPRECNETOTONCPOValor_Internalname;
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
         /* Using cursor T001418 */
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
         /* Using cursor T001419 */
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

      public void Valid_Motivosprenetcodigo( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T001420 */
         pr_default.execute(18, new Object[] {A67MOTIVOSPRENETCodigo});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'MOTIVOSPRENET'.", "ForeignKeyNotFound", 1, "MOTIVOSPRENETCODIGO");
            AnyError = 1;
            GX_FocusControl = edtMOTIVOSPRENETCodigo_Internalname;
         }
         pr_default.close(18);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A203PRECNETOTONCPOValor", StringUtil.LTrim( StringUtil.NToC( A203PRECNETOTONCPOValor, 16, 2, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z83PRECNETOTONCPOFecha", context.localUtil.Format(Z83PRECNETOTONCPOFecha, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z84PRECNETOTONCPOMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z84PRECNETOTONCPOMes), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z85PRECNETOTONCPOAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z85PRECNETOTONCPOAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z5Cod_Area", Z5Cod_Area);
         GxWebStd.gx_hidden_field( context, "Z4IndicadoresCodigo", Z4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "Z67MOTIVOSPRENETCodigo", Z67MOTIVOSPRENETCodigo);
         GxWebStd.gx_hidden_field( context, "Z203PRECNETOTONCPOValor", StringUtil.LTrim( StringUtil.NToC( Z203PRECNETOTONCPOValor, 16, 2, ".", "")));
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
         setEventMetadata("VALID_PRECNETOTONCPOFECHA","{handler:'Valid_Precnetotoncpofecha',iparms:[]");
         setEventMetadata("VALID_PRECNETOTONCPOFECHA",",oparms:[]}");
         setEventMetadata("VALID_PRECNETOTONCPOMES","{handler:'Valid_Precnetotoncpomes',iparms:[]");
         setEventMetadata("VALID_PRECNETOTONCPOMES",",oparms:[]}");
         setEventMetadata("VALID_PRECNETOTONCPOANO","{handler:'Valid_Precnetotoncpoano',iparms:[]");
         setEventMetadata("VALID_PRECNETOTONCPOANO",",oparms:[]}");
         setEventMetadata("VALID_COD_AREA","{handler:'Valid_Cod_area',iparms:[{av:'A5Cod_Area',fld:'COD_AREA',pic:''}]");
         setEventMetadata("VALID_COD_AREA",",oparms:[]}");
         setEventMetadata("VALID_INDICADORESCODIGO","{handler:'Valid_Indicadorescodigo',iparms:[{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:''}]");
         setEventMetadata("VALID_INDICADORESCODIGO",",oparms:[]}");
         setEventMetadata("VALID_MOTIVOSPRENETCODIGO","{handler:'Valid_Motivosprenetcodigo',iparms:[{av:'A83PRECNETOTONCPOFecha',fld:'PRECNETOTONCPOFECHA',pic:''},{av:'A84PRECNETOTONCPOMes',fld:'PRECNETOTONCPOMES',pic:'ZZZ9'},{av:'A85PRECNETOTONCPOAno',fld:'PRECNETOTONCPOANO',pic:'ZZZ9'},{av:'A5Cod_Area',fld:'COD_AREA',pic:''},{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:''},{av:'A67MOTIVOSPRENETCodigo',fld:'MOTIVOSPRENETCODIGO',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_MOTIVOSPRENETCODIGO",",oparms:[{av:'A203PRECNETOTONCPOValor',fld:'PRECNETOTONCPOVALOR',pic:'ZZZZZZZZZZZZ9.99'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z83PRECNETOTONCPOFecha'},{av:'Z84PRECNETOTONCPOMes'},{av:'Z85PRECNETOTONCPOAno'},{av:'Z5Cod_Area'},{av:'Z4IndicadoresCodigo'},{av:'Z67MOTIVOSPRENETCodigo'},{av:'Z203PRECNETOTONCPOValor'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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
         Z83PRECNETOTONCPOFecha = DateTime.MinValue;
         Z5Cod_Area = "";
         Z4IndicadoresCodigo = "";
         Z67MOTIVOSPRENETCodigo = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A5Cod_Area = "";
         A4IndicadoresCodigo = "";
         A67MOTIVOSPRENETCodigo = "";
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
         A83PRECNETOTONCPOFecha = DateTime.MinValue;
         imgprompt_5_gximage = "";
         sImgUrl = "";
         imgprompt_4_gximage = "";
         imgprompt_67_gximage = "";
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
         T00147_A83PRECNETOTONCPOFecha = new DateTime[] {DateTime.MinValue} ;
         T00147_A84PRECNETOTONCPOMes = new short[1] ;
         T00147_A85PRECNETOTONCPOAno = new short[1] ;
         T00147_A203PRECNETOTONCPOValor = new decimal[1] ;
         T00147_A5Cod_Area = new string[] {""} ;
         T00147_A4IndicadoresCodigo = new string[] {""} ;
         T00147_A67MOTIVOSPRENETCodigo = new string[] {""} ;
         T00144_A5Cod_Area = new string[] {""} ;
         T00145_A4IndicadoresCodigo = new string[] {""} ;
         T00146_A67MOTIVOSPRENETCodigo = new string[] {""} ;
         T00148_A5Cod_Area = new string[] {""} ;
         T00149_A4IndicadoresCodigo = new string[] {""} ;
         T001410_A67MOTIVOSPRENETCodigo = new string[] {""} ;
         T001411_A83PRECNETOTONCPOFecha = new DateTime[] {DateTime.MinValue} ;
         T001411_A84PRECNETOTONCPOMes = new short[1] ;
         T001411_A85PRECNETOTONCPOAno = new short[1] ;
         T001411_A5Cod_Area = new string[] {""} ;
         T001411_A4IndicadoresCodigo = new string[] {""} ;
         T001411_A67MOTIVOSPRENETCodigo = new string[] {""} ;
         T00143_A83PRECNETOTONCPOFecha = new DateTime[] {DateTime.MinValue} ;
         T00143_A84PRECNETOTONCPOMes = new short[1] ;
         T00143_A85PRECNETOTONCPOAno = new short[1] ;
         T00143_A203PRECNETOTONCPOValor = new decimal[1] ;
         T00143_A5Cod_Area = new string[] {""} ;
         T00143_A4IndicadoresCodigo = new string[] {""} ;
         T00143_A67MOTIVOSPRENETCodigo = new string[] {""} ;
         sMode41 = "";
         T001412_A83PRECNETOTONCPOFecha = new DateTime[] {DateTime.MinValue} ;
         T001412_A84PRECNETOTONCPOMes = new short[1] ;
         T001412_A85PRECNETOTONCPOAno = new short[1] ;
         T001412_A5Cod_Area = new string[] {""} ;
         T001412_A4IndicadoresCodigo = new string[] {""} ;
         T001412_A67MOTIVOSPRENETCodigo = new string[] {""} ;
         T001413_A83PRECNETOTONCPOFecha = new DateTime[] {DateTime.MinValue} ;
         T001413_A84PRECNETOTONCPOMes = new short[1] ;
         T001413_A85PRECNETOTONCPOAno = new short[1] ;
         T001413_A5Cod_Area = new string[] {""} ;
         T001413_A4IndicadoresCodigo = new string[] {""} ;
         T001413_A67MOTIVOSPRENETCodigo = new string[] {""} ;
         T00142_A83PRECNETOTONCPOFecha = new DateTime[] {DateTime.MinValue} ;
         T00142_A84PRECNETOTONCPOMes = new short[1] ;
         T00142_A85PRECNETOTONCPOAno = new short[1] ;
         T00142_A203PRECNETOTONCPOValor = new decimal[1] ;
         T00142_A5Cod_Area = new string[] {""} ;
         T00142_A4IndicadoresCodigo = new string[] {""} ;
         T00142_A67MOTIVOSPRENETCodigo = new string[] {""} ;
         T001417_A83PRECNETOTONCPOFecha = new DateTime[] {DateTime.MinValue} ;
         T001417_A84PRECNETOTONCPOMes = new short[1] ;
         T001417_A85PRECNETOTONCPOAno = new short[1] ;
         T001417_A5Cod_Area = new string[] {""} ;
         T001417_A4IndicadoresCodigo = new string[] {""} ;
         T001417_A67MOTIVOSPRENETCodigo = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T001418_A5Cod_Area = new string[] {""} ;
         T001419_A4IndicadoresCodigo = new string[] {""} ;
         T001420_A67MOTIVOSPRENETCodigo = new string[] {""} ;
         ZZ83PRECNETOTONCPOFecha = DateTime.MinValue;
         ZZ5Cod_Area = "";
         ZZ4IndicadoresCodigo = "";
         ZZ67MOTIVOSPRENETCodigo = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.precnetotoncpo__default(),
            new Object[][] {
                new Object[] {
               T00142_A83PRECNETOTONCPOFecha, T00142_A84PRECNETOTONCPOMes, T00142_A85PRECNETOTONCPOAno, T00142_A203PRECNETOTONCPOValor, T00142_A5Cod_Area, T00142_A4IndicadoresCodigo, T00142_A67MOTIVOSPRENETCodigo
               }
               , new Object[] {
               T00143_A83PRECNETOTONCPOFecha, T00143_A84PRECNETOTONCPOMes, T00143_A85PRECNETOTONCPOAno, T00143_A203PRECNETOTONCPOValor, T00143_A5Cod_Area, T00143_A4IndicadoresCodigo, T00143_A67MOTIVOSPRENETCodigo
               }
               , new Object[] {
               T00144_A5Cod_Area
               }
               , new Object[] {
               T00145_A4IndicadoresCodigo
               }
               , new Object[] {
               T00146_A67MOTIVOSPRENETCodigo
               }
               , new Object[] {
               T00147_A83PRECNETOTONCPOFecha, T00147_A84PRECNETOTONCPOMes, T00147_A85PRECNETOTONCPOAno, T00147_A203PRECNETOTONCPOValor, T00147_A5Cod_Area, T00147_A4IndicadoresCodigo, T00147_A67MOTIVOSPRENETCodigo
               }
               , new Object[] {
               T00148_A5Cod_Area
               }
               , new Object[] {
               T00149_A4IndicadoresCodigo
               }
               , new Object[] {
               T001410_A67MOTIVOSPRENETCodigo
               }
               , new Object[] {
               T001411_A83PRECNETOTONCPOFecha, T001411_A84PRECNETOTONCPOMes, T001411_A85PRECNETOTONCPOAno, T001411_A5Cod_Area, T001411_A4IndicadoresCodigo, T001411_A67MOTIVOSPRENETCodigo
               }
               , new Object[] {
               T001412_A83PRECNETOTONCPOFecha, T001412_A84PRECNETOTONCPOMes, T001412_A85PRECNETOTONCPOAno, T001412_A5Cod_Area, T001412_A4IndicadoresCodigo, T001412_A67MOTIVOSPRENETCodigo
               }
               , new Object[] {
               T001413_A83PRECNETOTONCPOFecha, T001413_A84PRECNETOTONCPOMes, T001413_A85PRECNETOTONCPOAno, T001413_A5Cod_Area, T001413_A4IndicadoresCodigo, T001413_A67MOTIVOSPRENETCodigo
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001417_A83PRECNETOTONCPOFecha, T001417_A84PRECNETOTONCPOMes, T001417_A85PRECNETOTONCPOAno, T001417_A5Cod_Area, T001417_A4IndicadoresCodigo, T001417_A67MOTIVOSPRENETCodigo
               }
               , new Object[] {
               T001418_A5Cod_Area
               }
               , new Object[] {
               T001419_A4IndicadoresCodigo
               }
               , new Object[] {
               T001420_A67MOTIVOSPRENETCodigo
               }
            }
         );
      }

      private short Z84PRECNETOTONCPOMes ;
      private short Z85PRECNETOTONCPOAno ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A84PRECNETOTONCPOMes ;
      private short A85PRECNETOTONCPOAno ;
      private short GX_JID ;
      private short RcdFound41 ;
      private short nIsDirty_41 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ84PRECNETOTONCPOMes ;
      private short ZZ85PRECNETOTONCPOAno ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtPRECNETOTONCPOFecha_Enabled ;
      private int edtPRECNETOTONCPOMes_Enabled ;
      private int edtPRECNETOTONCPOAno_Enabled ;
      private int edtCod_Area_Enabled ;
      private int imgprompt_5_Visible ;
      private int edtIndicadoresCodigo_Enabled ;
      private int imgprompt_4_Visible ;
      private int edtMOTIVOSPRENETCodigo_Enabled ;
      private int imgprompt_67_Visible ;
      private int edtPRECNETOTONCPOValor_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private decimal Z203PRECNETOTONCPOValor ;
      private decimal A203PRECNETOTONCPOValor ;
      private decimal ZZ203PRECNETOTONCPOValor ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPRECNETOTONCPOFecha_Internalname ;
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
      private string edtPRECNETOTONCPOFecha_Jsonclick ;
      private string edtPRECNETOTONCPOMes_Internalname ;
      private string edtPRECNETOTONCPOMes_Jsonclick ;
      private string edtPRECNETOTONCPOAno_Internalname ;
      private string edtPRECNETOTONCPOAno_Jsonclick ;
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
      private string edtMOTIVOSPRENETCodigo_Internalname ;
      private string imgprompt_67_gximage ;
      private string imgprompt_67_Internalname ;
      private string imgprompt_67_Link ;
      private string edtPRECNETOTONCPOValor_Internalname ;
      private string edtPRECNETOTONCPOValor_Jsonclick ;
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
      private string sMode41 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z83PRECNETOTONCPOFecha ;
      private DateTime A83PRECNETOTONCPOFecha ;
      private DateTime ZZ83PRECNETOTONCPOFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string Z5Cod_Area ;
      private string Z4IndicadoresCodigo ;
      private string Z67MOTIVOSPRENETCodigo ;
      private string A5Cod_Area ;
      private string A4IndicadoresCodigo ;
      private string A67MOTIVOSPRENETCodigo ;
      private string ZZ5Cod_Area ;
      private string ZZ4IndicadoresCodigo ;
      private string ZZ67MOTIVOSPRENETCodigo ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] T00147_A83PRECNETOTONCPOFecha ;
      private short[] T00147_A84PRECNETOTONCPOMes ;
      private short[] T00147_A85PRECNETOTONCPOAno ;
      private decimal[] T00147_A203PRECNETOTONCPOValor ;
      private string[] T00147_A5Cod_Area ;
      private string[] T00147_A4IndicadoresCodigo ;
      private string[] T00147_A67MOTIVOSPRENETCodigo ;
      private string[] T00144_A5Cod_Area ;
      private string[] T00145_A4IndicadoresCodigo ;
      private string[] T00146_A67MOTIVOSPRENETCodigo ;
      private string[] T00148_A5Cod_Area ;
      private string[] T00149_A4IndicadoresCodigo ;
      private string[] T001410_A67MOTIVOSPRENETCodigo ;
      private DateTime[] T001411_A83PRECNETOTONCPOFecha ;
      private short[] T001411_A84PRECNETOTONCPOMes ;
      private short[] T001411_A85PRECNETOTONCPOAno ;
      private string[] T001411_A5Cod_Area ;
      private string[] T001411_A4IndicadoresCodigo ;
      private string[] T001411_A67MOTIVOSPRENETCodigo ;
      private DateTime[] T00143_A83PRECNETOTONCPOFecha ;
      private short[] T00143_A84PRECNETOTONCPOMes ;
      private short[] T00143_A85PRECNETOTONCPOAno ;
      private decimal[] T00143_A203PRECNETOTONCPOValor ;
      private string[] T00143_A5Cod_Area ;
      private string[] T00143_A4IndicadoresCodigo ;
      private string[] T00143_A67MOTIVOSPRENETCodigo ;
      private DateTime[] T001412_A83PRECNETOTONCPOFecha ;
      private short[] T001412_A84PRECNETOTONCPOMes ;
      private short[] T001412_A85PRECNETOTONCPOAno ;
      private string[] T001412_A5Cod_Area ;
      private string[] T001412_A4IndicadoresCodigo ;
      private string[] T001412_A67MOTIVOSPRENETCodigo ;
      private DateTime[] T001413_A83PRECNETOTONCPOFecha ;
      private short[] T001413_A84PRECNETOTONCPOMes ;
      private short[] T001413_A85PRECNETOTONCPOAno ;
      private string[] T001413_A5Cod_Area ;
      private string[] T001413_A4IndicadoresCodigo ;
      private string[] T001413_A67MOTIVOSPRENETCodigo ;
      private DateTime[] T00142_A83PRECNETOTONCPOFecha ;
      private short[] T00142_A84PRECNETOTONCPOMes ;
      private short[] T00142_A85PRECNETOTONCPOAno ;
      private decimal[] T00142_A203PRECNETOTONCPOValor ;
      private string[] T00142_A5Cod_Area ;
      private string[] T00142_A4IndicadoresCodigo ;
      private string[] T00142_A67MOTIVOSPRENETCodigo ;
      private DateTime[] T001417_A83PRECNETOTONCPOFecha ;
      private short[] T001417_A84PRECNETOTONCPOMes ;
      private short[] T001417_A85PRECNETOTONCPOAno ;
      private string[] T001417_A5Cod_Area ;
      private string[] T001417_A4IndicadoresCodigo ;
      private string[] T001417_A67MOTIVOSPRENETCodigo ;
      private string[] T001418_A5Cod_Area ;
      private string[] T001419_A4IndicadoresCodigo ;
      private string[] T001420_A67MOTIVOSPRENETCodigo ;
      private GXWebForm Form ;
   }

   public class precnetotoncpo__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT00147;
          prmT00147 = new Object[] {
          new ParDef("@PRECNETOTONCPOFecha",GXType.Date,8,0) ,
          new ParDef("@PRECNETOTONCPOMes",GXType.Int16,4,0) ,
          new ParDef("@PRECNETOTONCPOAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MOTIVOSPRENETCodigo",GXType.NVarChar,200,0)
          };
          Object[] prmT00144;
          prmT00144 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT00145;
          prmT00145 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT00146;
          prmT00146 = new Object[] {
          new ParDef("@MOTIVOSPRENETCodigo",GXType.NVarChar,200,0)
          };
          Object[] prmT00148;
          prmT00148 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT00149;
          prmT00149 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT001410;
          prmT001410 = new Object[] {
          new ParDef("@MOTIVOSPRENETCodigo",GXType.NVarChar,200,0)
          };
          Object[] prmT001411;
          prmT001411 = new Object[] {
          new ParDef("@PRECNETOTONCPOFecha",GXType.Date,8,0) ,
          new ParDef("@PRECNETOTONCPOMes",GXType.Int16,4,0) ,
          new ParDef("@PRECNETOTONCPOAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MOTIVOSPRENETCodigo",GXType.NVarChar,200,0)
          };
          Object[] prmT00143;
          prmT00143 = new Object[] {
          new ParDef("@PRECNETOTONCPOFecha",GXType.Date,8,0) ,
          new ParDef("@PRECNETOTONCPOMes",GXType.Int16,4,0) ,
          new ParDef("@PRECNETOTONCPOAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MOTIVOSPRENETCodigo",GXType.NVarChar,200,0)
          };
          Object[] prmT001412;
          prmT001412 = new Object[] {
          new ParDef("@PRECNETOTONCPOFecha",GXType.Date,8,0) ,
          new ParDef("@PRECNETOTONCPOMes",GXType.Int16,4,0) ,
          new ParDef("@PRECNETOTONCPOAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MOTIVOSPRENETCodigo",GXType.NVarChar,200,0)
          };
          Object[] prmT001413;
          prmT001413 = new Object[] {
          new ParDef("@PRECNETOTONCPOFecha",GXType.Date,8,0) ,
          new ParDef("@PRECNETOTONCPOMes",GXType.Int16,4,0) ,
          new ParDef("@PRECNETOTONCPOAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MOTIVOSPRENETCodigo",GXType.NVarChar,200,0)
          };
          Object[] prmT00142;
          prmT00142 = new Object[] {
          new ParDef("@PRECNETOTONCPOFecha",GXType.Date,8,0) ,
          new ParDef("@PRECNETOTONCPOMes",GXType.Int16,4,0) ,
          new ParDef("@PRECNETOTONCPOAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MOTIVOSPRENETCodigo",GXType.NVarChar,200,0)
          };
          Object[] prmT001414;
          prmT001414 = new Object[] {
          new ParDef("@PRECNETOTONCPOFecha",GXType.Date,8,0) ,
          new ParDef("@PRECNETOTONCPOMes",GXType.Int16,4,0) ,
          new ParDef("@PRECNETOTONCPOAno",GXType.Int16,4,0) ,
          new ParDef("@PRECNETOTONCPOValor",GXType.Decimal,16,2) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MOTIVOSPRENETCodigo",GXType.NVarChar,200,0)
          };
          Object[] prmT001415;
          prmT001415 = new Object[] {
          new ParDef("@PRECNETOTONCPOValor",GXType.Decimal,16,2) ,
          new ParDef("@PRECNETOTONCPOFecha",GXType.Date,8,0) ,
          new ParDef("@PRECNETOTONCPOMes",GXType.Int16,4,0) ,
          new ParDef("@PRECNETOTONCPOAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MOTIVOSPRENETCodigo",GXType.NVarChar,200,0)
          };
          Object[] prmT001416;
          prmT001416 = new Object[] {
          new ParDef("@PRECNETOTONCPOFecha",GXType.Date,8,0) ,
          new ParDef("@PRECNETOTONCPOMes",GXType.Int16,4,0) ,
          new ParDef("@PRECNETOTONCPOAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MOTIVOSPRENETCodigo",GXType.NVarChar,200,0)
          };
          Object[] prmT001417;
          prmT001417 = new Object[] {
          };
          Object[] prmT001418;
          prmT001418 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT001419;
          prmT001419 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT001420;
          prmT001420 = new Object[] {
          new ParDef("@MOTIVOSPRENETCodigo",GXType.NVarChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00142", "SELECT [PRECNETOTONCPOFecha], [PRECNETOTONCPOMes], [PRECNETOTONCPOAno], [PRECNETOTONCPOValor], [Cod_Area], [IndicadoresCodigo], [MOTIVOSPRENETCodigo] FROM [PRECNETOTONCPO] WITH (UPDLOCK) WHERE [PRECNETOTONCPOFecha] = @PRECNETOTONCPOFecha AND [PRECNETOTONCPOMes] = @PRECNETOTONCPOMes AND [PRECNETOTONCPOAno] = @PRECNETOTONCPOAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo AND [MOTIVOSPRENETCodigo] = @MOTIVOSPRENETCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT00142,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00143", "SELECT [PRECNETOTONCPOFecha], [PRECNETOTONCPOMes], [PRECNETOTONCPOAno], [PRECNETOTONCPOValor], [Cod_Area], [IndicadoresCodigo], [MOTIVOSPRENETCodigo] FROM [PRECNETOTONCPO] WHERE [PRECNETOTONCPOFecha] = @PRECNETOTONCPOFecha AND [PRECNETOTONCPOMes] = @PRECNETOTONCPOMes AND [PRECNETOTONCPOAno] = @PRECNETOTONCPOAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo AND [MOTIVOSPRENETCodigo] = @MOTIVOSPRENETCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT00143,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00144", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT00144,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00145", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT00145,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00146", "SELECT [MOTIVOSPRENETCodigo] FROM [MOTIVOSPRENET] WHERE [MOTIVOSPRENETCodigo] = @MOTIVOSPRENETCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT00146,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00147", "SELECT TM1.[PRECNETOTONCPOFecha], TM1.[PRECNETOTONCPOMes], TM1.[PRECNETOTONCPOAno], TM1.[PRECNETOTONCPOValor], TM1.[Cod_Area], TM1.[IndicadoresCodigo], TM1.[MOTIVOSPRENETCodigo] FROM [PRECNETOTONCPO] TM1 WHERE TM1.[PRECNETOTONCPOFecha] = @PRECNETOTONCPOFecha and TM1.[PRECNETOTONCPOMes] = @PRECNETOTONCPOMes and TM1.[PRECNETOTONCPOAno] = @PRECNETOTONCPOAno and TM1.[Cod_Area] = @Cod_Area and TM1.[IndicadoresCodigo] = @IndicadoresCodigo and TM1.[MOTIVOSPRENETCodigo] = @MOTIVOSPRENETCodigo ORDER BY TM1.[PRECNETOTONCPOFecha], TM1.[PRECNETOTONCPOMes], TM1.[PRECNETOTONCPOAno], TM1.[Cod_Area], TM1.[IndicadoresCodigo], TM1.[MOTIVOSPRENETCodigo]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00147,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00148", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT00148,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00149", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT00149,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001410", "SELECT [MOTIVOSPRENETCodigo] FROM [MOTIVOSPRENET] WHERE [MOTIVOSPRENETCodigo] = @MOTIVOSPRENETCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT001410,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001411", "SELECT [PRECNETOTONCPOFecha], [PRECNETOTONCPOMes], [PRECNETOTONCPOAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOSPRENETCodigo] FROM [PRECNETOTONCPO] WHERE [PRECNETOTONCPOFecha] = @PRECNETOTONCPOFecha AND [PRECNETOTONCPOMes] = @PRECNETOTONCPOMes AND [PRECNETOTONCPOAno] = @PRECNETOTONCPOAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo AND [MOTIVOSPRENETCodigo] = @MOTIVOSPRENETCodigo  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001411,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001412", "SELECT TOP 1 [PRECNETOTONCPOFecha], [PRECNETOTONCPOMes], [PRECNETOTONCPOAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOSPRENETCodigo] FROM [PRECNETOTONCPO] WHERE ( [PRECNETOTONCPOFecha] > @PRECNETOTONCPOFecha or [PRECNETOTONCPOFecha] = @PRECNETOTONCPOFecha and [PRECNETOTONCPOMes] > @PRECNETOTONCPOMes or [PRECNETOTONCPOMes] = @PRECNETOTONCPOMes and [PRECNETOTONCPOFecha] = @PRECNETOTONCPOFecha and [PRECNETOTONCPOAno] > @PRECNETOTONCPOAno or [PRECNETOTONCPOAno] = @PRECNETOTONCPOAno and [PRECNETOTONCPOMes] = @PRECNETOTONCPOMes and [PRECNETOTONCPOFecha] = @PRECNETOTONCPOFecha and [Cod_Area] > @Cod_Area or [Cod_Area] = @Cod_Area and [PRECNETOTONCPOAno] = @PRECNETOTONCPOAno and [PRECNETOTONCPOMes] = @PRECNETOTONCPOMes and [PRECNETOTONCPOFecha] = @PRECNETOTONCPOFecha and [IndicadoresCodigo] > @IndicadoresCodigo or [IndicadoresCodigo] = @IndicadoresCodigo and [Cod_Area] = @Cod_Area and [PRECNETOTONCPOAno] = @PRECNETOTONCPOAno and [PRECNETOTONCPOMes] = @PRECNETOTONCPOMes and [PRECNETOTONCPOFecha] = @PRECNETOTONCPOFecha and [MOTIVOSPRENETCodigo] > @MOTIVOSPRENETCodigo) ORDER BY [PRECNETOTONCPOFecha], [PRECNETOTONCPOMes], [PRECNETOTONCPOAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOSPRENETCodigo]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001412,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001413", "SELECT TOP 1 [PRECNETOTONCPOFecha], [PRECNETOTONCPOMes], [PRECNETOTONCPOAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOSPRENETCodigo] FROM [PRECNETOTONCPO] WHERE ( [PRECNETOTONCPOFecha] < @PRECNETOTONCPOFecha or [PRECNETOTONCPOFecha] = @PRECNETOTONCPOFecha and [PRECNETOTONCPOMes] < @PRECNETOTONCPOMes or [PRECNETOTONCPOMes] = @PRECNETOTONCPOMes and [PRECNETOTONCPOFecha] = @PRECNETOTONCPOFecha and [PRECNETOTONCPOAno] < @PRECNETOTONCPOAno or [PRECNETOTONCPOAno] = @PRECNETOTONCPOAno and [PRECNETOTONCPOMes] = @PRECNETOTONCPOMes and [PRECNETOTONCPOFecha] = @PRECNETOTONCPOFecha and [Cod_Area] < @Cod_Area or [Cod_Area] = @Cod_Area and [PRECNETOTONCPOAno] = @PRECNETOTONCPOAno and [PRECNETOTONCPOMes] = @PRECNETOTONCPOMes and [PRECNETOTONCPOFecha] = @PRECNETOTONCPOFecha and [IndicadoresCodigo] < @IndicadoresCodigo or [IndicadoresCodigo] = @IndicadoresCodigo and [Cod_Area] = @Cod_Area and [PRECNETOTONCPOAno] = @PRECNETOTONCPOAno and [PRECNETOTONCPOMes] = @PRECNETOTONCPOMes and [PRECNETOTONCPOFecha] = @PRECNETOTONCPOFecha and [MOTIVOSPRENETCodigo] < @MOTIVOSPRENETCodigo) ORDER BY [PRECNETOTONCPOFecha] DESC, [PRECNETOTONCPOMes] DESC, [PRECNETOTONCPOAno] DESC, [Cod_Area] DESC, [IndicadoresCodigo] DESC, [MOTIVOSPRENETCodigo] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001413,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001414", "INSERT INTO [PRECNETOTONCPO]([PRECNETOTONCPOFecha], [PRECNETOTONCPOMes], [PRECNETOTONCPOAno], [PRECNETOTONCPOValor], [Cod_Area], [IndicadoresCodigo], [MOTIVOSPRENETCodigo]) VALUES(@PRECNETOTONCPOFecha, @PRECNETOTONCPOMes, @PRECNETOTONCPOAno, @PRECNETOTONCPOValor, @Cod_Area, @IndicadoresCodigo, @MOTIVOSPRENETCodigo)", GxErrorMask.GX_NOMASK,prmT001414)
             ,new CursorDef("T001415", "UPDATE [PRECNETOTONCPO] SET [PRECNETOTONCPOValor]=@PRECNETOTONCPOValor  WHERE [PRECNETOTONCPOFecha] = @PRECNETOTONCPOFecha AND [PRECNETOTONCPOMes] = @PRECNETOTONCPOMes AND [PRECNETOTONCPOAno] = @PRECNETOTONCPOAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo AND [MOTIVOSPRENETCodigo] = @MOTIVOSPRENETCodigo", GxErrorMask.GX_NOMASK,prmT001415)
             ,new CursorDef("T001416", "DELETE FROM [PRECNETOTONCPO]  WHERE [PRECNETOTONCPOFecha] = @PRECNETOTONCPOFecha AND [PRECNETOTONCPOMes] = @PRECNETOTONCPOMes AND [PRECNETOTONCPOAno] = @PRECNETOTONCPOAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo AND [MOTIVOSPRENETCodigo] = @MOTIVOSPRENETCodigo", GxErrorMask.GX_NOMASK,prmT001416)
             ,new CursorDef("T001417", "SELECT [PRECNETOTONCPOFecha], [PRECNETOTONCPOMes], [PRECNETOTONCPOAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOSPRENETCodigo] FROM [PRECNETOTONCPO] ORDER BY [PRECNETOTONCPOFecha], [PRECNETOTONCPOMes], [PRECNETOTONCPOAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOSPRENETCodigo]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001417,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001418", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT001418,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001419", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT001419,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001420", "SELECT [MOTIVOSPRENETCodigo] FROM [MOTIVOSPRENET] WHERE [MOTIVOSPRENETCodigo] = @MOTIVOSPRENETCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT001420,1, GxCacheFrequency.OFF ,true,false )
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
