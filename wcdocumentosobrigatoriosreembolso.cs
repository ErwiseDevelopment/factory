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
   public class wcdocumentosobrigatoriosreembolso : GXWebComponent
   {
      public wcdocumentosobrigatoriosreembolso( )
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

      public wcdocumentosobrigatoriosreembolso( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_JSON )
      {
         this.AV28JSON = aP0_JSON;
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
         cmbavSddocumentosreembolsos__reembolsodocumentostatus = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "JSON");
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
                  AV28JSON = GetPar( "JSON");
                  AssignAttri(sPrefix, false, "AV28JSON", AV28JSON);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV28JSON});
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
                  gxfirstwebparm = GetFirstPar( "JSON");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "JSON");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
               {
                  gxnrGrid_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
               {
                  gxgrGrid_refresh_invoke( ) ;
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

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_12 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_12"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_12_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_12_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_12_idx = GetPar( "sGXsfl_12_idx");
         sPrefix = GetPar( "sPrefix");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid_newrow( ) ;
         /* End function gxnrGrid_newrow_invoke */
      }

      protected void gxgrGrid_refresh_invoke( )
      {
         subGrid_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid_Rows"), "."), 18, MidpointRounding.ToEven));
         AV45Pgmname = GetPar( "Pgmname");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV17SdDocumentosReembolsos);
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV45Pgmname, AV17SdDocumentosReembolsos, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid_refresh_invoke */
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
            PA6M2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV45Pgmname = "WcDocumentosObrigatoriosReembolso";
               edtavAnexo_Enabled = 0;
               AssignProp(sPrefix, false, edtavAnexo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAnexo_Enabled), 5, 0), !bGXsfl_12_Refreshing);
               edtavDownload_Enabled = 0;
               AssignProp(sPrefix, false, edtavDownload_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDownload_Enabled), 5, 0), !bGXsfl_12_Refreshing);
               edtavSddocumentosreembolsos__documentosid_Enabled = 0;
               AssignProp(sPrefix, false, edtavSddocumentosreembolsos__documentosid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSddocumentosreembolsos__documentosid_Enabled), 5, 0), !bGXsfl_12_Refreshing);
               edtavSddocumentosreembolsos__documentosdescricao_Enabled = 0;
               AssignProp(sPrefix, false, edtavSddocumentosreembolsos__documentosdescricao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSddocumentosreembolsos__documentosdescricao_Enabled), 5, 0), !bGXsfl_12_Refreshing);
               edtavSddocumentosreembolsos__documentonome_Enabled = 0;
               AssignProp(sPrefix, false, edtavSddocumentosreembolsos__documentonome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSddocumentosreembolsos__documentonome_Enabled), 5, 0), !bGXsfl_12_Refreshing);
               edtavSddocumentosreembolsos__documentoextensao_Enabled = 0;
               AssignProp(sPrefix, false, edtavSddocumentosreembolsos__documentoextensao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSddocumentosreembolsos__documentoextensao_Enabled), 5, 0), !bGXsfl_12_Refreshing);
               cmbavSddocumentosreembolsos__reembolsodocumentostatus.Enabled = 0;
               AssignProp(sPrefix, false, cmbavSddocumentosreembolsos__reembolsodocumentostatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSddocumentosreembolsos__reembolsodocumentostatus.Enabled), 5, 0), !bGXsfl_12_Refreshing);
               edtavSddocumentosreembolsos__documentoblob_Enabled = 0;
               AssignProp(sPrefix, false, edtavSddocumentosreembolsos__documentoblob_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSddocumentosreembolsos__documentoblob_Enabled), 5, 0), !bGXsfl_12_Refreshing);
               edtavDocumentosid_Enabled = 0;
               AssignProp(sPrefix, false, edtavDocumentosid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocumentosid_Enabled), 5, 0), !bGXsfl_12_Refreshing);
               edtavReembolsodocumentoid_Enabled = 0;
               AssignProp(sPrefix, false, edtavReembolsodocumentoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavReembolsodocumentoid_Enabled), 5, 0), !bGXsfl_12_Refreshing);
               WS6M2( ) ;
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
            context.SendWebValue( " Documentos") ;
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
            FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
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
            if ( nGXWrapped != 1 )
            {
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               GXEncryptionTmp = "wcdocumentosobrigatoriosreembolso"+UrlEncode(StringUtil.RTrim(AV28JSON));
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wcdocumentosobrigatoriosreembolso") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
               GxWebStd.gx_hidden_field( context, "_EventName", "");
               GxWebStd.gx_hidden_field( context, "_EventGridId", "");
               GxWebStd.gx_hidden_field( context, "_EventRowId", "");
               context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
               AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
            }
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV45Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV45Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Sddocumentosreembolsos", AV17SdDocumentosReembolsos);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Sddocumentosreembolsos", AV17SdDocumentosReembolsos);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_12", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_12), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV28JSON", wcpOAV28JSON);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV45Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV45Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDDOCUMENTOSREEMBOLSOS", AV17SdDocumentosReembolsos);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDDOCUMENTOSREEMBOLSOS", AV17SdDocumentosReembolsos);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vINNOME", AV27InNome);
         GxWebStd.gx_hidden_field( context, sPrefix+"vINEXTENSAO", AV26InExtensao);
         GxWebStd.gx_hidden_field( context, sPrefix+"vINBLOB", AV25InBlob);
         GxWebStd.gx_hidden_field( context, sPrefix+"vINDOCUMENTOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24InDocumentosId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"REEMBOLSODOCUMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A529ReembolsoDocumentoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"REEMBOLSODOCUMENTOBLOB", A531ReembolsoDocumentoBlob);
         GxWebStd.gx_hidden_field( context, sPrefix+"REEMBOLSODOCUMENTONOME", A530ReembolsoDocumentoNome);
         GxWebStd.gx_hidden_field( context, sPrefix+"REEMBOLSODOCUMENTOBLOBEXT", A532ReembolsoDocumentoBlobExt);
         GxWebStd.gx_hidden_field( context, sPrefix+"vJSON", AV28JSON);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDDOCUMENTOSREEMBOLSO", AV18SdDocumentosReembolso);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDDOCUMENTOSREEMBOLSO", AV18SdDocumentosReembolso);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vGXV9", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV46GXV9), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"NOVAJANELA_Target", StringUtil.RTrim( Novajanela_Target));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm6M2( )
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
            if ( nGXWrapped != 1 )
            {
               context.WriteHtmlTextNl( "</form>") ;
            }
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
         return "WcDocumentosObrigatoriosReembolso" ;
      }

      public override string GetPgmdesc( )
      {
         return " Documentos" ;
      }

      protected void WB6M0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wcdocumentosobrigatoriosreembolso");
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell HasGridEmpowerer", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl12( ) ;
         }
         if ( wbEnd == 12 )
         {
            wbEnd = 0;
            nRC_GXsfl_12 = (int)(nGXsfl_12_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
               GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
               AV36GXV1 = nGXsfl_12_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
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
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, sPrefix+"GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 12 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
                  GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
                  AV36GXV1 = nGXsfl_12_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START6M2( )
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
            Form.Meta.addItem("description", " Documentos", 0) ;
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
               STRUP6M0( ) ;
            }
         }
      }

      protected void WS6M2( )
      {
         START6M2( ) ;
         EVT6M2( ) ;
      }

      protected void EVT6M2( )
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
                                 STRUP6M0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6M0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavAnexo_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6M0( ) ;
                              }
                              sEvt = cgiGet( sPrefix+"GRIDPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 12), "VANEXO.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 15), "VDOWNLOAD.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 12), "VANEXO.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 15), "VDOWNLOAD.CLICK") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6M0( ) ;
                              }
                              nGXsfl_12_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
                              SubsflControlProps_122( ) ;
                              AV36GXV1 = (int)(nGXsfl_12_idx+GRID_nFirstRecordOnPage);
                              if ( ( AV17SdDocumentosReembolsos.Count >= AV36GXV1 ) && ( AV36GXV1 > 0 ) )
                              {
                                 AV17SdDocumentosReembolsos.CurrentItem = ((SdtSdDocumentosReembolso)AV17SdDocumentosReembolsos.Item(AV36GXV1));
                                 AV19Anexo = cgiGet( edtavAnexo_Internalname);
                                 AssignAttri(sPrefix, false, edtavAnexo_Internalname, AV19Anexo);
                                 AV31Download = cgiGet( edtavDownload_Internalname);
                                 AssignAttri(sPrefix, false, edtavDownload_Internalname, AV31Download);
                                 if ( ( ( context.localUtil.CToN( cgiGet( edtavDocumentosid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavDocumentosid_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
                                 {
                                    GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vDOCUMENTOSID");
                                    GX_FocusControl = edtavDocumentosid_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                    wbErr = true;
                                    AV23DocumentosId = 0;
                                    AssignAttri(sPrefix, false, edtavDocumentosid_Internalname, StringUtil.LTrimStr( (decimal)(AV23DocumentosId), 9, 0));
                                    GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDOCUMENTOSID"+"_"+sGXsfl_12_idx, GetSecureSignedToken( sPrefix+sGXsfl_12_idx, context.localUtil.Format( (decimal)(AV23DocumentosId), "ZZZZZZZZ9"), context));
                                 }
                                 else
                                 {
                                    AV23DocumentosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavDocumentosid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                                    AssignAttri(sPrefix, false, edtavDocumentosid_Internalname, StringUtil.LTrimStr( (decimal)(AV23DocumentosId), 9, 0));
                                    GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDOCUMENTOSID"+"_"+sGXsfl_12_idx, GetSecureSignedToken( sPrefix+sGXsfl_12_idx, context.localUtil.Format( (decimal)(AV23DocumentosId), "ZZZZZZZZ9"), context));
                                 }
                                 if ( ( ( context.localUtil.CToN( cgiGet( edtavReembolsodocumentoid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavReembolsodocumentoid_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
                                 {
                                    GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vREEMBOLSODOCUMENTOID");
                                    GX_FocusControl = edtavReembolsodocumentoid_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                    wbErr = true;
                                    AV35ReembolsoDocumentoId = 0;
                                    AssignAttri(sPrefix, false, edtavReembolsodocumentoid_Internalname, StringUtil.LTrimStr( (decimal)(AV35ReembolsoDocumentoId), 9, 0));
                                    GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vREEMBOLSODOCUMENTOID"+"_"+sGXsfl_12_idx, GetSecureSignedToken( sPrefix+sGXsfl_12_idx, context.localUtil.Format( (decimal)(AV35ReembolsoDocumentoId), "ZZZZZZZZ9"), context));
                                 }
                                 else
                                 {
                                    AV35ReembolsoDocumentoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavReembolsodocumentoid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                                    AssignAttri(sPrefix, false, edtavReembolsodocumentoid_Internalname, StringUtil.LTrimStr( (decimal)(AV35ReembolsoDocumentoId), 9, 0));
                                    GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vREEMBOLSODOCUMENTOID"+"_"+sGXsfl_12_idx, GetSecureSignedToken( sPrefix+sGXsfl_12_idx, context.localUtil.Format( (decimal)(AV35ReembolsoDocumentoId), "ZZZZZZZZ9"), context));
                                 }
                              }
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
                                          GX_FocusControl = edtavAnexo_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E116M2 ();
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
                                          GX_FocusControl = edtavAnexo_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E126M2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavAnexo_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Grid.Load */
                                          E136M2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VANEXO.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavAnexo_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E146M2 ();
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
                                          GX_FocusControl = edtavAnexo_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E156M2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
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
                                             }
                                             dynload_actions( ) ;
                                          }
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP6M0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavAnexo_Internalname;
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

      protected void WE6M2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm6M2( ) ;
            }
         }
      }

      protected void PA6M2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wcdocumentosobrigatoriosreembolso")), "wcdocumentosobrigatoriosreembolso") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wcdocumentosobrigatoriosreembolso")))) ;
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
                     gxfirstwebparm = GetFirstPar( "JSON");
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

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_122( ) ;
         while ( nGXsfl_12_idx <= nRC_GXsfl_12 )
         {
            sendrow_122( ) ;
            nGXsfl_12_idx = ((subGrid_Islastpage==1)&&(nGXsfl_12_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_12_idx+1);
            sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
            SubsflControlProps_122( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV45Pgmname ,
                                       GXBaseCollection<SdtSdDocumentosReembolso> AV17SdDocumentosReembolsos ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF6M2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDOCUMENTOSID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV23DocumentosId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDOCUMENTOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23DocumentosId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vREEMBOLSODOCUMENTOID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV35ReembolsoDocumentoId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vREEMBOLSODOCUMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV35ReembolsoDocumentoId), 9, 0, ".", "")));
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
         RF6M2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV45Pgmname = "WcDocumentosObrigatoriosReembolso";
         edtavAnexo_Enabled = 0;
         edtavDownload_Enabled = 0;
         edtavSddocumentosreembolsos__documentosid_Enabled = 0;
         edtavSddocumentosreembolsos__documentosdescricao_Enabled = 0;
         edtavSddocumentosreembolsos__documentonome_Enabled = 0;
         edtavSddocumentosreembolsos__documentoextensao_Enabled = 0;
         cmbavSddocumentosreembolsos__reembolsodocumentostatus.Enabled = 0;
         edtavSddocumentosreembolsos__documentoblob_Enabled = 0;
         edtavDocumentosid_Enabled = 0;
         edtavReembolsodocumentoid_Enabled = 0;
      }

      protected void RF6M2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 12;
         /* Execute user event: Refresh */
         E126M2 ();
         nGXsfl_12_idx = 1;
         sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
         SubsflControlProps_122( ) ;
         bGXsfl_12_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", sPrefix);
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithBorderColor WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_122( ) ;
            /* Execute user event: Grid.Load */
            E136M2 ();
            if ( ( subGrid_Islastpage == 0 ) && ( GRID_nCurrentRecord > 0 ) && ( GRID_nGridOutOfScope == 0 ) && ( nGXsfl_12_idx == 1 ) )
            {
               GRID_nCurrentRecord = 0;
               GRID_nGridOutOfScope = 1;
               subgrid_firstpage( ) ;
               /* Execute user event: Grid.Load */
               E136M2 ();
            }
            wbEnd = 12;
            WB6M0( ) ;
         }
         bGXsfl_12_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes6M2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV45Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV45Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDOCUMENTOSID"+"_"+sGXsfl_12_idx, GetSecureSignedToken( sPrefix+sGXsfl_12_idx, context.localUtil.Format( (decimal)(AV23DocumentosId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vREEMBOLSODOCUMENTOID"+"_"+sGXsfl_12_idx, GetSecureSignedToken( sPrefix+sGXsfl_12_idx, context.localUtil.Format( (decimal)(AV35ReembolsoDocumentoId), "ZZZZZZZZ9"), context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         return AV17SdDocumentosReembolsos.Count ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid_firstpage( )
      {
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV45Pgmname, AV17SdDocumentosReembolsos, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV45Pgmname, AV17SdDocumentosReembolsos, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV45Pgmname, AV17SdDocumentosReembolsos, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( GRID_nRecordCount > subGrid_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-subGrid_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV45Pgmname, AV17SdDocumentosReembolsos, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV45Pgmname, AV17SdDocumentosReembolsos, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV45Pgmname = "WcDocumentosObrigatoriosReembolso";
         edtavAnexo_Enabled = 0;
         edtavDownload_Enabled = 0;
         edtavSddocumentosreembolsos__documentosid_Enabled = 0;
         edtavSddocumentosreembolsos__documentosdescricao_Enabled = 0;
         edtavSddocumentosreembolsos__documentonome_Enabled = 0;
         edtavSddocumentosreembolsos__documentoextensao_Enabled = 0;
         cmbavSddocumentosreembolsos__reembolsodocumentostatus.Enabled = 0;
         edtavSddocumentosreembolsos__documentoblob_Enabled = 0;
         edtavDocumentosid_Enabled = 0;
         edtavReembolsodocumentoid_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP6M0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E116M2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Sddocumentosreembolsos"), AV17SdDocumentosReembolsos);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vSDDOCUMENTOSREEMBOLSOS"), AV17SdDocumentosReembolsos);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vSDDOCUMENTOSREEMBOLSO"), AV18SdDocumentosReembolso);
            /* Read saved values. */
            nRC_GXsfl_12 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_12"), ",", "."), 18, MidpointRounding.ToEven));
            wcpOAV28JSON = cgiGet( sPrefix+"wcpOAV28JSON");
            AV27InNome = cgiGet( sPrefix+"vINNOME");
            AV26InExtensao = cgiGet( sPrefix+"vINEXTENSAO");
            AV25InBlob = cgiGet( sPrefix+"vINBLOB");
            AV46GXV9 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGXV9"), ",", "."), 18, MidpointRounding.ToEven));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nFirstRecordOnPage"), ",", "."), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nEOF"), ",", "."), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Novajanela_Target = cgiGet( sPrefix+"NOVAJANELA_Target");
            Grid_empowerer_Gridinternalname = cgiGet( sPrefix+"GRID_EMPOWERER_Gridinternalname");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            nRC_GXsfl_12 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_12"), ",", "."), 18, MidpointRounding.ToEven));
            nGXsfl_12_fel_idx = 0;
            while ( nGXsfl_12_fel_idx < nRC_GXsfl_12 )
            {
               nGXsfl_12_fel_idx = ((subGrid_Islastpage==1)&&(nGXsfl_12_fel_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_12_fel_idx+1);
               sGXsfl_12_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_122( ) ;
               AV36GXV1 = (int)(nGXsfl_12_fel_idx+GRID_nFirstRecordOnPage);
               if ( ( AV17SdDocumentosReembolsos.Count >= AV36GXV1 ) && ( AV36GXV1 > 0 ) )
               {
                  AV17SdDocumentosReembolsos.CurrentItem = ((SdtSdDocumentosReembolso)AV17SdDocumentosReembolsos.Item(AV36GXV1));
                  AV19Anexo = cgiGet( edtavAnexo_Internalname);
                  AV31Download = cgiGet( edtavDownload_Internalname);
                  if ( ( ( context.localUtil.CToN( cgiGet( edtavDocumentosid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavDocumentosid_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vDOCUMENTOSID");
                     GX_FocusControl = edtavDocumentosid_Internalname;
                     wbErr = true;
                     AV23DocumentosId = 0;
                  }
                  else
                  {
                     AV23DocumentosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavDocumentosid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  }
                  if ( ( ( context.localUtil.CToN( cgiGet( edtavReembolsodocumentoid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavReembolsodocumentoid_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vREEMBOLSODOCUMENTOID");
                     GX_FocusControl = edtavReembolsodocumentoid_Internalname;
                     wbErr = true;
                     AV35ReembolsoDocumentoId = 0;
                  }
                  else
                  {
                     AV35ReembolsoDocumentoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavReembolsodocumentoid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  }
               }
            }
            if ( nGXsfl_12_fel_idx == 0 )
            {
               nGXsfl_12_idx = 1;
               sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
               SubsflControlProps_122( ) ;
            }
            nGXsfl_12_fel_idx = 1;
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
         E116M2 ();
         if (returnInSub) return;
      }

      protected void E116M2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, sPrefix, false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S112 ();
         if (returnInSub) return;
         AV29Array_SdDocumentosReembolso = new GXBaseCollection<SdtSdDocumentosReembolso>( context, "SdDocumentosReembolso", "Factory21");
         AV29Array_SdDocumentosReembolso.FromJSonString(AV28JSON, null);
         AV17SdDocumentosReembolsos = new GXBaseCollection<SdtSdDocumentosReembolso>( context, "SdDocumentosReembolso", "Factory21");
         gx_BV12 = true;
         /* Using cursor H006M2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A536DocumentoObrigatorioReembolso = H006M2_A536DocumentoObrigatorioReembolso[0];
            n536DocumentoObrigatorioReembolso = H006M2_n536DocumentoObrigatorioReembolso[0];
            A407DocumentosStatus = H006M2_A407DocumentosStatus[0];
            n407DocumentosStatus = H006M2_n407DocumentosStatus[0];
            A405DocumentosId = H006M2_A405DocumentosId[0];
            A406DocumentosDescricao = H006M2_A406DocumentosDescricao[0];
            n406DocumentosDescricao = H006M2_n406DocumentosDescricao[0];
            AV18SdDocumentosReembolso = new SdtSdDocumentosReembolso(context);
            AV18SdDocumentosReembolso.gxTpr_Documentosid = A405DocumentosId;
            AV18SdDocumentosReembolso.gxTpr_Documentosdescricao = A406DocumentosDescricao;
            AV44GXV8 = 1;
            while ( AV44GXV8 <= AV29Array_SdDocumentosReembolso.Count )
            {
               AV30AuxSdDocumentosReembolso = ((SdtSdDocumentosReembolso)AV29Array_SdDocumentosReembolso.Item(AV44GXV8));
               if ( AV18SdDocumentosReembolso.gxTpr_Documentosid == AV30AuxSdDocumentosReembolso.gxTpr_Documentosid )
               {
                  AV18SdDocumentosReembolso.gxTpr_Documentonome = AV30AuxSdDocumentosReembolso.gxTpr_Documentonome;
                  AV18SdDocumentosReembolso.gxTpr_Documentoextensao = AV30AuxSdDocumentosReembolso.gxTpr_Documentoextensao;
                  AV18SdDocumentosReembolso.gxTpr_Documentoblob = AV30AuxSdDocumentosReembolso.gxTpr_Documentoblob;
                  AV18SdDocumentosReembolso.gxTpr_Reembolsodocumentoid = AV30AuxSdDocumentosReembolso.gxTpr_Reembolsodocumentoid;
                  AV18SdDocumentosReembolso.gxTpr_Reembolsodocumentostatus = AV30AuxSdDocumentosReembolso.gxTpr_Reembolsodocumentostatus;
                  if (true) break;
               }
               AV44GXV8 = (int)(AV44GXV8+1);
            }
            AV17SdDocumentosReembolsos.Add(AV18SdDocumentosReembolso, 0);
            gx_BV12 = true;
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void E126M2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADGRIDSDT' */
         S132 ();
         if (returnInSub) return;
      }

      private void E136M2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV36GXV1 = 1;
         while ( AV36GXV1 <= AV17SdDocumentosReembolsos.Count )
         {
            AV17SdDocumentosReembolsos.CurrentItem = ((SdtSdDocumentosReembolso)AV17SdDocumentosReembolsos.Item(AV36GXV1));
            AV23DocumentosId = ((SdtSdDocumentosReembolso)(AV17SdDocumentosReembolsos.CurrentItem)).gxTpr_Documentosid;
            AssignAttri(sPrefix, false, edtavDocumentosid_Internalname, StringUtil.LTrimStr( (decimal)(AV23DocumentosId), 9, 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDOCUMENTOSID"+"_"+sGXsfl_12_idx, GetSecureSignedToken( sPrefix+sGXsfl_12_idx, context.localUtil.Format( (decimal)(AV23DocumentosId), "ZZZZZZZZ9"), context));
            AV35ReembolsoDocumentoId = ((SdtSdDocumentosReembolso)(AV17SdDocumentosReembolsos.CurrentItem)).gxTpr_Reembolsodocumentoid;
            AssignAttri(sPrefix, false, edtavReembolsodocumentoid_Internalname, StringUtil.LTrimStr( (decimal)(AV35ReembolsoDocumentoId), 9, 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vREEMBOLSODOCUMENTOID"+"_"+sGXsfl_12_idx, GetSecureSignedToken( sPrefix+sGXsfl_12_idx, context.localUtil.Format( (decimal)(AV35ReembolsoDocumentoId), "ZZZZZZZZ9"), context));
            AV19Anexo = "<i class=\"fas fa-plus\"></i>";
            AssignAttri(sPrefix, false, edtavAnexo_Internalname, AV19Anexo);
            if ( ! ( StringUtil.StrCmp(((SdtSdDocumentosReembolso)(AV17SdDocumentosReembolsos.CurrentItem)).gxTpr_Reembolsodocumentostatus, "APROVADO") == 0 ) )
            {
               edtavAnexo_Class = "Attribute";
            }
            else
            {
               edtavAnexo_Class = "Invisible";
            }
            AV31Download = "<i class=\"fas fa-download\"></i>";
            AssignAttri(sPrefix, false, edtavDownload_Internalname, AV31Download);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSdDocumentosReembolso)(AV17SdDocumentosReembolsos.CurrentItem)).gxTpr_Documentoblob)) )
            {
               edtavDownload_Class = "Attribute";
            }
            else
            {
               edtavDownload_Class = "Invisible";
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 12;
            }
            if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_122( ) ;
            }
            GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_12_Refreshing )
            {
               DoAjaxLoad(12, GridRow);
            }
            AV36GXV1 = (int)(AV36GXV1+1);
         }
         /*  Sending Event outputs  */
      }

      protected void E146M2( )
      {
         /* Anexo_Click Routine */
         returnInSub = false;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "popupnovodocumentonome"+UrlEncode(StringUtil.LTrimStr(AV23DocumentosId,9,0)) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.RTrim(""));
         context.PopUp(formatLink("popupnovodocumentonome") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {"AV20Blob","AV21Extensao","AV22Nome"});
         context.DoAjaxRefreshCmp(sPrefix);
      }

      protected void S132( )
      {
         /* 'LOADGRIDSDT' Routine */
         returnInSub = false;
      }

      protected void S112( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV13Session.Get(AV45Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV45Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV13Session.Get(AV45Pgmname+"GridState"), null, "", "");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV10GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV10GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV10GridState.gxTpr_Currentpage) ;
      }

      protected void S122( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV13Session.Get(AV45Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV45Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void E156M2( )
      {
         AV36GXV1 = (int)(nGXsfl_12_idx+GRID_nFirstRecordOnPage);
         if ( ( AV36GXV1 > 0 ) && ( AV17SdDocumentosReembolsos.Count >= AV36GXV1 ) )
         {
            AV17SdDocumentosReembolsos.CurrentItem = ((SdtSdDocumentosReembolso)AV17SdDocumentosReembolsos.Item(AV36GXV1));
         }
         /* Download_Click Routine */
         returnInSub = false;
         if ( ! (0==AV35ReembolsoDocumentoId) )
         {
            /* Using cursor H006M3 */
            pr_default.execute(1, new Object[] {AV35ReembolsoDocumentoId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A529ReembolsoDocumentoId = H006M3_A529ReembolsoDocumentoId[0];
               A530ReembolsoDocumentoNome = H006M3_A530ReembolsoDocumentoNome[0];
               n530ReembolsoDocumentoNome = H006M3_n530ReembolsoDocumentoNome[0];
               A532ReembolsoDocumentoBlobExt = H006M3_A532ReembolsoDocumentoBlobExt[0];
               n532ReembolsoDocumentoBlobExt = H006M3_n532ReembolsoDocumentoBlobExt[0];
               A531ReembolsoDocumentoBlob = H006M3_A531ReembolsoDocumentoBlob[0];
               n531ReembolsoDocumentoBlob = H006M3_n531ReembolsoDocumentoBlob[0];
               new prdownloadblob(context ).execute(  A531ReembolsoDocumentoBlob,  A530ReembolsoDocumentoNome,  A532ReembolsoDocumentoBlobExt, out  AV34Arquivo) ;
               Novajanela_Target = AV34Arquivo;
               ucNovajanela.SendProperty(context, sPrefix, false, Novajanela_Internalname, "Target", Novajanela_Target);
               this.executeUsercontrolMethod(sPrefix, false, "NOVAJANELAContainer", "OpenWindow", "", new Object[] {});
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
         }
         else
         {
            AV48GXV10 = 1;
            while ( AV48GXV10 <= AV17SdDocumentosReembolsos.Count )
            {
               AV18SdDocumentosReembolso = ((SdtSdDocumentosReembolso)AV17SdDocumentosReembolsos.Item(AV48GXV10));
               if ( AV18SdDocumentosReembolso.gxTpr_Documentosid == AV23DocumentosId )
               {
                  new prdownloadblob(context ).execute(  AV18SdDocumentosReembolso.gxTpr_Documentoblob,  AV18SdDocumentosReembolso.gxTpr_Documentonome,  AV18SdDocumentosReembolso.gxTpr_Documentoextensao, out  AV34Arquivo) ;
                  Novajanela_Target = AV34Arquivo;
                  ucNovajanela.SendProperty(context, sPrefix, false, Novajanela_Internalname, "Target", Novajanela_Target);
                  this.executeUsercontrolMethod(sPrefix, false, "NOVAJANELAContainer", "OpenWindow", "", new Object[] {});
                  if (true) break;
               }
               AV48GXV10 = (int)(AV48GXV10+1);
            }
         }
         /*  Sending Event outputs  */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV28JSON = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV28JSON", AV28JSON);
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
         PA6M2( ) ;
         WS6M2( ) ;
         WE6M2( ) ;
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
         sCtrlAV28JSON = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA6M2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wcdocumentosobrigatoriosreembolso", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA6M2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV28JSON = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV28JSON", AV28JSON);
         }
         wcpOAV28JSON = cgiGet( sPrefix+"wcpOAV28JSON");
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV28JSON, wcpOAV28JSON) != 0 ) ) )
         {
            setjustcreated();
         }
         wcpOAV28JSON = AV28JSON;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV28JSON = cgiGet( sPrefix+"AV28JSON_CTRL");
         if ( StringUtil.Len( sCtrlAV28JSON) > 0 )
         {
            AV28JSON = cgiGet( sCtrlAV28JSON);
            AssignAttri(sPrefix, false, "AV28JSON", AV28JSON);
         }
         else
         {
            AV28JSON = cgiGet( sPrefix+"AV28JSON_PARM");
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
         PA6M2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS6M2( ) ;
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
         WS6M2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV28JSON_PARM", AV28JSON);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV28JSON)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV28JSON_CTRL", StringUtil.RTrim( sCtrlAV28JSON));
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
         WE6M2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101965114", true, true);
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
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("wcdocumentosobrigatoriosreembolso.js", "?20256101965115", false, true);
            context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_122( )
      {
         edtavAnexo_Internalname = sPrefix+"vANEXO_"+sGXsfl_12_idx;
         edtavDownload_Internalname = sPrefix+"vDOWNLOAD_"+sGXsfl_12_idx;
         edtavSddocumentosreembolsos__documentosid_Internalname = sPrefix+"SDDOCUMENTOSREEMBOLSOS__DOCUMENTOSID_"+sGXsfl_12_idx;
         edtavSddocumentosreembolsos__documentosdescricao_Internalname = sPrefix+"SDDOCUMENTOSREEMBOLSOS__DOCUMENTOSDESCRICAO_"+sGXsfl_12_idx;
         edtavSddocumentosreembolsos__documentonome_Internalname = sPrefix+"SDDOCUMENTOSREEMBOLSOS__DOCUMENTONOME_"+sGXsfl_12_idx;
         edtavSddocumentosreembolsos__documentoextensao_Internalname = sPrefix+"SDDOCUMENTOSREEMBOLSOS__DOCUMENTOEXTENSAO_"+sGXsfl_12_idx;
         cmbavSddocumentosreembolsos__reembolsodocumentostatus_Internalname = sPrefix+"SDDOCUMENTOSREEMBOLSOS__REEMBOLSODOCUMENTOSTATUS_"+sGXsfl_12_idx;
         edtavSddocumentosreembolsos__documentoblob_Internalname = sPrefix+"SDDOCUMENTOSREEMBOLSOS__DOCUMENTOBLOB_"+sGXsfl_12_idx;
         edtavDocumentosid_Internalname = sPrefix+"vDOCUMENTOSID_"+sGXsfl_12_idx;
         edtavReembolsodocumentoid_Internalname = sPrefix+"vREEMBOLSODOCUMENTOID_"+sGXsfl_12_idx;
      }

      protected void SubsflControlProps_fel_122( )
      {
         edtavAnexo_Internalname = sPrefix+"vANEXO_"+sGXsfl_12_fel_idx;
         edtavDownload_Internalname = sPrefix+"vDOWNLOAD_"+sGXsfl_12_fel_idx;
         edtavSddocumentosreembolsos__documentosid_Internalname = sPrefix+"SDDOCUMENTOSREEMBOLSOS__DOCUMENTOSID_"+sGXsfl_12_fel_idx;
         edtavSddocumentosreembolsos__documentosdescricao_Internalname = sPrefix+"SDDOCUMENTOSREEMBOLSOS__DOCUMENTOSDESCRICAO_"+sGXsfl_12_fel_idx;
         edtavSddocumentosreembolsos__documentonome_Internalname = sPrefix+"SDDOCUMENTOSREEMBOLSOS__DOCUMENTONOME_"+sGXsfl_12_fel_idx;
         edtavSddocumentosreembolsos__documentoextensao_Internalname = sPrefix+"SDDOCUMENTOSREEMBOLSOS__DOCUMENTOEXTENSAO_"+sGXsfl_12_fel_idx;
         cmbavSddocumentosreembolsos__reembolsodocumentostatus_Internalname = sPrefix+"SDDOCUMENTOSREEMBOLSOS__REEMBOLSODOCUMENTOSTATUS_"+sGXsfl_12_fel_idx;
         edtavSddocumentosreembolsos__documentoblob_Internalname = sPrefix+"SDDOCUMENTOSREEMBOLSOS__DOCUMENTOBLOB_"+sGXsfl_12_fel_idx;
         edtavDocumentosid_Internalname = sPrefix+"vDOCUMENTOSID_"+sGXsfl_12_fel_idx;
         edtavReembolsodocumentoid_Internalname = sPrefix+"vREEMBOLSODOCUMENTOID_"+sGXsfl_12_fel_idx;
      }

      protected void sendrow_122( )
      {
         sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
         SubsflControlProps_122( ) ;
         WB6M0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_12_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
         {
            GridRow = GXWebRow.GetNew(context,GridContainer);
            if ( subGrid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
            else if ( subGrid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_Backstyle = 0;
               subGrid_Backcolor = subGrid_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Uniform";
               }
            }
            else if ( subGrid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
               subGrid_Backcolor = (int)(0x0);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_12_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"GridWithBorderColor WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_12_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 13,'" + sPrefix + "',false,'" + sGXsfl_12_idx + "',12)\"";
            ROClassString = edtavAnexo_Class;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavAnexo_Internalname,StringUtil.RTrim( AV19Anexo),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,13);\"","'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVANEXO.CLICK."+sGXsfl_12_idx+"'",(string)"",(string)"",(string)"Anexo",(string)"",(string)edtavAnexo_Jsonclick,(short)5,(string)edtavAnexo_Class,(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavAnexo_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)12,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'" + sPrefix + "',false,'" + sGXsfl_12_idx + "',12)\"";
            ROClassString = edtavDownload_Class;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDownload_Internalname,StringUtil.RTrim( AV31Download),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,14);\"","'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVDOWNLOAD.CLICK."+sGXsfl_12_idx+"'",(string)"",(string)"",(string)"Download",(string)"",(string)edtavDownload_Jsonclick,(short)5,(string)edtavDownload_Class,(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavDownload_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)12,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSddocumentosreembolsos__documentosid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSdDocumentosReembolso)AV17SdDocumentosReembolsos.Item(AV36GXV1)).gxTpr_Documentosid), 9, 0, ",", "")),StringUtil.LTrim( ((edtavSddocumentosreembolsos__documentosid_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSdDocumentosReembolso)AV17SdDocumentosReembolsos.Item(AV36GXV1)).gxTpr_Documentosid), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSdDocumentosReembolso)AV17SdDocumentosReembolsos.Item(AV36GXV1)).gxTpr_Documentosid), "ZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+""+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSddocumentosreembolsos__documentosid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSddocumentosreembolsos__documentosid_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'" + sPrefix + "',false,'" + sGXsfl_12_idx + "',12)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSddocumentosreembolsos__documentosdescricao_Internalname,((SdtSdDocumentosReembolso)AV17SdDocumentosReembolsos.Item(AV36GXV1)).gxTpr_Documentosdescricao,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,16);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSddocumentosreembolsos__documentosdescricao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSddocumentosreembolsos__documentosdescricao_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'" + sPrefix + "',false,'" + sGXsfl_12_idx + "',12)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSddocumentosreembolsos__documentonome_Internalname,((SdtSdDocumentosReembolso)AV17SdDocumentosReembolsos.Item(AV36GXV1)).gxTpr_Documentonome,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,17);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSddocumentosreembolsos__documentonome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSddocumentosreembolsos__documentonome_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'" + sPrefix + "',false,'" + sGXsfl_12_idx + "',12)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSddocumentosreembolsos__documentoextensao_Internalname,((SdtSdDocumentosReembolso)AV17SdDocumentosReembolsos.Item(AV36GXV1)).gxTpr_Documentoextensao,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,18);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSddocumentosreembolsos__documentoextensao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSddocumentosreembolsos__documentoextensao_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'" + sPrefix + "',false,'" + sGXsfl_12_idx + "',12)\"";
            if ( ( cmbavSddocumentosreembolsos__reembolsodocumentostatus.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "SDDOCUMENTOSREEMBOLSOS__REEMBOLSODOCUMENTOSTATUS_" + sGXsfl_12_idx;
               cmbavSddocumentosreembolsos__reembolsodocumentostatus.Name = GXCCtl;
               cmbavSddocumentosreembolsos__reembolsodocumentostatus.WebTags = "";
               cmbavSddocumentosreembolsos__reembolsodocumentostatus.addItem("AGUARDANDO_ANALISE", "Aguardando análise", 0);
               cmbavSddocumentosreembolsos__reembolsodocumentostatus.addItem("APROVADO", "Aprovado", 0);
               cmbavSddocumentosreembolsos__reembolsodocumentostatus.addItem("REPROVADO", "Reprovado", 0);
               if ( cmbavSddocumentosreembolsos__reembolsodocumentostatus.ItemCount > 0 )
               {
                  if ( ( AV36GXV1 > 0 ) && ( AV17SdDocumentosReembolsos.Count >= AV36GXV1 ) && String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSdDocumentosReembolso)AV17SdDocumentosReembolsos.Item(AV36GXV1)).gxTpr_Reembolsodocumentostatus)) )
                  {
                     ((SdtSdDocumentosReembolso)AV17SdDocumentosReembolsos.Item(AV36GXV1)).gxTpr_Reembolsodocumentostatus = cmbavSddocumentosreembolsos__reembolsodocumentostatus.getValidValue(((SdtSdDocumentosReembolso)AV17SdDocumentosReembolsos.Item(AV36GXV1)).gxTpr_Reembolsodocumentostatus);
                  }
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavSddocumentosreembolsos__reembolsodocumentostatus,(string)cmbavSddocumentosreembolsos__reembolsodocumentostatus_Internalname,StringUtil.RTrim( ((SdtSdDocumentosReembolso)AV17SdDocumentosReembolsos.Item(AV36GXV1)).gxTpr_Reembolsodocumentostatus),(short)1,(string)cmbavSddocumentosreembolsos__reembolsodocumentostatus_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,cmbavSddocumentosreembolsos__reembolsodocumentostatus.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,19);\"",(string)"",(bool)true,(short)0});
            cmbavSddocumentosreembolsos__reembolsodocumentostatus.CurrentValue = StringUtil.RTrim( ((SdtSdDocumentosReembolso)AV17SdDocumentosReembolsos.Item(AV36GXV1)).gxTpr_Reembolsodocumentostatus);
            AssignProp(sPrefix, false, cmbavSddocumentosreembolsos__reembolsodocumentostatus_Internalname, "Values", (string)(cmbavSddocumentosreembolsos__reembolsodocumentostatus.ToJavascriptSource()), !bGXsfl_12_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            ClassString = "Attribute";
            StyleString = "";
            edtavSddocumentosreembolsos__documentoblob_Filetype = "tmp";
            AssignProp(sPrefix, false, edtavSddocumentosreembolsos__documentoblob_Internalname, "Filetype", edtavSddocumentosreembolsos__documentoblob_Filetype, !bGXsfl_12_Refreshing);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSdDocumentosReembolso)AV17SdDocumentosReembolsos.Item(AV36GXV1)).gxTpr_Documentoblob)) )
            {
               gxblobfileaux.Source = ((SdtSdDocumentosReembolso)AV17SdDocumentosReembolsos.Item(AV36GXV1)).gxTpr_Documentoblob;
               if ( ! gxblobfileaux.HasExtension() || ( StringUtil.StrCmp(edtavSddocumentosreembolsos__documentoblob_Filetype, "tmp") != 0 ) )
               {
                  gxblobfileaux.SetExtension(StringUtil.Trim( edtavSddocumentosreembolsos__documentoblob_Filetype));
               }
               if ( gxblobfileaux.ErrCode == 0 )
               {
                  ((SdtSdDocumentosReembolso)AV17SdDocumentosReembolsos.Item(AV36GXV1)).gxTpr_Documentoblob = gxblobfileaux.GetURI();
                  edtavSddocumentosreembolsos__documentoblob_Filetype = gxblobfileaux.GetExtension();
                  AssignProp(sPrefix, false, edtavSddocumentosreembolsos__documentoblob_Internalname, "Filetype", edtavSddocumentosreembolsos__documentoblob_Filetype, !bGXsfl_12_Refreshing);
               }
               AssignProp(sPrefix, false, edtavSddocumentosreembolsos__documentoblob_Internalname, "URL", context.PathToRelativeUrl( ((SdtSdDocumentosReembolso)AV17SdDocumentosReembolsos.Item(AV36GXV1)).gxTpr_Documentoblob), !bGXsfl_12_Refreshing);
            }
            GridRow.AddColumnProperties("blob", 2, isAjaxCallMode( ), new Object[] {(string)edtavSddocumentosreembolsos__documentoblob_Internalname,StringUtil.RTrim( ((SdtSdDocumentosReembolso)AV17SdDocumentosReembolsos.Item(AV36GXV1)).gxTpr_Documentoblob),context.PathToRelativeUrl( ((SdtSdDocumentosReembolso)AV17SdDocumentosReembolsos.Item(AV36GXV1)).gxTpr_Documentoblob),(String.IsNullOrEmpty(StringUtil.RTrim( edtavSddocumentosreembolsos__documentoblob_Contenttype)) ? context.GetContentType( (String.IsNullOrEmpty(StringUtil.RTrim( edtavSddocumentosreembolsos__documentoblob_Filetype)) ? ((SdtSdDocumentosReembolso)AV17SdDocumentosReembolsos.Item(AV36GXV1)).gxTpr_Documentoblob : edtavSddocumentosreembolsos__documentoblob_Filetype)) : edtavSddocumentosreembolsos__documentoblob_Contenttype),(bool)false,(string)"",(string)edtavSddocumentosreembolsos__documentoblob_Parameters,(short)0,(int)edtavSddocumentosreembolsos__documentoblob_Enabled,(short)0,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)60,(string)"px",(short)0,(short)0,(short)0,(string)edtavSddocumentosreembolsos__documentoblob_Jsonclick,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",""+""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDocumentosid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23DocumentosId), 9, 0, ",", "")),StringUtil.LTrim( ((edtavDocumentosid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV23DocumentosId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV23DocumentosId), "ZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+""+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDocumentosid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavDocumentosid_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavReembolsodocumentoid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV35ReembolsoDocumentoId), 9, 0, ",", "")),StringUtil.LTrim( ((edtavReembolsodocumentoid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV35ReembolsoDocumentoId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV35ReembolsoDocumentoId), "ZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+""+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavReembolsodocumentoid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavReembolsodocumentoid_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes6M2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_12_idx = ((subGrid_Islastpage==1)&&(nGXsfl_12_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_12_idx+1);
            sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
            SubsflControlProps_122( ) ;
         }
         /* End function sendrow_122 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "SDDOCUMENTOSREEMBOLSOS__REEMBOLSODOCUMENTOSTATUS_" + sGXsfl_12_idx;
         cmbavSddocumentosreembolsos__reembolsodocumentostatus.Name = GXCCtl;
         cmbavSddocumentosreembolsos__reembolsodocumentostatus.WebTags = "";
         cmbavSddocumentosreembolsos__reembolsodocumentostatus.addItem("AGUARDANDO_ANALISE", "Aguardando análise", 0);
         cmbavSddocumentosreembolsos__reembolsodocumentostatus.addItem("APROVADO", "Aprovado", 0);
         cmbavSddocumentosreembolsos__reembolsodocumentostatus.addItem("REPROVADO", "Reprovado", 0);
         if ( cmbavSddocumentosreembolsos__reembolsodocumentostatus.ItemCount > 0 )
         {
            if ( ( AV36GXV1 > 0 ) && ( AV17SdDocumentosReembolsos.Count >= AV36GXV1 ) && String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSdDocumentosReembolso)AV17SdDocumentosReembolsos.Item(AV36GXV1)).gxTpr_Reembolsodocumentostatus)) )
            {
            }
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl12( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"12\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "GridWithBorderColor WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid_Backcolorstyle == 0 )
            {
               subGrid_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid_Class) > 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Title";
               }
            }
            else
            {
               subGrid_Titlebackstyle = 1;
               if ( subGrid_Backcolorstyle == 1 )
               {
                  subGrid_Titlebackcolor = subGrid_Allbackcolor;
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+edtavAnexo_Class+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+edtavDownload_Class+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Documentos Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Documento") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Nome") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Extensão") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Status") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Documento Blob") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Documentos Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Reembolso Documento Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", "GridWithBorderColor WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", sPrefix);
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV19Anexo)));
            GridColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavAnexo_Class));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavAnexo_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV31Download)));
            GridColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavDownload_Class));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDownload_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSddocumentosreembolsos__documentosid_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSddocumentosreembolsos__documentosdescricao_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSddocumentosreembolsos__documentonome_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSddocumentosreembolsos__documentoextensao_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavSddocumentosreembolsos__reembolsodocumentostatus.Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSddocumentosreembolsos__documentoblob_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23DocumentosId), 9, 0, ".", ""))));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDocumentosid_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV35ReembolsoDocumentoId), 9, 0, ".", ""))));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavReembolsodocumentoid_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         edtavAnexo_Internalname = sPrefix+"vANEXO";
         edtavDownload_Internalname = sPrefix+"vDOWNLOAD";
         edtavSddocumentosreembolsos__documentosid_Internalname = sPrefix+"SDDOCUMENTOSREEMBOLSOS__DOCUMENTOSID";
         edtavSddocumentosreembolsos__documentosdescricao_Internalname = sPrefix+"SDDOCUMENTOSREEMBOLSOS__DOCUMENTOSDESCRICAO";
         edtavSddocumentosreembolsos__documentonome_Internalname = sPrefix+"SDDOCUMENTOSREEMBOLSOS__DOCUMENTONOME";
         edtavSddocumentosreembolsos__documentoextensao_Internalname = sPrefix+"SDDOCUMENTOSREEMBOLSOS__DOCUMENTOEXTENSAO";
         cmbavSddocumentosreembolsos__reembolsodocumentostatus_Internalname = sPrefix+"SDDOCUMENTOSREEMBOLSOS__REEMBOLSODOCUMENTOSTATUS";
         edtavSddocumentosreembolsos__documentoblob_Internalname = sPrefix+"SDDOCUMENTOSREEMBOLSOS__DOCUMENTOBLOB";
         edtavDocumentosid_Internalname = sPrefix+"vDOCUMENTOSID";
         edtavReembolsodocumentoid_Internalname = sPrefix+"vREEMBOLSODOCUMENTOID";
         Novajanela_Internalname = sPrefix+"NOVAJANELA";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         Grid_empowerer_Internalname = sPrefix+"GRID_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGrid_Internalname = sPrefix+"GRID";
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
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         edtavReembolsodocumentoid_Jsonclick = "";
         edtavReembolsodocumentoid_Enabled = 1;
         edtavDocumentosid_Jsonclick = "";
         edtavDocumentosid_Enabled = 1;
         edtavSddocumentosreembolsos__documentoblob_Jsonclick = "";
         edtavSddocumentosreembolsos__documentoblob_Parameters = "";
         edtavSddocumentosreembolsos__documentoblob_Contenttype = "";
         edtavSddocumentosreembolsos__documentoblob_Filetype = "";
         edtavSddocumentosreembolsos__documentoblob_Enabled = 0;
         cmbavSddocumentosreembolsos__reembolsodocumentostatus_Jsonclick = "";
         cmbavSddocumentosreembolsos__reembolsodocumentostatus.Enabled = 0;
         edtavSddocumentosreembolsos__documentoextensao_Jsonclick = "";
         edtavSddocumentosreembolsos__documentoextensao_Enabled = 0;
         edtavSddocumentosreembolsos__documentonome_Jsonclick = "";
         edtavSddocumentosreembolsos__documentonome_Enabled = 0;
         edtavSddocumentosreembolsos__documentosdescricao_Jsonclick = "";
         edtavSddocumentosreembolsos__documentosdescricao_Enabled = 0;
         edtavSddocumentosreembolsos__documentosid_Jsonclick = "";
         edtavSddocumentosreembolsos__documentosid_Enabled = 0;
         edtavDownload_Jsonclick = "";
         edtavDownload_Class = "Attribute";
         edtavDownload_Enabled = 1;
         edtavAnexo_Jsonclick = "";
         edtavAnexo_Class = "Attribute";
         edtavAnexo_Enabled = 1;
         subGrid_Class = "GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         Novajanela_Target = "";
         edtavSddocumentosreembolsos__documentoblob_Enabled = -1;
         cmbavSddocumentosreembolsos__reembolsodocumentostatus.Enabled = -1;
         edtavSddocumentosreembolsos__documentoextensao_Enabled = -1;
         edtavSddocumentosreembolsos__documentonome_Enabled = -1;
         edtavSddocumentosreembolsos__documentosdescricao_Enabled = -1;
         edtavSddocumentosreembolsos__documentosid_Enabled = -1;
         subGrid_Rows = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV17SdDocumentosReembolsos","fld":"vSDDOCUMENTOSREEMBOLSOS","grid":12,"type":""},{"av":"nGXsfl_12_idx","ctrl":"GRID","prop":"GridCurrRow","grid":12},{"av":"nRC_GXsfl_12","ctrl":"GRID","prop":"GridRC","grid":12,"type":"int"},{"av":"sPrefix","type":"char"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV45Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E136M2","iparms":[{"av":"AV17SdDocumentosReembolsos","fld":"vSDDOCUMENTOSREEMBOLSOS","grid":12,"type":""},{"av":"nGXsfl_12_idx","ctrl":"GRID","prop":"GridCurrRow","grid":12},{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"nRC_GXsfl_12","ctrl":"GRID","prop":"GridRC","grid":12,"type":"int"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV23DocumentosId","fld":"vDOCUMENTOSID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV35ReembolsoDocumentoId","fld":"vREEMBOLSODOCUMENTOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV19Anexo","fld":"vANEXO","type":"char"},{"av":"edtavAnexo_Class","ctrl":"vANEXO","prop":"Class"},{"av":"AV31Download","fld":"vDOWNLOAD","type":"char"},{"av":"edtavDownload_Class","ctrl":"vDOWNLOAD","prop":"Class"}]}""");
         setEventMetadata("VANEXO.CLICK","""{"handler":"E146M2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV45Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV17SdDocumentosReembolsos","fld":"vSDDOCUMENTOSREEMBOLSOS","grid":12,"type":""},{"av":"nGXsfl_12_idx","ctrl":"GRID","prop":"GridCurrRow","grid":12},{"av":"nRC_GXsfl_12","ctrl":"GRID","prop":"GridRC","grid":12,"type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV23DocumentosId","fld":"vDOCUMENTOSID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("VDOWNLOAD.CLICK","""{"handler":"E156M2","iparms":[{"av":"AV35ReembolsoDocumentoId","fld":"vREEMBOLSODOCUMENTOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A529ReembolsoDocumentoId","fld":"REEMBOLSODOCUMENTOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A531ReembolsoDocumentoBlob","fld":"REEMBOLSODOCUMENTOBLOB","type":"bitstr"},{"av":"A530ReembolsoDocumentoNome","fld":"REEMBOLSODOCUMENTONOME","type":"svchar"},{"av":"A532ReembolsoDocumentoBlobExt","fld":"REEMBOLSODOCUMENTOBLOBEXT","type":"svchar"},{"av":"AV17SdDocumentosReembolsos","fld":"vSDDOCUMENTOSREEMBOLSOS","grid":12,"type":""},{"av":"nGXsfl_12_idx","ctrl":"GRID","prop":"GridCurrRow","grid":12},{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"nRC_GXsfl_12","ctrl":"GRID","prop":"GridRC","grid":12,"type":"int"},{"av":"AV23DocumentosId","fld":"vDOCUMENTOSID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("VDOWNLOAD.CLICK",""","oparms":[{"av":"Novajanela_Target","ctrl":"NOVAJANELA","prop":"Target"}]}""");
         setEventMetadata("GRID_FIRSTPAGE","""{"handler":"subgrid_firstpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV17SdDocumentosReembolsos","fld":"vSDDOCUMENTOSREEMBOLSOS","grid":12,"type":""},{"av":"nGXsfl_12_idx","ctrl":"GRID","prop":"GridCurrRow","grid":12},{"av":"nRC_GXsfl_12","ctrl":"GRID","prop":"GridRC","grid":12,"type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV45Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("GRID_PREVPAGE","""{"handler":"subgrid_previouspage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV17SdDocumentosReembolsos","fld":"vSDDOCUMENTOSREEMBOLSOS","grid":12,"type":""},{"av":"nGXsfl_12_idx","ctrl":"GRID","prop":"GridCurrRow","grid":12},{"av":"nRC_GXsfl_12","ctrl":"GRID","prop":"GridRC","grid":12,"type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV45Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("GRID_NEXTPAGE","""{"handler":"subgrid_nextpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV17SdDocumentosReembolsos","fld":"vSDDOCUMENTOSREEMBOLSOS","grid":12,"type":""},{"av":"nGXsfl_12_idx","ctrl":"GRID","prop":"GridCurrRow","grid":12},{"av":"nRC_GXsfl_12","ctrl":"GRID","prop":"GridRC","grid":12,"type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV45Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("GRID_LASTPAGE","""{"handler":"subgrid_lastpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV17SdDocumentosReembolsos","fld":"vSDDOCUMENTOSREEMBOLSOS","grid":12,"type":""},{"av":"nGXsfl_12_idx","ctrl":"GRID","prop":"GridCurrRow","grid":12},{"av":"nRC_GXsfl_12","ctrl":"GRID","prop":"GridRC","grid":12,"type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV45Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("VALIDV_GXV6","""{"handler":"Validv_Gxv6","iparms":[]}""");
         setEventMetadata("VALIDV_REEMBOLSODOCUMENTOID","""{"handler":"Validv_Reembolsodocumentoid","iparms":[]}""");
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
         wcpOAV28JSON = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV45Pgmname = "";
         AV17SdDocumentosReembolsos = new GXBaseCollection<SdtSdDocumentosReembolso>( context, "SdDocumentosReembolso", "Factory21");
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV27InNome = "";
         AV26InExtensao = "";
         AV25InBlob = "";
         A531ReembolsoDocumentoBlob = "";
         A530ReembolsoDocumentoNome = "";
         A532ReembolsoDocumentoBlobExt = "";
         AV18SdDocumentosReembolso = new SdtSdDocumentosReembolso(context);
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucNovajanela = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV19Anexo = "";
         AV31Download = "";
         GXDecQS = "";
         AV29Array_SdDocumentosReembolso = new GXBaseCollection<SdtSdDocumentosReembolso>( context, "SdDocumentosReembolso", "Factory21");
         H006M2_A536DocumentoObrigatorioReembolso = new bool[] {false} ;
         H006M2_n536DocumentoObrigatorioReembolso = new bool[] {false} ;
         H006M2_A407DocumentosStatus = new bool[] {false} ;
         H006M2_n407DocumentosStatus = new bool[] {false} ;
         H006M2_A405DocumentosId = new int[1] ;
         H006M2_A406DocumentosDescricao = new string[] {""} ;
         H006M2_n406DocumentosDescricao = new bool[] {false} ;
         A406DocumentosDescricao = "";
         AV30AuxSdDocumentosReembolso = new SdtSdDocumentosReembolso(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV13Session = context.GetSession();
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         H006M3_A529ReembolsoDocumentoId = new int[1] ;
         H006M3_A530ReembolsoDocumentoNome = new string[] {""} ;
         H006M3_n530ReembolsoDocumentoNome = new bool[] {false} ;
         H006M3_A532ReembolsoDocumentoBlobExt = new string[] {""} ;
         H006M3_n532ReembolsoDocumentoBlobExt = new bool[] {false} ;
         H006M3_A531ReembolsoDocumentoBlob = new string[] {""} ;
         H006M3_n531ReembolsoDocumentoBlob = new bool[] {false} ;
         AV34Arquivo = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV28JSON = "";
         subGrid_Linesclass = "";
         TempTags = "";
         ROClassString = "";
         GXCCtl = "";
         gxblobfileaux = new GxFile(context.GetPhysicalPath());
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wcdocumentosobrigatoriosreembolso__default(),
            new Object[][] {
                new Object[] {
               H006M2_A536DocumentoObrigatorioReembolso, H006M2_n536DocumentoObrigatorioReembolso, H006M2_A407DocumentosStatus, H006M2_n407DocumentosStatus, H006M2_A405DocumentosId, H006M2_A406DocumentosDescricao, H006M2_n406DocumentosDescricao
               }
               , new Object[] {
               H006M3_A529ReembolsoDocumentoId, H006M3_A530ReembolsoDocumentoNome, H006M3_n530ReembolsoDocumentoNome, H006M3_A532ReembolsoDocumentoBlobExt, H006M3_n532ReembolsoDocumentoBlobExt, H006M3_A531ReembolsoDocumentoBlob, H006M3_n531ReembolsoDocumentoBlob
               }
            }
         );
         AV45Pgmname = "WcDocumentosObrigatoriosReembolso";
         /* GeneXus formulas. */
         AV45Pgmname = "WcDocumentosObrigatoriosReembolso";
         edtavAnexo_Enabled = 0;
         edtavDownload_Enabled = 0;
         edtavSddocumentosreembolsos__documentosid_Enabled = 0;
         edtavSddocumentosreembolsos__documentosdescricao_Enabled = 0;
         edtavSddocumentosreembolsos__documentonome_Enabled = 0;
         edtavSddocumentosreembolsos__documentoextensao_Enabled = 0;
         cmbavSddocumentosreembolsos__reembolsodocumentostatus.Enabled = 0;
         edtavSddocumentosreembolsos__documentoblob_Enabled = 0;
         edtavDocumentosid_Enabled = 0;
         edtavReembolsodocumentoid_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short gxcookieaux ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int nRC_GXsfl_12 ;
      private int nGXsfl_12_idx=1 ;
      private int edtavAnexo_Enabled ;
      private int edtavDownload_Enabled ;
      private int edtavSddocumentosreembolsos__documentosid_Enabled ;
      private int edtavSddocumentosreembolsos__documentosdescricao_Enabled ;
      private int edtavSddocumentosreembolsos__documentonome_Enabled ;
      private int edtavSddocumentosreembolsos__documentoextensao_Enabled ;
      private int edtavSddocumentosreembolsos__documentoblob_Enabled ;
      private int edtavDocumentosid_Enabled ;
      private int edtavReembolsodocumentoid_Enabled ;
      private int AV24InDocumentosId ;
      private int A529ReembolsoDocumentoId ;
      private int AV46GXV9 ;
      private int AV36GXV1 ;
      private int AV23DocumentosId ;
      private int AV35ReembolsoDocumentoId ;
      private int subGrid_Islastpage ;
      private int GRID_nGridOutOfScope ;
      private int nGXsfl_12_fel_idx=1 ;
      private int A405DocumentosId ;
      private int AV44GXV8 ;
      private int AV48GXV10 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_12_idx="0001" ;
      private string AV45Pgmname ;
      private string edtavAnexo_Internalname ;
      private string edtavDownload_Internalname ;
      private string edtavSddocumentosreembolsos__documentosid_Internalname ;
      private string edtavSddocumentosreembolsos__documentosdescricao_Internalname ;
      private string edtavSddocumentosreembolsos__documentonome_Internalname ;
      private string edtavSddocumentosreembolsos__documentoextensao_Internalname ;
      private string cmbavSddocumentosreembolsos__reembolsodocumentostatus_Internalname ;
      private string edtavSddocumentosreembolsos__documentoblob_Internalname ;
      private string edtavDocumentosid_Internalname ;
      private string edtavReembolsodocumentoid_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Novajanela_Target ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Novajanela_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV19Anexo ;
      private string AV31Download ;
      private string GXDecQS ;
      private string sGXsfl_12_fel_idx="0001" ;
      private string edtavAnexo_Class ;
      private string edtavDownload_Class ;
      private string sCtrlAV28JSON ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string TempTags ;
      private string ROClassString ;
      private string edtavAnexo_Jsonclick ;
      private string edtavDownload_Jsonclick ;
      private string edtavSddocumentosreembolsos__documentosid_Jsonclick ;
      private string edtavSddocumentosreembolsos__documentosdescricao_Jsonclick ;
      private string edtavSddocumentosreembolsos__documentonome_Jsonclick ;
      private string edtavSddocumentosreembolsos__documentoextensao_Jsonclick ;
      private string GXCCtl ;
      private string cmbavSddocumentosreembolsos__reembolsodocumentostatus_Jsonclick ;
      private string edtavSddocumentosreembolsos__documentoblob_Filetype ;
      private string edtavSddocumentosreembolsos__documentoblob_Contenttype ;
      private string edtavSddocumentosreembolsos__documentoblob_Parameters ;
      private string edtavSddocumentosreembolsos__documentoblob_Jsonclick ;
      private string edtavDocumentosid_Jsonclick ;
      private string edtavReembolsodocumentoid_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_12_Refreshing=false ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_BV12 ;
      private bool A536DocumentoObrigatorioReembolso ;
      private bool n536DocumentoObrigatorioReembolso ;
      private bool A407DocumentosStatus ;
      private bool n407DocumentosStatus ;
      private bool n406DocumentosDescricao ;
      private bool gx_refresh_fired ;
      private bool n530ReembolsoDocumentoNome ;
      private bool n532ReembolsoDocumentoBlobExt ;
      private bool n531ReembolsoDocumentoBlob ;
      private string AV28JSON ;
      private string wcpOAV28JSON ;
      private string AV27InNome ;
      private string AV26InExtensao ;
      private string A530ReembolsoDocumentoNome ;
      private string A532ReembolsoDocumentoBlobExt ;
      private string A406DocumentosDescricao ;
      private string AV34Arquivo ;
      private string AV25InBlob ;
      private string A531ReembolsoDocumentoBlob ;
      private IGxSession AV13Session ;
      private GxFile gxblobfileaux ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucNovajanela ;
      private GXUserControl ucGrid_empowerer ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavSddocumentosreembolsos__reembolsodocumentostatus ;
      private GXBaseCollection<SdtSdDocumentosReembolso> AV17SdDocumentosReembolsos ;
      private SdtSdDocumentosReembolso AV18SdDocumentosReembolso ;
      private GXBaseCollection<SdtSdDocumentosReembolso> AV29Array_SdDocumentosReembolso ;
      private IDataStoreProvider pr_default ;
      private bool[] H006M2_A536DocumentoObrigatorioReembolso ;
      private bool[] H006M2_n536DocumentoObrigatorioReembolso ;
      private bool[] H006M2_A407DocumentosStatus ;
      private bool[] H006M2_n407DocumentosStatus ;
      private int[] H006M2_A405DocumentosId ;
      private string[] H006M2_A406DocumentosDescricao ;
      private bool[] H006M2_n406DocumentosDescricao ;
      private SdtSdDocumentosReembolso AV30AuxSdDocumentosReembolso ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private int[] H006M3_A529ReembolsoDocumentoId ;
      private string[] H006M3_A530ReembolsoDocumentoNome ;
      private bool[] H006M3_n530ReembolsoDocumentoNome ;
      private string[] H006M3_A532ReembolsoDocumentoBlobExt ;
      private bool[] H006M3_n532ReembolsoDocumentoBlobExt ;
      private string[] H006M3_A531ReembolsoDocumentoBlob ;
      private bool[] H006M3_n531ReembolsoDocumentoBlob ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wcdocumentosobrigatoriosreembolso__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH006M2;
          prmH006M2 = new Object[] {
          };
          Object[] prmH006M3;
          prmH006M3 = new Object[] {
          new ParDef("AV35ReembolsoDocumentoId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("H006M2", "SELECT DocumentoObrigatorioReembolso, DocumentosStatus, DocumentosId, DocumentosDescricao FROM Documentos WHERE (DocumentosStatus) AND (DocumentoObrigatorioReembolso) ORDER BY DocumentosId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006M2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H006M3", "SELECT ReembolsoDocumentoId, ReembolsoDocumentoNome, ReembolsoDocumentoBlobExt, ReembolsoDocumentoBlob FROM ReembolsoDocumento WHERE ReembolsoDocumentoId = :AV35ReembolsoDocumentoId ORDER BY ReembolsoDocumentoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006M3,1, GxCacheFrequency.OFF ,true,true )
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
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getBLOBFile(4, "tmp", "");
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
       }
    }

 }

}
