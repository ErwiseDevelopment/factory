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
   public class sacado : GXDataArea
   {
      public sacado( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public sacado( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_TrnMode ,
                           int aP1_ClienteId )
      {
         this.AV47TrnMode = aP0_TrnMode;
         this.AV50ClienteId = aP1_ClienteId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavCliente_clientestatus = new GXCombobox();
         cmbavCliente_clientepixtipo = new GXCombobox();
         cmbavCliente_clientetipopessoa = new GXCombobox();
         cmbavCliente_enderecotipo = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "TrnMode");
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
               gxfirstwebparm = GetFirstPar( "TrnMode");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "TrnMode");
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
         PAA32( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTA32( ) ;
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 133260), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 133260), false, true);
         context.AddJavascriptSource("calendar-pt.js", "?"+context.GetBuildNumber( 133260), false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
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
         context.WriteHtmlText( " "+"class=\"form-horizontal FormWithFixedActions\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "sacado"+UrlEncode(StringUtil.RTrim(AV47TrnMode)) + "," + UrlEncode(StringUtil.LTrimStr(AV50ClienteId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("sacado") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal FormWithFixedActions", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPCONTEXT", AV41WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT", AV41WWPContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPCONTEXT", GetSecureSignedToken( "", AV41WWPContext, context));
         GxWebStd.gx_hidden_field( context, "vTRNMODE", StringUtil.RTrim( AV47TrnMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV47TrnMode, "")), context));
         GxWebStd.gx_hidden_field( context, "vCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV50ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV50ClienteId), "ZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Cliente", AV40Cliente);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Cliente", AV40Cliente);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCLIENTE_BANCOID_DATA", AV61Cliente_BancoId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCLIENTE_BANCOID_DATA", AV61Cliente_BancoId_Data);
         }
         GxWebStd.gx_hidden_field( context, "vTRNMODE", StringUtil.RTrim( AV47TrnMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV47TrnMode, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vCHECKREQUIREDFIELDSRESULT", AV12CheckRequiredFieldsResult);
         GxWebStd.gx_hidden_field( context, "CLIENTEDOCUMENTO", A169ClienteDocumento);
         GxWebStd.gx_hidden_field( context, "CLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "TIPOCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A192TipoClienteId), 4, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAUXCLIENTE", AV67AuxCliente);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAUXCLIENTE", AV67AuxCliente);
         }
         GxWebStd.gx_boolean_hidden_field( context, "TIPOCLIENTEPORTAL", A207TipoClientePortal);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPCONTEXT", AV41WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT", AV41WWPContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPCONTEXT", GetSecureSignedToken( "", AV41WWPContext, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDERRO", AV43SdErro);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDERRO", AV43SdErro);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMESSAGES", AV46Messages);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMESSAGES", AV46Messages);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vENDERECOCOMPLETO", AV33EnderecoCompleto);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vENDERECOCOMPLETO", AV33EnderecoCompleto);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDEMPRESAS", AV69SdEmpresas);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDEMPRESAS", AV69SdEmpresas);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vISOK", AV13IsOK);
         GxWebStd.gx_hidden_field( context, "vCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV50ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV50ClienteId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "RELACIONAMENTOSACADO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1031RelacionamentoSacado), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "CLIENTESACADO", A1030ClienteSacado);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCLIENTE", AV40Cliente);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCLIENTE", AV40Cliente);
         }
         GxWebStd.gx_hidden_field( context, "COMBO_CLIENTE_BANCOID_Cls", StringUtil.RTrim( Combo_cliente_bancoid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_CLIENTE_BANCOID_Selectedvalue_set", StringUtil.RTrim( Combo_cliente_bancoid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CLIENTE_BANCOID_Enabled", StringUtil.BoolToStr( Combo_cliente_bancoid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_CLIENTE_BANCOID_Emptyitem", StringUtil.BoolToStr( Combo_cliente_bancoid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS1_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gxuitabspanel_tabs1_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS1_Class", StringUtil.RTrim( Gxuitabspanel_tabs1_Class));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS1_Historymanagement", StringUtil.BoolToStr( Gxuitabspanel_tabs1_Historymanagement));
         GxWebStd.gx_hidden_field( context, "COMBO_CLIENTE_BANCOID_Selectedvalue_get", StringUtil.RTrim( Combo_cliente_bancoid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_CLIENTE_BANCOID_Selectedvalue_get", StringUtil.RTrim( Combo_cliente_bancoid_Selectedvalue_get));
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
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal FormWithFixedActions" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WEA32( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTA32( ) ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "sacado"+UrlEncode(StringUtil.RTrim(AV47TrnMode)) + "," + UrlEncode(StringUtil.LTrimStr(AV50ClienteId,9,0));
         return formatLink("sacado") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Sacado" ;
      }

      public override string GetPgmdesc( )
      {
         return "Cliente" ;
      }

      protected void WBA30( )
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
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table TableTransactionTemplate", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainTransaction TableMainFixedActions", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGxuitabspanel_tabs1.SetProperty("PageCount", Gxuitabspanel_tabs1_Pagecount);
            ucGxuitabspanel_tabs1.SetProperty("Class", Gxuitabspanel_tabs1_Class);
            ucGxuitabspanel_tabs1.SetProperty("HistoryManagement", Gxuitabspanel_tabs1_Historymanagement);
            ucGxuitabspanel_tabs1.Render(context, "tab", Gxuitabspanel_tabs1_Internalname, "GXUITABSPANEL_TABS1Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"title1"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTabinformacoes_title_Internalname, "Informações gerais", "", "", lblTabinformacoes_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Sacado.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "TabInformacoes") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"panel1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableinfo_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 col-md-5 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCliente_clientedocumento_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCliente_clientedocumento_Internalname, "CNPJ", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCliente_clientedocumento_Internalname, AV40Cliente.gxTpr_Clientedocumento, StringUtil.RTrim( context.localUtil.Format( AV40Cliente.gxTpr_Clientedocumento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "CNPJ", edtavCliente_clientedocumento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavCliente_clientedocumento_Enabled, 1, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Sacado.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCliente_clienterazaosocial_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCliente_clienterazaosocial_Internalname, edtavCliente_clienterazaosocial_Caption, "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCliente_clienterazaosocial_Internalname, AV40Cliente.gxTpr_Clienterazaosocial, StringUtil.RTrim( context.localUtil.Format( AV40Cliente.gxTpr_Clienterazaosocial, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCliente_clienterazaosocial_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavCliente_clienterazaosocial_Enabled, 1, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Sacado.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablenomefantasia_Internalname, divTablenomefantasia_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCliente_clientenomefantasia_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCliente_clientenomefantasia_Internalname, "Nome fantasia", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCliente_clientenomefantasia_Internalname, AV40Cliente.gxTpr_Clientenomefantasia, StringUtil.RTrim( context.localUtil.Format( AV40Cliente.gxTpr_Clientenomefantasia, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCliente_clientenomefantasia_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavCliente_clientenomefantasia_Enabled, 1, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Sacado.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCliente_clientestatus_cell_Internalname, 1, 0, "px", 0, "px", divCliente_clientestatus_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", cmbavCliente_clientestatus.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavCliente_clientestatus_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCliente_clientestatus_Internalname, "Status", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCliente_clientestatus, cmbavCliente_clientestatus_Internalname, StringUtil.BoolToStr( AV40Cliente.gxTpr_Clientestatus), 1, cmbavCliente_clientestatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", cmbavCliente_clientestatus.Visible, cmbavCliente_clientestatus.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "", true, 0, "HLP_Sacado.htm");
            cmbavCliente_clientestatus.CurrentValue = StringUtil.BoolToStr( AV40Cliente.gxTpr_Clientestatus);
            AssignProp("", false, cmbavCliente_clientestatus_Internalname, "Values", (string)(cmbavCliente_clientestatus.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup2_Internalname, "Endereço", 1, 0, "px", 0, "px", "Group", "", "HLP_Sacado.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableendereco_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCep_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCep_Internalname, "CEP", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCep_Internalname, AV51CEP, StringUtil.RTrim( context.localUtil.Format( AV51CEP, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCep_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavCep_Enabled, 1, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Sacado.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-10 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCliente_enderecologradouro_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCliente_enderecologradouro_Internalname, "Logradouro", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCliente_enderecologradouro_Internalname, AV40Cliente.gxTpr_Enderecologradouro, StringUtil.RTrim( context.localUtil.Format( AV40Cliente.gxTpr_Enderecologradouro, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCliente_enderecologradouro_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavCliente_enderecologradouro_Enabled, 1, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Sacado.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCliente_endereconumero_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCliente_endereconumero_Internalname, "Número", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCliente_endereconumero_Internalname, AV40Cliente.gxTpr_Endereconumero, StringUtil.RTrim( context.localUtil.Format( AV40Cliente.gxTpr_Endereconumero, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCliente_endereconumero_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavCliente_endereconumero_Enabled, 1, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Sacado.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCliente_enderecocomplemento_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCliente_enderecocomplemento_Internalname, "Complemento", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCliente_enderecocomplemento_Internalname, AV40Cliente.gxTpr_Enderecocomplemento, StringUtil.RTrim( context.localUtil.Format( AV40Cliente.gxTpr_Enderecocomplemento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCliente_enderecocomplemento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavCliente_enderecocomplemento_Enabled, 1, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Sacado.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCliente_enderecobairro_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCliente_enderecobairro_Internalname, "Bairro", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCliente_enderecobairro_Internalname, AV40Cliente.gxTpr_Enderecobairro, StringUtil.RTrim( context.localUtil.Format( AV40Cliente.gxTpr_Enderecobairro, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCliente_enderecobairro_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavCliente_enderecobairro_Enabled, 1, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Sacado.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCliente_enderecocidade_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCliente_enderecocidade_Internalname, "Cidade", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCliente_enderecocidade_Internalname, AV40Cliente.gxTpr_Enderecocidade, StringUtil.RTrim( context.localUtil.Format( AV40Cliente.gxTpr_Enderecocidade, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCliente_enderecocidade_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavCliente_enderecocidade_Enabled, 1, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Sacado.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavMunicipiouf_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMunicipiouf_Internalname, "UF", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMunicipiouf_Internalname, AV54MunicipioUF, StringUtil.RTrim( context.localUtil.Format( AV54MunicipioUF, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,80);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMunicipiouf_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavMunicipiouf_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Sacado.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup3_Internalname, "Contato", 1, 0, "px", 0, "px", "Group", "", "HLP_Sacado.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontato_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCliente_contatoemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCliente_contatoemail_Internalname, "E-mail", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCliente_contatoemail_Internalname, AV40Cliente.gxTpr_Contatoemail, StringUtil.RTrim( context.localUtil.Format( AV40Cliente.gxTpr_Contatoemail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCliente_contatoemail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavCliente_contatoemail_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_Sacado.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedcliente_contatoddd_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcliente_contatoddd_Internalname, "Celular", "", "", lblTextblockcliente_contatoddd_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Sacado.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            wb_table1_97_A32( true) ;
         }
         else
         {
            wb_table1_97_A32( false) ;
         }
         return  ;
      }

      protected void wb_table1_97_A32e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedcliente_contatotelefoneddd_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcliente_contatotelefoneddd_Internalname, "Telefone", "", "", lblTextblockcliente_contatotelefoneddd_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Sacado.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            wb_table2_111_A32( true) ;
         }
         else
         {
            wb_table2_111_A32( false) ;
         }
         return  ;
      }

      protected void wb_table2_111_A32e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"title2"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTabcontabancaria_title_Internalname, "Conta bancária", "", "", lblTabcontabancaria_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Sacado.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "TabContaBancaria") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"panel2"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DscTop ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedcliente_bancoid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_cliente_bancoid_Internalname, "Banco", "", "", lblTextblockcombo_cliente_bancoid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Sacado.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_cliente_bancoid.SetProperty("Caption", Combo_cliente_bancoid_Caption);
            ucCombo_cliente_bancoid.SetProperty("Cls", Combo_cliente_bancoid_Cls);
            ucCombo_cliente_bancoid.SetProperty("EmptyItem", Combo_cliente_bancoid_Emptyitem);
            ucCombo_cliente_bancoid.SetProperty("DropDownOptionsData", AV61Cliente_BancoId_Data);
            ucCombo_cliente_bancoid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_cliente_bancoid_Internalname, "COMBO_CLIENTE_BANCOIDContainer");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCliente_contaagencia_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCliente_contaagencia_Internalname, "Agência", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 136,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCliente_contaagencia_Internalname, AV40Cliente.gxTpr_Contaagencia, StringUtil.RTrim( context.localUtil.Format( AV40Cliente.gxTpr_Contaagencia, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,136);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Agência", edtavCliente_contaagencia_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavCliente_contaagencia_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Sacado.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCliente_contanumero_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCliente_contanumero_Internalname, "Número", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 141,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCliente_contanumero_Internalname, AV40Cliente.gxTpr_Contanumero, StringUtil.RTrim( context.localUtil.Format( AV40Cliente.gxTpr_Contanumero, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,141);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Número", edtavCliente_contanumero_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavCliente_contanumero_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Sacado.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavCliente_clientepixtipo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCliente_clientepixtipo_Internalname, "Tipo pix", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 146,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCliente_clientepixtipo, cmbavCliente_clientepixtipo_Internalname, StringUtil.RTrim( AV40Cliente.gxTpr_Clientepixtipo), 1, cmbavCliente_clientepixtipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavCliente_clientepixtipo.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,146);\"", "", true, 0, "HLP_Sacado.htm");
            cmbavCliente_clientepixtipo.CurrentValue = StringUtil.RTrim( AV40Cliente.gxTpr_Clientepixtipo);
            AssignProp("", false, cmbavCliente_clientepixtipo_Internalname, "Values", (string)(cmbavCliente_clientepixtipo.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCliente_clientepix_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCliente_clientepix_Internalname, "Chave Pix", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 151,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCliente_clientepix_Internalname, AV40Cliente.gxTpr_Clientepix, StringUtil.RTrim( context.localUtil.Format( AV40Cliente.gxTpr_Clientepix, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,151);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCliente_clientepix_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavCliente_clientepix_Enabled, 1, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Sacado.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupFixedBottom CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 156,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", "Confirmar", bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtnenter_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Sacado.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 158,'',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", "Fechar", bttBtncancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Sacado.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 162,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCliente_clientetipopessoa, cmbavCliente_clientetipopessoa_Internalname, StringUtil.RTrim( AV40Cliente.gxTpr_Clientetipopessoa), 1, cmbavCliente_clientetipopessoa_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", cmbavCliente_clientetipopessoa.Visible, 1, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,162);\"", "", true, 0, "HLP_Sacado.htm");
            cmbavCliente_clientetipopessoa.CurrentValue = StringUtil.RTrim( AV40Cliente.gxTpr_Clientetipopessoa);
            AssignProp("", false, cmbavCliente_clientetipopessoa_Internalname, "Values", (string)(cmbavCliente_clientetipopessoa.ToJavascriptSource()), true);
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 163,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCliente_tipoclienteid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40Cliente.gxTpr_Tipoclienteid), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV40Cliente.gxTpr_Tipoclienteid), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,163);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCliente_tipoclienteid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCliente_tipoclienteid_Visible, 1, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Sacado.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 164,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCliente_clienteid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40Cliente.gxTpr_Clienteid), 9, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV40Cliente.gxTpr_Clienteid), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,164);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCliente_clienteid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCliente_clienteid_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Sacado.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 165,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCliente_clientecreatedat_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCliente_clientecreatedat_Internalname, context.localUtil.TToC( AV40Cliente.gxTpr_Clientecreatedat, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( AV40Cliente.gxTpr_Clientecreatedat, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,165);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCliente_clientecreatedat_Jsonclick, 0, "Attribute", "", "", "", "", edtavCliente_clientecreatedat_Visible, 1, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Sacado.htm");
            GxWebStd.gx_bitmap( context, edtavCliente_clientecreatedat_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtavCliente_clientecreatedat_Visible==0)||(1==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Sacado.htm");
            context.WriteHtmlTextNl( "</div>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 166,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCliente_clienteupdatedat_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCliente_clienteupdatedat_Internalname, context.localUtil.TToC( AV40Cliente.gxTpr_Clienteupdatedat, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( AV40Cliente.gxTpr_Clienteupdatedat, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,166);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCliente_clienteupdatedat_Jsonclick, 0, "Attribute", "", "", "", "", edtavCliente_clienteupdatedat_Visible, 1, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Sacado.htm");
            GxWebStd.gx_bitmap( context, edtavCliente_clienteupdatedat_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtavCliente_clienteupdatedat_Visible==0)||(1==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Sacado.htm");
            context.WriteHtmlTextNl( "</div>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 167,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCliente_clienteloguser_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40Cliente.gxTpr_Clienteloguser), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV40Cliente.gxTpr_Clienteloguser), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,167);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCliente_clienteloguser_Jsonclick, 0, "Attribute", "", "", "", "", edtavCliente_clienteloguser_Visible, 1, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Sacado.htm");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 168,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCliente_enderecotipo, cmbavCliente_enderecotipo_Internalname, StringUtil.RTrim( AV40Cliente.gxTpr_Enderecotipo), 1, cmbavCliente_enderecotipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", cmbavCliente_enderecotipo.Visible, 1, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,168);\"", "", true, 0, "HLP_Sacado.htm");
            cmbavCliente_enderecotipo.CurrentValue = StringUtil.RTrim( AV40Cliente.gxTpr_Enderecotipo);
            AssignProp("", false, cmbavCliente_enderecotipo_Internalname, "Values", (string)(cmbavCliente_enderecotipo.ToJavascriptSource()), true);
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 169,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCliente_enderecocep_Internalname, AV40Cliente.gxTpr_Enderecocep, StringUtil.RTrim( context.localUtil.Format( AV40Cliente.gxTpr_Enderecocep, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,169);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCliente_enderecocep_Jsonclick, 0, "Attribute", "", "", "", "", edtavCliente_enderecocep_Visible, 1, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Sacado.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 170,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCliente_municipiocodigo_Internalname, AV40Cliente.gxTpr_Municipiocodigo, StringUtil.RTrim( context.localUtil.Format( AV40Cliente.gxTpr_Municipiocodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,170);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCliente_municipiocodigo_Jsonclick, 0, "Attribute", "", "", "", "", edtavCliente_municipiocodigo_Visible, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Sacado.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 171,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMunicipionome_Internalname, AV34MunicipioNome, StringUtil.RTrim( context.localUtil.Format( AV34MunicipioNome, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,171);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMunicipionome_Jsonclick, 0, "Attribute", "", "", "", "", edtavMunicipionome_Visible, 1, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Sacado.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void STARTA32( )
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
         Form.Meta.addItem("description", "Cliente", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPA30( ) ;
      }

      protected void WSA32( )
      {
         STARTA32( ) ;
         EVTA32( ) ;
      }

      protected void EVTA32( )
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
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_CLIENTE_BANCOID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Combo_cliente_bancoid.Onoptionclicked */
                              E11A32 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E12A32 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E13A32 ();
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
                                    E14A32 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "CLIENTE_CLIENTEDOCUMENTO.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Cliente_clientedocumento.Controlvaluechanged */
                              E15A32 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VCEP.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E16A32 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "CLIENTE_CONTATONUMERO.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Cliente_contatonumero.Controlvaluechanged */
                              E17A32 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "CLIENTE_CONTATOTELEFONENUMERO.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Cliente_contatotelefonenumero.Controlvaluechanged */
                              E18A32 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E19A32 ();
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

      protected void WEA32( )
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

      protected void PAA32( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               GxWebError = 1;
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
            }
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "sacado")), "sacado") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "sacado")))) ;
               }
               else
               {
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               }
            }
            if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               if ( nGotPars == 0 )
               {
                  entryPointCalled = false;
                  gxfirstwebparm = GetFirstPar( "TrnMode");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV47TrnMode = gxfirstwebparm;
                     AssignAttri("", false, "AV47TrnMode", AV47TrnMode);
                     GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV47TrnMode, "")), context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV50ClienteId = (int)(Math.Round(NumberUtil.Val( GetPar( "ClienteId"), "."), 18, MidpointRounding.ToEven));
                        AssignAttri("", false, "AV50ClienteId", StringUtil.LTrimStr( (decimal)(AV50ClienteId), 9, 0));
                        GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV50ClienteId), "ZZZZZZZZ9"), context));
                     }
                  }
                  if ( toggleJsOutput )
                  {
                     if ( context.isSpaRequest( ) )
                     {
                        enableJsOutput();
                     }
                  }
               }
            }
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
               GX_FocusControl = edtavCliente_clientedocumento_Internalname;
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
         if ( cmbavCliente_clientestatus.ItemCount > 0 )
         {
            AV40Cliente.gxTpr_Clientestatus = StringUtil.StrToBool( cmbavCliente_clientestatus.getValidValue(StringUtil.BoolToStr( AV40Cliente.gxTpr_Clientestatus)));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCliente_clientestatus.CurrentValue = StringUtil.BoolToStr( AV40Cliente.gxTpr_Clientestatus);
            AssignProp("", false, cmbavCliente_clientestatus_Internalname, "Values", cmbavCliente_clientestatus.ToJavascriptSource(), true);
         }
         if ( cmbavCliente_clientepixtipo.ItemCount > 0 )
         {
            AV40Cliente.gxTpr_Clientepixtipo = cmbavCliente_clientepixtipo.getValidValue(AV40Cliente.gxTpr_Clientepixtipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCliente_clientepixtipo.CurrentValue = StringUtil.RTrim( AV40Cliente.gxTpr_Clientepixtipo);
            AssignProp("", false, cmbavCliente_clientepixtipo_Internalname, "Values", cmbavCliente_clientepixtipo.ToJavascriptSource(), true);
         }
         if ( cmbavCliente_clientetipopessoa.ItemCount > 0 )
         {
            AV40Cliente.gxTpr_Clientetipopessoa = cmbavCliente_clientetipopessoa.getValidValue(AV40Cliente.gxTpr_Clientetipopessoa);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCliente_clientetipopessoa.CurrentValue = StringUtil.RTrim( AV40Cliente.gxTpr_Clientetipopessoa);
            AssignProp("", false, cmbavCliente_clientetipopessoa_Internalname, "Values", cmbavCliente_clientetipopessoa.ToJavascriptSource(), true);
         }
         if ( cmbavCliente_enderecotipo.ItemCount > 0 )
         {
            AV40Cliente.gxTpr_Enderecotipo = cmbavCliente_enderecotipo.getValidValue(AV40Cliente.gxTpr_Enderecotipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCliente_enderecotipo.CurrentValue = StringUtil.RTrim( AV40Cliente.gxTpr_Enderecotipo);
            AssignProp("", false, cmbavCliente_enderecotipo_Internalname, "Values", cmbavCliente_enderecotipo.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFA32( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavMunicipiouf_Enabled = 0;
         AssignProp("", false, edtavMunicipiouf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMunicipiouf_Enabled), 5, 0), true);
      }

      protected void RFA32( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E13A32 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E19A32 ();
            WBA30( ) ;
         }
      }

      protected void send_integrity_lvl_hashesA32( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPCONTEXT", AV41WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT", AV41WWPContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPCONTEXT", GetSecureSignedToken( "", AV41WWPContext, context));
      }

      protected void before_start_formulas( )
      {
         edtavMunicipiouf_Enabled = 0;
         AssignProp("", false, edtavMunicipiouf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMunicipiouf_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUPA30( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E12A32 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vCLIENTE"), AV40Cliente);
            ajax_req_read_hidden_sdt(cgiGet( "Cliente"), AV40Cliente);
            ajax_req_read_hidden_sdt(cgiGet( "vCLIENTE_BANCOID_DATA"), AV61Cliente_BancoId_Data);
            /* Read saved values. */
            Combo_cliente_bancoid_Cls = cgiGet( "COMBO_CLIENTE_BANCOID_Cls");
            Combo_cliente_bancoid_Selectedvalue_set = cgiGet( "COMBO_CLIENTE_BANCOID_Selectedvalue_set");
            Combo_cliente_bancoid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_CLIENTE_BANCOID_Enabled"));
            Combo_cliente_bancoid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_CLIENTE_BANCOID_Emptyitem"));
            Gxuitabspanel_tabs1_Pagecount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GXUITABSPANEL_TABS1_Pagecount"), ",", "."), 18, MidpointRounding.ToEven));
            Gxuitabspanel_tabs1_Class = cgiGet( "GXUITABSPANEL_TABS1_Class");
            Gxuitabspanel_tabs1_Historymanagement = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_TABS1_Historymanagement"));
            Combo_cliente_bancoid_Selectedvalue_get = cgiGet( "COMBO_CLIENTE_BANCOID_Selectedvalue_get");
            /* Read variables values. */
            AV40Cliente.gxTpr_Clientedocumento = cgiGet( edtavCliente_clientedocumento_Internalname);
            AV40Cliente.gxTpr_Clienterazaosocial = StringUtil.Upper( cgiGet( edtavCliente_clienterazaosocial_Internalname));
            AV40Cliente.gxTpr_Clientenomefantasia = StringUtil.Upper( cgiGet( edtavCliente_clientenomefantasia_Internalname));
            cmbavCliente_clientestatus.CurrentValue = cgiGet( cmbavCliente_clientestatus_Internalname);
            AV40Cliente.gxTpr_Clientestatus = StringUtil.StrToBool( cgiGet( cmbavCliente_clientestatus_Internalname));
            AV51CEP = cgiGet( edtavCep_Internalname);
            AssignAttri("", false, "AV51CEP", AV51CEP);
            AV40Cliente.gxTpr_Enderecologradouro = StringUtil.Upper( cgiGet( edtavCliente_enderecologradouro_Internalname));
            AV40Cliente.gxTpr_Endereconumero = cgiGet( edtavCliente_endereconumero_Internalname);
            AV40Cliente.gxTpr_Enderecocomplemento = cgiGet( edtavCliente_enderecocomplemento_Internalname);
            AV40Cliente.gxTpr_Enderecobairro = StringUtil.Upper( cgiGet( edtavCliente_enderecobairro_Internalname));
            AV40Cliente.gxTpr_Enderecocidade = StringUtil.Upper( cgiGet( edtavCliente_enderecocidade_Internalname));
            AV54MunicipioUF = StringUtil.Upper( cgiGet( edtavMunicipiouf_Internalname));
            AssignAttri("", false, "AV54MunicipioUF", AV54MunicipioUF);
            AV40Cliente.gxTpr_Contatoemail = cgiGet( edtavCliente_contatoemail_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCliente_contatoddd_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCliente_contatoddd_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLIENTE_CONTATODDD");
               GX_FocusControl = edtavCliente_contatoddd_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV40Cliente.gxTpr_Contatoddd = 0;
            }
            else
            {
               AV40Cliente.gxTpr_Contatoddd = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCliente_contatoddd_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCliente_contatonumero_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCliente_contatonumero_Internalname), ",", ".") > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLIENTE_CONTATONUMERO");
               GX_FocusControl = edtavCliente_contatonumero_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV40Cliente.gxTpr_Contatonumero = 0;
            }
            else
            {
               AV40Cliente.gxTpr_Contatonumero = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCliente_contatonumero_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCliente_contatotelefoneddd_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCliente_contatotelefoneddd_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLIENTE_CONTATOTELEFONEDDD");
               GX_FocusControl = edtavCliente_contatotelefoneddd_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV40Cliente.gxTpr_Contatotelefoneddd = 0;
            }
            else
            {
               AV40Cliente.gxTpr_Contatotelefoneddd = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCliente_contatotelefoneddd_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCliente_contatotelefonenumero_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCliente_contatotelefonenumero_Internalname), ",", ".") > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLIENTE_CONTATOTELEFONENUMERO");
               GX_FocusControl = edtavCliente_contatotelefonenumero_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV40Cliente.gxTpr_Contatotelefonenumero = 0;
            }
            else
            {
               AV40Cliente.gxTpr_Contatotelefonenumero = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCliente_contatotelefonenumero_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            }
            AV40Cliente.gxTpr_Contaagencia = cgiGet( edtavCliente_contaagencia_Internalname);
            AV40Cliente.gxTpr_Contanumero = cgiGet( edtavCliente_contanumero_Internalname);
            cmbavCliente_clientepixtipo.CurrentValue = cgiGet( cmbavCliente_clientepixtipo_Internalname);
            AV40Cliente.gxTpr_Clientepixtipo = cgiGet( cmbavCliente_clientepixtipo_Internalname);
            AV40Cliente.gxTpr_Clientepix = cgiGet( edtavCliente_clientepix_Internalname);
            cmbavCliente_clientetipopessoa.CurrentValue = cgiGet( cmbavCliente_clientetipopessoa_Internalname);
            AV40Cliente.gxTpr_Clientetipopessoa = cgiGet( cmbavCliente_clientetipopessoa_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCliente_tipoclienteid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCliente_tipoclienteid_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLIENTE_TIPOCLIENTEID");
               GX_FocusControl = edtavCliente_tipoclienteid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV40Cliente.gxTpr_Tipoclienteid = 0;
            }
            else
            {
               AV40Cliente.gxTpr_Tipoclienteid = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCliente_tipoclienteid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCliente_clienteid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCliente_clienteid_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLIENTE_CLIENTEID");
               GX_FocusControl = edtavCliente_clienteid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV40Cliente.gxTpr_Clienteid = 0;
            }
            else
            {
               AV40Cliente.gxTpr_Clienteid = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCliente_clienteid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtavCliente_clientecreatedat_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Criação"}), 1, "CLIENTE_CLIENTECREATEDAT");
               GX_FocusControl = edtavCliente_clientecreatedat_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV40Cliente.gxTpr_Clientecreatedat = (DateTime)(DateTime.MinValue);
            }
            else
            {
               AV40Cliente.gxTpr_Clientecreatedat = context.localUtil.CToT( cgiGet( edtavCliente_clientecreatedat_Internalname));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtavCliente_clienteupdatedat_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Atualização"}), 1, "CLIENTE_CLIENTEUPDATEDAT");
               GX_FocusControl = edtavCliente_clienteupdatedat_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV40Cliente.gxTpr_Clienteupdatedat = (DateTime)(DateTime.MinValue);
            }
            else
            {
               AV40Cliente.gxTpr_Clienteupdatedat = context.localUtil.CToT( cgiGet( edtavCliente_clienteupdatedat_Internalname));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCliente_clienteloguser_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCliente_clienteloguser_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLIENTE_CLIENTELOGUSER");
               GX_FocusControl = edtavCliente_clienteloguser_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV40Cliente.gxTpr_Clienteloguser = 0;
            }
            else
            {
               AV40Cliente.gxTpr_Clienteloguser = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCliente_clienteloguser_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            }
            cmbavCliente_enderecotipo.CurrentValue = cgiGet( cmbavCliente_enderecotipo_Internalname);
            AV40Cliente.gxTpr_Enderecotipo = cgiGet( cmbavCliente_enderecotipo_Internalname);
            AV40Cliente.gxTpr_Enderecocep = cgiGet( edtavCliente_enderecocep_Internalname);
            AV40Cliente.gxTpr_Municipiocodigo = cgiGet( edtavCliente_municipiocodigo_Internalname);
            AV34MunicipioNome = StringUtil.Upper( cgiGet( edtavMunicipionome_Internalname));
            AssignAttri("", false, "AV34MunicipioNome", AV34MunicipioNome);
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
         E12A32 ();
         if (returnInSub) return;
      }

      protected void E12A32( )
      {
         /* Start Routine */
         returnInSub = false;
         AV40Cliente.gxTpr_Clientetipopessoa = "JURIDICA";
         AV48LoadSuccess = true;
         if ( ( ( StringUtil.StrCmp(AV47TrnMode, "DSP") == 0 ) ) || ( ( StringUtil.StrCmp(AV47TrnMode, "INS") == 0 ) ) || ( ( StringUtil.StrCmp(AV47TrnMode, "UPD") == 0 ) ) || ( ( StringUtil.StrCmp(AV47TrnMode, "DLT") == 0 ) ) )
         {
            if ( StringUtil.StrCmp(AV47TrnMode, "INS") != 0 )
            {
               AV40Cliente.Load(AV50ClienteId);
               AV48LoadSuccess = AV40Cliente.Success();
               if ( ! AV48LoadSuccess )
               {
                  AV46Messages = AV40Cliente.GetMessages();
                  /* Execute user subroutine: 'SHOW MESSAGES' */
                  S112 ();
                  if (returnInSub) return;
               }
               if ( ( StringUtil.StrCmp(AV47TrnMode, "DSP") == 0 ) || ( StringUtil.StrCmp(AV47TrnMode, "DLT") == 0 ) )
               {
                  Combo_cliente_bancoid_Enabled = false;
                  ucCombo_cliente_bancoid.SendProperty(context, "", false, Combo_cliente_bancoid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_cliente_bancoid_Enabled));
                  edtavCliente_contaagencia_Enabled = 0;
                  AssignProp("", false, edtavCliente_contaagencia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCliente_contaagencia_Enabled), 5, 0), true);
                  edtavCliente_contanumero_Enabled = 0;
                  AssignProp("", false, edtavCliente_contanumero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCliente_contanumero_Enabled), 5, 0), true);
                  cmbavCliente_clientepixtipo.Enabled = 0;
                  AssignProp("", false, cmbavCliente_clientepixtipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavCliente_clientepixtipo.Enabled), 5, 0), true);
                  edtavCliente_clientepix_Enabled = 0;
                  AssignProp("", false, edtavCliente_clientepix_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCliente_clientepix_Enabled), 5, 0), true);
                  edtavCliente_clientedocumento_Enabled = 0;
                  AssignProp("", false, edtavCliente_clientedocumento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCliente_clientedocumento_Enabled), 5, 0), true);
                  edtavCliente_clienterazaosocial_Enabled = 0;
                  AssignProp("", false, edtavCliente_clienterazaosocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCliente_clienterazaosocial_Enabled), 5, 0), true);
                  cmbavCliente_clientestatus.Enabled = 0;
                  AssignProp("", false, cmbavCliente_clientestatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavCliente_clientestatus.Enabled), 5, 0), true);
                  edtavCliente_contatoemail_Enabled = 0;
                  AssignProp("", false, edtavCliente_contatoemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCliente_contatoemail_Enabled), 5, 0), true);
                  edtavCliente_contatoddd_Enabled = 0;
                  AssignProp("", false, edtavCliente_contatoddd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCliente_contatoddd_Enabled), 5, 0), true);
                  edtavCliente_contatonumero_Enabled = 0;
                  AssignProp("", false, edtavCliente_contatonumero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCliente_contatonumero_Enabled), 5, 0), true);
                  edtavCliente_contatotelefoneddd_Enabled = 0;
                  AssignProp("", false, edtavCliente_contatotelefoneddd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCliente_contatotelefoneddd_Enabled), 5, 0), true);
                  edtavCliente_contatotelefonenumero_Enabled = 0;
                  AssignProp("", false, edtavCliente_contatotelefonenumero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCliente_contatotelefonenumero_Enabled), 5, 0), true);
                  edtavCep_Enabled = 0;
                  AssignProp("", false, edtavCep_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCep_Enabled), 5, 0), true);
                  edtavCliente_enderecologradouro_Enabled = 0;
                  AssignProp("", false, edtavCliente_enderecologradouro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCliente_enderecologradouro_Enabled), 5, 0), true);
                  edtavCliente_endereconumero_Enabled = 0;
                  AssignProp("", false, edtavCliente_endereconumero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCliente_endereconumero_Enabled), 5, 0), true);
                  edtavCliente_enderecocomplemento_Enabled = 0;
                  AssignProp("", false, edtavCliente_enderecocomplemento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCliente_enderecocomplemento_Enabled), 5, 0), true);
                  edtavCliente_enderecobairro_Enabled = 0;
                  AssignProp("", false, edtavCliente_enderecobairro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCliente_enderecobairro_Enabled), 5, 0), true);
                  edtavCliente_enderecocidade_Enabled = 0;
                  AssignProp("", false, edtavCliente_enderecocidade_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCliente_enderecocidade_Enabled), 5, 0), true);
                  edtavCliente_clientenomefantasia_Enabled = 0;
                  AssignProp("", false, edtavCliente_clientenomefantasia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCliente_clientenomefantasia_Enabled), 5, 0), true);
               }
            }
         }
         else
         {
            AV48LoadSuccess = false;
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         if ( AV48LoadSuccess )
         {
            if ( StringUtil.StrCmp(AV47TrnMode, "DLT") == 0 )
            {
               GX_msglist.addItem("Confirme a eliminação dos dados.");
            }
         }
         /* Execute user subroutine: 'LOADCOMBOCLIENTE_BANCOID' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S132 ();
         if (returnInSub) return;
         cmbavCliente_clientetipopessoa.Visible = 0;
         AssignProp("", false, cmbavCliente_clientetipopessoa_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavCliente_clientetipopessoa.Visible), 5, 0), true);
         edtavCliente_tipoclienteid_Visible = 0;
         AssignProp("", false, edtavCliente_tipoclienteid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCliente_tipoclienteid_Visible), 5, 0), true);
         edtavCliente_clienteid_Visible = 0;
         AssignProp("", false, edtavCliente_clienteid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCliente_clienteid_Visible), 5, 0), true);
         edtavCliente_clientecreatedat_Visible = 0;
         AssignProp("", false, edtavCliente_clientecreatedat_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCliente_clientecreatedat_Visible), 5, 0), true);
         edtavCliente_clienteupdatedat_Visible = 0;
         AssignProp("", false, edtavCliente_clienteupdatedat_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCliente_clienteupdatedat_Visible), 5, 0), true);
         edtavCliente_clienteloguser_Visible = 0;
         AssignProp("", false, edtavCliente_clienteloguser_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCliente_clienteloguser_Visible), 5, 0), true);
         cmbavCliente_enderecotipo.Visible = 0;
         AssignProp("", false, cmbavCliente_enderecotipo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavCliente_enderecotipo.Visible), 5, 0), true);
         edtavCliente_enderecocep_Visible = 0;
         AssignProp("", false, edtavCliente_enderecocep_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCliente_enderecocep_Visible), 5, 0), true);
         edtavCliente_municipiocodigo_Visible = 0;
         AssignProp("", false, edtavCliente_municipiocodigo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCliente_municipiocodigo_Visible), 5, 0), true);
         edtavMunicipionome_Visible = 0;
         AssignProp("", false, edtavMunicipionome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMunicipionome_Visible), 5, 0), true);
         AV51CEP = AV40Cliente.gxTpr_Enderecocep;
         AssignAttri("", false, "AV51CEP", AV51CEP);
         GXt_SdtWWPContext1 = AV41WWPContext;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  GXt_SdtWWPContext1) ;
         AV41WWPContext = GXt_SdtWWPContext1;
         if ( StringUtil.StrCmp(AV47TrnMode, "INS") == 0 )
         {
            this.executeUsercontrolMethod("", false, "GXUITABSPANEL_TABS1Container", "HideTab", "", new Object[] {(short)3});
         }
      }

      protected void E13A32( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S142 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E11A32( )
      {
         /* Combo_cliente_bancoid_Onoptionclicked Routine */
         returnInSub = false;
         AV40Cliente.gxTpr_Bancoid = (int)(Math.Round(NumberUtil.Val( Combo_cliente_bancoid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV40Cliente", AV40Cliente);
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E14A32 ();
         if (returnInSub) return;
      }

      protected void E14A32( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV67AuxCliente = new SdtCliente(context);
         AV67AuxCliente.FromJSonString(AV40Cliente.ToJSonString(true, true), null);
         if ( 1 == 2 )
         {
            if ( StringUtil.StrCmp(AV47TrnMode, "DSP") != 0 )
            {
               if ( StringUtil.StrCmp(AV47TrnMode, "DLT") != 0 )
               {
                  /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
                  S152 ();
                  if (returnInSub) return;
               }
               if ( ( StringUtil.StrCmp(AV47TrnMode, "DLT") == 0 ) || AV12CheckRequiredFieldsResult )
               {
                  if ( StringUtil.StrCmp(AV47TrnMode, "DLT") == 0 )
                  {
                     AV40Cliente.Delete();
                  }
                  else
                  {
                     AV40Cliente.Save();
                  }
                  if ( AV40Cliente.Success() )
                  {
                     /* Execute user subroutine: 'AFTER_TRN' */
                     S162 ();
                     if (returnInSub) return;
                  }
                  else
                  {
                     AV46Messages = AV40Cliente.GetMessages();
                     /* Execute user subroutine: 'SHOW MESSAGES' */
                     S112 ();
                     if (returnInSub) return;
                  }
               }
            }
         }
         else
         {
            AV98GXLvl128 = 0;
            /* Using cursor H00A33 */
            pr_default.execute(0, new Object[] {AV40Cliente.gxTpr_Clientedocumento});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A169ClienteDocumento = H00A33_A169ClienteDocumento[0];
               n169ClienteDocumento = H00A33_n169ClienteDocumento[0];
               A168ClienteId = H00A33_A168ClienteId[0];
               n168ClienteId = H00A33_n168ClienteId[0];
               A1031RelacionamentoSacado = H00A33_A1031RelacionamentoSacado[0];
               n1031RelacionamentoSacado = H00A33_n1031RelacionamentoSacado[0];
               A1031RelacionamentoSacado = H00A33_A1031RelacionamentoSacado[0];
               n1031RelacionamentoSacado = H00A33_n1031RelacionamentoSacado[0];
               A1030ClienteSacado = ((A1031RelacionamentoSacado==0) ? false : true);
               AssignAttri("", false, "A1030ClienteSacado", A1030ClienteSacado);
               AV98GXLvl128 = 1;
               if ( ! A1030ClienteSacado )
               {
                  AV70Relacionamento = new SdtRelacionamento(context);
                  AV70Relacionamento.gxTpr_Clienteid = A168ClienteId;
                  AV70Relacionamento.gxTpr_Relacionamentotipo = "Sacado";
                  AV70Relacionamento.Save();
                  if ( AV70Relacionamento.Success() )
                  {
                     context.CommitDataStores("sacado",pr_default);
                     context.setWebReturnParms(new Object[] {});
                     context.setWebReturnParmsMetadata(new Object[] {});
                     context.wjLocDisableFrm = 1;
                     context.nUserReturn = 1;
                     pr_default.close(0);
                     returnInSub = true;
                     if (true) return;
                  }
                  else
                  {
                     context.RollbackDataStores("sacado",pr_default);
                     GXt_char2 = ((GeneXus.Utils.SdtMessages_Message)AV70Relacionamento.GetMessages().Item(1)).gxTpr_Description;
                     new message(context ).gxep_erro( ref  GXt_char2) ;
                     ((GeneXus.Utils.SdtMessages_Message)AV70Relacionamento.GetMessages().Item(1)).gxTpr_Description = GXt_char2;
                  }
               }
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            if ( AV98GXLvl128 == 0 )
            {
               if ( StringUtil.StrCmp(AV47TrnMode, "DSP") != 0 )
               {
                  if ( StringUtil.StrCmp(AV47TrnMode, "DLT") != 0 )
                  {
                     /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
                     S152 ();
                     if (returnInSub) return;
                  }
                  if ( ( StringUtil.StrCmp(AV47TrnMode, "DLT") == 0 ) || AV12CheckRequiredFieldsResult )
                  {
                     if ( StringUtil.StrCmp(AV47TrnMode, "DLT") == 0 )
                     {
                        AV67AuxCliente.Delete();
                     }
                     else
                     {
                        AV67AuxCliente.Save();
                     }
                     if ( AV67AuxCliente.Success() )
                     {
                        /* Execute user subroutine: 'AFTER_TRN' */
                        S162 ();
                        if (returnInSub) return;
                     }
                     else
                     {
                        AV46Messages = AV67AuxCliente.GetMessages();
                        /* Execute user subroutine: 'SHOW MESSAGES' */
                        S112 ();
                        if (returnInSub) return;
                     }
                  }
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV67AuxCliente", AV67AuxCliente);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV40Cliente", AV40Cliente);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV46Messages", AV46Messages);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV43SdErro", AV43SdErro);
      }

      protected void S142( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ( StringUtil.StrCmp(AV47TrnMode, "DSP") != 0 ) ) )
         {
            bttBtnenter_Visible = 0;
            AssignProp("", false, bttBtnenter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnenter_Visible), 5, 0), true);
         }
      }

      protected void S152( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV12CheckRequiredFieldsResult = true;
         AssignAttri("", false, "AV12CheckRequiredFieldsResult", AV12CheckRequiredFieldsResult);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV40Cliente.gxTpr_Clientedocumento)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "CNPJ", "", "", "", "", "", "", "", ""),  "error",  edtavCliente_clientedocumento_Internalname,  "true",  ""));
            AV12CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV12CheckRequiredFieldsResult", AV12CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV40Cliente.gxTpr_Clienterazaosocial)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Razão social", "", "", "", "", "", "", "", ""),  "error",  edtavCliente_clienterazaosocial_Internalname,  "true",  ""));
            AV12CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV12CheckRequiredFieldsResult", AV12CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51CEP)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "CEP", "", "", "", "", "", "", "", ""),  "error",  edtavCep_Internalname,  "true",  ""));
            AV12CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV12CheckRequiredFieldsResult", AV12CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV40Cliente.gxTpr_Enderecologradouro)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Logradouro", "", "", "", "", "", "", "", ""),  "error",  edtavCliente_enderecologradouro_Internalname,  "true",  ""));
            AV12CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV12CheckRequiredFieldsResult", AV12CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV40Cliente.gxTpr_Endereconumero)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Número", "", "", "", "", "", "", "", ""),  "error",  edtavCliente_endereconumero_Internalname,  "true",  ""));
            AV12CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV12CheckRequiredFieldsResult", AV12CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV40Cliente.gxTpr_Enderecobairro)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Bairro", "", "", "", "", "", "", "", ""),  "error",  edtavCliente_enderecobairro_Internalname,  "true",  ""));
            AV12CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV12CheckRequiredFieldsResult", AV12CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV40Cliente.gxTpr_Enderecocidade)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Cidade", "", "", "", "", "", "", "", ""),  "error",  edtavCliente_enderecocidade_Internalname,  "true",  ""));
            AV12CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV12CheckRequiredFieldsResult", AV12CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV40Cliente.gxTpr_Contatoemail)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "E-mail", "", "", "", "", "", "", "", ""),  "error",  edtavCliente_contatoemail_Internalname,  "true",  ""));
            AV12CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV12CheckRequiredFieldsResult", AV12CheckRequiredFieldsResult);
         }
         /* Execute user subroutine: 'VALIDADOCUMENTO' */
         S172 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'VALIDACEP' */
         S182 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'VALIDACELULAR' */
         S192 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'VALIDATELEFONE' */
         S202 ();
         if (returnInSub) return;
      }

      protected void S132( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( ! ( ( StringUtil.StrCmp(AV47TrnMode, "INS") != 0 ) ) )
         {
            cmbavCliente_clientestatus.Visible = 0;
            AssignProp("", false, cmbavCliente_clientestatus_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavCliente_clientestatus.Visible), 5, 0), true);
            divCliente_clientestatus_cell_Class = "Invisible";
            AssignProp("", false, divCliente_clientestatus_cell_Internalname, "Class", divCliente_clientestatus_cell_Class, true);
         }
         else
         {
            cmbavCliente_clientestatus.Visible = 1;
            AssignProp("", false, cmbavCliente_clientestatus_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavCliente_clientestatus.Visible), 5, 0), true);
            divCliente_clientestatus_cell_Class = "col-xs-12 col-sm-2 DataContentCellFL";
            AssignProp("", false, divCliente_clientestatus_cell_Internalname, "Class", divCliente_clientestatus_cell_Class, true);
         }
      }

      protected void S122( )
      {
         /* 'LOADCOMBOCLIENTE_BANCOID' Routine */
         returnInSub = false;
         /* Using cursor H00A34 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A402BancoId = H00A34_A402BancoId[0];
            A403BancoNome = H00A34_A403BancoNome[0];
            n403BancoNome = H00A34_n403BancoNome[0];
            AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A402BancoId), 9, 0));
            AV16Combo_DataItem.gxTpr_Title = A403BancoNome;
            AV61Cliente_BancoId_Data.Add(AV16Combo_DataItem, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         Combo_cliente_bancoid_Selectedvalue_set = ((0==AV40Cliente.gxTpr_Bancoid) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV40Cliente.gxTpr_Bancoid), 9, 0)));
         ucCombo_cliente_bancoid.SendProperty(context, "", false, Combo_cliente_bancoid_Internalname, "SelectedValue_set", Combo_cliente_bancoid_Selectedvalue_set);
      }

      protected void S112( )
      {
         /* 'SHOW MESSAGES' Routine */
         returnInSub = false;
         AV100GXV28 = 1;
         while ( AV100GXV28 <= AV46Messages.Count )
         {
            AV45Message = ((GeneXus.Utils.SdtMessages_Message)AV46Messages.Item(AV100GXV28));
            GX_msglist.addItem(AV45Message.gxTpr_Description);
            AV100GXV28 = (int)(AV100GXV28+1);
         }
      }

      protected void S162( )
      {
         /* 'AFTER_TRN' Routine */
         returnInSub = false;
         AV65IsContinue = true;
         AV53TipoClientePortal = false;
         /* Using cursor H00A35 */
         pr_default.execute(2, new Object[] {AV67AuxCliente.gxTpr_Tipoclienteid});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A192TipoClienteId = H00A35_A192TipoClienteId[0];
            A207TipoClientePortal = H00A35_A207TipoClientePortal[0];
            n207TipoClientePortal = H00A35_n207TipoClientePortal[0];
            AV53TipoClientePortal = A207TipoClientePortal;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(2);
         if ( AV53TipoClientePortal )
         {
            GXt_int3 = 0;
            new prcriausuario(context ).execute(  AV67AuxCliente.gxTpr_Clientedocumento,  AV67AuxCliente.gxTpr_Clienterazaosocial,  AV67AuxCliente.gxTpr_Contatoemail,  AV41WWPContext.gxTpr_Userid,  AV67AuxCliente.gxTpr_Clienteid, ref  GXt_int3, ref  AV43SdErro) ;
            if ( AV43SdErro.gxTpr_Status != 200 )
            {
               GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Erro!",  AV43SdErro.gxTpr_Msg,  "error",  "",  "true",  ""));
               context.RollbackDataStores("sacado",pr_default);
               AV65IsContinue = false;
            }
            else
            {
               AV65IsContinue = true;
            }
         }
         if ( AV65IsContinue )
         {
            AV70Relacionamento = new SdtRelacionamento(context);
            AV70Relacionamento.gxTpr_Clienteid = AV67AuxCliente.gxTpr_Clienteid;
            AV70Relacionamento.gxTpr_Relacionamentotipo = "Sacado";
            AV70Relacionamento.Save();
            if ( AV70Relacionamento.Success() )
            {
               context.CommitDataStores("sacado",pr_default);
               context.setWebReturnParms(new Object[] {});
               context.setWebReturnParmsMetadata(new Object[] {});
               context.wjLocDisableFrm = 1;
               context.nUserReturn = 1;
               returnInSub = true;
               if (true) return;
            }
            else
            {
               context.RollbackDataStores("sacado",pr_default);
               GXt_char2 = ((GeneXus.Utils.SdtMessages_Message)AV70Relacionamento.GetMessages().Item(1)).gxTpr_Description;
               new message(context ).gxep_erro( ref  GXt_char2) ;
               ((GeneXus.Utils.SdtMessages_Message)AV70Relacionamento.GetMessages().Item(1)).gxTpr_Description = GXt_char2;
            }
         }
      }

      protected void E15A32( )
      {
         /* Cliente_clientedocumento_Controlvaluechanged Routine */
         returnInSub = false;
         AV40Cliente.gxTpr_Clientedocumento = StringUtil.StringReplace( AV40Cliente.gxTpr_Clientedocumento, ".", "");
         AV40Cliente.gxTpr_Clientedocumento = StringUtil.StringReplace( AV40Cliente.gxTpr_Clientedocumento, "-", "");
         AV40Cliente.gxTpr_Clientedocumento = StringUtil.StringReplace( AV40Cliente.gxTpr_Clientedocumento, "/", "");
         /* Execute user subroutine: 'VALIDADOCUMENTO' */
         S172 ();
         if (returnInSub) return;
         if ( AV13IsOK )
         {
            AV68EmpresaCNPJ = AV40Cliente.gxTpr_Clientedocumento;
            new prgetempresaapi(context ).execute(  AV68EmpresaCNPJ, out  AV69SdEmpresas) ;
            AV40Cliente.gxTpr_Clienterazaosocial = AV69SdEmpresas.gxTpr_Company.gxTpr_Name;
            AV40Cliente.gxTpr_Clientenomefantasia = AV69SdEmpresas.gxTpr_Alias;
            AV51CEP = AV69SdEmpresas.gxTpr_Address.gxTpr_Zip;
            AssignAttri("", false, "AV51CEP", AV51CEP);
            AV40Cliente.gxTpr_Enderecocep = AV69SdEmpresas.gxTpr_Address.gxTpr_Zip;
            AV40Cliente.gxTpr_Enderecobairro = StringUtil.Upper( AV69SdEmpresas.gxTpr_Address.gxTpr_District);
            AV40Cliente.gxTpr_Enderecocidade = StringUtil.Upper( AV69SdEmpresas.gxTpr_Address.gxTpr_City);
            AV40Cliente.gxTpr_Enderecocomplemento = AV69SdEmpresas.gxTpr_Address.gxTpr_Details;
            AV40Cliente.gxTpr_Enderecologradouro = StringUtil.Upper( AV69SdEmpresas.gxTpr_Address.gxTpr_Street);
            AV40Cliente.gxTpr_Endereconumero = AV69SdEmpresas.gxTpr_Address.gxTpr_Number;
            AV40Cliente.gxTpr_Enderecotipo = "COBRANCA";
            AV40Cliente.gxTpr_Municipiocodigo = StringUtil.Trim( StringUtil.Str( AV69SdEmpresas.gxTpr_Address.gxTpr_Municipality, 10, 5));
            AV54MunicipioUF = StringUtil.Upper( AV69SdEmpresas.gxTpr_Address.gxTpr_State);
            AssignAttri("", false, "AV54MunicipioUF", AV54MunicipioUF);
            if ( StringUtil.Len( ((SdtSdEmpresas_phonesItem)AV69SdEmpresas.gxTpr_Phones.Item(1)).gxTpr_Number) == 8 )
            {
               AV40Cliente.gxTpr_Contatotelefoneddd = (short)(Math.Round(NumberUtil.Val( ((SdtSdEmpresas_phonesItem)AV69SdEmpresas.gxTpr_Phones.Item(1)).gxTpr_Area, "."), 18, MidpointRounding.ToEven));
               AV40Cliente.gxTpr_Contatotelefonenumero = (long)(Math.Round(NumberUtil.Val( ((SdtSdEmpresas_phonesItem)AV69SdEmpresas.gxTpr_Phones.Item(1)).gxTpr_Number, "."), 18, MidpointRounding.ToEven));
            }
            else
            {
               AV40Cliente.gxTpr_Contatoddd = (short)(Math.Round(NumberUtil.Val( ((SdtSdEmpresas_phonesItem)AV69SdEmpresas.gxTpr_Phones.Item(1)).gxTpr_Area, "."), 18, MidpointRounding.ToEven));
               AV40Cliente.gxTpr_Contatonumero = (long)(Math.Round(NumberUtil.Val( ((SdtSdEmpresas_phonesItem)AV69SdEmpresas.gxTpr_Phones.Item(1)).gxTpr_Number, "."), 18, MidpointRounding.ToEven));
            }
            AV40Cliente.gxTpr_Contatoemail = ((SdtSdEmpresas_emailsItem)AV69SdEmpresas.gxTpr_Emails.Item(1)).gxTpr_Address;
            AV66Municipio.Load(StringUtil.Trim( StringUtil.Str( AV69SdEmpresas.gxTpr_Address.gxTpr_Municipality, 10, 5)));
            if ( AV66Municipio.Fail() )
            {
               AV66Municipio.gxTpr_Municipionome = StringUtil.Upper( AV69SdEmpresas.gxTpr_Address.gxTpr_City);
               AV66Municipio.gxTpr_Municipiouf = StringUtil.Upper( AV69SdEmpresas.gxTpr_Address.gxTpr_State);
               AV66Municipio.Save();
               if ( AV66Municipio.Success() )
               {
                  context.CommitDataStores("sacado",pr_default);
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV40Cliente", AV40Cliente);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV69SdEmpresas", AV69SdEmpresas);
      }

      protected void E16A32( )
      {
         /* Cep_Controlvaluechanged Routine */
         returnInSub = false;
         AV34MunicipioNome = "";
         AssignAttri("", false, "AV34MunicipioNome", AV34MunicipioNome);
         AV54MunicipioUF = "";
         AssignAttri("", false, "AV54MunicipioUF", AV54MunicipioUF);
         AV51CEP = StringUtil.StringReplace( AV51CEP, "-", "");
         AssignAttri("", false, "AV51CEP", AV51CEP);
         AV33EnderecoCompleto = new GeneXus.Programs.myobjects.viacep.SdtEnderecoCompleto(context);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51CEP)) )
         {
            new GeneXus.Programs.myobjects.viacep.cepparaendereco(context ).execute(  AV51CEP, out  AV31ModeloRetorno, out  AV32Mensagem) ;
            AV33EnderecoCompleto.FromJSonString(AV31ModeloRetorno, null);
            /* Execute user subroutine: 'VALIDACEP' */
            S182 ();
            if (returnInSub) return;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33EnderecoCompleto.gxTpr_Cep)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "",  "error",  edtavCliente_endereconumero_Internalname,  "true",  ""));
         }
         AV40Cliente.gxTpr_Enderecobairro = AV33EnderecoCompleto.gxTpr_Bairro;
         AV40Cliente.gxTpr_Enderecocidade = AV33EnderecoCompleto.gxTpr_Localidade;
         AV40Cliente.gxTpr_Enderecologradouro = AV33EnderecoCompleto.gxTpr_Logradouro;
         AV40Cliente.gxTpr_Municipiocodigo = AV33EnderecoCompleto.gxTpr_Ibge;
         AV34MunicipioNome = AV33EnderecoCompleto.gxTpr_Localidade;
         AssignAttri("", false, "AV34MunicipioNome", AV34MunicipioNome);
         AV54MunicipioUF = AV33EnderecoCompleto.gxTpr_Uf;
         AssignAttri("", false, "AV54MunicipioUF", AV54MunicipioUF);
         AV66Municipio.Load(AV40Cliente.gxTpr_Municipiocodigo);
         if ( AV66Municipio.Fail() )
         {
            AV66Municipio.gxTpr_Municipionome = AV33EnderecoCompleto.gxTpr_Localidade;
            AV66Municipio.gxTpr_Municipiouf = AV33EnderecoCompleto.gxTpr_Uf;
            AV66Municipio.Save();
            if ( AV66Municipio.Success() )
            {
               context.CommitDataStores("sacado",pr_default);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33EnderecoCompleto.gxTpr_Bairro)) )
         {
            edtavCliente_enderecobairro_Enabled = ((String.IsNullOrEmpty(StringUtil.RTrim( AV33EnderecoCompleto.gxTpr_Bairro)) ? true : false) ? 1 : 0);
            AssignProp("", false, edtavCliente_enderecobairro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCliente_enderecobairro_Enabled), 5, 0), true);
         }
         edtavCliente_enderecocidade_Enabled = ((String.IsNullOrEmpty(StringUtil.RTrim( AV33EnderecoCompleto.gxTpr_Localidade)) ? true : false) ? 1 : 0);
         AssignProp("", false, edtavCliente_enderecocidade_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCliente_enderecocidade_Enabled), 5, 0), true);
         edtavCliente_enderecologradouro_Enabled = ((String.IsNullOrEmpty(StringUtil.RTrim( AV33EnderecoCompleto.gxTpr_Logradouro)) ? true : false) ? 1 : 0);
         AssignProp("", false, edtavCliente_enderecologradouro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCliente_enderecologradouro_Enabled), 5, 0), true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV33EnderecoCompleto", AV33EnderecoCompleto);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV40Cliente", AV40Cliente);
      }

      protected void E17A32( )
      {
         /* Cliente_contatonumero_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'VALIDACELULAR' */
         S192 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E18A32( )
      {
         /* Cliente_contatotelefonenumero_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'VALIDATELEFONE' */
         S202 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S172( )
      {
         /* 'VALIDADOCUMENTO' Routine */
         returnInSub = false;
         GXt_char2 = "";
         new prvalidcpf(context ).execute(  AV40Cliente.gxTpr_Clientetipopessoa,  AV40Cliente.gxTpr_Clientedocumento, out  AV13IsOK, out  GXt_char2) ;
         AssignAttri("", false, "AV13IsOK", AV13IsOK);
         if ( ! AV13IsOK )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Documento inválido, verifique!",  "error",  edtavCliente_clientedocumento_Internalname,  "true",  ""));
            AV12CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV12CheckRequiredFieldsResult", AV12CheckRequiredFieldsResult);
         }
      }

      protected void S212( )
      {
         /* 'VALIDATIPOCLIENTE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV47TrnMode, "INS") == 0 )
         {
            if ( StringUtil.StrCmp(AV40Cliente.gxTpr_Clientetipopessoa, "FISICA") == 0 )
            {
               edtavCliente_clienterazaosocial_Caption = "Nome";
               AssignProp("", false, edtavCliente_clienterazaosocial_Internalname, "Caption", edtavCliente_clienterazaosocial_Caption, true);
               AV40Cliente.gxTpr_Clienterazaosocial = "";
               divTablenomefantasia_Visible = 0;
               AssignProp("", false, divTablenomefantasia_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablenomefantasia_Visible), 5, 0), true);
            }
            else
            {
               divTablenomefantasia_Visible = 1;
               AssignProp("", false, divTablenomefantasia_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablenomefantasia_Visible), 5, 0), true);
               edtavCliente_clienterazaosocial_Caption = "Razão Social";
               AssignProp("", false, edtavCliente_clienterazaosocial_Internalname, "Caption", edtavCliente_clienterazaosocial_Caption, true);
               AV40Cliente.gxTpr_Clienterazaosocial = "";
               AV40Cliente.gxTpr_Clientenomefantasia = "";
            }
         }
      }

      protected void S222( )
      {
         /* 'LOADCOMBOTIPOCLIENTEID' Routine */
         returnInSub = false;
         AV23TipoClienteId_Data.Clear();
      }

      protected void S182( )
      {
         /* 'VALIDACEP' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV33EnderecoCompleto.gxTpr_Cep)) && String.IsNullOrEmpty(StringUtil.RTrim( AV69SdEmpresas.gxTpr_Address.gxTpr_Zip)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "CEP não encontrado",  "error",  edtavCep_Internalname,  "true",  ""));
            AV12CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV12CheckRequiredFieldsResult", AV12CheckRequiredFieldsResult);
         }
      }

      protected void S192( )
      {
         /* 'VALIDACELULAR' Routine */
         returnInSub = false;
         if ( ! (0==AV40Cliente.gxTpr_Contatonumero) )
         {
            if ( StringUtil.Len( StringUtil.Trim( StringUtil.Str( (decimal)(AV40Cliente.gxTpr_Contatonumero), 18, 0))) != 9 )
            {
               GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Número de celular deve ter 9 dígitos",  "error",  edtavCliente_contatonumero_Internalname,  "true",  ""));
               AV12CheckRequiredFieldsResult = false;
               AssignAttri("", false, "AV12CheckRequiredFieldsResult", AV12CheckRequiredFieldsResult);
            }
            if ( (0==AV40Cliente.gxTpr_Contatoddd) )
            {
               GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Informe o DDD",  "error",  edtavCliente_contatoddd_Internalname,  "true",  ""));
               AV12CheckRequiredFieldsResult = false;
               AssignAttri("", false, "AV12CheckRequiredFieldsResult", AV12CheckRequiredFieldsResult);
            }
         }
      }

      protected void S202( )
      {
         /* 'VALIDATELEFONE' Routine */
         returnInSub = false;
         if ( ! (0==AV40Cliente.gxTpr_Contatotelefonenumero) )
         {
            if ( StringUtil.Len( StringUtil.Trim( StringUtil.Str( (decimal)(AV40Cliente.gxTpr_Contatotelefonenumero), 18, 0))) != 8 )
            {
               GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Número de telefone deve ter 8 dígitos",  "error",  edtavCliente_contatotelefonenumero_Internalname,  "true",  ""));
               AV12CheckRequiredFieldsResult = false;
               AssignAttri("", false, "AV12CheckRequiredFieldsResult", AV12CheckRequiredFieldsResult);
            }
            if ( (0==AV40Cliente.gxTpr_Contatotelefoneddd) )
            {
               GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Informe o DDD",  "error",  edtavCliente_contatotelefoneddd_Internalname,  "true",  ""));
               AV12CheckRequiredFieldsResult = false;
               AssignAttri("", false, "AV12CheckRequiredFieldsResult", AV12CheckRequiredFieldsResult);
            }
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E19A32( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table2_111_A32( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedcliente_contatotelefoneddd_Internalname, tblTablemergedcliente_contatotelefoneddd_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCliente_contatotelefoneddd_Internalname, "DDD", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 115,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCliente_contatotelefoneddd_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40Cliente.gxTpr_Contatotelefoneddd), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV40Cliente.gxTpr_Contatotelefoneddd), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,115);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "DDD", edtavCliente_contatotelefoneddd_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCliente_contatotelefoneddd_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Sacado.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='DataContentCellFL'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCliente_contatotelefonenumero_Internalname, "Número", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCliente_contatotelefonenumero_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40Cliente.gxTpr_Contatotelefonenumero), 18, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV40Cliente.gxTpr_Contatotelefonenumero), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,118);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Número", edtavCliente_contatotelefonenumero_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCliente_contatotelefonenumero_Enabled, 1, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Sacado.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_111_A32e( true) ;
         }
         else
         {
            wb_table2_111_A32e( false) ;
         }
      }

      protected void wb_table1_97_A32( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedcliente_contatoddd_Internalname, tblTablemergedcliente_contatoddd_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCliente_contatoddd_Internalname, "DDD", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCliente_contatoddd_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40Cliente.gxTpr_Contatoddd), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV40Cliente.gxTpr_Contatoddd), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,101);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "DDD", edtavCliente_contatoddd_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCliente_contatoddd_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Sacado.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='DataContentCellFL'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCliente_contatonumero_Internalname, "Número", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCliente_contatonumero_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40Cliente.gxTpr_Contatonumero), 18, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV40Cliente.gxTpr_Contatonumero), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,104);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Número", edtavCliente_contatonumero_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCliente_contatonumero_Enabled, 1, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Sacado.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_97_A32e( true) ;
         }
         else
         {
            wb_table1_97_A32e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV47TrnMode = (string)getParm(obj,0);
         AssignAttri("", false, "AV47TrnMode", AV47TrnMode);
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV47TrnMode, "")), context));
         AV50ClienteId = Convert.ToInt32(getParm(obj,1));
         AssignAttri("", false, "AV50ClienteId", StringUtil.LTrimStr( (decimal)(AV50ClienteId), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV50ClienteId), "ZZZZZZZZ9"), context));
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
         PAA32( ) ;
         WSA32( ) ;
         WEA32( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019293246", true, true);
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
         context.AddJavascriptSource("sacado.js", "?202561019293247", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavCliente_clientestatus.Name = "CLIENTE_CLIENTESTATUS";
         cmbavCliente_clientestatus.WebTags = "";
         cmbavCliente_clientestatus.addItem(StringUtil.BoolToStr( true), "ATIVO", 0);
         cmbavCliente_clientestatus.addItem(StringUtil.BoolToStr( false), "INATIVO", 0);
         if ( cmbavCliente_clientestatus.ItemCount > 0 )
         {
            AV40Cliente.gxTpr_Clientestatus = StringUtil.StrToBool( cmbavCliente_clientestatus.getValidValue(StringUtil.BoolToStr( AV40Cliente.gxTpr_Clientestatus)));
         }
         cmbavCliente_clientepixtipo.Name = "CLIENTE_CLIENTEPIXTIPO";
         cmbavCliente_clientepixtipo.WebTags = "";
         cmbavCliente_clientepixtipo.addItem("CPF", "CPF", 0);
         cmbavCliente_clientepixtipo.addItem("CNPJ", "CNPJ", 0);
         cmbavCliente_clientepixtipo.addItem("Telefone", "Telefone", 0);
         cmbavCliente_clientepixtipo.addItem("Email", "E-mail", 0);
         cmbavCliente_clientepixtipo.addItem("ChaveAleatoria", "Chave aleatória", 0);
         if ( cmbavCliente_clientepixtipo.ItemCount > 0 )
         {
            AV40Cliente.gxTpr_Clientepixtipo = cmbavCliente_clientepixtipo.getValidValue(AV40Cliente.gxTpr_Clientepixtipo);
         }
         cmbavCliente_clientetipopessoa.Name = "CLIENTE_CLIENTETIPOPESSOA";
         cmbavCliente_clientetipopessoa.WebTags = "";
         cmbavCliente_clientetipopessoa.addItem("FISICA", "Física", 0);
         cmbavCliente_clientetipopessoa.addItem("JURIDICA", "Jurídica", 0);
         if ( cmbavCliente_clientetipopessoa.ItemCount > 0 )
         {
            AV40Cliente.gxTpr_Clientetipopessoa = cmbavCliente_clientetipopessoa.getValidValue(AV40Cliente.gxTpr_Clientetipopessoa);
         }
         cmbavCliente_enderecotipo.Name = "CLIENTE_ENDERECOTIPO";
         cmbavCliente_enderecotipo.WebTags = "";
         cmbavCliente_enderecotipo.addItem("COBRANCA", "Cobrança", 0);
         cmbavCliente_enderecotipo.addItem("ENTREGA", "Entrega", 0);
         if ( cmbavCliente_enderecotipo.ItemCount > 0 )
         {
            AV40Cliente.gxTpr_Enderecotipo = cmbavCliente_enderecotipo.getValidValue(AV40Cliente.gxTpr_Enderecotipo);
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTabinformacoes_title_Internalname = "TABINFORMACOES_TITLE";
         edtavCliente_clientedocumento_Internalname = "CLIENTE_CLIENTEDOCUMENTO";
         edtavCliente_clienterazaosocial_Internalname = "CLIENTE_CLIENTERAZAOSOCIAL";
         edtavCliente_clientenomefantasia_Internalname = "CLIENTE_CLIENTENOMEFANTASIA";
         divTablenomefantasia_Internalname = "TABLENOMEFANTASIA";
         cmbavCliente_clientestatus_Internalname = "CLIENTE_CLIENTESTATUS";
         divCliente_clientestatus_cell_Internalname = "CLIENTE_CLIENTESTATUS_CELL";
         edtavCep_Internalname = "vCEP";
         edtavCliente_enderecologradouro_Internalname = "CLIENTE_ENDERECOLOGRADOURO";
         edtavCliente_endereconumero_Internalname = "CLIENTE_ENDERECONUMERO";
         edtavCliente_enderecocomplemento_Internalname = "CLIENTE_ENDERECOCOMPLEMENTO";
         edtavCliente_enderecobairro_Internalname = "CLIENTE_ENDERECOBAIRRO";
         edtavCliente_enderecocidade_Internalname = "CLIENTE_ENDERECOCIDADE";
         edtavMunicipiouf_Internalname = "vMUNICIPIOUF";
         divTableendereco_Internalname = "TABLEENDERECO";
         grpUnnamedgroup2_Internalname = "UNNAMEDGROUP2";
         edtavCliente_contatoemail_Internalname = "CLIENTE_CONTATOEMAIL";
         lblTextblockcliente_contatoddd_Internalname = "TEXTBLOCKCLIENTE_CONTATODDD";
         edtavCliente_contatoddd_Internalname = "CLIENTE_CONTATODDD";
         edtavCliente_contatonumero_Internalname = "CLIENTE_CONTATONUMERO";
         tblTablemergedcliente_contatoddd_Internalname = "TABLEMERGEDCLIENTE_CONTATODDD";
         divTablesplittedcliente_contatoddd_Internalname = "TABLESPLITTEDCLIENTE_CONTATODDD";
         lblTextblockcliente_contatotelefoneddd_Internalname = "TEXTBLOCKCLIENTE_CONTATOTELEFONEDDD";
         edtavCliente_contatotelefoneddd_Internalname = "CLIENTE_CONTATOTELEFONEDDD";
         edtavCliente_contatotelefonenumero_Internalname = "CLIENTE_CONTATOTELEFONENUMERO";
         tblTablemergedcliente_contatotelefoneddd_Internalname = "TABLEMERGEDCLIENTE_CONTATOTELEFONEDDD";
         divTablesplittedcliente_contatotelefoneddd_Internalname = "TABLESPLITTEDCLIENTE_CONTATOTELEFONEDDD";
         divTablecontato_Internalname = "TABLECONTATO";
         grpUnnamedgroup3_Internalname = "UNNAMEDGROUP3";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         divTableinfo_Internalname = "TABLEINFO";
         lblTabcontabancaria_title_Internalname = "TABCONTABANCARIA_TITLE";
         lblTextblockcombo_cliente_bancoid_Internalname = "TEXTBLOCKCOMBO_CLIENTE_BANCOID";
         Combo_cliente_bancoid_Internalname = "COMBO_CLIENTE_BANCOID";
         divTablesplittedcliente_bancoid_Internalname = "TABLESPLITTEDCLIENTE_BANCOID";
         edtavCliente_contaagencia_Internalname = "CLIENTE_CONTAAGENCIA";
         edtavCliente_contanumero_Internalname = "CLIENTE_CONTANUMERO";
         cmbavCliente_clientepixtipo_Internalname = "CLIENTE_CLIENTEPIXTIPO";
         edtavCliente_clientepix_Internalname = "CLIENTE_CLIENTEPIX";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         Gxuitabspanel_tabs1_Internalname = "GXUITABSPANEL_TABS1";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         cmbavCliente_clientetipopessoa_Internalname = "CLIENTE_CLIENTETIPOPESSOA";
         edtavCliente_tipoclienteid_Internalname = "CLIENTE_TIPOCLIENTEID";
         edtavCliente_clienteid_Internalname = "CLIENTE_CLIENTEID";
         edtavCliente_clientecreatedat_Internalname = "CLIENTE_CLIENTECREATEDAT";
         edtavCliente_clienteupdatedat_Internalname = "CLIENTE_CLIENTEUPDATEDAT";
         edtavCliente_clienteloguser_Internalname = "CLIENTE_CLIENTELOGUSER";
         cmbavCliente_enderecotipo_Internalname = "CLIENTE_ENDERECOTIPO";
         edtavCliente_enderecocep_Internalname = "CLIENTE_ENDERECOCEP";
         edtavCliente_municipiocodigo_Internalname = "CLIENTE_MUNICIPIOCODIGO";
         edtavMunicipionome_Internalname = "vMUNICIPIONOME";
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
         edtavCliente_contatonumero_Jsonclick = "";
         edtavCliente_contatonumero_Enabled = 1;
         edtavCliente_contatoddd_Jsonclick = "";
         edtavCliente_contatoddd_Enabled = 1;
         edtavCliente_contatotelefonenumero_Jsonclick = "";
         edtavCliente_contatotelefonenumero_Enabled = 1;
         edtavCliente_contatotelefoneddd_Jsonclick = "";
         edtavCliente_contatotelefoneddd_Enabled = 1;
         edtavCliente_clienterazaosocial_Caption = "Razão social";
         edtavCliente_clientenomefantasia_Enabled = 1;
         edtavCliente_enderecocidade_Enabled = 1;
         edtavCliente_enderecobairro_Enabled = 1;
         edtavCliente_enderecocomplemento_Enabled = 1;
         edtavCliente_endereconumero_Enabled = 1;
         edtavCliente_enderecologradouro_Enabled = 1;
         edtavCliente_contatotelefonenumero_Enabled = 1;
         edtavCliente_contatotelefoneddd_Enabled = 1;
         edtavCliente_contatonumero_Enabled = 1;
         edtavCliente_contatoddd_Enabled = 1;
         edtavCliente_contatoemail_Enabled = 1;
         cmbavCliente_clientestatus.Enabled = 1;
         edtavCliente_clienterazaosocial_Enabled = 1;
         edtavCliente_clientedocumento_Enabled = 1;
         edtavCliente_clientepix_Enabled = 1;
         cmbavCliente_clientepixtipo.Enabled = 1;
         edtavCliente_contanumero_Enabled = 1;
         edtavCliente_contaagencia_Enabled = 1;
         edtavMunicipionome_Jsonclick = "";
         edtavMunicipionome_Visible = 1;
         edtavCliente_municipiocodigo_Jsonclick = "";
         edtavCliente_municipiocodigo_Visible = 1;
         edtavCliente_enderecocep_Jsonclick = "";
         edtavCliente_enderecocep_Visible = 1;
         cmbavCliente_enderecotipo_Jsonclick = "";
         cmbavCliente_enderecotipo.Visible = 1;
         edtavCliente_clienteloguser_Jsonclick = "";
         edtavCliente_clienteloguser_Visible = 1;
         edtavCliente_clienteupdatedat_Jsonclick = "";
         edtavCliente_clienteupdatedat_Visible = 1;
         edtavCliente_clientecreatedat_Jsonclick = "";
         edtavCliente_clientecreatedat_Visible = 1;
         edtavCliente_clienteid_Jsonclick = "";
         edtavCliente_clienteid_Visible = 1;
         edtavCliente_tipoclienteid_Jsonclick = "";
         edtavCliente_tipoclienteid_Visible = 1;
         cmbavCliente_clientetipopessoa_Jsonclick = "";
         cmbavCliente_clientetipopessoa.Visible = 1;
         bttBtnenter_Visible = 1;
         edtavCliente_clientepix_Jsonclick = "";
         edtavCliente_clientepix_Enabled = 1;
         cmbavCliente_clientepixtipo_Jsonclick = "";
         cmbavCliente_clientepixtipo.Enabled = 1;
         edtavCliente_contanumero_Jsonclick = "";
         edtavCliente_contanumero_Enabled = 1;
         edtavCliente_contaagencia_Jsonclick = "";
         edtavCliente_contaagencia_Enabled = 1;
         edtavCliente_contatoemail_Jsonclick = "";
         edtavCliente_contatoemail_Enabled = 1;
         edtavMunicipiouf_Jsonclick = "";
         edtavMunicipiouf_Enabled = 1;
         edtavCliente_enderecocidade_Jsonclick = "";
         edtavCliente_enderecocidade_Enabled = 1;
         edtavCliente_enderecobairro_Jsonclick = "";
         edtavCliente_enderecobairro_Enabled = 1;
         edtavCliente_enderecocomplemento_Jsonclick = "";
         edtavCliente_enderecocomplemento_Enabled = 1;
         edtavCliente_endereconumero_Jsonclick = "";
         edtavCliente_endereconumero_Enabled = 1;
         edtavCliente_enderecologradouro_Jsonclick = "";
         edtavCliente_enderecologradouro_Enabled = 1;
         edtavCep_Jsonclick = "";
         edtavCep_Enabled = 1;
         cmbavCliente_clientestatus_Jsonclick = "";
         cmbavCliente_clientestatus.Enabled = 1;
         cmbavCliente_clientestatus.Visible = 1;
         divCliente_clientestatus_cell_Class = "col-xs-12 col-sm-2";
         edtavCliente_clientenomefantasia_Jsonclick = "";
         edtavCliente_clientenomefantasia_Enabled = 1;
         divTablenomefantasia_Visible = 1;
         edtavCliente_clienterazaosocial_Jsonclick = "";
         edtavCliente_clienterazaosocial_Enabled = 1;
         edtavCliente_clienterazaosocial_Caption = "Razão social";
         edtavCliente_clientedocumento_Jsonclick = "";
         edtavCliente_clientedocumento_Enabled = 1;
         Gxuitabspanel_tabs1_Historymanagement = Convert.ToBoolean( 0);
         Gxuitabspanel_tabs1_Class = "Tab";
         Gxuitabspanel_tabs1_Pagecount = 2;
         Combo_cliente_bancoid_Emptyitem = Convert.ToBoolean( 0);
         Combo_cliente_bancoid_Enabled = Convert.ToBoolean( -1);
         Combo_cliente_bancoid_Cls = "ExtendedCombo AttributeFL";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Cliente";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV47TrnMode","fld":"vTRNMODE","hsh":true,"type":"char"},{"av":"AV41WWPContext","fld":"vWWPCONTEXT","hsh":true,"type":""},{"av":"AV50ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"ctrl":"BTNENTER","prop":"Visible"}]}""");
         setEventMetadata("COMBO_CLIENTE_BANCOID.ONOPTIONCLICKED","""{"handler":"E11A32","iparms":[{"av":"Combo_cliente_bancoid_Selectedvalue_get","ctrl":"COMBO_CLIENTE_BANCOID","prop":"SelectedValue_get"},{"av":"AV40Cliente","fld":"vCLIENTE","type":""}]""");
         setEventMetadata("COMBO_CLIENTE_BANCOID.ONOPTIONCLICKED",""","oparms":[{"av":"AV40Cliente","fld":"vCLIENTE","type":""}]}""");
         setEventMetadata("ENTER","""{"handler":"E14A32","iparms":[{"av":"AV40Cliente","fld":"vCLIENTE","type":""},{"av":"AV47TrnMode","fld":"vTRNMODE","hsh":true,"type":"char"},{"av":"AV12CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"},{"av":"A169ClienteDocumento","fld":"CLIENTEDOCUMENTO","type":"svchar"},{"av":"A1030ClienteSacado","fld":"CLIENTESACADO","type":"boolean"},{"av":"A168ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV51CEP","fld":"vCEP","type":"svchar"},{"av":"A192TipoClienteId","fld":"TIPOCLIENTEID","pic":"ZZZ9","type":"int"},{"av":"AV67AuxCliente","fld":"vAUXCLIENTE","type":""},{"av":"A207TipoClientePortal","fld":"TIPOCLIENTEPORTAL","type":"boolean"},{"av":"AV41WWPContext","fld":"vWWPCONTEXT","hsh":true,"type":""},{"av":"AV43SdErro","fld":"vSDERRO","type":""},{"av":"AV46Messages","fld":"vMESSAGES","type":""},{"av":"AV33EnderecoCompleto","fld":"vENDERECOCOMPLETO","type":""},{"av":"AV69SdEmpresas","fld":"vSDEMPRESAS","type":""}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV67AuxCliente","fld":"vAUXCLIENTE","type":""},{"av":"AV40Cliente","fld":"vCLIENTE","type":""},{"av":"AV46Messages","fld":"vMESSAGES","type":""},{"av":"AV12CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"},{"av":"AV43SdErro","fld":"vSDERRO","type":""},{"av":"AV13IsOK","fld":"vISOK","type":"boolean"}]}""");
         setEventMetadata("CLIENTE_CLIENTEDOCUMENTO.CONTROLVALUECHANGED","""{"handler":"E15A32","iparms":[{"av":"AV40Cliente","fld":"vCLIENTE","type":""},{"av":"AV13IsOK","fld":"vISOK","type":"boolean"}]""");
         setEventMetadata("CLIENTE_CLIENTEDOCUMENTO.CONTROLVALUECHANGED",""","oparms":[{"av":"AV40Cliente","fld":"vCLIENTE","type":""},{"av":"AV69SdEmpresas","fld":"vSDEMPRESAS","type":""},{"av":"AV51CEP","fld":"vCEP","type":"svchar"},{"av":"AV54MunicipioUF","fld":"vMUNICIPIOUF","pic":"@!","type":"svchar"},{"av":"AV13IsOK","fld":"vISOK","type":"boolean"},{"av":"AV12CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"}]}""");
         setEventMetadata("VCEP.CONTROLVALUECHANGED","""{"handler":"E16A32","iparms":[{"av":"AV51CEP","fld":"vCEP","type":"svchar"},{"av":"AV40Cliente","fld":"vCLIENTE","type":""},{"av":"AV33EnderecoCompleto","fld":"vENDERECOCOMPLETO","type":""},{"av":"AV69SdEmpresas","fld":"vSDEMPRESAS","type":""}]""");
         setEventMetadata("VCEP.CONTROLVALUECHANGED",""","oparms":[{"av":"AV34MunicipioNome","fld":"vMUNICIPIONOME","pic":"@!","type":"svchar"},{"av":"AV54MunicipioUF","fld":"vMUNICIPIOUF","pic":"@!","type":"svchar"},{"av":"AV51CEP","fld":"vCEP","type":"svchar"},{"av":"AV33EnderecoCompleto","fld":"vENDERECOCOMPLETO","type":""},{"av":"AV40Cliente","fld":"vCLIENTE","type":""},{"ctrl":"CLIENTE_ENDERECOBAIRRO","prop":"Enabled"},{"ctrl":"CLIENTE_ENDERECOCIDADE","prop":"Enabled"},{"ctrl":"CLIENTE_ENDERECOLOGRADOURO","prop":"Enabled"},{"av":"AV12CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"}]}""");
         setEventMetadata("CLIENTE_CONTATONUMERO.CONTROLVALUECHANGED","""{"handler":"E17A32","iparms":[{"av":"AV40Cliente","fld":"vCLIENTE","type":""}]""");
         setEventMetadata("CLIENTE_CONTATONUMERO.CONTROLVALUECHANGED",""","oparms":[{"av":"AV12CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"}]}""");
         setEventMetadata("CLIENTE_CONTATOTELEFONENUMERO.CONTROLVALUECHANGED","""{"handler":"E18A32","iparms":[{"av":"AV40Cliente","fld":"vCLIENTE","type":""}]""");
         setEventMetadata("CLIENTE_CONTATOTELEFONENUMERO.CONTROLVALUECHANGED",""","oparms":[{"av":"AV12CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"}]}""");
         setEventMetadata("VALIDV_GXV10","""{"handler":"Validv_Gxv10","iparms":[]}""");
         setEventMetadata("VALIDV_GXV17","""{"handler":"Validv_Gxv17","iparms":[]}""");
         setEventMetadata("VALIDV_GXV19","""{"handler":"Validv_Gxv19","iparms":[]}""");
         setEventMetadata("VALIDV_GXV25","""{"handler":"Validv_Gxv25","iparms":[]}""");
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
         wcpOAV47TrnMode = "";
         Combo_cliente_bancoid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV41WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV40Cliente = new SdtCliente(context);
         AV61Cliente_BancoId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A169ClienteDocumento = "";
         AV67AuxCliente = new SdtCliente(context);
         AV43SdErro = new SdtSdErro(context);
         AV46Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV33EnderecoCompleto = new GeneXus.Programs.myobjects.viacep.SdtEnderecoCompleto(context);
         AV69SdEmpresas = new SdtSdEmpresas(context);
         Combo_cliente_bancoid_Selectedvalue_set = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucGxuitabspanel_tabs1 = new GXUserControl();
         lblTabinformacoes_title_Jsonclick = "";
         TempTags = "";
         AV51CEP = "";
         AV54MunicipioUF = "";
         lblTextblockcliente_contatoddd_Jsonclick = "";
         lblTextblockcliente_contatotelefoneddd_Jsonclick = "";
         lblTabcontabancaria_title_Jsonclick = "";
         lblTextblockcombo_cliente_bancoid_Jsonclick = "";
         ucCombo_cliente_bancoid = new GXUserControl();
         Combo_cliente_bancoid_Caption = "";
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         AV34MunicipioNome = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         GXt_SdtWWPContext1 = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         H00A33_A169ClienteDocumento = new string[] {""} ;
         H00A33_n169ClienteDocumento = new bool[] {false} ;
         H00A33_A168ClienteId = new int[1] ;
         H00A33_n168ClienteId = new bool[] {false} ;
         H00A33_A1031RelacionamentoSacado = new short[1] ;
         H00A33_n1031RelacionamentoSacado = new bool[] {false} ;
         AV70Relacionamento = new SdtRelacionamento(context);
         H00A34_A402BancoId = new int[1] ;
         H00A34_A403BancoNome = new string[] {""} ;
         H00A34_n403BancoNome = new bool[] {false} ;
         A403BancoNome = "";
         AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV45Message = new GeneXus.Utils.SdtMessages_Message(context);
         H00A35_A192TipoClienteId = new short[1] ;
         H00A35_A207TipoClientePortal = new bool[] {false} ;
         H00A35_n207TipoClientePortal = new bool[] {false} ;
         AV68EmpresaCNPJ = "";
         AV66Municipio = new SdtMunicipio(context);
         AV31ModeloRetorno = "";
         AV32Mensagem = "";
         GXt_char2 = "";
         AV23TipoClienteId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         sStyleString = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.sacado__default(),
            new Object[][] {
                new Object[] {
               H00A33_A169ClienteDocumento, H00A33_n169ClienteDocumento, H00A33_A168ClienteId, H00A33_A1031RelacionamentoSacado, H00A33_n1031RelacionamentoSacado
               }
               , new Object[] {
               H00A34_A402BancoId, H00A34_A403BancoNome, H00A34_n403BancoNome
               }
               , new Object[] {
               H00A35_A192TipoClienteId, H00A35_A207TipoClientePortal, H00A35_n207TipoClientePortal
               }
            }
         );
         /* GeneXus formulas. */
         edtavMunicipiouf_Enabled = 0;
      }

      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short A192TipoClienteId ;
      private short A1031RelacionamentoSacado ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short AV98GXLvl128 ;
      private short GXt_int3 ;
      private short nGXWrapped ;
      private int AV50ClienteId ;
      private int wcpOAV50ClienteId ;
      private int A168ClienteId ;
      private int Gxuitabspanel_tabs1_Pagecount ;
      private int edtavCliente_clientedocumento_Enabled ;
      private int edtavCliente_clienterazaosocial_Enabled ;
      private int divTablenomefantasia_Visible ;
      private int edtavCliente_clientenomefantasia_Enabled ;
      private int edtavCep_Enabled ;
      private int edtavCliente_enderecologradouro_Enabled ;
      private int edtavCliente_endereconumero_Enabled ;
      private int edtavCliente_enderecocomplemento_Enabled ;
      private int edtavCliente_enderecobairro_Enabled ;
      private int edtavCliente_enderecocidade_Enabled ;
      private int edtavMunicipiouf_Enabled ;
      private int edtavCliente_contatoemail_Enabled ;
      private int edtavCliente_contaagencia_Enabled ;
      private int edtavCliente_contanumero_Enabled ;
      private int edtavCliente_clientepix_Enabled ;
      private int bttBtnenter_Visible ;
      private int edtavCliente_tipoclienteid_Visible ;
      private int edtavCliente_clienteid_Visible ;
      private int edtavCliente_clientecreatedat_Visible ;
      private int edtavCliente_clienteupdatedat_Visible ;
      private int edtavCliente_clienteloguser_Visible ;
      private int edtavCliente_enderecocep_Visible ;
      private int edtavCliente_municipiocodigo_Visible ;
      private int edtavMunicipionome_Visible ;
      private int edtavCliente_contatoddd_Enabled ;
      private int edtavCliente_contatonumero_Enabled ;
      private int edtavCliente_contatotelefoneddd_Enabled ;
      private int edtavCliente_contatotelefonenumero_Enabled ;
      private int A402BancoId ;
      private int AV100GXV28 ;
      private int idxLst ;
      private string AV47TrnMode ;
      private string wcpOAV47TrnMode ;
      private string Combo_cliente_bancoid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Combo_cliente_bancoid_Cls ;
      private string Combo_cliente_bancoid_Selectedvalue_set ;
      private string Gxuitabspanel_tabs1_Class ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Gxuitabspanel_tabs1_Internalname ;
      private string lblTabinformacoes_title_Internalname ;
      private string lblTabinformacoes_title_Jsonclick ;
      private string divTableinfo_Internalname ;
      private string divTableattributes_Internalname ;
      private string edtavCliente_clientedocumento_Internalname ;
      private string TempTags ;
      private string edtavCliente_clientedocumento_Jsonclick ;
      private string edtavCliente_clienterazaosocial_Internalname ;
      private string edtavCliente_clienterazaosocial_Caption ;
      private string edtavCliente_clienterazaosocial_Jsonclick ;
      private string divTablenomefantasia_Internalname ;
      private string edtavCliente_clientenomefantasia_Internalname ;
      private string edtavCliente_clientenomefantasia_Jsonclick ;
      private string divCliente_clientestatus_cell_Internalname ;
      private string divCliente_clientestatus_cell_Class ;
      private string cmbavCliente_clientestatus_Internalname ;
      private string cmbavCliente_clientestatus_Jsonclick ;
      private string grpUnnamedgroup2_Internalname ;
      private string divTableendereco_Internalname ;
      private string edtavCep_Internalname ;
      private string edtavCep_Jsonclick ;
      private string edtavCliente_enderecologradouro_Internalname ;
      private string edtavCliente_enderecologradouro_Jsonclick ;
      private string edtavCliente_endereconumero_Internalname ;
      private string edtavCliente_endereconumero_Jsonclick ;
      private string edtavCliente_enderecocomplemento_Internalname ;
      private string edtavCliente_enderecocomplemento_Jsonclick ;
      private string edtavCliente_enderecobairro_Internalname ;
      private string edtavCliente_enderecobairro_Jsonclick ;
      private string edtavCliente_enderecocidade_Internalname ;
      private string edtavCliente_enderecocidade_Jsonclick ;
      private string edtavMunicipiouf_Internalname ;
      private string edtavMunicipiouf_Jsonclick ;
      private string grpUnnamedgroup3_Internalname ;
      private string divTablecontato_Internalname ;
      private string edtavCliente_contatoemail_Internalname ;
      private string edtavCliente_contatoemail_Jsonclick ;
      private string divTablesplittedcliente_contatoddd_Internalname ;
      private string lblTextblockcliente_contatoddd_Internalname ;
      private string lblTextblockcliente_contatoddd_Jsonclick ;
      private string divTablesplittedcliente_contatotelefoneddd_Internalname ;
      private string lblTextblockcliente_contatotelefoneddd_Internalname ;
      private string lblTextblockcliente_contatotelefoneddd_Jsonclick ;
      private string lblTabcontabancaria_title_Internalname ;
      private string lblTabcontabancaria_title_Jsonclick ;
      private string divUnnamedtable1_Internalname ;
      private string divTablesplittedcliente_bancoid_Internalname ;
      private string lblTextblockcombo_cliente_bancoid_Internalname ;
      private string lblTextblockcombo_cliente_bancoid_Jsonclick ;
      private string Combo_cliente_bancoid_Caption ;
      private string Combo_cliente_bancoid_Internalname ;
      private string edtavCliente_contaagencia_Internalname ;
      private string edtavCliente_contaagencia_Jsonclick ;
      private string edtavCliente_contanumero_Internalname ;
      private string edtavCliente_contanumero_Jsonclick ;
      private string cmbavCliente_clientepixtipo_Internalname ;
      private string cmbavCliente_clientepixtipo_Jsonclick ;
      private string edtavCliente_clientepix_Internalname ;
      private string edtavCliente_clientepix_Jsonclick ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string cmbavCliente_clientetipopessoa_Internalname ;
      private string cmbavCliente_clientetipopessoa_Jsonclick ;
      private string edtavCliente_tipoclienteid_Internalname ;
      private string edtavCliente_tipoclienteid_Jsonclick ;
      private string edtavCliente_clienteid_Internalname ;
      private string edtavCliente_clienteid_Jsonclick ;
      private string edtavCliente_clientecreatedat_Internalname ;
      private string edtavCliente_clientecreatedat_Jsonclick ;
      private string edtavCliente_clienteupdatedat_Internalname ;
      private string edtavCliente_clienteupdatedat_Jsonclick ;
      private string edtavCliente_clienteloguser_Internalname ;
      private string edtavCliente_clienteloguser_Jsonclick ;
      private string cmbavCliente_enderecotipo_Internalname ;
      private string cmbavCliente_enderecotipo_Jsonclick ;
      private string edtavCliente_enderecocep_Internalname ;
      private string edtavCliente_enderecocep_Jsonclick ;
      private string edtavCliente_municipiocodigo_Internalname ;
      private string edtavCliente_municipiocodigo_Jsonclick ;
      private string edtavMunicipionome_Internalname ;
      private string edtavMunicipionome_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string edtavCliente_contatoddd_Internalname ;
      private string edtavCliente_contatonumero_Internalname ;
      private string edtavCliente_contatotelefoneddd_Internalname ;
      private string edtavCliente_contatotelefonenumero_Internalname ;
      private string GXt_char2 ;
      private string sStyleString ;
      private string tblTablemergedcliente_contatotelefoneddd_Internalname ;
      private string edtavCliente_contatotelefoneddd_Jsonclick ;
      private string edtavCliente_contatotelefonenumero_Jsonclick ;
      private string tblTablemergedcliente_contatoddd_Internalname ;
      private string edtavCliente_contatoddd_Jsonclick ;
      private string edtavCliente_contatonumero_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV12CheckRequiredFieldsResult ;
      private bool A207TipoClientePortal ;
      private bool AV13IsOK ;
      private bool A1030ClienteSacado ;
      private bool Combo_cliente_bancoid_Enabled ;
      private bool Combo_cliente_bancoid_Emptyitem ;
      private bool Gxuitabspanel_tabs1_Historymanagement ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV48LoadSuccess ;
      private bool n169ClienteDocumento ;
      private bool n168ClienteId ;
      private bool n1031RelacionamentoSacado ;
      private bool n403BancoNome ;
      private bool AV65IsContinue ;
      private bool AV53TipoClientePortal ;
      private bool n207TipoClientePortal ;
      private string AV31ModeloRetorno ;
      private string A169ClienteDocumento ;
      private string AV51CEP ;
      private string AV54MunicipioUF ;
      private string AV34MunicipioNome ;
      private string A403BancoNome ;
      private string AV68EmpresaCNPJ ;
      private string AV32Mensagem ;
      private GXUserControl ucGxuitabspanel_tabs1 ;
      private GXUserControl ucCombo_cliente_bancoid ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavCliente_clientestatus ;
      private GXCombobox cmbavCliente_clientepixtipo ;
      private GXCombobox cmbavCliente_clientetipopessoa ;
      private GXCombobox cmbavCliente_enderecotipo ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV41WWPContext ;
      private SdtCliente AV40Cliente ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV61Cliente_BancoId_Data ;
      private SdtCliente AV67AuxCliente ;
      private SdtSdErro AV43SdErro ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV46Messages ;
      private GeneXus.Programs.myobjects.viacep.SdtEnderecoCompleto AV33EnderecoCompleto ;
      private SdtSdEmpresas AV69SdEmpresas ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext GXt_SdtWWPContext1 ;
      private IDataStoreProvider pr_default ;
      private string[] H00A33_A169ClienteDocumento ;
      private bool[] H00A33_n169ClienteDocumento ;
      private int[] H00A33_A168ClienteId ;
      private bool[] H00A33_n168ClienteId ;
      private short[] H00A33_A1031RelacionamentoSacado ;
      private bool[] H00A33_n1031RelacionamentoSacado ;
      private SdtRelacionamento AV70Relacionamento ;
      private int[] H00A34_A402BancoId ;
      private string[] H00A34_A403BancoNome ;
      private bool[] H00A34_n403BancoNome ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV16Combo_DataItem ;
      private GeneXus.Utils.SdtMessages_Message AV45Message ;
      private short[] H00A35_A192TipoClienteId ;
      private bool[] H00A35_A207TipoClientePortal ;
      private bool[] H00A35_n207TipoClientePortal ;
      private SdtMunicipio AV66Municipio ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV23TipoClienteId_Data ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class sacado__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00A33;
          prmH00A33 = new Object[] {
          new ParDef("AV40Cliente__Clientedocumento",GXType.VarChar,20,0)
          };
          Object[] prmH00A34;
          prmH00A34 = new Object[] {
          };
          Object[] prmH00A35;
          prmH00A35 = new Object[] {
          new ParDef("AV67AuxCliente__Tipoclienteid",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00A33", "SELECT T1.ClienteDocumento, T1.ClienteId, COALESCE( T2.RelacionamentoSacado, 0) AS RelacionamentoSacado FROM (Cliente T1 LEFT JOIN LATERAL (SELECT COUNT(*) AS RelacionamentoSacado, ClienteId FROM Relacionamento WHERE (T1.ClienteId = ClienteId) AND (RelacionamentoTipo = ( 'Sacado')) GROUP BY ClienteId ) T2 ON T2.ClienteId = T1.ClienteId) WHERE T1.ClienteDocumento = ( :AV40Cliente__Clientedocumento) ORDER BY T1.ClienteDocumento ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00A33,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H00A34", "SELECT BancoId, BancoNome FROM Banco ORDER BY BancoNome ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00A34,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00A35", "SELECT TipoClienteId, TipoClientePortal FROM TipoCliente WHERE TipoClienteId = :AV67AuxCliente__Tipoclienteid ORDER BY TipoClienteId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00A35,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
       }
    }

 }

}
