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
   public class wcimpnotafiscalimportarxml : GXWebComponent
   {
      public wcimpnotafiscalimportarxml( )
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

      public wcimpnotafiscalimportarxml( IGxContext context )
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
            PA8P2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS8P2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     WE8P2( ) ;
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
            context.SendWebValue( "Wc Imp Nota Fiscal Importar XML") ;
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
         context.AddJavascriptSource("FileUpload/fileupload.min.js", "", false, true);
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
            GXEncryptionTmp = "wcimpnotafiscalimportarxml"+UrlEncode(StringUtil.RTrim(AV6WebSessionKey)) + "," + UrlEncode(StringUtil.RTrim(AV8PreviousStep)) + "," + UrlEncode(StringUtil.BoolToStr(AV7GoingBack));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wcimpnotafiscalimportarxml") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vCLIENTE", AV31Cliente);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vCLIENTE", AV31Cliente);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCLIENTE", GetSecureSignedToken( sPrefix, AV31Cliente, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vEMPTYWIZARDDATA", AV34EmptyWizardData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vEMPTYWIZARDDATA", AV34EmptyWizardData);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vEMPTYWIZARDDATA", GetSecureSignedToken( sPrefix, AV34EmptyWizardData, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vUPLOADEDFILES", AV12UploadedFiles);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vUPLOADEDFILES", AV12UploadedFiles);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vFAILEDFILES", AV13FailedFiles);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vFAILEDFILES", AV13FailedFiles);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6WebSessionKey", wcpOAV6WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8PreviousStep", wcpOAV8PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV7GoingBack", wcpOAV7GoingBack);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vGOINGBACK", AV7GoingBack);
         GxWebStd.gx_hidden_field( context, sPrefix+"NOTAFISCALNUMERO", A799NotaFiscalNumero);
         GxWebStd.gx_hidden_field( context, sPrefix+"NOTAFISCAEMITENTELDOCUMENTO", A818NotaFiscaEmitentelDocumento);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vCLIENTE", AV31Cliente);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vCLIENTE", AV31Cliente);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCLIENTE", GetSecureSignedToken( sPrefix, AV31Cliente, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWEBSESSIONKEY", AV6WebSessionKey);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vEMPTYWIZARDDATA", AV34EmptyWizardData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vEMPTYWIZARDDATA", AV34EmptyWizardData);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vEMPTYWIZARDDATA", GetSecureSignedToken( sPrefix, AV34EmptyWizardData, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPREVIOUSSTEP", AV8PreviousStep);
         GxWebStd.gx_hidden_field( context, sPrefix+"vCLIENTE_Clientedocumento", AV31Cliente.gxTpr_Clientedocumento);
      }

      protected void RenderHtmlCloseForm8P2( )
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
         return "WcImpNotaFiscalImportarXML" ;
      }

      public override string GetPgmdesc( )
      {
         return "Wc Imp Nota Fiscal Importar XML" ;
      }

      protected void WB8P0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wcimpnotafiscalimportarxml");
               context.AddJavascriptSource("FileUpload/fileupload.min.js", "", false, true);
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
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablenotasflex_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;flex-wrap:wrap;justify-content:center;align-items:center;align-content:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLabeluploaddataxml_Internalname, "<h3>Upload de Notas Fiscais</h3>", "", "", lblLabeluploaddataxml_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WcImpNotaFiscalImportarXML.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLabeldescriptionuploaddata_Internalname, "<h4>Faça o upload dos arquivos XML das notas fiscais para iniciar o processo de venda de títulos.</h4>", "", "", lblLabeldescriptionuploaddata_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WcImpNotaFiscalImportarXML.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLabelerro_Internalname, lblLabelerro_Caption, "", "", lblLabelerro_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_WcImpNotaFiscalImportarXML.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableimportxml_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablefiles_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucXmlsnotafiscal.SetProperty("AutoUpload", Xmlsnotafiscal_Autoupload);
            ucXmlsnotafiscal.SetProperty("HideAdditionalButtons", Xmlsnotafiscal_Hideadditionalbuttons);
            ucXmlsnotafiscal.SetProperty("TooltipText", Xmlsnotafiscal_Tooltiptext);
            ucXmlsnotafiscal.SetProperty("EnableUploadedFileCanceling", Xmlsnotafiscal_Enableuploadedfilecanceling);
            ucXmlsnotafiscal.SetProperty("DisableImageResize", Xmlsnotafiscal_Disableimageresize);
            ucXmlsnotafiscal.SetProperty("MaxNumberOfFiles", Xmlsnotafiscal_Maxnumberoffiles);
            ucXmlsnotafiscal.SetProperty("AutoDisableAddingFiles", Xmlsnotafiscal_Autodisableaddingfiles);
            ucXmlsnotafiscal.SetProperty("AcceptedFileTypes", Xmlsnotafiscal_Acceptedfiletypes);
            ucXmlsnotafiscal.SetProperty("CustomFileTypes", Xmlsnotafiscal_Customfiletypes);
            ucXmlsnotafiscal.SetProperty("UploadedFiles", AV12UploadedFiles);
            ucXmlsnotafiscal.SetProperty("FailedFiles", AV13FailedFiles);
            ucXmlsnotafiscal.Render(context, "fileupload", Xmlsnotafiscal_Internalname, sPrefix+"XMLSNOTAFISCALContainer");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 ActionGroupFixedBottomWizard", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;justify-content:space-between;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* User Defined Control */
            ucBtnwizardfirstprevious.SetProperty("TooltipText", Btnwizardfirstprevious_Tooltiptext);
            ucBtnwizardfirstprevious.SetProperty("BeforeIconClass", Btnwizardfirstprevious_Beforeiconclass);
            ucBtnwizardfirstprevious.SetProperty("Caption", Btnwizardfirstprevious_Caption);
            ucBtnwizardfirstprevious.SetProperty("Class", Btnwizardfirstprevious_Class);
            ucBtnwizardfirstprevious.Render(context, "wwp_iconbutton", Btnwizardfirstprevious_Internalname, sPrefix+"BTNWIZARDFIRSTPREVIOUSContainer");
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
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavJsonsdnotafiscal_Internalname, AV15JSONSdNotaFiscal, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", 0, edtavJsonsdnotafiscal_Visible, 1, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, false, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WcImpNotaFiscalImportarXML.htm");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavJsonsdprodutosnota_Internalname, AV16JSONSdProdutosNota, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", 0, edtavJsonsdprodutosnota_Visible, 1, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, false, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WcImpNotaFiscalImportarXML.htm");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavJsonbase64arquivos_Internalname, AV17JSONBase64Arquivos, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", 0, edtavJsonbase64arquivos_Visible, 1, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, false, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WcImpNotaFiscalImportarXML.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClienteid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29ClienteId), 9, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV29ClienteId), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,46);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClienteid_Jsonclick, 0, "Attribute", "", "", "", "", edtavClienteid_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, false, "", "end", false, "", "HLP_WcImpNotaFiscalImportarXML.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START8P2( )
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
            Form.Meta.addItem("description", "Wc Imp Nota Fiscal Importar XML", 0) ;
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
               STRUP8P0( ) ;
            }
         }
      }

      protected void WS8P2( )
      {
         START8P2( ) ;
         EVT8P2( ) ;
      }

      protected void EVT8P2( )
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
                                 STRUP8P0( ) ;
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
                                 STRUP8P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E118P2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP8P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E128P2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP8P0( ) ;
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
                                          E138P2 ();
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
                                 STRUP8P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'WizardPrevious' */
                                    E148P2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP8P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E158P2 ();
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP8P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavJsonsdnotafiscal_Internalname;
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

      protected void WE8P2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm8P2( ) ;
            }
         }
      }

      protected void PA8P2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wcimpnotafiscalimportarxml")), "wcimpnotafiscalimportarxml") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wcimpnotafiscalimportarxml")))) ;
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
                     if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                     {
                        AV6WebSessionKey = gxfirstwebparm;
                        AssignAttri(sPrefix, false, "AV6WebSessionKey", AV6WebSessionKey);
                        if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                        {
                           AV8PreviousStep = GetPar( "PreviousStep");
                           AssignAttri(sPrefix, false, "AV8PreviousStep", AV8PreviousStep);
                           AV7GoingBack = StringUtil.StrToBool( GetPar( "GoingBack"));
                           AssignAttri(sPrefix, false, "AV7GoingBack", AV7GoingBack);
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
               GX_FocusControl = edtavJsonsdnotafiscal_Internalname;
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
         RF8P2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF8P2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E128P2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E158P2 ();
            WB8P0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes8P2( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vCLIENTE", AV31Cliente);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vCLIENTE", AV31Cliente);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCLIENTE", GetSecureSignedToken( sPrefix, AV31Cliente, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vEMPTYWIZARDDATA", AV34EmptyWizardData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vEMPTYWIZARDDATA", AV34EmptyWizardData);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vEMPTYWIZARDDATA", GetSecureSignedToken( sPrefix, AV34EmptyWizardData, context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP8P0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E118P2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vUPLOADEDFILES"), AV12UploadedFiles);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vFAILEDFILES"), AV13FailedFiles);
            /* Read saved values. */
            wcpOAV6WebSessionKey = cgiGet( sPrefix+"wcpOAV6WebSessionKey");
            wcpOAV8PreviousStep = cgiGet( sPrefix+"wcpOAV8PreviousStep");
            wcpOAV7GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV7GoingBack"));
            /* Read variables values. */
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
         E118P2 ();
         if (returnInSub) return;
      }

      protected void E118P2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADVARIABLESFROMWIZARDDATA' */
         S112 ();
         if (returnInSub) return;
         edtavJsonsdnotafiscal_Visible = 0;
         AssignProp(sPrefix, false, edtavJsonsdnotafiscal_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavJsonsdnotafiscal_Visible), 5, 0), true);
         edtavJsonsdprodutosnota_Visible = 0;
         AssignProp(sPrefix, false, edtavJsonsdprodutosnota_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavJsonsdprodutosnota_Visible), 5, 0), true);
         edtavJsonbase64arquivos_Visible = 0;
         AssignProp(sPrefix, false, edtavJsonbase64arquivos_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavJsonbase64arquivos_Visible), 5, 0), true);
         edtavClienteid_Visible = 0;
         AssignProp(sPrefix, false, edtavClienteid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClienteid_Visible), 5, 0), true);
         GXt_SdtWWPContext1 = AV38WWPContext;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  GXt_SdtWWPContext1) ;
         AV38WWPContext = GXt_SdtWWPContext1;
         AV29ClienteId = AV38WWPContext.gxTpr_Ownerid;
         AssignAttri(sPrefix, false, "AV29ClienteId", StringUtil.LTrimStr( (decimal)(AV29ClienteId), 9, 0));
         AV31Cliente.Load(AV29ClienteId);
      }

      protected void E128P2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S122 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E138P2 ();
         if (returnInSub) return;
      }

      protected void E138P2( )
      {
         /* Enter Routine */
         returnInSub = false;
         lblLabelerro_Caption = "<span></span>";
         AssignProp(sPrefix, false, lblLabelerro_Internalname, "Caption", lblLabelerro_Caption, true);
         AV30IsErro = false;
         AV15JSONSdNotaFiscal = "";
         AssignAttri(sPrefix, false, "AV15JSONSdNotaFiscal", AV15JSONSdNotaFiscal);
         AV17JSONBase64Arquivos = "";
         AssignAttri(sPrefix, false, "AV17JSONBase64Arquivos", AV17JSONBase64Arquivos);
         AV16JSONSdProdutosNota = "";
         AssignAttri(sPrefix, false, "AV16JSONSdProdutosNota", AV16JSONSdProdutosNota);
         AV18Array_SdNotaFiscal = new GXBaseCollection<SdtSdNotaFiscal>( context, "SdNotaFiscal", "Factory21");
         AV25Arquivos = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV32Lista = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV39GXV1 = 1;
         while ( AV39GXV1 <= AV12UploadedFiles.Count )
         {
            AV14FileUploadData = ((SdtFileUploadData)AV12UploadedFiles.Item(AV39GXV1));
            AV19File = new GxFile(context.GetPhysicalPath());
            AV19File.Source = "publictempstorage/teste.xml";
            AV19File.Create();
            AV19File.FromBase64(context.FileToBase64( AV14FileUploadData.gxTpr_File));
            AV20StringNota = AV19File.ReadAllText("");
            AV25Arquivos.Add(AV20StringNota, 0);
            new prlerxml(context ).execute(  AV20StringNota, out  AV21SdNotaFiscal) ;
            AV21SdNotaFiscal.gxTpr_Nome_arquivo = AV14FileUploadData.gxTpr_Name;
            AV28IsAdd = true;
            AV40GXV2 = 1;
            while ( AV40GXV2 <= AV18Array_SdNotaFiscal.Count )
            {
               AV27AuxSdNotaFiscal = ((SdtSdNotaFiscal)AV18Array_SdNotaFiscal.Item(AV40GXV2));
               if ( AV27AuxSdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Cobr.gxTpr_Dup.Count == 0 )
               {
                  AV32Lista.Add(StringUtil.Format( "Atenção: Não foram encontradas duplicatas na nota fiscal. Verifique se as condições de pagamento foram corretamente informadas. (Arquivo: %1)", AV14FileUploadData.gxTpr_Name, "", "", "", "", "", "", "", ""), 0);
               }
               if ( StringUtil.StrCmp(AV27AuxSdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Id, AV21SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Id) == 0 )
               {
                  AV32Lista.Add(StringUtil.Format( "Nota fiscal duplicada (Arquivo: %1), verifique!", AV14FileUploadData.gxTpr_Name, "", "", "", "", "", "", "", ""), 0);
                  AV30IsErro = true;
                  AV28IsAdd = false;
                  if (true) break;
               }
               AV40GXV2 = (int)(AV40GXV2+1);
            }
            if ( AV28IsAdd )
            {
               AV18Array_SdNotaFiscal.Add(AV21SdNotaFiscal, 0);
            }
            AV39GXV1 = (int)(AV39GXV1+1);
         }
         AV22Array_SdProdutoNotaFiscal = new GXBaseCollection<SdtSdProdutoNotaFiscal>( context, "SdProdutoNotaFiscal", "Factory21");
         AV26id = 1;
         AV41GXV3 = 1;
         while ( AV41GXV3 <= AV18Array_SdNotaFiscal.Count )
         {
            AV21SdNotaFiscal = ((SdtSdNotaFiscal)AV18Array_SdNotaFiscal.Item(AV41GXV3));
            /* Using cursor H008P2 */
            pr_default.execute(0, new Object[] {AV21SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Ide.gxTpr_Nnf, AV21SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Emit.gxTpr_Cnpj});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A818NotaFiscaEmitentelDocumento = H008P2_A818NotaFiscaEmitentelDocumento[0];
               n818NotaFiscaEmitentelDocumento = H008P2_n818NotaFiscaEmitentelDocumento[0];
               A799NotaFiscalNumero = H008P2_A799NotaFiscalNumero[0];
               n799NotaFiscalNumero = H008P2_n799NotaFiscalNumero[0];
               AV30IsErro = true;
               AV32Lista.Add(StringUtil.Format( "Nota fiscal (%1) do arquivo (%2) já foi importada anteriormente, verifique!", A799NotaFiscalNumero, AV21SdNotaFiscal.gxTpr_Nome_arquivo, "", "", "", "", "", "", ""), 0);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            if ( StringUtil.StrCmp(AV31Cliente.gxTpr_Clientedocumento, AV21SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Emit.gxTpr_Cnpj) != 0 )
            {
               AV32Lista.Add(StringUtil.Format( "Nota fiscal (%1) do arquivo (%2) não é do CNPJ %3, verifique!", AV21SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Ide.gxTpr_Nnf, AV21SdNotaFiscal.gxTpr_Nome_arquivo, AV31Cliente.gxTpr_Clientedocumento, "", "", "", "", "", ""), 0);
               AV30IsErro = true;
            }
            AV43GXV4 = 1;
            while ( AV43GXV4 <= AV21SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Det.Count )
            {
               AV23SdNotaFiscalDet = ((SdtSdNotaFiscal_NFe_infNFe_detItem)AV21SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Det.Item(AV43GXV4));
               AV24SdProdutoNotaFiscal = new SdtSdProdutoNotaFiscal(context);
               AV24SdProdutoNotaFiscal.FromJSonString(AV23SdNotaFiscalDet.gxTpr_Prod.ToJSonString(false, true), null);
               AV24SdProdutoNotaFiscal.gxTpr_Cnfe = AV21SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Ide.gxTpr_Cnf;
               AV24SdProdutoNotaFiscal.gxTpr_Id = AV26id;
               AV26id = (int)(AV26id+1);
               AV22Array_SdProdutoNotaFiscal.Add(AV24SdProdutoNotaFiscal, 0);
               AV43GXV4 = (int)(AV43GXV4+1);
            }
            AV41GXV3 = (int)(AV41GXV3+1);
         }
         AV15JSONSdNotaFiscal = AV18Array_SdNotaFiscal.ToJSonString(false);
         AssignAttri(sPrefix, false, "AV15JSONSdNotaFiscal", AV15JSONSdNotaFiscal);
         AV17JSONBase64Arquivos = AV25Arquivos.ToJSonString(false);
         AssignAttri(sPrefix, false, "AV17JSONBase64Arquivos", AV17JSONBase64Arquivos);
         AV16JSONSdProdutosNota = AV22Array_SdProdutoNotaFiscal.ToJSonString(false);
         AssignAttri(sPrefix, false, "AV16JSONSdProdutosNota", AV16JSONSdProdutosNota);
         if ( ! ( AV18Array_SdNotaFiscal.Count == 0 ) && ! AV30IsErro )
         {
            if ( ! AV10HasValidationErrors )
            {
               /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
               S132 ();
               if (returnInSub) return;
               if ( StringUtil.Len( sPrefix) == 0 )
               {
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
                  {
                     gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
                  }
               }
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               GXEncryptionTmp = "wcimpnotafiscal"+UrlEncode(StringUtil.RTrim("ImportarXML")) + "," + UrlEncode(StringUtil.RTrim("ProdutosNota")) + "," + UrlEncode(StringUtil.BoolToStr(false));
               CallWebObject(formatLink("wcimpnotafiscal") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
               context.wjLocDisableFrm = 1;
            }
         }
         else
         {
            if ( AV18Array_SdNotaFiscal.Count == 0 )
            {
               AV32Lista.Add("Não é possível continuar sem arquivo.", 0);
            }
            if ( ! ( AV32Lista.Count == 0 ) )
            {
               new prcriarerrolista(context ).execute(  AV32Lista, out  AV33HTML) ;
               lblLabelerro_Caption = AV33HTML;
               AssignProp(sPrefix, false, lblLabelerro_Internalname, "Caption", lblLabelerro_Caption, true);
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV21SdNotaFiscal", AV21SdNotaFiscal);
      }

      protected void E148P2( )
      {
         /* 'WizardPrevious' Routine */
         returnInSub = false;
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S122( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ! AV7GoingBack ) )
         {
            Btnwizardfirstprevious_Visible = false;
            ucBtnwizardfirstprevious.SendProperty(context, sPrefix, false, Btnwizardfirstprevious_Internalname, "Visible", StringUtil.BoolToStr( Btnwizardfirstprevious_Visible));
         }
      }

      protected void S112( )
      {
         /* 'LOADVARIABLESFROMWIZARDDATA' Routine */
         returnInSub = false;
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
         AV15JSONSdNotaFiscal = AV11WizardData.gxTpr_Importarxml.gxTpr_Jsonsdnotafiscal;
         AssignAttri(sPrefix, false, "AV15JSONSdNotaFiscal", AV15JSONSdNotaFiscal);
         AV16JSONSdProdutosNota = AV11WizardData.gxTpr_Importarxml.gxTpr_Jsonsdprodutosnota;
         AssignAttri(sPrefix, false, "AV16JSONSdProdutosNota", AV16JSONSdProdutosNota);
         AV17JSONBase64Arquivos = AV11WizardData.gxTpr_Importarxml.gxTpr_Jsonbase64arquivos;
         AssignAttri(sPrefix, false, "AV17JSONBase64Arquivos", AV17JSONBase64Arquivos);
         AV29ClienteId = AV11WizardData.gxTpr_Importarxml.gxTpr_Clienteid;
         AssignAttri(sPrefix, false, "AV29ClienteId", StringUtil.LTrimStr( (decimal)(AV29ClienteId), 9, 0));
      }

      protected void S132( )
      {
         /* 'SAVEVARIABLESTOWIZARDDATA' Routine */
         returnInSub = false;
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
         AV11WizardData.gxTpr_Importarxml.gxTpr_Jsonsdnotafiscal = AV15JSONSdNotaFiscal;
         AV11WizardData.gxTpr_Importarxml.gxTpr_Jsonsdprodutosnota = AV16JSONSdProdutosNota;
         AV11WizardData.gxTpr_Importarxml.gxTpr_Jsonbase64arquivos = AV17JSONBase64Arquivos;
         AV11WizardData.gxTpr_Importarxml.gxTpr_Clienteid = AV29ClienteId;
         AV11WizardData.gxTpr_Produtosnota.gxTpr_Jsonsdprodutosnota = AV34EmptyWizardData.gxTpr_Produtosnota.gxTpr_Jsonsdprodutosnota;
         AV11WizardData.gxTpr_Produtosnota.gxTpr_Totalsel = AV34EmptyWizardData.gxTpr_Produtosnota.gxTpr_Totalsel;
         AV5WebSession.Set(AV6WebSessionKey, AV11WizardData.ToJSonString(false, true));
      }

      protected void nextLoad( )
      {
      }

      protected void E158P2( )
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
         PA8P2( ) ;
         WS8P2( ) ;
         WE8P2( ) ;
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
         PA8P2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wcimpnotafiscalimportarxml", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA8P2( ) ;
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
         PA8P2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS8P2( ) ;
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
         WS8P2( ) ;
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
         WE8P2( ) ;
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
         AddStyleSheetFile("FileUpload/fileupload.min.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019133198", true, true);
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
         context.AddJavascriptSource("messages.por.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("wcimpnotafiscalimportarxml.js", "?20256101913320", false, true);
         context.AddJavascriptSource("FileUpload/fileupload.min.js", "", false, true);
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
         lblLabelerro_Internalname = sPrefix+"LABELERRO";
         divTablenotasflex_Internalname = sPrefix+"TABLENOTASFLEX";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         Xmlsnotafiscal_Internalname = sPrefix+"XMLSNOTAFISCAL";
         divTablefiles_Internalname = sPrefix+"TABLEFILES";
         divTableimportxml_Internalname = sPrefix+"TABLEIMPORTXML";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         Btnwizardfirstprevious_Internalname = sPrefix+"BTNWIZARDFIRSTPREVIOUS";
         Btnwizardnext_Internalname = sPrefix+"BTNWIZARDNEXT";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavJsonsdnotafiscal_Internalname = sPrefix+"vJSONSDNOTAFISCAL";
         edtavJsonsdprodutosnota_Internalname = sPrefix+"vJSONSDPRODUTOSNOTA";
         edtavJsonbase64arquivos_Internalname = sPrefix+"vJSONBASE64ARQUIVOS";
         edtavClienteid_Internalname = sPrefix+"vCLIENTEID";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
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
         Btnwizardfirstprevious_Visible = Convert.ToBoolean( -1);
         edtavClienteid_Jsonclick = "";
         edtavClienteid_Visible = 1;
         edtavJsonbase64arquivos_Visible = 1;
         edtavJsonsdprodutosnota_Visible = 1;
         edtavJsonsdnotafiscal_Visible = 1;
         Btnwizardnext_Class = "Button ButtonWizard";
         Btnwizardnext_Caption = "Próximo";
         Btnwizardnext_Aftericonclass = "fas fa-arrow-right";
         Btnwizardnext_Tooltiptext = "";
         Btnwizardfirstprevious_Class = "BtnDefault ButtonWizard";
         Btnwizardfirstprevious_Caption = "Fechar";
         Btnwizardfirstprevious_Beforeiconclass = "fas fa-arrow-left";
         Btnwizardfirstprevious_Tooltiptext = "";
         Xmlsnotafiscal_Customfiletypes = "xml";
         Xmlsnotafiscal_Acceptedfiletypes = "custom";
         Xmlsnotafiscal_Autodisableaddingfiles = Convert.ToBoolean( -1);
         Xmlsnotafiscal_Maxnumberoffiles = 0;
         Xmlsnotafiscal_Disableimageresize = Convert.ToBoolean( 0);
         Xmlsnotafiscal_Enableuploadedfilecanceling = Convert.ToBoolean( -1);
         Xmlsnotafiscal_Tooltiptext = "";
         Xmlsnotafiscal_Hideadditionalbuttons = Convert.ToBoolean( -1);
         Xmlsnotafiscal_Autoupload = Convert.ToBoolean( -1);
         lblLabelerro_Caption = "<span></span>";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV7GoingBack","fld":"vGOINGBACK","type":"boolean"},{"av":"AV31Cliente","fld":"vCLIENTE","hsh":true,"type":""},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true,"type":"boolean"},{"av":"AV34EmptyWizardData","fld":"vEMPTYWIZARDDATA","hsh":true,"type":""}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"Btnwizardfirstprevious_Visible","ctrl":"BTNWIZARDFIRSTPREVIOUS","prop":"Visible"}]}""");
         setEventMetadata("ENTER","""{"handler":"E138P2","iparms":[{"av":"AV12UploadedFiles","fld":"vUPLOADEDFILES","type":""},{"av":"A799NotaFiscalNumero","fld":"NOTAFISCALNUMERO","type":"svchar"},{"av":"A818NotaFiscaEmitentelDocumento","fld":"NOTAFISCAEMITENTELDOCUMENTO","type":"svchar"},{"av":"AV31Cliente","fld":"vCLIENTE","hsh":true,"type":""},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true,"type":"boolean"},{"av":"AV6WebSessionKey","fld":"vWEBSESSIONKEY","type":"svchar"},{"av":"AV15JSONSdNotaFiscal","fld":"vJSONSDNOTAFISCAL","type":"vchar"},{"av":"AV16JSONSdProdutosNota","fld":"vJSONSDPRODUTOSNOTA","type":"vchar"},{"av":"AV17JSONBase64Arquivos","fld":"vJSONBASE64ARQUIVOS","type":"vchar"},{"av":"AV29ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV34EmptyWizardData","fld":"vEMPTYWIZARDDATA","hsh":true,"type":""}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"lblLabelerro_Caption","ctrl":"LABELERRO","prop":"Caption"},{"av":"AV15JSONSdNotaFiscal","fld":"vJSONSDNOTAFISCAL","type":"vchar"},{"av":"AV17JSONBase64Arquivos","fld":"vJSONBASE64ARQUIVOS","type":"vchar"},{"av":"AV16JSONSdProdutosNota","fld":"vJSONSDPRODUTOSNOTA","type":"vchar"},{"av":"AV21SdNotaFiscal","fld":"vSDNOTAFISCAL","type":""}]}""");
         setEventMetadata("'WIZARDPREVIOUS'","""{"handler":"E148P2","iparms":[]}""");
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

      public override bool UploadEnabled( )
      {
         return true ;
      }

      public override void initialize( )
      {
         wcpOAV6WebSessionKey = "";
         wcpOAV8PreviousStep = "";
         AV31Cliente = new SdtCliente(context);
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV34EmptyWizardData = new SdtWcImpNotaFiscalData(context);
         AV12UploadedFiles = new GXBaseCollection<SdtFileUploadData>( context, "FileUploadData", "Factory21");
         AV13FailedFiles = new GXBaseCollection<SdtFileUploadData>( context, "FileUploadData", "Factory21");
         A799NotaFiscalNumero = "";
         A818NotaFiscaEmitentelDocumento = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         lblLabeluploaddataxml_Jsonclick = "";
         lblLabeldescriptionuploaddata_Jsonclick = "";
         lblLabelerro_Jsonclick = "";
         ucXmlsnotafiscal = new GXUserControl();
         ucBtnwizardfirstprevious = new GXUserControl();
         ucBtnwizardnext = new GXUserControl();
         TempTags = "";
         AV15JSONSdNotaFiscal = "";
         AV16JSONSdProdutosNota = "";
         AV17JSONBase64Arquivos = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV38WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtWWPContext1 = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV18Array_SdNotaFiscal = new GXBaseCollection<SdtSdNotaFiscal>( context, "SdNotaFiscal", "Factory21");
         AV25Arquivos = new GxSimpleCollection<string>();
         AV32Lista = new GxSimpleCollection<string>();
         AV14FileUploadData = new SdtFileUploadData(context);
         AV19File = new GxFile(context.GetPhysicalPath());
         AV20StringNota = "";
         AV21SdNotaFiscal = new SdtSdNotaFiscal(context);
         AV27AuxSdNotaFiscal = new SdtSdNotaFiscal(context);
         AV22Array_SdProdutoNotaFiscal = new GXBaseCollection<SdtSdProdutoNotaFiscal>( context, "SdProdutoNotaFiscal", "Factory21");
         H008P2_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         H008P2_A818NotaFiscaEmitentelDocumento = new string[] {""} ;
         H008P2_n818NotaFiscaEmitentelDocumento = new bool[] {false} ;
         H008P2_A799NotaFiscalNumero = new string[] {""} ;
         H008P2_n799NotaFiscalNumero = new bool[] {false} ;
         AV23SdNotaFiscalDet = new SdtSdNotaFiscal_NFe_infNFe_detItem(context);
         AV24SdProdutoNotaFiscal = new SdtSdProdutoNotaFiscal(context);
         AV33HTML = "";
         AV11WizardData = new SdtWcImpNotaFiscalData(context);
         AV5WebSession = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV6WebSessionKey = "";
         sCtrlAV8PreviousStep = "";
         sCtrlAV7GoingBack = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wcimpnotafiscalimportarxml__default(),
            new Object[][] {
                new Object[] {
               H008P2_A794NotaFiscalId, H008P2_A818NotaFiscaEmitentelDocumento, H008P2_n818NotaFiscaEmitentelDocumento, H008P2_A799NotaFiscalNumero, H008P2_n799NotaFiscalNumero
               }
            }
         );
         /* GeneXus formulas. */
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
      private int Xmlsnotafiscal_Maxnumberoffiles ;
      private int edtavJsonsdnotafiscal_Visible ;
      private int edtavJsonsdprodutosnota_Visible ;
      private int edtavJsonbase64arquivos_Visible ;
      private int AV29ClienteId ;
      private int edtavClienteid_Visible ;
      private int AV39GXV1 ;
      private int AV40GXV2 ;
      private int AV26id ;
      private int AV41GXV3 ;
      private int AV43GXV4 ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
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
      private string lblLabelerro_Internalname ;
      private string lblLabelerro_Caption ;
      private string lblLabelerro_Jsonclick ;
      private string divTableimportxml_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string divTablefiles_Internalname ;
      private string Xmlsnotafiscal_Tooltiptext ;
      private string Xmlsnotafiscal_Acceptedfiletypes ;
      private string Xmlsnotafiscal_Customfiletypes ;
      private string Xmlsnotafiscal_Internalname ;
      private string divTableactions_Internalname ;
      private string Btnwizardfirstprevious_Tooltiptext ;
      private string Btnwizardfirstprevious_Beforeiconclass ;
      private string Btnwizardfirstprevious_Caption ;
      private string Btnwizardfirstprevious_Class ;
      private string Btnwizardfirstprevious_Internalname ;
      private string Btnwizardnext_Tooltiptext ;
      private string Btnwizardnext_Aftericonclass ;
      private string Btnwizardnext_Caption ;
      private string Btnwizardnext_Class ;
      private string Btnwizardnext_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string TempTags ;
      private string edtavJsonsdnotafiscal_Internalname ;
      private string edtavJsonsdprodutosnota_Internalname ;
      private string edtavJsonbase64arquivos_Internalname ;
      private string edtavClienteid_Internalname ;
      private string edtavClienteid_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string sCtrlAV6WebSessionKey ;
      private string sCtrlAV8PreviousStep ;
      private string sCtrlAV7GoingBack ;
      private bool AV7GoingBack ;
      private bool wcpOAV7GoingBack ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV10HasValidationErrors ;
      private bool wbLoad ;
      private bool Xmlsnotafiscal_Autoupload ;
      private bool Xmlsnotafiscal_Hideadditionalbuttons ;
      private bool Xmlsnotafiscal_Enableuploadedfilecanceling ;
      private bool Xmlsnotafiscal_Disableimageresize ;
      private bool Xmlsnotafiscal_Autodisableaddingfiles ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV30IsErro ;
      private bool AV28IsAdd ;
      private bool n818NotaFiscaEmitentelDocumento ;
      private bool n799NotaFiscalNumero ;
      private bool Btnwizardfirstprevious_Visible ;
      private string AV15JSONSdNotaFiscal ;
      private string AV16JSONSdProdutosNota ;
      private string AV17JSONBase64Arquivos ;
      private string AV20StringNota ;
      private string AV33HTML ;
      private string AV6WebSessionKey ;
      private string AV8PreviousStep ;
      private string wcpOAV6WebSessionKey ;
      private string wcpOAV8PreviousStep ;
      private string A799NotaFiscalNumero ;
      private string A818NotaFiscaEmitentelDocumento ;
      private IGxSession AV5WebSession ;
      private GXUserControl ucXmlsnotafiscal ;
      private GXUserControl ucBtnwizardfirstprevious ;
      private GXUserControl ucBtnwizardnext ;
      private GXWebForm Form ;
      private GxFile AV19File ;
      private IGxDataStore dsDefault ;
      private SdtCliente AV31Cliente ;
      private SdtWcImpNotaFiscalData AV34EmptyWizardData ;
      private GXBaseCollection<SdtFileUploadData> AV12UploadedFiles ;
      private GXBaseCollection<SdtFileUploadData> AV13FailedFiles ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV38WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext GXt_SdtWWPContext1 ;
      private GXBaseCollection<SdtSdNotaFiscal> AV18Array_SdNotaFiscal ;
      private GxSimpleCollection<string> AV25Arquivos ;
      private GxSimpleCollection<string> AV32Lista ;
      private SdtFileUploadData AV14FileUploadData ;
      private SdtSdNotaFiscal AV21SdNotaFiscal ;
      private SdtSdNotaFiscal AV27AuxSdNotaFiscal ;
      private GXBaseCollection<SdtSdProdutoNotaFiscal> AV22Array_SdProdutoNotaFiscal ;
      private IDataStoreProvider pr_default ;
      private Guid[] H008P2_A794NotaFiscalId ;
      private string[] H008P2_A818NotaFiscaEmitentelDocumento ;
      private bool[] H008P2_n818NotaFiscaEmitentelDocumento ;
      private string[] H008P2_A799NotaFiscalNumero ;
      private bool[] H008P2_n799NotaFiscalNumero ;
      private SdtSdNotaFiscal_NFe_infNFe_detItem AV23SdNotaFiscalDet ;
      private SdtSdProdutoNotaFiscal AV24SdProdutoNotaFiscal ;
      private SdtWcImpNotaFiscalData AV11WizardData ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wcimpnotafiscalimportarxml__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH008P2;
          prmH008P2 = new Object[] {
          new ParDef("AV21SdNo_1Nfe_1Infnfe_1Ide_1N",GXType.VarChar,100,0) ,
          new ParDef("AV21SdNo_2Nfe_2Infnfe_2Emit_2",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H008P2", "SELECT NotaFiscalId, NotaFiscaEmitentelDocumento, NotaFiscalNumero FROM NotaFiscal WHERE (NotaFiscalNumero = ( :AV21SdNo_1Nfe_1Infnfe_1Ide_1N)) AND (NotaFiscaEmitentelDocumento = ( :AV21SdNo_2Nfe_2Infnfe_2Emit_2)) ORDER BY NotaFiscalId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH008P2,100, GxCacheFrequency.OFF ,false,false )
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
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
       }
    }

 }

}
