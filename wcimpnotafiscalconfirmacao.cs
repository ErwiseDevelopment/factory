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
   public class wcimpnotafiscalconfirmacao : GXWebComponent
   {
      public wcimpnotafiscalconfirmacao( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
      }

      public wcimpnotafiscalconfirmacao( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_WebSessionKey ,
                           string aP1_PreviousStep ,
                           bool aP2_GoingBack )
      {
         this.AV6WebSessionKey = aP0_WebSessionKey;
         this.AV8PreviousStep = aP1_PreviousStep;
         this.AV7GoingBack = aP2_GoingBack;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
         cmbavPropostastatus = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "WebSessionKey");
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetPar( "sCompPrefix");
                  sSFPrefix = GetPar( "sSFPrefix");
                  AV6WebSessionKey = GetPar( "WebSessionKey");
                  AssignAttri(sPrefix, false, "AV6WebSessionKey", AV6WebSessionKey);
                  AV8PreviousStep = GetPar( "PreviousStep");
                  AssignAttri(sPrefix, false, "AV8PreviousStep", AV8PreviousStep);
                  AV7GoingBack = StringUtil.StrToBool( GetPar( "GoingBack"));
                  AssignAttri(sPrefix, false, "AV7GoingBack", AV7GoingBack);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV6WebSessionKey,(string)AV8PreviousStep,(bool)AV7GoingBack});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
                  gxfirstwebparm = GetFirstPar( "WebSessionKey");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "WebSessionKey");
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
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA8S2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavPropostaprotocolo_Enabled = 0;
               AssignProp(sPrefix, false, edtavPropostaprotocolo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPropostaprotocolo_Enabled), 5, 0), true);
               edtavPropostacreatedat_Enabled = 0;
               AssignProp(sPrefix, false, edtavPropostacreatedat_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPropostacreatedat_Enabled), 5, 0), true);
               edtavQuantidadeitens_Enabled = 0;
               AssignProp(sPrefix, false, edtavQuantidadeitens_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavQuantidadeitens_Enabled), 5, 0), true);
               edtavPropostavalor_Enabled = 0;
               AssignProp(sPrefix, false, edtavPropostavalor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPropostavalor_Enabled), 5, 0), true);
               cmbavPropostastatus.Enabled = 0;
               AssignProp(sPrefix, false, cmbavPropostastatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavPropostastatus.Enabled), 5, 0), true);
               WS8S2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
            }
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

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( "Wc Imp Nota Fiscal Confirmacao") ;
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
         }
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
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
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wcimpnotafiscalconfirmacao"+UrlEncode(StringUtil.RTrim(AV6WebSessionKey)) + "," + UrlEncode(StringUtil.RTrim(AV8PreviousStep)) + "," + UrlEncode(StringUtil.BoolToStr(AV7GoingBack));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wcimpnotafiscalconfirmacao") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPROPOSTAPROTOCOLO", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV12PropostaProtocolo, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPROPOSTACREATEDAT", GetSecureSignedToken( sPrefix, context.localUtil.Format( AV13PropostaCreatedAt, "99/99/99 99:99"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vQUANTIDADEITENS", GetSecureSignedToken( sPrefix, context.localUtil.Format( AV14QuantidadeItens, "ZZZZZZZZZZ9.999999"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPROPOSTAVALOR", GetSecureSignedToken( sPrefix, context.localUtil.Format( AV15PropostaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPROPOSTASTATUS", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV16PropostaStatus, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"WcImpNotaFiscalConfirmacao");
         forbiddenHiddens.Add("PropostaProtocolo", StringUtil.RTrim( context.localUtil.Format( AV12PropostaProtocolo, "")));
         forbiddenHiddens.Add("PropostaCreatedAt", context.localUtil.Format( AV13PropostaCreatedAt, "99/99/99 99:99"));
         forbiddenHiddens.Add("QuantidadeItens", context.localUtil.Format( AV14QuantidadeItens, "ZZZZZZZZZZ9.999999"));
         forbiddenHiddens.Add("PropostaValor", context.localUtil.Format( AV15PropostaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"));
         forbiddenHiddens.Add("PropostaStatus", StringUtil.RTrim( context.localUtil.Format( AV16PropostaStatus, "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("wcimpnotafiscalconfirmacao:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6WebSessionKey", wcpOAV6WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8PreviousStep", wcpOAV8PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV7GoingBack", wcpOAV7GoingBack);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWEBSESSIONKEY", AV6WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPREVIOUSSTEP", AV8PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vGOINGBACK", AV7GoingBack);
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_DETALHES_Width", StringUtil.RTrim( Dvpanel_detalhes_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_DETALHES_Autowidth", StringUtil.BoolToStr( Dvpanel_detalhes_Autowidth));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_DETALHES_Autoheight", StringUtil.BoolToStr( Dvpanel_detalhes_Autoheight));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_DETALHES_Cls", StringUtil.RTrim( Dvpanel_detalhes_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_DETALHES_Title", StringUtil.RTrim( Dvpanel_detalhes_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_DETALHES_Collapsible", StringUtil.BoolToStr( Dvpanel_detalhes_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_DETALHES_Collapsed", StringUtil.BoolToStr( Dvpanel_detalhes_Collapsed));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_DETALHES_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_detalhes_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_DETALHES_Iconposition", StringUtil.RTrim( Dvpanel_detalhes_Iconposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_DETALHES_Autoscroll", StringUtil.BoolToStr( Dvpanel_detalhes_Autoscroll));
      }

      protected void RenderHtmlCloseForm8S2( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
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
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "WcImpNotaFiscalConfirmacao" ;
      }

      public override string GetPgmdesc( )
      {
         return "Wc Imp Nota Fiscal Confirmacao" ;
      }

      protected void WB8S0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wcimpnotafiscalconfirmacao");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "table-content-wizard", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablenotasflex_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;flex-wrap:wrap;justify-content:center;align-items:center;align-content:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLabeluploaddataxml_Internalname, "<h3>Solicitação Enviada com Sucesso!</h3>", "", "", lblLabeluploaddataxml_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WcImpNotaFiscalConfirmacao.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLabeldescriptionuploaddata_Internalname, "<h4>Sua solicitação de venda de títulos foi recebida e está sendo processada pela nossa equipe financeira.</h4>", "", "", lblLabeldescriptionuploaddata_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WcImpNotaFiscalConfirmacao.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_detalhes.SetProperty("Width", Dvpanel_detalhes_Width);
            ucDvpanel_detalhes.SetProperty("AutoWidth", Dvpanel_detalhes_Autowidth);
            ucDvpanel_detalhes.SetProperty("AutoHeight", Dvpanel_detalhes_Autoheight);
            ucDvpanel_detalhes.SetProperty("Cls", Dvpanel_detalhes_Cls);
            ucDvpanel_detalhes.SetProperty("Title", Dvpanel_detalhes_Title);
            ucDvpanel_detalhes.SetProperty("Collapsible", Dvpanel_detalhes_Collapsible);
            ucDvpanel_detalhes.SetProperty("Collapsed", Dvpanel_detalhes_Collapsed);
            ucDvpanel_detalhes.SetProperty("ShowCollapseIcon", Dvpanel_detalhes_Showcollapseicon);
            ucDvpanel_detalhes.SetProperty("IconPosition", Dvpanel_detalhes_Iconposition);
            ucDvpanel_detalhes.SetProperty("AutoScroll", Dvpanel_detalhes_Autoscroll);
            ucDvpanel_detalhes.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_detalhes_Internalname, sPrefix+"DVPANEL_DETALHESContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVPANEL_DETALHESContainer"+"Detalhes"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divDetalhes_Internalname, 1, 0, "px", 0, "px", "PanelNoHeader", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLabelt_Internalname, "<span style=\"font-size: 16px; \"><strong>Detalhes da Transação</strong></span>", "", "", lblLabelt_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WcImpNotaFiscalConfirmacao.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPropostaprotocolo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostaprotocolo_Internalname, "ID da Transação:", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostaprotocolo_Internalname, AV12PropostaProtocolo, StringUtil.RTrim( context.localUtil.Format( AV12PropostaProtocolo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostaprotocolo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavPropostaprotocolo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WcImpNotaFiscalConfirmacao.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPropostacreatedat_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostacreatedat_Internalname, "Data:", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavPropostacreatedat_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavPropostacreatedat_Internalname, context.localUtil.TToC( AV13PropostaCreatedAt, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( AV13PropostaCreatedAt, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,37);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostacreatedat_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavPropostacreatedat_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WcImpNotaFiscalConfirmacao.htm");
            GxWebStd.gx_bitmap( context, edtavPropostacreatedat_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavPropostacreatedat_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WcImpNotaFiscalConfirmacao.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavQuantidadeitens_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavQuantidadeitens_Internalname, "Quantidade de itens:", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavQuantidadeitens_Internalname, StringUtil.LTrim( StringUtil.NToC( AV14QuantidadeItens, 18, 6, ",", "")), StringUtil.LTrim( ((edtavQuantidadeitens_Enabled!=0) ? context.localUtil.Format( AV14QuantidadeItens, "ZZZZZZZZZZ9.999999") : context.localUtil.Format( AV14QuantidadeItens, "ZZZZZZZZZZ9.999999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','6');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','6');"+";gx.evt.onblur(this,42);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavQuantidadeitens_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavQuantidadeitens_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WcImpNotaFiscalConfirmacao.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPropostavalor_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostavalor_Internalname, "Valor Total:", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostavalor_Internalname, StringUtil.LTrim( StringUtil.NToC( AV15PropostaValor, 18, 2, ",", "")), StringUtil.LTrim( ((edtavPropostavalor_Enabled!=0) ? context.localUtil.Format( AV15PropostaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV15PropostaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,47);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostavalor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavPropostavalor_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WcImpNotaFiscalConfirmacao.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavPropostastatus_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavPropostastatus_Internalname, "Status:", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavPropostastatus, cmbavPropostastatus_Internalname, StringUtil.RTrim( AV16PropostaStatus), 1, cmbavPropostastatus_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavPropostastatus.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "", true, 0, "HLP_WcImpNotaFiscalConfirmacao.htm");
            cmbavPropostastatus.CurrentValue = StringUtil.RTrim( AV16PropostaStatus);
            AssignProp(sPrefix, false, cmbavPropostastatus_Internalname, "Values", (string)(cmbavPropostastatus.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "<div style=\"background-color: #f0f6ff; border: 1px solid #cfe2ff; padding: 10px 15px; border-radius: 8px; font-family: Arial, sans-serif; font-size: 14px; color: #212529;\"><strong style=\"color: #084298;\">Próximos passos:</strong><span style=\"color: #084298;\">Nossa equipe financeira irá analisar sua solicitação e você receberá um e-mail com a confirmação e os detalhes para recebimento do valor. Este processo geralmente leva até 2 dias úteis.</span></div>", "", "", lblTextblock1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WcImpNotaFiscalConfirmacao.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 ActionGroupFixedBottomWizard", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;flex-wrap:wrap;justify-content:center;align-items:center;align-content:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuseraction1_Internalname, "", "Voltar para lista", bttBtnuseraction1_Jsonclick, 5, "Voltar para lista", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUSERACTION1\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WcImpNotaFiscalConfirmacao.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button ButtonWizard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnwizardlastnext_Internalname, "", "Iniciar Nova Solicitação", bttBtnwizardlastnext_Jsonclick, 5, "Iniciar Nova Solicitação", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WcImpNotaFiscalConfirmacao.htm");
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
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START8S2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) != 0 )
         {
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET 18_0_12-186073", 0) ;
               }
            }
            Form.Meta.addItem("description", "Wc Imp Nota Fiscal Confirmacao", 0) ;
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP8S0( ) ;
            }
         }
      }

      protected void WS8S2( )
      {
         START8S2( ) ;
         EVT8S2( ) ;
      }

      protected void EVT8S2( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
                  if ( StringUtil.Len( sEvt) > 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 1);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP8S0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP8S0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E118S2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP8S0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E128S2 ();
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUSERACTION1'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP8S0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUserAction1' */
                                    E138S2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP8S0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E148S2 ();
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP8S0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavPropostaprotocolo_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
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

      protected void WE8S2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm8S2( ) ;
            }
         }
      }

      protected void PA8S2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            if ( StringUtil.Len( sPrefix) == 0 )
            {
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wcimpnotafiscalconfirmacao")), "wcimpnotafiscalconfirmacao") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wcimpnotafiscalconfirmacao")))) ;
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
            }
            if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               if ( StringUtil.Len( sPrefix) == 0 )
               {
                  if ( nGotPars == 0 )
                  {
                     entryPointCalled = false;
                     gxfirstwebparm = GetFirstPar( "WebSessionKey");
                     toggleJsOutput = isJsOutputEnabled( );
                     if ( context.isSpaRequest( ) )
                     {
                        disableJsOutput();
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
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavPropostaprotocolo_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
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
         if ( cmbavPropostastatus.ItemCount > 0 )
         {
            AV16PropostaStatus = cmbavPropostastatus.getValidValue(AV16PropostaStatus);
            AssignAttri(sPrefix, false, "AV16PropostaStatus", AV16PropostaStatus);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPROPOSTASTATUS", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV16PropostaStatus, "")), context));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavPropostastatus.CurrentValue = StringUtil.RTrim( AV16PropostaStatus);
            AssignProp(sPrefix, false, cmbavPropostastatus_Internalname, "Values", cmbavPropostastatus.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF8S2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavPropostaprotocolo_Enabled = 0;
         AssignProp(sPrefix, false, edtavPropostaprotocolo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPropostaprotocolo_Enabled), 5, 0), true);
         edtavPropostacreatedat_Enabled = 0;
         AssignProp(sPrefix, false, edtavPropostacreatedat_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPropostacreatedat_Enabled), 5, 0), true);
         edtavQuantidadeitens_Enabled = 0;
         AssignProp(sPrefix, false, edtavQuantidadeitens_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavQuantidadeitens_Enabled), 5, 0), true);
         edtavPropostavalor_Enabled = 0;
         AssignProp(sPrefix, false, edtavPropostavalor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPropostavalor_Enabled), 5, 0), true);
         cmbavPropostastatus.Enabled = 0;
         AssignProp(sPrefix, false, cmbavPropostastatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavPropostastatus.Enabled), 5, 0), true);
      }

      protected void RF8S2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E148S2 ();
            WB8S0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes8S2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPROPOSTAPROTOCOLO", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV12PropostaProtocolo, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPROPOSTACREATEDAT", GetSecureSignedToken( sPrefix, context.localUtil.Format( AV13PropostaCreatedAt, "99/99/99 99:99"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vQUANTIDADEITENS", GetSecureSignedToken( sPrefix, context.localUtil.Format( AV14QuantidadeItens, "ZZZZZZZZZZ9.999999"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPROPOSTAVALOR", GetSecureSignedToken( sPrefix, context.localUtil.Format( AV15PropostaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPROPOSTASTATUS", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV16PropostaStatus, "")), context));
      }

      protected void before_start_formulas( )
      {
         edtavPropostaprotocolo_Enabled = 0;
         AssignProp(sPrefix, false, edtavPropostaprotocolo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPropostaprotocolo_Enabled), 5, 0), true);
         edtavPropostacreatedat_Enabled = 0;
         AssignProp(sPrefix, false, edtavPropostacreatedat_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPropostacreatedat_Enabled), 5, 0), true);
         edtavQuantidadeitens_Enabled = 0;
         AssignProp(sPrefix, false, edtavQuantidadeitens_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavQuantidadeitens_Enabled), 5, 0), true);
         edtavPropostavalor_Enabled = 0;
         AssignProp(sPrefix, false, edtavPropostavalor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPropostavalor_Enabled), 5, 0), true);
         cmbavPropostastatus.Enabled = 0;
         AssignProp(sPrefix, false, cmbavPropostastatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavPropostastatus.Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP8S0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E118S2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOAV6WebSessionKey = cgiGet( sPrefix+"wcpOAV6WebSessionKey");
            wcpOAV8PreviousStep = cgiGet( sPrefix+"wcpOAV8PreviousStep");
            wcpOAV7GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV7GoingBack"));
            Dvpanel_detalhes_Width = cgiGet( sPrefix+"DVPANEL_DETALHES_Width");
            Dvpanel_detalhes_Autowidth = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_DETALHES_Autowidth"));
            Dvpanel_detalhes_Autoheight = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_DETALHES_Autoheight"));
            Dvpanel_detalhes_Cls = cgiGet( sPrefix+"DVPANEL_DETALHES_Cls");
            Dvpanel_detalhes_Title = cgiGet( sPrefix+"DVPANEL_DETALHES_Title");
            Dvpanel_detalhes_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_DETALHES_Collapsible"));
            Dvpanel_detalhes_Collapsed = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_DETALHES_Collapsed"));
            Dvpanel_detalhes_Showcollapseicon = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_DETALHES_Showcollapseicon"));
            Dvpanel_detalhes_Iconposition = cgiGet( sPrefix+"DVPANEL_DETALHES_Iconposition");
            Dvpanel_detalhes_Autoscroll = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_DETALHES_Autoscroll"));
            /* Read variables values. */
            AV12PropostaProtocolo = cgiGet( edtavPropostaprotocolo_Internalname);
            AssignAttri(sPrefix, false, "AV12PropostaProtocolo", AV12PropostaProtocolo);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPROPOSTAPROTOCOLO", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV12PropostaProtocolo, "")), context));
            if ( context.localUtil.VCDateTime( cgiGet( edtavPropostacreatedat_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Proposta Created At"}), 1, "vPROPOSTACREATEDAT");
               GX_FocusControl = edtavPropostacreatedat_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV13PropostaCreatedAt = (DateTime)(DateTime.MinValue);
               AssignAttri(sPrefix, false, "AV13PropostaCreatedAt", context.localUtil.TToC( AV13PropostaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPROPOSTACREATEDAT", GetSecureSignedToken( sPrefix, context.localUtil.Format( AV13PropostaCreatedAt, "99/99/99 99:99"), context));
            }
            else
            {
               AV13PropostaCreatedAt = context.localUtil.CToT( cgiGet( edtavPropostacreatedat_Internalname));
               AssignAttri(sPrefix, false, "AV13PropostaCreatedAt", context.localUtil.TToC( AV13PropostaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPROPOSTACREATEDAT", GetSecureSignedToken( sPrefix, context.localUtil.Format( AV13PropostaCreatedAt, "99/99/99 99:99"), context));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavQuantidadeitens_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavQuantidadeitens_Internalname), ",", ".") > 99999999999.999999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vQUANTIDADEITENS");
               GX_FocusControl = edtavQuantidadeitens_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV14QuantidadeItens = 0;
               AssignAttri(sPrefix, false, "AV14QuantidadeItens", StringUtil.LTrimStr( AV14QuantidadeItens, 18, 6));
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vQUANTIDADEITENS", GetSecureSignedToken( sPrefix, context.localUtil.Format( AV14QuantidadeItens, "ZZZZZZZZZZ9.999999"), context));
            }
            else
            {
               AV14QuantidadeItens = context.localUtil.CToN( cgiGet( edtavQuantidadeitens_Internalname), ",", ".");
               AssignAttri(sPrefix, false, "AV14QuantidadeItens", StringUtil.LTrimStr( AV14QuantidadeItens, 18, 6));
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vQUANTIDADEITENS", GetSecureSignedToken( sPrefix, context.localUtil.Format( AV14QuantidadeItens, "ZZZZZZZZZZ9.999999"), context));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPropostavalor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPropostavalor_Internalname), ",", ".") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPROPOSTAVALOR");
               GX_FocusControl = edtavPropostavalor_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV15PropostaValor = 0;
               AssignAttri(sPrefix, false, "AV15PropostaValor", StringUtil.LTrimStr( AV15PropostaValor, 18, 2));
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPROPOSTAVALOR", GetSecureSignedToken( sPrefix, context.localUtil.Format( AV15PropostaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"), context));
            }
            else
            {
               AV15PropostaValor = context.localUtil.CToN( cgiGet( edtavPropostavalor_Internalname), ",", ".");
               AssignAttri(sPrefix, false, "AV15PropostaValor", StringUtil.LTrimStr( AV15PropostaValor, 18, 2));
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPROPOSTAVALOR", GetSecureSignedToken( sPrefix, context.localUtil.Format( AV15PropostaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"), context));
            }
            cmbavPropostastatus.CurrentValue = cgiGet( cmbavPropostastatus_Internalname);
            AV16PropostaStatus = cgiGet( cmbavPropostastatus_Internalname);
            AssignAttri(sPrefix, false, "AV16PropostaStatus", AV16PropostaStatus);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPROPOSTASTATUS", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV16PropostaStatus, "")), context));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"WcImpNotaFiscalConfirmacao");
            AV12PropostaProtocolo = cgiGet( edtavPropostaprotocolo_Internalname);
            AssignAttri(sPrefix, false, "AV12PropostaProtocolo", AV12PropostaProtocolo);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPROPOSTAPROTOCOLO", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV12PropostaProtocolo, "")), context));
            forbiddenHiddens.Add("PropostaProtocolo", StringUtil.RTrim( context.localUtil.Format( AV12PropostaProtocolo, "")));
            AV13PropostaCreatedAt = context.localUtil.CToT( cgiGet( edtavPropostacreatedat_Internalname));
            AssignAttri(sPrefix, false, "AV13PropostaCreatedAt", context.localUtil.TToC( AV13PropostaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPROPOSTACREATEDAT", GetSecureSignedToken( sPrefix, context.localUtil.Format( AV13PropostaCreatedAt, "99/99/99 99:99"), context));
            forbiddenHiddens.Add("PropostaCreatedAt", context.localUtil.Format( AV13PropostaCreatedAt, "99/99/99 99:99"));
            AV14QuantidadeItens = context.localUtil.CToN( cgiGet( edtavQuantidadeitens_Internalname), ",", ".");
            AssignAttri(sPrefix, false, "AV14QuantidadeItens", StringUtil.LTrimStr( AV14QuantidadeItens, 18, 6));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vQUANTIDADEITENS", GetSecureSignedToken( sPrefix, context.localUtil.Format( AV14QuantidadeItens, "ZZZZZZZZZZ9.999999"), context));
            forbiddenHiddens.Add("QuantidadeItens", context.localUtil.Format( AV14QuantidadeItens, "ZZZZZZZZZZ9.999999"));
            AV15PropostaValor = context.localUtil.CToN( cgiGet( edtavPropostavalor_Internalname), ",", ".");
            AssignAttri(sPrefix, false, "AV15PropostaValor", StringUtil.LTrimStr( AV15PropostaValor, 18, 2));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPROPOSTAVALOR", GetSecureSignedToken( sPrefix, context.localUtil.Format( AV15PropostaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"), context));
            forbiddenHiddens.Add("PropostaValor", context.localUtil.Format( AV15PropostaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"));
            AV16PropostaStatus = cgiGet( cmbavPropostastatus_Internalname);
            AssignAttri(sPrefix, false, "AV16PropostaStatus", AV16PropostaStatus);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPROPOSTASTATUS", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV16PropostaStatus, "")), context));
            forbiddenHiddens.Add("PropostaStatus", StringUtil.RTrim( context.localUtil.Format( AV16PropostaStatus, "")));
            hsh = cgiGet( sPrefix+"hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("wcimpnotafiscalconfirmacao:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
               GxWebError = 1;
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               return  ;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E118S2 ();
         if (returnInSub) return;
      }

      protected void E118S2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADVARIABLESFROMWIZARDDATA' */
         S112 ();
         if (returnInSub) return;
         AV17Proposta.Load(AV11WizardData.gxTpr_Revisao.gxTpr_Propostaid);
         AV13PropostaCreatedAt = AV17Proposta.gxTpr_Propostacreatedat;
         AssignAttri(sPrefix, false, "AV13PropostaCreatedAt", context.localUtil.TToC( AV13PropostaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPROPOSTACREATEDAT", GetSecureSignedToken( sPrefix, context.localUtil.Format( AV13PropostaCreatedAt, "99/99/99 99:99"), context));
         AV12PropostaProtocolo = AV17Proposta.gxTpr_Propostaprotocolo;
         AssignAttri(sPrefix, false, "AV12PropostaProtocolo", AV12PropostaProtocolo);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPROPOSTAPROTOCOLO", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV12PropostaProtocolo, "")), context));
         AV16PropostaStatus = AV17Proposta.gxTpr_Propostastatus;
         AssignAttri(sPrefix, false, "AV16PropostaStatus", AV16PropostaStatus);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPROPOSTASTATUS", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV16PropostaStatus, "")), context));
         AV14QuantidadeItens = (decimal)(AV17Proposta.gxTpr_Propostaqtditensnota_f);
         AssignAttri(sPrefix, false, "AV14QuantidadeItens", StringUtil.LTrimStr( AV14QuantidadeItens, 18, 6));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vQUANTIDADEITENS", GetSecureSignedToken( sPrefix, context.localUtil.Format( AV14QuantidadeItens, "ZZZZZZZZZZ9.999999"), context));
         AV15PropostaValor = AV17Proposta.gxTpr_Propostavalorliquido;
         AssignAttri(sPrefix, false, "AV15PropostaValor", StringUtil.LTrimStr( AV15PropostaValor, 18, 2));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPROPOSTAVALOR", GetSecureSignedToken( sPrefix, context.localUtil.Format( AV15PropostaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"), context));
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11WizardData.gxTpr_Importarxml.gxTpr_Jsonsdnotafiscal)) )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wcimpnotafiscal"+UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.RTrim("ImportarXML")) + "," + UrlEncode(StringUtil.BoolToStr(false));
            CallWebObject(formatLink("wcimpnotafiscal") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E128S2 ();
         if (returnInSub) return;
      }

      protected void E128S2( )
      {
         /* Enter Routine */
         returnInSub = false;
         if ( ! AV10HasValidationErrors )
         {
            /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
            S122 ();
            if (returnInSub) return;
            /* Execute user subroutine: 'FINISHWIZARD' */
            S132 ();
            if (returnInSub) return;
            AV5WebSession.Remove(AV6WebSessionKey);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11WizardData", AV11WizardData);
      }

      protected void E138S2( )
      {
         /* 'DoUserAction1' Routine */
         returnInSub = false;
         AV5WebSession.Remove(AV6WebSessionKey);
         CallWebObject(formatLink("costumer.invoices") );
         context.wjLocDisableFrm = 1;
      }

      protected void S112( )
      {
         /* 'LOADVARIABLESFROMWIZARDDATA' Routine */
         returnInSub = false;
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
         AV12PropostaProtocolo = AV11WizardData.gxTpr_Confirmacao.gxTpr_Propostaprotocolo;
         AssignAttri(sPrefix, false, "AV12PropostaProtocolo", AV12PropostaProtocolo);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPROPOSTAPROTOCOLO", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV12PropostaProtocolo, "")), context));
         AV13PropostaCreatedAt = AV11WizardData.gxTpr_Confirmacao.gxTpr_Propostacreatedat;
         AssignAttri(sPrefix, false, "AV13PropostaCreatedAt", context.localUtil.TToC( AV13PropostaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPROPOSTACREATEDAT", GetSecureSignedToken( sPrefix, context.localUtil.Format( AV13PropostaCreatedAt, "99/99/99 99:99"), context));
         AV14QuantidadeItens = AV11WizardData.gxTpr_Confirmacao.gxTpr_Quantidadeitens;
         AssignAttri(sPrefix, false, "AV14QuantidadeItens", StringUtil.LTrimStr( AV14QuantidadeItens, 18, 6));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vQUANTIDADEITENS", GetSecureSignedToken( sPrefix, context.localUtil.Format( AV14QuantidadeItens, "ZZZZZZZZZZ9.999999"), context));
         AV15PropostaValor = AV11WizardData.gxTpr_Confirmacao.gxTpr_Propostavalor;
         AssignAttri(sPrefix, false, "AV15PropostaValor", StringUtil.LTrimStr( AV15PropostaValor, 18, 2));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPROPOSTAVALOR", GetSecureSignedToken( sPrefix, context.localUtil.Format( AV15PropostaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"), context));
         AV16PropostaStatus = AV11WizardData.gxTpr_Confirmacao.gxTpr_Propostastatus;
         AssignAttri(sPrefix, false, "AV16PropostaStatus", AV16PropostaStatus);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPROPOSTASTATUS", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV16PropostaStatus, "")), context));
      }

      protected void S122( )
      {
         /* 'SAVEVARIABLESTOWIZARDDATA' Routine */
         returnInSub = false;
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
         AV11WizardData.gxTpr_Confirmacao.gxTpr_Propostaprotocolo = AV12PropostaProtocolo;
         AV11WizardData.gxTpr_Confirmacao.gxTpr_Propostacreatedat = AV13PropostaCreatedAt;
         AV11WizardData.gxTpr_Confirmacao.gxTpr_Quantidadeitens = AV14QuantidadeItens;
         AV11WizardData.gxTpr_Confirmacao.gxTpr_Propostavalor = AV15PropostaValor;
         AV11WizardData.gxTpr_Confirmacao.gxTpr_Propostastatus = AV16PropostaStatus;
         AV5WebSession.Set(AV6WebSessionKey, AV11WizardData.ToJSonString(false, true));
      }

      protected void S132( )
      {
         /* 'FINISHWIZARD' Routine */
         returnInSub = false;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wcimpnotafiscal"+UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.RTrim("ImportarXML")) + "," + UrlEncode(StringUtil.BoolToStr(false));
         CallWebObject(formatLink("wcimpnotafiscal") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void nextLoad( )
      {
      }

      protected void E148S2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV6WebSessionKey = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV6WebSessionKey", AV6WebSessionKey);
         AV8PreviousStep = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV8PreviousStep", AV8PreviousStep);
         AV7GoingBack = (bool)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV7GoingBack", AV7GoingBack);
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
         PA8S2( ) ;
         WS8S2( ) ;
         WE8S2( ) ;
         cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected override EncryptionType GetEncryptionType( )
      {
         return EncryptionType.SESSION ;
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlAV6WebSessionKey = (string)((string)getParm(obj,0));
         sCtrlAV8PreviousStep = (string)((string)getParm(obj,1));
         sCtrlAV7GoingBack = (string)((string)getParm(obj,2));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA8S2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wcimpnotafiscalconfirmacao", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA8S2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV6WebSessionKey = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV6WebSessionKey", AV6WebSessionKey);
            AV8PreviousStep = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV8PreviousStep", AV8PreviousStep);
            AV7GoingBack = (bool)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV7GoingBack", AV7GoingBack);
         }
         wcpOAV6WebSessionKey = cgiGet( sPrefix+"wcpOAV6WebSessionKey");
         wcpOAV8PreviousStep = cgiGet( sPrefix+"wcpOAV8PreviousStep");
         wcpOAV7GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV7GoingBack"));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV6WebSessionKey, wcpOAV6WebSessionKey) != 0 ) || ( StringUtil.StrCmp(AV8PreviousStep, wcpOAV8PreviousStep) != 0 ) || ( AV7GoingBack != wcpOAV7GoingBack ) ) )
         {
            setjustcreated();
         }
         wcpOAV6WebSessionKey = AV6WebSessionKey;
         wcpOAV8PreviousStep = AV8PreviousStep;
         wcpOAV7GoingBack = AV7GoingBack;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV6WebSessionKey = cgiGet( sPrefix+"AV6WebSessionKey_CTRL");
         if ( StringUtil.Len( sCtrlAV6WebSessionKey) > 0 )
         {
            AV6WebSessionKey = cgiGet( sCtrlAV6WebSessionKey);
            AssignAttri(sPrefix, false, "AV6WebSessionKey", AV6WebSessionKey);
         }
         else
         {
            AV6WebSessionKey = cgiGet( sPrefix+"AV6WebSessionKey_PARM");
         }
         sCtrlAV8PreviousStep = cgiGet( sPrefix+"AV8PreviousStep_CTRL");
         if ( StringUtil.Len( sCtrlAV8PreviousStep) > 0 )
         {
            AV8PreviousStep = cgiGet( sCtrlAV8PreviousStep);
            AssignAttri(sPrefix, false, "AV8PreviousStep", AV8PreviousStep);
         }
         else
         {
            AV8PreviousStep = cgiGet( sPrefix+"AV8PreviousStep_PARM");
         }
         sCtrlAV7GoingBack = cgiGet( sPrefix+"AV7GoingBack_CTRL");
         if ( StringUtil.Len( sCtrlAV7GoingBack) > 0 )
         {
            AV7GoingBack = StringUtil.StrToBool( cgiGet( sCtrlAV7GoingBack));
            AssignAttri(sPrefix, false, "AV7GoingBack", AV7GoingBack);
         }
         else
         {
            AV7GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"AV7GoingBack_PARM"));
         }
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA8S2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS8S2( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS8S2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV6WebSessionKey_PARM", AV6WebSessionKey);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV6WebSessionKey)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV6WebSessionKey_CTRL", StringUtil.RTrim( sCtrlAV6WebSessionKey));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV8PreviousStep_PARM", AV8PreviousStep);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV8PreviousStep)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV8PreviousStep_CTRL", StringUtil.RTrim( sCtrlAV8PreviousStep));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV7GoingBack_PARM", StringUtil.BoolToStr( AV7GoingBack));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV7GoingBack)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV7GoingBack_CTRL", StringUtil.RTrim( sCtrlAV7GoingBack));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE8S2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019151397", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         CloseStyles();
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("wcimpnotafiscalconfirmacao.js", "?202561019151398", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavPropostastatus.Name = "vPROPOSTASTATUS";
         cmbavPropostastatus.WebTags = "";
         cmbavPropostastatus.addItem("PENDENTE", "Pendente aprovação", 0);
         cmbavPropostastatus.addItem("EM_ANALISE", "Em análise", 0);
         cmbavPropostastatus.addItem("APROVADO", "Aprovado", 0);
         cmbavPropostastatus.addItem("REJEITADO", "Rejeitado", 0);
         cmbavPropostastatus.addItem("REVISAO", "Revisão", 0);
         cmbavPropostastatus.addItem("CANCELADO", "Cancelado", 0);
         cmbavPropostastatus.addItem("AGUARDANDO_ASSINATURA", "Aguardando assinatura", 0);
         cmbavPropostastatus.addItem("AnaliseReprovada", "Análise reprovada", 0);
         if ( cmbavPropostastatus.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblLabeluploaddataxml_Internalname = sPrefix+"LABELUPLOADDATAXML";
         lblLabeldescriptionuploaddata_Internalname = sPrefix+"LABELDESCRIPTIONUPLOADDATA";
         divTablenotasflex_Internalname = sPrefix+"TABLENOTASFLEX";
         lblLabelt_Internalname = sPrefix+"LABELT";
         edtavPropostaprotocolo_Internalname = sPrefix+"vPROPOSTAPROTOCOLO";
         edtavPropostacreatedat_Internalname = sPrefix+"vPROPOSTACREATEDAT";
         edtavQuantidadeitens_Internalname = sPrefix+"vQUANTIDADEITENS";
         edtavPropostavalor_Internalname = sPrefix+"vPROPOSTAVALOR";
         cmbavPropostastatus_Internalname = sPrefix+"vPROPOSTASTATUS";
         divDetalhes_Internalname = sPrefix+"DETALHES";
         Dvpanel_detalhes_Internalname = sPrefix+"DVPANEL_DETALHES";
         lblTextblock1_Internalname = sPrefix+"TEXTBLOCK1";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         bttBtnuseraction1_Internalname = sPrefix+"BTNUSERACTION1";
         bttBtnwizardlastnext_Internalname = sPrefix+"BTNWIZARDLASTNEXT";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         cmbavPropostastatus_Jsonclick = "";
         cmbavPropostastatus.Enabled = 1;
         edtavPropostavalor_Jsonclick = "";
         edtavPropostavalor_Enabled = 1;
         edtavQuantidadeitens_Jsonclick = "";
         edtavQuantidadeitens_Enabled = 1;
         edtavPropostacreatedat_Jsonclick = "";
         edtavPropostacreatedat_Enabled = 1;
         edtavPropostaprotocolo_Jsonclick = "";
         edtavPropostaprotocolo_Enabled = 1;
         Dvpanel_detalhes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_detalhes_Iconposition = "Right";
         Dvpanel_detalhes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_detalhes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_detalhes_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_detalhes_Title = "";
         Dvpanel_detalhes_Cls = "PanelCard_GrayTitle";
         Dvpanel_detalhes_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_detalhes_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_detalhes_Width = "100%";
         context.GX_msglist.DisplayMode = 1;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true,"type":"boolean"},{"av":"AV12PropostaProtocolo","fld":"vPROPOSTAPROTOCOLO","hsh":true,"type":"svchar"},{"av":"AV13PropostaCreatedAt","fld":"vPROPOSTACREATEDAT","pic":"99/99/99 99:99","hsh":true,"type":"dtime"},{"av":"AV14QuantidadeItens","fld":"vQUANTIDADEITENS","pic":"ZZZZZZZZZZ9.999999","hsh":true,"type":"decimal"},{"av":"AV15PropostaValor","fld":"vPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","hsh":true,"type":"decimal"},{"av":"cmbavPropostastatus"},{"av":"AV16PropostaStatus","fld":"vPROPOSTASTATUS","hsh":true,"type":"svchar"}]}""");
         setEventMetadata("ENTER","""{"handler":"E128S2","iparms":[{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true,"type":"boolean"},{"av":"AV6WebSessionKey","fld":"vWEBSESSIONKEY","type":"svchar"},{"av":"AV12PropostaProtocolo","fld":"vPROPOSTAPROTOCOLO","hsh":true,"type":"svchar"},{"av":"AV13PropostaCreatedAt","fld":"vPROPOSTACREATEDAT","pic":"99/99/99 99:99","hsh":true,"type":"dtime"},{"av":"AV14QuantidadeItens","fld":"vQUANTIDADEITENS","pic":"ZZZZZZZZZZ9.999999","hsh":true,"type":"decimal"},{"av":"AV15PropostaValor","fld":"vPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","hsh":true,"type":"decimal"},{"av":"cmbavPropostastatus"},{"av":"AV16PropostaStatus","fld":"vPROPOSTASTATUS","hsh":true,"type":"svchar"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV11WizardData","fld":"vWIZARDDATA","type":""}]}""");
         setEventMetadata("'DOUSERACTION1'","""{"handler":"E138S2","iparms":[{"av":"AV6WebSessionKey","fld":"vWEBSESSIONKEY","type":"svchar"}]}""");
         setEventMetadata("VALIDV_PROPOSTASTATUS","""{"handler":"Validv_Propostastatus","iparms":[]}""");
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
         wcpOAV6WebSessionKey = "";
         wcpOAV8PreviousStep = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV12PropostaProtocolo = "";
         AV13PropostaCreatedAt = (DateTime)(DateTime.MinValue);
         AV16PropostaStatus = "";
         forbiddenHiddens = new GXProperties();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         lblLabeluploaddataxml_Jsonclick = "";
         lblLabeldescriptionuploaddata_Jsonclick = "";
         ucDvpanel_detalhes = new GXUserControl();
         lblLabelt_Jsonclick = "";
         TempTags = "";
         lblTextblock1_Jsonclick = "";
         bttBtnuseraction1_Jsonclick = "";
         bttBtnwizardlastnext_Jsonclick = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         hsh = "";
         AV17Proposta = new SdtProposta(context);
         AV11WizardData = new SdtWcImpNotaFiscalData(context);
         AV5WebSession = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV6WebSessionKey = "";
         sCtrlAV8PreviousStep = "";
         sCtrlAV7GoingBack = "";
         /* GeneXus formulas. */
         edtavPropostaprotocolo_Enabled = 0;
         edtavPropostacreatedat_Enabled = 0;
         edtavQuantidadeitens_Enabled = 0;
         edtavPropostavalor_Enabled = 0;
         cmbavPropostastatus.Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtavPropostaprotocolo_Enabled ;
      private int edtavPropostacreatedat_Enabled ;
      private int edtavQuantidadeitens_Enabled ;
      private int edtavPropostavalor_Enabled ;
      private int idxLst ;
      private decimal AV14QuantidadeItens ;
      private decimal AV15PropostaValor ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string edtavPropostaprotocolo_Internalname ;
      private string edtavPropostacreatedat_Internalname ;
      private string edtavQuantidadeitens_Internalname ;
      private string edtavPropostavalor_Internalname ;
      private string cmbavPropostastatus_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Dvpanel_detalhes_Width ;
      private string Dvpanel_detalhes_Cls ;
      private string Dvpanel_detalhes_Title ;
      private string Dvpanel_detalhes_Iconposition ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string divTablenotasflex_Internalname ;
      private string lblLabeluploaddataxml_Internalname ;
      private string lblLabeluploaddataxml_Jsonclick ;
      private string lblLabeldescriptionuploaddata_Internalname ;
      private string lblLabeldescriptionuploaddata_Jsonclick ;
      private string Dvpanel_detalhes_Internalname ;
      private string divDetalhes_Internalname ;
      private string lblLabelt_Internalname ;
      private string lblLabelt_Jsonclick ;
      private string TempTags ;
      private string edtavPropostaprotocolo_Jsonclick ;
      private string edtavPropostacreatedat_Jsonclick ;
      private string edtavQuantidadeitens_Jsonclick ;
      private string edtavPropostavalor_Jsonclick ;
      private string cmbavPropostastatus_Jsonclick ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string divTableactions_Internalname ;
      private string bttBtnuseraction1_Internalname ;
      private string bttBtnuseraction1_Jsonclick ;
      private string bttBtnwizardlastnext_Internalname ;
      private string bttBtnwizardlastnext_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string hsh ;
      private string sCtrlAV6WebSessionKey ;
      private string sCtrlAV8PreviousStep ;
      private string sCtrlAV7GoingBack ;
      private DateTime AV13PropostaCreatedAt ;
      private bool AV7GoingBack ;
      private bool wcpOAV7GoingBack ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV10HasValidationErrors ;
      private bool Dvpanel_detalhes_Autowidth ;
      private bool Dvpanel_detalhes_Autoheight ;
      private bool Dvpanel_detalhes_Collapsible ;
      private bool Dvpanel_detalhes_Collapsed ;
      private bool Dvpanel_detalhes_Showcollapseicon ;
      private bool Dvpanel_detalhes_Autoscroll ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV6WebSessionKey ;
      private string AV8PreviousStep ;
      private string wcpOAV6WebSessionKey ;
      private string wcpOAV8PreviousStep ;
      private string AV12PropostaProtocolo ;
      private string AV16PropostaStatus ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_detalhes ;
      private GXWebForm Form ;
      private IGxSession AV5WebSession ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavPropostastatus ;
      private SdtProposta AV17Proposta ;
      private SdtWcImpNotaFiscalData AV11WizardData ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
