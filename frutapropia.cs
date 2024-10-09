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
   public class frutapropia : GXDataArea
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
            Form.Meta.addItem("description", "FRUTAPROPIA", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtFRUTAPROPIAFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("IndicadroresPalmas", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public frutapropia( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("IndicadroresPalmas", true);
      }

      public frutapropia( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "FRUTAPROPIA", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_FRUTAPROPIA.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_FRUTAPROPIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_FRUTAPROPIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_FRUTAPROPIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_FRUTAPROPIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 4, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx00r0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"FRUTAPROPIAFECHA"+"'), id:'"+"FRUTAPROPIAFECHA"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"FRUTAPROPIAMES"+"'), id:'"+"FRUTAPROPIAMES"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"FRUTAPROPIAANO"+"'), id:'"+"FRUTAPROPIAANO"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"INDICADORESCODIGO"+"'), id:'"+"INDICADORESCODIGO"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"COD_AREA"+"'), id:'"+"COD_AREA"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"VIAJE"+"'), id:'"+"VIAJE"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"SETOR"+"'), id:'"+"SETOR"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"FINCA"+"'), id:'"+"FINCA"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"PROVE_COD"+"'), id:'"+"PROVE_COD"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"DIA"+"'), id:'"+"DIA"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"LOTE"+"'), id:'"+"LOTE"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"TAL"+"'), id:'"+"TAL"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_FRUTAPROPIA.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFRUTAPROPIAFecha_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFRUTAPROPIAFecha_Internalname, "FRUTAPROPIAFecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtFRUTAPROPIAFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtFRUTAPROPIAFecha_Internalname, context.localUtil.Format(A94FRUTAPROPIAFecha, "99/99/99"), context.localUtil.Format( A94FRUTAPROPIAFecha, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFRUTAPROPIAFecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFRUTAPROPIAFecha_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_FRUTAPROPIA.htm");
         GxWebStd.gx_bitmap( context, edtFRUTAPROPIAFecha_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtFRUTAPROPIAFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_FRUTAPROPIA.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFRUTAPROPIAMes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFRUTAPROPIAMes_Internalname, "FRUTAPROPIAMes", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFRUTAPROPIAMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A95FRUTAPROPIAMes), 4, 0, ",", "")), StringUtil.LTrim( ((edtFRUTAPROPIAMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A95FRUTAPROPIAMes), "ZZZ9") : context.localUtil.Format( (decimal)(A95FRUTAPROPIAMes), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFRUTAPROPIAMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFRUTAPROPIAMes_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_FRUTAPROPIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFRUTAPROPIAAno_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFRUTAPROPIAAno_Internalname, "FRUTAPROPIAAno", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFRUTAPROPIAAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A96FRUTAPROPIAAno), 4, 0, ",", "")), StringUtil.LTrim( ((edtFRUTAPROPIAAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A96FRUTAPROPIAAno), "ZZZ9") : context.localUtil.Format( (decimal)(A96FRUTAPROPIAAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFRUTAPROPIAAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFRUTAPROPIAAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_FRUTAPROPIA.htm");
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
         GxWebStd.gx_single_line_edit( context, edtIndicadoresCodigo_Internalname, A4IndicadoresCodigo, StringUtil.RTrim( context.localUtil.Format( A4IndicadoresCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIndicadoresCodigo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIndicadoresCodigo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_FRUTAPROPIA.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_4_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_4_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_4_Internalname, sImgUrl, imgprompt_4_Link, "", "", context.GetTheme( ), imgprompt_4_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_FRUTAPROPIA.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCod_Area_Internalname, A5Cod_Area, StringUtil.RTrim( context.localUtil.Format( A5Cod_Area, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCod_Area_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCod_Area_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_FRUTAPROPIA.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_5_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_5_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_5_Internalname, sImgUrl, imgprompt_5_Link, "", "", context.GetTheme( ), imgprompt_5_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_FRUTAPROPIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtVIAJE_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVIAJE_Internalname, "VIAJE", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVIAJE_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A97VIAJE), 12, 0, ",", "")), StringUtil.LTrim( ((edtVIAJE_Enabled!=0) ? context.localUtil.Format( (decimal)(A97VIAJE), "ZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A97VIAJE), "ZZZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVIAJE_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVIAJE_Enabled, 0, "text", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_FRUTAPROPIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSETOR_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSETOR_Internalname, "SETOR", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSETOR_Internalname, A98SETOR, StringUtil.RTrim( context.localUtil.Format( A98SETOR, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSETOR_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSETOR_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_FRUTAPROPIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFINCA_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFINCA_Internalname, "FINCA", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFINCA_Internalname, A99FINCA, StringUtil.RTrim( context.localUtil.Format( A99FINCA, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFINCA_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFINCA_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_FRUTAPROPIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFINCA_nom_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFINCA_nom_Internalname, "FINCA_nom", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFINCA_nom_Internalname, A267FINCA_nom, StringUtil.RTrim( context.localUtil.Format( A267FINCA_nom, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFINCA_nom_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFINCA_nom_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_FRUTAPROPIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPROVE_COD_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPROVE_COD_Internalname, "PROVE_COD", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPROVE_COD_Internalname, A100PROVE_COD, StringUtil.RTrim( context.localUtil.Format( A100PROVE_COD, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPROVE_COD_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPROVE_COD_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_FRUTAPROPIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPROVE_NOM_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPROVE_NOM_Internalname, "PROVE_NOM", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPROVE_NOM_Internalname, A268PROVE_NOM, StringUtil.RTrim( context.localUtil.Format( A268PROVE_NOM, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPROVE_NOM_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPROVE_NOM_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_FRUTAPROPIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDIA_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDIA_Internalname, "DIA", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtDIA_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtDIA_Internalname, context.localUtil.TToC( A101DIA, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A101DIA, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDIA_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDIA_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_FRUTAPROPIA.htm");
         GxWebStd.gx_bitmap( context, edtDIA_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtDIA_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_FRUTAPROPIA.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCHOFER_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCHOFER_Internalname, "CHOFER", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCHOFER_Internalname, A269CHOFER, StringUtil.RTrim( context.localUtil.Format( A269CHOFER, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,94);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCHOFER_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCHOFER_Enabled, 0, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_FRUTAPROPIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCABEZAL_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCABEZAL_Internalname, "CABEZAL", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCABEZAL_Internalname, A270CABEZAL, StringUtil.RTrim( context.localUtil.Format( A270CABEZAL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCABEZAL_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCABEZAL_Enabled, 0, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_FRUTAPROPIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFH_ENT_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFH_ENT_Internalname, "FH_ENT", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtFH_ENT_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtFH_ENT_Internalname, context.localUtil.Format(A271FH_ENT, "99/99/99"), context.localUtil.Format( A271FH_ENT, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,104);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFH_ENT_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFH_ENT_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_FRUTAPROPIA.htm");
         GxWebStd.gx_bitmap( context, edtFH_ENT_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtFH_ENT_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_FRUTAPROPIA.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFH_SAI_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFH_SAI_Internalname, "FH_SAI", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtFH_SAI_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtFH_SAI_Internalname, context.localUtil.Format(A272FH_SAI, "99/99/99"), context.localUtil.Format( A272FH_SAI, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,109);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFH_SAI_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFH_SAI_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_FRUTAPROPIA.htm");
         GxWebStd.gx_bitmap( context, edtFH_SAI_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtFH_SAI_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_FRUTAPROPIA.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPESO_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPESO_Internalname, "PESO", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPESO_Internalname, StringUtil.LTrim( StringUtil.NToC( A273PESO, 12, 2, ",", "")), StringUtil.LTrim( ((edtPESO_Enabled!=0) ? context.localUtil.Format( A273PESO, "ZZZZZZZZ9.99") : context.localUtil.Format( A273PESO, "ZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,114);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPESO_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPESO_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_FRUTAPROPIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPESO_NETO_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPESO_NETO_Internalname, "PESO_NETO", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 119,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPESO_NETO_Internalname, StringUtil.LTrim( StringUtil.NToC( A274PESO_NETO, 12, 2, ",", "")), StringUtil.LTrim( ((edtPESO_NETO_Enabled!=0) ? context.localUtil.Format( A274PESO_NETO, "ZZZZZZZZ9.99") : context.localUtil.Format( A274PESO_NETO, "ZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,119);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPESO_NETO_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPESO_NETO_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_FRUTAPROPIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTARA_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTARA_Internalname, "TARA", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 124,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTARA_Internalname, StringUtil.LTrim( StringUtil.NToC( A275TARA, 12, 2, ",", "")), StringUtil.LTrim( ((edtTARA_Enabled!=0) ? context.localUtil.Format( A275TARA, "ZZZZZZZZ9.99") : context.localUtil.Format( A275TARA, "ZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,124);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTARA_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTARA_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_FRUTAPROPIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtBRUTO_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtBRUTO_Internalname, "BRUTO", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 129,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtBRUTO_Internalname, StringUtil.LTrim( StringUtil.NToC( A276BRUTO, 12, 2, ",", "")), StringUtil.LTrim( ((edtBRUTO_Enabled!=0) ? context.localUtil.Format( A276BRUTO, "ZZZZZZZZ9.99") : context.localUtil.Format( A276BRUTO, "ZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,129);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBRUTO_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtBRUTO_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_FRUTAPROPIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFORN_ASOCIADO_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFORN_ASOCIADO_Internalname, "FORN_ASOCIADO", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 134,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFORN_ASOCIADO_Internalname, A277FORN_ASOCIADO, StringUtil.RTrim( context.localUtil.Format( A277FORN_ASOCIADO, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,134);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFORN_ASOCIADO_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFORN_ASOCIADO_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_FRUTAPROPIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtNOM_ASOCIADO_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNOM_ASOCIADO_Internalname, "NOM_ASOCIADO", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 139,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtNOM_ASOCIADO_Internalname, A278NOM_ASOCIADO, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,139);\"", 0, 1, edtNOM_ASOCIADO_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_FRUTAPROPIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCOd_PROPIETARIO_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCOd_PROPIETARIO_Internalname, "COd_PROPIETARIO", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 144,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtCOd_PROPIETARIO_Internalname, A279COd_PROPIETARIO, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,144);\"", 0, 1, edtCOd_PROPIETARIO_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_FRUTAPROPIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtNOM_PROPIETARIO_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNOM_PROPIETARIO_Internalname, "NOM_PROPIETARIO", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 149,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtNOM_PROPIETARIO_Internalname, A280NOM_PROPIETARIO, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,149);\"", 0, 1, edtNOM_PROPIETARIO_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_FRUTAPROPIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTIPO_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTIPO_Internalname, "TIPO", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 154,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTIPO_Internalname, StringUtil.LTrim( StringUtil.NToC( A281TIPO, 4, 2, ",", "")), StringUtil.LTrim( ((edtTIPO_Enabled!=0) ? context.localUtil.Format( A281TIPO, "9.99") : context.localUtil.Format( A281TIPO, "9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,154);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTIPO_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTIPO_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_FRUTAPROPIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAGRUPACION_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAGRUPACION_Internalname, "AGRUPACION", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 159,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAGRUPACION_Internalname, A282AGRUPACION, StringUtil.RTrim( context.localUtil.Format( A282AGRUPACION, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,159);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAGRUPACION_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAGRUPACION_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_FRUTAPROPIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtVALOR_TRANSP_AP_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVALOR_TRANSP_AP_Internalname, "VALOR_TRANSP_AP", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 164,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVALOR_TRANSP_AP_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A283VALOR_TRANSP_AP), 10, 0, ",", "")), StringUtil.LTrim( ((edtVALOR_TRANSP_AP_Enabled!=0) ? context.localUtil.Format( (decimal)(A283VALOR_TRANSP_AP), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A283VALOR_TRANSP_AP), "ZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,164);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVALOR_TRANSP_AP_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVALOR_TRANSP_AP_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_FRUTAPROPIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtHORA_SAI_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHORA_SAI_Internalname, "HORA_SAI", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 169,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHORA_SAI_Internalname, A284HORA_SAI, StringUtil.RTrim( context.localUtil.Format( A284HORA_SAI, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,169);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHORA_SAI_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtHORA_SAI_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_FRUTAPROPIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtHORA_BRUTO_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHORA_BRUTO_Internalname, "HORA_BRUTO", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 174,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHORA_BRUTO_Internalname, A285HORA_BRUTO, StringUtil.RTrim( context.localUtil.Format( A285HORA_BRUTO, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,174);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHORA_BRUTO_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtHORA_BRUTO_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_FRUTAPROPIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLOTE_NOM_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLOTE_NOM_Internalname, "LOTE_NOM", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 179,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLOTE_NOM_Internalname, A286LOTE_NOM, StringUtil.RTrim( context.localUtil.Format( A286LOTE_NOM, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,179);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLOTE_NOM_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLOTE_NOM_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_FRUTAPROPIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLOTE_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLOTE_Internalname, "LOTE", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 184,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLOTE_Internalname, A102LOTE, StringUtil.RTrim( context.localUtil.Format( A102LOTE, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,184);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLOTE_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLOTE_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_FRUTAPROPIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTAL_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTAL_Internalname, "TAL", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 189,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTAL_Internalname, A103TAL, StringUtil.RTrim( context.localUtil.Format( A103TAL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,189);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTAL_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTAL_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_FRUTAPROPIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTAL_DET_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTAL_DET_Internalname, "TAL_DET", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 194,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTAL_DET_Internalname, A287TAL_DET, StringUtil.RTrim( context.localUtil.Format( A287TAL_DET, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,194);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTAL_DET_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTAL_DET_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_FRUTAPROPIA.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 199,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_FRUTAPROPIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         drawControls1( ) ;
      }

      protected void drawControls1( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 201,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_FRUTAPROPIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 203,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_FRUTAPROPIA.htm");
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
            Z94FRUTAPROPIAFecha = context.localUtil.CToD( cgiGet( "Z94FRUTAPROPIAFecha"), 0);
            Z95FRUTAPROPIAMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z95FRUTAPROPIAMes"), ",", "."), 18, MidpointRounding.ToEven));
            Z96FRUTAPROPIAAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z96FRUTAPROPIAAno"), ",", "."), 18, MidpointRounding.ToEven));
            Z4IndicadoresCodigo = cgiGet( "Z4IndicadoresCodigo");
            Z5Cod_Area = cgiGet( "Z5Cod_Area");
            Z97VIAJE = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z97VIAJE"), ",", "."), 18, MidpointRounding.ToEven));
            Z98SETOR = cgiGet( "Z98SETOR");
            Z99FINCA = cgiGet( "Z99FINCA");
            Z100PROVE_COD = cgiGet( "Z100PROVE_COD");
            Z101DIA = context.localUtil.CToT( cgiGet( "Z101DIA"), 0);
            Z102LOTE = cgiGet( "Z102LOTE");
            Z103TAL = cgiGet( "Z103TAL");
            Z267FINCA_nom = cgiGet( "Z267FINCA_nom");
            Z268PROVE_NOM = cgiGet( "Z268PROVE_NOM");
            Z269CHOFER = cgiGet( "Z269CHOFER");
            Z270CABEZAL = cgiGet( "Z270CABEZAL");
            Z271FH_ENT = context.localUtil.CToD( cgiGet( "Z271FH_ENT"), 0);
            Z272FH_SAI = context.localUtil.CToD( cgiGet( "Z272FH_SAI"), 0);
            Z273PESO = context.localUtil.CToN( cgiGet( "Z273PESO"), ",", ".");
            Z274PESO_NETO = context.localUtil.CToN( cgiGet( "Z274PESO_NETO"), ",", ".");
            Z275TARA = context.localUtil.CToN( cgiGet( "Z275TARA"), ",", ".");
            Z276BRUTO = context.localUtil.CToN( cgiGet( "Z276BRUTO"), ",", ".");
            Z277FORN_ASOCIADO = cgiGet( "Z277FORN_ASOCIADO");
            Z278NOM_ASOCIADO = cgiGet( "Z278NOM_ASOCIADO");
            Z279COd_PROPIETARIO = cgiGet( "Z279COd_PROPIETARIO");
            Z280NOM_PROPIETARIO = cgiGet( "Z280NOM_PROPIETARIO");
            Z281TIPO = context.localUtil.CToN( cgiGet( "Z281TIPO"), ",", ".");
            Z282AGRUPACION = cgiGet( "Z282AGRUPACION");
            Z283VALOR_TRANSP_AP = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z283VALOR_TRANSP_AP"), ",", "."), 18, MidpointRounding.ToEven));
            Z284HORA_SAI = cgiGet( "Z284HORA_SAI");
            Z285HORA_BRUTO = cgiGet( "Z285HORA_BRUTO");
            Z286LOTE_NOM = cgiGet( "Z286LOTE_NOM");
            Z287TAL_DET = cgiGet( "Z287TAL_DET");
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( context.localUtil.VCDate( cgiGet( edtFRUTAPROPIAFecha_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"FRUTAPROPIAFecha"}), 1, "FRUTAPROPIAFECHA");
               AnyError = 1;
               GX_FocusControl = edtFRUTAPROPIAFecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A94FRUTAPROPIAFecha = DateTime.MinValue;
               AssignAttri("", false, "A94FRUTAPROPIAFecha", context.localUtil.Format(A94FRUTAPROPIAFecha, "99/99/99"));
            }
            else
            {
               A94FRUTAPROPIAFecha = context.localUtil.CToD( cgiGet( edtFRUTAPROPIAFecha_Internalname), 2);
               AssignAttri("", false, "A94FRUTAPROPIAFecha", context.localUtil.Format(A94FRUTAPROPIAFecha, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtFRUTAPROPIAMes_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtFRUTAPROPIAMes_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FRUTAPROPIAMES");
               AnyError = 1;
               GX_FocusControl = edtFRUTAPROPIAMes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A95FRUTAPROPIAMes = 0;
               AssignAttri("", false, "A95FRUTAPROPIAMes", StringUtil.LTrimStr( (decimal)(A95FRUTAPROPIAMes), 4, 0));
            }
            else
            {
               A95FRUTAPROPIAMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtFRUTAPROPIAMes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A95FRUTAPROPIAMes", StringUtil.LTrimStr( (decimal)(A95FRUTAPROPIAMes), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtFRUTAPROPIAAno_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtFRUTAPROPIAAno_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FRUTAPROPIAANO");
               AnyError = 1;
               GX_FocusControl = edtFRUTAPROPIAAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A96FRUTAPROPIAAno = 0;
               AssignAttri("", false, "A96FRUTAPROPIAAno", StringUtil.LTrimStr( (decimal)(A96FRUTAPROPIAAno), 4, 0));
            }
            else
            {
               A96FRUTAPROPIAAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtFRUTAPROPIAAno_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A96FRUTAPROPIAAno", StringUtil.LTrimStr( (decimal)(A96FRUTAPROPIAAno), 4, 0));
            }
            A4IndicadoresCodigo = cgiGet( edtIndicadoresCodigo_Internalname);
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A5Cod_Area = cgiGet( edtCod_Area_Internalname);
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            if ( ( ( context.localUtil.CToN( cgiGet( edtVIAJE_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtVIAJE_Internalname), ",", ".") > Convert.ToDecimal( 999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "VIAJE");
               AnyError = 1;
               GX_FocusControl = edtVIAJE_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A97VIAJE = 0;
               AssignAttri("", false, "A97VIAJE", StringUtil.LTrimStr( (decimal)(A97VIAJE), 12, 0));
            }
            else
            {
               A97VIAJE = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtVIAJE_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A97VIAJE", StringUtil.LTrimStr( (decimal)(A97VIAJE), 12, 0));
            }
            A98SETOR = cgiGet( edtSETOR_Internalname);
            AssignAttri("", false, "A98SETOR", A98SETOR);
            A99FINCA = cgiGet( edtFINCA_Internalname);
            AssignAttri("", false, "A99FINCA", A99FINCA);
            A267FINCA_nom = cgiGet( edtFINCA_nom_Internalname);
            AssignAttri("", false, "A267FINCA_nom", A267FINCA_nom);
            A100PROVE_COD = cgiGet( edtPROVE_COD_Internalname);
            AssignAttri("", false, "A100PROVE_COD", A100PROVE_COD);
            A268PROVE_NOM = cgiGet( edtPROVE_NOM_Internalname);
            AssignAttri("", false, "A268PROVE_NOM", A268PROVE_NOM);
            if ( context.localUtil.VCDateTime( cgiGet( edtDIA_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"DIA"}), 1, "DIA");
               AnyError = 1;
               GX_FocusControl = edtDIA_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A101DIA = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A101DIA", context.localUtil.TToC( A101DIA, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A101DIA = context.localUtil.CToT( cgiGet( edtDIA_Internalname));
               AssignAttri("", false, "A101DIA", context.localUtil.TToC( A101DIA, 8, 5, 0, 3, "/", ":", " "));
            }
            A269CHOFER = cgiGet( edtCHOFER_Internalname);
            AssignAttri("", false, "A269CHOFER", A269CHOFER);
            A270CABEZAL = cgiGet( edtCABEZAL_Internalname);
            AssignAttri("", false, "A270CABEZAL", A270CABEZAL);
            if ( context.localUtil.VCDate( cgiGet( edtFH_ENT_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"FH_ENT"}), 1, "FH_ENT");
               AnyError = 1;
               GX_FocusControl = edtFH_ENT_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A271FH_ENT = DateTime.MinValue;
               AssignAttri("", false, "A271FH_ENT", context.localUtil.Format(A271FH_ENT, "99/99/99"));
            }
            else
            {
               A271FH_ENT = context.localUtil.CToD( cgiGet( edtFH_ENT_Internalname), 2);
               AssignAttri("", false, "A271FH_ENT", context.localUtil.Format(A271FH_ENT, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtFH_SAI_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"FH_SAI"}), 1, "FH_SAI");
               AnyError = 1;
               GX_FocusControl = edtFH_SAI_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A272FH_SAI = DateTime.MinValue;
               AssignAttri("", false, "A272FH_SAI", context.localUtil.Format(A272FH_SAI, "99/99/99"));
            }
            else
            {
               A272FH_SAI = context.localUtil.CToD( cgiGet( edtFH_SAI_Internalname), 2);
               AssignAttri("", false, "A272FH_SAI", context.localUtil.Format(A272FH_SAI, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtPESO_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPESO_Internalname), ",", ".") > 999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PESO");
               AnyError = 1;
               GX_FocusControl = edtPESO_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A273PESO = 0;
               AssignAttri("", false, "A273PESO", StringUtil.LTrimStr( A273PESO, 12, 2));
            }
            else
            {
               A273PESO = context.localUtil.CToN( cgiGet( edtPESO_Internalname), ",", ".");
               AssignAttri("", false, "A273PESO", StringUtil.LTrimStr( A273PESO, 12, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtPESO_NETO_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPESO_NETO_Internalname), ",", ".") > 999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PESO_NETO");
               AnyError = 1;
               GX_FocusControl = edtPESO_NETO_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A274PESO_NETO = 0;
               AssignAttri("", false, "A274PESO_NETO", StringUtil.LTrimStr( A274PESO_NETO, 12, 2));
            }
            else
            {
               A274PESO_NETO = context.localUtil.CToN( cgiGet( edtPESO_NETO_Internalname), ",", ".");
               AssignAttri("", false, "A274PESO_NETO", StringUtil.LTrimStr( A274PESO_NETO, 12, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtTARA_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTARA_Internalname), ",", ".") > 999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TARA");
               AnyError = 1;
               GX_FocusControl = edtTARA_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A275TARA = 0;
               AssignAttri("", false, "A275TARA", StringUtil.LTrimStr( A275TARA, 12, 2));
            }
            else
            {
               A275TARA = context.localUtil.CToN( cgiGet( edtTARA_Internalname), ",", ".");
               AssignAttri("", false, "A275TARA", StringUtil.LTrimStr( A275TARA, 12, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtBRUTO_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtBRUTO_Internalname), ",", ".") > 999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "BRUTO");
               AnyError = 1;
               GX_FocusControl = edtBRUTO_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A276BRUTO = 0;
               AssignAttri("", false, "A276BRUTO", StringUtil.LTrimStr( A276BRUTO, 12, 2));
            }
            else
            {
               A276BRUTO = context.localUtil.CToN( cgiGet( edtBRUTO_Internalname), ",", ".");
               AssignAttri("", false, "A276BRUTO", StringUtil.LTrimStr( A276BRUTO, 12, 2));
            }
            A277FORN_ASOCIADO = cgiGet( edtFORN_ASOCIADO_Internalname);
            AssignAttri("", false, "A277FORN_ASOCIADO", A277FORN_ASOCIADO);
            A278NOM_ASOCIADO = cgiGet( edtNOM_ASOCIADO_Internalname);
            AssignAttri("", false, "A278NOM_ASOCIADO", A278NOM_ASOCIADO);
            A279COd_PROPIETARIO = cgiGet( edtCOd_PROPIETARIO_Internalname);
            AssignAttri("", false, "A279COd_PROPIETARIO", A279COd_PROPIETARIO);
            A280NOM_PROPIETARIO = cgiGet( edtNOM_PROPIETARIO_Internalname);
            AssignAttri("", false, "A280NOM_PROPIETARIO", A280NOM_PROPIETARIO);
            if ( ( ( context.localUtil.CToN( cgiGet( edtTIPO_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTIPO_Internalname), ",", ".") > 0.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TIPO");
               AnyError = 1;
               GX_FocusControl = edtTIPO_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A281TIPO = 0;
               AssignAttri("", false, "A281TIPO", StringUtil.LTrimStr( A281TIPO, 3, 2));
            }
            else
            {
               A281TIPO = context.localUtil.CToN( cgiGet( edtTIPO_Internalname), ",", ".");
               AssignAttri("", false, "A281TIPO", StringUtil.LTrimStr( A281TIPO, 3, 2));
            }
            A282AGRUPACION = cgiGet( edtAGRUPACION_Internalname);
            AssignAttri("", false, "A282AGRUPACION", A282AGRUPACION);
            if ( ( ( context.localUtil.CToN( cgiGet( edtVALOR_TRANSP_AP_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtVALOR_TRANSP_AP_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "VALOR_TRANSP_AP");
               AnyError = 1;
               GX_FocusControl = edtVALOR_TRANSP_AP_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A283VALOR_TRANSP_AP = 0;
               AssignAttri("", false, "A283VALOR_TRANSP_AP", StringUtil.LTrimStr( (decimal)(A283VALOR_TRANSP_AP), 10, 0));
            }
            else
            {
               A283VALOR_TRANSP_AP = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtVALOR_TRANSP_AP_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A283VALOR_TRANSP_AP", StringUtil.LTrimStr( (decimal)(A283VALOR_TRANSP_AP), 10, 0));
            }
            A284HORA_SAI = cgiGet( edtHORA_SAI_Internalname);
            AssignAttri("", false, "A284HORA_SAI", A284HORA_SAI);
            A285HORA_BRUTO = cgiGet( edtHORA_BRUTO_Internalname);
            AssignAttri("", false, "A285HORA_BRUTO", A285HORA_BRUTO);
            A286LOTE_NOM = cgiGet( edtLOTE_NOM_Internalname);
            AssignAttri("", false, "A286LOTE_NOM", A286LOTE_NOM);
            A102LOTE = cgiGet( edtLOTE_Internalname);
            AssignAttri("", false, "A102LOTE", A102LOTE);
            A103TAL = cgiGet( edtTAL_Internalname);
            AssignAttri("", false, "A103TAL", A103TAL);
            A287TAL_DET = cgiGet( edtTAL_DET_Internalname);
            AssignAttri("", false, "A287TAL_DET", A287TAL_DET);
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
               A94FRUTAPROPIAFecha = context.localUtil.ParseDateParm( GetPar( "FRUTAPROPIAFecha"));
               AssignAttri("", false, "A94FRUTAPROPIAFecha", context.localUtil.Format(A94FRUTAPROPIAFecha, "99/99/99"));
               A95FRUTAPROPIAMes = (short)(Math.Round(NumberUtil.Val( GetPar( "FRUTAPROPIAMes"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A95FRUTAPROPIAMes", StringUtil.LTrimStr( (decimal)(A95FRUTAPROPIAMes), 4, 0));
               A96FRUTAPROPIAAno = (short)(Math.Round(NumberUtil.Val( GetPar( "FRUTAPROPIAAno"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A96FRUTAPROPIAAno", StringUtil.LTrimStr( (decimal)(A96FRUTAPROPIAAno), 4, 0));
               A4IndicadoresCodigo = GetPar( "IndicadoresCodigo");
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               A5Cod_Area = GetPar( "Cod_Area");
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               A97VIAJE = (long)(Math.Round(NumberUtil.Val( GetPar( "VIAJE"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A97VIAJE", StringUtil.LTrimStr( (decimal)(A97VIAJE), 12, 0));
               A98SETOR = GetPar( "SETOR");
               AssignAttri("", false, "A98SETOR", A98SETOR);
               A99FINCA = GetPar( "FINCA");
               AssignAttri("", false, "A99FINCA", A99FINCA);
               A100PROVE_COD = GetPar( "PROVE_COD");
               AssignAttri("", false, "A100PROVE_COD", A100PROVE_COD);
               A101DIA = context.localUtil.ParseDTimeParm( GetPar( "DIA"));
               AssignAttri("", false, "A101DIA", context.localUtil.TToC( A101DIA, 8, 5, 0, 3, "/", ":", " "));
               A102LOTE = GetPar( "LOTE");
               AssignAttri("", false, "A102LOTE", A102LOTE);
               A103TAL = GetPar( "TAL");
               AssignAttri("", false, "A103TAL", A103TAL);
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
               InitAll0Q27( ) ;
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
         DisableAttributes0Q27( ) ;
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

      protected void ResetCaption0Q0( )
      {
      }

      protected void ZM0Q27( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z267FINCA_nom = T000Q3_A267FINCA_nom[0];
               Z268PROVE_NOM = T000Q3_A268PROVE_NOM[0];
               Z269CHOFER = T000Q3_A269CHOFER[0];
               Z270CABEZAL = T000Q3_A270CABEZAL[0];
               Z271FH_ENT = T000Q3_A271FH_ENT[0];
               Z272FH_SAI = T000Q3_A272FH_SAI[0];
               Z273PESO = T000Q3_A273PESO[0];
               Z274PESO_NETO = T000Q3_A274PESO_NETO[0];
               Z275TARA = T000Q3_A275TARA[0];
               Z276BRUTO = T000Q3_A276BRUTO[0];
               Z277FORN_ASOCIADO = T000Q3_A277FORN_ASOCIADO[0];
               Z278NOM_ASOCIADO = T000Q3_A278NOM_ASOCIADO[0];
               Z279COd_PROPIETARIO = T000Q3_A279COd_PROPIETARIO[0];
               Z280NOM_PROPIETARIO = T000Q3_A280NOM_PROPIETARIO[0];
               Z281TIPO = T000Q3_A281TIPO[0];
               Z282AGRUPACION = T000Q3_A282AGRUPACION[0];
               Z283VALOR_TRANSP_AP = T000Q3_A283VALOR_TRANSP_AP[0];
               Z284HORA_SAI = T000Q3_A284HORA_SAI[0];
               Z285HORA_BRUTO = T000Q3_A285HORA_BRUTO[0];
               Z286LOTE_NOM = T000Q3_A286LOTE_NOM[0];
               Z287TAL_DET = T000Q3_A287TAL_DET[0];
            }
            else
            {
               Z267FINCA_nom = A267FINCA_nom;
               Z268PROVE_NOM = A268PROVE_NOM;
               Z269CHOFER = A269CHOFER;
               Z270CABEZAL = A270CABEZAL;
               Z271FH_ENT = A271FH_ENT;
               Z272FH_SAI = A272FH_SAI;
               Z273PESO = A273PESO;
               Z274PESO_NETO = A274PESO_NETO;
               Z275TARA = A275TARA;
               Z276BRUTO = A276BRUTO;
               Z277FORN_ASOCIADO = A277FORN_ASOCIADO;
               Z278NOM_ASOCIADO = A278NOM_ASOCIADO;
               Z279COd_PROPIETARIO = A279COd_PROPIETARIO;
               Z280NOM_PROPIETARIO = A280NOM_PROPIETARIO;
               Z281TIPO = A281TIPO;
               Z282AGRUPACION = A282AGRUPACION;
               Z283VALOR_TRANSP_AP = A283VALOR_TRANSP_AP;
               Z284HORA_SAI = A284HORA_SAI;
               Z285HORA_BRUTO = A285HORA_BRUTO;
               Z286LOTE_NOM = A286LOTE_NOM;
               Z287TAL_DET = A287TAL_DET;
            }
         }
         if ( GX_JID == -5 )
         {
            Z94FRUTAPROPIAFecha = A94FRUTAPROPIAFecha;
            Z95FRUTAPROPIAMes = A95FRUTAPROPIAMes;
            Z96FRUTAPROPIAAno = A96FRUTAPROPIAAno;
            Z97VIAJE = A97VIAJE;
            Z98SETOR = A98SETOR;
            Z99FINCA = A99FINCA;
            Z100PROVE_COD = A100PROVE_COD;
            Z101DIA = A101DIA;
            Z102LOTE = A102LOTE;
            Z103TAL = A103TAL;
            Z267FINCA_nom = A267FINCA_nom;
            Z268PROVE_NOM = A268PROVE_NOM;
            Z269CHOFER = A269CHOFER;
            Z270CABEZAL = A270CABEZAL;
            Z271FH_ENT = A271FH_ENT;
            Z272FH_SAI = A272FH_SAI;
            Z273PESO = A273PESO;
            Z274PESO_NETO = A274PESO_NETO;
            Z275TARA = A275TARA;
            Z276BRUTO = A276BRUTO;
            Z277FORN_ASOCIADO = A277FORN_ASOCIADO;
            Z278NOM_ASOCIADO = A278NOM_ASOCIADO;
            Z279COd_PROPIETARIO = A279COd_PROPIETARIO;
            Z280NOM_PROPIETARIO = A280NOM_PROPIETARIO;
            Z281TIPO = A281TIPO;
            Z282AGRUPACION = A282AGRUPACION;
            Z283VALOR_TRANSP_AP = A283VALOR_TRANSP_AP;
            Z284HORA_SAI = A284HORA_SAI;
            Z285HORA_BRUTO = A285HORA_BRUTO;
            Z286LOTE_NOM = A286LOTE_NOM;
            Z287TAL_DET = A287TAL_DET;
            Z4IndicadoresCodigo = A4IndicadoresCodigo;
            Z5Cod_Area = A5Cod_Area;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_4_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0030.aspx"+"',["+"{Ctrl:gx.dom.el('"+"INDICADORESCODIGO"+"'), id:'"+"INDICADORESCODIGO"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"true"+");");
         imgprompt_5_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"COD_AREA"+"'), id:'"+"COD_AREA"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"true"+");");
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

      protected void Load0Q27( )
      {
         /* Using cursor T000Q6 */
         pr_default.execute(4, new Object[] {A94FRUTAPROPIAFecha, A95FRUTAPROPIAMes, A96FRUTAPROPIAAno, A4IndicadoresCodigo, A5Cod_Area, A97VIAJE, A98SETOR, A99FINCA, A100PROVE_COD, A101DIA, A102LOTE, A103TAL});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound27 = 1;
            A267FINCA_nom = T000Q6_A267FINCA_nom[0];
            AssignAttri("", false, "A267FINCA_nom", A267FINCA_nom);
            A268PROVE_NOM = T000Q6_A268PROVE_NOM[0];
            AssignAttri("", false, "A268PROVE_NOM", A268PROVE_NOM);
            A269CHOFER = T000Q6_A269CHOFER[0];
            AssignAttri("", false, "A269CHOFER", A269CHOFER);
            A270CABEZAL = T000Q6_A270CABEZAL[0];
            AssignAttri("", false, "A270CABEZAL", A270CABEZAL);
            A271FH_ENT = T000Q6_A271FH_ENT[0];
            AssignAttri("", false, "A271FH_ENT", context.localUtil.Format(A271FH_ENT, "99/99/99"));
            A272FH_SAI = T000Q6_A272FH_SAI[0];
            AssignAttri("", false, "A272FH_SAI", context.localUtil.Format(A272FH_SAI, "99/99/99"));
            A273PESO = T000Q6_A273PESO[0];
            AssignAttri("", false, "A273PESO", StringUtil.LTrimStr( A273PESO, 12, 2));
            A274PESO_NETO = T000Q6_A274PESO_NETO[0];
            AssignAttri("", false, "A274PESO_NETO", StringUtil.LTrimStr( A274PESO_NETO, 12, 2));
            A275TARA = T000Q6_A275TARA[0];
            AssignAttri("", false, "A275TARA", StringUtil.LTrimStr( A275TARA, 12, 2));
            A276BRUTO = T000Q6_A276BRUTO[0];
            AssignAttri("", false, "A276BRUTO", StringUtil.LTrimStr( A276BRUTO, 12, 2));
            A277FORN_ASOCIADO = T000Q6_A277FORN_ASOCIADO[0];
            AssignAttri("", false, "A277FORN_ASOCIADO", A277FORN_ASOCIADO);
            A278NOM_ASOCIADO = T000Q6_A278NOM_ASOCIADO[0];
            AssignAttri("", false, "A278NOM_ASOCIADO", A278NOM_ASOCIADO);
            A279COd_PROPIETARIO = T000Q6_A279COd_PROPIETARIO[0];
            AssignAttri("", false, "A279COd_PROPIETARIO", A279COd_PROPIETARIO);
            A280NOM_PROPIETARIO = T000Q6_A280NOM_PROPIETARIO[0];
            AssignAttri("", false, "A280NOM_PROPIETARIO", A280NOM_PROPIETARIO);
            A281TIPO = T000Q6_A281TIPO[0];
            AssignAttri("", false, "A281TIPO", StringUtil.LTrimStr( A281TIPO, 3, 2));
            A282AGRUPACION = T000Q6_A282AGRUPACION[0];
            AssignAttri("", false, "A282AGRUPACION", A282AGRUPACION);
            A283VALOR_TRANSP_AP = T000Q6_A283VALOR_TRANSP_AP[0];
            AssignAttri("", false, "A283VALOR_TRANSP_AP", StringUtil.LTrimStr( (decimal)(A283VALOR_TRANSP_AP), 10, 0));
            A284HORA_SAI = T000Q6_A284HORA_SAI[0];
            AssignAttri("", false, "A284HORA_SAI", A284HORA_SAI);
            A285HORA_BRUTO = T000Q6_A285HORA_BRUTO[0];
            AssignAttri("", false, "A285HORA_BRUTO", A285HORA_BRUTO);
            A286LOTE_NOM = T000Q6_A286LOTE_NOM[0];
            AssignAttri("", false, "A286LOTE_NOM", A286LOTE_NOM);
            A287TAL_DET = T000Q6_A287TAL_DET[0];
            AssignAttri("", false, "A287TAL_DET", A287TAL_DET);
            ZM0Q27( -5) ;
         }
         pr_default.close(4);
         OnLoadActions0Q27( ) ;
      }

      protected void OnLoadActions0Q27( )
      {
      }

      protected void CheckExtendedTable0Q27( )
      {
         nIsDirty_27 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A94FRUTAPROPIAFecha) || ( DateTimeUtil.ResetTime ( A94FRUTAPROPIAFecha ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo FRUTAPROPIAFecha fuera de rango", "OutOfRange", 1, "FRUTAPROPIAFECHA");
            AnyError = 1;
            GX_FocusControl = edtFRUTAPROPIAFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000Q4 */
         pr_default.execute(2, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T000Q5 */
         pr_default.execute(3, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         if ( ! ( (DateTime.MinValue==A101DIA) || ( A101DIA >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo DIA fuera de rango", "OutOfRange", 1, "DIA");
            AnyError = 1;
            GX_FocusControl = edtDIA_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A271FH_ENT) || ( DateTimeUtil.ResetTime ( A271FH_ENT ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo FH_ENT fuera de rango", "OutOfRange", 1, "FH_ENT");
            AnyError = 1;
            GX_FocusControl = edtFH_ENT_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A272FH_SAI) || ( DateTimeUtil.ResetTime ( A272FH_SAI ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo FH_SAI fuera de rango", "OutOfRange", 1, "FH_SAI");
            AnyError = 1;
            GX_FocusControl = edtFH_SAI_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0Q27( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_6( string A4IndicadoresCodigo )
      {
         /* Using cursor T000Q7 */
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

      protected void gxLoad_7( string A5Cod_Area )
      {
         /* Using cursor T000Q8 */
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

      protected void GetKey0Q27( )
      {
         /* Using cursor T000Q9 */
         pr_default.execute(7, new Object[] {A94FRUTAPROPIAFecha, A95FRUTAPROPIAMes, A96FRUTAPROPIAAno, A4IndicadoresCodigo, A5Cod_Area, A97VIAJE, A98SETOR, A99FINCA, A100PROVE_COD, A101DIA, A102LOTE, A103TAL});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound27 = 1;
         }
         else
         {
            RcdFound27 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000Q3 */
         pr_default.execute(1, new Object[] {A94FRUTAPROPIAFecha, A95FRUTAPROPIAMes, A96FRUTAPROPIAAno, A4IndicadoresCodigo, A5Cod_Area, A97VIAJE, A98SETOR, A99FINCA, A100PROVE_COD, A101DIA, A102LOTE, A103TAL});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0Q27( 5) ;
            RcdFound27 = 1;
            A94FRUTAPROPIAFecha = T000Q3_A94FRUTAPROPIAFecha[0];
            AssignAttri("", false, "A94FRUTAPROPIAFecha", context.localUtil.Format(A94FRUTAPROPIAFecha, "99/99/99"));
            A95FRUTAPROPIAMes = T000Q3_A95FRUTAPROPIAMes[0];
            AssignAttri("", false, "A95FRUTAPROPIAMes", StringUtil.LTrimStr( (decimal)(A95FRUTAPROPIAMes), 4, 0));
            A96FRUTAPROPIAAno = T000Q3_A96FRUTAPROPIAAno[0];
            AssignAttri("", false, "A96FRUTAPROPIAAno", StringUtil.LTrimStr( (decimal)(A96FRUTAPROPIAAno), 4, 0));
            A97VIAJE = T000Q3_A97VIAJE[0];
            AssignAttri("", false, "A97VIAJE", StringUtil.LTrimStr( (decimal)(A97VIAJE), 12, 0));
            A98SETOR = T000Q3_A98SETOR[0];
            AssignAttri("", false, "A98SETOR", A98SETOR);
            A99FINCA = T000Q3_A99FINCA[0];
            AssignAttri("", false, "A99FINCA", A99FINCA);
            A100PROVE_COD = T000Q3_A100PROVE_COD[0];
            AssignAttri("", false, "A100PROVE_COD", A100PROVE_COD);
            A101DIA = T000Q3_A101DIA[0];
            AssignAttri("", false, "A101DIA", context.localUtil.TToC( A101DIA, 8, 5, 0, 3, "/", ":", " "));
            A102LOTE = T000Q3_A102LOTE[0];
            AssignAttri("", false, "A102LOTE", A102LOTE);
            A103TAL = T000Q3_A103TAL[0];
            AssignAttri("", false, "A103TAL", A103TAL);
            A267FINCA_nom = T000Q3_A267FINCA_nom[0];
            AssignAttri("", false, "A267FINCA_nom", A267FINCA_nom);
            A268PROVE_NOM = T000Q3_A268PROVE_NOM[0];
            AssignAttri("", false, "A268PROVE_NOM", A268PROVE_NOM);
            A269CHOFER = T000Q3_A269CHOFER[0];
            AssignAttri("", false, "A269CHOFER", A269CHOFER);
            A270CABEZAL = T000Q3_A270CABEZAL[0];
            AssignAttri("", false, "A270CABEZAL", A270CABEZAL);
            A271FH_ENT = T000Q3_A271FH_ENT[0];
            AssignAttri("", false, "A271FH_ENT", context.localUtil.Format(A271FH_ENT, "99/99/99"));
            A272FH_SAI = T000Q3_A272FH_SAI[0];
            AssignAttri("", false, "A272FH_SAI", context.localUtil.Format(A272FH_SAI, "99/99/99"));
            A273PESO = T000Q3_A273PESO[0];
            AssignAttri("", false, "A273PESO", StringUtil.LTrimStr( A273PESO, 12, 2));
            A274PESO_NETO = T000Q3_A274PESO_NETO[0];
            AssignAttri("", false, "A274PESO_NETO", StringUtil.LTrimStr( A274PESO_NETO, 12, 2));
            A275TARA = T000Q3_A275TARA[0];
            AssignAttri("", false, "A275TARA", StringUtil.LTrimStr( A275TARA, 12, 2));
            A276BRUTO = T000Q3_A276BRUTO[0];
            AssignAttri("", false, "A276BRUTO", StringUtil.LTrimStr( A276BRUTO, 12, 2));
            A277FORN_ASOCIADO = T000Q3_A277FORN_ASOCIADO[0];
            AssignAttri("", false, "A277FORN_ASOCIADO", A277FORN_ASOCIADO);
            A278NOM_ASOCIADO = T000Q3_A278NOM_ASOCIADO[0];
            AssignAttri("", false, "A278NOM_ASOCIADO", A278NOM_ASOCIADO);
            A279COd_PROPIETARIO = T000Q3_A279COd_PROPIETARIO[0];
            AssignAttri("", false, "A279COd_PROPIETARIO", A279COd_PROPIETARIO);
            A280NOM_PROPIETARIO = T000Q3_A280NOM_PROPIETARIO[0];
            AssignAttri("", false, "A280NOM_PROPIETARIO", A280NOM_PROPIETARIO);
            A281TIPO = T000Q3_A281TIPO[0];
            AssignAttri("", false, "A281TIPO", StringUtil.LTrimStr( A281TIPO, 3, 2));
            A282AGRUPACION = T000Q3_A282AGRUPACION[0];
            AssignAttri("", false, "A282AGRUPACION", A282AGRUPACION);
            A283VALOR_TRANSP_AP = T000Q3_A283VALOR_TRANSP_AP[0];
            AssignAttri("", false, "A283VALOR_TRANSP_AP", StringUtil.LTrimStr( (decimal)(A283VALOR_TRANSP_AP), 10, 0));
            A284HORA_SAI = T000Q3_A284HORA_SAI[0];
            AssignAttri("", false, "A284HORA_SAI", A284HORA_SAI);
            A285HORA_BRUTO = T000Q3_A285HORA_BRUTO[0];
            AssignAttri("", false, "A285HORA_BRUTO", A285HORA_BRUTO);
            A286LOTE_NOM = T000Q3_A286LOTE_NOM[0];
            AssignAttri("", false, "A286LOTE_NOM", A286LOTE_NOM);
            A287TAL_DET = T000Q3_A287TAL_DET[0];
            AssignAttri("", false, "A287TAL_DET", A287TAL_DET);
            A4IndicadoresCodigo = T000Q3_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A5Cod_Area = T000Q3_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            Z94FRUTAPROPIAFecha = A94FRUTAPROPIAFecha;
            Z95FRUTAPROPIAMes = A95FRUTAPROPIAMes;
            Z96FRUTAPROPIAAno = A96FRUTAPROPIAAno;
            Z4IndicadoresCodigo = A4IndicadoresCodigo;
            Z5Cod_Area = A5Cod_Area;
            Z97VIAJE = A97VIAJE;
            Z98SETOR = A98SETOR;
            Z99FINCA = A99FINCA;
            Z100PROVE_COD = A100PROVE_COD;
            Z101DIA = A101DIA;
            Z102LOTE = A102LOTE;
            Z103TAL = A103TAL;
            sMode27 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0Q27( ) ;
            if ( AnyError == 1 )
            {
               RcdFound27 = 0;
               InitializeNonKey0Q27( ) ;
            }
            Gx_mode = sMode27;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound27 = 0;
            InitializeNonKey0Q27( ) ;
            sMode27 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode27;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0Q27( ) ;
         if ( RcdFound27 == 0 )
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
         RcdFound27 = 0;
         /* Using cursor T000Q10 */
         pr_default.execute(8, new Object[] {A94FRUTAPROPIAFecha, A95FRUTAPROPIAMes, A96FRUTAPROPIAAno, A4IndicadoresCodigo, A5Cod_Area, A97VIAJE, A98SETOR, A99FINCA, A100PROVE_COD, A101DIA, A102LOTE, A103TAL});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( DateTimeUtil.ResetTime ( T000Q10_A94FRUTAPROPIAFecha[0] ) < DateTimeUtil.ResetTime ( A94FRUTAPROPIAFecha ) ) || ( DateTimeUtil.ResetTime ( T000Q10_A94FRUTAPROPIAFecha[0] ) == DateTimeUtil.ResetTime ( A94FRUTAPROPIAFecha ) ) && ( T000Q10_A95FRUTAPROPIAMes[0] < A95FRUTAPROPIAMes ) || ( T000Q10_A95FRUTAPROPIAMes[0] == A95FRUTAPROPIAMes ) &&
            ( DateTimeUtil.ResetTime ( T000Q10_A94FRUTAPROPIAFecha[0] ) == DateTimeUtil.ResetTime ( A94FRUTAPROPIAFecha ) ) && ( T000Q10_A96FRUTAPROPIAAno[0] < A96FRUTAPROPIAAno ) || ( T000Q10_A96FRUTAPROPIAAno[0] == A96FRUTAPROPIAAno ) && ( T000Q10_A95FRUTAPROPIAMes[0] == A95FRUTAPROPIAMes ) && ( DateTimeUtil.ResetTime ( T000Q10_A94FRUTAPROPIAFecha[0] ) == DateTimeUtil.ResetTime ( A94FRUTAPROPIAFecha ) ) &&
            ( StringUtil.StrCmp(T000Q10_A4IndicadoresCodigo[0], A4IndicadoresCodigo) < 0 ) || ( StringUtil.StrCmp(T000Q10_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000Q10_A96FRUTAPROPIAAno[0] == A96FRUTAPROPIAAno ) && ( T000Q10_A95FRUTAPROPIAMes[0] == A95FRUTAPROPIAMes ) && ( DateTimeUtil.ResetTime ( T000Q10_A94FRUTAPROPIAFecha[0] ) == DateTimeUtil.ResetTime ( A94FRUTAPROPIAFecha ) ) &&
            ( StringUtil.StrCmp(T000Q10_A5Cod_Area[0], A5Cod_Area) < 0 ) || ( StringUtil.StrCmp(T000Q10_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( StringUtil.StrCmp(T000Q10_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000Q10_A96FRUTAPROPIAAno[0] == A96FRUTAPROPIAAno ) && ( T000Q10_A95FRUTAPROPIAMes[0] == A95FRUTAPROPIAMes ) && ( DateTimeUtil.ResetTime ( T000Q10_A94FRUTAPROPIAFecha[0] ) ==
            DateTimeUtil.ResetTime ( A94FRUTAPROPIAFecha ) ) && ( T000Q10_A97VIAJE[0] < A97VIAJE ) || ( T000Q10_A97VIAJE[0] == A97VIAJE ) && ( StringUtil.StrCmp(T000Q10_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( StringUtil.StrCmp(T000Q10_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000Q10_A96FRUTAPROPIAAno[0] == A96FRUTAPROPIAAno ) && ( T000Q10_A95FRUTAPROPIAMes[0] == A95FRUTAPROPIAMes ) &&
            ( DateTimeUtil.ResetTime ( T000Q10_A94FRUTAPROPIAFecha[0] ) == DateTimeUtil.ResetTime ( A94FRUTAPROPIAFecha ) ) && ( StringUtil.StrCmp(T000Q10_A98SETOR[0], A98SETOR) < 0 ) || ( StringUtil.StrCmp(T000Q10_A98SETOR[0], A98SETOR) == 0 ) && ( T000Q10_A97VIAJE[0] == A97VIAJE ) && ( StringUtil.StrCmp(T000Q10_A5Cod_Area[0], A5Cod_Area) == 0 ) &&
            ( StringUtil.StrCmp(T000Q10_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000Q10_A96FRUTAPROPIAAno[0] == A96FRUTAPROPIAAno ) && ( T000Q10_A95FRUTAPROPIAMes[0] == A95FRUTAPROPIAMes ) && ( DateTimeUtil.ResetTime ( T000Q10_A94FRUTAPROPIAFecha[0] ) == DateTimeUtil.ResetTime ( A94FRUTAPROPIAFecha ) ) && ( StringUtil.StrCmp(T000Q10_A99FINCA[0], A99FINCA) < 0 ) ||
            ( StringUtil.StrCmp(T000Q10_A99FINCA[0], A99FINCA) == 0 ) && ( StringUtil.StrCmp(T000Q10_A98SETOR[0], A98SETOR) == 0 ) && ( T000Q10_A97VIAJE[0] == A97VIAJE ) && ( StringUtil.StrCmp(T000Q10_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( StringUtil.StrCmp(T000Q10_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000Q10_A96FRUTAPROPIAAno[0] == A96FRUTAPROPIAAno ) && ( T000Q10_A95FRUTAPROPIAMes[0] ==
            A95FRUTAPROPIAMes ) && ( DateTimeUtil.ResetTime ( T000Q10_A94FRUTAPROPIAFecha[0] ) == DateTimeUtil.ResetTime ( A94FRUTAPROPIAFecha ) ) && ( StringUtil.StrCmp(T000Q10_A100PROVE_COD[0], A100PROVE_COD) < 0 ) || ( StringUtil.StrCmp(T000Q10_A100PROVE_COD[0], A100PROVE_COD) == 0 ) && ( StringUtil.StrCmp(T000Q10_A99FINCA[0], A99FINCA) == 0 ) && ( StringUtil.StrCmp(T000Q10_A98SETOR[0], A98SETOR) == 0 ) &&
            ( T000Q10_A97VIAJE[0] == A97VIAJE ) && ( StringUtil.StrCmp(T000Q10_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( StringUtil.StrCmp(T000Q10_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000Q10_A96FRUTAPROPIAAno[0] == A96FRUTAPROPIAAno ) && ( T000Q10_A95FRUTAPROPIAMes[0] == A95FRUTAPROPIAMes ) && ( DateTimeUtil.ResetTime ( T000Q10_A94FRUTAPROPIAFecha[0] ) ==
            DateTimeUtil.ResetTime ( A94FRUTAPROPIAFecha ) ) && ( T000Q10_A101DIA[0] < A101DIA ) || ( T000Q10_A101DIA[0] == A101DIA ) && ( StringUtil.StrCmp(T000Q10_A100PROVE_COD[0], A100PROVE_COD) == 0 ) && ( StringUtil.StrCmp(T000Q10_A99FINCA[0], A99FINCA) == 0 ) && ( StringUtil.StrCmp(T000Q10_A98SETOR[0], A98SETOR) == 0 ) && ( T000Q10_A97VIAJE[0] == A97VIAJE ) &&
            ( StringUtil.StrCmp(T000Q10_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( StringUtil.StrCmp(T000Q10_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000Q10_A96FRUTAPROPIAAno[0] == A96FRUTAPROPIAAno ) && ( T000Q10_A95FRUTAPROPIAMes[0] == A95FRUTAPROPIAMes ) && ( DateTimeUtil.ResetTime ( T000Q10_A94FRUTAPROPIAFecha[0] ) == DateTimeUtil.ResetTime ( A94FRUTAPROPIAFecha ) ) &&
            ( StringUtil.StrCmp(T000Q10_A102LOTE[0], A102LOTE) < 0 ) || ( StringUtil.StrCmp(T000Q10_A102LOTE[0], A102LOTE) == 0 ) && ( T000Q10_A101DIA[0] == A101DIA ) && ( StringUtil.StrCmp(T000Q10_A100PROVE_COD[0], A100PROVE_COD) == 0 ) && ( StringUtil.StrCmp(T000Q10_A99FINCA[0], A99FINCA) == 0 ) && ( StringUtil.StrCmp(T000Q10_A98SETOR[0], A98SETOR) == 0 ) && ( T000Q10_A97VIAJE[0] == A97VIAJE ) &&
            ( StringUtil.StrCmp(T000Q10_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( StringUtil.StrCmp(T000Q10_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000Q10_A96FRUTAPROPIAAno[0] == A96FRUTAPROPIAAno ) && ( T000Q10_A95FRUTAPROPIAMes[0] == A95FRUTAPROPIAMes ) && ( DateTimeUtil.ResetTime ( T000Q10_A94FRUTAPROPIAFecha[0] ) == DateTimeUtil.ResetTime ( A94FRUTAPROPIAFecha ) ) && ( StringUtil.StrCmp(T000Q10_A103TAL[0], A103TAL) < 0 ) )
            )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( DateTimeUtil.ResetTime ( T000Q10_A94FRUTAPROPIAFecha[0] ) > DateTimeUtil.ResetTime ( A94FRUTAPROPIAFecha ) ) || ( DateTimeUtil.ResetTime ( T000Q10_A94FRUTAPROPIAFecha[0] ) == DateTimeUtil.ResetTime ( A94FRUTAPROPIAFecha ) ) && ( T000Q10_A95FRUTAPROPIAMes[0] > A95FRUTAPROPIAMes ) || ( T000Q10_A95FRUTAPROPIAMes[0] == A95FRUTAPROPIAMes ) &&
            ( DateTimeUtil.ResetTime ( T000Q10_A94FRUTAPROPIAFecha[0] ) == DateTimeUtil.ResetTime ( A94FRUTAPROPIAFecha ) ) && ( T000Q10_A96FRUTAPROPIAAno[0] > A96FRUTAPROPIAAno ) || ( T000Q10_A96FRUTAPROPIAAno[0] == A96FRUTAPROPIAAno ) && ( T000Q10_A95FRUTAPROPIAMes[0] == A95FRUTAPROPIAMes ) && ( DateTimeUtil.ResetTime ( T000Q10_A94FRUTAPROPIAFecha[0] ) == DateTimeUtil.ResetTime ( A94FRUTAPROPIAFecha ) ) &&
            ( StringUtil.StrCmp(T000Q10_A4IndicadoresCodigo[0], A4IndicadoresCodigo) > 0 ) || ( StringUtil.StrCmp(T000Q10_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000Q10_A96FRUTAPROPIAAno[0] == A96FRUTAPROPIAAno ) && ( T000Q10_A95FRUTAPROPIAMes[0] == A95FRUTAPROPIAMes ) && ( DateTimeUtil.ResetTime ( T000Q10_A94FRUTAPROPIAFecha[0] ) == DateTimeUtil.ResetTime ( A94FRUTAPROPIAFecha ) ) &&
            ( StringUtil.StrCmp(T000Q10_A5Cod_Area[0], A5Cod_Area) > 0 ) || ( StringUtil.StrCmp(T000Q10_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( StringUtil.StrCmp(T000Q10_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000Q10_A96FRUTAPROPIAAno[0] == A96FRUTAPROPIAAno ) && ( T000Q10_A95FRUTAPROPIAMes[0] == A95FRUTAPROPIAMes ) && ( DateTimeUtil.ResetTime ( T000Q10_A94FRUTAPROPIAFecha[0] ) ==
            DateTimeUtil.ResetTime ( A94FRUTAPROPIAFecha ) ) && ( T000Q10_A97VIAJE[0] > A97VIAJE ) || ( T000Q10_A97VIAJE[0] == A97VIAJE ) && ( StringUtil.StrCmp(T000Q10_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( StringUtil.StrCmp(T000Q10_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000Q10_A96FRUTAPROPIAAno[0] == A96FRUTAPROPIAAno ) && ( T000Q10_A95FRUTAPROPIAMes[0] == A95FRUTAPROPIAMes ) &&
            ( DateTimeUtil.ResetTime ( T000Q10_A94FRUTAPROPIAFecha[0] ) == DateTimeUtil.ResetTime ( A94FRUTAPROPIAFecha ) ) && ( StringUtil.StrCmp(T000Q10_A98SETOR[0], A98SETOR) > 0 ) || ( StringUtil.StrCmp(T000Q10_A98SETOR[0], A98SETOR) == 0 ) && ( T000Q10_A97VIAJE[0] == A97VIAJE ) && ( StringUtil.StrCmp(T000Q10_A5Cod_Area[0], A5Cod_Area) == 0 ) &&
            ( StringUtil.StrCmp(T000Q10_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000Q10_A96FRUTAPROPIAAno[0] == A96FRUTAPROPIAAno ) && ( T000Q10_A95FRUTAPROPIAMes[0] == A95FRUTAPROPIAMes ) && ( DateTimeUtil.ResetTime ( T000Q10_A94FRUTAPROPIAFecha[0] ) == DateTimeUtil.ResetTime ( A94FRUTAPROPIAFecha ) ) && ( StringUtil.StrCmp(T000Q10_A99FINCA[0], A99FINCA) > 0 ) ||
            ( StringUtil.StrCmp(T000Q10_A99FINCA[0], A99FINCA) == 0 ) && ( StringUtil.StrCmp(T000Q10_A98SETOR[0], A98SETOR) == 0 ) && ( T000Q10_A97VIAJE[0] == A97VIAJE ) && ( StringUtil.StrCmp(T000Q10_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( StringUtil.StrCmp(T000Q10_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000Q10_A96FRUTAPROPIAAno[0] == A96FRUTAPROPIAAno ) && ( T000Q10_A95FRUTAPROPIAMes[0] ==
            A95FRUTAPROPIAMes ) && ( DateTimeUtil.ResetTime ( T000Q10_A94FRUTAPROPIAFecha[0] ) == DateTimeUtil.ResetTime ( A94FRUTAPROPIAFecha ) ) && ( StringUtil.StrCmp(T000Q10_A100PROVE_COD[0], A100PROVE_COD) > 0 ) || ( StringUtil.StrCmp(T000Q10_A100PROVE_COD[0], A100PROVE_COD) == 0 ) && ( StringUtil.StrCmp(T000Q10_A99FINCA[0], A99FINCA) == 0 ) && ( StringUtil.StrCmp(T000Q10_A98SETOR[0], A98SETOR) == 0 ) &&
            ( T000Q10_A97VIAJE[0] == A97VIAJE ) && ( StringUtil.StrCmp(T000Q10_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( StringUtil.StrCmp(T000Q10_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000Q10_A96FRUTAPROPIAAno[0] == A96FRUTAPROPIAAno ) && ( T000Q10_A95FRUTAPROPIAMes[0] == A95FRUTAPROPIAMes ) && ( DateTimeUtil.ResetTime ( T000Q10_A94FRUTAPROPIAFecha[0] ) ==
            DateTimeUtil.ResetTime ( A94FRUTAPROPIAFecha ) ) && ( T000Q10_A101DIA[0] > A101DIA ) || ( T000Q10_A101DIA[0] == A101DIA ) && ( StringUtil.StrCmp(T000Q10_A100PROVE_COD[0], A100PROVE_COD) == 0 ) && ( StringUtil.StrCmp(T000Q10_A99FINCA[0], A99FINCA) == 0 ) && ( StringUtil.StrCmp(T000Q10_A98SETOR[0], A98SETOR) == 0 ) && ( T000Q10_A97VIAJE[0] == A97VIAJE ) &&
            ( StringUtil.StrCmp(T000Q10_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( StringUtil.StrCmp(T000Q10_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000Q10_A96FRUTAPROPIAAno[0] == A96FRUTAPROPIAAno ) && ( T000Q10_A95FRUTAPROPIAMes[0] == A95FRUTAPROPIAMes ) && ( DateTimeUtil.ResetTime ( T000Q10_A94FRUTAPROPIAFecha[0] ) == DateTimeUtil.ResetTime ( A94FRUTAPROPIAFecha ) ) &&
            ( StringUtil.StrCmp(T000Q10_A102LOTE[0], A102LOTE) > 0 ) || ( StringUtil.StrCmp(T000Q10_A102LOTE[0], A102LOTE) == 0 ) && ( T000Q10_A101DIA[0] == A101DIA ) && ( StringUtil.StrCmp(T000Q10_A100PROVE_COD[0], A100PROVE_COD) == 0 ) && ( StringUtil.StrCmp(T000Q10_A99FINCA[0], A99FINCA) == 0 ) && ( StringUtil.StrCmp(T000Q10_A98SETOR[0], A98SETOR) == 0 ) && ( T000Q10_A97VIAJE[0] == A97VIAJE ) &&
            ( StringUtil.StrCmp(T000Q10_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( StringUtil.StrCmp(T000Q10_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000Q10_A96FRUTAPROPIAAno[0] == A96FRUTAPROPIAAno ) && ( T000Q10_A95FRUTAPROPIAMes[0] == A95FRUTAPROPIAMes ) && ( DateTimeUtil.ResetTime ( T000Q10_A94FRUTAPROPIAFecha[0] ) == DateTimeUtil.ResetTime ( A94FRUTAPROPIAFecha ) ) &&
            ( StringUtil.StrCmp(T000Q10_A103TAL[0], A103TAL) > 0 ) )
            )
            {
               A94FRUTAPROPIAFecha = T000Q10_A94FRUTAPROPIAFecha[0];
               AssignAttri("", false, "A94FRUTAPROPIAFecha", context.localUtil.Format(A94FRUTAPROPIAFecha, "99/99/99"));
               A95FRUTAPROPIAMes = T000Q10_A95FRUTAPROPIAMes[0];
               AssignAttri("", false, "A95FRUTAPROPIAMes", StringUtil.LTrimStr( (decimal)(A95FRUTAPROPIAMes), 4, 0));
               A96FRUTAPROPIAAno = T000Q10_A96FRUTAPROPIAAno[0];
               AssignAttri("", false, "A96FRUTAPROPIAAno", StringUtil.LTrimStr( (decimal)(A96FRUTAPROPIAAno), 4, 0));
               A4IndicadoresCodigo = T000Q10_A4IndicadoresCodigo[0];
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               A5Cod_Area = T000Q10_A5Cod_Area[0];
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               A97VIAJE = T000Q10_A97VIAJE[0];
               AssignAttri("", false, "A97VIAJE", StringUtil.LTrimStr( (decimal)(A97VIAJE), 12, 0));
               A98SETOR = T000Q10_A98SETOR[0];
               AssignAttri("", false, "A98SETOR", A98SETOR);
               A99FINCA = T000Q10_A99FINCA[0];
               AssignAttri("", false, "A99FINCA", A99FINCA);
               A100PROVE_COD = T000Q10_A100PROVE_COD[0];
               AssignAttri("", false, "A100PROVE_COD", A100PROVE_COD);
               A101DIA = T000Q10_A101DIA[0];
               AssignAttri("", false, "A101DIA", context.localUtil.TToC( A101DIA, 8, 5, 0, 3, "/", ":", " "));
               A102LOTE = T000Q10_A102LOTE[0];
               AssignAttri("", false, "A102LOTE", A102LOTE);
               A103TAL = T000Q10_A103TAL[0];
               AssignAttri("", false, "A103TAL", A103TAL);
               RcdFound27 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound27 = 0;
         /* Using cursor T000Q11 */
         pr_default.execute(9, new Object[] {A94FRUTAPROPIAFecha, A95FRUTAPROPIAMes, A96FRUTAPROPIAAno, A4IndicadoresCodigo, A5Cod_Area, A97VIAJE, A98SETOR, A99FINCA, A100PROVE_COD, A101DIA, A102LOTE, A103TAL});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( DateTimeUtil.ResetTime ( T000Q11_A94FRUTAPROPIAFecha[0] ) > DateTimeUtil.ResetTime ( A94FRUTAPROPIAFecha ) ) || ( DateTimeUtil.ResetTime ( T000Q11_A94FRUTAPROPIAFecha[0] ) == DateTimeUtil.ResetTime ( A94FRUTAPROPIAFecha ) ) && ( T000Q11_A95FRUTAPROPIAMes[0] > A95FRUTAPROPIAMes ) || ( T000Q11_A95FRUTAPROPIAMes[0] == A95FRUTAPROPIAMes ) &&
            ( DateTimeUtil.ResetTime ( T000Q11_A94FRUTAPROPIAFecha[0] ) == DateTimeUtil.ResetTime ( A94FRUTAPROPIAFecha ) ) && ( T000Q11_A96FRUTAPROPIAAno[0] > A96FRUTAPROPIAAno ) || ( T000Q11_A96FRUTAPROPIAAno[0] == A96FRUTAPROPIAAno ) && ( T000Q11_A95FRUTAPROPIAMes[0] == A95FRUTAPROPIAMes ) && ( DateTimeUtil.ResetTime ( T000Q11_A94FRUTAPROPIAFecha[0] ) == DateTimeUtil.ResetTime ( A94FRUTAPROPIAFecha ) ) &&
            ( StringUtil.StrCmp(T000Q11_A4IndicadoresCodigo[0], A4IndicadoresCodigo) > 0 ) || ( StringUtil.StrCmp(T000Q11_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000Q11_A96FRUTAPROPIAAno[0] == A96FRUTAPROPIAAno ) && ( T000Q11_A95FRUTAPROPIAMes[0] == A95FRUTAPROPIAMes ) && ( DateTimeUtil.ResetTime ( T000Q11_A94FRUTAPROPIAFecha[0] ) == DateTimeUtil.ResetTime ( A94FRUTAPROPIAFecha ) ) &&
            ( StringUtil.StrCmp(T000Q11_A5Cod_Area[0], A5Cod_Area) > 0 ) || ( StringUtil.StrCmp(T000Q11_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( StringUtil.StrCmp(T000Q11_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000Q11_A96FRUTAPROPIAAno[0] == A96FRUTAPROPIAAno ) && ( T000Q11_A95FRUTAPROPIAMes[0] == A95FRUTAPROPIAMes ) && ( DateTimeUtil.ResetTime ( T000Q11_A94FRUTAPROPIAFecha[0] ) ==
            DateTimeUtil.ResetTime ( A94FRUTAPROPIAFecha ) ) && ( T000Q11_A97VIAJE[0] > A97VIAJE ) || ( T000Q11_A97VIAJE[0] == A97VIAJE ) && ( StringUtil.StrCmp(T000Q11_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( StringUtil.StrCmp(T000Q11_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000Q11_A96FRUTAPROPIAAno[0] == A96FRUTAPROPIAAno ) && ( T000Q11_A95FRUTAPROPIAMes[0] == A95FRUTAPROPIAMes ) &&
            ( DateTimeUtil.ResetTime ( T000Q11_A94FRUTAPROPIAFecha[0] ) == DateTimeUtil.ResetTime ( A94FRUTAPROPIAFecha ) ) && ( StringUtil.StrCmp(T000Q11_A98SETOR[0], A98SETOR) > 0 ) || ( StringUtil.StrCmp(T000Q11_A98SETOR[0], A98SETOR) == 0 ) && ( T000Q11_A97VIAJE[0] == A97VIAJE ) && ( StringUtil.StrCmp(T000Q11_A5Cod_Area[0], A5Cod_Area) == 0 ) &&
            ( StringUtil.StrCmp(T000Q11_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000Q11_A96FRUTAPROPIAAno[0] == A96FRUTAPROPIAAno ) && ( T000Q11_A95FRUTAPROPIAMes[0] == A95FRUTAPROPIAMes ) && ( DateTimeUtil.ResetTime ( T000Q11_A94FRUTAPROPIAFecha[0] ) == DateTimeUtil.ResetTime ( A94FRUTAPROPIAFecha ) ) && ( StringUtil.StrCmp(T000Q11_A99FINCA[0], A99FINCA) > 0 ) ||
            ( StringUtil.StrCmp(T000Q11_A99FINCA[0], A99FINCA) == 0 ) && ( StringUtil.StrCmp(T000Q11_A98SETOR[0], A98SETOR) == 0 ) && ( T000Q11_A97VIAJE[0] == A97VIAJE ) && ( StringUtil.StrCmp(T000Q11_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( StringUtil.StrCmp(T000Q11_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000Q11_A96FRUTAPROPIAAno[0] == A96FRUTAPROPIAAno ) && ( T000Q11_A95FRUTAPROPIAMes[0] ==
            A95FRUTAPROPIAMes ) && ( DateTimeUtil.ResetTime ( T000Q11_A94FRUTAPROPIAFecha[0] ) == DateTimeUtil.ResetTime ( A94FRUTAPROPIAFecha ) ) && ( StringUtil.StrCmp(T000Q11_A100PROVE_COD[0], A100PROVE_COD) > 0 ) || ( StringUtil.StrCmp(T000Q11_A100PROVE_COD[0], A100PROVE_COD) == 0 ) && ( StringUtil.StrCmp(T000Q11_A99FINCA[0], A99FINCA) == 0 ) && ( StringUtil.StrCmp(T000Q11_A98SETOR[0], A98SETOR) == 0 ) &&
            ( T000Q11_A97VIAJE[0] == A97VIAJE ) && ( StringUtil.StrCmp(T000Q11_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( StringUtil.StrCmp(T000Q11_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000Q11_A96FRUTAPROPIAAno[0] == A96FRUTAPROPIAAno ) && ( T000Q11_A95FRUTAPROPIAMes[0] == A95FRUTAPROPIAMes ) && ( DateTimeUtil.ResetTime ( T000Q11_A94FRUTAPROPIAFecha[0] ) ==
            DateTimeUtil.ResetTime ( A94FRUTAPROPIAFecha ) ) && ( T000Q11_A101DIA[0] > A101DIA ) || ( T000Q11_A101DIA[0] == A101DIA ) && ( StringUtil.StrCmp(T000Q11_A100PROVE_COD[0], A100PROVE_COD) == 0 ) && ( StringUtil.StrCmp(T000Q11_A99FINCA[0], A99FINCA) == 0 ) && ( StringUtil.StrCmp(T000Q11_A98SETOR[0], A98SETOR) == 0 ) && ( T000Q11_A97VIAJE[0] == A97VIAJE ) &&
            ( StringUtil.StrCmp(T000Q11_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( StringUtil.StrCmp(T000Q11_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000Q11_A96FRUTAPROPIAAno[0] == A96FRUTAPROPIAAno ) && ( T000Q11_A95FRUTAPROPIAMes[0] == A95FRUTAPROPIAMes ) && ( DateTimeUtil.ResetTime ( T000Q11_A94FRUTAPROPIAFecha[0] ) == DateTimeUtil.ResetTime ( A94FRUTAPROPIAFecha ) ) &&
            ( StringUtil.StrCmp(T000Q11_A102LOTE[0], A102LOTE) > 0 ) || ( StringUtil.StrCmp(T000Q11_A102LOTE[0], A102LOTE) == 0 ) && ( T000Q11_A101DIA[0] == A101DIA ) && ( StringUtil.StrCmp(T000Q11_A100PROVE_COD[0], A100PROVE_COD) == 0 ) && ( StringUtil.StrCmp(T000Q11_A99FINCA[0], A99FINCA) == 0 ) && ( StringUtil.StrCmp(T000Q11_A98SETOR[0], A98SETOR) == 0 ) && ( T000Q11_A97VIAJE[0] == A97VIAJE ) &&
            ( StringUtil.StrCmp(T000Q11_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( StringUtil.StrCmp(T000Q11_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000Q11_A96FRUTAPROPIAAno[0] == A96FRUTAPROPIAAno ) && ( T000Q11_A95FRUTAPROPIAMes[0] == A95FRUTAPROPIAMes ) && ( DateTimeUtil.ResetTime ( T000Q11_A94FRUTAPROPIAFecha[0] ) == DateTimeUtil.ResetTime ( A94FRUTAPROPIAFecha ) ) &&
            ( StringUtil.StrCmp(T000Q11_A103TAL[0], A103TAL) > 0 ) )
            )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( DateTimeUtil.ResetTime ( T000Q11_A94FRUTAPROPIAFecha[0] ) < DateTimeUtil.ResetTime ( A94FRUTAPROPIAFecha ) ) || ( DateTimeUtil.ResetTime ( T000Q11_A94FRUTAPROPIAFecha[0] ) == DateTimeUtil.ResetTime ( A94FRUTAPROPIAFecha ) ) && ( T000Q11_A95FRUTAPROPIAMes[0] < A95FRUTAPROPIAMes ) || ( T000Q11_A95FRUTAPROPIAMes[0] == A95FRUTAPROPIAMes ) &&
            ( DateTimeUtil.ResetTime ( T000Q11_A94FRUTAPROPIAFecha[0] ) == DateTimeUtil.ResetTime ( A94FRUTAPROPIAFecha ) ) && ( T000Q11_A96FRUTAPROPIAAno[0] < A96FRUTAPROPIAAno ) || ( T000Q11_A96FRUTAPROPIAAno[0] == A96FRUTAPROPIAAno ) && ( T000Q11_A95FRUTAPROPIAMes[0] == A95FRUTAPROPIAMes ) && ( DateTimeUtil.ResetTime ( T000Q11_A94FRUTAPROPIAFecha[0] ) == DateTimeUtil.ResetTime ( A94FRUTAPROPIAFecha ) ) &&
            ( StringUtil.StrCmp(T000Q11_A4IndicadoresCodigo[0], A4IndicadoresCodigo) < 0 ) || ( StringUtil.StrCmp(T000Q11_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000Q11_A96FRUTAPROPIAAno[0] == A96FRUTAPROPIAAno ) && ( T000Q11_A95FRUTAPROPIAMes[0] == A95FRUTAPROPIAMes ) && ( DateTimeUtil.ResetTime ( T000Q11_A94FRUTAPROPIAFecha[0] ) == DateTimeUtil.ResetTime ( A94FRUTAPROPIAFecha ) ) &&
            ( StringUtil.StrCmp(T000Q11_A5Cod_Area[0], A5Cod_Area) < 0 ) || ( StringUtil.StrCmp(T000Q11_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( StringUtil.StrCmp(T000Q11_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000Q11_A96FRUTAPROPIAAno[0] == A96FRUTAPROPIAAno ) && ( T000Q11_A95FRUTAPROPIAMes[0] == A95FRUTAPROPIAMes ) && ( DateTimeUtil.ResetTime ( T000Q11_A94FRUTAPROPIAFecha[0] ) ==
            DateTimeUtil.ResetTime ( A94FRUTAPROPIAFecha ) ) && ( T000Q11_A97VIAJE[0] < A97VIAJE ) || ( T000Q11_A97VIAJE[0] == A97VIAJE ) && ( StringUtil.StrCmp(T000Q11_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( StringUtil.StrCmp(T000Q11_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000Q11_A96FRUTAPROPIAAno[0] == A96FRUTAPROPIAAno ) && ( T000Q11_A95FRUTAPROPIAMes[0] == A95FRUTAPROPIAMes ) &&
            ( DateTimeUtil.ResetTime ( T000Q11_A94FRUTAPROPIAFecha[0] ) == DateTimeUtil.ResetTime ( A94FRUTAPROPIAFecha ) ) && ( StringUtil.StrCmp(T000Q11_A98SETOR[0], A98SETOR) < 0 ) || ( StringUtil.StrCmp(T000Q11_A98SETOR[0], A98SETOR) == 0 ) && ( T000Q11_A97VIAJE[0] == A97VIAJE ) && ( StringUtil.StrCmp(T000Q11_A5Cod_Area[0], A5Cod_Area) == 0 ) &&
            ( StringUtil.StrCmp(T000Q11_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000Q11_A96FRUTAPROPIAAno[0] == A96FRUTAPROPIAAno ) && ( T000Q11_A95FRUTAPROPIAMes[0] == A95FRUTAPROPIAMes ) && ( DateTimeUtil.ResetTime ( T000Q11_A94FRUTAPROPIAFecha[0] ) == DateTimeUtil.ResetTime ( A94FRUTAPROPIAFecha ) ) && ( StringUtil.StrCmp(T000Q11_A99FINCA[0], A99FINCA) < 0 ) ||
            ( StringUtil.StrCmp(T000Q11_A99FINCA[0], A99FINCA) == 0 ) && ( StringUtil.StrCmp(T000Q11_A98SETOR[0], A98SETOR) == 0 ) && ( T000Q11_A97VIAJE[0] == A97VIAJE ) && ( StringUtil.StrCmp(T000Q11_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( StringUtil.StrCmp(T000Q11_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000Q11_A96FRUTAPROPIAAno[0] == A96FRUTAPROPIAAno ) && ( T000Q11_A95FRUTAPROPIAMes[0] ==
            A95FRUTAPROPIAMes ) && ( DateTimeUtil.ResetTime ( T000Q11_A94FRUTAPROPIAFecha[0] ) == DateTimeUtil.ResetTime ( A94FRUTAPROPIAFecha ) ) && ( StringUtil.StrCmp(T000Q11_A100PROVE_COD[0], A100PROVE_COD) < 0 ) || ( StringUtil.StrCmp(T000Q11_A100PROVE_COD[0], A100PROVE_COD) == 0 ) && ( StringUtil.StrCmp(T000Q11_A99FINCA[0], A99FINCA) == 0 ) && ( StringUtil.StrCmp(T000Q11_A98SETOR[0], A98SETOR) == 0 ) &&
            ( T000Q11_A97VIAJE[0] == A97VIAJE ) && ( StringUtil.StrCmp(T000Q11_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( StringUtil.StrCmp(T000Q11_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000Q11_A96FRUTAPROPIAAno[0] == A96FRUTAPROPIAAno ) && ( T000Q11_A95FRUTAPROPIAMes[0] == A95FRUTAPROPIAMes ) && ( DateTimeUtil.ResetTime ( T000Q11_A94FRUTAPROPIAFecha[0] ) ==
            DateTimeUtil.ResetTime ( A94FRUTAPROPIAFecha ) ) && ( T000Q11_A101DIA[0] < A101DIA ) || ( T000Q11_A101DIA[0] == A101DIA ) && ( StringUtil.StrCmp(T000Q11_A100PROVE_COD[0], A100PROVE_COD) == 0 ) && ( StringUtil.StrCmp(T000Q11_A99FINCA[0], A99FINCA) == 0 ) && ( StringUtil.StrCmp(T000Q11_A98SETOR[0], A98SETOR) == 0 ) && ( T000Q11_A97VIAJE[0] == A97VIAJE ) &&
            ( StringUtil.StrCmp(T000Q11_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( StringUtil.StrCmp(T000Q11_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000Q11_A96FRUTAPROPIAAno[0] == A96FRUTAPROPIAAno ) && ( T000Q11_A95FRUTAPROPIAMes[0] == A95FRUTAPROPIAMes ) && ( DateTimeUtil.ResetTime ( T000Q11_A94FRUTAPROPIAFecha[0] ) == DateTimeUtil.ResetTime ( A94FRUTAPROPIAFecha ) ) &&
            ( StringUtil.StrCmp(T000Q11_A102LOTE[0], A102LOTE) < 0 ) || ( StringUtil.StrCmp(T000Q11_A102LOTE[0], A102LOTE) == 0 ) && ( T000Q11_A101DIA[0] == A101DIA ) && ( StringUtil.StrCmp(T000Q11_A100PROVE_COD[0], A100PROVE_COD) == 0 ) && ( StringUtil.StrCmp(T000Q11_A99FINCA[0], A99FINCA) == 0 ) && ( StringUtil.StrCmp(T000Q11_A98SETOR[0], A98SETOR) == 0 ) && ( T000Q11_A97VIAJE[0] == A97VIAJE ) &&
            ( StringUtil.StrCmp(T000Q11_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( StringUtil.StrCmp(T000Q11_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( T000Q11_A96FRUTAPROPIAAno[0] == A96FRUTAPROPIAAno ) && ( T000Q11_A95FRUTAPROPIAMes[0] == A95FRUTAPROPIAMes ) && ( DateTimeUtil.ResetTime ( T000Q11_A94FRUTAPROPIAFecha[0] ) == DateTimeUtil.ResetTime ( A94FRUTAPROPIAFecha ) ) && ( StringUtil.StrCmp(T000Q11_A103TAL[0], A103TAL) < 0 ) )
            )
            {
               A94FRUTAPROPIAFecha = T000Q11_A94FRUTAPROPIAFecha[0];
               AssignAttri("", false, "A94FRUTAPROPIAFecha", context.localUtil.Format(A94FRUTAPROPIAFecha, "99/99/99"));
               A95FRUTAPROPIAMes = T000Q11_A95FRUTAPROPIAMes[0];
               AssignAttri("", false, "A95FRUTAPROPIAMes", StringUtil.LTrimStr( (decimal)(A95FRUTAPROPIAMes), 4, 0));
               A96FRUTAPROPIAAno = T000Q11_A96FRUTAPROPIAAno[0];
               AssignAttri("", false, "A96FRUTAPROPIAAno", StringUtil.LTrimStr( (decimal)(A96FRUTAPROPIAAno), 4, 0));
               A4IndicadoresCodigo = T000Q11_A4IndicadoresCodigo[0];
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               A5Cod_Area = T000Q11_A5Cod_Area[0];
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               A97VIAJE = T000Q11_A97VIAJE[0];
               AssignAttri("", false, "A97VIAJE", StringUtil.LTrimStr( (decimal)(A97VIAJE), 12, 0));
               A98SETOR = T000Q11_A98SETOR[0];
               AssignAttri("", false, "A98SETOR", A98SETOR);
               A99FINCA = T000Q11_A99FINCA[0];
               AssignAttri("", false, "A99FINCA", A99FINCA);
               A100PROVE_COD = T000Q11_A100PROVE_COD[0];
               AssignAttri("", false, "A100PROVE_COD", A100PROVE_COD);
               A101DIA = T000Q11_A101DIA[0];
               AssignAttri("", false, "A101DIA", context.localUtil.TToC( A101DIA, 8, 5, 0, 3, "/", ":", " "));
               A102LOTE = T000Q11_A102LOTE[0];
               AssignAttri("", false, "A102LOTE", A102LOTE);
               A103TAL = T000Q11_A103TAL[0];
               AssignAttri("", false, "A103TAL", A103TAL);
               RcdFound27 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0Q27( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtFRUTAPROPIAFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0Q27( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound27 == 1 )
            {
               if ( ( DateTimeUtil.ResetTime ( A94FRUTAPROPIAFecha ) != DateTimeUtil.ResetTime ( Z94FRUTAPROPIAFecha ) ) || ( A95FRUTAPROPIAMes != Z95FRUTAPROPIAMes ) || ( A96FRUTAPROPIAAno != Z96FRUTAPROPIAAno ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( A97VIAJE != Z97VIAJE ) || ( StringUtil.StrCmp(A98SETOR, Z98SETOR) != 0 ) || ( StringUtil.StrCmp(A99FINCA, Z99FINCA) != 0 ) || ( StringUtil.StrCmp(A100PROVE_COD, Z100PROVE_COD) != 0 ) || ( A101DIA != Z101DIA ) || ( StringUtil.StrCmp(A102LOTE, Z102LOTE) != 0 ) || ( StringUtil.StrCmp(A103TAL, Z103TAL) != 0 ) )
               {
                  A94FRUTAPROPIAFecha = Z94FRUTAPROPIAFecha;
                  AssignAttri("", false, "A94FRUTAPROPIAFecha", context.localUtil.Format(A94FRUTAPROPIAFecha, "99/99/99"));
                  A95FRUTAPROPIAMes = Z95FRUTAPROPIAMes;
                  AssignAttri("", false, "A95FRUTAPROPIAMes", StringUtil.LTrimStr( (decimal)(A95FRUTAPROPIAMes), 4, 0));
                  A96FRUTAPROPIAAno = Z96FRUTAPROPIAAno;
                  AssignAttri("", false, "A96FRUTAPROPIAAno", StringUtil.LTrimStr( (decimal)(A96FRUTAPROPIAAno), 4, 0));
                  A4IndicadoresCodigo = Z4IndicadoresCodigo;
                  AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
                  A5Cod_Area = Z5Cod_Area;
                  AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
                  A97VIAJE = Z97VIAJE;
                  AssignAttri("", false, "A97VIAJE", StringUtil.LTrimStr( (decimal)(A97VIAJE), 12, 0));
                  A98SETOR = Z98SETOR;
                  AssignAttri("", false, "A98SETOR", A98SETOR);
                  A99FINCA = Z99FINCA;
                  AssignAttri("", false, "A99FINCA", A99FINCA);
                  A100PROVE_COD = Z100PROVE_COD;
                  AssignAttri("", false, "A100PROVE_COD", A100PROVE_COD);
                  A101DIA = Z101DIA;
                  AssignAttri("", false, "A101DIA", context.localUtil.TToC( A101DIA, 8, 5, 0, 3, "/", ":", " "));
                  A102LOTE = Z102LOTE;
                  AssignAttri("", false, "A102LOTE", A102LOTE);
                  A103TAL = Z103TAL;
                  AssignAttri("", false, "A103TAL", A103TAL);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "FRUTAPROPIAFECHA");
                  AnyError = 1;
                  GX_FocusControl = edtFRUTAPROPIAFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtFRUTAPROPIAFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0Q27( ) ;
                  GX_FocusControl = edtFRUTAPROPIAFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( DateTimeUtil.ResetTime ( A94FRUTAPROPIAFecha ) != DateTimeUtil.ResetTime ( Z94FRUTAPROPIAFecha ) ) || ( A95FRUTAPROPIAMes != Z95FRUTAPROPIAMes ) || ( A96FRUTAPROPIAAno != Z96FRUTAPROPIAAno ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( A97VIAJE != Z97VIAJE ) || ( StringUtil.StrCmp(A98SETOR, Z98SETOR) != 0 ) || ( StringUtil.StrCmp(A99FINCA, Z99FINCA) != 0 ) || ( StringUtil.StrCmp(A100PROVE_COD, Z100PROVE_COD) != 0 ) || ( A101DIA != Z101DIA ) || ( StringUtil.StrCmp(A102LOTE, Z102LOTE) != 0 ) || ( StringUtil.StrCmp(A103TAL, Z103TAL) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtFRUTAPROPIAFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0Q27( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "FRUTAPROPIAFECHA");
                     AnyError = 1;
                     GX_FocusControl = edtFRUTAPROPIAFecha_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtFRUTAPROPIAFecha_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0Q27( ) ;
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
         if ( ( DateTimeUtil.ResetTime ( A94FRUTAPROPIAFecha ) != DateTimeUtil.ResetTime ( Z94FRUTAPROPIAFecha ) ) || ( A95FRUTAPROPIAMes != Z95FRUTAPROPIAMes ) || ( A96FRUTAPROPIAAno != Z96FRUTAPROPIAAno ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( A97VIAJE != Z97VIAJE ) || ( StringUtil.StrCmp(A98SETOR, Z98SETOR) != 0 ) || ( StringUtil.StrCmp(A99FINCA, Z99FINCA) != 0 ) || ( StringUtil.StrCmp(A100PROVE_COD, Z100PROVE_COD) != 0 ) || ( A101DIA != Z101DIA ) || ( StringUtil.StrCmp(A102LOTE, Z102LOTE) != 0 ) || ( StringUtil.StrCmp(A103TAL, Z103TAL) != 0 ) )
         {
            A94FRUTAPROPIAFecha = Z94FRUTAPROPIAFecha;
            AssignAttri("", false, "A94FRUTAPROPIAFecha", context.localUtil.Format(A94FRUTAPROPIAFecha, "99/99/99"));
            A95FRUTAPROPIAMes = Z95FRUTAPROPIAMes;
            AssignAttri("", false, "A95FRUTAPROPIAMes", StringUtil.LTrimStr( (decimal)(A95FRUTAPROPIAMes), 4, 0));
            A96FRUTAPROPIAAno = Z96FRUTAPROPIAAno;
            AssignAttri("", false, "A96FRUTAPROPIAAno", StringUtil.LTrimStr( (decimal)(A96FRUTAPROPIAAno), 4, 0));
            A4IndicadoresCodigo = Z4IndicadoresCodigo;
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A5Cod_Area = Z5Cod_Area;
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A97VIAJE = Z97VIAJE;
            AssignAttri("", false, "A97VIAJE", StringUtil.LTrimStr( (decimal)(A97VIAJE), 12, 0));
            A98SETOR = Z98SETOR;
            AssignAttri("", false, "A98SETOR", A98SETOR);
            A99FINCA = Z99FINCA;
            AssignAttri("", false, "A99FINCA", A99FINCA);
            A100PROVE_COD = Z100PROVE_COD;
            AssignAttri("", false, "A100PROVE_COD", A100PROVE_COD);
            A101DIA = Z101DIA;
            AssignAttri("", false, "A101DIA", context.localUtil.TToC( A101DIA, 8, 5, 0, 3, "/", ":", " "));
            A102LOTE = Z102LOTE;
            AssignAttri("", false, "A102LOTE", A102LOTE);
            A103TAL = Z103TAL;
            AssignAttri("", false, "A103TAL", A103TAL);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "FRUTAPROPIAFECHA");
            AnyError = 1;
            GX_FocusControl = edtFRUTAPROPIAFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtFRUTAPROPIAFecha_Internalname;
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
         if ( RcdFound27 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "FRUTAPROPIAFECHA");
            AnyError = 1;
            GX_FocusControl = edtFRUTAPROPIAFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtFINCA_nom_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0Q27( ) ;
         if ( RcdFound27 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtFINCA_nom_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0Q27( ) ;
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
         if ( RcdFound27 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtFINCA_nom_Internalname;
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
         if ( RcdFound27 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtFINCA_nom_Internalname;
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
         ScanStart0Q27( ) ;
         if ( RcdFound27 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound27 != 0 )
            {
               ScanNext0Q27( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtFINCA_nom_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0Q27( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0Q27( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000Q2 */
            pr_default.execute(0, new Object[] {A94FRUTAPROPIAFecha, A95FRUTAPROPIAMes, A96FRUTAPROPIAAno, A4IndicadoresCodigo, A5Cod_Area, A97VIAJE, A98SETOR, A99FINCA, A100PROVE_COD, A101DIA, A102LOTE, A103TAL});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"FRUTAPROPIA"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z267FINCA_nom, T000Q2_A267FINCA_nom[0]) != 0 ) || ( StringUtil.StrCmp(Z268PROVE_NOM, T000Q2_A268PROVE_NOM[0]) != 0 ) || ( StringUtil.StrCmp(Z269CHOFER, T000Q2_A269CHOFER[0]) != 0 ) || ( StringUtil.StrCmp(Z270CABEZAL, T000Q2_A270CABEZAL[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z271FH_ENT ) != DateTimeUtil.ResetTime ( T000Q2_A271FH_ENT[0] ) ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( DateTimeUtil.ResetTime ( Z272FH_SAI ) != DateTimeUtil.ResetTime ( T000Q2_A272FH_SAI[0] ) ) || ( Z273PESO != T000Q2_A273PESO[0] ) || ( Z274PESO_NETO != T000Q2_A274PESO_NETO[0] ) || ( Z275TARA != T000Q2_A275TARA[0] ) || ( Z276BRUTO != T000Q2_A276BRUTO[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z277FORN_ASOCIADO, T000Q2_A277FORN_ASOCIADO[0]) != 0 ) || ( StringUtil.StrCmp(Z278NOM_ASOCIADO, T000Q2_A278NOM_ASOCIADO[0]) != 0 ) || ( StringUtil.StrCmp(Z279COd_PROPIETARIO, T000Q2_A279COd_PROPIETARIO[0]) != 0 ) || ( StringUtil.StrCmp(Z280NOM_PROPIETARIO, T000Q2_A280NOM_PROPIETARIO[0]) != 0 ) || ( Z281TIPO != T000Q2_A281TIPO[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z282AGRUPACION, T000Q2_A282AGRUPACION[0]) != 0 ) || ( Z283VALOR_TRANSP_AP != T000Q2_A283VALOR_TRANSP_AP[0] ) || ( StringUtil.StrCmp(Z284HORA_SAI, T000Q2_A284HORA_SAI[0]) != 0 ) || ( StringUtil.StrCmp(Z285HORA_BRUTO, T000Q2_A285HORA_BRUTO[0]) != 0 ) || ( StringUtil.StrCmp(Z286LOTE_NOM, T000Q2_A286LOTE_NOM[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z287TAL_DET, T000Q2_A287TAL_DET[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z267FINCA_nom, T000Q2_A267FINCA_nom[0]) != 0 )
               {
                  GXUtil.WriteLog("frutapropia:[seudo value changed for attri]"+"FINCA_nom");
                  GXUtil.WriteLogRaw("Old: ",Z267FINCA_nom);
                  GXUtil.WriteLogRaw("Current: ",T000Q2_A267FINCA_nom[0]);
               }
               if ( StringUtil.StrCmp(Z268PROVE_NOM, T000Q2_A268PROVE_NOM[0]) != 0 )
               {
                  GXUtil.WriteLog("frutapropia:[seudo value changed for attri]"+"PROVE_NOM");
                  GXUtil.WriteLogRaw("Old: ",Z268PROVE_NOM);
                  GXUtil.WriteLogRaw("Current: ",T000Q2_A268PROVE_NOM[0]);
               }
               if ( StringUtil.StrCmp(Z269CHOFER, T000Q2_A269CHOFER[0]) != 0 )
               {
                  GXUtil.WriteLog("frutapropia:[seudo value changed for attri]"+"CHOFER");
                  GXUtil.WriteLogRaw("Old: ",Z269CHOFER);
                  GXUtil.WriteLogRaw("Current: ",T000Q2_A269CHOFER[0]);
               }
               if ( StringUtil.StrCmp(Z270CABEZAL, T000Q2_A270CABEZAL[0]) != 0 )
               {
                  GXUtil.WriteLog("frutapropia:[seudo value changed for attri]"+"CABEZAL");
                  GXUtil.WriteLogRaw("Old: ",Z270CABEZAL);
                  GXUtil.WriteLogRaw("Current: ",T000Q2_A270CABEZAL[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z271FH_ENT ) != DateTimeUtil.ResetTime ( T000Q2_A271FH_ENT[0] ) )
               {
                  GXUtil.WriteLog("frutapropia:[seudo value changed for attri]"+"FH_ENT");
                  GXUtil.WriteLogRaw("Old: ",Z271FH_ENT);
                  GXUtil.WriteLogRaw("Current: ",T000Q2_A271FH_ENT[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z272FH_SAI ) != DateTimeUtil.ResetTime ( T000Q2_A272FH_SAI[0] ) )
               {
                  GXUtil.WriteLog("frutapropia:[seudo value changed for attri]"+"FH_SAI");
                  GXUtil.WriteLogRaw("Old: ",Z272FH_SAI);
                  GXUtil.WriteLogRaw("Current: ",T000Q2_A272FH_SAI[0]);
               }
               if ( Z273PESO != T000Q2_A273PESO[0] )
               {
                  GXUtil.WriteLog("frutapropia:[seudo value changed for attri]"+"PESO");
                  GXUtil.WriteLogRaw("Old: ",Z273PESO);
                  GXUtil.WriteLogRaw("Current: ",T000Q2_A273PESO[0]);
               }
               if ( Z274PESO_NETO != T000Q2_A274PESO_NETO[0] )
               {
                  GXUtil.WriteLog("frutapropia:[seudo value changed for attri]"+"PESO_NETO");
                  GXUtil.WriteLogRaw("Old: ",Z274PESO_NETO);
                  GXUtil.WriteLogRaw("Current: ",T000Q2_A274PESO_NETO[0]);
               }
               if ( Z275TARA != T000Q2_A275TARA[0] )
               {
                  GXUtil.WriteLog("frutapropia:[seudo value changed for attri]"+"TARA");
                  GXUtil.WriteLogRaw("Old: ",Z275TARA);
                  GXUtil.WriteLogRaw("Current: ",T000Q2_A275TARA[0]);
               }
               if ( Z276BRUTO != T000Q2_A276BRUTO[0] )
               {
                  GXUtil.WriteLog("frutapropia:[seudo value changed for attri]"+"BRUTO");
                  GXUtil.WriteLogRaw("Old: ",Z276BRUTO);
                  GXUtil.WriteLogRaw("Current: ",T000Q2_A276BRUTO[0]);
               }
               if ( StringUtil.StrCmp(Z277FORN_ASOCIADO, T000Q2_A277FORN_ASOCIADO[0]) != 0 )
               {
                  GXUtil.WriteLog("frutapropia:[seudo value changed for attri]"+"FORN_ASOCIADO");
                  GXUtil.WriteLogRaw("Old: ",Z277FORN_ASOCIADO);
                  GXUtil.WriteLogRaw("Current: ",T000Q2_A277FORN_ASOCIADO[0]);
               }
               if ( StringUtil.StrCmp(Z278NOM_ASOCIADO, T000Q2_A278NOM_ASOCIADO[0]) != 0 )
               {
                  GXUtil.WriteLog("frutapropia:[seudo value changed for attri]"+"NOM_ASOCIADO");
                  GXUtil.WriteLogRaw("Old: ",Z278NOM_ASOCIADO);
                  GXUtil.WriteLogRaw("Current: ",T000Q2_A278NOM_ASOCIADO[0]);
               }
               if ( StringUtil.StrCmp(Z279COd_PROPIETARIO, T000Q2_A279COd_PROPIETARIO[0]) != 0 )
               {
                  GXUtil.WriteLog("frutapropia:[seudo value changed for attri]"+"COd_PROPIETARIO");
                  GXUtil.WriteLogRaw("Old: ",Z279COd_PROPIETARIO);
                  GXUtil.WriteLogRaw("Current: ",T000Q2_A279COd_PROPIETARIO[0]);
               }
               if ( StringUtil.StrCmp(Z280NOM_PROPIETARIO, T000Q2_A280NOM_PROPIETARIO[0]) != 0 )
               {
                  GXUtil.WriteLog("frutapropia:[seudo value changed for attri]"+"NOM_PROPIETARIO");
                  GXUtil.WriteLogRaw("Old: ",Z280NOM_PROPIETARIO);
                  GXUtil.WriteLogRaw("Current: ",T000Q2_A280NOM_PROPIETARIO[0]);
               }
               if ( Z281TIPO != T000Q2_A281TIPO[0] )
               {
                  GXUtil.WriteLog("frutapropia:[seudo value changed for attri]"+"TIPO");
                  GXUtil.WriteLogRaw("Old: ",Z281TIPO);
                  GXUtil.WriteLogRaw("Current: ",T000Q2_A281TIPO[0]);
               }
               if ( StringUtil.StrCmp(Z282AGRUPACION, T000Q2_A282AGRUPACION[0]) != 0 )
               {
                  GXUtil.WriteLog("frutapropia:[seudo value changed for attri]"+"AGRUPACION");
                  GXUtil.WriteLogRaw("Old: ",Z282AGRUPACION);
                  GXUtil.WriteLogRaw("Current: ",T000Q2_A282AGRUPACION[0]);
               }
               if ( Z283VALOR_TRANSP_AP != T000Q2_A283VALOR_TRANSP_AP[0] )
               {
                  GXUtil.WriteLog("frutapropia:[seudo value changed for attri]"+"VALOR_TRANSP_AP");
                  GXUtil.WriteLogRaw("Old: ",Z283VALOR_TRANSP_AP);
                  GXUtil.WriteLogRaw("Current: ",T000Q2_A283VALOR_TRANSP_AP[0]);
               }
               if ( StringUtil.StrCmp(Z284HORA_SAI, T000Q2_A284HORA_SAI[0]) != 0 )
               {
                  GXUtil.WriteLog("frutapropia:[seudo value changed for attri]"+"HORA_SAI");
                  GXUtil.WriteLogRaw("Old: ",Z284HORA_SAI);
                  GXUtil.WriteLogRaw("Current: ",T000Q2_A284HORA_SAI[0]);
               }
               if ( StringUtil.StrCmp(Z285HORA_BRUTO, T000Q2_A285HORA_BRUTO[0]) != 0 )
               {
                  GXUtil.WriteLog("frutapropia:[seudo value changed for attri]"+"HORA_BRUTO");
                  GXUtil.WriteLogRaw("Old: ",Z285HORA_BRUTO);
                  GXUtil.WriteLogRaw("Current: ",T000Q2_A285HORA_BRUTO[0]);
               }
               if ( StringUtil.StrCmp(Z286LOTE_NOM, T000Q2_A286LOTE_NOM[0]) != 0 )
               {
                  GXUtil.WriteLog("frutapropia:[seudo value changed for attri]"+"LOTE_NOM");
                  GXUtil.WriteLogRaw("Old: ",Z286LOTE_NOM);
                  GXUtil.WriteLogRaw("Current: ",T000Q2_A286LOTE_NOM[0]);
               }
               if ( StringUtil.StrCmp(Z287TAL_DET, T000Q2_A287TAL_DET[0]) != 0 )
               {
                  GXUtil.WriteLog("frutapropia:[seudo value changed for attri]"+"TAL_DET");
                  GXUtil.WriteLogRaw("Old: ",Z287TAL_DET);
                  GXUtil.WriteLogRaw("Current: ",T000Q2_A287TAL_DET[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"FRUTAPROPIA"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0Q27( )
      {
         BeforeValidate0Q27( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Q27( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0Q27( 0) ;
            CheckOptimisticConcurrency0Q27( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Q27( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0Q27( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000Q12 */
                     pr_default.execute(10, new Object[] {A94FRUTAPROPIAFecha, A95FRUTAPROPIAMes, A96FRUTAPROPIAAno, A97VIAJE, A98SETOR, A99FINCA, A100PROVE_COD, A101DIA, A102LOTE, A103TAL, A267FINCA_nom, A268PROVE_NOM, A269CHOFER, A270CABEZAL, A271FH_ENT, A272FH_SAI, A273PESO, A274PESO_NETO, A275TARA, A276BRUTO, A277FORN_ASOCIADO, A278NOM_ASOCIADO, A279COd_PROPIETARIO, A280NOM_PROPIETARIO, A281TIPO, A282AGRUPACION, A283VALOR_TRANSP_AP, A284HORA_SAI, A285HORA_BRUTO, A286LOTE_NOM, A287TAL_DET, A4IndicadoresCodigo, A5Cod_Area});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("FRUTAPROPIA");
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
                           ResetCaption0Q0( ) ;
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
               Load0Q27( ) ;
            }
            EndLevel0Q27( ) ;
         }
         CloseExtendedTableCursors0Q27( ) ;
      }

      protected void Update0Q27( )
      {
         BeforeValidate0Q27( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Q27( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Q27( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Q27( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0Q27( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000Q13 */
                     pr_default.execute(11, new Object[] {A267FINCA_nom, A268PROVE_NOM, A269CHOFER, A270CABEZAL, A271FH_ENT, A272FH_SAI, A273PESO, A274PESO_NETO, A275TARA, A276BRUTO, A277FORN_ASOCIADO, A278NOM_ASOCIADO, A279COd_PROPIETARIO, A280NOM_PROPIETARIO, A281TIPO, A282AGRUPACION, A283VALOR_TRANSP_AP, A284HORA_SAI, A285HORA_BRUTO, A286LOTE_NOM, A287TAL_DET, A94FRUTAPROPIAFecha, A95FRUTAPROPIAMes, A96FRUTAPROPIAAno, A4IndicadoresCodigo, A5Cod_Area, A97VIAJE, A98SETOR, A99FINCA, A100PROVE_COD, A101DIA, A102LOTE, A103TAL});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("FRUTAPROPIA");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"FRUTAPROPIA"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0Q27( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0Q0( ) ;
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
            EndLevel0Q27( ) ;
         }
         CloseExtendedTableCursors0Q27( ) ;
      }

      protected void DeferredUpdate0Q27( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0Q27( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Q27( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0Q27( ) ;
            AfterConfirm0Q27( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0Q27( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000Q14 */
                  pr_default.execute(12, new Object[] {A94FRUTAPROPIAFecha, A95FRUTAPROPIAMes, A96FRUTAPROPIAAno, A4IndicadoresCodigo, A5Cod_Area, A97VIAJE, A98SETOR, A99FINCA, A100PROVE_COD, A101DIA, A102LOTE, A103TAL});
                  pr_default.close(12);
                  pr_default.SmartCacheProvider.SetUpdated("FRUTAPROPIA");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound27 == 0 )
                        {
                           InitAll0Q27( ) ;
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
                        ResetCaption0Q0( ) ;
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
         sMode27 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0Q27( ) ;
         Gx_mode = sMode27;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0Q27( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0Q27( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0Q27( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("frutapropia",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0Q0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("frutapropia",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0Q27( )
      {
         /* Using cursor T000Q15 */
         pr_default.execute(13);
         RcdFound27 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound27 = 1;
            A94FRUTAPROPIAFecha = T000Q15_A94FRUTAPROPIAFecha[0];
            AssignAttri("", false, "A94FRUTAPROPIAFecha", context.localUtil.Format(A94FRUTAPROPIAFecha, "99/99/99"));
            A95FRUTAPROPIAMes = T000Q15_A95FRUTAPROPIAMes[0];
            AssignAttri("", false, "A95FRUTAPROPIAMes", StringUtil.LTrimStr( (decimal)(A95FRUTAPROPIAMes), 4, 0));
            A96FRUTAPROPIAAno = T000Q15_A96FRUTAPROPIAAno[0];
            AssignAttri("", false, "A96FRUTAPROPIAAno", StringUtil.LTrimStr( (decimal)(A96FRUTAPROPIAAno), 4, 0));
            A4IndicadoresCodigo = T000Q15_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A5Cod_Area = T000Q15_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A97VIAJE = T000Q15_A97VIAJE[0];
            AssignAttri("", false, "A97VIAJE", StringUtil.LTrimStr( (decimal)(A97VIAJE), 12, 0));
            A98SETOR = T000Q15_A98SETOR[0];
            AssignAttri("", false, "A98SETOR", A98SETOR);
            A99FINCA = T000Q15_A99FINCA[0];
            AssignAttri("", false, "A99FINCA", A99FINCA);
            A100PROVE_COD = T000Q15_A100PROVE_COD[0];
            AssignAttri("", false, "A100PROVE_COD", A100PROVE_COD);
            A101DIA = T000Q15_A101DIA[0];
            AssignAttri("", false, "A101DIA", context.localUtil.TToC( A101DIA, 8, 5, 0, 3, "/", ":", " "));
            A102LOTE = T000Q15_A102LOTE[0];
            AssignAttri("", false, "A102LOTE", A102LOTE);
            A103TAL = T000Q15_A103TAL[0];
            AssignAttri("", false, "A103TAL", A103TAL);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0Q27( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound27 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound27 = 1;
            A94FRUTAPROPIAFecha = T000Q15_A94FRUTAPROPIAFecha[0];
            AssignAttri("", false, "A94FRUTAPROPIAFecha", context.localUtil.Format(A94FRUTAPROPIAFecha, "99/99/99"));
            A95FRUTAPROPIAMes = T000Q15_A95FRUTAPROPIAMes[0];
            AssignAttri("", false, "A95FRUTAPROPIAMes", StringUtil.LTrimStr( (decimal)(A95FRUTAPROPIAMes), 4, 0));
            A96FRUTAPROPIAAno = T000Q15_A96FRUTAPROPIAAno[0];
            AssignAttri("", false, "A96FRUTAPROPIAAno", StringUtil.LTrimStr( (decimal)(A96FRUTAPROPIAAno), 4, 0));
            A4IndicadoresCodigo = T000Q15_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A5Cod_Area = T000Q15_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A97VIAJE = T000Q15_A97VIAJE[0];
            AssignAttri("", false, "A97VIAJE", StringUtil.LTrimStr( (decimal)(A97VIAJE), 12, 0));
            A98SETOR = T000Q15_A98SETOR[0];
            AssignAttri("", false, "A98SETOR", A98SETOR);
            A99FINCA = T000Q15_A99FINCA[0];
            AssignAttri("", false, "A99FINCA", A99FINCA);
            A100PROVE_COD = T000Q15_A100PROVE_COD[0];
            AssignAttri("", false, "A100PROVE_COD", A100PROVE_COD);
            A101DIA = T000Q15_A101DIA[0];
            AssignAttri("", false, "A101DIA", context.localUtil.TToC( A101DIA, 8, 5, 0, 3, "/", ":", " "));
            A102LOTE = T000Q15_A102LOTE[0];
            AssignAttri("", false, "A102LOTE", A102LOTE);
            A103TAL = T000Q15_A103TAL[0];
            AssignAttri("", false, "A103TAL", A103TAL);
         }
      }

      protected void ScanEnd0Q27( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm0Q27( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0Q27( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0Q27( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0Q27( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0Q27( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0Q27( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0Q27( )
      {
         edtFRUTAPROPIAFecha_Enabled = 0;
         AssignProp("", false, edtFRUTAPROPIAFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFRUTAPROPIAFecha_Enabled), 5, 0), true);
         edtFRUTAPROPIAMes_Enabled = 0;
         AssignProp("", false, edtFRUTAPROPIAMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFRUTAPROPIAMes_Enabled), 5, 0), true);
         edtFRUTAPROPIAAno_Enabled = 0;
         AssignProp("", false, edtFRUTAPROPIAAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFRUTAPROPIAAno_Enabled), 5, 0), true);
         edtIndicadoresCodigo_Enabled = 0;
         AssignProp("", false, edtIndicadoresCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIndicadoresCodigo_Enabled), 5, 0), true);
         edtCod_Area_Enabled = 0;
         AssignProp("", false, edtCod_Area_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCod_Area_Enabled), 5, 0), true);
         edtVIAJE_Enabled = 0;
         AssignProp("", false, edtVIAJE_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVIAJE_Enabled), 5, 0), true);
         edtSETOR_Enabled = 0;
         AssignProp("", false, edtSETOR_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSETOR_Enabled), 5, 0), true);
         edtFINCA_Enabled = 0;
         AssignProp("", false, edtFINCA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFINCA_Enabled), 5, 0), true);
         edtFINCA_nom_Enabled = 0;
         AssignProp("", false, edtFINCA_nom_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFINCA_nom_Enabled), 5, 0), true);
         edtPROVE_COD_Enabled = 0;
         AssignProp("", false, edtPROVE_COD_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPROVE_COD_Enabled), 5, 0), true);
         edtPROVE_NOM_Enabled = 0;
         AssignProp("", false, edtPROVE_NOM_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPROVE_NOM_Enabled), 5, 0), true);
         edtDIA_Enabled = 0;
         AssignProp("", false, edtDIA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDIA_Enabled), 5, 0), true);
         edtCHOFER_Enabled = 0;
         AssignProp("", false, edtCHOFER_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCHOFER_Enabled), 5, 0), true);
         edtCABEZAL_Enabled = 0;
         AssignProp("", false, edtCABEZAL_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCABEZAL_Enabled), 5, 0), true);
         edtFH_ENT_Enabled = 0;
         AssignProp("", false, edtFH_ENT_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFH_ENT_Enabled), 5, 0), true);
         edtFH_SAI_Enabled = 0;
         AssignProp("", false, edtFH_SAI_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFH_SAI_Enabled), 5, 0), true);
         edtPESO_Enabled = 0;
         AssignProp("", false, edtPESO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPESO_Enabled), 5, 0), true);
         edtPESO_NETO_Enabled = 0;
         AssignProp("", false, edtPESO_NETO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPESO_NETO_Enabled), 5, 0), true);
         edtTARA_Enabled = 0;
         AssignProp("", false, edtTARA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTARA_Enabled), 5, 0), true);
         edtBRUTO_Enabled = 0;
         AssignProp("", false, edtBRUTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBRUTO_Enabled), 5, 0), true);
         edtFORN_ASOCIADO_Enabled = 0;
         AssignProp("", false, edtFORN_ASOCIADO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFORN_ASOCIADO_Enabled), 5, 0), true);
         edtNOM_ASOCIADO_Enabled = 0;
         AssignProp("", false, edtNOM_ASOCIADO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNOM_ASOCIADO_Enabled), 5, 0), true);
         edtCOd_PROPIETARIO_Enabled = 0;
         AssignProp("", false, edtCOd_PROPIETARIO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOd_PROPIETARIO_Enabled), 5, 0), true);
         edtNOM_PROPIETARIO_Enabled = 0;
         AssignProp("", false, edtNOM_PROPIETARIO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNOM_PROPIETARIO_Enabled), 5, 0), true);
         edtTIPO_Enabled = 0;
         AssignProp("", false, edtTIPO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTIPO_Enabled), 5, 0), true);
         edtAGRUPACION_Enabled = 0;
         AssignProp("", false, edtAGRUPACION_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAGRUPACION_Enabled), 5, 0), true);
         edtVALOR_TRANSP_AP_Enabled = 0;
         AssignProp("", false, edtVALOR_TRANSP_AP_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVALOR_TRANSP_AP_Enabled), 5, 0), true);
         edtHORA_SAI_Enabled = 0;
         AssignProp("", false, edtHORA_SAI_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHORA_SAI_Enabled), 5, 0), true);
         edtHORA_BRUTO_Enabled = 0;
         AssignProp("", false, edtHORA_BRUTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHORA_BRUTO_Enabled), 5, 0), true);
         edtLOTE_NOM_Enabled = 0;
         AssignProp("", false, edtLOTE_NOM_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLOTE_NOM_Enabled), 5, 0), true);
         edtLOTE_Enabled = 0;
         AssignProp("", false, edtLOTE_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLOTE_Enabled), 5, 0), true);
         edtTAL_Enabled = 0;
         AssignProp("", false, edtTAL_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTAL_Enabled), 5, 0), true);
         edtTAL_DET_Enabled = 0;
         AssignProp("", false, edtTAL_DET_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTAL_DET_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0Q27( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0Q0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("frutapropia.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z94FRUTAPROPIAFecha", context.localUtil.DToC( Z94FRUTAPROPIAFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z95FRUTAPROPIAMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z95FRUTAPROPIAMes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z96FRUTAPROPIAAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z96FRUTAPROPIAAno), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z4IndicadoresCodigo", Z4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "Z5Cod_Area", Z5Cod_Area);
         GxWebStd.gx_hidden_field( context, "Z97VIAJE", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z97VIAJE), 12, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z98SETOR", Z98SETOR);
         GxWebStd.gx_hidden_field( context, "Z99FINCA", Z99FINCA);
         GxWebStd.gx_hidden_field( context, "Z100PROVE_COD", Z100PROVE_COD);
         GxWebStd.gx_hidden_field( context, "Z101DIA", context.localUtil.TToC( Z101DIA, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z102LOTE", Z102LOTE);
         GxWebStd.gx_hidden_field( context, "Z103TAL", Z103TAL);
         GxWebStd.gx_hidden_field( context, "Z267FINCA_nom", Z267FINCA_nom);
         GxWebStd.gx_hidden_field( context, "Z268PROVE_NOM", Z268PROVE_NOM);
         GxWebStd.gx_hidden_field( context, "Z269CHOFER", Z269CHOFER);
         GxWebStd.gx_hidden_field( context, "Z270CABEZAL", Z270CABEZAL);
         GxWebStd.gx_hidden_field( context, "Z271FH_ENT", context.localUtil.DToC( Z271FH_ENT, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z272FH_SAI", context.localUtil.DToC( Z272FH_SAI, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z273PESO", StringUtil.LTrim( StringUtil.NToC( Z273PESO, 12, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z274PESO_NETO", StringUtil.LTrim( StringUtil.NToC( Z274PESO_NETO, 12, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z275TARA", StringUtil.LTrim( StringUtil.NToC( Z275TARA, 12, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z276BRUTO", StringUtil.LTrim( StringUtil.NToC( Z276BRUTO, 12, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z277FORN_ASOCIADO", Z277FORN_ASOCIADO);
         GxWebStd.gx_hidden_field( context, "Z278NOM_ASOCIADO", Z278NOM_ASOCIADO);
         GxWebStd.gx_hidden_field( context, "Z279COd_PROPIETARIO", Z279COd_PROPIETARIO);
         GxWebStd.gx_hidden_field( context, "Z280NOM_PROPIETARIO", Z280NOM_PROPIETARIO);
         GxWebStd.gx_hidden_field( context, "Z281TIPO", StringUtil.LTrim( StringUtil.NToC( Z281TIPO, 3, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z282AGRUPACION", Z282AGRUPACION);
         GxWebStd.gx_hidden_field( context, "Z283VALOR_TRANSP_AP", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z283VALOR_TRANSP_AP), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z284HORA_SAI", Z284HORA_SAI);
         GxWebStd.gx_hidden_field( context, "Z285HORA_BRUTO", Z285HORA_BRUTO);
         GxWebStd.gx_hidden_field( context, "Z286LOTE_NOM", Z286LOTE_NOM);
         GxWebStd.gx_hidden_field( context, "Z287TAL_DET", Z287TAL_DET);
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
         return formatLink("frutapropia.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "FRUTAPROPIA" ;
      }

      public override string GetPgmdesc( )
      {
         return "FRUTAPROPIA" ;
      }

      protected void InitializeNonKey0Q27( )
      {
         A267FINCA_nom = "";
         AssignAttri("", false, "A267FINCA_nom", A267FINCA_nom);
         A268PROVE_NOM = "";
         AssignAttri("", false, "A268PROVE_NOM", A268PROVE_NOM);
         A269CHOFER = "";
         AssignAttri("", false, "A269CHOFER", A269CHOFER);
         A270CABEZAL = "";
         AssignAttri("", false, "A270CABEZAL", A270CABEZAL);
         A271FH_ENT = DateTime.MinValue;
         AssignAttri("", false, "A271FH_ENT", context.localUtil.Format(A271FH_ENT, "99/99/99"));
         A272FH_SAI = DateTime.MinValue;
         AssignAttri("", false, "A272FH_SAI", context.localUtil.Format(A272FH_SAI, "99/99/99"));
         A273PESO = 0;
         AssignAttri("", false, "A273PESO", StringUtil.LTrimStr( A273PESO, 12, 2));
         A274PESO_NETO = 0;
         AssignAttri("", false, "A274PESO_NETO", StringUtil.LTrimStr( A274PESO_NETO, 12, 2));
         A275TARA = 0;
         AssignAttri("", false, "A275TARA", StringUtil.LTrimStr( A275TARA, 12, 2));
         A276BRUTO = 0;
         AssignAttri("", false, "A276BRUTO", StringUtil.LTrimStr( A276BRUTO, 12, 2));
         A277FORN_ASOCIADO = "";
         AssignAttri("", false, "A277FORN_ASOCIADO", A277FORN_ASOCIADO);
         A278NOM_ASOCIADO = "";
         AssignAttri("", false, "A278NOM_ASOCIADO", A278NOM_ASOCIADO);
         A279COd_PROPIETARIO = "";
         AssignAttri("", false, "A279COd_PROPIETARIO", A279COd_PROPIETARIO);
         A280NOM_PROPIETARIO = "";
         AssignAttri("", false, "A280NOM_PROPIETARIO", A280NOM_PROPIETARIO);
         A281TIPO = 0;
         AssignAttri("", false, "A281TIPO", StringUtil.LTrimStr( A281TIPO, 3, 2));
         A282AGRUPACION = "";
         AssignAttri("", false, "A282AGRUPACION", A282AGRUPACION);
         A283VALOR_TRANSP_AP = 0;
         AssignAttri("", false, "A283VALOR_TRANSP_AP", StringUtil.LTrimStr( (decimal)(A283VALOR_TRANSP_AP), 10, 0));
         A284HORA_SAI = "";
         AssignAttri("", false, "A284HORA_SAI", A284HORA_SAI);
         A285HORA_BRUTO = "";
         AssignAttri("", false, "A285HORA_BRUTO", A285HORA_BRUTO);
         A286LOTE_NOM = "";
         AssignAttri("", false, "A286LOTE_NOM", A286LOTE_NOM);
         A287TAL_DET = "";
         AssignAttri("", false, "A287TAL_DET", A287TAL_DET);
         Z267FINCA_nom = "";
         Z268PROVE_NOM = "";
         Z269CHOFER = "";
         Z270CABEZAL = "";
         Z271FH_ENT = DateTime.MinValue;
         Z272FH_SAI = DateTime.MinValue;
         Z273PESO = 0;
         Z274PESO_NETO = 0;
         Z275TARA = 0;
         Z276BRUTO = 0;
         Z277FORN_ASOCIADO = "";
         Z278NOM_ASOCIADO = "";
         Z279COd_PROPIETARIO = "";
         Z280NOM_PROPIETARIO = "";
         Z281TIPO = 0;
         Z282AGRUPACION = "";
         Z283VALOR_TRANSP_AP = 0;
         Z284HORA_SAI = "";
         Z285HORA_BRUTO = "";
         Z286LOTE_NOM = "";
         Z287TAL_DET = "";
      }

      protected void InitAll0Q27( )
      {
         A94FRUTAPROPIAFecha = DateTime.MinValue;
         AssignAttri("", false, "A94FRUTAPROPIAFecha", context.localUtil.Format(A94FRUTAPROPIAFecha, "99/99/99"));
         A95FRUTAPROPIAMes = 0;
         AssignAttri("", false, "A95FRUTAPROPIAMes", StringUtil.LTrimStr( (decimal)(A95FRUTAPROPIAMes), 4, 0));
         A96FRUTAPROPIAAno = 0;
         AssignAttri("", false, "A96FRUTAPROPIAAno", StringUtil.LTrimStr( (decimal)(A96FRUTAPROPIAAno), 4, 0));
         A4IndicadoresCodigo = "";
         AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
         A5Cod_Area = "";
         AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
         A97VIAJE = 0;
         AssignAttri("", false, "A97VIAJE", StringUtil.LTrimStr( (decimal)(A97VIAJE), 12, 0));
         A98SETOR = "";
         AssignAttri("", false, "A98SETOR", A98SETOR);
         A99FINCA = "";
         AssignAttri("", false, "A99FINCA", A99FINCA);
         A100PROVE_COD = "";
         AssignAttri("", false, "A100PROVE_COD", A100PROVE_COD);
         A101DIA = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A101DIA", context.localUtil.TToC( A101DIA, 8, 5, 0, 3, "/", ":", " "));
         A102LOTE = "";
         AssignAttri("", false, "A102LOTE", A102LOTE);
         A103TAL = "";
         AssignAttri("", false, "A103TAL", A103TAL);
         InitializeNonKey0Q27( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024723102373", true, true);
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
         context.AddJavascriptSource("frutapropia.js", "?2024723102373", false, true);
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
         edtFRUTAPROPIAFecha_Internalname = "FRUTAPROPIAFECHA";
         edtFRUTAPROPIAMes_Internalname = "FRUTAPROPIAMES";
         edtFRUTAPROPIAAno_Internalname = "FRUTAPROPIAANO";
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO";
         edtCod_Area_Internalname = "COD_AREA";
         edtVIAJE_Internalname = "VIAJE";
         edtSETOR_Internalname = "SETOR";
         edtFINCA_Internalname = "FINCA";
         edtFINCA_nom_Internalname = "FINCA_NOM";
         edtPROVE_COD_Internalname = "PROVE_COD";
         edtPROVE_NOM_Internalname = "PROVE_NOM";
         edtDIA_Internalname = "DIA";
         edtCHOFER_Internalname = "CHOFER";
         edtCABEZAL_Internalname = "CABEZAL";
         edtFH_ENT_Internalname = "FH_ENT";
         edtFH_SAI_Internalname = "FH_SAI";
         edtPESO_Internalname = "PESO";
         edtPESO_NETO_Internalname = "PESO_NETO";
         edtTARA_Internalname = "TARA";
         edtBRUTO_Internalname = "BRUTO";
         edtFORN_ASOCIADO_Internalname = "FORN_ASOCIADO";
         edtNOM_ASOCIADO_Internalname = "NOM_ASOCIADO";
         edtCOd_PROPIETARIO_Internalname = "COD_PROPIETARIO";
         edtNOM_PROPIETARIO_Internalname = "NOM_PROPIETARIO";
         edtTIPO_Internalname = "TIPO";
         edtAGRUPACION_Internalname = "AGRUPACION";
         edtVALOR_TRANSP_AP_Internalname = "VALOR_TRANSP_AP";
         edtHORA_SAI_Internalname = "HORA_SAI";
         edtHORA_BRUTO_Internalname = "HORA_BRUTO";
         edtLOTE_NOM_Internalname = "LOTE_NOM";
         edtLOTE_Internalname = "LOTE";
         edtTAL_Internalname = "TAL";
         edtTAL_DET_Internalname = "TAL_DET";
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
         Form.Caption = "FRUTAPROPIA";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtTAL_DET_Jsonclick = "";
         edtTAL_DET_Enabled = 1;
         edtTAL_Jsonclick = "";
         edtTAL_Enabled = 1;
         edtLOTE_Jsonclick = "";
         edtLOTE_Enabled = 1;
         edtLOTE_NOM_Jsonclick = "";
         edtLOTE_NOM_Enabled = 1;
         edtHORA_BRUTO_Jsonclick = "";
         edtHORA_BRUTO_Enabled = 1;
         edtHORA_SAI_Jsonclick = "";
         edtHORA_SAI_Enabled = 1;
         edtVALOR_TRANSP_AP_Jsonclick = "";
         edtVALOR_TRANSP_AP_Enabled = 1;
         edtAGRUPACION_Jsonclick = "";
         edtAGRUPACION_Enabled = 1;
         edtTIPO_Jsonclick = "";
         edtTIPO_Enabled = 1;
         edtNOM_PROPIETARIO_Enabled = 1;
         edtCOd_PROPIETARIO_Enabled = 1;
         edtNOM_ASOCIADO_Enabled = 1;
         edtFORN_ASOCIADO_Jsonclick = "";
         edtFORN_ASOCIADO_Enabled = 1;
         edtBRUTO_Jsonclick = "";
         edtBRUTO_Enabled = 1;
         edtTARA_Jsonclick = "";
         edtTARA_Enabled = 1;
         edtPESO_NETO_Jsonclick = "";
         edtPESO_NETO_Enabled = 1;
         edtPESO_Jsonclick = "";
         edtPESO_Enabled = 1;
         edtFH_SAI_Jsonclick = "";
         edtFH_SAI_Enabled = 1;
         edtFH_ENT_Jsonclick = "";
         edtFH_ENT_Enabled = 1;
         edtCABEZAL_Jsonclick = "";
         edtCABEZAL_Enabled = 1;
         edtCHOFER_Jsonclick = "";
         edtCHOFER_Enabled = 1;
         edtDIA_Jsonclick = "";
         edtDIA_Enabled = 1;
         edtPROVE_NOM_Jsonclick = "";
         edtPROVE_NOM_Enabled = 1;
         edtPROVE_COD_Jsonclick = "";
         edtPROVE_COD_Enabled = 1;
         edtFINCA_nom_Jsonclick = "";
         edtFINCA_nom_Enabled = 1;
         edtFINCA_Jsonclick = "";
         edtFINCA_Enabled = 1;
         edtSETOR_Jsonclick = "";
         edtSETOR_Enabled = 1;
         edtVIAJE_Jsonclick = "";
         edtVIAJE_Enabled = 1;
         imgprompt_5_Visible = 1;
         imgprompt_5_Link = "";
         edtCod_Area_Jsonclick = "";
         edtCod_Area_Enabled = 1;
         imgprompt_4_Visible = 1;
         imgprompt_4_Link = "";
         edtIndicadoresCodigo_Jsonclick = "";
         edtIndicadoresCodigo_Enabled = 1;
         edtFRUTAPROPIAAno_Jsonclick = "";
         edtFRUTAPROPIAAno_Enabled = 1;
         edtFRUTAPROPIAMes_Jsonclick = "";
         edtFRUTAPROPIAMes_Enabled = 1;
         edtFRUTAPROPIAFecha_Jsonclick = "";
         edtFRUTAPROPIAFecha_Enabled = 1;
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
         /* Using cursor T000Q16 */
         pr_default.execute(14, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(14);
         /* Using cursor T000Q17 */
         pr_default.execute(15, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(15);
         GX_FocusControl = edtFINCA_nom_Internalname;
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
         /* Using cursor T000Q16 */
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
         /* Using cursor T000Q17 */
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
      }

      public void Valid_Tal( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A267FINCA_nom", A267FINCA_nom);
         AssignAttri("", false, "A268PROVE_NOM", A268PROVE_NOM);
         AssignAttri("", false, "A269CHOFER", A269CHOFER);
         AssignAttri("", false, "A270CABEZAL", A270CABEZAL);
         AssignAttri("", false, "A271FH_ENT", context.localUtil.Format(A271FH_ENT, "99/99/99"));
         AssignAttri("", false, "A272FH_SAI", context.localUtil.Format(A272FH_SAI, "99/99/99"));
         AssignAttri("", false, "A273PESO", StringUtil.LTrim( StringUtil.NToC( A273PESO, 12, 2, ".", "")));
         AssignAttri("", false, "A274PESO_NETO", StringUtil.LTrim( StringUtil.NToC( A274PESO_NETO, 12, 2, ".", "")));
         AssignAttri("", false, "A275TARA", StringUtil.LTrim( StringUtil.NToC( A275TARA, 12, 2, ".", "")));
         AssignAttri("", false, "A276BRUTO", StringUtil.LTrim( StringUtil.NToC( A276BRUTO, 12, 2, ".", "")));
         AssignAttri("", false, "A277FORN_ASOCIADO", A277FORN_ASOCIADO);
         AssignAttri("", false, "A278NOM_ASOCIADO", A278NOM_ASOCIADO);
         AssignAttri("", false, "A279COd_PROPIETARIO", A279COd_PROPIETARIO);
         AssignAttri("", false, "A280NOM_PROPIETARIO", A280NOM_PROPIETARIO);
         AssignAttri("", false, "A281TIPO", StringUtil.LTrim( StringUtil.NToC( A281TIPO, 3, 2, ".", "")));
         AssignAttri("", false, "A282AGRUPACION", A282AGRUPACION);
         AssignAttri("", false, "A283VALOR_TRANSP_AP", StringUtil.LTrim( StringUtil.NToC( (decimal)(A283VALOR_TRANSP_AP), 10, 0, ".", "")));
         AssignAttri("", false, "A284HORA_SAI", A284HORA_SAI);
         AssignAttri("", false, "A285HORA_BRUTO", A285HORA_BRUTO);
         AssignAttri("", false, "A286LOTE_NOM", A286LOTE_NOM);
         AssignAttri("", false, "A287TAL_DET", A287TAL_DET);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z94FRUTAPROPIAFecha", context.localUtil.Format(Z94FRUTAPROPIAFecha, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z95FRUTAPROPIAMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z95FRUTAPROPIAMes), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z96FRUTAPROPIAAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z96FRUTAPROPIAAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z4IndicadoresCodigo", Z4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "Z5Cod_Area", Z5Cod_Area);
         GxWebStd.gx_hidden_field( context, "Z97VIAJE", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z97VIAJE), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z98SETOR", Z98SETOR);
         GxWebStd.gx_hidden_field( context, "Z99FINCA", Z99FINCA);
         GxWebStd.gx_hidden_field( context, "Z100PROVE_COD", Z100PROVE_COD);
         GxWebStd.gx_hidden_field( context, "Z101DIA", context.localUtil.TToC( Z101DIA, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z102LOTE", Z102LOTE);
         GxWebStd.gx_hidden_field( context, "Z103TAL", Z103TAL);
         GxWebStd.gx_hidden_field( context, "Z267FINCA_nom", Z267FINCA_nom);
         GxWebStd.gx_hidden_field( context, "Z268PROVE_NOM", Z268PROVE_NOM);
         GxWebStd.gx_hidden_field( context, "Z269CHOFER", Z269CHOFER);
         GxWebStd.gx_hidden_field( context, "Z270CABEZAL", Z270CABEZAL);
         GxWebStd.gx_hidden_field( context, "Z271FH_ENT", context.localUtil.Format(Z271FH_ENT, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z272FH_SAI", context.localUtil.Format(Z272FH_SAI, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z273PESO", StringUtil.LTrim( StringUtil.NToC( Z273PESO, 12, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z274PESO_NETO", StringUtil.LTrim( StringUtil.NToC( Z274PESO_NETO, 12, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z275TARA", StringUtil.LTrim( StringUtil.NToC( Z275TARA, 12, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z276BRUTO", StringUtil.LTrim( StringUtil.NToC( Z276BRUTO, 12, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z277FORN_ASOCIADO", Z277FORN_ASOCIADO);
         GxWebStd.gx_hidden_field( context, "Z278NOM_ASOCIADO", Z278NOM_ASOCIADO);
         GxWebStd.gx_hidden_field( context, "Z279COd_PROPIETARIO", Z279COd_PROPIETARIO);
         GxWebStd.gx_hidden_field( context, "Z280NOM_PROPIETARIO", Z280NOM_PROPIETARIO);
         GxWebStd.gx_hidden_field( context, "Z281TIPO", StringUtil.LTrim( StringUtil.NToC( Z281TIPO, 3, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z282AGRUPACION", Z282AGRUPACION);
         GxWebStd.gx_hidden_field( context, "Z283VALOR_TRANSP_AP", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z283VALOR_TRANSP_AP), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z284HORA_SAI", Z284HORA_SAI);
         GxWebStd.gx_hidden_field( context, "Z285HORA_BRUTO", Z285HORA_BRUTO);
         GxWebStd.gx_hidden_field( context, "Z286LOTE_NOM", Z286LOTE_NOM);
         GxWebStd.gx_hidden_field( context, "Z287TAL_DET", Z287TAL_DET);
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
         setEventMetadata("VALID_FRUTAPROPIAFECHA","{handler:'Valid_Frutapropiafecha',iparms:[]");
         setEventMetadata("VALID_FRUTAPROPIAFECHA",",oparms:[]}");
         setEventMetadata("VALID_FRUTAPROPIAMES","{handler:'Valid_Frutapropiames',iparms:[]");
         setEventMetadata("VALID_FRUTAPROPIAMES",",oparms:[]}");
         setEventMetadata("VALID_FRUTAPROPIAANO","{handler:'Valid_Frutapropiaano',iparms:[]");
         setEventMetadata("VALID_FRUTAPROPIAANO",",oparms:[]}");
         setEventMetadata("VALID_INDICADORESCODIGO","{handler:'Valid_Indicadorescodigo',iparms:[{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:''}]");
         setEventMetadata("VALID_INDICADORESCODIGO",",oparms:[]}");
         setEventMetadata("VALID_COD_AREA","{handler:'Valid_Cod_area',iparms:[{av:'A5Cod_Area',fld:'COD_AREA',pic:''}]");
         setEventMetadata("VALID_COD_AREA",",oparms:[]}");
         setEventMetadata("VALID_VIAJE","{handler:'Valid_Viaje',iparms:[]");
         setEventMetadata("VALID_VIAJE",",oparms:[]}");
         setEventMetadata("VALID_SETOR","{handler:'Valid_Setor',iparms:[]");
         setEventMetadata("VALID_SETOR",",oparms:[]}");
         setEventMetadata("VALID_FINCA","{handler:'Valid_Finca',iparms:[]");
         setEventMetadata("VALID_FINCA",",oparms:[]}");
         setEventMetadata("VALID_PROVE_COD","{handler:'Valid_Prove_cod',iparms:[]");
         setEventMetadata("VALID_PROVE_COD",",oparms:[]}");
         setEventMetadata("VALID_DIA","{handler:'Valid_Dia',iparms:[]");
         setEventMetadata("VALID_DIA",",oparms:[]}");
         setEventMetadata("VALID_FH_ENT","{handler:'Valid_Fh_ent',iparms:[]");
         setEventMetadata("VALID_FH_ENT",",oparms:[]}");
         setEventMetadata("VALID_FH_SAI","{handler:'Valid_Fh_sai',iparms:[]");
         setEventMetadata("VALID_FH_SAI",",oparms:[]}");
         setEventMetadata("VALID_LOTE","{handler:'Valid_Lote',iparms:[]");
         setEventMetadata("VALID_LOTE",",oparms:[]}");
         setEventMetadata("VALID_TAL","{handler:'Valid_Tal',iparms:[{av:'A94FRUTAPROPIAFecha',fld:'FRUTAPROPIAFECHA',pic:''},{av:'A95FRUTAPROPIAMes',fld:'FRUTAPROPIAMES',pic:'ZZZ9'},{av:'A96FRUTAPROPIAAno',fld:'FRUTAPROPIAANO',pic:'ZZZ9'},{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:''},{av:'A5Cod_Area',fld:'COD_AREA',pic:''},{av:'A97VIAJE',fld:'VIAJE',pic:'ZZZZZZZZZZZ9'},{av:'A98SETOR',fld:'SETOR',pic:''},{av:'A99FINCA',fld:'FINCA',pic:''},{av:'A100PROVE_COD',fld:'PROVE_COD',pic:''},{av:'A101DIA',fld:'DIA',pic:'99/99/99 99:99'},{av:'A102LOTE',fld:'LOTE',pic:''},{av:'A103TAL',fld:'TAL',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_TAL",",oparms:[{av:'A267FINCA_nom',fld:'FINCA_NOM',pic:''},{av:'A268PROVE_NOM',fld:'PROVE_NOM',pic:''},{av:'A269CHOFER',fld:'CHOFER',pic:''},{av:'A270CABEZAL',fld:'CABEZAL',pic:''},{av:'A271FH_ENT',fld:'FH_ENT',pic:''},{av:'A272FH_SAI',fld:'FH_SAI',pic:''},{av:'A273PESO',fld:'PESO',pic:'ZZZZZZZZ9.99'},{av:'A274PESO_NETO',fld:'PESO_NETO',pic:'ZZZZZZZZ9.99'},{av:'A275TARA',fld:'TARA',pic:'ZZZZZZZZ9.99'},{av:'A276BRUTO',fld:'BRUTO',pic:'ZZZZZZZZ9.99'},{av:'A277FORN_ASOCIADO',fld:'FORN_ASOCIADO',pic:''},{av:'A278NOM_ASOCIADO',fld:'NOM_ASOCIADO',pic:''},{av:'A279COd_PROPIETARIO',fld:'COD_PROPIETARIO',pic:''},{av:'A280NOM_PROPIETARIO',fld:'NOM_PROPIETARIO',pic:''},{av:'A281TIPO',fld:'TIPO',pic:'9.99'},{av:'A282AGRUPACION',fld:'AGRUPACION',pic:''},{av:'A283VALOR_TRANSP_AP',fld:'VALOR_TRANSP_AP',pic:'ZZZZZZZZZ9'},{av:'A284HORA_SAI',fld:'HORA_SAI',pic:''},{av:'A285HORA_BRUTO',fld:'HORA_BRUTO',pic:''},{av:'A286LOTE_NOM',fld:'LOTE_NOM',pic:''},{av:'A287TAL_DET',fld:'TAL_DET',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z94FRUTAPROPIAFecha'},{av:'Z95FRUTAPROPIAMes'},{av:'Z96FRUTAPROPIAAno'},{av:'Z4IndicadoresCodigo'},{av:'Z5Cod_Area'},{av:'Z97VIAJE'},{av:'Z98SETOR'},{av:'Z99FINCA'},{av:'Z100PROVE_COD'},{av:'Z101DIA'},{av:'Z102LOTE'},{av:'Z103TAL'},{av:'Z267FINCA_nom'},{av:'Z268PROVE_NOM'},{av:'Z269CHOFER'},{av:'Z270CABEZAL'},{av:'Z271FH_ENT'},{av:'Z272FH_SAI'},{av:'Z273PESO'},{av:'Z274PESO_NETO'},{av:'Z275TARA'},{av:'Z276BRUTO'},{av:'Z277FORN_ASOCIADO'},{av:'Z278NOM_ASOCIADO'},{av:'Z279COd_PROPIETARIO'},{av:'Z280NOM_PROPIETARIO'},{av:'Z281TIPO'},{av:'Z282AGRUPACION'},{av:'Z283VALOR_TRANSP_AP'},{av:'Z284HORA_SAI'},{av:'Z285HORA_BRUTO'},{av:'Z286LOTE_NOM'},{av:'Z287TAL_DET'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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
         Z94FRUTAPROPIAFecha = DateTime.MinValue;
         Z4IndicadoresCodigo = "";
         Z5Cod_Area = "";
         Z98SETOR = "";
         Z99FINCA = "";
         Z100PROVE_COD = "";
         Z101DIA = (DateTime)(DateTime.MinValue);
         Z102LOTE = "";
         Z103TAL = "";
         Z267FINCA_nom = "";
         Z268PROVE_NOM = "";
         Z269CHOFER = "";
         Z270CABEZAL = "";
         Z271FH_ENT = DateTime.MinValue;
         Z272FH_SAI = DateTime.MinValue;
         Z277FORN_ASOCIADO = "";
         Z278NOM_ASOCIADO = "";
         Z279COd_PROPIETARIO = "";
         Z280NOM_PROPIETARIO = "";
         Z282AGRUPACION = "";
         Z284HORA_SAI = "";
         Z285HORA_BRUTO = "";
         Z286LOTE_NOM = "";
         Z287TAL_DET = "";
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
         A94FRUTAPROPIAFecha = DateTime.MinValue;
         imgprompt_4_gximage = "";
         sImgUrl = "";
         imgprompt_5_gximage = "";
         A98SETOR = "";
         A99FINCA = "";
         A267FINCA_nom = "";
         A100PROVE_COD = "";
         A268PROVE_NOM = "";
         A101DIA = (DateTime)(DateTime.MinValue);
         A269CHOFER = "";
         A270CABEZAL = "";
         A271FH_ENT = DateTime.MinValue;
         A272FH_SAI = DateTime.MinValue;
         A277FORN_ASOCIADO = "";
         A278NOM_ASOCIADO = "";
         A279COd_PROPIETARIO = "";
         A280NOM_PROPIETARIO = "";
         A282AGRUPACION = "";
         A284HORA_SAI = "";
         A285HORA_BRUTO = "";
         A286LOTE_NOM = "";
         A102LOTE = "";
         A103TAL = "";
         A287TAL_DET = "";
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
         T000Q6_A94FRUTAPROPIAFecha = new DateTime[] {DateTime.MinValue} ;
         T000Q6_A95FRUTAPROPIAMes = new short[1] ;
         T000Q6_A96FRUTAPROPIAAno = new short[1] ;
         T000Q6_A97VIAJE = new long[1] ;
         T000Q6_A98SETOR = new string[] {""} ;
         T000Q6_A99FINCA = new string[] {""} ;
         T000Q6_A100PROVE_COD = new string[] {""} ;
         T000Q6_A101DIA = new DateTime[] {DateTime.MinValue} ;
         T000Q6_A102LOTE = new string[] {""} ;
         T000Q6_A103TAL = new string[] {""} ;
         T000Q6_A267FINCA_nom = new string[] {""} ;
         T000Q6_A268PROVE_NOM = new string[] {""} ;
         T000Q6_A269CHOFER = new string[] {""} ;
         T000Q6_A270CABEZAL = new string[] {""} ;
         T000Q6_A271FH_ENT = new DateTime[] {DateTime.MinValue} ;
         T000Q6_A272FH_SAI = new DateTime[] {DateTime.MinValue} ;
         T000Q6_A273PESO = new decimal[1] ;
         T000Q6_A274PESO_NETO = new decimal[1] ;
         T000Q6_A275TARA = new decimal[1] ;
         T000Q6_A276BRUTO = new decimal[1] ;
         T000Q6_A277FORN_ASOCIADO = new string[] {""} ;
         T000Q6_A278NOM_ASOCIADO = new string[] {""} ;
         T000Q6_A279COd_PROPIETARIO = new string[] {""} ;
         T000Q6_A280NOM_PROPIETARIO = new string[] {""} ;
         T000Q6_A281TIPO = new decimal[1] ;
         T000Q6_A282AGRUPACION = new string[] {""} ;
         T000Q6_A283VALOR_TRANSP_AP = new long[1] ;
         T000Q6_A284HORA_SAI = new string[] {""} ;
         T000Q6_A285HORA_BRUTO = new string[] {""} ;
         T000Q6_A286LOTE_NOM = new string[] {""} ;
         T000Q6_A287TAL_DET = new string[] {""} ;
         T000Q6_A4IndicadoresCodigo = new string[] {""} ;
         T000Q6_A5Cod_Area = new string[] {""} ;
         T000Q4_A4IndicadoresCodigo = new string[] {""} ;
         T000Q5_A5Cod_Area = new string[] {""} ;
         T000Q7_A4IndicadoresCodigo = new string[] {""} ;
         T000Q8_A5Cod_Area = new string[] {""} ;
         T000Q9_A94FRUTAPROPIAFecha = new DateTime[] {DateTime.MinValue} ;
         T000Q9_A95FRUTAPROPIAMes = new short[1] ;
         T000Q9_A96FRUTAPROPIAAno = new short[1] ;
         T000Q9_A4IndicadoresCodigo = new string[] {""} ;
         T000Q9_A5Cod_Area = new string[] {""} ;
         T000Q9_A97VIAJE = new long[1] ;
         T000Q9_A98SETOR = new string[] {""} ;
         T000Q9_A99FINCA = new string[] {""} ;
         T000Q9_A100PROVE_COD = new string[] {""} ;
         T000Q9_A101DIA = new DateTime[] {DateTime.MinValue} ;
         T000Q9_A102LOTE = new string[] {""} ;
         T000Q9_A103TAL = new string[] {""} ;
         T000Q3_A94FRUTAPROPIAFecha = new DateTime[] {DateTime.MinValue} ;
         T000Q3_A95FRUTAPROPIAMes = new short[1] ;
         T000Q3_A96FRUTAPROPIAAno = new short[1] ;
         T000Q3_A97VIAJE = new long[1] ;
         T000Q3_A98SETOR = new string[] {""} ;
         T000Q3_A99FINCA = new string[] {""} ;
         T000Q3_A100PROVE_COD = new string[] {""} ;
         T000Q3_A101DIA = new DateTime[] {DateTime.MinValue} ;
         T000Q3_A102LOTE = new string[] {""} ;
         T000Q3_A103TAL = new string[] {""} ;
         T000Q3_A267FINCA_nom = new string[] {""} ;
         T000Q3_A268PROVE_NOM = new string[] {""} ;
         T000Q3_A269CHOFER = new string[] {""} ;
         T000Q3_A270CABEZAL = new string[] {""} ;
         T000Q3_A271FH_ENT = new DateTime[] {DateTime.MinValue} ;
         T000Q3_A272FH_SAI = new DateTime[] {DateTime.MinValue} ;
         T000Q3_A273PESO = new decimal[1] ;
         T000Q3_A274PESO_NETO = new decimal[1] ;
         T000Q3_A275TARA = new decimal[1] ;
         T000Q3_A276BRUTO = new decimal[1] ;
         T000Q3_A277FORN_ASOCIADO = new string[] {""} ;
         T000Q3_A278NOM_ASOCIADO = new string[] {""} ;
         T000Q3_A279COd_PROPIETARIO = new string[] {""} ;
         T000Q3_A280NOM_PROPIETARIO = new string[] {""} ;
         T000Q3_A281TIPO = new decimal[1] ;
         T000Q3_A282AGRUPACION = new string[] {""} ;
         T000Q3_A283VALOR_TRANSP_AP = new long[1] ;
         T000Q3_A284HORA_SAI = new string[] {""} ;
         T000Q3_A285HORA_BRUTO = new string[] {""} ;
         T000Q3_A286LOTE_NOM = new string[] {""} ;
         T000Q3_A287TAL_DET = new string[] {""} ;
         T000Q3_A4IndicadoresCodigo = new string[] {""} ;
         T000Q3_A5Cod_Area = new string[] {""} ;
         sMode27 = "";
         T000Q10_A94FRUTAPROPIAFecha = new DateTime[] {DateTime.MinValue} ;
         T000Q10_A95FRUTAPROPIAMes = new short[1] ;
         T000Q10_A96FRUTAPROPIAAno = new short[1] ;
         T000Q10_A4IndicadoresCodigo = new string[] {""} ;
         T000Q10_A5Cod_Area = new string[] {""} ;
         T000Q10_A97VIAJE = new long[1] ;
         T000Q10_A98SETOR = new string[] {""} ;
         T000Q10_A99FINCA = new string[] {""} ;
         T000Q10_A100PROVE_COD = new string[] {""} ;
         T000Q10_A101DIA = new DateTime[] {DateTime.MinValue} ;
         T000Q10_A102LOTE = new string[] {""} ;
         T000Q10_A103TAL = new string[] {""} ;
         T000Q11_A94FRUTAPROPIAFecha = new DateTime[] {DateTime.MinValue} ;
         T000Q11_A95FRUTAPROPIAMes = new short[1] ;
         T000Q11_A96FRUTAPROPIAAno = new short[1] ;
         T000Q11_A4IndicadoresCodigo = new string[] {""} ;
         T000Q11_A5Cod_Area = new string[] {""} ;
         T000Q11_A97VIAJE = new long[1] ;
         T000Q11_A98SETOR = new string[] {""} ;
         T000Q11_A99FINCA = new string[] {""} ;
         T000Q11_A100PROVE_COD = new string[] {""} ;
         T000Q11_A101DIA = new DateTime[] {DateTime.MinValue} ;
         T000Q11_A102LOTE = new string[] {""} ;
         T000Q11_A103TAL = new string[] {""} ;
         T000Q2_A94FRUTAPROPIAFecha = new DateTime[] {DateTime.MinValue} ;
         T000Q2_A95FRUTAPROPIAMes = new short[1] ;
         T000Q2_A96FRUTAPROPIAAno = new short[1] ;
         T000Q2_A97VIAJE = new long[1] ;
         T000Q2_A98SETOR = new string[] {""} ;
         T000Q2_A99FINCA = new string[] {""} ;
         T000Q2_A100PROVE_COD = new string[] {""} ;
         T000Q2_A101DIA = new DateTime[] {DateTime.MinValue} ;
         T000Q2_A102LOTE = new string[] {""} ;
         T000Q2_A103TAL = new string[] {""} ;
         T000Q2_A267FINCA_nom = new string[] {""} ;
         T000Q2_A268PROVE_NOM = new string[] {""} ;
         T000Q2_A269CHOFER = new string[] {""} ;
         T000Q2_A270CABEZAL = new string[] {""} ;
         T000Q2_A271FH_ENT = new DateTime[] {DateTime.MinValue} ;
         T000Q2_A272FH_SAI = new DateTime[] {DateTime.MinValue} ;
         T000Q2_A273PESO = new decimal[1] ;
         T000Q2_A274PESO_NETO = new decimal[1] ;
         T000Q2_A275TARA = new decimal[1] ;
         T000Q2_A276BRUTO = new decimal[1] ;
         T000Q2_A277FORN_ASOCIADO = new string[] {""} ;
         T000Q2_A278NOM_ASOCIADO = new string[] {""} ;
         T000Q2_A279COd_PROPIETARIO = new string[] {""} ;
         T000Q2_A280NOM_PROPIETARIO = new string[] {""} ;
         T000Q2_A281TIPO = new decimal[1] ;
         T000Q2_A282AGRUPACION = new string[] {""} ;
         T000Q2_A283VALOR_TRANSP_AP = new long[1] ;
         T000Q2_A284HORA_SAI = new string[] {""} ;
         T000Q2_A285HORA_BRUTO = new string[] {""} ;
         T000Q2_A286LOTE_NOM = new string[] {""} ;
         T000Q2_A287TAL_DET = new string[] {""} ;
         T000Q2_A4IndicadoresCodigo = new string[] {""} ;
         T000Q2_A5Cod_Area = new string[] {""} ;
         T000Q15_A94FRUTAPROPIAFecha = new DateTime[] {DateTime.MinValue} ;
         T000Q15_A95FRUTAPROPIAMes = new short[1] ;
         T000Q15_A96FRUTAPROPIAAno = new short[1] ;
         T000Q15_A4IndicadoresCodigo = new string[] {""} ;
         T000Q15_A5Cod_Area = new string[] {""} ;
         T000Q15_A97VIAJE = new long[1] ;
         T000Q15_A98SETOR = new string[] {""} ;
         T000Q15_A99FINCA = new string[] {""} ;
         T000Q15_A100PROVE_COD = new string[] {""} ;
         T000Q15_A101DIA = new DateTime[] {DateTime.MinValue} ;
         T000Q15_A102LOTE = new string[] {""} ;
         T000Q15_A103TAL = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T000Q16_A4IndicadoresCodigo = new string[] {""} ;
         T000Q17_A5Cod_Area = new string[] {""} ;
         ZZ94FRUTAPROPIAFecha = DateTime.MinValue;
         ZZ4IndicadoresCodigo = "";
         ZZ5Cod_Area = "";
         ZZ98SETOR = "";
         ZZ99FINCA = "";
         ZZ100PROVE_COD = "";
         ZZ101DIA = (DateTime)(DateTime.MinValue);
         ZZ102LOTE = "";
         ZZ103TAL = "";
         ZZ267FINCA_nom = "";
         ZZ268PROVE_NOM = "";
         ZZ269CHOFER = "";
         ZZ270CABEZAL = "";
         ZZ271FH_ENT = DateTime.MinValue;
         ZZ272FH_SAI = DateTime.MinValue;
         ZZ277FORN_ASOCIADO = "";
         ZZ278NOM_ASOCIADO = "";
         ZZ279COd_PROPIETARIO = "";
         ZZ280NOM_PROPIETARIO = "";
         ZZ282AGRUPACION = "";
         ZZ284HORA_SAI = "";
         ZZ285HORA_BRUTO = "";
         ZZ286LOTE_NOM = "";
         ZZ287TAL_DET = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.frutapropia__default(),
            new Object[][] {
                new Object[] {
               T000Q2_A94FRUTAPROPIAFecha, T000Q2_A95FRUTAPROPIAMes, T000Q2_A96FRUTAPROPIAAno, T000Q2_A97VIAJE, T000Q2_A98SETOR, T000Q2_A99FINCA, T000Q2_A100PROVE_COD, T000Q2_A101DIA, T000Q2_A102LOTE, T000Q2_A103TAL,
               T000Q2_A267FINCA_nom, T000Q2_A268PROVE_NOM, T000Q2_A269CHOFER, T000Q2_A270CABEZAL, T000Q2_A271FH_ENT, T000Q2_A272FH_SAI, T000Q2_A273PESO, T000Q2_A274PESO_NETO, T000Q2_A275TARA, T000Q2_A276BRUTO,
               T000Q2_A277FORN_ASOCIADO, T000Q2_A278NOM_ASOCIADO, T000Q2_A279COd_PROPIETARIO, T000Q2_A280NOM_PROPIETARIO, T000Q2_A281TIPO, T000Q2_A282AGRUPACION, T000Q2_A283VALOR_TRANSP_AP, T000Q2_A284HORA_SAI, T000Q2_A285HORA_BRUTO, T000Q2_A286LOTE_NOM,
               T000Q2_A287TAL_DET, T000Q2_A4IndicadoresCodigo, T000Q2_A5Cod_Area
               }
               , new Object[] {
               T000Q3_A94FRUTAPROPIAFecha, T000Q3_A95FRUTAPROPIAMes, T000Q3_A96FRUTAPROPIAAno, T000Q3_A97VIAJE, T000Q3_A98SETOR, T000Q3_A99FINCA, T000Q3_A100PROVE_COD, T000Q3_A101DIA, T000Q3_A102LOTE, T000Q3_A103TAL,
               T000Q3_A267FINCA_nom, T000Q3_A268PROVE_NOM, T000Q3_A269CHOFER, T000Q3_A270CABEZAL, T000Q3_A271FH_ENT, T000Q3_A272FH_SAI, T000Q3_A273PESO, T000Q3_A274PESO_NETO, T000Q3_A275TARA, T000Q3_A276BRUTO,
               T000Q3_A277FORN_ASOCIADO, T000Q3_A278NOM_ASOCIADO, T000Q3_A279COd_PROPIETARIO, T000Q3_A280NOM_PROPIETARIO, T000Q3_A281TIPO, T000Q3_A282AGRUPACION, T000Q3_A283VALOR_TRANSP_AP, T000Q3_A284HORA_SAI, T000Q3_A285HORA_BRUTO, T000Q3_A286LOTE_NOM,
               T000Q3_A287TAL_DET, T000Q3_A4IndicadoresCodigo, T000Q3_A5Cod_Area
               }
               , new Object[] {
               T000Q4_A4IndicadoresCodigo
               }
               , new Object[] {
               T000Q5_A5Cod_Area
               }
               , new Object[] {
               T000Q6_A94FRUTAPROPIAFecha, T000Q6_A95FRUTAPROPIAMes, T000Q6_A96FRUTAPROPIAAno, T000Q6_A97VIAJE, T000Q6_A98SETOR, T000Q6_A99FINCA, T000Q6_A100PROVE_COD, T000Q6_A101DIA, T000Q6_A102LOTE, T000Q6_A103TAL,
               T000Q6_A267FINCA_nom, T000Q6_A268PROVE_NOM, T000Q6_A269CHOFER, T000Q6_A270CABEZAL, T000Q6_A271FH_ENT, T000Q6_A272FH_SAI, T000Q6_A273PESO, T000Q6_A274PESO_NETO, T000Q6_A275TARA, T000Q6_A276BRUTO,
               T000Q6_A277FORN_ASOCIADO, T000Q6_A278NOM_ASOCIADO, T000Q6_A279COd_PROPIETARIO, T000Q6_A280NOM_PROPIETARIO, T000Q6_A281TIPO, T000Q6_A282AGRUPACION, T000Q6_A283VALOR_TRANSP_AP, T000Q6_A284HORA_SAI, T000Q6_A285HORA_BRUTO, T000Q6_A286LOTE_NOM,
               T000Q6_A287TAL_DET, T000Q6_A4IndicadoresCodigo, T000Q6_A5Cod_Area
               }
               , new Object[] {
               T000Q7_A4IndicadoresCodigo
               }
               , new Object[] {
               T000Q8_A5Cod_Area
               }
               , new Object[] {
               T000Q9_A94FRUTAPROPIAFecha, T000Q9_A95FRUTAPROPIAMes, T000Q9_A96FRUTAPROPIAAno, T000Q9_A4IndicadoresCodigo, T000Q9_A5Cod_Area, T000Q9_A97VIAJE, T000Q9_A98SETOR, T000Q9_A99FINCA, T000Q9_A100PROVE_COD, T000Q9_A101DIA,
               T000Q9_A102LOTE, T000Q9_A103TAL
               }
               , new Object[] {
               T000Q10_A94FRUTAPROPIAFecha, T000Q10_A95FRUTAPROPIAMes, T000Q10_A96FRUTAPROPIAAno, T000Q10_A4IndicadoresCodigo, T000Q10_A5Cod_Area, T000Q10_A97VIAJE, T000Q10_A98SETOR, T000Q10_A99FINCA, T000Q10_A100PROVE_COD, T000Q10_A101DIA,
               T000Q10_A102LOTE, T000Q10_A103TAL
               }
               , new Object[] {
               T000Q11_A94FRUTAPROPIAFecha, T000Q11_A95FRUTAPROPIAMes, T000Q11_A96FRUTAPROPIAAno, T000Q11_A4IndicadoresCodigo, T000Q11_A5Cod_Area, T000Q11_A97VIAJE, T000Q11_A98SETOR, T000Q11_A99FINCA, T000Q11_A100PROVE_COD, T000Q11_A101DIA,
               T000Q11_A102LOTE, T000Q11_A103TAL
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000Q15_A94FRUTAPROPIAFecha, T000Q15_A95FRUTAPROPIAMes, T000Q15_A96FRUTAPROPIAAno, T000Q15_A4IndicadoresCodigo, T000Q15_A5Cod_Area, T000Q15_A97VIAJE, T000Q15_A98SETOR, T000Q15_A99FINCA, T000Q15_A100PROVE_COD, T000Q15_A101DIA,
               T000Q15_A102LOTE, T000Q15_A103TAL
               }
               , new Object[] {
               T000Q16_A4IndicadoresCodigo
               }
               , new Object[] {
               T000Q17_A5Cod_Area
               }
            }
         );
      }

      private short Z95FRUTAPROPIAMes ;
      private short Z96FRUTAPROPIAAno ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A95FRUTAPROPIAMes ;
      private short A96FRUTAPROPIAAno ;
      private short GX_JID ;
      private short RcdFound27 ;
      private short nIsDirty_27 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ95FRUTAPROPIAMes ;
      private short ZZ96FRUTAPROPIAAno ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtFRUTAPROPIAFecha_Enabled ;
      private int edtFRUTAPROPIAMes_Enabled ;
      private int edtFRUTAPROPIAAno_Enabled ;
      private int edtIndicadoresCodigo_Enabled ;
      private int imgprompt_4_Visible ;
      private int edtCod_Area_Enabled ;
      private int imgprompt_5_Visible ;
      private int edtVIAJE_Enabled ;
      private int edtSETOR_Enabled ;
      private int edtFINCA_Enabled ;
      private int edtFINCA_nom_Enabled ;
      private int edtPROVE_COD_Enabled ;
      private int edtPROVE_NOM_Enabled ;
      private int edtDIA_Enabled ;
      private int edtCHOFER_Enabled ;
      private int edtCABEZAL_Enabled ;
      private int edtFH_ENT_Enabled ;
      private int edtFH_SAI_Enabled ;
      private int edtPESO_Enabled ;
      private int edtPESO_NETO_Enabled ;
      private int edtTARA_Enabled ;
      private int edtBRUTO_Enabled ;
      private int edtFORN_ASOCIADO_Enabled ;
      private int edtNOM_ASOCIADO_Enabled ;
      private int edtCOd_PROPIETARIO_Enabled ;
      private int edtNOM_PROPIETARIO_Enabled ;
      private int edtTIPO_Enabled ;
      private int edtAGRUPACION_Enabled ;
      private int edtVALOR_TRANSP_AP_Enabled ;
      private int edtHORA_SAI_Enabled ;
      private int edtHORA_BRUTO_Enabled ;
      private int edtLOTE_NOM_Enabled ;
      private int edtLOTE_Enabled ;
      private int edtTAL_Enabled ;
      private int edtTAL_DET_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z97VIAJE ;
      private long Z283VALOR_TRANSP_AP ;
      private long A97VIAJE ;
      private long A283VALOR_TRANSP_AP ;
      private long ZZ97VIAJE ;
      private long ZZ283VALOR_TRANSP_AP ;
      private decimal Z273PESO ;
      private decimal Z274PESO_NETO ;
      private decimal Z275TARA ;
      private decimal Z276BRUTO ;
      private decimal Z281TIPO ;
      private decimal A273PESO ;
      private decimal A274PESO_NETO ;
      private decimal A275TARA ;
      private decimal A276BRUTO ;
      private decimal A281TIPO ;
      private decimal ZZ273PESO ;
      private decimal ZZ274PESO_NETO ;
      private decimal ZZ275TARA ;
      private decimal ZZ276BRUTO ;
      private decimal ZZ281TIPO ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtFRUTAPROPIAFecha_Internalname ;
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
      private string edtFRUTAPROPIAFecha_Jsonclick ;
      private string edtFRUTAPROPIAMes_Internalname ;
      private string edtFRUTAPROPIAMes_Jsonclick ;
      private string edtFRUTAPROPIAAno_Internalname ;
      private string edtFRUTAPROPIAAno_Jsonclick ;
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
      private string edtVIAJE_Internalname ;
      private string edtVIAJE_Jsonclick ;
      private string edtSETOR_Internalname ;
      private string edtSETOR_Jsonclick ;
      private string edtFINCA_Internalname ;
      private string edtFINCA_Jsonclick ;
      private string edtFINCA_nom_Internalname ;
      private string edtFINCA_nom_Jsonclick ;
      private string edtPROVE_COD_Internalname ;
      private string edtPROVE_COD_Jsonclick ;
      private string edtPROVE_NOM_Internalname ;
      private string edtPROVE_NOM_Jsonclick ;
      private string edtDIA_Internalname ;
      private string edtDIA_Jsonclick ;
      private string edtCHOFER_Internalname ;
      private string edtCHOFER_Jsonclick ;
      private string edtCABEZAL_Internalname ;
      private string edtCABEZAL_Jsonclick ;
      private string edtFH_ENT_Internalname ;
      private string edtFH_ENT_Jsonclick ;
      private string edtFH_SAI_Internalname ;
      private string edtFH_SAI_Jsonclick ;
      private string edtPESO_Internalname ;
      private string edtPESO_Jsonclick ;
      private string edtPESO_NETO_Internalname ;
      private string edtPESO_NETO_Jsonclick ;
      private string edtTARA_Internalname ;
      private string edtTARA_Jsonclick ;
      private string edtBRUTO_Internalname ;
      private string edtBRUTO_Jsonclick ;
      private string edtFORN_ASOCIADO_Internalname ;
      private string edtFORN_ASOCIADO_Jsonclick ;
      private string edtNOM_ASOCIADO_Internalname ;
      private string edtCOd_PROPIETARIO_Internalname ;
      private string edtNOM_PROPIETARIO_Internalname ;
      private string edtTIPO_Internalname ;
      private string edtTIPO_Jsonclick ;
      private string edtAGRUPACION_Internalname ;
      private string edtAGRUPACION_Jsonclick ;
      private string edtVALOR_TRANSP_AP_Internalname ;
      private string edtVALOR_TRANSP_AP_Jsonclick ;
      private string edtHORA_SAI_Internalname ;
      private string edtHORA_SAI_Jsonclick ;
      private string edtHORA_BRUTO_Internalname ;
      private string edtHORA_BRUTO_Jsonclick ;
      private string edtLOTE_NOM_Internalname ;
      private string edtLOTE_NOM_Jsonclick ;
      private string edtLOTE_Internalname ;
      private string edtLOTE_Jsonclick ;
      private string edtTAL_Internalname ;
      private string edtTAL_Jsonclick ;
      private string edtTAL_DET_Internalname ;
      private string edtTAL_DET_Jsonclick ;
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
      private string sMode27 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z101DIA ;
      private DateTime A101DIA ;
      private DateTime ZZ101DIA ;
      private DateTime Z94FRUTAPROPIAFecha ;
      private DateTime Z271FH_ENT ;
      private DateTime Z272FH_SAI ;
      private DateTime A94FRUTAPROPIAFecha ;
      private DateTime A271FH_ENT ;
      private DateTime A272FH_SAI ;
      private DateTime ZZ94FRUTAPROPIAFecha ;
      private DateTime ZZ271FH_ENT ;
      private DateTime ZZ272FH_SAI ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private string Z4IndicadoresCodigo ;
      private string Z5Cod_Area ;
      private string Z98SETOR ;
      private string Z99FINCA ;
      private string Z100PROVE_COD ;
      private string Z102LOTE ;
      private string Z103TAL ;
      private string Z267FINCA_nom ;
      private string Z268PROVE_NOM ;
      private string Z269CHOFER ;
      private string Z270CABEZAL ;
      private string Z277FORN_ASOCIADO ;
      private string Z278NOM_ASOCIADO ;
      private string Z279COd_PROPIETARIO ;
      private string Z280NOM_PROPIETARIO ;
      private string Z282AGRUPACION ;
      private string Z284HORA_SAI ;
      private string Z285HORA_BRUTO ;
      private string Z286LOTE_NOM ;
      private string Z287TAL_DET ;
      private string A4IndicadoresCodigo ;
      private string A5Cod_Area ;
      private string A98SETOR ;
      private string A99FINCA ;
      private string A267FINCA_nom ;
      private string A100PROVE_COD ;
      private string A268PROVE_NOM ;
      private string A269CHOFER ;
      private string A270CABEZAL ;
      private string A277FORN_ASOCIADO ;
      private string A278NOM_ASOCIADO ;
      private string A279COd_PROPIETARIO ;
      private string A280NOM_PROPIETARIO ;
      private string A282AGRUPACION ;
      private string A284HORA_SAI ;
      private string A285HORA_BRUTO ;
      private string A286LOTE_NOM ;
      private string A102LOTE ;
      private string A103TAL ;
      private string A287TAL_DET ;
      private string ZZ4IndicadoresCodigo ;
      private string ZZ5Cod_Area ;
      private string ZZ98SETOR ;
      private string ZZ99FINCA ;
      private string ZZ100PROVE_COD ;
      private string ZZ102LOTE ;
      private string ZZ103TAL ;
      private string ZZ267FINCA_nom ;
      private string ZZ268PROVE_NOM ;
      private string ZZ269CHOFER ;
      private string ZZ270CABEZAL ;
      private string ZZ277FORN_ASOCIADO ;
      private string ZZ278NOM_ASOCIADO ;
      private string ZZ279COd_PROPIETARIO ;
      private string ZZ280NOM_PROPIETARIO ;
      private string ZZ282AGRUPACION ;
      private string ZZ284HORA_SAI ;
      private string ZZ285HORA_BRUTO ;
      private string ZZ286LOTE_NOM ;
      private string ZZ287TAL_DET ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] T000Q6_A94FRUTAPROPIAFecha ;
      private short[] T000Q6_A95FRUTAPROPIAMes ;
      private short[] T000Q6_A96FRUTAPROPIAAno ;
      private long[] T000Q6_A97VIAJE ;
      private string[] T000Q6_A98SETOR ;
      private string[] T000Q6_A99FINCA ;
      private string[] T000Q6_A100PROVE_COD ;
      private DateTime[] T000Q6_A101DIA ;
      private string[] T000Q6_A102LOTE ;
      private string[] T000Q6_A103TAL ;
      private string[] T000Q6_A267FINCA_nom ;
      private string[] T000Q6_A268PROVE_NOM ;
      private string[] T000Q6_A269CHOFER ;
      private string[] T000Q6_A270CABEZAL ;
      private DateTime[] T000Q6_A271FH_ENT ;
      private DateTime[] T000Q6_A272FH_SAI ;
      private decimal[] T000Q6_A273PESO ;
      private decimal[] T000Q6_A274PESO_NETO ;
      private decimal[] T000Q6_A275TARA ;
      private decimal[] T000Q6_A276BRUTO ;
      private string[] T000Q6_A277FORN_ASOCIADO ;
      private string[] T000Q6_A278NOM_ASOCIADO ;
      private string[] T000Q6_A279COd_PROPIETARIO ;
      private string[] T000Q6_A280NOM_PROPIETARIO ;
      private decimal[] T000Q6_A281TIPO ;
      private string[] T000Q6_A282AGRUPACION ;
      private long[] T000Q6_A283VALOR_TRANSP_AP ;
      private string[] T000Q6_A284HORA_SAI ;
      private string[] T000Q6_A285HORA_BRUTO ;
      private string[] T000Q6_A286LOTE_NOM ;
      private string[] T000Q6_A287TAL_DET ;
      private string[] T000Q6_A4IndicadoresCodigo ;
      private string[] T000Q6_A5Cod_Area ;
      private string[] T000Q4_A4IndicadoresCodigo ;
      private string[] T000Q5_A5Cod_Area ;
      private string[] T000Q7_A4IndicadoresCodigo ;
      private string[] T000Q8_A5Cod_Area ;
      private DateTime[] T000Q9_A94FRUTAPROPIAFecha ;
      private short[] T000Q9_A95FRUTAPROPIAMes ;
      private short[] T000Q9_A96FRUTAPROPIAAno ;
      private string[] T000Q9_A4IndicadoresCodigo ;
      private string[] T000Q9_A5Cod_Area ;
      private long[] T000Q9_A97VIAJE ;
      private string[] T000Q9_A98SETOR ;
      private string[] T000Q9_A99FINCA ;
      private string[] T000Q9_A100PROVE_COD ;
      private DateTime[] T000Q9_A101DIA ;
      private string[] T000Q9_A102LOTE ;
      private string[] T000Q9_A103TAL ;
      private DateTime[] T000Q3_A94FRUTAPROPIAFecha ;
      private short[] T000Q3_A95FRUTAPROPIAMes ;
      private short[] T000Q3_A96FRUTAPROPIAAno ;
      private long[] T000Q3_A97VIAJE ;
      private string[] T000Q3_A98SETOR ;
      private string[] T000Q3_A99FINCA ;
      private string[] T000Q3_A100PROVE_COD ;
      private DateTime[] T000Q3_A101DIA ;
      private string[] T000Q3_A102LOTE ;
      private string[] T000Q3_A103TAL ;
      private string[] T000Q3_A267FINCA_nom ;
      private string[] T000Q3_A268PROVE_NOM ;
      private string[] T000Q3_A269CHOFER ;
      private string[] T000Q3_A270CABEZAL ;
      private DateTime[] T000Q3_A271FH_ENT ;
      private DateTime[] T000Q3_A272FH_SAI ;
      private decimal[] T000Q3_A273PESO ;
      private decimal[] T000Q3_A274PESO_NETO ;
      private decimal[] T000Q3_A275TARA ;
      private decimal[] T000Q3_A276BRUTO ;
      private string[] T000Q3_A277FORN_ASOCIADO ;
      private string[] T000Q3_A278NOM_ASOCIADO ;
      private string[] T000Q3_A279COd_PROPIETARIO ;
      private string[] T000Q3_A280NOM_PROPIETARIO ;
      private decimal[] T000Q3_A281TIPO ;
      private string[] T000Q3_A282AGRUPACION ;
      private long[] T000Q3_A283VALOR_TRANSP_AP ;
      private string[] T000Q3_A284HORA_SAI ;
      private string[] T000Q3_A285HORA_BRUTO ;
      private string[] T000Q3_A286LOTE_NOM ;
      private string[] T000Q3_A287TAL_DET ;
      private string[] T000Q3_A4IndicadoresCodigo ;
      private string[] T000Q3_A5Cod_Area ;
      private DateTime[] T000Q10_A94FRUTAPROPIAFecha ;
      private short[] T000Q10_A95FRUTAPROPIAMes ;
      private short[] T000Q10_A96FRUTAPROPIAAno ;
      private string[] T000Q10_A4IndicadoresCodigo ;
      private string[] T000Q10_A5Cod_Area ;
      private long[] T000Q10_A97VIAJE ;
      private string[] T000Q10_A98SETOR ;
      private string[] T000Q10_A99FINCA ;
      private string[] T000Q10_A100PROVE_COD ;
      private DateTime[] T000Q10_A101DIA ;
      private string[] T000Q10_A102LOTE ;
      private string[] T000Q10_A103TAL ;
      private DateTime[] T000Q11_A94FRUTAPROPIAFecha ;
      private short[] T000Q11_A95FRUTAPROPIAMes ;
      private short[] T000Q11_A96FRUTAPROPIAAno ;
      private string[] T000Q11_A4IndicadoresCodigo ;
      private string[] T000Q11_A5Cod_Area ;
      private long[] T000Q11_A97VIAJE ;
      private string[] T000Q11_A98SETOR ;
      private string[] T000Q11_A99FINCA ;
      private string[] T000Q11_A100PROVE_COD ;
      private DateTime[] T000Q11_A101DIA ;
      private string[] T000Q11_A102LOTE ;
      private string[] T000Q11_A103TAL ;
      private DateTime[] T000Q2_A94FRUTAPROPIAFecha ;
      private short[] T000Q2_A95FRUTAPROPIAMes ;
      private short[] T000Q2_A96FRUTAPROPIAAno ;
      private long[] T000Q2_A97VIAJE ;
      private string[] T000Q2_A98SETOR ;
      private string[] T000Q2_A99FINCA ;
      private string[] T000Q2_A100PROVE_COD ;
      private DateTime[] T000Q2_A101DIA ;
      private string[] T000Q2_A102LOTE ;
      private string[] T000Q2_A103TAL ;
      private string[] T000Q2_A267FINCA_nom ;
      private string[] T000Q2_A268PROVE_NOM ;
      private string[] T000Q2_A269CHOFER ;
      private string[] T000Q2_A270CABEZAL ;
      private DateTime[] T000Q2_A271FH_ENT ;
      private DateTime[] T000Q2_A272FH_SAI ;
      private decimal[] T000Q2_A273PESO ;
      private decimal[] T000Q2_A274PESO_NETO ;
      private decimal[] T000Q2_A275TARA ;
      private decimal[] T000Q2_A276BRUTO ;
      private string[] T000Q2_A277FORN_ASOCIADO ;
      private string[] T000Q2_A278NOM_ASOCIADO ;
      private string[] T000Q2_A279COd_PROPIETARIO ;
      private string[] T000Q2_A280NOM_PROPIETARIO ;
      private decimal[] T000Q2_A281TIPO ;
      private string[] T000Q2_A282AGRUPACION ;
      private long[] T000Q2_A283VALOR_TRANSP_AP ;
      private string[] T000Q2_A284HORA_SAI ;
      private string[] T000Q2_A285HORA_BRUTO ;
      private string[] T000Q2_A286LOTE_NOM ;
      private string[] T000Q2_A287TAL_DET ;
      private string[] T000Q2_A4IndicadoresCodigo ;
      private string[] T000Q2_A5Cod_Area ;
      private DateTime[] T000Q15_A94FRUTAPROPIAFecha ;
      private short[] T000Q15_A95FRUTAPROPIAMes ;
      private short[] T000Q15_A96FRUTAPROPIAAno ;
      private string[] T000Q15_A4IndicadoresCodigo ;
      private string[] T000Q15_A5Cod_Area ;
      private long[] T000Q15_A97VIAJE ;
      private string[] T000Q15_A98SETOR ;
      private string[] T000Q15_A99FINCA ;
      private string[] T000Q15_A100PROVE_COD ;
      private DateTime[] T000Q15_A101DIA ;
      private string[] T000Q15_A102LOTE ;
      private string[] T000Q15_A103TAL ;
      private string[] T000Q16_A4IndicadoresCodigo ;
      private string[] T000Q17_A5Cod_Area ;
      private GXWebForm Form ;
   }

   public class frutapropia__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT000Q6;
          prmT000Q6 = new Object[] {
          new ParDef("@FRUTAPROPIAFecha",GXType.Date,8,0) ,
          new ParDef("@FRUTAPROPIAMes",GXType.Int16,4,0) ,
          new ParDef("@FRUTAPROPIAAno",GXType.Int16,4,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@VIAJE",GXType.Decimal,12,0) ,
          new ParDef("@SETOR",GXType.NVarChar,40,0) ,
          new ParDef("@FINCA",GXType.NVarChar,150,0) ,
          new ParDef("@PROVE_COD",GXType.NVarChar,150,0) ,
          new ParDef("@DIA",GXType.DateTime,8,5) ,
          new ParDef("@LOTE",GXType.NVarChar,40,0) ,
          new ParDef("@TAL",GXType.NVarChar,40,0)
          };
          Object[] prmT000Q4;
          prmT000Q4 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000Q5;
          prmT000Q5 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000Q7;
          prmT000Q7 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000Q8;
          prmT000Q8 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000Q9;
          prmT000Q9 = new Object[] {
          new ParDef("@FRUTAPROPIAFecha",GXType.Date,8,0) ,
          new ParDef("@FRUTAPROPIAMes",GXType.Int16,4,0) ,
          new ParDef("@FRUTAPROPIAAno",GXType.Int16,4,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@VIAJE",GXType.Decimal,12,0) ,
          new ParDef("@SETOR",GXType.NVarChar,40,0) ,
          new ParDef("@FINCA",GXType.NVarChar,150,0) ,
          new ParDef("@PROVE_COD",GXType.NVarChar,150,0) ,
          new ParDef("@DIA",GXType.DateTime,8,5) ,
          new ParDef("@LOTE",GXType.NVarChar,40,0) ,
          new ParDef("@TAL",GXType.NVarChar,40,0)
          };
          Object[] prmT000Q3;
          prmT000Q3 = new Object[] {
          new ParDef("@FRUTAPROPIAFecha",GXType.Date,8,0) ,
          new ParDef("@FRUTAPROPIAMes",GXType.Int16,4,0) ,
          new ParDef("@FRUTAPROPIAAno",GXType.Int16,4,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@VIAJE",GXType.Decimal,12,0) ,
          new ParDef("@SETOR",GXType.NVarChar,40,0) ,
          new ParDef("@FINCA",GXType.NVarChar,150,0) ,
          new ParDef("@PROVE_COD",GXType.NVarChar,150,0) ,
          new ParDef("@DIA",GXType.DateTime,8,5) ,
          new ParDef("@LOTE",GXType.NVarChar,40,0) ,
          new ParDef("@TAL",GXType.NVarChar,40,0)
          };
          Object[] prmT000Q10;
          prmT000Q10 = new Object[] {
          new ParDef("@FRUTAPROPIAFecha",GXType.Date,8,0) ,
          new ParDef("@FRUTAPROPIAMes",GXType.Int16,4,0) ,
          new ParDef("@FRUTAPROPIAAno",GXType.Int16,4,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@VIAJE",GXType.Decimal,12,0) ,
          new ParDef("@SETOR",GXType.NVarChar,40,0) ,
          new ParDef("@FINCA",GXType.NVarChar,150,0) ,
          new ParDef("@PROVE_COD",GXType.NVarChar,150,0) ,
          new ParDef("@DIA",GXType.DateTime,8,5) ,
          new ParDef("@LOTE",GXType.NVarChar,40,0) ,
          new ParDef("@TAL",GXType.NVarChar,40,0)
          };
          string cmdBufferT000Q10;
          cmdBufferT000Q10=" SELECT TOP 1 [FRUTAPROPIAFecha], [FRUTAPROPIAMes], [FRUTAPROPIAAno], [IndicadoresCodigo], [Cod_Area], [VIAJE], [SETOR], [FINCA], [PROVE_COD], [DIA], [LOTE], [TAL] FROM [FRUTAPROPIA] WHERE ( [FRUTAPROPIAFecha] > @FRUTAPROPIAFecha or [FRUTAPROPIAFecha] = @FRUTAPROPIAFecha and [FRUTAPROPIAMes] > @FRUTAPROPIAMes or [FRUTAPROPIAMes] = @FRUTAPROPIAMes and [FRUTAPROPIAFecha] = @FRUTAPROPIAFecha and [FRUTAPROPIAAno] > @FRUTAPROPIAAno or [FRUTAPROPIAAno] = @FRUTAPROPIAAno and [FRUTAPROPIAMes] = @FRUTAPROPIAMes and [FRUTAPROPIAFecha] = @FRUTAPROPIAFecha and [IndicadoresCodigo] > @IndicadoresCodigo or [IndicadoresCodigo] = @IndicadoresCodigo and [FRUTAPROPIAAno] = @FRUTAPROPIAAno and [FRUTAPROPIAMes] = @FRUTAPROPIAMes and [FRUTAPROPIAFecha] = @FRUTAPROPIAFecha and [Cod_Area] > @Cod_Area or [Cod_Area] = @Cod_Area and [IndicadoresCodigo] = @IndicadoresCodigo and [FRUTAPROPIAAno] = @FRUTAPROPIAAno and [FRUTAPROPIAMes] = @FRUTAPROPIAMes and [FRUTAPROPIAFecha] = @FRUTAPROPIAFecha and [VIAJE] > @VIAJE or [VIAJE] = @VIAJE and [Cod_Area] = @Cod_Area and [IndicadoresCodigo] = @IndicadoresCodigo and [FRUTAPROPIAAno] = @FRUTAPROPIAAno and [FRUTAPROPIAMes] = @FRUTAPROPIAMes and [FRUTAPROPIAFecha] = @FRUTAPROPIAFecha and [SETOR] > @SETOR or [SETOR] = @SETOR and [VIAJE] = @VIAJE and [Cod_Area] = @Cod_Area and [IndicadoresCodigo] = @IndicadoresCodigo and [FRUTAPROPIAAno] = @FRUTAPROPIAAno and [FRUTAPROPIAMes] = @FRUTAPROPIAMes and [FRUTAPROPIAFecha] = @FRUTAPROPIAFecha and [FINCA] > @FINCA or [FINCA] = @FINCA and [SETOR] = @SETOR and [VIAJE] = @VIAJE and [Cod_Area] = @Cod_Area and [IndicadoresCodigo] = @IndicadoresCodigo and [FRUTAPROPIAAno] = @FRUTAPROPIAAno and [FRUTAPROPIAMes] = @FRUTAPROPIAMes and [FRUTAPROPIAFecha] = @FRUTAPROPIAFecha and [PROVE_COD] > @PROVE_COD or [PROVE_COD] = @PROVE_COD "
          + " and [FINCA] = @FINCA and [SETOR] = @SETOR and [VIAJE] = @VIAJE and [Cod_Area] = @Cod_Area and [IndicadoresCodigo] = @IndicadoresCodigo and [FRUTAPROPIAAno] = @FRUTAPROPIAAno and [FRUTAPROPIAMes] = @FRUTAPROPIAMes and [FRUTAPROPIAFecha] = @FRUTAPROPIAFecha and [DIA] > @DIA or [DIA] = @DIA and [PROVE_COD] = @PROVE_COD and [FINCA] = @FINCA and [SETOR] = @SETOR and [VIAJE] = @VIAJE and [Cod_Area] = @Cod_Area and [IndicadoresCodigo] = @IndicadoresCodigo and [FRUTAPROPIAAno] = @FRUTAPROPIAAno and [FRUTAPROPIAMes] = @FRUTAPROPIAMes and [FRUTAPROPIAFecha] = @FRUTAPROPIAFecha and [LOTE] > @LOTE or [LOTE] = @LOTE and [DIA] = @DIA and [PROVE_COD] = @PROVE_COD and [FINCA] = @FINCA and [SETOR] = @SETOR and [VIAJE] = @VIAJE and [Cod_Area] = @Cod_Area and [IndicadoresCodigo] = @IndicadoresCodigo and [FRUTAPROPIAAno] = @FRUTAPROPIAAno and [FRUTAPROPIAMes] = @FRUTAPROPIAMes and [FRUTAPROPIAFecha] = @FRUTAPROPIAFecha and [TAL] > @TAL) ORDER BY [FRUTAPROPIAFecha], [FRUTAPROPIAMes], [FRUTAPROPIAAno], [IndicadoresCodigo], [Cod_Area], [VIAJE], [SETOR], [FINCA], [PROVE_COD], [DIA], [LOTE], [TAL]  OPTION (FAST 1)" ;
          Object[] prmT000Q11;
          prmT000Q11 = new Object[] {
          new ParDef("@FRUTAPROPIAFecha",GXType.Date,8,0) ,
          new ParDef("@FRUTAPROPIAMes",GXType.Int16,4,0) ,
          new ParDef("@FRUTAPROPIAAno",GXType.Int16,4,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@VIAJE",GXType.Decimal,12,0) ,
          new ParDef("@SETOR",GXType.NVarChar,40,0) ,
          new ParDef("@FINCA",GXType.NVarChar,150,0) ,
          new ParDef("@PROVE_COD",GXType.NVarChar,150,0) ,
          new ParDef("@DIA",GXType.DateTime,8,5) ,
          new ParDef("@LOTE",GXType.NVarChar,40,0) ,
          new ParDef("@TAL",GXType.NVarChar,40,0)
          };
          string cmdBufferT000Q11;
          cmdBufferT000Q11=" SELECT TOP 1 [FRUTAPROPIAFecha], [FRUTAPROPIAMes], [FRUTAPROPIAAno], [IndicadoresCodigo], [Cod_Area], [VIAJE], [SETOR], [FINCA], [PROVE_COD], [DIA], [LOTE], [TAL] FROM [FRUTAPROPIA] WHERE ( [FRUTAPROPIAFecha] < @FRUTAPROPIAFecha or [FRUTAPROPIAFecha] = @FRUTAPROPIAFecha and [FRUTAPROPIAMes] < @FRUTAPROPIAMes or [FRUTAPROPIAMes] = @FRUTAPROPIAMes and [FRUTAPROPIAFecha] = @FRUTAPROPIAFecha and [FRUTAPROPIAAno] < @FRUTAPROPIAAno or [FRUTAPROPIAAno] = @FRUTAPROPIAAno and [FRUTAPROPIAMes] = @FRUTAPROPIAMes and [FRUTAPROPIAFecha] = @FRUTAPROPIAFecha and [IndicadoresCodigo] < @IndicadoresCodigo or [IndicadoresCodigo] = @IndicadoresCodigo and [FRUTAPROPIAAno] = @FRUTAPROPIAAno and [FRUTAPROPIAMes] = @FRUTAPROPIAMes and [FRUTAPROPIAFecha] = @FRUTAPROPIAFecha and [Cod_Area] < @Cod_Area or [Cod_Area] = @Cod_Area and [IndicadoresCodigo] = @IndicadoresCodigo and [FRUTAPROPIAAno] = @FRUTAPROPIAAno and [FRUTAPROPIAMes] = @FRUTAPROPIAMes and [FRUTAPROPIAFecha] = @FRUTAPROPIAFecha and [VIAJE] < @VIAJE or [VIAJE] = @VIAJE and [Cod_Area] = @Cod_Area and [IndicadoresCodigo] = @IndicadoresCodigo and [FRUTAPROPIAAno] = @FRUTAPROPIAAno and [FRUTAPROPIAMes] = @FRUTAPROPIAMes and [FRUTAPROPIAFecha] = @FRUTAPROPIAFecha and [SETOR] < @SETOR or [SETOR] = @SETOR and [VIAJE] = @VIAJE and [Cod_Area] = @Cod_Area and [IndicadoresCodigo] = @IndicadoresCodigo and [FRUTAPROPIAAno] = @FRUTAPROPIAAno and [FRUTAPROPIAMes] = @FRUTAPROPIAMes and [FRUTAPROPIAFecha] = @FRUTAPROPIAFecha and [FINCA] < @FINCA or [FINCA] = @FINCA and [SETOR] = @SETOR and [VIAJE] = @VIAJE and [Cod_Area] = @Cod_Area and [IndicadoresCodigo] = @IndicadoresCodigo and [FRUTAPROPIAAno] = @FRUTAPROPIAAno and [FRUTAPROPIAMes] = @FRUTAPROPIAMes and [FRUTAPROPIAFecha] = @FRUTAPROPIAFecha and [PROVE_COD] < @PROVE_COD or [PROVE_COD] = @PROVE_COD "
          + " and [FINCA] = @FINCA and [SETOR] = @SETOR and [VIAJE] = @VIAJE and [Cod_Area] = @Cod_Area and [IndicadoresCodigo] = @IndicadoresCodigo and [FRUTAPROPIAAno] = @FRUTAPROPIAAno and [FRUTAPROPIAMes] = @FRUTAPROPIAMes and [FRUTAPROPIAFecha] = @FRUTAPROPIAFecha and [DIA] < @DIA or [DIA] = @DIA and [PROVE_COD] = @PROVE_COD and [FINCA] = @FINCA and [SETOR] = @SETOR and [VIAJE] = @VIAJE and [Cod_Area] = @Cod_Area and [IndicadoresCodigo] = @IndicadoresCodigo and [FRUTAPROPIAAno] = @FRUTAPROPIAAno and [FRUTAPROPIAMes] = @FRUTAPROPIAMes and [FRUTAPROPIAFecha] = @FRUTAPROPIAFecha and [LOTE] < @LOTE or [LOTE] = @LOTE and [DIA] = @DIA and [PROVE_COD] = @PROVE_COD and [FINCA] = @FINCA and [SETOR] = @SETOR and [VIAJE] = @VIAJE and [Cod_Area] = @Cod_Area and [IndicadoresCodigo] = @IndicadoresCodigo and [FRUTAPROPIAAno] = @FRUTAPROPIAAno and [FRUTAPROPIAMes] = @FRUTAPROPIAMes and [FRUTAPROPIAFecha] = @FRUTAPROPIAFecha and [TAL] < @TAL) ORDER BY [FRUTAPROPIAFecha] DESC, [FRUTAPROPIAMes] DESC, [FRUTAPROPIAAno] DESC, [IndicadoresCodigo] DESC, [Cod_Area] DESC, [VIAJE] DESC, [SETOR] DESC, [FINCA] DESC, [PROVE_COD] DESC, [DIA] DESC, [LOTE] DESC, [TAL] DESC  OPTION (FAST 1)" ;
          Object[] prmT000Q2;
          prmT000Q2 = new Object[] {
          new ParDef("@FRUTAPROPIAFecha",GXType.Date,8,0) ,
          new ParDef("@FRUTAPROPIAMes",GXType.Int16,4,0) ,
          new ParDef("@FRUTAPROPIAAno",GXType.Int16,4,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@VIAJE",GXType.Decimal,12,0) ,
          new ParDef("@SETOR",GXType.NVarChar,40,0) ,
          new ParDef("@FINCA",GXType.NVarChar,150,0) ,
          new ParDef("@PROVE_COD",GXType.NVarChar,150,0) ,
          new ParDef("@DIA",GXType.DateTime,8,5) ,
          new ParDef("@LOTE",GXType.NVarChar,40,0) ,
          new ParDef("@TAL",GXType.NVarChar,40,0)
          };
          Object[] prmT000Q12;
          prmT000Q12 = new Object[] {
          new ParDef("@FRUTAPROPIAFecha",GXType.Date,8,0) ,
          new ParDef("@FRUTAPROPIAMes",GXType.Int16,4,0) ,
          new ParDef("@FRUTAPROPIAAno",GXType.Int16,4,0) ,
          new ParDef("@VIAJE",GXType.Decimal,12,0) ,
          new ParDef("@SETOR",GXType.NVarChar,40,0) ,
          new ParDef("@FINCA",GXType.NVarChar,150,0) ,
          new ParDef("@PROVE_COD",GXType.NVarChar,150,0) ,
          new ParDef("@DIA",GXType.DateTime,8,5) ,
          new ParDef("@LOTE",GXType.NVarChar,40,0) ,
          new ParDef("@TAL",GXType.NVarChar,40,0) ,
          new ParDef("@FINCA_nom",GXType.NVarChar,150,0) ,
          new ParDef("@PROVE_NOM",GXType.NVarChar,150,0) ,
          new ParDef("@CHOFER",GXType.NVarChar,120,0) ,
          new ParDef("@CABEZAL",GXType.NVarChar,120,0) ,
          new ParDef("@FH_ENT",GXType.Date,8,0) ,
          new ParDef("@FH_SAI",GXType.Date,8,0) ,
          new ParDef("@PESO",GXType.Decimal,12,2) ,
          new ParDef("@PESO_NETO",GXType.Decimal,12,2) ,
          new ParDef("@TARA",GXType.Decimal,12,2) ,
          new ParDef("@BRUTO",GXType.Decimal,12,2) ,
          new ParDef("@FORN_ASOCIADO",GXType.NVarChar,150,0) ,
          new ParDef("@NOM_ASOCIADO",GXType.NVarChar,200,0) ,
          new ParDef("@COd_PROPIETARIO",GXType.NVarChar,300,0) ,
          new ParDef("@NOM_PROPIETARIO",GXType.NVarChar,300,0) ,
          new ParDef("@TIPO",GXType.Decimal,3,2) ,
          new ParDef("@AGRUPACION",GXType.NVarChar,40,0) ,
          new ParDef("@VALOR_TRANSP_AP",GXType.Decimal,10,0) ,
          new ParDef("@HORA_SAI",GXType.NVarChar,40,0) ,
          new ParDef("@HORA_BRUTO",GXType.NVarChar,40,0) ,
          new ParDef("@LOTE_NOM",GXType.NVarChar,40,0) ,
          new ParDef("@TAL_DET",GXType.NVarChar,30,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000Q13;
          prmT000Q13 = new Object[] {
          new ParDef("@FINCA_nom",GXType.NVarChar,150,0) ,
          new ParDef("@PROVE_NOM",GXType.NVarChar,150,0) ,
          new ParDef("@CHOFER",GXType.NVarChar,120,0) ,
          new ParDef("@CABEZAL",GXType.NVarChar,120,0) ,
          new ParDef("@FH_ENT",GXType.Date,8,0) ,
          new ParDef("@FH_SAI",GXType.Date,8,0) ,
          new ParDef("@PESO",GXType.Decimal,12,2) ,
          new ParDef("@PESO_NETO",GXType.Decimal,12,2) ,
          new ParDef("@TARA",GXType.Decimal,12,2) ,
          new ParDef("@BRUTO",GXType.Decimal,12,2) ,
          new ParDef("@FORN_ASOCIADO",GXType.NVarChar,150,0) ,
          new ParDef("@NOM_ASOCIADO",GXType.NVarChar,200,0) ,
          new ParDef("@COd_PROPIETARIO",GXType.NVarChar,300,0) ,
          new ParDef("@NOM_PROPIETARIO",GXType.NVarChar,300,0) ,
          new ParDef("@TIPO",GXType.Decimal,3,2) ,
          new ParDef("@AGRUPACION",GXType.NVarChar,40,0) ,
          new ParDef("@VALOR_TRANSP_AP",GXType.Decimal,10,0) ,
          new ParDef("@HORA_SAI",GXType.NVarChar,40,0) ,
          new ParDef("@HORA_BRUTO",GXType.NVarChar,40,0) ,
          new ParDef("@LOTE_NOM",GXType.NVarChar,40,0) ,
          new ParDef("@TAL_DET",GXType.NVarChar,30,0) ,
          new ParDef("@FRUTAPROPIAFecha",GXType.Date,8,0) ,
          new ParDef("@FRUTAPROPIAMes",GXType.Int16,4,0) ,
          new ParDef("@FRUTAPROPIAAno",GXType.Int16,4,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@VIAJE",GXType.Decimal,12,0) ,
          new ParDef("@SETOR",GXType.NVarChar,40,0) ,
          new ParDef("@FINCA",GXType.NVarChar,150,0) ,
          new ParDef("@PROVE_COD",GXType.NVarChar,150,0) ,
          new ParDef("@DIA",GXType.DateTime,8,5) ,
          new ParDef("@LOTE",GXType.NVarChar,40,0) ,
          new ParDef("@TAL",GXType.NVarChar,40,0)
          };
          Object[] prmT000Q14;
          prmT000Q14 = new Object[] {
          new ParDef("@FRUTAPROPIAFecha",GXType.Date,8,0) ,
          new ParDef("@FRUTAPROPIAMes",GXType.Int16,4,0) ,
          new ParDef("@FRUTAPROPIAAno",GXType.Int16,4,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@VIAJE",GXType.Decimal,12,0) ,
          new ParDef("@SETOR",GXType.NVarChar,40,0) ,
          new ParDef("@FINCA",GXType.NVarChar,150,0) ,
          new ParDef("@PROVE_COD",GXType.NVarChar,150,0) ,
          new ParDef("@DIA",GXType.DateTime,8,5) ,
          new ParDef("@LOTE",GXType.NVarChar,40,0) ,
          new ParDef("@TAL",GXType.NVarChar,40,0)
          };
          Object[] prmT000Q15;
          prmT000Q15 = new Object[] {
          };
          Object[] prmT000Q16;
          prmT000Q16 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000Q17;
          prmT000Q17 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("T000Q2", "SELECT [FRUTAPROPIAFecha], [FRUTAPROPIAMes], [FRUTAPROPIAAno], [VIAJE], [SETOR], [FINCA], [PROVE_COD], [DIA], [LOTE], [TAL], [FINCA_nom], [PROVE_NOM], [CHOFER], [CABEZAL], [FH_ENT], [FH_SAI], [PESO], [PESO_NETO], [TARA], [BRUTO], [FORN_ASOCIADO], [NOM_ASOCIADO], [COd_PROPIETARIO], [NOM_PROPIETARIO], [TIPO], [AGRUPACION], [VALOR_TRANSP_AP], [HORA_SAI], [HORA_BRUTO], [LOTE_NOM], [TAL_DET], [IndicadoresCodigo], [Cod_Area] FROM [FRUTAPROPIA] WITH (UPDLOCK) WHERE [FRUTAPROPIAFecha] = @FRUTAPROPIAFecha AND [FRUTAPROPIAMes] = @FRUTAPROPIAMes AND [FRUTAPROPIAAno] = @FRUTAPROPIAAno AND [IndicadoresCodigo] = @IndicadoresCodigo AND [Cod_Area] = @Cod_Area AND [VIAJE] = @VIAJE AND [SETOR] = @SETOR AND [FINCA] = @FINCA AND [PROVE_COD] = @PROVE_COD AND [DIA] = @DIA AND [LOTE] = @LOTE AND [TAL] = @TAL ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000Q3", "SELECT [FRUTAPROPIAFecha], [FRUTAPROPIAMes], [FRUTAPROPIAAno], [VIAJE], [SETOR], [FINCA], [PROVE_COD], [DIA], [LOTE], [TAL], [FINCA_nom], [PROVE_NOM], [CHOFER], [CABEZAL], [FH_ENT], [FH_SAI], [PESO], [PESO_NETO], [TARA], [BRUTO], [FORN_ASOCIADO], [NOM_ASOCIADO], [COd_PROPIETARIO], [NOM_PROPIETARIO], [TIPO], [AGRUPACION], [VALOR_TRANSP_AP], [HORA_SAI], [HORA_BRUTO], [LOTE_NOM], [TAL_DET], [IndicadoresCodigo], [Cod_Area] FROM [FRUTAPROPIA] WHERE [FRUTAPROPIAFecha] = @FRUTAPROPIAFecha AND [FRUTAPROPIAMes] = @FRUTAPROPIAMes AND [FRUTAPROPIAAno] = @FRUTAPROPIAAno AND [IndicadoresCodigo] = @IndicadoresCodigo AND [Cod_Area] = @Cod_Area AND [VIAJE] = @VIAJE AND [SETOR] = @SETOR AND [FINCA] = @FINCA AND [PROVE_COD] = @PROVE_COD AND [DIA] = @DIA AND [LOTE] = @LOTE AND [TAL] = @TAL ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000Q4", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000Q5", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000Q6", "SELECT TM1.[FRUTAPROPIAFecha], TM1.[FRUTAPROPIAMes], TM1.[FRUTAPROPIAAno], TM1.[VIAJE], TM1.[SETOR], TM1.[FINCA], TM1.[PROVE_COD], TM1.[DIA], TM1.[LOTE], TM1.[TAL], TM1.[FINCA_nom], TM1.[PROVE_NOM], TM1.[CHOFER], TM1.[CABEZAL], TM1.[FH_ENT], TM1.[FH_SAI], TM1.[PESO], TM1.[PESO_NETO], TM1.[TARA], TM1.[BRUTO], TM1.[FORN_ASOCIADO], TM1.[NOM_ASOCIADO], TM1.[COd_PROPIETARIO], TM1.[NOM_PROPIETARIO], TM1.[TIPO], TM1.[AGRUPACION], TM1.[VALOR_TRANSP_AP], TM1.[HORA_SAI], TM1.[HORA_BRUTO], TM1.[LOTE_NOM], TM1.[TAL_DET], TM1.[IndicadoresCodigo], TM1.[Cod_Area] FROM [FRUTAPROPIA] TM1 WHERE TM1.[FRUTAPROPIAFecha] = @FRUTAPROPIAFecha and TM1.[FRUTAPROPIAMes] = @FRUTAPROPIAMes and TM1.[FRUTAPROPIAAno] = @FRUTAPROPIAAno and TM1.[IndicadoresCodigo] = @IndicadoresCodigo and TM1.[Cod_Area] = @Cod_Area and TM1.[VIAJE] = @VIAJE and TM1.[SETOR] = @SETOR and TM1.[FINCA] = @FINCA and TM1.[PROVE_COD] = @PROVE_COD and TM1.[DIA] = @DIA and TM1.[LOTE] = @LOTE and TM1.[TAL] = @TAL ORDER BY TM1.[FRUTAPROPIAFecha], TM1.[FRUTAPROPIAMes], TM1.[FRUTAPROPIAAno], TM1.[IndicadoresCodigo], TM1.[Cod_Area], TM1.[VIAJE], TM1.[SETOR], TM1.[FINCA], TM1.[PROVE_COD], TM1.[DIA], TM1.[LOTE], TM1.[TAL]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000Q7", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000Q8", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000Q9", "SELECT [FRUTAPROPIAFecha], [FRUTAPROPIAMes], [FRUTAPROPIAAno], [IndicadoresCodigo], [Cod_Area], [VIAJE], [SETOR], [FINCA], [PROVE_COD], [DIA], [LOTE], [TAL] FROM [FRUTAPROPIA] WHERE [FRUTAPROPIAFecha] = @FRUTAPROPIAFecha AND [FRUTAPROPIAMes] = @FRUTAPROPIAMes AND [FRUTAPROPIAAno] = @FRUTAPROPIAAno AND [IndicadoresCodigo] = @IndicadoresCodigo AND [Cod_Area] = @Cod_Area AND [VIAJE] = @VIAJE AND [SETOR] = @SETOR AND [FINCA] = @FINCA AND [PROVE_COD] = @PROVE_COD AND [DIA] = @DIA AND [LOTE] = @LOTE AND [TAL] = @TAL  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000Q10", cmdBufferT000Q10,true, GxErrorMask.GX_NOMASK, false, this,prmT000Q10,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000Q11", cmdBufferT000Q11,true, GxErrorMask.GX_NOMASK, false, this,prmT000Q11,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000Q12", "INSERT INTO [FRUTAPROPIA]([FRUTAPROPIAFecha], [FRUTAPROPIAMes], [FRUTAPROPIAAno], [VIAJE], [SETOR], [FINCA], [PROVE_COD], [DIA], [LOTE], [TAL], [FINCA_nom], [PROVE_NOM], [CHOFER], [CABEZAL], [FH_ENT], [FH_SAI], [PESO], [PESO_NETO], [TARA], [BRUTO], [FORN_ASOCIADO], [NOM_ASOCIADO], [COd_PROPIETARIO], [NOM_PROPIETARIO], [TIPO], [AGRUPACION], [VALOR_TRANSP_AP], [HORA_SAI], [HORA_BRUTO], [LOTE_NOM], [TAL_DET], [IndicadoresCodigo], [Cod_Area]) VALUES(@FRUTAPROPIAFecha, @FRUTAPROPIAMes, @FRUTAPROPIAAno, @VIAJE, @SETOR, @FINCA, @PROVE_COD, @DIA, @LOTE, @TAL, @FINCA_nom, @PROVE_NOM, @CHOFER, @CABEZAL, @FH_ENT, @FH_SAI, @PESO, @PESO_NETO, @TARA, @BRUTO, @FORN_ASOCIADO, @NOM_ASOCIADO, @COd_PROPIETARIO, @NOM_PROPIETARIO, @TIPO, @AGRUPACION, @VALOR_TRANSP_AP, @HORA_SAI, @HORA_BRUTO, @LOTE_NOM, @TAL_DET, @IndicadoresCodigo, @Cod_Area)", GxErrorMask.GX_NOMASK,prmT000Q12)
             ,new CursorDef("T000Q13", "UPDATE [FRUTAPROPIA] SET [FINCA_nom]=@FINCA_nom, [PROVE_NOM]=@PROVE_NOM, [CHOFER]=@CHOFER, [CABEZAL]=@CABEZAL, [FH_ENT]=@FH_ENT, [FH_SAI]=@FH_SAI, [PESO]=@PESO, [PESO_NETO]=@PESO_NETO, [TARA]=@TARA, [BRUTO]=@BRUTO, [FORN_ASOCIADO]=@FORN_ASOCIADO, [NOM_ASOCIADO]=@NOM_ASOCIADO, [COd_PROPIETARIO]=@COd_PROPIETARIO, [NOM_PROPIETARIO]=@NOM_PROPIETARIO, [TIPO]=@TIPO, [AGRUPACION]=@AGRUPACION, [VALOR_TRANSP_AP]=@VALOR_TRANSP_AP, [HORA_SAI]=@HORA_SAI, [HORA_BRUTO]=@HORA_BRUTO, [LOTE_NOM]=@LOTE_NOM, [TAL_DET]=@TAL_DET  WHERE [FRUTAPROPIAFecha] = @FRUTAPROPIAFecha AND [FRUTAPROPIAMes] = @FRUTAPROPIAMes AND [FRUTAPROPIAAno] = @FRUTAPROPIAAno AND [IndicadoresCodigo] = @IndicadoresCodigo AND [Cod_Area] = @Cod_Area AND [VIAJE] = @VIAJE AND [SETOR] = @SETOR AND [FINCA] = @FINCA AND [PROVE_COD] = @PROVE_COD AND [DIA] = @DIA AND [LOTE] = @LOTE AND [TAL] = @TAL", GxErrorMask.GX_NOMASK,prmT000Q13)
             ,new CursorDef("T000Q14", "DELETE FROM [FRUTAPROPIA]  WHERE [FRUTAPROPIAFecha] = @FRUTAPROPIAFecha AND [FRUTAPROPIAMes] = @FRUTAPROPIAMes AND [FRUTAPROPIAAno] = @FRUTAPROPIAAno AND [IndicadoresCodigo] = @IndicadoresCodigo AND [Cod_Area] = @Cod_Area AND [VIAJE] = @VIAJE AND [SETOR] = @SETOR AND [FINCA] = @FINCA AND [PROVE_COD] = @PROVE_COD AND [DIA] = @DIA AND [LOTE] = @LOTE AND [TAL] = @TAL", GxErrorMask.GX_NOMASK,prmT000Q14)
             ,new CursorDef("T000Q15", "SELECT [FRUTAPROPIAFecha], [FRUTAPROPIAMes], [FRUTAPROPIAAno], [IndicadoresCodigo], [Cod_Area], [VIAJE], [SETOR], [FINCA], [PROVE_COD], [DIA], [LOTE], [TAL] FROM [FRUTAPROPIA] ORDER BY [FRUTAPROPIAFecha], [FRUTAPROPIAMes], [FRUTAPROPIAAno], [IndicadoresCodigo], [Cod_Area], [VIAJE], [SETOR], [FINCA], [PROVE_COD], [DIA], [LOTE], [TAL]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q15,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000Q16", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q16,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000Q17", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q17,1, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getVarchar(12);
                ((string[]) buf[12])[0] = rslt.getVarchar(13);
                ((string[]) buf[13])[0] = rslt.getVarchar(14);
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(15);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(16);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(17);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(18);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(19);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(20);
                ((string[]) buf[20])[0] = rslt.getVarchar(21);
                ((string[]) buf[21])[0] = rslt.getVarchar(22);
                ((string[]) buf[22])[0] = rslt.getVarchar(23);
                ((string[]) buf[23])[0] = rslt.getVarchar(24);
                ((decimal[]) buf[24])[0] = rslt.getDecimal(25);
                ((string[]) buf[25])[0] = rslt.getVarchar(26);
                ((long[]) buf[26])[0] = rslt.getLong(27);
                ((string[]) buf[27])[0] = rslt.getVarchar(28);
                ((string[]) buf[28])[0] = rslt.getVarchar(29);
                ((string[]) buf[29])[0] = rslt.getVarchar(30);
                ((string[]) buf[30])[0] = rslt.getVarchar(31);
                ((string[]) buf[31])[0] = rslt.getVarchar(32);
                ((string[]) buf[32])[0] = rslt.getVarchar(33);
                return;
             case 1 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getVarchar(12);
                ((string[]) buf[12])[0] = rslt.getVarchar(13);
                ((string[]) buf[13])[0] = rslt.getVarchar(14);
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(15);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(16);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(17);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(18);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(19);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(20);
                ((string[]) buf[20])[0] = rslt.getVarchar(21);
                ((string[]) buf[21])[0] = rslt.getVarchar(22);
                ((string[]) buf[22])[0] = rslt.getVarchar(23);
                ((string[]) buf[23])[0] = rslt.getVarchar(24);
                ((decimal[]) buf[24])[0] = rslt.getDecimal(25);
                ((string[]) buf[25])[0] = rslt.getVarchar(26);
                ((long[]) buf[26])[0] = rslt.getLong(27);
                ((string[]) buf[27])[0] = rslt.getVarchar(28);
                ((string[]) buf[28])[0] = rslt.getVarchar(29);
                ((string[]) buf[29])[0] = rslt.getVarchar(30);
                ((string[]) buf[30])[0] = rslt.getVarchar(31);
                ((string[]) buf[31])[0] = rslt.getVarchar(32);
                ((string[]) buf[32])[0] = rslt.getVarchar(33);
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
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getVarchar(12);
                ((string[]) buf[12])[0] = rslt.getVarchar(13);
                ((string[]) buf[13])[0] = rslt.getVarchar(14);
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(15);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(16);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(17);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(18);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(19);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(20);
                ((string[]) buf[20])[0] = rslt.getVarchar(21);
                ((string[]) buf[21])[0] = rslt.getVarchar(22);
                ((string[]) buf[22])[0] = rslt.getVarchar(23);
                ((string[]) buf[23])[0] = rslt.getVarchar(24);
                ((decimal[]) buf[24])[0] = rslt.getDecimal(25);
                ((string[]) buf[25])[0] = rslt.getVarchar(26);
                ((long[]) buf[26])[0] = rslt.getLong(27);
                ((string[]) buf[27])[0] = rslt.getVarchar(28);
                ((string[]) buf[28])[0] = rslt.getVarchar(29);
                ((string[]) buf[29])[0] = rslt.getVarchar(30);
                ((string[]) buf[30])[0] = rslt.getVarchar(31);
                ((string[]) buf[31])[0] = rslt.getVarchar(32);
                ((string[]) buf[32])[0] = rslt.getVarchar(33);
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
                ((long[]) buf[5])[0] = rslt.getLong(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getVarchar(12);
                return;
             case 8 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getVarchar(12);
                return;
             case 9 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getVarchar(12);
                return;
             case 13 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getVarchar(12);
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
