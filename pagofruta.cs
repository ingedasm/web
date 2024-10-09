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
   public class pagofruta : GXDataArea
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
            A30MotivosUspCodigo = GetPar( "MotivosUspCodigo");
            AssignAttri("", false, "A30MotivosUspCodigo", A30MotivosUspCodigo);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A30MotivosUspCodigo) ;
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
            Form.Meta.addItem("description", "PAGOFRUTA", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtPAGOFRUTAFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("IndicadroresPalmas", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public pagofruta( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("IndicadroresPalmas", true);
      }

      public pagofruta( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "PAGOFRUTA", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_PAGOFRUTA.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_PAGOFRUTA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_PAGOFRUTA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_PAGOFRUTA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_PAGOFRUTA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 4, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx00d0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PAGOFRUTAFECHA"+"'), id:'"+"PAGOFRUTAFECHA"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"PAGOFRUTAMES"+"'), id:'"+"PAGOFRUTAMES"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"PAGOFRUTAANO"+"'), id:'"+"PAGOFRUTAANO"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"COD_AREA"+"'), id:'"+"COD_AREA"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"INDICADORESCODIGO"+"'), id:'"+"INDICADORESCODIGO"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"MOTIVOSUSPCODIGO"+"'), id:'"+"MOTIVOSUSPCODIGO"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_PAGOFRUTA.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPAGOFRUTAFecha_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPAGOFRUTAFecha_Internalname, "PAGOFRUTAFecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtPAGOFRUTAFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPAGOFRUTAFecha_Internalname, context.localUtil.Format(A68PAGOFRUTAFecha, "99/99/99"), context.localUtil.Format( A68PAGOFRUTAFecha, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPAGOFRUTAFecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPAGOFRUTAFecha_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_PAGOFRUTA.htm");
         GxWebStd.gx_bitmap( context, edtPAGOFRUTAFecha_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPAGOFRUTAFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_PAGOFRUTA.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPAGOFRUTAMes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPAGOFRUTAMes_Internalname, "PAGOFRUTAMes", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPAGOFRUTAMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A69PAGOFRUTAMes), 4, 0, ",", "")), StringUtil.LTrim( ((edtPAGOFRUTAMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A69PAGOFRUTAMes), "ZZZ9") : context.localUtil.Format( (decimal)(A69PAGOFRUTAMes), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPAGOFRUTAMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPAGOFRUTAMes_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_PAGOFRUTA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPAGOFRUTAAno_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPAGOFRUTAAno_Internalname, "PAGOFRUTAAno", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPAGOFRUTAAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A70PAGOFRUTAAno), 4, 0, ",", "")), StringUtil.LTrim( ((edtPAGOFRUTAAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A70PAGOFRUTAAno), "ZZZ9") : context.localUtil.Format( (decimal)(A70PAGOFRUTAAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPAGOFRUTAAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPAGOFRUTAAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_PAGOFRUTA.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCod_Area_Internalname, A5Cod_Area, StringUtil.RTrim( context.localUtil.Format( A5Cod_Area, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCod_Area_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCod_Area_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_PAGOFRUTA.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_5_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_5_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_5_Internalname, sImgUrl, imgprompt_5_Link, "", "", context.GetTheme( ), imgprompt_5_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_PAGOFRUTA.htm");
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
         GxWebStd.gx_single_line_edit( context, edtIndicadoresCodigo_Internalname, A4IndicadoresCodigo, StringUtil.RTrim( context.localUtil.Format( A4IndicadoresCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIndicadoresCodigo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIndicadoresCodigo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_PAGOFRUTA.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_4_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_4_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_4_Internalname, sImgUrl, imgprompt_4_Link, "", "", context.GetTheme( ), imgprompt_4_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_PAGOFRUTA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMotivosUspCodigo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMotivosUspCodigo_Internalname, "Motivos Usp Codigo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMotivosUspCodigo_Internalname, A30MotivosUspCodigo, StringUtil.RTrim( context.localUtil.Format( A30MotivosUspCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMotivosUspCodigo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMotivosUspCodigo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_PAGOFRUTA.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_30_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_30_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_30_Internalname, sImgUrl, imgprompt_30_Link, "", "", context.GetTheme( ), imgprompt_30_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_PAGOFRUTA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPAGOFRUTAValor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPAGOFRUTAValor_Internalname, "PAGOFRUTAValor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPAGOFRUTAValor_Internalname, StringUtil.LTrim( StringUtil.NToC( A136PAGOFRUTAValor, 14, 2, ",", "")), StringUtil.LTrim( ((edtPAGOFRUTAValor_Enabled!=0) ? context.localUtil.Format( A136PAGOFRUTAValor, "ZZZZZZZZZZ9.99") : context.localUtil.Format( A136PAGOFRUTAValor, "ZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPAGOFRUTAValor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPAGOFRUTAValor_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_PAGOFRUTA.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_PAGOFRUTA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_PAGOFRUTA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_PAGOFRUTA.htm");
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
            Z68PAGOFRUTAFecha = context.localUtil.CToD( cgiGet( "Z68PAGOFRUTAFecha"), 0);
            Z69PAGOFRUTAMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z69PAGOFRUTAMes"), ",", "."), 18, MidpointRounding.ToEven));
            Z70PAGOFRUTAAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z70PAGOFRUTAAno"), ",", "."), 18, MidpointRounding.ToEven));
            Z5Cod_Area = cgiGet( "Z5Cod_Area");
            Z4IndicadoresCodigo = cgiGet( "Z4IndicadoresCodigo");
            Z30MotivosUspCodigo = cgiGet( "Z30MotivosUspCodigo");
            Z136PAGOFRUTAValor = context.localUtil.CToN( cgiGet( "Z136PAGOFRUTAValor"), ",", ".");
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( context.localUtil.VCDate( cgiGet( edtPAGOFRUTAFecha_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"PAGOFRUTAFecha"}), 1, "PAGOFRUTAFECHA");
               AnyError = 1;
               GX_FocusControl = edtPAGOFRUTAFecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A68PAGOFRUTAFecha = DateTime.MinValue;
               AssignAttri("", false, "A68PAGOFRUTAFecha", context.localUtil.Format(A68PAGOFRUTAFecha, "99/99/99"));
            }
            else
            {
               A68PAGOFRUTAFecha = context.localUtil.CToD( cgiGet( edtPAGOFRUTAFecha_Internalname), 2);
               AssignAttri("", false, "A68PAGOFRUTAFecha", context.localUtil.Format(A68PAGOFRUTAFecha, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtPAGOFRUTAMes_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPAGOFRUTAMes_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PAGOFRUTAMES");
               AnyError = 1;
               GX_FocusControl = edtPAGOFRUTAMes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A69PAGOFRUTAMes = 0;
               AssignAttri("", false, "A69PAGOFRUTAMes", StringUtil.LTrimStr( (decimal)(A69PAGOFRUTAMes), 4, 0));
            }
            else
            {
               A69PAGOFRUTAMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPAGOFRUTAMes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A69PAGOFRUTAMes", StringUtil.LTrimStr( (decimal)(A69PAGOFRUTAMes), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtPAGOFRUTAAno_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPAGOFRUTAAno_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PAGOFRUTAANO");
               AnyError = 1;
               GX_FocusControl = edtPAGOFRUTAAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A70PAGOFRUTAAno = 0;
               AssignAttri("", false, "A70PAGOFRUTAAno", StringUtil.LTrimStr( (decimal)(A70PAGOFRUTAAno), 4, 0));
            }
            else
            {
               A70PAGOFRUTAAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPAGOFRUTAAno_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A70PAGOFRUTAAno", StringUtil.LTrimStr( (decimal)(A70PAGOFRUTAAno), 4, 0));
            }
            A5Cod_Area = cgiGet( edtCod_Area_Internalname);
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = cgiGet( edtIndicadoresCodigo_Internalname);
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A30MotivosUspCodigo = cgiGet( edtMotivosUspCodigo_Internalname);
            AssignAttri("", false, "A30MotivosUspCodigo", A30MotivosUspCodigo);
            if ( ( ( context.localUtil.CToN( cgiGet( edtPAGOFRUTAValor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPAGOFRUTAValor_Internalname), ",", ".") > 99999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PAGOFRUTAVALOR");
               AnyError = 1;
               GX_FocusControl = edtPAGOFRUTAValor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A136PAGOFRUTAValor = 0;
               AssignAttri("", false, "A136PAGOFRUTAValor", StringUtil.LTrimStr( A136PAGOFRUTAValor, 14, 2));
            }
            else
            {
               A136PAGOFRUTAValor = context.localUtil.CToN( cgiGet( edtPAGOFRUTAValor_Internalname), ",", ".");
               AssignAttri("", false, "A136PAGOFRUTAValor", StringUtil.LTrimStr( A136PAGOFRUTAValor, 14, 2));
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
               A68PAGOFRUTAFecha = context.localUtil.ParseDateParm( GetPar( "PAGOFRUTAFecha"));
               AssignAttri("", false, "A68PAGOFRUTAFecha", context.localUtil.Format(A68PAGOFRUTAFecha, "99/99/99"));
               A69PAGOFRUTAMes = (short)(Math.Round(NumberUtil.Val( GetPar( "PAGOFRUTAMes"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A69PAGOFRUTAMes", StringUtil.LTrimStr( (decimal)(A69PAGOFRUTAMes), 4, 0));
               A70PAGOFRUTAAno = (short)(Math.Round(NumberUtil.Val( GetPar( "PAGOFRUTAAno"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A70PAGOFRUTAAno", StringUtil.LTrimStr( (decimal)(A70PAGOFRUTAAno), 4, 0));
               A5Cod_Area = GetPar( "Cod_Area");
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               A4IndicadoresCodigo = GetPar( "IndicadoresCodigo");
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               A30MotivosUspCodigo = GetPar( "MotivosUspCodigo");
               AssignAttri("", false, "A30MotivosUspCodigo", A30MotivosUspCodigo);
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
               InitAll0C13( ) ;
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
         DisableAttributes0C13( ) ;
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

      protected void ResetCaption0C0( )
      {
      }

      protected void ZM0C13( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z136PAGOFRUTAValor = T000C3_A136PAGOFRUTAValor[0];
            }
            else
            {
               Z136PAGOFRUTAValor = A136PAGOFRUTAValor;
            }
         }
         if ( GX_JID == -2 )
         {
            Z68PAGOFRUTAFecha = A68PAGOFRUTAFecha;
            Z69PAGOFRUTAMes = A69PAGOFRUTAMes;
            Z70PAGOFRUTAAno = A70PAGOFRUTAAno;
            Z136PAGOFRUTAValor = A136PAGOFRUTAValor;
            Z5Cod_Area = A5Cod_Area;
            Z4IndicadoresCodigo = A4IndicadoresCodigo;
            Z30MotivosUspCodigo = A30MotivosUspCodigo;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_5_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"COD_AREA"+"'), id:'"+"COD_AREA"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"true"+");");
         imgprompt_4_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0030.aspx"+"',["+"{Ctrl:gx.dom.el('"+"INDICADORESCODIGO"+"'), id:'"+"INDICADORESCODIGO"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"true"+");");
         imgprompt_30_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx00c0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"MOTIVOSUSPCODIGO"+"'), id:'"+"MOTIVOSUSPCODIGO"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");");
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

      protected void Load0C13( )
      {
         /* Using cursor T000C7 */
         pr_default.execute(5, new Object[] {A68PAGOFRUTAFecha, A69PAGOFRUTAMes, A70PAGOFRUTAAno, A5Cod_Area, A4IndicadoresCodigo, A30MotivosUspCodigo});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound13 = 1;
            A136PAGOFRUTAValor = T000C7_A136PAGOFRUTAValor[0];
            AssignAttri("", false, "A136PAGOFRUTAValor", StringUtil.LTrimStr( A136PAGOFRUTAValor, 14, 2));
            ZM0C13( -2) ;
         }
         pr_default.close(5);
         OnLoadActions0C13( ) ;
      }

      protected void OnLoadActions0C13( )
      {
      }

      protected void CheckExtendedTable0C13( )
      {
         nIsDirty_13 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A68PAGOFRUTAFecha) || ( DateTimeUtil.ResetTime ( A68PAGOFRUTAFecha ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo PAGOFRUTAFecha fuera de rango", "OutOfRange", 1, "PAGOFRUTAFECHA");
            AnyError = 1;
            GX_FocusControl = edtPAGOFRUTAFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000C4 */
         pr_default.execute(2, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T000C5 */
         pr_default.execute(3, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         /* Using cursor T000C6 */
         pr_default.execute(4, new Object[] {A30MotivosUspCodigo});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Motivos Usp'.", "ForeignKeyNotFound", 1, "MOTIVOSUSPCODIGO");
            AnyError = 1;
            GX_FocusControl = edtMotivosUspCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors0C13( )
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
         /* Using cursor T000C8 */
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
         /* Using cursor T000C9 */
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

      protected void gxLoad_5( string A30MotivosUspCodigo )
      {
         /* Using cursor T000C10 */
         pr_default.execute(8, new Object[] {A30MotivosUspCodigo});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Motivos Usp'.", "ForeignKeyNotFound", 1, "MOTIVOSUSPCODIGO");
            AnyError = 1;
            GX_FocusControl = edtMotivosUspCodigo_Internalname;
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

      protected void GetKey0C13( )
      {
         /* Using cursor T000C11 */
         pr_default.execute(9, new Object[] {A68PAGOFRUTAFecha, A69PAGOFRUTAMes, A70PAGOFRUTAAno, A5Cod_Area, A4IndicadoresCodigo, A30MotivosUspCodigo});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound13 = 1;
         }
         else
         {
            RcdFound13 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000C3 */
         pr_default.execute(1, new Object[] {A68PAGOFRUTAFecha, A69PAGOFRUTAMes, A70PAGOFRUTAAno, A5Cod_Area, A4IndicadoresCodigo, A30MotivosUspCodigo});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0C13( 2) ;
            RcdFound13 = 1;
            A68PAGOFRUTAFecha = T000C3_A68PAGOFRUTAFecha[0];
            AssignAttri("", false, "A68PAGOFRUTAFecha", context.localUtil.Format(A68PAGOFRUTAFecha, "99/99/99"));
            A69PAGOFRUTAMes = T000C3_A69PAGOFRUTAMes[0];
            AssignAttri("", false, "A69PAGOFRUTAMes", StringUtil.LTrimStr( (decimal)(A69PAGOFRUTAMes), 4, 0));
            A70PAGOFRUTAAno = T000C3_A70PAGOFRUTAAno[0];
            AssignAttri("", false, "A70PAGOFRUTAAno", StringUtil.LTrimStr( (decimal)(A70PAGOFRUTAAno), 4, 0));
            A136PAGOFRUTAValor = T000C3_A136PAGOFRUTAValor[0];
            AssignAttri("", false, "A136PAGOFRUTAValor", StringUtil.LTrimStr( A136PAGOFRUTAValor, 14, 2));
            A5Cod_Area = T000C3_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = T000C3_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A30MotivosUspCodigo = T000C3_A30MotivosUspCodigo[0];
            AssignAttri("", false, "A30MotivosUspCodigo", A30MotivosUspCodigo);
            Z68PAGOFRUTAFecha = A68PAGOFRUTAFecha;
            Z69PAGOFRUTAMes = A69PAGOFRUTAMes;
            Z70PAGOFRUTAAno = A70PAGOFRUTAAno;
            Z5Cod_Area = A5Cod_Area;
            Z4IndicadoresCodigo = A4IndicadoresCodigo;
            Z30MotivosUspCodigo = A30MotivosUspCodigo;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0C13( ) ;
            if ( AnyError == 1 )
            {
               RcdFound13 = 0;
               InitializeNonKey0C13( ) ;
            }
            Gx_mode = sMode13;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound13 = 0;
            InitializeNonKey0C13( ) ;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode13;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0C13( ) ;
         if ( RcdFound13 == 0 )
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
         RcdFound13 = 0;
         /* Using cursor T000C12 */
         pr_default.execute(10, new Object[] {A68PAGOFRUTAFecha, A69PAGOFRUTAMes, A70PAGOFRUTAAno, A5Cod_Area, A4IndicadoresCodigo, A30MotivosUspCodigo});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( DateTimeUtil.ResetTime ( T000C12_A68PAGOFRUTAFecha[0] ) < DateTimeUtil.ResetTime ( A68PAGOFRUTAFecha ) ) || ( DateTimeUtil.ResetTime ( T000C12_A68PAGOFRUTAFecha[0] ) == DateTimeUtil.ResetTime ( A68PAGOFRUTAFecha ) ) && ( T000C12_A69PAGOFRUTAMes[0] < A69PAGOFRUTAMes ) || ( T000C12_A69PAGOFRUTAMes[0] == A69PAGOFRUTAMes ) && ( DateTimeUtil.ResetTime ( T000C12_A68PAGOFRUTAFecha[0] ) == DateTimeUtil.ResetTime ( A68PAGOFRUTAFecha ) ) && ( T000C12_A70PAGOFRUTAAno[0] < A70PAGOFRUTAAno ) || ( T000C12_A70PAGOFRUTAAno[0] == A70PAGOFRUTAAno ) && ( T000C12_A69PAGOFRUTAMes[0] == A69PAGOFRUTAMes ) && ( DateTimeUtil.ResetTime ( T000C12_A68PAGOFRUTAFecha[0] ) == DateTimeUtil.ResetTime ( A68PAGOFRUTAFecha ) ) && ( StringUtil.StrCmp(T000C12_A5Cod_Area[0], A5Cod_Area) < 0 ) || ( StringUtil.StrCmp(T000C12_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000C12_A70PAGOFRUTAAno[0] == A70PAGOFRUTAAno ) && ( T000C12_A69PAGOFRUTAMes[0] == A69PAGOFRUTAMes ) && ( DateTimeUtil.ResetTime ( T000C12_A68PAGOFRUTAFecha[0] ) == DateTimeUtil.ResetTime ( A68PAGOFRUTAFecha ) ) && ( StringUtil.StrCmp(T000C12_A4IndicadoresCodigo[0], A4IndicadoresCodigo) < 0 ) || ( StringUtil.StrCmp(T000C12_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T000C12_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000C12_A70PAGOFRUTAAno[0] == A70PAGOFRUTAAno ) && ( T000C12_A69PAGOFRUTAMes[0] == A69PAGOFRUTAMes ) && ( DateTimeUtil.ResetTime ( T000C12_A68PAGOFRUTAFecha[0] ) == DateTimeUtil.ResetTime ( A68PAGOFRUTAFecha ) ) && ( StringUtil.StrCmp(T000C12_A30MotivosUspCodigo[0], A30MotivosUspCodigo) < 0 ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( DateTimeUtil.ResetTime ( T000C12_A68PAGOFRUTAFecha[0] ) > DateTimeUtil.ResetTime ( A68PAGOFRUTAFecha ) ) || ( DateTimeUtil.ResetTime ( T000C12_A68PAGOFRUTAFecha[0] ) == DateTimeUtil.ResetTime ( A68PAGOFRUTAFecha ) ) && ( T000C12_A69PAGOFRUTAMes[0] > A69PAGOFRUTAMes ) || ( T000C12_A69PAGOFRUTAMes[0] == A69PAGOFRUTAMes ) && ( DateTimeUtil.ResetTime ( T000C12_A68PAGOFRUTAFecha[0] ) == DateTimeUtil.ResetTime ( A68PAGOFRUTAFecha ) ) && ( T000C12_A70PAGOFRUTAAno[0] > A70PAGOFRUTAAno ) || ( T000C12_A70PAGOFRUTAAno[0] == A70PAGOFRUTAAno ) && ( T000C12_A69PAGOFRUTAMes[0] == A69PAGOFRUTAMes ) && ( DateTimeUtil.ResetTime ( T000C12_A68PAGOFRUTAFecha[0] ) == DateTimeUtil.ResetTime ( A68PAGOFRUTAFecha ) ) && ( StringUtil.StrCmp(T000C12_A5Cod_Area[0], A5Cod_Area) > 0 ) || ( StringUtil.StrCmp(T000C12_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000C12_A70PAGOFRUTAAno[0] == A70PAGOFRUTAAno ) && ( T000C12_A69PAGOFRUTAMes[0] == A69PAGOFRUTAMes ) && ( DateTimeUtil.ResetTime ( T000C12_A68PAGOFRUTAFecha[0] ) == DateTimeUtil.ResetTime ( A68PAGOFRUTAFecha ) ) && ( StringUtil.StrCmp(T000C12_A4IndicadoresCodigo[0], A4IndicadoresCodigo) > 0 ) || ( StringUtil.StrCmp(T000C12_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T000C12_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000C12_A70PAGOFRUTAAno[0] == A70PAGOFRUTAAno ) && ( T000C12_A69PAGOFRUTAMes[0] == A69PAGOFRUTAMes ) && ( DateTimeUtil.ResetTime ( T000C12_A68PAGOFRUTAFecha[0] ) == DateTimeUtil.ResetTime ( A68PAGOFRUTAFecha ) ) && ( StringUtil.StrCmp(T000C12_A30MotivosUspCodigo[0], A30MotivosUspCodigo) > 0 ) ) )
            {
               A68PAGOFRUTAFecha = T000C12_A68PAGOFRUTAFecha[0];
               AssignAttri("", false, "A68PAGOFRUTAFecha", context.localUtil.Format(A68PAGOFRUTAFecha, "99/99/99"));
               A69PAGOFRUTAMes = T000C12_A69PAGOFRUTAMes[0];
               AssignAttri("", false, "A69PAGOFRUTAMes", StringUtil.LTrimStr( (decimal)(A69PAGOFRUTAMes), 4, 0));
               A70PAGOFRUTAAno = T000C12_A70PAGOFRUTAAno[0];
               AssignAttri("", false, "A70PAGOFRUTAAno", StringUtil.LTrimStr( (decimal)(A70PAGOFRUTAAno), 4, 0));
               A5Cod_Area = T000C12_A5Cod_Area[0];
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               A4IndicadoresCodigo = T000C12_A4IndicadoresCodigo[0];
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               A30MotivosUspCodigo = T000C12_A30MotivosUspCodigo[0];
               AssignAttri("", false, "A30MotivosUspCodigo", A30MotivosUspCodigo);
               RcdFound13 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound13 = 0;
         /* Using cursor T000C13 */
         pr_default.execute(11, new Object[] {A68PAGOFRUTAFecha, A69PAGOFRUTAMes, A70PAGOFRUTAAno, A5Cod_Area, A4IndicadoresCodigo, A30MotivosUspCodigo});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( DateTimeUtil.ResetTime ( T000C13_A68PAGOFRUTAFecha[0] ) > DateTimeUtil.ResetTime ( A68PAGOFRUTAFecha ) ) || ( DateTimeUtil.ResetTime ( T000C13_A68PAGOFRUTAFecha[0] ) == DateTimeUtil.ResetTime ( A68PAGOFRUTAFecha ) ) && ( T000C13_A69PAGOFRUTAMes[0] > A69PAGOFRUTAMes ) || ( T000C13_A69PAGOFRUTAMes[0] == A69PAGOFRUTAMes ) && ( DateTimeUtil.ResetTime ( T000C13_A68PAGOFRUTAFecha[0] ) == DateTimeUtil.ResetTime ( A68PAGOFRUTAFecha ) ) && ( T000C13_A70PAGOFRUTAAno[0] > A70PAGOFRUTAAno ) || ( T000C13_A70PAGOFRUTAAno[0] == A70PAGOFRUTAAno ) && ( T000C13_A69PAGOFRUTAMes[0] == A69PAGOFRUTAMes ) && ( DateTimeUtil.ResetTime ( T000C13_A68PAGOFRUTAFecha[0] ) == DateTimeUtil.ResetTime ( A68PAGOFRUTAFecha ) ) && ( StringUtil.StrCmp(T000C13_A5Cod_Area[0], A5Cod_Area) > 0 ) || ( StringUtil.StrCmp(T000C13_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000C13_A70PAGOFRUTAAno[0] == A70PAGOFRUTAAno ) && ( T000C13_A69PAGOFRUTAMes[0] == A69PAGOFRUTAMes ) && ( DateTimeUtil.ResetTime ( T000C13_A68PAGOFRUTAFecha[0] ) == DateTimeUtil.ResetTime ( A68PAGOFRUTAFecha ) ) && ( StringUtil.StrCmp(T000C13_A4IndicadoresCodigo[0], A4IndicadoresCodigo) > 0 ) || ( StringUtil.StrCmp(T000C13_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T000C13_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000C13_A70PAGOFRUTAAno[0] == A70PAGOFRUTAAno ) && ( T000C13_A69PAGOFRUTAMes[0] == A69PAGOFRUTAMes ) && ( DateTimeUtil.ResetTime ( T000C13_A68PAGOFRUTAFecha[0] ) == DateTimeUtil.ResetTime ( A68PAGOFRUTAFecha ) ) && ( StringUtil.StrCmp(T000C13_A30MotivosUspCodigo[0], A30MotivosUspCodigo) > 0 ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( DateTimeUtil.ResetTime ( T000C13_A68PAGOFRUTAFecha[0] ) < DateTimeUtil.ResetTime ( A68PAGOFRUTAFecha ) ) || ( DateTimeUtil.ResetTime ( T000C13_A68PAGOFRUTAFecha[0] ) == DateTimeUtil.ResetTime ( A68PAGOFRUTAFecha ) ) && ( T000C13_A69PAGOFRUTAMes[0] < A69PAGOFRUTAMes ) || ( T000C13_A69PAGOFRUTAMes[0] == A69PAGOFRUTAMes ) && ( DateTimeUtil.ResetTime ( T000C13_A68PAGOFRUTAFecha[0] ) == DateTimeUtil.ResetTime ( A68PAGOFRUTAFecha ) ) && ( T000C13_A70PAGOFRUTAAno[0] < A70PAGOFRUTAAno ) || ( T000C13_A70PAGOFRUTAAno[0] == A70PAGOFRUTAAno ) && ( T000C13_A69PAGOFRUTAMes[0] == A69PAGOFRUTAMes ) && ( DateTimeUtil.ResetTime ( T000C13_A68PAGOFRUTAFecha[0] ) == DateTimeUtil.ResetTime ( A68PAGOFRUTAFecha ) ) && ( StringUtil.StrCmp(T000C13_A5Cod_Area[0], A5Cod_Area) < 0 ) || ( StringUtil.StrCmp(T000C13_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000C13_A70PAGOFRUTAAno[0] == A70PAGOFRUTAAno ) && ( T000C13_A69PAGOFRUTAMes[0] == A69PAGOFRUTAMes ) && ( DateTimeUtil.ResetTime ( T000C13_A68PAGOFRUTAFecha[0] ) == DateTimeUtil.ResetTime ( A68PAGOFRUTAFecha ) ) && ( StringUtil.StrCmp(T000C13_A4IndicadoresCodigo[0], A4IndicadoresCodigo) < 0 ) || ( StringUtil.StrCmp(T000C13_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T000C13_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000C13_A70PAGOFRUTAAno[0] == A70PAGOFRUTAAno ) && ( T000C13_A69PAGOFRUTAMes[0] == A69PAGOFRUTAMes ) && ( DateTimeUtil.ResetTime ( T000C13_A68PAGOFRUTAFecha[0] ) == DateTimeUtil.ResetTime ( A68PAGOFRUTAFecha ) ) && ( StringUtil.StrCmp(T000C13_A30MotivosUspCodigo[0], A30MotivosUspCodigo) < 0 ) ) )
            {
               A68PAGOFRUTAFecha = T000C13_A68PAGOFRUTAFecha[0];
               AssignAttri("", false, "A68PAGOFRUTAFecha", context.localUtil.Format(A68PAGOFRUTAFecha, "99/99/99"));
               A69PAGOFRUTAMes = T000C13_A69PAGOFRUTAMes[0];
               AssignAttri("", false, "A69PAGOFRUTAMes", StringUtil.LTrimStr( (decimal)(A69PAGOFRUTAMes), 4, 0));
               A70PAGOFRUTAAno = T000C13_A70PAGOFRUTAAno[0];
               AssignAttri("", false, "A70PAGOFRUTAAno", StringUtil.LTrimStr( (decimal)(A70PAGOFRUTAAno), 4, 0));
               A5Cod_Area = T000C13_A5Cod_Area[0];
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               A4IndicadoresCodigo = T000C13_A4IndicadoresCodigo[0];
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               A30MotivosUspCodigo = T000C13_A30MotivosUspCodigo[0];
               AssignAttri("", false, "A30MotivosUspCodigo", A30MotivosUspCodigo);
               RcdFound13 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0C13( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPAGOFRUTAFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0C13( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound13 == 1 )
            {
               if ( ( DateTimeUtil.ResetTime ( A68PAGOFRUTAFecha ) != DateTimeUtil.ResetTime ( Z68PAGOFRUTAFecha ) ) || ( A69PAGOFRUTAMes != Z69PAGOFRUTAMes ) || ( A70PAGOFRUTAAno != Z70PAGOFRUTAAno ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) || ( StringUtil.StrCmp(A30MotivosUspCodigo, Z30MotivosUspCodigo) != 0 ) )
               {
                  A68PAGOFRUTAFecha = Z68PAGOFRUTAFecha;
                  AssignAttri("", false, "A68PAGOFRUTAFecha", context.localUtil.Format(A68PAGOFRUTAFecha, "99/99/99"));
                  A69PAGOFRUTAMes = Z69PAGOFRUTAMes;
                  AssignAttri("", false, "A69PAGOFRUTAMes", StringUtil.LTrimStr( (decimal)(A69PAGOFRUTAMes), 4, 0));
                  A70PAGOFRUTAAno = Z70PAGOFRUTAAno;
                  AssignAttri("", false, "A70PAGOFRUTAAno", StringUtil.LTrimStr( (decimal)(A70PAGOFRUTAAno), 4, 0));
                  A5Cod_Area = Z5Cod_Area;
                  AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
                  A4IndicadoresCodigo = Z4IndicadoresCodigo;
                  AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
                  A30MotivosUspCodigo = Z30MotivosUspCodigo;
                  AssignAttri("", false, "A30MotivosUspCodigo", A30MotivosUspCodigo);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PAGOFRUTAFECHA");
                  AnyError = 1;
                  GX_FocusControl = edtPAGOFRUTAFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPAGOFRUTAFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0C13( ) ;
                  GX_FocusControl = edtPAGOFRUTAFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( DateTimeUtil.ResetTime ( A68PAGOFRUTAFecha ) != DateTimeUtil.ResetTime ( Z68PAGOFRUTAFecha ) ) || ( A69PAGOFRUTAMes != Z69PAGOFRUTAMes ) || ( A70PAGOFRUTAAno != Z70PAGOFRUTAAno ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) || ( StringUtil.StrCmp(A30MotivosUspCodigo, Z30MotivosUspCodigo) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtPAGOFRUTAFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0C13( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PAGOFRUTAFECHA");
                     AnyError = 1;
                     GX_FocusControl = edtPAGOFRUTAFecha_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtPAGOFRUTAFecha_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0C13( ) ;
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
         if ( ( DateTimeUtil.ResetTime ( A68PAGOFRUTAFecha ) != DateTimeUtil.ResetTime ( Z68PAGOFRUTAFecha ) ) || ( A69PAGOFRUTAMes != Z69PAGOFRUTAMes ) || ( A70PAGOFRUTAAno != Z70PAGOFRUTAAno ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) || ( StringUtil.StrCmp(A30MotivosUspCodigo, Z30MotivosUspCodigo) != 0 ) )
         {
            A68PAGOFRUTAFecha = Z68PAGOFRUTAFecha;
            AssignAttri("", false, "A68PAGOFRUTAFecha", context.localUtil.Format(A68PAGOFRUTAFecha, "99/99/99"));
            A69PAGOFRUTAMes = Z69PAGOFRUTAMes;
            AssignAttri("", false, "A69PAGOFRUTAMes", StringUtil.LTrimStr( (decimal)(A69PAGOFRUTAMes), 4, 0));
            A70PAGOFRUTAAno = Z70PAGOFRUTAAno;
            AssignAttri("", false, "A70PAGOFRUTAAno", StringUtil.LTrimStr( (decimal)(A70PAGOFRUTAAno), 4, 0));
            A5Cod_Area = Z5Cod_Area;
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = Z4IndicadoresCodigo;
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A30MotivosUspCodigo = Z30MotivosUspCodigo;
            AssignAttri("", false, "A30MotivosUspCodigo", A30MotivosUspCodigo);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PAGOFRUTAFECHA");
            AnyError = 1;
            GX_FocusControl = edtPAGOFRUTAFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPAGOFRUTAFecha_Internalname;
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
         if ( RcdFound13 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "PAGOFRUTAFECHA");
            AnyError = 1;
            GX_FocusControl = edtPAGOFRUTAFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtPAGOFRUTAValor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0C13( ) ;
         if ( RcdFound13 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPAGOFRUTAValor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0C13( ) ;
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
         if ( RcdFound13 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPAGOFRUTAValor_Internalname;
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
         if ( RcdFound13 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPAGOFRUTAValor_Internalname;
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
         ScanStart0C13( ) ;
         if ( RcdFound13 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound13 != 0 )
            {
               ScanNext0C13( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPAGOFRUTAValor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0C13( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0C13( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000C2 */
            pr_default.execute(0, new Object[] {A68PAGOFRUTAFecha, A69PAGOFRUTAMes, A70PAGOFRUTAAno, A5Cod_Area, A4IndicadoresCodigo, A30MotivosUspCodigo});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PAGOFRUTA"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z136PAGOFRUTAValor != T000C2_A136PAGOFRUTAValor[0] ) )
            {
               if ( Z136PAGOFRUTAValor != T000C2_A136PAGOFRUTAValor[0] )
               {
                  GXUtil.WriteLog("pagofruta:[seudo value changed for attri]"+"PAGOFRUTAValor");
                  GXUtil.WriteLogRaw("Old: ",Z136PAGOFRUTAValor);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A136PAGOFRUTAValor[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"PAGOFRUTA"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0C13( )
      {
         BeforeValidate0C13( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C13( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0C13( 0) ;
            CheckOptimisticConcurrency0C13( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C13( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0C13( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000C14 */
                     pr_default.execute(12, new Object[] {A68PAGOFRUTAFecha, A69PAGOFRUTAMes, A70PAGOFRUTAAno, A136PAGOFRUTAValor, A5Cod_Area, A4IndicadoresCodigo, A30MotivosUspCodigo});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("PAGOFRUTA");
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
                           ResetCaption0C0( ) ;
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
               Load0C13( ) ;
            }
            EndLevel0C13( ) ;
         }
         CloseExtendedTableCursors0C13( ) ;
      }

      protected void Update0C13( )
      {
         BeforeValidate0C13( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C13( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C13( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C13( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0C13( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000C15 */
                     pr_default.execute(13, new Object[] {A136PAGOFRUTAValor, A68PAGOFRUTAFecha, A69PAGOFRUTAMes, A70PAGOFRUTAAno, A5Cod_Area, A4IndicadoresCodigo, A30MotivosUspCodigo});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("PAGOFRUTA");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PAGOFRUTA"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0C13( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0C0( ) ;
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
            EndLevel0C13( ) ;
         }
         CloseExtendedTableCursors0C13( ) ;
      }

      protected void DeferredUpdate0C13( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0C13( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C13( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0C13( ) ;
            AfterConfirm0C13( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0C13( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000C16 */
                  pr_default.execute(14, new Object[] {A68PAGOFRUTAFecha, A69PAGOFRUTAMes, A70PAGOFRUTAAno, A5Cod_Area, A4IndicadoresCodigo, A30MotivosUspCodigo});
                  pr_default.close(14);
                  pr_default.SmartCacheProvider.SetUpdated("PAGOFRUTA");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound13 == 0 )
                        {
                           InitAll0C13( ) ;
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
                        ResetCaption0C0( ) ;
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
         sMode13 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0C13( ) ;
         Gx_mode = sMode13;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0C13( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0C13( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0C13( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("pagofruta",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0C0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("pagofruta",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0C13( )
      {
         /* Using cursor T000C17 */
         pr_default.execute(15);
         RcdFound13 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound13 = 1;
            A68PAGOFRUTAFecha = T000C17_A68PAGOFRUTAFecha[0];
            AssignAttri("", false, "A68PAGOFRUTAFecha", context.localUtil.Format(A68PAGOFRUTAFecha, "99/99/99"));
            A69PAGOFRUTAMes = T000C17_A69PAGOFRUTAMes[0];
            AssignAttri("", false, "A69PAGOFRUTAMes", StringUtil.LTrimStr( (decimal)(A69PAGOFRUTAMes), 4, 0));
            A70PAGOFRUTAAno = T000C17_A70PAGOFRUTAAno[0];
            AssignAttri("", false, "A70PAGOFRUTAAno", StringUtil.LTrimStr( (decimal)(A70PAGOFRUTAAno), 4, 0));
            A5Cod_Area = T000C17_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = T000C17_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A30MotivosUspCodigo = T000C17_A30MotivosUspCodigo[0];
            AssignAttri("", false, "A30MotivosUspCodigo", A30MotivosUspCodigo);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0C13( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound13 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound13 = 1;
            A68PAGOFRUTAFecha = T000C17_A68PAGOFRUTAFecha[0];
            AssignAttri("", false, "A68PAGOFRUTAFecha", context.localUtil.Format(A68PAGOFRUTAFecha, "99/99/99"));
            A69PAGOFRUTAMes = T000C17_A69PAGOFRUTAMes[0];
            AssignAttri("", false, "A69PAGOFRUTAMes", StringUtil.LTrimStr( (decimal)(A69PAGOFRUTAMes), 4, 0));
            A70PAGOFRUTAAno = T000C17_A70PAGOFRUTAAno[0];
            AssignAttri("", false, "A70PAGOFRUTAAno", StringUtil.LTrimStr( (decimal)(A70PAGOFRUTAAno), 4, 0));
            A5Cod_Area = T000C17_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = T000C17_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A30MotivosUspCodigo = T000C17_A30MotivosUspCodigo[0];
            AssignAttri("", false, "A30MotivosUspCodigo", A30MotivosUspCodigo);
         }
      }

      protected void ScanEnd0C13( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm0C13( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0C13( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0C13( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0C13( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0C13( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0C13( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0C13( )
      {
         edtPAGOFRUTAFecha_Enabled = 0;
         AssignProp("", false, edtPAGOFRUTAFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPAGOFRUTAFecha_Enabled), 5, 0), true);
         edtPAGOFRUTAMes_Enabled = 0;
         AssignProp("", false, edtPAGOFRUTAMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPAGOFRUTAMes_Enabled), 5, 0), true);
         edtPAGOFRUTAAno_Enabled = 0;
         AssignProp("", false, edtPAGOFRUTAAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPAGOFRUTAAno_Enabled), 5, 0), true);
         edtCod_Area_Enabled = 0;
         AssignProp("", false, edtCod_Area_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCod_Area_Enabled), 5, 0), true);
         edtIndicadoresCodigo_Enabled = 0;
         AssignProp("", false, edtIndicadoresCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIndicadoresCodigo_Enabled), 5, 0), true);
         edtMotivosUspCodigo_Enabled = 0;
         AssignProp("", false, edtMotivosUspCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMotivosUspCodigo_Enabled), 5, 0), true);
         edtPAGOFRUTAValor_Enabled = 0;
         AssignProp("", false, edtPAGOFRUTAValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPAGOFRUTAValor_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0C13( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0C0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("pagofruta.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z68PAGOFRUTAFecha", context.localUtil.DToC( Z68PAGOFRUTAFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z69PAGOFRUTAMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z69PAGOFRUTAMes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z70PAGOFRUTAAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z70PAGOFRUTAAno), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z5Cod_Area", Z5Cod_Area);
         GxWebStd.gx_hidden_field( context, "Z4IndicadoresCodigo", Z4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "Z30MotivosUspCodigo", Z30MotivosUspCodigo);
         GxWebStd.gx_hidden_field( context, "Z136PAGOFRUTAValor", StringUtil.LTrim( StringUtil.NToC( Z136PAGOFRUTAValor, 14, 2, ",", "")));
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
         return formatLink("pagofruta.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "PAGOFRUTA" ;
      }

      public override string GetPgmdesc( )
      {
         return "PAGOFRUTA" ;
      }

      protected void InitializeNonKey0C13( )
      {
         A136PAGOFRUTAValor = 0;
         AssignAttri("", false, "A136PAGOFRUTAValor", StringUtil.LTrimStr( A136PAGOFRUTAValor, 14, 2));
         Z136PAGOFRUTAValor = 0;
      }

      protected void InitAll0C13( )
      {
         A68PAGOFRUTAFecha = DateTime.MinValue;
         AssignAttri("", false, "A68PAGOFRUTAFecha", context.localUtil.Format(A68PAGOFRUTAFecha, "99/99/99"));
         A69PAGOFRUTAMes = 0;
         AssignAttri("", false, "A69PAGOFRUTAMes", StringUtil.LTrimStr( (decimal)(A69PAGOFRUTAMes), 4, 0));
         A70PAGOFRUTAAno = 0;
         AssignAttri("", false, "A70PAGOFRUTAAno", StringUtil.LTrimStr( (decimal)(A70PAGOFRUTAAno), 4, 0));
         A5Cod_Area = "";
         AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
         A4IndicadoresCodigo = "";
         AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
         A30MotivosUspCodigo = "";
         AssignAttri("", false, "A30MotivosUspCodigo", A30MotivosUspCodigo);
         InitializeNonKey0C13( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20247231021148", true, true);
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
         context.AddJavascriptSource("pagofruta.js", "?20247231021148", false, true);
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
         edtPAGOFRUTAFecha_Internalname = "PAGOFRUTAFECHA";
         edtPAGOFRUTAMes_Internalname = "PAGOFRUTAMES";
         edtPAGOFRUTAAno_Internalname = "PAGOFRUTAANO";
         edtCod_Area_Internalname = "COD_AREA";
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO";
         edtMotivosUspCodigo_Internalname = "MOTIVOSUSPCODIGO";
         edtPAGOFRUTAValor_Internalname = "PAGOFRUTAVALOR";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_5_Internalname = "PROMPT_5";
         imgprompt_4_Internalname = "PROMPT_4";
         imgprompt_30_Internalname = "PROMPT_30";
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
         Form.Caption = "PAGOFRUTA";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtPAGOFRUTAValor_Jsonclick = "";
         edtPAGOFRUTAValor_Enabled = 1;
         imgprompt_30_Visible = 1;
         imgprompt_30_Link = "";
         edtMotivosUspCodigo_Jsonclick = "";
         edtMotivosUspCodigo_Enabled = 1;
         imgprompt_4_Visible = 1;
         imgprompt_4_Link = "";
         edtIndicadoresCodigo_Jsonclick = "";
         edtIndicadoresCodigo_Enabled = 1;
         imgprompt_5_Visible = 1;
         imgprompt_5_Link = "";
         edtCod_Area_Jsonclick = "";
         edtCod_Area_Enabled = 1;
         edtPAGOFRUTAAno_Jsonclick = "";
         edtPAGOFRUTAAno_Enabled = 1;
         edtPAGOFRUTAMes_Jsonclick = "";
         edtPAGOFRUTAMes_Enabled = 1;
         edtPAGOFRUTAFecha_Jsonclick = "";
         edtPAGOFRUTAFecha_Enabled = 1;
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
         /* Using cursor T000C18 */
         pr_default.execute(16, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(16);
         /* Using cursor T000C19 */
         pr_default.execute(17, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(17);
         /* Using cursor T000C20 */
         pr_default.execute(18, new Object[] {A30MotivosUspCodigo});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'Motivos Usp'.", "ForeignKeyNotFound", 1, "MOTIVOSUSPCODIGO");
            AnyError = 1;
            GX_FocusControl = edtMotivosUspCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(18);
         GX_FocusControl = edtPAGOFRUTAValor_Internalname;
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
         /* Using cursor T000C18 */
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
         /* Using cursor T000C19 */
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

      public void Valid_Motivosuspcodigo( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T000C20 */
         pr_default.execute(18, new Object[] {A30MotivosUspCodigo});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'Motivos Usp'.", "ForeignKeyNotFound", 1, "MOTIVOSUSPCODIGO");
            AnyError = 1;
            GX_FocusControl = edtMotivosUspCodigo_Internalname;
         }
         pr_default.close(18);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A136PAGOFRUTAValor", StringUtil.LTrim( StringUtil.NToC( A136PAGOFRUTAValor, 14, 2, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z68PAGOFRUTAFecha", context.localUtil.Format(Z68PAGOFRUTAFecha, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z69PAGOFRUTAMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z69PAGOFRUTAMes), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z70PAGOFRUTAAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z70PAGOFRUTAAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z5Cod_Area", Z5Cod_Area);
         GxWebStd.gx_hidden_field( context, "Z4IndicadoresCodigo", Z4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "Z30MotivosUspCodigo", Z30MotivosUspCodigo);
         GxWebStd.gx_hidden_field( context, "Z136PAGOFRUTAValor", StringUtil.LTrim( StringUtil.NToC( Z136PAGOFRUTAValor, 14, 2, ".", "")));
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
         setEventMetadata("VALID_PAGOFRUTAFECHA","{handler:'Valid_Pagofrutafecha',iparms:[]");
         setEventMetadata("VALID_PAGOFRUTAFECHA",",oparms:[]}");
         setEventMetadata("VALID_PAGOFRUTAMES","{handler:'Valid_Pagofrutames',iparms:[]");
         setEventMetadata("VALID_PAGOFRUTAMES",",oparms:[]}");
         setEventMetadata("VALID_PAGOFRUTAANO","{handler:'Valid_Pagofrutaano',iparms:[]");
         setEventMetadata("VALID_PAGOFRUTAANO",",oparms:[]}");
         setEventMetadata("VALID_COD_AREA","{handler:'Valid_Cod_area',iparms:[{av:'A5Cod_Area',fld:'COD_AREA',pic:''}]");
         setEventMetadata("VALID_COD_AREA",",oparms:[]}");
         setEventMetadata("VALID_INDICADORESCODIGO","{handler:'Valid_Indicadorescodigo',iparms:[{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:''}]");
         setEventMetadata("VALID_INDICADORESCODIGO",",oparms:[]}");
         setEventMetadata("VALID_MOTIVOSUSPCODIGO","{handler:'Valid_Motivosuspcodigo',iparms:[{av:'A68PAGOFRUTAFecha',fld:'PAGOFRUTAFECHA',pic:''},{av:'A69PAGOFRUTAMes',fld:'PAGOFRUTAMES',pic:'ZZZ9'},{av:'A70PAGOFRUTAAno',fld:'PAGOFRUTAANO',pic:'ZZZ9'},{av:'A5Cod_Area',fld:'COD_AREA',pic:''},{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:''},{av:'A30MotivosUspCodigo',fld:'MOTIVOSUSPCODIGO',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_MOTIVOSUSPCODIGO",",oparms:[{av:'A136PAGOFRUTAValor',fld:'PAGOFRUTAVALOR',pic:'ZZZZZZZZZZ9.99'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z68PAGOFRUTAFecha'},{av:'Z69PAGOFRUTAMes'},{av:'Z70PAGOFRUTAAno'},{av:'Z5Cod_Area'},{av:'Z4IndicadoresCodigo'},{av:'Z30MotivosUspCodigo'},{av:'Z136PAGOFRUTAValor'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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
         Z68PAGOFRUTAFecha = DateTime.MinValue;
         Z5Cod_Area = "";
         Z4IndicadoresCodigo = "";
         Z30MotivosUspCodigo = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A5Cod_Area = "";
         A4IndicadoresCodigo = "";
         A30MotivosUspCodigo = "";
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
         A68PAGOFRUTAFecha = DateTime.MinValue;
         imgprompt_5_gximage = "";
         sImgUrl = "";
         imgprompt_4_gximage = "";
         imgprompt_30_gximage = "";
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
         T000C7_A68PAGOFRUTAFecha = new DateTime[] {DateTime.MinValue} ;
         T000C7_A69PAGOFRUTAMes = new short[1] ;
         T000C7_A70PAGOFRUTAAno = new short[1] ;
         T000C7_A136PAGOFRUTAValor = new decimal[1] ;
         T000C7_A5Cod_Area = new string[] {""} ;
         T000C7_A4IndicadoresCodigo = new string[] {""} ;
         T000C7_A30MotivosUspCodigo = new string[] {""} ;
         T000C4_A5Cod_Area = new string[] {""} ;
         T000C5_A4IndicadoresCodigo = new string[] {""} ;
         T000C6_A30MotivosUspCodigo = new string[] {""} ;
         T000C8_A5Cod_Area = new string[] {""} ;
         T000C9_A4IndicadoresCodigo = new string[] {""} ;
         T000C10_A30MotivosUspCodigo = new string[] {""} ;
         T000C11_A68PAGOFRUTAFecha = new DateTime[] {DateTime.MinValue} ;
         T000C11_A69PAGOFRUTAMes = new short[1] ;
         T000C11_A70PAGOFRUTAAno = new short[1] ;
         T000C11_A5Cod_Area = new string[] {""} ;
         T000C11_A4IndicadoresCodigo = new string[] {""} ;
         T000C11_A30MotivosUspCodigo = new string[] {""} ;
         T000C3_A68PAGOFRUTAFecha = new DateTime[] {DateTime.MinValue} ;
         T000C3_A69PAGOFRUTAMes = new short[1] ;
         T000C3_A70PAGOFRUTAAno = new short[1] ;
         T000C3_A136PAGOFRUTAValor = new decimal[1] ;
         T000C3_A5Cod_Area = new string[] {""} ;
         T000C3_A4IndicadoresCodigo = new string[] {""} ;
         T000C3_A30MotivosUspCodigo = new string[] {""} ;
         sMode13 = "";
         T000C12_A68PAGOFRUTAFecha = new DateTime[] {DateTime.MinValue} ;
         T000C12_A69PAGOFRUTAMes = new short[1] ;
         T000C12_A70PAGOFRUTAAno = new short[1] ;
         T000C12_A5Cod_Area = new string[] {""} ;
         T000C12_A4IndicadoresCodigo = new string[] {""} ;
         T000C12_A30MotivosUspCodigo = new string[] {""} ;
         T000C13_A68PAGOFRUTAFecha = new DateTime[] {DateTime.MinValue} ;
         T000C13_A69PAGOFRUTAMes = new short[1] ;
         T000C13_A70PAGOFRUTAAno = new short[1] ;
         T000C13_A5Cod_Area = new string[] {""} ;
         T000C13_A4IndicadoresCodigo = new string[] {""} ;
         T000C13_A30MotivosUspCodigo = new string[] {""} ;
         T000C2_A68PAGOFRUTAFecha = new DateTime[] {DateTime.MinValue} ;
         T000C2_A69PAGOFRUTAMes = new short[1] ;
         T000C2_A70PAGOFRUTAAno = new short[1] ;
         T000C2_A136PAGOFRUTAValor = new decimal[1] ;
         T000C2_A5Cod_Area = new string[] {""} ;
         T000C2_A4IndicadoresCodigo = new string[] {""} ;
         T000C2_A30MotivosUspCodigo = new string[] {""} ;
         T000C17_A68PAGOFRUTAFecha = new DateTime[] {DateTime.MinValue} ;
         T000C17_A69PAGOFRUTAMes = new short[1] ;
         T000C17_A70PAGOFRUTAAno = new short[1] ;
         T000C17_A5Cod_Area = new string[] {""} ;
         T000C17_A4IndicadoresCodigo = new string[] {""} ;
         T000C17_A30MotivosUspCodigo = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T000C18_A5Cod_Area = new string[] {""} ;
         T000C19_A4IndicadoresCodigo = new string[] {""} ;
         T000C20_A30MotivosUspCodigo = new string[] {""} ;
         ZZ68PAGOFRUTAFecha = DateTime.MinValue;
         ZZ5Cod_Area = "";
         ZZ4IndicadoresCodigo = "";
         ZZ30MotivosUspCodigo = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pagofruta__default(),
            new Object[][] {
                new Object[] {
               T000C2_A68PAGOFRUTAFecha, T000C2_A69PAGOFRUTAMes, T000C2_A70PAGOFRUTAAno, T000C2_A136PAGOFRUTAValor, T000C2_A5Cod_Area, T000C2_A4IndicadoresCodigo, T000C2_A30MotivosUspCodigo
               }
               , new Object[] {
               T000C3_A68PAGOFRUTAFecha, T000C3_A69PAGOFRUTAMes, T000C3_A70PAGOFRUTAAno, T000C3_A136PAGOFRUTAValor, T000C3_A5Cod_Area, T000C3_A4IndicadoresCodigo, T000C3_A30MotivosUspCodigo
               }
               , new Object[] {
               T000C4_A5Cod_Area
               }
               , new Object[] {
               T000C5_A4IndicadoresCodigo
               }
               , new Object[] {
               T000C6_A30MotivosUspCodigo
               }
               , new Object[] {
               T000C7_A68PAGOFRUTAFecha, T000C7_A69PAGOFRUTAMes, T000C7_A70PAGOFRUTAAno, T000C7_A136PAGOFRUTAValor, T000C7_A5Cod_Area, T000C7_A4IndicadoresCodigo, T000C7_A30MotivosUspCodigo
               }
               , new Object[] {
               T000C8_A5Cod_Area
               }
               , new Object[] {
               T000C9_A4IndicadoresCodigo
               }
               , new Object[] {
               T000C10_A30MotivosUspCodigo
               }
               , new Object[] {
               T000C11_A68PAGOFRUTAFecha, T000C11_A69PAGOFRUTAMes, T000C11_A70PAGOFRUTAAno, T000C11_A5Cod_Area, T000C11_A4IndicadoresCodigo, T000C11_A30MotivosUspCodigo
               }
               , new Object[] {
               T000C12_A68PAGOFRUTAFecha, T000C12_A69PAGOFRUTAMes, T000C12_A70PAGOFRUTAAno, T000C12_A5Cod_Area, T000C12_A4IndicadoresCodigo, T000C12_A30MotivosUspCodigo
               }
               , new Object[] {
               T000C13_A68PAGOFRUTAFecha, T000C13_A69PAGOFRUTAMes, T000C13_A70PAGOFRUTAAno, T000C13_A5Cod_Area, T000C13_A4IndicadoresCodigo, T000C13_A30MotivosUspCodigo
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000C17_A68PAGOFRUTAFecha, T000C17_A69PAGOFRUTAMes, T000C17_A70PAGOFRUTAAno, T000C17_A5Cod_Area, T000C17_A4IndicadoresCodigo, T000C17_A30MotivosUspCodigo
               }
               , new Object[] {
               T000C18_A5Cod_Area
               }
               , new Object[] {
               T000C19_A4IndicadoresCodigo
               }
               , new Object[] {
               T000C20_A30MotivosUspCodigo
               }
            }
         );
      }

      private short Z69PAGOFRUTAMes ;
      private short Z70PAGOFRUTAAno ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A69PAGOFRUTAMes ;
      private short A70PAGOFRUTAAno ;
      private short GX_JID ;
      private short RcdFound13 ;
      private short nIsDirty_13 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ69PAGOFRUTAMes ;
      private short ZZ70PAGOFRUTAAno ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtPAGOFRUTAFecha_Enabled ;
      private int edtPAGOFRUTAMes_Enabled ;
      private int edtPAGOFRUTAAno_Enabled ;
      private int edtCod_Area_Enabled ;
      private int imgprompt_5_Visible ;
      private int edtIndicadoresCodigo_Enabled ;
      private int imgprompt_4_Visible ;
      private int edtMotivosUspCodigo_Enabled ;
      private int imgprompt_30_Visible ;
      private int edtPAGOFRUTAValor_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private decimal Z136PAGOFRUTAValor ;
      private decimal A136PAGOFRUTAValor ;
      private decimal ZZ136PAGOFRUTAValor ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPAGOFRUTAFecha_Internalname ;
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
      private string edtPAGOFRUTAFecha_Jsonclick ;
      private string edtPAGOFRUTAMes_Internalname ;
      private string edtPAGOFRUTAMes_Jsonclick ;
      private string edtPAGOFRUTAAno_Internalname ;
      private string edtPAGOFRUTAAno_Jsonclick ;
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
      private string edtMotivosUspCodigo_Internalname ;
      private string edtMotivosUspCodigo_Jsonclick ;
      private string imgprompt_30_gximage ;
      private string imgprompt_30_Internalname ;
      private string imgprompt_30_Link ;
      private string edtPAGOFRUTAValor_Internalname ;
      private string edtPAGOFRUTAValor_Jsonclick ;
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
      private string sMode13 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z68PAGOFRUTAFecha ;
      private DateTime A68PAGOFRUTAFecha ;
      private DateTime ZZ68PAGOFRUTAFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string Z5Cod_Area ;
      private string Z4IndicadoresCodigo ;
      private string Z30MotivosUspCodigo ;
      private string A5Cod_Area ;
      private string A4IndicadoresCodigo ;
      private string A30MotivosUspCodigo ;
      private string ZZ5Cod_Area ;
      private string ZZ4IndicadoresCodigo ;
      private string ZZ30MotivosUspCodigo ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] T000C7_A68PAGOFRUTAFecha ;
      private short[] T000C7_A69PAGOFRUTAMes ;
      private short[] T000C7_A70PAGOFRUTAAno ;
      private decimal[] T000C7_A136PAGOFRUTAValor ;
      private string[] T000C7_A5Cod_Area ;
      private string[] T000C7_A4IndicadoresCodigo ;
      private string[] T000C7_A30MotivosUspCodigo ;
      private string[] T000C4_A5Cod_Area ;
      private string[] T000C5_A4IndicadoresCodigo ;
      private string[] T000C6_A30MotivosUspCodigo ;
      private string[] T000C8_A5Cod_Area ;
      private string[] T000C9_A4IndicadoresCodigo ;
      private string[] T000C10_A30MotivosUspCodigo ;
      private DateTime[] T000C11_A68PAGOFRUTAFecha ;
      private short[] T000C11_A69PAGOFRUTAMes ;
      private short[] T000C11_A70PAGOFRUTAAno ;
      private string[] T000C11_A5Cod_Area ;
      private string[] T000C11_A4IndicadoresCodigo ;
      private string[] T000C11_A30MotivosUspCodigo ;
      private DateTime[] T000C3_A68PAGOFRUTAFecha ;
      private short[] T000C3_A69PAGOFRUTAMes ;
      private short[] T000C3_A70PAGOFRUTAAno ;
      private decimal[] T000C3_A136PAGOFRUTAValor ;
      private string[] T000C3_A5Cod_Area ;
      private string[] T000C3_A4IndicadoresCodigo ;
      private string[] T000C3_A30MotivosUspCodigo ;
      private DateTime[] T000C12_A68PAGOFRUTAFecha ;
      private short[] T000C12_A69PAGOFRUTAMes ;
      private short[] T000C12_A70PAGOFRUTAAno ;
      private string[] T000C12_A5Cod_Area ;
      private string[] T000C12_A4IndicadoresCodigo ;
      private string[] T000C12_A30MotivosUspCodigo ;
      private DateTime[] T000C13_A68PAGOFRUTAFecha ;
      private short[] T000C13_A69PAGOFRUTAMes ;
      private short[] T000C13_A70PAGOFRUTAAno ;
      private string[] T000C13_A5Cod_Area ;
      private string[] T000C13_A4IndicadoresCodigo ;
      private string[] T000C13_A30MotivosUspCodigo ;
      private DateTime[] T000C2_A68PAGOFRUTAFecha ;
      private short[] T000C2_A69PAGOFRUTAMes ;
      private short[] T000C2_A70PAGOFRUTAAno ;
      private decimal[] T000C2_A136PAGOFRUTAValor ;
      private string[] T000C2_A5Cod_Area ;
      private string[] T000C2_A4IndicadoresCodigo ;
      private string[] T000C2_A30MotivosUspCodigo ;
      private DateTime[] T000C17_A68PAGOFRUTAFecha ;
      private short[] T000C17_A69PAGOFRUTAMes ;
      private short[] T000C17_A70PAGOFRUTAAno ;
      private string[] T000C17_A5Cod_Area ;
      private string[] T000C17_A4IndicadoresCodigo ;
      private string[] T000C17_A30MotivosUspCodigo ;
      private string[] T000C18_A5Cod_Area ;
      private string[] T000C19_A4IndicadoresCodigo ;
      private string[] T000C20_A30MotivosUspCodigo ;
      private GXWebForm Form ;
   }

   public class pagofruta__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT000C7;
          prmT000C7 = new Object[] {
          new ParDef("@PAGOFRUTAFecha",GXType.Date,8,0) ,
          new ParDef("@PAGOFRUTAMes",GXType.Int16,4,0) ,
          new ParDef("@PAGOFRUTAAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MotivosUspCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000C4;
          prmT000C4 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000C5;
          prmT000C5 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000C6;
          prmT000C6 = new Object[] {
          new ParDef("@MotivosUspCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000C8;
          prmT000C8 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000C9;
          prmT000C9 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000C10;
          prmT000C10 = new Object[] {
          new ParDef("@MotivosUspCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000C11;
          prmT000C11 = new Object[] {
          new ParDef("@PAGOFRUTAFecha",GXType.Date,8,0) ,
          new ParDef("@PAGOFRUTAMes",GXType.Int16,4,0) ,
          new ParDef("@PAGOFRUTAAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MotivosUspCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000C3;
          prmT000C3 = new Object[] {
          new ParDef("@PAGOFRUTAFecha",GXType.Date,8,0) ,
          new ParDef("@PAGOFRUTAMes",GXType.Int16,4,0) ,
          new ParDef("@PAGOFRUTAAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MotivosUspCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000C12;
          prmT000C12 = new Object[] {
          new ParDef("@PAGOFRUTAFecha",GXType.Date,8,0) ,
          new ParDef("@PAGOFRUTAMes",GXType.Int16,4,0) ,
          new ParDef("@PAGOFRUTAAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MotivosUspCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000C13;
          prmT000C13 = new Object[] {
          new ParDef("@PAGOFRUTAFecha",GXType.Date,8,0) ,
          new ParDef("@PAGOFRUTAMes",GXType.Int16,4,0) ,
          new ParDef("@PAGOFRUTAAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MotivosUspCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000C2;
          prmT000C2 = new Object[] {
          new ParDef("@PAGOFRUTAFecha",GXType.Date,8,0) ,
          new ParDef("@PAGOFRUTAMes",GXType.Int16,4,0) ,
          new ParDef("@PAGOFRUTAAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MotivosUspCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000C14;
          prmT000C14 = new Object[] {
          new ParDef("@PAGOFRUTAFecha",GXType.Date,8,0) ,
          new ParDef("@PAGOFRUTAMes",GXType.Int16,4,0) ,
          new ParDef("@PAGOFRUTAAno",GXType.Int16,4,0) ,
          new ParDef("@PAGOFRUTAValor",GXType.Decimal,14,2) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MotivosUspCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000C15;
          prmT000C15 = new Object[] {
          new ParDef("@PAGOFRUTAValor",GXType.Decimal,14,2) ,
          new ParDef("@PAGOFRUTAFecha",GXType.Date,8,0) ,
          new ParDef("@PAGOFRUTAMes",GXType.Int16,4,0) ,
          new ParDef("@PAGOFRUTAAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MotivosUspCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000C16;
          prmT000C16 = new Object[] {
          new ParDef("@PAGOFRUTAFecha",GXType.Date,8,0) ,
          new ParDef("@PAGOFRUTAMes",GXType.Int16,4,0) ,
          new ParDef("@PAGOFRUTAAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MotivosUspCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000C17;
          prmT000C17 = new Object[] {
          };
          Object[] prmT000C18;
          prmT000C18 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000C19;
          prmT000C19 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000C20;
          prmT000C20 = new Object[] {
          new ParDef("@MotivosUspCodigo",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("T000C2", "SELECT [PAGOFRUTAFecha], [PAGOFRUTAMes], [PAGOFRUTAAno], [PAGOFRUTAValor], [Cod_Area], [IndicadoresCodigo], [MotivosUspCodigo] FROM [PAGOFRUTA] WITH (UPDLOCK) WHERE [PAGOFRUTAFecha] = @PAGOFRUTAFecha AND [PAGOFRUTAMes] = @PAGOFRUTAMes AND [PAGOFRUTAAno] = @PAGOFRUTAAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo AND [MotivosUspCodigo] = @MotivosUspCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C3", "SELECT [PAGOFRUTAFecha], [PAGOFRUTAMes], [PAGOFRUTAAno], [PAGOFRUTAValor], [Cod_Area], [IndicadoresCodigo], [MotivosUspCodigo] FROM [PAGOFRUTA] WHERE [PAGOFRUTAFecha] = @PAGOFRUTAFecha AND [PAGOFRUTAMes] = @PAGOFRUTAMes AND [PAGOFRUTAAno] = @PAGOFRUTAAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo AND [MotivosUspCodigo] = @MotivosUspCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C4", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C5", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C6", "SELECT [MotivosUspCodigo] FROM [MotivosUsp] WHERE [MotivosUspCodigo] = @MotivosUspCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C7", "SELECT TM1.[PAGOFRUTAFecha], TM1.[PAGOFRUTAMes], TM1.[PAGOFRUTAAno], TM1.[PAGOFRUTAValor], TM1.[Cod_Area], TM1.[IndicadoresCodigo], TM1.[MotivosUspCodigo] FROM [PAGOFRUTA] TM1 WHERE TM1.[PAGOFRUTAFecha] = @PAGOFRUTAFecha and TM1.[PAGOFRUTAMes] = @PAGOFRUTAMes and TM1.[PAGOFRUTAAno] = @PAGOFRUTAAno and TM1.[Cod_Area] = @Cod_Area and TM1.[IndicadoresCodigo] = @IndicadoresCodigo and TM1.[MotivosUspCodigo] = @MotivosUspCodigo ORDER BY TM1.[PAGOFRUTAFecha], TM1.[PAGOFRUTAMes], TM1.[PAGOFRUTAAno], TM1.[Cod_Area], TM1.[IndicadoresCodigo], TM1.[MotivosUspCodigo]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000C7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C8", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C9", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C10", "SELECT [MotivosUspCodigo] FROM [MotivosUsp] WHERE [MotivosUspCodigo] = @MotivosUspCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C10,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C11", "SELECT [PAGOFRUTAFecha], [PAGOFRUTAMes], [PAGOFRUTAAno], [Cod_Area], [IndicadoresCodigo], [MotivosUspCodigo] FROM [PAGOFRUTA] WHERE [PAGOFRUTAFecha] = @PAGOFRUTAFecha AND [PAGOFRUTAMes] = @PAGOFRUTAMes AND [PAGOFRUTAAno] = @PAGOFRUTAAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo AND [MotivosUspCodigo] = @MotivosUspCodigo  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000C11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C12", "SELECT TOP 1 [PAGOFRUTAFecha], [PAGOFRUTAMes], [PAGOFRUTAAno], [Cod_Area], [IndicadoresCodigo], [MotivosUspCodigo] FROM [PAGOFRUTA] WHERE ( [PAGOFRUTAFecha] > @PAGOFRUTAFecha or [PAGOFRUTAFecha] = @PAGOFRUTAFecha and [PAGOFRUTAMes] > @PAGOFRUTAMes or [PAGOFRUTAMes] = @PAGOFRUTAMes and [PAGOFRUTAFecha] = @PAGOFRUTAFecha and [PAGOFRUTAAno] > @PAGOFRUTAAno or [PAGOFRUTAAno] = @PAGOFRUTAAno and [PAGOFRUTAMes] = @PAGOFRUTAMes and [PAGOFRUTAFecha] = @PAGOFRUTAFecha and [Cod_Area] > @Cod_Area or [Cod_Area] = @Cod_Area and [PAGOFRUTAAno] = @PAGOFRUTAAno and [PAGOFRUTAMes] = @PAGOFRUTAMes and [PAGOFRUTAFecha] = @PAGOFRUTAFecha and [IndicadoresCodigo] > @IndicadoresCodigo or [IndicadoresCodigo] = @IndicadoresCodigo and [Cod_Area] = @Cod_Area and [PAGOFRUTAAno] = @PAGOFRUTAAno and [PAGOFRUTAMes] = @PAGOFRUTAMes and [PAGOFRUTAFecha] = @PAGOFRUTAFecha and [MotivosUspCodigo] > @MotivosUspCodigo) ORDER BY [PAGOFRUTAFecha], [PAGOFRUTAMes], [PAGOFRUTAAno], [Cod_Area], [IndicadoresCodigo], [MotivosUspCodigo]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000C12,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000C13", "SELECT TOP 1 [PAGOFRUTAFecha], [PAGOFRUTAMes], [PAGOFRUTAAno], [Cod_Area], [IndicadoresCodigo], [MotivosUspCodigo] FROM [PAGOFRUTA] WHERE ( [PAGOFRUTAFecha] < @PAGOFRUTAFecha or [PAGOFRUTAFecha] = @PAGOFRUTAFecha and [PAGOFRUTAMes] < @PAGOFRUTAMes or [PAGOFRUTAMes] = @PAGOFRUTAMes and [PAGOFRUTAFecha] = @PAGOFRUTAFecha and [PAGOFRUTAAno] < @PAGOFRUTAAno or [PAGOFRUTAAno] = @PAGOFRUTAAno and [PAGOFRUTAMes] = @PAGOFRUTAMes and [PAGOFRUTAFecha] = @PAGOFRUTAFecha and [Cod_Area] < @Cod_Area or [Cod_Area] = @Cod_Area and [PAGOFRUTAAno] = @PAGOFRUTAAno and [PAGOFRUTAMes] = @PAGOFRUTAMes and [PAGOFRUTAFecha] = @PAGOFRUTAFecha and [IndicadoresCodigo] < @IndicadoresCodigo or [IndicadoresCodigo] = @IndicadoresCodigo and [Cod_Area] = @Cod_Area and [PAGOFRUTAAno] = @PAGOFRUTAAno and [PAGOFRUTAMes] = @PAGOFRUTAMes and [PAGOFRUTAFecha] = @PAGOFRUTAFecha and [MotivosUspCodigo] < @MotivosUspCodigo) ORDER BY [PAGOFRUTAFecha] DESC, [PAGOFRUTAMes] DESC, [PAGOFRUTAAno] DESC, [Cod_Area] DESC, [IndicadoresCodigo] DESC, [MotivosUspCodigo] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000C13,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000C14", "INSERT INTO [PAGOFRUTA]([PAGOFRUTAFecha], [PAGOFRUTAMes], [PAGOFRUTAAno], [PAGOFRUTAValor], [Cod_Area], [IndicadoresCodigo], [MotivosUspCodigo]) VALUES(@PAGOFRUTAFecha, @PAGOFRUTAMes, @PAGOFRUTAAno, @PAGOFRUTAValor, @Cod_Area, @IndicadoresCodigo, @MotivosUspCodigo)", GxErrorMask.GX_NOMASK,prmT000C14)
             ,new CursorDef("T000C15", "UPDATE [PAGOFRUTA] SET [PAGOFRUTAValor]=@PAGOFRUTAValor  WHERE [PAGOFRUTAFecha] = @PAGOFRUTAFecha AND [PAGOFRUTAMes] = @PAGOFRUTAMes AND [PAGOFRUTAAno] = @PAGOFRUTAAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo AND [MotivosUspCodigo] = @MotivosUspCodigo", GxErrorMask.GX_NOMASK,prmT000C15)
             ,new CursorDef("T000C16", "DELETE FROM [PAGOFRUTA]  WHERE [PAGOFRUTAFecha] = @PAGOFRUTAFecha AND [PAGOFRUTAMes] = @PAGOFRUTAMes AND [PAGOFRUTAAno] = @PAGOFRUTAAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo AND [MotivosUspCodigo] = @MotivosUspCodigo", GxErrorMask.GX_NOMASK,prmT000C16)
             ,new CursorDef("T000C17", "SELECT [PAGOFRUTAFecha], [PAGOFRUTAMes], [PAGOFRUTAAno], [Cod_Area], [IndicadoresCodigo], [MotivosUspCodigo] FROM [PAGOFRUTA] ORDER BY [PAGOFRUTAFecha], [PAGOFRUTAMes], [PAGOFRUTAAno], [Cod_Area], [IndicadoresCodigo], [MotivosUspCodigo]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000C17,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C18", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C18,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C19", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C19,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C20", "SELECT [MotivosUspCodigo] FROM [MotivosUsp] WHERE [MotivosUspCodigo] = @MotivosUspCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C20,1, GxCacheFrequency.OFF ,true,false )
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
