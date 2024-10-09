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
   public class accdag : GXDataArea
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
            A17ProcesosACCDAGCod = GetPar( "ProcesosACCDAGCod");
            AssignAttri("", false, "A17ProcesosACCDAGCod", A17ProcesosACCDAGCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A17ProcesosACCDAGCod) ;
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
            Form.Meta.addItem("description", "ACCDAG", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtACCDAG_Fecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("IndicadroresPalmas", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public accdag( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("IndicadroresPalmas", true);
      }

      public accdag( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "ACCDAG", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_ACCDAG.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACCDAG.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACCDAG.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACCDAG.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACCDAG.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 4, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx0080.aspx"+"',["+"{Ctrl:gx.dom.el('"+"ACCDAG_FECHA"+"'), id:'"+"ACCDAG_FECHA"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"ACCDAG_MES"+"'), id:'"+"ACCDAG_MES"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"ACCDAG_ANO"+"'), id:'"+"ACCDAG_ANO"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"COD_AREA"+"'), id:'"+"COD_AREA"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"INDICADORESCODIGO"+"'), id:'"+"INDICADORESCODIGO"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"PROCESOSACCDAGCOD"+"'), id:'"+"PROCESOSACCDAGCOD"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_ACCDAG.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACCDAG_Fecha_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACCDAG_Fecha_Internalname, "ACCDAG_Fecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtACCDAG_Fecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtACCDAG_Fecha_Internalname, context.localUtil.Format(A18ACCDAG_Fecha, "99/99/99"), context.localUtil.Format( A18ACCDAG_Fecha, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACCDAG_Fecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACCDAG_Fecha_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_ACCDAG.htm");
         GxWebStd.gx_bitmap( context, edtACCDAG_Fecha_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtACCDAG_Fecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_ACCDAG.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACCDAG_Mes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACCDAG_Mes_Internalname, "ACCDAG_Mes", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACCDAG_Mes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A19ACCDAG_Mes), 4, 0, ",", "")), StringUtil.LTrim( ((edtACCDAG_Mes_Enabled!=0) ? context.localUtil.Format( (decimal)(A19ACCDAG_Mes), "ZZZ9") : context.localUtil.Format( (decimal)(A19ACCDAG_Mes), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACCDAG_Mes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACCDAG_Mes_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_ACCDAG.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACCDAG_Ano_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACCDAG_Ano_Internalname, "ACCDAG_Ano", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACCDAG_Ano_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A20ACCDAG_Ano), 4, 0, ",", "")), StringUtil.LTrim( ((edtACCDAG_Ano_Enabled!=0) ? context.localUtil.Format( (decimal)(A20ACCDAG_Ano), "ZZZ9") : context.localUtil.Format( (decimal)(A20ACCDAG_Ano), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACCDAG_Ano_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACCDAG_Ano_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_ACCDAG.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCod_Area_Internalname, A5Cod_Area, StringUtil.RTrim( context.localUtil.Format( A5Cod_Area, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCod_Area_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCod_Area_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_ACCDAG.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_5_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_5_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_5_Internalname, sImgUrl, imgprompt_5_Link, "", "", context.GetTheme( ), imgprompt_5_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ACCDAG.htm");
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
         GxWebStd.gx_single_line_edit( context, edtIndicadoresCodigo_Internalname, A4IndicadoresCodigo, StringUtil.RTrim( context.localUtil.Format( A4IndicadoresCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIndicadoresCodigo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIndicadoresCodigo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_ACCDAG.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_4_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_4_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_4_Internalname, sImgUrl, imgprompt_4_Link, "", "", context.GetTheme( ), imgprompt_4_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ACCDAG.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProcesosACCDAGCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProcesosACCDAGCod_Internalname, "Procesos ACCDAGCod", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProcesosACCDAGCod_Internalname, A17ProcesosACCDAGCod, StringUtil.RTrim( context.localUtil.Format( A17ProcesosACCDAGCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProcesosACCDAGCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProcesosACCDAGCod_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_ACCDAG.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_17_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_17_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_17_Internalname, sImgUrl, imgprompt_17_Link, "", "", context.GetTheme( ), imgprompt_17_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ACCDAG.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACCDAGValor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACCDAGValor_Internalname, "ACCDAGValor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACCDAGValor_Internalname, StringUtil.LTrim( StringUtil.NToC( A130ACCDAGValor, 10, 2, ",", "")), StringUtil.LTrim( ((edtACCDAGValor_Enabled!=0) ? context.localUtil.Format( A130ACCDAGValor, "ZZZZZZ9.99") : context.localUtil.Format( A130ACCDAGValor, "ZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACCDAGValor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACCDAGValor_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_ACCDAG.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACCDAGUser_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACCDAGUser_Internalname, "ACCDAGUser", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACCDAGUser_Internalname, A209ACCDAGUser, StringUtil.RTrim( context.localUtil.Format( A209ACCDAGUser, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACCDAGUser_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACCDAGUser_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_ACCDAG.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACCDAGReg_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACCDAGReg_Internalname, "ACCDAGReg", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtACCDAGReg_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtACCDAGReg_Internalname, context.localUtil.Format(A210ACCDAGReg, "99/99/99"), context.localUtil.Format( A210ACCDAGReg, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACCDAGReg_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACCDAGReg_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_ACCDAG.htm");
         GxWebStd.gx_bitmap( context, edtACCDAGReg_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtACCDAGReg_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_ACCDAG.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACCDAGHor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACCDAGHor_Internalname, "ACCDAGHor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACCDAGHor_Internalname, A211ACCDAGHor, StringUtil.RTrim( context.localUtil.Format( A211ACCDAGHor, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACCDAGHor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACCDAGHor_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_ACCDAG.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACCDAG.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACCDAG.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACCDAG.htm");
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
            Z18ACCDAG_Fecha = context.localUtil.CToD( cgiGet( "Z18ACCDAG_Fecha"), 0);
            Z19ACCDAG_Mes = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z19ACCDAG_Mes"), ",", "."), 18, MidpointRounding.ToEven));
            Z20ACCDAG_Ano = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z20ACCDAG_Ano"), ",", "."), 18, MidpointRounding.ToEven));
            Z5Cod_Area = cgiGet( "Z5Cod_Area");
            Z4IndicadoresCodigo = cgiGet( "Z4IndicadoresCodigo");
            Z17ProcesosACCDAGCod = cgiGet( "Z17ProcesosACCDAGCod");
            Z130ACCDAGValor = context.localUtil.CToN( cgiGet( "Z130ACCDAGValor"), ",", ".");
            Z209ACCDAGUser = cgiGet( "Z209ACCDAGUser");
            Z210ACCDAGReg = context.localUtil.CToD( cgiGet( "Z210ACCDAGReg"), 0);
            Z211ACCDAGHor = cgiGet( "Z211ACCDAGHor");
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( context.localUtil.VCDate( cgiGet( edtACCDAG_Fecha_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"ACCDAG_Fecha"}), 1, "ACCDAG_FECHA");
               AnyError = 1;
               GX_FocusControl = edtACCDAG_Fecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A18ACCDAG_Fecha = DateTime.MinValue;
               AssignAttri("", false, "A18ACCDAG_Fecha", context.localUtil.Format(A18ACCDAG_Fecha, "99/99/99"));
            }
            else
            {
               A18ACCDAG_Fecha = context.localUtil.CToD( cgiGet( edtACCDAG_Fecha_Internalname), 2);
               AssignAttri("", false, "A18ACCDAG_Fecha", context.localUtil.Format(A18ACCDAG_Fecha, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtACCDAG_Mes_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtACCDAG_Mes_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACCDAG_MES");
               AnyError = 1;
               GX_FocusControl = edtACCDAG_Mes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A19ACCDAG_Mes = 0;
               AssignAttri("", false, "A19ACCDAG_Mes", StringUtil.LTrimStr( (decimal)(A19ACCDAG_Mes), 4, 0));
            }
            else
            {
               A19ACCDAG_Mes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtACCDAG_Mes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A19ACCDAG_Mes", StringUtil.LTrimStr( (decimal)(A19ACCDAG_Mes), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtACCDAG_Ano_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtACCDAG_Ano_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACCDAG_ANO");
               AnyError = 1;
               GX_FocusControl = edtACCDAG_Ano_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A20ACCDAG_Ano = 0;
               AssignAttri("", false, "A20ACCDAG_Ano", StringUtil.LTrimStr( (decimal)(A20ACCDAG_Ano), 4, 0));
            }
            else
            {
               A20ACCDAG_Ano = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtACCDAG_Ano_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A20ACCDAG_Ano", StringUtil.LTrimStr( (decimal)(A20ACCDAG_Ano), 4, 0));
            }
            A5Cod_Area = cgiGet( edtCod_Area_Internalname);
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = cgiGet( edtIndicadoresCodigo_Internalname);
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A17ProcesosACCDAGCod = cgiGet( edtProcesosACCDAGCod_Internalname);
            AssignAttri("", false, "A17ProcesosACCDAGCod", A17ProcesosACCDAGCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtACCDAGValor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtACCDAGValor_Internalname), ",", ".") > 9999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACCDAGVALOR");
               AnyError = 1;
               GX_FocusControl = edtACCDAGValor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A130ACCDAGValor = 0;
               AssignAttri("", false, "A130ACCDAGValor", StringUtil.LTrimStr( A130ACCDAGValor, 10, 2));
            }
            else
            {
               A130ACCDAGValor = context.localUtil.CToN( cgiGet( edtACCDAGValor_Internalname), ",", ".");
               AssignAttri("", false, "A130ACCDAGValor", StringUtil.LTrimStr( A130ACCDAGValor, 10, 2));
            }
            A209ACCDAGUser = cgiGet( edtACCDAGUser_Internalname);
            AssignAttri("", false, "A209ACCDAGUser", A209ACCDAGUser);
            if ( context.localUtil.VCDate( cgiGet( edtACCDAGReg_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"ACCDAGReg"}), 1, "ACCDAGREG");
               AnyError = 1;
               GX_FocusControl = edtACCDAGReg_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A210ACCDAGReg = DateTime.MinValue;
               AssignAttri("", false, "A210ACCDAGReg", context.localUtil.Format(A210ACCDAGReg, "99/99/99"));
            }
            else
            {
               A210ACCDAGReg = context.localUtil.CToD( cgiGet( edtACCDAGReg_Internalname), 2);
               AssignAttri("", false, "A210ACCDAGReg", context.localUtil.Format(A210ACCDAGReg, "99/99/99"));
            }
            A211ACCDAGHor = cgiGet( edtACCDAGHor_Internalname);
            AssignAttri("", false, "A211ACCDAGHor", A211ACCDAGHor);
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
               A18ACCDAG_Fecha = context.localUtil.ParseDateParm( GetPar( "ACCDAG_Fecha"));
               AssignAttri("", false, "A18ACCDAG_Fecha", context.localUtil.Format(A18ACCDAG_Fecha, "99/99/99"));
               A19ACCDAG_Mes = (short)(Math.Round(NumberUtil.Val( GetPar( "ACCDAG_Mes"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A19ACCDAG_Mes", StringUtil.LTrimStr( (decimal)(A19ACCDAG_Mes), 4, 0));
               A20ACCDAG_Ano = (short)(Math.Round(NumberUtil.Val( GetPar( "ACCDAG_Ano"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A20ACCDAG_Ano", StringUtil.LTrimStr( (decimal)(A20ACCDAG_Ano), 4, 0));
               A5Cod_Area = GetPar( "Cod_Area");
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               A4IndicadoresCodigo = GetPar( "IndicadoresCodigo");
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               A17ProcesosACCDAGCod = GetPar( "ProcesosACCDAGCod");
               AssignAttri("", false, "A17ProcesosACCDAGCod", A17ProcesosACCDAGCod);
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
               InitAll078( ) ;
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
         DisableAttributes078( ) ;
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

      protected void ResetCaption070( )
      {
      }

      protected void ZM078( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z130ACCDAGValor = T00073_A130ACCDAGValor[0];
               Z209ACCDAGUser = T00073_A209ACCDAGUser[0];
               Z210ACCDAGReg = T00073_A210ACCDAGReg[0];
               Z211ACCDAGHor = T00073_A211ACCDAGHor[0];
            }
            else
            {
               Z130ACCDAGValor = A130ACCDAGValor;
               Z209ACCDAGUser = A209ACCDAGUser;
               Z210ACCDAGReg = A210ACCDAGReg;
               Z211ACCDAGHor = A211ACCDAGHor;
            }
         }
         if ( GX_JID == -3 )
         {
            Z18ACCDAG_Fecha = A18ACCDAG_Fecha;
            Z19ACCDAG_Mes = A19ACCDAG_Mes;
            Z20ACCDAG_Ano = A20ACCDAG_Ano;
            Z130ACCDAGValor = A130ACCDAGValor;
            Z209ACCDAGUser = A209ACCDAGUser;
            Z210ACCDAGReg = A210ACCDAGReg;
            Z211ACCDAGHor = A211ACCDAGHor;
            Z5Cod_Area = A5Cod_Area;
            Z4IndicadoresCodigo = A4IndicadoresCodigo;
            Z17ProcesosACCDAGCod = A17ProcesosACCDAGCod;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_5_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"COD_AREA"+"'), id:'"+"COD_AREA"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"true"+");");
         imgprompt_4_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0030.aspx"+"',["+"{Ctrl:gx.dom.el('"+"INDICADORESCODIGO"+"'), id:'"+"INDICADORESCODIGO"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"true"+");");
         imgprompt_17_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0070.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PROCESOSACCDAGCOD"+"'), id:'"+"PROCESOSACCDAGCOD"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");");
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

      protected void Load078( )
      {
         /* Using cursor T00077 */
         pr_default.execute(5, new Object[] {A18ACCDAG_Fecha, A19ACCDAG_Mes, A20ACCDAG_Ano, A5Cod_Area, A4IndicadoresCodigo, A17ProcesosACCDAGCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound8 = 1;
            A130ACCDAGValor = T00077_A130ACCDAGValor[0];
            AssignAttri("", false, "A130ACCDAGValor", StringUtil.LTrimStr( A130ACCDAGValor, 10, 2));
            A209ACCDAGUser = T00077_A209ACCDAGUser[0];
            AssignAttri("", false, "A209ACCDAGUser", A209ACCDAGUser);
            A210ACCDAGReg = T00077_A210ACCDAGReg[0];
            AssignAttri("", false, "A210ACCDAGReg", context.localUtil.Format(A210ACCDAGReg, "99/99/99"));
            A211ACCDAGHor = T00077_A211ACCDAGHor[0];
            AssignAttri("", false, "A211ACCDAGHor", A211ACCDAGHor);
            ZM078( -3) ;
         }
         pr_default.close(5);
         OnLoadActions078( ) ;
      }

      protected void OnLoadActions078( )
      {
      }

      protected void CheckExtendedTable078( )
      {
         nIsDirty_8 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A18ACCDAG_Fecha) || ( DateTimeUtil.ResetTime ( A18ACCDAG_Fecha ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo ACCDAG_Fecha fuera de rango", "OutOfRange", 1, "ACCDAG_FECHA");
            AnyError = 1;
            GX_FocusControl = edtACCDAG_Fecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00074 */
         pr_default.execute(2, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T00075 */
         pr_default.execute(3, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         /* Using cursor T00076 */
         pr_default.execute(4, new Object[] {A17ProcesosACCDAGCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Procesos ACCDAG'.", "ForeignKeyNotFound", 1, "PROCESOSACCDAGCOD");
            AnyError = 1;
            GX_FocusControl = edtProcesosACCDAGCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(4);
         if ( ! ( (DateTime.MinValue==A210ACCDAGReg) || ( DateTimeUtil.ResetTime ( A210ACCDAGReg ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo ACCDAGReg fuera de rango", "OutOfRange", 1, "ACCDAGREG");
            AnyError = 1;
            GX_FocusControl = edtACCDAGReg_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors078( )
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
         /* Using cursor T00078 */
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
         /* Using cursor T00079 */
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

      protected void gxLoad_6( string A17ProcesosACCDAGCod )
      {
         /* Using cursor T000710 */
         pr_default.execute(8, new Object[] {A17ProcesosACCDAGCod});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Procesos ACCDAG'.", "ForeignKeyNotFound", 1, "PROCESOSACCDAGCOD");
            AnyError = 1;
            GX_FocusControl = edtProcesosACCDAGCod_Internalname;
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

      protected void GetKey078( )
      {
         /* Using cursor T000711 */
         pr_default.execute(9, new Object[] {A18ACCDAG_Fecha, A19ACCDAG_Mes, A20ACCDAG_Ano, A5Cod_Area, A4IndicadoresCodigo, A17ProcesosACCDAGCod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound8 = 1;
         }
         else
         {
            RcdFound8 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00073 */
         pr_default.execute(1, new Object[] {A18ACCDAG_Fecha, A19ACCDAG_Mes, A20ACCDAG_Ano, A5Cod_Area, A4IndicadoresCodigo, A17ProcesosACCDAGCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM078( 3) ;
            RcdFound8 = 1;
            A18ACCDAG_Fecha = T00073_A18ACCDAG_Fecha[0];
            AssignAttri("", false, "A18ACCDAG_Fecha", context.localUtil.Format(A18ACCDAG_Fecha, "99/99/99"));
            A19ACCDAG_Mes = T00073_A19ACCDAG_Mes[0];
            AssignAttri("", false, "A19ACCDAG_Mes", StringUtil.LTrimStr( (decimal)(A19ACCDAG_Mes), 4, 0));
            A20ACCDAG_Ano = T00073_A20ACCDAG_Ano[0];
            AssignAttri("", false, "A20ACCDAG_Ano", StringUtil.LTrimStr( (decimal)(A20ACCDAG_Ano), 4, 0));
            A130ACCDAGValor = T00073_A130ACCDAGValor[0];
            AssignAttri("", false, "A130ACCDAGValor", StringUtil.LTrimStr( A130ACCDAGValor, 10, 2));
            A209ACCDAGUser = T00073_A209ACCDAGUser[0];
            AssignAttri("", false, "A209ACCDAGUser", A209ACCDAGUser);
            A210ACCDAGReg = T00073_A210ACCDAGReg[0];
            AssignAttri("", false, "A210ACCDAGReg", context.localUtil.Format(A210ACCDAGReg, "99/99/99"));
            A211ACCDAGHor = T00073_A211ACCDAGHor[0];
            AssignAttri("", false, "A211ACCDAGHor", A211ACCDAGHor);
            A5Cod_Area = T00073_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = T00073_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A17ProcesosACCDAGCod = T00073_A17ProcesosACCDAGCod[0];
            AssignAttri("", false, "A17ProcesosACCDAGCod", A17ProcesosACCDAGCod);
            Z18ACCDAG_Fecha = A18ACCDAG_Fecha;
            Z19ACCDAG_Mes = A19ACCDAG_Mes;
            Z20ACCDAG_Ano = A20ACCDAG_Ano;
            Z5Cod_Area = A5Cod_Area;
            Z4IndicadoresCodigo = A4IndicadoresCodigo;
            Z17ProcesosACCDAGCod = A17ProcesosACCDAGCod;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load078( ) ;
            if ( AnyError == 1 )
            {
               RcdFound8 = 0;
               InitializeNonKey078( ) ;
            }
            Gx_mode = sMode8;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound8 = 0;
            InitializeNonKey078( ) ;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode8;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey078( ) ;
         if ( RcdFound8 == 0 )
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
         RcdFound8 = 0;
         /* Using cursor T000712 */
         pr_default.execute(10, new Object[] {A18ACCDAG_Fecha, A19ACCDAG_Mes, A20ACCDAG_Ano, A5Cod_Area, A4IndicadoresCodigo, A17ProcesosACCDAGCod});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( DateTimeUtil.ResetTime ( T000712_A18ACCDAG_Fecha[0] ) < DateTimeUtil.ResetTime ( A18ACCDAG_Fecha ) ) || ( DateTimeUtil.ResetTime ( T000712_A18ACCDAG_Fecha[0] ) == DateTimeUtil.ResetTime ( A18ACCDAG_Fecha ) ) && ( T000712_A19ACCDAG_Mes[0] < A19ACCDAG_Mes ) || ( T000712_A19ACCDAG_Mes[0] == A19ACCDAG_Mes ) && ( DateTimeUtil.ResetTime ( T000712_A18ACCDAG_Fecha[0] ) == DateTimeUtil.ResetTime ( A18ACCDAG_Fecha ) ) && ( T000712_A20ACCDAG_Ano[0] < A20ACCDAG_Ano ) || ( T000712_A20ACCDAG_Ano[0] == A20ACCDAG_Ano ) && ( T000712_A19ACCDAG_Mes[0] == A19ACCDAG_Mes ) && ( DateTimeUtil.ResetTime ( T000712_A18ACCDAG_Fecha[0] ) == DateTimeUtil.ResetTime ( A18ACCDAG_Fecha ) ) && ( StringUtil.StrCmp(T000712_A5Cod_Area[0], A5Cod_Area) < 0 ) || ( StringUtil.StrCmp(T000712_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000712_A20ACCDAG_Ano[0] == A20ACCDAG_Ano ) && ( T000712_A19ACCDAG_Mes[0] == A19ACCDAG_Mes ) && ( DateTimeUtil.ResetTime ( T000712_A18ACCDAG_Fecha[0] ) == DateTimeUtil.ResetTime ( A18ACCDAG_Fecha ) ) && ( StringUtil.StrCmp(T000712_A4IndicadoresCodigo[0], A4IndicadoresCodigo) < 0 ) || ( StringUtil.StrCmp(T000712_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T000712_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000712_A20ACCDAG_Ano[0] == A20ACCDAG_Ano ) && ( T000712_A19ACCDAG_Mes[0] == A19ACCDAG_Mes ) && ( DateTimeUtil.ResetTime ( T000712_A18ACCDAG_Fecha[0] ) == DateTimeUtil.ResetTime ( A18ACCDAG_Fecha ) ) && ( StringUtil.StrCmp(T000712_A17ProcesosACCDAGCod[0], A17ProcesosACCDAGCod) < 0 ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( DateTimeUtil.ResetTime ( T000712_A18ACCDAG_Fecha[0] ) > DateTimeUtil.ResetTime ( A18ACCDAG_Fecha ) ) || ( DateTimeUtil.ResetTime ( T000712_A18ACCDAG_Fecha[0] ) == DateTimeUtil.ResetTime ( A18ACCDAG_Fecha ) ) && ( T000712_A19ACCDAG_Mes[0] > A19ACCDAG_Mes ) || ( T000712_A19ACCDAG_Mes[0] == A19ACCDAG_Mes ) && ( DateTimeUtil.ResetTime ( T000712_A18ACCDAG_Fecha[0] ) == DateTimeUtil.ResetTime ( A18ACCDAG_Fecha ) ) && ( T000712_A20ACCDAG_Ano[0] > A20ACCDAG_Ano ) || ( T000712_A20ACCDAG_Ano[0] == A20ACCDAG_Ano ) && ( T000712_A19ACCDAG_Mes[0] == A19ACCDAG_Mes ) && ( DateTimeUtil.ResetTime ( T000712_A18ACCDAG_Fecha[0] ) == DateTimeUtil.ResetTime ( A18ACCDAG_Fecha ) ) && ( StringUtil.StrCmp(T000712_A5Cod_Area[0], A5Cod_Area) > 0 ) || ( StringUtil.StrCmp(T000712_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000712_A20ACCDAG_Ano[0] == A20ACCDAG_Ano ) && ( T000712_A19ACCDAG_Mes[0] == A19ACCDAG_Mes ) && ( DateTimeUtil.ResetTime ( T000712_A18ACCDAG_Fecha[0] ) == DateTimeUtil.ResetTime ( A18ACCDAG_Fecha ) ) && ( StringUtil.StrCmp(T000712_A4IndicadoresCodigo[0], A4IndicadoresCodigo) > 0 ) || ( StringUtil.StrCmp(T000712_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T000712_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000712_A20ACCDAG_Ano[0] == A20ACCDAG_Ano ) && ( T000712_A19ACCDAG_Mes[0] == A19ACCDAG_Mes ) && ( DateTimeUtil.ResetTime ( T000712_A18ACCDAG_Fecha[0] ) == DateTimeUtil.ResetTime ( A18ACCDAG_Fecha ) ) && ( StringUtil.StrCmp(T000712_A17ProcesosACCDAGCod[0], A17ProcesosACCDAGCod) > 0 ) ) )
            {
               A18ACCDAG_Fecha = T000712_A18ACCDAG_Fecha[0];
               AssignAttri("", false, "A18ACCDAG_Fecha", context.localUtil.Format(A18ACCDAG_Fecha, "99/99/99"));
               A19ACCDAG_Mes = T000712_A19ACCDAG_Mes[0];
               AssignAttri("", false, "A19ACCDAG_Mes", StringUtil.LTrimStr( (decimal)(A19ACCDAG_Mes), 4, 0));
               A20ACCDAG_Ano = T000712_A20ACCDAG_Ano[0];
               AssignAttri("", false, "A20ACCDAG_Ano", StringUtil.LTrimStr( (decimal)(A20ACCDAG_Ano), 4, 0));
               A5Cod_Area = T000712_A5Cod_Area[0];
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               A4IndicadoresCodigo = T000712_A4IndicadoresCodigo[0];
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               A17ProcesosACCDAGCod = T000712_A17ProcesosACCDAGCod[0];
               AssignAttri("", false, "A17ProcesosACCDAGCod", A17ProcesosACCDAGCod);
               RcdFound8 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound8 = 0;
         /* Using cursor T000713 */
         pr_default.execute(11, new Object[] {A18ACCDAG_Fecha, A19ACCDAG_Mes, A20ACCDAG_Ano, A5Cod_Area, A4IndicadoresCodigo, A17ProcesosACCDAGCod});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( DateTimeUtil.ResetTime ( T000713_A18ACCDAG_Fecha[0] ) > DateTimeUtil.ResetTime ( A18ACCDAG_Fecha ) ) || ( DateTimeUtil.ResetTime ( T000713_A18ACCDAG_Fecha[0] ) == DateTimeUtil.ResetTime ( A18ACCDAG_Fecha ) ) && ( T000713_A19ACCDAG_Mes[0] > A19ACCDAG_Mes ) || ( T000713_A19ACCDAG_Mes[0] == A19ACCDAG_Mes ) && ( DateTimeUtil.ResetTime ( T000713_A18ACCDAG_Fecha[0] ) == DateTimeUtil.ResetTime ( A18ACCDAG_Fecha ) ) && ( T000713_A20ACCDAG_Ano[0] > A20ACCDAG_Ano ) || ( T000713_A20ACCDAG_Ano[0] == A20ACCDAG_Ano ) && ( T000713_A19ACCDAG_Mes[0] == A19ACCDAG_Mes ) && ( DateTimeUtil.ResetTime ( T000713_A18ACCDAG_Fecha[0] ) == DateTimeUtil.ResetTime ( A18ACCDAG_Fecha ) ) && ( StringUtil.StrCmp(T000713_A5Cod_Area[0], A5Cod_Area) > 0 ) || ( StringUtil.StrCmp(T000713_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000713_A20ACCDAG_Ano[0] == A20ACCDAG_Ano ) && ( T000713_A19ACCDAG_Mes[0] == A19ACCDAG_Mes ) && ( DateTimeUtil.ResetTime ( T000713_A18ACCDAG_Fecha[0] ) == DateTimeUtil.ResetTime ( A18ACCDAG_Fecha ) ) && ( StringUtil.StrCmp(T000713_A4IndicadoresCodigo[0], A4IndicadoresCodigo) > 0 ) || ( StringUtil.StrCmp(T000713_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T000713_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000713_A20ACCDAG_Ano[0] == A20ACCDAG_Ano ) && ( T000713_A19ACCDAG_Mes[0] == A19ACCDAG_Mes ) && ( DateTimeUtil.ResetTime ( T000713_A18ACCDAG_Fecha[0] ) == DateTimeUtil.ResetTime ( A18ACCDAG_Fecha ) ) && ( StringUtil.StrCmp(T000713_A17ProcesosACCDAGCod[0], A17ProcesosACCDAGCod) > 0 ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( DateTimeUtil.ResetTime ( T000713_A18ACCDAG_Fecha[0] ) < DateTimeUtil.ResetTime ( A18ACCDAG_Fecha ) ) || ( DateTimeUtil.ResetTime ( T000713_A18ACCDAG_Fecha[0] ) == DateTimeUtil.ResetTime ( A18ACCDAG_Fecha ) ) && ( T000713_A19ACCDAG_Mes[0] < A19ACCDAG_Mes ) || ( T000713_A19ACCDAG_Mes[0] == A19ACCDAG_Mes ) && ( DateTimeUtil.ResetTime ( T000713_A18ACCDAG_Fecha[0] ) == DateTimeUtil.ResetTime ( A18ACCDAG_Fecha ) ) && ( T000713_A20ACCDAG_Ano[0] < A20ACCDAG_Ano ) || ( T000713_A20ACCDAG_Ano[0] == A20ACCDAG_Ano ) && ( T000713_A19ACCDAG_Mes[0] == A19ACCDAG_Mes ) && ( DateTimeUtil.ResetTime ( T000713_A18ACCDAG_Fecha[0] ) == DateTimeUtil.ResetTime ( A18ACCDAG_Fecha ) ) && ( StringUtil.StrCmp(T000713_A5Cod_Area[0], A5Cod_Area) < 0 ) || ( StringUtil.StrCmp(T000713_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000713_A20ACCDAG_Ano[0] == A20ACCDAG_Ano ) && ( T000713_A19ACCDAG_Mes[0] == A19ACCDAG_Mes ) && ( DateTimeUtil.ResetTime ( T000713_A18ACCDAG_Fecha[0] ) == DateTimeUtil.ResetTime ( A18ACCDAG_Fecha ) ) && ( StringUtil.StrCmp(T000713_A4IndicadoresCodigo[0], A4IndicadoresCodigo) < 0 ) || ( StringUtil.StrCmp(T000713_A4IndicadoresCodigo[0], A4IndicadoresCodigo) == 0 ) && ( StringUtil.StrCmp(T000713_A5Cod_Area[0], A5Cod_Area) == 0 ) && ( T000713_A20ACCDAG_Ano[0] == A20ACCDAG_Ano ) && ( T000713_A19ACCDAG_Mes[0] == A19ACCDAG_Mes ) && ( DateTimeUtil.ResetTime ( T000713_A18ACCDAG_Fecha[0] ) == DateTimeUtil.ResetTime ( A18ACCDAG_Fecha ) ) && ( StringUtil.StrCmp(T000713_A17ProcesosACCDAGCod[0], A17ProcesosACCDAGCod) < 0 ) ) )
            {
               A18ACCDAG_Fecha = T000713_A18ACCDAG_Fecha[0];
               AssignAttri("", false, "A18ACCDAG_Fecha", context.localUtil.Format(A18ACCDAG_Fecha, "99/99/99"));
               A19ACCDAG_Mes = T000713_A19ACCDAG_Mes[0];
               AssignAttri("", false, "A19ACCDAG_Mes", StringUtil.LTrimStr( (decimal)(A19ACCDAG_Mes), 4, 0));
               A20ACCDAG_Ano = T000713_A20ACCDAG_Ano[0];
               AssignAttri("", false, "A20ACCDAG_Ano", StringUtil.LTrimStr( (decimal)(A20ACCDAG_Ano), 4, 0));
               A5Cod_Area = T000713_A5Cod_Area[0];
               AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
               A4IndicadoresCodigo = T000713_A4IndicadoresCodigo[0];
               AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
               A17ProcesosACCDAGCod = T000713_A17ProcesosACCDAGCod[0];
               AssignAttri("", false, "A17ProcesosACCDAGCod", A17ProcesosACCDAGCod);
               RcdFound8 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey078( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtACCDAG_Fecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert078( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound8 == 1 )
            {
               if ( ( DateTimeUtil.ResetTime ( A18ACCDAG_Fecha ) != DateTimeUtil.ResetTime ( Z18ACCDAG_Fecha ) ) || ( A19ACCDAG_Mes != Z19ACCDAG_Mes ) || ( A20ACCDAG_Ano != Z20ACCDAG_Ano ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) || ( StringUtil.StrCmp(A17ProcesosACCDAGCod, Z17ProcesosACCDAGCod) != 0 ) )
               {
                  A18ACCDAG_Fecha = Z18ACCDAG_Fecha;
                  AssignAttri("", false, "A18ACCDAG_Fecha", context.localUtil.Format(A18ACCDAG_Fecha, "99/99/99"));
                  A19ACCDAG_Mes = Z19ACCDAG_Mes;
                  AssignAttri("", false, "A19ACCDAG_Mes", StringUtil.LTrimStr( (decimal)(A19ACCDAG_Mes), 4, 0));
                  A20ACCDAG_Ano = Z20ACCDAG_Ano;
                  AssignAttri("", false, "A20ACCDAG_Ano", StringUtil.LTrimStr( (decimal)(A20ACCDAG_Ano), 4, 0));
                  A5Cod_Area = Z5Cod_Area;
                  AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
                  A4IndicadoresCodigo = Z4IndicadoresCodigo;
                  AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
                  A17ProcesosACCDAGCod = Z17ProcesosACCDAGCod;
                  AssignAttri("", false, "A17ProcesosACCDAGCod", A17ProcesosACCDAGCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ACCDAG_FECHA");
                  AnyError = 1;
                  GX_FocusControl = edtACCDAG_Fecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtACCDAG_Fecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update078( ) ;
                  GX_FocusControl = edtACCDAG_Fecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( DateTimeUtil.ResetTime ( A18ACCDAG_Fecha ) != DateTimeUtil.ResetTime ( Z18ACCDAG_Fecha ) ) || ( A19ACCDAG_Mes != Z19ACCDAG_Mes ) || ( A20ACCDAG_Ano != Z20ACCDAG_Ano ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) || ( StringUtil.StrCmp(A17ProcesosACCDAGCod, Z17ProcesosACCDAGCod) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtACCDAG_Fecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert078( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ACCDAG_FECHA");
                     AnyError = 1;
                     GX_FocusControl = edtACCDAG_Fecha_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtACCDAG_Fecha_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert078( ) ;
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
         if ( ( DateTimeUtil.ResetTime ( A18ACCDAG_Fecha ) != DateTimeUtil.ResetTime ( Z18ACCDAG_Fecha ) ) || ( A19ACCDAG_Mes != Z19ACCDAG_Mes ) || ( A20ACCDAG_Ano != Z20ACCDAG_Ano ) || ( StringUtil.StrCmp(A5Cod_Area, Z5Cod_Area) != 0 ) || ( StringUtil.StrCmp(A4IndicadoresCodigo, Z4IndicadoresCodigo) != 0 ) || ( StringUtil.StrCmp(A17ProcesosACCDAGCod, Z17ProcesosACCDAGCod) != 0 ) )
         {
            A18ACCDAG_Fecha = Z18ACCDAG_Fecha;
            AssignAttri("", false, "A18ACCDAG_Fecha", context.localUtil.Format(A18ACCDAG_Fecha, "99/99/99"));
            A19ACCDAG_Mes = Z19ACCDAG_Mes;
            AssignAttri("", false, "A19ACCDAG_Mes", StringUtil.LTrimStr( (decimal)(A19ACCDAG_Mes), 4, 0));
            A20ACCDAG_Ano = Z20ACCDAG_Ano;
            AssignAttri("", false, "A20ACCDAG_Ano", StringUtil.LTrimStr( (decimal)(A20ACCDAG_Ano), 4, 0));
            A5Cod_Area = Z5Cod_Area;
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = Z4IndicadoresCodigo;
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A17ProcesosACCDAGCod = Z17ProcesosACCDAGCod;
            AssignAttri("", false, "A17ProcesosACCDAGCod", A17ProcesosACCDAGCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ACCDAG_FECHA");
            AnyError = 1;
            GX_FocusControl = edtACCDAG_Fecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtACCDAG_Fecha_Internalname;
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
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "ACCDAG_FECHA");
            AnyError = 1;
            GX_FocusControl = edtACCDAG_Fecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtACCDAGValor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart078( ) ;
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtACCDAGValor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd078( ) ;
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
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtACCDAGValor_Internalname;
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
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtACCDAGValor_Internalname;
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
         ScanStart078( ) ;
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound8 != 0 )
            {
               ScanNext078( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtACCDAGValor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd078( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency078( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00072 */
            pr_default.execute(0, new Object[] {A18ACCDAG_Fecha, A19ACCDAG_Mes, A20ACCDAG_Ano, A5Cod_Area, A4IndicadoresCodigo, A17ProcesosACCDAGCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ACCDAG"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z130ACCDAGValor != T00072_A130ACCDAGValor[0] ) || ( StringUtil.StrCmp(Z209ACCDAGUser, T00072_A209ACCDAGUser[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z210ACCDAGReg ) != DateTimeUtil.ResetTime ( T00072_A210ACCDAGReg[0] ) ) || ( StringUtil.StrCmp(Z211ACCDAGHor, T00072_A211ACCDAGHor[0]) != 0 ) )
            {
               if ( Z130ACCDAGValor != T00072_A130ACCDAGValor[0] )
               {
                  GXUtil.WriteLog("accdag:[seudo value changed for attri]"+"ACCDAGValor");
                  GXUtil.WriteLogRaw("Old: ",Z130ACCDAGValor);
                  GXUtil.WriteLogRaw("Current: ",T00072_A130ACCDAGValor[0]);
               }
               if ( StringUtil.StrCmp(Z209ACCDAGUser, T00072_A209ACCDAGUser[0]) != 0 )
               {
                  GXUtil.WriteLog("accdag:[seudo value changed for attri]"+"ACCDAGUser");
                  GXUtil.WriteLogRaw("Old: ",Z209ACCDAGUser);
                  GXUtil.WriteLogRaw("Current: ",T00072_A209ACCDAGUser[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z210ACCDAGReg ) != DateTimeUtil.ResetTime ( T00072_A210ACCDAGReg[0] ) )
               {
                  GXUtil.WriteLog("accdag:[seudo value changed for attri]"+"ACCDAGReg");
                  GXUtil.WriteLogRaw("Old: ",Z210ACCDAGReg);
                  GXUtil.WriteLogRaw("Current: ",T00072_A210ACCDAGReg[0]);
               }
               if ( StringUtil.StrCmp(Z211ACCDAGHor, T00072_A211ACCDAGHor[0]) != 0 )
               {
                  GXUtil.WriteLog("accdag:[seudo value changed for attri]"+"ACCDAGHor");
                  GXUtil.WriteLogRaw("Old: ",Z211ACCDAGHor);
                  GXUtil.WriteLogRaw("Current: ",T00072_A211ACCDAGHor[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ACCDAG"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert078( )
      {
         BeforeValidate078( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable078( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM078( 0) ;
            CheckOptimisticConcurrency078( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm078( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert078( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000714 */
                     pr_default.execute(12, new Object[] {A18ACCDAG_Fecha, A19ACCDAG_Mes, A20ACCDAG_Ano, A130ACCDAGValor, A209ACCDAGUser, A210ACCDAGReg, A211ACCDAGHor, A5Cod_Area, A4IndicadoresCodigo, A17ProcesosACCDAGCod});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("ACCDAG");
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
                           ResetCaption070( ) ;
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
               Load078( ) ;
            }
            EndLevel078( ) ;
         }
         CloseExtendedTableCursors078( ) ;
      }

      protected void Update078( )
      {
         BeforeValidate078( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable078( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency078( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm078( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate078( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000715 */
                     pr_default.execute(13, new Object[] {A130ACCDAGValor, A209ACCDAGUser, A210ACCDAGReg, A211ACCDAGHor, A18ACCDAG_Fecha, A19ACCDAG_Mes, A20ACCDAG_Ano, A5Cod_Area, A4IndicadoresCodigo, A17ProcesosACCDAGCod});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("ACCDAG");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ACCDAG"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate078( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption070( ) ;
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
            EndLevel078( ) ;
         }
         CloseExtendedTableCursors078( ) ;
      }

      protected void DeferredUpdate078( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate078( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency078( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls078( ) ;
            AfterConfirm078( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete078( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000716 */
                  pr_default.execute(14, new Object[] {A18ACCDAG_Fecha, A19ACCDAG_Mes, A20ACCDAG_Ano, A5Cod_Area, A4IndicadoresCodigo, A17ProcesosACCDAGCod});
                  pr_default.close(14);
                  pr_default.SmartCacheProvider.SetUpdated("ACCDAG");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound8 == 0 )
                        {
                           InitAll078( ) ;
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
                        ResetCaption070( ) ;
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
         sMode8 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel078( ) ;
         Gx_mode = sMode8;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls078( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel078( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete078( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("accdag",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues070( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("accdag",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart078( )
      {
         /* Using cursor T000717 */
         pr_default.execute(15);
         RcdFound8 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound8 = 1;
            A18ACCDAG_Fecha = T000717_A18ACCDAG_Fecha[0];
            AssignAttri("", false, "A18ACCDAG_Fecha", context.localUtil.Format(A18ACCDAG_Fecha, "99/99/99"));
            A19ACCDAG_Mes = T000717_A19ACCDAG_Mes[0];
            AssignAttri("", false, "A19ACCDAG_Mes", StringUtil.LTrimStr( (decimal)(A19ACCDAG_Mes), 4, 0));
            A20ACCDAG_Ano = T000717_A20ACCDAG_Ano[0];
            AssignAttri("", false, "A20ACCDAG_Ano", StringUtil.LTrimStr( (decimal)(A20ACCDAG_Ano), 4, 0));
            A5Cod_Area = T000717_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = T000717_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A17ProcesosACCDAGCod = T000717_A17ProcesosACCDAGCod[0];
            AssignAttri("", false, "A17ProcesosACCDAGCod", A17ProcesosACCDAGCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext078( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound8 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound8 = 1;
            A18ACCDAG_Fecha = T000717_A18ACCDAG_Fecha[0];
            AssignAttri("", false, "A18ACCDAG_Fecha", context.localUtil.Format(A18ACCDAG_Fecha, "99/99/99"));
            A19ACCDAG_Mes = T000717_A19ACCDAG_Mes[0];
            AssignAttri("", false, "A19ACCDAG_Mes", StringUtil.LTrimStr( (decimal)(A19ACCDAG_Mes), 4, 0));
            A20ACCDAG_Ano = T000717_A20ACCDAG_Ano[0];
            AssignAttri("", false, "A20ACCDAG_Ano", StringUtil.LTrimStr( (decimal)(A20ACCDAG_Ano), 4, 0));
            A5Cod_Area = T000717_A5Cod_Area[0];
            AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
            A4IndicadoresCodigo = T000717_A4IndicadoresCodigo[0];
            AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
            A17ProcesosACCDAGCod = T000717_A17ProcesosACCDAGCod[0];
            AssignAttri("", false, "A17ProcesosACCDAGCod", A17ProcesosACCDAGCod);
         }
      }

      protected void ScanEnd078( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm078( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert078( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate078( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete078( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete078( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate078( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes078( )
      {
         edtACCDAG_Fecha_Enabled = 0;
         AssignProp("", false, edtACCDAG_Fecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACCDAG_Fecha_Enabled), 5, 0), true);
         edtACCDAG_Mes_Enabled = 0;
         AssignProp("", false, edtACCDAG_Mes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACCDAG_Mes_Enabled), 5, 0), true);
         edtACCDAG_Ano_Enabled = 0;
         AssignProp("", false, edtACCDAG_Ano_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACCDAG_Ano_Enabled), 5, 0), true);
         edtCod_Area_Enabled = 0;
         AssignProp("", false, edtCod_Area_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCod_Area_Enabled), 5, 0), true);
         edtIndicadoresCodigo_Enabled = 0;
         AssignProp("", false, edtIndicadoresCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIndicadoresCodigo_Enabled), 5, 0), true);
         edtProcesosACCDAGCod_Enabled = 0;
         AssignProp("", false, edtProcesosACCDAGCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProcesosACCDAGCod_Enabled), 5, 0), true);
         edtACCDAGValor_Enabled = 0;
         AssignProp("", false, edtACCDAGValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACCDAGValor_Enabled), 5, 0), true);
         edtACCDAGUser_Enabled = 0;
         AssignProp("", false, edtACCDAGUser_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACCDAGUser_Enabled), 5, 0), true);
         edtACCDAGReg_Enabled = 0;
         AssignProp("", false, edtACCDAGReg_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACCDAGReg_Enabled), 5, 0), true);
         edtACCDAGHor_Enabled = 0;
         AssignProp("", false, edtACCDAGHor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACCDAGHor_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes078( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues070( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("accdag.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z18ACCDAG_Fecha", context.localUtil.DToC( Z18ACCDAG_Fecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z19ACCDAG_Mes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z19ACCDAG_Mes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z20ACCDAG_Ano", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z20ACCDAG_Ano), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z5Cod_Area", Z5Cod_Area);
         GxWebStd.gx_hidden_field( context, "Z4IndicadoresCodigo", Z4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "Z17ProcesosACCDAGCod", Z17ProcesosACCDAGCod);
         GxWebStd.gx_hidden_field( context, "Z130ACCDAGValor", StringUtil.LTrim( StringUtil.NToC( Z130ACCDAGValor, 10, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z209ACCDAGUser", Z209ACCDAGUser);
         GxWebStd.gx_hidden_field( context, "Z210ACCDAGReg", context.localUtil.DToC( Z210ACCDAGReg, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z211ACCDAGHor", Z211ACCDAGHor);
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
         return formatLink("accdag.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "ACCDAG" ;
      }

      public override string GetPgmdesc( )
      {
         return "ACCDAG" ;
      }

      protected void InitializeNonKey078( )
      {
         A130ACCDAGValor = 0;
         AssignAttri("", false, "A130ACCDAGValor", StringUtil.LTrimStr( A130ACCDAGValor, 10, 2));
         A209ACCDAGUser = "";
         AssignAttri("", false, "A209ACCDAGUser", A209ACCDAGUser);
         A210ACCDAGReg = DateTime.MinValue;
         AssignAttri("", false, "A210ACCDAGReg", context.localUtil.Format(A210ACCDAGReg, "99/99/99"));
         A211ACCDAGHor = "";
         AssignAttri("", false, "A211ACCDAGHor", A211ACCDAGHor);
         Z130ACCDAGValor = 0;
         Z209ACCDAGUser = "";
         Z210ACCDAGReg = DateTime.MinValue;
         Z211ACCDAGHor = "";
      }

      protected void InitAll078( )
      {
         A18ACCDAG_Fecha = DateTime.MinValue;
         AssignAttri("", false, "A18ACCDAG_Fecha", context.localUtil.Format(A18ACCDAG_Fecha, "99/99/99"));
         A19ACCDAG_Mes = 0;
         AssignAttri("", false, "A19ACCDAG_Mes", StringUtil.LTrimStr( (decimal)(A19ACCDAG_Mes), 4, 0));
         A20ACCDAG_Ano = 0;
         AssignAttri("", false, "A20ACCDAG_Ano", StringUtil.LTrimStr( (decimal)(A20ACCDAG_Ano), 4, 0));
         A5Cod_Area = "";
         AssignAttri("", false, "A5Cod_Area", A5Cod_Area);
         A4IndicadoresCodigo = "";
         AssignAttri("", false, "A4IndicadoresCodigo", A4IndicadoresCodigo);
         A17ProcesosACCDAGCod = "";
         AssignAttri("", false, "A17ProcesosACCDAGCod", A17ProcesosACCDAGCod);
         InitializeNonKey078( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024723102954", true, true);
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
         context.AddJavascriptSource("accdag.js", "?2024723102954", false, true);
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
         edtACCDAG_Fecha_Internalname = "ACCDAG_FECHA";
         edtACCDAG_Mes_Internalname = "ACCDAG_MES";
         edtACCDAG_Ano_Internalname = "ACCDAG_ANO";
         edtCod_Area_Internalname = "COD_AREA";
         edtIndicadoresCodigo_Internalname = "INDICADORESCODIGO";
         edtProcesosACCDAGCod_Internalname = "PROCESOSACCDAGCOD";
         edtACCDAGValor_Internalname = "ACCDAGVALOR";
         edtACCDAGUser_Internalname = "ACCDAGUSER";
         edtACCDAGReg_Internalname = "ACCDAGREG";
         edtACCDAGHor_Internalname = "ACCDAGHOR";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_5_Internalname = "PROMPT_5";
         imgprompt_4_Internalname = "PROMPT_4";
         imgprompt_17_Internalname = "PROMPT_17";
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
         Form.Caption = "ACCDAG";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtACCDAGHor_Jsonclick = "";
         edtACCDAGHor_Enabled = 1;
         edtACCDAGReg_Jsonclick = "";
         edtACCDAGReg_Enabled = 1;
         edtACCDAGUser_Jsonclick = "";
         edtACCDAGUser_Enabled = 1;
         edtACCDAGValor_Jsonclick = "";
         edtACCDAGValor_Enabled = 1;
         imgprompt_17_Visible = 1;
         imgprompt_17_Link = "";
         edtProcesosACCDAGCod_Jsonclick = "";
         edtProcesosACCDAGCod_Enabled = 1;
         imgprompt_4_Visible = 1;
         imgprompt_4_Link = "";
         edtIndicadoresCodigo_Jsonclick = "";
         edtIndicadoresCodigo_Enabled = 1;
         imgprompt_5_Visible = 1;
         imgprompt_5_Link = "";
         edtCod_Area_Jsonclick = "";
         edtCod_Area_Enabled = 1;
         edtACCDAG_Ano_Jsonclick = "";
         edtACCDAG_Ano_Enabled = 1;
         edtACCDAG_Mes_Jsonclick = "";
         edtACCDAG_Mes_Enabled = 1;
         edtACCDAG_Fecha_Jsonclick = "";
         edtACCDAG_Fecha_Enabled = 1;
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
         /* Using cursor T000718 */
         pr_default.execute(16, new Object[] {A5Cod_Area});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Areas'.", "ForeignKeyNotFound", 1, "COD_AREA");
            AnyError = 1;
            GX_FocusControl = edtCod_Area_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(16);
         /* Using cursor T000719 */
         pr_default.execute(17, new Object[] {A4IndicadoresCodigo});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No existe 'Indicadores'.", "ForeignKeyNotFound", 1, "INDICADORESCODIGO");
            AnyError = 1;
            GX_FocusControl = edtIndicadoresCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(17);
         /* Using cursor T000720 */
         pr_default.execute(18, new Object[] {A17ProcesosACCDAGCod});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'Procesos ACCDAG'.", "ForeignKeyNotFound", 1, "PROCESOSACCDAGCOD");
            AnyError = 1;
            GX_FocusControl = edtProcesosACCDAGCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(18);
         GX_FocusControl = edtACCDAGValor_Internalname;
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
         /* Using cursor T000718 */
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
         /* Using cursor T000719 */
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

      public void Valid_Procesosaccdagcod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T000720 */
         pr_default.execute(18, new Object[] {A17ProcesosACCDAGCod});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'Procesos ACCDAG'.", "ForeignKeyNotFound", 1, "PROCESOSACCDAGCOD");
            AnyError = 1;
            GX_FocusControl = edtProcesosACCDAGCod_Internalname;
         }
         pr_default.close(18);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A130ACCDAGValor", StringUtil.LTrim( StringUtil.NToC( A130ACCDAGValor, 10, 2, ".", "")));
         AssignAttri("", false, "A209ACCDAGUser", A209ACCDAGUser);
         AssignAttri("", false, "A210ACCDAGReg", context.localUtil.Format(A210ACCDAGReg, "99/99/99"));
         AssignAttri("", false, "A211ACCDAGHor", A211ACCDAGHor);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z18ACCDAG_Fecha", context.localUtil.Format(Z18ACCDAG_Fecha, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z19ACCDAG_Mes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z19ACCDAG_Mes), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z20ACCDAG_Ano", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z20ACCDAG_Ano), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z5Cod_Area", Z5Cod_Area);
         GxWebStd.gx_hidden_field( context, "Z4IndicadoresCodigo", Z4IndicadoresCodigo);
         GxWebStd.gx_hidden_field( context, "Z17ProcesosACCDAGCod", Z17ProcesosACCDAGCod);
         GxWebStd.gx_hidden_field( context, "Z130ACCDAGValor", StringUtil.LTrim( StringUtil.NToC( Z130ACCDAGValor, 10, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z209ACCDAGUser", Z209ACCDAGUser);
         GxWebStd.gx_hidden_field( context, "Z210ACCDAGReg", context.localUtil.Format(Z210ACCDAGReg, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z211ACCDAGHor", Z211ACCDAGHor);
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
         setEventMetadata("VALID_ACCDAG_FECHA","{handler:'Valid_Accdag_fecha',iparms:[]");
         setEventMetadata("VALID_ACCDAG_FECHA",",oparms:[]}");
         setEventMetadata("VALID_ACCDAG_MES","{handler:'Valid_Accdag_mes',iparms:[]");
         setEventMetadata("VALID_ACCDAG_MES",",oparms:[]}");
         setEventMetadata("VALID_ACCDAG_ANO","{handler:'Valid_Accdag_ano',iparms:[]");
         setEventMetadata("VALID_ACCDAG_ANO",",oparms:[]}");
         setEventMetadata("VALID_COD_AREA","{handler:'Valid_Cod_area',iparms:[{av:'A5Cod_Area',fld:'COD_AREA',pic:''}]");
         setEventMetadata("VALID_COD_AREA",",oparms:[]}");
         setEventMetadata("VALID_INDICADORESCODIGO","{handler:'Valid_Indicadorescodigo',iparms:[{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:''}]");
         setEventMetadata("VALID_INDICADORESCODIGO",",oparms:[]}");
         setEventMetadata("VALID_PROCESOSACCDAGCOD","{handler:'Valid_Procesosaccdagcod',iparms:[{av:'A18ACCDAG_Fecha',fld:'ACCDAG_FECHA',pic:''},{av:'A19ACCDAG_Mes',fld:'ACCDAG_MES',pic:'ZZZ9'},{av:'A20ACCDAG_Ano',fld:'ACCDAG_ANO',pic:'ZZZ9'},{av:'A5Cod_Area',fld:'COD_AREA',pic:''},{av:'A4IndicadoresCodigo',fld:'INDICADORESCODIGO',pic:''},{av:'A17ProcesosACCDAGCod',fld:'PROCESOSACCDAGCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_PROCESOSACCDAGCOD",",oparms:[{av:'A130ACCDAGValor',fld:'ACCDAGVALOR',pic:'ZZZZZZ9.99'},{av:'A209ACCDAGUser',fld:'ACCDAGUSER',pic:''},{av:'A210ACCDAGReg',fld:'ACCDAGREG',pic:''},{av:'A211ACCDAGHor',fld:'ACCDAGHOR',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z18ACCDAG_Fecha'},{av:'Z19ACCDAG_Mes'},{av:'Z20ACCDAG_Ano'},{av:'Z5Cod_Area'},{av:'Z4IndicadoresCodigo'},{av:'Z17ProcesosACCDAGCod'},{av:'Z130ACCDAGValor'},{av:'Z209ACCDAGUser'},{av:'Z210ACCDAGReg'},{av:'Z211ACCDAGHor'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_ACCDAGREG","{handler:'Valid_Accdagreg',iparms:[]");
         setEventMetadata("VALID_ACCDAGREG",",oparms:[]}");
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
         Z18ACCDAG_Fecha = DateTime.MinValue;
         Z5Cod_Area = "";
         Z4IndicadoresCodigo = "";
         Z17ProcesosACCDAGCod = "";
         Z209ACCDAGUser = "";
         Z210ACCDAGReg = DateTime.MinValue;
         Z211ACCDAGHor = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A5Cod_Area = "";
         A4IndicadoresCodigo = "";
         A17ProcesosACCDAGCod = "";
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
         A18ACCDAG_Fecha = DateTime.MinValue;
         imgprompt_5_gximage = "";
         sImgUrl = "";
         imgprompt_4_gximage = "";
         imgprompt_17_gximage = "";
         A209ACCDAGUser = "";
         A210ACCDAGReg = DateTime.MinValue;
         A211ACCDAGHor = "";
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
         T00077_A18ACCDAG_Fecha = new DateTime[] {DateTime.MinValue} ;
         T00077_A19ACCDAG_Mes = new short[1] ;
         T00077_A20ACCDAG_Ano = new short[1] ;
         T00077_A130ACCDAGValor = new decimal[1] ;
         T00077_A209ACCDAGUser = new string[] {""} ;
         T00077_A210ACCDAGReg = new DateTime[] {DateTime.MinValue} ;
         T00077_A211ACCDAGHor = new string[] {""} ;
         T00077_A5Cod_Area = new string[] {""} ;
         T00077_A4IndicadoresCodigo = new string[] {""} ;
         T00077_A17ProcesosACCDAGCod = new string[] {""} ;
         T00074_A5Cod_Area = new string[] {""} ;
         T00075_A4IndicadoresCodigo = new string[] {""} ;
         T00076_A17ProcesosACCDAGCod = new string[] {""} ;
         T00078_A5Cod_Area = new string[] {""} ;
         T00079_A4IndicadoresCodigo = new string[] {""} ;
         T000710_A17ProcesosACCDAGCod = new string[] {""} ;
         T000711_A18ACCDAG_Fecha = new DateTime[] {DateTime.MinValue} ;
         T000711_A19ACCDAG_Mes = new short[1] ;
         T000711_A20ACCDAG_Ano = new short[1] ;
         T000711_A5Cod_Area = new string[] {""} ;
         T000711_A4IndicadoresCodigo = new string[] {""} ;
         T000711_A17ProcesosACCDAGCod = new string[] {""} ;
         T00073_A18ACCDAG_Fecha = new DateTime[] {DateTime.MinValue} ;
         T00073_A19ACCDAG_Mes = new short[1] ;
         T00073_A20ACCDAG_Ano = new short[1] ;
         T00073_A130ACCDAGValor = new decimal[1] ;
         T00073_A209ACCDAGUser = new string[] {""} ;
         T00073_A210ACCDAGReg = new DateTime[] {DateTime.MinValue} ;
         T00073_A211ACCDAGHor = new string[] {""} ;
         T00073_A5Cod_Area = new string[] {""} ;
         T00073_A4IndicadoresCodigo = new string[] {""} ;
         T00073_A17ProcesosACCDAGCod = new string[] {""} ;
         sMode8 = "";
         T000712_A18ACCDAG_Fecha = new DateTime[] {DateTime.MinValue} ;
         T000712_A19ACCDAG_Mes = new short[1] ;
         T000712_A20ACCDAG_Ano = new short[1] ;
         T000712_A5Cod_Area = new string[] {""} ;
         T000712_A4IndicadoresCodigo = new string[] {""} ;
         T000712_A17ProcesosACCDAGCod = new string[] {""} ;
         T000713_A18ACCDAG_Fecha = new DateTime[] {DateTime.MinValue} ;
         T000713_A19ACCDAG_Mes = new short[1] ;
         T000713_A20ACCDAG_Ano = new short[1] ;
         T000713_A5Cod_Area = new string[] {""} ;
         T000713_A4IndicadoresCodigo = new string[] {""} ;
         T000713_A17ProcesosACCDAGCod = new string[] {""} ;
         T00072_A18ACCDAG_Fecha = new DateTime[] {DateTime.MinValue} ;
         T00072_A19ACCDAG_Mes = new short[1] ;
         T00072_A20ACCDAG_Ano = new short[1] ;
         T00072_A130ACCDAGValor = new decimal[1] ;
         T00072_A209ACCDAGUser = new string[] {""} ;
         T00072_A210ACCDAGReg = new DateTime[] {DateTime.MinValue} ;
         T00072_A211ACCDAGHor = new string[] {""} ;
         T00072_A5Cod_Area = new string[] {""} ;
         T00072_A4IndicadoresCodigo = new string[] {""} ;
         T00072_A17ProcesosACCDAGCod = new string[] {""} ;
         T000717_A18ACCDAG_Fecha = new DateTime[] {DateTime.MinValue} ;
         T000717_A19ACCDAG_Mes = new short[1] ;
         T000717_A20ACCDAG_Ano = new short[1] ;
         T000717_A5Cod_Area = new string[] {""} ;
         T000717_A4IndicadoresCodigo = new string[] {""} ;
         T000717_A17ProcesosACCDAGCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T000718_A5Cod_Area = new string[] {""} ;
         T000719_A4IndicadoresCodigo = new string[] {""} ;
         T000720_A17ProcesosACCDAGCod = new string[] {""} ;
         ZZ18ACCDAG_Fecha = DateTime.MinValue;
         ZZ5Cod_Area = "";
         ZZ4IndicadoresCodigo = "";
         ZZ17ProcesosACCDAGCod = "";
         ZZ209ACCDAGUser = "";
         ZZ210ACCDAGReg = DateTime.MinValue;
         ZZ211ACCDAGHor = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.accdag__default(),
            new Object[][] {
                new Object[] {
               T00072_A18ACCDAG_Fecha, T00072_A19ACCDAG_Mes, T00072_A20ACCDAG_Ano, T00072_A130ACCDAGValor, T00072_A209ACCDAGUser, T00072_A210ACCDAGReg, T00072_A211ACCDAGHor, T00072_A5Cod_Area, T00072_A4IndicadoresCodigo, T00072_A17ProcesosACCDAGCod
               }
               , new Object[] {
               T00073_A18ACCDAG_Fecha, T00073_A19ACCDAG_Mes, T00073_A20ACCDAG_Ano, T00073_A130ACCDAGValor, T00073_A209ACCDAGUser, T00073_A210ACCDAGReg, T00073_A211ACCDAGHor, T00073_A5Cod_Area, T00073_A4IndicadoresCodigo, T00073_A17ProcesosACCDAGCod
               }
               , new Object[] {
               T00074_A5Cod_Area
               }
               , new Object[] {
               T00075_A4IndicadoresCodigo
               }
               , new Object[] {
               T00076_A17ProcesosACCDAGCod
               }
               , new Object[] {
               T00077_A18ACCDAG_Fecha, T00077_A19ACCDAG_Mes, T00077_A20ACCDAG_Ano, T00077_A130ACCDAGValor, T00077_A209ACCDAGUser, T00077_A210ACCDAGReg, T00077_A211ACCDAGHor, T00077_A5Cod_Area, T00077_A4IndicadoresCodigo, T00077_A17ProcesosACCDAGCod
               }
               , new Object[] {
               T00078_A5Cod_Area
               }
               , new Object[] {
               T00079_A4IndicadoresCodigo
               }
               , new Object[] {
               T000710_A17ProcesosACCDAGCod
               }
               , new Object[] {
               T000711_A18ACCDAG_Fecha, T000711_A19ACCDAG_Mes, T000711_A20ACCDAG_Ano, T000711_A5Cod_Area, T000711_A4IndicadoresCodigo, T000711_A17ProcesosACCDAGCod
               }
               , new Object[] {
               T000712_A18ACCDAG_Fecha, T000712_A19ACCDAG_Mes, T000712_A20ACCDAG_Ano, T000712_A5Cod_Area, T000712_A4IndicadoresCodigo, T000712_A17ProcesosACCDAGCod
               }
               , new Object[] {
               T000713_A18ACCDAG_Fecha, T000713_A19ACCDAG_Mes, T000713_A20ACCDAG_Ano, T000713_A5Cod_Area, T000713_A4IndicadoresCodigo, T000713_A17ProcesosACCDAGCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000717_A18ACCDAG_Fecha, T000717_A19ACCDAG_Mes, T000717_A20ACCDAG_Ano, T000717_A5Cod_Area, T000717_A4IndicadoresCodigo, T000717_A17ProcesosACCDAGCod
               }
               , new Object[] {
               T000718_A5Cod_Area
               }
               , new Object[] {
               T000719_A4IndicadoresCodigo
               }
               , new Object[] {
               T000720_A17ProcesosACCDAGCod
               }
            }
         );
      }

      private short Z19ACCDAG_Mes ;
      private short Z20ACCDAG_Ano ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A19ACCDAG_Mes ;
      private short A20ACCDAG_Ano ;
      private short GX_JID ;
      private short RcdFound8 ;
      private short nIsDirty_8 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ19ACCDAG_Mes ;
      private short ZZ20ACCDAG_Ano ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtACCDAG_Fecha_Enabled ;
      private int edtACCDAG_Mes_Enabled ;
      private int edtACCDAG_Ano_Enabled ;
      private int edtCod_Area_Enabled ;
      private int imgprompt_5_Visible ;
      private int edtIndicadoresCodigo_Enabled ;
      private int imgprompt_4_Visible ;
      private int edtProcesosACCDAGCod_Enabled ;
      private int imgprompt_17_Visible ;
      private int edtACCDAGValor_Enabled ;
      private int edtACCDAGUser_Enabled ;
      private int edtACCDAGReg_Enabled ;
      private int edtACCDAGHor_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private decimal Z130ACCDAGValor ;
      private decimal A130ACCDAGValor ;
      private decimal ZZ130ACCDAGValor ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtACCDAG_Fecha_Internalname ;
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
      private string edtACCDAG_Fecha_Jsonclick ;
      private string edtACCDAG_Mes_Internalname ;
      private string edtACCDAG_Mes_Jsonclick ;
      private string edtACCDAG_Ano_Internalname ;
      private string edtACCDAG_Ano_Jsonclick ;
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
      private string edtProcesosACCDAGCod_Internalname ;
      private string edtProcesosACCDAGCod_Jsonclick ;
      private string imgprompt_17_gximage ;
      private string imgprompt_17_Internalname ;
      private string imgprompt_17_Link ;
      private string edtACCDAGValor_Internalname ;
      private string edtACCDAGValor_Jsonclick ;
      private string edtACCDAGUser_Internalname ;
      private string edtACCDAGUser_Jsonclick ;
      private string edtACCDAGReg_Internalname ;
      private string edtACCDAGReg_Jsonclick ;
      private string edtACCDAGHor_Internalname ;
      private string edtACCDAGHor_Jsonclick ;
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
      private string sMode8 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z18ACCDAG_Fecha ;
      private DateTime Z210ACCDAGReg ;
      private DateTime A18ACCDAG_Fecha ;
      private DateTime A210ACCDAGReg ;
      private DateTime ZZ18ACCDAG_Fecha ;
      private DateTime ZZ210ACCDAGReg ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string Z5Cod_Area ;
      private string Z4IndicadoresCodigo ;
      private string Z17ProcesosACCDAGCod ;
      private string Z209ACCDAGUser ;
      private string Z211ACCDAGHor ;
      private string A5Cod_Area ;
      private string A4IndicadoresCodigo ;
      private string A17ProcesosACCDAGCod ;
      private string A209ACCDAGUser ;
      private string A211ACCDAGHor ;
      private string ZZ5Cod_Area ;
      private string ZZ4IndicadoresCodigo ;
      private string ZZ17ProcesosACCDAGCod ;
      private string ZZ209ACCDAGUser ;
      private string ZZ211ACCDAGHor ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] T00077_A18ACCDAG_Fecha ;
      private short[] T00077_A19ACCDAG_Mes ;
      private short[] T00077_A20ACCDAG_Ano ;
      private decimal[] T00077_A130ACCDAGValor ;
      private string[] T00077_A209ACCDAGUser ;
      private DateTime[] T00077_A210ACCDAGReg ;
      private string[] T00077_A211ACCDAGHor ;
      private string[] T00077_A5Cod_Area ;
      private string[] T00077_A4IndicadoresCodigo ;
      private string[] T00077_A17ProcesosACCDAGCod ;
      private string[] T00074_A5Cod_Area ;
      private string[] T00075_A4IndicadoresCodigo ;
      private string[] T00076_A17ProcesosACCDAGCod ;
      private string[] T00078_A5Cod_Area ;
      private string[] T00079_A4IndicadoresCodigo ;
      private string[] T000710_A17ProcesosACCDAGCod ;
      private DateTime[] T000711_A18ACCDAG_Fecha ;
      private short[] T000711_A19ACCDAG_Mes ;
      private short[] T000711_A20ACCDAG_Ano ;
      private string[] T000711_A5Cod_Area ;
      private string[] T000711_A4IndicadoresCodigo ;
      private string[] T000711_A17ProcesosACCDAGCod ;
      private DateTime[] T00073_A18ACCDAG_Fecha ;
      private short[] T00073_A19ACCDAG_Mes ;
      private short[] T00073_A20ACCDAG_Ano ;
      private decimal[] T00073_A130ACCDAGValor ;
      private string[] T00073_A209ACCDAGUser ;
      private DateTime[] T00073_A210ACCDAGReg ;
      private string[] T00073_A211ACCDAGHor ;
      private string[] T00073_A5Cod_Area ;
      private string[] T00073_A4IndicadoresCodigo ;
      private string[] T00073_A17ProcesosACCDAGCod ;
      private DateTime[] T000712_A18ACCDAG_Fecha ;
      private short[] T000712_A19ACCDAG_Mes ;
      private short[] T000712_A20ACCDAG_Ano ;
      private string[] T000712_A5Cod_Area ;
      private string[] T000712_A4IndicadoresCodigo ;
      private string[] T000712_A17ProcesosACCDAGCod ;
      private DateTime[] T000713_A18ACCDAG_Fecha ;
      private short[] T000713_A19ACCDAG_Mes ;
      private short[] T000713_A20ACCDAG_Ano ;
      private string[] T000713_A5Cod_Area ;
      private string[] T000713_A4IndicadoresCodigo ;
      private string[] T000713_A17ProcesosACCDAGCod ;
      private DateTime[] T00072_A18ACCDAG_Fecha ;
      private short[] T00072_A19ACCDAG_Mes ;
      private short[] T00072_A20ACCDAG_Ano ;
      private decimal[] T00072_A130ACCDAGValor ;
      private string[] T00072_A209ACCDAGUser ;
      private DateTime[] T00072_A210ACCDAGReg ;
      private string[] T00072_A211ACCDAGHor ;
      private string[] T00072_A5Cod_Area ;
      private string[] T00072_A4IndicadoresCodigo ;
      private string[] T00072_A17ProcesosACCDAGCod ;
      private DateTime[] T000717_A18ACCDAG_Fecha ;
      private short[] T000717_A19ACCDAG_Mes ;
      private short[] T000717_A20ACCDAG_Ano ;
      private string[] T000717_A5Cod_Area ;
      private string[] T000717_A4IndicadoresCodigo ;
      private string[] T000717_A17ProcesosACCDAGCod ;
      private string[] T000718_A5Cod_Area ;
      private string[] T000719_A4IndicadoresCodigo ;
      private string[] T000720_A17ProcesosACCDAGCod ;
      private GXWebForm Form ;
   }

   public class accdag__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT00077;
          prmT00077 = new Object[] {
          new ParDef("@ACCDAG_Fecha",GXType.Date,8,0) ,
          new ParDef("@ACCDAG_Mes",GXType.Int16,4,0) ,
          new ParDef("@ACCDAG_Ano",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@ProcesosACCDAGCod",GXType.NVarChar,40,0)
          };
          Object[] prmT00074;
          prmT00074 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT00075;
          prmT00075 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT00076;
          prmT00076 = new Object[] {
          new ParDef("@ProcesosACCDAGCod",GXType.NVarChar,40,0)
          };
          Object[] prmT00078;
          prmT00078 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT00079;
          prmT00079 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000710;
          prmT000710 = new Object[] {
          new ParDef("@ProcesosACCDAGCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000711;
          prmT000711 = new Object[] {
          new ParDef("@ACCDAG_Fecha",GXType.Date,8,0) ,
          new ParDef("@ACCDAG_Mes",GXType.Int16,4,0) ,
          new ParDef("@ACCDAG_Ano",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@ProcesosACCDAGCod",GXType.NVarChar,40,0)
          };
          Object[] prmT00073;
          prmT00073 = new Object[] {
          new ParDef("@ACCDAG_Fecha",GXType.Date,8,0) ,
          new ParDef("@ACCDAG_Mes",GXType.Int16,4,0) ,
          new ParDef("@ACCDAG_Ano",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@ProcesosACCDAGCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000712;
          prmT000712 = new Object[] {
          new ParDef("@ACCDAG_Fecha",GXType.Date,8,0) ,
          new ParDef("@ACCDAG_Mes",GXType.Int16,4,0) ,
          new ParDef("@ACCDAG_Ano",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@ProcesosACCDAGCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000713;
          prmT000713 = new Object[] {
          new ParDef("@ACCDAG_Fecha",GXType.Date,8,0) ,
          new ParDef("@ACCDAG_Mes",GXType.Int16,4,0) ,
          new ParDef("@ACCDAG_Ano",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@ProcesosACCDAGCod",GXType.NVarChar,40,0)
          };
          Object[] prmT00072;
          prmT00072 = new Object[] {
          new ParDef("@ACCDAG_Fecha",GXType.Date,8,0) ,
          new ParDef("@ACCDAG_Mes",GXType.Int16,4,0) ,
          new ParDef("@ACCDAG_Ano",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@ProcesosACCDAGCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000714;
          prmT000714 = new Object[] {
          new ParDef("@ACCDAG_Fecha",GXType.Date,8,0) ,
          new ParDef("@ACCDAG_Mes",GXType.Int16,4,0) ,
          new ParDef("@ACCDAG_Ano",GXType.Int16,4,0) ,
          new ParDef("@ACCDAGValor",GXType.Decimal,10,2) ,
          new ParDef("@ACCDAGUser",GXType.NVarChar,150,0) ,
          new ParDef("@ACCDAGReg",GXType.Date,8,0) ,
          new ParDef("@ACCDAGHor",GXType.NVarChar,40,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@ProcesosACCDAGCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000715;
          prmT000715 = new Object[] {
          new ParDef("@ACCDAGValor",GXType.Decimal,10,2) ,
          new ParDef("@ACCDAGUser",GXType.NVarChar,150,0) ,
          new ParDef("@ACCDAGReg",GXType.Date,8,0) ,
          new ParDef("@ACCDAGHor",GXType.NVarChar,40,0) ,
          new ParDef("@ACCDAG_Fecha",GXType.Date,8,0) ,
          new ParDef("@ACCDAG_Mes",GXType.Int16,4,0) ,
          new ParDef("@ACCDAG_Ano",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@ProcesosACCDAGCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000716;
          prmT000716 = new Object[] {
          new ParDef("@ACCDAG_Fecha",GXType.Date,8,0) ,
          new ParDef("@ACCDAG_Mes",GXType.Int16,4,0) ,
          new ParDef("@ACCDAG_Ano",GXType.Int16,4,0) ,
          new ParDef("@Cod_Area",GXType.NVarChar,40,0) ,
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0) ,
          new ParDef("@ProcesosACCDAGCod",GXType.NVarChar,40,0)
          };
          Object[] prmT000717;
          prmT000717 = new Object[] {
          };
          Object[] prmT000718;
          prmT000718 = new Object[] {
          new ParDef("@Cod_Area",GXType.NVarChar,40,0)
          };
          Object[] prmT000719;
          prmT000719 = new Object[] {
          new ParDef("@IndicadoresCodigo",GXType.NVarChar,40,0)
          };
          Object[] prmT000720;
          prmT000720 = new Object[] {
          new ParDef("@ProcesosACCDAGCod",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00072", "SELECT [ACCDAG_Fecha], [ACCDAG_Mes], [ACCDAG_Ano], [ACCDAGValor], [ACCDAGUser], [ACCDAGReg], [ACCDAGHor], [Cod_Area], [IndicadoresCodigo], [ProcesosACCDAGCod] FROM [ACCDAG] WITH (UPDLOCK) WHERE [ACCDAG_Fecha] = @ACCDAG_Fecha AND [ACCDAG_Mes] = @ACCDAG_Mes AND [ACCDAG_Ano] = @ACCDAG_Ano AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo AND [ProcesosACCDAGCod] = @ProcesosACCDAGCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00072,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00073", "SELECT [ACCDAG_Fecha], [ACCDAG_Mes], [ACCDAG_Ano], [ACCDAGValor], [ACCDAGUser], [ACCDAGReg], [ACCDAGHor], [Cod_Area], [IndicadoresCodigo], [ProcesosACCDAGCod] FROM [ACCDAG] WHERE [ACCDAG_Fecha] = @ACCDAG_Fecha AND [ACCDAG_Mes] = @ACCDAG_Mes AND [ACCDAG_Ano] = @ACCDAG_Ano AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo AND [ProcesosACCDAGCod] = @ProcesosACCDAGCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00073,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00074", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT00074,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00075", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT00075,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00076", "SELECT [ProcesosACCDAGCod] FROM [ProcesosACCDAG] WHERE [ProcesosACCDAGCod] = @ProcesosACCDAGCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00076,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00077", "SELECT TM1.[ACCDAG_Fecha], TM1.[ACCDAG_Mes], TM1.[ACCDAG_Ano], TM1.[ACCDAGValor], TM1.[ACCDAGUser], TM1.[ACCDAGReg], TM1.[ACCDAGHor], TM1.[Cod_Area], TM1.[IndicadoresCodigo], TM1.[ProcesosACCDAGCod] FROM [ACCDAG] TM1 WHERE TM1.[ACCDAG_Fecha] = @ACCDAG_Fecha and TM1.[ACCDAG_Mes] = @ACCDAG_Mes and TM1.[ACCDAG_Ano] = @ACCDAG_Ano and TM1.[Cod_Area] = @Cod_Area and TM1.[IndicadoresCodigo] = @IndicadoresCodigo and TM1.[ProcesosACCDAGCod] = @ProcesosACCDAGCod ORDER BY TM1.[ACCDAG_Fecha], TM1.[ACCDAG_Mes], TM1.[ACCDAG_Ano], TM1.[Cod_Area], TM1.[IndicadoresCodigo], TM1.[ProcesosACCDAGCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00077,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00078", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT00078,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00079", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT00079,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000710", "SELECT [ProcesosACCDAGCod] FROM [ProcesosACCDAG] WHERE [ProcesosACCDAGCod] = @ProcesosACCDAGCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000710,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000711", "SELECT [ACCDAG_Fecha], [ACCDAG_Mes], [ACCDAG_Ano], [Cod_Area], [IndicadoresCodigo], [ProcesosACCDAGCod] FROM [ACCDAG] WHERE [ACCDAG_Fecha] = @ACCDAG_Fecha AND [ACCDAG_Mes] = @ACCDAG_Mes AND [ACCDAG_Ano] = @ACCDAG_Ano AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo AND [ProcesosACCDAGCod] = @ProcesosACCDAGCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000711,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000712", "SELECT TOP 1 [ACCDAG_Fecha], [ACCDAG_Mes], [ACCDAG_Ano], [Cod_Area], [IndicadoresCodigo], [ProcesosACCDAGCod] FROM [ACCDAG] WHERE ( [ACCDAG_Fecha] > @ACCDAG_Fecha or [ACCDAG_Fecha] = @ACCDAG_Fecha and [ACCDAG_Mes] > @ACCDAG_Mes or [ACCDAG_Mes] = @ACCDAG_Mes and [ACCDAG_Fecha] = @ACCDAG_Fecha and [ACCDAG_Ano] > @ACCDAG_Ano or [ACCDAG_Ano] = @ACCDAG_Ano and [ACCDAG_Mes] = @ACCDAG_Mes and [ACCDAG_Fecha] = @ACCDAG_Fecha and [Cod_Area] > @Cod_Area or [Cod_Area] = @Cod_Area and [ACCDAG_Ano] = @ACCDAG_Ano and [ACCDAG_Mes] = @ACCDAG_Mes and [ACCDAG_Fecha] = @ACCDAG_Fecha and [IndicadoresCodigo] > @IndicadoresCodigo or [IndicadoresCodigo] = @IndicadoresCodigo and [Cod_Area] = @Cod_Area and [ACCDAG_Ano] = @ACCDAG_Ano and [ACCDAG_Mes] = @ACCDAG_Mes and [ACCDAG_Fecha] = @ACCDAG_Fecha and [ProcesosACCDAGCod] > @ProcesosACCDAGCod) ORDER BY [ACCDAG_Fecha], [ACCDAG_Mes], [ACCDAG_Ano], [Cod_Area], [IndicadoresCodigo], [ProcesosACCDAGCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000712,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000713", "SELECT TOP 1 [ACCDAG_Fecha], [ACCDAG_Mes], [ACCDAG_Ano], [Cod_Area], [IndicadoresCodigo], [ProcesosACCDAGCod] FROM [ACCDAG] WHERE ( [ACCDAG_Fecha] < @ACCDAG_Fecha or [ACCDAG_Fecha] = @ACCDAG_Fecha and [ACCDAG_Mes] < @ACCDAG_Mes or [ACCDAG_Mes] = @ACCDAG_Mes and [ACCDAG_Fecha] = @ACCDAG_Fecha and [ACCDAG_Ano] < @ACCDAG_Ano or [ACCDAG_Ano] = @ACCDAG_Ano and [ACCDAG_Mes] = @ACCDAG_Mes and [ACCDAG_Fecha] = @ACCDAG_Fecha and [Cod_Area] < @Cod_Area or [Cod_Area] = @Cod_Area and [ACCDAG_Ano] = @ACCDAG_Ano and [ACCDAG_Mes] = @ACCDAG_Mes and [ACCDAG_Fecha] = @ACCDAG_Fecha and [IndicadoresCodigo] < @IndicadoresCodigo or [IndicadoresCodigo] = @IndicadoresCodigo and [Cod_Area] = @Cod_Area and [ACCDAG_Ano] = @ACCDAG_Ano and [ACCDAG_Mes] = @ACCDAG_Mes and [ACCDAG_Fecha] = @ACCDAG_Fecha and [ProcesosACCDAGCod] < @ProcesosACCDAGCod) ORDER BY [ACCDAG_Fecha] DESC, [ACCDAG_Mes] DESC, [ACCDAG_Ano] DESC, [Cod_Area] DESC, [IndicadoresCodigo] DESC, [ProcesosACCDAGCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000713,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000714", "INSERT INTO [ACCDAG]([ACCDAG_Fecha], [ACCDAG_Mes], [ACCDAG_Ano], [ACCDAGValor], [ACCDAGUser], [ACCDAGReg], [ACCDAGHor], [Cod_Area], [IndicadoresCodigo], [ProcesosACCDAGCod]) VALUES(@ACCDAG_Fecha, @ACCDAG_Mes, @ACCDAG_Ano, @ACCDAGValor, @ACCDAGUser, @ACCDAGReg, @ACCDAGHor, @Cod_Area, @IndicadoresCodigo, @ProcesosACCDAGCod)", GxErrorMask.GX_NOMASK,prmT000714)
             ,new CursorDef("T000715", "UPDATE [ACCDAG] SET [ACCDAGValor]=@ACCDAGValor, [ACCDAGUser]=@ACCDAGUser, [ACCDAGReg]=@ACCDAGReg, [ACCDAGHor]=@ACCDAGHor  WHERE [ACCDAG_Fecha] = @ACCDAG_Fecha AND [ACCDAG_Mes] = @ACCDAG_Mes AND [ACCDAG_Ano] = @ACCDAG_Ano AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo AND [ProcesosACCDAGCod] = @ProcesosACCDAGCod", GxErrorMask.GX_NOMASK,prmT000715)
             ,new CursorDef("T000716", "DELETE FROM [ACCDAG]  WHERE [ACCDAG_Fecha] = @ACCDAG_Fecha AND [ACCDAG_Mes] = @ACCDAG_Mes AND [ACCDAG_Ano] = @ACCDAG_Ano AND [Cod_Area] = @Cod_Area AND [IndicadoresCodigo] = @IndicadoresCodigo AND [ProcesosACCDAGCod] = @ProcesosACCDAGCod", GxErrorMask.GX_NOMASK,prmT000716)
             ,new CursorDef("T000717", "SELECT [ACCDAG_Fecha], [ACCDAG_Mes], [ACCDAG_Ano], [Cod_Area], [IndicadoresCodigo], [ProcesosACCDAGCod] FROM [ACCDAG] ORDER BY [ACCDAG_Fecha], [ACCDAG_Mes], [ACCDAG_Ano], [Cod_Area], [IndicadoresCodigo], [ProcesosACCDAGCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000717,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000718", "SELECT [Cod_Area] FROM [Areas] WHERE [Cod_Area] = @Cod_Area ",true, GxErrorMask.GX_NOMASK, false, this,prmT000718,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000719", "SELECT [IndicadoresCodigo] FROM [Indicadores] WHERE [IndicadoresCodigo] = @IndicadoresCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000719,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000720", "SELECT [ProcesosACCDAGCod] FROM [ProcesosACCDAG] WHERE [ProcesosACCDAGCod] = @ProcesosACCDAGCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000720,1, GxCacheFrequency.OFF ,true,false )
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
