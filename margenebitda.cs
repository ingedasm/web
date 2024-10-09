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
   public class margenebitda : GXDataArea
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
            A63MOTIVOMARGENCod = GetPar( "MOTIVOMARGENCod");
            AssignAttri("", false, "A63MOTIVOMARGENCod", A63MOTIVOMARGENCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A63MOTIVOMARGENCod) ;
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
            Form.Meta.addItem("description", "MARGENEBITDA", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtMARGENEBITDAFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("IndicadroresPalmas", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public margenebitda( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("IndicadroresPalmas", true);
      }

      public margenebitda( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "MARGENEBITDA", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_MARGENEBITDA.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_MARGENEBITDA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_MARGENEBITDA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_MARGENEBITDA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_MARGENEBITDA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 4, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx00x0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"MARGENEBITDAFECHA"+"'), id:'"+"MARGENEBITDAFECHA"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"MARGENEBITDAMES"+"'), id:'"+"MARGENEBITDAMES"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"MARGENEBITDAANO"+"'), id:'"+"MARGENEBITDAANO"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"COD_AREA"+"'), id:'"+"COD_AREA"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"INDICADORESCODIGO"+"'), id:'"+"INDICADORESCODIGO"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"MOTIVOMARGENCOD"+"'), id:'"+"MOTIVOMARGENCOD"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_MARGENEBITDA.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMARGENEBITDAFecha_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMARGENEBITDAFecha_Internalname, "MARGENEBITDAFecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtMARGENEBITDAFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtMARGENEBITDAFecha_Internalname, context.localUtil.Format(A74MARGENEBITDAFecha, "99/99/99"), context.localUtil.Format( A74MARGENEBITDAFecha, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMARGENEBITDAFecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMARGENEBITDAFecha_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_MARGENEBITDA.htm");
         GxWebStd.gx_bitmap( context, edtMARGENEBITDAFecha_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtMARGENEBITDAFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_MARGENEBITDA.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMARGENEBITDAMes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMARGENEBITDAMes_Internalname, "MARGENEBITDAMes", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMARGENEBITDAMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A75MARGENEBITDAMes), 4, 0, ",", "")), StringUtil.LTrim( ((edtMARGENEBITDAMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A75MARGENEBITDAMes), "ZZZ9") : context.localUtil.Format( (decimal)(A75MARGENEBITDAMes), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMARGENEBITDAMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMARGENEBITDAMes_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_MARGENEBITDA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMARGENEBITDAAno_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMARGENEBITDAAno_Internalname, "MARGENEBITDAAno", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMARGENEBITDAAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A76MARGENEBITDAAno), 4, 0, ",", "")), StringUtil.LTrim( ((edtMARGENEBITDAAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A76MARGENEBITDAAno), "ZZZ9") : context.localUtil.Format( (decimal)(A76MARGENEBITDAAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMARGENEBITDAAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMARGENEBITDAAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_MARGENEBITDA.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCod_Area_Internalname, A5Cod_Area, StringUtil.RTrim( context.localUtil.Format( A5Cod_Area, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCod_Area_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCod_Area_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_MARGENEBITDA.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_5_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_5_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_5_Internalname, sImgUrl, imgprompt_5_Link, "", "", context.GetTheme( ), imgprompt_5_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_MARGENEBITDA.htm");
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
         GxWebStd.gx_single_line_edit( context, edtIndicadoresCodigo_Internalname, A4IndicadoresCodigo, StringUtil.RTrim( context.localUtil.Format( A4IndicadoresCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIndicadoresCodigo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIndicadoresCodigo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_MARGENEBITDA.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_4_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_4_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_4_Internalname, sImgUrl, imgprompt_4_Link, "", "", context.GetTheme( ), imgprompt_4_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_MARGENEBITDA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMOTIVOMARGENCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMOTIVOMARGENCod_Internalname, "MOTIVOMARGENCod", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMOTIVOMARGENCod_Internalname, A63MOTIVOMARGENCod, StringUtil.RTrim( context.localUtil.Format( A63MOTIVOMARGENCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMOTIVOMARGENCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMOTIVOMARGENCod_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_MARGENEBITDA.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_63_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_63_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_63_Internalname, sImgUrl, imgprompt_63_Link, "", "", context.GetTheme( ), imgprompt_63_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_MARGENEBITDA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMARGENEBITDAValor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMARGENEBITDAValor_Internalname, "MARGENEBITDAValor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMARGENEBITDAValor_Internalname, StringUtil.LTrim( StringUtil.NToC( A186MARGENEBITDAValor, 12, 3, ",", "")), StringUtil.LTrim( ((edtMARGENEBITDAValor_Enabled!=0) ? context.localUtil.Format( A186MARGENEBITDAValor, "ZZZZZZZ9.999") : context.localUtil.Format( A186MARGENEBITDAValor, "ZZZZZZZ9.999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','3');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','3');"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMARGENEBITDAValor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMARGENEBITDAValor_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_MARGENEBITDA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMARGENEBITDAuser_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMARGENEBITDAuser_Internalname, "MARGENEBITDAuser", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMARGENEBITDAuser_Internalname, A187MARGENEBITDAuser, StringUtil.RTrim( context.localUtil.Format( A187MARGENEBITDAuser, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMARGENEBITDAuser_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMARGENEBITDAuser_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_MARGENEBITDA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMARGENEBITDAfec_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMARGENEBITDAfec_Internalname, "MARGENEBITDAfec", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtMARGENEBITDAfec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtMARGENEBITDAfec_Internalname, context.localUtil.Format(A188MARGENEBITDAfec, "99/99/99"), context.localUtil.Format( A188MARGENEBITDAfec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMARGENEBITDAfec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMARGENEBITDAfec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_MARGENEBITDA.htm");
         GxWebStd.gx_bitmap( context, edtMARGENEBITDAfec_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtMARGENEBITDAfec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_MARGENEBITDA.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMARGENEBITDAhor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMARGENEBITDAhor_Internalname, "MARGENEBITDAhor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMARGENEBITDAhor_Internalname, A189MARGENEBITDAhor, StringUtil.RTrim( context.localUtil.Format( A189MARGENEBITDAhor, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMARGENEBITDAhor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMARGENEBITDAhor_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_MARGENEBITDA.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_MARGENEBITDA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_MARGENEBITDA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_MARGENEBITDA.htm");
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
            Z74MARGENEBITDAFecha = context.localUtil.CToD( cgiGet( "Z74MARGENEBITDAFecha"), 0);
            Z75MARGENEBITDAMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z75MARGENEBITDAMes"), ",", "."), 18, MidpointRounding.ToEven));
            Z76MARGENEBITDAAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z76MARGENEBITDAAno"), ",", "."), 18, MidpointRounding.ToEven));
            Z5Cod_Area = cgiGet( "Z5Cod_Area");
            Z4IndicadoresCodigo = cgiGet( "Z4IndicadoresCodigo");
            Z63MOTIVOMARGENCod = cgiGet( "Z63MOTIVOMARGENCod");
            Z186MARGENEBITDAValor = context.localUtil.CToN( cgiGet( "Z186MARGENEBITDAValor"), ",", ".");
            Z187MARGENEBITDAuser = cgiGet( "Z187MARGENEBITDAuser");
            Z188MARGENEBITDAfec = context.localUtil.CToD( cgiGet( "Z188MARGENEBITDAfec"), 0);
            Z189MARGENEBITDAhor = cgiGet( "Z189MARGENEBITDAhor");
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( context.localUtil.VCDate( cgiGet( edtMARGENEBITDAFecha_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"MARGENEBITDAFecha"}), 1, "MARGENEBITDAFECHA");
               AnyError = 1;
               GX_FocusControl = edtMARGENEBITDAFecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A74MARGENEBITDAFecha = DateTime.MinValue;
               AssignAttri("", false, "A74MARGENEBITDAFecha", context.localUtil.Format(A74MARGENEBITDAFecha, "99/99/99"));
            }
            else
            {
               A74MARGENEBITDAFecha = context.localUtil.CToD( cgiGet( edtMARGENEBITDAFecha_Internalname), 2);
               AssignAttri("", false, "A74MARGENEBITDAFecha", context.localUtil.Format(A74MARGENEBITDAFecha, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtMARGENEBITDAMes_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMARGENEBITDAMes_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MARGENEBITDAMES");
               AnyError = 1;
               GX_FocusControl = edtMARGENEBITDAMes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A75MARGENEBITDAMes = 0;
               AssignAttri("", false, "A75MARGENEBITDAMes", StringUtil.LTrimStr( (decimal)(A75MARGENEBITDAMes), 4, 0));
            }
            else
            {
               A75MARGENEBITDAMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtMARGENEBITDAMes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A75MARGENEBITDAMes", StringUtil.LTrimStr( (decimal)(A75MARGENEBITDAMes), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtMARGENEBITDAAno_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMARGENEBITDAAno_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MARGENEBITDAANO");
               AnyError = 1;
               GX_FocusControl = edtMARGENEBITDAAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A76MARGENEBITDAAno = 0;
               AssignAttri("", false, "A76MARGENEBITDAAno", StringUtil.LTrimStr( (decimal)(A76MARGENEBITDAAno), 4, 0));
            }
            else
            {
               A76MARGENEBITDAAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtMARGENEBITDAAno_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A76MARGENEBITDAAno", StringUtil.LTrimStr( (decimal)(A76MARGENEBITDAAno), 4, 0));
            }
            A5Cod_Area = cgiGet( edtCod_Area_Internalname);
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = cgiGet( edtIndicadoresCodigo_Internalname);
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A63MOTIVOMARGENCod = cgiGet( edtMOTIVOMARGENCod_Internalname);
            AssignAttri("", false, "A63MOTIVOMARGENCod", A63MOTIVOMARGENCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtMARGENEBITDAValor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMARGENEBITDAValor_Internalname), ",", ".") > 99999999.999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MARGENEBITDAVALOR");
               AnyError = 1;
               GX_FocusControl = edtMARGENEBITDAValor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A186MARGENEBITDAValor = 0;
               AssignAttri("", false, "A186MARGENEBITDAValor", StringUtil.LTrimStr( A186MARGENEBITDAValor, 12, 3));
            }
            else
            {
               A186MARGENEBITDAValor = context.localUtil.CToN( cgiGet( edtMARGENEBITDAValor_Internalname), ",", ".");
               AssignAttri("", false, "A186MARGENEBITDAValor", StringUtil.LTrimStr( A186MARGENEBITDAValor, 12, 3));
            }
            A187MARGENEBITDAuser = cgiGet( edtMARGENEBITDAuser_Internalname);
            AssignAttri("", false, "A187MARGENEBITDAuser", A187MARGENEBITDAuser);
            if ( context.localUtil.VCDate( cgiGet( edtMARGENEBITDAfec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"MARGENEBITDAfec"}), 1, "MARGENEBITDAFEC");
               AnyError = 1;
               GX_FocusControl = edtMARGENEBITDAfec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A188MARGENEBITDAfec = DateTime.MinValue;
               AssignAttri("", false, "A188MARGENEBITDAfec", context.localUtil.Format(A188MARGENEBITDAfec, "99/99/99"));
            }
            else
            {
               A188MARGENEBITDAfec = context.localUtil.CToD( cgiGet( edtMARGENEBITDAfec_Internalname), 2);
               AssignAttri("", false, "A188MARGENEBITDAfec", context.localUtil.Format(A188MARGENEBITDAfec, "99/99/99"));
            }
            A189MARGENEBITDAhor = cgiGet( edtMARGENEBITDAhor_Internalname);
            AssignAttri("", false, "A189MARGENEBITDAhor", A189MARGENEBITDAhor);
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
               A74MARGENEBITDAFecha = context.localUtil.ParseDateParm( GetPar( "MARGENEBITDAFecha"));
               AssignAttri("", false, "A74MARGENEBITDAFecha", context.localUtil.Format(A74MARGENEBITDAFecha, "99/99/99"));
               A75MARGENEBITDAMes = (short)(Math.Round(NumberUtil.Val( GetPar( "MARGENEBITDAMes"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A75MARGENEBITDAMes", StringUtil.LTrimStr( (decimal)(A75MARGENEBITDAMes), 4, 0));
               A76MARGENEBITDAAno = (short)(Math.Round(NumberUtil.Val( GetPar( "MARGENEBITDAAno"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A76MARGENEBITDAAno", StringUtil.LTrimStr( (decimal)(A76MARGENEBITDAAno), 4, 0));
               A5Cod_Area = GetPar( "Cod_Area");
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               A4IndicadoresCodigo = GetPar( "IndicadoresCodigo");
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               A63MOTIVOMARGENCod = GetPar( "MOTIVOMARGENCod");
               AssignAttri("", false, "A63MOTIVOMARGENCod", A63MOTIVOMARGENCod);
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
               InitAll0W33( ) ;
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
         DisableAttributes0W33( ) ;
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

      protected void ResetCaption0W0( )
      {
      }

      protected void ZM0W33( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z186MARGENEBITDAValor = T000W3_A186MARGENEBITDAValor[0];
               Z187MARGENEBITDAuser = T000W3_A187MARGENEBITDAuser[0];
               Z188MARGENEBITDAfec = T000W3_A188MARGENEBITDAfec[0];
               Z189MARGENEBITDAhor = T000W3_A189MARGENEBITDAhor[0];
            }
            else
            {
               Z186MARGENEBITDAValor = A186MARGENEBITDAValor;
               Z187MARGENEBITDAuser = A187MARGENEBITDAuser;
               Z188MARGENEBITDAfec = A188MARGENEBITDAfec;
               Z189MARGENEBITDAhor = A189MARGENEBITDAhor;
            }
         }
         if ( GX_JID == -3 )
         {
            Z74MARGENEBITDAFecha = A74MARGENEBITDAFecha;
            Z75MARGENEBITDAMes = A75MARGENEBITDAMes;
            Z76MARGENEBITDAAno = A76MARGENEBITDAAno;
            Z186MARGENEBITDAValor = A186MARGENEBITDAValor;
            Z187MARGENEBITDAuser = A187MARGENEBITDAuser;
            Z188MARGENEBITDAfec = A188MARGENEBITDAfec;
            Z189MARGENEBITDAhor = A189MARGENEBITDAhor;
            Z5Cod_Area = A5Cod_Area;
            Z4IndicadoresCodigo = A4IndicadoresCodigo;
            Z63MOTIVOMARGENCod = A63MOTIVOMARGENCod;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_5_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"COD_AREA"+"'), id:'"+"COD_AREA"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"true"+");");
         imgprompt_4_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0030.aspx"+"',["+"{Ctrl:gx.dom.el('"+"INDICADORESCODIGO"+"'), id:'"+"INDICADORESCODIGO"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"true"+");");
         imgprompt_63_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx00w0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"MOTIVOMARGENCOD"+"'), id:'"+"MOTIVOMARGENCOD"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");");
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

      protected void Load0W33( )
      {
         /* Using cursor T000W7 */
         pr_default.execute(5, new Object[] {A74MARGENEBITDAFecha, A75MARGENEBITDAMes, A76MARGENEBITDAAno, A5Cod_Area, A4IndicadoresCodigo, A63MOTIVOMARGENCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound33 = 1;
            A186MARGENEBITDAValor = T000W7_A186MARGENEBITDAValor[0];
            AssignAttri("", false, "A186MARGENEBITDAValor", StringUtil.LTrimStr( A186MARGENEBITDAValor, 12, 3));
            A187MARGENEBITDAuser = T000W7_A187MARGENEBITDAuser[0];
            AssignAttri("", false, "A187MARGENEBITDAuser", A187MARGENEBITDAuser);
            A188MARGENEBITDAfec = T000W7_A188MARGENEBITDAfec[0];
            AssignAttri("", false, "A188MARGENEBITDAfec", context.localUtil.Format(A188MARGENEBITDAfec, "99/99/99"));
            A189MARGENEBITDAhor = T000W7_A189MARGENEBITDAhor[0];
            AssignAttri("", false, "A189MARGENEBITDAhor", A189MARGENEBITDAhor);
            ZM0W33( -3) ;
         }
         pr_default.close(5);
         OnLoadActions0W33( ) ;
      }

      protected void OnLoadActions0W33( )
      {
      }

      protected void CheckExtendedTable0W33( )
      {
         nIsDirty_33 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A74MARGENEBITDAFecha) || ( DateTimeUtil.ResetTime ( A74MARGENEBITDAFecha ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo MARGENEBITDAFecha fuera de rango", "OutOfRange", 1, "MARGENEBITDAFECHA");
            AnyError = 1;
            GX_FocusControl = edtMARGENEBITDAFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000W4 */
         pr_default.execute(2, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T000W5 */
         pr_default.execute(3, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         /* Using cursor T000W6 */
         pr_default.execute(4, new Object[] {A63MOTIVOMARGENCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'MOTIVOMARGEN'.", "ForeignKeyNotFound", 1, "MOTIVOMARGENCOD");
            AnyError = 1;
            GX_FocusControl = edtMOTIVOMARGENCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(4);
         if ( ! ( (DateTime.MinValue==A188MARGENEBITDAfec) || ( DateTimeUtil.ResetTime ( A188MARGENEBITDAfec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo MARGENEBITDAfec fuera de rango", "OutOfRange", 1, "MARGENEBITDAFEC");
            AnyError = 1;
            GX_FocusControl = edtMARGENEBITDAfec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0W33( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_4( string A5Cod_Area )
      {
         /* Using cursor T000W8 */
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

      protected void gxLoad_5( string A4IndicadoresCodigo )
      {
         /* Using cursor T000W9 */
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

      protected void gxLoad_6( string A63MOTIVOMARGENCod )
      {
         /* Using cursor T000W10 */
         pr_default.execute(8, new Object[] {A63MOTIVOMARGENCod});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'MOTIVOMARGEN'.", "ForeignKeyNotFound", 1, "MOTIVOMARGENCOD");
            AnyError = 1;
            GX_FocusControl = edtMOTIVOMARGENCod_Internalname;
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

      protected void GetKey0W33( )
      {
         /* Using cursor T000W11 */
         pr_default.execute(9, new Object[] {A74MARGENEBITDAFecha, A75MARGENEBITDAMes, A76MARGENEBITDAAno, A5Cod_Area, A4IndicadoresCodigo, A63MOTIVOMARGENCod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound33 = 1;
         }
         else
         {
            RcdFound33 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000W3 */
         pr_default.execute(1, new Object[] {A74MARGENEBITDAFecha, A75MARGENEBITDAMes, A76MARGENEBITDAAno, A5Cod_Area, A4IndicadoresCodigo, A63MOTIVOMARGENCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0W33( 3) ;
            RcdFound33 = 1;
            A74MARGENEBITDAFecha = T000W3_A74MARGENEBITDAFecha[0];
            AssignAttri("", false, "A74MARGENEBITDAFecha", context.localUtil.Format(A74MARGENEBITDAFecha, "99/99/99"));
            A75MARGENEBITDAMes = T000W3_A75MARGENEBITDAMes[0];
            AssignAttri("", false, "A75MARGENEBITDAMes", StringUtil.LTrimStr( (decimal)(A75MARGENEBITDAMes), 4, 0));
            A76MARGENEBITDAAno = T000W3_A76MARGENEBITDAAno[0];
            AssignAttri("", false, "A76MARGENEBITDAAno", StringUtil.LTrimStr( (decimal)(A76MARGENEBITDAAno), 4, 0));
            A186MARGENEBITDAValor = T000W3_A186MARGENEBITDAValor[0];
            AssignAttri("", false, "A186MARGENEBITDAValor", StringUtil.LTrimStr( A186MARGENEBITDAValor, 12, 3));
            A187MARGENEBITDAuser = T000W3_A187MARGENEBITDAuser[0];
            AssignAttri("", false, "A187MARGENEBITDAuser", A187MARGENEBITDAuser);
            A188MARGENEBITDAfec = T000W3_A188MARGENEBITDAfec[0];
            AssignAttri("", false, "A188MARGENEBITDAfec", context.localUtil.Format(A188MARGENEBITDAfec, "99/99/99"));
            A189MARGENEBITDAhor = T000W3_A189MARGENEBITDAhor[0];
            AssignAttri("", false, "A189MARGENEBITDAhor", A189MARGENEBITDAhor);
            A5Cod_Area = T000W3_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = T000W3_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A63MOTIVOMARGENCod = T000W3_A63MOTIVOMARGENCod[0];
            AssignAttri("", false, "A63MOTIVOMARGENCod", A63MOTIVOMARGENCod);
            Z74MARGENEBITDAFecha = A74MARGENEBITDAFecha;
            Z75MARGENEBITDAMes = A75MARGENEBITDAMes;
            Z76MARGENEBITDAAno = A76MARGENEBITDAAno;
            Z5Cod_Area = A5Cod_Area;
            Z4IndicadoresCodigo = A4IndicadoresCodigo;
            Z63MOTIVOMARGENCod = A63MOTIVOMARGENCod;
            sMode33 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0W33( ) ;
            if ( AnyError == 1 )
            {
               RcdFound33 = 0;
               InitializeNonKey0W33( ) ;
            }
            Gx_mode = sMode33;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound33 = 0;
            InitializeNonKey0W33( ) ;
            sMode33 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode33;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0W33( ) ;
         if ( RcdFound33 == 0 )
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
         RcdFound33 = 0;
         /* Using cursor T000W12 */
         pr_default.execute(10, new Object[] {A74MARGENEBITDAFecha, A75MARGENEBITDAMes, A76MARGENEBITDAAno, A5Cod_Area, A4IndicadoresCodigo, A63MOTIVOMARGENCod});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( DateTimeUtil.ResetTime ( T000W12_A74MARGENEBITDAFecha[0] ) < DateTimeUtil.ResetTime ( A74MARGENEBITDAFecha ) ) || ( DateTimeUtil.ResetTime ( T000W12_A74MARGENEBITDAFecha[0] ) == DateTimeUtil.ResetTime ( A74MARGENEBITDAFecha ) ) && ( T000W12_A75MARGENEBITDAMes[0] < A75MARGENEBITDAMes ) || ( T000W12_A75MARGENEBITDAMes[0] == A75MARGENEBITDAMes ) && ( DateTimeUtil.ResetTime ( T000W12_A74MARGENEBITDAFecha[0] ) == DateTimeUtil.ResetTime ( A74MARGENEBITDAFecha ) ) && ( T000W12_A76MARGENEBITDAAno[0] < A76MARGENEBITDAAno ) || ( T000W12_A76MARGENEBITDAAno[0] == A76MARGENEBITDAAno ) && ( T000W12_A75MARGENEBITDAMes[0] == A75MARGENEBITDAMes ) && ( DateTimeUtil.ResetTime ( T000W12_A74MARGENEBITDAFecha[0] ) == DateTimeUtil.ResetTime ( A74MARGENEBITDAFecha ) ) && ( StringUtil.StrCmp(T000W12_A5Cod_Area[0], A5Cod_Area) < 0 ) || ( StringUtil.StrCmp(T000W12_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000W12_A76MARGENEBITDAAno[0] == A76MARGENEBITDAAno ) && ( T000W12_A75MARGENEBITDAMes[0] == A75MARGENEBITDAMes ) && ( DateTimeUtil.ResetTime ( T000W12_A74MARGENEBITDAFecha[0] ) == DateTimeUtil.ResetTime ( A74MARGENEBITDAFecha ) ) && ( StringUtil.StrCmp(T000W12_A4IndicadoresCodigo[0], A4IndicadoresCodigo) < 0 ) || ( StringUtil.StrCmp(T000W12_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T000W12_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000W12_A76MARGENEBITDAAno[0] == A76MARGENEBITDAAno ) && ( T000W12_A75MARGENEBITDAMes[0] == A75MARGENEBITDAMes ) && ( DateTimeUtil.ResetTime ( T000W12_A74MARGENEBITDAFecha[0] ) == DateTimeUtil.ResetTime ( A74MARGENEBITDAFecha ) ) && ( StringUtil.StrCmp(T000W12_A63MOTIVOMARGENCod[0], A63MOTIVOMARGENCod) < 0 ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( DateTimeUtil.ResetTime ( T000W12_A74MARGENEBITDAFecha[0] ) > DateTimeUtil.ResetTime ( A74MARGENEBITDAFecha ) ) || ( DateTimeUtil.ResetTime ( T000W12_A74MARGENEBITDAFecha[0] ) == DateTimeUtil.ResetTime ( A74MARGENEBITDAFecha ) ) && ( T000W12_A75MARGENEBITDAMes[0] > A75MARGENEBITDAMes ) || ( T000W12_A75MARGENEBITDAMes[0] == A75MARGENEBITDAMes ) && ( DateTimeUtil.ResetTime ( T000W12_A74MARGENEBITDAFecha[0] ) == DateTimeUtil.ResetTime ( A74MARGENEBITDAFecha ) ) && ( T000W12_A76MARGENEBITDAAno[0] > A76MARGENEBITDAAno ) || ( T000W12_A76MARGENEBITDAAno[0] == A76MARGENEBITDAAno ) && ( T000W12_A75MARGENEBITDAMes[0] == A75MARGENEBITDAMes ) && ( DateTimeUtil.ResetTime ( T000W12_A74MARGENEBITDAFecha[0] ) == DateTimeUtil.ResetTime ( A74MARGENEBITDAFecha ) ) && ( StringUtil.StrCmp(T000W12_A5Cod_Area[0], A5Cod_Area) > 0 ) || ( StringUtil.StrCmp(T000W12_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000W12_A76MARGENEBITDAAno[0] == A76MARGENEBITDAAno ) && ( T000W12_A75MARGENEBITDAMes[0] == A75MARGENEBITDAMes ) && ( DateTimeUtil.ResetTime ( T000W12_A74MARGENEBITDAFecha[0] ) == DateTimeUtil.ResetTime ( A74MARGENEBITDAFecha ) ) && ( StringUtil.StrCmp(T000W12_A4IndicadoresCodigo[0], A4IndicadoresCodigo) > 0 ) || ( StringUtil.StrCmp(T000W12_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T000W12_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000W12_A76MARGENEBITDAAno[0] == A76MARGENEBITDAAno ) && ( T000W12_A75MARGENEBITDAMes[0] == A75MARGENEBITDAMes ) && ( DateTimeUtil.ResetTime ( T000W12_A74MARGENEBITDAFecha[0] ) == DateTimeUtil.ResetTime ( A74MARGENEBITDAFecha ) ) && ( StringUtil.StrCmp(T000W12_A63MOTIVOMARGENCod[0], A63MOTIVOMARGENCod) > 0 ) ) )
            {
               A74MARGENEBITDAFecha = T000W12_A74MARGENEBITDAFecha[0];
               AssignAttri("", false, "A74MARGENEBITDAFecha", context.localUtil.Format(A74MARGENEBITDAFecha, "99/99/99"));
               A75MARGENEBITDAMes = T000W12_A75MARGENEBITDAMes[0];
               AssignAttri("", false, "A75MARGENEBITDAMes", StringUtil.LTrimStr( (decimal)(A75MARGENEBITDAMes), 4, 0));
               A76MARGENEBITDAAno = T000W12_A76MARGENEBITDAAno[0];
               AssignAttri("", false, "A76MARGENEBITDAAno", StringUtil.LTrimStr( (decimal)(A76MARGENEBITDAAno), 4, 0));
               A5Cod_Area = T000W12_A5Cod_Area[0];
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               A4IndicadoresCodigo = T000W12_A4IndicadoresCodigo[0];
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               A63MOTIVOMARGENCod = T000W12_A63MOTIVOMARGENCod[0];
               AssignAttri("", false, "A63MOTIVOMARGENCod", A63MOTIVOMARGENCod);
               RcdFound33 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound33 = 0;
         /* Using cursor T000W13 */
         pr_default.execute(11, new Object[] {A74MARGENEBITDAFecha, A75MARGENEBITDAMes, A76MARGENEBITDAAno, A5Cod_Area, A4IndicadoresCodigo, A63MOTIVOMARGENCod});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( DateTimeUtil.ResetTime ( T000W13_A74MARGENEBITDAFecha[0] ) > DateTimeUtil.ResetTime ( A74MARGENEBITDAFecha ) ) || ( DateTimeUtil.ResetTime ( T000W13_A74MARGENEBITDAFecha[0] ) == DateTimeUtil.ResetTime ( A74MARGENEBITDAFecha ) ) && ( T000W13_A75MARGENEBITDAMes[0] > A75MARGENEBITDAMes ) || ( T000W13_A75MARGENEBITDAMes[0] == A75MARGENEBITDAMes ) && ( DateTimeUtil.ResetTime ( T000W13_A74MARGENEBITDAFecha[0] ) == DateTimeUtil.ResetTime ( A74MARGENEBITDAFecha ) ) && ( T000W13_A76MARGENEBITDAAno[0] > A76MARGENEBITDAAno ) || ( T000W13_A76MARGENEBITDAAno[0] == A76MARGENEBITDAAno ) && ( T000W13_A75MARGENEBITDAMes[0] == A75MARGENEBITDAMes ) && ( DateTimeUtil.ResetTime ( T000W13_A74MARGENEBITDAFecha[0] ) == DateTimeUtil.ResetTime ( A74MARGENEBITDAFecha ) ) && ( StringUtil.StrCmp(T000W13_A5Cod_Area[0], A5Cod_Area) > 0 ) || ( StringUtil.StrCmp(T000W13_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000W13_A76MARGENEBITDAAno[0] == A76MARGENEBITDAAno ) && ( T000W13_A75MARGENEBITDAMes[0] == A75MARGENEBITDAMes ) && ( DateTimeUtil.ResetTime ( T000W13_A74MARGENEBITDAFecha[0] ) == DateTimeUtil.ResetTime ( A74MARGENEBITDAFecha ) ) && ( StringUtil.StrCmp(T000W13_A4IndicadoresCodigo[0], A4IndicadoresCodigo) > 0 ) || ( StringUtil.StrCmp(T000W13_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T000W13_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000W13_A76MARGENEBITDAAno[0] == A76MARGENEBITDAAno ) && ( T000W13_A75MARGENEBITDAMes[0] == A75MARGENEBITDAMes ) && ( DateTimeUtil.ResetTime ( T000W13_A74MARGENEBITDAFecha[0] ) == DateTimeUtil.ResetTime ( A74MARGENEBITDAFecha ) ) && ( StringUtil.StrCmp(T000W13_A63MOTIVOMARGENCod[0], A63MOTIVOMARGENCod) > 0 ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( DateTimeUtil.ResetTime ( T000W13_A74MARGENEBITDAFecha[0] ) < DateTimeUtil.ResetTime ( A74MARGENEBITDAFecha ) ) || ( DateTimeUtil.ResetTime ( T000W13_A74MARGENEBITDAFecha[0] ) == DateTimeUtil.ResetTime ( A74MARGENEBITDAFecha ) ) && ( T000W13_A75MARGENEBITDAMes[0] < A75MARGENEBITDAMes ) || ( T000W13_A75MARGENEBITDAMes[0] == A75MARGENEBITDAMes ) && ( DateTimeUtil.ResetTime ( T000W13_A74MARGENEBITDAFecha[0] ) == DateTimeUtil.ResetTime ( A74MARGENEBITDAFecha ) ) && ( T000W13_A76MARGENEBITDAAno[0] < A76MARGENEBITDAAno ) || ( T000W13_A76MARGENEBITDAAno[0] == A76MARGENEBITDAAno ) && ( T000W13_A75MARGENEBITDAMes[0] == A75MARGENEBITDAMes ) && ( DateTimeUtil.ResetTime ( T000W13_A74MARGENEBITDAFecha[0] ) == DateTimeUtil.ResetTime ( A74MARGENEBITDAFecha ) ) && ( StringUtil.StrCmp(T000W13_A5Cod_Area[0], A5Cod_Area) < 0 ) || ( StringUtil.StrCmp(T000W13_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000W13_A76MARGENEBITDAAno[0] == A76MARGENEBITDAAno ) && ( T000W13_A75MARGENEBITDAMes[0] == A75MARGENEBITDAMes ) && ( DateTimeUtil.ResetTime ( T000W13_A74MARGENEBITDAFecha[0] ) == DateTimeUtil.ResetTime ( A74MARGENEBITDAFecha ) ) && ( StringUtil.StrCmp(T000W13_A4IndicadoresCodigo[0], A4IndicadoresCodigo) < 0 ) || ( StringUtil.StrCmp(T000W13_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T000W13_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000W13_A76MARGENEBITDAAno[0] == A76MARGENEBITDAAno ) && ( T000W13_A75MARGENEBITDAMes[0] == A75MARGENEBITDAMes ) && ( DateTimeUtil.ResetTime ( T000W13_A74MARGENEBITDAFecha[0] ) == DateTimeUtil.ResetTime ( A74MARGENEBITDAFecha ) ) && ( StringUtil.StrCmp(T000W13_A63MOTIVOMARGENCod[0], A63MOTIVOMARGENCod) < 0 ) ) )
            {
               A74MARGENEBITDAFecha = T000W13_A74MARGENEBITDAFecha[0];
               AssignAttri("", false, "A74MARGENEBITDAFecha", context.localUtil.Format(A74MARGENEBITDAFecha, "99/99/99"));
               A75MARGENEBITDAMes = T000W13_A75MARGENEBITDAMes[0];
               AssignAttri("", false, "A75MARGENEBITDAMes", StringUtil.LTrimStr( (decimal)(A75MARGENEBITDAMes), 4, 0));
               A76MARGENEBITDAAno = T000W13_A76MARGENEBITDAAno[0];
               AssignAttri("", false, "A76MARGENEBITDAAno", StringUtil.LTrimStr( (decimal)(A76MARGENEBITDAAno), 4, 0));
               A5Cod_Area = T000W13_A5Cod_Area[0];
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               A4IndicadoresCodigo = T000W13_A4IndicadoresCodigo[0];
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               A63MOTIVOMARGENCod = T000W13_A63MOTIVOMARGENCod[0];
               AssignAttri("", false, "A63MOTIVOMARGENCod", A63MOTIVOMARGENCod);
               RcdFound33 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0W33( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtMARGENEBITDAFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0W33( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound33 == 1 )
            {
               if ( ( DateTimeUtil.ResetTime ( A74MARGENEBITDAFecha ) != DateTimeUtil.ResetTime ( Z74MARGENEBITDAFecha ) ) || ( A75MARGENEBITDAMes != Z75MARGENEBITDAMes ) || ( A76MARGENEBITDAAno != Z76MARGENEBITDAAno ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) || ( StringUtil.StrCmp(A63MOTIVOMARGENCod, Z63MOTIVOMARGENCod) != 0 ) )
               {
                  A74MARGENEBITDAFecha = Z74MARGENEBITDAFecha;
                  AssignAttri("", false, "A74MARGENEBITDAFecha", context.localUtil.Format(A74MARGENEBITDAFecha, "99/99/99"));
                  A75MARGENEBITDAMes = Z75MARGENEBITDAMes;
                  AssignAttri("", false, "A75MARGENEBITDAMes", StringUtil.LTrimStr( (decimal)(A75MARGENEBITDAMes), 4, 0));
                  A76MARGENEBITDAAno = Z76MARGENEBITDAAno;
                  AssignAttri("", false, "A76MARGENEBITDAAno", StringUtil.LTrimStr( (decimal)(A76MARGENEBITDAAno), 4, 0));
                  A5Cod_Area = Z5Cod_Area;
                  AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
                  A4IndicadoresCodigo = Z4IndicadoresCodigo;
                  AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
                  A63MOTIVOMARGENCod = Z63MOTIVOMARGENCod;
                  AssignAttri("", false, "A63MOTIVOMARGENCod", A63MOTIVOMARGENCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "MARGENEBITDAFECHA");
                  AnyError = 1;
                  GX_FocusControl = edtMARGENEBITDAFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtMARGENEBITDAFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0W33( ) ;
                  GX_FocusControl = edtMARGENEBITDAFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( DateTimeUtil.ResetTime ( A74MARGENEBITDAFecha ) != DateTimeUtil.ResetTime ( Z74MARGENEBITDAFecha ) ) || ( A75MARGENEBITDAMes != Z75MARGENEBITDAMes ) || ( A76MARGENEBITDAAno != Z76MARGENEBITDAAno ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) || ( StringUtil.StrCmp(A63MOTIVOMARGENCod, Z63MOTIVOMARGENCod) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtMARGENEBITDAFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0W33( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "MARGENEBITDAFECHA");
                     AnyError = 1;
                     GX_FocusControl = edtMARGENEBITDAFecha_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtMARGENEBITDAFecha_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0W33( ) ;
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
         if ( ( DateTimeUtil.ResetTime ( A74MARGENEBITDAFecha ) != DateTimeUtil.ResetTime ( Z74MARGENEBITDAFecha ) ) || ( A75MARGENEBITDAMes != Z75MARGENEBITDAMes ) || ( A76MARGENEBITDAAno != Z76MARGENEBITDAAno ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) || ( StringUtil.StrCmp(A63MOTIVOMARGENCod, Z63MOTIVOMARGENCod) != 0 ) )
         {
            A74MARGENEBITDAFecha = Z74MARGENEBITDAFecha;
            AssignAttri("", false, "A74MARGENEBITDAFecha", context.localUtil.Format(A74MARGENEBITDAFecha, "99/99/99"));
            A75MARGENEBITDAMes = Z75MARGENEBITDAMes;
            AssignAttri("", false, "A75MARGENEBITDAMes", StringUtil.LTrimStr( (decimal)(A75MARGENEBITDAMes), 4, 0));
            A76MARGENEBITDAAno = Z76MARGENEBITDAAno;
            AssignAttri("", false, "A76MARGENEBITDAAno", StringUtil.LTrimStr( (decimal)(A76MARGENEBITDAAno), 4, 0));
            A5Cod_Area = Z5Cod_Area;
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = Z4IndicadoresCodigo;
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A63MOTIVOMARGENCod = Z63MOTIVOMARGENCod;
            AssignAttri("", false, "A63MOTIVOMARGENCod", A63MOTIVOMARGENCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "MARGENEBITDAFECHA");
            AnyError = 1;
            GX_FocusControl = edtMARGENEBITDAFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtMARGENEBITDAFecha_Internalname;
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
         if ( RcdFound33 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "MARGENEBITDAFECHA");
            AnyError = 1;
            GX_FocusControl = edtMARGENEBITDAFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtMARGENEBITDAValor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0W33( ) ;
         if ( RcdFound33 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMARGENEBITDAValor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0W33( ) ;
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
         if ( RcdFound33 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMARGENEBITDAValor_Internalname;
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
         if ( RcdFound33 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMARGENEBITDAValor_Internalname;
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
         ScanStart0W33( ) ;
         if ( RcdFound33 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound33 != 0 )
            {
               ScanNext0W33( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMARGENEBITDAValor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0W33( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0W33( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000W2 */
            pr_default.execute(0, new Object[] {A74MARGENEBITDAFecha, A75MARGENEBITDAMes, A76MARGENEBITDAAno, A5Cod_Area, A4IndicadoresCodigo, A63MOTIVOMARGENCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"MARGENEBITDA"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z186MARGENEBITDAValor != T000W2_A186MARGENEBITDAValor[0] ) || ( StringUtil.StrCmp(Z187MARGENEBITDAuser, T000W2_A187MARGENEBITDAuser[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z188MARGENEBITDAfec ) != DateTimeUtil.ResetTime ( T000W2_A188MARGENEBITDAfec[0] ) ) || ( StringUtil.StrCmp(Z189MARGENEBITDAhor, T000W2_A189MARGENEBITDAhor[0]) != 0 ) )
            {
               if ( Z186MARGENEBITDAValor != T000W2_A186MARGENEBITDAValor[0] )
               {
                  GXUtil.WriteLog("margenebitda:[seudo value changed for attri]"+"MARGENEBITDAValor");
                  GXUtil.WriteLogRaw("Old: ",Z186MARGENEBITDAValor);
                  GXUtil.WriteLogRaw("Current: ",T000W2_A186MARGENEBITDAValor[0]);
               }
               if ( StringUtil.StrCmp(Z187MARGENEBITDAuser, T000W2_A187MARGENEBITDAuser[0]) != 0 )
               {
                  GXUtil.WriteLog("margenebitda:[seudo value changed for attri]"+"MARGENEBITDAuser");
                  GXUtil.WriteLogRaw("Old: ",Z187MARGENEBITDAuser);
                  GXUtil.WriteLogRaw("Current: ",T000W2_A187MARGENEBITDAuser[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z188MARGENEBITDAfec ) != DateTimeUtil.ResetTime ( T000W2_A188MARGENEBITDAfec[0] ) )
               {
                  GXUtil.WriteLog("margenebitda:[seudo value changed for attri]"+"MARGENEBITDAfec");
                  GXUtil.WriteLogRaw("Old: ",Z188MARGENEBITDAfec);
                  GXUtil.WriteLogRaw("Current: ",T000W2_A188MARGENEBITDAfec[0]);
               }
               if ( StringUtil.StrCmp(Z189MARGENEBITDAhor, T000W2_A189MARGENEBITDAhor[0]) != 0 )
               {
                  GXUtil.WriteLog("margenebitda:[seudo value changed for attri]"+"MARGENEBITDAhor");
                  GXUtil.WriteLogRaw("Old: ",Z189MARGENEBITDAhor);
                  GXUtil.WriteLogRaw("Current: ",T000W2_A189MARGENEBITDAhor[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"MARGENEBITDA"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0W33( )
      {
         BeforeValidate0W33( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0W33( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0W33( 0) ;
            CheckOptimisticConcurrency0W33( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0W33( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0W33( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000W14 */
                     pr_default.execute(12, new Object[] {A74MARGENEBITDAFecha, A75MARGENEBITDAMes, A76MARGENEBITDAAno, A186MARGENEBITDAValor, A187MARGENEBITDAuser, A188MARGENEBITDAfec, A189MARGENEBITDAhor, A5Cod_Area, A4IndicadoresCodigo, A63MOTIVOMARGENCod});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("MARGENEBITDA");
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
                           ResetCaption0W0( ) ;
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
               Load0W33( ) ;
            }
            EndLevel0W33( ) ;
         }
         CloseExtendedTableCursors0W33( ) ;
      }

      protected void Update0W33( )
      {
         BeforeValidate0W33( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0W33( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0W33( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0W33( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0W33( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000W15 */
                     pr_default.execute(13, new Object[] {A186MARGENEBITDAValor, A187MARGENEBITDAuser, A188MARGENEBITDAfec, A189MARGENEBITDAhor, A74MARGENEBITDAFecha, A75MARGENEBITDAMes, A76MARGENEBITDAAno, A5Cod_Area, A4IndicadoresCodigo, A63MOTIVOMARGENCod});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("MARGENEBITDA");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"MARGENEBITDA"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0W33( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0W0( ) ;
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
            EndLevel0W33( ) ;
         }
         CloseExtendedTableCursors0W33( ) ;
      }

      protected void DeferredUpdate0W33( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0W33( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0W33( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0W33( ) ;
            AfterConfirm0W33( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0W33( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000W16 */
                  pr_default.execute(14, new Object[] {A74MARGENEBITDAFecha, A75MARGENEBITDAMes, A76MARGENEBITDAAno, A5Cod_Area, A4IndicadoresCodigo, A63MOTIVOMARGENCod});
                  pr_default.close(14);
                  pr_default.SmartCacheProvider.SetUpdated("MARGENEBITDA");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound33 == 0 )
                        {
                           InitAll0W33( ) ;
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
                        ResetCaption0W0( ) ;
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
         sMode33 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0W33( ) ;
         Gx_mode = sMode33;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0W33( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0W33( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0W33( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("margenebitda",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0W0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("margenebitda",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0W33( )
      {
         /* Using cursor T000W17 */
         pr_default.execute(15);
         RcdFound33 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound33 = 1;
            A74MARGENEBITDAFecha = T000W17_A74MARGENEBITDAFecha[0];
            AssignAttri("", false, "A74MARGENEBITDAFecha", context.localUtil.Format(A74MARGENEBITDAFecha, "99/99/99"));
            A75MARGENEBITDAMes = T000W17_A75MARGENEBITDAMes[0];
            AssignAttri("", false, "A75MARGENEBITDAMes", StringUtil.LTrimStr( (decimal)(A75MARGENEBITDAMes), 4, 0));
            A76MARGENEBITDAAno = T000W17_A76MARGENEBITDAAno[0];
            AssignAttri("", false, "A76MARGENEBITDAAno", StringUtil.LTrimStr( (decimal)(A76MARGENEBITDAAno), 4, 0));
            A5Cod_Area = T000W17_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = T000W17_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A63MOTIVOMARGENCod = T000W17_A63MOTIVOMARGENCod[0];
            AssignAttri("", false, "A63MOTIVOMARGENCod", A63MOTIVOMARGENCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0W33( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound33 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound33 = 1;
            A74MARGENEBITDAFecha = T000W17_A74MARGENEBITDAFecha[0];
            AssignAttri("", false, "A74MARGENEBITDAFecha", context.localUtil.Format(A74MARGENEBITDAFecha, "99/99/99"));
            A75MARGENEBITDAMes = T000W17_A75MARGENEBITDAMes[0];
            AssignAttri("", false, "A75MARGENEBITDAMes", StringUtil.LTrimStr( (decimal)(A75MARGENEBITDAMes), 4, 0));
            A76MARGENEBITDAAno = T000W17_A76MARGENEBITDAAno[0];
            AssignAttri("", false, "A76MARGENEBITDAAno", StringUtil.LTrimStr( (decimal)(A76MARGENEBITDAAno), 4, 0));
            A5Cod_Area = T000W17_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = T000W17_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A63MOTIVOMARGENCod = T000W17_A63MOTIVOMARGENCod[0];
            AssignAttri("", false, "A63MOTIVOMARGENCod", A63MOTIVOMARGENCod);
         }
      }

      protected void ScanEnd0W33( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm0W33( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0W33( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0W33( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0W33( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0W33( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0W33( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0W33( )
      {
         edtMARGENEBITDAFecha_Enabled = 0;
         AssignProp("", false, edtMARGENEBITDAFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMARGENEBITDAFecha_Enabled), 5, 0), true);
         edtMARGENEBITDAMes_Enabled = 0;
         AssignProp("", false, edtMARGENEBITDAMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMARGENEBITDAMes_Enabled), 5, 0), true);
         edtMARGENEBITDAAno_Enabled = 0;
         AssignProp("", false, edtMARGENEBITDAAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMARGENEBITDAAno_Enabled), 5, 0), true);
         edtCod_Area_Enabled = 0;
         AssignProp("", false, edtCod_Area_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCod_Area_Enabled), 5, 0), true);
         edtIndicadoresCodigo_Enabled = 0;
         AssignProp("", false, edtIndicadoresCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIndicadoresCodigo_Enabled), 5, 0), true);
         edtMOTIVOMARGENCod_Enabled = 0;
         AssignProp("", false, edtMOTIVOMARGENCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMOTIVOMARGENCod_Enabled), 5, 0), true);
         edtMARGENEBITDAValor_Enabled = 0;
         AssignProp("", false, edtMARGENEBITDAValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMARGENEBITDAValor_Enabled), 5, 0), true);
         edtMARGENEBITDAuser_Enabled = 0;
         AssignProp("", false, edtMARGENEBITDAuser_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMARGENEBITDAuser_Enabled), 5, 0), true);
         edtMARGENEBITDAfec_Enabled = 0;
         AssignProp("", false, edtMARGENEBITDAfec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMARGENEBITDAfec_Enabled), 5, 0), true);
         edtMARGENEBITDAhor_Enabled = 0;
         AssignProp("", false, edtMARGENEBITDAhor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMARGENEBITDAhor_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0W33( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0W0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("margenebitda.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z74MARGENEBITDAFecha", context.localUtil.DToC( Z74MARGENEBITDAFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z75MARGENEBITDAMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z75MARGENEBITDAMes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z76MARGENEBITDAAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z76MARGENEBITDAAno), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z5Cod_Area", Z5Cod_Area);
         GxWebStd.gx_hidden_field( context, "Z4IndicadoresCodigo", Z4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "Z63MOTIVOMARGENCod", Z63MOTIVOMARGENCod);
         GxWebStd.gx_hidden_field( context, "Z186MARGENEBITDAValor", StringUtil.LTrim( StringUtil.NToC( Z186MARGENEBITDAValor, 12, 3, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z187MARGENEBITDAuser", Z187MARGENEBITDAuser);
         GxWebStd.gx_hidden_field( context, "Z188MARGENEBITDAfec", context.localUtil.DToC( Z188MARGENEBITDAfec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z189MARGENEBITDAhor", Z189MARGENEBITDAhor);
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
         return formatLink("margenebitda.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "MARGENEBITDA" ;
      }

      public override string GetPgmdesc( )
      {
         return "MARGENEBITDA" ;
      }

      protected void InitializeNonKey0W33( )
      {
         A186MARGENEBITDAValor = 0;
         AssignAttri("", false, "A186MARGENEBITDAValor", StringUtil.LTrimStr( A186MARGENEBITDAValor, 12, 3));
         A187MARGENEBITDAuser = "";
         AssignAttri("", false, "A187MARGENEBITDAuser", A187MARGENEBITDAuser);
         A188MARGENEBITDAfec = DateTime.MinValue;
         AssignAttri("", false, "A188MARGENEBITDAfec", context.localUtil.Format(A188MARGENEBITDAfec, "99/99/99"));
         A189MARGENEBITDAhor = "";
         AssignAttri("", false, "A189MARGENEBITDAhor", A189MARGENEBITDAhor);
         Z186MARGENEBITDAValor = 0;
         Z187MARGENEBITDAuser = "";
         Z188MARGENEBITDAfec = DateTime.MinValue;
         Z189MARGENEBITDAhor = "";
      }

      protected void InitAll0W33( )
      {
         A74MARGENEBITDAFecha = DateTime.MinValue;
         AssignAttri("", false, "A74MARGENEBITDAFecha", context.localUtil.Format(A74MARGENEBITDAFecha, "99/99/99"));
         A75MARGENEBITDAMes = 0;
         AssignAttri("", false, "A75MARGENEBITDAMes", StringUtil.LTrimStr( (decimal)(A75MARGENEBITDAMes), 4, 0));
         A76MARGENEBITDAAno = 0;
         AssignAttri("", false, "A76MARGENEBITDAAno", StringUtil.LTrimStr( (decimal)(A76MARGENEBITDAAno), 4, 0));
         A5Cod_Area = "";
         AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
         A4IndicadoresCodigo = "";
         AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
         A63MOTIVOMARGENCod = "";
         AssignAttri("", false, "A63MOTIVOMARGENCod", A63MOTIVOMARGENCod);
         InitializeNonKey0W33( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20247231024645", true, true);
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
         context.AddJavascriptSource("margenebitda.js", "?20247231024645", false, true);
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
         edtMARGENEBITDAFecha_Internalname = "MARGENEBITDAFECHA";
         edtMARGENEBITDAMes_Internalname = "MARGENEBITDAMES";
         edtMARGENEBITDAAno_Internalname = "MARGENEBITDAANO";
         edtCod_Area_Internalname = "COD_AREA";
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO";
         edtMOTIVOMARGENCod_Internalname = "MOTIVOMARGENCOD";
         edtMARGENEBITDAValor_Internalname = "MARGENEBITDAVALOR";
         edtMARGENEBITDAuser_Internalname = "MARGENEBITDAUSER";
         edtMARGENEBITDAfec_Internalname = "MARGENEBITDAFEC";
         edtMARGENEBITDAhor_Internalname = "MARGENEBITDAHOR";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_5_Internalname = "PROMPT_5";
         imgprompt_4_Internalname = "PROMPT_4";
         imgprompt_63_Internalname = "PROMPT_63";
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
         Form.Caption = "MARGENEBITDA";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtMARGENEBITDAhor_Jsonclick = "";
         edtMARGENEBITDAhor_Enabled = 1;
         edtMARGENEBITDAfec_Jsonclick = "";
         edtMARGENEBITDAfec_Enabled = 1;
         edtMARGENEBITDAuser_Jsonclick = "";
         edtMARGENEBITDAuser_Enabled = 1;
         edtMARGENEBITDAValor_Jsonclick = "";
         edtMARGENEBITDAValor_Enabled = 1;
         imgprompt_63_Visible = 1;
         imgprompt_63_Link = "";
         edtMOTIVOMARGENCod_Jsonclick = "";
         edtMOTIVOMARGENCod_Enabled = 1;
         imgprompt_4_Visible = 1;
         imgprompt_4_Link = "";
         edtIndicadoresCodigo_Jsonclick = "";
         edtIndicadoresCodigo_Enabled = 1;
         imgprompt_5_Visible = 1;
         imgprompt_5_Link = "";
         edtCod_Area_Jsonclick = "";
         edtCod_Area_Enabled = 1;
         edtMARGENEBITDAAno_Jsonclick = "";
         edtMARGENEBITDAAno_Enabled = 1;
         edtMARGENEBITDAMes_Jsonclick = "";
         edtMARGENEBITDAMes_Enabled = 1;
         edtMARGENEBITDAFecha_Jsonclick = "";
         edtMARGENEBITDAFecha_Enabled = 1;
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
         /* Using cursor T000W18 */
         pr_default.execute(16, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(16);
         /* Using cursor T000W19 */
         pr_default.execute(17, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(17);
         /* Using cursor T000W20 */
         pr_default.execute(18, new Object[] {A63MOTIVOMARGENCod});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'MOTIVOMARGEN'.", "ForeignKeyNotFound", 1, "MOTIVOMARGENCOD");
            AnyError = 1;
            GX_FocusControl = edtMOTIVOMARGENCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(18);
         GX_FocusControl = edtMARGENEBITDAValor_Internalname;
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
         /* Using cursor T000W18 */
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
         /* Using cursor T000W19 */
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

      public void Valid_Motivomargencod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T000W20 */
         pr_default.execute(18, new Object[] {A63MOTIVOMARGENCod});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'MOTIVOMARGEN'.", "ForeignKeyNotFound", 1, "MOTIVOMARGENCOD");
            AnyError = 1;
            GX_FocusControl = edtMOTIVOMARGENCod_Internalname;
         }
         pr_default.close(18);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A186MARGENEBITDAValor", StringUtil.LTrim( StringUtil.NToC( A186MARGENEBITDAValor, 12, 3, ".", "")));
         AssignAttri("", false, "A187MARGENEBITDAuser", A187MARGENEBITDAuser);
         AssignAttri("", false, "A188MARGENEBITDAfec", context.localUtil.Format(A188MARGENEBITDAfec, "99/99/99"));
         AssignAttri("", false, "A189MARGENEBITDAhor", A189MARGENEBITDAhor);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z74MARGENEBITDAFecha", context.localUtil.Format(Z74MARGENEBITDAFecha, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z75MARGENEBITDAMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z75MARGENEBITDAMes), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z76MARGENEBITDAAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z76MARGENEBITDAAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z5Cod_Area", Z5Cod_Area);
         GxWebStd.gx_hidden_field( context, "Z4IndicadoresCodigo", Z4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "Z63MOTIVOMARGENCod", Z63MOTIVOMARGENCod);
         GxWebStd.gx_hidden_field( context, "Z186MARGENEBITDAValor", StringUtil.LTrim( StringUtil.NToC( Z186MARGENEBITDAValor, 12, 3, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z187MARGENEBITDAuser", Z187MARGENEBITDAuser);
         GxWebStd.gx_hidden_field( context, "Z188MARGENEBITDAfec", context.localUtil.Format(Z188MARGENEBITDAfec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z189MARGENEBITDAhor", Z189MARGENEBITDAhor);
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
         setEventMetadata("VALID_MARGENEBITDAFECHA","{handler:'Valid_Margenebitdafecha',iparms:[]");
         setEventMetadata("VALID_MARGENEBITDAFECHA",",oparms:[]}");
         setEventMetadata("VALID_MARGENEBITDAMES","{handler:'Valid_Margenebitdames',iparms:[]");
         setEventMetadata("VALID_MARGENEBITDAMES",",oparms:[]}");
         setEventMetadata("VALID_MARGENEBITDAANO","{handler:'Valid_Margenebitdaano',iparms:[]");
         setEventMetadata("VALID_MARGENEBITDAANO",",oparms:[]}");
         setEventMetadata("VALID_COD_AREA","{handler:'Valid_Cod_area',iparms:[{av:'A5Cod_Area',fld:'COD_AREA',pic:''}]");
         setEventMetadata("VALID_COD_AREA",",oparms:[]}");
         setEventMetadata("VALID_INDICADORESCODIGO","{handler:'Valid_Indicadorescodigo',iparms:[{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:''}]");
         setEventMetadata("VALID_INDICADORESCODIGO",",oparms:[]}");
         setEventMetadata("VALID_MOTIVOMARGENCOD","{handler:'Valid_Motivomargencod',iparms:[{av:'A74MARGENEBITDAFecha',fld:'MARGENEBITDAFECHA',pic:''},{av:'A75MARGENEBITDAMes',fld:'MARGENEBITDAMES',pic:'ZZZ9'},{av:'A76MARGENEBITDAAno',fld:'MARGENEBITDAANO',pic:'ZZZ9'},{av:'A5Cod_Area',fld:'COD_AREA',pic:''},{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:''},{av:'A63MOTIVOMARGENCod',fld:'MOTIVOMARGENCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_MOTIVOMARGENCOD",",oparms:[{av:'A186MARGENEBITDAValor',fld:'MARGENEBITDAVALOR',pic:'ZZZZZZZ9.999'},{av:'A187MARGENEBITDAuser',fld:'MARGENEBITDAUSER',pic:''},{av:'A188MARGENEBITDAfec',fld:'MARGENEBITDAFEC',pic:''},{av:'A189MARGENEBITDAhor',fld:'MARGENEBITDAHOR',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z74MARGENEBITDAFecha'},{av:'Z75MARGENEBITDAMes'},{av:'Z76MARGENEBITDAAno'},{av:'Z5Cod_Area'},{av:'Z4IndicadoresCodigo'},{av:'Z63MOTIVOMARGENCod'},{av:'Z186MARGENEBITDAValor'},{av:'Z187MARGENEBITDAuser'},{av:'Z188MARGENEBITDAfec'},{av:'Z189MARGENEBITDAhor'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_MARGENEBITDAFEC","{handler:'Valid_Margenebitdafec',iparms:[]");
         setEventMetadata("VALID_MARGENEBITDAFEC",",oparms:[]}");
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
         Z74MARGENEBITDAFecha = DateTime.MinValue;
         Z5Cod_Area = "";
         Z4IndicadoresCodigo = "";
         Z63MOTIVOMARGENCod = "";
         Z187MARGENEBITDAuser = "";
         Z188MARGENEBITDAfec = DateTime.MinValue;
         Z189MARGENEBITDAhor = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A5Cod_Area = "";
         A4IndicadoresCodigo = "";
         A63MOTIVOMARGENCod = "";
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
         A74MARGENEBITDAFecha = DateTime.MinValue;
         imgprompt_5_gximage = "";
         sImgUrl = "";
         imgprompt_4_gximage = "";
         imgprompt_63_gximage = "";
         A187MARGENEBITDAuser = "";
         A188MARGENEBITDAfec = DateTime.MinValue;
         A189MARGENEBITDAhor = "";
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
         T000W7_A74MARGENEBITDAFecha = new DateTime[] {DateTime.MinValue} ;
         T000W7_A75MARGENEBITDAMes = new short[1] ;
         T000W7_A76MARGENEBITDAAno = new short[1] ;
         T000W7_A186MARGENEBITDAValor = new decimal[1] ;
         T000W7_A187MARGENEBITDAuser = new string[] {""} ;
         T000W7_A188MARGENEBITDAfec = new DateTime[] {DateTime.MinValue} ;
         T000W7_A189MARGENEBITDAhor = new string[] {""} ;
         T000W7_A5Cod_Area = new string[] {""} ;
         T000W7_A4IndicadoresCodigo = new string[] {""} ;
         T000W7_A63MOTIVOMARGENCod = new string[] {""} ;
         T000W4_A5Cod_Area = new string[] {""} ;
         T000W5_A4IndicadoresCodigo = new string[] {""} ;
         T000W6_A63MOTIVOMARGENCod = new string[] {""} ;
         T000W8_A5Cod_Area = new string[] {""} ;
         T000W9_A4IndicadoresCodigo = new string[] {""} ;
         T000W10_A63MOTIVOMARGENCod = new string[] {""} ;
         T000W11_A74MARGENEBITDAFecha = new DateTime[] {DateTime.MinValue} ;
         T000W11_A75MARGENEBITDAMes = new short[1] ;
         T000W11_A76MARGENEBITDAAno = new short[1] ;
         T000W11_A5Cod_Area = new string[] {""} ;
         T000W11_A4IndicadoresCodigo = new string[] {""} ;
         T000W11_A63MOTIVOMARGENCod = new string[] {""} ;
         T000W3_A74MARGENEBITDAFecha = new DateTime[] {DateTime.MinValue} ;
         T000W3_A75MARGENEBITDAMes = new short[1] ;
         T000W3_A76MARGENEBITDAAno = new short[1] ;
         T000W3_A186MARGENEBITDAValor = new decimal[1] ;
         T000W3_A187MARGENEBITDAuser = new string[] {""} ;
         T000W3_A188MARGENEBITDAfec = new DateTime[] {DateTime.MinValue} ;
         T000W3_A189MARGENEBITDAhor = new string[] {""} ;
         T000W3_A5Cod_Area = new string[] {""} ;
         T000W3_A4IndicadoresCodigo = new string[] {""} ;
         T000W3_A63MOTIVOMARGENCod = new string[] {""} ;
         sMode33 = "";
         T000W12_A74MARGENEBITDAFecha = new DateTime[] {DateTime.MinValue} ;
         T000W12_A75MARGENEBITDAMes = new short[1] ;
         T000W12_A76MARGENEBITDAAno = new short[1] ;
         T000W12_A5Cod_Area = new string[] {""} ;
         T000W12_A4IndicadoresCodigo = new string[] {""} ;
         T000W12_A63MOTIVOMARGENCod = new string[] {""} ;
         T000W13_A74MARGENEBITDAFecha = new DateTime[] {DateTime.MinValue} ;
         T000W13_A75MARGENEBITDAMes = new short[1] ;
         T000W13_A76MARGENEBITDAAno = new short[1] ;
         T000W13_A5Cod_Area = new string[] {""} ;
         T000W13_A4IndicadoresCodigo = new string[] {""} ;
         T000W13_A63MOTIVOMARGENCod = new string[] {""} ;
         T000W2_A74MARGENEBITDAFecha = new DateTime[] {DateTime.MinValue} ;
         T000W2_A75MARGENEBITDAMes = new short[1] ;
         T000W2_A76MARGENEBITDAAno = new short[1] ;
         T000W2_A186MARGENEBITDAValor = new decimal[1] ;
         T000W2_A187MARGENEBITDAuser = new string[] {""} ;
         T000W2_A188MARGENEBITDAfec = new DateTime[] {DateTime.MinValue} ;
         T000W2_A189MARGENEBITDAhor = new string[] {""} ;
         T000W2_A5Cod_Area = new string[] {""} ;
         T000W2_A4IndicadoresCodigo = new string[] {""} ;
         T000W2_A63MOTIVOMARGENCod = new string[] {""} ;
         T000W17_A74MARGENEBITDAFecha = new DateTime[] {DateTime.MinValue} ;
         T000W17_A75MARGENEBITDAMes = new short[1] ;
         T000W17_A76MARGENEBITDAAno = new short[1] ;
         T000W17_A5Cod_Area = new string[] {""} ;
         T000W17_A4IndicadoresCodigo = new string[] {""} ;
         T000W17_A63MOTIVOMARGENCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T000W18_A5Cod_Area = new string[] {""} ;
         T000W19_A4IndicadoresCodigo = new string[] {""} ;
         T000W20_A63MOTIVOMARGENCod = new string[] {""} ;
         ZZ74MARGENEBITDAFecha = DateTime.MinValue;
         ZZ5Cod_Area = "";
         ZZ4IndicadoresCodigo = "";
         ZZ63MOTIVOMARGENCod = "";
         ZZ187MARGENEBITDAuser = "";
         ZZ188MARGENEBITDAfec = DateTime.MinValue;
         ZZ189MARGENEBITDAhor = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.margenebitda__default(),
            new Object[][] {
                new Object[] {
               T000W2_A74MARGENEBITDAFecha, T000W2_A75MARGENEBITDAMes, T000W2_A76MARGENEBITDAAno, T000W2_A186MARGENEBITDAValor, T000W2_A187MARGENEBITDAuser, T000W2_A188MARGENEBITDAfec, T000W2_A189MARGENEBITDAhor, T000W2_A5Cod_Area, T000W2_A4IndicadoresCodigo, T000W2_A63MOTIVOMARGENCod
               }
               , new Object[] {
               T000W3_A74MARGENEBITDAFecha, T000W3_A75MARGENEBITDAMes, T000W3_A76MARGENEBITDAAno, T000W3_A186MARGENEBITDAValor, T000W3_A187MARGENEBITDAuser, T000W3_A188MARGENEBITDAfec, T000W3_A189MARGENEBITDAhor, T000W3_A5Cod_Area, T000W3_A4IndicadoresCodigo, T000W3_A63MOTIVOMARGENCod
               }
               , new Object[] {
               T000W4_A5Cod_Area
               }
               , new Object[] {
               T000W5_A4IndicadoresCodigo
               }
               , new Object[] {
               T000W6_A63MOTIVOMARGENCod
               }
               , new Object[] {
               T000W7_A74MARGENEBITDAFecha, T000W7_A75MARGENEBITDAMes, T000W7_A76MARGENEBITDAAno, T000W7_A186MARGENEBITDAValor, T000W7_A187MARGENEBITDAuser, T000W7_A188MARGENEBITDAfec, T000W7_A189MARGENEBITDAhor, T000W7_A5Cod_Area, T000W7_A4IndicadoresCodigo, T000W7_A63MOTIVOMARGENCod
               }
               , new Object[] {
               T000W8_A5Cod_Area
               }
               , new Object[] {
               T000W9_A4IndicadoresCodigo
               }
               , new Object[] {
               T000W10_A63MOTIVOMARGENCod
               }
               , new Object[] {
               T000W11_A74MARGENEBITDAFecha, T000W11_A75MARGENEBITDAMes, T000W11_A76MARGENEBITDAAno, T000W11_A5Cod_Area, T000W11_A4IndicadoresCodigo, T000W11_A63MOTIVOMARGENCod
               }
               , new Object[] {
               T000W12_A74MARGENEBITDAFecha, T000W12_A75MARGENEBITDAMes, T000W12_A76MARGENEBITDAAno, T000W12_A5Cod_Area, T000W12_A4IndicadoresCodigo, T000W12_A63MOTIVOMARGENCod
               }
               , new Object[] {
               T000W13_A74MARGENEBITDAFecha, T000W13_A75MARGENEBITDAMes, T000W13_A76MARGENEBITDAAno, T000W13_A5Cod_Area, T000W13_A4IndicadoresCodigo, T000W13_A63MOTIVOMARGENCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000W17_A74MARGENEBITDAFecha, T000W17_A75MARGENEBITDAMes, T000W17_A76MARGENEBITDAAno, T000W17_A5Cod_Area, T000W17_A4IndicadoresCodigo, T000W17_A63MOTIVOMARGENCod
               }
               , new Object[] {
               T000W18_A5Cod_Area
               }
               , new Object[] {
               T000W19_A4IndicadoresCodigo
               }
               , new Object[] {
               T000W20_A63MOTIVOMARGENCod
               }
            }
         );
      }

      private short Z75MARGENEBITDAMes ;
      private short Z76MARGENEBITDAAno ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A75MARGENEBITDAMes ;
      private short A76MARGENEBITDAAno ;
      private short GX_JID ;
      private short RcdFound33 ;
      private short nIsDirty_33 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ75MARGENEBITDAMes ;
      private short ZZ76MARGENEBITDAAno ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtMARGENEBITDAFecha_Enabled ;
      private int edtMARGENEBITDAMes_Enabled ;
      private int edtMARGENEBITDAAno_Enabled ;
      private int edtCod_Area_Enabled ;
      private int imgprompt_5_Visible ;
      private int edtIndicadoresCodigo_Enabled ;
      private int imgprompt_4_Visible ;
      private int edtMOTIVOMARGENCod_Enabled ;
      private int imgprompt_63_Visible ;
      private int edtMARGENEBITDAValor_Enabled ;
      private int edtMARGENEBITDAuser_Enabled ;
      private int edtMARGENEBITDAfec_Enabled ;
      private int edtMARGENEBITDAhor_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private decimal Z186MARGENEBITDAValor ;
      private decimal A186MARGENEBITDAValor ;
      private decimal ZZ186MARGENEBITDAValor ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtMARGENEBITDAFecha_Internalname ;
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
      private string edtMARGENEBITDAFecha_Jsonclick ;
      private string edtMARGENEBITDAMes_Internalname ;
      private string edtMARGENEBITDAMes_Jsonclick ;
      private string edtMARGENEBITDAAno_Internalname ;
      private string edtMARGENEBITDAAno_Jsonclick ;
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
      private string edtMOTIVOMARGENCod_Internalname ;
      private string edtMOTIVOMARGENCod_Jsonclick ;
      private string imgprompt_63_gximage ;
      private string imgprompt_63_Internalname ;
      private string imgprompt_63_Link ;
      private string edtMARGENEBITDAValor_Internalname ;
      private string edtMARGENEBITDAValor_Jsonclick ;
      private string edtMARGENEBITDAuser_Internalname ;
      private string edtMARGENEBITDAuser_Jsonclick ;
      private string edtMARGENEBITDAfec_Internalname ;
      private string edtMARGENEBITDAfec_Jsonclick ;
      private string edtMARGENEBITDAhor_Internalname ;
      private string edtMARGENEBITDAhor_Jsonclick ;
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
      private string sMode33 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z74MARGENEBITDAFecha ;
      private DateTime Z188MARGENEBITDAfec ;
      private DateTime A74MARGENEBITDAFecha ;
      private DateTime A188MARGENEBITDAfec ;
      private DateTime ZZ74MARGENEBITDAFecha ;
      private DateTime ZZ188MARGENEBITDAfec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string Z5Cod_Area ;
      private string Z4IndicadoresCodigo ;
      private string Z63MOTIVOMARGENCod ;
      private string Z187MARGENEBITDAuser ;
      private string Z189MARGENEBITDAhor ;
      private string A5Cod_Area ;
      private string A4IndicadoresCodigo ;
      private string A63MOTIVOMARGENCod ;
      private string A187MARGENEBITDAuser ;
      private string A189MARGENEBITDAhor ;
      private string ZZ5Cod_Area ;
      private string ZZ4IndicadoresCodigo ;
      private string ZZ63MOTIVOMARGENCod ;
      private string ZZ187MARGENEBITDAuser ;
      private string ZZ189MARGENEBITDAhor ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] T000W7_A74MARGENEBITDAFecha ;
      private short[] T000W7_A75MARGENEBITDAMes ;
      private short[] T000W7_A76MARGENEBITDAAno ;
      private decimal[] T000W7_A186MARGENEBITDAValor ;
      private string[] T000W7_A187MARGENEBITDAuser ;
      private DateTime[] T000W7_A188MARGENEBITDAfec ;
      private string[] T000W7_A189MARGENEBITDAhor ;
      private string[] T000W7_A5Cod_Area ;
      private string[] T000W7_A4IndicadoresCodigo ;
      private string[] T000W7_A63MOTIVOMARGENCod ;
      private string[] T000W4_A5Cod_Area ;
      private string[] T000W5_A4IndicadoresCodigo ;
      private string[] T000W6_A63MOTIVOMARGENCod ;
      private string[] T000W8_A5Cod_Area ;
      private string[] T000W9_A4IndicadoresCodigo ;
      private string[] T000W10_A63MOTIVOMARGENCod ;
      private DateTime[] T000W11_A74MARGENEBITDAFecha ;
      private short[] T000W11_A75MARGENEBITDAMes ;
      private short[] T000W11_A76MARGENEBITDAAno ;
      private string[] T000W11_A5Cod_Area ;
      private string[] T000W11_A4IndicadoresCodigo ;
      private string[] T000W11_A63MOTIVOMARGENCod ;
      private DateTime[] T000W3_A74MARGENEBITDAFecha ;
      private short[] T000W3_A75MARGENEBITDAMes ;
      private short[] T000W3_A76MARGENEBITDAAno ;
      private decimal[] T000W3_A186MARGENEBITDAValor ;
      private string[] T000W3_A187MARGENEBITDAuser ;
      private DateTime[] T000W3_A188MARGENEBITDAfec ;
      private string[] T000W3_A189MARGENEBITDAhor ;
      private string[] T000W3_A5Cod_Area ;
      private string[] T000W3_A4IndicadoresCodigo ;
      private string[] T000W3_A63MOTIVOMARGENCod ;
      private DateTime[] T000W12_A74MARGENEBITDAFecha ;
      private short[] T000W12_A75MARGENEBITDAMes ;
      private short[] T000W12_A76MARGENEBITDAAno ;
      private string[] T000W12_A5Cod_Area ;
      private string[] T000W12_A4IndicadoresCodigo ;
      private string[] T000W12_A63MOTIVOMARGENCod ;
      private DateTime[] T000W13_A74MARGENEBITDAFecha ;
      private short[] T000W13_A75MARGENEBITDAMes ;
      private short[] T000W13_A76MARGENEBITDAAno ;
      private string[] T000W13_A5Cod_Area ;
      private string[] T000W13_A4IndicadoresCodigo ;
      private string[] T000W13_A63MOTIVOMARGENCod ;
      private DateTime[] T000W2_A74MARGENEBITDAFecha ;
      private short[] T000W2_A75MARGENEBITDAMes ;
      private short[] T000W2_A76MARGENEBITDAAno ;
      private decimal[] T000W2_A186MARGENEBITDAValor ;
      private string[] T000W2_A187MARGENEBITDAuser ;
      private DateTime[] T000W2_A188MARGENEBITDAfec ;
      private string[] T000W2_A189MARGENEBITDAhor ;
      private string[] T000W2_A5Cod_Area ;
      private string[] T000W2_A4IndicadoresCodigo ;
      private string[] T000W2_A63MOTIVOMARGENCod ;
      private DateTime[] T000W17_A74MARGENEBITDAFecha ;
      private short[] T000W17_A75MARGENEBITDAMes ;
      private short[] T000W17_A76MARGENEBITDAAno ;
      private string[] T000W17_A5Cod_Area ;
      private string[] T000W17_A4IndicadoresCodigo ;
      private string[] T000W17_A63MOTIVOMARGENCod ;
      private string[] T000W18_A5Cod_Area ;
      private string[] T000W19_A4IndicadoresCodigo ;
      private string[] T000W20_A63MOTIVOMARGENCod ;
      private GXWebForm Form ;
   }

   public class margenebitda__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT000W7;
          prmT000W7 = new Object[] {
          new ParDef("@MARGENEBITDAFecha",GXType.Date,8,0) ,
          new ParDef("@MARGENEBITDAMes",GXType.Int16,4,0) ,
          new ParDef("@MARGENEBITDAAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MOTIVOMARGENCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000W4;
          prmT000W4 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000W5;
          prmT000W5 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000W6;
          prmT000W6 = new Object[] {
          new ParDef("@MOTIVOMARGENCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000W8;
          prmT000W8 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000W9;
          prmT000W9 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000W10;
          prmT000W10 = new Object[] {
          new ParDef("@MOTIVOMARGENCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000W11;
          prmT000W11 = new Object[] {
          new ParDef("@MARGENEBITDAFecha",GXType.Date,8,0) ,
          new ParDef("@MARGENEBITDAMes",GXType.Int16,4,0) ,
          new ParDef("@MARGENEBITDAAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MOTIVOMARGENCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000W3;
          prmT000W3 = new Object[] {
          new ParDef("@MARGENEBITDAFecha",GXType.Date,8,0) ,
          new ParDef("@MARGENEBITDAMes",GXType.Int16,4,0) ,
          new ParDef("@MARGENEBITDAAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MOTIVOMARGENCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000W12;
          prmT000W12 = new Object[] {
          new ParDef("@MARGENEBITDAFecha",GXType.Date,8,0) ,
          new ParDef("@MARGENEBITDAMes",GXType.Int16,4,0) ,
          new ParDef("@MARGENEBITDAAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MOTIVOMARGENCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000W13;
          prmT000W13 = new Object[] {
          new ParDef("@MARGENEBITDAFecha",GXType.Date,8,0) ,
          new ParDef("@MARGENEBITDAMes",GXType.Int16,4,0) ,
          new ParDef("@MARGENEBITDAAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MOTIVOMARGENCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000W2;
          prmT000W2 = new Object[] {
          new ParDef("@MARGENEBITDAFecha",GXType.Date,8,0) ,
          new ParDef("@MARGENEBITDAMes",GXType.Int16,4,0) ,
          new ParDef("@MARGENEBITDAAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MOTIVOMARGENCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000W14;
          prmT000W14 = new Object[] {
          new ParDef("@MARGENEBITDAFecha",GXType.Date,8,0) ,
          new ParDef("@MARGENEBITDAMes",GXType.Int16,4,0) ,
          new ParDef("@MARGENEBITDAAno",GXType.Int16,4,0) ,
          new ParDef("@MARGENEBITDAValor",GXType.Decimal,12,3) ,
          new ParDef("@MARGENEBITDAuser",GXType.NVarChar,150,0) ,
          new ParDef("@MARGENEBITDAfec",GXType.Date,8,0) ,
          new ParDef("@MARGENEBITDAhor",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MOTIVOMARGENCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000W15;
          prmT000W15 = new Object[] {
          new ParDef("@MARGENEBITDAValor",GXType.Decimal,12,3) ,
          new ParDef("@MARGENEBITDAuser",GXType.NVarChar,150,0) ,
          new ParDef("@MARGENEBITDAfec",GXType.Date,8,0) ,
          new ParDef("@MARGENEBITDAhor",GXType.NVarChar,40,0) ,
          new ParDef("@MARGENEBITDAFecha",GXType.Date,8,0) ,
          new ParDef("@MARGENEBITDAMes",GXType.Int16,4,0) ,
          new ParDef("@MARGENEBITDAAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MOTIVOMARGENCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000W16;
          prmT000W16 = new Object[] {
          new ParDef("@MARGENEBITDAFecha",GXType.Date,8,0) ,
          new ParDef("@MARGENEBITDAMes",GXType.Int16,4,0) ,
          new ParDef("@MARGENEBITDAAno",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@MOTIVOMARGENCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000W17;
          prmT000W17 = new Object[] {
          };
          Object[] prmT000W18;
          prmT000W18 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000W19;
          prmT000W19 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000W20;
          prmT000W20 = new Object[] {
          new ParDef("@MOTIVOMARGENCod",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("T000W2", "SELECT [MARGENEBITDAFecha], [MARGENEBITDAMes], [MARGENEBITDAAno], [MARGENEBITDAValor], [MARGENEBITDAuser], [MARGENEBITDAfec], [MARGENEBITDAhor], [Cod_Area], [IndicadoresCodigo], [MOTIVOMARGENCod] FROM [MARGENEBITDA] WITH (UPDLOCK) WHERE [MARGENEBITDAFecha] = @MARGENEBITDAFecha AND [MARGENEBITDAMes] = @MARGENEBITDAMes AND [MARGENEBITDAAno] = @MARGENEBITDAAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo AND [MOTIVOMARGENCod] = @MOTIVOMARGENCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000W3", "SELECT [MARGENEBITDAFecha], [MARGENEBITDAMes], [MARGENEBITDAAno], [MARGENEBITDAValor], [MARGENEBITDAuser], [MARGENEBITDAfec], [MARGENEBITDAhor], [Cod_Area], [IndicadoresCodigo], [MOTIVOMARGENCod] FROM [MARGENEBITDA] WHERE [MARGENEBITDAFecha] = @MARGENEBITDAFecha AND [MARGENEBITDAMes] = @MARGENEBITDAMes AND [MARGENEBITDAAno] = @MARGENEBITDAAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo AND [MOTIVOMARGENCod] = @MOTIVOMARGENCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000W4", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000W5", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000W6", "SELECT [MOTIVOMARGENCod] FROM [MOTIVOMARGEN] WHERE [MOTIVOMARGENCod] = @MOTIVOMARGENCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000W7", "SELECT TM1.[MARGENEBITDAFecha], TM1.[MARGENEBITDAMes], TM1.[MARGENEBITDAAno], TM1.[MARGENEBITDAValor], TM1.[MARGENEBITDAuser], TM1.[MARGENEBITDAfec], TM1.[MARGENEBITDAhor], TM1.[Cod_Area], TM1.[IndicadoresCodigo], TM1.[MOTIVOMARGENCod] FROM [MARGENEBITDA] TM1 WHERE TM1.[MARGENEBITDAFecha] = @MARGENEBITDAFecha and TM1.[MARGENEBITDAMes] = @MARGENEBITDAMes and TM1.[MARGENEBITDAAno] = @MARGENEBITDAAno and TM1.[Cod_Area] = @Cod_Area and TM1.[IndicadoresCodigo] = @IndicadoresCodigo and TM1.[MOTIVOMARGENCod] = @MOTIVOMARGENCod ORDER BY TM1.[MARGENEBITDAFecha], TM1.[MARGENEBITDAMes], TM1.[MARGENEBITDAAno], TM1.[Cod_Area], TM1.[IndicadoresCodigo], TM1.[MOTIVOMARGENCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000W7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000W8", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000W9", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000W10", "SELECT [MOTIVOMARGENCod] FROM [MOTIVOMARGEN] WHERE [MOTIVOMARGENCod] = @MOTIVOMARGENCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W10,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000W11", "SELECT [MARGENEBITDAFecha], [MARGENEBITDAMes], [MARGENEBITDAAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOMARGENCod] FROM [MARGENEBITDA] WHERE [MARGENEBITDAFecha] = @MARGENEBITDAFecha AND [MARGENEBITDAMes] = @MARGENEBITDAMes AND [MARGENEBITDAAno] = @MARGENEBITDAAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo AND [MOTIVOMARGENCod] = @MOTIVOMARGENCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000W11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000W12", "SELECT TOP 1 [MARGENEBITDAFecha], [MARGENEBITDAMes], [MARGENEBITDAAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOMARGENCod] FROM [MARGENEBITDA] WHERE ( [MARGENEBITDAFecha] > @MARGENEBITDAFecha or [MARGENEBITDAFecha] = @MARGENEBITDAFecha and [MARGENEBITDAMes] > @MARGENEBITDAMes or [MARGENEBITDAMes] = @MARGENEBITDAMes and [MARGENEBITDAFecha] = @MARGENEBITDAFecha and [MARGENEBITDAAno] > @MARGENEBITDAAno or [MARGENEBITDAAno] = @MARGENEBITDAAno and [MARGENEBITDAMes] = @MARGENEBITDAMes and [MARGENEBITDAFecha] = @MARGENEBITDAFecha and [Cod_Area] > @Cod_Area or [Cod_Area] = @Cod_Area and [MARGENEBITDAAno] = @MARGENEBITDAAno and [MARGENEBITDAMes] = @MARGENEBITDAMes and [MARGENEBITDAFecha] = @MARGENEBITDAFecha and [IndicadoresCodigo] > @IndicadoresCodigo or [IndicadoresCodigo] = @IndicadoresCodigo and [Cod_Area] = @Cod_Area and [MARGENEBITDAAno] = @MARGENEBITDAAno and [MARGENEBITDAMes] = @MARGENEBITDAMes and [MARGENEBITDAFecha] = @MARGENEBITDAFecha and [MOTIVOMARGENCod] > @MOTIVOMARGENCod) ORDER BY [MARGENEBITDAFecha], [MARGENEBITDAMes], [MARGENEBITDAAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOMARGENCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000W12,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000W13", "SELECT TOP 1 [MARGENEBITDAFecha], [MARGENEBITDAMes], [MARGENEBITDAAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOMARGENCod] FROM [MARGENEBITDA] WHERE ( [MARGENEBITDAFecha] < @MARGENEBITDAFecha or [MARGENEBITDAFecha] = @MARGENEBITDAFecha and [MARGENEBITDAMes] < @MARGENEBITDAMes or [MARGENEBITDAMes] = @MARGENEBITDAMes and [MARGENEBITDAFecha] = @MARGENEBITDAFecha and [MARGENEBITDAAno] < @MARGENEBITDAAno or [MARGENEBITDAAno] = @MARGENEBITDAAno and [MARGENEBITDAMes] = @MARGENEBITDAMes and [MARGENEBITDAFecha] = @MARGENEBITDAFecha and [Cod_Area] < @Cod_Area or [Cod_Area] = @Cod_Area and [MARGENEBITDAAno] = @MARGENEBITDAAno and [MARGENEBITDAMes] = @MARGENEBITDAMes and [MARGENEBITDAFecha] = @MARGENEBITDAFecha and [IndicadoresCodigo] < @IndicadoresCodigo or [IndicadoresCodigo] = @IndicadoresCodigo and [Cod_Area] = @Cod_Area and [MARGENEBITDAAno] = @MARGENEBITDAAno and [MARGENEBITDAMes] = @MARGENEBITDAMes and [MARGENEBITDAFecha] = @MARGENEBITDAFecha and [MOTIVOMARGENCod] < @MOTIVOMARGENCod) ORDER BY [MARGENEBITDAFecha] DESC, [MARGENEBITDAMes] DESC, [MARGENEBITDAAno] DESC, [Cod_Area] DESC, [IndicadoresCodigo] DESC, [MOTIVOMARGENCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000W13,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000W14", "INSERT INTO [MARGENEBITDA]([MARGENEBITDAFecha], [MARGENEBITDAMes], [MARGENEBITDAAno], [MARGENEBITDAValor], [MARGENEBITDAuser], [MARGENEBITDAfec], [MARGENEBITDAhor], [Cod_Area], [IndicadoresCodigo], [MOTIVOMARGENCod]) VALUES(@MARGENEBITDAFecha, @MARGENEBITDAMes, @MARGENEBITDAAno, @MARGENEBITDAValor, @MARGENEBITDAuser, @MARGENEBITDAfec, @MARGENEBITDAhor, @Cod_Area, @IndicadoresCodigo, @MOTIVOMARGENCod)", GxErrorMask.GX_NOMASK,prmT000W14)
             ,new CursorDef("T000W15", "UPDATE [MARGENEBITDA] SET [MARGENEBITDAValor]=@MARGENEBITDAValor, [MARGENEBITDAuser]=@MARGENEBITDAuser, [MARGENEBITDAfec]=@MARGENEBITDAfec, [MARGENEBITDAhor]=@MARGENEBITDAhor  WHERE [MARGENEBITDAFecha] = @MARGENEBITDAFecha AND [MARGENEBITDAMes] = @MARGENEBITDAMes AND [MARGENEBITDAAno] = @MARGENEBITDAAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo AND [MOTIVOMARGENCod] = @MOTIVOMARGENCod", GxErrorMask.GX_NOMASK,prmT000W15)
             ,new CursorDef("T000W16", "DELETE FROM [MARGENEBITDA]  WHERE [MARGENEBITDAFecha] = @MARGENEBITDAFecha AND [MARGENEBITDAMes] = @MARGENEBITDAMes AND [MARGENEBITDAAno] = @MARGENEBITDAAno AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo AND [MOTIVOMARGENCod] = @MOTIVOMARGENCod", GxErrorMask.GX_NOMASK,prmT000W16)
             ,new CursorDef("T000W17", "SELECT [MARGENEBITDAFecha], [MARGENEBITDAMes], [MARGENEBITDAAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOMARGENCod] FROM [MARGENEBITDA] ORDER BY [MARGENEBITDAFecha], [MARGENEBITDAMes], [MARGENEBITDAAno], [Cod_Area], [IndicadoresCodigo], [MOTIVOMARGENCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000W17,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000W18", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W18,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000W19", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W19,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000W20", "SELECT [MOTIVOMARGENCod] FROM [MOTIVOMARGEN] WHERE [MOTIVOMARGENCod] = @MOTIVOMARGENCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W20,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
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
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
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
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
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
