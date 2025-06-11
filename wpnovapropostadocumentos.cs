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
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class wpnovapropostadocumentos : GXWebComponent
   {
      public wpnovapropostadocumentos( )
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

      public wpnovapropostadocumentos( IGxContext context )
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
         cmbavDocumentoobrigatorio = new GXCombobox();
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Griddocumentos") == 0 )
               {
                  gxnrGriddocumentos_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Griddocumentos") == 0 )
               {
                  gxgrGriddocumentos_refresh_invoke( ) ;
                  return  ;
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

      protected void gxnrGriddocumentos_newrow_invoke( )
      {
         nRC_GXsfl_15 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_15"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_15_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_15_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_15_idx = GetPar( "sGXsfl_15_idx");
         sPrefix = GetPar( "sPrefix");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGriddocumentos_newrow( ) ;
         /* End function gxnrGriddocumentos_newrow_invoke */
      }

      protected void gxgrGriddocumentos_refresh_invoke( )
      {
         subGriddocumentos_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGriddocumentos_Rows"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV27Array_SdPropostaDocumento);
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGriddocumentos_refresh( subGriddocumentos_Rows, AV27Array_SdPropostaDocumento, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGriddocumentos_refresh_invoke */
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
            PA5Y2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavAdicionaranexo_Enabled = 0;
               AssignProp(sPrefix, false, edtavAdicionaranexo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAdicionaranexo_Enabled), 5, 0), !bGXsfl_15_Refreshing);
               edtavDownload_Enabled = 0;
               AssignProp(sPrefix, false, edtavDownload_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDownload_Enabled), 5, 0), !bGXsfl_15_Refreshing);
               edtavDocumentosid_Enabled = 0;
               AssignProp(sPrefix, false, edtavDocumentosid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocumentosid_Enabled), 5, 0), !bGXsfl_15_Refreshing);
               edtavDocumentosdescricao_Enabled = 0;
               AssignProp(sPrefix, false, edtavDocumentosdescricao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocumentosdescricao_Enabled), 5, 0), !bGXsfl_15_Refreshing);
               cmbavDocumentoobrigatorio.Enabled = 0;
               AssignProp(sPrefix, false, cmbavDocumentoobrigatorio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavDocumentoobrigatorio.Enabled), 5, 0), !bGXsfl_15_Refreshing);
               edtavDocumento_Enabled = 0;
               AssignProp(sPrefix, false, edtavDocumento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocumento_Enabled), 5, 0), !bGXsfl_15_Refreshing);
               edtavNome_Enabled = 0;
               AssignProp(sPrefix, false, edtavNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNome_Enabled), 5, 0), !bGXsfl_15_Refreshing);
               edtavExtensao_Enabled = 0;
               AssignProp(sPrefix, false, edtavExtensao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavExtensao_Enabled), 5, 0), !bGXsfl_15_Refreshing);
               edtavNomearquivo_Enabled = 0;
               AssignProp(sPrefix, false, edtavNomearquivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNomearquivo_Enabled), 5, 0), !bGXsfl_15_Refreshing);
               WS5Y2( ) ;
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
            context.SendWebValue( "Wp Nova Proposta Documentos") ;
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
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
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
            GXEncryptionTmp = "wpnovapropostadocumentos"+UrlEncode(StringUtil.RTrim(AV6WebSessionKey)) + "," + UrlEncode(StringUtil.RTrim(AV8PreviousStep)) + "," + UrlEncode(StringUtil.BoolToStr(AV7GoingBack));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpnovapropostadocumentos") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_15", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_15), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6WebSessionKey", wcpOAV6WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8PreviousStep", wcpOAV8PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV7GoingBack", wcpOAV7GoingBack);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vARRAY_SDPROPOSTADOCUMENTO", AV27Array_SdPropostaDocumento);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vARRAY_SDPROPOSTADOCUMENTO", AV27Array_SdPropostaDocumento);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vWEBSESSIONKEY", AV6WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"vINNOME", AV30InNome);
         GxWebStd.gx_hidden_field( context, sPrefix+"vINEXTENSAO", AV31InExtensao);
         GxWebStd.gx_hidden_field( context, sPrefix+"vBLOB", AV29Blob);
         GxWebStd.gx_hidden_field( context, sPrefix+"vINDOCUMENTOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32InDocumentosId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPREVIOUSSTEP", AV8PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vGOINGBACK", AV7GoingBack);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDPROPOSTADOCUMENTO", AV28SdPropostaDocumento);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDPROPOSTADOCUMENTO", AV28SdPropostaDocumento);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vGXV2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40GXV2), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDDOCUMENTOS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDDOCUMENTOS_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDDOCUMENTOS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDDOCUMENTOS_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"subGriddocumentos_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddocumentos_Recordcount), 5, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDDOCUMENTOS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddocumentos_Rows), 6, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm5Y2( )
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
         return "WpNovaPropostaDocumentos" ;
      }

      public override string GetPgmdesc( )
      {
         return "Wp Nova Proposta Documentos" ;
      }

      protected void WB5Y0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wpnovapropostadocumentos");
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
               context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 HasGridEmpowerer", "start", "top", "", "", "div");
            /*  Grid Control  */
            GriddocumentosContainer.SetWrapped(nGXWrapped);
            StartGridControl15( ) ;
         }
         if ( wbEnd == 15 )
         {
            wbEnd = 0;
            nRC_GXsfl_15 = (int)(nGXsfl_15_idx-1);
            if ( GriddocumentosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GriddocumentosContainer.AddObjectProperty("GRIDDOCUMENTOS_nEOF", GRIDDOCUMENTOS_nEOF);
               GriddocumentosContainer.AddObjectProperty("GRIDDOCUMENTOS_nFirstRecordOnPage", GRIDDOCUMENTOS_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"GriddocumentosContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Griddocumentos", GriddocumentosContainer, subGriddocumentos_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GriddocumentosContainerData", GriddocumentosContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GriddocumentosContainerData"+"V", GriddocumentosContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GriddocumentosContainerData"+"V"+"\" value='"+GriddocumentosContainer.GridValuesHidden()+"'/>") ;
               }
            }
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucNovajanela.Render(context, "innewwindow", Novajanela_Internalname, sPrefix+"NOVAJANELAContainer");
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
            /* User Defined Control */
            ucGriddocumentos_empowerer.Render(context, "wwp.gridempowerer", Griddocumentos_empowerer_Internalname, sPrefix+"GRIDDOCUMENTOS_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 15 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GriddocumentosContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  GriddocumentosContainer.AddObjectProperty("GRIDDOCUMENTOS_nEOF", GRIDDOCUMENTOS_nEOF);
                  GriddocumentosContainer.AddObjectProperty("GRIDDOCUMENTOS_nFirstRecordOnPage", GRIDDOCUMENTOS_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"GriddocumentosContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Griddocumentos", GriddocumentosContainer, subGriddocumentos_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GriddocumentosContainerData", GriddocumentosContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GriddocumentosContainerData"+"V", GriddocumentosContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GriddocumentosContainerData"+"V"+"\" value='"+GriddocumentosContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START5Y2( )
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
            Form.Meta.addItem("description", "Wp Nova Proposta Documentos", 0) ;
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
               STRUP5Y0( ) ;
            }
         }
      }

      protected void WS5Y2( )
      {
         START5Y2( ) ;
         EVT5Y2( ) ;
      }

      protected void EVT5Y2( )
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
                                 STRUP5Y0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5Y0( ) ;
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
                                          E115Y2 ();
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
                                 STRUP5Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'WizardPrevious' */
                                    E125Y2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavAdicionaranexo_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDDOCUMENTOSPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5Y0( ) ;
                              }
                              sEvt = cgiGet( sPrefix+"GRIDDOCUMENTOSPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgriddocumentos_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgriddocumentos_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgriddocumentos_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgriddocumentos_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "GRIDDOCUMENTOS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 21), "VADICIONARANEXO.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 15), "VDOWNLOAD.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 21), "VADICIONARANEXO.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 15), "VDOWNLOAD.CLICK") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5Y0( ) ;
                              }
                              nGXsfl_15_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
                              SubsflControlProps_152( ) ;
                              AV19AdicionarAnexo = cgiGet( edtavAdicionaranexo_Internalname);
                              AssignAttri(sPrefix, false, edtavAdicionaranexo_Internalname, AV19AdicionarAnexo);
                              AV33Download = cgiGet( edtavDownload_Internalname);
                              AssignAttri(sPrefix, false, edtavDownload_Internalname, AV33Download);
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavDocumentosid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavDocumentosid_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vDOCUMENTOSID");
                                 GX_FocusControl = edtavDocumentosid_Internalname;
                                 AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV22DocumentosId = 0;
                                 AssignAttri(sPrefix, false, edtavDocumentosid_Internalname, StringUtil.LTrimStr( (decimal)(AV22DocumentosId), 9, 0));
                                 GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDOCUMENTOSID"+"_"+sGXsfl_15_idx, GetSecureSignedToken( sPrefix+sGXsfl_15_idx, context.localUtil.Format( (decimal)(AV22DocumentosId), "ZZZZZZZZ9"), context));
                              }
                              else
                              {
                                 AV22DocumentosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavDocumentosid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                                 AssignAttri(sPrefix, false, edtavDocumentosid_Internalname, StringUtil.LTrimStr( (decimal)(AV22DocumentosId), 9, 0));
                                 GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDOCUMENTOSID"+"_"+sGXsfl_15_idx, GetSecureSignedToken( sPrefix+sGXsfl_15_idx, context.localUtil.Format( (decimal)(AV22DocumentosId), "ZZZZZZZZ9"), context));
                              }
                              AV23DocumentosDescricao = cgiGet( edtavDocumentosdescricao_Internalname);
                              AssignAttri(sPrefix, false, edtavDocumentosdescricao_Internalname, AV23DocumentosDescricao);
                              GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDOCUMENTOSDESCRICAO"+"_"+sGXsfl_15_idx, GetSecureSignedToken( sPrefix+sGXsfl_15_idx, StringUtil.RTrim( context.localUtil.Format( AV23DocumentosDescricao, "")), context));
                              cmbavDocumentoobrigatorio.Name = cmbavDocumentoobrigatorio_Internalname;
                              cmbavDocumentoobrigatorio.CurrentValue = cgiGet( cmbavDocumentoobrigatorio_Internalname);
                              AV12DocumentoObrigatorio = StringUtil.StrToBool( cgiGet( cmbavDocumentoobrigatorio_Internalname));
                              AssignAttri(sPrefix, false, cmbavDocumentoobrigatorio_Internalname, AV12DocumentoObrigatorio);
                              GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDOCUMENTOOBRIGATORIO"+"_"+sGXsfl_15_idx, GetSecureSignedToken( sPrefix+sGXsfl_15_idx, AV12DocumentoObrigatorio, context));
                              AV24Documento = cgiGet( edtavDocumento_Internalname);
                              AssignProp(sPrefix, false, edtavDocumento_Internalname, "URL", context.PathToRelativeUrl( AV24Documento), !bGXsfl_15_Refreshing);
                              AV35Nome = cgiGet( edtavNome_Internalname);
                              AssignAttri(sPrefix, false, edtavNome_Internalname, AV35Nome);
                              GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vNOME"+"_"+sGXsfl_15_idx, GetSecureSignedToken( sPrefix+sGXsfl_15_idx, StringUtil.RTrim( context.localUtil.Format( AV35Nome, "")), context));
                              AV25Extensao = cgiGet( edtavExtensao_Internalname);
                              AssignAttri(sPrefix, false, edtavExtensao_Internalname, AV25Extensao);
                              AV36NomeArquivo = cgiGet( edtavNomearquivo_Internalname);
                              AssignAttri(sPrefix, false, edtavNomearquivo_Internalname, AV36NomeArquivo);
                              GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vNOMEARQUIVO"+"_"+sGXsfl_15_idx, GetSecureSignedToken( sPrefix+sGXsfl_15_idx, StringUtil.RTrim( context.localUtil.Format( AV36NomeArquivo, "")), context));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavAdicionaranexo_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E135Y2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavAdicionaranexo_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E145Y2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDDOCUMENTOS.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavAdicionaranexo_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Griddocumentos.Load */
                                          E155Y2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VADICIONARANEXO.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavAdicionaranexo_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E165Y2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VDOWNLOAD.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavAdicionaranexo_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E175Y2 ();
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP5Y0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavAdicionaranexo_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                       }
                                    }
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE5Y2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm5Y2( ) ;
            }
         }
      }

      protected void PA5Y2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpnovapropostadocumentos")), "wpnovapropostadocumentos") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpnovapropostadocumentos")))) ;
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
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGriddocumentos_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_152( ) ;
         while ( nGXsfl_15_idx <= nRC_GXsfl_15 )
         {
            sendrow_152( ) ;
            nGXsfl_15_idx = ((subGriddocumentos_Islastpage==1)&&(nGXsfl_15_idx+1>subGriddocumentos_fnc_Recordsperpage( )) ? 1 : nGXsfl_15_idx+1);
            sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
            SubsflControlProps_152( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GriddocumentosContainer)) ;
         /* End function gxnrGriddocumentos_newrow */
      }

      protected void gxgrGriddocumentos_refresh( int subGriddocumentos_Rows ,
                                                 GXBaseCollection<SdtSdPropostaDocumento> AV27Array_SdPropostaDocumento ,
                                                 string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDDOCUMENTOS_nCurrentRecord = 0;
         RF5Y2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGriddocumentos_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDOCUMENTOOBRIGATORIO", GetSecureSignedToken( sPrefix, AV12DocumentoObrigatorio, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDOCUMENTOOBRIGATORIO", StringUtil.BoolToStr( AV12DocumentoObrigatorio));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDOCUMENTOSDESCRICAO", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV23DocumentosDescricao, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDOCUMENTOSDESCRICAO", AV23DocumentosDescricao);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDOCUMENTOSID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV22DocumentosId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDOCUMENTOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22DocumentosId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vNOME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV35Nome, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vNOME", AV35Nome);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vNOMEARQUIVO", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV36NomeArquivo, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vNOMEARQUIVO", AV36NomeArquivo);
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
         RF5Y2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavAdicionaranexo_Enabled = 0;
         edtavDownload_Enabled = 0;
         edtavDocumentosid_Enabled = 0;
         edtavDocumentosdescricao_Enabled = 0;
         cmbavDocumentoobrigatorio.Enabled = 0;
         edtavDocumento_Enabled = 0;
         edtavNome_Enabled = 0;
         edtavExtensao_Enabled = 0;
         edtavNomearquivo_Enabled = 0;
      }

      protected void RF5Y2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GriddocumentosContainer.ClearRows();
         }
         wbStart = 15;
         /* Execute user event: Refresh */
         E145Y2 ();
         nGXsfl_15_idx = 1;
         sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
         SubsflControlProps_152( ) ;
         bGXsfl_15_Refreshing = true;
         GriddocumentosContainer.AddObjectProperty("GridName", "Griddocumentos");
         GriddocumentosContainer.AddObjectProperty("CmpContext", sPrefix);
         GriddocumentosContainer.AddObjectProperty("InMasterPage", "false");
         GriddocumentosContainer.AddObjectProperty("Class", "GridWithBorderColor WorkWith");
         GriddocumentosContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GriddocumentosContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GriddocumentosContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddocumentos_Backcolorstyle), 1, 0, ".", "")));
         GriddocumentosContainer.PageSize = subGriddocumentos_fnc_Recordsperpage( );
         if ( subGriddocumentos_Islastpage != 0 )
         {
            GRIDDOCUMENTOS_nFirstRecordOnPage = (long)(subGriddocumentos_fnc_Recordcount( )-subGriddocumentos_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRIDDOCUMENTOS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDDOCUMENTOS_nFirstRecordOnPage), 15, 0, ".", "")));
            GriddocumentosContainer.AddObjectProperty("GRIDDOCUMENTOS_nFirstRecordOnPage", GRIDDOCUMENTOS_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_152( ) ;
            /* Execute user event: Griddocumentos.Load */
            E155Y2 ();
            if ( ( subGriddocumentos_Islastpage == 0 ) && ( GRIDDOCUMENTOS_nCurrentRecord > 0 ) && ( GRIDDOCUMENTOS_nGridOutOfScope == 0 ) && ( nGXsfl_15_idx == 1 ) )
            {
               GRIDDOCUMENTOS_nCurrentRecord = 0;
               GRIDDOCUMENTOS_nGridOutOfScope = 1;
               subgriddocumentos_firstpage( ) ;
               /* Execute user event: Griddocumentos.Load */
               E155Y2 ();
            }
            wbEnd = 15;
            WB5Y0( ) ;
         }
         bGXsfl_15_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes5Y2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDOCUMENTOOBRIGATORIO"+"_"+sGXsfl_15_idx, GetSecureSignedToken( sPrefix+sGXsfl_15_idx, AV12DocumentoObrigatorio, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDOCUMENTOSDESCRICAO"+"_"+sGXsfl_15_idx, GetSecureSignedToken( sPrefix+sGXsfl_15_idx, StringUtil.RTrim( context.localUtil.Format( AV23DocumentosDescricao, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDOCUMENTOSID"+"_"+sGXsfl_15_idx, GetSecureSignedToken( sPrefix+sGXsfl_15_idx, context.localUtil.Format( (decimal)(AV22DocumentosId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vNOME"+"_"+sGXsfl_15_idx, GetSecureSignedToken( sPrefix+sGXsfl_15_idx, StringUtil.RTrim( context.localUtil.Format( AV35Nome, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vNOMEARQUIVO"+"_"+sGXsfl_15_idx, GetSecureSignedToken( sPrefix+sGXsfl_15_idx, StringUtil.RTrim( context.localUtil.Format( AV36NomeArquivo, "")), context));
      }

      protected int subGriddocumentos_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGriddocumentos_fnc_Recordcount( )
      {
         return (int)(((subGriddocumentos_Recordcount==0) ? GRIDDOCUMENTOS_nFirstRecordOnPage+1 : subGriddocumentos_Recordcount)) ;
      }

      protected int subGriddocumentos_fnc_Recordsperpage( )
      {
         if ( subGriddocumentos_Rows > 0 )
         {
            return subGriddocumentos_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGriddocumentos_fnc_Currentpage( )
      {
         return (int)(((subGriddocumentos_Islastpage==1) ? NumberUtil.Int( (long)(Math.Round(subGriddocumentos_fnc_Recordcount( )/ (decimal)(subGriddocumentos_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+((((int)((subGriddocumentos_fnc_Recordcount( )) % (subGriddocumentos_fnc_Recordsperpage( ))))==0) ? 0 : 1) : NumberUtil.Int( (long)(Math.Round(GRIDDOCUMENTOS_nFirstRecordOnPage/ (decimal)(subGriddocumentos_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1)) ;
      }

      protected short subgriddocumentos_firstpage( )
      {
         GRIDDOCUMENTOS_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDDOCUMENTOS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDDOCUMENTOS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGriddocumentos_refresh( subGriddocumentos_Rows, AV27Array_SdPropostaDocumento, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgriddocumentos_nextpage( )
      {
         if ( GRIDDOCUMENTOS_nEOF == 0 )
         {
            GRIDDOCUMENTOS_nFirstRecordOnPage = (long)(GRIDDOCUMENTOS_nFirstRecordOnPage+subGriddocumentos_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDDOCUMENTOS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDDOCUMENTOS_nFirstRecordOnPage), 15, 0, ".", "")));
         GriddocumentosContainer.AddObjectProperty("GRIDDOCUMENTOS_nFirstRecordOnPage", GRIDDOCUMENTOS_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGriddocumentos_refresh( subGriddocumentos_Rows, AV27Array_SdPropostaDocumento, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRIDDOCUMENTOS_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgriddocumentos_previouspage( )
      {
         if ( GRIDDOCUMENTOS_nFirstRecordOnPage >= subGriddocumentos_fnc_Recordsperpage( ) )
         {
            GRIDDOCUMENTOS_nFirstRecordOnPage = (long)(GRIDDOCUMENTOS_nFirstRecordOnPage-subGriddocumentos_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDDOCUMENTOS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDDOCUMENTOS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGriddocumentos_refresh( subGriddocumentos_Rows, AV27Array_SdPropostaDocumento, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgriddocumentos_lastpage( )
      {
         subGriddocumentos_Islastpage = 1;
         if ( isFullAjaxMode( ) )
         {
            gxgrGriddocumentos_refresh( subGriddocumentos_Rows, AV27Array_SdPropostaDocumento, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgriddocumentos_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRIDDOCUMENTOS_nFirstRecordOnPage = (long)(subGriddocumentos_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRIDDOCUMENTOS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDDOCUMENTOS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDDOCUMENTOS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGriddocumentos_refresh( subGriddocumentos_Rows, AV27Array_SdPropostaDocumento, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtavAdicionaranexo_Enabled = 0;
         edtavDownload_Enabled = 0;
         edtavDocumentosid_Enabled = 0;
         edtavDocumentosdescricao_Enabled = 0;
         cmbavDocumentoobrigatorio.Enabled = 0;
         edtavDocumento_Enabled = 0;
         edtavNome_Enabled = 0;
         edtavExtensao_Enabled = 0;
         edtavNomearquivo_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5Y0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E135Y2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vSDPROPOSTADOCUMENTO"), AV28SdPropostaDocumento);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vARRAY_SDPROPOSTADOCUMENTO"), AV27Array_SdPropostaDocumento);
            /* Read saved values. */
            nRC_GXsfl_15 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_15"), ",", "."), 18, MidpointRounding.ToEven));
            wcpOAV6WebSessionKey = cgiGet( sPrefix+"wcpOAV6WebSessionKey");
            wcpOAV8PreviousStep = cgiGet( sPrefix+"wcpOAV8PreviousStep");
            wcpOAV7GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV7GoingBack"));
            AV30InNome = cgiGet( sPrefix+"vINNOME");
            AV31InExtensao = cgiGet( sPrefix+"vINEXTENSAO");
            AV29Blob = cgiGet( sPrefix+"vBLOB");
            AV32InDocumentosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vINDOCUMENTOSID"), ",", "."), 18, MidpointRounding.ToEven));
            AV40GXV2 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGXV2"), ",", "."), 18, MidpointRounding.ToEven));
            GRIDDOCUMENTOS_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDDOCUMENTOS_nFirstRecordOnPage"), ",", "."), 18, MidpointRounding.ToEven));
            GRIDDOCUMENTOS_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDDOCUMENTOS_nEOF"), ",", "."), 18, MidpointRounding.ToEven));
            subGriddocumentos_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"subGriddocumentos_Recordcount"), ",", "."), 18, MidpointRounding.ToEven));
            subGriddocumentos_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDDOCUMENTOS_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRIDDOCUMENTOS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddocumentos_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E135Y2 ();
         if (returnInSub) return;
      }

      protected void E135Y2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADVARIABLESFROMWIZARDDATA' */
         S112 ();
         if (returnInSub) return;
         Griddocumentos_empowerer_Gridinternalname = subGriddocumentos_Internalname;
         ucGriddocumentos_empowerer.SendProperty(context, sPrefix, false, Griddocumentos_empowerer_Internalname, "GridInternalName", Griddocumentos_empowerer_Gridinternalname);
         subGriddocumentos_Rows = 10;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDDOCUMENTOS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddocumentos_Rows), 6, 0, ".", "")));
         /* Execute user subroutine: 'CARREGASDT' */
         S122 ();
         if (returnInSub) return;
      }

      protected void E145Y2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         cmbavDocumentoobrigatorio_Columnheaderclass = "WWColumn";
         AssignProp(sPrefix, false, cmbavDocumentoobrigatorio_Internalname, "Columnheaderclass", cmbavDocumentoobrigatorio_Columnheaderclass, !bGXsfl_15_Refreshing);
         /*  Sending Event outputs  */
      }

      private void E155Y2( )
      {
         /* Griddocumentos_Load Routine */
         returnInSub = false;
         AV37GXV1 = 1;
         while ( AV37GXV1 <= AV27Array_SdPropostaDocumento.Count )
         {
            AV28SdPropostaDocumento = ((SdtSdPropostaDocumento)AV27Array_SdPropostaDocumento.Item(AV37GXV1));
            AV22DocumentosId = AV28SdPropostaDocumento.gxTpr_Documentosid;
            AssignAttri(sPrefix, false, edtavDocumentosid_Internalname, StringUtil.LTrimStr( (decimal)(AV22DocumentosId), 9, 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDOCUMENTOSID"+"_"+sGXsfl_15_idx, GetSecureSignedToken( sPrefix+sGXsfl_15_idx, context.localUtil.Format( (decimal)(AV22DocumentosId), "ZZZZZZZZ9"), context));
            AV12DocumentoObrigatorio = AV28SdPropostaDocumento.gxTpr_Documentoobrigatorio;
            AssignAttri(sPrefix, false, cmbavDocumentoobrigatorio_Internalname, AV12DocumentoObrigatorio);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDOCUMENTOOBRIGATORIO"+"_"+sGXsfl_15_idx, GetSecureSignedToken( sPrefix+sGXsfl_15_idx, AV12DocumentoObrigatorio, context));
            AV23DocumentosDescricao = AV28SdPropostaDocumento.gxTpr_Documentosdescricao;
            AssignAttri(sPrefix, false, edtavDocumentosdescricao_Internalname, AV23DocumentosDescricao);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDOCUMENTOSDESCRICAO"+"_"+sGXsfl_15_idx, GetSecureSignedToken( sPrefix+sGXsfl_15_idx, StringUtil.RTrim( context.localUtil.Format( AV23DocumentosDescricao, "")), context));
            AV25Extensao = AV28SdPropostaDocumento.gxTpr_Extensao;
            AssignAttri(sPrefix, false, edtavExtensao_Internalname, AV25Extensao);
            AV35Nome = AV28SdPropostaDocumento.gxTpr_Nome;
            AssignAttri(sPrefix, false, edtavNome_Internalname, AV35Nome);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vNOME"+"_"+sGXsfl_15_idx, GetSecureSignedToken( sPrefix+sGXsfl_15_idx, StringUtil.RTrim( context.localUtil.Format( AV35Nome, "")), context));
            AV24Documento = AV28SdPropostaDocumento.gxTpr_Documento;
            AssignAttri(sPrefix, false, edtavDocumento_Internalname, AV24Documento);
            AV36NomeArquivo = StringUtil.Format( "%1.%2", AV35Nome, AV25Extensao, "", "", "", "", "", "", "");
            AssignAttri(sPrefix, false, edtavNomearquivo_Internalname, AV36NomeArquivo);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vNOMEARQUIVO"+"_"+sGXsfl_15_idx, GetSecureSignedToken( sPrefix+sGXsfl_15_idx, StringUtil.RTrim( context.localUtil.Format( AV36NomeArquivo, "")), context));
            AV19AdicionarAnexo = "<i class=\"fas fa-plus\"></i>";
            AssignAttri(sPrefix, false, edtavAdicionaranexo_Internalname, AV19AdicionarAnexo);
            AV33Download = "<i class=\"fas fa-download\"></i>";
            AssignAttri(sPrefix, false, edtavDownload_Internalname, AV33Download);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24Documento)) )
            {
               edtavDownload_Class = "Attribute";
            }
            else
            {
               edtavDownload_Class = "Invisible";
            }
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( AV12DocumentoObrigatorio)), "true") == 0 )
            {
               cmbavDocumentoobrigatorio_Columnclass = "WWColumn WWColumnTag WWColumnTagSuccess WWColumnTagSuccessSingleCell";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( AV12DocumentoObrigatorio)), "false") == 0 )
            {
               cmbavDocumentoobrigatorio_Columnclass = "WWColumn WWColumnTag WWColumnTagDanger WWColumnTagDangerSingleCell";
            }
            else
            {
               cmbavDocumentoobrigatorio_Columnclass = "WWColumn";
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 15;
            }
            if ( ( subGriddocumentos_Islastpage == 1 ) || ( subGriddocumentos_Rows == 0 ) || ( ( GRIDDOCUMENTOS_nCurrentRecord >= GRIDDOCUMENTOS_nFirstRecordOnPage ) && ( GRIDDOCUMENTOS_nCurrentRecord < GRIDDOCUMENTOS_nFirstRecordOnPage + subGriddocumentos_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_152( ) ;
            }
            GRIDDOCUMENTOS_nEOF = (short)(((GRIDDOCUMENTOS_nCurrentRecord<GRIDDOCUMENTOS_nFirstRecordOnPage+subGriddocumentos_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRIDDOCUMENTOS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDDOCUMENTOS_nEOF), 1, 0, ".", "")));
            GRIDDOCUMENTOS_nCurrentRecord = (long)(GRIDDOCUMENTOS_nCurrentRecord+1);
            subGriddocumentos_Recordcount = (int)(GRIDDOCUMENTOS_nCurrentRecord);
            if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
            {
               DoAjaxLoad(15, GriddocumentosRow);
            }
            AV37GXV1 = (int)(AV37GXV1+1);
         }
         /*  Sending Event outputs  */
         cmbavDocumentoobrigatorio.CurrentValue = StringUtil.BoolToStr( AV12DocumentoObrigatorio);
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E115Y2 ();
         if (returnInSub) return;
      }

      protected void E115Y2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV10HasValidationErrors = false;
         /* Start For Each Line in Griddocumentos */
         nRC_GXsfl_15 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_15"), ",", "."), 18, MidpointRounding.ToEven));
         nGXsfl_15_fel_idx = 0;
         while ( nGXsfl_15_fel_idx < nRC_GXsfl_15 )
         {
            nGXsfl_15_fel_idx = ((subGriddocumentos_Islastpage==1)&&(nGXsfl_15_fel_idx+1>subGriddocumentos_fnc_Recordsperpage( )) ? 1 : nGXsfl_15_fel_idx+1);
            sGXsfl_15_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_fel_idx), 4, 0), 4, "0");
            SubsflControlProps_fel_152( ) ;
            AV19AdicionarAnexo = cgiGet( edtavAdicionaranexo_Internalname);
            AV33Download = cgiGet( edtavDownload_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavDocumentosid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavDocumentosid_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vDOCUMENTOSID");
               GX_FocusControl = edtavDocumentosid_Internalname;
               wbErr = true;
               AV22DocumentosId = 0;
            }
            else
            {
               AV22DocumentosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavDocumentosid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            }
            AV23DocumentosDescricao = cgiGet( edtavDocumentosdescricao_Internalname);
            cmbavDocumentoobrigatorio.Name = cmbavDocumentoobrigatorio_Internalname;
            cmbavDocumentoobrigatorio.CurrentValue = cgiGet( cmbavDocumentoobrigatorio_Internalname);
            AV12DocumentoObrigatorio = StringUtil.StrToBool( cgiGet( cmbavDocumentoobrigatorio_Internalname));
            AV24Documento = cgiGet( edtavDocumento_Internalname);
            AV35Nome = cgiGet( edtavNome_Internalname);
            AV25Extensao = cgiGet( edtavExtensao_Internalname);
            AV36NomeArquivo = cgiGet( edtavNomearquivo_Internalname);
            if ( AV12DocumentoObrigatorio && String.IsNullOrEmpty(StringUtil.RTrim( AV24Documento)) )
            {
               AV10HasValidationErrors = true;
               GXt_char1 = StringUtil.Format( "%1 é obrigatório, coloque o documento!", AV23DocumentosDescricao, "", "", "", "", "", "", "", "");
               new message(context ).gxep_erro( ref  GXt_char1) ;
            }
            /* End For Each Line */
         }
         if ( nGXsfl_15_fel_idx == 0 )
         {
            nGXsfl_15_idx = 1;
            sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
            SubsflControlProps_152( ) ;
         }
         nGXsfl_15_fel_idx = 1;
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
            GXEncryptionTmp = "wpnovaproposta"+UrlEncode(StringUtil.RTrim("Documentos")) + "," + UrlEncode(StringUtil.RTrim("Resumo")) + "," + UrlEncode(StringUtil.BoolToStr(false));
            CallWebObject(formatLink("wpnovaproposta") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         /*  Sending Event outputs  */
      }

      protected void E125Y2( )
      {
         /* 'WizardPrevious' Routine */
         returnInSub = false;
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
         GXEncryptionTmp = "wpnovaproposta"+UrlEncode(StringUtil.RTrim("Documentos")) + "," + UrlEncode(StringUtil.RTrim("Proposta")) + "," + UrlEncode(StringUtil.BoolToStr(true));
         CallWebObject(formatLink("wpnovaproposta") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
         /*  Sending Event outputs  */
      }

      protected void E165Y2( )
      {
         /* Adicionaranexo_Click Routine */
         returnInSub = false;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "popupnovodocumento"+UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.LTrimStr(AV22DocumentosId,9,0));
         context.PopUp(formatLink("popupnovodocumento") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {"AV24Documento","AV25Extensao",});
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'LOADVARIABLESFROMWIZARDDATA' Routine */
         returnInSub = false;
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
      }

      protected void S132( )
      {
         /* 'SAVEVARIABLESTOWIZARDDATA' Routine */
         returnInSub = false;
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
         AV11WizardData.gxTpr_Documentos.gxTpr_Griddocumentos.Clear();
         /* Start For Each Line in Griddocumentos */
         nRC_GXsfl_15 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_15"), ",", "."), 18, MidpointRounding.ToEven));
         nGXsfl_15_fel_idx = 0;
         while ( nGXsfl_15_fel_idx < nRC_GXsfl_15 )
         {
            nGXsfl_15_fel_idx = ((subGriddocumentos_Islastpage==1)&&(nGXsfl_15_fel_idx+1>subGriddocumentos_fnc_Recordsperpage( )) ? 1 : nGXsfl_15_fel_idx+1);
            sGXsfl_15_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_fel_idx), 4, 0), 4, "0");
            SubsflControlProps_fel_152( ) ;
            AV19AdicionarAnexo = cgiGet( edtavAdicionaranexo_Internalname);
            AV33Download = cgiGet( edtavDownload_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavDocumentosid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavDocumentosid_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vDOCUMENTOSID");
               GX_FocusControl = edtavDocumentosid_Internalname;
               wbErr = true;
               AV22DocumentosId = 0;
            }
            else
            {
               AV22DocumentosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavDocumentosid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            }
            AV23DocumentosDescricao = cgiGet( edtavDocumentosdescricao_Internalname);
            cmbavDocumentoobrigatorio.Name = cmbavDocumentoobrigatorio_Internalname;
            cmbavDocumentoobrigatorio.CurrentValue = cgiGet( cmbavDocumentoobrigatorio_Internalname);
            AV12DocumentoObrigatorio = StringUtil.StrToBool( cgiGet( cmbavDocumentoobrigatorio_Internalname));
            AV24Documento = cgiGet( edtavDocumento_Internalname);
            AV35Nome = cgiGet( edtavNome_Internalname);
            AV25Extensao = cgiGet( edtavExtensao_Internalname);
            AV36NomeArquivo = cgiGet( edtavNomearquivo_Internalname);
            AV13GridDocumentosItem = new SdtWpNovaPropostaData_Documentos_GridDocumentosItem(context);
            AV13GridDocumentosItem.gxTpr_Documentosid = AV22DocumentosId;
            AV13GridDocumentosItem.gxTpr_Documentosdescricao = AV23DocumentosDescricao;
            AV13GridDocumentosItem.gxTpr_Documentoobrigatorio = AV12DocumentoObrigatorio;
            AV13GridDocumentosItem.gxTpr_Documento = AV24Documento;
            AV13GridDocumentosItem.gxTpr_Nome = AV35Nome;
            AV13GridDocumentosItem.gxTpr_Extensao = AV25Extensao;
            AV13GridDocumentosItem.gxTpr_Nomearquivo = AV36NomeArquivo;
            AV11WizardData.gxTpr_Documentos.gxTpr_Griddocumentos.Add(AV13GridDocumentosItem, 0);
            /* End For Each Line */
         }
         if ( nGXsfl_15_fel_idx == 0 )
         {
            nGXsfl_15_idx = 1;
            sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
            SubsflControlProps_152( ) ;
         }
         nGXsfl_15_fel_idx = 1;
         AV5WebSession.Set(AV6WebSessionKey, AV11WizardData.ToJSonString(false, true));
      }

      protected void E175Y2( )
      {
         /* Download_Click Routine */
         returnInSub = false;
         AV41GXV3 = 1;
         while ( AV41GXV3 <= AV27Array_SdPropostaDocumento.Count )
         {
            AV28SdPropostaDocumento = ((SdtSdPropostaDocumento)AV27Array_SdPropostaDocumento.Item(AV41GXV3));
            if ( AV28SdPropostaDocumento.gxTpr_Documentosid == AV22DocumentosId )
            {
               new prdownloadblob(context ).execute(  AV28SdPropostaDocumento.gxTpr_Documento,  AV28SdPropostaDocumento.gxTpr_Nome,  AV28SdPropostaDocumento.gxTpr_Extensao, out  AV34Arquivo) ;
               Novajanela_Target = AV34Arquivo;
               ucNovajanela.SendProperty(context, sPrefix, false, Novajanela_Internalname, "Target", Novajanela_Target);
               this.executeUsercontrolMethod(sPrefix, false, "NOVAJANELAContainer", "OpenWindow", "", new Object[] {});
               if (true) break;
            }
            AV41GXV3 = (int)(AV41GXV3+1);
         }
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'CARREGASDT' Routine */
         returnInSub = false;
         AV27Array_SdPropostaDocumento = new GXBaseCollection<SdtSdPropostaDocumento>( context, "SdPropostaDocumento", "Factory21");
         /* Using cursor H005Y2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A413DocumentoObrigatorio = H005Y2_A413DocumentoObrigatorio[0];
            n413DocumentoObrigatorio = H005Y2_n413DocumentoObrigatorio[0];
            A405DocumentosId = H005Y2_A405DocumentosId[0];
            A406DocumentosDescricao = H005Y2_A406DocumentosDescricao[0];
            n406DocumentosDescricao = H005Y2_n406DocumentosDescricao[0];
            AV28SdPropostaDocumento = new SdtSdPropostaDocumento(context);
            AV28SdPropostaDocumento.gxTpr_Documentosid = A405DocumentosId;
            AV28SdPropostaDocumento.gxTpr_Documentoobrigatorio = A413DocumentoObrigatorio;
            AV28SdPropostaDocumento.gxTpr_Documentosdescricao = A406DocumentosDescricao;
            AV27Array_SdPropostaDocumento.Add(AV28SdPropostaDocumento, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         PA5Y2( ) ;
         WS5Y2( ) ;
         WE5Y2( ) ;
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
         PA5Y2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wpnovapropostadocumentos", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA5Y2( ) ;
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
         PA5Y2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS5Y2( ) ;
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
         WS5Y2( ) ;
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
         WE5Y2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101964960", true, true);
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
         context.AddJavascriptSource("wpnovapropostadocumentos.js", "?20256101964961", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_152( )
      {
         edtavAdicionaranexo_Internalname = sPrefix+"vADICIONARANEXO_"+sGXsfl_15_idx;
         edtavDownload_Internalname = sPrefix+"vDOWNLOAD_"+sGXsfl_15_idx;
         edtavDocumentosid_Internalname = sPrefix+"vDOCUMENTOSID_"+sGXsfl_15_idx;
         edtavDocumentosdescricao_Internalname = sPrefix+"vDOCUMENTOSDESCRICAO_"+sGXsfl_15_idx;
         cmbavDocumentoobrigatorio_Internalname = sPrefix+"vDOCUMENTOOBRIGATORIO_"+sGXsfl_15_idx;
         edtavDocumento_Internalname = sPrefix+"vDOCUMENTO_"+sGXsfl_15_idx;
         edtavNome_Internalname = sPrefix+"vNOME_"+sGXsfl_15_idx;
         edtavExtensao_Internalname = sPrefix+"vEXTENSAO_"+sGXsfl_15_idx;
         edtavNomearquivo_Internalname = sPrefix+"vNOMEARQUIVO_"+sGXsfl_15_idx;
      }

      protected void SubsflControlProps_fel_152( )
      {
         edtavAdicionaranexo_Internalname = sPrefix+"vADICIONARANEXO_"+sGXsfl_15_fel_idx;
         edtavDownload_Internalname = sPrefix+"vDOWNLOAD_"+sGXsfl_15_fel_idx;
         edtavDocumentosid_Internalname = sPrefix+"vDOCUMENTOSID_"+sGXsfl_15_fel_idx;
         edtavDocumentosdescricao_Internalname = sPrefix+"vDOCUMENTOSDESCRICAO_"+sGXsfl_15_fel_idx;
         cmbavDocumentoobrigatorio_Internalname = sPrefix+"vDOCUMENTOOBRIGATORIO_"+sGXsfl_15_fel_idx;
         edtavDocumento_Internalname = sPrefix+"vDOCUMENTO_"+sGXsfl_15_fel_idx;
         edtavNome_Internalname = sPrefix+"vNOME_"+sGXsfl_15_fel_idx;
         edtavExtensao_Internalname = sPrefix+"vEXTENSAO_"+sGXsfl_15_fel_idx;
         edtavNomearquivo_Internalname = sPrefix+"vNOMEARQUIVO_"+sGXsfl_15_fel_idx;
      }

      protected void sendrow_152( )
      {
         sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
         SubsflControlProps_152( ) ;
         WB5Y0( ) ;
         if ( ( subGriddocumentos_Rows * 1 == 0 ) || ( nGXsfl_15_idx <= subGriddocumentos_fnc_Recordsperpage( ) * 1 ) )
         {
            GriddocumentosRow = GXWebRow.GetNew(context,GriddocumentosContainer);
            if ( subGriddocumentos_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGriddocumentos_Backstyle = 0;
               if ( StringUtil.StrCmp(subGriddocumentos_Class, "") != 0 )
               {
                  subGriddocumentos_Linesclass = subGriddocumentos_Class+"Odd";
               }
            }
            else if ( subGriddocumentos_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGriddocumentos_Backstyle = 0;
               subGriddocumentos_Backcolor = subGriddocumentos_Allbackcolor;
               if ( StringUtil.StrCmp(subGriddocumentos_Class, "") != 0 )
               {
                  subGriddocumentos_Linesclass = subGriddocumentos_Class+"Uniform";
               }
            }
            else if ( subGriddocumentos_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGriddocumentos_Backstyle = 1;
               if ( StringUtil.StrCmp(subGriddocumentos_Class, "") != 0 )
               {
                  subGriddocumentos_Linesclass = subGriddocumentos_Class+"Odd";
               }
               subGriddocumentos_Backcolor = (int)(0x0);
            }
            else if ( subGriddocumentos_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGriddocumentos_Backstyle = 1;
               if ( ((int)((nGXsfl_15_idx) % (2))) == 0 )
               {
                  subGriddocumentos_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGriddocumentos_Class, "") != 0 )
                  {
                     subGriddocumentos_Linesclass = subGriddocumentos_Class+"Even";
                  }
               }
               else
               {
                  subGriddocumentos_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGriddocumentos_Class, "") != 0 )
                  {
                     subGriddocumentos_Linesclass = subGriddocumentos_Class+"Odd";
                  }
               }
            }
            if ( GriddocumentosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"GridWithBorderColor WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_15_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GriddocumentosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'" + sPrefix + "',false,'" + sGXsfl_15_idx + "',15)\"";
            ROClassString = "Attribute";
            GriddocumentosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavAdicionaranexo_Internalname,StringUtil.RTrim( AV19AdicionarAnexo),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,16);\"","'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVADICIONARANEXO.CLICK."+sGXsfl_15_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavAdicionaranexo_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavAdicionaranexo_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)15,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GriddocumentosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'" + sPrefix + "',false,'" + sGXsfl_15_idx + "',15)\"";
            ROClassString = edtavDownload_Class;
            GriddocumentosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDownload_Internalname,StringUtil.RTrim( AV33Download),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,17);\"","'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVDOWNLOAD.CLICK."+sGXsfl_15_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDownload_Jsonclick,(short)5,(string)edtavDownload_Class,(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavDownload_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)15,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GriddocumentosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GriddocumentosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDocumentosid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22DocumentosId), 9, 0, ",", "")),StringUtil.LTrim( ((edtavDocumentosid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV22DocumentosId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV22DocumentosId), "ZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+""+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDocumentosid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavDocumentosid_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GriddocumentosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'" + sPrefix + "',false,'" + sGXsfl_15_idx + "',15)\"";
            ROClassString = "Attribute";
            GriddocumentosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDocumentosdescricao_Internalname,(string)AV23DocumentosDescricao,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,19);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDocumentosdescricao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavDocumentosdescricao_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GriddocumentosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'" + sPrefix + "',false,'" + sGXsfl_15_idx + "',15)\"";
            if ( ( cmbavDocumentoobrigatorio.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vDOCUMENTOOBRIGATORIO_" + sGXsfl_15_idx;
               cmbavDocumentoobrigatorio.Name = GXCCtl;
               cmbavDocumentoobrigatorio.WebTags = "";
               cmbavDocumentoobrigatorio.addItem(StringUtil.BoolToStr( true), "Sim", 0);
               cmbavDocumentoobrigatorio.addItem(StringUtil.BoolToStr( false), "Não", 0);
               if ( cmbavDocumentoobrigatorio.ItemCount > 0 )
               {
                  AV12DocumentoObrigatorio = StringUtil.StrToBool( cmbavDocumentoobrigatorio.getValidValue(StringUtil.BoolToStr( AV12DocumentoObrigatorio)));
                  AssignAttri(sPrefix, false, cmbavDocumentoobrigatorio_Internalname, AV12DocumentoObrigatorio);
                  GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDOCUMENTOOBRIGATORIO"+"_"+sGXsfl_15_idx, GetSecureSignedToken( sPrefix+sGXsfl_15_idx, AV12DocumentoObrigatorio, context));
               }
            }
            /* ComboBox */
            GriddocumentosRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavDocumentoobrigatorio,(string)cmbavDocumentoobrigatorio_Internalname,StringUtil.BoolToStr( AV12DocumentoObrigatorio),(short)1,(string)cmbavDocumentoobrigatorio_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"boolean",(string)"",(short)-1,cmbavDocumentoobrigatorio.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)cmbavDocumentoobrigatorio_Columnclass,(string)cmbavDocumentoobrigatorio_Columnheaderclass,TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"",(string)"",(bool)true,(short)0});
            cmbavDocumentoobrigatorio.CurrentValue = StringUtil.BoolToStr( AV12DocumentoObrigatorio);
            AssignProp(sPrefix, false, cmbavDocumentoobrigatorio_Internalname, "Values", (string)(cmbavDocumentoobrigatorio.ToJavascriptSource()), !bGXsfl_15_Refreshing);
            /* Subfile cell */
            if ( GriddocumentosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            ClassString = "Attribute";
            StyleString = "";
            edtavDocumento_Filetype = "tmp";
            AssignProp(sPrefix, false, edtavDocumento_Internalname, "Filetype", edtavDocumento_Filetype, !bGXsfl_15_Refreshing);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24Documento)) )
            {
               gxblobfileaux.Source = AV24Documento;
               if ( ! gxblobfileaux.HasExtension() || ( StringUtil.StrCmp(edtavDocumento_Filetype, "tmp") != 0 ) )
               {
                  gxblobfileaux.SetExtension(StringUtil.Trim( edtavDocumento_Filetype));
               }
               if ( gxblobfileaux.ErrCode == 0 )
               {
                  AV24Documento = gxblobfileaux.GetURI();
                  AssignProp(sPrefix, false, edtavDocumento_Internalname, "URL", context.PathToRelativeUrl( AV24Documento), !bGXsfl_15_Refreshing);
                  edtavDocumento_Filetype = gxblobfileaux.GetExtension();
                  AssignProp(sPrefix, false, edtavDocumento_Internalname, "Filetype", edtavDocumento_Filetype, !bGXsfl_15_Refreshing);
               }
               AssignProp(sPrefix, false, edtavDocumento_Internalname, "URL", context.PathToRelativeUrl( AV24Documento), !bGXsfl_15_Refreshing);
            }
            GriddocumentosRow.AddColumnProperties("blob", 2, isAjaxCallMode( ), new Object[] {(string)edtavDocumento_Internalname,StringUtil.RTrim( AV24Documento),context.PathToRelativeUrl( AV24Documento),(String.IsNullOrEmpty(StringUtil.RTrim( edtavDocumento_Contenttype)) ? context.GetContentType( (String.IsNullOrEmpty(StringUtil.RTrim( edtavDocumento_Filetype)) ? AV24Documento : edtavDocumento_Filetype)) : edtavDocumento_Contenttype),(bool)false,(string)"",(string)edtavDocumento_Parameters,(short)0,(int)edtavDocumento_Enabled,(short)0,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)60,(string)"px",(short)0,(short)0,(short)0,(string)edtavDocumento_Jsonclick,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",""+""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"",(string)""});
            /* Subfile cell */
            if ( GriddocumentosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GriddocumentosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavNome_Internalname,(string)AV35Nome,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavNome_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GriddocumentosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GriddocumentosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavExtensao_Internalname,(string)AV25Extensao,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavExtensao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavExtensao_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GriddocumentosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'" + sGXsfl_15_idx + "',15)\"";
            ROClassString = "Attribute";
            GriddocumentosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavNomearquivo_Internalname,(string)AV36NomeArquivo,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavNomearquivo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavNomearquivo_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes5Y2( ) ;
            GriddocumentosContainer.AddRow(GriddocumentosRow);
            nGXsfl_15_idx = ((subGriddocumentos_Islastpage==1)&&(nGXsfl_15_idx+1>subGriddocumentos_fnc_Recordsperpage( )) ? 1 : nGXsfl_15_idx+1);
            sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
            SubsflControlProps_152( ) ;
         }
         /* End function sendrow_152 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "vDOCUMENTOOBRIGATORIO_" + sGXsfl_15_idx;
         cmbavDocumentoobrigatorio.Name = GXCCtl;
         cmbavDocumentoobrigatorio.WebTags = "";
         cmbavDocumentoobrigatorio.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbavDocumentoobrigatorio.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbavDocumentoobrigatorio.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl15( )
      {
         if ( GriddocumentosContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GriddocumentosContainer"+"DivS\" data-gxgridid=\"15\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGriddocumentos_Internalname, subGriddocumentos_Internalname, "", "GridWithBorderColor WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGriddocumentos_Backcolorstyle == 0 )
            {
               subGriddocumentos_Titlebackstyle = 0;
               if ( StringUtil.Len( subGriddocumentos_Class) > 0 )
               {
                  subGriddocumentos_Linesclass = subGriddocumentos_Class+"Title";
               }
            }
            else
            {
               subGriddocumentos_Titlebackstyle = 1;
               if ( subGriddocumentos_Backcolorstyle == 1 )
               {
                  subGriddocumentos_Titlebackcolor = subGriddocumentos_Allbackcolor;
                  if ( StringUtil.Len( subGriddocumentos_Class) > 0 )
                  {
                     subGriddocumentos_Linesclass = subGriddocumentos_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGriddocumentos_Class) > 0 )
                  {
                     subGriddocumentos_Linesclass = subGriddocumentos_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+edtavDownload_Class+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Documentos Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Descrição") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Obrigatório") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Nome") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GriddocumentosContainer.AddObjectProperty("GridName", "Griddocumentos");
         }
         else
         {
            GriddocumentosContainer.AddObjectProperty("GridName", "Griddocumentos");
            GriddocumentosContainer.AddObjectProperty("Header", subGriddocumentos_Header);
            GriddocumentosContainer.AddObjectProperty("Class", "GridWithBorderColor WorkWith");
            GriddocumentosContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GriddocumentosContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GriddocumentosContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddocumentos_Backcolorstyle), 1, 0, ".", "")));
            GriddocumentosContainer.AddObjectProperty("CmpContext", sPrefix);
            GriddocumentosContainer.AddObjectProperty("InMasterPage", "false");
            GriddocumentosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GriddocumentosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV19AdicionarAnexo)));
            GriddocumentosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavAdicionaranexo_Enabled), 5, 0, ".", "")));
            GriddocumentosContainer.AddColumnProperties(GriddocumentosColumn);
            GriddocumentosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GriddocumentosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV33Download)));
            GriddocumentosColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavDownload_Class));
            GriddocumentosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDownload_Enabled), 5, 0, ".", "")));
            GriddocumentosContainer.AddColumnProperties(GriddocumentosColumn);
            GriddocumentosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GriddocumentosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22DocumentosId), 9, 0, ".", ""))));
            GriddocumentosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDocumentosid_Enabled), 5, 0, ".", "")));
            GriddocumentosContainer.AddColumnProperties(GriddocumentosColumn);
            GriddocumentosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GriddocumentosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV23DocumentosDescricao));
            GriddocumentosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDocumentosdescricao_Enabled), 5, 0, ".", "")));
            GriddocumentosContainer.AddColumnProperties(GriddocumentosColumn);
            GriddocumentosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GriddocumentosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( AV12DocumentoObrigatorio)));
            GriddocumentosColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( cmbavDocumentoobrigatorio_Columnclass));
            GriddocumentosColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( cmbavDocumentoobrigatorio_Columnheaderclass));
            GriddocumentosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavDocumentoobrigatorio.Enabled), 5, 0, ".", "")));
            GriddocumentosContainer.AddColumnProperties(GriddocumentosColumn);
            GriddocumentosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GriddocumentosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV24Documento));
            GriddocumentosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDocumento_Enabled), 5, 0, ".", "")));
            GriddocumentosContainer.AddColumnProperties(GriddocumentosColumn);
            GriddocumentosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GriddocumentosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV35Nome));
            GriddocumentosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavNome_Enabled), 5, 0, ".", "")));
            GriddocumentosContainer.AddColumnProperties(GriddocumentosColumn);
            GriddocumentosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GriddocumentosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV25Extensao));
            GriddocumentosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavExtensao_Enabled), 5, 0, ".", "")));
            GriddocumentosContainer.AddColumnProperties(GriddocumentosColumn);
            GriddocumentosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GriddocumentosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV36NomeArquivo));
            GriddocumentosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavNomearquivo_Enabled), 5, 0, ".", "")));
            GriddocumentosContainer.AddColumnProperties(GriddocumentosColumn);
            GriddocumentosContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddocumentos_Selectedindex), 4, 0, ".", "")));
            GriddocumentosContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddocumentos_Allowselection), 1, 0, ".", "")));
            GriddocumentosContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddocumentos_Selectioncolor), 9, 0, ".", "")));
            GriddocumentosContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddocumentos_Allowhovering), 1, 0, ".", "")));
            GriddocumentosContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddocumentos_Hoveringcolor), 9, 0, ".", "")));
            GriddocumentosContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddocumentos_Allowcollapsing), 1, 0, ".", "")));
            GriddocumentosContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddocumentos_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         edtavAdicionaranexo_Internalname = sPrefix+"vADICIONARANEXO";
         edtavDownload_Internalname = sPrefix+"vDOWNLOAD";
         edtavDocumentosid_Internalname = sPrefix+"vDOCUMENTOSID";
         edtavDocumentosdescricao_Internalname = sPrefix+"vDOCUMENTOSDESCRICAO";
         cmbavDocumentoobrigatorio_Internalname = sPrefix+"vDOCUMENTOOBRIGATORIO";
         edtavDocumento_Internalname = sPrefix+"vDOCUMENTO";
         edtavNome_Internalname = sPrefix+"vNOME";
         edtavExtensao_Internalname = sPrefix+"vEXTENSAO";
         edtavNomearquivo_Internalname = sPrefix+"vNOMEARQUIVO";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         Btnwizardprevious_Internalname = sPrefix+"BTNWIZARDPREVIOUS";
         Btnwizardnext_Internalname = sPrefix+"BTNWIZARDNEXT";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         Novajanela_Internalname = sPrefix+"NOVAJANELA";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         Griddocumentos_empowerer_Internalname = sPrefix+"GRIDDOCUMENTOS_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGriddocumentos_Internalname = sPrefix+"GRIDDOCUMENTOS";
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
         subGriddocumentos_Allowcollapsing = 0;
         subGriddocumentos_Allowselection = 0;
         subGriddocumentos_Header = "";
         edtavNomearquivo_Jsonclick = "";
         edtavNomearquivo_Enabled = 1;
         edtavExtensao_Jsonclick = "";
         edtavExtensao_Enabled = 1;
         edtavNome_Jsonclick = "";
         edtavNome_Enabled = 1;
         edtavDocumento_Jsonclick = "";
         edtavDocumento_Parameters = "";
         edtavDocumento_Contenttype = "";
         edtavDocumento_Filetype = "";
         edtavDocumento_Enabled = 1;
         cmbavDocumentoobrigatorio_Jsonclick = "";
         cmbavDocumentoobrigatorio.Enabled = 1;
         cmbavDocumentoobrigatorio_Columnclass = "WWColumn";
         edtavDocumentosdescricao_Jsonclick = "";
         edtavDocumentosdescricao_Enabled = 1;
         edtavDocumentosid_Jsonclick = "";
         edtavDocumentosid_Enabled = 1;
         edtavDownload_Jsonclick = "";
         edtavDownload_Class = "Attribute";
         edtavDownload_Enabled = 1;
         edtavAdicionaranexo_Jsonclick = "";
         edtavAdicionaranexo_Enabled = 1;
         subGriddocumentos_Class = "GridWithBorderColor WorkWith";
         subGriddocumentos_Backcolorstyle = 0;
         Novajanela_Target = "";
         cmbavDocumentoobrigatorio_Columnheaderclass = "";
         Btnwizardnext_Class = "Button ButtonWizard";
         Btnwizardnext_Caption = "Próximo";
         Btnwizardnext_Aftericonclass = "fas fa-arrow-right";
         Btnwizardnext_Tooltiptext = "";
         Btnwizardprevious_Class = "BtnDefault ButtonWizard";
         Btnwizardprevious_Caption = "Anterior";
         Btnwizardprevious_Beforeiconclass = "fas fa-arrow-left";
         Btnwizardprevious_Tooltiptext = "";
         subGriddocumentos_Rows = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRIDDOCUMENTOS_nFirstRecordOnPage","type":"int"},{"av":"GRIDDOCUMENTOS_nEOF","type":"int"},{"av":"subGriddocumentos_Rows","ctrl":"GRIDDOCUMENTOS","prop":"Rows"},{"av":"AV27Array_SdPropostaDocumento","fld":"vARRAY_SDPROPOSTADOCUMENTO","type":""},{"av":"sPrefix","type":"char"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"cmbavDocumentoobrigatorio"}]}""");
         setEventMetadata("GRIDDOCUMENTOS.LOAD","""{"handler":"E155Y2","iparms":[{"av":"AV27Array_SdPropostaDocumento","fld":"vARRAY_SDPROPOSTADOCUMENTO","type":""}]""");
         setEventMetadata("GRIDDOCUMENTOS.LOAD",""","oparms":[{"av":"AV22DocumentosId","fld":"vDOCUMENTOSID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"cmbavDocumentoobrigatorio"},{"av":"AV12DocumentoObrigatorio","fld":"vDOCUMENTOOBRIGATORIO","hsh":true,"type":"boolean"},{"av":"AV23DocumentosDescricao","fld":"vDOCUMENTOSDESCRICAO","hsh":true,"type":"svchar"},{"av":"AV25Extensao","fld":"vEXTENSAO","type":"svchar"},{"av":"AV35Nome","fld":"vNOME","hsh":true,"type":"svchar"},{"av":"AV24Documento","fld":"vDOCUMENTO","type":"bitstr"},{"av":"AV36NomeArquivo","fld":"vNOMEARQUIVO","hsh":true,"type":"svchar"},{"av":"AV19AdicionarAnexo","fld":"vADICIONARANEXO","type":"char"},{"av":"AV33Download","fld":"vDOWNLOAD","type":"char"},{"av":"edtavDownload_Class","ctrl":"vDOWNLOAD","prop":"Class"}]}""");
         setEventMetadata("ENTER","""{"handler":"E115Y2","iparms":[{"av":"AV12DocumentoObrigatorio","fld":"vDOCUMENTOOBRIGATORIO","grid":15,"hsh":true,"type":"boolean"},{"av":"GRIDDOCUMENTOS_nFirstRecordOnPage","type":"int"},{"av":"nRC_GXsfl_15","ctrl":"GRIDDOCUMENTOS","prop":"GridRC","grid":15,"type":"int"},{"av":"AV24Documento","fld":"vDOCUMENTO","grid":15,"type":"bitstr"},{"av":"AV23DocumentosDescricao","fld":"vDOCUMENTOSDESCRICAO","grid":15,"hsh":true,"type":"svchar"},{"av":"AV6WebSessionKey","fld":"vWEBSESSIONKEY","type":"svchar"},{"av":"AV22DocumentosId","fld":"vDOCUMENTOSID","grid":15,"pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV35Nome","fld":"vNOME","grid":15,"hsh":true,"type":"svchar"},{"av":"AV25Extensao","fld":"vEXTENSAO","grid":15,"type":"svchar"},{"av":"AV36NomeArquivo","fld":"vNOMEARQUIVO","grid":15,"hsh":true,"type":"svchar"}]}""");
         setEventMetadata("'WIZARDPREVIOUS'","""{"handler":"E125Y2","iparms":[{"av":"AV6WebSessionKey","fld":"vWEBSESSIONKEY","type":"svchar"},{"av":"AV22DocumentosId","fld":"vDOCUMENTOSID","grid":15,"pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"GRIDDOCUMENTOS_nFirstRecordOnPage","type":"int"},{"av":"nRC_GXsfl_15","ctrl":"GRIDDOCUMENTOS","prop":"GridRC","grid":15,"type":"int"},{"av":"AV23DocumentosDescricao","fld":"vDOCUMENTOSDESCRICAO","grid":15,"hsh":true,"type":"svchar"},{"av":"AV12DocumentoObrigatorio","fld":"vDOCUMENTOOBRIGATORIO","grid":15,"hsh":true,"type":"boolean"},{"av":"AV24Documento","fld":"vDOCUMENTO","grid":15,"type":"bitstr"},{"av":"AV35Nome","fld":"vNOME","grid":15,"hsh":true,"type":"svchar"},{"av":"AV25Extensao","fld":"vEXTENSAO","grid":15,"type":"svchar"},{"av":"AV36NomeArquivo","fld":"vNOMEARQUIVO","grid":15,"hsh":true,"type":"svchar"}]}""");
         setEventMetadata("VADICIONARANEXO.CLICK","""{"handler":"E165Y2","iparms":[{"av":"AV22DocumentosId","fld":"vDOCUMENTOSID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("VADICIONARANEXO.CLICK",""","oparms":[{"av":"AV25Extensao","fld":"vEXTENSAO","type":"svchar"},{"av":"AV24Documento","fld":"vDOCUMENTO","type":"bitstr"}]}""");
         setEventMetadata("VDOWNLOAD.CLICK","""{"handler":"E175Y2","iparms":[{"av":"AV27Array_SdPropostaDocumento","fld":"vARRAY_SDPROPOSTADOCUMENTO","type":""},{"av":"AV22DocumentosId","fld":"vDOCUMENTOSID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("VDOWNLOAD.CLICK",""","oparms":[{"av":"Novajanela_Target","ctrl":"NOVAJANELA","prop":"Target"}]}""");
         setEventMetadata("GRIDDOCUMENTOS_FIRSTPAGE","""{"handler":"subgriddocumentos_firstpage","iparms":[{"av":"GRIDDOCUMENTOS_nFirstRecordOnPage","type":"int"},{"av":"GRIDDOCUMENTOS_nEOF","type":"int"},{"av":"subGriddocumentos_Rows","ctrl":"GRIDDOCUMENTOS","prop":"Rows"},{"av":"AV27Array_SdPropostaDocumento","fld":"vARRAY_SDPROPOSTADOCUMENTO","type":""},{"av":"sPrefix","type":"char"}]""");
         setEventMetadata("GRIDDOCUMENTOS_FIRSTPAGE",""","oparms":[{"av":"cmbavDocumentoobrigatorio"}]}""");
         setEventMetadata("GRIDDOCUMENTOS_PREVPAGE","""{"handler":"subgriddocumentos_previouspage","iparms":[{"av":"GRIDDOCUMENTOS_nFirstRecordOnPage","type":"int"},{"av":"GRIDDOCUMENTOS_nEOF","type":"int"},{"av":"subGriddocumentos_Rows","ctrl":"GRIDDOCUMENTOS","prop":"Rows"},{"av":"AV27Array_SdPropostaDocumento","fld":"vARRAY_SDPROPOSTADOCUMENTO","type":""},{"av":"sPrefix","type":"char"}]""");
         setEventMetadata("GRIDDOCUMENTOS_PREVPAGE",""","oparms":[{"av":"cmbavDocumentoobrigatorio"}]}""");
         setEventMetadata("GRIDDOCUMENTOS_NEXTPAGE","""{"handler":"subgriddocumentos_nextpage","iparms":[{"av":"GRIDDOCUMENTOS_nFirstRecordOnPage","type":"int"},{"av":"GRIDDOCUMENTOS_nEOF","type":"int"},{"av":"subGriddocumentos_Rows","ctrl":"GRIDDOCUMENTOS","prop":"Rows"},{"av":"AV27Array_SdPropostaDocumento","fld":"vARRAY_SDPROPOSTADOCUMENTO","type":""},{"av":"sPrefix","type":"char"}]""");
         setEventMetadata("GRIDDOCUMENTOS_NEXTPAGE",""","oparms":[{"av":"cmbavDocumentoobrigatorio"}]}""");
         setEventMetadata("GRIDDOCUMENTOS_LASTPAGE","""{"handler":"subgriddocumentos_lastpage","iparms":[{"av":"GRIDDOCUMENTOS_nFirstRecordOnPage","type":"int"},{"av":"GRIDDOCUMENTOS_nEOF","type":"int"},{"av":"subGriddocumentos_Rows","ctrl":"GRIDDOCUMENTOS","prop":"Rows"},{"av":"AV27Array_SdPropostaDocumento","fld":"vARRAY_SDPROPOSTADOCUMENTO","type":""},{"av":"sPrefix","type":"char"},{"av":"subGriddocumentos_Recordcount","type":"int"}]""");
         setEventMetadata("GRIDDOCUMENTOS_LASTPAGE",""","oparms":[{"av":"cmbavDocumentoobrigatorio"}]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Nomearquivo","iparms":[]}""");
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
         AV27Array_SdPropostaDocumento = new GXBaseCollection<SdtSdPropostaDocumento>( context, "SdPropostaDocumento", "Factory21");
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV30InNome = "";
         AV31InExtensao = "";
         AV29Blob = "";
         AV28SdPropostaDocumento = new SdtSdPropostaDocumento(context);
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         GriddocumentosContainer = new GXWebGrid( context);
         sStyleString = "";
         ucBtnwizardprevious = new GXUserControl();
         ucBtnwizardnext = new GXUserControl();
         ucNovajanela = new GXUserControl();
         ucGriddocumentos_empowerer = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV19AdicionarAnexo = "";
         AV33Download = "";
         AV23DocumentosDescricao = "";
         AV24Documento = "";
         AV35Nome = "";
         AV25Extensao = "";
         AV36NomeArquivo = "";
         GXDecQS = "";
         Griddocumentos_empowerer_Gridinternalname = "";
         GriddocumentosRow = new GXWebRow();
         GXt_char1 = "";
         AV11WizardData = new SdtWpNovaPropostaData(context);
         AV5WebSession = context.GetSession();
         AV13GridDocumentosItem = new SdtWpNovaPropostaData_Documentos_GridDocumentosItem(context);
         AV34Arquivo = "";
         H005Y2_A413DocumentoObrigatorio = new bool[] {false} ;
         H005Y2_n413DocumentoObrigatorio = new bool[] {false} ;
         H005Y2_A405DocumentosId = new int[1] ;
         H005Y2_A406DocumentosDescricao = new string[] {""} ;
         H005Y2_n406DocumentosDescricao = new bool[] {false} ;
         A406DocumentosDescricao = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV6WebSessionKey = "";
         sCtrlAV8PreviousStep = "";
         sCtrlAV7GoingBack = "";
         subGriddocumentos_Linesclass = "";
         TempTags = "";
         ROClassString = "";
         GXCCtl = "";
         gxblobfileaux = new GxFile(context.GetPhysicalPath());
         GriddocumentosColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpnovapropostadocumentos__default(),
            new Object[][] {
                new Object[] {
               H005Y2_A413DocumentoObrigatorio, H005Y2_n413DocumentoObrigatorio, H005Y2_A405DocumentosId, H005Y2_A406DocumentosDescricao, H005Y2_n406DocumentosDescricao
               }
            }
         );
         /* GeneXus formulas. */
         edtavAdicionaranexo_Enabled = 0;
         edtavDownload_Enabled = 0;
         edtavDocumentosid_Enabled = 0;
         edtavDocumentosdescricao_Enabled = 0;
         cmbavDocumentoobrigatorio.Enabled = 0;
         edtavDocumento_Enabled = 0;
         edtavNome_Enabled = 0;
         edtavExtensao_Enabled = 0;
         edtavNomearquivo_Enabled = 0;
      }

      private short GRIDDOCUMENTOS_nEOF ;
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
      private short subGriddocumentos_Backcolorstyle ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short subGriddocumentos_Backstyle ;
      private short subGriddocumentos_Titlebackstyle ;
      private short subGriddocumentos_Allowselection ;
      private short subGriddocumentos_Allowhovering ;
      private short subGriddocumentos_Allowcollapsing ;
      private short subGriddocumentos_Collapsed ;
      private int nRC_GXsfl_15 ;
      private int subGriddocumentos_Recordcount ;
      private int subGriddocumentos_Rows ;
      private int nGXsfl_15_idx=1 ;
      private int edtavAdicionaranexo_Enabled ;
      private int edtavDownload_Enabled ;
      private int edtavDocumentosid_Enabled ;
      private int edtavDocumentosdescricao_Enabled ;
      private int edtavDocumento_Enabled ;
      private int edtavNome_Enabled ;
      private int edtavExtensao_Enabled ;
      private int edtavNomearquivo_Enabled ;
      private int AV32InDocumentosId ;
      private int AV40GXV2 ;
      private int AV22DocumentosId ;
      private int subGriddocumentos_Islastpage ;
      private int GRIDDOCUMENTOS_nGridOutOfScope ;
      private int AV37GXV1 ;
      private int nGXsfl_15_fel_idx=1 ;
      private int AV41GXV3 ;
      private int A405DocumentosId ;
      private int idxLst ;
      private int subGriddocumentos_Backcolor ;
      private int subGriddocumentos_Allbackcolor ;
      private int subGriddocumentos_Titlebackcolor ;
      private int subGriddocumentos_Selectedindex ;
      private int subGriddocumentos_Selectioncolor ;
      private int subGriddocumentos_Hoveringcolor ;
      private long GRIDDOCUMENTOS_nFirstRecordOnPage ;
      private long GRIDDOCUMENTOS_nCurrentRecord ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_15_idx="0001" ;
      private string edtavAdicionaranexo_Internalname ;
      private string edtavDownload_Internalname ;
      private string edtavDocumentosid_Internalname ;
      private string edtavDocumentosdescricao_Internalname ;
      private string cmbavDocumentoobrigatorio_Internalname ;
      private string edtavDocumento_Internalname ;
      private string edtavNome_Internalname ;
      private string edtavExtensao_Internalname ;
      private string edtavNomearquivo_Internalname ;
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
      private string sStyleString ;
      private string subGriddocumentos_Internalname ;
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
      private string Novajanela_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Griddocumentos_empowerer_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV19AdicionarAnexo ;
      private string AV33Download ;
      private string GXDecQS ;
      private string Griddocumentos_empowerer_Gridinternalname ;
      private string cmbavDocumentoobrigatorio_Columnheaderclass ;
      private string edtavDownload_Class ;
      private string cmbavDocumentoobrigatorio_Columnclass ;
      private string sGXsfl_15_fel_idx="0001" ;
      private string GXt_char1 ;
      private string Novajanela_Target ;
      private string sCtrlAV6WebSessionKey ;
      private string sCtrlAV8PreviousStep ;
      private string sCtrlAV7GoingBack ;
      private string subGriddocumentos_Class ;
      private string subGriddocumentos_Linesclass ;
      private string TempTags ;
      private string ROClassString ;
      private string edtavAdicionaranexo_Jsonclick ;
      private string edtavDownload_Jsonclick ;
      private string edtavDocumentosid_Jsonclick ;
      private string edtavDocumentosdescricao_Jsonclick ;
      private string GXCCtl ;
      private string cmbavDocumentoobrigatorio_Jsonclick ;
      private string edtavDocumento_Filetype ;
      private string edtavDocumento_Contenttype ;
      private string edtavDocumento_Parameters ;
      private string edtavDocumento_Jsonclick ;
      private string edtavNome_Jsonclick ;
      private string edtavExtensao_Jsonclick ;
      private string edtavNomearquivo_Jsonclick ;
      private string subGriddocumentos_Header ;
      private bool AV7GoingBack ;
      private bool wcpOAV7GoingBack ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_15_Refreshing=false ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool AV12DocumentoObrigatorio ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV10HasValidationErrors ;
      private bool A413DocumentoObrigatorio ;
      private bool n413DocumentoObrigatorio ;
      private bool n406DocumentosDescricao ;
      private string AV6WebSessionKey ;
      private string AV8PreviousStep ;
      private string wcpOAV6WebSessionKey ;
      private string wcpOAV8PreviousStep ;
      private string AV30InNome ;
      private string AV31InExtensao ;
      private string AV23DocumentosDescricao ;
      private string AV35Nome ;
      private string AV25Extensao ;
      private string AV36NomeArquivo ;
      private string AV34Arquivo ;
      private string A406DocumentosDescricao ;
      private string AV29Blob ;
      private string AV24Documento ;
      private IGxSession AV5WebSession ;
      private GxFile gxblobfileaux ;
      private GXWebGrid GriddocumentosContainer ;
      private GXWebRow GriddocumentosRow ;
      private GXWebColumn GriddocumentosColumn ;
      private GXUserControl ucBtnwizardprevious ;
      private GXUserControl ucBtnwizardnext ;
      private GXUserControl ucNovajanela ;
      private GXUserControl ucGriddocumentos_empowerer ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDocumentoobrigatorio ;
      private GXBaseCollection<SdtSdPropostaDocumento> AV27Array_SdPropostaDocumento ;
      private SdtSdPropostaDocumento AV28SdPropostaDocumento ;
      private SdtWpNovaPropostaData AV11WizardData ;
      private SdtWpNovaPropostaData_Documentos_GridDocumentosItem AV13GridDocumentosItem ;
      private IDataStoreProvider pr_default ;
      private bool[] H005Y2_A413DocumentoObrigatorio ;
      private bool[] H005Y2_n413DocumentoObrigatorio ;
      private int[] H005Y2_A405DocumentosId ;
      private string[] H005Y2_A406DocumentosDescricao ;
      private bool[] H005Y2_n406DocumentosDescricao ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpnovapropostadocumentos__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH005Y2;
          prmH005Y2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H005Y2", "SELECT DocumentoObrigatorio, DocumentosId, DocumentosDescricao FROM Documentos WHERE DocumentoObrigatorio = TRUE ORDER BY DocumentosDescricao ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005Y2,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
       }
    }

 }

}
