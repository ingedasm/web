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
   public class incidenciapc : GXDataArea
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
            A90TiposEnfermedadesCod = GetPar( "TiposEnfermedadesCod");
            AssignAttri("", false, "A90TiposEnfermedadesCod", A90TiposEnfermedadesCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A90TiposEnfermedadesCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A91MATERIALPALMASCOD = GetPar( "MATERIALPALMASCOD");
            AssignAttri("", false, "A91MATERIALPALMASCOD", A91MATERIALPALMASCOD);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A91MATERIALPALMASCOD) ;
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
            Form.Meta.addItem("description", "INCIDENCIAPC", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtINCIDENCIAPCFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("IndicadroresPalmas", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public incidenciapc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("IndicadroresPalmas", true);
      }

      public incidenciapc( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "INCIDENCIAPC", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_INCIDENCIAPC.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_INCIDENCIAPC.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_INCIDENCIAPC.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_INCIDENCIAPC.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_INCIDENCIAPC.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 4, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx00v0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"INCIDENCIAPCFEC"+"'), id:'"+"INCIDENCIAPCFEC"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"INCIDENCIAPCMES"+"'), id:'"+"INCIDENCIAPCMES"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"INCIDENCIAPCANO"+"'), id:'"+"INCIDENCIAPCANO"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"COD_AREA"+"'), id:'"+"COD_AREA"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"INDICADORESCODIGO"+"'), id:'"+"INDICADORESCODIGO"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"TIPOSENFERMEDADESCOD"+"'), id:'"+"TIPOSENFERMEDADESCOD"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"MATERIALPALMASCOD"+"'), id:'"+"MATERIALPALMASCOD"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"INCIDENCIAPCZONA"+"'), id:'"+"INCIDENCIAPCZONA"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"INCIDENCIAPCLOTE"+"'), id:'"+"INCIDENCIAPCLOTE"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_INCIDENCIAPC.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtINCIDENCIAPCFec_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtINCIDENCIAPCFec_Internalname, "INCIDENCIAPCFec", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtINCIDENCIAPCFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtINCIDENCIAPCFec_Internalname, context.localUtil.Format(A104INCIDENCIAPCFec, "99/99/99"), context.localUtil.Format( A104INCIDENCIAPCFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtINCIDENCIAPCFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtINCIDENCIAPCFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_INCIDENCIAPC.htm");
         GxWebStd.gx_bitmap( context, edtINCIDENCIAPCFec_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtINCIDENCIAPCFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_INCIDENCIAPC.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtINCIDENCIAPCMes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtINCIDENCIAPCMes_Internalname, "INCIDENCIAPCMes", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtINCIDENCIAPCMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A105INCIDENCIAPCMes), 4, 0, ",", "")), StringUtil.LTrim( ((edtINCIDENCIAPCMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A105INCIDENCIAPCMes), "ZZZ9") : context.localUtil.Format( (decimal)(A105INCIDENCIAPCMes), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtINCIDENCIAPCMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtINCIDENCIAPCMes_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_INCIDENCIAPC.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtINCIDENCIAPCano_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtINCIDENCIAPCano_Internalname, "INCIDENCIAPCano", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtINCIDENCIAPCano_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A106INCIDENCIAPCano), 4, 0, ",", "")), StringUtil.LTrim( ((edtINCIDENCIAPCano_Enabled!=0) ? context.localUtil.Format( (decimal)(A106INCIDENCIAPCano), "ZZZ9") : context.localUtil.Format( (decimal)(A106INCIDENCIAPCano), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtINCIDENCIAPCano_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtINCIDENCIAPCano_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_INCIDENCIAPC.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCod_Area_Internalname, A5Cod_Area, StringUtil.RTrim( context.localUtil.Format( A5Cod_Area, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCod_Area_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCod_Area_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_INCIDENCIAPC.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_5_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_5_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_5_Internalname, sImgUrl, imgprompt_5_Link, "", "", context.GetTheme( ), imgprompt_5_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_INCIDENCIAPC.htm");
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
         GxWebStd.gx_single_line_edit( context, edtIndicadoresCodigo_Internalname, A4IndicadoresCodigo, StringUtil.RTrim( context.localUtil.Format( A4IndicadoresCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIndicadoresCodigo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIndicadoresCodigo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_INCIDENCIAPC.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_4_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_4_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_4_Internalname, sImgUrl, imgprompt_4_Link, "", "", context.GetTheme( ), imgprompt_4_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_INCIDENCIAPC.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTiposEnfermedadesCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTiposEnfermedadesCod_Internalname, "Tipos Enfermedades Cod", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTiposEnfermedadesCod_Internalname, A90TiposEnfermedadesCod, StringUtil.RTrim( context.localUtil.Format( A90TiposEnfermedadesCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTiposEnfermedadesCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTiposEnfermedadesCod_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_INCIDENCIAPC.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_90_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_90_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_90_Internalname, sImgUrl, imgprompt_90_Link, "", "", context.GetTheme( ), imgprompt_90_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_INCIDENCIAPC.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMATERIALPALMASCOD_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMATERIALPALMASCOD_Internalname, "MATERIALPALMASCOD", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMATERIALPALMASCOD_Internalname, A91MATERIALPALMASCOD, StringUtil.RTrim( context.localUtil.Format( A91MATERIALPALMASCOD, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMATERIALPALMASCOD_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMATERIALPALMASCOD_Enabled, 0, "text", "", 80, "chr", 1, "row", 140, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_INCIDENCIAPC.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_91_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_91_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_91_Internalname, sImgUrl, imgprompt_91_Link, "", "", context.GetTheme( ), imgprompt_91_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_INCIDENCIAPC.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtINCIDENCIAPCCasos_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtINCIDENCIAPCCasos_Internalname, "INCIDENCIAPCCasos", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtINCIDENCIAPCCasos_Internalname, StringUtil.LTrim( StringUtil.NToC( A180INCIDENCIAPCCasos, 12, 2, ",", "")), StringUtil.LTrim( ((edtINCIDENCIAPCCasos_Enabled!=0) ? context.localUtil.Format( A180INCIDENCIAPCCasos, "ZZZZZZZZ9.99") : context.localUtil.Format( A180INCIDENCIAPCCasos, "ZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtINCIDENCIAPCCasos_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtINCIDENCIAPCCasos_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_INCIDENCIAPC.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtINCIDENCIAPCPalmas_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtINCIDENCIAPCPalmas_Internalname, "INCIDENCIAPCPalmas", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtINCIDENCIAPCPalmas_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A181INCIDENCIAPCPalmas), 12, 0, ",", "")), StringUtil.LTrim( ((edtINCIDENCIAPCPalmas_Enabled!=0) ? context.localUtil.Format( (decimal)(A181INCIDENCIAPCPalmas), "ZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A181INCIDENCIAPCPalmas), "ZZZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtINCIDENCIAPCPalmas_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtINCIDENCIAPCPalmas_Enabled, 0, "text", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_INCIDENCIAPC.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtINCIDENCIAPCuser_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtINCIDENCIAPCuser_Internalname, "INCIDENCIAPCuser", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtINCIDENCIAPCuser_Internalname, A182INCIDENCIAPCuser, StringUtil.RTrim( context.localUtil.Format( A182INCIDENCIAPCuser, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtINCIDENCIAPCuser_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtINCIDENCIAPCuser_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_INCIDENCIAPC.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtINCIDENCIAPCreg_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtINCIDENCIAPCreg_Internalname, "INCIDENCIAPCreg", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtINCIDENCIAPCreg_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtINCIDENCIAPCreg_Internalname, context.localUtil.Format(A183INCIDENCIAPCreg, "99/99/99"), context.localUtil.Format( A183INCIDENCIAPCreg, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtINCIDENCIAPCreg_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtINCIDENCIAPCreg_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_INCIDENCIAPC.htm");
         GxWebStd.gx_bitmap( context, edtINCIDENCIAPCreg_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtINCIDENCIAPCreg_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_INCIDENCIAPC.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtINCIDENCIAPChor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtINCIDENCIAPChor_Internalname, "INCIDENCIAPChor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtINCIDENCIAPChor_Internalname, A184INCIDENCIAPChor, StringUtil.RTrim( context.localUtil.Format( A184INCIDENCIAPChor, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtINCIDENCIAPChor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtINCIDENCIAPChor_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_INCIDENCIAPC.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtINCIDENCIAPCZONA_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtINCIDENCIAPCZONA_Internalname, "INCIDENCIAPCZONA", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtINCIDENCIAPCZONA_Internalname, A107INCIDENCIAPCZONA, StringUtil.RTrim( context.localUtil.Format( A107INCIDENCIAPCZONA, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,94);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtINCIDENCIAPCZONA_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtINCIDENCIAPCZONA_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_INCIDENCIAPC.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtINCIDENCIAPCLOTE_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtINCIDENCIAPCLOTE_Internalname, "INCIDENCIAPCLOTE", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtINCIDENCIAPCLOTE_Internalname, A108INCIDENCIAPCLOTE, StringUtil.RTrim( context.localUtil.Format( A108INCIDENCIAPCLOTE, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtINCIDENCIAPCLOTE_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtINCIDENCIAPCLOTE_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_INCIDENCIAPC.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtINCIDENCIAPCUMA_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtINCIDENCIAPCUMA_Internalname, "INCIDENCIAPCUMA", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtINCIDENCIAPCUMA_Internalname, A264INCIDENCIAPCUMA, StringUtil.RTrim( context.localUtil.Format( A264INCIDENCIAPCUMA, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,104);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtINCIDENCIAPCUMA_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtINCIDENCIAPCUMA_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_INCIDENCIAPC.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtINCIDENCIAPCSIEMBRA_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtINCIDENCIAPCSIEMBRA_Internalname, "INCIDENCIAPCSIEMBRA", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtINCIDENCIAPCSIEMBRA_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A265INCIDENCIAPCSIEMBRA), 12, 0, ",", "")), StringUtil.LTrim( ((edtINCIDENCIAPCSIEMBRA_Enabled!=0) ? context.localUtil.Format( (decimal)(A265INCIDENCIAPCSIEMBRA), "ZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A265INCIDENCIAPCSIEMBRA), "ZZZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,109);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtINCIDENCIAPCSIEMBRA_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtINCIDENCIAPCSIEMBRA_Enabled, 0, "text", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_INCIDENCIAPC.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtINCIDENCIAPCGRUPOZONA_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtINCIDENCIAPCGRUPOZONA_Internalname, "INCIDENCIAPCGRUPOZONA", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtINCIDENCIAPCGRUPOZONA_Internalname, A266INCIDENCIAPCGRUPOZONA, StringUtil.RTrim( context.localUtil.Format( A266INCIDENCIAPCGRUPOZONA, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,114);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtINCIDENCIAPCGRUPOZONA_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtINCIDENCIAPCGRUPOZONA_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_INCIDENCIAPC.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 119,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_INCIDENCIAPC.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_INCIDENCIAPC.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 123,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_INCIDENCIAPC.htm");
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
            Z104INCIDENCIAPCFec = context.localUtil.CToD( cgiGet( "Z104INCIDENCIAPCFec"), 0);
            Z105INCIDENCIAPCMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z105INCIDENCIAPCMes"), ",", "."), 18, MidpointRounding.ToEven));
            Z106INCIDENCIAPCano = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z106INCIDENCIAPCano"), ",", "."), 18, MidpointRounding.ToEven));
            Z5Cod_Area = cgiGet( "Z5Cod_Area");
            Z4IndicadoresCodigo = cgiGet( "Z4IndicadoresCodigo");
            Z90TiposEnfermedadesCod = cgiGet( "Z90TiposEnfermedadesCod");
            Z91MATERIALPALMASCOD = cgiGet( "Z91MATERIALPALMASCOD");
            Z107INCIDENCIAPCZONA = cgiGet( "Z107INCIDENCIAPCZONA");
            Z108INCIDENCIAPCLOTE = cgiGet( "Z108INCIDENCIAPCLOTE");
            Z180INCIDENCIAPCCasos = context.localUtil.CToN( cgiGet( "Z180INCIDENCIAPCCasos"), ",", ".");
            Z181INCIDENCIAPCPalmas = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z181INCIDENCIAPCPalmas"), ",", "."), 18, MidpointRounding.ToEven));
            Z182INCIDENCIAPCuser = cgiGet( "Z182INCIDENCIAPCuser");
            Z183INCIDENCIAPCreg = context.localUtil.CToD( cgiGet( "Z183INCIDENCIAPCreg"), 0);
            Z184INCIDENCIAPChor = cgiGet( "Z184INCIDENCIAPChor");
            Z264INCIDENCIAPCUMA = cgiGet( "Z264INCIDENCIAPCUMA");
            Z265INCIDENCIAPCSIEMBRA = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z265INCIDENCIAPCSIEMBRA"), ",", "."), 18, MidpointRounding.ToEven));
            Z266INCIDENCIAPCGRUPOZONA = cgiGet( "Z266INCIDENCIAPCGRUPOZONA");
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( context.localUtil.VCDate( cgiGet( edtINCIDENCIAPCFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"INCIDENCIAPCFec"}), 1, "INCIDENCIAPCFEC");
               AnyError = 1;
               GX_FocusControl = edtINCIDENCIAPCFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A104INCIDENCIAPCFec = DateTime.MinValue;
               AssignAttri("", false, "A104INCIDENCIAPCFec", context.localUtil.Format(A104INCIDENCIAPCFec, "99/99/99"));
            }
            else
            {
               A104INCIDENCIAPCFec = context.localUtil.CToD( cgiGet( edtINCIDENCIAPCFec_Internalname), 2);
               AssignAttri("", false, "A104INCIDENCIAPCFec", context.localUtil.Format(A104INCIDENCIAPCFec, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtINCIDENCIAPCMes_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtINCIDENCIAPCMes_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "INCIDENCIAPCMES");
               AnyError = 1;
               GX_FocusControl = edtINCIDENCIAPCMes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A105INCIDENCIAPCMes = 0;
               AssignAttri("", false, "A105INCIDENCIAPCMes", StringUtil.LTrimStr( (decimal)(A105INCIDENCIAPCMes), 4, 0));
            }
            else
            {
               A105INCIDENCIAPCMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtINCIDENCIAPCMes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A105INCIDENCIAPCMes", StringUtil.LTrimStr( (decimal)(A105INCIDENCIAPCMes), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtINCIDENCIAPCano_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtINCIDENCIAPCano_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "INCIDENCIAPCANO");
               AnyError = 1;
               GX_FocusControl = edtINCIDENCIAPCano_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A106INCIDENCIAPCano = 0;
               AssignAttri("", false, "A106INCIDENCIAPCano", StringUtil.LTrimStr( (decimal)(A106INCIDENCIAPCano), 4, 0));
            }
            else
            {
               A106INCIDENCIAPCano = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtINCIDENCIAPCano_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A106INCIDENCIAPCano", StringUtil.LTrimStr( (decimal)(A106INCIDENCIAPCano), 4, 0));
            }
            A5Cod_Area = cgiGet( edtCod_Area_Internalname);
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = cgiGet( edtIndicadoresCodigo_Internalname);
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A90TiposEnfermedadesCod = cgiGet( edtTiposEnfermedadesCod_Internalname);
            AssignAttri("", false, "A90TiposEnfermedadesCod", A90TiposEnfermedadesCod);
            A91MATERIALPALMASCOD = cgiGet( edtMATERIALPALMASCOD_Internalname);
            AssignAttri("", false, "A91MATERIALPALMASCOD", A91MATERIALPALMASCOD);
            if ( ( ( context.localUtil.CToN( cgiGet( edtINCIDENCIAPCCasos_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtINCIDENCIAPCCasos_Internalname), ",", ".") > 999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "INCIDENCIAPCCASOS");
               AnyError = 1;
               GX_FocusControl = edtINCIDENCIAPCCasos_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A180INCIDENCIAPCCasos = 0;
               AssignAttri("", false, "A180INCIDENCIAPCCasos", StringUtil.LTrimStr( A180INCIDENCIAPCCasos, 12, 2));
            }
            else
            {
               A180INCIDENCIAPCCasos = context.localUtil.CToN( cgiGet( edtINCIDENCIAPCCasos_Internalname), ",", ".");
               AssignAttri("", false, "A180INCIDENCIAPCCasos", StringUtil.LTrimStr( A180INCIDENCIAPCCasos, 12, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtINCIDENCIAPCPalmas_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtINCIDENCIAPCPalmas_Internalname), ",", ".") > Convert.ToDecimal( 999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "INCIDENCIAPCPALMAS");
               AnyError = 1;
               GX_FocusControl = edtINCIDENCIAPCPalmas_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A181INCIDENCIAPCPalmas = 0;
               AssignAttri("", false, "A181INCIDENCIAPCPalmas", StringUtil.LTrimStr( (decimal)(A181INCIDENCIAPCPalmas), 12, 0));
            }
            else
            {
               A181INCIDENCIAPCPalmas = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtINCIDENCIAPCPalmas_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A181INCIDENCIAPCPalmas", StringUtil.LTrimStr( (decimal)(A181INCIDENCIAPCPalmas), 12, 0));
            }
            A182INCIDENCIAPCuser = cgiGet( edtINCIDENCIAPCuser_Internalname);
            AssignAttri("", false, "A182INCIDENCIAPCuser", A182INCIDENCIAPCuser);
            if ( context.localUtil.VCDate( cgiGet( edtINCIDENCIAPCreg_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"INCIDENCIAPCreg"}), 1, "INCIDENCIAPCREG");
               AnyError = 1;
               GX_FocusControl = edtINCIDENCIAPCreg_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A183INCIDENCIAPCreg = DateTime.MinValue;
               AssignAttri("", false, "A183INCIDENCIAPCreg", context.localUtil.Format(A183INCIDENCIAPCreg, "99/99/99"));
            }
            else
            {
               A183INCIDENCIAPCreg = context.localUtil.CToD( cgiGet( edtINCIDENCIAPCreg_Internalname), 2);
               AssignAttri("", false, "A183INCIDENCIAPCreg", context.localUtil.Format(A183INCIDENCIAPCreg, "99/99/99"));
            }
            A184INCIDENCIAPChor = cgiGet( edtINCIDENCIAPChor_Internalname);
            AssignAttri("", false, "A184INCIDENCIAPChor", A184INCIDENCIAPChor);
            A107INCIDENCIAPCZONA = cgiGet( edtINCIDENCIAPCZONA_Internalname);
            AssignAttri("", false, "A107INCIDENCIAPCZONA", A107INCIDENCIAPCZONA);
            A108INCIDENCIAPCLOTE = cgiGet( edtINCIDENCIAPCLOTE_Internalname);
            AssignAttri("", false, "A108INCIDENCIAPCLOTE", A108INCIDENCIAPCLOTE);
            A264INCIDENCIAPCUMA = cgiGet( edtINCIDENCIAPCUMA_Internalname);
            AssignAttri("", false, "A264INCIDENCIAPCUMA", A264INCIDENCIAPCUMA);
            if ( ( ( context.localUtil.CToN( cgiGet( edtINCIDENCIAPCSIEMBRA_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtINCIDENCIAPCSIEMBRA_Internalname), ",", ".") > Convert.ToDecimal( 999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "INCIDENCIAPCSIEMBRA");
               AnyError = 1;
               GX_FocusControl = edtINCIDENCIAPCSIEMBRA_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A265INCIDENCIAPCSIEMBRA = 0;
               AssignAttri("", false, "A265INCIDENCIAPCSIEMBRA", StringUtil.LTrimStr( (decimal)(A265INCIDENCIAPCSIEMBRA), 12, 0));
            }
            else
            {
               A265INCIDENCIAPCSIEMBRA = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtINCIDENCIAPCSIEMBRA_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A265INCIDENCIAPCSIEMBRA", StringUtil.LTrimStr( (decimal)(A265INCIDENCIAPCSIEMBRA), 12, 0));
            }
            A266INCIDENCIAPCGRUPOZONA = cgiGet( edtINCIDENCIAPCGRUPOZONA_Internalname);
            AssignAttri("", false, "A266INCIDENCIAPCGRUPOZONA", A266INCIDENCIAPCGRUPOZONA);
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
               A104INCIDENCIAPCFec = context.localUtil.ParseDateParm( GetPar( "INCIDENCIAPCFec"));
               AssignAttri("", false, "A104INCIDENCIAPCFec", context.localUtil.Format(A104INCIDENCIAPCFec, "99/99/99"));
               A105INCIDENCIAPCMes = (short)(Math.Round(NumberUtil.Val( GetPar( "INCIDENCIAPCMes"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A105INCIDENCIAPCMes", StringUtil.LTrimStr( (decimal)(A105INCIDENCIAPCMes), 4, 0));
               A106INCIDENCIAPCano = (short)(Math.Round(NumberUtil.Val( GetPar( "INCIDENCIAPCano"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A106INCIDENCIAPCano", StringUtil.LTrimStr( (decimal)(A106INCIDENCIAPCano), 4, 0));
               A5Cod_Area = GetPar( "Cod_Area");
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               A4IndicadoresCodigo = GetPar( "IndicadoresCodigo");
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               A90TiposEnfermedadesCod = GetPar( "TiposEnfermedadesCod");
               AssignAttri("", false, "A90TiposEnfermedadesCod", A90TiposEnfermedadesCod);
               A91MATERIALPALMASCOD = GetPar( "MATERIALPALMASCOD");
               AssignAttri("", false, "A91MATERIALPALMASCOD", A91MATERIALPALMASCOD);
               A107INCIDENCIAPCZONA = GetPar( "INCIDENCIAPCZONA");
               AssignAttri("", false, "A107INCIDENCIAPCZONA", A107INCIDENCIAPCZONA);
               A108INCIDENCIAPCLOTE = GetPar( "INCIDENCIAPCLOTE");
               AssignAttri("", false, "A108INCIDENCIAPCLOTE", A108INCIDENCIAPCLOTE);
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
               InitAll0U31( ) ;
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
         DisableAttributes0U31( ) ;
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

      protected void ResetCaption0U0( )
      {
      }

      protected void ZM0U31( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z180INCIDENCIAPCCasos = T000U3_A180INCIDENCIAPCCasos[0];
               Z181INCIDENCIAPCPalmas = T000U3_A181INCIDENCIAPCPalmas[0];
               Z182INCIDENCIAPCuser = T000U3_A182INCIDENCIAPCuser[0];
               Z183INCIDENCIAPCreg = T000U3_A183INCIDENCIAPCreg[0];
               Z184INCIDENCIAPChor = T000U3_A184INCIDENCIAPChor[0];
               Z264INCIDENCIAPCUMA = T000U3_A264INCIDENCIAPCUMA[0];
               Z265INCIDENCIAPCSIEMBRA = T000U3_A265INCIDENCIAPCSIEMBRA[0];
               Z266INCIDENCIAPCGRUPOZONA = T000U3_A266INCIDENCIAPCGRUPOZONA[0];
            }
            else
            {
               Z180INCIDENCIAPCCasos = A180INCIDENCIAPCCasos;
               Z181INCIDENCIAPCPalmas = A181INCIDENCIAPCPalmas;
               Z182INCIDENCIAPCuser = A182INCIDENCIAPCuser;
               Z183INCIDENCIAPCreg = A183INCIDENCIAPCreg;
               Z184INCIDENCIAPChor = A184INCIDENCIAPChor;
               Z264INCIDENCIAPCUMA = A264INCIDENCIAPCUMA;
               Z265INCIDENCIAPCSIEMBRA = A265INCIDENCIAPCSIEMBRA;
               Z266INCIDENCIAPCGRUPOZONA = A266INCIDENCIAPCGRUPOZONA;
            }
         }
         if ( GX_JID == -3 )
         {
            Z104INCIDENCIAPCFec = A104INCIDENCIAPCFec;
            Z105INCIDENCIAPCMes = A105INCIDENCIAPCMes;
            Z106INCIDENCIAPCano = A106INCIDENCIAPCano;
            Z107INCIDENCIAPCZONA = A107INCIDENCIAPCZONA;
            Z108INCIDENCIAPCLOTE = A108INCIDENCIAPCLOTE;
            Z180INCIDENCIAPCCasos = A180INCIDENCIAPCCasos;
            Z181INCIDENCIAPCPalmas = A181INCIDENCIAPCPalmas;
            Z182INCIDENCIAPCuser = A182INCIDENCIAPCuser;
            Z183INCIDENCIAPCreg = A183INCIDENCIAPCreg;
            Z184INCIDENCIAPChor = A184INCIDENCIAPChor;
            Z264INCIDENCIAPCUMA = A264INCIDENCIAPCUMA;
            Z265INCIDENCIAPCSIEMBRA = A265INCIDENCIAPCSIEMBRA;
            Z266INCIDENCIAPCGRUPOZONA = A266INCIDENCIAPCGRUPOZONA;
            Z5Cod_Area = A5Cod_Area;
            Z4IndicadoresCodigo = A4IndicadoresCodigo;
            Z90TiposEnfermedadesCod = A90TiposEnfermedadesCod;
            Z91MATERIALPALMASCOD = A91MATERIALPALMASCOD;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_5_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"COD_AREA"+"'), id:'"+"COD_AREA"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"true"+");");
         imgprompt_4_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0030.aspx"+"',["+"{Ctrl:gx.dom.el('"+"INDICADORESCODIGO"+"'), id:'"+"INDICADORESCODIGO"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"true"+");");
         imgprompt_90_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0170.aspx"+"',["+"{Ctrl:gx.dom.el('"+"TIPOSENFERMEDADESCOD"+"'), id:'"+"TIPOSENFERMEDADESCOD"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"true"+");");
         imgprompt_91_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0180.aspx"+"',["+"{Ctrl:gx.dom.el('"+"MATERIALPALMASCOD"+"'), id:'"+"MATERIALPALMASCOD"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"true"+");");
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

      protected void Load0U31( )
      {
         /* Using cursor T000U8 */
         pr_default.execute(6, new Object[] {A104INCIDENCIAPCFec, A105INCIDENCIAPCMes, A106INCIDENCIAPCano, A5Cod_Area, A4IndicadoresCodigo, A90TiposEnfermedadesCod, A91MATERIALPALMASCOD, A107INCIDENCIAPCZONA, A108INCIDENCIAPCLOTE});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound31 = 1;
            A180INCIDENCIAPCCasos = T000U8_A180INCIDENCIAPCCasos[0];
            AssignAttri("", false, "A180INCIDENCIAPCCasos", StringUtil.LTrimStr( A180INCIDENCIAPCCasos, 12, 2));
            A181INCIDENCIAPCPalmas = T000U8_A181INCIDENCIAPCPalmas[0];
            AssignAttri("", false, "A181INCIDENCIAPCPalmas", StringUtil.LTrimStr( (decimal)(A181INCIDENCIAPCPalmas), 12, 0));
            A182INCIDENCIAPCuser = T000U8_A182INCIDENCIAPCuser[0];
            AssignAttri("", false, "A182INCIDENCIAPCuser", A182INCIDENCIAPCuser);
            A183INCIDENCIAPCreg = T000U8_A183INCIDENCIAPCreg[0];
            AssignAttri("", false, "A183INCIDENCIAPCreg", context.localUtil.Format(A183INCIDENCIAPCreg, "99/99/99"));
            A184INCIDENCIAPChor = T000U8_A184INCIDENCIAPChor[0];
            AssignAttri("", false, "A184INCIDENCIAPChor", A184INCIDENCIAPChor);
            A264INCIDENCIAPCUMA = T000U8_A264INCIDENCIAPCUMA[0];
            AssignAttri("", false, "A264INCIDENCIAPCUMA", A264INCIDENCIAPCUMA);
            A265INCIDENCIAPCSIEMBRA = T000U8_A265INCIDENCIAPCSIEMBRA[0];
            AssignAttri("", false, "A265INCIDENCIAPCSIEMBRA", StringUtil.LTrimStr( (decimal)(A265INCIDENCIAPCSIEMBRA), 12, 0));
            A266INCIDENCIAPCGRUPOZONA = T000U8_A266INCIDENCIAPCGRUPOZONA[0];
            AssignAttri("", false, "A266INCIDENCIAPCGRUPOZONA", A266INCIDENCIAPCGRUPOZONA);
            ZM0U31( -3) ;
         }
         pr_default.close(6);
         OnLoadActions0U31( ) ;
      }

      protected void OnLoadActions0U31( )
      {
      }

      protected void CheckExtendedTable0U31( )
      {
         nIsDirty_31 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A104INCIDENCIAPCFec) || ( DateTimeUtil.ResetTime ( A104INCIDENCIAPCFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo INCIDENCIAPCFec fuera de rango", "OutOfRange", 1, "INCIDENCIAPCFEC");
            AnyError = 1;
            GX_FocusControl = edtINCIDENCIAPCFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000U4 */
         pr_default.execute(2, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T000U5 */
         pr_default.execute(3, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         /* Using cursor T000U6 */
         pr_default.execute(4, new Object[] {A90TiposEnfermedadesCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipos Enfermedades'.", "ForeignKeyNotFound", 1, "TIPOSENFERMEDADESCOD");
            AnyError = 1;
            GX_FocusControl = edtTiposEnfermedadesCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(4);
         /* Using cursor T000U7 */
         pr_default.execute(5, new Object[] {A91MATERIALPALMASCOD});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'MATERIALPALMAS'.", "ForeignKeyNotFound", 1, "MATERIALPALMASCOD");
            AnyError = 1;
            GX_FocusControl = edtMATERIALPALMASCOD_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(5);
         if ( ! ( (DateTime.MinValue==A183INCIDENCIAPCreg) || ( DateTimeUtil.ResetTime ( A183INCIDENCIAPCreg ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo INCIDENCIAPCreg fuera de rango", "OutOfRange", 1, "INCIDENCIAPCREG");
            AnyError = 1;
            GX_FocusControl = edtINCIDENCIAPCreg_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0U31( )
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
         /* Using cursor T000U9 */
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
         /* Using cursor T000U10 */
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

      protected void gxLoad_6( string A90TiposEnfermedadesCod )
      {
         /* Using cursor T000U11 */
         pr_default.execute(9, new Object[] {A90TiposEnfermedadesCod});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipos Enfermedades'.", "ForeignKeyNotFound", 1, "TIPOSENFERMEDADESCOD");
            AnyError = 1;
            GX_FocusControl = edtTiposEnfermedadesCod_Internalname;
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

      protected void gxLoad_7( string A91MATERIALPALMASCOD )
      {
         /* Using cursor T000U12 */
         pr_default.execute(10, new Object[] {A91MATERIALPALMASCOD});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem("No existe 'MATERIALPALMAS'.", "ForeignKeyNotFound", 1, "MATERIALPALMASCOD");
            AnyError = 1;
            GX_FocusControl = edtMATERIALPALMASCOD_Internalname;
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

      protected void GetKey0U31( )
      {
         /* Using cursor T000U13 */
         pr_default.execute(11, new Object[] {A104INCIDENCIAPCFec, A105INCIDENCIAPCMes, A106INCIDENCIAPCano, A5Cod_Area, A4IndicadoresCodigo, A90TiposEnfermedadesCod, A91MATERIALPALMASCOD, A107INCIDENCIAPCZONA, A108INCIDENCIAPCLOTE});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound31 = 1;
         }
         else
         {
            RcdFound31 = 0;
         }
         pr_default.close(11);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000U3 */
         pr_default.execute(1, new Object[] {A104INCIDENCIAPCFec, A105INCIDENCIAPCMes, A106INCIDENCIAPCano, A5Cod_Area, A4IndicadoresCodigo, A90TiposEnfermedadesCod, A91MATERIALPALMASCOD, A107INCIDENCIAPCZONA, A108INCIDENCIAPCLOTE});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0U31( 3) ;
            RcdFound31 = 1;
            A104INCIDENCIAPCFec = T000U3_A104INCIDENCIAPCFec[0];
            AssignAttri("", false, "A104INCIDENCIAPCFec", context.localUtil.Format(A104INCIDENCIAPCFec, "99/99/99"));
            A105INCIDENCIAPCMes = T000U3_A105INCIDENCIAPCMes[0];
            AssignAttri("", false, "A105INCIDENCIAPCMes", StringUtil.LTrimStr( (decimal)(A105INCIDENCIAPCMes), 4, 0));
            A106INCIDENCIAPCano = T000U3_A106INCIDENCIAPCano[0];
            AssignAttri("", false, "A106INCIDENCIAPCano", StringUtil.LTrimStr( (decimal)(A106INCIDENCIAPCano), 4, 0));
            A107INCIDENCIAPCZONA = T000U3_A107INCIDENCIAPCZONA[0];
            AssignAttri("", false, "A107INCIDENCIAPCZONA", A107INCIDENCIAPCZONA);
            A108INCIDENCIAPCLOTE = T000U3_A108INCIDENCIAPCLOTE[0];
            AssignAttri("", false, "A108INCIDENCIAPCLOTE", A108INCIDENCIAPCLOTE);
            A180INCIDENCIAPCCasos = T000U3_A180INCIDENCIAPCCasos[0];
            AssignAttri("", false, "A180INCIDENCIAPCCasos", StringUtil.LTrimStr( A180INCIDENCIAPCCasos, 12, 2));
            A181INCIDENCIAPCPalmas = T000U3_A181INCIDENCIAPCPalmas[0];
            AssignAttri("", false, "A181INCIDENCIAPCPalmas", StringUtil.LTrimStr( (decimal)(A181INCIDENCIAPCPalmas), 12, 0));
            A182INCIDENCIAPCuser = T000U3_A182INCIDENCIAPCuser[0];
            AssignAttri("", false, "A182INCIDENCIAPCuser", A182INCIDENCIAPCuser);
            A183INCIDENCIAPCreg = T000U3_A183INCIDENCIAPCreg[0];
            AssignAttri("", false, "A183INCIDENCIAPCreg", context.localUtil.Format(A183INCIDENCIAPCreg, "99/99/99"));
            A184INCIDENCIAPChor = T000U3_A184INCIDENCIAPChor[0];
            AssignAttri("", false, "A184INCIDENCIAPChor", A184INCIDENCIAPChor);
            A264INCIDENCIAPCUMA = T000U3_A264INCIDENCIAPCUMA[0];
            AssignAttri("", false, "A264INCIDENCIAPCUMA", A264INCIDENCIAPCUMA);
            A265INCIDENCIAPCSIEMBRA = T000U3_A265INCIDENCIAPCSIEMBRA[0];
            AssignAttri("", false, "A265INCIDENCIAPCSIEMBRA", StringUtil.LTrimStr( (decimal)(A265INCIDENCIAPCSIEMBRA), 12, 0));
            A266INCIDENCIAPCGRUPOZONA = T000U3_A266INCIDENCIAPCGRUPOZONA[0];
            AssignAttri("", false, "A266INCIDENCIAPCGRUPOZONA", A266INCIDENCIAPCGRUPOZONA);
            A5Cod_Area = T000U3_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = T000U3_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A90TiposEnfermedadesCod = T000U3_A90TiposEnfermedadesCod[0];
            AssignAttri("", false, "A90TiposEnfermedadesCod", A90TiposEnfermedadesCod);
            A91MATERIALPALMASCOD = T000U3_A91MATERIALPALMASCOD[0];
            AssignAttri("", false, "A91MATERIALPALMASCOD", A91MATERIALPALMASCOD);
            Z104INCIDENCIAPCFec = A104INCIDENCIAPCFec;
            Z105INCIDENCIAPCMes = A105INCIDENCIAPCMes;
            Z106INCIDENCIAPCano = A106INCIDENCIAPCano;
            Z5Cod_Area = A5Cod_Area;
            Z4IndicadoresCodigo = A4IndicadoresCodigo;
            Z90TiposEnfermedadesCod = A90TiposEnfermedadesCod;
            Z91MATERIALPALMASCOD = A91MATERIALPALMASCOD;
            Z107INCIDENCIAPCZONA = A107INCIDENCIAPCZONA;
            Z108INCIDENCIAPCLOTE = A108INCIDENCIAPCLOTE;
            sMode31 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0U31( ) ;
            if ( AnyError == 1 )
            {
               RcdFound31 = 0;
               InitializeNonKey0U31( ) ;
            }
            Gx_mode = sMode31;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound31 = 0;
            InitializeNonKey0U31( ) ;
            sMode31 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode31;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0U31( ) ;
         if ( RcdFound31 == 0 )
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
         RcdFound31 = 0;
         /* Using cursor T000U14 */
         pr_default.execute(12, new Object[] {A104INCIDENCIAPCFec, A105INCIDENCIAPCMes, A106INCIDENCIAPCano, A5Cod_Area, A4IndicadoresCodigo, A90TiposEnfermedadesCod, A91MATERIALPALMASCOD, A107INCIDENCIAPCZONA, A108INCIDENCIAPCLOTE});
         if ( (pr_default.getStatus(12) != 101) )
         {
            while ( (pr_default.getStatus(12) != 101) && ( ( DateTimeUtil.ResetTime ( T000U14_A104INCIDENCIAPCFec[0] ) < DateTimeUtil.ResetTime ( A104INCIDENCIAPCFec ) ) || ( DateTimeUtil.ResetTime ( T000U14_A104INCIDENCIAPCFec[0] ) == DateTimeUtil.ResetTime ( A104INCIDENCIAPCFec ) ) && ( T000U14_A105INCIDENCIAPCMes[0] < A105INCIDENCIAPCMes ) || ( T000U14_A105INCIDENCIAPCMes[0] == A105INCIDENCIAPCMes ) &&
            ( DateTimeUtil.ResetTime ( T000U14_A104INCIDENCIAPCFec[0] ) == DateTimeUtil.ResetTime ( A104INCIDENCIAPCFec ) ) && ( T000U14_A106INCIDENCIAPCano[0] < A106INCIDENCIAPCano ) || ( T000U14_A106INCIDENCIAPCano[0] == A106INCIDENCIAPCano ) && ( T000U14_A105INCIDENCIAPCMes[0] == A105INCIDENCIAPCMes ) && ( DateTimeUtil.ResetTime ( T000U14_A104INCIDENCIAPCFec[0] ) ==
            DateTimeUtil.ResetTime ( A104INCIDENCIAPCFec ) ) && ( StringUtil.StrCmp(T000U14_A5Cod_Area[0], A5Cod_Area) < 0 ) || ( StringUtil.StrCmp(T000U14_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000U14_A106INCIDENCIAPCano[0] == A106INCIDENCIAPCano ) && ( T000U14_A105INCIDENCIAPCMes[0] == A105INCIDENCIAPCMes ) && ( DateTimeUtil.ResetTime ( T000U14_A104INCIDENCIAPCFec[0] ) ==
            DateTimeUtil.ResetTime ( A104INCIDENCIAPCFec ) ) && ( StringUtil.StrCmp(T000U14_A4IndicadoresCodigo[0], A4IndicadoresCodigo) < 0 ) || ( StringUtil.StrCmp(T000U14_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T000U14_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000U14_A106INCIDENCIAPCano[0] == A106INCIDENCIAPCano ) && ( T000U14_A105INCIDENCIAPCMes[0] ==
            A105INCIDENCIAPCMes ) && ( DateTimeUtil.ResetTime ( T000U14_A104INCIDENCIAPCFec[0] ) == DateTimeUtil.ResetTime ( A104INCIDENCIAPCFec ) ) && ( StringUtil.StrCmp(T000U14_A90TiposEnfermedadesCod[0], A90TiposEnfermedadesCod) < 0 ) || ( StringUtil.StrCmp(T000U14_A90TiposEnfermedadesCod[0], A90TiposEnfermedadesCod) == 0 ) && ( StringUtil.StrCmp(T000U14_A4IndicadoresCodigo[0], A4IndicadoresCodigo) ==
            0 ) && ( StringUtil.StrCmp(T000U14_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000U14_A106INCIDENCIAPCano[0] == A106INCIDENCIAPCano ) && ( T000U14_A105INCIDENCIAPCMes[0] == A105INCIDENCIAPCMes ) && ( DateTimeUtil.ResetTime ( T000U14_A104INCIDENCIAPCFec[0] ) == DateTimeUtil.ResetTime ( A104INCIDENCIAPCFec ) ) && ( StringUtil.StrCmp(T000U14_A91MATERIALPALMASCOD[0], A91MATERIALPALMASCOD) < 0 ) ||
            ( StringUtil.StrCmp(T000U14_A91MATERIALPALMASCOD[0], A91MATERIALPALMASCOD) == 0 ) && ( StringUtil.StrCmp(T000U14_A90TiposEnfermedadesCod[0], A90TiposEnfermedadesCod) == 0 ) && ( StringUtil.StrCmp(T000U14_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T000U14_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000U14_A106INCIDENCIAPCano[0] == A106INCIDENCIAPCano ) &&
            ( T000U14_A105INCIDENCIAPCMes[0] == A105INCIDENCIAPCMes ) && ( DateTimeUtil.ResetTime ( T000U14_A104INCIDENCIAPCFec[0] ) == DateTimeUtil.ResetTime ( A104INCIDENCIAPCFec ) ) && ( StringUtil.StrCmp(T000U14_A107INCIDENCIAPCZONA[0], A107INCIDENCIAPCZONA) < 0 ) || ( StringUtil.StrCmp(T000U14_A107INCIDENCIAPCZONA[0], A107INCIDENCIAPCZONA) == 0 ) &&
            ( StringUtil.StrCmp(T000U14_A91MATERIALPALMASCOD[0], A91MATERIALPALMASCOD) == 0 ) && ( StringUtil.StrCmp(T000U14_A90TiposEnfermedadesCod[0], A90TiposEnfermedadesCod) == 0 ) && ( StringUtil.StrCmp(T000U14_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T000U14_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000U14_A106INCIDENCIAPCano[0] == A106INCIDENCIAPCano ) &&
            ( T000U14_A105INCIDENCIAPCMes[0] == A105INCIDENCIAPCMes ) && ( DateTimeUtil.ResetTime ( T000U14_A104INCIDENCIAPCFec[0] ) == DateTimeUtil.ResetTime ( A104INCIDENCIAPCFec ) ) && ( StringUtil.StrCmp(T000U14_A108INCIDENCIAPCLOTE[0], A108INCIDENCIAPCLOTE) < 0 ) )
            )
            {
               pr_default.readNext(12);
            }
            if ( (pr_default.getStatus(12) != 101) && ( ( DateTimeUtil.ResetTime ( T000U14_A104INCIDENCIAPCFec[0] ) > DateTimeUtil.ResetTime ( A104INCIDENCIAPCFec ) ) || ( DateTimeUtil.ResetTime ( T000U14_A104INCIDENCIAPCFec[0] ) == DateTimeUtil.ResetTime ( A104INCIDENCIAPCFec ) ) && ( T000U14_A105INCIDENCIAPCMes[0] > A105INCIDENCIAPCMes ) || ( T000U14_A105INCIDENCIAPCMes[0] == A105INCIDENCIAPCMes ) &&
            ( DateTimeUtil.ResetTime ( T000U14_A104INCIDENCIAPCFec[0] ) == DateTimeUtil.ResetTime ( A104INCIDENCIAPCFec ) ) && ( T000U14_A106INCIDENCIAPCano[0] > A106INCIDENCIAPCano ) || ( T000U14_A106INCIDENCIAPCano[0] == A106INCIDENCIAPCano ) && ( T000U14_A105INCIDENCIAPCMes[0] == A105INCIDENCIAPCMes ) && ( DateTimeUtil.ResetTime ( T000U14_A104INCIDENCIAPCFec[0] ) ==
            DateTimeUtil.ResetTime ( A104INCIDENCIAPCFec ) ) && ( StringUtil.StrCmp(T000U14_A5Cod_Area[0], A5Cod_Area) > 0 ) || ( StringUtil.StrCmp(T000U14_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000U14_A106INCIDENCIAPCano[0] == A106INCIDENCIAPCano ) && ( T000U14_A105INCIDENCIAPCMes[0] == A105INCIDENCIAPCMes ) && ( DateTimeUtil.ResetTime ( T000U14_A104INCIDENCIAPCFec[0] ) ==
            DateTimeUtil.ResetTime ( A104INCIDENCIAPCFec ) ) && ( StringUtil.StrCmp(T000U14_A4IndicadoresCodigo[0], A4IndicadoresCodigo) > 0 ) || ( StringUtil.StrCmp(T000U14_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T000U14_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000U14_A106INCIDENCIAPCano[0] == A106INCIDENCIAPCano ) && ( T000U14_A105INCIDENCIAPCMes[0] ==
            A105INCIDENCIAPCMes ) && ( DateTimeUtil.ResetTime ( T000U14_A104INCIDENCIAPCFec[0] ) == DateTimeUtil.ResetTime ( A104INCIDENCIAPCFec ) ) && ( StringUtil.StrCmp(T000U14_A90TiposEnfermedadesCod[0], A90TiposEnfermedadesCod) > 0 ) || ( StringUtil.StrCmp(T000U14_A90TiposEnfermedadesCod[0], A90TiposEnfermedadesCod) == 0 ) && ( StringUtil.StrCmp(T000U14_A4IndicadoresCodigo[0], A4IndicadoresCodigo) ==
            0 ) && ( StringUtil.StrCmp(T000U14_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000U14_A106INCIDENCIAPCano[0] == A106INCIDENCIAPCano ) && ( T000U14_A105INCIDENCIAPCMes[0] == A105INCIDENCIAPCMes ) && ( DateTimeUtil.ResetTime ( T000U14_A104INCIDENCIAPCFec[0] ) == DateTimeUtil.ResetTime ( A104INCIDENCIAPCFec ) ) && ( StringUtil.StrCmp(T000U14_A91MATERIALPALMASCOD[0], A91MATERIALPALMASCOD) > 0 ) ||
            ( StringUtil.StrCmp(T000U14_A91MATERIALPALMASCOD[0], A91MATERIALPALMASCOD) == 0 ) && ( StringUtil.StrCmp(T000U14_A90TiposEnfermedadesCod[0], A90TiposEnfermedadesCod) == 0 ) && ( StringUtil.StrCmp(T000U14_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T000U14_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000U14_A106INCIDENCIAPCano[0] == A106INCIDENCIAPCano ) &&
            ( T000U14_A105INCIDENCIAPCMes[0] == A105INCIDENCIAPCMes ) && ( DateTimeUtil.ResetTime ( T000U14_A104INCIDENCIAPCFec[0] ) == DateTimeUtil.ResetTime ( A104INCIDENCIAPCFec ) ) && ( StringUtil.StrCmp(T000U14_A107INCIDENCIAPCZONA[0], A107INCIDENCIAPCZONA) > 0 ) || ( StringUtil.StrCmp(T000U14_A107INCIDENCIAPCZONA[0], A107INCIDENCIAPCZONA) == 0 ) &&
            ( StringUtil.StrCmp(T000U14_A91MATERIALPALMASCOD[0], A91MATERIALPALMASCOD) == 0 ) && ( StringUtil.StrCmp(T000U14_A90TiposEnfermedadesCod[0], A90TiposEnfermedadesCod) == 0 ) && ( StringUtil.StrCmp(T000U14_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T000U14_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000U14_A106INCIDENCIAPCano[0] == A106INCIDENCIAPCano ) &&
            ( T000U14_A105INCIDENCIAPCMes[0] == A105INCIDENCIAPCMes ) && ( DateTimeUtil.ResetTime ( T000U14_A104INCIDENCIAPCFec[0] ) == DateTimeUtil.ResetTime ( A104INCIDENCIAPCFec ) ) && ( StringUtil.StrCmp(T000U14_A108INCIDENCIAPCLOTE[0], A108INCIDENCIAPCLOTE) > 0 ) )
            )
            {
               A104INCIDENCIAPCFec = T000U14_A104INCIDENCIAPCFec[0];
               AssignAttri("", false, "A104INCIDENCIAPCFec", context.localUtil.Format(A104INCIDENCIAPCFec, "99/99/99"));
               A105INCIDENCIAPCMes = T000U14_A105INCIDENCIAPCMes[0];
               AssignAttri("", false, "A105INCIDENCIAPCMes", StringUtil.LTrimStr( (decimal)(A105INCIDENCIAPCMes), 4, 0));
               A106INCIDENCIAPCano = T000U14_A106INCIDENCIAPCano[0];
               AssignAttri("", false, "A106INCIDENCIAPCano", StringUtil.LTrimStr( (decimal)(A106INCIDENCIAPCano), 4, 0));
               A5Cod_Area = T000U14_A5Cod_Area[0];
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               A4IndicadoresCodigo = T000U14_A4IndicadoresCodigo[0];
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               A90TiposEnfermedadesCod = T000U14_A90TiposEnfermedadesCod[0];
               AssignAttri("", false, "A90TiposEnfermedadesCod", A90TiposEnfermedadesCod);
               A91MATERIALPALMASCOD = T000U14_A91MATERIALPALMASCOD[0];
               AssignAttri("", false, "A91MATERIALPALMASCOD", A91MATERIALPALMASCOD);
               A107INCIDENCIAPCZONA = T000U14_A107INCIDENCIAPCZONA[0];
               AssignAttri("", false, "A107INCIDENCIAPCZONA", A107INCIDENCIAPCZONA);
               A108INCIDENCIAPCLOTE = T000U14_A108INCIDENCIAPCLOTE[0];
               AssignAttri("", false, "A108INCIDENCIAPCLOTE", A108INCIDENCIAPCLOTE);
               RcdFound31 = 1;
            }
         }
         pr_default.close(12);
      }

      protected void move_previous( )
      {
         RcdFound31 = 0;
         /* Using cursor T000U15 */
         pr_default.execute(13, new Object[] {A104INCIDENCIAPCFec, A105INCIDENCIAPCMes, A106INCIDENCIAPCano, A5Cod_Area, A4IndicadoresCodigo, A90TiposEnfermedadesCod, A91MATERIALPALMASCOD, A107INCIDENCIAPCZONA, A108INCIDENCIAPCLOTE});
         if ( (pr_default.getStatus(13) != 101) )
         {
            while ( (pr_default.getStatus(13) != 101) && ( ( DateTimeUtil.ResetTime ( T000U15_A104INCIDENCIAPCFec[0] ) > DateTimeUtil.ResetTime ( A104INCIDENCIAPCFec ) ) || ( DateTimeUtil.ResetTime ( T000U15_A104INCIDENCIAPCFec[0] ) == DateTimeUtil.ResetTime ( A104INCIDENCIAPCFec ) ) && ( T000U15_A105INCIDENCIAPCMes[0] > A105INCIDENCIAPCMes ) || ( T000U15_A105INCIDENCIAPCMes[0] == A105INCIDENCIAPCMes ) &&
            ( DateTimeUtil.ResetTime ( T000U15_A104INCIDENCIAPCFec[0] ) == DateTimeUtil.ResetTime ( A104INCIDENCIAPCFec ) ) && ( T000U15_A106INCIDENCIAPCano[0] > A106INCIDENCIAPCano ) || ( T000U15_A106INCIDENCIAPCano[0] == A106INCIDENCIAPCano ) && ( T000U15_A105INCIDENCIAPCMes[0] == A105INCIDENCIAPCMes ) && ( DateTimeUtil.ResetTime ( T000U15_A104INCIDENCIAPCFec[0] ) ==
            DateTimeUtil.ResetTime ( A104INCIDENCIAPCFec ) ) && ( StringUtil.StrCmp(T000U15_A5Cod_Area[0], A5Cod_Area) > 0 ) || ( StringUtil.StrCmp(T000U15_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000U15_A106INCIDENCIAPCano[0] == A106INCIDENCIAPCano ) && ( T000U15_A105INCIDENCIAPCMes[0] == A105INCIDENCIAPCMes ) && ( DateTimeUtil.ResetTime ( T000U15_A104INCIDENCIAPCFec[0] ) ==
            DateTimeUtil.ResetTime ( A104INCIDENCIAPCFec ) ) && ( StringUtil.StrCmp(T000U15_A4IndicadoresCodigo[0], A4IndicadoresCodigo) > 0 ) || ( StringUtil.StrCmp(T000U15_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T000U15_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000U15_A106INCIDENCIAPCano[0] == A106INCIDENCIAPCano ) && ( T000U15_A105INCIDENCIAPCMes[0] ==
            A105INCIDENCIAPCMes ) && ( DateTimeUtil.ResetTime ( T000U15_A104INCIDENCIAPCFec[0] ) == DateTimeUtil.ResetTime ( A104INCIDENCIAPCFec ) ) && ( StringUtil.StrCmp(T000U15_A90TiposEnfermedadesCod[0], A90TiposEnfermedadesCod) > 0 ) || ( StringUtil.StrCmp(T000U15_A90TiposEnfermedadesCod[0], A90TiposEnfermedadesCod) == 0 ) && ( StringUtil.StrCmp(T000U15_A4IndicadoresCodigo[0], A4IndicadoresCodigo) ==
            0 ) && ( StringUtil.StrCmp(T000U15_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000U15_A106INCIDENCIAPCano[0] == A106INCIDENCIAPCano ) && ( T000U15_A105INCIDENCIAPCMes[0] == A105INCIDENCIAPCMes ) && ( DateTimeUtil.ResetTime ( T000U15_A104INCIDENCIAPCFec[0] ) == DateTimeUtil.ResetTime ( A104INCIDENCIAPCFec ) ) && ( StringUtil.StrCmp(T000U15_A91MATERIALPALMASCOD[0], A91MATERIALPALMASCOD) > 0 ) ||
            ( StringUtil.StrCmp(T000U15_A91MATERIALPALMASCOD[0], A91MATERIALPALMASCOD) == 0 ) && ( StringUtil.StrCmp(T000U15_A90TiposEnfermedadesCod[0], A90TiposEnfermedadesCod) == 0 ) && ( StringUtil.StrCmp(T000U15_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T000U15_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000U15_A106INCIDENCIAPCano[0] == A106INCIDENCIAPCano ) &&
            ( T000U15_A105INCIDENCIAPCMes[0] == A105INCIDENCIAPCMes ) && ( DateTimeUtil.ResetTime ( T000U15_A104INCIDENCIAPCFec[0] ) == DateTimeUtil.ResetTime ( A104INCIDENCIAPCFec ) ) && ( StringUtil.StrCmp(T000U15_A107INCIDENCIAPCZONA[0], A107INCIDENCIAPCZONA) > 0 ) || ( StringUtil.StrCmp(T000U15_A107INCIDENCIAPCZONA[0], A107INCIDENCIAPCZONA) == 0 ) &&
            ( StringUtil.StrCmp(T000U15_A91MATERIALPALMASCOD[0], A91MATERIALPALMASCOD) == 0 ) && ( StringUtil.StrCmp(T000U15_A90TiposEnfermedadesCod[0], A90TiposEnfermedadesCod) == 0 ) && ( StringUtil.StrCmp(T000U15_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T000U15_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000U15_A106INCIDENCIAPCano[0] == A106INCIDENCIAPCano ) &&
            ( T000U15_A105INCIDENCIAPCMes[0] == A105INCIDENCIAPCMes ) && ( DateTimeUtil.ResetTime ( T000U15_A104INCIDENCIAPCFec[0] ) == DateTimeUtil.ResetTime ( A104INCIDENCIAPCFec ) ) && ( StringUtil.StrCmp(T000U15_A108INCIDENCIAPCLOTE[0], A108INCIDENCIAPCLOTE) > 0 ) )
            )
            {
               pr_default.readNext(13);
            }
            if ( (pr_default.getStatus(13) != 101) && ( ( DateTimeUtil.ResetTime ( T000U15_A104INCIDENCIAPCFec[0] ) < DateTimeUtil.ResetTime ( A104INCIDENCIAPCFec ) ) || ( DateTimeUtil.ResetTime ( T000U15_A104INCIDENCIAPCFec[0] ) == DateTimeUtil.ResetTime ( A104INCIDENCIAPCFec ) ) && ( T000U15_A105INCIDENCIAPCMes[0] < A105INCIDENCIAPCMes ) || ( T000U15_A105INCIDENCIAPCMes[0] == A105INCIDENCIAPCMes ) &&
            ( DateTimeUtil.ResetTime ( T000U15_A104INCIDENCIAPCFec[0] ) == DateTimeUtil.ResetTime ( A104INCIDENCIAPCFec ) ) && ( T000U15_A106INCIDENCIAPCano[0] < A106INCIDENCIAPCano ) || ( T000U15_A106INCIDENCIAPCano[0] == A106INCIDENCIAPCano ) && ( T000U15_A105INCIDENCIAPCMes[0] == A105INCIDENCIAPCMes ) && ( DateTimeUtil.ResetTime ( T000U15_A104INCIDENCIAPCFec[0] ) ==
            DateTimeUtil.ResetTime ( A104INCIDENCIAPCFec ) ) && ( StringUtil.StrCmp(T000U15_A5Cod_Area[0], A5Cod_Area) < 0 ) || ( StringUtil.StrCmp(T000U15_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000U15_A106INCIDENCIAPCano[0] == A106INCIDENCIAPCano ) && ( T000U15_A105INCIDENCIAPCMes[0] == A105INCIDENCIAPCMes ) && ( DateTimeUtil.ResetTime ( T000U15_A104INCIDENCIAPCFec[0] ) ==
            DateTimeUtil.ResetTime ( A104INCIDENCIAPCFec ) ) && ( StringUtil.StrCmp(T000U15_A4IndicadoresCodigo[0], A4IndicadoresCodigo) < 0 ) || ( StringUtil.StrCmp(T000U15_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T000U15_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000U15_A106INCIDENCIAPCano[0] == A106INCIDENCIAPCano ) && ( T000U15_A105INCIDENCIAPCMes[0] ==
            A105INCIDENCIAPCMes ) && ( DateTimeUtil.ResetTime ( T000U15_A104INCIDENCIAPCFec[0] ) == DateTimeUtil.ResetTime ( A104INCIDENCIAPCFec ) ) && ( StringUtil.StrCmp(T000U15_A90TiposEnfermedadesCod[0], A90TiposEnfermedadesCod) < 0 ) || ( StringUtil.StrCmp(T000U15_A90TiposEnfermedadesCod[0], A90TiposEnfermedadesCod) == 0 ) && ( StringUtil.StrCmp(T000U15_A4IndicadoresCodigo[0], A4IndicadoresCodigo) ==
            0 ) && ( StringUtil.StrCmp(T000U15_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000U15_A106INCIDENCIAPCano[0] == A106INCIDENCIAPCano ) && ( T000U15_A105INCIDENCIAPCMes[0] == A105INCIDENCIAPCMes ) && ( DateTimeUtil.ResetTime ( T000U15_A104INCIDENCIAPCFec[0] ) == DateTimeUtil.ResetTime ( A104INCIDENCIAPCFec ) ) && ( StringUtil.StrCmp(T000U15_A91MATERIALPALMASCOD[0], A91MATERIALPALMASCOD) < 0 ) ||
            ( StringUtil.StrCmp(T000U15_A91MATERIALPALMASCOD[0], A91MATERIALPALMASCOD) == 0 ) && ( StringUtil.StrCmp(T000U15_A90TiposEnfermedadesCod[0], A90TiposEnfermedadesCod) == 0 ) && ( StringUtil.StrCmp(T000U15_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T000U15_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000U15_A106INCIDENCIAPCano[0] == A106INCIDENCIAPCano ) &&
            ( T000U15_A105INCIDENCIAPCMes[0] == A105INCIDENCIAPCMes ) && ( DateTimeUtil.ResetTime ( T000U15_A104INCIDENCIAPCFec[0] ) == DateTimeUtil.ResetTime ( A104INCIDENCIAPCFec ) ) && ( StringUtil.StrCmp(T000U15_A107INCIDENCIAPCZONA[0], A107INCIDENCIAPCZONA) < 0 ) || ( StringUtil.StrCmp(T000U15_A107INCIDENCIAPCZONA[0], A107INCIDENCIAPCZONA) == 0 ) &&
            ( StringUtil.StrCmp(T000U15_A91MATERIALPALMASCOD[0], A91MATERIALPALMASCOD) == 0 ) && ( StringUtil.StrCmp(T000U15_A90TiposEnfermedadesCod[0], A90TiposEnfermedadesCod) == 0 ) && ( StringUtil.StrCmp(T000U15_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T000U15_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000U15_A106INCIDENCIAPCano[0] == A106INCIDENCIAPCano ) &&
            ( T000U15_A105INCIDENCIAPCMes[0] == A105INCIDENCIAPCMes ) && ( DateTimeUtil.ResetTime ( T000U15_A104INCIDENCIAPCFec[0] ) == DateTimeUtil.ResetTime ( A104INCIDENCIAPCFec ) ) && ( StringUtil.StrCmp(T000U15_A108INCIDENCIAPCLOTE[0], A108INCIDENCIAPCLOTE) < 0 ) )
            )
            {
               A104INCIDENCIAPCFec = T000U15_A104INCIDENCIAPCFec[0];
               AssignAttri("", false, "A104INCIDENCIAPCFec", context.localUtil.Format(A104INCIDENCIAPCFec, "99/99/99"));
               A105INCIDENCIAPCMes = T000U15_A105INCIDENCIAPCMes[0];
               AssignAttri("", false, "A105INCIDENCIAPCMes", StringUtil.LTrimStr( (decimal)(A105INCIDENCIAPCMes), 4, 0));
               A106INCIDENCIAPCano = T000U15_A106INCIDENCIAPCano[0];
               AssignAttri("", false, "A106INCIDENCIAPCano", StringUtil.LTrimStr( (decimal)(A106INCIDENCIAPCano), 4, 0));
               A5Cod_Area = T000U15_A5Cod_Area[0];
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               A4IndicadoresCodigo = T000U15_A4IndicadoresCodigo[0];
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               A90TiposEnfermedadesCod = T000U15_A90TiposEnfermedadesCod[0];
               AssignAttri("", false, "A90TiposEnfermedadesCod", A90TiposEnfermedadesCod);
               A91MATERIALPALMASCOD = T000U15_A91MATERIALPALMASCOD[0];
               AssignAttri("", false, "A91MATERIALPALMASCOD", A91MATERIALPALMASCOD);
               A107INCIDENCIAPCZONA = T000U15_A107INCIDENCIAPCZONA[0];
               AssignAttri("", false, "A107INCIDENCIAPCZONA", A107INCIDENCIAPCZONA);
               A108INCIDENCIAPCLOTE = T000U15_A108INCIDENCIAPCLOTE[0];
               AssignAttri("", false, "A108INCIDENCIAPCLOTE", A108INCIDENCIAPCLOTE);
               RcdFound31 = 1;
            }
         }
         pr_default.close(13);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0U31( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtINCIDENCIAPCFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0U31( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound31 == 1 )
            {
               if ( ( DateTimeUtil.ResetTime ( A104INCIDENCIAPCFec ) != DateTimeUtil.ResetTime ( Z104INCIDENCIAPCFec ) ) || ( A105INCIDENCIAPCMes != Z105INCIDENCIAPCMes ) || ( A106INCIDENCIAPCano != Z106INCIDENCIAPCano ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) || ( StringUtil.StrCmp(A90TiposEnfermedadesCod, Z90TiposEnfermedadesCod) != 0 ) || ( StringUtil.StrCmp(A91MATERIALPALMASCOD, Z91MATERIALPALMASCOD) != 0 ) || ( StringUtil.StrCmp(A107INCIDENCIAPCZONA, Z107INCIDENCIAPCZONA) != 0 ) || ( StringUtil.StrCmp(A108INCIDENCIAPCLOTE, Z108INCIDENCIAPCLOTE) != 0 ) )
               {
                  A104INCIDENCIAPCFec = Z104INCIDENCIAPCFec;
                  AssignAttri("", false, "A104INCIDENCIAPCFec", context.localUtil.Format(A104INCIDENCIAPCFec, "99/99/99"));
                  A105INCIDENCIAPCMes = Z105INCIDENCIAPCMes;
                  AssignAttri("", false, "A105INCIDENCIAPCMes", StringUtil.LTrimStr( (decimal)(A105INCIDENCIAPCMes), 4, 0));
                  A106INCIDENCIAPCano = Z106INCIDENCIAPCano;
                  AssignAttri("", false, "A106INCIDENCIAPCano", StringUtil.LTrimStr( (decimal)(A106INCIDENCIAPCano), 4, 0));
                  A5Cod_Area = Z5Cod_Area;
                  AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
                  A4IndicadoresCodigo = Z4IndicadoresCodigo;
                  AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
                  A90TiposEnfermedadesCod = Z90TiposEnfermedadesCod;
                  AssignAttri("", false, "A90TiposEnfermedadesCod", A90TiposEnfermedadesCod);
                  A91MATERIALPALMASCOD = Z91MATERIALPALMASCOD;
                  AssignAttri("", false, "A91MATERIALPALMASCOD", A91MATERIALPALMASCOD);
                  A107INCIDENCIAPCZONA = Z107INCIDENCIAPCZONA;
                  AssignAttri("", false, "A107INCIDENCIAPCZONA", A107INCIDENCIAPCZONA);
                  A108INCIDENCIAPCLOTE = Z108INCIDENCIAPCLOTE;
                  AssignAttri("", false, "A108INCIDENCIAPCLOTE", A108INCIDENCIAPCLOTE);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "INCIDENCIAPCFEC");
                  AnyError = 1;
                  GX_FocusControl = edtINCIDENCIAPCFec_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtINCIDENCIAPCFec_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0U31( ) ;
                  GX_FocusControl = edtINCIDENCIAPCFec_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( DateTimeUtil.ResetTime ( A104INCIDENCIAPCFec ) != DateTimeUtil.ResetTime ( Z104INCIDENCIAPCFec ) ) || ( A105INCIDENCIAPCMes != Z105INCIDENCIAPCMes ) || ( A106INCIDENCIAPCano != Z106INCIDENCIAPCano ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) || ( StringUtil.StrCmp(A90TiposEnfermedadesCod, Z90TiposEnfermedadesCod) != 0 ) || ( StringUtil.StrCmp(A91MATERIALPALMASCOD, Z91MATERIALPALMASCOD) != 0 ) || ( StringUtil.StrCmp(A107INCIDENCIAPCZONA, Z107INCIDENCIAPCZONA) != 0 ) || ( StringUtil.StrCmp(A108INCIDENCIAPCLOTE, Z108INCIDENCIAPCLOTE) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtINCIDENCIAPCFec_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0U31( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "INCIDENCIAPCFEC");
                     AnyError = 1;
                     GX_FocusControl = edtINCIDENCIAPCFec_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtINCIDENCIAPCFec_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0U31( ) ;
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
         if ( ( DateTimeUtil.ResetTime ( A104INCIDENCIAPCFec ) != DateTimeUtil.ResetTime ( Z104INCIDENCIAPCFec ) ) || ( A105INCIDENCIAPCMes != Z105INCIDENCIAPCMes ) || ( A106INCIDENCIAPCano != Z106INCIDENCIAPCano ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) || ( StringUtil.StrCmp(A90TiposEnfermedadesCod, Z90TiposEnfermedadesCod) != 0 ) || ( StringUtil.StrCmp(A91MATERIALPALMASCOD, Z91MATERIALPALMASCOD) != 0 ) || ( StringUtil.StrCmp(A107INCIDENCIAPCZONA, Z107INCIDENCIAPCZONA) != 0 ) || ( StringUtil.StrCmp(A108INCIDENCIAPCLOTE, Z108INCIDENCIAPCLOTE) != 0 ) )
         {
            A104INCIDENCIAPCFec = Z104INCIDENCIAPCFec;
            AssignAttri("", false, "A104INCIDENCIAPCFec", context.localUtil.Format(A104INCIDENCIAPCFec, "99/99/99"));
            A105INCIDENCIAPCMes = Z105INCIDENCIAPCMes;
            AssignAttri("", false, "A105INCIDENCIAPCMes", StringUtil.LTrimStr( (decimal)(A105INCIDENCIAPCMes), 4, 0));
            A106INCIDENCIAPCano = Z106INCIDENCIAPCano;
            AssignAttri("", false, "A106INCIDENCIAPCano", StringUtil.LTrimStr( (decimal)(A106INCIDENCIAPCano), 4, 0));
            A5Cod_Area = Z5Cod_Area;
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = Z4IndicadoresCodigo;
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A90TiposEnfermedadesCod = Z90TiposEnfermedadesCod;
            AssignAttri("", false, "A90TiposEnfermedadesCod", A90TiposEnfermedadesCod);
            A91MATERIALPALMASCOD = Z91MATERIALPALMASCOD;
            AssignAttri("", false, "A91MATERIALPALMASCOD", A91MATERIALPALMASCOD);
            A107INCIDENCIAPCZONA = Z107INCIDENCIAPCZONA;
            AssignAttri("", false, "A107INCIDENCIAPCZONA", A107INCIDENCIAPCZONA);
            A108INCIDENCIAPCLOTE = Z108INCIDENCIAPCLOTE;
            AssignAttri("", false, "A108INCIDENCIAPCLOTE", A108INCIDENCIAPCLOTE);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "INCIDENCIAPCFEC");
            AnyError = 1;
            GX_FocusControl = edtINCIDENCIAPCFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtINCIDENCIAPCFec_Internalname;
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
         if ( RcdFound31 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "INCIDENCIAPCFEC");
            AnyError = 1;
            GX_FocusControl = edtINCIDENCIAPCFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtINCIDENCIAPCCasos_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0U31( ) ;
         if ( RcdFound31 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtINCIDENCIAPCCasos_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0U31( ) ;
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
         if ( RcdFound31 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtINCIDENCIAPCCasos_Internalname;
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
         if ( RcdFound31 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtINCIDENCIAPCCasos_Internalname;
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
         ScanStart0U31( ) ;
         if ( RcdFound31 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound31 != 0 )
            {
               ScanNext0U31( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtINCIDENCIAPCCasos_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0U31( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0U31( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000U2 */
            pr_default.execute(0, new Object[] {A104INCIDENCIAPCFec, A105INCIDENCIAPCMes, A106INCIDENCIAPCano, A5Cod_Area, A4IndicadoresCodigo, A90TiposEnfermedadesCod, A91MATERIALPALMASCOD, A107INCIDENCIAPCZONA, A108INCIDENCIAPCLOTE});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"INCIDENCIAPC"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z180INCIDENCIAPCCasos != T000U2_A180INCIDENCIAPCCasos[0] ) || ( Z181INCIDENCIAPCPalmas != T000U2_A181INCIDENCIAPCPalmas[0] ) || ( StringUtil.StrCmp(Z182INCIDENCIAPCuser, T000U2_A182INCIDENCIAPCuser[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z183INCIDENCIAPCreg ) != DateTimeUtil.ResetTime ( T000U2_A183INCIDENCIAPCreg[0] ) ) || ( StringUtil.StrCmp(Z184INCIDENCIAPChor, T000U2_A184INCIDENCIAPChor[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z264INCIDENCIAPCUMA, T000U2_A264INCIDENCIAPCUMA[0]) != 0 ) || ( Z265INCIDENCIAPCSIEMBRA != T000U2_A265INCIDENCIAPCSIEMBRA[0] ) || ( StringUtil.StrCmp(Z266INCIDENCIAPCGRUPOZONA, T000U2_A266INCIDENCIAPCGRUPOZONA[0]) != 0 ) )
            {
               if ( Z180INCIDENCIAPCCasos != T000U2_A180INCIDENCIAPCCasos[0] )
               {
                  GXUtil.WriteLog("incidenciapc:[seudo value changed for attri]"+"INCIDENCIAPCCasos");
                  GXUtil.WriteLogRaw("Old: ",Z180INCIDENCIAPCCasos);
                  GXUtil.WriteLogRaw("Current: ",T000U2_A180INCIDENCIAPCCasos[0]);
               }
               if ( Z181INCIDENCIAPCPalmas != T000U2_A181INCIDENCIAPCPalmas[0] )
               {
                  GXUtil.WriteLog("incidenciapc:[seudo value changed for attri]"+"INCIDENCIAPCPalmas");
                  GXUtil.WriteLogRaw("Old: ",Z181INCIDENCIAPCPalmas);
                  GXUtil.WriteLogRaw("Current: ",T000U2_A181INCIDENCIAPCPalmas[0]);
               }
               if ( StringUtil.StrCmp(Z182INCIDENCIAPCuser, T000U2_A182INCIDENCIAPCuser[0]) != 0 )
               {
                  GXUtil.WriteLog("incidenciapc:[seudo value changed for attri]"+"INCIDENCIAPCuser");
                  GXUtil.WriteLogRaw("Old: ",Z182INCIDENCIAPCuser);
                  GXUtil.WriteLogRaw("Current: ",T000U2_A182INCIDENCIAPCuser[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z183INCIDENCIAPCreg ) != DateTimeUtil.ResetTime ( T000U2_A183INCIDENCIAPCreg[0] ) )
               {
                  GXUtil.WriteLog("incidenciapc:[seudo value changed for attri]"+"INCIDENCIAPCreg");
                  GXUtil.WriteLogRaw("Old: ",Z183INCIDENCIAPCreg);
                  GXUtil.WriteLogRaw("Current: ",T000U2_A183INCIDENCIAPCreg[0]);
               }
               if ( StringUtil.StrCmp(Z184INCIDENCIAPChor, T000U2_A184INCIDENCIAPChor[0]) != 0 )
               {
                  GXUtil.WriteLog("incidenciapc:[seudo value changed for attri]"+"INCIDENCIAPChor");
                  GXUtil.WriteLogRaw("Old: ",Z184INCIDENCIAPChor);
                  GXUtil.WriteLogRaw("Current: ",T000U2_A184INCIDENCIAPChor[0]);
               }
               if ( StringUtil.StrCmp(Z264INCIDENCIAPCUMA, T000U2_A264INCIDENCIAPCUMA[0]) != 0 )
               {
                  GXUtil.WriteLog("incidenciapc:[seudo value changed for attri]"+"INCIDENCIAPCUMA");
                  GXUtil.WriteLogRaw("Old: ",Z264INCIDENCIAPCUMA);
                  GXUtil.WriteLogRaw("Current: ",T000U2_A264INCIDENCIAPCUMA[0]);
               }
               if ( Z265INCIDENCIAPCSIEMBRA != T000U2_A265INCIDENCIAPCSIEMBRA[0] )
               {
                  GXUtil.WriteLog("incidenciapc:[seudo value changed for attri]"+"INCIDENCIAPCSIEMBRA");
                  GXUtil.WriteLogRaw("Old: ",Z265INCIDENCIAPCSIEMBRA);
                  GXUtil.WriteLogRaw("Current: ",T000U2_A265INCIDENCIAPCSIEMBRA[0]);
               }
               if ( StringUtil.StrCmp(Z266INCIDENCIAPCGRUPOZONA, T000U2_A266INCIDENCIAPCGRUPOZONA[0]) != 0 )
               {
                  GXUtil.WriteLog("incidenciapc:[seudo value changed for attri]"+"INCIDENCIAPCGRUPOZONA");
                  GXUtil.WriteLogRaw("Old: ",Z266INCIDENCIAPCGRUPOZONA);
                  GXUtil.WriteLogRaw("Current: ",T000U2_A266INCIDENCIAPCGRUPOZONA[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"INCIDENCIAPC"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0U31( )
      {
         BeforeValidate0U31( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0U31( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0U31( 0) ;
            CheckOptimisticConcurrency0U31( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0U31( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0U31( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000U16 */
                     pr_default.execute(14, new Object[] {A104INCIDENCIAPCFec, A105INCIDENCIAPCMes, A106INCIDENCIAPCano, A107INCIDENCIAPCZONA, A108INCIDENCIAPCLOTE, A180INCIDENCIAPCCasos, A181INCIDENCIAPCPalmas, A182INCIDENCIAPCuser, A183INCIDENCIAPCreg, A184INCIDENCIAPChor, A264INCIDENCIAPCUMA, A265INCIDENCIAPCSIEMBRA, A266INCIDENCIAPCGRUPOZONA, A5Cod_Area, A4IndicadoresCodigo, A90TiposEnfermedadesCod, A91MATERIALPALMASCOD});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("INCIDENCIAPC");
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
                           ResetCaption0U0( ) ;
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
               Load0U31( ) ;
            }
            EndLevel0U31( ) ;
         }
         CloseExtendedTableCursors0U31( ) ;
      }

      protected void Update0U31( )
      {
         BeforeValidate0U31( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0U31( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0U31( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0U31( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0U31( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000U17 */
                     pr_default.execute(15, new Object[] {A180INCIDENCIAPCCasos, A181INCIDENCIAPCPalmas, A182INCIDENCIAPCuser, A183INCIDENCIAPCreg, A184INCIDENCIAPChor, A264INCIDENCIAPCUMA, A265INCIDENCIAPCSIEMBRA, A266INCIDENCIAPCGRUPOZONA, A104INCIDENCIAPCFec, A105INCIDENCIAPCMes, A106INCIDENCIAPCano, A5Cod_Area, A4IndicadoresCodigo, A90TiposEnfermedadesCod, A91MATERIALPALMASCOD, A107INCIDENCIAPCZONA, A108INCIDENCIAPCLOTE});
                     pr_default.close(15);
                     pr_default.SmartCacheProvider.SetUpdated("INCIDENCIAPC");
                     if ( (pr_default.getStatus(15) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"INCIDENCIAPC"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0U31( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0U0( ) ;
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
            EndLevel0U31( ) ;
         }
         CloseExtendedTableCursors0U31( ) ;
      }

      protected void DeferredUpdate0U31( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0U31( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0U31( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0U31( ) ;
            AfterConfirm0U31( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0U31( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000U18 */
                  pr_default.execute(16, new Object[] {A104INCIDENCIAPCFec, A105INCIDENCIAPCMes, A106INCIDENCIAPCano, A5Cod_Area, A4IndicadoresCodigo, A90TiposEnfermedadesCod, A91MATERIALPALMASCOD, A107INCIDENCIAPCZONA, A108INCIDENCIAPCLOTE});
                  pr_default.close(16);
                  pr_default.SmartCacheProvider.SetUpdated("INCIDENCIAPC");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound31 == 0 )
                        {
                           InitAll0U31( ) ;
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
                        ResetCaption0U0( ) ;
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
         sMode31 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0U31( ) ;
         Gx_mode = sMode31;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0U31( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0U31( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0U31( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("incidenciapc",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0U0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("incidenciapc",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0U31( )
      {
         /* Using cursor T000U19 */
         pr_default.execute(17);
         RcdFound31 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound31 = 1;
            A104INCIDENCIAPCFec = T000U19_A104INCIDENCIAPCFec[0];
            AssignAttri("", false, "A104INCIDENCIAPCFec", context.localUtil.Format(A104INCIDENCIAPCFec, "99/99/99"));
            A105INCIDENCIAPCMes = T000U19_A105INCIDENCIAPCMes[0];
            AssignAttri("", false, "A105INCIDENCIAPCMes", StringUtil.LTrimStr( (decimal)(A105INCIDENCIAPCMes), 4, 0));
            A106INCIDENCIAPCano = T000U19_A106INCIDENCIAPCano[0];
            AssignAttri("", false, "A106INCIDENCIAPCano", StringUtil.LTrimStr( (decimal)(A106INCIDENCIAPCano), 4, 0));
            A5Cod_Area = T000U19_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = T000U19_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A90TiposEnfermedadesCod = T000U19_A90TiposEnfermedadesCod[0];
            AssignAttri("", false, "A90TiposEnfermedadesCod", A90TiposEnfermedadesCod);
            A91MATERIALPALMASCOD = T000U19_A91MATERIALPALMASCOD[0];
            AssignAttri("", false, "A91MATERIALPALMASCOD", A91MATERIALPALMASCOD);
            A107INCIDENCIAPCZONA = T000U19_A107INCIDENCIAPCZONA[0];
            AssignAttri("", false, "A107INCIDENCIAPCZONA", A107INCIDENCIAPCZONA);
            A108INCIDENCIAPCLOTE = T000U19_A108INCIDENCIAPCLOTE[0];
            AssignAttri("", false, "A108INCIDENCIAPCLOTE", A108INCIDENCIAPCLOTE);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0U31( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound31 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound31 = 1;
            A104INCIDENCIAPCFec = T000U19_A104INCIDENCIAPCFec[0];
            AssignAttri("", false, "A104INCIDENCIAPCFec", context.localUtil.Format(A104INCIDENCIAPCFec, "99/99/99"));
            A105INCIDENCIAPCMes = T000U19_A105INCIDENCIAPCMes[0];
            AssignAttri("", false, "A105INCIDENCIAPCMes", StringUtil.LTrimStr( (decimal)(A105INCIDENCIAPCMes), 4, 0));
            A106INCIDENCIAPCano = T000U19_A106INCIDENCIAPCano[0];
            AssignAttri("", false, "A106INCIDENCIAPCano", StringUtil.LTrimStr( (decimal)(A106INCIDENCIAPCano), 4, 0));
            A5Cod_Area = T000U19_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = T000U19_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A90TiposEnfermedadesCod = T000U19_A90TiposEnfermedadesCod[0];
            AssignAttri("", false, "A90TiposEnfermedadesCod", A90TiposEnfermedadesCod);
            A91MATERIALPALMASCOD = T000U19_A91MATERIALPALMASCOD[0];
            AssignAttri("", false, "A91MATERIALPALMASCOD", A91MATERIALPALMASCOD);
            A107INCIDENCIAPCZONA = T000U19_A107INCIDENCIAPCZONA[0];
            AssignAttri("", false, "A107INCIDENCIAPCZONA", A107INCIDENCIAPCZONA);
            A108INCIDENCIAPCLOTE = T000U19_A108INCIDENCIAPCLOTE[0];
            AssignAttri("", false, "A108INCIDENCIAPCLOTE", A108INCIDENCIAPCLOTE);
         }
      }

      protected void ScanEnd0U31( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm0U31( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0U31( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0U31( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0U31( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0U31( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0U31( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0U31( )
      {
         edtINCIDENCIAPCFec_Enabled = 0;
         AssignProp("", false, edtINCIDENCIAPCFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtINCIDENCIAPCFec_Enabled), 5, 0), true);
         edtINCIDENCIAPCMes_Enabled = 0;
         AssignProp("", false, edtINCIDENCIAPCMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtINCIDENCIAPCMes_Enabled), 5, 0), true);
         edtINCIDENCIAPCano_Enabled = 0;
         AssignProp("", false, edtINCIDENCIAPCano_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtINCIDENCIAPCano_Enabled), 5, 0), true);
         edtCod_Area_Enabled = 0;
         AssignProp("", false, edtCod_Area_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCod_Area_Enabled), 5, 0), true);
         edtIndicadoresCodigo_Enabled = 0;
         AssignProp("", false, edtIndicadoresCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIndicadoresCodigo_Enabled), 5, 0), true);
         edtTiposEnfermedadesCod_Enabled = 0;
         AssignProp("", false, edtTiposEnfermedadesCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTiposEnfermedadesCod_Enabled), 5, 0), true);
         edtMATERIALPALMASCOD_Enabled = 0;
         AssignProp("", false, edtMATERIALPALMASCOD_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMATERIALPALMASCOD_Enabled), 5, 0), true);
         edtINCIDENCIAPCCasos_Enabled = 0;
         AssignProp("", false, edtINCIDENCIAPCCasos_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtINCIDENCIAPCCasos_Enabled), 5, 0), true);
         edtINCIDENCIAPCPalmas_Enabled = 0;
         AssignProp("", false, edtINCIDENCIAPCPalmas_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtINCIDENCIAPCPalmas_Enabled), 5, 0), true);
         edtINCIDENCIAPCuser_Enabled = 0;
         AssignProp("", false, edtINCIDENCIAPCuser_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtINCIDENCIAPCuser_Enabled), 5, 0), true);
         edtINCIDENCIAPCreg_Enabled = 0;
         AssignProp("", false, edtINCIDENCIAPCreg_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtINCIDENCIAPCreg_Enabled), 5, 0), true);
         edtINCIDENCIAPChor_Enabled = 0;
         AssignProp("", false, edtINCIDENCIAPChor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtINCIDENCIAPChor_Enabled), 5, 0), true);
         edtINCIDENCIAPCZONA_Enabled = 0;
         AssignProp("", false, edtINCIDENCIAPCZONA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtINCIDENCIAPCZONA_Enabled), 5, 0), true);
         edtINCIDENCIAPCLOTE_Enabled = 0;
         AssignProp("", false, edtINCIDENCIAPCLOTE_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtINCIDENCIAPCLOTE_Enabled), 5, 0), true);
         edtINCIDENCIAPCUMA_Enabled = 0;
         AssignProp("", false, edtINCIDENCIAPCUMA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtINCIDENCIAPCUMA_Enabled), 5, 0), true);
         edtINCIDENCIAPCSIEMBRA_Enabled = 0;
         AssignProp("", false, edtINCIDENCIAPCSIEMBRA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtINCIDENCIAPCSIEMBRA_Enabled), 5, 0), true);
         edtINCIDENCIAPCGRUPOZONA_Enabled = 0;
         AssignProp("", false, edtINCIDENCIAPCGRUPOZONA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtINCIDENCIAPCGRUPOZONA_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0U31( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0U0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("incidenciapc.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z104INCIDENCIAPCFec", context.localUtil.DToC( Z104INCIDENCIAPCFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z105INCIDENCIAPCMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z105INCIDENCIAPCMes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z106INCIDENCIAPCano", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z106INCIDENCIAPCano), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z5Cod_Area", Z5Cod_Area);
         GxWebStd.gx_hidden_field( context, "Z4IndicadoresCodigo", Z4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "Z90TiposEnfermedadesCod", Z90TiposEnfermedadesCod);
         GxWebStd.gx_hidden_field( context, "Z91MATERIALPALMASCOD", Z91MATERIALPALMASCOD);
         GxWebStd.gx_hidden_field( context, "Z107INCIDENCIAPCZONA", Z107INCIDENCIAPCZONA);
         GxWebStd.gx_hidden_field( context, "Z108INCIDENCIAPCLOTE", Z108INCIDENCIAPCLOTE);
         GxWebStd.gx_hidden_field( context, "Z180INCIDENCIAPCCasos", StringUtil.LTrim( StringUtil.NToC( Z180INCIDENCIAPCCasos, 12, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z181INCIDENCIAPCPalmas", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z181INCIDENCIAPCPalmas), 12, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z182INCIDENCIAPCuser", Z182INCIDENCIAPCuser);
         GxWebStd.gx_hidden_field( context, "Z183INCIDENCIAPCreg", context.localUtil.DToC( Z183INCIDENCIAPCreg, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z184INCIDENCIAPChor", Z184INCIDENCIAPChor);
         GxWebStd.gx_hidden_field( context, "Z264INCIDENCIAPCUMA", Z264INCIDENCIAPCUMA);
         GxWebStd.gx_hidden_field( context, "Z265INCIDENCIAPCSIEMBRA", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z265INCIDENCIAPCSIEMBRA), 12, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z266INCIDENCIAPCGRUPOZONA", Z266INCIDENCIAPCGRUPOZONA);
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
         return formatLink("incidenciapc.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "INCIDENCIAPC" ;
      }

      public override string GetPgmdesc( )
      {
         return "INCIDENCIAPC" ;
      }

      protected void InitializeNonKey0U31( )
      {
         A180INCIDENCIAPCCasos = 0;
         AssignAttri("", false, "A180INCIDENCIAPCCasos", StringUtil.LTrimStr( A180INCIDENCIAPCCasos, 12, 2));
         A181INCIDENCIAPCPalmas = 0;
         AssignAttri("", false, "A181INCIDENCIAPCPalmas", StringUtil.LTrimStr( (decimal)(A181INCIDENCIAPCPalmas), 12, 0));
         A182INCIDENCIAPCuser = "";
         AssignAttri("", false, "A182INCIDENCIAPCuser", A182INCIDENCIAPCuser);
         A183INCIDENCIAPCreg = DateTime.MinValue;
         AssignAttri("", false, "A183INCIDENCIAPCreg", context.localUtil.Format(A183INCIDENCIAPCreg, "99/99/99"));
         A184INCIDENCIAPChor = "";
         AssignAttri("", false, "A184INCIDENCIAPChor", A184INCIDENCIAPChor);
         A264INCIDENCIAPCUMA = "";
         AssignAttri("", false, "A264INCIDENCIAPCUMA", A264INCIDENCIAPCUMA);
         A265INCIDENCIAPCSIEMBRA = 0;
         AssignAttri("", false, "A265INCIDENCIAPCSIEMBRA", StringUtil.LTrimStr( (decimal)(A265INCIDENCIAPCSIEMBRA), 12, 0));
         A266INCIDENCIAPCGRUPOZONA = "";
         AssignAttri("", false, "A266INCIDENCIAPCGRUPOZONA", A266INCIDENCIAPCGRUPOZONA);
         Z180INCIDENCIAPCCasos = 0;
         Z181INCIDENCIAPCPalmas = 0;
         Z182INCIDENCIAPCuser = "";
         Z183INCIDENCIAPCreg = DateTime.MinValue;
         Z184INCIDENCIAPChor = "";
         Z264INCIDENCIAPCUMA = "";
         Z265INCIDENCIAPCSIEMBRA = 0;
         Z266INCIDENCIAPCGRUPOZONA = "";
      }

      protected void InitAll0U31( )
      {
         A104INCIDENCIAPCFec = DateTime.MinValue;
         AssignAttri("", false, "A104INCIDENCIAPCFec", context.localUtil.Format(A104INCIDENCIAPCFec, "99/99/99"));
         A105INCIDENCIAPCMes = 0;
         AssignAttri("", false, "A105INCIDENCIAPCMes", StringUtil.LTrimStr( (decimal)(A105INCIDENCIAPCMes), 4, 0));
         A106INCIDENCIAPCano = 0;
         AssignAttri("", false, "A106INCIDENCIAPCano", StringUtil.LTrimStr( (decimal)(A106INCIDENCIAPCano), 4, 0));
         A5Cod_Area = "";
         AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
         A4IndicadoresCodigo = "";
         AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
         A90TiposEnfermedadesCod = "";
         AssignAttri("", false, "A90TiposEnfermedadesCod", A90TiposEnfermedadesCod);
         A91MATERIALPALMASCOD = "";
         AssignAttri("", false, "A91MATERIALPALMASCOD", A91MATERIALPALMASCOD);
         A107INCIDENCIAPCZONA = "";
         AssignAttri("", false, "A107INCIDENCIAPCZONA", A107INCIDENCIAPCZONA);
         A108INCIDENCIAPCLOTE = "";
         AssignAttri("", false, "A108INCIDENCIAPCLOTE", A108INCIDENCIAPCLOTE);
         InitializeNonKey0U31( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20247231024192", true, true);
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
         context.AddJavascriptSource("incidenciapc.js", "?20247231024192", false, true);
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
         edtINCIDENCIAPCFec_Internalname = "INCIDENCIAPCFEC";
         edtINCIDENCIAPCMes_Internalname = "INCIDENCIAPCMES";
         edtINCIDENCIAPCano_Internalname = "INCIDENCIAPCANO";
         edtCod_Area_Internalname = "COD_AREA";
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO";
         edtTiposEnfermedadesCod_Internalname = "TIPOSENFERMEDADESCOD";
         edtMATERIALPALMASCOD_Internalname = "MATERIALPALMASCOD";
         edtINCIDENCIAPCCasos_Internalname = "INCIDENCIAPCCASOS";
         edtINCIDENCIAPCPalmas_Internalname = "INCIDENCIAPCPALMAS";
         edtINCIDENCIAPCuser_Internalname = "INCIDENCIAPCUSER";
         edtINCIDENCIAPCreg_Internalname = "INCIDENCIAPCREG";
         edtINCIDENCIAPChor_Internalname = "INCIDENCIAPCHOR";
         edtINCIDENCIAPCZONA_Internalname = "INCIDENCIAPCZONA";
         edtINCIDENCIAPCLOTE_Internalname = "INCIDENCIAPCLOTE";
         edtINCIDENCIAPCUMA_Internalname = "INCIDENCIAPCUMA";
         edtINCIDENCIAPCSIEMBRA_Internalname = "INCIDENCIAPCSIEMBRA";
         edtINCIDENCIAPCGRUPOZONA_Internalname = "INCIDENCIAPCGRUPOZONA";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_5_Internalname = "PROMPT_5";
         imgprompt_4_Internalname = "PROMPT_4";
         imgprompt_90_Internalname = "PROMPT_90";
         imgprompt_91_Internalname = "PROMPT_91";
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
         Form.Caption = "INCIDENCIAPC";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtINCIDENCIAPCGRUPOZONA_Jsonclick = "";
         edtINCIDENCIAPCGRUPOZONA_Enabled = 1;
         edtINCIDENCIAPCSIEMBRA_Jsonclick = "";
         edtINCIDENCIAPCSIEMBRA_Enabled = 1;
         edtINCIDENCIAPCUMA_Jsonclick = "";
         edtINCIDENCIAPCUMA_Enabled = 1;
         edtINCIDENCIAPCLOTE_Jsonclick = "";
         edtINCIDENCIAPCLOTE_Enabled = 1;
         edtINCIDENCIAPCZONA_Jsonclick = "";
         edtINCIDENCIAPCZONA_Enabled = 1;
         edtINCIDENCIAPChor_Jsonclick = "";
         edtINCIDENCIAPChor_Enabled = 1;
         edtINCIDENCIAPCreg_Jsonclick = "";
         edtINCIDENCIAPCreg_Enabled = 1;
         edtINCIDENCIAPCuser_Jsonclick = "";
         edtINCIDENCIAPCuser_Enabled = 1;
         edtINCIDENCIAPCPalmas_Jsonclick = "";
         edtINCIDENCIAPCPalmas_Enabled = 1;
         edtINCIDENCIAPCCasos_Jsonclick = "";
         edtINCIDENCIAPCCasos_Enabled = 1;
         imgprompt_91_Visible = 1;
         imgprompt_91_Link = "";
         edtMATERIALPALMASCOD_Jsonclick = "";
         edtMATERIALPALMASCOD_Enabled = 1;
         imgprompt_90_Visible = 1;
         imgprompt_90_Link = "";
         edtTiposEnfermedadesCod_Jsonclick = "";
         edtTiposEnfermedadesCod_Enabled = 1;
         imgprompt_4_Visible = 1;
         imgprompt_4_Link = "";
         edtIndicadoresCodigo_Jsonclick = "";
         edtIndicadoresCodigo_Enabled = 1;
         imgprompt_5_Visible = 1;
         imgprompt_5_Link = "";
         edtCod_Area_Jsonclick = "";
         edtCod_Area_Enabled = 1;
         edtINCIDENCIAPCano_Jsonclick = "";
         edtINCIDENCIAPCano_Enabled = 1;
         edtINCIDENCIAPCMes_Jsonclick = "";
         edtINCIDENCIAPCMes_Enabled = 1;
         edtINCIDENCIAPCFec_Jsonclick = "";
         edtINCIDENCIAPCFec_Enabled = 1;
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
         /* Using cursor T000U20 */
         pr_default.execute(18, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(18);
         /* Using cursor T000U21 */
         pr_default.execute(19, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(19);
         /* Using cursor T000U22 */
         pr_default.execute(20, new Object[] {A90TiposEnfermedadesCod});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipos Enfermedades'.", "ForeignKeyNotFound", 1, "TIPOSENFERMEDADESCOD");
            AnyError = 1;
            GX_FocusControl = edtTiposEnfermedadesCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(20);
         /* Using cursor T000U23 */
         pr_default.execute(21, new Object[] {A91MATERIALPALMASCOD});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GX_msglist.addItem("No existe 'MATERIALPALMAS'.", "ForeignKeyNotFound", 1, "MATERIALPALMASCOD");
            AnyError = 1;
            GX_FocusControl = edtMATERIALPALMASCOD_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(21);
         GX_FocusControl = edtINCIDENCIAPCCasos_Internalname;
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
         /* Using cursor T000U20 */
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
         /* Using cursor T000U21 */
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

      public void Valid_Tiposenfermedadescod( )
      {
         /* Using cursor T000U22 */
         pr_default.execute(20, new Object[] {A90TiposEnfermedadesCod});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipos Enfermedades'.", "ForeignKeyNotFound", 1, "TIPOSENFERMEDADESCOD");
            AnyError = 1;
            GX_FocusControl = edtTiposEnfermedadesCod_Internalname;
         }
         pr_default.close(20);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Materialpalmascod( )
      {
         /* Using cursor T000U23 */
         pr_default.execute(21, new Object[] {A91MATERIALPALMASCOD});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GX_msglist.addItem("No existe 'MATERIALPALMAS'.", "ForeignKeyNotFound", 1, "MATERIALPALMASCOD");
            AnyError = 1;
            GX_FocusControl = edtMATERIALPALMASCOD_Internalname;
         }
         pr_default.close(21);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Incidenciapclote( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A180INCIDENCIAPCCasos", StringUtil.LTrim( StringUtil.NToC( A180INCIDENCIAPCCasos, 12, 2, ".", "")));
         AssignAttri("", false, "A181INCIDENCIAPCPalmas", StringUtil.LTrim( StringUtil.NToC( (decimal)(A181INCIDENCIAPCPalmas), 12, 0, ".", "")));
         AssignAttri("", false, "A182INCIDENCIAPCuser", A182INCIDENCIAPCuser);
         AssignAttri("", false, "A183INCIDENCIAPCreg", context.localUtil.Format(A183INCIDENCIAPCreg, "99/99/99"));
         AssignAttri("", false, "A184INCIDENCIAPChor", A184INCIDENCIAPChor);
         AssignAttri("", false, "A264INCIDENCIAPCUMA", A264INCIDENCIAPCUMA);
         AssignAttri("", false, "A265INCIDENCIAPCSIEMBRA", StringUtil.LTrim( StringUtil.NToC( (decimal)(A265INCIDENCIAPCSIEMBRA), 12, 0, ".", "")));
         AssignAttri("", false, "A266INCIDENCIAPCGRUPOZONA", A266INCIDENCIAPCGRUPOZONA);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z104INCIDENCIAPCFec", context.localUtil.Format(Z104INCIDENCIAPCFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z105INCIDENCIAPCMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z105INCIDENCIAPCMes), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z106INCIDENCIAPCano", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z106INCIDENCIAPCano), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z5Cod_Area", Z5Cod_Area);
         GxWebStd.gx_hidden_field( context, "Z4IndicadoresCodigo", Z4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "Z90TiposEnfermedadesCod", Z90TiposEnfermedadesCod);
         GxWebStd.gx_hidden_field( context, "Z91MATERIALPALMASCOD", Z91MATERIALPALMASCOD);
         GxWebStd.gx_hidden_field( context, "Z107INCIDENCIAPCZONA", Z107INCIDENCIAPCZONA);
         GxWebStd.gx_hidden_field( context, "Z108INCIDENCIAPCLOTE", Z108INCIDENCIAPCLOTE);
         GxWebStd.gx_hidden_field( context, "Z180INCIDENCIAPCCasos", StringUtil.LTrim( StringUtil.NToC( Z180INCIDENCIAPCCasos, 12, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z181INCIDENCIAPCPalmas", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z181INCIDENCIAPCPalmas), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z182INCIDENCIAPCuser", Z182INCIDENCIAPCuser);
         GxWebStd.gx_hidden_field( context, "Z183INCIDENCIAPCreg", context.localUtil.Format(Z183INCIDENCIAPCreg, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z184INCIDENCIAPChor", Z184INCIDENCIAPChor);
         GxWebStd.gx_hidden_field( context, "Z264INCIDENCIAPCUMA", Z264INCIDENCIAPCUMA);
         GxWebStd.gx_hidden_field( context, "Z265INCIDENCIAPCSIEMBRA", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z265INCIDENCIAPCSIEMBRA), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z266INCIDENCIAPCGRUPOZONA", Z266INCIDENCIAPCGRUPOZONA);
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
         setEventMetadata("VALID_INCIDENCIAPCFEC","{handler:'Valid_Incidenciapcfec',iparms:[]");
         setEventMetadata("VALID_INCIDENCIAPCFEC",",oparms:[]}");
         setEventMetadata("VALID_INCIDENCIAPCMES","{handler:'Valid_Incidenciapcmes',iparms:[]");
         setEventMetadata("VALID_INCIDENCIAPCMES",",oparms:[]}");
         setEventMetadata("VALID_INCIDENCIAPCANO","{handler:'Valid_Incidenciapcano',iparms:[]");
         setEventMetadata("VALID_INCIDENCIAPCANO",",oparms:[]}");
         setEventMetadata("VALID_COD_AREA","{handler:'Valid_Cod_area',iparms:[{av:'A5Cod_Area',fld:'COD_AREA',pic:''}]");
         setEventMetadata("VALID_COD_AREA",",oparms:[]}");
         setEventMetadata("VALID_INDICADORESCODIGO","{handler:'Valid_Indicadorescodigo',iparms:[{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:''}]");
         setEventMetadata("VALID_INDICADORESCODIGO",",oparms:[]}");
         setEventMetadata("VALID_TIPOSENFERMEDADESCOD","{handler:'Valid_Tiposenfermedadescod',iparms:[{av:'A90TiposEnfermedadesCod',fld:'TIPOSENFERMEDADESCOD',pic:''}]");
         setEventMetadata("VALID_TIPOSENFERMEDADESCOD",",oparms:[]}");
         setEventMetadata("VALID_MATERIALPALMASCOD","{handler:'Valid_Materialpalmascod',iparms:[{av:'A91MATERIALPALMASCOD',fld:'MATERIALPALMASCOD',pic:''}]");
         setEventMetadata("VALID_MATERIALPALMASCOD",",oparms:[]}");
         setEventMetadata("VALID_INCIDENCIAPCREG","{handler:'Valid_Incidenciapcreg',iparms:[]");
         setEventMetadata("VALID_INCIDENCIAPCREG",",oparms:[]}");
         setEventMetadata("VALID_INCIDENCIAPCZONA","{handler:'Valid_Incidenciapczona',iparms:[]");
         setEventMetadata("VALID_INCIDENCIAPCZONA",",oparms:[]}");
         setEventMetadata("VALID_INCIDENCIAPCLOTE","{handler:'Valid_Incidenciapclote',iparms:[{av:'A104INCIDENCIAPCFec',fld:'INCIDENCIAPCFEC',pic:''},{av:'A105INCIDENCIAPCMes',fld:'INCIDENCIAPCMES',pic:'ZZZ9'},{av:'A106INCIDENCIAPCano',fld:'INCIDENCIAPCANO',pic:'ZZZ9'},{av:'A5Cod_Area',fld:'COD_AREA',pic:''},{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:''},{av:'A90TiposEnfermedadesCod',fld:'TIPOSENFERMEDADESCOD',pic:''},{av:'A91MATERIALPALMASCOD',fld:'MATERIALPALMASCOD',pic:''},{av:'A107INCIDENCIAPCZONA',fld:'INCIDENCIAPCZONA',pic:''},{av:'A108INCIDENCIAPCLOTE',fld:'INCIDENCIAPCLOTE',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_INCIDENCIAPCLOTE",",oparms:[{av:'A180INCIDENCIAPCCasos',fld:'INCIDENCIAPCCASOS',pic:'ZZZZZZZZ9.99'},{av:'A181INCIDENCIAPCPalmas',fld:'INCIDENCIAPCPALMAS',pic:'ZZZZZZZZZZZ9'},{av:'A182INCIDENCIAPCuser',fld:'INCIDENCIAPCUSER',pic:''},{av:'A183INCIDENCIAPCreg',fld:'INCIDENCIAPCREG',pic:''},{av:'A184INCIDENCIAPChor',fld:'INCIDENCIAPCHOR',pic:''},{av:'A264INCIDENCIAPCUMA',fld:'INCIDENCIAPCUMA',pic:''},{av:'A265INCIDENCIAPCSIEMBRA',fld:'INCIDENCIAPCSIEMBRA',pic:'ZZZZZZZZZZZ9'},{av:'A266INCIDENCIAPCGRUPOZONA',fld:'INCIDENCIAPCGRUPOZONA',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z104INCIDENCIAPCFec'},{av:'Z105INCIDENCIAPCMes'},{av:'Z106INCIDENCIAPCano'},{av:'Z5Cod_Area'},{av:'Z4IndicadoresCodigo'},{av:'Z90TiposEnfermedadesCod'},{av:'Z91MATERIALPALMASCOD'},{av:'Z107INCIDENCIAPCZONA'},{av:'Z108INCIDENCIAPCLOTE'},{av:'Z180INCIDENCIAPCCasos'},{av:'Z181INCIDENCIAPCPalmas'},{av:'Z182INCIDENCIAPCuser'},{av:'Z183INCIDENCIAPCreg'},{av:'Z184INCIDENCIAPChor'},{av:'Z264INCIDENCIAPCUMA'},{av:'Z265INCIDENCIAPCSIEMBRA'},{av:'Z266INCIDENCIAPCGRUPOZONA'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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
         Z104INCIDENCIAPCFec = DateTime.MinValue;
         Z5Cod_Area = "";
         Z4IndicadoresCodigo = "";
         Z90TiposEnfermedadesCod = "";
         Z91MATERIALPALMASCOD = "";
         Z107INCIDENCIAPCZONA = "";
         Z108INCIDENCIAPCLOTE = "";
         Z182INCIDENCIAPCuser = "";
         Z183INCIDENCIAPCreg = DateTime.MinValue;
         Z184INCIDENCIAPChor = "";
         Z264INCIDENCIAPCUMA = "";
         Z266INCIDENCIAPCGRUPOZONA = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A5Cod_Area = "";
         A4IndicadoresCodigo = "";
         A90TiposEnfermedadesCod = "";
         A91MATERIALPALMASCOD = "";
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
         A104INCIDENCIAPCFec = DateTime.MinValue;
         imgprompt_5_gximage = "";
         sImgUrl = "";
         imgprompt_4_gximage = "";
         imgprompt_90_gximage = "";
         imgprompt_91_gximage = "";
         A182INCIDENCIAPCuser = "";
         A183INCIDENCIAPCreg = DateTime.MinValue;
         A184INCIDENCIAPChor = "";
         A107INCIDENCIAPCZONA = "";
         A108INCIDENCIAPCLOTE = "";
         A264INCIDENCIAPCUMA = "";
         A266INCIDENCIAPCGRUPOZONA = "";
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
         T000U8_A104INCIDENCIAPCFec = new DateTime[] {DateTime.MinValue} ;
         T000U8_A105INCIDENCIAPCMes = new short[1] ;
         T000U8_A106INCIDENCIAPCano = new short[1] ;
         T000U8_A107INCIDENCIAPCZONA = new string[] {""} ;
         T000U8_A108INCIDENCIAPCLOTE = new string[] {""} ;
         T000U8_A180INCIDENCIAPCCasos = new decimal[1] ;
         T000U8_A181INCIDENCIAPCPalmas = new long[1] ;
         T000U8_A182INCIDENCIAPCuser = new string[] {""} ;
         T000U8_A183INCIDENCIAPCreg = new DateTime[] {DateTime.MinValue} ;
         T000U8_A184INCIDENCIAPChor = new string[] {""} ;
         T000U8_A264INCIDENCIAPCUMA = new string[] {""} ;
         T000U8_A265INCIDENCIAPCSIEMBRA = new long[1] ;
         T000U8_A266INCIDENCIAPCGRUPOZONA = new string[] {""} ;
         T000U8_A5Cod_Area = new string[] {""} ;
         T000U8_A4IndicadoresCodigo = new string[] {""} ;
         T000U8_A90TiposEnfermedadesCod = new string[] {""} ;
         T000U8_A91MATERIALPALMASCOD = new string[] {""} ;
         T000U4_A5Cod_Area = new string[] {""} ;
         T000U5_A4IndicadoresCodigo = new string[] {""} ;
         T000U6_A90TiposEnfermedadesCod = new string[] {""} ;
         T000U7_A91MATERIALPALMASCOD = new string[] {""} ;
         T000U9_A5Cod_Area = new string[] {""} ;
         T000U10_A4IndicadoresCodigo = new string[] {""} ;
         T000U11_A90TiposEnfermedadesCod = new string[] {""} ;
         T000U12_A91MATERIALPALMASCOD = new string[] {""} ;
         T000U13_A104INCIDENCIAPCFec = new DateTime[] {DateTime.MinValue} ;
         T000U13_A105INCIDENCIAPCMes = new short[1] ;
         T000U13_A106INCIDENCIAPCano = new short[1] ;
         T000U13_A5Cod_Area = new string[] {""} ;
         T000U13_A4IndicadoresCodigo = new string[] {""} ;
         T000U13_A90TiposEnfermedadesCod = new string[] {""} ;
         T000U13_A91MATERIALPALMASCOD = new string[] {""} ;
         T000U13_A107INCIDENCIAPCZONA = new string[] {""} ;
         T000U13_A108INCIDENCIAPCLOTE = new string[] {""} ;
         T000U3_A104INCIDENCIAPCFec = new DateTime[] {DateTime.MinValue} ;
         T000U3_A105INCIDENCIAPCMes = new short[1] ;
         T000U3_A106INCIDENCIAPCano = new short[1] ;
         T000U3_A107INCIDENCIAPCZONA = new string[] {""} ;
         T000U3_A108INCIDENCIAPCLOTE = new string[] {""} ;
         T000U3_A180INCIDENCIAPCCasos = new decimal[1] ;
         T000U3_A181INCIDENCIAPCPalmas = new long[1] ;
         T000U3_A182INCIDENCIAPCuser = new string[] {""} ;
         T000U3_A183INCIDENCIAPCreg = new DateTime[] {DateTime.MinValue} ;
         T000U3_A184INCIDENCIAPChor = new string[] {""} ;
         T000U3_A264INCIDENCIAPCUMA = new string[] {""} ;
         T000U3_A265INCIDENCIAPCSIEMBRA = new long[1] ;
         T000U3_A266INCIDENCIAPCGRUPOZONA = new string[] {""} ;
         T000U3_A5Cod_Area = new string[] {""} ;
         T000U3_A4IndicadoresCodigo = new string[] {""} ;
         T000U3_A90TiposEnfermedadesCod = new string[] {""} ;
         T000U3_A91MATERIALPALMASCOD = new string[] {""} ;
         sMode31 = "";
         T000U14_A104INCIDENCIAPCFec = new DateTime[] {DateTime.MinValue} ;
         T000U14_A105INCIDENCIAPCMes = new short[1] ;
         T000U14_A106INCIDENCIAPCano = new short[1] ;
         T000U14_A5Cod_Area = new string[] {""} ;
         T000U14_A4IndicadoresCodigo = new string[] {""} ;
         T000U14_A90TiposEnfermedadesCod = new string[] {""} ;
         T000U14_A91MATERIALPALMASCOD = new string[] {""} ;
         T000U14_A107INCIDENCIAPCZONA = new string[] {""} ;
         T000U14_A108INCIDENCIAPCLOTE = new string[] {""} ;
         T000U15_A104INCIDENCIAPCFec = new DateTime[] {DateTime.MinValue} ;
         T000U15_A105INCIDENCIAPCMes = new short[1] ;
         T000U15_A106INCIDENCIAPCano = new short[1] ;
         T000U15_A5Cod_Area = new string[] {""} ;
         T000U15_A4IndicadoresCodigo = new string[] {""} ;
         T000U15_A90TiposEnfermedadesCod = new string[] {""} ;
         T000U15_A91MATERIALPALMASCOD = new string[] {""} ;
         T000U15_A107INCIDENCIAPCZONA = new string[] {""} ;
         T000U15_A108INCIDENCIAPCLOTE = new string[] {""} ;
         T000U2_A104INCIDENCIAPCFec = new DateTime[] {DateTime.MinValue} ;
         T000U2_A105INCIDENCIAPCMes = new short[1] ;
         T000U2_A106INCIDENCIAPCano = new short[1] ;
         T000U2_A107INCIDENCIAPCZONA = new string[] {""} ;
         T000U2_A108INCIDENCIAPCLOTE = new string[] {""} ;
         T000U2_A180INCIDENCIAPCCasos = new decimal[1] ;
         T000U2_A181INCIDENCIAPCPalmas = new long[1] ;
         T000U2_A182INCIDENCIAPCuser = new string[] {""} ;
         T000U2_A183INCIDENCIAPCreg = new DateTime[] {DateTime.MinValue} ;
         T000U2_A184INCIDENCIAPChor = new string[] {""} ;
         T000U2_A264INCIDENCIAPCUMA = new string[] {""} ;
         T000U2_A265INCIDENCIAPCSIEMBRA = new long[1] ;
         T000U2_A266INCIDENCIAPCGRUPOZONA = new string[] {""} ;
         T000U2_A5Cod_Area = new string[] {""} ;
         T000U2_A4IndicadoresCodigo = new string[] {""} ;
         T000U2_A90TiposEnfermedadesCod = new string[] {""} ;
         T000U2_A91MATERIALPALMASCOD = new string[] {""} ;
         T000U19_A104INCIDENCIAPCFec = new DateTime[] {DateTime.MinValue} ;
         T000U19_A105INCIDENCIAPCMes = new short[1] ;
         T000U19_A106INCIDENCIAPCano = new short[1] ;
         T000U19_A5Cod_Area = new string[] {""} ;
         T000U19_A4IndicadoresCodigo = new string[] {""} ;
         T000U19_A90TiposEnfermedadesCod = new string[] {""} ;
         T000U19_A91MATERIALPALMASCOD = new string[] {""} ;
         T000U19_A107INCIDENCIAPCZONA = new string[] {""} ;
         T000U19_A108INCIDENCIAPCLOTE = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T000U20_A5Cod_Area = new string[] {""} ;
         T000U21_A4IndicadoresCodigo = new string[] {""} ;
         T000U22_A90TiposEnfermedadesCod = new string[] {""} ;
         T000U23_A91MATERIALPALMASCOD = new string[] {""} ;
         ZZ104INCIDENCIAPCFec = DateTime.MinValue;
         ZZ5Cod_Area = "";
         ZZ4IndicadoresCodigo = "";
         ZZ90TiposEnfermedadesCod = "";
         ZZ91MATERIALPALMASCOD = "";
         ZZ107INCIDENCIAPCZONA = "";
         ZZ108INCIDENCIAPCLOTE = "";
         ZZ182INCIDENCIAPCuser = "";
         ZZ183INCIDENCIAPCreg = DateTime.MinValue;
         ZZ184INCIDENCIAPChor = "";
         ZZ264INCIDENCIAPCUMA = "";
         ZZ266INCIDENCIAPCGRUPOZONA = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.incidenciapc__default(),
            new Object[][] {
                new Object[] {
               T000U2_A104INCIDENCIAPCFec, T000U2_A105INCIDENCIAPCMes, T000U2_A106INCIDENCIAPCano, T000U2_A107INCIDENCIAPCZONA, T000U2_A108INCIDENCIAPCLOTE, T000U2_A180INCIDENCIAPCCasos, T000U2_A181INCIDENCIAPCPalmas, T000U2_A182INCIDENCIAPCuser, T000U2_A183INCIDENCIAPCreg, T000U2_A184INCIDENCIAPChor,
               T000U2_A264INCIDENCIAPCUMA, T000U2_A265INCIDENCIAPCSIEMBRA, T000U2_A266INCIDENCIAPCGRUPOZONA, T000U2_A5Cod_Area, T000U2_A4IndicadoresCodigo, T000U2_A90TiposEnfermedadesCod, T000U2_A91MATERIALPALMASCOD
               }
               , new Object[] {
               T000U3_A104INCIDENCIAPCFec, T000U3_A105INCIDENCIAPCMes, T000U3_A106INCIDENCIAPCano, T000U3_A107INCIDENCIAPCZONA, T000U3_A108INCIDENCIAPCLOTE, T000U3_A180INCIDENCIAPCCasos, T000U3_A181INCIDENCIAPCPalmas, T000U3_A182INCIDENCIAPCuser, T000U3_A183INCIDENCIAPCreg, T000U3_A184INCIDENCIAPChor,
               T000U3_A264INCIDENCIAPCUMA, T000U3_A265INCIDENCIAPCSIEMBRA, T000U3_A266INCIDENCIAPCGRUPOZONA, T000U3_A5Cod_Area, T000U3_A4IndicadoresCodigo, T000U3_A90TiposEnfermedadesCod, T000U3_A91MATERIALPALMASCOD
               }
               , new Object[] {
               T000U4_A5Cod_Area
               }
               , new Object[] {
               T000U5_A4IndicadoresCodigo
               }
               , new Object[] {
               T000U6_A90TiposEnfermedadesCod
               }
               , new Object[] {
               T000U7_A91MATERIALPALMASCOD
               }
               , new Object[] {
               T000U8_A104INCIDENCIAPCFec, T000U8_A105INCIDENCIAPCMes, T000U8_A106INCIDENCIAPCano, T000U8_A107INCIDENCIAPCZONA, T000U8_A108INCIDENCIAPCLOTE, T000U8_A180INCIDENCIAPCCasos, T000U8_A181INCIDENCIAPCPalmas, T000U8_A182INCIDENCIAPCuser, T000U8_A183INCIDENCIAPCreg, T000U8_A184INCIDENCIAPChor,
               T000U8_A264INCIDENCIAPCUMA, T000U8_A265INCIDENCIAPCSIEMBRA, T000U8_A266INCIDENCIAPCGRUPOZONA, T000U8_A5Cod_Area, T000U8_A4IndicadoresCodigo, T000U8_A90TiposEnfermedadesCod, T000U8_A91MATERIALPALMASCOD
               }
               , new Object[] {
               T000U9_A5Cod_Area
               }
               , new Object[] {
               T000U10_A4IndicadoresCodigo
               }
               , new Object[] {
               T000U11_A90TiposEnfermedadesCod
               }
               , new Object[] {
               T000U12_A91MATERIALPALMASCOD
               }
               , new Object[] {
               T000U13_A104INCIDENCIAPCFec, T000U13_A105INCIDENCIAPCMes, T000U13_A106INCIDENCIAPCano, T000U13_A5Cod_Area, T000U13_A4IndicadoresCodigo, T000U13_A90TiposEnfermedadesCod, T000U13_A91MATERIALPALMASCOD, T000U13_A107INCIDENCIAPCZONA, T000U13_A108INCIDENCIAPCLOTE
               }
               , new Object[] {
               T000U14_A104INCIDENCIAPCFec, T000U14_A105INCIDENCIAPCMes, T000U14_A106INCIDENCIAPCano, T000U14_A5Cod_Area, T000U14_A4IndicadoresCodigo, T000U14_A90TiposEnfermedadesCod, T000U14_A91MATERIALPALMASCOD, T000U14_A107INCIDENCIAPCZONA, T000U14_A108INCIDENCIAPCLOTE
               }
               , new Object[] {
               T000U15_A104INCIDENCIAPCFec, T000U15_A105INCIDENCIAPCMes, T000U15_A106INCIDENCIAPCano, T000U15_A5Cod_Area, T000U15_A4IndicadoresCodigo, T000U15_A90TiposEnfermedadesCod, T000U15_A91MATERIALPALMASCOD, T000U15_A107INCIDENCIAPCZONA, T000U15_A108INCIDENCIAPCLOTE
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000U19_A104INCIDENCIAPCFec, T000U19_A105INCIDENCIAPCMes, T000U19_A106INCIDENCIAPCano, T000U19_A5Cod_Area, T000U19_A4IndicadoresCodigo, T000U19_A90TiposEnfermedadesCod, T000U19_A91MATERIALPALMASCOD, T000U19_A107INCIDENCIAPCZONA, T000U19_A108INCIDENCIAPCLOTE
               }
               , new Object[] {
               T000U20_A5Cod_Area
               }
               , new Object[] {
               T000U21_A4IndicadoresCodigo
               }
               , new Object[] {
               T000U22_A90TiposEnfermedadesCod
               }
               , new Object[] {
               T000U23_A91MATERIALPALMASCOD
               }
            }
         );
      }

      private short Z105INCIDENCIAPCMes ;
      private short Z106INCIDENCIAPCano ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A105INCIDENCIAPCMes ;
      private short A106INCIDENCIAPCano ;
      private short GX_JID ;
      private short RcdFound31 ;
      private short nIsDirty_31 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ105INCIDENCIAPCMes ;
      private short ZZ106INCIDENCIAPCano ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtINCIDENCIAPCFec_Enabled ;
      private int edtINCIDENCIAPCMes_Enabled ;
      private int edtINCIDENCIAPCano_Enabled ;
      private int edtCod_Area_Enabled ;
      private int imgprompt_5_Visible ;
      private int edtIndicadoresCodigo_Enabled ;
      private int imgprompt_4_Visible ;
      private int edtTiposEnfermedadesCod_Enabled ;
      private int imgprompt_90_Visible ;
      private int edtMATERIALPALMASCOD_Enabled ;
      private int imgprompt_91_Visible ;
      private int edtINCIDENCIAPCCasos_Enabled ;
      private int edtINCIDENCIAPCPalmas_Enabled ;
      private int edtINCIDENCIAPCuser_Enabled ;
      private int edtINCIDENCIAPCreg_Enabled ;
      private int edtINCIDENCIAPChor_Enabled ;
      private int edtINCIDENCIAPCZONA_Enabled ;
      private int edtINCIDENCIAPCLOTE_Enabled ;
      private int edtINCIDENCIAPCUMA_Enabled ;
      private int edtINCIDENCIAPCSIEMBRA_Enabled ;
      private int edtINCIDENCIAPCGRUPOZONA_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z181INCIDENCIAPCPalmas ;
      private long Z265INCIDENCIAPCSIEMBRA ;
      private long A181INCIDENCIAPCPalmas ;
      private long A265INCIDENCIAPCSIEMBRA ;
      private long ZZ181INCIDENCIAPCPalmas ;
      private long ZZ265INCIDENCIAPCSIEMBRA ;
      private decimal Z180INCIDENCIAPCCasos ;
      private decimal A180INCIDENCIAPCCasos ;
      private decimal ZZ180INCIDENCIAPCCasos ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtINCIDENCIAPCFec_Internalname ;
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
      private string edtINCIDENCIAPCFec_Jsonclick ;
      private string edtINCIDENCIAPCMes_Internalname ;
      private string edtINCIDENCIAPCMes_Jsonclick ;
      private string edtINCIDENCIAPCano_Internalname ;
      private string edtINCIDENCIAPCano_Jsonclick ;
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
      private string edtTiposEnfermedadesCod_Internalname ;
      private string edtTiposEnfermedadesCod_Jsonclick ;
      private string imgprompt_90_gximage ;
      private string imgprompt_90_Internalname ;
      private string imgprompt_90_Link ;
      private string edtMATERIALPALMASCOD_Internalname ;
      private string edtMATERIALPALMASCOD_Jsonclick ;
      private string imgprompt_91_gximage ;
      private string imgprompt_91_Internalname ;
      private string imgprompt_91_Link ;
      private string edtINCIDENCIAPCCasos_Internalname ;
      private string edtINCIDENCIAPCCasos_Jsonclick ;
      private string edtINCIDENCIAPCPalmas_Internalname ;
      private string edtINCIDENCIAPCPalmas_Jsonclick ;
      private string edtINCIDENCIAPCuser_Internalname ;
      private string edtINCIDENCIAPCuser_Jsonclick ;
      private string edtINCIDENCIAPCreg_Internalname ;
      private string edtINCIDENCIAPCreg_Jsonclick ;
      private string edtINCIDENCIAPChor_Internalname ;
      private string edtINCIDENCIAPChor_Jsonclick ;
      private string edtINCIDENCIAPCZONA_Internalname ;
      private string edtINCIDENCIAPCZONA_Jsonclick ;
      private string edtINCIDENCIAPCLOTE_Internalname ;
      private string edtINCIDENCIAPCLOTE_Jsonclick ;
      private string edtINCIDENCIAPCUMA_Internalname ;
      private string edtINCIDENCIAPCUMA_Jsonclick ;
      private string edtINCIDENCIAPCSIEMBRA_Internalname ;
      private string edtINCIDENCIAPCSIEMBRA_Jsonclick ;
      private string edtINCIDENCIAPCGRUPOZONA_Internalname ;
      private string edtINCIDENCIAPCGRUPOZONA_Jsonclick ;
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
      private string sMode31 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z104INCIDENCIAPCFec ;
      private DateTime Z183INCIDENCIAPCreg ;
      private DateTime A104INCIDENCIAPCFec ;
      private DateTime A183INCIDENCIAPCreg ;
      private DateTime ZZ104INCIDENCIAPCFec ;
      private DateTime ZZ183INCIDENCIAPCreg ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private string Z5Cod_Area ;
      private string Z4IndicadoresCodigo ;
      private string Z90TiposEnfermedadesCod ;
      private string Z91MATERIALPALMASCOD ;
      private string Z107INCIDENCIAPCZONA ;
      private string Z108INCIDENCIAPCLOTE ;
      private string Z182INCIDENCIAPCuser ;
      private string Z184INCIDENCIAPChor ;
      private string Z264INCIDENCIAPCUMA ;
      private string Z266INCIDENCIAPCGRUPOZONA ;
      private string A5Cod_Area ;
      private string A4IndicadoresCodigo ;
      private string A90TiposEnfermedadesCod ;
      private string A91MATERIALPALMASCOD ;
      private string A182INCIDENCIAPCuser ;
      private string A184INCIDENCIAPChor ;
      private string A107INCIDENCIAPCZONA ;
      private string A108INCIDENCIAPCLOTE ;
      private string A264INCIDENCIAPCUMA ;
      private string A266INCIDENCIAPCGRUPOZONA ;
      private string ZZ5Cod_Area ;
      private string ZZ4IndicadoresCodigo ;
      private string ZZ90TiposEnfermedadesCod ;
      private string ZZ91MATERIALPALMASCOD ;
      private string ZZ107INCIDENCIAPCZONA ;
      private string ZZ108INCIDENCIAPCLOTE ;
      private string ZZ182INCIDENCIAPCuser ;
      private string ZZ184INCIDENCIAPChor ;
      private string ZZ264INCIDENCIAPCUMA ;
      private string ZZ266INCIDENCIAPCGRUPOZONA ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] T000U8_A104INCIDENCIAPCFec ;
      private short[] T000U8_A105INCIDENCIAPCMes ;
      private short[] T000U8_A106INCIDENCIAPCano ;
      private string[] T000U8_A107INCIDENCIAPCZONA ;
      private string[] T000U8_A108INCIDENCIAPCLOTE ;
      private decimal[] T000U8_A180INCIDENCIAPCCasos ;
      private long[] T000U8_A181INCIDENCIAPCPalmas ;
      private string[] T000U8_A182INCIDENCIAPCuser ;
      private DateTime[] T000U8_A183INCIDENCIAPCreg ;
      private string[] T000U8_A184INCIDENCIAPChor ;
      private string[] T000U8_A264INCIDENCIAPCUMA ;
      private long[] T000U8_A265INCIDENCIAPCSIEMBRA ;
      private string[] T000U8_A266INCIDENCIAPCGRUPOZONA ;
      private string[] T000U8_A5Cod_Area ;
      private string[] T000U8_A4IndicadoresCodigo ;
      private string[] T000U8_A90TiposEnfermedadesCod ;
      private string[] T000U8_A91MATERIALPALMASCOD ;
      private string[] T000U4_A5Cod_Area ;
      private string[] T000U5_A4IndicadoresCodigo ;
      private string[] T000U6_A90TiposEnfermedadesCod ;
      private string[] T000U7_A91MATERIALPALMASCOD ;
      private string[] T000U9_A5Cod_Area ;
      private string[] T000U10_A4IndicadoresCodigo ;
      private string[] T000U11_A90TiposEnfermedadesCod ;
      private string[] T000U12_A91MATERIALPALMASCOD ;
      private DateTime[] T000U13_A104INCIDENCIAPCFec ;
      private short[] T000U13_A105INCIDENCIAPCMes ;
      private short[] T000U13_A106INCIDENCIAPCano ;
      private string[] T000U13_A5Cod_Area ;
      private string[] T000U13_A4IndicadoresCodigo ;
      private string[] T000U13_A90TiposEnfermedadesCod ;
      private string[] T000U13_A91MATERIALPALMASCOD ;
      private string[] T000U13_A107INCIDENCIAPCZONA ;
      private string[] T000U13_A108INCIDENCIAPCLOTE ;
      private DateTime[] T000U3_A104INCIDENCIAPCFec ;
      private short[] T000U3_A105INCIDENCIAPCMes ;
      private short[] T000U3_A106INCIDENCIAPCano ;
      private string[] T000U3_A107INCIDENCIAPCZONA ;
      private string[] T000U3_A108INCIDENCIAPCLOTE ;
      private decimal[] T000U3_A180INCIDENCIAPCCasos ;
      private long[] T000U3_A181INCIDENCIAPCPalmas ;
      private string[] T000U3_A182INCIDENCIAPCuser ;
      private DateTime[] T000U3_A183INCIDENCIAPCreg ;
      private string[] T000U3_A184INCIDENCIAPChor ;
      private string[] T000U3_A264INCIDENCIAPCUMA ;
      private long[] T000U3_A265INCIDENCIAPCSIEMBRA ;
      private string[] T000U3_A266INCIDENCIAPCGRUPOZONA ;
      private string[] T000U3_A5Cod_Area ;
      private string[] T000U3_A4IndicadoresCodigo ;
      private string[] T000U3_A90TiposEnfermedadesCod ;
      private string[] T000U3_A91MATERIALPALMASCOD ;
      private DateTime[] T000U14_A104INCIDENCIAPCFec ;
      private short[] T000U14_A105INCIDENCIAPCMes ;
      private short[] T000U14_A106INCIDENCIAPCano ;
      private string[] T000U14_A5Cod_Area ;
      private string[] T000U14_A4IndicadoresCodigo ;
      private string[] T000U14_A90TiposEnfermedadesCod ;
      private string[] T000U14_A91MATERIALPALMASCOD ;
      private string[] T000U14_A107INCIDENCIAPCZONA ;
      private string[] T000U14_A108INCIDENCIAPCLOTE ;
      private DateTime[] T000U15_A104INCIDENCIAPCFec ;
      private short[] T000U15_A105INCIDENCIAPCMes ;
      private short[] T000U15_A106INCIDENCIAPCano ;
      private string[] T000U15_A5Cod_Area ;
      private string[] T000U15_A4IndicadoresCodigo ;
      private string[] T000U15_A90TiposEnfermedadesCod ;
      private string[] T000U15_A91MATERIALPALMASCOD ;
      private string[] T000U15_A107INCIDENCIAPCZONA ;
      private string[] T000U15_A108INCIDENCIAPCLOTE ;
      private DateTime[] T000U2_A104INCIDENCIAPCFec ;
      private short[] T000U2_A105INCIDENCIAPCMes ;
      private short[] T000U2_A106INCIDENCIAPCano ;
      private string[] T000U2_A107INCIDENCIAPCZONA ;
      private string[] T000U2_A108INCIDENCIAPCLOTE ;
      private decimal[] T000U2_A180INCIDENCIAPCCasos ;
      private long[] T000U2_A181INCIDENCIAPCPalmas ;
      private string[] T000U2_A182INCIDENCIAPCuser ;
      private DateTime[] T000U2_A183INCIDENCIAPCreg ;
      private string[] T000U2_A184INCIDENCIAPChor ;
      private string[] T000U2_A264INCIDENCIAPCUMA ;
      private long[] T000U2_A265INCIDENCIAPCSIEMBRA ;
      private string[] T000U2_A266INCIDENCIAPCGRUPOZONA ;
      private string[] T000U2_A5Cod_Area ;
      private string[] T000U2_A4IndicadoresCodigo ;
      private string[] T000U2_A90TiposEnfermedadesCod ;
      private string[] T000U2_A91MATERIALPALMASCOD ;
      private DateTime[] T000U19_A104INCIDENCIAPCFec ;
      private short[] T000U19_A105INCIDENCIAPCMes ;
      private short[] T000U19_A106INCIDENCIAPCano ;
      private string[] T000U19_A5Cod_Area ;
      private string[] T000U19_A4IndicadoresCodigo ;
      private string[] T000U19_A90TiposEnfermedadesCod ;
      private string[] T000U19_A91MATERIALPALMASCOD ;
      private string[] T000U19_A107INCIDENCIAPCZONA ;
      private string[] T000U19_A108INCIDENCIAPCLOTE ;
      private string[] T000U20_A5Cod_Area ;
      private string[] T000U21_A4IndicadoresCodigo ;
      private string[] T000U22_A90TiposEnfermedadesCod ;
      private string[] T000U23_A91MATERIALPALMASCOD ;
      private GXWebForm Form ;
   }

   public class incidenciapc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT000U8;
          prmT000U8 = new Object[] {
          new ParDef("@INCIDENCIAPCFec",GXType.Date,8,0) ,
          new ParDef("@INCIDENCIAPCMes",GXType.Int16,4,0) ,
          new ParDef("@INCIDENCIAPCano",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@TiposEnfermedadesCod",GXType.NVarChar,40,0) ,
          new ParDef("@MATERIALPALMASCOD",GXType.NVarChar,140,0) ,
          new ParDef("@INCIDENCIAPCZONA",GXType.NVarChar,40,0) ,
          new ParDef("@INCIDENCIAPCLOTE",GXType.NVarChar,40,0)
          };
          Object[] prmT000U4;
          prmT000U4 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000U5;
          prmT000U5 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000U6;
          prmT000U6 = new Object[] {
          new ParDef("@TiposEnfermedadesCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000U7;
          prmT000U7 = new Object[] {
          new ParDef("@MATERIALPALMASCOD",GXType.NVarChar,140,0)
          };
          Object[] prmT000U9;
          prmT000U9 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000U10;
          prmT000U10 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000U11;
          prmT000U11 = new Object[] {
          new ParDef("@TiposEnfermedadesCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000U12;
          prmT000U12 = new Object[] {
          new ParDef("@MATERIALPALMASCOD",GXType.NVarChar,140,0)
          };
          Object[] prmT000U13;
          prmT000U13 = new Object[] {
          new ParDef("@INCIDENCIAPCFec",GXType.Date,8,0) ,
          new ParDef("@INCIDENCIAPCMes",GXType.Int16,4,0) ,
          new ParDef("@INCIDENCIAPCano",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@TiposEnfermedadesCod",GXType.NVarChar,40,0) ,
          new ParDef("@MATERIALPALMASCOD",GXType.NVarChar,140,0) ,
          new ParDef("@INCIDENCIAPCZONA",GXType.NVarChar,40,0) ,
          new ParDef("@INCIDENCIAPCLOTE",GXType.NVarChar,40,0)
          };
          Object[] prmT000U3;
          prmT000U3 = new Object[] {
          new ParDef("@INCIDENCIAPCFec",GXType.Date,8,0) ,
          new ParDef("@INCIDENCIAPCMes",GXType.Int16,4,0) ,
          new ParDef("@INCIDENCIAPCano",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@TiposEnfermedadesCod",GXType.NVarChar,40,0) ,
          new ParDef("@MATERIALPALMASCOD",GXType.NVarChar,140,0) ,
          new ParDef("@INCIDENCIAPCZONA",GXType.NVarChar,40,0) ,
          new ParDef("@INCIDENCIAPCLOTE",GXType.NVarChar,40,0)
          };
          Object[] prmT000U14;
          prmT000U14 = new Object[] {
          new ParDef("@INCIDENCIAPCFec",GXType.Date,8,0) ,
          new ParDef("@INCIDENCIAPCMes",GXType.Int16,4,0) ,
          new ParDef("@INCIDENCIAPCano",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@TiposEnfermedadesCod",GXType.NVarChar,40,0) ,
          new ParDef("@MATERIALPALMASCOD",GXType.NVarChar,140,0) ,
          new ParDef("@INCIDENCIAPCZONA",GXType.NVarChar,40,0) ,
          new ParDef("@INCIDENCIAPCLOTE",GXType.NVarChar,40,0)
          };
          string cmdBufferT000U14;
          cmdBufferT000U14=" SELECT TOP 1 [INCIDENCIAPCFec], [INCIDENCIAPCMes], [INCIDENCIAPCano], [Cod_Area], [IndicadoresCodigo], [TiposEnfermedadesCod], [MATERIALPALMASCOD], [INCIDENCIAPCZONA], [INCIDENCIAPCLOTE] FROM [INCIDENCIAPC] WHERE ( [INCIDENCIAPCFec] > @INCIDENCIAPCFec or [INCIDENCIAPCFec] = @INCIDENCIAPCFec and [INCIDENCIAPCMes] > @INCIDENCIAPCMes or [INCIDENCIAPCMes] = @INCIDENCIAPCMes and [INCIDENCIAPCFec] = @INCIDENCIAPCFec and [INCIDENCIAPCano] > @INCIDENCIAPCano or [INCIDENCIAPCano] = @INCIDENCIAPCano and [INCIDENCIAPCMes] = @INCIDENCIAPCMes and [INCIDENCIAPCFec] = @INCIDENCIAPCFec and [Cod_Area] > @Cod_Area or [Cod_Area] = @Cod_Area and [INCIDENCIAPCano] = @INCIDENCIAPCano and [INCIDENCIAPCMes] = @INCIDENCIAPCMes and [INCIDENCIAPCFec] = @INCIDENCIAPCFec and [IndicadoresCodigo] > @IndicadoresCodigo or [IndicadoresCodigo] = @IndicadoresCodigo and [Cod_Area] = @Cod_Area and [INCIDENCIAPCano] = @INCIDENCIAPCano and [INCIDENCIAPCMes] = @INCIDENCIAPCMes and [INCIDENCIAPCFec] = @INCIDENCIAPCFec and [TiposEnfermedadesCod] > @TiposEnfermedadesCod or [TiposEnfermedadesCod] = @TiposEnfermedadesCod and [IndicadoresCodigo] = @IndicadoresCodigo and [Cod_Area] = @Cod_Area and [INCIDENCIAPCano] = @INCIDENCIAPCano and [INCIDENCIAPCMes] = @INCIDENCIAPCMes and [INCIDENCIAPCFec] = @INCIDENCIAPCFec and [MATERIALPALMASCOD] > @MATERIALPALMASCOD or [MATERIALPALMASCOD] = @MATERIALPALMASCOD and [TiposEnfermedadesCod] = @TiposEnfermedadesCod and [IndicadoresCodigo] = @IndicadoresCodigo and [Cod_Area] = @Cod_Area and [INCIDENCIAPCano] = @INCIDENCIAPCano and [INCIDENCIAPCMes] = @INCIDENCIAPCMes and [INCIDENCIAPCFec] = @INCIDENCIAPCFec and [INCIDENCIAPCZONA] > @INCIDENCIAPCZONA or [INCIDENCIAPCZONA] = @INCIDENCIAPCZONA and [MATERIALPALMASCOD] = @MATERIALPALMASCOD and [TiposEnfermedadesCod] = @TiposEnfermedadesCod "
          + " and [IndicadoresCodigo] = @IndicadoresCodigo and [Cod_Area] = @Cod_Area and [INCIDENCIAPCano] = @INCIDENCIAPCano and [INCIDENCIAPCMes] = @INCIDENCIAPCMes and [INCIDENCIAPCFec] = @INCIDENCIAPCFec and [INCIDENCIAPCLOTE] > @INCIDENCIAPCLOTE) ORDER BY [INCIDENCIAPCFec], [INCIDENCIAPCMes], [INCIDENCIAPCano], [Cod_Area], [IndicadoresCodigo], [TiposEnfermedadesCod], [MATERIALPALMASCOD], [INCIDENCIAPCZONA], [INCIDENCIAPCLOTE]  OPTION (FAST 1)" ;
          Object[] prmT000U15;
          prmT000U15 = new Object[] {
          new ParDef("@INCIDENCIAPCFec",GXType.Date,8,0) ,
          new ParDef("@INCIDENCIAPCMes",GXType.Int16,4,0) ,
          new ParDef("@INCIDENCIAPCano",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@TiposEnfermedadesCod",GXType.NVarChar,40,0) ,
          new ParDef("@MATERIALPALMASCOD",GXType.NVarChar,140,0) ,
          new ParDef("@INCIDENCIAPCZONA",GXType.NVarChar,40,0) ,
          new ParDef("@INCIDENCIAPCLOTE",GXType.NVarChar,40,0)
          };
          string cmdBufferT000U15;
          cmdBufferT000U15=" SELECT TOP 1 [INCIDENCIAPCFec], [INCIDENCIAPCMes], [INCIDENCIAPCano], [Cod_Area], [IndicadoresCodigo], [TiposEnfermedadesCod], [MATERIALPALMASCOD], [INCIDENCIAPCZONA], [INCIDENCIAPCLOTE] FROM [INCIDENCIAPC] WHERE ( [INCIDENCIAPCFec] < @INCIDENCIAPCFec or [INCIDENCIAPCFec] = @INCIDENCIAPCFec and [INCIDENCIAPCMes] < @INCIDENCIAPCMes or [INCIDENCIAPCMes] = @INCIDENCIAPCMes and [INCIDENCIAPCFec] = @INCIDENCIAPCFec and [INCIDENCIAPCano] < @INCIDENCIAPCano or [INCIDENCIAPCano] = @INCIDENCIAPCano and [INCIDENCIAPCMes] = @INCIDENCIAPCMes and [INCIDENCIAPCFec] = @INCIDENCIAPCFec and [Cod_Area] < @Cod_Area or [Cod_Area] = @Cod_Area and [INCIDENCIAPCano] = @INCIDENCIAPCano and [INCIDENCIAPCMes] = @INCIDENCIAPCMes and [INCIDENCIAPCFec] = @INCIDENCIAPCFec and [IndicadoresCodigo] < @IndicadoresCodigo or [IndicadoresCodigo] = @IndicadoresCodigo and [Cod_Area] = @Cod_Area and [INCIDENCIAPCano] = @INCIDENCIAPCano and [INCIDENCIAPCMes] = @INCIDENCIAPCMes and [INCIDENCIAPCFec] = @INCIDENCIAPCFec and [TiposEnfermedadesCod] < @TiposEnfermedadesCod or [TiposEnfermedadesCod] = @TiposEnfermedadesCod and [IndicadoresCodigo] = @IndicadoresCodigo and [Cod_Area] = @Cod_Area and [INCIDENCIAPCano] = @INCIDENCIAPCano and [INCIDENCIAPCMes] = @INCIDENCIAPCMes and [INCIDENCIAPCFec] = @INCIDENCIAPCFec and [MATERIALPALMASCOD] < @MATERIALPALMASCOD or [MATERIALPALMASCOD] = @MATERIALPALMASCOD and [TiposEnfermedadesCod] = @TiposEnfermedadesCod and [IndicadoresCodigo] = @IndicadoresCodigo and [Cod_Area] = @Cod_Area and [INCIDENCIAPCano] = @INCIDENCIAPCano and [INCIDENCIAPCMes] = @INCIDENCIAPCMes and [INCIDENCIAPCFec] = @INCIDENCIAPCFec and [INCIDENCIAPCZONA] < @INCIDENCIAPCZONA or [INCIDENCIAPCZONA] = @INCIDENCIAPCZONA and [MATERIALPALMASCOD] = @MATERIALPALMASCOD and [TiposEnfermedadesCod] = @TiposEnfermedadesCod "
          + " and [IndicadoresCodigo] = @IndicadoresCodigo and [Cod_Area] = @Cod_Area and [INCIDENCIAPCano] = @INCIDENCIAPCano and [INCIDENCIAPCMes] = @INCIDENCIAPCMes and [INCIDENCIAPCFec] = @INCIDENCIAPCFec and [INCIDENCIAPCLOTE] < @INCIDENCIAPCLOTE) ORDER BY [INCIDENCIAPCFec] DESC, [INCIDENCIAPCMes] DESC, [INCIDENCIAPCano] DESC, [Cod_Area] DESC, [IndicadoresCodigo] DESC, [TiposEnfermedadesCod] DESC, [MATERIALPALMASCOD] DESC, [INCIDENCIAPCZONA] DESC, [INCIDENCIAPCLOTE] DESC  OPTION (FAST 1)" ;
          Object[] prmT000U2;
          prmT000U2 = new Object[] {
          new ParDef("@INCIDENCIAPCFec",GXType.Date,8,0) ,
          new ParDef("@INCIDENCIAPCMes",GXType.Int16,4,0) ,
          new ParDef("@INCIDENCIAPCano",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@TiposEnfermedadesCod",GXType.NVarChar,40,0) ,
          new ParDef("@MATERIALPALMASCOD",GXType.NVarChar,140,0) ,
          new ParDef("@INCIDENCIAPCZONA",GXType.NVarChar,40,0) ,
          new ParDef("@INCIDENCIAPCLOTE",GXType.NVarChar,40,0)
          };
          Object[] prmT000U16;
          prmT000U16 = new Object[] {
          new ParDef("@INCIDENCIAPCFec",GXType.Date,8,0) ,
          new ParDef("@INCIDENCIAPCMes",GXType.Int16,4,0) ,
          new ParDef("@INCIDENCIAPCano",GXType.Int16,4,0) ,
          new ParDef("@INCIDENCIAPCZONA",GXType.NVarChar,40,0) ,
          new ParDef("@INCIDENCIAPCLOTE",GXType.NVarChar,40,0) ,
          new ParDef("@INCIDENCIAPCCasos",GXType.Decimal,12,2) ,
          new ParDef("@INCIDENCIAPCPalmas",GXType.Decimal,12,0) ,
          new ParDef("@INCIDENCIAPCuser",GXType.NVarChar,150,0) ,
          new ParDef("@INCIDENCIAPCreg",GXType.Date,8,0) ,
          new ParDef("@INCIDENCIAPChor",GXType.NVarChar,40,0) ,
          new ParDef("@INCIDENCIAPCUMA",GXType.NVarChar,40,0) ,
          new ParDef("@INCIDENCIAPCSIEMBRA",GXType.Decimal,12,0) ,
          new ParDef("@INCIDENCIAPCGRUPOZONA",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@TiposEnfermedadesCod",GXType.NVarChar,40,0) ,
          new ParDef("@MATERIALPALMASCOD",GXType.NVarChar,140,0)
          };
          Object[] prmT000U17;
          prmT000U17 = new Object[] {
          new ParDef("@INCIDENCIAPCCasos",GXType.Decimal,12,2) ,
          new ParDef("@INCIDENCIAPCPalmas",GXType.Decimal,12,0) ,
          new ParDef("@INCIDENCIAPCuser",GXType.NVarChar,150,0) ,
          new ParDef("@INCIDENCIAPCreg",GXType.Date,8,0) ,
          new ParDef("@INCIDENCIAPChor",GXType.NVarChar,40,0) ,
          new ParDef("@INCIDENCIAPCUMA",GXType.NVarChar,40,0) ,
          new ParDef("@INCIDENCIAPCSIEMBRA",GXType.Decimal,12,0) ,
          new ParDef("@INCIDENCIAPCGRUPOZONA",GXType.NVarChar,40,0) ,
          new ParDef("@INCIDENCIAPCFec",GXType.Date,8,0) ,
          new ParDef("@INCIDENCIAPCMes",GXType.Int16,4,0) ,
          new ParDef("@INCIDENCIAPCano",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@TiposEnfermedadesCod",GXType.NVarChar,40,0) ,
          new ParDef("@MATERIALPALMASCOD",GXType.NVarChar,140,0) ,
          new ParDef("@INCIDENCIAPCZONA",GXType.NVarChar,40,0) ,
          new ParDef("@INCIDENCIAPCLOTE",GXType.NVarChar,40,0)
          };
          Object[] prmT000U18;
          prmT000U18 = new Object[] {
          new ParDef("@INCIDENCIAPCFec",GXType.Date,8,0) ,
          new ParDef("@INCIDENCIAPCMes",GXType.Int16,4,0) ,
          new ParDef("@INCIDENCIAPCano",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@TiposEnfermedadesCod",GXType.NVarChar,40,0) ,
          new ParDef("@MATERIALPALMASCOD",GXType.NVarChar,140,0) ,
          new ParDef("@INCIDENCIAPCZONA",GXType.NVarChar,40,0) ,
          new ParDef("@INCIDENCIAPCLOTE",GXType.NVarChar,40,0)
          };
          Object[] prmT000U19;
          prmT000U19 = new Object[] {
          };
          Object[] prmT000U20;
          prmT000U20 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000U21;
          prmT000U21 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000U22;
          prmT000U22 = new Object[] {
          new ParDef("@TiposEnfermedadesCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000U23;
          prmT000U23 = new Object[] {
          new ParDef("@MATERIALPALMASCOD",GXType.NVarChar,140,0)
          };
          def= new CursorDef[] {
              new CursorDef("T000U2", "SELECT [INCIDENCIAPCFec], [INCIDENCIAPCMes], [INCIDENCIAPCano], [INCIDENCIAPCZONA], [INCIDENCIAPCLOTE], [INCIDENCIAPCCasos], [INCIDENCIAPCPalmas], [INCIDENCIAPCuser], [INCIDENCIAPCreg], [INCIDENCIAPChor], [INCIDENCIAPCUMA], [INCIDENCIAPCSIEMBRA], [INCIDENCIAPCGRUPOZONA], [Cod_Area], [IndicadoresCodigo], [TiposEnfermedadesCod], [MATERIALPALMASCOD] FROM [INCIDENCIAPC] WITH (UPDLOCK) WHERE [INCIDENCIAPCFec] = @INCIDENCIAPCFec AND [INCIDENCIAPCMes] = @INCIDENCIAPCMes AND [INCIDENCIAPCano] = @INCIDENCIAPCano AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo AND [TiposEnfermedadesCod] = @TiposEnfermedadesCod AND [MATERIALPALMASCOD] = @MATERIALPALMASCOD AND [INCIDENCIAPCZONA] = @INCIDENCIAPCZONA AND [INCIDENCIAPCLOTE] = @INCIDENCIAPCLOTE ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000U3", "SELECT [INCIDENCIAPCFec], [INCIDENCIAPCMes], [INCIDENCIAPCano], [INCIDENCIAPCZONA], [INCIDENCIAPCLOTE], [INCIDENCIAPCCasos], [INCIDENCIAPCPalmas], [INCIDENCIAPCuser], [INCIDENCIAPCreg], [INCIDENCIAPChor], [INCIDENCIAPCUMA], [INCIDENCIAPCSIEMBRA], [INCIDENCIAPCGRUPOZONA], [Cod_Area], [IndicadoresCodigo], [TiposEnfermedadesCod], [MATERIALPALMASCOD] FROM [INCIDENCIAPC] WHERE [INCIDENCIAPCFec] = @INCIDENCIAPCFec AND [INCIDENCIAPCMes] = @INCIDENCIAPCMes AND [INCIDENCIAPCano] = @INCIDENCIAPCano AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo AND [TiposEnfermedadesCod] = @TiposEnfermedadesCod AND [MATERIALPALMASCOD] = @MATERIALPALMASCOD AND [INCIDENCIAPCZONA] = @INCIDENCIAPCZONA AND [INCIDENCIAPCLOTE] = @INCIDENCIAPCLOTE ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000U4", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000U5", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000U6", "SELECT [TiposEnfermedadesCod] FROM [TiposEnfermedades] WHERE [TiposEnfermedadesCod] = @TiposEnfermedadesCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000U7", "SELECT [MATERIALPALMASCOD] FROM [MATERIALPALMAS] WHERE [MATERIALPALMASCOD] = @MATERIALPALMASCOD ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000U8", "SELECT TM1.[INCIDENCIAPCFec], TM1.[INCIDENCIAPCMes], TM1.[INCIDENCIAPCano], TM1.[INCIDENCIAPCZONA], TM1.[INCIDENCIAPCLOTE], TM1.[INCIDENCIAPCCasos], TM1.[INCIDENCIAPCPalmas], TM1.[INCIDENCIAPCuser], TM1.[INCIDENCIAPCreg], TM1.[INCIDENCIAPChor], TM1.[INCIDENCIAPCUMA], TM1.[INCIDENCIAPCSIEMBRA], TM1.[INCIDENCIAPCGRUPOZONA], TM1.[Cod_Area], TM1.[IndicadoresCodigo], TM1.[TiposEnfermedadesCod], TM1.[MATERIALPALMASCOD] FROM [INCIDENCIAPC] TM1 WHERE TM1.[INCIDENCIAPCFec] = @INCIDENCIAPCFec and TM1.[INCIDENCIAPCMes] = @INCIDENCIAPCMes and TM1.[INCIDENCIAPCano] = @INCIDENCIAPCano and TM1.[Cod_Area] = @Cod_Area and TM1.[IndicadoresCodigo] = @IndicadoresCodigo and TM1.[TiposEnfermedadesCod] = @TiposEnfermedadesCod and TM1.[MATERIALPALMASCOD] = @MATERIALPALMASCOD and TM1.[INCIDENCIAPCZONA] = @INCIDENCIAPCZONA and TM1.[INCIDENCIAPCLOTE] = @INCIDENCIAPCLOTE ORDER BY TM1.[INCIDENCIAPCFec], TM1.[INCIDENCIAPCMes], TM1.[INCIDENCIAPCano], TM1.[Cod_Area], TM1.[IndicadoresCodigo], TM1.[TiposEnfermedadesCod], TM1.[MATERIALPALMASCOD], TM1.[INCIDENCIAPCZONA], TM1.[INCIDENCIAPCLOTE]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000U8,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000U9", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000U10", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U10,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000U11", "SELECT [TiposEnfermedadesCod] FROM [TiposEnfermedades] WHERE [TiposEnfermedadesCod] = @TiposEnfermedadesCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000U12", "SELECT [MATERIALPALMASCOD] FROM [MATERIALPALMAS] WHERE [MATERIALPALMASCOD] = @MATERIALPALMASCOD ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U12,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000U13", "SELECT [INCIDENCIAPCFec], [INCIDENCIAPCMes], [INCIDENCIAPCano], [Cod_Area], [IndicadoresCodigo], [TiposEnfermedadesCod], [MATERIALPALMASCOD], [INCIDENCIAPCZONA], [INCIDENCIAPCLOTE] FROM [INCIDENCIAPC] WHERE [INCIDENCIAPCFec] = @INCIDENCIAPCFec AND [INCIDENCIAPCMes] = @INCIDENCIAPCMes AND [INCIDENCIAPCano] = @INCIDENCIAPCano AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo AND [TiposEnfermedadesCod] = @TiposEnfermedadesCod AND [MATERIALPALMASCOD] = @MATERIALPALMASCOD AND [INCIDENCIAPCZONA] = @INCIDENCIAPCZONA AND [INCIDENCIAPCLOTE] = @INCIDENCIAPCLOTE  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000U13,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000U14", cmdBufferT000U14,true, GxErrorMask.GX_NOMASK, false, this,prmT000U14,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000U15", cmdBufferT000U15,true, GxErrorMask.GX_NOMASK, false, this,prmT000U15,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000U16", "INSERT INTO [INCIDENCIAPC]([INCIDENCIAPCFec], [INCIDENCIAPCMes], [INCIDENCIAPCano], [INCIDENCIAPCZONA], [INCIDENCIAPCLOTE], [INCIDENCIAPCCasos], [INCIDENCIAPCPalmas], [INCIDENCIAPCuser], [INCIDENCIAPCreg], [INCIDENCIAPChor], [INCIDENCIAPCUMA], [INCIDENCIAPCSIEMBRA], [INCIDENCIAPCGRUPOZONA], [Cod_Area], [IndicadoresCodigo], [TiposEnfermedadesCod], [MATERIALPALMASCOD]) VALUES(@INCIDENCIAPCFec, @INCIDENCIAPCMes, @INCIDENCIAPCano, @INCIDENCIAPCZONA, @INCIDENCIAPCLOTE, @INCIDENCIAPCCasos, @INCIDENCIAPCPalmas, @INCIDENCIAPCuser, @INCIDENCIAPCreg, @INCIDENCIAPChor, @INCIDENCIAPCUMA, @INCIDENCIAPCSIEMBRA, @INCIDENCIAPCGRUPOZONA, @Cod_Area, @IndicadoresCodigo, @TiposEnfermedadesCod, @MATERIALPALMASCOD)", GxErrorMask.GX_NOMASK,prmT000U16)
             ,new CursorDef("T000U17", "UPDATE [INCIDENCIAPC] SET [INCIDENCIAPCCasos]=@INCIDENCIAPCCasos, [INCIDENCIAPCPalmas]=@INCIDENCIAPCPalmas, [INCIDENCIAPCuser]=@INCIDENCIAPCuser, [INCIDENCIAPCreg]=@INCIDENCIAPCreg, [INCIDENCIAPChor]=@INCIDENCIAPChor, [INCIDENCIAPCUMA]=@INCIDENCIAPCUMA, [INCIDENCIAPCSIEMBRA]=@INCIDENCIAPCSIEMBRA, [INCIDENCIAPCGRUPOZONA]=@INCIDENCIAPCGRUPOZONA  WHERE [INCIDENCIAPCFec] = @INCIDENCIAPCFec AND [INCIDENCIAPCMes] = @INCIDENCIAPCMes AND [INCIDENCIAPCano] = @INCIDENCIAPCano AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo AND [TiposEnfermedadesCod] = @TiposEnfermedadesCod AND [MATERIALPALMASCOD] = @MATERIALPALMASCOD AND [INCIDENCIAPCZONA] = @INCIDENCIAPCZONA AND [INCIDENCIAPCLOTE] = @INCIDENCIAPCLOTE", GxErrorMask.GX_NOMASK,prmT000U17)
             ,new CursorDef("T000U18", "DELETE FROM [INCIDENCIAPC]  WHERE [INCIDENCIAPCFec] = @INCIDENCIAPCFec AND [INCIDENCIAPCMes] = @INCIDENCIAPCMes AND [INCIDENCIAPCano] = @INCIDENCIAPCano AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo AND [TiposEnfermedadesCod] = @TiposEnfermedadesCod AND [MATERIALPALMASCOD] = @MATERIALPALMASCOD AND [INCIDENCIAPCZONA] = @INCIDENCIAPCZONA AND [INCIDENCIAPCLOTE] = @INCIDENCIAPCLOTE", GxErrorMask.GX_NOMASK,prmT000U18)
             ,new CursorDef("T000U19", "SELECT [INCIDENCIAPCFec], [INCIDENCIAPCMes], [INCIDENCIAPCano], [Cod_Area], [IndicadoresCodigo], [TiposEnfermedadesCod], [MATERIALPALMASCOD], [INCIDENCIAPCZONA], [INCIDENCIAPCLOTE] FROM [INCIDENCIAPC] ORDER BY [INCIDENCIAPCFec], [INCIDENCIAPCMes], [INCIDENCIAPCano], [Cod_Area], [IndicadoresCodigo], [TiposEnfermedadesCod], [MATERIALPALMASCOD], [INCIDENCIAPCZONA], [INCIDENCIAPCLOTE]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000U19,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000U20", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U20,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000U21", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U21,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000U22", "SELECT [TiposEnfermedadesCod] FROM [TiposEnfermedades] WHERE [TiposEnfermedadesCod] = @TiposEnfermedadesCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U22,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000U23", "SELECT [MATERIALPALMASCOD] FROM [MATERIALPALMAS] WHERE [MATERIALPALMASCOD] = @MATERIALPALMASCOD ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U23,1, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((long[]) buf[11])[0] = rslt.getLong(12);
                ((string[]) buf[12])[0] = rslt.getVarchar(13);
                ((string[]) buf[13])[0] = rslt.getVarchar(14);
                ((string[]) buf[14])[0] = rslt.getVarchar(15);
                ((string[]) buf[15])[0] = rslt.getVarchar(16);
                ((string[]) buf[16])[0] = rslt.getVarchar(17);
                return;
             case 1 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((long[]) buf[11])[0] = rslt.getLong(12);
                ((string[]) buf[12])[0] = rslt.getVarchar(13);
                ((string[]) buf[13])[0] = rslt.getVarchar(14);
                ((string[]) buf[14])[0] = rslt.getVarchar(15);
                ((string[]) buf[15])[0] = rslt.getVarchar(16);
                ((string[]) buf[16])[0] = rslt.getVarchar(17);
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
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((long[]) buf[11])[0] = rslt.getLong(12);
                ((string[]) buf[12])[0] = rslt.getVarchar(13);
                ((string[]) buf[13])[0] = rslt.getVarchar(14);
                ((string[]) buf[14])[0] = rslt.getVarchar(15);
                ((string[]) buf[15])[0] = rslt.getVarchar(16);
                ((string[]) buf[16])[0] = rslt.getVarchar(17);
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
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                return;
             case 12 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                return;
             case 13 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                return;
             case 17 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
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
