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
   public class wpalterarproposta : GXDataArea
   {
      public wpalterarproposta( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpalterarproposta( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_PropostaId )
      {
         this.AV5PropostaId = aP0_PropostaId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavClientepixtipo = new GXCombobox();
         cmbavConveniovencimentoano = new GXCombobox();
         cmbavConveniovencimentomes = new GXCombobox();
         cmbavDocumentoobrigatorio = new GXCombobox();
         cmbavPropostadocumentosstatus = new GXCombobox();
         chkavPropostadocumentosadm = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "PropostaId");
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
               gxfirstwebparm = GetFirstPar( "PropostaId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "PropostaId");
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
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGriddocumentos_newrow_invoke( )
      {
         nRC_GXsfl_167 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_167"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_167_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_167_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_167_idx = GetPar( "sGXsfl_167_idx");
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
         AV66Aprovados = (short)(Math.Round(NumberUtil.Val( GetPar( "Aprovados"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV67Context);
         AV68PropostaStatus = GetPar( "PropostaStatus");
         A323PropostaId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaId"), "."), 18, MidpointRounding.ToEven));
         n323PropostaId = false;
         AV5PropostaId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaId"), "."), 18, MidpointRounding.ToEven));
         A415PropostaDocumentosAnexo = GetPar( "PropostaDocumentosAnexo");
         n415PropostaDocumentosAnexo = false;
         A406DocumentosDescricao = GetPar( "DocumentosDescricao");
         n406DocumentosDescricao = false;
         A405DocumentosId = (int)(Math.Round(NumberUtil.Val( GetPar( "DocumentosId"), "."), 18, MidpointRounding.ToEven));
         n405DocumentosId = false;
         A417PropostaDocumentosAnexoFileType = GetPar( "PropostaDocumentosAnexoFileType");
         n417PropostaDocumentosAnexoFileType = false;
         A579PropostaDocumentosStatus = GetPar( "PropostaDocumentosStatus");
         n579PropostaDocumentosStatus = false;
         A416PropostaDocumentosAnexoName = GetPar( "PropostaDocumentosAnexoName");
         n416PropostaDocumentosAnexoName = false;
         A414PropostaDocumentosId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaDocumentosId"), "."), 18, MidpointRounding.ToEven));
         A651PropostaDocumentosAdm = StringUtil.StrToBool( GetPar( "PropostaDocumentosAdm"));
         n651PropostaDocumentosAdm = false;
         AV46PropostaPacienteClienteId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaPacienteClienteId"), "."), 18, MidpointRounding.ToEven));
         AV71PropostaComentarioAnalise = GetPar( "PropostaComentarioAnalise");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGriddocumentos_refresh( subGriddocumentos_Rows, AV66Aprovados, AV67Context, AV68PropostaStatus, A323PropostaId, AV5PropostaId, A415PropostaDocumentosAnexo, A406DocumentosDescricao, A405DocumentosId, A417PropostaDocumentosAnexoFileType, A579PropostaDocumentosStatus, A416PropostaDocumentosAnexoName, A414PropostaDocumentosId, A651PropostaDocumentosAdm, AV46PropostaPacienteClienteId, AV71PropostaComentarioAnalise) ;
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
         PA7U2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START7U2( ) ;
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
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
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
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wpalterarproposta"+UrlEncode(StringUtil.LTrimStr(AV5PropostaId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpalterarproposta") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vAPROVADOS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV66Aprovados), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vAPROVADOS", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV66Aprovados), "ZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCONTEXT", AV67Context);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCONTEXT", AV67Context);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vCONTEXT", GetSecureSignedToken( "", AV67Context, context));
         GxWebStd.gx_hidden_field( context, "vPROPOSTASTATUS", AV68PropostaStatus);
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTASTATUS", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV68PropostaStatus, "")), context));
         GxWebStd.gx_hidden_field( context, "vPROPOSTAPACIENTECLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV46PropostaPacienteClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAPACIENTECLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV46PropostaPacienteClienteId), "ZZZZZZZZ9"), context));
         GXKey = Crypto.GetSiteKey( );
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"WpAlterarProposta");
         forbiddenHiddens.Add("PropostaComentarioAnalise", StringUtil.RTrim( context.localUtil.Format( AV71PropostaComentarioAnalise, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("wpalterarproposta:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_167", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_167), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPROPOSTARESPONSAVELID_DATA", AV72PropostaResponsavelId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPROPOSTARESPONSAVELID_DATA", AV72PropostaResponsavelId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPROCEDIMENTOSMEDICOSID_DATA", AV31ProcedimentosMedicosId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPROCEDIMENTOSMEDICOSID_DATA", AV31ProcedimentosMedicosId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCONVENIOID_DATA", AV33ConvenioId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCONVENIOID_DATA", AV33ConvenioId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCONVENIOCATEGORIAID_DATA", AV34ConvenioCategoriaId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCONVENIOCATEGORIAID_DATA", AV34ConvenioCategoriaId_Data);
         }
         GxWebStd.gx_hidden_field( context, "vAPROVADOS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV66Aprovados), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vAPROVADOS", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV66Aprovados), "ZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCONTEXT", AV67Context);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCONTEXT", AV67Context);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vCONTEXT", GetSecureSignedToken( "", AV67Context, context));
         GxWebStd.gx_hidden_field( context, "vPROPOSTASTATUS", AV68PropostaStatus);
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTASTATUS", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV68PropostaStatus, "")), context));
         GxWebStd.gx_hidden_field( context, "PROPOSTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPROPOSTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5PropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "PROPOSTADOCUMENTOSANEXO", A415PropostaDocumentosAnexo);
         GxWebStd.gx_hidden_field( context, "DOCUMENTOSDESCRICAO", A406DocumentosDescricao);
         GxWebStd.gx_hidden_field( context, "DOCUMENTOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A405DocumentosId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "PROPOSTADOCUMENTOSANEXOFILETYPE", A417PropostaDocumentosAnexoFileType);
         GxWebStd.gx_hidden_field( context, "PROPOSTADOCUMENTOSSTATUS", A579PropostaDocumentosStatus);
         GxWebStd.gx_hidden_field( context, "PROPOSTADOCUMENTOSANEXONAME", A416PropostaDocumentosAnexoName);
         GxWebStd.gx_hidden_field( context, "PROPOSTADOCUMENTOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A414PropostaDocumentosId), 9, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "PROPOSTADOCUMENTOSADM", A651PropostaDocumentosAdm);
         GxWebStd.gx_hidden_field( context, "vPROPOSTAPACIENTECLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV46PropostaPacienteClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAPACIENTECLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV46PropostaPacienteClienteId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "CLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CONVENIOCATEGORIADESCRICAO", A494ConvenioCategoriaDescricao);
         GxWebStd.gx_boolean_hidden_field( context, "CONVENIOCATEGORIASTATUS", A495ConvenioCategoriaStatus);
         GxWebStd.gx_hidden_field( context, "CONVENIOCATEGORIAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A493ConvenioCategoriaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CONVENIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A410ConvenioId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRIDDOCUMENTOS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDDOCUMENTOS_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRIDDOCUMENTOS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDDOCUMENTOS_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "subGriddocumentos_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddocumentos_Recordcount), 5, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRIDDOCUMENTOS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddocumentos_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMBO_PROPOSTARESPONSAVELID_Cls", StringUtil.RTrim( Combo_propostaresponsavelid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_PROPOSTARESPONSAVELID_Selectedvalue_set", StringUtil.RTrim( Combo_propostaresponsavelid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PROPOSTARESPONSAVELID_Emptyitem", StringUtil.BoolToStr( Combo_propostaresponsavelid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_PROPOSTARESPONSAVELID_Htmltemplate", StringUtil.RTrim( Combo_propostaresponsavelid_Htmltemplate));
         GxWebStd.gx_hidden_field( context, "COMBO_PROCEDIMENTOSMEDICOSID_Cls", StringUtil.RTrim( Combo_procedimentosmedicosid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_PROCEDIMENTOSMEDICOSID_Selectedvalue_set", StringUtil.RTrim( Combo_procedimentosmedicosid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PROCEDIMENTOSMEDICOSID_Enabled", StringUtil.BoolToStr( Combo_procedimentosmedicosid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_PROCEDIMENTOSMEDICOSID_Emptyitem", StringUtil.BoolToStr( Combo_procedimentosmedicosid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_CONVENIOID_Cls", StringUtil.RTrim( Combo_convenioid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_CONVENIOID_Selectedvalue_set", StringUtil.RTrim( Combo_convenioid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CONVENIOID_Enabled", StringUtil.BoolToStr( Combo_convenioid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_CONVENIOID_Emptyitem", StringUtil.BoolToStr( Combo_convenioid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_CONVENIOCATEGORIAID_Cls", StringUtil.RTrim( Combo_conveniocategoriaid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_CONVENIOCATEGORIAID_Selectedvalue_set", StringUtil.RTrim( Combo_conveniocategoriaid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CONVENIOCATEGORIAID_Enabled", StringUtil.BoolToStr( Combo_conveniocategoriaid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_CONVENIOCATEGORIAID_Emptyitem", StringUtil.BoolToStr( Combo_conveniocategoriaid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS1_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gxuitabspanel_tabs1_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS1_Class", StringUtil.RTrim( Gxuitabspanel_tabs1_Class));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS1_Historymanagement", StringUtil.BoolToStr( Gxuitabspanel_tabs1_Historymanagement));
         GxWebStd.gx_hidden_field( context, "NOVAJANELA_Target", StringUtil.RTrim( Novajanela_Target));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_APROVAR_PROPOSTA_Title", StringUtil.RTrim( Dvelop_confirmpanel_aprovar_proposta_Title));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_APROVAR_PROPOSTA_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_aprovar_proposta_Confirmationtext));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_APROVAR_PROPOSTA_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_aprovar_proposta_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_APROVAR_PROPOSTA_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_aprovar_proposta_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_APROVAR_PROPOSTA_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_aprovar_proposta_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_APROVAR_PROPOSTA_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_aprovar_proposta_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_APROVAR_PROPOSTA_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_aprovar_proposta_Confirmtype));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_APROVAR_PROPOSTA_Comment", StringUtil.RTrim( Dvelop_confirmpanel_aprovar_proposta_Comment));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_APROVAR_PROPOSTA_Bodycontentinternalname", StringUtil.RTrim( Dvelop_confirmpanel_aprovar_proposta_Bodycontentinternalname));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_FINALIZAR_ANALISE_Title", StringUtil.RTrim( Dvelop_confirmpanel_finalizar_analise_Title));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_FINALIZAR_ANALISE_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_finalizar_analise_Confirmationtext));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_FINALIZAR_ANALISE_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_finalizar_analise_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_FINALIZAR_ANALISE_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_finalizar_analise_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_FINALIZAR_ANALISE_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_finalizar_analise_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_FINALIZAR_ANALISE_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_finalizar_analise_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_FINALIZAR_ANALISE_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_finalizar_analise_Confirmtype));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_FINALIZAR_ANALISE_Comment", StringUtil.RTrim( Dvelop_confirmpanel_finalizar_analise_Comment));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_FINALIZAR_ANALISE_Bodycontentinternalname", StringUtil.RTrim( Dvelop_confirmpanel_finalizar_analise_Bodycontentinternalname));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_EXCLUIR_Title", StringUtil.RTrim( Dvelop_confirmpanel_excluir_Title));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_EXCLUIR_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_excluir_Confirmationtext));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_EXCLUIR_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_excluir_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_EXCLUIR_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_excluir_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_EXCLUIR_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_excluir_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_EXCLUIR_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_excluir_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_EXCLUIR_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_excluir_Confirmtype));
         GxWebStd.gx_hidden_field( context, "GRIDDOCUMENTOS_EMPOWERER_Gridinternalname", StringUtil.RTrim( Griddocumentos_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_APROVAR_PROPOSTA_Result", StringUtil.RTrim( Dvelop_confirmpanel_aprovar_proposta_Result));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_FINALIZAR_ANALISE_Result", StringUtil.RTrim( Dvelop_confirmpanel_finalizar_analise_Result));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_EXCLUIR_Result", StringUtil.RTrim( Dvelop_confirmpanel_excluir_Result));
         GxWebStd.gx_hidden_field( context, "COMBO_CONVENIOCATEGORIAID_Selectedvalue_get", StringUtil.RTrim( Combo_conveniocategoriaid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_CONVENIOID_Selectedvalue_get", StringUtil.RTrim( Combo_convenioid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_PROCEDIMENTOSMEDICOSID_Selectedvalue_get", StringUtil.RTrim( Combo_procedimentosmedicosid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_PROPOSTARESPONSAVELID_Selectedvalue_get", StringUtil.RTrim( Combo_propostaresponsavelid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_APROVAR_PROPOSTA_Result", StringUtil.RTrim( Dvelop_confirmpanel_aprovar_proposta_Result));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_FINALIZAR_ANALISE_Result", StringUtil.RTrim( Dvelop_confirmpanel_finalizar_analise_Result));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_EXCLUIR_Result", StringUtil.RTrim( Dvelop_confirmpanel_excluir_Result));
         GxWebStd.gx_hidden_field( context, "COMBO_CONVENIOID_Selectedvalue_get", StringUtil.RTrim( Combo_convenioid_Selectedvalue_get));
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
         if ( ! ( WebComp_Wcserasaww == null ) )
         {
            WebComp_Wcserasaww.componentjscripts();
         }
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE7U2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT7U2( ) ;
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
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wpalterarproposta"+UrlEncode(StringUtil.LTrimStr(AV5PropostaId,9,0));
         return formatLink("wpalterarproposta") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WpAlterarProposta" ;
      }

      public override string GetPgmdesc( )
      {
         return "Proposta" ;
      }

      protected void WB7U0( )
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
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnaprovar_proposta_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(167), 3, 0)+","+"null"+");", "Aprovar proposta", bttBtnaprovar_proposta_Jsonclick, 7, "Aprovar proposta", "", StyleString, ClassString, bttBtnaprovar_proposta_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"e117u1_client"+"'", TempTags, "", 2, "HLP_WpAlterarProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnfinalizar_analise_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(167), 3, 0)+","+"null"+");", "Finalizar análise", bttBtnfinalizar_analise_Jsonclick, 7, "Finalizar análise", "", StyleString, ClassString, bttBtnfinalizar_analise_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"e127u1_client"+"'", TempTags, "", 2, "HLP_WpAlterarProposta.htm");
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
            ucGxuitabspanel_tabs1.Render(context, "tab", Gxuitabspanel_tabs1_Internalname, "GXUITABSPANEL_TABS1Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"title1"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTab_title_Internalname, "Informações", "", "", lblTab_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WpAlterarProposta.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Tab") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"panel1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divPropostacomentarioanalise_cell_Internalname, 1, 0, "px", 0, "px", divPropostacomentarioanalise_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavPropostacomentarioanalise_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPropostacomentarioanalise_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostacomentarioanalise_Internalname, "Comentário análise", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'" + sGXsfl_167_idx + "',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavPropostacomentarioanalise_Internalname, AV71PropostaComentarioAnalise, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", 0, edtavPropostacomentarioanalise_Visible, edtavPropostacomentarioanalise_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WpAlterarProposta.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(167), 3, 0)+","+"null"+");", "Confirmar", bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpAlterarProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(167), 3, 0)+","+"null"+");", "Fechar", bttBtncancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpAlterarProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecliente_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblConsultarcliente_Internalname, "<i class=\"fas fa-magnifying-glass\"></i>", "", "", lblConsultarcliente_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOCONSULTARCLIENTE\\'."+"'", "", "TextBlock", 5, "", 1, 1, 0, 1, "HLP_WpAlterarProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavClienterazaosocial_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClienterazaosocial_Internalname, "Nome", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'" + sGXsfl_167_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClienterazaosocial_Internalname, AV26ClienteRazaoSocial, StringUtil.RTrim( context.localUtil.Format( AV26ClienteRazaoSocial, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,50);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClienterazaosocial_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavClienterazaosocial_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpAlterarProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavClientedocumento_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientedocumento_Internalname, "Documento", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'" + sGXsfl_167_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientedocumento_Internalname, AV27ClienteDocumento, StringUtil.RTrim( context.localUtil.Format( AV27ClienteDocumento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientedocumento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavClientedocumento_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpAlterarProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavContatoemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContatoemail_Internalname, "E-mail", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'" + sGXsfl_167_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContatoemail_Internalname, AV28ContatoEmail, StringUtil.RTrim( context.localUtil.Format( AV28ContatoEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContatoemail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavContatoemail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WpAlterarProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontentresponsavel_Internalname, divTablecontentresponsavel_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedpropostaresponsavelid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_propostaresponsavelid_Internalname, "Responsável financeiro", "", "", lblTextblockcombo_propostaresponsavelid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WpAlterarProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            wb_table1_69_7U2( true) ;
         }
         else
         {
            wb_table1_69_7U2( false) ;
         }
         return  ;
      }

      protected void wb_table1_69_7U2e( bool wbgen )
      {
         if ( wbgen )
         {
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableconta_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablebanco_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavBanconome_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavBanconome_Internalname, "Banco", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'" + sGXsfl_167_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavBanconome_Internalname, AV42BancoNome, StringUtil.RTrim( context.localUtil.Format( AV42BancoNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,86);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavBanconome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavBanconome_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpAlterarProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavContaagencia_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContaagencia_Internalname, "Agência", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'" + sGXsfl_167_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContaagencia_Internalname, AV21ContaAgencia, StringUtil.RTrim( context.localUtil.Format( AV21ContaAgencia, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,90);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContaagencia_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavContaagencia_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpAlterarProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavContanumero_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContanumero_Internalname, "Número", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'" + sGXsfl_167_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContanumero_Internalname, AV22ContaNumero, StringUtil.RTrim( context.localUtil.Format( AV22ContaNumero, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,95);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContanumero_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavContanumero_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpAlterarProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablepix_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavClientepixtipo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavClientepixtipo_Internalname, "Tipo da chave pix", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'" + sGXsfl_167_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavClientepixtipo, cmbavClientepixtipo_Internalname, StringUtil.RTrim( AV18ClientePixTipo), 1, cmbavClientepixtipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavClientepixtipo.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,102);\"", "", true, 0, "HLP_WpAlterarProposta.htm");
            cmbavClientepixtipo.CurrentValue = StringUtil.RTrim( AV18ClientePixTipo);
            AssignProp("", false, cmbavClientepixtipo_Internalname, "Values", (string)(cmbavClientepixtipo.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavClientepix_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientepix_Internalname, "Chave pix", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'" + sGXsfl_167_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientepix_Internalname, AV19ClientePix, StringUtil.RTrim( context.localUtil.Format( AV19ClientePix, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,106);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientepix_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavClientepix_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpAlterarProposta.htm");
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
            GxWebStd.gx_div_start( context, divTableproposta_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedprocedimentosmedicosid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_procedimentosmedicosid_Internalname, "Procedimento", "", "", lblTextblockcombo_procedimentosmedicosid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WpAlterarProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_procedimentosmedicosid.SetProperty("Caption", Combo_procedimentosmedicosid_Caption);
            ucCombo_procedimentosmedicosid.SetProperty("Cls", Combo_procedimentosmedicosid_Cls);
            ucCombo_procedimentosmedicosid.SetProperty("EmptyItem", Combo_procedimentosmedicosid_Emptyitem);
            ucCombo_procedimentosmedicosid.SetProperty("DropDownOptionsData", AV31ProcedimentosMedicosId_Data);
            ucCombo_procedimentosmedicosid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_procedimentosmedicosid_Internalname, "COMBO_PROCEDIMENTOSMEDICOSIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPropostavalor_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostavalor_Internalname, "Valor", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'',false,'" + sGXsfl_167_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostavalor_Internalname, StringUtil.LTrim( StringUtil.NToC( AV12PropostaValor, 18, 2, ",", "")), StringUtil.LTrim( context.localUtil.Format( AV12PropostaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99")), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,121);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostavalor_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavPropostavalor_Enabled, 1, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpAlterarProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPropostadescricao_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostadescricao_Internalname, "Descrição", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'',false,'" + sGXsfl_167_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostadescricao_Internalname, AV13PropostaDescricao, StringUtil.RTrim( context.localUtil.Format( AV13PropostaDescricao, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,126);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostadescricao_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavPropostadescricao_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpAlterarProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedconvenioid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_convenioid_Internalname, "Convênio", "", "", lblTextblockcombo_convenioid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WpAlterarProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_convenioid.SetProperty("Caption", Combo_convenioid_Caption);
            ucCombo_convenioid.SetProperty("Cls", Combo_convenioid_Cls);
            ucCombo_convenioid.SetProperty("EmptyItem", Combo_convenioid_Emptyitem);
            ucCombo_convenioid.SetProperty("DropDownOptionsData", AV33ConvenioId_Data);
            ucCombo_convenioid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_convenioid_Internalname, "COMBO_CONVENIOIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedconveniocategoriaid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_conveniocategoriaid_Internalname, "Categoria do convênio", "", "", lblTextblockcombo_conveniocategoriaid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WpAlterarProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_conveniocategoriaid.SetProperty("Caption", Combo_conveniocategoriaid_Caption);
            ucCombo_conveniocategoriaid.SetProperty("Cls", Combo_conveniocategoriaid_Cls);
            ucCombo_conveniocategoriaid.SetProperty("EmptyItem", Combo_conveniocategoriaid_Emptyitem);
            ucCombo_conveniocategoriaid.SetProperty("DropDownOptionsData", AV34ConvenioCategoriaId_Data);
            ucCombo_conveniocategoriaid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_conveniocategoriaid_Internalname, "COMBO_CONVENIOCATEGORIAIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedconveniovencimentoano_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockconveniovencimentoano_Internalname, "Ano vencimento carteira", "", "", lblTextblockconveniovencimentoano_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WpAlterarProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            wb_table2_149_7U2( true) ;
         }
         else
         {
            wb_table2_149_7U2( false) ;
         }
         return  ;
      }

      protected void wb_table2_149_7U2e( bool wbgen )
      {
         if ( wbgen )
         {
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
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup3_Internalname, "Documentos", 1, 0, "px", 0, "px", "Group", "", "HLP_WpAlterarProposta.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledocumentos_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 164,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnnovodocumento_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(167), 3, 0)+","+"null"+");", "Novo documento", bttBtnnovodocumento_Jsonclick, 5, "Novo documento", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DONOVODOCUMENTO\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpAlterarProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 HasGridEmpowerer", "start", "top", "", "", "div");
            /*  Grid Control  */
            GriddocumentosContainer.SetWrapped(nGXWrapped);
            StartGridControl167( ) ;
         }
         if ( wbEnd == 167 )
         {
            wbEnd = 0;
            nRC_GXsfl_167 = (int)(nGXsfl_167_idx-1);
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
               context.WriteHtmlText( "<div id=\""+"GriddocumentosContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Griddocumentos", GriddocumentosContainer, subGriddocumentos_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GriddocumentosContainerData", GriddocumentosContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GriddocumentosContainerData"+"V", GriddocumentosContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GriddocumentosContainerData"+"V"+"\" value='"+GriddocumentosContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"title2"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSerasa_title_Internalname, "Serasa", "", "", lblSerasa_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WpAlterarProposta.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Serasa") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"panel2"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0188"+"", StringUtil.RTrim( WebComp_Wcserasaww_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0188"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_167_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wcserasaww_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWcserasaww), StringUtil.Lower( WebComp_Wcserasaww_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0188"+"");
                     }
                     WebComp_Wcserasaww.componentdraw();
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWcserasaww), StringUtil.Lower( WebComp_Wcserasaww_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspEndCmp();
                     }
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
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
            /* User Defined Control */
            ucNovajanela.Render(context, "innewwindow", Novajanela_Internalname, "NOVAJANELAContainer");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 195,'',false,'" + sGXsfl_167_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostaresponsavelid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV47PropostaResponsavelId), 9, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV47PropostaResponsavelId), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,195);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostaresponsavelid_Jsonclick, 0, "Attribute", "", "", "", "", edtavPropostaresponsavelid_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpAlterarProposta.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 196,'',false,'" + sGXsfl_167_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProcedimentosmedicosid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11ProcedimentosMedicosId), 9, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV11ProcedimentosMedicosId), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,196);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProcedimentosmedicosid_Jsonclick, 0, "Attribute", "", "", "", "", edtavProcedimentosmedicosid_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpAlterarProposta.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 197,'',false,'" + sGXsfl_167_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConvenioid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14ConvenioId), 9, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV14ConvenioId), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,197);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConvenioid_Jsonclick, 0, "Attribute", "", "", "", "", edtavConvenioid_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpAlterarProposta.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 198,'',false,'" + sGXsfl_167_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConveniocategoriaid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15ConvenioCategoriaId), 9, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV15ConvenioCategoriaId), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,198);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConveniocategoriaid_Jsonclick, 0, "Attribute", "", "", "", "", edtavConveniocategoriaid_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpAlterarProposta.htm");
            wb_table3_199_7U2( true) ;
         }
         else
         {
            wb_table3_199_7U2( false) ;
         }
         return  ;
      }

      protected void wb_table3_199_7U2e( bool wbgen )
      {
         if ( wbgen )
         {
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_dvelop_confirmpanel_aprovar_proposta_body_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 205,'',false,'" + sGXsfl_167_idx + "',0)\"";
            ClassString = "ConfirmComment";
            StyleString = "";
            ClassString = "ConfirmComment";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavDvelop_confirmpanel_aprovar_proposta_comment_Internalname, AV69DVelop_ConfirmPanel_Aprovar_Proposta_Comment, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,205);\"", 0, 1, 1, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "Descrição da aprovação", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WpAlterarProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            wb_table4_206_7U2( true) ;
         }
         else
         {
            wb_table4_206_7U2( false) ;
         }
         return  ;
      }

      protected void wb_table4_206_7U2e( bool wbgen )
      {
         if ( wbgen )
         {
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_dvelop_confirmpanel_finalizar_analise_body_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 212,'',false,'" + sGXsfl_167_idx + "',0)\"";
            ClassString = "ConfirmComment";
            StyleString = "";
            ClassString = "ConfirmComment";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavDvelop_confirmpanel_finalizar_analise_comment_Internalname, AV70DVelop_ConfirmPanel_Finalizar_analise_Comment, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,212);\"", 0, 1, 1, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "Digite o por que você tomou essa decisão", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WpAlterarProposta.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            wb_table5_213_7U2( true) ;
         }
         else
         {
            wb_table5_213_7U2( false) ;
         }
         return  ;
      }

      protected void wb_table5_213_7U2e( bool wbgen )
      {
         if ( wbgen )
         {
            /* User Defined Control */
            ucGriddocumentos_empowerer.Render(context, "wwp.gridempowerer", Griddocumentos_empowerer_Internalname, "GRIDDOCUMENTOS_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 167 )
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
                  context.WriteHtmlText( "<div id=\""+"GriddocumentosContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Griddocumentos", GriddocumentosContainer, subGriddocumentos_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GriddocumentosContainerData", GriddocumentosContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GriddocumentosContainerData"+"V", GriddocumentosContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GriddocumentosContainerData"+"V"+"\" value='"+GriddocumentosContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START7U2( )
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
         Form.Meta.addItem("description", "Proposta", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP7U0( ) ;
      }

      protected void WS7U2( )
      {
         START7U2( ) ;
         EVT7U2( ) ;
      }

      protected void EVT7U2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_CONVENIOID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Combo_convenioid.Onoptionclicked */
                              E137U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_APROVAR_PROPOSTA.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Dvelop_confirmpanel_aprovar_proposta.Close */
                              E147U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_FINALIZAR_ANALISE.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Dvelop_confirmpanel_finalizar_analise.Close */
                              E157U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_EXCLUIR.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Dvelop_confirmpanel_excluir.Close */
                              E167U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DONOVODOCUMENTO'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoNovoDocumento' */
                              E177U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOCONSULTARCLIENTE'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoConsultarCliente' */
                              E187U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOCONSULTARRESPONSAVEL'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoConsultarResponsavel' */
                              E197U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOADICIONARRESPONSAVEL'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoAdicionarResponsavel' */
                              E207U2 ();
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
                                    E217U2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDDOCUMENTOSPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRIDDOCUMENTOSPAGING");
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "GRIDDOCUMENTOS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 21), "VADICIONARANEXO.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "VAPROVAR.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 15), "VREPROVAR.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "VAPROVAR.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 15), "VREPROVAR.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 21), "VADICIONARANEXO.CLICK") == 0 ) )
                           {
                              nGXsfl_167_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_167_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_167_idx), 4, 0), 4, "0");
                              SubsflControlProps_1672( ) ;
                              AV61Aprovar = cgiGet( edtavAprovar_Internalname);
                              AssignAttri("", false, edtavAprovar_Internalname, AV61Aprovar);
                              AV62Reprovar = cgiGet( edtavReprovar_Internalname);
                              AssignAttri("", false, edtavReprovar_Internalname, AV62Reprovar);
                              AV29AdicionarAnexo = cgiGet( edtavAdicionaranexo_Internalname);
                              AssignAttri("", false, edtavAdicionaranexo_Internalname, AV29AdicionarAnexo);
                              AV59Excluir = cgiGet( edtavExcluir_Internalname);
                              AssignAttri("", false, edtavExcluir_Internalname, AV59Excluir);
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavDocumentosid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavDocumentosid_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vDOCUMENTOSID");
                                 GX_FocusControl = edtavDocumentosid_Internalname;
                                 AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV36DocumentosId = 0;
                                 AssignAttri("", false, edtavDocumentosid_Internalname, StringUtil.LTrimStr( (decimal)(AV36DocumentosId), 9, 0));
                              }
                              else
                              {
                                 AV36DocumentosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavDocumentosid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                                 AssignAttri("", false, edtavDocumentosid_Internalname, StringUtil.LTrimStr( (decimal)(AV36DocumentosId), 9, 0));
                              }
                              AV37DocumentosDescricao = cgiGet( edtavDocumentosdescricao_Internalname);
                              AssignAttri("", false, edtavDocumentosdescricao_Internalname, AV37DocumentosDescricao);
                              cmbavDocumentoobrigatorio.Name = cmbavDocumentoobrigatorio_Internalname;
                              cmbavDocumentoobrigatorio.CurrentValue = cgiGet( cmbavDocumentoobrigatorio_Internalname);
                              AV38DocumentoObrigatorio = StringUtil.StrToBool( cgiGet( cmbavDocumentoobrigatorio_Internalname));
                              AssignAttri("", false, cmbavDocumentoobrigatorio_Internalname, AV38DocumentoObrigatorio);
                              AV49PropostaDocumentosAnexoName = cgiGet( edtavPropostadocumentosanexoname_Internalname);
                              AssignAttri("", false, edtavPropostadocumentosanexoname_Internalname, AV49PropostaDocumentosAnexoName);
                              AV39Documento = cgiGet( edtavDocumento_Internalname);
                              AssignProp("", false, edtavDocumento_Internalname, "URL", context.PathToRelativeUrl( AV39Documento), !bGXsfl_167_Refreshing);
                              AV40Extensao = cgiGet( edtavExtensao_Internalname);
                              AssignAttri("", false, edtavExtensao_Internalname, AV40Extensao);
                              cmbavPropostadocumentosstatus.Name = cmbavPropostadocumentosstatus_Internalname;
                              cmbavPropostadocumentosstatus.CurrentValue = cgiGet( cmbavPropostadocumentosstatus_Internalname);
                              AV41PropostaDocumentosStatus = cgiGet( cmbavPropostadocumentosstatus_Internalname);
                              AssignAttri("", false, cmbavPropostadocumentosstatus_Internalname, AV41PropostaDocumentosStatus);
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavPropostadocumentosid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPropostadocumentosid_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPROPOSTADOCUMENTOSID");
                                 GX_FocusControl = edtavPropostadocumentosid_Internalname;
                                 AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV54PropostaDocumentosId = 0;
                                 AssignAttri("", false, edtavPropostadocumentosid_Internalname, StringUtil.LTrimStr( (decimal)(AV54PropostaDocumentosId), 9, 0));
                                 GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTADOCUMENTOSID"+"_"+sGXsfl_167_idx, GetSecureSignedToken( sGXsfl_167_idx, context.localUtil.Format( (decimal)(AV54PropostaDocumentosId), "ZZZZZZZZ9"), context));
                              }
                              else
                              {
                                 AV54PropostaDocumentosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavPropostadocumentosid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                                 AssignAttri("", false, edtavPropostadocumentosid_Internalname, StringUtil.LTrimStr( (decimal)(AV54PropostaDocumentosId), 9, 0));
                                 GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTADOCUMENTOSID"+"_"+sGXsfl_167_idx, GetSecureSignedToken( sGXsfl_167_idx, context.localUtil.Format( (decimal)(AV54PropostaDocumentosId), "ZZZZZZZZ9"), context));
                              }
                              AV58PropostaDocumentosAdm = StringUtil.StrToBool( cgiGet( chkavPropostadocumentosadm_Internalname));
                              AssignAttri("", false, chkavPropostadocumentosadm_Internalname, AV58PropostaDocumentosAdm);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E227U2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E237U2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDDOCUMENTOS.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Griddocumentos.Load */
                                    E247U2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VADICIONARANEXO.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E257U2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VAPROVAR.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E267U2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VREPROVAR.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E277U2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                        if ( nCmpId == 188 )
                        {
                           OldWcserasaww = cgiGet( "W0188");
                           if ( ( StringUtil.Len( OldWcserasaww) == 0 ) || ( StringUtil.StrCmp(OldWcserasaww, WebComp_Wcserasaww_Component) != 0 ) )
                           {
                              WebComp_Wcserasaww = getWebComponent(GetType(), "GeneXus.Programs", OldWcserasaww, new Object[] {context} );
                              WebComp_Wcserasaww.ComponentInit();
                              WebComp_Wcserasaww.Name = "OldWcserasaww";
                              WebComp_Wcserasaww_Component = OldWcserasaww;
                           }
                           if ( StringUtil.Len( WebComp_Wcserasaww_Component) != 0 )
                           {
                              WebComp_Wcserasaww.componentprocess("W0188", "", sEvt);
                           }
                           WebComp_Wcserasaww_Component = OldWcserasaww;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE7U2( )
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

      protected void PA7U2( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpalterarproposta")), "wpalterarproposta") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpalterarproposta")))) ;
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
                  gxfirstwebparm = GetFirstPar( "PropostaId");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV5PropostaId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV5PropostaId", StringUtil.LTrimStr( (decimal)(AV5PropostaId), 9, 0));
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
               GX_FocusControl = edtavPropostacomentarioanalise_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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
         SubsflControlProps_1672( ) ;
         while ( nGXsfl_167_idx <= nRC_GXsfl_167 )
         {
            sendrow_1672( ) ;
            nGXsfl_167_idx = ((subGriddocumentos_Islastpage==1)&&(nGXsfl_167_idx+1>subGriddocumentos_fnc_Recordsperpage( )) ? 1 : nGXsfl_167_idx+1);
            sGXsfl_167_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_167_idx), 4, 0), 4, "0");
            SubsflControlProps_1672( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GriddocumentosContainer)) ;
         /* End function gxnrGriddocumentos_newrow */
      }

      protected void gxgrGriddocumentos_refresh( int subGriddocumentos_Rows ,
                                                 short AV66Aprovados ,
                                                 GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV67Context ,
                                                 string AV68PropostaStatus ,
                                                 int A323PropostaId ,
                                                 int AV5PropostaId ,
                                                 string A415PropostaDocumentosAnexo ,
                                                 string A406DocumentosDescricao ,
                                                 int A405DocumentosId ,
                                                 string A417PropostaDocumentosAnexoFileType ,
                                                 string A579PropostaDocumentosStatus ,
                                                 string A416PropostaDocumentosAnexoName ,
                                                 int A414PropostaDocumentosId ,
                                                 bool A651PropostaDocumentosAdm ,
                                                 int AV46PropostaPacienteClienteId ,
                                                 string AV71PropostaComentarioAnalise )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDDOCUMENTOS_nCurrentRecord = 0;
         RF7U2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"WpAlterarProposta");
         forbiddenHiddens.Add("PropostaComentarioAnalise", StringUtil.RTrim( context.localUtil.Format( AV71PropostaComentarioAnalise, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("wpalterarproposta:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
         /* End function gxgrGriddocumentos_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTADOCUMENTOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV54PropostaDocumentosId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPROPOSTADOCUMENTOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV54PropostaDocumentosId), 9, 0, ".", "")));
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
         if ( cmbavClientepixtipo.ItemCount > 0 )
         {
            AV18ClientePixTipo = cmbavClientepixtipo.getValidValue(AV18ClientePixTipo);
            AssignAttri("", false, "AV18ClientePixTipo", AV18ClientePixTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavClientepixtipo.CurrentValue = StringUtil.RTrim( AV18ClientePixTipo);
            AssignProp("", false, cmbavClientepixtipo_Internalname, "Values", cmbavClientepixtipo.ToJavascriptSource(), true);
         }
         if ( cmbavConveniovencimentoano.ItemCount > 0 )
         {
            AV16ConvenioVencimentoAno = (short)(Math.Round(NumberUtil.Val( cmbavConveniovencimentoano.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV16ConvenioVencimentoAno), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV16ConvenioVencimentoAno", StringUtil.LTrimStr( (decimal)(AV16ConvenioVencimentoAno), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavConveniovencimentoano.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16ConvenioVencimentoAno), 4, 0));
            AssignProp("", false, cmbavConveniovencimentoano_Internalname, "Values", cmbavConveniovencimentoano.ToJavascriptSource(), true);
         }
         if ( cmbavConveniovencimentomes.ItemCount > 0 )
         {
            AV17ConvenioVencimentoMes = (short)(Math.Round(NumberUtil.Val( cmbavConveniovencimentomes.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV17ConvenioVencimentoMes), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV17ConvenioVencimentoMes", StringUtil.LTrimStr( (decimal)(AV17ConvenioVencimentoMes), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavConveniovencimentomes.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17ConvenioVencimentoMes), 4, 0));
            AssignProp("", false, cmbavConveniovencimentomes_Internalname, "Values", cmbavConveniovencimentomes.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF7U2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavPropostacomentarioanalise_Enabled = 0;
         AssignProp("", false, edtavPropostacomentarioanalise_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPropostacomentarioanalise_Enabled), 5, 0), true);
         edtavClienterazaosocial_Enabled = 0;
         AssignProp("", false, edtavClienterazaosocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClienterazaosocial_Enabled), 5, 0), true);
         edtavClientedocumento_Enabled = 0;
         AssignProp("", false, edtavClientedocumento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientedocumento_Enabled), 5, 0), true);
         edtavContatoemail_Enabled = 0;
         AssignProp("", false, edtavContatoemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavContatoemail_Enabled), 5, 0), true);
         edtavBanconome_Enabled = 0;
         AssignProp("", false, edtavBanconome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavBanconome_Enabled), 5, 0), true);
         edtavContaagencia_Enabled = 0;
         AssignProp("", false, edtavContaagencia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavContaagencia_Enabled), 5, 0), true);
         edtavContanumero_Enabled = 0;
         AssignProp("", false, edtavContanumero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavContanumero_Enabled), 5, 0), true);
         cmbavClientepixtipo.Enabled = 0;
         AssignProp("", false, cmbavClientepixtipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavClientepixtipo.Enabled), 5, 0), true);
         edtavClientepix_Enabled = 0;
         AssignProp("", false, edtavClientepix_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientepix_Enabled), 5, 0), true);
         edtavAprovar_Enabled = 0;
         edtavReprovar_Enabled = 0;
         edtavAdicionaranexo_Enabled = 0;
         edtavExcluir_Enabled = 0;
         edtavDocumentosid_Enabled = 0;
         edtavDocumentosdescricao_Enabled = 0;
         cmbavDocumentoobrigatorio.Enabled = 0;
         edtavPropostadocumentosanexoname_Enabled = 0;
         edtavDocumento_Enabled = 0;
         edtavExtensao_Enabled = 0;
         cmbavPropostadocumentosstatus.Enabled = 0;
         edtavPropostadocumentosid_Enabled = 0;
         chkavPropostadocumentosadm.Enabled = 0;
      }

      protected void RF7U2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GriddocumentosContainer.ClearRows();
         }
         wbStart = 167;
         /* Execute user event: Refresh */
         E237U2 ();
         nGXsfl_167_idx = 1;
         sGXsfl_167_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_167_idx), 4, 0), 4, "0");
         SubsflControlProps_1672( ) ;
         bGXsfl_167_Refreshing = true;
         GriddocumentosContainer.AddObjectProperty("GridName", "Griddocumentos");
         GriddocumentosContainer.AddObjectProperty("CmpContext", "");
         GriddocumentosContainer.AddObjectProperty("InMasterPage", "false");
         GriddocumentosContainer.AddObjectProperty("Class", "GridWithBorderColor WorkWith");
         GriddocumentosContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GriddocumentosContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GriddocumentosContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddocumentos_Backcolorstyle), 1, 0, ".", "")));
         GriddocumentosContainer.PageSize = subGriddocumentos_fnc_Recordsperpage( );
         if ( subGriddocumentos_Islastpage != 0 )
         {
            GRIDDOCUMENTOS_nFirstRecordOnPage = (long)(subGriddocumentos_fnc_Recordcount( )-subGriddocumentos_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, "GRIDDOCUMENTOS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDDOCUMENTOS_nFirstRecordOnPage), 15, 0, ".", "")));
            GriddocumentosContainer.AddObjectProperty("GRIDDOCUMENTOS_nFirstRecordOnPage", GRIDDOCUMENTOS_nFirstRecordOnPage);
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcserasaww_Component) != 0 )
               {
                  WebComp_Wcserasaww.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1672( ) ;
            /* Execute user event: Griddocumentos.Load */
            E247U2 ();
            if ( ( subGriddocumentos_Islastpage == 0 ) && ( GRIDDOCUMENTOS_nCurrentRecord > 0 ) && ( GRIDDOCUMENTOS_nGridOutOfScope == 0 ) && ( nGXsfl_167_idx == 1 ) )
            {
               GRIDDOCUMENTOS_nCurrentRecord = 0;
               GRIDDOCUMENTOS_nGridOutOfScope = 1;
               subgriddocumentos_firstpage( ) ;
               /* Execute user event: Griddocumentos.Load */
               E247U2 ();
            }
            wbEnd = 167;
            WB7U0( ) ;
         }
         bGXsfl_167_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes7U2( )
      {
         GxWebStd.gx_hidden_field( context, "vAPROVADOS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV66Aprovados), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vAPROVADOS", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV66Aprovados), "ZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCONTEXT", AV67Context);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCONTEXT", AV67Context);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vCONTEXT", GetSecureSignedToken( "", AV67Context, context));
         GxWebStd.gx_hidden_field( context, "vPROPOSTASTATUS", AV68PropostaStatus);
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTASTATUS", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV68PropostaStatus, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTADOCUMENTOSID"+"_"+sGXsfl_167_idx, GetSecureSignedToken( sGXsfl_167_idx, context.localUtil.Format( (decimal)(AV54PropostaDocumentosId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPROPOSTAPACIENTECLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV46PropostaPacienteClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAPACIENTECLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV46PropostaPacienteClienteId), "ZZZZZZZZ9"), context));
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
         GxWebStd.gx_hidden_field( context, "GRIDDOCUMENTOS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDDOCUMENTOS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGriddocumentos_refresh( subGriddocumentos_Rows, AV66Aprovados, AV67Context, AV68PropostaStatus, A323PropostaId, AV5PropostaId, A415PropostaDocumentosAnexo, A406DocumentosDescricao, A405DocumentosId, A417PropostaDocumentosAnexoFileType, A579PropostaDocumentosStatus, A416PropostaDocumentosAnexoName, A414PropostaDocumentosId, A651PropostaDocumentosAdm, AV46PropostaPacienteClienteId, AV71PropostaComentarioAnalise) ;
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
         GxWebStd.gx_hidden_field( context, "GRIDDOCUMENTOS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDDOCUMENTOS_nFirstRecordOnPage), 15, 0, ".", "")));
         GriddocumentosContainer.AddObjectProperty("GRIDDOCUMENTOS_nFirstRecordOnPage", GRIDDOCUMENTOS_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGriddocumentos_refresh( subGriddocumentos_Rows, AV66Aprovados, AV67Context, AV68PropostaStatus, A323PropostaId, AV5PropostaId, A415PropostaDocumentosAnexo, A406DocumentosDescricao, A405DocumentosId, A417PropostaDocumentosAnexoFileType, A579PropostaDocumentosStatus, A416PropostaDocumentosAnexoName, A414PropostaDocumentosId, A651PropostaDocumentosAdm, AV46PropostaPacienteClienteId, AV71PropostaComentarioAnalise) ;
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
         GxWebStd.gx_hidden_field( context, "GRIDDOCUMENTOS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDDOCUMENTOS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGriddocumentos_refresh( subGriddocumentos_Rows, AV66Aprovados, AV67Context, AV68PropostaStatus, A323PropostaId, AV5PropostaId, A415PropostaDocumentosAnexo, A406DocumentosDescricao, A405DocumentosId, A417PropostaDocumentosAnexoFileType, A579PropostaDocumentosStatus, A416PropostaDocumentosAnexoName, A414PropostaDocumentosId, A651PropostaDocumentosAdm, AV46PropostaPacienteClienteId, AV71PropostaComentarioAnalise) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgriddocumentos_lastpage( )
      {
         subGriddocumentos_Islastpage = 1;
         if ( isFullAjaxMode( ) )
         {
            gxgrGriddocumentos_refresh( subGriddocumentos_Rows, AV66Aprovados, AV67Context, AV68PropostaStatus, A323PropostaId, AV5PropostaId, A415PropostaDocumentosAnexo, A406DocumentosDescricao, A405DocumentosId, A417PropostaDocumentosAnexoFileType, A579PropostaDocumentosStatus, A416PropostaDocumentosAnexoName, A414PropostaDocumentosId, A651PropostaDocumentosAdm, AV46PropostaPacienteClienteId, AV71PropostaComentarioAnalise) ;
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
         GxWebStd.gx_hidden_field( context, "GRIDDOCUMENTOS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDDOCUMENTOS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGriddocumentos_refresh( subGriddocumentos_Rows, AV66Aprovados, AV67Context, AV68PropostaStatus, A323PropostaId, AV5PropostaId, A415PropostaDocumentosAnexo, A406DocumentosDescricao, A405DocumentosId, A417PropostaDocumentosAnexoFileType, A579PropostaDocumentosStatus, A416PropostaDocumentosAnexoName, A414PropostaDocumentosId, A651PropostaDocumentosAdm, AV46PropostaPacienteClienteId, AV71PropostaComentarioAnalise) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtavPropostacomentarioanalise_Enabled = 0;
         AssignProp("", false, edtavPropostacomentarioanalise_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPropostacomentarioanalise_Enabled), 5, 0), true);
         edtavClienterazaosocial_Enabled = 0;
         AssignProp("", false, edtavClienterazaosocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClienterazaosocial_Enabled), 5, 0), true);
         edtavClientedocumento_Enabled = 0;
         AssignProp("", false, edtavClientedocumento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientedocumento_Enabled), 5, 0), true);
         edtavContatoemail_Enabled = 0;
         AssignProp("", false, edtavContatoemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavContatoemail_Enabled), 5, 0), true);
         edtavBanconome_Enabled = 0;
         AssignProp("", false, edtavBanconome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavBanconome_Enabled), 5, 0), true);
         edtavContaagencia_Enabled = 0;
         AssignProp("", false, edtavContaagencia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavContaagencia_Enabled), 5, 0), true);
         edtavContanumero_Enabled = 0;
         AssignProp("", false, edtavContanumero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavContanumero_Enabled), 5, 0), true);
         cmbavClientepixtipo.Enabled = 0;
         AssignProp("", false, cmbavClientepixtipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavClientepixtipo.Enabled), 5, 0), true);
         edtavClientepix_Enabled = 0;
         AssignProp("", false, edtavClientepix_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientepix_Enabled), 5, 0), true);
         edtavAprovar_Enabled = 0;
         edtavReprovar_Enabled = 0;
         edtavAdicionaranexo_Enabled = 0;
         edtavExcluir_Enabled = 0;
         edtavDocumentosid_Enabled = 0;
         edtavDocumentosdescricao_Enabled = 0;
         cmbavDocumentoobrigatorio.Enabled = 0;
         edtavPropostadocumentosanexoname_Enabled = 0;
         edtavDocumento_Enabled = 0;
         edtavExtensao_Enabled = 0;
         cmbavPropostadocumentosstatus.Enabled = 0;
         edtavPropostadocumentosid_Enabled = 0;
         chkavPropostadocumentosadm.Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP7U0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E227U2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vPROPOSTARESPONSAVELID_DATA"), AV72PropostaResponsavelId_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vPROCEDIMENTOSMEDICOSID_DATA"), AV31ProcedimentosMedicosId_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vCONVENIOID_DATA"), AV33ConvenioId_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vCONVENIOCATEGORIAID_DATA"), AV34ConvenioCategoriaId_Data);
            /* Read saved values. */
            nRC_GXsfl_167 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_167"), ",", "."), 18, MidpointRounding.ToEven));
            GRIDDOCUMENTOS_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDDOCUMENTOS_nFirstRecordOnPage"), ",", "."), 18, MidpointRounding.ToEven));
            GRIDDOCUMENTOS_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDDOCUMENTOS_nEOF"), ",", "."), 18, MidpointRounding.ToEven));
            subGriddocumentos_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "subGriddocumentos_Recordcount"), ",", "."), 18, MidpointRounding.ToEven));
            subGriddocumentos_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDDOCUMENTOS_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRIDDOCUMENTOS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddocumentos_Rows), 6, 0, ".", "")));
            Combo_propostaresponsavelid_Cls = cgiGet( "COMBO_PROPOSTARESPONSAVELID_Cls");
            Combo_propostaresponsavelid_Selectedvalue_set = cgiGet( "COMBO_PROPOSTARESPONSAVELID_Selectedvalue_set");
            Combo_propostaresponsavelid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_PROPOSTARESPONSAVELID_Emptyitem"));
            Combo_propostaresponsavelid_Htmltemplate = cgiGet( "COMBO_PROPOSTARESPONSAVELID_Htmltemplate");
            Combo_procedimentosmedicosid_Cls = cgiGet( "COMBO_PROCEDIMENTOSMEDICOSID_Cls");
            Combo_procedimentosmedicosid_Selectedvalue_set = cgiGet( "COMBO_PROCEDIMENTOSMEDICOSID_Selectedvalue_set");
            Combo_procedimentosmedicosid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_PROCEDIMENTOSMEDICOSID_Enabled"));
            Combo_procedimentosmedicosid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_PROCEDIMENTOSMEDICOSID_Emptyitem"));
            Combo_convenioid_Cls = cgiGet( "COMBO_CONVENIOID_Cls");
            Combo_convenioid_Selectedvalue_set = cgiGet( "COMBO_CONVENIOID_Selectedvalue_set");
            Combo_convenioid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_CONVENIOID_Enabled"));
            Combo_convenioid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_CONVENIOID_Emptyitem"));
            Combo_conveniocategoriaid_Cls = cgiGet( "COMBO_CONVENIOCATEGORIAID_Cls");
            Combo_conveniocategoriaid_Selectedvalue_set = cgiGet( "COMBO_CONVENIOCATEGORIAID_Selectedvalue_set");
            Combo_conveniocategoriaid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_CONVENIOCATEGORIAID_Enabled"));
            Combo_conveniocategoriaid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_CONVENIOCATEGORIAID_Emptyitem"));
            Gxuitabspanel_tabs1_Pagecount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GXUITABSPANEL_TABS1_Pagecount"), ",", "."), 18, MidpointRounding.ToEven));
            Gxuitabspanel_tabs1_Class = cgiGet( "GXUITABSPANEL_TABS1_Class");
            Gxuitabspanel_tabs1_Historymanagement = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_TABS1_Historymanagement"));
            Novajanela_Target = cgiGet( "NOVAJANELA_Target");
            Dvelop_confirmpanel_aprovar_proposta_Title = cgiGet( "DVELOP_CONFIRMPANEL_APROVAR_PROPOSTA_Title");
            Dvelop_confirmpanel_aprovar_proposta_Confirmationtext = cgiGet( "DVELOP_CONFIRMPANEL_APROVAR_PROPOSTA_Confirmationtext");
            Dvelop_confirmpanel_aprovar_proposta_Yesbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_APROVAR_PROPOSTA_Yesbuttoncaption");
            Dvelop_confirmpanel_aprovar_proposta_Nobuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_APROVAR_PROPOSTA_Nobuttoncaption");
            Dvelop_confirmpanel_aprovar_proposta_Cancelbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_APROVAR_PROPOSTA_Cancelbuttoncaption");
            Dvelop_confirmpanel_aprovar_proposta_Yesbuttonposition = cgiGet( "DVELOP_CONFIRMPANEL_APROVAR_PROPOSTA_Yesbuttonposition");
            Dvelop_confirmpanel_aprovar_proposta_Confirmtype = cgiGet( "DVELOP_CONFIRMPANEL_APROVAR_PROPOSTA_Confirmtype");
            Dvelop_confirmpanel_aprovar_proposta_Comment = cgiGet( "DVELOP_CONFIRMPANEL_APROVAR_PROPOSTA_Comment");
            Dvelop_confirmpanel_aprovar_proposta_Bodycontentinternalname = cgiGet( "DVELOP_CONFIRMPANEL_APROVAR_PROPOSTA_Bodycontentinternalname");
            Dvelop_confirmpanel_finalizar_analise_Title = cgiGet( "DVELOP_CONFIRMPANEL_FINALIZAR_ANALISE_Title");
            Dvelop_confirmpanel_finalizar_analise_Confirmationtext = cgiGet( "DVELOP_CONFIRMPANEL_FINALIZAR_ANALISE_Confirmationtext");
            Dvelop_confirmpanel_finalizar_analise_Yesbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_FINALIZAR_ANALISE_Yesbuttoncaption");
            Dvelop_confirmpanel_finalizar_analise_Nobuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_FINALIZAR_ANALISE_Nobuttoncaption");
            Dvelop_confirmpanel_finalizar_analise_Cancelbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_FINALIZAR_ANALISE_Cancelbuttoncaption");
            Dvelop_confirmpanel_finalizar_analise_Yesbuttonposition = cgiGet( "DVELOP_CONFIRMPANEL_FINALIZAR_ANALISE_Yesbuttonposition");
            Dvelop_confirmpanel_finalizar_analise_Confirmtype = cgiGet( "DVELOP_CONFIRMPANEL_FINALIZAR_ANALISE_Confirmtype");
            Dvelop_confirmpanel_finalizar_analise_Comment = cgiGet( "DVELOP_CONFIRMPANEL_FINALIZAR_ANALISE_Comment");
            Dvelop_confirmpanel_finalizar_analise_Bodycontentinternalname = cgiGet( "DVELOP_CONFIRMPANEL_FINALIZAR_ANALISE_Bodycontentinternalname");
            Dvelop_confirmpanel_excluir_Title = cgiGet( "DVELOP_CONFIRMPANEL_EXCLUIR_Title");
            Dvelop_confirmpanel_excluir_Confirmationtext = cgiGet( "DVELOP_CONFIRMPANEL_EXCLUIR_Confirmationtext");
            Dvelop_confirmpanel_excluir_Yesbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_EXCLUIR_Yesbuttoncaption");
            Dvelop_confirmpanel_excluir_Nobuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_EXCLUIR_Nobuttoncaption");
            Dvelop_confirmpanel_excluir_Cancelbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_EXCLUIR_Cancelbuttoncaption");
            Dvelop_confirmpanel_excluir_Yesbuttonposition = cgiGet( "DVELOP_CONFIRMPANEL_EXCLUIR_Yesbuttonposition");
            Dvelop_confirmpanel_excluir_Confirmtype = cgiGet( "DVELOP_CONFIRMPANEL_EXCLUIR_Confirmtype");
            Griddocumentos_empowerer_Gridinternalname = cgiGet( "GRIDDOCUMENTOS_EMPOWERER_Gridinternalname");
            Dvelop_confirmpanel_aprovar_proposta_Result = cgiGet( "DVELOP_CONFIRMPANEL_APROVAR_PROPOSTA_Result");
            Dvelop_confirmpanel_finalizar_analise_Result = cgiGet( "DVELOP_CONFIRMPANEL_FINALIZAR_ANALISE_Result");
            Dvelop_confirmpanel_excluir_Result = cgiGet( "DVELOP_CONFIRMPANEL_EXCLUIR_Result");
            Combo_convenioid_Selectedvalue_get = cgiGet( "COMBO_CONVENIOID_Selectedvalue_get");
            /* Read variables values. */
            AV71PropostaComentarioAnalise = cgiGet( edtavPropostacomentarioanalise_Internalname);
            AssignAttri("", false, "AV71PropostaComentarioAnalise", AV71PropostaComentarioAnalise);
            AV26ClienteRazaoSocial = StringUtil.Upper( cgiGet( edtavClienterazaosocial_Internalname));
            AssignAttri("", false, "AV26ClienteRazaoSocial", AV26ClienteRazaoSocial);
            AV27ClienteDocumento = cgiGet( edtavClientedocumento_Internalname);
            AssignAttri("", false, "AV27ClienteDocumento", AV27ClienteDocumento);
            AV28ContatoEmail = cgiGet( edtavContatoemail_Internalname);
            AssignAttri("", false, "AV28ContatoEmail", AV28ContatoEmail);
            AV42BancoNome = cgiGet( edtavBanconome_Internalname);
            AssignAttri("", false, "AV42BancoNome", AV42BancoNome);
            AV21ContaAgencia = cgiGet( edtavContaagencia_Internalname);
            AssignAttri("", false, "AV21ContaAgencia", AV21ContaAgencia);
            AV22ContaNumero = cgiGet( edtavContanumero_Internalname);
            AssignAttri("", false, "AV22ContaNumero", AV22ContaNumero);
            cmbavClientepixtipo.Name = cmbavClientepixtipo_Internalname;
            cmbavClientepixtipo.CurrentValue = cgiGet( cmbavClientepixtipo_Internalname);
            AV18ClientePixTipo = cgiGet( cmbavClientepixtipo_Internalname);
            AssignAttri("", false, "AV18ClientePixTipo", AV18ClientePixTipo);
            AV19ClientePix = cgiGet( edtavClientepix_Internalname);
            AssignAttri("", false, "AV19ClientePix", AV19ClientePix);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPropostavalor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPropostavalor_Internalname), ",", ".") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPROPOSTAVALOR");
               GX_FocusControl = edtavPropostavalor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12PropostaValor = 0;
               AssignAttri("", false, "AV12PropostaValor", StringUtil.LTrimStr( AV12PropostaValor, 18, 2));
            }
            else
            {
               AV12PropostaValor = context.localUtil.CToN( cgiGet( edtavPropostavalor_Internalname), ",", ".");
               AssignAttri("", false, "AV12PropostaValor", StringUtil.LTrimStr( AV12PropostaValor, 18, 2));
            }
            AV13PropostaDescricao = cgiGet( edtavPropostadescricao_Internalname);
            AssignAttri("", false, "AV13PropostaDescricao", AV13PropostaDescricao);
            cmbavConveniovencimentoano.Name = cmbavConveniovencimentoano_Internalname;
            cmbavConveniovencimentoano.CurrentValue = cgiGet( cmbavConveniovencimentoano_Internalname);
            AV16ConvenioVencimentoAno = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavConveniovencimentoano_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV16ConvenioVencimentoAno", StringUtil.LTrimStr( (decimal)(AV16ConvenioVencimentoAno), 4, 0));
            cmbavConveniovencimentomes.Name = cmbavConveniovencimentomes_Internalname;
            cmbavConveniovencimentomes.CurrentValue = cgiGet( cmbavConveniovencimentomes_Internalname);
            AV17ConvenioVencimentoMes = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavConveniovencimentomes_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV17ConvenioVencimentoMes", StringUtil.LTrimStr( (decimal)(AV17ConvenioVencimentoMes), 4, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPropostaresponsavelid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPropostaresponsavelid_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPROPOSTARESPONSAVELID");
               GX_FocusControl = edtavPropostaresponsavelid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV47PropostaResponsavelId = 0;
               AssignAttri("", false, "AV47PropostaResponsavelId", StringUtil.LTrimStr( (decimal)(AV47PropostaResponsavelId), 9, 0));
            }
            else
            {
               AV47PropostaResponsavelId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavPropostaresponsavelid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV47PropostaResponsavelId", StringUtil.LTrimStr( (decimal)(AV47PropostaResponsavelId), 9, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavProcedimentosmedicosid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavProcedimentosmedicosid_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPROCEDIMENTOSMEDICOSID");
               GX_FocusControl = edtavProcedimentosmedicosid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11ProcedimentosMedicosId = 0;
               AssignAttri("", false, "AV11ProcedimentosMedicosId", StringUtil.LTrimStr( (decimal)(AV11ProcedimentosMedicosId), 9, 0));
            }
            else
            {
               AV11ProcedimentosMedicosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavProcedimentosmedicosid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11ProcedimentosMedicosId", StringUtil.LTrimStr( (decimal)(AV11ProcedimentosMedicosId), 9, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavConvenioid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavConvenioid_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCONVENIOID");
               GX_FocusControl = edtavConvenioid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV14ConvenioId = 0;
               AssignAttri("", false, "AV14ConvenioId", StringUtil.LTrimStr( (decimal)(AV14ConvenioId), 9, 0));
            }
            else
            {
               AV14ConvenioId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavConvenioid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV14ConvenioId", StringUtil.LTrimStr( (decimal)(AV14ConvenioId), 9, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavConveniocategoriaid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavConveniocategoriaid_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCONVENIOCATEGORIAID");
               GX_FocusControl = edtavConveniocategoriaid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV15ConvenioCategoriaId = 0;
               AssignAttri("", false, "AV15ConvenioCategoriaId", StringUtil.LTrimStr( (decimal)(AV15ConvenioCategoriaId), 9, 0));
            }
            else
            {
               AV15ConvenioCategoriaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavConveniocategoriaid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV15ConvenioCategoriaId", StringUtil.LTrimStr( (decimal)(AV15ConvenioCategoriaId), 9, 0));
            }
            AV69DVelop_ConfirmPanel_Aprovar_Proposta_Comment = cgiGet( edtavDvelop_confirmpanel_aprovar_proposta_comment_Internalname);
            AssignAttri("", false, "AV69DVelop_ConfirmPanel_Aprovar_Proposta_Comment", AV69DVelop_ConfirmPanel_Aprovar_Proposta_Comment);
            AV70DVelop_ConfirmPanel_Finalizar_analise_Comment = cgiGet( edtavDvelop_confirmpanel_finalizar_analise_comment_Internalname);
            AssignAttri("", false, "AV70DVelop_ConfirmPanel_Finalizar_analise_Comment", AV70DVelop_ConfirmPanel_Finalizar_analise_Comment);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"WpAlterarProposta");
            AV71PropostaComentarioAnalise = cgiGet( edtavPropostacomentarioanalise_Internalname);
            AssignAttri("", false, "AV71PropostaComentarioAnalise", AV71PropostaComentarioAnalise);
            forbiddenHiddens.Add("PropostaComentarioAnalise", StringUtil.RTrim( context.localUtil.Format( AV71PropostaComentarioAnalise, "")));
            hsh = cgiGet( "hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("wpalterarproposta:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
               GxWebError = 1;
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               return  ;
            }
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
         E227U2 ();
         if (returnInSub) return;
      }

      protected void E227U2( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtWWPContext1 = AV67Context;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  GXt_SdtWWPContext1) ;
         AV67Context = GXt_SdtWWPContext1;
         AV63Array_ClienteId = (GxSimpleCollection<int>)(new GxSimpleCollection<int>());
         /* Using cursor H007U3 */
         pr_default.execute(0, new Object[] {AV67Context.gxTpr_Userid, AV5PropostaId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A227ContratoId = H007U3_A227ContratoId[0];
            n227ContratoId = H007U3_n227ContratoId[0];
            A473ContratoClienteId = H007U3_A473ContratoClienteId[0];
            n473ContratoClienteId = H007U3_n473ContratoClienteId[0];
            A402BancoId = H007U3_A402BancoId[0];
            n402BancoId = H007U3_n402BancoId[0];
            A403BancoNome = H007U3_A403BancoNome[0];
            n403BancoNome = H007U3_n403BancoNome[0];
            A323PropostaId = H007U3_A323PropostaId[0];
            n323PropostaId = H007U3_n323PropostaId[0];
            A329PropostaStatus = H007U3_A329PropostaStatus[0];
            n329PropostaStatus = H007U3_n329PropostaStatus[0];
            A790PropostaComentarioAnalise = H007U3_A790PropostaComentarioAnalise[0];
            n790PropostaComentarioAnalise = H007U3_n790PropostaComentarioAnalise[0];
            A553PropostaResponsavelId = H007U3_A553PropostaResponsavelId[0];
            n553PropostaResponsavelId = H007U3_n553PropostaResponsavelId[0];
            A504PropostaPacienteClienteId = H007U3_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = H007U3_n504PropostaPacienteClienteId[0];
            A642PropostaClinicaId = H007U3_A642PropostaClinicaId[0];
            n642PropostaClinicaId = H007U3_n642PropostaClinicaId[0];
            A590PropostaResponsavelConta = H007U3_A590PropostaResponsavelConta[0];
            n590PropostaResponsavelConta = H007U3_n590PropostaResponsavelConta[0];
            A591PropostaResponsavelAgencia = H007U3_A591PropostaResponsavelAgencia[0];
            n591PropostaResponsavelAgencia = H007U3_n591PropostaResponsavelAgencia[0];
            A592PropostaResponsavelTipoPix = H007U3_A592PropostaResponsavelTipoPix[0];
            n592PropostaResponsavelTipoPix = H007U3_n592PropostaResponsavelTipoPix[0];
            A593PropostaResponsavelPIX = H007U3_A593PropostaResponsavelPIX[0];
            n593PropostaResponsavelPIX = H007U3_n593PropostaResponsavelPIX[0];
            A594PropostaResponsavelDepositoTipo = H007U3_A594PropostaResponsavelDepositoTipo[0];
            n594PropostaResponsavelDepositoTipo = H007U3_n594PropostaResponsavelDepositoTipo[0];
            A584PropostaPacienteConta = H007U3_A584PropostaPacienteConta[0];
            n584PropostaPacienteConta = H007U3_n584PropostaPacienteConta[0];
            A585PropostaPacienteAgencia = H007U3_A585PropostaPacienteAgencia[0];
            n585PropostaPacienteAgencia = H007U3_n585PropostaPacienteAgencia[0];
            A586PropostaPacienteTipoPix = H007U3_A586PropostaPacienteTipoPix[0];
            n586PropostaPacienteTipoPix = H007U3_n586PropostaPacienteTipoPix[0];
            A587PropostaPacientePIX = H007U3_A587PropostaPacientePIX[0];
            n587PropostaPacientePIX = H007U3_n587PropostaPacientePIX[0];
            A588PropostaPacienteDepositoTipo = H007U3_A588PropostaPacienteDepositoTipo[0];
            n588PropostaPacienteDepositoTipo = H007U3_n588PropostaPacienteDepositoTipo[0];
            A376ProcedimentosMedicosId = H007U3_A376ProcedimentosMedicosId[0];
            n376ProcedimentosMedicosId = H007U3_n376ProcedimentosMedicosId[0];
            A410ConvenioId = H007U3_A410ConvenioId[0];
            n410ConvenioId = H007U3_n410ConvenioId[0];
            A493ConvenioCategoriaId = H007U3_A493ConvenioCategoriaId[0];
            n493ConvenioCategoriaId = H007U3_n493ConvenioCategoriaId[0];
            A505PropostaPacienteClienteRazaoSocial = H007U3_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = H007U3_n505PropostaPacienteClienteRazaoSocial[0];
            A540PropostaPacienteClienteDocumento = H007U3_A540PropostaPacienteClienteDocumento[0];
            n540PropostaPacienteClienteDocumento = H007U3_n540PropostaPacienteClienteDocumento[0];
            A541PropostaPacienteContatoEmail = H007U3_A541PropostaPacienteContatoEmail[0];
            n541PropostaPacienteContatoEmail = H007U3_n541PropostaPacienteContatoEmail[0];
            A580PropostaResponsavelDocumento = H007U3_A580PropostaResponsavelDocumento[0];
            n580PropostaResponsavelDocumento = H007U3_n580PropostaResponsavelDocumento[0];
            A581PropostaResponsavelRazaoSocial = H007U3_A581PropostaResponsavelRazaoSocial[0];
            n581PropostaResponsavelRazaoSocial = H007U3_n581PropostaResponsavelRazaoSocial[0];
            A582PropostaResponsavelEmail = H007U3_A582PropostaResponsavelEmail[0];
            n582PropostaResponsavelEmail = H007U3_n582PropostaResponsavelEmail[0];
            A378ProcedimentosMedicosDescricao = H007U3_A378ProcedimentosMedicosDescricao[0];
            n378ProcedimentosMedicosDescricao = H007U3_n378ProcedimentosMedicosDescricao[0];
            A326PropostaValor = H007U3_A326PropostaValor[0];
            n326PropostaValor = H007U3_n326PropostaValor[0];
            A325PropostaDescricao = H007U3_A325PropostaDescricao[0];
            n325PropostaDescricao = H007U3_n325PropostaDescricao[0];
            A494ConvenioCategoriaDescricao = H007U3_A494ConvenioCategoriaDescricao[0];
            n494ConvenioCategoriaDescricao = H007U3_n494ConvenioCategoriaDescricao[0];
            A411ConvenioDescricao = H007U3_A411ConvenioDescricao[0];
            n411ConvenioDescricao = H007U3_n411ConvenioDescricao[0];
            A496ConvenioVencimentoAno = H007U3_A496ConvenioVencimentoAno[0];
            n496ConvenioVencimentoAno = H007U3_n496ConvenioVencimentoAno[0];
            A497ConvenioVencimentoMes = H007U3_A497ConvenioVencimentoMes[0];
            n497ConvenioVencimentoMes = H007U3_n497ConvenioVencimentoMes[0];
            A40000GXC1 = H007U3_A40000GXC1[0];
            n40000GXC1 = H007U3_n40000GXC1[0];
            A473ContratoClienteId = H007U3_A473ContratoClienteId[0];
            n473ContratoClienteId = H007U3_n473ContratoClienteId[0];
            A402BancoId = H007U3_A402BancoId[0];
            n402BancoId = H007U3_n402BancoId[0];
            A403BancoNome = H007U3_A403BancoNome[0];
            n403BancoNome = H007U3_n403BancoNome[0];
            A40000GXC1 = H007U3_A40000GXC1[0];
            n40000GXC1 = H007U3_n40000GXC1[0];
            A590PropostaResponsavelConta = H007U3_A590PropostaResponsavelConta[0];
            n590PropostaResponsavelConta = H007U3_n590PropostaResponsavelConta[0];
            A591PropostaResponsavelAgencia = H007U3_A591PropostaResponsavelAgencia[0];
            n591PropostaResponsavelAgencia = H007U3_n591PropostaResponsavelAgencia[0];
            A592PropostaResponsavelTipoPix = H007U3_A592PropostaResponsavelTipoPix[0];
            n592PropostaResponsavelTipoPix = H007U3_n592PropostaResponsavelTipoPix[0];
            A593PropostaResponsavelPIX = H007U3_A593PropostaResponsavelPIX[0];
            n593PropostaResponsavelPIX = H007U3_n593PropostaResponsavelPIX[0];
            A594PropostaResponsavelDepositoTipo = H007U3_A594PropostaResponsavelDepositoTipo[0];
            n594PropostaResponsavelDepositoTipo = H007U3_n594PropostaResponsavelDepositoTipo[0];
            A580PropostaResponsavelDocumento = H007U3_A580PropostaResponsavelDocumento[0];
            n580PropostaResponsavelDocumento = H007U3_n580PropostaResponsavelDocumento[0];
            A581PropostaResponsavelRazaoSocial = H007U3_A581PropostaResponsavelRazaoSocial[0];
            n581PropostaResponsavelRazaoSocial = H007U3_n581PropostaResponsavelRazaoSocial[0];
            A582PropostaResponsavelEmail = H007U3_A582PropostaResponsavelEmail[0];
            n582PropostaResponsavelEmail = H007U3_n582PropostaResponsavelEmail[0];
            A584PropostaPacienteConta = H007U3_A584PropostaPacienteConta[0];
            n584PropostaPacienteConta = H007U3_n584PropostaPacienteConta[0];
            A585PropostaPacienteAgencia = H007U3_A585PropostaPacienteAgencia[0];
            n585PropostaPacienteAgencia = H007U3_n585PropostaPacienteAgencia[0];
            A586PropostaPacienteTipoPix = H007U3_A586PropostaPacienteTipoPix[0];
            n586PropostaPacienteTipoPix = H007U3_n586PropostaPacienteTipoPix[0];
            A587PropostaPacientePIX = H007U3_A587PropostaPacientePIX[0];
            n587PropostaPacientePIX = H007U3_n587PropostaPacientePIX[0];
            A588PropostaPacienteDepositoTipo = H007U3_A588PropostaPacienteDepositoTipo[0];
            n588PropostaPacienteDepositoTipo = H007U3_n588PropostaPacienteDepositoTipo[0];
            A505PropostaPacienteClienteRazaoSocial = H007U3_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = H007U3_n505PropostaPacienteClienteRazaoSocial[0];
            A540PropostaPacienteClienteDocumento = H007U3_A540PropostaPacienteClienteDocumento[0];
            n540PropostaPacienteClienteDocumento = H007U3_n540PropostaPacienteClienteDocumento[0];
            A541PropostaPacienteContatoEmail = H007U3_A541PropostaPacienteContatoEmail[0];
            n541PropostaPacienteContatoEmail = H007U3_n541PropostaPacienteContatoEmail[0];
            A378ProcedimentosMedicosDescricao = H007U3_A378ProcedimentosMedicosDescricao[0];
            n378ProcedimentosMedicosDescricao = H007U3_n378ProcedimentosMedicosDescricao[0];
            A410ConvenioId = H007U3_A410ConvenioId[0];
            n410ConvenioId = H007U3_n410ConvenioId[0];
            A494ConvenioCategoriaDescricao = H007U3_A494ConvenioCategoriaDescricao[0];
            n494ConvenioCategoriaDescricao = H007U3_n494ConvenioCategoriaDescricao[0];
            A411ConvenioDescricao = H007U3_A411ConvenioDescricao[0];
            n411ConvenioDescricao = H007U3_n411ConvenioDescricao[0];
            AV66Aprovados = (short)(A40000GXC1);
            AssignAttri("", false, "AV66Aprovados", StringUtil.LTrimStr( (decimal)(AV66Aprovados), 4, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vAPROVADOS", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV66Aprovados), "ZZZ9"), context));
            AV68PropostaStatus = A329PropostaStatus;
            AssignAttri("", false, "AV68PropostaStatus", AV68PropostaStatus);
            GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTASTATUS", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV68PropostaStatus, "")), context));
            AV71PropostaComentarioAnalise = A790PropostaComentarioAnalise;
            AssignAttri("", false, "AV71PropostaComentarioAnalise", AV71PropostaComentarioAnalise);
            if ( StringUtil.StrCmp(A329PropostaStatus, "APROVADO") == 0 )
            {
               Combo_conveniocategoriaid_Enabled = false;
               ucCombo_conveniocategoriaid.SendProperty(context, "", false, Combo_conveniocategoriaid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_conveniocategoriaid_Enabled));
               Combo_convenioid_Enabled = false;
               ucCombo_convenioid.SendProperty(context, "", false, Combo_convenioid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_convenioid_Enabled));
               Combo_procedimentosmedicosid_Enabled = false;
               ucCombo_procedimentosmedicosid.SendProperty(context, "", false, Combo_procedimentosmedicosid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_procedimentosmedicosid_Enabled));
               edtavPropostavalor_Enabled = 0;
               AssignProp("", false, edtavPropostavalor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPropostavalor_Enabled), 5, 0), true);
               cmbavConveniovencimentoano.Enabled = 0;
               AssignProp("", false, cmbavConveniovencimentoano_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavConveniovencimentoano.Enabled), 5, 0), true);
               cmbavConveniovencimentomes.Enabled = 0;
               AssignProp("", false, cmbavConveniovencimentomes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavConveniovencimentomes.Enabled), 5, 0), true);
            }
            AV47PropostaResponsavelId = A553PropostaResponsavelId;
            AssignAttri("", false, "AV47PropostaResponsavelId", StringUtil.LTrimStr( (decimal)(AV47PropostaResponsavelId), 9, 0));
            AV63Array_ClienteId.Add(A504PropostaPacienteClienteId, 0);
            AV63Array_ClienteId.Add(A553PropostaResponsavelId, 0);
            AV63Array_ClienteId.Add(A642PropostaClinicaId, 0);
            if ( ( A504PropostaPacienteClienteId == A553PropostaResponsavelId ) || H007U3_n553PropostaResponsavelId[0] || (0==A553PropostaResponsavelId) )
            {
               divTablecontentresponsavel_Visible = 0;
               AssignProp("", false, divTablecontentresponsavel_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablecontentresponsavel_Visible), 5, 0), true);
               AV42BancoNome = A589PropostaResponsavelBanco;
               AssignAttri("", false, "AV42BancoNome", AV42BancoNome);
               AV22ContaNumero = A590PropostaResponsavelConta;
               AssignAttri("", false, "AV22ContaNumero", AV22ContaNumero);
               AV21ContaAgencia = A591PropostaResponsavelAgencia;
               AssignAttri("", false, "AV21ContaAgencia", AV21ContaAgencia);
               AV18ClientePixTipo = A592PropostaResponsavelTipoPix;
               AssignAttri("", false, "AV18ClientePixTipo", AV18ClientePixTipo);
               AV19ClientePix = A593PropostaResponsavelPIX;
               AssignAttri("", false, "AV19ClientePix", AV19ClientePix);
               AV48ClienteDepositoTipo = A594PropostaResponsavelDepositoTipo;
            }
            else
            {
               AV42BancoNome = A583PropostaPacienteBanco;
               AssignAttri("", false, "AV42BancoNome", AV42BancoNome);
               AV22ContaNumero = A584PropostaPacienteConta;
               AssignAttri("", false, "AV22ContaNumero", AV22ContaNumero);
               AV21ContaAgencia = A585PropostaPacienteAgencia;
               AssignAttri("", false, "AV21ContaAgencia", AV21ContaAgencia);
               AV18ClientePixTipo = A586PropostaPacienteTipoPix;
               AssignAttri("", false, "AV18ClientePixTipo", AV18ClientePixTipo);
               AV19ClientePix = A587PropostaPacientePIX;
               AssignAttri("", false, "AV19ClientePix", AV19ClientePix);
               AV48ClienteDepositoTipo = A588PropostaPacienteDepositoTipo;
            }
            AV11ProcedimentosMedicosId = A376ProcedimentosMedicosId;
            AssignAttri("", false, "AV11ProcedimentosMedicosId", StringUtil.LTrimStr( (decimal)(AV11ProcedimentosMedicosId), 9, 0));
            AV14ConvenioId = A410ConvenioId;
            AssignAttri("", false, "AV14ConvenioId", StringUtil.LTrimStr( (decimal)(AV14ConvenioId), 9, 0));
            AV15ConvenioCategoriaId = A493ConvenioCategoriaId;
            AssignAttri("", false, "AV15ConvenioCategoriaId", StringUtil.LTrimStr( (decimal)(AV15ConvenioCategoriaId), 9, 0));
            AV26ClienteRazaoSocial = A505PropostaPacienteClienteRazaoSocial;
            AssignAttri("", false, "AV26ClienteRazaoSocial", AV26ClienteRazaoSocial);
            AV27ClienteDocumento = A540PropostaPacienteClienteDocumento;
            AssignAttri("", false, "AV27ClienteDocumento", AV27ClienteDocumento);
            AV28ContatoEmail = A541PropostaPacienteContatoEmail;
            AssignAttri("", false, "AV28ContatoEmail", AV28ContatoEmail);
            AV24ResponsavelClienteDocumento = A580PropostaResponsavelDocumento;
            AV23ResponsavelClienteRazaoSocial = A581PropostaResponsavelRazaoSocial;
            AV25ResponsavelContatoEmail = A582PropostaResponsavelEmail;
            AV43ProcedimentosMedicosDescricao = A378ProcedimentosMedicosDescricao;
            AV12PropostaValor = A326PropostaValor;
            AssignAttri("", false, "AV12PropostaValor", StringUtil.LTrimStr( AV12PropostaValor, 18, 2));
            AV13PropostaDescricao = A325PropostaDescricao;
            AssignAttri("", false, "AV13PropostaDescricao", AV13PropostaDescricao);
            AV45ConvenioCategoriaDescricao = A494ConvenioCategoriaDescricao;
            AV15ConvenioCategoriaId = A493ConvenioCategoriaId;
            AssignAttri("", false, "AV15ConvenioCategoriaId", StringUtil.LTrimStr( (decimal)(AV15ConvenioCategoriaId), 9, 0));
            AV44ConvenioDescricao = A411ConvenioDescricao;
            AV16ConvenioVencimentoAno = A496ConvenioVencimentoAno;
            AssignAttri("", false, "AV16ConvenioVencimentoAno", StringUtil.LTrimStr( (decimal)(AV16ConvenioVencimentoAno), 4, 0));
            AV17ConvenioVencimentoMes = A497ConvenioVencimentoMes;
            AssignAttri("", false, "AV17ConvenioVencimentoMes", StringUtil.LTrimStr( (decimal)(AV17ConvenioVencimentoMes), 4, 0));
            AV46PropostaPacienteClienteId = A504PropostaPacienteClienteId;
            AssignAttri("", false, "AV46PropostaPacienteClienteId", StringUtil.LTrimStr( (decimal)(AV46PropostaPacienteClienteId), 9, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAPACIENTECLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV46PropostaPacienteClienteId), "ZZZZZZZZ9"), context));
            AV47PropostaResponsavelId = A553PropostaResponsavelId;
            AssignAttri("", false, "AV47PropostaResponsavelId", StringUtil.LTrimStr( (decimal)(AV47PropostaResponsavelId), 9, 0));
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         edtavConveniocategoriaid_Visible = 0;
         AssignProp("", false, edtavConveniocategoriaid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavConveniocategoriaid_Visible), 5, 0), true);
         edtavConvenioid_Visible = 0;
         AssignProp("", false, edtavConvenioid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavConvenioid_Visible), 5, 0), true);
         edtavProcedimentosmedicosid_Visible = 0;
         AssignProp("", false, edtavProcedimentosmedicosid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProcedimentosmedicosid_Visible), 5, 0), true);
         edtavPropostaresponsavelid_Visible = 0;
         AssignProp("", false, edtavPropostaresponsavelid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostaresponsavelid_Visible), 5, 0), true);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and subtitle", out  GXt_char2) ;
         Combo_propostaresponsavelid_Htmltemplate = GXt_char2;
         ucCombo_propostaresponsavelid.SendProperty(context, "", false, Combo_propostaresponsavelid_Internalname, "HTMLTemplate", Combo_propostaresponsavelid_Htmltemplate);
         Dvelop_confirmpanel_aprovar_proposta_Bodycontentinternalname = edtavDvelop_confirmpanel_aprovar_proposta_comment_Internalname;
         ucDvelop_confirmpanel_aprovar_proposta.SendProperty(context, "", false, Dvelop_confirmpanel_aprovar_proposta_Internalname, "BodyContentInternalName", Dvelop_confirmpanel_aprovar_proposta_Bodycontentinternalname);
         Dvelop_confirmpanel_finalizar_analise_Bodycontentinternalname = edtavDvelop_confirmpanel_finalizar_analise_comment_Internalname;
         ucDvelop_confirmpanel_finalizar_analise.SendProperty(context, "", false, Dvelop_confirmpanel_finalizar_analise_Internalname, "BodyContentInternalName", Dvelop_confirmpanel_finalizar_analise_Bodycontentinternalname);
         /* Execute user subroutine: 'LOADCOMBOPROPOSTARESPONSAVELID' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOPROCEDIMENTOSMEDICOSID' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOCONVENIOID' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOCONVENIOCATEGORIAID' */
         S142 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S152 ();
         if (returnInSub) return;
         Griddocumentos_empowerer_Gridinternalname = subGriddocumentos_Internalname;
         ucGriddocumentos_empowerer.SendProperty(context, "", false, Griddocumentos_empowerer_Internalname, "GridInternalName", Griddocumentos_empowerer_Gridinternalname);
         subGriddocumentos_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRIDDOCUMENTOS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddocumentos_Rows), 6, 0, ".", "")));
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wcserasaww = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcserasaww_Component), StringUtil.Lower( "SerasaWW")) != 0 )
         {
            WebComp_Wcserasaww = getWebComponent(GetType(), "GeneXus.Programs", "serasaww", new Object[] {context} );
            WebComp_Wcserasaww.ComponentInit();
            WebComp_Wcserasaww.Name = "SerasaWW";
            WebComp_Wcserasaww_Component = "SerasaWW";
         }
         if ( StringUtil.Len( WebComp_Wcserasaww_Component) != 0 )
         {
            WebComp_Wcserasaww.setjustcreated();
            WebComp_Wcserasaww.componentprepare(new Object[] {(string)"W0188",(string)"",AV63Array_ClienteId.ToJSonString(false),(int)AV5PropostaId});
            WebComp_Wcserasaww.componentbind(new Object[] {(string)""+"",(string)""});
         }
         Dvelop_confirmpanel_finalizar_analise_Yesbuttoncaption = "Aprovar análise";
         ucDvelop_confirmpanel_finalizar_analise.SendProperty(context, "", false, Dvelop_confirmpanel_finalizar_analise_Internalname, "YesButtonCaption", Dvelop_confirmpanel_finalizar_analise_Yesbuttoncaption);
         Dvelop_confirmpanel_finalizar_analise_Nobuttoncaption = "Reprovar análise";
         ucDvelop_confirmpanel_finalizar_analise.SendProperty(context, "", false, Dvelop_confirmpanel_finalizar_analise_Internalname, "NoButtonCaption", Dvelop_confirmpanel_finalizar_analise_Nobuttoncaption);
      }

      protected void E237U2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         AV55String = "";
         AV55String = AV56WEBSESSION.Get("WpAdicionarAnexoProposta");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55String)) )
         {
            GXt_char2 = "Documento adicionado com sucesso";
            new message(context ).gxep_sucesso( ref  GXt_char2) ;
            AV56WEBSESSION.Remove("WpAdicionarAnexoProposta");
         }
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S162 ();
         if (returnInSub) return;
         cmbavPropostadocumentosstatus_Columnheaderclass = "WWColumn";
         AssignProp("", false, cmbavPropostadocumentosstatus_Internalname, "Columnheaderclass", cmbavPropostadocumentosstatus_Columnheaderclass, !bGXsfl_167_Refreshing);
         /*  Sending Event outputs  */
      }

      private void E247U2( )
      {
         /* Griddocumentos_Load Routine */
         returnInSub = false;
         /* Using cursor H007U4 */
         pr_default.execute(1, new Object[] {AV5PropostaId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A323PropostaId = H007U4_A323PropostaId[0];
            n323PropostaId = H007U4_n323PropostaId[0];
            A406DocumentosDescricao = H007U4_A406DocumentosDescricao[0];
            n406DocumentosDescricao = H007U4_n406DocumentosDescricao[0];
            A405DocumentosId = H007U4_A405DocumentosId[0];
            n405DocumentosId = H007U4_n405DocumentosId[0];
            A417PropostaDocumentosAnexoFileType = H007U4_A417PropostaDocumentosAnexoFileType[0];
            n417PropostaDocumentosAnexoFileType = H007U4_n417PropostaDocumentosAnexoFileType[0];
            A579PropostaDocumentosStatus = H007U4_A579PropostaDocumentosStatus[0];
            n579PropostaDocumentosStatus = H007U4_n579PropostaDocumentosStatus[0];
            A416PropostaDocumentosAnexoName = H007U4_A416PropostaDocumentosAnexoName[0];
            n416PropostaDocumentosAnexoName = H007U4_n416PropostaDocumentosAnexoName[0];
            A414PropostaDocumentosId = H007U4_A414PropostaDocumentosId[0];
            A651PropostaDocumentosAdm = H007U4_A651PropostaDocumentosAdm[0];
            n651PropostaDocumentosAdm = H007U4_n651PropostaDocumentosAdm[0];
            A415PropostaDocumentosAnexo = H007U4_A415PropostaDocumentosAnexo[0];
            n415PropostaDocumentosAnexo = H007U4_n415PropostaDocumentosAnexo[0];
            A406DocumentosDescricao = H007U4_A406DocumentosDescricao[0];
            n406DocumentosDescricao = H007U4_n406DocumentosDescricao[0];
            AV37DocumentosDescricao = A406DocumentosDescricao;
            AssignAttri("", false, edtavDocumentosdescricao_Internalname, AV37DocumentosDescricao);
            AV36DocumentosId = A405DocumentosId;
            AssignAttri("", false, edtavDocumentosid_Internalname, StringUtil.LTrimStr( (decimal)(AV36DocumentosId), 9, 0));
            AV39Documento = A415PropostaDocumentosAnexo;
            AssignAttri("", false, edtavDocumento_Internalname, AV39Documento);
            AV40Extensao = A417PropostaDocumentosAnexoFileType;
            AssignAttri("", false, edtavExtensao_Internalname, AV40Extensao);
            AV41PropostaDocumentosStatus = A579PropostaDocumentosStatus;
            AssignAttri("", false, cmbavPropostadocumentosstatus_Internalname, AV41PropostaDocumentosStatus);
            AV49PropostaDocumentosAnexoName = A416PropostaDocumentosAnexoName;
            AssignAttri("", false, edtavPropostadocumentosanexoname_Internalname, AV49PropostaDocumentosAnexoName);
            AV54PropostaDocumentosId = A414PropostaDocumentosId;
            AssignAttri("", false, edtavPropostadocumentosid_Internalname, StringUtil.LTrimStr( (decimal)(AV54PropostaDocumentosId), 9, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTADOCUMENTOSID"+"_"+sGXsfl_167_idx, GetSecureSignedToken( sGXsfl_167_idx, context.localUtil.Format( (decimal)(AV54PropostaDocumentosId), "ZZZZZZZZ9"), context));
            AV58PropostaDocumentosAdm = A651PropostaDocumentosAdm;
            AssignAttri("", false, chkavPropostadocumentosadm_Internalname, AV58PropostaDocumentosAdm);
            AV61Aprovar = "<i class=\"fas fa-check\"></i>";
            AssignAttri("", false, edtavAprovar_Internalname, AV61Aprovar);
            if ( StringUtil.StrCmp(AV41PropostaDocumentosStatus, "APROVADO") != 0 )
            {
               edtavAprovar_Class = "Attribute";
            }
            else
            {
               edtavAprovar_Class = "Invisible";
            }
            AV62Reprovar = "<i class=\"fas fa-ban\"></i>";
            AssignAttri("", false, edtavReprovar_Internalname, AV62Reprovar);
            if ( StringUtil.StrCmp(AV41PropostaDocumentosStatus, "APROVADO") != 0 )
            {
               edtavReprovar_Class = "Attribute";
            }
            else
            {
               edtavReprovar_Class = "Invisible";
            }
            AV29AdicionarAnexo = "<i class=\"fas fa-download\"></i>";
            AssignAttri("", false, edtavAdicionaranexo_Internalname, AV29AdicionarAnexo);
            AV59Excluir = "<i class=\"fas fa-trash-can\"></i>";
            AssignAttri("", false, edtavExcluir_Internalname, AV59Excluir);
            if ( AV58PropostaDocumentosAdm )
            {
               edtavExcluir_Class = "Attribute";
            }
            else
            {
               edtavExcluir_Class = "Invisible";
            }
            if ( StringUtil.StrCmp(AV41PropostaDocumentosStatus, "AGUARDANDO_ANALISE") == 0 )
            {
               cmbavPropostadocumentosstatus_Columnclass = "WWColumn WWColumnTag WWColumnTagInfo WWColumnTagInfoSingleCell";
            }
            else if ( StringUtil.StrCmp(AV41PropostaDocumentosStatus, "APROVADO") == 0 )
            {
               cmbavPropostadocumentosstatus_Columnclass = "WWColumn WWColumnTag WWColumnTagSuccess WWColumnTagSuccessSingleCell";
            }
            else if ( StringUtil.StrCmp(AV41PropostaDocumentosStatus, "REPROVADO") == 0 )
            {
               cmbavPropostadocumentosstatus_Columnclass = "WWColumn WWColumnTag WWColumnTagDanger WWColumnTagDangerSingleCell";
            }
            else
            {
               cmbavPropostadocumentosstatus_Columnclass = "WWColumn";
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 167;
            }
            if ( ( subGriddocumentos_Islastpage == 1 ) || ( subGriddocumentos_Rows == 0 ) || ( ( GRIDDOCUMENTOS_nCurrentRecord >= GRIDDOCUMENTOS_nFirstRecordOnPage ) && ( GRIDDOCUMENTOS_nCurrentRecord < GRIDDOCUMENTOS_nFirstRecordOnPage + subGriddocumentos_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_1672( ) ;
            }
            GRIDDOCUMENTOS_nEOF = (short)(((GRIDDOCUMENTOS_nCurrentRecord<GRIDDOCUMENTOS_nFirstRecordOnPage+subGriddocumentos_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRIDDOCUMENTOS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDDOCUMENTOS_nEOF), 1, 0, ".", "")));
            GRIDDOCUMENTOS_nCurrentRecord = (long)(GRIDDOCUMENTOS_nCurrentRecord+1);
            subGriddocumentos_Recordcount = (int)(GRIDDOCUMENTOS_nCurrentRecord);
            if ( isFullAjaxMode( ) && ! bGXsfl_167_Refreshing )
            {
               DoAjaxLoad(167, GriddocumentosRow);
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
         /*  Sending Event outputs  */
         cmbavPropostadocumentosstatus.CurrentValue = StringUtil.RTrim( AV41PropostaDocumentosStatus);
      }

      protected void E147U2( )
      {
         /* Dvelop_confirmpanel_aprovar_proposta_Close Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Dvelop_confirmpanel_aprovar_proposta_Result, "Yes") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV69DVelop_ConfirmPanel_Aprovar_Proposta_Comment)) )
         {
            /* Execute user subroutine: 'DO ACTION APROVAR_PROPOSTA' */
            S172 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E157U2( )
      {
         /* Dvelop_confirmpanel_finalizar_analise_Close Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Dvelop_confirmpanel_finalizar_analise_Result, "Yes") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV70DVelop_ConfirmPanel_Finalizar_analise_Comment)) )
         {
            /* Execute user subroutine: 'DO ACTION FINALIZAR_ANALISE' */
            S182 ();
            if (returnInSub) return;
         }
         if ( ( StringUtil.StrCmp(Dvelop_confirmpanel_finalizar_analise_Result, "No") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV70DVelop_ConfirmPanel_Finalizar_analise_Comment)) )
         {
            /* Execute user subroutine: 'DO ACTION FINALIZAR_ANALISE_REPROVADA' */
            S192 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E177U2( )
      {
         /* 'DoNovoDocumento' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpadicionaanexoproposta"+UrlEncode(StringUtil.LTrimStr(AV5PropostaId,9,0));
         context.PopUp(formatLink("wpadicionaanexoproposta") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
      }

      protected void E167U2( )
      {
         /* Dvelop_confirmpanel_excluir_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_excluir_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO EXCLUIR' */
            S202 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E187U2( )
      {
         /* 'DoConsultarCliente' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wcliente"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(AV46PropostaPacienteClienteId,9,0));
         CallWebObject(formatLink("wcliente") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E197U2( )
      {
         /* 'DoConsultarResponsavel' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wcliente"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(AV47PropostaResponsavelId,9,0));
         CallWebObject(formatLink("wcliente") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E207U2( )
      {
         /* 'DoAdicionarResponsavel' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wcliente"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
         CallWebObject(formatLink("wcliente") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E137U2( )
      {
         /* Combo_convenioid_Onoptionclicked Routine */
         returnInSub = false;
         AV14ConvenioId = (int)(Math.Round(NumberUtil.Val( Combo_convenioid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV14ConvenioId", StringUtil.LTrimStr( (decimal)(AV14ConvenioId), 9, 0));
         AV15ConvenioCategoriaId = 0;
         AssignAttri("", false, "AV15ConvenioCategoriaId", StringUtil.LTrimStr( (decimal)(AV15ConvenioCategoriaId), 9, 0));
         AV34ConvenioCategoriaId_Data.Clear();
         /* Execute user subroutine: 'LOADCOMBOCONVENIOCATEGORIAID' */
         S142 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV34ConvenioCategoriaId_Data", AV34ConvenioCategoriaId_Data);
      }

      protected void S162( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ( AV66Aprovados == 0 ) && AV67Context.gxTpr_Isaprover && ( StringUtil.StrCmp(AV68PropostaStatus, "PENDENTE") == 0 ) ) )
         {
            bttBtnaprovar_proposta_Visible = 0;
            AssignProp("", false, bttBtnaprovar_proposta_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnaprovar_proposta_Visible), 5, 0), true);
         }
         if ( ! ( ( StringUtil.StrCmp(AV68PropostaStatus, "EM_ANALISE") == 0 ) && AV67Context.gxTpr_Secuseranalista ) )
         {
            bttBtnfinalizar_analise_Visible = 0;
            AssignProp("", false, bttBtnfinalizar_analise_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnfinalizar_analise_Visible), 5, 0), true);
         }
      }

      protected void S172( )
      {
         /* 'DO ACTION APROVAR_PROPOSTA' Routine */
         returnInSub = false;
         new praprovarproposta(context ).execute(  AV5PropostaId,  AV69DVelop_ConfirmPanel_Aprovar_Proposta_Comment, out  AV65sdERro) ;
         if ( AV65sdERro.gxTpr_Status == 401 )
         {
            GX_msglist.addItem(AV65sdERro.gxTpr_Msg);
         }
         else
         {
            GXt_char2 = "Proposta aprovada com sucesso!";
            new message(context ).gxep_sucesso( ref  GXt_char2) ;
            bttBtnaprovar_proposta_Visible = 0;
            AssignProp("", false, bttBtnaprovar_proposta_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnaprovar_proposta_Visible), 5, 0), true);
         }
      }

      protected void S182( )
      {
         /* 'DO ACTION FINALIZAR_ANALISE' Routine */
         returnInSub = false;
         AV57Proposta.Load(AV5PropostaId);
         AV57Proposta.gxTpr_Propostastatus = "PENDENTE";
         AV57Proposta.gxTpr_Propostacomentarioanalise = AV70DVelop_ConfirmPanel_Finalizar_analise_Comment;
         AV57Proposta.Save();
         if ( AV57Proposta.Success() )
         {
            context.CommitDataStores("wpalterarproposta",pr_default);
            bttBtnfinalizar_analise_Visible = 0;
            AssignProp("", false, bttBtnfinalizar_analise_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnfinalizar_analise_Visible), 5, 0), true);
            GXt_char2 = "Análise aprovada!";
            new message(context ).gxep_sucesso( ref  GXt_char2) ;
         }
         else
         {
            context.RollbackDataStores("wpalterarproposta",pr_default);
            GXt_char3 = ((GeneXus.Utils.SdtMessages_Message)AV57Proposta.GetMessages().Item(1)).gxTpr_Description;
            new message(context ).gxep_erro( ref  GXt_char3) ;
            ((GeneXus.Utils.SdtMessages_Message)AV57Proposta.GetMessages().Item(1)).gxTpr_Description = GXt_char3;
         }
      }

      protected void S202( )
      {
         /* 'DO EXCLUIR' Routine */
         returnInSub = false;
         AV53PropostaDocumentos.Load(AV54PropostaDocumentosId);
         AV53PropostaDocumentos.Delete();
         if ( AV53PropostaDocumentos.Success() )
         {
            context.CommitDataStores("wpalterarproposta",pr_default);
            GXt_char3 = "Documento removido com sucesso";
            new message(context ).gxep_sucesso( ref  GXt_char3) ;
            gxgrGriddocumentos_refresh( subGriddocumentos_Rows, AV66Aprovados, AV67Context, AV68PropostaStatus, A323PropostaId, AV5PropostaId, A415PropostaDocumentosAnexo, A406DocumentosDescricao, A405DocumentosId, A417PropostaDocumentosAnexoFileType, A579PropostaDocumentosStatus, A416PropostaDocumentosAnexoName, A414PropostaDocumentosId, A651PropostaDocumentosAdm, AV46PropostaPacienteClienteId, AV71PropostaComentarioAnalise) ;
         }
         else
         {
            context.RollbackDataStores("wpalterarproposta",pr_default);
            GXt_char2 = ((GeneXus.Utils.SdtMessages_Message)AV53PropostaDocumentos.GetMessages().Item(1)).gxTpr_Description;
            new message(context ).gxep_erro( ref  GXt_char2) ;
            ((GeneXus.Utils.SdtMessages_Message)AV53PropostaDocumentos.GetMessages().Item(1)).gxTpr_Description = GXt_char2;
         }
      }

      protected void S152( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( ! ( ( StringUtil.StrCmp(AV71PropostaComentarioAnalise, "") != 0 ) ) )
         {
            edtavPropostacomentarioanalise_Visible = 0;
            AssignProp("", false, edtavPropostacomentarioanalise_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostacomentarioanalise_Visible), 5, 0), true);
            divPropostacomentarioanalise_cell_Class = "Invisible";
            AssignProp("", false, divPropostacomentarioanalise_cell_Internalname, "Class", divPropostacomentarioanalise_cell_Class, true);
         }
         else
         {
            edtavPropostacomentarioanalise_Visible = 1;
            AssignProp("", false, edtavPropostacomentarioanalise_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostacomentarioanalise_Visible), 5, 0), true);
            divPropostacomentarioanalise_cell_Class = "col-xs-12";
            AssignProp("", false, divPropostacomentarioanalise_cell_Internalname, "Class", divPropostacomentarioanalise_cell_Class, true);
         }
      }

      protected void S142( )
      {
         /* 'LOADCOMBOCONVENIOCATEGORIAID' Routine */
         returnInSub = false;
         if ( 1 == 2 )
         {
            /* Using cursor H007U5 */
            pr_default.execute(2);
            while ( (pr_default.getStatus(2) != 101) )
            {
               A495ConvenioCategoriaStatus = H007U5_A495ConvenioCategoriaStatus[0];
               n495ConvenioCategoriaStatus = H007U5_n495ConvenioCategoriaStatus[0];
               A493ConvenioCategoriaId = H007U5_A493ConvenioCategoriaId[0];
               n493ConvenioCategoriaId = H007U5_n493ConvenioCategoriaId[0];
               A494ConvenioCategoriaDescricao = H007U5_A494ConvenioCategoriaDescricao[0];
               n494ConvenioCategoriaDescricao = H007U5_n494ConvenioCategoriaDescricao[0];
               AV32Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV32Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A493ConvenioCategoriaId), 9, 0));
               AV32Combo_DataItem.gxTpr_Title = A494ConvenioCategoriaDescricao;
               AV34ConvenioCategoriaId_Data.Add(AV32Combo_DataItem, 0);
               pr_default.readNext(2);
            }
            pr_default.close(2);
            Combo_conveniocategoriaid_Selectedvalue_set = ((0==AV15ConvenioCategoriaId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV15ConvenioCategoriaId), 9, 0)));
            ucCombo_conveniocategoriaid.SendProperty(context, "", false, Combo_conveniocategoriaid_Internalname, "SelectedValue_set", Combo_conveniocategoriaid_Selectedvalue_set);
         }
         else
         {
            /* Using cursor H007U6 */
            pr_default.execute(3, new Object[] {AV14ConvenioId});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A410ConvenioId = H007U6_A410ConvenioId[0];
               n410ConvenioId = H007U6_n410ConvenioId[0];
               A495ConvenioCategoriaStatus = H007U6_A495ConvenioCategoriaStatus[0];
               n495ConvenioCategoriaStatus = H007U6_n495ConvenioCategoriaStatus[0];
               A493ConvenioCategoriaId = H007U6_A493ConvenioCategoriaId[0];
               n493ConvenioCategoriaId = H007U6_n493ConvenioCategoriaId[0];
               A494ConvenioCategoriaDescricao = H007U6_A494ConvenioCategoriaDescricao[0];
               n494ConvenioCategoriaDescricao = H007U6_n494ConvenioCategoriaDescricao[0];
               AV32Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV32Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A493ConvenioCategoriaId), 9, 0));
               AV32Combo_DataItem.gxTpr_Title = A494ConvenioCategoriaDescricao;
               AV34ConvenioCategoriaId_Data.Add(AV32Combo_DataItem, 0);
               pr_default.readNext(3);
            }
            pr_default.close(3);
            Combo_conveniocategoriaid_Selectedvalue_set = ((0==AV15ConvenioCategoriaId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV15ConvenioCategoriaId), 9, 0)));
            ucCombo_conveniocategoriaid.SendProperty(context, "", false, Combo_conveniocategoriaid_Internalname, "SelectedValue_set", Combo_conveniocategoriaid_Selectedvalue_set);
         }
      }

      protected void S132( )
      {
         /* 'LOADCOMBOCONVENIOID' Routine */
         returnInSub = false;
         /* Using cursor H007U7 */
         pr_default.execute(4);
         while ( (pr_default.getStatus(4) != 101) )
         {
            A412ConvenioStatus = H007U7_A412ConvenioStatus[0];
            A410ConvenioId = H007U7_A410ConvenioId[0];
            n410ConvenioId = H007U7_n410ConvenioId[0];
            A411ConvenioDescricao = H007U7_A411ConvenioDescricao[0];
            n411ConvenioDescricao = H007U7_n411ConvenioDescricao[0];
            AV32Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV32Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A410ConvenioId), 9, 0));
            AV32Combo_DataItem.gxTpr_Title = A411ConvenioDescricao;
            AV33ConvenioId_Data.Add(AV32Combo_DataItem, 0);
            pr_default.readNext(4);
         }
         pr_default.close(4);
         Combo_convenioid_Selectedvalue_set = ((0==AV14ConvenioId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV14ConvenioId), 9, 0)));
         ucCombo_convenioid.SendProperty(context, "", false, Combo_convenioid_Internalname, "SelectedValue_set", Combo_convenioid_Selectedvalue_set);
      }

      protected void S122( )
      {
         /* 'LOADCOMBOPROCEDIMENTOSMEDICOSID' Routine */
         returnInSub = false;
         /* Using cursor H007U8 */
         pr_default.execute(5);
         while ( (pr_default.getStatus(5) != 101) )
         {
            A376ProcedimentosMedicosId = H007U8_A376ProcedimentosMedicosId[0];
            n376ProcedimentosMedicosId = H007U8_n376ProcedimentosMedicosId[0];
            A378ProcedimentosMedicosDescricao = H007U8_A378ProcedimentosMedicosDescricao[0];
            n378ProcedimentosMedicosDescricao = H007U8_n378ProcedimentosMedicosDescricao[0];
            AV32Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV32Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A376ProcedimentosMedicosId), 9, 0));
            AV32Combo_DataItem.gxTpr_Title = A378ProcedimentosMedicosDescricao;
            AV31ProcedimentosMedicosId_Data.Add(AV32Combo_DataItem, 0);
            pr_default.readNext(5);
         }
         pr_default.close(5);
         Combo_procedimentosmedicosid_Selectedvalue_set = ((0==AV11ProcedimentosMedicosId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV11ProcedimentosMedicosId), 9, 0)));
         ucCombo_procedimentosmedicosid.SendProperty(context, "", false, Combo_procedimentosmedicosid_Internalname, "SelectedValue_set", Combo_procedimentosmedicosid_Selectedvalue_set);
      }

      protected void S112( )
      {
         /* 'LOADCOMBOPROPOSTARESPONSAVELID' Routine */
         returnInSub = false;
         if ( 1 == 2 )
         {
            /* Using cursor H007U9 */
            pr_default.execute(6, new Object[] {AV46PropostaPacienteClienteId});
            while ( (pr_default.getStatus(6) != 101) )
            {
               A172ClienteTipoPessoa = H007U9_A172ClienteTipoPessoa[0];
               n172ClienteTipoPessoa = H007U9_n172ClienteTipoPessoa[0];
               A174ClienteStatus = H007U9_A174ClienteStatus[0];
               n174ClienteStatus = H007U9_n174ClienteStatus[0];
               A168ClienteId = H007U9_A168ClienteId[0];
               A201ContatoEmail = H007U9_A201ContatoEmail[0];
               n201ContatoEmail = H007U9_n201ContatoEmail[0];
               A170ClienteRazaoSocial = H007U9_A170ClienteRazaoSocial[0];
               n170ClienteRazaoSocial = H007U9_n170ClienteRazaoSocial[0];
               AV32Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV32Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A168ClienteId), 9, 0));
               AV30ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
               AV30ComboTitles.Add(A170ClienteRazaoSocial, 0);
               AV30ComboTitles.Add(A201ContatoEmail, 0);
               AV32Combo_DataItem.gxTpr_Title = AV30ComboTitles.ToJSonString(false);
               AV72PropostaResponsavelId_Data.Add(AV32Combo_DataItem, 0);
               pr_default.readNext(6);
            }
            pr_default.close(6);
            Combo_propostaresponsavelid_Selectedvalue_set = ((0==AV47PropostaResponsavelId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV47PropostaResponsavelId), 9, 0)));
            ucCombo_propostaresponsavelid.SendProperty(context, "", false, Combo_propostaresponsavelid_Internalname, "SelectedValue_set", Combo_propostaresponsavelid_Selectedvalue_set);
         }
         else
         {
            /* Using cursor H007U10 */
            pr_default.execute(7, new Object[] {AV46PropostaPacienteClienteId});
            while ( (pr_default.getStatus(7) != 101) )
            {
               A172ClienteTipoPessoa = H007U10_A172ClienteTipoPessoa[0];
               n172ClienteTipoPessoa = H007U10_n172ClienteTipoPessoa[0];
               A174ClienteStatus = H007U10_A174ClienteStatus[0];
               n174ClienteStatus = H007U10_n174ClienteStatus[0];
               A168ClienteId = H007U10_A168ClienteId[0];
               A169ClienteDocumento = H007U10_A169ClienteDocumento[0];
               n169ClienteDocumento = H007U10_n169ClienteDocumento[0];
               A201ContatoEmail = H007U10_A201ContatoEmail[0];
               n201ContatoEmail = H007U10_n201ContatoEmail[0];
               A170ClienteRazaoSocial = H007U10_A170ClienteRazaoSocial[0];
               n170ClienteRazaoSocial = H007U10_n170ClienteRazaoSocial[0];
               AV32Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV32Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A168ClienteId), 9, 0));
               AV30ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
               AV30ComboTitles.Add(StringUtil.Format( "%1 - %2", A170ClienteRazaoSocial, A169ClienteDocumento, "", "", "", "", "", "", ""), 0);
               AV30ComboTitles.Add(A201ContatoEmail, 0);
               AV32Combo_DataItem.gxTpr_Title = AV30ComboTitles.ToJSonString(false);
               AV72PropostaResponsavelId_Data.Add(AV32Combo_DataItem, 0);
               pr_default.readNext(7);
            }
            pr_default.close(7);
            Combo_propostaresponsavelid_Selectedvalue_set = ((0==AV47PropostaResponsavelId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV47PropostaResponsavelId), 9, 0)));
            ucCombo_propostaresponsavelid.SendProperty(context, "", false, Combo_propostaresponsavelid_Internalname, "SelectedValue_set", Combo_propostaresponsavelid_Selectedvalue_set);
         }
      }

      protected void E257U2( )
      {
         /* Adicionaranexo_Click Routine */
         returnInSub = false;
         AV53PropostaDocumentos = new SdtPropostaDocumentos(context);
         AV53PropostaDocumentos.Load(AV54PropostaDocumentosId);
         AV50GUID = Guid.NewGuid( );
         AV51Source = "./PrivateTempStorage/" + StringUtil.Trim( AV50GUID.ToString()) + ".pdf";
         AV52File = new GxFile(context.GetPhysicalPath());
         AV52File.Source = AV51Source;
         AV52File.FromBase64(context.FileToBase64( AV53PropostaDocumentos.gxTpr_Propostadocumentosanexo));
         AV52File.Create();
         Novajanela_Target = AV51Source;
         ucNovajanela.SendProperty(context, "", false, Novajanela_Internalname, "Target", Novajanela_Target);
         this.executeUsercontrolMethod("", false, "NOVAJANELAContainer", "OpenWindow", "", new Object[] {});
         /*  Sending Event outputs  */
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E217U2 ();
         if (returnInSub) return;
      }

      protected void E217U2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV60IsContinue = true;
         if ( ( AV12PropostaValor <= Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Valor deve ser maior que 0",  "error",  edtavPropostavalor_Internalname,  "false",  ""));
            AV60IsContinue = false;
         }
         if ( AV11ProcedimentosMedicosId <= 0 )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Selecione um procedimento",  "error",  edtavProcedimentosmedicosid_Internalname,  "false",  ""));
            AV60IsContinue = false;
         }
         if ( AV14ConvenioId <= 0 )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Selecione um convênio",  "error",  edtavConvenioid_Internalname,  "false",  ""));
            AV60IsContinue = false;
         }
         if ( AV15ConvenioCategoriaId <= 0 )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Selecione uma categoria de convênio",  "error",  edtavConveniocategoriaid_Internalname,  "false",  ""));
            AV60IsContinue = false;
         }
         if ( AV16ConvenioVencimentoAno <= 0 )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Selecione um ano",  "error",  cmbavConveniovencimentoano_Internalname,  "false",  ""));
            AV60IsContinue = false;
         }
         if ( AV17ConvenioVencimentoMes <= 0 )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Selecione um mês",  "error",  cmbavConveniovencimentomes_Internalname,  "false",  ""));
            AV60IsContinue = false;
         }
         if ( AV60IsContinue )
         {
            AV57Proposta.Load(AV5PropostaId);
            AV57Proposta.gxTpr_Propostavalor = AV12PropostaValor;
            AV57Proposta.gxTpr_Procedimentosmedicosid = AV11ProcedimentosMedicosId;
            AV57Proposta.gxTpr_Conveniocategoriaid = AV15ConvenioCategoriaId;
            AV57Proposta.gxTpr_Propostadescricao = AV13PropostaDescricao;
            AV57Proposta.gxTpr_Conveniovencimentoano = AV16ConvenioVencimentoAno;
            AV57Proposta.gxTpr_Conveniovencimentomes = AV17ConvenioVencimentoMes;
            AV57Proposta.gxTpr_Propostaresponsavelid = AV47PropostaResponsavelId;
            AV57Proposta.Save();
            if ( AV57Proposta.Success() )
            {
               context.CommitDataStores("wpalterarproposta",pr_default);
               GXt_char3 = "Alterações gravadas com sucesso!";
               new message(context ).gxep_sucesso( ref  GXt_char3) ;
            }
            else
            {
               context.RollbackDataStores("wpalterarproposta",pr_default);
               GXt_char2 = ((GeneXus.Utils.SdtMessages_Message)AV57Proposta.GetMessages().Item(1)).gxTpr_Description;
               new message(context ).gxep_erro( ref  GXt_char2) ;
               ((GeneXus.Utils.SdtMessages_Message)AV57Proposta.GetMessages().Item(1)).gxTpr_Description = GXt_char2;
            }
         }
      }

      protected void E267U2( )
      {
         /* Aprovar_Click Routine */
         returnInSub = false;
         AV53PropostaDocumentos.Load(AV54PropostaDocumentosId);
         AV53PropostaDocumentos.gxTpr_Propostadocumentosstatus = "APROVADO";
         AV53PropostaDocumentos.Save();
         if ( AV53PropostaDocumentos.Success() )
         {
            context.CommitDataStores("wpalterarproposta",pr_default);
            GXt_char3 = "Documento aprovado com sucesso.";
            new message(context ).gxep_sucesso( ref  GXt_char3) ;
            gxgrGriddocumentos_refresh( subGriddocumentos_Rows, AV66Aprovados, AV67Context, AV68PropostaStatus, A323PropostaId, AV5PropostaId, A415PropostaDocumentosAnexo, A406DocumentosDescricao, A405DocumentosId, A417PropostaDocumentosAnexoFileType, A579PropostaDocumentosStatus, A416PropostaDocumentosAnexoName, A414PropostaDocumentosId, A651PropostaDocumentosAdm, AV46PropostaPacienteClienteId, AV71PropostaComentarioAnalise) ;
         }
         else
         {
            context.RollbackDataStores("wpalterarproposta",pr_default);
            GXt_char2 = ((GeneXus.Utils.SdtMessages_Message)AV53PropostaDocumentos.GetMessages().Item(1)).gxTpr_Description;
            new message(context ).gxep_erro( ref  GXt_char2) ;
            ((GeneXus.Utils.SdtMessages_Message)AV53PropostaDocumentos.GetMessages().Item(1)).gxTpr_Description = GXt_char2;
         }
         /*  Sending Event outputs  */
      }

      protected void E277U2( )
      {
         /* Reprovar_Click Routine */
         returnInSub = false;
         AV53PropostaDocumentos.Load(AV54PropostaDocumentosId);
         AV53PropostaDocumentos.gxTpr_Propostadocumentosstatus = "REPROVADO";
         AV53PropostaDocumentos.Save();
         if ( AV53PropostaDocumentos.Success() )
         {
            context.CommitDataStores("wpalterarproposta",pr_default);
            new prenviaemaildocumentorejeitadoproposta(context).executeSubmit(  AV5PropostaId) ;
            GXt_char3 = "Documento reprovado com sucesso.";
            new message(context ).gxep_sucesso( ref  GXt_char3) ;
            gxgrGriddocumentos_refresh( subGriddocumentos_Rows, AV66Aprovados, AV67Context, AV68PropostaStatus, A323PropostaId, AV5PropostaId, A415PropostaDocumentosAnexo, A406DocumentosDescricao, A405DocumentosId, A417PropostaDocumentosAnexoFileType, A579PropostaDocumentosStatus, A416PropostaDocumentosAnexoName, A414PropostaDocumentosId, A651PropostaDocumentosAdm, AV46PropostaPacienteClienteId, AV71PropostaComentarioAnalise) ;
         }
         else
         {
            context.RollbackDataStores("wpalterarproposta",pr_default);
            GXt_char2 = ((GeneXus.Utils.SdtMessages_Message)AV53PropostaDocumentos.GetMessages().Item(1)).gxTpr_Description;
            new message(context ).gxep_erro( ref  GXt_char2) ;
            ((GeneXus.Utils.SdtMessages_Message)AV53PropostaDocumentos.GetMessages().Item(1)).gxTpr_Description = GXt_char2;
         }
         /*  Sending Event outputs  */
      }

      protected void S192( )
      {
         /* 'DO ACTION FINALIZAR_ANALISE_REPROVADA' Routine */
         returnInSub = false;
         AV57Proposta.Load(AV5PropostaId);
         AV57Proposta.gxTpr_Propostastatus = "AnaliseReprovada";
         AV57Proposta.gxTpr_Propostacomentarioanalise = AV70DVelop_ConfirmPanel_Finalizar_analise_Comment;
         AV57Proposta.Save();
         if ( AV57Proposta.Success() )
         {
            context.CommitDataStores("wpalterarproposta",pr_default);
            bttBtnfinalizar_analise_Visible = 0;
            AssignProp("", false, bttBtnfinalizar_analise_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnfinalizar_analise_Visible), 5, 0), true);
            GXt_char3 = "Análise reprovada";
            new message(context ).gxep_sucesso( ref  GXt_char3) ;
         }
         else
         {
            context.RollbackDataStores("wpalterarproposta",pr_default);
            GXt_char2 = ((GeneXus.Utils.SdtMessages_Message)AV57Proposta.GetMessages().Item(1)).gxTpr_Description;
            new message(context ).gxep_erro( ref  GXt_char2) ;
            ((GeneXus.Utils.SdtMessages_Message)AV57Proposta.GetMessages().Item(1)).gxTpr_Description = GXt_char2;
         }
      }

      protected void wb_table5_213_7U2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_excluir_Internalname, tblTabledvelop_confirmpanel_excluir_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_excluir.SetProperty("Title", Dvelop_confirmpanel_excluir_Title);
            ucDvelop_confirmpanel_excluir.SetProperty("ConfirmationText", Dvelop_confirmpanel_excluir_Confirmationtext);
            ucDvelop_confirmpanel_excluir.SetProperty("YesButtonCaption", Dvelop_confirmpanel_excluir_Yesbuttoncaption);
            ucDvelop_confirmpanel_excluir.SetProperty("NoButtonCaption", Dvelop_confirmpanel_excluir_Nobuttoncaption);
            ucDvelop_confirmpanel_excluir.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_excluir_Cancelbuttoncaption);
            ucDvelop_confirmpanel_excluir.SetProperty("YesButtonPosition", Dvelop_confirmpanel_excluir_Yesbuttonposition);
            ucDvelop_confirmpanel_excluir.SetProperty("ConfirmType", Dvelop_confirmpanel_excluir_Confirmtype);
            ucDvelop_confirmpanel_excluir.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_excluir_Internalname, "DVELOP_CONFIRMPANEL_EXCLUIRContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVELOP_CONFIRMPANEL_EXCLUIRContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_213_7U2e( true) ;
         }
         else
         {
            wb_table5_213_7U2e( false) ;
         }
      }

      protected void wb_table4_206_7U2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_finalizar_analise_Internalname, tblTabledvelop_confirmpanel_finalizar_analise_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_finalizar_analise.SetProperty("Title", Dvelop_confirmpanel_finalizar_analise_Title);
            ucDvelop_confirmpanel_finalizar_analise.SetProperty("ConfirmationText", Dvelop_confirmpanel_finalizar_analise_Confirmationtext);
            ucDvelop_confirmpanel_finalizar_analise.SetProperty("YesButtonCaption", Dvelop_confirmpanel_finalizar_analise_Yesbuttoncaption);
            ucDvelop_confirmpanel_finalizar_analise.SetProperty("NoButtonCaption", Dvelop_confirmpanel_finalizar_analise_Nobuttoncaption);
            ucDvelop_confirmpanel_finalizar_analise.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_finalizar_analise_Cancelbuttoncaption);
            ucDvelop_confirmpanel_finalizar_analise.SetProperty("YesButtonPosition", Dvelop_confirmpanel_finalizar_analise_Yesbuttonposition);
            ucDvelop_confirmpanel_finalizar_analise.SetProperty("ConfirmType", Dvelop_confirmpanel_finalizar_analise_Confirmtype);
            ucDvelop_confirmpanel_finalizar_analise.SetProperty("Comment", Dvelop_confirmpanel_finalizar_analise_Comment);
            ucDvelop_confirmpanel_finalizar_analise.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_finalizar_analise_Internalname, "DVELOP_CONFIRMPANEL_FINALIZAR_ANALISEContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVELOP_CONFIRMPANEL_FINALIZAR_ANALISEContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_206_7U2e( true) ;
         }
         else
         {
            wb_table4_206_7U2e( false) ;
         }
      }

      protected void wb_table3_199_7U2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_aprovar_proposta_Internalname, tblTabledvelop_confirmpanel_aprovar_proposta_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_aprovar_proposta.SetProperty("Title", Dvelop_confirmpanel_aprovar_proposta_Title);
            ucDvelop_confirmpanel_aprovar_proposta.SetProperty("ConfirmationText", Dvelop_confirmpanel_aprovar_proposta_Confirmationtext);
            ucDvelop_confirmpanel_aprovar_proposta.SetProperty("YesButtonCaption", Dvelop_confirmpanel_aprovar_proposta_Yesbuttoncaption);
            ucDvelop_confirmpanel_aprovar_proposta.SetProperty("NoButtonCaption", Dvelop_confirmpanel_aprovar_proposta_Nobuttoncaption);
            ucDvelop_confirmpanel_aprovar_proposta.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_aprovar_proposta_Cancelbuttoncaption);
            ucDvelop_confirmpanel_aprovar_proposta.SetProperty("YesButtonPosition", Dvelop_confirmpanel_aprovar_proposta_Yesbuttonposition);
            ucDvelop_confirmpanel_aprovar_proposta.SetProperty("ConfirmType", Dvelop_confirmpanel_aprovar_proposta_Confirmtype);
            ucDvelop_confirmpanel_aprovar_proposta.SetProperty("Comment", Dvelop_confirmpanel_aprovar_proposta_Comment);
            ucDvelop_confirmpanel_aprovar_proposta.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_aprovar_proposta_Internalname, "DVELOP_CONFIRMPANEL_APROVAR_PROPOSTAContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVELOP_CONFIRMPANEL_APROVAR_PROPOSTAContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_199_7U2e( true) ;
         }
         else
         {
            wb_table3_199_7U2e( false) ;
         }
      }

      protected void wb_table2_149_7U2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedconveniovencimentoano_Internalname, tblTablemergedconveniovencimentoano_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavConveniovencimentoano_Internalname, "Convenio Vencimento Ano", "gx-form-item AttributeFLLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 153,'',false,'" + sGXsfl_167_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavConveniovencimentoano, cmbavConveniovencimentoano_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV16ConvenioVencimentoAno), 4, 0)), 1, cmbavConveniovencimentoano_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavConveniovencimentoano.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,153);\"", "", true, 0, "HLP_WpAlterarProposta.htm");
            cmbavConveniovencimentoano.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16ConvenioVencimentoAno), 4, 0));
            AssignProp("", false, cmbavConveniovencimentoano_Internalname, "Values", (string)(cmbavConveniovencimentoano.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='DataContentCellFL'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+cmbavConveniovencimentomes_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavConveniovencimentomes_Internalname, "Mês vencimento carteira", "gx-form-item AttributeFLLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 157,'',false,'" + sGXsfl_167_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavConveniovencimentomes, cmbavConveniovencimentomes_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV17ConvenioVencimentoMes), 4, 0)), 1, cmbavConveniovencimentomes_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavConveniovencimentomes.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,157);\"", "", true, 0, "HLP_WpAlterarProposta.htm");
            cmbavConveniovencimentomes.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17ConvenioVencimentoMes), 4, 0));
            AssignProp("", false, cmbavConveniovencimentomes_Internalname, "Values", (string)(cmbavConveniovencimentomes.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_149_7U2e( true) ;
         }
         else
         {
            wb_table2_149_7U2e( false) ;
         }
      }

      protected void wb_table1_69_7U2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedpropostaresponsavelid_Internalname, tblTablemergedpropostaresponsavelid_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* User Defined Control */
            ucCombo_propostaresponsavelid.SetProperty("Caption", Combo_propostaresponsavelid_Caption);
            ucCombo_propostaresponsavelid.SetProperty("Cls", Combo_propostaresponsavelid_Cls);
            ucCombo_propostaresponsavelid.SetProperty("EmptyItem", Combo_propostaresponsavelid_Emptyitem);
            ucCombo_propostaresponsavelid.SetProperty("DropDownOptionsData", AV72PropostaResponsavelId_Data);
            ucCombo_propostaresponsavelid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_propostaresponsavelid_Internalname, "COMBO_PROPOSTARESPONSAVELIDContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblConsultarresponsavel_Internalname, "<i class=\"fas fa-magnifying-glass\"></i>", "", "", lblConsultarresponsavel_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOCONSULTARRESPONSAVEL\\'."+"'", "", "TextBlock", 5, "Consultar responsável", 1, 1, 0, 1, "HLP_WpAlterarProposta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblAdicionarresponsavel_Internalname, "<i class=\"fas fa-user-plus\"></i>", "", "", lblAdicionarresponsavel_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOADICIONARRESPONSAVEL\\'."+"'", "", "TextBlock", 5, "Adicionar cliente / responsável", 1, 1, 0, 1, "HLP_WpAlterarProposta.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_69_7U2e( true) ;
         }
         else
         {
            wb_table1_69_7U2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV5PropostaId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV5PropostaId", StringUtil.LTrimStr( (decimal)(AV5PropostaId), 9, 0));
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
         PA7U2( ) ;
         WS7U2( ) ;
         WE7U2( ) ;
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
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wcserasaww == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcserasaww_Component) != 0 )
            {
               WebComp_Wcserasaww.componentthemes();
            }
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019275167", true, true);
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
         context.AddJavascriptSource("wpalterarproposta.js", "?202561019275168", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1672( )
      {
         edtavAprovar_Internalname = "vAPROVAR_"+sGXsfl_167_idx;
         edtavReprovar_Internalname = "vREPROVAR_"+sGXsfl_167_idx;
         edtavAdicionaranexo_Internalname = "vADICIONARANEXO_"+sGXsfl_167_idx;
         edtavExcluir_Internalname = "vEXCLUIR_"+sGXsfl_167_idx;
         edtavDocumentosid_Internalname = "vDOCUMENTOSID_"+sGXsfl_167_idx;
         edtavDocumentosdescricao_Internalname = "vDOCUMENTOSDESCRICAO_"+sGXsfl_167_idx;
         cmbavDocumentoobrigatorio_Internalname = "vDOCUMENTOOBRIGATORIO_"+sGXsfl_167_idx;
         edtavPropostadocumentosanexoname_Internalname = "vPROPOSTADOCUMENTOSANEXONAME_"+sGXsfl_167_idx;
         edtavDocumento_Internalname = "vDOCUMENTO_"+sGXsfl_167_idx;
         edtavExtensao_Internalname = "vEXTENSAO_"+sGXsfl_167_idx;
         cmbavPropostadocumentosstatus_Internalname = "vPROPOSTADOCUMENTOSSTATUS_"+sGXsfl_167_idx;
         edtavPropostadocumentosid_Internalname = "vPROPOSTADOCUMENTOSID_"+sGXsfl_167_idx;
         chkavPropostadocumentosadm_Internalname = "vPROPOSTADOCUMENTOSADM_"+sGXsfl_167_idx;
      }

      protected void SubsflControlProps_fel_1672( )
      {
         edtavAprovar_Internalname = "vAPROVAR_"+sGXsfl_167_fel_idx;
         edtavReprovar_Internalname = "vREPROVAR_"+sGXsfl_167_fel_idx;
         edtavAdicionaranexo_Internalname = "vADICIONARANEXO_"+sGXsfl_167_fel_idx;
         edtavExcluir_Internalname = "vEXCLUIR_"+sGXsfl_167_fel_idx;
         edtavDocumentosid_Internalname = "vDOCUMENTOSID_"+sGXsfl_167_fel_idx;
         edtavDocumentosdescricao_Internalname = "vDOCUMENTOSDESCRICAO_"+sGXsfl_167_fel_idx;
         cmbavDocumentoobrigatorio_Internalname = "vDOCUMENTOOBRIGATORIO_"+sGXsfl_167_fel_idx;
         edtavPropostadocumentosanexoname_Internalname = "vPROPOSTADOCUMENTOSANEXONAME_"+sGXsfl_167_fel_idx;
         edtavDocumento_Internalname = "vDOCUMENTO_"+sGXsfl_167_fel_idx;
         edtavExtensao_Internalname = "vEXTENSAO_"+sGXsfl_167_fel_idx;
         cmbavPropostadocumentosstatus_Internalname = "vPROPOSTADOCUMENTOSSTATUS_"+sGXsfl_167_fel_idx;
         edtavPropostadocumentosid_Internalname = "vPROPOSTADOCUMENTOSID_"+sGXsfl_167_fel_idx;
         chkavPropostadocumentosadm_Internalname = "vPROPOSTADOCUMENTOSADM_"+sGXsfl_167_fel_idx;
      }

      protected void sendrow_1672( )
      {
         sGXsfl_167_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_167_idx), 4, 0), 4, "0");
         SubsflControlProps_1672( ) ;
         WB7U0( ) ;
         if ( ( subGriddocumentos_Rows * 1 == 0 ) || ( nGXsfl_167_idx <= subGriddocumentos_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_167_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_167_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GriddocumentosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 168,'',false,'" + sGXsfl_167_idx + "',167)\"";
            ROClassString = edtavAprovar_Class;
            GriddocumentosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavAprovar_Internalname,StringUtil.RTrim( AV61Aprovar),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,168);\"","'"+""+"'"+",false,"+"'"+"EVAPROVAR.CLICK."+sGXsfl_167_idx+"'",(string)"",(string)"",(string)"Aprovar",(string)"",(string)edtavAprovar_Jsonclick,(short)5,(string)edtavAprovar_Class,(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavAprovar_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)167,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GriddocumentosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 169,'',false,'" + sGXsfl_167_idx + "',167)\"";
            ROClassString = edtavReprovar_Class;
            GriddocumentosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavReprovar_Internalname,StringUtil.RTrim( AV62Reprovar),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,169);\"","'"+""+"'"+",false,"+"'"+"EVREPROVAR.CLICK."+sGXsfl_167_idx+"'",(string)"",(string)"",(string)"Reprovar",(string)"",(string)edtavReprovar_Jsonclick,(short)5,(string)edtavReprovar_Class,(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavReprovar_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)167,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GriddocumentosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 170,'',false,'" + sGXsfl_167_idx + "',167)\"";
            ROClassString = "Attribute";
            GriddocumentosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavAdicionaranexo_Internalname,StringUtil.RTrim( AV29AdicionarAnexo),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,170);\"","'"+""+"'"+",false,"+"'"+"EVADICIONARANEXO.CLICK."+sGXsfl_167_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavAdicionaranexo_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavAdicionaranexo_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)167,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GriddocumentosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 171,'',false,'" + sGXsfl_167_idx + "',167)\"";
            ROClassString = edtavExcluir_Class;
            GriddocumentosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavExcluir_Internalname,StringUtil.RTrim( AV59Excluir),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,171);\"",(string)"'"+""+"'"+",false,"+"'"+"e287u2_client"+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavExcluir_Jsonclick,(short)7,(string)edtavExcluir_Class,(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavExcluir_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)167,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GriddocumentosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GriddocumentosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDocumentosid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV36DocumentosId), 9, 0, ",", "")),StringUtil.LTrim( ((edtavDocumentosid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV36DocumentosId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV36DocumentosId), "ZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+""+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDocumentosid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavDocumentosid_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)167,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GriddocumentosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 173,'',false,'" + sGXsfl_167_idx + "',167)\"";
            ROClassString = "Attribute";
            GriddocumentosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDocumentosdescricao_Internalname,(string)AV37DocumentosDescricao,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,173);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDocumentosdescricao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavDocumentosdescricao_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)167,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GriddocumentosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( cmbavDocumentoobrigatorio.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vDOCUMENTOOBRIGATORIO_" + sGXsfl_167_idx;
               cmbavDocumentoobrigatorio.Name = GXCCtl;
               cmbavDocumentoobrigatorio.WebTags = "";
               cmbavDocumentoobrigatorio.addItem(StringUtil.BoolToStr( true), "Sim", 0);
               cmbavDocumentoobrigatorio.addItem(StringUtil.BoolToStr( false), "Não", 0);
               if ( cmbavDocumentoobrigatorio.ItemCount > 0 )
               {
                  AV38DocumentoObrigatorio = StringUtil.StrToBool( cmbavDocumentoobrigatorio.getValidValue(StringUtil.BoolToStr( AV38DocumentoObrigatorio)));
                  AssignAttri("", false, cmbavDocumentoobrigatorio_Internalname, AV38DocumentoObrigatorio);
               }
            }
            /* ComboBox */
            GriddocumentosRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavDocumentoobrigatorio,(string)cmbavDocumentoobrigatorio_Internalname,StringUtil.BoolToStr( AV38DocumentoObrigatorio),(short)1,(string)cmbavDocumentoobrigatorio_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"boolean",(string)"",(short)0,cmbavDocumentoobrigatorio.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"",(bool)true,(short)0});
            cmbavDocumentoobrigatorio.CurrentValue = StringUtil.BoolToStr( AV38DocumentoObrigatorio);
            AssignProp("", false, cmbavDocumentoobrigatorio_Internalname, "Values", (string)(cmbavDocumentoobrigatorio.ToJavascriptSource()), !bGXsfl_167_Refreshing);
            /* Subfile cell */
            if ( GriddocumentosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 175,'',false,'" + sGXsfl_167_idx + "',167)\"";
            ROClassString = "Attribute";
            GriddocumentosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavPropostadocumentosanexoname_Internalname,(string)AV49PropostaDocumentosAnexoName,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,175);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavPropostadocumentosanexoname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavPropostadocumentosanexoname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)128,(short)0,(short)0,(short)167,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GriddocumentosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            ClassString = "Attribute";
            StyleString = "";
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 176,'',false,'" + sGXsfl_167_idx + "',167)\"";
            edtavDocumento_Filetype = "tmp";
            AssignProp("", false, edtavDocumento_Internalname, "Filetype", edtavDocumento_Filetype, !bGXsfl_167_Refreshing);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39Documento)) )
            {
               gxblobfileaux.Source = AV39Documento;
               if ( ! gxblobfileaux.HasExtension() || ( StringUtil.StrCmp(edtavDocumento_Filetype, "tmp") != 0 ) )
               {
                  gxblobfileaux.SetExtension(StringUtil.Trim( edtavDocumento_Filetype));
               }
               if ( gxblobfileaux.ErrCode == 0 )
               {
                  AV39Documento = gxblobfileaux.GetURI();
                  AssignProp("", false, edtavDocumento_Internalname, "URL", context.PathToRelativeUrl( AV39Documento), !bGXsfl_167_Refreshing);
                  edtavDocumento_Filetype = gxblobfileaux.GetExtension();
                  AssignProp("", false, edtavDocumento_Internalname, "Filetype", edtavDocumento_Filetype, !bGXsfl_167_Refreshing);
               }
               AssignProp("", false, edtavDocumento_Internalname, "URL", context.PathToRelativeUrl( AV39Documento), !bGXsfl_167_Refreshing);
            }
            GriddocumentosRow.AddColumnProperties("blob", 2, isAjaxCallMode( ), new Object[] {(string)edtavDocumento_Internalname,StringUtil.RTrim( AV39Documento),context.PathToRelativeUrl( AV39Documento),(String.IsNullOrEmpty(StringUtil.RTrim( edtavDocumento_Contenttype)) ? context.GetContentType( (String.IsNullOrEmpty(StringUtil.RTrim( edtavDocumento_Filetype)) ? AV39Documento : edtavDocumento_Filetype)) : edtavDocumento_Contenttype),(bool)false,(string)"",(string)edtavDocumento_Parameters,(short)0,(int)edtavDocumento_Enabled,(short)-1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)60,(string)"px",(short)0,(short)0,(short)0,(string)edtavDocumento_Jsonclick,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",""+TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,176);\"",(string)"",(string)""});
            /* Subfile cell */
            if ( GriddocumentosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 177,'',false,'" + sGXsfl_167_idx + "',167)\"";
            ROClassString = "Attribute";
            GriddocumentosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavExtensao_Internalname,(string)AV40Extensao,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,177);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavExtensao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavExtensao_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)167,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GriddocumentosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 178,'',false,'" + sGXsfl_167_idx + "',167)\"";
            if ( ( cmbavPropostadocumentosstatus.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vPROPOSTADOCUMENTOSSTATUS_" + sGXsfl_167_idx;
               cmbavPropostadocumentosstatus.Name = GXCCtl;
               cmbavPropostadocumentosstatus.WebTags = "";
               cmbavPropostadocumentosstatus.addItem("AGUARDANDO_ANALISE", "Aguardando análise", 0);
               cmbavPropostadocumentosstatus.addItem("APROVADO", "Aprovado", 0);
               cmbavPropostadocumentosstatus.addItem("REPROVADO", "Reprovado", 0);
               if ( cmbavPropostadocumentosstatus.ItemCount > 0 )
               {
                  AV41PropostaDocumentosStatus = cmbavPropostadocumentosstatus.getValidValue(AV41PropostaDocumentosStatus);
                  AssignAttri("", false, cmbavPropostadocumentosstatus_Internalname, AV41PropostaDocumentosStatus);
               }
            }
            /* ComboBox */
            GriddocumentosRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavPropostadocumentosstatus,(string)cmbavPropostadocumentosstatus_Internalname,StringUtil.RTrim( AV41PropostaDocumentosStatus),(short)1,(string)cmbavPropostadocumentosstatus_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,cmbavPropostadocumentosstatus.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)cmbavPropostadocumentosstatus_Columnclass,(string)cmbavPropostadocumentosstatus_Columnheaderclass,TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,178);\"",(string)"",(bool)true,(short)0});
            cmbavPropostadocumentosstatus.CurrentValue = StringUtil.RTrim( AV41PropostaDocumentosStatus);
            AssignProp("", false, cmbavPropostadocumentosstatus_Internalname, "Values", (string)(cmbavPropostadocumentosstatus.ToJavascriptSource()), !bGXsfl_167_Refreshing);
            /* Subfile cell */
            if ( GriddocumentosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GriddocumentosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavPropostadocumentosid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV54PropostaDocumentosId), 9, 0, ",", "")),StringUtil.LTrim( ((edtavPropostadocumentosid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV54PropostaDocumentosId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV54PropostaDocumentosId), "ZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+""+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavPropostadocumentosid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavPropostadocumentosid_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)167,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GriddocumentosContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "vPROPOSTADOCUMENTOSADM_" + sGXsfl_167_idx;
            chkavPropostadocumentosadm.Name = GXCCtl;
            chkavPropostadocumentosadm.WebTags = "";
            chkavPropostadocumentosadm.Caption = "";
            AssignProp("", false, chkavPropostadocumentosadm_Internalname, "TitleCaption", chkavPropostadocumentosadm.Caption, !bGXsfl_167_Refreshing);
            chkavPropostadocumentosadm.CheckedValue = "false";
            AV58PropostaDocumentosAdm = StringUtil.StrToBool( StringUtil.BoolToStr( AV58PropostaDocumentosAdm));
            AssignAttri("", false, chkavPropostadocumentosadm_Internalname, AV58PropostaDocumentosAdm);
            GriddocumentosRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavPropostadocumentosadm_Internalname,StringUtil.BoolToStr( AV58PropostaDocumentosAdm),(string)"",(string)"",(short)0,chkavPropostadocumentosadm.Enabled,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)""});
            send_integrity_lvl_hashes7U2( ) ;
            GriddocumentosContainer.AddRow(GriddocumentosRow);
            nGXsfl_167_idx = ((subGriddocumentos_Islastpage==1)&&(nGXsfl_167_idx+1>subGriddocumentos_fnc_Recordsperpage( )) ? 1 : nGXsfl_167_idx+1);
            sGXsfl_167_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_167_idx), 4, 0), 4, "0");
            SubsflControlProps_1672( ) ;
         }
         /* End function sendrow_1672 */
      }

      protected void init_web_controls( )
      {
         cmbavClientepixtipo.Name = "vCLIENTEPIXTIPO";
         cmbavClientepixtipo.WebTags = "";
         cmbavClientepixtipo.addItem("CPF", "CPF", 0);
         cmbavClientepixtipo.addItem("CNPJ", "CNPJ", 0);
         cmbavClientepixtipo.addItem("Telefone", "Telefone", 0);
         cmbavClientepixtipo.addItem("Email", "E-mail", 0);
         cmbavClientepixtipo.addItem("ChaveAleatoria", "Chave aleatória", 0);
         if ( cmbavClientepixtipo.ItemCount > 0 )
         {
            AV18ClientePixTipo = cmbavClientepixtipo.getValidValue(AV18ClientePixTipo);
            AssignAttri("", false, "AV18ClientePixTipo", AV18ClientePixTipo);
         }
         cmbavConveniovencimentoano.Name = "vCONVENIOVENCIMENTOANO";
         cmbavConveniovencimentoano.WebTags = "";
         cmbavConveniovencimentoano.addItem("2024", "2024", 0);
         cmbavConveniovencimentoano.addItem("2025", "2025", 0);
         cmbavConveniovencimentoano.addItem("2026", "2026", 0);
         cmbavConveniovencimentoano.addItem("2027", "2027", 0);
         cmbavConveniovencimentoano.addItem("2028", "2028", 0);
         cmbavConveniovencimentoano.addItem("2029", "2029", 0);
         cmbavConveniovencimentoano.addItem("2030", "2030", 0);
         cmbavConveniovencimentoano.addItem("2031", "2031", 0);
         cmbavConveniovencimentoano.addItem("2032", "2032", 0);
         cmbavConveniovencimentoano.addItem("2033", "2033", 0);
         cmbavConveniovencimentoano.addItem("2034", "2034", 0);
         cmbavConveniovencimentoano.addItem("2035", "2035", 0);
         cmbavConveniovencimentoano.addItem("2036", "2036", 0);
         cmbavConveniovencimentoano.addItem("2037", "2037", 0);
         cmbavConveniovencimentoano.addItem("2038", "2038", 0);
         cmbavConveniovencimentoano.addItem("2039", "2039", 0);
         cmbavConveniovencimentoano.addItem("2040", "2040", 0);
         cmbavConveniovencimentoano.addItem("2041", "2041", 0);
         cmbavConveniovencimentoano.addItem("2042", "2042", 0);
         cmbavConveniovencimentoano.addItem("2043", "2043", 0);
         cmbavConveniovencimentoano.addItem("2044", "2044", 0);
         cmbavConveniovencimentoano.addItem("2045", "2045", 0);
         cmbavConveniovencimentoano.addItem("2046", "2046", 0);
         cmbavConveniovencimentoano.addItem("2047", "2047", 0);
         cmbavConveniovencimentoano.addItem("2048", "2048", 0);
         cmbavConveniovencimentoano.addItem("2049", "2049", 0);
         cmbavConveniovencimentoano.addItem("2050", "2050", 0);
         if ( cmbavConveniovencimentoano.ItemCount > 0 )
         {
            AV16ConvenioVencimentoAno = (short)(Math.Round(NumberUtil.Val( cmbavConveniovencimentoano.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV16ConvenioVencimentoAno), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV16ConvenioVencimentoAno", StringUtil.LTrimStr( (decimal)(AV16ConvenioVencimentoAno), 4, 0));
         }
         cmbavConveniovencimentomes.Name = "vCONVENIOVENCIMENTOMES";
         cmbavConveniovencimentomes.WebTags = "";
         cmbavConveniovencimentomes.addItem("1", "Janeiro", 0);
         cmbavConveniovencimentomes.addItem("2", "Fevereiro", 0);
         cmbavConveniovencimentomes.addItem("3", "Maço", 0);
         cmbavConveniovencimentomes.addItem("4", "Abril", 0);
         cmbavConveniovencimentomes.addItem("5", "Maio", 0);
         cmbavConveniovencimentomes.addItem("6", "Junho", 0);
         cmbavConveniovencimentomes.addItem("7", "Julho", 0);
         cmbavConveniovencimentomes.addItem("8", "Agosto", 0);
         cmbavConveniovencimentomes.addItem("9", "Setembro", 0);
         cmbavConveniovencimentomes.addItem("10", "Outubro", 0);
         cmbavConveniovencimentomes.addItem("11", "Novembro", 0);
         cmbavConveniovencimentomes.addItem("12", "Dezembro", 0);
         if ( cmbavConveniovencimentomes.ItemCount > 0 )
         {
            AV17ConvenioVencimentoMes = (short)(Math.Round(NumberUtil.Val( cmbavConveniovencimentomes.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV17ConvenioVencimentoMes), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV17ConvenioVencimentoMes", StringUtil.LTrimStr( (decimal)(AV17ConvenioVencimentoMes), 4, 0));
         }
         GXCCtl = "vDOCUMENTOOBRIGATORIO_" + sGXsfl_167_idx;
         cmbavDocumentoobrigatorio.Name = GXCCtl;
         cmbavDocumentoobrigatorio.WebTags = "";
         cmbavDocumentoobrigatorio.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbavDocumentoobrigatorio.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbavDocumentoobrigatorio.ItemCount > 0 )
         {
            AV38DocumentoObrigatorio = StringUtil.StrToBool( cmbavDocumentoobrigatorio.getValidValue(StringUtil.BoolToStr( AV38DocumentoObrigatorio)));
            AssignAttri("", false, cmbavDocumentoobrigatorio_Internalname, AV38DocumentoObrigatorio);
         }
         GXCCtl = "vPROPOSTADOCUMENTOSSTATUS_" + sGXsfl_167_idx;
         cmbavPropostadocumentosstatus.Name = GXCCtl;
         cmbavPropostadocumentosstatus.WebTags = "";
         cmbavPropostadocumentosstatus.addItem("AGUARDANDO_ANALISE", "Aguardando análise", 0);
         cmbavPropostadocumentosstatus.addItem("APROVADO", "Aprovado", 0);
         cmbavPropostadocumentosstatus.addItem("REPROVADO", "Reprovado", 0);
         if ( cmbavPropostadocumentosstatus.ItemCount > 0 )
         {
            AV41PropostaDocumentosStatus = cmbavPropostadocumentosstatus.getValidValue(AV41PropostaDocumentosStatus);
            AssignAttri("", false, cmbavPropostadocumentosstatus_Internalname, AV41PropostaDocumentosStatus);
         }
         GXCCtl = "vPROPOSTADOCUMENTOSADM_" + sGXsfl_167_idx;
         chkavPropostadocumentosadm.Name = GXCCtl;
         chkavPropostadocumentosadm.WebTags = "";
         chkavPropostadocumentosadm.Caption = "";
         AssignProp("", false, chkavPropostadocumentosadm_Internalname, "TitleCaption", chkavPropostadocumentosadm.Caption, !bGXsfl_167_Refreshing);
         chkavPropostadocumentosadm.CheckedValue = "false";
         AV58PropostaDocumentosAdm = StringUtil.StrToBool( StringUtil.BoolToStr( AV58PropostaDocumentosAdm));
         AssignAttri("", false, chkavPropostadocumentosadm_Internalname, AV58PropostaDocumentosAdm);
         /* End function init_web_controls */
      }

      protected void StartGridControl167( )
      {
         if ( GriddocumentosContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GriddocumentosContainer"+"DivS\" data-gxgridid=\"167\">") ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+edtavAprovar_Class+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+edtavReprovar_Class+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+edtavExcluir_Class+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Documentos Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Descrição") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Obrigatório") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Nome do anexo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Situação") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Proposta Documentos Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Proposta Documentos Adm") ;
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
            GriddocumentosContainer.AddObjectProperty("CmpContext", "");
            GriddocumentosContainer.AddObjectProperty("InMasterPage", "false");
            GriddocumentosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GriddocumentosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV61Aprovar)));
            GriddocumentosColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavAprovar_Class));
            GriddocumentosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavAprovar_Enabled), 5, 0, ".", "")));
            GriddocumentosContainer.AddColumnProperties(GriddocumentosColumn);
            GriddocumentosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GriddocumentosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV62Reprovar)));
            GriddocumentosColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavReprovar_Class));
            GriddocumentosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavReprovar_Enabled), 5, 0, ".", "")));
            GriddocumentosContainer.AddColumnProperties(GriddocumentosColumn);
            GriddocumentosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GriddocumentosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV29AdicionarAnexo)));
            GriddocumentosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavAdicionaranexo_Enabled), 5, 0, ".", "")));
            GriddocumentosContainer.AddColumnProperties(GriddocumentosColumn);
            GriddocumentosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GriddocumentosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV59Excluir)));
            GriddocumentosColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavExcluir_Class));
            GriddocumentosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavExcluir_Enabled), 5, 0, ".", "")));
            GriddocumentosContainer.AddColumnProperties(GriddocumentosColumn);
            GriddocumentosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GriddocumentosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV36DocumentosId), 9, 0, ".", ""))));
            GriddocumentosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDocumentosid_Enabled), 5, 0, ".", "")));
            GriddocumentosContainer.AddColumnProperties(GriddocumentosColumn);
            GriddocumentosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GriddocumentosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV37DocumentosDescricao));
            GriddocumentosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDocumentosdescricao_Enabled), 5, 0, ".", "")));
            GriddocumentosContainer.AddColumnProperties(GriddocumentosColumn);
            GriddocumentosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GriddocumentosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( AV38DocumentoObrigatorio)));
            GriddocumentosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavDocumentoobrigatorio.Enabled), 5, 0, ".", "")));
            GriddocumentosContainer.AddColumnProperties(GriddocumentosColumn);
            GriddocumentosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GriddocumentosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV49PropostaDocumentosAnexoName));
            GriddocumentosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavPropostadocumentosanexoname_Enabled), 5, 0, ".", "")));
            GriddocumentosContainer.AddColumnProperties(GriddocumentosColumn);
            GriddocumentosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GriddocumentosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV39Documento));
            GriddocumentosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDocumento_Enabled), 5, 0, ".", "")));
            GriddocumentosContainer.AddColumnProperties(GriddocumentosColumn);
            GriddocumentosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GriddocumentosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV40Extensao));
            GriddocumentosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavExtensao_Enabled), 5, 0, ".", "")));
            GriddocumentosContainer.AddColumnProperties(GriddocumentosColumn);
            GriddocumentosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GriddocumentosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV41PropostaDocumentosStatus));
            GriddocumentosColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( cmbavPropostadocumentosstatus_Columnclass));
            GriddocumentosColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( cmbavPropostadocumentosstatus_Columnheaderclass));
            GriddocumentosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavPropostadocumentosstatus.Enabled), 5, 0, ".", "")));
            GriddocumentosContainer.AddColumnProperties(GriddocumentosColumn);
            GriddocumentosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GriddocumentosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV54PropostaDocumentosId), 9, 0, ".", ""))));
            GriddocumentosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavPropostadocumentosid_Enabled), 5, 0, ".", "")));
            GriddocumentosContainer.AddColumnProperties(GriddocumentosColumn);
            GriddocumentosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GriddocumentosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( AV58PropostaDocumentosAdm)));
            GriddocumentosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkavPropostadocumentosadm.Enabled), 5, 0, ".", "")));
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
         bttBtnaprovar_proposta_Internalname = "BTNAPROVAR_PROPOSTA";
         bttBtnfinalizar_analise_Internalname = "BTNFINALIZAR_ANALISE";
         lblTab_title_Internalname = "TAB_TITLE";
         edtavPropostacomentarioanalise_Internalname = "vPROPOSTACOMENTARIOANALISE";
         divPropostacomentarioanalise_cell_Internalname = "PROPOSTACOMENTARIOANALISE_CELL";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
         lblConsultarcliente_Internalname = "CONSULTARCLIENTE";
         edtavClienterazaosocial_Internalname = "vCLIENTERAZAOSOCIAL";
         edtavClientedocumento_Internalname = "vCLIENTEDOCUMENTO";
         edtavContatoemail_Internalname = "vCONTATOEMAIL";
         lblTextblockcombo_propostaresponsavelid_Internalname = "TEXTBLOCKCOMBO_PROPOSTARESPONSAVELID";
         Combo_propostaresponsavelid_Internalname = "COMBO_PROPOSTARESPONSAVELID";
         lblConsultarresponsavel_Internalname = "CONSULTARRESPONSAVEL";
         lblAdicionarresponsavel_Internalname = "ADICIONARRESPONSAVEL";
         tblTablemergedpropostaresponsavelid_Internalname = "TABLEMERGEDPROPOSTARESPONSAVELID";
         divTablesplittedpropostaresponsavelid_Internalname = "TABLESPLITTEDPROPOSTARESPONSAVELID";
         divTablecontentresponsavel_Internalname = "TABLECONTENTRESPONSAVEL";
         divTablecliente_Internalname = "TABLECLIENTE";
         edtavBanconome_Internalname = "vBANCONOME";
         edtavContaagencia_Internalname = "vCONTAAGENCIA";
         edtavContanumero_Internalname = "vCONTANUMERO";
         divTablebanco_Internalname = "TABLEBANCO";
         cmbavClientepixtipo_Internalname = "vCLIENTEPIXTIPO";
         edtavClientepix_Internalname = "vCLIENTEPIX";
         divTablepix_Internalname = "TABLEPIX";
         divTableconta_Internalname = "TABLECONTA";
         lblTextblockcombo_procedimentosmedicosid_Internalname = "TEXTBLOCKCOMBO_PROCEDIMENTOSMEDICOSID";
         Combo_procedimentosmedicosid_Internalname = "COMBO_PROCEDIMENTOSMEDICOSID";
         divTablesplittedprocedimentosmedicosid_Internalname = "TABLESPLITTEDPROCEDIMENTOSMEDICOSID";
         edtavPropostavalor_Internalname = "vPROPOSTAVALOR";
         edtavPropostadescricao_Internalname = "vPROPOSTADESCRICAO";
         lblTextblockcombo_convenioid_Internalname = "TEXTBLOCKCOMBO_CONVENIOID";
         Combo_convenioid_Internalname = "COMBO_CONVENIOID";
         divTablesplittedconvenioid_Internalname = "TABLESPLITTEDCONVENIOID";
         lblTextblockcombo_conveniocategoriaid_Internalname = "TEXTBLOCKCOMBO_CONVENIOCATEGORIAID";
         Combo_conveniocategoriaid_Internalname = "COMBO_CONVENIOCATEGORIAID";
         divTablesplittedconveniocategoriaid_Internalname = "TABLESPLITTEDCONVENIOCATEGORIAID";
         lblTextblockconveniovencimentoano_Internalname = "TEXTBLOCKCONVENIOVENCIMENTOANO";
         cmbavConveniovencimentoano_Internalname = "vCONVENIOVENCIMENTOANO";
         cmbavConveniovencimentomes_Internalname = "vCONVENIOVENCIMENTOMES";
         tblTablemergedconveniovencimentoano_Internalname = "TABLEMERGEDCONVENIOVENCIMENTOANO";
         divTablesplittedconveniovencimentoano_Internalname = "TABLESPLITTEDCONVENIOVENCIMENTOANO";
         divTableproposta_Internalname = "TABLEPROPOSTA";
         bttBtnnovodocumento_Internalname = "BTNNOVODOCUMENTO";
         edtavAprovar_Internalname = "vAPROVAR";
         edtavReprovar_Internalname = "vREPROVAR";
         edtavAdicionaranexo_Internalname = "vADICIONARANEXO";
         edtavExcluir_Internalname = "vEXCLUIR";
         edtavDocumentosid_Internalname = "vDOCUMENTOSID";
         edtavDocumentosdescricao_Internalname = "vDOCUMENTOSDESCRICAO";
         cmbavDocumentoobrigatorio_Internalname = "vDOCUMENTOOBRIGATORIO";
         edtavPropostadocumentosanexoname_Internalname = "vPROPOSTADOCUMENTOSANEXONAME";
         edtavDocumento_Internalname = "vDOCUMENTO";
         edtavExtensao_Internalname = "vEXTENSAO";
         cmbavPropostadocumentosstatus_Internalname = "vPROPOSTADOCUMENTOSSTATUS";
         edtavPropostadocumentosid_Internalname = "vPROPOSTADOCUMENTOSID";
         chkavPropostadocumentosadm_Internalname = "vPROPOSTADOCUMENTOSADM";
         divTabledocumentos_Internalname = "TABLEDOCUMENTOS";
         grpUnnamedgroup3_Internalname = "UNNAMEDGROUP3";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         lblSerasa_title_Internalname = "SERASA_TITLE";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         Gxuitabspanel_tabs1_Internalname = "GXUITABSPANEL_TABS1";
         divTablecontent_Internalname = "TABLECONTENT";
         Novajanela_Internalname = "NOVAJANELA";
         divTablemain_Internalname = "TABLEMAIN";
         edtavPropostaresponsavelid_Internalname = "vPROPOSTARESPONSAVELID";
         edtavProcedimentosmedicosid_Internalname = "vPROCEDIMENTOSMEDICOSID";
         edtavConvenioid_Internalname = "vCONVENIOID";
         edtavConveniocategoriaid_Internalname = "vCONVENIOCATEGORIAID";
         Dvelop_confirmpanel_aprovar_proposta_Internalname = "DVELOP_CONFIRMPANEL_APROVAR_PROPOSTA";
         tblTabledvelop_confirmpanel_aprovar_proposta_Internalname = "TABLEDVELOP_CONFIRMPANEL_APROVAR_PROPOSTA";
         edtavDvelop_confirmpanel_aprovar_proposta_comment_Internalname = "vDVELOP_CONFIRMPANEL_APROVAR_PROPOSTA_COMMENT";
         divDiv_dvelop_confirmpanel_aprovar_proposta_body_Internalname = "DIV_DVELOP_CONFIRMPANEL_APROVAR_PROPOSTA_BODY";
         Dvelop_confirmpanel_finalizar_analise_Internalname = "DVELOP_CONFIRMPANEL_FINALIZAR_ANALISE";
         tblTabledvelop_confirmpanel_finalizar_analise_Internalname = "TABLEDVELOP_CONFIRMPANEL_FINALIZAR_ANALISE";
         edtavDvelop_confirmpanel_finalizar_analise_comment_Internalname = "vDVELOP_CONFIRMPANEL_FINALIZAR_ANALISE_COMMENT";
         divDiv_dvelop_confirmpanel_finalizar_analise_body_Internalname = "DIV_DVELOP_CONFIRMPANEL_FINALIZAR_ANALISE_BODY";
         Dvelop_confirmpanel_excluir_Internalname = "DVELOP_CONFIRMPANEL_EXCLUIR";
         tblTabledvelop_confirmpanel_excluir_Internalname = "TABLEDVELOP_CONFIRMPANEL_EXCLUIR";
         Griddocumentos_empowerer_Internalname = "GRIDDOCUMENTOS_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGriddocumentos_Internalname = "GRIDDOCUMENTOS";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGriddocumentos_Allowcollapsing = 0;
         subGriddocumentos_Allowselection = 0;
         subGriddocumentos_Header = "";
         chkavPropostadocumentosadm.Caption = "";
         chkavPropostadocumentosadm.Enabled = 1;
         edtavPropostadocumentosid_Jsonclick = "";
         edtavPropostadocumentosid_Enabled = 1;
         cmbavPropostadocumentosstatus_Jsonclick = "";
         cmbavPropostadocumentosstatus.Enabled = 1;
         cmbavPropostadocumentosstatus_Columnclass = "WWColumn";
         edtavExtensao_Jsonclick = "";
         edtavExtensao_Enabled = 1;
         edtavDocumento_Jsonclick = "";
         edtavDocumento_Parameters = "";
         edtavDocumento_Contenttype = "";
         edtavDocumento_Filetype = "";
         edtavDocumento_Enabled = 1;
         edtavPropostadocumentosanexoname_Jsonclick = "";
         edtavPropostadocumentosanexoname_Enabled = 1;
         cmbavDocumentoobrigatorio_Jsonclick = "";
         cmbavDocumentoobrigatorio.Enabled = 1;
         edtavDocumentosdescricao_Jsonclick = "";
         edtavDocumentosdescricao_Enabled = 1;
         edtavDocumentosid_Jsonclick = "";
         edtavDocumentosid_Enabled = 1;
         edtavExcluir_Jsonclick = "";
         edtavExcluir_Class = "Attribute";
         edtavExcluir_Enabled = 1;
         edtavAdicionaranexo_Jsonclick = "";
         edtavAdicionaranexo_Enabled = 1;
         edtavReprovar_Jsonclick = "";
         edtavReprovar_Class = "Attribute";
         edtavReprovar_Enabled = 1;
         edtavAprovar_Jsonclick = "";
         edtavAprovar_Class = "Attribute";
         edtavAprovar_Enabled = 1;
         subGriddocumentos_Class = "GridWithBorderColor WorkWith";
         subGriddocumentos_Backcolorstyle = 0;
         cmbavConveniovencimentomes_Jsonclick = "";
         cmbavConveniovencimentoano_Jsonclick = "";
         cmbavPropostadocumentosstatus_Columnheaderclass = "";
         cmbavConveniovencimentomes.Enabled = 1;
         cmbavConveniovencimentoano.Enabled = 1;
         edtavConveniocategoriaid_Jsonclick = "";
         edtavConveniocategoriaid_Visible = 1;
         edtavConvenioid_Jsonclick = "";
         edtavConvenioid_Visible = 1;
         edtavProcedimentosmedicosid_Jsonclick = "";
         edtavProcedimentosmedicosid_Visible = 1;
         edtavPropostaresponsavelid_Jsonclick = "";
         edtavPropostaresponsavelid_Visible = 1;
         edtavPropostadescricao_Jsonclick = "";
         edtavPropostadescricao_Enabled = 1;
         edtavPropostavalor_Jsonclick = "";
         edtavPropostavalor_Enabled = 1;
         edtavClientepix_Jsonclick = "";
         edtavClientepix_Enabled = 1;
         cmbavClientepixtipo_Jsonclick = "";
         cmbavClientepixtipo.Enabled = 1;
         edtavContanumero_Jsonclick = "";
         edtavContanumero_Enabled = 1;
         edtavContaagencia_Jsonclick = "";
         edtavContaagencia_Enabled = 1;
         edtavBanconome_Jsonclick = "";
         edtavBanconome_Enabled = 1;
         divTablecontentresponsavel_Visible = 1;
         edtavContatoemail_Jsonclick = "";
         edtavContatoemail_Enabled = 1;
         edtavClientedocumento_Jsonclick = "";
         edtavClientedocumento_Enabled = 1;
         edtavClienterazaosocial_Jsonclick = "";
         edtavClienterazaosocial_Enabled = 1;
         edtavPropostacomentarioanalise_Enabled = 1;
         edtavPropostacomentarioanalise_Visible = 1;
         divPropostacomentarioanalise_cell_Class = "col-xs-12";
         bttBtnfinalizar_analise_Visible = 1;
         bttBtnaprovar_proposta_Visible = 1;
         Dvelop_confirmpanel_excluir_Confirmtype = "1";
         Dvelop_confirmpanel_excluir_Yesbuttonposition = "left";
         Dvelop_confirmpanel_excluir_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_excluir_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_excluir_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_excluir_Confirmationtext = "Tem certeza que deseja excluir essa arquivo? Uma vez excluido não será mais possível recupera-lo.";
         Dvelop_confirmpanel_excluir_Title = "Remover documento";
         Dvelop_confirmpanel_finalizar_analise_Comment = "Required";
         Dvelop_confirmpanel_finalizar_analise_Confirmtype = "2";
         Dvelop_confirmpanel_finalizar_analise_Yesbuttonposition = "left";
         Dvelop_confirmpanel_finalizar_analise_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_finalizar_analise_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_finalizar_analise_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_finalizar_analise_Confirmationtext = "Deseja finalizar a análise?";
         Dvelop_confirmpanel_finalizar_analise_Title = "Análise";
         Dvelop_confirmpanel_aprovar_proposta_Comment = "Required";
         Dvelop_confirmpanel_aprovar_proposta_Confirmtype = "1";
         Dvelop_confirmpanel_aprovar_proposta_Yesbuttonposition = "left";
         Dvelop_confirmpanel_aprovar_proposta_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_aprovar_proposta_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_aprovar_proposta_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_aprovar_proposta_Confirmationtext = "Deixe um comentário da sua decisão para prosseguir.";
         Dvelop_confirmpanel_aprovar_proposta_Title = "Aprovação";
         Novajanela_Target = "";
         Gxuitabspanel_tabs1_Historymanagement = Convert.ToBoolean( 0);
         Gxuitabspanel_tabs1_Class = "Tab";
         Gxuitabspanel_tabs1_Pagecount = 2;
         Combo_conveniocategoriaid_Emptyitem = Convert.ToBoolean( 0);
         Combo_conveniocategoriaid_Enabled = Convert.ToBoolean( -1);
         Combo_conveniocategoriaid_Cls = "ExtendedCombo AttributeFL";
         Combo_convenioid_Emptyitem = Convert.ToBoolean( 0);
         Combo_convenioid_Enabled = Convert.ToBoolean( -1);
         Combo_convenioid_Cls = "ExtendedCombo AttributeFL";
         Combo_procedimentosmedicosid_Emptyitem = Convert.ToBoolean( 0);
         Combo_procedimentosmedicosid_Enabled = Convert.ToBoolean( -1);
         Combo_procedimentosmedicosid_Cls = "ExtendedCombo AttributeFL";
         Combo_propostaresponsavelid_Htmltemplate = "";
         Combo_propostaresponsavelid_Emptyitem = Convert.ToBoolean( 0);
         Combo_propostaresponsavelid_Cls = "ExtendedCombo AttributeFL ExtendedComboTitleAndSubtitle";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Proposta";
         subGriddocumentos_Rows = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRIDDOCUMENTOS_nFirstRecordOnPage","type":"int"},{"av":"GRIDDOCUMENTOS_nEOF","type":"int"},{"av":"subGriddocumentos_Rows","ctrl":"GRIDDOCUMENTOS","prop":"Rows"},{"av":"A323PropostaId","fld":"PROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV5PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A415PropostaDocumentosAnexo","fld":"PROPOSTADOCUMENTOSANEXO","type":"bitstr"},{"av":"A406DocumentosDescricao","fld":"DOCUMENTOSDESCRICAO","type":"svchar"},{"av":"A405DocumentosId","fld":"DOCUMENTOSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A417PropostaDocumentosAnexoFileType","fld":"PROPOSTADOCUMENTOSANEXOFILETYPE","type":"svchar"},{"av":"A579PropostaDocumentosStatus","fld":"PROPOSTADOCUMENTOSSTATUS","type":"svchar"},{"av":"A416PropostaDocumentosAnexoName","fld":"PROPOSTADOCUMENTOSANEXONAME","type":"svchar"},{"av":"A414PropostaDocumentosId","fld":"PROPOSTADOCUMENTOSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A651PropostaDocumentosAdm","fld":"PROPOSTADOCUMENTOSADM","type":"boolean"},{"av":"AV66Aprovados","fld":"vAPROVADOS","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV67Context","fld":"vCONTEXT","hsh":true,"type":""},{"av":"AV68PropostaStatus","fld":"vPROPOSTASTATUS","hsh":true,"type":"svchar"},{"av":"AV46PropostaPacienteClienteId","fld":"vPROPOSTAPACIENTECLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV71PropostaComentarioAnalise","fld":"vPROPOSTACOMENTARIOANALISE","type":"svchar"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"cmbavPropostadocumentosstatus"},{"ctrl":"BTNAPROVAR_PROPOSTA","prop":"Visible"},{"ctrl":"BTNFINALIZAR_ANALISE","prop":"Visible"}]}""");
         setEventMetadata("GRIDDOCUMENTOS.LOAD","""{"handler":"E247U2","iparms":[{"av":"A323PropostaId","fld":"PROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV5PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A415PropostaDocumentosAnexo","fld":"PROPOSTADOCUMENTOSANEXO","type":"bitstr"},{"av":"A406DocumentosDescricao","fld":"DOCUMENTOSDESCRICAO","type":"svchar"},{"av":"A405DocumentosId","fld":"DOCUMENTOSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A417PropostaDocumentosAnexoFileType","fld":"PROPOSTADOCUMENTOSANEXOFILETYPE","type":"svchar"},{"av":"A579PropostaDocumentosStatus","fld":"PROPOSTADOCUMENTOSSTATUS","type":"svchar"},{"av":"A416PropostaDocumentosAnexoName","fld":"PROPOSTADOCUMENTOSANEXONAME","type":"svchar"},{"av":"A414PropostaDocumentosId","fld":"PROPOSTADOCUMENTOSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A651PropostaDocumentosAdm","fld":"PROPOSTADOCUMENTOSADM","type":"boolean"}]""");
         setEventMetadata("GRIDDOCUMENTOS.LOAD",""","oparms":[{"av":"AV37DocumentosDescricao","fld":"vDOCUMENTOSDESCRICAO","type":"svchar"},{"av":"AV36DocumentosId","fld":"vDOCUMENTOSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV39Documento","fld":"vDOCUMENTO","type":"bitstr"},{"av":"AV40Extensao","fld":"vEXTENSAO","type":"svchar"},{"av":"cmbavPropostadocumentosstatus"},{"av":"AV41PropostaDocumentosStatus","fld":"vPROPOSTADOCUMENTOSSTATUS","type":"svchar"},{"av":"AV49PropostaDocumentosAnexoName","fld":"vPROPOSTADOCUMENTOSANEXONAME","type":"svchar"},{"av":"AV54PropostaDocumentosId","fld":"vPROPOSTADOCUMENTOSID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV58PropostaDocumentosAdm","fld":"vPROPOSTADOCUMENTOSADM","type":"boolean"},{"av":"AV61Aprovar","fld":"vAPROVAR","type":"char"},{"av":"edtavAprovar_Class","ctrl":"vAPROVAR","prop":"Class"},{"av":"AV62Reprovar","fld":"vREPROVAR","type":"char"},{"av":"edtavReprovar_Class","ctrl":"vREPROVAR","prop":"Class"},{"av":"AV29AdicionarAnexo","fld":"vADICIONARANEXO","type":"char"},{"av":"AV59Excluir","fld":"vEXCLUIR","type":"char"},{"av":"edtavExcluir_Class","ctrl":"vEXCLUIR","prop":"Class"}]}""");
         setEventMetadata("'DOAPROVAR_PROPOSTA'","""{"handler":"E117U1","iparms":[]""");
         setEventMetadata("'DOAPROVAR_PROPOSTA'",""","oparms":[{"av":"AV69DVelop_ConfirmPanel_Aprovar_Proposta_Comment","fld":"vDVELOP_CONFIRMPANEL_APROVAR_PROPOSTA_COMMENT","type":"vchar"}]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_APROVAR_PROPOSTA.CLOSE","""{"handler":"E147U2","iparms":[{"av":"Dvelop_confirmpanel_aprovar_proposta_Result","ctrl":"DVELOP_CONFIRMPANEL_APROVAR_PROPOSTA","prop":"Result"},{"av":"AV69DVelop_ConfirmPanel_Aprovar_Proposta_Comment","fld":"vDVELOP_CONFIRMPANEL_APROVAR_PROPOSTA_COMMENT","type":"vchar"},{"av":"AV5PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_APROVAR_PROPOSTA.CLOSE",""","oparms":[{"ctrl":"BTNAPROVAR_PROPOSTA","prop":"Visible"}]}""");
         setEventMetadata("'DOFINALIZAR_ANALISE'","""{"handler":"E127U1","iparms":[]""");
         setEventMetadata("'DOFINALIZAR_ANALISE'",""","oparms":[{"av":"AV70DVelop_ConfirmPanel_Finalizar_analise_Comment","fld":"vDVELOP_CONFIRMPANEL_FINALIZAR_ANALISE_COMMENT","type":"vchar"}]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_FINALIZAR_ANALISE.CLOSE","""{"handler":"E157U2","iparms":[{"av":"Dvelop_confirmpanel_finalizar_analise_Result","ctrl":"DVELOP_CONFIRMPANEL_FINALIZAR_ANALISE","prop":"Result"},{"av":"AV70DVelop_ConfirmPanel_Finalizar_analise_Comment","fld":"vDVELOP_CONFIRMPANEL_FINALIZAR_ANALISE_COMMENT","type":"vchar"},{"av":"AV5PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_FINALIZAR_ANALISE.CLOSE",""","oparms":[{"ctrl":"BTNFINALIZAR_ANALISE","prop":"Visible"}]}""");
         setEventMetadata("'DONOVODOCUMENTO'","""{"handler":"E177U2","iparms":[{"av":"GRIDDOCUMENTOS_nFirstRecordOnPage","type":"int"},{"av":"GRIDDOCUMENTOS_nEOF","type":"int"},{"av":"subGriddocumentos_Rows","ctrl":"GRIDDOCUMENTOS","prop":"Rows"},{"av":"AV66Aprovados","fld":"vAPROVADOS","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV67Context","fld":"vCONTEXT","hsh":true,"type":""},{"av":"AV68PropostaStatus","fld":"vPROPOSTASTATUS","hsh":true,"type":"svchar"},{"av":"A323PropostaId","fld":"PROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV5PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A415PropostaDocumentosAnexo","fld":"PROPOSTADOCUMENTOSANEXO","type":"bitstr"},{"av":"A406DocumentosDescricao","fld":"DOCUMENTOSDESCRICAO","type":"svchar"},{"av":"A405DocumentosId","fld":"DOCUMENTOSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A417PropostaDocumentosAnexoFileType","fld":"PROPOSTADOCUMENTOSANEXOFILETYPE","type":"svchar"},{"av":"A579PropostaDocumentosStatus","fld":"PROPOSTADOCUMENTOSSTATUS","type":"svchar"},{"av":"A416PropostaDocumentosAnexoName","fld":"PROPOSTADOCUMENTOSANEXONAME","type":"svchar"},{"av":"A414PropostaDocumentosId","fld":"PROPOSTADOCUMENTOSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A651PropostaDocumentosAdm","fld":"PROPOSTADOCUMENTOSADM","type":"boolean"},{"av":"AV46PropostaPacienteClienteId","fld":"vPROPOSTAPACIENTECLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV71PropostaComentarioAnalise","fld":"vPROPOSTACOMENTARIOANALISE","type":"svchar"}]""");
         setEventMetadata("'DONOVODOCUMENTO'",""","oparms":[{"av":"cmbavPropostadocumentosstatus"},{"ctrl":"BTNAPROVAR_PROPOSTA","prop":"Visible"},{"ctrl":"BTNFINALIZAR_ANALISE","prop":"Visible"}]}""");
         setEventMetadata("VEXCLUIR.CLICK","""{"handler":"E287U2","iparms":[]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_EXCLUIR.CLOSE","""{"handler":"E167U2","iparms":[{"av":"Dvelop_confirmpanel_excluir_Result","ctrl":"DVELOP_CONFIRMPANEL_EXCLUIR","prop":"Result"},{"av":"GRIDDOCUMENTOS_nFirstRecordOnPage","type":"int"},{"av":"GRIDDOCUMENTOS_nEOF","type":"int"},{"av":"subGriddocumentos_Rows","ctrl":"GRIDDOCUMENTOS","prop":"Rows"},{"av":"AV66Aprovados","fld":"vAPROVADOS","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV67Context","fld":"vCONTEXT","hsh":true,"type":""},{"av":"AV68PropostaStatus","fld":"vPROPOSTASTATUS","hsh":true,"type":"svchar"},{"av":"A323PropostaId","fld":"PROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV5PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A415PropostaDocumentosAnexo","fld":"PROPOSTADOCUMENTOSANEXO","type":"bitstr"},{"av":"A406DocumentosDescricao","fld":"DOCUMENTOSDESCRICAO","type":"svchar"},{"av":"A405DocumentosId","fld":"DOCUMENTOSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A417PropostaDocumentosAnexoFileType","fld":"PROPOSTADOCUMENTOSANEXOFILETYPE","type":"svchar"},{"av":"A579PropostaDocumentosStatus","fld":"PROPOSTADOCUMENTOSSTATUS","type":"svchar"},{"av":"A416PropostaDocumentosAnexoName","fld":"PROPOSTADOCUMENTOSANEXONAME","type":"svchar"},{"av":"A414PropostaDocumentosId","fld":"PROPOSTADOCUMENTOSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A651PropostaDocumentosAdm","fld":"PROPOSTADOCUMENTOSADM","type":"boolean"},{"av":"AV46PropostaPacienteClienteId","fld":"vPROPOSTAPACIENTECLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV71PropostaComentarioAnalise","fld":"vPROPOSTACOMENTARIOANALISE","type":"svchar"},{"av":"AV54PropostaDocumentosId","fld":"vPROPOSTADOCUMENTOSID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_EXCLUIR.CLOSE",""","oparms":[{"av":"cmbavPropostadocumentosstatus"},{"ctrl":"BTNAPROVAR_PROPOSTA","prop":"Visible"},{"ctrl":"BTNFINALIZAR_ANALISE","prop":"Visible"}]}""");
         setEventMetadata("'DOCONSULTARCLIENTE'","""{"handler":"E187U2","iparms":[{"av":"AV46PropostaPacienteClienteId","fld":"vPROPOSTAPACIENTECLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("'DOCONSULTARRESPONSAVEL'","""{"handler":"E197U2","iparms":[{"av":"AV47PropostaResponsavelId","fld":"vPROPOSTARESPONSAVELID","pic":"ZZZZZZZZ9","type":"int"}]}""");
         setEventMetadata("'DOADICIONARRESPONSAVEL'","""{"handler":"E207U2","iparms":[{"av":"A168ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZ9","type":"int"}]}""");
         setEventMetadata("COMBO_CONVENIOID.ONOPTIONCLICKED","""{"handler":"E137U2","iparms":[{"av":"Combo_convenioid_Selectedvalue_get","ctrl":"COMBO_CONVENIOID","prop":"SelectedValue_get"},{"av":"A494ConvenioCategoriaDescricao","fld":"CONVENIOCATEGORIADESCRICAO","type":"svchar"},{"av":"A495ConvenioCategoriaStatus","fld":"CONVENIOCATEGORIASTATUS","type":"boolean"},{"av":"A493ConvenioCategoriaId","fld":"CONVENIOCATEGORIAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV34ConvenioCategoriaId_Data","fld":"vCONVENIOCATEGORIAID_DATA","type":""},{"av":"AV15ConvenioCategoriaId","fld":"vCONVENIOCATEGORIAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A410ConvenioId","fld":"CONVENIOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV14ConvenioId","fld":"vCONVENIOID","pic":"ZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("COMBO_CONVENIOID.ONOPTIONCLICKED",""","oparms":[{"av":"AV14ConvenioId","fld":"vCONVENIOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV15ConvenioCategoriaId","fld":"vCONVENIOCATEGORIAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV34ConvenioCategoriaId_Data","fld":"vCONVENIOCATEGORIAID_DATA","type":""},{"av":"Combo_conveniocategoriaid_Selectedvalue_set","ctrl":"COMBO_CONVENIOCATEGORIAID","prop":"SelectedValue_set"}]}""");
         setEventMetadata("VADICIONARANEXO.CLICK","""{"handler":"E257U2","iparms":[{"av":"AV54PropostaDocumentosId","fld":"vPROPOSTADOCUMENTOSID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("VADICIONARANEXO.CLICK",""","oparms":[{"av":"Novajanela_Target","ctrl":"NOVAJANELA","prop":"Target"}]}""");
         setEventMetadata("ENTER","""{"handler":"E217U2","iparms":[{"av":"AV12PropostaValor","fld":"vPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV11ProcedimentosMedicosId","fld":"vPROCEDIMENTOSMEDICOSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV14ConvenioId","fld":"vCONVENIOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV15ConvenioCategoriaId","fld":"vCONVENIOCATEGORIAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"cmbavConveniovencimentoano"},{"av":"AV16ConvenioVencimentoAno","fld":"vCONVENIOVENCIMENTOANO","pic":"ZZZ9","type":"int"},{"av":"cmbavConveniovencimentomes"},{"av":"AV17ConvenioVencimentoMes","fld":"vCONVENIOVENCIMENTOMES","pic":"ZZZ9","type":"int"},{"av":"AV5PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV13PropostaDescricao","fld":"vPROPOSTADESCRICAO","type":"svchar"},{"av":"AV47PropostaResponsavelId","fld":"vPROPOSTARESPONSAVELID","pic":"ZZZZZZZZ9","type":"int"}]}""");
         setEventMetadata("VAPROVAR.CLICK","""{"handler":"E267U2","iparms":[{"av":"GRIDDOCUMENTOS_nFirstRecordOnPage","type":"int"},{"av":"GRIDDOCUMENTOS_nEOF","type":"int"},{"av":"subGriddocumentos_Rows","ctrl":"GRIDDOCUMENTOS","prop":"Rows"},{"av":"AV66Aprovados","fld":"vAPROVADOS","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV67Context","fld":"vCONTEXT","hsh":true,"type":""},{"av":"AV68PropostaStatus","fld":"vPROPOSTASTATUS","hsh":true,"type":"svchar"},{"av":"A323PropostaId","fld":"PROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV5PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A415PropostaDocumentosAnexo","fld":"PROPOSTADOCUMENTOSANEXO","type":"bitstr"},{"av":"A406DocumentosDescricao","fld":"DOCUMENTOSDESCRICAO","type":"svchar"},{"av":"A405DocumentosId","fld":"DOCUMENTOSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A417PropostaDocumentosAnexoFileType","fld":"PROPOSTADOCUMENTOSANEXOFILETYPE","type":"svchar"},{"av":"A579PropostaDocumentosStatus","fld":"PROPOSTADOCUMENTOSSTATUS","type":"svchar"},{"av":"A416PropostaDocumentosAnexoName","fld":"PROPOSTADOCUMENTOSANEXONAME","type":"svchar"},{"av":"A414PropostaDocumentosId","fld":"PROPOSTADOCUMENTOSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A651PropostaDocumentosAdm","fld":"PROPOSTADOCUMENTOSADM","type":"boolean"},{"av":"AV46PropostaPacienteClienteId","fld":"vPROPOSTAPACIENTECLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV71PropostaComentarioAnalise","fld":"vPROPOSTACOMENTARIOANALISE","type":"svchar"},{"av":"AV54PropostaDocumentosId","fld":"vPROPOSTADOCUMENTOSID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("VAPROVAR.CLICK",""","oparms":[{"av":"cmbavPropostadocumentosstatus"},{"ctrl":"BTNAPROVAR_PROPOSTA","prop":"Visible"},{"ctrl":"BTNFINALIZAR_ANALISE","prop":"Visible"}]}""");
         setEventMetadata("VREPROVAR.CLICK","""{"handler":"E277U2","iparms":[{"av":"GRIDDOCUMENTOS_nFirstRecordOnPage","type":"int"},{"av":"GRIDDOCUMENTOS_nEOF","type":"int"},{"av":"subGriddocumentos_Rows","ctrl":"GRIDDOCUMENTOS","prop":"Rows"},{"av":"AV66Aprovados","fld":"vAPROVADOS","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV67Context","fld":"vCONTEXT","hsh":true,"type":""},{"av":"AV68PropostaStatus","fld":"vPROPOSTASTATUS","hsh":true,"type":"svchar"},{"av":"A323PropostaId","fld":"PROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV5PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A415PropostaDocumentosAnexo","fld":"PROPOSTADOCUMENTOSANEXO","type":"bitstr"},{"av":"A406DocumentosDescricao","fld":"DOCUMENTOSDESCRICAO","type":"svchar"},{"av":"A405DocumentosId","fld":"DOCUMENTOSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A417PropostaDocumentosAnexoFileType","fld":"PROPOSTADOCUMENTOSANEXOFILETYPE","type":"svchar"},{"av":"A579PropostaDocumentosStatus","fld":"PROPOSTADOCUMENTOSSTATUS","type":"svchar"},{"av":"A416PropostaDocumentosAnexoName","fld":"PROPOSTADOCUMENTOSANEXONAME","type":"svchar"},{"av":"A414PropostaDocumentosId","fld":"PROPOSTADOCUMENTOSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A651PropostaDocumentosAdm","fld":"PROPOSTADOCUMENTOSADM","type":"boolean"},{"av":"AV46PropostaPacienteClienteId","fld":"vPROPOSTAPACIENTECLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV71PropostaComentarioAnalise","fld":"vPROPOSTACOMENTARIOANALISE","type":"svchar"},{"av":"AV54PropostaDocumentosId","fld":"vPROPOSTADOCUMENTOSID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("VREPROVAR.CLICK",""","oparms":[{"av":"AV5PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"cmbavPropostadocumentosstatus"},{"ctrl":"BTNAPROVAR_PROPOSTA","prop":"Visible"},{"ctrl":"BTNFINALIZAR_ANALISE","prop":"Visible"}]}""");
         setEventMetadata("GRIDDOCUMENTOS_FIRSTPAGE","""{"handler":"subgriddocumentos_firstpage","iparms":[{"av":"GRIDDOCUMENTOS_nFirstRecordOnPage","type":"int"},{"av":"GRIDDOCUMENTOS_nEOF","type":"int"},{"av":"subGriddocumentos_Rows","ctrl":"GRIDDOCUMENTOS","prop":"Rows"},{"av":"A323PropostaId","fld":"PROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV5PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A415PropostaDocumentosAnexo","fld":"PROPOSTADOCUMENTOSANEXO","type":"bitstr"},{"av":"A406DocumentosDescricao","fld":"DOCUMENTOSDESCRICAO","type":"svchar"},{"av":"A405DocumentosId","fld":"DOCUMENTOSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A417PropostaDocumentosAnexoFileType","fld":"PROPOSTADOCUMENTOSANEXOFILETYPE","type":"svchar"},{"av":"A579PropostaDocumentosStatus","fld":"PROPOSTADOCUMENTOSSTATUS","type":"svchar"},{"av":"A416PropostaDocumentosAnexoName","fld":"PROPOSTADOCUMENTOSANEXONAME","type":"svchar"},{"av":"A414PropostaDocumentosId","fld":"PROPOSTADOCUMENTOSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A651PropostaDocumentosAdm","fld":"PROPOSTADOCUMENTOSADM","type":"boolean"},{"av":"AV46PropostaPacienteClienteId","fld":"vPROPOSTAPACIENTECLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV71PropostaComentarioAnalise","fld":"vPROPOSTACOMENTARIOANALISE","type":"svchar"},{"av":"AV66Aprovados","fld":"vAPROVADOS","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV67Context","fld":"vCONTEXT","hsh":true,"type":""},{"av":"AV68PropostaStatus","fld":"vPROPOSTASTATUS","hsh":true,"type":"svchar"}]""");
         setEventMetadata("GRIDDOCUMENTOS_FIRSTPAGE",""","oparms":[{"av":"cmbavPropostadocumentosstatus"},{"ctrl":"BTNAPROVAR_PROPOSTA","prop":"Visible"},{"ctrl":"BTNFINALIZAR_ANALISE","prop":"Visible"}]}""");
         setEventMetadata("GRIDDOCUMENTOS_PREVPAGE","""{"handler":"subgriddocumentos_previouspage","iparms":[{"av":"GRIDDOCUMENTOS_nFirstRecordOnPage","type":"int"},{"av":"GRIDDOCUMENTOS_nEOF","type":"int"},{"av":"subGriddocumentos_Rows","ctrl":"GRIDDOCUMENTOS","prop":"Rows"},{"av":"A323PropostaId","fld":"PROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV5PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A415PropostaDocumentosAnexo","fld":"PROPOSTADOCUMENTOSANEXO","type":"bitstr"},{"av":"A406DocumentosDescricao","fld":"DOCUMENTOSDESCRICAO","type":"svchar"},{"av":"A405DocumentosId","fld":"DOCUMENTOSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A417PropostaDocumentosAnexoFileType","fld":"PROPOSTADOCUMENTOSANEXOFILETYPE","type":"svchar"},{"av":"A579PropostaDocumentosStatus","fld":"PROPOSTADOCUMENTOSSTATUS","type":"svchar"},{"av":"A416PropostaDocumentosAnexoName","fld":"PROPOSTADOCUMENTOSANEXONAME","type":"svchar"},{"av":"A414PropostaDocumentosId","fld":"PROPOSTADOCUMENTOSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A651PropostaDocumentosAdm","fld":"PROPOSTADOCUMENTOSADM","type":"boolean"},{"av":"AV46PropostaPacienteClienteId","fld":"vPROPOSTAPACIENTECLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV71PropostaComentarioAnalise","fld":"vPROPOSTACOMENTARIOANALISE","type":"svchar"},{"av":"AV66Aprovados","fld":"vAPROVADOS","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV67Context","fld":"vCONTEXT","hsh":true,"type":""},{"av":"AV68PropostaStatus","fld":"vPROPOSTASTATUS","hsh":true,"type":"svchar"}]""");
         setEventMetadata("GRIDDOCUMENTOS_PREVPAGE",""","oparms":[{"av":"cmbavPropostadocumentosstatus"},{"ctrl":"BTNAPROVAR_PROPOSTA","prop":"Visible"},{"ctrl":"BTNFINALIZAR_ANALISE","prop":"Visible"}]}""");
         setEventMetadata("GRIDDOCUMENTOS_NEXTPAGE","""{"handler":"subgriddocumentos_nextpage","iparms":[{"av":"GRIDDOCUMENTOS_nFirstRecordOnPage","type":"int"},{"av":"GRIDDOCUMENTOS_nEOF","type":"int"},{"av":"subGriddocumentos_Rows","ctrl":"GRIDDOCUMENTOS","prop":"Rows"},{"av":"A323PropostaId","fld":"PROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV5PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A415PropostaDocumentosAnexo","fld":"PROPOSTADOCUMENTOSANEXO","type":"bitstr"},{"av":"A406DocumentosDescricao","fld":"DOCUMENTOSDESCRICAO","type":"svchar"},{"av":"A405DocumentosId","fld":"DOCUMENTOSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A417PropostaDocumentosAnexoFileType","fld":"PROPOSTADOCUMENTOSANEXOFILETYPE","type":"svchar"},{"av":"A579PropostaDocumentosStatus","fld":"PROPOSTADOCUMENTOSSTATUS","type":"svchar"},{"av":"A416PropostaDocumentosAnexoName","fld":"PROPOSTADOCUMENTOSANEXONAME","type":"svchar"},{"av":"A414PropostaDocumentosId","fld":"PROPOSTADOCUMENTOSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A651PropostaDocumentosAdm","fld":"PROPOSTADOCUMENTOSADM","type":"boolean"},{"av":"AV46PropostaPacienteClienteId","fld":"vPROPOSTAPACIENTECLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV71PropostaComentarioAnalise","fld":"vPROPOSTACOMENTARIOANALISE","type":"svchar"},{"av":"AV66Aprovados","fld":"vAPROVADOS","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV67Context","fld":"vCONTEXT","hsh":true,"type":""},{"av":"AV68PropostaStatus","fld":"vPROPOSTASTATUS","hsh":true,"type":"svchar"}]""");
         setEventMetadata("GRIDDOCUMENTOS_NEXTPAGE",""","oparms":[{"av":"cmbavPropostadocumentosstatus"},{"ctrl":"BTNAPROVAR_PROPOSTA","prop":"Visible"},{"ctrl":"BTNFINALIZAR_ANALISE","prop":"Visible"}]}""");
         setEventMetadata("GRIDDOCUMENTOS_LASTPAGE","""{"handler":"subgriddocumentos_lastpage","iparms":[{"av":"GRIDDOCUMENTOS_nFirstRecordOnPage","type":"int"},{"av":"GRIDDOCUMENTOS_nEOF","type":"int"},{"av":"subGriddocumentos_Rows","ctrl":"GRIDDOCUMENTOS","prop":"Rows"},{"av":"A323PropostaId","fld":"PROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV5PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A415PropostaDocumentosAnexo","fld":"PROPOSTADOCUMENTOSANEXO","type":"bitstr"},{"av":"A406DocumentosDescricao","fld":"DOCUMENTOSDESCRICAO","type":"svchar"},{"av":"A405DocumentosId","fld":"DOCUMENTOSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A417PropostaDocumentosAnexoFileType","fld":"PROPOSTADOCUMENTOSANEXOFILETYPE","type":"svchar"},{"av":"A579PropostaDocumentosStatus","fld":"PROPOSTADOCUMENTOSSTATUS","type":"svchar"},{"av":"A416PropostaDocumentosAnexoName","fld":"PROPOSTADOCUMENTOSANEXONAME","type":"svchar"},{"av":"A414PropostaDocumentosId","fld":"PROPOSTADOCUMENTOSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A651PropostaDocumentosAdm","fld":"PROPOSTADOCUMENTOSADM","type":"boolean"},{"av":"AV46PropostaPacienteClienteId","fld":"vPROPOSTAPACIENTECLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV71PropostaComentarioAnalise","fld":"vPROPOSTACOMENTARIOANALISE","type":"svchar"},{"av":"AV66Aprovados","fld":"vAPROVADOS","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV67Context","fld":"vCONTEXT","hsh":true,"type":""},{"av":"AV68PropostaStatus","fld":"vPROPOSTASTATUS","hsh":true,"type":"svchar"},{"av":"subGriddocumentos_Recordcount","type":"int"}]""");
         setEventMetadata("GRIDDOCUMENTOS_LASTPAGE",""","oparms":[{"av":"cmbavPropostadocumentosstatus"},{"ctrl":"BTNAPROVAR_PROPOSTA","prop":"Visible"},{"ctrl":"BTNFINALIZAR_ANALISE","prop":"Visible"}]}""");
         setEventMetadata("VALIDV_CONTATOEMAIL","""{"handler":"Validv_Contatoemail","iparms":[]}""");
         setEventMetadata("VALIDV_CLIENTEPIXTIPO","""{"handler":"Validv_Clientepixtipo","iparms":[]}""");
         setEventMetadata("VALIDV_CONVENIOVENCIMENTOANO","""{"handler":"Validv_Conveniovencimentoano","iparms":[]}""");
         setEventMetadata("VALIDV_CONVENIOVENCIMENTOMES","""{"handler":"Validv_Conveniovencimentomes","iparms":[]}""");
         setEventMetadata("VALIDV_PROPOSTADOCUMENTOSSTATUS","""{"handler":"Validv_Propostadocumentosstatus","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Propostadocumentosadm","iparms":[]}""");
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
         Dvelop_confirmpanel_aprovar_proposta_Result = "";
         Dvelop_confirmpanel_finalizar_analise_Result = "";
         Dvelop_confirmpanel_excluir_Result = "";
         Combo_conveniocategoriaid_Selectedvalue_get = "";
         Combo_convenioid_Selectedvalue_get = "";
         Combo_procedimentosmedicosid_Selectedvalue_get = "";
         Combo_propostaresponsavelid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV67Context = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV68PropostaStatus = "";
         A415PropostaDocumentosAnexo = "";
         A406DocumentosDescricao = "";
         A417PropostaDocumentosAnexoFileType = "";
         A579PropostaDocumentosStatus = "";
         A416PropostaDocumentosAnexoName = "";
         AV71PropostaComentarioAnalise = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         forbiddenHiddens = new GXProperties();
         AV72PropostaResponsavelId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV31ProcedimentosMedicosId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV33ConvenioId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV34ConvenioCategoriaId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A494ConvenioCategoriaDescricao = "";
         Combo_propostaresponsavelid_Selectedvalue_set = "";
         Combo_procedimentosmedicosid_Selectedvalue_set = "";
         Combo_convenioid_Selectedvalue_set = "";
         Combo_conveniocategoriaid_Selectedvalue_set = "";
         Dvelop_confirmpanel_aprovar_proposta_Bodycontentinternalname = "";
         Dvelop_confirmpanel_finalizar_analise_Bodycontentinternalname = "";
         Griddocumentos_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtnaprovar_proposta_Jsonclick = "";
         bttBtnfinalizar_analise_Jsonclick = "";
         ucGxuitabspanel_tabs1 = new GXUserControl();
         lblTab_title_Jsonclick = "";
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         lblConsultarcliente_Jsonclick = "";
         AV26ClienteRazaoSocial = "";
         AV27ClienteDocumento = "";
         AV28ContatoEmail = "";
         lblTextblockcombo_propostaresponsavelid_Jsonclick = "";
         AV42BancoNome = "";
         AV21ContaAgencia = "";
         AV22ContaNumero = "";
         AV18ClientePixTipo = "";
         AV19ClientePix = "";
         lblTextblockcombo_procedimentosmedicosid_Jsonclick = "";
         ucCombo_procedimentosmedicosid = new GXUserControl();
         Combo_procedimentosmedicosid_Caption = "";
         AV13PropostaDescricao = "";
         lblTextblockcombo_convenioid_Jsonclick = "";
         ucCombo_convenioid = new GXUserControl();
         Combo_convenioid_Caption = "";
         lblTextblockcombo_conveniocategoriaid_Jsonclick = "";
         ucCombo_conveniocategoriaid = new GXUserControl();
         Combo_conveniocategoriaid_Caption = "";
         lblTextblockconveniovencimentoano_Jsonclick = "";
         bttBtnnovodocumento_Jsonclick = "";
         GriddocumentosContainer = new GXWebGrid( context);
         sStyleString = "";
         lblSerasa_title_Jsonclick = "";
         WebComp_Wcserasaww_Component = "";
         OldWcserasaww = "";
         ucNovajanela = new GXUserControl();
         AV69DVelop_ConfirmPanel_Aprovar_Proposta_Comment = "";
         AV70DVelop_ConfirmPanel_Finalizar_analise_Comment = "";
         ucGriddocumentos_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV61Aprovar = "";
         AV62Reprovar = "";
         AV29AdicionarAnexo = "";
         AV59Excluir = "";
         AV37DocumentosDescricao = "";
         AV49PropostaDocumentosAnexoName = "";
         AV39Documento = "";
         AV40Extensao = "";
         AV41PropostaDocumentosStatus = "";
         GXDecQS = "";
         hsh = "";
         GXt_SdtWWPContext1 = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV63Array_ClienteId = new GxSimpleCollection<int>();
         H007U3_A227ContratoId = new int[1] ;
         H007U3_n227ContratoId = new bool[] {false} ;
         H007U3_A473ContratoClienteId = new int[1] ;
         H007U3_n473ContratoClienteId = new bool[] {false} ;
         H007U3_A402BancoId = new int[1] ;
         H007U3_n402BancoId = new bool[] {false} ;
         H007U3_A403BancoNome = new string[] {""} ;
         H007U3_n403BancoNome = new bool[] {false} ;
         H007U3_A323PropostaId = new int[1] ;
         H007U3_n323PropostaId = new bool[] {false} ;
         H007U3_A329PropostaStatus = new string[] {""} ;
         H007U3_n329PropostaStatus = new bool[] {false} ;
         H007U3_A790PropostaComentarioAnalise = new string[] {""} ;
         H007U3_n790PropostaComentarioAnalise = new bool[] {false} ;
         H007U3_A553PropostaResponsavelId = new int[1] ;
         H007U3_n553PropostaResponsavelId = new bool[] {false} ;
         H007U3_A504PropostaPacienteClienteId = new int[1] ;
         H007U3_n504PropostaPacienteClienteId = new bool[] {false} ;
         H007U3_A642PropostaClinicaId = new int[1] ;
         H007U3_n642PropostaClinicaId = new bool[] {false} ;
         H007U3_A590PropostaResponsavelConta = new string[] {""} ;
         H007U3_n590PropostaResponsavelConta = new bool[] {false} ;
         H007U3_A591PropostaResponsavelAgencia = new string[] {""} ;
         H007U3_n591PropostaResponsavelAgencia = new bool[] {false} ;
         H007U3_A592PropostaResponsavelTipoPix = new string[] {""} ;
         H007U3_n592PropostaResponsavelTipoPix = new bool[] {false} ;
         H007U3_A593PropostaResponsavelPIX = new string[] {""} ;
         H007U3_n593PropostaResponsavelPIX = new bool[] {false} ;
         H007U3_A594PropostaResponsavelDepositoTipo = new string[] {""} ;
         H007U3_n594PropostaResponsavelDepositoTipo = new bool[] {false} ;
         H007U3_A584PropostaPacienteConta = new string[] {""} ;
         H007U3_n584PropostaPacienteConta = new bool[] {false} ;
         H007U3_A585PropostaPacienteAgencia = new string[] {""} ;
         H007U3_n585PropostaPacienteAgencia = new bool[] {false} ;
         H007U3_A586PropostaPacienteTipoPix = new string[] {""} ;
         H007U3_n586PropostaPacienteTipoPix = new bool[] {false} ;
         H007U3_A587PropostaPacientePIX = new string[] {""} ;
         H007U3_n587PropostaPacientePIX = new bool[] {false} ;
         H007U3_A588PropostaPacienteDepositoTipo = new string[] {""} ;
         H007U3_n588PropostaPacienteDepositoTipo = new bool[] {false} ;
         H007U3_A376ProcedimentosMedicosId = new int[1] ;
         H007U3_n376ProcedimentosMedicosId = new bool[] {false} ;
         H007U3_A410ConvenioId = new int[1] ;
         H007U3_n410ConvenioId = new bool[] {false} ;
         H007U3_A493ConvenioCategoriaId = new int[1] ;
         H007U3_n493ConvenioCategoriaId = new bool[] {false} ;
         H007U3_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         H007U3_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         H007U3_A540PropostaPacienteClienteDocumento = new string[] {""} ;
         H007U3_n540PropostaPacienteClienteDocumento = new bool[] {false} ;
         H007U3_A541PropostaPacienteContatoEmail = new string[] {""} ;
         H007U3_n541PropostaPacienteContatoEmail = new bool[] {false} ;
         H007U3_A580PropostaResponsavelDocumento = new string[] {""} ;
         H007U3_n580PropostaResponsavelDocumento = new bool[] {false} ;
         H007U3_A581PropostaResponsavelRazaoSocial = new string[] {""} ;
         H007U3_n581PropostaResponsavelRazaoSocial = new bool[] {false} ;
         H007U3_A582PropostaResponsavelEmail = new string[] {""} ;
         H007U3_n582PropostaResponsavelEmail = new bool[] {false} ;
         H007U3_A378ProcedimentosMedicosDescricao = new string[] {""} ;
         H007U3_n378ProcedimentosMedicosDescricao = new bool[] {false} ;
         H007U3_A326PropostaValor = new decimal[1] ;
         H007U3_n326PropostaValor = new bool[] {false} ;
         H007U3_A325PropostaDescricao = new string[] {""} ;
         H007U3_n325PropostaDescricao = new bool[] {false} ;
         H007U3_A494ConvenioCategoriaDescricao = new string[] {""} ;
         H007U3_n494ConvenioCategoriaDescricao = new bool[] {false} ;
         H007U3_A411ConvenioDescricao = new string[] {""} ;
         H007U3_n411ConvenioDescricao = new bool[] {false} ;
         H007U3_A496ConvenioVencimentoAno = new short[1] ;
         H007U3_n496ConvenioVencimentoAno = new bool[] {false} ;
         H007U3_A497ConvenioVencimentoMes = new short[1] ;
         H007U3_n497ConvenioVencimentoMes = new bool[] {false} ;
         H007U3_A40000GXC1 = new int[1] ;
         H007U3_n40000GXC1 = new bool[] {false} ;
         A403BancoNome = "";
         A329PropostaStatus = "";
         A790PropostaComentarioAnalise = "";
         A590PropostaResponsavelConta = "";
         A591PropostaResponsavelAgencia = "";
         A592PropostaResponsavelTipoPix = "";
         A593PropostaResponsavelPIX = "";
         A594PropostaResponsavelDepositoTipo = "";
         A584PropostaPacienteConta = "";
         A585PropostaPacienteAgencia = "";
         A586PropostaPacienteTipoPix = "";
         A587PropostaPacientePIX = "";
         A588PropostaPacienteDepositoTipo = "";
         A505PropostaPacienteClienteRazaoSocial = "";
         A540PropostaPacienteClienteDocumento = "";
         A541PropostaPacienteContatoEmail = "";
         A580PropostaResponsavelDocumento = "";
         A581PropostaResponsavelRazaoSocial = "";
         A582PropostaResponsavelEmail = "";
         A378ProcedimentosMedicosDescricao = "";
         A325PropostaDescricao = "";
         A411ConvenioDescricao = "";
         A589PropostaResponsavelBanco = "";
         AV48ClienteDepositoTipo = "";
         A583PropostaPacienteBanco = "";
         AV24ResponsavelClienteDocumento = "";
         AV23ResponsavelClienteRazaoSocial = "";
         AV25ResponsavelContatoEmail = "";
         AV43ProcedimentosMedicosDescricao = "";
         AV45ConvenioCategoriaDescricao = "";
         AV44ConvenioDescricao = "";
         ucCombo_propostaresponsavelid = new GXUserControl();
         ucDvelop_confirmpanel_aprovar_proposta = new GXUserControl();
         ucDvelop_confirmpanel_finalizar_analise = new GXUserControl();
         AV55String = "";
         AV56WEBSESSION = context.GetSession();
         H007U4_A323PropostaId = new int[1] ;
         H007U4_n323PropostaId = new bool[] {false} ;
         H007U4_A406DocumentosDescricao = new string[] {""} ;
         H007U4_n406DocumentosDescricao = new bool[] {false} ;
         H007U4_A405DocumentosId = new int[1] ;
         H007U4_n405DocumentosId = new bool[] {false} ;
         H007U4_A417PropostaDocumentosAnexoFileType = new string[] {""} ;
         H007U4_n417PropostaDocumentosAnexoFileType = new bool[] {false} ;
         H007U4_A579PropostaDocumentosStatus = new string[] {""} ;
         H007U4_n579PropostaDocumentosStatus = new bool[] {false} ;
         H007U4_A416PropostaDocumentosAnexoName = new string[] {""} ;
         H007U4_n416PropostaDocumentosAnexoName = new bool[] {false} ;
         H007U4_A414PropostaDocumentosId = new int[1] ;
         H007U4_A651PropostaDocumentosAdm = new bool[] {false} ;
         H007U4_n651PropostaDocumentosAdm = new bool[] {false} ;
         H007U4_A415PropostaDocumentosAnexo = new string[] {""} ;
         H007U4_n415PropostaDocumentosAnexo = new bool[] {false} ;
         GriddocumentosRow = new GXWebRow();
         AV65sdERro = new SdtSdErro(context);
         AV57Proposta = new SdtProposta(context);
         AV53PropostaDocumentos = new SdtPropostaDocumentos(context);
         H007U5_A495ConvenioCategoriaStatus = new bool[] {false} ;
         H007U5_n495ConvenioCategoriaStatus = new bool[] {false} ;
         H007U5_A493ConvenioCategoriaId = new int[1] ;
         H007U5_n493ConvenioCategoriaId = new bool[] {false} ;
         H007U5_A494ConvenioCategoriaDescricao = new string[] {""} ;
         H007U5_n494ConvenioCategoriaDescricao = new bool[] {false} ;
         AV32Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         H007U6_A410ConvenioId = new int[1] ;
         H007U6_n410ConvenioId = new bool[] {false} ;
         H007U6_A495ConvenioCategoriaStatus = new bool[] {false} ;
         H007U6_n495ConvenioCategoriaStatus = new bool[] {false} ;
         H007U6_A493ConvenioCategoriaId = new int[1] ;
         H007U6_n493ConvenioCategoriaId = new bool[] {false} ;
         H007U6_A494ConvenioCategoriaDescricao = new string[] {""} ;
         H007U6_n494ConvenioCategoriaDescricao = new bool[] {false} ;
         H007U7_A412ConvenioStatus = new bool[] {false} ;
         H007U7_A410ConvenioId = new int[1] ;
         H007U7_n410ConvenioId = new bool[] {false} ;
         H007U7_A411ConvenioDescricao = new string[] {""} ;
         H007U7_n411ConvenioDescricao = new bool[] {false} ;
         H007U8_A376ProcedimentosMedicosId = new int[1] ;
         H007U8_n376ProcedimentosMedicosId = new bool[] {false} ;
         H007U8_A378ProcedimentosMedicosDescricao = new string[] {""} ;
         H007U8_n378ProcedimentosMedicosDescricao = new bool[] {false} ;
         H007U9_A172ClienteTipoPessoa = new string[] {""} ;
         H007U9_n172ClienteTipoPessoa = new bool[] {false} ;
         H007U9_A174ClienteStatus = new bool[] {false} ;
         H007U9_n174ClienteStatus = new bool[] {false} ;
         H007U9_A168ClienteId = new int[1] ;
         H007U9_A201ContatoEmail = new string[] {""} ;
         H007U9_n201ContatoEmail = new bool[] {false} ;
         H007U9_A170ClienteRazaoSocial = new string[] {""} ;
         H007U9_n170ClienteRazaoSocial = new bool[] {false} ;
         A172ClienteTipoPessoa = "";
         A201ContatoEmail = "";
         A170ClienteRazaoSocial = "";
         AV30ComboTitles = new GxSimpleCollection<string>();
         H007U10_A172ClienteTipoPessoa = new string[] {""} ;
         H007U10_n172ClienteTipoPessoa = new bool[] {false} ;
         H007U10_A174ClienteStatus = new bool[] {false} ;
         H007U10_n174ClienteStatus = new bool[] {false} ;
         H007U10_A168ClienteId = new int[1] ;
         H007U10_A169ClienteDocumento = new string[] {""} ;
         H007U10_n169ClienteDocumento = new bool[] {false} ;
         H007U10_A201ContatoEmail = new string[] {""} ;
         H007U10_n201ContatoEmail = new bool[] {false} ;
         H007U10_A170ClienteRazaoSocial = new string[] {""} ;
         H007U10_n170ClienteRazaoSocial = new bool[] {false} ;
         A169ClienteDocumento = "";
         AV50GUID = Guid.Empty;
         AV51Source = "";
         AV52File = new GxFile(context.GetPhysicalPath());
         GXt_char3 = "";
         GXt_char2 = "";
         ucDvelop_confirmpanel_excluir = new GXUserControl();
         Combo_propostaresponsavelid_Caption = "";
         lblConsultarresponsavel_Jsonclick = "";
         lblAdicionarresponsavel_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGriddocumentos_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         gxblobfileaux = new GxFile(context.GetPhysicalPath());
         GriddocumentosColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpalterarproposta__default(),
            new Object[][] {
                new Object[] {
               H007U3_A227ContratoId, H007U3_n227ContratoId, H007U3_A473ContratoClienteId, H007U3_n473ContratoClienteId, H007U3_A402BancoId, H007U3_n402BancoId, H007U3_A403BancoNome, H007U3_n403BancoNome, H007U3_A323PropostaId, H007U3_A329PropostaStatus,
               H007U3_n329PropostaStatus, H007U3_A790PropostaComentarioAnalise, H007U3_n790PropostaComentarioAnalise, H007U3_A553PropostaResponsavelId, H007U3_n553PropostaResponsavelId, H007U3_A504PropostaPacienteClienteId, H007U3_n504PropostaPacienteClienteId, H007U3_A642PropostaClinicaId, H007U3_n642PropostaClinicaId, H007U3_A590PropostaResponsavelConta,
               H007U3_n590PropostaResponsavelConta, H007U3_A591PropostaResponsavelAgencia, H007U3_n591PropostaResponsavelAgencia, H007U3_A592PropostaResponsavelTipoPix, H007U3_n592PropostaResponsavelTipoPix, H007U3_A593PropostaResponsavelPIX, H007U3_n593PropostaResponsavelPIX, H007U3_A594PropostaResponsavelDepositoTipo, H007U3_n594PropostaResponsavelDepositoTipo, H007U3_A584PropostaPacienteConta,
               H007U3_n584PropostaPacienteConta, H007U3_A585PropostaPacienteAgencia, H007U3_n585PropostaPacienteAgencia, H007U3_A586PropostaPacienteTipoPix, H007U3_n586PropostaPacienteTipoPix, H007U3_A587PropostaPacientePIX, H007U3_n587PropostaPacientePIX, H007U3_A588PropostaPacienteDepositoTipo, H007U3_n588PropostaPacienteDepositoTipo, H007U3_A376ProcedimentosMedicosId,
               H007U3_n376ProcedimentosMedicosId, H007U3_A410ConvenioId, H007U3_n410ConvenioId, H007U3_A493ConvenioCategoriaId, H007U3_n493ConvenioCategoriaId, H007U3_A505PropostaPacienteClienteRazaoSocial, H007U3_n505PropostaPacienteClienteRazaoSocial, H007U3_A540PropostaPacienteClienteDocumento, H007U3_n540PropostaPacienteClienteDocumento, H007U3_A541PropostaPacienteContatoEmail,
               H007U3_n541PropostaPacienteContatoEmail, H007U3_A580PropostaResponsavelDocumento, H007U3_n580PropostaResponsavelDocumento, H007U3_A581PropostaResponsavelRazaoSocial, H007U3_n581PropostaResponsavelRazaoSocial, H007U3_A582PropostaResponsavelEmail, H007U3_n582PropostaResponsavelEmail, H007U3_A378ProcedimentosMedicosDescricao, H007U3_n378ProcedimentosMedicosDescricao, H007U3_A326PropostaValor,
               H007U3_n326PropostaValor, H007U3_A325PropostaDescricao, H007U3_n325PropostaDescricao, H007U3_A494ConvenioCategoriaDescricao, H007U3_n494ConvenioCategoriaDescricao, H007U3_A411ConvenioDescricao, H007U3_n411ConvenioDescricao, H007U3_A496ConvenioVencimentoAno, H007U3_n496ConvenioVencimentoAno, H007U3_A497ConvenioVencimentoMes,
               H007U3_n497ConvenioVencimentoMes, H007U3_A40000GXC1, H007U3_n40000GXC1
               }
               , new Object[] {
               H007U4_A323PropostaId, H007U4_n323PropostaId, H007U4_A406DocumentosDescricao, H007U4_n406DocumentosDescricao, H007U4_A405DocumentosId, H007U4_n405DocumentosId, H007U4_A417PropostaDocumentosAnexoFileType, H007U4_n417PropostaDocumentosAnexoFileType, H007U4_A579PropostaDocumentosStatus, H007U4_n579PropostaDocumentosStatus,
               H007U4_A416PropostaDocumentosAnexoName, H007U4_n416PropostaDocumentosAnexoName, H007U4_A414PropostaDocumentosId, H007U4_A651PropostaDocumentosAdm, H007U4_n651PropostaDocumentosAdm, H007U4_A415PropostaDocumentosAnexo, H007U4_n415PropostaDocumentosAnexo
               }
               , new Object[] {
               H007U5_A495ConvenioCategoriaStatus, H007U5_n495ConvenioCategoriaStatus, H007U5_A493ConvenioCategoriaId, H007U5_A494ConvenioCategoriaDescricao, H007U5_n494ConvenioCategoriaDescricao
               }
               , new Object[] {
               H007U6_A410ConvenioId, H007U6_n410ConvenioId, H007U6_A495ConvenioCategoriaStatus, H007U6_n495ConvenioCategoriaStatus, H007U6_A493ConvenioCategoriaId, H007U6_A494ConvenioCategoriaDescricao, H007U6_n494ConvenioCategoriaDescricao
               }
               , new Object[] {
               H007U7_A412ConvenioStatus, H007U7_A410ConvenioId, H007U7_A411ConvenioDescricao, H007U7_n411ConvenioDescricao
               }
               , new Object[] {
               H007U8_A376ProcedimentosMedicosId, H007U8_A378ProcedimentosMedicosDescricao, H007U8_n378ProcedimentosMedicosDescricao
               }
               , new Object[] {
               H007U9_A172ClienteTipoPessoa, H007U9_n172ClienteTipoPessoa, H007U9_A174ClienteStatus, H007U9_n174ClienteStatus, H007U9_A168ClienteId, H007U9_A201ContatoEmail, H007U9_n201ContatoEmail, H007U9_A170ClienteRazaoSocial, H007U9_n170ClienteRazaoSocial
               }
               , new Object[] {
               H007U10_A172ClienteTipoPessoa, H007U10_n172ClienteTipoPessoa, H007U10_A174ClienteStatus, H007U10_n174ClienteStatus, H007U10_A168ClienteId, H007U10_A169ClienteDocumento, H007U10_n169ClienteDocumento, H007U10_A201ContatoEmail, H007U10_n201ContatoEmail, H007U10_A170ClienteRazaoSocial,
               H007U10_n170ClienteRazaoSocial
               }
            }
         );
         WebComp_Wcserasaww = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
         edtavPropostacomentarioanalise_Enabled = 0;
         edtavClienterazaosocial_Enabled = 0;
         edtavClientedocumento_Enabled = 0;
         edtavContatoemail_Enabled = 0;
         edtavBanconome_Enabled = 0;
         edtavContaagencia_Enabled = 0;
         edtavContanumero_Enabled = 0;
         cmbavClientepixtipo.Enabled = 0;
         edtavClientepix_Enabled = 0;
         edtavAprovar_Enabled = 0;
         edtavReprovar_Enabled = 0;
         edtavAdicionaranexo_Enabled = 0;
         edtavExcluir_Enabled = 0;
         edtavDocumentosid_Enabled = 0;
         edtavDocumentosdescricao_Enabled = 0;
         cmbavDocumentoobrigatorio.Enabled = 0;
         edtavPropostadocumentosanexoname_Enabled = 0;
         edtavDocumento_Enabled = 0;
         edtavExtensao_Enabled = 0;
         cmbavPropostadocumentosstatus.Enabled = 0;
         edtavPropostadocumentosid_Enabled = 0;
         chkavPropostadocumentosadm.Enabled = 0;
      }

      private short GRIDDOCUMENTOS_nEOF ;
      private short nRcdExists_10 ;
      private short nIsMod_10 ;
      private short nRcdExists_9 ;
      private short nIsMod_9 ;
      private short nRcdExists_8 ;
      private short nIsMod_8 ;
      private short nRcdExists_7 ;
      private short nIsMod_7 ;
      private short nRcdExists_6 ;
      private short nIsMod_6 ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV66Aprovados ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short AV16ConvenioVencimentoAno ;
      private short AV17ConvenioVencimentoMes ;
      private short subGriddocumentos_Backcolorstyle ;
      private short A496ConvenioVencimentoAno ;
      private short A497ConvenioVencimentoMes ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short subGriddocumentos_Backstyle ;
      private short subGriddocumentos_Titlebackstyle ;
      private short subGriddocumentos_Allowselection ;
      private short subGriddocumentos_Allowhovering ;
      private short subGriddocumentos_Allowcollapsing ;
      private short subGriddocumentos_Collapsed ;
      private int AV5PropostaId ;
      private int wcpOAV5PropostaId ;
      private int nRC_GXsfl_167 ;
      private int subGriddocumentos_Recordcount ;
      private int subGriddocumentos_Rows ;
      private int nGXsfl_167_idx=1 ;
      private int A323PropostaId ;
      private int A405DocumentosId ;
      private int A414PropostaDocumentosId ;
      private int AV46PropostaPacienteClienteId ;
      private int A168ClienteId ;
      private int A493ConvenioCategoriaId ;
      private int A410ConvenioId ;
      private int Gxuitabspanel_tabs1_Pagecount ;
      private int bttBtnaprovar_proposta_Visible ;
      private int bttBtnfinalizar_analise_Visible ;
      private int edtavPropostacomentarioanalise_Visible ;
      private int edtavPropostacomentarioanalise_Enabled ;
      private int edtavClienterazaosocial_Enabled ;
      private int edtavClientedocumento_Enabled ;
      private int edtavContatoemail_Enabled ;
      private int divTablecontentresponsavel_Visible ;
      private int edtavBanconome_Enabled ;
      private int edtavContaagencia_Enabled ;
      private int edtavContanumero_Enabled ;
      private int edtavClientepix_Enabled ;
      private int edtavPropostavalor_Enabled ;
      private int edtavPropostadescricao_Enabled ;
      private int AV47PropostaResponsavelId ;
      private int edtavPropostaresponsavelid_Visible ;
      private int AV11ProcedimentosMedicosId ;
      private int edtavProcedimentosmedicosid_Visible ;
      private int AV14ConvenioId ;
      private int edtavConvenioid_Visible ;
      private int AV15ConvenioCategoriaId ;
      private int edtavConveniocategoriaid_Visible ;
      private int AV36DocumentosId ;
      private int AV54PropostaDocumentosId ;
      private int subGriddocumentos_Islastpage ;
      private int edtavAprovar_Enabled ;
      private int edtavReprovar_Enabled ;
      private int edtavAdicionaranexo_Enabled ;
      private int edtavExcluir_Enabled ;
      private int edtavDocumentosid_Enabled ;
      private int edtavDocumentosdescricao_Enabled ;
      private int edtavPropostadocumentosanexoname_Enabled ;
      private int edtavDocumento_Enabled ;
      private int edtavExtensao_Enabled ;
      private int edtavPropostadocumentosid_Enabled ;
      private int GRIDDOCUMENTOS_nGridOutOfScope ;
      private int A227ContratoId ;
      private int A473ContratoClienteId ;
      private int A402BancoId ;
      private int A553PropostaResponsavelId ;
      private int A504PropostaPacienteClienteId ;
      private int A642PropostaClinicaId ;
      private int A376ProcedimentosMedicosId ;
      private int A40000GXC1 ;
      private int idxLst ;
      private int subGriddocumentos_Backcolor ;
      private int subGriddocumentos_Allbackcolor ;
      private int subGriddocumentos_Titlebackcolor ;
      private int subGriddocumentos_Selectedindex ;
      private int subGriddocumentos_Selectioncolor ;
      private int subGriddocumentos_Hoveringcolor ;
      private long GRIDDOCUMENTOS_nFirstRecordOnPage ;
      private long GRIDDOCUMENTOS_nCurrentRecord ;
      private decimal AV12PropostaValor ;
      private decimal A326PropostaValor ;
      private string Dvelop_confirmpanel_aprovar_proposta_Result ;
      private string Dvelop_confirmpanel_finalizar_analise_Result ;
      private string Dvelop_confirmpanel_excluir_Result ;
      private string Combo_conveniocategoriaid_Selectedvalue_get ;
      private string Combo_convenioid_Selectedvalue_get ;
      private string Combo_procedimentosmedicosid_Selectedvalue_get ;
      private string Combo_propostaresponsavelid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_167_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Combo_propostaresponsavelid_Cls ;
      private string Combo_propostaresponsavelid_Selectedvalue_set ;
      private string Combo_propostaresponsavelid_Htmltemplate ;
      private string Combo_procedimentosmedicosid_Cls ;
      private string Combo_procedimentosmedicosid_Selectedvalue_set ;
      private string Combo_convenioid_Cls ;
      private string Combo_convenioid_Selectedvalue_set ;
      private string Combo_conveniocategoriaid_Cls ;
      private string Combo_conveniocategoriaid_Selectedvalue_set ;
      private string Gxuitabspanel_tabs1_Class ;
      private string Novajanela_Target ;
      private string Dvelop_confirmpanel_aprovar_proposta_Title ;
      private string Dvelop_confirmpanel_aprovar_proposta_Confirmationtext ;
      private string Dvelop_confirmpanel_aprovar_proposta_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_aprovar_proposta_Nobuttoncaption ;
      private string Dvelop_confirmpanel_aprovar_proposta_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_aprovar_proposta_Yesbuttonposition ;
      private string Dvelop_confirmpanel_aprovar_proposta_Confirmtype ;
      private string Dvelop_confirmpanel_aprovar_proposta_Comment ;
      private string Dvelop_confirmpanel_aprovar_proposta_Bodycontentinternalname ;
      private string Dvelop_confirmpanel_finalizar_analise_Title ;
      private string Dvelop_confirmpanel_finalizar_analise_Confirmationtext ;
      private string Dvelop_confirmpanel_finalizar_analise_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_finalizar_analise_Nobuttoncaption ;
      private string Dvelop_confirmpanel_finalizar_analise_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_finalizar_analise_Yesbuttonposition ;
      private string Dvelop_confirmpanel_finalizar_analise_Confirmtype ;
      private string Dvelop_confirmpanel_finalizar_analise_Comment ;
      private string Dvelop_confirmpanel_finalizar_analise_Bodycontentinternalname ;
      private string Dvelop_confirmpanel_excluir_Title ;
      private string Dvelop_confirmpanel_excluir_Confirmationtext ;
      private string Dvelop_confirmpanel_excluir_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_excluir_Nobuttoncaption ;
      private string Dvelop_confirmpanel_excluir_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_excluir_Yesbuttonposition ;
      private string Dvelop_confirmpanel_excluir_Confirmtype ;
      private string Griddocumentos_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string TempTags ;
      private string bttBtnaprovar_proposta_Internalname ;
      private string bttBtnaprovar_proposta_Jsonclick ;
      private string bttBtnfinalizar_analise_Internalname ;
      private string bttBtnfinalizar_analise_Jsonclick ;
      private string Gxuitabspanel_tabs1_Internalname ;
      private string lblTab_title_Internalname ;
      private string lblTab_title_Jsonclick ;
      private string divUnnamedtable2_Internalname ;
      private string divPropostacomentarioanalise_cell_Internalname ;
      private string divPropostacomentarioanalise_cell_Class ;
      private string edtavPropostacomentarioanalise_Internalname ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divTablecliente_Internalname ;
      private string lblConsultarcliente_Internalname ;
      private string lblConsultarcliente_Jsonclick ;
      private string edtavClienterazaosocial_Internalname ;
      private string edtavClienterazaosocial_Jsonclick ;
      private string edtavClientedocumento_Internalname ;
      private string edtavClientedocumento_Jsonclick ;
      private string edtavContatoemail_Internalname ;
      private string edtavContatoemail_Jsonclick ;
      private string divTablecontentresponsavel_Internalname ;
      private string divTablesplittedpropostaresponsavelid_Internalname ;
      private string lblTextblockcombo_propostaresponsavelid_Internalname ;
      private string lblTextblockcombo_propostaresponsavelid_Jsonclick ;
      private string divTableconta_Internalname ;
      private string divTablebanco_Internalname ;
      private string edtavBanconome_Internalname ;
      private string edtavBanconome_Jsonclick ;
      private string edtavContaagencia_Internalname ;
      private string edtavContaagencia_Jsonclick ;
      private string edtavContanumero_Internalname ;
      private string edtavContanumero_Jsonclick ;
      private string divTablepix_Internalname ;
      private string cmbavClientepixtipo_Internalname ;
      private string cmbavClientepixtipo_Jsonclick ;
      private string edtavClientepix_Internalname ;
      private string edtavClientepix_Jsonclick ;
      private string divTableproposta_Internalname ;
      private string divTablesplittedprocedimentosmedicosid_Internalname ;
      private string lblTextblockcombo_procedimentosmedicosid_Internalname ;
      private string lblTextblockcombo_procedimentosmedicosid_Jsonclick ;
      private string Combo_procedimentosmedicosid_Caption ;
      private string Combo_procedimentosmedicosid_Internalname ;
      private string edtavPropostavalor_Internalname ;
      private string edtavPropostavalor_Jsonclick ;
      private string edtavPropostadescricao_Internalname ;
      private string edtavPropostadescricao_Jsonclick ;
      private string divTablesplittedconvenioid_Internalname ;
      private string lblTextblockcombo_convenioid_Internalname ;
      private string lblTextblockcombo_convenioid_Jsonclick ;
      private string Combo_convenioid_Caption ;
      private string Combo_convenioid_Internalname ;
      private string divTablesplittedconveniocategoriaid_Internalname ;
      private string lblTextblockcombo_conveniocategoriaid_Internalname ;
      private string lblTextblockcombo_conveniocategoriaid_Jsonclick ;
      private string Combo_conveniocategoriaid_Caption ;
      private string Combo_conveniocategoriaid_Internalname ;
      private string divTablesplittedconveniovencimentoano_Internalname ;
      private string lblTextblockconveniovencimentoano_Internalname ;
      private string lblTextblockconveniovencimentoano_Jsonclick ;
      private string grpUnnamedgroup3_Internalname ;
      private string divTabledocumentos_Internalname ;
      private string bttBtnnovodocumento_Internalname ;
      private string bttBtnnovodocumento_Jsonclick ;
      private string sStyleString ;
      private string subGriddocumentos_Internalname ;
      private string lblSerasa_title_Internalname ;
      private string lblSerasa_title_Jsonclick ;
      private string divUnnamedtable1_Internalname ;
      private string WebComp_Wcserasaww_Component ;
      private string OldWcserasaww ;
      private string Novajanela_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavPropostaresponsavelid_Internalname ;
      private string edtavPropostaresponsavelid_Jsonclick ;
      private string edtavProcedimentosmedicosid_Internalname ;
      private string edtavProcedimentosmedicosid_Jsonclick ;
      private string edtavConvenioid_Internalname ;
      private string edtavConvenioid_Jsonclick ;
      private string edtavConveniocategoriaid_Internalname ;
      private string edtavConveniocategoriaid_Jsonclick ;
      private string divDiv_dvelop_confirmpanel_aprovar_proposta_body_Internalname ;
      private string edtavDvelop_confirmpanel_aprovar_proposta_comment_Internalname ;
      private string divDiv_dvelop_confirmpanel_finalizar_analise_body_Internalname ;
      private string edtavDvelop_confirmpanel_finalizar_analise_comment_Internalname ;
      private string Griddocumentos_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV61Aprovar ;
      private string edtavAprovar_Internalname ;
      private string AV62Reprovar ;
      private string edtavReprovar_Internalname ;
      private string AV29AdicionarAnexo ;
      private string edtavAdicionaranexo_Internalname ;
      private string AV59Excluir ;
      private string edtavExcluir_Internalname ;
      private string edtavDocumentosid_Internalname ;
      private string edtavDocumentosdescricao_Internalname ;
      private string cmbavDocumentoobrigatorio_Internalname ;
      private string edtavPropostadocumentosanexoname_Internalname ;
      private string edtavDocumento_Internalname ;
      private string edtavExtensao_Internalname ;
      private string cmbavPropostadocumentosstatus_Internalname ;
      private string edtavPropostadocumentosid_Internalname ;
      private string chkavPropostadocumentosadm_Internalname ;
      private string GXDecQS ;
      private string cmbavConveniovencimentoano_Internalname ;
      private string cmbavConveniovencimentomes_Internalname ;
      private string hsh ;
      private string Combo_propostaresponsavelid_Internalname ;
      private string Dvelop_confirmpanel_aprovar_proposta_Internalname ;
      private string Dvelop_confirmpanel_finalizar_analise_Internalname ;
      private string cmbavPropostadocumentosstatus_Columnheaderclass ;
      private string edtavAprovar_Class ;
      private string edtavReprovar_Class ;
      private string edtavExcluir_Class ;
      private string cmbavPropostadocumentosstatus_Columnclass ;
      private string GXt_char3 ;
      private string GXt_char2 ;
      private string tblTabledvelop_confirmpanel_excluir_Internalname ;
      private string Dvelop_confirmpanel_excluir_Internalname ;
      private string tblTabledvelop_confirmpanel_finalizar_analise_Internalname ;
      private string tblTabledvelop_confirmpanel_aprovar_proposta_Internalname ;
      private string tblTablemergedconveniovencimentoano_Internalname ;
      private string cmbavConveniovencimentoano_Jsonclick ;
      private string cmbavConveniovencimentomes_Jsonclick ;
      private string tblTablemergedpropostaresponsavelid_Internalname ;
      private string Combo_propostaresponsavelid_Caption ;
      private string lblConsultarresponsavel_Internalname ;
      private string lblConsultarresponsavel_Jsonclick ;
      private string lblAdicionarresponsavel_Internalname ;
      private string lblAdicionarresponsavel_Jsonclick ;
      private string sGXsfl_167_fel_idx="0001" ;
      private string subGriddocumentos_Class ;
      private string subGriddocumentos_Linesclass ;
      private string ROClassString ;
      private string edtavAprovar_Jsonclick ;
      private string edtavReprovar_Jsonclick ;
      private string edtavAdicionaranexo_Jsonclick ;
      private string edtavExcluir_Jsonclick ;
      private string edtavDocumentosid_Jsonclick ;
      private string edtavDocumentosdescricao_Jsonclick ;
      private string GXCCtl ;
      private string cmbavDocumentoobrigatorio_Jsonclick ;
      private string edtavPropostadocumentosanexoname_Jsonclick ;
      private string edtavDocumento_Filetype ;
      private string edtavDocumento_Contenttype ;
      private string edtavDocumento_Parameters ;
      private string edtavDocumento_Jsonclick ;
      private string edtavExtensao_Jsonclick ;
      private string cmbavPropostadocumentosstatus_Jsonclick ;
      private string edtavPropostadocumentosid_Jsonclick ;
      private string subGriddocumentos_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n323PropostaId ;
      private bool n415PropostaDocumentosAnexo ;
      private bool n406DocumentosDescricao ;
      private bool n405DocumentosId ;
      private bool n417PropostaDocumentosAnexoFileType ;
      private bool n579PropostaDocumentosStatus ;
      private bool n416PropostaDocumentosAnexoName ;
      private bool A651PropostaDocumentosAdm ;
      private bool n651PropostaDocumentosAdm ;
      private bool A495ConvenioCategoriaStatus ;
      private bool Combo_propostaresponsavelid_Emptyitem ;
      private bool Combo_procedimentosmedicosid_Enabled ;
      private bool Combo_procedimentosmedicosid_Emptyitem ;
      private bool Combo_convenioid_Enabled ;
      private bool Combo_convenioid_Emptyitem ;
      private bool Combo_conveniocategoriaid_Enabled ;
      private bool Combo_conveniocategoriaid_Emptyitem ;
      private bool Gxuitabspanel_tabs1_Historymanagement ;
      private bool wbLoad ;
      private bool bGXsfl_167_Refreshing=false ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool AV38DocumentoObrigatorio ;
      private bool AV58PropostaDocumentosAdm ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool n227ContratoId ;
      private bool n473ContratoClienteId ;
      private bool n402BancoId ;
      private bool n403BancoNome ;
      private bool n329PropostaStatus ;
      private bool n790PropostaComentarioAnalise ;
      private bool n553PropostaResponsavelId ;
      private bool n504PropostaPacienteClienteId ;
      private bool n642PropostaClinicaId ;
      private bool n590PropostaResponsavelConta ;
      private bool n591PropostaResponsavelAgencia ;
      private bool n592PropostaResponsavelTipoPix ;
      private bool n593PropostaResponsavelPIX ;
      private bool n594PropostaResponsavelDepositoTipo ;
      private bool n584PropostaPacienteConta ;
      private bool n585PropostaPacienteAgencia ;
      private bool n586PropostaPacienteTipoPix ;
      private bool n587PropostaPacientePIX ;
      private bool n588PropostaPacienteDepositoTipo ;
      private bool n376ProcedimentosMedicosId ;
      private bool n410ConvenioId ;
      private bool n493ConvenioCategoriaId ;
      private bool n505PropostaPacienteClienteRazaoSocial ;
      private bool n540PropostaPacienteClienteDocumento ;
      private bool n541PropostaPacienteContatoEmail ;
      private bool n580PropostaResponsavelDocumento ;
      private bool n581PropostaResponsavelRazaoSocial ;
      private bool n582PropostaResponsavelEmail ;
      private bool n378ProcedimentosMedicosDescricao ;
      private bool n326PropostaValor ;
      private bool n325PropostaDescricao ;
      private bool n494ConvenioCategoriaDescricao ;
      private bool n411ConvenioDescricao ;
      private bool n496ConvenioVencimentoAno ;
      private bool n497ConvenioVencimentoMes ;
      private bool n40000GXC1 ;
      private bool bDynCreated_Wcserasaww ;
      private bool gx_refresh_fired ;
      private bool n495ConvenioCategoriaStatus ;
      private bool A412ConvenioStatus ;
      private bool n172ClienteTipoPessoa ;
      private bool A174ClienteStatus ;
      private bool n174ClienteStatus ;
      private bool n201ContatoEmail ;
      private bool n170ClienteRazaoSocial ;
      private bool n169ClienteDocumento ;
      private bool AV60IsContinue ;
      private string AV69DVelop_ConfirmPanel_Aprovar_Proposta_Comment ;
      private string AV70DVelop_ConfirmPanel_Finalizar_analise_Comment ;
      private string A378ProcedimentosMedicosDescricao ;
      private string AV43ProcedimentosMedicosDescricao ;
      private string AV68PropostaStatus ;
      private string A406DocumentosDescricao ;
      private string A417PropostaDocumentosAnexoFileType ;
      private string A579PropostaDocumentosStatus ;
      private string A416PropostaDocumentosAnexoName ;
      private string AV71PropostaComentarioAnalise ;
      private string A494ConvenioCategoriaDescricao ;
      private string AV26ClienteRazaoSocial ;
      private string AV27ClienteDocumento ;
      private string AV28ContatoEmail ;
      private string AV42BancoNome ;
      private string AV21ContaAgencia ;
      private string AV22ContaNumero ;
      private string AV18ClientePixTipo ;
      private string AV19ClientePix ;
      private string AV13PropostaDescricao ;
      private string AV37DocumentosDescricao ;
      private string AV49PropostaDocumentosAnexoName ;
      private string AV40Extensao ;
      private string AV41PropostaDocumentosStatus ;
      private string A403BancoNome ;
      private string A329PropostaStatus ;
      private string A790PropostaComentarioAnalise ;
      private string A590PropostaResponsavelConta ;
      private string A591PropostaResponsavelAgencia ;
      private string A592PropostaResponsavelTipoPix ;
      private string A593PropostaResponsavelPIX ;
      private string A594PropostaResponsavelDepositoTipo ;
      private string A584PropostaPacienteConta ;
      private string A585PropostaPacienteAgencia ;
      private string A586PropostaPacienteTipoPix ;
      private string A587PropostaPacientePIX ;
      private string A588PropostaPacienteDepositoTipo ;
      private string A505PropostaPacienteClienteRazaoSocial ;
      private string A540PropostaPacienteClienteDocumento ;
      private string A541PropostaPacienteContatoEmail ;
      private string A580PropostaResponsavelDocumento ;
      private string A581PropostaResponsavelRazaoSocial ;
      private string A582PropostaResponsavelEmail ;
      private string A325PropostaDescricao ;
      private string A411ConvenioDescricao ;
      private string A589PropostaResponsavelBanco ;
      private string AV48ClienteDepositoTipo ;
      private string A583PropostaPacienteBanco ;
      private string AV24ResponsavelClienteDocumento ;
      private string AV23ResponsavelClienteRazaoSocial ;
      private string AV25ResponsavelContatoEmail ;
      private string AV45ConvenioCategoriaDescricao ;
      private string AV44ConvenioDescricao ;
      private string AV55String ;
      private string A172ClienteTipoPessoa ;
      private string A201ContatoEmail ;
      private string A170ClienteRazaoSocial ;
      private string A169ClienteDocumento ;
      private string AV51Source ;
      private Guid AV50GUID ;
      private string A415PropostaDocumentosAnexo ;
      private string AV39Documento ;
      private IGxSession AV56WEBSESSION ;
      private GXWebComponent WebComp_Wcserasaww ;
      private GxFile gxblobfileaux ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid GriddocumentosContainer ;
      private GXWebRow GriddocumentosRow ;
      private GXWebColumn GriddocumentosColumn ;
      private GXUserControl ucGxuitabspanel_tabs1 ;
      private GXUserControl ucCombo_procedimentosmedicosid ;
      private GXUserControl ucCombo_convenioid ;
      private GXUserControl ucCombo_conveniocategoriaid ;
      private GXUserControl ucNovajanela ;
      private GXUserControl ucGriddocumentos_empowerer ;
      private GXUserControl ucCombo_propostaresponsavelid ;
      private GXUserControl ucDvelop_confirmpanel_aprovar_proposta ;
      private GXUserControl ucDvelop_confirmpanel_finalizar_analise ;
      private GXUserControl ucDvelop_confirmpanel_excluir ;
      private GxFile AV52File ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavClientepixtipo ;
      private GXCombobox cmbavConveniovencimentoano ;
      private GXCombobox cmbavConveniovencimentomes ;
      private GXCombobox cmbavDocumentoobrigatorio ;
      private GXCombobox cmbavPropostadocumentosstatus ;
      private GXCheckbox chkavPropostadocumentosadm ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV67Context ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV72PropostaResponsavelId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV31ProcedimentosMedicosId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV33ConvenioId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV34ConvenioCategoriaId_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext GXt_SdtWWPContext1 ;
      private GxSimpleCollection<int> AV63Array_ClienteId ;
      private IDataStoreProvider pr_default ;
      private int[] H007U3_A227ContratoId ;
      private bool[] H007U3_n227ContratoId ;
      private int[] H007U3_A473ContratoClienteId ;
      private bool[] H007U3_n473ContratoClienteId ;
      private int[] H007U3_A402BancoId ;
      private bool[] H007U3_n402BancoId ;
      private string[] H007U3_A403BancoNome ;
      private bool[] H007U3_n403BancoNome ;
      private int[] H007U3_A323PropostaId ;
      private bool[] H007U3_n323PropostaId ;
      private string[] H007U3_A329PropostaStatus ;
      private bool[] H007U3_n329PropostaStatus ;
      private string[] H007U3_A790PropostaComentarioAnalise ;
      private bool[] H007U3_n790PropostaComentarioAnalise ;
      private int[] H007U3_A553PropostaResponsavelId ;
      private bool[] H007U3_n553PropostaResponsavelId ;
      private int[] H007U3_A504PropostaPacienteClienteId ;
      private bool[] H007U3_n504PropostaPacienteClienteId ;
      private int[] H007U3_A642PropostaClinicaId ;
      private bool[] H007U3_n642PropostaClinicaId ;
      private string[] H007U3_A590PropostaResponsavelConta ;
      private bool[] H007U3_n590PropostaResponsavelConta ;
      private string[] H007U3_A591PropostaResponsavelAgencia ;
      private bool[] H007U3_n591PropostaResponsavelAgencia ;
      private string[] H007U3_A592PropostaResponsavelTipoPix ;
      private bool[] H007U3_n592PropostaResponsavelTipoPix ;
      private string[] H007U3_A593PropostaResponsavelPIX ;
      private bool[] H007U3_n593PropostaResponsavelPIX ;
      private string[] H007U3_A594PropostaResponsavelDepositoTipo ;
      private bool[] H007U3_n594PropostaResponsavelDepositoTipo ;
      private string[] H007U3_A584PropostaPacienteConta ;
      private bool[] H007U3_n584PropostaPacienteConta ;
      private string[] H007U3_A585PropostaPacienteAgencia ;
      private bool[] H007U3_n585PropostaPacienteAgencia ;
      private string[] H007U3_A586PropostaPacienteTipoPix ;
      private bool[] H007U3_n586PropostaPacienteTipoPix ;
      private string[] H007U3_A587PropostaPacientePIX ;
      private bool[] H007U3_n587PropostaPacientePIX ;
      private string[] H007U3_A588PropostaPacienteDepositoTipo ;
      private bool[] H007U3_n588PropostaPacienteDepositoTipo ;
      private int[] H007U3_A376ProcedimentosMedicosId ;
      private bool[] H007U3_n376ProcedimentosMedicosId ;
      private int[] H007U3_A410ConvenioId ;
      private bool[] H007U3_n410ConvenioId ;
      private int[] H007U3_A493ConvenioCategoriaId ;
      private bool[] H007U3_n493ConvenioCategoriaId ;
      private string[] H007U3_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] H007U3_n505PropostaPacienteClienteRazaoSocial ;
      private string[] H007U3_A540PropostaPacienteClienteDocumento ;
      private bool[] H007U3_n540PropostaPacienteClienteDocumento ;
      private string[] H007U3_A541PropostaPacienteContatoEmail ;
      private bool[] H007U3_n541PropostaPacienteContatoEmail ;
      private string[] H007U3_A580PropostaResponsavelDocumento ;
      private bool[] H007U3_n580PropostaResponsavelDocumento ;
      private string[] H007U3_A581PropostaResponsavelRazaoSocial ;
      private bool[] H007U3_n581PropostaResponsavelRazaoSocial ;
      private string[] H007U3_A582PropostaResponsavelEmail ;
      private bool[] H007U3_n582PropostaResponsavelEmail ;
      private string[] H007U3_A378ProcedimentosMedicosDescricao ;
      private bool[] H007U3_n378ProcedimentosMedicosDescricao ;
      private decimal[] H007U3_A326PropostaValor ;
      private bool[] H007U3_n326PropostaValor ;
      private string[] H007U3_A325PropostaDescricao ;
      private bool[] H007U3_n325PropostaDescricao ;
      private string[] H007U3_A494ConvenioCategoriaDescricao ;
      private bool[] H007U3_n494ConvenioCategoriaDescricao ;
      private string[] H007U3_A411ConvenioDescricao ;
      private bool[] H007U3_n411ConvenioDescricao ;
      private short[] H007U3_A496ConvenioVencimentoAno ;
      private bool[] H007U3_n496ConvenioVencimentoAno ;
      private short[] H007U3_A497ConvenioVencimentoMes ;
      private bool[] H007U3_n497ConvenioVencimentoMes ;
      private int[] H007U3_A40000GXC1 ;
      private bool[] H007U3_n40000GXC1 ;
      private int[] H007U4_A323PropostaId ;
      private bool[] H007U4_n323PropostaId ;
      private string[] H007U4_A406DocumentosDescricao ;
      private bool[] H007U4_n406DocumentosDescricao ;
      private int[] H007U4_A405DocumentosId ;
      private bool[] H007U4_n405DocumentosId ;
      private string[] H007U4_A417PropostaDocumentosAnexoFileType ;
      private bool[] H007U4_n417PropostaDocumentosAnexoFileType ;
      private string[] H007U4_A579PropostaDocumentosStatus ;
      private bool[] H007U4_n579PropostaDocumentosStatus ;
      private string[] H007U4_A416PropostaDocumentosAnexoName ;
      private bool[] H007U4_n416PropostaDocumentosAnexoName ;
      private int[] H007U4_A414PropostaDocumentosId ;
      private bool[] H007U4_A651PropostaDocumentosAdm ;
      private bool[] H007U4_n651PropostaDocumentosAdm ;
      private string[] H007U4_A415PropostaDocumentosAnexo ;
      private bool[] H007U4_n415PropostaDocumentosAnexo ;
      private SdtSdErro AV65sdERro ;
      private SdtProposta AV57Proposta ;
      private SdtPropostaDocumentos AV53PropostaDocumentos ;
      private bool[] H007U5_A495ConvenioCategoriaStatus ;
      private bool[] H007U5_n495ConvenioCategoriaStatus ;
      private int[] H007U5_A493ConvenioCategoriaId ;
      private bool[] H007U5_n493ConvenioCategoriaId ;
      private string[] H007U5_A494ConvenioCategoriaDescricao ;
      private bool[] H007U5_n494ConvenioCategoriaDescricao ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV32Combo_DataItem ;
      private int[] H007U6_A410ConvenioId ;
      private bool[] H007U6_n410ConvenioId ;
      private bool[] H007U6_A495ConvenioCategoriaStatus ;
      private bool[] H007U6_n495ConvenioCategoriaStatus ;
      private int[] H007U6_A493ConvenioCategoriaId ;
      private bool[] H007U6_n493ConvenioCategoriaId ;
      private string[] H007U6_A494ConvenioCategoriaDescricao ;
      private bool[] H007U6_n494ConvenioCategoriaDescricao ;
      private bool[] H007U7_A412ConvenioStatus ;
      private int[] H007U7_A410ConvenioId ;
      private bool[] H007U7_n410ConvenioId ;
      private string[] H007U7_A411ConvenioDescricao ;
      private bool[] H007U7_n411ConvenioDescricao ;
      private int[] H007U8_A376ProcedimentosMedicosId ;
      private bool[] H007U8_n376ProcedimentosMedicosId ;
      private string[] H007U8_A378ProcedimentosMedicosDescricao ;
      private bool[] H007U8_n378ProcedimentosMedicosDescricao ;
      private string[] H007U9_A172ClienteTipoPessoa ;
      private bool[] H007U9_n172ClienteTipoPessoa ;
      private bool[] H007U9_A174ClienteStatus ;
      private bool[] H007U9_n174ClienteStatus ;
      private int[] H007U9_A168ClienteId ;
      private string[] H007U9_A201ContatoEmail ;
      private bool[] H007U9_n201ContatoEmail ;
      private string[] H007U9_A170ClienteRazaoSocial ;
      private bool[] H007U9_n170ClienteRazaoSocial ;
      private GxSimpleCollection<string> AV30ComboTitles ;
      private string[] H007U10_A172ClienteTipoPessoa ;
      private bool[] H007U10_n172ClienteTipoPessoa ;
      private bool[] H007U10_A174ClienteStatus ;
      private bool[] H007U10_n174ClienteStatus ;
      private int[] H007U10_A168ClienteId ;
      private string[] H007U10_A169ClienteDocumento ;
      private bool[] H007U10_n169ClienteDocumento ;
      private string[] H007U10_A201ContatoEmail ;
      private bool[] H007U10_n201ContatoEmail ;
      private string[] H007U10_A170ClienteRazaoSocial ;
      private bool[] H007U10_n170ClienteRazaoSocial ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpalterarproposta__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH007U3;
          prmH007U3 = new Object[] {
          new ParDef("AV67Context__Userid",GXType.Int16,4,0) ,
          new ParDef("AV5PropostaId",GXType.Int32,9,0)
          };
          string cmdBufferH007U3;
          cmdBufferH007U3=" SELECT T1.ContratoId, T2.ContratoClienteId AS ContratoClienteId, T3.BancoId, T4.BancoNome, T1.PropostaId, T1.PropostaStatus, T1.PropostaComentarioAnalise, T1.PropostaResponsavelId AS PropostaResponsavelId, T1.PropostaPacienteClienteId AS PropostaPacienteClienteId, T1.PropostaClinicaId, T6.ContaNumero AS PropostaResponsavelConta, T6.ContaAgencia AS PropostaResponsavelAgencia, T6.ClientePixTipo AS PropostaResponsavelTipoPix, T6.ClientePix AS PropostaResponsavelPIX, T6.ClienteDepositoTipo AS PropostaResponsavelDepositoTipo, T7.ContaNumero AS PropostaPacienteConta, T7.ContaAgencia AS PropostaPacienteAgencia, T7.ClientePixTipo AS PropostaPacienteTipoPix, T7.ClientePix AS PropostaPacientePIX, T7.ClienteDepositoTipo AS PropostaPacienteDepositoTipo, T1.ProcedimentosMedicosId, T9.ConvenioId, T1.ConvenioCategoriaId, T7.ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial, T7.ClienteDocumento AS PropostaPacienteClienteDocumento, T7.ContatoEmail AS PropostaPacienteContatoEmail, T6.ClienteDocumento AS PropostaResponsavelDocumento, T6.ClienteRazaoSocial AS PropostaResponsavelRazaoSocial, T6.ContatoEmail AS PropostaResponsavelEmail, T8.ProcedimentosMedicosDescricao, T1.PropostaValor, T1.PropostaDescricao, T9.ConvenioCategoriaDescricao, T10.ConvenioDescricao, T1.ConvenioVencimentoAno, T1.ConvenioVencimentoMes, COALESCE( T5.GXC1, 0) AS GXC1 FROM (((((((((Proposta T1 LEFT JOIN Contrato T2 ON T2.ContratoId = T1.ContratoId) LEFT JOIN Cliente T3 ON T3.ClienteId = T2.ContratoClienteId) LEFT JOIN Banco T4 ON T4.BancoId = T3.BancoId) LEFT JOIN LATERAL (SELECT COUNT(*) AS GXC1, PropostaId FROM Aprovacao WHERE (T1.PropostaId = PropostaId) AND (AprovadoresId = :AV67Context__Userid) GROUP BY PropostaId ) T5 ON T5.PropostaId = T1.PropostaId) LEFT JOIN Cliente T6 ON T6.ClienteId = T1.PropostaResponsavelId) "
          + " LEFT JOIN Cliente T7 ON T7.ClienteId = T1.PropostaPacienteClienteId) LEFT JOIN ProcedimentosMedicos T8 ON T8.ProcedimentosMedicosId = T1.ProcedimentosMedicosId) LEFT JOIN ConvenioCategoria T9 ON T9.ConvenioCategoriaId = T1.ConvenioCategoriaId) LEFT JOIN Convenio T10 ON T10.ConvenioId = T9.ConvenioId) WHERE T1.PropostaId = :AV5PropostaId ORDER BY T1.PropostaId" ;
          Object[] prmH007U4;
          prmH007U4 = new Object[] {
          new ParDef("AV5PropostaId",GXType.Int32,9,0)
          };
          Object[] prmH007U5;
          prmH007U5 = new Object[] {
          };
          Object[] prmH007U6;
          prmH007U6 = new Object[] {
          new ParDef("AV14ConvenioId",GXType.Int32,9,0)
          };
          Object[] prmH007U7;
          prmH007U7 = new Object[] {
          };
          Object[] prmH007U8;
          prmH007U8 = new Object[] {
          };
          Object[] prmH007U9;
          prmH007U9 = new Object[] {
          new ParDef("AV46PropostaPacienteClienteId",GXType.Int32,9,0)
          };
          Object[] prmH007U10;
          prmH007U10 = new Object[] {
          new ParDef("AV46PropostaPacienteClienteId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("H007U3", cmdBufferH007U3,false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007U3,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H007U4", "SELECT T1.PropostaId, T2.DocumentosDescricao, T1.DocumentosId, T1.PropostaDocumentosAnexoFileType, T1.PropostaDocumentosStatus, T1.PropostaDocumentosAnexoName, T1.PropostaDocumentosId, T1.PropostaDocumentosAdm, T1.PropostaDocumentosAnexo FROM (PropostaDocumentos T1 LEFT JOIN Documentos T2 ON T2.DocumentosId = T1.DocumentosId) WHERE (T1.PropostaId = :AV5PropostaId) AND (Not (T1.PropostaDocumentosAnexo = '') and Not T1.PropostaDocumentosAnexo IS NULL) ORDER BY T1.PropostaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007U4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H007U5", "SELECT ConvenioCategoriaStatus, ConvenioCategoriaId, ConvenioCategoriaDescricao FROM ConvenioCategoria WHERE ConvenioCategoriaStatus ORDER BY ConvenioCategoriaDescricao ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007U5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H007U6", "SELECT ConvenioId, ConvenioCategoriaStatus, ConvenioCategoriaId, ConvenioCategoriaDescricao FROM ConvenioCategoria WHERE (ConvenioCategoriaStatus) AND (ConvenioId = :AV14ConvenioId) ORDER BY ConvenioCategoriaDescricao ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007U6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H007U7", "SELECT ConvenioStatus, ConvenioId, ConvenioDescricao FROM Convenio WHERE ConvenioStatus ORDER BY ConvenioDescricao ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007U7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H007U8", "SELECT ProcedimentosMedicosId, ProcedimentosMedicosDescricao FROM ProcedimentosMedicos ORDER BY ProcedimentosMedicosDescricao ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007U8,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H007U9", "SELECT ClienteTipoPessoa, ClienteStatus, ClienteId, ContatoEmail, ClienteRazaoSocial FROM Cliente WHERE (ClienteId <> :AV46PropostaPacienteClienteId) AND (ClienteStatus) AND (ClienteTipoPessoa = ( 'FISICA')) ORDER BY ClienteRazaoSocial ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007U9,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H007U10", "SELECT ClienteTipoPessoa, ClienteStatus, ClienteId, ClienteDocumento, ContatoEmail, ClienteRazaoSocial FROM Cliente WHERE (ClienteId <> :AV46PropostaPacienteClienteId and ClienteStatus) AND (ClienteTipoPessoa = ( 'FISICA')) ORDER BY ClienteRazaoSocial ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007U10,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((int[]) buf[13])[0] = rslt.getInt(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((int[]) buf[15])[0] = rslt.getInt(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((int[]) buf[17])[0] = rslt.getInt(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((string[]) buf[27])[0] = rslt.getVarchar(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((string[]) buf[31])[0] = rslt.getVarchar(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((string[]) buf[35])[0] = rslt.getVarchar(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((string[]) buf[37])[0] = rslt.getVarchar(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((int[]) buf[39])[0] = rslt.getInt(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((int[]) buf[41])[0] = rslt.getInt(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((int[]) buf[43])[0] = rslt.getInt(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((string[]) buf[45])[0] = rslt.getVarchar(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((string[]) buf[47])[0] = rslt.getVarchar(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((string[]) buf[49])[0] = rslt.getVarchar(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((string[]) buf[51])[0] = rslt.getVarchar(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((string[]) buf[53])[0] = rslt.getVarchar(28);
                ((bool[]) buf[54])[0] = rslt.wasNull(28);
                ((string[]) buf[55])[0] = rslt.getVarchar(29);
                ((bool[]) buf[56])[0] = rslt.wasNull(29);
                ((string[]) buf[57])[0] = rslt.getLongVarchar(30);
                ((bool[]) buf[58])[0] = rslt.wasNull(30);
                ((decimal[]) buf[59])[0] = rslt.getDecimal(31);
                ((bool[]) buf[60])[0] = rslt.wasNull(31);
                ((string[]) buf[61])[0] = rslt.getVarchar(32);
                ((bool[]) buf[62])[0] = rslt.wasNull(32);
                ((string[]) buf[63])[0] = rslt.getVarchar(33);
                ((bool[]) buf[64])[0] = rslt.wasNull(33);
                ((string[]) buf[65])[0] = rslt.getVarchar(34);
                ((bool[]) buf[66])[0] = rslt.wasNull(34);
                ((short[]) buf[67])[0] = rslt.getShort(35);
                ((bool[]) buf[68])[0] = rslt.wasNull(35);
                ((short[]) buf[69])[0] = rslt.getShort(36);
                ((bool[]) buf[70])[0] = rslt.wasNull(36);
                ((int[]) buf[71])[0] = rslt.getInt(37);
                ((bool[]) buf[72])[0] = rslt.wasNull(37);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((int[]) buf[12])[0] = rslt.getInt(7);
                ((bool[]) buf[13])[0] = rslt.getBool(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getBLOBFile(9, "tmp", "");
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                return;
             case 2 :
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 4 :
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
       }
    }

 }

}
