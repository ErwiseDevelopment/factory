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
   public class wptransferirsaldo : GXDataArea
   {
      public wptransferirsaldo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wptransferirsaldo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
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
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpage", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpage", new Object[] {context});
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
         cleanup();
      }

      public override short ExecuteStartEvent( )
      {
         PA662( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START662( ) ;
         }
         return gxajaxcallmode ;
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
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
         CloseStyles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 133260), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 133260), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 133260), false, true);
         context.AddJavascriptSource("gxcfg.js", "?"+GetCacheInvalidationToken( ), false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
         {
            context.WriteHtmlText( " dir=\"rtl\" ") ;
         }
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wptransferirsaldo") +"\">") ;
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
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCONTAID_DATA", AV8ContaId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCONTAID_DATA", AV8ContaId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDCONTAID_DATA", AV10DContaId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDCONTAID_DATA", AV10DContaId_Data);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vCHECKREQUIREDFIELDSRESULT", AV11CheckRequiredFieldsResult);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDERRO", AV20SdErro);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDERRO", AV20SdErro);
         }
         GxWebStd.gx_hidden_field( context, "vTITULOMOVIMENTOVALOR", StringUtil.LTrim( StringUtil.NToC( AV17TituloMovimentoValor, 18, 2, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTITULOMOVIMENTO", AV16SdTituloMovimento);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTITULOMOVIMENTO", AV16SdTituloMovimento);
         }
         GxWebStd.gx_hidden_field( context, "vTITULOMOVIMENTOOPE", AV18TituloMovimentoOpe);
         GxWebStd.gx_hidden_field( context, "vAUXCONTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19AuxContaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "COMBO_CONTAID_Cls", StringUtil.RTrim( Combo_contaid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_CONTAID_Selectedvalue_set", StringUtil.RTrim( Combo_contaid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CONTAID_Emptyitem", StringUtil.BoolToStr( Combo_contaid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_CONTAID_Htmltemplate", StringUtil.RTrim( Combo_contaid_Htmltemplate));
         GxWebStd.gx_hidden_field( context, "COMBO_DCONTAID_Cls", StringUtil.RTrim( Combo_dcontaid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_DCONTAID_Selectedvalue_set", StringUtil.RTrim( Combo_dcontaid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_DCONTAID_Emptyitem", StringUtil.BoolToStr( Combo_dcontaid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_CONTAID_Ddointernalname", StringUtil.RTrim( Combo_contaid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, "COMBO_DCONTAID_Ddointernalname", StringUtil.RTrim( Combo_dcontaid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, "COMBO_DCONTAID_Selectedvalue_get", StringUtil.RTrim( Combo_dcontaid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_CONTAID_Selectedvalue_get", StringUtil.RTrim( Combo_contaid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_CONTAID_Ddointernalname", StringUtil.RTrim( Combo_contaid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, "COMBO_DCONTAID_Ddointernalname", StringUtil.RTrim( Combo_dcontaid_Ddointernalname));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
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

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE662( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT662( ) ;
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
         return formatLink("wptransferirsaldo")  ;
      }

      public override string GetPgmname( )
      {
         return "WpTransferirSaldo" ;
      }

      public override string GetPgmdesc( )
      {
         return "Transferir saldo" ;
      }

      protected void WB660( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", divTablecontent_Height, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 15,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", "Confirmar", bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpTransferirSaldo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedcontaid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_contaid_Internalname, "Conta Origem", "", "", lblTextblockcombo_contaid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WpTransferirSaldo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_contaid.SetProperty("Caption", Combo_contaid_Caption);
            ucCombo_contaid.SetProperty("Cls", Combo_contaid_Cls);
            ucCombo_contaid.SetProperty("EmptyItem", Combo_contaid_Emptyitem);
            ucCombo_contaid.SetProperty("DropDownOptionsData", AV8ContaId_Data);
            ucCombo_contaid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_contaid_Internalname, "COMBO_CONTAIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplitteddcontaid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_dcontaid_Internalname, "Conta destino", "", "", lblTextblockcombo_dcontaid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WpTransferirSaldo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_dcontaid.SetProperty("Caption", Combo_dcontaid_Caption);
            ucCombo_dcontaid.SetProperty("Cls", Combo_dcontaid_Cls);
            ucCombo_dcontaid.SetProperty("EmptyItem", Combo_dcontaid_Emptyitem);
            ucCombo_dcontaid.SetProperty("DropDownOptionsData", AV10DContaId_Data);
            ucCombo_dcontaid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_dcontaid_Internalname, "COMBO_DCONTAIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavValor_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavValor_Internalname, "Valor", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavValor_Internalname, StringUtil.LTrim( StringUtil.NToC( AV7Valor, 18, 2, ",", "")), StringUtil.LTrim( ((edtavValor_Enabled!=0) ? context.localUtil.Format( AV7Valor, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV7Valor, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavValor_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavValor_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Valor", "end", false, "", "HLP_WpTransferirSaldo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContaid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5ContaId), 9, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV5ContaId), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContaid_Jsonclick, 0, "Attribute", "", "", "", "", edtavContaid_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpTransferirSaldo.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDcontaid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6DContaId), 9, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV6DContaId), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDcontaid_Jsonclick, 0, "Attribute", "", "", "", "", edtavDcontaid_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpTransferirSaldo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START662( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_12-186073", 0) ;
            }
         }
         Form.Meta.addItem("description", "Transferir saldo", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP660( ) ;
      }

      protected void WS662( )
      {
         START662( ) ;
         EVT662( ) ;
      }

      protected void EVT662( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
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
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E11662 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                    /* Execute user event: Enter */
                                    E12662 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E13662 ();
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
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
      }

      protected void WE662( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA662( )
      {
         if ( nDonePA == 0 )
         {
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
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavValor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF662( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF662( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E13662 ();
            WB660( ) ;
         }
      }

      protected void send_integrity_lvl_hashes662( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP660( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11662 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vCONTAID_DATA"), AV8ContaId_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vDCONTAID_DATA"), AV10DContaId_Data);
            /* Read saved values. */
            Combo_contaid_Cls = cgiGet( "COMBO_CONTAID_Cls");
            Combo_contaid_Selectedvalue_set = cgiGet( "COMBO_CONTAID_Selectedvalue_set");
            Combo_contaid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_CONTAID_Emptyitem"));
            Combo_contaid_Htmltemplate = cgiGet( "COMBO_CONTAID_Htmltemplate");
            Combo_dcontaid_Cls = cgiGet( "COMBO_DCONTAID_Cls");
            Combo_dcontaid_Selectedvalue_set = cgiGet( "COMBO_DCONTAID_Selectedvalue_set");
            Combo_dcontaid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_DCONTAID_Emptyitem"));
            Combo_contaid_Ddointernalname = cgiGet( "COMBO_CONTAID_Ddointernalname");
            Combo_dcontaid_Ddointernalname = cgiGet( "COMBO_DCONTAID_Ddointernalname");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavValor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavValor_Internalname), ",", ".") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vVALOR");
               GX_FocusControl = edtavValor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7Valor = 0;
               AssignAttri("", false, "AV7Valor", StringUtil.LTrimStr( AV7Valor, 18, 2));
            }
            else
            {
               AV7Valor = context.localUtil.CToN( cgiGet( edtavValor_Internalname), ",", ".");
               AssignAttri("", false, "AV7Valor", StringUtil.LTrimStr( AV7Valor, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavContaid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavContaid_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCONTAID");
               GX_FocusControl = edtavContaid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5ContaId = 0;
               AssignAttri("", false, "AV5ContaId", StringUtil.LTrimStr( (decimal)(AV5ContaId), 9, 0));
            }
            else
            {
               AV5ContaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavContaid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV5ContaId", StringUtil.LTrimStr( (decimal)(AV5ContaId), 9, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavDcontaid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavDcontaid_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vDCONTAID");
               GX_FocusControl = edtavDcontaid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6DContaId = 0;
               AssignAttri("", false, "AV6DContaId", StringUtil.LTrimStr( (decimal)(AV6DContaId), 9, 0));
            }
            else
            {
               AV6DContaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavDcontaid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6DContaId", StringUtil.LTrimStr( (decimal)(AV6DContaId), 9, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E11662 ();
         if (returnInSub) return;
      }

      protected void E11662( )
      {
         /* Start Routine */
         returnInSub = false;
         divTablecontent_Height = 400;
         AssignProp("", false, divTablecontent_Internalname, "Height", StringUtil.LTrimStr( (decimal)(divTablecontent_Height), 9, 0), true);
         edtavDcontaid_Visible = 0;
         AssignProp("", false, edtavDcontaid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDcontaid_Visible), 5, 0), true);
         edtavContaid_Visible = 0;
         AssignProp("", false, edtavContaid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavContaid_Visible), 5, 0), true);
         GXt_char1 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and subtitle", out  GXt_char1) ;
         Combo_contaid_Htmltemplate = GXt_char1;
         ucCombo_contaid.SendProperty(context, "", false, Combo_contaid_Internalname, "HTMLTemplate", Combo_contaid_Htmltemplate);
         /* Execute user subroutine: 'LOADCOMBOCONTAID' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBODCONTAID' */
         S122 ();
         if (returnInSub) return;
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E12662 ();
         if (returnInSub) return;
      }

      protected void E12662( )
      {
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S132 ();
         if (returnInSub) return;
         if ( AV11CheckRequiredFieldsResult )
         {
            AV14Conta.Load(AV5ContaId);
            if ( AV14Conta.gxTpr_Contasaldoatual < AV7Valor )
            {
               GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Valor deve ser menor ou igual ao saldo",  "error",  edtavValor_Internalname,  "true",  ""));
            }
            else
            {
               AV14Conta.gxTpr_Contasaldoatual = (decimal)(AV14Conta.gxTpr_Contasaldoatual-AV7Valor);
               AV14Conta.Save();
               if ( AV14Conta.Success() )
               {
                  AV15AuxConta.Load(AV6DContaId);
                  AV15AuxConta.gxTpr_Contasaldoatual = (decimal)(AV15AuxConta.gxTpr_Contasaldoatual+AV7Valor);
                  AV15AuxConta.Save();
                  if ( AV15AuxConta.Success() )
                  {
                     AV17TituloMovimentoValor = AV7Valor;
                     AssignAttri("", false, "AV17TituloMovimentoValor", StringUtil.LTrimStr( AV17TituloMovimentoValor, 18, 2));
                     AV19AuxContaId = AV5ContaId;
                     AssignAttri("", false, "AV19AuxContaId", StringUtil.LTrimStr( (decimal)(AV19AuxContaId), 9, 0));
                     AV18TituloMovimentoOpe = "Saida";
                     AssignAttri("", false, "AV18TituloMovimentoOpe", AV18TituloMovimentoOpe);
                     /* Execute user subroutine: 'MOVIMENTO' */
                     S142 ();
                     if (returnInSub) return;
                     if ( AV20SdErro.gxTpr_Status == 200 )
                     {
                        AV19AuxContaId = AV6DContaId;
                        AssignAttri("", false, "AV19AuxContaId", StringUtil.LTrimStr( (decimal)(AV19AuxContaId), 9, 0));
                        AV18TituloMovimentoOpe = "Entrada";
                        AssignAttri("", false, "AV18TituloMovimentoOpe", AV18TituloMovimentoOpe);
                        /* Execute user subroutine: 'MOVIMENTO' */
                        S142 ();
                        if (returnInSub) return;
                        if ( AV20SdErro.gxTpr_Status == 200 )
                        {
                           context.CommitDataStores("wptransferirsaldo",pr_default);
                           AV21WEBSESSION.Set("WpTransferirSaldo", "Sucesso");
                           context.setWebReturnParms(new Object[] {});
                           context.setWebReturnParmsMetadata(new Object[] {});
                           context.wjLocDisableFrm = 1;
                           context.nUserReturn = 1;
                           returnInSub = true;
                           if (true) return;
                        }
                     }
                  }
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV16SdTituloMovimento", AV16SdTituloMovimento);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20SdErro", AV20SdErro);
      }

      protected void S132( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV11CheckRequiredFieldsResult = true;
         AssignAttri("", false, "AV11CheckRequiredFieldsResult", AV11CheckRequiredFieldsResult);
         if ( (0==AV5ContaId) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Conta Origem", "", "", "", "", "", "", "", ""),  "error",  Combo_contaid_Ddointernalname,  "true",  ""));
            AV11CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV11CheckRequiredFieldsResult", AV11CheckRequiredFieldsResult);
         }
         if ( (0==AV6DContaId) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Conta destino", "", "", "", "", "", "", "", ""),  "error",  Combo_dcontaid_Ddointernalname,  "true",  ""));
            AV11CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV11CheckRequiredFieldsResult", AV11CheckRequiredFieldsResult);
         }
         if ( (Convert.ToDecimal(0)==AV7Valor) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Valor", "", "", "", "", "", "", "", ""),  "error",  edtavValor_Internalname,  "true",  ""));
            AV11CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV11CheckRequiredFieldsResult", AV11CheckRequiredFieldsResult);
         }
         if ( AV5ContaId == AV6DContaId )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Selecione contas diferentes",  "error",  Combo_contaid_Ddointernalname,  "true",  ""));
            AV11CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV11CheckRequiredFieldsResult", AV11CheckRequiredFieldsResult);
         }
      }

      protected void S122( )
      {
         /* 'LOADCOMBODCONTAID' Routine */
         returnInSub = false;
         /* Using cursor H00662 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A422ContaId = H00662_A422ContaId[0];
            A424ContaNomeConta = H00662_A424ContaNomeConta[0];
            n424ContaNomeConta = H00662_n424ContaNomeConta[0];
            AV9Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV9Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A422ContaId), 9, 0));
            AV9Combo_DataItem.gxTpr_Title = A424ContaNomeConta;
            AV10DContaId_Data.Add(AV9Combo_DataItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         Combo_dcontaid_Selectedvalue_set = ((0==AV6DContaId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV6DContaId), 9, 0)));
         ucCombo_dcontaid.SendProperty(context, "", false, Combo_dcontaid_Internalname, "SelectedValue_set", Combo_dcontaid_Selectedvalue_set);
      }

      protected void S112( )
      {
         /* 'LOADCOMBOCONTAID' Routine */
         returnInSub = false;
         /* Using cursor H00663 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A423ContaSaldoAtual = H00663_A423ContaSaldoAtual[0];
            n423ContaSaldoAtual = H00663_n423ContaSaldoAtual[0];
            A422ContaId = H00663_A422ContaId[0];
            A424ContaNomeConta = H00663_A424ContaNomeConta[0];
            n424ContaNomeConta = H00663_n424ContaNomeConta[0];
            AV9Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV9Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A422ContaId), 9, 0));
            AV13ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV13ComboTitles.Add(A424ContaNomeConta, 0);
            AV13ComboTitles.Add(StringUtil.Trim( context.localUtil.Format( A423ContaSaldoAtual, "ZZZZZZZZZZZZZZ9.99")), 0);
            AV9Combo_DataItem.gxTpr_Title = AV13ComboTitles.ToJSonString(false);
            AV8ContaId_Data.Add(AV9Combo_DataItem, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         Combo_contaid_Selectedvalue_set = ((0==AV5ContaId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV5ContaId), 9, 0)));
         ucCombo_contaid.SendProperty(context, "", false, Combo_contaid_Internalname, "SelectedValue_set", Combo_contaid_Selectedvalue_set);
      }

      protected void S142( )
      {
         /* 'MOVIMENTO' Routine */
         returnInSub = false;
         AV16SdTituloMovimento.gxTpr_Titulomovimentovalor = AV17TituloMovimentoValor;
         AV16SdTituloMovimento.gxTpr_Titulomovimentotipo = "Baixa";
         AV16SdTituloMovimento.gxTpr_Titulomovimentodatacredito = DateTimeUtil.ServerDate( context, pr_default);
         AV16SdTituloMovimento.gxTpr_Titulomovimentocreatedat = DateTimeUtil.ServerNow( context, pr_default);
         AV16SdTituloMovimento.gxTpr_Titulomovimentoupdatedat = DateTimeUtil.ServerNow( context, pr_default);
         AV16SdTituloMovimento.gxTpr_Titulomovimentoope = AV18TituloMovimentoOpe;
         AV16SdTituloMovimento.gxTpr_Titulomovimentoconta = AV19AuxContaId;
         new prcriartitulomovimento(context ).execute(  AV16SdTituloMovimento, out  AV20SdErro) ;
         if ( AV20SdErro.gxTpr_Status != 200 )
         {
            context.RollbackDataStores("wptransferirsaldo",pr_default);
            GX_msglist.addItem(AV20SdErro.gxTpr_Msg);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E13662( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA662( ) ;
         WS662( ) ;
         WE662( ) ;
         cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019254626", true, true);
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
         context.AddJavascriptSource("messages.por.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("gxdec.js", "?"+context.GetBuildNumber( 133260), false, true);
         context.AddJavascriptSource("wptransferirsaldo.js", "?202561019254626", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtnenter_Internalname = "BTNENTER";
         lblTextblockcombo_contaid_Internalname = "TEXTBLOCKCOMBO_CONTAID";
         Combo_contaid_Internalname = "COMBO_CONTAID";
         divTablesplittedcontaid_Internalname = "TABLESPLITTEDCONTAID";
         lblTextblockcombo_dcontaid_Internalname = "TEXTBLOCKCOMBO_DCONTAID";
         Combo_dcontaid_Internalname = "COMBO_DCONTAID";
         divTablesplitteddcontaid_Internalname = "TABLESPLITTEDDCONTAID";
         edtavValor_Internalname = "vVALOR";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain_Internalname = "TABLEMAIN";
         edtavContaid_Internalname = "vCONTAID";
         edtavDcontaid_Internalname = "vDCONTAID";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtavDcontaid_Jsonclick = "";
         edtavDcontaid_Visible = 1;
         edtavContaid_Jsonclick = "";
         edtavContaid_Visible = 1;
         edtavValor_Jsonclick = "";
         edtavValor_Enabled = 1;
         divTablecontent_Height = 0;
         Combo_dcontaid_Emptyitem = Convert.ToBoolean( 0);
         Combo_dcontaid_Cls = "ExtendedCombo AttributeFL";
         Combo_contaid_Htmltemplate = "";
         Combo_contaid_Emptyitem = Convert.ToBoolean( 0);
         Combo_contaid_Cls = "ExtendedCombo AttributeFL ExtendedComboTitleAndSubtitle";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Transferir saldo";
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[]}""");
         setEventMetadata("ENTER","""{"handler":"E12662","iparms":[{"av":"AV11CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"},{"av":"AV5ContaId","fld":"vCONTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV7Valor","fld":"vVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV6DContaId","fld":"vDCONTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV20SdErro","fld":"vSDERRO","type":""},{"av":"Combo_contaid_Ddointernalname","ctrl":"COMBO_CONTAID","prop":"DDOInternalName"},{"av":"Combo_dcontaid_Ddointernalname","ctrl":"COMBO_DCONTAID","prop":"DDOInternalName"},{"av":"AV17TituloMovimentoValor","fld":"vTITULOMOVIMENTOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV16SdTituloMovimento","fld":"vSDTITULOMOVIMENTO","type":""},{"av":"AV18TituloMovimentoOpe","fld":"vTITULOMOVIMENTOOPE","type":"svchar"},{"av":"AV19AuxContaId","fld":"vAUXCONTAID","pic":"ZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV17TituloMovimentoValor","fld":"vTITULOMOVIMENTOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV19AuxContaId","fld":"vAUXCONTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV18TituloMovimentoOpe","fld":"vTITULOMOVIMENTOOPE","type":"svchar"},{"av":"AV11CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"},{"av":"AV16SdTituloMovimento","fld":"vSDTITULOMOVIMENTO","type":""},{"av":"AV20SdErro","fld":"vSDERRO","type":""}]}""");
         return  ;
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      public override void initialize( )
      {
         Combo_contaid_Ddointernalname = "";
         Combo_dcontaid_Ddointernalname = "";
         Combo_dcontaid_Selectedvalue_get = "";
         Combo_contaid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV8ContaId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV10DContaId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV20SdErro = new SdtSdErro(context);
         AV16SdTituloMovimento = new SdtSdTituloMovimento(context);
         AV18TituloMovimentoOpe = "";
         Combo_contaid_Selectedvalue_set = "";
         Combo_dcontaid_Selectedvalue_set = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtnenter_Jsonclick = "";
         lblTextblockcombo_contaid_Jsonclick = "";
         ucCombo_contaid = new GXUserControl();
         Combo_contaid_Caption = "";
         lblTextblockcombo_dcontaid_Jsonclick = "";
         ucCombo_dcontaid = new GXUserControl();
         Combo_dcontaid_Caption = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXt_char1 = "";
         AV14Conta = new SdtConta(context);
         AV15AuxConta = new SdtConta(context);
         AV21WEBSESSION = context.GetSession();
         H00662_A422ContaId = new int[1] ;
         H00662_A424ContaNomeConta = new string[] {""} ;
         H00662_n424ContaNomeConta = new bool[] {false} ;
         A424ContaNomeConta = "";
         AV9Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         H00663_A423ContaSaldoAtual = new decimal[1] ;
         H00663_n423ContaSaldoAtual = new bool[] {false} ;
         H00663_A422ContaId = new int[1] ;
         H00663_A424ContaNomeConta = new string[] {""} ;
         H00663_n424ContaNomeConta = new bool[] {false} ;
         AV13ComboTitles = new GxSimpleCollection<string>();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wptransferirsaldo__default(),
            new Object[][] {
                new Object[] {
               H00662_A422ContaId, H00662_A424ContaNomeConta, H00662_n424ContaNomeConta
               }
               , new Object[] {
               H00663_A423ContaSaldoAtual, H00663_n423ContaSaldoAtual, H00663_A422ContaId, H00663_A424ContaNomeConta, H00663_n424ContaNomeConta
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int AV19AuxContaId ;
      private int divTablecontent_Height ;
      private int edtavValor_Enabled ;
      private int AV5ContaId ;
      private int edtavContaid_Visible ;
      private int AV6DContaId ;
      private int edtavDcontaid_Visible ;
      private int A422ContaId ;
      private int idxLst ;
      private decimal AV17TituloMovimentoValor ;
      private decimal AV7Valor ;
      private decimal A423ContaSaldoAtual ;
      private string Combo_contaid_Ddointernalname ;
      private string Combo_dcontaid_Ddointernalname ;
      private string Combo_dcontaid_Selectedvalue_get ;
      private string Combo_contaid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Combo_contaid_Cls ;
      private string Combo_contaid_Selectedvalue_set ;
      private string Combo_contaid_Htmltemplate ;
      private string Combo_dcontaid_Cls ;
      private string Combo_dcontaid_Selectedvalue_set ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string TempTags ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string divTablesplittedcontaid_Internalname ;
      private string lblTextblockcombo_contaid_Internalname ;
      private string lblTextblockcombo_contaid_Jsonclick ;
      private string Combo_contaid_Caption ;
      private string Combo_contaid_Internalname ;
      private string divTablesplitteddcontaid_Internalname ;
      private string lblTextblockcombo_dcontaid_Internalname ;
      private string lblTextblockcombo_dcontaid_Jsonclick ;
      private string Combo_dcontaid_Caption ;
      private string Combo_dcontaid_Internalname ;
      private string edtavValor_Internalname ;
      private string edtavValor_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavContaid_Internalname ;
      private string edtavContaid_Jsonclick ;
      private string edtavDcontaid_Internalname ;
      private string edtavDcontaid_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXt_char1 ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV11CheckRequiredFieldsResult ;
      private bool Combo_contaid_Emptyitem ;
      private bool Combo_dcontaid_Emptyitem ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool n424ContaNomeConta ;
      private bool n423ContaSaldoAtual ;
      private string AV18TituloMovimentoOpe ;
      private string A424ContaNomeConta ;
      private GXUserControl ucCombo_contaid ;
      private GXUserControl ucCombo_dcontaid ;
      private IGxSession AV21WEBSESSION ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV8ContaId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV10DContaId_Data ;
      private SdtSdErro AV20SdErro ;
      private SdtSdTituloMovimento AV16SdTituloMovimento ;
      private SdtConta AV14Conta ;
      private SdtConta AV15AuxConta ;
      private IDataStoreProvider pr_default ;
      private int[] H00662_A422ContaId ;
      private string[] H00662_A424ContaNomeConta ;
      private bool[] H00662_n424ContaNomeConta ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV9Combo_DataItem ;
      private decimal[] H00663_A423ContaSaldoAtual ;
      private bool[] H00663_n423ContaSaldoAtual ;
      private int[] H00663_A422ContaId ;
      private string[] H00663_A424ContaNomeConta ;
      private bool[] H00663_n424ContaNomeConta ;
      private GxSimpleCollection<string> AV13ComboTitles ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wptransferirsaldo__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00662;
          prmH00662 = new Object[] {
          };
          Object[] prmH00663;
          prmH00663 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H00662", "SELECT ContaId, ContaNomeConta FROM Conta ORDER BY ContaNomeConta ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00662,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00663", "SELECT ContaSaldoAtual, ContaId, ContaNomeConta FROM Conta WHERE ContaSaldoAtual > 0 ORDER BY ContaNomeConta ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00663,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 1 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
       }
    }

 }

}
