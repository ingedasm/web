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
   public class cosusptonfruta : GXDataArea
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
            Form.Meta.addItem("description", "COSUSPTONFRUTA", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCOSUSPTONFRUTAFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("IndicadroresPalmas", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cosusptonfruta( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("IndicadroresPalmas", true);
      }

      public cosusptonfruta( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "COSUSPTONFRUTA", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_COSUSPTONFRUTA.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSUSPTONFRUTA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSUSPTONFRUTA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSUSPTONFRUTA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSUSPTONFRUTA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 4, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx00b0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"COSUSPTONFRUTAFECHA"+"'), id:'"+"COSUSPTONFRUTAFECHA"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"COSUSPTONFRUTAMES"+"'), id:'"+"COSUSPTONFRUTAMES"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"COSUSPTONFRUTAANO"+"'), id:'"+"COSUSPTONFRUTAANO"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"COD_AREA"+"'), id:'"+"COD_AREA"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"INDICADORESCODIGO"+"'), id:'"+"INDICADORESCODIGO"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_COSUSPTONFRUTA.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCOSUSPTONFRUTAFecha_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCOSUSPTONFRUTAFecha_Internalname, "COSUSPTONFRUTAFecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCOSUSPTONFRUTAFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCOSUSPTONFRUTAFecha_Internalname, context.localUtil.Format(A27COSUSPTONFRUTAFecha, "99/99/99"), context.localUtil.Format( A27COSUSPTONFRUTAFecha, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCOSUSPTONFRUTAFecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCOSUSPTONFRUTAFecha_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_COSUSPTONFRUTA.htm");
         GxWebStd.gx_bitmap( context, edtCOSUSPTONFRUTAFecha_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCOSUSPTONFRUTAFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_COSUSPTONFRUTA.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCOSUSPTONFRUTAMes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCOSUSPTONFRUTAMes_Internalname, "COSUSPTONFRUTAMes", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCOSUSPTONFRUTAMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A28COSUSPTONFRUTAMes), 4, 0, ",", "")), StringUtil.LTrim( ((edtCOSUSPTONFRUTAMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A28COSUSPTONFRUTAMes), "ZZZ9") : context.localUtil.Format( (decimal)(A28COSUSPTONFRUTAMes), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCOSUSPTONFRUTAMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCOSUSPTONFRUTAMes_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_COSUSPTONFRUTA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCOSUSPTONFRUTAAno_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCOSUSPTONFRUTAAno_Internalname, "COSUSPTONFRUTAAno", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCOSUSPTONFRUTAAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A29COSUSPTONFRUTAAno), 4, 0, ",", "")), StringUtil.LTrim( ((edtCOSUSPTONFRUTAAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A29COSUSPTONFRUTAAno), "ZZZ9") : context.localUtil.Format( (decimal)(A29COSUSPTONFRUTAAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCOSUSPTONFRUTAAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCOSUSPTONFRUTAAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_COSUSPTONFRUTA.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCod_Area_Internalname, A5Cod_Area, StringUtil.RTrim( context.localUtil.Format( A5Cod_Area, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCod_Area_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCod_Area_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_COSUSPTONFRUTA.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_5_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_5_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_5_Internalname, sImgUrl, imgprompt_5_Link, "", "", context.GetTheme( ), imgprompt_5_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_COSUSPTONFRUTA.htm");
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
         GxWebStd.gx_single_line_edit( context, edtIndicadoresCodigo_Internalname, A4IndicadoresCodigo, StringUtil.RTrim( context.localUtil.Format( A4IndicadoresCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIndicadoresCodigo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIndicadoresCodigo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_COSUSPTONFRUTA.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_4_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_4_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_4_Internalname, sImgUrl, imgprompt_4_Link, "", "", context.GetTheme( ), imgprompt_4_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_COSUSPTONFRUTA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCOSUSPTONFRUTAValor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCOSUSPTONFRUTAValor_Internalname, "COSUSPTONFRUTAValor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCOSUSPTONFRUTAValor_Internalname, StringUtil.LTrim( StringUtil.NToC( A134COSUSPTONFRUTAValor, 12, 5, ",", "")), StringUtil.LTrim( ((edtCOSUSPTONFRUTAValor_Enabled!=0) ? context.localUtil.Format( A134COSUSPTONFRUTAValor, "ZZZZZ9.99999") : context.localUtil.Format( A134COSUSPTONFRUTAValor, "ZZZZZ9.99999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','5');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','5');"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCOSUSPTONFRUTAValor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCOSUSPTONFRUTAValor_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_COSUSPTONFRUTA.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSUSPTONFRUTA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSUSPTONFRUTA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_COSUSPTONFRUTA.htm");
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
            Z27COSUSPTONFRUTAFecha = context.localUtil.CToD( cgiGet( "Z27COSUSPTONFRUTAFecha"), 0);
            Z28COSUSPTONFRUTAMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z28COSUSPTONFRUTAMes"), ",", "."), 18, MidpointRounding.ToEven));
            Z29COSUSPTONFRUTAAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z29COSUSPTONFRUTAAno"), ",", "."), 18, MidpointRounding.ToEven));
            Z5Cod_Area = cgiGet( "Z5Cod_Area");
            Z4IndicadoresCodigo = cgiGet( "Z4IndicadoresCodigo");
            Z134COSUSPTONFRUTAValor = context.localUtil.CToN( cgiGet( "Z134COSUSPTONFRUTAValor"), ",", ".");
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( context.localUtil.VCDate( cgiGet( edtCOSUSPTONFRUTAFecha_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"COSUSPTONFRUTAFecha"}), 1, "COSUSPTONFRUTAFECHA");
               AnyError = 1;
               GX_FocusControl = edtCOSUSPTONFRUTAFecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A27COSUSPTONFRUTAFecha = DateTime.MinValue;
               AssignAttri("", false, "A27COSUSPTONFRUTAFecha", context.localUtil.Format(A27COSUSPTONFRUTAFecha, "99/99/99"));
            }
            else
            {
               A27COSUSPTONFRUTAFecha = context.localUtil.CToD( cgiGet( edtCOSUSPTONFRUTAFecha_Internalname), 2);
               AssignAttri("", false, "A27COSUSPTONFRUTAFecha", context.localUtil.Format(A27COSUSPTONFRUTAFecha, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCOSUSPTONFRUTAMes_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCOSUSPTONFRUTAMes_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COSUSPTONFRUTAMES");
               AnyError = 1;
               GX_FocusControl = edtCOSUSPTONFRUTAMes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A28COSUSPTONFRUTAMes = 0;
               AssignAttri("", false, "A28COSUSPTONFRUTAMes", StringUtil.LTrimStr( (decimal)(A28COSUSPTONFRUTAMes), 4, 0));
            }
            else
            {
               A28COSUSPTONFRUTAMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCOSUSPTONFRUTAMes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A28COSUSPTONFRUTAMes", StringUtil.LTrimStr( (decimal)(A28COSUSPTONFRUTAMes), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCOSUSPTONFRUTAAno_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCOSUSPTONFRUTAAno_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COSUSPTONFRUTAANO");
               AnyError = 1;
               GX_FocusControl = edtCOSUSPTONFRUTAAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A29COSUSPTONFRUTAAno = 0;
               AssignAttri("", false, "A29COSUSPTONFRUTAAno", StringUtil.LTrimStr( (decimal)(A29COSUSPTONFRUTAAno), 4, 0));
            }
            else
            {
               A29COSUSPTONFRUTAAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCOSUSPTONFRUTAAno_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A29COSUSPTONFRUTAAno", StringUtil.LTrimStr( (decimal)(A29COSUSPTONFRUTAAno), 4, 0));
            }
            A5Cod_Area = cgiGet( edtCod_Area_Internalname);
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = cgiGet( edtIndicadoresCodigo_Internalname);
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCOSUSPTONFRUTAValor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCOSUSPTONFRUTAValor_Internalname), ",", ".") > 999999.99999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COSUSPTONFRUTAVALOR");
               AnyError = 1;
               GX_FocusControl = edtCOSUSPTONFRUTAValor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A134COSUSPTONFRUTAValor = 0;
               AssignAttri("", false, "A134COSUSPTONFRUTAValor", StringUtil.LTrimStr( A134COSUSPTONFRUTAValor, 12, 5));
            }
            else
            {
               A134COSUSPTONFRUTAValor = context.localUtil.CToN( cgiGet( edtCOSUSPTONFRUTAValor_Internalname), ",", ".");
               AssignAttri("", false, "A134COSUSPTONFRUTAValor", StringUtil.LTrimStr( A134COSUSPTONFRUTAValor, 12, 5));
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
               A27COSUSPTONFRUTAFecha = context.localUtil.ParseDateParm( GetPar( "COSUSPTONFRUTAFecha"));
               AssignAttri("", false, "A27COSUSPTONFRUTAFecha", context.localUtil.Format(A27COSUSPTONFRUTAFecha, "99/99/99"));
               A28COSUSPTONFRUTAMes = (short)(Math.Round(NumberUtil.Val( GetPar( "COSUSPTONFRUTAMes"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A28COSUSPTONFRUTAMes", StringUtil.LTrimStr( (decimal)(A28COSUSPTONFRUTAMes), 4, 0));
               A29COSUSPTONFRUTAAno = (short)(Math.Round(NumberUtil.Val( GetPar( "COSUSPTONFRUTAAno"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A29COSUSPTONFRUTAAno", StringUtil.LTrimStr( (decimal)(A29COSUSPTONFRUTAAno), 4, 0));
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
               InitAll0A11( ) ;
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
         DisableAttributes0A11( ) ;
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

      protected void ResetCaption0A0( )
      {
      }

      protected void ZM0A11( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z134COSUSPTONFRUTAValor = T000A3_A134COSUSPTONFRUTAValor[0];
            }
            else
            {
               Z134COSUSPTONFRUTAValor = A134COSUSPTONFRUTAValor;
            }
         }
         if ( GX_JID == -2 )
         {
            Z27COSUSPTONFRUTAFecha = A27COSUSPTONFRUTAFecha;
            Z28COSUSPTONFRUTAMes = A28COSUSPTONFRUTAMes;
            Z29COSUSPTONFRUTAAno = A29COSUSPTONFRUTAAno;
            Z134COSUSPTONFRUTAValor = A134COSUSPTONFRUTAValor;
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

      protected void Load0A11( )
      {
         /* Using cursor T000A6 */
         pr_default.execute(4, new Object[] {A27COSUSPTONFRUTAFecha, A28COSUSPTONFRUTAMes, A29COSUSPTONFRUTAAno, A5Cod_Area, A4IndicadoresCodigo});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound11 = 1;
            A134COSUSPTONFRUTAValor = T000A6_A134COSUSPTONFRUTAValor[0];
            AssignAttri("", false, "A134COSUSPTONFRUTAValor", StringUtil.LTrimStr( A134COSUSPTONFRUTAValor, 12, 5));
            ZM0A11( -2) ;
         }
         pr_default.close(4);
         OnLoadActions0A11( ) ;
      }

      protected void OnLoadActions0A11( )
      {
      }

      protected void CheckExtendedTable0A11( )
      {
         nIsDirty_11 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A27COSUSPTONFRUTAFecha) || ( DateTimeUtil.ResetTime ( A27COSUSPTONFRUTAFecha ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo COSUSPTONFRUTAFecha fuera de rango", "OutOfRange", 1, "COSUSPTONFRUTAFECHA");
            AnyError = 1;
            GX_FocusControl = edtCOSUSPTONFRUTAFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000A4 */
         pr_default.execute(2, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T000A5 */
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

      protected void CloseExtendedTableCursors0A11( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( string A5Cod_Area )
      {
         /* Using cursor T000A7 */
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
         /* Using cursor T000A8 */
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

      protected void GetKey0A11( )
      {
         /* Using cursor T000A9 */
         pr_default.execute(7, new Object[] {A27COSUSPTONFRUTAFecha, A28COSUSPTONFRUTAMes, A29COSUSPTONFRUTAAno, A5Cod_Area, A4IndicadoresCodigo});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound11 = 1;
         }
         else
         {
            RcdFound11 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000A3 */
         pr_default.execute(1, new Object[] {A27COSUSPTONFRUTAFecha, A28COSUSPTONFRUTAMes, A29COSUSPTONFRUTAAno, A5Cod_Area, A4IndicadoresCodigo});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0A11( 2) ;
            RcdFound11 = 1;
            A27COSUSPTONFRUTAFecha = T000A3_A27COSUSPTONFRUTAFecha[0];
            AssignAttri("", false, "A27COSUSPTONFRUTAFecha", context.localUtil.Format(A27COSUSPTONFRUTAFecha, "99/99/99"));
            A28COSUSPTONFRUTAMes = T000A3_A28COSUSPTONFRUTAMes[0];
            AssignAttri("", false, "A28COSUSPTONFRUTAMes", StringUtil.LTrimStr( (decimal)(A28COSUSPTONFRUTAMes), 4, 0));
            A29COSUSPTONFRUTAAno = T000A3_A29COSUSPTONFRUTAAno[0];
            AssignAttri("", false, "A29COSUSPTONFRUTAAno", StringUtil.LTrimStr( (decimal)(A29COSUSPTONFRUTAAno), 4, 0));
            A134COSUSPTONFRUTAValor = T000A3_A134COSUSPTONFRUTAValor[0];
            AssignAttri("", false, "A134COSUSPTONFRUTAValor", StringUtil.LTrimStr( A134COSUSPTONFRUTAValor, 12, 5));
            A5Cod_Area = T000A3_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = T000A3_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            Z27COSUSPTONFRUTAFecha = A27COSUSPTONFRUTAFecha;
            Z28COSUSPTONFRUTAMes = A28COSUSPTONFRUTAMes;
            Z29COSUSPTONFRUTAAno = A29COSUSPTONFRUTAAno;
            Z5Cod_Area = A5Cod_Area;
            Z4IndicadoresCodigo = A4IndicadoresCodigo;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0A11( ) ;
            if ( AnyError == 1 )
            {
               RcdFound11 = 0;
               InitializeNonKey0A11( ) ;
            }
            Gx_mode = sMode11;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound11 = 0;
            InitializeNonKey0A11( ) ;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode11;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0A11( ) ;
         if ( RcdFound11 == 0 )
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
         RcdFound11 = 0;
         /* Using cursor T000A10 */
         pr_default.execute(8, new Object[] {A27COSUSPTONFRUTAFecha, A28COSUSPTONFRUTAMes, A29COSUSPTONFRUTAAno, A5Cod_Area, A4IndicadoresCodigo});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( DateTimeUtil.ResetTime ( T000A10_A27COSUSPTONFRUTAFecha[0] ) < DateTimeUtil.ResetTime ( A27COSUSPTONFRUTAFecha ) ) || ( DateTimeUtil.ResetTime ( T000A10_A27COSUSPTONFRUTAFecha[0] ) == DateTimeUtil.ResetTime ( A27COSUSPTONFRUTAFecha ) ) && ( T000A10_A28COSUSPTONFRUTAMes[0] < A28COSUSPTONFRUTAMes ) || ( T000A10_A28COSUSPTONFRUTAMes[0] == A28COSUSPTONFRUTAMes ) && ( DateTimeUtil.ResetTime ( T000A10_A27COSUSPTONFRUTAFecha[0] ) == DateTimeUtil.ResetTime ( A27COSUSPTONFRUTAFecha ) ) && ( T000A10_A29COSUSPTONFRUTAAno[0] < A29COSUSPTONFRUTAAno ) || ( T000A10_A29COSUSPTONFRUTAAno[0] == A29COSUSPTONFRUTAAno ) && ( T000A10_A28COSUSPTONFRUTAMes[0] == A28COSUSPTONFRUTAMes ) && ( DateTimeUtil.ResetTime ( T000A10_A27COSUSPTONFRUTAFecha[0] ) == DateTimeUtil.ResetTime ( A27COSUSPTONFRUTAFecha ) ) && ( StringUtil.StrCmp(T000A10_A5Cod_Area[0], A5Cod_Area) < 0 ) || ( StringUtil.StrCmp(T000A10_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000A10_A29COSUSPTONFRUTAAno[0] == A29COSUSPTONFRUTAAno ) && ( T000A10_A28COSUSPTONFRUTAMes[0] == A28COSUSPTONFRUTAMes ) && ( DateTimeUtil.ResetTime ( T000A10_A27COSUSPTONFRUTAFecha[0] ) == DateTimeUtil.ResetTime ( A27COSUSPTONFRUTAFecha ) ) && ( StringUtil.StrCmp(T000A10_A4IndicadoresCodigo[0], A4IndicadoresCodigo) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( DateTimeUtil.ResetTime ( T000A10_A27COSUSPTONFRUTAFecha[0] ) > DateTimeUtil.ResetTime ( A27COSUSPTONFRUTAFecha ) ) || ( DateTimeUtil.ResetTime ( T000A10_A27COSUSPTONFRUTAFecha[0] ) == DateTimeUtil.ResetTime ( A27COSUSPTONFRUTAFecha ) ) && ( T000A10_A28COSUSPTONFRUTAMes[0] > A28COSUSPTONFRUTAMes ) || ( T000A10_A28COSUSPTONFRUTAMes[0] == A28COSUSPTONFRUTAMes ) && ( DateTimeUtil.ResetTime ( T000A10_A27COSUSPTONFRUTAFecha[0] ) == DateTimeUtil.ResetTime ( A27COSUSPTONFRUTAFecha ) ) && ( T000A10_A29COSUSPTONFRUTAAno[0] > A29COSUSPTONFRUTAAno ) || ( T000A10_A29COSUSPTONFRUTAAno[0] == A29COSUSPTONFRUTAAno ) && ( T000A10_A28COSUSPTONFRUTAMes[0] == A28COSUSPTONFRUTAMes ) && ( DateTimeUtil.ResetTime ( T000A10_A27COSUSPTONFRUTAFecha[0] ) == DateTimeUtil.ResetTime ( A27COSUSPTONFRUTAFecha ) ) && ( StringUtil.StrCmp(T000A10_A5Cod_Area[0], A5Cod_Area) > 0 ) || ( StringUtil.StrCmp(T000A10_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000A10_A29COSUSPTONFRUTAAno[0] == A29COSUSPTONFRUTAAno ) && ( T000A10_A28COSUSPTONFRUTAMes[0] == A28COSUSPTONFRUTAMes ) && ( DateTimeUtil.ResetTime ( T000A10_A27COSUSPTONFRUTAFecha[0] ) == DateTimeUtil.ResetTime ( A27COSUSPTONFRUTAFecha ) ) && ( StringUtil.StrCmp(T000A10_A4IndicadoresCodigo[0], A4IndicadoresCodigo) > 0 ) ) )
            {
               A27COSUSPTONFRUTAFecha = T000A10_A27COSUSPTONFRUTAFecha[0];
               AssignAttri("", false, "A27COSUSPTONFRUTAFecha", context.localUtil.Format(A27COSUSPTONFRUTAFecha, "99/99/99"));
               A28COSUSPTONFRUTAMes = T000A10_A28COSUSPTONFRUTAMes[0];
               AssignAttri("", false, "A28COSUSPTONFRUTAMes", StringUtil.LTrimStr( (decimal)(A28COSUSPTONFRUTAMes), 4, 0));
               A29COSUSPTONFRUTAAno = T000A10_A29COSUSPTONFRUTAAno[0];
               AssignAttri("", false, "A29COSUSPTONFRUTAAno", StringUtil.LTrimStr( (decimal)(A29COSUSPTONFRUTAAno), 4, 0));
               A5Cod_Area = T000A10_A5Cod_Area[0];
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               A4IndicadoresCodigo = T000A10_A4IndicadoresCodigo[0];
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               RcdFound11 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound11 = 0;
         /* Using cursor T000A11 */
         pr_default.execute(9, new Object[] {A27COSUSPTONFRUTAFecha, A28COSUSPTONFRUTAMes, A29COSUSPTONFRUTAAno, A5Cod_Area, A4IndicadoresCodigo});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( DateTimeUtil.ResetTime ( T000A11_A27COSUSPTONFRUTAFecha[0] ) > DateTimeUtil.ResetTime ( A27COSUSPTONFRUTAFecha ) ) || ( DateTimeUtil.ResetTime ( T000A11_A27COSUSPTONFRUTAFecha[0] ) == DateTimeUtil.ResetTime ( A27COSUSPTONFRUTAFecha ) ) && ( T000A11_A28COSUSPTONFRUTAMes[0] > A28COSUSPTONFRUTAMes ) || ( T000A11_A28COSUSPTONFRUTAMes[0] == A28COSUSPTONFRUTAMes ) && ( DateTimeUtil.ResetTime ( T000A11_A27COSUSPTONFRUTAFecha[0] ) == DateTimeUtil.ResetTime ( A27COSUSPTONFRUTAFecha ) ) && ( T000A11_A29COSUSPTONFRUTAAno[0] > A29COSUSPTONFRUTAAno ) || ( T000A11_A29COSUSPTONFRUTAAno[0] == A29COSUSPTONFRUTAAno ) && ( T000A11_A28COSUSPTONFRUTAMes[0] == A28COSUSPTONFRUTAMes ) && ( DateTimeUtil.ResetTime ( T000A11_A27COSUSPTONFRUTAFecha[0] ) == DateTimeUtil.ResetTime ( A27COSUSPTONFRUTAFecha ) ) && ( StringUtil.StrCmp(T000A11_A5Cod_Area[0], A5Cod_Area) > 0 ) || ( StringUtil.StrCmp(T000A11_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000A11_A29COSUSPTONFRUTAAno[0] == A29COSUSPTONFRUTAAno ) && ( T000A11_A28COSUSPTONFRUTAMes[0] == A28COSUSPTONFRUTAMes ) && ( DateTimeUtil.ResetTime ( T000A11_A27COSUSPTONFRUTAFecha[0] ) == DateTimeUtil.ResetTime ( A27COSUSPTONFRUTAFecha ) ) && ( StringUtil.StrCmp(T000A11_A4IndicadoresCodigo[0], A4IndicadoresCodigo) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( DateTimeUtil.ResetTime ( T000A11_A27COSUSPTONFRUTAFecha[0] ) < DateTimeUtil.ResetTime ( A27COSUSPTONFRUTAFecha ) ) || ( DateTimeUtil.ResetTime ( T000A11_A27COSUSPTONFRUTAFecha[0] ) == DateTimeUtil.ResetTime ( A27COSUSPTONFRUTAFecha ) ) && ( T000A11_A28COSUSPTONFRUTAMes[0] < A28COSUSPTONFRUTAMes ) || ( T000A11_A28COSUSPTONFRUTAMes[0] == A28COSUSPTONFRUTAMes ) && ( DateTimeUtil.ResetTime ( T000A11_A27COSUSPTONFRUTAFecha[0] ) == DateTimeUtil.ResetTime ( A27COSUSPTONFRUTAFecha ) ) && ( T000A11_A29COSUSPTONFRUTAAno[0] < A29COSUSPTONFRUTAAno ) || ( T000A11_A29COSUSPTONFRUTAAno[0] == A29COSUSPTONFRUTAAno ) && ( T000A11_A28COSUSPTONFRUTAMes[0] == A28COSUSPTONFRUTAMes ) && ( DateTimeUtil.ResetTime ( T000A11_A27COSUSPTONFRUTAFecha[0] ) == DateTimeUtil.ResetTime ( A27COSUSPTONFRUTAFecha ) ) && ( StringUtil.StrCmp(T000A11_A5Cod_Area[0], A5Cod_Area) < 0 ) || ( StringUtil.StrCmp(T000A11_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000A11_A29COSUSPTONFRUTAAno[0] == A29COSUSPTONFRUTAAno ) && ( T000A11_A28COSUSPTONFRUTAMes[0] == A28COSUSPTONFRUTAMes ) && ( DateTimeUtil.ResetTime ( T000A11_A27COSUSPTONFRUTAFecha[0] ) == DateTimeUtil.ResetTime ( A27COSUSPTONFRUTAFecha ) ) && ( StringUtil.StrCmp(T000A11_A4IndicadoresCodigo[0], A4IndicadoresCodigo) < 0 ) ) )
            {
               A27COSUSPTONFRUTAFecha = T000A11_A27COSUSPTONFRUTAFecha[0];
               AssignAttri("", false, "A27COSUSPTONFRUTAFecha", context.localUtil.Format(A27COSUSPTONFRUTAFecha, "99/99/99"));
               A28COSUSPTONFRUTAMes = T000A11_A28COSUSPTONFRUTAMes[0];
               AssignAttri("", false, "A28COSUSPTONFRUTAMes", StringUtil.LTrimStr( (decimal)(A28COSUSPTONFRUTAMes), 4, 0));
               A29COSUSPTONFRUTAAno = T000A11_A29COSUSPTONFRUTAAno[0];
               AssignAttri("", false, "A29COSUSPTONFRUTAAno", StringUtil.LTrimStr( (decimal)(A29COSUSPTONFRUTAAno), 4, 0));
               A5Cod_Area = T000A11_A5Cod_Area[0];
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               A4IndicadoresCodigo = T000A11_A4IndicadoresCodigo[0];
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               RcdFound11 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0A11( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCOSUSPTONFRUTAFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0A11( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound11 == 1 )
            {
               if ( ( DateTimeUtil.ResetTime ( A27COSUSPTONFRUTAFecha ) != DateTimeUtil.ResetTime ( Z27COSUSPTONFRUTAFecha ) ) || ( A28COSUSPTONFRUTAMes != Z28COSUSPTONFRUTAMes ) || ( A29COSUSPTONFRUTAAno != Z29COSUSPTONFRUTAAno ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) )
               {
                  A27COSUSPTONFRUTAFecha = Z27COSUSPTONFRUTAFecha;
                  AssignAttri("", false, "A27COSUSPTONFRUTAFecha", context.localUtil.Format(A27COSUSPTONFRUTAFecha, "99/99/99"));
                  A28COSUSPTONFRUTAMes = Z28COSUSPTONFRUTAMes;
                  AssignAttri("", false, "A28COSUSPTONFRUTAMes", StringUtil.LTrimStr( (decimal)(A28COSUSPTONFRUTAMes), 4, 0));
                  A29COSUSPTONFRUTAAno = Z29COSUSPTONFRUTAAno;
                  AssignAttri("", false, "A29COSUSPTONFRUTAAno", StringUtil.LTrimStr( (decimal)(A29COSUSPTONFRUTAAno), 4, 0));
                  A5Cod_Area = Z5Cod_Area;
                  AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
                  A4IndicadoresCodigo = Z4IndicadoresCodigo;
                  AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "COSUSPTONFRUTAFECHA");
                  AnyError = 1;
                  GX_FocusControl = edtCOSUSPTONFRUTAFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCOSUSPTONFRUTAFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0A11( ) ;
                  GX_FocusControl = edtCOSUSPTONFRUTAFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( DateTimeUtil.ResetTime ( A27COSUSPTONFRUTAFecha ) != DateTimeUtil.ResetTime ( Z27COSUSPTONFRUTAFecha ) ) || ( A28COSUSPTONFRUTAMes != Z28COSUSPTONFRUTAMes ) || ( A29COSUSPTONFRUTAAno != Z29COSUSPTONFRUTAAno ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtCOSUSPTONFRUTAFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0A11( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "COSUSPTONFRUTAFECHA");
                     AnyError = 1;
                     GX_FocusControl = edtCOSUSPTONFRUTAFecha_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtCOSUSPTONFRUTAFecha_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0A11( ) ;
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
         if ( ( DateTimeUtil.ResetTime ( A27COSUSPTONFRUTAFecha ) != DateTimeUtil.ResetTime ( Z27COSUSPTONFRUTAFecha ) ) || ( A28COSUSPTONFRUTAMes != Z28COSUSPTONFRUTAMes ) || ( A29COSUSPTONFRUTAAno != Z29COSUSPTONFRUTAAno ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) )
         {
            A27COSUSPTONFRUTAFecha = Z27COSUSPTONFRUTAFecha;
            AssignAttri("", false, "A27COSUSPTONFRUTAFecha", context.localUtil.Format(A27COSUSPTONFRUTAFecha, "99/99/99"));
            A28COSUSPTONFRUTAMes = Z28COSUSPTONFRUTAMes;
            AssignAttri("", false, "A28COSUSPTONFRUTAMes", StringUtil.LTrimStr( (decimal)(A28COSUSPTONFRUTAMes), 4, 0));
            A29COSUSPTONFRUTAAno = Z29COSUSPTONFRUTAAno;
            AssignAttri("", false, "A29COSUSPTONFRUTAAno", StringUtil.LTrimStr( (decimal)(A29COSUSPTONFRUTAAno), 4, 0));
            A5Cod_Area = Z5Cod_Area;
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = Z4IndicadoresCodigo;
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "COSUSPTONFRUTAFECHA");
            AnyError = 1;
            GX_FocusControl = edtCOSUSPTONFRUTAFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCOSUSPTONFRUTAFecha_Internalname;
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
         if ( RcdFound11 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "COSUSPTONFRUTAFECHA");
            AnyError = 1;
            GX_FocusControl = edtCOSUSPTONFRUTAFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtCOSUSPTONFRUTAValor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0A11( ) ;
         if ( RcdFound11 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCOSUSPTONFRUTAValor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0A11( ) ;
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
         if ( RcdFound11 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCOSUSPTONFRUTAValor_Internalname;
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
         if ( RcdFound11 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCOSUSPTONFRUTAValor_Internalname;
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
         ScanStart0A11( ) ;
         if ( RcdFound11 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound11 != 0 )
            {
               ScanNext0A11( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCOSUSPTONFRUTAValor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0A11( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0A11( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000A2 */
            pr_default.execute(0, new Object[] {A27COSUSPTONFRUTAFecha, A28COSUSPTONFRUTAMes, A29COSUSPTONFRUTAAno, A5Cod_Area, A4IndicadoresCodigo});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"COSUSPTONFRUTA"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z134COSUSPTONFRUTAValor != T000A2_A134COSUSPTONFRUTAValor[0] ) )
            {
               if ( Z134COSUSPTONFRUTAValor != T000A2_A134COSUSPTONFRUTAValor[0] )
               {
                  GXUtil.WriteLog("cosusptonfruta:[seudo value changed for attri]"+"COSUSPTONFRUTAValor");
                  GXUtil.WriteLogRaw("Old: ",Z134COSUSPTONFRUTAValor);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A134COSUSPTONFRUTAValor[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"COSUSPTONFRUTA"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0A11( )
      {
         BeforeValidate0A11( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A11( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0A11( 0) ;
            CheckOptimisticConcurrency0A11( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A11( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0A11( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000A12 */
                     pr_default.execute(10, new Object[] {A27COSUSPTONFRUTAFecha, A28COSUSPTONFRUTAMes, A29COSUSPTONFRUTAAno, A134COSUSPTONFRUTAValor, A5Cod_Area, A4IndicadoresCodigo});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("COSUSPTONFRUTA");
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
                           ResetCaption0A0( ) ;
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
               Load0A11( ) ;
            }
            EndLevel0A11( ) ;
         }
         CloseExtendedTableCursors0A11( ) ;
      }

      protected void Update0A11( )
      {
         BeforeValidate0A11( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A11( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A11( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A11( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0A11( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000A13 */
                     pr_default.execute(11, new Object[] {A134COSUSPTONFRUTAValor, A27COSUSPTONFRUTAFecha, A28COSUSPTONFRUTAMes, A29COSUSPTONFRUTAAno, A5Cod_Area, A4IndicadoresCodigo});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("COSUSPTONFRUTA");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"COSUSPTONFRUTA"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0A11( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0A0( ) ;
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
            EndLevel0A11( ) ;
         }
         CloseExtendedTableCursors0A11( ) ;
      }

      protected void DeferredUpdate0A11( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0A11( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A11( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0A11( ) ;
            AfterConfirm0A11( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0A11( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000A14 */
                  pr_default.execute(12, new Object[] {A27COSUSPTONFRUTAFecha, A28COSUSPTONFRUTAMes, A29COSUSPTONFRUTAAno, A5Cod_Area, A4IndicadoresCodigo});
                  pr_default.close(12);
                  pr_default.SmartCacheProvider.SetUpdated("COSUSPTONFRUTA");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound11 == 0 )
                        {
                           InitAll0A11( ) ;
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
                        ResetCaption0A0( ) ;
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
         sMode11 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0A11( ) ;
         Gx_mode = sMode11;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0A11( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0A11( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0A11( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("cosusptonfruta",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0A0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("cosusptonfruta",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0A11( )
      {
         /* Using cursor T000A15 */
         pr_default.execute(13);
         RcdFound11 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound11 = 1;
            A27COSUSPTONFRUTAFecha = T000A15_A27COSUSPTONFRUTAFecha[0];
            AssignAttri("", false, "A27COSUSPTONFRUTAFecha", context.localUtil.Format(A27COSUSPTONFRUTAFecha, "99/99/99"));
            A28COSUSPTONFRUTAMes = T000A15_A28COSUSPTONFRUTAMes[0];
            AssignAttri("", false, "A28COSUSPTONFRUTAMes", StringUtil.LTrimStr( (decimal)(A28COSUSPTONFRUTAMes), 4, 0));
            A29COSUSPTONFRUTAAno = T000A15_A29COSUSPTONFRUTAAno[0];
            AssignAttri("", false, "A29COSUSPTONFRUTAAno", StringUtil.LTrimStr( (decimal)(A29COSUSPTONFRUTAAno), 4, 0));
            A5Cod_Area = T000A15_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = T000A15_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0A11( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound11 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound11 = 1;
            A27COSUSPTONFRUTAFecha = T000A15_A27COSUSPTONFRUTAFecha[0];
            AssignAttri("", false, "A27COSUSPTONFRUTAFecha", context.localUtil.Format(A27COSUSPTONFRUTAFecha, "99/99/99"));
            A28COSUSPTONFRUTAMes = T000A15_A28COSUSPTONFRUTAMes[0];
            AssignAttri("", false, "A28COSUSPTONFRUTAMes", StringUtil.LTrimStr( (decimal)(A28COSUSPTONFRUTAMes), 4, 0));
            A29COSUSPTONFRUTAAno = T000A15_A29COSUSPTONFRUTAAno[0];
            AssignAttri("", false, "A29COSUSPTONFRUTAAno", StringUtil.LTrimStr( (decimal)(A29COSUSPTONFRUTAAno), 4, 0));
            A5Cod_Area = T000A15_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = T000A15_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
         }
      }

      protected void ScanEnd0A11( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm0A11( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0A11( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0A11( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0A11( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0A11( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0A11( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0A11( )
      {
         edtCOSUSPTONFRUTAFecha_Enabled = 0;
         AssignProp("", false, edtCOSUSPTONFRUTAFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSUSPTONFRUTAFecha_Enabled), 5, 0), true);
         edtCOSUSPTONFRUTAMes_Enabled = 0;
         AssignProp("", false, edtCOSUSPTONFRUTAMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSUSPTONFRUTAMes_Enabled), 5, 0), true);
         edtCOSUSPTONFRUTAAno_Enabled = 0;
         AssignProp("", false, edtCOSUSPTONFRUTAAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSUSPTONFRUTAAno_Enabled), 5, 0), true);
         edtCod_Area_Enabled = 0;
         AssignProp("", false, edtCod_Area_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCod_Area_Enabled), 5, 0), true);
         edtIndicadoresCodigo_Enabled = 0;
         AssignProp("", false, edtIndicadoresCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIndicadoresCodigo_Enabled), 5, 0), true);
         edtCOSUSPTONFRUTAValor_Enabled = 0;
         AssignProp("", false, edtCOSUSPTONFRUTAValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSUSPTONFRUTAValor_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0A11( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0A0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("cosusptonfruta.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z27COSUSPTONFRUTAFecha", context.localUtil.DToC( Z27COSUSPTONFRUTAFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z28COSUSPTONFRUTAMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z28COSUSPTONFRUTAMes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z29COSUSPTONFRUTAAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z29COSUSPTONFRUTAAno), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z5Cod_Area", Z5Cod_Area);
         GxWebStd.gx_hidden_field( context, "Z4IndicadoresCodigo", Z4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "Z134COSUSPTONFRUTAValor", StringUtil.LTrim( StringUtil.NToC( Z134COSUSPTONFRUTAValor, 12, 5, ",", "")));
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
         return formatLink("cosusptonfruta.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "COSUSPTONFRUTA" ;
      }

      public override string GetPgmdesc( )
      {
         return "COSUSPTONFRUTA" ;
      }

      protected void InitializeNonKey0A11( )
      {
         A134COSUSPTONFRUTAValor = 0;
         AssignAttri("", false, "A134COSUSPTONFRUTAValor", StringUtil.LTrimStr( A134COSUSPTONFRUTAValor, 12, 5));
         Z134COSUSPTONFRUTAValor = 0;
      }

      protected void InitAll0A11( )
      {
         A27COSUSPTONFRUTAFecha = DateTime.MinValue;
         AssignAttri("", false, "A27COSUSPTONFRUTAFecha", context.localUtil.Format(A27COSUSPTONFRUTAFecha, "99/99/99"));
         A28COSUSPTONFRUTAMes = 0;
         AssignAttri("", false, "A28COSUSPTONFRUTAMes", StringUtil.LTrimStr( (decimal)(A28COSUSPTONFRUTAMes), 4, 0));
         A29COSUSPTONFRUTAAno = 0;
         AssignAttri("", false, "A29COSUSPTONFRUTAAno", StringUtil.LTrimStr( (decimal)(A29COSUSPTONFRUTAAno), 4, 0));
         A5Cod_Area = "";
         AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
         A4IndicadoresCodigo = "";
         AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
         InitializeNonKey0A11( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024723102654", true, true);
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
         context.AddJavascriptSource("cosusptonfruta.js", "?2024723102654", false, true);
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
         edtCOSUSPTONFRUTAFecha_Internalname = "COSUSPTONFRUTAFECHA";
         edtCOSUSPTONFRUTAMes_Internalname = "COSUSPTONFRUTAMES";
         edtCOSUSPTONFRUTAAno_Internalname = "COSUSPTONFRUTAANO";
         edtCod_Area_Internalname = "COD_AREA";
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO";
         edtCOSUSPTONFRUTAValor_Internalname = "COSUSPTONFRUTAVALOR";
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
         Form.Caption = "COSUSPTONFRUTA";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCOSUSPTONFRUTAValor_Jsonclick = "";
         edtCOSUSPTONFRUTAValor_Enabled = 1;
         imgprompt_4_Visible = 1;
         imgprompt_4_Link = "";
         edtIndicadoresCodigo_Jsonclick = "";
         edtIndicadoresCodigo_Enabled = 1;
         imgprompt_5_Visible = 1;
         imgprompt_5_Link = "";
         edtCod_Area_Jsonclick = "";
         edtCod_Area_Enabled = 1;
         edtCOSUSPTONFRUTAAno_Jsonclick = "";
         edtCOSUSPTONFRUTAAno_Enabled = 1;
         edtCOSUSPTONFRUTAMes_Jsonclick = "";
         edtCOSUSPTONFRUTAMes_Enabled = 1;
         edtCOSUSPTONFRUTAFecha_Jsonclick = "";
         edtCOSUSPTONFRUTAFecha_Enabled = 1;
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
         /* Using cursor T000A16 */
         pr_default.execute(14, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(14);
         /* Using cursor T000A17 */
         pr_default.execute(15, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(15);
         GX_FocusControl = edtCOSUSPTONFRUTAValor_Internalname;
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
         /* Using cursor T000A16 */
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
         /* Using cursor T000A17 */
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
         AssignAttri("", false, "A134COSUSPTONFRUTAValor", StringUtil.LTrim( StringUtil.NToC( A134COSUSPTONFRUTAValor, 12, 5, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z27COSUSPTONFRUTAFecha", context.localUtil.Format(Z27COSUSPTONFRUTAFecha, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z28COSUSPTONFRUTAMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z28COSUSPTONFRUTAMes), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z29COSUSPTONFRUTAAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z29COSUSPTONFRUTAAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z5Cod_Area", Z5Cod_Area);
         GxWebStd.gx_hidden_field( context, "Z4IndicadoresCodigo", Z4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "Z134COSUSPTONFRUTAValor", StringUtil.LTrim( StringUtil.NToC( Z134COSUSPTONFRUTAValor, 12, 5, ".", "")));
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
         setEventMetadata("VALID_COSUSPTONFRUTAFECHA","{handler:'Valid_Cosusptonfrutafecha',iparms:[]");
         setEventMetadata("VALID_COSUSPTONFRUTAFECHA",",oparms:[]}");
         setEventMetadata("VALID_COSUSPTONFRUTAMES","{handler:'Valid_Cosusptonfrutames',iparms:[]");
         setEventMetadata("VALID_COSUSPTONFRUTAMES",",oparms:[]}");
         setEventMetadata("VALID_COSUSPTONFRUTAANO","{handler:'Valid_Cosusptonfrutaano',iparms:[]");
         setEventMetadata("VALID_COSUSPTONFRUTAANO",",oparms:[]}");
         setEventMetadata("VALID_COD_AREA","{handler:'Valid_Cod_area',iparms:[{av:'A5Cod_Area',fld:'COD_AREA',pic:''}]");
         setEventMetadata("VALID_COD_AREA",",oparms:[]}");
         setEventMetadata("VALID_INDICADORESCODIGO","{handler:'Valid_Indicadorescodigo',iparms:[{av:'A27COSUSPTONFRUTAFecha',fld:'COSUSPTONFRUTAFECHA',pic:''},{av:'A28COSUSPTONFRUTAMes',fld:'COSUSPTONFRUTAMES',pic:'ZZZ9'},{av:'A29COSUSPTONFRUTAAno',fld:'COSUSPTONFRUTAANO',pic:'ZZZ9'},{av:'A5Cod_Area',fld:'COD_AREA',pic:''},{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_INDICADORESCODIGO",",oparms:[{av:'A134COSUSPTONFRUTAValor',fld:'COSUSPTONFRUTAVALOR',pic:'ZZZZZ9.99999'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z27COSUSPTONFRUTAFecha'},{av:'Z28COSUSPTONFRUTAMes'},{av:'Z29COSUSPTONFRUTAAno'},{av:'Z5Cod_Area'},{av:'Z4IndicadoresCodigo'},{av:'Z134COSUSPTONFRUTAValor'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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
         Z27COSUSPTONFRUTAFecha = DateTime.MinValue;
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
         A27COSUSPTONFRUTAFecha = DateTime.MinValue;
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
         T000A6_A27COSUSPTONFRUTAFecha = new DateTime[] {DateTime.MinValue} ;
         T000A6_A28COSUSPTONFRUTAMes = new short[1] ;
         T000A6_A29COSUSPTONFRUTAAno = new short[1] ;
         T000A6_A134COSUSPTONFRUTAValor = new decimal[1] ;
         T000A6_A5Cod_Area = new string[] {""} ;
         T000A6_A4IndicadoresCodigo = new string[] {""} ;
         T000A4_A5Cod_Area = new string[] {""} ;
         T000A5_A4IndicadoresCodigo = new string[] {""} ;
         T000A7_A5Cod_Area = new string[] {""} ;
         T000A8_A4IndicadoresCodigo = new string[] {""} ;
         T000A9_A27COSUSPTONFRUTAFecha = new DateTime[] {DateTime.MinValue} ;
         T000A9_A28COSUSPTONFRUTAMes = new short[1] ;
         T000A9_A29COSUSPTONFRUTAAno = new short[1] ;
         T000A9_A5Cod_Area = new string[] {""} ;
         T000A9_A4IndicadoresCodigo = new string[] {""} ;
         T000A3_A27COSUSPTONFRUTAFecha = new DateTime[] {DateTime.MinValue} ;
         T000A3_A28COSUSPTONFRUTAMes = new short[1] ;
         T000A3_A29COSUSPTONFRUTAAno = new short[1] ;
         T000A3_A134COSUSPTONFRUTAValor = new decimal[1] ;
         T000A3_A5Cod_Area = new string[] {""} ;
         T000A3_A4IndicadoresCodigo = new string[] {""} ;
         sMode11 = "";
         T000A10_A27COSUSPTONFRUTAFecha = new DateTime[] {DateTime.MinValue} ;
         T000A10_A28COSUSPTONFRUTAMes = new short[1] ;
         T000A10_A29COSUSPTONFRUTAAno = new short[1] ;
         T000A10_A5Cod_Area = new string[] {""} ;
         T000A10_A4IndicadoresCodigo = new string[] {""} ;
         T000A11_A27COSUSPTONFRUTAFecha = new DateTime[] {DateTime.MinValue} ;
         T000A11_A28COSUSPTONFRUTAMes = new short[1] ;
         T000A11_A29COSUSPTONFRUTAAno = new short[1] ;
         T000A11_A5Cod_Area = new string[] {""} ;
         T000A11_A4IndicadoresCodigo = new string[] {""} ;
         T000A2_A27COSUSPTONFRUTAFecha = new DateTime[] {DateTime.MinValue} ;
         T000A2_A28COSUSPTONFRUTAMes = new short[1] ;
         T000A2_A29COSUSPTONFRUTAAno = new short[1] ;
         T000A2_A134COSUSPTONFRUTAValor = new decimal[1] ;
         T000A2_A5Cod_Area = new string[] {""} ;
         T000A2_A4IndicadoresCodigo = new string[] {""} ;
         T000A15_A27COSUSPTONFRUTAFecha = new DateTime[] {DateTime.MinValue} ;
         T000A15_A28COSUSPTONFRUTAMes = new short[1] ;
         T000A15_A29COSUSPTONFRUTAAno = new short[1] ;
         T000A15_A5Cod_Area = new string[] {""} ;
         T000A15_A4IndicadoresCodigo = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T000A16_A5Cod_Area = new string[] {""} ;
         T000A17_A4IndicadoresCodigo = new string[] {""} ;
         ZZ27COSUSPTONFRUTAFecha = DateTime.MinValue;
         ZZ5Cod_Area = "";
         ZZ4IndicadoresCodigo = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cosusptonfruta__default(),
            new Object[][] {
                new Object[] {
               T000A2_A27COSUSPTONFRUTAFecha, T000A2_A28COSUSPTONFRUTAMes, T000A2_A29COSUSPTONFRUTAAno, T000A2_A134COSUSPTONFRUTAValor, T000A2_A5Cod_Area, T000A2_A4IndicadoresCodigo
               }
               , new Object[] {
               T000A3_A27COSUSPTONFRUTAFecha, T000A3_A28COSUSPTONFRUTAMes, T000A3_A29COSUSPTONFRUTAAno, T000A3_A134COSUSPTONFRUTAValor, T000A3_A5Cod_Area, T000A3_A4IndicadoresCodigo
               }
               , new Object[] {
               T000A4_A5Cod_Area
               }
               , new Object[] {
               T000A5_A4IndicadoresCodigo
               }
               , new Object[] {
               T000A6_A27COSUSPTONFRUTAFecha, T000A6_A28COSUSPTONFRUTAMes, T000A6_A29COSUSPTONFRUTAAno, T000A6_A134COSUSPTONFRUTAValor, T000A6_A5Cod_Area, T000A6_A4IndicadoresCodigo
               }
               , new Object[] {
               T000A7_A5Cod_Area
               }
               , new Object[] {
               T000A8_A4IndicadoresCodigo
               }
               , new Object[] {
               T000A9_A27COSUSPTONFRUTAFecha, T000A9_A28COSUSPTONFRUTAMes, T000A9_A29COSUSPTONFRUTAAno, T000A9_A5Cod_Area, T000A9_A4IndicadoresCodigo
               }
               , new Object[] {
               T000A10_A27COSUSPTONFRUTAFecha, T000A10_A28COSUSPTONFRUTAMes, T000A10_A29COSUSPTONFRUTAAno, T000A10_A5Cod_Area, T000A10_A4IndicadoresCodigo
               }
               , new Object[] {
               T000A11_A27COSUSPTONFRUTAFecha, T000A11_A28COSUSPTONFRUTAMes, T000A11_A29COSUSPTONFRUTAAno, T000A11_A5Cod_Area, T000A11_A4IndicadoresCodigo
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000A15_A27COSUSPTONFRUTAFecha, T000A15_A28COSUSPTONFRUTAMes, T000A15_A29COSUSPTONFRUTAAno, T000A15_A5Cod_Area, T000A15_A4IndicadoresCodigo
               }
               , new Object[] {
               T000A16_A5Cod_Area
               }
               , new Object[] {
               T000A17_A4IndicadoresCodigo
               }
            }
         );
      }

      private short Z28COSUSPTONFRUTAMes ;
      private short Z29COSUSPTONFRUTAAno ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A28COSUSPTONFRUTAMes ;
      private short A29COSUSPTONFRUTAAno ;
      private short GX_JID ;
      private short RcdFound11 ;
      private short nIsDirty_11 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ28COSUSPTONFRUTAMes ;
      private short ZZ29COSUSPTONFRUTAAno ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtCOSUSPTONFRUTAFecha_Enabled ;
      private int edtCOSUSPTONFRUTAMes_Enabled ;
      private int edtCOSUSPTONFRUTAAno_Enabled ;
      private int edtCod_Area_Enabled ;
      private int imgprompt_5_Visible ;
      private int edtIndicadoresCodigo_Enabled ;
      private int imgprompt_4_Visible ;
      private int edtCOSUSPTONFRUTAValor_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private decimal Z134COSUSPTONFRUTAValor ;
      private decimal A134COSUSPTONFRUTAValor ;
      private decimal ZZ134COSUSPTONFRUTAValor ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCOSUSPTONFRUTAFecha_Internalname ;
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
      private string edtCOSUSPTONFRUTAFecha_Jsonclick ;
      private string edtCOSUSPTONFRUTAMes_Internalname ;
      private string edtCOSUSPTONFRUTAMes_Jsonclick ;
      private string edtCOSUSPTONFRUTAAno_Internalname ;
      private string edtCOSUSPTONFRUTAAno_Jsonclick ;
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
      private string edtCOSUSPTONFRUTAValor_Internalname ;
      private string edtCOSUSPTONFRUTAValor_Jsonclick ;
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
      private string sMode11 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z27COSUSPTONFRUTAFecha ;
      private DateTime A27COSUSPTONFRUTAFecha ;
      private DateTime ZZ27COSUSPTONFRUTAFecha ;
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
      private DateTime[] T000A6_A27COSUSPTONFRUTAFecha ;
      private short[] T000A6_A28COSUSPTONFRUTAMes ;
      private short[] T000A6_A29COSUSPTONFRUTAAno ;
      private decimal[] T000A6_A134COSUSPTONFRUTAValor ;
      private string[] T000A6_A5Cod_Area ;
      private string[] T000A6_A4IndicadoresCodigo ;
      private string[] T000A4_A5Cod_Area ;
      private string[] T000A5_A4IndicadoresCodigo ;
      private string[] T000A7_A5Cod_Area ;
      private string[] T000A8_A4IndicadoresCodigo ;
      private DateTime[] T000A9_A27COSUSPTONFRUTAFecha ;
      private short[] T000A9_A28COSUSPTONFRUTAMes ;
      private short[] T000A9_A29COSUSPTONFRUTAAno ;
      private string[] T000A9_A5Cod_Area ;
      private string[] T000A9_A4IndicadoresCodigo ;
      private DateTime[] T000A3_A27COSUSPTONFRUTAFecha ;
      private short[] T000A3_A28COSUSPTONFRUTAMes ;
      private short[] T000A3_A29COSUSPTONFRUTAAno ;
      private decimal[] T000A3_A134COSUSPTONFRUTAValor ;
      private string[] T000A3_A5Cod_Area ;
      private string[] T000A3_A4IndicadoresCodigo ;
      private DateTime[] T000A10_A27COSUSPTONFRUTAFecha ;
      private short[] T000A10_A28COSUSPTONFRUTAMes ;
      private short[] T000A10_A29COSUSPTONFRUTAAno ;
      private string[] T000A10_A5Cod_Area ;
      private string[] T000A10_A4IndicadoresCodigo ;
      private DateTime[] T000A11_A27COSUSPTONFRUTAFecha ;
      private short[] T000A11_A28COSUSPTONFRUTAMes ;
      private short[] T000A11_A29COSUSPTONFRUTAAno ;
      private string[] T000A11_A5Cod_Area ;
      private string[] T000A11_A4IndicadoresCodigo ;
      private DateTime[] T000A2_A27COSUSPTONFRUTAFecha ;
      private short[] T000A2_A28COSUSPTONFRUTAMes ;
      private short[] T000A2_A29COSUSPTONFRUTAAno ;
      private decimal[] T000A2_A134COSUSPTONFRUTAValor ;
      private string[] T000A2_A5Cod_Area ;
      private string[] T000A2_A4IndicadoresCodigo ;
      private DateTime[] T000A15_A27COSUSPTONFRUTAFecha ;
      private short[] T000A15_A28COSUSPTONFRUTAMes ;
      private short[] T000A15_A29COSUSPTONFRUTAAno ;
      private string[] T000A15_A5Cod_Area ;
      private string[] T000A15_A4IndicadoresCodigo ;
      private string[] T000A16_A5Cod_Area ;
      private string[] T000A17_A4IndicadoresCodigo ;
      private GXWebForm Form ;
   }

   public class cosusptonfruta__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT000A6;
          prmT000A6 = new Object[] {
          new ParDef("@COSUSPTONFRUTAFecha",GXType.Date,8,0) ,
          new ParDef("@COSUSPTONFRUTAMes",GXType.Int16,4,0) ,
          new ParDef("@COSUSPTONFRUTAAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000A4;
          prmT000A4 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000A5;
          prmT000A5 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000A7;
          prmT000A7 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000A8;
          prmT000A8 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000A9;
          prmT000A9 = new Object[] {
          new ParDef("@COSUSPTONFRUTAFecha",GXType.Date,8,0) ,
          new ParDef("@COSUSPTONFRUTAMes",GXType.Int16,4,0) ,
          new ParDef("@COSUSPTONFRUTAAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000A3;
          prmT000A3 = new Object[] {
          new ParDef("@COSUSPTONFRUTAFecha",GXType.Date,8,0) ,
          new ParDef("@COSUSPTONFRUTAMes",GXType.Int16,4,0) ,
          new ParDef("@COSUSPTONFRUTAAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000A10;
          prmT000A10 = new Object[] {
          new ParDef("@COSUSPTONFRUTAFecha",GXType.Date,8,0) ,
          new ParDef("@COSUSPTONFRUTAMes",GXType.Int16,4,0) ,
          new ParDef("@COSUSPTONFRUTAAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000A11;
          prmT000A11 = new Object[] {
          new ParDef("@COSUSPTONFRUTAFecha",GXType.Date,8,0) ,
          new ParDef("@COSUSPTONFRUTAMes",GXType.Int16,4,0) ,
          new ParDef("@COSUSPTONFRUTAAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000A2;
          prmT000A2 = new Object[] {
          new ParDef("@COSUSPTONFRUTAFecha",GXType.Date,8,0) ,
          new ParDef("@COSUSPTONFRUTAMes",GXType.Int16,4,0) ,
          new ParDef("@COSUSPTONFRUTAAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000A12;
          prmT000A12 = new Object[] {
          new ParDef("@COSUSPTONFRUTAFecha",GXType.Date,8,0) ,
          new ParDef("@COSUSPTONFRUTAMes",GXType.Int16,4,0) ,
          new ParDef("@COSUSPTONFRUTAAno",GXType.Int16,4,0) ,
          new ParDef("@COSUSPTONFRUTAValor",GXType.Decimal,12,5) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000A13;
          prmT000A13 = new Object[] {
          new ParDef("@COSUSPTONFRUTAValor",GXType.Decimal,12,5) ,
          new ParDef("@COSUSPTONFRUTAFecha",GXType.Date,8,0) ,
          new ParDef("@COSUSPTONFRUTAMes",GXType.Int16,4,0) ,
          new ParDef("@COSUSPTONFRUTAAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000A14;
          prmT000A14 = new Object[] {
          new ParDef("@COSUSPTONFRUTAFecha",GXType.Date,8,0) ,
          new ParDef("@COSUSPTONFRUTAMes",GXType.Int16,4,0) ,
          new ParDef("@COSUSPTONFRUTAAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000A15;
          prmT000A15 = new Object[] {
          };
          Object[] prmT000A16;
          prmT000A16 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000A17;
          prmT000A17 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("T000A2", "SELECT [COSUSPTONFRUTAFecha], [COSUSPTONFRUTAMes], [COSUSPTONFRUTAAno], [COSUSPTONFRUTAValor], [Cod_Area], [IndicadoresCodigo] FROM [COSUSPTONFRUTA] WITH (UPDLOCK) WHERE [COSUSPTONFRUTAFecha] = @COSUSPTONFRUTAFecha AND [COSUSPTONFRUTAMes] = @COSUSPTONFRUTAMes AND [COSUSPTONFRUTAAno] = @COSUSPTONFRUTAAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A3", "SELECT [COSUSPTONFRUTAFecha], [COSUSPTONFRUTAMes], [COSUSPTONFRUTAAno], [COSUSPTONFRUTAValor], [Cod_Area], [IndicadoresCodigo] FROM [COSUSPTONFRUTA] WHERE [COSUSPTONFRUTAFecha] = @COSUSPTONFRUTAFecha AND [COSUSPTONFRUTAMes] = @COSUSPTONFRUTAMes AND [COSUSPTONFRUTAAno] = @COSUSPTONFRUTAAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A4", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A5", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A6", "SELECT TM1.[COSUSPTONFRUTAFecha], TM1.[COSUSPTONFRUTAMes], TM1.[COSUSPTONFRUTAAno], TM1.[COSUSPTONFRUTAValor], TM1.[Cod_Area], TM1.[IndicadoresCodigo] FROM [COSUSPTONFRUTA] TM1 WHERE TM1.[COSUSPTONFRUTAFecha] = @COSUSPTONFRUTAFecha and TM1.[COSUSPTONFRUTAMes] = @COSUSPTONFRUTAMes and TM1.[COSUSPTONFRUTAAno] = @COSUSPTONFRUTAAno and TM1.[Cod_Area] = @Cod_Area and TM1.[IndicadoresCodigo] = @IndicadoresCodigo ORDER BY TM1.[COSUSPTONFRUTAFecha], TM1.[COSUSPTONFRUTAMes], TM1.[COSUSPTONFRUTAAno], TM1.[Cod_Area], TM1.[IndicadoresCodigo]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A7", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A8", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A9", "SELECT [COSUSPTONFRUTAFecha], [COSUSPTONFRUTAMes], [COSUSPTONFRUTAAno], [Cod_Area], [IndicadoresCodigo] FROM [COSUSPTONFRUTA] WHERE [COSUSPTONFRUTAFecha] = @COSUSPTONFRUTAFecha AND [COSUSPTONFRUTAMes] = @COSUSPTONFRUTAMes AND [COSUSPTONFRUTAAno] = @COSUSPTONFRUTAAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A10", "SELECT TOP 1 [COSUSPTONFRUTAFecha], [COSUSPTONFRUTAMes], [COSUSPTONFRUTAAno], [Cod_Area], [IndicadoresCodigo] FROM [COSUSPTONFRUTA] WHERE ( [COSUSPTONFRUTAFecha] > @COSUSPTONFRUTAFecha or [COSUSPTONFRUTAFecha] = @COSUSPTONFRUTAFecha and [COSUSPTONFRUTAMes] > @COSUSPTONFRUTAMes or [COSUSPTONFRUTAMes] = @COSUSPTONFRUTAMes and [COSUSPTONFRUTAFecha] = @COSUSPTONFRUTAFecha and [COSUSPTONFRUTAAno] > @COSUSPTONFRUTAAno or [COSUSPTONFRUTAAno] = @COSUSPTONFRUTAAno and [COSUSPTONFRUTAMes] = @COSUSPTONFRUTAMes and [COSUSPTONFRUTAFecha] = @COSUSPTONFRUTAFecha and [Cod_Area] > @Cod_Area or [Cod_Area] = @Cod_Area and [COSUSPTONFRUTAAno] = @COSUSPTONFRUTAAno and [COSUSPTONFRUTAMes] = @COSUSPTONFRUTAMes and [COSUSPTONFRUTAFecha] = @COSUSPTONFRUTAFecha and [IndicadoresCodigo] > @IndicadoresCodigo) ORDER BY [COSUSPTONFRUTAFecha], [COSUSPTONFRUTAMes], [COSUSPTONFRUTAAno], [Cod_Area], [IndicadoresCodigo]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A10,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000A11", "SELECT TOP 1 [COSUSPTONFRUTAFecha], [COSUSPTONFRUTAMes], [COSUSPTONFRUTAAno], [Cod_Area], [IndicadoresCodigo] FROM [COSUSPTONFRUTA] WHERE ( [COSUSPTONFRUTAFecha] < @COSUSPTONFRUTAFecha or [COSUSPTONFRUTAFecha] = @COSUSPTONFRUTAFecha and [COSUSPTONFRUTAMes] < @COSUSPTONFRUTAMes or [COSUSPTONFRUTAMes] = @COSUSPTONFRUTAMes and [COSUSPTONFRUTAFecha] = @COSUSPTONFRUTAFecha and [COSUSPTONFRUTAAno] < @COSUSPTONFRUTAAno or [COSUSPTONFRUTAAno] = @COSUSPTONFRUTAAno and [COSUSPTONFRUTAMes] = @COSUSPTONFRUTAMes and [COSUSPTONFRUTAFecha] = @COSUSPTONFRUTAFecha and [Cod_Area] < @Cod_Area or [Cod_Area] = @Cod_Area and [COSUSPTONFRUTAAno] = @COSUSPTONFRUTAAno and [COSUSPTONFRUTAMes] = @COSUSPTONFRUTAMes and [COSUSPTONFRUTAFecha] = @COSUSPTONFRUTAFecha and [IndicadoresCodigo] < @IndicadoresCodigo) ORDER BY [COSUSPTONFRUTAFecha] DESC, [COSUSPTONFRUTAMes] DESC, [COSUSPTONFRUTAAno] DESC, [Cod_Area] DESC, [IndicadoresCodigo] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A11,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000A12", "INSERT INTO [COSUSPTONFRUTA]([COSUSPTONFRUTAFecha], [COSUSPTONFRUTAMes], [COSUSPTONFRUTAAno], [COSUSPTONFRUTAValor], [Cod_Area], [IndicadoresCodigo]) VALUES(@COSUSPTONFRUTAFecha, @COSUSPTONFRUTAMes, @COSUSPTONFRUTAAno, @COSUSPTONFRUTAValor, @Cod_Area, @IndicadoresCodigo)", GxErrorMask.GX_NOMASK,prmT000A12)
             ,new CursorDef("T000A13", "UPDATE [COSUSPTONFRUTA] SET [COSUSPTONFRUTAValor]=@COSUSPTONFRUTAValor  WHERE [COSUSPTONFRUTAFecha] = @COSUSPTONFRUTAFecha AND [COSUSPTONFRUTAMes] = @COSUSPTONFRUTAMes AND [COSUSPTONFRUTAAno] = @COSUSPTONFRUTAAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo", GxErrorMask.GX_NOMASK,prmT000A13)
             ,new CursorDef("T000A14", "DELETE FROM [COSUSPTONFRUTA]  WHERE [COSUSPTONFRUTAFecha] = @COSUSPTONFRUTAFecha AND [COSUSPTONFRUTAMes] = @COSUSPTONFRUTAMes AND [COSUSPTONFRUTAAno] = @COSUSPTONFRUTAAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo", GxErrorMask.GX_NOMASK,prmT000A14)
             ,new CursorDef("T000A15", "SELECT [COSUSPTONFRUTAFecha], [COSUSPTONFRUTAMes], [COSUSPTONFRUTAAno], [Cod_Area], [IndicadoresCodigo] FROM [COSUSPTONFRUTA] ORDER BY [COSUSPTONFRUTAFecha], [COSUSPTONFRUTAMes], [COSUSPTONFRUTAAno], [Cod_Area], [IndicadoresCodigo]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A15,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A16", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A16,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A17", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A17,1, GxCacheFrequency.OFF ,true,false )
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
