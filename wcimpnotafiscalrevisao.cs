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
   public class wcimpnotafiscalrevisao : GXWebComponent
   {
      public wcimpnotafiscalrevisao( )
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

      public wcimpnotafiscalrevisao( IGxContext context )
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
            PA8R2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavPropostaid_Enabled = 0;
               AssignProp(sPrefix, false, edtavPropostaid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPropostaid_Enabled), 5, 0), true);
               WS8R2( ) ;
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
            context.SendWebValue( "Wc Imp Nota Fiscal Revisao") ;
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
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/UcListaItensNotaFiscalRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/UcListaParcelasXTaxasRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
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
            GXEncryptionTmp = "wcimpnotafiscalrevisao"+UrlEncode(StringUtil.RTrim(AV6WebSessionKey)) + "," + UrlEncode(StringUtil.RTrim(AV8PreviousStep)) + "," + UrlEncode(StringUtil.BoolToStr(AV7GoingBack));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wcimpnotafiscalrevisao") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vARRAY_SDNOTAFISCAL", AV23Array_SdNotaFiscal);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vARRAY_SDNOTAFISCAL", AV23Array_SdNotaFiscal);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vARRAY_SDNOTAFISCAL", GetSecureSignedToken( sPrefix, AV23Array_SdNotaFiscal, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vARRAY_SDPRODUTOSNOTAFISCAL", AV15Array_SdProdutosNotaFiscal);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vARRAY_SDPRODUTOSNOTAFISCAL", AV15Array_SdProdutosNotaFiscal);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vARRAY_SDPRODUTOSNOTAFISCAL", GetSecureSignedToken( sPrefix, AV15Array_SdProdutosNotaFiscal, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTAXA", StringUtil.LTrim( StringUtil.NToC( AV18Taxa, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTAXA", GetSecureSignedToken( sPrefix, context.localUtil.Format( AV18Taxa, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vARRAY_SDPARCELACALCULADATAXA", AV28Array_SdParcelaCalculadaTaxa);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vARRAY_SDPARCELACALCULADATAXA", AV28Array_SdParcelaCalculadaTaxa);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vARRAY_SDPARCELACALCULADATAXA", GetSecureSignedToken( sPrefix, AV28Array_SdParcelaCalculadaTaxa, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vEMPTYWIZARDDATA", AV26EmptyWizardData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vEMPTYWIZARDDATA", AV26EmptyWizardData);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vEMPTYWIZARDDATA", GetSecureSignedToken( sPrefix, AV26EmptyWizardData, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6WebSessionKey", wcpOAV6WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8PreviousStep", wcpOAV8PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV7GoingBack", wcpOAV7GoingBack);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vARRAY_SDNOTAFISCAL", AV23Array_SdNotaFiscal);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vARRAY_SDNOTAFISCAL", AV23Array_SdNotaFiscal);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vARRAY_SDNOTAFISCAL", GetSecureSignedToken( sPrefix, AV23Array_SdNotaFiscal, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vARRAY_SDPRODUTOSNOTAFISCAL", AV15Array_SdProdutosNotaFiscal);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vARRAY_SDPRODUTOSNOTAFISCAL", AV15Array_SdProdutosNotaFiscal);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vARRAY_SDPRODUTOSNOTAFISCAL", GetSecureSignedToken( sPrefix, AV15Array_SdProdutosNotaFiscal, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWIZARDDATA", AV11WizardData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWIZARDDATA", AV11WizardData);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vTAXA", StringUtil.LTrim( StringUtil.NToC( AV18Taxa, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTAXA", GetSecureSignedToken( sPrefix, context.localUtil.Format( AV18Taxa, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vARRAY_SDPARCELACALCULADATAXA", AV28Array_SdParcelaCalculadaTaxa);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vARRAY_SDPARCELACALCULADATAXA", AV28Array_SdParcelaCalculadaTaxa);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vARRAY_SDPARCELACALCULADATAXA", GetSecureSignedToken( sPrefix, AV28Array_SdParcelaCalculadaTaxa, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWEBSESSIONKEY", AV6WebSessionKey);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vEMPTYWIZARDDATA", AV26EmptyWizardData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vEMPTYWIZARDDATA", AV26EmptyWizardData);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vEMPTYWIZARDDATA", GetSecureSignedToken( sPrefix, AV26EmptyWizardData, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPREVIOUSSTEP", AV8PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vGOINGBACK", AV7GoingBack);
      }

      protected void RenderHtmlCloseForm8R2( )
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
         return "WcImpNotaFiscalRevisao" ;
      }

      public override string GetPgmdesc( )
      {
         return "Wc Imp Nota Fiscal Revisao" ;
      }

      protected void WB8R0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wcimpnotafiscalrevisao");
               context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
               context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
               context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
               context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
               context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/UcListaItensNotaFiscalRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/UcListaParcelasXTaxasRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
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
            GxWebStd.gx_label_ctrl( context, lblLabeluploaddataxml_Internalname, "<h3>Revisão</h3>", "", "", lblLabeluploaddataxml_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WcImpNotaFiscalRevisao.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLabeldescriptionuploaddata_Internalname, "<h4>Revise os itens selecionados, a taxa aplicada e o valor final a receber.</h4>", "", "", lblLabeldescriptionuploaddata_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WcImpNotaFiscalRevisao.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGxuitabspanel_tabs1.SetProperty("PageCount", Gxuitabspanel_tabs1_Pagecount);
            ucGxuitabspanel_tabs1.SetProperty("Class", Gxuitabspanel_tabs1_Class);
            ucGxuitabspanel_tabs1.SetProperty("HistoryManagement", Gxuitabspanel_tabs1_Historymanagement);
            ucGxuitabspanel_tabs1.Render(context, "tab", Gxuitabspanel_tabs1_Internalname, sPrefix+"GXUITABSPANEL_TABS1Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"GXUITABSPANEL_TABS1Container"+"title1"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTabresumo_title_Internalname, "Resumo", "", "", lblTabresumo_title_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WcImpNotaFiscalRevisao.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "TabResumo") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"GXUITABSPANEL_TABS1Container"+"panel1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucUclistaitens.Render(context, "uclistaitensnotafiscal", Uclistaitens_Internalname, sPrefix+"UCLISTAITENSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"GXUITABSPANEL_TABS1Container"+"title2"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTabparcelas_title_Internalname, "Parcelas", "", "", lblTabparcelas_title_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WcImpNotaFiscalRevisao.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "TabParcelas") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"GXUITABSPANEL_TABS1Container"+"panel2"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucListaparcelas.Render(context, "uclistaparcelasxtaxas", Listaparcelas_Internalname, sPrefix+"LISTAPARCELASContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableinfobox_Internalname, 1, 0, "px", 0, "px", "info-box", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableinfoboxheader_Internalname, 1, 0, "px", 0, "px", "info-box-header", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblInfoheadercontent_Internalname, "<i class=\"fas fa-info-circle\"></i><span>Informações sobre as taxas</span>", "", "", lblInfoheadercontent_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WcImpNotaFiscalRevisao.htm");
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
            GxWebStd.gx_div_start( context, divTableinfoboxcontent_Internalname, 1, 0, "px", 0, "px", "info-box-content", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblInfocontentcontent_Internalname, lblInfocontentcontent_Caption, "", "", lblInfocontentcontent_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WcImpNotaFiscalRevisao.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 ActionGroupFixedBottomWizard", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;justify-content:space-between;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* User Defined Control */
            ucBtnwizardprevious.SetProperty("TooltipText", Btnwizardprevious_Tooltiptext);
            ucBtnwizardprevious.SetProperty("BeforeIconClass", Btnwizardprevious_Beforeiconclass);
            ucBtnwizardprevious.SetProperty("Caption", Btnwizardprevious_Caption);
            ucBtnwizardprevious.SetProperty("Class", Btnwizardprevious_Class);
            ucBtnwizardprevious.Render(context, "wwp_iconbutton", Btnwizardprevious_Internalname, sPrefix+"BTNWIZARDPREVIOUSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* User Defined Control */
            ucBtnwizardnext.SetProperty("TooltipText", Btnwizardnext_Tooltiptext);
            ucBtnwizardnext.SetProperty("AfterIconClass", Btnwizardnext_Aftericonclass);
            ucBtnwizardnext.SetProperty("Caption", Btnwizardnext_Caption);
            ucBtnwizardnext.SetProperty("Class", Btnwizardnext_Class);
            ucBtnwizardnext.Render(context, "wwp_iconbutton", Btnwizardnext_Internalname, sPrefix+"BTNWIZARDNEXTContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs hidden-sm hidden-md hidden-lg", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPropostaid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostaid_Internalname, "Proposta Id", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostaid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25PropostaId), 9, 0, ",", "")), StringUtil.LTrim( ((edtavPropostaid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV25PropostaId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV25PropostaId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,65);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostaid_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavPropostaid_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WcImpNotaFiscalRevisao.htm");
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

      protected void START8R2( )
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
            Form.Meta.addItem("description", "Wc Imp Nota Fiscal Revisao", 0) ;
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
               STRUP8R0( ) ;
            }
         }
      }

      protected void WS8R2( )
      {
         START8R2( ) ;
         EVT8R2( ) ;
      }

      protected void EVT8R2( )
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
                                 STRUP8R0( ) ;
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
                                 STRUP8R0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E118R2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP8R0( ) ;
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
                                          E128R2 ();
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'WIZARDPREVIOUS'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP8R0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'WizardPrevious' */
                                    E138R2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP8R0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E148R2 ();
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP8R0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavPropostaid_Internalname;
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

      protected void WE8R2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm8R2( ) ;
            }
         }
      }

      protected void PA8R2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wcimpnotafiscalrevisao")), "wcimpnotafiscalrevisao") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wcimpnotafiscalrevisao")))) ;
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
               GX_FocusControl = edtavPropostaid_Internalname;
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
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF8R2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavPropostaid_Enabled = 0;
         AssignProp(sPrefix, false, edtavPropostaid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPropostaid_Enabled), 5, 0), true);
      }

      protected void RF8R2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E148R2 ();
            WB8R0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes8R2( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vARRAY_SDNOTAFISCAL", AV23Array_SdNotaFiscal);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vARRAY_SDNOTAFISCAL", AV23Array_SdNotaFiscal);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vARRAY_SDNOTAFISCAL", GetSecureSignedToken( sPrefix, AV23Array_SdNotaFiscal, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vARRAY_SDPRODUTOSNOTAFISCAL", AV15Array_SdProdutosNotaFiscal);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vARRAY_SDPRODUTOSNOTAFISCAL", AV15Array_SdProdutosNotaFiscal);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vARRAY_SDPRODUTOSNOTAFISCAL", GetSecureSignedToken( sPrefix, AV15Array_SdProdutosNotaFiscal, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTAXA", StringUtil.LTrim( StringUtil.NToC( AV18Taxa, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTAXA", GetSecureSignedToken( sPrefix, context.localUtil.Format( AV18Taxa, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vARRAY_SDPARCELACALCULADATAXA", AV28Array_SdParcelaCalculadaTaxa);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vARRAY_SDPARCELACALCULADATAXA", AV28Array_SdParcelaCalculadaTaxa);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vARRAY_SDPARCELACALCULADATAXA", GetSecureSignedToken( sPrefix, AV28Array_SdParcelaCalculadaTaxa, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vEMPTYWIZARDDATA", AV26EmptyWizardData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vEMPTYWIZARDDATA", AV26EmptyWizardData);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vEMPTYWIZARDDATA", GetSecureSignedToken( sPrefix, AV26EmptyWizardData, context));
      }

      protected void before_start_formulas( )
      {
         edtavPropostaid_Enabled = 0;
         AssignProp(sPrefix, false, edtavPropostaid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPropostaid_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP8R0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E118R2 ();
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
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPropostaid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPropostaid_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPROPOSTAID");
               GX_FocusControl = edtavPropostaid_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV25PropostaId = 0;
               AssignAttri(sPrefix, false, "AV25PropostaId", StringUtil.LTrimStr( (decimal)(AV25PropostaId), 9, 0));
            }
            else
            {
               AV25PropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavPropostaid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV25PropostaId", StringUtil.LTrimStr( (decimal)(AV25PropostaId), 9, 0));
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
         E118R2 ();
         if (returnInSub) return;
      }

      protected void E118R2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV13IsPermiteSelecionar = false;
         /* Execute user subroutine: 'LOADVARIABLESFROMWIZARDDATA' */
         S112 ();
         if (returnInSub) return;
         AV17TotalValor = 0;
         AssignAttri(sPrefix, false, "AV17TotalValor", StringUtil.LTrimStr( AV17TotalValor, 18, 2));
         AV15Array_SdProdutosNotaFiscal = new GXBaseCollection<SdtSdProdutoNotaFiscal>( context, "SdProdutoNotaFiscal", "Factory21");
         AV15Array_SdProdutosNotaFiscal.FromJSonString(AV11WizardData.gxTpr_Produtosnota.gxTpr_Jsonsdprodutosnota, null);
         AV23Array_SdNotaFiscal = new GXBaseCollection<SdtSdNotaFiscal>( context, "SdNotaFiscal", "Factory21");
         AV23Array_SdNotaFiscal.FromJSonString(AV11WizardData.gxTpr_Importarxml.gxTpr_Jsonsdnotafiscal, null);
         AV33Array_SdListaNotaFiscalVenda = new GXBaseCollection<SdtSdListaNotaFiscalVenda>( context, "SdListaNotaFiscalVenda", "Factory21");
         AV40GXV1 = 1;
         while ( AV40GXV1 <= AV15Array_SdProdutosNotaFiscal.Count )
         {
            AV16SdProdutoNotaFiscal = ((SdtSdProdutoNotaFiscal)AV15Array_SdProdutosNotaFiscal.Item(AV40GXV1));
            AV32SdListaNotaFiscalVenda = new SdtSdListaNotaFiscalVenda(context);
            AV17TotalValor = (decimal)(AV17TotalValor+(NumberUtil.Val( StringUtil.Trim( AV16SdProdutoNotaFiscal.gxTpr_Vprod), ".")));
            AssignAttri(sPrefix, false, "AV17TotalValor", StringUtil.LTrimStr( AV17TotalValor, 18, 2));
            AV34Valor = NumberUtil.Val( StringUtil.Trim( AV16SdProdutoNotaFiscal.gxTpr_Vprod), ".");
            AV36ValorTotal = AV34Valor;
            AV34Valor = NumberUtil.Val( StringUtil.Trim( AV16SdProdutoNotaFiscal.gxTpr_Vuncom), ".");
            AV35ValorUnitario = AV34Valor;
            AV32SdListaNotaFiscalVenda.gxTpr_Notafiscal = AV16SdProdutoNotaFiscal.gxTpr_Cnfe;
            AV32SdListaNotaFiscalVenda.gxTpr_Codigo = AV16SdProdutoNotaFiscal.gxTpr_Cprod;
            AV32SdListaNotaFiscalVenda.gxTpr_Descricao = AV16SdProdutoNotaFiscal.gxTpr_Xprod;
            AV32SdListaNotaFiscalVenda.gxTpr_Quantidade = AV16SdProdutoNotaFiscal.gxTpr_Qcom;
            AV32SdListaNotaFiscalVenda.gxTpr_Valorunitario = AV35ValorUnitario;
            AV32SdListaNotaFiscalVenda.gxTpr_Total = AV36ValorTotal;
            AV33Array_SdListaNotaFiscalVenda.Add(AV32SdListaNotaFiscalVenda, 0);
            AV40GXV1 = (int)(AV40GXV1+1);
         }
         /* Using cursor H008R2 */
         pr_default.execute(0, new Object[] {AV17TotalValor});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A865TaxasValorMinimo = H008R2_A865TaxasValorMinimo[0];
            n865TaxasValorMinimo = H008R2_n865TaxasValorMinimo[0];
            A864TaxasPercentual = H008R2_A864TaxasPercentual[0];
            n864TaxasPercentual = H008R2_n864TaxasPercentual[0];
            A894TaxasPercentualAnual = H008R2_A894TaxasPercentualAnual[0];
            n894TaxasPercentualAnual = H008R2_n894TaxasPercentualAnual[0];
            AV18Taxa = A864TaxasPercentual;
            AssignAttri(sPrefix, false, "AV18Taxa", StringUtil.LTrimStr( AV18Taxa, 16, 4));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTAXA", GetSecureSignedToken( sPrefix, context.localUtil.Format( AV18Taxa, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"), context));
            AV27TaxaAnual = A894TaxasPercentualAnual;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         lblInfocontentcontent_Caption = StringUtil.Format( "<ul class=\"info-box-list\"><li>Juros de %2% ao ano, calculados proporcionalmente ao prazo de cada parcela</li><li>Taxa administrativa de %1% sobre o valor de cada parcela</li></ul>", StringUtil.LTrimStr( AV18Taxa, 16, 4), StringUtil.LTrimStr( AV27TaxaAnual, 16, 4), "", "", "", "", "", "", "");
         AssignProp(sPrefix, false, lblInfocontentcontent_Internalname, "Caption", lblInfocontentcontent_Caption, true);
         new prcalculataxasnotafiscal(context ).execute(  AV23Array_SdNotaFiscal.ToJSonString(false),  (short)(Math.Round(AV18Taxa, 18, MidpointRounding.ToEven)),  AV27TaxaAnual, out  AV28Array_SdParcelaCalculadaTaxa) ;
         AV37TotalAdministracao = 0;
         AV38TotalJuros = 0;
         AV42GXV2 = 1;
         while ( AV42GXV2 <= AV28Array_SdParcelaCalculadaTaxa.Count )
         {
            AV29SdParcelaCalculadaTaxa = ((SdtSdParcelaCalculadaTaxa)AV28Array_SdParcelaCalculadaTaxa.Item(AV42GXV2));
            AV37TotalAdministracao = (decimal)(AV37TotalAdministracao+(AV29SdParcelaCalculadaTaxa.gxTpr_Taxavalor));
            AV38TotalJuros = (decimal)(AV38TotalJuros+(AV29SdParcelaCalculadaTaxa.gxTpr_Jurosvalor));
            AV42GXV2 = (int)(AV42GXV2+1);
         }
         Listaparcelas_Data = AV28Array_SdParcelaCalculadaTaxa.ToJSonString(false);
         ucListaparcelas.SendProperty(context, sPrefix, false, Listaparcelas_Internalname, "Data", Listaparcelas_Data);
         this.executeUsercontrolMethod(sPrefix, false, "LISTAPARCELASContainer", "LoadData", "", new Object[] {});
         Uclistaitens_Percentualjuros = context.localUtil.Format( AV27TaxaAnual, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%");
         ucUclistaitens.SendProperty(context, sPrefix, false, Uclistaitens_Internalname, "PercentualJuros", Uclistaitens_Percentualjuros);
         Uclistaitens_Percentualtaxaadm = context.localUtil.Format( AV18Taxa, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%");
         ucUclistaitens.SendProperty(context, sPrefix, false, Uclistaitens_Internalname, "PercentualTaxaADM", Uclistaitens_Percentualtaxaadm);
         Uclistaitens_Juros = context.localUtil.Format( AV38TotalJuros, "ZZZ,ZZZ,ZZZ,ZZ9.99");
         ucUclistaitens.SendProperty(context, sPrefix, false, Uclistaitens_Internalname, "Juros", Uclistaitens_Juros);
         Uclistaitens_Taxaadm = context.localUtil.Format( AV37TotalAdministracao, "ZZZ,ZZZ,ZZZ,ZZ9.99");
         ucUclistaitens.SendProperty(context, sPrefix, false, Uclistaitens_Internalname, "TaxaADM", Uclistaitens_Taxaadm);
         AV39TotalString = (decimal)(AV17TotalValor-AV37TotalAdministracao-AV38TotalJuros);
         Uclistaitens_Valorfinal = context.localUtil.Format( AV39TotalString, "ZZZ,ZZZ,ZZZ,ZZ9.99");
         ucUclistaitens.SendProperty(context, sPrefix, false, Uclistaitens_Internalname, "ValorFinal", Uclistaitens_Valorfinal);
         Uclistaitens_Data = AV33Array_SdListaNotaFiscalVenda.ToJSonString(false);
         ucUclistaitens.SendProperty(context, sPrefix, false, Uclistaitens_Internalname, "Data", Uclistaitens_Data);
         this.executeUsercontrolMethod(sPrefix, false, "UCLISTAITENSContainer", "LoadData", "", new Object[] {});
         AV31TotalParcelaTaxaValor = 0;
         AV43GXV3 = 1;
         while ( AV43GXV3 <= AV28Array_SdParcelaCalculadaTaxa.Count )
         {
            AV29SdParcelaCalculadaTaxa = ((SdtSdParcelaCalculadaTaxa)AV28Array_SdParcelaCalculadaTaxa.Item(AV43GXV3));
            AV31TotalParcelaTaxaValor = (decimal)(AV31TotalParcelaTaxaValor+(AV29SdParcelaCalculadaTaxa.gxTpr_Valortotal));
            AV43GXV3 = (int)(AV43GXV3+1);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E128R2 ();
         if (returnInSub) return;
      }

      protected void E128R2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV44GXV4 = 1;
         while ( AV44GXV4 <= AV23Array_SdNotaFiscal.Count )
         {
            AV21SdNotaFiscal = ((SdtSdNotaFiscal)AV23Array_SdNotaFiscal.Item(AV44GXV4));
            AV45GXV5 = 1;
            while ( AV45GXV5 <= AV21SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Det.Count )
            {
               AV24SdNotaFiscalItem = ((SdtSdNotaFiscal_NFe_infNFe_detItem)AV21SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Det.Item(AV45GXV5));
               AV24SdNotaFiscalItem.gxTpr_Prod.gxTpr_Issel = false;
               AV46GXV6 = 1;
               while ( AV46GXV6 <= AV15Array_SdProdutosNotaFiscal.Count )
               {
                  AV16SdProdutoNotaFiscal = ((SdtSdProdutoNotaFiscal)AV15Array_SdProdutosNotaFiscal.Item(AV46GXV6));
                  if ( AV16SdProdutoNotaFiscal.gxTpr_Issel && ( StringUtil.StrCmp(AV16SdProdutoNotaFiscal.gxTpr_Cprod, AV24SdNotaFiscalItem.gxTpr_Prod.gxTpr_Cprod) == 0 ) && ( StringUtil.StrCmp(AV16SdProdutoNotaFiscal.gxTpr_Cnfe, AV21SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Ide.gxTpr_Cnf) == 0 ) && ( StringUtil.StrCmp(AV16SdProdutoNotaFiscal.gxTpr_Vprod, AV24SdNotaFiscalItem.gxTpr_Prod.gxTpr_Vprod) == 0 ) )
                  {
                     AV24SdNotaFiscalItem.gxTpr_Prod.gxTpr_Issel = true;
                     if (true) break;
                  }
                  AV46GXV6 = (int)(AV46GXV6+1);
               }
               AV45GXV5 = (int)(AV45GXV5+1);
            }
            AV44GXV4 = (int)(AV44GXV4+1);
         }
         AV20ClienteId = AV11WizardData.gxTpr_Importarxml.gxTpr_Clienteid;
         new prfinalizarvendatitulo(context ).execute(  AV20ClienteId,  AV18Taxa,  AV23Array_SdNotaFiscal,  AV28Array_SdParcelaCalculadaTaxa, out  AV25PropostaId, out  AV22SdErro) ;
         AssignAttri(sPrefix, false, "AV25PropostaId", StringUtil.LTrimStr( (decimal)(AV25PropostaId), 9, 0));
         if ( AV22SdErro.gxTpr_Internalcode == 0 )
         {
            context.CommitDataStores("wcimpnotafiscalrevisao",pr_default);
            if ( ! AV10HasValidationErrors )
            {
               /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
               S122 ();
               if (returnInSub) return;
               if ( StringUtil.Len( sPrefix) == 0 )
               {
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
                  {
                     gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
                  }
               }
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               GXEncryptionTmp = "wcimpnotafiscal"+UrlEncode(StringUtil.RTrim("Revisao")) + "," + UrlEncode(StringUtil.RTrim("Confirmacao")) + "," + UrlEncode(StringUtil.BoolToStr(false));
               CallWebObject(formatLink("wcimpnotafiscal") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
               context.wjLocDisableFrm = 1;
            }
         }
         else
         {
            context.RollbackDataStores("wcimpnotafiscalrevisao",pr_default);
            GXt_char1 = AV22SdErro.gxTpr_Msg;
            new message(context ).gxep_erro( ref  GXt_char1) ;
            AV22SdErro.gxTpr_Msg = GXt_char1;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11WizardData", AV11WizardData);
      }

      protected void E138R2( )
      {
         /* 'WizardPrevious' Routine */
         returnInSub = false;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wcimpnotafiscal"+UrlEncode(StringUtil.RTrim("Revisao")) + "," + UrlEncode(StringUtil.RTrim("ProdutosNota")) + "," + UrlEncode(StringUtil.BoolToStr(true));
         CallWebObject(formatLink("wcimpnotafiscal") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S112( )
      {
         /* 'LOADVARIABLESFROMWIZARDDATA' Routine */
         returnInSub = false;
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
         AV25PropostaId = AV11WizardData.gxTpr_Revisao.gxTpr_Propostaid;
         AssignAttri(sPrefix, false, "AV25PropostaId", StringUtil.LTrimStr( (decimal)(AV25PropostaId), 9, 0));
      }

      protected void S122( )
      {
         /* 'SAVEVARIABLESTOWIZARDDATA' Routine */
         returnInSub = false;
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
         AV11WizardData.gxTpr_Revisao.gxTpr_Propostaid = AV25PropostaId;
         AV11WizardData.gxTpr_Confirmacao.gxTpr_Propostaprotocolo = AV26EmptyWizardData.gxTpr_Confirmacao.gxTpr_Propostaprotocolo;
         AV11WizardData.gxTpr_Confirmacao.gxTpr_Propostacreatedat = AV26EmptyWizardData.gxTpr_Confirmacao.gxTpr_Propostacreatedat;
         AV11WizardData.gxTpr_Confirmacao.gxTpr_Quantidadeitens = AV26EmptyWizardData.gxTpr_Confirmacao.gxTpr_Quantidadeitens;
         AV11WizardData.gxTpr_Confirmacao.gxTpr_Propostavalor = AV26EmptyWizardData.gxTpr_Confirmacao.gxTpr_Propostavalor;
         AV11WizardData.gxTpr_Confirmacao.gxTpr_Propostastatus = AV26EmptyWizardData.gxTpr_Confirmacao.gxTpr_Propostastatus;
         AV5WebSession.Set(AV6WebSessionKey, AV11WizardData.ToJSonString(false, true));
      }

      protected void nextLoad( )
      {
      }

      protected void E148R2( )
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
         PA8R2( ) ;
         WS8R2( ) ;
         WE8R2( ) ;
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
         PA8R2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wcimpnotafiscalrevisao", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA8R2( ) ;
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
         PA8R2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS8R2( ) ;
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
         WS8R2( ) ;
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
         WE8R2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101962626", true, true);
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
         context.AddJavascriptSource("wcimpnotafiscalrevisao.js", "?20256101962627", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/UcListaItensNotaFiscalRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/UcListaParcelasXTaxasRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblLabeluploaddataxml_Internalname = sPrefix+"LABELUPLOADDATAXML";
         lblLabeldescriptionuploaddata_Internalname = sPrefix+"LABELDESCRIPTIONUPLOADDATA";
         divTablenotasflex_Internalname = sPrefix+"TABLENOTASFLEX";
         lblTabresumo_title_Internalname = sPrefix+"TABRESUMO_TITLE";
         Uclistaitens_Internalname = sPrefix+"UCLISTAITENS";
         divUnnamedtable2_Internalname = sPrefix+"UNNAMEDTABLE2";
         lblTabparcelas_title_Internalname = sPrefix+"TABPARCELAS_TITLE";
         Listaparcelas_Internalname = sPrefix+"LISTAPARCELAS";
         lblInfoheadercontent_Internalname = sPrefix+"INFOHEADERCONTENT";
         divTableinfoboxheader_Internalname = sPrefix+"TABLEINFOBOXHEADER";
         lblInfocontentcontent_Internalname = sPrefix+"INFOCONTENTCONTENT";
         divTableinfoboxcontent_Internalname = sPrefix+"TABLEINFOBOXCONTENT";
         divTableinfobox_Internalname = sPrefix+"TABLEINFOBOX";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         Gxuitabspanel_tabs1_Internalname = sPrefix+"GXUITABSPANEL_TABS1";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         Btnwizardprevious_Internalname = sPrefix+"BTNWIZARDPREVIOUS";
         Btnwizardnext_Internalname = sPrefix+"BTNWIZARDNEXT";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         edtavPropostaid_Internalname = sPrefix+"vPROPOSTAID";
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
         Uclistaitens_Data = "";
         Uclistaitens_Valorfinal = "";
         Uclistaitens_Taxaadm = "";
         Uclistaitens_Juros = "";
         Uclistaitens_Percentualtaxaadm = "";
         Uclistaitens_Percentualjuros = "";
         Listaparcelas_Data = "";
         edtavPropostaid_Jsonclick = "";
         edtavPropostaid_Enabled = 1;
         Btnwizardnext_Class = "Button ButtonWizard";
         Btnwizardnext_Caption = "Confirmar e finalizar";
         Btnwizardnext_Aftericonclass = "fas fa-arrow-right";
         Btnwizardnext_Tooltiptext = "";
         Btnwizardprevious_Class = "BtnDefault ButtonWizard";
         Btnwizardprevious_Caption = "Anterior";
         Btnwizardprevious_Beforeiconclass = "fas fa-arrow-left";
         Btnwizardprevious_Tooltiptext = "";
         lblInfocontentcontent_Caption = "<ul class=\"info-box-list\"><li>Juros de 12% ao ano, calculados proporcionalmente ao prazo de cada parcela</li><li>Taxa administrativa de 20% sobre o valor de cada parcela</li></ul>";
         Gxuitabspanel_tabs1_Historymanagement = Convert.ToBoolean( 0);
         Gxuitabspanel_tabs1_Class = "Tab";
         Gxuitabspanel_tabs1_Pagecount = 2;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV23Array_SdNotaFiscal","fld":"vARRAY_SDNOTAFISCAL","hsh":true,"type":""},{"av":"AV15Array_SdProdutosNotaFiscal","fld":"vARRAY_SDPRODUTOSNOTAFISCAL","hsh":true,"type":""},{"av":"AV18Taxa","fld":"vTAXA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","hsh":true,"type":"decimal"},{"av":"AV28Array_SdParcelaCalculadaTaxa","fld":"vARRAY_SDPARCELACALCULADATAXA","hsh":true,"type":""},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true,"type":"boolean"},{"av":"AV26EmptyWizardData","fld":"vEMPTYWIZARDDATA","hsh":true,"type":""}]}""");
         setEventMetadata("ENTER","""{"handler":"E128R2","iparms":[{"av":"AV23Array_SdNotaFiscal","fld":"vARRAY_SDNOTAFISCAL","hsh":true,"type":""},{"av":"AV15Array_SdProdutosNotaFiscal","fld":"vARRAY_SDPRODUTOSNOTAFISCAL","hsh":true,"type":""},{"av":"AV11WizardData","fld":"vWIZARDDATA","type":""},{"av":"AV18Taxa","fld":"vTAXA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","hsh":true,"type":"decimal"},{"av":"AV28Array_SdParcelaCalculadaTaxa","fld":"vARRAY_SDPARCELACALCULADATAXA","hsh":true,"type":""},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true,"type":"boolean"},{"av":"AV6WebSessionKey","fld":"vWEBSESSIONKEY","type":"svchar"},{"av":"AV25PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV26EmptyWizardData","fld":"vEMPTYWIZARDDATA","hsh":true,"type":""}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV25PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV11WizardData","fld":"vWIZARDDATA","type":""}]}""");
         setEventMetadata("'WIZARDPREVIOUS'","""{"handler":"E138R2","iparms":[]}""");
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
         AV23Array_SdNotaFiscal = new GXBaseCollection<SdtSdNotaFiscal>( context, "SdNotaFiscal", "Factory21");
         AV15Array_SdProdutosNotaFiscal = new GXBaseCollection<SdtSdProdutoNotaFiscal>( context, "SdProdutoNotaFiscal", "Factory21");
         AV28Array_SdParcelaCalculadaTaxa = new GXBaseCollection<SdtSdParcelaCalculadaTaxa>( context, "SdParcelaCalculadaTaxa", "Factory21");
         AV26EmptyWizardData = new SdtWcImpNotaFiscalData(context);
         AV11WizardData = new SdtWcImpNotaFiscalData(context);
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         lblLabeluploaddataxml_Jsonclick = "";
         lblLabeldescriptionuploaddata_Jsonclick = "";
         ucGxuitabspanel_tabs1 = new GXUserControl();
         lblTabresumo_title_Jsonclick = "";
         ucUclistaitens = new GXUserControl();
         lblTabparcelas_title_Jsonclick = "";
         ucListaparcelas = new GXUserControl();
         lblInfoheadercontent_Jsonclick = "";
         lblInfocontentcontent_Jsonclick = "";
         ucBtnwizardprevious = new GXUserControl();
         ucBtnwizardnext = new GXUserControl();
         TempTags = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV33Array_SdListaNotaFiscalVenda = new GXBaseCollection<SdtSdListaNotaFiscalVenda>( context, "SdListaNotaFiscalVenda", "Factory21");
         AV16SdProdutoNotaFiscal = new SdtSdProdutoNotaFiscal(context);
         AV32SdListaNotaFiscalVenda = new SdtSdListaNotaFiscalVenda(context);
         H008R2_A863TaxasId = new int[1] ;
         H008R2_A865TaxasValorMinimo = new decimal[1] ;
         H008R2_n865TaxasValorMinimo = new bool[] {false} ;
         H008R2_A864TaxasPercentual = new decimal[1] ;
         H008R2_n864TaxasPercentual = new bool[] {false} ;
         H008R2_A894TaxasPercentualAnual = new decimal[1] ;
         H008R2_n894TaxasPercentualAnual = new bool[] {false} ;
         AV29SdParcelaCalculadaTaxa = new SdtSdParcelaCalculadaTaxa(context);
         AV21SdNotaFiscal = new SdtSdNotaFiscal(context);
         AV24SdNotaFiscalItem = new SdtSdNotaFiscal_NFe_infNFe_detItem(context);
         AV22SdErro = new SdtSdErro(context);
         GXt_char1 = "";
         AV5WebSession = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV6WebSessionKey = "";
         sCtrlAV8PreviousStep = "";
         sCtrlAV7GoingBack = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wcimpnotafiscalrevisao__default(),
            new Object[][] {
                new Object[] {
               H008R2_A863TaxasId, H008R2_A865TaxasValorMinimo, H008R2_n865TaxasValorMinimo, H008R2_A864TaxasPercentual, H008R2_n864TaxasPercentual, H008R2_A894TaxasPercentualAnual, H008R2_n894TaxasPercentualAnual
               }
            }
         );
         /* GeneXus formulas. */
         edtavPropostaid_Enabled = 0;
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
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
      private int edtavPropostaid_Enabled ;
      private int Gxuitabspanel_tabs1_Pagecount ;
      private int AV25PropostaId ;
      private int AV40GXV1 ;
      private int AV42GXV2 ;
      private int AV43GXV3 ;
      private int AV44GXV4 ;
      private int AV45GXV5 ;
      private int AV46GXV6 ;
      private int AV20ClienteId ;
      private int idxLst ;
      private decimal AV18Taxa ;
      private decimal AV17TotalValor ;
      private decimal AV34Valor ;
      private decimal AV36ValorTotal ;
      private decimal AV35ValorUnitario ;
      private decimal A865TaxasValorMinimo ;
      private decimal A864TaxasPercentual ;
      private decimal A894TaxasPercentualAnual ;
      private decimal AV27TaxaAnual ;
      private decimal AV37TotalAdministracao ;
      private decimal AV38TotalJuros ;
      private decimal AV39TotalString ;
      private decimal AV31TotalParcelaTaxaValor ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string edtavPropostaid_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
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
      private string Gxuitabspanel_tabs1_Class ;
      private string Gxuitabspanel_tabs1_Internalname ;
      private string lblTabresumo_title_Internalname ;
      private string lblTabresumo_title_Jsonclick ;
      private string divUnnamedtable2_Internalname ;
      private string Uclistaitens_Internalname ;
      private string lblTabparcelas_title_Internalname ;
      private string lblTabparcelas_title_Jsonclick ;
      private string divUnnamedtable1_Internalname ;
      private string Listaparcelas_Internalname ;
      private string divTableinfobox_Internalname ;
      private string divTableinfoboxheader_Internalname ;
      private string lblInfoheadercontent_Internalname ;
      private string lblInfoheadercontent_Jsonclick ;
      private string divTableinfoboxcontent_Internalname ;
      private string lblInfocontentcontent_Internalname ;
      private string lblInfocontentcontent_Caption ;
      private string lblInfocontentcontent_Jsonclick ;
      private string divTableactions_Internalname ;
      private string Btnwizardprevious_Tooltiptext ;
      private string Btnwizardprevious_Beforeiconclass ;
      private string Btnwizardprevious_Caption ;
      private string Btnwizardprevious_Class ;
      private string Btnwizardprevious_Internalname ;
      private string Btnwizardnext_Tooltiptext ;
      private string Btnwizardnext_Aftericonclass ;
      private string Btnwizardnext_Caption ;
      private string Btnwizardnext_Class ;
      private string Btnwizardnext_Internalname ;
      private string TempTags ;
      private string edtavPropostaid_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string Listaparcelas_Data ;
      private string Uclistaitens_Percentualjuros ;
      private string Uclistaitens_Percentualtaxaadm ;
      private string Uclistaitens_Juros ;
      private string Uclistaitens_Taxaadm ;
      private string Uclistaitens_Valorfinal ;
      private string Uclistaitens_Data ;
      private string GXt_char1 ;
      private string sCtrlAV6WebSessionKey ;
      private string sCtrlAV8PreviousStep ;
      private string sCtrlAV7GoingBack ;
      private bool AV7GoingBack ;
      private bool wcpOAV7GoingBack ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV10HasValidationErrors ;
      private bool wbLoad ;
      private bool Gxuitabspanel_tabs1_Historymanagement ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV13IsPermiteSelecionar ;
      private bool n865TaxasValorMinimo ;
      private bool n864TaxasPercentual ;
      private bool n894TaxasPercentualAnual ;
      private string AV6WebSessionKey ;
      private string AV8PreviousStep ;
      private string wcpOAV6WebSessionKey ;
      private string wcpOAV8PreviousStep ;
      private IGxSession AV5WebSession ;
      private GXUserControl ucGxuitabspanel_tabs1 ;
      private GXUserControl ucUclistaitens ;
      private GXUserControl ucListaparcelas ;
      private GXUserControl ucBtnwizardprevious ;
      private GXUserControl ucBtnwizardnext ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSdNotaFiscal> AV23Array_SdNotaFiscal ;
      private GXBaseCollection<SdtSdProdutoNotaFiscal> AV15Array_SdProdutosNotaFiscal ;
      private GXBaseCollection<SdtSdParcelaCalculadaTaxa> AV28Array_SdParcelaCalculadaTaxa ;
      private SdtWcImpNotaFiscalData AV26EmptyWizardData ;
      private SdtWcImpNotaFiscalData AV11WizardData ;
      private GXBaseCollection<SdtSdListaNotaFiscalVenda> AV33Array_SdListaNotaFiscalVenda ;
      private SdtSdProdutoNotaFiscal AV16SdProdutoNotaFiscal ;
      private SdtSdListaNotaFiscalVenda AV32SdListaNotaFiscalVenda ;
      private IDataStoreProvider pr_default ;
      private int[] H008R2_A863TaxasId ;
      private decimal[] H008R2_A865TaxasValorMinimo ;
      private bool[] H008R2_n865TaxasValorMinimo ;
      private decimal[] H008R2_A864TaxasPercentual ;
      private bool[] H008R2_n864TaxasPercentual ;
      private decimal[] H008R2_A894TaxasPercentualAnual ;
      private bool[] H008R2_n894TaxasPercentualAnual ;
      private SdtSdParcelaCalculadaTaxa AV29SdParcelaCalculadaTaxa ;
      private SdtSdNotaFiscal AV21SdNotaFiscal ;
      private SdtSdNotaFiscal_NFe_infNFe_detItem AV24SdNotaFiscalItem ;
      private SdtSdErro AV22SdErro ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wcimpnotafiscalrevisao__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH008R2;
          prmH008R2 = new Object[] {
          new ParDef("AV17TotalValor",GXType.Number,18,2)
          };
          def= new CursorDef[] {
              new CursorDef("H008R2", "SELECT TaxasId, TaxasValorMinimo, TaxasPercentual, TaxasPercentualAnual FROM Taxas WHERE TaxasValorMinimo <= :AV17TotalValor ORDER BY TaxasValorMinimo DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH008R2,1, GxCacheFrequency.OFF ,false,true )
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
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
       }
    }

 }

}
