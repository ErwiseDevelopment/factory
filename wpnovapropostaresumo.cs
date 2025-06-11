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
   public class wpnovapropostaresumo : GXWebComponent
   {
      public wpnovapropostaresumo( )
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

      public wpnovapropostaresumo( IGxContext context )
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
         cmbavClientepixtipo = new GXCombobox();
         cmbavConveniovencimentoano = new GXCombobox();
         cmbavConveniovencimentomes = new GXCombobox();
         cmbavResumodocumentoobrigatorio = new GXCombobox();
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Griddocc") == 0 )
               {
                  gxnrGriddocc_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Griddocc") == 0 )
               {
                  gxgrGriddocc_refresh_invoke( ) ;
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

      protected void gxnrGriddocc_newrow_invoke( )
      {
         nRC_GXsfl_138 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_138"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_138_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_138_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_138_idx = GetPar( "sGXsfl_138_idx");
         sPrefix = GetPar( "sPrefix");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGriddocc_newrow( ) ;
         /* End function gxnrGriddocc_newrow_invoke */
      }

      protected void gxgrGriddocc_refresh_invoke( )
      {
         subGriddocc_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGriddocc_Rows"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV11WizardData);
         AV10HasValidationErrors = StringUtil.StrToBool( GetPar( "HasValidationErrors"));
         AV35PropostaValor = NumberUtil.Val( GetPar( "PropostaValor"), ".");
         AV36PropostaDescricao = GetPar( "PropostaDescricao");
         cmbavConveniovencimentoano.FromJSonString( GetNextPar( ));
         AV39ConvenioVencimentoAno = (short)(Math.Round(NumberUtil.Val( GetPar( "ConvenioVencimentoAno"), "."), 18, MidpointRounding.ToEven));
         cmbavConveniovencimentomes.FromJSonString( GetNextPar( ));
         AV40ConvenioVencimentoMes = (short)(Math.Round(NumberUtil.Val( GetPar( "ConvenioVencimentoMes"), "."), 18, MidpointRounding.ToEven));
         cmbavClientepixtipo.FromJSonString( GetNextPar( ));
         AV41ClientePixTipo = GetPar( "ClientePixTipo");
         AV42ClientePix = GetPar( "ClientePix");
         AV44ContaAgencia = GetPar( "ContaAgencia");
         AV45ContaNumero = GetPar( "ContaNumero");
         AV46ResponsavelClienteRazaoSocial = GetPar( "ResponsavelClienteRazaoSocial");
         AV47ResponsavelClienteDocumento = GetPar( "ResponsavelClienteDocumento");
         AV48ResponsavelContatoEmail = GetPar( "ResponsavelContatoEmail");
         AV49ClienteRazaoSocial = GetPar( "ClienteRazaoSocial");
         AV50ClienteDocumento = GetPar( "ClienteDocumento");
         AV51ContatoEmail = GetPar( "ContatoEmail");
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGriddocc_refresh( subGriddocc_Rows, AV11WizardData, AV10HasValidationErrors, AV35PropostaValor, AV36PropostaDescricao, AV39ConvenioVencimentoAno, AV40ConvenioVencimentoMes, AV41ClientePixTipo, AV42ClientePix, AV44ContaAgencia, AV45ContaNumero, AV46ResponsavelClienteRazaoSocial, AV47ResponsavelClienteDocumento, AV48ResponsavelContatoEmail, AV49ClienteRazaoSocial, AV50ClienteDocumento, AV51ContatoEmail, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGriddocc_refresh_invoke */
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
            PA6Q2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavClienterazaosocial_Enabled = 0;
               AssignProp(sPrefix, false, edtavClienterazaosocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClienterazaosocial_Enabled), 5, 0), true);
               edtavClientedocumento_Enabled = 0;
               AssignProp(sPrefix, false, edtavClientedocumento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientedocumento_Enabled), 5, 0), true);
               edtavContatoemail_Enabled = 0;
               AssignProp(sPrefix, false, edtavContatoemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavContatoemail_Enabled), 5, 0), true);
               edtavResponsavelclienterazaosocial_Enabled = 0;
               AssignProp(sPrefix, false, edtavResponsavelclienterazaosocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelclienterazaosocial_Enabled), 5, 0), true);
               edtavResponsavelclientedocumento_Enabled = 0;
               AssignProp(sPrefix, false, edtavResponsavelclientedocumento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelclientedocumento_Enabled), 5, 0), true);
               edtavResponsavelcontatoemail_Enabled = 0;
               AssignProp(sPrefix, false, edtavResponsavelcontatoemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelcontatoemail_Enabled), 5, 0), true);
               edtavContaagencia_Enabled = 0;
               AssignProp(sPrefix, false, edtavContaagencia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavContaagencia_Enabled), 5, 0), true);
               edtavContanumero_Enabled = 0;
               AssignProp(sPrefix, false, edtavContanumero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavContanumero_Enabled), 5, 0), true);
               cmbavClientepixtipo.Enabled = 0;
               AssignProp(sPrefix, false, cmbavClientepixtipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavClientepixtipo.Enabled), 5, 0), true);
               edtavClientepix_Enabled = 0;
               AssignProp(sPrefix, false, edtavClientepix_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientepix_Enabled), 5, 0), true);
               edtavPropostavalor_Enabled = 0;
               AssignProp(sPrefix, false, edtavPropostavalor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPropostavalor_Enabled), 5, 0), true);
               edtavPropostadescricao_Enabled = 0;
               AssignProp(sPrefix, false, edtavPropostadescricao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPropostadescricao_Enabled), 5, 0), true);
               cmbavConveniovencimentoano.Enabled = 0;
               AssignProp(sPrefix, false, cmbavConveniovencimentoano_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavConveniovencimentoano.Enabled), 5, 0), true);
               cmbavConveniovencimentomes.Enabled = 0;
               AssignProp(sPrefix, false, cmbavConveniovencimentomes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavConveniovencimentomes.Enabled), 5, 0), true);
               edtavAdicionaranexo_Enabled = 0;
               AssignProp(sPrefix, false, edtavAdicionaranexo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAdicionaranexo_Enabled), 5, 0), !bGXsfl_138_Refreshing);
               edtavResumodocumentosid_Enabled = 0;
               AssignProp(sPrefix, false, edtavResumodocumentosid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResumodocumentosid_Enabled), 5, 0), !bGXsfl_138_Refreshing);
               edtavResumodocumentosdescricao_Enabled = 0;
               AssignProp(sPrefix, false, edtavResumodocumentosdescricao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResumodocumentosdescricao_Enabled), 5, 0), !bGXsfl_138_Refreshing);
               cmbavResumodocumentoobrigatorio.Enabled = 0;
               AssignProp(sPrefix, false, cmbavResumodocumentoobrigatorio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavResumodocumentoobrigatorio.Enabled), 5, 0), !bGXsfl_138_Refreshing);
               edtavResumodocumento_Enabled = 0;
               AssignProp(sPrefix, false, edtavResumodocumento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResumodocumento_Enabled), 5, 0), !bGXsfl_138_Refreshing);
               edtavResumoextensao_Enabled = 0;
               AssignProp(sPrefix, false, edtavResumoextensao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResumoextensao_Enabled), 5, 0), !bGXsfl_138_Refreshing);
               edtavNome_Enabled = 0;
               AssignProp(sPrefix, false, edtavNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNome_Enabled), 5, 0), !bGXsfl_138_Refreshing);
               edtavNomearquivo_Enabled = 0;
               AssignProp(sPrefix, false, edtavNomearquivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNomearquivo_Enabled), 5, 0), !bGXsfl_138_Refreshing);
               WS6Q2( ) ;
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
            context.SendWebValue( "Wp Nova Proposta Resumo") ;
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
            GXEncryptionTmp = "wpnovapropostaresumo"+UrlEncode(StringUtil.RTrim(AV6WebSessionKey)) + "," + UrlEncode(StringUtil.RTrim(AV8PreviousStep)) + "," + UrlEncode(StringUtil.BoolToStr(AV7GoingBack));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpnovapropostaresumo") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPROPOSTAVALOR", GetSecureSignedToken( sPrefix, context.localUtil.Format( AV35PropostaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPROPOSTADESCRICAO", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV36PropostaDescricao, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCONVENIOVENCIMENTOANO", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV39ConvenioVencimentoAno), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCONVENIOVENCIMENTOMES", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV40ConvenioVencimentoMes), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCLIENTEPIXTIPO", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV41ClientePixTipo, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCLIENTEPIX", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV42ClientePix, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCONTAAGENCIA", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV44ContaAgencia, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCONTANUMERO", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV45ContaNumero, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESPONSAVELCLIENTERAZAOSOCIAL", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV46ResponsavelClienteRazaoSocial, "@!")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESPONSAVELCLIENTEDOCUMENTO", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV47ResponsavelClienteDocumento, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESPONSAVELCONTATOEMAIL", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV48ResponsavelContatoEmail, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCLIENTERAZAOSOCIAL", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV49ClienteRazaoSocial, "@!")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCLIENTEDOCUMENTO", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV50ClienteDocumento, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCONTATOEMAIL", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV51ContatoEmail, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"WpNovaPropostaResumo");
         forbiddenHiddens.Add("ClienteRazaoSocial", StringUtil.RTrim( context.localUtil.Format( AV49ClienteRazaoSocial, "@!")));
         forbiddenHiddens.Add("ClienteDocumento", StringUtil.RTrim( context.localUtil.Format( AV50ClienteDocumento, "")));
         forbiddenHiddens.Add("ContatoEmail", StringUtil.RTrim( context.localUtil.Format( AV51ContatoEmail, "")));
         forbiddenHiddens.Add("ResponsavelClienteRazaoSocial", StringUtil.RTrim( context.localUtil.Format( AV46ResponsavelClienteRazaoSocial, "@!")));
         forbiddenHiddens.Add("ResponsavelClienteDocumento", StringUtil.RTrim( context.localUtil.Format( AV47ResponsavelClienteDocumento, "")));
         forbiddenHiddens.Add("ResponsavelContatoEmail", StringUtil.RTrim( context.localUtil.Format( AV48ResponsavelContatoEmail, "")));
         forbiddenHiddens.Add("ContaAgencia", StringUtil.RTrim( context.localUtil.Format( AV44ContaAgencia, "")));
         forbiddenHiddens.Add("ContaNumero", StringUtil.RTrim( context.localUtil.Format( AV45ContaNumero, "")));
         forbiddenHiddens.Add("ClientePixTipo", StringUtil.RTrim( context.localUtil.Format( AV41ClientePixTipo, "")));
         forbiddenHiddens.Add("ClientePix", StringUtil.RTrim( context.localUtil.Format( AV42ClientePix, "")));
         forbiddenHiddens.Add("PropostaValor", context.localUtil.Format( AV35PropostaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"));
         forbiddenHiddens.Add("PropostaDescricao", StringUtil.RTrim( context.localUtil.Format( AV36PropostaDescricao, "")));
         forbiddenHiddens.Add("ConvenioVencimentoAno", context.localUtil.Format( (decimal)(AV39ConvenioVencimentoAno), "ZZZ9"));
         forbiddenHiddens.Add("ConvenioVencimentoMes", context.localUtil.Format( (decimal)(AV40ConvenioVencimentoMes), "ZZZ9"));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("wpnovapropostaresumo:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_138", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_138), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vBANCOID_DATA", AV55BancoId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vBANCOID_DATA", AV55BancoId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vPROCEDIMENTOSMEDICOSID_DATA", AV52ProcedimentosMedicosId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vPROCEDIMENTOSMEDICOSID_DATA", AV52ProcedimentosMedicosId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vCONVENIOID_DATA", AV53ConvenioId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vCONVENIOID_DATA", AV53ConvenioId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vCONVENIOCATEGORIAID_DATA", AV54ConvenioCategoriaId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vCONVENIOCATEGORIAID_DATA", AV54ConvenioCategoriaId_Data);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6WebSessionKey", wcpOAV6WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8PreviousStep", wcpOAV8PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV7GoingBack", wcpOAV7GoingBack);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWIZARDDATA", AV11WizardData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWIZARDDATA", AV11WizardData);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"LIMITEAPROVACAOVALORMINIMO", StringUtil.LTrim( StringUtil.NToC( A332LimiteAprovacaoValorMinimo, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"LIMITEAPROVACAOAPROVACOES", StringUtil.LTrim( StringUtil.NToC( (decimal)(A334LimiteAprovacaoAprovacoes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWEBSESSIONKEY", AV6WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPREVIOUSSTEP", AV8PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vGOINGBACK", AV7GoingBack);
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDDOCC_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDDOCC_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDDOCC_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDDOCC_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"subGriddocc_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddocc_Recordcount), 5, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDDOCC_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddocc_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vHTTPREQUEST_Baseurl", StringUtil.RTrim( AV68HTTPREQUEST.BaseURL));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_CONVENIOCATEGORIAID_Selectedvalue_get", StringUtil.RTrim( Combo_conveniocategoriaid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_CONVENIOID_Selectedvalue_get", StringUtil.RTrim( Combo_convenioid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_PROCEDIMENTOSMEDICOSID_Selectedvalue_get", StringUtil.RTrim( Combo_procedimentosmedicosid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_BANCOID_Selectedvalue_get", StringUtil.RTrim( Combo_bancoid_Selectedvalue_get));
      }

      protected void RenderHtmlCloseForm6Q2( )
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
         return "WpNovaPropostaResumo" ;
      }

      public override string GetPgmdesc( )
      {
         return "Wp Nova Proposta Resumo" ;
      }

      protected void WB6Q0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wpnovapropostaresumo");
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
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, "Paciente", 1, 0, "px", 0, "px", "Group", "", "HLP_WpNovaPropostaResumo.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecliente_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'" + sPrefix + "',false,'" + sGXsfl_138_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClienterazaosocial_Internalname, AV49ClienteRazaoSocial, StringUtil.RTrim( context.localUtil.Format( AV49ClienteRazaoSocial, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,20);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClienterazaosocial_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavClienterazaosocial_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpNovaPropostaResumo.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'" + sGXsfl_138_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientedocumento_Internalname, AV50ClienteDocumento, StringUtil.RTrim( context.localUtil.Format( AV50ClienteDocumento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientedocumento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavClientedocumento_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpNovaPropostaResumo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavContatoemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavContatoemail_Internalname, "E-mail", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'" + sPrefix + "',false,'" + sGXsfl_138_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContatoemail_Internalname, AV51ContatoEmail, StringUtil.RTrim( context.localUtil.Format( AV51ContatoEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContatoemail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavContatoemail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WpNovaPropostaResumo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontentresponsavel_Internalname, divTablecontentresponsavel_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup5_Internalname, "Responsável", 1, 0, "px", 0, "px", "Group", "", "HLP_WpNovaPropostaResumo.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablerespnosavel_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResponsavelclienterazaosocial_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelclienterazaosocial_Internalname, "Nome", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'" + sPrefix + "',false,'" + sGXsfl_138_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelclienterazaosocial_Internalname, AV46ResponsavelClienteRazaoSocial, StringUtil.RTrim( context.localUtil.Format( AV46ResponsavelClienteRazaoSocial, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,40);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelclienterazaosocial_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavResponsavelclienterazaosocial_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpNovaPropostaResumo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResponsavelclientedocumento_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelclientedocumento_Internalname, "Documento", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'" + sPrefix + "',false,'" + sGXsfl_138_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelclientedocumento_Internalname, AV47ResponsavelClienteDocumento, StringUtil.RTrim( context.localUtil.Format( AV47ResponsavelClienteDocumento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelclientedocumento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavResponsavelclientedocumento_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpNovaPropostaResumo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResponsavelcontatoemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResponsavelcontatoemail_Internalname, "E-mail", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'" + sPrefix + "',false,'" + sGXsfl_138_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResponsavelcontatoemail_Internalname, AV48ResponsavelContatoEmail, StringUtil.RTrim( context.localUtil.Format( AV48ResponsavelContatoEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResponsavelcontatoemail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavResponsavelcontatoemail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WpNovaPropostaResumo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup2_Internalname, "Conta / PIX", 1, 0, "px", 0, "px", "Group", "", "HLP_WpNovaPropostaResumo.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableconta_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablebanco_Internalname, divTablebanco_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedbancoid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_bancoid_Internalname, "Banco", "", "", lblTextblockcombo_bancoid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WpNovaPropostaResumo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_bancoid.SetProperty("Caption", Combo_bancoid_Caption);
            ucCombo_bancoid.SetProperty("Cls", Combo_bancoid_Cls);
            ucCombo_bancoid.SetProperty("EmptyItem", Combo_bancoid_Emptyitem);
            ucCombo_bancoid.SetProperty("DropDownOptionsData", AV55BancoId_Data);
            ucCombo_bancoid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_bancoid_Internalname, sPrefix+"COMBO_BANCOIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'" + sPrefix + "',false,'" + sGXsfl_138_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContaagencia_Internalname, AV44ContaAgencia, StringUtil.RTrim( context.localUtil.Format( AV44ContaAgencia, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContaagencia_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavContaagencia_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpNovaPropostaResumo.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'" + sPrefix + "',false,'" + sGXsfl_138_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavContanumero_Internalname, AV45ContaNumero, StringUtil.RTrim( context.localUtil.Format( AV45ContaNumero, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavContanumero_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavContanumero_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpNovaPropostaResumo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablepix_Internalname, divTablepix_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'" + sPrefix + "',false,'" + sGXsfl_138_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavClientepixtipo, cmbavClientepixtipo_Internalname, StringUtil.RTrim( AV41ClientePixTipo), 1, cmbavClientepixtipo_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavClientepixtipo.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"", "", true, 0, "HLP_WpNovaPropostaResumo.htm");
            cmbavClientepixtipo.CurrentValue = StringUtil.RTrim( AV41ClientePixTipo);
            AssignProp(sPrefix, false, cmbavClientepixtipo_Internalname, "Values", (string)(cmbavClientepixtipo.ToJavascriptSource()), true);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'" + sPrefix + "',false,'" + sGXsfl_138_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientepix_Internalname, AV42ClientePix, StringUtil.RTrim( context.localUtil.Format( AV42ClientePix, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,82);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientepix_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavClientepix_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpNovaPropostaResumo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup3_Internalname, "Proposta", 1, 0, "px", 0, "px", "Group", "", "HLP_WpNovaPropostaResumo.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_procedimentosmedicosid_Internalname, "Procedimento", "", "", lblTextblockcombo_procedimentosmedicosid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WpNovaPropostaResumo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_procedimentosmedicosid.SetProperty("Caption", Combo_procedimentosmedicosid_Caption);
            ucCombo_procedimentosmedicosid.SetProperty("Cls", Combo_procedimentosmedicosid_Cls);
            ucCombo_procedimentosmedicosid.SetProperty("EmptyItem", Combo_procedimentosmedicosid_Emptyitem);
            ucCombo_procedimentosmedicosid.SetProperty("DropDownOptionsData", AV52ProcedimentosMedicosId_Data);
            ucCombo_procedimentosmedicosid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_procedimentosmedicosid_Internalname, sPrefix+"COMBO_PROCEDIMENTOSMEDICOSIDContainer");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'" + sPrefix + "',false,'" + sGXsfl_138_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostavalor_Internalname, StringUtil.LTrim( StringUtil.NToC( AV35PropostaValor, 18, 2, ",", "")), StringUtil.LTrim( ((edtavPropostavalor_Enabled!=0) ? context.localUtil.Format( AV35PropostaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV35PropostaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,97);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostavalor_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavPropostavalor_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpNovaPropostaResumo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPropostadescricao_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostadescricao_Internalname, "Descrição", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'" + sPrefix + "',false,'" + sGXsfl_138_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostadescricao_Internalname, AV36PropostaDescricao, StringUtil.RTrim( context.localUtil.Format( AV36PropostaDescricao, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,102);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostadescricao_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavPropostadescricao_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpNovaPropostaResumo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedconvenioid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_convenioid_Internalname, "Convênio", "", "", lblTextblockcombo_convenioid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WpNovaPropostaResumo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_convenioid.SetProperty("Caption", Combo_convenioid_Caption);
            ucCombo_convenioid.SetProperty("Cls", Combo_convenioid_Cls);
            ucCombo_convenioid.SetProperty("EmptyItem", Combo_convenioid_Emptyitem);
            ucCombo_convenioid.SetProperty("DropDownOptionsData", AV53ConvenioId_Data);
            ucCombo_convenioid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_convenioid_Internalname, sPrefix+"COMBO_CONVENIOIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedconveniocategoriaid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_conveniocategoriaid_Internalname, "Categoria do convênio", "", "", lblTextblockcombo_conveniocategoriaid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WpNovaPropostaResumo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_conveniocategoriaid.SetProperty("Caption", Combo_conveniocategoriaid_Caption);
            ucCombo_conveniocategoriaid.SetProperty("Cls", Combo_conveniocategoriaid_Cls);
            ucCombo_conveniocategoriaid.SetProperty("EmptyItem", Combo_conveniocategoriaid_Emptyitem);
            ucCombo_conveniocategoriaid.SetProperty("DropDownOptionsData", AV54ConvenioCategoriaId_Data);
            ucCombo_conveniocategoriaid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_conveniocategoriaid_Internalname, sPrefix+"COMBO_CONVENIOCATEGORIAIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedconveniovencimentoano_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockconveniovencimentoano_Internalname, "Ano vencimento carteira", "", "", lblTextblockconveniovencimentoano_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WpNovaPropostaResumo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            wb_table1_124_6Q2( true) ;
         }
         else
         {
            wb_table1_124_6Q2( false) ;
         }
         return  ;
      }

      protected void wb_table1_124_6Q2e( bool wbgen )
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup4_Internalname, "Documentos", 1, 0, "px", 0, "px", "Group", "", "HLP_WpNovaPropostaResumo.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledocumentos_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 HasGridEmpowerer", "start", "top", "", "", "div");
            /*  Grid Control  */
            GriddoccContainer.SetWrapped(nGXWrapped);
            StartGridControl138( ) ;
         }
         if ( wbEnd == 138 )
         {
            wbEnd = 0;
            nRC_GXsfl_138 = (int)(nGXsfl_138_idx-1);
            if ( GriddoccContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GriddoccContainer.AddObjectProperty("GRIDDOCC_nEOF", GRIDDOCC_nEOF);
               GriddoccContainer.AddObjectProperty("GRIDDOCC_nFirstRecordOnPage", GRIDDOCC_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"GriddoccContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Griddocc", GriddoccContainer, subGriddocc_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GriddoccContainerData", GriddoccContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GriddoccContainerData"+"V", GriddoccContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GriddoccContainerData"+"V"+"\" value='"+GriddoccContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
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
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 160,'" + sPrefix + "',false,'" + sGXsfl_138_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavBancoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43BancoId), 9, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV43BancoId), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,160);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavBancoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavBancoid_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpNovaPropostaResumo.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 161,'" + sPrefix + "',false,'" + sGXsfl_138_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProcedimentosmedicosid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34ProcedimentosMedicosId), 9, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV34ProcedimentosMedicosId), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,161);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProcedimentosmedicosid_Jsonclick, 0, "Attribute", "", "", "", "", edtavProcedimentosmedicosid_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpNovaPropostaResumo.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 162,'" + sPrefix + "',false,'" + sGXsfl_138_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConvenioid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV37ConvenioId), 9, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV37ConvenioId), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,162);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConvenioid_Jsonclick, 0, "Attribute", "", "", "", "", edtavConvenioid_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpNovaPropostaResumo.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 163,'" + sPrefix + "',false,'" + sGXsfl_138_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConveniocategoriaid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV38ConvenioCategoriaId), 9, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV38ConvenioCategoriaId), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,163);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConveniocategoriaid_Jsonclick, 0, "Attribute", "", "", "", "", edtavConveniocategoriaid_Visible, 1, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpNovaPropostaResumo.htm");
            /* User Defined Control */
            ucGriddocc_empowerer.Render(context, "wwp.gridempowerer", Griddocc_empowerer_Internalname, sPrefix+"GRIDDOCC_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 138 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GriddoccContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  GriddoccContainer.AddObjectProperty("GRIDDOCC_nEOF", GRIDDOCC_nEOF);
                  GriddoccContainer.AddObjectProperty("GRIDDOCC_nFirstRecordOnPage", GRIDDOCC_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"GriddoccContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Griddocc", GriddoccContainer, subGriddocc_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GriddoccContainerData", GriddoccContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GriddoccContainerData"+"V", GriddoccContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GriddoccContainerData"+"V"+"\" value='"+GriddoccContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START6Q2( )
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
            Form.Meta.addItem("description", "Wp Nova Proposta Resumo", 0) ;
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
               STRUP6Q0( ) ;
            }
         }
      }

      protected void WS6Q2( )
      {
         START6Q2( ) ;
         EVT6Q2( ) ;
      }

      protected void EVT6Q2( )
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
                                 STRUP6Q0( ) ;
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
                                 STRUP6Q0( ) ;
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
                                          E116Q2 ();
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
                                 STRUP6Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'WizardPrevious' */
                                    E126Q2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6Q0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "GRIDDOCCPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6Q0( ) ;
                              }
                              sEvt = cgiGet( sPrefix+"GRIDDOCCPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgriddocc_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgriddocc_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgriddocc_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgriddocc_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "GRIDDOCC.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 21), "VADICIONARANEXO.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 21), "VADICIONARANEXO.CLICK") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6Q0( ) ;
                              }
                              nGXsfl_138_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_138_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_138_idx), 4, 0), 4, "0");
                              SubsflControlProps_1382( ) ;
                              AV32AdicionarAnexo = cgiGet( edtavAdicionaranexo_Internalname);
                              AssignAttri(sPrefix, false, edtavAdicionaranexo_Internalname, AV32AdicionarAnexo);
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavResumodocumentosid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavResumodocumentosid_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vRESUMODOCUMENTOSID");
                                 GX_FocusControl = edtavResumodocumentosid_Internalname;
                                 AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV27ResumoDocumentosId = 0;
                                 AssignAttri(sPrefix, false, edtavResumodocumentosid_Internalname, StringUtil.LTrimStr( (decimal)(AV27ResumoDocumentosId), 9, 0));
                                 GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESUMODOCUMENTOSID"+"_"+sGXsfl_138_idx, GetSecureSignedToken( sPrefix+sGXsfl_138_idx, context.localUtil.Format( (decimal)(AV27ResumoDocumentosId), "ZZZZZZZZ9"), context));
                              }
                              else
                              {
                                 AV27ResumoDocumentosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavResumodocumentosid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                                 AssignAttri(sPrefix, false, edtavResumodocumentosid_Internalname, StringUtil.LTrimStr( (decimal)(AV27ResumoDocumentosId), 9, 0));
                                 GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESUMODOCUMENTOSID"+"_"+sGXsfl_138_idx, GetSecureSignedToken( sPrefix+sGXsfl_138_idx, context.localUtil.Format( (decimal)(AV27ResumoDocumentosId), "ZZZZZZZZ9"), context));
                              }
                              AV28ResumoDocumentosDescricao = cgiGet( edtavResumodocumentosdescricao_Internalname);
                              AssignAttri(sPrefix, false, edtavResumodocumentosdescricao_Internalname, AV28ResumoDocumentosDescricao);
                              GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESUMODOCUMENTOSDESCRICAO"+"_"+sGXsfl_138_idx, GetSecureSignedToken( sPrefix+sGXsfl_138_idx, StringUtil.RTrim( context.localUtil.Format( AV28ResumoDocumentosDescricao, "")), context));
                              cmbavResumodocumentoobrigatorio.Name = cmbavResumodocumentoobrigatorio_Internalname;
                              cmbavResumodocumentoobrigatorio.CurrentValue = cgiGet( cmbavResumodocumentoobrigatorio_Internalname);
                              AV29ResumoDocumentoObrigatorio = StringUtil.StrToBool( cgiGet( cmbavResumodocumentoobrigatorio_Internalname));
                              AssignAttri(sPrefix, false, cmbavResumodocumentoobrigatorio_Internalname, AV29ResumoDocumentoObrigatorio);
                              GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESUMODOCUMENTOOBRIGATORIO"+"_"+sGXsfl_138_idx, GetSecureSignedToken( sPrefix+sGXsfl_138_idx, AV29ResumoDocumentoObrigatorio, context));
                              AV30ResumoDocumento = cgiGet( edtavResumodocumento_Internalname);
                              AssignProp(sPrefix, false, edtavResumodocumento_Internalname, "URL", context.PathToRelativeUrl( AV30ResumoDocumento), !bGXsfl_138_Refreshing);
                              AV31ResumoExtensao = cgiGet( edtavResumoextensao_Internalname);
                              AssignAttri(sPrefix, false, edtavResumoextensao_Internalname, AV31ResumoExtensao);
                              GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESUMOEXTENSAO"+"_"+sGXsfl_138_idx, GetSecureSignedToken( sPrefix+sGXsfl_138_idx, StringUtil.RTrim( context.localUtil.Format( AV31ResumoExtensao, "")), context));
                              AV71Nome = cgiGet( edtavNome_Internalname);
                              AssignAttri(sPrefix, false, edtavNome_Internalname, AV71Nome);
                              GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vNOME"+"_"+sGXsfl_138_idx, GetSecureSignedToken( sPrefix+sGXsfl_138_idx, StringUtil.RTrim( context.localUtil.Format( AV71Nome, "")), context));
                              AV72NomeArquivo = cgiGet( edtavNomearquivo_Internalname);
                              AssignAttri(sPrefix, false, edtavNomearquivo_Internalname, AV72NomeArquivo);
                              GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vNOMEARQUIVO"+"_"+sGXsfl_138_idx, GetSecureSignedToken( sPrefix+sGXsfl_138_idx, StringUtil.RTrim( context.localUtil.Format( AV72NomeArquivo, "")), context));
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
                                          E136Q2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDDOCC.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavAdicionaranexo_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Griddocc.Load */
                                          E146Q2 ();
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
                                          E156Q2 ();
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP6Q0( ) ;
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

      protected void WE6Q2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm6Q2( ) ;
            }
         }
      }

      protected void PA6Q2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpnovapropostaresumo")), "wpnovapropostaresumo") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpnovapropostaresumo")))) ;
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
               GX_FocusControl = edtavClienterazaosocial_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGriddocc_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1382( ) ;
         while ( nGXsfl_138_idx <= nRC_GXsfl_138 )
         {
            sendrow_1382( ) ;
            nGXsfl_138_idx = ((subGriddocc_Islastpage==1)&&(nGXsfl_138_idx+1>subGriddocc_fnc_Recordsperpage( )) ? 1 : nGXsfl_138_idx+1);
            sGXsfl_138_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_138_idx), 4, 0), 4, "0");
            SubsflControlProps_1382( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GriddoccContainer)) ;
         /* End function gxnrGriddocc_newrow */
      }

      protected void gxgrGriddocc_refresh( int subGriddocc_Rows ,
                                           SdtWpNovaPropostaData AV11WizardData ,
                                           bool AV10HasValidationErrors ,
                                           decimal AV35PropostaValor ,
                                           string AV36PropostaDescricao ,
                                           short AV39ConvenioVencimentoAno ,
                                           short AV40ConvenioVencimentoMes ,
                                           string AV41ClientePixTipo ,
                                           string AV42ClientePix ,
                                           string AV44ContaAgencia ,
                                           string AV45ContaNumero ,
                                           string AV46ResponsavelClienteRazaoSocial ,
                                           string AV47ResponsavelClienteDocumento ,
                                           string AV48ResponsavelContatoEmail ,
                                           string AV49ClienteRazaoSocial ,
                                           string AV50ClienteDocumento ,
                                           string AV51ContatoEmail ,
                                           string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDDOCC_nCurrentRecord = 0;
         RF6Q2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"WpNovaPropostaResumo");
         forbiddenHiddens.Add("ClienteRazaoSocial", StringUtil.RTrim( context.localUtil.Format( AV49ClienteRazaoSocial, "@!")));
         forbiddenHiddens.Add("ClienteDocumento", StringUtil.RTrim( context.localUtil.Format( AV50ClienteDocumento, "")));
         forbiddenHiddens.Add("ContatoEmail", StringUtil.RTrim( context.localUtil.Format( AV51ContatoEmail, "")));
         forbiddenHiddens.Add("ResponsavelClienteRazaoSocial", StringUtil.RTrim( context.localUtil.Format( AV46ResponsavelClienteRazaoSocial, "@!")));
         forbiddenHiddens.Add("ResponsavelClienteDocumento", StringUtil.RTrim( context.localUtil.Format( AV47ResponsavelClienteDocumento, "")));
         forbiddenHiddens.Add("ResponsavelContatoEmail", StringUtil.RTrim( context.localUtil.Format( AV48ResponsavelContatoEmail, "")));
         forbiddenHiddens.Add("ContaAgencia", StringUtil.RTrim( context.localUtil.Format( AV44ContaAgencia, "")));
         forbiddenHiddens.Add("ContaNumero", StringUtil.RTrim( context.localUtil.Format( AV45ContaNumero, "")));
         forbiddenHiddens.Add("ClientePixTipo", StringUtil.RTrim( context.localUtil.Format( AV41ClientePixTipo, "")));
         forbiddenHiddens.Add("ClientePix", StringUtil.RTrim( context.localUtil.Format( AV42ClientePix, "")));
         forbiddenHiddens.Add("PropostaValor", context.localUtil.Format( AV35PropostaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"));
         forbiddenHiddens.Add("PropostaDescricao", StringUtil.RTrim( context.localUtil.Format( AV36PropostaDescricao, "")));
         forbiddenHiddens.Add("ConvenioVencimentoAno", context.localUtil.Format( (decimal)(AV39ConvenioVencimentoAno), "ZZZ9"));
         forbiddenHiddens.Add("ConvenioVencimentoMes", context.localUtil.Format( (decimal)(AV40ConvenioVencimentoMes), "ZZZ9"));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("wpnovapropostaresumo:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
         /* End function gxgrGriddocc_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESUMODOCUMENTOSID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV27ResumoDocumentosId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vRESUMODOCUMENTOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27ResumoDocumentosId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESUMODOCUMENTOSDESCRICAO", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV28ResumoDocumentosDescricao, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vRESUMODOCUMENTOSDESCRICAO", AV28ResumoDocumentosDescricao);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESUMODOCUMENTOOBRIGATORIO", GetSecureSignedToken( sPrefix, AV29ResumoDocumentoObrigatorio, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vRESUMODOCUMENTOOBRIGATORIO", StringUtil.BoolToStr( AV29ResumoDocumentoObrigatorio));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESUMOEXTENSAO", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV31ResumoExtensao, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vRESUMOEXTENSAO", AV31ResumoExtensao);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vNOME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV71Nome, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vNOME", AV71Nome);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vNOMEARQUIVO", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV72NomeArquivo, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vNOMEARQUIVO", AV72NomeArquivo);
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
            AV41ClientePixTipo = cmbavClientepixtipo.getValidValue(AV41ClientePixTipo);
            AssignAttri(sPrefix, false, "AV41ClientePixTipo", AV41ClientePixTipo);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCLIENTEPIXTIPO", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV41ClientePixTipo, "")), context));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavClientepixtipo.CurrentValue = StringUtil.RTrim( AV41ClientePixTipo);
            AssignProp(sPrefix, false, cmbavClientepixtipo_Internalname, "Values", cmbavClientepixtipo.ToJavascriptSource(), true);
         }
         if ( cmbavConveniovencimentoano.ItemCount > 0 )
         {
            AV39ConvenioVencimentoAno = (short)(Math.Round(NumberUtil.Val( cmbavConveniovencimentoano.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV39ConvenioVencimentoAno), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV39ConvenioVencimentoAno", StringUtil.LTrimStr( (decimal)(AV39ConvenioVencimentoAno), 4, 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCONVENIOVENCIMENTOANO", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV39ConvenioVencimentoAno), "ZZZ9"), context));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavConveniovencimentoano.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV39ConvenioVencimentoAno), 4, 0));
            AssignProp(sPrefix, false, cmbavConveniovencimentoano_Internalname, "Values", cmbavConveniovencimentoano.ToJavascriptSource(), true);
         }
         if ( cmbavConveniovencimentomes.ItemCount > 0 )
         {
            AV40ConvenioVencimentoMes = (short)(Math.Round(NumberUtil.Val( cmbavConveniovencimentomes.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV40ConvenioVencimentoMes), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV40ConvenioVencimentoMes", StringUtil.LTrimStr( (decimal)(AV40ConvenioVencimentoMes), 4, 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCONVENIOVENCIMENTOMES", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV40ConvenioVencimentoMes), "ZZZ9"), context));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavConveniovencimentomes.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV40ConvenioVencimentoMes), 4, 0));
            AssignProp(sPrefix, false, cmbavConveniovencimentomes_Internalname, "Values", cmbavConveniovencimentomes.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF6Q2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavClienterazaosocial_Enabled = 0;
         AssignProp(sPrefix, false, edtavClienterazaosocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClienterazaosocial_Enabled), 5, 0), true);
         edtavClientedocumento_Enabled = 0;
         AssignProp(sPrefix, false, edtavClientedocumento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientedocumento_Enabled), 5, 0), true);
         edtavContatoemail_Enabled = 0;
         AssignProp(sPrefix, false, edtavContatoemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavContatoemail_Enabled), 5, 0), true);
         edtavResponsavelclienterazaosocial_Enabled = 0;
         AssignProp(sPrefix, false, edtavResponsavelclienterazaosocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelclienterazaosocial_Enabled), 5, 0), true);
         edtavResponsavelclientedocumento_Enabled = 0;
         AssignProp(sPrefix, false, edtavResponsavelclientedocumento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelclientedocumento_Enabled), 5, 0), true);
         edtavResponsavelcontatoemail_Enabled = 0;
         AssignProp(sPrefix, false, edtavResponsavelcontatoemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelcontatoemail_Enabled), 5, 0), true);
         edtavContaagencia_Enabled = 0;
         AssignProp(sPrefix, false, edtavContaagencia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavContaagencia_Enabled), 5, 0), true);
         edtavContanumero_Enabled = 0;
         AssignProp(sPrefix, false, edtavContanumero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavContanumero_Enabled), 5, 0), true);
         cmbavClientepixtipo.Enabled = 0;
         AssignProp(sPrefix, false, cmbavClientepixtipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavClientepixtipo.Enabled), 5, 0), true);
         edtavClientepix_Enabled = 0;
         AssignProp(sPrefix, false, edtavClientepix_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientepix_Enabled), 5, 0), true);
         edtavPropostavalor_Enabled = 0;
         AssignProp(sPrefix, false, edtavPropostavalor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPropostavalor_Enabled), 5, 0), true);
         edtavPropostadescricao_Enabled = 0;
         AssignProp(sPrefix, false, edtavPropostadescricao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPropostadescricao_Enabled), 5, 0), true);
         cmbavConveniovencimentoano.Enabled = 0;
         AssignProp(sPrefix, false, cmbavConveniovencimentoano_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavConveniovencimentoano.Enabled), 5, 0), true);
         cmbavConveniovencimentomes.Enabled = 0;
         AssignProp(sPrefix, false, cmbavConveniovencimentomes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavConveniovencimentomes.Enabled), 5, 0), true);
         edtavAdicionaranexo_Enabled = 0;
         edtavResumodocumentosid_Enabled = 0;
         edtavResumodocumentosdescricao_Enabled = 0;
         cmbavResumodocumentoobrigatorio.Enabled = 0;
         edtavResumodocumento_Enabled = 0;
         edtavResumoextensao_Enabled = 0;
         edtavNome_Enabled = 0;
         edtavNomearquivo_Enabled = 0;
      }

      protected void RF6Q2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GriddoccContainer.ClearRows();
         }
         wbStart = 138;
         nGXsfl_138_idx = 1;
         sGXsfl_138_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_138_idx), 4, 0), 4, "0");
         SubsflControlProps_1382( ) ;
         bGXsfl_138_Refreshing = true;
         GriddoccContainer.AddObjectProperty("GridName", "Griddocc");
         GriddoccContainer.AddObjectProperty("CmpContext", sPrefix);
         GriddoccContainer.AddObjectProperty("InMasterPage", "false");
         GriddoccContainer.AddObjectProperty("Class", "GridWithBorderColor WorkWith");
         GriddoccContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GriddoccContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GriddoccContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddocc_Backcolorstyle), 1, 0, ".", "")));
         GriddoccContainer.PageSize = subGriddocc_fnc_Recordsperpage( );
         if ( subGriddocc_Islastpage != 0 )
         {
            GRIDDOCC_nFirstRecordOnPage = (long)(subGriddocc_fnc_Recordcount( )-subGriddocc_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRIDDOCC_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDDOCC_nFirstRecordOnPage), 15, 0, ".", "")));
            GriddoccContainer.AddObjectProperty("GRIDDOCC_nFirstRecordOnPage", GRIDDOCC_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1382( ) ;
            /* Execute user event: Griddocc.Load */
            E146Q2 ();
            if ( ( subGriddocc_Islastpage == 0 ) && ( GRIDDOCC_nCurrentRecord > 0 ) && ( GRIDDOCC_nGridOutOfScope == 0 ) && ( nGXsfl_138_idx == 1 ) )
            {
               GRIDDOCC_nCurrentRecord = 0;
               GRIDDOCC_nGridOutOfScope = 1;
               subgriddocc_firstpage( ) ;
               /* Execute user event: Griddocc.Load */
               E146Q2 ();
            }
            wbEnd = 138;
            WB6Q0( ) ;
         }
         bGXsfl_138_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes6Q2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESUMODOCUMENTOSID"+"_"+sGXsfl_138_idx, GetSecureSignedToken( sPrefix+sGXsfl_138_idx, context.localUtil.Format( (decimal)(AV27ResumoDocumentosId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESUMODOCUMENTOSDESCRICAO"+"_"+sGXsfl_138_idx, GetSecureSignedToken( sPrefix+sGXsfl_138_idx, StringUtil.RTrim( context.localUtil.Format( AV28ResumoDocumentosDescricao, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESUMODOCUMENTOOBRIGATORIO"+"_"+sGXsfl_138_idx, GetSecureSignedToken( sPrefix+sGXsfl_138_idx, AV29ResumoDocumentoObrigatorio, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESUMOEXTENSAO"+"_"+sGXsfl_138_idx, GetSecureSignedToken( sPrefix+sGXsfl_138_idx, StringUtil.RTrim( context.localUtil.Format( AV31ResumoExtensao, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vNOME"+"_"+sGXsfl_138_idx, GetSecureSignedToken( sPrefix+sGXsfl_138_idx, StringUtil.RTrim( context.localUtil.Format( AV71Nome, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vNOMEARQUIVO"+"_"+sGXsfl_138_idx, GetSecureSignedToken( sPrefix+sGXsfl_138_idx, StringUtil.RTrim( context.localUtil.Format( AV72NomeArquivo, "")), context));
      }

      protected int subGriddocc_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGriddocc_fnc_Recordcount( )
      {
         return (int)(((subGriddocc_Recordcount==0) ? GRIDDOCC_nFirstRecordOnPage+1 : subGriddocc_Recordcount)) ;
      }

      protected int subGriddocc_fnc_Recordsperpage( )
      {
         if ( subGriddocc_Rows > 0 )
         {
            return subGriddocc_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGriddocc_fnc_Currentpage( )
      {
         return (int)(((subGriddocc_Islastpage==1) ? NumberUtil.Int( (long)(Math.Round(subGriddocc_fnc_Recordcount( )/ (decimal)(subGriddocc_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+((((int)((subGriddocc_fnc_Recordcount( )) % (subGriddocc_fnc_Recordsperpage( ))))==0) ? 0 : 1) : NumberUtil.Int( (long)(Math.Round(GRIDDOCC_nFirstRecordOnPage/ (decimal)(subGriddocc_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1)) ;
      }

      protected short subgriddocc_firstpage( )
      {
         GRIDDOCC_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDDOCC_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDDOCC_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGriddocc_refresh( subGriddocc_Rows, AV11WizardData, AV10HasValidationErrors, AV35PropostaValor, AV36PropostaDescricao, AV39ConvenioVencimentoAno, AV40ConvenioVencimentoMes, AV41ClientePixTipo, AV42ClientePix, AV44ContaAgencia, AV45ContaNumero, AV46ResponsavelClienteRazaoSocial, AV47ResponsavelClienteDocumento, AV48ResponsavelContatoEmail, AV49ClienteRazaoSocial, AV50ClienteDocumento, AV51ContatoEmail, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgriddocc_nextpage( )
      {
         if ( GRIDDOCC_nEOF == 0 )
         {
            GRIDDOCC_nFirstRecordOnPage = (long)(GRIDDOCC_nFirstRecordOnPage+subGriddocc_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDDOCC_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDDOCC_nFirstRecordOnPage), 15, 0, ".", "")));
         GriddoccContainer.AddObjectProperty("GRIDDOCC_nFirstRecordOnPage", GRIDDOCC_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGriddocc_refresh( subGriddocc_Rows, AV11WizardData, AV10HasValidationErrors, AV35PropostaValor, AV36PropostaDescricao, AV39ConvenioVencimentoAno, AV40ConvenioVencimentoMes, AV41ClientePixTipo, AV42ClientePix, AV44ContaAgencia, AV45ContaNumero, AV46ResponsavelClienteRazaoSocial, AV47ResponsavelClienteDocumento, AV48ResponsavelContatoEmail, AV49ClienteRazaoSocial, AV50ClienteDocumento, AV51ContatoEmail, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRIDDOCC_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgriddocc_previouspage( )
      {
         if ( GRIDDOCC_nFirstRecordOnPage >= subGriddocc_fnc_Recordsperpage( ) )
         {
            GRIDDOCC_nFirstRecordOnPage = (long)(GRIDDOCC_nFirstRecordOnPage-subGriddocc_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDDOCC_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDDOCC_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGriddocc_refresh( subGriddocc_Rows, AV11WizardData, AV10HasValidationErrors, AV35PropostaValor, AV36PropostaDescricao, AV39ConvenioVencimentoAno, AV40ConvenioVencimentoMes, AV41ClientePixTipo, AV42ClientePix, AV44ContaAgencia, AV45ContaNumero, AV46ResponsavelClienteRazaoSocial, AV47ResponsavelClienteDocumento, AV48ResponsavelContatoEmail, AV49ClienteRazaoSocial, AV50ClienteDocumento, AV51ContatoEmail, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgriddocc_lastpage( )
      {
         subGriddocc_Islastpage = 1;
         if ( isFullAjaxMode( ) )
         {
            gxgrGriddocc_refresh( subGriddocc_Rows, AV11WizardData, AV10HasValidationErrors, AV35PropostaValor, AV36PropostaDescricao, AV39ConvenioVencimentoAno, AV40ConvenioVencimentoMes, AV41ClientePixTipo, AV42ClientePix, AV44ContaAgencia, AV45ContaNumero, AV46ResponsavelClienteRazaoSocial, AV47ResponsavelClienteDocumento, AV48ResponsavelContatoEmail, AV49ClienteRazaoSocial, AV50ClienteDocumento, AV51ContatoEmail, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgriddocc_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRIDDOCC_nFirstRecordOnPage = (long)(subGriddocc_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRIDDOCC_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDDOCC_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDDOCC_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGriddocc_refresh( subGriddocc_Rows, AV11WizardData, AV10HasValidationErrors, AV35PropostaValor, AV36PropostaDescricao, AV39ConvenioVencimentoAno, AV40ConvenioVencimentoMes, AV41ClientePixTipo, AV42ClientePix, AV44ContaAgencia, AV45ContaNumero, AV46ResponsavelClienteRazaoSocial, AV47ResponsavelClienteDocumento, AV48ResponsavelContatoEmail, AV49ClienteRazaoSocial, AV50ClienteDocumento, AV51ContatoEmail, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtavClienterazaosocial_Enabled = 0;
         AssignProp(sPrefix, false, edtavClienterazaosocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClienterazaosocial_Enabled), 5, 0), true);
         edtavClientedocumento_Enabled = 0;
         AssignProp(sPrefix, false, edtavClientedocumento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientedocumento_Enabled), 5, 0), true);
         edtavContatoemail_Enabled = 0;
         AssignProp(sPrefix, false, edtavContatoemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavContatoemail_Enabled), 5, 0), true);
         edtavResponsavelclienterazaosocial_Enabled = 0;
         AssignProp(sPrefix, false, edtavResponsavelclienterazaosocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelclienterazaosocial_Enabled), 5, 0), true);
         edtavResponsavelclientedocumento_Enabled = 0;
         AssignProp(sPrefix, false, edtavResponsavelclientedocumento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelclientedocumento_Enabled), 5, 0), true);
         edtavResponsavelcontatoemail_Enabled = 0;
         AssignProp(sPrefix, false, edtavResponsavelcontatoemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResponsavelcontatoemail_Enabled), 5, 0), true);
         edtavContaagencia_Enabled = 0;
         AssignProp(sPrefix, false, edtavContaagencia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavContaagencia_Enabled), 5, 0), true);
         edtavContanumero_Enabled = 0;
         AssignProp(sPrefix, false, edtavContanumero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavContanumero_Enabled), 5, 0), true);
         cmbavClientepixtipo.Enabled = 0;
         AssignProp(sPrefix, false, cmbavClientepixtipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavClientepixtipo.Enabled), 5, 0), true);
         edtavClientepix_Enabled = 0;
         AssignProp(sPrefix, false, edtavClientepix_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientepix_Enabled), 5, 0), true);
         edtavPropostavalor_Enabled = 0;
         AssignProp(sPrefix, false, edtavPropostavalor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPropostavalor_Enabled), 5, 0), true);
         edtavPropostadescricao_Enabled = 0;
         AssignProp(sPrefix, false, edtavPropostadescricao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPropostadescricao_Enabled), 5, 0), true);
         cmbavConveniovencimentoano.Enabled = 0;
         AssignProp(sPrefix, false, cmbavConveniovencimentoano_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavConveniovencimentoano.Enabled), 5, 0), true);
         cmbavConveniovencimentomes.Enabled = 0;
         AssignProp(sPrefix, false, cmbavConveniovencimentomes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavConveniovencimentomes.Enabled), 5, 0), true);
         edtavAdicionaranexo_Enabled = 0;
         edtavResumodocumentosid_Enabled = 0;
         edtavResumodocumentosdescricao_Enabled = 0;
         cmbavResumodocumentoobrigatorio.Enabled = 0;
         edtavResumodocumento_Enabled = 0;
         edtavResumoextensao_Enabled = 0;
         edtavNome_Enabled = 0;
         edtavNomearquivo_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP6Q0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E136Q2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vBANCOID_DATA"), AV55BancoId_Data);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vPROCEDIMENTOSMEDICOSID_DATA"), AV52ProcedimentosMedicosId_Data);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vCONVENIOID_DATA"), AV53ConvenioId_Data);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vCONVENIOCATEGORIAID_DATA"), AV54ConvenioCategoriaId_Data);
            /* Read saved values. */
            nRC_GXsfl_138 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_138"), ",", "."), 18, MidpointRounding.ToEven));
            wcpOAV6WebSessionKey = cgiGet( sPrefix+"wcpOAV6WebSessionKey");
            wcpOAV8PreviousStep = cgiGet( sPrefix+"wcpOAV8PreviousStep");
            wcpOAV7GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV7GoingBack"));
            GRIDDOCC_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDDOCC_nFirstRecordOnPage"), ",", "."), 18, MidpointRounding.ToEven));
            GRIDDOCC_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDDOCC_nEOF"), ",", "."), 18, MidpointRounding.ToEven));
            subGriddocc_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"subGriddocc_Recordcount"), ",", "."), 18, MidpointRounding.ToEven));
            subGriddocc_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDDOCC_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRIDDOCC_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddocc_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV49ClienteRazaoSocial = StringUtil.Upper( cgiGet( edtavClienterazaosocial_Internalname));
            AssignAttri(sPrefix, false, "AV49ClienteRazaoSocial", AV49ClienteRazaoSocial);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCLIENTERAZAOSOCIAL", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV49ClienteRazaoSocial, "@!")), context));
            AV50ClienteDocumento = cgiGet( edtavClientedocumento_Internalname);
            AssignAttri(sPrefix, false, "AV50ClienteDocumento", AV50ClienteDocumento);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCLIENTEDOCUMENTO", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV50ClienteDocumento, "")), context));
            AV51ContatoEmail = cgiGet( edtavContatoemail_Internalname);
            AssignAttri(sPrefix, false, "AV51ContatoEmail", AV51ContatoEmail);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCONTATOEMAIL", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV51ContatoEmail, "")), context));
            AV46ResponsavelClienteRazaoSocial = StringUtil.Upper( cgiGet( edtavResponsavelclienterazaosocial_Internalname));
            AssignAttri(sPrefix, false, "AV46ResponsavelClienteRazaoSocial", AV46ResponsavelClienteRazaoSocial);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESPONSAVELCLIENTERAZAOSOCIAL", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV46ResponsavelClienteRazaoSocial, "@!")), context));
            AV47ResponsavelClienteDocumento = cgiGet( edtavResponsavelclientedocumento_Internalname);
            AssignAttri(sPrefix, false, "AV47ResponsavelClienteDocumento", AV47ResponsavelClienteDocumento);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESPONSAVELCLIENTEDOCUMENTO", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV47ResponsavelClienteDocumento, "")), context));
            AV48ResponsavelContatoEmail = cgiGet( edtavResponsavelcontatoemail_Internalname);
            AssignAttri(sPrefix, false, "AV48ResponsavelContatoEmail", AV48ResponsavelContatoEmail);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESPONSAVELCONTATOEMAIL", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV48ResponsavelContatoEmail, "")), context));
            AV44ContaAgencia = cgiGet( edtavContaagencia_Internalname);
            AssignAttri(sPrefix, false, "AV44ContaAgencia", AV44ContaAgencia);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCONTAAGENCIA", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV44ContaAgencia, "")), context));
            AV45ContaNumero = cgiGet( edtavContanumero_Internalname);
            AssignAttri(sPrefix, false, "AV45ContaNumero", AV45ContaNumero);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCONTANUMERO", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV45ContaNumero, "")), context));
            cmbavClientepixtipo.Name = cmbavClientepixtipo_Internalname;
            cmbavClientepixtipo.CurrentValue = cgiGet( cmbavClientepixtipo_Internalname);
            AV41ClientePixTipo = cgiGet( cmbavClientepixtipo_Internalname);
            AssignAttri(sPrefix, false, "AV41ClientePixTipo", AV41ClientePixTipo);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCLIENTEPIXTIPO", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV41ClientePixTipo, "")), context));
            AV42ClientePix = cgiGet( edtavClientepix_Internalname);
            AssignAttri(sPrefix, false, "AV42ClientePix", AV42ClientePix);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCLIENTEPIX", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV42ClientePix, "")), context));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPropostavalor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPropostavalor_Internalname), ",", ".") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPROPOSTAVALOR");
               GX_FocusControl = edtavPropostavalor_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV35PropostaValor = 0;
               AssignAttri(sPrefix, false, "AV35PropostaValor", StringUtil.LTrimStr( AV35PropostaValor, 18, 2));
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPROPOSTAVALOR", GetSecureSignedToken( sPrefix, context.localUtil.Format( AV35PropostaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"), context));
            }
            else
            {
               AV35PropostaValor = context.localUtil.CToN( cgiGet( edtavPropostavalor_Internalname), ",", ".");
               AssignAttri(sPrefix, false, "AV35PropostaValor", StringUtil.LTrimStr( AV35PropostaValor, 18, 2));
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPROPOSTAVALOR", GetSecureSignedToken( sPrefix, context.localUtil.Format( AV35PropostaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"), context));
            }
            AV36PropostaDescricao = cgiGet( edtavPropostadescricao_Internalname);
            AssignAttri(sPrefix, false, "AV36PropostaDescricao", AV36PropostaDescricao);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPROPOSTADESCRICAO", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV36PropostaDescricao, "")), context));
            cmbavConveniovencimentoano.Name = cmbavConveniovencimentoano_Internalname;
            cmbavConveniovencimentoano.CurrentValue = cgiGet( cmbavConveniovencimentoano_Internalname);
            AV39ConvenioVencimentoAno = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavConveniovencimentoano_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV39ConvenioVencimentoAno", StringUtil.LTrimStr( (decimal)(AV39ConvenioVencimentoAno), 4, 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCONVENIOVENCIMENTOANO", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV39ConvenioVencimentoAno), "ZZZ9"), context));
            cmbavConveniovencimentomes.Name = cmbavConveniovencimentomes_Internalname;
            cmbavConveniovencimentomes.CurrentValue = cgiGet( cmbavConveniovencimentomes_Internalname);
            AV40ConvenioVencimentoMes = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavConveniovencimentomes_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV40ConvenioVencimentoMes", StringUtil.LTrimStr( (decimal)(AV40ConvenioVencimentoMes), 4, 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCONVENIOVENCIMENTOMES", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV40ConvenioVencimentoMes), "ZZZ9"), context));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavBancoid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavBancoid_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vBANCOID");
               GX_FocusControl = edtavBancoid_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV43BancoId = 0;
               AssignAttri(sPrefix, false, "AV43BancoId", StringUtil.LTrimStr( (decimal)(AV43BancoId), 9, 0));
            }
            else
            {
               AV43BancoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavBancoid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV43BancoId", StringUtil.LTrimStr( (decimal)(AV43BancoId), 9, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavProcedimentosmedicosid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavProcedimentosmedicosid_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPROCEDIMENTOSMEDICOSID");
               GX_FocusControl = edtavProcedimentosmedicosid_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV34ProcedimentosMedicosId = 0;
               AssignAttri(sPrefix, false, "AV34ProcedimentosMedicosId", StringUtil.LTrimStr( (decimal)(AV34ProcedimentosMedicosId), 9, 0));
            }
            else
            {
               AV34ProcedimentosMedicosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavProcedimentosmedicosid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV34ProcedimentosMedicosId", StringUtil.LTrimStr( (decimal)(AV34ProcedimentosMedicosId), 9, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavConvenioid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavConvenioid_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCONVENIOID");
               GX_FocusControl = edtavConvenioid_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV37ConvenioId = 0;
               AssignAttri(sPrefix, false, "AV37ConvenioId", StringUtil.LTrimStr( (decimal)(AV37ConvenioId), 9, 0));
            }
            else
            {
               AV37ConvenioId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavConvenioid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV37ConvenioId", StringUtil.LTrimStr( (decimal)(AV37ConvenioId), 9, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavConveniocategoriaid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavConveniocategoriaid_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCONVENIOCATEGORIAID");
               GX_FocusControl = edtavConveniocategoriaid_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV38ConvenioCategoriaId = 0;
               AssignAttri(sPrefix, false, "AV38ConvenioCategoriaId", StringUtil.LTrimStr( (decimal)(AV38ConvenioCategoriaId), 9, 0));
            }
            else
            {
               AV38ConvenioCategoriaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavConveniocategoriaid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV38ConvenioCategoriaId", StringUtil.LTrimStr( (decimal)(AV38ConvenioCategoriaId), 9, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"WpNovaPropostaResumo");
            AV49ClienteRazaoSocial = cgiGet( edtavClienterazaosocial_Internalname);
            AssignAttri(sPrefix, false, "AV49ClienteRazaoSocial", AV49ClienteRazaoSocial);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCLIENTERAZAOSOCIAL", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV49ClienteRazaoSocial, "@!")), context));
            forbiddenHiddens.Add("ClienteRazaoSocial", StringUtil.RTrim( context.localUtil.Format( AV49ClienteRazaoSocial, "@!")));
            AV50ClienteDocumento = cgiGet( edtavClientedocumento_Internalname);
            AssignAttri(sPrefix, false, "AV50ClienteDocumento", AV50ClienteDocumento);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCLIENTEDOCUMENTO", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV50ClienteDocumento, "")), context));
            forbiddenHiddens.Add("ClienteDocumento", StringUtil.RTrim( context.localUtil.Format( AV50ClienteDocumento, "")));
            AV51ContatoEmail = cgiGet( edtavContatoemail_Internalname);
            AssignAttri(sPrefix, false, "AV51ContatoEmail", AV51ContatoEmail);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCONTATOEMAIL", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV51ContatoEmail, "")), context));
            forbiddenHiddens.Add("ContatoEmail", StringUtil.RTrim( context.localUtil.Format( AV51ContatoEmail, "")));
            AV46ResponsavelClienteRazaoSocial = cgiGet( edtavResponsavelclienterazaosocial_Internalname);
            AssignAttri(sPrefix, false, "AV46ResponsavelClienteRazaoSocial", AV46ResponsavelClienteRazaoSocial);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESPONSAVELCLIENTERAZAOSOCIAL", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV46ResponsavelClienteRazaoSocial, "@!")), context));
            forbiddenHiddens.Add("ResponsavelClienteRazaoSocial", StringUtil.RTrim( context.localUtil.Format( AV46ResponsavelClienteRazaoSocial, "@!")));
            AV47ResponsavelClienteDocumento = cgiGet( edtavResponsavelclientedocumento_Internalname);
            AssignAttri(sPrefix, false, "AV47ResponsavelClienteDocumento", AV47ResponsavelClienteDocumento);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESPONSAVELCLIENTEDOCUMENTO", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV47ResponsavelClienteDocumento, "")), context));
            forbiddenHiddens.Add("ResponsavelClienteDocumento", StringUtil.RTrim( context.localUtil.Format( AV47ResponsavelClienteDocumento, "")));
            AV48ResponsavelContatoEmail = cgiGet( edtavResponsavelcontatoemail_Internalname);
            AssignAttri(sPrefix, false, "AV48ResponsavelContatoEmail", AV48ResponsavelContatoEmail);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESPONSAVELCONTATOEMAIL", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV48ResponsavelContatoEmail, "")), context));
            forbiddenHiddens.Add("ResponsavelContatoEmail", StringUtil.RTrim( context.localUtil.Format( AV48ResponsavelContatoEmail, "")));
            AV44ContaAgencia = cgiGet( edtavContaagencia_Internalname);
            AssignAttri(sPrefix, false, "AV44ContaAgencia", AV44ContaAgencia);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCONTAAGENCIA", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV44ContaAgencia, "")), context));
            forbiddenHiddens.Add("ContaAgencia", StringUtil.RTrim( context.localUtil.Format( AV44ContaAgencia, "")));
            AV45ContaNumero = cgiGet( edtavContanumero_Internalname);
            AssignAttri(sPrefix, false, "AV45ContaNumero", AV45ContaNumero);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCONTANUMERO", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV45ContaNumero, "")), context));
            forbiddenHiddens.Add("ContaNumero", StringUtil.RTrim( context.localUtil.Format( AV45ContaNumero, "")));
            AV41ClientePixTipo = cgiGet( cmbavClientepixtipo_Internalname);
            AssignAttri(sPrefix, false, "AV41ClientePixTipo", AV41ClientePixTipo);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCLIENTEPIXTIPO", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV41ClientePixTipo, "")), context));
            forbiddenHiddens.Add("ClientePixTipo", StringUtil.RTrim( context.localUtil.Format( AV41ClientePixTipo, "")));
            AV42ClientePix = cgiGet( edtavClientepix_Internalname);
            AssignAttri(sPrefix, false, "AV42ClientePix", AV42ClientePix);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCLIENTEPIX", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV42ClientePix, "")), context));
            forbiddenHiddens.Add("ClientePix", StringUtil.RTrim( context.localUtil.Format( AV42ClientePix, "")));
            AV35PropostaValor = context.localUtil.CToN( cgiGet( edtavPropostavalor_Internalname), ",", ".");
            AssignAttri(sPrefix, false, "AV35PropostaValor", StringUtil.LTrimStr( AV35PropostaValor, 18, 2));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPROPOSTAVALOR", GetSecureSignedToken( sPrefix, context.localUtil.Format( AV35PropostaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"), context));
            forbiddenHiddens.Add("PropostaValor", context.localUtil.Format( AV35PropostaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"));
            AV36PropostaDescricao = cgiGet( edtavPropostadescricao_Internalname);
            AssignAttri(sPrefix, false, "AV36PropostaDescricao", AV36PropostaDescricao);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPROPOSTADESCRICAO", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV36PropostaDescricao, "")), context));
            forbiddenHiddens.Add("PropostaDescricao", StringUtil.RTrim( context.localUtil.Format( AV36PropostaDescricao, "")));
            AV39ConvenioVencimentoAno = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavConveniovencimentoano_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV39ConvenioVencimentoAno", StringUtil.LTrimStr( (decimal)(AV39ConvenioVencimentoAno), 4, 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCONVENIOVENCIMENTOANO", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV39ConvenioVencimentoAno), "ZZZ9"), context));
            forbiddenHiddens.Add("ConvenioVencimentoAno", context.localUtil.Format( (decimal)(AV39ConvenioVencimentoAno), "ZZZ9"));
            AV40ConvenioVencimentoMes = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavConveniovencimentomes_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV40ConvenioVencimentoMes", StringUtil.LTrimStr( (decimal)(AV40ConvenioVencimentoMes), 4, 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCONVENIOVENCIMENTOMES", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV40ConvenioVencimentoMes), "ZZZ9"), context));
            forbiddenHiddens.Add("ConvenioVencimentoMes", context.localUtil.Format( (decimal)(AV40ConvenioVencimentoMes), "ZZZ9"));
            hsh = cgiGet( sPrefix+"hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("wpnovapropostaresumo:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
         E136Q2 ();
         if (returnInSub) return;
      }

      protected void E136Q2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADVARIABLESFROMWIZARDDATA' */
         S112 ();
         if (returnInSub) return;
         edtavConveniocategoriaid_Visible = 0;
         AssignProp(sPrefix, false, edtavConveniocategoriaid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavConveniocategoriaid_Visible), 5, 0), true);
         Combo_conveniocategoriaid_Enabled = false;
         ucCombo_conveniocategoriaid.SendProperty(context, sPrefix, false, Combo_conveniocategoriaid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_conveniocategoriaid_Enabled));
         edtavConvenioid_Visible = 0;
         AssignProp(sPrefix, false, edtavConvenioid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavConvenioid_Visible), 5, 0), true);
         Combo_convenioid_Enabled = false;
         ucCombo_convenioid.SendProperty(context, sPrefix, false, Combo_convenioid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_convenioid_Enabled));
         edtavProcedimentosmedicosid_Visible = 0;
         AssignProp(sPrefix, false, edtavProcedimentosmedicosid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProcedimentosmedicosid_Visible), 5, 0), true);
         GXt_char1 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and subtitle", out  GXt_char1) ;
         Combo_procedimentosmedicosid_Htmltemplate = GXt_char1;
         ucCombo_procedimentosmedicosid.SendProperty(context, sPrefix, false, Combo_procedimentosmedicosid_Internalname, "HTMLTemplate", Combo_procedimentosmedicosid_Htmltemplate);
         Combo_procedimentosmedicosid_Enabled = false;
         ucCombo_procedimentosmedicosid.SendProperty(context, sPrefix, false, Combo_procedimentosmedicosid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_procedimentosmedicosid_Enabled));
         edtavBancoid_Visible = 0;
         AssignProp(sPrefix, false, edtavBancoid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavBancoid_Visible), 5, 0), true);
         GXt_char1 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and subtitle", out  GXt_char1) ;
         Combo_bancoid_Htmltemplate = GXt_char1;
         ucCombo_bancoid.SendProperty(context, sPrefix, false, Combo_bancoid_Internalname, "HTMLTemplate", Combo_bancoid_Htmltemplate);
         Combo_bancoid_Enabled = false;
         ucCombo_bancoid.SendProperty(context, sPrefix, false, Combo_bancoid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_bancoid_Enabled));
         /* Execute user subroutine: 'LOADCOMBOBANCOID' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOPROCEDIMENTOSMEDICOSID' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOCONVENIOID' */
         S142 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOCONVENIOCATEGORIAID' */
         S152 ();
         if (returnInSub) return;
         Griddocc_empowerer_Gridinternalname = subGriddocc_Internalname;
         ucGriddocc_empowerer.SendProperty(context, sPrefix, false, Griddocc_empowerer_Internalname, "GridInternalName", Griddocc_empowerer_Gridinternalname);
         subGriddocc_Rows = 10;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDDOCC_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddocc_Rows), 6, 0, ".", "")));
      }

      private void E146Q2( )
      {
         /* Griddocc_Load Routine */
         returnInSub = false;
         AV77GXV1 = 1;
         while ( AV77GXV1 <= AV11WizardData.gxTpr_Documentos.gxTpr_Griddocumentos.Count )
         {
            AV70Grid = ((SdtWpNovaPropostaData_Documentos_GridDocumentosItem)AV11WizardData.gxTpr_Documentos.gxTpr_Griddocumentos.Item(AV77GXV1));
            AV30ResumoDocumento = AV70Grid.gxTpr_Documento;
            AssignAttri(sPrefix, false, edtavResumodocumento_Internalname, AV30ResumoDocumento);
            AV28ResumoDocumentosDescricao = AV70Grid.gxTpr_Documentosdescricao;
            AssignAttri(sPrefix, false, edtavResumodocumentosdescricao_Internalname, AV28ResumoDocumentosDescricao);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESUMODOCUMENTOSDESCRICAO"+"_"+sGXsfl_138_idx, GetSecureSignedToken( sPrefix+sGXsfl_138_idx, StringUtil.RTrim( context.localUtil.Format( AV28ResumoDocumentosDescricao, "")), context));
            AV27ResumoDocumentosId = AV70Grid.gxTpr_Documentosid;
            AssignAttri(sPrefix, false, edtavResumodocumentosid_Internalname, StringUtil.LTrimStr( (decimal)(AV27ResumoDocumentosId), 9, 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESUMODOCUMENTOSID"+"_"+sGXsfl_138_idx, GetSecureSignedToken( sPrefix+sGXsfl_138_idx, context.localUtil.Format( (decimal)(AV27ResumoDocumentosId), "ZZZZZZZZ9"), context));
            AV31ResumoExtensao = AV70Grid.gxTpr_Extensao;
            AssignAttri(sPrefix, false, edtavResumoextensao_Internalname, AV31ResumoExtensao);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESUMOEXTENSAO"+"_"+sGXsfl_138_idx, GetSecureSignedToken( sPrefix+sGXsfl_138_idx, StringUtil.RTrim( context.localUtil.Format( AV31ResumoExtensao, "")), context));
            AV72NomeArquivo = AV70Grid.gxTpr_Nomearquivo;
            AssignAttri(sPrefix, false, edtavNomearquivo_Internalname, AV72NomeArquivo);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vNOMEARQUIVO"+"_"+sGXsfl_138_idx, GetSecureSignedToken( sPrefix+sGXsfl_138_idx, StringUtil.RTrim( context.localUtil.Format( AV72NomeArquivo, "")), context));
            AV32AdicionarAnexo = "<i class=\"fas fa-download\"></i>";
            AssignAttri(sPrefix, false, edtavAdicionaranexo_Internalname, AV32AdicionarAnexo);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 138;
            }
            if ( ( subGriddocc_Islastpage == 1 ) || ( subGriddocc_Rows == 0 ) || ( ( GRIDDOCC_nCurrentRecord >= GRIDDOCC_nFirstRecordOnPage ) && ( GRIDDOCC_nCurrentRecord < GRIDDOCC_nFirstRecordOnPage + subGriddocc_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_1382( ) ;
            }
            GRIDDOCC_nEOF = (short)(((GRIDDOCC_nCurrentRecord<GRIDDOCC_nFirstRecordOnPage+subGriddocc_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRIDDOCC_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDDOCC_nEOF), 1, 0, ".", "")));
            GRIDDOCC_nCurrentRecord = (long)(GRIDDOCC_nCurrentRecord+1);
            subGriddocc_Recordcount = (int)(GRIDDOCC_nCurrentRecord);
            if ( isFullAjaxMode( ) && ! bGXsfl_138_Refreshing )
            {
               DoAjaxLoad(138, GriddoccRow);
            }
            AV77GXV1 = (int)(AV77GXV1+1);
         }
         /*  Sending Event outputs  */
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E116Q2 ();
         if (returnInSub) return;
      }

      protected void E116Q2( )
      {
         /* Enter Routine */
         returnInSub = false;
         if ( 1 == 2 )
         {
            if ( ! AV10HasValidationErrors )
            {
               /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
               S162 ();
               if (returnInSub) return;
               if ( StringUtil.Len( sPrefix) == 0 )
               {
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
                  {
                     gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
                  }
               }
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               GXEncryptionTmp = "wpnovaproposta"+UrlEncode(StringUtil.RTrim("Resumo")) + "," + UrlEncode(StringUtil.RTrim("Proposta_Criada")) + "," + UrlEncode(StringUtil.BoolToStr(false));
               CallWebObject(formatLink("wpnovaproposta") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
               context.wjLocDisableFrm = 1;
            }
         }
         GXt_SdtWWPContext2 = AV56WwpContext;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  GXt_SdtWWPContext2) ;
         AV56WwpContext = GXt_SdtWWPContext2;
         if ( (0==AV56WwpContext.gxTpr_Userid) )
         {
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         AV57PropostaQuantidadeAprovadores = 0;
         /* Using cursor H006Q2 */
         pr_default.execute(0, new Object[] {AV35PropostaValor});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A332LimiteAprovacaoValorMinimo = H006Q2_A332LimiteAprovacaoValorMinimo[0];
            n332LimiteAprovacaoValorMinimo = H006Q2_n332LimiteAprovacaoValorMinimo[0];
            A334LimiteAprovacaoAprovacoes = H006Q2_A334LimiteAprovacaoAprovacoes[0];
            n334LimiteAprovacaoAprovacoes = H006Q2_n334LimiteAprovacaoAprovacoes[0];
            AV57PropostaQuantidadeAprovadores = A334LimiteAprovacaoAprovacoes;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV58Proposta = new SdtProposta(context);
         AV58Proposta.gxTpr_Procedimentosmedicosid = AV34ProcedimentosMedicosId;
         AV58Proposta.gxTpr_Propostadescricao = AV36PropostaDescricao;
         AV58Proposta.gxTpr_Propostavalor = AV35PropostaValor;
         AV58Proposta.gxTpr_Propostastatus = "PENDENTE";
         AV58Proposta.gxTpr_Propostaresponsavelid = (AV11WizardData.gxTpr_Novocliente.gxTpr_Possuiresponsavel ? AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelclienteid : AV11WizardData.gxTpr_Novocliente.gxTpr_Clienteid);
         AV58Proposta.gxTpr_Propostapacienteclienteid = AV11WizardData.gxTpr_Novocliente.gxTpr_Clienteid;
         AV58Proposta.gxTpr_Conveniocategoriaid = AV11WizardData.gxTpr_Proposta.gxTpr_Conveniocategoriaid;
         AV58Proposta.gxTpr_Conveniovencimentoano = AV11WizardData.gxTpr_Proposta.gxTpr_Conveniovencimentoano;
         AV58Proposta.gxTpr_Conveniovencimentomes = AV11WizardData.gxTpr_Proposta.gxTpr_Conveniovencimentomes;
         AV58Proposta.gxTpr_Propostaquantidadeaprovadores = AV57PropostaQuantidadeAprovadores;
         AV58Proposta.gxTpr_Propostacratedby = AV56WwpContext.gxTpr_Userid;
         AV58Proposta.gxTpr_Propostaclinicaid = AV56WwpContext.gxTpr_Ownerid;
         new getclinicatax(context ).execute(  AV56WwpContext.gxTpr_Secuserclienteid, out  AV59ContratoTaxa, out  AV60ContratoSLA, out  AV61ContratoJurosMora, out  AV62ContratoIOFMinimo) ;
         AV58Proposta.gxTpr_Propostataxaadministrativa = AV59ContratoTaxa;
         AV58Proposta.gxTpr_Propostasla = AV60ContratoSLA;
         AV58Proposta.gxTpr_Propostajurosmora = AV61ContratoJurosMora;
         new insertproposta(context ).execute(  AV58Proposta, out  AV63Messages) ;
         if ( (0==AV63Messages.Count) )
         {
            AV64IsContinue = true;
            AV79GXV2 = 1;
            while ( AV79GXV2 <= AV11WizardData.gxTpr_Documentos.gxTpr_Griddocumentos.Count )
            {
               AV70Grid = ((SdtWpNovaPropostaData_Documentos_GridDocumentosItem)AV11WizardData.gxTpr_Documentos.gxTpr_Griddocumentos.Item(AV79GXV2));
               AV66PropostaDocumentos = new SdtPropostaDocumentos(context);
               AV66PropostaDocumentos.gxTpr_Propostaid = AV58Proposta.gxTpr_Propostaid;
               AV66PropostaDocumentos.gxTpr_Documentosid = AV70Grid.gxTpr_Documentosid;
               AV66PropostaDocumentos.gxTpr_Propostadocumentosanexo = AV70Grid.gxTpr_Documento;
               AV66PropostaDocumentos.gxTpr_Propostadocumentosanexoname = AV70Grid.gxTpr_Documentosdescricao;
               AV66PropostaDocumentos.gxTpr_Propostadocumentosanexofiletype = "pdf";
               AV66PropostaDocumentos.gxTpr_Propostadocumentosstatus = "AGUARDANDO_ANALISE";
               AV66PropostaDocumentos.Save();
               if ( AV66PropostaDocumentos.Fail() )
               {
                  AV64IsContinue = false;
                  context.RollbackDataStores("wpnovapropostaresumo",pr_default);
                  GXt_objcol_SdtMessages_Message3 = AV66PropostaDocumentos.GetMessages();
                  new showmessages(context ).gxep_error( ref  GXt_objcol_SdtMessages_Message3) ;
               }
               AV79GXV2 = (int)(AV79GXV2+1);
            }
            if ( AV64IsContinue )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wpconsultaproposta"+UrlEncode(StringUtil.LTrimStr(AV58Proposta.gxTpr_Propostaid,9,0));
               AV67NotificationLink = AV68HTTPREQUEST.BaseURL + formatLink("wpconsultaproposta") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
               GXt_char1 = AV69HTML;
               new premailnotificacao(context ).execute( out  GXt_char1) ;
               AV69HTML = GXt_char1;
               new prenviarnotificacoesaprovadores(context ).execute(  "Nova proposta",  "Uma nova proposta foi criada no valor de R$"+context.localUtil.Format( AV35PropostaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99")+". De "+AV56WwpContext.gxTpr_Userfullname,  "Internal",  AV67NotificationLink,  AV56WwpContext.gxTpr_Userid,  AV69HTML, out  AV63Messages) ;
               if ( ! (0==AV63Messages.Count) )
               {
                  context.RollbackDataStores("wpnovapropostaresumo",pr_default);
                  context.setWebReturnParms(new Object[] {});
                  context.setWebReturnParmsMetadata(new Object[] {});
                  context.wjLocDisableFrm = 1;
                  context.nUserReturn = 1;
                  returnInSub = true;
                  if (true) return;
               }
               context.CommitDataStores("wpnovapropostaresumo",pr_default);
               if ( ! AV10HasValidationErrors )
               {
                  /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
                  S162 ();
                  if (returnInSub) return;
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
                     {
                        gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
                     }
                  }
                  GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
                  GXEncryptionTmp = "wpnovaproposta"+UrlEncode(StringUtil.RTrim("Resumo")) + "," + UrlEncode(StringUtil.RTrim("Proposta_Criada")) + "," + UrlEncode(StringUtil.BoolToStr(false));
                  CallWebObject(formatLink("wpnovaproposta") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
                  context.wjLocDisableFrm = 1;
               }
            }
         }
         else
         {
            context.RollbackDataStores("wpnovapropostaresumo",pr_default);
            new showmessages(context ).gxep_error( ref  AV63Messages) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11WizardData", AV11WizardData);
      }

      protected void E126Q2( )
      {
         /* 'WizardPrevious' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
         S162 ();
         if (returnInSub) return;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpnovaproposta"+UrlEncode(StringUtil.RTrim("Resumo")) + "," + UrlEncode(StringUtil.RTrim("Documentos")) + "," + UrlEncode(StringUtil.BoolToStr(true));
         CallWebObject(formatLink("wpnovaproposta") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11WizardData", AV11WizardData);
      }

      protected void S112( )
      {
         /* 'LOADVARIABLESFROMWIZARDDATA' Routine */
         returnInSub = false;
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
         AV34ProcedimentosMedicosId = AV11WizardData.gxTpr_Resumo.gxTpr_Procedimentosmedicosid;
         AssignAttri(sPrefix, false, "AV34ProcedimentosMedicosId", StringUtil.LTrimStr( (decimal)(AV34ProcedimentosMedicosId), 9, 0));
         AV35PropostaValor = AV11WizardData.gxTpr_Resumo.gxTpr_Propostavalor;
         AssignAttri(sPrefix, false, "AV35PropostaValor", StringUtil.LTrimStr( AV35PropostaValor, 18, 2));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPROPOSTAVALOR", GetSecureSignedToken( sPrefix, context.localUtil.Format( AV35PropostaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"), context));
         AV36PropostaDescricao = AV11WizardData.gxTpr_Resumo.gxTpr_Propostadescricao;
         AssignAttri(sPrefix, false, "AV36PropostaDescricao", AV36PropostaDescricao);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPROPOSTADESCRICAO", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV36PropostaDescricao, "")), context));
         AV37ConvenioId = AV11WizardData.gxTpr_Resumo.gxTpr_Convenioid;
         AssignAttri(sPrefix, false, "AV37ConvenioId", StringUtil.LTrimStr( (decimal)(AV37ConvenioId), 9, 0));
         AV38ConvenioCategoriaId = AV11WizardData.gxTpr_Resumo.gxTpr_Conveniocategoriaid;
         AssignAttri(sPrefix, false, "AV38ConvenioCategoriaId", StringUtil.LTrimStr( (decimal)(AV38ConvenioCategoriaId), 9, 0));
         AV39ConvenioVencimentoAno = AV11WizardData.gxTpr_Resumo.gxTpr_Conveniovencimentoano;
         AssignAttri(sPrefix, false, "AV39ConvenioVencimentoAno", StringUtil.LTrimStr( (decimal)(AV39ConvenioVencimentoAno), 4, 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCONVENIOVENCIMENTOANO", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV39ConvenioVencimentoAno), "ZZZ9"), context));
         AV40ConvenioVencimentoMes = AV11WizardData.gxTpr_Resumo.gxTpr_Conveniovencimentomes;
         AssignAttri(sPrefix, false, "AV40ConvenioVencimentoMes", StringUtil.LTrimStr( (decimal)(AV40ConvenioVencimentoMes), 4, 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCONVENIOVENCIMENTOMES", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV40ConvenioVencimentoMes), "ZZZ9"), context));
         AV41ClientePixTipo = AV11WizardData.gxTpr_Resumo.gxTpr_Clientepixtipo;
         AssignAttri(sPrefix, false, "AV41ClientePixTipo", AV41ClientePixTipo);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCLIENTEPIXTIPO", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV41ClientePixTipo, "")), context));
         AV42ClientePix = AV11WizardData.gxTpr_Resumo.gxTpr_Clientepix;
         AssignAttri(sPrefix, false, "AV42ClientePix", AV42ClientePix);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCLIENTEPIX", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV42ClientePix, "")), context));
         AV43BancoId = AV11WizardData.gxTpr_Resumo.gxTpr_Bancoid;
         AssignAttri(sPrefix, false, "AV43BancoId", StringUtil.LTrimStr( (decimal)(AV43BancoId), 9, 0));
         AV44ContaAgencia = AV11WizardData.gxTpr_Resumo.gxTpr_Contaagencia;
         AssignAttri(sPrefix, false, "AV44ContaAgencia", AV44ContaAgencia);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCONTAAGENCIA", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV44ContaAgencia, "")), context));
         AV45ContaNumero = AV11WizardData.gxTpr_Resumo.gxTpr_Contanumero;
         AssignAttri(sPrefix, false, "AV45ContaNumero", AV45ContaNumero);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCONTANUMERO", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV45ContaNumero, "")), context));
         AV46ResponsavelClienteRazaoSocial = AV11WizardData.gxTpr_Resumo.gxTpr_Responsavelclienterazaosocial;
         AssignAttri(sPrefix, false, "AV46ResponsavelClienteRazaoSocial", AV46ResponsavelClienteRazaoSocial);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESPONSAVELCLIENTERAZAOSOCIAL", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV46ResponsavelClienteRazaoSocial, "@!")), context));
         AV47ResponsavelClienteDocumento = AV11WizardData.gxTpr_Resumo.gxTpr_Responsavelclientedocumento;
         AssignAttri(sPrefix, false, "AV47ResponsavelClienteDocumento", AV47ResponsavelClienteDocumento);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESPONSAVELCLIENTEDOCUMENTO", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV47ResponsavelClienteDocumento, "")), context));
         AV48ResponsavelContatoEmail = AV11WizardData.gxTpr_Resumo.gxTpr_Responsavelcontatoemail;
         AssignAttri(sPrefix, false, "AV48ResponsavelContatoEmail", AV48ResponsavelContatoEmail);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESPONSAVELCONTATOEMAIL", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV48ResponsavelContatoEmail, "")), context));
         AV49ClienteRazaoSocial = AV11WizardData.gxTpr_Resumo.gxTpr_Clienterazaosocial;
         AssignAttri(sPrefix, false, "AV49ClienteRazaoSocial", AV49ClienteRazaoSocial);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCLIENTERAZAOSOCIAL", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV49ClienteRazaoSocial, "@!")), context));
         AV50ClienteDocumento = AV11WizardData.gxTpr_Resumo.gxTpr_Clientedocumento;
         AssignAttri(sPrefix, false, "AV50ClienteDocumento", AV50ClienteDocumento);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCLIENTEDOCUMENTO", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV50ClienteDocumento, "")), context));
         AV51ContatoEmail = AV11WizardData.gxTpr_Resumo.gxTpr_Contatoemail;
         AssignAttri(sPrefix, false, "AV51ContatoEmail", AV51ContatoEmail);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCONTATOEMAIL", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV51ContatoEmail, "")), context));
         AV34ProcedimentosMedicosId = AV11WizardData.gxTpr_Proposta.gxTpr_Procedimentosmedicosid;
         AssignAttri(sPrefix, false, "AV34ProcedimentosMedicosId", StringUtil.LTrimStr( (decimal)(AV34ProcedimentosMedicosId), 9, 0));
         AV35PropostaValor = AV11WizardData.gxTpr_Proposta.gxTpr_Propostavalor;
         AssignAttri(sPrefix, false, "AV35PropostaValor", StringUtil.LTrimStr( AV35PropostaValor, 18, 2));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPROPOSTAVALOR", GetSecureSignedToken( sPrefix, context.localUtil.Format( AV35PropostaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"), context));
         AV36PropostaDescricao = AV11WizardData.gxTpr_Proposta.gxTpr_Propostadescricao;
         AssignAttri(sPrefix, false, "AV36PropostaDescricao", AV36PropostaDescricao);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPROPOSTADESCRICAO", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV36PropostaDescricao, "")), context));
         AV37ConvenioId = AV11WizardData.gxTpr_Proposta.gxTpr_Convenioid;
         AssignAttri(sPrefix, false, "AV37ConvenioId", StringUtil.LTrimStr( (decimal)(AV37ConvenioId), 9, 0));
         AV38ConvenioCategoriaId = AV11WizardData.gxTpr_Proposta.gxTpr_Conveniocategoriaid;
         AssignAttri(sPrefix, false, "AV38ConvenioCategoriaId", StringUtil.LTrimStr( (decimal)(AV38ConvenioCategoriaId), 9, 0));
         AV39ConvenioVencimentoAno = AV11WizardData.gxTpr_Proposta.gxTpr_Conveniovencimentoano;
         AssignAttri(sPrefix, false, "AV39ConvenioVencimentoAno", StringUtil.LTrimStr( (decimal)(AV39ConvenioVencimentoAno), 4, 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCONVENIOVENCIMENTOANO", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV39ConvenioVencimentoAno), "ZZZ9"), context));
         AV40ConvenioVencimentoMes = AV11WizardData.gxTpr_Proposta.gxTpr_Conveniovencimentomes;
         AssignAttri(sPrefix, false, "AV40ConvenioVencimentoMes", StringUtil.LTrimStr( (decimal)(AV40ConvenioVencimentoMes), 4, 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCONVENIOVENCIMENTOMES", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV40ConvenioVencimentoMes), "ZZZ9"), context));
         AV41ClientePixTipo = AV11WizardData.gxTpr_Conta.gxTpr_Clientepixtipo;
         AssignAttri(sPrefix, false, "AV41ClientePixTipo", AV41ClientePixTipo);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCLIENTEPIXTIPO", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV41ClientePixTipo, "")), context));
         AV42ClientePix = AV11WizardData.gxTpr_Conta.gxTpr_Clientepix;
         AssignAttri(sPrefix, false, "AV42ClientePix", AV42ClientePix);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCLIENTEPIX", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV42ClientePix, "")), context));
         AV43BancoId = AV11WizardData.gxTpr_Conta.gxTpr_Bancoid;
         AssignAttri(sPrefix, false, "AV43BancoId", StringUtil.LTrimStr( (decimal)(AV43BancoId), 9, 0));
         AV44ContaAgencia = AV11WizardData.gxTpr_Conta.gxTpr_Contaagencia;
         AssignAttri(sPrefix, false, "AV44ContaAgencia", AV44ContaAgencia);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCONTAAGENCIA", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV44ContaAgencia, "")), context));
         AV45ContaNumero = AV11WizardData.gxTpr_Conta.gxTpr_Contanumero;
         AssignAttri(sPrefix, false, "AV45ContaNumero", AV45ContaNumero);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCONTANUMERO", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV45ContaNumero, "")), context));
         AV46ResponsavelClienteRazaoSocial = AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelclienterazaosocial;
         AssignAttri(sPrefix, false, "AV46ResponsavelClienteRazaoSocial", AV46ResponsavelClienteRazaoSocial);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESPONSAVELCLIENTERAZAOSOCIAL", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV46ResponsavelClienteRazaoSocial, "@!")), context));
         AV47ResponsavelClienteDocumento = AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelclientedocumento;
         AssignAttri(sPrefix, false, "AV47ResponsavelClienteDocumento", AV47ResponsavelClienteDocumento);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESPONSAVELCLIENTEDOCUMENTO", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV47ResponsavelClienteDocumento, "")), context));
         AV48ResponsavelContatoEmail = AV11WizardData.gxTpr_Responsavel.gxTpr_Responsavelcontatoemail;
         AssignAttri(sPrefix, false, "AV48ResponsavelContatoEmail", AV48ResponsavelContatoEmail);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESPONSAVELCONTATOEMAIL", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV48ResponsavelContatoEmail, "")), context));
         AV49ClienteRazaoSocial = AV11WizardData.gxTpr_Novocliente.gxTpr_Clienterazaosocial;
         AssignAttri(sPrefix, false, "AV49ClienteRazaoSocial", AV49ClienteRazaoSocial);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCLIENTERAZAOSOCIAL", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV49ClienteRazaoSocial, "@!")), context));
         AV50ClienteDocumento = AV11WizardData.gxTpr_Novocliente.gxTpr_Clientedocumento;
         AssignAttri(sPrefix, false, "AV50ClienteDocumento", AV50ClienteDocumento);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCLIENTEDOCUMENTO", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV50ClienteDocumento, "")), context));
         AV51ContatoEmail = AV11WizardData.gxTpr_Novocliente.gxTpr_Contatoemail;
         AssignAttri(sPrefix, false, "AV51ContatoEmail", AV51ContatoEmail);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCONTATOEMAIL", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV51ContatoEmail, "")), context));
         if ( AV11WizardData.gxTpr_Novocliente.gxTpr_Possuiresponsavel )
         {
            divTablecontentresponsavel_Visible = 1;
            AssignProp(sPrefix, false, divTablecontentresponsavel_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablecontentresponsavel_Visible), 5, 0), true);
         }
         else
         {
            divTablecontentresponsavel_Visible = 0;
            AssignProp(sPrefix, false, divTablecontentresponsavel_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablecontentresponsavel_Visible), 5, 0), true);
         }
         if ( StringUtil.StrCmp(AV11WizardData.gxTpr_Conta.gxTpr_Clientedepositotipo, "Conta") == 0 )
         {
            divTablebanco_Visible = 1;
            AssignProp(sPrefix, false, divTablebanco_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablebanco_Visible), 5, 0), true);
            divTablepix_Visible = 0;
            AssignProp(sPrefix, false, divTablepix_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablepix_Visible), 5, 0), true);
         }
         else
         {
            divTablebanco_Visible = 0;
            AssignProp(sPrefix, false, divTablebanco_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablebanco_Visible), 5, 0), true);
            divTablepix_Visible = 1;
            AssignProp(sPrefix, false, divTablepix_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablepix_Visible), 5, 0), true);
         }
      }

      protected void S162( )
      {
         /* 'SAVEVARIABLESTOWIZARDDATA' Routine */
         returnInSub = false;
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
         AV11WizardData.gxTpr_Resumo.gxTpr_Procedimentosmedicosid = AV34ProcedimentosMedicosId;
         AV11WizardData.gxTpr_Resumo.gxTpr_Propostavalor = AV35PropostaValor;
         AV11WizardData.gxTpr_Resumo.gxTpr_Propostadescricao = AV36PropostaDescricao;
         AV11WizardData.gxTpr_Resumo.gxTpr_Convenioid = AV37ConvenioId;
         AV11WizardData.gxTpr_Resumo.gxTpr_Conveniocategoriaid = AV38ConvenioCategoriaId;
         AV11WizardData.gxTpr_Resumo.gxTpr_Conveniovencimentoano = AV39ConvenioVencimentoAno;
         AV11WizardData.gxTpr_Resumo.gxTpr_Conveniovencimentomes = AV40ConvenioVencimentoMes;
         AV11WizardData.gxTpr_Resumo.gxTpr_Clientepixtipo = AV41ClientePixTipo;
         AV11WizardData.gxTpr_Resumo.gxTpr_Clientepix = AV42ClientePix;
         AV11WizardData.gxTpr_Resumo.gxTpr_Bancoid = AV43BancoId;
         AV11WizardData.gxTpr_Resumo.gxTpr_Contaagencia = AV44ContaAgencia;
         AV11WizardData.gxTpr_Resumo.gxTpr_Contanumero = AV45ContaNumero;
         AV11WizardData.gxTpr_Resumo.gxTpr_Responsavelclienterazaosocial = AV46ResponsavelClienteRazaoSocial;
         AV11WizardData.gxTpr_Resumo.gxTpr_Responsavelclientedocumento = AV47ResponsavelClienteDocumento;
         AV11WizardData.gxTpr_Resumo.gxTpr_Responsavelcontatoemail = AV48ResponsavelContatoEmail;
         AV11WizardData.gxTpr_Resumo.gxTpr_Clienterazaosocial = AV49ClienteRazaoSocial;
         AV11WizardData.gxTpr_Resumo.gxTpr_Clientedocumento = AV50ClienteDocumento;
         AV11WizardData.gxTpr_Resumo.gxTpr_Contatoemail = AV51ContatoEmail;
         AV11WizardData.gxTpr_Resumo.gxTpr_Griddocc.Clear();
         /* Start For Each Line in Griddocc */
         nRC_GXsfl_138 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_138"), ",", "."), 18, MidpointRounding.ToEven));
         nGXsfl_138_fel_idx = 0;
         while ( nGXsfl_138_fel_idx < nRC_GXsfl_138 )
         {
            nGXsfl_138_fel_idx = ((subGriddocc_Islastpage==1)&&(nGXsfl_138_fel_idx+1>subGriddocc_fnc_Recordsperpage( )) ? 1 : nGXsfl_138_fel_idx+1);
            sGXsfl_138_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_138_fel_idx), 4, 0), 4, "0");
            SubsflControlProps_fel_1382( ) ;
            AV32AdicionarAnexo = cgiGet( edtavAdicionaranexo_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavResumodocumentosid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavResumodocumentosid_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vRESUMODOCUMENTOSID");
               GX_FocusControl = edtavResumodocumentosid_Internalname;
               wbErr = true;
               AV27ResumoDocumentosId = 0;
            }
            else
            {
               AV27ResumoDocumentosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavResumodocumentosid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            }
            AV28ResumoDocumentosDescricao = cgiGet( edtavResumodocumentosdescricao_Internalname);
            cmbavResumodocumentoobrigatorio.Name = cmbavResumodocumentoobrigatorio_Internalname;
            cmbavResumodocumentoobrigatorio.CurrentValue = cgiGet( cmbavResumodocumentoobrigatorio_Internalname);
            AV29ResumoDocumentoObrigatorio = StringUtil.StrToBool( cgiGet( cmbavResumodocumentoobrigatorio_Internalname));
            AV30ResumoDocumento = cgiGet( edtavResumodocumento_Internalname);
            AV31ResumoExtensao = cgiGet( edtavResumoextensao_Internalname);
            AV71Nome = cgiGet( edtavNome_Internalname);
            AV72NomeArquivo = cgiGet( edtavNomearquivo_Internalname);
            AV73GridDoccItem = new SdtWpNovaPropostaData_Resumo_GridDoccItem(context);
            AV73GridDoccItem.gxTpr_Resumodocumentosid = AV27ResumoDocumentosId;
            AV73GridDoccItem.gxTpr_Resumodocumentosdescricao = AV28ResumoDocumentosDescricao;
            AV73GridDoccItem.gxTpr_Resumodocumentoobrigatorio = AV29ResumoDocumentoObrigatorio;
            AV73GridDoccItem.gxTpr_Resumodocumento = AV30ResumoDocumento;
            AV73GridDoccItem.gxTpr_Resumoextensao = AV31ResumoExtensao;
            AV73GridDoccItem.gxTpr_Nome = AV71Nome;
            AV73GridDoccItem.gxTpr_Nomearquivo = AV72NomeArquivo;
            AV11WizardData.gxTpr_Resumo.gxTpr_Griddocc.Add(AV73GridDoccItem, 0);
            /* End For Each Line */
         }
         if ( nGXsfl_138_fel_idx == 0 )
         {
            nGXsfl_138_idx = 1;
            sGXsfl_138_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_138_idx), 4, 0), 4, "0");
            SubsflControlProps_1382( ) ;
         }
         nGXsfl_138_fel_idx = 1;
         AV5WebSession.Set(AV6WebSessionKey, AV11WizardData.ToJSonString(false, true));
      }

      protected void S152( )
      {
         /* 'LOADCOMBOCONVENIOCATEGORIAID' Routine */
         returnInSub = false;
         /* Using cursor H006Q3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A495ConvenioCategoriaStatus = H006Q3_A495ConvenioCategoriaStatus[0];
            n495ConvenioCategoriaStatus = H006Q3_n495ConvenioCategoriaStatus[0];
            A493ConvenioCategoriaId = H006Q3_A493ConvenioCategoriaId[0];
            A494ConvenioCategoriaDescricao = H006Q3_A494ConvenioCategoriaDescricao[0];
            n494ConvenioCategoriaDescricao = H006Q3_n494ConvenioCategoriaDescricao[0];
            AV26Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV26Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A493ConvenioCategoriaId), 9, 0));
            AV26Combo_DataItem.gxTpr_Title = A494ConvenioCategoriaDescricao;
            AV54ConvenioCategoriaId_Data.Add(AV26Combo_DataItem, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         Combo_conveniocategoriaid_Selectedvalue_set = ((0==AV38ConvenioCategoriaId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV38ConvenioCategoriaId), 9, 0)));
         ucCombo_conveniocategoriaid.SendProperty(context, sPrefix, false, Combo_conveniocategoriaid_Internalname, "SelectedValue_set", Combo_conveniocategoriaid_Selectedvalue_set);
      }

      protected void S142( )
      {
         /* 'LOADCOMBOCONVENIOID' Routine */
         returnInSub = false;
         /* Using cursor H006Q4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A412ConvenioStatus = H006Q4_A412ConvenioStatus[0];
            A410ConvenioId = H006Q4_A410ConvenioId[0];
            A411ConvenioDescricao = H006Q4_A411ConvenioDescricao[0];
            n411ConvenioDescricao = H006Q4_n411ConvenioDescricao[0];
            AV26Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV26Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A410ConvenioId), 9, 0));
            AV26Combo_DataItem.gxTpr_Title = A411ConvenioDescricao;
            AV53ConvenioId_Data.Add(AV26Combo_DataItem, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         Combo_convenioid_Selectedvalue_set = ((0==AV37ConvenioId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV37ConvenioId), 9, 0)));
         ucCombo_convenioid.SendProperty(context, sPrefix, false, Combo_convenioid_Internalname, "SelectedValue_set", Combo_convenioid_Selectedvalue_set);
      }

      protected void S132( )
      {
         /* 'LOADCOMBOPROCEDIMENTOSMEDICOSID' Routine */
         returnInSub = false;
         /* Using cursor H006Q5 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            A376ProcedimentosMedicosId = H006Q5_A376ProcedimentosMedicosId[0];
            A379ProcedimentosMedicosArea = H006Q5_A379ProcedimentosMedicosArea[0];
            n379ProcedimentosMedicosArea = H006Q5_n379ProcedimentosMedicosArea[0];
            A377ProcedimentosMedicosNome = H006Q5_A377ProcedimentosMedicosNome[0];
            n377ProcedimentosMedicosNome = H006Q5_n377ProcedimentosMedicosNome[0];
            AV26Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV26Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A376ProcedimentosMedicosId), 9, 0));
            AV23ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV23ComboTitles.Add(A377ProcedimentosMedicosNome, 0);
            AV23ComboTitles.Add(A379ProcedimentosMedicosArea, 0);
            AV26Combo_DataItem.gxTpr_Title = AV23ComboTitles.ToJSonString(false);
            AV52ProcedimentosMedicosId_Data.Add(AV26Combo_DataItem, 0);
            pr_default.readNext(3);
         }
         pr_default.close(3);
         Combo_procedimentosmedicosid_Selectedvalue_set = ((0==AV34ProcedimentosMedicosId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV34ProcedimentosMedicosId), 9, 0)));
         ucCombo_procedimentosmedicosid.SendProperty(context, sPrefix, false, Combo_procedimentosmedicosid_Internalname, "SelectedValue_set", Combo_procedimentosmedicosid_Selectedvalue_set);
      }

      protected void S122( )
      {
         /* 'LOADCOMBOBANCOID' Routine */
         returnInSub = false;
         /* Using cursor H006Q6 */
         pr_default.execute(4);
         while ( (pr_default.getStatus(4) != 101) )
         {
            A402BancoId = H006Q6_A402BancoId[0];
            A404BancoCodigo = H006Q6_A404BancoCodigo[0];
            n404BancoCodigo = H006Q6_n404BancoCodigo[0];
            A403BancoNome = H006Q6_A403BancoNome[0];
            n403BancoNome = H006Q6_n403BancoNome[0];
            AV26Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV26Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A402BancoId), 9, 0));
            AV23ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV23ComboTitles.Add(A403BancoNome, 0);
            AV23ComboTitles.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(A404BancoCodigo), "ZZZZZZZZ9")), 0);
            AV26Combo_DataItem.gxTpr_Title = AV23ComboTitles.ToJSonString(false);
            AV55BancoId_Data.Add(AV26Combo_DataItem, 0);
            pr_default.readNext(4);
         }
         pr_default.close(4);
         Combo_bancoid_Selectedvalue_set = ((0==AV43BancoId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV43BancoId), 9, 0)));
         ucCombo_bancoid.SendProperty(context, sPrefix, false, Combo_bancoid_Internalname, "SelectedValue_set", Combo_bancoid_Selectedvalue_set);
      }

      protected void E156Q2( )
      {
         /* Adicionaranexo_Click Routine */
         returnInSub = false;
         new prdownloadblob(context ).execute(  AV30ResumoDocumento,  AV72NomeArquivo,  AV31ResumoExtensao, out  AV76Arquivo) ;
         Novajanela_Target = AV76Arquivo;
         ucNovajanela.SendProperty(context, sPrefix, false, Novajanela_Internalname, "Target", Novajanela_Target);
         this.executeUsercontrolMethod(sPrefix, false, "NOVAJANELAContainer", "OpenWindow", "", new Object[] {});
         /*  Sending Event outputs  */
      }

      protected void wb_table1_124_6Q2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'" + sPrefix + "',false,'" + sGXsfl_138_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavConveniovencimentoano, cmbavConveniovencimentoano_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV39ConvenioVencimentoAno), 4, 0)), 1, cmbavConveniovencimentoano_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavConveniovencimentoano.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,128);\"", "", true, 0, "HLP_WpNovaPropostaResumo.htm");
            cmbavConveniovencimentoano.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV39ConvenioVencimentoAno), 4, 0));
            AssignProp(sPrefix, false, cmbavConveniovencimentoano_Internalname, "Values", (string)(cmbavConveniovencimentoano.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='DataContentCellFL'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+cmbavConveniovencimentomes_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavConveniovencimentomes_Internalname, "Mês vencimento carteira", "gx-form-item AttributeFLLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 132,'" + sPrefix + "',false,'" + sGXsfl_138_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavConveniovencimentomes, cmbavConveniovencimentomes_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV40ConvenioVencimentoMes), 4, 0)), 1, cmbavConveniovencimentomes_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavConveniovencimentomes.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,132);\"", "", true, 0, "HLP_WpNovaPropostaResumo.htm");
            cmbavConveniovencimentomes.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV40ConvenioVencimentoMes), 4, 0));
            AssignProp(sPrefix, false, cmbavConveniovencimentomes_Internalname, "Values", (string)(cmbavConveniovencimentomes.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_124_6Q2e( true) ;
         }
         else
         {
            wb_table1_124_6Q2e( false) ;
         }
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
         PA6Q2( ) ;
         WS6Q2( ) ;
         WE6Q2( ) ;
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
         PA6Q2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wpnovapropostaresumo", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA6Q2( ) ;
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
         PA6Q2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS6Q2( ) ;
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
         WS6Q2( ) ;
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
         WE6Q2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019173745", true, true);
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
         context.AddJavascriptSource("wpnovapropostaresumo.js", "?202561019173746", false, true);
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
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1382( )
      {
         edtavAdicionaranexo_Internalname = sPrefix+"vADICIONARANEXO_"+sGXsfl_138_idx;
         edtavResumodocumentosid_Internalname = sPrefix+"vRESUMODOCUMENTOSID_"+sGXsfl_138_idx;
         edtavResumodocumentosdescricao_Internalname = sPrefix+"vRESUMODOCUMENTOSDESCRICAO_"+sGXsfl_138_idx;
         cmbavResumodocumentoobrigatorio_Internalname = sPrefix+"vRESUMODOCUMENTOOBRIGATORIO_"+sGXsfl_138_idx;
         edtavResumodocumento_Internalname = sPrefix+"vRESUMODOCUMENTO_"+sGXsfl_138_idx;
         edtavResumoextensao_Internalname = sPrefix+"vRESUMOEXTENSAO_"+sGXsfl_138_idx;
         edtavNome_Internalname = sPrefix+"vNOME_"+sGXsfl_138_idx;
         edtavNomearquivo_Internalname = sPrefix+"vNOMEARQUIVO_"+sGXsfl_138_idx;
      }

      protected void SubsflControlProps_fel_1382( )
      {
         edtavAdicionaranexo_Internalname = sPrefix+"vADICIONARANEXO_"+sGXsfl_138_fel_idx;
         edtavResumodocumentosid_Internalname = sPrefix+"vRESUMODOCUMENTOSID_"+sGXsfl_138_fel_idx;
         edtavResumodocumentosdescricao_Internalname = sPrefix+"vRESUMODOCUMENTOSDESCRICAO_"+sGXsfl_138_fel_idx;
         cmbavResumodocumentoobrigatorio_Internalname = sPrefix+"vRESUMODOCUMENTOOBRIGATORIO_"+sGXsfl_138_fel_idx;
         edtavResumodocumento_Internalname = sPrefix+"vRESUMODOCUMENTO_"+sGXsfl_138_fel_idx;
         edtavResumoextensao_Internalname = sPrefix+"vRESUMOEXTENSAO_"+sGXsfl_138_fel_idx;
         edtavNome_Internalname = sPrefix+"vNOME_"+sGXsfl_138_fel_idx;
         edtavNomearquivo_Internalname = sPrefix+"vNOMEARQUIVO_"+sGXsfl_138_fel_idx;
      }

      protected void sendrow_1382( )
      {
         sGXsfl_138_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_138_idx), 4, 0), 4, "0");
         SubsflControlProps_1382( ) ;
         WB6Q0( ) ;
         if ( ( subGriddocc_Rows * 1 == 0 ) || ( nGXsfl_138_idx <= subGriddocc_fnc_Recordsperpage( ) * 1 ) )
         {
            GriddoccRow = GXWebRow.GetNew(context,GriddoccContainer);
            if ( subGriddocc_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGriddocc_Backstyle = 0;
               if ( StringUtil.StrCmp(subGriddocc_Class, "") != 0 )
               {
                  subGriddocc_Linesclass = subGriddocc_Class+"Odd";
               }
            }
            else if ( subGriddocc_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGriddocc_Backstyle = 0;
               subGriddocc_Backcolor = subGriddocc_Allbackcolor;
               if ( StringUtil.StrCmp(subGriddocc_Class, "") != 0 )
               {
                  subGriddocc_Linesclass = subGriddocc_Class+"Uniform";
               }
            }
            else if ( subGriddocc_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGriddocc_Backstyle = 1;
               if ( StringUtil.StrCmp(subGriddocc_Class, "") != 0 )
               {
                  subGriddocc_Linesclass = subGriddocc_Class+"Odd";
               }
               subGriddocc_Backcolor = (int)(0x0);
            }
            else if ( subGriddocc_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGriddocc_Backstyle = 1;
               if ( ((int)((nGXsfl_138_idx) % (2))) == 0 )
               {
                  subGriddocc_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGriddocc_Class, "") != 0 )
                  {
                     subGriddocc_Linesclass = subGriddocc_Class+"Even";
                  }
               }
               else
               {
                  subGriddocc_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGriddocc_Class, "") != 0 )
                  {
                     subGriddocc_Linesclass = subGriddocc_Class+"Odd";
                  }
               }
            }
            if ( GriddoccContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"GridWithBorderColor WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_138_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GriddoccContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 139,'" + sPrefix + "',false,'" + sGXsfl_138_idx + "',138)\"";
            ROClassString = "Attribute";
            GriddoccRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavAdicionaranexo_Internalname,StringUtil.RTrim( AV32AdicionarAnexo),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,139);\"","'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVADICIONARANEXO.CLICK."+sGXsfl_138_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavAdicionaranexo_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavAdicionaranexo_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)138,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GriddoccContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GriddoccRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavResumodocumentosid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27ResumoDocumentosId), 9, 0, ",", "")),StringUtil.LTrim( ((edtavResumodocumentosid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV27ResumoDocumentosId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV27ResumoDocumentosId), "ZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+""+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavResumodocumentosid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavResumodocumentosid_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)138,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GriddoccContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 141,'" + sPrefix + "',false,'" + sGXsfl_138_idx + "',138)\"";
            ROClassString = "Attribute";
            GriddoccRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavResumodocumentosdescricao_Internalname,(string)AV28ResumoDocumentosDescricao,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,141);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavResumodocumentosdescricao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavResumodocumentosdescricao_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)138,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GriddoccContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( cmbavResumodocumentoobrigatorio.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vRESUMODOCUMENTOOBRIGATORIO_" + sGXsfl_138_idx;
               cmbavResumodocumentoobrigatorio.Name = GXCCtl;
               cmbavResumodocumentoobrigatorio.WebTags = "";
               cmbavResumodocumentoobrigatorio.addItem(StringUtil.BoolToStr( true), "Sim", 0);
               cmbavResumodocumentoobrigatorio.addItem(StringUtil.BoolToStr( false), "Não", 0);
               if ( cmbavResumodocumentoobrigatorio.ItemCount > 0 )
               {
                  AV29ResumoDocumentoObrigatorio = StringUtil.StrToBool( cmbavResumodocumentoobrigatorio.getValidValue(StringUtil.BoolToStr( AV29ResumoDocumentoObrigatorio)));
                  AssignAttri(sPrefix, false, cmbavResumodocumentoobrigatorio_Internalname, AV29ResumoDocumentoObrigatorio);
                  GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESUMODOCUMENTOOBRIGATORIO"+"_"+sGXsfl_138_idx, GetSecureSignedToken( sPrefix+sGXsfl_138_idx, AV29ResumoDocumentoObrigatorio, context));
               }
            }
            /* ComboBox */
            GriddoccRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavResumodocumentoobrigatorio,(string)cmbavResumodocumentoobrigatorio_Internalname,StringUtil.BoolToStr( AV29ResumoDocumentoObrigatorio),(short)1,(string)cmbavResumodocumentoobrigatorio_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"boolean",(string)"",(short)0,cmbavResumodocumentoobrigatorio.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"",(bool)true,(short)0});
            cmbavResumodocumentoobrigatorio.CurrentValue = StringUtil.BoolToStr( AV29ResumoDocumentoObrigatorio);
            AssignProp(sPrefix, false, cmbavResumodocumentoobrigatorio_Internalname, "Values", (string)(cmbavResumodocumentoobrigatorio.ToJavascriptSource()), !bGXsfl_138_Refreshing);
            /* Subfile cell */
            if ( GriddoccContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            ClassString = "Attribute";
            StyleString = "";
            edtavResumodocumento_Filetype = "tmp";
            AssignProp(sPrefix, false, edtavResumodocumento_Internalname, "Filetype", edtavResumodocumento_Filetype, !bGXsfl_138_Refreshing);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30ResumoDocumento)) )
            {
               gxblobfileaux.Source = AV30ResumoDocumento;
               if ( ! gxblobfileaux.HasExtension() || ( StringUtil.StrCmp(edtavResumodocumento_Filetype, "tmp") != 0 ) )
               {
                  gxblobfileaux.SetExtension(StringUtil.Trim( edtavResumodocumento_Filetype));
               }
               if ( gxblobfileaux.ErrCode == 0 )
               {
                  AV30ResumoDocumento = gxblobfileaux.GetURI();
                  AssignProp(sPrefix, false, edtavResumodocumento_Internalname, "URL", context.PathToRelativeUrl( AV30ResumoDocumento), !bGXsfl_138_Refreshing);
                  edtavResumodocumento_Filetype = gxblobfileaux.GetExtension();
                  AssignProp(sPrefix, false, edtavResumodocumento_Internalname, "Filetype", edtavResumodocumento_Filetype, !bGXsfl_138_Refreshing);
               }
               AssignProp(sPrefix, false, edtavResumodocumento_Internalname, "URL", context.PathToRelativeUrl( AV30ResumoDocumento), !bGXsfl_138_Refreshing);
            }
            GriddoccRow.AddColumnProperties("blob", 2, isAjaxCallMode( ), new Object[] {(string)edtavResumodocumento_Internalname,StringUtil.RTrim( AV30ResumoDocumento),context.PathToRelativeUrl( AV30ResumoDocumento),(String.IsNullOrEmpty(StringUtil.RTrim( edtavResumodocumento_Contenttype)) ? context.GetContentType( (String.IsNullOrEmpty(StringUtil.RTrim( edtavResumodocumento_Filetype)) ? AV30ResumoDocumento : edtavResumodocumento_Filetype)) : edtavResumodocumento_Contenttype),(bool)false,(string)"",(string)edtavResumodocumento_Parameters,(short)0,(int)edtavResumodocumento_Enabled,(short)0,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)60,(string)"px",(short)0,(short)0,(short)0,(string)edtavResumodocumento_Jsonclick,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",""+""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"",(string)""});
            /* Subfile cell */
            if ( GriddoccContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GriddoccRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavResumoextensao_Internalname,(string)AV31ResumoExtensao,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavResumoextensao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavResumoextensao_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)138,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GriddoccContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GriddoccRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavNome_Internalname,(string)AV71Nome,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavNome_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)138,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GriddoccContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 146,'" + sPrefix + "',false,'" + sGXsfl_138_idx + "',138)\"";
            ROClassString = "Attribute";
            GriddoccRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavNomearquivo_Internalname,(string)AV72NomeArquivo,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,146);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavNomearquivo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavNomearquivo_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)138,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes6Q2( ) ;
            GriddoccContainer.AddRow(GriddoccRow);
            nGXsfl_138_idx = ((subGriddocc_Islastpage==1)&&(nGXsfl_138_idx+1>subGriddocc_fnc_Recordsperpage( )) ? 1 : nGXsfl_138_idx+1);
            sGXsfl_138_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_138_idx), 4, 0), 4, "0");
            SubsflControlProps_1382( ) ;
         }
         /* End function sendrow_1382 */
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
         }
         GXCCtl = "vRESUMODOCUMENTOOBRIGATORIO_" + sGXsfl_138_idx;
         cmbavResumodocumentoobrigatorio.Name = GXCCtl;
         cmbavResumodocumentoobrigatorio.WebTags = "";
         cmbavResumodocumentoobrigatorio.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbavResumodocumentoobrigatorio.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbavResumodocumentoobrigatorio.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl138( )
      {
         if ( GriddoccContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GriddoccContainer"+"DivS\" data-gxgridid=\"138\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGriddocc_Internalname, subGriddocc_Internalname, "", "GridWithBorderColor WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGriddocc_Backcolorstyle == 0 )
            {
               subGriddocc_Titlebackstyle = 0;
               if ( StringUtil.Len( subGriddocc_Class) > 0 )
               {
                  subGriddocc_Linesclass = subGriddocc_Class+"Title";
               }
            }
            else
            {
               subGriddocc_Titlebackstyle = 1;
               if ( subGriddocc_Backcolorstyle == 1 )
               {
                  subGriddocc_Titlebackcolor = subGriddocc_Allbackcolor;
                  if ( StringUtil.Len( subGriddocc_Class) > 0 )
                  {
                     subGriddocc_Linesclass = subGriddocc_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGriddocc_Class) > 0 )
                  {
                     subGriddocc_Linesclass = subGriddocc_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GriddoccContainer.AddObjectProperty("GridName", "Griddocc");
         }
         else
         {
            GriddoccContainer.AddObjectProperty("GridName", "Griddocc");
            GriddoccContainer.AddObjectProperty("Header", subGriddocc_Header);
            GriddoccContainer.AddObjectProperty("Class", "GridWithBorderColor WorkWith");
            GriddoccContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GriddoccContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GriddoccContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddocc_Backcolorstyle), 1, 0, ".", "")));
            GriddoccContainer.AddObjectProperty("CmpContext", sPrefix);
            GriddoccContainer.AddObjectProperty("InMasterPage", "false");
            GriddoccColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GriddoccColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV32AdicionarAnexo)));
            GriddoccColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavAdicionaranexo_Enabled), 5, 0, ".", "")));
            GriddoccContainer.AddColumnProperties(GriddoccColumn);
            GriddoccColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GriddoccColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27ResumoDocumentosId), 9, 0, ".", ""))));
            GriddoccColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavResumodocumentosid_Enabled), 5, 0, ".", "")));
            GriddoccContainer.AddColumnProperties(GriddoccColumn);
            GriddoccColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GriddoccColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV28ResumoDocumentosDescricao));
            GriddoccColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavResumodocumentosdescricao_Enabled), 5, 0, ".", "")));
            GriddoccContainer.AddColumnProperties(GriddoccColumn);
            GriddoccColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GriddoccColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( AV29ResumoDocumentoObrigatorio)));
            GriddoccColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavResumodocumentoobrigatorio.Enabled), 5, 0, ".", "")));
            GriddoccContainer.AddColumnProperties(GriddoccColumn);
            GriddoccColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GriddoccColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV30ResumoDocumento));
            GriddoccColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavResumodocumento_Enabled), 5, 0, ".", "")));
            GriddoccContainer.AddColumnProperties(GriddoccColumn);
            GriddoccColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GriddoccColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV31ResumoExtensao));
            GriddoccColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavResumoextensao_Enabled), 5, 0, ".", "")));
            GriddoccContainer.AddColumnProperties(GriddoccColumn);
            GriddoccColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GriddoccColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV71Nome));
            GriddoccColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavNome_Enabled), 5, 0, ".", "")));
            GriddoccContainer.AddColumnProperties(GriddoccColumn);
            GriddoccColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GriddoccColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV72NomeArquivo));
            GriddoccColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavNomearquivo_Enabled), 5, 0, ".", "")));
            GriddoccContainer.AddColumnProperties(GriddoccColumn);
            GriddoccContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddocc_Selectedindex), 4, 0, ".", "")));
            GriddoccContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddocc_Allowselection), 1, 0, ".", "")));
            GriddoccContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddocc_Selectioncolor), 9, 0, ".", "")));
            GriddoccContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddocc_Allowhovering), 1, 0, ".", "")));
            GriddoccContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddocc_Hoveringcolor), 9, 0, ".", "")));
            GriddoccContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddocc_Allowcollapsing), 1, 0, ".", "")));
            GriddoccContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddocc_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         edtavClienterazaosocial_Internalname = sPrefix+"vCLIENTERAZAOSOCIAL";
         edtavClientedocumento_Internalname = sPrefix+"vCLIENTEDOCUMENTO";
         edtavContatoemail_Internalname = sPrefix+"vCONTATOEMAIL";
         divTablecliente_Internalname = sPrefix+"TABLECLIENTE";
         grpUnnamedgroup1_Internalname = sPrefix+"UNNAMEDGROUP1";
         edtavResponsavelclienterazaosocial_Internalname = sPrefix+"vRESPONSAVELCLIENTERAZAOSOCIAL";
         edtavResponsavelclientedocumento_Internalname = sPrefix+"vRESPONSAVELCLIENTEDOCUMENTO";
         edtavResponsavelcontatoemail_Internalname = sPrefix+"vRESPONSAVELCONTATOEMAIL";
         divTablerespnosavel_Internalname = sPrefix+"TABLERESPNOSAVEL";
         grpUnnamedgroup5_Internalname = sPrefix+"UNNAMEDGROUP5";
         divTablecontentresponsavel_Internalname = sPrefix+"TABLECONTENTRESPONSAVEL";
         lblTextblockcombo_bancoid_Internalname = sPrefix+"TEXTBLOCKCOMBO_BANCOID";
         Combo_bancoid_Internalname = sPrefix+"COMBO_BANCOID";
         divTablesplittedbancoid_Internalname = sPrefix+"TABLESPLITTEDBANCOID";
         edtavContaagencia_Internalname = sPrefix+"vCONTAAGENCIA";
         edtavContanumero_Internalname = sPrefix+"vCONTANUMERO";
         divTablebanco_Internalname = sPrefix+"TABLEBANCO";
         cmbavClientepixtipo_Internalname = sPrefix+"vCLIENTEPIXTIPO";
         edtavClientepix_Internalname = sPrefix+"vCLIENTEPIX";
         divTablepix_Internalname = sPrefix+"TABLEPIX";
         divTableconta_Internalname = sPrefix+"TABLECONTA";
         grpUnnamedgroup2_Internalname = sPrefix+"UNNAMEDGROUP2";
         lblTextblockcombo_procedimentosmedicosid_Internalname = sPrefix+"TEXTBLOCKCOMBO_PROCEDIMENTOSMEDICOSID";
         Combo_procedimentosmedicosid_Internalname = sPrefix+"COMBO_PROCEDIMENTOSMEDICOSID";
         divTablesplittedprocedimentosmedicosid_Internalname = sPrefix+"TABLESPLITTEDPROCEDIMENTOSMEDICOSID";
         edtavPropostavalor_Internalname = sPrefix+"vPROPOSTAVALOR";
         edtavPropostadescricao_Internalname = sPrefix+"vPROPOSTADESCRICAO";
         lblTextblockcombo_convenioid_Internalname = sPrefix+"TEXTBLOCKCOMBO_CONVENIOID";
         Combo_convenioid_Internalname = sPrefix+"COMBO_CONVENIOID";
         divTablesplittedconvenioid_Internalname = sPrefix+"TABLESPLITTEDCONVENIOID";
         lblTextblockcombo_conveniocategoriaid_Internalname = sPrefix+"TEXTBLOCKCOMBO_CONVENIOCATEGORIAID";
         Combo_conveniocategoriaid_Internalname = sPrefix+"COMBO_CONVENIOCATEGORIAID";
         divTablesplittedconveniocategoriaid_Internalname = sPrefix+"TABLESPLITTEDCONVENIOCATEGORIAID";
         lblTextblockconveniovencimentoano_Internalname = sPrefix+"TEXTBLOCKCONVENIOVENCIMENTOANO";
         cmbavConveniovencimentoano_Internalname = sPrefix+"vCONVENIOVENCIMENTOANO";
         cmbavConveniovencimentomes_Internalname = sPrefix+"vCONVENIOVENCIMENTOMES";
         tblTablemergedconveniovencimentoano_Internalname = sPrefix+"TABLEMERGEDCONVENIOVENCIMENTOANO";
         divTablesplittedconveniovencimentoano_Internalname = sPrefix+"TABLESPLITTEDCONVENIOVENCIMENTOANO";
         divTableproposta_Internalname = sPrefix+"TABLEPROPOSTA";
         grpUnnamedgroup3_Internalname = sPrefix+"UNNAMEDGROUP3";
         edtavAdicionaranexo_Internalname = sPrefix+"vADICIONARANEXO";
         edtavResumodocumentosid_Internalname = sPrefix+"vRESUMODOCUMENTOSID";
         edtavResumodocumentosdescricao_Internalname = sPrefix+"vRESUMODOCUMENTOSDESCRICAO";
         cmbavResumodocumentoobrigatorio_Internalname = sPrefix+"vRESUMODOCUMENTOOBRIGATORIO";
         edtavResumodocumento_Internalname = sPrefix+"vRESUMODOCUMENTO";
         edtavResumoextensao_Internalname = sPrefix+"vRESUMOEXTENSAO";
         edtavNome_Internalname = sPrefix+"vNOME";
         edtavNomearquivo_Internalname = sPrefix+"vNOMEARQUIVO";
         divTabledocumentos_Internalname = sPrefix+"TABLEDOCUMENTOS";
         grpUnnamedgroup4_Internalname = sPrefix+"UNNAMEDGROUP4";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         Btnwizardprevious_Internalname = sPrefix+"BTNWIZARDPREVIOUS";
         Btnwizardnext_Internalname = sPrefix+"BTNWIZARDNEXT";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         Novajanela_Internalname = sPrefix+"NOVAJANELA";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavBancoid_Internalname = sPrefix+"vBANCOID";
         edtavProcedimentosmedicosid_Internalname = sPrefix+"vPROCEDIMENTOSMEDICOSID";
         edtavConvenioid_Internalname = sPrefix+"vCONVENIOID";
         edtavConveniocategoriaid_Internalname = sPrefix+"vCONVENIOCATEGORIAID";
         Griddocc_empowerer_Internalname = sPrefix+"GRIDDOCC_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGriddocc_Internalname = sPrefix+"GRIDDOCC";
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
         subGriddocc_Allowcollapsing = 0;
         subGriddocc_Allowselection = 0;
         subGriddocc_Header = "";
         edtavNomearquivo_Jsonclick = "";
         edtavNomearquivo_Enabled = 1;
         edtavNome_Jsonclick = "";
         edtavNome_Enabled = 1;
         edtavResumoextensao_Jsonclick = "";
         edtavResumoextensao_Enabled = 1;
         edtavResumodocumento_Jsonclick = "";
         edtavResumodocumento_Parameters = "";
         edtavResumodocumento_Contenttype = "";
         edtavResumodocumento_Filetype = "";
         edtavResumodocumento_Enabled = 1;
         cmbavResumodocumentoobrigatorio_Jsonclick = "";
         cmbavResumodocumentoobrigatorio.Enabled = 1;
         edtavResumodocumentosdescricao_Jsonclick = "";
         edtavResumodocumentosdescricao_Enabled = 1;
         edtavResumodocumentosid_Jsonclick = "";
         edtavResumodocumentosid_Enabled = 1;
         edtavAdicionaranexo_Jsonclick = "";
         edtavAdicionaranexo_Enabled = 1;
         subGriddocc_Class = "GridWithBorderColor WorkWith";
         subGriddocc_Backcolorstyle = 0;
         cmbavConveniovencimentomes_Jsonclick = "";
         cmbavConveniovencimentomes.Enabled = 1;
         cmbavConveniovencimentoano_Jsonclick = "";
         cmbavConveniovencimentoano.Enabled = 1;
         Novajanela_Target = "";
         Combo_bancoid_Htmltemplate = "";
         Combo_procedimentosmedicosid_Htmltemplate = "";
         edtavConveniocategoriaid_Jsonclick = "";
         edtavConveniocategoriaid_Visible = 1;
         edtavConvenioid_Jsonclick = "";
         edtavConvenioid_Visible = 1;
         edtavProcedimentosmedicosid_Jsonclick = "";
         edtavProcedimentosmedicosid_Visible = 1;
         edtavBancoid_Jsonclick = "";
         edtavBancoid_Visible = 1;
         Btnwizardnext_Class = "Button ButtonWizard";
         Btnwizardnext_Caption = "Finalizar";
         Btnwizardnext_Aftericonclass = "fas fa-arrow-right";
         Btnwizardnext_Tooltiptext = "";
         Btnwizardprevious_Class = "BtnDefault ButtonWizard";
         Btnwizardprevious_Caption = "Anterior";
         Btnwizardprevious_Beforeiconclass = "fas fa-arrow-left";
         Btnwizardprevious_Tooltiptext = "";
         Combo_conveniocategoriaid_Emptyitem = Convert.ToBoolean( 0);
         Combo_conveniocategoriaid_Cls = "ExtendedCombo AttributeFL";
         Combo_conveniocategoriaid_Enabled = Convert.ToBoolean( -1);
         Combo_convenioid_Emptyitem = Convert.ToBoolean( 0);
         Combo_convenioid_Cls = "ExtendedCombo AttributeFL";
         Combo_convenioid_Enabled = Convert.ToBoolean( -1);
         edtavPropostadescricao_Jsonclick = "";
         edtavPropostadescricao_Enabled = 1;
         edtavPropostavalor_Jsonclick = "";
         edtavPropostavalor_Enabled = 1;
         Combo_procedimentosmedicosid_Emptyitem = Convert.ToBoolean( 0);
         Combo_procedimentosmedicosid_Cls = "ExtendedCombo AttributeFL ExtendedComboTitleAndSubtitle";
         Combo_procedimentosmedicosid_Enabled = Convert.ToBoolean( -1);
         edtavClientepix_Jsonclick = "";
         edtavClientepix_Enabled = 1;
         cmbavClientepixtipo_Jsonclick = "";
         cmbavClientepixtipo.Enabled = 1;
         divTablepix_Visible = 1;
         edtavContanumero_Jsonclick = "";
         edtavContanumero_Enabled = 1;
         edtavContaagencia_Jsonclick = "";
         edtavContaagencia_Enabled = 1;
         Combo_bancoid_Emptyitem = Convert.ToBoolean( 0);
         Combo_bancoid_Cls = "ExtendedCombo AttributeFL ExtendedComboTitleAndSubtitle";
         Combo_bancoid_Enabled = Convert.ToBoolean( -1);
         divTablebanco_Visible = 1;
         edtavResponsavelcontatoemail_Jsonclick = "";
         edtavResponsavelcontatoemail_Enabled = 1;
         edtavResponsavelclientedocumento_Jsonclick = "";
         edtavResponsavelclientedocumento_Enabled = 1;
         edtavResponsavelclienterazaosocial_Jsonclick = "";
         edtavResponsavelclienterazaosocial_Enabled = 1;
         divTablecontentresponsavel_Visible = 1;
         edtavContatoemail_Jsonclick = "";
         edtavContatoemail_Enabled = 1;
         edtavClientedocumento_Jsonclick = "";
         edtavClientedocumento_Enabled = 1;
         edtavClienterazaosocial_Jsonclick = "";
         edtavClienterazaosocial_Enabled = 1;
         subGriddocc_Rows = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRIDDOCC_nFirstRecordOnPage","type":"int"},{"av":"GRIDDOCC_nEOF","type":"int"},{"av":"subGriddocc_Rows","ctrl":"GRIDDOCC","prop":"Rows"},{"av":"AV11WizardData","fld":"vWIZARDDATA","type":""},{"av":"sPrefix","type":"char"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true,"type":"boolean"},{"av":"AV35PropostaValor","fld":"vPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","hsh":true,"type":"decimal"},{"av":"AV36PropostaDescricao","fld":"vPROPOSTADESCRICAO","hsh":true,"type":"svchar"},{"av":"cmbavConveniovencimentoano"},{"av":"AV39ConvenioVencimentoAno","fld":"vCONVENIOVENCIMENTOANO","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"cmbavConveniovencimentomes"},{"av":"AV40ConvenioVencimentoMes","fld":"vCONVENIOVENCIMENTOMES","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"cmbavClientepixtipo"},{"av":"AV41ClientePixTipo","fld":"vCLIENTEPIXTIPO","hsh":true,"type":"svchar"},{"av":"AV42ClientePix","fld":"vCLIENTEPIX","hsh":true,"type":"svchar"},{"av":"AV44ContaAgencia","fld":"vCONTAAGENCIA","hsh":true,"type":"svchar"},{"av":"AV45ContaNumero","fld":"vCONTANUMERO","hsh":true,"type":"svchar"},{"av":"AV46ResponsavelClienteRazaoSocial","fld":"vRESPONSAVELCLIENTERAZAOSOCIAL","pic":"@!","hsh":true,"type":"svchar"},{"av":"AV47ResponsavelClienteDocumento","fld":"vRESPONSAVELCLIENTEDOCUMENTO","hsh":true,"type":"svchar"},{"av":"AV48ResponsavelContatoEmail","fld":"vRESPONSAVELCONTATOEMAIL","hsh":true,"type":"svchar"},{"av":"AV49ClienteRazaoSocial","fld":"vCLIENTERAZAOSOCIAL","pic":"@!","hsh":true,"type":"svchar"},{"av":"AV50ClienteDocumento","fld":"vCLIENTEDOCUMENTO","hsh":true,"type":"svchar"},{"av":"AV51ContatoEmail","fld":"vCONTATOEMAIL","hsh":true,"type":"svchar"}]}""");
         setEventMetadata("GRIDDOCC.LOAD","""{"handler":"E146Q2","iparms":[{"av":"AV11WizardData","fld":"vWIZARDDATA","type":""}]""");
         setEventMetadata("GRIDDOCC.LOAD",""","oparms":[{"av":"AV30ResumoDocumento","fld":"vRESUMODOCUMENTO","type":"bitstr"},{"av":"AV28ResumoDocumentosDescricao","fld":"vRESUMODOCUMENTOSDESCRICAO","hsh":true,"type":"svchar"},{"av":"AV27ResumoDocumentosId","fld":"vRESUMODOCUMENTOSID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV31ResumoExtensao","fld":"vRESUMOEXTENSAO","hsh":true,"type":"svchar"},{"av":"AV72NomeArquivo","fld":"vNOMEARQUIVO","hsh":true,"type":"svchar"},{"av":"AV32AdicionarAnexo","fld":"vADICIONARANEXO","type":"char"}]}""");
         setEventMetadata("ENTER","""{"handler":"E116Q2","iparms":[{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true,"type":"boolean"},{"av":"A332LimiteAprovacaoValorMinimo","fld":"LIMITEAPROVACAOVALORMINIMO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV35PropostaValor","fld":"vPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","hsh":true,"type":"decimal"},{"av":"A334LimiteAprovacaoAprovacoes","fld":"LIMITEAPROVACAOAPROVACOES","pic":"ZZZ9","type":"int"},{"av":"AV34ProcedimentosMedicosId","fld":"vPROCEDIMENTOSMEDICOSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV36PropostaDescricao","fld":"vPROPOSTADESCRICAO","hsh":true,"type":"svchar"},{"av":"AV11WizardData","fld":"vWIZARDDATA","type":""},{"av":"AV68HTTPREQUEST.BaseURL","ctrl":"vHTTPREQUEST","prop":"Baseurl"},{"av":"AV6WebSessionKey","fld":"vWEBSESSIONKEY","type":"svchar"},{"av":"AV37ConvenioId","fld":"vCONVENIOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV38ConvenioCategoriaId","fld":"vCONVENIOCATEGORIAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"cmbavConveniovencimentoano"},{"av":"AV39ConvenioVencimentoAno","fld":"vCONVENIOVENCIMENTOANO","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"cmbavConveniovencimentomes"},{"av":"AV40ConvenioVencimentoMes","fld":"vCONVENIOVENCIMENTOMES","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"cmbavClientepixtipo"},{"av":"AV41ClientePixTipo","fld":"vCLIENTEPIXTIPO","hsh":true,"type":"svchar"},{"av":"AV42ClientePix","fld":"vCLIENTEPIX","hsh":true,"type":"svchar"},{"av":"AV43BancoId","fld":"vBANCOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV44ContaAgencia","fld":"vCONTAAGENCIA","hsh":true,"type":"svchar"},{"av":"AV45ContaNumero","fld":"vCONTANUMERO","hsh":true,"type":"svchar"},{"av":"AV46ResponsavelClienteRazaoSocial","fld":"vRESPONSAVELCLIENTERAZAOSOCIAL","pic":"@!","hsh":true,"type":"svchar"},{"av":"AV47ResponsavelClienteDocumento","fld":"vRESPONSAVELCLIENTEDOCUMENTO","hsh":true,"type":"svchar"},{"av":"AV48ResponsavelContatoEmail","fld":"vRESPONSAVELCONTATOEMAIL","hsh":true,"type":"svchar"},{"av":"AV49ClienteRazaoSocial","fld":"vCLIENTERAZAOSOCIAL","pic":"@!","hsh":true,"type":"svchar"},{"av":"AV50ClienteDocumento","fld":"vCLIENTEDOCUMENTO","hsh":true,"type":"svchar"},{"av":"AV51ContatoEmail","fld":"vCONTATOEMAIL","hsh":true,"type":"svchar"},{"av":"AV27ResumoDocumentosId","fld":"vRESUMODOCUMENTOSID","grid":138,"pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"GRIDDOCC_nFirstRecordOnPage","type":"int"},{"av":"nRC_GXsfl_138","ctrl":"GRIDDOCC","prop":"GridRC","grid":138,"type":"int"},{"av":"AV28ResumoDocumentosDescricao","fld":"vRESUMODOCUMENTOSDESCRICAO","grid":138,"hsh":true,"type":"svchar"},{"av":"AV29ResumoDocumentoObrigatorio","fld":"vRESUMODOCUMENTOOBRIGATORIO","grid":138,"hsh":true,"type":"boolean"},{"av":"AV30ResumoDocumento","fld":"vRESUMODOCUMENTO","grid":138,"type":"bitstr"},{"av":"AV31ResumoExtensao","fld":"vRESUMOEXTENSAO","grid":138,"hsh":true,"type":"svchar"},{"av":"AV71Nome","fld":"vNOME","grid":138,"hsh":true,"type":"svchar"},{"av":"AV72NomeArquivo","fld":"vNOMEARQUIVO","grid":138,"hsh":true,"type":"svchar"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV11WizardData","fld":"vWIZARDDATA","type":""}]}""");
         setEventMetadata("'WIZARDPREVIOUS'","""{"handler":"E126Q2","iparms":[{"av":"AV6WebSessionKey","fld":"vWEBSESSIONKEY","type":"svchar"},{"av":"AV34ProcedimentosMedicosId","fld":"vPROCEDIMENTOSMEDICOSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV35PropostaValor","fld":"vPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","hsh":true,"type":"decimal"},{"av":"AV36PropostaDescricao","fld":"vPROPOSTADESCRICAO","hsh":true,"type":"svchar"},{"av":"AV37ConvenioId","fld":"vCONVENIOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV38ConvenioCategoriaId","fld":"vCONVENIOCATEGORIAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"cmbavConveniovencimentoano"},{"av":"AV39ConvenioVencimentoAno","fld":"vCONVENIOVENCIMENTOANO","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"cmbavConveniovencimentomes"},{"av":"AV40ConvenioVencimentoMes","fld":"vCONVENIOVENCIMENTOMES","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"cmbavClientepixtipo"},{"av":"AV41ClientePixTipo","fld":"vCLIENTEPIXTIPO","hsh":true,"type":"svchar"},{"av":"AV42ClientePix","fld":"vCLIENTEPIX","hsh":true,"type":"svchar"},{"av":"AV43BancoId","fld":"vBANCOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV44ContaAgencia","fld":"vCONTAAGENCIA","hsh":true,"type":"svchar"},{"av":"AV45ContaNumero","fld":"vCONTANUMERO","hsh":true,"type":"svchar"},{"av":"AV46ResponsavelClienteRazaoSocial","fld":"vRESPONSAVELCLIENTERAZAOSOCIAL","pic":"@!","hsh":true,"type":"svchar"},{"av":"AV47ResponsavelClienteDocumento","fld":"vRESPONSAVELCLIENTEDOCUMENTO","hsh":true,"type":"svchar"},{"av":"AV48ResponsavelContatoEmail","fld":"vRESPONSAVELCONTATOEMAIL","hsh":true,"type":"svchar"},{"av":"AV49ClienteRazaoSocial","fld":"vCLIENTERAZAOSOCIAL","pic":"@!","hsh":true,"type":"svchar"},{"av":"AV50ClienteDocumento","fld":"vCLIENTEDOCUMENTO","hsh":true,"type":"svchar"},{"av":"AV51ContatoEmail","fld":"vCONTATOEMAIL","hsh":true,"type":"svchar"},{"av":"AV27ResumoDocumentosId","fld":"vRESUMODOCUMENTOSID","grid":138,"pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"GRIDDOCC_nFirstRecordOnPage","type":"int"},{"av":"nRC_GXsfl_138","ctrl":"GRIDDOCC","prop":"GridRC","grid":138,"type":"int"},{"av":"AV28ResumoDocumentosDescricao","fld":"vRESUMODOCUMENTOSDESCRICAO","grid":138,"hsh":true,"type":"svchar"},{"av":"AV29ResumoDocumentoObrigatorio","fld":"vRESUMODOCUMENTOOBRIGATORIO","grid":138,"hsh":true,"type":"boolean"},{"av":"AV30ResumoDocumento","fld":"vRESUMODOCUMENTO","grid":138,"type":"bitstr"},{"av":"AV31ResumoExtensao","fld":"vRESUMOEXTENSAO","grid":138,"hsh":true,"type":"svchar"},{"av":"AV71Nome","fld":"vNOME","grid":138,"hsh":true,"type":"svchar"},{"av":"AV72NomeArquivo","fld":"vNOMEARQUIVO","grid":138,"hsh":true,"type":"svchar"}]""");
         setEventMetadata("'WIZARDPREVIOUS'",""","oparms":[{"av":"AV11WizardData","fld":"vWIZARDDATA","type":""}]}""");
         setEventMetadata("VADICIONARANEXO.CLICK","""{"handler":"E156Q2","iparms":[{"av":"AV30ResumoDocumento","fld":"vRESUMODOCUMENTO","type":"bitstr"},{"av":"AV72NomeArquivo","fld":"vNOMEARQUIVO","hsh":true,"type":"svchar"},{"av":"AV31ResumoExtensao","fld":"vRESUMOEXTENSAO","hsh":true,"type":"svchar"}]""");
         setEventMetadata("VADICIONARANEXO.CLICK",""","oparms":[{"av":"Novajanela_Target","ctrl":"NOVAJANELA","prop":"Target"}]}""");
         setEventMetadata("GRIDDOCC_FIRSTPAGE","""{"handler":"subgriddocc_firstpage","iparms":[{"av":"GRIDDOCC_nFirstRecordOnPage","type":"int"},{"av":"GRIDDOCC_nEOF","type":"int"},{"av":"subGriddocc_Rows","ctrl":"GRIDDOCC","prop":"Rows"},{"av":"AV11WizardData","fld":"vWIZARDDATA","type":""},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true,"type":"boolean"},{"av":"AV35PropostaValor","fld":"vPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","hsh":true,"type":"decimal"},{"av":"AV36PropostaDescricao","fld":"vPROPOSTADESCRICAO","hsh":true,"type":"svchar"},{"av":"cmbavConveniovencimentoano"},{"av":"AV39ConvenioVencimentoAno","fld":"vCONVENIOVENCIMENTOANO","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"cmbavConveniovencimentomes"},{"av":"AV40ConvenioVencimentoMes","fld":"vCONVENIOVENCIMENTOMES","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"cmbavClientepixtipo"},{"av":"AV41ClientePixTipo","fld":"vCLIENTEPIXTIPO","hsh":true,"type":"svchar"},{"av":"AV42ClientePix","fld":"vCLIENTEPIX","hsh":true,"type":"svchar"},{"av":"AV44ContaAgencia","fld":"vCONTAAGENCIA","hsh":true,"type":"svchar"},{"av":"AV45ContaNumero","fld":"vCONTANUMERO","hsh":true,"type":"svchar"},{"av":"AV46ResponsavelClienteRazaoSocial","fld":"vRESPONSAVELCLIENTERAZAOSOCIAL","pic":"@!","hsh":true,"type":"svchar"},{"av":"AV47ResponsavelClienteDocumento","fld":"vRESPONSAVELCLIENTEDOCUMENTO","hsh":true,"type":"svchar"},{"av":"AV48ResponsavelContatoEmail","fld":"vRESPONSAVELCONTATOEMAIL","hsh":true,"type":"svchar"},{"av":"AV49ClienteRazaoSocial","fld":"vCLIENTERAZAOSOCIAL","pic":"@!","hsh":true,"type":"svchar"},{"av":"AV50ClienteDocumento","fld":"vCLIENTEDOCUMENTO","hsh":true,"type":"svchar"},{"av":"AV51ContatoEmail","fld":"vCONTATOEMAIL","hsh":true,"type":"svchar"},{"av":"sPrefix","type":"char"}]}""");
         setEventMetadata("GRIDDOCC_PREVPAGE","""{"handler":"subgriddocc_previouspage","iparms":[{"av":"GRIDDOCC_nFirstRecordOnPage","type":"int"},{"av":"GRIDDOCC_nEOF","type":"int"},{"av":"subGriddocc_Rows","ctrl":"GRIDDOCC","prop":"Rows"},{"av":"AV11WizardData","fld":"vWIZARDDATA","type":""},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true,"type":"boolean"},{"av":"AV35PropostaValor","fld":"vPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","hsh":true,"type":"decimal"},{"av":"AV36PropostaDescricao","fld":"vPROPOSTADESCRICAO","hsh":true,"type":"svchar"},{"av":"cmbavConveniovencimentoano"},{"av":"AV39ConvenioVencimentoAno","fld":"vCONVENIOVENCIMENTOANO","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"cmbavConveniovencimentomes"},{"av":"AV40ConvenioVencimentoMes","fld":"vCONVENIOVENCIMENTOMES","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"cmbavClientepixtipo"},{"av":"AV41ClientePixTipo","fld":"vCLIENTEPIXTIPO","hsh":true,"type":"svchar"},{"av":"AV42ClientePix","fld":"vCLIENTEPIX","hsh":true,"type":"svchar"},{"av":"AV44ContaAgencia","fld":"vCONTAAGENCIA","hsh":true,"type":"svchar"},{"av":"AV45ContaNumero","fld":"vCONTANUMERO","hsh":true,"type":"svchar"},{"av":"AV46ResponsavelClienteRazaoSocial","fld":"vRESPONSAVELCLIENTERAZAOSOCIAL","pic":"@!","hsh":true,"type":"svchar"},{"av":"AV47ResponsavelClienteDocumento","fld":"vRESPONSAVELCLIENTEDOCUMENTO","hsh":true,"type":"svchar"},{"av":"AV48ResponsavelContatoEmail","fld":"vRESPONSAVELCONTATOEMAIL","hsh":true,"type":"svchar"},{"av":"AV49ClienteRazaoSocial","fld":"vCLIENTERAZAOSOCIAL","pic":"@!","hsh":true,"type":"svchar"},{"av":"AV50ClienteDocumento","fld":"vCLIENTEDOCUMENTO","hsh":true,"type":"svchar"},{"av":"AV51ContatoEmail","fld":"vCONTATOEMAIL","hsh":true,"type":"svchar"},{"av":"sPrefix","type":"char"}]}""");
         setEventMetadata("GRIDDOCC_NEXTPAGE","""{"handler":"subgriddocc_nextpage","iparms":[{"av":"GRIDDOCC_nFirstRecordOnPage","type":"int"},{"av":"GRIDDOCC_nEOF","type":"int"},{"av":"subGriddocc_Rows","ctrl":"GRIDDOCC","prop":"Rows"},{"av":"AV11WizardData","fld":"vWIZARDDATA","type":""},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true,"type":"boolean"},{"av":"AV35PropostaValor","fld":"vPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","hsh":true,"type":"decimal"},{"av":"AV36PropostaDescricao","fld":"vPROPOSTADESCRICAO","hsh":true,"type":"svchar"},{"av":"cmbavConveniovencimentoano"},{"av":"AV39ConvenioVencimentoAno","fld":"vCONVENIOVENCIMENTOANO","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"cmbavConveniovencimentomes"},{"av":"AV40ConvenioVencimentoMes","fld":"vCONVENIOVENCIMENTOMES","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"cmbavClientepixtipo"},{"av":"AV41ClientePixTipo","fld":"vCLIENTEPIXTIPO","hsh":true,"type":"svchar"},{"av":"AV42ClientePix","fld":"vCLIENTEPIX","hsh":true,"type":"svchar"},{"av":"AV44ContaAgencia","fld":"vCONTAAGENCIA","hsh":true,"type":"svchar"},{"av":"AV45ContaNumero","fld":"vCONTANUMERO","hsh":true,"type":"svchar"},{"av":"AV46ResponsavelClienteRazaoSocial","fld":"vRESPONSAVELCLIENTERAZAOSOCIAL","pic":"@!","hsh":true,"type":"svchar"},{"av":"AV47ResponsavelClienteDocumento","fld":"vRESPONSAVELCLIENTEDOCUMENTO","hsh":true,"type":"svchar"},{"av":"AV48ResponsavelContatoEmail","fld":"vRESPONSAVELCONTATOEMAIL","hsh":true,"type":"svchar"},{"av":"AV49ClienteRazaoSocial","fld":"vCLIENTERAZAOSOCIAL","pic":"@!","hsh":true,"type":"svchar"},{"av":"AV50ClienteDocumento","fld":"vCLIENTEDOCUMENTO","hsh":true,"type":"svchar"},{"av":"AV51ContatoEmail","fld":"vCONTATOEMAIL","hsh":true,"type":"svchar"},{"av":"sPrefix","type":"char"}]}""");
         setEventMetadata("GRIDDOCC_LASTPAGE","""{"handler":"subgriddocc_lastpage","iparms":[{"av":"GRIDDOCC_nFirstRecordOnPage","type":"int"},{"av":"GRIDDOCC_nEOF","type":"int"},{"av":"subGriddocc_Rows","ctrl":"GRIDDOCC","prop":"Rows"},{"av":"AV11WizardData","fld":"vWIZARDDATA","type":""},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true,"type":"boolean"},{"av":"AV35PropostaValor","fld":"vPROPOSTAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","hsh":true,"type":"decimal"},{"av":"AV36PropostaDescricao","fld":"vPROPOSTADESCRICAO","hsh":true,"type":"svchar"},{"av":"cmbavConveniovencimentoano"},{"av":"AV39ConvenioVencimentoAno","fld":"vCONVENIOVENCIMENTOANO","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"cmbavConveniovencimentomes"},{"av":"AV40ConvenioVencimentoMes","fld":"vCONVENIOVENCIMENTOMES","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"cmbavClientepixtipo"},{"av":"AV41ClientePixTipo","fld":"vCLIENTEPIXTIPO","hsh":true,"type":"svchar"},{"av":"AV42ClientePix","fld":"vCLIENTEPIX","hsh":true,"type":"svchar"},{"av":"AV44ContaAgencia","fld":"vCONTAAGENCIA","hsh":true,"type":"svchar"},{"av":"AV45ContaNumero","fld":"vCONTANUMERO","hsh":true,"type":"svchar"},{"av":"AV46ResponsavelClienteRazaoSocial","fld":"vRESPONSAVELCLIENTERAZAOSOCIAL","pic":"@!","hsh":true,"type":"svchar"},{"av":"AV47ResponsavelClienteDocumento","fld":"vRESPONSAVELCLIENTEDOCUMENTO","hsh":true,"type":"svchar"},{"av":"AV48ResponsavelContatoEmail","fld":"vRESPONSAVELCONTATOEMAIL","hsh":true,"type":"svchar"},{"av":"AV49ClienteRazaoSocial","fld":"vCLIENTERAZAOSOCIAL","pic":"@!","hsh":true,"type":"svchar"},{"av":"AV50ClienteDocumento","fld":"vCLIENTEDOCUMENTO","hsh":true,"type":"svchar"},{"av":"AV51ContatoEmail","fld":"vCONTATOEMAIL","hsh":true,"type":"svchar"},{"av":"sPrefix","type":"char"},{"av":"subGriddocc_Recordcount","type":"int"}]}""");
         setEventMetadata("VALIDV_CONTATOEMAIL","""{"handler":"Validv_Contatoemail","iparms":[]}""");
         setEventMetadata("VALIDV_RESPONSAVELCONTATOEMAIL","""{"handler":"Validv_Responsavelcontatoemail","iparms":[]}""");
         setEventMetadata("VALIDV_CLIENTEPIXTIPO","""{"handler":"Validv_Clientepixtipo","iparms":[]}""");
         setEventMetadata("VALIDV_CONVENIOVENCIMENTOANO","""{"handler":"Validv_Conveniovencimentoano","iparms":[]}""");
         setEventMetadata("VALIDV_CONVENIOVENCIMENTOMES","""{"handler":"Validv_Conveniovencimentomes","iparms":[]}""");
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
         AV68HTTPREQUEST = new GxHttpRequest( context);
         Combo_conveniocategoriaid_Selectedvalue_get = "";
         Combo_convenioid_Selectedvalue_get = "";
         Combo_procedimentosmedicosid_Selectedvalue_get = "";
         Combo_bancoid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV11WizardData = new SdtWpNovaPropostaData(context);
         AV36PropostaDescricao = "";
         AV41ClientePixTipo = "";
         AV42ClientePix = "";
         AV44ContaAgencia = "";
         AV45ContaNumero = "";
         AV46ResponsavelClienteRazaoSocial = "";
         AV47ResponsavelClienteDocumento = "";
         AV48ResponsavelContatoEmail = "";
         AV49ClienteRazaoSocial = "";
         AV50ClienteDocumento = "";
         AV51ContatoEmail = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         forbiddenHiddens = new GXProperties();
         AV55BancoId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV52ProcedimentosMedicosId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV53ConvenioId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV54ConvenioCategoriaId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         lblTextblockcombo_bancoid_Jsonclick = "";
         ucCombo_bancoid = new GXUserControl();
         Combo_bancoid_Caption = "";
         lblTextblockcombo_procedimentosmedicosid_Jsonclick = "";
         ucCombo_procedimentosmedicosid = new GXUserControl();
         Combo_procedimentosmedicosid_Caption = "";
         lblTextblockcombo_convenioid_Jsonclick = "";
         ucCombo_convenioid = new GXUserControl();
         Combo_convenioid_Caption = "";
         lblTextblockcombo_conveniocategoriaid_Jsonclick = "";
         ucCombo_conveniocategoriaid = new GXUserControl();
         Combo_conveniocategoriaid_Caption = "";
         lblTextblockconveniovencimentoano_Jsonclick = "";
         GriddoccContainer = new GXWebGrid( context);
         sStyleString = "";
         ucBtnwizardprevious = new GXUserControl();
         ucBtnwizardnext = new GXUserControl();
         ucNovajanela = new GXUserControl();
         ucGriddocc_empowerer = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV32AdicionarAnexo = "";
         AV28ResumoDocumentosDescricao = "";
         AV30ResumoDocumento = "";
         AV31ResumoExtensao = "";
         AV71Nome = "";
         AV72NomeArquivo = "";
         GXDecQS = "";
         hsh = "";
         Griddocc_empowerer_Gridinternalname = "";
         AV70Grid = new SdtWpNovaPropostaData_Documentos_GridDocumentosItem(context);
         GriddoccRow = new GXWebRow();
         AV56WwpContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtWWPContext2 = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         H006Q2_A331LimiteAprovacaoId = new int[1] ;
         H006Q2_A332LimiteAprovacaoValorMinimo = new decimal[1] ;
         H006Q2_n332LimiteAprovacaoValorMinimo = new bool[] {false} ;
         H006Q2_A334LimiteAprovacaoAprovacoes = new short[1] ;
         H006Q2_n334LimiteAprovacaoAprovacoes = new bool[] {false} ;
         AV58Proposta = new SdtProposta(context);
         AV63Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV66PropostaDocumentos = new SdtPropostaDocumentos(context);
         GXt_objcol_SdtMessages_Message3 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV67NotificationLink = "";
         AV69HTML = "";
         GXt_char1 = "";
         AV5WebSession = context.GetSession();
         AV73GridDoccItem = new SdtWpNovaPropostaData_Resumo_GridDoccItem(context);
         H006Q3_A495ConvenioCategoriaStatus = new bool[] {false} ;
         H006Q3_n495ConvenioCategoriaStatus = new bool[] {false} ;
         H006Q3_A493ConvenioCategoriaId = new int[1] ;
         H006Q3_A494ConvenioCategoriaDescricao = new string[] {""} ;
         H006Q3_n494ConvenioCategoriaDescricao = new bool[] {false} ;
         A494ConvenioCategoriaDescricao = "";
         AV26Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         Combo_conveniocategoriaid_Selectedvalue_set = "";
         H006Q4_A412ConvenioStatus = new bool[] {false} ;
         H006Q4_A410ConvenioId = new int[1] ;
         H006Q4_A411ConvenioDescricao = new string[] {""} ;
         H006Q4_n411ConvenioDescricao = new bool[] {false} ;
         A411ConvenioDescricao = "";
         Combo_convenioid_Selectedvalue_set = "";
         H006Q5_A376ProcedimentosMedicosId = new int[1] ;
         H006Q5_A379ProcedimentosMedicosArea = new string[] {""} ;
         H006Q5_n379ProcedimentosMedicosArea = new bool[] {false} ;
         H006Q5_A377ProcedimentosMedicosNome = new string[] {""} ;
         H006Q5_n377ProcedimentosMedicosNome = new bool[] {false} ;
         A379ProcedimentosMedicosArea = "";
         A377ProcedimentosMedicosNome = "";
         AV23ComboTitles = new GxSimpleCollection<string>();
         Combo_procedimentosmedicosid_Selectedvalue_set = "";
         H006Q6_A402BancoId = new int[1] ;
         H006Q6_A404BancoCodigo = new int[1] ;
         H006Q6_n404BancoCodigo = new bool[] {false} ;
         H006Q6_A403BancoNome = new string[] {""} ;
         H006Q6_n403BancoNome = new bool[] {false} ;
         A403BancoNome = "";
         Combo_bancoid_Selectedvalue_set = "";
         AV76Arquivo = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV6WebSessionKey = "";
         sCtrlAV8PreviousStep = "";
         sCtrlAV7GoingBack = "";
         subGriddocc_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         gxblobfileaux = new GxFile(context.GetPhysicalPath());
         GriddoccColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpnovapropostaresumo__default(),
            new Object[][] {
                new Object[] {
               H006Q2_A331LimiteAprovacaoId, H006Q2_A332LimiteAprovacaoValorMinimo, H006Q2_n332LimiteAprovacaoValorMinimo, H006Q2_A334LimiteAprovacaoAprovacoes, H006Q2_n334LimiteAprovacaoAprovacoes
               }
               , new Object[] {
               H006Q3_A495ConvenioCategoriaStatus, H006Q3_n495ConvenioCategoriaStatus, H006Q3_A493ConvenioCategoriaId, H006Q3_A494ConvenioCategoriaDescricao, H006Q3_n494ConvenioCategoriaDescricao
               }
               , new Object[] {
               H006Q4_A412ConvenioStatus, H006Q4_A410ConvenioId, H006Q4_A411ConvenioDescricao, H006Q4_n411ConvenioDescricao
               }
               , new Object[] {
               H006Q5_A376ProcedimentosMedicosId, H006Q5_A379ProcedimentosMedicosArea, H006Q5_n379ProcedimentosMedicosArea, H006Q5_A377ProcedimentosMedicosNome, H006Q5_n377ProcedimentosMedicosNome
               }
               , new Object[] {
               H006Q6_A402BancoId, H006Q6_A404BancoCodigo, H006Q6_n404BancoCodigo, H006Q6_A403BancoNome, H006Q6_n403BancoNome
               }
            }
         );
         /* GeneXus formulas. */
         edtavClienterazaosocial_Enabled = 0;
         edtavClientedocumento_Enabled = 0;
         edtavContatoemail_Enabled = 0;
         edtavResponsavelclienterazaosocial_Enabled = 0;
         edtavResponsavelclientedocumento_Enabled = 0;
         edtavResponsavelcontatoemail_Enabled = 0;
         edtavContaagencia_Enabled = 0;
         edtavContanumero_Enabled = 0;
         cmbavClientepixtipo.Enabled = 0;
         edtavClientepix_Enabled = 0;
         edtavPropostavalor_Enabled = 0;
         edtavPropostadescricao_Enabled = 0;
         cmbavConveniovencimentoano.Enabled = 0;
         cmbavConveniovencimentomes.Enabled = 0;
         edtavAdicionaranexo_Enabled = 0;
         edtavResumodocumentosid_Enabled = 0;
         edtavResumodocumentosdescricao_Enabled = 0;
         cmbavResumodocumentoobrigatorio.Enabled = 0;
         edtavResumodocumento_Enabled = 0;
         edtavResumoextensao_Enabled = 0;
         edtavNome_Enabled = 0;
         edtavNomearquivo_Enabled = 0;
      }

      private short GRIDDOCC_nEOF ;
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
      private short nDynComponent ;
      private short AV39ConvenioVencimentoAno ;
      private short AV40ConvenioVencimentoMes ;
      private short A334LimiteAprovacaoAprovacoes ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short subGriddocc_Backcolorstyle ;
      private short gxcookieaux ;
      private short AV57PropostaQuantidadeAprovadores ;
      private short AV60ContratoSLA ;
      private short nGXWrapped ;
      private short subGriddocc_Backstyle ;
      private short subGriddocc_Titlebackstyle ;
      private short subGriddocc_Allowselection ;
      private short subGriddocc_Allowhovering ;
      private short subGriddocc_Allowcollapsing ;
      private short subGriddocc_Collapsed ;
      private int nRC_GXsfl_138 ;
      private int subGriddocc_Recordcount ;
      private int subGriddocc_Rows ;
      private int nGXsfl_138_idx=1 ;
      private int edtavClienterazaosocial_Enabled ;
      private int edtavClientedocumento_Enabled ;
      private int edtavContatoemail_Enabled ;
      private int edtavResponsavelclienterazaosocial_Enabled ;
      private int edtavResponsavelclientedocumento_Enabled ;
      private int edtavResponsavelcontatoemail_Enabled ;
      private int edtavContaagencia_Enabled ;
      private int edtavContanumero_Enabled ;
      private int edtavClientepix_Enabled ;
      private int edtavPropostavalor_Enabled ;
      private int edtavPropostadescricao_Enabled ;
      private int edtavAdicionaranexo_Enabled ;
      private int edtavResumodocumentosid_Enabled ;
      private int edtavResumodocumentosdescricao_Enabled ;
      private int edtavResumodocumento_Enabled ;
      private int edtavResumoextensao_Enabled ;
      private int edtavNome_Enabled ;
      private int edtavNomearquivo_Enabled ;
      private int divTablecontentresponsavel_Visible ;
      private int divTablebanco_Visible ;
      private int divTablepix_Visible ;
      private int AV43BancoId ;
      private int edtavBancoid_Visible ;
      private int AV34ProcedimentosMedicosId ;
      private int edtavProcedimentosmedicosid_Visible ;
      private int AV37ConvenioId ;
      private int edtavConvenioid_Visible ;
      private int AV38ConvenioCategoriaId ;
      private int edtavConveniocategoriaid_Visible ;
      private int AV27ResumoDocumentosId ;
      private int subGriddocc_Islastpage ;
      private int GRIDDOCC_nGridOutOfScope ;
      private int AV77GXV1 ;
      private int AV79GXV2 ;
      private int nGXsfl_138_fel_idx=1 ;
      private int A493ConvenioCategoriaId ;
      private int A410ConvenioId ;
      private int A376ProcedimentosMedicosId ;
      private int A402BancoId ;
      private int A404BancoCodigo ;
      private int idxLst ;
      private int subGriddocc_Backcolor ;
      private int subGriddocc_Allbackcolor ;
      private int subGriddocc_Titlebackcolor ;
      private int subGriddocc_Selectedindex ;
      private int subGriddocc_Selectioncolor ;
      private int subGriddocc_Hoveringcolor ;
      private long GRIDDOCC_nFirstRecordOnPage ;
      private long GRIDDOCC_nCurrentRecord ;
      private decimal AV35PropostaValor ;
      private decimal A332LimiteAprovacaoValorMinimo ;
      private decimal AV59ContratoTaxa ;
      private decimal AV61ContratoJurosMora ;
      private decimal AV62ContratoIOFMinimo ;
      private string Combo_conveniocategoriaid_Selectedvalue_get ;
      private string Combo_convenioid_Selectedvalue_get ;
      private string Combo_procedimentosmedicosid_Selectedvalue_get ;
      private string Combo_bancoid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_138_idx="0001" ;
      private string edtavClienterazaosocial_Internalname ;
      private string edtavClientedocumento_Internalname ;
      private string edtavContatoemail_Internalname ;
      private string edtavResponsavelclienterazaosocial_Internalname ;
      private string edtavResponsavelclientedocumento_Internalname ;
      private string edtavResponsavelcontatoemail_Internalname ;
      private string edtavContaagencia_Internalname ;
      private string edtavContanumero_Internalname ;
      private string cmbavClientepixtipo_Internalname ;
      private string edtavClientepix_Internalname ;
      private string edtavPropostavalor_Internalname ;
      private string edtavPropostadescricao_Internalname ;
      private string cmbavConveniovencimentoano_Internalname ;
      private string cmbavConveniovencimentomes_Internalname ;
      private string edtavAdicionaranexo_Internalname ;
      private string edtavResumodocumentosid_Internalname ;
      private string edtavResumodocumentosdescricao_Internalname ;
      private string cmbavResumodocumentoobrigatorio_Internalname ;
      private string edtavResumodocumento_Internalname ;
      private string edtavResumoextensao_Internalname ;
      private string edtavNome_Internalname ;
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
      private string grpUnnamedgroup1_Internalname ;
      private string divTablecliente_Internalname ;
      private string TempTags ;
      private string edtavClienterazaosocial_Jsonclick ;
      private string edtavClientedocumento_Jsonclick ;
      private string edtavContatoemail_Jsonclick ;
      private string divTablecontentresponsavel_Internalname ;
      private string grpUnnamedgroup5_Internalname ;
      private string divTablerespnosavel_Internalname ;
      private string edtavResponsavelclienterazaosocial_Jsonclick ;
      private string edtavResponsavelclientedocumento_Jsonclick ;
      private string edtavResponsavelcontatoemail_Jsonclick ;
      private string grpUnnamedgroup2_Internalname ;
      private string divTableconta_Internalname ;
      private string divTablebanco_Internalname ;
      private string divTablesplittedbancoid_Internalname ;
      private string lblTextblockcombo_bancoid_Internalname ;
      private string lblTextblockcombo_bancoid_Jsonclick ;
      private string Combo_bancoid_Caption ;
      private string Combo_bancoid_Cls ;
      private string Combo_bancoid_Internalname ;
      private string edtavContaagencia_Jsonclick ;
      private string edtavContanumero_Jsonclick ;
      private string divTablepix_Internalname ;
      private string cmbavClientepixtipo_Jsonclick ;
      private string edtavClientepix_Jsonclick ;
      private string grpUnnamedgroup3_Internalname ;
      private string divTableproposta_Internalname ;
      private string divTablesplittedprocedimentosmedicosid_Internalname ;
      private string lblTextblockcombo_procedimentosmedicosid_Internalname ;
      private string lblTextblockcombo_procedimentosmedicosid_Jsonclick ;
      private string Combo_procedimentosmedicosid_Caption ;
      private string Combo_procedimentosmedicosid_Cls ;
      private string Combo_procedimentosmedicosid_Internalname ;
      private string edtavPropostavalor_Jsonclick ;
      private string edtavPropostadescricao_Jsonclick ;
      private string divTablesplittedconvenioid_Internalname ;
      private string lblTextblockcombo_convenioid_Internalname ;
      private string lblTextblockcombo_convenioid_Jsonclick ;
      private string Combo_convenioid_Caption ;
      private string Combo_convenioid_Cls ;
      private string Combo_convenioid_Internalname ;
      private string divTablesplittedconveniocategoriaid_Internalname ;
      private string lblTextblockcombo_conveniocategoriaid_Internalname ;
      private string lblTextblockcombo_conveniocategoriaid_Jsonclick ;
      private string Combo_conveniocategoriaid_Caption ;
      private string Combo_conveniocategoriaid_Cls ;
      private string Combo_conveniocategoriaid_Internalname ;
      private string divTablesplittedconveniovencimentoano_Internalname ;
      private string lblTextblockconveniovencimentoano_Internalname ;
      private string lblTextblockconveniovencimentoano_Jsonclick ;
      private string grpUnnamedgroup4_Internalname ;
      private string divTabledocumentos_Internalname ;
      private string sStyleString ;
      private string subGriddocc_Internalname ;
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
      private string edtavBancoid_Internalname ;
      private string edtavBancoid_Jsonclick ;
      private string edtavProcedimentosmedicosid_Internalname ;
      private string edtavProcedimentosmedicosid_Jsonclick ;
      private string edtavConvenioid_Internalname ;
      private string edtavConvenioid_Jsonclick ;
      private string edtavConveniocategoriaid_Internalname ;
      private string edtavConveniocategoriaid_Jsonclick ;
      private string Griddocc_empowerer_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV32AdicionarAnexo ;
      private string GXDecQS ;
      private string hsh ;
      private string Combo_procedimentosmedicosid_Htmltemplate ;
      private string Combo_bancoid_Htmltemplate ;
      private string Griddocc_empowerer_Gridinternalname ;
      private string GXt_char1 ;
      private string sGXsfl_138_fel_idx="0001" ;
      private string Combo_conveniocategoriaid_Selectedvalue_set ;
      private string Combo_convenioid_Selectedvalue_set ;
      private string Combo_procedimentosmedicosid_Selectedvalue_set ;
      private string Combo_bancoid_Selectedvalue_set ;
      private string Novajanela_Target ;
      private string tblTablemergedconveniovencimentoano_Internalname ;
      private string cmbavConveniovencimentoano_Jsonclick ;
      private string cmbavConveniovencimentomes_Jsonclick ;
      private string sCtrlAV6WebSessionKey ;
      private string sCtrlAV8PreviousStep ;
      private string sCtrlAV7GoingBack ;
      private string subGriddocc_Class ;
      private string subGriddocc_Linesclass ;
      private string ROClassString ;
      private string edtavAdicionaranexo_Jsonclick ;
      private string edtavResumodocumentosid_Jsonclick ;
      private string edtavResumodocumentosdescricao_Jsonclick ;
      private string GXCCtl ;
      private string cmbavResumodocumentoobrigatorio_Jsonclick ;
      private string edtavResumodocumento_Filetype ;
      private string edtavResumodocumento_Contenttype ;
      private string edtavResumodocumento_Parameters ;
      private string edtavResumodocumento_Jsonclick ;
      private string edtavResumoextensao_Jsonclick ;
      private string edtavNome_Jsonclick ;
      private string edtavNomearquivo_Jsonclick ;
      private string subGriddocc_Header ;
      private bool AV7GoingBack ;
      private bool wcpOAV7GoingBack ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV10HasValidationErrors ;
      private bool bGXsfl_138_Refreshing=false ;
      private bool wbLoad ;
      private bool Combo_bancoid_Emptyitem ;
      private bool Combo_procedimentosmedicosid_Emptyitem ;
      private bool Combo_convenioid_Emptyitem ;
      private bool Combo_conveniocategoriaid_Emptyitem ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool AV29ResumoDocumentoObrigatorio ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool Combo_conveniocategoriaid_Enabled ;
      private bool Combo_convenioid_Enabled ;
      private bool Combo_procedimentosmedicosid_Enabled ;
      private bool Combo_bancoid_Enabled ;
      private bool n332LimiteAprovacaoValorMinimo ;
      private bool n334LimiteAprovacaoAprovacoes ;
      private bool AV64IsContinue ;
      private bool A495ConvenioCategoriaStatus ;
      private bool n495ConvenioCategoriaStatus ;
      private bool n494ConvenioCategoriaDescricao ;
      private bool A412ConvenioStatus ;
      private bool n411ConvenioDescricao ;
      private bool n379ProcedimentosMedicosArea ;
      private bool n377ProcedimentosMedicosNome ;
      private bool n404BancoCodigo ;
      private bool n403BancoNome ;
      private string AV69HTML ;
      private string AV6WebSessionKey ;
      private string AV8PreviousStep ;
      private string wcpOAV6WebSessionKey ;
      private string wcpOAV8PreviousStep ;
      private string AV36PropostaDescricao ;
      private string AV41ClientePixTipo ;
      private string AV42ClientePix ;
      private string AV44ContaAgencia ;
      private string AV45ContaNumero ;
      private string AV46ResponsavelClienteRazaoSocial ;
      private string AV47ResponsavelClienteDocumento ;
      private string AV48ResponsavelContatoEmail ;
      private string AV49ClienteRazaoSocial ;
      private string AV50ClienteDocumento ;
      private string AV51ContatoEmail ;
      private string AV28ResumoDocumentosDescricao ;
      private string AV31ResumoExtensao ;
      private string AV71Nome ;
      private string AV72NomeArquivo ;
      private string AV67NotificationLink ;
      private string A494ConvenioCategoriaDescricao ;
      private string A411ConvenioDescricao ;
      private string A379ProcedimentosMedicosArea ;
      private string A377ProcedimentosMedicosNome ;
      private string A403BancoNome ;
      private string AV76Arquivo ;
      private string AV30ResumoDocumento ;
      private IGxSession AV5WebSession ;
      private GxFile gxblobfileaux ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid GriddoccContainer ;
      private GXWebRow GriddoccRow ;
      private GXWebColumn GriddoccColumn ;
      private GXUserControl ucCombo_bancoid ;
      private GXUserControl ucCombo_procedimentosmedicosid ;
      private GXUserControl ucCombo_convenioid ;
      private GXUserControl ucCombo_conveniocategoriaid ;
      private GXUserControl ucBtnwizardprevious ;
      private GXUserControl ucBtnwizardnext ;
      private GXUserControl ucNovajanela ;
      private GXUserControl ucGriddocc_empowerer ;
      private GXWebForm Form ;
      private GxHttpRequest AV68HTTPREQUEST ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavClientepixtipo ;
      private GXCombobox cmbavConveniovencimentoano ;
      private GXCombobox cmbavConveniovencimentomes ;
      private GXCombobox cmbavResumodocumentoobrigatorio ;
      private SdtWpNovaPropostaData AV11WizardData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV55BancoId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV52ProcedimentosMedicosId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV53ConvenioId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV54ConvenioCategoriaId_Data ;
      private SdtWpNovaPropostaData_Documentos_GridDocumentosItem AV70Grid ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV56WwpContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext GXt_SdtWWPContext2 ;
      private IDataStoreProvider pr_default ;
      private int[] H006Q2_A331LimiteAprovacaoId ;
      private decimal[] H006Q2_A332LimiteAprovacaoValorMinimo ;
      private bool[] H006Q2_n332LimiteAprovacaoValorMinimo ;
      private short[] H006Q2_A334LimiteAprovacaoAprovacoes ;
      private bool[] H006Q2_n334LimiteAprovacaoAprovacoes ;
      private SdtProposta AV58Proposta ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV63Messages ;
      private SdtPropostaDocumentos AV66PropostaDocumentos ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> GXt_objcol_SdtMessages_Message3 ;
      private SdtWpNovaPropostaData_Resumo_GridDoccItem AV73GridDoccItem ;
      private bool[] H006Q3_A495ConvenioCategoriaStatus ;
      private bool[] H006Q3_n495ConvenioCategoriaStatus ;
      private int[] H006Q3_A493ConvenioCategoriaId ;
      private string[] H006Q3_A494ConvenioCategoriaDescricao ;
      private bool[] H006Q3_n494ConvenioCategoriaDescricao ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV26Combo_DataItem ;
      private bool[] H006Q4_A412ConvenioStatus ;
      private int[] H006Q4_A410ConvenioId ;
      private string[] H006Q4_A411ConvenioDescricao ;
      private bool[] H006Q4_n411ConvenioDescricao ;
      private int[] H006Q5_A376ProcedimentosMedicosId ;
      private string[] H006Q5_A379ProcedimentosMedicosArea ;
      private bool[] H006Q5_n379ProcedimentosMedicosArea ;
      private string[] H006Q5_A377ProcedimentosMedicosNome ;
      private bool[] H006Q5_n377ProcedimentosMedicosNome ;
      private GxSimpleCollection<string> AV23ComboTitles ;
      private int[] H006Q6_A402BancoId ;
      private int[] H006Q6_A404BancoCodigo ;
      private bool[] H006Q6_n404BancoCodigo ;
      private string[] H006Q6_A403BancoNome ;
      private bool[] H006Q6_n403BancoNome ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpnovapropostaresumo__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH006Q2;
          prmH006Q2 = new Object[] {
          new ParDef("AV35PropostaValor",GXType.Number,18,2)
          };
          Object[] prmH006Q3;
          prmH006Q3 = new Object[] {
          };
          Object[] prmH006Q4;
          prmH006Q4 = new Object[] {
          };
          Object[] prmH006Q5;
          prmH006Q5 = new Object[] {
          };
          Object[] prmH006Q6;
          prmH006Q6 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H006Q2", "SELECT LimiteAprovacaoId, LimiteAprovacaoValorMinimo, LimiteAprovacaoAprovacoes FROM LimiteAprovacao WHERE LimiteAprovacaoValorMinimo <= :AV35PropostaValor ORDER BY LimiteAprovacaoValorMinimo DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006Q2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H006Q3", "SELECT ConvenioCategoriaStatus, ConvenioCategoriaId, ConvenioCategoriaDescricao FROM ConvenioCategoria WHERE ConvenioCategoriaStatus = TRUE ORDER BY ConvenioCategoriaDescricao ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006Q3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H006Q4", "SELECT ConvenioStatus, ConvenioId, ConvenioDescricao FROM Convenio WHERE ConvenioStatus = TRUE ORDER BY ConvenioDescricao ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006Q4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H006Q5", "SELECT ProcedimentosMedicosId, ProcedimentosMedicosArea, ProcedimentosMedicosNome FROM ProcedimentosMedicos ORDER BY ProcedimentosMedicosNome ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006Q5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H006Q6", "SELECT BancoId, BancoCodigo, BancoNome FROM Banco ORDER BY BancoNome ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006Q6,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 1 :
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 2 :
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
       }
    }

 }

}
