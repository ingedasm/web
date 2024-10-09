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
   public class trif : GXDataArea
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
            Form.Meta.addItem("description", "TRIF", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTRIFFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("IndicadroresPalmas", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public trif( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("IndicadroresPalmas", true);
      }

      public trif( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "TRIF", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_TRIF.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TRIF.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_TRIF.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_TRIF.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TRIF.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 4, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx00a0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"TRIFFECHA"+"'), id:'"+"TRIFFECHA"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"TRIFMES"+"'), id:'"+"TRIFMES"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"TRIFANO"+"'), id:'"+"TRIFANO"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"INDICADORESCODIGO"+"'), id:'"+"INDICADORESCODIGO"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"COD_AREA"+"'), id:'"+"COD_AREA"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_TRIF.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTRIFFecha_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTRIFFecha_Internalname, "TRIFFecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTRIFFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTRIFFecha_Internalname, context.localUtil.Format(A24TRIFFecha, "99/99/99"), context.localUtil.Format( A24TRIFFecha, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTRIFFecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTRIFFecha_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_TRIF.htm");
         GxWebStd.gx_bitmap( context, edtTRIFFecha_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTRIFFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TRIF.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTRIFMes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTRIFMes_Internalname, "TRIFMes", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTRIFMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A25TRIFMes), 4, 0, ",", "")), StringUtil.LTrim( ((edtTRIFMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A25TRIFMes), "ZZZ9") : context.localUtil.Format( (decimal)(A25TRIFMes), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTRIFMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTRIFMes_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_TRIF.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTRIFAno_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTRIFAno_Internalname, "TRIFAno", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTRIFAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A26TRIFAno), 4, 0, ",", "")), StringUtil.LTrim( ((edtTRIFAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A26TRIFAno), "ZZZ9") : context.localUtil.Format( (decimal)(A26TRIFAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTRIFAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTRIFAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_TRIF.htm");
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
         GxWebStd.gx_single_line_edit( context, edtIndicadoresCodigo_Internalname, A4IndicadoresCodigo, StringUtil.RTrim( context.localUtil.Format( A4IndicadoresCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIndicadoresCodigo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIndicadoresCodigo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_TRIF.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_4_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_4_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_4_Internalname, sImgUrl, imgprompt_4_Link, "", "", context.GetTheme( ), imgprompt_4_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_TRIF.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCod_Area_Internalname, A5Cod_Area, StringUtil.RTrim( context.localUtil.Format( A5Cod_Area, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCod_Area_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCod_Area_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_TRIF.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_5_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_5_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_5_Internalname, sImgUrl, imgprompt_5_Link, "", "", context.GetTheme( ), imgprompt_5_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_TRIF.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTRIF_Valor_ACC_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTRIF_Valor_ACC_Internalname, "TRIF_Valor_ACC", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTRIF_Valor_ACC_Internalname, StringUtil.LTrim( StringUtil.NToC( A132TRIF_Valor_ACC, 12, 2, ",", "")), StringUtil.LTrim( ((edtTRIF_Valor_ACC_Enabled!=0) ? context.localUtil.Format( A132TRIF_Valor_ACC, "ZZZZZZZZ9.99") : context.localUtil.Format( A132TRIF_Valor_ACC, "ZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTRIF_Valor_ACC_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTRIF_Valor_ACC_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_TRIF.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTRIF_Valor_TRAB_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTRIF_Valor_TRAB_Internalname, "TRIF_Valor_TRAB", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTRIF_Valor_TRAB_Internalname, StringUtil.LTrim( StringUtil.NToC( A133TRIF_Valor_TRAB, 12, 2, ",", "")), StringUtil.LTrim( ((edtTRIF_Valor_TRAB_Enabled!=0) ? context.localUtil.Format( A133TRIF_Valor_TRAB, "ZZZZZZZZ9.99") : context.localUtil.Format( A133TRIF_Valor_TRAB, "ZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTRIF_Valor_TRAB_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTRIF_Valor_TRAB_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_TRIF.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTRIF_Dias_PerdidosAtel_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTRIF_Dias_PerdidosAtel_Internalname, "Atel", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTRIF_Dias_PerdidosAtel_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A289TRIF_Dias_PerdidosAtel), 12, 0, ",", "")), StringUtil.LTrim( ((edtTRIF_Dias_PerdidosAtel_Enabled!=0) ? context.localUtil.Format( (decimal)(A289TRIF_Dias_PerdidosAtel), "ZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A289TRIF_Dias_PerdidosAtel), "ZZZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTRIF_Dias_PerdidosAtel_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTRIF_Dias_PerdidosAtel_Enabled, 0, "text", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_TRIF.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_TRIF.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_TRIF.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_TRIF.htm");
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
            Z24TRIFFecha = context.localUtil.CToD( cgiGet( "Z24TRIFFecha"), 0);
            Z25TRIFMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z25TRIFMes"), ",", "."), 18, MidpointRounding.ToEven));
            Z26TRIFAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z26TRIFAno"), ",", "."), 18, MidpointRounding.ToEven));
            Z4IndicadoresCodigo = cgiGet( "Z4IndicadoresCodigo");
            Z5Cod_Area = cgiGet( "Z5Cod_Area");
            Z132TRIF_Valor_ACC = context.localUtil.CToN( cgiGet( "Z132TRIF_Valor_ACC"), ",", ".");
            Z133TRIF_Valor_TRAB = context.localUtil.CToN( cgiGet( "Z133TRIF_Valor_TRAB"), ",", ".");
            Z289TRIF_Dias_PerdidosAtel = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z289TRIF_Dias_PerdidosAtel"), ",", "."), 18, MidpointRounding.ToEven));
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( context.localUtil.VCDate( cgiGet( edtTRIFFecha_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"TRIFFecha"}), 1, "TRIFFECHA");
               AnyError = 1;
               GX_FocusControl = edtTRIFFecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A24TRIFFecha = DateTime.MinValue;
               AssignAttri("", false, "A24TRIFFecha", context.localUtil.Format(A24TRIFFecha, "99/99/99"));
            }
            else
            {
               A24TRIFFecha = context.localUtil.CToD( cgiGet( edtTRIFFecha_Internalname), 2);
               AssignAttri("", false, "A24TRIFFecha", context.localUtil.Format(A24TRIFFecha, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtTRIFMes_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTRIFMes_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TRIFMES");
               AnyError = 1;
               GX_FocusControl = edtTRIFMes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A25TRIFMes = 0;
               AssignAttri("", false, "A25TRIFMes", StringUtil.LTrimStr( (decimal)(A25TRIFMes), 4, 0));
            }
            else
            {
               A25TRIFMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtTRIFMes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A25TRIFMes", StringUtil.LTrimStr( (decimal)(A25TRIFMes), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtTRIFAno_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTRIFAno_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TRIFANO");
               AnyError = 1;
               GX_FocusControl = edtTRIFAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A26TRIFAno = 0;
               AssignAttri("", false, "A26TRIFAno", StringUtil.LTrimStr( (decimal)(A26TRIFAno), 4, 0));
            }
            else
            {
               A26TRIFAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtTRIFAno_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A26TRIFAno", StringUtil.LTrimStr( (decimal)(A26TRIFAno), 4, 0));
            }
            A4IndicadoresCodigo = cgiGet( edtIndicadoresCodigo_Internalname);
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A5Cod_Area = cgiGet( edtCod_Area_Internalname);
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            if ( ( ( context.localUtil.CToN( cgiGet( edtTRIF_Valor_ACC_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTRIF_Valor_ACC_Internalname), ",", ".") > 999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TRIF_VALOR_ACC");
               AnyError = 1;
               GX_FocusControl = edtTRIF_Valor_ACC_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A132TRIF_Valor_ACC = 0;
               AssignAttri("", false, "A132TRIF_Valor_ACC", StringUtil.LTrimStr( A132TRIF_Valor_ACC, 12, 2));
            }
            else
            {
               A132TRIF_Valor_ACC = context.localUtil.CToN( cgiGet( edtTRIF_Valor_ACC_Internalname), ",", ".");
               AssignAttri("", false, "A132TRIF_Valor_ACC", StringUtil.LTrimStr( A132TRIF_Valor_ACC, 12, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtTRIF_Valor_TRAB_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTRIF_Valor_TRAB_Internalname), ",", ".") > 999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TRIF_VALOR_TRAB");
               AnyError = 1;
               GX_FocusControl = edtTRIF_Valor_TRAB_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A133TRIF_Valor_TRAB = 0;
               AssignAttri("", false, "A133TRIF_Valor_TRAB", StringUtil.LTrimStr( A133TRIF_Valor_TRAB, 12, 2));
            }
            else
            {
               A133TRIF_Valor_TRAB = context.localUtil.CToN( cgiGet( edtTRIF_Valor_TRAB_Internalname), ",", ".");
               AssignAttri("", false, "A133TRIF_Valor_TRAB", StringUtil.LTrimStr( A133TRIF_Valor_TRAB, 12, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtTRIF_Dias_PerdidosAtel_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTRIF_Dias_PerdidosAtel_Internalname), ",", ".") > Convert.ToDecimal( 999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TRIF_DIAS_PERDIDOSATEL");
               AnyError = 1;
               GX_FocusControl = edtTRIF_Dias_PerdidosAtel_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A289TRIF_Dias_PerdidosAtel = 0;
               AssignAttri("", false, "A289TRIF_Dias_PerdidosAtel", StringUtil.LTrimStr( (decimal)(A289TRIF_Dias_PerdidosAtel), 12, 0));
            }
            else
            {
               A289TRIF_Dias_PerdidosAtel = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtTRIF_Dias_PerdidosAtel_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A289TRIF_Dias_PerdidosAtel", StringUtil.LTrimStr( (decimal)(A289TRIF_Dias_PerdidosAtel), 12, 0));
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
               A24TRIFFecha = context.localUtil.ParseDateParm( GetPar( "TRIFFecha"));
               AssignAttri("", false, "A24TRIFFecha", context.localUtil.Format(A24TRIFFecha, "99/99/99"));
               A25TRIFMes = (short)(Math.Round(NumberUtil.Val( GetPar( "TRIFMes"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A25TRIFMes", StringUtil.LTrimStr( (decimal)(A25TRIFMes), 4, 0));
               A26TRIFAno = (short)(Math.Round(NumberUtil.Val( GetPar( "TRIFAno"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A26TRIFAno", StringUtil.LTrimStr( (decimal)(A26TRIFAno), 4, 0));
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
               InitAll0910( ) ;
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
         DisableAttributes0910( ) ;
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

      protected void ResetCaption090( )
      {
      }

      protected void ZM0910( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z132TRIF_Valor_ACC = T00093_A132TRIF_Valor_ACC[0];
               Z133TRIF_Valor_TRAB = T00093_A133TRIF_Valor_TRAB[0];
               Z289TRIF_Dias_PerdidosAtel = T00093_A289TRIF_Dias_PerdidosAtel[0];
            }
            else
            {
               Z132TRIF_Valor_ACC = A132TRIF_Valor_ACC;
               Z133TRIF_Valor_TRAB = A133TRIF_Valor_TRAB;
               Z289TRIF_Dias_PerdidosAtel = A289TRIF_Dias_PerdidosAtel;
            }
         }
         if ( GX_JID == -2 )
         {
            Z24TRIFFecha = A24TRIFFecha;
            Z25TRIFMes = A25TRIFMes;
            Z26TRIFAno = A26TRIFAno;
            Z132TRIF_Valor_ACC = A132TRIF_Valor_ACC;
            Z133TRIF_Valor_TRAB = A133TRIF_Valor_TRAB;
            Z289TRIF_Dias_PerdidosAtel = A289TRIF_Dias_PerdidosAtel;
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

      protected void Load0910( )
      {
         /* Using cursor T00096 */
         pr_default.execute(4, new Object[] {A24TRIFFecha, A25TRIFMes, A26TRIFAno, A4IndicadoresCodigo, A5Cod_Area});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound10 = 1;
            A132TRIF_Valor_ACC = T00096_A132TRIF_Valor_ACC[0];
            AssignAttri("", false, "A132TRIF_Valor_ACC", StringUtil.LTrimStr( A132TRIF_Valor_ACC, 12, 2));
            A133TRIF_Valor_TRAB = T00096_A133TRIF_Valor_TRAB[0];
            AssignAttri("", false, "A133TRIF_Valor_TRAB", StringUtil.LTrimStr( A133TRIF_Valor_TRAB, 12, 2));
            A289TRIF_Dias_PerdidosAtel = T00096_A289TRIF_Dias_PerdidosAtel[0];
            AssignAttri("", false, "A289TRIF_Dias_PerdidosAtel", StringUtil.LTrimStr( (decimal)(A289TRIF_Dias_PerdidosAtel), 12, 0));
            ZM0910( -2) ;
         }
         pr_default.close(4);
         OnLoadActions0910( ) ;
      }

      protected void OnLoadActions0910( )
      {
      }

      protected void CheckExtendedTable0910( )
      {
         nIsDirty_10 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A24TRIFFecha) || ( DateTimeUtil.ResetTime ( A24TRIFFecha ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo TRIFFecha fuera de rango", "OutOfRange", 1, "TRIFFECHA");
            AnyError = 1;
            GX_FocusControl = edtTRIFFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00094 */
         pr_default.execute(2, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T00095 */
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

      protected void CloseExtendedTableCursors0910( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( string A4IndicadoresCodigo )
      {
         /* Using cursor T00097 */
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
         /* Using cursor T00098 */
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

      protected void GetKey0910( )
      {
         /* Using cursor T00099 */
         pr_default.execute(7, new Object[] {A24TRIFFecha, A25TRIFMes, A26TRIFAno, A4IndicadoresCodigo, A5Cod_Area});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound10 = 1;
         }
         else
         {
            RcdFound10 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00093 */
         pr_default.execute(1, new Object[] {A24TRIFFecha, A25TRIFMes, A26TRIFAno, A4IndicadoresCodigo, A5Cod_Area});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0910( 2) ;
            RcdFound10 = 1;
            A24TRIFFecha = T00093_A24TRIFFecha[0];
            AssignAttri("", false, "A24TRIFFecha", context.localUtil.Format(A24TRIFFecha, "99/99/99"));
            A25TRIFMes = T00093_A25TRIFMes[0];
            AssignAttri("", false, "A25TRIFMes", StringUtil.LTrimStr( (decimal)(A25TRIFMes), 4, 0));
            A26TRIFAno = T00093_A26TRIFAno[0];
            AssignAttri("", false, "A26TRIFAno", StringUtil.LTrimStr( (decimal)(A26TRIFAno), 4, 0));
            A132TRIF_Valor_ACC = T00093_A132TRIF_Valor_ACC[0];
            AssignAttri("", false, "A132TRIF_Valor_ACC", StringUtil.LTrimStr( A132TRIF_Valor_ACC, 12, 2));
            A133TRIF_Valor_TRAB = T00093_A133TRIF_Valor_TRAB[0];
            AssignAttri("", false, "A133TRIF_Valor_TRAB", StringUtil.LTrimStr( A133TRIF_Valor_TRAB, 12, 2));
            A289TRIF_Dias_PerdidosAtel = T00093_A289TRIF_Dias_PerdidosAtel[0];
            AssignAttri("", false, "A289TRIF_Dias_PerdidosAtel", StringUtil.LTrimStr( (decimal)(A289TRIF_Dias_PerdidosAtel), 12, 0));
            A4IndicadoresCodigo = T00093_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A5Cod_Area = T00093_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            Z24TRIFFecha = A24TRIFFecha;
            Z25TRIFMes = A25TRIFMes;
            Z26TRIFAno = A26TRIFAno;
            Z4IndicadoresCodigo = A4IndicadoresCodigo;
            Z5Cod_Area = A5Cod_Area;
            sMode10 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0910( ) ;
            if ( AnyError == 1 )
            {
               RcdFound10 = 0;
               InitializeNonKey0910( ) ;
            }
            Gx_mode = sMode10;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound10 = 0;
            InitializeNonKey0910( ) ;
            sMode10 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode10;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0910( ) ;
         if ( RcdFound10 == 0 )
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
         RcdFound10 = 0;
         /* Using cursor T000910 */
         pr_default.execute(8, new Object[] {A24TRIFFecha, A25TRIFMes, A26TRIFAno, A4IndicadoresCodigo, A5Cod_Area});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( DateTimeUtil.ResetTime ( T000910_A24TRIFFecha[0] ) < DateTimeUtil.ResetTime ( A24TRIFFecha ) ) || ( DateTimeUtil.ResetTime ( T000910_A24TRIFFecha[0] ) == DateTimeUtil.ResetTime ( A24TRIFFecha ) ) && ( T000910_A25TRIFMes[0] < A25TRIFMes ) || ( T000910_A25TRIFMes[0] == A25TRIFMes ) && ( DateTimeUtil.ResetTime ( T000910_A24TRIFFecha[0] ) == DateTimeUtil.ResetTime ( A24TRIFFecha ) ) && ( T000910_A26TRIFAno[0] < A26TRIFAno ) || ( T000910_A26TRIFAno[0] == A26TRIFAno ) && ( T000910_A25TRIFMes[0] == A25TRIFMes ) && ( DateTimeUtil.ResetTime ( T000910_A24TRIFFecha[0] ) == DateTimeUtil.ResetTime ( A24TRIFFecha ) ) && ( StringUtil.StrCmp(T000910_A4IndicadoresCodigo[0], A4IndicadoresCodigo) < 0 ) || ( StringUtil.StrCmp(T000910_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000910_A26TRIFAno[0] == A26TRIFAno ) && ( T000910_A25TRIFMes[0] == A25TRIFMes ) && ( DateTimeUtil.ResetTime ( T000910_A24TRIFFecha[0] ) == DateTimeUtil.ResetTime ( A24TRIFFecha ) ) && ( StringUtil.StrCmp(T000910_A5Cod_Area[0], A5Cod_Area) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( DateTimeUtil.ResetTime ( T000910_A24TRIFFecha[0] ) > DateTimeUtil.ResetTime ( A24TRIFFecha ) ) || ( DateTimeUtil.ResetTime ( T000910_A24TRIFFecha[0] ) == DateTimeUtil.ResetTime ( A24TRIFFecha ) ) && ( T000910_A25TRIFMes[0] > A25TRIFMes ) || ( T000910_A25TRIFMes[0] == A25TRIFMes ) && ( DateTimeUtil.ResetTime ( T000910_A24TRIFFecha[0] ) == DateTimeUtil.ResetTime ( A24TRIFFecha ) ) && ( T000910_A26TRIFAno[0] > A26TRIFAno ) || ( T000910_A26TRIFAno[0] == A26TRIFAno ) && ( T000910_A25TRIFMes[0] == A25TRIFMes ) && ( DateTimeUtil.ResetTime ( T000910_A24TRIFFecha[0] ) == DateTimeUtil.ResetTime ( A24TRIFFecha ) ) && ( StringUtil.StrCmp(T000910_A4IndicadoresCodigo[0], A4IndicadoresCodigo) > 0 ) || ( StringUtil.StrCmp(T000910_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000910_A26TRIFAno[0] == A26TRIFAno ) && ( T000910_A25TRIFMes[0] == A25TRIFMes ) && ( DateTimeUtil.ResetTime ( T000910_A24TRIFFecha[0] ) == DateTimeUtil.ResetTime ( A24TRIFFecha ) ) && ( StringUtil.StrCmp(T000910_A5Cod_Area[0], A5Cod_Area) > 0 ) ) )
            {
               A24TRIFFecha = T000910_A24TRIFFecha[0];
               AssignAttri("", false, "A24TRIFFecha", context.localUtil.Format(A24TRIFFecha, "99/99/99"));
               A25TRIFMes = T000910_A25TRIFMes[0];
               AssignAttri("", false, "A25TRIFMes", StringUtil.LTrimStr( (decimal)(A25TRIFMes), 4, 0));
               A26TRIFAno = T000910_A26TRIFAno[0];
               AssignAttri("", false, "A26TRIFAno", StringUtil.LTrimStr( (decimal)(A26TRIFAno), 4, 0));
               A4IndicadoresCodigo = T000910_A4IndicadoresCodigo[0];
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               A5Cod_Area = T000910_A5Cod_Area[0];
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               RcdFound10 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound10 = 0;
         /* Using cursor T000911 */
         pr_default.execute(9, new Object[] {A24TRIFFecha, A25TRIFMes, A26TRIFAno, A4IndicadoresCodigo, A5Cod_Area});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( DateTimeUtil.ResetTime ( T000911_A24TRIFFecha[0] ) > DateTimeUtil.ResetTime ( A24TRIFFecha ) ) || ( DateTimeUtil.ResetTime ( T000911_A24TRIFFecha[0] ) == DateTimeUtil.ResetTime ( A24TRIFFecha ) ) && ( T000911_A25TRIFMes[0] > A25TRIFMes ) || ( T000911_A25TRIFMes[0] == A25TRIFMes ) && ( DateTimeUtil.ResetTime ( T000911_A24TRIFFecha[0] ) == DateTimeUtil.ResetTime ( A24TRIFFecha ) ) && ( T000911_A26TRIFAno[0] > A26TRIFAno ) || ( T000911_A26TRIFAno[0] == A26TRIFAno ) && ( T000911_A25TRIFMes[0] == A25TRIFMes ) && ( DateTimeUtil.ResetTime ( T000911_A24TRIFFecha[0] ) == DateTimeUtil.ResetTime ( A24TRIFFecha ) ) && ( StringUtil.StrCmp(T000911_A4IndicadoresCodigo[0], A4IndicadoresCodigo) > 0 ) || ( StringUtil.StrCmp(T000911_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000911_A26TRIFAno[0] == A26TRIFAno ) && ( T000911_A25TRIFMes[0] == A25TRIFMes ) && ( DateTimeUtil.ResetTime ( T000911_A24TRIFFecha[0] ) == DateTimeUtil.ResetTime ( A24TRIFFecha ) ) && ( StringUtil.StrCmp(T000911_A5Cod_Area[0], A5Cod_Area) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( DateTimeUtil.ResetTime ( T000911_A24TRIFFecha[0] ) < DateTimeUtil.ResetTime ( A24TRIFFecha ) ) || ( DateTimeUtil.ResetTime ( T000911_A24TRIFFecha[0] ) == DateTimeUtil.ResetTime ( A24TRIFFecha ) ) && ( T000911_A25TRIFMes[0] < A25TRIFMes ) || ( T000911_A25TRIFMes[0] == A25TRIFMes ) && ( DateTimeUtil.ResetTime ( T000911_A24TRIFFecha[0] ) == DateTimeUtil.ResetTime ( A24TRIFFecha ) ) && ( T000911_A26TRIFAno[0] < A26TRIFAno ) || ( T000911_A26TRIFAno[0] == A26TRIFAno ) && ( T000911_A25TRIFMes[0] == A25TRIFMes ) && ( DateTimeUtil.ResetTime ( T000911_A24TRIFFecha[0] ) == DateTimeUtil.ResetTime ( A24TRIFFecha ) ) && ( StringUtil.StrCmp(T000911_A4IndicadoresCodigo[0], A4IndicadoresCodigo) < 0 ) || ( StringUtil.StrCmp(T000911_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000911_A26TRIFAno[0] == A26TRIFAno ) && ( T000911_A25TRIFMes[0] == A25TRIFMes ) && ( DateTimeUtil.ResetTime ( T000911_A24TRIFFecha[0] ) == DateTimeUtil.ResetTime ( A24TRIFFecha ) ) && ( StringUtil.StrCmp(T000911_A5Cod_Area[0], A5Cod_Area) < 0 ) ) )
            {
               A24TRIFFecha = T000911_A24TRIFFecha[0];
               AssignAttri("", false, "A24TRIFFecha", context.localUtil.Format(A24TRIFFecha, "99/99/99"));
               A25TRIFMes = T000911_A25TRIFMes[0];
               AssignAttri("", false, "A25TRIFMes", StringUtil.LTrimStr( (decimal)(A25TRIFMes), 4, 0));
               A26TRIFAno = T000911_A26TRIFAno[0];
               AssignAttri("", false, "A26TRIFAno", StringUtil.LTrimStr( (decimal)(A26TRIFAno), 4, 0));
               A4IndicadoresCodigo = T000911_A4IndicadoresCodigo[0];
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               A5Cod_Area = T000911_A5Cod_Area[0];
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               RcdFound10 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0910( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTRIFFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0910( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound10 == 1 )
            {
               if ( ( DateTimeUtil.ResetTime ( A24TRIFFecha ) != DateTimeUtil.ResetTime ( Z24TRIFFecha ) ) || ( A25TRIFMes != Z25TRIFMes ) || ( A26TRIFAno != Z26TRIFAno ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) )
               {
                  A24TRIFFecha = Z24TRIFFecha;
                  AssignAttri("", false, "A24TRIFFecha", context.localUtil.Format(A24TRIFFecha, "99/99/99"));
                  A25TRIFMes = Z25TRIFMes;
                  AssignAttri("", false, "A25TRIFMes", StringUtil.LTrimStr( (decimal)(A25TRIFMes), 4, 0));
                  A26TRIFAno = Z26TRIFAno;
                  AssignAttri("", false, "A26TRIFAno", StringUtil.LTrimStr( (decimal)(A26TRIFAno), 4, 0));
                  A4IndicadoresCodigo = Z4IndicadoresCodigo;
                  AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
                  A5Cod_Area = Z5Cod_Area;
                  AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TRIFFECHA");
                  AnyError = 1;
                  GX_FocusControl = edtTRIFFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTRIFFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0910( ) ;
                  GX_FocusControl = edtTRIFFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( DateTimeUtil.ResetTime ( A24TRIFFecha ) != DateTimeUtil.ResetTime ( Z24TRIFFecha ) ) || ( A25TRIFMes != Z25TRIFMes ) || ( A26TRIFAno != Z26TRIFAno ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtTRIFFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0910( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TRIFFECHA");
                     AnyError = 1;
                     GX_FocusControl = edtTRIFFecha_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtTRIFFecha_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0910( ) ;
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
         if ( ( DateTimeUtil.ResetTime ( A24TRIFFecha ) != DateTimeUtil.ResetTime ( Z24TRIFFecha ) ) || ( A25TRIFMes != Z25TRIFMes ) || ( A26TRIFAno != Z26TRIFAno ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) )
         {
            A24TRIFFecha = Z24TRIFFecha;
            AssignAttri("", false, "A24TRIFFecha", context.localUtil.Format(A24TRIFFecha, "99/99/99"));
            A25TRIFMes = Z25TRIFMes;
            AssignAttri("", false, "A25TRIFMes", StringUtil.LTrimStr( (decimal)(A25TRIFMes), 4, 0));
            A26TRIFAno = Z26TRIFAno;
            AssignAttri("", false, "A26TRIFAno", StringUtil.LTrimStr( (decimal)(A26TRIFAno), 4, 0));
            A4IndicadoresCodigo = Z4IndicadoresCodigo;
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A5Cod_Area = Z5Cod_Area;
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TRIFFECHA");
            AnyError = 1;
            GX_FocusControl = edtTRIFFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTRIFFecha_Internalname;
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
         if ( RcdFound10 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "TRIFFECHA");
            AnyError = 1;
            GX_FocusControl = edtTRIFFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtTRIF_Valor_ACC_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0910( ) ;
         if ( RcdFound10 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTRIF_Valor_ACC_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0910( ) ;
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
         if ( RcdFound10 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTRIF_Valor_ACC_Internalname;
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
         if ( RcdFound10 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTRIF_Valor_ACC_Internalname;
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
         ScanStart0910( ) ;
         if ( RcdFound10 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound10 != 0 )
            {
               ScanNext0910( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTRIF_Valor_ACC_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0910( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0910( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00092 */
            pr_default.execute(0, new Object[] {A24TRIFFecha, A25TRIFMes, A26TRIFAno, A4IndicadoresCodigo, A5Cod_Area});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TRIF"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z132TRIF_Valor_ACC != T00092_A132TRIF_Valor_ACC[0] ) || ( Z133TRIF_Valor_TRAB != T00092_A133TRIF_Valor_TRAB[0] ) || ( Z289TRIF_Dias_PerdidosAtel != T00092_A289TRIF_Dias_PerdidosAtel[0] ) )
            {
               if ( Z132TRIF_Valor_ACC != T00092_A132TRIF_Valor_ACC[0] )
               {
                  GXUtil.WriteLog("trif:[seudo value changed for attri]"+"TRIF_Valor_ACC");
                  GXUtil.WriteLogRaw("Old: ",Z132TRIF_Valor_ACC);
                  GXUtil.WriteLogRaw("Current: ",T00092_A132TRIF_Valor_ACC[0]);
               }
               if ( Z133TRIF_Valor_TRAB != T00092_A133TRIF_Valor_TRAB[0] )
               {
                  GXUtil.WriteLog("trif:[seudo value changed for attri]"+"TRIF_Valor_TRAB");
                  GXUtil.WriteLogRaw("Old: ",Z133TRIF_Valor_TRAB);
                  GXUtil.WriteLogRaw("Current: ",T00092_A133TRIF_Valor_TRAB[0]);
               }
               if ( Z289TRIF_Dias_PerdidosAtel != T00092_A289TRIF_Dias_PerdidosAtel[0] )
               {
                  GXUtil.WriteLog("trif:[seudo value changed for attri]"+"TRIF_Dias_PerdidosAtel");
                  GXUtil.WriteLogRaw("Old: ",Z289TRIF_Dias_PerdidosAtel);
                  GXUtil.WriteLogRaw("Current: ",T00092_A289TRIF_Dias_PerdidosAtel[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TRIF"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0910( )
      {
         BeforeValidate0910( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0910( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0910( 0) ;
            CheckOptimisticConcurrency0910( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0910( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0910( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000912 */
                     pr_default.execute(10, new Object[] {A24TRIFFecha, A25TRIFMes, A26TRIFAno, A132TRIF_Valor_ACC, A133TRIF_Valor_TRAB, A289TRIF_Dias_PerdidosAtel, A4IndicadoresCodigo, A5Cod_Area});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("TRIF");
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
                           ResetCaption090( ) ;
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
               Load0910( ) ;
            }
            EndLevel0910( ) ;
         }
         CloseExtendedTableCursors0910( ) ;
      }

      protected void Update0910( )
      {
         BeforeValidate0910( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0910( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0910( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0910( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0910( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000913 */
                     pr_default.execute(11, new Object[] {A132TRIF_Valor_ACC, A133TRIF_Valor_TRAB, A289TRIF_Dias_PerdidosAtel, A24TRIFFecha, A25TRIFMes, A26TRIFAno, A4IndicadoresCodigo, A5Cod_Area});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("TRIF");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TRIF"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0910( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption090( ) ;
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
            EndLevel0910( ) ;
         }
         CloseExtendedTableCursors0910( ) ;
      }

      protected void DeferredUpdate0910( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0910( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0910( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0910( ) ;
            AfterConfirm0910( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0910( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000914 */
                  pr_default.execute(12, new Object[] {A24TRIFFecha, A25TRIFMes, A26TRIFAno, A4IndicadoresCodigo, A5Cod_Area});
                  pr_default.close(12);
                  pr_default.SmartCacheProvider.SetUpdated("TRIF");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound10 == 0 )
                        {
                           InitAll0910( ) ;
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
                        ResetCaption090( ) ;
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
         sMode10 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0910( ) ;
         Gx_mode = sMode10;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0910( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0910( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0910( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("trif",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues090( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("trif",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0910( )
      {
         /* Using cursor T000915 */
         pr_default.execute(13);
         RcdFound10 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound10 = 1;
            A24TRIFFecha = T000915_A24TRIFFecha[0];
            AssignAttri("", false, "A24TRIFFecha", context.localUtil.Format(A24TRIFFecha, "99/99/99"));
            A25TRIFMes = T000915_A25TRIFMes[0];
            AssignAttri("", false, "A25TRIFMes", StringUtil.LTrimStr( (decimal)(A25TRIFMes), 4, 0));
            A26TRIFAno = T000915_A26TRIFAno[0];
            AssignAttri("", false, "A26TRIFAno", StringUtil.LTrimStr( (decimal)(A26TRIFAno), 4, 0));
            A4IndicadoresCodigo = T000915_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A5Cod_Area = T000915_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0910( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound10 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound10 = 1;
            A24TRIFFecha = T000915_A24TRIFFecha[0];
            AssignAttri("", false, "A24TRIFFecha", context.localUtil.Format(A24TRIFFecha, "99/99/99"));
            A25TRIFMes = T000915_A25TRIFMes[0];
            AssignAttri("", false, "A25TRIFMes", StringUtil.LTrimStr( (decimal)(A25TRIFMes), 4, 0));
            A26TRIFAno = T000915_A26TRIFAno[0];
            AssignAttri("", false, "A26TRIFAno", StringUtil.LTrimStr( (decimal)(A26TRIFAno), 4, 0));
            A4IndicadoresCodigo = T000915_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A5Cod_Area = T000915_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
         }
      }

      protected void ScanEnd0910( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm0910( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0910( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0910( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0910( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0910( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0910( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0910( )
      {
         edtTRIFFecha_Enabled = 0;
         AssignProp("", false, edtTRIFFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTRIFFecha_Enabled), 5, 0), true);
         edtTRIFMes_Enabled = 0;
         AssignProp("", false, edtTRIFMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTRIFMes_Enabled), 5, 0), true);
         edtTRIFAno_Enabled = 0;
         AssignProp("", false, edtTRIFAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTRIFAno_Enabled), 5, 0), true);
         edtIndicadoresCodigo_Enabled = 0;
         AssignProp("", false, edtIndicadoresCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIndicadoresCodigo_Enabled), 5, 0), true);
         edtCod_Area_Enabled = 0;
         AssignProp("", false, edtCod_Area_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCod_Area_Enabled), 5, 0), true);
         edtTRIF_Valor_ACC_Enabled = 0;
         AssignProp("", false, edtTRIF_Valor_ACC_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTRIF_Valor_ACC_Enabled), 5, 0), true);
         edtTRIF_Valor_TRAB_Enabled = 0;
         AssignProp("", false, edtTRIF_Valor_TRAB_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTRIF_Valor_TRAB_Enabled), 5, 0), true);
         edtTRIF_Dias_PerdidosAtel_Enabled = 0;
         AssignProp("", false, edtTRIF_Dias_PerdidosAtel_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTRIF_Dias_PerdidosAtel_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0910( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues090( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trif.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z24TRIFFecha", context.localUtil.DToC( Z24TRIFFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z25TRIFMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z25TRIFMes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z26TRIFAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z26TRIFAno), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z4IndicadoresCodigo", Z4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "Z5Cod_Area", Z5Cod_Area);
         GxWebStd.gx_hidden_field( context, "Z132TRIF_Valor_ACC", StringUtil.LTrim( StringUtil.NToC( Z132TRIF_Valor_ACC, 12, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z133TRIF_Valor_TRAB", StringUtil.LTrim( StringUtil.NToC( Z133TRIF_Valor_TRAB, 12, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z289TRIF_Dias_PerdidosAtel", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z289TRIF_Dias_PerdidosAtel), 12, 0, ",", "")));
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
         return formatLink("trif.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "TRIF" ;
      }

      public override string GetPgmdesc( )
      {
         return "TRIF" ;
      }

      protected void InitializeNonKey0910( )
      {
         A132TRIF_Valor_ACC = 0;
         AssignAttri("", false, "A132TRIF_Valor_ACC", StringUtil.LTrimStr( A132TRIF_Valor_ACC, 12, 2));
         A133TRIF_Valor_TRAB = 0;
         AssignAttri("", false, "A133TRIF_Valor_TRAB", StringUtil.LTrimStr( A133TRIF_Valor_TRAB, 12, 2));
         A289TRIF_Dias_PerdidosAtel = 0;
         AssignAttri("", false, "A289TRIF_Dias_PerdidosAtel", StringUtil.LTrimStr( (decimal)(A289TRIF_Dias_PerdidosAtel), 12, 0));
         Z132TRIF_Valor_ACC = 0;
         Z133TRIF_Valor_TRAB = 0;
         Z289TRIF_Dias_PerdidosAtel = 0;
      }

      protected void InitAll0910( )
      {
         A24TRIFFecha = DateTime.MinValue;
         AssignAttri("", false, "A24TRIFFecha", context.localUtil.Format(A24TRIFFecha, "99/99/99"));
         A25TRIFMes = 0;
         AssignAttri("", false, "A25TRIFMes", StringUtil.LTrimStr( (decimal)(A25TRIFMes), 4, 0));
         A26TRIFAno = 0;
         AssignAttri("", false, "A26TRIFAno", StringUtil.LTrimStr( (decimal)(A26TRIFAno), 4, 0));
         A4IndicadoresCodigo = "";
         AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
         A5Cod_Area = "";
         AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
         InitializeNonKey0910( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024723102481", true, true);
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
         context.AddJavascriptSource("trif.js", "?2024723102481", false, true);
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
         edtTRIFFecha_Internalname = "TRIFFECHA";
         edtTRIFMes_Internalname = "TRIFMES";
         edtTRIFAno_Internalname = "TRIFANO";
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO";
         edtCod_Area_Internalname = "COD_AREA";
         edtTRIF_Valor_ACC_Internalname = "TRIF_VALOR_ACC";
         edtTRIF_Valor_TRAB_Internalname = "TRIF_VALOR_TRAB";
         edtTRIF_Dias_PerdidosAtel_Internalname = "TRIF_DIAS_PERDIDOSATEL";
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
         Form.Caption = "TRIF";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtTRIF_Dias_PerdidosAtel_Jsonclick = "";
         edtTRIF_Dias_PerdidosAtel_Enabled = 1;
         edtTRIF_Valor_TRAB_Jsonclick = "";
         edtTRIF_Valor_TRAB_Enabled = 1;
         edtTRIF_Valor_ACC_Jsonclick = "";
         edtTRIF_Valor_ACC_Enabled = 1;
         imgprompt_5_Visible = 1;
         imgprompt_5_Link = "";
         edtCod_Area_Jsonclick = "";
         edtCod_Area_Enabled = 1;
         imgprompt_4_Visible = 1;
         imgprompt_4_Link = "";
         edtIndicadoresCodigo_Jsonclick = "";
         edtIndicadoresCodigo_Enabled = 1;
         edtTRIFAno_Jsonclick = "";
         edtTRIFAno_Enabled = 1;
         edtTRIFMes_Jsonclick = "";
         edtTRIFMes_Enabled = 1;
         edtTRIFFecha_Jsonclick = "";
         edtTRIFFecha_Enabled = 1;
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
         /* Using cursor T000916 */
         pr_default.execute(14, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(14);
         /* Using cursor T000917 */
         pr_default.execute(15, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(15);
         GX_FocusControl = edtTRIF_Valor_ACC_Internalname;
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
         /* Using cursor T000916 */
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
         /* Using cursor T000917 */
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
         AssignAttri("", false, "A132TRIF_Valor_ACC", StringUtil.LTrim( StringUtil.NToC( A132TRIF_Valor_ACC, 12, 2, ".", "")));
         AssignAttri("", false, "A133TRIF_Valor_TRAB", StringUtil.LTrim( StringUtil.NToC( A133TRIF_Valor_TRAB, 12, 2, ".", "")));
         AssignAttri("", false, "A289TRIF_Dias_PerdidosAtel", StringUtil.LTrim( StringUtil.NToC( (decimal)(A289TRIF_Dias_PerdidosAtel), 12, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z24TRIFFecha", context.localUtil.Format(Z24TRIFFecha, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z25TRIFMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z25TRIFMes), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z26TRIFAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z26TRIFAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z4IndicadoresCodigo", Z4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "Z5Cod_Area", Z5Cod_Area);
         GxWebStd.gx_hidden_field( context, "Z132TRIF_Valor_ACC", StringUtil.LTrim( StringUtil.NToC( Z132TRIF_Valor_ACC, 12, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z133TRIF_Valor_TRAB", StringUtil.LTrim( StringUtil.NToC( Z133TRIF_Valor_TRAB, 12, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z289TRIF_Dias_PerdidosAtel", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z289TRIF_Dias_PerdidosAtel), 12, 0, ".", "")));
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
         setEventMetadata("VALID_TRIFFECHA","{handler:'Valid_Triffecha',iparms:[]");
         setEventMetadata("VALID_TRIFFECHA",",oparms:[]}");
         setEventMetadata("VALID_TRIFMES","{handler:'Valid_Trifmes',iparms:[]");
         setEventMetadata("VALID_TRIFMES",",oparms:[]}");
         setEventMetadata("VALID_TRIFANO","{handler:'Valid_Trifano',iparms:[]");
         setEventMetadata("VALID_TRIFANO",",oparms:[]}");
         setEventMetadata("VALID_INDICADORESCODIGO","{handler:'Valid_Indicadorescodigo',iparms:[{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:''}]");
         setEventMetadata("VALID_INDICADORESCODIGO",",oparms:[]}");
         setEventMetadata("VALID_COD_AREA","{handler:'Valid_Cod_area',iparms:[{av:'A24TRIFFecha',fld:'TRIFFECHA',pic:''},{av:'A25TRIFMes',fld:'TRIFMES',pic:'ZZZ9'},{av:'A26TRIFAno',fld:'TRIFANO',pic:'ZZZ9'},{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:''},{av:'A5Cod_Area',fld:'COD_AREA',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_COD_AREA",",oparms:[{av:'A132TRIF_Valor_ACC',fld:'TRIF_VALOR_ACC',pic:'ZZZZZZZZ9.99'},{av:'A133TRIF_Valor_TRAB',fld:'TRIF_VALOR_TRAB',pic:'ZZZZZZZZ9.99'},{av:'A289TRIF_Dias_PerdidosAtel',fld:'TRIF_DIAS_PERDIDOSATEL',pic:'ZZZZZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z24TRIFFecha'},{av:'Z25TRIFMes'},{av:'Z26TRIFAno'},{av:'Z4IndicadoresCodigo'},{av:'Z5Cod_Area'},{av:'Z132TRIF_Valor_ACC'},{av:'Z133TRIF_Valor_TRAB'},{av:'Z289TRIF_Dias_PerdidosAtel'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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
         Z24TRIFFecha = DateTime.MinValue;
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
         A24TRIFFecha = DateTime.MinValue;
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
         T00096_A24TRIFFecha = new DateTime[] {DateTime.MinValue} ;
         T00096_A25TRIFMes = new short[1] ;
         T00096_A26TRIFAno = new short[1] ;
         T00096_A132TRIF_Valor_ACC = new decimal[1] ;
         T00096_A133TRIF_Valor_TRAB = new decimal[1] ;
         T00096_A289TRIF_Dias_PerdidosAtel = new long[1] ;
         T00096_A4IndicadoresCodigo = new string[] {""} ;
         T00096_A5Cod_Area = new string[] {""} ;
         T00094_A4IndicadoresCodigo = new string[] {""} ;
         T00095_A5Cod_Area = new string[] {""} ;
         T00097_A4IndicadoresCodigo = new string[] {""} ;
         T00098_A5Cod_Area = new string[] {""} ;
         T00099_A24TRIFFecha = new DateTime[] {DateTime.MinValue} ;
         T00099_A25TRIFMes = new short[1] ;
         T00099_A26TRIFAno = new short[1] ;
         T00099_A4IndicadoresCodigo = new string[] {""} ;
         T00099_A5Cod_Area = new string[] {""} ;
         T00093_A24TRIFFecha = new DateTime[] {DateTime.MinValue} ;
         T00093_A25TRIFMes = new short[1] ;
         T00093_A26TRIFAno = new short[1] ;
         T00093_A132TRIF_Valor_ACC = new decimal[1] ;
         T00093_A133TRIF_Valor_TRAB = new decimal[1] ;
         T00093_A289TRIF_Dias_PerdidosAtel = new long[1] ;
         T00093_A4IndicadoresCodigo = new string[] {""} ;
         T00093_A5Cod_Area = new string[] {""} ;
         sMode10 = "";
         T000910_A24TRIFFecha = new DateTime[] {DateTime.MinValue} ;
         T000910_A25TRIFMes = new short[1] ;
         T000910_A26TRIFAno = new short[1] ;
         T000910_A4IndicadoresCodigo = new string[] {""} ;
         T000910_A5Cod_Area = new string[] {""} ;
         T000911_A24TRIFFecha = new DateTime[] {DateTime.MinValue} ;
         T000911_A25TRIFMes = new short[1] ;
         T000911_A26TRIFAno = new short[1] ;
         T000911_A4IndicadoresCodigo = new string[] {""} ;
         T000911_A5Cod_Area = new string[] {""} ;
         T00092_A24TRIFFecha = new DateTime[] {DateTime.MinValue} ;
         T00092_A25TRIFMes = new short[1] ;
         T00092_A26TRIFAno = new short[1] ;
         T00092_A132TRIF_Valor_ACC = new decimal[1] ;
         T00092_A133TRIF_Valor_TRAB = new decimal[1] ;
         T00092_A289TRIF_Dias_PerdidosAtel = new long[1] ;
         T00092_A4IndicadoresCodigo = new string[] {""} ;
         T00092_A5Cod_Area = new string[] {""} ;
         T000915_A24TRIFFecha = new DateTime[] {DateTime.MinValue} ;
         T000915_A25TRIFMes = new short[1] ;
         T000915_A26TRIFAno = new short[1] ;
         T000915_A4IndicadoresCodigo = new string[] {""} ;
         T000915_A5Cod_Area = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T000916_A4IndicadoresCodigo = new string[] {""} ;
         T000917_A5Cod_Area = new string[] {""} ;
         ZZ24TRIFFecha = DateTime.MinValue;
         ZZ4IndicadoresCodigo = "";
         ZZ5Cod_Area = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trif__default(),
            new Object[][] {
                new Object[] {
               T00092_A24TRIFFecha, T00092_A25TRIFMes, T00092_A26TRIFAno, T00092_A132TRIF_Valor_ACC, T00092_A133TRIF_Valor_TRAB, T00092_A289TRIF_Dias_PerdidosAtel, T00092_A4IndicadoresCodigo, T00092_A5Cod_Area
               }
               , new Object[] {
               T00093_A24TRIFFecha, T00093_A25TRIFMes, T00093_A26TRIFAno, T00093_A132TRIF_Valor_ACC, T00093_A133TRIF_Valor_TRAB, T00093_A289TRIF_Dias_PerdidosAtel, T00093_A4IndicadoresCodigo, T00093_A5Cod_Area
               }
               , new Object[] {
               T00094_A4IndicadoresCodigo
               }
               , new Object[] {
               T00095_A5Cod_Area
               }
               , new Object[] {
               T00096_A24TRIFFecha, T00096_A25TRIFMes, T00096_A26TRIFAno, T00096_A132TRIF_Valor_ACC, T00096_A133TRIF_Valor_TRAB, T00096_A289TRIF_Dias_PerdidosAtel, T00096_A4IndicadoresCodigo, T00096_A5Cod_Area
               }
               , new Object[] {
               T00097_A4IndicadoresCodigo
               }
               , new Object[] {
               T00098_A5Cod_Area
               }
               , new Object[] {
               T00099_A24TRIFFecha, T00099_A25TRIFMes, T00099_A26TRIFAno, T00099_A4IndicadoresCodigo, T00099_A5Cod_Area
               }
               , new Object[] {
               T000910_A24TRIFFecha, T000910_A25TRIFMes, T000910_A26TRIFAno, T000910_A4IndicadoresCodigo, T000910_A5Cod_Area
               }
               , new Object[] {
               T000911_A24TRIFFecha, T000911_A25TRIFMes, T000911_A26TRIFAno, T000911_A4IndicadoresCodigo, T000911_A5Cod_Area
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000915_A24TRIFFecha, T000915_A25TRIFMes, T000915_A26TRIFAno, T000915_A4IndicadoresCodigo, T000915_A5Cod_Area
               }
               , new Object[] {
               T000916_A4IndicadoresCodigo
               }
               , new Object[] {
               T000917_A5Cod_Area
               }
            }
         );
      }

      private short Z25TRIFMes ;
      private short Z26TRIFAno ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A25TRIFMes ;
      private short A26TRIFAno ;
      private short GX_JID ;
      private short RcdFound10 ;
      private short nIsDirty_10 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ25TRIFMes ;
      private short ZZ26TRIFAno ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtTRIFFecha_Enabled ;
      private int edtTRIFMes_Enabled ;
      private int edtTRIFAno_Enabled ;
      private int edtIndicadoresCodigo_Enabled ;
      private int imgprompt_4_Visible ;
      private int edtCod_Area_Enabled ;
      private int imgprompt_5_Visible ;
      private int edtTRIF_Valor_ACC_Enabled ;
      private int edtTRIF_Valor_TRAB_Enabled ;
      private int edtTRIF_Dias_PerdidosAtel_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z289TRIF_Dias_PerdidosAtel ;
      private long A289TRIF_Dias_PerdidosAtel ;
      private long ZZ289TRIF_Dias_PerdidosAtel ;
      private decimal Z132TRIF_Valor_ACC ;
      private decimal Z133TRIF_Valor_TRAB ;
      private decimal A132TRIF_Valor_ACC ;
      private decimal A133TRIF_Valor_TRAB ;
      private decimal ZZ132TRIF_Valor_ACC ;
      private decimal ZZ133TRIF_Valor_TRAB ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTRIFFecha_Internalname ;
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
      private string edtTRIFFecha_Jsonclick ;
      private string edtTRIFMes_Internalname ;
      private string edtTRIFMes_Jsonclick ;
      private string edtTRIFAno_Internalname ;
      private string edtTRIFAno_Jsonclick ;
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
      private string edtTRIF_Valor_ACC_Internalname ;
      private string edtTRIF_Valor_ACC_Jsonclick ;
      private string edtTRIF_Valor_TRAB_Internalname ;
      private string edtTRIF_Valor_TRAB_Jsonclick ;
      private string edtTRIF_Dias_PerdidosAtel_Internalname ;
      private string edtTRIF_Dias_PerdidosAtel_Jsonclick ;
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
      private string sMode10 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z24TRIFFecha ;
      private DateTime A24TRIFFecha ;
      private DateTime ZZ24TRIFFecha ;
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
      private DateTime[] T00096_A24TRIFFecha ;
      private short[] T00096_A25TRIFMes ;
      private short[] T00096_A26TRIFAno ;
      private decimal[] T00096_A132TRIF_Valor_ACC ;
      private decimal[] T00096_A133TRIF_Valor_TRAB ;
      private long[] T00096_A289TRIF_Dias_PerdidosAtel ;
      private string[] T00096_A4IndicadoresCodigo ;
      private string[] T00096_A5Cod_Area ;
      private string[] T00094_A4IndicadoresCodigo ;
      private string[] T00095_A5Cod_Area ;
      private string[] T00097_A4IndicadoresCodigo ;
      private string[] T00098_A5Cod_Area ;
      private DateTime[] T00099_A24TRIFFecha ;
      private short[] T00099_A25TRIFMes ;
      private short[] T00099_A26TRIFAno ;
      private string[] T00099_A4IndicadoresCodigo ;
      private string[] T00099_A5Cod_Area ;
      private DateTime[] T00093_A24TRIFFecha ;
      private short[] T00093_A25TRIFMes ;
      private short[] T00093_A26TRIFAno ;
      private decimal[] T00093_A132TRIF_Valor_ACC ;
      private decimal[] T00093_A133TRIF_Valor_TRAB ;
      private long[] T00093_A289TRIF_Dias_PerdidosAtel ;
      private string[] T00093_A4IndicadoresCodigo ;
      private string[] T00093_A5Cod_Area ;
      private DateTime[] T000910_A24TRIFFecha ;
      private short[] T000910_A25TRIFMes ;
      private short[] T000910_A26TRIFAno ;
      private string[] T000910_A4IndicadoresCodigo ;
      private string[] T000910_A5Cod_Area ;
      private DateTime[] T000911_A24TRIFFecha ;
      private short[] T000911_A25TRIFMes ;
      private short[] T000911_A26TRIFAno ;
      private string[] T000911_A4IndicadoresCodigo ;
      private string[] T000911_A5Cod_Area ;
      private DateTime[] T00092_A24TRIFFecha ;
      private short[] T00092_A25TRIFMes ;
      private short[] T00092_A26TRIFAno ;
      private decimal[] T00092_A132TRIF_Valor_ACC ;
      private decimal[] T00092_A133TRIF_Valor_TRAB ;
      private long[] T00092_A289TRIF_Dias_PerdidosAtel ;
      private string[] T00092_A4IndicadoresCodigo ;
      private string[] T00092_A5Cod_Area ;
      private DateTime[] T000915_A24TRIFFecha ;
      private short[] T000915_A25TRIFMes ;
      private short[] T000915_A26TRIFAno ;
      private string[] T000915_A4IndicadoresCodigo ;
      private string[] T000915_A5Cod_Area ;
      private string[] T000916_A4IndicadoresCodigo ;
      private string[] T000917_A5Cod_Area ;
      private GXWebForm Form ;
   }

   public class trif__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT00096;
          prmT00096 = new Object[] {
          new ParDef("@TRIFFecha",GXType.Date,8,0) ,
          new ParDef("@TRIFMes",GXType.Int16,4,0) ,
          new ParDef("@TRIFAno",GXType.Int16,4,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT00094;
          prmT00094 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT00095;
          prmT00095 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT00097;
          prmT00097 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT00098;
          prmT00098 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT00099;
          prmT00099 = new Object[] {
          new ParDef("@TRIFFecha",GXType.Date,8,0) ,
          new ParDef("@TRIFMes",GXType.Int16,4,0) ,
          new ParDef("@TRIFAno",GXType.Int16,4,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT00093;
          prmT00093 = new Object[] {
          new ParDef("@TRIFFecha",GXType.Date,8,0) ,
          new ParDef("@TRIFMes",GXType.Int16,4,0) ,
          new ParDef("@TRIFAno",GXType.Int16,4,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000910;
          prmT000910 = new Object[] {
          new ParDef("@TRIFFecha",GXType.Date,8,0) ,
          new ParDef("@TRIFMes",GXType.Int16,4,0) ,
          new ParDef("@TRIFAno",GXType.Int16,4,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000911;
          prmT000911 = new Object[] {
          new ParDef("@TRIFFecha",GXType.Date,8,0) ,
          new ParDef("@TRIFMes",GXType.Int16,4,0) ,
          new ParDef("@TRIFAno",GXType.Int16,4,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT00092;
          prmT00092 = new Object[] {
          new ParDef("@TRIFFecha",GXType.Date,8,0) ,
          new ParDef("@TRIFMes",GXType.Int16,4,0) ,
          new ParDef("@TRIFAno",GXType.Int16,4,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000912;
          prmT000912 = new Object[] {
          new ParDef("@TRIFFecha",GXType.Date,8,0) ,
          new ParDef("@TRIFMes",GXType.Int16,4,0) ,
          new ParDef("@TRIFAno",GXType.Int16,4,0) ,
          new ParDef("@TRIF_Valor_ACC",GXType.Decimal,12,2) ,
          new ParDef("@TRIF_Valor_TRAB",GXType.Decimal,12,2) ,
          new ParDef("@TRIF_Dias_PerdidosAtel",GXType.Decimal,12,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000913;
          prmT000913 = new Object[] {
          new ParDef("@TRIF_Valor_ACC",GXType.Decimal,12,2) ,
          new ParDef("@TRIF_Valor_TRAB",GXType.Decimal,12,2) ,
          new ParDef("@TRIF_Dias_PerdidosAtel",GXType.Decimal,12,0) ,
          new ParDef("@TRIFFecha",GXType.Date,8,0) ,
          new ParDef("@TRIFMes",GXType.Int16,4,0) ,
          new ParDef("@TRIFAno",GXType.Int16,4,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000914;
          prmT000914 = new Object[] {
          new ParDef("@TRIFFecha",GXType.Date,8,0) ,
          new ParDef("@TRIFMes",GXType.Int16,4,0) ,
          new ParDef("@TRIFAno",GXType.Int16,4,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000915;
          prmT000915 = new Object[] {
          };
          Object[] prmT000916;
          prmT000916 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000917;
          prmT000917 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00092", "SELECT [TRIFFecha], [TRIFMes], [TRIFAno], [TRIF_Valor_ACC], [TRIF_Valor_TRAB], [TRIF_Dias_PerdidosAtel], [IndicadoresCodigo], [Cod_Area] FROM [TRIF] WITH (UPDLOCK) WHERE [TRIFFecha] = @TRIFFecha AND [TRIFMes] = @TRIFMes AND [TRIFAno] = @TRIFAno AND [IndicadoresCodigo] = @IndicadoresCodigo AND [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT00092,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00093", "SELECT [TRIFFecha], [TRIFMes], [TRIFAno], [TRIF_Valor_ACC], [TRIF_Valor_TRAB], [TRIF_Dias_PerdidosAtel], [IndicadoresCodigo], [Cod_Area] FROM [TRIF] WHERE [TRIFFecha] = @TRIFFecha AND [TRIFMes] = @TRIFMes AND [TRIFAno] = @TRIFAno AND [IndicadoresCodigo] = @IndicadoresCodigo AND [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT00093,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00094", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT00094,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00095", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT00095,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00096", "SELECT TM1.[TRIFFecha], TM1.[TRIFMes], TM1.[TRIFAno], TM1.[TRIF_Valor_ACC], TM1.[TRIF_Valor_TRAB], TM1.[TRIF_Dias_PerdidosAtel], TM1.[IndicadoresCodigo], TM1.[Cod_Area] FROM [TRIF] TM1 WHERE TM1.[TRIFFecha] = @TRIFFecha and TM1.[TRIFMes] = @TRIFMes and TM1.[TRIFAno] = @TRIFAno and TM1.[IndicadoresCodigo] = @IndicadoresCodigo and TM1.[Cod_Area] = @Cod_Area ORDER BY TM1.[TRIFFecha], TM1.[TRIFMes], TM1.[TRIFAno], TM1.[IndicadoresCodigo], TM1.[Cod_Area]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00096,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00097", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT00097,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00098", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT00098,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00099", "SELECT [TRIFFecha], [TRIFMes], [TRIFAno], [IndicadoresCodigo], [Cod_Area] FROM [TRIF] WHERE [TRIFFecha] = @TRIFFecha AND [TRIFMes] = @TRIFMes AND [TRIFAno] = @TRIFAno AND [IndicadoresCodigo] = @IndicadoresCodigo AND [Cod_Area] = @Cod_Area  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00099,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000910", "SELECT TOP 1 [TRIFFecha], [TRIFMes], [TRIFAno], [IndicadoresCodigo], [Cod_Area] FROM [TRIF] WHERE ( [TRIFFecha] > @TRIFFecha or [TRIFFecha] = @TRIFFecha and [TRIFMes] > @TRIFMes or [TRIFMes] = @TRIFMes and [TRIFFecha] = @TRIFFecha and [TRIFAno] > @TRIFAno or [TRIFAno] = @TRIFAno and [TRIFMes] = @TRIFMes and [TRIFFecha] = @TRIFFecha and [IndicadoresCodigo] > @IndicadoresCodigo or [IndicadoresCodigo] = @IndicadoresCodigo and [TRIFAno] = @TRIFAno and [TRIFMes] = @TRIFMes and [TRIFFecha] = @TRIFFecha and [Cod_Area] > @Cod_Area) ORDER BY [TRIFFecha], [TRIFMes], [TRIFAno], [IndicadoresCodigo], [Cod_Area]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000910,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000911", "SELECT TOP 1 [TRIFFecha], [TRIFMes], [TRIFAno], [IndicadoresCodigo], [Cod_Area] FROM [TRIF] WHERE ( [TRIFFecha] < @TRIFFecha or [TRIFFecha] = @TRIFFecha and [TRIFMes] < @TRIFMes or [TRIFMes] = @TRIFMes and [TRIFFecha] = @TRIFFecha and [TRIFAno] < @TRIFAno or [TRIFAno] = @TRIFAno and [TRIFMes] = @TRIFMes and [TRIFFecha] = @TRIFFecha and [IndicadoresCodigo] < @IndicadoresCodigo or [IndicadoresCodigo] = @IndicadoresCodigo and [TRIFAno] = @TRIFAno and [TRIFMes] = @TRIFMes and [TRIFFecha] = @TRIFFecha and [Cod_Area] < @Cod_Area) ORDER BY [TRIFFecha] DESC, [TRIFMes] DESC, [TRIFAno] DESC, [IndicadoresCodigo] DESC, [Cod_Area] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000911,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000912", "INSERT INTO [TRIF]([TRIFFecha], [TRIFMes], [TRIFAno], [TRIF_Valor_ACC], [TRIF_Valor_TRAB], [TRIF_Dias_PerdidosAtel], [IndicadoresCodigo], [Cod_Area]) VALUES(@TRIFFecha, @TRIFMes, @TRIFAno, @TRIF_Valor_ACC, @TRIF_Valor_TRAB, @TRIF_Dias_PerdidosAtel, @IndicadoresCodigo, @Cod_Area)", GxErrorMask.GX_NOMASK,prmT000912)
             ,new CursorDef("T000913", "UPDATE [TRIF] SET [TRIF_Valor_ACC]=@TRIF_Valor_ACC, [TRIF_Valor_TRAB]=@TRIF_Valor_TRAB, [TRIF_Dias_PerdidosAtel]=@TRIF_Dias_PerdidosAtel  WHERE [TRIFFecha] = @TRIFFecha AND [TRIFMes] = @TRIFMes AND [TRIFAno] = @TRIFAno AND [IndicadoresCodigo] = @IndicadoresCodigo AND [Cod_Area] = @Cod_Area", GxErrorMask.GX_NOMASK,prmT000913)
             ,new CursorDef("T000914", "DELETE FROM [TRIF]  WHERE [TRIFFecha] = @TRIFFecha AND [TRIFMes] = @TRIFMes AND [TRIFAno] = @TRIFAno AND [IndicadoresCodigo] = @IndicadoresCodigo AND [Cod_Area] = @Cod_Area", GxErrorMask.GX_NOMASK,prmT000914)
             ,new CursorDef("T000915", "SELECT [TRIFFecha], [TRIFMes], [TRIFAno], [IndicadoresCodigo], [Cod_Area] FROM [TRIF] ORDER BY [TRIFFecha], [TRIFMes], [TRIFAno], [IndicadoresCodigo], [Cod_Area]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000915,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000916", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000916,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000917", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000917,1, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                return;
             case 1 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
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
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
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
